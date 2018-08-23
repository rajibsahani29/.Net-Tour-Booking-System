Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAccomDocuments
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accommodation documents.
        ''' </summary>
        Public Function AddAccomDocuments(ByVal objBEAccomDocuments As clsBEAccomDocuments) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomDocuments"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomDocuments")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomDocuments.AccomId)
                cmd.Parameters.AddWithValue("DocLink", objBEAccomDocuments.DocLink)
                cmd.Parameters.AddWithValue("Name", objBEAccomDocuments.Name)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomDocuments")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accommodation documents detail by accom id.
        ''' </summary>
        Public Function GetAccomDocumentsDetailByAccomId(ByVal intAccomId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomDocuments"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomDocumentsDetailByAccomId")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomDocumentsDetailByAccomId")
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
        ''' This function is used to delete accommodation documents detail by id.
        ''' </summary>
        Public Function DeleteAccomDocumentsById(ByVal intAccomDocumentId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomDocuments"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomDocumentsById")
                cmd.Parameters.AddWithValue("AccomDocumentsId", intAccomDocumentId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomDocumentsById")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace