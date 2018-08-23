Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_client_notinvoiced
    Inherits System.Web.UI.Page

    Protected objFunction As New clsCommon()
    Protected objPaymentCalculation As clsPaymentCalculation = New clsPaymentCalculation

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

            Dim dstReportClientNonInvoiced As DataSet = (New clsDLBookingReport()).GetReportClientNonInvoiced(intCompanyId, strSearchByFromDate, strSearchByToDate)

            'Dim dstData As DataSet = dstReportClientNonInvoiced.Copy()
            'dstData.Clear()
            Dim dtReportData As DataTable = New DataTable
            Dim colBookingId As DataColumn = New DataColumn("BookingId", Type.GetType("System.String"))
            Dim colBookingUniqueId As DataColumn = New DataColumn("BookingUniqueId", Type.GetType("System.String"))
            Dim colClientName As DataColumn = New DataColumn("ClientName", Type.GetType("System.String"))
            Dim colAmountOutstanding As DataColumn = New DataColumn("AmountOutstanding", Type.GetType("System.String"))
            dtReportData.Columns.Add(colBookingId)
            dtReportData.Columns.Add(colBookingUniqueId)
            dtReportData.Columns.Add(colClientName)
            dtReportData.Columns.Add(colAmountOutstanding)
            If objFunction.CheckDataSet(dstReportClientNonInvoiced) Then
                Dim dtData As DataTable = dstReportClientNonInvoiced.Tables(0)
                For i = 0 To dtData.Rows.Count - 1
                    Dim dblTotalAmountPayable As Double = (New clsPaymentCalculation()).GetTotalAmountPayable(objFunction.ReturnInteger(dtData.Rows(i)("id")))
                    Dim dblTotalBalanceRemaining As Double = (New clsPaymentCalculation()).GetTotalBalanceRemaining(dblTotalAmountPayable, objFunction.ReturnInteger(dtData.Rows(i)("id")))
                    Dim dblAmountPaid As Double = dblTotalAmountPayable - dblTotalBalanceRemaining
                    If dblTotalAmountPayable <> dblAmountPaid Then
                        'dstData.Tables(0).Rows.Add(dstReportClientNonInvoiced.Tables(0).Rows(i))
                        Dim dr As DataRow = dtReportData.NewRow()
                        dr("BookingId") = objFunction.ReturnString(dtData.Rows(i)("id"))
                        dr("BookingUniqueId") = objFunction.ReturnString(dtData.Rows(i)("unique_id"))
                        dr("ClientName") = objFunction.ReturnString(dtData.Rows(i)("ClientName"))
                        dr("AmountOutstanding") = dblTotalBalanceRemaining.ToString("0.00")
                        dtReportData.Rows.Add(dr)
                    End If
                Next
            End If

            GRID_Client_notinvoiced.DataSource = dtReportData
            GRID_Client_notinvoiced.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Client_notinvoiced
    ''' </summary>
    Protected Sub GRID_Client_notinvoiced_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Client_notinvoiced.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Client_notinvoiced
    ''' </summary>
    Protected Sub GRID_Client_notinvoiced_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Client_notinvoiced.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingId") = objFunction.ReturnString(GRID_Client_notinvoiced.DataKeys(e.NewSelectedIndex).Value)
            Dim strUrl As String = "bookings_view.aspx"
            Response.Write("<script>")
            Response.Write("window.open('" + strUrl + "','_blank')")
            Response.Write("<" + "/script>")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class