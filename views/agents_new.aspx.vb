Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class agents_new
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEAgent As clsBEAgent = New clsBEAgent
    Dim objDLAgent As clsDLAgent = New clsDLAgent

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

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add agent detail
    ''' </summary>
    Protected Sub BUT_Add_New_Agent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_New_Agent.Click
        Try
            objBEAgent.Name = TB_name.Text
            objBEAgent.ContactName = TB_contact_name.Text
            objBEAgent.Address1 = TB_Address1.Text
            objBEAgent.Address2 = TB_Address2.Text
            objBEAgent.City = TB_city.Text
            objBEAgent.PostCode = TB_postcode.Text
            objBEAgent.Email = TB_email.Text
            objBEAgent.Phone = TB_phone1.Text
            objBEAgent.CountryId = objFunction.ReturnInteger(DROP_Country.SelectedItem.Value)
            objBEAgent.AdditionalInfo = TB_Info.Text
            objBEAgent.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            objBEAgent.BankCharge = objFunction.ReturnDouble(TB_Agent_Bank_Charge.Text)
            If CHK_Buy_From.Checked = True Then
                objBEAgent.Buyx = True
            Else
                objBEAgent.Buyx = False
            End If

            If IsNumeric(TB_Agent_Bank_Charge.Text) Then
                Dim intAgentId As Integer = objDLAgent.AddAgentDetails(objBEAgent)
                Trace.Warn("btn intAgentId = " + Convert.ToString(intAgentId))
                Dim intAffectedAgentContactDetails As Integer
                If intAgentId > 0 Then
                    'Add Activity - Start
                    Dim objBEActivity As New clsBEActivity
                    objBEActivity.Descx = objBEAgent.Name + " has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                    objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                    Dim objDLActivity As New clsDLActivity
                    objDLActivity.AddActivity(objBEActivity)
                    'Add Activity - End

                    If TB_Agent_Contact1_Email.Text <> "" Then
                        objBEAgent.AgentId = intAgentId
                        objBEAgent.ACContactName = TB_Agent_Contact1.Text
                        objBEAgent.ACJobTitle = TB_Agent_Contact1_Job_Title.Text
                        objBEAgent.ACEmail = TB_Agent_Contact1_Email.Text
                        objBEAgent.ACPhone = TB_Agent_Contact1_Phone.Text
                        objBEAgent.ACOrderx = 1
                        intAffectedAgentContactDetails = objDLAgent.AddAgentContactDetails(objBEAgent)
                    End If

                    If TB_Agent_Contact2_Email.Text <> "" Then
                        objBEAgent.AgentId = intAgentId
                        objBEAgent.ACContactName = TB_Agent_Contact2.Text
                        objBEAgent.ACJobTitle = TB_Agent_Contact2_Job_Title.Text
                        objBEAgent.ACEmail = TB_Agent_Contact2_Email.Text
                        objBEAgent.ACPhone = TB_Agent_Contact2_Phone.Text
                        objBEAgent.ACOrderx = 2
                        intAffectedAgentContactDetails = objDLAgent.AddAgentContactDetails(objBEAgent)
                    End If

                    If TB_Agent_Contact3_Email.Text <> "" Then
                        objBEAgent.AgentId = intAgentId
                        objBEAgent.ACContactName = TB_Agent_Contact3.Text
                        objBEAgent.ACJobTitle = TB_Agent_Contact3_Job_Title.Text
                        objBEAgent.ACEmail = TB_Agent_Contact3_Email.Text
                        objBEAgent.ACPhone = TB_Agent_Contact3_Phone.Text
                        objBEAgent.ACOrderx = 3
                        intAffectedAgentContactDetails = objDLAgent.AddAgentContactDetails(objBEAgent)
                    End If

                    Trace.Warn("btn intExtraBankingDetailsId = " + Convert.ToString(intAffectedAgentContactDetails))
                End If

                If intAgentId > 0 Then
                    Session("feedback_call") = "1"
                    Session("error_msg") = "New agent has been added"
                    Response.Redirect("agents_new.aspx", False)
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    Response.Redirect("agents_new.aspx", False)
                End If
            Else
                'Session("feedback_call") = "2"
                'Session("error_msg") = "WARNING - Record was NOT updated - please check the charge entry"
                Dim javaScript As String = ""
                javaScript += "<script type='text/javascript'>"
                javaScript += "alert('Please check all fields');"
                javaScript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
            End If
            'Response.Redirect("agents_new.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





