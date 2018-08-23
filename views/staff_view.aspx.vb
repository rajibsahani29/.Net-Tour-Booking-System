Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class staff_view
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEStaff As clsBEStaff = New clsBEStaff
    Dim objDLStaff As clsDLStaff = New clsDLStaff

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstStaffMember As DataSet = (New clsDLStaff()).GetStaffMemberFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Staff_Name, dstStaffMember)
                DROP_Staff_Name.Items.Insert(0, New ListItem("Select Staff Member", ""))

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
    ''' This event is used to update staff detail
    ''' </summary>
    Protected Sub BUT_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Update.Click

        Try
            objBEStaff.StaffId = objFunction.ReturnInteger(hdnStaffId.Value)
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
            'If TB_Date_Ended.Text <> "" Then
            '    objBEStaff.DateEnded = Convert.ToDateTime(TB_Date_Ended.Text)
            'Else
            '    objBEStaff.DateEnded = DateTime.MinValue
            'End If
            objBEStaff.DateEnded = (If(TB_Date_Ended.Text <> "", Convert.ToDateTime(TB_Date_Ended.Text), DateTime.MinValue))

            Dim intAffectedRow As Integer = objDLStaff.UpdateStaffMember(objBEStaff)
            Trace.Warn("intAffectedRow = " + Convert.ToString(intAffectedRow))
            Dim intAffectedStaffDetailRow As Integer
            If intAffectedRow > 0 Then
                intAffectedStaffDetailRow = objDLStaff.UpdateStaffMemberDetail(objBEStaff)
                Trace.Warn("intAffectedStaffDetailRow = " + Convert.ToString(intAffectedStaffDetailRow))
            End If

            If intAffectedRow > 0 And intAffectedStaffDetailRow > 0 Then
                Session("feedback_call") = "1"
                Session("error_msg") = "Staff details have been updated."
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            Response.Redirect("staff_view.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to deactivate staff member
    ''' </summary>
    Protected Sub BUT_Deactivate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Deactivate.Click

        objBEStaff.StaffId = objFunction.ReturnInteger(hdnStaffId.Value)
        objBEStaff.Active = hdnStaffRecStatus.Value
        Dim intAffectedRow As Integer = objDLStaff.UpdateStaffMemberRecStatus(objBEStaff)
        If intAffectedRow > 0 Then
            Session("feedback_call") = "1"
            Session("error_msg") = "Updated record status."
        Else
            Session("feedback_call") = "2"
            Session("error_msg") = "Error in updating reccord status."
        End If
        Response.Redirect("staff_view.aspx", False)
    End Sub

    ''' <summary>
    ''' This event is used to cancel the request
    ''' </summary>
    Protected Sub BUT_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Cancel.Click
        Response.Redirect("staff_view.aspx")
    End Sub
End Class





