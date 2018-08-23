Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_bookings_no_walkers
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
                DROP_Route.Items.Insert(0, New ListItem("Select Route", ""))

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
            TB_Total_No_Walkers.Text = ""

            DIV_Total_No_Walkers.Attributes.Add("style", "display:block;")

            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim strSearchByCheckinEarliest As String = ""
            If TB_Date_From.Text <> "" Then
                Dim dt As DateTime = (If(TB_Date_From.Text <> "", Convert.ToDateTime(TB_Date_From.Text), DateTime.MinValue))
                strSearchByCheckinEarliest = dt.ToString("MM-dd-yyyy")
            End If

            Dim strSearchByCheckoutLatest As String = ""
            If TB_Date_To.Text <> "" Then
                Dim dt As DateTime = (If(TB_Date_To.Text <> "", Convert.ToDateTime(TB_Date_To.Text), DateTime.MinValue))
                strSearchByCheckoutLatest = dt.ToString("MM-dd-yyyy")
            End If

            Dim strSearchByRoute As String = objFunction.ReturnString(DROP_Route.SelectedItem.Value)

            Dim dstReportBookingNoWalkers As DataSet = (New clsDLBookingReport()).GetReportBookingNoWalkers(intCompanyId, strSearchByCheckinEarliest, strSearchByCheckoutLatest, strSearchByRoute)
            GRID_No_Walkers.DataSource = dstReportBookingNoWalkers
            GRID_No_Walkers.DataBind()

            If objFunction.CheckDataSet(dstReportBookingNoWalkers) Then
                Dim dtData As DataTable = dstReportBookingNoWalkers.Tables(0)
                Dim intSumOfMale As Integer = objFunction.ReturnInteger(dtData.Compute("SUM(NoOfMale)", String.Empty))
                Dim intSumOfFemale As Integer = objFunction.ReturnInteger(dtData.Compute("SUM(NoOfFemale)", String.Empty))
                Dim intSumOfOther As Integer = objFunction.ReturnInteger(dtData.Compute("SUM(NoOfOther)", String.Empty))
                TB_Total_No_Walkers.Text = objFunction.ReturnString(intSumOfMale + intSumOfFemale + intSumOfOther)
            Else
                TB_Total_No_Walkers.Text = "0"
            End If

            

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_No_Walkers
    ''' </summary>
    Protected Sub GRID_No_Walkers_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_No_Walkers.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_No_Walkers
    ''' </summary>
    Protected Sub GRID_No_Walkers_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_No_Walkers.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingId") = objFunction.ReturnString(GRID_No_Walkers.DataKeys(e.NewSelectedIndex).Value)
            Response.Redirect("bookings_view.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' Clieck event of button to get record
    ''' </summary>
    Protected Sub BUT__Show_No_Walkers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Show_No_Walkers.Click
        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

End Class