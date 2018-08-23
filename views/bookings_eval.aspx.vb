Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_eval
    Inherits System.Web.UI.Page

    Protected objFunction As New clsCommon()
    Protected dstAccomStageEvalBookingDetail As DataSet

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            If objFunction.ReturnString(Session("BookingId")) = "" And Session("BookingId") Is Nothing And objFunction.ReturnString(Session("AccomStageId")) = "" And Session("AccomStageId") Is Nothing Then
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

                Trace.Warn("BookingId = " + Session("BookingId"))
                Trace.Warn("AccomStageId = " + Session("AccomStageId"))

                GetBookingDetails()
                GetEvaluationDetail()

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
                If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("customised")) = True Then
                    CHK_Customised.Checked = True
                End If

                Dim intNoOfMale As Integer = objFunction.ReturnInteger(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("no_males")))
                Dim intNoOfFemale As Integer = objFunction.ReturnInteger(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("no_females")))
                Dim intNoOfOther As Integer = objFunction.ReturnInteger(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("no_other")))

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind booking details
    ''' </summary>
    Protected Sub GetEvaluationDetail()
        Try
            Dim dstBookingEvaluationDetail As DataSet = (New clsDLBookingEvaluation()).GetBookingEvaluationByBookingId(objFunction.ReturnInteger(Session("BookingId")))
            If objFunction.CheckDataSet(dstBookingEvaluationDetail) Then
                TB_Client_Referrer.Text = objFunction.ReturnString(dstBookingEvaluationDetail.Tables(0).Rows(0)("hear_about"))
                LABEL_Overall_EW_Rating.Text = GetRatingValue(objFunction.ReturnInteger(dstBookingEvaluationDetail.Tables(0).Rows(0)("overall")))
                LABEL_Ease_of_Booking.Text = GetRatingValue(objFunction.ReturnInteger(dstBookingEvaluationDetail.Tables(0).Rows(0)("ease")))
                LABEL_Rating_Quality_of_Info.Text = GetRatingValue(objFunction.ReturnInteger(dstBookingEvaluationDetail.Tables(0).Rows(0)("quality")))
                LABEL_Value_for_Money.Text = GetRatingValue(objFunction.ReturnInteger(dstBookingEvaluationDetail.Tables(0).Rows(0)("value")))
                TB_Feedback.Text = objFunction.ReturnString(dstBookingEvaluationDetail.Tables(0).Rows(0)("textx"))
            Else
                Response.Redirect("bookings_view.aspx")
            End If

            dstAccomStageEvalBookingDetail = (New clsDLAccomStageEvalBooking()).GetAccomStageEvalBookingByBookingId(objFunction.ReturnInteger(Session("BookingId")))
            
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to get reating value
    ''' </summary>
    Protected Function GetRatingValue(ByVal intRating As Integer) As String

        Try
            Dim strRatingVal As String = ""

            If intRating = 1 Then
                strRatingVal = "Excellent"
            ElseIf intRating = 2 Then
                strRatingVal = "VeryGood"
            ElseIf intRating = 3 Then
                strRatingVal = "Average"
            ElseIf intRating = 4 Then
                strRatingVal = "Fair"
            ElseIf intRating = 5 Then
                strRatingVal = "Poor"
            End If

            Return strRatingVal
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This event is used to go back to booking view screen
    ''' </summary>
    Protected Sub BUT_Back_to_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Back_to_Booking.Click
        Response.Redirect("bookings_view.aspx")
    End Sub
End Class