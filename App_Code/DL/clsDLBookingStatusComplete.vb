Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL
    Public Class clsDLBookingStatusComplete
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to get booking_status_complete by easyways.
        ''' </summary>
        Public Function GetBookingStatusCompleteByEasyways(ByVal objBEBookingStatusComplete As clsBEBookingStatusComplete) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingStatusComplete"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingStatusCompleteByEasyways")
                cmd.Parameters.AddWithValue("Easyways", objBEBookingStatusComplete.Easyways)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingStatusCompleteByEasyways")
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
        ''' This function is used to get booking_status_complete by agent.
        ''' </summary>
        Public Function GetBookingStatusCompleteByAgent(ByVal objBEBookingStatusComplete As clsBEBookingStatusComplete) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingStatusComplete"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingStatusCompleteByAgent")
                cmd.Parameters.AddWithValue("Agent", objBEBookingStatusComplete.Agent)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingStatusCompleteByAgent")
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
        ''' This function is used to get booking_status_complete fill in dropdown.
        ''' </summary>
        Public Function GetBookingStatusCompleteFillInDD() As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingStatusComplete"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingStatusCompleteFillInDD")
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingStatusCompleteFillInDD")
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
        ''' This function is used to get booking_status_complete cat by id and easyways.
        ''' </summary>
        Public Function GetBookingStatusCompleteCatByIdAndEasyways(ByVal objBEBookingStatusComplete As clsBEBookingStatusComplete) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingStatusComplete"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingStatusCompleteCatByIdAndEasyways")
                cmd.Parameters.AddWithValue("BookingStatusCompleteId", objBEBookingStatusComplete.BookingStatusCompleteId)
                cmd.Parameters.AddWithValue("Easyways", objBEBookingStatusComplete.Easyways)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingStatusCompleteCatByIdAndEasyways")
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
        ''' This function is used to get booking_status_complete cat by id and agent.
        ''' </summary>
        Public Function GetBookingStatusCompleteCatByIdAndAgent(ByVal objBEBookingStatusComplete As clsBEBookingStatusComplete) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingStatusComplete"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingStatusCompleteCatByIdAndAgent")
                cmd.Parameters.AddWithValue("BookingStatusCompleteId", objBEBookingStatusComplete.BookingStatusCompleteId)
                cmd.Parameters.AddWithValue("Agent", objBEBookingStatusComplete.Agent)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingStatusCompleteCatByIdAndAgent")
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