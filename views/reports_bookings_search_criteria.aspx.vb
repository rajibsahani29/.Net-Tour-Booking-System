Imports System.Data
Imports Easyway.BE
Imports Easyway.DL
'Imports Microsoft.Reporting.WebForms
Imports System.Data.SqlClient

Partial Class views_reports_bookings_search_criteria
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

                Dim dstBookingStatus As DataSet = (New clsDLBookingStatus()).GetBookingStatusFillInDD()
                objFunction.FillDropDownByDataSet(DROP_Booking_Status, dstBookingStatus)
                DROP_Booking_Status.Items.Insert(0, New ListItem("Select Booking Status", "0"))

                Dim dstRoute As DataSet = (New clsDLRoute()).GetRouteFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Route, dstRoute)
                DROP_Route.Items.Insert(0, New ListItem("Select Route", "0"))

                Dim dstAgent As DataSet = (New clsDLAgent()).GetAgentDetailFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Agent, dstAgent)
                DROP_Agent.Items.Insert(0, New ListItem("Select Agent", "0"))

                Dim dstCountry As DataSet = (New clsDLCountry()).GetCountryFillInDD()
                objFunction.FillDropDownByDataSet(DROP_Country, dstCountry)
                DROP_Country.Items.Insert(0, New ListItem("Select Country", "0"))

                'BindGridview()

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

            Dim strSearchByStatus As String = (If(objFunction.ReturnString(DROP_Booking_Status.SelectedItem.Value) <> "0", DROP_Booking_Status.SelectedItem.Value, ""))
            Dim strSearchByRoute As String = (If(objFunction.ReturnString(DROP_Route.SelectedItem.Value) <> "0", DROP_Route.SelectedItem.Value, ""))
            Dim strSearchByAgent As String = (If(objFunction.ReturnString(DROP_Agent.SelectedItem.Value) <> "0", DROP_Agent.SelectedItem.Value, ""))
            Dim strSearchByNationality As String = (If(objFunction.ReturnString(DROP_Country.SelectedItem.Value) <> "0", DROP_Country.SelectedItem.Value, ""))
            Dim dtTodayDate As DateTime = DateTime.Now
            Dim strTodayDate As String = dtTodayDate.ToString("MM-dd-yyyy")

            Dim strSearchByDate As String = ""
            If TB_Start_Date.Text <> "" Then
                Dim dtSearchByDate As DateTime = (If(TB_Start_Date.Text <> "", Convert.ToDateTime(TB_Start_Date.Text), DateTime.MinValue))
                'Trace.Warn("dtSearchByDate = " + dtSearchByDate.ToString("dd-MM-yyyy"))
                strSearchByDate = dtSearchByDate.ToString("MM-dd-yyyy")
            End If

            Dim dstReportBookingSearchCriteria As DataSet = (New clsDLBookingReport()).GetReportBookingSearchCriteria(intCompanyId, strSearchByStatus, strSearchByRoute, strSearchByAgent, strSearchByNationality, strSearchByDate, strTodayDate)
            GRID_Bookings_Search_Criteria.DataSource = dstReportBookingSearchCriteria
            GRID_Bookings_Search_Criteria.DataBind()

            'Dim parameter1 As ReportParameter = New ReportParameter(1)
            'If objFunction.ReturnInteger(DROP_Country.SelectedItem.Value) > 0 Then
            '    parameter1 = New ReportParameter("CountryName_Visible", "True")
            'Else
            '    parameter1 = New ReportParameter("CountryName_Visible", "False")
            'End If
            'ReportViewer1.LocalReport.SetParameters(parameter1)

            'Dim parameter2 As ReportParameter = New ReportParameter(1)
            'If objFunction.ReturnInteger(DROP_Booking_Status.SelectedItem.Value) > 0 Then
            '    parameter2 = New ReportParameter("BookingStatus_Visible", "True")
            'Else
            '    parameter2 = New ReportParameter("BookingStatus_Visible", "False")
            'End If
            'ReportViewer1.LocalReport.SetParameters(parameter2)

            'Dim datasource As ReportDataSource = New ReportDataSource("DataSet1", dstReportBookingSearchCriteria.Tables(0))
            'ReportViewer1.LocalReport.DataSources.Clear()
            'ReportViewer1.LocalReport.DataSources.Add(datasource)
            'ReportViewer1.DataBind()
            'ReportViewer1.LocalReport.Refresh()

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Bookings_Search_Criteria
    ''' </summary>
    Protected Sub GRID_Bookings_Search_Criteria_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Bookings_Search_Criteria.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Bookings_Search_Criteria
    ''' </summary>
    Protected Sub GRID_Bookings_Search_Criteria_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Bookings_Search_Criteria.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingId") = objFunction.ReturnString(GRID_Bookings_Search_Criteria.DataKeys(e.NewSelectedIndex).Value)
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub DROP_Booking_Status_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Booking_Status.SelectedIndexChanged
        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub DROP_Route_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Route.SelectedIndexChanged
        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub DROP_Agent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Agent.SelectedIndexChanged
        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub DROP_Country_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Country.SelectedIndexChanged
        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub TB_Start_Date_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Start_Date.TextChanged
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

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetValue(ByVal value As Object) As String
        Try
            If Convert.ToBoolean(value) = True Then
                Return "Yes"
            Else
                Return "No"
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return ""
    End Function

End Class
