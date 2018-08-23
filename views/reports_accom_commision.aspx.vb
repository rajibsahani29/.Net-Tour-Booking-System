Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_accom_commision
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
                Dim dstRoute As DataSet = (New clsDLRoute()).GetRouteFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Route, dstRoute)
                DROP_Route.Items.Insert(0, New ListItem("Select Route", ""))

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

            Dim strSearchByRoute As String = objFunction.ReturnString(DROP_Route.SelectedItem.Value)

            Dim dstReportAccomCommision As DataSet = (New clsDLBookingReport()).GetReportAccomCommision(intCompanyId, strSearchByFromDate, strSearchByToDate, strSearchByRoute)

            Dim dtReportData As DataTable = New DataTable
            Dim colAccomName As DataColumn = New DataColumn("AccomName", Type.GetType("System.String"))
            Dim colRouteName As DataColumn = New DataColumn("RouteName", Type.GetType("System.String"))
            Dim colNoOfBooking As DataColumn = New DataColumn("NoOfBooking", Type.GetType("System.String"))
            dtReportData.Columns.Add(colAccomName)
            dtReportData.Columns.Add(colRouteName)
            dtReportData.Columns.Add(colNoOfBooking)
            If objFunction.CheckDataSet(dstReportAccomCommision) Then
                Trace.Warn("Count = " + objFunction.ReturnString(dstReportAccomCommision.Tables(0).Rows.Count))
                Dim dtDistinctData As DataTable = dstReportAccomCommision.Tables(0).DefaultView.ToTable(True, "accomodation_id")
                Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))

                If objFunction.CheckDataTable(dtDistinctData) Then
                    For i = 0 To dtDistinctData.Rows.Count - 1
                        Dim dtTemp As DataTable = dstReportAccomCommision.Tables(0)
                        Trace.Warn("accomodation_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("accomodation_id")))
                        dtTemp.DefaultView.RowFilter = "accomodation_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("accomodation_id"))
                        Dim dtData As DataTable = dtTemp.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtData) Then
                            Dim TotalNoOfBooking As Integer = objFunction.ReturnInteger(dtData.Compute("SUM(total_num)", String.Empty))
                            Trace.Warn("TotalNoOfBooking = " + objFunction.ReturnString(TotalNoOfBooking))
                            If TotalNoOfBooking >= 50 Then
                                Dim dr As DataRow = dtReportData.NewRow()
                                dr("AccomName") = objFunction.ReturnString(dtData.Rows(0)("AccomName"))
                                dr("RouteName") = objFunction.ReturnString(dtData.Rows(0)("RouteName"))
                                dr("NoOfBooking") = objFunction.ReturnString(TotalNoOfBooking)
                                dtReportData.Rows.Add(dr)
                            End If
                        End If
                    Next
                End If
            End If

            If objFunction.CheckDataTable(dtReportData) Then
                GRID_Accom_Commision.DataSource = dtReportData.Select("", "NoOfBooking DESC", DataViewRowState.CurrentRows).CopyToDataTable()
                GRID_Accom_Commision.DataBind()
            Else
                GRID_Accom_Commision.DataSource = dtReportData
                GRID_Accom_Commision.DataBind()
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Accom_Commision
    ''' </summary>
    Protected Sub GRID_Accom_Commision_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Accom_Commision.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class