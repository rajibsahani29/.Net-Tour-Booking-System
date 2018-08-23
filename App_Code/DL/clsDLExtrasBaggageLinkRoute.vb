Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLExtrasBaggageLinkRoute
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add extra route stage.
        ''' </summary>
        Public Function AddExtrasBaggageLinkRoute(ByVal objBEExtrasBaggageLinkRoute As clsBEExtrasBaggageLinkRoute) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageLinkRoute"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddExtrasBaggageLinkRoute")
                cmd.Parameters.AddWithValue("RouteId", objBEExtrasBaggageLinkRoute.RouteId)
                cmd.Parameters.AddWithValue("ExtraId", objBEExtrasBaggageLinkRoute.ExtraId)
                cmd.Parameters.AddWithValue("CostEasyway", objBEExtrasBaggageLinkRoute.CostEasyway)
                cmd.Parameters.AddWithValue("CostClient", objBEExtrasBaggageLinkRoute.CostClient)
                cmd.Parameters.AddWithValue("AdditionalNotes", objBEExtrasBaggageLinkRoute.AdditionalNotes)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddExtrasBaggageLinkRoute")
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
        Public Function GetExtrasBaggageLinkRoute(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageLinkRoute"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtrasBaggageLinkRoute")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtrasBaggageLinkRoute")
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
        Public Function GetExtrasBaggageLinkRouteById(ByVal intExtrasBaggageLinkRouteId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageLinkRoute"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtrasBaggageLinkRouteById")
                cmd.Parameters.AddWithValue("ExtrasBaggageLinkRouteId", intExtrasBaggageLinkRouteId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtrasBaggageLinkRouteById")
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
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEExtrasBaggageLinkRoute As clsBEExtrasBaggageLinkRoute) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageLinkRoute"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateExtrasBaggageLinkRoute")
                    cmd.Parameters.AddWithValue("ExtrasBaggageLinkRouteId", objBEExtrasBaggageLinkRoute.ExtrasBaggageLinkRouteId)
                    cmd.Parameters.AddWithValue("RouteId", objBEExtrasBaggageLinkRoute.RouteId)
                    cmd.Parameters.AddWithValue("ExtraId", objBEExtrasBaggageLinkRoute.ExtraId)
                    cmd.Parameters.AddWithValue("CostEasyway", objBEExtrasBaggageLinkRoute.CostEasyway)
                    cmd.Parameters.AddWithValue("CostClient", objBEExtrasBaggageLinkRoute.CostClient)
                    cmd.Parameters.AddWithValue("AdditionalNotes", objBEExtrasBaggageLinkRoute.AdditionalNotes)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteExtrasBaggageLinkRoute")
                    cmd.Parameters.AddWithValue("ExtrasBaggageLinkRouteId", objBEExtrasBaggageLinkRoute.ExtrasBaggageLinkRouteId)
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
        Public Function CheckDuplicateRecord(ByVal objBEExtrasBaggageLinkRoute As clsBEExtrasBaggageLinkRoute, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtrasBaggageLinkRoute"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckDuplicateRecord")
                cmd.Parameters.AddWithValue("RouteId", objBEExtrasBaggageLinkRoute.RouteId)
                cmd.Parameters.AddWithValue("ExtraId", objBEExtrasBaggageLinkRoute.ExtraId)
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
        Public Function GetExtrasBaggageLinkRouteByRouteIdFillInDD(ByVal intRouteId As Integer, ByVal intCompanyId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spExtrasBaggageLinkRoute"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtrasBaggageLinkRouteByRouteId")
                cmd.Parameters.AddWithValue("RouteId", intRouteId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtrasBaggageLinkRouteByRouteId")
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