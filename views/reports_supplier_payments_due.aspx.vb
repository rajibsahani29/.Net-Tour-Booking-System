Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_supplier_payments_due
    Inherits System.Web.UI.Page

    Protected objFunction As New clsCommon()
    Protected dstData As DataSet
    
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

                Trace.Warn("Supplier_Payment_MM = " + objFunction.ReturnString(Session("Supplier_Payment_MM")))
                Trace.Warn("Supplier_Payment_YYYY = " + objFunction.ReturnString(Session("Supplier_Payment_YYYY")))
                Trace.Warn("Supplier_Payment_Type = " + objFunction.ReturnString(Session("Supplier_Payment_Type")))

                If objFunction.ReturnString(Session("Supplier_Payment_MM")) <> "" Then
                    DROP_Month.SelectedValue = objFunction.ReturnString(Session("Supplier_Payment_MM"))
                Else
                    If DROP_Month.Items.FindByValue(objFunction.ReturnString(DateTime.Now.Month)) IsNot Nothing Then
                        DROP_Month.Items.FindByValue(objFunction.ReturnString(DateTime.Now.Month)).Selected = True
                    Else
                        DROP_Month.SelectedIndex = 0
                    End If
                End If

                If objFunction.ReturnString(Session("Supplier_Payment_YYYY")) <> "" Then
                    DROP_Year.SelectedValue = objFunction.ReturnString(Session("Supplier_Payment_YYYY"))
                Else
                    If DROP_Year.Items.FindByValue(objFunction.ReturnString(DateTime.Now.Year)) IsNot Nothing Then
                        DROP_Year.Items.FindByValue(objFunction.ReturnString(DateTime.Now.Year)).Selected = True
                    Else
                        DROP_Year.SelectedIndex = 0
                    End If
                End If

                If objFunction.ReturnString(Session("Supplier_Payment_Type")) <> "" Then
                    DROP_Supplier_Type.SelectedValue = objFunction.ReturnString(Session("Supplier_Payment_Type"))
                End If

                BindData()

            End If

            'BindData()

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindData()

        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            Dim objDLPaymentToSupplier As clsDLPaymentToSupplier = New clsDLPaymentToSupplier

            Session("Print_Supplier_Payment_MM") = objFunction.ReturnString(DROP_Month.SelectedItem.Value)
            Session("Print_Supplier_Payment_YYYY") = objFunction.ReturnString(DROP_Year.SelectedItem.Value)
            Session("Print_Supplier_Payment_Type") = objFunction.ReturnString(DROP_Supplier_Type.SelectedItem.Value)

            If objFunction.ReturnInteger(DROP_Supplier_Type.SelectedItem.Value) = 1 Then
                objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(DROP_Month.SelectedItem.Value)
                objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(DROP_Year.SelectedItem.Value)
                objBEPaymentToSupplier.SupplierType = objFunction.ReturnInteger(DROP_Supplier_Type.SelectedItem.Value)
                dstData = objDLPaymentToSupplier.GetSupplierDetailByMonthYearAndSupplierType(objBEPaymentToSupplier, intCompanyId)
            ElseIf objFunction.ReturnInteger(DROP_Supplier_Type.SelectedItem.Value) = 2 Then
                objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(DROP_Month.SelectedItem.Value)
                objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(DROP_Year.SelectedItem.Value)
                objBEPaymentToSupplier.SupplierType = objFunction.ReturnInteger(DROP_Supplier_Type.SelectedItem.Value)
                dstData = objDLPaymentToSupplier.GetSupplierDetailByMonthYearAndSupplierType(objBEPaymentToSupplier, intCompanyId)
            ElseIf objFunction.ReturnInteger(DROP_Supplier_Type.SelectedItem.Value) = 3 Then
                objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(DROP_Month.SelectedItem.Value)
                objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(DROP_Year.SelectedItem.Value)
                objBEPaymentToSupplier.SupplierType = objFunction.ReturnInteger(DROP_Supplier_Type.SelectedItem.Value)
                dstData = objDLPaymentToSupplier.GetSupplierDetailByMonthYearAndSupplierType(objBEPaymentToSupplier, intCompanyId)
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Click event of button
    ''' </summary>
    Protected Sub BUT_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_View.Click
        Try
            BindData()
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
                Return dt.ToString("dd-MM-yyyy")
            Else
                Return ""
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return ""
    End Function

    'Protected Sub BUT_Print_Click(sender As Object, e As System.EventArgs) Handles BUT_Print.Click
    '    Try
    '        Session("Print_Supplier_Payment_MM") = objFunction.ReturnString(DROP_Month.SelectedItem.Value)
    '        Session("Print_Supplier_Payment_YYYY") = objFunction.ReturnString(DROP_Year.SelectedItem.Value)
    '        Session("Print_Supplier_Payment_Type") = objFunction.ReturnString(DROP_Supplier_Type.SelectedItem.Value)
    '        'Response.Redirect("reports_supplier_payments_due_print.aspx")
    '        Dim strUrl As String = "reports_supplier_payments_due_print.aspx"
    '        Response.Write("<script>")
    '        Response.Write("window.open('" + strUrl + "','_blank')")
    '        Response.Write("<" + "/script>")
    '    Catch ex As Exception
    '        HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
    '        HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
    '    End Try
    'End Sub
End Class