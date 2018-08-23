Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class accom_options_dog
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEDogInfo As clsBEDogInfo = New clsBEDogInfo
    Dim objDLDogInfo As clsDLDogInfo = New clsDLDogInfo

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

                Dim dstDogInfo As DataSet = objDLDogInfo.GetDogInfo(objFunction.ReturnInteger(Session("CompanyId")))
                If objFunction.CheckDataSet(dstDogInfo) Then
                    TB_Dog_Info.Text = objFunction.ReturnString(dstDogInfo.Tables(0).Rows(0)("info"))
                End If

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Used to insert/update dog info
    ''' </summary>
    Protected Sub BUT_Add_Dog_Info_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Dog_Info.Click
        Try
            Dim intAffectedRow As Integer = 0
            Dim dstCheckDogInfo As DataSet = objDLDogInfo.GetDogInfo(objFunction.ReturnInteger(Session("CompanyId")))
            If objFunction.CheckDataSet(dstCheckDogInfo) Then
                objBEDogInfo.Info = TB_Dog_Info.Text
                objBEDogInfo.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                intAffectedRow = objDLDogInfo.UpdateDogInfo(objBEDogInfo)
            Else
                objBEDogInfo.Info = TB_Dog_Info.Text
                objBEDogInfo.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                intAffectedRow = objDLDogInfo.AddDogInfo(objBEDogInfo)
            End If

            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Dog info has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("accom_options_dog.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





