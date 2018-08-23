Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAccomDiaryEvent

        Private intAccomDiaryEventId As Integer
        Public Property AccomDiaryEventId() As Integer
            Get
                Return intAccomDiaryEventId
            End Get
            Set(ByVal value As Integer)
                intAccomDiaryEventId = value
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

        Private intDiaryEventStatusId As Integer
        Public Property DiaryEventStatusId() As Integer
            Get
                Return intDiaryEventStatusId
            End Get
            Set(ByVal value As Integer)
                intDiaryEventStatusId = value
            End Set
        End Property

        Private strNote As String
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal value As String)
                strNote = value
            End Set
        End Property

        Private dtFromDate As Date
        Public Property FromDate() As Date
            Get
                Return dtFromDate
            End Get
            Set(ByVal value As Date)
                dtFromDate = value
            End Set
        End Property

        Private dtToDate As Date
        Public Property ToDate() As Date
            Get
                Return dtToDate
            End Get
            Set(ByVal value As Date)
                dtToDate = value
            End Set
        End Property

    End Class

End Namespace