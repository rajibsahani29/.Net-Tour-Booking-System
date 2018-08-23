Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLCountry
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to get all countries.
        ''' </summary>
        Public Function GetAllCountry() As DataSet
            Try
                Dim dstData As DataSet
                Dim cmd As New SqlCommand()
                'cmd.CommandText += "Select * From city WHERE ISNULL(status, 1) <> 2 ORDER BY cityid DESC"
                cmd.CommandText = "EW_spCountry"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAllCountry")
                dstData = FillDataSetByCommand(cmd, "GetAllCountry")
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
        ''' This function is used to get country and fill in dropdown.
        ''' </summary>
        Public Function GetCountryFillInDD() As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spCountry"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetCountryFillInDD")
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetCountryFillInDD")
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
