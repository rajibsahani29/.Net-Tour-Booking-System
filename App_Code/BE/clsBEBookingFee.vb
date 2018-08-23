Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEBookingFee

        Private intBookingFeeId As Integer
        Public Property BookingFeeId() As Integer
            Get
                Return intBookingFeeId
            End Get
            Set(ByVal value As Integer)
                intBookingFeeId = value
            End Set
        End Property

        Private intTotalNum As Integer
        Public Property TotalNum() As Integer
            Get
                Return intTotalNum
            End Get
            Set(ByVal value As Integer)
                intTotalNum = value
            End Set
        End Property

        Private dblFeeTotal As Double
        Public Property FeeTotal() As Decimal
            Get
                Return dblFeeTotal
            End Get
            Set(ByVal value As Decimal)
                dblFeeTotal = value
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