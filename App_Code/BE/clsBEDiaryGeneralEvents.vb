Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEDiaryGeneralEvents

        Private intDiaryGeneralEventsId As Integer
        Public Property DiaryGeneralEventsId() As Integer
            Get
                Return intDiaryGeneralEventsId
            End Get
            Set(ByVal value As Integer)
                intDiaryGeneralEventsId = value
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

        Private intStageId As Integer
        Public Property StageId() As Integer
            Get
                Return intStageId
            End Get
            Set(ByVal value As Integer)
                intStageId = value
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

        Private blnAllAccom As Boolean
        Public Property AllAccom() As Boolean
            Get
                Return blnAllAccom
            End Get
            Set(ByVal value As Boolean)
                blnAllAccom = value
            End Set
        End Property

    End Class

End Namespace
