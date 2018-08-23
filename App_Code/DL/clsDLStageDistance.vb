Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLStageDistance
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add stage distance.
        ''' </summary>
        Public Function AddStageDistance(ByVal objBEStageDistance As clsBEStageDistance) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStageDistance"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddStageDistance")
                cmd.Parameters.AddWithValue("StageId1", objBEStageDistance.StageId1)
                cmd.Parameters.AddWithValue("StageId2", objBEStageDistance.StageId2)
                cmd.Parameters.AddWithValue("Mile", objBEStageDistance.Miles)
                cmd.Parameters.AddWithValue("Km", objBEStageDistance.Km)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddStageDistance")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get stage distance.
        ''' </summary>
        Public Function GetStageDistance(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStageDistance"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetStageDistance")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetStageDistance")
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
        ''' This function is used to perform gridview operation for stage distance.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEStageDistance As clsBEStageDistance) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStageDistance"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateStageDistance")
                    cmd.Parameters.AddWithValue("StageDistanceId", objBEStageDistance.StageDistanceId)
                    'cmd.Parameters.AddWithValue("StageId1", objBEStageDistance.StageId1)
                    'cmd.Parameters.AddWithValue("StageId2", objBEStageDistance.StageId2)
                    cmd.Parameters.AddWithValue("Mile", objBEStageDistance.Miles)
                    cmd.Parameters.AddWithValue("Km", objBEStageDistance.Km)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteStageDistance")
                    cmd.Parameters.AddWithValue("StageDistanceId", objBEStageDistance.StageDistanceId)
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
        Public Function CheckDuplicateRecord(ByVal objBEStageDistance As clsBEStageDistance, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStageDistance"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckDuplicateRecord")
                cmd.Parameters.AddWithValue("StageId1", objBEStageDistance.StageId1)
                cmd.Parameters.AddWithValue("StageId2", objBEStageDistance.StageId2)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
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

    End Class

End Namespace