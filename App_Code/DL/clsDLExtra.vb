Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLExtra
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add extra details.
        ''' </summary>
        Public Function AddExtraDetails(ByVal objBEExtra As clsBEExtra) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddExtraDetails")
                cmd.Parameters.AddWithValue("Name", objBEExtra.Name)
                cmd.Parameters.AddWithValue("ExtraTypeId", objBEExtra.ExtraTypeId)
                cmd.Parameters.AddWithValue("ContactName", objBEExtra.ContactName)
                cmd.Parameters.AddWithValue("Address1", objBEExtra.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEExtra.Address2)
                cmd.Parameters.AddWithValue("PostCode", objBEExtra.PostCode)
                cmd.Parameters.AddWithValue("City", objBEExtra.City)
                cmd.Parameters.AddWithValue("CountryId", objBEExtra.CountryId)
                cmd.Parameters.AddWithValue("Email", objBEExtra.Email)
                cmd.Parameters.AddWithValue("Phone", objBEExtra.Phone)
                cmd.Parameters.AddWithValue("MaxNumber", objBEExtra.MaxNumber)
                cmd.Parameters.AddWithValue("CompanyId", objBEExtra.CompanyId)
                cmd.Parameters.AddWithValue("DateAdded", DateTime.Now)
                cmd.Parameters.AddWithValue("GoogleDoc", objBEExtra.GoogleDoc)
                cmd.Parameters.AddWithValue("WebsiteUrl", objBEExtra.WebsiteUrl)
                cmd.Parameters.AddWithValue("Mobile", objBEExtra.Mobile)
                cmd.Parameters.AddWithValue("OpenFrom", objBEExtra.OpenFrom)
                cmd.Parameters.AddWithValue("OpenTo", objBEExtra.OpenTo)
                cmd.Parameters.AddWithValue("ExtGoogleDoc", objBEExtra.ExtGoogleDoc)

                Dim intExtraId As Integer = ExecuteNoneQueryByCommand(cmd, "AddExtraDetails", "Y")
                Return intExtraId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update extra details.
        ''' </summary>
        Public Function UpdateExtraDetails(ByVal objBEExtra As clsBEExtra) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateExtraDetails")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtra.ExtraId)
                cmd.Parameters.AddWithValue("Name", objBEExtra.Name)
                cmd.Parameters.AddWithValue("ExtraTypeId", objBEExtra.ExtraTypeId)
                cmd.Parameters.AddWithValue("ContactName", objBEExtra.ContactName)
                cmd.Parameters.AddWithValue("Address1", objBEExtra.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEExtra.Address2)
                cmd.Parameters.AddWithValue("PostCode", objBEExtra.PostCode)
                cmd.Parameters.AddWithValue("City", objBEExtra.City)
                cmd.Parameters.AddWithValue("CountryId", objBEExtra.CountryId)
                cmd.Parameters.AddWithValue("Email", objBEExtra.Email)
                cmd.Parameters.AddWithValue("Phone", objBEExtra.Phone)
                cmd.Parameters.AddWithValue("MaxNumber", objBEExtra.MaxNumber)
                cmd.Parameters.AddWithValue("DateAmended", DateTime.Now)
                cmd.Parameters.AddWithValue("GoogleDoc", objBEExtra.GoogleDoc)
                cmd.Parameters.AddWithValue("WebsiteUrl", objBEExtra.WebsiteUrl)
                cmd.Parameters.AddWithValue("Mobile", objBEExtra.Mobile)
                cmd.Parameters.AddWithValue("OpenFrom", objBEExtra.OpenFrom)
                cmd.Parameters.AddWithValue("OpenTo", objBEExtra.OpenTo)
                cmd.Parameters.AddWithValue("ExtGoogleDoc", objBEExtra.ExtGoogleDoc)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateExtraDetails")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update extra company id.
        ''' </summary>
        Public Function UpdateExtraCompanyId(ByVal objBEExtra As clsBEExtra) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateExtraCompanyId")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtra.ExtraId)
                cmd.Parameters.AddWithValue("CompanyId", objBEExtra.CompanyId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateExtraCompanyId")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add extra banking details.
        ''' </summary>
        Public Function AddExtraBankingDetails(ByVal objBEExtra As clsBEExtra) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddExtraBankingDetails")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtra.ExtraId)
                cmd.Parameters.AddWithValue("AccountName", objBEExtra.AccountName)
                cmd.Parameters.AddWithValue("AccountNo", objBEExtra.AccountNo)
                cmd.Parameters.AddWithValue("SortCode", objBEExtra.SortCode)
                
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddExtraBankingDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update extra banking details.
        ''' </summary>
        Public Function UpdateExtraBankingDetails(ByVal objBEExtra As clsBEExtra) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateExtraBankingDetails")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtra.ExtraId)
                cmd.Parameters.AddWithValue("AccountName", objBEExtra.AccountName)
                cmd.Parameters.AddWithValue("AccountNo", objBEExtra.AccountNo)
                cmd.Parameters.AddWithValue("SortCode", objBEExtra.SortCode)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateExtraBankingDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to check extra banking details.
        ''' </summary>
        Public Function CheckExtraBankingDetails(ByVal objBEExtra As clsBEExtra) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckExtraBankingDetails")
                cmd.Parameters.AddWithValue("ExtraId", objBEExtra.ExtraId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "CheckExtraBankingDetails")
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
        ''' This function is used to get extra details and fill in dropdown.
        ''' </summary>
        Public Function GetExtraDetailFillInDD(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtraDetailFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtraDetailFillInDD")
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
        ''' This function is used to get extra details by extra type id and fill in dropdown.
        ''' </summary>
        Public Function GetExtraDetailByExtraTypeIdFillInDD(ByVal intExtraTypeId As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtraDetailByExtraTypeIdFillInDD")
                cmd.Parameters.AddWithValue("ExtraTypeId", intExtraTypeId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtraDetailByExtraTypeIdFillInDD")
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
        ''' This function is used to get extra details by extra type id and fill in dropdown.
        ''' </summary>
        Public Function GetExtraDetailByNotInExtraTypeIdFillInDD(ByVal intExtraTypeId As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtraDetailByNotInExtraTypeIdFillInDD")
                cmd.Parameters.AddWithValue("ExtraTypeId", intExtraTypeId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtraDetailByNotInExtraTypeIdFillInDD")
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
        ''' This function is used to get extra detail by extra id.
        ''' </summary>
        Public Function GetExtraDetailById(ByVal intExtraId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spExtraDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetExtraDetailById")
                cmd.Parameters.AddWithValue("ExtraId", intExtraId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetExtraDetailById")
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