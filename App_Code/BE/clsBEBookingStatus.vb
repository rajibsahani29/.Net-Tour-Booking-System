Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEBookingStatus

        Private intBookingStatusId As Integer
        Public Property BookingStatusId() As Integer
            Get
                Return intBookingStatusId
            End Get
            Set(ByVal value As Integer)
                intBookingStatusId = value
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

    End Class

End Namespace
