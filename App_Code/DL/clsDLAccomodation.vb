Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL
    Public Class clsDLAccomodation
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add accommodation details.
        ''' </summary>
        Public Function AddAccommodationDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccommodationDetails")
                cmd.Parameters.AddWithValue("Name", objBEAccomodation.Name)
                cmd.Parameters.AddWithValue("Contact", objBEAccomodation.Contact)
                cmd.Parameters.AddWithValue("Address1", objBEAccomodation.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEAccomodation.Address2)
                cmd.Parameters.AddWithValue("City", objBEAccomodation.City)
                cmd.Parameters.AddWithValue("PostCode", objBEAccomodation.PostCode)
                cmd.Parameters.AddWithValue("CountryId", objBEAccomodation.CountryId)
                cmd.Parameters.AddWithValue("Email", objBEAccomodation.Email)
                cmd.Parameters.AddWithValue("Phone", objBEAccomodation.Phone)
                cmd.Parameters.AddWithValue("Mobilex", objBEAccomodation.Mobilex)
                cmd.Parameters.AddWithValue("OpenFrom", objBEAccomodation.OpenFrom)
                cmd.Parameters.AddWithValue("OpenTo", objBEAccomodation.OpenTo)
                cmd.Parameters.AddWithValue("Description", objBEAccomodation.Description)
                cmd.Parameters.AddWithValue("Direction", objBEAccomodation.Direction)
                cmd.Parameters.AddWithValue("Direction2", objBEAccomodation.Direction2)
                cmd.Parameters.AddWithValue("Direction3", objBEAccomodation.Direction3)
                cmd.Parameters.AddWithValue("Direction4", objBEAccomodation.Direction4)
                cmd.Parameters.AddWithValue("CompanyId", objBEAccomodation.CompanyId)
                cmd.Parameters.AddWithValue("StarRating", objBEAccomodation.StarRating)
                cmd.Parameters.AddWithValue("EarliestTimeArrival", objBEAccomodation.EarliestTimeArrival)
                cmd.Parameters.AddWithValue("AccomComment", objBEAccomodation.AccomComment)
                cmd.Parameters.AddWithValue("WebsiteLink", objBEAccomodation.WebsiteLink)
                cmd.Parameters.AddWithValue("DogFriendly", objBEAccomodation.DogFriendly)
                cmd.Parameters.AddWithValue("DogPrice", objBEAccomodation.DogPrice)
                cmd.Parameters.AddWithValue("NoRoom", objBEAccomodation.NoRoom)
                cmd.Parameters.AddWithValue("GoogleMapLink", objBEAccomodation.GoogleMapLink)
                cmd.Parameters.AddWithValue("BedroomConfig", objBEAccomodation.BedroomConfig)
                cmd.Parameters.AddWithValue("DogConstraints", objBEAccomodation.DogConstraints)
                cmd.Parameters.AddWithValue("PaymentPrefer", objBEAccomodation.PaymentPrefer)
                
                Dim intAccomId As Integer = ExecuteNoneQueryByCommand(cmd, "AddAccommodationDetails", "Y")
                Return intAccomId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update accommodation details.
        ''' </summary>
        Public Function UpdateAccommodationDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateAccommodationDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                cmd.Parameters.AddWithValue("Name", objBEAccomodation.Name)
                cmd.Parameters.AddWithValue("Contact", objBEAccomodation.Contact)
                cmd.Parameters.AddWithValue("Address1", objBEAccomodation.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEAccomodation.Address2)
                cmd.Parameters.AddWithValue("City", objBEAccomodation.City)
                cmd.Parameters.AddWithValue("PostCode", objBEAccomodation.PostCode)
                cmd.Parameters.AddWithValue("CountryId", objBEAccomodation.CountryId)
                cmd.Parameters.AddWithValue("Email", objBEAccomodation.Email)
                cmd.Parameters.AddWithValue("Phone", objBEAccomodation.Phone)
                cmd.Parameters.AddWithValue("Mobilex", objBEAccomodation.Mobilex)
                cmd.Parameters.AddWithValue("OpenFrom", objBEAccomodation.OpenFrom)
                cmd.Parameters.AddWithValue("OpenTo", objBEAccomodation.OpenTo)
                cmd.Parameters.AddWithValue("Description", objBEAccomodation.Description)
                cmd.Parameters.AddWithValue("Direction", objBEAccomodation.Direction)
                cmd.Parameters.AddWithValue("Direction2", objBEAccomodation.Direction2)
                cmd.Parameters.AddWithValue("Direction3", objBEAccomodation.Direction3)
                cmd.Parameters.AddWithValue("Direction4", objBEAccomodation.Direction4)
                cmd.Parameters.AddWithValue("StarRating", objBEAccomodation.StarRating)
                cmd.Parameters.AddWithValue("EarliestTimeArrival", objBEAccomodation.EarliestTimeArrival)
                cmd.Parameters.AddWithValue("AccomComment", objBEAccomodation.AccomComment)
                cmd.Parameters.AddWithValue("WebsiteLink", objBEAccomodation.WebsiteLink)
                cmd.Parameters.AddWithValue("DogFriendly", objBEAccomodation.DogFriendly)
                cmd.Parameters.AddWithValue("DogPrice", objBEAccomodation.DogPrice)
                cmd.Parameters.AddWithValue("NoRoom", objBEAccomodation.NoRoom)
                cmd.Parameters.AddWithValue("GoogleMapLink", objBEAccomodation.GoogleMapLink)
                cmd.Parameters.AddWithValue("BedroomConfig", objBEAccomodation.BedroomConfig)
                cmd.Parameters.AddWithValue("DogConstraints", objBEAccomodation.DogConstraints)
                cmd.Parameters.AddWithValue("PaymentPrefer", objBEAccomodation.PaymentPrefer)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateAccommodationDetails")
                
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update accommodation company id.
        ''' </summary>
        Public Function UpdateAccommodationCompanyId(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateAccommodationCompanyId")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                cmd.Parameters.AddWithValue("CompanyId", objBEAccomodation.CompanyId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateAccommodationCompanyId")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add accom facilities detail.
        ''' </summary>
        Public Function AddAccomAccomFacilitiesDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomAccomFacilitiesDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                cmd.Parameters.AddWithValue("AccomFacilitiesId", objBEAccomodation.AccomFacilitiesId)
                cmd.Parameters.AddWithValue("CostEasyway", objBEAccomodation.CostEasyway)
                cmd.Parameters.AddWithValue("CostClient", objBEAccomodation.CostClient)
                cmd.Parameters.AddWithValue("Commentx", objBEAccomodation.Commentx)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomAccomFacilitiesDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accom facilities detail.
        ''' </summary>
        Public Function DeleteAccomAccomFacilitiesDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomAccomFacilitiesDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomAccomFacilitiesDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get accommodation details and fill in dropdown.
        ''' </summary>
        Public Function GetAccomAccomFacilitiesByAccomID(ByVal intAccomId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomAccomFacilitiesByAccomID")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomAccomFacilitiesByAccomID")
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
        ''' This function is used to add accom breakfast detail.
        ''' </summary>
        Public Function AddAccomBreakfastDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomBreakfastDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                cmd.Parameters.AddWithValue("BreakfastId", objBEAccomodation.BreakfastId)
                cmd.Parameters.AddWithValue("BreakfastAmount", objBEAccomodation.BreakfastAmount)
                
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomBreakfastDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accom breakfast detail.
        ''' </summary>
        Public Function DeleteAccomBreakfastDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomBreakfastDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomBreakfastDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add accom payment method detail.
        ''' </summary>
        Public Function AddAccomPaymentMethodDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomPaymentMethodDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                cmd.Parameters.AddWithValue("PaymentMethodId", objBEAccomodation.PaymentMethodId)
                
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomPaymentMethodDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accom payment method detail.
        ''' </summary>
        Public Function DeleteAccomPaymentMethodDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomPaymentMethodDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomPaymentMethodDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add accom banking detail.
        ''' </summary>
        Public Function AddAccomBankingDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomBankingDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                cmd.Parameters.AddWithValue("AccountName", objBEAccomodation.AccountName)
                cmd.Parameters.AddWithValue("AccountNo", objBEAccomodation.AccountNo)
                cmd.Parameters.AddWithValue("SortCode", objBEAccomodation.SortCode)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomBankingDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update accom banking detail.
        ''' </summary>
        Public Function UpdateAccomBankingDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateAccomBankingDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                cmd.Parameters.AddWithValue("AccountName", objBEAccomodation.AccountName)
                cmd.Parameters.AddWithValue("AccountNo", objBEAccomodation.AccountNo)
                cmd.Parameters.AddWithValue("SortCode", objBEAccomodation.SortCode)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateAccomBankingDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add accom memberships detail.
        ''' </summary>
        Public Function AddAccomMembershipsDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomMembershipsDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                cmd.Parameters.AddWithValue("AccomOpMembershipId", objBEAccomodation.AccomOpMembershipId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomMembershipsDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete accom memberships detail.
        ''' </summary>
        Public Function DeleteAccomMembershipsDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAccomMembershipsDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAccomMembershipsDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add accom app detail.
        ''' </summary>
        Public Function AddAccomAppDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAccomAppDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                cmd.Parameters.AddWithValue("IosLink", objBEAccomodation.IosLink)
                cmd.Parameters.AddWithValue("AndroidLink", objBEAccomodation.AndroidLink)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomAppDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update accom app detail.
        ''' </summary>
        Public Function UpdateAccomAppDetails(ByVal objBEAccomodation As clsBEAccomodation) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateAccomAppDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                cmd.Parameters.AddWithValue("IosLink", objBEAccomodation.IosLink)
                cmd.Parameters.AddWithValue("AndroidLink", objBEAccomodation.AndroidLink)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateAccomAppDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to check accom app detail.
        ''' </summary>
        Public Function CheckAccomAppDetails(ByVal objBEAccomodation As clsBEAccomodation) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckAccomAppDetails")
                cmd.Parameters.AddWithValue("AccomId", objBEAccomodation.AccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "CheckAccomAppDetails")
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
        Public Function GetAccommodationDetailFillInDD(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomodationDetailFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomodationDetailFillInDD")
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
        ''' This function is used to get accomodation detail by accom id.
        ''' </summary>
        Public Function GetAccommodationDetailById(ByVal intAccomId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccommodationDetailById")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccommodationDetailById")
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
        ''' This function is used to get accomodation facility detail by accom id.
        ''' </summary>
        Public Function GetAccomFacilityByAccomId(ByVal intAccomId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomFacilityByAccomId")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomFacilityByAccomId")
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
        ''' This function is used to get accomodation brakfast detail by accom id.
        ''' </summary>
        Public Function GetAccomBreakfastByAccomId(ByVal intAccomId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomBreakfastByAccomId")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomBreakfastByAccomId")
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
        ''' This function is used to get accomodation payment method detail by accom id.
        ''' </summary>
        Public Function GetAccomPaymentMethodByAccomId(ByVal intAccomId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomPaymentMethodId")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomPaymentMethodId")
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
        ''' This function is used to get accomodation membership detail by accom id.
        ''' </summary>
        Public Function GetAccomMembershipByAccomId(ByVal intAccomId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAccommodationDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAccomMembershipId")
                cmd.Parameters.AddWithValue("AccomId", intAccomId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAccomMembershipId")
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
