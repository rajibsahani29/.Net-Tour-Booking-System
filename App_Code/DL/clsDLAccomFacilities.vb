Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAccomFacilities
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accom facilities.
        ''' </summary>
        Public Function AddAccomFacilities(ByVal objBEAccomFacilities As clsBEAccomFacilities) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomFacilities"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomFacilities")
                cmd.Parameters.AddWithValue("Name", objBEAccomFacilities.Name)
                cmd.Parameters.AddWithValue("CompanyId", objBEAccomFacilities.CompanyId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomFacilities")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accom facilities.
        ''' </summary>
        Public Function GetAccomFacilities(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomFacilities"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomFacilities")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomFacilities")
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
        ''' This function is used to perform gridview operation for accom facilities.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEAccomFacilities As clsBEAccomFacilities) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomFacilities"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateAccomFacilities")
                    cmd.Parameters.AddWithValue("AccomFacilitiesId", objBEAccomFacilities.AccomFacilitiesId)
                    cmd.Parameters.AddWithValue("Name", objBEAccomFacilities.Name)
                    cmd.Parameters.AddWithValue("CompanyId", objBEAccomFacilities.CompanyId)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteAccomFacilities")
                    cmd.Parameters.AddWithValue("AccomFacilitiesId", objBEAccomFacilities.AccomFacilitiesId)
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
