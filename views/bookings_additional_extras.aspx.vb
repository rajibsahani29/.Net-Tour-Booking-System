Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_additional_extras
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEAdditionalExtras As clsBEAdditionalExtras = New clsBEAdditionalExtras
    Dim objDLAdditionalExtras As clsDLAdditionalExtras = New clsDLAdditionalExtras

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
                BindGridview()

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
                If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("customised")) = True Then
                    CHK_Customised.Checked = True
                End If

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
            Dim dstAdditionalExtras As New DataSet()
            objBEAdditionalExtras.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            dstAdditionalExtras = (New clsDLAdditionalExtras()).GetAdditionalExtrasByBookingId(objBEAdditionalExtras)
            GRID_Bookings_Additional_Extras.DataSource = dstAdditionalExtras
            GRID_Bookings_Additional_Extras.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GRID_Bookings_Additional_Extras
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_Extras_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lb As LinkButton = DirectCast(e.Row.Cells(4).Controls(2), LinkButton)
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
    ''' RowEditing event of the GRID_Bookings_Additional_Extras
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_Extras_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

        Try
            GRID_Bookings_Additional_Extras.EditIndex = e.NewEditIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowCancelingEdit event of the GRID_Bookings_Additional_Extras
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_Extras_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)

        Try
            GRID_Bookings_Additional_Extras.EditIndex = -1
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Bookings_Additional_Extras
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_Extras_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Bookings_Additional_Extras.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowUpdating event of the GRID_Bookings_Additional_Extras
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_Extras_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GRID_Bookings_Additional_Extras.DataKeys(e.RowIndex).Values("id")))
            Dim txtDescription As TextBox = DirectCast(GRID_Bookings_Additional_Extras.Rows(e.RowIndex).FindControl("TB_Description"), TextBox)
            Dim txtCostEw As TextBox = DirectCast(GRID_Bookings_Additional_Extras.Rows(e.RowIndex).FindControl("TB_CostEw"), TextBox)
            Dim txtCostClient As TextBox = DirectCast(GRID_Bookings_Additional_Extras.Rows(e.RowIndex).FindControl("TB_CostClient"), TextBox)
            
            If txtDescription.Text <> "" And IsNumeric(txtCostEw.Text) And IsNumeric(txtCostClient.Text) Then
                objBEAdditionalExtras.AdditionalExtrasId = id
                objBEAdditionalExtras.Description = txtDescription.Text
                objBEAdditionalExtras.CostEasyway = objFunction.ReturnDouble(txtCostEw.Text)
                objBEAdditionalExtras.CostClient = objFunction.ReturnDouble(txtCostClient.Text)

                Dim intAffectedRow As Integer = objDLAdditionalExtras.PerformGridViewOpertaion("UPDATE", objBEAdditionalExtras)
                If intAffectedRow > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Booking additional extra detail has been amended"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the costing entries"
            End If
            GRID_Bookings_Additional_Extras.EditIndex = -1
            'BindGridview()
            Response.Redirect("bookings_additional_extras.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GRID_Bookings_Additional_Extras
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_Extras_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            objBEAdditionalExtras.AdditionalExtrasId = objFunction.ReturnInteger(GRID_Bookings_Additional_Extras.DataKeys(e.RowIndex).Values("id").ToString())
            Dim intAffectedRow As Integer = objDLAdditionalExtras.PerformGridViewOpertaion("DELETE", objBEAdditionalExtras)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Booking additional extra detail has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_Bookings_Additional_Extras.EditIndex = -1
            'BindGridview()
            Response.Redirect("bookings_additional_extras.aspx", False)
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
    Protected Sub BUT_Add_Extra_to_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Extra_to_Booking.Click
        Try
            If TB_Extras_Description.Text <> "" And IsNumeric(TB_EW_Cost.Text) And IsNumeric(TB_Client_Cost.Text) Then

                objBEAdditionalExtras.Description = TB_Extras_Description.Text
                objBEAdditionalExtras.CostEasyway = objFunction.ReturnDouble(TB_EW_Cost.Text)
                objBEAdditionalExtras.CostClient = objFunction.ReturnDouble(TB_Client_Cost.Text)
                objBEAdditionalExtras.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                If CHK_Show_in_Invoice.Checked = True Then
                    objBEAdditionalExtras.Invoicex = False
                Else
                    objBEAdditionalExtras.Invoicex = True
                End If
                
                Dim intAffectedRow As Integer = objDLAdditionalExtras.AddAdditionalExtras(objBEAdditionalExtras)
                If intAffectedRow > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Booking additional extra detail has been added"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the costing entries"
            End If
            Response.Redirect("bookings_additional_extras.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetValue(ByVal value As Object) As String
        If Convert.ToBoolean(value) = True Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

End Class





