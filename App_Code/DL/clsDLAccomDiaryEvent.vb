Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAccomDiaryEvent
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accomodation dairy event.
        ''' </summary>
        Public Function AddAccomDiaryEvent(ByVal objBEAccomDiaryEvent As clsBEAccomDiaryEvent) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomDiaryEvent"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomDiaryEvent")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomDiaryEvent.AccomId)
                cmd.Parameters.AddWithValue("Note", objBEAccomDiaryEvent.Note)
                cmd.Parameters.AddWithValue("FromDate", (If(objBEAccomDiaryEvent.FromDate <> DateTime.MinValue, objBEAccomDiaryEvent.FromDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("ToDate", (If(objBEAccomDiaryEvent.ToDate <> DateTime.MinValue, objBEAccomDiaryEvent.ToDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("DiaryEventStatusId", objBEAccomDiaryEvent.DiaryEventStatusId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomDiaryEvent")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to perform gridview operation for accom diary event.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEAccomDiaryEvent As clsBEAccomDiaryEvent) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomDiaryEvent"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateAccomDiaryEvent")
                    cmd.Parameters.AddWithValue("AccomDiaryEventId", objBEAccomDiaryEvent.AccomDiaryEventId)
                    'cmd.Parameters.AddWithValue("AccomId", objBEAccomDiaryEvent.AccomId)
                    cmd.Parameters.AddWithValue("Note", objBEAccomDiaryEvent.Note)
                    cmd.Parameters.AddWithValue("FromDate", (If(objBEAccomDiaryEvent.FromDate <> DateTime.MinValue, objBEAccomDiaryEvent.FromDate, DirectCast(DBNull.Value, Object))))
                    cmd.Parameters.AddWithValue("ToDate", (If(objBEAccomDiaryEvent.ToDate <> DateTime.MinValue, objBEAccomDiaryEvent.ToDate, DirectCast(DBNull.Value, Object))))
                    'cmd.Parameters.AddWithValue("DiaryEventStatusId", objBEAccomDiaryEvent.DiaryEventStatusId)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteAccomDiaryEvent")
                    cmd.Parameters.AddWithValue("AccomDiaryEventId", objBEAccomDiaryEvent.AccomDiaryEventId)
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
        ''' This function is used to get accomodation dairy event calendar.
        ''' </summary>
        Public Function GetAccomDiaryEventCalander(ByVal objBEAccomDiaryEvent As clsBEAccomDiaryEvent, ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomDiaryEvent"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomDiaryEventCalander")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomDiaryEvent.AccomId)
                cmd.Parameters.AddWithValue("FromDate", (If(objBEAccomDiaryEvent.FromDate <> DateTime.MinValue, objBEAccomDiaryEvent.FromDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomDiaryEventCalander")
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
        ''' This function is used to get dairy event calendar.
        ''' </summary>
        Public Function GetAccomDiaryEventCalander2(ByVal objBEAccomDiaryEvent As clsBEAccomDiaryEvent, ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal intStageId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomDiaryEvent"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomDiaryEventCalander2")
                cmd.Parameters.AddWithValue("StageId", intStageId)
                cmd.Parameters.AddWithValue("FromDate", (If(objBEAccomDiaryEvent.FromDate <> DateTime.MinValue, objBEAccomDiaryEvent.FromDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomDiaryEventCalander2")
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
        ''' This function is used to get accom_diaryevent between from_date and to_date
        ''' </summary>
        Public Function GetAccomDiaryEventByDates(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomDiaryEvent"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomDiaryEventByDates")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomDiaryEventByDates")
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
