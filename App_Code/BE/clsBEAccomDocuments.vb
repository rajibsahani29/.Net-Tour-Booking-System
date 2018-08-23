Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAccomDocuments

        Private intAccomDocumentsId As Integer
        Public Property AccomDocumentsId() As Integer
            Get
                Return intAccomDocumentsId
            End Get
            Set(ByVal value As Integer)
                intAccomDocumentsId = value
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

        Private strDocLink As String
        Public Property DocLink() As String
            Get
                Return strDocLink
            End Get
            Set(ByVal value As String)
                strDocLink = value
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