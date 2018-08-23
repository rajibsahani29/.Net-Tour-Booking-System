Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLAgent
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add agent details.
        ''' </summary>
        Public Function AddAgentDetails(ByVal objBEAgent As clsBEAgent) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAgentDetails")
                cmd.Parameters.AddWithValue("Name", objBEAgent.Name)
                cmd.Parameters.AddWithValue("ContactName", objBEAgent.ContactName)
                cmd.Parameters.AddWithValue("Address1", objBEAgent.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEAgent.Address2)
                cmd.Parameters.AddWithValue("City", objBEAgent.City)
                cmd.Parameters.AddWithValue("PostCode", objBEAgent.PostCode)
                cmd.Parameters.AddWithValue("Email", objBEAgent.Email)
                cmd.Parameters.AddWithValue("Phone", objBEAgent.Phone)
                cmd.Parameters.AddWithValue("CountryId", objBEAgent.CountryId)
                cmd.Parameters.AddWithValue("AdditionalInfo", objBEAgent.AdditionalInfo)
                cmd.Parameters.AddWithValue("CompanyId", objBEAgent.CompanyId)
                cmd.Parameters.AddWithValue("DateAdded", DateTime.Now)
                cmd.Parameters.AddWithValue("BankCharge", objBEAgent.BankCharge)
                cmd.Parameters.AddWithValue("Buyx", objBEAgent.Buyx)

                Dim intAgentId As Integer = ExecuteNoneQueryByCommand(cmd, "AddAgentDetails", "Y")
                Return intAgentId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update agent details.
        ''' </summary>
        Public Function UpdateAgentDetails(ByVal objBEAgent As clsBEAgent) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateAgentDetails")
                cmd.Parameters.AddWithValue("AgentId", objBEAgent.AgentId)
                cmd.Parameters.AddWithValue("Name", objBEAgent.Name)
                cmd.Parameters.AddWithValue("ContactName", objBEAgent.ContactName)
                cmd.Parameters.AddWithValue("Address1", objBEAgent.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEAgent.Address2)
                cmd.Parameters.AddWithValue("City", objBEAgent.City)
                cmd.Parameters.AddWithValue("PostCode", objBEAgent.PostCode)
                cmd.Parameters.AddWithValue("Email", objBEAgent.Email)
                cmd.Parameters.AddWithValue("Phone", objBEAgent.Phone)
                cmd.Parameters.AddWithValue("CountryId", objBEAgent.CountryId)
                cmd.Parameters.AddWithValue("AdditionalInfo", objBEAgent.AdditionalInfo)
                cmd.Parameters.AddWithValue("LastUpdated", DateTime.Now)
                cmd.Parameters.AddWithValue("BankCharge", objBEAgent.BankCharge)
                cmd.Parameters.AddWithValue("Buyx", objBEAgent.Buyx)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateAgentDetails")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add agent contact details.
        ''' </summary>
        Public Function AddAgentContactDetails(ByVal objBEAgent As clsBEAgent) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddAgentContactDetails")
                cmd.Parameters.AddWithValue("AgentId", objBEAgent.AgentId)
                cmd.Parameters.AddWithValue("ACContactName", objBEAgent.ACContactName)
                cmd.Parameters.AddWithValue("ACJobTitle", objBEAgent.ACJobTitle)
                cmd.Parameters.AddWithValue("ACEmail", objBEAgent.ACEmail)
                cmd.Parameters.AddWithValue("ACPhone", objBEAgent.ACPhone)
                cmd.Parameters.AddWithValue("ACOrderx", objBEAgent.ACOrderx)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAgentContactDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete agent contact details.
        ''' </summary>
        Public Function DeleteAgentContactDetails(ByVal objBEAgent As clsBEAgent) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteAgentContactDetails")
                cmd.Parameters.AddWithValue("AgentId", objBEAgent.AgentId)
                
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteAgentContactDetails")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get agent details and fill in dropdown.
        ''' </summary>
        Public Function GetAgentDetailFillInDD(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAgentDetailFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAgentDetailFillInDD")
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
        ''' This function is used to get agent detail by agent id.
        ''' </summary>
        Public Function GetAgentDetailById(ByVal intAgentId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetAgentDetailById")
                cmd.Parameters.AddWithValue("AgentId", intAgentId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetAgentDetailById")
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
        ''' This function is used to get contact detail by agent id.
        ''' </summary>
        Public Function GetContactDetailByAgentId(ByVal intAgentId As Integer, ByVal intACOrderx As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetContactDetailByAgentId")
                cmd.Parameters.AddWithValue("AgentId", intAgentId)
                cmd.Parameters.AddWithValue("ACOrderx", intACOrderx)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetContactDetailByAgentId")
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
        ''' This function is used to upload agent logo.
        ''' </summary>
        Public Function UploadAgentLogo(ByVal objBEAgent As clsBEAgent) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UploadAgentLogo")
                cmd.Parameters.AddWithValue("AgentId", objBEAgent.AgentId)
                cmd.Parameters.AddWithValue("ImageLoc", objBEAgent.ImageLoc)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddAccomPhotos")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update company id for delete agent.
        ''' </summary>
        Public Function UpdateCompanyIdForDeleteAgent(ByVal objBEAgent As clsBEAgent) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spAgentDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateCompanyIdForDeleteAgent")
                cmd.Parameters.AddWithValue("AgentId", objBEAgent.AgentId)
                cmd.Parameters.AddWithValue("CompanyId", objBEAgent.CompanyId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateCompanyIdForDeleteAgent")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace