
Partial Class views_logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Session("LoginUserId") = Nothing
            Session("RoleId") = Nothing
            Session("CompanyId") = Nothing
            Session("LoginUserName") = Nothing
            Session("LoginUserFirstName") = Nothing
            Response.Redirect("~/login.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class
