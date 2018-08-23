Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLBookingPayments
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add booking payments.
        ''' </summary>
        Public Function AddBookingPayments(ByVal objBEBookingPayments As clsBEBookingPayments) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingPayments"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddBookingPayments")
                cmd.Parameters.AddWithValue("BookingId", objBEBookingPayments.BookingId)
                cmd.Parameters.AddWithValue("AmountWishToPay", objBEBookingPayments.AmountWishToPay)
                cmd.Parameters.AddWithValue("AmountPaid", objBEBookingPayments.AmountPaid)
                cmd.Parameters.AddWithValue("PaymentMethodsId", objBEBookingPayments.PaymentMethodsId)
                cmd.Parameters.AddWithValue("BalanceBeforePayment", objBEBookingPayments.BalanceBeforePayment)
                cmd.Parameters.AddWithValue("CCCharge", objBEBookingPayments.CCCharge)
                cmd.Parameters.AddWithValue("DateAdded", DateTime.Now)
                cmd.Parameters.AddWithValue("FirstData", objBEBookingPayments.FirstData)
                cmd.Parameters.AddWithValue("DateReceived", objBEBookingPayments.DateReceived)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddBookingPayments")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accom stage room detail by booking id.
        ''' </summary>
        Public Function GetBookingPaymentsByBookingId(ByVal objBEBookingPayments As clsBEBookingPayments) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spBookingPayments"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingPaymentsByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEBookingPayments.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingPaymentsByBookingId")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete booking payments by id.
        ''' </summary>
        Public Function DeleteBookingPaymentsById(ByVal objBEBookingPayments As clsBEBookingPayments) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBookingPayments"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteBookingPaymentsById")
                cmd.Parameters.AddWithValue("BookingPaymentsId", objBEBookingPayments.BookingPaymentsId)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteBookingPaymentsById")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace