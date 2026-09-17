Imports System.Data
Imports Npgsql

Partial Class EditAdmin
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected text As String
    Protected name As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user_id") Is Nothing OrElse String.IsNullOrEmpty(Session("user_id").ToString()) Then
            Response.Redirect("../Login.aspx")
            Return
        End If


        Dim dbConnect As New DBConnect
        Dim con As NpgsqlConnection = DBConnect.getConnection()
        Dim isAdmin As Boolean = False

        Try
            con.Open()
            Using cmd As New NpgsqlCommand("SELECT COUNT(1) FROM admin WHERE username=@user_id", con)
                cmd.Parameters.Add("@user_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Session("user_id").ToString()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    isAdmin = True

                    Using cmd2 As New NpgsqlCommand("SELECT admin_id FROM admin WHERE username=@user_id", con)
                        cmd2.Parameters.Add("@user_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Session("user_id").ToString()
                        Session("admin_id") = Convert.ToInt32(cmd2.ExecuteScalar())
                    End Using
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        Finally
            con.Close()
        End Try


        Session("isAdmin") = isAdmin
        Session("role") = If(isAdmin, "admin", "user_admin")
    End Sub



    'Private Sub savedata()
    '    If Session("user_id") Is Nothing OrElse Session("admin_id") Is Nothing Then
    '        Response.Redirect("../Login.aspx")
    '        Return
    '    End If

    '    'Dim dbConnect As New DBConnect
    '    'Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
    '    'Dim cmd As New Npgsql.NpgsqlCommand
    '    'Dim dr As Npgsql.NpgsqlDataReader
    '    'Dim old As String = ""
    '    Dim dbConnect As New DBConnect
    '    Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
    '    Dim oldPass As String = ""
    '    Dim username As String = Session("user_id").ToString()
    '    Dim adminId As Integer = Convert.ToInt32(Session("admin_id"))
    '    Dim tableName As String = ""
    '    Dim passwordCol As String = ""

    '    Try
    '        con.Open()
    '        cmd.Connection = con

    '        cmd.CommandType = CommandType.Text

    '        cmd.CommandText = "SELECT username, pass FROM admin WHERE admin_id = @admin_id AND username = @user_id"
    '        cmd.Parameters.Clear()
    '        cmd.Parameters.Add("@admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(Session("admin_id"))
    '        cmd.Parameters.Add("@user_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Session("user_id")
    '        Console.WriteLine("admin_id=" & Session("admin_id") & ", user_id=" & Session("user_id"))

    '        dr = cmd.ExecuteReader
    '        If dr.Read Then
    '            old = dr("pass")
    '            lblUser.Text = dr("username")
    '            dr.Close()
    '            If txtNewPass.Text <> txtNewPassCon.Text Then
    '                Dim alert As String = "alert('รหัสผ่านยืนยันไม่ตรงกัน');"
    '                ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
    '                txtNewPass.Text = ""
    '                txtNewPassCon.Text = ""
    '            ElseIf DBConnect.password(lblUser.Text, txtOldPass.Text).ToString <> old Then
    '                Dim alert As String = "alert('รหัสผ่านเดิมไม่ถูกต้อง');"
    '                ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
    '                txtOldPass.Text = ""
    '                txtNewPass.Text = ""
    '                txtNewPassCon.Text = ""
    '            Else
    '                Dim newpass As String = DBConnect.password(lblUser.Text, txtNewPass.Text)
    '                cmd.CommandText = "Update admin set pass=:pass where username = '" & lblUser.Text & "'"
    '                cmd.Parameters.Clear()
    '                cmd.Parameters.Add("pass", NpgsqlTypes.NpgsqlDbType.Varchar).Value = newpass
    '                cmd.ExecuteNonQuery()
    '                Dim alert As String = "alert('เปลี่ยนแปลงรหัสผ่านเรียบร้อย');"
    '                ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
    '                txtOldPass.Text = ""
    '                txtNewPass.Text = ""
    '                txtNewPassCon.Text = ""
    '            End If
    '        Else
    '            dr.Close()

    '            cmd.CommandText = "SELECT username, password FROM user_admin WHERE admin_id = @admin_id AND username = @user_id"
    '            cmd.Parameters.Clear()
    '            cmd.Parameters.Add("@admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(Session("admin_id"))
    '            cmd.Parameters.Add("@user_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Session("user_id")
    '            Console.WriteLine("admin_id=" & Session("admin_id") & ", user_id=" & Session("user_id"))

    '            dr = cmd.ExecuteReader
    '            If dr.Read Then
    '                old = dr("password")
    '                lblUser.Text = dr("username")
    '                dr.Close()
    '                If txtNewPass.Text <> txtNewPassCon.Text Then
    '                    Dim alert As String = "alert('รหัสผ่านยืนยันไม่ตรงกัน');"
    '                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
    '                    txtNewPass.Text = ""
    '                    txtNewPassCon.Text = ""
    '                ElseIf DBConnect.password(lblUser.Text, txtOldPass.Text).ToString <> old Then
    '                    Dim alert As String = "alert('รหัสผ่านเดิมไม่ถูกต้อง');"
    '                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
    '                    txtOldPass.Text = ""
    '                    txtNewPass.Text = ""
    '                    txtNewPassCon.Text = ""
    '                Else
    '                    Dim newpass As String = DBConnect.password(lblUser.Text, txtNewPass.Text)
    '                    cmd.CommandText = "Update user_admin set password=:password where username = '" & lblUser.Text & "'"
    '                    cmd.Parameters.Clear()
    '                    cmd.Parameters.Add("password", NpgsqlTypes.NpgsqlDbType.Varchar).Value = newpass
    '                    cmd.ExecuteNonQuery()
    '                    Dim alert As String = "alert('เปลี่ยนแปลงรหัสผ่านเรียบร้อย');"
    '                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
    '                    txtOldPass.Text = ""
    '                    txtNewPass.Text = ""
    '                    txtNewPassCon.Text = ""
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Console.WriteLine(ex.Message)
    '    Finally
    '        cmd.Connection.Close()
    '        con.Close()

    '    End Try
    'End Sub
    Private Sub savedata()

        If Session("user_id") Is Nothing OrElse Session("admin_id") Is Nothing Then
            Response.Redirect("../Login.aspx")
            Return
        End If

        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection()
        Dim oldPass As String = ""
        Dim username As String = Session("user_id").ToString()
        Dim adminId As Integer = Convert.ToInt32(Session("admin_id"))
        Dim tableName As String = ""
        Dim passwordCol As String = ""

        Try
            con.Open()


            Using cmd As New NpgsqlCommand("SELECT pass FROM admin WHERE admin_id=@admin_id AND username=@user_id", con)
                cmd.Parameters.Add("@admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = adminId
                cmd.Parameters.Add("@user_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = username

                Dim dr As NpgsqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then
                    oldPass = dr("pass").ToString()
                    tableName = "admin"
                    passwordCol = "pass"
                End If
                dr.Close()
            End Using


            If String.IsNullOrEmpty(oldPass) Then
                Using cmd As New NpgsqlCommand("SELECT password FROM user_admin WHERE admin_id=@admin_id AND username=@user_id", con)
                    cmd.Parameters.Add("@admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = adminId
                    cmd.Parameters.Add("@user_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = username

                    Dim dr As NpgsqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        oldPass = dr("password").ToString()
                        tableName = "user_admin"
                        passwordCol = "password"
                    Else
                        dr.Close()
                        ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", "alert('ไม่พบผู้ใช้งาน');", True)
                        Return
                    End If
                    dr.Close()
                End Using
            End If


            If txtNewPass.Text <> txtNewPassCon.Text Then
                ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", "alert('รหัสผ่านยืนยันไม่ตรงกัน');", True)
                txtNewPass.Text = ""
                txtNewPassCon.Text = ""
                Return
            End If


            Dim oldPassHashed As String = DBConnect.password(username, txtOldPass.Text)
            If oldPassHashed <> oldPass Then
                ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", "alert('รหัสผ่านเดิมไม่ถูกต้อง');", True)
                txtOldPass.Text = ""
                txtNewPass.Text = ""
                txtNewPassCon.Text = ""
                Return
            End If


            Dim newPass As String = DBConnect.password(username, txtNewPass.Text)


            If Not ((tableName = "admin" AndAlso passwordCol = "pass") OrElse (tableName = "user_admin" AndAlso passwordCol = "password")) Then
                ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", "alert('เกิดข้อผิดพลาด: invalid table or column');", True)
                Return
            End If

            Dim sql As String = "UPDATE " & tableName & " SET " & passwordCol & " = @newpass WHERE admin_id = @admin_id AND username = @user_id"
            Using cmd As New NpgsqlCommand(sql, con)
                cmd.Parameters.Add("@newpass", NpgsqlTypes.NpgsqlDbType.Varchar).Value = newPass
                cmd.Parameters.Add("@admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = adminId
                cmd.Parameters.Add("@user_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = username
                cmd.ExecuteNonQuery()
            End Using

            ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", "alert('เปลี่ยนแปลงรหัสผ่านเรียบร้อย');", True)
            txtOldPass.Text = ""
            txtNewPass.Text = ""
            txtNewPassCon.Text = ""

        Catch ex As Exception
            Console.WriteLine(ex.ToString())
            ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", "alert('เกิดข้อผิดพลาด: " & ex.Message & "');", True)
        Finally
            con.Close()
        End Try
    End Sub





    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        savedata()
    End Sub
End Class
