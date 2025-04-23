Imports QRCoder
Imports System.Drawing
Imports System.IO

Partial Class Control_genQRCode
    Inherits System.Web.UI.Page

    Protected Sub btnGenerate_Click(sender As Object, e As System.EventArgs) 'Handles btnGenerate.Click
        GenerateQRCode(txtCode.Text)
    End Sub

    Private folderPath As String = Server.MapPath(ConfigurationManager.AppSettings("FileQRCode"))
    Private Sub GenerateQRCode(code As String)
        Dim qrGenerator As New QRCodeGenerator()
        Dim qrCode As QRCodeGenerator.QRCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q)
        Dim imgBarCode As New System.Web.UI.WebControls.Image()
        imgBarCode.Height = 160
        imgBarCode.Width = 160

        Dim Ar As String() = Request.QueryString("url").Split("=")
        Dim imagePath As String = folderPath & Ar(1) & ".png"
        If File.Exists(imagePath) Then
            File.Delete(imagePath)
        End If
        Using bitMap As Bitmap = qrCode.GetGraphic(20)
            Using ms As New MemoryStream()
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                Dim byteImage As Byte() = ms.ToArray()
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage)

                Dim cleandata As String = imgBarCode.ImageUrl.Replace("data:image/png;base64,", "")
                Dim data As Byte() = System.Convert.FromBase64String(cleandata)

                Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(ms)
                img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg)
            End Using
            plBarCode.Controls.Add(imgBarCode)
        End Using
    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Not Request.QueryString("url") Is Nothing Then
                GenerateQRCode(Request.QueryString("url"))
            End If
        End If
    End Sub
End Class
