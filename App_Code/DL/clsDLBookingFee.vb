Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLBookingFee
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add booking fee.
        ''' </summary>
        Public Function AddBookingFee(ByVal objBEBookingFee As clsBEBookingFee) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingFee"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddBookingFee")
                cmd.Parameters.AddWithValue("TotalNum", objBEBookingFee.TotalNum)
                cmd.Parameters.AddWithValue("FeeTotal", objBEBookingFee.FeeTotal)
                cmd.Parameters.AddWithValue("CompanyId", objBEBookingFee.CompanyId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddBookingFee")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get booking fee.
        ''' </summary>
        Public Function GetBookingFee(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingFee"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingFee")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingFee")
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
        ''' This function is used to perform gridview operation for booking fee.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEBookingFee As clsBEBookingFee) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingFee"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateBookingFee")
                    cmd.Parameters.AddWithValue("BookingFeeId", objBEBookingFee.BookingFeeId)
                    cmd.Parameters.AddWithValue("FeeTotal", objBEBookingFee.FeeTotal)
                    cmd.Parameters.AddWithValue("CompanyId", objBEBookingFee.CompanyId)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteBookingFee")
                    cmd.Parameters.AddWithValue("BookingFeeId", objBEBookingFee.BookingFeeId)
                End If
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "PerformGridViewOpertaion")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to check duplicate record.
        ''' </summary>
        Public Function CheckDuplicateRecord(ByVal objBEBookingFee As clsBEBookingFee) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingFee"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckDuplicateRecord")
                cmd.Parameters.AddWithValue("TotalNum", objBEBookingFee.TotalNum)
                cmd.Parameters.AddWithValue("CompanyId", objBEBookingFee.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "CheckDuplicateRecord")
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
        ''' This function is used to get booking fee by company id and total number.
        ''' </summary>
        Public Function GetBookingFeeByCompanyIdAndTotalNum(ByVal objBEBookingFee As clsBEBookingFee) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingFee"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingFeeByCompanyIdAndTotalNum")
                cmd.Parameters.AddWithValue("TotalNum", objBEBookingFee.TotalNum)
                cmd.Parameters.AddWithValue("CompanyId", objBEBookingFee.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingFeeByCompanyIdAndTotalNum")
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