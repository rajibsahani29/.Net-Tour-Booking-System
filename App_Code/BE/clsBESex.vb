Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBESex

        Private intSexId As Integer
        Public Property SexId() As Integer
            Get
                Return intSexId
            End Get
            Set(ByVal value As Integer)
                intSexId = value
            End Set
        End Property

        Private strSexName As String
        Public Property SexName() As String
            Get
                Return strSexName
            End Get
            Set(ByVal value As String)
                strSexName = value
            End Set
        End Property

    End Class

End Namespace
