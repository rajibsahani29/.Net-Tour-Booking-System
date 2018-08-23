Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEClient

        Private intClientId As Integer
        Public Property ClientId() As Integer
            Get
                Return intClientId
            End Get
            Set(ByVal value As Integer)
                intClientId = value
            End Set
        End Property

        Private strName1 As String
        Public Property Name1() As String
            Get
                Return strName1
            End Get
            Set(ByVal value As String)
                strName1 = value
            End Set
        End Property

        Private strName2 As String
        Public Property Name2() As String
            Get
                Return strName2
            End Get
            Set(ByVal value As String)
                strName2 = value
            End Set
        End Property

        Private strAddress1 As String
        Public Property Address1() As String
            Get
                Return strAddress1
            End Get
            Set(ByVal value As String)
                strAddress1 = value
            End Set
        End Property

        Private strAddress2 As String
        Public Property Address2() As String
            Get
                Return strAddress2
            End Get
            Set(ByVal value As String)
                strAddress2 = value
            End Set
        End Property

        Private strCity As String
        Public Property City() As String
            Get
                Return strCity
            End Get
            Set(ByVal value As String)
                strCity = value
            End Set
        End Property

        Private strPostCode As String
        Public Property PostCode() As String
            Get
                Return strPostCode
            End Get
            Set(ByVal value As String)
                strPostCode = value
            End Set
        End Property

        Private intCountryId As Integer
        Public Property CountryId() As Integer
            Get
                Return intCountryId
            End Get
            Set(ByVal value As Integer)
                intCountryId = value
            End Set
        End Property

        Private strEmail As String
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal value As String)
                strEmail = value
            End Set
        End Property

        Private strPhone1 As String
        Public Property Phone1() As String
            Get
                Return strPhone1
            End Get
            Set(ByVal value As String)
                strPhone1 = value
            End Set
        End Property

        Private strPhone2 As String
        Public Property Phone2() As String
            Get
                Return strPhone2
            End Get
            Set(ByVal value As String)
                strPhone2 = value
            End Set
        End Property

        Private intSexId As Integer
        Public Property SexId() As Integer
            Get
                Return intSexId
            End Get
            Set(ByVal value As Integer)
                intSexId = value
            End Set
        End Property

        Private blnNewsLetter As Boolean
        Public Property NewsLetter() As Boolean
            Get
                Return blnNewsLetter
            End Get
            Set(ByVal value As Boolean)
                blnNewsLetter = value
            End Set
        End Property

        Private strAdditionalInfo As String
        Public Property AdditionalInfo() As String
            Get
                Return strAdditionalInfo
            End Get
            Set(ByVal value As String)
                strAdditionalInfo = value
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

        Private intMarketingId As Integer
        Public Property MarketingId() As Integer
            Get
                Return intMarketingId
            End Get
            Set(ByVal value As Integer)
                intMarketingId = value
            End Set
        End Property

        Private strUrlName As String
        Public Property UrlName() As String
            Get
                Return strUrlName
            End Get
            Set(ByVal value As String)
                strUrlName = value
            End Set
        End Property

    End Class

End Namespace
