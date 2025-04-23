Imports System.Data
Imports Npgsql
Imports System.IO
Imports Excel

Partial Class ImportAdmin
    Inherits System.Web.UI.Page
    Protected text As String
    Private populate As New PopulateDropDown

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dbconnect As New DBConnect
        Dim con As NpgsqlConnection = dbconnect.getConnection
        Dim cmd As New NpgsqlCommand
        Try
            Dim cou As Integer = dbconnect.executeScalar("select Count(admin_id) from admin WHERE NOT admin_id = 1")
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text

            Dim i As Integer = 2
            cou = cou + 2

           
            While (i < cou)
                Dim name As String = "T" & i
                Dim pass As String = dbconnect.password(name, name)
                Dim strupdate As String = "UPDATE admin set username=:username , pass=:pass WHERE admin_id = " & i & " "
                cmd.CommandText = strupdate
                cmd.Parameters.Add("username", NpgsqlTypes.NpgsqlDbType.Varchar).Value = name
                cmd.Parameters.Add("pass", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pass
                cmd.ExecuteNonQuery()
                i = i + 1
            End While






        Catch ex As Exception

        End Try

    End Sub
End Class
