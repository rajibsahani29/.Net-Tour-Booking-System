Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLClientBookingNotes
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add client booking notes detail
        ''' </summary>
        Public Function AddClientBookingNotes(ByVal objBEClientBookingNotes As clsBEClientBookingNotes) As Integer
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spClientBookingNotes"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddClientBookingNotes")
                cmd.Parameters.AddWithValue("Notes", objBEClientBookingNotes.Notes)
                cmd.Parameters.AddWithValue("BookingId", objBEClientBookingNotes.BookingId)
                cmd.Parameters.AddWithValue("DateAdded", DateTime.Now)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddClientBookingNotes")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get additional name detail by booking id
        ''' </summary>
        Public Function GetClientBookingNotesByBookingId(ByVal objBEClientBookingNotes As clsBEClientBookingNotes) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spClientBookingNotes"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientBookingNotesByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEClientBookingNotes.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientBookingNotesByBookingId")
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
        ''' This function is used to perform gridview operation for additional name detail.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEClientBookingNotes As clsBEClientBookingNotes) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientBookingNotes"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateClientBookingNotes")
                    cmd.Parameters.AddWithValue("ClientBookingNotesId", objBEClientBookingNotes.ClientBookingNotesId)
                    cmd.Parameters.AddWithValue("Notes", objBEClientBookingNotes.Notes)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteClientBookingNotesById")
                    cmd.Parameters.AddWithValue("ClientBookingNotesId", objBEClientBookingNotes.ClientBookingNotesId)
                End If
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "PerformGridViewOpertaion")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace