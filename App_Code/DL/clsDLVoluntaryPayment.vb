Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLVoluntaryPayment
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to get voluntary payment detail
        ''' </summary>
        Public Function AddVoluntaryPayment(ByVal objBEVoluntaryPayment As clsBEVoluntaryPayment) As Integer
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spVoluntaryPayment"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddVoluntaryPayment")
                cmd.Parameters.AddWithValue("Amount", objBEVoluntaryPayment.Amount)
                cmd.Parameters.AddWithValue("Paid", objBEVoluntaryPayment.Paid)
                cmd.Parameters.AddWithValue("BookingId", objBEVoluntaryPayment.BookingId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddVoluntaryPayment")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update voluntary payment detail by booking id
        ''' </summary>
        Public Function UpdateVoluntaryPaymentByBookingId(ByVal objBEVoluntaryPayment As clsBEVoluntaryPayment) As Integer
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spVoluntaryPayment"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateVoluntaryPaymentByBookingId")
                'cmd.Parameters.AddWithValue("VoluntaryPaymentId", objBEVoluntaryPayment.VoluntaryPaymentId)
                cmd.Parameters.AddWithValue("Amount", objBEVoluntaryPayment.Amount)
                cmd.Parameters.AddWithValue("Paid", objBEVoluntaryPayment.Paid)
                cmd.Parameters.AddWithValue("BookingId", objBEVoluntaryPayment.BookingId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateVoluntaryPaymentByBookingId")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get voluntary payment detail by booking id
        ''' </summary>
        Public Function GetVoluntaryPaymentByBookingId(ByVal objBEVoluntaryPayment As clsBEVoluntaryPayment) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spVoluntaryPayment"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetVoluntaryPaymentByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEVoluntaryPayment.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetVoluntaryPaymentByBookingId")
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

End Namespace