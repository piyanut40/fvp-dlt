Imports System.Data
Imports Npgsql

Partial Class EditAdmin
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected text As String
    Protected name As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_id") = Nothing Then
            Response.Redirect("../Login.aspx")
        End If
        If Page.IsPostBack = False Then
            'loaddata()
        End If
    End Sub

    Private Sub savedata()

        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim cmd As New Npgsql.NpgsqlCommand
        Dim dr As Npgsql.NpgsqlDataReader
        Dim old As String = ""

        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            cmd.CommandText = "select username , pass from admin WHERE admin_id = '" & Session("admin_id") & "' and username = '" & Session("user_id") & "' "
            dr = cmd.ExecuteReader
            If dr.Read Then
                old = dr("pass")
                lblUser.Text = dr("username")
                dr.Close()
                If txtNewPass.Text <> txtNewPassCon.Text Then
                    Dim alert As String = "alert('รหัสผ่านยืนยันไม่ตรงกัน');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                    txtNewPass.Text = ""
                    txtNewPassCon.Text = ""
                ElseIf dbConnect.password(lblUser.Text, txtOldPass.Text).ToString <> old Then
                    Dim alert As String = "alert('รหัสผ่านเดิมไม่ถูกต้อง');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                    txtOldPass.Text = ""
                    txtNewPass.Text = ""
                    txtNewPassCon.Text = ""
                Else
                    Dim newpass As String = dbConnect.password(lblUser.Text, txtNewPass.Text)
                    cmd.CommandText = "Update admin set pass=:pass where username = '" & lblUser.Text & "'"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("pass", NpgsqlTypes.NpgsqlDbType.Varchar).Value = newpass
                    cmd.ExecuteNonQuery()
                    Dim alert As String = "alert('เปลี่ยนแปลงรหัสผ่านเรียบร้อย');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                    txtOldPass.Text = ""
                    txtNewPass.Text = ""
                    txtNewPassCon.Text = ""
                End If
            Else
                dr.Close()
                cmd.CommandText = "select username , password from user_admin WHERE admin_id = '" & Session("admin_id") & "' and username = '" & Session("user_id") & "' "
                dr = cmd.ExecuteReader
                If dr.Read Then
                    old = dr("password")
                    lblUser.Text = dr("username")
                    dr.Close()
                    If txtNewPass.Text <> txtNewPassCon.Text Then
                        Dim alert As String = "alert('รหัสผ่านยืนยันไม่ตรงกัน');"
                        ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                        txtNewPass.Text = ""
                        txtNewPassCon.Text = ""
                    ElseIf dbConnect.password(lblUser.Text, txtOldPass.Text).ToString <> old Then
                        Dim alert As String = "alert('รหัสผ่านเดิมไม่ถูกต้อง');"
                        ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                        txtOldPass.Text = ""
                        txtNewPass.Text = ""
                        txtNewPassCon.Text = ""
                    Else
                        Dim newpass As String = dbConnect.password(lblUser.Text, txtNewPass.Text)
                        cmd.CommandText = "Update user_admin set password=:password where username = '" & lblUser.Text & "'"
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("password", NpgsqlTypes.NpgsqlDbType.Varchar).Value = newpass
                        cmd.ExecuteNonQuery()
                        Dim alert As String = "alert('เปลี่ยนแปลงรหัสผ่านเรียบร้อย');"
                        ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                        txtOldPass.Text = ""
                        txtNewPass.Text = ""
                        txtNewPassCon.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
        Finally
            cmd.Connection.Close()
            con.Close()

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        savedata()
    End Sub
End Class
