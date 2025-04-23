Imports System.Data
Imports Npgsql

Partial Class MgtEditUserAdmin
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
            Populate.genAdminName(ddlAdminName, False)
            loaddata()
        End If
    End Sub
    Private Sub loaddata()
        If Request.QueryString("id") <> "" Then
            Dim dbConnect As New DBConnect
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Dim cmd As New Npgsql.NpgsqlCommand
            Try
                Dim str As String = "select username , password , admin_id, type from user_admin WHERE user_id = " & Request.QueryString("id") & ""
                Dim a As DataTable = dbConnect.getDataTable(str, "user_admin")
                txtUser.Text = a.Rows(0).Item("username")
                txtUser.Enabled = False
                txtUser.CssClass = "form-control"
                chkIsofficer.Checked = IIf(a.Rows(0).Item("type") = 0, True, False)
                ddlAdminName.SelectedValue = a.Rows(0).Item("admin_id")
                isEdit.Visible = True
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub savedata()
        Dim dbConnect As New DBConnect
        Dim TableCommand As DataTable = dbConnect.TableCommand
        Dim tableName As String = "user_admin"
        Dim checkError As String = ""
        Try
            If Request.QueryString("id") <> "" Then
                If txtPass.Text <> txtPassCon.Text Then
                    Dim alert As String = "alert('รหัสผ่านยืนยันไม่ตรงกัน');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                ElseIf txtUser.Text = "" Then
                    Dim alert As String = "alert('กรุณาใส่ Username');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                ElseIf txtPass.Text = "" Or txtPassCon.Text = "" Then
                    Dim alert As String = "alert('กรุณาใส่ Password');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                Else
                    TableCommand.Rows.Add("password", NpgsqlTypes.NpgsqlDbType.Varchar, dbConnect.password(txtUser.Text, txtPass.Text))
                    TableCommand.Rows.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer, ddlAdminName.SelectedValue)
                    TableCommand.Rows.Add("type", NpgsqlTypes.NpgsqlDbType.Integer, IIf(chkIsofficer.Checked = True, 0, 99))
                    checkError = dbConnect.UpdateDataTable(TableCommand, tableName, "WHERE user_id = " & Request.QueryString("id"))
                        If checkError = "" Then
                            Dim alert As String = "alert('บันทึกข้อมูลเรียบร้อย');"
                            ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                            Response.Redirect("EditUserAdmin.aspx")
                        Else
                            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('" & checkError.ToString & "');", True)
                        End If
                End If
            Else
                If txtPass.Text <> txtPassCon.Text Then
                    Dim alert As String = "alert('รหัสผ่านยืนยันไม่ตรงกัน');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                ElseIf txtUser.Text = "" Then
                    Dim alert As String = "alert('กรุณาใส่ Username');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                ElseIf txtPass.Text = "" Or txtPassCon.Text = "" Then
                    Dim alert As String = "alert('กรุณาใส่ Password');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                Else
                    Dim checkuser = dbConnect.executeScalar("select username from user_admin WHERE username like '" & txtUser.Text & "'")
                    If checkuser <> "" Then
                        Dim alert As String = "alert('มีผู้ใช้ User " & checkuser & " แล้ว กรุณาใช้ User อื่น');"
                        ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                    Else
                        TableCommand.Rows.Add("username", NpgsqlTypes.NpgsqlDbType.Varchar, txtUser.Text)
                        TableCommand.Rows.Add("password", NpgsqlTypes.NpgsqlDbType.Varchar, dbConnect.password(txtUser.Text, txtPass.Text))
                        TableCommand.Rows.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer, ddlAdminName.SelectedValue)
                        TableCommand.Rows.Add("type", NpgsqlTypes.NpgsqlDbType.Integer, IIf(chkIsofficer.Checked = True, 0, 99))
                        checkError = dbConnect.InsertDataTable(TableCommand, tableName)
                        If checkError = "" Then
                            Dim alert As String = "alert('บันทึกข้อมูลเรียบร้อย');"
                            Response.Redirect("EditUserAdmin.aspx")
                            ScriptManager.RegisterStartupScript(Me, GetType(String), "Script", alert, True)
                        Else
                            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('" & checkError.ToString & "');", True)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        Finally
            TableCommand.Dispose()
        End Try


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        savedata()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("EditUserAdmin.aspx")
    End Sub
End Class
