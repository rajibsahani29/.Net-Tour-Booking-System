Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class booking_options_distance_stages
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEStageDistance As clsBEStageDistance = New clsBEStageDistance
    Dim objDLStageDistance As clsDLStageDistance = New clsDLStageDistance

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
                Dim dstStage As DataSet = (New clsDLStages()).GetStagesFillInDD(intCompanyId)

                objFunction.FillDropDownByDataSet(DROP_Stage1, dstStage)
                DROP_Stage1.Items.Insert(0, New ListItem("Select Stage 1", ""))

                objFunction.FillDropDownByDataSet(DROP_Stage2, dstStage)
                DROP_Stage2.Items.Insert(0, New ListItem("Select Stage 2", ""))

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
            Dim dstStageDistance As New DataSet()
            dstStageDistance = (New clsDLStageDistance()).GetStageDistance(intCompanyId)
            GridView1.DataSource = dstStageDistance
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
                Dim lb As LinkButton = DirectCast(e.Row.Cells(5).Controls(2), LinkButton)
                If lb IsNot Nothing Then
                    If lb.Text = "Delete" Then
                        lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
                    End If
                End If

                'Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                'Dim dstStage As DataSet = (New clsDLStages()).GetStagesFillInDD(intCompanyId)

                'Dim ddlStage1 = DirectCast(e.Row.FindControl("DROP_GridStage1"), DropDownList)
                'objFunction.FillDropDownByDataSet(ddlStage1, dstStage)
                'ddlStage1.Items.Insert(0, New ListItem("Select Stage 1", ""))
                'ddlStage1.Items.FindByValue(TryCast(e.Row.FindControl("hdnStageId1"), HiddenField).Value).Selected = True

                'Dim ddlStage2 = DirectCast(e.Row.FindControl("DROP_GridStage2"), DropDownList)
                'objFunction.FillDropDownByDataSet(ddlStage2, dstStage)
                'ddlStage2.Items.Insert(0, New ListItem("Select Stage 2", ""))
                'ddlStage2.Items.FindByValue(TryCast(e.Row.FindControl("hdnStageId2"), HiddenField).Value).Selected = True

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
            'Dim ddlStageId1 As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("DROP_GridStage1"), DropDownList)
            'Dim ddlStageId2 As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("DROP_GridStage2"), DropDownList)
            Dim txtMile As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_Mile"), TextBox)
            Dim txtKm As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_Km"), TextBox)

            If IsNumeric(txtMile.Text) And IsNumeric(txtKm.Text) Then
                objBEStageDistance.StageDistanceId = id
                'objBEStageDistance.StageId1 = objFunction.ReturnInteger(ddlStageId1.SelectedItem.Value)
                'objBEStageDistance.StageId2 = objFunction.ReturnInteger(ddlStageId2.SelectedItem.Value)
                objBEStageDistance.Miles = objFunction.ReturnInteger(txtMile.Text)
                objBEStageDistance.Km = objFunction.ReturnInteger(txtKm.Text)

                'Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                'Dim dstCheckDuplicateRecord As DataSet = objDLStageDistance.CheckDuplicateRecord(objBEStageDistance, intCompanyId)

                'If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                '    Session("feedback_call") = "2"
                '    Session("error_msg") = "WARNING - New stage-stage distances have NOT been added as the entry already exists"
                'Else
                Dim intAffectedRow As Integer = objDLStageDistance.PerformGridViewOpertaion("UPDATE", objBEStageDistance)
                If intAffectedRow > 0 Then
                    'Add Activity - Start
                    Dim objBEActivity As New clsBEActivity
                    objBEActivity.Descx = "Distance between " + DROP_Stage1.SelectedItem.Text + " and " + DROP_Stage2.SelectedItem.Text + " has been amended by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                    objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                    Dim objDLActivity As New clsDLActivity
                    objDLActivity.AddActivity(objBEActivity)
                    'Add Activity - End
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Stage-stage distances has been amended"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
                'End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "Please enter numerical values. No records has been added"
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("booking_options_distance_stages.aspx", False)
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
            objBEStageDistance.StageDistanceId = objFunction.ReturnInteger(GridView1.DataKeys(e.RowIndex).Values("id").ToString())
            Dim strStageName1 As String = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("stagename1"))
            Dim strStageName2 As String = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("stagename2"))
            Dim intAffectedRow As Integer = objDLStageDistance.PerformGridViewOpertaion("DELETE", objBEStageDistance)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "Distance between " + strStageName1 + " and " + strStageName2 + " has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Stage-stage distances has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("booking_options_distance_stages.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add distance stage details
    ''' </summary>
    Protected Sub BUT_Add_New_Distance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_New_Distance.Click
        Try
            If IsNumeric(TB_Distance_Miles.Text) And IsNumeric(TB_Distance_KM.Text) Then
                objBEStageDistance.StageId1 = objFunction.ReturnInteger(DROP_Stage1.SelectedItem.Value)
                objBEStageDistance.StageId2 = objFunction.ReturnInteger(DROP_Stage2.SelectedItem.Value)
                objBEStageDistance.Miles = objFunction.ReturnInteger(TB_Distance_Miles.Text)
                objBEStageDistance.Km = objFunction.ReturnInteger(TB_Distance_KM.Text)

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstCheckDuplicateRecord As DataSet = objDLStageDistance.CheckDuplicateRecord(objBEStageDistance, intCompanyId)

                If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                    Session("feedback_call") = "2"
                    Session("error_msg") = "WARNING - New stage-stage distances have NOT been added as the entry already exists"
                Else
                    Dim intAffectedRow As Integer = objDLStageDistance.AddStageDistance(objBEStageDistance)
                    If intAffectedRow > 0 Then
                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        objBEActivity.Descx = "Distance between " + DROP_Stage1.SelectedItem.Text + " and " + DROP_Stage2.SelectedItem.Text + " has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "New stage-stage distances has been added"
                        TB_Distance_Miles.Text = ""
                        TB_Distance_KM.Text = ""
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "Please enter numerical values. No records has been added"
            End If
            Response.Redirect("booking_options_distance_stages.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





