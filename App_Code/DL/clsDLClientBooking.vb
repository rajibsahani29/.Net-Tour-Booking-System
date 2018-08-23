Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLClientBooking
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add client booking details.
        ''' </summary>
        Public Function AddClientBooking(ByVal objBEClientBooking As clsBEClientBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddClientBooking")
                cmd.Parameters.AddWithValue("ClientId", objBEClientBooking.ClientId)
                cmd.Parameters.AddWithValue("BookingId", objBEClientBooking.BookingId)
                cmd.Parameters.AddWithValue("DateCreated", DateTime.Now)
                cmd.Parameters.AddWithValue("StaffId", objBEClientBooking.StaffId)
                cmd.Parameters.AddWithValue("AgentId", objBEClientBooking.AgentId)
                cmd.Parameters.AddWithValue("BookingStageId", objBEClientBooking.BookingStageId)
                cmd.Parameters.AddWithValue("CarParkingRequire", objBEClientBooking.CarParkingRequire)
                cmd.Parameters.AddWithValue("UrlVisited", objBEClientBooking.UrlVisited)
                'cmd.Parameters.AddWithValue("AgentPaid", objBEClientBooking.AgentPaid)
                cmd.Parameters.AddWithValue("PriceBand", objBEClientBooking.PriceBand)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddClientBooking")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update checkin earliest and checkout latest date bt booking id.
        ''' </summary>
        Public Function UpdateCheckinEarliestAndCheckoutLatestDateByBookingId(ByVal strAction As String, ByVal objBEClientBooking As clsBEClientBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UpdateCheckinEarliestDate" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateCheckinEarliestDate")
                    cmd.Parameters.AddWithValue("BookingId", objBEClientBooking.BookingId)
                    cmd.Parameters.AddWithValue("CheckinEarliest", objBEClientBooking.CheckinEarliest)
                ElseIf strAction = "UpdateCheckoutLatestDate" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateCheckoutLatestDate")
                    cmd.Parameters.AddWithValue("BookingId", objBEClientBooking.BookingId)
                    cmd.Parameters.AddWithValue("CheckoutLatest", objBEClientBooking.CheckoutLatest)
                ElseIf strAction = "UpdateCheckinEarliestAndCheckoutLatestDate" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateCheckinEarliestAndCheckoutLatestDate")
                    cmd.Parameters.AddWithValue("BookingId", objBEClientBooking.BookingId)
                    cmd.Parameters.AddWithValue("CheckinEarliest", objBEClientBooking.CheckinEarliest)
                    cmd.Parameters.AddWithValue("CheckoutLatest", objBEClientBooking.CheckoutLatest)
                End If
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateCheckinEarliestAndCheckoutLatestDateByBookingId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update booking stage id by booking id.
        ''' </summary>
        Public Function UpdateBookingStageIdByBookingId(ByVal objBEClientBooking As clsBEClientBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateBookingStageIdByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEClientBooking.BookingId)
                cmd.Parameters.AddWithValue("BookingStageId", objBEClientBooking.BookingStageId)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateBookingStageIdByBookingId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update inv_date by booking id.
        ''' </summary>
        Public Function UpdateInvDateByBookingId(ByVal objBEClientBooking As clsBEClientBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateInvDateByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEClientBooking.BookingId)
                cmd.Parameters.AddWithValue("InvDate", objBEClientBooking.InvDate)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateInvDateByBookingId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update flag_invoice by booking id.
        ''' </summary>
        Public Function UpdateFlagInvoiceByBookingId(ByVal objBEClientBooking As clsBEClientBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateFlagInvoiceByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEClientBooking.BookingId)
                cmd.Parameters.AddWithValue("FlagInvoice", objBEClientBooking.FlagInvoice)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateFlagInvoiceByBookingId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update agent_invoiced by id.
        ''' </summary>
        Public Function UpdateAgentInvoicedById(ByVal objBEClientBooking As clsBEClientBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateAgentInvoicedById")
                cmd.Parameters.AddWithValue("ClientBookingId", objBEClientBooking.ClientBookingId)
                cmd.Parameters.AddWithValue("AgentInvoiced", objBEClientBooking.AgentInvoiced)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateAgentInvoicedById")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update agent_ref by booking id.
        ''' </summary>
        Public Function UpdateAgentRefByBookingId(ByVal objBEClientBooking As clsBEClientBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateAgentRefByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEClientBooking.BookingId)
                cmd.Parameters.AddWithValue("AgentRef", objBEClientBooking.AgentRef)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateAgentRefByBookingId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update agent_id and priceband by booking id.
        ''' </summary>
        Public Function UpdateAgentIdAndPriceBandByBookingId(ByVal objBEClientBooking As clsBEClientBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateAgentIdAndPriceBandByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEClientBooking.BookingId)
                cmd.Parameters.AddWithValue("AgentId", objBEClientBooking.AgentId)
                cmd.Parameters.AddWithValue("PriceBand", objBEClientBooking.PriceBand)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateAgentIdAndPriceBandByBookingId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add client booking details.
        ''' </summary>
        Public Function GetClientBookingByBookingId(ByVal intBookingId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientBookingByBookingId")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientBookingByBookingId")
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
        ''' This function is used to get dashboard quick stats details.
        ''' </summary>
        Public Function GetDashboardQuickStatsDetails(ByVal strAction As String, ByVal objBEClientBooking As clsBEClientBooking, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "WalksToday" Then
                    cmd.Parameters.AddWithValue("Action", "WalksToday")
                    cmd.Parameters.AddWithValue("CheckinEarliest", objBEClientBooking.CheckinEarliest)
                    cmd.Parameters.AddWithValue("CheckoutLatest", objBEClientBooking.CheckoutLatest)
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "EnquiriesThisWeek" Then
                    cmd.Parameters.AddWithValue("Action", "EnquiriesThisWeek")
                    cmd.Parameters.AddWithValue("DateCreated", objBEClientBooking.DateCreated)
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "PartallyPaidBookings" Then
                    cmd.Parameters.AddWithValue("Action", "PartallyPaidBookings")
                    cmd.Parameters.AddWithValue("BookingStageId", objBEClientBooking.BookingStageId)
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "ConfirmedBookingsThisWeek" Then
                    cmd.Parameters.AddWithValue("Action", "ConfirmedBookingsThisWeek")
                    cmd.Parameters.AddWithValue("BookingStageId", objBEClientBooking.BookingStageId)
                    cmd.Parameters.AddWithValue("DateCreated", objBEClientBooking.DateCreated)
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "WalksToDate" Then
                    cmd.Parameters.AddWithValue("Action", "WalksToDate")
                    cmd.Parameters.AddWithValue("CheckoutLatest", objBEClientBooking.CheckoutLatest)
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "OpenEnquiries" Then
                    cmd.Parameters.AddWithValue("Action", "OpenEnquiries")
                    cmd.Parameters.AddWithValue("BookingStageId", objBEClientBooking.BookingStageId)
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "BookingsNotPaidDeposit" Then
                    cmd.Parameters.AddWithValue("Action", "BookingsNotPaidDeposit")
                    cmd.Parameters.AddWithValue("BookingStageId", objBEClientBooking.BookingStageId)
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "ConfirmedBookingsThisMonth" Then
                    cmd.Parameters.AddWithValue("Action", "ConfirmedBookingsThisMonth")
                    cmd.Parameters.AddWithValue("DateCreated", objBEClientBooking.DateCreated)
                    cmd.Parameters.AddWithValue("BookingStageId", objBEClientBooking.BookingStageId)
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                End If

                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDashboardQuickStatsDetails")
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
        ''' This function is used to get dashboard Unconfirmed New Enquiries over 7 Days Old.
        ''' </summary>
        Public Function GetDashboardUnconfirmedNewEnquiryOverSevenDayOld(ByVal objBEClientBooking As clsBEClientBooking, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDashboardUnconfirmedNewEnquiryOverSevenDayOld")
                cmd.Parameters.AddWithValue("DateCreated", objBEClientBooking.DateCreated)
                cmd.Parameters.AddWithValue("BookingStageId", objBEClientBooking.BookingStageId)
                cmd.Parameters.AddWithValue("AgentId", objBEClientBooking.AgentId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDashboardUnconfirmedNewEnquiryOverSevenDayOld")
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
        ''' This function is used to get dashboard Unconfirmed New Enquiries over 7 Days Old.
        ''' </summary>
        Public Function GetOutstandingBalancesSixWeeksBeforeStart(ByVal objBEClientBooking As clsBEClientBooking, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetOutstandingBalancesSixWeeksBeforeStart")
                cmd.Parameters.AddWithValue("CheckinEarliest", objBEClientBooking.CheckinEarliest)
                cmd.Parameters.AddWithValue("BookingStageId", objBEClientBooking.BookingStageId)
                cmd.Parameters.AddWithValue("AgentId", objBEClientBooking.AgentId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetOutstandingBalancesSixWeeksBeforeStart")
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
        ''' This function is used to get dashboard Get12thAgentsMonthly.
        ''' </summary>
        Public Function Get12thAgentsMonthly(ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal intMonthlyLast As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "Get12thAgentsMonthly")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("MonthlyLast", intMonthlyLast)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "Get12thAgentsMonthly")
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
        ''' This function is used to get dashboard GetDataForAgentInvoicedBookings.
        ''' </summary>
        Public Function GetDataForAgentInvoicedBookings(ByVal strSearchByToDate As String, ByVal intMonthlyLast As Integer, ByVal intCompanyId As Integer, ByVal intAgentId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDataForAgentInvoicedBookings")
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("MonthlyLast", intMonthlyLast)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                cmd.Parameters.AddWithValue("AgentId", intAgentId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDataForAgentInvoicedBookings")
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
        ''' This function is used to get dashboard Get15thBaggageMonthlyEmail.
        ''' </summary>
        Public Function Get15thBaggageMonthlyEmail(ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal intMonthlyLast As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "Get15thBaggageMonthlyEmail")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("MonthlyLast", intMonthlyLast)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "Get15thBaggageMonthlyEmail")
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
        ''' This function is used to get dashboard GetDataForExtrasInvoicedBookings.
        ''' </summary>
        Public Function GetDataForExtrasInvoicedBookings(ByVal strSearchByToDate As String, ByVal intMonthlyLast As Integer, ByVal intCompanyId As Integer, ByVal intExtraId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDataForExtrasInvoicedBookings")
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("MonthlyLast", intMonthlyLast)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                cmd.Parameters.AddWithValue("ExtraId", intExtraId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDataForExtrasInvoicedBookings")
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
        ''' This function is used to get dashboard Get18thExtraServicesMonthly.
        ''' </summary>
        Public Function Get18thExtraServicesMonthly(ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String, ByVal intMonthlyLast As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "Get18thExtraServicesMonthly")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("MonthlyLast", intMonthlyLast)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "Get18thExtraServicesMonthly")
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
        ''' This function is used to get dashboard GetDataOfExtrasBookingForExtrasInvoicedBookings.
        ''' </summary>
        Public Function GetDataOfExtrasBookingForExtrasInvoicedBookings(ByVal strSearchByToDate As String, ByVal intMonthlyLast As Integer, ByVal intCompanyId As Integer, ByVal intExtraId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDataOfExtrasBookingForExtrasInvoicedBookings")
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("MonthlyLast", intMonthlyLast)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                cmd.Parameters.AddWithValue("ExtraId", intExtraId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDataOfExtrasBookingForExtrasInvoicedBookings")
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
        ''' This function is used to get dashboard GetEvalReportsReminders.
        ''' </summary>
        Public Function GetEvalReportsReminders(ByVal strSearchByFromDate As String, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetEvalReportsReminders")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetEvalReportsReminders")
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
        ''' This function is used to get dashboard Get21stPaymentsDueToAccommodations.
        ''' </summary>
        Public Function Get21stPaymentsDueToAccommodations(ByVal strSearchByToDate As String, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "Get21stPaymentsDueToAccommodations")
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "Get21stPaymentsDueToAccommodations")
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
        ''' This function is used to get dashboard Get28thBaggageServicesAccountPayable.
        ''' </summary>
        Public Function Get28thBaggageServicesAccountPayable(ByVal strSearchByToDate As String, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "Get28thBaggageServicesAccountPayable")
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "Get28thBaggageServicesAccountPayable")
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
        ''' This function is used to get dashboard Get28thExtrasServicesAccountPayable.
        ''' </summary>
        Public Function Get28thExtrasServicesAccountPayable(ByVal strSearchByToDate As String, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "Get28thExtrasServicesAccountPayable")
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "Get28thExtrasServicesAccountPayable")
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
        ''' This function is used to get booking incomplete.
        ''' </summary>
        Public Function GetBookingIncomplete(ByVal intCompanyId As Integer, ByVal strSearchByFromDate As String, ByVal strSearchByToDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingIncomplete")
                cmd.Parameters.AddWithValue("SearchByFromDate", strSearchByFromDate)
                cmd.Parameters.AddWithValue("SearchByToDate", strSearchByToDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingIncomplete")
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