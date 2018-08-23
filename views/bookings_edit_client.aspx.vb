Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class bookings_edit_client
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

            If Session("EditClientId") = Nothing And objFunction.ReturnInteger(Session("EditClientId")) <= 0 Then
                Response.Redirect("~/views/bookings_view_client.aspx")
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

                SetClientDetails()

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to set client data in controls
    ''' </summary>
    Protected Sub SetClientDetails()

        Try
            objBEClient.ClientId = objFunction.ReturnInteger(Session("EditClientId"))
            objBEClient.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim dstClientDetail As DataSet = objDLClient.GetClientDetailById(objBEClient)

            If objFunction.CheckDataSet(dstClientDetail) Then

                TB_firstname.Text = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("name1"))
                TB_surname.Text = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("name2"))
                TB_Address1.Text = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("address1"))
                TB_Address2.Text = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("address2"))
                TB_city.Text = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("city"))
                TB_postcode.Text = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("postcode"))
                DROP_Country.SelectedValue = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("country_id"))
                TB_Client_Email.Text = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("email"))
                TB_phone1.Text = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("phone1"))
                TB_phone2.Text = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("phone2"))
                RADIO_Gender.SelectedValue = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("sexid"))

                If Convert.ToBoolean(dstClientDetail.Tables(0).Rows(0)("newsletter")) = True Then
                    CHK_Newsletter.Checked = True
                Else
                    CHK_Newsletter.Checked = False
                End If

                TB_Info.Text = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("additionainfo"))
                DROP_Marketing_Source.SelectedValue = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("marketing_id"))
                TB_UrlName.Text = objFunction.ReturnString(dstClientDetail.Tables(0).Rows(0)("url_name"))

            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to update client detail
    ''' </summary>
    Protected Sub BUT_Add_Update_Client_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Update_Client.Click

        Try
            objBEClient.ClientId = objFunction.ReturnInteger(Session("EditClientId"))
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
            objBEClient.MarketingId = objFunction.ReturnInteger(DROP_Marketing_Source.SelectedItem.Value)
            objBEClient.UrlName = TB_UrlName.Text

            Dim intAffectedRow As Integer = objDLClient.UpdateClientDetails(objBEClient)
            Trace.Warn("intAffectedRow = " + Convert.ToString(intAffectedRow))
            If intAffectedRow > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objBEClient.Name1 + " has been updated by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Client has been updated"

                'Session("EditClientId") = Nothing

            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If

            Response.Redirect("bookings_edit_client.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub BUT_Back_to_Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Back_to_Search.Click

        Try
            Session("EditClientId") = Nothing
            If Session("RequestPage") <> Nothing And objFunction.ReturnString(Session("RequestPage")) = "bookings_client_search" Then
                Session("RequestPage") = Nothing
                Response.Redirect("bookings_client_search.aspx")
            Else
                Response.Redirect("bookings_view_client.aspx")
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub BUT_Archive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Archive.Click
        Try
            objBEClient.ClientId = objFunction.ReturnInteger(Session("EditClientId"))
            objBEClient.CompanyId = 4
            Dim intAffectedRow As Integer = objDLClient.UpdateCompanyIdForDeleteClient(objBEClient)
            If intAffectedRow > 0 Then
                Session("EditClientId") = Nothing
                Session("feedback_call") = "1"
                Session("error_msg") = "Client has been archived"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("bookings_edit_client.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





