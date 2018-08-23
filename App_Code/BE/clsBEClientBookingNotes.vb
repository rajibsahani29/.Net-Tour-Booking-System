Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEClientBookingNotes

        Private intClientBookingNotesId As Integer
        Public Property ClientBookingNotesId() As Integer
            Get
                Return intClientBookingNotesId
            End Get
            Set(ByVal value As Integer)
                intClientBookingNotesId = value
            End Set
        End Property

        Private strNotes As String
        Public Property Notes() As String
            Get
                Return strNotes
            End Get
            Set(ByVal value As String)
                strNotes = value
            End Set
        End Property

        Private dtDateAdded As DateTime
        Public Property DateAdded() As DateTime
            Get
                Return dtDateAdded
            End Get
            Set(ByVal value As DateTime)
                dtDateAdded = value
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

    End Class

End Namespace