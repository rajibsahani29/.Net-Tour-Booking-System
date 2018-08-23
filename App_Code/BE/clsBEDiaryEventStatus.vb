Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEDiaryEventStatus

        Private intDiaryEventStatusId As Integer
        Public Property DiaryEventStatusId() As Integer
            Get
                Return intDiaryEventStatusId
            End Get
            Set(ByVal value As Integer)
                intDiaryEventStatusId = value
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

        Private strColor As String
        Public Property Color() As String
            Get
                Return strColor
            End Get
            Set(ByVal value As String)
                strColor = value
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

    End Class

End Namespace