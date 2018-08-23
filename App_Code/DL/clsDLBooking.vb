Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLBooking
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add booking details.
        ''' </summary>
        Public Function AddBooking(ByVal objBEBooking As clsBEBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddBooking")
                cmd.Parameters.AddWithValue("RouteId", objBEBooking.RouteId)
                cmd.Parameters.AddWithValue("UniqueId", objBEBooking.UniqueId)
                cmd.Parameters.AddWithValue("Active", objBEBooking.Active)
                cmd.Parameters.AddWithValue("TotalNumber", objBEBooking.TotalNumber)
                cmd.Parameters.AddWithValue("Customised", objBEBooking.Customised)
                cmd.Parameters.AddWithValue("CompanyId", objBEBooking.CompanyId)
                cmd.Parameters.AddWithValue("NoMales", objBEBooking.NoMales)
                cmd.Parameters.AddWithValue("NoFemales", objBEBooking.NoFemales)
                cmd.Parameters.AddWithValue("NoOther", objBEBooking.NoOther)
                cmd.Parameters.AddWithValue("Ensuite", objBEBooking.Ensuite)
                cmd.Parameters.AddWithValue("DogFriendly", objBEBooking.DogFriendly)
                cmd.Parameters.AddWithValue("RouteCostClient", objBEBooking.RouteCostClient)
                cmd.Parameters.AddWithValue("RouteCostEasyways", objBEBooking.RouteCostEasyways)

                Dim intBookingId As Integer = ExecuteNoneQueryByCommand(cmd, "AddBooking", "Y")
                Return intBookingId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add booking details.
        ''' </summary>
        Public Function UpdateBookingMemberNo(ByVal objBEBooking As clsBEBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateBookingMemberNo")
                cmd.Parameters.AddWithValue("BookingId", objBEBooking.BookingId)
                cmd.Parameters.AddWithValue("NoMales", objBEBooking.NoMales)
                cmd.Parameters.AddWithValue("NoFemales", objBEBooking.NoFemales)
                cmd.Parameters.AddWithValue("NoOther", objBEBooking.NoOther)
                cmd.Parameters.AddWithValue("TotalNumber", objBEBooking.TotalNumber)
                cmd.Parameters.AddWithValue("RouteCostClient", objBEBooking.RouteCostClient)
                cmd.Parameters.AddWithValue("RouteCostEasyways", objBEBooking.RouteCostEasyways)
                cmd.Parameters.AddWithValue("RouteId", objBEBooking.RouteId)
                cmd.Parameters.AddWithValue("Ensuite", objBEBooking.Ensuite)
                cmd.Parameters.AddWithValue("Customised", objBEBooking.Customised)
                cmd.Parameters.AddWithValue("DogFriendly", objBEBooking.DogFriendly)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateBookingMemberNo")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update booking unique id.
        ''' </summary>
        Public Function UpdateBookingUniqueId(ByVal objBEBooking As clsBEBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateBookingUniqueId")
                cmd.Parameters.AddWithValue("BookingId", objBEBooking.BookingId)
                cmd.Parameters.AddWithValue("UniqueId", objBEBooking.UniqueId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateBookingUniqueId")
                
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update company id for delete booking.
        ''' </summary>
        Public Function UpdateCompanyIdForDeleteBooking(ByVal objBEBooking As clsBEBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateCompanyIdForDeleteBooking")
                cmd.Parameters.AddWithValue("BookingId", objBEBooking.BookingId)
                cmd.Parameters.AddWithValue("CompanyId", objBEBooking.CompanyId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateCompanyIdForDeleteBooking")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to cancel booking by bookingid
        ''' </summary>
        Public Function CancelBookingByBookingId(ByVal objBEBooking As clsBEBooking) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CancelBookingByBookingId")
                cmd.Parameters.AddWithValue("BookingId", objBEBooking.BookingId)
                cmd.Parameters.AddWithValue("Cancelled", objBEBooking.Cancelled)
                cmd.Parameters.AddWithValue("CancellationDate", objBEBooking.CancellationDate)
                cmd.Parameters.AddWithValue("CancellationAmount", objBEBooking.CancellationAmount)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "CancelBookingByBookingId")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get booking detail.
        ''' </summary>
        Public Function GetBookingDetail(ByVal intCompanyId As Integer, ByVal strSearchByName As String, ByVal strSearchBySurname As String, ByVal strSearchByBookingRef As String, ByVal strSearchByPostcode As String, ByVal strSearchByEmail As String, ByVal strSearchByDate As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingDetail")
                cmd.Parameters.AddWithValue("SearchByName", strSearchByName)
                cmd.Parameters.AddWithValue("SearchBySurname", strSearchBySurname)
                cmd.Parameters.AddWithValue("SearchByBookingRef", strSearchByBookingRef)
                cmd.Parameters.AddWithValue("SearchByPostcode", strSearchByPostcode)
                cmd.Parameters.AddWithValue("SearchByEmail", strSearchByEmail)
                cmd.Parameters.AddWithValue("SearchByDate", strSearchByDate)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingDetail")
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
        ''' This function is used to get booking by id.
        ''' </summary>
        Public Function GetBookingById(ByVal objBEBooking As clsBEBooking) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingById")
                cmd.Parameters.AddWithValue("BookingId", objBEBooking.BookingId)
                cmd.Parameters.AddWithValue("CompanyId", objBEBooking.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingById")
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
        ''' This function is used to get booking detail by id.
        ''' </summary>
        Public Function GetBookingDetailById(ByVal objBEBooking As clsBEBooking, ByVal intAccomStageId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingDetailById")
                cmd.Parameters.AddWithValue("BookingId", objBEBooking.BookingId)
                cmd.Parameters.AddWithValue("CompanyId", objBEBooking.CompanyId)
                cmd.Parameters.AddWithValue("AccomStageId", intAccomStageId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingDetailById")
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
        ''' This function is used to get booking detail by accom stage sequence.
        ''' </summary>
        Public Function GetBookingDetailByAccomStageSeq(ByVal objBEBooking As clsBEBooking, ByVal intSequence As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingDetailByAccomStageSeq")
                cmd.Parameters.AddWithValue("BookingId", objBEBooking.BookingId)
                cmd.Parameters.AddWithValue("CompanyId", objBEBooking.CompanyId)
                cmd.Parameters.AddWithValue("Sequence", intSequence)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingDetailByAccomStageSeq")
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
        ''' This function is used to get booking detail for client search.
        ''' </summary>
        Public Function GetBookingDetailForClientSearch(ByVal intCompanyId As Integer, ByVal strSearchByName As String, ByVal strSearchBySurname As String, ByVal strSearchByPostcode As String, ByVal strSearchByEmail As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spBooking"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBookingDetailForClientSearch")
                cmd.Parameters.AddWithValue("SearchByName", strSearchByName)
                cmd.Parameters.AddWithValue("SearchBySurname", strSearchBySurname)
                cmd.Parameters.AddWithValue("SearchByPostcode", strSearchByPostcode)
                cmd.Parameters.AddWithValue("SearchByEmail", strSearchByEmail)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBookingDetailForClientSearch")
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