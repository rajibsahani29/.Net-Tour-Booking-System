Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_bookings_indepth_search
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

            Dim strSearchByDateCreated As String = ""
            If TB_Date_Created.Text <> "" Then
                Dim dt As DateTime = (If(TB_Date_Created.Text <> "", Convert.ToDateTime(TB_Date_Created.Text), DateTime.MinValue))
                strSearchByDateCreated = dt.ToString("MM-dd-yyyy")
            End If

            Dim strSearchByPaymentDate As String = ""
            If TB_Last_Payment_Date.Text <> "" Then
                Dim dt As DateTime = (If(TB_Last_Payment_Date.Text <> "", Convert.ToDateTime(TB_Last_Payment_Date.Text), DateTime.MinValue))
                strSearchByPaymentDate = dt.ToString("MM-dd-yyyy")
            End If

            Dim strSearchByNoOfPeople As String = (If(TB_No_of_People.Text <> "", TB_No_of_People.Text, ""))
            Dim strSearchByRoute As String = (If(objFunction.ReturnString(DROP_Route.SelectedItem.Value) <> "0", DROP_Route.SelectedItem.Value, ""))
            Dim strSearchByCustomised As String = objFunction.ReturnString(RADIO_Customised_Fixed.SelectedItem.Value)
            Dim strSearchByAgent As String = objFunction.ReturnString(RADIO_Agent_or_Not.SelectedItem.Value)

            Dim dstReportBookingIndepthSearch As DataSet = (New clsDLBookingReport()).GetReportBookingIndepthSearch(intCompanyId, strSearchByDateCreated, strSearchByPaymentDate, strSearchByNoOfPeople, strSearchByRoute, strSearchByCustomised, strSearchByAgent)
            GridView1.DataSource = dstReportBookingIndepthSearch
            GridView1.DataBind()

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

    Protected Sub BUT__Show_Bookings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Show_Bookings.Click
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