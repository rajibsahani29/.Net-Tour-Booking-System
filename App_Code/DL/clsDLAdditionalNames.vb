Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAdditionalNames
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add additional name detail
        ''' </summary>
        Public Function AddAdditionalNames(ByVal objBEAdditionalNames As clsBEAdditionalNames) As Integer
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAdditionalNames"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAdditionalNames")
                cmd.Parameters.AddWithValue("Name", objBEAdditionalNames.Name)
                cmd.Parameters.AddWithValue("SexId", objBEAdditionalNames.SexId)
                cmd.Parameters.AddWithValue("DietaryNeeds", objBEAdditionalNames.DietaryNeeds)
                cmd.Parameters.AddWithValue("BookingId", objBEAdditionalNames.BookingId)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAdditionalNames")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get additional name detail by booking id
        ''' </summary>
        Public Function GetAdditionalNamesByBookingId(ByVal objBEAdditionalNames As clsBEAdditionalNames) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAdditionalNames"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAdditionalNamesByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEAdditionalNames.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAdditionalNamesByBookingId")
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
        ''' This function is used to perform gridview operation for additional name detail.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEAdditionalNames As clsBEAdditionalNames) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAdditionalNames"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateAdditionalNames")
                    cmd.Parameters.AddWithValue("AdditionalNamesId", objBEAdditionalNames.AdditionalNamesId)
                    cmd.Parameters.AddWithValue("Name", objBEAdditionalNames.Name)
                    cmd.Parameters.AddWithValue("SexId", objBEAdditionalNames.SexId)
                    cmd.Parameters.AddWithValue("DietaryNeeds", objBEAdditionalNames.DietaryNeeds)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteAdditionalNamesById")
                    cmd.Parameters.AddWithValue("AdditionalNamesId", objBEAdditionalNames.AdditionalNamesId)
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