Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLExtraRouteStage
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add extra route stage.
        ''' </summary>
        Public Function AddExtraRouteStage(ByVal objBEExtraRouteStage As clsBEExtraRouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddExtraRouteStage")
                cmd.Parameters.AddWithValue("RouteStageId1", objBEExtraRouteStage.RouteStageId1)
                cmd.Parameters.AddWithValue("RouteStageId2", objBEExtraRouteStage.RouteStageId2)
                cmd.Parameters.AddWithValue("ExtraId", objBEExtraRouteStage.ExtraId)
                cmd.Parameters.AddWithValue("CostEasyway", objBEExtraRouteStage.CostEasyway)
                cmd.Parameters.AddWithValue("CostClient", objBEExtraRouteStage.CostClient)
                cmd.Parameters.AddWithValue("AdditionalNotes", objBEExtraRouteStage.AdditionalNotes)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddExtraRouteStage")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get extra route stage.
        ''' </summary>
        Public Function GetExtraRouteStage(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtraRouteStage")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtraRouteStage")
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
        ''' This function is used to get extra route stage by route id.
        ''' </summary>
        Public Function GetExtraRouteStageByRouteId(ByVal intRouteId As Integer, ByVal intExtraId As Integer, ByVal intCompanyId As Integer, ByVal intExtraTypeId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtraRouteStageByRouteId")
                cmd.Parameters.AddWithValue("RouteId", intRouteId)
                cmd.Parameters.AddWithValue("ExtraId", intExtraId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                cmd.Parameters.AddWithValue("ExtraTypeId", intExtraTypeId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtraRouteStageByRouteId")
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
        ''' This function is used to get extra route stage by id.
        ''' </summary>
        Public Function GetExtraRouteStageById(ByVal intExtraRouteStageId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtraRouteStageById")
                cmd.Parameters.AddWithValue("ExtraRouteStageId", intExtraRouteStageId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtraRouteStageById")
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
        ''' This function is used to perform gridview operation for extra route stage.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEExtraRouteStage As clsBEExtraRouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateExtraRouteStage")
                    cmd.Parameters.AddWithValue("ExtraRouteStageId", objBEExtraRouteStage.ExtraRouteStageId)
                    cmd.Parameters.AddWithValue("RouteStageId1", objBEExtraRouteStage.RouteStageId1)
                    cmd.Parameters.AddWithValue("RouteStageId2", objBEExtraRouteStage.RouteStageId2)
                    cmd.Parameters.AddWithValue("ExtraId", objBEExtraRouteStage.ExtraId)
                    cmd.Parameters.AddWithValue("CostEasyway", objBEExtraRouteStage.CostEasyway)
                    cmd.Parameters.AddWithValue("CostClient", objBEExtraRouteStage.CostClient)
                    cmd.Parameters.AddWithValue("AdditionalNotes", objBEExtraRouteStage.AdditionalNotes)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteExtraRouteStage")
                    cmd.Parameters.AddWithValue("ExtraRouteStageId", objBEExtraRouteStage.ExtraRouteStageId)
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
        Public Function CheckDuplicateRecord(ByVal objBEExtraRouteStage As clsBEExtraRouteStage, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckDuplicateRecord")
                cmd.Parameters.AddWithValue("RouteStageId1", objBEExtraRouteStage.RouteStageId1)
                cmd.Parameters.AddWithValue("RouteStageId2", objBEExtraRouteStage.RouteStageId2)
                cmd.Parameters.AddWithValue("ExtraId", objBEExtraRouteStage.ExtraId)
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

        ''' <summary>
        ''' This function is used to get room type by route stage id and fill in dropdown.
        ''' </summary>
        Public Function GetRoomTypeByRouteStageIdFillInDD(ByVal intRouteStageId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spExtraRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomTypeByRouteStageIdFillInDD")
                cmd.Parameters.AddWithValue("RouteStageId1", intRouteStageId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomTypeByRouteStageIdFillInDD")
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