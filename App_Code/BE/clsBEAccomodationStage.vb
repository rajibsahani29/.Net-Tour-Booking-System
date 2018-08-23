Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAccomodationStage

        Private intAccomodationStageId As Integer
        Public Property AccomodationStageId() As Integer
            Get
                Return intAccomodationStageId
            End Get
            Set(ByVal value As Integer)
                intAccomodationStageId = value
            End Set
        End Property

        Private intAccomId As Integer
        Public Property AccomId() As Integer
            Get
                Return intAccomId
            End Get
            Set(ByVal value As Integer)
                intAccomId = value
            End Set
        End Property

        Private intStageId As Integer
        Public Property StageId() As Integer
            Get
                Return intStageId
            End Get
            Set(ByVal value As Integer)
                intStageId = value
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