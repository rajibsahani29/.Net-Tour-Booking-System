Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEBookingCorrespondence

        Private intBookingCorrespondenceId As Integer
        Public Property BookingCorrespondenceId() As Integer
            Get
                Return intBookingCorrespondenceId
            End Get
            Set(ByVal value As Integer)
                intBookingCorrespondenceId = value
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

        Private dtDatex As DateTime
        Public Property Datex() As DateTime
            Get
                Return dtDatex
            End Get
            Set(ByVal value As DateTime)
                dtDatex = value
            End Set
        End Property

        Private intCorrespondenceTypeId As Integer
        Public Property CorrespondenceTypeId() As Integer
            Get
                Return intCorrespondenceTypeId
            End Get
            Set(ByVal value As Integer)
                intCorrespondenceTypeId = value
            End Set
        End Property

        Private strCorrespondenceTypeName As String
        Public Property CorrespondenceTypeName() As String
            Get
                Return strCorrespondenceTypeName
            End Get
            Set(ByVal value As String)
                strCorrespondenceTypeName = value
            End Set
        End Property

        Private blnDirection As Boolean
        Public Property Direction() As Boolean
            Get
                Return blnDirection
            End Get
            Set(ByVal value As Boolean)
                blnDirection = value
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

        Private strSubject As String
        Public Property Subject() As String
            Get
                Return strSubject
            End Get
            Set(ByVal value As String)
                strSubject = value
            End Set
        End Property

        Private intTypex As Integer
        Public Property Typex() As Integer
            Get
                Return intTypex
            End Get
            Set(ByVal value As Integer)
                intTypex = value
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

        Private intExtraId As Integer
        Public Property ExtraId() As Integer
            Get
                Return intExtraId
            End Get
            Set(ByVal value As Integer)
                intExtraId = value
            End Set
        End Property

        Private strEmailType As String
        Public Property EmailType() As String
            Get
                Return strEmailType
            End Get
            Set(ByVal value As String)
                strEmailType = value
            End Set
        End Property

    End Class

End Namespace