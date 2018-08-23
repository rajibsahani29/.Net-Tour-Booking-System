Imports System.Data
Imports Easyway.BE
Imports Easyway.DL
Imports System.Drawing

Partial Class bookings_status
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    
    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
response.redirect("bookings_status2.aspx")
        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            If objFunction.ReturnString(Session("BookingId")) = "" And Session("BookingId") Is Nothing Then
                Response.Redirect("bookings_search.aspx")
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

                GetBookingDetails()
                ManageBookingStatus()

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind booking details
    ''' </summary>
    Protected Sub GetBookingDetails()

        Try
            'Trace.Warn("BookingId = " + Session("BookingId").ToString())
            Dim intBookingId = objFunction.ReturnInteger(Session("BookingId"))
            Dim intAccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstBookingDetail As New DataSet()
            Dim objBEBooking As clsBEBooking = New clsBEBooking
            objBEBooking.BookingId = intBookingId
            objBEBooking.CompanyId = intCompanyId
            dstBookingDetail = (New clsDLBooking()).GetBookingDetailById(objBEBooking, 0)

            If dstBookingDetail IsNot Nothing Then

                LABEL_Booking_ID.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("unique_id"))
                LABEL_Tour_and_Stage.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("RouteName"))
                LABEL_Client_Name.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ClientName"))
                LABEL_Stage.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("StageName"))
                LABEL_Total_Number_in_Party.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("total_num"))
                Dim dblTotalAmountPayable As Double = (New clsPaymentCalculation()).GetTotalAmountPayable(intBookingId)
                LABEL_Total_Payable.Text = "£" + dblTotalAmountPayable.ToString("0.00")
                Dim dblTotalBalanceRemaining As Double = (New clsPaymentCalculation()).GetTotalBalanceRemaining(dblTotalAmountPayable, intBookingId)
                LABEL_Balance_Remaining.Text = "£" + dblTotalBalanceRemaining.ToString("0.00")
                ViewState.Add("TotalBalanceRemaining", dblTotalBalanceRemaining)
                If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("customised")) = True Then
                    CHK_Customised.Checked = True
                End If

                If Convert.IsDBNull(dstBookingDetail.Tables(0).Rows(0)("cancelled")) = False Then
                    If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("cancelled")) = True Then
                        LABEL_Total_Payable.Text = "£" + objFunction.ReturnDouble(dstBookingDetail.Tables(0).Rows(0)("cancellation_amount")).ToString("0.00")
                        Dim dblPaymentMade As Double = dblTotalAmountPayable - dblTotalBalanceRemaining
                        LABEL_Balance_Remaining.Text = "£" + objFunction.ReturnDouble(dstBookingDetail.Tables(0).Rows(0)("cancellation_amount") - dblPaymentMade).ToString("0.00")
                        LABEL_Balance_Remaining.Text = objFunction.ReturnDouble(dstBookingDetail.Tables(0).Rows(0)("cancellation_amount") - dblPaymentMade).ToString("0.00")
                    End If
                End If

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind booking details
    ''' </summary>
    Protected Sub ManageBookingStatus()

        Try
            Dim intBookingId = objFunction.ReturnInteger(Session("BookingId"))
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.BookingId = intBookingId
            Dim dstAccomRouteStage As DataSet = (New clsDLAccomRouteStage()).GetAccomRouteStageByBookingId(objBEAccomRouteStage, intCompanyId)
            If objFunction.CheckDataSet(dstAccomRouteStage) Then
                Dim dtData As DataTable = dstAccomRouteStage.Tables(0)
                dtData.DefaultView.RowFilter = "(accomodation_id = 0 OR accomodation_id IS NULL)"
                Dim dtDataTemp As DataTable = dtData.DefaultView.ToTable()
                If Not objFunction.CheckDataTable(dtDataTemp) Then
                    CHK_Accom_Booked.Checked = True
                End If
            End If

            Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
            objBEExtrasBaggageBooking.BookingId = intBookingId
            Dim dstExtrasBaggageBooking As DataSet = (New clsDLExtrasBaggageBooking()).GetExtrasBaggageBookingByBookingId(objBEExtrasBaggageBooking)
            If objFunction.CheckDataSet(dstExtrasBaggageBooking) Then
                CHK_Baggage_Booked.Checked = True
            End If

            Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
            objBEExtrasBooking.BookingId = intBookingId
            Dim dstExtrasBooking As DataSet = (New clsDLExtrasBooking()).GetExtrasBookingByBookingId(objBEExtrasBooking)
            If objFunction.CheckDataSet(dstExtrasBooking) Then
                CHK_Extras_Booked.Checked = True
            End If

            If objFunction.CheckDataSet(dstAccomRouteStage) Then
                Dim dtData As DataTable = dstAccomRouteStage.Tables(0)
                dtData.DefaultView.RowFilter = "flag_confirmation = 1"
                Dim dtDataTemp As DataTable = dtData.DefaultView.ToTable()
                If objFunction.CheckDataTable(dtDataTemp) Then
                    CHK_Accom_Email_Sent.Checked = True
                End If
            End If

            Dim dstClientBooking As DataSet = (New clsDLClientBooking()).GetClientBookingByBookingId(intBookingId)
            If objFunction.CheckDataSet(dstClientBooking) Then
                If Convert.IsDBNull(dstClientBooking.Tables(0).Rows(0)("agent_id")) = False Then
                    If objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(0)("agent_id")) = 0 Then
                        DIV_Agent.Attributes.Add("style", "display:none;")
                    Else
                        If Convert.ToBoolean(dstClientBooking.Tables(0).Rows(0)("flag_confirmation_agent")) = True Then
                            CHK_Agent_Email_Conf_Sent.Checked = True
                        End If
                    End If
                Else
                    DIV_Agent.Attributes.Add("style", "display:none;")
                End If

                If Convert.IsDBNull(dstClientBooking.Tables(0).Rows(0)("flag_invoice")) = False Then
                    If Convert.ToBoolean(dstClientBooking.Tables(0).Rows(0)("flag_invoice")) = True Then
                        CHK_Invoice_Sent.Checked = True
                    End If
                End If

                If Convert.IsDBNull(dstClientBooking.Tables(0).Rows(0)("flag_deposit_received")) = False Then
                    If Convert.ToBoolean(dstClientBooking.Tables(0).Rows(0)("flag_deposit_received")) = True Then
                        CHK_Deposit_Received.Checked = True
                    End If
                End If
                
                If Convert.IsDBNull(dstClientBooking.Tables(0).Rows(0)("flag_tourpack")) = False Then
                    If Convert.ToBoolean(dstClientBooking.Tables(0).Rows(0)("flag_tourpack")) = True Then
                        CHK_URL_Sent.Checked = True
                    End If
                End If
                
            End If

            Dim dstBookingEvaluation As DataSet = (New clsDLBookingEvaluation()).GetBookingEvaluationByBookingId(intBookingId)
            If objFunction.CheckDataSet(dstBookingEvaluation) Then
                CHK_Eval_Rec.Checked = True
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to go back to booking view screen
    ''' </summary>
    Protected Sub BUT_Back_to_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Back_to_Booking.Click
        Response.Redirect("bookings_view.aspx")
    End Sub

End Class