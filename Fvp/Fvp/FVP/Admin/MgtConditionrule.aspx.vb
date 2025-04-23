Imports System.Data
Imports Npgsql
Imports System.IO
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Globalization

Partial Class MgtConditionrule
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_id") Is Nothing Then
            Response.Redirect("../Login.aspx")
        Else

            If Page.IsPostBack = False Then
                Populate.genLicenseIdfromNo(ddlLicenseNo, False)
                Populate.genDDLCondition(ddlcon, False)

                If Request.QueryString("id") <> "" Then
                    loaddata()
                End If


            End If

        End If

        ddlLicenseNo.CssClass = "form-control"
        ddlcon.CssClass = "form-control"

    End Sub
    Private Sub loaddata()
        Dim dbConnect As New DBConnect
        Dim cmd As New Npgsql.NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            If Request.QueryString("id") <> "" Then
                Dim sqlstr As String = "SELECT cond_id , cond_info, latitude, longtitude, license_id , cond_time , rule_name , con_id " & _
                                       " FROM public.condition_rule  WHERE cond_id = '" & Request.QueryString("id") & "' "
                Dim dr As Npgsql.NpgsqlDataReader
                cmd.CommandText = CommandType.Text
                cmd.Parameters.Clear()
                cmd.CommandText = sqlstr
                dr = cmd.ExecuteReader()
                If dr.Read Then
                    If dr("cond_info") IsNot DBNull.Value Then
                        txtCond_info.Text = dr("cond_info")
                    End If

                    If dr("rule_name") IsNot DBNull.Value Then
                        txtrule_name.Text = dr("rule_name")
                    End If

                    If dr("cond_time") IsNot DBNull.Value Then
                        txtCond_time.Text = dr("cond_time")
                        txtCond_time.Text = Format(CDate(txtCond_time.Text), "MM/dd/yyyy HH:mm")
                    End If

                    If dr("license_id") IsNot DBNull.Value Then
                        ddlLicenseNo.SelectedValue = dr("license_id")
                    End If

                    If dr("con_id") IsNot DBNull.Value Then
                        ddlcon.SelectedValue = dr("con_id")
                    End If

                End If
                dr.Close()
                cmd.ExecuteReader.Close()

            Else

            End If

        Catch ex As Exception

        Finally
            cmd.Connection.Close()
            con.Close()
            con.Dispose()
            cmd.Dispose()

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New Npgsql.NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            If Request.QueryString("id") <> "" Then
                Dim strUpdate As String = "Update condition_rule set cond_info=:cond_info , cond_time=:cond_time , license_id=:license_id , rule_name=:rule_name , con_id=:con_id WHERE cond_id =  '" & Request.QueryString("id") & "' "
                cmd.CommandText = CommandType.Text
                cmd.CommandText = strUpdate
                cmd.Parameters.Clear()
                cmd.Parameters.Add("cond_info", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtCond_info.Text
                cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlLicenseNo.SelectedValue
                cmd.Parameters.Add("cond_time", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = txtCond_time.Text
                cmd.Parameters.Add("rule_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtrule_name.Text
                cmd.Parameters.Add("con_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlcon.SelectedValue
                cmd.ExecuteNonQuery()

            Else

                Dim strIns As String = " INSERT Into condition_rule (cond_info , cond_time , license_id , rule_name , con_id ) VALUES(:cond_info , :cond_time , :license_id , :rule_name , :con_id )"
                cmd.CommandText = CommandType.Text
                cmd.CommandText = strIns
                cmd.Parameters.Clear()
                cmd.Parameters.Add("cond_info", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtCond_info.Text
                cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlLicenseNo.SelectedValue
                cmd.Parameters.Add("cond_time", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = txtCond_time.Text
                cmd.Parameters.Add("rule_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtrule_name.Text
                cmd.Parameters.Add("con_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlcon.SelectedValue
                cmd.ExecuteNonQuery()
            End If


            Response.Redirect("Conditionrule.aspx")

        Catch ex As Exception

        Finally
            cmd.Connection.Close()
            con.Close()
        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("Conditionrule.aspx")
    End Sub
End Class
