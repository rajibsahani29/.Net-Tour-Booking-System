Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEExtrasBaggageDetails

        Private intExtrasBaggageDetailsId As Integer
        Public Property ExtrasBaggageDetailsId() As Integer
            Get
                Return intExtrasBaggageDetailsId
            End Get
            Set(ByVal value As Integer)
                intExtrasBaggageDetailsId = value
            End Set
        End Property

        Private intExtraId As Integer
        Public Property ExtraId() As Integer
            Get
                Return intExtraId
            End Get
            Set(ByVal value As Integer)
                intExtraId = value
            End Set
        End Property

        Private strStages As String
        Public Property Stages() As String
            Get
                Return strStages
            End Get
            Set(ByVal value As String)
                strStages = value
            End Set
        End Property

        Private strBags As String
        Public Property Bags() As String
            Get
                Return strBags
            End Get
            Set(ByVal value As String)
                strBags = value
            End Set
        End Property

        Private dblPrices As Double
        Public Property Prices() As Double
            Get
                Return dblPrices
            End Get
            Set(ByVal value As Double)
                dblPrices = value
            End Set
        End Property

        Private strInstruction1 As String
        Public Property Instruction1() As String
            Get
                Return strInstruction1
            End Get
            Set(ByVal value As String)
                strInstruction1 = value
            End Set
        End Property

        Private strInstruction2 As String
        Public Property Instruction2() As String
            Get
                Return strInstruction2
            End Get
            Set(ByVal value As String)
                strInstruction2 = value
            End Set
        End Property

    End Class

End Namespace