Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_enquiry
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

                Dim dstAgent As DataSet = (New clsDLAgent()).GetAgentDetailFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Agent, dstAgent)
                DROP_Agent.Items.Insert(0, New ListItem("Easyways", "0"))

                'Session("RouteId") = Nothing
                'Session("TravelDate") = Nothing
                If objFunction.ReturnInteger(Session("RouteId")) > 0 And objFunction.ReturnString(Session("TravelDate")) <> "" Then
                    DROP_Route.SelectedValue = objFunction.ReturnString(Session("RouteId"))
                End If

                If objFunction.ReturnString(Session("ClientId")) = "" Then
                    BUT_Add_Link_Client.Visible = True
                    BUT_Remove_Client.Visible = False
                    hdnClientName.Value = ""
                Else
                    BUT_Add_Link_Client.Visible = False
                    BUT_Remove_Client.Visible = True

                    LABEL_Client_Name.Text = objFunction.ReturnString(Session("ClientFirstName")) + " " + objFunction.ReturnString(Session("ClientSurname"))
                    hdnClientName.Value = LABEL_Client_Name.Text
                End If

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to link client
    ''' </summary>
    Protected Sub BUT_Add_Link_Client_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Link_Client.Click

        Try
            Session("RequestPage") = "BookingEnquiry"
            Response.Redirect("bookings_check_client.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to remove client
    ''' </summary>
    Protected Sub BUT_Remove_Client_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Remove_Client.Click

        Try
            Session("ClientId") = Nothing
            Session("ClientFirstName") = Nothing
            Session("ClientSurname") = Nothing
            Response.Redirect("Bookings_enquiry.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add booking enquiry
    ''' </summary>
    Protected Sub BUT_Create_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Create_Booking.Click

        Try

            'If IsNumeric(TB_Total_Number_In_Party.Text) Then
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEBooking As clsBEBooking = New clsBEBooking
            Dim objDLBooking As clsDLBooking = New clsDLBooking

            objBEBooking.RouteId = objFunction.ReturnInteger(DROP_Route.SelectedItem.Value)
            objBEBooking.RouteCostClient = 0
            objBEBooking.RouteCostEasyways = 0

            Dim objBERoute As clsBERoute = New clsBERoute
            objBERoute.RouteId = objFunction.ReturnInteger(DROP_Route.SelectedItem.Value)
            objBERoute.CompanyId = intCompanyId
            Dim dstRoute As DataSet = (New clsDLRoute()).GetRouteById(objBERoute)
            If objFunction.CheckDataSet(dstRoute) Then
                objBEBooking.RouteCostClient = objFunction.ReturnDouble(dstRoute.Tables(0).Rows(0)("cost_client"))
                objBEBooking.RouteCostEasyways = objFunction.ReturnDouble(dstRoute.Tables(0).Rows(0)("cost_easyways"))
            End If

            objBEBooking.Active = True
            If CHK_Customised_Tour.Checked = True Then
                objBEBooking.Customised = True
            Else
                objBEBooking.Customised = False
            End If
            objBEBooking.CompanyId = intCompanyId
            objBEBooking.NoMales = objFunction.ReturnInteger(TB_Number_of_Males.Text)
            objBEBooking.NoFemales = objFunction.ReturnInteger(TB_Number_of_Females.Text)
            objBEBooking.NoOther = objFunction.ReturnInteger(TB_Number_of_Unspecified.Text)
            Dim intTotalNumber As Integer = objBEBooking.NoMales + objBEBooking.NoFemales + objBEBooking.NoOther
            objBEBooking.TotalNumber = intTotalNumber
            objBEBooking.Ensuite = DROP_Ensuite.SelectedItem.Value
            If CHK_Dog_Friendly.Checked = True Then
                objBEBooking.DogFriendly = True
            Else
                objBEBooking.DogFriendly = False
            End If

            Dim intBookingId As Integer = objDLBooking.AddBooking(objBEBooking)

            If intBookingId > 0 Then

                'Add Voluntary_Payment
                Dim objBEVoluntaryPayment As clsBEVoluntaryPayment = New clsBEVoluntaryPayment
                Dim objDLVoluntaryPayment As clsDLVoluntaryPayment = New clsDLVoluntaryPayment
                objBEVoluntaryPayment.BookingId = intBookingId
                'objBEVoluntaryPayment.Amount = objFunction.ReturnDouble(intTotalNumber * 5)
                objBEVoluntaryPayment.Amount = 0
                objBEVoluntaryPayment.Paid = False
                objDLVoluntaryPayment.AddVoluntaryPayment(objBEVoluntaryPayment)

                'Add Booking_Status_Bookings
                Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                objBEBookingStatusBookings.BookingId = intBookingId
                objBEBookingStatusBookings.BSCId = 1
                objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)

                If TB_Room_Preference_Info.Text <> "" Then
                    Dim objBEClientBookingNotes As clsBEClientBookingNotes = New clsBEClientBookingNotes
                    Dim objDLClientBookingNotes As clsDLClientBookingNotes = New clsDLClientBookingNotes

                    objBEClientBookingNotes.Notes = TB_Room_Preference_Info.Text
                    objBEClientBookingNotes.BookingId = intBookingId
                    objDLClientBookingNotes.AddClientBookingNotes(objBEClientBookingNotes)
                End If

                objBEBooking.BookingId = intBookingId

                Dim strFirstNameChar As String = objFunction.ReturnString(Session("ClientFirstName")).Chars(0)
                Dim strSurnameChar As String = objFunction.ReturnString(Session("ClientSurname")).Chars(0)
                Dim dtDate As DateTime = DateTime.Now
                Dim strDD As String = dtDate.Day.ToString("#00") 'objFunction.ReturnString(dtDate.Day).PadLeft(2, "0"c)
                Dim strMM As String = dtDate.Month.ToString("#00")
                Dim strYY As String = objFunction.ReturnString(dtDate.Year).Substring(2, 2)

                'objBEBooking.UniqueId = strFirstNameChar + strSurnameChar + strDD + strMM + strYY + objFunction.ReturnString(intBookingId)
                objBEBooking.UniqueId = strFirstNameChar + strSurnameChar + objFunction.ReturnString(intBookingId)
                objDLBooking.UpdateBookingUniqueId(objBEBooking)

                Trace.Warn("objBEBooking.UniqueId = " + objBEBooking.UniqueId.ToString())

                Dim objBEClientBooking As clsBEClientBooking = New clsBEClientBooking
                Dim objDLClientBooking As clsDLClientBooking = New clsDLClientBooking

                objBEClientBooking.ClientId = objFunction.ReturnInteger(Session("ClientId"))
                objBEClientBooking.BookingId = intBookingId
                objBEClientBooking.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))
                objBEClientBooking.AgentId = objFunction.ReturnInteger(DROP_Agent.SelectedItem.Value)
                Dim dstBookingStage As DataSet = (New clsDLBookingStatus).GetBookingStatusIdByName("Enquiry_New")
                objBEClientBooking.BookingStageId = (If(dstBookingStage.Tables(0).Rows.Count > 0, objFunction.ReturnInteger(dstBookingStage.Tables(0).Rows(0)("id")), 0))
                objBEClientBooking.CarParkingRequire = False
                objBEClientBooking.UrlVisited = False
                objBEClientBooking.AgentPaid = False
                objBEClientBooking.PriceBand = objFunction.ReturnString(DROP_Accom_Band.SelectedItem.Value)

                objDLClientBooking.AddClientBooking(objBEClientBooking)

                'Dim objBERouteStage As clsBERouteStage = New clsBERouteStage
                'Dim objDLRouteStage As clsDLRouteStage = New clsDLRouteStage
                Dim dstRouteStage As DataSet = (New clsDLRouteStage).GetRouteStageByRouteId(objFunction.ReturnInteger(DROP_Route.SelectedItem.Value), intCompanyId)

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

                            If Session("TravelDate") <> "" Then
                                Dim dt As DateTime = Convert.ToDateTime(Session("TravelDate"))
                                'Trace.Warn("dt = " + dt.ToString())
                                'Trace.Warn("in = " + String.Format("{0:dd-MM-yyyy}", dt))

                                objBEAccomStageDateBooking.CheckInDate = Convert.ToDateTime(Session("TravelDate")).AddDays((objBEAccomRouteStage.Sequence - 1))
                                objBEAccomStageDateBooking.CheckOutDate = Convert.ToDateTime(Session("TravelDate")).AddDays((objBEAccomRouteStage.Sequence - 1) + 1)
                            Else
                                objBEAccomStageDateBooking.CheckInDate = DateTime.MinValue
                                objBEAccomStageDateBooking.CheckOutDate = DateTime.MinValue
                            End If

                            objBEAccomStageDateBooking.FeeTotal = 0
                            objBEAccomStageDateBooking.ExtraActualCost = 0
                            objBEAccomStageDateBooking.AccomActualCost = 0
                            objBEAccomStageDateBooking.AccomRouteStageId = intAccomRouteStageId

                            objDLAccomStageDateBooking.AddAccomStageDateBooking(objBEAccomStageDateBooking)

                        End If

                    Next

                End If

                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = "New Enquiry created for " + objFunction.ReturnString(Session("ClientFirstName")) + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "New booking enquiry has been added"

            End If
            Session("ClientId") = Nothing
            Session("ClientFirstName") = Nothing
            Session("ClientSurname") = Nothing

            Session("BookingId") = objFunction.ReturnString(intBookingId)
            Response.Redirect("bookings_view.aspx")
            'Else
            'Session("feedback_call") = "2"
            'Session("error_msg") = "Please enter numerical value in total number. No records has been added"
            'End If
            Response.Redirect("bookings_enquiry.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub
End Class





