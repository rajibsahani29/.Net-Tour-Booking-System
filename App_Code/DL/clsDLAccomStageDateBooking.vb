Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAccomStageDateBooking
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accom stage date booking details.
        ''' </summary>
        Public Function AddAccomStageDateBooking(ByVal objBEAccomStageDateBooking As clsBEAccomStageDateBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageDateBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomStageDateBooking")
                cmd.Parameters.AddWithValue("BookingId", objBEAccomStageDateBooking.BookingId)
                cmd.Parameters.AddWithValue("CheckInDate", (If(objBEAccomStageDateBooking.CheckInDate <> DateTime.MinValue, objBEAccomStageDateBooking.CheckInDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("CheckOutDate", (If(objBEAccomStageDateBooking.CheckOutDate <> DateTime.MinValue, objBEAccomStageDateBooking.CheckOutDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("FeeTotal", objBEAccomStageDateBooking.FeeTotal)
                cmd.Parameters.AddWithValue("ExtraActualCost", objBEAccomStageDateBooking.ExtraActualCost)
                cmd.Parameters.AddWithValue("AccomActualCost", objBEAccomStageDateBooking.AccomActualCost)
                cmd.Parameters.AddWithValue("AccomRouteStageId", objBEAccomStageDateBooking.AccomRouteStageId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomStageDateBooking")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update checkin and checkout date by accom stage id.
        ''' </summary>
        Public Function UpdateCheckInOutDateByAccomRouteStageId(ByVal objBEAccomStageDateBooking As clsBEAccomStageDateBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageDateBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateCheckInOutDateByAccomRouteStageId")
                cmd.Parameters.AddWithValue("AccomRouteStageId", objBEAccomStageDateBooking.AccomRouteStageId)
                cmd.Parameters.AddWithValue("BookingId", objBEAccomStageDateBooking.BookingId)
                cmd.Parameters.AddWithValue("CheckInDate", objBEAccomStageDateBooking.CheckInDate)
                cmd.Parameters.AddWithValue("CheckOutDate", objBEAccomStageDateBooking.CheckOutDate)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateCheckInOutDateByAccomRouteStageId")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accom stage date booking.
        ''' </summary>
        Public Function DeleteAccomStageDateBookingByAccomRouteStageId(ByVal objBEAccomStageDateBooking As clsBEAccomStageDateBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageDateBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomStageDateBookingByAccomRouteStageId")
                cmd.Parameters.AddWithValue("AccomRouteStageId", objBEAccomStageDateBooking.AccomRouteStageId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomStageDateBookingByAccomRouteStageId")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accom stage date booking by booking_id.
        ''' </summary>
        Public Function DeleteAccomStageDateBookingByBookingId(ByVal intBookingId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageDateBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomStageDateBookingByBookingId")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomStageDateBookingByBookingId")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accom stage date booking by accomroutestageid.
        ''' </summary>
        Public Function GetAccomStageDateBookingByBookingId(ByVal objBEAccomStageDateBooking As clsBEAccomStageDateBooking) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomStageDateBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomStageDateBookingByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEAccomStageDateBooking.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomStageDateBookingByBookingId")
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
        ''' This function is used to get accom stage date booking by accomroutestageid.
        ''' </summary>
        Public Function GetAccomStageDateBookingByAccomRouteStageId(ByVal objBEAccomStageDateBooking As clsBEAccomStageDateBooking) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomStageDateBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomStageDateBookingByAccomRouteStageId")
                cmd.Parameters.AddWithValue("AccomRouteStageId", objBEAccomStageDateBooking.AccomRouteStageId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomStageDateBookingByAccomRouteStageId")
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