Imports System.Data
Imports Easyway.BE
Imports Easyway.DL
Imports System.Drawing

Partial Class bookings_search
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

                'Session("RouteId") = Nothing
                'Session("TravelDate") = Nothing
                If objFunction.ReturnString(Session("SearchByName")) <> "" Then
                    TB_Search_Name.Text = objFunction.ReturnString(Session("SearchByName"))
                End If
                If objFunction.ReturnString(Session("SearchByBookingRef")) <> "" Then
                    TB_Search_Booking.Text = objFunction.ReturnString(Session("SearchByBookingRef"))
                End If
                If objFunction.ReturnString(Session("SearchByDate")) <> "" Then
                    'Trace.Warn("date = " + Convert.ToDateTime(Session("SearchByDate")).ToString())
                    Dim dt As DateTime = Convert.ToDateTime(Session("SearchByDate"))
                    'Trace.Warn("date new = " + dt.ToString("yyyy-MM-dd"))
                    TB_Search_Date.Text = dt.ToString("yyyy-MM-dd")
                End If

                If objFunction.ReturnString(Session("SearchByName")) <> "" Or objFunction.ReturnString(Session("SearchByBookingRef")) <> "" Or objFunction.ReturnString(Session("SearchByDate")) <> "" Then
                    BindGridview()
                End If

                Session("SearchByName") = Nothing
                Session("SearchByBookingRef") = Nothing
                Session("SearchByDate") = Nothing

                If objFunction.ReturnString(Session("BackToSearch")) <> "" And objFunction.ReturnString(Session("BackToSearch")) = "Press" Then
                    TB_Search_Name.Text = objFunction.ReturnString(Session("BackSearchByName"))
                    TB_Search_Surname.Text = objFunction.ReturnString(Session("BackSearchBySurname"))
                    TB_Search_Booking.Text = objFunction.ReturnString(Session("BackSearchByBookingRef"))
                    TB_Search_Postcode.Text = objFunction.ReturnString(Session("BackSearchByPostcode"))
                    TB_Search_Email.Text = objFunction.ReturnString(Session("BackSearchByEmail"))
                    TB_Search_Date.Text = objFunction.ReturnString(Session("BackSearchByDate"))

                    BindGridview()
                Else
                    Session("BackSearchByName") = Nothing
                    Session("BackSearchBySurname") = Nothing
                    Session("BackSearchByBookingRef") = Nothing
                    Session("BackSearchByPostcode") = Nothing
                    Session("BackSearchByEmail") = Nothing
                    Session("BackSearchByDate") = Nothing
                    Session("BackToSearch") = Nothing
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
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim strSearchByName As String = (If(TB_Search_Name.Text <> "", TB_Search_Name.Text, ""))
            Dim strSearchBySurname As String = (If(TB_Search_Surname.Text <> "", TB_Search_Surname.Text, ""))
            Dim strSearchByBookingRef As String = (If(TB_Search_Booking.Text <> "", TB_Search_Booking.Text, ""))
            Dim strSearchByPostcode As String = (If(TB_Search_Postcode.Text <> "", TB_Search_Postcode.Text, ""))
            Dim strSearchByEmail As String = (If(TB_Search_Email.Text <> "", TB_Search_Email.Text, ""))

            Dim strSearchByDate As String = ""
            If TB_Search_Date.Text <> "" Then
                Dim dtSearchByDate As DateTime = (If(TB_Search_Date.Text <> "", Convert.ToDateTime(TB_Search_Date.Text), DateTime.MinValue))
                'Trace.Warn("dtSearchByDate = " + dtSearchByDate.ToString("dd-MM-yyyy"))
                strSearchByDate = dtSearchByDate.ToString("dd-MM-yyyy")
            End If

            Dim dstBookingDetail As DataSet = (New clsDLBooking()).GetBookingDetail(intCompanyId, strSearchByName, strSearchBySurname, strSearchByBookingRef, strSearchByPostcode, strSearchByEmail, strSearchByDate)
            If dstBookingDetail Is Nothing Then
                Session("feedback_call") = "2"
                Session("error_msg") = "Warning - no record found on the system"
            End If

            GridView1.DataSource = dstBookingDetail
            GridView1.DataBind()

            For i = 0 To GridView1.Rows.Count - 1
                Dim intCurrentIndex As Integer = (GridView1.PageSize * GridView1.PageIndex) + i
                Dim gRow As GridViewRow = GridView1.Rows(i)
                Dim lblTourName As Label = DirectCast(gRow.FindControl("LABEL_TourName"), Label)
                If Convert.IsDBNull(dstBookingDetail.Tables(0).Rows(intCurrentIndex)("cancelled")) = False Then
                    If Convert.ToBoolean(dstBookingDetail.Tables(0).Rows(intCurrentIndex)("cancelled")) = True Then
                        lblTourName.Text = "Cancelled"
                        gRow.BackColor = Color.MistyRose
                    Else
                        lblTourName.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(intCurrentIndex)("TourName"))
                    End If
                Else
                    lblTourName.Text = objFunction.ReturnString(dstBookingDetail.Tables(0).Rows(intCurrentIndex)("TourName"))
                End If
            Next

            Trace.Warn("Session = " + Session("feedback_call"))
            If Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 1 Then
                Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
            ElseIf Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 2 Then
                Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
            End If
            Session("feedback_call") = "0"
            Session("error_msg") = ""

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
            'Trace.Warn("Value = " + objFunction.ReturnString(GridView1.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingId") = objFunction.ReturnString(GridView1.DataKeys(e.NewSelectedIndex).Value)
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Click event of the button
    ''' </summary>
    Protected Sub BUT_Search_Name_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Search_Name.Click

        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Click event of the button
    ''' </summary>
    Protected Sub BUT__Search_Booking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Search_Booking.Click

        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Click event of the button
    ''' </summary>
    Protected Sub BUT__Search_Date_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Search_Date.Click

        Try
            Session("BackSearchByName") = objFunction.ReturnString(TB_Search_Name.Text)
            Session("BackSearchBySurname") = objFunction.ReturnString(TB_Search_Surname.Text)
            Session("BackSearchByBookingRef") = objFunction.ReturnString(TB_Search_Booking.Text)
            Session("BackSearchByPostcode") = objFunction.ReturnString(TB_Search_Postcode.Text)
            Session("BackSearchByEmail") = objFunction.ReturnString(TB_Search_Email.Text)
            Session("BackSearchByDate") = objFunction.ReturnString(TB_Search_Date.Text)
            Session("BackToSearch") = Nothing
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