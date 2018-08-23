Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class clsEmailContentData
    Inherits BaseDB

    Dim objFunction As New clsCommon()

    ''' <summary>
    ''' This function is used to get agent details and fill in dropdown.
    ''' </summary>
    Public Function CustomizedReply(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "CustomizedReply")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "CustomizedReply")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function FixedPriceReply(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "FixedPriceReply")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "FixedPriceReply")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function CustomizedWalkConfirmaionEmail(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "CustomizedWalkConfirmaionEmail")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "CustomizedWalkConfirmaionEmail")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function FixedPriceWalkConfirmaionEmail(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "FixedPriceReply")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "FixedPriceReply")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function PreviouslyInvoicedClientsEmail(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "PreviouslyInvoicedClientsEmail")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "PreviouslyInvoicedClientsEmail")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function ThanksForPayment_FullPayment(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "ThanksForPayment_FullPayment")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "ThanksForPayment_FullPayment")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    'Public Function UK_URL(ByVal intBookingId As Integer, ByVal intBookingStageId As Integer) As DataSet
    Public Function UK_URL(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "UK_URL")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            'cmd.Parameters.AddWithValue("BookingStageId", intBookingStageId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "UK_URL")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function NoOvernightInMilngavie(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "NoOvernightInMilngavie")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "NoOvernightInMilngavie")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function FollowUpEmailOnWalkCompletion(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "FollowUpEmailOnWalkCompletion")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "FollowUpEmailOnWalkCompletion")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function OnlineEvaluation_ThankYou(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "OnlineEvaluation_ThankYou")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "OnlineEvaluation_ThankYou")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function ToSupplier_AccomBookingGeneral(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "ToSupplier_AccomBookingGeneral")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "ToSupplier_AccomBookingGeneral")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function ToSupplier_AccomBookingAfterPhoneCall(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "ToSupplier_AccomBookingAfterPhoneCall")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "ToSupplier_AccomBookingAfterPhoneCall")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function SendBookingConfirmationToSupplier(ByVal intBookingId As Integer, ByVal intAccomStageId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "SendBookingConfirmationToSupplier")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            cmd.Parameters.AddWithValue("AccomStageId", intAccomStageId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "SendBookingConfirmationToSupplier")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function SendBookingCancellationToSupplier(ByVal intBookingId As Integer, ByVal intAccomStageId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "SendBookingCancellationToSupplier")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            cmd.Parameters.AddWithValue("AccomStageId", intAccomStageId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "SendBookingCancellationToSupplier")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function CustomerCancellationReceiptLetter(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "CustomerCancellationReceiptLetter")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "CustomerCancellationReceiptLetter")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function CreditCardDetailsRequestToHoldRoom(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "CreditCardDetailsRequestToHoldRoom")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "CreditCardDetailsRequestToHoldRoom")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function ConfirmToAgent(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "ConfirmToAgent")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "ConfirmToAgent")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function ReceiveChangedBooking(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "ReceiveChangedBooking")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "ReceiveChangedBooking")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function ConfirmChangedBookingToCustomer_Successful(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "ConfirmChangedBookingToCustomer_Successful")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "ConfirmChangedBookingToCustomer_Successful")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function ConfirmChangedBookingToCustomer_NotSuccessful(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "ConfirmChangedBookingToCustomer_NotSuccessful")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "ConfirmChangedBookingToCustomer_NotSuccessful")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function DepositReceived(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "DepositReceived")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "DepositReceived")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function EmailExtra_IndividualBookingEGTaxi(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "EmailExtra_IndividualBookingEGTaxi")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "EmailExtra_IndividualBookingEGTaxi")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function EmailExtra_IndividualBookingEGTaxi_Repeater(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "EmailExtra_IndividualBookingEGTaxi_Repeater")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "EmailExtra_IndividualBookingEGTaxi_Repeater")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    Public Function EmailExtra_IndividualBookingEGTaxi_Bulk() As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "EmailExtra_IndividualBookingEGTaxi_Bulk")
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "EmailExtra_IndividualBookingEGTaxi_Bulk")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function EmailExtra_IndividualBookingEGTaxi_Bulk_Repeater(ByVal intExtraId As Integer, ByVal intMonthVal As Integer, ByVal intYearVal As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "EmailExtra_IndividualBookingEGTaxi_Bulk_Repeater")
            cmd.Parameters.AddWithValue("ExtraId", intExtraId)
            cmd.Parameters.AddWithValue("MonthVal", intMonthVal)
            cmd.Parameters.AddWithValue("YearVal", intYearVal)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "EmailExtra_IndividualBookingEGTaxi_Bulk_Repeater")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    Public Function EmailBaggageCompany_IndividualBooking_Repeater(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "EmailBaggageCompany_IndividualBooking_Repeater")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "EmailBaggageCompany_IndividualBooking_Repeater")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function EmailBaggageCompany_IndividualBooking_Bulk_Repeater(ByVal intExtraId As Integer, ByVal intMonthVal As Integer, ByVal intYearVal As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "EmailBaggageCompany_IndividualBooking_Bulk_Repeater")
            cmd.Parameters.AddWithValue("ExtraId", intExtraId)
            cmd.Parameters.AddWithValue("MonthVal", intMonthVal)
            cmd.Parameters.AddWithValue("YearVal", intYearVal)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "EmailBaggageCompany_IndividualBooking_Bulk_Repeater")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

    Public Function AgentInvoicedBookings_Email(ByVal intAgentId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "AgentInvoicedBookings_Email")
            cmd.Parameters.AddWithValue("AgentId", intAgentId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "AgentInvoicedBookings_Email")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    Public Function AgentUKURL(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "AgentUKURL")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "AgentUKURL")
            If objFunction.CheckDataSet(dstData) Then
                Return dstData
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

End Class
