Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class accom_room_view
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEAccomRooms As clsBEAccomRooms = New clsBEAccomRooms
    Dim objDLAccomRooms As clsDLAccomRooms = New clsDLAccomRooms

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

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstAccomodation As DataSet = (New clsDLAccomodation()).GetAccommodationDetailFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Accommodation, dstAccomodation)
                DROP_Accommodation.Items.Insert(0, New ListItem("Select Accommodation", ""))

                If Session("SelectedAccomId") <> Nothing And objFunction.ReturnInteger(Session("SelectedAccomId")) > 0 Then
                    DROP_Accommodation.SelectedValue = objFunction.ReturnInteger(Session("SelectedAccomId"))
                    Session("SelectedAccomId") = Nothing
                    BindAccomRoomsGridview()
                End If

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    
    ''' <summary>
    ''' SelectedIndexChanged event of deropdown
    ''' </summary>
    Protected Sub DROP_Accommodation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Accommodation.SelectedIndexChanged

        Try
            Session("SelectedAccomId") = objFunction.ReturnString(DROP_Accommodation.SelectedItem.Value)
            BindAccomRoomsGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind room gridview
    ''' </summary>
    Protected Sub BindAccomRoomsGridview()

        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim intAccomId = objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value)
            Dim dstRoomType As DataSet = (New clsDLAccomRooms()).GetRoomTypeByAccomId(intAccomId)
            GRID_Accom_Rooms.DataSource = dstRoomType
            GRID_Accom_Rooms.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GRID_Accom_Rooms
    ''' </summary>
    Protected Sub GRID_Accom_Rooms_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

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
    ''' RowEditing event of the GRID_Accom_Rooms
    ''' </summary>
    Protected Sub GRID_Accom_Rooms_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

        Try
            GRID_Accom_Rooms.EditIndex = e.NewEditIndex
            BindAccomRoomsGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowCancelingEdit event of the GRID_Accom_Rooms
    ''' </summary>
    Protected Sub GRID_Accom_Rooms_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)

        Try
            GRID_Accom_Rooms.EditIndex = -1
            BindAccomRoomsGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Accom_Rooms
    ''' </summary>
    Protected Sub GRID_Accom_Rooms_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Accom_Rooms.PageIndex = e.NewPageIndex
            BindAccomRoomsGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowUpdating event of the GRID_Accom_Rooms
    ''' </summary>
    Protected Sub GRID_Accom_Rooms_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GRID_Accom_Rooms.DataKeys(e.RowIndex).Values("id")))
            Dim txtCostEasyways As TextBox = DirectCast(GRID_Accom_Rooms.Rows(e.RowIndex).FindControl("TB_CostEasyways"), TextBox)
            Dim txtCostClient As TextBox = DirectCast(GRID_Accom_Rooms.Rows(e.RowIndex).FindControl("TB_CostClient"), TextBox)
            
            objBEAccomRooms.AccomRoomTypeId = id
            objBEAccomRooms.CostEasyway = objFunction.ReturnDouble(txtCostEasyways.Text)
            objBEAccomRooms.CostClient = objFunction.ReturnDouble(txtCostClient.Text)

            Dim intAffectedRow As Integer = objDLAccomRooms.UpdateAccomRoomTypeDetails(objBEAccomRooms)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "A room in " + objFunction.ReturnString(DROP_Accommodation.SelectedItem.Text) + " had been updated by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End

                Session("feedback_call") = "1"
                Session("error_msg") = "Room has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_Accom_Rooms.EditIndex = -1
            'BindAccomRoomsGridview()
            Session("SelectedAccomId") = objFunction.ReturnString(DROP_Accommodation.SelectedItem.Value)
            Response.Redirect("accom_room_view.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GRID_Accom_Rooms
    ''' </summary>
    Protected Sub GRID_Accom_Rooms_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            objBEAccomRooms.AccomRoomTypeId = objFunction.ReturnInteger(GRID_Accom_Rooms.DataKeys(e.RowIndex).Values("id").ToString())
            Dim intAffectedRow As Integer = objDLAccomRooms.DeleteAccomRoomType(objBEAccomRooms)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "A room in " + objFunction.ReturnString(DROP_Accommodation.SelectedItem.Text) + " had been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Room has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_Accom_Rooms.EditIndex = -1
            'BindAccomRoomsGridview()
            Response.Redirect("accom_room_view.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class





