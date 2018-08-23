Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEExtrasBaggageLinkRoute

        Private intExtrasBaggageLinkRouteId As Integer
        Public Property ExtrasBaggageLinkRouteId() As Integer
            Get
                Return intExtrasBaggageLinkRouteId
            End Get
            Set(ByVal value As Integer)
                intExtrasBaggageLinkRouteId = value
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