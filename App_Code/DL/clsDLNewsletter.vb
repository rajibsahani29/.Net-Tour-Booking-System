Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLNewsletter
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add newsletter.
        ''' </summary>
        Public Function AddNewsletter(ByVal objBENewsletter As clsBENewsletter) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spNewsletter"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddNewsletter")
                cmd.Parameters.AddWithValue("MediaId", objBENewsletter.MediaId)
                cmd.Parameters.AddWithValue("DocLink", objBENewsletter.DocLink)
                cmd.Parameters.AddWithValue("CompanyId", objBENewsletter.CompanyId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddNewsletter")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update newsletter.
        ''' </summary>
        Public Function UpdateNewsletter(ByVal objBENewsletter As clsBENewsletter) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spNewsletter"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateNewsletter")
                cmd.Parameters.AddWithValue("MediaId", objBENewsletter.MediaId)
                cmd.Parameters.AddWithValue("DocLink", objBENewsletter.DocLink)
                cmd.Parameters.AddWithValue("CompanyId", objBENewsletter.CompanyId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateNewsletter")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get newsletter.
        ''' </summary>
        Public Function GetNewsletter(ByVal objBENewsletter As clsBENewsletter) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spNewsletter"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetNewsletter")
                cmd.Parameters.AddWithValue("CompanyId", objBENewsletter.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetNewsletter")
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
        ''' This function is used to check duplicate record.
        ''' </summary>
        Public Function CheckDuplicateRecord(ByVal objBENewsletter As clsBENewsletter) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spNewsletter"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckDuplicateRecord")
                cmd.Parameters.AddWithValue("MediaId", objBENewsletter.MediaId)
                cmd.Parameters.AddWithValue("CompanyId", objBENewsletter.CompanyId)
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