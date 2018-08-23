Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEExtraRouteStage

        Private intExtraRouteStageId As Integer
        Public Property ExtraRouteStageId() As Integer
            Get
                Return intExtraRouteStageId
            End Get
            Set(ByVal value As Integer)
                intExtraRouteStageId = value
            End Set
        End Property

        Private intRouteStageId1 As Integer
        Public Property RouteStageId1() As Integer
            Get
                Return intRouteStageId1
            End Get
            Set(ByVal value As Integer)
                intRouteStageId1 = value
            End Set
        End Property

        Private intRouteStageId2 As Integer
        Public Property RouteStageId2() As Integer
            Get
                Return intRouteStageId2
            End Get
            Set(ByVal value As Integer)
                intRouteStageId2 = value
            End Set
        End Property

        Private intExtraId As Integer
        Public Property ExtraId() As Integer
            Get
                Return intExtraId
            End Get
            Set(ByVal value As Integer)
                intExtraId = value
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

        Private strAdditionalNotes As String
        Public Property AdditionalNotes() As String
            Get
                Return strAdditionalNotes
            End Get
            Set(ByVal value As String)
                strAdditionalNotes = value
            End Set
        End Property

    End Class

End Namespace