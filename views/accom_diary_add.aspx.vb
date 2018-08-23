Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class accom_diary_add
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

                Dim dstDiaryEventStatus As DataSet = (New clsDLDiaryEventStatus()).GetDiaryEventStatusFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Statue, dstDiaryEventStatus)
                DROP_Statue.Items.Insert(0, New ListItem("Select Status", ""))

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add accom diary event detail
    ''' </summary>
    Protected Sub BUT_Add_Accom_Diary_Event_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Accom_Diary_Event.Click

        Try
            objBEAccomDiaryEvent.AccomId = objFunction.ReturnInteger(DROP_Accom_Name.SelectedItem.Value)
            objBEAccomDiaryEvent.FromDate = (If(TB_From_Date.Text <> "", Convert.ToDateTime(TB_From_Date.Text), DateTime.MinValue))
            objBEAccomDiaryEvent.ToDate = (If(TB_To_Date.Text <> "", Convert.ToDateTime(TB_To_Date.Text), DateTime.MinValue))
            objBEAccomDiaryEvent.Note = TB_Info.Text
            objBEAccomDiaryEvent.DiaryEventStatusId = objFunction.ReturnInteger(DROP_Statue.SelectedItem.Value)

            Dim intAffectedRow As Integer = objDLAccomDiaryEvent.AddAccomDiaryEvent(objBEAccomDiaryEvent)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "New Diary Event added for " + objFunction.ReturnString(DROP_Accom_Name.SelectedItem.Text) + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End

                Session("feedback_call") = "1"
                Session("error_msg") = "New diary event has been added"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If

            Response.Redirect("accom_diary_add.aspx", False)
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

            Dim dstAccomDiaryEvent As DataSet = (New clsDLAccomDiaryEvent()).GetAccomDiaryEventByDates(intCompanyId, strSearchByFromDate, strSearchByToDate)
            GRID_Accom_Diary_Edit.DataSource = dstAccomDiaryEvent
            GRID_Accom_Diary_Edit.DataBind()
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
                Dim lb As LinkButton = DirectCast(e.Row.Cells(5).Controls(2), LinkButton)
                If lb IsNot Nothing Then
                    If lb.Text = "Delete" Then
                        lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
                    End If
                End If

                'Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                'Dim ddlAccommodation = DirectCast(e.Row.FindControl("DROP_GridAccommodation"), DropDownList)
                'Dim dstAccommodation As DataSet = (New clsDLAccomodation()).GetAccommodationDetailFillInDD(intCompanyId)
                'objFunction.FillDropDownByDataSet(ddlAccommodation, dstAccommodation)
                'ddlAccommodation.Items.Insert(0, New ListItem("Select Accommodation", ""))
                'ddlAccommodation.Items.FindByValue(TryCast(e.Row.FindControl("hdnAccomId"), HiddenField).Value).Selected = True

                'Dim ddlDiaryEventStatus = DirectCast(e.Row.FindControl("DROP_GridDiaryEventStatus"), DropDownList)
                'Dim dstDiaryEventStatus As DataSet = (New clsDLDiaryEventStatus()).GetDiaryEventStatusFillInDD(intCompanyId)
                'objFunction.FillDropDownByDataSet(ddlDiaryEventStatus, dstDiaryEventStatus)
                'ddlDiaryEventStatus.Items.Insert(0, New ListItem("Select Status", ""))
                'ddlDiaryEventStatus.Items.FindByValue(TryCast(e.Row.FindControl("hdnDiaryEventStatus"), HiddenField).Value).Selected = True
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
            'Dim ddlAccomId As DropDownList = DirectCast(GRID_Accom_Diary_Edit.Rows(e.RowIndex).FindControl("DROP_GridAccommodation"), DropDownList)
            Dim txtFromDate As TextBox = DirectCast(GRID_Accom_Diary_Edit.Rows(e.RowIndex).FindControl("TB_GridFromDate"), TextBox)
            Dim txtToDate As TextBox = DirectCast(GRID_Accom_Diary_Edit.Rows(e.RowIndex).FindControl("TB_GridToDate"), TextBox)
            Dim txtNotes As TextBox = DirectCast(GRID_Accom_Diary_Edit.Rows(e.RowIndex).FindControl("TB_GridNotes"), TextBox)
            'Dim ddlDiaryEventStatus As DropDownList = DirectCast(GRID_Accom_Diary_Edit.Rows(e.RowIndex).FindControl("DROP_GridDiaryEventStatus"), DropDownList)

            objBEAccomDiaryEvent.AccomDiaryEventId = id
            'objBEAccomDiaryEvent.AccomId = objFunction.ReturnInteger(ddlAccomId.SelectedItem.Value)
            objBEAccomDiaryEvent.FromDate = (If(txtFromDate.Text <> "", Convert.ToDateTime(txtFromDate.Text), DateTime.MinValue))
            objBEAccomDiaryEvent.ToDate = (If(txtToDate.Text <> "", Convert.ToDateTime(txtToDate.Text), DateTime.MinValue))
            objBEAccomDiaryEvent.Note = txtNotes.Text
            'objBEAccomDiaryEvent.DiaryEventStatusId = objFunction.ReturnInteger(ddlDiaryEventStatus.SelectedItem.Value)

            Dim intAffectedRow As Integer = objDLAccomDiaryEvent.PerformGridViewOpertaion("UPDATE", objBEAccomDiaryEvent)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                'objBEActivity.Descx = "Diary Event has been Updated for " + objFunction.ReturnString(ddlAccomId.SelectedItem.Text) + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.Descx = "Diary Event has been Updated by " + objFunction.ReturnString(Session("LoginUserFirstName"))
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
            'BindGridview()
            Response.Redirect("accom_diary_add.aspx", False)
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
            'Dim strAccomName As String = objFunction.ReturnString(GRID_Accom_Diary_Edit.DataKeys(e.RowIndex).Values("AccomName"))
            Dim intAffectedRow As Integer = objDLAccomDiaryEvent.PerformGridViewOpertaion("DELETE", objBEAccomDiaryEvent)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                'objBEActivity.Descx = "Diary Event has been deleted for " + strAccomName + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.Descx = "Diary Event has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
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
            'BindGridview()
            Response.Redirect("accom_diary_add.aspx", False)
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

End Class





