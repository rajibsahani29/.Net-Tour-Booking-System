Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEBookingStatusComplete

        Private intBookingStatusCompleteId As Integer
        Public Property BookingStatusCompleteId() As Integer
            Get
                Return intBookingStatusCompleteId
            End Get
            Set(ByVal value As Integer)
                intBookingStatusCompleteId = value
            End Set
        End Property

        Private strName As String
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal value As String)
                strName = value
            End Set
        End Property

        Private bnlAgent As Boolean
        Public Property Agent() As Boolean
            Get
                Return bnlAgent
            End Get
            Set(ByVal value As Boolean)
                bnlAgent = value
            End Set
        End Property

        Private bnlEasyways As Boolean
        Public Property Easyways() As Boolean
            Get
                Return bnlEasyways
            End Get
            Set(ByVal value As Boolean)
                bnlEasyways = value
            End Set
        End Property

        Private intCat As Integer
        Public Property Cat() As Integer
            Get
                Return intCat
            End Get
            Set(ByVal value As Integer)
                intCat = value
            End Set
        End Property

    End Class

End Namespace