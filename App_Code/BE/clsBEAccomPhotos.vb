Imports Microsoft.VisualBasic

Namespace Easyway.BE

    Public Class clsBEAccomPhotos

        Private intAccomPhotoId As Integer
        Public Property AccomPhotoId() As Integer
            Get
                Return intAccomPhotoId
            End Get
            Set(ByVal value As Integer)
                intAccomPhotoId = value
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

        Private strPhotoLocation As String
        Public Property PhotoLocation() As String
            Get
                Return strPhotoLocation
            End Get
            Set(ByVal value As String)
                strPhotoLocation = value
            End Set
        End Property

        Private blnDefaultImg As Boolean
        Public Property DefaultImg() As Boolean
            Get
                Return blnDefaultImg
            End Get
            Set(ByVal value As Boolean)
                blnDefaultImg = value
            End Set
        End Property

    End Class

End Namespace