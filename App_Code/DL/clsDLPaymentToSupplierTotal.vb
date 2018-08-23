Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLPaymentToSupplierTotal
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add paymentTo_supplier_total.
        ''' </summary>
        Public Function AddPaymentToSupplierTotal(ByVal objBEPaymentToSupplierTotal As clsBEPaymentToSupplierTotal) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplierTotal"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddPaymentToSupplierTotal")
                cmd.Parameters.AddWithValue("SupplierId", objBEPaymentToSupplierTotal.SupplierId)
                cmd.Parameters.AddWithValue("MonthVal", objBEPaymentToSupplierTotal.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEPaymentToSupplierTotal.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEPaymentToSupplierTotal.SupplierType)
                cmd.Parameters.AddWithValue("TotalAmount", objBEPaymentToSupplierTotal.TotalAmount)
                cmd.Parameters.AddWithValue("DatePaid", (If(objBEPaymentToSupplierTotal.DatePaid <> DateTime.MinValue, objBEPaymentToSupplierTotal.DatePaid, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("Paid", objBEPaymentToSupplierTotal.Paid)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddPaymentToSupplierTotal")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add paymentTo_supplier_total.
        ''' </summary>
        Public Function UpdatePaymentToSupplierTotalPaidAndDatePaid(ByVal objBEPaymentToSupplierTotal As clsBEPaymentToSupplierTotal) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplierTotal"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdatePaymentToSupplierTotalPaidAndDatePaid")
                cmd.Parameters.AddWithValue("PaymentToSupplierTotalId", objBEPaymentToSupplierTotal.PaymentToSupplierTotalId)
                cmd.Parameters.AddWithValue("DatePaid", (If(objBEPaymentToSupplierTotal.DatePaid <> DateTime.MinValue, objBEPaymentToSupplierTotal.DatePaid, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("Paid", objBEPaymentToSupplierTotal.Paid)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdatePaymentToSupplierTotalPaidAndDatePaid")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to GetSupplierDetailByMonthYearSupplierIdAndSupplierType.
        ''' </summary>
        Public Function GetSupplierDetailByMonthYearSupplierIdAndSupplierType(ByVal objBEPaymentToSupplierTotal As clsBEPaymentToSupplierTotal) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplierTotal"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSupplierDetailByMonthYearSupplierIdAndSupplierType")
                cmd.Parameters.AddWithValue("SupplierId", objBEPaymentToSupplierTotal.SupplierId)
                cmd.Parameters.AddWithValue("MonthVal", objBEPaymentToSupplierTotal.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEPaymentToSupplierTotal.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEPaymentToSupplierTotal.SupplierType)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSupplierDetailByMonthYearSupplierIdAndSupplierType")
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