Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class accom_search
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
            Dim strSearchByStage As String = (If(TB_Search_Stage.Text <> "", TB_Search_Stage.Text, ""))
            Dim strSearchByPostcode As String = (If(TB_Search_Postcode.Text <> "", TB_Search_Postcode.Text, ""))

            Dim dstAccomRouteStage As DataSet = (New clsDLAccomodationStage()).GetAccomodationStageForSearch(intCompanyId, strSearchByName, strSearchByStage, strSearchByPostcode)
            GRID_Accom_Search.DataSource = dstAccomRouteStage
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

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Accom_Search
    ''' </summary>
    'Protected Sub GRID_Accom_Search_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

    '    Try
    '        'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Accom_Search.DataKeys(e.NewSelectedIndex).Value))
    '        Session("AccomId") = objFunction.ReturnString(GRID_Accom_Search.DataKeys(e.NewSelectedIndex).Value)
    '        Response.Redirect("accom_view_all.aspx")
    '    Catch ex As Exception
    '        HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
    '        HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
    '    End Try

    'End Sub

    Protected Sub GRID_Accom_Search_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        'Trace.Warn("GRID_Accom_Search_RowCommand = " + objFunction.ReturnString(e.CommandName))
        'Trace.Warn("Id Val = " + objFunction.ReturnString(GRID_Accom_Search.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(0)))
        'Trace.Warn("Id Val = " + objFunction.ReturnString(GRID_Accom_Search.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(1)))

        If objFunction.ReturnString(e.CommandName) = "ViewAccommodation" Then
            Session("AccomId") = objFunction.ReturnString(GRID_Accom_Search.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(0))
            Response.Redirect("accom_view_all.aspx")
        End If

        If e.CommandName = "EditAccommodation" Then
            Session("EditAccomId") = objFunction.ReturnString(GRID_Accom_Search.DataKeys(objFunction.ReturnInteger(e.CommandArgument)).Item(0))
            'Session("RequestPage") = "bookings_client_search"
            Response.Redirect("accom_view.aspx")
        End If

    End Sub

    Protected Sub BUT__Search_Accom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__Search_Accom.Click
        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class