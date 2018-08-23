Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLRoomFacilities
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add room facilities.
        ''' </summary>
        Public Function AddRoomFacilities(ByVal objBERoomFacilities As clsBERoomFacilities) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRoomFacilities"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddRoomFacilities")
                cmd.Parameters.AddWithValue("Name", objBERoomFacilities.Name)
                cmd.Parameters.AddWithValue("CompanyId", objBERoomFacilities.CompanyId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddRoomFacilities")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get room facilities.
        ''' </summary>
        Public Function GetRoomFacilities(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRoomFacilities"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomFacilities")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomFacilities")
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
        ''' This function is used to perform gridview operation for room facilities.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBERoomFacilities As clsBERoomFacilities) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spRoomFacilities"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateRoomFacilities")
                    cmd.Parameters.AddWithValue("RoomFacilitiesId", objBERoomFacilities.RoomFacilitiesId)
                    cmd.Parameters.AddWithValue("Name", objBERoomFacilities.Name)
                    cmd.Parameters.AddWithValue("CompanyId", objBERoomFacilities.CompanyId)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteRoomFacilities")
                    cmd.Parameters.AddWithValue("RoomFacilitiesId", objBERoomFacilities.RoomFacilitiesId)
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
        Public Function GetRoomFacilitiesFillInDD(ByVal intCompanyId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spRoomFacilities"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomFacilitiesFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomFacilitiesFillInDD")
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