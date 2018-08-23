Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class accom_add_rooms
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEAccomRooms As clsBEAccomRooms = New clsBEAccomRooms
    Dim objDLAccomRooms As clsDLAccomRooms = New clsDLAccomRooms

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

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstAccomodation As DataSet = (New clsDLAccomodation()).GetAccommodationDetailFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Accommodation, dstAccomodation)
                DROP_Accommodation.Items.Insert(0, New ListItem("Select Accommodation", ""))

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of deropdown
    ''' </summary>
    Protected Sub DROP_Accommodation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Accommodation.SelectedIndexChanged

        Try
            DROP_Room_Type.Enabled = True
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstRoomType As DataSet = (New clsDLRoomType()).GetRoomTypeFillInDD(intCompanyId)
            objFunction.FillDropDownByDataSet(DROP_Room_Type, dstRoomType)
            DROP_Room_Type.Items.Insert(0, New ListItem("Select Room Type", ""))

            CHKLIST_Room_Facilities.Items.Clear()
            CHKLIST_Room_Options.Items.Clear()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of deropdown
    ''' </summary>
    Protected Sub DROP_Room_Type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Room_Type.SelectedIndexChanged

        Try
            CHKLIST_Room_Facilities.Items.Clear()
            CHKLIST_Room_Options.Items.Clear()

            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstRoomFacilities As DataSet = (New clsDLRoomFacilities()).GetRoomFacilitiesFillInDD(intCompanyId)
            If objFunction.CheckDataSet(dstRoomFacilities) Then
                For i As Integer = 0 To dstRoomFacilities.Tables(0).Rows.Count - 1
                    Dim item As New ListItem()
                    item.Text = objFunction.ReturnString(dstRoomFacilities.Tables(0).Rows(i)("Value"))
                    item.Value = objFunction.ReturnString(dstRoomFacilities.Tables(0).Rows(i)("Id"))
                    'item.Attributes("class") = "clsPaymentMethodId_" + objFunction.ReturnString(dstRoomFacilities.Tables(0).Rows(i)("Id"))
                    CHKLIST_Room_Facilities.Items.Add(item)
                Next
            End If

            Dim dstRoomtypeOptionsDesc As DataSet = (New clsDLRoomTypeOptions()).GetRoomTypeOptionsFillInDD(intCompanyId)
            If objFunction.CheckDataSet(dstRoomtypeOptionsDesc) Then
                For i As Integer = 0 To dstRoomtypeOptionsDesc.Tables(0).Rows.Count - 1
                    Dim item As New ListItem()
                    item.Text = objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(i)("Value"))
                    item.Value = objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(i)("Id"))
                    'item.Attributes("class") = "clsPaymentMethodId_" + objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(i)("Id"))
                    CHKLIST_Room_Options.Items.Add(item)
                Next
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add accommodation room type detail
    ''' </summary>
    Protected Sub BUT_Add_New_Room_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_New_Room.Click

        Try
            If IsNumeric(TB_EW_Cost.Text) And IsNumeric(TB_Client_Cost.Text) Then

                objBEAccomRooms.AccomId = objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value)
                objBEAccomRooms.RoomTypeId = objFunction.ReturnInteger(DROP_Room_Type.SelectedItem.Value)
                objBEAccomRooms.CostEasyway = objFunction.ReturnDouble(TB_EW_Cost.Text)
                objBEAccomRooms.CostClient = objFunction.ReturnDouble(TB_Client_Cost.Text)

                Dim intAccomRoomTypeId As Integer = objDLAccomRooms.AddAccomRoomTypeDetails(objBEAccomRooms)
                objBEAccomRooms.AccomRoomTypeId = intAccomRoomTypeId

                For Each li As ListItem In CHKLIST_Room_Facilities.Items
                    If li.Selected Then
                        objBEAccomRooms.RoomFacilitiesId = objFunction.ReturnInteger(li.Value)
                        objDLAccomRooms.AddAccomRoomTypeFacilitiesDetails(objBEAccomRooms)
                    End If
                Next

                For Each li As ListItem In CHKLIST_Room_Options.Items
                    If li.Selected Then
                        objBEAccomRooms.RoomTypeOptionsDescId = objFunction.ReturnInteger(li.Value)
                        objDLAccomRooms.AddRoomTypeOptionsDetails(objBEAccomRooms)
                    End If
                Next

                If intAccomRoomTypeId > 0 Then
                    'Add Activity - Start
                    Dim objBEActivity As New clsBEActivity
                    objBEActivity.Descx = objFunction.ReturnString(DROP_Room_Type.SelectedItem.Text) + " has been added to " + objFunction.ReturnString(DROP_Accommodation.SelectedItem.Text) + " by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                    objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                    Dim objDLActivity As New clsDLActivity
                    objDLActivity.AddActivity(objBEActivity)
                    'Add Activity - End
                    Session("feedback_call") = "1"
                    Session("error_msg") = "New room has been added"
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "WARNING - Record was NOT added - please check the costing entries"
            End If
            Response.Redirect("accom_add_rooms.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub
End Class





