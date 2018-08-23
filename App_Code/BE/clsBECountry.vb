Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBECountry

        Private intCountryId As Integer
        Public Property CountryId() As Integer
            Get
                Return intCountryId
            End Get
            Set(ByVal value As Integer)
                intCountryId = value
            End Set
        End Property

        Private strCountryName As String
        Public Property CountryName() As String
            Get
                Return strCountryName
            End Get
            Set(ByVal value As String)
                strCountryName = value
            End Set
        End Property

    End Class

End Namespace

