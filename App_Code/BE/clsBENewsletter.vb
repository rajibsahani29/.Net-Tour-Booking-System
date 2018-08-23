Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBENewsletter

        Private intNewsletterId As Integer
        Public Property NewsletterId() As Integer
            Get
                Return intNewsletterId
            End Get
            Set(ByVal value As Integer)
                intNewsletterId = value
            End Set
        End Property

        Private intMediaId As Integer
        Public Property MediaId() As Integer
            Get
                Return intMediaId
            End Get
            Set(ByVal value As Integer)
                intMediaId = value
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

        Private intCompanyId As Integer
        Public Property CompanyId() As Integer
            Get
                Return intCompanyId
            End Get
            Set(ByVal value As Integer)
                intCompanyId = value
            End Set
        End Property

    End Class

End Namespace