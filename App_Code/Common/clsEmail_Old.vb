Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class clsEmail_Old

    Public Shared Function SendEmail(ByVal namex As String, ByVal emailx As String, ByVal subjectx As String, ByVal messageLink As String, ByVal filex As String, ByVal controlx As Control) As Integer

        'Dim TemplateFile As String = HttpContext.Current.Server.MapPath("~/emails/" + filex + ".html")
        'Dim TemplateFile As String = HttpContext.Current.Server.MapPath("~/emails/" + filex)

        'Dim md As MailDefinition = New MailDefinition

        'md.BodyFileName = filex

        'md.From = "Easyways <donotreply@tentaclesolutions.co.uk>" '"rsthelord@gmail.com" '"Easyways <donotreply@tentaclesolutions.co.uk>"

        'md.Subject = subjectx

        'md.Priority = Net.Mail.MailPriority.High

        'md.IsBodyHtml = True

        'Dim replacements As ListDictionary = New ListDictionary
        'replacements.Add("<%To%>", namex)
        'replacements.Add("<%linkx%>", messageLink)

        'Dim msg As System.Net.Mail.MailMessage
        'msg = md.CreateMailMessage(emailx, replacements, controlx)

        'Dim sc As SmtpClient = New SmtpClient()

        'Try
        '    sc.Host = "mail.systems.easyways.co.uk"
        '    'sc.Host = "smtp.gmail.com"
        '    'sc.Port = '587 '25
        '    'sc.Credentials = New System.Net.NetworkCredential("rsthelord@gmail.com", "Keshav123")
        '    sc.Credentials = New System.Net.NetworkCredential("donotreply@systems.easyways.co.uk", "d7jh6kH4J2HG")
        '    sc.Send(msg)

        '    HttpContext.Current.Trace.Warn("Mail Status", "Send Success")

        '    ' sc.Dispose()
        '    Return 1
        'Catch ex As Exception
        '    Return -1
        '    '  sc.Dispose()
        'Finally
        '    '  sc.Dispose()
        'End Try

        Try
            'Dim fromaddr As String = "rsthelord@gmail.com"
            'Dim fromaddr As String = "test@gmail.com"
            'Dim password As String = "pword"
            'Dim strHostName As String = "smtp.gmail.com"
            'Dim intPort As Integer = 587

            Dim fromaddr As String = "donotreply@systems.easyways.co.uk"
            Dim password As String = "d7jh6kH4J2HG"
            Dim strHostName As String = "mail.systems.easyways.co.uk"
            Dim intPort As Integer = 587

            Dim Message As New MailMessage()
            Dim smtp As SmtpClient

            Message.From = New MailAddress(fromaddr)
            smtp = New SmtpClient()
            smtp.Host = strHostName
            smtp.Port = intPort
            smtp.EnableSsl = True
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
            smtp.UseDefaultCredentials = False
            smtp.Credentials = New NetworkCredential(fromaddr, password)
            smtp.TargetName = "STARTTLS/smtp.gmail.com"

            Message.IsBodyHtml = True
            Message.Body = filex
            Message.Subject = subjectx
            Message.[To].Add(emailx)
            smtp.Send(Message)
            Return 1
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return 0
    End Function

End Class
