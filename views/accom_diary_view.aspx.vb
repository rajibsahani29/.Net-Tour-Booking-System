Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class accom_diary_view
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEAccomDiaryEvent As clsBEAccomDiaryEvent = New clsBEAccomDiaryEvent
    Dim objDLAccomDiaryEvent As clsDLAccomDiaryEvent = New clsDLAccomDiaryEvent

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Response.Redirect("accom_diary_view2.aspx")

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class