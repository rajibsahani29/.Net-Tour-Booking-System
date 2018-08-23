Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLBookingEvaluation
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accom_stage_evaluation_booking.
        ''' </summary>
        Public Function AddBookingEvaluation(ByVal objBEBookingEvaluation As clsBEBookingEvaluation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingEvaluation"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddBookingEvaluation")
                cmd.Parameters.AddWithValue("BookingId", objBEBookingEvaluation.BookingId)
                cmd.Parameters.AddWithValue("OverAll", objBEBookingEvaluation.OverAll)
                cmd.Parameters.AddWithValue("Ease", objBEBookingEvaluation.Ease)
                cmd.Parameters.AddWithValue("Quality", objBEBookingEvaluation.Quality)
                cmd.Parameters.AddWithValue("Value", objBEBookingEvaluation.Value)
                cmd.Parameters.AddWithValue("Textx", objBEBookingEvaluation.Textx)
                cmd.Parameters.AddWithValue("DateEntered", objBEBookingEvaluation.DateEntered)
                cmd.Parameters.AddWithValue("HearAbout", objBEBookingEvaluation.HearAbout)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddBookingEvaluation")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get booking evaluation by bookingid.
        ''' </summary>
        Public Function GetBookingEvaluationByBookingId(ByVal intBookingId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingEvaluation"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingEvaluationByBookingId")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingEvaluationByBookingId")
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