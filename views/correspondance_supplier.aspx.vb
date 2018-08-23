Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class correspondance_supplier
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
                BindGridview()
                'FillAccommodation()
                FillExtraSupplier(0)
                FillBaggageSupplier()
            End If

            FillAccommodation()

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
                LABEL_Total_Payable.Text = "£" + dblTotalAmountPayable.ToString("0.00")
                Dim dblTotalBalanceRemaining As Double = (New clsPaymentCalculation()).GetTotalBalanceRemaining(dblTotalAmountPayable, intBookingId)
                LABEL_Balance_Remaining.Text = "£" + dblTotalBalanceRemaining.ToString("0.00")
                If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(0)("customised")) = True Then
                    CHK_Customised.Checked = True
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
            objBEBookingCorrespondence.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            objBEBookingCorrespondence.Typex = 1
            Dim dstBookingCorrespondence As New DataSet()
            dstBookingCorrespondence = (New clsDLBookingCorrespondence()).GetBookingCorrespondenceByBookingIdAndTypex(objBEBookingCorrespondence)
            GRID_Correspondance_Supplier.DataSource = dstBookingCorrespondence
            GRID_Correspondance_Supplier.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to fill accomdation dropdown
    ''' </summary>
    Protected Sub FillAccommodation()
        Try
            'Dim intBookingId As Integer = objFunction.ReturnInteger(Session("BookingId"))
            'Dim dstAccommodation As DataSet = (New clsDLAccomRouteStage()).GetAccomRouteStageByBookingIdFillInDD(intBookingId)
            'objFunction.FillDropDownByDataSet(DROP_Accommodation, dstAccommodation)
            'DROP_Accommodation.Items.Insert(0, New ListItem("Select Accommodation", "0"))

            DROP_Accommodation.Items.Clear()
            Dim intBookingId As Integer = objFunction.ReturnInteger(Session("BookingId"))
            Dim dstAccommodation As DataSet = (New clsDLAccomRouteStage()).GetAccomRouteStageByBookingIdFillInDD(intBookingId)
            DROP_Accommodation.Items.Insert(0, New ListItem("Select Accommodation", "0"))
            If objFunction.CheckDataSet(dstAccommodation) Then
                For i = 0 To dstAccommodation.Tables(0).Rows.Count - 1
                    Dim lstItem As ListItem = New ListItem(objFunction.ReturnString(dstAccommodation.Tables(0).Rows(i)("Value")), objFunction.ReturnString(dstAccommodation.Tables(0).Rows(i)("ID")))
                    lstItem.Attributes.Add("data-id", objFunction.ReturnString(dstAccommodation.Tables(0).Rows(i)("AccomId")))
                    DROP_Accommodation.Items.Insert((i + 1), lstItem)
                Next
            End If

            Trace.Warn("hdnAccomId = " + objFunction.ReturnString(hdnAccomId.Value))
            Trace.Warn("hdnAccomDropdownId = " + objFunction.ReturnString(hdnAccomDropdownId.Value))
            If objFunction.ReturnInteger(hdnAccomDropdownId.Value) > 0 Then
                DROP_Accommodation.Items.FindByValue(objFunction.ReturnString(hdnAccomDropdownId.Value)).Selected = True
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to fill extra supplier dropdown
    ''' </summary>
    Protected Sub FillExtraSupplier(ByVal intAccomStageId As Integer)
        Try
            Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
            objBEExtrasBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            objBEExtrasBooking.AccomStageId = intAccomStageId
            Dim dstExtra As DataSet = (New clsDLExtrasBooking()).GetExtrasDetailByBookingIdAndAccomStageIdFillInDD(objBEExtrasBooking)
            objFunction.FillDropDownByDataSet(DROP_Extras_Supplier, dstExtra)
            DROP_Extras_Supplier.Items.Insert(0, New ListItem("Select Extra Supplier", "0"))

            'Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
            'objBEExtrasBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
            'objBEExtrasBooking.AccomStageId = intAccomStageId
            'Dim dstExtra As DataSet = (New clsDLExtrasBooking()).GetExtrasDetailByBookingIdAndAccomStageIdFillInDD(objBEExtrasBooking)

            'DROP_Extras_Supplier.Items.Insert(0, New ListItem("Select Extra Supplier", "0"))
            'If objFunction.CheckDataSet(dstExtra) Then
            '    For i = 0 To dstExtra.Tables(0).Rows.Count - 1
            '        Dim lstItem As ListItem = New ListItem(objFunction.ReturnString(dstExtra.Tables(0).Rows(i)("Value")), objFunction.ReturnString(dstExtra.Tables(0).Rows(i)("ID")))
            '        lstItem.Attributes.Add("data-id", objFunction.ReturnString(dstExtra.Tables(0).Rows(i)("ExtraId")))
            '        DROP_Extras_Supplier.Items.Insert((i + 1), lstItem)
            '    Next
            'End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to fill baggage supplier dropdown
    ''' </summary>
    Protected Sub FillBaggageSupplier()
        Try
            Dim intBookingId As Integer = objFunction.ReturnInteger(Session("BookingId"))
            Dim dstExtrasBaggage As DataSet = (New clsDLExtrasBaggageBooking()).GetExtrasBaggageDetailByBookingIdFillInDD(intBookingId)
            objFunction.FillDropDownByDataSet(DROP_Baggage_Supplier, dstExtrasBaggage)
            DROP_Baggage_Supplier.Items.Insert(0, New ListItem("Select Baggage Supplier", "0"))

            'Dim intBookingId As Integer = objFunction.ReturnInteger(Session("BookingId"))
            'Dim dstExtrasBaggage As DataSet = (New clsDLExtrasBaggageBooking()).GetExtrasBaggageDetailByBookingIdFillInDD(intBookingId)

            'If objFunction.CheckDataSet(dstExtrasBaggage) Then
            '    DROP_Baggage_Supplier.Items.Insert(0, New ListItem("Select Baggage Supplier", "0"))
            '    For i = 0 To dstExtrasBaggage.Tables(0).Rows.Count - 1
            '        Dim lstItem As ListItem = New ListItem(objFunction.ReturnString(dstExtrasBaggage.Tables(0).Rows(i)("Value")), objFunction.ReturnString(dstExtrasBaggage.Tables(0).Rows(i)("ID")))
            '        lstItem.Attributes.Add("data-id", objFunction.ReturnString(dstExtrasBaggage.Tables(0).Rows(i)("ExtraId")))
            '        DROP_Baggage_Supplier.Items.Insert((i + 1), lstItem)
            '    Next
            'End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the correspondance dropdown of supplier
    ''' </summary>
    Protected Sub DROP_Correspondance_Supplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Correspondance_Supplier.SelectedIndexChanged
        Try
            GetCorrespondanceData()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to get correspondance data
    ''' </summary>
    Public Sub GetCorrespondanceData()
        Try
            Dim strEmailContent As String = ""
            If DROP_Correspondance_Supplier.SelectedItem.Value <> "" Then
                'Session("BookingStageAccomId") = Nothing
                'Session("BookingStageExtraBookingId") = Nothing

                'Trace.Warn("BookingStageAccomId = " + objFunction.ReturnString(Session("BookingStageAccomId")))
                'Trace.Warn("BookingStageExtraBookingId = " + objFunction.ReturnString(Session("BookingStageExtraBookingId")))

                Dim dstEmailData As DataSet
                'Trace.Warn("BookingStageAccomId = " + objFunction.ReturnString(Session("BookingStageAccomId")))
                'Trace.Warn("BookingStageExtraBookingId = " + objFunction.ReturnString(Session("BookingStageExtraBookingId")))
                If objFunction.ReturnInteger(hdnAccomId.Value) > 0 Then
                    dstEmailData = (New clsDLAccomodation()).GetAccommodationDetailById(objFunction.ReturnInteger(hdnAccomId.Value))
                    If objFunction.CheckDataSet(dstEmailData) Then
                        ViewState.Add("SendEmailName", objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("name")))
                        ViewState.Add("SendEmailId", objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("email")))
                    End If
                End If

                'If objFunction.ReturnInteger(DROP_Extras_Supplier.SelectedItem.Value) > 0 And objFunction.ReturnString(ViewState("SendEmailId")) = "" Then
                If objFunction.ReturnInteger(DROP_Extras_Supplier.SelectedItem.Value) > 0 Then
                    dstEmailData = (New clsDLExtra()).GetExtraDetailById(objFunction.ReturnInteger(DROP_Extras_Supplier.SelectedItem.Value))
                    If objFunction.CheckDataSet(dstEmailData) Then
                        ViewState.Add("SendEmailName", objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("name")))
                        ViewState.Add("SendEmailId", objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("email")))
                    End If
                End If

                If objFunction.ReturnInteger(DROP_Baggage_Supplier.SelectedItem.Value) > 0 Then
                    dstEmailData = (New clsDLExtra()).GetExtraDetailById(objFunction.ReturnInteger(DROP_Baggage_Supplier.SelectedItem.Value))
                    If objFunction.CheckDataSet(dstEmailData) Then
                        ViewState.Add("SendEmailName", objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("name")))
                        ViewState.Add("SendEmailId", objFunction.ReturnString(dstEmailData.Tables(0).Rows(0)("email")))
                    End If
                End If

                'If DROP_Correspondance_Supplier.SelectedItem.Value = "11.html" Then
                '    strEmailContent = objEmailContent.ToSupplier_AccomBookingGeneral("", DateTime.MinValue, "", DateTime.MinValue, objFunction.ReturnString(ViewState("SendEmailName")), "", "")
                'ElseIf DROP_Correspondance_Supplier.SelectedItem.Value = "12.html" Then
                '    strEmailContent = objEmailContent.ToSupplier_AccomBookingAfterPhoneCall("", DateTime.MinValue, "", DateTime.MinValue, objFunction.ReturnString(ViewState("SendEmailName")), "")
                'ElseIf DROP_Correspondance_Supplier.SelectedItem.Value = "13.html" Then
                '    strEmailContent = objEmailContent.SendBookingConfirmationToSupplier("", DateTime.MinValue, "", objFunction.ReturnString(ViewState("SendEmailName")), "", 0, 0, DateTime.MinValue, "", "", 0, "", "")
                'ElseIf DROP_Correspondance_Supplier.SelectedItem.Value = "14.html" Then
                '    strEmailContent = objEmailContent.SendBookingCancellationToSupplier("", DateTime.MinValue, "", objFunction.ReturnString(ViewState("SendEmailName")), "", 0, 0, DateTime.MinValue, "", "", 0, "", "")
                'End If

                If DROP_Correspondance_Supplier.SelectedItem.Value = "11.html" Then
                    TB_Email_Subject.Text = DROP_Accommodation.SelectedItem.Text + " - Booking Request"
                    Dim dstData As DataSet = (New clsEmailContentData()).ToSupplier_AccomBookingGeneral(objFunction.ReturnInteger(Session("BookingId")))
                    Dim dtDataTemp As DataTable = dstData.Tables(0)
                    dtDataTemp.DefaultView.RowFilter = "accomid = " + objFunction.ReturnString(hdnAccomId.Value)
                    Dim dtData As DataTable = dtDataTemp.DefaultView.ToTable()
                    If objFunction.CheckDataTable(dtData) Then
                        strEmailContent = objEmailContent.ToSupplier_AccomBookingGeneral(objFunction.ReturnString(dtData.Rows(0)("accomname")), SetDateVal(DateTime.Now), objFunction.ReturnString(dtData.Rows(0)("accomcontact")), DateTime.MinValue, objFunction.ReturnString(dtData.Rows(0)("clientname1")), objFunction.ReturnString(dtData.Rows(0)("clientname2")), (objFunction.ReturnString(dtData.Rows(0)("staffname1")) + " " + objFunction.ReturnString(dtData.Rows(0)("staffname2"))))
                    Else
                        strEmailContent = objEmailContent.ToSupplier_AccomBookingGeneral("", "", "", DateTime.MinValue, "", "", "")
                    End If
                ElseIf DROP_Correspondance_Supplier.SelectedItem.Value = "12.html" Then
                    TB_Email_Subject.Text = DROP_Accommodation.SelectedItem.Text + " - Booking Request"
                    Dim dstData As DataSet = (New clsEmailContentData()).ToSupplier_AccomBookingAfterPhoneCall(objFunction.ReturnInteger(Session("BookingId")))
                    Dim dtDataTemp As DataTable = dstData.Tables(0)
                    dtDataTemp.DefaultView.RowFilter = "accomid = " + objFunction.ReturnString(hdnAccomId.Value)
                    Dim dtData As DataTable = dtDataTemp.DefaultView.ToTable()
                    If objFunction.CheckDataTable(dtData) Then
                        strEmailContent = objEmailContent.ToSupplier_AccomBookingAfterPhoneCall(objFunction.ReturnString(dtData.Rows(0)("accomname")), objFunction.ReturnString(dtData.Rows(0)("StageName")), SetDateVal(DateTime.Now), objFunction.ReturnString(dtData.Rows(0)("accomcontact")), DateTime.MinValue, objFunction.ReturnString(dtData.Rows(0)("clientname1")), objFunction.ReturnString(dtData.Rows(0)("clientname2")), (objFunction.ReturnString(dtData.Rows(0)("staffname1")) + " " + objFunction.ReturnString(dtData.Rows(0)("staffname2"))))
                    Else
                        strEmailContent = objEmailContent.ToSupplier_AccomBookingAfterPhoneCall("", "", "", "", DateTime.MinValue, "", "", "")
                    End If
                ElseIf DROP_Correspondance_Supplier.SelectedItem.Value = "13.html" Then
                    TB_Email_Subject.Text = DROP_Accommodation.SelectedItem.Text + " - Booking Confirmation"
                    Dim dstData As DataSet = (New clsEmailContentData()).SendBookingConfirmationToSupplier(objFunction.ReturnInteger(Session("BookingId")), objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value))
                    If objFunction.CheckDataSet(dstData) Then
                        Dim lngDurationOfStay As Long = 0
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin")) <> "" And objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkout")) <> "" Then
                            lngDurationOfStay = DateDiff(DateInterval.Day, Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin")), Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkout")))
                        End If
                        Dim strRoomTypeList As String = ""
                        Dim strRoomPriceList As String = ""
                        Dim dstRoomType As DataSet = (New clsDLAccomStageRoom()).GetAccomStageRoomRoomTypeNameByBookingId(objFunction.ReturnInteger(Session("BookingId")), objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value))
                        If objFunction.CheckDataSet(dstRoomType) Then
                            For i = 0 To dstRoomType.Tables(0).Rows.Count - 1
                                strRoomTypeList += objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("name")) + ","
                                strRoomPriceList += objFunction.ReturnDouble(dstRoomType.Tables(0).Rows(i)("cost_easyways")).ToString("0.00") + ","
                            Next
                        End If
                        strEmailContent = objEmailContent.SendBookingConfirmationToSupplier(objFunction.ReturnString(dstData.Tables(0).Rows(0)("accomname")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("accomcontact")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("clientname1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("clientname2")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("total_num")), objFunction.ReturnInteger(lngDurationOfStay), SetDateVal(dstData.Tables(0).Rows(0)("checkin")), strRoomTypeList.TrimEnd(","), objFunction.ReturnString(dstData.Tables(0).Rows(0)("dietaryneeds")), strRoomPriceList.TrimEnd(","), objFunction.ReturnString(dstData.Tables(0).Rows(0)("supplier_note")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("payment_prefer")), (objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname2"))))
                    Else
                        strEmailContent = objEmailContent.SendBookingConfirmationToSupplier("", "", "", "", "", 0, 0, "", "", "", "", "", "", "")
                    End If
                ElseIf DROP_Correspondance_Supplier.SelectedItem.Value = "14.html" Then
                    TB_Email_Subject.Text = DROP_Accommodation.SelectedItem.Text + " - Cancellation"
                    Dim dstData As DataSet = (New clsEmailContentData()).SendBookingCancellationToSupplier(objFunction.ReturnInteger(Session("BookingId")), objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value))
                    If objFunction.CheckDataSet(dstData) Then
                        Dim lngDurationOfStay As Long = 0
                        If objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkin")) <> "" And objFunction.ReturnString(dstData.Tables(0).Rows(0)("checkout")) <> "" Then
                            lngDurationOfStay = DateDiff(DateInterval.Day, Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkin")), Convert.ToDateTime(dstData.Tables(0).Rows(0)("checkout")))
                        End If
                        Dim strRoomTypeList As String = ""
                        Dim strRoomPriceList As String = ""
                        Dim dstRoomType As DataSet = (New clsDLAccomStageRoom()).GetAccomStageRoomRoomTypeNameByBookingId(objFunction.ReturnInteger(Session("BookingId")), objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value))
                        If objFunction.CheckDataSet(dstRoomType) Then
                            For i = 0 To dstRoomType.Tables(0).Rows.Count - 1
                                strRoomTypeList += objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("name")) + ","
                                strRoomPriceList += objFunction.ReturnDouble(dstRoomType.Tables(0).Rows(i)("cost_easyways")).ToString("0.00") + ","
                            Next
                        End If
                        strEmailContent = objEmailContent.SendBookingCancellationToSupplier(objFunction.ReturnString(dstData.Tables(0).Rows(0)("accomname")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("accomcontact")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("clientname1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("clientname2")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("total_num")), objFunction.ReturnInteger(lngDurationOfStay), SetDateVal(dstData.Tables(0).Rows(0)("checkin")), strRoomTypeList.TrimEnd(","), objFunction.ReturnString(dstData.Tables(0).Rows(0)("dietaryneeds")), strRoomPriceList.TrimEnd(","), objFunction.ReturnString(dstData.Tables(0).Rows(0)("unique_id")), (objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname2"))))
                    Else
                        strEmailContent = objEmailContent.SendBookingCancellationToSupplier("", "", "", "", "", 0, 0, "", "", "", "", "", "")
                    End If
                ElseIf DROP_Correspondance_Supplier.SelectedItem.Value = "22.html" Then
                    TB_Email_Subject.Text = DROP_Extras_Supplier.SelectedItem.Text + " - Late Booking"
                    Dim dstData As DataSet = (New clsEmailContentData()).EmailExtra_IndividualBookingEGTaxi(objFunction.ReturnInteger(Session("BookingId")))
                    If objFunction.CheckDataSet(dstData) Then
                        'strEmailContent = objEmailContent.EmailExtra_IndividualBookingEGTaxi(objFunction.ReturnString(dstData.Tables(0).Rows(0)("ExtraName")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("ExtraContact")), (objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname2"))), objFunction.ReturnInteger(Session("BookingId")))
                        strEmailContent = objEmailContent.EmailExtra_IndividualBookingEGTaxi("", SetDateVal(DateTime.Now), "", (objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname2"))), objFunction.ReturnInteger(Session("BookingId")))
                    Else
                        strEmailContent = objEmailContent.EmailExtra_IndividualBookingEGTaxi("", "", "", "", 0)
                    End If
                ElseIf DROP_Correspondance_Supplier.SelectedItem.Value = "24.html" Then
                    TB_Email_Subject.Text = DROP_Baggage_Supplier.SelectedItem.Text + " - Late Booking"
                    Dim dstData As DataSet = (New clsEmailContentData()).EmailExtra_IndividualBookingEGTaxi(objFunction.ReturnInteger(Session("BookingId")))
                    If objFunction.CheckDataSet(dstData) Then
                        'strEmailContent = objEmailContent.EmailExtra_IndividualBookingEGTaxi(objFunction.ReturnString(dstData.Tables(0).Rows(0)("ExtraName")), SetDateVal(DateTime.Now), objFunction.ReturnString(dstData.Tables(0).Rows(0)("ExtraContact")), (objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname2"))), objFunction.ReturnInteger(Session("BookingId")))
                        strEmailContent = objEmailContent.EmailBaggageCompany_IndividualBooking("", SetDateVal(DateTime.Now), "", (objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("staffname2"))), objFunction.ReturnInteger(Session("BookingId")))
                    Else
                        strEmailContent = objEmailContent.EmailBaggageCompany_IndividualBooking("", "", "", "", 0)
                    End If
                End If
                TB_Editor.Text = ""
                TB_Editor.Text = strEmailContent
                TB_Email_Address.Text = objFunction.ReturnString(ViewState("SendEmailId"))
            End If

            hdnAccordianStatus.Value = "two"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to add supplier correspondence detail and send mail to supplier
    ''' </summary>
    Protected Sub BUT_Send_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Send.Click
        Try
            If TB_Email_Subject.Text <> "" And DROP_Correspondance_Supplier.SelectedItem.Value <> "" Then
                objBEBookingCorrespondence.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                objBEBookingCorrespondence.Direction = Convert.ToBoolean(1)
                objBEBookingCorrespondence.Subject = TB_Email_Subject.Text
                objBEBookingCorrespondence.Notes = TB_Editor.Text
                objBEBookingCorrespondence.Datex = DateTime.Now
                objBEBookingCorrespondence.CorrespondenceTypeId = 1
                objBEBookingCorrespondence.Typex = 1

                If objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value) > 0 Then
                    objBEBookingCorrespondence.AccomId = objFunction.ReturnInteger(hdnAccomId.Value)
                End If

                If objFunction.ReturnInteger(DROP_Extras_Supplier.SelectedItem.Value) > 0 Then
                    objBEBookingCorrespondence.ExtraId = objFunction.ReturnInteger(DROP_Extras_Supplier.SelectedItem.Value)
                End If

                Dim intAffectedRow As Integer = objDLBookingCorrespondence.AddBookingCorrespondence(objBEBookingCorrespondence)
                If intAffectedRow > 0 Then
                    Trace.Warn("SendEmailName = " + objFunction.ReturnString(ViewState("SendEmailName")))
                    Trace.Warn("SendEmailId = " + objFunction.ReturnString(ViewState("SendEmailId")))

                    Dim strMailStatus As String = clsEmail.SendEmail(objFunction.ReturnString(ViewState("SendEmailName")), objFunction.ReturnString(ViewState("SendEmailId")), TB_Email_Subject.Text, "Test Msg", TB_Editor.Text, Me)

                    If strMailStatus = "Success" Then
                        
                        If objFunction.ReturnString(DROP_Correspondance_Supplier.SelectedItem.Value) = "13.html" Or objFunction.ReturnString(DROP_Correspondance_Supplier.SelectedItem.Value) = "14.html" Or objFunction.ReturnString(DROP_Correspondance_Supplier.SelectedItem.Value) = "22.html" Or objFunction.ReturnString(DROP_Correspondance_Supplier.SelectedItem.Value) = "24.html" Then
                            Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                            objBEClientBooking.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEClientBooking.FlagInvoice = True
                            Dim intAffectedRow1 As Integer = (New clsDLClientBooking()).UpdateFlagInvoiceByBookingId(objBEClientBooking)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance_Supplier.SelectedItem.Value) = "13.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 8
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        If objFunction.ReturnString(DROP_Correspondance_Supplier.SelectedItem.Value) = "14.html" Then
                            'Add Booking_Status_Bookings
                            Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                            Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                            objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(Session("BookingId"))
                            objBEBookingStatusBookings.BSCId = 28
                            objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        End If

                        Session("feedback_call") = "1"
                        Session("error_msg") = "Correspondence sent to supplier"
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
            hdnAccordianStatus.Value = "one"
            Response.Redirect("correspondance_supplier.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to go back to booking add stage screen
    ''' </summary>
    Protected Sub BUT_Back_to_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Back_to_Booking.Click

        Try
            Response.Redirect("bookings_view.aspx")
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

    ''' <summary>
    ''' SelectedIndexChanged event of the accomodation dropdown
    ''' </summary>
    Protected Sub DROP_Accommodation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Accommodation.SelectedIndexChanged
        Try
            TB_Email_Subject.Text = ""
            DROP_Correspondance_Supplier.Items.Clear()
            DROP_Correspondance_Supplier.Items.Insert(0, New ListItem("Select Correspondance", "0"))
            DROP_Correspondance_Supplier.Items.Insert(1, New ListItem("To Supplier - Accom Booking General", "11.html"))
            DROP_Correspondance_Supplier.Items.Insert(2, New ListItem("To Supplier - Accom Booking after Phone Call", "12.html"))
            DROP_Correspondance_Supplier.Items.Insert(3, New ListItem("Send Booking Confirmation to Supplier", "13.html"))
            DROP_Correspondance_Supplier.Items.Insert(4, New ListItem("Send Booking Cancellation to Supplier", "14.html"))
            FillExtraSupplier(objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value))
            GetCorrespondanceData()

            DROP_Extras_Supplier.ClearSelection()
            DROP_Baggage_Supplier.ClearSelection()

            hdnAccordianStatus.Value = "two"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the baggage dropdown
    ''' </summary>
    Protected Sub DROP_Baggage_Supplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Baggage_Supplier.SelectedIndexChanged
        Try
            TB_Email_Subject.Text = ""
            TB_Email_Address.Text = ""
            DROP_Correspondance_Supplier.Items.Clear()
            DROP_Correspondance_Supplier.Items.Insert(0, New ListItem("Select Correspondance", "0"))
            DROP_Correspondance_Supplier.Items.Insert(1, New ListItem("EMAIL BAGGAGE COMPANY - INDIVIDUAL BOOKING", "24.html"))

            If objFunction.ReturnInteger(DROP_Extras_Supplier.SelectedItem.Value) > 0 Then
                FillExtraSupplier(objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value))
            End If

            GetCorrespondanceData()

            DROP_Accommodation.ClearSelection()
            DROP_Extras_Supplier.ClearSelection()

            hdnAccordianStatus.Value = "two"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub DROP_Extras_Supplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Extras_Supplier.SelectedIndexChanged
        Try
            TB_Email_Subject.Text = ""
            TB_Email_Address.Text = ""
            DROP_Correspondance_Supplier.Items.Clear()
            DROP_Correspondance_Supplier.Items.Insert(0, New ListItem("Select Correspondance", "0"))
            DROP_Correspondance_Supplier.Items.Insert(1, New ListItem("EMAIL EXTRA - INDIVIDUAL BOOKING E.G. TAXI", "22.html"))

            GetCorrespondanceData()

            DROP_Accommodation.ClearSelection()
            DROP_Baggage_Supplier.ClearSelection()

            'If objFunction.ReturnInteger(DROP_Baggage_Supplier.SelectedItem.Value) > 0 Then
            '    DROP_Baggage_Supplier.ClearSelection()
            '    'DROP_Baggage_Supplier.Items.FindByValue("0").Selected = True
            'End If
            hdnAccordianStatus.Value = "two"
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





