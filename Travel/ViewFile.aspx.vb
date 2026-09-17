Imports System.Diagnostics
Imports System.Net

Partial Class ViewFile
    Inherits System.Web.UI.Page
    Private fname, sname, fpathstr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fname = Server.UrlPathEncode(Request.QueryString("fname"))
        sname = Request.QueryString("sname")
        fpathstr = Request.QueryString("fpath")

        fpathstr = Server.MapPath(ConfigurationManager.AppSettings("" & fpathstr & ""))

        'dialogSave()

        Dim pathFile As String = fpathstr & sname

        Try

            Dim User As WebClient = New WebClient()
            Dim FileBuffer As Byte() = User.DownloadData(pathFile)

            If FileBuffer IsNot Nothing Then
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-length", FileBuffer.Length.ToString())
                Response.BinaryWrite(FileBuffer)
            End If

            'End If
        Catch ex As Exception
            'lblwait.Text = "�������ö�Դ��� PDF �� Error " & ex.Message.ToString
            'Response.Write("<script language='javascript'> alert('" & ex.Message.ToString & "')</script>")
        End Try

    End Sub
    Private Sub dialogSave()
        Dim objFileInfo As System.IO.FileInfo
        Try

            If Not System.IO.File.Exists(fpathstr & sname) Then Exit Sub
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
    End Sub


End Class
