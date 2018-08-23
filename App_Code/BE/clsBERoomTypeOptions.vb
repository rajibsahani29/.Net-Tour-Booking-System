Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBERoomTypeOptions

        Private intRoomTypeOptionsId As Integer
        Public Property RoomTypeOptionsId() As Integer
            Get
                Return intRoomTypeOptionsId
            End Get
            Set(ByVal value As Integer)
                intRoomTypeOptionsId = value
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