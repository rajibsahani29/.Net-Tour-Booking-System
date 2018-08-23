Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAccomStageRoom
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accom stage room detail.
        ''' </summary>
        Public Function AddAccomStageRoomDetail(ByVal objBEAccomStageRoom As clsBEAccomStageRoom) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageRoom"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomStageRoomDetail")
                cmd.Parameters.AddWithValue("AccomRoomTypeId", objBEAccomStageRoom.AccomRoomTypeId)
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomStageRoom.AccomStageId)
                cmd.Parameters.AddWithValue("NoMales", objBEAccomStageRoom.NoMales)
                cmd.Parameters.AddWithValue("NoFemales", objBEAccomStageRoom.NoFemales)
                cmd.Parameters.AddWithValue("NoOfChildren", objBEAccomStageRoom.NoOfChildren)
                cmd.Parameters.AddWithValue("NoDogs", objBEAccomStageRoom.NoDogs)
                cmd.Parameters.AddWithValue("TotalCostDogs", objBEAccomStageRoom.TotalCostDogs)
                cmd.Parameters.AddWithValue("CostEasyway", objBEAccomStageRoom.CostEasyway)
                cmd.Parameters.AddWithValue("CostClient", objBEAccomStageRoom.CostClient)
                cmd.Parameters.AddWithValue("AdditionalNotes", objBEAccomStageRoom.AdditionalNotes)
                cmd.Parameters.AddWithValue("BookingId", objBEAccomStageRoom.BookingId)
                
                Dim intAccomStageRoomId As Integer = ExecuteNoneQueryByCommand(cmd, "AddAccomStageRoomDetail", "Y")
                Return intAccomStageRoomId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accom stage room detail by booking id.
        ''' </summary>
        Public Function GetAccomStageRoomByBookingId(ByVal objBEAccomStageRoom As clsBEAccomStageRoom) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomStageRoom"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomStageRoomByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEAccomStageRoom.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomStageRoomByBookingId")
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
        ''' This function is used to get accom stage room  roomtype name by booking id.
        ''' </summary>
        Public Function GetAccomStageRoomRoomTypeNameByBookingId(ByVal intBookingId As Integer, ByVal intAccomStageId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomStageRoom"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomStageRoomRoomTypeNameByBookingId")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                cmd.Parameters.AddWithValue("AccomStageId", intAccomStageId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomStageRoomRoomTypeNameByBookingId")
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
        ''' This function is used to get accom stage room detail by accom stage id.
        ''' </summary>
        Public Function GetAccomStageRoomByAccomStageId(ByVal objBEAccomStageRoom As clsBEAccomStageRoom) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomStageRoom"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomStageRoomByAccomStageId")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomStageRoom.AccomStageId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomStageRoomByAccomStageId")
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
        ''' This function is used to get accom facilities name by accom stage room id.
        ''' </summary>
        Public Function GetRoomFacilitiesNameByAccomStageRoomId(ByVal intAccomStageRoomId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomStageRoom"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomFacilitiesNameByAccomStageRoomId")
                cmd.Parameters.AddWithValue("AccomStageRoomId", intAccomStageRoomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomFacilitiesNameByAccomStageRoomId")
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
        ''' This function is used to delete ccom stage date booking.
        ''' </summary>
        Public Function DeleteAccomStageRoomByAccomStageId(ByVal objBEAccomStageRoom As clsBEAccomStageRoom) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageRoom"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomStageRoomByAccomStageId")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomStageRoom.AccomStageId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomStageRoomByAccomStageId")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accom_stage_room by bookingid.
        ''' </summary>
        Public Function DeleteAccomStageRoomByBookingId(ByVal intBookingId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageRoom"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomStageRoomByBookingId")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomStageRoomByBookingId")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to perform gridview operation for accom stage room.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEAccomStageRoom As clsBEAccomStageRoom) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomStageRoom"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateAccomStageRoomDetail")
                    cmd.Parameters.AddWithValue("AccomStageRoomId", objBEAccomStageRoom.AccomStageRoomId)
                    cmd.Parameters.AddWithValue("NoMales", objBEAccomStageRoom.NoMales)
                    cmd.Parameters.AddWithValue("NoFemales", objBEAccomStageRoom.NoFemales)
                    cmd.Parameters.AddWithValue("NoOfChildren", objBEAccomStageRoom.NoOfChildren)
                    cmd.Parameters.AddWithValue("NoDogs", objBEAccomStageRoom.NoDogs)
                    cmd.Parameters.AddWithValue("TotalCostDogs", objBEAccomStageRoom.TotalCostDogs)
                    cmd.Parameters.AddWithValue("CostEasyway", objBEAccomStageRoom.CostEasyway)
                    cmd.Parameters.AddWithValue("CostClient", objBEAccomStageRoom.CostClient)
                    cmd.Parameters.AddWithValue("AdditionalNotes", objBEAccomStageRoom.AdditionalNotes)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteAccomStageRoomById")
                    cmd.Parameters.AddWithValue("AccomStageRoomId", objBEAccomStageRoom.AccomStageRoomId)
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
