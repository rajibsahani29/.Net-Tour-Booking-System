Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLPaymentToSupplierEmailSent
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add paymentTo_supplier_email_sent.
        ''' </summary>
        Public Function AddPaymentToSupplierEmailSent(ByVal objBEPaymentToSupplierEmailSent As clsBEPaymentToSupplierEmailSent) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplierEmailSent"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddPaymentToSupplierEmailSent")
                cmd.Parameters.AddWithValue("SupplierId", objBEPaymentToSupplierEmailSent.SupplierId)
                cmd.Parameters.AddWithValue("DateEntered", objBEPaymentToSupplierEmailSent.DateEntered)
                cmd.Parameters.AddWithValue("MonthVal", objBEPaymentToSupplierEmailSent.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEPaymentToSupplierEmailSent.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEPaymentToSupplierEmailSent.SupplierType)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddPaymentToSupplierEmailSent")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get dashboard GetSupplierEmailDetailByMonthYearAndSupplierType.
        ''' </summary>
        Public Function GetSupplierEmailDetailByMonthYearAndSupplierType(ByVal objBEPaymentToSupplierEmailSent As clsBEPaymentToSupplierEmailSent, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplierEmailSent"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSupplierEmailDetailByMonthYearAndSupplierType")
                cmd.Parameters.AddWithValue("MonthVal", objBEPaymentToSupplierEmailSent.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEPaymentToSupplierEmailSent.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEPaymentToSupplierEmailSent.SupplierType)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSupplierEmailDetailByMonthYearAndSupplierType")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace
