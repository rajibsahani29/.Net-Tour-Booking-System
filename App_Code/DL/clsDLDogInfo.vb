Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLDogInfo
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add DogInfo.
        ''' </summary>
        Public Function AddDogInfo(ByVal objBEDogInfo As clsBEDogInfo) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDogInfo"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddDogInfo")
                cmd.Parameters.AddWithValue("Info", objBEDogInfo.Info)
                cmd.Parameters.AddWithValue("CompanyId", objBEDogInfo.CompanyId)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddDogInfo")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update DogInfo.
        ''' </summary>
        Public Function UpdateDogInfo(ByVal objBEDogInfo As clsBEDogInfo) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDogInfo"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateDogInfo")
                cmd.Parameters.AddWithValue("Info", objBEDogInfo.Info)
                cmd.Parameters.AddWithValue("CompanyId", objBEDogInfo.CompanyId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateDogInfo")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get DogInfo.
        ''' </summary>
        Public Function GetDogInfo(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDogInfo"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDogInfo")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDogInfo")
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