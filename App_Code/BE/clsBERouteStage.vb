Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBERouteStage

        Private intRouteStageId As Integer
        Public Property RouteStageId() As Integer
            Get
                Return intRouteStageId
            End Get
            Set(ByVal value As Integer)
                intRouteStageId = value
            End Set
        End Property

        Private intRouteId As Integer
        Public Property RouteId() As Integer
            Get
                Return intRouteId
            End Get
            Set(ByVal value As Integer)
                intRouteId = value
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

        Private intRouteSequence As Integer
        Public Property RouteSequence() As Integer
            Get
                Return intRouteSequence
            End Get
            Set(ByVal value As Integer)
                intRouteSequence = value
            End Set
        End Property

    End Class

End Namespace