Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEExtrasBaggageBooking

        Private intExtrasBaggageBookingId As Integer
        Public Property ExtrasBaggageBookingId() As Integer
            Get
                Return intExtrasBaggageBookingId
            End Get
            Set(ByVal value As Integer)
                intExtrasBaggageBookingId = value
            End Set
        End Property

        Private intExtrasBaggageLinkRouteId As Integer
        Public Property ExtrasBaggageLinkRouteId() As Integer
            Get
                Return intExtrasBaggageLinkRouteId
            End Get
            Set(ByVal value As Integer)
                intExtrasBaggageLinkRouteId = value
            End Set
        End Property

        Private blnBookedYN As Boolean
        Public Property BookedYN() As Boolean
            Get
                Return blnBookedYN
            End Get
            Set(ByVal value As Boolean)
                blnBookedYN = value
            End Set
        End Property

        Private dtBookedDate As DateTime
        Public Property BookedDate() As DateTime
            Get
                Return dtBookedDate
            End Get
            Set(ByVal value As DateTime)
                dtBookedDate = value
            End Set
        End Property

        Private dblCostEasyway As Double
        Public Property CostEasyway() As Double
            Get
                Return dblCostEasyway
            End Get
            Set(ByVal value As Double)
                dblCostEasyway = value
            End Set
        End Property

        Private dblCostClient As Double
        Public Property CostClient() As Double
            Get
                Return dblCostClient
            End Get
            Set(ByVal value As Double)
                dblCostClient = value
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

        Private blnPaidx As Boolean
        Public Property Paidx() As Boolean
            Get
                Return blnPaidx
            End Get
            Set(ByVal value As Boolean)
                blnPaidx = value
            End Set
        End Property

        Private blnInvoicex As Boolean
        Public Property Invoicex() As Boolean
            Get
                Return blnInvoicex
            End Get
            Set(ByVal value As Boolean)
                blnInvoicex = value
            End Set
        End Property

        Private strInstructionx As String
        Public Property Instructionx() As String
            Get
                Return strInstructionx
            End Get
            Set(ByVal value As String)
                strInstructionx = value
            End Set
        End Property

        Private intNoBags As Integer
        Public Property NoBags() As Integer
            Get
                Return intNoBags
            End Get
            Set(ByVal value As Integer)
                intNoBags = value
            End Set
        End Property

        Private blnExtraInvoiced As Boolean
        Public Property ExtraInvoiced() As Boolean
            Get
                Return blnExtraInvoiced
            End Get
            Set(ByVal value As Boolean)
                blnExtraInvoiced = value
            End Set
        End Property

        Private bnlSetPaid As Boolean
        Public Property SetPaid() As Boolean
            Get
                Return bnlSetPaid
            End Get
            Set(ByVal value As Boolean)
                bnlSetPaid = value
            End Set
        End Property

        Private strInfoSupplierEmail As String
        Public Property InfoSupplierEmail() As String
            Get
                Return strInfoSupplierEmail
            End Get
            Set(ByVal value As String)
                strInfoSupplierEmail = value
            End Set
        End Property

    End Class

End Namespace