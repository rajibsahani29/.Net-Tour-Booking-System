Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAccomStageEvalBooking

        Private intAccomStageEvalBookingId As Integer
        Public Property AccomStageEvalBookingId() As Integer
            Get
                Return intAccomStageEvalBookingId
            End Get
            Set(ByVal value As Integer)
                intAccomStageEvalBookingId = value
            End Set
        End Property

        Private intAccomId As Integer
        Public Property AccomId() As Integer
            Get
                Return intAccomId
            End Get
            Set(ByVal value As Integer)
                intAccomId = value
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

        Private intWelcome As Integer
        Public Property Welcome() As Integer
            Get
                Return intWelcome
            End Get
            Set(ByVal value As Integer)
                intWelcome = value
            End Set
        End Property

        Private intCleanliness As Integer
        Public Property Cleanliness() As Integer
            Get
                Return intCleanliness
            End Get
            Set(ByVal value As Integer)
                intCleanliness = value
            End Set
        End Property

        Private intBreakfast As Integer
        Public Property Breakfast() As Integer
            Get
                Return intBreakfast
            End Get
            Set(ByVal value As Integer)
                intBreakfast = value
            End Set
        End Property

        Private intFacilities As Integer
        Public Property Facilities() As Integer
            Get
                Return intFacilities
            End Get
            Set(ByVal value As Integer)
                intFacilities = value
            End Set
        End Property

        Private intOverall As Integer
        Public Property Overall() As Integer
            Get
                Return intOverall
            End Get
            Set(ByVal value As Integer)
                intOverall = value
            End Set
        End Property

    End Class

End Namespace