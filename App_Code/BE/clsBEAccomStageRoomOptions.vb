Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAccomStageRoomOptions

        Private intAccomStageRoomOptionsId As Integer
        Public Property AccomStageRoomOptionsId() As Integer
            Get
                Return intAccomStageRoomOptionsId
            End Get
            Set(ByVal value As Integer)
                intAccomStageRoomOptionsId = value
            End Set
        End Property

        Private intAccomStageRoomId As Integer
        Public Property AccomStageRoomId() As Integer
            Get
                Return intAccomStageRoomId
            End Get
            Set(ByVal value As Integer)
                intAccomStageRoomId = value
            End Set
        End Property

        Private intRoomTypeOptionId As Integer
        Public Property RoomTypeOptionId() As Integer
            Get
                Return intRoomTypeOptionId
            End Get
            Set(ByVal value As Integer)
                intRoomTypeOptionId = value
            End Set
        End Property

    End Class

End Namespace