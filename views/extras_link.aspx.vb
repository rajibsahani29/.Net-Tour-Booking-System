Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class extras_link
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEExtraRouteStage As clsBEExtraRouteStage = New clsBEExtraRouteStage
    Dim objDLExtraRouteStage As clsDLExtraRouteStage = New clsDLExtraRouteStage

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
                Dim dstRouteStage As DataSet = (New clsDLRouteStage()).GetRouteStageByNameFillInDD(intCompanyId)

                objFunction.FillDropDownByDataSet(DROP_Route_Stage1, dstRouteStage)
                DROP_Route_Stage1.Items.Insert(0, New ListItem("Select Route Stage 1", ""))

                objFunction.FillDropDownByDataSet(DROP_Route_Stage2, dstRouteStage)
                DROP_Route_Stage2.Items.Insert(0, New ListItem("Select Route Stage 2", ""))

                Dim dstExtra As DataSet = (New clsDLExtra()).GetExtraDetailByNotInExtraTypeIdFillInDD(15, intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Extra_Service, dstExtra)
                DROP_Extra_Service.Items.Insert(0, New ListItem("Select Extra Service", ""))

                Dim dstRoute As DataSet = (New clsDLRoute()).GetRouteFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Route, dstRoute)
                DROP_Route.Items.Insert(0, New ListItem("Select Route", "0"))

                objFunction.FillDropDownByDataSet(DROP_Supplier, dstExtra)
                DROP_Supplier.Items.Insert(0, New ListItem("Select Extra Service Supplier", ""))

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
            Dim intRouteId As Integer = 0
            If objFunction.ReturnInteger(DROP_Route.SelectedItem.Value) > 0 Then
                intRouteId = objFunction.ReturnInteger(DROP_Route.SelectedItem.Value)
            End If

            Dim intExtraId As Integer = 0
            If objFunction.ReturnInteger(DROP_Supplier.SelectedItem.Value) > 0 Then
                intExtraId = objFunction.ReturnInteger(DROP_Supplier.SelectedItem.Value)
            End If

            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstExtraRouteStage As New DataSet()
            dstExtraRouteStage = (New clsDLExtraRouteStage()).GetExtraRouteStageByRouteId(intRouteId, intExtraId, intCompanyId, 15)
            GridView1.DataSource = dstExtraRouteStage
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
                Dim lb As LinkButton = DirectCast(e.Row.Cells(8).Controls(2), LinkButton)
                If lb IsNot Nothing Then
                    If lb.Text = "Delete" Then
                        lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
                    End If
                End If

                Dim intCompanyId As Integer = objFunction.ReturnInteger(Session("CompanyId"))
                'Dim dstRouteStage As DataSet = (New clsDLRouteStage()).GetRouteStageByNameFillInDD(intCompanyId)

                'Dim ddlRouteStage1 = DirectCast(e.Row.FindControl("DROP_RouteStage1"), DropDownList)
                'objFunction.FillDropDownByDataSet(ddlRouteStage1, dstRouteStage)
                'ddlRouteStage1.Items.Insert(0, New ListItem("Select Route Stage 1", ""))
                'ddlRouteStage1.Items.FindByValue(TryCast(e.Row.FindControl("hdnRouteStage1"), HiddenField).Value).Selected = True

                'Dim ddlRouteStage2 = DirectCast(e.Row.FindControl("DROP_RouteStage2"), DropDownList)
                'objFunction.FillDropDownByDataSet(ddlRouteStage2, dstRouteStage)
                'ddlRouteStage2.Items.Insert(0, New ListItem("Select Route Stage 2", ""))
                'ddlRouteStage2.Items.FindByValue(TryCast(e.Row.FindControl("hdnRouteStage2"), HiddenField).Value).Selected = True

                Dim dstExtra As DataSet = (New clsDLExtra()).GetExtraDetailByNotInExtraTypeIdFillInDD(15, intCompanyId)
                Dim ddlExtraService = DirectCast(e.Row.FindControl("DROP_ExtraService"), DropDownList)
                objFunction.FillDropDownByDataSet(ddlExtraService, dstExtra)
                ddlExtraService.Items.Insert(0, New ListItem("Select Extra Service", ""))
                ddlExtraService.Items.FindByValue(TryCast(e.Row.FindControl("hdnExtraService"), HiddenField).Value).Selected = True

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
            'Dim ddlRouteStage1 As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("DROP_RouteStage1"), DropDownList)
            'Dim ddlRouteStage2 As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("DROP_RouteStage2"), DropDownList)
            Dim ddlExtraService As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("DROP_ExtraService"), DropDownList)
            Dim txtCostEw As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_CostEw"), TextBox)
            Dim txtCostClient As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_CostClient"), TextBox)
            Dim txtAddInfo As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_AddInfo"), TextBox)

            Dim hdnRouteStage1 As HiddenField = DirectCast(GridView1.Rows(e.RowIndex).FindControl("hdnRouteStage1"), HiddenField)
            Dim hdnRouteStage2 As HiddenField = DirectCast(GridView1.Rows(e.RowIndex).FindControl("hdnRouteStage2"), HiddenField)
            Dim hdnExtraService As HiddenField = DirectCast(GridView1.Rows(e.RowIndex).FindControl("hdnExtraService"), HiddenField)

            If IsNumeric(txtCostEw.Text) And IsNumeric(txtCostClient.Text) Then
                objBEExtraRouteStage.ExtraRouteStageId = id
                objBEExtraRouteStage.RouteStageId1 = objFunction.ReturnInteger(hdnRouteStage1.Value)
                objBEExtraRouteStage.RouteStageId2 = objFunction.ReturnInteger(hdnRouteStage2.Value)
                objBEExtraRouteStage.ExtraId = objFunction.ReturnInteger(ddlExtraService.SelectedItem.Value)
                objBEExtraRouteStage.CostEasyway = objFunction.ReturnDouble(txtCostEw.Text)
                objBEExtraRouteStage.CostClient = objFunction.ReturnDouble(txtCostClient.Text)
                objBEExtraRouteStage.AdditionalNotes = txtAddInfo.Text

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim blnDuplicateRecStatus As Boolean = False
                If hdnExtraService.Value <> ddlExtraService.SelectedItem.Value Then
                    Dim dstCheckDuplicateRecord As DataSet = objDLExtraRouteStage.CheckDuplicateRecord(objBEExtraRouteStage, intCompanyId)
                    blnDuplicateRecStatus = objFunction.CheckDataSet(dstCheckDuplicateRecord)
                End If

                If blnDuplicateRecStatus Then
                    Session("feedback_call") = "2"
                    Session("error_msg") = "WARNING - Record was NOT updated - entry already in system"
                Else
                    Dim intAffectedRow As Integer = objDLExtraRouteStage.PerformGridViewOpertaion("UPDATE", objBEExtraRouteStage)
                    If intAffectedRow > 0 Then
                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        'objBEActivity.Descx = ddlExtraService.SelectedItem.Text + " has been amemded to " + ddlRouteStage1.SelectedItem.Text + " " + ddlRouteStage2.SelectedItem.Text + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.Descx = ddlExtraService.SelectedItem.Text + " has been amemded by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "Extra to Route-Stages has been amended"
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
            Response.Redirect("extras_link.aspx", False)
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
            objBEExtraRouteStage.ExtraRouteStageId = objFunction.ReturnInteger(GridView1.DataKeys(e.RowIndex).Values("id").ToString())
            'Dim strRouteStageName1 As String = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("routestagename1"))
            'Dim strRouteStageName2 As String = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("routestagename2"))
            Dim strExtraServiceName As String = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("extraservicename"))
            Dim intAffectedRow As Integer = objDLExtraRouteStage.PerformGridViewOpertaion("DELETE", objBEExtraRouteStage)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                'objBEActivity.Descx = "Distance between " + strStageName1 + " and " + strStageName2 + " has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                'objBEActivity.Descx = strExtraServiceName + " has been deleted to " + strRouteStageName1 + " " + strRouteStageName2 + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.Descx = strExtraServiceName + " has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Extra to Route-Stages has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("extras_link.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add extra route stage details
    ''' </summary>
    Protected Sub BUT_Add_Extra_Route_Stage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Extra_Route_Stage.Click
        Try
            If IsNumeric(TB_Booking_Cost_Ew.Text) And IsNumeric(TB_Booking_Cost_Client.Text) Then
                objBEExtraRouteStage.RouteStageId1 = objFunction.ReturnInteger(DROP_Route_Stage1.SelectedItem.Value)
                objBEExtraRouteStage.RouteStageId2 = objFunction.ReturnInteger(DROP_Route_Stage2.SelectedItem.Value)
                objBEExtraRouteStage.ExtraId = objFunction.ReturnInteger(DROP_Extra_Service.SelectedItem.Value)
                objBEExtraRouteStage.CostEasyway = objFunction.ReturnDouble(TB_Booking_Cost_Ew.Text)
                objBEExtraRouteStage.CostClient = objFunction.ReturnDouble(TB_Booking_Cost_Client.Text)
                objBEExtraRouteStage.AdditionalNotes = TB_Info.Text

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstCheckDuplicateRecord As DataSet = objDLExtraRouteStage.CheckDuplicateRecord(objBEExtraRouteStage, intCompanyId)

                If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                    Session("feedback_call") = "2"
                    Session("error_msg") = "WARNING - Record was NOT added - entry already in system"
                Else
                    Dim intAffectedRow As Integer = objDLExtraRouteStage.AddExtraRouteStage(objBEExtraRouteStage)
                    If intAffectedRow > 0 Then
                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        objBEActivity.Descx = DROP_Extra_Service.SelectedItem.Text + " has been added to " + DROP_Route_Stage1.SelectedItem.Text + " " + DROP_Route_Stage2.SelectedItem.Text + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "New Extra to Route-Stages has been added"
                        'TB_Distance_Miles.Text = ""
                        'TB_Distance_KM.Text = ""
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the costing entries"
            End If
            Response.Redirect("extras_link.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub DROP_Route_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Route.SelectedIndexChanged
        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub DROP_Supplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Supplier.SelectedIndexChanged
        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





