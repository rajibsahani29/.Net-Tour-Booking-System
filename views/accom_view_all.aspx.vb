Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class accom_view_all
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

            If objFunction.ReturnString(Session("AccomId")) = "" And Session("AccomId") Is Nothing Then
                Response.Redirect("accom_search.aspx")
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
                Dim dstCountry As DataSet = (New clsDLCountry()).GetCountryFillInDD()
                objFunction.FillDropDownByDataSet(DROP_Country, dstCountry)
                DROP_Country.Items.Insert(0, New ListItem("Select Country", ""))

                Dim dstPaymentMethod As DataSet = (New clsDLPaymentMethod()).GetPaymentMethodFillInDD(intCompanyId)
                If objFunction.CheckDataSet(dstPaymentMethod) Then
                    For i As Integer = 0 To dstPaymentMethod.Tables(0).Rows.Count - 1
                        Dim item As New ListItem()
                        item.Text = objFunction.ReturnString(dstPaymentMethod.Tables(0).Rows(i)("Value"))
                        item.Value = objFunction.ReturnString(dstPaymentMethod.Tables(0).Rows(i)("Id"))
                        item.Attributes("class") = "clsPaymentMethodId_" + objFunction.ReturnString(dstPaymentMethod.Tables(0).Rows(i)("Id"))
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
                        item.Attributes("class") = "clsMembershipId_" + objFunction.ReturnString(dstMembership.Tables(0).Rows(i)("Id"))
                        CHKLIST_Memberships.Items.Add(item)
                    Next
                End If

                BindAccomFacilitiesGridview()
                BindBreakfastGridview()
                BindAccomDetails()
                BindAccomPhotoGridview()
                BindAccomRoomsGridview()
                BindAccomLinkGridView()

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
            GRID_Accom_Facilities.DataSource = dstAccomFacilities
            GRID_Accom_Facilities.DataBind()

            For i As Integer = 0 To GRID_Accom_Facilities.Rows.Count - 1
                Dim gRow As GridViewRow = GRID_Accom_Facilities.Rows(i)
                Dim chkFacility As CheckBox = DirectCast(gRow.FindControl("CHK_SelectFacilities"), CheckBox)
                Dim txtCostEw As TextBox = DirectCast(gRow.FindControl("TB_CostEw"), TextBox)
                Dim txtCostClient As TextBox = DirectCast(gRow.FindControl("TB_CostClient"), TextBox)
                Dim txtComment As TextBox = DirectCast(gRow.FindControl("TB_Comment"), TextBox)
                Dim hdnSelectFacilities As HiddenField = DirectCast(gRow.FindControl("hdnSelectFacilities"), HiddenField)
                chkFacility.Attributes("class") = "clsFacilityId_" + hdnSelectFacilities.Value
                txtCostEw.Attributes("class") = "clsCostEw_" + hdnSelectFacilities.Value
                txtCostClient.Attributes("class") = "clsCostClient_" + hdnSelectFacilities.Value
                txtComment.Attributes("class") = "clsComment_" + hdnSelectFacilities.Value
            Next

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
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstBreakfast As New DataSet()
            dstBreakfast = (New clsDLBreakfast()).GetBreakfastFillInDD(intCompanyId)
            GRID_Breakfast.DataSource = dstBreakfast
            GRID_Breakfast.DataBind()

            For i As Integer = 0 To GRID_Breakfast.Rows.Count - 1
                Dim gRow As GridViewRow = GRID_Breakfast.Rows(i)
                Dim chkBreakfast As CheckBox = DirectCast(gRow.FindControl("CHK_SelectBreakfast"), CheckBox)
                Dim txtBreakfastAmount As TextBox = DirectCast(gRow.FindControl("TB_Amount"), TextBox)
                Dim hdnSelectBreakfast As HiddenField = DirectCast(gRow.FindControl("hdnSelectBreakfast"), HiddenField)
                chkBreakfast.Attributes("class") = "clsBreakfastId_" + hdnSelectBreakfast.Value
                txtBreakfastAmount.Attributes("class") = "clsBreakfastAmount_" + hdnSelectBreakfast.Value
            Next
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind accom details
    ''' </summary>
    Protected Sub BindAccomDetails()

        Try
            Dim intAccomId As Integer = objFunction.ReturnInteger(Session("AccomId"))
            Dim dstAccomodationDetail As DataSet = (New clsDLAccomodation()).GetAccommodationDetailById(intAccomId)

            If objFunction.CheckDataSet(dstAccomodationDetail) Then
                TB_name.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("name"))
                TB_contact_name.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("contact"))
                TB_Address1.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("address1"))
                TB_Address2.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("address2"))
                TB_city.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("city"))
                TB_postcode.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("postcode"))
                DROP_Country.SelectedValue = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("countryID"))
                TB_email.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("email"))
                TB_phone1.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("phone"))
                TB_Mobile_Phone.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("mobilex"))
                TB_Accom_Total_no_Rooms.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("no_rooms"))
                TB_Open_From.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("openfrom"))
                TB_Open_To.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("opento"))
                TB_Accom_Comments.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("commentx"))
                If objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("dog_friendly")) <> "" Then
                    If Convert.ToBoolean(dstAccomodationDetail.Tables(0).Rows(0)("dog_friendly")) = True Then
                        CHK_Dog_Friendly.Checked = True
                    Else
                        CHK_Dog_Friendly.Checked = False
                    End If
                End If
                TB_Dog_Price.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("dog_price"))
                TB_Star_Rating.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("star_rating"))
                TB_Google_Map_Link.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("google_link"))
                TB_Dog_Constraints.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("dog_constraints"))
                TB_Supplier_Payment_Method.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("payment_prefer"))
                TB_Room_Config.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("bedroom_config"))
                TB_Description.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("description"))
                TB_Directions.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("directions"))
                TB_Directions2.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("directions2"))
                TB_Directions3.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("directions3"))
                TB_Directions4.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("directions4"))
                TB_arrival_time.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("earliest_time_arrival"))
                TB_Bank_Account_Name.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("account_name"))
                TB_Bank_Account_Number.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("account_no"))
                TB_Bank_Account_Sort_Code.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("sortcode"))
                TB_Apple_Link.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("ios_link"))
                TB_Android_Link.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("and_link"))
                TB_Accom_Website.Text = objFunction.ReturnString(dstAccomodationDetail.Tables(0).Rows(0)("websitex"))


                Dim javaScript As String = ""
                javaScript += "<script type='text/javascript'>"
                javaScript += "GetAccommodationFacility('" + objFunction.ReturnString(intAccomId) + "');"
                javaScript += "GetAccommodationBreakfast('" + objFunction.ReturnString(intAccomId) + "');"
                javaScript += "GetAccommodationPaymentMethod('" + objFunction.ReturnString(intAccomId) + "');"
                javaScript += "GetAccommodationMembership('" + objFunction.ReturnString(intAccomId) + "');"
                javaScript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind accom photo gridview
    ''' </summary>
    Protected Sub BindAccomPhotoGridview()

        Try
            Dim intAccomId As Integer = objFunction.ReturnInteger(Session("AccomId"))
            Dim dstAccomPhoto As New DataSet()
            dstAccomPhoto = (New clsDLAccomPhotos()).GetAccomPhotoDetailByAccomId(intAccomId)
            GRID_Accom_Photos.DataSource = dstAccomPhoto
            GRID_Accom_Photos.DataBind()

            For i As Integer = 0 To GRID_Accom_Photos.Rows.Count - 1
                Dim gRow As GridViewRow = GRID_Accom_Photos.Rows(i)
                Dim hdnImageName As HiddenField = DirectCast(gRow.FindControl("hdnImageName"), HiddenField)
                Dim imgPhoto As Image = DirectCast(gRow.FindControl("IMG_Photo"), Image)
                imgPhoto.ImageUrl = "~/uploadedimages/" + hdnImageName.Value
            Next

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind room gridview
    ''' </summary>
    Protected Sub BindAccomRoomsGridview()

        Try
            Dim intAccomId = objFunction.ReturnInteger(Session("AccomId"))
            Dim dstRoomType As DataSet = (New clsDLAccomRooms()).GetRoomTypeByAccomId(intAccomId)
            GRID_Accom_Rooms.DataSource = dstRoomType
            GRID_Accom_Rooms.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindAccomLinkGridView()

        Try
            Dim intAccomId = objFunction.ReturnInteger(Session("AccomId"))
            Dim dstAccomodationStage As New DataSet()
            dstAccomodationStage = (New clsDLAccomodationStage()).GetAccomodationStageByAccomId(intAccomId)
            GRID_Accom_Links.DataSource = dstAccomodationStage
            GRID_Accom_Links.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to set default value
    ''' </summary>
    Public Function SetDefaultVal(ByVal value As Object) As String
        If value.ToString() = "True" Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    ''' <summary>
    ''' Click event of the button which is used to go back to search
    ''' </summary>
    Protected Sub BUT_Back_to_Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Back_to_Search.Click
        Try
            Session("AccomId") = Nothing
            Response.Redirect("accom_search.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class