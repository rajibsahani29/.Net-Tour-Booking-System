Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Easyway.BE

Namespace Easyway.DL

    Public Class clsDLPaymentMethod
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add payment method.
        ''' </summary>
        Public Function AddPaymentMethod(ByVal objBEPaymentMethod As clsBEPaymentMethod) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentMethod"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddPaymentMethod")
                cmd.Parameters.AddWithValue("Name", objBEPaymentMethod.Name)
                cmd.Parameters.AddWithValue("Commision", objBEPaymentMethod.Commision)
                cmd.Parameters.AddWithValue("CompanyId", objBEPaymentMethod.CompanyId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddPaymentMethod")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get payment method.
        ''' </summary>
        Public Function GetPaymentMethod(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentMethod"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetPaymentMethod")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetPaymentMethod")
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
        ''' This function is used to get payment method by id.
        ''' </summary>
        Public Function GetPaymentMethodById(ByVal objBEPaymentMethod As clsBEPaymentMethod) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentMethod"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetPaymentMethodById")
                cmd.Parameters.AddWithValue("PaymentMethodId", objBEPaymentMethod.PaymentMethodId)
                cmd.Parameters.AddWithValue("CompanyId", objBEPaymentMethod.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetPaymentMethodById")
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
        ''' This function is used to get payment method and fill in dropdown.
        ''' </summary>
        Public Function GetPaymentMethodFillInDD(ByVal intCompanyId As Integer) As DataSet
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "EW_spPaymentMethod"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetPaymentMethodFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetPaymentMethodFillInDD")
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
        ''' This function is used to perform gridview operation for payment method.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEPaymentMethod As clsBEPaymentMethod) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "EW_spPaymentMethod"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdatePaymentMethod")
                    cmd.Parameters.AddWithValue("PaymentMethodId", objBEPaymentMethod.PaymentMethodId)
                    cmd.Parameters.AddWithValue("Name", objBEPaymentMethod.Name)
                    cmd.Parameters.AddWithValue("Commision", objBEPaymentMethod.Commision)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeletePaymentMethod")
                    cmd.Parameters.AddWithValue("PaymentMethodId", objBEPaymentMethod.PaymentMethodId)
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