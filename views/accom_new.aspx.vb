Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class accom_new
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEAccomodation As clsBEAccomodation = New clsBEAccomodation
    Dim objDLAccomodation As clsDLAccomodation = New clsDLAccomodation

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

                BindAccomFacilitiesGridview()

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

                Dim dstPaymentMethod As DataSet = (New clsDLPaymentMethod()).GetPaymentMethodFillInDD(intCompanyId)
                If objFunction.CheckDataSet(dstPaymentMethod) Then
                    For i As Integer = 0 To dstPaymentMethod.Tables(0).Rows.Count - 1
                        Dim item As New ListItem()
                        item.Text = objFunction.ReturnString(dstPaymentMethod.Tables(0).Rows(i)("Value"))
                        item.Value = objFunction.ReturnString(dstPaymentMethod.Tables(0).Rows(i)("Id"))
                        CHKLIST_Payment_Method.Items.Add(item)
                    Next
                End If

                Dim dstMembership As DataSet = (New clsDLMembership()).GetMembershipFillInDD(intCompanyId)
                Trace.Warn("Row = " + objFunction.ReturnString(dstMembership.Tables(0).Rows.Count))
                If objFunction.CheckDataSet(dstMembership) Then
                    For i As Integer = 0 To dstMembership.Tables(0).Rows.Count - 1
                        Dim item As New ListItem()
                        item.Text = objFunction.ReturnString(dstMembership.Tables(0).Rows(i)("Value"))
                        item.Value = objFunction.ReturnString(dstMembership.Tables(0).Rows(i)("Id"))
                        CHKLIST_Memberships.Items.Add(item)
                    Next
                End If

                BindBreakfastGridview()

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindAccomFacilitiesGridview()

        Try
            Dim dstAccomFacilities As New DataSet()
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            dstAccomFacilities = (New clsDLAccomFacilities()).GetAccomFacilities(intCompanyId)
            GridView1.DataSource = dstAccomFacilities
            GridView1.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindBreakfastGridview()

        Try
            Dim dstBreakfast As New DataSet()
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            dstBreakfast = (New clsDLBreakfast()).GetBreakfastFillInDD(intCompanyId)
            GRID_Breakfast.DataSource = dstBreakfast
            GRID_Breakfast.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add accommodation detail
    ''' </summary>
    Protected Sub BUT_Add_New_Accommodation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_New_Accommodation.Click
        Try
            objBEAccomodation.Name = TB_name.Text
            objBEAccomodation.Contact = TB_contact_name.Text
            objBEAccomodation.Address1 = TB_Address1.Text
            objBEAccomodation.Address2 = TB_Address2.Text
            objBEAccomodation.City = TB_city.Text
            objBEAccomodation.PostCode = TB_postcode.Text
            objBEAccomodation.CountryId = objFunction.ReturnInteger(DROP_Country.SelectedItem.Value)
            objBEAccomodation.Email = TB_email.Text
            objBEAccomodation.Phone = TB_phone1.Text
            objBEAccomodation.Mobilex = TB_Mobile_Phone.Text
            objBEAccomodation.OpenFrom = TB_Open_From.Text
            objBEAccomodation.OpenTo = TB_Open_To.Text
            objBEAccomodation.Description = TB_Description.Text
            objBEAccomodation.Direction = TB_Directions.Text
            objBEAccomodation.Direction2 = TB_Directions2.Text
            objBEAccomodation.Direction3 = TB_Directions3.Text
            objBEAccomodation.Direction4 = TB_Directions4.Text
            objBEAccomodation.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            objBEAccomodation.StarRating = objFunction.ReturnInteger(TB_Star_Rating.Text)
            objBEAccomodation.EarliestTimeArrival = TB_arrival_time.Text
            objBEAccomodation.AccomComment = TB_Accom_Comments.Text
            objBEAccomodation.WebsiteLink = TB_Accom_Website.Text
            objBEAccomodation.NoRoom = objFunction.ReturnInteger(TB_Accom_Total_no_Rooms.Text)
            objBEAccomodation.GoogleMapLink = TB_Google_Map_Link.Text
            objBEAccomodation.BedroomConfig = TB_Room_Config.Text
            objBEAccomodation.DogConstraints = TB_Dog_Constraints.Text
            objBEAccomodation.PaymentPrefer = TB_Supplier_Payment_Method.Text

            If CHK_Dog_Friendly.Checked = True Then
                objBEAccomodation.DogFriendly = True
                objBEAccomodation.DogPrice = objFunction.ReturnDouble(TB_Dog_Price.Text)
            Else
                objBEAccomodation.DogFriendly = False
                objBEAccomodation.DogPrice = 0
            End If

            Dim intAccomId As Integer = objDLAccomodation.AddAccommodationDetails(objBEAccomodation)
            objBEAccomodation.AccomId = intAccomId

            For i As Integer = 0 To GridView1.Rows.Count - 1
                Dim gRow As GridViewRow = GridView1.Rows(i)
                Dim chkFacility As CheckBox = DirectCast(gRow.FindControl("CHK_SelectFacilities"), CheckBox)
                If chkFacility.Checked = True Then
                    Dim txtCostEw As TextBox = DirectCast(gRow.FindControl("TB_CostEw"), TextBox)
                    Dim txtCostClient As TextBox = DirectCast(gRow.FindControl("TB_CostClient"), TextBox)
                    Dim txtComment As TextBox = DirectCast(gRow.FindControl("TB_Comment"), TextBox)
                    Dim hdnSelectFacilities As HiddenField = DirectCast(gRow.FindControl("hdnSelectFacilities"), HiddenField)
                    objBEAccomodation.AccomFacilitiesId = objFunction.ReturnInteger(hdnSelectFacilities.Value)
                    objBEAccomodation.CostEasyway = objFunction.ReturnDouble(txtCostEw.Text)
                    objBEAccomodation.CostClient = objFunction.ReturnDouble(txtCostClient.Text)
                    objBEAccomodation.Commentx = txtComment.Text
                    objDLAccomodation.AddAccomAccomFacilitiesDetails(objBEAccomodation)
                End If
            Next

            For i As Integer = 0 To GRID_Breakfast.Rows.Count - 1
                Dim gRow As GridViewRow = GRID_Breakfast.Rows(i)
                Dim chkBreakfast As CheckBox = DirectCast(gRow.FindControl("CHK_SelectBreakfast"), CheckBox)
                If chkBreakfast.Checked = True Then
                    Dim txtBreakfastAmount As TextBox = DirectCast(gRow.FindControl("TB_Amount"), TextBox)
                    Dim hdnSelectBreakfast As HiddenField = DirectCast(gRow.FindControl("hdnSelectBreakfast"), HiddenField)
                    objBEAccomodation.BreakfastId = objFunction.ReturnInteger(hdnSelectBreakfast.Value)
                    objBEAccomodation.BreakfastAmount = objFunction.ReturnDouble(txtBreakfastAmount.Text)
                    objDLAccomodation.AddAccomBreakfastDetails(objBEAccomodation)
                End If
            Next

            For Each li As ListItem In CHKLIST_Payment_Method.Items
                If li.Selected Then
                    objBEAccomodation.PaymentMethodId = objFunction.ReturnInteger(li.Value)
                    objDLAccomodation.AddAccomPaymentMethodDetails(objBEAccomodation)
                End If
            Next

            objBEAccomodation.AccountName = TB_Bank_Account_Name.Text
            objBEAccomodation.AccountNo = TB_Bank_Account_Number.Text
            objBEAccomodation.SortCode = TB_Bank_Account_Sort_Code.Text
            objDLAccomodation.AddAccomBankingDetails(objBEAccomodation)

            For Each li As ListItem In CHKLIST_Memberships.Items
                If li.Selected Then
                    objBEAccomodation.AccomOpMembershipId = objFunction.ReturnInteger(li.Value)
                    objDLAccomodation.AddAccomMembershipsDetails(objBEAccomodation)
                End If
            Next

            If TB_Apple_Link.Text <> "" Or TB_Android_Link.Text <> "" Then
                objBEAccomodation.IosLink = TB_Apple_Link.Text
                objBEAccomodation.AndroidLink = TB_Android_Link.Text
                objDLAccomodation.AddAccomAppDetails(objBEAccomodation)
            End If

            If intAccomId > 0 Then
                'Add(Activity - Start)
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objBEAccomodation.Name + " has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "New accommodation has been added"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If

            Response.Redirect("accom_new.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





