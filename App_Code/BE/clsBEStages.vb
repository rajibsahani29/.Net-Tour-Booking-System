Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEStages

        Private intStagesId As Integer
        Public Property StagesId() As Integer
            Get
                Return intStagesId
            End Get
            Set(ByVal value As Integer)
                intStagesId = value
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

        Private dblLongitude As Double
        Public Property Longitude() As Double
            Get
                Return dblLongitude
            End Get
            Set(ByVal value As Double)
                dblLongitude = value
            End Set
        End Property

        Private dblLatitude As Double
        Public Property Latitude() As Double
            Get
                Return dblLatitude
            End Get
            Set(ByVal value As Double)
                dblLatitude = value
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

        Private strMoreInfo As String
        Public Property MoreInfo() As String
            Get
                Return strMoreInfo
            End Get
            Set(ByVal value As String)
                strMoreInfo = value
            End Set
        End Property

    End Class

End Namespace