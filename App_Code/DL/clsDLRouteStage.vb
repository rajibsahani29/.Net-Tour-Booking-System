Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLRouteStage
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add routestage.
        ''' </summary>
        Public Function AddRouteStage(ByVal objBERouteStage As clsBERouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddRouteStage")
                cmd.Parameters.AddWithValue("RouteId", objBERouteStage.RouteId)
                cmd.Parameters.AddWithValue("StageId", objBERouteStage.StageId)
                cmd.Parameters.AddWithValue("RouteSequence", objBERouteStage.RouteSequence)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddRouteStage")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get routestage.
        ''' </summary>
        Public Function GetRouteStage(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRouteStage")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRouteStage")
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
        ''' This function is used to perform gridview operation for routestage.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBERouteStage As clsBERouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateRouteStage")
                    cmd.Parameters.AddWithValue("RouteStageId", objBERouteStage.RouteStageId)
                    cmd.Parameters.AddWithValue("RouteId", objBERouteStage.RouteId)
                    cmd.Parameters.AddWithValue("StageId", objBERouteStage.StageId)
                    cmd.Parameters.AddWithValue("RouteSequence", objBERouteStage.RouteSequence)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteRouteStage")
                    cmd.Parameters.AddWithValue("RouteStageId", objBERouteStage.RouteStageId)
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
        Public Function CheckDuplicateRecord(ByVal objBERouteStage As clsBERouteStage, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckDuplicateRecord")
                cmd.Parameters.AddWithValue("RouteId", objBERouteStage.RouteId)
                cmd.Parameters.AddWithValue("StageId", objBERouteStage.StageId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                cmd.Parameters.AddWithValue("RouteSequence", objBERouteStage.RouteSequence)
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
        ''' This function is used to get route stage and fill in dropdown.
        ''' </summary>
        Public Function GetRouteStageByNameFillInDD(ByVal intCompanyId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRouteStageByNameFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRouteStageByNameFillInDD")
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
        ''' This function is used to get routestage by route id.
        ''' </summary>
        Public Function GetRouteStageByRouteId(ByVal intRouteId As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRouteStageByRouteId")
                cmd.Parameters.AddWithValue("RouteId", intRouteId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRouteStageByRouteId")
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
        ''' This function is used to get routestage by stage_id.
        ''' </summary>
        Public Function GetRouteStageByStageId(ByVal intStageId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRouteStageByStageId")
                cmd.Parameters.AddWithValue("StageId", intStageId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRouteStageByStageId")
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
        ''' This function is used to get routestage by booking route id and fill in dropdown.
        ''' </summary>
        Public Function GetRouteStageByBookingRouteIdFillInDD(ByVal intRouteId As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRouteStageByBookingRouteIdFillInDD")
                cmd.Parameters.AddWithValue("RouteId", intRouteId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRouteStageByBookingRouteIdFillInDD")
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