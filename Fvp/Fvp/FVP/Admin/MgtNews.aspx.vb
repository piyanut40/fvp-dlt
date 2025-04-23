Imports System.Data
Imports Npgsql
Imports System.IO
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Globalization

Partial Class MgtNews
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected text As String
    Protected name As String

    Dim fPathJodit As String = Server.MapPath(ConfigurationManager.AppSettings("FileJodit"))
    Dim fPathNews As String = Server.MapPath(ConfigurationManager.AppSettings("FileNews"))
    Dim fPathDoc As String = Server.MapPath(ConfigurationManager.AppSettings("FileDocNews"))
    Dim tbFile As New DataTable
    Dim tbImage As New DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_id") Is Nothing Then
            Response.Redirect("../Login.aspx")
        Else
            If Session("user_id").ToString <> "adminbt" Then
                Session.Clear()
                Response.Redirect("../Login.aspx")
            End If
            If Page.IsPostBack = False Then
                loaddata()

                If hidUploadPic1.Value <> "" Then
                    PhotoPic1.ImageUrl = "~/Upload/News/" & hidUploadPic1.Value
                    PhotoPic1.Visible = True
                    btnUploadPic1.Visible = False
                    FilePic1.Visible = False
                    PhotoDeletePic1.Visible = True
                Else
                    btnUploadPic1.Visible = True
                    PhotoPic1.Visible = False
                    FilePic1.Visible = True
                    PhotoDeletePic1.Visible = False
                End If

                If txtDate.Text = "" Then
                    txtDate.Text = Date.Now.Date.ToString("MM/dd/yyyy")
                End If

            End If

            With tbFile
                .Columns.Add("gid")
                .Columns.Add("file_name")
                .Columns.Add("files")
                .Columns.Add("PathDoc")
            End With

            For Each row As GridViewRow In gvFile.Rows
                Dim nrow As DataRow = tbFile.NewRow
                nrow("gid") = CType(row.Cells(0).FindControl("lblid"), Label).Text
                nrow("file_name") = CType(row.Cells(0).FindControl("lblfilename"), Label).Text
                nrow("files") = CType(row.Cells(0).FindControl("lblfiles"), Label).Text
                nrow("PathDoc") = CType(row.Cells(0).FindControl("lblPathDoc"), Label).Text
                tbFile.Rows.Add(nrow)
            Next

            With tbImage
                .Columns.Add("gid")
                .Columns.Add("pic_name")
                .Columns.Add("PathImg")
            End With

            For Each row As GridViewRow In gvImage.Rows
                Dim nrow As DataRow = tbImage.NewRow
                nrow("gid") = CType(row.Cells(0).FindControl("lblID"), Label).Text
                nrow("pic_name") = CType(row.Cells(0).FindControl("lblpic_name"), Label).Text
                nrow("PathImg") = CType(row.Cells(0).FindControl("lblPathImg"), Label).Text
                tbImage.Rows.Add(nrow)
            Next
        End If



    End Sub

    Protected Sub PhotoDeletePic1_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeletePic1.Command
        If File.Exists(fPathNews & hidUploadPic1.Value) Then
            File.Delete(fPathNews & hidUploadPic1.Value)
        End If
        btnUploadPic1.Visible = True
        FilePic1.Visible = True
        hidUploadPic1.Value = ""
        PhotoPic1.Visible = False
        PhotoDeletePic1.Visible = False
    End Sub


    Protected Sub btnUploadPic1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadPic1.Click
        Dim srcName As String
        Dim srcExt As String
        If FilePic1.PostedFile.FileName <> "" Then
            If FilePic1.HasFile Then
                srcName = Path.GetFileName(FilePic1.PostedFile.FileName)
                srcExt = Path.GetExtension(FilePic1.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FilePic1.PostedFile.SaveAs(Server.MapPath("~/Upload/News/") + srcName & srcExt)
                hidUploadPic1.Value = srcName & srcExt
                PhotoPic1.ImageUrl = "~/Upload/News/" & hidUploadPic1.Value
                PhotoPic1.Visible = True
                btnUploadPic1.Visible = False
                FilePic1.Visible = False
                PhotoDeletePic1.Visible = True
            End If
        End If
    End Sub
    Protected Sub btnUploadFile_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadFile.Click
        Dim Filename As String
        Dim srcName As String
        Dim srcExt As String
        If FileDoc.PostedFile.FileName <> "" Then
            If FileDoc.HasFile Then
                Filename = Path.GetFileName(FileDoc.PostedFile.FileName)
                srcExt = Path.GetExtension(FileDoc.PostedFile.FileName)
                srcName = (Filename & DateTime.Now).GetHashCode
                FileDoc.PostedFile.SaveAs(Server.MapPath("~/Upload/DocNews/") + srcName & srcExt)
         
                Try
                    Dim nrow As DataRow = tbFile.NewRow
                    nrow.Item("gid") = tbFile.Rows.Count + 1
                    nrow.Item("file_name") = Filename
                    nrow.Item("files") = srcName + srcExt
                    nrow.Item("PathDoc") = "~/Upload/DocNews/" + srcName + srcExt
                    tbFile.Rows.Add(nrow)
                    nrow = Nothing
                    gvFile.DataSource = tbFile
                    gvFile.DataBind()

                Catch ex As Exception
                End Try

            End If
        End If
    End Sub
    Protected Sub FileDelete_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try
            Dim FileID As Integer = e.CommandArgument
            Dim nrow As DataRow = tbFile.Select("gid=" & FileID)(0)
            If File.Exists(fPathDoc & nrow("files")) Then
                File.Delete(fPathDoc & nrow("files"))
            End If
            tbFile.Select("gid=" & FileID)(0).Delete()
            gvFile.DataSource = tbFile
            gvFile.DataBind()
            updFile.Update()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
        End Try
    End Sub

    Protected Sub btnUploadPhotoNews2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadPhotoNews2.Click
        Dim srcName As String
        Dim srcExt As String
        If FilePhotoPic2.PostedFile.FileName <> "" Then
            If FilePhotoPic2.HasFile Then
                srcName = Path.GetFileName(FilePhotoPic2.PostedFile.FileName)
                srcExt = Path.GetExtension(FilePhotoPic2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FilePhotoPic2.PostedFile.SaveAs(Server.MapPath("~/Upload/News/") + srcName & srcExt)
                hidPhotoNews2.Value = srcName & srcExt
                PhotoNews2.ImageUrl = "~/Upload/News/" & hidPhotoNews2.Value
                PhotoNews2.Visible = False
                btnUploadPhotoNews2.Visible = True
                FilePhotoPic2.Visible = True
                Try
                    Dim nrow As DataRow = tbImage.NewRow
                    nrow.Item("gid") = tbImage.Rows.Count + 1
                    nrow.Item("pic_name") = hidPhotoNews2.Value
                    nrow.Item("PathImg") = "~/Upload/News/" & hidPhotoNews2.Value
                    tbImage.Rows.Add(nrow)
                    nrow = Nothing
                    gvImage.DataSource = tbImage
                    gvImage.DataBind()

                    DtlImg.DataSource = tbImage
                    DtlImg.DataBind()
                    UpdgvFile.Update()
                Catch ex As Exception
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
                End Try
            End If
        End If
    End Sub

    Protected Sub PhotoCarDelete_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) 'Handles PhotoCarDelete.Command
        Try
            Dim FileID As Integer = e.CommandArgument
            Dim nrow As DataRow = tbImage.Select("gid=" & FileID)(0)
            If File.Exists(fPathNews & nrow("pic_name")) Then
                File.Delete(fPathNews & nrow("pic_name"))
            End If
            tbImage.Select("gid=" & FileID)(0).Delete()
            gvImage.DataSource = tbImage
            gvImage.DataBind()
            DtlImg.DataSource = tbImage
            DtlImg.DataBind()
            UpdgvFile.Update()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
        End Try
    End Sub
    Private Sub loaddata()
        Dim dbConnect As New DBConnect
        Dim cmd As New Npgsql.NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dr As Npgsql.NpgsqlDataReader

        Try
            con.Open()
            cmd.Connection = con
            If Request.QueryString("id") Then
                Dim sqlstr As String = "SELECT title , detail , date_news , pic from news WHERE news_id =  '" & Request.QueryString("id") & "' "
                cmd.CommandText = CommandType.Text
                cmd.Parameters.Clear()
                cmd.CommandText = sqlstr
                dr = cmd.ExecuteReader()
                If dr.Read Then
                    If dr("title") IsNot DBNull.Value Then
                        txtTitle.Text = dr("title")
                    End If

                    If dr("detail") IsNot DBNull.Value Then
                        txtDetail.Text = dr("detail")
                    End If

                    If dr("date_news") IsNot DBNull.Value Then
                        txtDate.Text = Format(dr("date_news"), "MM/dd/yyyy")
                    End If

                    If dr("pic") IsNot DBNull.Value Then
                        hidUploadPic1.Value = dr("pic")
                        PhotoPic1.ImageUrl = "~/Upload/News/" & hidUploadPic1.Value
                        PhotoPic1.Visible = True
                        btnUploadPic1.Visible = False
                        FilePic1.Visible = False
                        PhotoDeletePic1.Visible = True
                    End If

                End If
                dr.Close()

                'ไฟล์ 
                Dim sqlstrFile As String
                sqlstrFile = "select gid , news_id , file_name , files ,  CAST('~/Upload/DocNews/' || files as Varchar) as PathDoc from news_file WHERE news_id = '" & Request.QueryString("id") & "' "
                Dim DataTable As DataTable = dbConnect.getDataTable(sqlstrFile, "DataTable")
                If DataTable.Rows.Count > 0 Then
                    gvFile.DataSource = DataTable
                    gvFile.DataBind()
                End If


                'รูป 
                Dim sqlstrImg As String
                sqlstrImg = "select gid , news_id , pic_name , CAST('~/Upload/News/' || pic_name as Varchar) as PathImg from news_pic WHERE news_id = '" & Request.QueryString("id") & "' "
                Dim DataTable2 As DataTable = dbConnect.getDataTable(sqlstrImg, "sqlstrImg")
                If DataTable2.Rows.Count > 0 Then
                    gvImage.DataSource = DataTable2
                    gvImage.DataBind()
                    DtlImg.DataSource = DataTable2
                    DtlImg.DataBind()
                    UpdgvFile.Update()
                End If


            Else

            End If

        Catch ex As Exception

        Finally
            cmd.Connection.Close()
            con.Close()

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New Npgsql.NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Dim news_id As Integer
        Try
            con.Open()
            cmd.Connection = con
            If Request.QueryString("id") <> "" Then
                Dim strUpdate As String = "Update news set title=:title , date_news=:date_news , detail=:detail , pic=:pic  WHERE news_id =  '" & Request.QueryString("id") & "' "
                cmd.CommandText = CommandType.Text
                cmd.CommandText = strUpdate
                cmd.Parameters.Clear()
                cmd.Parameters.Add("detail", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtDetail.Text
                cmd.Parameters.Add("title", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtTitle.Text
                cmd.Parameters.Add("date_news", NpgsqlTypes.NpgsqlDbType.Date).Value = txtDate.Text
                cmd.Parameters.Add("pic", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidUploadPic1.Value
                news_id = Request.QueryString("id")
                cmd.ExecuteNonQuery()

            Else

                Dim strIns As String = " INSERT Into news (title , date_news , detail , pic) VALUES(:title , :date_news , :detail , :pic ) RETURNING news_id  "
                cmd.CommandText = CommandType.Text
                cmd.CommandText = strIns
                cmd.Parameters.Clear()
                cmd.Parameters.Add("detail", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtDetail.Text
                cmd.Parameters.Add("title", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtTitle.Text
                cmd.Parameters.Add("date_news", NpgsqlTypes.NpgsqlDbType.Date).Value = txtDate.Text
                cmd.Parameters.Add("pic", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidUploadPic1.Value
                news_id = cmd.ExecuteScalar

            End If

            Dim strCheckFile As String = "SELECT gid from news_file WHERE news_id = '" & news_id & "' "
            cmd.CommandText = CommandType.Text
            cmd.CommandText = strCheckFile
            cmd.Parameters.Clear()
            dread = cmd.ExecuteReader()

            If dread.Read Then
                dread.Close()
                Dim cRowf As DataRow
                Dim drRow() As DataRow
                Dim TbFileOld As New DataTable

                cmd.CommandText = CommandType.Text
                cmd.CommandText = strCheckFile
                TbFileOld = dbConnect.getDataTable(strCheckFile, "TbFileOld")

                '-------เพิ่มข้อมูลไฟล์------------

                For introw = 0 To tbFile.Rows.Count - 1
                    cRowf = tbFile.Rows(introw)
                    drRow = TbFileOld.Select("gid = " & cRowf("gid"))

                    If drRow.Length > 0 Then
                        cmd.CommandText = "Update news_file set news_id=:news_id , file_name=:file_name , files=:files   WHERE gid = " & cRowf("gid")
                        TbFileOld.Rows.Remove(drRow(0))
                    Else
                        cmd.CommandText = "Insert Into news_file ( news_id , file_name , files  ) VALUES (:news_id , :file_name , :files ) "

                    End If
                    cmd.Parameters.Add(":news_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = news_id
                    cmd.Parameters.Add(":file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("file_name")
                    cmd.Parameters.Add(":files", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("files")
                    cmd.ExecuteNonQuery()
                Next

                '-------ลบข้อมูลไฟล์----------

                For Each crow In TbFileOld.Rows
                    cmd.Parameters.Clear()
                    cmd.CommandText = "delete from news_file where gid =" & crow("gid")
                    cmd.ExecuteScalar()
                Next


            Else
                dread.Close()
                Dim cRowf As DataRow
                For introw = 0 To tbFile.Rows.Count - 1
                    cRowf = tbFile.Rows(introw)
                    cmd.Parameters.Clear()
                    cmd.CommandText = "Insert Into news_file ( news_id , file_name , files  ) VALUES (:news_id , :file_name , :files ) "
                    cmd.Parameters.Add(":news_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = news_id
                    cmd.Parameters.Add(":file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("file_name")
                    cmd.Parameters.Add(":files", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("files")
                    cmd.ExecuteNonQuery()
                Next
            End If



            '--------------เพิ่มรูป-----------------

            Dim strCheckImg As String = "SELECT gid from news_pic WHERE news_id = '" & news_id & "' "
            cmd.CommandText = CommandType.Text
            cmd.CommandText = strCheckImg
            cmd.Parameters.Clear()
            dread = cmd.ExecuteReader()

            If dread.Read Then
                dread.Close()
                Dim cRowf As DataRow
                Dim drRow() As DataRow
                Dim TbImgOld As New DataTable

                cmd.CommandText = CommandType.Text
                cmd.CommandText = strCheckImg
                TbImgOld = dbConnect.getDataTable(strCheckImg, "TbImgOld")

                '-------เพิ่มข้อมูลไฟล์------------

                For introw = 0 To tbImage.Rows.Count - 1
                    cRowf = tbImage.Rows(introw)
                    drRow = TbImgOld.Select("gid = " & cRowf("gid"))

                    If drRow.Length > 0 Then
                        cmd.CommandText = "Update news_pic set news_id=:news_id , pic_name=:pic_name  WHERE gid = " & cRowf("gid")
                        TbImgOld.Rows.Remove(drRow(0))
                    Else
                        cmd.CommandText = "Insert Into news_pic ( news_id , pic_name   ) VALUES (:news_id , :pic_name  ) "

                    End If
                    cmd.Parameters.Add(":news_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = news_id
                    cmd.Parameters.Add(":pic_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("pic_name")
                    cmd.ExecuteNonQuery()
                Next

                '-------ลบข้อมูลไฟล์----------

                For Each crow In TbImgOld.Rows
                    cmd.Parameters.Clear()
                    cmd.CommandText = "delete from news_pic where gid =" & crow("gid")
                    cmd.ExecuteScalar()
                Next


            Else
                dread.Close()
                Dim cRowf As DataRow
                For introw = 0 To tbImage.Rows.Count - 1
                    cRowf = tbImage.Rows(introw)
                    cmd.Parameters.Clear()
                    cmd.CommandText = "Insert Into news_pic ( news_id , pic_name   ) VALUES (:news_id , :pic_name  ) "
                    cmd.Parameters.Add(":news_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = news_id
                    cmd.Parameters.Add(":pic_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("pic_name")
                    cmd.ExecuteNonQuery()
                Next
            End If



            Response.Redirect("News.aspx")




        Catch ex As Exception

            Dim alert As String = "alert('กรุณาใส่ข้อมูลให้ครบถ้วน');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)


        Finally
            cmd.Connection.Close()
            con.Close()
        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("News.aspx")
    End Sub
End Class
