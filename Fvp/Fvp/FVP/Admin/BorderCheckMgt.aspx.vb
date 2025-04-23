Imports System.Data
Imports Npgsql
Imports System.IO
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Globalization

Partial Class Admin_BorderCheckMgt
    Inherits System.Web.UI.Page

    Private Populate As New PopulateDropDown
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Populate.genDDLProvinceTH(ddlPro, False)
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
            Dim sqlstr As String = "SELECT  border_nameth, border_nameen, prov_code , border_country , lat, lon FROM border_check WHERE border_id =  '" & Request.QueryString("id") & "' "
            cmd.CommandText = CommandType.Text
            cmd.Parameters.Clear()
            cmd.CommandText = sqlstr
            dr = cmd.ExecuteReader()
            If dr.Read Then
                If dr("border_nameth") IsNot DBNull.Value Then
                    txtborder_nameth.Text = dr("border_nameth")
                End If
                If dr("border_nameen") IsNot DBNull.Value Then
                    txtborder_nameen.Text = dr("border_nameen")
                End If
                If dr("prov_code") IsNot DBNull.Value Then
                    ddlPro.SelectedValue = dr("prov_code")
                End If
                If dr("border_country") IsNot DBNull.Value Then
                    ddlcountry.SelectedValue = dr("border_country")
                End If
                If Not dr("lat") Is DBNull.Value Then
                    hidlat.Value = dr("lat")
                End If
                If Not dr("lon") Is DBNull.Value Then
                    hidlon.Value = dr("lon")
                End If
            End If
            dr.Close()


            Dim Location As String
            If hidlat.Value <> "" And hidlon.Value <> "" Then
                Location = " Getloaction(" & hidlon.Value & " , " & hidlat.Value & " ); "
                lat.Text = hidlat.Value
                lon.Text = hidlon.Value
            Else
                Location = ZoomLocation()
            End If
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", " " & Location & " ", True)
        Catch ex As Exception

        Finally
            cmd.Connection.Close()
            con.Close()
            dbConnect = Nothing
        End Try
    End Sub

    Protected Sub BtnSave_Click(sender As Object, e As System.EventArgs) Handles BtnSave.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New Npgsql.NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            Dim strQuery As String = ""
            If Not Request.QueryString("id") Is Nothing Then
                strQuery = " Update border_check set border_nameth = :border_nameth , border_nameen = :border_nameen , prov_code = :prov_code , border_country = :border_country " & _
                            " , lat = :lat , lon = :lon WHERE border_id = " & Request.QueryString("id")
            Else
                strQuery = " INSERT INTO border_check ( border_nameth, border_nameen, prov_code , border_country , lat, lon ) VALUES ( :border_nameth, :border_nameen, :prov_code , :border_country , :lat, :lon)"
            End If
            cmd.CommandText = CommandType.Text
            cmd.CommandText = strQuery
            cmd.Parameters.Clear()
            cmd.Parameters.Add("border_nameth", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtborder_nameth.Text
            cmd.Parameters.Add("border_nameen", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtborder_nameen.Text
            cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlPro.SelectedValue
            cmd.Parameters.Add("border_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlcountry.SelectedValue
            If hidlat.Value = "" Then
                cmd.Parameters.Add("lat", NpgsqlTypes.NpgsqlDbType.Numeric).Value = DBNull.Value
            Else
                cmd.Parameters.Add("lat", NpgsqlTypes.NpgsqlDbType.Numeric).Value = hidlat.Value
            End If
            If hidlon.Value = "" Then
                cmd.Parameters.Add("lon", NpgsqlTypes.NpgsqlDbType.Numeric).Value = DBNull.Value
            Else
                cmd.Parameters.Add("lon", NpgsqlTypes.NpgsqlDbType.Numeric).Value = hidlon.Value
            End If
            cmd.ExecuteNonQuery()
            Response.Redirect("BorderCheck.aspx")
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถบันทึกข้อมูลได้ Error >>> " & ex.Message.ToString & " กรุณาลองอีกครั้ง!!! ');", True)
        Finally
            cmd.Connection.Close()
            con.Close()
            dbConnect = Nothing
        End Try
    End Sub

    Protected Sub BtnBack_Click(sender As Object, e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("BorderCheck.aspx")
    End Sub

    Private Function ZoomLocation() As String
        Dim min_x, min_y, max_x, max_y As Double
        Dim chkSch As Boolean = True
        Dim sql As String = ""
        Dim conname As String = ""
        Dim strCommand As String = ""


        strCommand = " SELECT  ST_xmin(ST_extent(ST_Transform(the_geom, 4326))) As xmin " & _
            " , ST_Ymin(ST_extent(ST_Transform(the_geom, 4326))) As ymin" & _
            " , ST_xmax(ST_extent(ST_Transform(the_geom, 4326))) As xmax " & _
            " , ST_ymax(ST_extent(ST_Transform(the_geom, 4326))) As ymax " & _
            "from province WHERE prov_code='" & ddlPro.SelectedValue & "'"


        If chkSch Then
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
            Try
                con.ClearPool()
                cmd.Connection = con
                If cmd.Connection.State = Data.ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = strCommand
                Dim dr As NpgsqlDataReader
                dr = cmd.ExecuteReader
                If dr.Read Then
                    min_x = IIf(dr("xmin") Is DBNull.Value, 0, dr("xmin"))
                    min_y = IIf(dr("ymin") Is DBNull.Value, 0, dr("ymin"))
                    max_x = IIf(dr("xmax") Is DBNull.Value, 0, dr("xmax"))
                    max_y = IIf(dr("ymax") Is DBNull.Value, 0, dr("ymax"))
                End If
                dr.Close()
                con.Close()
            Catch ex As Exception

            Finally
                If cmd.Connection.State = Data.ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                con.Close()
            End Try
            Return " ZoomLocation(" & min_x & "," & min_y & "," & max_x & "," & max_y & "); "
        Else
            Return ""
        End If
    End Function

    Protected Sub ddlPro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPro.SelectedIndexChanged
        Dim Location As String = ZoomLocation()
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", " " & Location & " ", True)
    End Sub

    Protected Sub btn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn1.Click
        lat.Text = hidlat.Value
        lon.Text = hidlon.Value
    End Sub
End Class
