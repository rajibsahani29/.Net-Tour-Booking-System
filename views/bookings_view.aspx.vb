Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_view
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            If objFunction.ReturnString(Session("BookingId")) = "" And Session("BookingId") Is Nothing Then
                Response.Redirect("bookings_search.aspx")
            End If

            If Not Page.IsPostBack Then

                Trace.Warn("Session = " + Session("feedback_call"))
                If Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 1 Then
                    Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
                ElseIf Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 2 Then
                    Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
                End If
                Session("feedback_call") = "0"
                Session("error_msg") = ""
                Trace.Warn("End Session = " + Session("feedback_call"))

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstRoute As DataSet = (New clsDLRoute()).GetRouteFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Route, dstRoute)
                DROP_Route.Items.Insert(0, New ListItem("Select Route", "0"))

                Dim dstAgent As DataSet = (New clsDLAgent()).GetAgentDetailFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Agent, dstAgent)
                DROP_Agent.Items.Insert(0, New ListItem("Easyways", "0"))

                GetBookingDetails()
                ResequenceBookingStage()
                BindGridview()

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind booking details
    ''' </summary>
    Protected Sub GetBookingDetails()

        Try
            'Trace.Warn("BookingId = " + Session("BookingId").ToString())
            Dim intBookingId = objFunction.ReturnInteger(Session("BookingId"))
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstBookingDetail As New DataSet()
            Dim objBEBooking As clsBEBooking = New clsBEBooking
            objBEBooking.BookingId = intBookingId
            objBEBooking.CompanyId = intCompanyId
            dstBookingDetail = (New clsDLBooking()).GetBookingDetailById(objBEBooking, 0)

            If dstBookingDetail IsNot Nothing Then

                LABEL_Booking_ID.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("unique_id"))
                LABEL_Client_Name.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ClientName"))
                LABEL_Tour2.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("RouteName"))
                LABEL_Staff_Name.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("StaffName"))
                Dim strCreatedDate As String = ""
                If objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("CreatedDate")) <> "" Then
                    strCreatedDate = Convert.ToDateTime(dstBookingDetail.Tables(0).Rows(0)("CreatedDate")).ToString("dd/MM/yyyy hh:mm:ss tt")
                End If
                LABEL_Date_Booking_Created.Text = strCreatedDate
                Dim dblTotalAmountPayable As Double = (New clsPaymentCalculation()).GetTotalAmountPayable(intBookingId)
                LABEL_Total_Payable.Text = "£" + dblTotalAmountPayable.ToString("0.00")
                LABEL_Agent_ID.Text = (If(objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("AgentName")) <> "", objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("AgentName")), "Easyways"))
                Dim dblTotalBalanceRemaining As Double = (New clsPaymentCalculation()).GetTotalBalanceRemaining(dblTotalAmountPayable, intBookingId)
                LABEL_Balance_Remaining.Text = "£" + dblTotalBalanceRemaining.ToString("0.00")
                If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("UrlVisited")) = True Then
                    CHK_URL.Checked = True
                End If
                If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("customised")) = True Then
                    CHK_Customised.Checked = True
                End If
                LABEL_No_of_Booking_Notes.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ClientBookingNotesCount"))
                TB_Number_of_Males.Text = objFunction.ReturnString(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("no_males")))
                TB_Number_of_Females.Text = objFunction.ReturnString(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("no_females")))
                TB_Number_of_Unspecified.Text = objFunction.ReturnString(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("no_other")))
                TB_Tour_Cost.Text = objFunction.ReturnDouble(dstBookingDetail.Tables(0).Rows(0)("route_cost_client")).ToString("0.00")
                LABEL_Accom_Band.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("priceband"))

                hdnTempRouteCostEasyway.Value = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("route_cost_easyways"))
                hdnOldRouteId.Value = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("route_id"))
                DROP_Route.Items.FindByValue(objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("route_id"))).Selected = True
                If objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("agent_id")) > 0 Then
                    DROP_Agent.Items.FindByValue(objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("agent_id"))).Selected = True
                End If

                If objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("priceband")) <> "" Then
                    DROP_Accom_Band.Items.FindByValue(objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("priceband"))).Selected = True
                End If

                If objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ensuite")) <> "" Then
                    DROP_Ensuite.Items.FindByValue(objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ensuite"))).Selected = True
                End If

                If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("customised")) = True Then
                    CHK_Customised2.Checked = True
                End If

                If Convert.IsDBNull(dstBookingDetail.Tables(0).Rows(0)("dog_friendly")) = False Then
                    If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("dog_friendly")) = True Then
                        CHK_Dog_Friendly.Checked = True
                    End If
                End If
                
                ViewState.Add("BookingClientId", objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ClientId")))

                Dim intBookingRouteId As Integer = objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("route_id"))
                Dim dstRouteStage As DataSet = (New clsDLRouteStage()).GetRouteStageByBookingRouteIdFillInDD(intBookingRouteId, intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Stage, dstRouteStage)
                DROP_Stage.Items.Insert(0, New ListItem("Select Stage", ""))

                Dim dstBookingEvaluationDetail As DataSet = (New clsDLBookingEvaluation()).GetBookingEvaluationByBookingId(intBookingId)
                If objFunction.CheckDataSet(dstBookingEvaluationDetail) Then
                    BUT_View_Evaluation.Enabled = True
                End If

                Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                objBEBookingStatusBookings.BookingId = intBookingId
                Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingId(objBEBookingStatusBookings)
                If objFunction.CheckDataSet(dstBookingStatusBookings) Then

                    Dim dstBookingStatusComplete As DataSet
                    Dim objBEBookingStatusComplete As clsBEBookingStatusComplete = New clsBEBookingStatusComplete
                    If objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("agent_id")) = 0 Then
                        objBEBookingStatusComplete.Easyways = True
                        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByEasyways(objBEBookingStatusComplete)
                    Else
                        objBEBookingStatusComplete.Agent = True
                        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByAgent(objBEBookingStatusComplete)
                    End If

                    If objFunction.CheckDataSet(dstBookingStatusComplete) Then

                        Dim dtData As DataTable
                        Dim dtDataTemp As DataTable

                        'Booking Status
                        dtData = dstBookingStatusBookings.Tables(0)
                        dtData.DefaultView.RowFilter = "cat = 1"
                        dtData.DefaultView.Sort = "orderx DESC"
                        dtDataTemp = dtData.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtDataTemp) Then
                            'LABEL_Booking_Status.Text = objFunction.ReturnString(dtDataTemp.Rows(0)("name"))
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 1"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                Dim strNextBookingStatus As String = ""

                                Dim lstStatus As List(Of String) = New List(Of String)
                                For k = 0 To dtDataTemp.Rows.Count - 1
                                    Dim strName As String = objFunction.ReturnString(dtDataTemp.Rows(k)("name")).ToLower()
                                    If strName = ("For JB").ToLower() Or strName = ("For MAJ").ToLower() Or strName = ("Cancelled").ToLower() Or strName = ("Complete").ToLower() Then
                                        lstStatus.Add(objFunction.ReturnString(dtDataTemp.Rows(k)("name")))
                                    End If
                                Next

                                'New Logic
                                If lstStatus.Contains("For JB") = True Then
                                    strNextBookingStatus = "For JB"
                                ElseIf lstStatus.Contains("For MAJ") = True Then
                                    strNextBookingStatus = "For MAJ"
                                ElseIf lstStatus.Contains("Cancelled") = True Then
                                    strNextBookingStatus = "Cancelled"
                                ElseIf lstStatus.Contains("Complete") = True Then
                                    strNextBookingStatus = "Complete"
                                Else
                                    For j = 0 To dtStatusTemp.Rows.Count - 1
                                        dtDataTemp.DefaultView.RowFilter = "bsc_id = " + objFunction.ReturnString(dtStatusTemp.Rows(j)("id"))
                                        Dim dt As DataTable = dtDataTemp.DefaultView.ToTable()
                                        If Not objFunction.CheckDataTable(dt) Then
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                            Exit For
                                        End If
                                    Next
                                End If

                                'Old Logic
                                'For j = 0 To dtStatusTemp.Rows.Count - 1
                                '    If objFunction.ReturnInteger(dtStatusTemp.Rows(j)("orderx")) = objFunction.ReturnInteger(dtDataTemp.Rows(0)("orderx")) Then
                                '        Dim strBookingStatus As String = objFunction.ReturnString(dtStatusTemp.Rows(j)("name")).ToLower()
                                '        Trace.Warn("strBookingStatus = " + strBookingStatus)
                                '        If strBookingStatus = ("For JB").ToLower() Or lstStatus.Contains("For JB") = True Then
                                '            strNextBookingStatus = "For JB"
                                '        ElseIf strBookingStatus = ("For MAJ").ToLower() Or lstStatus.Contains("For MAJ") = True Then
                                '            strNextBookingStatus = "For MAJ"
                                '        ElseIf strBookingStatus = ("Cancelled").ToLower() Or lstStatus.Contains("Cancelled") = True Then
                                '            strNextBookingStatus = "Cancelled"
                                '        ElseIf strBookingStatus = ("Complete").ToLower() Or lstStatus.Contains("Complete") = True Then
                                '            strNextBookingStatus = "Complete"
                                '        Else
                                '            If j = (dtStatusTemp.Rows.Count - 1) Then
                                '                strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                '            Else
                                '                'Trace.Warn("Booking Status name j = " + objFunction.ReturnString(objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))))
                                '                'Trace.Warn("Booking Status name j+1 = " + objFunction.ReturnString(objFunction.ReturnString(dtStatusTemp.Rows(j + 1)("name"))))
                                '                strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j + 1)("name"))
                                '            End If
                                '        End If
                                '        Exit For
                                '    End If
                                'Next
                                LABEL_Booking_Status.Text = strNextBookingStatus
                            End If
                        Else
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 1"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                LABEL_Booking_Status.Text = objFunction.ReturnString(dtStatusTemp.Rows(0)("name"))
                            Else
                                LABEL_Booking_Status.Text = ""
                            End If
                        End If

                        'Baggage Status
                        dtData = dstBookingStatusBookings.Tables(0)
                        dtData.DefaultView.RowFilter = "cat = 2"
                        dtData.DefaultView.Sort = "orderx DESC"
                        dtDataTemp = dtData.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtDataTemp) Then
                            'LABEL_Baggage_Booking_Status.Text = objFunction.ReturnString(dtDataTemp.Rows(0)("name"))
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 2"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                Dim strNextBookingStatus As String = ""

                                Dim lstStatus As List(Of String) = New List(Of String)
                                For k = 0 To dtDataTemp.Rows.Count - 1
                                    Dim strName As String = objFunction.ReturnString(dtDataTemp.Rows(k)("name")).ToLower()
                                    If strName = ("Baggage Not Required").ToLower() Or strName = ("Pay Baggage").ToLower() Then
                                        lstStatus.Add(objFunction.ReturnString(dtDataTemp.Rows(k)("name")))
                                    End If
                                Next

                                'New Logic
                                If lstStatus.Contains("Pay Baggage") = True Then
                                    strNextBookingStatus = "Pay Baggage"
                                ElseIf lstStatus.Contains("Baggage Not Required") = True Then
                                    strNextBookingStatus = "Baggage Not Required"
                                Else
                                    For j = 0 To dtStatusTemp.Rows.Count - 1
                                        dtDataTemp.DefaultView.RowFilter = "bsc_id = " + objFunction.ReturnString(dtStatusTemp.Rows(j)("id"))
                                        Dim dt As DataTable = dtDataTemp.DefaultView.ToTable()
                                        If Not objFunction.CheckDataTable(dt) Then
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                            Exit For
                                        End If
                                    Next
                                End If

                                'Old Logic
                                'For j = 0 To dtStatusTemp.Rows.Count - 1
                                '    If objFunction.ReturnInteger(dtStatusTemp.Rows(j)("orderx")) = objFunction.ReturnInteger(dtDataTemp.Rows(0)("orderx")) Then
                                '        Dim strBookingStatus As String = objFunction.ReturnString(dtStatusTemp.Rows(j)("name")).ToLower()
                                '        Trace.Warn("strBookingStatus = " + strBookingStatus)
                                '        If strBookingStatus = ("Pay Baggage").ToLower() Or lstStatus.Contains("Pay Baggage") = True Then
                                '            strNextBookingStatus = "Pay Baggage"
                                '        Else
                                '            If objFunction.ReturnString(dtStatusTemp.Rows(j)("name")).ToLower() = ("Baggage Not Required").ToLower() Or lstStatus.Contains("Baggage Not Required") = True Then
                                '                strNextBookingStatus = "Baggage Not Required"
                                '            Else
                                '                If j = (dtStatusTemp.Rows.Count - 1) Then
                                '                    strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                '                Else
                                '                    strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j + 1)("name"))
                                '                End If
                                '            End If
                                '        End If
                                '        Exit For
                                '    End If
                                'Next
                                LABEL_Baggage_Booking_Status.Text = strNextBookingStatus
                            End If
                        Else
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 2"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                LABEL_Baggage_Booking_Status.Text = objFunction.ReturnString(dtStatusTemp.Rows(0)("name"))
                            Else
                                LABEL_Baggage_Booking_Status.Text = ""
                            End If
                        End If

                        'Extras Status
                        dtData = dstBookingStatusBookings.Tables(0)
                        dtData.DefaultView.RowFilter = "cat = 3"
                        dtData.DefaultView.Sort = "orderx DESC"
                        dtDataTemp = dtData.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtDataTemp) Then
                            'LABEL_Extras_Booking_Status.Text = objFunction.ReturnString(dtDataTemp.Rows(0)("name"))
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 3"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                Dim strNextBookingStatus As String = ""

                                Dim lstStatus As List(Of String) = New List(Of String)
                                For k = 0 To dtDataTemp.Rows.Count - 1
                                    Dim strName As String = objFunction.ReturnString(dtDataTemp.Rows(k)("name")).ToLower()
                                    If strName = ("Taxi Not Required").ToLower() Or strName = ("Pay Taxis").ToLower() Then
                                        lstStatus.Add(objFunction.ReturnString(dtDataTemp.Rows(k)("name")))
                                    End If
                                Next

                                'New Logic
                                If lstStatus.Contains("Pay Taxis") = True Then
                                    strNextBookingStatus = "Pay Taxis"
                                ElseIf lstStatus.Contains("Taxi Not Required") = True Then
                                    strNextBookingStatus = "Taxi Not Required"
                                Else
                                    For j = 0 To dtStatusTemp.Rows.Count - 1
                                        dtDataTemp.DefaultView.RowFilter = "bsc_id = " + objFunction.ReturnString(dtStatusTemp.Rows(j)("id"))
                                        Dim dt As DataTable = dtDataTemp.DefaultView.ToTable()
                                        If Not objFunction.CheckDataTable(dt) Then
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                            Exit For
                                        End If
                                    Next
                                End If

                                'Old Logic
                                'For j = 0 To dtStatusTemp.Rows.Count - 1
                                '    If objFunction.ReturnInteger(dtStatusTemp.Rows(j)("orderx")) = objFunction.ReturnInteger(dtDataTemp.Rows(0)("orderx")) Then
                                '        Dim strBookingStatus As String = objFunction.ReturnString(dtStatusTemp.Rows(j)("name")).ToLower()
                                '        Trace.Warn("strBookingStatus = " + strBookingStatus)
                                '        If strBookingStatus = objFunction.ReturnString("Pay Taxis").ToLower() Or lstStatus.Contains("Pay Taxis") = True Then
                                '            strNextBookingStatus = "Pay Taxis"
                                '        Else
                                '            If objFunction.ReturnString(dtStatusTemp.Rows(j)("name")).ToLower() = ("Taxi Not Required").ToLower() Or lstStatus.Contains("Taxi Not Required") = True Then
                                '                strNextBookingStatus = "Taxi Not Required"
                                '            Else
                                '                If j = (dtStatusTemp.Rows.Count - 1) Then
                                '                    strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                '                Else
                                '                    strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j + 1)("name"))
                                '                End If
                                '            End If
                                '        End If
                                '        Exit For
                                '    End If
                                'Next
                                LABEL_Extras_Booking_Status.Text = strNextBookingStatus
                            End If
                        Else
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 3"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                LABEL_Extras_Booking_Status.Text = objFunction.ReturnString(dtStatusTemp.Rows(0)("name"))
                            Else
                                LABEL_Extras_Booking_Status.Text = ""
                            End If
                        End If

                    End If
                Else
                    Dim dstBookingStatusComplete As DataSet
                    Dim objBEBookingStatusComplete As clsBEBookingStatusComplete = New clsBEBookingStatusComplete
                    If objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("agent_id")) = 0 Then
                        objBEBookingStatusComplete.Easyways = True
                        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByEasyways(objBEBookingStatusComplete)
                    Else
                        objBEBookingStatusComplete.Agent = True
                        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByAgent(objBEBookingStatusComplete)
                    End If

                    If objFunction.CheckDataSet(dstBookingStatusComplete) Then

                        Dim dtStatus As DataTable
                        Dim dtStatusTemp As DataTable

                        dtStatus = dstBookingStatusComplete.Tables(0)
                        dtStatus.DefaultView.RowFilter = "cat = 1"
                        dtStatusTemp = dtStatus.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtStatusTemp) Then
                            LABEL_Booking_Status.Text = objFunction.ReturnString(dtStatusTemp.Rows(0)("name"))
                        Else
                            LABEL_Booking_Status.Text = ""
                        End If

                        dtStatus = dstBookingStatusComplete.Tables(0)
                        dtStatus.DefaultView.RowFilter = "cat = 2"
                        dtStatusTemp = dtStatus.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtStatusTemp) Then
                            LABEL_Baggage_Booking_Status.Text = objFunction.ReturnString(dtStatusTemp.Rows(0)("name"))
                        Else
                            LABEL_Baggage_Booking_Status.Text = ""
                        End If

                        dtStatus = dstBookingStatusComplete.Tables(0)
                        dtStatus.DefaultView.RowFilter = "cat = 3"
                        dtStatusTemp = dtStatus.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtStatusTemp) Then
                            LABEL_Extras_Booking_Status.Text = objFunction.ReturnString(dtStatusTemp.Rows(0)("name"))
                        Else
                            LABEL_Extras_Booking_Status.Text = ""
                        End If

                    End If
                End If

                If Convert.IsDBNull(dstBookingDetail.Tables(0).Rows(0)("cancelled")) = False Then
                    If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("cancelled")) = True Then
                        BUT_Client_View.Enabled = False
                        BUT_View_URL.Enabled = False
                        'BUT_Add_Note_Booking.Enabled = False
                        BUT_Additional_Info.Enabled = False
                        BUT_Additional_Extras.Enabled = False
                        BUT_View_Evaluation.Enabled = False
                        BUT_TBC.Enabled = False
                        BUT_Email_Suppliers.Enabled = False
                        BUT_Resequence_Stages.Enabled = False
                        BUT_Cancel_Booking.Enabled = False
                        BUT_Delete_Booking.Enabled = False
                        GridView1.Enabled = False
                        BUT_Add_Accom_to_Stage.Enabled = False
                        BUT__Update.Enabled = False

                        LABEL_Total_Payable.Text = "£" + objFunction.ReturnDouble(dstBookingDetail.Tables(0).Rows(0)("cancellation_amount")).ToString("0.00")
                        Dim dblPaymentMade As Double = dblTotalAmountPayable - dblTotalBalanceRemaining
                        LABEL_Balance_Remaining.Text = "£" + objFunction.ReturnDouble(dstBookingDetail.Tables(0).Rows(0)("cancellation_amount") - dblPaymentMade).ToString("0.00")
                    End If
                End If

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindGridview()

        Try
            Dim intBookingId = objFunction.ReturnInteger(Session("BookingId"))
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstAccomRouteStage As New DataSet()
            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.BookingId = intBookingId
            dstAccomRouteStage = (New clsDLAccomRouteStage()).GetAccomRouteStageByBookingId(objBEAccomRouteStage, intCompanyId)
            GridView1.DataSource = dstAccomRouteStage
            GridView1.DataBind()

            For i As Integer = 0 To GridView1.Rows.Count - 1
                Dim gRow As GridViewRow = GridView1.Rows(i)
                'Dim chkPaid = DirectCast(gRow.FindControl("CHK_Paid"), CheckBox)
                Dim lblPaidDate = DirectCast(gRow.FindControl("LABEL_PaidDate"), Label)
                If lblPaidDate IsNot Nothing Then
                    Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
                    objBEPaymentToSupplier.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                    Trace.Warn("accomodation_id = " + objFunction.ReturnString(dstAccomRouteStage.Tables(0).Rows(i)("accomodation_id")))
                    objBEPaymentToSupplier.SupplierId = objFunction.ReturnInteger(dstAccomRouteStage.Tables(0).Rows(i)("accomodation_id"))
                    objBEPaymentToSupplier.SupplierType = 1
                    Dim dstData As DataSet = (New clsDLPaymentToSupplier()).GetSupplierDetailByBookingIdSupplierIdAndSupplierType(objBEPaymentToSupplier)
                    If objFunction.CheckDataSet(dstData) Then
                        'Dim bnlChkVal As Boolean = Convert.ToBoolean(dstData.Tables(0).Rows(0)("paid"))
                        'If bnlChkVal = True Then
                        '    chkPaid.Checked = True
                        'End If
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("date_paid")) <> "" Then
                            Dim dt As DateTime = Convert.ToDateTime(objFunction.ReturnString(dstData.Tables(0).Rows(0)("date_paid")))
                            lblPaidDate.Text = dt.ToString("dd/MM/yy")
                        End If
                    End If

                End If
            Next

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' OnRowDataBound event of the GridView1
    ''' </summary>
    Protected Sub GridView1_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            'If e.Row.RowType = DataControlRowType.DataRow Then
            '    Dim lb As LinkButton = DirectCast(e.Row.Cells(4).Controls(0), LinkButton)
            '    If lb IsNot Nothing Then
            '        If lb.Text = "Delete" Then
            '            lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
            '        End If
            '    End If
            'End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GridView1
    ''' </summary>
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GridView1.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GridView1
    ''' </summary>
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Trace.Warn("Id = " + objFunction.ReturnString(GridView1.DataKeys(e.NewSelectedIndex).Values("id")))
            'Trace.Warn("Seq = " + objFunction.ReturnString(GridView1.DataKeys(e.NewSelectedIndex).Values("seq")))
            Session("AccomStageId") = objFunction.ReturnString(GridView1.DataKeys(e.NewSelectedIndex).Values("id"))
            Session("AccomStageSeq") = objFunction.ReturnString(GridView1.DataKeys(e.NewSelectedIndex).Values("seq"))
            Session("RequestPage") = "BookingView"
            Response.Redirect("bookings_add_stages.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowEditing event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

        Try
            GridView1.EditIndex = e.NewEditIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowCancelingEdit event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)

        Try
            GridView1.EditIndex = -1
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowUpdating event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("id")))
            Dim txtSequence As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_Sequence"), TextBox)

            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            Dim objDLAccomRouteStage As clsDLAccomRouteStage = New clsDLAccomRouteStage

            objBEAccomRouteStage.AccomStageId = id
            objBEAccomRouteStage.Sequence = txtSequence.Text
            Dim intAffectedRow As Integer = objDLAccomRouteStage.UpdateAccomRouteStageSequenceById(objBEAccomRouteStage)

            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Accom stage has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("bookings_view.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            Dim intAccomStageId As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("id")))

            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            objBEAccomRouteStage.AccomStageId = intAccomStageId
            Dim intAffectedRow As Integer = (New clsDLAccomRouteStage().DeleteAccomRouteStage(objBEAccomRouteStage))

            Dim objBEAccomStageDateBooking As clsBEAccomStageDateBooking = New clsBEAccomStageDateBooking
            objBEAccomStageDateBooking.AccomRouteStageId = intAccomStageId
            Dim intAffectedRow1 As Integer = (New clsDLAccomStageDateBooking().DeleteAccomStageDateBookingByAccomRouteStageId(objBEAccomStageDateBooking))

            Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
            objBEAccomStageRoom.AccomStageId = intAccomStageId
            Dim intAffectedRow2 As Integer = (New clsDLAccomStageRoom().DeleteAccomStageRoomByAccomStageId(objBEAccomStageRoom))

            If intAffectedRow > 0 Then
                'Add(Activity - Start)
                'Dim objBEActivity As New clsBEActivity

                'objBEActivity.Descx = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("AccomName")) + " had been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                'objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                'Dim objDLActivity As New clsDLActivity
                'objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Accom stage has been deleted"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Click event of the button
    ''' </summary>
    Protected Sub BUT_Add_Accom_to_Stage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Accom_to_Stage.Click
        Try
            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            Dim objDLAccomRouteStage As clsDLAccomRouteStage = New clsDLAccomRouteStage

            Dim intRouteStageId As Integer = 0
            Dim dstData As DataSet = (New clsDLRouteStage()).GetRouteStageByStageId(objFunction.ReturnInteger(DROP_Stage.SelectedItem.Value))
            If objFunction.CheckDataSet(dstData) Then
                intRouteStageId = objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("id"))
            End If

            objBEAccomRouteStage.StageId = objFunction.ReturnInteger(DROP_Stage.SelectedItem.Value)
            objBEAccomRouteStage.AccomId = 0
            objBEAccomRouteStage.Sequence = objFunction.ReturnInteger(TB_Sequence_in_Route.Text)
            objBEAccomRouteStage.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            objBEAccomRouteStage.RouteStageId = intRouteStageId
            Dim intAccomRouteStageId As Integer = objDLAccomRouteStage.AddAccomRouteStage(objBEAccomRouteStage)

            If intAccomRouteStageId > 0 Then

                Dim objBEAccomStageDateBooking As clsBEAccomStageDateBooking = New clsBEAccomStageDateBooking
                Dim objDLAccomStageDateBooking As clsDLAccomStageDateBooking = New clsDLAccomStageDateBooking

                objBEAccomStageDateBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEAccomStageDateBooking.CheckInDate = DateTime.MinValue
                objBEAccomStageDateBooking.CheckOutDate = DateTime.MinValue
                objBEAccomStageDateBooking.FeeTotal = 0
                objBEAccomStageDateBooking.ExtraActualCost = 0
                objBEAccomStageDateBooking.AccomActualCost = 0
                objBEAccomStageDateBooking.AccomRouteStageId = intAccomRouteStageId

                objDLAccomStageDateBooking.AddAccomStageDateBooking(objBEAccomStageDateBooking)

                'Add(Activity - Start)
                'Dim objBEActivity As New clsBEActivity

                'objBEActivity.Descx = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("AccomName")) + " had been deleted by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                'objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                'Dim objDLActivity As New clsDLActivity
                'objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Accom stage has been added"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' Click event of the button
    ''' </summary>
    Protected Sub BUT__Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Update.Click

        Try
            'Trace.Warn("hdnOldRouteId = " + hdnOldRouteId.Value)

            If IsNumeric(TB_Number_of_Males.Text) And IsNumeric(TB_Number_of_Females.Text) And IsNumeric(TB_Number_of_Unspecified.Text) Then

                Dim objBEBooking As clsBEBooking = New clsBEBooking
                objBEBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEBooking.NoMales = objFunction.ReturnInteger(TB_Number_of_Males.Text)
                objBEBooking.NoFemales = objFunction.ReturnInteger(TB_Number_of_Females.Text)
                objBEBooking.NoOther = objFunction.ReturnInteger(TB_Number_of_Unspecified.Text)
                Dim intTotalNumber As Integer = objBEBooking.NoMales + objBEBooking.NoFemales + objBEBooking.NoOther
                objBEBooking.TotalNumber = intTotalNumber
                objBEBooking.RouteCostClient = objFunction.ReturnDouble(TB_Tour_Cost.Text)
                objBEBooking.RouteCostEasyways = objFunction.ReturnDouble(hdnTempRouteCostEasyway.Value)
                objBEBooking.RouteId = objFunction.ReturnInteger(DROP_Route.SelectedItem.Value)
                objBEBooking.Ensuite = DROP_Ensuite.SelectedItem.Value
                If CHK_Customised2.Checked = True Then
                    objBEBooking.Customised = True
                Else
                    objBEBooking.Customised = False
                End If
                If CHK_Dog_Friendly.Checked = True Then
                    objBEBooking.DogFriendly = True
                Else
                    objBEBooking.DogFriendly = False
                End If

                Dim intAffectedRow As Integer = (New clsDLBooking()).UpdateBookingMemberNo(objBEBooking)
                If intAffectedRow > 0 Then

                    Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                    objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                    objBEClientBooking.AgentId = objFunction.ReturnInteger(DROP_Agent.SelectedItem.Value)
                    objBEClientBooking.PriceBand = DROP_Accom_Band.SelectedItem.Value
                    intAffectedRow = (New clsDLClientBooking()).UpdateAgentIdAndPriceBandByBookingId(objBEClientBooking)

                    If intAffectedRow > 0 Then
                        Dim objBEVoluntaryPayment As clsBEVoluntaryPayment = New clsBEVoluntaryPayment
                        Dim objDLVoluntaryPayment As clsDLVoluntaryPayment = New clsDLVoluntaryPayment
                        objBEVoluntaryPayment.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        Dim dstCheckVoluntaryPayment As DataSet = objDLVoluntaryPayment.GetVoluntaryPaymentByBookingId(objBEVoluntaryPayment)
                        If objFunction.CheckDataSet(dstCheckVoluntaryPayment) Then
                            'objBEVoluntaryPayment.Amount = objFunction.ReturnDouble(intTotalNumber * 5)
                            objBEVoluntaryPayment.Amount = objFunction.ReturnString(dstCheckVoluntaryPayment.Tables(0).Rows(0)("amt"))
                            objBEVoluntaryPayment.Paid = False
                            intAffectedRow = objDLVoluntaryPayment.UpdateVoluntaryPaymentByBookingId(objBEVoluntaryPayment)
                        Else
                            'objBEVoluntaryPayment.Amount = objFunction.ReturnDouble(intTotalNumber * 5)
                            objBEVoluntaryPayment.Amount = 0
                            objBEVoluntaryPayment.Paid = False
                            intAffectedRow = objDLVoluntaryPayment.AddVoluntaryPayment(objBEVoluntaryPayment)
                        End If

                        If objFunction.ReturnInteger(hdnOldRouteId.Value) <> objFunction.ReturnInteger(DROP_Route.SelectedItem.Value) Then
                            Dim intAffectedDeletedRow As Integer = 0
                            Dim intBookingId As Integer = objFunction.ReturnInteger(Session("BookingId"))
                            intAffectedDeletedRow = (New clsDLExtrasBooking().DeleteExtrasBookingByBookingId(intBookingId))
                            intAffectedDeletedRow = (New clsDLExtrasBaggageBooking().DeleteExtrasBaggageBookingByBookingId(intBookingId))
                            intAffectedDeletedRow = (New clsDLAccomStageDateBooking().DeleteAccomStageDateBookingByBookingId(intBookingId))
                            intAffectedDeletedRow = (New clsDLAccomStageRoom().DeleteAccomStageRoomByBookingId(intBookingId))
                            intAffectedDeletedRow = (New clsDLAccomRouteStage().DeleteAccomRouteStageByBookingId(intBookingId))

                            Dim dstRouteStage As DataSet = (New clsDLRouteStage).GetRouteStageByRouteId(objFunction.ReturnInteger(DROP_Route.SelectedItem.Value), objFunction.ReturnInteger(Session("CompanyId")))
                            If objFunction.CheckDataSet(dstRouteStage) Then
                                For i = 0 To dstRouteStage.Tables(0).Rows.Count - 1
                                    Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
                                    Dim objDLAccomRouteStage As clsDLAccomRouteStage = New clsDLAccomRouteStage

                                    objBEAccomRouteStage.StageId = objFunction.ReturnInteger(dstRouteStage.Tables(0).Rows(i)("stage_id"))
                                    objBEAccomRouteStage.AccomId = 0
                                    objBEAccomRouteStage.Sequence = objFunction.ReturnInteger(dstRouteStage.Tables(0).Rows(i)("route_sequence"))
                                    objBEAccomRouteStage.BookingId = intBookingId
                                    objBEAccomRouteStage.RouteStageId = objFunction.ReturnInteger(dstRouteStage.Tables(0).Rows(i)("id"))

                                    Dim intAccomRouteStageId As Integer = objDLAccomRouteStage.AddAccomRouteStage(objBEAccomRouteStage)

                                    If intAccomRouteStageId > 0 Then
                                        Dim objBEAccomStageDateBooking As clsBEAccomStageDateBooking = New clsBEAccomStageDateBooking
                                        Dim objDLAccomStageDateBooking As clsDLAccomStageDateBooking = New clsDLAccomStageDateBooking

                                        objBEAccomStageDateBooking.BookingId = intBookingId
                                        objBEAccomStageDateBooking.CheckInDate = DateTime.MinValue
                                        objBEAccomStageDateBooking.CheckOutDate = DateTime.MinValue
                                        objBEAccomStageDateBooking.FeeTotal = 0
                                        objBEAccomStageDateBooking.ExtraActualCost = 0
                                        objBEAccomStageDateBooking.AccomActualCost = 0
                                        objBEAccomStageDateBooking.AccomRouteStageId = intAccomRouteStageId

                                        objDLAccomStageDateBooking.AddAccomStageDateBooking(objBEAccomStageDateBooking)
                                    End If
                                Next
                            End If
                        End If

                        Session("feedback_call") = "1"
                        Session("error_msg") = "Booking has been updated"
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "Please enter numerical value in number field. No records has been added"
            End If
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetValue(ByVal value As Object) As String
        Try
            If objFunction.ReturnString(value) = "" Then
                Return "No Accomodation Selected"
            Else
                Return value
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return ""
    End Function

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

    Protected Sub BUT_Client_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Client_View.Click
        'Response.Redirect("bookings_edit_client.aspx")
        Session("EditClientId") = objFunction.ReturnString(ViewState("BookingClientId"))
        Dim strUrl = "bookings_edit_client.aspx"
        Response.Write("<script>")
        Response.Write("window.open('" + strUrl + "','_blank')")
        Response.Write("<" + "/script>")
    End Sub

    Protected Sub BUT_View_Breakdown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_View_Breakdown.Click

        Dim strUrl As String = ""
        If CHK_Customised.Checked = True Then
            strUrl = "http://bookings.systems.easyways.co.uk/i/invoice_customised.aspx?bookingid=" + LABEL_Booking_ID.Text
        Else
            strUrl = "http://bookings.systems.easyways.co.uk/i/invoice.aspx?bookingid=" + LABEL_Booking_ID.Text
        End If

        Response.Write("<script>")
        Response.Write("window.open('" + strUrl + "','_blank')")
        Response.Write("<" + "/script>")
    End Sub

    Protected Sub BUT_Payments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Payments.Click
        Response.Redirect("bookings_payments.aspx")
    End Sub

    Protected Sub BUT_View_URL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_View_URL.Click
        'Response.Redirect("http://bookings.systems.easyways.co.uk/u/?bookingid=" + LABEL_Booking_ID.Text + "&donotcount=1")
        Dim strUrl As String = "http://bookings.systems.easyways.co.uk/u/?bookingid=" + LABEL_Booking_ID.Text + "&donotcount=1"
        'Dim strUrl As String = "http://localhost:56833/bookings_systems_easyways/u/?bookingid=" + LABEL_Booking_ID.Text + "&donotcount=1"
        Response.Write("<script>")
        Response.Write("window.open('" + strUrl + "','_blank')")
        Response.Write("<" + "/script>")
    End Sub

    Protected Sub BUT_Add_Note_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Note_Booking.Click
        Response.Redirect("bookings_client_notes.aspx")
    End Sub

    Protected Sub BUT_Additional_Info_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Additional_Info.Click
        Response.Redirect("bookings_additional_info.aspx")
    End Sub

    Protected Sub BUT_Additional_Extras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Additional_Extras.Click
        Response.Redirect("bookings_additional_extras.aspx")
    End Sub

    Protected Sub BUT_Correspondance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Correspondance.Click
        Response.Redirect("correspondance.aspx")
    End Sub

    Protected Sub BUT_View_Evaluation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_View_Evaluation.Click
        Response.Redirect("bookings_eval.aspx")
    End Sub

    Protected Sub BUT_TBC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_TBC.Click
        Response.Redirect("bookings_add_baggage.aspx")
    End Sub

    Protected Sub BUT_Email_Suppliers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Email_Suppliers.Click
        Response.Redirect("correspondance_supplier.aspx#one")
    End Sub

    Protected Sub BUT_Booking_Status_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Booking_Status.Click
        Response.Redirect("bookings_status.aspx")
    End Sub

    Protected Sub BUT_Resequence_Stages_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Resequence_Stages.Click
        Try
            Dim intAffectedRow As Integer = ResequenceBookingStage()
            If intAffectedRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Accom stage has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            GridView1.EditIndex = -1
            Response.Redirect("bookings_view.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to resequence booking stage.
    ''' </summary>
    Public Function ResequenceBookingStage() As Integer
        Try
            Dim intBookingId = objFunction.ReturnInteger(Session("BookingId"))
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstAccomRouteStage As New DataSet()
            Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
            Dim objDLAccomRouteStage As clsDLAccomRouteStage = New clsDLAccomRouteStage
            objBEAccomRouteStage.BookingId = intBookingId
            dstAccomRouteStage = objDLAccomRouteStage.GetAccomRouteStageByBookingId(objBEAccomRouteStage, intCompanyId)

            Dim intAffectedRow As Integer = 0
            If objFunction.CheckDataSet(dstAccomRouteStage) Then
                For i = 0 To dstAccomRouteStage.Tables(0).Rows.Count - 1
                    objBEAccomRouteStage.AccomStageId = objFunction.ReturnInteger(dstAccomRouteStage.Tables(0).Rows(i)("id"))
                    objBEAccomRouteStage.Sequence = (i + 1)
                    intAffectedRow = objDLAccomRouteStage.UpdateAccomRouteStageSequenceById(objBEAccomRouteStage)
                Next
            End If
            Return intAffectedRow
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return 0
    End Function

    Protected Sub BUT_Cancel_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Cancel_Booking.Click
        Try
            Dim dblTotalAmountPayable As Double = (New clsPaymentCalculation()).GetTotalAmountPayable(objFunction.ReturnInteger(Session("BookingId")))
            Dim dstClientBookingDetail As DataSet = (New clsDLClientBooking()).GetClientBookingByBookingId(objFunction.ReturnInteger(Session("BookingId")))

            If objFunction.CheckDataSet(dstClientBookingDetail) Then
                Dim dblCancellationCharge As Double = 0

                If objFunction.ReturnString(dstClientBookingDetail.Tables(0).Rows(0)("checkin_earliest")) <> "" Then

                    'Trace.Warn("checkin_earliest = " + objFunction.ReturnString(Convert.ToDateTime(dstClientBookingDetail.Tables(0).Rows(0)("checkin_earliest"))))
                    'Trace.Warn("DateTime.Now = " + objFunction.ReturnString(Convert.ToDateTime(DateTime.Now)))
                    'Trace.Warn("After 43 day date = " + objFunction.ReturnString(Convert.ToDateTime(DateTime.Now.AddDays(43))))

                    Dim lngDayDiff As Long = 0
                    lngDayDiff = DateDiff(DateInterval.Day, Convert.ToDateTime(DateTime.Now), Convert.ToDateTime(dstClientBookingDetail.Tables(0).Rows(0)("checkin_earliest")))
                    Trace.Warn("lngDayDiff = " + objFunction.ReturnString(lngDayDiff))

                    If lngDayDiff >= 43 Then
                        dblCancellationCharge = (dblTotalAmountPayable * 20) / 100
                        Trace.Warn("43 Day dblCancellationCharge = " + objFunction.ReturnString(dblCancellationCharge))
                    End If

                    If lngDayDiff >= 29 And lngDayDiff <= 42 Then
                        dblCancellationCharge = (dblTotalAmountPayable * 40) / 100
                        Trace.Warn("29 to 42 Day dblCancellationCharge = " + objFunction.ReturnString(dblCancellationCharge))
                    End If

                    If lngDayDiff >= 15 And lngDayDiff <= 28 Then
                        dblCancellationCharge = (dblTotalAmountPayable * 60) / 100
                        Trace.Warn("15 to 28 Day dblCancellationCharge = " + objFunction.ReturnString(dblCancellationCharge))
                    End If

                    If lngDayDiff < 15 Then
                        dblCancellationCharge = dblTotalAmountPayable
                        Trace.Warn("15 Day dblCancellationCharge = " + objFunction.ReturnString(dblCancellationCharge))
                    End If
                End If

                Dim objBEBooking As clsBEBooking = New clsBEBooking
                objBEBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEBooking.Cancelled = True
                objBEBooking.CancellationDate = DateTime.Now
                objBEBooking.CancellationAmount = dblCancellationCharge
                Dim intAffectedRow As Integer = (New clsDLBooking()).CancelBookingByBookingId(objBEBooking)
                If intAffectedRow > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Booking has been cancelled"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("bookings_view.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub BUT_Delete_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Delete_Booking.Click
        Try
            Dim objBEBooking As clsBEBooking = New clsBEBooking
            objBEBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            objBEBooking.CompanyId = 4
            Dim intAffectedRow As Integer = (New clsDLBooking()).UpdateCompanyIdForDeleteBooking(objBEBooking)
            If intAffectedRow > 0 Then
                'Session("feedback_call") = "1"
                'Session("error_msg") = "Booking has been deleted"
                Session("BookingId") = Nothing
                Response.Redirect("dashboard.aspx", False)
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                Response.Redirect("bookings_view.aspx", False)
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub BUT_Back_to_Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Back_to_Search.Click
        Try
            Session("BackToSearch") = "Press"
            Response.Redirect("bookings_search.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

End Class