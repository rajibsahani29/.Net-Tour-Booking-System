Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_additional_info
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEAdditionalNames As clsBEAdditionalNames = New clsBEAdditionalNames
    Dim objDLAdditionalNames As clsDLAdditionalNames = New clsDLAdditionalNames

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

                Dim objBEDietaryNeedsBooking As clsBEDietaryNeedsBooking = New clsBEDietaryNeedsBooking
                objBEDietaryNeedsBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                Dim dstDietaryNeedsBooking As DataSet = (New clsDLDietaryNeedsBooking()).GetDietaryNeedsBookingByBookingId(objBEDietaryNeedsBooking)
                If objFunction.CheckDataSet(dstDietaryNeedsBooking) Then
                    TB_Dietary_Needs_Main_Person.Text = objFunction.ReturnString(dstDietaryNeedsBooking.Tables(0).Rows(0)("dietaryneeds"))
                End If

                Dim dstSex As DataSet = (New clsDLSex()).GetSexFillInDD()
                objFunction.FillDropDownByDataSet(DROP_Gender, dstSex)
                DROP_Gender.Items.Insert(0, New ListItem("Select Gender", "0"))

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

                Dim objBEVoluntaryPayment As clsBEVoluntaryPayment = New clsBEVoluntaryPayment
                objBEVoluntaryPayment.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                Dim dstVoluntaryPayment As DataSet = (New clsDLVoluntaryPayment()).GetVoluntaryPaymentByBookingId(objBEVoluntaryPayment)
                If objFunction.CheckDataSet(dstVoluntaryPayment) Then
                    TB_Voluntary_Contribution.Text = objFunction.ReturnString(dstVoluntaryPayment.Tables(0).Rows(0)("amt"))
                Else
                    'TB_Voluntary_Contribution.Text = (objFunction.ReturnDouble(dstBookingDetail.Tables(0).Rows(0)("total_num")) * 5).ToString("0.00")
                    TB_Voluntary_Contribution.Text = "0"
                End If
                'TB_Voluntary_Contribution.Text = (objFunction.ReturnDouble(dstBookingDetail.Tables(0).Rows(0)("total_num")) * 5).ToString("0.00")

                TB_Agent_Ref.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("agent_ref"))

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
            Dim dstAdditionalNames As New DataSet()
            objBEAdditionalNames.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            dstAdditionalNames = (New clsDLAdditionalNames()).GetAdditionalNamesByBookingId(objBEAdditionalNames)
            GRID_Bookings_Additional_People.DataSource = dstAdditionalNames
            GRID_Bookings_Additional_People.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GRID_Bookings_Additional_People
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_People_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lb As LinkButton = DirectCast(e.Row.Cells(3).Controls(2), LinkButton)
                If lb IsNot Nothing Then
                    If lb.Text = "Delete" Then
                        lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
                    End If
                End If

                Dim dstSex As DataSet = (New clsDLSex()).GetSexFillInDD()
                Dim ddlGender = DirectCast(e.Row.FindControl("DROP_GridGender"), DropDownList)
                If Not ddlGender Is Nothing Then
                    objFunction.FillDropDownByDataSet(ddlGender, dstSex)
                    ddlGender.Items.Insert(0, New ListItem("Select Gender", "0"))
                    ddlGender.Items.FindByValue(TryCast(e.Row.FindControl("hdnGenderId"), HiddenField).Value).Selected = True
                End If
                
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowEditing event of the GRID_Bookings_Additional_People
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_People_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

        Try
            GRID_Bookings_Additional_People.EditIndex = e.NewEditIndex
            BindGridview()
            hdnAccordianStatus.Value = "two"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowCancelingEdit event of the GRID_Bookings_Additional_People
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_People_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)

        Try
            GRID_Bookings_Additional_People.EditIndex = -1
            BindGridview()
            hdnAccordianStatus.Value = "two"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Bookings_Additional_People
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_People_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Bookings_Additional_People.PageIndex = e.NewPageIndex
            BindGridview()
            hdnAccordianStatus.Value = "two"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowUpdating event of the GRID_Bookings_Additional_People
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_People_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GRID_Bookings_Additional_People.DataKeys(e.RowIndex).Values("id")))
            Dim txtName As TextBox = DirectCast(GRID_Bookings_Additional_People.Rows(e.RowIndex).FindControl("TB_Name"), TextBox)
            Dim ddlGender As DropDownList = DirectCast(GRID_Bookings_Additional_People.Rows(e.RowIndex).FindControl("DROP_GridGender"), DropDownList)
            Dim txtDietaryNeeds As TextBox = DirectCast(GRID_Bookings_Additional_People.Rows(e.RowIndex).FindControl("TB_DietaryNeeds"), TextBox)

            If txtName.Text <> "" And objFunction.ReturnInteger(ddlGender.SelectedItem.Value) Then

                objBEAdditionalNames.AdditionalNamesId = id
                objBEAdditionalNames.Name = txtName.Text
                objBEAdditionalNames.SexId = objFunction.ReturnInteger(ddlGender.SelectedItem.Value)
                objBEAdditionalNames.DietaryNeeds = txtDietaryNeeds.Text
                
                Dim intAffectedRow As Integer = objDLAdditionalNames.PerformGridViewOpertaion("UPDATE", objBEAdditionalNames)
                If intAffectedRow > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Booking additional name has been amended"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If

            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check entries"
            End If
            GRID_Bookings_Additional_People.EditIndex = -1
            'BindGridview()
            Response.Redirect("bookings_additional_info.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GRID_Bookings_Additional_People
    ''' </summary>
    Protected Sub GRID_Bookings_Additional_People_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            objBEAdditionalNames.AdditionalNamesId = objFunction.ReturnInteger(GRID_Bookings_Additional_People.DataKeys(e.RowIndex).Values("id").ToString())
            Dim intAffectedRow As Integer = objDLAdditionalNames.PerformGridViewOpertaion("DELETE", objBEAdditionalNames)
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Booking additional name has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_Bookings_Additional_People.EditIndex = -1
            'BindGridview()
            Response.Redirect("bookings_additional_info.aspx", False)
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
    ''' This event is used to add/update additional info
    ''' </summary>
    Protected Sub BUT_Update_Additional_Info_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Update_Additional_Info.Click

        Try
            If IsNumeric(TB_Voluntary_Contribution.Text) Then
                Dim intAffectedRow As Integer = 0
                Dim objBEDietaryNeedsBooking As clsBEDietaryNeedsBooking = New clsBEDietaryNeedsBooking
                Dim objDLDietaryNeedsBooking As clsDLDietaryNeedsBooking = New clsDLDietaryNeedsBooking
                objBEDietaryNeedsBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                Dim dstCheckDietaryNeedsBooking As DataSet = objDLDietaryNeedsBooking.GetDietaryNeedsBookingByBookingId(objBEDietaryNeedsBooking)
                If objFunction.CheckDataSet(dstCheckDietaryNeedsBooking) Then
                    objBEDietaryNeedsBooking.DietaryNeeds = TB_Dietary_Needs_Main_Person.Text
                    intAffectedRow = objDLDietaryNeedsBooking.UpdateDietaryNeedsBookingByBookingId(objBEDietaryNeedsBooking)
                Else
                    objBEDietaryNeedsBooking.DietaryNeeds = TB_Dietary_Needs_Main_Person.Text
                    intAffectedRow = objDLDietaryNeedsBooking.AddDietaryNeedsBooking(objBEDietaryNeedsBooking)
                End If

                Dim objBEVoluntaryPayment As clsBEVoluntaryPayment = New clsBEVoluntaryPayment
                Dim objDLVoluntaryPayment As clsDLVoluntaryPayment = New clsDLVoluntaryPayment
                objBEVoluntaryPayment.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                Dim dstCheckVoluntaryPayment As DataSet = objDLVoluntaryPayment.GetVoluntaryPaymentByBookingId(objBEVoluntaryPayment)
                If objFunction.CheckDataSet(dstCheckVoluntaryPayment) Then
                    objBEVoluntaryPayment.Amount = objFunction.ReturnDouble(TB_Voluntary_Contribution.Text)
                    objBEVoluntaryPayment.Paid = False
                    intAffectedRow = objDLVoluntaryPayment.UpdateVoluntaryPaymentByBookingId(objBEVoluntaryPayment)
                Else
                    objBEVoluntaryPayment.Amount = objFunction.ReturnDouble(TB_Voluntary_Contribution.Text)
                    objBEVoluntaryPayment.Paid = False
                    intAffectedRow = objDLVoluntaryPayment.AddVoluntaryPayment(objBEVoluntaryPayment)
                End If

                Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEClientBooking.AgentRef = TB_Agent_Ref.Text
                intAffectedRow = (New clsDLClientBooking()).UpdateAgentRefByBookingId(objBEClientBooking)
                
                If intAffectedRow > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Booking additional info has been amended"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If

            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the costing entries"
            End If
            Response.Redirect("bookings_additional_info.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add additional people
    ''' </summary>
    Protected Sub BUT_Add_Additional_Person_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Additional_Person.Click

        Try
            If TB_Additional_Name.Text <> "" And objFunction.ReturnInteger(DROP_Gender.SelectedItem.Value) Then

                objBEAdditionalNames.Name = TB_Additional_Name.Text
                objBEAdditionalNames.SexId = objFunction.ReturnInteger(DROP_Gender.SelectedItem.Value)
                objBEAdditionalNames.DietaryNeeds = TB_Dietary_Needs_Extra.Text
                objBEAdditionalNames.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                
                Dim intAffectedRow As Integer = objDLAdditionalNames.AddAdditionalNames(objBEAdditionalNames)
                If intAffectedRow > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Booking additional name has been added"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check entries"
            End If
            Response.Redirect("bookings_additional_info.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub
End Class





