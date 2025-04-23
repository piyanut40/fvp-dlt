Imports Npgsql
Imports System.Data

Partial Class RegisterComplete
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Not Request.QueryString("token") Is Nothing Then
                iframeQRCode.Attributes.Add("src", "Control/genQRCode.aspx?url=" & ConfigurationManager.AppSettings("UrlWebFVM") & "TrackStatus.aspx?token=" & Request.QueryString("token"))
                LoadData()
            End If
        End If
    End Sub

    Private Send As New SendEmail
    Private Sub LoadData()
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            Dim str = " SELECT driver.prename , driver.name ,  driver.surname , idcard_no , driver.email , type_user.typename_th " & _
            " from driver LEFT JOIN license on license.driver_id = driver.driver_id " & _
            " LEFT JOIN type_user on type_user.typeuser_id = license.typeuser_id " & _
            " WHERE license.token = '" & Request.QueryString("token") & "' "
            cmd.CommandText = str
            dread = cmd.ExecuteReader()
            Dim email As String = ""
            Dim typename_th As String = ""
            If dread.Read Then
                If dread("prename") IsNot DBNull.Value Then
                    If (dread("prename") = "Mr." Or dread("prename") = "Ms." Or dread("prename") = "Miss." Or dread("prename") = "Mrs.") Then
                        lblName.Text = dread("prename")
                    Else
                        lblName.Text = dread("prename")
                    End If
                End If

                If dread("name") IsNot DBNull.Value Then
                    lblName.Text = lblName.Text & " " & dread("name")
                End If
                If dread("surname") IsNot DBNull.Value Then
                    lblName.Text = lblName.Text & " " & dread("surname")
                End If

                If dread("idcard_no") IsNot DBNull.Value Then
                    lblIdcardDriver.Text = dread("idcard_no")
                End If
                If dread("email") IsNot DBNull.Value Then
                    email = dread("email")
                End If
                If dread("typename_th") IsNot DBNull.Value Then
                    typename_th = dread("typename_th")
                End If
            End If
            dread.Close()


            Send.Email(email, lblName.Text, Request.QueryString("token"), typename_th)
         
        Catch ex As Exception

        Finally
            cmd.Connection.Close()
            con.Close()
        End Try

    End Sub
End Class
