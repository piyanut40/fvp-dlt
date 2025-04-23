
Partial Class ViewImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("pathImg") Is Nothing Then
            Dim ImageType As String
            Dim fpathstr As String

            ImageType = Request.QueryString("ImageType")
            fpathstr = Request.QueryString("fpath")

            fpathstr = ConfigurationManager.AppSettings("" & fpathstr & "")

            Image.ImageUrl = fpathstr & ImageType
        Else
            'สำหรับดึงภาพจาก WebService
            Image.ImageUrl = Request.QueryString("pathImg")
        End If
    End Sub
End Class
