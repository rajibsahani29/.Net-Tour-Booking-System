Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class general_diary_edit
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEDiaryGeneralEvents As clsBEDiaryGeneralEvents = New clsBEDiaryGeneralEvents
    Dim objDLDiaryGeneralEvents As clsDLDiaryGeneralEvents = New clsDLDiaryGeneralEvents

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
                objFunction.FillDropDownByDataSet(DROP_Stage, dstStage)
                DROP_Stage.Items.Insert(0, New ListItem("Select Stage", "0"))

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
            If TB_From_Date.Text <> "" Then
                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                objBEDiaryGeneralEvents.StageId = objFunction.ReturnInteger(DROP_Stage.SelectedItem.Value)
                If DROP_Accom_Name.Items.Count > 0 Then
                    objBEDiaryGeneralEvents.AccomId = objFunction.ReturnInteger(DROP_Accom_Name.SelectedItem.Value)
                Else
                    objBEDiaryGeneralEvents.AccomId = 0
                End If
                objBEDiaryGeneralEvents.FromDate = Convert.ToDateTime(TB_From_Date.Text)
                Dim dstAccomDiaryGeneralEvent As DataSet = objDLDiaryGeneralEvents.GetDiaryGeneralEventsCalander(objBEDiaryGeneralEvents, intCompanyId, "")
                GRID_General_Diary_Edit.DataSource = dstAccomDiaryGeneralEvent
                GRID_General_Diary_Edit.DataBind()
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GRID_General_Diary_Edit
    ''' </summary>
    Protected Sub GRID_General_Diary_Edit_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lb As LinkButton = DirectCast(e.Row.Cells(7).Controls(2), LinkButton)
                If lb IsNot Nothing Then
                    If lb.Text = "Delete" Then
                        lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
                    End If
                End If

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

                Dim ddlStage = DirectCast(e.Row.FindControl("DROP_GridStage"), DropDownList)
                If ddlStage IsNot Nothing Then
                    Dim dstStage As DataSet = (New clsDLStages()).GetStagesFillInDD(intCompanyId)
                    objFunction.FillDropDownByDataSet(ddlStage, dstStage)
                    ddlStage.Items.Insert(0, New ListItem("Select Stage", "0"))
                    ddlStage.Items.FindByValue(TryCast(e.Row.FindControl("hdnStageId"), HiddenField).Value).Selected = True
                End If

                Dim ddlAccommodation = DirectCast(e.Row.FindControl("DROP_GridAccommodation"), DropDownList)
                If ddlAccommodation IsNot Nothing Then
                    Dim dstAccomodation As DataSet = (New clsDLAccomRouteStage()).GetAccommodationForStageFillInDD(objFunction.ReturnInteger(ddlStage.SelectedItem.Value), intCompanyId)
                    objFunction.FillDropDownByDataSet(ddlAccommodation, dstAccomodation)
                    ddlAccommodation.Items.Insert(0, New ListItem("Select Accommodation", "0"))
                    ddlAccommodation.Items.FindByValue(TryCast(e.Row.FindControl("hdnAccomId"), HiddenField).Value).Selected = True
                End If
                
                Dim rblAllAccom = DirectCast(e.Row.FindControl("RADIO_GridAllAccom"), RadioButtonList)
                If rblAllAccom IsNot Nothing Then
                    rblAllAccom.Items.Insert(0, New ListItem("&nbsp;Apply to this Accommodation Only", "0"))
                    rblAllAccom.Items.Insert(1, New ListItem("&nbsp;Apply to Stage", "1"))
                    Dim bnlRbVal As Boolean = Convert.ToBoolean(TryCast(e.Row.FindControl("hdnAllAccom"), HiddenField).Value)
                    rblAllAccom.SelectedValue = Convert.ToInt32(bnlRbVal)
                End If
                
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowEditing event of the GRID_General_Diary_Edit
    ''' </summary>
    Protected Sub GRID_General_Diary_Edit_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

        Try
            GRID_General_Diary_Edit.EditIndex = e.NewEditIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowCancelingEdit event of the GRID_General_Diary_Edit
    ''' </summary>
    Protected Sub GRID_General_Diary_Edit_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)

        Try
            GRID_General_Diary_Edit.EditIndex = -1
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_General_Diary_Edit
    ''' </summary>
    Protected Sub GRID_General_Diary_Edit_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_General_Diary_Edit.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowUpdating event of the GRID_General_Diary_Edit
    ''' </summary>
    Protected Sub GRID_General_Diary_Edit_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GRID_General_Diary_Edit.DataKeys(e.RowIndex).Values("id")))
            Dim txtNote As TextBox = DirectCast(GRID_General_Diary_Edit.Rows(e.RowIndex).FindControl("TB_Note"), TextBox)
            Dim ddlStageId As DropDownList = DirectCast(GRID_General_Diary_Edit.Rows(e.RowIndex).FindControl("DROP_GridStage"), DropDownList)
            Dim txtFromDate As TextBox = DirectCast(GRID_General_Diary_Edit.Rows(e.RowIndex).FindControl("TB_From"), TextBox)
            Dim txtToDate As TextBox = DirectCast(GRID_General_Diary_Edit.Rows(e.RowIndex).FindControl("TB_To"), TextBox)
            Dim ddlAccommodationId As DropDownList = DirectCast(GRID_General_Diary_Edit.Rows(e.RowIndex).FindControl("DROP_GridAccommodation"), DropDownList)
            Dim rblAllAccom As RadioButtonList = DirectCast(GRID_General_Diary_Edit.Rows(e.RowIndex).FindControl("RADIO_GridAllAccom"), RadioButtonList)

            objBEDiaryGeneralEvents.DiaryGeneralEventsId = id
            objBEDiaryGeneralEvents.Note = txtNote.Text
            objBEDiaryGeneralEvents.StageId = objFunction.ReturnInteger(ddlStageId.SelectedItem.Value)
            objBEDiaryGeneralEvents.FromDate = (If(txtFromDate.Text <> "", Convert.ToDateTime(txtFromDate.Text), DateTime.MinValue))
            objBEDiaryGeneralEvents.ToDate = (If(txtToDate.Text <> "", Convert.ToDateTime(txtToDate.Text), DateTime.MinValue))
            objBEDiaryGeneralEvents.AccomId = objFunction.ReturnInteger(ddlAccommodationId.SelectedItem.Value)
            objBEDiaryGeneralEvents.AllAccom = objFunction.ReturnInteger(rblAllAccom.SelectedItem.Value)

            Dim intAffectedRow As Integer = objDLDiaryGeneralEvents.PerformGridViewOpertaion("UPDATE", objBEDiaryGeneralEvents)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "Diary Event updated for " + objFunction.ReturnString(ddlStageId.SelectedItem.Text) + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End

                Session("feedback_call") = "1"
                Session("error_msg") = "Diary event has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_General_Diary_Edit.EditIndex = -1
            BindGridview()
            If Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 1 Then
                Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
            ElseIf Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 2 Then
                Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
            End If
            Session("feedback_call") = "0"
            Session("error_msg") = ""
            'Response.Redirect("accom_diary_edit.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GRID_General_Diary_Edit
    ''' </summary>
    Protected Sub GRID_General_Diary_Edit_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            objBEDiaryGeneralEvents.DiaryGeneralEventsId = objFunction.ReturnInteger(GRID_General_Diary_Edit.DataKeys(e.RowIndex).Values("id").ToString())
            Dim strStageName As String = objFunction.ReturnString(GRID_General_Diary_Edit.DataKeys(e.RowIndex).Values("StageName"))
            Dim intAffectedRow As Integer = objDLDiaryGeneralEvents.PerformGridViewOpertaion("DELETE", objBEDiaryGeneralEvents)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "Diary Event updated for " + objFunction.ReturnString(strStageName) + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Diary event has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_General_Diary_Edit.EditIndex = -1
            If Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 1 Then
                Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
            ElseIf Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 2 Then
                Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
            End If
            Session("feedback_call") = "0"
            Session("error_msg") = ""
            BindGridview()
            'Response.Redirect("accom_diary_edit.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of dropdown
    ''' </summary>
    Protected Sub DROP_Stage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Stage.SelectedIndexChanged

        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstAccomodation As DataSet = (New clsDLAccomRouteStage()).GetAccommodationForStageFillInDD(objFunction.ReturnInteger(DROP_Stage.SelectedItem.Value), intCompanyId)
            objFunction.FillDropDownByDataSet(DROP_Accom_Name, dstAccomodation)
            DROP_Accom_Name.Items.Insert(0, New ListItem("Select Accommodation", "0"))

            BindGridview()

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of dropdown
    ''' </summary>
    Protected Sub DROP_Accom_Name_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Accom_Name.SelectedIndexChanged

        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of textbox
    ''' </summary>
    Protected Sub TB_From_Date_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_From_Date.TextChanged

        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of dropdown
    ''' </summary>
    Protected Sub DROP_GridStage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            'Trace.Warn("Come in DROP_GridStage_SelectedIndexChanged")
            Dim ddl As DropDownList = DirectCast(sender, DropDownList)
            Dim row As GridViewRow = TryCast(ddl.NamingContainer, GridViewRow)
            Dim i As Int16
            If row IsNot Nothing Then
                'Trace.Warn("Value = " + CType(row.FindControl("DROP_GridStage"), DropDownList).SelectedValue.ToString())
                Dim intStageId As Integer = objFunction.ReturnInteger(CType(row.FindControl("DROP_GridStage"), DropDownList).SelectedValue)
                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstAccomodation As DataSet = (New clsDLAccomRouteStage()).GetAccommodationForStageFillInDD(intStageId, intCompanyId)
                Dim ddlAccomodation As DropDownList = DirectCast(CType(row.FindControl("DROP_GridAccommodation"), DropDownList), DropDownList)
                objFunction.FillDropDownByDataSet(ddlAccomodation, dstAccomodation)
                ddlAccomodation.Items.Insert(0, New ListItem("Select Accommodation", "0"))
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        
    End Sub

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetDateVal(ByVal value As Object) As String
        If objFunction.ReturnString(value) <> "" Then
            Dim dt As DateTime = Convert.ToDateTime(value)
            Return dt.ToString("dd-MM-yyyy")
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' This function is used to set date control value
    ''' </summary>
    Public Function SetDateControlVal(ByVal value As Object) As String
        If objFunction.ReturnString(value) <> "" Then
            Dim dt As DateTime = Convert.ToDateTime(value)
            Return dt.ToString("yyyy-MM-dd")
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' This function is used to set radio button value
    ''' </summary>
    Public Function SetAccomRadioVal(ByVal value As Object) As String
        If objFunction.ReturnString(value) = "False" Then
            Return "Apply to this Accommodation Only"
        Else
            Return "Apply to Stage"
        End If
    End Function

End Class





