Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAgent

#Region "Agents"

        Private intAgentId As Integer
        Public Property AgentId() As Integer
            Get
                Return intAgentId
            End Get
            Set(ByVal value As Integer)
                intAgentId = value
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

        Private intCountryId As Integer
        Public Property CountryId() As Integer
            Get
                Return intCountryId
            End Get
            Set(ByVal value As Integer)
                intCountryId = value
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

        Private dtDateAdded As DateTime
        Public Property DateAdded() As DateTime
            Get
                Return dtDateAdded
            End Get
            Set(ByVal value As DateTime)
                dtDateAdded = value
            End Set
        End Property

        Private dtLastUpdated As DateTime
        Public Property LastUpdated() As DateTime
            Get
                Return dtLastUpdated
            End Get
            Set(ByVal value As DateTime)
                dtLastUpdated = value
            End Set
        End Property

        Private dblBankCharge As Double
        Public Property BankCharge() As Double
            Get
                Return dblBankCharge
            End Get
            Set(ByVal value As Double)
                dblBankCharge = value
            End Set
        End Property

        Private blnBuyx As Boolean
        Public Property Buyx() As Boolean
            Get
                Return blnBuyx
            End Get
            Set(ByVal value As Boolean)
                blnBuyx = value
            End Set
        End Property

        Private strImageLoc As String
        Public Property ImageLoc() As String
            Get
                Return strImageLoc
            End Get
            Set(ByVal value As String)
                strImageLoc = value
            End Set
        End Property

#End Region

#Region "Agents_Contacts"

        Private intAgentContactId As Integer
        Public Property AgentContactId() As Integer
            Get
                Return intAgentContactId
            End Get
            Set(ByVal value As Integer)
                intAgentContactId = value
            End Set
        End Property

        Private strACContactName As String
        Public Property ACContactName() As String
            Get
                Return strACContactName
            End Get
            Set(ByVal value As String)
                strACContactName = value
            End Set
        End Property

        Private strACJobTitle As String
        Public Property ACJobTitle() As String
            Get
                Return strACJobTitle
            End Get
            Set(ByVal value As String)
                strACJobTitle = value
            End Set
        End Property

        Private strACEmail As String
        Public Property ACEmail() As String
            Get
                Return strACEmail
            End Get
            Set(ByVal value As String)
                strACEmail = value
            End Set
        End Property

        Private strACPhone As String
        Public Property ACPhone() As String
            Get
                Return strACPhone
            End Get
            Set(ByVal value As String)
                strACPhone = value
            End Set
        End Property

        Private intACOrderx As Integer
        Public Property ACOrderx() As Integer
            Get
                Return intACOrderx
            End Get
            Set(ByVal value As Integer)
                intACOrderx = value
            End Set
        End Property

#End Region

    End Class

End Namespace