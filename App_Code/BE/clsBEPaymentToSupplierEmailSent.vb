Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEPaymentToSupplierEmailSent

        Private intPaymentToSupplierEmailSentId As Integer
        Public Property PaymentToSupplierEmailSentId() As Integer
            Get
                Return intPaymentToSupplierEmailSentId
            End Get
            Set(ByVal value As Integer)
                intPaymentToSupplierEmailSentId = value
            End Set
        End Property

        Private intSupplierId As Integer
        Public Property SupplierId() As Integer
            Get
                Return intSupplierId
            End Get
            Set(ByVal value As Integer)
                intSupplierId = value
            End Set
        End Property

        Private dtDateEntered As DateTime
        Public Property DateEntered() As DateTime
            Get
                Return dtDateEntered
            End Get
            Set(ByVal value As DateTime)
                dtDateEntered = value
            End Set
        End Property

        Private intMonthVal As Integer
        Public Property MonthVal() As Integer
            Get
                Return intMonthVal
            End Get
            Set(ByVal value As Integer)
                intMonthVal = value
            End Set
        End Property

        Private intYearVal As Integer
        Public Property YearVal() As Integer
            Get
                Return intYearVal
            End Get
            Set(ByVal value As Integer)
                intYearVal = value
            End Set
        End Property

        Private intSupplierType As Integer
        Public Property SupplierType() As Integer
            Get
                Return intSupplierType
            End Get
            Set(ByVal value As Integer)
                intSupplierType = value
            End Set
        End Property

    End Class

End Namespace