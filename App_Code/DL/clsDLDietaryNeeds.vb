Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLDietaryNeeds
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add dietary needs.
        ''' </summary>
        Public Function AddDietaryNeeds(ByVal objBEDietaryNeeds As clsBEDietaryNeeds) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDietaryNeeds"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddDietaryNeeds")
                cmd.Parameters.AddWithValue("Name", objBEDietaryNeeds.Name)
                cmd.Parameters.AddWithValue("CompanyId", objBEDietaryNeeds.CompanyId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddDietaryNeeds")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get dietary needs.
        ''' </summary>
        Public Function GetDietaryNeeds(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDietaryNeeds"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDietaryNeeds")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDietaryNeeds")
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
        ''' This function is used to perform gridview operation for dietary needs.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEDietaryNeeds As clsBEDietaryNeeds) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDietaryNeeds"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateDietaryNeeds")
                    cmd.Parameters.AddWithValue("DietaryNeedsId", objBEDietaryNeeds.DietaryNeedsId)
                    cmd.Parameters.AddWithValue("Name", objBEDietaryNeeds.Name)
                    cmd.Parameters.AddWithValue("CompanyId", objBEDietaryNeeds.CompanyId)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteDietaryNeeds")
                    cmd.Parameters.AddWithValue("DietaryNeedsId", objBEDietaryNeeds.DietaryNeedsId)
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