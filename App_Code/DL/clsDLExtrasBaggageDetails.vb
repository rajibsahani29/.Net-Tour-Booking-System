Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL
    Public Class clsDLExtrasBaggageDetails
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add extras baggage details.
        ''' </summary>
        Public Function AddExtrasBaggageDetails(ByVal objBEExtrasBaggageDetails As clsBEExtrasBaggageDetails) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddExtrasBaggageDetails")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtrasBaggageDetails.ExtraId)
                cmd.Parameters.AddWithValue("Stages", objBEExtrasBaggageDetails.Stages)
                cmd.Parameters.AddWithValue("Bags", objBEExtrasBaggageDetails.Bags)
                cmd.Parameters.AddWithValue("Prices", objBEExtrasBaggageDetails.Prices)
                cmd.Parameters.AddWithValue("Instruction1", objBEExtrasBaggageDetails.Instruction1)
                cmd.Parameters.AddWithValue("Instruction2", objBEExtrasBaggageDetails.Instruction2)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddExtrasBaggageDetails")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update extras baggage details.
        ''' </summary>
        Public Function UpdateExtrasBaggageDetails(ByVal objBEExtrasBaggageDetails As clsBEExtrasBaggageDetails) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateExtrasBaggageDetails")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtrasBaggageDetails.ExtraId)
                cmd.Parameters.AddWithValue("Stages", objBEExtrasBaggageDetails.Stages)
                cmd.Parameters.AddWithValue("Bags", objBEExtrasBaggageDetails.Bags)
                cmd.Parameters.AddWithValue("Prices", objBEExtrasBaggageDetails.Prices)
                cmd.Parameters.AddWithValue("Instruction1", objBEExtrasBaggageDetails.Instruction1)
                cmd.Parameters.AddWithValue("Instruction2", objBEExtrasBaggageDetails.Instruction2)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateExtrasBaggageDetails")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get extra baggage detail by extra id.
        ''' </summary>
        Public Function GetExtraBaggageDetailByExtraId(ByVal intExtraId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtraBaggageDetailByExtraId")
                cmd.Parameters.AddWithValue("ExtraId", intExtraId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtraBaggageDetailByExtraId")
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
        ''' This function is used to check extra baggage details.
        ''' </summary>
        Public Function CheckExtraBaggageDetails(ByVal intExtraId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckExtraBaggageDetails")
                cmd.Parameters.AddWithValue("ExtraId", intExtraId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "CheckExtraBaggageDetails")
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
