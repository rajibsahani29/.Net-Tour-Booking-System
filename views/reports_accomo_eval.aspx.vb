Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_accomo_eval
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()

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
                Dim dstAccomodation As DataSet = (New clsDLAccomodation()).GetAccommodationDetailFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Accom, dstAccomodation)
                DROP_Accom.Items.Insert(0, New ListItem("Select Accomodation", ""))

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub BUT__View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__View.Click
        Try
            Dim dstAccomStageEvalBooking As DataSet = (New clsDLAccomStageEvalBooking()).GetAverageAccomStageEvalBookingByAccomId(objFunction.ReturnInteger(DROP_Accom.SelectedItem.Value))
            If objFunction.CheckDataSet(dstAccomStageEvalBooking) Then
                Label_Accom_Average_Welcome.Text = objFunction.ReturnString(dstAccomStageEvalBooking.Tables(0).Rows(0)("welcome"))
                Label_Accom_Average_Cleanliness.Text = objFunction.ReturnString(dstAccomStageEvalBooking.Tables(0).Rows(0)("cleanliness"))
                Label_Accom_Average_Breakfast.Text = objFunction.ReturnString(dstAccomStageEvalBooking.Tables(0).Rows(0)("breakfast"))
                Label_Accom_Average_Facilities.Text = objFunction.ReturnString(dstAccomStageEvalBooking.Tables(0).Rows(0)("facilities"))
                Label_Accom_Average_Overall.Text = objFunction.ReturnString(dstAccomStageEvalBooking.Tables(0).Rows(0)("overall"))
            Else
                Label_Accom_Average_Welcome.Text = "0"
                Label_Accom_Average_Cleanliness.Text = "0"
                Label_Accom_Average_Breakfast.Text = "0"
                Label_Accom_Average_Facilities.Text = "0"
                Label_Accom_Average_Overall.Text = "0"
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class