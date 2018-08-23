Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_accom_bookings
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

            Dim dstReportNumberOfBookingPerAccom As DataSet = (New clsDLBookingReport()).GetReportNumberOfBookingPerAccom(intCompanyId, strSearchByFromDate, strSearchByToDate)

            Dim dtReportData As DataTable = New DataTable
            Dim colAccomName As DataColumn = New DataColumn("AccomName", Type.GetType("System.String"))
            Dim colNoOfBooking As DataColumn = New DataColumn("NoOfBooking", Type.GetType("System.String"))
            dtReportData.Columns.Add(colAccomName)
            dtReportData.Columns.Add(colNoOfBooking)
            If objFunction.CheckDataSet(dstReportNumberOfBookingPerAccom) Then
                Trace.Warn("Count = " + objFunction.ReturnString(dstReportNumberOfBookingPerAccom.Tables(0).Rows.Count))
                Dim dtDistinctData As DataTable = dstReportNumberOfBookingPerAccom.Tables(0).DefaultView.ToTable(True, "accomodation_id")
                Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))

                If objFunction.CheckDataTable(dtDistinctData) Then
                    For i = 0 To dtDistinctData.Rows.Count - 1
                        Dim dtTemp As DataTable = dstReportNumberOfBookingPerAccom.Tables(0)
                        dtTemp.DefaultView.RowFilter = "accomodation_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("accomodation_id"))
                        Dim dtData As DataTable = dtTemp.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtData) Then
                            Dim dr As DataRow = dtReportData.NewRow()
                            dr("AccomName") = objFunction.ReturnString(dtData.Rows(0)("AccomName"))
                            dr("NoOfBooking") = objFunction.ReturnString(dtData.Rows.Count)
                            dtReportData.Rows.Add(dr)
                        End If
                    Next
                End If
            End If

            If objFunction.CheckDataTable(dtReportData) Then
                GRID_Accom_Bookings.DataSource = dtReportData.Select("", "NoOfBooking DESC", DataViewRowState.CurrentRows).CopyToDataTable()
                GRID_Accom_Bookings.DataBind()
            Else
                GRID_Accom_Bookings.DataSource = dtReportData
                GRID_Accom_Bookings.DataBind()
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Accom_Bookings
    ''' </summary>
    Protected Sub GRID_Accom_Bookings_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Accom_Bookings.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class