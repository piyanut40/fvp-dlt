Imports System.Data
Imports Npgsql
Partial Class RegisterCommerce
    Inherits System.Web.UI.Page
    Protected text As String
    Protected textMgt As String
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected Css As String = " w3-padding-top w3-padding-left "
    Protected Css2 As String = " w3-padding-top w3-right "
    Protected Css_Ctrl As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            Populate.genDDLCountry(ddlCountryCar, False)
        End If

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
       
            strCommand = " INSERT INTO car_commerce( _language, permit_no, issue_date, issue_place, expiry_date, extended_until, issuing_authority, tad_no, transport_operator_name, " & _
                " address, province, telephone, email, vehicle_owner_name, vehicle_owner_address, vehicle_owner_province, vehicle_owner_telephone, vehicle_owner_email, " & _
                " vehicle_type, registration_no, vehicle_category, regis_date, regis_province, brand, model, vin_no, engine_no, axles_no, colour, " & _
                " capacity_cc, weight_gross, weight_net, seats_no, width, length, height, import_date, semi_trailer , country_car) " & _
                        " VALUES( 'English', :permit_no, :issue_date, :issue_place, :expiry_date, :extended_until, :issuing_authority, :tad_no, :transport_operator_name, " & _
                " :address, :province, :telephone, :email, :vehicle_owner_name, :vehicle_owner_address, :vehicle_owner_province, :vehicle_owner_telephone, :vehicle_owner_email, " & _
                " :vehicle_type, :registration_no, :vehicle_category, :regis_date, :regis_province, :brand, :model, :vin_no, :engine_no, :axles_no, :colour, " & _
                " :capacity_cc, :weight_gross, :weight_net, :seats_no, :width, :length, :height, now(), :semi_trailer , :country_car) RETURNING car_id;"
            'End If

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
            cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtregis_date.Text.Trim = "", Nothing, txtregis_date.Text)
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
                cmd.CommandText = "INSERT INTO license ( car_id , typeuser_id , status_id, regis_date  ) VALUES ( " & hidcar_id.Value & "  , 5 , 6 , :regis_date ) RETURNING license_id;"
                cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtregis_date.Text.Trim = "", Nothing, txtregis_date.Text)
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
                cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtregis_date.Text.Trim = "", Nothing, txtregis_date.Text)
                cmd.ExecuteNonQuery()
            End If

            transaction.Commit()
            Response.Redirect("RegisterComplete.aspx")
        Catch ex As Exception
            Dim scriptError As String = "<script> alert('Information incorrect , Please Try again  !!!');</script>"
            Response.Write(ex)
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", scriptError, False)
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
                Dim dateS = DateTime.ParseExact(pDate, "MM/dd/yyyy", Nothing)
                Dim arr_tmp As Array = Format(CDate(dateS), "yyyy-MMMM-d").ToString.Split("-")
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
