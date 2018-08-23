Imports System.Data
Imports System.IO
Imports Easyway.BE
Imports Easyway.DL

Partial Class agent_photos
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEAgent As clsBEAgent = New clsBEAgent
    Dim objDLAgent As clsDLAgent = New clsDLAgent

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
                Dim dstAgent As DataSet = (New clsDLAgent()).GetAgentDetailFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Agent, dstAgent)
                DROP_Agent.Items.Insert(0, New ListItem("Select Agent", ""))

                Trace.Warn("EditAgentIdForPhoto = " + objFunction.ReturnString(Session("EditAgentIdForPhoto")))
                If objFunction.ReturnString(Session("EditAgentIdForPhoto")) <> "" Then
                    Trace.Warn("In if EditAgentIdForPhoto = " + objFunction.ReturnString(Session("EditAgentIdForPhoto")))
                    DROP_Agent.Items.FindByValue(objFunction.ReturnString(Session("EditAgentIdForPhoto"))).Selected = True
                    BUT_Add_Logo.Enabled = True
                    BindGridview()
                    Session("EditAgentIdForPhoto") = Nothing
                End If

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add agent photo details
    ''' </summary>
    Protected Sub BUT_Add_Logo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Logo.Click
        Try
            Session("EditAgentIdForPhoto") = objFunction.ReturnString(DROP_Agent.SelectedItem.Value)

            If FILE_Logo.HasFile = True Then
                Dim strFileExtension As String = Path.GetExtension(FILE_Logo.PostedFile.FileName)

                If strFileExtension = ".jpg" Or strFileExtension = ".jpeg" Or strFileExtension = ".png" Or strFileExtension = ".gif" Then
                    Dim random As New Random
                    Dim strRandomNo As String = objFunction.ReturnString(random.Next(100000, 999999))
                    Dim strFileName As String = strRandomNo + "_" + objFunction.ReturnString(DROP_Agent.SelectedItem.Value) + "_Logo" + strFileExtension
                    FILE_Logo.SaveAs(Server.MapPath("~/uploadedimages/" + strFileName))

                    objBEAgent.AgentId = objFunction.ReturnInteger(DROP_Agent.SelectedItem.Value)
                    objBEAgent.ImageLoc = strFileName

                    Dim intAgentId As Integer = objFunction.ReturnInteger(DROP_Agent.SelectedItem.Value)
                    Dim dstAgent As DataSet = (New clsDLAgent()).GetAgentDetailById(intAgentId)
                    Dim strOldFileName As String = ""
                    If objFunction.CheckDataSet(dstAgent) Then
                        strOldFileName = objFunction.ReturnString(dstAgent.Tables(0).Rows(0)("image_loc"))
                    End If

                    Dim intAffectedRow As Integer = objDLAgent.UploadAgentLogo(objBEAgent)
                    If intAffectedRow > 0 Then

                        If strOldFileName <> "" Then
                            File.Delete(Server.MapPath("~/uploadedimages/" + strOldFileName))
                        End If

                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        objBEActivity.Descx = DROP_Agent.SelectedItem.Text + " photos have been updated by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "New photo has been added"
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "Upload only jpg, jpeg, png & gif image file."
                End If

            End If
            Response.Redirect("agent_photos.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to change the dropdown index
    ''' </summary>
    Protected Sub DROP_Agent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Agent.SelectedIndexChanged
        BUT_Add_Logo.Enabled = True
        BindGridview()
    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindGridview()

        Try
            Dim intAgentId As Integer = objFunction.ReturnInteger(DROP_Agent.SelectedItem.Value)
            Dim dstAgent As New DataSet()
            dstAgent = (New clsDLAgent()).GetAgentDetailById(intAgentId)

            If objFunction.CheckDataSet(dstAgent) Then
                If objFunction.ReturnString(dstAgent.Tables(0).Rows(0)("image_loc")) <> "" Then
                    GRID_Agent_Logo.DataSource = dstAgent
                    GRID_Agent_Logo.DataBind()

                    For i As Integer = 0 To GRID_Agent_Logo.Rows.Count - 1
                        Dim gRow As GridViewRow = GRID_Agent_Logo.Rows(i)
                        Dim hdnImageName As HiddenField = DirectCast(gRow.FindControl("hdnImageName"), HiddenField)
                        Dim imgPhoto As Image = DirectCast(gRow.FindControl("IMG_Photo"), Image)
                        imgPhoto.ImageUrl = "~/uploadedimages/" + hdnImageName.Value
                    Next
                Else
                    Dim dstTemp As DataSet = Nothing
                    GRID_Agent_Logo.DataSource = dstTemp
                    GRID_Agent_Logo.DataBind()
                End If
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GRID_Agent_Logo
    ''' </summary>
    Protected Sub GRID_Agent_Logo_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lb As LinkButton = DirectCast(e.Row.Cells(2).Controls(0), LinkButton)
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
    ''' RowDeleting event of the GRID_Agent_Logo
    ''' </summary>
    Protected Sub GRID_Agent_Logo_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            Session("EditAgentIdForPhoto") = objFunction.ReturnString(DROP_Agent.SelectedItem.Value)
            Dim intAgentId As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GRID_Agent_Logo.DataKeys(e.RowIndex).Values("id")))
            Dim strFileName As String = objFunction.ReturnString(GRID_Agent_Logo.DataKeys(e.RowIndex).Values("image_loc"))
            
            objBEAgent.AgentId = intAgentId
            objBEAgent.ImageLoc = ""

            Dim intAffectedRow As Integer = objDLAgent.UploadAgentLogo(objBEAgent)

            If intAffectedRow > 0 Then

                File.Delete(Server.MapPath("~/uploadedimages/" + strFileName))

                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objFunction.ReturnString(DROP_Agent.SelectedItem.Text) + " photos have been updated by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Photo has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            'GRID_Agent_Logo.EditIndex = -1
            'BindGridview()
            Response.Redirect("agent_photos.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class





