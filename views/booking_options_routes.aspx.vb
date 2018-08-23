Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class booking_options_routes
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBERoute As clsBERoute = New clsBERoute
    Dim objDLRoute As clsDLRoute = New clsDLRoute

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
            Dim dstRoute As New DataSet()
            dstRoute = (New clsDLRoute()).GetRoute(intCompanyId)
            GridView1.DataSource = dstRoute
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
            Dim txtName As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_Name"), TextBox)
            'Dim txtCostEw As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_CostEw"), TextBox)
            Dim txtCostClient As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_CostClient"), TextBox)
            Dim txtDocLink As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_DocLink"), TextBox)
            Dim txtSingleSupplement As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_SingleSupplement"), TextBox)
            Dim txtRouteCode As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_RouteCode"), TextBox)
            Dim txtCostGuideBook As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_CostGuideBook"), TextBox)
            Dim txtExternalLink1 As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_ExternalLink1"), TextBox)
            Dim txtExternalLink2 As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_ExternalLink2"), TextBox)
            Dim txtMapLink As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_MapLink"), TextBox)

            If IsNumeric(txtCostClient.Text) And IsNumeric(txtSingleSupplement.Text) Then
                objBERoute.RouteId = id
                objBERoute.Name = txtName.Text
                'objBERoute.CostEasyway = objFunction.ReturnDouble(txtCostEw.Text)
                objBERoute.CostClient = objFunction.ReturnDouble(txtCostClient.Text)
                objBERoute.DocLink = txtDocLink.Text
                objBERoute.SingleSupplement = txtSingleSupplement.Text
                objBERoute.Codex = txtRouteCode.Text
                objBERoute.CostGuideBook = objFunction.ReturnDouble(txtCostGuideBook.Text)
                objBERoute.ExternalLink1 = txtExternalLink1.Text
                objBERoute.ExternalLink2 = txtExternalLink2.Text
                objBERoute.MapLink = txtMapLink.Text

                Dim intAffectedRow As Integer = objDLRoute.PerformGridViewOpertaion("UPDATE", objBERoute)
                If intAffectedRow > 0 Then
                    'Add Activity - Start
                    Dim objBEActivity As New clsBEActivity
                    objBEActivity.Descx = objBERoute.Name + " has been amended by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                    objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                    Dim objDLActivity As New clsDLActivity
                    objDLActivity.AddActivity(objBEActivity)
                    'Add Activity - End
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Route has been amended"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the costing entries"
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("booking_options_routes.aspx", False)
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
            objBERoute.RouteId = objFunction.ReturnInteger(GridView1.DataKeys(e.RowIndex).Values("id").ToString())
            objBERoute.Name = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("name"))
            Dim intAffectedRow As Integer = objDLRoute.PerformGridViewOpertaion("DELETE", objBERoute)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objBERoute.Name + " has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Route has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("booking_options_routes.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add routes detail
    ''' </summary>
    Protected Sub BUT_Add_New_Route_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_New_Route.Click
        Try
            If IsNumeric(TB_Booking_Cost_Client.Text) And IsNumeric(TB_Single_Supplement.Text) Then
                objBERoute.Name = TB_Booking_Route_Name.Text
                objBERoute.CostEasyway = objFunction.ReturnDouble(TB_Booking_Cost_Ew.Text)
                objBERoute.CostClient = objFunction.ReturnDouble(TB_Booking_Cost_Client.Text)
                objBERoute.DocLink = TB_Bookings_Link_Info_Leaflet.Text
                objBERoute.SingleSupplement = objFunction.ReturnDouble(TB_Single_Supplement.Text)
                objBERoute.Codex = TB_Booking_Route_Code.Text
                objBERoute.CompanyId = objFunction.ReturnString(Session("CompanyId"))
                objBERoute.CostGuideBook = objFunction.ReturnDouble(TB_EW_Cost_Guidebooks.Text)
                objBERoute.ExternalLink1 = TB_Link_Highlands_Page.Text
                objBERoute.ExternalLink2 = TB_Official_Walk_Page.Text
                objBERoute.MapLink = TB_Map_Link.Text

                Dim intAffectedRow As Integer = objDLRoute.AddRoute(objBERoute)
                If intAffectedRow > 0 Then
                    'Add Activity - Start
                    Dim objBEActivity As New clsBEActivity
                    objBEActivity.Descx = objBERoute.Name + " has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                    objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                    Dim objDLActivity As New clsDLActivity
                    objDLActivity.AddActivity(objBEActivity)
                    'Add Activity - End
                    Session("feedback_call") = "1"
                    Session("error_msg") = "New route has been added"
                    TB_Booking_Route_Name.Text = ""
                    TB_Booking_Cost_Ew.Text = ""
                    TB_Booking_Cost_Client.Text = ""
                    TB_Bookings_Link_Info_Leaflet.Text = ""
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the costing entries"
            End If
            Response.Redirect("booking_options_routes.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





