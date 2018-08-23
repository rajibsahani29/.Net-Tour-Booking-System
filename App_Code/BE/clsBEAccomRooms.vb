Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAccomRooms

#Region "Accom_RoomType"

        Private intAccomRoomTypeId As Integer
        Public Property AccomRoomTypeId() As Integer
            Get
                Return intAccomRoomTypeId
            End Get
            Set(ByVal value As Integer)
                intAccomRoomTypeId = value
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

        Private intRoomTypeId As Integer
        Public Property RoomTypeId() As Integer
            Get
                Return intRoomTypeId
            End Get
            Set(ByVal value As Integer)
                intRoomTypeId = value
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

#End Region

#Region "Accom_RoomType_Facilities"

        Private intAccomRoomTypeFacilitiesId As Integer
        Public Property AccomRoomTypeFacilitiesId() As Integer
            Get
                Return intAccomRoomTypeFacilitiesId
            End Get
            Set(ByVal value As Integer)
                intAccomRoomTypeFacilitiesId = value
            End Set
        End Property

        Private intRoomFacilitiesId As Integer
        Public Property RoomFacilitiesId() As Integer
            Get
                Return intRoomFacilitiesId
            End Get
            Set(ByVal value As Integer)
                intRoomFacilitiesId = value
            End Set
        End Property

#End Region

#Region "RoomType_Options"

        Private intRoomTypeOptionsId As Integer
        Public Property RoomTypeOptionsId() As Integer
            Get
                Return intRoomTypeOptionsId
            End Get
            Set(ByVal value As Integer)
                intRoomTypeOptionsId = value
            End Set
        End Property

        Private intRoomTypeOptionsDescId As Integer
        Public Property RoomTypeOptionsDescId() As Integer
            Get
                Return intRoomTypeOptionsDescId
            End Get
            Set(ByVal value As Integer)
                intRoomTypeOptionsDescId = value
            End Set
        End Property

#End Region

    End Class

End Namespace
