Imports System.Data

Partial Class Map_RealtimeLocation
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            genDDLLicense(ddlLicense)
            Populate.genDDLCountry(ddlcountry, "เลือกทั้งหมด")
            Populate.genDDLCartype(ddltype_car, True)
            Populate.genDDLTypeUser(ddltype, True)
            loadMap()
        End If
    End Sub

    Private Sub loadMap()
        Dim JsProvince As New StringBuilder
        JsProvince.Remove(0, JsProvince.Length)
        If Request.QueryString("no") <> "" Then
            over_map_rights.Visible = False
            ddlLicense.SelectedValue = Request.QueryString("no")
        End If
        Dim JsMarkerCar As String = ""

        Dim db As New DBConnect
        Try
            'Dim strForm2 As String = "select lat , lon , date_time , typeuser_id from realtime_location left join license on license.token = realtime_location.token_license " & _
            '" where token_license in (select token from license where license_no = '" & ddlLicense.SelectedValue & "' and status_id = 1) "
            Dim strForm2 As String = "select lat , lon , date_time , typeuser_id from realtime_location left join license on license.token = realtime_location.token_license " & _
          " where token_license in (select token from license where license_no <> '' and status_id = 5 and license_id in (select license_id from license inner join car on car.car_id = license.car_id where 1=1 "


            If ddlLicense.SelectedIndex > 0 Then
                strForm2 = strForm2 & " and license_no = '" & ddlLicense.SelectedValue & "'"
            End If

            If ddltype.SelectedIndex > 0 Then
                strForm2 = strForm2 & " and  typeuser_id = " & ddltype.SelectedValue
            End If

            If ddlcountry.SelectedIndex > 0 Then
                strForm2 = strForm2 & " and  country_car = '" & ddlcountry.SelectedItem.Text & "'"
            End If

            If ddltype_car.SelectedIndex > 0 Then
                strForm2 = strForm2 & " and  typecar_id = " & ddltype.SelectedValue
            End If



            strForm2 = strForm2 & ") )"

            Dim DtForm2 As DataTable = db.getDataTable(strForm2, "Form2")
            Dim typeuser_id As Integer = 0
            For Each dr As DataRow In DtForm2.Rows
                Dim xy As String = dr("lon") & "," & dr("lat")
                JsMarkerCar = JsMarkerCar & " AddMarkerCar(" & xy & ",'<b> วันที่/เวลา : </b>" & Format(CDate(dr("date_time")), "dd MMM yy HH:mm น.") & "'); "
                If typeuser_id = 0 Then
                    typeuser_id = dr("typeuser_id")
                End If
            Next




            Dim strProvince As String = " select distinct prov_th , '[' || replace(replace(replace(replace(st_astext(st_flipcoordinates(ST_Transform(the_geom,4326))), 'MULTIPOLYGON(((', ''), ')', ''),',','],['),' ',',') ||  ']' as astxt " & _
                           " , replace(replace(st_astext(st_flipcoordinates(ST_Transform(the_geom,4326))), 'MULTIPOLYGON(((', ''), ')))', '') as astxt2 " & _
                           " from province where prov_code in (select prov_code from area where license_id in (select license_id from license inner join car on car.car_id = license.car_id " & _
                           " where 1=1 " 'and prov_code <> '0' "
            If ddlLicense.SelectedIndex > 0 Then
                strProvince = strProvince & " and license_no = '" & ddlLicense.SelectedValue & "'"
            End If

            If ddltype.SelectedIndex > 0 Then
                strProvince = strProvince & " and  typeuser_id = " & ddltype.SelectedValue
            End If

            If ddlcountry.SelectedIndex > 0 Then
                strProvince = strProvince & " and  country_car = '" & ddlcountry.SelectedItem.Text & "'"
            End If

            If ddltype_car.SelectedIndex > 0 Then
                strProvince = strProvince & " and  typecar_id = " & ddltype.SelectedValue
            End If
            strProvince = strProvince & ") )"

            'If Page.IsPostBack = False Then
            '    Dim MaxPro As Object = db.executeScalar(" select min(prov_code) from area where license_id in (select license_id from license inner join car on car.car_id = license.car_id ) ")
            '    If MaxPro = "0" Then
            '        'มันมีปัญหาตรงประเทศไทยนี่แระ prov_code = '0'
            '        strProvince = "select distinct prov_th , '[' || replace(replace(replace(replace(st_astext(st_flipcoordinates(ST_Transform(the_geom,4326))), 'MULTIPOLYGON(((', ''), ')', ''),',','],['),' ',',') ||  ']' as astxt " & _
            '               " , replace(replace(st_astext(st_flipcoordinates(ST_Transform(the_geom,4326))), 'MULTIPOLYGON(((', ''), ')))', '') as astxt2 " & _
            '               " from province where prov_code = '0' "

            '        'strProvince = "select distinct prov_th , '[' || replace(replace(replace(replace(st_astext(st_flipcoordinates(ST_Transform(the_geom,4326))), 'MULTIPOLYGON(((', ''), ')', ''),',','],['),' ',',') ||  ']' as astxt " & _
            '        '       " , replace(replace(st_astext(st_flipcoordinates(ST_Transform(the_geom,4326))), 'MULTIPOLYGON(((', ''), ')))', '') as astxt2 " & _
            '        '       " from province where prov_code <> '0' and the_geom is not null "
            '    End If
            'End If
            Dim dtProvince As DataTable = db.getDataTable(strProvince, "Province")

            For Each dr As DataRow In dtProvince.Rows
                Try
                    If dr("astxt") IsNot DBNull.Value Then
                        If dr("astxt").ToString.Contains("(") Then
                            If dr("astxt2").ToString.Contains(")),((") Then
                                'กรณีเกาะ
                                Dim astxt = dr("astxt2").ToString.Replace(")),((", "_")
                                Dim Ar As String() = astxt.Split("_")
                                For i As Integer = 0 To Ar.Length - 1
                                    Dim polyline As String = Ar(i).ToString.Replace(",", "],[").ToString.Replace(" ", ",")
                                    Dim _linePoints As String = " var polylinePro" & i & " = [[" & polyline.Substring(0, polyline.Length - 2) & "]]; "
                                    Dim _LineColor = "RoyalBlue"
                                    If i = Ar.Length - 1 Then
                                        JsProvince.Append(_linePoints & " AddProvince(polylinePro" & i & ",'" & dr("prov_th") & "','" & _LineColor & "'); ")
                                    Else
                                        JsProvince.Append(_linePoints & " AddProvince(polylinePro" & i & ",'','" & _LineColor & "'); ")
                                    End If
                                Next
                            Else
                                Dim astxt = dr("astxt").ToString.Replace("((", "").Replace("(", "")
                                Dim _linePoints As String = " var polylinePro = [" & astxt & " ]; "
                                Dim _LineColor = "RoyalBlue"
                                JsProvince.Append(_linePoints & " AddProvince(polylinePro,'" & dr("prov_th") & "','" & _LineColor & "'); ")
                            End If
                        Else
                            Dim astxt = dr("astxt").ToString
                            Dim _linePoints As String = " var polylinePro = [" & astxt & " ]; "
                            Dim _LineColor = "RoyalBlue"
                            JsProvince.Append(_linePoints & " AddProvince(polylinePro,'" & dr("prov_th") & "','" & _LineColor & "'); ")
                        End If
                    End If
                Catch ex As Exception

                End Try
            Next


        Catch ex As Exception

        Finally
            db = Nothing
        End Try
        If Page.IsPostBack = False Then
            'มันมีปัญหาตรงประเทศไทยนี่แระ prov_code = '0'
            'mBody.Attributes.Add("onload", " addMap(); " & JsMarkerCar & JsProvince.ToString & " ZoomLayerGroup(); ")
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", "  addMap(); " & JsMarkerCar & JsProvince.ToString, True)
        Else
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", " RemoveLayerGroup(); " & JsMarkerCar & JsProvince.ToString & " ZoomLayerGroup(); ", True)
        End If
    End Sub

    Public Sub genDDLLicense(ByVal ddl As DropDownList)
        'แขวงทางหลวง
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct license_no as text , license_no as value  from license where license_no <> '' and status_id = 5 order by license_no "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        'ddl.Items.Clear()
        'If IsSelectAll Then
        '    ddl.Items.Insert(0, "เลือกทั้งหมด")
        '    ddl.Items(0).Value = 0
        'End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        loadMap()
    End Sub

End Class
