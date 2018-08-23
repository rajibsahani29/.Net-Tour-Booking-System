Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLRoomTypeOptions
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add room type options.
        ''' </summary>
        Public Function AddRoomTypeOptions(ByVal objBERoomTypeOptions As clsBERoomTypeOptions) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRoomTypeOptions"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddRoomTypeOptions")
                cmd.Parameters.AddWithValue("Name", objBERoomTypeOptions.Name)
                cmd.Parameters.AddWithValue("CompanyId", objBERoomTypeOptions.CompanyId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddRoomTypeOptions")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get room type options.
        ''' </summary>
        Public Function GetRoomTypeOptions(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRoomTypeOptions"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomTypeOptions")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomTypeOptions")
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
        ''' This function is used to perform gridview operation for room type options.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBERoomTypeOptions As clsBERoomTypeOptions) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRoomTypeOptions"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateRoomTypeOptions")
                    cmd.Parameters.AddWithValue("RoomTypeOptionsId", objBERoomTypeOptions.RoomTypeOptionsId)
                    cmd.Parameters.AddWithValue("Name", objBERoomTypeOptions.Name)
                    cmd.Parameters.AddWithValue("CompanyId", objBERoomTypeOptions.CompanyId)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteRoomTypeOptions")
                    cmd.Parameters.AddWithValue("RoomTypeOptionsId", objBERoomTypeOptions.RoomTypeOptionsId)
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
        ''' This function is used to get room type and fill in dropdown.
        ''' </summary>
        Public Function GetRoomTypeOptionsFillInDD(ByVal intCompanyId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spRoomTypeOptions"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomTypeOptionsFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomTypeOptionsFillInDD")
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
        ''' This function is used to get room type option by id and fill in dropdown.
        ''' </summary>
        Public Function GetRoomTypeOptionsByIdFillInDD(ByVal objBERoomTypeOptions As clsBERoomTypeOptions) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spRoomTypeOptions"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomTypeOptionsByIdFillInDD")
                cmd.Parameters.AddWithValue("RoomTypeOptionsId", objBERoomTypeOptions.RoomTypeOptionsId)
                cmd.Parameters.AddWithValue("CompanyId", objBERoomTypeOptions.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomTypeOptionsByIdFillInDD")
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