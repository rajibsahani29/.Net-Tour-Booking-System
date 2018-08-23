Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEActivity

        Private intActivityId As Integer
        Public Property ActivityId() As Integer
            Get
                Return intActivityId
            End Get
            Set(ByVal value As Integer)
                intActivityId = value
            End Set
        End Property

        Private strDescx As String
        Public Property Descx() As String
            Get
                Return strDescx
            End Get
            Set(ByVal value As String)
                strDescx = value
            End Set
        End Property

        Private dtDateAdded As DateTime
        Public Property DateAdded() As DateTime
            Get
                Return dtDateAdded
            End Get
            Set(ByVal value As DateTime)
                dtDateAdded = value
            End Set
        End Property

        Private intStaffId As Integer
        Public Property StaffId() As Integer
            Get
                Return intStaffId
            End Get
            Set(ByVal value As Integer)
                intStaffId = value
            End Set
        End Property

    End Class

End Namespace