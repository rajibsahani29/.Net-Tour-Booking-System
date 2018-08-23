Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAccomStageEvalBooking
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accom_stage_evaluation_booking.
        ''' </summary>
        Public Function AddAccomStageEvalBooking(ByVal objBEAccomStageEvalBooking As clsBEAccomStageEvalBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageEvalBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomStageEvalBooking")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomStageEvalBooking.AccomId)
                cmd.Parameters.AddWithValue("BookingId", objBEAccomStageEvalBooking.BookingId)
                cmd.Parameters.AddWithValue("Welcome", objBEAccomStageEvalBooking.Welcome)
                cmd.Parameters.AddWithValue("Cleanliness", objBEAccomStageEvalBooking.Cleanliness)
                cmd.Parameters.AddWithValue("Breakfast", objBEAccomStageEvalBooking.Breakfast)
                cmd.Parameters.AddWithValue("Facilities", objBEAccomStageEvalBooking.Facilities)
                cmd.Parameters.AddWithValue("Overall", objBEAccomStageEvalBooking.Overall)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomStageEvalBooking")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accom_stage_eval_booking by bookingid.
        ''' </summary>
        Public Function GetAccomStageEvalBookingByBookingId(ByVal intBookingId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageEvalBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomStageEvalBookingByBookingId")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomStageEvalBookingByBookingId")
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
        ''' This function is used to get average accom_stage_eval_booking by accom_id.
        ''' </summary>
        Public Function GetAverageAccomStageEvalBookingByAccomId(ByVal intAccomId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageEvalBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAverageAccomStageEvalBookingByAccomId")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAverageAccomStageEvalBookingByAccomId")
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