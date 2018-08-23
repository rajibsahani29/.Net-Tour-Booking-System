Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_status2
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

            Dim dstClientBooking As DataSet = (New clsDLClientBooking()).GetClientBookingByBookingId(intBookingId)
            If objFunction.CheckDataSet(dstClientBooking) Then
                If Convert.IsDBNull(dstClientBooking.Tables(0).Rows(0)("agent_id")) = False Then
                    If objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(0)("agent_id")) = 0 Then
                        Dim objBEBookingStatusComplete As clsBEBookingStatusComplete = New clsBEBookingStatusComplete
                        objBEBookingStatusComplete.Easyways = True
                        Dim dstBookingStatusComplete As DataSet = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByEasyways(objBEBookingStatusComplete)
                        BindGridView(dstBookingStatusComplete)
                    Else
                        Dim objBEBookingStatusComplete As clsBEBookingStatusComplete = New clsBEBookingStatusComplete
                        objBEBookingStatusComplete.Agent = True
                        Dim dstBookingStatusComplete As DataSet = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByAgent(objBEBookingStatusComplete)
                        BindGridView(dstBookingStatusComplete)
                    End If
                Else
                    Dim objBEBookingStatusComplete As clsBEBookingStatusComplete = New clsBEBookingStatusComplete
                    objBEBookingStatusComplete.Easyways = True
                    Dim dstBookingStatusComplete As DataSet = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByEasyways(objBEBookingStatusComplete)
                    BindGridView(dstBookingStatusComplete)
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
    Protected Sub BindGridView(ByVal dstData As DataSet)
        Try
            Dim dtData As DataTable
            Dim dtDataTemp As DataTable
            If objFunction.CheckDataSet(dstData) Then

                dtData = dstData.Tables(0)
                dtData.DefaultView.RowFilter = "cat = 1"
                dtDataTemp = dtData.DefaultView.ToTable()
                If objFunction.CheckDataTable(dtDataTemp) Then
                    GRID_Clients.DataSource = dtDataTemp
                    GRID_Clients.DataBind()

                    For i As Integer = 0 To GRID_Clients.Rows.Count - 1
                        Dim gRow As GridViewRow = GRID_Clients.Rows(i)
                        Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                        objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEBookingStatusBookings.BSCId = objFunction.ReturnInteger(dtDataTemp.Rows(i)("id"))
                        Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingIdAndBscId(objBEBookingStatusBookings)
                        Dim chkCheckStatus = DirectCast(gRow.FindControl("CHK_CheckStatus"), CheckBox)
                        chkCheckStatus.Attributes.Add("onclick", "AddRemoveBookingStatusBookings('" + objFunction.ReturnString(Session("BookingId")) + "','" + objFunction.ReturnString(dtDataTemp.Rows(i)("id")) + "')")
                        chkCheckStatus.Attributes.Add("class", "Chk_" + objFunction.ReturnString(dtDataTemp.Rows(i)("id")))
                        If objFunction.CheckDataSet(dstBookingStatusBookings) Then
                            If chkCheckStatus IsNot Nothing Then
                                chkCheckStatus.Checked = True
                            End If
                        End If
                    Next
                End If

                dtData = dstData.Tables(0)
                dtData.DefaultView.RowFilter = "cat = 2"
                dtDataTemp = dtData.DefaultView.ToTable()
                If objFunction.CheckDataTable(dtDataTemp) Then
                    GRID_Baggage.DataSource = dtDataTemp
                    GRID_Baggage.DataBind()

                    For i As Integer = 0 To GRID_Baggage.Rows.Count - 1
                        Dim gRow As GridViewRow = GRID_Baggage.Rows(i)
                        Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                        objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEBookingStatusBookings.BSCId = objFunction.ReturnInteger(dtDataTemp.Rows(i)("id"))
                        Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingIdAndBscId(objBEBookingStatusBookings)
                        Dim hdnBaggageBSCId = DirectCast(gRow.FindControl("hdnBaggageBSCId"), HiddenField)
                        hdnBaggageBSCId.Value = objFunction.ReturnString(dtDataTemp.Rows(i)("id"))
                        Dim chkCheckStatus = DirectCast(gRow.FindControl("CHK_CheckStatus"), CheckBox)
                        chkCheckStatus.Attributes.Add("onclick", "AddRemoveBookingStatusBookings('" + objFunction.ReturnString(Session("BookingId")) + "','" + objFunction.ReturnString(dtDataTemp.Rows(i)("id")) + "')")
                        chkCheckStatus.Attributes.Add("class", "Chk_" + objFunction.ReturnString(dtDataTemp.Rows(i)("id")))
                        If objFunction.CheckDataSet(dstBookingStatusBookings) Then
                            If chkCheckStatus IsNot Nothing Then
                                chkCheckStatus.Checked = True
                            End If
                        End If
                    Next
                End If

                dtData = dstData.Tables(0)
                dtData.DefaultView.RowFilter = "cat = 3"
                dtDataTemp = dtData.DefaultView.ToTable()
                If objFunction.CheckDataTable(dtDataTemp) Then
                    GRID_Extras.DataSource = dtDataTemp
                    GRID_Extras.DataBind()

                    For i As Integer = 0 To GRID_Extras.Rows.Count - 1
                        Dim gRow As GridViewRow = GRID_Extras.Rows(i)
                        Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                        objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEBookingStatusBookings.BSCId = objFunction.ReturnInteger(dtDataTemp.Rows(i)("id"))
                        Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingIdAndBscId(objBEBookingStatusBookings)
                        Dim hdnExtraBSCId = DirectCast(gRow.FindControl("hdnExtraBSCId"), HiddenField)
                        hdnExtraBSCId.Value = objFunction.ReturnString(dtDataTemp.Rows(i)("id"))
                        Dim chkCheckStatus = DirectCast(gRow.FindControl("CHK_CheckStatus"), CheckBox)
                        chkCheckStatus.Attributes.Add("onclick", "AddRemoveBookingStatusBookings('" + objFunction.ReturnString(Session("BookingId")) + "','" + objFunction.ReturnString(dtDataTemp.Rows(i)("id")) + "')")
                        chkCheckStatus.Attributes.Add("class", "Chk_" + objFunction.ReturnString(dtDataTemp.Rows(i)("id")))
                        If objFunction.CheckDataSet(dstBookingStatusBookings) Then
                            If chkCheckStatus IsNot Nothing Then
                                chkCheckStatus.Checked = True
                            End If
                        End If
                    Next
                End If

                dtData = dstData.Tables(0)
                dtData.DefaultView.RowFilter = "cat = 4"
                dtDataTemp = dtData.DefaultView.ToTable()
                If objFunction.CheckDataTable(dtDataTemp) Then
                    GRID_Changes.DataSource = dtDataTemp
                    GRID_Changes.DataBind()

                    For i As Integer = 0 To GRID_Changes.Rows.Count - 1
                        Dim gRow As GridViewRow = GRID_Changes.Rows(i)
                        Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                        objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEBookingStatusBookings.BSCId = objFunction.ReturnInteger(dtDataTemp.Rows(i)("id"))
                        Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingIdAndBscId(objBEBookingStatusBookings)
                        Dim chkCheckStatus = DirectCast(gRow.FindControl("CHK_CheckStatus"), CheckBox)
                        chkCheckStatus.Attributes.Add("onclick", "AddRemoveBookingStatusBookings('" + objFunction.ReturnString(Session("BookingId")) + "','" + objFunction.ReturnString(dtDataTemp.Rows(i)("id")) + "')")
                        chkCheckStatus.Attributes.Add("class", "Chk_" + objFunction.ReturnString(dtDataTemp.Rows(i)("id")))
                        If objFunction.CheckDataSet(dstBookingStatusBookings) Then
                            If chkCheckStatus IsNot Nothing Then
                                chkCheckStatus.Checked = True
                            End If
                        End If
                    Next
                End If

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
        Try
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to add baggage record
    ''' </summary>
    Protected Sub BUT_Baggage_Not_Required_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Baggage_Not_Required.Click
        Try
            Dim intAffectedRow As Integer = 1
            If objFunction.ReturnInteger(GRID_Baggage.Rows.Count) > 0 Then
                For i As Integer = 0 To GRID_Baggage.Rows.Count - 1
                    Dim gRow As GridViewRow = GRID_Baggage.Rows(i)
                    Dim hdnBaggageBSCId = DirectCast(gRow.FindControl("hdnBaggageBSCId"), HiddenField)
                    Dim chkCheckStatus = DirectCast(gRow.FindControl("CHK_CheckStatus"), CheckBox)
                    If chkCheckStatus IsNot Nothing Then
                        If chkCheckStatus.Checked = False Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = hdnBaggageBSCId.Value
                            intAffectedRow = objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If
                    End If
                Next
            End If
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Baggage has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("bookings_status2.aspx#two")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to add extra record
    ''' </summary>
    Protected Sub BUT_Extras_Not_Required_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Extras_Not_Required.Click
        Try
            Dim intAffectedRow As Integer = 1
            If objFunction.ReturnInteger(GRID_Extras.Rows.Count) > 0 Then
                For i As Integer = 0 To GRID_Extras.Rows.Count - 1
                    Dim gRow As GridViewRow = GRID_Extras.Rows(i)
                    Dim hdnExtraBSCId = DirectCast(gRow.FindControl("hdnExtraBSCId"), HiddenField)
                    Dim chkCheckStatus = DirectCast(gRow.FindControl("CHK_CheckStatus"), CheckBox)
                    If chkCheckStatus IsNot Nothing Then
                        If chkCheckStatus.Checked = False Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = hdnExtraBSCId.Value
                            intAffectedRow = objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If
                    End If
                Next
            End If
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Extra has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("bookings_status2.aspx#three")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class