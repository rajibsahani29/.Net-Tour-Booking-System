Imports Microsoft.VisualBasic
Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Public Class clsEmailContent

    Dim objFunction As New clsCommon()

    Public Function CustomizedReply(ByVal strName1 As String, ByVal strName2 As String, ByVal strDate As String, ByVal strName1_1 As String, ByVal strRouteName As String, ByVal strOvernights As String, ByVal strOccupancy As String, ByVal strBagWeight As String, ByVal dblBookingFeeTotal As Double, ByVal strNewsletter As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strRouteName)
        lstEmailValue.Add(strOvernights)
        lstEmailValue.Add(strOccupancy)
        lstEmailValue.Add(strBagWeight)
        lstEmailValue.Add(dblBookingFeeTotal.ToString("0.00"))
        lstEmailValue.Add(strNewsletter)
        Return ReadHtmlPage("1.html", lstEmailValue)

    End Function

    Public Function FixedPriceReply(ByVal strName1 As String, ByVal strName2 As String, ByVal strDate As String, ByVal strName1_1 As String, ByVal strRouteName As String, ByVal strNameFPWalk As String, ByVal dblCostPerPerson As Double, ByVal strOccupancy As String, ByVal strBagWeight As String, ByVal intDaysWalking As Integer, ByVal strOvernights As String, ByVal strNewsletter As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strRouteName)
        lstEmailValue.Add(strNameFPWalk)
        lstEmailValue.Add(objFunction.ReturnString(dblCostPerPerson))
        lstEmailValue.Add(strOccupancy)
        lstEmailValue.Add(strBagWeight)
        lstEmailValue.Add(objFunction.ReturnString(intDaysWalking))
        lstEmailValue.Add(strOvernights)
        lstEmailValue.Add(strNewsletter)
        Return ReadHtmlPage("2.html", lstEmailValue)

    End Function


    Public Function CustomizedWalkConfirmaionEmail(ByVal strName1 As String, ByVal strName2 As String, ByVal strDate As String, ByVal strNameWalk As String, ByVal strBookingId As String, ByVal strName1_1 As String, ByVal strDayOfTravel As String, ByVal strDateOfTravel As String, ByVal strStage1 As String, ByVal intDaysWalking As Integer, ByVal strStageLast As String, ByVal strLastDayOfTravel As String, ByVal strLastDateOfTravel As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strNameWalk)
        lstEmailValue.Add(strBookingId)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strDayOfTravel)
        lstEmailValue.Add(strDateOfTravel)
        lstEmailValue.Add(strStage1)
        lstEmailValue.Add(objFunction.ReturnString(intDaysWalking))
        lstEmailValue.Add(strStageLast)
        lstEmailValue.Add(strLastDayOfTravel)
        lstEmailValue.Add(strLastDateOfTravel)
        Return ReadHtmlPage("3.html", lstEmailValue)

    End Function

    Public Function FixedPriceWalkConfirmaionEmail(ByVal strName1 As String, ByVal strName2 As String, ByVal strDate As String, ByVal strNameWalk As String, ByVal strBookingId As String, ByVal strName1_1 As String, ByVal strTotalCostOfBooking As String, ByVal strDayOfTravel As String, ByVal strDateOfTravel As String, ByVal strStage1 As String, ByVal intDaysWalking As Integer, ByVal strStageLast As String, ByVal strLastDayOfTravel As String, ByVal strLastDateOfTravel As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strNameWalk)
        lstEmailValue.Add(strBookingId)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strTotalCostOfBooking)
        lstEmailValue.Add(strDayOfTravel)
        lstEmailValue.Add(strDateOfTravel)
        lstEmailValue.Add(strStage1)
        lstEmailValue.Add(objFunction.ReturnString(intDaysWalking))
        lstEmailValue.Add(strStageLast)
        lstEmailValue.Add(strLastDayOfTravel)
        lstEmailValue.Add(strLastDateOfTravel)
        Return ReadHtmlPage("4.html", lstEmailValue)

    End Function

    Public Function PreviouslyInvoicedClientsEmail(ByVal strName1 As String, ByVal strName2 As String, ByVal strDate As String, ByVal strNameWalk As String, ByVal strBookingId As String, ByVal strName1_2 As String, ByVal strNameWalk2 As String, ByVal strInvoiceURL As String, ByVal strNameWalk3 As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strNameWalk)
        lstEmailValue.Add(strBookingId)
        lstEmailValue.Add(strName1_2)
        lstEmailValue.Add(strNameWalk2)
        lstEmailValue.Add(strInvoiceURL)
        lstEmailValue.Add(strNameWalk3)
        Return ReadHtmlPage("5.html", lstEmailValue)

    End Function

    Public Function ThanksForPayment_FullPayment(ByVal strName1_1 As String, ByVal strName2 As String, ByVal strDate As String, ByVal strNameWalk As String, ByVal strBookingId As String, ByVal strName1 As String, ByVal dblClientPaymentAmount As Double) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strNameWalk)
        lstEmailValue.Add(strBookingId)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(objFunction.ReturnString(dblClientPaymentAmount))
        Return ReadHtmlPage("6.html", lstEmailValue)

    End Function

    Public Function UK_URL(ByVal strName1_1 As String, ByVal strName2 As String, ByVal strDate As String, ByVal strNameWalk As String, ByVal strBookingId As String, ByVal strName1 As String, ByVal strTourPackURL As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strNameWalk)
        lstEmailValue.Add(strBookingId)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strTourPackURL)
        Return ReadHtmlPage("7.html", lstEmailValue)

    End Function

    Public Function NoOvernightInMilngavie(ByVal strName1 As String, ByVal strTourPackURL As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strTourPackURL)
        Return ReadHtmlPage("8.html", lstEmailValue)

    End Function

    Public Function FollowUpEmailOnWalkCompletion(ByVal strName1_1 As String, ByVal strName2 As String, ByVal strDate As String, ByVal strNameWalk As String, ByVal strBookingId As String, ByVal strName1 As String, ByVal strNameWalk2 As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strNameWalk)
        lstEmailValue.Add(strBookingId)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strNameWalk2)
        Return ReadHtmlPage("9.html", lstEmailValue)

    End Function

    Public Function OnlineEvaluation_ThankYou(ByVal strName1 As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1)
        Return ReadHtmlPage("10.html", lstEmailValue)

    End Function

    Public Function ToSupplier_AccomBookingGeneral(ByVal strSupplierName As String, ByVal strDate As String, ByVal strSupplierContactName As String, ByVal dtDateOfTravel As DateTime, ByVal strName1 As String, ByVal strName2 As String, ByVal strEWStaffName As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strSupplierName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSupplierContactName)
        lstEmailValue.Add((If(dtDateOfTravel <> DateTime.MinValue, objFunction.ReturnString(dtDateOfTravel), "")))
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strEWStaffName)
        Return ReadHtmlPage("11.html", lstEmailValue)

    End Function

    Public Function ToSupplier_AccomBookingAfterPhoneCall(ByVal strSupplierName As String, ByVal strStageName As String, ByVal strDate As String, ByVal strSupplierContactName As String, ByVal dtDateOfTravel As DateTime, ByVal strName1 As String, ByVal strName2 As String, ByVal strEWStaffName As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strSupplierName)
        lstEmailValue.Add(strStageName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSupplierContactName)
        lstEmailValue.Add((If(dtDateOfTravel <> DateTime.MinValue, objFunction.ReturnString(dtDateOfTravel), "")))
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strEWStaffName)
        Return ReadHtmlPage("12.html", lstEmailValue)

    End Function

    Public Function SendBookingConfirmationToSupplier(ByVal strSupplierName As String, ByVal strDate As String, ByVal strSupplierContactName As String, ByVal strName1_1 As String, ByVal strName2 As String, ByVal intNumberOfPeopleBooking As Integer, ByVal intDurationOfStay As Integer, ByVal strDateOfStay As String, ByVal strRoomType As String, ByVal strDietaryNeeds As String, ByVal strRateQuoted As String, ByVal strSupplierNote As String, ByVal strRefNumber As String, ByVal strEWStaffName As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strSupplierName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSupplierContactName)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(objFunction.ReturnString(intNumberOfPeopleBooking))
        lstEmailValue.Add(objFunction.ReturnString(intDurationOfStay))
        lstEmailValue.Add(strDateOfStay)
        lstEmailValue.Add(strRoomType)
        lstEmailValue.Add(strDietaryNeeds)
        lstEmailValue.Add(strRateQuoted)
        lstEmailValue.Add(strSupplierNote)
        lstEmailValue.Add(strRefNumber)
        lstEmailValue.Add(strEWStaffName)
        Return ReadHtmlPage("13.html", lstEmailValue)

    End Function

    Public Function SendBookingCancellationToSupplier(ByVal strSupplierName As String, ByVal strDate As String, ByVal strSupplierContactName As String, ByVal strName1_1 As String, ByVal strName2 As String, ByVal intNumberOfPeopleBooking As Integer, ByVal intDurationOfStay As Integer, ByVal strDateOfStay As String, ByVal strRoomType As String, ByVal strDietaryNeeds As String, ByVal strRateQuoted As String, ByVal strRefNumber As String, ByVal strEWStaffName As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strSupplierName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSupplierContactName)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(objFunction.ReturnString(intNumberOfPeopleBooking))
        lstEmailValue.Add(objFunction.ReturnString(intDurationOfStay))
        lstEmailValue.Add(strDateOfStay)
        lstEmailValue.Add(strRoomType)
        lstEmailValue.Add(strDietaryNeeds)
        lstEmailValue.Add(strRateQuoted)
        lstEmailValue.Add(strRefNumber)
        lstEmailValue.Add(strEWStaffName)
        Return ReadHtmlPage("14.html", lstEmailValue)

    End Function

    Public Function CustomerCancellationReceiptLetter(ByVal strName1_1 As String, ByVal strName2_1 As String, ByVal strDate As String, ByVal strNameWalk As String, ByVal strBookingId As String, ByVal strName1_2 As String, ByVal strNameWalk2 As String, ByVal strInvoiceLink As String, ByVal strCancellationPeriod As String, ByVal strCancellationFee As String, ByVal strCancellationFee2 As String, ByVal strEWStaffName As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strName2_1)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strNameWalk)
        lstEmailValue.Add(strBookingId)
        lstEmailValue.Add(strName1_2)
        lstEmailValue.Add(strNameWalk2)
        lstEmailValue.Add(strInvoiceLink)
        lstEmailValue.Add(strCancellationPeriod)
        lstEmailValue.Add(strCancellationFee)
        lstEmailValue.Add(strCancellationFee2)
        lstEmailValue.Add(strEWStaffName)
        Return ReadHtmlPage("15.html", lstEmailValue)

    End Function

    Public Function CreditCardDetailsRequestToHoldRoom(ByVal strName1 As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1)
        Return ReadHtmlPage("16.html", lstEmailValue)

    End Function

    Public Function ConfirmToAgent(ByVal strAgentName As String, ByVal strDate As String, ByVal strAgentContactName As String, ByVal strDateOfTravel As String, ByVal strName1 As String, ByVal strName2 As String, ByVal strNameWalk As String, ByVal strEWStaffName As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strAgentName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strAgentContactName)
        lstEmailValue.Add(strDateOfTravel)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strNameWalk)
        lstEmailValue.Add(strEWStaffName)
        Return ReadHtmlPage("17.html", lstEmailValue)

    End Function

    Public Function ReceiveChangedBooking(ByVal strName1 As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1)
        Return ReadHtmlPage("18.html", lstEmailValue)

    End Function

    Public Function ConfirmChangedBookingToCustomer_Successful(ByVal strName1_1 As String, ByVal strName2 As String, ByVal strDate As String, ByVal strNameWalk As String, ByVal strBookingId As String, ByVal strName1 As String, ByVal strTourPackURL As String, ByVal strInvoiceURL As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strNameWalk)
        lstEmailValue.Add(strBookingId)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strTourPackURL)
        lstEmailValue.Add(strInvoiceURL)
        Return ReadHtmlPage("19.html", lstEmailValue)

    End Function

    Public Function ConfirmChangedBookingToCustomer_NotSuccessful(ByVal strName1_1 As String, ByVal strName2 As String, ByVal strDate As String, ByVal strNameWalk As String, ByVal strBookingId As String, ByVal strName1 As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1_1)
        lstEmailValue.Add(strName2)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strNameWalk)
        lstEmailValue.Add(strBookingId)
        lstEmailValue.Add(strName1)
        Return ReadHtmlPage("20.html", lstEmailValue)

    End Function

    Public Function DepositReceived(ByVal strName1 As String, ByVal strTourPackURL As String, ByVal dblBalanceDue As Double, ByVal strFullPaymentDueDate As String) As String
        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName1)
        lstEmailValue.Add(strTourPackURL)
        lstEmailValue.Add(objFunction.ReturnString(dblBalanceDue))
        lstEmailValue.Add(strFullPaymentDueDate)
        Return ReadHtmlPage("21.html", lstEmailValue)

    End Function

    Public Function EmailExtra_IndividualBookingEGTaxi(ByVal strSupplierName As String, ByVal strDate As String, ByVal strSupplierContactName As String, ByVal strEWStaffName As String, ByVal intBookingID As Integer) As String
        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strSupplierName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSupplierContactName)

        Dim strRepeaterValue As String = ""

        Dim dblCostEasyways As Double = 0

        Dim dstData As DataSet = (New clsEmailContentData()).EmailExtra_IndividualBookingEGTaxi_Repeater(intBookingID)
        If objFunction.CheckDataSet(dstData) Then
            For i = 0 To dstData.Tables(0).Rows.Count - 1

                Dim lstRepeaterValue As New List(Of String)

                Dim strDateVal As String = ""
                If objFunction.ReturnString(dstData.Tables(0).Rows(i)("StartDayOfTravel")) <> "" Then
                    'strDateVal = Convert.ToDateTime(dstData.Tables(0).Rows(i)("StartDayOfTravel")).ToString("dd-MM-yyyy")
                    Dim dt As DateTime = Convert.ToDateTime(dstData.Tables(0).Rows(i)("StartDayOfTravel"))
                    HttpContext.Current.Trace.Warn("Start date = " + objFunction.ReturnString(dt))
                    strDateVal = objFunction.ReturnString(dt.DayOfWeek) + ", " + objFunction.ReturnString(dt.Day) + daySuffix(dt.Day) + " " + MonthName(dt.Month)
                End If

                HttpContext.Current.Trace.Warn("strDateVal = " + strDateVal)

                lstRepeaterValue.Add(strDateVal)
                lstRepeaterValue.Add(strDateVal)
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("ClientName1")))
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("ClientName2")))
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("FirstAccomName")))
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("FirstAccomCity")))
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("SecondAccomName")))
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("SecondAccomCity")))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("CostEasyways")))
                dblCostEasyways += objFunction.ReturnDouble(dstData.Tables(0).Rows(i)("CostEasyways"))

                strRepeaterValue += ReadHtmlPage("22_Repeater.html", lstRepeaterValue)

            Next
        End If

        lstEmailValue.Add(strRepeaterValue)
        lstEmailValue.Add(dblCostEasyways.ToString("0.00"))
        lstEmailValue.Add(strEWStaffName)

        Return ReadHtmlPage("22.html", lstEmailValue)

    End Function

    Public Function EmailExtra_IndividualBookingEGTaxi_Bulk(ByVal strSupplierName As String, ByVal strDate As String, ByVal strSupplierContactName As String, ByVal strEWStaffName As String, ByVal intExtraId As Integer) As String
        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strSupplierName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSupplierContactName)

        Dim strRepeaterValue As String = ""

        Dim dblCostEasyways As Double = 0

        Dim intMonth As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
        Dim intYear As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
        'Dim intMonth As Integer = 9
        'Dim intYear As Integer = 2017
        Dim dstData As DataSet = (New clsEmailContentData()).EmailExtra_IndividualBookingEGTaxi_Bulk_Repeater(intExtraId, intMonth, intYear)

        If objFunction.CheckDataSet(dstData) Then
            For i = 0 To dstData.Tables(0).Rows.Count - 1

                Dim lstRepeaterValue As New List(Of String)

                HttpContext.Current.Trace.Warn("StartDayOfTravel = " + objFunction.ReturnString(dstData.Tables(0).Rows(i)("StartDayOfTravel")))
                Dim strDateVal As String = ""
                If objFunction.ReturnString(dstData.Tables(0).Rows(i)("StartDayOfTravel")) <> "" Then
                    'strDateVal = Convert.ToDateTime(dstData.Tables(0).Rows(i)("StartDayOfTravel")).ToString("dd-MM-yyyy")
                    Dim dt As DateTime = Convert.ToDateTime(dstData.Tables(0).Rows(i)("StartDayOfTravel"))
                    HttpContext.Current.Trace.Warn("Start date = " + objFunction.ReturnString(dt))
                    strDateVal = objFunction.ReturnString(dt.DayOfWeek) + ", " + objFunction.ReturnString(dt.Day) + daySuffix(dt.Day) + " " + MonthName(dt.Month)
                End If

                HttpContext.Current.Trace.Warn("strDateVal = " + strDateVal)

                lstRepeaterValue.Add(strDateVal)
                'lstRepeaterValue.Add(strDateVal)
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("ClientName1")))
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("ClientName2")))

                'Booking Status
                Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("id"))
                Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingId(objBEBookingStatusBookings)
                Dim strBookingStatus As String = ""
                If objFunction.CheckDataSet(dstBookingStatusBookings) Then

                    Dim dstBookingStatusComplete As DataSet
                    Dim objBEBookingStatusComplete As clsBEBookingStatusComplete = New clsBEBookingStatusComplete
                    If objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("agent_id")) = 0 Then
                        objBEBookingStatusComplete.Easyways = True
                        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByEasyways(objBEBookingStatusComplete)
                    Else
                        objBEBookingStatusComplete.Agent = True
                        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByAgent(objBEBookingStatusComplete)
                    End If

                    If objFunction.CheckDataSet(dstBookingStatusComplete) Then
                        Dim dtData As DataTable = dstBookingStatusBookings.Tables(0)
                        dtData.DefaultView.RowFilter = "cat = 1"
                        dtData.DefaultView.Sort = "orderx DESC"
                        Dim dtDataTemp As DataTable = dtData.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtDataTemp) Then
                            'strBookingStatus = objFunction.ReturnString(dtDataTemp.Rows(0)("name"))

                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 1"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                Dim strNextBookingStatus As String = ""
                                For j = 0 To dtStatusTemp.Rows.Count - 1
                                    If objFunction.ReturnInteger(dtStatusTemp.Rows(j)("orderx")) = objFunction.ReturnInteger(dtDataTemp.Rows(0)("orderx")) Then
                                        If j = (dtStatusTemp.Rows.Count - 1) Then
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                        Else
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j + 1)("name"))
                                        End If
                                        Exit For
                                    End If
                                Next
                                strBookingStatus = strNextBookingStatus
                            Else
                            End If
                        Else
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 1"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                strBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(0)("name"))
                            End If
                        End If
                    End If

                End If

                lstRepeaterValue.Add(strBookingStatus)
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("total_num")))
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("FirstAccomName")))
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("FirstAccomCity")))
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("SecondAccomName")))
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("SecondAccomCity")))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(""))
                'lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("CostEasyways")))
                dblCostEasyways += objFunction.ReturnDouble(dstData.Tables(0).Rows(i)("CostEasyways"))

                strRepeaterValue += ReadHtmlPage("23_Repeater.html", lstRepeaterValue)

            Next
        End If

        lstEmailValue.Add(strRepeaterValue)
        lstEmailValue.Add(dblCostEasyways.ToString("0.00"))
        lstEmailValue.Add(strEWStaffName)

        Return ReadHtmlPage("23.html", lstEmailValue)

    End Function

    Public Function EmailBaggageCompany_IndividualBooking(ByVal strSupplierName As String, ByVal strDate As String, ByVal strSupplierContactName As String, ByVal strEWStaffName As String, ByVal intBookingID As Integer) As String
        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strSupplierName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSupplierContactName)

        Dim strRepeaterValue As String = ""

        Dim dstData As DataSet = (New clsEmailContentData()).EmailBaggageCompany_IndividualBooking_Repeater(intBookingID)
        If objFunction.CheckDataSet(dstData) Then
            For i = 0 To dstData.Tables(0).Rows.Count - 1

                Dim lstRepeaterValue As New List(Of String)

                Dim strDateVal As String = ""
                If objFunction.ReturnString(dstData.Tables(0).Rows(i)("checkin_earliest")) <> "" Then
                    'strDateVal = Convert.ToDateTime(dstData.Tables(0).Rows(i)("StartDayOfTravel")).ToString("dd-MM-yyyy")
                    Dim dt As DateTime = Convert.ToDateTime(dstData.Tables(0).Rows(i)("checkin_earliest"))
                    HttpContext.Current.Trace.Warn("Start date = " + objFunction.ReturnString(dt))
                    strDateVal = objFunction.ReturnString(dt.Day) + daySuffix(dt.Day) + " " + MonthName(dt.Month)
                End If

                HttpContext.Current.Trace.Warn("strDateVal = " + strDateVal)

                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("codex")))
                lstRepeaterValue.Add(strDateVal)
                'lstRepeaterValue.Add(strDateVal)
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("ClientName1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(i)("ClientName2")))
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("AgentName")))
                lstRepeaterValue.Add("http://bookings.systems.easyways.co.uk/u/booking_info_baggage.aspx?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(i)("unique_id")))

                strRepeaterValue += ReadHtmlPage("24_Repeater.html", lstRepeaterValue)

            Next
        End If

        lstEmailValue.Add(strRepeaterValue)
        lstEmailValue.Add(strEWStaffName)

        Return ReadHtmlPage("24.html", lstEmailValue)

    End Function

    Public Function EmailBaggageCompany_IndividualBooking_Bulk(ByVal strSupplierName As String, ByVal strDate As String, ByVal strSupplierContactName As String, ByVal strEWStaffName As String, ByVal intExtraId As Integer) As String
        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strSupplierName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSupplierContactName)

        Dim strRepeaterValue As String = ""

        Dim intMonth As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
        Dim intYear As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
        'Dim intMonth As Integer = 9
        'Dim intYear As Integer = 2017
        Dim dstData As DataSet = (New clsEmailContentData()).EmailBaggageCompany_IndividualBooking_Bulk_Repeater(intExtraId, intMonth, intYear)

        If objFunction.CheckDataSet(dstData) Then
            For i = 0 To dstData.Tables(0).Rows.Count - 1

                Dim lstRepeaterValue As New List(Of String)

                Dim strDateVal As String = ""
                If objFunction.ReturnString(dstData.Tables(0).Rows(i)("checkin_earliest")) <> "" Then
                    'strDateVal = Convert.ToDateTime(dstData.Tables(0).Rows(i)("StartDayOfTravel")).ToString("dd-MM-yyyy")
                    Dim dt As DateTime = Convert.ToDateTime(dstData.Tables(0).Rows(i)("checkin_earliest"))
                    HttpContext.Current.Trace.Warn("Start date = " + objFunction.ReturnString(dt))
                    strDateVal = objFunction.ReturnString(dt.Day) + daySuffix(dt.Day) + " " + MonthName(dt.Month)
                End If

                HttpContext.Current.Trace.Warn("strDateVal = " + strDateVal)

                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("codex")))
                lstRepeaterValue.Add(strDateVal)
                'lstRepeaterValue.Add(strDateVal)
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("ClientName1")) + " " + objFunction.ReturnString(dstData.Tables(0).Rows(i)("ClientName2")))

                'Booking Status
                Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("id"))
                Dim dstBookingStatusBookings As DataSet = (New clsDLBookingStatusBookings()).GetBookingStatusBookingsByBookingId(objBEBookingStatusBookings)
                Dim strBookingStatus As String = ""
                If objFunction.CheckDataSet(dstBookingStatusBookings) Then

                    Dim dstBookingStatusComplete As DataSet
                    Dim objBEBookingStatusComplete As clsBEBookingStatusComplete = New clsBEBookingStatusComplete
                    If objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("agent_id")) = 0 Then
                        objBEBookingStatusComplete.Easyways = True
                        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByEasyways(objBEBookingStatusComplete)
                    Else
                        objBEBookingStatusComplete.Agent = True
                        dstBookingStatusComplete = (New clsDLBookingStatusComplete()).GetBookingStatusCompleteByAgent(objBEBookingStatusComplete)
                    End If

                    If objFunction.CheckDataSet(dstBookingStatusComplete) Then
                        Dim dtData As DataTable = dstBookingStatusBookings.Tables(0)
                        dtData.DefaultView.RowFilter = "cat = 1"
                        dtData.DefaultView.Sort = "orderx DESC"
                        Dim dtDataTemp As DataTable = dtData.DefaultView.ToTable()
                        If objFunction.CheckDataTable(dtDataTemp) Then
                            'strBookingStatus = objFunction.ReturnString(dtDataTemp.Rows(0)("name"))

                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 1"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                Dim strNextBookingStatus As String = ""
                                For j = 0 To dtStatusTemp.Rows.Count - 1
                                    If objFunction.ReturnInteger(dtStatusTemp.Rows(j)("orderx")) = objFunction.ReturnInteger(dtDataTemp.Rows(0)("orderx")) Then
                                        If j = (dtStatusTemp.Rows.Count - 1) Then
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j)("name"))
                                        Else
                                            strNextBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(j + 1)("name"))
                                        End If
                                        Exit For
                                    End If
                                Next
                                strBookingStatus = strNextBookingStatus
                            Else
                            End If
                        Else
                            Dim dtStatus As DataTable = dstBookingStatusComplete.Tables(0)
                            dtStatus.DefaultView.RowFilter = "cat = 1"
                            Dim dtStatusTemp As DataTable = dtStatus.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtStatusTemp) Then
                                strBookingStatus = objFunction.ReturnString(dtStatusTemp.Rows(0)("name"))
                            End If
                        End If
                    End If

                End If

                lstRepeaterValue.Add(strBookingStatus)
                lstRepeaterValue.Add(objFunction.ReturnString(dstData.Tables(0).Rows(i)("AgentName")))
                lstRepeaterValue.Add("http://bookings.systems.easyways.co.uk/u/booking_info_baggage.aspx?bookingid=" + objFunction.ReturnString(dstData.Tables(0).Rows(i)("unique_id")))

                strRepeaterValue += ReadHtmlPage("25_Repeater.html", lstRepeaterValue)

            Next
        End If

        lstEmailValue.Add(strRepeaterValue)
        lstEmailValue.Add(strEWStaffName)

        Return ReadHtmlPage("25.html", lstEmailValue)

    End Function

    Public Function AgentInvoicedBookings_Email(ByVal strSupplierName As String, ByVal strDate As String, ByVal strSupplierContactName As String, ByVal bnlBookingCustomised As Boolean, ByVal strEWStaffName As String, ByVal intAgentId As Integer) As String
        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strSupplierName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSupplierContactName)

        Dim strMonthlyAgentInvoice As String
        'If bnlBookingCustomised = False Then
        '    strMonthlyAgentInvoice = "http://bookings.systems.easyways.co.uk/i/agent_fixed_invoice.aspx?agent_id=" + objFunction.ReturnString(intAgentId + 141275)
        'Else
        '    Dim intMonth As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
        '    Dim intYear As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
        '    strMonthlyAgentInvoice = "http://bookings.systems.easyways.co.uk/i/agent_customised_invoice.aspx?agent_id=" + objFunction.ReturnString(intAgentId + 141275) + "&datem=" + objFunction.ReturnString(intMonth) + "&datey=" + objFunction.ReturnString(intYear)
        'End If

        Dim intMonth As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Month)
        Dim intYear As Integer = objFunction.ReturnInteger(Convert.ToDateTime(FirstDayOfMonthFromDateTime(DateTime.Now.AddMonths(1))).Year)
        If bnlBookingCustomised = False Then
            strMonthlyAgentInvoice = "http://bookings.systems.easyways.co.uk/i/agent_fixed_invoice.aspx?agent_id=" + objFunction.ReturnString(intAgentId + 141275) + "&datem=" + objFunction.ReturnString(intMonth) + "&datey=" + objFunction.ReturnString(intYear)
        Else
            strMonthlyAgentInvoice = "http://bookings.systems.easyways.co.uk/i/agent_customised_invoice.aspx?agent_id=" + objFunction.ReturnString(intAgentId + 141275) + "&datem=" + objFunction.ReturnString(intMonth) + "&datey=" + objFunction.ReturnString(intYear)
        End If

        lstEmailValue.Add(strMonthlyAgentInvoice)
        lstEmailValue.Add(strEWStaffName)
        Return ReadHtmlPage("26.html", lstEmailValue)
    End Function

    Public Function PaymentsDueToAccommodationsEmail(ByVal strAccomName As String, ByVal strDate As String, ByVal strSupplierContactName As String, ByVal strRepeaterData As String, ByVal strAccomTotalCost As String, ByVal strSupplierNote As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strAccomName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSupplierContactName)
        lstEmailValue.Add(strRepeaterData)
        lstEmailValue.Add(strAccomTotalCost)
        lstEmailValue.Add(strSupplierNote)
        Return ReadHtmlPage("27.html", lstEmailValue)

    End Function

    Public Function AgentUKURL(ByVal strClientName As String, ByVal strDate As String, ByVal strNameWalk As String, ByVal strBookingId As String, ByVal strAgentContactName As String, ByVal strClientName2 As String, ByVal strTourPackURL As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strClientName)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strNameWalk)
        lstEmailValue.Add(strBookingId)
        lstEmailValue.Add(strAgentContactName)
        lstEmailValue.Add(strClientName2)
        lstEmailValue.Add(strTourPackURL)
        Return ReadHtmlPage("28.html", lstEmailValue)

    End Function

    Public Function FirstDayOfMonthFromDateTime(ByVal dateTime As DateTime) As DateTime
        Return New DateTime(dateTime.Year, dateTime.Month, 1)
    End Function

    Private Function daySuffix(ByVal day As Integer) As String
        If day > 0 Then
            If day Mod 10 = 1 And day Mod 100 <> 11 Then
                Return "st"
            ElseIf day Mod 10 = 2 And day Mod 100 <> 12 Then
                Return "nd"
            ElseIf day Mod 10 = 3 And day Mod 100 <> 13 Then
                Return "rd"
            Else
                Return "th"
            End If
        Else
            Return String.Empty
        End If
    End Function

    Public Function ReadHtmlPage(ByVal strFileName As String, ByVal lstEmailValue As List(Of String)) As String

        Try
            Dim file As String = HttpContext.Current.Server.MapPath("~/emails/" + strFileName)
            HttpContext.Current.Trace.Warn("File path = " + file)
            Dim sr As System.IO.StreamReader
            Dim strContents As String = ""
            If System.IO.File.Exists(file) Then
                sr = System.IO.File.OpenText(file)
                strContents += HttpContext.Current.Server.HtmlDecode(sr.ReadToEnd())
                sr.Close()

                Dim strTempContent As String = strContents

                Dim intCount As Integer = 0

                Dim lngPos1 As Long
                Dim lngPos2 As Long
                Dim strSubString As String

                lngPos1 = InStr(1, strContents, "<%")
                Do While lngPos1 > 0
                    lngPos2 = InStr(Convert.ToInt32(lngPos1 + 1), strContents, "%>")
                    If lngPos2 > 0 Then
                        strSubString = Mid$(strContents, lngPos1 + 1, lngPos2 - lngPos1 - 1)
                        HttpContext.Current.Trace.Warn("sSubString = " + strSubString)
                        'strTempContent = strTempContent.Replace(strSubString, "%" + Convert.ToString(intCount))
                        'strTempContent = strTempContent.Replace("<" + strSubString + "%>", Convert.ToString(intCount))
                        HttpContext.Current.Trace.Warn("intCount = " + objFunction.ReturnString(intCount))
                        If intCount < lstEmailValue.Count Then
                            strTempContent = strTempContent.Replace("<" + strSubString + "%>", Convert.ToString(lstEmailValue(intCount)))
                        End If
                        strTempContent = strTempContent.Replace("<" + strSubString + "%>", Convert.ToString(intCount))
                        intCount += 1
                    Else
                        Exit Do
                    End If
                    lngPos1 = InStr(Convert.ToInt32(lngPos2 + 1), strContents, "<%")
                Loop

                'Trace.Warn("strTempContent = " + strTempContent)

                strContents = strTempContent

            End If
            Return strContents
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

End Class
