Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class views_reports_supplier_payments_due_print
    Inherits System.Web.UI.Page

    Protected objFunction As New clsCommon()
    Protected dstData As DataSet

    Protected intSupplierType As Integer = 0
    Protected intMonth As Integer = 0
    Protected intYear As Integer = 0

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            If Not Page.IsPostBack Then

                BindData()

            End If

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

            Trace.Warn("Supplier_Payment_MM = " + objFunction.ReturnString(Session("Print_Supplier_Payment_MM")))
            Trace.Warn("Supplier_Payment_YYYY = " + objFunction.ReturnString(Session("Print_Supplier_Payment_YYYY")))
            Trace.Warn("Supplier_Payment_Type = " + objFunction.ReturnString(Session("Print_Supplier_Payment_Type")))

            If objFunction.ReturnString(Session("Print_Supplier_Payment_Type")) <> "" Then
                intSupplierType = objFunction.ReturnInteger(Session("Print_Supplier_Payment_Type"))
            End If

            If objFunction.ReturnString(Session("Print_Supplier_Payment_MM")) <> "" Then
                intMonth = objFunction.ReturnInteger(Session("Print_Supplier_Payment_MM"))
            Else
                intMonth = objFunction.ReturnInteger(DateTime.Now.Month)
            End If

            If objFunction.ReturnString(Session("Print_Supplier_Payment_YYYY")) <> "" Then
                intYear = objFunction.ReturnInteger(Session("Print_Supplier_Payment_YYYY"))
            Else
                intYear = objFunction.ReturnInteger(DateTime.Now.Year)
            End If

            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            Dim objDLPaymentToSupplier As clsDLPaymentToSupplier = New clsDLPaymentToSupplier

            If intSupplierType = 1 Then
                objBEPaymentToSupplier.MonthVal = intMonth
                objBEPaymentToSupplier.YearVal = intYear
                objBEPaymentToSupplier.SupplierType = intSupplierType
                dstData = objDLPaymentToSupplier.GetSupplierDetailByMonthYearAndSupplierType(objBEPaymentToSupplier, intCompanyId)
            ElseIf intSupplierType = 2 Then
                objBEPaymentToSupplier.MonthVal = intMonth
                objBEPaymentToSupplier.YearVal = intYear
                objBEPaymentToSupplier.SupplierType = intSupplierType
                dstData = objDLPaymentToSupplier.GetSupplierDetailByMonthYearAndSupplierType(objBEPaymentToSupplier, intCompanyId)
            ElseIf intSupplierType = 3 Then
                objBEPaymentToSupplier.MonthVal = intMonth
                objBEPaymentToSupplier.YearVal = intYear
                objBEPaymentToSupplier.SupplierType = intSupplierType
                dstData = objDLPaymentToSupplier.GetSupplierDetailByMonthYearAndSupplierType(objBEPaymentToSupplier, intCompanyId)
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class
