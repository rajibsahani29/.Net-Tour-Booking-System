Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEClientBooking

        Private intClientBookingId As Integer
        Public Property ClientBookingId() As Integer
            Get
                Return intClientBookingId
            End Get
            Set(ByVal value As Integer)
                intClientBookingId = value
            End Set
        End Property

        Private intClientId As Integer
        Public Property ClientId() As Integer
            Get
                Return intClientId
            End Get
            Set(ByVal value As Integer)
                intClientId = value
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

        Private dtDateCreated As DateTime
        Public Property DateCreated() As DateTime
            Get
                Return dtDateCreated
            End Get
            Set(ByVal value As DateTime)
                dtDateCreated = value
            End Set
        End Property

        Private intStaffId As Integer
        Public Property StaffId() As Integer
            Get
                Return intStaffId
            End Get
            Set(ByVal value As Integer)
                intStaffId = value
            End Set
        End Property

        Private intAgentId As Integer
        Public Property AgentId() As Integer
            Get
                Return intAgentId
            End Get
            Set(ByVal value As Integer)
                intAgentId = value
            End Set
        End Property

        Private intBookingStageId As Integer
        Public Property BookingStageId() As Integer
            Get
                Return intBookingStageId
            End Get
            Set(ByVal value As Integer)
                intBookingStageId = value
            End Set
        End Property

        Private blnCarParkingRequire As Boolean
        Public Property CarParkingRequire() As Boolean
            Get
                Return blnCarParkingRequire
            End Get
            Set(ByVal value As Boolean)
                blnCarParkingRequire = value
            End Set
        End Property

        Private blnUrlVisited As Boolean
        Public Property UrlVisited() As String
            Get
                Return blnUrlVisited
            End Get
            Set(ByVal value As String)
                blnUrlVisited = value
            End Set
        End Property

        Private blnAgentPaid As Boolean
        Public Property AgentPaid() As Boolean
            Get
                Return blnAgentPaid
            End Get
            Set(ByVal value As Boolean)
                blnAgentPaid = value
            End Set
        End Property

        Private blnAgentInvoiced As Boolean
        Public Property AgentInvoiced() As Boolean
            Get
                Return blnAgentInvoiced
            End Get
            Set(ByVal value As Boolean)
                blnAgentInvoiced = value
            End Set
        End Property

        Private dtCheckinEarliest As DateTime
        Public Property CheckinEarliest() As DateTime
            Get
                Return dtCheckinEarliest
            End Get
            Set(ByVal value As DateTime)
                dtCheckinEarliest = value
            End Set
        End Property

        Private dtCheckoutLatest As DateTime
        Public Property CheckoutLatest() As DateTime
            Get
                Return dtCheckoutLatest
            End Get
            Set(ByVal value As DateTime)
                dtCheckoutLatest = value
            End Set
        End Property

        Private dtInvDate As DateTime
        Public Property InvDate() As DateTime
            Get
                Return dtInvDate
            End Get
            Set(ByVal value As DateTime)
                dtInvDate = value
            End Set
        End Property

        Private strPriceBand As String
        Public Property PriceBand() As String
            Get
                Return strPriceBand
            End Get
            Set(ByVal value As String)
                strPriceBand = value
            End Set
        End Property

        Private blnFlagInvoice As Boolean
        Public Property FlagInvoice() As Boolean
            Get
                Return blnFlagInvoice
            End Get
            Set(ByVal value As Boolean)
                blnFlagInvoice = value
            End Set
        End Property

        Private strAgentRef As String
        Public Property AgentRef() As String
            Get
                Return strAgentRef
            End Get
            Set(ByVal value As String)
                strAgentRef = value
            End Set
        End Property

    End Class

End Namespace
