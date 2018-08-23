Imports System.Data
Imports Easyway.BE
Imports Easyway.DL
Imports System.Drawing

Partial Class bookings_incomplete
    Inherits System.Web.UI.Page

    Protected objFunction As New clsCommon()

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

            Dim dstBookingIncomplete As DataSet = (New clsDLClientBooking()).GetBookingIncomplete(intCompanyId, strSearchByFromDate, strSearchByToDate)

            Dim dtGridData As DataTable = New DataTable
            Dim colBookingId As DataColumn = New DataColumn("BookingId", Type.GetType("System.String"))
            Dim colDateCreated As DataColumn = New DataColumn("DateCreated", Type.GetType("System.String"))
            Dim colClientName As DataColumn = New DataColumn("ClientName", Type.GetType("System.String"))
            Dim colBookingUniqueId As DataColumn = New DataColumn("BookingUniqueId", Type.GetType("System.String"))
            Dim colTourName As DataColumn = New DataColumn("TourName", Type.GetType("System.String"))
            dtGridData.Columns.Add(colBookingId)
            dtGridData.Columns.Add(colDateCreated)
            dtGridData.Columns.Add(colClientName)
            dtGridData.Columns.Add(colBookingUniqueId)
            dtGridData.Columns.Add(colTourName)

            If objFunction.CheckDataSet(dstBookingIncomplete) Then
                Dim dtData As DataTable = dstBookingIncomplete.Tables(0)

                If CHK_Accom.Checked = True Then
                    For i = 0 To dtData.Rows.Count - 1
                        Dim objBEAccomRouteStage As clsBEAccomRouteStage = New clsBEAccomRouteStage
                        objBEAccomRouteStage.BookingId = objFunction.ReturnInteger(dtData.Rows(i)("BookingId"))
                        Dim dstAccomRouteStage As DataSet = (New clsDLAccomRouteStage()).GetAccomRouteStageByBookingId(objBEAccomRouteStage, intCompanyId)
                        If objFunction.CheckDataSet(dstAccomRouteStage) Then
                            Dim dtData1 As DataTable = dstAccomRouteStage.Tables(0)
                            dtData1.DefaultView.RowFilter = "(accomodation_id = 0 OR accomodation_id IS NULL)"
                            Dim dtDataTemp As DataTable = dtData1.DefaultView.ToTable()
                            If objFunction.CheckDataTable(dtDataTemp) Then
                                Dim dr As DataRow = dtGridData.NewRow()
                                dr("BookingId") = objFunction.ReturnString(dtData.Rows(i)("BookingId"))
                                dr("DateCreated") = objFunction.ReturnString(dtData.Rows(i)("DateCreated"))
                                dr("ClientName") = objFunction.ReturnString(dtData.Rows(i)("ClientName"))
                                dr("BookingUniqueId") = objFunction.ReturnString(dtData.Rows(i)("BookingUniqueId"))
                                dr("TourName") = objFunction.ReturnString(dtData.Rows(i)("TourName"))
                                dtGridData.Rows.Add(dr)
                            End If
                        End If
                    Next
                End If

                If CHK_Baggage.Checked = True Then
                    For i = 0 To dtData.Rows.Count - 1
                        Dim objBEExtrasBaggageBooking As clsBEExtrasBaggageBooking = New clsBEExtrasBaggageBooking
                        objBEExtrasBaggageBooking.BookingId = objFunction.ReturnInteger(dtData.Rows(i)("BookingId"))
                        Dim dstExtrasBaggageBooking As DataSet = (New clsDLExtrasBaggageBooking()).GetExtrasBaggageBookingByBookingId(objBEExtrasBaggageBooking)
                        If Not objFunction.CheckDataSet(dstExtrasBaggageBooking) Then
                            Dim dr As DataRow = dtGridData.NewRow()
                            dr("BookingId") = objFunction.ReturnString(dtData.Rows(i)("BookingId"))
                            dr("DateCreated") = objFunction.ReturnString(dtData.Rows(i)("DateCreated"))
                            dr("ClientName") = objFunction.ReturnString(dtData.Rows(i)("ClientName"))
                            dr("BookingUniqueId") = objFunction.ReturnString(dtData.Rows(i)("BookingUniqueId"))
                            dr("TourName") = objFunction.ReturnString(dtData.Rows(i)("TourName"))
                            dtGridData.Rows.Add(dr)
                        End If
                    Next
                End If

                If CHK_Extras.Checked = True Then
                    For i = 0 To dtData.Rows.Count - 1
                        Dim objBEExtrasBooking As clsBEExtrasBooking = New clsBEExtrasBooking
                        objBEExtrasBooking.BookingId = objFunction.ReturnInteger(dtData.Rows(i)("BookingId"))
                        Dim dstExtrasBooking As DataSet = (New clsDLExtrasBooking()).GetExtrasBookingByBookingId(objBEExtrasBooking)
                        If Not objFunction.CheckDataSet(dstExtrasBooking) Then
                            Dim dr As DataRow = dtGridData.NewRow()
                            dr("BookingId") = objFunction.ReturnString(dtData.Rows(i)("BookingId"))
                            dr("DateCreated") = objFunction.ReturnString(dtData.Rows(i)("DateCreated"))
                            dr("ClientName") = objFunction.ReturnString(dtData.Rows(i)("ClientName"))
                            dr("BookingUniqueId") = objFunction.ReturnString(dtData.Rows(i)("BookingUniqueId"))
                            dr("TourName") = objFunction.ReturnString(dtData.Rows(i)("TourName"))
                            dtGridData.Rows.Add(dr)
                        End If
                    Next
                End If

            End If

            Trace.Warn("dtGridData Count = " + objFunction.ReturnString(dtGridData.Rows.Count))
            If objFunction.CheckDataTable(dtGridData) Then
                Dim dtDistinctData As DataTable = dtGridData.DefaultView.ToTable(True, "BookingId", "DateCreated", "ClientName", "BookingUniqueId", "TourName")
                Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))
                GRID_Bookings_Incomplete.DataSource = dtDistinctData
                GRID_Bookings_Incomplete.DataBind()
            Else
                GRID_Bookings_Incomplete.DataSource = dstBookingIncomplete
                GRID_Bookings_Incomplete.DataBind()
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Bookings_Incomplete
    ''' </summary>
    Protected Sub GRID_Bookings_Incomplete_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Bookings_Incomplete.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Bookings_Incomplete
    ''' </summary>
    Protected Sub GRID_Bookings_Incomplete_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Bookings_Incomplete.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingId") = objFunction.ReturnString(GRID_Bookings_Incomplete.DataKeys(e.NewSelectedIndex).Value)
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub BUT__Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Search.Click
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