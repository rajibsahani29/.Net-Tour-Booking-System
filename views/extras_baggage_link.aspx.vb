Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class extras_baggage_link
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEExtrasBaggageLinkRoute As clsBEExtrasBaggageLinkRoute = New clsBEExtrasBaggageLinkRoute
    Dim objDLExtrasBaggageLinkRoute As clsDLExtrasBaggageLinkRoute = New clsDLExtrasBaggageLinkRoute

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

                Dim dstExtra As DataSet = (New clsDLExtra()).GetExtraDetailByExtraTypeIdFillInDD(15, intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Baggage_Service, dstExtra)
                DROP_Baggage_Service.Items.Insert(0, New ListItem("Select Baggage Service", ""))

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
            Dim dstExtrasBaggageLinkRoute As New DataSet()
            dstExtrasBaggageLinkRoute = (New clsDLExtrasBaggageLinkRoute()).GetExtrasBaggageLinkRoute(intCompanyId)
            GridView1.DataSource = dstExtrasBaggageLinkRoute
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
                Dim lb As LinkButton = DirectCast(e.Row.Cells(6).Controls(2), LinkButton)
                If lb IsNot Nothing Then
                    If lb.Text = "Delete" Then
                        lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
                    End If
                End If

                Dim intCompanyId As Integer = objFunction.ReturnInteger(Session("CompanyId"))

                Dim dstRoute As DataSet = (New clsDLRoute()).GetRouteFillInDD(intCompanyId)
                Dim ddlRoute = DirectCast(e.Row.FindControl("DROP_Route"), DropDownList)
                objFunction.FillDropDownByDataSet(ddlRoute, dstRoute)
                ddlRoute.Items.Insert(0, New ListItem("Select Route", ""))
                ddlRoute.Items.FindByValue(TryCast(e.Row.FindControl("hdnRoute"), HiddenField).Value).Selected = True

                Dim dstExtra As DataSet = (New clsDLExtra()).GetExtraDetailByExtraTypeIdFillInDD(15, intCompanyId)
                Dim ddlBaggageService = DirectCast(e.Row.FindControl("DROP_BaggageService"), DropDownList)
                objFunction.FillDropDownByDataSet(ddlBaggageService, dstExtra)
                ddlBaggageService.Items.Insert(0, New ListItem("Select Baggage Service", ""))
                ddlBaggageService.Items.FindByValue(TryCast(e.Row.FindControl("hdnBaggageService"), HiddenField).Value).Selected = True

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
            Dim ddlRoute As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("DROP_Route"), DropDownList)
            Dim ddlBaggageService As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("DROP_BaggageService"), DropDownList)
            Dim txtCostEw As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_CostEw"), TextBox)
            Dim txtCostClient As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_CostClient"), TextBox)
            Dim txtAddInfo As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_AddInfo"), TextBox)

            Dim hdnRoute As HiddenField = DirectCast(GridView1.Rows(e.RowIndex).FindControl("hdnRoute"), HiddenField)
            Dim hdnBaggageService As HiddenField = DirectCast(GridView1.Rows(e.RowIndex).FindControl("hdnBaggageService"), HiddenField)

            If IsNumeric(txtCostEw.Text) And IsNumeric(txtCostClient.Text) Then
                objBEExtrasBaggageLinkRoute.ExtrasBaggageLinkRouteId = id
                objBEExtrasBaggageLinkRoute.RouteId = objFunction.ReturnInteger(ddlRoute.SelectedItem.Value)
                objBEExtrasBaggageLinkRoute.ExtraId = objFunction.ReturnInteger(ddlBaggageService.SelectedItem.Value)
                objBEExtrasBaggageLinkRoute.CostEasyway = objFunction.ReturnDouble(txtCostEw.Text)
                objBEExtrasBaggageLinkRoute.CostClient = objFunction.ReturnDouble(txtCostClient.Text)
                objBEExtrasBaggageLinkRoute.AdditionalNotes = txtAddInfo.Text

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim blnDuplicateRecStatus As Boolean = False
                If hdnRoute.Value <> ddlRoute.SelectedItem.Value Or hdnBaggageService.Value <> ddlBaggageService.SelectedItem.Value Then
                    Dim dstCheckDuplicateRecord As DataSet = objDLExtrasBaggageLinkRoute.CheckDuplicateRecord(objBEExtrasBaggageLinkRoute, intCompanyId)
                    blnDuplicateRecStatus = objFunction.CheckDataSet(dstCheckDuplicateRecord)
                End If

                If blnDuplicateRecStatus Then
                    Session("feedback_call") = "2"
                    Session("error_msg") = "WARNING - Record was NOT updated - entry already in system"
                Else
                    Dim intAffectedRow As Integer = objDLExtrasBaggageLinkRoute.PerformGridViewOpertaion("UPDATE", objBEExtrasBaggageLinkRoute)
                    If intAffectedRow > 0 Then
                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        'objBEActivity.Descx = "Distance between " + DROP_Stage1.SelectedItem.Text + " and " + DROP_Stage2.SelectedItem.Text + " has been amended by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.Descx = ddlBaggageService.SelectedItem.Text + " has been amemded to " + ddlRoute.SelectedItem.Text + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "Baggage Link to a Route-Stage has been amended"
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT updated - please check the costing entries"
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("extras_baggage_link.aspx", False)
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
            objBEExtrasBaggageLinkRoute.ExtrasBaggageLinkRouteId = objFunction.ReturnInteger(GridView1.DataKeys(e.RowIndex).Values("id").ToString())
            Dim strRouteName As String = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("routename"))
            Dim strExtraServiceName As String = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("extraservicename"))
            Dim intAffectedRow As Integer = objDLExtrasBaggageLinkRoute.PerformGridViewOpertaion("DELETE", objBEExtrasBaggageLinkRoute)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                'objBEActivity.Descx = "Distance between " + strStageName1 + " and " + strStageName2 + " has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.Descx = strExtraServiceName + " has been deleted to " + strRouteName + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Baggage Link to a Route-Stage has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("extras_baggage_link.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add extra route stage details
    ''' </summary>
    Protected Sub BUT_Link_Baggage_to_Route_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Link_Baggage_to_Route.Click
        Try
            If IsNumeric(TB_Booking_Cost_Ew.Text) And IsNumeric(TB_Booking_Cost_Client.Text) Then
                objBEExtrasBaggageLinkRoute.RouteId = objFunction.ReturnInteger(DROP_Route.SelectedItem.Value)
                objBEExtrasBaggageLinkRoute.ExtraId = objFunction.ReturnInteger(DROP_Baggage_Service.SelectedItem.Value)
                objBEExtrasBaggageLinkRoute.CostEasyway = objFunction.ReturnDouble(TB_Booking_Cost_Ew.Text)
                objBEExtrasBaggageLinkRoute.CostClient = objFunction.ReturnDouble(TB_Booking_Cost_Client.Text)
                objBEExtrasBaggageLinkRoute.AdditionalNotes = TB_Info.Text

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstCheckDuplicateRecord As DataSet = objDLExtrasBaggageLinkRoute.CheckDuplicateRecord(objBEExtrasBaggageLinkRoute, intCompanyId)

                If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                    Session("feedback_call") = "2"
                    Session("error_msg") = "WARNING - Record was NOT added - entry already in system"
                Else
                    Dim intAffectedRow As Integer = objDLExtrasBaggageLinkRoute.AddExtrasBaggageLinkRoute(objBEExtrasBaggageLinkRoute)
                    If intAffectedRow > 0 Then
                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        objBEActivity.Descx = DROP_Baggage_Service.SelectedItem.Text + " has been added to " + DROP_Route.SelectedItem.Text + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "New Baggage Link to a Route-Stage has been added"
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the costing entries"
            End If
            Response.Redirect("extras_baggage_link.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class


