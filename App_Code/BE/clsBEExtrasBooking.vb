Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEExtrasBooking

        Private intExtrasBookingId As Integer
        Public Property ExtrasBookingId() As Integer
            Get
                Return intExtrasBookingId
            End Get
            Set(ByVal value As Integer)
                intExtrasBookingId = value
            End Set
        End Property

        Private intExtrasId As Integer
        Public Property ExtrasId() As Integer
            Get
                Return intExtrasId
            End Get
            Set(ByVal value As Integer)
                intExtrasId = value
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

        Private intAccomStageId As Integer
        Public Property AccomStageId() As Integer
            Get
                Return intAccomStageId
            End Get
            Set(ByVal value As Integer)
                intAccomStageId = value
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

        Private strAdditionalInfo As String
        Public Property AdditionalInfo() As String
            Get
                Return strAdditionalInfo
            End Get
            Set(ByVal value As String)
                strAdditionalInfo = value
            End Set
        End Property

    End Class

End Namespace