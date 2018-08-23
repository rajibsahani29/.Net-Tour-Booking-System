Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class views_test_email
    Inherits System.Web.UI.Page

    Protected objFunction As New clsCommon()
    Protected objPaymentCalculation As clsPaymentCalculation = New clsPaymentCalculation

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            If Not Page.IsPostBack Then

                Trace.Warn("Session = " + Session("feedback_call"))
                If Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 1 Then
                    Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
                ElseIf Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 2 Then
                    Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
                End If
                Session("feedback_call") = "0"
                Session("error_msg") = ""
                Trace.Warn("End Session = " + Session("feedback_call"))

                BindGridview()

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindGridview()

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
                Trace.Warn("Count = " + objFunction.ReturnString(dstData.Tables(0).Rows.Count))
                Dim dtDistinctData As DataTable = dstData.Tables(0).DefaultView.ToTable(True, "supplier_id", "SupplierName", "SupplierEmail")
                Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))
                GRID_Test_Email.DataSource = dtDistinctData
                GRID_Test_Email.DataBind()
            Else
                GRID_Test_Email.DataSource = New List(Of String())
                GRID_Test_Email.DataBind()
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Test_Email
    ''' </summary>
    Protected Sub GRID_Test_Email_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Test_Email.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Test_Email
    ''' </summary>
    Protected Sub GRID_Test_Email_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Test_Email.DataKeys(e.NewSelectedIndex).Value))
            Dim intSupplierId As Integer = objFunction.ReturnInteger(GRID_Test_Email.DataKeys(e.NewSelectedIndex).Values("supplier_id"))
            Dim strSupplierEmail As String = objFunction.ReturnString(GRID_Test_Email.DataKeys(e.NewSelectedIndex).Values("SupplierEmail"))
            Trace.Warn("strSupplierId = " + objFunction.ReturnString(intSupplierId))
            Trace.Warn("strSupplierEmail = " + strSupplierEmail)

            SendEmail(intSupplierId)

            'Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to send email
    ''' </summary>
    Protected Sub SendEmail(ByVal intSupplierId As Integer)
        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            Dim objDLPaymentToSupplier As clsDLPaymentToSupplier = New clsDLPaymentToSupplier

            Dim intMonthVal As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            Dim intYearVal As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            'Dim intMonthVal As Integer = 8
            'Dim intYearVal As Integer = 2017

            objBEPaymentToSupplier.SupplierId = intSupplierId
            objBEPaymentToSupplier.MonthVal = intMonthVal
            objBEPaymentToSupplier.YearVal = intYearVal
            objBEPaymentToSupplier.SupplierType = 1

            Dim dstData As DataSet = objDLPaymentToSupplier.GetSupplierDetailByMonthYearSupplierTypeAndSupplierId(objBEPaymentToSupplier, intCompanyId)

            If objFunction.CheckDataSet(dstData) Then

                Dim strRepeaterData As String = ""
                Dim dblTotalCost As Double = 0

                Dim dtData As DataTable = dstData.Tables(0)
                For i = 0 To dtData.Rows.Count - 1
                    Dim lngNoOfNight As Long = 0
                    If objFunction.ReturnString(dtData.Rows(i)("checkin")) <> "" And objFunction.ReturnString(dtData.Rows(i)("checkout")) <> "" Then
                        lngNoOfNight = DateDiff(DateInterval.Day, Convert.ToDateTime(dtData.Rows(i)("checkin")), Convert.ToDateTime(dtData.Rows(i)("checkout")))
                    End If
                    Trace.Warn("lngNoOfNight = " + objFunction.ReturnString(lngNoOfNight))

                    Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
                    objBEAccomStageRoom.AccomStageId = objFunction.ReturnInteger(dtData.Rows(i)("accom_stage_id"))
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
                    strRepeaterData += "<td>" + SetDateVal(objFunction.ReturnString(dtData.Rows(i)("checkin"))) + "</td>"
                    strRepeaterData += "<td>" + objFunction.ReturnString(dtData.Rows(i)("ClientName")) + "</td>"
                    strRepeaterData += "<td>" + objFunction.ReturnString(dtData.Rows(i)("AgentName")) + "</td>"
                    strRepeaterData += "<td>" + objFunction.ReturnString(dtData.Rows(i)("total_num")) + "</td>"
                    strRepeaterData += "<td>" + strAccomRoomType.TrimEnd(",") + "</td>"
                    strRepeaterData += "<td>" + dblCost.ToString("0.00") + "</td>"
                    strRepeaterData += "<td>" + objFunction.ReturnString(dtData.Rows(i)("supplier_note")) + "</td>"
                    strRepeaterData += "</tr>"
                Next

                Trace.Warn("strRepeaterData = " + strRepeaterData)
                Trace.Warn("dblTotalCost = " + objFunction.ReturnString(dblTotalCost))

                'Dim strEmailContent As String = (New clsEmailContent()).PaymentsDueToAccommodationsEmail(objFunction.ReturnString(dtData.Rows(0)("SupplierName")), SetDateVal(DateTime.Now), objFunction.ReturnString(dtData.Rows(0)("SupplierContact")), strRepeaterData, dblTotalCost.ToString("0.00"), objFunction.ReturnString(dtData.Rows(0)("supplier_note")))
                Dim strEmailContent As String = (New clsEmailContent()).PaymentsDueToAccommodationsEmail(objFunction.ReturnString(dtData.Rows(0)("SupplierName")), SetDateVal(DateTime.Now), objFunction.ReturnString(dtData.Rows(0)("SupplierContact")), strRepeaterData, dblTotalCost.ToString("0.00"), "")
                Trace.Warn("strEmailContent = " + strEmailContent)

                Dim strMailStatus As String = clsEmail.SendEmailToBCC(objFunction.ReturnString(dtData.Rows(0)("SupplierContact")), objFunction.ReturnString(dtData.Rows(0)("SupplierEmail")), "EasyWays bookings for next month - " + objFunction.ReturnString(dtData.Rows(0)("SupplierName")), "Test Msg", strEmailContent, Me)
                Dim strEmailStatus As String = ""
                If strMailStatus = "Success" Then
                    strEmailStatus = "Send email to BCC email."
                Else
                    strEmailStatus = strMailStatus
                End If

                Dim javaScriptMsg As String = ""
                javaScriptMsg += "<script type='text/javascript'>"
                javaScriptMsg += "alert('" + strEmailStatus + "');"
                javaScriptMsg += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScriptMsg)

            End If

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
