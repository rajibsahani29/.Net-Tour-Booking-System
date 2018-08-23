Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAccomRouteStage

#Region "Accom_Stage"

        Private intAccomStageId As Integer
        Public Property AccomStageId() As Integer
            Get
                Return intAccomStageId
            End Get
            Set(ByVal value As Integer)
                intAccomStageId = value
            End Set
        End Property

        Private intStageId As Integer
        Public Property StageId() As Integer
            Get
                Return intStageId
            End Get
            Set(ByVal value As Integer)
                intStageId = value
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

        Private intSequence As Integer
        Public Property Sequence() As Integer
            Get
                Return intSequence
            End Get
            Set(ByVal value As Integer)
                intSequence = value
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

        Private intRouteStageId As Integer
        Public Property RouteStageId() As Integer
            Get
                Return intRouteStageId
            End Get
            Set(ByVal value As Integer)
                intRouteStageId = value
            End Set
        End Property

        Private strDirection As String
        Public Property Direction() As String
            Get
                Return strDirection
            End Get
            Set(ByVal value As String)
                strDirection = value
            End Set
        End Property

        Private bnlSetPaid As Boolean
        Public Property SetPaid() As Boolean
            Get
                Return bnlSetPaid
            End Get
            Set(ByVal value As Boolean)
                bnlSetPaid = value
            End Set
        End Property

        Private strSupplierNote As String
        Public Property SupplierNote() As String
            Get
                Return strSupplierNote
            End Get
            Set(ByVal value As String)
                strSupplierNote = value
            End Set
        End Property

        Private strClientNote As String
        Public Property ClientNote() As String
            Get
                Return strClientNote
            End Get
            Set(ByVal value As String)
                strClientNote = value
            End Set
        End Property

        Private strInvoiceNote As String
        Public Property InvoiceNote() As String
            Get
                Return strInvoiceNote
            End Get
            Set(ByVal value As String)
                strInvoiceNote = value
            End Set
        End Property

#End Region

    End Class

End Namespace