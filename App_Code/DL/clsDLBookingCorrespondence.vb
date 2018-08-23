Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLBookingCorrespondence
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add booking correspondence.
        ''' </summary>
        Public Function AddBookingCorrespondence(ByVal objBEBookingCorrespondence As clsBEBookingCorrespondence) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingCorrespondence"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddBookingCorrespondence")
                cmd.Parameters.AddWithValue("BookingId", objBEBookingCorrespondence.BookingId)
                cmd.Parameters.AddWithValue("Direction", objBEBookingCorrespondence.Direction)
                cmd.Parameters.AddWithValue("Subject", objBEBookingCorrespondence.Subject)
                cmd.Parameters.AddWithValue("Notes", objBEBookingCorrespondence.Notes)
                cmd.Parameters.AddWithValue("Datex", objBEBookingCorrespondence.Datex)
                cmd.Parameters.AddWithValue("CorrespondenceTypeId", objBEBookingCorrespondence.CorrespondenceTypeId)
                cmd.Parameters.AddWithValue("Typex", objBEBookingCorrespondence.Typex)
                cmd.Parameters.AddWithValue("AccomId", objBEBookingCorrespondence.AccomId)
                cmd.Parameters.AddWithValue("ExtraId", objBEBookingCorrespondence.ExtraId)
                cmd.Parameters.AddWithValue("EmailType", objBEBookingCorrespondence.EmailType)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddBookingCorrespondence")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get booking correspondence by id
        ''' </summary>
        Public Function GetBookingCorrespondenceById(ByVal intBookingCorrespondenceId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingCorrespondence"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingCorrespondenceById")
                cmd.Parameters.AddWithValue("BookingCorrespondenceId", intBookingCorrespondenceId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingCorrespondenceById")
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
        ''' This function is used to get booking correspondence by booking id and direction
        ''' </summary>
        Public Function GetBookingCorrespondenceByBookingIdAndDirection(ByVal objBEBookingCorrespondence As clsBEBookingCorrespondence) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingCorrespondence"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingCorrespondenceByBookingIdAndDirection")
                cmd.Parameters.AddWithValue("CorrespondenceTypeName", objBEBookingCorrespondence.CorrespondenceTypeName)
                cmd.Parameters.AddWithValue("Direction", objBEBookingCorrespondence.Direction)
                cmd.Parameters.AddWithValue("BookingId", objBEBookingCorrespondence.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingCorrespondenceByBookingIdAndDirection")
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
        ''' This function is used to get booking correspondence by booking id, direction and typex
        ''' </summary>
        Public Function GetBookingCorrespondenceByBookingIdAndDirectionAndTypex(ByVal objBEBookingCorrespondence As clsBEBookingCorrespondence) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingCorrespondence"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingCorrespondenceByBookingIdAndDirectionAndTypex")
                cmd.Parameters.AddWithValue("CorrespondenceTypeName", objBEBookingCorrespondence.CorrespondenceTypeName)
                cmd.Parameters.AddWithValue("Direction", objBEBookingCorrespondence.Direction)
                cmd.Parameters.AddWithValue("BookingId", objBEBookingCorrespondence.BookingId)
                cmd.Parameters.AddWithValue("Typex", objBEBookingCorrespondence.Typex)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingCorrespondenceByBookingIdAndDirectionAndTypex")
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
        ''' This function is used to get booking correspondence by booking id and typex
        ''' </summary>
        Public Function GetBookingCorrespondenceByBookingIdAndTypex(ByVal objBEBookingCorrespondence As clsBEBookingCorrespondence) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingCorrespondence"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingCorrespondenceByBookingIdAndTypex")
                cmd.Parameters.AddWithValue("BookingId", objBEBookingCorrespondence.BookingId)
                cmd.Parameters.AddWithValue("Typex", objBEBookingCorrespondence.Typex)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingCorrespondenceByBookingIdAndTypex")
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
        ''' This function is used to delete booking payments by id.
        ''' </summary>
        'Public Function DeleteBookingPaymentsById(ByVal objBEBookingPayments As clsBEBookingPayments) As Integer
        '    Dim cmd As New SqlCommand()
        '    Try
        '        cmd.CommandText = "EW_spBookingPayments"
        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.Parameters.AddWithValue("Action", "DeleteBookingPaymentsById")
        '        cmd.Parameters.AddWithValue("BookingPaymentsId", objBEBookingPayments.BookingPaymentsId)

        '        Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteBookingPaymentsById")
        '        Return intAffectedRow

        '    Catch ex As Exception
        '        HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
        '        HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        '    End Try
        '    Return Nothing
        'End Function

    End Class

End Namespace