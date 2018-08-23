Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_agent_booking
    Inherits System.Web.UI.Page

    Protected objFunction As New clsCommon()

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

            Dim strSearchByFromDate As String = ""
            If TB_Date_From.Text <> "" Then
                Dim dt As DateTime = (If(TB_Date_From.Text <> "", Convert.ToDateTime(TB_Date_From.Text), DateTime.MinValue))
                strSearchByFromDate = dt.ToString("MM-dd-yyyy")
            End If

            Dim strSearchByToDate As String = ""
            If TB_Date_To.Text <> "" Then
                Dim dt As DateTime = (If(TB_Date_To.Text <> "", Convert.ToDateTime(TB_Date_To.Text), DateTime.MinValue))
                strSearchByToDate = dt.ToString("MM-dd-yyyy")
            End If

            Dim dstReportAgentBooking As DataSet = (New clsDLBookingReport()).GetReportAgentBooking(intCompanyId, strSearchByFromDate, strSearchByToDate)

            Dim dtReportData As DataTable = New DataTable
            Dim colAccomName As DataColumn = New DataColumn("AgentName", Type.GetType("System.String"))
            Dim colAgentTotalBooking As DataColumn = New DataColumn("AgentTotalBooking", Type.GetType("System.String"))
            dtReportData.Columns.Add(colAccomName)
            dtReportData.Columns.Add(colAgentTotalBooking)
            If objFunction.CheckDataSet(dstReportAgentBooking) Then
                Trace.Warn("Count = " + objFunction.ReturnString(dstReportAgentBooking.Tables(0).Rows.Count))
                Dim dtDistinctData As DataTable = dstReportAgentBooking.Tables(0).DefaultView.ToTable(True, "agent_id")
                Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))

                If objFunction.CheckDataTable(dtDistinctData) Then
                    For i = 0 To dtDistinctData.Rows.Count - 1
                        Dim dtTemp As DataTable = dstReportAgentBooking.Tables(0)
                        Trace.Warn("agent_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("agent_id")))
                        dtTemp.DefaultView.RowFilter = "agent_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("agent_id"))
                        Dim dtData As DataTable = dtTemp.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtData) Then
                            Dim dr As DataRow = dtReportData.NewRow()
                            dr("AgentName") = objFunction.ReturnString(dtData.Rows(0)("AgentName"))
                            dr("AgentTotalBooking") = objFunction.ReturnString(dtData.Rows.Count)
                            dtReportData.Rows.Add(dr)
                        End If
                    Next
                End If
            End If

            GRID_Agent_Bookings.DataSource = dtReportData
            GRID_Agent_Bookings.DataBind()

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Agent_Bookings
    ''' </summary>
    Protected Sub GRID_Agent_Bookings_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Agent_Bookings.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Agent_Bookings
    ''' </summary>
    Protected Sub GRID_Agent_Bookings_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Agent_Bookings.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingId") = objFunction.ReturnString(GRID_Agent_Bookings.DataKeys(e.NewSelectedIndex).Value)
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' Clieck event of button to get record
    ''' </summary>
    Protected Sub BUT__Show_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Show_All.Click
        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetDateVal(ByVal value As Object) As String
        Try
            If objFunction.ReturnString(value) <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(value)
                Return dt.ToString("MM/dd/yyyy")
            Else
                Return ""
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return ""
    End Function

End Class