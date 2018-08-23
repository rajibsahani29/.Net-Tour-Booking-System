Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAccomPhotos
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accommodation photo.
        ''' </summary>
        Public Function AddAccomPhotos(ByVal objBEAccomPhotos As clsBEAccomPhotos) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomPhoto"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomPhotos")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomPhotos.AccomId)
                cmd.Parameters.AddWithValue("PhotoLocation", objBEAccomPhotos.PhotoLocation)
                cmd.Parameters.AddWithValue("DefaultImg", objBEAccomPhotos.DefaultImg)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomPhotos")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update accommodation photo.
        ''' </summary>
        Public Function UpdateDefaultImageStatus(ByVal objBEAccomPhotos As clsBEAccomPhotos) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomPhoto"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateDefaultImageStatus")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomPhotos.AccomId)
                cmd.Parameters.AddWithValue("DefaultImg", objBEAccomPhotos.DefaultImg)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateDefaultImageStatus")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accommodation photo detail by accom id.
        ''' </summary>
        Public Function GetAccomPhotoDetailByAccomId(ByVal intAccomId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomPhoto"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomPhotoDetailByAccomId")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomPhotoDetailByAccomId")
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
        ''' This function is used to delete accommodation photo detail by id.
        ''' </summary>
        Public Function DeleteAccomPhotoById(ByVal intAccomPhotoId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomPhoto"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomPhotoById")
                cmd.Parameters.AddWithValue("AccomPhotoId", intAccomPhotoId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomPhotoById")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace
