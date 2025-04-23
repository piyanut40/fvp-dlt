Imports Npgsql
Imports System.Data
Imports System.IO
Partial Class QR_CODE
    Inherits System.Web.UI.Page
    Protected check_in As String
    Protected start_date As String
    Protected end_date As String
    Protected name_driver As String
    Protected type_car As String
    Protected brands As String
    Protected model As String
    Protected color As String
    Protected area As String
    Protected car_Regis As String
    Protected license_car As String
    Protected qrcode As String
    Protected license As String
    Protected carid As String
    Protected PathImg As String = "~/Upload/Vehicle/"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim token = Request.QueryString("token")
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader

        Dim str As String = " select name_driver, surname , address , state , city , telephone, id_card , email , postal, start_date , exp_date , license.car_id , " & _
                            " (select  en_short_name from countries WHERE num_code = country) as country , " & _
                            " (select  nationality from countries WHERE num_code = nation) as nation , " & _
                            " register_no , token , urlqrcode , license_no , CAST(brands as varchar) as brandcar_en , type_name as typecar_en , model , colors , seats , " & _
                            " number_car, number_engine, license_car, cylinder_cap , " & _
                            " (select en_short_name from countries WHERE num_code = regis_country) as regis_country , " & _
                            " weight, weight_carry , " & _
                            " (select border_nameth from border_check WHERE border_id = checkin_id) as check_in , " & _
                            " (select border_nameth from border_check WHERE border_id = checkout_id) as check_out , " & _
                            " (SELECT string_agg(prov_en ,',' ) from area LEFT JOIN province on area.prov_code = province.prov_code WHERE license_id = license.license_id) as area " & _
                            " , nature from license " & _
                            " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                            " LEFT JOIN car on car.car_id = license.car_id " & _
                            " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
                            " WHERE token = '" & Request.QueryString("token") & "' and status_id = 1"
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            cmd.CommandText = str
            dread = cmd.ExecuteReader()
            If dread.Read Then
                If dread("license_no") IsNot DBNull.Value Then
                    license = dread("license_no")
                End If
                If dread("check_in") IsNot DBNull.Value Then
                    check_in = dread("check_in")
                End If

                If dread("start_date") IsNot DBNull.Value Then
                    start_date = dread("start_date")
                End If

                If dread("exp_date") IsNot DBNull.Value Then
                    end_date = dread("exp_date")
                End If

                If dread("name_driver") IsNot DBNull.Value Then
                    name_driver = dread("name_driver")
                End If

                If dread("surname") IsNot DBNull.Value Then
                    name_driver = name_driver & " " & dread("surname")
                End If

                If dread("typecar_en") IsNot DBNull.Value Then
                    type_car = dread("typecar_en")
                End If

                If dread("brandcar_en") IsNot DBNull.Value Then
                    brands = dread("brandcar_en")
                End If

                If dread("model") IsNot DBNull.Value Then
                    model = dread("model")
                End If

                If dread("colors") IsNot DBNull.Value Then
                    color = dread("colors")
                End If

                If dread("area") IsNot DBNull.Value Then
                    area = dread("area")
                End If

                If dread("regis_country") IsNot DBNull.Value Then
                    car_Regis = dread("regis_country")
                End If

                If dread("license_car") IsNot DBNull.Value Then
                    license_car = dread("license_car")
                End If

                If dread("urlqrcode") IsNot DBNull.Value Then
                    qrcodeImg.ImageUrl = dread("urlqrcode")
                End If

                If dread("car_id") IsNot DBNull.Value Then
                    carid = dread("car_id")
                End If
            End If
            dread.Close()

            cmd.CommandText = "SELECT file_name from car_pic WHERE car_id = '" & carid & "' limit 1"
            PathImg = PathImg & cmd.ExecuteScalar

            Imgcar.ImageUrl = PathImg

        Catch ex As Exception

        End Try
        cmd.Dispose()
        con.Close()

    End Sub
End Class
