Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE
Imports Easyway.DL

Partial Class login
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEStaff As clsBEStaff = New clsBEStaff

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If objFunction.ValidateLogin() Then
                Response.Redirect("~/views/dashboard.aspx")
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to check staff login
    ''' </summary>
    Protected Sub BUT_login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_login.Click

        Try
            objBEStaff.UserName = TB_Username.Text
            objBEStaff.Password = TB_Password.Text

            Dim objDLStaff As clsDLStaff = New clsDLStaff

            If hdnCompanyId.Value <> "" Then
                objBEStaff.CompanyId = objFunction.ReturnInteger(hdnCompanyId.Value)
            End If

            Dim dstLogin As DataSet = objDLStaff.StaffLogin(objBEStaff)

            If dstLogin IsNot Nothing AndAlso dstLogin.Tables(0).Rows.Count = 1 Then
                Session("LoginUserId") = Convert.ToString(dstLogin.Tables(0).Rows(0)("id"))
                Session("RoleId") = Convert.ToString(dstLogin.Tables(0).Rows(0)("role"))
                Session("CompanyId") = Convert.ToString(dstLogin.Tables(0).Rows(0)("company_id"))
                Session("LoginUserName") = Convert.ToString(dstLogin.Tables(0).Rows(0)("username"))
                Session("LoginUserFirstName") = Convert.ToString(dstLogin.Tables(0).Rows(0)("firstname"))
                Response.Redirect("~/views/dashboard.aspx")
            Else
                LABEL_Login_Error.Text = "Username and/or Password is incorrect."
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class