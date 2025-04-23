Imports System.Data
Imports Npgsql

Partial Class ViewData
    Inherits System.Web.UI.Page
    Protected text As String
    Private car_id As Integer
    Private tbIMG_car As New DataTable


    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "
    Protected Css_Ctrl As String = ""
    Private fpathstrIMGCar As String = ConfigurationSettings.AppSettings("FileVehicle")
    Private fpathstrIMGLicense As String = ConfigurationSettings.AppSettings("FileLicenseDriver")
    Private fpathstrIMGPassport As String = ConfigurationSettings.AppSettings("FilePassport")
    Private fpathstrIMGRegistercar As String = ConfigurationSettings.AppSettings("FileRegisterCar")
    Private fpathstrIMGAct As String = ConfigurationSettings.AppSettings("FileAct")
    Private fPathAuthorize As String = ConfigurationSettings.AppSettings("FileAuthorize")




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            If Request.QueryString("rt") = 1 Then
                text = "ขออนุญาตนำรถประจำถิ่นเข้ามาในราชอาณาจักร"
                divCompany.Visible = False

            ElseIf Request.QueryString("rt") = 2 Then
                text = "ขออนุญาตนำรถท่องเที่ยวเข้ามาในราชอาณาจักร"

                'divIMG_act_photo.Visible = False
                'divIMG_authorize_car.Visible = False
                divIMG_car.Visible = False
                'divIMG_license_no.Visible = False
                'divIMG_passport.Visible = False
                'divIMG_regis_photo.Visible = False

            ElseIf Request.QueryString("rt") = 3 Then
                text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถยนต์ส่วนบุคคล ของประเทศลาวเข้ามาในราชอาณาจักร"
                'divCar.Visible = False
                divCompany.Visible = False

            ElseIf Request.QueryString("rt") = 4 Then
                text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถยนต์ส่วนบุคคล ของประเทศมาเลเซีย และสิงคโปร์เข้ามาในราชอาณาจักร"
                divCompany.Visible = False

            ElseIf Request.QueryString("rt") = 5 Then
                text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถขนส่งเชิงพาณิชย์เข้ามาในราชอาณาจักร"
                divCompany.Visible = False

            End If
        End If

        If Request.QueryString("rt") = 5 Then
            LoadData_Type5()
            formT1.Visible = False
        Else
            LoadData()
            formT2.Visible = False
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
            strsql = "SELECT * FROM ( SELECT driver.*, car.*, act.*, license.license_id , token , CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name " & _
                " , CAST(spare_1.prename || ' ' || spare_1.name || ' ' || spare_1.surname as varchar) as spare_1_name , CAST(spare_2.prename || ' ' || spare_2.name || ' ' || spare_2.surname as varchar) as spare_2_name " & _
                " , spare_1.passport_no as spare_1_passport_no, spare_1.passport_expire as spare_1_passport_expire, spare_2.passport_no as spare_2_passport_no, spare_2.passport_expire as spare_2_passport_expire " & _
                " , spare_1.national as spare_1_national, spare_1.license_no as spare_1_license_no, spare_2.national as spare_2_national, spare_2.license_no as spare_2_license_no " & _
                " , type_name as typecar_en, model as models, case when " & IIf(Request.QueryString("rt") = 2, "travel_group.exp_date < now() ", "license.exp_date < now()") & " then 'Expired' else case when license.status_id = 5 then 'Active' when license.status_id = 4 then 'Revoked' else 'Not Active' end end status_en , (select string_agg(prov_en , ', ') from area LEFT JOIN province on area.prov_code = province.prov_code  WHERE license_id = license.license_id) as provarea " '& _

            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " ,name_company as com_name , CAST(user_name || ' ' || user_travel.user_surname as varchar) as agen_name, info_company, history, user_travel.telephone as com_tel, user_travel.email as com_mail, company_license " & _
                " , coalesce(user_travel.address,'')|| ' ตำบล' || t_name_t || ' อำเภอ' || a_name_t || ' จังหวัด' ||p_name_t|| ' ' ||coalesce(postal,'') as com_address "
            End If
            strsql = strsql & " FROM license " & _
             " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
             " LEFT JOIN spare_driver spare_1 on driver.driver_id = spare_1.driver_id and spare_1.spare_ord = 1 " & _
             " LEFT JOIN spare_driver spare_2 on driver.driver_id = spare_2.driver_id and spare_2.spare_ord = 2 " & _
             " LEFT JOIN car on car.car_id = license.car_id " & _
             " LEFT JOIN act on act.act_id = license.act_id " & _
             " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
             " LEFT JOIN status on license.status_id = status.status_id " '& _

            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " LEFT JOIN user_travel on user_travel.user_id = license.travel_id " & _
                " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
                " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                " LEFT JOIN tumbol on tumbol.t_id = user_travel.tumbol "
            End If
            strsql = strsql & " WHERE token = '" & Request.QueryString("token") & "' ) as dt "
            cmd.CommandText = strsql
            Dim dr As NpgsqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then

                If Request.QueryString("rt") = 2 Then
                    If Not dr("com_name") Is DBNull.Value Then
                        lblcom_name.Text = dr("com_name")
                    End If

                    If Not dr("agen_name") Is DBNull.Value Then
                        lblagen_name.Text = dr("agen_name")
                    End If

                    If Not dr("info_company") Is DBNull.Value Then
                        'lblcom_info.Text = dr("info_company")
                    End If

                    If Not dr("status_en") Is DBNull.Value Then
                        lblStatus_en.Text = dr("status_en")
                    End If

                    If Not dr("com_tel") Is DBNull.Value Then
                        lblcom_tel.Text = dr("com_tel")
                    End If

                    If Not dr("com_mail") Is DBNull.Value Then
                        lblcom_mail.Text = dr("com_mail")
                    End If

                    If Not dr("company_license") Is DBNull.Value Then
                        'lblcompany_license.Text = dr("company_license")
                    End If

                    If Not dr("com_address") Is DBNull.Value Then
                        lblcom_address.Text = dr("com_address")
                    End If

                End If

                car_id = dr("car_id")

                If Not dr("idcard_no") Is DBNull.Value Then
                    'lblid_code.Text = dr("idcard_no")
                End If

                If Not dr("countries") Is DBNull.Value Then
                    lblcountry_driver.Text = dr("countries")
                End If

                If Not dr("passport_no") Is DBNull.Value Then
                    'lblpassport.Text = dr("passport_no")
                End If

                If Not dr("passport_expire") Is DBNull.Value Then
                    lblexp_pass_date.Text = Format(dr("passport_expire"), "d MMMM yyyy")
                End If

                If Not dr("driver_name") Is DBNull.Value Then
                    lblname.Text = dr("driver_name")
                End If

                If Not dr("national") Is DBNull.Value Then
                    lblnational.Text = dr("national")
                End If

                If Not dr("birthday") Is DBNull.Value Then
                    'lbldate.Text = Format(dr("birthday"), "d MMMM yyyy")
                End If

                If Not dr("other_information") Is DBNull.Value Then
                    'lblinfo.Text = dr("other_information")
                End If

                If Not dr("gender") Is DBNull.Value Then
                    lblgender.Text = dr("gender")
                End If

                If Not dr("thailicense_no") Is DBNull.Value Then
                    'lbllicense_no.Text = dr("thailicense_no")
                End If

                If Not dr("license_expire") Is DBNull.Value Then
                    lblexp_license_no.Text = Format(dr("license_expire"), "d MMMM yyyy")
                End If

                If Not dr("address") Is DBNull.Value Then
                    'lbladdress_driver.Text = dr("address")
                End If

                If Not dr("tel") Is DBNull.Value Then
                    'lbltel_driver.Text = dr("tel")
                End If

                If Not dr("email") Is DBNull.Value Then
                    lblemail_driver.Text = dr("email")
                End If

                If Not dr("typecar_en") Is DBNull.Value Then
                    lbltypecar.Text = dr("typecar_en")
                End If

                If Not dr("brands") Is DBNull.Value Then
                    lblbrands.Text = dr("brands")
                End If

                If Not dr("models") Is DBNull.Value Then
                    lblmodels.Text = dr("models")
                End If

                If Not dr("spare_1_name") Is DBNull.Value Then
                    lblname1.Text = dr("spare_1_name")
                End If

                If Not dr("spare_1_passport_no") Is DBNull.Value Then
                    'lblpassport1.Text = dr("spare_1_passport_no")
                End If

                If Not dr("spare_1_passport_expire") Is DBNull.Value Then
                    lblexp_pass_date1.Text = Format(dr("spare_1_passport_expire"), "d MMMM yyyy")
                End If

                If Not dr("spare_1_national") Is DBNull.Value Then
                    lblnational1.Text = dr("spare_1_national")
                End If

                If Not dr("spare_1_license_no") Is DBNull.Value Then
                    'lbllicense_no1.Text = dr("spare_1_license_no")
                End If

                If Not dr("spare_2_name") Is DBNull.Value Then
                    lblname2.Text = dr("spare_2_name")
                End If

                If Not dr("spare_2_passport_no") Is DBNull.Value Then
                    'lblpassport2.Text = dr("spare_2_passport_no")
                End If

                If Not dr("spare_2_passport_expire") Is DBNull.Value Then
                    lblexp_pass_date2.Text = Format(dr("spare_2_passport_expire"), "d MMMM yyyy")
                End If

                If Not dr("spare_2_national") Is DBNull.Value Then
                    lblnational2.Text = dr("spare_2_national")
                End If

                If Not dr("spare_2_license_no") Is DBNull.Value Then
                    'lbllicense_no2.Text = dr("spare_2_license_no")
                End If

                If Not dr("plate") Is DBNull.Value Then
                    lblplate.Text = dr("plate")
                End If

                If Not dr("seat") Is DBNull.Value Then
                    lblSeats.Text = dr("seat")
                End If

                If Not dr("weight") Is DBNull.Value Then
                    'lblweight.Text = Format(dr("weight"), "#,###.##")
                    lblweight.Text = dr("weight")
                End If

                'If Not dr("year") Is DBNull.Value Then
                '    lblyears.Text = dr("year")
                'End If

                If Not dr("colors") Is DBNull.Value Then
                    lblcolors.Text = dr("colors")
                End If

                If Not dr("provarea") Is DBNull.Value Then
                    lblprovarea.Text = dr("provarea")
                End If

                If Not dr("engine_no") Is DBNull.Value Then
                    'lblNumEngine.Text = dr("engine_no")
                End If

                If Not dr("car_no") Is DBNull.Value Then
                    'lblnumcar.Text = dr("car_no")
                End If

                If Not dr("passportcar_no") Is DBNull.Value Then
                    'lblpass_car.Text = dr("passportcar_no")
                End If

                'If Not dr("passportcar_expire") Is DBNull.Value Then
                '    lblexp_pass_car_date.Text = Format(dr("passportcar_expire"), "d MMMM yyyy")
                'End If

                If Not dr("owner_name") Is DBNull.Value Then
                    lblowner.Text = dr("owner_name")
                End If

                If Not dr("owner_idcard") Is DBNull.Value Then
                    'lblowner_id_card.Text = dr("owner_idcard")
                End If

                If Not dr("owner_address") Is DBNull.Value Then
                    'lbladdress_owner.Text = dr("owner_address")
                End If

                If Not dr("owner_tel") Is DBNull.Value Then
                    'lbltel_owner.Text = dr("owner_tel")
                End If

                'If Not dr("holder_name") Is DBNull.Value Then
                '    lblholder.Text = dr("holder_name")
                'End If

                If Not dr("holder_idcard") Is DBNull.Value Then
                    'lblholder_id_card.Text = dr("holder_idcard")
                End If

                If Not dr("holder_address") Is DBNull.Value Then
                    'lbladdress_holder.Text = dr("holder_address")
                End If

                If Not dr("holder_tel") Is DBNull.Value Then
                    'lbltel_holder.Text = dr("holder_tel")
                End If

                If Not dr("act_no") Is DBNull.Value Then
                    'lblinsure_no.Text = dr("act_no")
                End If

                If Not dr("act_name") Is DBNull.Value Then
                    'lblinsure_name.Text = dr("act_name")
                End If

                If Not dr("act_tankno") Is DBNull.Value Then
                    'lblcar_no.Text = dr("act_tankno")
                End If

                If Not dr("act_company") Is DBNull.Value Then
                    lblcompany.Text = dr("act_company")
                End If

                If Not dr("act_start") Is DBNull.Value Then
                    lblstart_date.Text = Format(dr("act_start"), "d MMMM yyyy")
                End If

                If Not dr("act_ends") Is DBNull.Value Then
                    lblend_date.Text = Format(dr("act_ends"), "d MMMM yyyy")
                End If

                If Not dr("act_company2") Is DBNull.Value Then
                    lblcompany2.Text = dr("act_company2")
                End If

                If Not dr("act_start2") Is DBNull.Value Then
                    lblstart_date2.Text = Format(dr("act_start"), "d MMMM yyyy")
                End If

                If Not dr("act_ends2") Is DBNull.Value Then
                    lblend_date2.Text = Format(dr("act_ends2"), "d MMMM yyyy")
                End If

                'If Not dr("licensedriver_photo") Is DBNull.Value Then
                '    imageFilelicense_no.ImageUrl = fpathstrIMGLicense & dr("licensedriver_photo")
                '    Hyperlicense_no.NavigateUrl = "../ViewImage.aspx?fpath=FileLicenseDriver&ImageType=" & dr("licensedriver_photo")
                'Else
                '    imageFilelicense_no.Visible = False
                '    Hyperlicense_no.Visible = False
                'End If

                'If Not dr("passport_photo") Is DBNull.Value Then
                '    imageFilepassport.ImageUrl = fpathstrIMGPassport & dr("passport_photo")
                '    Hyperpassport.NavigateUrl = "../ViewImage.aspx?fpath=FilePassport&ImageType=" & dr("passport_photo")
                'Else
                '    imageFilepassport.Visible = False
                '    Hyperpassport.Visible = False
                'End If

                'If Not dr("authorize_car") Is DBNull.Value Then
                '    imageFileauthorize_car.ImageUrl = fPathAuthorize & dr("authorize_car")
                '    Hyperauthorize_car.NavigateUrl = "../ViewImage.aspx?fpath=FileAuthorize&ImageType=" & dr("authorize_car")
                'Else
                '    imageFileauthorize_car.Visible = False
                '    Hyperauthorize_car.Visible = False
                'End If

                'If Not dr("regis_photo") Is DBNull.Value Then
                '    imageFileregis_photo.ImageUrl = fpathstrIMGRegistercar & dr("regis_photo")
                '    Hyperregis_photo.NavigateUrl = "../ViewImage.aspx?fpath=FileRegisterCar&ImageType=" & dr("regis_photo")
                'Else
                '    imageFileregis_photo.Visible = False
                '    Hyperregis_photo.Visible = False
                'End If

                'If Not dr("act_photo") Is DBNull.Value Then
                '    imageFileact_photo.ImageUrl = fpathstrIMGAct & dr("act_photo")
                '    Hyperact_photo.NavigateUrl = "../ViewImage.aspx?fpath=FileAct&ImageType=" & dr("act_photo")
                'Else
                '    imageFileact_photo.Visible = False
                '    Hyperact_photo.Visible = False
                'End If
            End If
            dr.Close()

            Dim dbConnect As New DBConnect

            'รูปถ่ายรถ
            strsql = "select gid , file_name from car_pic where car_id = " & car_id
            Dim DataTableimg As DataTable = dbConnect.getDataTable(strsql, "car_pic")
            With DataTableimg.Columns
                .Add(New DataColumn("PathImg"))
                .Add(New DataColumn("LinkImg"))
            End With
            For Each nrow As DataRow In DataTableimg.Rows
                nrow("PathImg") = fpathstrIMGCar & nrow("file_name")
                nrow("LinkImg") = "../ViewImage.aspx?fpath=FileVehicle&ImageType=" & nrow("file_name")
            Next
            If DataTableimg.Rows.Count > 0 Then

                DtlImg_car.DataSource = DataTableimg
                DtlImg_car.DataBind()
            End If



        Catch ex As Exception
            Dim ppScript As String = " alert('เกิดข้อผิดพลาด:: " & ex.Message & " ไม่สามารถเรียกข้อมูลแผนงานได้'); "
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", ppScript, True)
        Finally
            cmd.Connection.Close()
            con = Nothing
        End Try

    End Sub

    Private Sub LoadData_Type5()
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
                If Not dr("permit_no") Is DBNull.Value Then
                    'lblpermit_no.Text = dr("permit_no")
                End If

                If Not dr("issue_date") Is DBNull.Value Then
                    lblissue_date.Text = dr("issue_date")
                End If

                If Not dr("issue_place") Is DBNull.Value Then
                    lblissue_place.Text = dr("issue_place")
                End If

                If Not dr("expiry_date") Is DBNull.Value Then
                    lblexpiry_date.Text = dr("expiry_date")
                End If

                If Not dr("extended_until") Is DBNull.Value Then
                    lblextended_until.Text = dr("extended_until")
                End If

                If Not dr("issuing_authority") Is DBNull.Value Then
                    lblissuing_authority.Text = dr("issuing_authority")
                End If

                If Not dr("tad_no") Is DBNull.Value Then
                    lbltad_no.Text = dr("tad_no")
                End If

                If Not dr("transport_operator_name") Is DBNull.Value Then
                    lbltransport_operator_name.Text = dr("transport_operator_name")
                End If

                If Not dr("address") Is DBNull.Value Then
                    lbladdress.Text = dr("address")
                End If

                If Not dr("province") Is DBNull.Value Then
                    lblprovince.Text = dr("province")
                End If

                If Not dr("telephone") Is DBNull.Value Then
                    'lbltelephone.Text = dr("telephone")
                End If

                If Not dr("email") Is DBNull.Value Then
                    'lblemail.Text = dr("email")
                End If

                If Not dr("vehicle_owner_name") Is DBNull.Value Then
                    lblvehicle_owner_name.Text = dr("vehicle_owner_name")
                End If

                If Not dr("vehicle_owner_address") Is DBNull.Value Then
                    lblvehicle_owner_address.Text = dr("vehicle_owner_address")
                End If

                If Not dr("vehicle_owner_province") Is DBNull.Value Then
                    lblvehicle_owner_province.Text = dr("vehicle_owner_province")
                End If

                If Not dr("vehicle_owner_telephone") Is DBNull.Value Then
                    lblvehicle_owner_telephone.Text = dr("vehicle_owner_telephone")
                End If

                If Not dr("vehicle_owner_email") Is DBNull.Value Then
                    lblvehicle_owner_email.Text = dr("vehicle_owner_email")
                End If

                If Not dr("vehicle_type") Is DBNull.Value Then
                    lblvehicle_type.Text = dr("vehicle_type")
                End If

                If Not dr("registration_no") Is DBNull.Value Then
                    lblregistration_no.Text = dr("registration_no")
                End If

                If Not dr("vehicle_category") Is DBNull.Value Then
                    lblvehicle_category.Text = dr("vehicle_category")
                End If

                If Not dr("regis_date") Is DBNull.Value Then
                    'lblregis_date.Text = dr("regis_date")
                    lblregis_date.Text = ConvertDateFormat(dr("regis_date"))
                End If

                If Not dr("regis_province") Is DBNull.Value Then
                    lblregis_province.Text = dr("regis_province")
                End If

                If Not dr("semi_trailer") Is DBNull.Value Then
                    lblsemi_trailer.Text = dr("semi_trailer")
                End If

                If Not dr("brand") Is DBNull.Value Then
                    lblbrand.Text = dr("brand")
                End If

                If Not dr("model") Is DBNull.Value Then
                    lblmodel.Text = dr("model")
                End If

                If Not dr("vin_no") Is DBNull.Value Then
                    'lblvin_no.Text = dr("vin_no")
                End If

                If Not dr("engine_no") Is DBNull.Value Then
                    'lblengine_no.Text = dr("engine_no")
                End If

                If Not dr("axles_no") Is DBNull.Value Then
                    lblaxles_no.Text = dr("axles_no")
                End If

                If Not dr("colour") Is DBNull.Value Then
                    lblcolour.Text = dr("colour")
                End If

                If Not dr("capacity_cc") Is DBNull.Value Then
                    lblcapacity_cc.Text = Format(dr("capacity_cc"), "#,###.##")
                End If

                If Not dr("weight_gross") Is DBNull.Value Then
                    lblweight_gross.Text = Format(dr("weight_gross"), "#,###.##")
                End If

                If Not dr("weight_net") Is DBNull.Value Then
                    lblweight_net.Text = Format(dr("weight_net"), "#,###.##")
                End If

                If Not dr("seats_no") Is DBNull.Value Then
                    lblseats_no.Text = Format(dr("seats_no"), "#,###.##")
                End If

                If Not dr("width") Is DBNull.Value Then
                    lblwidth.Text = Format(dr("width"), "#,###.##")
                End If

                If Not dr("length") Is DBNull.Value Then
                    lbllength.Text = Format(dr("length"), "#,###.##")
                End If

                If Not dr("height") Is DBNull.Value Then
                    lblheight.Text = Format(dr("height"), "#,###.##")
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
