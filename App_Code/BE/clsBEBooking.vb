Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEBooking

        Private intBookingId As Integer
        Public Property BookingId() As Integer
            Get
                Return intBookingId
            End Get
            Set(ByVal value As Integer)
                intBookingId = value
            End Set
        End Property

        Private intRouteId As Integer
        Public Property RouteId() As Integer
            Get
                Return intRouteId
            End Get
            Set(ByVal value As Integer)
                intRouteId = value
            End Set
        End Property

        Private strUniqueId As String
        Public Property UniqueId() As String
            Get
                Return strUniqueId
            End Get
            Set(ByVal value As String)
                strUniqueId = value
            End Set
        End Property

        Private blnActive As Boolean
        Public Property Active() As Boolean
            Get
                Return blnActive
            End Get
            Set(ByVal value As Boolean)
                blnActive = value
            End Set
        End Property

        Private intTotalNumber As Integer
        Public Property TotalNumber() As Integer
            Get
                Return intTotalNumber
            End Get
            Set(ByVal value As Integer)
                intTotalNumber = value
            End Set
        End Property

        Private blnCustomised As Boolean
        Public Property Customised() As Boolean
            Get
                Return blnCustomised
            End Get
            Set(ByVal value As Boolean)
                blnCustomised = value
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

        Private intNoMales As Integer
        Public Property NoMales() As Integer
            Get
                Return intNoMales
            End Get
            Set(ByVal value As Integer)
                intNoMales = value
            End Set
        End Property

        Private intNoFemales As Integer
        Public Property NoFemales() As Integer
            Get
                Return intNoFemales
            End Get
            Set(ByVal value As Integer)
                intNoFemales = value
            End Set
        End Property

        Private intNoOther As Integer
        Public Property NoOther() As Integer
            Get
                Return intNoOther
            End Get
            Set(ByVal value As Integer)
                intNoOther = value
            End Set
        End Property

        Private strEnsuite As String
        Public Property Ensuite() As String
            Get
                Return strEnsuite
            End Get
            Set(ByVal value As String)
                strEnsuite = value
            End Set
        End Property

        Private bnlDogFriendly As Boolean
        Public Property DogFriendly() As Boolean
            Get
                Return bnlDogFriendly
            End Get
            Set(ByVal value As Boolean)
                bnlDogFriendly = value
            End Set
        End Property

        Private bnlCancelled As Boolean
        Public Property Cancelled() As Boolean
            Get
                Return bnlCancelled
            End Get
            Set(ByVal value As Boolean)
                bnlCancelled = value
            End Set
        End Property

        Private dtCancellationDate As DateTime
        Public Property CancellationDate() As DateTime
            Get
                Return dtCancellationDate
            End Get
            Set(ByVal value As DateTime)
                dtCancellationDate = value
            End Set
        End Property

        Private dblCancellationAmount As Double
        Public Property CancellationAmount() As Double
            Get
                Return dblCancellationAmount
            End Get
            Set(ByVal value As Double)
                dblCancellationAmount = value
            End Set
        End Property

        Private dblRouteCostClient As Double
        Public Property RouteCostClient() As Double
            Get
                Return dblRouteCostClient
            End Get
            Set(ByVal value As Double)
                dblRouteCostClient = value
            End Set
        End Property

        Private dblRouteCostEasyways As Double
        Public Property RouteCostEasyways() As Double
            Get
                Return dblRouteCostEasyways
            End Get
            Set(ByVal value As Double)
                dblRouteCostEasyways = value
            End Set
        End Property

    End Class

End Namespace
