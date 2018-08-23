Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class booking_options_route_stages
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBERouteStage As clsBERouteStage = New clsBERouteStage
    Dim objDLRouteStage As clsDLRouteStage = New clsDLRouteStage

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
                Dim dstRoute As DataSet = (New clsDLRoute()).GetRouteFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Route, dstRoute)
                DROP_Route.Items.Insert(0, New ListItem("Select Route", ""))

                Dim dstStage As DataSet = (New clsDLStages()).GetStagesFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Stage, dstStage)
                DROP_Stage.Items.Insert(0, New ListItem("Select Stage", ""))

                BindGridview()

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
            Dim dstRouteStage As New DataSet()
            dstRouteStage = (New clsDLRouteStage()).GetRouteStage(intCompanyId)
            GridView1.DataSource = dstRouteStage
            GridView1.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GridView1
    ''' </summary>
    Protected Sub GridView1_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lb As LinkButton = DirectCast(e.Row.Cells(4).Controls(2), LinkButton)
                If lb IsNot Nothing Then
                    If lb.Text = "Delete" Then
                        lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
                    End If
                End If

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim ddlRoute = DirectCast(e.Row.FindControl("DROP_GridRoute"), DropDownList)
                Dim dstRoute As DataSet = (New clsDLRoute()).GetRouteFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(ddlRoute, dstRoute)
                ddlRoute.Items.Insert(0, New ListItem("Select Route", ""))
                ddlRoute.Items.FindByValue(TryCast(e.Row.FindControl("hdnRouteId"), HiddenField).Value).Selected = True

                Dim ddlStage = DirectCast(e.Row.FindControl("DROP_GridStage"), DropDownList)
                Dim dstStage As DataSet = (New clsDLStages()).GetStagesFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(ddlStage, dstStage)
                ddlStage.Items.Insert(0, New ListItem("Select Stage", ""))
                ddlStage.Items.FindByValue(TryCast(e.Row.FindControl("hdnStageId"), HiddenField).Value).Selected = True
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowEditing event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

        Try
            GridView1.EditIndex = e.NewEditIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowCancelingEdit event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)

        Try
            GridView1.EditIndex = -1
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GridView1
    ''' </summary>
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GridView1.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowUpdating event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("id")))
            Dim ddlRouteId As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("DROP_GridRoute"), DropDownList)
            Dim ddlStageId As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("DROP_GridStage"), DropDownList)
            Dim txtRouteSequence As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_RouteSequence"), TextBox)

            If IsNumeric(txtRouteSequence.Text) Then
                objBERouteStage.RouteStageId = id
                objBERouteStage.RouteId = objFunction.ReturnInteger(ddlRouteId.SelectedItem.Value)
                objBERouteStage.StageId = objFunction.ReturnInteger(ddlStageId.SelectedItem.Value)
                objBERouteStage.RouteSequence = objFunction.ReturnInteger(txtRouteSequence.Text)

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstCheckDuplicateRecord As DataSet = objDLRouteStage.CheckDuplicateRecord(objBERouteStage, intCompanyId)

                If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                    Session("feedback_call") = "2"
                    Session("error_msg") = "WARNING - New stage within route has NOT been added - please check the sequence number entered"
                Else
                    Dim intAffectedRow As Integer = objDLRouteStage.PerformGridViewOpertaion("UPDATE", objBERouteStage)
                    If intAffectedRow > 0 Then
                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        objBEActivity.Descx = ddlStageId.SelectedItem.Text + "-" + ddlRouteId.SelectedItem.Text + " has been amended by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "Stage within route has been amended"
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "Please enter numerical values. No records has been added"
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("booking_options_route_stages.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            objBERouteStage.RouteStageId = objFunction.ReturnInteger(GridView1.DataKeys(e.RowIndex).Values("id").ToString())
            Dim strStageName As String = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("stagename"))
            Dim strRouteName As String = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("routename"))
            Dim intAffectedRow As Integer = objDLRouteStage.PerformGridViewOpertaion("DELETE", objBERouteStage)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "Booking fee has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.Descx = strStageName + "-" + strRouteName + " has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Stage within route has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("booking_options_route_stages.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add routestage details
    ''' </summary>
    Protected Sub BUT_Add_New_Route_Stage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_New_Route_Stage.Click
        Try
            If IsNumeric(TB_Bookings_Sequence__In_Route.Text) Then
                objBERouteStage.RouteId = objFunction.ReturnInteger(DROP_Route.SelectedItem.Value)
                objBERouteStage.StageId = objFunction.ReturnInteger(DROP_Stage.SelectedItem.Value)
                objBERouteStage.RouteSequence = objFunction.ReturnInteger(TB_Bookings_Sequence__In_Route.Text)

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstCheckDuplicateRecord As DataSet = objDLRouteStage.CheckDuplicateRecord(objBERouteStage, intCompanyId)

                If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                    Session("feedback_call") = "2"
                    Session("error_msg") = "WARNING - New stage within route has NOT been added - please check the sequence number entered"
                Else
                    Dim intAffectedRow As Integer = objDLRouteStage.AddRouteStage(objBERouteStage)
                    If intAffectedRow > 0 Then
                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        objBEActivity.Descx = DROP_Stage.SelectedItem.Text + "-" + DROP_Route.SelectedItem.Text + " has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "New stage within route has been added"
                        TB_Bookings_Sequence__In_Route.Text = ""
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "Please enter numerical values. No records has been added"
            End If
            Response.Redirect("booking_options_route_stages.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





