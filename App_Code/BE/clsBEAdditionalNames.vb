Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAdditionalNames

        Private intAdditionalNamesId As Integer
        Public Property AdditionalNamesId() As Integer
            Get
                Return intAdditionalNamesId
            End Get
            Set(ByVal value As Integer)
                intAdditionalNamesId = value
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

        Private intBookingId As Integer
        Public Property BookingId() As Integer
            Get
                Return intBookingId
            End Get
            Set(ByVal value As Integer)
                intBookingId = value
            End Set
        End Property

        Private intSexId As Integer
        Public Property SexId() As Integer
            Get
                Return intSexId
            End Get
            Set(ByVal value As Integer)
                intSexId = value
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