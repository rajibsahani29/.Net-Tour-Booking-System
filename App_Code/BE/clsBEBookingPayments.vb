Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEBookingPayments

        Private intBookingPaymentsId As Integer
        Public Property BookingPaymentsId() As Integer
            Get
                Return intBookingPaymentsId
            End Get
            Set(ByVal value As Integer)
                intBookingPaymentsId = value
            End Set
        End Property

        Private intBookingId As Integer
        Public Property BookingId() As Integer
            Get
                Return intBookingId
            End Get
            Set(ByVal value As Integer)
                intBookingId = value
            End Set
        End Property

        Private dblAmountWishToPay As Double
        Public Property AmountWishToPay() As Double
            Get
                Return dblAmountWishToPay
            End Get
            Set(ByVal value As Double)
                dblAmountWishToPay = value
            End Set
        End Property

        Private dblAmountPaid As Double
        Public Property AmountPaid() As Double
            Get
                Return dblAmountPaid
            End Get
            Set(ByVal value As Double)
                dblAmountPaid = value
            End Set
        End Property

        Private intPaymentMethodsId As Integer
        Public Property PaymentMethodsId() As Integer
            Get
                Return intPaymentMethodsId
            End Get
            Set(ByVal value As Integer)
                intPaymentMethodsId = value
            End Set
        End Property

        Private dtDateAdded As DateTime
        Public Property DateAdded() As DateTime
            Get
                Return dtDateAdded
            End Get
            Set(ByVal value As DateTime)
                dtDateAdded = value
            End Set
        End Property

        Private dblBalanceBeforePayment As Double
        Public Property BalanceBeforePayment() As Double
            Get
                Return dblBalanceBeforePayment
            End Get
            Set(ByVal value As Double)
                dblBalanceBeforePayment = value
            End Set
        End Property

        Private dblCCCharge As Double
        Public Property CCCharge() As Double
            Get
                Return dblCCCharge
            End Get
            Set(ByVal value As Double)
                dblCCCharge = value
            End Set
        End Property

        Private strFirstData As String
        Public Property FirstData() As String
            Get
                Return strFirstData
            End Get
            Set(ByVal value As String)
                strFirstData = value
            End Set
        End Property

        Private dtDateReceived As DateTime
        Public Property DateReceived() As DateTime
            Get
                Return dtDateReceived
            End Get
            Set(ByVal value As DateTime)
                dtDateReceived = value
            End Set
        End Property

    End Class

End Namespace