Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBERoute

        Private intRouteId As Integer
        Public Property RouteId() As Integer
            Get
                Return intRouteId
            End Get
            Set(ByVal value As Integer)
                intRouteId = value
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

        Private intCompanyId As Integer
        Public Property CompanyId() As Integer
            Get
                Return intCompanyId
            End Get
            Set(ByVal value As Integer)
                intCompanyId = value
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

        Private strDocLink As String
        Public Property DocLink() As String
            Get
                Return strDocLink
            End Get
            Set(ByVal value As String)
                strDocLink = value
            End Set
        End Property

        Private dblSingleSupplement As Double
        Public Property SingleSupplement() As Double
            Get
                Return dblSingleSupplement
            End Get
            Set(ByVal value As Double)
                dblSingleSupplement = value
            End Set
        End Property

        Private strCodex As String
        Public Property Codex() As String
            Get
                Return strCodex
            End Get
            Set(ByVal value As String)
                strCodex = value
            End Set
        End Property

        Private dblCostGuideBook As Double
        Public Property CostGuideBook() As Double
            Get
                Return dblCostGuideBook
            End Get
            Set(ByVal value As Double)
                dblCostGuideBook = value
            End Set
        End Property

        Private strExternalLink1 As String
        Public Property ExternalLink1() As String
            Get
                Return strExternalLink1
            End Get
            Set(ByVal value As String)
                strExternalLink1 = value
            End Set
        End Property

        Private strExternalLink2 As String
        Public Property ExternalLink2() As String
            Get
                Return strExternalLink2
            End Get
            Set(ByVal value As String)
                strExternalLink2 = value
            End Set
        End Property

        Private strMapLink As String
        Public Property MapLink() As String
            Get
                Return strMapLink
            End Get
            Set(ByVal value As String)
                strMapLink = value
            End Set
        End Property

    End Class

End Namespace