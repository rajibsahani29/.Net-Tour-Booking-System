Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLExtrasInvoicedBookings
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add extras_invoiced_bookings.
        ''' </summary>
        Public Function AddExtrasInvoicedBookings(ByVal objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddExtrasInvoicedBookings")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtrasInvoicedBookings.ExtraId)
                cmd.Parameters.AddWithValue("BookingId", objBEExtrasInvoicedBookings.BookingId)
                cmd.Parameters.AddWithValue("DateEntered", objBEExtrasInvoicedBookings.DateEntered)
                cmd.Parameters.AddWithValue("MonthVal", objBEExtrasInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEExtrasInvoicedBookings.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEExtrasInvoicedBookings.SupplierType)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddExtrasInvoicedBookings")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update date_lastupdated by extra_id.
        ''' </summary>
        Public Function UpdateDateLastUpdatedByExtraId(ByVal objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateDateLastUpdatedByExtraId")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtrasInvoicedBookings.ExtraId)
                cmd.Parameters.AddWithValue("MonthVal", objBEExtrasInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEExtrasInvoicedBookings.YearVal)
                cmd.Parameters.AddWithValue("DateLastUpdated", objBEExtrasInvoicedBookings.DateLastUpdated)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateDateLastUpdatedByExtraId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update date_sent by extra_id.
        ''' </summary>
        Public Function UpdateDateSentByExtraId(ByVal objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateDateSentByExtraId")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtrasInvoicedBookings.ExtraId)
                cmd.Parameters.AddWithValue("MonthVal", objBEExtrasInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEExtrasInvoicedBookings.YearVal)
                cmd.Parameters.AddWithValue("DateSent", objBEExtrasInvoicedBookings.DateSent)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateDateSentByExtraId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get dashboard GetUniqueExtraDetailByMonthAndYear.
        ''' </summary>
        Public Function GetUniqueExtraDetailByMonthYearAndSupplierType(ByVal objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetUniqueExtraDetailByMonthYearAndSupplierType")
                cmd.Parameters.AddWithValue("MonthVal", objBEExtrasInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEExtrasInvoicedBookings.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEExtrasInvoicedBookings.SupplierType)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetUniqueExtraDetailByMonthYearAndSupplierType")
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
        ''' This function is used to get dashboard GetExtraDetailByMonthYearAndExtraId.
        ''' </summary>
        Public Function GetExtraDetailByMonthYearAndExtraId(ByVal objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtraDetailByMonthYearAndExtraId")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtrasInvoicedBookings.ExtraId)
                cmd.Parameters.AddWithValue("MonthVal", objBEExtrasInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEExtrasInvoicedBookings.YearVal)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtraDetailByMonthYearAndExtraId")
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
        ''' This function is used to get dashboard extras_invoiced_bookings by year, month, extra_id and supplier_type.
        ''' </summary>
        Public Function GetExtraDetailByMonthYearExtraIdAndSupplierType(ByVal objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtraDetailByMonthYearExtraIdAndSupplierType")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtrasInvoicedBookings.ExtraId)
                cmd.Parameters.AddWithValue("MonthVal", objBEExtrasInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEExtrasInvoicedBookings.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEExtrasInvoicedBookings.SupplierType)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtraDetailByMonthYearExtraIdAndSupplierType")
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
        ''' This function is used to get dashboard extras_invoiced_bookings by year, month, extra_id and supplier_type.
        ''' </summary>
        Public Function DeleteExtraDetailByMonthYearExtraIdAndSupplierType(ByVal objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings, ByVal intCompanyId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteExtraDetailByMonthYearExtraIdAndSupplierType")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtrasInvoicedBookings.ExtraId)
                cmd.Parameters.AddWithValue("MonthVal", objBEExtrasInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEExtrasInvoicedBookings.YearVal)
                cmd.Parameters.AddWithValue("SupplierType", objBEExtrasInvoicedBookings.SupplierType)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteExtraDetailByMonthYearExtraIdAndSupplierType")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace


