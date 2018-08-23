Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_bookings_payments_rec_out
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

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstAgent As DataSet = (New clsDLAgent()).GetAgentDetailFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Agent, dstAgent)
                DROP_Agent.Items.Insert(0, New ListItem("All Clients", ""))
                DROP_Agent.Items.Insert(1, New ListItem("Easyways Clients", "0"))
                
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

            Dim strSearchByAgent As String = DROP_Agent.SelectedItem.Value

            Dim dstReportBookingPaymentsRecOut As DataSet = (New clsDLBookingReport()).GetReportBookingPaymentsRecOut(intCompanyId, strSearchByFromDate, strSearchByToDate, strSearchByAgent)
            GRID_Payments_Rec_Out.DataSource = dstReportBookingPaymentsRecOut
            GRID_Payments_Rec_Out.DataBind()

            For i As Integer = 0 To GRID_Payments_Rec_Out.Rows.Count - 1
                Dim gRow As GridViewRow = GRID_Payments_Rec_Out.Rows(i)
                Dim lblTotalCost As Label = DirectCast(gRow.FindControl("LABEL_TotalCost"), Label)
                Dim lblAmountReceived As Label = DirectCast(gRow.FindControl("LABEL_AmountReceived"), Label)
                Dim lblAmountOutstanding As Label = DirectCast(gRow.FindControl("LABEL_AmountOutstanding"), Label)
                Dim hdnBookingId As HiddenField = DirectCast(gRow.FindControl("hdnBookingId"), HiddenField)
                Trace.Warn("hdnBookingId = " + objFunction.ReturnString(hdnBookingId.Value))
                Dim dblTotalAmountPayable As Double = (New clsPaymentCalculation()).GetTotalAmountPayable(objFunction.ReturnInteger(hdnBookingId.Value))
                Dim dblTotalBalanceRemaining As Double = (New clsPaymentCalculation()).GetTotalBalanceRemaining(dblTotalAmountPayable, objFunction.ReturnInteger(hdnBookingId.Value))

                lblTotalCost.Text = dblTotalAmountPayable.ToString("0.00")
                lblAmountReceived.Text = (dblTotalAmountPayable - dblTotalBalanceRemaining).ToString("0.00")
                lblAmountOutstanding.Text = dblTotalBalanceRemaining.ToString("0.00")
            Next

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Payments_Rec_Out
    ''' </summary>
    Protected Sub GRID_Payments_Rec_Out_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Payments_Rec_Out.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Payments_Rec_Out
    ''' </summary>
    Protected Sub GRID_Payments_Rec_Out_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Payments_Rec_Out.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingId") = objFunction.ReturnString(GRID_Payments_Rec_Out.DataKeys(e.NewSelectedIndex).Value)
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Clieck event of button to get record
    ''' </summary>
    Protected Sub BUT__Show_Payments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Show_Payments.Click
        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class