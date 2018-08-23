Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAgentInvoicedBookings
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add agent_invoiced_bookings.
        ''' </summary>
        Public Function AddAgentInvoicedBookings(ByVal objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAgentInvoicedBookings")
                cmd.Parameters.AddWithValue("AgentId", objBEAgentInvoicedBookings.AgentId)
                cmd.Parameters.AddWithValue("BookingId", objBEAgentInvoicedBookings.BookingId)
                cmd.Parameters.AddWithValue("DateEntered", objBEAgentInvoicedBookings.DateEntered)
                cmd.Parameters.AddWithValue("MonthVal", objBEAgentInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEAgentInvoicedBookings.YearVal)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAgentInvoicedBookings")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update date_lastupdated by agent_id.
        ''' </summary>
        Public Function UpdateDateLastUpdatedByAgentId(ByVal objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateDateLastUpdatedByAgentId")
                cmd.Parameters.AddWithValue("AgentId", objBEAgentInvoicedBookings.AgentId)
                cmd.Parameters.AddWithValue("MonthVal", objBEAgentInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEAgentInvoicedBookings.YearVal)
                cmd.Parameters.AddWithValue("DateLastUpdated", objBEAgentInvoicedBookings.DateLastUpdated)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateDateLastUpdatedByAgentId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update date_sent by agent_id.
        ''' </summary>
        Public Function UpdateDateSentByAgentId(ByVal objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateDateSentByAgentId")
                cmd.Parameters.AddWithValue("AgentId", objBEAgentInvoicedBookings.AgentId)
                cmd.Parameters.AddWithValue("MonthVal", objBEAgentInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEAgentInvoicedBookings.YearVal)
                cmd.Parameters.AddWithValue("DateSent", objBEAgentInvoicedBookings.DateSent)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateDateSentByAgentId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get dashboard GetUniqueAgentDetailByMonthAndYear.
        ''' </summary>
        Public Function GetUniqueAgentDetailByMonthAndYear(ByVal objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetUniqueAgentDetailByMonthAndYear")
                cmd.Parameters.AddWithValue("MonthVal", objBEAgentInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEAgentInvoicedBookings.YearVal)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetUniqueAgentDetailByMonthAndYear")
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
        ''' This function is used to get dashboard GetAgentDetailByMonthYearAndAgentId.
        ''' </summary>
        Public Function GetAgentDetailByMonthYearAndAgentId(ByVal objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAgentDetailByMonthYearAndAgentId")
                cmd.Parameters.AddWithValue("AgentId", objBEAgentInvoicedBookings.AgentId)
                cmd.Parameters.AddWithValue("MonthVal", objBEAgentInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEAgentInvoicedBookings.YearVal)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAgentDetailByMonthYearAndAgentId")
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
        ''' This function is used to get dashboard agent_invoiced_bookings by year, month, agent_id and company_id.
        ''' </summary>
        Public Function GetAgentDetailByMonthAndYearAgentIdAndCompanyId(ByVal objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAgentDetailByMonthAndYearAgentIdAndCompanyId")
                cmd.Parameters.AddWithValue("AgentId", objBEAgentInvoicedBookings.AgentId)
                cmd.Parameters.AddWithValue("MonthVal", objBEAgentInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEAgentInvoicedBookings.YearVal)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAgentDetailByMonthAndYearAgentIdAndCompanyId")
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
        ''' This function is used to get dashboard agent_invoiced_bookings by year, month, agent_id and company_id.
        ''' </summary>
        Public Function DeleteAgentDetailByMonthAndYearAgentIdAndCompanyId(ByVal objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings, ByVal intCompanyId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentInvoicedBookings"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAgentDetailByMonthAndYearAgentIdAndCompanyId")
                cmd.Parameters.AddWithValue("AgentId", objBEAgentInvoicedBookings.AgentId)
                cmd.Parameters.AddWithValue("MonthVal", objBEAgentInvoicedBookings.MonthVal)
                cmd.Parameters.AddWithValue("YearVal", objBEAgentInvoicedBookings.YearVal)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAgentDetailByMonthAndYearAgentIdAndCompanyId")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace

    
