Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEStageDistance

        Private intStageDistanceId As Integer
        Public Property StageDistanceId() As Integer
            Get
                Return intStageDistanceId
            End Get
            Set(ByVal value As Integer)
                intStageDistanceId = value
            End Set
        End Property

        Private intStageId1 As Integer
        Public Property StageId1() As Integer
            Get
                Return intStageId1
            End Get
            Set(ByVal value As Integer)
                intStageId1 = value
            End Set
        End Property

        Private intStageId2 As Integer
        Public Property StageId2() As Integer
            Get
                Return intStageId2
            End Get
            Set(ByVal value As Integer)
                intStageId2 = value
            End Set
        End Property

        Private intMiles As Integer
        Public Property Miles() As Integer
            Get
                Return intMiles
            End Get
            Set(ByVal value As Integer)
                intMiles = value
            End Set
        End Property

        Private intKm As Integer
        Public Property Km() As Integer
            Get
                Return intKm
            End Get
            Set(ByVal value As Integer)
                intKm = value
            End Set
        End Property

    End Class

End Namespace