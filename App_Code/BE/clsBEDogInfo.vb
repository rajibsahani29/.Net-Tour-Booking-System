Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEDogInfo

        Private intDogInfoId As Integer
        Public Property DogInfoId() As Integer
            Get
                Return intDogInfoId
            End Get
            Set(ByVal value As Integer)
                intDogInfoId = value
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

        Private strInfo As String
        Public Property Info() As String
            Get
                Return strInfo
            End Get
            Set(ByVal value As String)
                strInfo = value
            End Set
        End Property

    End Class

End Namespace