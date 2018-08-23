Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_financial
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
                DROP_Route.Items.Insert(0, New ListItem("All", ""))

                Dim dstAgent As DataSet = (New clsDLAgent()).GetAgentDetailFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Agent, dstAgent)
                DROP_Agent.Items.Insert(0, New ListItem("All", ""))

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Click event of the button
    ''' </summary>
    Protected Sub BUT__View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__View.Click
        Try
            GetFinancialReportData()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to GetTotalNumberOfBooking
    ''' </summary>
    Protected Sub GetFinancialReportData()

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
            Dim strSearchByAgent As String = objFunction.ReturnString(DROP_Agent.SelectedItem.Value)
            Dim strSearchByCustomised As String = objFunction.ReturnString(RADIO_Customised_Fixed_All.SelectedItem.Value)

            Dim dstTotalNumberOfBooking As DataSet = (New clsDLBookingReport()).GetFinancialReportData(intCompanyId, strSearchByFromDate, strSearchByToDate, strSearchByRoute, strSearchByAgent, strSearchByCustomised)
            Dim intTotalNumberOfBooking As Integer = 0
            If objFunction.CheckDataSet(dstTotalNumberOfBooking) Then
                Dim dtData As DataTable = dstTotalNumberOfBooking.Tables(0)
                intTotalNumberOfBooking = objFunction.ReturnInteger(dtData.Compute("SUM(total_num)", String.Empty))
                'intTotalNumberOfBooking = objFunction.ReturnInteger(dstTotalNumberOfBooking.Tables(0).Rows(0)("Result"))
                LABEL_Oldest_Value.Text = objFunction.ReturnString(intTotalNumberOfBooking)
            Else
                LABEL_Oldest_Value.Text = "0"
            End If

            If objFunction.ReturnInteger(RADIO_Customised_Fixed_All.SelectedItem.Value) = 1 Then
                LABEL_Newest_Value.Text = "£" + "0"
            Else
                Dim objBEBookingFee As clsBEBookingFee = New clsBEBookingFee
                Dim objDLBookingFee As clsDLBookingFee = New clsDLBookingFee
                objBEBookingFee.TotalNum = 1
                objBEBookingFee.CompanyId = intCompanyId
                Dim dstBookingFee As DataSet = objDLBookingFee.GetBookingFeeByCompanyIdAndTotalNum(objBEBookingFee)
                Dim dblBookingFeeAmount As Double = 0
                If objFunction.CheckDataSet(dstBookingFee) Then
                    dblBookingFeeAmount = objFunction.ReturnDouble(dstBookingFee.Tables(0).Rows(0)("fee_total"))
                End If
                LABEL_Newest_Value.Text = "£" + objFunction.ReturnDouble(dblBookingFeeAmount * intTotalNumberOfBooking).ToString("0.00")
            End If

            Dim dblBookingPayment As Double = 0
            If objFunction.CheckDataSet(dstTotalNumberOfBooking) Then
                For i = 0 To dstTotalNumberOfBooking.Tables(0).Rows.Count - 1
                    Dim objBEBookingPayments As clsBEBookingPayments = New clsBEBookingPayments
                    Dim objDLBookingPayments As clsDLBookingPayments = New clsDLBookingPayments
                    objBEBookingPayments.BookingId = objFunction.ReturnInteger(dstTotalNumberOfBooking.Tables(0).Rows(i)("id"))
                    Dim dstBookingPayments As DataSet = objDLBookingPayments.GetBookingPaymentsByBookingId(objBEBookingPayments)
                    If objFunction.CheckDataSet(dstBookingPayments) Then
                        Dim dtData As DataTable = dstBookingPayments.Tables(0)
                        dblBookingPayment += objFunction.ReturnDouble(dtData.Compute("SUM(cc_charge)", String.Empty))
                    End If
                Next
            End If
            LABEL_Smallest_Value.Text = "£" + dblBookingPayment.ToString("0.00")

            Dim dblTotalCostEasyway As Double = 0
            If objFunction.CheckDataSet(dstTotalNumberOfBooking) Then
                For i = 0 To dstTotalNumberOfBooking.Tables(0).Rows.Count - 1
                    dblTotalCostEasyway += (New clsPaymentCalculation()).GetCostToEasyway(objFunction.ReturnInteger(dstTotalNumberOfBooking.Tables(0).Rows(i)("id")))
                Next
            End If
            LABEL_Largest_Value.Text = "£" + dblTotalCostEasyway.ToString("0.00")

            Dim dblTotalCostClient As Double = 0
            If objFunction.CheckDataSet(dstTotalNumberOfBooking) Then
                For i = 0 To dstTotalNumberOfBooking.Tables(0).Rows.Count - 1
                    dblTotalCostClient += (New clsPaymentCalculation()).GetTotalAmountPayable(objFunction.ReturnInteger(dstTotalNumberOfBooking.Tables(0).Rows(i)("id")))
                Next
            End If
            LABEL_Total_No_Value.Text = "£" + dblTotalCostClient.ToString("0.00")

            LABEL_Total_Agent_Value.Text = "£" + objFunction.ReturnDouble(dblTotalCostClient - dblTotalCostEasyway).ToString("0.00")

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class