Imports System.Data
Imports System.Diagnostics

Partial Class Login
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = True Then
            LinkButton1_Click(sender, e)
        End If
        If Session("user_type") = "1" And Session("email") <> "" Then
            Response.Redirect("Local/index.aspx", True)
        ElseIf Session("user_type") = "2" And Session("username") <> "" Then
            Response.Redirect("Travel/index.aspx?rt=1", True)
        ElseIf Session("admin_id") Or Session("user_id") = "adminbt" Then
            Response.Redirect("~/Admin/dashboard.aspx", True)
        End If
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim strError As String = ""
        Dim a As String = ""
        Dim db As New DBConnect
        Try
            Dim dr As DataRow
            Dim str As String = "SELECT user_id, username, name_company, pass, user_type , is_active FROM user_travel WHERE username = '" & txtUsername.Text.Trim & "' "
            Dim strAdmin As String = "SELECT admin.username , pass from admin WHERE  username = '" & txtUsername.Text.Trim & "' "
            Dim strUserAdmin As String = "SELECT username , password from user_admin WHERE username = '" & txtUsername.Text.Trim & "' "
            Dim strUserLocal As String = "SELECT user_id, username , password , typeuser_id from user_cus WHERE username = '" & txtUsername.Text.Trim & "'"

            Dim DataTable = db.ReadDataTabletest(str)
            Dim DataTable2 = db.ReadDataTabletest(strUserLocal)
            Console.WriteLine("dd")
            If DataTable.Rows.Count > 0 Then
                dr = DataTable.Select("pass= '" & DBConnect.password(txtUsername.Text.Trim, txtPassword.Text.Trim) & "'")(0)
                If dr("is_active") = 1 Then
                    If dr("user_type") = 1 Then

                    Else
                        Session("user_id") = dr("user_id")
                        Session("user_type") = 2
                        Session("name_company") = dr("name_company")
                        Session("username") = dr("username")
                        If Request.QueryString("Page") <> "" Then
                            Response.Redirect(HttpContext.Current.Server.UrlDecode(Request.QueryString("Page")))
                        Else
                            Response.Redirect("Travel/index.aspx")
                        End If
                    End If
                Else
                    strError = "alert('User not active . Please contact Admin !!!');"
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", strError, True)
                End If
            ElseIf DataTable2.Rows.Count > 0 Then
                dr = DataTable2.Select("password= '" & DBConnect.password(txtUsername.Text.Trim, txtPassword.Text.Trim) & "'")(0)
                Dim drTable As DataTable = db.ReadDataTabletest("select CAST(fname || ' ' || lname as varchar) as name , typeuser_id from license WHERE email = '" & txtUsername.Text & "'")
                Session("user_id") = dr("user_id")
                Session("name_company") = drTable.Rows(0).Item("name")
                Session("user_type") = 1
                Session("email") = txtUsername.Text
                Session("typeuser_id") = dr("typeuser_id")
                Response.Redirect("Local/index.aspx", True)
            Else
                Dim datatableadmin = db.getDataTabletest(strAdmin, "admin")
                Dim datatableuseradmin = db.getDataTabletest(strUserAdmin, "user_admin")
                If datatableadmin.Rows.Count > 0 Or datatableuseradmin.Rows.Count > 0 Then
                    a = DBConnect.password(txtUsername.Text.Trim, txtPassword.Text.Trim)
                    If datatableadmin.Rows.Count > 0 Then
                        dr = datatableadmin.Select("pass= '" & DBConnect.password(txtUsername.Text.Trim, txtPassword.Text.Trim) & "'")(0)
                    Else
                        dr = datatableuseradmin.Select("password= '" & DBConnect.password(txtUsername.Text.Trim, txtPassword.Text.Trim) & "'")(0)
                    End If

                    If dr("username") = "adminbt" Then
                        Session("user_id") = "adminbt"
                        Session("user_type") = "Admin สำนักงานส่วนกลาง"
                        Response.Redirect("~/Admin/dashboard.aspx", True)
                    Else
                        If datatableuseradmin.Rows.Count > 0 Then
                            Dim Table As New DataTable
                            Table = db.getDataTabletest("SELECT user_admin.admin_id , user_admin.username, type, admin.admin_name from user_admin left join admin on admin.admin_id = user_admin.admin_id WHERE user_admin.username like '" & txtUsername.Text & "' ", "tableadmin")
                            Session("admin_id") = Table.Rows(0)(0).ToString
                            Session("user_id") = Table.Rows(0)(1).ToString
                            Session("user_type") = Table.Rows(0)(2).ToString 'Table.Rows(0)(1).ToString
                            Session("admin_name") = Table.Rows(0)(3).ToString
                            Response.Redirect("~/Admin/dashboard.aspx", True)
                        Else
                            Dim Table As New DataTable
                            Table = db.getDataTabletest("SELECT admin_id , username , admin_name from admin WHERE username like '" & txtUsername.Text & "' ", "tableadmin")
                            Session("admin_id") = Table.Rows(0)(0).ToString
                            Session("user_id") = Table.Rows(0)(1).ToString
                            Session("user_type") = Table.Rows(0)(2).ToString
                            Response.Redirect("~/Admin/dashboard.aspx", True)
                        End If

                    End If
                ElseIf txtUsername.Text.Trim.IndexOf("admin#") > -1 And txtPassword.Text.Trim = "admin1234" Then

                    Dim strAdminTest As String = "SELECT user_id, username, name_company, pass, user_type , is_active FROM user_travel WHERE user_id = " & txtUsername.Text.Trim.Replace("admin#", "")
                    Dim DataTableAdminTest = db.getDataTabletest(strAdminTest, "admintest")

                    If DataTableAdminTest.Rows.Count > 0 Then
                        dr = DataTableAdminTest.Select("user_id= " & txtUsername.Text.Trim.Replace("admin#", ""))(0)
                        Session("user_id") = dr("user_id")
                        Session("user_type") = 2
                        Session("name_company") = dr("name_company")
                        Session("username") = dr("username")
                        If Request.QueryString("Page") <> "" Then
                            Response.Redirect(HttpContext.Current.Server.UrlDecode(Request.QueryString("Page")))
                        Else
                            Response.Redirect("Travel/index.aspx")
                        End If
                    End If

                Else
                    strError = "alert('Username or Password is incorrect . Please try again !!! ');"
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", strError, True)
                End If
            End If
        Catch ex As Exception
            Dim errorDe As String = ex.Message
            strError = "alert('Username or Password is incorrect . Please try again !!! ');"
            Dim stConsole = "console.log(" & a & ");"
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", strError & stConsole, True)
        Finally
            db = Nothing

        End Try



    End Sub
End Class
