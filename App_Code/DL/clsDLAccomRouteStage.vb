Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAccomRouteStage
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accom route stage.
        ''' </summary>
        Public Function AddAccomRouteStage(ByVal objBEAccomRouteStage As clsBEAccomRouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomRouteStage")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomRouteStage.AccomId)
                cmd.Parameters.AddWithValue("StageId", objBEAccomRouteStage.StageId)
                cmd.Parameters.AddWithValue("Sequence", objBEAccomRouteStage.Sequence)
                cmd.Parameters.AddWithValue("BookingId", objBEAccomRouteStage.BookingId)
                cmd.Parameters.AddWithValue("RouteStageId", objBEAccomRouteStage.RouteStageId)

                Dim intAccomRouteStageId As Integer = ExecuteNoneQueryByCommand(cmd, "AddAccomRouteStage", "Y")
                Return intAccomRouteStageId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update accom route stage sequence by id.
        ''' </summary>
        Public Function UpdateAccomRouteStageSequenceById(ByVal objBEAccomRouteStage As clsBEAccomRouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateAccomRouteStageSequenceById")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomRouteStage.AccomStageId)
                cmd.Parameters.AddWithValue("Sequence", objBEAccomRouteStage.Sequence)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateAccomRouteStageSequenceById")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update set_paid by accom_stage_id.
        ''' </summary>
        Public Function UpdateSetPaidById(ByVal objBEAccomRouteStage As clsBEAccomRouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateSetPaidById")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomRouteStage.AccomStageId)
                cmd.Parameters.AddWithValue("SetPaid", objBEAccomRouteStage.SetPaid)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateSetPaidById")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update supplier note by accom_stage_id.
        ''' </summary>
        Public Function UpdateSupplierNoteById(ByVal objBEAccomRouteStage As clsBEAccomRouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateSupplierNoteById")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomRouteStage.AccomStageId)
                cmd.Parameters.AddWithValue("SupplierNote", objBEAccomRouteStage.SupplierNote)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateSupplierNoteById")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update client note by accom_stage_id.
        ''' </summary>
        Public Function UpdateClientNoteById(ByVal objBEAccomRouteStage As clsBEAccomRouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientNoteById")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomRouteStage.AccomStageId)
                cmd.Parameters.AddWithValue("ClientNote", objBEAccomRouteStage.ClientNote)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientNoteById")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update invoice note by accom_stage_id.
        ''' </summary>
        Public Function UpdateInvoiceNoteById(ByVal objBEAccomRouteStage As clsBEAccomRouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateInvoiceNoteById")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomRouteStage.AccomStageId)
                cmd.Parameters.AddWithValue("InvoiceNote", objBEAccomRouteStage.InvoiceNote)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateInvoiceNoteById")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accom route stage.
        ''' </summary>
        Public Function DeleteAccomRouteStage(ByVal objBEAccomRouteStage As clsBEAccomRouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomRouteStage")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomRouteStage.AccomStageId)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomRouteStage")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accom_stage by bookingid.
        ''' </summary>
        Public Function DeleteAccomRouteStageByBookingId(ByVal intBookingId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomRouteStageByBookingId")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomRouteStageByBookingId")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accom route stage.
        ''' </summary>
        Public Function GetAccomRouteStage(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomRouteStage")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomRouteStage")
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
        ''' This function is used to check duplicate record.
        ''' </summary>
        Public Function CheckDuplicateRecord(ByVal objBEAccomRouteStage As clsBEAccomRouteStage, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckDuplicateRecord")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomRouteStage.AccomId)
                cmd.Parameters.AddWithValue("StageId", objBEAccomRouteStage.StageId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "CheckDuplicateRecord")
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
        ''' This function is used to get accommodation details and fill in dropdown.
        ''' </summary>
        Public Function GetAccommodationForStageFillInDD(ByVal intStageId As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccommodationForStageFillInDD")
                cmd.Parameters.AddWithValue("StageId", intStageId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccommodationForStageFillInDD")
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
        ''' This function is used to get accom route stage by booking id.
        ''' </summary>
        Public Function GetAccomRouteStageByBookingId(ByVal objBEAccomRouteStage As clsBEAccomRouteStage, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomRouteStageByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEAccomRouteStage.BookingId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomRouteStageByBookingId")
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
        ''' This function is used to get distinct stage name from accom route stage by booking id.
        ''' </summary>
        Public Function GetStageNameFromAccomRouteStageByBookingId(ByVal intBookingId As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetStageNameFromAccomRouteStageByBookingId")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetStageNameFromAccomRouteStageByBookingId")
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
        ''' This function is used to get accom route stage by booking id.
        ''' </summary>
        Public Function GetAccomRouteStageByBookingIdFillInDD(ByVal intBookingId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomRouteStageByBookingIdFillInDD")
                cmd.Parameters.AddWithValue("BookingId", intBookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomRouteStageByBookingIdFillInDD")
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
        ''' This function is used to accom comment by accom stage id.
        ''' </summary>
        Public Function GetAccomCommentByAccomStageId(ByVal objBEAccomRouteStage As clsBEAccomRouteStage) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomCommentByAccomStageId")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomRouteStage.AccomStageId)
                cmd.Parameters.AddWithValue("BookingId", objBEAccomRouteStage.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomCommentByAccomStageId")
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
        ''' This function is used to accom detail by accom stage id.
        ''' </summary>
        Public Function GetAccomByAccomStageId(ByVal objBEAccomRouteStage As clsBEAccomRouteStage) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomByAccomStageId")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomRouteStage.AccomStageId)
                cmd.Parameters.AddWithValue("BookingId", objBEAccomRouteStage.BookingId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomByAccomStageId")
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
        ''' This function is used to update accom id by accom stage id.
        ''' </summary>
        Public Function UpdateAccomIdByAccomStageId(ByVal objBEAccomRouteStage As clsBEAccomRouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateAccomIdByAccomStageId")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomRouteStage.AccomStageId)
                cmd.Parameters.AddWithValue("BookingId", objBEAccomRouteStage.BookingId)
                cmd.Parameters.AddWithValue("AccomId", objBEAccomRouteStage.AccomId)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateAccomIdByAccomStageId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update direction by accom stage id.
        ''' </summary>
        Public Function UpdateDirectionByAccomStageId(ByVal objBEAccomRouteStage As clsBEAccomRouteStage) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateDirectionByAccomStageId")
                cmd.Parameters.AddWithValue("AccomStageId", objBEAccomRouteStage.AccomStageId)
                cmd.Parameters.AddWithValue("Direction", objBEAccomRouteStage.Direction)
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateDirectionByAccomStageId")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get booking detail.
        ''' </summary>
        Public Function GetAccomRouteStageForSearch(ByVal intCompanyId As Integer, ByVal strSearchByName As String, ByVal strSearchByStage As String, ByVal strSearchByPostcode As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccomRouteStage"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomRouteStageForSearch")
                cmd.Parameters.AddWithValue("SearchByName", strSearchByName)
                cmd.Parameters.AddWithValue("SearchByStage", strSearchByStage)
                cmd.Parameters.AddWithValue("SearchByPostcode", strSearchByPostcode)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomRouteStageForSearch")
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