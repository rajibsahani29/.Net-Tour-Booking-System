Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLBookingStatus
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to get booking status id by name.
        ''' </summary>
        Public Function GetBookingStatusIdByName(ByVal strStatusName As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingStatus"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingStatusByName")
                cmd.Parameters.AddWithValue("Name", strStatusName)

                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingStatusIdByName")
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
        ''' This function is used to get booking status.
        ''' </summary>
        Public Function GetBookingStatusFillInDD() As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingStatus"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingStatusFillInDD")
                
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingStatusFillInDD")
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