Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLSex
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to get sex detail and fill in dropdown.
        ''' </summary>
        Public Function GetSexFillInDD() As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spSex"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSexFillInDD")
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSexFillInDD")
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
