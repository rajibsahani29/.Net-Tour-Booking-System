Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLExtrasBooking
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add extra booking.
        ''' </summary>
        Public Function AddExtrasBooking(ByVal objBEExtrasBooking As clsBEExtrasBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddExtrasBooking")
                cmd.Parameters.AddWithValue("ExtrasId", objBEExtrasBooking.ExtrasId)
                cmd.Parameters.AddWithValue("BookedYN", objBEExtrasBooking.BookedYN)
                cmd.Parameters.AddWithValue("BookedDate", (If(objBEExtrasBooking.BookedDate <> DateTime.MinValue, objBEExtrasBooking.BookedDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("CostEasyway", objBEExtrasBooking.CostEasyway)
                cmd.Parameters.AddWithValue("CostClient", objBEExtrasBooking.CostClient)
                cmd.Parameters.AddWithValue("BookingId", objBEExtrasBooking.BookingId)
                cmd.Parameters.AddWithValue("AccomStageId", objBEExtrasBooking.AccomStageId)
                cmd.Parameters.AddWithValue("Paidx", objBEExtrasBooking.Paidx)
                cmd.Parameters.AddWithValue("Invoicex", objBEExtrasBooking.Invoicex)
                cmd.Parameters.AddWithValue("AdditionalInfo", objBEExtrasBooking.AdditionalInfo)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddExtrasBooking")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update extra_invoiced by booking id.
        ''' </summary>
        Public Function UpdateExtraInvoicedByBookingId(ByVal objBEExtrasBooking As clsBEExtrasBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateExtraInvoicedByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEExtrasBooking.BookingId)
                cmd.Parameters.AddWithValue("ExtraInvoiced", objBEExtrasBooking.ExtraInvoiced)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateExtraInvoicedByBookingId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update set_paid by ExtrasBookingId.
        ''' </summary>
        Public Function UpdateSetPaidById(ByVal objBEExtrasBooking As clsBEExtrasBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateSetPaidById")
                cmd.Parameters.AddWithValue("ExtrasBookingId", objBEExtrasBooking.ExtrasBookingId)
                cmd.Parameters.AddWithValue("SetPaid", objBEExtrasBooking.SetPaid)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateSetPaidById")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete extras_booking by bookingid.
        ''' </summary>
        Public Function DeleteExtrasBookingByBookingId(ByVal intBookingId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteExtrasBookingByBookingId")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteExtrasBookingByBookingId")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get extras booking detail by id
        ''' </summary>
        Public Function GetExtrasBookingById(ByVal intExtrasBookingId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spExtrasBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtrasBookingById")
                cmd.Parameters.AddWithValue("ExtrasBookingId", intExtrasBookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtrasBookingById")
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
        ''' This function is used to get extras booking detail by booking id
        ''' </summary>
        Public Function GetExtrasBookingByBookingId(ByVal objBEExtrasBooking As clsBEExtrasBooking) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spExtrasBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtrasBookingByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEExtrasBooking.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtrasBookingByBookingId")
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
        ''' This function is used to get extras booking detail by booking id
        ''' </summary>
        Public Function GetExtrasDetailByBookingIdAndAccomStageIdFillInDD(ByVal objBEExtrasBooking As clsBEExtrasBooking) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spExtrasBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtrasDetailByBookingIdAndAccomStageIdFillInDD")
                cmd.Parameters.AddWithValue("BookingId", objBEExtrasBooking.BookingId)
                cmd.Parameters.AddWithValue("AccomStageId", objBEExtrasBooking.AccomStageId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtrasDetailByBookingIdAndAccomStageIdFillInDD")
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
        ''' This function is used to get extra detail by extra booking id.
        ''' </summary>
        Public Function GetExtraDetailByExtraBookingId(ByVal intExtrasBookingId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtraDetailByExtraBookingId")
                cmd.Parameters.AddWithValue("ExtrasBookingId", intExtrasBookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtraDetailByExtraBookingId")
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
        ''' This function is used to get extras booking detail by accom stage id
        ''' </summary>
        Public Function GetExtrasBookingByAccomStageId(ByVal objBEExtrasBooking As clsBEExtrasBooking) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spExtrasBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtrasBookingByAccomStageId")
                cmd.Parameters.AddWithValue("AccomStageId", objBEExtrasBooking.AccomStageId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtrasBookingByAccomStageId")
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
        ''' This function is used to perform gridview operation for extra bookings.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEExtrasBooking As clsBEExtrasBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBooking"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateExtrasBooking")
                    cmd.Parameters.AddWithValue("ExtrasBookingId", objBEExtrasBooking.ExtrasBookingId)
                    cmd.Parameters.AddWithValue("CostEasyway", objBEExtrasBooking.CostEasyway)
                    cmd.Parameters.AddWithValue("CostClient", objBEExtrasBooking.CostClient)
                    cmd.Parameters.AddWithValue("BookedYN", objBEExtrasBooking.BookedYN)
                    cmd.Parameters.AddWithValue("Invoicex", objBEExtrasBooking.Invoicex)
                    cmd.Parameters.AddWithValue("BookedDate", (If(objBEExtrasBooking.BookedDate <> DateTime.MinValue, objBEExtrasBooking.BookedDate, DateTime.Now)))
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteExtrasBookingById")
                    cmd.Parameters.AddWithValue("ExtrasBookingId", objBEExtrasBooking.ExtrasBookingId)
                End If
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "PerformGridViewOpertaion")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace