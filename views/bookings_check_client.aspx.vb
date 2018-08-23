Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_check_client
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEClient As clsBEClient = New clsBEClient
    Dim objDLClient As clsDLClient = New clsDLClient

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
    ''' This event is used to get client detail
    ''' </summary>
    Protected Sub BUT_Search_Name_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Search_Name.Click

        Try
            objBEClient.Name1 = TB_firstname.Text
            objBEClient.Name2 = TB_surname.Text
            objBEClient.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim dstClientDetail As DataSet = objDLClient.GetClientDetailByName(objBEClient)

            BindGridview(dstClientDetail)

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindGridview(ByVal dstClientDetail As DataSet)

        Try
            GridView1.DataSource = dstClientDetail
            GridView1.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GridView1
    ''' </summary>
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        'Trace.Warn("Value = " + objFunction.ReturnString(GridView1.DataKeys(e.NewSelectedIndex).Value))
        Session("ClientId") = objFunction.ReturnString(GridView1.DataKeys(e.NewSelectedIndex).Value)
        Session("ClientFirstName") = GridView1.Rows(e.NewSelectedIndex).Cells(1).Text
        Session("ClientSurname") = GridView1.Rows(e.NewSelectedIndex).Cells(2).Text
        Response.Redirect("Bookings_enquiry.aspx")

    End Sub

    Protected Sub BUT_Check_Client_System_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Check_Client_System.Click
        Session("NewClientFirstName") = TB_firstname.Text
        Session("NewClientSurname") = TB_surname.Text
        Response.Redirect("bookings_new_client.aspx")
    End Sub

End Class





