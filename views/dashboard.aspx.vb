Imports System.Data
Imports Easyway.BE
Imports Easyway.DL
Imports System.Globalization

Partial Class dashboard
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            Session("SendEmailId") = Nothing

            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            If Not Page.IsPostBack Then

                Dim dstRoute As DataSet = (New clsDLRoute()).GetRouteFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_TourList, dstRoute)
                DROP_TourList.Items.Insert(0, New ListItem("Select Route", ""))

                'DIV_UnconfirmedNewEnquiryOverSevenDayOld.Attributes.Add("style", "display:none;")
                'DIV_OutstandingBalancesSixWeeksBeforeStart.Attributes.Add("style", "display:none;")
                'DIV_SendClientURLEmail.Attributes.Add("style", "display:none;")
                'DIV_AgentsMonthly.Attributes.Add("style", "display:none;")
                'DIV_BaggageMonthly.Attributes.Add("style", "display:none;")
                'DIV_ExtraServicesMonthly.Attributes.Add("style", "display:none;")
                'DIV_EvalReportsReminders.Attributes.Add("style", "display:none;")

                GetQuickStateDetail()
                GetUnconfirmedNewEnquiryOverSevenDayOld()
                GetOutstandingBalancesSixWeeksBeforeStart()
                GetSendClientURLEmail()
                Get12thAgentsMonthly()
                Get15thBaggageMonthlyEmail()
                Get18thExtraServicesMonthly()
                GetEvalReportsReminders()
                GetAccountPayable()

            End If

            Dim intMonthVal As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            Dim intYearVal As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)

            'Dim intMonthVal As Integer = 8
            'Dim intYearVal As Integer = 2017

            Trace.Warn("intMonthVal = " + objFunction.ReturnString(intMonthVal))
            Trace.Warn("intYearVal = " + objFunction.ReturnString(intYearVal))

            Dim objBEPaymentToSupplierEmailSent As clsBEPaymentToSupplierEmailSent = New clsBEPaymentToSupplierEmailSent
            objBEPaymentToSupplierEmailSent.MonthVal = intMonthVal
            objBEPaymentToSupplierEmailSent.YearVal = intYearVal
            objBEPaymentToSupplierEmailSent.SupplierType = 1
            Dim dstSendEmailData As DataSet = (New clsDLPaymentToSupplierEmailSent()).GetSupplierEmailDetailByMonthYearAndSupplierType(objBEPaymentToSupplierEmailSent, intCompanyId)
            Dim intEmaiSendCount As Integer = 0
            If objFunction.CheckDataSet(dstSendEmailData) Then
                intEmaiSendCount = dstSendEmailData.Tables(0).Rows.Count
            End If

            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            objBEPaymentToSupplier.MonthVal = intMonthVal
            objBEPaymentToSupplier.YearVal = intYearVal
            objBEPaymentToSupplier.SupplierType = 1
            Dim dstEmailData As DataSet = (New clsDLPaymentToSupplier()).GetSupplierDetailByMonthYearAndSupplierType(objBEPaymentToSupplier, intCompanyId)
            Dim intEmaiCount As Integer = 0
            If objFunction.CheckDataSet(dstEmailData) Then
                Trace.Warn("Count = " + objFunction.ReturnString(dstEmailData.Tables(0).Rows.Count))
                Dim dtDistinctData As DataTable = dstEmailData.Tables(0).DefaultView.ToTable(True, "supplier_id")
                Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))
                intEmaiCount = dtDistinctData.Rows.Count
                'dtDistinctData.DefaultView.RowFilter = " supplier_id <> 0"
                'Dim dtData As DataTable = dtDistinctData.DefaultView.ToTable()
                'If objFunction.CheckDataTable(dtData) Then
                '    intEmaiCount = dtData.Rows.Count
                'End If
            End If

            Trace.Warn("intEmaiSendCount = " + objFunction.ReturnString(intEmaiSendCount))
            Trace.Warn("intEmaiCount = " + objFunction.ReturnString(intEmaiCount))
            If intEmaiCount = intEmaiSendCount Then
                BUT_Email_All.Enabled = False
                BUT_Test_Email.Enabled = False
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to set dashboard quick state
    ''' </summary>
    Protected Sub GetQuickStateDetail()

        Try
            Dim dstData As DataSet
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
            Dim objDLClientBooking As clsDLClientBooking = New clsDLClientBooking

            'Walks Today
            objBEClientBooking.CheckinEarliest = DateTime.Now
            objBEClientBooking.CheckoutLatest = DateTime.Now
            Trace.Warn("Checkin date = " + objFunction.ReturnString(objBEClientBooking.CheckinEarliest))
            dstData = objDLClientBooking.GetDashboardQuickStatsDetails("WalksToday", objBEClientBooking, intCompanyId)
            If objFunction.CheckDataSet(dstData) Then
                LABEL_No_Walks_Week.Text = objFunction.ReturnString(dstData.Tables(0).Rows(0)("result"))
            End If

            'of Enquiries this Week
            objBEClientBooking.DateCreated = DateTime.Now
            dstData = objDLClientBooking.GetDashboardQuickStatsDetails("EnquiriesThisWeek", objBEClientBooking, intCompanyId)
            If objFunction.CheckDataSet(dstData) Then
                LABEL_No_Enquiries_Week.Text = objFunction.ReturnString(dstData.Tables(0).Rows(0)("result"))
            End If

            'of Partally Paid Bookings
            objBEClientBooking.BookingStageId = 5
            dstData = objDLClientBooking.GetDashboardQuickStatsDetails("PartallyPaidBookings", objBEClientBooking, intCompanyId)
            Trace.Warn("Checkin date = " + objFunction.ReturnString(objBEClientBooking.CheckinEarliest))
            If objFunction.CheckDataSet(dstData) Then
                LABEL_No_Partially_Paid_Bookings.Text = objFunction.ReturnString(dstData.Tables(0).Rows(0)("result"))
            End If

            'Confirmed Bookings this week
            objBEClientBooking.DateCreated = DateTime.Now
            objBEClientBooking.BookingStageId = 4
            dstData = objDLClientBooking.GetDashboardQuickStatsDetails("ConfirmedBookingsThisWeek", objBEClientBooking, intCompanyId)
            If objFunction.CheckDataSet(dstData) Then
                LABEL_No_Confirmed_Bookings_Week.Text = objFunction.ReturnString(dstData.Tables(0).Rows(0)("result"))
            End If

            'of Walks To Date
            objBEClientBooking.CheckoutLatest = DateTime.Now
            dstData = objDLClientBooking.GetDashboardQuickStatsDetails("WalksToDate", objBEClientBooking, intCompanyId)
            If objFunction.CheckDataSet(dstData) Then
                LABEL_No_Walks_To_Date.Text = objFunction.ReturnString(dstData.Tables(0).Rows(0)("result"))
            End If

            'of Open Enquiries
            objBEClientBooking.BookingStageId = 2
            dstData = objDLClientBooking.GetDashboardQuickStatsDetails("OpenEnquiries", objBEClientBooking, intCompanyId)
            Trace.Warn("Checkin date = " + objFunction.ReturnString(objBEClientBooking.CheckinEarliest))
            If objFunction.CheckDataSet(dstData) Then
                LABEL_No_Open_Enquiries.Text = objFunction.ReturnString(dstData.Tables(0).Rows(0)("result"))
            End If

            'of Bookings Not Paid Deposit
            objBEClientBooking.BookingStageId = 4
            dstData = objDLClientBooking.GetDashboardQuickStatsDetails("BookingsNotPaidDeposit", objBEClientBooking, intCompanyId)
            Trace.Warn("Checkin date = " + objFunction.ReturnString(objBEClientBooking.CheckinEarliest))
            If objFunction.CheckDataSet(dstData) Then
                LABEL_Bookings_Not_Paid_Deposit.Text = objFunction.ReturnString(dstData.Tables(0).Rows(0)("result"))
            End If

            'Confirmed Bookings this month
            objBEClientBooking.DateCreated = DateTime.Now
            objBEClientBooking.BookingStageId = 6
            dstData = objDLClientBooking.GetDashboardQuickStatsDetails("ConfirmedBookingsThisMonth", objBEClientBooking, intCompanyId)
            Trace.Warn("Checkin date = " + objFunction.ReturnString(objBEClientBooking.CheckinEarliest))
            If objFunction.CheckDataSet(dstData) Then
                LABEL_No_Confirmed_Bookings_Month.Text = objFunction.ReturnString(dstData.Tables(0).Rows(0)("result"))
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to get dashboard Unconfirmed New Enquiries over 7 Days Old
    ''' </summary>
    Protected Sub GetUnconfirmedNewEnquiryOverSevenDayOld()

        Try
            Dim dstData As DataSet
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
            Dim objDLClientBooking As clsDLClientBooking = New clsDLClientBooking

            objBEClientBooking.DateCreated = Convert.ToDateTime(DateTime.Now.AddDays(-7))
            objBEClientBooking.BookingStageId = 1
            objBEClientBooking.AgentId = 0
            Trace.Warn("Created date = " + objFunction.ReturnString(objBEClientBooking.DateCreated))
            dstData = objDLClientBooking.GetDashboardUnconfirmedNewEnquiryOverSevenDayOld(objBEClientBooking, intCompanyId)
            Trace.Warn("dstData count = " + objFunction.ReturnString(dstData.Tables(0).Rows.Count))

            GRID_Enquiries_over_7_Days_Old.DataSource = dstData
            GRID_Enquiries_over_7_Days_Old.DataBind()
            DIV_UnconfirmedNewEnquiryOverSevenDayOld.Attributes.Add("style", "display:block;")

            'If objFunction.CheckDataSet(dstData) Then
            '    GRID_Enquiries_over_7_Days_Old.DataSource = dstData
            '    GRID_Enquiries_over_7_Days_Old.DataBind()
            '    DIV_UnconfirmedNewEnquiryOverSevenDayOld.Attributes.Add("style", "display:block;")
            'End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Enquiries_over_7_Days_Old
    ''' </summary>
    Protected Sub GRID_Enquiries_over_7_Days_Old_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Enquiries_over_7_Days_Old.PageIndex = e.NewPageIndex
            GetUnconfirmedNewEnquiryOverSevenDayOld()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Enquiries_over_7_Days_Old
    ''' </summary>
    Protected Sub GRID_Enquiries_over_7_Days_Old_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Enquiries_over_7_Days_Old.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingId") = objFunction.ReturnString(GRID_Enquiries_over_7_Days_Old.DataKeys(e.NewSelectedIndex).Value)
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to get dashboard Outstanding Balances 6 Weeks Before Start
    ''' </summary>
    Protected Sub GetOutstandingBalancesSixWeeksBeforeStart()

        Try
            Dim dstData As DataSet
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
            Dim objDLClientBooking As clsDLClientBooking = New clsDLClientBooking

            objBEClientBooking.CheckinEarliest = Convert.ToDateTime(DateTime.Now.AddDays(42))
            objBEClientBooking.BookingStageId = 5
            objBEClientBooking.AgentId = 0
            Trace.Warn("CheckinEarliest after 6 week = " + objFunction.ReturnString(objBEClientBooking.CheckinEarliest))
            dstData = objDLClientBooking.GetOutstandingBalancesSixWeeksBeforeStart(objBEClientBooking, intCompanyId)
            'Trace.Warn("dstData count = " + objFunction.ReturnString(dstData.Tables(0).Rows.Count))

            GRID_Outstanding_6_Weeks_Before.DataSource = dstData
            GRID_Outstanding_6_Weeks_Before.DataBind()
            DIV_OutstandingBalancesSixWeeksBeforeStart.Attributes.Add("style", "display:block;")

            'If objFunction.CheckDataSet(dstData) Then
            '    GRID_Outstanding_6_Weeks_Before.DataSource = dstData
            '    GRID_Outstanding_6_Weeks_Before.DataBind()
            '    DIV_OutstandingBalancesSixWeeksBeforeStart.Attributes.Add("style", "display:block;")
            'End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Outstanding_6_Weeks_Before
    ''' </summary>
    Protected Sub GRID_Outstanding_6_Weeks_Before_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Outstanding_6_Weeks_Before.PageIndex = e.NewPageIndex
            GetOutstandingBalancesSixWeeksBeforeStart()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Outstanding_6_Weeks_Before
    ''' </summary>
    Protected Sub GRID_Outstanding_6_Weeks_Before_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            Session("BookingId") = objFunction.ReturnString(GRID_Outstanding_6_Weeks_Before.DataKeys(e.NewSelectedIndex).Value)
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to get dashboard Send Client URL email
    ''' </summary>
    Protected Sub GetSendClientURLEmail()

        Try
            Dim dstData As DataSet
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
            Dim objDLClientBooking As clsDLClientBooking = New clsDLClientBooking

            objBEClientBooking.CheckinEarliest = Convert.ToDateTime(DateTime.Now.AddDays(42))
            objBEClientBooking.BookingStageId = 6
            objBEClientBooking.AgentId = 0
            Trace.Warn("CheckinEarliest after 6 week = " + objFunction.ReturnString(objBEClientBooking.CheckinEarliest))
            dstData = objDLClientBooking.GetOutstandingBalancesSixWeeksBeforeStart(objBEClientBooking, intCompanyId)
            'Trace.Warn("dstData count = " + objFunction.ReturnString(dstData.Tables(0).Rows.Count))

            GRID_Send_Client_URL.DataSource = dstData
            GRID_Send_Client_URL.DataBind()
            DIV_SendClientURLEmail.Attributes.Add("style", "display:block;")

            'If objFunction.CheckDataSet(dstData) Then
            '    'GRID_Send_Client_URL.DataSource = dstData
            '    'GRID_Send_Client_URL.DataBind()
            '    'DIV_SendClientURLEmail.Attributes.Add("style", "display:block;")

            '    'Add Booking_Status_Bookings
            '    'Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
            '    'Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings

            '    'For i = 0 To dstData.Tables(0).Rows.Count - 1
            '    '    objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("id"))
            '    '    objBEBookingStatusBookings.BSCId = 15
            '    '    Dim dstBookingStatusBookings As DataSet = objDLBookingStatusBookings.GetBookingStatusBookingsByBookingIdAndBscId(objBEBookingStatusBookings)
            '    '    If Not objFunction.CheckDataSet(dstBookingStatusBookings) Then
            '    '        objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
            '    '    End If
            '    'Next

            'End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Send_Client_URL_PageIndexChanging
    ''' </summary>
    Protected Sub GRID_Send_Client_URL_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Send_Client_URL.PageIndex = e.NewPageIndex
            GetSendClientURLEmail()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Send_Client_URL_PageIndexChanging
    ''' </summary>
    Protected Sub GRID_Send_Client_URL_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            Session("BookingId") = objFunction.ReturnString(GRID_Send_Client_URL.DataKeys(e.NewSelectedIndex).Value)
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to get 12th - Agents Monthly
    ''' This data op must execute between the 12th - 19th of every month.
    ''' </summary>
    Protected Sub Get12thAgentsMonthly(Optional ByVal bnlExecuteStatus As Boolean = False, Optional ByVal intAgentId As Integer = 0)

        Try
            Dim intTodayDay As Integer = objFunction.ReturnInteger(DateTime.Now.Day)

            Trace.Warn("Get12thAgentsMonthly() intTodayDay = " + objFunction.ReturnString(intTodayDay))

            'Dim dtCurrentMonthDate As New DateTime(DateTime.Now.Year, DateTime.Now.Month, 12)
            'Dim dtNextMonthDate As New DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 7)

            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings = New clsBEAgentInvoicedBookings
            Dim objDLAgentInvoicedBookings As clsDLAgentInvoicedBookings = New clsDLAgentInvoicedBookings

            'If DateTime.Now.Date >= dtCurrentMonthDate And DateTime.Now.Date <= dtNextMonthDate Then
            If (intTodayDay <= 5) Or (bnlExecuteStatus = True And intAgentId > 0) Then
                'If intTodayDay >= 12 And intTodayDay <= 19 Then
                Trace.Warn("FirstDayOfMonthFromDateTime = " + objFunction.ReturnString(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))))
                Trace.Warn("LastDayOfMonthFromDateTime = " + objFunction.ReturnString(LastDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))))

                Dim intTodayMonth As Integer = objFunction.ReturnInteger(DateTime.Now.Month)
                Trace.Warn("Get12thAgentsMonthly() intTodayMonth = " + objFunction.ReturnString(intTodayMonth))

                Dim strSearchByFromDate As String = FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")
                Dim strSearchByToDate As String = LastDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")

                Trace.Warn("strSearchByFromDate = " + strSearchByFromDate)
                Trace.Warn("strSearchByToDate = " + strSearchByToDate)

                Dim dstClientBooking As DataSet = (New clsDLClientBooking()).GetDataForAgentInvoicedBookings(strSearchByToDate, intTodayMonth, intCompanyId, intAgentId)
                If objFunction.CheckDataSet(dstClientBooking) Then

                    For i = 0 To dstClientBooking.Tables(0).Rows.Count - 1
                        'Update agent_invoiced=1 of client_booking
                        Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                        objBEClientBooking.AgentInvoiced = True
                        objBEClientBooking.ClientBookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("id"))
                        Dim intAffectedRow As Integer = (New clsDLClientBooking()).UpdateAgentInvoicedById(objBEClientBooking)

                        If bnlExecuteStatus = True Then
                            objBEAgentInvoicedBookings.AgentId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("agent_id"))
                            objBEAgentInvoicedBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("booking_id"))
                            objBEAgentInvoicedBookings.DateEntered = DateTime.Now
                            objBEAgentInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Month)
                            objBEAgentInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Year)
                            objDLAgentInvoicedBookings.AddAgentInvoicedBookings(objBEAgentInvoicedBookings)
                        Else
                            objBEAgentInvoicedBookings.AgentId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("agent_id"))
                            objBEAgentInvoicedBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("booking_id"))
                            objBEAgentInvoicedBookings.DateEntered = DateTime.Now
                            objBEAgentInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                            objBEAgentInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                            objDLAgentInvoicedBookings.AddAgentInvoicedBookings(objBEAgentInvoicedBookings)
                        End If

                        'Add Booking_Status_Bookings
                        Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                        Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                        objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("booking_id"))
                        objBEBookingStatusBookings.BSCId = 16
                        objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)

                    Next

                End If

                If intAgentId > 0 Then
                    objBEAgentInvoicedBookings.AgentId = intAgentId
                    objBEAgentInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                    objBEAgentInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                    objBEAgentInvoicedBookings.DateLastUpdated = DateTime.Now
                    Dim intAff As Integer = objDLAgentInvoicedBookings.UpdateDateLastUpdatedByAgentId(objBEAgentInvoicedBookings)
                End If

            End If

            objBEAgentInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            objBEAgentInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            'Dim dstData As DataSet = (New clsDLClientBooking()).Get12thAgentsMonthly(strSearchByFromDate, strSearchByToDate, intTodayMonth, intCompanyId)
            Dim dstData As DataSet = objDLAgentInvoicedBookings.GetUniqueAgentDetailByMonthAndYear(objBEAgentInvoicedBookings, intCompanyId)
            'Trace.Warn("dstData count = " + objFunction.ReturnString(dstData.Tables(0).Rows.Count))

            'GRID_Agents_Monthly.DataSource = dstData
            'GRID_Agents_Monthly.DataBind()
            'DIV_AgentsMonthly.Attributes.Add("style", "display:block;")

            If objFunction.CheckDataSet(dstData) Then
                GRID_Agents_Monthly.DataSource = dstData
                GRID_Agents_Monthly.DataBind()
                DIV_AgentsMonthly.Attributes.Add("style", "display:block;")
            Else
                GRID_Agents_Monthly.DataSource = Nothing
                GRID_Agents_Monthly.DataBind()
                DIV_AgentsMonthly.Attributes.Add("style", "display:block;")
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Agents_Monthly
    ''' </summary>
    Protected Sub GRID_Agents_Monthly_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Send_Client_URL.PageIndex = e.NewPageIndex
            Get12thAgentsMonthly()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Agents_Monthly
    ''' </summary>
    Protected Sub GRID_Agents_Monthly_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            Session("SupplierId") = objFunction.ReturnString(GRID_Agents_Monthly.DataKeys(e.NewSelectedIndex).Value)
            Session("SupplierType") = "0"
            Response.Redirect("correspondance_system.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub GRID_Agents_Monthly_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        If objFunction.ReturnString(e.CommandName) = "RefreshData" Then
            Dim intAgentId As Integer = objFunction.ReturnInteger(GRID_Agents_Monthly.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(0))
            'Dim intStatus As Integer = objFunction.ReturnInteger(GRID_Agents_Monthly.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(1))
            Trace.Warn("intAgentId = " + objFunction.ReturnString(intAgentId))
            'Trace.Warn("bnlAuthorised = " + objFunction.ReturnString(intStatus))

            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings = New clsBEAgentInvoicedBookings
            objBEAgentInvoicedBookings.AgentId = intAgentId
            objBEAgentInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            objBEAgentInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            Dim dstData As DataSet = (New clsDLAgentInvoicedBookings()).GetAgentDetailByMonthAndYearAgentIdAndCompanyId(objBEAgentInvoicedBookings, intCompanyId)
            If objFunction.CheckDataSet(dstData) Then
                Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                Dim intAffectedRow As Integer = 0
                Dim bnlError As Boolean = False
                For i = 0 To dstData.Tables(0).Rows.Count - 1
                    objBEClientBooking.AgentInvoiced = False
                    objBEClientBooking.ClientBookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("client_booking_id"))
                    intAffectedRow = (New clsDLClientBooking()).UpdateAgentInvoicedById(objBEClientBooking)
                    If intAffectedRow <= 0 Then
                        bnlError = True
                    End If

                    Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                    objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("booking_id"))
                    objBEBookingStatusBookings.BSCId = 16
                    Dim intAff As Integer = (New clsDLBookingStatusBookings()).DeleteBookingStatusBookingsByBookingIdAndBscId(objBEBookingStatusBookings)
                Next

                'If bnlError = False Then
                Dim intAffRow As Integer = (New clsDLAgentInvoicedBookings()).DeleteAgentDetailByMonthAndYearAgentIdAndCompanyId(objBEAgentInvoicedBookings, intCompanyId)
                'End If
            End If

            Get12thAgentsMonthly(True, intAgentId)
        End If

    End Sub

    ''' <summary>
    ''' This function is used to get 15th - Baggage Monthly Email
    ''' This data op must execute between the 15th - 22nd of every month.
    ''' </summary>
    Protected Sub Get15thBaggageMonthlyEmail(Optional ByVal bnlExecuteStatus As Boolean = False, Optional ByVal intExtraId As Integer = 0)

        Try
            Dim intTodayDay As Integer = objFunction.ReturnInteger(DateTime.Now.Day)
            Trace.Warn("Get15thBaggageMonthlyEmail() intTodayDay = " + objFunction.ReturnString(intTodayDay))

            'Dim dtCurrentMonthDate As New DateTime(DateTime.Now.Year, DateTime.Now.Month, 15)
            'Dim dtNextMonthDate As New DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 10)

            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings = New clsBEExtrasInvoicedBookings
            Dim objDLExtrasInvoicedBookings As clsDLExtrasInvoicedBookings = New clsDLExtrasInvoicedBookings

            If (intTodayDay <= 5) Or (bnlExecuteStatus = True And intExtraId > 0) Then
                'If DateTime.Now.Date >= dtCurrentMonthDate And DateTime.Now.Date <= dtNextMonthDate Then
                'If intTodayDay >= 15 And intTodayDay <= 22 Then
                'If intTodayDay >= 1 And intTodayDay <= 22 Then
                Trace.Warn("FirstDayOfMonthFromDateTime = " + objFunction.ReturnString(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))))
                Trace.Warn("LastDayOfMonthFromDateTime = " + objFunction.ReturnString(LastDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))))

                Dim intTodayMonth As Integer = objFunction.ReturnInteger(DateTime.Now.Month)

                Trace.Warn("Get15thBaggageMonthlyEmail() intTodayMonth = " + objFunction.ReturnString(intTodayMonth))
                Dim strSearchByFromDate As String = FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")
                Dim strSearchByToDate As String = LastDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")

                Dim dstClientBooking As DataSet = (New clsDLClientBooking()).GetDataForExtrasInvoicedBookings(strSearchByToDate, intTodayMonth, intCompanyId, intExtraId)
                If objFunction.CheckDataSet(dstClientBooking) Then

                    For i = 0 To dstClientBooking.Tables(0).Rows.Count - 1
                        'Update extra_invoiced=1 of client_booking
                        Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
                        objBEExtrasBaggageBooking.ExtraInvoiced = True
                        objBEExtrasBaggageBooking.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("booking_id"))
                        Dim intAffectedRow As Integer = (New clsDLExtrasBaggageBooking()).UpdateExtraInvoicedByBookingId(objBEExtrasBaggageBooking)

                        If bnlExecuteStatus = True Then
                            objBEExtrasInvoicedBookings.ExtraId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtraId"))
                            objBEExtrasInvoicedBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("booking_id"))
                            objBEExtrasInvoicedBookings.DateEntered = DateTime.Now
                            objBEExtrasInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Month)
                            objBEExtrasInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Year)
                            objBEExtrasInvoicedBookings.SupplierType = 1
                            objDLExtrasInvoicedBookings.AddExtrasInvoicedBookings(objBEExtrasInvoicedBookings)
                        Else
                            objBEExtrasInvoicedBookings.ExtraId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtraId"))
                            objBEExtrasInvoicedBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("booking_id"))
                            objBEExtrasInvoicedBookings.DateEntered = DateTime.Now
                            objBEExtrasInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                            objBEExtrasInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                            objBEExtrasInvoicedBookings.SupplierType = 1
                            objDLExtrasInvoicedBookings.AddExtrasInvoicedBookings(objBEExtrasInvoicedBookings)
                        End If

                        'Add Booking_Status_Bookings
                        'Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                        'Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                        'objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("booking_id"))
                        'objBEBookingStatusBookings.BSCId = 17
                        'objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)

                    Next

                End If

                If intExtraId > 0 Then
                    objBEExtrasInvoicedBookings.ExtraId = intExtraId
                    objBEExtrasInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                    objBEExtrasInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                    objBEExtrasInvoicedBookings.DateLastUpdated = DateTime.Now
                    Dim intAff As Integer = objDLExtrasInvoicedBookings.UpdateDateLastUpdatedByExtraId(objBEExtrasInvoicedBookings)
                End If

            End If

            objBEExtrasInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            objBEExtrasInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            'objBEExtrasInvoicedBookings.MonthVal = 9
            'objBEExtrasInvoicedBookings.YearVal = 2017
            objBEExtrasInvoicedBookings.SupplierType = 1
            'Dim dstData As DataSet = (New clsDLClientBooking()).Get15thBaggageMonthlyEmail(strSearchByFromDate, strSearchByToDate, intTodayMonth, intCompanyId)
            Dim dstData As DataSet = objDLExtrasInvoicedBookings.GetUniqueExtraDetailByMonthYearAndSupplierType(objBEExtrasInvoicedBookings, intCompanyId)
            'Trace.Warn("dstData count = " + objFunction.ReturnString(dstData.Tables(0).Rows.Count))

            'GRID_Baggage_Services_Monthly.DataSource = dstData
            'GRID_Baggage_Services_Monthly.DataBind()
            'DIV_BaggageMonthly.Attributes.Add("style", "display:block;")

            If objFunction.CheckDataSet(dstData) Then
                GRID_Baggage_Services_Monthly.DataSource = dstData
                GRID_Baggage_Services_Monthly.DataBind()
                DIV_BaggageMonthly.Attributes.Add("style", "display:block;")
            Else
                GRID_Baggage_Services_Monthly.DataSource = Nothing
                GRID_Baggage_Services_Monthly.DataBind()
                DIV_BaggageMonthly.Attributes.Add("style", "display:block;")
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Baggage_Services_Monthly
    ''' </summary>
    Protected Sub GRID_Baggage_Services_Monthly_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Send_Client_URL.PageIndex = e.NewPageIndex
            Get15thBaggageMonthlyEmail()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Baggage_Services_Monthly
    ''' </summary>
    Protected Sub GRID_Baggage_Services_Monthly_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            Session("SupplierId") = objFunction.ReturnString(GRID_Baggage_Services_Monthly.DataKeys(e.NewSelectedIndex).Value)
            Session("SupplierType") = "1"
            Response.Redirect("correspondance_system.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub GRID_Baggage_Services_Monthly_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        If objFunction.ReturnString(e.CommandName) = "RefreshData" Then
            Dim intExtraId As Integer = objFunction.ReturnInteger(GRID_Baggage_Services_Monthly.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(0))
            'Dim intStatus As Integer = objFunction.ReturnInteger(GRID_Agents_Monthly.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(1))
            Trace.Warn("intExtraId = " + objFunction.ReturnString(intExtraId))
            'Trace.Warn("bnlAuthorised = " + objFunction.ReturnString(intStatus))

            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings = New clsBEExtrasInvoicedBookings
            objBEExtrasInvoicedBookings.SupplierType = 1
            objBEExtrasInvoicedBookings.ExtraId = intExtraId
            objBEExtrasInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            objBEExtrasInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            Dim dstData As DataSet = (New clsDLExtrasInvoicedBookings()).GetExtraDetailByMonthYearExtraIdAndSupplierType(objBEExtrasInvoicedBookings, intCompanyId)
            If objFunction.CheckDataSet(dstData) Then
                Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
                Dim intAffectedRow As Integer = 0
                Dim bnlError As Boolean = False
                For i = 0 To dstData.Tables(0).Rows.Count - 1
                    objBEExtrasBaggageBooking.ExtraInvoiced = False
                    objBEExtrasBaggageBooking.BookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("booking_id"))
                    intAffectedRow = (New clsDLExtrasBaggageBooking()).UpdateExtraInvoicedByBookingId(objBEExtrasBaggageBooking)
                    If intAffectedRow <= 0 Then
                        bnlError = True
                    End If

                    'Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                    'objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("booking_id"))
                    'objBEBookingStatusBookings.BSCId = 16
                    'Dim intAff As Integer = (New clsDLBookingStatusBookings()).DeleteBookingStatusBookingsByBookingIdAndBscId(objBEBookingStatusBookings)
                Next

                'If bnlError = False Then
                Dim intAffRow As Integer = (New clsDLExtrasInvoicedBookings()).DeleteExtraDetailByMonthYearExtraIdAndSupplierType(objBEExtrasInvoicedBookings, intCompanyId)
                'End If
            End If

            Get15thBaggageMonthlyEmail(True, intExtraId)
        End If

    End Sub

    ''' <summary>
    ''' This function is used to get 18th - Extra Services Monthly
    ''' This data op must execute between the 18th - 25th of every month.
    ''' </summary>
    Protected Sub Get18thExtraServicesMonthly(Optional ByVal bnlExecuteStatus As Boolean = False, Optional ByVal intExtraId As Integer = 0)

        Try
            Dim intTodayDay As Integer = objFunction.ReturnInteger(DateTime.Now.Day)
            Trace.Warn("Get18thExtraServicesMonthly() intTodayDay = " + objFunction.ReturnString(intTodayDay))

            'Dim dtCurrentMonthDate As New DateTime(DateTime.Now.Year, DateTime.Now.Month, 18)
            'Dim dtNextMonthDate As New DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 13)

            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings = New clsBEExtrasInvoicedBookings
            Dim objDLExtrasInvoicedBookings As clsDLExtrasInvoicedBookings = New clsDLExtrasInvoicedBookings

            If (intTodayDay <= 5) Or (bnlExecuteStatus = True And intExtraId > 0) Then
                'If DateTime.Now.Date >= dtCurrentMonthDate And DateTime.Now.Date <= dtNextMonthDate Then
                'If intTodayDay >= 18 And intTodayDay <= 25 Then
                'If intTodayDay >= 1 And intTodayDay <= 25 Then
                Trace.Warn("FirstDayOfMonthFromDateTime = " + objFunction.ReturnString(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))))
                Trace.Warn("LastDayOfMonthFromDateTime = " + objFunction.ReturnString(LastDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))))

                Dim intTodayMonth As Integer = objFunction.ReturnInteger(DateTime.Now.Month)

                Trace.Warn("Get18thExtraServicesMonthly() intTodayMonth = " + objFunction.ReturnString(intTodayMonth))
                Dim strSearchByFromDate As String = FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")
                Dim strSearchByToDate As String = LastDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")

                Dim dstClientBooking As DataSet = (New clsDLClientBooking()).GetDataOfExtrasBookingForExtrasInvoicedBookings(strSearchByToDate, intTodayMonth, intCompanyId, intExtraId)
                If objFunction.CheckDataSet(dstClientBooking) Then

                    For i = 0 To dstClientBooking.Tables(0).Rows.Count - 1
                        'Update extra_invoiced=1 of client_booking
                        Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
                        objBEExtrasBooking.ExtraInvoiced = True
                        objBEExtrasBooking.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("booking_id"))
                        Dim intAffectedRow As Integer = (New clsDLExtrasBooking()).UpdateExtraInvoicedByBookingId(objBEExtrasBooking)

                        If bnlExecuteStatus = True Then
                            objBEExtrasInvoicedBookings.ExtraId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtraId"))
                            objBEExtrasInvoicedBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("booking_id"))
                            objBEExtrasInvoicedBookings.DateEntered = DateTime.Now
                            objBEExtrasInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Month)
                            objBEExtrasInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Year)
                            objBEExtrasInvoicedBookings.SupplierType = 2
                            objDLExtrasInvoicedBookings.AddExtrasInvoicedBookings(objBEExtrasInvoicedBookings)
                        Else
                            objBEExtrasInvoicedBookings.ExtraId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtraId"))
                            objBEExtrasInvoicedBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("booking_id"))
                            objBEExtrasInvoicedBookings.DateEntered = DateTime.Now
                            objBEExtrasInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                            objBEExtrasInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                            objBEExtrasInvoicedBookings.SupplierType = 2
                            objDLExtrasInvoicedBookings.AddExtrasInvoicedBookings(objBEExtrasInvoicedBookings)
                        End If

                        'Add Booking_Status_Bookings
                        'Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                        'Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                        'objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("booking_id"))
                        'objBEBookingStatusBookings.BSCId = 18
                        'objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                    Next
                End If

                If intExtraId > 0 Then
                    objBEExtrasInvoicedBookings.ExtraId = intExtraId
                    objBEExtrasInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                    objBEExtrasInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                    objBEExtrasInvoicedBookings.DateLastUpdated = DateTime.Now
                    Dim intAff As Integer = objDLExtrasInvoicedBookings.UpdateDateLastUpdatedByExtraId(objBEExtrasInvoicedBookings)
                End If

            End If

            objBEExtrasInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            objBEExtrasInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            'objBEExtrasInvoicedBookings.MonthVal = 9
            'objBEExtrasInvoicedBookings.YearVal = 2017
            objBEExtrasInvoicedBookings.SupplierType = 2
            Dim dstData As DataSet = objDLExtrasInvoicedBookings.GetUniqueExtraDetailByMonthYearAndSupplierType(objBEExtrasInvoicedBookings, intCompanyId)
            'Dim dstData As DataSet = (New clsDLClientBooking()).Get18thExtraServicesMonthly(strSearchByFromDate, strSearchByToDate, intTodayMonth, intCompanyId)
            'Trace.Warn("dstData count = " + objFunction.ReturnString(dstData.Tables(0).Rows.Count))

            'GRID_Extra_Services_Monthly.DataSource = dstData
            'GRID_Extra_Services_Monthly.DataBind()
            'DIV_ExtraServicesMonthly.Attributes.Add("style", "display:block;")

            If objFunction.CheckDataSet(dstData) Then
                GRID_Extra_Services_Monthly.DataSource = dstData
                GRID_Extra_Services_Monthly.DataBind()
                DIV_ExtraServicesMonthly.Attributes.Add("style", "display:block;")
            Else
                GRID_Extra_Services_Monthly.DataSource = Nothing
                GRID_Extra_Services_Monthly.DataBind()
                DIV_ExtraServicesMonthly.Attributes.Add("style", "display:block;")
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Extra_Services_Monthly
    ''' </summary>
    Protected Sub GRID_Extra_Services_Monthly_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Send_Client_URL.PageIndex = e.NewPageIndex
            Get18thExtraServicesMonthly()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Extra_Services_Monthly
    ''' </summary>
    Protected Sub GRID_Extra_Services_Monthly_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            Session("SupplierId") = objFunction.ReturnString(GRID_Extra_Services_Monthly.DataKeys(e.NewSelectedIndex).Value)
            Session("SupplierType") = "2"
            Response.Redirect("correspondance_system.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub GRID_Extra_Services_Monthly_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        If objFunction.ReturnString(e.CommandName) = "RefreshData" Then
            Dim intExtraId As Integer = objFunction.ReturnInteger(GRID_Extra_Services_Monthly.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(0))
            'Dim intStatus As Integer = objFunction.ReturnInteger(GRID_Agents_Monthly.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(1))
            Trace.Warn("intExtraId = " + objFunction.ReturnString(intExtraId))
            'Trace.Warn("bnlAuthorised = " + objFunction.ReturnString(intStatus))

            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim objBEExtrasInvoicedBookings As clsBEExtrasInvoicedBookings = New clsBEExtrasInvoicedBookings
            objBEExtrasInvoicedBookings.SupplierType = 2
            objBEExtrasInvoicedBookings.ExtraId = intExtraId
            objBEExtrasInvoicedBookings.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            objBEExtrasInvoicedBookings.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            Dim dstData As DataSet = (New clsDLExtrasInvoicedBookings()).GetExtraDetailByMonthYearExtraIdAndSupplierType(objBEExtrasInvoicedBookings, intCompanyId)
            If objFunction.CheckDataSet(dstData) Then
                Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
                Dim intAffectedRow As Integer = 0
                Dim bnlError As Boolean = False
                For i = 0 To dstData.Tables(0).Rows.Count - 1
                    objBEExtrasBooking.ExtraInvoiced = False
                    objBEExtrasBooking.BookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("booking_id"))
                    intAffectedRow = (New clsDLExtrasBooking()).UpdateExtraInvoicedByBookingId(objBEExtrasBooking)
                    If intAffectedRow <= 0 Then
                        bnlError = True
                    End If

                    'Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                    'objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("booking_id"))
                    'objBEBookingStatusBookings.BSCId = 16
                    'Dim intAff As Integer = (New clsDLBookingStatusBookings()).DeleteBookingStatusBookingsByBookingIdAndBscId(objBEBookingStatusBookings)
                Next

                'If bnlError = False Then
                Dim intAffRow As Integer = (New clsDLExtrasInvoicedBookings()).DeleteExtraDetailByMonthYearExtraIdAndSupplierType(objBEExtrasInvoicedBookings, intCompanyId)
                'End If
            End If

            Get18thExtraServicesMonthly(True, intExtraId)
        End If

    End Sub

    ''' <summary>
    ''' This function is used to get Account Payable
    ''' </summary>
    Protected Sub GetAccountPayable()

        Try
            Dim intTodayDay As Integer = objFunction.ReturnInteger(DateTime.Now.Day)
            Trace.Warn("GetAccountPayable() intTodayDay = " + objFunction.ReturnString(intTodayDay))

            'If intTodayDay >= 21 And intTodayDay <= 28 Then
            '    'If intTodayDay >= 10 And intTodayDay <= 28 Then
            '    BUT_Report_Not_Ready.Attributes.Add("style", "display:none;")
            '    BUT_Report_Ready.Attributes.Add("style", "display:block;float:right")
            '    BUT_Email_All.Attributes.Add("style", "display:block;float:right")
            '    Get21stPaymentsDueToAccommodations()

            '    BUT_Report_Not_Ready3.Attributes.Add("style", "display:none;")
            '    BUT_Report_Ready3.Attributes.Add("style", "display:block;float:right")
            '    Get28thExtrasServicesAccountPayable()
            'End If

            'If intTodayDay >= 28 Or intTodayDay <= 5 Then
            '    BUT_Report_Not_Ready2.Attributes.Add("style", "display:none;")
            '    BUT_Report_Ready2.Attributes.Add("style", "display:block;float:right")
            '    Get28thBaggageServicesAccountPayable()
            'End If

            'Dim dtCurrentMonthDate As New DateTime(DateTime.Now.Year, DateTime.Now.Month, 21)
            'Dim dtNextMonthDate As New DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 17)

            'If intTodayDay = 21 Then
            If intTodayDay <= 5 Then
                'If DateTime.Now.Date >= dtCurrentMonthDate And DateTime.Now.Date <= dtNextMonthDate Then
                'If intTodayDay >= 21 Or intTodayDay <= 17 Then
                'BUT_Report_Not_Ready.Attributes.Add("style", "display:none;")
                'BUT_Report_Ready.Attributes.Add("style", "display:block;float:right")
                'BUT_Email_All.Attributes.Add("style", "display:block;float:right")
                Get21stPaymentsDueToAccommodations()

                'BUT_Report_Not_Ready2.Attributes.Add("style", "display:none;")
                'BUT_Report_Ready2.Attributes.Add("style", "display:block;float:right")
                Get28thBaggageServicesAccountPayable()

                'BUT_Report_Not_Ready3.Attributes.Add("style", "display:none;")
                'BUT_Report_Ready3.Attributes.Add("style", "display:block;float:right")
                Get28thExtrasServicesAccountPayable()
            End If

            BUT_Report_Not_Ready.Attributes.Add("style", "display:none;")
            BUT_Report_Ready.Attributes.Add("style", "display:block;float:right")
            BUT_Email_All.Attributes.Add("style", "display:block;float:right")
            BUT_Test_Email.Attributes.Add("style", "display:block;float:right")

            BUT_Report_Not_Ready3.Attributes.Add("style", "display:none;")
            BUT_Report_Ready3.Attributes.Add("style", "display:block;float:right")

            BUT_Report_Not_Ready2.Attributes.Add("style", "display:none;")
            BUT_Report_Ready2.Attributes.Add("style", "display:block;float:right")

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to get 21st - Payments Due to Accommodations
    ''' </summary>
    Protected Sub Get21stPaymentsDueToAccommodations(Optional ByVal bnlExecuteStatus As Boolean = False)

        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            'Dim strSearchByFromDate As String = FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")
            Dim strSearchByToDate As String = LastDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")
            Trace.Warn("Get21stPaymentsDueToAccommodations() strSearchByToDate = " + strSearchByToDate)

            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            Dim objDLPaymentToSupplier As clsDLPaymentToSupplier = New clsDLPaymentToSupplier

            Dim dstClientBooking As DataSet = (New clsDLClientBooking()).Get21stPaymentsDueToAccommodations(strSearchByToDate, intCompanyId)
            If objFunction.CheckDataSet(dstClientBooking) Then

                For i = 0 To dstClientBooking.Tables(0).Rows.Count - 1
                    'Update set_paid=1 of accom_stage
                    Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
                    objBEAccomRouteStage.AccomStageId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("AccomStageId"))
                    objBEAccomRouteStage.SetPaid = True
                    Dim intAffectedRow As Integer = (New clsDLAccomRouteStage()).UpdateSetPaidById(objBEAccomRouteStage)

                    If bnlExecuteStatus = True Then
                        objBEPaymentToSupplier.SupplierType = 1
                        Dim dstData As DataSet = (New clsDLPaymentToSupplier()).GetSupplierDetailBySupplierTypeAndCompanyId(objBEPaymentToSupplier, intCompanyId)
                        Dim dtTempData As DataTable = dstData.Tables(0)
                        dtTempData.DefaultView.RowFilter = "accom_stage_id = " + objFunction.ReturnString(dstClientBooking.Tables(0).Rows(i)("AccomStageId"))
                        Dim dtData As DataTable = dtTempData.DefaultView.ToTable()

                        If Not objFunction.CheckDataTable(dtData) Then
                            objBEPaymentToSupplier.SupplierId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("accomodation_id"))
                            objBEPaymentToSupplier.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("bookingid"))
                            objBEPaymentToSupplier.DateEntered = DateTime.Now
                            objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Month)
                            objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Year)
                            objBEPaymentToSupplier.SupplierType = 1
                            objBEPaymentToSupplier.AccomStageId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("AccomStageId"))
                            objDLPaymentToSupplier.AddPaymentToSupplier(objBEPaymentToSupplier)
                        End If
                    Else
                        objBEPaymentToSupplier.SupplierId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("accomodation_id"))
                        objBEPaymentToSupplier.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("bookingid"))
                        objBEPaymentToSupplier.DateEntered = DateTime.Now
                        objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                        objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                        objBEPaymentToSupplier.SupplierType = 1
                        objBEPaymentToSupplier.AccomStageId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("AccomStageId"))
                        objDLPaymentToSupplier.AddPaymentToSupplier(objBEPaymentToSupplier)
                    End If

                    'Add Booking_Status_Bookings
                    'Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                    'Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                    'objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("bookingid"))
                    'objBEBookingStatusBookings.BSCId = 19
                    'objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)

                Next

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub btn_Refresh_21PDTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Refresh_21PDTA.Click
        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            objBEPaymentToSupplier.SupplierType = 1
            objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            Dim dstData As DataSet = (New clsDLPaymentToSupplier()).GetSupplierDetailByMonthYearSupplierTypeAndCompanyId(objBEPaymentToSupplier, intCompanyId)
            If objFunction.CheckDataSet(dstData) Then
                Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
                Dim intAffectedRow As Integer = 0
                Dim bnlError As Boolean = False
                For i = 0 To dstData.Tables(0).Rows.Count - 1
                    objBEAccomRouteStage.AccomStageId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("accom_stage_id"))
                    objBEAccomRouteStage.SetPaid = False
                    intAffectedRow = (New clsDLAccomRouteStage()).UpdateSetPaidById(objBEAccomRouteStage)
                    If intAffectedRow <= 0 Then
                        bnlError = True
                    End If
                Next

                'If bnlError = False Then
                Dim intAffRow As Integer = (New clsDLPaymentToSupplier()).DeleteSupplierDetailByMonthYearSupplierTypeAndCompanyId(objBEPaymentToSupplier, intCompanyId)
                'End If

                'Dim dtDataTemp As DataTable = dstData.Tables(0)
                'dtDataTemp.DefaultView.Sort = "booking_id ASC"
                'Dim dtData As DataTable = dtDataTemp.DefaultView.ToTable(True, "booking_id")

                'If objFunction.CheckDataTable(dtData) Then
                '    Dim strBookingIds As String = ""
                '    For i = 0 To dtData.Rows.Count - 1
                '        strBookingIds += objFunction.ReturnString(dtData.Rows(i)("booking_id")) + ","
                '    Next
                '    Trace.Warn("strBookingIds = " + strBookingIds.TrimEnd(","))
                'End If
            End If

            Get21stPaymentsDueToAccommodations(True)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to get 28th - Baggage Services Account Payable
    ''' </summary>
    Protected Sub Get28thBaggageServicesAccountPayable(Optional ByVal bnlExecuteStatus As Boolean = False)

        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            'Dim strSearchByFromDate As String = FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")
            Dim strSearchByToDate As String = LastDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")
            Trace.Warn("Get28thBaggageServicesAccountPayable() strSearchByToDate = " + strSearchByToDate)

            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            Dim objDLPaymentToSupplier As clsDLPaymentToSupplier = New clsDLPaymentToSupplier

            Dim dstClientBooking As DataSet = (New clsDLClientBooking()).Get28thBaggageServicesAccountPayable(strSearchByToDate, intCompanyId)
            If objFunction.CheckDataSet(dstClientBooking) Then

                For i = 0 To dstClientBooking.Tables(0).Rows.Count - 1
                    'Update set_paid=1 of extras_baggage_booking
                    Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
                    objBEExtrasBaggageBooking.ExtrasBaggageBookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtrasBaggageBookingId"))
                    objBEExtrasBaggageBooking.SetPaid = True
                    Dim intAffectedRow As Integer = (New clsDLExtrasBaggageBooking()).UpdateSetPaidById(objBEExtrasBaggageBooking)

                    If bnlExecuteStatus = True Then
                        objBEPaymentToSupplier.SupplierType = 2
                        Dim dstData As DataSet = (New clsDLPaymentToSupplier()).GetSupplierDetailBySupplierTypeAndCompanyId(objBEPaymentToSupplier, intCompanyId)
                        Dim dtTempData As DataTable = dstData.Tables(0)
                        dtTempData.DefaultView.RowFilter = "accom_stage_id = " + objFunction.ReturnString(dstClientBooking.Tables(0).Rows(i)("ExtrasBaggageBookingId"))
                        Dim dtData As DataTable = dtTempData.DefaultView.ToTable()

                        If Not objFunction.CheckDataTable(dtData) Then
                            objBEPaymentToSupplier.SupplierId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtraId"))
                            objBEPaymentToSupplier.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("BookingId"))
                            objBEPaymentToSupplier.DateEntered = DateTime.Now
                            objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Month)
                            objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Year)
                            objBEPaymentToSupplier.SupplierType = 2
                            objBEPaymentToSupplier.AccomStageId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtrasBaggageBookingId"))
                            objDLPaymentToSupplier.AddPaymentToSupplier(objBEPaymentToSupplier)
                        End If
                    Else
                        objBEPaymentToSupplier.SupplierId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtraId"))
                        objBEPaymentToSupplier.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("BookingId"))
                        objBEPaymentToSupplier.DateEntered = DateTime.Now
                        objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                        objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                        objBEPaymentToSupplier.SupplierType = 2
                        objBEPaymentToSupplier.AccomStageId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtrasBaggageBookingId"))
                        objDLPaymentToSupplier.AddPaymentToSupplier(objBEPaymentToSupplier)
                    End If

                    'Add Booking_Status_Bookings
                    'Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                    'Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                    'objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("bookingid"))
                    'objBEBookingStatusBookings.BSCId = 20
                    'objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)

                Next

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub btn_Refresh_28BSAP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Refresh_28BSAP.Click
        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            objBEPaymentToSupplier.SupplierType = 2
            objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            Dim dstData As DataSet = (New clsDLPaymentToSupplier()).GetSupplierDetailByMonthYearSupplierTypeAndCompanyId(objBEPaymentToSupplier, intCompanyId)
            If objFunction.CheckDataSet(dstData) Then
                Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
                Dim intAffectedRow As Integer = 0
                Dim bnlError As Boolean = False
                For i = 0 To dstData.Tables(0).Rows.Count - 1
                    objBEExtrasBaggageBooking.ExtrasBaggageBookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("accom_stage_id"))
                    objBEExtrasBaggageBooking.SetPaid = False
                    intAffectedRow = (New clsDLExtrasBaggageBooking()).UpdateSetPaidById(objBEExtrasBaggageBooking)
                    If intAffectedRow <= 0 Then
                        bnlError = True
                    End If
                Next

                'If bnlError = False Then
                Dim intAffRow As Integer = (New clsDLPaymentToSupplier()).DeleteSupplierDetailByMonthYearSupplierTypeAndCompanyId(objBEPaymentToSupplier, intCompanyId)
                'End If
            End If

            Get28thBaggageServicesAccountPayable(True)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to get 28th - Extras Services Account Payable
    ''' </summary>
    Protected Sub Get28thExtrasServicesAccountPayable(Optional ByVal bnlExecuteStatus As Boolean = False)

        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            'Dim strSearchByFromDate As String = FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")
            Dim strSearchByToDate As String = LastDayOfMonthFromDateTime(DateTime.Now.AddMonths(1)).ToString("MM-dd-yyyy")
            Trace.Warn("Get28thExtrasServicesAccountPayable() strSearchByToDate = " + strSearchByToDate)

            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            Dim objDLPaymentToSupplier As clsDLPaymentToSupplier = New clsDLPaymentToSupplier

            Dim dstClientBooking As DataSet = (New clsDLClientBooking()).Get28thExtrasServicesAccountPayable(strSearchByToDate, intCompanyId)
            If objFunction.CheckDataSet(dstClientBooking) Then

                For i = 0 To dstClientBooking.Tables(0).Rows.Count - 1
                    'Update set_paid=1 of extras_baggage_booking
                    Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
                    objBEExtrasBooking.ExtrasBookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtrasBookingId"))
                    objBEExtrasBooking.SetPaid = True
                    Dim intAffectedRow As Integer = (New clsDLExtrasBooking()).UpdateSetPaidById(objBEExtrasBooking)

                    If bnlExecuteStatus = True Then
                        objBEPaymentToSupplier.SupplierType = 3
                        Dim dstData As DataSet = (New clsDLPaymentToSupplier()).GetSupplierDetailBySupplierTypeAndCompanyId(objBEPaymentToSupplier, intCompanyId)
                        Dim dtTempData As DataTable = dstData.Tables(0)
                        dtTempData.DefaultView.RowFilter = "accom_stage_id = " + objFunction.ReturnString(dstClientBooking.Tables(0).Rows(i)("ExtrasBookingId"))
                        Dim dtData As DataTable = dtTempData.DefaultView.ToTable()

                        If Not objFunction.CheckDataTable(dtData) Then
                            objBEPaymentToSupplier.SupplierId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtraId"))
                            objBEPaymentToSupplier.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("BookingId"))
                            objBEPaymentToSupplier.DateEntered = DateTime.Now
                            objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Month)
                            objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(dstClientBooking.Tables(0).Rows(i)("checkin_earliest")).Year)
                            objBEPaymentToSupplier.SupplierType = 3
                            objBEPaymentToSupplier.AccomStageId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtrasBookingId"))
                            objDLPaymentToSupplier.AddPaymentToSupplier(objBEPaymentToSupplier)
                        End If
                    Else
                        objBEPaymentToSupplier.SupplierId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtraId"))
                        objBEPaymentToSupplier.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("BookingId"))
                        objBEPaymentToSupplier.DateEntered = DateTime.Now
                        objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
                        objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
                        objBEPaymentToSupplier.SupplierType = 3
                        objBEPaymentToSupplier.AccomStageId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("ExtrasBookingId"))
                        objDLPaymentToSupplier.AddPaymentToSupplier(objBEPaymentToSupplier)
                    End If

                    'Add Booking_Status_Bookings
                    'Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                    'Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                    'objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstClientBooking.Tables(0).Rows(i)("bookingid"))
                    'objBEBookingStatusBookings.BSCId = 21
                    'objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)

                Next

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub btn_Refresh_28ESAP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Refresh_28ESAP.Click
        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            objBEPaymentToSupplier.SupplierType = 3
            objBEPaymentToSupplier.MonthVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            objBEPaymentToSupplier.YearVal = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            Dim dstData As DataSet = (New clsDLPaymentToSupplier()).GetSupplierDetailByMonthYearSupplierTypeAndCompanyId(objBEPaymentToSupplier, intCompanyId)
            If objFunction.CheckDataSet(dstData) Then
                Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
                Dim intAffectedRow As Integer = 0
                Dim bnlError As Boolean = False
                For i = 0 To dstData.Tables(0).Rows.Count - 1
                    objBEExtrasBooking.ExtrasBookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("accom_stage_id"))
                    objBEExtrasBooking.SetPaid = False
                    intAffectedRow = (New clsDLExtrasBooking()).UpdateSetPaidById(objBEExtrasBooking)
                    If intAffectedRow <= 0 Then
                        bnlError = True
                    End If
                Next

                'If bnlError = False Then
                Dim intAffRow As Integer = (New clsDLPaymentToSupplier()).DeleteSupplierDetailByMonthYearSupplierTypeAndCompanyId(objBEPaymentToSupplier, intCompanyId)
                'End If
            End If

            Get28thExtrasServicesAccountPayable(True)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to get Eval Reports Reminders
    ''' </summary>
    Protected Sub GetEvalReportsReminders()

        Try
            Dim dstData As DataSet
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim strSearchByFromDate As String = DateTime.Now.AddDays(-4).ToString("MM-dd-yyyy")
            Trace.Warn("strSearchByFromDate = " + objFunction.ReturnString(strSearchByFromDate))

            dstData = (New clsDLClientBooking()).GetEvalReportsReminders(strSearchByFromDate, intCompanyId)
            'Trace.Warn("dstData count = " + objFunction.ReturnString(dstData.Tables(0).Rows.Count))

            GRID_Eval_Report_Reminders.DataSource = dstData
            GRID_Eval_Report_Reminders.DataBind()
            DIV_EvalReportsReminders.Attributes.Add("style", "display:block;")

            'If objFunction.CheckDataSet(dstData) Then
            '    GRID_Eval_Report_Reminders.DataSource = dstData
            '    GRID_Eval_Report_Reminders.DataBind()
            '    DIV_EvalReportsReminders.Attributes.Add("style", "display:block;")
            'End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Eval_Report_Reminders_PageIndexChanging
    ''' </summary>
    Protected Sub GRID_Eval_Report_Reminders_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Send_Client_URL.PageIndex = e.NewPageIndex
            GetEvalReportsReminders()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Eval_Report_Reminders_PageIndexChanging
    ''' </summary>
    Protected Sub GRID_Eval_Report_Reminders_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Session("BookingId") = objFunction.ReturnString(GRID_Eval_Report_Reminders.DataKeys(e.NewSelectedIndex).Value)
            'Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function return first date of the month by date
    ''' </summary>
    Public Function FirstDayOfMonthFromDateTime(ByVal dateTime As DateTime) As DateTime
        Return New DateTime(dateTime.Year, dateTime.Month, 1)
    End Function

    ''' <summary>
    ''' This function return last date of the month by date
    ''' </summary>
    Public Function LastDayOfMonthFromDateTime(ByVal dateTime As DateTime) As DateTime
        Dim firstDayOfTheMonth As New DateTime(dateTime.Year, dateTime.Month, 1)
        Return firstDayOfTheMonth.AddMonths(1).AddDays(-1)
    End Function

    ''' <summary>
    ''' This function return last date of the month by month and year
    ''' </summary>
    Public Function LastDayOfMonthByMonthAndYear(ByVal intMonth As Integer, ByVal intYear As Integer) As String
        Try
            Dim firstDayOfTheMonth As New DateTime(intYear, intMonth, 1)
            Dim dt As DateTime = firstDayOfTheMonth.AddMonths(1).AddDays(-1)
            Return dt.ToString("dd MMMM yyyy")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return ""
    End Function

    ''' <summary>
    ''' This event is used to submit form
    ''' </summary>
    Protected Sub BUT_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Submit.Click

        Try
            Session("RouteId") = objFunction.ReturnString(DROP_TourList.SelectedItem.Value)
            Dim strTravelDate As String() = TB_Date_of_Travel.Text.Split("/")
            Session("TravelDate") = objFunction.ReturnString(strTravelDate(1) + "/" + strTravelDate(0) + "/" + strTravelDate(2))
            'Trace.Warn("Date = " + objFunction.ReturnString(strTravelDate(1) + "/" + strTravelDate(0) + "/" + strTravelDate(2)))
            Response.Redirect("bookings_enquiry.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub BUT_Search_Name_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Search_Name.Click

        Try
            Session("SearchByName") = TB_Search_Name.Text
            Response.Redirect("bookings_search.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub BUT__Search_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Search_Booking.Click

        Try
            Session("SearchByBookingRef") = TB_Search_Booking.Text
            Response.Redirect("bookings_search.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub BUT__Search_Date_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Search_Date.Click

        Try
            Session("SearchByDate") = TB_Search_Date.Text
            Response.Redirect("bookings_search.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetDateVal(ByVal value As Object) As String
        Try
            If objFunction.ReturnString(value) <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(value)
                Return dt.ToString("dd-MM-yyyy")
            Else
                Return ""
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return ""
    End Function

    Protected Sub BUT_Report_Ready_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Report_Ready.Click
        Try
            Session("Supplier_Payment_MM") = objFunction.ReturnString(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            Session("Supplier_Payment_YYYY") = objFunction.ReturnString(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            Session("Supplier_Payment_Type") = "1"
            Response.Redirect("reports_supplier_payments_due.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub BUT_Report_Ready2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Report_Ready2.Click
        Try
            Session("Supplier_Payment_MM") = objFunction.ReturnString(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            Session("Supplier_Payment_YYYY") = objFunction.ReturnString(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            Session("Supplier_Payment_Type") = "2"
            Response.Redirect("reports_supplier_payments_due.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub BUT_Report_Ready3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Report_Ready3.Click
        Try
            Session("Supplier_Payment_MM") = objFunction.ReturnString(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            Session("Supplier_Payment_YYYY") = objFunction.ReturnString(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            Session("Supplier_Payment_Type") = "3"
            Response.Redirect("reports_supplier_payments_due.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub BUT_Email_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Email_All.Click
        Try
            'Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            'Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            'Dim objDLPaymentToSupplier As clsDLPaymentToSupplier = New clsDLPaymentToSupplier

            'Dim intMonthVal As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
            'Dim intYearVal As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
            ''Dim intMonthVal As Integer = 9
            ''Dim intYearVal As Integer = 2017
            'objBEPaymentToSupplier.MonthVal = intMonthVal
            'objBEPaymentToSupplier.YearVal = intYearVal
            'objBEPaymentToSupplier.SupplierType = 1

            'Dim objBEPaymentToSupplierEmailSent As clsBEPaymentToSupplierEmailSent = New clsBEPaymentToSupplierEmailSent
            'objBEPaymentToSupplierEmailSent.MonthVal = intMonthVal
            'objBEPaymentToSupplierEmailSent.YearVal = intYearVal
            'objBEPaymentToSupplierEmailSent.SupplierType = 1
            'Dim dstSendEmailData As DataSet = (New clsDLPaymentToSupplierEmailSent()).GetSupplierEmailDetailByMonthYearAndSupplierType(objBEPaymentToSupplierEmailSent, intCompanyId)

            'Dim dstData As DataSet = objDLPaymentToSupplier.GetSupplierDetailByMonthYearAndSupplierType(objBEPaymentToSupplier, intCompanyId)

            'If objFunction.CheckDataSet(dstData) Then

            '    Trace.Warn("Count = " + objFunction.ReturnString(dstData.Tables(0).Rows.Count))
            '    Dim dtDistinctData As DataTable = dstData.Tables(0).DefaultView.ToTable(True, "supplier_id")
            '    Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))

            '    If objFunction.CheckDataTable(dtDistinctData) Then

            '        Dim lstEmailContent = New List(Of Dictionary(Of String, String))()

            '        For i = 0 To dtDistinctData.Rows.Count - 1
            '            Dim dtTemp As DataTable = dstData.Tables(0)
            '            dtTemp.DefaultView.RowFilter = "supplier_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("supplier_id")) + " AND supplier_id <> 0"
            '            Dim dtData As DataTable = dtTemp.DefaultView.ToTable()

            '            Trace.Warn("supplier_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("supplier_id")))
            '            If objFunction.CheckDataTable(dtData) Then

            '                Trace.Warn("dtData Count = " + objFunction.ReturnString(dtData.Rows.Count))

            '                Dim dtEmailDataTemp As DataTable = Nothing
            '                Dim dtEmailData As DataTable = Nothing
            '                If objFunction.CheckDataSet(dstSendEmailData) Then
            '                    dtEmailDataTemp = dstSendEmailData.Tables(0)
            '                    dtEmailDataTemp.DefaultView.RowFilter = "supplier_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("supplier_id")) + " AND supplier_id <> 0"
            '                    dtEmailData = dtEmailDataTemp.DefaultView.ToTable()
            '                End If

            '                If Not objFunction.CheckDataTable(dtEmailData) Then

            '                    Dim strRepeaterData As String = ""
            '                    Dim dblTotalCost As Double = 0

            '                    For j = 0 To dtData.Rows.Count - 1

            '                        Dim lngNoOfNight As Long = 0
            '                        If objFunction.ReturnString(dtData.Rows(j)("checkin")) <> "" And objFunction.ReturnString(dtData.Rows(j)("checkout")) <> "" Then
            '                            lngNoOfNight = DateDiff(DateInterval.Day, Convert.ToDateTime(dtData.Rows(j)("checkin")), Convert.ToDateTime(dtData.Rows(j)("checkout")))
            '                        End If
            '                        Trace.Warn("lngNoOfNight = " + objFunction.ReturnString(lngNoOfNight))

            '                        Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
            '                        objBEAccomStageRoom.AccomStageId = objFunction.ReturnInteger(dtData.Rows(j)("accom_stage_id"))
            '                        Dim dstTotalCostToEasyways As DataSet = (New clsDLAccomStageRoom()).GetAccomStageRoomByAccomStageId(objBEAccomStageRoom)
            '                        Dim dblCost As Double = 0
            '                        If objFunction.CheckDataSet(dstTotalCostToEasyways) Then
            '                            For k = 0 To dstTotalCostToEasyways.Tables(0).Rows.Count - 1
            '                                dblCost += (objFunction.ReturnDouble(dstTotalCostToEasyways.Tables(0).Rows(k)("cost_easyways")) + objFunction.ReturnDouble(dstTotalCostToEasyways.Tables(0).Rows(k)("total_cost_dogs"))) * lngNoOfNight
            '                            Next
            '                        End If
            '                        dblTotalCost += dblCost

            '                        strRepeaterData += "<br/>" + objFunction.ReturnString(dtData.Rows(j)("unique_id")) + "&nbsp;&mdash;&nbsp; " + SetDateVal(objFunction.ReturnString(dtData.Rows(j)("DateStarted"))) + "&nbsp;&mdash;&nbsp;" + objFunction.ReturnString(dtData.Rows(j)("ClientName")) + "&nbsp;&mdash;&nbsp;" + dblCost.ToString("0.00")

            '                    Next

            '                    'Trace.Warn("dblTotalCost = " + objFunction.ReturnString(dblTotalCost))

            '                    Dim strEmailContent As String = (New clsEmailContent()).PaymentsDueToAccommodationsEmail(objFunction.ReturnString(dtData.Rows(0)("SupplierName")), SetDateVal(DateTime.Now), objFunction.ReturnString(dtData.Rows(0)("SupplierContact")), strRepeaterData, dblTotalCost.ToString("0.00"))
            '                    'Trace.Warn("strEmailContent = " + strEmailContent)

            '                    Dim objEmailContent As New Dictionary(Of String, String)()
            '                    objEmailContent.Add("SupplierId", objFunction.ReturnString(dtData.Rows(0)("supplier_id")))
            '                    objEmailContent.Add("Name", objFunction.ReturnString(dtData.Rows(0)("SupplierContact")))
            '                    objEmailContent.Add("Email", objFunction.ReturnString(dtData.Rows(0)("SupplierEmail")))
            '                    objEmailContent.Add("Subject", "Confirmation of payments – " + objFunction.ReturnString(dtData.Rows(0)("SupplierName")))
            '                    objEmailContent.Add("Body", strEmailContent)
            '                    lstEmailContent.Add(objEmailContent)

            '                End If

            '            End If
            '        Next

            '        Dim strEmailSuccess As String = ""
            '        'Dim strSuccessEmail As String = ""
            '        Dim strEmailError As String = ""
            '        Dim strFailEmail As String = ""
            '        If lstEmailContent.Count > 0 Then
            '            For i = 0 To lstEmailContent.Count - 1
            '                'Dim strName As String = lstEmailContent(i).Item("Name")
            '                'Trace.Warn("List value = " + strName)
            '                Dim strMailStatus As String = clsEmail.SendEmail(lstEmailContent(i).Item("Name"), lstEmailContent(i).Item("Email"), "Supplier Email", "Test Msg", lstEmailContent(i).Item("Body"), Me)
            '                If strMailStatus = "Success" Then
            '                    strEmailSuccess = "Send email to supplier."
            '                    'strSuccessEmail += lstEmailContent(i).Item("Email") + ","
            '                    objBEPaymentToSupplierEmailSent.SupplierId = lstEmailContent(i).Item("SupplierId")
            '                    objBEPaymentToSupplierEmailSent.DateEntered = DateTime.Now
            '                    objBEPaymentToSupplierEmailSent.MonthVal = intMonthVal
            '                    objBEPaymentToSupplierEmailSent.YearVal = intYearVal
            '                    objBEPaymentToSupplierEmailSent.SupplierType = 1
            '                    Dim intAffectedRow As Integer = (New clsDLPaymentToSupplierEmailSent()).AddPaymentToSupplierEmailSent(objBEPaymentToSupplierEmailSent)
            '                Else
            '                    strEmailError = strMailStatus
            '                    strFailEmail += lstEmailContent(i).Item("Email") + ","
            '                End If
            '            Next
            '        End If

            '        Dim javaScript As String = ""
            '        Dim strAlertMsg As String = strEmailSuccess
            '        If strEmailError <> "" Then
            '            strAlertMsg += "\n" + strEmailError + ". \nFail Email Id = " + strFailEmail.TrimEnd(",")
            '        End If
            '        javaScript += "<script type='text/javascript'>"
            '        javaScript += "alert('" + strAlertMsg + "');"
            '        javaScript += "window.location='dashboard.aspx#seven';"
            '        javaScript += "</script>"
            '        ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)

            '        If strEmailError = "" Then
            '            BUT_Email_All.Enabled = False
            '        End If

            '    End If
            'End If
            'Response.Redirect("dashboard.aspx#seven")

            Session("BulkEmailStatus") = "SendBulkEmail"
            Dim strUrl As String = "bulk_email.aspx"
            Response.Write("<script>")
            Response.Write("window.open('" + strUrl + "','_blank')")
            Response.Write("<" + "/script>")

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub BUT_Test_Email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Test_Email.Click
        Try
            'Session("BulkEmailStatus") = "SendBulkEmail"
            'Dim strUrl As String = "bulk_email.aspx?mode=testemail"
            Dim strUrl As String = "test_email.aspx"
            Response.Write("<script>")
            Response.Write("window.open('" + strUrl + "','_blank')")
            Response.Write("<" + "/script>")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

End Class





