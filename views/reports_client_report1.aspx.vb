Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_client_report1
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

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub BUT__View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__View.Click
        Try
            BindGridview()
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

            Dim dstClientReport1 As DataSet = (New clsDLBookingReport()).GetClientReport1(intCompanyId, strSearchByFromDate, strSearchByToDate)

            Dim dtReportData As DataTable = New DataTable
            Dim colClientId As DataColumn = New DataColumn("ClientId", Type.GetType("System.String"))
            Dim colClientName As DataColumn = New DataColumn("ClientName", Type.GetType("System.String"))
            Dim colNoOfBooking As DataColumn = New DataColumn("NoOfBooking", Type.GetType("System.String"))
            dtReportData.Columns.Add(colClientId)
            dtReportData.Columns.Add(colClientName)
            dtReportData.Columns.Add(colNoOfBooking)
            If objFunction.CheckDataSet(dstClientReport1) Then
                Trace.Warn("Count = " + objFunction.ReturnString(dstClientReport1.Tables(0).Rows.Count))
                Dim dtDistinctData As DataTable = dstClientReport1.Tables(0).DefaultView.ToTable(True, "ClientId")
                Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))

                If objFunction.CheckDataTable(dtDistinctData) Then
                    For i = 0 To dtDistinctData.Rows.Count - 1
                        Dim dtTemp As DataTable = dstClientReport1.Tables(0)
                        dtTemp.DefaultView.RowFilter = "ClientId = " + objFunction.ReturnString(dtDistinctData.Rows(i)("ClientId"))
                        Dim dtData As DataTable = dtTemp.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtData) Then
                            Dim dr As DataRow = dtReportData.NewRow()
                            dr("ClientId") = objFunction.ReturnString(dtData.Rows(0)("ClientId"))
                            dr("ClientName") = objFunction.ReturnString(dtData.Rows(0)("ClientName"))
                            dr("NoOfBooking") = objFunction.ReturnString(dtData.Rows.Count)
                            dtReportData.Rows.Add(dr)
                        End If
                    Next
                End If
            End If

            'GRID_Client_Report1.DataSource = dtReportData.Select("", "NoOfBooking DESC", DataViewRowState.CurrentRows).CopyToDataTable()
            GRID_Client_Report1.DataSource = dtReportData
            GRID_Client_Report1.DataBind()

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Client_Report1
    ''' </summary>
    Protected Sub GRID_Client_Report1_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Client_Report1.DataKeys(e.NewSelectedIndex).Value))
            Session("EditClientId") = objFunction.ReturnString(GRID_Client_Report1.DataKeys(e.NewSelectedIndex).Value)
            'Session("RequestPage") = "BookingView"
            Dim strUrl = "bookings_edit_client.aspx"
            Response.Write("<script>")
            Response.Write("window.open('" + strUrl + "','_blank')")
            Response.Write("<" + "/script>")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Client_Report1
    ''' </summary>
    Protected Sub GRID_Client_Report1_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Client_Report1.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class