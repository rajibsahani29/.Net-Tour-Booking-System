Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class accom_diary_edit
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEAccomDiaryEvent As clsBEAccomDiaryEvent = New clsBEAccomDiaryEvent
    Dim objDLAccomDiaryEvent As clsDLAccomDiaryEvent = New clsDLAccomDiaryEvent

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
                objFunction.FillDropDownByDataSet(DROP_Accom_Name, dstAccomodation)
                DROP_Accom_Name.Items.Insert(0, New ListItem("Select Accommodation", ""))

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
            If objFunction.ReturnInteger(DROP_Accom_Name.SelectedItem.Value) > 0 And TB_From_Date.Text <> "" Then
                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

                If CHK_View_All_Accom_Diary.Checked = True Then
                    objBEAccomDiaryEvent.AccomId = 0
                Else
                    objBEAccomDiaryEvent.AccomId = objFunction.ReturnInteger(DROP_Accom_Name.SelectedItem.Value)
                End If
                objBEAccomDiaryEvent.FromDate = Convert.ToDateTime(TB_From_Date.Text)
                Dim dstAccomDiaryEvent As DataSet = objDLAccomDiaryEvent.GetAccomDiaryEventCalander(objBEAccomDiaryEvent, intCompanyId, "")
                GRID_Accom_Diary_Edit.DataSource = dstAccomDiaryEvent
                GRID_Accom_Diary_Edit.DataBind()
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GRID_Accom_Diary_Edit
    ''' </summary>
    Protected Sub GRID_Accom_Diary_Edit_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lb As LinkButton = DirectCast(e.Row.Cells(6).Controls(2), LinkButton)
                If lb IsNot Nothing Then
                    If lb.Text = "Delete" Then
                        lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
                    End If
                End If

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

                Dim ddlDiaryEventStatus = DirectCast(e.Row.FindControl("DROP_GridDiaryEventStatus"), DropDownList)
                If ddlDiaryEventStatus IsNot Nothing Then
                    Dim dstDiaryEventStatus As DataSet = (New clsDLDiaryEventStatus()).GetDiaryEventStatusFillInDD(intCompanyId)
                    objFunction.FillDropDownByDataSet(ddlDiaryEventStatus, dstDiaryEventStatus)
                    ddlDiaryEventStatus.Items.Insert(0, New ListItem("Select Status", ""))
                    ddlDiaryEventStatus.Items.FindByValue(TryCast(e.Row.FindControl("hdnDiaryEventStatusId"), HiddenField).Value).Selected = True
                End If
                
                Dim ddlAccommodation = DirectCast(e.Row.FindControl("DROP_GridAccommodation"), DropDownList)
                If ddlAccommodation IsNot Nothing Then
                    Dim dstAccomodation As DataSet = (New clsDLAccomodation()).GetAccommodationDetailFillInDD(intCompanyId)
                    objFunction.FillDropDownByDataSet(ddlAccommodation, dstAccomodation)
                    ddlAccommodation.Items.Insert(0, New ListItem("Select Accommodation", ""))
                    ddlAccommodation.Items.FindByValue(TryCast(e.Row.FindControl("hdnAccomId"), HiddenField).Value).Selected = True
                End If
                
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowEditing event of the GRID_Accom_Diary_Edit
    ''' </summary>
    Protected Sub GRID_Accom_Diary_Edit_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

        Try
            GRID_Accom_Diary_Edit.EditIndex = e.NewEditIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowCancelingEdit event of the GRID_Accom_Diary_Edit
    ''' </summary>
    Protected Sub GRID_Accom_Diary_Edit_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)

        Try
            GRID_Accom_Diary_Edit.EditIndex = -1
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Accom_Diary_Edit
    ''' </summary>
    Protected Sub GRID_Accom_Diary_Edit_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Accom_Diary_Edit.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowUpdating event of the GRID_Accom_Diary_Edit
    ''' </summary>
    Protected Sub GRID_Accom_Diary_Edit_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GRID_Accom_Diary_Edit.DataKeys(e.RowIndex).Values("id")))
            Dim txtNote As TextBox = DirectCast(GRID_Accom_Diary_Edit.Rows(e.RowIndex).FindControl("TB_Note"), TextBox)
            Dim ddlDiaryEventStatusId As DropDownList = DirectCast(GRID_Accom_Diary_Edit.Rows(e.RowIndex).FindControl("DROP_GridDiaryEventStatus"), DropDownList)
            Dim txtFromDate As TextBox = DirectCast(GRID_Accom_Diary_Edit.Rows(e.RowIndex).FindControl("TB_From"), TextBox)
            Dim txtToDate As TextBox = DirectCast(GRID_Accom_Diary_Edit.Rows(e.RowIndex).FindControl("TB_To"), TextBox)
            Dim ddlAccommodationId As DropDownList = DirectCast(GRID_Accom_Diary_Edit.Rows(e.RowIndex).FindControl("DROP_GridAccommodation"), DropDownList)
            
            objBEAccomDiaryEvent.AccomDiaryEventId = id
            objBEAccomDiaryEvent.Note = txtNote.Text
            objBEAccomDiaryEvent.DiaryEventStatusId = objFunction.ReturnInteger(ddlDiaryEventStatusId.SelectedItem.Value)
            objBEAccomDiaryEvent.FromDate = (If(txtFromDate.Text <> "", Convert.ToDateTime(txtFromDate.Text), DateTime.MinValue))
            objBEAccomDiaryEvent.ToDate = (If(txtToDate.Text <> "", Convert.ToDateTime(txtToDate.Text), DateTime.MinValue))
            objBEAccomDiaryEvent.AccomId = objFunction.ReturnInteger(ddlAccommodationId.SelectedItem.Value)

            Dim intAffectedRow As Integer = objDLAccomDiaryEvent.PerformGridViewOpertaion("UPDATE", objBEAccomDiaryEvent)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "Diary Event updated for " + objFunction.ReturnString(ddlAccommodationId.SelectedItem.Text) + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
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
            GRID_Accom_Diary_Edit.EditIndex = -1
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
    ''' RowDeleting event of the GRID_Accom_Diary_Edit
    ''' </summary>
    Protected Sub GRID_Accom_Diary_Edit_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            objBEAccomDiaryEvent.AccomDiaryEventId = objFunction.ReturnInteger(GRID_Accom_Diary_Edit.DataKeys(e.RowIndex).Values("id").ToString())
            Dim strAccomName As String = objFunction.ReturnString(GRID_Accom_Diary_Edit.DataKeys(e.RowIndex).Values("AccomName"))
            Dim intAffectedRow As Integer = objDLAccomDiaryEvent.PerformGridViewOpertaion("DELETE", objBEAccomDiaryEvent)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "Diary Event updated for " + objFunction.ReturnString(strAccomName) + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
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
            GRID_Accom_Diary_Edit.EditIndex = -1
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
    ''' SelectedIndexChanged event of checkbox
    ''' </summary>
    Protected Sub CHK_View_All_Accom_Diary_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHK_View_All_Accom_Diary.CheckedChanged

        Try
            BindGridview()
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

End Class