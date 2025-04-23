Imports System.Data
Imports Npgsql

Partial Class Map_MapAdmin2
    Inherits System.Web.UI.Page
    Private Populate As New PopulateDropDown
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Request.QueryString("IsUpdate") = "1" Then

            Else
                PnUpdateData.Visible = False
            End If

            Populate.genDDLProvince(ddlPro, False)
            'Populate.genDDLAmphoe(ddlPro, ddlAmp, "All Amphoe")
            'Populate.genDDLTumbol(ddlPro, ddlAmp, ddlTum, "All Tumbol")
            loadMap()
        End If
    End Sub

    Private Sub loadMap()
        Dim JsMarkerAdmin As String = ""
        Dim db As New DBConnect
        Try
            Dim str As String = "select admin_id , admin_nameen , lat , lon from admin where lat > 0 and lon > 0 "
            Dim DtAdmin As DataTable = db.getDataTable(str, "dataAdmin")
            For Each dr As DataRow In DtAdmin.Rows
                JsMarkerAdmin = JsMarkerAdmin & " AddMarkerAdmin(" & dr("lon") & "," & dr("lat") & ",'" & dr("admin_nameen") & "'," & dr("admin_id") & "); "
            Next
        Catch ex As Exception

        End Try
        If Page.IsPostBack = False Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", "  addMap(); " & JsMarkerAdmin, True)
        Else
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", " RemoveLayerGroup(); " & " ZoomLayerGroup(); ", True)
        End If
    End Sub

    Protected Sub BtnUpdateDataMarker_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdateDataMarker.Click
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Try
            con.ClearPool()
            con.Open()
            cmd.Connection = con

            cmd.CommandText = "  UPDATE admin SET lon = null , lat = null "
            cmd.ExecuteNonQuery()

            ''landmark60
            'Dim strsubquery As String = "SELECT admin_id , replace(admin_name,'สำนักงานขนส่งจังหวัด','') admin_name , point_x, point_y FROM admin " & _
            '" left join (  SELECT  replace(replace(name_t,'สำนักงานขนส่งจังหวัด',''),'สงขลาแ','สงขลา') name_t, point_x, point_y  " & _
            '"       FROM public.landmark60 where name_t like '%สำนักงานขนส่งจังหวัด%' and name_t not like '% สาขา%' and name_t not like '% ส%' " & _
            '"       and gid in (select min(gid)  from  public.landmark60 where name_t like '%สำนักงานขนส่งจังหวัด%' and name_t not like '% สาขา%' and name_t not like '% ส%' " & _
            '"       group by replace(name_t,'สำนักงานขนส่งจังหวัด','')  ) order by name_t" & _
            '" ) dt on replace(admin.admin_name,'สำนักงานขนส่งจังหวัด','') like '%' || replace(dt.name_t,'สำนักงานขนส่งจังหวัด','')  || '%' order by admin_name "

            ''landmark60V2
            Dim strsubquery As String = " SELECT admin_id , point_x, point_y FROM admin " & _
            " left join (  SELECT   replace(replace(name_t2,'สำนักงานขนส่ง',''),'จังหวัด','')   name_t, point_x, point_y   " & _
            "        FROM  landmark60v2 where (name_t2 like '%สำนักงานขนส่งจังหวัด%' or name_t2 like '%สำนักงานขนส่งกรุงเทพ%' ) and name_t2 not like '% สาขา%' and name_t2 not like '% ส%'  and name_t2 not like '%แห่ง%' " & _
            "        and name_t2 not like '%ร้านค้า%'   and name_t2 not like '%อาคาร%'  and name_t2 not like '%ย่อย%' " & _
            "        ) dt on replace(admin.admin_name,'สำนักงานขนส่งจังหวัด','') like '%' || replace(dt.name_t,'สำนักงานขนส่งจังหวัด','')  || '%' order by admin_name "
            Dim strCommand As String = " UPDATE admin SET lon = subquery.point_x , lat = subquery.point_y FROM ( " & strsubquery & " ) AS subquery WHERE admin.admin_id = subquery.admin_id "
            cmd.CommandText = strCommand
            cmd.ExecuteNonQuery()
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", "  alert('ระบบอัปเดตตำแหน่งสำนักขนส่งจังหวัดเรียบร้อยแล้ว'); ", True)
        Catch ex As Exception

        Finally
            If cmd.Connection.State = Data.ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            con.Close()
        End Try
    End Sub

#Region "ตำบล/อำเภอ/จังหวัด"
    Protected Sub ddlPro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPro.SelectedIndexChanged
        Populate.genDDLAmphoe(ddlPro, ddlAmp, False)
        Populate.genDDLTumbol(ddlPro, ddlAmp, ddlTum, False)
        UpdLocation.Update()
        Dim Location As String = ZoomLocation()
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", " " & Location & " ", True)
    End Sub

    Protected Sub ddlAmp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAmp.SelectedIndexChanged
        Populate.genDDLTumbol(ddlPro, ddlAmp, ddlTum, False)
        UpdLocation.Update()
        Dim Location As String = ZoomLocation()
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript2", " " & Location & " ", True)
    End Sub

    Protected Sub ddlTum_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTum.SelectedIndexChanged
        'Populate.genDDLTumbol(ddlPro, ddlAmp, ddlTum, False)
        'UpdLocation.Update()
        Dim Location As String = ZoomLocation()
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript3", " " & Location & " ", True)
    End Sub
#End Region

    Private Function ZoomLocation() As String
        Dim min_x, min_y, max_x, max_y As Double
        Dim chkSch As Boolean = True
        Dim sql As String = ""
        Dim conname As String = ""
        Dim strCommand As String = ""

        If ddlTum.SelectedIndex <> 0 Then
            strCommand = " SELECT  ST_xmin(ST_extent(ST_Transform(the_geom, 4326))) As xmin " & _
                " , ST_Ymin(ST_extent(ST_Transform(the_geom, 4326))) As ymin" & _
                " , ST_xmax(ST_extent(ST_Transform(the_geom, 4326))) As xmax " & _
                " , ST_ymax(ST_extent(ST_Transform(the_geom, 4326))) As ymax " & _
                "from tumbol WHERE t_id='" & ddlTum.SelectedValue & "'"
        ElseIf ddlAmp.SelectedIndex <> 0 Then
            strCommand = " SELECT ST_xmin(ST_extent(ST_Transform(the_geom, 4326))) As xmin " & _
                " , ST_Ymin(ST_extent(ST_Transform(the_geom, 4326))) As ymin" & _
                " , ST_xmax(ST_extent(ST_Transform(the_geom, 4326))) As xmax " & _
                " , ST_ymax(ST_extent(ST_Transform(the_geom, 4326))) As ymax " & _
                "from tumbol WHERE a_code='" & ddlAmp.SelectedValue & "' and p_code = '" & ddlPro.SelectedValue & "' "
        ElseIf ddlPro.SelectedIndex <> 0 Then
            strCommand = " SELECT  ST_xmin(ST_extent(ST_Transform(the_geom, 4326))) As xmin " & _
                " , ST_Ymin(ST_extent(ST_Transform(the_geom, 4326))) As ymin" & _
                " , ST_xmax(ST_extent(ST_Transform(the_geom, 4326))) As xmax " & _
                " , ST_ymax(ST_extent(ST_Transform(the_geom, 4326))) As ymax " & _
                "from province WHERE prov_code='" & ddlPro.SelectedValue & "'"
        Else
            chkSch = False
        End If

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

    Protected Sub btnSetAdmin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetAdmin.Click
        Dim script = " winOpener=window.self.opener; " & _
                         " winOpener.document.getElementById('MainContent_HidValueddladmin').value='" & HidAdminID.Value & "' ; " & _
                         " winOpener.document.getElementById('MainContent_btnSetValueddladmin').click() ; " & _
                         " window.close(); "
        'Response.Write("<script language='javascript'> { alert('456'); }</script>")
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", script, True)
    End Sub
End Class
