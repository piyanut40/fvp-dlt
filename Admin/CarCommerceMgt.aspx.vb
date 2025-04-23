Imports System.Data
Imports Npgsql
Partial Class Admin_CarCommerceMgt
    Inherits System.Web.UI.Page
    Protected text As String
    Protected textMgt As String
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "
    Protected Css_Ctrl As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Populate.genDDLCountry(ddlCountryCar, False)
            If Session("user_id") = Nothing Then
                Response.Redirect("../Login.aspx")
            Else
                text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถขนส่งเชิงพาณิชย์เข้ามาในราชอาณาจักร"
                textMgt = "เพิ่ม"
                If Not Request.QueryString("token") Is Nothing Then
                    LoadData()
                    textMgt = "แก้ไข"
                End If

            End If
            If PopulateS.IsMobile Then
                Css = "w3-padding w3-padding-left0"
                Css_Ctrl = " w3-padding w3-padding-left32 w3-purple3 w3-round-large "
            End If
        End If

    End Sub

    Private Sub LoadData()
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim strsql As String = ""
        Try
            con.ClearPool()
            cmd.Connection = con
            cmd.Connection.Open()
            strsql = "SELECT * FROM ( SELECT license.*, car_commerce.* " & _
                " FROM license " & _
                " LEFT JOIN car_commerce on car_commerce.car_id = license.car_id " & _
                " WHERE token = '" & Request.QueryString("token") & "' ) as dt "
            cmd.CommandText = strsql
            Dim dr As NpgsqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                hidlicense_id.Value = dr("license_id")

                If Not dr("permit_no") Is DBNull.Value Then
                    txtpermit_no.Text = dr("permit_no")
                End If

                If Not dr("car_id") Is DBNull.Value Then
                    hidcar_id.Value = dr("car_id")
                End If

                If Not dr("issue_date") Is DBNull.Value Then
                    txtissue_date.Text = dr("issue_date")
                    txtissue_date.Text = Format(CDate(txtissue_date.Text), "MM/dd/yyyy")

                End If

                If Not dr("issue_place") Is DBNull.Value Then
                    txtissue_place.Text = dr("issue_place")
                End If

                If Not dr("expiry_date") Is DBNull.Value Then
                    txtexpiry_date.Text = dr("expiry_date")
                    txtexpiry_date.Text = Format(CDate(txtexpiry_date.Text), "MM/dd/yyyy")

                End If

                If Not dr("extended_until") Is DBNull.Value Then
                    txtextended_until.Text = dr("extended_until")
                    txtextended_until.Text = Format(CDate(txtextended_until.Text), "MM/dd/yyyy")
                End If

                If Not dr("issuing_authority") Is DBNull.Value Then
                    txtissuing_authority.Text = dr("issuing_authority")
                End If

                If Not dr("tad_no") Is DBNull.Value Then
                    txttad_no.Text = dr("tad_no")
                End If

                If Not dr("transport_operator_name") Is DBNull.Value Then
                    txttransport_operator_name.Text = dr("transport_operator_name")
                End If

                If Not dr("address") Is DBNull.Value Then
                    txtaddress.Text = dr("address")
                End If

                If Not dr("province") Is DBNull.Value Then
                    txtprovince.Text = dr("province")
                End If

                If Not dr("telephone") Is DBNull.Value Then
                    txttelephone.Text = dr("telephone")
                End If

                If Not dr("email") Is DBNull.Value Then
                    txtemail.Text = dr("email")
                End If

                If Not dr("vehicle_owner_name") Is DBNull.Value Then
                    txtvehicle_owner_name.Text = dr("vehicle_owner_name")
                End If

                If Not dr("vehicle_owner_address") Is DBNull.Value Then
                    txtvehicle_owner_address.Text = dr("vehicle_owner_address")
                End If

                If Not dr("vehicle_owner_province") Is DBNull.Value Then
                    txtvehicle_owner_province.Text = dr("vehicle_owner_province")
                End If

                If Not dr("vehicle_owner_telephone") Is DBNull.Value Then
                    txtvehicle_owner_telephone.Text = dr("vehicle_owner_telephone")
                End If

                If Not dr("vehicle_owner_email") Is DBNull.Value Then
                    txtvehicle_owner_email.Text = dr("vehicle_owner_email")
                End If

                If Not dr("vehicle_type") Is DBNull.Value Then
                    txtvehicle_type.Text = dr("vehicle_type")
                End If

                If Not dr("registration_no") Is DBNull.Value Then
                    txtregistration_no.Text = dr("registration_no")
                End If

                If Not dr("vehicle_category") Is DBNull.Value Then
                    txtvehicle_category.Text = dr("vehicle_category")
                End If

                If Not dr("regis_date") Is DBNull.Value Then
                    txtregis_date.Text = dr("regis_date")
                    txtregis_date.Text = Format(CDate(txtregis_date.Text), "MM/dd/yyyy")
                End If

                If Not dr("regis_province") Is DBNull.Value Then
                    txtregis_province.Text = dr("regis_province")
                End If

                If Not dr("semi_trailer") Is DBNull.Value Then
                    txtsemi_trailer.Text = dr("semi_trailer")
                End If

                If Not dr("brand") Is DBNull.Value Then
                    txtbrand.Text = dr("brand")
                End If

                If Not dr("model") Is DBNull.Value Then
                    txtmodel.Text = dr("model")
                End If

                If Not dr("vin_no") Is DBNull.Value Then
                    txtvin_no.Text = dr("vin_no")
                End If

                If Not dr("engine_no") Is DBNull.Value Then
                    txtengine_no.Text = dr("engine_no")
                End If

                If Not dr("axles_no") Is DBNull.Value Then
                    txtaxles_no.Text = dr("axles_no")
                End If

                If Not dr("colour") Is DBNull.Value Then
                    txtcolour.Text = dr("colour")
                End If

                If Not dr("capacity_cc") Is DBNull.Value Then
                    txtcapacity_cc.Text = Format(dr("capacity_cc"), "#,###.##")
                End If

                If Not dr("weight_gross") Is DBNull.Value Then
                    txtweight_gross.Text = Format(dr("weight_gross"), "#,###.##")
                End If

                If Not dr("weight_net") Is DBNull.Value Then
                    txtweight_net.Text = Format(dr("weight_net"), "#,###.##")
                End If

                If Not dr("seats_no") Is DBNull.Value Then
                    txtseats_no.Text = Format(dr("seats_no"), "#,###.##")
                End If

                If Not dr("width") Is DBNull.Value Then
                    txtwidth.Text = Format(dr("width"), "#,###.##")
                End If

                If Not dr("length") Is DBNull.Value Then
                    txtlength.Text = Format(dr("length"), "#,###.##")
                End If

                If Not dr("height") Is DBNull.Value Then
                    txtheight.Text = Format(dr("height"), "#,###.##")
                End If

                If Not dr("country_car") Is DBNull.Value Then
                    ddlCountryCar.SelectedValue = dr("country_car")
                End If

            End If
            dr.Close()

        Catch ex As Exception
            Dim ppScript As String = " alert('เกิดข้อผิดพลาด:: " & ex.Message & " ไม่สามารถเรียกข้อมูลแผนงานได้'); "
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", ppScript, True)
        Finally
            cmd.Connection.Close()
            con = Nothing
        End Try

    End Sub

    Protected Sub lnkSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSubmit.Click

        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim strError As String = ""
        Dim transaction As NpgsqlTransaction
        Try
            con.Open()
            transaction = con.BeginTransaction()
            cmd.Connection = con

            Dim strCommand As String = ""
            If Not Request.QueryString("token") Is Nothing Then
                strCommand = "update car_commerce set permit_no = :permit_no, issue_date = :issue_date, issue_place = :issue_place, expiry_date = :expiry_date, extended_until = :extended_until " & _
                    " , issuing_authority = :issuing_authority, tad_no = :tad_no, transport_operator_name = :transport_operator_name, address = :address, province = :province, telephone = :telephone " & _
                    " , email = :email, vehicle_owner_name = :vehicle_owner_name, vehicle_owner_address = :vehicle_owner_address, vehicle_owner_province = :vehicle_owner_province " & _
                    " , vehicle_owner_telephone = :vehicle_owner_telephone, vehicle_owner_email = :vehicle_owner_email, vehicle_type = :vehicle_type, registration_no = :registration_no " & _
                    " , vehicle_category = :vehicle_category, regis_date = :regis_date, regis_province = :regis_province, brand = :brand, model = :model, vin_no = :vin_no, engine_no = :engine_no " & _
                    " , axles_no = :axles_no, colour = :colour, capacity_cc = :capacity_cc, weight_gross = :weight_gross, weight_net = :weight_net, seats_no = :seats_no, width = :width, length = :length " & _
                    " , height = :height, semi_trailer = :semi_trailer , country_car = :country_car where car_id = " & hidcar_id.Value
            Else
                strCommand = " INSERT INTO car_commerce( _language, permit_no, issue_date, issue_place, expiry_date, extended_until, issuing_authority, tad_no, transport_operator_name, " & _
                    " address, province, telephone, email, vehicle_owner_name, vehicle_owner_address, vehicle_owner_province, vehicle_owner_telephone, vehicle_owner_email, " & _
                    " vehicle_type, registration_no, vehicle_category, regis_date, regis_province, brand, model, vin_no, engine_no, axles_no, colour, " & _
                    " capacity_cc, weight_gross, weight_net, seats_no, width, length, height, import_date, semi_trailer , country_car) " & _
                            " VALUES( 'English', :permit_no, :issue_date, :issue_place, :expiry_date, :extended_until, :issuing_authority, :tad_no, :transport_operator_name, " & _
                    " :address, :province, :telephone, :email, :vehicle_owner_name, :vehicle_owner_address, :vehicle_owner_province, :vehicle_owner_telephone, :vehicle_owner_email, " & _
                    " :vehicle_type, :registration_no, :vehicle_category, :regis_date, :regis_province, :brand, :model, :vin_no, :engine_no, :axles_no, :colour, " & _
                    " :capacity_cc, :weight_gross, :weight_net, :seats_no, :width, :length, :height, now(), :semi_trailer , :country_car) RETURNING car_id;"
            End If
    
            cmd.CommandText = strCommand
            cmd.Parameters.Clear()
            cmd.Parameters.Add("permit_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtpermit_no.Text.Trim = "", Nothing, txtpermit_no.Text)
            cmd.Parameters.Add("issue_date", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ConvertDateFormat(txtissue_date.Text)
            cmd.Parameters.Add("issue_place", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtissue_place.Text.Trim = "", Nothing, txtissue_place.Text)
            cmd.Parameters.Add("expiry_date", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ConvertDateFormat(txtexpiry_date.Text)
            cmd.Parameters.Add("extended_until", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ConvertDateFormat(txtextended_until.Text)
            cmd.Parameters.Add("issuing_authority", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtissuing_authority.Text.Trim = "", Nothing, txtissuing_authority.Text)
            cmd.Parameters.Add("tad_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txttad_no.Text.Trim = "", Nothing, txttad_no.Text)
            cmd.Parameters.Add("transport_operator_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txttransport_operator_name.Text.Trim = "", Nothing, txttransport_operator_name.Text)
            cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtaddress.Text.Trim = "", Nothing, txtaddress.Text)
            cmd.Parameters.Add("province", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtprovince.Text.Trim = "", Nothing, txtprovince.Text)
            cmd.Parameters.Add("telephone", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txttelephone.Text.Trim = "", Nothing, txttelephone.Text)
            cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtemail.Text.Trim = "", Nothing, txtemail.Text)
            cmd.Parameters.Add("vehicle_owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtvehicle_owner_name.Text.Trim = "", Nothing, txtvehicle_owner_name.Text)
            cmd.Parameters.Add("vehicle_owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtvehicle_owner_address.Text.Trim = "", Nothing, txtvehicle_owner_address.Text)
            cmd.Parameters.Add("vehicle_owner_province", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtvehicle_owner_province.Text.Trim = "", Nothing, txtvehicle_owner_province.Text)
            cmd.Parameters.Add("vehicle_owner_telephone", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtvehicle_owner_telephone.Text.Trim = "", Nothing, txtvehicle_owner_telephone.Text)
            cmd.Parameters.Add("vehicle_owner_email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtvehicle_owner_email.Text.Trim = "", Nothing, txtvehicle_owner_email.Text)
            cmd.Parameters.Add("vehicle_type", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtvehicle_type.Text.Trim = "", Nothing, txtvehicle_type.Text)
            cmd.Parameters.Add("registration_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtregistration_no.Text.Trim = "", Nothing, txtregistration_no.Text)
            cmd.Parameters.Add("vehicle_category", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtvehicle_category.Text.Trim = "", Nothing, txtvehicle_category.Text)
            cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtregis_date.Text.Trim = "", Nothing, CDate(txtregis_date.Text))
            cmd.Parameters.Add("regis_province", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtregis_province.Text.Trim = "", Nothing, txtregis_province.Text)
            cmd.Parameters.Add("brand", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtbrand.Text.Trim = "", Nothing, txtbrand.Text)
            cmd.Parameters.Add("model", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtmodel.Text.Trim = "", Nothing, txtmodel.Text)
            cmd.Parameters.Add("vin_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtvin_no.Text.Trim = "", Nothing, txtvin_no.Text)
            cmd.Parameters.Add("engine_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtengine_no.Text.Trim = "", Nothing, txtengine_no.Text)
            cmd.Parameters.Add("axles_no", NpgsqlTypes.NpgsqlDbType.Integer).Value = IIf(txtaxles_no.Text.Trim = "", Nothing, txtaxles_no.Text)
            cmd.Parameters.Add("colour", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcolour.Text.Trim = "", Nothing, txtcolour.Text)
            cmd.Parameters.Add("capacity_cc", NpgsqlTypes.NpgsqlDbType.Double).Value = IIf(txtcapacity_cc.Text.Trim = "", Nothing, txtcapacity_cc.Text.Replace(",", ""))
            cmd.Parameters.Add("weight_gross", NpgsqlTypes.NpgsqlDbType.Double).Value = IIf(txtweight_gross.Text.Trim = "", Nothing, txtweight_gross.Text.Replace(",", ""))
            cmd.Parameters.Add("weight_net", NpgsqlTypes.NpgsqlDbType.Double).Value = IIf(txtweight_net.Text.Trim = "", Nothing, txtweight_net.Text.Replace(",", ""))
            cmd.Parameters.Add("seats_no", NpgsqlTypes.NpgsqlDbType.Double).Value = IIf(txtseats_no.Text.Trim = "", Nothing, txtseats_no.Text.Replace(",", ""))
            cmd.Parameters.Add("width", NpgsqlTypes.NpgsqlDbType.Double).Value = IIf(txtwidth.Text.Trim = "", Nothing, txtwidth.Text.Replace(",", ""))
            cmd.Parameters.Add("length", NpgsqlTypes.NpgsqlDbType.Double).Value = IIf(txtlength.Text.Trim = "", Nothing, txtlength.Text.Replace(",", ""))
            cmd.Parameters.Add("height", NpgsqlTypes.NpgsqlDbType.Double).Value = IIf(txtheight.Text.Trim = "", Nothing, txtheight.Text.Replace(",", ""))
            cmd.Parameters.Add("semi_trailer", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtsemi_trailer.Text.Trim = "", Nothing, txtsemi_trailer.Text)
            cmd.Parameters.Add("country_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountryCar.SelectedValue
            If Request.QueryString("token") Is Nothing Then
                cmd.Parameters.Add("car_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
            End If
            cmd.ExecuteNonQuery()

            If Request.QueryString("token") Is Nothing Then
                hidcar_id.Value = cmd.Parameters("car_id").Value.ToString

                cmd.Parameters.Clear()
                cmd.CommandText = "INSERT INTO license ( car_id , typeuser_id , status_id, regis_date  ) VALUES ( " & hidcar_id.Value & "  , 5 , 0 , :regis_date ) RETURNING license_id;"
                cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtregis_date.Text.Trim = "", Nothing, CDate(txtregis_date.Text))
                cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()

                hidlicense_id.Value = cmd.Parameters("license_id").Value.ToString

                cmd.Parameters.Clear()
                Dim token As String = dbConnect.Token(hidlicense_id.Value, hidcar_id.Value)
                Dim qrcode As String = dbConnect.qrcode(token, "5")

                cmd.Parameters.Clear()
                cmd.CommandText = " UPDATE license SET token = '" & token & "' , qrcode = '" & qrcode & "' where license_id = " & hidlicense_id.Value
                cmd.ExecuteNonQuery()

                cmd.CommandText = " INSERT INTO area ( prov_code, license_id)  VALUES (0 , " & hidlicense_id.Value & " ) "
                cmd.ExecuteNonQuery()
            Else
                cmd.Parameters.Clear()
                cmd.CommandText = " UPDATE license SET regis_date = :regis_date where license_id = " & hidlicense_id.Value
                cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtregis_date.Text.Trim = "", Nothing, CDate(txtregis_date.Text))
                cmd.ExecuteNonQuery()
            End If

            transaction.Commit()
            Response.Redirect("index.aspx?rt=5")
        Catch ex As Exception
            Dim scriptError As String = "alert ('เกิดข้อผิดพลาด:: " & ex.Message & " ไม่สามารถบันทึกข้อมูลได้');"
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScriptAddHideProgress", scriptError, True)
        Finally
            cmd.Connection.Close()
            con.Close()
        End Try
        'End If



    End Sub

    Protected Sub lnkBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBack.Click
        Response.Redirect("index.aspx?rt=5")
    End Sub

    Private Function ConvertDateFormat(ByVal pDate As String) As String
        Dim _date As String = ""
        If pDate.Trim <> "" Then
            Try
                Dim arr_tmp As Array = Format(CDate(pDate), "yyyy-MMMM-d").ToString.Split("-")
                _date = arr_tmp(1) & " " & arr_tmp(2)
                Select Case arr_tmp(2)
                    Case 1, 21, 31
                        _date = _date & " st , "
                    Case 2, 22
                        _date = _date & " nd , "
                    Case 3, 23
                        _date = _date & " rd , "
                    Case Else
                        _date = _date & " th , "
                End Select
                _date = _date & arr_tmp(0)
            Catch ex As Exception
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
        Return _date
    End Function
End Class
