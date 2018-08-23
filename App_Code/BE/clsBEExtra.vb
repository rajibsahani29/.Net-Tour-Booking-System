Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEExtra

#Region "Extras"

        Private intExtraId As Integer
        Public Property ExtraId() As Integer
            Get
                Return intExtraId
            End Get
            Set(ByVal value As Integer)
                intExtraId = value
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

        Private strContactName As String
        Public Property ContactName() As String
            Get
                Return strContactName
            End Get
            Set(ByVal value As String)
                strContactName = value
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

        Private strPostCode As String
        Public Property PostCode() As String
            Get
                Return strPostCode
            End Get
            Set(ByVal value As String)
                strPostCode = value
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

        Private strPhone As String
        Public Property Phone() As String
            Get
                Return strPhone
            End Get
            Set(ByVal value As String)
                strPhone = value
            End Set
        End Property

        Private intMaxNumber As Integer
        Public Property MaxNumber() As Integer
            Get
                Return intMaxNumber
            End Get
            Set(ByVal value As Integer)
                intMaxNumber = value
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

        Private dtDateAdded As DateTime
        Public Property DateAdded() As DateTime
            Get
                Return dtDateAdded
            End Get
            Set(ByVal value As DateTime)
                dtDateAdded = value
            End Set
        End Property

        Private dtDateAmended As DateTime
        Public Property DateAmended() As DateTime
            Get
                Return dtDateAmended
            End Get
            Set(ByVal value As DateTime)
                dtDateAmended = value
            End Set
        End Property

        Private intExtraTypeId As Integer
        Public Property ExtraTypeId() As Integer
            Get
                Return intExtraTypeId
            End Get
            Set(ByVal value As Integer)
                intExtraTypeId = value
            End Set
        End Property

        Private strGoogleDoc As String
        Public Property GoogleDoc() As String
            Get
                Return strGoogleDoc
            End Get
            Set(ByVal value As String)
                strGoogleDoc = value
            End Set
        End Property

        Private strWebsiteUrl As String
        Public Property WebsiteUrl() As String
            Get
                Return strWebsiteUrl
            End Get
            Set(ByVal value As String)
                strWebsiteUrl = value
            End Set
        End Property

        Private strMobile As String
        Public Property Mobile() As String
            Get
                Return strMobile
            End Get
            Set(ByVal value As String)
                strMobile = value
            End Set
        End Property

        Private strOpenFrom As String
        Public Property OpenFrom() As String
            Get
                Return strOpenFrom
            End Get
            Set(ByVal value As String)
                strOpenFrom = value
            End Set
        End Property

        Private strOpenTo As String
        Public Property OpenTo() As String
            Get
                Return strOpenTo
            End Get
            Set(ByVal value As String)
                strOpenTo = value
            End Set
        End Property

        Private strExtGoogleDoc As String
        Public Property ExtGoogleDoc() As String
            Get
                Return strExtGoogleDoc
            End Get
            Set(ByVal value As String)
                strExtGoogleDoc = value
            End Set
        End Property

#End Region

#Region "Extras_Banking_Details"

        Private intExtraBankingDetailId As Integer
        Public Property ExtraBankingDetailId() As Integer
            Get
                Return intExtraBankingDetailId
            End Get
            Set(ByVal value As Integer)
                intExtraBankingDetailId = value
            End Set
        End Property

        Private strAccountName As String
        Public Property AccountName() As String
            Get
                Return strAccountName
            End Get
            Set(ByVal value As String)
                strAccountName = value
            End Set
        End Property

        Private strAccountNo As String
        Public Property AccountNo() As String
            Get
                Return strAccountNo
            End Get
            Set(ByVal value As String)
                strAccountNo = value
            End Set
        End Property

        Private strSortCode As String
        Public Property SortCode() As String
            Get
                Return strSortCode
            End Get
            Set(ByVal value As String)
                strSortCode = value
            End Set
        End Property

#End Region

    End Class

End Namespace