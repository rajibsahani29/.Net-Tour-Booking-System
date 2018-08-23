Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEVoluntaryPayment

        Private intVoluntaryPaymentId As Integer
        Public Property VoluntaryPaymentId() As Integer
            Get
                Return intVoluntaryPaymentId
            End Get
            Set(ByVal value As Integer)
                intVoluntaryPaymentId = value
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

        Private dblAmount As Double
        Public Property Amount() As Double
            Get
                Return dblAmount
            End Get
            Set(ByVal value As Double)
                dblAmount = value
            End Set
        End Property

        Private blnPaid As Boolean
        Public Property Paid() As Boolean
            Get
                Return blnPaid
            End Get
            Set(ByVal value As Boolean)
                blnPaid = value
            End Set
        End Property

    End Class

End Namespace