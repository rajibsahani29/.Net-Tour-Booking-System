Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLDiaryGeneralEvents
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add dairy general event.
        ''' </summary>
        Public Function AddDiaryGeneralEvents(ByVal objBEDiaryGeneralEvents As clsBEDiaryGeneralEvents) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDiaryGeneralEvents"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddDiaryGeneralEvents")
                cmd.Parameters.AddWithValue("AccomId", objBEDiaryGeneralEvents.AccomId)
                cmd.Parameters.AddWithValue("StageId", objBEDiaryGeneralEvents.StageId)
                cmd.Parameters.AddWithValue("Note", objBEDiaryGeneralEvents.Note)
                cmd.Parameters.AddWithValue("FromDate", (If(objBEDiaryGeneralEvents.FromDate <> DateTime.MinValue, objBEDiaryGeneralEvents.FromDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("ToDate", (If(objBEDiaryGeneralEvents.ToDate <> DateTime.MinValue, objBEDiaryGeneralEvents.ToDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("AllAccom", objBEDiaryGeneralEvents.AllAccom)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddDiaryGeneralEvents")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to perform gridview operation for diary general event.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEDiaryGeneralEvents As clsBEDiaryGeneralEvents) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDiaryGeneralEvents"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateDiaryGeneralEvents")
                    cmd.Parameters.AddWithValue("DiaryGeneralEventsId", objBEDiaryGeneralEvents.DiaryGeneralEventsId)
                    'cmd.Parameters.AddWithValue("AccomId", objBEDiaryGeneralEvents.AccomId)
                    'cmd.Parameters.AddWithValue("StageId", objBEDiaryGeneralEvents.StageId)
                    cmd.Parameters.AddWithValue("Note", objBEDiaryGeneralEvents.Note)
                    cmd.Parameters.AddWithValue("FromDate", (If(objBEDiaryGeneralEvents.FromDate <> DateTime.MinValue, objBEDiaryGeneralEvents.FromDate, DirectCast(DBNull.Value, Object))))
                    cmd.Parameters.AddWithValue("ToDate", (If(objBEDiaryGeneralEvents.ToDate <> DateTime.MinValue, objBEDiaryGeneralEvents.ToDate, DirectCast(DBNull.Value, Object))))
                    'cmd.Parameters.AddWithValue("AllAccom", objBEDiaryGeneralEvents.AllAccom)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteDiaryGeneralEvents")
                    cmd.Parameters.AddWithValue("DiaryGeneralEventsId", objBEDiaryGeneralEvents.DiaryGeneralEventsId)
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
        ''' This function is used to get dairy general event calendar.
        ''' </summary>
        Public Function GetDiaryGeneralEventsCalander(ByVal objBEDiaryGeneralEvents As clsBEDiaryGeneralEvents, ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDiaryGeneralEvents"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDiaryGeneralEventsCalander")
                cmd.Parameters.AddWithValue("StageId", objBEDiaryGeneralEvents.StageId)
                cmd.Parameters.AddWithValue("AccomId", objBEDiaryGeneralEvents.AccomId)
                cmd.Parameters.AddWithValue("FromDate", (If(objBEDiaryGeneralEvents.FromDate <> DateTime.MinValue, objBEDiaryGeneralEvents.FromDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDiaryGeneralEventsCalander")
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
        ''' This function is used to get dairy general event calendar.
        ''' </summary>
        Public Function GetDiaryGeneralEventsCalander2(ByVal objBEDiaryGeneralEvents As clsBEDiaryGeneralEvents, ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDiaryGeneralEvents"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDiaryGeneralEventsCalander2")
                cmd.Parameters.AddWithValue("StageId", objBEDiaryGeneralEvents.StageId)
                cmd.Parameters.AddWithValue("FromDate", (If(objBEDiaryGeneralEvents.FromDate <> DateTime.MinValue, objBEDiaryGeneralEvents.FromDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDiaryGeneralEventsCalander2")
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
        ''' This function is used to get diary_general_events between from_date and to_date
        ''' </summary>
        Public Function GetDiaryGeneralEventsByDates(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spDiaryGeneralEvents"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDiaryGeneralEventsByDates")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDiaryGeneralEventsByDates")
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