Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_client_search
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
            Dim strSearchByPostcode As String = (If(TB_Search_Postcode.Text <> "", TB_Search_Postcode.Text, ""))
            Dim strSearchByEmail As String = (If(TB_Search_Email.Text <> "", TB_Search_Email.Text, ""))
            
            Dim dstBookingDetailForClientSearch As DataSet = (New clsDLBooking()).GetBookingDetailForClientSearch(intCompanyId, strSearchByName, strSearchBySurname, strSearchByPostcode, strSearchByEmail)
            GRID_Accom_Search.DataSource = dstBookingDetailForClientSearch
            GRID_Accom_Search.DataBind()
            
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Accom_Search
    ''' </summary>
    Protected Sub GRID_Accom_Search_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Accom_Search.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub GRID_Accom_Search_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        'Trace.Warn("GRID_Accom_Search_RowCommand = " + objFunction.ReturnString(e.CommandName))
        'Trace.Warn("Id Val = " + objFunction.ReturnString(GRID_Accom_Search.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(0)))
        'Trace.Warn("Id Val = " + objFunction.ReturnString(GRID_Accom_Search.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(1)))

        If objFunction.ReturnString(e.CommandName) = "ViewBooking" Then
            Session("BookingId") = objFunction.ReturnString(GRID_Accom_Search.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(0))
            Response.Redirect("bookings_view.aspx")
        End If

        If e.CommandName = "ViewClient" Then
            Session("EditClientId") = objFunction.ReturnString(GRID_Accom_Search.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(1))
            Session("RequestPage") = "bookings_client_search"
            Response.Redirect("bookings_edit_client.aspx")
        End If
        
    End Sub

    Protected Sub BUT__Search_Date_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Search_Date.Click
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