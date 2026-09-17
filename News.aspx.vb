Imports System
Imports System.Web
Imports System.Data
Imports System.IO
Imports System.Net

Partial Class News

    Inherits System.Web.UI.Page
    Dim PopulateJs As New PopulateScript
    Public DtNews As DataTable
    Public DivNews As String
    Public pScript As String = ""
    Public ImgNews As DataTable
    Public imgDoc As DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("id") = "" Then
            Panel1.Visible = True
            Panel2.Visible = False
        Else
            Panel1.Visible = False
            Panel2.Visible = True
            If Page.IsPostBack = False Then
                getNew()
            End If
        End If


        
    End Sub

    Private enCul As New System.Globalization.CultureInfo("en-US")

    Private Sub getNew()
        Dim newsId As Integer
        If Not Integer.TryParse(Request.QueryString("id"), newsId) Then
            Return
        End If

        Dim dbconnect As New DBConnect
        Dim cmd As New Npgsql.NpgsqlCommand
        Dim dr As Npgsql.NpgsqlDataReader
        Dim con As Npgsql.NpgsqlConnection = dbconnect.getConnection
        Try
            con.Open()
            Dim str As String = "SELECT title , detail , pic , date_news from news WHERE news_id = :news_id"
            Dim strImg As String = "SELECT CAST('Upload/News/' || pic_name as varchar) as pic , CAST('~/Upload/News/' || pic_name as varchar) as url from news_pic WHERE news_id = :news_id"
            Dim strDoc As String = "SELECT file_name , CAST('~/Upload/DocNews/' || files as varchar ) as url  from news_file WHERE news_id = :news_id"

            Dim cmdImg As New Npgsql.NpgsqlCommand(strImg, con)
            cmdImg.Parameters.AddWithValue("news_id", newsId)
            Dim adapImg As New Npgsql.NpgsqlDataAdapter(cmdImg)
            Dim tblImg As New DataTable("Img")
            adapImg.Fill(tblImg)
            dtlImg.DataSource = tblImg
            dtlImg.DataBind()

            Dim cmdDoc As New Npgsql.NpgsqlCommand(strDoc, con)
            cmdDoc.Parameters.AddWithValue("news_id", newsId)
            Dim adapDoc As New Npgsql.NpgsqlDataAdapter(cmdDoc)
            Dim tblDoc As New DataTable("doc")
            adapDoc.Fill(tblDoc)
            dtlFile.DataSource = tblDoc
            dtlFile.DataBind()



            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = str
            cmd.Parameters.AddWithValue("news_id", newsId)
            dr = cmd.ExecuteReader

            If dr.Read Then
                If dr("title") IsNot DBNull.Value Then
                    lbltitle.Text = dr("title")
                End If
                If dr("detail") IsNot DBNull.Value Then
                    lblDetail.Text = dr("detail")
                End If


            End If
            dr.Close()




        Catch ex As Exception

        Finally
            con.Close()
            con.Dispose()
            cmd.Connection.Close()
            cmd.Dispose()
            dbconnect = Nothing
        End Try






    End Sub
End Class
