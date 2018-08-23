Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAdditionalExtras

        Private intAdditionalExtrasId As Integer
        Public Property AdditionalExtrasId() As Integer
            Get
                Return intAdditionalExtrasId
            End Get
            Set(ByVal value As Integer)
                intAdditionalExtrasId = value
            End Set
        End Property

        Private strDescription As String
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal value As String)
                strDescription = value
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

        Private intBookingId As Integer
        Public Property BookingId() As Integer
            Get
                Return intBookingId
            End Get
            Set(ByVal value As Integer)
                intBookingId = value
            End Set
        End Property

        Private blnInvoicex As Boolean
        Public Property Invoicex() As Boolean
            Get
                Return blnInvoicex
            End Get
            Set(ByVal value As Boolean)
                blnInvoicex = value
            End Set
        End Property

    End Class

End Namespace