Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL
    Public Class clsDLBookingReport
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to get oldest date created record from client_booking.
        ''' </summary>
        Public Function GetOldestDateCreated(ByVal dtTodayDate As DateTime, ByVal intCompanyId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetOldestDateCreated")
                cmd.Parameters.AddWithValue("TodayDate", dtTodayDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetOldestDateCreated")
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
        ''' This function is used to get newest date created record from client_booking.
        ''' </summary>
        Public Function GetNewestDateCreated(ByVal dtTodayDate As DateTime, ByVal intCompanyId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetNewestDateCreated")
                cmd.Parameters.AddWithValue("TodayDate", dtTodayDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetNewestDateCreated")
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
        ''' This function is used to get samllest total number record from booking.
        ''' </summary>
        Public Function GetSmallestTotalNum(ByVal dtTodayDate As DateTime) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSmallestTotalNum")
                cmd.Parameters.AddWithValue("TodayDate", dtTodayDate)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSmallestTotalNum")
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
        ''' This function is used to get largest total number record from booking.
        ''' </summary>
        Public Function GetLargestTotalNum(ByVal dtTodayDate As DateTime) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetLargestTotalNum")
                cmd.Parameters.AddWithValue("TodayDate", dtTodayDate)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetLargestTotalNum")
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
        ''' This function is used to get sum of total number record from booking.
        ''' </summary>
        Public Function GetSumOfTotalNum(ByVal dtTodayDate As DateTime) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSumOfTotalNum")
                cmd.Parameters.AddWithValue("TodayDate", dtTodayDate)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSumOfTotalNum")
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
        ''' This function is used to get sum of total agent type(agentid<>0) record from client_booking.
        ''' </summary>
        Public Function GetSumOfTotalAgentType(ByVal dtTodayDate As DateTime, ByVal intCompanyId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSumOfTotalAgentType")
                cmd.Parameters.AddWithValue("TodayDate", dtTodayDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSumOfTotalAgentType")
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
        ''' This function is used to get sum of total non agent type(agentid=0) record from client_booking.
        ''' </summary>
        Public Function GetSumOfTotalNonAgentType(ByVal dtTodayDate As DateTime, ByVal intCompanyId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSumOfTotalNonAgentType")
                cmd.Parameters.AddWithValue("TodayDate", dtTodayDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSumOfTotalNonAgentType")
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
        ''' This function is used to get report booking search criteria.
        ''' </summary>
        Public Function GetReportBookingSearchCriteria(ByVal intCompanyId As Integer, ByVal strSearchByStatus As String, ByVal strSearchByRoute As String, ByVal strSearchByAgent As String, ByVal strSearchByNationality As String, ByVal strSearchByDate As String, ByVal strTodayDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportBookingSearchCriteria")
                cmd.Parameters.AddWithValue("SearchByStatus", strSearchByStatus)
                cmd.Parameters.AddWithValue("SearchByRoute", strSearchByRoute)
                cmd.Parameters.AddWithValue("SearchByAgent", strSearchByAgent)
                cmd.Parameters.AddWithValue("SearchByNationality", strSearchByNationality)
                cmd.Parameters.AddWithValue("SearchByDate", strSearchByDate)
                cmd.Parameters.AddWithValue("TodayDateCheck", strTodayDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportBookingSearchCriteria")
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
        ''' This function is used to get report booking search criteria.
        ''' </summary>
        Public Function GetReportBookingIndepthSearch(ByVal intCompanyId As Integer, ByVal strSearchByDateCreated As String, ByVal strSearchByPaymentDate As String, ByVal strSearchByNoOfPeople As String, ByVal strSearchByRoute As String, ByVal strSearchByCustomised As String, ByVal strSearchByAgent As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportBookingIndepthSearch")
                cmd.Parameters.AddWithValue("SearchByDateCreated", strSearchByDateCreated)
                cmd.Parameters.AddWithValue("SearchByPaymentDate", strSearchByPaymentDate)
                cmd.Parameters.AddWithValue("SearchByNoOfPeople", strSearchByNoOfPeople)
                cmd.Parameters.AddWithValue("SearchByRoute", strSearchByRoute)
                cmd.Parameters.AddWithValue("SearchByCustomised", strSearchByCustomised)
                cmd.Parameters.AddWithValue("SearchByAgent", strSearchByAgent)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportBookingIndepthSearch")
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
        ''' This function is used to get report booking for no walkers.
        ''' </summary>
        Public Function GetReportBookingNoWalkers(ByVal intCompanyId As Integer, ByVal strSearchByCheckinEarliest As String, ByVal strSearchByCheckoutLatest As String, ByVal strSearchByRoute As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportBookingNoWalkers")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByCheckinEarliest)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByCheckoutLatest)
                cmd.Parameters.AddWithValue("SearchByRoute", strSearchByRoute)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportBookingNoWalkers")
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
        ''' This function is used to get report booking for cost comparison.
        ''' </summary>
        Public Function GetReportBookingCostComparison(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportBookingCostComparison")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportBookingCostComparison")
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
        ''' This function is used to get report booking for payment rec out.
        ''' </summary>
        Public Function GetReportBookingPaymentsRecOut(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal strSearchByAgent As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportBookingPaymentsRecOut")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("SearchByAgent", strSearchByAgent)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportBookingPaymentsRecOut")
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
        ''' This function is used to GetFinancialReportData.
        ''' </summary>
        Public Function GetFinancialReportData(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal strSearchByRoute As String, ByVal strSearchByAgent As String, ByVal strSearchByCustomised As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetFinancialReportData")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("SearchByRoute", strSearchByRoute)
                cmd.Parameters.AddWithValue("SearchByAgent", strSearchByAgent)
                cmd.Parameters.AddWithValue("SearchByCustomised", strSearchByCustomised)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetFinancialReportData")
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
        ''' This function is used to GetReportClientNonInvoiced.
        ''' </summary>
        Public Function GetReportClientNonInvoiced(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportClientNonInvoiced")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportClientNonInvoiced")
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
        ''' This function is used to get report booking for number of booking per accomodation.
        ''' </summary>
        Public Function GetReportNumberOfBookingPerAccom(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportNumberOfBookingPerAccom")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportNumberOfBookingPerAccom")
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
        ''' This function is used to get accom commision report.
        ''' </summary>
        Public Function GetReportAccomCommision(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal strSearchByRoute As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportAccomCommision")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("SearchByRoute", strSearchByRoute)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportAccomCommision")
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
        ''' This function is used to get taxi financial report.
        ''' </summary>
        Public Function GetReportsTaxiFinancial(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal strSearchByExtra As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportsTaxiFinancial")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("SearchByExtra", strSearchByExtra)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportsTaxiFinancial")
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
        ''' This function is used to get baggage financial report.
        ''' </summary>
        Public Function GetReportsBaggageFinancial(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal strSearchByExtra As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportsBaggageFinancial")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("SearchByExtra", strSearchByExtra)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportsBaggageFinancial")
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
        ''' This function is used to get easyway eval report.
        ''' </summary>
        Public Function GetReportEvalEasyway(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal strSearchByRoute As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportEvalEasyway")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("SearchByRoute", strSearchByRoute)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportEvalEasyway")
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
        ''' This function is used to get url visited report.
        ''' </summary>
        Public Function GetReportUrlClick(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportUrlClick")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportUrlClick")
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
        ''' This function is used to get client report for client booking.
        ''' </summary>
        Public Function GetClientReport1(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientReport1")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientReport1")
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
        ''' This function is used to get client report for marketing.
        ''' </summary>
        Public Function GetClientReport3(ByVal intCompanyId As Integer, ByVal strSearchByMarketing As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientReport3")
                cmd.Parameters.AddWithValue("SearchByMarketing", strSearchByMarketing)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientReport3")
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
        ''' This function is used to get report booking for all walks date.
        ''' </summary>
        Public Function GetReportBookingAllWalksDate(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportBookingAllWalksDate")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportBookingAllWalksDate")
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
        ''' This function is used to get report for agent route date.
        ''' </summary>
        Public Function GetReportAgentsRouteDate(ByVal intCompanyId As Integer, ByVal strSearchByRoute As String, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportAgentsRouteDate")
                cmd.Parameters.AddWithValue("SearchByRoute", strSearchByRoute)
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportAgentsRouteDate")
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
        ''' This function is used to get report for walk route start agent.
        ''' </summary>
        Public Function GetReportWalksRouteStartAgent(ByVal intCompanyId As Integer, ByVal strSearchByRoute As String, ByVal strSearchByAgent As String, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportWalksRouteStartAgent")
                cmd.Parameters.AddWithValue("SearchByRoute", strSearchByRoute)
                cmd.Parameters.AddWithValue("SearchByAgent", strSearchByAgent)
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportWalksRouteStartAgent")
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
        ''' This function is used to get report agent booking.
        ''' </summary>
        Public Function GetReportAgentBooking(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportAgentBooking")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportAgentBooking")
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
        ''' This function is used to get report client to be invoice.
        ''' </summary>
        Public Function GetReportClientsToBeInv(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportClientsToBeInv")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportClientsToBeInv")
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
        ''' This function is used to get report client to be invoice.
        ''' </summary>
        Public Function GetReportBookingsNoBaggageExtras(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal strSearchByBaggage As String, ByVal strSearchByExtra As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportBookingsNoBaggageExtras")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("SearchByBaggage", strSearchByBaggage)
                cmd.Parameters.AddWithValue("SearchByExtra", strSearchByExtra)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportBookingsNoBaggageExtras")
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
        ''' This function is used to get report cc commision.
        ''' </summary>
        Public Function GetReportCcCommision(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportCcCommision")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportCcCommision")
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
        ''' This function is used to get report extra baggage commision.
        ''' </summary>
        Public Function GetReportExtraBaggageCommision(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal strSearchByBaggage As String, ByVal strSearchByExtra As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportExtraBaggageCommision")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("SearchByBaggage", strSearchByBaggage)
                cmd.Parameters.AddWithValue("SearchByExtra", strSearchByExtra)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportExtraBaggageCommision")
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
        ''' This function is used to get report URL sent.
        ''' </summary>
        Public Function GetReportUrlSent(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportUrlSent")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportUrlSent")
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
        ''' This function is used to get report live walkers.
        ''' </summary>
        Public Function GetReportLiveWalkers(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal strSearchByRoute As String, ByVal strSearchByStage As String, ByVal strSearchByAccom As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportLiveWalkers")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("SearchByRoute", strSearchByRoute)
                cmd.Parameters.AddWithValue("SearchByStage", strSearchByStage)
                cmd.Parameters.AddWithValue("SearchByAccom", strSearchByAccom)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportLiveWalkers")
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
        ''' This function is used to get report status all.
        ''' </summary>
        Public Function GetReportStatusAll(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal strSearchByRoute As String, ByVal strSearchByBSCId As String, ByVal strSearchBySelectedBSCId As String, ByVal strSearchByCat As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingReport"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetReportStatusAll")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("SearchByRoute", strSearchByRoute)
                cmd.Parameters.AddWithValue("SearchByBSCId", strSearchByBSCId)
                cmd.Parameters.AddWithValue("SearchBySelectedBSCId", strSearchBySelectedBSCId)
                cmd.Parameters.AddWithValue("SearchByCat", strSearchByCat)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetReportStatusAll")
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
