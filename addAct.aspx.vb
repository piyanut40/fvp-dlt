Imports Npgsql
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Globalization



Partial Class addAct
    Inherits System.Web.UI.Page
    Protected statusth As String
    Protected Img As String
    Protected name As String


    Dim fPathAct As String = Server.MapPath(ConfigurationManager.AppSettings("FileAct"))



    Private populate As New PopulateDropDown
    Dim checktab As Integer

    Private tbImage As New DataTable
    Private tbSpareDriver As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Dim dr As Npgsql.NpgsqlDataReader
            Try
                Dim token As String = Request.QueryString("token")
                con.Open()
                cmd.Connection = con
                cmd.CommandText = " SELECT act.act_id , act_no , act_name , act_tankno , act_ends , act_photo , act_company , act_start from license " & _
                                  " LEFT JOIN act on act.act_id = license.act_id WHERE token = '" & token & "'"
                dr = cmd.ExecuteReader()

                If dr.Read Then

                    Session("act_id") = dr("act_id")

                    If dr("act_name") IsNot DBNull.Value Then
                        txtActName.Text = dr("act_name")
                    End If

                    If dr("act_no") IsNot DBNull.Value Then
                        txtActNo.Text = dr("act_no")
                    End If

                    If dr("act_tankno") IsNot DBNull.Value Then
                        txtActTankNo.Text = dr("act_tankno")
                    End If

                    If dr("act_ends") IsNot DBNull.Value Then
                        txtActExpire.Text = dr("act_ends")
                        txtActExpire.Text = Format(CDate(txtActExpire.Text), "MM/dd/yyyy")
                    End If


                    If dr("act_photo") IsNot DBNull.Value Then
                        hidPhotoAct.Value = dr("act_photo")
                    End If


                    If dr("act_company") IsNot DBNull.Value Then
                        txtActCompany.Text = dr("act_company")
                    End If


                    If dr("act_start") IsNot DBNull.Value Then
                        txtActStart.Text = dr("act_start")
                        txtActStart.Text = Format(CDate(txtActStart.Text), "MM/dd/yyyy")
                    End If
                End If
            Catch ex As Exception
            End Try
            If hidPhotoAct.Value <> "" Then
                PhotoAct.ImageUrl = "~/Upload/Act/" & hidPhotoAct.Value
                PhotoAct.Visible = True
                btnUploadAct.Visible = False
                FileUpload5.Visible = False
                PhotoDeleteAct.Visible = True
            Else
                PhotoAct.Visible = False
            End If

        End If
    End Sub
    ''อัพโหลด และ ลบ รูป กรมธรรม์
    Protected Sub PhotoDeleteAct_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteAct.Command
        If File.Exists(fPathAct & hidPhotoAct.Value) Then
            File.Delete(fPathAct & hidPhotoAct.Value)
        End If
        btnUploadAct.Visible = True
        FileUpload5.Visible = True
        hidPhotoAct.Value = ""
        PhotoAct.Visible = False
        PhotoDeleteAct.Visible = False
    End Sub

    Protected Sub btnNext4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext4.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            Dim strUpdate = "Update act set act_no=:act_no , act_company=:act_company , act_name=:act_name , act_tankno=:act_tankno , act_start=:act_start , act_ends=:act_ends , act_photo=:act_photo " & _
                            "WHERE act_id = '" & Session("act_id") & "' "
            cmd.CommandText = CommandType.Text
            cmd.CommandText = strUpdate
            cmd.Parameters.Clear()
            cmd.Parameters.Add("act_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtActNo.Text
            cmd.Parameters.Add("act_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtActName.Text
            cmd.Parameters.Add("act_tankno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtActTankNo.Text
            cmd.Parameters.Add("act_start", NpgsqlTypes.NpgsqlDbType.Date).Value = txtActStart.Text
            cmd.Parameters.Add("act_ends", NpgsqlTypes.NpgsqlDbType.Date).Value = txtActExpire.Text
            cmd.Parameters.Add("act_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoAct.Value
            cmd.Parameters.Add("act_company", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtActCompany.Text
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim strError = "alert('Fill information and please try again !');"
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", strError, True)
        Finally
            cmd.Connection.Close()
            con.Close()
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "Submit();", True)
        End Try



    End Sub
End Class
