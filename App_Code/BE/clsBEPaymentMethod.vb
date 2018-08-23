Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEPaymentMethod

        Private intPaymentMethodId As Integer
        Public Property PaymentMethodId() As Integer
            Get
                Return intPaymentMethodId
            End Get
            Set(ByVal value As Integer)
                intPaymentMethodId = value
            End Set
        End Property

        Private strName As String
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal value As String)
                strName = value
            End Set
        End Property

        Private dblCommision As Double
        Public Property Commision() As Double
            Get
                Return dblCommision
            End Get
            Set(ByVal value As Double)
                dblCommision = value
            End Set
        End Property

        Private intCompanyId As Integer
        Public Property CompanyId() As Integer
            Get
                Return intCompanyId
            End Get
            Set(ByVal value As Integer)
                intCompanyId = value
            End Set
        End Property

    End Class

End Namespace