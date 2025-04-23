Imports System.Data
Imports Npgsql
Imports System.IO
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Globalization

Partial Class Admin_CompanyTravelMgt
    Inherits System.Web.UI.Page

    Private Populate As New PopulateDropDown
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Populate.genDDLProvinceTH(ddlPro, False)
            Populate.genDDLAmphoeTH(ddlPro, ddlAmp, False)
            Populate.genDDLTumbolTH(ddlPro, ddlAmp, ddlTum, False)
            If Not Request.QueryString("id") Is Nothing Then
                LoadData()
            End If
        End If
    End Sub

    Private Sub LoadData()
        Dim dbConnect As New DBConnect
        Dim cmd As New Npgsql.NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dr As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con
            Dim sqlstr As String = "SELECT   company_nameth, company_nameen, t_id , address , postal , telephone , email , facebook , line " & _
                " FROM company_travel WHERE company_id =  '" & Request.QueryString("id") & "' "
            cmd.CommandText = CommandType.Text
            cmd.Parameters.Clear()
            cmd.CommandText = sqlstr
            dr = cmd.ExecuteReader()
            If dr.Read Then
                If dr("company_nameth") IsNot DBNull.Value Then
                    txtcompany_nameth.Text = dr("company_nameth")
                End If

                If dr("company_nameen") IsNot DBNull.Value Then
                    txtcompany_nameen.Text = dr("company_nameen")
                End If

                If dr("address") IsNot DBNull.Value Then
                    txtaddress.Text = dr("address")
                End If

                If dr("postal") IsNot DBNull.Value Then
                    txtpostal.Text = dr("postal")
                End If

                If dr("telephone") IsNot DBNull.Value Then
                    txttelephone.Text = dr("telephone")
                End If

                If dr("email") IsNot DBNull.Value Then
                    txtemail.Text = dr("email")
                End If

                If dr("facebook") IsNot DBNull.Value Then
                    txtfacebook.Text = dr("facebook")
                End If

                If dr("line") IsNot DBNull.Value Then
                    txtline.Text = dr("line")
                End If

                If dr("t_id") IsNot DBNull.Value Then
                    Dim pro As String = dr("t_id").ToString.Substring(0, 2)
                    Dim Amp As String = dr("t_id").ToString.Substring(2, 2)
                    ddlPro.SelectedValue = pro

                    Populate.genDDLAmphoeTH(ddlPro, ddlAmp, False)
                    ddlAmp.SelectedValue = Amp

                    Populate.genDDLTumbolTH(ddlPro, ddlAmp, ddlTum, False)
                    ddlTum.SelectedValue = dr("t_id")
                End If
            End If
            dr.Close()

        Catch ex As Exception

        Finally
            cmd.Connection.Close()
            con.Close()
            dbConnect = Nothing
        End Try
    End Sub

    Protected Sub BtnSave_Click(sender As Object, e As System.EventArgs) Handles BtnSave.Click
        If txtcompany_nameth.Text = "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('กรุณาระบุชื่อบริษัทท่องเที่ยว!!! ');", True)
        Else
            Dim dbConnect As New DBConnect
            Dim cmd As New Npgsql.NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Try
                con.Open()
                cmd.Connection = con
                Dim strQuery As String = ""
                If Not Request.QueryString("id") Is Nothing Then
                    strQuery = " Update company_travel set company_nameth = :company_nameth , company_nameen = :company_nameen , t_id = :t_id " & _
                    " , address = :address , postal = :postal , telephone = :telephone  , email = :email , facebook = :facebook , line = :line " & _
                    " WHERE company_id = " & Request.QueryString("id")
                Else
                    strQuery = " INSERT INTO company_travel ( company_nameth, company_nameen, t_id , address , postal , telephone , email , facebook , line) " & _
                    " VALUES ( :company_nameth, :company_nameen, :t_id , :address , :postal , :telephone , :email , :facebook , :line)"
                End If
                cmd.CommandText = CommandType.Text
                cmd.CommandText = strQuery
                cmd.Parameters.Clear()
                cmd.Parameters.Add("company_nameth", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtcompany_nameth.Text
                cmd.Parameters.Add("company_nameen", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtcompany_nameen.Text
                cmd.Parameters.Add("t_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlTum.SelectedValue
                cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtaddress.Text
                cmd.Parameters.Add("postal", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtpostal.Text
                cmd.Parameters.Add("telephone", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txttelephone.Text
                cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtemail.Text
                cmd.Parameters.Add("facebook", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtfacebook.Text
                cmd.Parameters.Add("line", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtline.Text
                cmd.ExecuteNonQuery()
                Response.Redirect("CompanyTravel.aspx")
            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถบันทึกข้อมูลได้ Error >>> " & ex.Message.ToString & " กรุณาลองอีกครั้ง!!! ');", True)
            Finally
                cmd.Connection.Close()
                con.Close()
                dbConnect = Nothing
            End Try
        End If

    End Sub

    Protected Sub BtnBack_Click(sender As Object, e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("CompanyTravel.aspx")
    End Sub

    Protected Sub ddlPro_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPro.SelectedIndexChanged
        Populate.genDDLAmphoeTH(ddlPro, ddlAmp, False)
        Populate.genDDLTumbolTH(ddlPro, ddlAmp, ddlTum, False)
    End Sub

    Protected Sub ddlAmp_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAmp.SelectedIndexChanged
        Populate.genDDLTumbolTH(ddlPro, ddlAmp, ddlTum, False)
    End Sub
End Class
