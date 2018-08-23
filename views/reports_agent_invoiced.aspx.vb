Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_agent_invoiced
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
                Dim dstAgent As DataSet = (New clsDLAgent()).GetAgentDetailFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Agent, dstAgent)
                DROP_Agent.Items.Insert(0, New ListItem("Select Agent", ""))

                If DROP_Month.Items.FindByValue(objFunction.ReturnString(DateTime.Now.Month)) IsNot Nothing Then
                    DROP_Month.Items.FindByValue(objFunction.ReturnString(DateTime.Now.Month)).Selected = True
                Else
                    DROP_Month.SelectedIndex = 0
                End If

                If DROP_Year.Items.FindByValue(objFunction.ReturnString(DateTime.Now.Year)) IsNot Nothing Then
                    DROP_Year.Items.FindByValue(objFunction.ReturnString(DateTime.Now.Year)).Selected = True
                Else
                    DROP_Year.SelectedIndex = 0
                End If

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub BUT__View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__View.Click
        Try
            BindGridview()
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

            Dim objBEAgentInvoicedBookings As clsBEAgentInvoicedBookings = New clsBEAgentInvoicedBookings
            objBEAgentInvoicedBookings.MonthVal = objFunction.ReturnInteger(DROP_Month.SelectedItem.Value)
            objBEAgentInvoicedBookings.YearVal = objFunction.ReturnInteger(DROP_Year.SelectedItem.Value)
            objBEAgentInvoicedBookings.AgentId = objFunction.ReturnInteger(DROP_Agent.SelectedItem.Value)

            Dim dstAgentInvoicedBookings As DataSet = (New clsDLAgentInvoicedBookings()).GetAgentDetailByMonthYearAndAgentId(objBEAgentInvoicedBookings)
            GRID_Agent_Invoiced.DataSource = dstAgentInvoicedBookings
            GRID_Agent_Invoiced.DataBind()

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Agent_Invoiced
    ''' </summary>
    Protected Sub GRID_Agent_Invoiced_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Agent_Invoiced.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Agent_Invoiced
    ''' </summary>
    Protected Sub GRID_Agent_Invoiced_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Agent_Invoiced.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingId") = objFunction.ReturnString(GRID_Agent_Invoiced.DataKeys(e.NewSelectedIndex).Value)
            Dim strUrl As String = "bookings_view.aspx"
            Response.Write("<script>")
            Response.Write("window.open('" + strUrl + "','_blank')")
            Response.Write("<" + "/script>")
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