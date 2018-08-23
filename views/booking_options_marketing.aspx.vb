Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class booking_options_marketing
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEMarketing As clsBEMarketing = New clsBEMarketing
    Dim objDLMarketing As clsDLMarketing = New clsDLMarketing

    Dim objBENewsletter As clsBENewsletter = New clsBENewsletter
    Dim objDLNewsletter As clsDLNewsletter = New clsDLNewsletter

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

                objBENewsletter.MediaId = 1
                objBENewsletter.CompanyId = objFunction.ReturnString(Session("CompanyId"))
                Dim dstNewsletter As DataSet = objDLNewsletter.GetNewsletter(objBENewsletter)
                If objFunction.CheckDataSet(dstNewsletter) Then
                    LABEL_Newsletter.Text = objFunction.ReturnString(dstNewsletter.Tables(0).Rows(0)("docLoc"))
                    LABEL_Scotland.Text = objFunction.ReturnString(dstNewsletter.Tables(0).Rows(1)("docLoc"))
                End If
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
            Dim dstMarketing As New DataSet()
            dstMarketing = (New clsDLMarketing()).GetMarketing(intCompanyId)
            GridView1.DataSource = dstMarketing
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
            'If e.Row.RowType = DataControlRowType.DataRow Then
            '    Dim lb As LinkButton = DirectCast(e.Row.Cells(2).Controls(2), LinkButton)
            '    If lb IsNot Nothing Then
            '        If lb.Text = "Delete" Then
            '            lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
            '        End If
            '    End If
            'End If
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
            hdnAccordianStatus.Value = "one"
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
            hdnAccordianStatus.Value = "one"
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
            hdnAccordianStatus.Value = "one"
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
            objBEMarketing.MarketingId = id
            objBEMarketing.Name = txtName.Text
            Dim intAffectedRow As Integer = objDLMarketing.PerformGridViewOpertaion("UPDATE", objBEMarketing)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objBEMarketing.Name + " type has been amended by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Marketing source has been amended"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("booking_options_marketing.aspx#one", False)
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
            'objBEMarketing.MarketingId = objFunction.ReturnInteger(GridView1.DataKeys(e.RowIndex).Values("id").ToString())
            'objBEMarketing.Name = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("name"))
            'Dim intAffectedRow As Integer = objDLMarketing.PerformGridViewOpertaion("DELETE", objBEMarketing)
            'If intAffectedRow > 0 Then
            '    'Add Activity - Start
            '    Dim objBEActivity As New clsBEActivity
            '    objBEActivity.Descx = objBEMarketing.Name + " type has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
            '    objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

            '    Dim objDLActivity As New clsDLActivity
            '    objDLActivity.AddActivity(objBEActivity)
            '    'Add Activity - End
            '    Session("feedback_call") = "1"
            '    Session("error_msg") = "Marketing source has been deleted"
            'Else
            '    Session("feedback_call") = "2"
            '    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            'End If
            'GridView1.EditIndex = -1
            ''BindGridview()
            'Response.Redirect("booking_options_marketing.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add marketing source details
    ''' </summary>
    Protected Sub BUT_Add_Marketing_Source_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Marketing_Source.Click
        Try
            objBEMarketing.Name = TB_Booking_Marketing_Source.Text
            objBEMarketing.CompanyId = objFunction.ReturnString(Session("CompanyId"))

            Dim intAffectedRow As Integer = objDLMarketing.AddMarketing(objBEMarketing)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objBEMarketing.Name + " has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "New marketing source has been added"
                TB_Booking_Marketing_Source.Text = ""
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("booking_options_marketing.aspx#one", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to add newsletter details
    ''' </summary>
    Protected Sub BUT_Add_Newsletter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Newsletter.Click
        Try
            objBENewsletter.MediaId = 1
            objBENewsletter.DocLink = TB_Newsletter.Text
            objBENewsletter.CompanyId = objFunction.ReturnString(Session("CompanyId"))

            Dim dstCheckDuplicateRecord As DataSet = objDLNewsletter.CheckDuplicateRecord(objBENewsletter)

            If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                Dim intAffectedRow As Integer = objDLNewsletter.UpdateNewsletter(objBENewsletter)
                If intAffectedRow > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Newsletters have been amended"
                    TB_Newsletter.Text = ""
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Dim intAffectedRow As Integer = objDLNewsletter.AddNewsletter(objBENewsletter)
                If intAffectedRow > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Newsletters have been added"
                    TB_Newsletter.Text = ""
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            End If
            Response.Redirect("booking_options_marketing.aspx#two", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to add scotland details
    ''' </summary>
    Protected Sub BUT_Add_Scotland2017_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Scotland2017.Click
        Try
            objBENewsletter.MediaId = 2
            objBENewsletter.DocLink = TB_Scotland2017.Text
            objBENewsletter.CompanyId = objFunction.ReturnString(Session("CompanyId"))

            Dim dstCheckDuplicateRecord As DataSet = objDLNewsletter.CheckDuplicateRecord(objBENewsletter)

            If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                Dim intAffectedRow As Integer = objDLNewsletter.UpdateNewsletter(objBENewsletter)
                If intAffectedRow > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Newsletters have been amended"
                    TB_Scotland2017.Text = ""
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Dim intAffectedRow As Integer = objDLNewsletter.AddNewsletter(objBENewsletter)
                If intAffectedRow > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Newsletters have been added"
                    TB_Scotland2017.Text = ""
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            End If
            Response.Redirect("booking_options_marketing.aspx#two", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





