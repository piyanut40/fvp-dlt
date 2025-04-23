Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Drawing.Drawing2D

Partial Class Control_UploadFileM
    Inherits System.Web.UI.Page

    Private supportedIMG As String = ",.jpeg,.jpg,.gif,.png,.bmp,"
    Private supportedFile As String = ",.doc,.docx,.xls,.xlsx,.xlxs,.ppt,.pptx,.pdf,.jpeg,.jpg,.gif,.png,.bmp,"
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdd.Click
        Dim Folder As String = Request.QueryString("f")
        Dim Path As String = Server.MapPath(ConfigurationManager.AppSettings(Folder))
        saveFile(Me.Attach, Folder, Path)
    End Sub

    Public Sub saveFile(ByVal fuAttach As FileUpload, ByVal s As String, ByVal fPath As String)
        Dim fSize, maxFSize As Integer
        Dim srcFName, srcExt, sName As String

        'If txtname.Text = "" Then
        srcFName = Path.GetFileName(fuAttach.PostedFile.FileName)
        'Else
        '    srcFName = txtname.Text
        'End If

        srcExt = Path.GetExtension(fuAttach.PostedFile.FileName)
        maxFSize = 20000 '5120 'lblSize.Text

        If srcFName.Length <> 0 Then

            If supportedFile.Contains("," & srcExt.ToLower.Trim & ",") Then
                fSize = CInt((fuAttach.PostedFile.ContentLength.ToString()) / 1024)
                If fSize = 0 Then
                    fSize = 1
                End If

                If fSize < maxFSize Then

                    sName = (srcFName & DateTime.Now).GetHashCode
                    'save file

                    If Not Directory.Exists(fPath) Then
                        Directory.CreateDirectory(fPath)
                    End If

                    fuAttach.PostedFile.SaveAs(fPath & sName & srcExt)
                    'lblError.Text = ""

                    If supportedIMG.Contains("," & srcExt.ToLower.Trim & ",") Then
                        FileSize(Server.MapPath(ConfigurationManager.AppSettings(Request.QueryString("f") & "Small") & sName & srcExt), fPath & sName & srcExt, 180)
                    End If

                    Dim script As String = "window.parent.iFrame_OnUploadComplete" & Request.QueryString("type") & s.ToString & "('" & srcFName & _
                    "','" & sName & srcExt & "'); "
                    ClientScript.RegisterStartupScript(Page.GetType, "Upload Completed", script, True)
                Else
                    'lblError.Text = "ไม่สามารถเพิ่มไฟล์ " & srcFName & "(" & fSize & "K) เนื่องจากขนาดไฟล์มากกว่า " & maxFSize & "K"
                End If
            Else
                'lblError.Text = "ไม่สามารถเพิ่มไฟล์ " & srcFName & " เนื่องระบบไม่รองรับไฟล์ " & srcExt
            End If
        End If
    End Sub

    Private Sub FileSize(ByVal urlImgNew As String, ByVal urlImgOld As String, ByVal MaxHeight As Integer)
        Dim bm As New Bitmap(urlImgOld) 'ที่อยู่ Part และชื่อไฟล์ที่จะ ลดขนาด
        Dim MaxWidth As Integer = 250
        Dim width As Integer
        Dim height As Integer
        If bm.Width > MaxWidth Then
            width = MaxWidth
            height = (MaxWidth * bm.Height) / bm.Width
        ElseIf bm.Height > MaxHeight Then
            width = (MaxHeight * bm.Width) / bm.Height
            height = MaxHeight
        Else
            width = bm.Width
            height = bm.Height
        End If

        Dim thumb As New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(thumb)
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel)
        g.Dispose()
        bm.Dispose()

        'image path New.
        thumb.Save(urlImgNew) 'can use any image format
        thumb.Dispose()
    End Sub

    Private PopulateS As New PopulateScript
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If PopulateS.IsMobile Then
            Attach.Width = Unit.Pixel(180)
        End If

        If Request.QueryString("support") = "File" Then
            btnAdd.ImageUrl = "~/image/document-add.png"
        End If
    End Sub
End Class
