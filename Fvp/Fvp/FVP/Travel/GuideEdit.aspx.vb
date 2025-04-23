Imports Npgsql
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Globalization



Partial Class GuideEdit

    Inherits System.Web.UI.Page
    Protected statusth As String
    Protected Img As String
    Protected name As String
    Dim fpathGuide As String = Server.MapPath(ConfigurationManager.AppSettings("FileGuide"))
    Private populate As New PopulateDropDown
    Dim checktab As Integer
    Private tbImage As New DataTable
    Private tbSpareDriver As New DataTable
    Private isUpdate

    Private guide_id As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.QueryString("id") Is Nothing Then
            guide_id = Request.QueryString("id")
        ElseIf Not Request.QueryString("token") Is Nothing Then
            Dim db As New DBConnect
            Try
                guide_id = db.executeScalar("select guide_id from guide where crypt(guide_id :: text, 'guide2562') = '" & Request.QueryString("token") & "' ")
            Catch ex As Exception

            Finally
                db = Nothing
            End Try
        End If

        If Page.IsPostBack = False Then
            If guide_id > 0 Then
                LoadGuide()
            End If
        End If
    End Sub


    Private Sub LoadGuide()
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dr As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select * from guide WHERE Guide_id = " & guide_id & " And travel_user_id = " & Session("user_id")

            dr = cmd.ExecuteReader()
            If dr.Read Then

                If dr("guide_name") IsNot DBNull.Value Then
                    txtName.Text = dr("guide_name")
                End If

                If dr("guide_surname") IsNot DBNull.Value Then
                    txtSurname.Text = dr("guide_surname")
                End If

                If dr("guide_email") IsNot DBNull.Value Then
                    txtEmail.Text = dr("guide_email")
                End If

                If dr("guide_tel") IsNot DBNull.Value Then
                    txtTelephone.Text = dr("guide_tel")
                End If


                If dr("guide_idcard") IsNot DBNull.Value Then
                    txtIdcard.Text = dr("guide_idcard")
                End If

                If dr("guide_photo") IsNot DBNull.Value Then
                    hidPhotoAct.Value = dr("guide_photo")
                End If

                If Not dr("prename") Is DBNull.Value Then
                    Select Case dr("prename")
                        Case "Mr.", "Mrs.", "Ms.", "Miss."
                            ddlprename.SelectedValue = dr("prename")
                        Case "Other"
                            ddlprename.SelectedValue = "Other"
                            txtPrename.Text = dr("prename")
                            txtPrename.Visible = True
                        Case Else
                            ddlprename.SelectedValue = "Other"
                            txtPrename.Text = dr("prename")
                            txtPrename.Visible = True
                    End Select
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
            PhotoDeleteAct.Visible = True
        Else
            PhotoAct.Visible = False
        End If
    End Sub

    Protected Sub ddlPrename_SelectIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlprename.SelectedIndexChanged
        If ddlPrename.SelectedValue = "Other" Then
            txtPrename.Visible = True
        Else
            txtPrename.Visible = False
        End If
    End Sub
    ''อัพโหลด และ ลบ รูป กรมธรรม์
    Protected Sub btnUploadAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadAct.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload5.PostedFile.FileName <> "" Then
            If FileUpload5.HasFile Then
                srcName = Path.GetFileName(FileUpload5.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload5.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload5.PostedFile.SaveAs(Server.MapPath("~/Upload/FileGuide/") + srcName & srcExt)
                hidPhotoAct.Value = srcName & srcExt
                PhotoAct.ImageUrl = "~/Upload/FileGuide/" & hidPhotoAct.Value
                PhotoAct.Visible = True
                btnUploadAct.Visible = False
                FileUpload5.CssClass = "w3-hide"
                PhotoDeleteAct.Visible = True
            End If
        End If
    End Sub

    Protected Sub PhotoDeleteAct_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteAct.Command
        If File.Exists(fpathGuide & hidPhotoAct.Value) Then
            File.Delete(fpathGuide & hidPhotoAct.Value)
        End If
        btnUploadAct.Visible = True
        FileUpload5.CssClass = "w3-show"
        hidPhotoAct.Value = ""
        PhotoAct.Visible = False
        PhotoDeleteAct.Visible = False
    End Sub

    Protected Sub btnNext4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNext4.Click
        If txtName.Text = "" Then
            Dim strError = "alert('Please enter Name !!!');"
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", strError, True)
        ElseIf txtSurname.Text = "" Then
            Dim strError = "alert('Please enter Last name !!!');"
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", strError, True)
        ElseIf txtIdcard.Text = "" Then
            Dim strError = "alert('Please enter ID card !!!');"
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", strError, True)
        ElseIf hidPhotoAct.Value = "" Then
            Dim strError = "alert('Please Upload Photo of identity card !!!');"
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", strError, True)
        Else
            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim TableCommand As DataTable = dbConnect.TableCommand
            Try
                TableCommand.Clear()
                TableCommand.Rows.Add("guide_name", NpgsqlTypes.NpgsqlDbType.Varchar, txtName.Text)
                TableCommand.Rows.Add("guide_surname", NpgsqlTypes.NpgsqlDbType.Varchar, txtSurname.Text)
                TableCommand.Rows.Add("guide_email", NpgsqlTypes.NpgsqlDbType.Varchar, txtEmail.Text)
                TableCommand.Rows.Add("guide_tel", NpgsqlTypes.NpgsqlDbType.Varchar, txtTelephone.Text)
                TableCommand.Rows.Add("guide_photo", NpgsqlTypes.NpgsqlDbType.Varchar, hidPhotoAct.Value)
                TableCommand.Rows.Add("guide_idcard", NpgsqlTypes.NpgsqlDbType.Varchar, txtIdcard.Text)

                If ddlprename.SelectedValue = "Other" Then
                    TableCommand.Rows.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar, txtPrename.Text)
                Else
                    TableCommand.Rows.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar, ddlprename.SelectedValue)
                End If

                If guide_id > 0 Then
                    Dim Update = dbConnect.UpdateDataTable(TableCommand, "guide", "WHERE guide_id = " & guide_id & " and travel_user_id = " & Session("user_id"))
                Else
                    TableCommand.Rows.Add("travel_user_id", NpgsqlTypes.NpgsqlDbType.Integer, Session("user_id"))
                    Dim Insert = dbConnect.InsertDataTable(TableCommand, "guide")
                End If
            Catch ex As Exception
                Dim strError = "alert('Fill information and please try again !');"
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", strError, True)
            Finally
                Response.Redirect("Guide.aspx")
            End Try
        End If


    End Sub

    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("Guide.aspx")
    End Sub
End Class
