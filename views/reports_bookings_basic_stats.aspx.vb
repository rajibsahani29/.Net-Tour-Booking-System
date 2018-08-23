Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_bookings_basic_stats
    Inherits System.Web.UI.Page


    Dim objFunction As New clsCommon()
    Dim objDLBookingReport As clsDLBookingReport = New clsDLBookingReport

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

                BindReportData()

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindReportData()

        Try
            Dim dstBookingReportData As New DataSet()

            'GetOldestDateCreated
            Dim intCompanyId As Integer = objFunction.ReturnInteger(Session("CompanyId"))
            dstBookingReportData = objDLBookingReport.GetOldestDateCreated(DateTime.Now, intCompanyId)
            If objFunction.CheckDataSet(dstBookingReportData) Then
                LABEL_Oldest_Value.Text = SetDateVal(dstBookingReportData.Tables(0).Rows(0)("datecreated"))
                LABEL_Oldest_Booking_ID.Text = objFunction.ReturnString(dstBookingReportData.Tables(0).Rows(0)("unique_id"))
            End If

            'GetNewestDateCreated
            dstBookingReportData = objDLBookingReport.GetNewestDateCreated(DateTime.Now, intCompanyId)
            If objFunction.CheckDataSet(dstBookingReportData) Then
                LABEL_Newest_Value.Text = SetDateVal(dstBookingReportData.Tables(0).Rows(0)("datecreated"))
                LABEL_Newest_Booking_ID.Text = objFunction.ReturnString(dstBookingReportData.Tables(0).Rows(0)("unique_id"))
            End If

            'GetSmallestTotalNum
            'dstBookingReportData = objDLBookingReport.GetSmallestTotalNum(DateTime.Now)
            'If objFunction.CheckDataSet(dstBookingReportData) Then
            '    LABEL_Smallest_Value.Text = objFunction.ReturnString(dstBookingReportData.Tables(0).Rows(0)("Result"))
            'End If

            'GetLargestTotalNum
            'dstBookingReportData = objDLBookingReport.GetLargestTotalNum(DateTime.Now)
            'If objFunction.CheckDataSet(dstBookingReportData) Then
            '    LABEL_Largest_Value.Text = objFunction.ReturnString(dstBookingReportData.Tables(0).Rows(0)("Result"))
            'End If

            'GetSumOfTotalAgentType
            dstBookingReportData = objDLBookingReport.GetSumOfTotalAgentType(DateTime.Now, intCompanyId)
            If objFunction.CheckDataSet(dstBookingReportData) Then
                LABEL_Total_Agent_Value.Text = objFunction.ReturnString(dstBookingReportData.Tables(0).Rows(0)("Result"))
            End If

            'GetSumOfTotalNonAgentType
            dstBookingReportData = objDLBookingReport.GetSumOfTotalNonAgentType(DateTime.Now, intCompanyId)
            If objFunction.CheckDataSet(dstBookingReportData) Then
                LABEL_Total_Non_Agent_Value.Text = objFunction.ReturnString(dstBookingReportData.Tables(0).Rows(0)("Result"))
            End If

            'GetSumOfTotalNum
            'dstBookingReportData = objDLBookingReport.GetSumOfTotalNum(DateTime.Now)
            'If objFunction.CheckDataSet(dstBookingReportData) Then
            '    LABEL_Total_No_Value.Text = objFunction.ReturnString(dstBookingReportData.Tables(0).Rows(0)("Result"))
            'End If

            LABEL_Total_No_Value.Text = objFunction.ReturnString(objFunction.ReturnInteger(LABEL_Total_Agent_Value.Text) + objFunction.ReturnInteger(LABEL_Total_Non_Agent_Value.Text))

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetDateVal(ByVal value As Object) As String
        If objFunction.ReturnString(value) <> "" Then
            Dim dt As DateTime = Convert.ToDateTime(value)
            Return dt.ToString("dd-MM-yyyy")
        Else
            Return ""
        End If
    End Function

End Class