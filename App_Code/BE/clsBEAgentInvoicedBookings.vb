Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAgentInvoicedBookings

        Private intAgentInvoicedBookingsId As Integer
        Public Property AgentInvoicedBookingsId() As Integer
            Get
                Return intAgentInvoicedBookingsId
            End Get
            Set(ByVal value As Integer)
                intAgentInvoicedBookingsId = value
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

        Private intBookingId As Integer
        Public Property BookingId() As Integer
            Get
                Return intBookingId
            End Get
            Set(ByVal value As Integer)
                intBookingId = value
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

        Private dtDateLastUpdated As DateTime
        Public Property DateLastUpdated() As DateTime
            Get
                Return dtDateLastUpdated
            End Get
            Set(ByVal value As DateTime)
                dtDateLastUpdated = value
            End Set
        End Property

        Private dtDateSent As DateTime
        Public Property DateSent() As DateTime
            Get
                Return dtDateSent
            End Get
            Set(ByVal value As DateTime)
                dtDateSent = value
            End Set
        End Property

    End Class

End Namespace