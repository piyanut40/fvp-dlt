Imports System.Data
Imports Npgsql

Partial Class Admin_GuideDtl
    Inherits System.Web.UI.Page
    Protected text As String
    Private car_id As Integer
    Private tbIMG_car As New DataTable

    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "
    Protected Css_Ctrl As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Request.QueryString("gid") <> "" Then
                LoadGuide()
            End If
        End If
    End Sub

    Private Sub LoadGuide()
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection

        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = " select * from guide WHERE guide_id = " & Request.QueryString("gid")

            Dim dr As Npgsql.NpgsqlDataReader
            dr = cmd.ExecuteReader()
            If dr.Read Then
                If dr("prename") IsNot DBNull.Value Then
                    lblgroup_name.Text = dr("prename")
                End If

                If dr("guide_name") IsNot DBNull.Value Then
                    lblgroup_name.Text = lblgroup_name.Text & " " & dr("guide_name")
                End If

                If dr("guide_surname") IsNot DBNull.Value Then
                    lblgroup_name.Text = lblgroup_name.Text & " " & dr("guide_surname")
                End If

                If dr("guide_email") IsNot DBNull.Value Then
                    lblguide_email.Text = dr("guide_email")
                End If

                If dr("guide_tel") IsNot DBNull.Value Then
                    lblguide_tel.Text = dr("guide_tel")
                End If

                If dr("guide_idcard") IsNot DBNull.Value Then
                    lblguide_idcard.Text = dr("guide_idcard")
                End If

                If dr("guide_photo") IsNot DBNull.Value Then
                    hidPhotoAct.Value = dr("guide_photo")
                End If

                If dr("regis_no") IsNot DBNull.Value Then
                    lblregis_no.Text = dr("regis_no")
                End If

                If dr("regis_photo") IsNot DBNull.Value Then
                    Imgregis.ImageUrl = "~/Upload/FileGuide/" & dr("regis_photo")
                    Imgregis.Visible = True
                Else
                    Imgregis.Visible = False
                End If
            End If
            dr.Close()

        Catch ex As Exception

        Finally
            cmd.Connection.Close()
            con = Nothing
        End Try

        If hidPhotoAct.Value <> "" Then
            PhotoAct.ImageUrl = "~/Upload/FileGuide/" & hidPhotoAct.Value
            PhotoAct.Visible = True
            btnUploadAct.Visible = False
            FileUpload5.CssClass = "w3-hide"
            'PhotoDeleteAct.Visible = True
        Else
            PhotoAct.Visible = False
        End If
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request.QueryString("isPopup") Is Nothing Then
            MasterPageFile = "~/MasterPageB.master"
        ElseIf Request.QueryString("isPopup") = "1" Then
            MasterPageFile = "~/MasterPagePopup.master"
        End If
    End Sub
End Class
