Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_status_all
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

                Dim objBEBookingStatusComplete As clsBEBookingStatusComplete = New clsBEBookingStatusComplete
                Dim dstBookingStatusComplete As DataSet = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteFillInDD()
                Dim dtData As DataTable
                Dim dtDataTemp As DataTable
                If objFunction.CheckDataSet(dstBookingStatusComplete) Then
                    dtData = dstBookingStatusComplete.Tables(0)
                    dtData.DefaultView.RowFilter = "cat = 1"
                    dtDataTemp = dtData.DefaultView.ToTable()
                    If objFunction.CheckDataTable(dtDataTemp) Then
                        Dim dsTemp = New DataSet()
                        dsTemp.Tables.Add(dtDataTemp)
                        objFunction.FillDropDownByDataSet(DROP_Clients_Status, dsTemp)
                        'For i = 0 To dtDataTemp.Rows.Count - 1
                        '    Dim lstItem As ListItem = New ListItem(objFunction.ReturnString(dtDataTemp.Rows(i)("Value")), objFunction.ReturnString(dtDataTemp.Rows(i)("ID")))
                        '    DROP_Clients_Status.Items.Insert((i + 1), lstItem)
                        '    DROP_Clients_Status.Items(i + 1).Attributes.Add("data-orderx", objFunction.ReturnString(dtDataTemp.Rows(i)("orderx")))
                        'Next
                    End If

                    dtData = dstBookingStatusComplete.Tables(0)
                    dtData.DefaultView.RowFilter = "cat = 2"
                    dtDataTemp = dtData.DefaultView.ToTable()
                    If objFunction.CheckDataTable(dtDataTemp) Then
                        Dim dsTemp = New DataSet()
                        dsTemp.Tables.Add(dtDataTemp)
                        objFunction.FillDropDownByDataSet(DROP_Baggage_Status, dsTemp)
                        'For i = 0 To dtDataTemp.Rows.Count - 1
                        '    Dim lstItem As ListItem = New ListItem(objFunction.ReturnString(dtDataTemp.Rows(i)("Value")), objFunction.ReturnString(dtDataTemp.Rows(i)("ID")))
                        '    DROP_Baggage_Status.Items.Insert((i + 1), lstItem)
                        '    DROP_Baggage_Status.Items(i + 1).Attributes.Add("data-orderx", objFunction.ReturnString(dtDataTemp.Rows(i)("orderx")))
                        'Next
                    End If

                    dtData = dstBookingStatusComplete.Tables(0)
                    dtData.DefaultView.RowFilter = "cat = 3"
                    dtDataTemp = dtData.DefaultView.ToTable()
                    If objFunction.CheckDataTable(dtDataTemp) Then
                        Dim dsTemp = New DataSet()
                        dsTemp.Tables.Add(dtDataTemp)
                        objFunction.FillDropDownByDataSet(DROP_Extras_Status, dsTemp)
                        'For i = 0 To dtDataTemp.Rows.Count - 1
                        '    Dim lstItem As ListItem = New ListItem(objFunction.ReturnString(dtDataTemp.Rows(i)("Value")), objFunction.ReturnString(dtDataTemp.Rows(i)("ID")))
                        '    DROP_Extras_Status.Items.Insert((i + 1), lstItem)
                        '    DROP_Extras_Status.Items(i + 1).Attributes.Add("data-orderx", objFunction.ReturnString(dtDataTemp.Rows(i)("orderx")))
                        'Next
                    End If

                    dtData = dstBookingStatusComplete.Tables(0)
                    dtData.DefaultView.RowFilter = "cat = 4"
                    dtDataTemp = dtData.DefaultView.ToTable()
                    If objFunction.CheckDataTable(dtDataTemp) Then
                        Dim dsTemp = New DataSet()
                        dsTemp.Tables.Add(dtDataTemp)
                        objFunction.FillDropDownByDataSet(DROP_Changes, dsTemp)
                        'For i = 0 To dtDataTemp.Rows.Count - 1
                        '    Dim lstItem As ListItem = New ListItem(objFunction.ReturnString(dtDataTemp.Rows(i)("Value")), objFunction.ReturnString(dtDataTemp.Rows(i)("ID")))
                        '    DROP_Changes.Items.Insert((i + 1), lstItem)
                        '    DROP_Changes.Items(i + 1).Attributes.Add("data-orderx", objFunction.ReturnString(dtDataTemp.Rows(i)("orderx")))
                        'Next
                    End If

                End If

                DROP_Clients_Status.Items.Insert(0, New ListItem("Select Client", ""))
                DROP_Baggage_Status.Items.Insert(0, New ListItem("Select Baggage", ""))
                DROP_Extras_Status.Items.Insert(0, New ListItem("Select Extras", ""))
                DROP_Changes.Items.Insert(0, New ListItem("Select Changes", ""))

                DROP_Clients_Status.Items.Insert(1, New ListItem("View All", "0"))
                DROP_Baggage_Status.Items.Insert(1, New ListItem("View All", "0"))
                DROP_Extras_Status.Items.Insert(1, New ListItem("View All", "0"))
                DROP_Changes.Items.Insert(1, New ListItem("View All", "0"))

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
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim strSearchByFromDate As String = ""
            If TB_Date_From.Text <> "" Then
                Dim dt As DateTime = (If(TB_Date_From.Text <> "", Convert.ToDateTime(TB_Date_From.Text), DateTime.MinValue))
                strSearchByFromDate = dt.ToString("MM-dd-yyyy")
            End If

            Dim strSearchByToDate As String = ""
            If TB_Date_To.Text <> "" Then
                Dim dt As DateTime = (If(TB_Date_To.Text <> "", Convert.ToDateTime(TB_Date_To.Text), DateTime.MinValue))
                strSearchByToDate = dt.ToString("MM-dd-yyyy")
            End If

            Dim strSearchByRoute As String = objFunction.ReturnString(DROP_Route.SelectedItem.Value)
            Dim strSearchByBSCId As String = "0"
            Dim strSearchBySelectedBSCId As String = "0"
            'Dim strSearchByPrevBSCId As String = "0"
            Dim intBSCId As Integer = 0
            Dim strSearchByCat As String = "0"

            'If objFunction.ReturnInteger(DROP_Clients_Status.SelectedItem.Value) >= 0 Then
            If DROP_Clients_Status.SelectedItem.Value <> "" Then
                Dim strName As String = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Text).ToLower()
                If strName = ("For JB").ToLower() Or strName = ("For MAJ").ToLower() Or strName = ("Cancelled").ToLower() Or strName = ("Complete").ToLower() Then
                    strSearchBySelectedBSCId = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Value)
                End If
                intBSCId = objFunction.ReturnInteger(DROP_Clients_Status.SelectedItem.Value)
                strSearchByCat = 1
                'If objFunction.ReturnInteger(DROP_Clients_Status.SelectedIndex) = 1 Then
                '    strSearchByBSCId = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Value)
                'End If
                strSearchByBSCId = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Value)
                'strSearchByPrevBSCId = objFunction.ReturnString(DROP_Clients_Status.Items(DROP_Clients_Status.SelectedIndex - 1).Value)
            ElseIf DROP_Baggage_Status.SelectedItem.Value <> "" Then
                intBSCId = objFunction.ReturnInteger(DROP_Baggage_Status.SelectedItem.Value)
                strSearchByBSCId = objFunction.ReturnString(DROP_Baggage_Status.SelectedItem.Value)
                strSearchByCat = 2
            ElseIf DROP_Extras_Status.SelectedItem.Value <> "" Then
                intBSCId = objFunction.ReturnInteger(DROP_Extras_Status.SelectedItem.Value)
                strSearchByBSCId = objFunction.ReturnString(DROP_Extras_Status.SelectedItem.Value)
                strSearchByCat = 3
            ElseIf DROP_Changes.SelectedItem.Value <> "" Then
                intBSCId = objFunction.ReturnInteger(DROP_Changes.SelectedItem.Value)
                strSearchByBSCId = objFunction.ReturnString(DROP_Changes.SelectedItem.Value)
                strSearchByCat = 4
            End If

            Dim dstReportStatusAll As DataSet = (New clsDLBookingReport()).GetReportStatusAll(intCompanyId, strSearchByFromDate, strSearchByToDate, strSearchByRoute, strSearchByBSCId, strSearchBySelectedBSCId, strSearchByCat)
            'Trace.Warn("dstReportStatusAll = " + objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows.Count))

            'Dim strBookingStatusName As String = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Text).ToLower()
            'If strBookingStatusName = ("For JB").ToLower() Or strBookingStatusName = ("For MAJ").ToLower() Or strBookingStatusName = ("Cancelled").ToLower() Or strBookingStatusName = ("Complete").ToLower() Then
            '    GRID_Reports_Status.DataSource = strBookingStatusName
            '    GRID_Reports_Status.DataBind()
            'Else

            'End If

            Dim dtReportData As DataTable = New DataTable
            Dim colBookingId As DataColumn = New DataColumn("id", Type.GetType("System.String"))
            Dim colClientName As DataColumn = New DataColumn("ClientName", Type.GetType("System.String"))
            Dim colBookingUniqueId As DataColumn = New DataColumn("unique_id", Type.GetType("System.String"))
            Dim colRouteName As DataColumn = New DataColumn("RouteName", Type.GetType("System.String"))
            Dim colStartDate As DataColumn = New DataColumn("checkin_earliest", Type.GetType("System.String"))
            Dim colBscId As DataColumn = New DataColumn("bsc_id", Type.GetType("System.String"))
            Dim colCancelled As DataColumn = New DataColumn("cancelled", Type.GetType("System.String"))
            Dim colAgentId As DataColumn = New DataColumn("agent_id", Type.GetType("System.String"))
            Dim colBookingStatus As DataColumn = New DataColumn("BookingStatus", Type.GetType("System.String"))
            dtReportData.Columns.Add(colBookingId)
            dtReportData.Columns.Add(colClientName)
            dtReportData.Columns.Add(colBookingUniqueId)
            dtReportData.Columns.Add(colRouteName)
            dtReportData.Columns.Add(colStartDate)
            dtReportData.Columns.Add(colBscId)
            dtReportData.Columns.Add(colCancelled)
            dtReportData.Columns.Add(colAgentId)
            dtReportData.Columns.Add(colBookingStatus)

            'Trace.Warn("dstReportStatusAll.Tables(0).Rows.Count = " + objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows.Count))
            If objFunction.CheckDataSet(dstReportStatusAll) Then
                For index = 0 To dstReportStatusAll.Tables(0).Rows.Count - 1
                    Dim dstBookingStatusComplete As DataSet
                    Dim objBEBookingStatusComplete As clsBEBookingStatusComplete = New clsBEBookingStatusComplete
                    'Trace.Warn("Agent ID = " + objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("agent_id")))
                    If objFunction.ReturnInteger(dstReportStatusAll.Tables(0).Rows(index)("agent_id")) = 0 Then
                        objBEBookingStatusComplete.Easyways = True
                        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByEasyways(objBEBookingStatusComplete)
                    Else
                        objBEBookingStatusComplete.Agent = True
                        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByAgent(objBEBookingStatusComplete)
                    End If

                    If objFunction.CheckDataSet(dstBookingStatusComplete) Then
                        Dim bnlStatus As Boolean = False
                        Dim strBookingStatus As String = ""

                        Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                        objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstReportStatusAll.Tables(0).Rows(index)("id"))
                        Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingId(objBEBookingStatusBookings)

                        If DROP_Clients_Status.SelectedItem.Value = "0" Or DROP_Baggage_Status.SelectedItem.Value = "0" Or DROP_Extras_Status.SelectedItem.Value = "0" Or DROP_Changes.SelectedItem.Value = "0" Then
                            'View All filter

                            Dim dtData As DataTable = dstBookingStatusBookings.Tables(0)
                            dtData.DefaultView.RowFilter = "cat = " + strSearchByCat
                            dtData.DefaultView.Sort = "orderx DESC"
                            Dim dtDataTemp As DataTable = dtData.DefaultView.ToTable()
                            Dim strNextBookingStatus As String = ""
                            If objFunction.CheckDataTable(dtDataTemp) Then
                                Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                                dtStatus.DefaultView.RowFilter = "cat = " + strSearchByCat
                                Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                                If objFunction.CheckDataTable(dtStatusTemp) Then
                                    'Dim strNextBookingStatus As String = ""

                                    Dim lstStatus As List(Of String) = New List(Of String)
                                    For k = 0 To dtDataTemp.Rows.Count - 1
                                        Dim strName As String = objFunction.ReturnString(dtDataTemp.Rows(k)("name")).ToLower()
                                        If strName = ("For JB").ToLower() Or strName = ("For MAJ").ToLower() Or strName = ("Cancelled").ToLower() Or strName = ("Complete").ToLower() Or strName = ("Baggage Not Required").ToLower() Or strName = ("Pay Baggage").ToLower() Or strName = ("Taxi Not Required").ToLower() Or strName = ("Pay Taxis").ToLower() Then
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
                                        'ElseIf lstStatus.Contains("Pay Baggage") = True Then
                                        '   strNextBookingStatus = "Pay Baggage"
                                    ElseIf lstStatus.Contains("Baggage Not Required") = True Then
                                        strNextBookingStatus = "Baggage Not Required"
                                        'ElseIf lstStatus.Contains("Pay Taxis") = True Then
                                        '   strNextBookingStatus = "Pay Taxis"
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
                                End If
                            Else
                                Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                                dtStatus.DefaultView.RowFilter = "cat = " + strSearchByCat
                                Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                                If objFunction.CheckDataTable(dtStatusTemp) Then
                                    strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(0)("name"))
                                End If
                            End If

                            Dim dr As DataRow = dtReportData.NewRow()
                            dr("id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("id"))
                            dr("ClientName") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("ClientName"))
                            dr("unique_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("unique_id"))
                            dr("RouteName") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("RouteName"))
                            dr("checkin_earliest") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("checkin_earliest"))
                            dr("bsc_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("bsc_id"))
                            dr("cancelled") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("cancelled"))
                            dr("agent_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("agent_id"))
                            dr("BookingStatus") = strNextBookingStatus
                            dtReportData.Rows.Add(dr)
                        Else
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = " + strSearchByCat
                            dtStatus.DefaultView.Sort = "orderx ASC"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()

                            Dim dtData As DataTable = dstBookingStatusBookings.Tables(0)
                            dtData.DefaultView.RowFilter = "cat = " + strSearchByCat
                            dtData.DefaultView.Sort = "orderx ASC"
                            'Dim dtDataTemp As DataTable = dtData.DefaultView.ToTable()
                            Dim dtDataTemp As DataTable = dtData.DefaultView.ToTable(True, "booking_id", "bsc_id", "name", "cat", "orderx")

                            If objFunction.CheckDataTable(dtStatusTemp) And objFunction.CheckDataTable(dtDataTemp) Then

                                Dim strNextBookingStatus As String = ""

                                If dtStatusTemp.Rows.Count = dtDataTemp.Rows.Count Then
                                    If strSearchByCat = "1" Then
                                        strNextBookingStatus = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Text)
                                    ElseIf strSearchByCat = "2" Then
                                        strNextBookingStatus = objFunction.ReturnString(DROP_Baggage_Status.SelectedItem.Text)
                                    ElseIf strSearchByCat = "3" Then
                                        strNextBookingStatus = objFunction.ReturnString(DROP_Extras_Status.SelectedItem.Text)
                                    ElseIf strSearchByCat = "4" Then
                                        strNextBookingStatus = objFunction.ReturnString(DROP_Changes.SelectedItem.Text)
                                    End If

                                    bnlStatus = True
                                Else
                                    Dim lstStatus As List(Of String) = New List(Of String)
                                    For k = 0 To dtDataTemp.Rows.Count - 1
                                        Dim strName As String = objFunction.ReturnString(dtDataTemp.Rows(k)("name")).ToLower()
                                        If strName = ("For JB").ToLower() Or strName = ("For MAJ").ToLower() Or strName = ("Cancelled").ToLower() Or strName = ("Complete").ToLower() Or strName = ("Baggage Not Required").ToLower() Or strName = ("Taxi Not Required").ToLower() Then
                                            lstStatus.Add(objFunction.ReturnString(dtDataTemp.Rows(k)("name")))
                                        End If
                                    Next

                                    If lstStatus.Contains("For JB") = True Then
                                        strNextBookingStatus = "For JB"
                                        bnlStatus = True
                                    ElseIf lstStatus.Contains("For MAJ") = True Then
                                        strNextBookingStatus = "For MAJ"
                                        bnlStatus = True
                                    ElseIf lstStatus.Contains("Cancelled") = True Then
                                        strNextBookingStatus = "Cancelled"
                                        bnlStatus = True
                                    ElseIf lstStatus.Contains("Complete") = True Then
                                        strNextBookingStatus = "Complete"
                                        bnlStatus = True
                                    ElseIf lstStatus.Contains("Baggage Not Required") = True Then
                                        strNextBookingStatus = "Baggage Not Required"
                                        bnlStatus = True
                                    ElseIf lstStatus.Contains("Taxi Not Required") = True Then
                                        strNextBookingStatus = "Taxi Not Required"
                                        bnlStatus = True
                                    Else

                                        Dim dtOrderx As DataTable = dstBookingStatusComplete.Tables(0)
                                        dtOrderx.DefaultView.RowFilter = "id = " + objFunction.ReturnString(intBSCId)
                                        Dim dtOrderxTemp As DataTable = dtOrderx.DefaultView.ToTable()
                                        Dim intOrderx As Integer = 0
                                        If objFunction.CheckDataTable(dtOrderxTemp) Then
                                            intOrderx = objFunction.ReturnInteger(dtOrderxTemp.Rows(0)("orderx"))
                                        End If

                                        If intOrderx > 0 Then

                                            Dim dtBsb As DataTable = dstBookingStatusBookings.Tables(0)
                                            dtBsb.DefaultView.RowFilter = "bsc_id = " + objFunction.ReturnString(intBSCId)
                                            Dim dtBsbTemp As DataTable = dtBsb.DefaultView.ToTable()
                                            If Not objFunction.CheckDataTable(dtBsbTemp) Then
                                                dtStatusTemp.DefaultView.RowFilter = "orderx < " + objFunction.ReturnString(intOrderx)
                                                Dim dt1 As DataTable = dtStatusTemp.DefaultView.ToTable()

                                                dtDataTemp.DefaultView.RowFilter = "orderx < " + objFunction.ReturnString(intOrderx)
                                                Dim dt2 As DataTable = dtDataTemp.DefaultView.ToTable()

                                                If dt1.Rows.Count > 0 And dt2.Rows.Count > 0 Then
                                                    If dt1.Rows.Count = dt2.Rows.Count Then

                                                        If strSearchByCat = "1" Then
                                                            strNextBookingStatus = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Text)
                                                        ElseIf strSearchByCat = "2" Then
                                                            strNextBookingStatus = objFunction.ReturnString(DROP_Baggage_Status.SelectedItem.Text)
                                                        ElseIf strSearchByCat = "3" Then
                                                            strNextBookingStatus = objFunction.ReturnString(DROP_Extras_Status.SelectedItem.Text)
                                                        ElseIf strSearchByCat = "4" Then
                                                            strNextBookingStatus = objFunction.ReturnString(DROP_Changes.SelectedItem.Text)
                                                        End If

                                                        bnlStatus = True

                                                    End If
                                                End If
                                            End If
                                        End If

                                    End If
                                End If

                                If bnlStatus = True Then
                                    Dim dr As DataRow = dtReportData.NewRow()
                                    dr("id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("id"))
                                    dr("ClientName") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("ClientName"))
                                    dr("unique_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("unique_id"))
                                    dr("RouteName") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("RouteName"))
                                    dr("checkin_earliest") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("checkin_earliest"))
                                    dr("bsc_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("bsc_id"))
                                    dr("cancelled") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("cancelled"))
                                    dr("agent_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("agent_id"))
                                    dr("BookingStatus") = strNextBookingStatus
                                    dtReportData.Rows.Add(dr)
                                End If

                            End If
                        End If
                    End If

                    'Trace.Warn("dstBookingStatusComplete count = " + objFunction.ReturnString(dstBookingStatusComplete.Tables(0).Rows.Count))

                    'New Logic
                    'If objFunction.CheckDataSet(dstBookingStatusComplete) Then

                    'Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                    'objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstReportStatusAll.Tables(0).Rows(index)("id"))
                    'Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingId(objBEBookingStatusBookings)

                    'Dim bnlStatus As Boolean = False
                    'Dim dtData As DataTable
                    'Dim dtDataTemp As DataTable
                    'Dim strNextBookingStatus As String = ""

                    ''Booking Status
                    'dtData = dstBookingStatusBookings.Tables(0)
                    'dtData.DefaultView.RowFilter = "cat = 1"
                    'dtData.DefaultView.Sort = "orderx DESC"
                    'dtDataTemp = dtData.DefaultView.ToTable()
                    'If objFunction.CheckDataTable(dtDataTemp) Then
                    '    'LABEL_Booking_Status.Text = objFunction.ReturnString(dtDataTemp.Rows(0)("name"))
                    '    Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                    '    dtStatus.DefaultView.RowFilter = "cat = " + strSearchByCat
                    '    Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                    '    If objFunction.CheckDataTable(dtStatusTemp) Then

                    '        Dim lstStatus As List(Of String) = New List(Of String)
                    '        For k = 0 To dtDataTemp.Rows.Count - 1
                    '            Dim strName As String = objFunction.ReturnString(dtDataTemp.Rows(k)("name")).ToLower()
                    '            If strName = ("For JB").ToLower() Or strName = ("For MAJ").ToLower() Or strName = ("Cancelled").ToLower() Or strName = ("Complete").ToLower() Then
                    '                lstStatus.Add(objFunction.ReturnString(dtDataTemp.Rows(k)("name")))
                    '            End If
                    '        Next

                    '        'New Logic
                    '        If lstStatus.Contains("For JB") = True Then
                    '            strNextBookingStatus = "For JB"
                    '            bnlStatus = True
                    '        ElseIf lstStatus.Contains("For MAJ") = True Then
                    '            strNextBookingStatus = "For MAJ"
                    '            bnlStatus = True
                    '        ElseIf lstStatus.Contains("Cancelled") = True Then
                    '            strNextBookingStatus = "Cancelled"
                    '            bnlStatus = True
                    '        ElseIf lstStatus.Contains("Complete") = True Then
                    '            strNextBookingStatus = "Complete"
                    '            bnlStatus = True
                    '        Else
                    '            For j = 0 To dtStatusTemp.Rows.Count - 1
                    '                dtDataTemp.DefaultView.RowFilter = "bsc_id = " + objFunction.ReturnString(dtStatusTemp.Rows(j)("id"))
                    '                Dim dt As DataTable = dtDataTemp.DefaultView.ToTable()
                    '                If Not objFunction.CheckDataTable(dt) Then
                    '                    strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                    '                    bnlStatus = True
                    '                    Exit For
                    '                End If
                    '            Next
                    '        End If

                    '    End If
                    'End If

                    'If bnlStatus = True Then
                    '    Dim dr As DataRow = dtReportData.NewRow()
                    '    dr("id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("id"))
                    '    dr("unique_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("unique_id"))
                    '    dr("RouteName") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("RouteName"))
                    '    dr("checkin_earliest") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("checkin_earliest"))
                    '    dr("bsc_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("bsc_id"))
                    '    dr("cancelled") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("cancelled"))
                    '    dr("agent_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("agent_id"))
                    '    dr("BookingStatus") = strNextBookingStatus
                    '    dtReportData.Rows.Add(dr)
                    'End If

                    'Dim dtOrderx As DataTable = dstBookingStatusComplete.Tables(0)
                    'dtOrderx.DefaultView.RowFilter = "id = " + objFunction.ReturnString(intBSCId)
                    'Dim dtOrderxTemp As DataTable = dtOrderx.DefaultView.ToTable()
                    'Dim intOrderx As Integer = 0
                    'If objFunction.CheckDataTable(dtOrderxTemp) Then
                    '    intOrderx = objFunction.ReturnInteger(dtOrderxTemp.Rows(0)("orderx"))
                    'End If

                    'Dim bnlStatus As Boolean = False
                    'Dim strBookingStatus As String = ""

                    'Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                    'objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstReportStatusAll.Tables(0).Rows(index)("id"))
                    'Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingId(objBEBookingStatusBookings)

                    'Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                    'dtStatus.DefaultView.RowFilter = "cat = " + strSearchByCat
                    'dtStatus.DefaultView.Sort = "orderx ASC"
                    'Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()

                    'For i = 0 To dtStatusTemp.Rows.Count - 1
                    '    'If dtStatusTemp.Rows(i)("id") <= intBSCId Then
                    '    If dtStatusTemp.Rows(i)("orderx") <= intOrderx Then

                    '        If objFunction.CheckDataSet(dstBookingStatusBookings) Then

                    '            Dim dtData As DataTable = dstBookingStatusBookings.Tables(0)
                    '            dtData.DefaultView.RowFilter = "cat = " + strSearchByCat
                    '            'dtData.DefaultView.Sort = "orderx DESC"
                    '            Dim dtDataTemp As DataTable = dtData.DefaultView.ToTable()

                    '            If objFunction.CheckDataTable(dtDataTemp) Then

                    '                Dim lstStatus As List(Of String) = New List(Of String)
                    '                For k = 0 To dtDataTemp.Rows.Count - 1
                    '                    Dim strName As String = objFunction.ReturnString(dtDataTemp.Rows(k)("name")).ToLower()
                    '                    'If strName = ("For JB").ToLower() Or strName = ("For MAJ").ToLower() Or strName = ("Cancelled").ToLower() Or strName = ("Complete").ToLower() Then
                    '                    If strName = ("Cancelled").ToLower() Or strName = ("Complete").ToLower() Then
                    '                        lstStatus.Add(objFunction.ReturnString(dtDataTemp.Rows(k)("name")))
                    '                    End If
                    '                Next

                    '                'If lstStatus.Contains("For JB") = True Then
                    '                '    strBookingStatus = "For JB"
                    '                '    bnlStatus = True
                    '                '    Exit For
                    '                'ElseIf lstStatus.Contains("For MAJ") = True Then
                    '                '    strBookingStatus = "For MAJ"
                    '                '    bnlStatus = True
                    '                '    Exit For
                    '                'ElseIf lstStatus.Contains("Cancelled") = True Then
                    '                If lstStatus.Contains("Cancelled") = True Then
                    '                    strBookingStatus = "Cancelled"
                    '                    bnlStatus = True
                    '                    Exit For
                    '                ElseIf lstStatus.Contains("Complete") = True Then
                    '                    strBookingStatus = "Complete"
                    '                    bnlStatus = True
                    '                    Exit For
                    '                Else
                    '                    dtDataTemp.DefaultView.RowFilter = "bsc_id = " + objFunction.ReturnString(dtStatusTemp.Rows(i)("id"))
                    '                    Dim dt As DataTable = dtDataTemp.DefaultView.ToTable()
                    '                    If Not objFunction.CheckDataTable(dt) Then
                    '                        If dtStatusTemp.Rows(i)("id") = intBSCId Then
                    '                            strBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(i)("name"))
                    '                            bnlStatus = True
                    '                            Exit For
                    '                        Else
                    '                            'bnlStatus = False
                    '                            'Exit For
                    '                        End If
                    '                    End If
                    '                End If

                    '            End If

                    '        End If
                    '    Else
                    '        Exit For
                    '    End If
                    'Next

                    'If bnlStatus = True Then
                    '    Dim dr As DataRow = dtReportData.NewRow()
                    '    dr("id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("id"))
                    '    dr("unique_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("unique_id"))
                    '    dr("RouteName") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("RouteName"))
                    '    dr("checkin_earliest") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("checkin_earliest"))
                    '    dr("bsc_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("bsc_id"))
                    '    dr("cancelled") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("cancelled"))
                    '    dr("agent_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("agent_id"))
                    '    dr("BookingStatus") = strBookingStatus
                    '    dtReportData.Rows.Add(dr)
                    'End If

                    'End If

                    'Old Logic
                    'If objFunction.CheckDataSet(dstBookingStatusComplete) Then
                    '    Dim dtData As DataTable = dstBookingStatusComplete.Tables(0)
                    '    dtData.DefaultView.RowFilter = "cat = " + strSearchByCat + " AND id = " + objFunction.ReturnString(intBSCId)
                    '    dtData.DefaultView.Sort = "orderx ASC"
                    '    Dim dtDataTemp As DataTable = dtData.DefaultView.ToTable()
                    '    'Dim intPreviousId As Integer = 0
                    '    Dim bnlStatus As Boolean = False

                    '    'Trace.Warn("dtDataTemp count = " + objFunction.ReturnString(dtDataTemp.Rows.Count))

                    '    Dim strBookingStatus As String = ""

                    '    If objFunction.CheckDataTable(dtDataTemp) Then

                    '        bnlStatus = True

                    '        'Dim dt As DataTable
                    '        'Dim dtT As DataTable

                    '        If objFunction.ReturnInteger(strSearchBySelectedBSCId) > 0 Then
                    '            If strSearchByCat = "1" Then
                    '                strBookingStatus = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Text)
                    '            ElseIf strSearchByCat = "2" Then
                    '                strBookingStatus = objFunction.ReturnString(DROP_Baggage_Status.SelectedItem.Text)
                    '            ElseIf strSearchByCat = "3" Then
                    '                strBookingStatus = objFunction.ReturnString(DROP_Extras_Status.SelectedItem.Text)
                    '            ElseIf strSearchByCat = "4" Then
                    '                strBookingStatus = objFunction.ReturnString(DROP_Changes.SelectedItem.Text)
                    '            End If
                    '        Else
                    '            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                    '            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstReportStatusAll.Tables(0).Rows(index)("id"))
                    '            Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingId(objBEBookingStatusBookings)

                    '            If objFunction.CheckDataSet(dstBookingStatusBookings) Then

                    '                Dim lstStatus As List(Of String) = New List(Of String)
                    '                For k = 0 To dstBookingStatusBookings.Tables(0).Rows.Count - 1
                    '                    Dim strName As String = objFunction.ReturnString(dstBookingStatusBookings.Tables(0).Rows(k)("name")).ToLower()
                    '                    'If strName = ("For JB").ToLower() Or strName = ("For MAJ").ToLower() Or strName = ("Cancelled").ToLower() Or strName = ("Complete").ToLower() Then
                    '                    If strName = ("Cancelled").ToLower() Or strName = ("Complete").ToLower() Then
                    '                        lstStatus.Add(objFunction.ReturnString(dstBookingStatusBookings.Tables(0).Rows(k)("name")))
                    '                    End If
                    '                Next

                    '                If lstStatus.Contains("For JB") = True Then
                    '                    strBookingStatus = "For JB"
                    '                ElseIf lstStatus.Contains("For MAJ") = True Then
                    '                    strBookingStatus = "For MAJ"
                    '                ElseIf lstStatus.Contains("Cancelled") = True Then
                    '                    strBookingStatus = "Cancelled"
                    '                ElseIf lstStatus.Contains("Complete") = True Then
                    '                    strBookingStatus = "Complete"
                    '                Else
                    '                    If strSearchByCat = "1" Then
                    '                        strBookingStatus = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Text)
                    '                    ElseIf strSearchByCat = "2" Then
                    '                        strBookingStatus = objFunction.ReturnString(DROP_Baggage_Status.SelectedItem.Text)
                    '                    ElseIf strSearchByCat = "3" Then
                    '                        strBookingStatus = objFunction.ReturnString(DROP_Extras_Status.SelectedItem.Text)
                    '                    ElseIf strSearchByCat = "4" Then
                    '                        strBookingStatus = objFunction.ReturnString(DROP_Changes.SelectedItem.Text)
                    '                    End If
                    '                End If
                    '            Else
                    '                If strSearchByCat = "1" Then
                    '                    strBookingStatus = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Text)
                    '                ElseIf strSearchByCat = "2" Then
                    '                    strBookingStatus = objFunction.ReturnString(DROP_Baggage_Status.SelectedItem.Text)
                    '                ElseIf strSearchByCat = "3" Then
                    '                    strBookingStatus = objFunction.ReturnString(DROP_Extras_Status.SelectedItem.Text)
                    '                ElseIf strSearchByCat = "4" Then
                    '                    strBookingStatus = objFunction.ReturnString(DROP_Changes.SelectedItem.Text)
                    '                End If
                    '            End If
                    '        End If


                    '        'dtDataTemp.DefaultView.RowFilter = "id = " + objFunction.ReturnString(intBSCId)
                    '        'Dim dtDataTempNew As DataTable = dtDataTemp.DefaultView.ToTable()
                    '        'If objFunction.CheckDataTable(dtDataTempNew) Then
                    '        '    bnlStatus = True
                    '        'End If

                    '        'For j = 0 To dtDataTemp.Rows.Count - 1
                    '        '    'Trace.Warn("id" + objFunction.ReturnString(dtDataTemp.Rows(j)("id")))
                    '        '    'Trace.Warn("intBSCId = " + objFunction.ReturnString(intBSCId))
                    '        '    If objFunction.ReturnInteger(dtDataTemp.Rows(j)("id")) = intBSCId Then
                    '        '        'Dim strName As String = objFunction.ReturnString(dtDataTemp.Rows(j)("name")).ToLower()
                    '        '        'If strName = ("For JB").ToLower() Or strName = ("For MAJ").ToLower() Or strName = ("Cancelled").ToLower() Or strName = ("Complete").ToLower() Then
                    '        '        '    intPreviousId = objFunction.ReturnInteger(dtDataTemp.Rows(j)("id"))
                    '        '        'Else
                    '        '        '    If j = (dtDataTemp.Rows.Count - 1) Then
                    '        '        '        intPreviousId = objFunction.ReturnInteger(dtDataTemp.Rows(j)("id"))
                    '        '        '    Else
                    '        '        '        If j = 0 Then
                    '        '        '            intPreviousId = objFunction.ReturnInteger(dtDataTemp.Rows(j)("id"))
                    '        '        '        Else
                    '        '        '            intPreviousId = objFunction.ReturnInteger(dtDataTemp.Rows(j - 1)("id"))
                    '        '        '        End If
                    '        '        '    End If
                    '        '        'End If
                    '        '        If j = (dtDataTemp.Rows.Count - 1) Then
                    '        '            intPreviousId = objFunction.ReturnInteger(dtDataTemp.Rows(j)("id"))
                    '        '        Else
                    '        '            If j = 0 Then
                    '        '                intPreviousId = objFunction.ReturnInteger(dtDataTemp.Rows(j)("id"))
                    '        '            Else
                    '        '                intPreviousId = objFunction.ReturnInteger(dtDataTemp.Rows(j - 1)("id"))
                    '        '            End If
                    '        '        End If
                    '        '        Exit For
                    '        '    End If
                    '        'Next
                    '    End If

                    '    'Trace.Warn("intPreviousId = " + objFunction.ReturnString(intPreviousId))

                    '    'If intPreviousId > 0 Then
                    '    If bnlStatus = True Then
                    '        Dim dr As DataRow = dtReportData.NewRow()
                    '        dr("id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("id"))
                    '        dr("unique_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("unique_id"))
                    '        dr("RouteName") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("RouteName"))
                    '        dr("checkin_earliest") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("checkin_earliest"))
                    '        dr("bsc_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("bsc_id"))
                    '        dr("cancelled") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("cancelled"))
                    '        dr("agent_id") = objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(index)("agent_id"))
                    '        dr("BookingStatus") = strBookingStatus
                    '        dtReportData.Rows.Add(dr)
                    '    End If

                    'End If
                Next
            End If

            'Trace.Warn("dtReportData.Rows.Count = " + objFunction.ReturnString(dtReportData.Rows.Count))

            'GRID_Reports_Status.DataSource = dtReportData
            'GRID_Reports_Status.DataBind()

            GRID_Reports_Status.DataSource = dtReportData
            GRID_Reports_Status.DataBind()

            'For i As Integer = 0 To GRID_Reports_Status.Rows.Count - 1
            '    Dim gRow As GridViewRow = GRID_Reports_Status.Rows(i)
            '    Dim lblNextBookingStatus = DirectCast(gRow.FindControl("LABEL_NextBookingStatus"), Label)

            '    If strSearchByCat = "1" Then
            '        lblNextBookingStatus.Text = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Text)
            '    ElseIf strSearchByCat = "2" Then
            '        lblNextBookingStatus.Text = objFunction.ReturnString(DROP_Baggage_Status.SelectedItem.Text)
            '    ElseIf strSearchByCat = "3" Then
            '        lblNextBookingStatus.Text = objFunction.ReturnString(DROP_Extras_Status.SelectedItem.Text)
            '    ElseIf strSearchByCat = "4" Then
            '        lblNextBookingStatus.Text = objFunction.ReturnString(DROP_Changes.SelectedItem.Text)
            '    End If

            'Trace.Warn("Cancelled = " + objFunction.ReturnString(dtReportData.Rows(i)("cancelled")))
            'Trace.Warn("Cancelled = " + objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(i)("cancelled")))

            'If Convert.ToBoolean(dstReportStatusAll.Tables(0).Rows(i)("cancelled")) = True Then
            '    lblNextBookingStatus.Text = "Cancelled"
            'Else
            '    'lblNextBookingStatus.Text = GetNextBookingStatus(objFunction.ReturnInteger(dstReportStatusAll.Tables(0).Rows(i)("id")), objFunction.ReturnInteger(dstReportStatusAll.Tables(0).Rows(i)("agent_id")))
            '    Trace.Warn("bsc_id = " + objFunction.ReturnString(dstReportStatusAll.Tables(0).Rows(i)("bsc_id")))
            '    Dim objBEBookingStatusComplete As clsBEBookingStatusComplete = New clsBEBookingStatusComplete
            '    objBEBookingStatusComplete.BookingStatusCompleteId = objFunction.ReturnInteger(dstReportStatusAll.Tables(0).Rows(i)("bsc_id"))
            '    Dim dstBookingStatusComplete As DataSet

            '    If objFunction.ReturnInteger(dstReportStatusAll.Tables(0).Rows(i)("agent_id")) = 0 Then
            '        objBEBookingStatusComplete.Easyways = True
            '        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteCatByIdAndEasyways(objBEBookingStatusComplete)
            '    Else
            '        objBEBookingStatusComplete.Agent = True
            '        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteCatByIdAndAgent(objBEBookingStatusComplete)
            '    End If

            '    If objFunction.CheckDataSet(dstBookingStatusComplete) Then
            '        Dim strNextBookingStatus As String = ""
            '        For j = 0 To dstBookingStatusComplete.Tables(0).Rows.Count - 1
            '            If objFunction.ReturnInteger(dstBookingStatusComplete.Tables(0).Rows(j)("id")) = objFunction.ReturnInteger(dstReportStatusAll.Tables(0).Rows(i)("bsc_id")) Then

            '                'If strSearchByCat = "1" Then
            '                '    strNextBookingStatus = objFunction.ReturnString(DROP_Clients_Status.SelectedItem.Text)
            '                'ElseIf strSearchByCat = "2" Then
            '                '    strNextBookingStatus = objFunction.ReturnString(DROP_Baggage_Status.SelectedItem.Text)
            '                'ElseIf strSearchByCat = "3" Then
            '                '    strNextBookingStatus = objFunction.ReturnString(DROP_Extras_Status.SelectedItem.Text)
            '                'ElseIf strSearchByCat = "4" Then
            '                '    strNextBookingStatus = objFunction.ReturnString(DROP_Changes.SelectedItem.Text)
            '                'End If

            '                If j = (dstBookingStatusComplete.Tables(0).Rows.Count - 1) Then
            '                    strNextBookingStatus = objFunction.ReturnString(dstBookingStatusComplete.Tables(0).Rows(j)("name"))
            '                Else
            '                    strNextBookingStatus = objFunction.ReturnString(dstBookingStatusComplete.Tables(0).Rows(j + 1)("name"))
            '                End If
            '                Exit For
            '            End If
            '        Next
            '        lblNextBookingStatus.Text = strNextBookingStatus
            '    End If
            'End If
            'Next

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to get next_booking_status
    ''' </summary>
    Protected Function GetNextBookingStatus(ByVal intBookingId As Integer, ByVal intAgentId As Integer) As String
        Try

            Dim bnlFlag = False
            Dim strNextBookingStatus As String = ""

            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
            objBEBookingStatusBookings.BookingId = intBookingId
            Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingId(objBEBookingStatusBookings)
            If objFunction.CheckDataSet(dstBookingStatusBookings) Then

                Dim dstBookingStatusComplete As DataSet
                Dim objBEBookingStatusComplete As clsBEBookingStatusComplete = New clsBEBookingStatusComplete
                If intAgentId = 0 Then
                    objBEBookingStatusComplete.Easyways = True
                    dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByEasyways(objBEBookingStatusComplete)
                Else
                    objBEBookingStatusComplete.Agent = True
                    dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByAgent(objBEBookingStatusComplete)
                End If

                If objFunction.CheckDataSet(dstBookingStatusComplete) Then

                    Dim dtData As DataTable
                    Dim dtDataTemp As DataTable

                    If bnlFlag = False Then
                        dtData = dstBookingStatusBookings.Tables(0)
                        dtData.DefaultView.RowFilter = "cat = 4"
                        dtData.DefaultView.Sort = "orderx DESC"
                        dtDataTemp = dtData.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtDataTemp) Then
                            'LABEL_Extras_Booking_Status.Text = objFunction.ReturnString(dtDataTemp.Rows(0)("name"))
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 4"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                For j = 0 To dtStatusTemp.Rows.Count - 1
                                    If objFunction.ReturnInteger(dtStatusTemp.Rows(j)("orderx")) = objFunction.ReturnInteger(dtDataTemp.Rows(0)("orderx")) Then
                                        If j = (dtStatusTemp.Rows.Count - 1) Then
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                        Else
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j + 1)("name"))
                                        End If
                                        bnlFlag = True
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    End If

                    If bnlFlag = False Then
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
                                For j = 0 To dtStatusTemp.Rows.Count - 1
                                    If objFunction.ReturnInteger(dtStatusTemp.Rows(j)("orderx")) = objFunction.ReturnInteger(dtDataTemp.Rows(0)("orderx")) Then
                                        If j = (dtStatusTemp.Rows.Count - 1) Then
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                        Else
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j + 1)("name"))
                                        End If
                                        bnlFlag = True
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    End If

                    If bnlFlag = False Then
                        dtData = dstBookingStatusBookings.Tables(0)
                        dtData.DefaultView.RowFilter = "cat = 2"
                        dtData.DefaultView.Sort = "orderx DESC"
                        dtDataTemp = dtData.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtDataTemp) Then
                            'LABEL_Extras_Booking_Status.Text = objFunction.ReturnString(dtDataTemp.Rows(0)("name"))
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 2"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                For j = 0 To dtStatusTemp.Rows.Count - 1
                                    If objFunction.ReturnInteger(dtStatusTemp.Rows(j)("orderx")) = objFunction.ReturnInteger(dtDataTemp.Rows(0)("orderx")) Then
                                        If j = (dtStatusTemp.Rows.Count - 1) Then
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                        Else
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j + 1)("name"))
                                        End If
                                        bnlFlag = True
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    End If

                    If bnlFlag = False Then
                        dtData = dstBookingStatusBookings.Tables(0)
                        dtData.DefaultView.RowFilter = "cat = 1"
                        dtData.DefaultView.Sort = "orderx DESC"
                        dtDataTemp = dtData.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtDataTemp) Then
                            'LABEL_Extras_Booking_Status.Text = objFunction.ReturnString(dtDataTemp.Rows(0)("name"))
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 1"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                For j = 0 To dtStatusTemp.Rows.Count - 1
                                    If objFunction.ReturnInteger(dtStatusTemp.Rows(j)("orderx")) = objFunction.ReturnInteger(dtDataTemp.Rows(0)("orderx")) Then
                                        If j = (dtStatusTemp.Rows.Count - 1) Then
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                        Else
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j + 1)("name"))
                                        End If
                                        bnlFlag = True
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    End If

                End If

            End If

            Return strNextBookingStatus

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function


    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Reports_Status
    ''' </summary>
    Protected Sub GRID_Reports_Status_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Reports_Status.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingId") = objFunction.ReturnString(GRID_Reports_Status.DataKeys(e.NewSelectedIndex).Value)
            'Response.Redirect("bookings_view.aspx")
            Dim strUrl = "bookings_view.aspx"
            Response.Write("<script>")
            Response.Write("window.open('" + strUrl + "','_blank')")
            Response.Write("</script>")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Reports_Status
    ''' </summary>
    Protected Sub GRID_Reports_Status_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Reports_Status.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Clieck event of button to get record
    ''' </summary>
    Protected Sub BUT__Show_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Show_All.Click
        Try
            BindGridview()
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

End Class