Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLRoute
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add route.
        ''' </summary>
        Public Function AddRoute(ByVal objBERoute As clsBERoute) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRoute"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddRoute")
                cmd.Parameters.AddWithValue("Name", objBERoute.Name)
                cmd.Parameters.AddWithValue("CostEasyway", objBERoute.CostEasyway)
                cmd.Parameters.AddWithValue("CostClient", objBERoute.CostClient)
                cmd.Parameters.AddWithValue("DocLink", objBERoute.DocLink)
                cmd.Parameters.AddWithValue("SingleSupplement", objBERoute.SingleSupplement)
                cmd.Parameters.AddWithValue("Codex", objBERoute.Codex)
                cmd.Parameters.AddWithValue("CompanyId", objBERoute.CompanyId)
                cmd.Parameters.AddWithValue("CostGuideBook", objBERoute.CostGuideBook)
                cmd.Parameters.AddWithValue("ExternalLink1", objBERoute.ExternalLink1)
                cmd.Parameters.AddWithValue("ExternalLink2", objBERoute.ExternalLink2)
                cmd.Parameters.AddWithValue("MapLink", objBERoute.MapLink)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddRoute")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get route.
        ''' </summary>
        Public Function GetRoute(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRoute"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoute")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoute")
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
        ''' This function is used to perform gridview operation for route.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBERoute As clsBERoute) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRoute"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateRoute")
                    cmd.Parameters.AddWithValue("RouteId", objBERoute.RouteId)
                    cmd.Parameters.AddWithValue("Name", objBERoute.Name)
                    cmd.Parameters.AddWithValue("CostEasyway", objBERoute.CostEasyway)
                    cmd.Parameters.AddWithValue("CostClient", objBERoute.CostClient)
                    cmd.Parameters.AddWithValue("DocLink", objBERoute.DocLink)
                    cmd.Parameters.AddWithValue("SingleSupplement", objBERoute.SingleSupplement)
                    cmd.Parameters.AddWithValue("Codex", objBERoute.Codex)
                    cmd.Parameters.AddWithValue("CostGuideBook", objBERoute.CostGuideBook)
                    cmd.Parameters.AddWithValue("ExternalLink1", objBERoute.ExternalLink1)
                    cmd.Parameters.AddWithValue("ExternalLink2", objBERoute.ExternalLink2)
                    cmd.Parameters.AddWithValue("MapLink", objBERoute.MapLink)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteRoute")
                    cmd.Parameters.AddWithValue("RouteId", objBERoute.RouteId)
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
        ''' This function is used to get country and fill in dropdown.
        ''' </summary>
        Public Function GetRouteFillInDD(ByVal intCompanyId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spRoute"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRouteFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRouteFillInDD")
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
        ''' This function is used to get route by id.
        ''' </summary>
        Public Function GetRouteById(ByVal objBERoute As clsBERoute) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRoute"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRouteById")
                cmd.Parameters.AddWithValue("RouteId", objBERoute.RouteId)
                cmd.Parameters.AddWithValue("CompanyId", objBERoute.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRouteById")
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