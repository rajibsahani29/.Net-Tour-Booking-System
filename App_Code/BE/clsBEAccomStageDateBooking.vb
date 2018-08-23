Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAccomStageDateBooking

        Private intAccomStageDateBookingId As Integer
        Public Property AccomStageDateBookingId() As Integer
            Get
                Return intAccomStageDateBookingId
            End Get
            Set(ByVal value As Integer)
                intAccomStageDateBookingId = value
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

        Private dtCheckInDate As DateTime
        Public Property CheckInDate() As DateTime
            Get
                Return dtCheckInDate
            End Get
            Set(ByVal value As DateTime)
                dtCheckInDate = value
            End Set
        End Property

        Private dtCheckOutDate As DateTime
        Public Property CheckOutDate() As DateTime
            Get
                Return dtCheckOutDate
            End Get
            Set(ByVal value As DateTime)
                dtCheckOutDate = value
            End Set
        End Property

        Private dblFeeTotal As Double
        Public Property FeeTotal() As Double
            Get
                Return dblFeeTotal
            End Get
            Set(ByVal value As Double)
                dblFeeTotal = value
            End Set
        End Property

        Private dblExtraActualCost As Double
        Public Property ExtraActualCost() As Double
            Get
                Return dblExtraActualCost
            End Get
            Set(ByVal value As Double)
                dblExtraActualCost = value
            End Set
        End Property

        Private dblAccomActualCost As Double
        Public Property AccomActualCost() As Double
            Get
                Return dblAccomActualCost
            End Get
            Set(ByVal value As Double)
                dblAccomActualCost = value
            End Set
        End Property

        Private intAccomRouteStageId As Integer
        Public Property AccomRouteStageId() As Integer
            Get
                Return intAccomRouteStageId
            End Get
            Set(ByVal value As Integer)
                intAccomRouteStageId = value
            End Set
        End Property

    End Class

End Namespace
