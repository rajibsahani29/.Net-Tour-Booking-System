Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAccomStageRoomOptions
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accom stage room options detail.
        ''' </summary>
        Public Function AddAccomStageRoomOptionsDetail(ByVal objBEAccomStageRoomOptions As clsBEAccomStageRoomOptions) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageRoomOptions"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomStageRoomOptionsDetail")
                cmd.Parameters.AddWithValue("AccomStageRoomId", objBEAccomStageRoomOptions.AccomStageRoomId)
                cmd.Parameters.AddWithValue("RoomTypeOptionId", objBEAccomStageRoomOptions.RoomTypeOptionId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomStageRoomOptionsDetail")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accom stage room option by accom stage room id.
        ''' </summary>
        Public Function DeleteAccomStageRoomOptionsByAccomStageRoomId(ByVal intAccomStageRoomId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageRoomOptions"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomStageRoomOptionsByAccomStageRoomId")
                cmd.Parameters.AddWithValue("AccomStageRoomId", intAccomStageRoomId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomStageRoomOptionsByAccomStageRoomId")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accom stage room option by accom stage room id.
        ''' </summary>
        Public Function GetAccomStageRoomOptionsByAccomStageRoomId(ByVal intAccomStageRoomId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomStageRoomOptions"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomStageRoomOptionsByAccomStageRoomId")
                cmd.Parameters.AddWithValue("AccomStageRoomId", intAccomStageRoomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomStageRoomOptionsByAccomStageRoomId")
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