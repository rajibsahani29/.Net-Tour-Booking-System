Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBERoomType

        Private intRoomTypeId As Integer
        Public Property RoomTypeId() As Integer
            Get
                Return intRoomTypeId
            End Get
            Set(ByVal value As Integer)
                intRoomTypeId = value
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

        Private intMaxOccupancy As Integer
        Public Property MaxOccupancy() As Integer
            Get
                Return intMaxOccupancy
            End Get
            Set(ByVal value As Integer)
                intMaxOccupancy = value
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