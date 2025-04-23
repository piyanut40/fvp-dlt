Imports System.Data
Imports Npgsql

Partial Class EditPassword
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected text As String
    Protected name As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("token") = "" Then
            Response.Redirect("index.aspx")
        Else
            If Page.IsPostBack = False Then
                Dim check = loaddata()
                If check = "" Or Request.QueryString("regis") = "" Then
                    Response.Redirect("index.aspx")
                Else
                    lblUser.Text = check
                    'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "alert('" & check & "');", True)
                End If
            End If
        End If
        'If Session("user_id") = Nothing Then
        '    Response.Redirect("../Login.aspx")
        'End If
        'If Page.IsPostBack = False Then
        '    'loaddata()
        'End If
    End Sub
    Private Function loaddata() As String
        Dim dbconnect As New DBConnect
        Dim token = Request.QueryString("token")
        Dim dtRead = New DataTable
        Try


            Dim strSql = " Select email , license.typeuser_id from license  " & _
                         " LEFT JOIN user_cus on user_cus.username = license.email " & _
                         " WHERE token = '" & token & "' and status_id is null and resetpass is null"
            dtRead = dbconnect.ReadDataTable(strSql)
            If dtRead.Rows.Count > 0 Then
                hidtypeuser_id.Value = dtRead.Rows(0).Item("typeuser_id")
                Return dtRead.Rows(0).Item("email")
            Else
                Return ""
            End If


        Catch ex As Exception
            Return ex.ToString
        Finally
        End Try
    End Function
    Private Sub savedata()
        Dim dbConnect As New DBConnect
        Dim TableCommand As DataTable = dbConnect.TableCommand
        Try
            If txtNewPass.Text = "" Or txtNewPassCon.Text = "" Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "alert('Please enter password.');", True)
            ElseIf txtNewPass.Text <> txtNewPassCon.Text Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "alert('Your password and confirmation password do not match. ');", True)
            Else
                TableCommand.Rows.Clear()
                TableCommand.Rows.Add("username", NpgsqlTypes.NpgsqlDbType.Varchar, lblUser.Text)
                TableCommand.Rows.Add("password", NpgsqlTypes.NpgsqlDbType.Varchar, dbConnect.password(lblUser.Text, txtNewPass.Text))
                TableCommand.Rows.Add("resetpass", NpgsqlTypes.NpgsqlDbType.Integer, 0)
                TableCommand.Rows.Add("typeuser_id", NpgsqlTypes.NpgsqlDbType.Integer, hidtypeuser_id.Value)
                Dim check = dbConnect.InsertDataTable(TableCommand, "user_cus")
                If check = "" Then
                    If Request.QueryString("country") = 1 Then
                        Response.Redirect("Register.aspx?token=" & Request.QueryString("token") & "&regis=" & Request.QueryString("regis") & "&country=" & Request.QueryString("country"))
                    Else
                        Response.Redirect("Register.aspx?token=" & Request.QueryString("token") & "&regis=" & Request.QueryString("regis"))
                    End If
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "alert('" & check & "');", True)
                End If
            End If
        Catch ex As Exception

        End Try
       
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        savedata()
    End Sub
End Class
