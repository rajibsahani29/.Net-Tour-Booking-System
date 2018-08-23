Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEBookingStatusBookings

        Private intBookingStatusBookingsId As Integer
        Public Property BookingStatusBookingsId() As Integer
            Get
                Return intBookingStatusBookingsId
            End Get
            Set(ByVal value As Integer)
                intBookingStatusBookingsId = value
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

        Private intBSCId As Integer
        Public Property BSCId() As Integer
            Get
                Return intBSCId
            End Get
            Set(ByVal value As Integer)
                intBSCId = value
            End Set
        End Property

    End Class

End Namespace
