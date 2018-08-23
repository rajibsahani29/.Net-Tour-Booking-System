Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class correspondance_system
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objEmailContent As New clsEmailContent()
    Dim objBEBookingCorrespondence As clsBEBookingCorrespondence = New clsBEBookingCorrespondence
    Dim objDLBookingCorrespondence As clsDLBookingCorrespondence = New clsDLBookingCorrespondence

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            'Session("SupplierId") = "22"
            'Session("SupplierType") = "1"

            If objFunction.ReturnString(Session("SupplierId")) = "" And Session("SupplierId") Is Nothing Then
                Response.Redirect("dashboard.aspx")
            End If

            Trace.Warn("SupplierId = " + objFunction.ReturnString(Session("SupplierId")))
            Trace.Warn("SupplierType = " + objFunction.ReturnString(Session("SupplierType")))

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

                GetSupplierDetails()

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to get supplier details
    ''' </summary>
    Protected Sub GetSupplierDetails()

        Try
            Dim strEmailContent As String = ""
            If objFunction.ReturnInteger(Session("SupplierType")) = 0 Then
                '0 = agent therefore we look in [agents] table
                'Dim dstData As DataSet = (New clsDLAgent()).GetAgentDetailById(objFunction.ReturnInteger(Session("SupplierId")))
                Dim dstData As DataSet = (New clsDLAgent()).GetContactDetailByAgentId(objFunction.ReturnInteger(Session("SupplierId")), 2)
                Dim strContactName2 As String = ""
                If objFunction.CheckDataSet(dstData) Then
                    TB_Supplier_Agent.Text = objFunction.ReturnString(dstData.Tables(0).Rows(0)("AgentName"))
                    strContactName2 = objFunction.ReturnString(dstData.Tables(0).Rows(0)("contactname"))
                    Session("SendEmailId") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("emailx"))
                    Trace.Warn("GetSupplierDetails() SendEmailId = " + objFunction.ReturnString(Session("SendEmailId")))
                End If
                Dim dstEmailData As DataSet = (New clsEmailContentData()).AgentInvoicedBookings_Email(objFunction.ReturnInteger(Session("SupplierId")))
                If objFunction.CheckDataSet(dstEmailData) Then
                    strEmailContent = objEmailContent.AgentInvoicedBookings_Email(objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("AgentName")), SetDateVal(DateTime.Now), strContactName2, Convert.ToBoolean(dstEmailData.Tables(0).Rows(0)("customised")), (objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("staffname2"))), objFunction.ReturnInteger(Session("SupplierId")))
                Else
                    strEmailContent = objEmailContent.AgentInvoicedBookings_Email("", "", "", False, "", 0)
                End If
            ElseIf objFunction.ReturnInteger(Session("SupplierType")) = 1 Then
                '1 = baggage therefore we look in [extras] table AND [extras_baggage_booking]
                TB_Email_Subject.Text = "EasyWays bookings for Next Month"
                Dim dstData As DataSet = (New clsDLExtra()).GetExtraDetailById(objFunction.ReturnInteger(Session("SupplierId")))
                If objFunction.CheckDataSet(dstData) Then
                    TB_Supplier_Agent.Text = objFunction.ReturnString(dstData.Tables(0).Rows(0)("name"))
                    Session("SendEmailId") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("email"))
                End If
                Dim dstEmailData As DataSet = (New clsEmailContentData()).EmailExtra_IndividualBookingEGTaxi_Bulk()
                If objFunction.CheckDataSet(dstEmailData) Then
                    strEmailContent = objEmailContent.EmailBaggageCompany_IndividualBooking_Bulk("", SetDateVal(DateTime.Now), "", (objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("staffname2"))), objFunction.ReturnInteger(Session("SupplierId")))
                Else
                    strEmailContent = objEmailContent.EmailBaggageCompany_IndividualBooking_Bulk("", "", "", "", 0)
                End If
            ElseIf objFunction.ReturnInteger(Session("SupplierType")) = 2 Then
                '2 = extras therefore we look in [extras] table AND [extras_booking]
                Dim dstData As DataSet = (New clsDLExtra()).GetExtraDetailById(objFunction.ReturnInteger(Session("SupplierId")))
                If objFunction.CheckDataSet(dstData) Then
                    TB_Supplier_Agent.Text = objFunction.ReturnString(dstData.Tables(0).Rows(0)("name"))
                    Session("SendEmailId") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("email"))
                End If
                Dim dstEmailData As DataSet = (New clsEmailContentData()).EmailExtra_IndividualBookingEGTaxi_Bulk()
                If objFunction.CheckDataSet(dstEmailData) Then
                    strEmailContent = objEmailContent.EmailExtra_IndividualBookingEGTaxi_Bulk("", SetDateVal(DateTime.Now), "", (objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("staffname2"))), objFunction.ReturnInteger(Session("SupplierId")))
                Else
                    strEmailContent = objEmailContent.EmailExtra_IndividualBookingEGTaxi_Bulk("", "", "", "", 0)
                End If
            End If
            TB_Email_Address.Text = objFunction.ReturnString(Session("SendEmailId"))
            TB_Editor.Text = ""
            TB_Editor.Text = strEmailContent

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add supplier correspondence detail and send mail to supplier
    ''' </summary>
    Protected Sub BUT_Send_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Send.Click
        Try
            If TB_Email_Subject.Text <> "" And objFunction.ReturnString(Session("SendEmailId")) <> "" Then
                'objBEBookingCorrespondence.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                'objBEBookingCorrespondence.Direction = Convert.ToBoolean(1)
                'objBEBookingCorrespondence.Subject = TB_Email_Subject.Text
                'objBEBookingCorrespondence.Notes = TB_Editor.Text
                'objBEBookingCorrespondence.Datex = DateTime.Now
                'objBEBookingCorrespondence.CorrespondenceTypeId = 1
                'objBEBookingCorrespondence.Typex = 1

                'If objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value) > 0 Then
                '    objBEBookingCorrespondence.AccomId = hdnAccomId.Value
                'End If

                'If objFunction.ReturnInteger(DROP_Extras_Supplier.SelectedItem.Value) > 0 Then
                '    objBEBookingCorrespondence.ExtraId = objFunction.ReturnInteger(DROP_Extras_Supplier.SelectedItem.Value)
                'End If

                'Dim intAffectedRow As Integer = objDLBookingCorrespondence.AddBookingCorrespondence(objBEBookingCorrespondence)
                'If intAffectedRow > 0 Then
                Trace.Warn("SendEmailId = " + objFunction.ReturnString(Session("SendEmailId")))
                Dim strMailStatus As String = clsEmail.SendEmail(TB_Supplier_Agent.Text, objFunction.ReturnString(Session("SendEmailId")), TB_Email_Subject.Text, "Test Msg", TB_Editor.Text, Me)
                Trace.Warn("strMailStatus = " + strMailStatus)
                If strMailStatus = "Success" Then

                    If objFunction.ReturnInteger(Session("SupplierType")) = 0 Then
                        Dim objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings = New clsBEAgentInvoicedBookings
                        objBEAgentInvoicedBookings.AgentId = objFunction.ReturnInteger(Session("SupplierId"))
                        objBEAgentInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                        objBEAgentInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                        Dim dstData As DataSet = (New clsDLAgentInvoicedBookings()).GetAgentDetailByMonthYearAndAgentId(objBEAgentInvoicedBookings)
                        If objFunction.CheckDataSet(dstData) Then
                            For i = 0 To dstData.Tables(0).Rows.Count - 1
                                'Add Booking_Status_Bookings
                                Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                                Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                                objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("booking_id"))
                                objBEBookingStatusBookings.BSCId = 16
                                Trace.Warn("objBEBookingStatusBookings.BookingId = " + objFunction.ReturnString(objBEBookingStatusBookings.BookingId))
                                objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                            Next
                        End If

                        If objFunction.ReturnInteger(Session("SupplierId")) > 0 Then
                            'Dim objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings = New clsBEAgentInvoicedBookings
                            objBEAgentInvoicedBookings.AgentId = objFunction.ReturnInteger(Session("SupplierId"))
                            objBEAgentInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                            objBEAgentInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                            objBEAgentInvoicedBookings.DateSent = DateTime.Now
                            Dim intAff As Integer = (New clsDLAgentInvoicedBookings()).UpdateDateSentByAgentId(objBEAgentInvoicedBookings)
                        End If
                    End If

                    If objFunction.ReturnInteger(Session("SupplierType")) = 1 Then
                        Dim intMonth As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                        Dim intYear As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                        Dim dstData As DataSet = (New clsEmailContentData()).EmailBaggageCompany_IndividualBooking_Bulk_Repeater(objFunction.ReturnInteger(Session("SupplierId")), intMonth, intYear)
                        If objFunction.CheckDataSet(dstData) Then
                            For i = 0 To dstData.Tables(0).Rows.Count - 1
                                'Add Booking_Status_Bookings
                                Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                                Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                                objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("id"))
                                objBEBookingStatusBookings.BSCId = 17
                                objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                            Next
                        End If

                        If objFunction.ReturnInteger(Session("SupplierId")) > 0 Then
                            Dim objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings = New clsBEExtrasInvoicedBookings
                            objBEExtrasInvoicedBookings.ExtraId = objFunction.ReturnInteger(Session("SupplierId"))
                            objBEExtrasInvoicedBookings.MonthVal = intMonth
                            objBEExtrasInvoicedBookings.YearVal = intYear
                            objBEExtrasInvoicedBookings.DateSent = DateTime.Now
                            Dim intAff As Integer = (New clsDLExtrasInvoicedBookings()).UpdateDateSentByExtraId(objBEExtrasInvoicedBookings)
                        End If
                    End If

                    If objFunction.ReturnInteger(Session("SupplierType")) = 2 Then
                        Dim intMonth As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                        Dim intYear As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                        Dim dstData As DataSet = (New clsEmailContentData()).EmailExtra_IndividualBookingEGTaxi_Bulk_Repeater(objFunction.ReturnInteger(Session("SupplierId")), intMonth, intYear)
                        If objFunction.CheckDataSet(dstData) Then
                            For i = 0 To dstData.Tables(0).Rows.Count - 1
                                'Add Booking_Status_Bookings
                                Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                                Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                                objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("id"))
                                objBEBookingStatusBookings.BSCId = 18
                                objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                            Next
                        End If

                        If objFunction.ReturnInteger(Session("SupplierId")) > 0 Then
                            Dim objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings = New clsBEExtrasInvoicedBookings
                            objBEExtrasInvoicedBookings.ExtraId = objFunction.ReturnInteger(Session("SupplierId"))
                            objBEExtrasInvoicedBookings.MonthVal = intMonth
                            objBEExtrasInvoicedBookings.YearVal = intYear
                            objBEExtrasInvoicedBookings.DateSent = DateTime.Now
                            Dim intAff As Integer = (New clsDLExtrasInvoicedBookings()).UpdateDateSentByExtraId(objBEExtrasInvoicedBookings)
                        End If

                    End If

                    Session("feedback_call") = "1"
                    Session("error_msg") = "Send correspondance to supplier"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = strMailStatus
                End If
                'Else
                '    Session("feedback_call") = "2"
                '    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                'End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the entries"
            End If
            Session("SendEmailId") = Nothing
            Response.Redirect("correspondance_system.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetDateVal(ByVal value As Object) As String
        If objFunction.ReturnString(value) <> "" Then
            Dim dt As DateTime = Convert.ToDateTime(value)
            Return dt.ToString("dd-MM-yyyy")
        Else
            Return ""
        End If
    End Function

    Public Function FirstDayOfMonthFromDateTime(ByVal dateTime As DateTime) As DateTime
        Return New DateTime(dateTime.Year, dateTime.Month, 1)
    End Function

End Class





