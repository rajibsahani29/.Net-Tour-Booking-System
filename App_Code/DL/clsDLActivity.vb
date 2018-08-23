Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLActivity
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add activity.
        ''' </summary>
        Public Function AddActivity(ByVal objBEActivity As clsBEActivity) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spActivity"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddActivity")
                cmd.Parameters.AddWithValue("Descx", objBEActivity.Descx)
                cmd.Parameters.AddWithValue("DateAdded", DateTime.Now)
                cmd.Parameters.AddWithValue("StaffId", objBEActivity.StaffId)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddActivity")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get top 10 activities.
        ''' </summary>
        Public Function GetLatestActivity(ByVal intStaffId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spActivity"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetLatestActivity")
                cmd.Parameters.AddWithValue("StaffId", intStaffId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetLatestActivity")
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
