
Partial Class LoadDatabase
    Inherits System.Web.UI.Page

    Private fname, sname, fpathstr As String
    Protected Sub BtnLoadFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLoadFile.Click
        fname = txtfileName.Text
        sname = txtfileName.Text

        fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileBackupDB"))

        dialogSave()
    End Sub

    Private Sub dialogSave()
        
    

        If Not System.IO.File.Exists(fpathstr & sname) Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "alert('ไม่พบไฟล์ดังกล่าว!!! \nกรุณาตรวจสอบวันที่ตรงกับวันศุกร์เท่านั้น');", True)
        Else
            Dim objFileInfo As System.IO.FileInfo
            Try
                objFileInfo = New System.IO.FileInfo(fpathstr & sname)
                Response.Clear()

                Response.AddHeader("Content-Disposition", "attachment; filename=" & Server.UrlPathEncode(fname))
                Response.AddHeader("Content-Length", objFileInfo.Length.ToString())
                Response.ContentType = "application/octet-stream"
                Response.WriteFile(objFileInfo.FullName)
            Catch

            Finally
                Response.End()
            End Try
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            txtfileName.Text = "BorderTransport_" & Format(CDate(Now), "yyyyMMdd") & "_020000.zip"
        End If
    End Sub
End Class
