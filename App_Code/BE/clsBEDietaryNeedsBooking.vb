Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEDietaryNeedsBooking

        Private intDietaryNeedsBookingId As Integer
        Public Property DietaryNeedsBookingId() As Integer
            Get
                Return intDietaryNeedsBookingId
            End Get
            Set(ByVal value As Integer)
                intDietaryNeedsBookingId = value
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

        Private strDietaryNeeds As String
        Public Property DietaryNeeds() As String
            Get
                Return strDietaryNeeds
            End Get
            Set(ByVal value As String)
                strDietaryNeeds = value
            End Set
        End Property

    End Class

End Namespace