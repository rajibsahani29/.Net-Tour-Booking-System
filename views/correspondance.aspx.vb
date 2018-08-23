Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class correspondance
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objEmailContent As New clsEmailContent()
    Dim objBEBookingCorrespondence As clsBEBookingCorrespondence = New clsBEBookingCorrespondence
    Dim objDLBookingCorrespondence As clsDLBookingCorrespondence = New clsDLBookingCorrespondence
    
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

                GetBookingDetails()
                FillCorrespondenceType()

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
            Dim intAccomStageId = objFunction.ReturnInteger(Session("AccomStageId"))
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstBookingDetail As New DataSet()
            Dim objBEBooking As clsBEBooking = New clsBEBooking
            objBEBooking.BookingId = intBookingId
            objBEBooking.CompanyId = intCompanyId
            dstBookingDetail = (New clsDLBooking()).GetBookingDetailById(objBEBooking, 0)

            If dstBookingDetail IsNot Nothing Then

                LABEL_Booking_ID.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("unique_id"))
                LABEL_Tour_and_Stage.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("RouteName"))
                LABEL_Client_Name.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ClientName"))
                LABEL_Stage.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("StageName"))
                LABEL_Total_Number_in_Party.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("total_num"))
                Dim dblTotalAmountPayable As Double = (New clsPaymentCalculation()).GetTotalAmountPayable(intBookingId)
                ViewState.Add("TotalAmountPayable", dblTotalAmountPayable)
                LABEL_Total_Payable.Text = "£" + dblTotalAmountPayable.ToString("0.00")
                Dim dblTotalBalanceRemaining As Double = (New clsPaymentCalculation()).GetTotalBalanceRemaining(dblTotalAmountPayable, intBookingId)
                ViewState.Add("TotalBalanceRemaining", dblTotalBalanceRemaining)
                LABEL_Balance_Remaining.Text = "£" + dblTotalBalanceRemaining.ToString("0.00")
                If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("customised")) = True Then
                    CHK_Customised.Checked = True
                End If

                TB_Email_Subject2.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ClientName")) + " - " + objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("RouteName")) + " - " + SetDateVal(objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("checkin_earliest")))

                Trace.Warn("Agent id = " + objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("agent_id")))
                If objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("agent_id")) <> 0 Then '<>
                    'DIV_send_correspondance_clients.Visible = False
                    DIV_send_correspondance_clients.Attributes.Add("style", "display:none;")
                End If

                If objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("agent_id")) = 0 Then '=
                    'DIV_send_correspondance_agents.Visible = False
                    DIV_send_correspondance_agents.Attributes.Add("style", "display:none;")
                End If

                ViewState.Add("ClientName1", objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ClientName1")))
                ViewState.Add("ClientName2", objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ClientName2")))
                ViewState.Add("ClientEmail", objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ClientEmail")))

                TB_Email_Address2.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("ClientEmail"))

                Dim strAgentName As String = ""
                Dim strAgentEmail As String = ""
                Dim dstAgentData As DataSet = (New clsDLAgent()).GetContactDetailByAgentId(objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("agent_id")), 1)
                If objFunction.CheckDataSet(dstAgentData) Then
                    strAgentName = objFunction.ReturnString(dstAgentData.Tables(0).Rows(0)("contactname"))
                    strAgentEmail = objFunction.ReturnString(dstAgentData.Tables(0).Rows(0)("emailx"))
                End If

                'ViewState.Add("AgentName", objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("AgentName")))
                'ViewState.Add("AgentEmail", objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(0)("AgentEmail")))
                ViewState.Add("AgentName", strAgentName)
                ViewState.Add("AgentEmail", strAgentEmail)
                TB_Email_Address4.Text = strAgentEmail

                Trace.Warn("Agent name = " + ViewState("AgentName").ToString())
                Trace.Warn("Agent email = " + ViewState("AgentEmail").ToString())

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to fill correspondence type dropdown
    ''' </summary>
    Protected Sub FillCorrespondenceType()
        Try
            Dim dstCorrespondenceType As DataSet = (New clsDLCorrespondenceType()).GetCorrespondenceTypeFillInDD()
            objFunction.FillDropDownByDataSet(DROP_Contact_Method, dstCorrespondenceType)
            DROP_Contact_Method.Items.Insert(0, New ListItem("Select Correspondence Type", "0"))
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to go back to booking view screen
    ''' </summary>
    Protected Sub BUT_Back_to_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Back_to_Booking.Click
        Response.Redirect("bookings_view.aspx")
    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the correspondance type dropdown
    ''' </summary>
    Protected Sub DROP_Correspondance_Type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Correspondance_Type.SelectedIndexChanged

        Try
            BindGridview()
            hdnAccordianStatus.Value = "one"
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
            If objFunction.ReturnString(DROP_Correspondance_Type.SelectedItem.Value) <> "" Then
                If DROP_Correspondance_Type.SelectedItem.Value = "Received" Then
                    objBEBookingCorrespondence.CorrespondenceTypeName = "Received"
                    objBEBookingCorrespondence.Direction = Convert.ToBoolean(0)
                ElseIf DROP_Correspondance_Type.SelectedItem.Value = "Sent" Then
                    objBEBookingCorrespondence.CorrespondenceTypeName = "Sent"
                    objBEBookingCorrespondence.Direction = Convert.ToBoolean(1)
                ElseIf DROP_Correspondance_Type.SelectedItem.Value = "All" Then
                    objBEBookingCorrespondence.CorrespondenceTypeName = "All"
                End If
                objBEBookingCorrespondence.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEBookingCorrespondence.Typex = 0
                Dim dstBookingCorrespondence As New DataSet()
                dstBookingCorrespondence = (New clsDLBookingCorrespondence()).GetBookingCorrespondenceByBookingIdAndDirectionAndTypex(objBEBookingCorrespondence)
                GRID_Correspondance.DataSource = dstBookingCorrespondence
                GRID_Correspondance.DataBind()
            Else
                Dim dt As New DataTable()
                GRID_Correspondance.DataSource = dt
                GRID_Correspondance.DataBind()
            End If
            
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Correspondance
    ''' </summary>
    Protected Sub GRID_Correspondance_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Correspondance.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add received correspondence details
    ''' </summary>
    Protected Sub BUT_Add_Communication_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Communication.Click
        Try
            If TB_Email_Subject.Text <> "" And TB_Email_Date_Received.Text <> "" And objFunction.ReturnInteger(DROP_Contact_Method.SelectedItem.Value) > 0 Then
                objBEBookingCorrespondence.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEBookingCorrespondence.Direction = Convert.ToBoolean(0)
                objBEBookingCorrespondence.Subject = TB_Email_Subject.Text
                objBEBookingCorrespondence.Notes = TB_Editor.Text
                objBEBookingCorrespondence.Datex = (If(TB_Email_Date_Received.Text <> "", Convert.ToDateTime(TB_Email_Date_Received.Text), DateTime.MinValue))
                objBEBookingCorrespondence.CorrespondenceTypeId = objFunction.ReturnInteger(DROP_Contact_Method.SelectedItem.Value)
                objBEBookingCorrespondence.Typex = 0
                objBEBookingCorrespondence.EmailType = ""

                Dim intAffectedRow As Integer = objDLBookingCorrespondence.AddBookingCorrespondence(objBEBookingCorrespondence)
                If intAffectedRow > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "Correspondence has been received"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the entries"
            End If
            Response.Redirect("correspondance.aspx#one", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the correspondance dropdown of client
    ''' </summary>
    Protected Sub DROP_Correspondance_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Correspondance.SelectedIndexChanged
        Try
            Dim strEmailContent As String = ""
            If DROP_Correspondance.SelectedItem.Value <> "" Then

                If DROP_Correspondance.SelectedItem.Value = "1.html" Then
                    Dim dstData As DataSet = (New clsEmailContentData()).CustomizedReply(objFunction.ReturnInteger(Session("BookingId")))
                    If objFunction.CheckDataSet(dstData) Then
                        'Dim dblTotalAmountPayable As Double = (New clsPaymentCalculation()).GetTotalAmountPayable(objFunction.ReturnInteger(Session("BookingId")))
                        Dim objBEBooking As clsBEBooking = New clsBEBooking
                        objBEBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEBooking.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                        Dim dstBookingDetail As DataSet = (New clsDLBooking()).GetBookingById(objBEBooking)
                        Dim intTotalNoOfPeople As Integer = 0
                        If objFunction.CheckDataSet(dstBookingDetail) Then
                            intTotalNoOfPeople = objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("total_num"))
                        End If

                        'Dim dblCostPerPerson As Double = 0
                        'If intTotalNoOfPeople > 0 Then
                        '    dblCostPerPerson = (dblTotalAmountPayable / intTotalNoOfPeople)
                        'End If
                        'Trace.Warn("dblCostPerPerson = " + objFunction.ReturnString(dblCostPerPerson))

                        Dim lngOvernights As Long = 0
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin_earliest")) <> "" And objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkout_latest")) <> "" Then
                            lngOvernights = DateDiff(DateInterval.Day, Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin_earliest")), Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkout_latest")))
                        End If

                        'Dim dblCostPerBag As Double = 0
                        Dim strBagWeight As String = ""
                        Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
                        objBEExtrasBaggageBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        Dim dstExtrasBaggageBooking As DataSet = (New clsDLExtrasBaggageBooking()).GetExtrasBaggageBookingByBookingId(objBEExtrasBaggageBooking)
                        If objFunction.CheckDataSet(dstExtrasBaggageBooking) Then
                            'dblCostPerBag = objFunction.ReturnDouble(dstExtrasBaggageBooking.Tables(0).Rows(0)("Price"))
                            strBagWeight = objFunction.ReturnString(dstExtrasBaggageBooking.Tables(0).Rows(0)("Bags"))
                        End If

                        strEmailContent = objEmailContent.CustomizedReply(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(lngOvernights), objFunction.ReturnString(dstData.Tables(0).Rows(0)("total_num")), strBagWeight, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("fee_total")) * objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("total_num")), dstData.Tables(0).Rows(0)("docLoc"))
                    Else
                        strEmailContent = objEmailContent.CustomizedReply("", "", "", "", "", "", "", "", 0, "")
                    End If
                ElseIf DROP_Correspondance.SelectedItem.Value = "2.html" Then
                    Dim dstData As DataSet = (New clsEmailContentData()).FixedPriceReply(objFunction.ReturnInteger(Session("BookingId")))
                    If objFunction.CheckDataSet(dstData) Then
                        Dim dblTotalAmountPayable As Double = (New clsPaymentCalculation()).GetTotalAmountPayable(objFunction.ReturnInteger(Session("BookingId")))
                        Dim objBEBooking As clsBEBooking = New clsBEBooking
                        objBEBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEBooking.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                        Dim dstBookingDetail As DataSet = (New clsDLBooking()).GetBookingById(objBEBooking)
                        Dim intTotalNoOfPeople As Integer = 0
                        If objFunction.CheckDataSet(dstBookingDetail) Then
                            intTotalNoOfPeople = objFunction.ReturnInteger(dstBookingDetail.Tables(0).Rows(0)("total_num"))
                        End If

                        Dim dblCostPerPerson As Double = 0
                        If intTotalNoOfPeople > 0 Then
                            dblCostPerPerson = (dblTotalAmountPayable / intTotalNoOfPeople)
                        End If
                        Trace.Warn("dblCostPerPerson = " + objFunction.ReturnString(dblCostPerPerson))

                        Dim lngOvernights As Long = 0
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin_earliest")) <> "" And objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkout_latest")) <> "" Then
                            lngOvernights = DateDiff(DateInterval.Day, Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin_earliest")), Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkout_latest")))
                        End If

                        'Dim strStageName As String = ""
                        'Dim dstAccomStageDetail As DataSet = (New clsDLAccomRouteStage()).GetStageNameFromAccomRouteStageByBookingId(objFunction.ReturnInteger(Session("BookingId")), objFunction.ReturnInteger(Session("CompanyId")))
                        'If objFunction.CheckDataSet(dstAccomStageDetail) Then
                        '    For i = 0 To dstAccomStageDetail.Tables(0).Rows.Count - 1
                        '        strStageName += objFunction.ReturnString(dstAccomStageDetail.Tables(0).Rows(i)("StageName")) + ", "
                        '    Next
                        'End If

                        'Dim dblCostPerBag As Double = 0
                        Dim strBagWeight As String = ""
                        Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
                        objBEExtrasBaggageBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        Dim dstExtrasBaggageBooking As DataSet = (New clsDLExtrasBaggageBooking()).GetExtrasBaggageBookingByBookingId(objBEExtrasBaggageBooking)
                        If objFunction.CheckDataSet(dstExtrasBaggageBooking) Then
                            'dblCostPerBag = objFunction.ReturnDouble(dstExtrasBaggageBooking.Tables(0).Rows(0)("Price"))
                            strBagWeight = objFunction.ReturnString(dstExtrasBaggageBooking.Tables(0).Rows(0)("Bags"))
                        End If

                        strEmailContent = objEmailContent.FixedPriceReply(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnDouble(dblCostPerPerson.ToString("0.00")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("total_num")), strBagWeight, objFunction.ReturnInteger(lngOvernights) + 1, objFunction.ReturnString(lngOvernights), dstData.Tables(0).Rows(0)("docLoc"))
                    Else
                        strEmailContent = objEmailContent.FixedPriceReply("", "", "", "", "", "", 0, "", "", 0, "", "")
                    End If
                ElseIf DROP_Correspondance.SelectedItem.Value = "3.html" Then
                    Dim dstData As DataSet = (New clsEmailContentData()).CustomizedWalkConfirmaionEmail(objFunction.ReturnInteger(Session("BookingId")))
                    If objFunction.CheckDataSet(dstData) Then
                        Dim lngOvernights As Long = 0
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin_earliest")) <> "" And objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkout_latest")) <> "" Then
                            lngOvernights = DateDiff(DateInterval.Day, Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin_earliest")), Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkout_latest")))
                        End If

                        Dim strCheckinEarliest As String = ""
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin_earliest")) <> "" Then
                            strCheckinEarliest = WeekdayName(Weekday(Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin_earliest")).Date), False, 1)
                        End If

                        'Dim strCheckoutLatest As String = ""
                        'If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkout_latest")) <> "" Then
                        '    strCheckoutLatest = WeekdayName(Weekday(Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkout_latest")).Date), False, 1)
                        'End If

                        Dim strCheckIn As String = ""
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin")) <> "" Then
                            strCheckIn = WeekdayName(Weekday(Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin")).Date), False, 1)
                        End If

                        'strEmailContent = objEmailContent.CustomizedWalkConfirmaionEmail(objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName1")), strCheckinEarliest, SetDateVal(dstData.Tables(0).Rows(0)("checkin_earliest")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("stage1")), objFunction.ReturnInteger(lngOvernights), objFunction.ReturnString(dstData.Tables(0).Rows(0)("stagelast")), strCheckoutLatest, SetDateVal(dstData.Tables(0).Rows(0)("checkout_latest")))
                        strEmailContent = objEmailContent.CustomizedWalkConfirmaionEmail(objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName1")), strCheckinEarliest, SetDateVal(dstData.Tables(0).Rows(0)("checkin_earliest")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("stage1")), objFunction.ReturnInteger(lngOvernights), objFunction.ReturnString(dstData.Tables(0).Rows(0)("stagelast")), strCheckIn, SetDateVal(dstData.Tables(0).Rows(0)("checkin")))
                    Else
                        strEmailContent = objEmailContent.CustomizedWalkConfirmaionEmail("", "", "", "", "", "", "", "", "", 0, "", "", "")
                    End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "4.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).CustomizedWalkConfirmaionEmail(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                        Dim lngOvernights As Long = 0
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin_earliest")) <> "" And objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkout_latest")) <> "" Then
                            lngOvernights = DateDiff(DateInterval.Day, Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin_earliest")), Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkout_latest")))
                        End If

                        Dim strCheckinEarliest As String = ""
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin_earliest")) <> "" Then
                            strCheckinEarliest = WeekdayName(Weekday(Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin_earliest")).Date), False, 1)
                        End If
                        Trace.Warn("strCheckinEarliest = " + strCheckinEarliest)

                        'Trace.Warn("checkout_latest = " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkout_latest")))
                        'Dim strCheckoutLatest As String = ""
                        'If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkout_latest")) <> "" Then
                        '    strCheckoutLatest = WeekdayName(Weekday(Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkout_latest")).Date), False, 1)
                        'End If
                        'Trace.Warn("strCheckoutLatest = " + strCheckoutLatest)

                        Dim strCheckIn As String = ""
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin")) <> "" Then
                            strCheckIn = WeekdayName(Weekday(Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin")).Date), False, 1)
                        End If

                        'strEmailContent = objEmailContent.FixedPriceWalkConfirmaionEmail(objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName1")), objFunction.ReturnDouble(ViewState("TotalAmountPayable")).ToString("0.00"), strCheckinEarliest, SetDateVal(dstData.Tables(0).Rows(0)("checkin_earliest")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("stage1")), objFunction.ReturnInteger(lngOvernights), objFunction.ReturnString(dstData.Tables(0).Rows(0)("stagelast")), strCheckoutLatest, SetDateVal(dstData.Tables(0).Rows(0)("checkout_latest")))
                        strEmailContent = objEmailContent.FixedPriceWalkConfirmaionEmail(objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("ClientName1")), objFunction.ReturnDouble(ViewState("TotalAmountPayable")).ToString("0.00"), strCheckinEarliest, SetDateVal(dstData.Tables(0).Rows(0)("checkin_earliest")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("stage1")), objFunction.ReturnInteger(lngOvernights), objFunction.ReturnString(dstData.Tables(0).Rows(0)("stagelast")), strCheckIn, SetDateVal(dstData.Tables(0).Rows(0)("checkin")))
                        Else
                            strEmailContent = objEmailContent.FixedPriceWalkConfirmaionEmail("", "", "", "", "", "", 0, "", "", "", 0, "", "", "")
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "5.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).PreviouslyInvoicedClientsEmail(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                            'Dim strBagWeight As String = ""
                            'Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
                            'objBEExtrasBaggageBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            'Dim dstExtrasBaggageBooking As DataSet = (New clsDLExtrasBaggageBooking()).GetExtrasBaggageBookingByBookingId(objBEExtrasBaggageBooking)
                            'If objFunction.CheckDataSet(dstExtrasBaggageBooking) Then
                            '    strBagWeight = objFunction.ReturnString(dstExtrasBaggageBooking.Tables(0).Rows(0)("Bags"))
                            'End If

                            Dim strInvoiceUrl As String = "http://bookings.systems.easyways.co.uk/i/invoice.aspx?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id"))
                            If Convert.ToBoolean(dstData.Tables(0).Rows(0)("customised")) = True Then
                                strInvoiceUrl = "http://bookings.systems.easyways.co.uk/i/invoice_customised.aspx?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id"))
                            End If

                        strEmailContent = objEmailContent.PreviouslyInvoicedClientsEmail(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), strInvoiceUrl, objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")))
                        Else
                            strEmailContent = objEmailContent.PreviouslyInvoicedClientsEmail("", "", "", "", "", "", "", "", "")
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "6.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).ThanksForPayment_FullPayment(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                            strEmailContent = objEmailContent.ThanksForPayment_FullPayment(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnDouble(ViewState("TotalAmountPayable")))
                        Else
                            strEmailContent = objEmailContent.ThanksForPayment_FullPayment("", "", "", "", "", "", 0)
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "7.html" Then
                        'Dim dstData As DataSet = (New clsEmailContentData()).UK_URL(objFunction.ReturnInteger(Session("BookingId")), 7)
                        Dim dstData As DataSet = (New clsEmailContentData()).UK_URL(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                            strEmailContent = objEmailContent.UK_URL(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), "http://bookings.systems.easyways.co.uk/u/?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")))
                        Else
                            strEmailContent = objEmailContent.UK_URL("", "", "", "", "", "", "")
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "8.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).NoOvernightInMilngavie(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                            strEmailContent = objEmailContent.NoOvernightInMilngavie(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), "http://bookings.systems.easyways.co.uk/u/?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")))
                        Else
                            strEmailContent = objEmailContent.NoOvernightInMilngavie("", "")
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "9.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).FollowUpEmailOnWalkCompletion(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                            strEmailContent = objEmailContent.FollowUpEmailOnWalkCompletion(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")))
                        Else
                            strEmailContent = objEmailContent.FollowUpEmailOnWalkCompletion("", "", "", "", "", "", "")
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "10.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).OnlineEvaluation_ThankYou(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                            strEmailContent = objEmailContent.OnlineEvaluation_ThankYou(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")))
                        Else
                            strEmailContent = objEmailContent.OnlineEvaluation_ThankYou("")
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "15.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).CustomerCancellationReceiptLetter(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then

                            Dim strCancellationPeriod As String = ""

                            If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin_earliest")) <> "" And objFunction.ReturnString(dstData.Tables(0).Rows(0)("cancellation_date")) <> "" Then
                                Dim lngDayDiff As Long = 0
                                lngDayDiff = DateDiff(DateInterval.Day, Convert.ToDateTime(dstData.Tables(0).Rows(0)("cancellation_date")), Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin_earliest")))
                                Trace.Warn("lngDayDiff = " + objFunction.ReturnString(lngDayDiff))

                                If lngDayDiff >= 43 Then
                                    strCancellationPeriod = "43 and over days prior to the walk start date"
                                ElseIf lngDayDiff >= 29 And lngDayDiff <= 42 Then
                                    strCancellationPeriod = "29 to 42 days prior to the walk start date"
                                ElseIf lngDayDiff >= 15 And lngDayDiff <= 28 Then
                                    strCancellationPeriod = "15 to 28 days prior to the walk start date"
                                ElseIf lngDayDiff < 15 Then
                                    strCancellationPeriod = "Less than 15 days prior to the walk start date"
                                End If
                            End If

                            Dim strInvoiceUrl As String = "http://bookings.systems.easyways.co.uk/i/invoice.aspx?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id"))
                            If Convert.ToBoolean(dstData.Tables(0).Rows(0)("customised")) = True Then
                                strInvoiceUrl = "http://bookings.systems.easyways.co.uk/i/invoice_customised.aspx?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id"))
                            End If

                            strEmailContent = objEmailContent.CustomerCancellationReceiptLetter(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("routename")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("routename")), strInvoiceUrl, strCancellationPeriod, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("cancellation_amount")).ToString("0.00"), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("cancellation_amount")).ToString("0.00"), (objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname2"))))
                        Else
                            strEmailContent = objEmailContent.CustomerCancellationReceiptLetter("", "", "", "", "", "", "", "", "", "", "", "")
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "16.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).CreditCardDetailsRequestToHoldRoom(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                            strEmailContent = objEmailContent.CreditCardDetailsRequestToHoldRoom(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")))
                        Else
                            strEmailContent = objEmailContent.CreditCardDetailsRequestToHoldRoom("")
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "18.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).ReceiveChangedBooking(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                            strEmailContent = objEmailContent.ReceiveChangedBooking(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")))
                        Else
                            strEmailContent = objEmailContent.ReceiveChangedBooking("")
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "19.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).ConfirmChangedBookingToCustomer_Successful(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                            Dim strInvoiceUrl As String = "http://bookings.systems.easyways.co.uk/i/invoice.aspx?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id"))
                            If Convert.ToBoolean(dstData.Tables(0).Rows(0)("customised")) = True Then
                                strInvoiceUrl = "http://bookings.systems.easyways.co.uk/i/invoice_customised.aspx?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id"))
                            End If
                            strEmailContent = objEmailContent.ConfirmChangedBookingToCustomer_Successful(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), "http://bookings.systems.easyways.co.uk/u/?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), strInvoiceUrl)
                        Else
                            strEmailContent = objEmailContent.ConfirmChangedBookingToCustomer_Successful("", "", "", "", "", "", "", "")
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "20.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).ConfirmChangedBookingToCustomer_NotSuccessful(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                            strEmailContent = objEmailContent.ConfirmChangedBookingToCustomer_NotSuccessful(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name2")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")))
                        Else
                            strEmailContent = objEmailContent.ConfirmChangedBookingToCustomer_NotSuccessful("", "", "", "", "", "")
                        End If
                    ElseIf DROP_Correspondance.SelectedItem.Value = "21.html" Then
                        Dim dstData As DataSet = (New clsEmailContentData()).DepositReceived(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstData) Then
                        Dim strCheckinEarliest As String = ""
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin_earliest")) <> "" Then
                            strCheckinEarliest = SetDateVal(DateAdd(DateInterval.Day, -42, Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin_earliest"))))
                        End If
                        Dim strInvoiceUrl As String = "http://bookings.systems.easyways.co.uk/i/invoice.aspx?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id"))
                        If Convert.ToBoolean(dstData.Tables(0).Rows(0)("customised")) = True Then
                            strInvoiceUrl = "http://bookings.systems.easyways.co.uk/i/invoice_customised.aspx?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id"))
                        End If
                        strEmailContent = objEmailContent.DepositReceived(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), strInvoiceUrl, objFunction.ReturnDouble(ViewState("TotalBalanceRemaining")), strCheckinEarliest)
                        Else
                            strEmailContent = objEmailContent.DepositReceived("", "", 0, "")
                        End If
                    End If

                TB_Editor2.Text = ""
                TB_Editor2.Text = strEmailContent
            End If
            hdnAccordianStatus.Value = "three"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to add client correspondence detail and send mail to client
    ''' </summary>
    Protected Sub BUT_Send_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Send.Click
        Try
            If TB_Email_Subject2.Text <> "" And DROP_Correspondance.SelectedItem.Value <> "" Then
                objBEBookingCorrespondence.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEBookingCorrespondence.Direction = Convert.ToBoolean(1)
                objBEBookingCorrespondence.Subject = TB_Email_Subject2.Text
                objBEBookingCorrespondence.Notes = TB_Editor2.Text
                objBEBookingCorrespondence.Datex = DateTime.Now
                objBEBookingCorrespondence.CorrespondenceTypeId = 1
                objBEBookingCorrespondence.Typex = 0
                objBEBookingCorrespondence.EmailType = objFunction.ReturnString(DROP_Correspondance.SelectedItem.Text)

                Dim intAffectedRow As Integer = objDLBookingCorrespondence.AddBookingCorrespondence(objBEBookingCorrespondence)
                If intAffectedRow > 0 Then

                    '“Customised Confirmation” or “Fixed Price Confirmation” or “Send Invoice Letter”
                    If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "3.html" Or objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "4.html" Or objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "5.html" Then
                        Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                        objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEClientBooking.InvDate = DateTime.Now
                        Dim intAffectedRow1 As Integer = (New clsDLClientBooking()).UpdateInvDateByBookingId(objBEClientBooking)
                    End If

                    '“Customised Confirmation” or “Fixed Price Confirmation”
                    If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "3.html" Or objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "4.html" Then
                        'Add Booking_Status_Bookings
                        Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                        Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                        objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEBookingStatusBookings.BSCId = 4
                        objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                    End If

                    Trace.Warn("Send ClientEmail = " + objFunction.ReturnString(ViewState("ClientEmail")))
                    Dim strMailStatus As String = clsEmail.SendEmail((objFunction.ReturnString(ViewState("ClientName1")) + objFunction.ReturnString(ViewState("ClientName2"))), objFunction.ReturnString(ViewState("ClientEmail")), TB_Email_Subject2.Text, "Test Msg", TB_Editor2.Text, Me)

                    If strMailStatus = "Success" Then

                        If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "3.html" Or objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "4.html" Or objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "7.html" Or objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "21.html" Then
                            Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                            objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEClientBooking.FlagInvoice = True
                            Dim intAffectedRow1 As Integer = (New clsDLClientBooking()).UpdateFlagInvoiceByBookingId(objBEClientBooking)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "1.html" Or objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "2.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 2
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "1.html" Or objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "4.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 9
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "5.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 10
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "6.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 12
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "7.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 15
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "9.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 22
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "10.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 24
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "18.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 25
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "19.html" Or objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "20.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 26
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance.SelectedItem.Value) = "15.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 27
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        Session("feedback_call") = "1"
                        Session("error_msg") = "Correspondence email sent to client"
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = strMailStatus
                    End If
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the entries"
            End If
            Response.Redirect("correspondance.aspx#one", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the correspondance dropdown of agent
    ''' </summary>
    Protected Sub DROP_Correspondance_Agent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Correspondance_Agent.SelectedIndexChanged
        Try
            TB_Email_Subject4.Text = ""
            Dim strEmailContent As String = ""
            If DROP_Correspondance_Agent.SelectedItem.Value <> "" Then

                If DROP_Correspondance_Agent.SelectedItem.Value = "17.html" Then
                    Dim dstData As DataSet = (New clsEmailContentData()).ConfirmToAgent(objFunction.ReturnInteger(Session("BookingId")))
                    If objFunction.CheckDataSet(dstData) Then
                        'strEmailContent = objEmailContent.ConfirmToAgent(objFunction.ReturnString(dstData.Tables(0).Rows(0)("agentname")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("agentcontact")), SetDateVal(dstData.Tables(0).Rows(0)("checkin_earliest")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("clientname1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("clientname2")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("routename")), (objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname2"))))
                        strEmailContent = objEmailContent.ConfirmToAgent(objFunction.ReturnString(dstData.Tables(0).Rows(0)("agentname")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("AgentContactName1")), SetDateVal(dstData.Tables(0).Rows(0)("checkin_earliest")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("clientname1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("clientname2")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("routename")), (objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname2"))))
                    Else
                        strEmailContent = objEmailContent.ConfirmToAgent("", "", "", "", "", "", "", "")
                    End If
                ElseIf DROP_Correspondance_Agent.SelectedItem.Value = "28.html" Then
                    Dim dstData As DataSet = (New clsEmailContentData()).AgentUKURL(objFunction.ReturnInteger(Session("BookingId")))
                    If objFunction.CheckDataSet(dstData) Then
                        Dim strClientName As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("name2"))
                        TB_Email_Subject4.Text = "EasyWays Tour Pack for " + strClientName
                        'strEmailContent = objEmailContent.AgentUKURL(strClientName, SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("contactname")), strClientName, "http://bookings.systems.easyways.co.uk/u/?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")))
                        strEmailContent = objEmailContent.AgentUKURL(strClientName, SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("RouteName")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("AgentContactName1")), strClientName, "http://bookings.systems.easyways.co.uk/u/?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")))
                    Else
                        strEmailContent = objEmailContent.AgentUKURL("", "", "", "", "", "", "")
                    End If
                End If

                TB_Editor4.Text = ""
                TB_Editor4.Text = strEmailContent
            End If
            hdnAccordianStatus.Value = "four"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to add agent correspondence detail and send mail to agent
    ''' </summary>
    Protected Sub BUT_Send3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Send3.Click
        Try
            If TB_Email_Subject4.Text <> "" And DROP_Correspondance_Agent.SelectedItem.Value <> "" Then
                objBEBookingCorrespondence.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEBookingCorrespondence.Direction = Convert.ToBoolean(1)
                objBEBookingCorrespondence.Subject = TB_Email_Subject4.Text
                objBEBookingCorrespondence.Notes = TB_Editor4.Text
                objBEBookingCorrespondence.Datex = DateTime.Now
                objBEBookingCorrespondence.CorrespondenceTypeId = 1
                objBEBookingCorrespondence.Typex = 0
                objBEBookingCorrespondence.EmailType = objFunction.ReturnString(DROP_Correspondance_Agent.SelectedItem.Text)

                Dim intAffectedRow As Integer = objDLBookingCorrespondence.AddBookingCorrespondence(objBEBookingCorrespondence)
                If intAffectedRow > 0 Then

                    If objFunction.ReturnString(DROP_Correspondance_Agent.SelectedItem.Value) = "17.html" Then
                        Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                        objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                        objBEClientBooking.InvDate = DateTime.Now
                        Dim intAffectedRow1 As Integer = (New clsDLClientBooking()).UpdateInvDateByBookingId(objBEClientBooking)
                    End If

                    If objFunction.ReturnString(DROP_Correspondance_Agent.SelectedItem.Value) = "28.html" Then
                        Dim dstClientBooking As DataSet = (New clsDLClientBooking()).GetClientBookingByBookingId(objFunction.ReturnInteger(Session("BookingId")))
                        If objFunction.CheckDataSet(dstClientBooking) Then
                            If objFunction.ReturnString(dstClientBooking.Tables(0).Rows(0)("inv_date")) = "" Then
                                Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                                objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                                objBEClientBooking.InvDate = DateTime.Now
                                Dim intAffectedRow1 As Integer = (New clsDLClientBooking()).UpdateInvDateByBookingId(objBEClientBooking)
                            End If
                        End If
                    End If

                    Trace.Warn("AgentName = " + objFunction.ReturnString(ViewState("AgentName")))
                    Trace.Warn("AgentEmail = " + objFunction.ReturnString(ViewState("AgentEmail")))
                    Dim strMailStatus As String = clsEmail.SendEmail(objFunction.ReturnString(ViewState("AgentName")), objFunction.ReturnString(ViewState("AgentEmail")), TB_Email_Subject4.Text, "Test Msg", TB_Editor4.Text, Me)

                    If strMailStatus = "Success" Then
                        If objFunction.ReturnString(DROP_Correspondance_Agent.SelectedItem.Value) = "17.html" Then
                            Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                            objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEClientBooking.FlagInvoice = True
                            Dim intAffectedRow1 As Integer = (New clsDLClientBooking()).UpdateFlagInvoiceByBookingId(objBEClientBooking)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance_Agent.SelectedItem.Value) = "28.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 15
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        Session("feedback_call") = "1"
                        Session("error_msg") = "Correspondence email sent to agent"
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = strMailStatus
                    End If
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the entries"
            End If
            Response.Redirect("correspondance.aspx#one", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetDateVal(ByVal value As Object) As String
        If objFunction.ReturnString(value) <> "" Then
            Dim dt As DateTime = Convert.ToDateTime(value)
            Return dt.ToString("dd-MM-yyyy")
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' This function is used to set boolean value
    ''' </summary>
    Public Function SetValue(ByVal value As Object) As String
        If Convert.ToBoolean(value) = True Then
            Return "Sent"
        Else
            Return "Received"
        End If
    End Function

End Class