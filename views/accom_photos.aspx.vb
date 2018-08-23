Imports System.Data
Imports System.IO
Imports Easyway.BE
Imports Easyway.DL

Partial Class accom_photos
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEAccomPhotos As clsBEAccomPhotos = New clsBEAccomPhotos
    Dim objDLAccomPhotos As clsDLAccomPhotos = New clsDLAccomPhotos

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

                Trace.Warn("EditAccomIdForPhoto = " + objFunction.ReturnString(Session("EditAccomIdForPhoto")))
                If objFunction.ReturnString(Session("EditAccomIdForPhoto")) <> "" Then
                    Trace.Warn("In if EditAccomIdForPhoto = " + objFunction.ReturnString(Session("EditAccomIdForPhoto")))
                    DROP_Accommodation.Items.FindByValue(objFunction.ReturnString(Session("EditAccomIdForPhoto"))).Selected = True
                    BUT_Add_New_Image.Enabled = True
                    BindGridview()
                    Session("EditAccomIdForPhoto") = Nothing
                End If

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add accommodation photo details
    ''' </summary>
    Protected Sub BUT_Add_New_Image_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_New_Image.Click

        Try
            Session("EditAccomIdForPhoto") = objFunction.ReturnString(DROP_Accommodation.SelectedItem.Value)

            If FILE_Photo.HasFile = True Then
                Dim strFileExtension As String = Path.GetExtension(FILE_Photo.PostedFile.FileName)

                If strFileExtension = ".jpg" Or strFileExtension = ".jpeg" Or strFileExtension = ".png" Or strFileExtension = ".gif" Then
                    Dim random As New Random
                    Dim strRandomNo As String = objFunction.ReturnString(random.Next(100000, 999999))
                    Dim strFileName As String = strRandomNo + "_" + objFunction.ReturnString(DROP_Accommodation.SelectedItem.Value) + "_Img" + strFileExtension
                    FILE_Photo.SaveAs(Server.MapPath("~/uploadedimages/" + strFileName))

                    objBEAccomPhotos.AccomId = objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value)
                    objBEAccomPhotos.PhotoLocation = strFileName
                    If CHK_Main_Image.Checked = True Then
                        objBEAccomPhotos.DefaultImg = False
                        objDLAccomPhotos.UpdateDefaultImageStatus(objBEAccomPhotos)
                        objBEAccomPhotos.DefaultImg = True
                    Else
                        objBEAccomPhotos.DefaultImg = False
                    End If

                    Dim intAffectedRow As Integer = objDLAccomPhotos.AddAccomPhotos(objBEAccomPhotos)
                    If intAffectedRow > 0 Then
                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        objBEActivity.Descx = DROP_Accommodation.SelectedItem.Text + " photos have been updated by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "New photo has been added"
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                Else
                    Session("feedback_call") = "2"
                    Session("error_msg") = "Upload only jpg, jpeg, png & gif image file."
                End If

            End If
            Response.Redirect("accom_photos.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to change the dropdown index
    ''' </summary>
    Protected Sub DROP_Accommodation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROP_Accommodation.SelectedIndexChanged
        BUT_Add_New_Image.Enabled = True
        BindGridview()
    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindGridview()

        Try
            Dim intAccomId As Integer = objFunction.ReturnInteger(DROP_Accommodation.SelectedItem.Value)
            Dim dstAccomPhoto As New DataSet()
            dstAccomPhoto = (New clsDLAccomPhotos()).GetAccomPhotoDetailByAccomId(intAccomId)
            GridView1.DataSource = dstAccomPhoto
            GridView1.DataBind()

            For i As Integer = 0 To GridView1.Rows.Count - 1
                Dim gRow As GridViewRow = GridView1.Rows(i)
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
    ''' OnRowDataBound event of the GridView1
    ''' </summary>
    Protected Sub GridView1_OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lb As LinkButton = DirectCast(e.Row.Cells(3).Controls(0), LinkButton)
                If lb IsNot Nothing Then
                    If lb.Text = "Delete" Then
                        lb.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record ?')")
                    End If
                End If
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GridView1
    ''' </summary>
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            'GridView1.PageIndex = e.NewPageIndex
            'BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowDeleting event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Try
            Session("EditAccomIdForPhoto") = objFunction.ReturnString(DROP_Accommodation.SelectedItem.Value)
            Dim intAccomPhotoId As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("id")))
            Dim strFileName As String = objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("photoLoc"))
            Dim intAffectedRow As Integer = objDLAccomPhotos.DeleteAccomPhotoById(intAccomPhotoId)
            If intAffectedRow > 0 Then

                File.Delete(Server.MapPath("~/uploadedimages/" + strFileName))

                'Add Activity - Start
                Dim objBEActivity As New clsBEActivity
                objBEActivity.Descx = objFunction.ReturnString(DROP_Accommodation.SelectedItem.Text) + " photos have been updated by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                Dim objDLActivity As New clsDLActivity
                objDLActivity.AddActivity(objBEActivity)
                'Add Activity - End
                Session("feedback_call") = "1"
                Session("error_msg") = "Photo has been updated"
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "There was a system error. If this error persists please contact technical support."
            End If
            'GridView1.EditIndex = -1
            'BindGridview()
            Response.Redirect("accom_photos.aspx", False)
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

End Class





