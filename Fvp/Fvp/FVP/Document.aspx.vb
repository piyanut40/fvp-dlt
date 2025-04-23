Imports Npgsql
Imports System.Data
Imports System.IO
Imports Microsoft.Reporting.WebForms
Imports System.Drawing
Imports System.Configuration
Imports System.Drawing.Bitmap
Imports System.Drawing.Image

Partial Class Document
    Inherits System.Web.UI.Page
    Private dt As New DataTable
    Protected Spare_driver As String
    Dim token As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        token = Request.QueryString("token")
        'If Page.IsPostBack = False Then
        '    If Request.QueryString("p") = 1 Then
        '        lblhead.Text = "พิมพ์ใบอนุญาตผู้จัดการด้านความปลอดภัย"
        '    Else
        '        lblhead.Text = "พิมพ์ใบขออนุญาตผู้จัดการด้านความปลอดภัย"
        '    End If
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        If Request.QueryString("typeuser") = 5 Then
            Dim stq = "select status_id from license WHERE token = '" & token & "' "
            Dim check = DBConnect.executeScalar(stq)
            If check = 0 Then
                Try
                    con.Open()
                    cmd.Connection = con
                    Dim strupdate = "UPDATE license set status_id = 1 , start_date=:start_date , exp_date=:exp_date , license_no = :license_no WHERE token = '" & token & "' "
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = strupdate
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
                    cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DateSerial(Now.Year + 1, Now.Month, Now.Day)
                    cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.licenseNo(0)
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
        'End If

    End Sub

    Private Function getTsmData() As DataTable
        'ข้อมูลคนขับรถหลัก
        Dim dt As New DataTable
        Dim db As New DBConnect
        Dim str As String
        If Request.QueryString("typeuser") = 5 Then
            str = " SELECT license.typeuser_id , doc_th , name , surname , passport_no , car_commerce.email , car_commerce.address , state , county , countries , zipcode , national , tel ,  " & _
            " car_commerce.brand as brands , car_commerce.vehicle_type as typecar_en , car_commerce.model , car_commerce.colour as colors , car_commerce.weight_gross as weight , car_commerce.seats_no as  seat , " & _
             "  car_commerce.engine_no , car_commerce.country_car as country_car , car_commerce.vin_no as car_no , act_name ,   act_no , act_name , act_company , " & _
            "   CAST(act_start  || ' - ' || act_ends as varchar) as exp ,  (select border_nameth from border_check WHERE border_id = checkin_id) as check_in ,   " & _
             "   (select border_nameth from border_check WHERE border_id = checkout_id) as check_out ,   (select string_agg(prov_th , ',') from area  " & _
              "  LEFT JOIN province on  " & _
             "   area.prov_code = province.prov_code WHERE license_id = license.license_id) as area ,   qrcode , license_no , CAST(start_date as varchar) as start_date ,  " & _
             "   CAST(exp_date as varchar) as exp_date , license.start_date from license  LEFT JOIN driver on driver.driver_id = license.driver_id   " & _
              "  LEFT JOIN car on car.car_id = license.car_id  " & _
              "   LEFT JOIN car_commerce on car_commerce.car_id = license.car_id  " & _
              "   LEFT JOIN act on act.act_id = license.act_id  LEFT JOIN type_car on type_car.type_id  = car.typecar_id  LEFT JOIN type_user on type_user.typeuser_id = license.typeuser_id  " & _
                  "   WHERE license.status_id = 1 and token =  '" & token & "'"
        Else
            str = " SELECT license.typeuser_id , doc_th , name , surname , passport_no , email , address , state , county , countries , zipcode , national , tel , " & _
                           " brands , type_name as typecar_en , model , colors , weight , seat , engine_no , country_car , car_no , act_name ,  " & _
                           " act_no , act_name , act_company , CAST(act_start  || ' - ' || act_ends as varchar) as exp , " & _
                           " (select border_nameth from border_check WHERE border_id = checkin_id) as check_in ,  " & _
                           " (select border_nameth from border_check WHERE border_id = checkout_id) as check_out ,  " & _
                           " (select string_agg(prov_th , ',') from area LEFT JOIN province on area.prov_code = province.prov_code WHERE license_id = license.license_id) as area ,  " & _
                           " qrcode , license_no , CAST(start_date as varchar) as start_date , CAST(exp_date as varchar) as exp_date , license.start_date from license " & _
                           " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                           " LEFT JOIN car on car.car_id = license.car_id " & _
                           " LEFT JOIN act on act.act_id = license.act_id " & _
                           " LEFT JOIN type_car on type_car.type_id  = car.typecar_id " & _
                           " LEFT JOIN type_user on type_user.typeuser_id = license.typeuser_id " & _
                           " WHERE license.status_id = 5 and token = '" & token & "'"
        End If
      
        dt = db.getDataTable(str, "driver")
        Return dt
    End Function

    Protected Sub DisplayReport()
        dt = getTsmData()
        dtl1.DataSource = dt
        dtl1.DataBind()


        ' ข้อมูลคนขับรถสำรอง
        Dim dt2 As New DataTable
        Dim db As New DBConnect
        Dim str As String = " SELECT spare_driver.prename , spare_driver.name , spare_driver.surname , spare_driver.passport_no from license " & _
                            " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                            " LEFT JOIN spare_driver on spare_driver.driver_id = spare_driver.driver_id " & _
                            " WHERE license.token = '" & token & "' and license.driver_id = spare_driver.driver_id "
        dt2 = db.getDataTable(str, "spare_driver")


        For Each a In dt2.Rows

            Spare_driver = Spare_driver & "<tr>" & _
                           " <td > " & _
                           " &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<span>ชื่อ: " & a("name") & " </span> " & _
                           " </td> " & _
                           " <td> " & _
                           " &nbsp; <span>นามสกุล: " & a("surname") & " </span>  " & _
                           " </td> " & _
                           " <td> " & _
                           " <span>Passport No: " & a("passport_no") & " </span>  " & _
                           " </td> " & _
                           "  </tr> "

        Next





    End Sub

    'Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
    '    'If Request.QueryString("p") = 1 Then
    '    '    Response.Redirect("CheckRegisterSec.aspx")
    '    'Else
    '    '    Response.Redirect("RegisterSecData.aspx?id=" & Request.QueryString("id"))
    '    'End If

    'End Sub
End Class
