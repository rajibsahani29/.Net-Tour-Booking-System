Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEBreakfast

        Private intBreakfastId As Integer
        Public Property BreakfastId() As Integer
            Get
                Return intBreakfastId
            End Get
            Set(ByVal value As Integer)
                intBreakfastId = value
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