Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_add_baggage
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
            dstBookingDetail = (New clsDLBooking()).GetBookingDetailById(objBEBooking, intAccomStageId)

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

                FillBaggageService(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("route_id")), intCompanyId)
                BindBaggageServicesGridview()
                
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to fill baggage service dropdown
    ''' </summary>
    Protected Sub FillBaggageService(ByVal intRouteId As Integer, ByVal intCompanyId As Integer)
        Try
            Dim dstAccommodationStage As DataSet = (New clsDLExtrasBaggageLinkRoute()).GetExtrasBaggageLinkRouteByRouteIdFillInDD(intRouteId, intCompanyId)
            objFunction.FillDropDownByDataSet(DROP_Baggage_Services, dstAccommodationStage)
            DROP_Baggage_Services.Items.Insert(0, New ListItem("Select Baggage Service", "0"))
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to bind baggage services gridview
    ''' </summary>
    Protected Sub BindBaggageServicesGridview()

        Try
            Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
            Dim dstExtrasBaggageBooking As New DataSet()
            objBEExtrasBaggageBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            dstExtrasBaggageBooking = (New clsDLExtrasBaggageBooking()).GetExtrasBaggageBookingByBookingId(objBEExtrasBaggageBooking)
            GRID_View_Baggage.DataSource = dstExtrasBaggageBooking
            GRID_View_Baggage.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GRID_View_Baggage
    ''' </summary>
    Protected Sub GRID_View_Baggage_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lb As LinkButton = DirectCast(e.Row.Cells(6).Controls(2), LinkButton)
                If lb IsNot Nothing Then
                    If lb.Text = "Delete" Then
                        lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
                    End If
                End If

                Dim chkBookedYN = DirectCast(e.Row.FindControl("CHK_BookedYN"), CheckBox)
                If chkBookedYN IsNot Nothing Then
                    Dim bnlChkVal As Boolean = Convert.ToBoolean(TryCast(e.Row.FindControl("hdnBookedYN"), HiddenField).Value)
                    If bnlChkVal = True Then
                        chkBookedYN.Checked = True
                        chkBookedYN.Enabled = False
                    End If
                End If

                Dim chkInvoice = DirectCast(e.Row.FindControl("CHK_Invoice"), CheckBox)
                If chkInvoice IsNot Nothing Then
                    Dim bnlChkVal As Boolean = Convert.ToBoolean(TryCast(e.Row.FindControl("hdnInvoice"), HiddenField).Value)
                    If bnlChkVal = True Then
                        chkInvoice.Checked = True
                    End If
                End If

            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GridView1
    ''' </summary>
    Protected Sub GRID_View_Baggage_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GridView1.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingStageExtraBaggageBookingId") = objFunction.ReturnString(GRID_View_Baggage.DataKeys(e.NewSelectedIndex).Value)
            Session("PageRequest") = "bookings_add_baggage"
            Response.Redirect("correspondance_supplier.aspx#one")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowEditing event of the GRID_View_Baggage
    ''' </summary>
    Protected Sub GRID_View_Baggage_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

        Try
            GRID_View_Baggage.EditIndex = e.NewEditIndex
            BindBaggageServicesGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowCancelingEdit event of the GRID_View_Baggage
    ''' </summary>
    Protected Sub GRID_View_Baggage_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)

        Try
            GRID_View_Baggage.EditIndex = -1
            BindBaggageServicesGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_View_Baggage
    ''' </summary>
    Protected Sub GRID_View_Baggage_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_View_Baggage.PageIndex = e.NewPageIndex
            BindBaggageServicesGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowUpdating event of the GRID_View_Baggage
    ''' </summary>
    Protected Sub GRID_View_Baggage_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GRID_View_Baggage.DataKeys(e.RowIndex).Values("id")))
            Dim txtTotalBags As TextBox = DirectCast(GRID_View_Baggage.Rows(e.RowIndex).FindControl("TB_TotalBags"), TextBox)
            Dim txtCostEasyways As TextBox = DirectCast(GRID_View_Baggage.Rows(e.RowIndex).FindControl("TB_CostEasyways"), TextBox)
            Dim txtCostClient As TextBox = DirectCast(GRID_View_Baggage.Rows(e.RowIndex).FindControl("TB_CostClient"), TextBox)
            Dim chkBookedYN As CheckBox = DirectCast(GRID_View_Baggage.Rows(e.RowIndex).FindControl("CHK_BookedYN"), CheckBox)
            Dim chkInvoice As CheckBox = DirectCast(GRID_View_Baggage.Rows(e.RowIndex).FindControl("CHK_Invoice"), CheckBox)
            Dim txtInfoSupplierEmail As TextBox = DirectCast(GRID_View_Baggage.Rows(e.RowIndex).FindControl("TB_InfoSupplierEmail"), TextBox)
            Dim txtInsBookingConf As TextBox = DirectCast(GRID_View_Baggage.Rows(e.RowIndex).FindControl("TB_InsBookingConf"), TextBox)

            Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
            objBEExtrasBaggageBooking.ExtrasBaggageBookingId = id
            objBEExtrasBaggageBooking.NoBags = objFunction.ReturnInteger(txtTotalBags.Text)
            objBEExtrasBaggageBooking.CostEasyway = objFunction.ReturnDouble(txtCostEasyways.Text)
            objBEExtrasBaggageBooking.CostClient = objFunction.ReturnDouble(txtCostClient.Text)
            objBEExtrasBaggageBooking.InfoSupplierEmail = txtInfoSupplierEmail.Text
            objBEExtrasBaggageBooking.Instructionx = txtInsBookingConf.Text
            If chkBookedYN.Checked = True Then
                objBEExtrasBaggageBooking.BookedYN = True
                objBEExtrasBaggageBooking.BookedDate = DateTime.Now
            Else
                objBEExtrasBaggageBooking.BookedYN = False
            End If

            If chkInvoice.Checked = True Then
                objBEExtrasBaggageBooking.Invoicex = True
            Else
                objBEExtrasBaggageBooking.Invoicex = False
            End If

            Dim intAffectedRow As Integer = (New clsDLExtrasBaggageBooking()).PerformGridViewOpertaion("UPDATE", objBEExtrasBaggageBooking)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Baggage services has been amended"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_View_Baggage.EditIndex = -1
            'BindBaggageServicesGridview()
            Response.Redirect("bookings_add_baggage.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GRID_View_Baggage
    ''' </summary>
    Protected Sub GRID_View_Baggage_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
            objBEExtrasBaggageBooking.ExtrasBaggageBookingId = objFunction.ReturnInteger(GRID_View_Baggage.DataKeys(e.RowIndex).Values("id").ToString())
            Dim intAffectedRow As Integer = (New clsDLExtrasBaggageBooking()).PerformGridViewOpertaion("DELETE", objBEExtrasBaggageBooking)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Baggage services has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_View_Baggage.EditIndex = -1
            'BindBaggageServicesGridview()
            Response.Redirect("bookings_add_baggage.aspx", False)
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
    ''' SelectedIndexChanged event of dropdown
    ''' </summary>
    Protected Sub DROP_Baggage_Services_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Baggage_Services.SelectedIndexChanged
        Try
            Dim dstExtraRouteStage As DataSet = (New clsDLExtrasBaggageLinkRoute()).GetExtrasBaggageLinkRouteById(objFunction.ReturnInteger(DROP_Baggage_Services.SelectedItem.Value))
            If objFunction.CheckDataSet(dstExtraRouteStage) Then
                TB_EW_Cost.Text = objFunction.ReturnString(dstExtraRouteStage.Tables(0).Rows(0)("cost_easyways"))
                TB_Client_Cost.Text = objFunction.ReturnString(dstExtraRouteStage.Tables(0).Rows(0)("cost_client"))
                TB_From_To_Stages.Text = objFunction.ReturnString(dstExtraRouteStage.Tables(0).Rows(0)("additional_notes"))
                hdnExtraId.Value = objFunction.ReturnString(dstExtraRouteStage.Tables(0).Rows(0)("extras_id"))
                GetInstructions()
            End If
            hdnAccordianStatus.Value = "one"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of dropdown
    ''' </summary>
    Protected Sub DROP_Instructions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Instructions.SelectedIndexChanged
        Try
            GetInstructions()
            hdnAccordianStatus.Value = "one"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to bind instruction
    ''' </summary>
    Protected Sub GetInstructions()

        Try
            If objFunction.ReturnInteger(DROP_Baggage_Services.SelectedItem.Value) > 0 Then
                Dim intExtraId As Integer = objFunction.ReturnInteger(hdnExtraId.Value)
                Dim dstExtrasBaggageDetails As DataSet = (New clsDLExtrasBaggageDetails()).GetExtraBaggageDetailByExtraId(intExtraId)
                If objFunction.CheckDataSet(dstExtrasBaggageDetails) Then
                    If objFunction.ReturnString(DROP_Instructions.SelectedItem.Value) = "0" Then
                        'Option1
                        TB_Instructions.Text = objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("instructions1"))
                    Else
                        'Option2
                        TB_Instructions.Text = objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("instructions2"))
                    End If
                    TB_Max_no_of_Bags.Text = objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("bags"))    '
                End If
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add extra booking details
    ''' </summary>
    Protected Sub BUT_Add_Baggage_to_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Baggage_to_Booking.Click
        Try
            Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
            Dim objDLExtrasBaggageBooking As clsDLExtrasBaggageBooking = New clsDLExtrasBaggageBooking

            If objFunction.ReturnInteger(DROP_Baggage_Services.SelectedItem.Value) > 0 Then

                objBEExtrasBaggageBooking.ExtrasBaggageLinkRouteId = objFunction.ReturnInteger(DROP_Baggage_Services.SelectedItem.Value)
                objBEExtrasBaggageBooking.BookedYN = False
                objBEExtrasBaggageBooking.BookedDate = DateTime.MinValue
                objBEExtrasBaggageBooking.CostEasyway = objFunction.ReturnDouble(TB_EW_Cost.Text)
                objBEExtrasBaggageBooking.CostClient = objFunction.ReturnDouble(TB_Client_Cost.Text)
                objBEExtrasBaggageBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEExtrasBaggageBooking.Paidx = False
                If CHK_Show_in_Invoice.Checked = True Then
                    objBEExtrasBaggageBooking.Invoicex = True
                Else
                    objBEExtrasBaggageBooking.Invoicex = False
                End If
                objBEExtrasBaggageBooking.Instructionx = TB_Instructions.Text
                objBEExtrasBaggageBooking.NoBags = objFunction.ReturnInteger(TB_Total_No_of_Bags.Text)
                objBEExtrasBaggageBooking.InfoSupplierEmail = TB_Baggage_Email_Notes.Text

                Dim intAffectedRow As Integer = objDLExtrasBaggageBooking.AddExtrasBaggageBooking(objBEExtrasBaggageBooking)

                If intAffectedRow > 0 Then

                    'Add Booking_Status_Bookings
                    Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                    Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                    objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                    objBEBookingStatusBookings.BSCId = 6
                    objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)

                    Session("feedback_call") = "1"
                    Session("error_msg") = "Baggage services has been added"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If

                Response.Redirect("bookings_add_baggage.aspx")

            End If

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

    Protected Sub BUT_Baggage_Internal_Google_Doc_Link_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Baggage_Internal_Google_Doc_Link.Click
        Try
            If objFunction.ReturnInteger(DROP_Baggage_Services.SelectedItem.Value) > 0 Then
                Dim dstExtrasBaggageLinkRoute As DataSet = (New clsDLExtrasBaggageLinkRoute()).GetExtrasBaggageLinkRouteById(objFunction.ReturnInteger(DROP_Baggage_Services.SelectedItem.Value))
                If objFunction.CheckDataSet(dstExtrasBaggageLinkRoute) Then
                    Dim dstExtra As DataSet = (New clsDLExtra()).GetExtraDetailById(objFunction.ReturnInteger(dstExtrasBaggageLinkRoute.Tables(0).Rows(0)("extras_id")))
                    If objFunction.CheckDataSet(dstExtra) Then
                        Dim strUrl = objFunction.ReturnString(dstExtra.Tables(0).Rows(0)("google_doc"))
                        Response.Write("<script>")
                        Response.Write("window.open('" + strUrl + "','_blank')")
                        Response.Write("<" + "/script>")
                    End If
                End If
            End If
            hdnAccordianStatus.Value = "one"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function FormatEmailText(ByVal value As Object) As String
        Try
            If objFunction.ReturnString(value) <> "" Then
                Return objFunction.ReturnString(value).Replace(Environment.NewLine, "<br/>")
            Else
                Return ""
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

End Class





