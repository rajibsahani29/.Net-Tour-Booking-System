Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLBookingStatusBookings
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add booking_status_bookings.
        ''' </summary>
        Public Function AddBookingStatusBookings(ByVal objBEBookingStatusBookings As clsBEBookingStatusBookings) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingStatusBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddBookingStatusBookings")
                cmd.Parameters.AddWithValue("BookingId", objBEBookingStatusBookings.BookingId)
                cmd.Parameters.AddWithValue("BSCId", objBEBookingStatusBookings.BSCId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddBookingStatusBookings")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get booking_status_bookings by boking_id and bsc_id.
        ''' </summary>
        Public Function GetBookingStatusBookingsByBookingIdAndBscId(ByVal objBEBookingStatusBookings As clsBEBookingStatusBookings) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingStatusBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingStatusBookingsByBookingIdAndBscId")
                cmd.Parameters.AddWithValue("BookingId", objBEBookingStatusBookings.BookingId)
                cmd.Parameters.AddWithValue("BSCId", objBEBookingStatusBookings.BSCId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingStatusBookingsByBookingIdAndBscId")
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
        ''' This function is used to delete booking_status_bookings by booking_id and bsc_id.
        ''' </summary>
        Public Function DeleteBookingStatusBookingsByBookingIdAndBscId(ByVal objBEBookingStatusBookings As clsBEBookingStatusBookings) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingStatusBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteBookingStatusBookingsByBookingIdAndBscId")
                cmd.Parameters.AddWithValue("BookingId", objBEBookingStatusBookings.BookingId)
                cmd.Parameters.AddWithValue("BSCId", objBEBookingStatusBookings.BSCId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteBookingStatusBookingsByBookingIdAndBscId")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get booking_status_bookings by boking_id.
        ''' </summary>
        Public Function GetBookingStatusBookingsByBookingId(ByVal objBEBookingStatusBookings As clsBEBookingStatusBookings) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingStatusBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingStatusBookingsByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEBookingStatusBookings.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingStatusBookingsByBookingId")
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