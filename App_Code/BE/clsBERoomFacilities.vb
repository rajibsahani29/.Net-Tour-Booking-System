Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBERoomFacilities

        Private intRoomFacilitiesId As Integer
        Public Property RoomFacilitiesId() As Integer
            Get
                Return intRoomFacilitiesId
            End Get
            Set(ByVal value As Integer)
                intRoomFacilitiesId = value
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