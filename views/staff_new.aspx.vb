Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class staff_new
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEStaff As clsBEStaff = New clsBEStaff
    Dim objDLStaff As clsDLStaff = New clsDLStaff

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TB_phone2.Text = " "
        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            If Not Convert.ToString(Session("RoleId")) = "1" Then
                Response.Redirect("~/views/not_allowed.aspx")
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

                Dim dstRole As DataSet = (New clsDLRole()).GetRoleFillInDD()
                objFunction.FillDropDownByDataSet(DROP_Role, dstRole)
                DROP_Role.Items.Insert(0, New ListItem("Select Role", ""))

                Dim dstSex As DataSet = (New clsDLSex()).GetSexFillInDD()
                RADIO_Gender.DataSource = dstSex
                RADIO_Gender.DataTextField = "Value"
                RADIO_Gender.DataValueField = "ID"
                RADIO_Gender.DataBind()
                RADIO_Gender.Items.FindByText("Male").Selected = True

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add staff detail
    ''' </summary>
    Protected Sub BUT_Add_Staff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Staff.Click

        Try
            objBEStaff.Name1 = TB_firstname.Text
            objBEStaff.Name2 = TB_surname.Text
            objBEStaff.Address1 = TB_Address1.Text
            objBEStaff.Address2 = TB_Address2.Text
            objBEStaff.City = TB_city.Text
            objBEStaff.PostCode = TB_postcode.Text
            objBEStaff.CountryId = objFunction.ReturnInteger(DROP_Country.SelectedItem.Value)
            objBEStaff.SexId = objFunction.ReturnInteger(RADIO_Gender.SelectedItem.Value)
            objBEStaff.Phone1 = TB_phone1.Text
            objBEStaff.Phone2 = TB_phone2.Text
            objBEStaff.AdditionalInfo = TB_Info.Text
            objBEStaff.Password = TB_Password.Text
            objBEStaff.RoleId = objFunction.ReturnInteger(DROP_Role.SelectedItem.Value)
            objBEStaff.DateStarted = (If(TB_Date_Started.Text <> "", Convert.ToDateTime(TB_Date_Started.Text), DateTime.MinValue))
            objBEStaff.CompanyId = objFunction.ReturnString(Session("CompanyId"))

            Dim intStaffId As Integer = objDLStaff.AddStaffMember(objBEStaff)
            Trace.Warn("btn intStaffId = " + Convert.ToString(intStaffId))
            Dim intStaffDetailId As Integer
            If intStaffId > 0 Then
                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objBEStaff.Name1 + " " + objBEStaff.Name2 + " has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End

                objBEStaff.StaffId = intStaffId
                intStaffDetailId = objDLStaff.AddStaffMemberDetail(objBEStaff)
                Trace.Warn("btn intStaffDetailId = " + Convert.ToString(intStaffDetailId))
            End If

            If intStaffId > 0 And intStaffDetailId > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "New staff member has been added."
                TB_firstname.Text = ""
                TB_surname.Text = ""
                TB_Address1.Text = ""
                TB_Address2.Text = ""
                TB_city.Text = ""
                TB_postcode.Text = ""
                DROP_Country.SelectedValue = ""
                RADIO_Gender.SelectedValue = "1"
                TB_phone1.Text = ""
                TB_phone2.Text = ""
                TB_Info.Text = ""
                TB_Password.Text = ""
                DROP_Role.SelectedValue = ""
                TB_Date_Started.Text = ""
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("staff_new.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub
End Class





