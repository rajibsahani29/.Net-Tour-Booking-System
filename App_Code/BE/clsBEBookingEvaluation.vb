Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEBookingEvaluation

        Private intBookingEvaluationId As Integer
        Public Property BookingEvaluationId() As Integer
            Get
                Return intBookingEvaluationId
            End Get
            Set(ByVal value As Integer)
                intBookingEvaluationId = value
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

        Private strOverAll As String
        Public Property OverAll() As String
            Get
                Return strOverAll
            End Get
            Set(ByVal value As String)
                strOverAll = value
            End Set
        End Property

        Private strEase As String
        Public Property Ease() As String
            Get
                Return strEase
            End Get
            Set(ByVal value As String)
                strEase = value
            End Set
        End Property

        Private strQuality As String
        Public Property Quality() As String
            Get
                Return strQuality
            End Get
            Set(ByVal value As String)
                strQuality = value
            End Set
        End Property

        Private strValue As String
        Public Property Value() As String
            Get
                Return strValue
            End Get
            Set(ByVal value As String)
                strValue = value
            End Set
        End Property

        Private strTextx As String
        Public Property Textx() As String
            Get
                Return strTextx
            End Get
            Set(ByVal value As String)
                strTextx = value
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

        Private strHearAbout As String
        Public Property HearAbout() As String
            Get
                Return strHearAbout
            End Get
            Set(ByVal value As String)
                strHearAbout = Value
            End Set
        End Property

    End Class

End Namespace