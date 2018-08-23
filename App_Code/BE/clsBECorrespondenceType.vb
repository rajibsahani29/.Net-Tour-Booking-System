Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBECorrespondenceType

        Private intCorrespondenceTypeId As Integer
        Public Property CorrespondenceTypeId() As Integer
            Get
                Return intCorrespondenceTypeId
            End Get
            Set(ByVal value As Integer)
                intCorrespondenceTypeId = value
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