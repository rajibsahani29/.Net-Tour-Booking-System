Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAdditionalExtras
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add additional extras detail
        ''' </summary>
        Public Function AddAdditionalExtras(ByVal objBEAdditionalExtras As clsBEAdditionalExtras) As Integer
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAdditionalExtras"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAdditionalExtras")
                cmd.Parameters.AddWithValue("Description", objBEAdditionalExtras.Description)
                cmd.Parameters.AddWithValue("CostEasyway", objBEAdditionalExtras.CostEasyway)
                cmd.Parameters.AddWithValue("CostClient", objBEAdditionalExtras.CostClient)
                cmd.Parameters.AddWithValue("BookingId", objBEAdditionalExtras.BookingId)
                cmd.Parameters.AddWithValue("Invoicex", objBEAdditionalExtras.Invoicex)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAdditionalExtras")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get additional extras detail by booking id
        ''' </summary>
        Public Function GetAdditionalExtrasByBookingId(ByVal objBEAdditionalExtras As clsBEAdditionalExtras) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAdditionalExtras"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAdditionalExtrasByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEAdditionalExtras.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAdditionalExtrasByBookingId")
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
        ''' This function is used to get additional extras detail by booking id and invoicex
        ''' </summary>
        Public Function GetAdditionalExtrasByBookingIdAndInvoicex(ByVal objBEAdditionalExtras As clsBEAdditionalExtras) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAdditionalExtras"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAdditionalExtrasByBookingIdAndInvoicex")
                cmd.Parameters.AddWithValue("BookingId", objBEAdditionalExtras.BookingId)
                cmd.Parameters.AddWithValue("Invoicex", objBEAdditionalExtras.Invoicex)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAdditionalExtrasByBookingIdAndInvoicex")
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
        ''' This function is used to perform gridview operation for additional extras detail.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEAdditionalExtras As clsBEAdditionalExtras) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAdditionalExtras"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateAdditionalExtras")
                    cmd.Parameters.AddWithValue("AdditionalExtrasId", objBEAdditionalExtras.AdditionalExtrasId)
                    cmd.Parameters.AddWithValue("Description", objBEAdditionalExtras.Description)
                    cmd.Parameters.AddWithValue("CostEasyway", objBEAdditionalExtras.CostEasyway)
                    cmd.Parameters.AddWithValue("CostClient", objBEAdditionalExtras.CostClient)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteAdditionalExtrasById")
                    cmd.Parameters.AddWithValue("AdditionalExtrasId", objBEAdditionalExtras.AdditionalExtrasId)
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