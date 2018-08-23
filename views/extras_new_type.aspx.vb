Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class extras_new_type
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEExtraType As clsBEExtraType = New clsBEExtraType
    Dim objDLExtraType As clsDLExtraType = New clsDLExtraType

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
            Dim dstExtraType As New DataSet()
            dstExtraType = (New clsDLExtraType()).GetExtraType(intCompanyId)
            GridView1.DataSource = dstExtraType
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
                Dim lb As LinkButton = DirectCast(e.Row.Cells(2).Controls(2), LinkButton)
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
            Dim intId = objFunction.ReturnInteger(objFunction.ReturnString(GridView1.DataKeys(e.NewEditIndex).Values("id")))
            If intId <> 1 And intId <> 2 Then
                GridView1.EditIndex = e.NewEditIndex
                BindGridview()
            End If

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
            objBEExtraType.ExtraTypeId = id
            objBEExtraType.Name = txtName.Text

            If objBEExtraType.ExtraTypeId <> 1 And objBEExtraType.ExtraTypeId <> 2 Then
                Dim intAffectedRow As Integer = objDLExtraType.PerformGridViewOpertaion("UPDATE", objBEExtraType)
                If intAffectedRow > 0 Then
                    'Add Activity - Start
                    Dim objBEActivity As New clsBEActivity
                    objBEActivity.Descx = objBEExtraType.Name + " has been amended by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                    objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                    Dim objDLActivity As New clsDLActivity
                    objDLActivity.AddActivity(objBEActivity)
                    'Add Activity - End
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Extra Type has been amended"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            End If

            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("extras_new_type.aspx", False)
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
            objBEExtraType.ExtraTypeId = objFunction.ReturnInteger(GridView1.DataKeys(e.RowIndex).Values("id").ToString())
            objBEExtraType.Name = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("name"))
            If objBEExtraType.ExtraTypeId <> 1 And objBEExtraType.ExtraTypeId <> 2 Then
                Dim intAffectedRow As Integer = objDLExtraType.PerformGridViewOpertaion("DELETE", objBEExtraType)
                If intAffectedRow > 0 Then
                    'Add Activity - Start
                    Dim objBEActivity As New clsBEActivity
                    objBEActivity.Descx = objBEExtraType.Name + " has been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                    objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                    Dim objDLActivity As New clsDLActivity
                    objDLActivity.AddActivity(objBEActivity)
                    'Add Activity - End
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Extra Type has been deleted"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("extras_new_type.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add extra type details
    ''' </summary>
    Protected Sub BUT_Add_Extra_Type_Service_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Extra_Type_Service.Click
        Try
            objBEExtraType.Name = TB_Service_Type.Text
            objBEExtraType.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim intAffectedRow As Integer = objDLExtraType.AddExtraType(objBEExtraType)
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objBEExtraType.Name + " has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "New Extra Type has been added"
                TB_Service_Type.Text = ""
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("extras_new_type.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





