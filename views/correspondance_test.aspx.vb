
Partial Class correspondance
    Inherits System.Web.UI.Page

    Dim objEmailContent As New clsEmailContent()

    

    Protected Sub BUT_Show_Email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Show_Email.Click

        Try
            Dim strEmailContent As String = ""
            If DROP_Correspondance.SelectedItem.Value <> "" Then

                If DROP_Correspondance.SelectedItem.Value = "1.html" Then
                    strEmailContent = objEmailContent.CustomizedReply("", "", Nothing, "", 0, 0, 0, 0, "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "2.html" Then
                    strEmailContent = objEmailContent.FixedPriceReply("", "", Nothing, "", 0, 0, "", "", 0, "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "3.html" Then
                    strEmailContent = objEmailContent.CustomizedWalkConfirmaionEmail("", 0, 0, Nothing, "", 0, "", 0, Nothing)
                ElseIf DROP_Correspondance.SelectedItem.Value = "4.html" Then
                    strEmailContent = objEmailContent.FixedPriceWalkConfirmaionEmail("", 0, "", 0, Nothing, "", 0, "", 0, Nothing, Nothing)
                ElseIf DROP_Correspondance.SelectedItem.Value = "5.html" Then
                    strEmailContent = objEmailContent.PreviouslyInvoicedClientsEmail("", "", Nothing, 0, "", "", "", 0)
                ElseIf DROP_Correspondance.SelectedItem.Value = "6.html" Then
                    strEmailContent = objEmailContent.ThanksForPayment_FullPayment("", 0)
                ElseIf DROP_Correspondance.SelectedItem.Value = "7.html" Then
                    strEmailContent = objEmailContent.UK_URL("", "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "8.html" Then
                    strEmailContent = objEmailContent.NoOvernightInMilngavie("", "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "9.html" Then
                    strEmailContent = objEmailContent.FollowUpEmailOnWalkCompletion("", "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "10.html" Then
                    strEmailContent = objEmailContent.OnlineEvaluation_ThankYou("")
                ElseIf DROP_Correspondance.SelectedItem.Value = "11.html" Then
                    strEmailContent = objEmailContent.ToSupplier_AccomBookingGeneral("", Nothing, "", Nothing, "", "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "12.html" Then
                    strEmailContent = objEmailContent.ToSupplier_AccomBookingAfterPhoneCall("", Nothing, "", Nothing, "", "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "13.html" Then
                    strEmailContent = objEmailContent.SendBookingConfirmationToSupplier("", Nothing, "", "", "", 0, 0, Nothing, "", "", 0, "", "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "14.html" Then
                    strEmailContent = objEmailContent.SendBookingCancellationToSupplier("", Nothing, "", "", "", 0, 0, Nothing, "", "", 0, "", "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "15.html" Then
                    strEmailContent = objEmailContent.CustomerCancellationReceiptLetter(Nothing, "", "", "", "", "", "", "", "", "", "", "", Nothing, 0, "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "16.html" Then
                    strEmailContent = objEmailContent.CreditCardDetailsRequestToHoldRoom("")
                ElseIf DROP_Correspondance.SelectedItem.Value = "17.html" Then
                    strEmailContent = objEmailContent.ConfirmToAgent("", Nothing, "", Nothing, "", "", "", "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "18.html" Then
                    strEmailContent = objEmailContent.ReceiveChangedBooking("")
                ElseIf DROP_Correspondance.SelectedItem.Value = "19.html" Then
                    strEmailContent = objEmailContent.ConfirmChangedBookingToCustomer_Successful("", "")
                ElseIf DROP_Correspondance.SelectedItem.Value = "20.html" Then
                    strEmailContent = objEmailContent.ConfirmChangedBookingToCustomer_NotSuccessful("")
                ElseIf DROP_Correspondance.SelectedItem.Value = "21.html" Then
                    strEmailContent = objEmailContent.DepositReceived("", "", 0, Nothing)
                End If

                Dim TemplateFile As String = Convert.ToString(DROP_Correspondance.SelectedItem.Value)
                TB_Editor.Text = ""
                'TB_Editor.Text = Convert.ToString(ReadHtmlPage(TemplateFile))
                TB_Editor.Text = strEmailContent
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub BUT_Send_Email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Send_Email.Click

        Dim objEmail As New clsEmail

        'Dim intMailStatus = clsEmail.sendemail(TB_name.Text, TB_email.Text, "Test Email", "Test Msg", DROP_Correspondance.SelectedItem.Value, Me)
        Dim intMailStatus = clsEmail.SendEmail(TB_name.Text, TB_email.Text, "Test Email", "Test Msg", TB_Editor.Text, Me)

        If intMailStatus = 1 Then
            Trace.Warn("Mail send successfully")
        Else
            Trace.Warn("Error in mail sending")
        End If

    End Sub
End Class





