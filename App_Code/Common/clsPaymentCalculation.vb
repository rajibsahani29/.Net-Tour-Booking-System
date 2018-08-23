Imports Microsoft.VisualBasic
Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Public Class clsPaymentCalculation

    Public Function GetTotalAmountPayable(ByVal intBookingId As Integer) As Double

        Dim objFunction As New clsCommon()
        Dim dblTotalAmountPayable As Double = 0

        HttpContext.Current.Trace.Warn("GetTotalAmountPayable() intBookingId = " + objFunction.ReturnString(intBookingId))

        Dim intCompanyId = objFunction.ReturnInteger(HttpContext.Current.Session("CompanyId"))

        'Get VoluntaryPayment Amount
        Dim objBEVoluntaryPayment As clsBEVoluntaryPayment = New clsBEVoluntaryPayment
        Dim objDLVoluntaryPayment As clsDLVoluntaryPayment = New clsDLVoluntaryPayment
        objBEVoluntaryPayment.BookingId = intBookingId
        Dim dstVoluntaryPayment As DataSet = objDLVoluntaryPayment.GetVoluntaryPaymentByBookingId(objBEVoluntaryPayment)
        If objFunction.CheckDataSet(dstVoluntaryPayment) Then
            dblTotalAmountPayable += objFunction.ReturnDouble(dstVoluntaryPayment.Tables(0).Rows(0)("amt"))
        End If
        HttpContext.Current.Trace.Warn("After VoluntaryPayment Amount = " + objFunction.ReturnString(dblTotalAmountPayable))

        'Get AdditionalExtras Amount
        Dim objBEAdditionalExtras As clsBEAdditionalExtras = New clsBEAdditionalExtras
        Dim objDLAdditionalExtras As clsDLAdditionalExtras = New clsDLAdditionalExtras
        objBEAdditionalExtras.BookingId = intBookingId
        'objBEAdditionalExtras.Invoicex = True
        Dim dstAdditionalExtras As DataSet = objDLAdditionalExtras.GetAdditionalExtrasByBookingId(objBEAdditionalExtras)
        'Dim dstAdditionalExtras As DataSet = objDLAdditionalExtras.GetAdditionalExtrasByBookingIdAndInvoicex(objBEAdditionalExtras)
        If objFunction.CheckDataSet(dstAdditionalExtras) Then
            For i = 0 To dstAdditionalExtras.Tables(0).Rows.Count - 1
                dblTotalAmountPayable += objFunction.ReturnDouble(dstAdditionalExtras.Tables(0).Rows(i)("cost_client"))
            Next
        End If
        HttpContext.Current.Trace.Warn("After AdditionalExtras Amount = " + objFunction.ReturnString(dblTotalAmountPayable))

        'Get Booking Detail
        Dim objBEBooking As clsBEBooking = New clsBEBooking
        Dim objDLBooking As clsDLBooking = New clsDLBooking
        objBEBooking.BookingId = intBookingId
        objBEBooking.CompanyId = intCompanyId
        Dim dstBooking As DataSet = objDLBooking.GetBookingById(objBEBooking)

        If objFunction.CheckDataSet(dstBooking) Then
            If Convert.ToBoolean(dstBooking.Tables(0).Rows(0)("customised")) = True Then

                'Get AccomStageDateBooking Amount
                Dim objBEAccomStageDateBooking As clsBEAccomStageDateBooking = New clsBEAccomStageDateBooking
                Dim objDLAccomStageDateBooking As clsDLAccomStageDateBooking = New clsDLAccomStageDateBooking
                objBEAccomStageDateBooking.BookingId = objFunction.ReturnInteger(intBookingId)
                Dim dstAccomStageDateBooking As DataSet = objDLAccomStageDateBooking.GetAccomStageDateBookingByBookingId(objBEAccomStageDateBooking)

                If objFunction.CheckDataSet(dstAccomStageDateBooking) Then
                    For i = 0 To dstAccomStageDateBooking.Tables(0).Rows.Count - 1
                        If objFunction.ReturnString(dstAccomStageDateBooking.Tables(0).Rows(i)("checkin")) <> "" And objFunction.ReturnString(dstAccomStageDateBooking.Tables(0).Rows(i)("checkout")) <> "" Then

                            Dim lngNoOfNight As Long = 0
                            lngNoOfNight = DateDiff(DateInterval.Day, Convert.ToDateTime(dstAccomStageDateBooking.Tables(0).Rows(i)("checkin")), Convert.ToDateTime(dstAccomStageDateBooking.Tables(0).Rows(i)("checkout")))

                            'HttpContext.Current.Trace.Warn("lngNoOfNight = " + objFunction.ReturnString(lngNoOfNight))

                            Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
                            Dim objDLAccomStageRoom As clsDLAccomStageRoom = New clsDLAccomStageRoom
                            objBEAccomStageRoom.AccomStageId = objFunction.ReturnInteger(dstAccomStageDateBooking.Tables(0).Rows(i)("accom_routestage_id"))
                            Dim dstAccomStageRoom As DataSet = objDLAccomStageRoom.GetAccomStageRoomByAccomStageId(objBEAccomStageRoom)

                            If objFunction.CheckDataSet(dstAccomStageRoom) Then
                                For j = 0 To dstAccomStageRoom.Tables(0).Rows.Count - 1
                                    HttpContext.Current.Trace.Warn("cost_client " + objFunction.ReturnString(dstAccomStageRoom.Tables(0).Rows(j)("cost_client")))
                                    HttpContext.Current.Trace.Warn("no_males " + objFunction.ReturnString(dstAccomStageRoom.Tables(0).Rows(j)("no_males")))
                                    'HttpContext.Current.Trace.Warn("lngNoOfNight " + objFunction.ReturnString(lngNoOfNight))
                                    dblTotalAmountPayable += (objFunction.ReturnDouble(dstAccomStageRoom.Tables(0).Rows(j)("cost_client")) + objFunction.ReturnDouble(dstAccomStageRoom.Tables(0).Rows(j)("total_cost_dogs"))) * lngNoOfNight
                                    'dblTotalAmountPayable += objFunction.ReturnDouble(dstAccomStageRoom.Tables(0).Rows(j)("cost_client")) * objFunction.ReturnDouble(dstAccomStageRoom.Tables(0).Rows(j)("no_males"))
                                    HttpContext.Current.Trace.Warn("dblTotalAmountPayable " + objFunction.ReturnString(dblTotalAmountPayable))
                                Next
                                'HttpContext.Current.Trace.Warn("total_cost_dogs " + objFunction.ReturnString(dstAccomStageRoom.Tables(0).Rows(0)("total_cost_dogs")))
                                'dblTotalAmountPayable += objFunction.ReturnDouble(dstAccomStageRoom.Tables(0).Rows(0)("total_cost_dogs"))
                            End If

                        End If
                    Next
                End If

                'Get AccomStageRoom Amount
                'Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
                'Dim objDLAccomStageRoom As clsDLAccomStageRoom = New clsDLAccomStageRoom
                'objBEAccomStageRoom.BookingId = intBookingId
                'Dim dstAccomStageRoom As DataSet = objDLAccomStageRoom.GetAccomStageRoomByBookingId(objBEAccomStageRoom)
                'If dstAccomStageRoom IsNot Nothing Then

                '    For index = 0 To dstAccomStageRoom.Tables(0).Rows.Count - 1

                '        Dim lngNoOfNight As Long = 0
                '        'Get AccomStageDateBooking Detail
                '        Dim objBEAccomStageDateBooking As clsBEAccomStageDateBooking = New clsBEAccomStageDateBooking
                '        Dim objDLAccomStageDateBooking As clsDLAccomStageDateBooking = New clsDLAccomStageDateBooking
                '        objBEAccomStageDateBooking.AccomRouteStageId = objFunction.ReturnInteger(dstAccomStageRoom.Tables(0).Rows(0)("id"))
                '        Dim dstAccomStageDateBooking As DataSet = objDLAccomStageDateBooking.GetAccomStageDateBookingByAccomRouteStageId(objBEAccomStageDateBooking)
                '        If dstAccomStageDateBooking IsNot Nothing Then
                '            lngNoOfNight = DateDiff(DateInterval.Day, Convert.ToDateTime(dstAccomStageDateBooking.Tables(0).Rows(0)("checkin")), Convert.ToDateTime(dstAccomStageDateBooking.Tables(0).Rows(0)("checkout")))
                '            HttpContext.Current.Trace.Warn("lngNoOfNight = " + objFunction.ReturnString(lngNoOfNight))
                '        End If

                '        dblTotalAmountPayable += (objFunction.ReturnDouble(dstAccomStageRoom.Tables(0).Rows(0)("cost_client")) + objFunction.ReturnDouble(dstAccomStageRoom.Tables(0).Rows(0)("total_cost_dogs"))) * lngNoOfNight
                '    Next

                'End If
                HttpContext.Current.Trace.Warn("After AccomStageRoom Amount = " + objFunction.ReturnString(dblTotalAmountPayable))

                'Get ExtrasBooking Amount
                Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
                Dim objDLExtrasBooking As clsDLExtrasBooking = New clsDLExtrasBooking
                objBEExtrasBooking.BookingId = intBookingId
                Dim dstExtrasBooking As DataSet = objDLExtrasBooking.GetExtrasBookingByBookingId(objBEExtrasBooking)
                If objFunction.CheckDataSet(dstExtrasBooking) Then
                    For i = 0 To dstExtrasBooking.Tables(0).Rows.Count - 1
                        dblTotalAmountPayable += objFunction.ReturnDouble(dstExtrasBooking.Tables(0).Rows(i)("cost_client"))
                    Next
                End If
                HttpContext.Current.Trace.Warn("After ExtrasBooking Amount = " + objFunction.ReturnString(dblTotalAmountPayable))

                'Get ExtrasBaggageBooking Amount
                Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
                Dim objDLExtrasBaggageBooking As clsDLExtrasBaggageBooking = New clsDLExtrasBaggageBooking
                objBEExtrasBaggageBooking.BookingId = intBookingId
                Dim dstExtrasBaggageBooking As DataSet = objDLExtrasBaggageBooking.GetExtrasBaggageBookingByBookingId(objBEExtrasBaggageBooking)
                If objFunction.CheckDataSet(dstExtrasBaggageBooking) Then
                    For i = 0 To dstExtrasBaggageBooking.Tables(0).Rows.Count - 1
                        dblTotalAmountPayable += objFunction.ReturnDouble(dstExtrasBaggageBooking.Tables(0).Rows(i)("cost_client"))
                    Next
                End If
                HttpContext.Current.Trace.Warn("After ExtrasBaggageBooking Amount = " + objFunction.ReturnString(dblTotalAmountPayable))

                'Get BookingFee Amount
                Dim objBEBookingFee As clsBEBookingFee = New clsBEBookingFee
                Dim objDLBookingFee As clsDLBookingFee = New clsDLBookingFee
                objBEBookingFee.TotalNum = 1
                objBEBookingFee.CompanyId = intCompanyId
                Dim dstBookingFee As DataSet = objDLBookingFee.GetBookingFeeByCompanyIdAndTotalNum(objBEBookingFee)
                If objFunction.CheckDataSet(dstBookingFee) Then
                    HttpContext.Current.Trace.Warn("fee_total = " + objFunction.ReturnString(dstBookingFee.Tables(0).Rows(0)("fee_total")))
                    HttpContext.Current.Trace.Warn("total_num = " + objFunction.ReturnString(dstBooking.Tables(0).Rows(0)("total_num")))
                    dblTotalAmountPayable += (objFunction.ReturnDouble(dstBookingFee.Tables(0).Rows(0)("fee_total")) * objFunction.ReturnInteger(dstBooking.Tables(0).Rows(0)("total_num")))
                End If
                HttpContext.Current.Trace.Warn("After BookingFee Amount = " + objFunction.ReturnString(dblTotalAmountPayable))
            Else
                'Get Route Amount
                Dim objBERoute As clsBERoute = New clsBERoute
                Dim objDLRoute As clsDLRoute = New clsDLRoute
                objBERoute.RouteId = objFunction.ReturnInteger(dstBooking.Tables(0).Rows(0)("route_id"))
                objBERoute.CompanyId = intCompanyId
                Dim dstRoute As DataSet = objDLRoute.GetRouteById(objBERoute)
                If objFunction.CheckDataSet(dstRoute) Then
                    'dblTotalAmountPayable += (objFunction.ReturnDouble(dstRoute.Tables(0).Rows(0)("cost_client")) * objFunction.ReturnInteger(dstBooking.Tables(0).Rows(0)("total_num")))
                    dblTotalAmountPayable += (objFunction.ReturnDouble(dstBooking.Tables(0).Rows(0)("route_cost_client")) * objFunction.ReturnInteger(dstBooking.Tables(0).Rows(0)("total_num")))
                    HttpContext.Current.Trace.Warn("After Route Amount = " + objFunction.ReturnString(dblTotalAmountPayable))
                    If objFunction.ReturnInteger(dstBooking.Tables(0).Rows(0)("total_num")) = 1 Then
                        dblTotalAmountPayable += objFunction.ReturnDouble(dstRoute.Tables(0).Rows(0)("single_supplement"))
                    End If
                    HttpContext.Current.Trace.Warn("After Route Amount in If = " + objFunction.ReturnString(dblTotalAmountPayable))
                End If

                'Get AccomStageDateBooking Amount
                Dim objBEAccomStageDateBooking As clsBEAccomStageDateBooking = New clsBEAccomStageDateBooking
                Dim objDLAccomStageDateBooking As clsDLAccomStageDateBooking = New clsDLAccomStageDateBooking
                objBEAccomStageDateBooking.BookingId = objFunction.ReturnInteger(intBookingId)
                Dim dstAccomStageDateBooking As DataSet = objDLAccomStageDateBooking.GetAccomStageDateBookingByBookingId(objBEAccomStageDateBooking)

                If objFunction.CheckDataSet(dstAccomStageDateBooking) Then
                    For i = 0 To dstAccomStageDateBooking.Tables(0).Rows.Count - 1
                        If objFunction.ReturnString(dstAccomStageDateBooking.Tables(0).Rows(i)("checkin")) <> "" And objFunction.ReturnString(dstAccomStageDateBooking.Tables(0).Rows(i)("checkout")) <> "" Then

                            Dim lngNoOfNight As Long = 0
                            lngNoOfNight = DateDiff(DateInterval.Day, Convert.ToDateTime(dstAccomStageDateBooking.Tables(0).Rows(i)("checkin")), Convert.ToDateTime(dstAccomStageDateBooking.Tables(0).Rows(i)("checkout")))

                            HttpContext.Current.Trace.Warn("lngNoOfNight = " + objFunction.ReturnString(lngNoOfNight))

                            Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
                            Dim objDLAccomStageRoom As clsDLAccomStageRoom = New clsDLAccomStageRoom
                            objBEAccomStageRoom.AccomStageId = objFunction.ReturnInteger(dstAccomStageDateBooking.Tables(0).Rows(i)("accom_routestage_id"))
                            Dim dstAccomStageRoom As DataSet = objDLAccomStageRoom.GetAccomStageRoomByAccomStageId(objBEAccomStageRoom)

                            If objFunction.CheckDataSet(dstAccomStageRoom) Then
                                For j = 0 To dstAccomStageRoom.Tables(0).Rows.Count - 1
                                    HttpContext.Current.Trace.Warn("total_cost_dogs " + objFunction.ReturnString(dstAccomStageRoom.Tables(0).Rows(j)("total_cost_dogs")))
                                    HttpContext.Current.Trace.Warn("lngNoOfNight " + objFunction.ReturnString(lngNoOfNight))
                                    dblTotalAmountPayable += objFunction.ReturnDouble(dstAccomStageRoom.Tables(0).Rows(j)("total_cost_dogs")) * lngNoOfNight
                                    HttpContext.Current.Trace.Warn("dblTotalAmountPayable " + objFunction.ReturnString(dblTotalAmountPayable))
                                Next
                            End If

                        End If
                    Next
                End If
                HttpContext.Current.Trace.Warn("After AccomStageRoom Amount = " + objFunction.ReturnString(dblTotalAmountPayable))

                'Get ExtrasBooking Amount
                Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
                Dim objDLExtrasBooking As clsDLExtrasBooking = New clsDLExtrasBooking
                objBEExtrasBooking.BookingId = intBookingId
                Dim dstExtrasBooking As DataSet = objDLExtrasBooking.GetExtrasBookingByBookingId(objBEExtrasBooking)
                If objFunction.CheckDataSet(dstExtrasBooking) Then
                    For i = 0 To dstExtrasBooking.Tables(0).Rows.Count - 1
                        dblTotalAmountPayable += objFunction.ReturnDouble(dstExtrasBooking.Tables(0).Rows(i)("cost_client"))
                    Next
                End If
                HttpContext.Current.Trace.Warn("After ExtrasBooking Amount = " + objFunction.ReturnString(dblTotalAmountPayable))

            End If
        End If

        HttpContext.Current.Trace.Warn("Final TotalAmountPayable Amount = " + objFunction.ReturnString(dblTotalAmountPayable))
        Return dblTotalAmountPayable

    End Function

    Public Function GetTotalBalanceRemaining(ByVal dblTotalAmountPayable As Double, ByVal intBookingId As Integer) As Double

        Dim objFunction As New clsCommon()
        Dim dblTotalBalanceRemaining As Double = 0

        HttpContext.Current.Trace.Warn("GetTotalBalanceRemaining() intBookingId = " + objFunction.ReturnString(intBookingId))

        Dim intCompanyId = objFunction.ReturnInteger(HttpContext.Current.Session("CompanyId"))

        'Get BookingPayments Amount
        Dim objBEBookingPayments As clsBEBookingPayments = New clsBEBookingPayments
        Dim objDLBookingPayments As clsDLBookingPayments = New clsDLBookingPayments
        objBEBookingPayments.BookingId = intBookingId
        Dim dstBookingPayments As DataSet = objDLBookingPayments.GetBookingPaymentsByBookingId(objBEBookingPayments)
        If objFunction.CheckDataSet(dstBookingPayments) Then
            For i = 0 To dstBookingPayments.Tables(0).Rows.Count - 1
                HttpContext.Current.Trace.Warn("amount_paid = " + objFunction.ReturnString(dstBookingPayments.Tables(0).Rows(i)("amount_paid")))
                dblTotalBalanceRemaining += objFunction.ReturnDouble(dstBookingPayments.Tables(0).Rows(i)("amount_paid"))
            Next
        End If

        HttpContext.Current.Trace.Warn("Final TotalBalanceRemaining Amount = " + objFunction.ReturnString(dblTotalAmountPayable - dblTotalBalanceRemaining))
        Return (dblTotalAmountPayable - dblTotalBalanceRemaining)

    End Function

    Public Function GetCostToEasyway(ByVal intBookingId As Integer) As Double

        Dim objFunction As New clsCommon()
        Dim dblTotalCostToEasyway As Double = 0

        HttpContext.Current.Trace.Warn("GetCostToEasyway() intBookingId = " + objFunction.ReturnString(intBookingId))

        Dim intCompanyId = objFunction.ReturnInteger(HttpContext.Current.Session("CompanyId"))

        'Get AdditionalExtras Amount
        Dim objBEAdditionalExtras As clsBEAdditionalExtras = New clsBEAdditionalExtras
        Dim objDLAdditionalExtras As clsDLAdditionalExtras = New clsDLAdditionalExtras
        objBEAdditionalExtras.BookingId = intBookingId
        Dim dstAdditionalExtras As DataSet = objDLAdditionalExtras.GetAdditionalExtrasByBookingId(objBEAdditionalExtras)
        If objFunction.CheckDataSet(dstAdditionalExtras) Then
            For i = 0 To dstAdditionalExtras.Tables(0).Rows.Count - 1
                dblTotalCostToEasyway += objFunction.ReturnDouble(dstAdditionalExtras.Tables(0).Rows(i)("cost_easyways"))
            Next
        End If
        HttpContext.Current.Trace.Warn("After AdditionalExtras Amount = " + objFunction.ReturnString(dblTotalCostToEasyway))

        'Get AccomStageDateBooking Amount
        Dim objBEAccomStageDateBooking As clsBEAccomStageDateBooking = New clsBEAccomStageDateBooking
        Dim objDLAccomStageDateBooking As clsDLAccomStageDateBooking = New clsDLAccomStageDateBooking
        objBEAccomStageDateBooking.BookingId = objFunction.ReturnInteger(intBookingId)
        Dim dstAccomStageDateBooking As DataSet = objDLAccomStageDateBooking.GetAccomStageDateBookingByBookingId(objBEAccomStageDateBooking)

        If objFunction.CheckDataSet(dstAccomStageDateBooking) Then
            For i = 0 To dstAccomStageDateBooking.Tables(0).Rows.Count - 1
                If objFunction.ReturnString(dstAccomStageDateBooking.Tables(0).Rows(i)("checkin")) <> "" And objFunction.ReturnString(dstAccomStageDateBooking.Tables(0).Rows(i)("checkout")) <> "" Then

                    Dim lngNoOfNight As Long = 0
                    lngNoOfNight = DateDiff(DateInterval.Day, Convert.ToDateTime(dstAccomStageDateBooking.Tables(0).Rows(i)("checkin")), Convert.ToDateTime(dstAccomStageDateBooking.Tables(0).Rows(i)("checkout")))

                    HttpContext.Current.Trace.Warn("lngNoOfNight = " + objFunction.ReturnString(lngNoOfNight))

                    Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
                    Dim objDLAccomStageRoom As clsDLAccomStageRoom = New clsDLAccomStageRoom
                    objBEAccomStageRoom.AccomStageId = objFunction.ReturnInteger(dstAccomStageDateBooking.Tables(0).Rows(i)("accom_routestage_id"))
                    Dim dstAccomStageRoom As DataSet = objDLAccomStageRoom.GetAccomStageRoomByAccomStageId(objBEAccomStageRoom)

                    If objFunction.CheckDataSet(dstAccomStageRoom) Then
                        For j = 0 To dstAccomStageRoom.Tables(0).Rows.Count - 1
                            dblTotalCostToEasyway += (objFunction.ReturnDouble(dstAccomStageRoom.Tables(0).Rows(j)("cost_easyways")) + objFunction.ReturnDouble(dstAccomStageRoom.Tables(0).Rows(j)("total_cost_dogs"))) * lngNoOfNight
                        Next
                    End If

                End If
            Next
        End If
        HttpContext.Current.Trace.Warn("After AccomStageRoom Amount = " + objFunction.ReturnString(dblTotalCostToEasyway))

        'Get ExtrasBooking Amount
        Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
        Dim objDLExtrasBooking As clsDLExtrasBooking = New clsDLExtrasBooking
        objBEExtrasBooking.BookingId = intBookingId
        Dim dstExtrasBooking As DataSet = objDLExtrasBooking.GetExtrasBookingByBookingId(objBEExtrasBooking)
        If objFunction.CheckDataSet(dstExtrasBooking) Then
            For i = 0 To dstExtrasBooking.Tables(0).Rows.Count - 1
                dblTotalCostToEasyway += objFunction.ReturnDouble(dstExtrasBooking.Tables(0).Rows(i)("cost_easyways"))
            Next
        End If
        HttpContext.Current.Trace.Warn("After ExtrasBooking Amount = " + objFunction.ReturnString(dblTotalCostToEasyway))

        'Get ExtrasBaggageBooking Amount
        Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
        Dim objDLExtrasBaggageBooking As clsDLExtrasBaggageBooking = New clsDLExtrasBaggageBooking
        objBEExtrasBaggageBooking.BookingId = intBookingId
        Dim dstExtrasBaggageBooking As DataSet = objDLExtrasBaggageBooking.GetExtrasBaggageBookingByBookingId(objBEExtrasBaggageBooking)
        If objFunction.CheckDataSet(dstExtrasBaggageBooking) Then
            For i = 0 To dstExtrasBaggageBooking.Tables(0).Rows.Count - 1
                dblTotalCostToEasyway += objFunction.ReturnDouble(dstExtrasBaggageBooking.Tables(0).Rows(i)("cost_easyways"))
            Next
        End If
        HttpContext.Current.Trace.Warn("After ExtrasBaggageBooking Amount = " + objFunction.ReturnString(dblTotalCostToEasyway))

        HttpContext.Current.Trace.Warn("Final TotalAmountPayable Amount = " + objFunction.ReturnString(dblTotalCostToEasyway))
        Return dblTotalCostToEasyway

    End Function

End Class
