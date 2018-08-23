Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLStaff
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to check the login credential of every uses.
        ''' </summary>
        Public Function StaffLogin(ByVal objBEStaff As clsBEStaff) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStaffMember"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "LoginStaffMember")
                cmd.Parameters.AddWithValue("Username", objBEStaff.UserName)
                cmd.Parameters.AddWithValue("Password", objBEStaff.Password)
                cmd.Parameters.AddWithValue("CompanyId", objBEStaff.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "StaffLogin")
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
        ''' This function is used to add staff member.
        ''' </summary>
        Public Function AddStaffMember(ByVal objBEStaff As clsBEStaff) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStaffMember"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddStaffMember")
                cmd.Parameters.AddWithValue("RoleId", objBEStaff.RoleId)
                cmd.Parameters.AddWithValue("CompanyId", objBEStaff.CompanyId)
                cmd.Parameters.AddWithValue("DateAdded", DateTime.Now)
                cmd.Parameters.AddWithValue("Active", RecoredStatus.Active)
                cmd.Parameters.AddWithValue("DateStarted", (If(objBEStaff.DateStarted <> DateTime.MinValue, objBEStaff.DateStarted, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("Password", objBEStaff.Password)
                
                Dim intStaffId As Integer = ExecuteNoneQueryByCommand(cmd, "AddStaffMember", "Y")
                HttpContext.Current.Trace.Warn("intStaffId = " + Convert.ToString(intStaffId))
                If intStaffId > 0 Then
                    Dim strUserName As String = objBEStaff.Name1 + objBEStaff.Name2 + objFunction.ReturnString(intStaffId)
                    HttpContext.Current.Trace.Warn("strUserName = " + strUserName)
                    Dim cmdNew = New SqlCommand()
                    cmdNew.CommandText = "EW_spStaffMember"
                    cmdNew.CommandType = CommandType.StoredProcedure
                    cmdNew.Parameters.AddWithValue("Action", "UpdateStaffMemberUserName")
                    cmdNew.Parameters.AddWithValue("Username", strUserName)
                    cmdNew.Parameters.AddWithValue("LastUpdated", DateTime.Now)
                    cmdNew.Parameters.AddWithValue("StaffId", intStaffId)
                    ExecuteNoneQueryByCommand(cmdNew, "UpdateStaffMemberUserName")
                End If

                Return intStaffId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update staff member.
        ''' </summary>
        Public Function UpdateStaffMember(ByVal objBEStaff As clsBEStaff) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStaffMember"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateStaffMember")
                cmd.Parameters.AddWithValue("RoleId", objBEStaff.RoleId)
                cmd.Parameters.AddWithValue("DateStarted", (If(objBEStaff.DateStarted <> DateTime.MinValue, objBEStaff.DateStarted, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("DateEnded", (If(objBEStaff.DateEnded <> DateTime.MinValue, objBEStaff.DateEnded, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("LastUpdated", DateTime.Now)
                cmd.Parameters.AddWithValue("StaffId", objBEStaff.StaffId)
                cmd.Parameters.AddWithValue("Password", objBEStaff.Password)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateStaffMember")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add staff member detail.
        ''' </summary>
        Public Function AddStaffMemberDetail(ByVal objBEStaff As clsBEStaff) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStaffMember"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddStaffMemberDetail")
                cmd.Parameters.AddWithValue("Name1", objBEStaff.Name1)
                cmd.Parameters.AddWithValue("Name2", objBEStaff.Name2)
                cmd.Parameters.AddWithValue("Address1", objBEStaff.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEStaff.Address2)
                cmd.Parameters.AddWithValue("City", objBEStaff.City)
                cmd.Parameters.AddWithValue("SexId", objBEStaff.SexId)
                cmd.Parameters.AddWithValue("PostCode", objBEStaff.PostCode)
                cmd.Parameters.AddWithValue("Phone1", objBEStaff.Phone1)
                cmd.Parameters.AddWithValue("Phone2", objBEStaff.Phone2)
                cmd.Parameters.AddWithValue("CountryId", objBEStaff.CountryId)
                cmd.Parameters.AddWithValue("AdditionalInfo", objBEStaff.AdditionalInfo)
                cmd.Parameters.AddWithValue("StaffId", objBEStaff.StaffId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddStaffMemberDetail")
                
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update staff member detail.
        ''' </summary>
        Public Function UpdateStaffMemberDetail(ByVal objBEStaff As clsBEStaff) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStaffMember"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateStaffMemberDetail")
                cmd.Parameters.AddWithValue("Name1", objBEStaff.Name1)
                cmd.Parameters.AddWithValue("Name2", objBEStaff.Name2)
                cmd.Parameters.AddWithValue("Address1", objBEStaff.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEStaff.Address2)
                cmd.Parameters.AddWithValue("City", objBEStaff.City)
                cmd.Parameters.AddWithValue("SexId", objBEStaff.SexId)
                cmd.Parameters.AddWithValue("PostCode", objBEStaff.PostCode)
                cmd.Parameters.AddWithValue("Phone1", objBEStaff.Phone1)
                cmd.Parameters.AddWithValue("Phone2", objBEStaff.Phone2)
                cmd.Parameters.AddWithValue("CountryId", objBEStaff.CountryId)
                cmd.Parameters.AddWithValue("AdditionalInfo", objBEStaff.AdditionalInfo)
                cmd.Parameters.AddWithValue("StaffId", objBEStaff.StaffId)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateStaffMemberDetail")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to change staff member password.
        ''' </summary>
        Public Function ChangeStaffMemberPassword(ByVal objBEStaff As clsBEStaff) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStaffMember"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "ChangeStaffMemberPassword")
                cmd.Parameters.AddWithValue("Password", objBEStaff.Password)
                cmd.Parameters.AddWithValue("OldPassword", objBEStaff.OldPassword)
                cmd.Parameters.AddWithValue("LastUpdated", DateTime.Now)
                cmd.Parameters.AddWithValue("StaffId", objBEStaff.StaffId)
                
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "ChangeStaffMemberPassword")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get staff member and fill in dropdown.
        ''' </summary>
        Public Function GetStaffMemberFillInDD(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStaffMember"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetStaffMemberFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetStaffMemberFillInDD")
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
        ''' This function is used to get staff member detail by staff id.
        ''' </summary>
        Public Function GetStaffMemberDetailById(ByVal intStaffId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStaffMember"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetStaffMemberDetailById")
                cmd.Parameters.AddWithValue("StaffId", intStaffId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetStaffMemberDetailById")
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
        ''' This function is used to update record status of staff member by staff id.
        ''' </summary>
        Public Function UpdateStaffMemberRecStatus(ByVal objBEStaff As clsBEStaff) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spStaffMember"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateStaffMemberRecStatus")
                Dim bnlRecStatus As Boolean = Nothing
                If objBEStaff.Active = "True" Then
                    bnlRecStatus = RecoredStatus.Deactive
                Else
                    bnlRecStatus = RecoredStatus.Active
                End If
                cmd.Parameters.AddWithValue("Active", bnlRecStatus)
                cmd.Parameters.AddWithValue("LastUpdated", DateTime.Now)
                cmd.Parameters.AddWithValue("StaffId", objBEStaff.StaffId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateStaffMemberRecStatus")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class
  
End Namespace


