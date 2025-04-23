Imports Npgsql
Imports System.Data
Imports System.IO
Imports Microsoft.Reporting.WebForms
Imports System.Drawing
Imports System.Configuration
Imports System.Drawing.Bitmap
Imports System.Drawing.Image

Partial Class Sign
    Inherits System.Web.UI.Page
    Private dt As New DataTable
    Protected Spare_driver As String
    Dim token As String
    Dim fPathCar As String = "Upload/Vehicle/"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection

        token = Request.QueryString("token")

        If Request.QueryString("typeuser") = 5 Then
            Dim stq = "select status_id from license WHERE token = '" & token & "' "
            Dim check = dbConnect.executeScalar(stq)
            If check = 0 Then          
                Try
                    con.Open()
                    cmd.Connection = con
                    Dim strupdate = "UPDATE license set  status_id = 5 , start_date=:start_date , exp_date=:exp_date , license_no = :license_no WHERE token = '" & token & "'"
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = strupdate
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
                    cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DateSerial(Now.Year + 1, Now.Month, Now.Day)
                    cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.licenseNo(1)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                Finally
                    cmd.Connection.Close()
                    con.Close()
                    cmd.Dispose()
                End Try
            End If
        End If



        DisplayReport()


    End Sub

    Private Function getTsmData() As DataTable
        Dim token = Request.QueryString("token")
        'ข้อมูลคนขับรถหลัก
        Dim dt As New DataTable
        Dim db As New DBConnect
        Dim str As String
        If Request.QueryString("typeuser") = 5 Then
            str = " SELECT CAST('เลขที่ใบอนุญาต' || license.license_no  as varchar ) as province , sign_th ,  car_commerce.registration_no as plate ,(select string_agg(prov_en , ',') from area " & _
                  " LEFT JOIN province on area.prov_code = province.prov_code  WHERE license_id = license.license_id) as area , (select count(prov_en) from area LEFT JOIN province on area.prov_code = province.prov_code " & _
                  " WHERE license_id = license.license_id) as countprov  , car_commerce.country_car ,  " & _
                  " CAST('1 . ' || driver.prename || ' ' || driver.name ||' '|| driver.surname as varchar) as name ,  CAST( driver.prename || ' ' || driver.name ||' '|| driver.surname as varchar) as name1 , " & _
                  "  (select CAST('2 . ' || spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 1) as name2, " & _
                  "  (select CAST('3 . ' || spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 2) as name3, " & _
                  "    car_commerce.vehicle_type as type_car , car_commerce.colour as colors , car_commerce.brand as brands , car_commerce.model , (SELECT REPLACE(border_nameth,'ด่านพรมแดน','') from border_check WHERE license.checkin_id = border_check.border_id)as checkin ,  " & _
                  "    (SELECT REPLACE(border_nameth,'ด่านพรมแดน','') from border_check WHERE license.checkout_id = border_check.border_id)as checkout , CAST('https://api.qrserver.com/v1/create-qr-code/?data=' as varchar)|| qrcode as qrcode , CAST( start_date || ' - ' ||  exp_date as varchar ) as exp , " & _
                  "     CAST('Upload/Vehicle/' || (SELECT car_pic.file_name from car_pic WHERE car_id = car.car_id order by gid asc  limit 1 ) as varchar ) as pic  from license " & _
                  "       LEFT JOIN border_check on border_check.border_id = license.checkin_id  LEFT JOIN province on province.prov_code = border_check.prov_code " & _
                  "       LEFT JOIN type_user on license.typeuser_id = type_user.typeuser_id LEFT JOIN car on license.car_id = car.car_id  " & _
                  "        LEFT JOIN driver on license.driver_id = driver.driver_id  LEFT JOIN spare_driver on spare_driver.driver_id = driver.driver_id  " & _
                  "        LEFT JOIN car_commerce on car_commerce.car_id = license.car_id " & _
                  "         WHERE token = '" & token & "' and status_id in(4,5) limit 1 "
        ElseIf Request.QueryString("typeuser") = 3 Or Request.QueryString("typeuser") = 4 Or Request.QueryString("typeuser") = 2 Then

         
            str = " SELECT CAST('image/sign2.jpg' as varchar) as imgsign, CAST(license.license_no  as varchar ) as permit , " & _
                  " plate ,CAST('' as varchar) as area ,  " & _
                  " (select count(prov_en) from area " & _
                  "  LEFT JOIN province on area.prov_code = province.prov_code " & _
                  " WHERE license_id = license.license_id) as countprov , country_car ,  " & _
                  " substring(CAST( coalesce(owner_prename,'') ||' ' || owner_name ||' '|| coalesce(owner_lastname,'') as varchar),0,36) as nameowner ,  " & _
                  " substring(CAST('1 . ' || driver.prename || ' ' || driver.name ||' '|| driver.surname as varchar),0,36) as name1 ,  " & _
                  " substring((select CAST('2 . ' || spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 1),0,36) as name2,  " & _
                  " substring((select CAST('3 . ' || spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 2),0,36) as name3, " & _
                  " split_part(type_name,'(',1) as type_name  , colors , brands , model " '& _
            If Request.QueryString("typeuser") = 2 Then
                str = str & ", upper(substring((SELECT border_nameen from border_check WHERE travel_group.checkin_id = border_check.border_id),0,21)) as checkin , " & _
                 " upper(substring((SELECT border_nameen from border_check WHERE travel_group.checkout_id = border_check.border_id),0,22)) as checkout " & _
                 "  , to_char( travel_group.start_date , 'DD/MM/YYYY') as start_date , to_char( travel_group.exp_date , 'DD/MM/YYYY') as exp_date "
            Else
                str = str & ", upper(substring((SELECT border_nameen from border_check WHERE license.checkin_id = border_check.border_id),0,21)) as checkin , " & _
                  " upper(substring((SELECT border_nameen from border_check WHERE license.checkout_id = border_check.border_id),0,22)) as checkout " & _
                  "  , to_char( license.start_date , 'DD/MM/YYYY') as start_date , to_char( license.exp_date , 'DD/MM/YYYY') as exp_date "
            End If
                 
            str = str & " , CAST('https://api.qrserver.com/v1/create-qr-code/?data=' as varchar)|| " & _
              " qrcode as qrcode, CAST('Upload/Vehicle/' || (SELECT car_pic.file_name from car_pic WHERE car_id = car.car_id order by gid asc  limit 1 ) as varchar ) as pic " & _
              " , substring(case when(select count(*) from receipt WHERE receipt.license_id = license.license_id) = 0 then license.registrar_name else (select registrar_name from receipt WHERE receipt.license_id = license.license_id order by unit desc limit 1) end,0,37) as registrar " & _
              " , substring(case when(select count(*) from receipt WHERE receipt.license_id = license.license_id) = 0 then split_part(license.registrar_position, ' ',1) else (select split_part(registrar_position, ' ',1) from receipt WHERE receipt.license_id = license.license_id order by unit desc limit 1) end,0,37) as regis_pos " & _
              " from license " '& _
            If Request.QueryString("typeuser") = 2 Then
                str = str & " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
                " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                " LEFT JOIN admin on travel_group.admin_id = admin.admin_id " '& _
            Else
                str = str & " LEFT JOIN admin on license.admin_id = admin.admin_id " '& _
            End If

            str = str & " LEFT JOIN province on admin.prov_code = province.prov_code  " & _
             " LEFT JOIN type_user on license.typeuser_id = type_user.typeuser_id " & _
             " LEFT JOIN car on license.car_id = car.car_id " & _
             " LEFT JOIN driver on license.driver_id = driver.driver_id  " & _
             " LEFT JOIN spare_driver on spare_driver.driver_id = driver.driver_id  " & _
             " LEFT JOIN type_car on type_car.type_id = car.typecar_id " & _
             " WHERE token = '" & token & "' and status_id in(4,5) limit 1 "
        Else
          
            str = " SELECT CAST('image/sign1.jpg' as varchar) as imgsign, CAST(license.license_no  as varchar ) as permit , " & _
                  " plate ,(select string_agg(prov_en , ',') " & _
                  " from area LEFT JOIN province on area.prov_code = province.prov_code " & _
                  " WHERE license_id = license.license_id) as area , " & _
                  " (select count(prov_en) from area " & _
                  " LEFT JOIN province on area.prov_code = province.prov_code " & _
                  " WHERE license_id = license.license_id) as countprov , country_car ,  " & _
                  " substring(CAST( coalesce(owner_prename,'') ||' ' || owner_name ||' '|| coalesce(owner_lastname,'') as varchar),0,36) as nameowner ,  " & _
                  " substring(CAST( driver.prename || ' ' || driver.name ||' '|| driver.surname as varchar),0,36) as name1 ,  " & _
                  " substring((select CAST( spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 1),0,36) as name2,  " & _
                  " substring((select CAST( spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 2),0,36) as name3, " & _
                  " split_part(type_name,'(',1) as type_name  , colors , brands , model , upper(substring((SELECT border_nameen from border_check WHERE license.checkin_id = border_check.border_id),0,21)) as checkin , " & _
                  " upper(substring((SELECT border_nameen from border_check WHERE license.checkout_id = border_check.border_id),0,22)) as checkout , CAST('https://api.qrserver.com/v1/create-qr-code/?data=' as varchar)|| " & _
                  " qrcode as qrcode , to_char( travel_group.start_date , 'DD/MM/YYYY') as start_date , to_char( license.exp_date , 'DD/MM/YYYY') as exp_date ,  CAST('Upload/Vehicle/' || (SELECT car_pic.file_name from car_pic WHERE car_id = car.car_id order by gid asc  limit 1 ) as varchar ) as pic " & _
                  " , substring(case when(select count(*) from receipt WHERE receipt.license_id = license.license_id) = 0 then license.registrar_name else (select registrar_name from receipt WHERE receipt.license_id = license.license_id order by unit desc limit 1) end,0,37) as registrar " & _
                  " , substring(case when(select count(*) from receipt WHERE receipt.license_id = license.license_id) = 0 then split_part(license.registrar_position, ' ',1) else (select split_part(registrar_position, ' ',1) from receipt WHERE receipt.license_id = license.license_id order by unit desc limit 1) end,0,37) as regis_pos " & _
                  " from license " & _
                  " LEFT JOIN admin on license.admin_id = admin.admin_id LEFT JOIN province on admin.prov_code = province.prov_code  " & _
                  " LEFT JOIN type_user on license.typeuser_id = type_user.typeuser_id LEFT JOIN car on license.car_id = car.car_id " & _
                  " LEFT JOIN driver on license.driver_id = driver.driver_id  LEFT JOIN spare_driver on spare_driver.driver_id = driver.driver_id  " & _
                  " LEFT JOIN type_car on type_car.type_id = car.typecar_id " & _
                  " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                  " WHERE token = '" & token & "' and status_id in(4,5) limit 1 "

        End If

        dt = db.getDataTable(str, "driver")
        Return dt
    End Function

    Protected Sub DisplayReport()
        dt = getTsmData()
        If token <> "" Then
            If dt.Rows(0)("countprov") > 3 Then
                If Request.QueryString("typeuser") <> 2 Then
                    dt.Rows(0)("area") = "Please Scan QR code"
                End If
            End If
            If Request.QueryString("typeuser") = 3 Then
                dt.Rows(0)("country_car") = "Laos"
            End If
            dtl1.DataSource = dt
            dtl1.DataBind()
        End If
    End Sub

   
End Class
