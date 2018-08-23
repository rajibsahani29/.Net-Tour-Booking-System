Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLCorrespondenceType
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to get correspondence type.
        ''' </summary>
        Public Function GetCorrespondenceTypeFillInDD() As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spCorrespondenceType"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetCorrespondenceTypeFillInDD")
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetCorrespondenceTypeFillInDD")
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