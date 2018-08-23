﻿Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEPaymentToSupplierTotal

        Private intPaymentToSupplierTotalId As Integer
        Public Property PaymentToSupplierTotalId() As Integer
            Get
                Return intPaymentToSupplierTotalId
            End Get
            Set(ByVal value As Integer)
                intPaymentToSupplierTotalId = value
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

        Private dblTotalAmount As Double
        Public Property TotalAmount() As Double
            Get
                Return dblTotalAmount
            End Get
            Set(ByVal value As Double)
                dblTotalAmount = value
            End Set
        End Property

        Private dtDatePaid As DateTime
        Public Property DatePaid() As DateTime
            Get
                Return dtDatePaid
            End Get
            Set(ByVal value As DateTime)
                dtDatePaid = value
            End Set
        End Property

        Private bnlPaid As Boolean
        Public Property Paid() As Boolean
            Get
                Return bnlPaid
            End Get
            Set(ByVal value As Boolean)
                bnlPaid = value
            End Set
        End Property

    End Class

End Namespace