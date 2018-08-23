Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class views_bulk_email
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            If Not Page.IsPostBack Then
                Trace.Warn("BulkEmailStatus = " + objFunction.ReturnString(Session("BulkEmailStatus")))
                If objFunction.ReturnString(Session("BulkEmailStatus")) <> "" And objFunction.ReturnString(Session("BulkEmailStatus")) = "SendBulkEmail" Then
                    Dim javaScriptMsg As String = ""
                    javaScriptMsg += "<script type='text/javascript'>"
                    javaScriptMsg += "alert('We are sending the emails please do not close this window');"
                    javaScriptMsg += "SendEmail_JS();"
                    javaScriptMsg += "</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScriptMsg)
                    'SendBulkEmails()
                Else
                    Response.Redirect("dashboard.aspx")
                End If
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' Click event of the button to send bulk email.
    ''' </summary>
    Protected Sub BUT_Send_Email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Send_Email.Click
        Try
            SendBulkEmails()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to send bulk email to supplier
    ''' </summary>
    Public Sub SendBulkEmails()
        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            Dim objDLPaymentToSupplier As clsDLPaymentToSupplier = New clsDLPaymentToSupplier

            Dim intMonthVal As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            Dim intYearVal As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            'Dim intMonthVal As Integer = 8
            'Dim intYearVal As Integer = 2017

            objBEPaymentToSupplier.MonthVal = intMonthVal
            objBEPaymentToSupplier.YearVal = intYearVal
            objBEPaymentToSupplier.SupplierType = 1

            Dim dstData As DataSet = objDLPaymentToSupplier.GetSupplierDetailByMonthYearAndSupplierType(objBEPaymentToSupplier, intCompanyId)

            If objFunction.CheckDataSet(dstData) Then

                Dim objBEPaymentToSupplierEmailSent As clsBEPaymentToSupplierEmailSent = New clsBEPaymentToSupplierEmailSent
                objBEPaymentToSupplierEmailSent.MonthVal = intMonthVal
                objBEPaymentToSupplierEmailSent.YearVal = intYearVal
                objBEPaymentToSupplierEmailSent.SupplierType = 1
                Dim dstSendEmailData As DataSet = (New clsDLPaymentToSupplierEmailSent()).GetSupplierEmailDetailByMonthYearAndSupplierType(objBEPaymentToSupplierEmailSent, intCompanyId)

                Trace.Warn("Count = " + objFunction.ReturnString(dstData.Tables(0).Rows.Count))
                Dim dtDistinctData As DataTable = dstData.Tables(0).DefaultView.ToTable(True, "supplier_id")
                Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))

                If objFunction.CheckDataTable(dtDistinctData) Then

                    Dim lstEmailContent = New List(Of Dictionary(Of String, String))()

                    For i = 0 To dtDistinctData.Rows.Count - 1

                        'LABEL_Send_Email_Count.Text = "Sending " + objFunction.ReturnString((i + 1)) + " of " + objFunction.ReturnString(dtDistinctData.Rows.Count) + " emails. Please wait"

                        Dim dtTemp As DataTable = dstData.Tables(0)
                        dtTemp.DefaultView.RowFilter = "supplier_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("supplier_id")) + " AND supplier_id <> 0"
                        Dim dtData As DataTable = dtTemp.DefaultView.ToTable()

                        Trace.Warn("supplier_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("supplier_id")))
                        If objFunction.CheckDataTable(dtData) Then

                            Trace.Warn("dtData Count = " + objFunction.ReturnString(dtData.Rows.Count))

                            Dim dtEmailDataTemp As DataTable = Nothing
                            Dim dtEmailData As DataTable = Nothing
                            If objFunction.CheckDataSet(dstSendEmailData) Then
                                dtEmailDataTemp = dstSendEmailData.Tables(0)
                                dtEmailDataTemp.DefaultView.RowFilter = "supplier_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("supplier_id")) + " AND supplier_id <> 0"
                                dtEmailData = dtEmailDataTemp.DefaultView.ToTable()
                            End If

                            If Not objFunction.CheckDataTable(dtEmailData) Then

                                Dim strRepeaterData As String = ""
                                Dim dblTotalCost As Double = 0

                                For j = 0 To dtData.Rows.Count - 1

                                    Dim lngNoOfNight As Long = 0
                                    If objFunction.ReturnString(dtData.Rows(j)("checkin")) <> "" And objFunction.ReturnString(dtData.Rows(j)("checkout")) <> "" Then
                                        lngNoOfNight = DateDiff(DateInterval.Day, Convert.ToDateTime(dtData.Rows(j)("checkin")), Convert.ToDateTime(dtData.Rows(j)("checkout")))
                                    End If
                                    Trace.Warn("lngNoOfNight = " + objFunction.ReturnString(lngNoOfNight))

                                    Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
                                    objBEAccomStageRoom.AccomStageId = objFunction.ReturnInteger(dtData.Rows(j)("accom_stage_id"))
                                    Dim dstTotalCostToEasyways As DataSet = (New clsDLAccomStageRoom()).GetAccomStageRoomByAccomStageId(objBEAccomStageRoom)
                                    Dim dblCost As Double = 0
                                    Dim strAccomRoomType As String = ""
                                    If objFunction.CheckDataSet(dstTotalCostToEasyways) Then
                                        For k = 0 To dstTotalCostToEasyways.Tables(0).Rows.Count - 1
                                            dblCost += (objFunction.ReturnDouble(dstTotalCostToEasyways.Tables(0).Rows(k)("cost_easyways")) + objFunction.ReturnDouble(dstTotalCostToEasyways.Tables(0).Rows(k)("total_cost_dogs"))) * lngNoOfNight
                                            strAccomRoomType += objFunction.ReturnString(dstTotalCostToEasyways.Tables(0).Rows(k)("RoomTypeName"))
                                            Dim dstAccomStageRoomFacility As DataSet = (New clsDLAccomStageRoom()).GetRoomFacilitiesNameByAccomStageRoomId(objFunction.ReturnInteger(dstTotalCostToEasyways.Tables(0).Rows(k)("id")))
                                            Dim strAccomStageRoomFacilityName As String = ""
                                            If objFunction.CheckDataSet(dstAccomStageRoomFacility) Then
                                                For l = 0 To dstAccomStageRoomFacility.Tables(0).Rows.Count - 1
                                                    strAccomStageRoomFacilityName += objFunction.ReturnString(dstAccomStageRoomFacility.Tables(0).Rows(l)("RoomFacilitiesName")) + ","
                                                Next
                                            End If
                                            If strAccomStageRoomFacilityName <> "" Then
                                                strAccomRoomType = strAccomRoomType + " " + strAccomStageRoomFacilityName
                                            Else
                                                strAccomRoomType = strAccomRoomType + " " + strAccomStageRoomFacilityName + ","
                                            End If
                                        Next
                                    End If
                                    dblTotalCost += dblCost

                                    'strRepeaterData += "<br/>" + objFunction.ReturnString(dtData.Rows(j)("unique_id")) + "&nbsp;&mdash;&nbsp; " + SetDateVal(objFunction.ReturnString(dtData.Rows(j)("DateStarted"))) + "&nbsp;&mdash;&nbsp;" + objFunction.ReturnString(dtData.Rows(j)("ClientName")) + "&nbsp;&mdash;&nbsp;" + dblCost.ToString("0.00")
                                    'strRepeaterData += "<br/>" + SetDateVal(objFunction.ReturnString(dtData.Rows(j)("checkin"))) + "&nbsp;&mdash;&nbsp; " + objFunction.ReturnString(dtData.Rows(j)("ClientName")) + "&nbsp;&mdash;&nbsp;" + objFunction.ReturnString(dtData.Rows(j)("AgentName")) + "&nbsp;&mdash;&nbsp;" + objFunction.ReturnString(dtData.Rows(j)("no_males")) + "&nbsp;&mdash;&nbsp;" + strAccomRoomType.TrimEnd(",") + "&nbsp;&mdash;&nbsp;" + dblCost.ToString("0.00") + "&nbsp;&mdash;&nbsp;" + objFunction.ReturnString(dtData.Rows(j)("AccomPhoneNo"))
                                    'strRepeaterData += "<br/>" + SetDateVal(objFunction.ReturnString(dtData.Rows(j)("checkin"))) + "&nbsp;&mdash;&nbsp; " + objFunction.ReturnString(dtData.Rows(j)("ClientName")) + "&nbsp;&mdash;&nbsp;" + objFunction.ReturnString(dtData.Rows(j)("AgentName")) + "&nbsp;&mdash;&nbsp;" + objFunction.ReturnString(dtData.Rows(j)("no_males")) + "&nbsp;&mdash;&nbsp;" + strAccomRoomType.TrimEnd(",") + "&nbsp;&mdash;&nbsp;" + objFunction.ReturnString(dtData.Rows(j)("AccomPhoneNo"))
                                    strRepeaterData += "<tr>"
                                    strRepeaterData += "<td>" + SetDateVal(objFunction.ReturnString(dtData.Rows(j)("checkin"))) + "</td>"
                                    strRepeaterData += "<td>" + objFunction.ReturnString(dtData.Rows(j)("ClientName")) + "</td>"
                                    strRepeaterData += "<td>" + objFunction.ReturnString(dtData.Rows(j)("AgentName")) + "</td>"
                                    strRepeaterData += "<td>" + objFunction.ReturnString(dtData.Rows(j)("total_num")) + "</td>"
                                    strRepeaterData += "<td>" + strAccomRoomType.TrimEnd(",") + "</td>"
                                    strRepeaterData += "<td>" + dblCost.ToString("0.00") + "</td>"
                                    strRepeaterData += "<td>" + objFunction.ReturnString(dtData.Rows(j)("supplier_note")) + "</td>"
                                    strRepeaterData += "</tr>"

                                Next

                                Trace.Warn("strRepeaterData = " + strRepeaterData)
                                Trace.Warn("dblTotalCost = " + objFunction.ReturnString(dblTotalCost))

                                'Dim strEmailContent As String = (New clsEmailContent()).PaymentsDueToAccommodationsEmail(objFunction.ReturnString(dtData.Rows(0)("SupplierName")), SetDateVal(DateTime.Now), objFunction.ReturnString(dtData.Rows(0)("SupplierContact")), strRepeaterData, dblTotalCost.ToString("0.00"), objFunction.ReturnString(dtData.Rows(0)("supplier_note")))
                                Dim strEmailContent As String = (New clsEmailContent()).PaymentsDueToAccommodationsEmail(objFunction.ReturnString(dtData.Rows(0)("SupplierName")), SetDateVal(DateTime.Now), objFunction.ReturnString(dtData.Rows(0)("SupplierContact")), strRepeaterData, dblTotalCost.ToString("0.00"), "")
                                Trace.Warn("strEmailContent = " + strEmailContent)

                                Dim objEmailContent As New Dictionary(Of String, String)()
                                objEmailContent.Add("SupplierId", objFunction.ReturnString(dtData.Rows(0)("supplier_id")))
                                objEmailContent.Add("Name", objFunction.ReturnString(dtData.Rows(0)("SupplierContact")))
                                objEmailContent.Add("Email", objFunction.ReturnString(dtData.Rows(0)("SupplierEmail")))
                                objEmailContent.Add("Subject", "Confirmation of payments – " + objFunction.ReturnString(dtData.Rows(0)("SupplierName")))
                                objEmailContent.Add("Body", strEmailContent)
                                lstEmailContent.Add(objEmailContent)

                            End If

                        End If
                    Next

                    Dim strEmailSuccess As String = ""
                    'Dim strSuccessEmail As String = ""
                    Dim strEmailError As String = ""
                    Dim strFailEmail As String = ""
                    If lstEmailContent.Count > 0 Then
                        For i = 0 To lstEmailContent.Count - 1
                            'Dim strName As String = lstEmailContent(i).Item("Name")
                            'Trace.Warn("List value = " + strName)

                            If objFunction.ReturnString(Request.QueryString("mode")) = "testemail" Then
                                Trace.Warn("Mail to BCC for testing")
                                Dim strMailStatus As String = clsEmail.SendEmailToBCC(lstEmailContent(i).Item("Name"), lstEmailContent(i).Item("Email"), "EasyWays bookings for next month", "Test Msg", lstEmailContent(i).Item("Body"), Me)
                                If strMailStatus = "Success" Then
                                    strEmailSuccess = "Send email to BCC email."
                                    
                                    If i <> (lstEmailContent.Count - 1) Then
                                        Trace.Warn("Thread start" + objFunction.ReturnString(DateTime.Now))
                                        System.Threading.Thread.Sleep(120000)
                                        Trace.Warn("Thread End" + objFunction.ReturnString(DateTime.Now))
                                    End If
                                Else
                                    strEmailError = strMailStatus
                                    strFailEmail += lstEmailContent(i).Item("Email") + "<br/>"
                                End If
                            Else
                                Trace.Warn("Mail to Suppiier")

                                Dim strMailStatus As String = clsEmail.SendEmail(lstEmailContent(i).Item("Name"), lstEmailContent(i).Item("Email"), "EasyWays bookings for next month", "Test Msg", lstEmailContent(i).Item("Body"), Me)
                                If strMailStatus = "Success" Then
                                    strEmailSuccess = "Send email to supplier."
                                    'strSuccessEmail += lstEmailContent(i).Item("Email") + ","
                                    objBEPaymentToSupplierEmailSent.SupplierId = lstEmailContent(i).Item("SupplierId")
                                    objBEPaymentToSupplierEmailSent.DateEntered = DateTime.Now
                                    objBEPaymentToSupplierEmailSent.MonthVal = intMonthVal
                                    objBEPaymentToSupplierEmailSent.YearVal = intYearVal
                                    objBEPaymentToSupplierEmailSent.SupplierType = 1
                                    Dim intAffectedRow As Integer = (New clsDLPaymentToSupplierEmailSent()).AddPaymentToSupplierEmailSent(objBEPaymentToSupplierEmailSent)

                                    If i <> (lstEmailContent.Count - 1) Then
                                        Trace.Warn("Thread start" + objFunction.ReturnString(DateTime.Now))
                                        System.Threading.Thread.Sleep(120000)
                                        Trace.Warn("Thread End" + objFunction.ReturnString(DateTime.Now))
                                    End If

                                Else
                                    strEmailError = strMailStatus
                                    strFailEmail += lstEmailContent(i).Item("Email") + "<br/>"
                                End If
                            End If

                        Next
                    End If

                    Dim javaScript As String = ""
                    Dim strAlertMsg As String = "<b>" + strEmailSuccess + "</b><br/>"
                    If strEmailError <> "" Then
                        strAlertMsg += "<b>" + strEmailError + "</b>. <br/><br/><b>Fail Email Id : </b> <br/>" + strFailEmail
                    End If

                    LABEL_Send_Email_Status.Text = strAlertMsg

                    'javaScript += "<script type='text/javascript'>"
                    'javaScript += "alert('" + strAlertMsg + "');"
                    'javaScript += "window.location='dashboard.aspx#seven';"
                    'javaScript += "</script>"
                    'ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)

                    'If strEmailError = "" Then
                    '    BUT_Email_All.Enabled = False
                    'End If

                    Session("BulkEmailStatus") = Nothing

                End If
            End If
            'Response.Redirect("dashboard.aspx#seven")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function return first date of the month by date
    ''' </summary>
    Public Function FirstDayOfMonthFromDateTime(ByVal dateTime As DateTime) As DateTime
        Return New DateTime(dateTime.Year, dateTime.Month, 1)
    End Function

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetDateVal(ByVal value As Object) As String
        Try
            If objFunction.ReturnString(value) <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(value)
                Return dt.ToString("dd-MM-yyyy")
            Else
                Return ""
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return ""
    End Function

End Class
