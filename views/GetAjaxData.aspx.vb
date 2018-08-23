Imports System.Data
Imports Easyway.BE
Imports Easyway.DL
Imports System.Web.Script.Serialization

Partial Class views_GetAjaxData
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strResponceText As String = String.Empty
        Dim strDoAction As String = Request.Params.Get("DoAction")
        'Response.Write(strDoAction)
        Try
            If strDoAction = "getStaffMemberDetail" Then
                Dim intStaffId As Integer = objFunction.ReturnInteger(Request.Params.Get("StaffId"))
                'strResponceText = "Staff Id = " + objFunction.ReturnString(intStaffId)

                Dim objDLStaff As clsDLStaff = New clsDLStaff
                Dim dstStaffDetail As DataSet = objDLStaff.GetStaffMemberDetailById(intStaffId)
                
                If objFunction.CheckDataSet(dstStaffDetail) Then
                    Dim objStaffDetail As New Dictionary(Of String, String)()
                    objStaffDetail.Add("StaffId", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("id")))
                    objStaffDetail.Add("FirstName", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("name1")))
                    objStaffDetail.Add("Surname", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("name2")))
                    objStaffDetail.Add("Address1", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("address1")))
                    objStaffDetail.Add("Address2", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("address2")))
                    objStaffDetail.Add("City", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("city")))
                    objStaffDetail.Add("Postcode", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("postcode")))
                    objStaffDetail.Add("CountryId", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("country_id")))
                    objStaffDetail.Add("GenderId", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("sex_id")))
                    objStaffDetail.Add("PhoneNo1", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("phone1")))
                    objStaffDetail.Add("PhoneNo2", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("phone2")))
                    objStaffDetail.Add("AddInfo", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("additionainfo")))
                    objStaffDetail.Add("Password", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("password")))
                    objStaffDetail.Add("RoleId", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("role")))
                    objStaffDetail.Add("DateStarted", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("StaffDateStarted")))
                    objStaffDetail.Add("DateEnded", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("StaffDateEnded")))

                    If objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("lastlogin")) <> "" Then
                        Dim dtDate As DateTime = DateTime.Parse(objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("lastlogin")))
                        Dim strDate As String = objFunction.ReturnString(MonthName(dtDate.Month)) + " " + objFunction.ReturnString(dtDate.Day) + " " + objFunction.ReturnString(dtDate.Year) + " " + objFunction.ReturnString(dtDate.ToShortTimeString())
                        objStaffDetail.Add("LastLogin", objFunction.ReturnString(strDate))
                    Else
                        objStaffDetail.Add("LastLogin", "")
                    End If

                    If objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("dateadded")) <> "" Then
                        Dim dtDate As DateTime = DateTime.Parse(objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("dateadded")))
                        Dim strDate As String = objFunction.ReturnString(MonthName(dtDate.Month)) + " " + objFunction.ReturnString(dtDate.Day) + " " + objFunction.ReturnString(dtDate.Year) + " " + objFunction.ReturnString(dtDate.ToShortTimeString())
                        objStaffDetail.Add("DateAdded", objFunction.ReturnString(strDate))
                    Else
                        objStaffDetail.Add("DateAdded", "")
                    End If
                    
                    If objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("lastupdated")) <> "" Then
                        Dim dtDate As DateTime = DateTime.Parse(objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("lastupdated")))
                        Dim strDate As String = objFunction.ReturnString(MonthName(dtDate.Month)) + " " + objFunction.ReturnString(dtDate.Day) + " " + objFunction.ReturnString(dtDate.Year) + " " + objFunction.ReturnString(dtDate.ToShortTimeString())
                        objStaffDetail.Add("LastUpdated", objFunction.ReturnString(strDate))
                    Else
                        objStaffDetail.Add("LastUpdated", "")
                    End If

                    objStaffDetail.Add("Username", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("username")))
                    objStaffDetail.Add("RecStatus", objFunction.ReturnString(dstStaffDetail.Tables(0).Rows(0)("active")))
                    Dim serializer As New JavaScriptSerializer()
                    strResponceText = serializer.Serialize(objStaffDetail)
                Else
                    strResponceText = "Error"
                End If
            ElseIf strDoAction = "getActivityDetail" Then
                Dim objDLActivity As clsDLActivity = New clsDLActivity
                Dim intStaffId = objFunction.ReturnInteger(Session("LoginUserId"))
                Dim dstActivityDetail As DataSet = objDLActivity.GetLatestActivity(intStaffId)

                If objFunction.CheckDataSet(dstActivityDetail) Then
                    Dim lstActivityDetail As New List(Of String)
                    For Each row As DataRow In dstActivityDetail.Tables(0).Rows
                        lstActivityDetail.Add(objFunction.ReturnString(row.Item("descx")))
                    Next
                    Dim serializer As New JavaScriptSerializer()
                    strResponceText = serializer.Serialize(lstActivityDetail)
                Else
                    strResponceText = "Error"
                End If
            ElseIf strDoAction = "getExtraDetail" Then
                Dim intExtraId As Integer = objFunction.ReturnInteger(Request.Params.Get("ExtraId"))
                'strResponceText = "Staff Id = " + objFunction.ReturnString(intStaffId)

                Dim objDLExtra As clsDLExtra = New clsDLExtra
                Dim dstExtraDetail As DataSet = objDLExtra.GetExtraDetailById(intExtraId)

                If objFunction.CheckDataSet(dstExtraDetail) Then
                    Dim objStaffDetail As New Dictionary(Of String, String)()
                    objStaffDetail.Add("ExtraId", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("id")))
                    objStaffDetail.Add("Name", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("name")))
                    objStaffDetail.Add("ContactName", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("contact")))
                    objStaffDetail.Add("Address1", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("address1")))
                    objStaffDetail.Add("Address2", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("address2")))
                    objStaffDetail.Add("Postcode", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("postcode")))
                    objStaffDetail.Add("City", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("city")))
                    objStaffDetail.Add("CountryId", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("countryID")))
                    objStaffDetail.Add("Email", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("email")))
                    objStaffDetail.Add("Phone", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("phone")))
                    objStaffDetail.Add("MaxNumber", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("max_x")))
                    objStaffDetail.Add("AccountName", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("account_name")))
                    objStaffDetail.Add("AccountNo", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("account_no")))
                    objStaffDetail.Add("SortCode", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("sortcode")))
                    objStaffDetail.Add("DateAdded", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("date_added")))
                    objStaffDetail.Add("DateAmended", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("date_amended")))
                    objStaffDetail.Add("GoogleDoc", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("google_doc")))
                    objStaffDetail.Add("WebsiteUrl", objFunction.ReturnString(dstExtraDetail.Tables(0).Rows(0)("websiteURL")))
                    Dim serializer As New JavaScriptSerializer()
                    strResponceText = serializer.Serialize(objStaffDetail)
                Else
                    strResponceText = "Error"
                End If
            ElseIf strDoAction = "getExtraBaggageDetail" Then
                Dim intExtraId As Integer = objFunction.ReturnInteger(Request.Params.Get("ExtraId"))

                Dim objDLExtrasBaggageDetails As clsDLExtrasBaggageDetails = New clsDLExtrasBaggageDetails
                Dim dstExtrasBaggageDetails As DataSet = objDLExtrasBaggageDetails.GetExtraBaggageDetailByExtraId(intExtraId)

                If objFunction.CheckDataSet(dstExtrasBaggageDetails) Then
                    Dim objExtrasBaggageDetails As New Dictionary(Of String, String)()
                    objExtrasBaggageDetails.Add("ExtraId", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("id")))
                    objExtrasBaggageDetails.Add("Name", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("name")))
                    objExtrasBaggageDetails.Add("ContactName", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("contact")))
                    objExtrasBaggageDetails.Add("Address1", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("address1")))
                    objExtrasBaggageDetails.Add("Address2", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("address2")))
                    objExtrasBaggageDetails.Add("Postcode", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("postcode")))
                    objExtrasBaggageDetails.Add("City", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("city")))
                    objExtrasBaggageDetails.Add("CountryId", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("countryID")))
                    objExtrasBaggageDetails.Add("Email", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("email")))
                    objExtrasBaggageDetails.Add("Phone", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("phone")))
                    objExtrasBaggageDetails.Add("MaxNumber", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("max_x")))
                    objExtrasBaggageDetails.Add("AccountName", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("account_name")))
                    objExtrasBaggageDetails.Add("AccountNo", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("account_no")))
                    objExtrasBaggageDetails.Add("SortCode", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("sortcode")))
                    objExtrasBaggageDetails.Add("DateAdded", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("date_added")))
                    objExtrasBaggageDetails.Add("DateAmended", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("date_amended")))
                    objExtrasBaggageDetails.Add("GoogleDoc", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("google_doc")))
                    objExtrasBaggageDetails.Add("WebsiteUrl", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("websiteURL")))
                    objExtrasBaggageDetails.Add("Stages", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("stages")))
                    objExtrasBaggageDetails.Add("Bags", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("bags")))
                    objExtrasBaggageDetails.Add("Prices", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("prices")))
                    objExtrasBaggageDetails.Add("Instruction1", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("instructions1")))
                    objExtrasBaggageDetails.Add("Instruction2", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("instructions2")))
                    objExtrasBaggageDetails.Add("Mobile", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("mobile")))
                    objExtrasBaggageDetails.Add("OpenFrom", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("openFrom")))
                    objExtrasBaggageDetails.Add("OpenTo", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("openTo")))
                    objExtrasBaggageDetails.Add("ExtGoogleDoc", objFunction.ReturnString(dstExtrasBaggageDetails.Tables(0).Rows(0)("ext_google_doc")))
                    Dim serializer As New JavaScriptSerializer()
                    strResponceText = serializer.Serialize(objExtrasBaggageDetails)
                Else
                    strResponceText = "Error"
                End If
            ElseIf strDoAction = "getAgentDetail" Then
                Dim intAgentId As Integer = objFunction.ReturnInteger(Request.Params.Get("AgentId"))

                Dim objDLAgent As clsDLAgent = New clsDLAgent
                Dim dstAgentDetail As DataSet = objDLAgent.GetAgentDetailById(intAgentId)

                If objFunction.CheckDataSet(dstAgentDetail) Then
                    Dim objAgentDetail As New Dictionary(Of String, String)()
                    objAgentDetail.Add("AgentId", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("id")))
                    objAgentDetail.Add("Name", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("name")))
                    objAgentDetail.Add("ContactName", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("contactname")))
                    objAgentDetail.Add("Address1", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("address1")))
                    objAgentDetail.Add("Address2", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("address2")))
                    objAgentDetail.Add("City", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("city")))
                    objAgentDetail.Add("Postcode", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("postcode")))
                    objAgentDetail.Add("CountryId", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("country_id")))
                    objAgentDetail.Add("Email", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("email")))
                    objAgentDetail.Add("Phone", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("phone1")))
                    objAgentDetail.Add("AddiInfo", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("additionainfo")))
                    objAgentDetail.Add("DateCreated", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("dateadded")))
                    objAgentDetail.Add("LastUpdated", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("lastupdated")))
                    objAgentDetail.Add("BankCharge", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("bank_charge")))
                    objAgentDetail.Add("Buyx", objFunction.ReturnString(dstAgentDetail.Tables(0).Rows(0)("buyx")))
                    Dim serializer As New JavaScriptSerializer()
                    strResponceText = serializer.Serialize(objAgentDetail)
                Else
                    strResponceText = "Error"
                End If
            ElseIf strDoAction = "getAgentContactDetail" Then
                Dim intAgentId As Integer = objFunction.ReturnInteger(Request.Params.Get("AgentId"))

                Dim objDLAgent As clsDLAgent = New clsDLAgent
                Dim dstAgentContactDetail As DataSet = objDLAgent.GetContactDetailByAgentId(intAgentId, 0)
                If objFunction.CheckDataSet(dstAgentContactDetail) Then
                    For i As Integer = 0 To dstAgentContactDetail.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstAgentContactDetail.Tables(0).Rows(i)("contactname")) + "colSplit" + objFunction.ReturnString(dstAgentContactDetail.Tables(0).Rows(i)("job_title")) + "colSplit" + objFunction.ReturnString(dstAgentContactDetail.Tables(0).Rows(i)("emailx")) + "colSplit" + objFunction.ReturnString(dstAgentContactDetail.Tables(0).Rows(i)("phonex")) + "colSplit" + objFunction.ReturnString(dstAgentContactDetail.Tables(0).Rows(i)("orderx")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "getAccommodationDetail" Then
                Dim intAccomId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomId"))

                Dim objDLAccomodation As clsDLAccomodation = New clsDLAccomodation
                Dim dstAccomodationDetail As DataSet = objDLAccomodation.GetAccommodationDetailById(intAccomId)

                If objFunction.CheckDataSet(dstAccomodationDetail) Then
                    Dim objAccomodationDetail As New Dictionary(Of String, String)()
                    'Accommodation Detail
                    objAccomodationDetail.Add("AccomId", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("id")))
                    objAccomodationDetail.Add("Name", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("name")))
                    objAccomodationDetail.Add("Contact", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("contact")))
                    objAccomodationDetail.Add("Address1", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("address1")))
                    objAccomodationDetail.Add("Address2", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("address2")))
                    objAccomodationDetail.Add("City", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("city")))
                    objAccomodationDetail.Add("Postcode", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("postcode")))
                    objAccomodationDetail.Add("CountryId", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("countryID")))
                    objAccomodationDetail.Add("Email", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("email")))
                    objAccomodationDetail.Add("Phone", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("phone")))
                    objAccomodationDetail.Add("Description", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("description")))
                    objAccomodationDetail.Add("Direction", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("directions")))
                    objAccomodationDetail.Add("StarRating", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("star_rating")))
                    objAccomodationDetail.Add("EarliestTimeArrival", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("earliest_time_arrival")))
                    objAccomodationDetail.Add("Direction2", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("directions2")))
                    objAccomodationDetail.Add("Direction3", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("directions3")))
                    objAccomodationDetail.Add("Direction4", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("directions4")))
                    objAccomodationDetail.Add("Mobilex", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("mobilex")))
                    objAccomodationDetail.Add("OpenFrom", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("openfrom")))
                    objAccomodationDetail.Add("OpenTo", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("opento")))
                    objAccomodationDetail.Add("AccomComment", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("commentx")))
                    objAccomodationDetail.Add("WebsiteLink", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("websitex")))
                    objAccomodationDetail.Add("DogFriendly", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("dog_friendly")))
                    objAccomodationDetail.Add("DogPrice", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("dog_price")))
                    objAccomodationDetail.Add("NoRoom", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("no_rooms")))
                    objAccomodationDetail.Add("GoogleMapLink", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("google_link")))
                    objAccomodationDetail.Add("BedroomConfig", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("bedroom_config")))
                    objAccomodationDetail.Add("DogConstraints", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("dog_constraints")))
                    objAccomodationDetail.Add("PaymentPrefer", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("payment_prefer")))

                    'Accommodation Bank Detail
                    objAccomodationDetail.Add("AccountName", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("account_name")))
                    objAccomodationDetail.Add("AccountNo", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("account_no")))
                    objAccomodationDetail.Add("SortCode", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("sortcode")))

                    'Accommodation App Detail
                    objAccomodationDetail.Add("IosLink", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("ios_link")))
                    objAccomodationDetail.Add("AndroidLink", objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("and_link")))

                    Dim serializer As New JavaScriptSerializer()
                    strResponceText = serializer.Serialize(objAccomodationDetail)
                Else
                    strResponceText = "Error"
                End If
            ElseIf strDoAction = "getAccommodationFacility" Then
                Dim intAccomId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomId"))

                Dim objDLAccomodation As clsDLAccomodation = New clsDLAccomodation
                Dim dstAccomodationFacility As DataSet = objDLAccomodation.GetAccomFacilityByAccomId(intAccomId)
                If objFunction.CheckDataSet(dstAccomodationFacility) Then
                    For i As Integer = 0 To dstAccomodationFacility.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstAccomodationFacility.Tables(0).Rows(i)("accom_facilities_id")) + "colSplit" + objFunction.ReturnString(dstAccomodationFacility.Tables(0).Rows(i)("cost_easyways")) + "colSplit" + objFunction.ReturnString(dstAccomodationFacility.Tables(0).Rows(i)("cost_client")) + "colSplit" + objFunction.ReturnString(dstAccomodationFacility.Tables(0).Rows(i)("commentx")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "getAccommodationBreakfast" Then
                Dim intAccomId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomId"))

                Dim objDLAccomodation As clsDLAccomodation = New clsDLAccomodation
                Dim dstAccomodationBreakfast As DataSet = objDLAccomodation.GetAccomBreakfastByAccomId(intAccomId)
                If objFunction.CheckDataSet(dstAccomodationBreakfast) Then
                    For i As Integer = 0 To dstAccomodationBreakfast.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstAccomodationBreakfast.Tables(0).Rows(i)("breakfast_id")) + "colSplit" + objFunction.ReturnString(dstAccomodationBreakfast.Tables(0).Rows(i)("amountx")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "getAccommodationPaymentMethod" Then
                Dim intAccomId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomId"))

                Dim objDLAccomodation As clsDLAccomodation = New clsDLAccomodation
                Dim dstAccomPaymentMethod As DataSet = objDLAccomodation.GetAccomPaymentMethodByAccomId(intAccomId)
                If objFunction.CheckDataSet(dstAccomPaymentMethod) Then
                    For i As Integer = 0 To dstAccomPaymentMethod.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstAccomPaymentMethod.Tables(0).Rows(i)("paymentMethod_id")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "getAccommodationMembership" Then
                Dim intAccomId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomId"))

                Dim objDLAccomodation As clsDLAccomodation = New clsDLAccomodation
                Dim dstAccomMembership As DataSet = objDLAccomodation.GetAccomMembershipByAccomId(intAccomId)
                If objFunction.CheckDataSet(dstAccomMembership) Then
                    For i As Integer = 0 To dstAccomMembership.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstAccomMembership.Tables(0).Rows(i)("accom_memberships_id")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "getAccomDiaryCalander" Then
                Dim intAccomId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomId"))
                Dim dtFromDate As DateTime = Convert.ToDateTime(Request.Params.Get("FromDate"))
                Dim strCheckStatus As String = objFunction.ReturnString(Request.Params.Get("CheckStatus"))

                Dim objBEAccomDiaryEvent As clsBEAccomDiaryEvent = New clsBEAccomDiaryEvent
                Dim objDLAccomDiaryEvent As clsDLAccomDiaryEvent = New clsDLAccomDiaryEvent

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                objBEAccomDiaryEvent.AccomId = intAccomId
                objBEAccomDiaryEvent.FromDate = dtFromDate
                Dim strSearchByFromDate As String = dtFromDate.ToString("MM-dd-yyyy")
                Dim dstAccomDiaryEvent As DataSet = objDLAccomDiaryEvent.GetAccomDiaryEventCalander(objBEAccomDiaryEvent, intCompanyId, strSearchByFromDate)

                Dim lstCalendarData = New List(Of Dictionary(Of String, Object))()
                If objFunction.CheckDataSet(dstAccomDiaryEvent) Then

                    For i As Integer = 0 To dstAccomDiaryEvent.Tables(0).Rows.Count - 1

                        Dim objAccomDiaryEventCalendar1 As New Dictionary(Of String, Object)()
                        Dim objAccomDiaryEventCalendar2 As New Dictionary(Of String, String)()

                        Dim dtDate As DateTime = DateTime.MinValue
                        Dim strFromDate As String = ""
                        Dim strToDate As String = ""

                        If objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("from_date")) <> "" Then
                            strFromDate = objFunction.ReturnString(dtDate.Year) + "-" + dtDate.Month.ToString("#00") + "-" + objFunction.ReturnString(dtDate.Day).PadLeft(2, "0"c)
                        End If

                        If objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("to_date")) <> "" Then
                            dtDate = DateTime.Parse(objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("to_date")))
                            Dim tmpDtDate As DateTime = dtDate.AddDays(1)
                            strToDate = objFunction.ReturnString(dtDate.Year) + "-" + dtDate.Month.ToString("#00") + "-" + objFunction.ReturnString(tmpDtDate.Day).PadLeft(2, "0"c)
                        End If

                        objAccomDiaryEventCalendar2.Add("title", objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("Note")))
                        objAccomDiaryEventCalendar2.Add("start", objFunction.ReturnString(strFromDate))
                        objAccomDiaryEventCalendar2.Add("end", objFunction.ReturnString(strToDate))
                        objAccomDiaryEventCalendar2.Add("color", objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("AccomDiaryEventStatusColor")))
                        objAccomDiaryEventCalendar2.Add("textColor", "black")

                        objAccomDiaryEventCalendar1.Add("id", objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("id")))
                        objAccomDiaryEventCalendar1.Add("color", objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("AccomDiaryEventStatusColor")))
                        objAccomDiaryEventCalendar1.Add("data", objAccomDiaryEventCalendar2)
                        lstCalendarData.Add(objAccomDiaryEventCalendar1)

                    Next

                End If

                If strCheckStatus = "GetGeneralDiaryData" Then
                    Dim objBEDiaryGeneralEvents As clsBEDiaryGeneralEvents = New clsBEDiaryGeneralEvents
                    Dim objDLDiaryGeneralEvents As clsDLDiaryGeneralEvents = New clsDLDiaryGeneralEvents

                    If objFunction.ReturnInteger(Session("all_accom")) = 0 Then
                        objBEDiaryGeneralEvents.AccomId = objFunction.ReturnInteger(Session("accom_id"))
                    End If

                    objBEDiaryGeneralEvents.AccomId = intAccomId
                    objBEDiaryGeneralEvents.FromDate = dtFromDate
                    Trace.Warn("strSearchByFromDate = " + strSearchByFromDate)
                    Dim dstDiaryGeneralEvents As DataSet = objDLDiaryGeneralEvents.GetDiaryGeneralEventsCalander(objBEDiaryGeneralEvents, intCompanyId, strSearchByFromDate)
                    If objFunction.CheckDataSet(dstDiaryGeneralEvents) Then

                        For i As Integer = 0 To dstDiaryGeneralEvents.Tables(0).Rows.Count - 1

                            Dim objDiaryGeneralEventsCalendar1 As New Dictionary(Of String, Object)()
                            Dim objDiaryGeneralEventsCalendar2 As New Dictionary(Of String, String)()

                            Dim dtDate As DateTime = DateTime.Parse(objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("from_date")))
                            Dim strFromDate As String = objFunction.ReturnString(dtDate.Year) + "-" + dtDate.Month.ToString("#00") + "-" + objFunction.ReturnString(dtDate.Day).PadLeft(2, "0"c)

                            dtDate = DateTime.Parse(objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("to_date")))
                            Dim tmpDtDate As DateTime = dtDate.AddDays(1)
                            Dim strToDate As String = objFunction.ReturnString(dtDate.Year) + "-" + dtDate.Month.ToString("#00") + "-" + objFunction.ReturnString(tmpDtDate.Day).PadLeft(2, "0"c)

                            objDiaryGeneralEventsCalendar2.Add("title", objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("notes_x")))
                            objDiaryGeneralEventsCalendar2.Add("start", objFunction.ReturnString(strFromDate))
                            objDiaryGeneralEventsCalendar2.Add("end", objFunction.ReturnString(strToDate))

                            objDiaryGeneralEventsCalendar1.Add("id", objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("id")))
                            objDiaryGeneralEventsCalendar1.Add("data", objDiaryGeneralEventsCalendar2)
                            lstCalendarData.Add(objDiaryGeneralEventsCalendar1)

                        Next
                        
                    End If
                End If

                Dim serializer As New JavaScriptSerializer()
                strResponceText = serializer.Serialize(lstCalendarData)
            ElseIf strDoAction = "getAccomDiaryCalander2" Then
                Dim intStageId As Integer = objFunction.ReturnInteger(Request.Params.Get("StageId"))
                Dim dtFromDate As DateTime = Convert.ToDateTime(Request.Params.Get("FromDate"))
                
                Dim objBEAccomDiaryEvent As clsBEAccomDiaryEvent = New clsBEAccomDiaryEvent
                Dim objDLAccomDiaryEvent As clsDLAccomDiaryEvent = New clsDLAccomDiaryEvent

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                objBEAccomDiaryEvent.FromDate = dtFromDate
                Dim strSearchByFromDate As String = dtFromDate.ToString("MM-dd-yyyy")
                Dim dstAccomDiaryEvent As DataSet = objDLAccomDiaryEvent.GetAccomDiaryEventCalander2(objBEAccomDiaryEvent, intCompanyId, strSearchByFromDate, intStageId)

                Dim lstCalendarData = New List(Of Dictionary(Of String, Object))()
                If objFunction.CheckDataSet(dstAccomDiaryEvent) Then

                    For i As Integer = 0 To dstAccomDiaryEvent.Tables(0).Rows.Count - 1

                        Dim objAccomDiaryEventCalendar1 As New Dictionary(Of String, Object)()
                        Dim objAccomDiaryEventCalendar2 As New Dictionary(Of String, String)()

                        Dim dtDate As DateTime = DateTime.MinValue
                        Dim strFromDate As String = ""
                        Dim strToDate As String = ""

                        If objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("from_date")) <> "" Then
                            dtDate = DateTime.Parse(objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("from_date")))
                            strFromDate = objFunction.ReturnString(dtDate.Year) + "-" + dtDate.Month.ToString("#00") + "-" + objFunction.ReturnString(dtDate.Day).PadLeft(2, "0"c)
                        End If

                        If objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("to_date")) <> "" Then
                            dtDate = DateTime.Parse(objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("to_date")))
                            Dim tmpDtDate As DateTime = dtDate.AddDays(1)
                            strToDate = objFunction.ReturnString(dtDate.Year) + "-" + dtDate.Month.ToString("#00") + "-" + objFunction.ReturnString(tmpDtDate.Day).PadLeft(2, "0"c)
                        End If

                        objAccomDiaryEventCalendar2.Add("title", objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("Note")))
                        objAccomDiaryEventCalendar2.Add("start", objFunction.ReturnString(strFromDate))
                        objAccomDiaryEventCalendar2.Add("end", objFunction.ReturnString(strToDate))
                        objAccomDiaryEventCalendar2.Add("color", objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("AccomDiaryEventStatusColor")))
                        objAccomDiaryEventCalendar2.Add("textColor", "black")

                        objAccomDiaryEventCalendar1.Add("id", objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("id")))
                        objAccomDiaryEventCalendar1.Add("color", objFunction.ReturnString(dstAccomDiaryEvent.Tables(0).Rows(i)("AccomDiaryEventStatusColor")))
                        objAccomDiaryEventCalendar1.Add("data", objAccomDiaryEventCalendar2)
                        lstCalendarData.Add(objAccomDiaryEventCalendar1)

                    Next

                End If

                'Get general diary events data
                Dim objBEDiaryGeneralEvents As clsBEDiaryGeneralEvents = New clsBEDiaryGeneralEvents
                Dim objDLDiaryGeneralEvents As clsDLDiaryGeneralEvents = New clsDLDiaryGeneralEvents

                objBEDiaryGeneralEvents.FromDate = dtFromDate
                objBEDiaryGeneralEvents.StageId = intStageId
                Trace.Warn("strSearchByFromDate = " + strSearchByFromDate)
                Dim dstDiaryGeneralEvents As DataSet = objDLDiaryGeneralEvents.GetDiaryGeneralEventsCalander2(objBEDiaryGeneralEvents, intCompanyId, strSearchByFromDate)
                If objFunction.CheckDataSet(dstDiaryGeneralEvents) Then

                    For i As Integer = 0 To dstDiaryGeneralEvents.Tables(0).Rows.Count - 1

                        Dim objDiaryGeneralEventsCalendar1 As New Dictionary(Of String, Object)()
                        Dim objDiaryGeneralEventsCalendar2 As New Dictionary(Of String, String)()

                        Dim dtDate As DateTime = DateTime.MinValue
                        Dim strFromDate As String = ""
                        Dim strToDate As String = ""

                        If objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("from_date")) <> "" Then
                            dtDate = DateTime.Parse(objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("from_date")))
                            strFromDate = objFunction.ReturnString(dtDate.Year) + "-" + dtDate.Month.ToString("#00") + "-" + objFunction.ReturnString(dtDate.Day).PadLeft(2, "0"c)
                        End If

                        If objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("to_date")) <> "" Then
                            dtDate = DateTime.Parse(objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("to_date")))
                            Dim tmpDtDate As DateTime = dtDate.AddDays(1)
                            strToDate = objFunction.ReturnString(dtDate.Year) + "-" + dtDate.Month.ToString("#00") + "-" + objFunction.ReturnString(tmpDtDate.Day).PadLeft(2, "0"c)
                        End If
                        
                        objDiaryGeneralEventsCalendar2.Add("title", (objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("StageName")) + " - " + objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("AccomName")) + " - " + objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("notes_x"))))
                        objDiaryGeneralEventsCalendar2.Add("start", objFunction.ReturnString(strFromDate))
                        objDiaryGeneralEventsCalendar2.Add("end", objFunction.ReturnString(strToDate))

                        objDiaryGeneralEventsCalendar1.Add("id", objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("id")))
                        objDiaryGeneralEventsCalendar1.Add("data", objDiaryGeneralEventsCalendar2)
                        lstCalendarData.Add(objDiaryGeneralEventsCalendar1)

                    Next

                End If
                
                Dim serializer As New JavaScriptSerializer()
                strResponceText = serializer.Serialize(lstCalendarData)
            ElseIf strDoAction = "getGeneralDiaryCalander" Then
                Dim intStageId As Integer = objFunction.ReturnInteger(Request.Params.Get("StageId"))
                Dim intAccomId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomId"))
                Dim dtFromDate As DateTime = Convert.ToDateTime(Request.Params.Get("FromDate"))

                Dim objBEDiaryGeneralEvents As clsBEDiaryGeneralEvents = New clsBEDiaryGeneralEvents
                Dim objDLDiaryGeneralEvents As clsDLDiaryGeneralEvents = New clsDLDiaryGeneralEvents

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                objBEDiaryGeneralEvents.StageId = intStageId

                Trace.Warn("Sesison all_accom = " + objFunction.ReturnString(Session("all_accom")))
                Trace.Warn("Sesison accom_id = " + objFunction.ReturnString(Session("accom_id")))

                If objFunction.ReturnInteger(Session("all_accom")) = 0 Then
                    objBEDiaryGeneralEvents.AccomId = objFunction.ReturnInteger(Session("accom_id"))
                End If

                If intAccomId > 0 Then
                    objBEDiaryGeneralEvents.AccomId = intAccomId
                End If

                objBEDiaryGeneralEvents.FromDate = dtFromDate
                Dim strSearchByFromDate As String = dtFromDate.ToString("MM-dd-yyyy")
                Dim dstDiaryGeneralEvents As DataSet = objDLDiaryGeneralEvents.GetDiaryGeneralEventsCalander(objBEDiaryGeneralEvents, intCompanyId, strSearchByFromDate)
                If objFunction.CheckDataSet(dstDiaryGeneralEvents) Then

                    Dim lstCalendarData = New List(Of Dictionary(Of String, Object))()

                    For i As Integer = 0 To dstDiaryGeneralEvents.Tables(0).Rows.Count - 1

                        Dim objDiaryGeneralEventsCalendar1 As New Dictionary(Of String, Object)()
                        Dim objDiaryGeneralEventsCalendar2 As New Dictionary(Of String, String)()

                        Dim dtDate As DateTime = DateTime.MinValue
                        Dim strFromDate As String = ""
                        Dim strToDate As String = ""

                        If objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("from_date")) <> "" Then
                            dtDate = DateTime.Parse(objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("from_date")))
                            strFromDate = objFunction.ReturnString(dtDate.Year) + "-" + dtDate.Month.ToString("#00") + "-" + objFunction.ReturnString(dtDate.Day).PadLeft(2, "0"c)
                        End If

                        If objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("to_date")) <> "" Then
                            dtDate = DateTime.Parse(objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("to_date")))
                            Dim tmpDtDate As DateTime = dtDate.AddDays(1)
                            strToDate = objFunction.ReturnString(dtDate.Year) + "-" + dtDate.Month.ToString("#00") + "-" + objFunction.ReturnString(tmpDtDate.Day).PadLeft(2, "0"c)
                        End If

                        objDiaryGeneralEventsCalendar2.Add("title", objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("notes_x")))
                        objDiaryGeneralEventsCalendar2.Add("start", objFunction.ReturnString(strFromDate))
                        objDiaryGeneralEventsCalendar2.Add("end", objFunction.ReturnString(strToDate))

                        objDiaryGeneralEventsCalendar1.Add("id", objFunction.ReturnString(dstDiaryGeneralEvents.Tables(0).Rows(i)("id")))
                        objDiaryGeneralEventsCalendar1.Add("data", objDiaryGeneralEventsCalendar2)
                        lstCalendarData.Add(objDiaryGeneralEventsCalendar1)

                    Next
                    Dim serializer As New JavaScriptSerializer()
                    strResponceText = serializer.Serialize(lstCalendarData)
                End If
            ElseIf strDoAction = "getRoomTypeFacilitiesByAccomRoomTypeIdFillInDD" Then
                Dim intAccomRoomtypeId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomRoomtypeId"))
                Dim dstRoomFacilities As DataSet = (New clsDLAccomRooms()).GetRoomTypeFacilitiesByAccomRoomTypeIdFillInDD(intAccomRoomtypeId)
                If objFunction.CheckDataSet(dstRoomFacilities) Then
                    For i As Integer = 0 To dstRoomFacilities.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstRoomFacilities.Tables(0).Rows(i)("Id")) + "colSplit" + objFunction.ReturnString(dstRoomFacilities.Tables(0).Rows(i)("Value")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "getRoomTypeOptionsById" Then
                Dim intAccomRoomtypeId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomRoomtypeId"))
                Dim objBERoomTypeOptions As clsBERoomTypeOptions = New clsBERoomTypeOptions
                objBERoomTypeOptions.RoomTypeOptionsId = intAccomRoomtypeId
                objBERoomTypeOptions.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstRoomtypeOptionsDesc As DataSet = (New clsDLRoomTypeOptions()).GetRoomTypeOptionsByIdFillInDD(objBERoomTypeOptions)
                If objFunction.CheckDataSet(dstRoomtypeOptionsDesc) Then
                    For i As Integer = 0 To dstRoomtypeOptionsDesc.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(i)("Id")) + "colSplit" + objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(i)("Value")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "getAccomStageRoomOptions" Then
                Dim intAccomStageRoomId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomStageRoomId"))
                Dim dstAccomStageRoomOptions As DataSet = (New clsDLAccomStageRoomOptions()).GetAccomStageRoomOptionsByAccomStageRoomId(intAccomStageRoomId)
                If objFunction.CheckDataSet(dstAccomStageRoomOptions) Then
                    For i As Integer = 0 To dstAccomStageRoomOptions.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstAccomStageRoomOptions.Tables(0).Rows(i)("id")) + "colSplit" + objFunction.ReturnString(dstAccomStageRoomOptions.Tables(0).Rows(i)("roomtype_options_id")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "updateAccomStageRoomOptions" Then
                Dim intAccomStageRoomId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomStageRoomId"))
                Dim strCheckBoxListVal As String = objFunction.ReturnString(Request.Params.Get("CheckBoxListVal"))

                Dim intAffectedRow1 As Integer = (New clsDLAccomStageRoomOptions()).DeleteAccomStageRoomOptionsByAccomStageRoomId(intAccomStageRoomId)
                Dim intAffectedRow As Integer = 0
                If strCheckBoxListVal <> "" Then
                    Dim strCheckBoxListArray() As String = Convert.ToString(strCheckBoxListVal.TrimEnd(",")).Split(",")
                    Dim objBEAccomStageRoomOptions As clsBEAccomStageRoomOptions = New clsBEAccomStageRoomOptions
                    Trace.Warn("Array length = " + strCheckBoxListArray.Length.ToString())
                    For i = 0 To strCheckBoxListArray.Length - 1
                        objBEAccomStageRoomOptions.AccomStageRoomId = intAccomStageRoomId
                        objBEAccomStageRoomOptions.RoomTypeOptionId = objFunction.ReturnInteger(strCheckBoxListArray(i))
                        intAffectedRow = (New clsDLAccomStageRoomOptions()).AddAccomStageRoomOptionsDetail(objBEAccomStageRoomOptions)
                    Next
                End If
                If intAffectedRow > 0 Or intAffectedRow1 > 0 Then
                    strResponceText = "Success"
                Else
                    strResponceText = "Error"
                End If
            ElseIf strDoAction = "getBookingCorrespondenceNoteById" Then
                Dim intBookingCorrespondenceId As Integer = objFunction.ReturnInteger(Request.Params.Get("BookingCorrespondenceId"))
                Dim dstBookingCorrespondence As DataSet = (New clsDLBookingCorrespondence()).GetBookingCorrespondenceById(intBookingCorrespondenceId)
                If objFunction.CheckDataSet(dstBookingCorrespondence) Then
                    strResponceText = objFunction.ReturnString(dstBookingCorrespondence.Tables(0).Rows(0)("notesx"))
                End If
            ElseIf strDoAction = "getRoomFacilitiesByCompanyId" Then
                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstRoomFacilities As DataSet = (New clsDLRoomFacilities()).GetRoomFacilitiesFillInDD(intCompanyId)
                If objFunction.CheckDataSet(dstRoomFacilities) Then
                    For i As Integer = 0 To dstRoomFacilities.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstRoomFacilities.Tables(0).Rows(i)("Id")) + "colSplit" + objFunction.ReturnString(dstRoomFacilities.Tables(0).Rows(i)("Value")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "getRoomTypeFacilitiesByAccomRoomTypeId" Then
                Dim intAccomRoomTypeId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomRoomTypeId"))
                Dim dstAccomRoomFacilities As DataSet = (New clsDLAccomRooms()).GetRoomTypeFacilitiesByAccomRoomTypeId(intAccomRoomTypeId)
                If objFunction.CheckDataSet(dstAccomRoomFacilities) Then
                    For i As Integer = 0 To dstAccomRoomFacilities.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstAccomRoomFacilities.Tables(0).Rows(i)("id")) + "colSplit" + objFunction.ReturnString(dstAccomRoomFacilities.Tables(0).Rows(i)("room_facilities_id")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "updateAccomRoomTypeFacilitiesDetails" Then
                Dim intAccomRoomTypeId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomRoomTypeId"))
                Dim strCheckBoxListVal As String = objFunction.ReturnString(Request.Params.Get("CheckBoxListVal"))

                Dim objBEAccomRooms As clsBEAccomRooms = New clsBEAccomRooms
                objBEAccomRooms.AccomRoomTypeId = intAccomRoomTypeId
                Dim intAffectedRow1 As Integer = (New clsDLAccomRooms()).DeleteAccomRoomTypeFacilitiesDetails(objBEAccomRooms)
                Dim intAffectedRow As Integer = 0
                If strCheckBoxListVal <> "" Then
                    Dim strCheckBoxListArray() As String = Convert.ToString(strCheckBoxListVal.TrimEnd(",")).Split(",")
                    Trace.Warn("Array length = " + strCheckBoxListArray.Length.ToString())
                    For i = 0 To strCheckBoxListArray.Length - 1
                        objBEAccomRooms.RoomFacilitiesId = objFunction.ReturnInteger(strCheckBoxListArray(i))
                        intAffectedRow = (New clsDLAccomRooms()).AddAccomRoomTypeFacilitiesDetails(objBEAccomRooms)
                    Next
                    If intAffectedRow > 0 Then
                        strResponceText = "Success"
                    Else
                        strResponceText = "Error"
                    End If
                Else
                    strResponceText = "Blank"
                End If
                
            ElseIf strDoAction = "getRoomTypeOptionsByCompanyId" Then
                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstRoomtypeOptionsDesc As DataSet = (New clsDLRoomTypeOptions()).GetRoomTypeOptionsFillInDD(intCompanyId)
                If objFunction.CheckDataSet(dstRoomtypeOptionsDesc) Then
                    For i As Integer = 0 To dstRoomtypeOptionsDesc.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(i)("Id")) + "colSplit" + objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(i)("Value")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "getRoomTypeOptionByAccomRoomTypeId" Then
                Dim intAccomRoomTypeId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomRoomTypeId"))
                Dim dstRoomOptionDesc As DataSet = (New clsDLAccomRooms()).GetRoomTypeOptionByAccomRoomTypeId(intAccomRoomTypeId)
                If objFunction.CheckDataSet(dstRoomOptionDesc) Then
                    For i As Integer = 0 To dstRoomOptionDesc.Tables(0).Rows.Count - 1
                        strResponceText += objFunction.ReturnString(dstRoomOptionDesc.Tables(0).Rows(i)("id")) + "colSplit" + objFunction.ReturnString(dstRoomOptionDesc.Tables(0).Rows(i)("roomtype_options_desc_id")) + "rowSplit"
                    Next
                End If
            ElseIf strDoAction = "updateAccomRoomTypeOptionDetails" Then
                Dim intAccomRoomTypeId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomRoomTypeId"))
                Dim strCheckBoxListVal As String = objFunction.ReturnString(Request.Params.Get("CheckBoxListVal"))

                Dim objBEAccomRooms As clsBEAccomRooms = New clsBEAccomRooms
                objBEAccomRooms.AccomRoomTypeId = intAccomRoomTypeId
                Dim intAffectedRow1 As Integer = (New clsDLAccomRooms()).DeleteRoomTypeOptionsDetails(objBEAccomRooms)
                Dim intAffectedRow As Integer = 0
                If strCheckBoxListVal <> "" Then
                    Dim strCheckBoxListArray() As String = Convert.ToString(strCheckBoxListVal.TrimEnd(",")).Split(",")
                    Trace.Warn("Array length = " + strCheckBoxListArray.Length.ToString())
                    For i = 0 To strCheckBoxListArray.Length - 1
                        objBEAccomRooms.RoomTypeOptionsDescId = objFunction.ReturnInteger(strCheckBoxListArray(i))
                        intAffectedRow = (New clsDLAccomRooms()).AddRoomTypeOptionsDetails(objBEAccomRooms)
                    Next
                    If intAffectedRow > 0 Then
                        strResponceText = "Success"
                    Else
                        strResponceText = "Error"
                    End If
                Else
                    strResponceText = "Blank"
                End If
            ElseIf strDoAction = "getRoomPricesByRoomTypeId" Then
                Dim intAccomRoomtypeId As Integer = objFunction.ReturnInteger(Request.Params.Get("AccomRoomtypeId"))
                Dim dstAccomRoomType As DataSet = (New clsDLAccomRooms()).GetAccomRoomtypeById(intAccomRoomtypeId)
                If objFunction.CheckDataSet(dstAccomRoomType) Then
                    strResponceText += objFunction.ReturnString(dstAccomRoomType.Tables(0).Rows(0)("max_occupancy")) + "colSplit" + objFunction.ReturnString(dstAccomRoomType.Tables(0).Rows(0)("cost_easyways")) + "colSplit" + objFunction.ReturnString(dstAccomRoomType.Tables(0).Rows(0)("cost_client"))
                End If
            ElseIf strDoAction = "ManagePaymentToSupplierTotal_Old" Then
                Dim intMonthVal As Integer = objFunction.ReturnInteger(Request.Params.Get("MonthVal"))
                Dim intYearVal As Integer = objFunction.ReturnInteger(Request.Params.Get("YearVal"))
                Dim intSupplierType As Integer = objFunction.ReturnInteger(Request.Params.Get("SupplierType"))
                Dim intSupplierId As Integer = objFunction.ReturnInteger(Request.Params.Get("SupplierId"))
                Dim dblTotalAmount As Double = objFunction.ReturnDouble(Request.Params.Get("TotalAmount"))
                Dim dtDatePaid As DateTime = (If(objFunction.ReturnString(Request.Params.Get("DatePaid")) <> "", Convert.ToDateTime(Request.Params.Get("DatePaid")), DateTime.MinValue))
                Dim bnlChkPaid As Boolean = Convert.ToBoolean(Request.Params.Get("ChkPaid"))

                Dim objBEPaymentToSupplierTotal As clsBEPaymentToSupplierTotal = New clsBEPaymentToSupplierTotal
                Dim objDLPaymentToSupplierTotal As clsDLPaymentToSupplierTotal = New clsDLPaymentToSupplierTotal

                objBEPaymentToSupplierTotal.SupplierId = intSupplierId
                objBEPaymentToSupplierTotal.MonthVal = intMonthVal
                objBEPaymentToSupplierTotal.YearVal = intYearVal
                objBEPaymentToSupplierTotal.SupplierType = intSupplierType
                objBEPaymentToSupplierTotal.TotalAmount = dblTotalAmount
                objBEPaymentToSupplierTotal.DatePaid = dtDatePaid
                objBEPaymentToSupplierTotal.Paid = bnlChkPaid

                Dim dstData As DataSet = objDLPaymentToSupplierTotal.GetSupplierDetailByMonthYearSupplierIdAndSupplierType(objBEPaymentToSupplierTotal)
                If objFunction.CheckDataSet(dstData) Then
                    objBEPaymentToSupplierTotal.PaymentToSupplierTotalId = objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("id"))
                    Dim intAffectedRow As Integer = objDLPaymentToSupplierTotal.UpdatePaymentToSupplierTotalPaidAndDatePaid(objBEPaymentToSupplierTotal)
                    If intAffectedRow > 0 Then
                        'strResponceText = "Success"
                        strResponceText = UpdatePaymentToSupplier_Paid(intSupplierId, intSupplierType, intMonthVal, intYearVal, dtDatePaid)
                    Else
                        strResponceText = "Error"
                    End If
                Else
                    Dim intAffectedRow As Integer = objDLPaymentToSupplierTotal.AddPaymentToSupplierTotal(objBEPaymentToSupplierTotal)
                    If intAffectedRow > 0 Then
                        'strResponceText = "Success"
                        strResponceText = UpdatePaymentToSupplier_Paid(intSupplierId, intSupplierType, intMonthVal, intYearVal, dtDatePaid)
                    Else
                        strResponceText = "Error"
                    End If
                End If
            ElseIf strDoAction = "ManagePaymentToSupplierTotal" Then
                Dim intMonthVal As Integer = objFunction.ReturnInteger(Request.Params.Get("MonthVal"))
                Dim intYearVal As Integer = objFunction.ReturnInteger(Request.Params.Get("YearVal"))
                Dim intSupplierType As Integer = objFunction.ReturnInteger(Request.Params.Get("SupplierType"))
                Dim intSupplierId As Integer = objFunction.ReturnInteger(Request.Params.Get("SupplierId"))
                Dim dblTotalAmount As Double = objFunction.ReturnDouble(Request.Params.Get("TotalAmount"))
                Dim dtDatePaid As DateTime = (If(objFunction.ReturnString(Request.Params.Get("DatePaid")) <> "", Convert.ToDateTime(Request.Params.Get("DatePaid")), DateTime.MinValue))
                Dim bnlChkPaid As Boolean = Convert.ToBoolean(Request.Params.Get("ChkPaid"))
                Dim strPaidStatus As String = objFunction.ReturnString(Request.Params.Get("PaidStatus"))

                Dim objBEPaymentToSupplierTotal As clsBEPaymentToSupplierTotal = New clsBEPaymentToSupplierTotal
                Dim objDLPaymentToSupplierTotal As clsDLPaymentToSupplierTotal = New clsDLPaymentToSupplierTotal

                objBEPaymentToSupplierTotal.SupplierId = intSupplierId
                objBEPaymentToSupplierTotal.MonthVal = intMonthVal
                objBEPaymentToSupplierTotal.YearVal = intYearVal
                objBEPaymentToSupplierTotal.SupplierType = intSupplierType
                objBEPaymentToSupplierTotal.TotalAmount = dblTotalAmount
                objBEPaymentToSupplierTotal.DatePaid = dtDatePaid
                objBEPaymentToSupplierTotal.Paid = bnlChkPaid

                Dim intAffectedRow As Integer = objDLPaymentToSupplierTotal.AddPaymentToSupplierTotal(objBEPaymentToSupplierTotal)
                If intAffectedRow > 0 Then
                    Session("Supplier_Payment_MM") = objFunction.ReturnString(intMonthVal)
                    Session("Supplier_Payment_YYYY") = objFunction.ReturnString(intYearVal)
                    Session("Supplier_Payment_Type") = objFunction.ReturnString(intSupplierType)
                    If strPaidStatus = "FullPaid" Then
                        strResponceText = UpdatePaymentToSupplier_Paid(intSupplierId, intSupplierType, intMonthVal, intYearVal, dtDatePaid)
                        strResponceText = AddBookingStatusBookings(intSupplierId, intSupplierType, intMonthVal, intYearVal)
                    Else
                        strResponceText = "Success"
                    End If
                Else
                    strResponceText = "Error"
                End If
            ElseIf strDoAction = "RedirectToBookingView" Then
                Session("BookingId") = objFunction.ReturnString(Request.Params.Get("BookingId"))
                If objFunction.ReturnString(Session("BookingId")) <> "" Then
                    strResponceText = "Success"
                Else
                    strResponceText = "Error"
                End If
            ElseIf strDoAction = "AddRemoveBookingStatusBookings" Then
                Dim intBookingId As Integer = objFunction.ReturnInteger(Request.Params.Get("BookingId"))
                Dim intBscID As Integer = objFunction.ReturnInteger(Request.Params.Get("BscID"))
                Dim strRecStatus As String = objFunction.ReturnString(Request.Params.Get("RecStatus"))

                Dim intAffectedRow As Integer = 0
                Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                If strRecStatus = "AddRecord" Then
                    objBEBookingStatusBookings.BookingId = intBookingId
                    objBEBookingStatusBookings.BSCId = intBscID
                    intAffectedRow = objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                ElseIf strRecStatus = "RemoveRecord" Then
                    objBEBookingStatusBookings.BookingId = intBookingId
                    objBEBookingStatusBookings.BSCId = intBscID
                    intAffectedRow = objDLBookingStatusBookings.DeleteBookingStatusBookingsByBookingIdAndBscId(objBEBookingStatusBookings)
                End If

                If intAffectedRow > 0 Then
                    strResponceText = "Success"
                Else
                    strResponceText = "Error"
                End If

            End If

            Response.Clear()
            Response.Write(strResponceText)
            Response.End()

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Function UpdatePaymentToSupplier_Paid(ByVal intSupplierId As Integer, ByVal intSupplierType As Integer, ByVal intMonthVal As Integer, ByVal intYearVal As Integer, ByVal dtDatePaid As DateTime) As String
        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            Dim objDLPaymentToSupplier As clsDLPaymentToSupplier = New clsDLPaymentToSupplier
            objBEPaymentToSupplier.SupplierId = intSupplierId
            objBEPaymentToSupplier.MonthVal = intMonthVal
            objBEPaymentToSupplier.YearVal = intYearVal
            objBEPaymentToSupplier.SupplierType = intSupplierType
            Dim dstData As DataSet = objDLPaymentToSupplier.GetSupplierDetailByMonthYearSupplierTypeAndSupplierId(objBEPaymentToSupplier, intCompanyId)
            Dim strMsg As String = "Success"
            If objFunction.CheckDataSet(dstData) Then
                For i = 0 To dstData.Tables(0).Rows.Count - 1
                    objBEPaymentToSupplier.PaymentToSupplierId = objFunction.ReturnInteger(dstData.Tables(0).Rows(i)("id"))
                    'objBEPaymentToSupplier.DatePaid = dtDatePaid
                    objBEPaymentToSupplier.DatePaid = DateTime.Now
                    objBEPaymentToSupplier.Paid = True
                    Dim intAffectedRow As Integer = objDLPaymentToSupplier.UpdatePaidStatusAndPaidDate(objBEPaymentToSupplier)
                    If intAffectedRow <= 0 Then
                        strMsg = "Error"
                    End If
                Next
                Return strMsg
            Else
                strMsg = "Error"
            End If
            Return strMsg
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function


    Function AddBookingStatusBookings(ByVal intSupplierId As Integer, ByVal intSupplierType As Integer, ByVal intMonthVal As Integer, ByVal intYearVal As Integer) As String
        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim objBEPaymentToSupplier As clsBEPaymentToSupplier = New clsBEPaymentToSupplier
            Dim objDLPaymentToSupplier As clsDLPaymentToSupplier = New clsDLPaymentToSupplier
            objBEPaymentToSupplier.SupplierId = intSupplierId
            objBEPaymentToSupplier.MonthVal = intMonthVal
            objBEPaymentToSupplier.YearVal = intYearVal
            objBEPaymentToSupplier.SupplierType = intSupplierType
            'Dim dstData As DataSet = objDLPaymentToSupplier.GetSupplierDetailByMonthYearAndSupplierType(objBEPaymentToSupplier, intCompanyId)
            Dim dstData As DataSet = objDLPaymentToSupplier.GetSupplierDetailByMonthYearSupplierTypeAndSupplierId(objBEPaymentToSupplier, intCompanyId)
            Dim strMsg As String = "Success"
            If objFunction.CheckDataSet(dstData) Then

                Dim intBSCId As Integer = 0
                If intSupplierType = 1 Then
                    intBSCId = 19
                ElseIf intSupplierType = 2 Then
                    intBSCId = 20
                ElseIf intSupplierType = 3 Then
                    intBSCId = 21
                End If

                Dim dtData As DataTable = dstData.Tables(0)
                Dim view As DataView = New DataView(dtData)
                Dim dtDistinctData As DataTable = view.ToTable(True, "booking_id")
                If objFunction.CheckDataTable(dtDistinctData) Then
                    For i = 0 To dtDistinctData.Rows.Count - 1
                        'Add Booking_Status_Bookings
                        Dim objBEBookingStatusBookings As clsBEBookingStatusBookings = New clsBEBookingStatusBookings
                        Dim objDLBookingStatusBookings As clsDLBookingStatusBookings = New clsDLBookingStatusBookings
                        objBEBookingStatusBookings.BookingId = objFunction.ReturnInteger(dtDistinctData.Rows(i)("booking_id"))
                        objBEBookingStatusBookings.BSCId = intBSCId
                        Dim intAffectedRow As Integer = objDLBookingStatusBookings.AddBookingStatusBookings(objBEBookingStatusBookings)
                        If intAffectedRow <= 0 Then
                            strMsg = "Error"
                        End If
                    Next
                End If

                'Dim dt As DataTable = dstData.Tables(0)
                'dt.DefaultView.RowFilter = "paid <> 1 OR paid IS NULL"
                'Dim dtDataTable As DataTable = dt.DefaultView.ToTable()

                'If Not objFunction.CheckDataTable(dtDataTable) Then

                'End If
                Return strMsg
            Else
                strMsg = "Error"
            End If
            Return strMsg
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

End Class
