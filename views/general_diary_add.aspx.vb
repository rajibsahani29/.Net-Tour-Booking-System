Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class general_diary_add
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
                DROP_Stage.Items.Insert(0, New ListItem("Select Stage", ""))

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add accom diary event detail
    ''' </summary>
    Protected Sub BUT_Add_General_Diary_Event_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_General_Diary_Event.Click

        Try

            'If (CHK_Only_This_Accom.Checked = True And DROP_Accom_Name.SelectedItem.Value = "") Or (CHK_Only_This_Accom.Checked = False And objFunction.ReturnInteger(DROP_Accom_Name.SelectedItem.Value) > 0) Then
            '    Session("feedback_call") = "2"
            '    Session("error_msg") = "WARNING either unselect the checkbox or select accomodation. No record has been added."
            '    Response.Redirect("general_diary_add.aspx", False)
            'End If

            objBEDiaryGeneralEvents.AccomId = objFunction.ReturnInteger(DROP_Accom_Name.SelectedItem.Value)
            objBEDiaryGeneralEvents.StageId = objFunction.ReturnInteger(DROP_Stage.SelectedItem.Value)
            objBEDiaryGeneralEvents.Note = TB_Info.Text
            objBEDiaryGeneralEvents.FromDate = (If(TB_From_Date.Text <> "", Convert.ToDateTime(TB_From_Date.Text), DateTime.MinValue))
            objBEDiaryGeneralEvents.ToDate = (If(TB_To_Date.Text <> "", Convert.ToDateTime(TB_To_Date.Text), DateTime.MinValue))

            'If (chk_only_this_accom.checked = False And DROP_Accom_Name.SelectedItem.Value = "") Or (chk_only_this_accom.checked = True And DROP_Accom_Name.SelectedItem.Value = "") Or (chk_only_this_accom.checked = False And objFunction.ReturnInteger(DROP_Accom_Name.SelectedItem.Value) > 0) Then
            '    Session("feedback_call") = "2"
            '    Session("error_msg") = "warning either unselect the checkbox or select accomodation. no record has been added."
            'Else

            'If RADIO_Apply_Diary_Event.SelectedIndex > -1 Then

            If objFunction.ReturnInteger(RADIO_Apply_Diary_Event.SelectedItem.Value) = 0 Then
                objBEDiaryGeneralEvents.AllAccom = Convert.ToBoolean(objFunction.ReturnInteger(RADIO_Apply_Diary_Event.SelectedItem.Value))
                Session("accom_id") = DROP_Accom_Name.SelectedItem.Value
                Session("all_accom") = "0"
            ElseIf objFunction.ReturnInteger(RADIO_Apply_Diary_Event.SelectedItem.Value) = 1 Then
                objBEDiaryGeneralEvents.AllAccom = Convert.ToBoolean(objFunction.ReturnInteger(RADIO_Apply_Diary_Event.SelectedItem.Value))
                Session("accom_id") = "0"
                Session("all_accom") = "1"
            End If

            'End If


            Dim intaffectedrow As Integer = objDLDiaryGeneralEvents.AddDiaryGeneralEvents(objBEDiaryGeneralEvents)
            If intaffectedrow > 0 Then
                'add activity - start
                Dim objbeactivity As New clsBEActivity
                objbeactivity.Descx = "New diary event added for " + objFunction.ReturnString(DROP_Stage.SelectedItem.Text) + " by " + objFunction.ReturnString(Session("loginuserfirstname"))
                objbeactivity.StaffId = objFunction.ReturnInteger(Session("loginuserid"))

                Dim objdlactivity As New clsDLActivity
                objdlactivity.AddActivity(objbeactivity)
                'add activity - end

                Session("feedback_call") = "1"
                Session("error_msg") = "New diary event has been added"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "there was a system error. if this error persists please contact technical support."
            End If
            'End If

            Response.Redirect("general_diary_add.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of deropdown
    ''' </summary>
    Protected Sub DROP_Stage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Stage.SelectedIndexChanged

        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstAccomodation As DataSet = (New clsDLAccomodationStage()).GetAccommodationForStageFillInDD(objFunction.ReturnInteger(DROP_Stage.SelectedItem.Value), intCompanyId)
            objFunction.FillDropDownByDataSet(DROP_Accom_Name, dstAccomodation)
            DROP_Accom_Name.Items.Insert(0, New ListItem("Select Accommodation", ""))
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to view accom diary event detail
    ''' </summary>
    Protected Sub BUT_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_View.Click
        Try
            BindGridview()
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

            Dim strSearchByFromDate As String = ""
            If TB_Date_From.Text <> "" Then
                Dim dt As DateTime = (If(TB_Date_From.Text <> "", Convert.ToDateTime(TB_Date_From.Text), DateTime.MinValue))
                strSearchByFromDate = dt.ToString("MM-dd-yyyy")
            End If

            Dim strSearchByToDate As String = ""
            If TB_Date_To.Text <> "" Then
                Dim dt As DateTime = (If(TB_Date_To.Text <> "", Convert.ToDateTime(TB_Date_To.Text), DateTime.MinValue))
                strSearchByToDate = dt.ToString("MM-dd-yyyy")
            End If

            Dim dstDiaryGeneralEvents As DataSet = (New clsDLDiaryGeneralEvents()).GetDiaryGeneralEventsByDates(intCompanyId, strSearchByFromDate, strSearchByToDate)
            GRID_General_Diary_Edit.DataSource = dstDiaryGeneralEvents
            GRID_General_Diary_Edit.DataBind()
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
                Dim lb As LinkButton = DirectCast(e.Row.Cells(6).Controls(2), LinkButton)
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
            Dim txtFromDate As TextBox = DirectCast(GRID_General_Diary_Edit.Rows(e.RowIndex).FindControl("TB_GridFromDate"), TextBox)
            Dim txtToDate As TextBox = DirectCast(GRID_General_Diary_Edit.Rows(e.RowIndex).FindControl("TB_GridToDate"), TextBox)
            Dim txtNotes As TextBox = DirectCast(GRID_General_Diary_Edit.Rows(e.RowIndex).FindControl("TB_GridNotes"), TextBox)
            
            objBEDiaryGeneralEvents.DiaryGeneralEventsId = id
            objBEDiaryGeneralEvents.FromDate = (If(txtFromDate.Text <> "", Convert.ToDateTime(txtFromDate.Text), DateTime.MinValue))
            objBEDiaryGeneralEvents.ToDate = (If(txtToDate.Text <> "", Convert.ToDateTime(txtToDate.Text), DateTime.MinValue))
            objBEDiaryGeneralEvents.Note = txtNotes.Text

            Dim intAffectedRow As Integer = objDLDiaryGeneralEvents.PerformGridViewOpertaion("UPDATE", objBEDiaryGeneralEvents)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "General Diary Event has been Updated by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End

                Session("feedback_call") = "1"
                Session("error_msg") = "General Diary event has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If

            GRID_General_Diary_Edit.EditIndex = -1
            'BindGridview()
            Response.Redirect("general_diary_add.aspx", False)
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
            Dim intAffectedRow As Integer = objDLDiaryGeneralEvents.PerformGridViewOpertaion("DELETE", objBEDiaryGeneralEvents)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "General Diary Event has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "General Diary event has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GRID_General_Diary_Edit.EditIndex = -1
            'BindGridview()
            Response.Redirect("general_diary_add.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

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
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetDateValEdit(ByVal value As Object) As String
        Try
            If objFunction.ReturnString(value) <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(value)
                Return dt.ToString("yyyy-MM-dd")
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





