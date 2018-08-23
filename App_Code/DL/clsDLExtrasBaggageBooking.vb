Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLExtrasBaggageBooking
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add extra booking.
        ''' </summary>
        Public Function AddExtrasBaggageBooking(ByVal objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddExtrasBaggageBooking")
                cmd.Parameters.AddWithValue("ExtrasBaggageLinkRouteId", objBEExtrasBaggageBooking.ExtrasBaggageLinkRouteId)
                cmd.Parameters.AddWithValue("BookedYN", objBEExtrasBaggageBooking.BookedYN)
                cmd.Parameters.AddWithValue("BookedDate", (If(objBEExtrasBaggageBooking.BookedDate <> DateTime.MinValue, objBEExtrasBaggageBooking.BookedDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("CostEasyway", objBEExtrasBaggageBooking.CostEasyway)
                cmd.Parameters.AddWithValue("CostClient", objBEExtrasBaggageBooking.CostClient)
                cmd.Parameters.AddWithValue("BookingId", objBEExtrasBaggageBooking.BookingId)
                cmd.Parameters.AddWithValue("Paidx", objBEExtrasBaggageBooking.Paidx)
                cmd.Parameters.AddWithValue("Invoicex", objBEExtrasBaggageBooking.Invoicex)
                cmd.Parameters.AddWithValue("Instructionx", objBEExtrasBaggageBooking.Instructionx)
                cmd.Parameters.AddWithValue("NoBags", objBEExtrasBaggageBooking.NoBags)
                cmd.Parameters.AddWithValue("InfoSupplierEmail", objBEExtrasBaggageBooking.InfoSupplierEmail)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddExtrasBaggageBooking")
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
        Public Function UpdateExtraInvoicedByBookingId(ByVal objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateExtraInvoicedByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEExtrasBaggageBooking.BookingId)
                cmd.Parameters.AddWithValue("ExtraInvoiced", objBEExtrasBaggageBooking.ExtraInvoiced)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateExtraInvoicedByBookingId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update set_paid by ExtrasBaggageBookingId.
        ''' </summary>
        Public Function UpdateSetPaidById(ByVal objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateSetPaidById")
                cmd.Parameters.AddWithValue("ExtrasBaggageBookingId", objBEExtrasBaggageBooking.ExtrasBaggageBookingId)
                cmd.Parameters.AddWithValue("SetPaid", objBEExtrasBaggageBooking.SetPaid)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateSetPaidById")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete extras_baggage_booking by bookingid.
        ''' </summary>
        Public Function DeleteExtrasBaggageBookingByBookingId(ByVal intBookingId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteExtrasBaggageBookingByBookingId")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteExtrasBaggageBookingByBookingId")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get extras baggag booking detail by id
        ''' </summary>
        Public Function GetExtrasBaggageBookingById(ByVal intExtrasBaggageBookingId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spExtrasBaggageBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtrasBaggageBookingById")
                cmd.Parameters.AddWithValue("ExtrasBaggageBookingId", intExtrasBaggageBookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtrasBaggageBookingById")
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
        ''' This function is used to get extras baggag booking detail by booking id
        ''' </summary>
        Public Function GetExtrasBaggageBookingByBookingId(ByVal objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spExtrasBaggageBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtrasBaggageBookingByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEExtrasBaggageBooking.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtrasBaggageBookingByBookingId")
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
        ''' This function is used to get extra baggage detail by booking id.
        ''' </summary>
        Public Function GetExtrasBaggageDetailByBookingIdFillInDD(ByVal intBookingId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtrasBaggageDetailByBookingIdFillInDD")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtrasBaggageDetailByBookingIdFillInDD")
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
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageBooking"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateExtrasBaggageBooking")
                    cmd.Parameters.AddWithValue("ExtrasBaggageBookingId", objBEExtrasBaggageBooking.ExtrasBaggageBookingId)
                    cmd.Parameters.AddWithValue("NoBags", objBEExtrasBaggageBooking.NoBags)
                    cmd.Parameters.AddWithValue("CostEasyway", objBEExtrasBaggageBooking.CostEasyway)
                    cmd.Parameters.AddWithValue("CostClient", objBEExtrasBaggageBooking.CostClient)
                    cmd.Parameters.AddWithValue("BookedYN", objBEExtrasBaggageBooking.BookedYN)
                    cmd.Parameters.AddWithValue("Invoicex", objBEExtrasBaggageBooking.Invoicex)
                    cmd.Parameters.AddWithValue("BookedDate", (If(objBEExtrasBaggageBooking.BookedDate <> DateTime.MinValue, objBEExtrasBaggageBooking.BookedDate, DateTime.Now)))
                    cmd.Parameters.AddWithValue("InfoSupplierEmail", objBEExtrasBaggageBooking.InfoSupplierEmail)
                    cmd.Parameters.AddWithValue("Instructionx", objBEExtrasBaggageBooking.Instructionx)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteExtrasBaggageBookingById")
                    cmd.Parameters.AddWithValue("ExtrasBaggageBookingId", objBEExtrasBaggageBooking.ExtrasBaggageBookingId)
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