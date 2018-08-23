Imports System.Data
Imports Easyway.BE
Imports Easyway.DL
Imports System.Data.SqlClient

Partial Class staff_password
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEStaff As clsBEStaff = New clsBEStaff
    Dim objDLStaff As clsDLStaff = New clsDLStaff

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to change the password of the staff
    ''' </summary>
    Protected Sub BUT_Change_Password_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Change_Password.Click

        Try
            objBEStaff.OldPassword = TB_Current_Password.Text
            objBEStaff.Password = TB_New_Password.Text
            objBEStaff.StaffId = objFunction.ReturnString(Session("LoginUserId"))

            Dim intAffectedRecord As Integer = objDLStaff.ChangeStaffMemberPassword(objBEStaff)
            Trace.Warn("intAffectedRecord = " + objFunction.ReturnString(intAffectedRecord))

            If intAffectedRecord > 0 Then
                LABEL_Password_Error.Text = "Your password have been updated"
            Else
                LABEL_Password_Error.Text = "Password is incorrect"
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub
End Class





