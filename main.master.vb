
Partial Class main
    Inherits System.Web.UI.MasterPage

    Dim objFunction As New clsCommon()

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Page.IsPostBack Then
            'remove the class to animate
            feedback_layer.Attributes.Remove("class")
            feedback_layer2.Attributes.Remove("class")
        End If

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            LABEL_LoginUserName.Text = objFunction.ReturnString(Session("LoginUserName"))

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub


    'Function to be called to display the feedback layer
    'whichOne 0=info, 1=error
    'the feedback layer will pop down for a couple of secs and then go back up
    Public Sub show_feedback_layer(whichOne As Integer, textx As String)

        If (whichOne = 1) Then
            'normal feedback layer
            feedback_layer_text.Text = textx
            'add the class to animate
            feedback_layer.Attributes.Add("class", "slide-in-topx")
        ElseIf (whichOne = 2) Then
            'warning error layer
            feedback_layer_text2.Text = textx
            'add the class to animate
            feedback_layer2.Attributes.Add("class", "slide-in-topx")
        End If
    End Sub

    'Function to be called to send an email
    'email settings may be changed before LIVE
    'the body text should be set before calling
    Public Function sendemail(ByVal namex As String, ByVal emailx As String, ByVal subjectx As String, ByVal textx As String) As Integer

        Try
            'SMTP settings
            Dim obj As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient("mail.systems.easyways.co.uk", 25)
            'login details
            obj.Credentials = New System.Net.NetworkCredential("donotreply@systems.easyways.co.uk", "d7jh6kH4J2HG")
            'setup a new object
            Dim Mailmsg As New System.Net.Mail.MailMessage
            'housekeeping
            Mailmsg.To.Clear()
            'whom is it going to?
            Dim emailto As String = namex & " <" & emailx & ">"
            'set this to send to
            Mailmsg.To.Add(New System.Net.Mail.MailAddress(emailto))
            'whom is it from
            Mailmsg.From = New System.Net.Mail.MailAddress("Easyways <donotreply@tentaclesolutions.co.uk>")
            'set the subject
            Mailmsg.Subject = subjectx
            'set the body text
            Dim bodytext As String = textx
            'set the signature 
            bodytext = bodytext & vbCrLf & vbCrLf & "Staff @ Easyways" & vbCrLf & vbCrLf
            'maybe some more? TBC
            bodytext = bodytext & ""
            'set this body text to the mail object
            Mailmsg.Body = bodytext
            'send!
            obj.Send(Mailmsg)
            'success
            Return 1
        Catch ex As Exception
            'problem - send feedback layer
            show_feedback_layer(1, ex.Message)
            Return 0
        End Try
    End Function

    'Image uploader
    'pass in the file uploader control
    Public Function SaveFile(ByVal FileUpload1 As FileUpload) As String

        ' Specify the path to save the uploaded file to.
        Dim savePath As String = "D:\WWWRoot\dev1412.systems.easyways.co.uk\www\uploadedimages"
        ' Get the name of the file to upload.
        Dim fileName As String
        'the control to be used 
        fileName = FileUpload1.FileName
        'the filename to be used
        fileName = FileUpload1.FileName
        ' Create the path and file name to check for duplicates.
        Dim pathToCheck As String = savePath + fileName
        ' Create a temporary file name to use for checking duplicates.
        Dim tempfileName As String
        ' Check to see if a file already exists with the
        ' same name as the file to upload.        
        If (System.IO.File.Exists(pathToCheck)) Then
            Dim counter As Integer = CInt(Math.Ceiling(Rnd() * 99999)) + 1
            While (System.IO.File.Exists(pathToCheck))
                ' If a file with this name already exists,
                ' prefix the filename with a number.
                tempfileName = counter.ToString() + "_" + fileName
                pathToCheck = savePath + tempfileName
                counter = counter + 1
            End While
            'save this new file name
            fileName = tempfileName
        End If
        ' Append the name of the file to upload to the path.
        savePath += fileName
        ' Call the SaveAs method to save the uploaded
        ' file to the specified directory. 
        FileUpload1.SaveAs(savePath)
        'return the path+filename for the database
        Return fileName
    End Function

End Class

