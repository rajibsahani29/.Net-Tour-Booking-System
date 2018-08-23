Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class booking_options_stages
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEStages As clsBEStages = New clsBEStages
    Dim objDLStages As clsDLStages = New clsDLStages

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
            Dim dstStages As New DataSet()
            dstStages = (New clsDLStages()).GetStages(intCompanyId)
            GridView1.DataSource = dstStages
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
            Dim txtLongitude As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_Longitude"), TextBox)
            Dim txtLatitude As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_Latitude"), TextBox)
            Dim txtMoreInfo As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_MoreInfo"), TextBox)

            If IsNumeric(txtLongitude.Text) And IsNumeric(txtLatitude.Text) Then
                objBEStages.StagesId = id
                objBEStages.Name = txtName.Text
                objBEStages.Longitude = objFunction.ReturnDouble(txtLongitude.Text)
                objBEStages.Latitude = objFunction.ReturnDouble(txtLatitude.Text)
                objBEStages.MoreInfo = txtMoreInfo.Text
                'objBEStages.Longitude = 0
                'objBEStages.Latitude = 0

                'objBEStages.CompanyId = objFunction.ReturnString(Session("CompanyId"))
                'Dim dstCheckDuplicateRecord As DataSet = objDLStages.CheckDuplicateRecord(objBEStages)

                'If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                'Session("feedback_call") = "2"
                'Session("error_msg") = "WARNING - Stage name already exists - new record was not added"
                'Else
                Dim intAffectedRow As Integer = objDLStages.PerformGridViewOpertaion("UPDATE", objBEStages)
                If intAffectedRow > 0 Then
                    'Add Activity - Start
                    Dim objBEActivity As New clsBEActivity
                    objBEActivity.Descx = objBEStages.Name + " has been amended by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                    objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                    Dim objDLActivity As New clsDLActivity
                    objDLActivity.AddActivity(objBEActivity)
                    'Add Activity - End
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Stage has been amended"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
                'End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the longitude and latitude entries"
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("booking_options_stages.aspx", False)
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
            objBEStages.StagesId = objFunction.ReturnInteger(GridView1.DataKeys(e.RowIndex).Values("id").ToString())
            objBEStages.Name = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("name"))
            Dim intAffectedRow As Integer = objDLStages.PerformGridViewOpertaion("DELETE", objBEStages)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objBEStages.Name + " has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Stage has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("booking_options_stages.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add stage details
    ''' </summary>
    Protected Sub BUT_Add_New_Stage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_New_Stage.Click
        Try
            If IsNumeric(TB_Booking_Longitude.Text) And IsNumeric(TB_Booking_Latitude.Text) Then
                objBEStages.Name = TB_Booking_Stage_Name.Text
                objBEStages.Longitude = objFunction.ReturnDouble(TB_Booking_Longitude.Text)
                objBEStages.Latitude = objFunction.ReturnDouble(TB_Booking_Latitude.Text)
                objBEStages.MoreInfo = TB_More_Info.Text
                objBEStages.CompanyId = objFunction.ReturnString(Session("CompanyId"))

                Dim dstCheckDuplicateRecord As DataSet = objDLStages.CheckDuplicateRecord(objBEStages)

                If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                    Session("feedback_call") = "2"
                    Session("error_msg") = "WARNING - Stage name already exists - new record was not added"
                Else
                    Dim intAffectedRow As Integer = objDLStages.AddStages(objBEStages)
                    If intAffectedRow > 0 Then
                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        objBEActivity.Descx = objBEStages.Name + " has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "New stage has been added"
                        TB_Booking_Stage_Name.Text = ""
                        TB_Booking_Longitude.Text = ""
                        TB_Booking_Latitude.Text = ""
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the longitude and latitude entries"
            End If

            Response.Redirect("booking_options_stages.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





