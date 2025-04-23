Imports System.Data

Partial Class Map_MapLocations
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            'genDDLLicense(ddlLicense)
            'Populate.genDDLCountry(ddlcountry, "เลือกทั้งหมด")
            'Populate.genDDLCartype(ddltype_car, True)
            'Populate.genDDLTypeUser(ddltype, True)
            loadMap(False)
        End If
    End Sub

    Private Sub loadMap(ByVal IsClickPopup As Boolean)
        Dim JsProvince As New StringBuilder
        JsProvince.Remove(0, JsProvince.Length)
        If Request.QueryString("no") <> "" Then
            over_map_rights.Visible = False
            ddlLicense.SelectedValue = Request.QueryString("no")
        End If
        Dim JsMarkerCar As String = ""
        Dim JSBorder As String = ""
        Dim JsTest As String = ""
        Dim db As New DBConnect
        Dim Popup As String = ""


        Try
            If Not IsClickPopup Then
                Dim query1 = " select * from ( select DISTINCT ON (token) * , CAST('../Travel/GroupDtl.aspx?isPopup=1&id=' || group_id as varchar) as linkgroup from vmaplocation " & _
                             " WHERE date_time Is Not null  ORDER by token , date_time DESC  ) as dt WHERE 1=1 "
                Dim filter As String = ""

                If ddlStatus.SelectedIndex > 0 Then
                    filter = filter & "and wrong_way = " & ddlStatus.SelectedValue
                End If

                If HidLicense_NO.Value <> "" Then
                    filter = filter & " and token = '" & HidLicense_NO.Value & "'"
                End If

                If ddlTypePosition.SelectedIndex > 0 Then
                    If HidLicense_NO.Value <> "" Then

                    Else
                        filter = filter & " and is_guide = " & ddlTypePosition.SelectedValue
                    End If
                End If

                If ddlSelect.SelectedValue = 1 Then
                    filter = filter & " and now() - INTERVAL '3 DAY' < date_time "
                End If


                Dim form1 = db.getDataTable(query1 & filter, "form1")

                For Each dr As DataRow In form1.Rows
                    Dim xy As String = dr("lon") & "," & dr("lat")
                    Dim typecar_id As Integer = 0
                    If Not dr("typecar_id") Is DBNull.Value Then
                        typecar_id = dr("typecar_id")
                    End If
                    'คำว่า”ไกด์นำเที่ยว”,”ไกด์ทัวร์”ในระบบ เปลี่ยนเป็น “ผู้นำเที่ยว” ให้หมด และภาษาอังกฤษใช้ให้เหมือนกันคือ Tour leader or assistant
                    Dim txtpopup As String = "<span style=color:slateblue> วันที่/เวลา </span> <br /> &nbsp; " & Format(CDate(dr("date_time")), "dd MMM yy HH:mm น.") & " " & _
                                        "<br /><span style=color:slateblue> ชื่อผู้นำเที่ยว </span><br /> &nbsp; " & dr("_name") & "" & _
                                        "<br /><span style=color:slateblue> เลขทัวร์กรุ๊ป </span><br /> &nbsp; " & dr("license_group") & "" & _
                                        "<br /><span style='text-align: right; float: right; color:slateblue; '><a href=MapLocationHis.aspx?token=" & dr("token") & " target=_blank> [รายละเอียดการเดินทาง] </a></span> &nbsp;  " & _
                                        "<br /><span style='text-align: right; float: right; color:slateblue; '><a href=" & dr("linkgroup") & " target=_blank> [รายละเอียดกรุ๊ป] </a></span> <br/> &nbsp;  "
                    'Popup = Popup & "L.popup({ autoClose: false })" & _
                    '                      ".setContent(" & txtpopup & ")" & _
                    '                      ".setLatLng([" & dr("lat") & ", " & dr("lon") & "])" & _
                    '                      ".openOn(maps); "
                    If dr("wrong_way") = "1" Then
                        JsMarkerCar = JsMarkerCar & " AddMarkerCar(" & xy & ",""" & txtpopup & """," & typecar_id & ",'R', '" & dr("token") & "' , " & dr("group_id") & "); "
                    Else
                        JsMarkerCar = JsMarkerCar & " AddMarkerCar(" & xy & ",""" & txtpopup & """," & typecar_id & ",'', '" & dr("token") & "' , " & dr("group_id") & "); "
                    End If
                Next
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", "RemoveLayerGroup1();" & JsMarkerCar, True)
            Else
                Dim query1 = " select * , CAST('../Travel/GroupDtl.aspx?isPopup=1&id=' || group_id as varchar) as linkgroup from vmaplocation WHERE date_time Is Not null and group_id = " & HidMarkerIB.Value
                Dim strProvince = "select geomjson from area_group LEFT JOIN province on province.prov_code = area_group.prov_code WHERE group_id = " & HidMarkerIB.Value
                Dim strBorder = "select _name , border_nameth , lat , lon from ( " & _
                                " (select CAST('ด่านพรมแดนขาเข้า' as varchar) as _name ,  border_nameth , lat , lon from border_check LEFT JOIN travel_group ci on ci.checkin_id = border_check.border_id WHERE group_id = " & HidMarkerIB.Value & ") " & _
                                " UNION ALL " & _
                                " (select CAST('ด่านพรมแดนขาออก' as varchar) as _name ,  border_nameth , lat , lon from border_check LEFT JOIN travel_group co on co.checkout_id = border_check.border_id WHERE group_id = " & HidMarkerIB.Value & " ) " & _
                                " ) as dt "

                Dim filter As String = ""
                If ddlStatus.SelectedIndex > 0 Then
                    filter = filter & "and wrong_way = " & ddlStatus.SelectedValue
                End If

                If HidLicense_NO.Value <> "" Then
                    filter = filter & " and token = '" & HidLicense_NO.Value & "'"
                End If

                If ddlSelect.SelectedValue = 1 Then
                    filter = filter & " and now() - INTERVAL '3 DAY' < date_time "
                End If


                Dim form1 = db.getDataTable(query1 & filter, "form1")

                For Each dr As DataRow In form1.Rows

                    Dim xy As String = dr("lon") & "," & dr("lat")
                    Dim typecar_id As Integer = 0
                    If Not dr("typecar_id") Is DBNull.Value Then
                        typecar_id = dr("typecar_id")
                    End If
                    Dim txtpopup As String
                    If typecar_id = "-1" Then
                        'คำว่า”ไกด์นำเที่ยว”,”ไกด์ทัวร์”ในระบบ เปลี่ยนเป็น “ผู้นำเที่ยว” ให้หมด และภาษาอังกฤษใช้ให้เหมือนกันคือ Tour leader or assistant
                        txtpopup = "<span style=color:slateblue> วันที่/เวลา </span> <br /> &nbsp; " & Format(CDate(dr("date_time")), "dd MMM yy HH:mm น.") & " " & _
                                      "<br /><span style=color:slateblue> ชื่อผู้นำเที่ยว </span><br /> &nbsp; " & dr("_name") & "" & _
                                      "<br /><span style=color:slateblue> เลขทัวร์กรุ๊ป </span><br /> &nbsp; " & dr("license_group") & "" & _
                                      "<br /><span style='text-align: right; float: right; color:slateblue; '><a href=MapLocationHis.aspx?token=" & dr("token") & " target=_blank> [รายละเอียดการเดินทาง] </a></span> &nbsp;  " & _
                                      "<br /><span style='text-align: right; float: right; color:slateblue; '><a href=" & dr("linkgroup") & " target=_blank> [รายละเอียดกรุ๊ป] </a></span> <br/> &nbsp;  "
                    Else
                        txtpopup = "<span style=color:slateblue> วันที่/เวลา </span> <br /> &nbsp; " & Format(CDate(dr("date_time")), "dd MMM yy HH:mm น.") & " " & _
                                    "<br /><span style=color:slateblue> ชื่อคนขับ </span><br /> &nbsp; " & dr("_name") & "" & _
                                    "<br /><span style=color:slateblue> เลขทัวร์กรุ๊ป </span><br /> &nbsp; " & dr("license_group") & "" & _
                                    "<br /><span style='text-align: right; float: right; color:slateblue; '><a href=MapLocationHis.aspx?token=" & dr("token") & " target=_blank> [รายละเอียดการเดินทาง] </a></span> &nbsp;  " & _
                                    "<br /><span style='text-align: right; float: right; color:slateblue; '><a href=" & dr("linkgroup") & " target=_blank> [รายละเอียดกรุ๊ป] </a></span> <br/> &nbsp;  "
                    End If

                    'Popup = Popup & "L.popup({ autoClose: false })" & _
                    '                      ".setContent(" & txtpopup & ")" & _
                    '                      ".setLatLng([" & dr("lat") & ", " & dr("lon") & "])" & _
                    '                      ".openOn(maps); "
                    If dr("wrong_way") = "1" Then
                        JsMarkerCar = JsMarkerCar & " AddMarkerGroup(" & xy & ",""" & txtpopup & """," & typecar_id & ",'R', '" & dr("token") & "' , " & dr("group_id") & "); "
                    Else
                        JsMarkerCar = JsMarkerCar & " AddMarkerGroup(" & xy & ",""" & txtpopup & """," & typecar_id & ",'', '" & dr("token") & "' , " & dr("group_id") & "); "
                    End If
                Next


                Dim dtProvince As DataTable = db.getDataTable(strProvince, "Province")
                For Each dr As DataRow In dtProvince.Rows
                    Try
                        If dr("geomjson") IsNot DBNull.Value Then
                            JsProvince.Append("AddProvince([" & dr("geomjson") & "]);")
                        End If
                    Catch ex As Exception

                    End Try
                Next


                Dim dtBorder As DataTable = db.getDataTable(strBorder, "Border")
                For Each dr As DataRow In dtBorder.Rows
                    Dim txtpopupBorder As String = ""
                    Dim xy As String = dr("lon") & "," & dr("lat")
                    Try
                        txtpopupBorder = "<span style=color:slateblue> " & dr("_name") & " </span><br /> &nbsp; " & dr("border_nameth") & ""
                        JSBorder = JSBorder & " AddBorder(" & xy & ", '" & txtpopupBorder & "');"
                    Catch ex As Exception

                    End Try
                Next



                ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", "RemoveLayerGroup1();" & JsMarkerCar & JsProvince.ToString & JSBorder, True)
            End If

        Catch ex As Exception

        Finally
            db = Nothing
        End Try


        'Try
        '    Dim filter As String
        '    'filter = " and license_id in (select license_id from license inner join car on car.car_id = license.car_id where 1=1 "
        '    'If ddlLicense.SelectedIndex > 0 Then
        '    '    filter = filter & " and license_no = '" & ddlLicense.SelectedValue & "'"
        '    'End If
        '    'If HidLicense_NO.Value <> "" Then
        '    '    filter = filter & " and license_no = '" & HidLicense_NO.Value & "'"
        '    'End If
        '    'If ddltype.SelectedIndex > 0 Then
        '    '    filter = filter & " and  typeuser_id = " & ddltype.SelectedValue
        '    'End If
        '    ''If ddlcountry.SelectedIndex > 0 Then
        '    ''    filter = filter & " and  country_car = '" & ddlcountry.SelectedItem.Text & "'"
        '    ''End If
        '    'If ddltype_car.SelectedIndex > 0 Then
        '    '    filter = filter & " and  typecar_id = " & ddltype_car.SelectedValue
        '    'End If
        '    'filter = filter & ")"

        '    If Not IsClickPopup Then


        '        Dim strForm2 As String = "select id_location , lat , lon , date_time , license.typeuser_id , typecar_id , license.license_id , license_no " ' , typename_th , type_name , en_short_name "
        '        strForm2 = strForm2 & " from realtime_location left join license on license.token = realtime_location.token_license "
        '        'strForm2 = strForm2 & " left join type_user on type_user.typeuser_id = license.typeuser_id "
        '        strForm2 = strForm2 & " left join car on car.car_id = license.car_id  "
        '        'strForm2 = strForm2 & " left join type_car on type_car.type_id = car.typecar_id " & _
        '        '" left join countries on countries.en_short_name = car.country_car "
        '        strForm2 = strForm2 & " where token_license in (select token from license where 1=1 " & _WhereLicense & filter & ") "

        '        'เอาตำแหน่งรถล่าสุด
        '        If HidLicense_NO.Value = "" Then
        '            strForm2 = strForm2 & " and date_time || license_no in ( select  max(date_time) ||   license_no  " & _
        '            " from realtime_location left join license on license.token = realtime_location.token_license " & _
        '            " left join car on car.car_id = license.car_id " & _
        '            " where token_license in (select token from license where 1=1 " & _WhereLicense & filter & ") group by license_no )  "
        '        End If
        '        Dim DtForm2 As DataTable = db.getDataTable(strForm2, "Form2")
        '        'Dim typeuser_id As Integer = 0
        '        For Each dr As DataRow In DtForm2.Rows
        '            Try
        '                If dr("lon") > 0 Then
        '                    If Request.QueryString("IsTest") = 1 Then
        '                        JsTest = JsTest & "\n" & dr("license_id") & " : " & dr("license_no")
        '                    End If

        '                    Dim strInPro As String = " select " & _
        '                                        "  ST_intersects( " & _
        '                                        "  st_setsrid(st_point(" & dr("lon") & "::numeric , " & dr("lat") & " ::numeric ) :: geometry , 4326), " & _
        '                                        "  ST_transform(the_geom,4326)) as geomlocation " & _
        '                                        "   from province " & _
        '                                        "  WHERE  prov_code in (select prov_code from area where license_id = " & dr("license_id") & ") order by geomlocation DESC "
        '                    Dim CheckIn As Object = False
        '                    Try
        '                        CheckIn = db.executeScalar(strInPro)
        '                    Catch ex As Exception

        '                        End Try
        '                    Dim xy As String = dr("lon") & "," & dr("lat")
        '                    Dim typecar_id As Integer = 0
        '                    If Not dr("typecar_id") Is DBNull.Value Then
        '                        typecar_id = dr("typecar_id")
        '                        End If

        '                    Dim txtpopup As String = "" '"<span style=color:slateblue> วันที่/เวลา </span> <br /> &nbsp; " & Format(CDate(dr("date_time")), "dd MMM yy HH:mm น.") & "" & _
        '                        '"<br /><span style=color:slateblue> เลขที่ใบอนุญาต </span><br /> &nbsp; " & dr("license_no") & "" & _
        '                        '"<br /><span style=color:slateblue> แบบขออนุญาต </span><br /> &nbsp; " & dr("typename_th") & "" & _
        '                        '"<br /><span style=color:slateblue> ประเภทรถ </span><br /> &nbsp; " & dr("type_name") & "" & _
        '                        '"<br /><span style=color:slateblue> ประเทศ </span><br /> &nbsp; " & dr("en_short_name") & ""
        '                    If CheckIn = False Then
        '                        If ddlStatus.SelectedValue = 1 Then
        '                                'อยู่ในเส้นทาง
        '                        Else
        '                            JsMarkerCar = JsMarkerCar & " AddMarkerCar(" & xy & ",'" & txtpopup & "'," & typecar_id & ",'R'," & dr("id_location") & "); "
        '                            End If
        '                    Else
        '                        If ddlStatus.SelectedValue = 2 Then
        '                                'ออกนอกเส้นทาง
        '                        Else
        '                            JsMarkerCar = JsMarkerCar & " AddMarkerCar(" & xy & ",'" & txtpopup & "'," & typecar_id & ",''," & dr("id_location") & "); "
        '                            End If
        '                            'If typeuser_id = 0 Then
        '                            '    typeuser_id = dr("typeuser_id")
        '                            'End If
        '                        End If
        '                End If
        '            Catch ex As Exception
        '                Response.Write("Error license_id : " & dr("license_id") & " >>> " & ex.Message.ToString)
        '            End Try
        '        Next
        '    Else
        '        Dim strlicense = "select license_no " & _
        '        " from realtime_location  " & _
        '        " LEFT JOIN license on license.token = realtime_location.token_license " & _
        '        " WHERE id_location = " & HidMarkerIB.Value & " "
        '        Dim license = db.executeScalar(strlicense)

        '        Dim strMarkCar = "select id_location , lat , lon , date_time , license.typeuser_id , typecar_id , license.license_id , license_no  from realtime_location left join license on license.token = realtime_location.token_license  left join car on car.car_id = license.car_id   where token_license in (select token from license where 1=1  and license_no <> '' and status_id = 5   and license_id in (select license_id from license inner join car on car.car_id = license.car_id where 1=1  and license_no = '" & license & "')) "

        '        Dim DtForm3 As DataTable = db.getDataTable(strMarkCar, "Form3")
        '        'Dim typeuser_id As Integer = 0
        '        For Each dr As DataRow In DtForm3.Rows
        '            Try
        '                If dr("lon") > 0 Then
        '                    If Request.QueryString("IsTest") = 1 Then
        '                        JsTest = JsTest & "\n" & dr("license_id") & " : " & dr("license_no")
        '                    End If

        '                    Dim strInPro As String = " select " & _
        '                                        "  ST_intersects( " & _
        '                                        "  st_setsrid(st_point(" & dr("lon") & "::numeric , " & dr("lat") & " ::numeric ) :: geometry , 4326), " & _
        '                                        "  ST_transform(the_geom,4326)) as geomlocation " & _
        '                                        "   from province " & _
        '                                        "  WHERE  prov_code in (select prov_code from area where license_id = " & dr("license_id") & ") order by geomlocation DESC "
        '                    Dim CheckIn As Object = False
        '                    Try
        '                        CheckIn = db.executeScalar(strInPro)
        '                    Catch ex As Exception

        '                    End Try
        '                    Dim xy As String = dr("lon") & "," & dr("lat")
        '                    Dim yx As String = dr("lat") & "," & dr("lon")
        '                    Dim typecar_id As Integer = 0
        '                    If Not dr("typecar_id") Is DBNull.Value Then
        '                        typecar_id = dr("typecar_id")
        '                    End If

        '                    Dim txtpopup As String = "<span style=color:slateblue> วันที่/เวลา </span> <br /> &nbsp; " & Format(CDate(dr("date_time")), "dd MMM yy HH:mm น.") & ""
        '                    '"<br /><span style=color:slateblue> เลขที่ใบอนุญาต </span><br /> &nbsp; " & dr("license_no") & "" & _
        '                    '"<br /><span style=color:slateblue> แบบขออนุญาต </span><br /> &nbsp; " & dr("typename_th") & "" & _
        '                    '"<br /><span style=color:slateblue> ประเภทรถ </span><br /> &nbsp; " & dr("type_name") & "" & _
        '                    '"<br /><span style=color:slateblue> ประเทศ </span><br /> &nbsp; " & dr("en_short_name") & ""
        '                    Popup = Popup & "L.popup({ autoClose: false })" & _
        '                                          ".setContent('" & txtpopup & "')" & _
        '                                          ".setLatLng([" & yx & "])" & _
        '                                          ".openOn(maps); "

        '                    If CheckIn = False Then
        '                        If ddlStatus.SelectedValue = 1 Then
        '                            'อยู่ในเส้นทาง
        '                        Else
        '                            JsMarkerCar = JsMarkerCar & " AddMarkerCar(" & xy & ",'" & txtpopup & "'," & typecar_id & ",'R'," & dr("id_location") & "); "
        '                        End If
        '                    Else
        '                        If ddlStatus.SelectedValue = 2 Then
        '                            'ออกนอกเส้นทาง
        '                        Else
        '                            JsMarkerCar = JsMarkerCar & " AddMarkerCar(" & xy & ",'" & txtpopup & "'," & typecar_id & ",''," & dr("id_location") & "); "
        '                        End If
        '                        'If typeuser_id = 0 Then
        '                        '    typeuser_id = dr("typeuser_id")
        '                        'End If
        '                    End If
        '                End If
        '            Catch ex As Exception
        '                Response.Write("Error license_id : " & dr("license_id") & " >>> " & ex.Message.ToString)
        '            End Try
        '        Next

        '    End If

        '    If Request.QueryString("IsTest") = 1 Then
        '        JsTest = JsTest & "\n License_NO : " & HidLicense_NO.Value
        '        JsTest = JsTest & "\n HidMarkerIB : " & HidMarkerIB.Value
        '    End If

        '    If HidLicense_NO.Value = "" And HidMarkerIB.Value = "" Then
        '        'ครั้งแรกไม่ต้องโชว์ประเทศก่อน เปลี่ยนเป็นมาโชว์ตอนคลิก Icon รถ 
        '        If Request.QueryString("IsTest") = 1 Then
        '            JsTest = JsTest & "\n Not Add Province "
        '        End If
        '    Else
        '        Dim strProvince As String = " select distinct prov_th , geomjson " & _
        '                                   " from province where prov_code in (select prov_code from area where 1=1 " & _
        '                                   IIf(IsClickPopup, " and license_id in ( select license_id from realtime_location left join license on license.token = realtime_location.token_license where id_location = " & HidMarkerIB.Value & " )", filter) & ")"
        '        If Request.QueryString("IsTest") = 1 Then
        '            JsTest = JsTest & "\n strProvince : " & strProvince.ToString.Replace("'", "-")
        '        End If
        '        Dim dtProvince As DataTable = db.getDataTable(strProvince, "Province")
        '        For Each dr As DataRow In dtProvince.Rows
        '            If Request.QueryString("IsTest") = 1 Then
        '                JsTest = JsTest & "\n" & dr("prov_th")
        '            End If

        '            Try
        '                  If dr("geomjson") IsNot DBNull.Value Then
        '                    JsProvince.Append("AddProvince([" & dr("geomjson") & "]);")
        '                End If
        '            Catch ex As Exception

        '            End Try
        '        Next
        '    End If

        'Catch ex As Exception

        'Finally
        '    db = Nothing
        'End Try
        'If Page.IsPostBack = False Then
        '    'มันมีปัญหาตรงประเทศไทยนี่แระ prov_code = '0'
        '    'mBody.Attributes.Add("onload", " addMap(); " & JsMarkerCar & JsProvince.ToString & " ZoomLayerGroup(); ")
        '    ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", "  addMap(); " & JsMarkerCar & Popup & JsProvince.ToString, True)
        'ElseIf IsClickPopup Then
        '    ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", " RemoveLayerGroup(); " & JsMarkerCar & Popup & JsProvince.ToString & " document.getElementById('HidMarkerIB').value = ''; document.getElementById('HidLicense_NO').value = ''; ZoomLayerGroup(); " & _
        '                                         IIf(Request.QueryString("IsTest") = 1, "alert('" & JsTest & "'); ", ""), True)
        'Else
        '    ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", " RemoveLayerGroup(); " & JsMarkerCar & Popup & JsProvince.ToString & " ZoomLayerGroup(); ", True)
        'End If
    End Sub


    Private _WhereLicense As String = " and license_no <> '' and status_id = 5  "
    Public Sub genDDLLicense(ByVal ddl As DropDownList)
        'แขวงทางหลวง
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct license_no as text , license_no as value  from license where 1=1 " & _WhereLicense & " order by license_no "
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
        loadMap(False)
    End Sub

    Protected Sub btnLoad1_Click(sender As Object, e As System.EventArgs) Handles btnLoad1.Click
        loadMap(True)
    End Sub
End Class
