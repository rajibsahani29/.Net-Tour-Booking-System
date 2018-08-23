Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLPaymentToSupplier
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add paymentTo_supplier.
        ''' </summary>
        Public Function AddPaymentToSupplier(ByVal objBEPaymentToSupplier As clsBEPaymentToSupplier) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplier"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddPaymentToSupplier")
                cmd.Parameters.AddWithValue("SupplierId", objBEPaymentToSupplier.SupplierId)
                cmd.Parameters.AddWithValue("BookingId", objBEPaymentToSupplier.BookingId)
                cmd.Parameters.AddWithValue("DateEntered", objBEPaymentToSupplier.DateEntered)
                cmd.Parameters.AddWithValue("MonthVal", objBEPaymentToSupplier.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEPaymentToSupplier.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEPaymentToSupplier.SupplierType)
                cmd.Parameters.AddWithValue("AccomStageId", objBEPaymentToSupplier.AccomStageId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddPaymentToSupplier")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update paymentTo_supplier date_paid and paid status.
        ''' </summary>
        Public Function UpdatePaidStatusAndPaidDate(ByVal objBEPaymentToSupplier As clsBEPaymentToSupplier) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplier"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdatePaidStatusAndPaidDate")
                cmd.Parameters.AddWithValue("PaymentToSupplierId", objBEPaymentToSupplier.PaymentToSupplierId)
                cmd.Parameters.AddWithValue("DatePaid", (If(objBEPaymentToSupplier.DatePaid <> DateTime.MinValue, objBEPaymentToSupplier.DatePaid, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("Paid", objBEPaymentToSupplier.Paid)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdatePaidStatusAndPaidDate")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get paymentTo_supplier detail by bookingid,supplierid and suppliertype.
        ''' </summary>
        Public Function GetSupplierDetailByBookingIdSupplierIdAndSupplierType(ByVal objBEPaymentToSupplier As clsBEPaymentToSupplier) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplier"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSupplierDetailByBookingIdSupplierIdAndSupplierType")
                cmd.Parameters.AddWithValue("BookingId", objBEPaymentToSupplier.BookingId)
                cmd.Parameters.AddWithValue("SupplierId", objBEPaymentToSupplier.SupplierId)
                cmd.Parameters.AddWithValue("SupplierType", objBEPaymentToSupplier.SupplierType)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSupplierDetailByBookingIdSupplierIdAndSupplierType")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get paymentTo_supplier detail by month,year and suppliertype.
        ''' </summary>
        Public Function GetSupplierDetailByMonthYearAndSupplierType(ByVal objBEPaymentToSupplier As clsBEPaymentToSupplier, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplier"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSupplierDetailByMonthYearAndSupplierType")
                cmd.Parameters.AddWithValue("MonthVal", objBEPaymentToSupplier.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEPaymentToSupplier.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEPaymentToSupplier.SupplierType)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSupplierDetailByMonthYearAndSupplierType")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get paymentTo_supplier detail by month,year, suppliertype and supplierid.
        ''' </summary>
        Public Function GetSupplierDetailByMonthYearSupplierTypeAndSupplierId(ByVal objBEPaymentToSupplier As clsBEPaymentToSupplier, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplier"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSupplierDetailByMonthYearSupplierTypeAndSupplierId")
                cmd.Parameters.AddWithValue("SupplierId", objBEPaymentToSupplier.SupplierId)
                cmd.Parameters.AddWithValue("MonthVal", objBEPaymentToSupplier.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEPaymentToSupplier.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEPaymentToSupplier.SupplierType)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSupplierDetailByMonthYearSupplierTypeAndSupplierId")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get paymentTo_supplier detail by month, year, suppliertype and company_id.
        ''' </summary>
        Public Function GetSupplierDetailByMonthYearSupplierTypeAndCompanyId(ByVal objBEPaymentToSupplier As clsBEPaymentToSupplier, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplier"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSupplierDetailByMonthYearSupplierTypeAndCompanyId")
                cmd.Parameters.AddWithValue("MonthVal", objBEPaymentToSupplier.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEPaymentToSupplier.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEPaymentToSupplier.SupplierType)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSupplierDetailByMonthYearSupplierTypeAndCompanyId")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete paymentTo_supplier detail by month, year, suppliertype and company_id.
        ''' </summary>
        Public Function DeleteSupplierDetailByMonthYearSupplierTypeAndCompanyId(ByVal objBEPaymentToSupplier As clsBEPaymentToSupplier, ByVal intCompanyId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplier"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteSupplierDetailByMonthYearSupplierTypeAndCompanyId")
                cmd.Parameters.AddWithValue("MonthVal", objBEPaymentToSupplier.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEPaymentToSupplier.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEPaymentToSupplier.SupplierType)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteSupplierDetailByMonthYearSupplierTypeAndCompanyId")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get paymentTo_supplier detail by addom_stage_id, suppliertype and company_id.
        ''' </summary>
        Public Function GetSupplierDetailBySupplierTypeAndCompanyId(ByVal objBEPaymentToSupplier As clsBEPaymentToSupplier, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentToSupplier"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSupplierDetailBySupplierTypeAndCompanyId")
                cmd.Parameters.AddWithValue("SupplierType", objBEPaymentToSupplier.SupplierType)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSupplierDetailBySupplierTypeAndCompanyId")
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