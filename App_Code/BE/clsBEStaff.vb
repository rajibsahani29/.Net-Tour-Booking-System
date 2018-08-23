Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEStaff

#Region "Staff"

        Private intStaffId As Integer
        Public Property StaffId() As Integer
            Get
                Return intStaffId
            End Get
            Set(ByVal value As Integer)
                intStaffId = value
            End Set
        End Property

        Private intRoleId As Integer
        Public Property RoleId() As Integer
            Get
                Return intRoleId
            End Get
            Set(ByVal value As Integer)
                intRoleId = value
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

        Private strLastLogin As String
        Public Property LastLogin() As String
            Get
                Return strLastLogin
            End Get
            Set(ByVal value As String)
                strLastLogin = value
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

        Private blnActive As Boolean
        Public Property Active() As String
            Get
                Return blnActive
            End Get
            Set(ByVal value As String)
                blnActive = value
            End Set
        End Property

        Private dtDateStarted As DateTime
        Public Property DateStarted() As DateTime
            Get
                Return dtDateStarted
            End Get
            Set(ByVal value As DateTime)
                dtDateStarted = value
            End Set
        End Property

        Private dtDateEnded As DateTime
        Public Property DateEnded() As DateTime
            Get
                Return dtDateEnded
            End Get
            Set(ByVal value As DateTime)
                dtDateEnded = value
            End Set
        End Property

        Private strUsername As String
        Public Property UserName() As String
            Get
                Return strUsername
            End Get
            Set(ByVal value As String)
                strUsername = value
            End Set
        End Property

        Private strPassword As String
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal value As String)
                strPassword = value
            End Set
        End Property

        Private strOldPassword As String
        Public Property OldPassword() As String
            Get
                Return strOldPassword
            End Get
            Set(ByVal value As String)
                strOldPassword = value
            End Set
        End Property
#End Region

#Region "Staff_Detail"

        Private intStaffDetailId As Integer
        Public Property StaffDetailId() As Integer
            Get
                Return intStaffDetailId
            End Get
            Set(ByVal value As Integer)
                intStaffDetailId = value
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

        Private intSexId As Integer
        Public Property SexId() As Integer
            Get
                Return intSexId
            End Get
            Set(ByVal value As Integer)
                intSexId = value
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

#End Region

    End Class

End Namespace


