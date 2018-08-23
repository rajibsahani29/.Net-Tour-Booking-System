Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLDietaryNeedsBooking
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add dietary needs detail
        ''' </summary>
        Public Function AddDietaryNeedsBooking(ByVal objBEDietaryNeedsBooking As clsBEDietaryNeedsBooking) As Integer
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spDietaryNeedsBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddDietaryNeedsBooking")
                cmd.Parameters.AddWithValue("DietaryNeeds", objBEDietaryNeedsBooking.DietaryNeeds)
                cmd.Parameters.AddWithValue("BookingId", objBEDietaryNeedsBooking.BookingId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddDietaryNeedsBooking")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update dietary needs detail by booking id
        ''' </summary>
        Public Function UpdateDietaryNeedsBookingByBookingId(ByVal objBEDietaryNeedsBooking As clsBEDietaryNeedsBooking) As Integer
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spDietaryNeedsBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateDietaryNeedsBookingByBookingId")
                'cmd.Parameters.AddWithValue("DietaryNeedsBookingId", objBEDietaryNeedsBooking.DietaryNeedsBookingId)
                cmd.Parameters.AddWithValue("DietaryNeeds", objBEDietaryNeedsBooking.DietaryNeeds)
                cmd.Parameters.AddWithValue("BookingId", objBEDietaryNeedsBooking.BookingId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateDietaryNeedsBookingByBookingId")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get dietary needs detail by booking id
        ''' </summary>
        Public Function GetDietaryNeedsBookingByBookingId(ByVal objBEDietaryNeedsBooking As clsBEDietaryNeedsBooking) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spDietaryNeedsBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetDietaryNeedsBookingByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEDietaryNeedsBooking.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetDietaryNeedsBookingByBookingId")
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