Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLMembership
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add membership.
        ''' </summary>
        Public Function AddMembership(ByVal objBEMembership As clsBEMembership) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spMembership"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddMembership")
                cmd.Parameters.AddWithValue("Name", objBEMembership.Name)
                cmd.Parameters.AddWithValue("CompanyId", objBEMembership.CompanyId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddMembership")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get membership.
        ''' </summary>
        Public Function GetMembership(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spMembership"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetMembership")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetMembership")
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
        ''' This function is used to get membership and fill in dropdown.
        ''' </summary>
        Public Function GetMembershipFillInDD(ByVal intCompanyId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spMembership"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetMembershipFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetMembershipFillInDD")
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
        ''' This function is used to perform gridview operation for membership.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEMembership As clsBEMembership) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spMembership"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateMembership")
                    cmd.Parameters.AddWithValue("MembershipId", objBEMembership.MembershipId)
                    cmd.Parameters.AddWithValue("Name", objBEMembership.Name)
                    cmd.Parameters.AddWithValue("CompanyId", objBEMembership.CompanyId)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteMembership")
                    cmd.Parameters.AddWithValue("MembershipId", objBEMembership.MembershipId)
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