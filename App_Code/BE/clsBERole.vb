Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBERole

        Private intRoleId As Integer
        Public Property RoleId() As Integer
            Get
                Return intRoleId
            End Get
            Set(ByVal value As Integer)
                intRoleId = value
            End Set
        End Property

        Private strRoleName As String
        Public Property RoleName() As String
            Get
                Return strRoleName
            End Get
            Set(ByVal value As String)
                strRoleName = value
            End Set
        End Property

    End Class

End Namespace

