Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class general_diary_view
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEDiaryGeneralEvents As clsBEDiaryGeneralEvents = New clsBEDiaryGeneralEvents
    Dim objDLDiaryGeneralEvents As clsDLDiaryGeneralEvents = New clsDLDiaryGeneralEvents

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
                Dim dstStage As DataSet = (New clsDLStages()).GetStagesFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Stage, dstStage)
                DROP_Stage.Items.Insert(0, New ListItem("Select Stage", ""))

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of deropdown
    ''' </summary>
    Protected Sub DROP_Stage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Stage.SelectedIndexChanged

        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstAccomodation As DataSet = (New clsDLAccomodationStage()).GetAccommodationForStageFillInDD(objFunction.ReturnInteger(DROP_Stage.SelectedItem.Value), intCompanyId)
            objFunction.FillDropDownByDataSet(DROP_Accom_Name, dstAccomodation)
            DROP_Accom_Name.Items.Insert(0, New ListItem("Select Accommodation", ""))

            If TB_From_Date.Text <> "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "window-script", "GetCalendarData();", True)
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub
End Class





