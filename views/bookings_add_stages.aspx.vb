Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_add_stages
    Inherits System.Web.UI.Page

    Protected objFunction As New clsCommon()
    Protected dstRoomType As DataSet
    Protected intAccomStageCount As Integer = 0

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
                DROP_Instructions.Items.FindByValue("1").Selected = True
                GetDirectionUrlOption()

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
                'LABEL_Total_Number_in_Party.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("total_num"))
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

                LABEL_No_of_Males.Text = objFunction.ReturnString(intNoOfMale)
                LABEL_No_of_Females.Text = objFunction.ReturnString(intNoOfFemale)
                LABEL_No_of_Unspecified.Text = objFunction.ReturnString(intNoOfOther)
                LABEL_Total_no_People.Text = objFunction.ReturnString((intNoOfMale + intNoOfFemale + intNoOfOther))
                LABEL_En_Suite_Preference.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ensuite"))

                Trace.Warn("checkin = " + objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("checkin")))
                Trace.Warn("checkout = " + objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("checkout")))
                If objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("checkin")) = "" And objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("checkout")) = "" Then
                    DIV_below_content.Visible = False
                    Dim intSequence = objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("Sequence"))
                    Dim dstBookingDetailBySeq As DataSet = (New clsDLBooking()).GetBookingDetailByAccomStageSeq(objBEBooking, (intSequence - 1))
                    If objFunction.CheckDataSet(dstBookingDetailBySeq) Then
                        If objFunction.ReturnString(dstBookingDetailBySeq.Tables(0).Rows(0)("checkin")) <> "" And objFunction.ReturnString(dstBookingDetailBySeq.Tables(0).Rows(0)("checkout")) <> "" Then
                            Dim dt As DateTime = Convert.ToDateTime(dstBookingDetailBySeq.Tables(0).Rows(0)("checkout"))
                            TB_Check_IN_Date.Text = dt.ToString("yyyy-MM-dd")
                            TB_Check_OUT_Date.Text = dt.AddDays(1).ToString("yyyy-MM-dd")
                        End If
                    End If
                Else
                    Dim dt As DateTime = Convert.ToDateTime(dstBookingDetail.Tables(0).Rows(0)("checkin"))
                    TB_Check_IN_Date.Text = dt.ToString("yyyy-MM-dd")

                    dt = Convert.ToDateTime(dstBookingDetail.Tables(0).Rows(0)("checkout"))
                    TB_Check_OUT_Date.Text = dt.ToString("yyyy-MM-dd")
                End If

                TB_Note_to_Supplier.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("supplier_note"))
                TB_Client_Note_URL.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("client_note"))
                TB_Client_Note_invoice.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("invoice_note"))

                Dim intAccomId As Integer = objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("accomodation_id"))
                Trace.Warn("intAccomId = " + intAccomId.ToString())
                ViewState.Add("AccomId", intAccomId)
                If intAccomId = 0 Then
                    DIV_bookings_select_accom.Visible = True
                    'DIV_bookings_accom_show.Visible = False
                    DIV_View_Accom.Visible = False
                    DIV_View_Room.Visible = False
                    'DIV_View_Extra.Visible = False
                    hdnShowAccordian.Value = "Two"
                Else
                    DIV_bookings_select_accom.Visible = False
                    'DIV_bookings_accom_show.Visible = True
                    DIV_View_Accom.Visible = True
                    DIV_View_Room.Visible = True
                    'DIV_View_Extra.Visible = True
                    hdnShowAccordian.Value = ""
                    TB_Total_Cost_Dogs.Text = objFunction.ReturnString(Session("DogPrice"))
                End If

                ViewState.Add("StageId", objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("stage_id")))

                If objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("dog_friendly")) <> "" Then
                    If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("dog_friendly")) = True Then
                        CHK_Dog_Friendly.Checked = True
                        FillAccommodationName(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("stage_id")), intCompanyId, True)
                    Else
                        FillAccommodationName(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("stage_id")), intCompanyId, False)
                    End If
                Else
                    FillAccommodationName(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("stage_id")), intCompanyId, False)
                End If

                FillRoomType(intAccomId)
                BindRoomGridview()
                FillExtraServices(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("route_stage_id")))
                BindExtraServicesGridview()
                BindAllBookingStageGridview()

                Trace.Warn("AccomStageSeq = " + objFunction.ReturnString(Session("AccomStageSeq")))
                Trace.Warn("intAccomStageCount = " + objFunction.ReturnString(intAccomStageCount))
                If objFunction.ReturnInteger(Session("AccomStageSeq")) = 1 Then
                    Button2.Visible = False
                End If

                If intAccomStageCount = objFunction.ReturnInteger(Session("AccomStageSeq")) Then
                    Button3.Visible = False
                End If

                Dim dstAccomRouteStage As DataSet = (New clsDLAccomodation()).GetAccommodationDetailById(intAccomId)
                If dstAccomRouteStage IsNot Nothing Then
                    TB_Accom_Name.Text = objFunction.ReturnString(dstAccomRouteStage.Tables(0).Rows(0)("name"))
                    TB_phone1.Text = objFunction.ReturnString(dstAccomRouteStage.Tables(0).Rows(0)("phone"))
                    div_accordions.Visible = True
                End If

                BUT_View_Accom.Visible = False
                BUT_Confirm_Accom.Visible = False
                DIV_accom_comments.Visible = False

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to fill accomdation name dropdown
    ''' </summary>
    Protected Sub FillAccommodationName(ByVal intStageId As Integer, ByVal intCompanyId As Integer, ByVal bnlDogFriendly As Boolean)
        Try
            DROP_Accommodation_Name.Items.Clear()
            Dim dstAccommodationStage As DataSet = (New clsDLAccomodationStage()).GetAccommodationForStageWithDogFriendlyFillInDD(intStageId, intCompanyId, bnlDogFriendly)
            DROP_Accommodation_Name.Items.Insert(0, New ListItem("Select Accommodation", "0"))
            If objFunction.CheckDataSet(dstAccommodationStage) Then
                For i = 0 To dstAccommodationStage.Tables(0).Rows.Count - 1
                    Dim strValue As String = objFunction.ReturnString(dstAccommodationStage.Tables(0).Rows(i)("value")) + " " + objFunction.ReturnString(dstAccommodationStage.Tables(0).Rows(i)("address2")) + " " + objFunction.ReturnString(dstAccommodationStage.Tables(0).Rows(i)("city"))
                    Dim lstItem As ListItem = New ListItem(strValue, objFunction.ReturnString(dstAccommodationStage.Tables(0).Rows(i)("ID")))
                    DROP_Accommodation_Name.Items.Insert((i + 1), lstItem)
                Next
            End If
            'objFunction.FillDropDownByDataSet(DROP_Accommodation_Name, dstAccommodationStage)
            'DROP_Accommodation_Name.Items.Insert(0, New ListItem("Select Accommodation", "0"))
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to fill room type dropdown
    ''' </summary>
    Protected Sub FillRoomType(ByVal intAccomId As Integer)
        Try
            dstRoomType = (New clsDLAccomRooms()).GetRoomTypeByAccomIdFillInDD(intAccomId)
            'objFunction.FillDropDownByDataSet(DROP_Room_Type, dstRoomType)
            'DROP_Room_Type.Items.Insert(0, New ListItem("Select Room Type", "0"))
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to fill extra services dropdown
    ''' </summary>
    Protected Sub FillExtraServices(ByVal intRouteStageId As Integer)
        Try
            Trace.Warn("intRouteStageId = " + objFunction.ReturnString(intRouteStageId))
            Dim dstExtraRouteStage As DataSet = (New clsDLExtraRouteStage()).GetRoomTypeByRouteStageIdFillInDD(intRouteStageId)
            objFunction.FillDropDownByDataSet(DROP_Extra_Services, dstExtraRouteStage)
            DROP_Extra_Services.Items.Insert(0, New ListItem("Select Extra Services", "0"))
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to bind room gridview
    ''' </summary>
    Protected Sub BindRoomGridview()

        Try
            Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
            Dim dstAccomStageRoom As New DataSet()
            objBEAccomStageRoom.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            dstAccomStageRoom = (New clsDLAccomStageRoom()).GetAccomStageRoomByAccomStageId(objBEAccomStageRoom)
            GRID_View_Rooms.DataSource = dstAccomStageRoom
            GRID_View_Rooms.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GRID_View_Rooms
    ''' </summary>
    Protected Sub GRID_View_Rooms_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lb As LinkButton = DirectCast(e.Row.Cells(10).Controls(2), LinkButton)
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
    ''' RowEditing event of the GRID_View_Rooms
    ''' </summary>
    Protected Sub GRID_View_Rooms_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

        Try
            GRID_View_Rooms.EditIndex = e.NewEditIndex
            BindRoomGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowCancelingEdit event of the GRID_View_Rooms
    ''' </summary>
    Protected Sub GRID_View_Rooms_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)

        Try
            GRID_View_Rooms.EditIndex = -1
            BindRoomGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_View_Rooms
    ''' </summary>
    Protected Sub GRID_View_Rooms_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_View_Rooms.PageIndex = e.NewPageIndex
            BindRoomGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowUpdating event of the GRID_View_Rooms
    ''' </summary>
    Protected Sub GRID_View_Rooms_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GRID_View_Rooms.DataKeys(e.RowIndex).Values("id")))
            Dim txtMales As TextBox = DirectCast(GRID_View_Rooms.Rows(e.RowIndex).FindControl("TB_Males"), TextBox)
            'Dim txtFemales As TextBox = DirectCast(GRID_View_Rooms.Rows(e.RowIndex).FindControl("TB_Females"), TextBox)
            Dim txtChildren As TextBox = DirectCast(GRID_View_Rooms.Rows(e.RowIndex).FindControl("TB_Children"), TextBox)
            Dim txtDogs As TextBox = DirectCast(GRID_View_Rooms.Rows(e.RowIndex).FindControl("TB_Dogs"), TextBox)
            Dim txtDogsCost As TextBox = DirectCast(GRID_View_Rooms.Rows(e.RowIndex).FindControl("TB_DogsCost"), TextBox)
            Dim txtCostEasyways As TextBox = DirectCast(GRID_View_Rooms.Rows(e.RowIndex).FindControl("TB_CostEasyways"), TextBox)
            Dim txtCostClient As TextBox = DirectCast(GRID_View_Rooms.Rows(e.RowIndex).FindControl("TB_CostClient"), TextBox)
            Dim txtNotes As TextBox = DirectCast(GRID_View_Rooms.Rows(e.RowIndex).FindControl("TB_Notes"), TextBox)

            Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
            objBEAccomStageRoom.AccomStageRoomId = id
            objBEAccomStageRoom.NoMales = objFunction.ReturnInteger(txtMales.Text)
            'objBEAccomStageRoom.NoFemales = objFunction.ReturnInteger(txtFemales.Text)
            objBEAccomStageRoom.NoOfChildren = objFunction.ReturnInteger(txtChildren.Text)
            objBEAccomStageRoom.NoDogs = objFunction.ReturnInteger(txtDogs.Text)
            objBEAccomStageRoom.TotalCostDogs = objFunction.ReturnDouble(txtDogsCost.Text)
            objBEAccomStageRoom.CostEasyway = objFunction.ReturnDouble(txtCostEasyways.Text)
            objBEAccomStageRoom.CostClient = objFunction.ReturnDouble(txtCostClient.Text)
            objBEAccomStageRoom.AdditionalNotes = txtNotes.Text
            Dim intAffectedRow As Integer = (New clsDLAccomStageRoom()).PerformGridViewOpertaion("UPDATE", objBEAccomStageRoom)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Room has been amended"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_View_Rooms.EditIndex = -1
            'BindRoomGridview()
            Response.Redirect("bookings_add_stages.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GRID_View_Rooms
    ''' </summary>
    Protected Sub GRID_View_Rooms_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
            objBEAccomStageRoom.AccomStageRoomId = objFunction.ReturnInteger(GRID_View_Rooms.DataKeys(e.RowIndex).Values("id").ToString())
            Dim intAffectedRow As Integer = (New clsDLAccomStageRoom()).PerformGridViewOpertaion("DELETE", objBEAccomStageRoom)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Room has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_View_Rooms.EditIndex = -1
            'BindRoomGridview()
            Response.Redirect("bookings_add_stages.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind extra services gridview
    ''' </summary>
    Protected Sub BindExtraServicesGridview()

        Try
            Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
            Dim dstExtrasBooking As New DataSet()
            objBEExtrasBooking.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            dstExtrasBooking = (New clsDLExtrasBooking()).GetExtrasBookingByAccomStageId(objBEExtrasBooking)
            GRID_View_Extras.DataSource = dstExtrasBooking
            GRID_View_Extras.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GRID_View_Extras
    ''' </summary>
    Protected Sub GRID_View_Extras_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lb As LinkButton = DirectCast(e.Row.Cells(5).Controls(2), LinkButton)
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
    ''' RowEditing event of the GRID_View_Extras
    ''' </summary>
    Protected Sub GRID_View_Extras_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

        Try
            GRID_View_Extras.EditIndex = e.NewEditIndex
            BindExtraServicesGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowCancelingEdit event of the GRID_View_Extras
    ''' </summary>
    Protected Sub GRID_View_Extras_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)

        Try
            GRID_View_Extras.EditIndex = -1
            BindExtraServicesGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_View_Extras
    ''' </summary>
    Protected Sub GRID_View_Extras_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_View_Extras.PageIndex = e.NewPageIndex
            BindExtraServicesGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowUpdating event of the GRID_View_Extras
    ''' </summary>
    Protected Sub GRID_View_Extras_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GRID_View_Extras.DataKeys(e.RowIndex).Values("id")))
            Dim txtCostEasyways As TextBox = DirectCast(GRID_View_Extras.Rows(e.RowIndex).FindControl("TB_CostEasyways"), TextBox)
            Dim txtCostClient As TextBox = DirectCast(GRID_View_Extras.Rows(e.RowIndex).FindControl("TB_CostClient"), TextBox)
            Dim chkBookedYN As CheckBox = DirectCast(GRID_View_Extras.Rows(e.RowIndex).FindControl("CHK_BookedYN"), CheckBox)
            Dim chkInvoice As CheckBox = DirectCast(GRID_View_Extras.Rows(e.RowIndex).FindControl("CHK_Invoice"), CheckBox)

            Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
            objBEExtrasBooking.ExtrasBookingId = id
            objBEExtrasBooking.CostEasyway = objFunction.ReturnDouble(txtCostEasyways.Text)
            objBEExtrasBooking.CostClient = objFunction.ReturnDouble(txtCostClient.Text)
            If chkBookedYN.Checked = True Then
                objBEExtrasBooking.BookedYN = True
                objBEExtrasBooking.BookedDate = DateTime.Now
            Else
                objBEExtrasBooking.BookedYN = False
            End If

            If chkInvoice.Checked = True Then
                objBEExtrasBooking.Invoicex = True
            Else
                objBEExtrasBooking.Invoicex = False
            End If

            Dim intAffectedRow As Integer = (New clsDLExtrasBooking()).PerformGridViewOpertaion("UPDATE", objBEExtrasBooking)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Extra Services has been amended"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_View_Extras.EditIndex = -1
            'BindExtraServicesGridview()
            Response.Redirect("bookings_add_stages.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GRID_View_Extras
    ''' </summary>
    Protected Sub GRID_View_Extras_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
            objBEExtrasBooking.ExtrasBookingId = objFunction.ReturnInteger(GRID_View_Extras.DataKeys(e.RowIndex).Values("id").ToString())
            Dim intAffectedRow As Integer = (New clsDLExtrasBooking()).PerformGridViewOpertaion("DELETE", objBEExtrasBooking)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Extra Services has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_View_Extras.EditIndex = -1
            'BindExtraServicesGridview()
            Response.Redirect("bookings_add_stages.aspx", False)
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
            Session("DogPrice") = Nothing
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to update confirm dates
    ''' </summary>
    Protected Sub BUT_Confirm_Date_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Confirm_Date.Click

        Try
            'Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
            'Dim objDLClientBooking As clsDLClientBooking = New clsDLClientBooking

            'Dim dstClientBooking As DataSet = objDLClientBooking.GetClientBookingByBookingId(objFunction.ReturnInteger(Session("BookingId")))
            'If objFunction.CheckDataSet(dstClientBooking) Then
            '    If objFunction.ReturnString(dstClientBooking.Tables(0).Rows(0)("checkin_earliest")) <> "" Then
            '        Dim result As Integer = DateTime.Compare(Convert.ToDateTime(TB_Check_IN_Date.Text), Convert.ToDateTime(dstClientBooking.Tables(0).Rows(0)("checkin_earliest")))
            '        If result < 0 Then
            '            'is earlier than
            '            objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            '            objBEClientBooking.CheckinEarliest = Convert.ToDateTime(TB_Check_IN_Date.Text)
            '            objDLClientBooking.UpdateCheckinEarliestAndCheckoutLatestDateByBookingId("UpdateCheckinEarliestDate", objBEClientBooking)
            '        End If
            '    Else
            '        objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            '        objBEClientBooking.CheckinEarliest = Convert.ToDateTime(TB_Check_IN_Date.Text)
            '        objDLClientBooking.UpdateCheckinEarliestAndCheckoutLatestDateByBookingId("UpdateCheckinEarliestDate", objBEClientBooking)
            '    End If

            '    If objFunction.ReturnString(dstClientBooking.Tables(0).Rows(0)("checkout_latest")) <> "" Then
            '        Dim result As Integer = DateTime.Compare(Convert.ToDateTime(TB_Check_OUT_Date.Text), Convert.ToDateTime(dstClientBooking.Tables(0).Rows(0)("checkout_latest")))
            '        If result > 0 Then
            '            'is later than
            '            objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            '            objBEClientBooking.CheckoutLatest = Convert.ToDateTime(TB_Check_OUT_Date.Text)
            '            objDLClientBooking.UpdateCheckinEarliestAndCheckoutLatestDateByBookingId("UpdateCheckoutLatestDate", objBEClientBooking)
            '        End If
            '    Else
            '        objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            '        objBEClientBooking.CheckoutLatest = Convert.ToDateTime(TB_Check_OUT_Date.Text)
            '        objDLClientBooking.UpdateCheckinEarliestAndCheckoutLatestDateByBookingId("UpdateCheckoutLatestDate", objBEClientBooking)
            '    End If
            'End If

            Dim objBEAccomStageDateBooking As clsBEAccomStageDateBooking = New clsBEAccomStageDateBooking
            Dim objDLAccomStageDateBooking As clsDLAccomStageDateBooking = New clsDLAccomStageDateBooking

            objBEAccomStageDateBooking.AccomRouteStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            objBEAccomStageDateBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            objBEAccomStageDateBooking.CheckInDate = Convert.ToDateTime(TB_Check_IN_Date.Text)
            objBEAccomStageDateBooking.CheckOutDate = Convert.ToDateTime(TB_Check_OUT_Date.Text)

            Dim intAffectedRow As Integer = objDLAccomStageDateBooking.UpdateCheckInOutDateByAccomRouteStageId(objBEAccomStageDateBooking)

            objBEAccomStageDateBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            Dim dstAccomStageDateBooking As DataSet = (New clsDLAccomStageDateBooking()).GetAccomStageDateBookingByBookingId(objBEAccomStageDateBooking)
            If objFunction.CheckDataSet(dstAccomStageDateBooking) Then
                Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                Dim objDLClientBooking As clsDLClientBooking = New clsDLClientBooking

                Dim dtData As DataTable = dstAccomStageDateBooking.Tables(0)
                Dim dtMinCheckInDate As DateTime = Convert.ToDateTime(dtData.Compute("MIN(checkin)", String.Empty))
                Dim dtMaxCheckOutDate As DateTime = Convert.ToDateTime(dtData.Compute("MAX(checkout)", String.Empty))
                Trace.Warn("Min Check in = " + objFunction.ReturnString(dtMinCheckInDate))
                Trace.Warn("Max Check out = " + objFunction.ReturnString(dtMaxCheckOutDate))

                objBEClientBooking.CheckinEarliest = dtMinCheckInDate
                objBEClientBooking.CheckoutLatest = dtMaxCheckOutDate
                objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objDLClientBooking.UpdateCheckinEarliestAndCheckoutLatestDateByBookingId("UpdateCheckinEarliestAndCheckoutLatestDate", objBEClientBooking)
                
            End If

            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Check-In and Check-Out date has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("bookings_add_stages.aspx")

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of dropdown
    ''' </summary>
    Protected Sub DROP_Accommodation_Name_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Accommodation_Name.SelectedIndexChanged

        Try
            If objFunction.ReturnInteger(DROP_Accommodation_Name.SelectedItem.Value) > 0 Then
                BUT_View_Accom.Visible = True
                BUT_Confirm_Accom.Visible = True
            Else
                BUT_View_Accom.Visible = False
                BUT_Confirm_Accom.Visible = False
            End If

            'Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            'objBEAccomRouteStage.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            'objBEAccomRouteStage.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            'Dim dstAccomRouteStage As DataSet = (New clsDLAccomRouteStage()).GetAccomCommentByAccomStageId(objBEAccomRouteStage)
            'If dstAccomRouteStage IsNot Nothing Then
            '    TB_Accom_Comments.Text = objFunction.ReturnString(dstAccomRouteStage.Tables(0).Rows(0)("commentx"))
            '    DIV_accom_comments.Visible = True
            'End If

            Dim dstAccomodationDetail As DataSet = (New clsDLAccomodation()).GetAccommodationDetailById(objFunction.ReturnInteger(DROP_Accommodation_Name.SelectedItem.Value))

            If objFunction.CheckDataSet(dstAccomodationDetail) And objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("commentx")) <> "" Then
                TB_Accom_Comments.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("commentx"))
                DIV_accom_comments.Visible = True
                Session("DogPrice") = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("dog_price"))
            Else
                DIV_accom_comments.Visible = False
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to view report
    ''' </summary>
    Protected Sub BUT_View_Accom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_View_Accom.Click

        'Response.Redirect("report_accom_view.aspx?id=" + objFunction.ReturnString(DROP_Accommodation_Name.SelectedItem.Value))
        Session("AccomId") = objFunction.ReturnString(DROP_Accommodation_Name.SelectedItem.Value)
        Dim strUrl = "accom_view_all.aspx"
        Response.Write("<script>")
        Response.Write("window.open('" + strUrl + "','_blank')")
        Response.Write("</script>")

    End Sub

    ''' <summary>
    ''' This event is used to confirm accomodation
    ''' </summary>
    Protected Sub BUT_Confirm_Accom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Confirm_Accom.Click

        Try
            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            objBEAccomRouteStage.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            objBEAccomRouteStage.AccomId = objFunction.ReturnInteger(DROP_Accommodation_Name.SelectedItem.Value)
            Dim intAffectedRow As Integer = (New clsDLAccomRouteStage()).UpdateAccomIdByAccomStageId(objBEAccomRouteStage)
            If intAffectedRow > 0 Then

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstAccomRouteStage As DataSet = (New clsDLAccomRouteStage()).GetAccomRouteStageByBookingId(objBEAccomRouteStage, intCompanyId)
                If objFunction.CheckDataSet(dstAccomRouteStage) Then
                    Dim dtData As DataTable = dstAccomRouteStage.Tables(0)
                    dtData.DefaultView.RowFilter = "accomodation_id = 0 OR accomodation_id IS NULL"
                    Dim dtDataTemp As DataTable = dtData.DefaultView.ToTable()
                    If Not objFunction.CheckDataTable(dtDataTemp) Then
                        'Add Booking_Status_Bookings
                        Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                        Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                        objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEBookingStatusBookings.BSCId = 5
                        objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                    End If
                End If

                Session("feedback_call") = "1"
                Session("error_msg") = "Accommodation has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to view report
    ''' </summary>
    Protected Sub BUT_View_Accom2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_View_Accom2.Click
        'Response.Redirect("report_accom_view.aspx?id=" + objFunction.ReturnString(DROP_Accommodation_Name.SelectedItem.Value))
        'Dim strUrl = "report_accom_view.aspx?id=" + objFunction.ReturnString(ViewState("AccomId"))
        Session("AccomId") = objFunction.ReturnString(ViewState("AccomId"))
        Dim strUrl = "accom_view_all.aspx"
        Response.Write("<script>")
        Response.Write("window.open('" + strUrl + "','_blank')")
        Response.Write("</script>")
    End Sub

    ''' <summary>
    ''' This event is used to remove accomodation
    ''' </summary>
    Protected Sub BUT_Remove_Accom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Remove_Accom.Click
        Try
            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            objBEAccomRouteStage.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            objBEAccomRouteStage.AccomId = 0
            Dim intAffectedRow As Integer = (New clsDLAccomRouteStage()).UpdateAccomIdByAccomStageId(objBEAccomRouteStage)

            Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
            objBEAccomStageRoom.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            Dim intAffectedRow1 As Integer = (New clsDLAccomStageRoom()).DeleteAccomStageRoomByAccomStageId(objBEAccomStageRoom)

            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Accommodation has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Session("DogPrice") = Nothing
            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ' ''' <summary>
    ' ''' SelectedIndexChanged event of dropdown
    ' ''' </summary>
    'Protected Sub DROP_Room_Type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Room_Type.SelectedIndexChanged
    '    Try
    '        Dim objBEAccomRooms As clsBEAccomRooms = New clsBEAccomRooms
    '        objBEAccomRooms.AccomId = ViewState("AccomId")
    '        objBEAccomRooms.RoomTypeId = objFunction.ReturnInteger(DROP_Room_Type.SelectedItem.Value)
    '        Dim dstAccomRoomType As DataSet = (New clsDLAccomRooms()).GetAccomRoomtypeById(objFunction.ReturnInteger(DROP_Room_Type.SelectedItem.Value))
    '        If objFunction.CheckDataSet(dstAccomRoomType) Then
    '            TB_EW_Cost.Text = objFunction.ReturnString(dstAccomRoomType.Tables(0).Rows(0)("cost_easyways"))
    '            TB_Client_Cost.Text = objFunction.ReturnString(dstAccomRoomType.Tables(0).Rows(0)("cost_client"))
    '        End If

    '        CHKLIST_Room_Options2.Items.Clear()
    '        Dim objBERoomTypeOptions As clsBERoomTypeOptions = New clsBERoomTypeOptions
    '        objBERoomTypeOptions.RoomTypeOptionsId = objFunction.ReturnInteger(DROP_Room_Type.SelectedItem.Value)
    '        objBERoomTypeOptions.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
    '        Dim dstRoomtypeOptionsDesc As DataSet = (New clsDLRoomTypeOptions()).GetRoomTypeOptionsByIdFillInDD(objBERoomTypeOptions)
    '        If objFunction.CheckDataSet(dstRoomtypeOptionsDesc) Then
    '            For i As Integer = 0 To dstRoomtypeOptionsDesc.Tables(0).Rows.Count - 1
    '                Dim item As New ListItem()
    '                item.Text = objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(i)("Value"))
    '                item.Value = objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(i)("Id"))
    '                CHKLIST_Room_Options2.Items.Add(item)
    '            Next
    '        End If

    '        CHKBOX_add_room_facilities.Items.Clear()
    '        Dim dstRoomFacilities As DataSet = (New clsDLAccomRooms()).GetRoomTypeFacilitiesByAccomRoomTypeIdFillInDD(objFunction.ReturnInteger(DROP_Room_Type.SelectedItem.Value))
    '        If objFunction.CheckDataSet(dstRoomFacilities) Then
    '            For i As Integer = 0 To dstRoomFacilities.Tables(0).Rows.Count - 1
    '                Dim item As New ListItem()
    '                item.Text = objFunction.ReturnString(dstRoomFacilities.Tables(0).Rows(i)("Value"))
    '                item.Value = objFunction.ReturnString(dstRoomFacilities.Tables(0).Rows(i)("Id"))
    '                item.Selected = True
    '                CHKBOX_add_room_facilities.Items.Add(item)
    '            Next
    '        End If
    '        CHKBOX_add_room_facilities.Enabled = False

    '        hdnAccordianStatus.Value = "one"
    '    Catch ex As Exception
    '        HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
    '        HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
    '    End Try
    'End Sub

    ''' <summary>
    ''' This event is used to add accom stage room detail
    ''' </summary>
    Protected Sub BUT_Add_Room_to_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Room_to_Booking.Click
        Try
            Dim intReturnResult As Integer = 0

            For i = 1 To objFunction.ReturnInteger(DROP_No_of_Rooms.SelectedItem.Value)
                intReturnResult = AddAccomStageRoomDetail()
            Next

            If intReturnResult > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Room has been added"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If

            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to AddAccomStageRoomDetail
    ''' </summary>
    Protected Function AddAccomStageRoomDetail() As Integer
        Try
            Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
            Dim objDLAccomStageRoom As clsDLAccomStageRoom = New clsDLAccomStageRoom

            Trace.Warn("Selected value = " + Request.Form("rb_Room_Select"))

            Dim rbVal As String = Request.Form("rb_Room_Select")
            Dim tmpRbVal As String() = rbVal.Split("^")
            Dim intRoomTypeId As Integer = objFunction.ReturnInteger(tmpRbVal(0))
            'Dim intRoomTypeId As Integer = objFunction.ReturnInteger(Request.Form("rb_Room_Select"))

            If intRoomTypeId > 0 Then

                objBEAccomStageRoom.AccomRoomTypeId = intRoomTypeId
                objBEAccomStageRoom.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
                objBEAccomStageRoom.NoMales = objFunction.ReturnInteger(TB_No_of_Males.Text)
                objBEAccomStageRoom.NoFemales = objFunction.ReturnInteger(TB_No_of_Females.Text)
                objBEAccomStageRoom.NoOfChildren = objFunction.ReturnInteger(TB_No_of_Children.Text)
                objBEAccomStageRoom.NoDogs = objFunction.ReturnInteger(TB_No_of_Dogs.Text)
                objBEAccomStageRoom.TotalCostDogs = objFunction.ReturnDouble(TB_Total_Cost_Dogs.Text)
                objBEAccomStageRoom.CostEasyway = objFunction.ReturnDouble(TB_EW_Cost.Text)
                objBEAccomStageRoom.CostClient = objFunction.ReturnDouble(TB_Client_Cost.Text)
                objBEAccomStageRoom.AdditionalNotes = TB_Additional_Notes.Text
                objBEAccomStageRoom.BookingId = objFunction.ReturnInteger(Session("BookingId"))

                Dim intAccomStageRoomId As Integer = objDLAccomStageRoom.AddAccomStageRoomDetail(objBEAccomStageRoom)

                If intAccomStageRoomId > 0 Then

                    Dim objBEAccomStageRoomOptions As clsBEAccomStageRoomOptions = New clsBEAccomStageRoomOptions

                    Dim intHdnRoomOptionCount As Integer = Request.Form("hdnRoomOptionCount_" + objFunction.ReturnString(intRoomTypeId))
                    Trace.Warn("intHdnRoomOptionCount = " + objFunction.ReturnString(intHdnRoomOptionCount))
                    If objFunction.ReturnInteger(intHdnRoomOptionCount) > 0 Then
                        For i = 0 To objFunction.ReturnInteger(intHdnRoomOptionCount) - 1
                            Dim chkVal As String = Request.Form("CHKBOXLIST_Room_Options_" + objFunction.ReturnString(intRoomTypeId) + "_" + objFunction.ReturnString(i))

                            If objFunction.ReturnString(chkVal) <> "" Then
                                Trace.Warn("chkVal = " + chkVal)
                                Dim tmpChkVal As String() = chkVal.Split("^")
                                Dim intCheckBoxValue As Integer = objFunction.ReturnInteger(tmpChkVal(0))
                                If intCheckBoxValue > 0 Then
                                    objBEAccomStageRoomOptions.AccomStageRoomId = intAccomStageRoomId
                                    objBEAccomStageRoomOptions.RoomTypeOptionId = intCheckBoxValue
                                    Dim intAffectedRow = (New clsDLAccomStageRoomOptions()).AddAccomStageRoomOptionsDetail(objBEAccomStageRoomOptions)
                                End If
                                Trace.Warn("checkbox val = " + objFunction.ReturnString(Request.Form("CHKBOXLIST_Room_Options_" + objFunction.ReturnString(intRoomTypeId) + "_" + objFunction.ReturnString(i))))
                            End If

                        Next
                    End If
                End If
                Return intAccomStageRoomId
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return 0
    End Function

    ''' <summary>
    ''' SelectedIndexChanged event of dropdown
    ''' </summary>
    Protected Sub DROP_Extra_Services_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Extra_Services.SelectedIndexChanged
        Try
            Dim dstExtraRouteStage As DataSet = (New clsDLExtraRouteStage()).GetExtraRouteStageById(objFunction.ReturnInteger(DROP_Extra_Services.SelectedItem.Value))
            If objFunction.CheckDataSet(dstExtraRouteStage) Then
                TB_EW_Cost2.Text = objFunction.ReturnString(dstExtraRouteStage.Tables(0).Rows(0)("cost_easyways"))
                TB_Client_Cost2.Text = objFunction.ReturnString(dstExtraRouteStage.Tables(0).Rows(0)("cost_client"))
                TB_From_To_Stages.Text = objFunction.ReturnString(dstExtraRouteStage.Tables(0).Rows(0)("StageName1")) + " TO " + objFunction.ReturnString(dstExtraRouteStage.Tables(0).Rows(0)("StageName2"))
                TB_Additional_Notes_Extras.Text = objFunction.ReturnString(dstExtraRouteStage.Tables(0).Rows(0)("additional_notes"))
            End If
            hdnAccordianStatus.Value = "two"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to add extra booking details
    ''' </summary>
    Protected Sub BUT_Add_Extra_to_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Extra_to_Booking.Click
        Try
            Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
            Dim objDLExtrasBooking As clsDLExtrasBooking = New clsDLExtrasBooking

            If objFunction.ReturnInteger(DROP_Extra_Services.SelectedItem.Value) > 0 Then

                objBEExtrasBooking.ExtrasId = objFunction.ReturnInteger(DROP_Extra_Services.SelectedItem.Value)
                objBEExtrasBooking.BookedYN = False
                objBEExtrasBooking.BookedDate = DateTime.MinValue
                objBEExtrasBooking.CostEasyway = objFunction.ReturnDouble(TB_EW_Cost2.Text)
                objBEExtrasBooking.CostClient = objFunction.ReturnDouble(TB_Client_Cost2.Text)
                objBEExtrasBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEExtrasBooking.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
                objBEExtrasBooking.Paidx = False
                If CHK_Show_in_Invoice.Checked = True Then
                    objBEExtrasBooking.Invoicex = True
                Else
                    objBEExtrasBooking.Invoicex = False
                End If
                objBEExtrasBooking.AdditionalInfo = TB_Additional_Notes_Extras.Text

                Dim intAffectedRow As Integer = objDLExtrasBooking.AddExtrasBooking(objBEExtrasBooking)

                If intAffectedRow > 0 Then

                    'Add Booking_Status_Bookings
                    Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                    Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                    objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                    objBEBookingStatusBookings.BSCId = 7
                    objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)

                    Session("feedback_call") = "1"
                    Session("error_msg") = "Extra services has been added"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If

                Response.Redirect("bookings_add_stages.aspx")

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

    Protected Sub CHK_Dog_Friendly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHK_Dog_Friendly.CheckedChanged

        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            If CHK_Dog_Friendly.Checked = True Then
                FillAccommodationName(objFunction.ReturnInteger(ViewState("StageId")), intCompanyId, True)
            Else
                FillAccommodationName(objFunction.ReturnInteger(ViewState("StageId")), intCompanyId, False)
            End If
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
            GetDirectionUrlOption(True)
            'If objFunction.ReturnInteger(DROP_Instructions.SelectedItem.Value) > 0 Then
            '    GetDirectionUrlOption(True)
            'End If
            hdnAccordianStatus.Value = "three"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub GetDirectionUrlOption(Optional ByVal bnlFlag As Boolean = False)

        Try
            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            objBEAccomRouteStage.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            Dim dstAccomRouteStage As DataSet = (New clsDLAccomRouteStage()).GetAccomByAccomStageId(objBEAccomRouteStage)
            If objFunction.CheckDataSet(dstAccomRouteStage) Then

                If objFunction.ReturnString(dstAccomRouteStage.Tables(0).Rows(0)("AccomStageDirection")) <> "" And bnlFlag = False Then
                    TB_Instructions.Text = objFunction.ReturnString(dstAccomRouteStage.Tables(0).Rows(0)("AccomStageDirection"))
                Else
                    If objFunction.ReturnString(DROP_Instructions.SelectedItem.Value) = "1" Then
                        'Option1
                        TB_Instructions.Text = objFunction.ReturnString(dstAccomRouteStage.Tables(0).Rows(0)("directions"))
                    ElseIf objFunction.ReturnString(DROP_Instructions.SelectedItem.Value) = "2" Then
                        'Option2
                        TB_Instructions.Text = objFunction.ReturnString(dstAccomRouteStage.Tables(0).Rows(0)("directions2"))
                    ElseIf objFunction.ReturnString(DROP_Instructions.SelectedItem.Value) = "3" Then
                        'Option3
                        TB_Instructions.Text = objFunction.ReturnString(dstAccomRouteStage.Tables(0).Rows(0)("directions3"))
                    ElseIf objFunction.ReturnString(DROP_Instructions.SelectedItem.Value) = "4" Then
                        'Option4
                        TB_Instructions.Text = objFunction.ReturnString(dstAccomRouteStage.Tables(0).Rows(0)("directions4"))
                    Else
                        TB_Instructions.Text = objFunction.ReturnString(dstAccomRouteStage.Tables(0).Rows(0)("AccomStageDirection"))
                    End If
                End If
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to update instruction
    ''' </summary>
    Protected Sub BUT_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Update.Click
        Try
            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            objBEAccomRouteStage.Direction = TB_Instructions.Text
            Dim intAffectedRow As Integer = (New clsDLAccomRouteStage()).UpdateDirectionByAccomStageId(objBEAccomRouteStage)

            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Instructions has been amended"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If

            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindAllBookingStageGridview()

        Try
            Dim intBookingId = objFunction.ReturnInteger(Session("BookingId"))
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstAccomRouteStage As New DataSet()
            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.BookingId = intBookingId
            dstAccomRouteStage = (New clsDLAccomRouteStage()).GetAccomRouteStageByBookingId(objBEAccomRouteStage, intCompanyId)
            intAccomStageCount = objFunction.ReturnInteger(dstAccomRouteStage.Tables(0).Rows.Count)
            ViewState.Add("VS_AccomRouteStage", dstAccomRouteStage.Tables(0))
            GRID_All_Booking_Stages.DataSource = dstAccomRouteStage
            GRID_All_Booking_Stages.DataBind()

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GRID_All_Booking_Stages
    ''' </summary>
    Protected Sub GRID_All_Booking_Stages_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            'If e.Row.RowType = DataControlRowType.DataRow Then
            '    Dim lb As LinkButton = DirectCast(e.Row.Cells(4).Controls(0), LinkButton)
            '    If lb IsNot Nothing Then
            '        If lb.Text = "Delete" Then
            '            lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
            '        End If
            '    End If
            'End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_All_Booking_Stages
    ''' </summary>
    Protected Sub GRID_All_Booking_Stages_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_All_Booking_Stages.PageIndex = e.NewPageIndex
            BindAllBookingStageGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_All_Booking_Stages
    ''' </summary>
    Protected Sub GRID_All_Booking_Stages_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_All_Booking_Stages.DataKeys(e.NewSelectedIndex).Value))
            'Session("AccomStageId") = objFunction.ReturnString(GRID_All_Booking_Stages.DataKeys(e.NewSelectedIndex).Value)
            Session("AccomStageId") = objFunction.ReturnString(GRID_All_Booking_Stages.DataKeys(e.NewSelectedIndex).Values("id"))
            Session("AccomStageSeq") = objFunction.ReturnString(GRID_All_Booking_Stages.DataKeys(e.NewSelectedIndex).Values("seq"))
            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GRID_All_Booking_Stages
    ''' </summary>
    Protected Sub GRID_All_Booking_Stages_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            Dim intAccomStageId As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GRID_All_Booking_Stages.DataKeys(e.RowIndex).Values("id")))

            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.AccomStageId = intAccomStageId
            Dim intAffectedRow As Integer = (New clsDLAccomRouteStage().DeleteAccomRouteStage(objBEAccomRouteStage))

            Dim objBEAccomStageDateBooking As clsBEAccomStageDateBooking = New clsBEAccomStageDateBooking
            objBEAccomStageDateBooking.AccomRouteStageId = intAccomStageId
            Dim intAffectedRow1 As Integer = (New clsDLAccomStageDateBooking().DeleteAccomStageDateBookingByAccomRouteStageId(objBEAccomStageDateBooking))

            Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
            objBEAccomStageRoom.AccomStageId = intAccomStageId
            Dim intAffectedRow2 As Integer = (New clsDLAccomStageRoom().DeleteAccomStageRoomByAccomStageId(objBEAccomStageRoom))

            If intAffectedRow > 0 Then
                'Add(Activity - Start)
                'Dim objBEActivity As New clsBEActivity

                'objBEActivity.Descx = objFunction.ReturnString(GRID_All_Booking_Stages.DataKeys(e.RowIndex).Values("AccomName")) + " had been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                'objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                'Dim objDLActivity As New clsDLActivity
                'objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Accom stage has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_All_Booking_Stages.EditIndex = -1
            'BindAllBookingStageGridview()
            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to set accom value
    ''' </summary>
    Public Function SetAccomValue(ByVal value As Object) As String
        Try
            If objFunction.ReturnString(value) = "" Then
                Return "No Accomodation Selected"
            Else
                Return value
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return ""
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

    ''' <summary>
    ''' This event is used to add accom stage room detail in all stage
    ''' </summary>
    Protected Sub BUT_Add_Room_All_Stages_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Room_All_Stages.Click
        Try
            Dim intBookingId = objFunction.ReturnInteger(Session("BookingId"))
            Dim intAccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
            Dim objDLAccomStageRoom As clsDLAccomStageRoom = New clsDLAccomStageRoom

            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            Dim objDLAccomRouteStage As clsDLAccomRouteStage = New clsDLAccomRouteStage
            objBEAccomRouteStage.BookingId = intBookingId
            Dim dstAccomRouteStageDetail As DataSet = objDLAccomRouteStage.GetAccomRouteStageByBookingId(objBEAccomRouteStage, intCompanyId)

            Dim intAccomStageRoomId As Integer = 0

            Dim rbVal As String = Request.Form("rb_Room_Select")
            Dim tmpRbVal As String() = rbVal.Split("^")
            Dim intRoomTypeId As Integer = objFunction.ReturnInteger(tmpRbVal(0))

            If objFunction.CheckDataSet(dstAccomRouteStageDetail) Then

                For i = 0 To dstAccomRouteStageDetail.Tables(0).Rows.Count - 1
                    If objFunction.ReturnInteger(dstAccomRouteStageDetail.Tables(0).Rows(i)("accomodation_id")) > 0 Then

                        Dim dstAccomRoomTypeDetail As DataSet = (New clsDLAccomRooms()).GetRoomTypeByAccomIdAndRoomTypeId(objFunction.ReturnInteger(dstAccomRouteStageDetail.Tables(0).Rows(i)("accomodation_id")), objFunction.ReturnInteger(tmpRbVal(1)))

                        If objFunction.CheckDataSet(dstAccomRoomTypeDetail) Then

                            For index = 1 To objFunction.ReturnInteger(DROP_No_of_Rooms.SelectedItem.Value)

                                If objFunction.ReturnInteger(dstAccomRouteStageDetail.Tables(0).Rows(i)("id")) = intAccomStageId Then
                                    intAccomStageRoomId = AddAccomStageRoomDetail()
                                Else
                                    objBEAccomStageRoom.AccomRoomTypeId = objFunction.ReturnInteger(dstAccomRoomTypeDetail.Tables(0).Rows(0)("id"))
                                    objBEAccomStageRoom.AccomStageId = objFunction.ReturnInteger(dstAccomRouteStageDetail.Tables(0).Rows(i)("id"))
                                    objBEAccomStageRoom.NoMales = objFunction.ReturnInteger(TB_No_of_Males.Text)
                                    objBEAccomStageRoom.NoFemales = objFunction.ReturnInteger(TB_No_of_Females.Text)
                                    objBEAccomStageRoom.NoOfChildren = objFunction.ReturnInteger(TB_No_of_Children.Text)
                                    objBEAccomStageRoom.NoDogs = objFunction.ReturnInteger(TB_No_of_Dogs.Text)
                                    objBEAccomStageRoom.TotalCostDogs = objFunction.ReturnDouble(TB_Total_Cost_Dogs.Text)
                                    objBEAccomStageRoom.CostEasyway = objFunction.ReturnDouble(dstAccomRoomTypeDetail.Tables(0).Rows(0)("cost_easyways"))
                                    objBEAccomStageRoom.CostClient = objFunction.ReturnDouble(dstAccomRoomTypeDetail.Tables(0).Rows(0)("cost_client"))
                                    objBEAccomStageRoom.AdditionalNotes = TB_Additional_Notes.Text
                                    objBEAccomStageRoom.BookingId = objFunction.ReturnInteger(Session("BookingId"))

                                    intAccomStageRoomId = objDLAccomStageRoom.AddAccomStageRoomDetail(objBEAccomStageRoom)

                                    If intAccomStageRoomId > 0 Then

                                        Dim objBEAccomStageRoomOptions As clsBEAccomStageRoomOptions = New clsBEAccomStageRoomOptions

                                        Dim intHdnRoomOptionCount As Integer = Request.Form("hdnRoomOptionCount_" + objFunction.ReturnString(intRoomTypeId))
                                        Trace.Warn("intHdnRoomOptionCount = " + objFunction.ReturnString(intHdnRoomOptionCount))
                                        If objFunction.ReturnInteger(intHdnRoomOptionCount) > 0 Then
                                            For j = 0 To objFunction.ReturnInteger(intHdnRoomOptionCount) - 1
                                                'Dim intCheckBoxValue As Integer = objFunction.ReturnInteger(Request.Form("CHKBOXLIST_Room_Options_" + objFunction.ReturnString(intRoomTypeId) + "_" + objFunction.ReturnString(j)))
                                                Dim chkVal As String = Request.Form("CHKBOXLIST_Room_Options_" + objFunction.ReturnString(intRoomTypeId) + "_" + objFunction.ReturnString(j))

                                                If objFunction.ReturnString(chkVal) <> "" Then
                                                    Dim tmpChkVal As String() = chkVal.Split("^")
                                                    Dim intCheckBoxValue As Integer = objFunction.ReturnInteger(tmpChkVal(0))
                                                    If intCheckBoxValue > 0 Then

                                                        Dim objBERoomTypeOptions As clsBERoomTypeOptions = New clsBERoomTypeOptions
                                                        objBERoomTypeOptions.RoomTypeOptionsId = objFunction.ReturnInteger(dstAccomRoomTypeDetail.Tables(0).Rows(0)("id"))
                                                        objBERoomTypeOptions.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                                                        Dim dstRoomtypeOptionsDesc As DataSet = (New clsDLRoomTypeOptions()).GetRoomTypeOptionsByIdFillInDD(objBERoomTypeOptions)

                                                        If objFunction.CheckDataSet(dstRoomtypeOptionsDesc) Then

                                                            Dim dtData As DataTable = dstRoomtypeOptionsDesc.Tables(0)
                                                            dtData.DefaultView.RowFilter = "AoomtypeOptionsDescId = " + tmpChkVal(1)
                                                            Dim dtDataTemp As DataTable = dtData.DefaultView.ToTable()

                                                            If objFunction.CheckDataTable(dtDataTemp) Then
                                                                objBEAccomStageRoomOptions.AccomStageRoomId = intAccomStageRoomId
                                                                objBEAccomStageRoomOptions.RoomTypeOptionId = objFunction.ReturnInteger(dtDataTemp.Rows(0)("ID"))
                                                                Dim intAffectedRow = (New clsDLAccomStageRoomOptions()).AddAccomStageRoomOptionsDetail(objBEAccomStageRoomOptions)
                                                            End If

                                                        End If

                                                    End If
                                                    Trace.Warn("checkbox val = " + objFunction.ReturnString(Request.Form("CHKBOXLIST_Room_Options_" + objFunction.ReturnString(intRoomTypeId) + "_" + objFunction.ReturnString(j))))
                                                End If
                                            Next
                                        End If

                                    End If
                                End If

                            Next

                        End If
                    End If
                Next
            End If

            If intAccomStageRoomId > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Room has been added to all stages"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If

            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to update supplier note by accom_stage_id.
    ''' </summary>
    Protected Sub BUT_Add_Note_to_Supplier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Note_to_Supplier.Click
        Try
            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            objBEAccomRouteStage.SupplierNote = TB_Note_to_Supplier.Text
            Dim intAffectedRow As Integer = (New clsDLAccomRouteStage()).UpdateSupplierNoteById(objBEAccomRouteStage)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Supplier Note has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to update client note by accom_stage_id.
    ''' </summary>
    Protected Sub BUT_Add_Note_Client_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Note_Client.Click
        Try
            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            objBEAccomRouteStage.ClientNote = TB_Client_Note_URL.Text
            Dim intAffectedRow As Integer = (New clsDLAccomRouteStage()).UpdateClientNoteById(objBEAccomRouteStage)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Client Note has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to update invoice note by accom_stage_id.
    ''' </summary>
    Protected Sub BUT_Add_Note_Invoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Note_Invoice.Click
        Try
            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.AccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            objBEAccomRouteStage.InvoiceNote = TB_Client_Note_invoice.Text
            Dim intAffectedRow As Integer = (New clsDLAccomRouteStage()).UpdateInvoiceNoteById(objBEAccomRouteStage)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Invoice Note has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to move on previous stage.
    ''' </summary>
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim dtAccomRouteStage As DataTable = DirectCast(ViewState("VS_AccomRouteStage"), DataTable)
            If objFunction.CheckDataTable(dtAccomRouteStage) Then
                dtAccomRouteStage.DefaultView.RowFilter = "seq = " + objFunction.ReturnString(objFunction.ReturnInteger(Session("AccomStageSeq")) - 1)
                Dim dtDataTemp As DataTable = dtAccomRouteStage.DefaultView.ToTable()
                If objFunction.CheckDataTable(dtDataTemp) Then
                    Session("AccomStageId") = objFunction.ReturnString(dtDataTemp.Rows(0)("id"))
                    Session("AccomStageSeq") = objFunction.ReturnString(dtDataTemp.Rows(0)("seq"))
                End If
            End If
            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to move on next stage.
    ''' </summary>
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim dtAccomRouteStage As DataTable = DirectCast(ViewState("VS_AccomRouteStage"), DataTable)
            If objFunction.CheckDataTable(dtAccomRouteStage) Then
                dtAccomRouteStage.DefaultView.RowFilter = "seq = " + objFunction.ReturnString(objFunction.ReturnInteger(Session("AccomStageSeq")) + 1)
                Dim dtDataTemp As DataTable = dtAccomRouteStage.DefaultView.ToTable()
                If objFunction.CheckDataTable(dtDataTemp) Then
                    Session("AccomStageId") = objFunction.ReturnString(dtDataTemp.Rows(0)("id"))
                    Session("AccomStageSeq") = objFunction.ReturnString(dtDataTemp.Rows(0)("seq"))
                End If
            End If
            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class