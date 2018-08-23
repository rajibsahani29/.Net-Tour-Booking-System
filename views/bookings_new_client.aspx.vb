Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_new_client
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

                Dim dstCountry As DataSet = (New clsDLCountry()).GetCountryFillInDD()
                objFunction.FillDropDownByDataSet(DROP_Country, dstCountry)
                DROP_Country.Items.Insert(0, New ListItem("Select Country", ""))

                Dim dstSex As DataSet = (New clsDLSex()).GetSexFillInDD()
                RADIO_Gender.DataSource = dstSex
                RADIO_Gender.DataTextField = "Value"
                RADIO_Gender.DataValueField = "ID"
                RADIO_Gender.DataBind()
                RADIO_Gender.Items.FindByText("Male").Selected = True

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstMarketingSource As DataSet = (New clsDLMarketing()).GetMarketingFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Marketing_Source, dstMarketingSource)
                DROP_Marketing_Source.Items.Insert(0, New ListItem("Select Marketing Source", ""))

                TB_firstname.Text = objFunction.ReturnString(Session("NewClientFirstName"))
                TB_surname.Text = objFunction.ReturnString(Session("NewClientSurname"))

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add client detail
    ''' </summary>
    Protected Sub BUT_Add_New_Client_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_New_Client.Click
        Try
            objBEClient.Name1 = TB_firstname.Text
            objBEClient.Name2 = TB_surname.Text
            objBEClient.Address1 = TB_Address1.Text
            objBEClient.Address2 = TB_Address2.Text
            objBEClient.City = TB_city.Text
            objBEClient.PostCode = TB_postcode.Text
            objBEClient.CountryId = objFunction.ReturnInteger(DROP_Country.SelectedItem.Value)
            objBEClient.Email = TB_Client_Email.Text
            objBEClient.Phone1 = TB_phone1.Text
            objBEClient.Phone2 = TB_phone2.Text
            objBEClient.SexId = objFunction.ReturnInteger(RADIO_Gender.SelectedItem.Value)

            If CHK_Newsletter.Checked = True Then
                objBEClient.NewsLetter = True
            Else
                objBEClient.NewsLetter = False
            End If

            objBEClient.AdditionalInfo = TB_Info.Text
            objBEClient.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            objBEClient.MarketingId = objFunction.ReturnInteger(DROP_Marketing_Source.SelectedItem.Value)
            objBEClient.UrlName = TB_UrlName.Text

            Dim intClientId As Integer = objDLClient.AddClientDetails(objBEClient)
            Trace.Warn("btn intClientId = " + Convert.ToString(intClientId))
            If intClientId > 0 Then

                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objBEClient.Name1 + " has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "New client has been added"

                Session("NewClientFirstName") = Nothing
                Session("NewClientSurname") = Nothing

                If Session("RequestPage") = "BookingEnquiry" Then
                    Session("ClientId") = objFunction.ReturnString(intClientId)
                    Session("ClientFirstName") = TB_firstname.Text
                    Session("ClientSurname") = TB_surname.Text
                    Session("RequestPage") = Nothing
                    Response.Redirect("Bookings_enquiry.aspx")
                Else
                    Response.Redirect("bookings_new_client.aspx")
                End If

            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                Response.Redirect("bookings_new_client.aspx")
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





