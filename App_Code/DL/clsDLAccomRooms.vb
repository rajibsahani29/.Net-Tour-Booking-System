Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAccomRooms
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accommodation room type details.
        ''' </summary>
        Public Function AddAccomRoomTypeDetails(ByVal objBEAccomRooms As clsBEAccomRooms) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccommodationDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomRooms.AccomId)
                cmd.Parameters.AddWithValue("RoomTypeId", objBEAccomRooms.RoomTypeId)
                cmd.Parameters.AddWithValue("CostEasyway", objBEAccomRooms.CostEasyway)
                cmd.Parameters.AddWithValue("CostClient", objBEAccomRooms.CostClient)
                
                Dim intAccomId As Integer = ExecuteNoneQueryByCommand(cmd, "AddAccomRoomTypeDetails", "Y")
                Return intAccomId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update accommodation room type details.
        ''' </summary>
        Public Function UpdateAccomRoomTypeDetails(ByVal objBEAccomRooms As clsBEAccomRooms) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateAccomRoomTypeDetails")
                cmd.Parameters.AddWithValue("AccomRoomTypeId", objBEAccomRooms.AccomRoomTypeId)
                cmd.Parameters.AddWithValue("CostEasyway", objBEAccomRooms.CostEasyway)
                cmd.Parameters.AddWithValue("CostClient", objBEAccomRooms.CostClient)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateAccomRoomTypeDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add accommodation room type facility details.
        ''' </summary>
        Public Function AddAccomRoomTypeFacilitiesDetails(ByVal objBEAccomRooms As clsBEAccomRooms) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomRoomTypeFacilitiesDetails")
                cmd.Parameters.AddWithValue("AccomRoomTypeId", objBEAccomRooms.AccomRoomTypeId)
                cmd.Parameters.AddWithValue("RoomFacilitiesId", objBEAccomRooms.RoomFacilitiesId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomRoomTypeFacilitiesDetails")
                
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accommodation room type facility detail.
        ''' </summary>
        Public Function DeleteAccomRoomTypeFacilitiesDetails(ByVal objBEAccomRooms As clsBEAccomRooms) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomRoomTypeFacilitiesDetails")
                cmd.Parameters.AddWithValue("AccomRoomTypeId", objBEAccomRooms.AccomRoomTypeId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomRoomTypeFacilitiesDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add accommodation room type option details.
        ''' </summary>
        Public Function AddRoomTypeOptionsDetails(ByVal objBEAccomRooms As clsBEAccomRooms) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddRoomTypeOptionsDetails")
                cmd.Parameters.AddWithValue("AccomRoomTypeId", objBEAccomRooms.AccomRoomTypeId)
                cmd.Parameters.AddWithValue("RoomTypeOptionsDescId", objBEAccomRooms.RoomTypeOptionsDescId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddRoomTypeOptionsDetails")
                
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accommodation room type option detail.
        ''' </summary>
        Public Function DeleteRoomTypeOptionsDetails(ByVal objBEAccomRooms As clsBEAccomRooms) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteRoomTypeOptionsDetails")
                cmd.Parameters.AddWithValue("AccomRoomTypeId", objBEAccomRooms.AccomRoomTypeId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteRoomTypeOptionsDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accom room type by id and fill in dropdown.
        ''' </summary>
        Public Function GetAccomRoomtypeById(ByVal intAccomRoomTypeId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomRoomtypeById")
                cmd.Parameters.AddWithValue("AccomRoomTypeId", intAccomRoomTypeId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomRoomtypeById")
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
        ''' This function is used to get room type by accom id and fill in dropdown.
        ''' </summary>
        Public Function GetRoomTypeByAccomIdFillInDD(ByVal intAccomId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomTypeByAccomIdFillInDD")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomTypeByAccomIdFillInDD")
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
        ''' This function is used to get room type by accom id.
        ''' </summary>
        Public Function GetRoomTypeByAccomId(ByVal intAccomId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomTypeByAccomId")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomTypeByAccomId")
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
        ''' This function is used to get room type by accom id.
        ''' </summary>
        Public Function GetRoomTypeByAccomIdAndRoomTypeId(ByVal intAccomId As Integer, ByVal intRoomTypeId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomTypeByAccomIdAndRoomTypeId")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                cmd.Parameters.AddWithValue("RoomTypeId", intRoomTypeId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomTypeByAccomIdAndRoomTypeId")
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
        ''' This function is used to get room type facility by accom room type id and fill in dropdown.
        ''' </summary>
        Public Function GetRoomTypeFacilitiesByAccomRoomTypeId(ByVal intAccomRoomTypeId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomTypeFacilitiesByAccomRoomTypeId")
                cmd.Parameters.AddWithValue("AccomRoomTypeId", intAccomRoomTypeId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomTypeFacilitiesByAccomRoomTypeId")
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
        ''' This function is used to get room type facility by accom room type id and fill in dropdown.
        ''' </summary>
        Public Function GetRoomTypeFacilitiesByAccomRoomTypeIdFillInDD(ByVal intAccomRoomTypeId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomTypeFacilitiesByAccomRoomTypeIdFillInDD")
                cmd.Parameters.AddWithValue("AccomRoomTypeId", intAccomRoomTypeId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomTypeFacilitiesByAccomRoomTypeIdFillInDD")
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
        ''' This function is used to get room type option by accom room type id and fill in dropdown.
        ''' </summary>
        Public Function GetRoomTypeOptionByAccomRoomTypeId(ByVal intAccomRoomTypeId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetRoomTypeOptionByAccomRoomTypeId")
                cmd.Parameters.AddWithValue("AccomRoomTypeId", intAccomRoomTypeId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetRoomTypeOptionByAccomRoomTypeId")
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
        ''' This function is used to delete accommodation room type option detail.
        ''' </summary>
        Public Function DeleteAccomRoomType(ByVal objBEAccomRooms As clsBEAccomRooms) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRoomTypeDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomRoomType")
                cmd.Parameters.AddWithValue("AccomRoomTypeId", objBEAccomRooms.AccomRoomTypeId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomRoomType")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace
