Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAccomodationStage
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accomodation stage.
        ''' </summary>
        Public Function AddAccomodationStage(ByVal objBEAccomodationStage As clsBEAccomodationStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomodationStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomodationStage")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodationStage.AccomId)
                cmd.Parameters.AddWithValue("StageId", objBEAccomodationStage.StageId)
                cmd.Parameters.AddWithValue("CompanyId", objBEAccomodationStage.CompanyId)

                Dim intAccomodationStageId As Integer = ExecuteNoneQueryByCommand(cmd, "AddAccomodationStage", "Y")
                Return intAccomodationStageId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accomodation stage.
        ''' </summary>
        Public Function DeleteAccomodationStage(ByVal objBEAccomodationStage As clsBEAccomodationStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomodationStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomodationStage")
                cmd.Parameters.AddWithValue("AccomodationStageId", objBEAccomodationStage.AccomodationStageId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomodationStage")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accomodation stage.
        ''' </summary>
        Public Function GetAccomodationStage(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomodationStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomodationStage")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomodationStage")
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
        ''' This function is used to get accomodation stage by accom id.
        ''' </summary>
        Public Function GetAccomodationStageByAccomId(ByVal intAccomId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomodationStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomodationStageByAccomId")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomodationStageByAccomId")
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
        ''' This function is used to check duplicate record.
        ''' </summary>
        Public Function CheckDuplicateRecord(ByVal objBEAccomodationStage As clsBEAccomodationStage, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomodationStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckDuplicateRecord")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodationStage.AccomId)
                cmd.Parameters.AddWithValue("StageId", objBEAccomodationStage.StageId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "CheckDuplicateRecord")
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
        ''' This function is used to get accommodation details and fill in dropdown.
        ''' </summary>
        Public Function GetAccommodationForStageFillInDD(ByVal intStageId As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomodationStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccommodationForStageFillInDD")
                cmd.Parameters.AddWithValue("StageId", intStageId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccommodationForStageFillInDD")
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
        ''' This function is used to get accommodation details and fill in dropdown.
        ''' </summary>
        Public Function GetAccommodationForStageWithDogFriendlyFillInDD(ByVal intStageId As Integer, ByVal intCompanyId As Integer, ByVal bnlDogFriendly As Boolean) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomodationStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccommodationForStageWithDogFriendlyFillInDD")
                cmd.Parameters.AddWithValue("StageId", intStageId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                cmd.Parameters.AddWithValue("DogFriendly", bnlDogFriendly)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccommodationForStageWithDogFriendlyFillInDD")
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
        ''' This function is used to get accomodation stage.
        ''' </summary>
        Public Function GetAccomodationStageForSearch(ByVal intCompanyId As Integer, ByVal strSearchByName As String, ByVal strSearchByStage As String, ByVal strSearchByPostcode As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomodationStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomodationStageForSearch")
                cmd.Parameters.AddWithValue("SearchByName", strSearchByName)
                cmd.Parameters.AddWithValue("SearchByStage", strSearchByStage)
                cmd.Parameters.AddWithValue("SearchByPostcode", strSearchByPostcode)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomodationStageForSearch")
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