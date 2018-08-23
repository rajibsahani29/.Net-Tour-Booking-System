Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAccomodation

#Region "Accom"

        Private intAccomId As Integer
        Public Property AccomId() As Integer
            Get
                Return intAccomId
            End Get
            Set(ByVal value As Integer)
                intAccomId = value
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

        Private strContact As String
        Public Property Contact() As String
            Get
                Return strContact
            End Get
            Set(ByVal value As String)
                strContact = value
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

        Private strPhone As String
        Public Property Phone() As String
            Get
                Return strPhone
            End Get
            Set(ByVal value As String)
                strPhone = value
            End Set
        End Property

        Private strDescription As String
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal value As String)
                strDescription = value
            End Set
        End Property

        Private strDirection As String
        Public Property Direction() As String
            Get
                Return strDirection
            End Get
            Set(ByVal value As String)
                strDirection = value
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

        Private intStarRating As Integer
        Public Property StarRating() As Integer
            Get
                Return intStarRating
            End Get
            Set(ByVal value As Integer)
                intStarRating = value
            End Set
        End Property

        Private strEarliestTimeArrival As String
        Public Property EarliestTimeArrival() As String
            Get
                Return strEarliestTimeArrival
            End Get
            Set(ByVal value As String)
                strEarliestTimeArrival = value
            End Set
        End Property

        Private strDirection2 As String
        Public Property Direction2() As String
            Get
                Return strDirection2
            End Get
            Set(ByVal value As String)
                strDirection2 = value
            End Set
        End Property

        Private strDirection3 As String
        Public Property Direction3() As String
            Get
                Return strDirection3
            End Get
            Set(ByVal value As String)
                strDirection3 = value
            End Set
        End Property

        Private strDirection4 As String
        Public Property Direction4() As String
            Get
                Return strDirection4
            End Get
            Set(ByVal value As String)
                strDirection4 = value
            End Set
        End Property

        Private strMobilex As String
        Public Property Mobilex() As String
            Get
                Return strMobilex
            End Get
            Set(ByVal value As String)
                strMobilex = value
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

        Private strAccomComment As String
        Public Property AccomComment() As String
            Get
                Return strAccomComment
            End Get
            Set(ByVal value As String)
                strAccomComment = value
            End Set
        End Property

        Private strWebsiteLink As String
        Public Property WebsiteLink() As String
            Get
                Return strWebsiteLink
            End Get
            Set(ByVal value As String)
                strWebsiteLink = value
            End Set
        End Property

        Private bnlDogFriendly As Boolean
        Public Property DogFriendly() As Boolean
            Get
                Return bnlDogFriendly
            End Get
            Set(ByVal value As Boolean)
                bnlDogFriendly = value
            End Set
        End Property

        Private dblDogPrice As Double
        Public Property DogPrice() As Double
            Get
                Return dblDogPrice
            End Get
            Set(ByVal value As Double)
                dblDogPrice = value
            End Set
        End Property

        Private intNoRoom As Integer
        Public Property NoRoom() As Integer
            Get
                Return intNoRoom
            End Get
            Set(ByVal value As Integer)
                intNoRoom = value
            End Set
        End Property

        Private strGoogleMapLink As String
        Public Property GoogleMapLink() As String
            Get
                Return strGoogleMapLink
            End Get
            Set(ByVal value As String)
                strGoogleMapLink = value
            End Set
        End Property

        Private strBedroomConfig As String
        Public Property BedroomConfig() As String
            Get
                Return strBedroomConfig
            End Get
            Set(ByVal value As String)
                strBedroomConfig = value
            End Set
        End Property

        Private strDogConstraints As String
        Public Property DogConstraints() As String
            Get
                Return strDogConstraints
            End Get
            Set(ByVal value As String)
                strDogConstraints = value
            End Set
        End Property

        Private strPaymentPrefer As String
        Public Property PaymentPrefer() As String
            Get
                Return strPaymentPrefer
            End Get
            Set(ByVal value As String)
                strPaymentPrefer = value
            End Set
        End Property

#End Region

#Region "Accom_App"

        Private intAccomAppId As Integer
        Public Property AccomAppId() As Integer
            Get
                Return intAccomAppId
            End Get
            Set(ByVal value As Integer)
                intAccomAppId = value
            End Set
        End Property

        Private strIosLink As String
        Public Property IosLink() As String
            Get
                Return strIosLink
            End Get
            Set(ByVal value As String)
                strIosLink = value
            End Set
        End Property

        Private strAndroidLink As String
        Public Property AndroidLink() As String
            Get
                Return strAndroidLink
            End Get
            Set(ByVal value As String)
                strAndroidLink = value
            End Set
        End Property

#End Region

#Region "Accom_AccomFacilities"

        Private intAccom_AccomFacilitiesId As Integer
        Public Property Accom_AccomFacilitiesId() As Integer
            Get
                Return intAccom_AccomFacilitiesId
            End Get
            Set(ByVal value As Integer)
                intAccom_AccomFacilitiesId = value
            End Set
        End Property

        Private intAccomFacilitiesId As Integer
        Public Property AccomFacilitiesId() As Integer
            Get
                Return intAccomFacilitiesId
            End Get
            Set(ByVal value As Integer)
                intAccomFacilitiesId = value
            End Set
        End Property

        Private dblCostEasyway As Double
        Public Property CostEasyway() As Double
            Get
                Return dblCostEasyway
            End Get
            Set(ByVal value As Double)
                dblCostEasyway = value
            End Set
        End Property

        Private dblCostClient As Double
        Public Property CostClient() As Double
            Get
                Return dblCostClient
            End Get
            Set(ByVal value As Double)
                dblCostClient = value
            End Set
        End Property

        Private strCommentx As String
        Public Property Commentx() As String
            Get
                Return strCommentx
            End Get
            Set(ByVal value As String)
                strCommentx = value
            End Set
        End Property

#End Region

#Region "Accom_PaymentMethod"

        Private intAccomPaymentMethodId As Integer
        Public Property AccomPaymentMethodId() As Integer
            Get
                Return intAccomPaymentMethodId
            End Get
            Set(ByVal value As Integer)
                intAccomPaymentMethodId = value
            End Set
        End Property

        Private intPaymentMethodId As Integer
        Public Property PaymentMethodId() As Integer
            Get
                Return intPaymentMethodId
            End Get
            Set(ByVal value As Integer)
                intPaymentMethodId = value
            End Set
        End Property

        Private dblCharge As Double
        Public Property Charge() As Double
            Get
                Return dblCharge
            End Get
            Set(ByVal value As Double)
                dblCharge = value
            End Set
        End Property

#End Region

#Region "Accom_Memberships"

        Private intAccomMembershipsId As Integer
        Public Property AccomMembershipsId() As Integer
            Get
                Return intAccomMembershipsId
            End Get
            Set(ByVal value As Integer)
                intAccomMembershipsId = value
            End Set
        End Property

        Private intAccomOpMembershipId As Integer
        Public Property AccomOpMembershipId() As Integer
            Get
                Return intAccomOpMembershipId
            End Get
            Set(ByVal value As Integer)
                intAccomOpMembershipId = value
            End Set
        End Property

#End Region

#Region "Accom_Banking_Details"

        Private intAccomBankingDetailsId As Integer
        Public Property AccomBankingDetailsId() As Integer
            Get
                Return intAccomBankingDetailsId
            End Get
            Set(ByVal value As Integer)
                intAccomBankingDetailsId = value
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

#Region "Accomodation_Breakfast"

        Private intAccomBreakfastId As Integer
        Public Property AccomBreakfastId() As Integer
            Get
                Return intAccomBreakfastId
            End Get
            Set(ByVal value As Integer)
                intAccomBreakfastId = value
            End Set
        End Property

        Private intBreakfastId As Integer
        Public Property BreakfastId() As Integer
            Get
                Return intBreakfastId
            End Get
            Set(ByVal value As Integer)
                intBreakfastId = value
            End Set
        End Property

        Private dblBreakfastAmount As Double
        Public Property BreakfastAmount() As Double
            Get
                Return dblBreakfastAmount
            End Get
            Set(ByVal value As Double)
                dblBreakfastAmount = value
            End Set
        End Property

#End Region

    End Class

End Namespace