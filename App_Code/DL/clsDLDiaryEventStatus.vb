Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLDiaryEventStatus
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add diary event status.
        ''' </summary>
        Public Function AddDiaryEventStatus(ByVal objBEDiaryEventStatus As clsBEDiaryEventStatus) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDiaryEventStatus"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddDiaryEventStatus")
                cmd.Parameters.AddWithValue("Name", objBEDiaryEventStatus.Name)
                cmd.Parameters.AddWithValue("Color", objBEDiaryEventStatus.Color)
                cmd.Parameters.AddWithValue("CompanyId", objBEDiaryEventStatus.CompanyId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddDiaryEventStatus")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get diary event status.
        ''' </summary>
        Public Function GetDiaryEventStatus(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDiaryEventStatus"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDiaryEventStatus")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDiaryEventStatus")
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
        ''' This function is used to perform gridview operation for diary event status.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEDiaryEventStatus As clsBEDiaryEventStatus) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDiaryEventStatus"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateDiaryEventStatus")
                    cmd.Parameters.AddWithValue("DiaryEventStatusId", objBEDiaryEventStatus.DiaryEventStatusId)
                    cmd.Parameters.AddWithValue("Name", objBEDiaryEventStatus.Name)
                    cmd.Parameters.AddWithValue("Color", objBEDiaryEventStatus.Color)
                    cmd.Parameters.AddWithValue("CompanyId", objBEDiaryEventStatus.CompanyId)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteDiaryEventStatus")
                    cmd.Parameters.AddWithValue("DiaryEventStatusId", objBEDiaryEventStatus.DiaryEventStatusId)
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
        ''' This function is used to get diary event status details and fill in dropdown.
        ''' </summary>
        Public Function GetDiaryEventStatusFillInDD(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDiaryEventStatus"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDiaryEventStatusFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDiaryEventStatusFillInDD")
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