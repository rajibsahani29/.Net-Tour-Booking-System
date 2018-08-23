﻿Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class extras_baggage_new
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEExtra As clsBEExtra = New clsBEExtra
    Dim objDLExtra As clsDLExtra = New clsDLExtra

    Dim objBEExtrasBaggageDetails As clsBEExtrasBaggageDetails = New clsBEExtrasBaggageDetails
    Dim objDLExtrasBaggageDetails As clsDLExtrasBaggageDetails = New clsDLExtrasBaggageDetails

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
    ''' This event is used to add extra detail
    ''' </summary>
    Protected Sub BUT_Add_Extra_Supplier_Service_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Extra_Supplier_Service.Click
        Try
            objBEExtra.Name = TB_name.Text
            objBEExtra.ExtraTypeId = 15
            objBEExtra.ContactName = TB_contact_name.Text
            objBEExtra.Address1 = TB_Address1.Text
            objBEExtra.Address2 = TB_Address2.Text
            objBEExtra.PostCode = TB_postcode.Text
            objBEExtra.City = TB_city.Text
            objBEExtra.CountryId = objFunction.ReturnInteger(DROP_Country.SelectedItem.Value)
            objBEExtra.Email = TB_email.Text
            objBEExtra.Phone = TB_phone1.Text
            'objBEExtra.MaxNumber = objFunction.ReturnInteger(TB_Maximum_Number.Text)
            objBEExtra.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            objBEExtra.GoogleDoc = TB_Extras_Google_Link.Text
            objBEExtra.WebsiteUrl = TB_Website.Text
            objBEExtra.Mobile = TB_Mobile_Phone.Text
            objBEExtra.OpenFrom = TB_Open_From.Text
            objBEExtra.OpenTo = TB_Open_To.Text
            objBEExtra.ExtGoogleDoc = TB_Extras_External_Google_Link.Text

            Dim intExtraId As Integer = objDLExtra.AddExtraDetails(objBEExtra)
            Trace.Warn("btn intExtraId = " + Convert.ToString(intExtraId))
            Dim intAffectedExtraBankingDetails As Integer
            If intExtraId > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objBEExtra.Name + " has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End

                objBEExtrasBaggageDetails.ExtraId = intExtraId
                objBEExtrasBaggageDetails.Stages = TB_No_of_Stages.Text
                objBEExtrasBaggageDetails.Bags = TB_Max_no_of_Bags.Text
                objBEExtrasBaggageDetails.Prices = objFunction.ReturnDouble(TB_Price_per_Bag.Text)
                objBEExtrasBaggageDetails.Instruction1 = TB_Instructions_1.Text
                objBEExtrasBaggageDetails.Instruction2 = TB_Instructions_2.Text
                objDLExtrasBaggageDetails.AddExtrasBaggageDetails(objBEExtrasBaggageDetails)

                objBEExtra.ExtraId = intExtraId
                objBEExtra.AccountName = TB_Bank_Account_Name.Text
                objBEExtra.AccountNo = TB_Bank_Account_Number.Text
                objBEExtra.SortCode = TB_Bank_Account_Sort_Code.Text
                intAffectedExtraBankingDetails = objDLExtra.AddExtraBankingDetails(objBEExtra)
                Trace.Warn("btn intExtraBankingDetailsId = " + Convert.ToString(intAffectedExtraBankingDetails))
            End If

            If intExtraId > 0 And intAffectedExtraBankingDetails > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "New Extra Baggage has been added"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("extras_baggage_new.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

End Class





