Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAccomStageRoom

        Private intAccomStageRoomId As Integer
        Public Property AccomStageRoomId() As Integer
            Get
                Return intAccomStageRoomId
            End Get
            Set(ByVal value As Integer)
                intAccomStageRoomId = value
            End Set
        End Property

        Private intAccomRoomTypeId As Integer
        Public Property AccomRoomTypeId() As Integer
            Get
                Return intAccomRoomTypeId
            End Get
            Set(ByVal value As Integer)
                intAccomRoomTypeId = value
            End Set
        End Property

        Private intAccomStageId As Integer
        Public Property AccomStageId() As Integer
            Get
                Return intAccomStageId
            End Get
            Set(ByVal value As Integer)
                intAccomStageId = value
            End Set
        End Property

        Private intNoMales As Integer
        Public Property NoMales() As Integer
            Get
                Return intNoMales
            End Get
            Set(ByVal value As Integer)
                intNoMales = value
            End Set
        End Property

        Private intNoFemales As Integer
        Public Property NoFemales() As Integer
            Get
                Return intNoFemales
            End Get
            Set(ByVal value As Integer)
                intNoFemales = value
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

        Private intNoDogs As Integer
        Public Property NoDogs() As Integer
            Get
                Return intNoDogs
            End Get
            Set(ByVal value As Integer)
                intNoDogs = value
            End Set
        End Property

        Private intNoOfChildren As Integer
        Public Property NoOfChildren() As Integer
            Get
                Return intNoOfChildren
            End Get
            Set(ByVal value As Integer)
                intNoOfChildren = value
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

        Private intBookingId As Integer
        Public Property BookingId() As Integer
            Get
                Return intBookingId
            End Get
            Set(ByVal value As Integer)
                intBookingId = value
            End Set
        End Property

        Private dblTotalCostDogs As Double
        Public Property TotalCostDogs() As Double
            Get
                Return dblTotalCostDogs
            End Get
            Set(ByVal value As Double)
                dblTotalCostDogs = value
            End Set
        End Property

    End Class

End Namespace