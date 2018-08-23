Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLClient
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add client details.
        ''' </summary>
        Public Function AddClientDetails(ByVal objBEClient As clsBEClient) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddClientDetails")
                cmd.Parameters.AddWithValue("Name1", objBEClient.Name1)
                cmd.Parameters.AddWithValue("Name2", objBEClient.Name2)
                cmd.Parameters.AddWithValue("Address1", objBEClient.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEClient.Address2)
                cmd.Parameters.AddWithValue("City", objBEClient.City)
                cmd.Parameters.AddWithValue("PostCode", objBEClient.PostCode)
                cmd.Parameters.AddWithValue("CountryId", objBEClient.CountryId)
                cmd.Parameters.AddWithValue("Email", objBEClient.Email)
                cmd.Parameters.AddWithValue("Phone1", objBEClient.Phone1)
                cmd.Parameters.AddWithValue("Phone2", objBEClient.Phone2)
                cmd.Parameters.AddWithValue("SexId", objBEClient.SexId)
                cmd.Parameters.AddWithValue("NewsLetter", objBEClient.NewsLetter)
                cmd.Parameters.AddWithValue("AdditionalInfo", objBEClient.AdditionalInfo)
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)
                cmd.Parameters.AddWithValue("MarketingId", objBEClient.MarketingId)
                cmd.Parameters.AddWithValue("UrlName", objBEClient.UrlName)

                Dim intClientId As Integer = ExecuteNoneQueryByCommand(cmd, "AddClientDetails", "Y")
                Return intClientId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update agent details.
        ''' </summary>
        Public Function UpdateClientDetails(ByVal objBEClient As clsBEClient) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientDetails")
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                cmd.Parameters.AddWithValue("Name1", objBEClient.Name1)
                cmd.Parameters.AddWithValue("Name2", objBEClient.Name2)
                cmd.Parameters.AddWithValue("Address1", objBEClient.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEClient.Address2)
                cmd.Parameters.AddWithValue("City", objBEClient.City)
                cmd.Parameters.AddWithValue("PostCode", objBEClient.PostCode)
                cmd.Parameters.AddWithValue("CountryId", objBEClient.CountryId)
                cmd.Parameters.AddWithValue("Email", objBEClient.Email)
                cmd.Parameters.AddWithValue("Phone1", objBEClient.Phone1)
                cmd.Parameters.AddWithValue("Phone2", objBEClient.Phone2)
                cmd.Parameters.AddWithValue("SexId", objBEClient.SexId)
                cmd.Parameters.AddWithValue("NewsLetter", objBEClient.NewsLetter)
                cmd.Parameters.AddWithValue("AdditionalInfo", objBEClient.AdditionalInfo)
                cmd.Parameters.AddWithValue("MarketingId", objBEClient.MarketingId)
                cmd.Parameters.AddWithValue("UrlName", objBEClient.UrlName)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientDetails")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get client detail by agent id.
        ''' </summary>
        Public Function GetClientDetailById(ByVal objBEClient As clsBEClient) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientDetailById")
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientDetailById")
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
        ''' This function is used to get client detail by agent id.
        ''' </summary>
        Public Function GetClientDetailByName(ByVal objBEClient As clsBEClient) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientDetailByName")
                cmd.Parameters.AddWithValue("Name1", objBEClient.Name1)
                cmd.Parameters.AddWithValue("Name2", objBEClient.Name2)
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientDetailByName")
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
        ''' This function is used to update company id for delete client.
        ''' </summary>
        Public Function UpdateCompanyIdForDeleteClient(ByVal objBEClient As clsBEClient) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateCompanyIdForDeleteClient")
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateCompanyIdForDeleteClient")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace