Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_payments
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEBookingPayments As clsBEBookingPayments = New clsBEBookingPayments
    Dim objDLBookingPayments As clsDLBookingPayments = New clsDLBookingPayments

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
                LABEL_Balance_RemainingTop.Text = "£" + dblTotalBalanceRemaining.ToString("0.00")
                LABEL_Balance_Remaining.Text = dblTotalBalanceRemaining.ToString("0.00")
                ViewState.Add("TotalBalanceRemaining", dblTotalBalanceRemaining)
                If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("customised")) = True Then
                    CHK_Customised.Checked = True
                End If

                If Convert.IsDBNull(dstBookingDetail.Tables(0).Rows(0)("cancelled")) = False Then
                    If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("cancelled")) = True Then
                        LABEL_Total_Payable.Text = "£" + objFunction.ReturnDouble(dstBookingDetail.Tables(0).Rows(0)("cancellation_amount")).ToString("0.00")
                        Dim dblPaymentMade As Double = dblTotalAmountPayable - dblTotalBalanceRemaining
                        LABEL_Balance_RemainingTop.Text = "£" + objFunction.ReturnDouble(dstBookingDetail.Tables(0).Rows(0)("cancellation_amount") - dblPaymentMade).ToString("0.00")
                        LABEL_Balance_Remaining.Text = objFunction.ReturnDouble(dstBookingDetail.Tables(0).Rows(0)("cancellation_amount") - dblPaymentMade).ToString("0.00")
                    End If
                End If

                FillAccommodationName(intCompanyId)
                BindGridview()

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to fill accomdation name dropdown
    ''' </summary>
    Protected Sub FillAccommodationName(ByVal intCompanyId As Integer)
        Try
            Dim dstPaymentMethod As DataSet = (New clsDLPaymentMethod()).GetPaymentMethodFillInDD(intCompanyId)
            objFunction.FillDropDownByDataSet(DROP_Payment_Method, dstPaymentMethod)
            DROP_Payment_Method.Items.Insert(0, New ListItem("Select Payment Method", "0"))
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
            objBEBookingPayments.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            Dim dstBookingPayments As New DataSet()
            dstBookingPayments = (New clsDLBookingPayments()).GetBookingPaymentsByBookingId(objBEBookingPayments)
            GRID_Bookings_Payments_Made.DataSource = dstBookingPayments
            GRID_Bookings_Payments_Made.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GRID_Bookings_Payments_Made
    ''' </summary>
    Protected Sub GRID_Bookings_Payments_Made_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lb As LinkButton = DirectCast(e.Row.Cells(8).Controls(0), LinkButton)
                If lb IsNot Nothing Then
                    If lb.Text = "Delete" Then
                        lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
                    End If
                End If
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Bookings_Payments_Made
    ''' </summary>
    Protected Sub GRID_Bookings_Payments_Made_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Bookings_Payments_Made.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GRID_Bookings_Payments_Made
    ''' </summary>
    Protected Sub GRID_Bookings_Payments_Made_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            objBEBookingPayments.BookingPaymentsId = objFunction.ReturnInteger(GRID_Bookings_Payments_Made.DataKeys(e.RowIndex).Values("id").ToString())
            Dim intAffectedRow As Integer = objDLBookingPayments.DeleteBookingPaymentsById(objBEBookingPayments)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Booking payments has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_Bookings_Payments_Made.EditIndex = -1
            'BindGridview()
            Response.Redirect("bookings_payments.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of dropdown
    ''' </summary>
    Protected Sub DROP_Payment_Method_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Payment_Method.SelectedIndexChanged

        Try
            Dim objBEPaymentMethod As clsBEPaymentMethod = New clsBEPaymentMethod
            objBEPaymentMethod.PaymentMethodId = objFunction.ReturnInteger(DROP_Payment_Method.SelectedItem.Value)
            objBEPaymentMethod.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstPaymentMethod As DataSet = (New clsDLPaymentMethod()).GetPaymentMethodById(objBEPaymentMethod)
            If objFunction.CheckDataSet(dstPaymentMethod) Then

                Dim dblCommision As Double = objFunction.ReturnDouble(dstPaymentMethod.Tables(0).Rows(0)("commision"))

                Dim dblPaymentCharge As Double = (objFunction.ReturnDouble(ViewState("TotalBalanceRemaining")) * dblCommision) / 100
                LABEL_Payment_Charge.Text = dblPaymentCharge.ToString("0.00")

                Dim dblAmountToCharge As Double = objFunction.ReturnDouble(TB_Amount_to_Pay.Text) + dblPaymentCharge
                LABEL_Amount_to_Charge.Text = dblAmountToCharge.ToString("0.00")
         
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

    ''' <summary>
    ''' This event is used to add booking payment
    ''' </summary>
    Protected Sub BUT_Add_Payment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Payment.Click

        Try
            If IsNumeric(TB_Amount_to_Pay.Text) And objFunction.ReturnInteger(DROP_Payment_Method.SelectedItem.Value) Then
                objBEBookingPayments.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEBookingPayments.AmountWishToPay = objFunction.ReturnDouble(TB_Amount_to_Pay.Text)
                'objBEBookingPayments.AmountPaid = objFunction.ReturnDouble(TB_Amount_to_Pay.Text) + objFunction.ReturnDouble(LABEL_Payment_Charge.Text)
                objBEBookingPayments.AmountPaid = objFunction.ReturnDouble(TB_Amount_to_Pay.Text)
                objBEBookingPayments.PaymentMethodsId = objFunction.ReturnInteger(DROP_Payment_Method.SelectedItem.Value)
                objBEBookingPayments.BalanceBeforePayment = objFunction.ReturnDouble(ViewState("TotalBalanceRemaining"))
                objBEBookingPayments.CCCharge = objFunction.ReturnDouble(LABEL_Payment_Charge.Text)
                objBEBookingPayments.FirstData = TB_First_Data_Ref.Text
                objBEBookingPayments.DateReceived = Convert.ToDateTime(TB_Date_Payment_Received.Text)
                
                Dim intAffectedRow As Integer = objDLBookingPayments.AddBookingPayments(objBEBookingPayments)
                If intAffectedRow > 0 Then

                    Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                    If objFunction.ReturnDouble(TB_Amount_to_Pay.Text) < objFunction.ReturnDouble(LABEL_Balance_Remaining.Text) Then
                        Trace.Warn("bookingStage_id = 5")
                        objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEClientBooking.BookingStageId = 5
                        Dim intAffectedRow1 As Integer = (New clsDLClientBooking()).UpdateBookingStageIdByBookingId(objBEClientBooking)
                    ElseIf objFunction.ReturnDouble(TB_Amount_to_Pay.Text) = objFunction.ReturnDouble(LABEL_Balance_Remaining.Text) Then
                        Trace.Warn("bookingStage_id = 6")
                        objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEClientBooking.BookingStageId = 6
                        Dim intAffectedRow1 As Integer = (New clsDLClientBooking()).UpdateBookingStageIdByBookingId(objBEClientBooking)
                    End If

                    Session("feedback_call") = "1"
                    Session("error_msg") = "Booking payment has been added"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the costing entries"
            End If
            Response.Redirect("bookings_payments.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

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





