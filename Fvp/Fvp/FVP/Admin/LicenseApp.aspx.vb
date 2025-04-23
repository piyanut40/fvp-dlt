Imports System.Data
Imports Npgsql
Imports System.IO

Partial Class Admin_LicenseApp
    Inherits System.Web.UI.Page
    Protected text As String
    Private car_id As Integer
    Private tbIMG_car As New DataTable



    Private fpathstrIMGCar As String = ConfigurationSettings.AppSettings("FileVehicle")
    Private fpathstrIMGLicense As String = ConfigurationSettings.AppSettings("FileLicenseDriver")
    Private fpathstrIMGPassport As String = ConfigurationSettings.AppSettings("FilePassport")
    Private fpathstrIMGRegistercar As String = ConfigurationSettings.AppSettings("FileRegisterCar")
    Private fpathstrIMGAct As String = ConfigurationSettings.AppSettings("FileAct")
    Private fPathAuthorize As String = ConfigurationSettings.AppSettings("FileAuthorize")
    Protected Css As String = "fontKanit w3-medium w3-padding-top w3-padding-right w3-right-align "
    Protected CSSY As String = "w3-button w3-large w3-green w3-padding w3-round fontKanit w3-medium"
    Protected CSSN As String = "w3-button w3-large w3-red w3-padding w3-round fontKanit w3-medium"
    Protected CSSbutton As String = "w3-button w3-large w3-purple2 w3-padding w3-round fontKanit w3-medium"
    Protected Css_Ctrl As String = ""
    Private PopulateS As New PopulateScript

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            If Session("user_id") = Nothing Then
                Response.Redirect("../Login.aspx")
            Else
                If Request.QueryString("rt") = 1 Then
                    text = "ขออนุญาตนำรถประจำถิ่นเข้ามาในราชอาณาจักร"
                    divCompany.Visible = False
                    div_map.Visible = False
                  

                ElseIf Request.QueryString("rt") = 2 Then
                    text = "ขออนุญาตนำรถท่องเที่ยวเข้ามาในราชอาณาจักร"

                
                    divCompany.Visible = True
                    div_map.Visible = False
                ElseIf Request.QueryString("rt") = 3 Then
                    text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถยนต์ส่วนบุคคล ของประเทศลาวเข้ามาในราชอาณาจักร"
                    'divCar.Visible = False
                    divCar_1.Visible = False
                    divCar_2.Visible = False
                    divCar_3.Visible = False
                    divIMG_regis_photo.Visible = False
                    divIMG_authorize_car.Visible = False

                    div_admin.Visible = False
                    divCompany.Visible = False
                    div_map.Visible = False
                ElseIf Request.QueryString("rt") = 4 Then
                    text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถยนต์ส่วนบุคคล ของประเทศมาเลเซีย และสิงคโปร์เข้ามาในราชอาณาจักร"
                    divCompany.Visible = False
                    'div_map.Visible = False
                    div_admin.Visible = False

                ElseIf Request.QueryString("rt") = 5 Then
                    text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถขนส่งเชิงพาณิชย์เข้ามาในราชอาณาจักร"
                    divCompany.Visible = False
                    div_map.Visible = False
                    formT2.Visible = True
                End If
            End If

            If Request.QueryString("rt") = 5 Then
                LoadData_Type5()
                formT1.Visible = False
            Else
                LoadData()
                formT2.Visible = False
            End If
            DtlImg_car.RepeatColumns = 4
            If PopulateS.IsMobile Then
                Css = "w3-padding "
                Css_Ctrl = " w3-padding w3-padding-left32 w3-purple3 w3-round-large "
                DtlImg_car.RepeatColumns = 1
            End If

            If _is_edit = 1 Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> tab_active(9);</script>", False)
            ElseIf Request.QueryString("rt") = 5 Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> tab_active(5);</script>", False)
            Else
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> tab_active(0);</script>", False)
            End If
        Else
            If PopulateS.IsMobile Then
                Css = "w3-padding "
                Css_Ctrl = " w3-padding w3-padding-left32 w3-purple3 w3-round-large "
                DtlImg_car.RepeatColumns = 1
            End If
        End If

            If Request.QueryString("rt") = 1 Then
                text = "ขออนุญาตนำรถประจำถิ่นเข้ามาในราชอาณาจักร"
            ElseIf Request.QueryString("rt") = 2 Then
                text = "ขออนุญาตนำรถท่องเที่ยวเข้ามาในราชอาณาจักร"
            ElseIf Request.QueryString("rt") = 3 Then
                text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถยนต์ส่วนบุคคล ของประเทศลาวเข้ามาในราชอาณาจักร"
            ElseIf Request.QueryString("rt") = 4 Then
                text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถยนต์ส่วนบุคคล ของประเทศมาเลเซีย และสิงคโปร์เข้ามาในราชอาณาจักร"
            ElseIf Request.QueryString("rt") = 5 Then
                text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถขนส่งเชิงพาณิชย์เข้ามาในราชอาณาจักร"
            End If

    End Sub
    Private Send As New SendEmail

    Private Sub LoadData()
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim strsql As String = ""
        Try
            Dim license_id As Integer
            con.ClearPool()
            cmd.Connection = con
            cmd.Connection.Open()
            strsql = "SELECT * FROM ( SELECT driver.*, car.*, act.*, license.email as licenseemail , fname , lname, license.license_id , token , CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name, check_tab0, check_tab1, check_tab2, check_tab3, check_tab4 , check_tab8 " & _
                " , comments_tab0 , comments_tab1 , comments_tab2 , comments_tab3 , comments_tab4 , comments_tab8 " & _
                " , CAST(spare_1.prename || ' ' || spare_1.name || ' ' || spare_1.surname as varchar) as spare_1_name , CAST(spare_2.prename || ' ' || spare_2.name || ' ' || spare_2.surname as varchar) as spare_2_name " & _
                " , spare_1.passport_no as spare_1_passport_no, spare_1.passport_expire as spare_1_passport_expire, spare_2.passport_no as spare_2_passport_no, spare_2.passport_expire as spare_2_passport_expire " & _
                " , spare_1.national as spare_1_national, spare_1.license_no as spare_1_license_no , spare_1.photo_cer as spare_1_photo_cer, spare_2.national as spare_2_national, spare_2.license_no as spare_2_license_no , spare_2.photo_cer as spare_2_photo_cer " & _
                " , type_name as typecar_en, model as models, status_th , coalesce(driver.address,'')  || ' ' || coalesce(driver.state,'') || ' ' || coalesce(driver.county,'')  || ' ' || coalesce(driver.countries,'') || ' ' || coalesce(driver.zipcode,'') as address_1 " '& _

            strsql = strsql & " , spare_1.license_exp_date as spare_1_license_exp_date " & _
                              " , spare_2.license_exp_date as spare_2_license_exp_date "

            strsql = strsql & " , spare_1.gender as spare_1_gender , coalesce(spare_1.address,'') || ' ' || coalesce(spare_1.state,'') || ' ' || coalesce(spare_1.country,'') || ' ' || coalesce(spare_1.zipcode,'') as spare_1_address , spare_1.tel as spare_1_tel  " & _
                              " , spare_2.gender as spare_2_gender , coalesce(spare_2.address,'') || ' ' || coalesce(spare_2.state,'') || ' ' || coalesce(spare_2.country,'') || ' ' || coalesce(spare_2.zipcode,'') as spare_2_address , spare_2.tel as spare_2_tel  "

            strsql = strsql & " , spare_1.email as spare_1_email , spare_1.passport_photo as spare_1_passport_photo , spare_1.licensedriver_photo as spare_1_licensedriver_photo, spare_1.passport_photo_2 as spare_1_passport_photo_2, spare_1.licensedriver_photo_2 as spare_1_licensedriver_photo_2 " & _
                              " , spare_2.email as spare_2_email , spare_2.passport_photo as spare_2_passport_photo , spare_2.licensedriver_photo as spare_2_licensedriver_photo, spare_2.passport_photo_2 as spare_2_passport_photo_2, spare_2.licensedriver_photo_2 as spare_2_licensedriver_photo_2 "

            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " ,name_company as com_name , CAST(user_travel.user_name || ' ' || user_travel.user_surname as varchar) as agen_name, info_company, history, user_travel.telephone as com_tel, user_travel.email as com_mail, company_license " & _
                " , coalesce(user_travel.address,'')|| ' ตำบล' || t_name_t || ' อำเภอ' || a_name_t || ' จังหวัด' ||p_name_t|| ' ' ||coalesce(postal,'') as com_address , group_name , travel_group.start_date as group_start  ,  travel_group.exp_date as group_exp, country_car , border_check.border_nameth , admin.admin_name  "
            End If
            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " , (select border_nameth from border_check WHERE border_check.border_id = travel_group.checkout_id) as borderout_nameth  "
            Else
                strsql = strsql & " , (select border_nameth from border_check WHERE border_check.border_id = license.checkout_id) as borderout_nameth "
            End If


            strsql = strsql & " , license.is_edit, old_group_id, attachments_file_name, attachments_file_saved, reason, travel_itinerary_filesaved, coalesce(dtCar.cntCar,0) as cnt_car FROM license " & _
             " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
             " LEFT JOIN spare_driver spare_1 on driver.driver_id = spare_1.driver_id and spare_1.spare_ord = 1 " & _
             " LEFT JOIN spare_driver spare_2 on driver.driver_id = spare_2.driver_id and spare_2.spare_ord > 1 " & _
             " LEFT JOIN car on car.car_id = license.car_id " & _
             " LEFT JOIN act on act.act_id = license.act_id " & _
             " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
             " LEFT JOIN status on license.status_id = status.status_id " '& _
            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " LEFT JOIN user_travel on user_travel.user_id = license.travel_id " & _
                " LEFT JOIN tumbol on tumbol.t_id = user_travel.tumbol  " & _
                " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
                " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                " LEFT JOIN (SELECT  count(gid) cntCar , group_id  FROM travel_group_car group by group_id) dtCar on dtCar.group_id = travel_group.group_id "
            End If
            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " LEFT JOIN border_check on border_check.border_id = travel_group.checkin_id " & _
                    " LEFT JOIN admin on admin.admin_id = travel_group.admin_id " '& _
            Else
                strsql = strsql & " LEFT JOIN border_check on border_check.border_id = license.checkin_id " & _
                    " LEFT JOIN admin on admin.admin_id = license.admin_id " '& _
            End If

            

           

            If Request.QueryString("token") Is Nothing Then

                strsql = strsql & " WHERE driver.driver_id = " & Request.QueryString("driver_id") & " ) as dt "
            Else
                strsql = strsql & " WHERE token = '" & Request.QueryString("token") & "' ) as dt "
            End If

            cmd.CommandText = strsql
            Dim dr As NpgsqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                If Not dr("license_id") Is DBNull.Value Then
                    license_id = dr("license_id")
                End If
                If Not dr("is_edit") Is DBNull.Value Then
                    _is_edit = dr("is_edit")
                End If

                If Request.QueryString("rt") = 2 Then
                    If Not dr("group_name") Is DBNull.Value Then
                        lblgroupname.Text = dr("group_name")
                    End If

                    If Not dr("cnt_car") Is DBNull.Value Then
                        lblcountcar.Text = dr("cnt_car")
                    End If

                    If Not dr("group_start") Is DBNull.Value Then
                        lblstartdategroup.Text = Format(CDate(dr("group_start")), "d MMMM yyyy")
                    End If

                    If Not dr("group_exp") Is DBNull.Value Then
                        lblexpdategroup.Text = Format(CDate(dr("group_exp")), "d MMMM yyyy")
                    End If
                End If



                If Not dr("border_nameth") Is DBNull.Value Then
                    lblBorderCheckin.Text = dr("border_nameth")
                End If

                If Not dr("borderout_nameth") Is DBNull.Value Then
                    lblBorderCheckout.Text = dr("borderout_nameth")
                End If

                If Not dr("admin_name") Is DBNull.Value Then
                    lbladmin_name.Text = dr("admin_name")
                End If

                If Request.QueryString("rt") = 2 Then
                    If Not dr("com_name") Is DBNull.Value Then
                        lblcom_name.Text = dr("com_name")
                    End If

                    If Not dr("agen_name") Is DBNull.Value Then
                        lblagen_name.Text = dr("agen_name")
                    End If

                    If Not dr("info_company") Is DBNull.Value Then
                        lblcom_info.Text = dr("info_company")
                    End If

                    If Not dr("history") Is DBNull.Value Then
                        lblhistory.Text = dr("history")
                    End If

                    If Not dr("com_tel") Is DBNull.Value Then
                        lblcom_tel.Text = dr("com_tel")
                    End If

                    If Not dr("com_mail") Is DBNull.Value Then
                        lblcom_mail.Text = dr("com_mail")
                    End If

                    If Not dr("company_license") Is DBNull.Value Then
                        lblcompany_license.Text = dr("company_license")
                    End If

                    If Not dr("com_address") Is DBNull.Value Then
                        lblcom_address.Text = dr("com_address")
                    End If

                End If

                car_id = dr("car_id")

                If dr("old_group_id") <> 0 Then
                    Exten.Visible = True
                    Dim db As New DBConnect
                    Dim old_token As String = db.executeScalar("select token from license where license_id = (select license_id from travel_group_car where group_id = " & dr("old_group_id") & ")")
                    Dim old_license_no As String = db.executeScalar("select license_no from license where license_id = (select license_id from travel_group_car where group_id = " & dr("old_group_id") & ")")
                    hlrefer.NavigateUrl = "LicenseDtl.aspx?rt=" & Request.QueryString("rt") & "&token=" & old_token
                    hlrefer.Target = "_blank"
                    hlrefer.Text = old_license_no

                    If Not dr("reason") Is DBNull.Value Then
                        lblReasonExten.Text = dr("reason")
                    End If

                    If Not dr("attachments_file_saved") Is DBNull.Value Then
                        HidSname.Value = dr("attachments_file_saved").ToString.Replace(hidfolderAttach.Value & "/", "")
                        HidFname.Value = dr("attachments_file_name")
                        hlFileAttach.Text = dr("attachments_file_name")
                        hlAttach(hlFileAttach, HidSname, HidFname, "FileAttach")

                    Else
                        hlFileAttach.Text = ""
                    End If
                Else
                    Exten.Visible = False
                End If


                If Not dr("country_car") Is DBNull.Value Then
                    lblcountry_car.Text = dr("country_car")
                End If
                If Not dr("province_car") Is DBNull.Value Then
                    lblprovince_car.Text = dr("province_car")
                End If

                If Not dr("idcard_no") Is DBNull.Value Then
                    lblid_code.Text = dr("idcard_no")
                End If

                If Not dr("countries") Is DBNull.Value Then
                    lblcountry_driver.Text = dr("countries")
                End If

                If Not dr("fname") Is DBNull.Value And Not dr("lname") Is DBNull.Value Then
                    lblFLname.Text = dr("fname") & "  " & dr("lname")
                End If

                If Not dr("licenseemail") Is DBNull.Value Then
                    lblEmailLicense.Text = dr("licenseemail")
                End If

                If Not dr("passport_no") Is DBNull.Value Then
                    lblpassport.Text = dr("passport_no")
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
                    lbldate.Text = Format(dr("birthday"), "d MMMM yyyy")
                End If

                If Not dr("other_information") Is DBNull.Value Then
                    lblinfo.Text = dr("other_information")
                End If

                If Not dr("gender") Is DBNull.Value Then
                    lblgender.Text = dr("gender")
                End If


                If Not dr("idcard_no") Is DBNull.Value Then
                    lbllicense_no.Text = dr("idcard_no")
                End If

                If Not dr("license_expire") Is DBNull.Value Then
                    lblexp_license_no.Text = Format(dr("license_expire"), "d MMMM yyyy")
                End If

                If Not dr("address_1") Is DBNull.Value Then
                    lbladdress_driver.Text = dr("address_1")
                End If

                If Not dr("tel") Is DBNull.Value Then
                    lbltel_driver.Text = dr("tel")
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
                    lblpassport1.Text = dr("spare_1_passport_no")
                End If

                If Not dr("spare_1_passport_expire") Is DBNull.Value Then
                    lblpassport_expire_1.Text = Format(CDate(dr("spare_1_passport_expire")), "d MMMM yyyy")
                End If

                If Not dr("spare_1_national") Is DBNull.Value Then
                    lblnational1.Text = dr("spare_1_national")
                End If

                If Not dr("spare_1_license_no") Is DBNull.Value Then
                    lbllicense_no1.Text = dr("spare_1_license_no")
                End If

                If Not dr("spare_1_gender") Is DBNull.Value Then
                    lblgender1.Text = dr("spare_1_gender")
                End If

                If Not dr("spare_1_address") Is DBNull.Value Then
                    lbladdress_1.Text = dr("spare_1_address")
                End If

                If Not dr("spare_1_tel") Is DBNull.Value Then
                    lbltel_1.Text = dr("spare_1_tel")
                End If

                If Not dr("spare_1_license_exp_date") Is DBNull.Value Then
                    lbllicense_exp_date_1.Text = Format(CDate(dr("spare_1_license_exp_date")), "d MMMM yyyy")
                End If

                If Not dr("spare_1_email") Is DBNull.Value Then
                    lblemail_1.Text = dr("spare_1_email")
                End If

                If Not dr("spare_2_name") Is DBNull.Value Then
                    lblname2.Text = dr("spare_2_name")
                End If

                If Not dr("spare_2_passport_no") Is DBNull.Value Then
                    lblpassport2.Text = dr("spare_2_passport_no")
                End If

                If Not dr("spare_2_passport_expire") Is DBNull.Value Then
                    lblpassport_expire_2.Text = Format(CDate(dr("spare_2_passport_expire")), "d MMMM yyyy")
                End If

                If Not dr("spare_2_national") Is DBNull.Value Then
                    lblnational2.Text = dr("spare_2_national")
                End If

                If Not dr("spare_2_license_no") Is DBNull.Value Then
                    lbllicense_no2.Text = dr("spare_2_license_no")
                End If

                If Not dr("spare_2_gender") Is DBNull.Value Then
                    lblgender2.Text = dr("spare_2_gender")
                End If

                If Not dr("spare_2_address") Is DBNull.Value Then
                    lbladdress_2.Text = dr("spare_2_address")
                End If

                If Not dr("spare_2_tel") Is DBNull.Value Then
                    lbltel_2.Text = dr("spare_2_tel")
                End If

                If Not dr("spare_2_license_exp_date") Is DBNull.Value Then
                    lbllicense_exp_date_2.Text = Format(CDate(dr("spare_2_license_exp_date")), "d MMMM yyyy")
                End If

                If Not dr("spare_2_email") Is DBNull.Value Then
                    lblemail_2.Text = dr("spare_2_email")
                End If

                If Not dr("plate") Is DBNull.Value Then
                    lblplate.Text = dr("plate")
                End If

                If Not dr("platelocal") Is DBNull.Value Then
                    lblplatelocal.Text = dr("platelocal")
                End If


                If dr("engine_cap") IsNot DBNull.Value Then
                    lblEngine_cap.Text = dr("engine_cap")
                End If
                If Not dr("seat") Is DBNull.Value Then
                    lblSeats.Text = dr("seat")
                End If

                If Not dr("weight") Is DBNull.Value Then
                    'lblweight.Text = Format(CDbl(dr("weight")), "#,###.##")
                    lblweight.Text = dr("weight")
                End If

                If Not dr("year") Is DBNull.Value Then
                    lblyears.Text = dr("year")
                End If

                If Not dr("colors") Is DBNull.Value Then
                    lblcolors.Text = dr("colors")
                End If

                If Not dr("engine_no") Is DBNull.Value Then
                    lblNumEngine.Text = dr("engine_no")
                End If

                If Not dr("car_no") Is DBNull.Value Then
                    lblnumcar.Text = dr("car_no")
                End If

                If Not dr("passportcar_no") Is DBNull.Value Then
                    lblpass_car.Text = dr("passportcar_no")
                End If

                If Not dr("passportcar_expire") Is DBNull.Value Then
                    lblexp_pass_car_date.Text = Format(dr("passportcar_expire"), "d MMMM yyyy")
                End If




                If dr("is_juristic") = 0 Then
                    If Not dr("owner_name") Is DBNull.Value Then
                        If Not dr("owner_prename") Is DBNull.Value Then
                            lblowner.Text = dr("owner_prename") & " " & dr("owner_name") & " " & dr("owner_lastname")
                        Else
                            lblowner.Text = dr("owner_name") & " " & dr("owner_lastname")
                        End If

                    End If
                Else
                    lblowner.Text = dr("owner_name")
                End If

                If Not dr("owner_idcard") Is DBNull.Value Then
                    lblowner_id_card.Text = dr("owner_idcard")
                End If

                If Not dr("owner_address") Is DBNull.Value Then
                    lbladdress_owner.Text = dr("owner_address")
                End If

                If Not dr("owner_tel") Is DBNull.Value Then
                    lbltel_owner.Text = dr("owner_tel")
                End If


                If Not dr("owner_province") Is DBNull.Value Then
                    lblprovince_owner.Text = dr("owner_province")
                End If

                If Not dr("owner_zipcode") Is DBNull.Value Then
                    lblzipcode_owner.Text = dr("owner_zipcode")
                End If

                If Not dr("owner_country") Is DBNull.Value Then
                    lblcountry_owner.Text = dr("owner_country")
                End If


                If Not dr("holder_name") Is DBNull.Value Then
                    lblholder.Text = dr("holder_name")
                End If

                If Not dr("holder_idcard") Is DBNull.Value Then
                    lblholder_id_card.Text = dr("holder_idcard")
                End If

                If Not dr("holder_address") Is DBNull.Value Then
                    lbladdress_holder.Text = dr("holder_address")
                End If

                If Not dr("holder_tel") Is DBNull.Value Then
                    lbltel_holder.Text = dr("holder_tel")
                End If

                If Not dr("act_no") Is DBNull.Value Then
                    lblinsure_no.Text = dr("act_no")
                End If

                If Not dr("act_name") Is DBNull.Value Then
                    lblinsure_name.Text = dr("act_name")
                End If

                If Not dr("act_tankno") Is DBNull.Value Then
                    lblcar_no.Text = dr("act_tankno")
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


                If Not dr("act_no2") Is DBNull.Value Then
                    lblinsure_no2.Text = dr("act_no2")
                End If

                If Not dr("act_name2") Is DBNull.Value Then
                    lblinsure_name2.Text = dr("act_name2")
                End If

                If Not dr("act_tankno") Is DBNull.Value Then
                    lblcar_no2.Text = dr("act_tankno2")
                End If

                If Not dr("act_company2") Is DBNull.Value Then
                    lblcompany2.Text = dr("act_company2")
                End If

                If Not dr("act_start2") Is DBNull.Value Then
                    lblstart_date2.Text = Format(dr("act_start2"), "d MMMM yyyy")
                End If

                If Not dr("act_ends2") Is DBNull.Value Then
                    lblend_date2.Text = Format(dr("act_ends2"), "d MMMM yyyy")
                End If


                If (CDate(dr("group_start")) > CDate(dr("act_start"))) Or (CDate(dr("group_start")) > CDate(dr("act_start"))) Then

                End If

                Hidchkact.Value = 0
                If (CDate(dr("group_start")) >= CDate(dr("act_start")) AndAlso CDate(dr("group_start")) <= CDate(dr("act_ends"))) And (CDate(dr("group_exp")) >= CDate(dr("act_start")) AndAlso CDate(dr("group_exp")) <= CDate(dr("act_ends"))) Then
                    lblexp_note.Visible = False
                Else
                    lblexp_note.Visible = True
                    Hidchkact.Value = 1
                End If

                If (CDate(dr("group_start")) >= CDate(dr("act_start2")) AndAlso CDate(dr("group_start")) <= CDate(dr("act_ends2"))) And (CDate(dr("group_exp")) >= CDate(dr("act_start2")) AndAlso CDate(dr("group_exp")) <= CDate(dr("act_ends2"))) Then
                    lblexp_note2.Visible = False
                Else
                    lblexp_note2.Visible = True
                    Hidchkact.Value = 1
                End If


                If Not dr("check_tab0") Is DBNull.Value Then
                    If dr("check_tab0") = 1 Then
                        chktabY0.Checked = dr("check_tab0")
                        lbltab0.Text = "ผ่าน"

                    ElseIf dr("check_tab0") = 2 Then
                        chktabN0.Checked = dr("check_tab0")
                        lbltab0.Text = "ไม่ผ่าน"

                    Else
                        lbltab0.Text = "ยังไม่ได้รับการตรวจ"
                    End If

                End If

                If Not dr("comments_tab0") Is DBNull.Value Then
                    txtcomments_tab0.Text = dr("comments_tab0")
                End If


                If Not dr("check_tab1") Is DBNull.Value Then
                    If dr("check_tab1") = 1 Then
                        chktabY1.Checked = dr("check_tab1")
                        lbltab1.Text = "ผ่าน"

                    ElseIf dr("check_tab1") = 2 Then
                        chktabN1.Checked = dr("check_tab1")
                        lbltab1.Text = "ไม่ผ่าน"

                    Else
                        lbltab1.Text = "ยังไม่ได้รับการตรวจ"
                    End If
                End If

                If Not dr("comments_tab1") Is DBNull.Value Then
                    txtcomments_tab1.Text = dr("comments_tab1")
                End If

                If Not dr("check_tab2") Is DBNull.Value Then
                    If dr("check_tab2") = 1 Then
                        chktabY2.Checked = dr("check_tab2")
                        lbltab2.Text = "ผ่าน"

                    ElseIf dr("check_tab2") = 2 Then
                        chktabN2.Checked = dr("check_tab2")
                        lbltab2.Text = "ไม่ผ่าน"

                    Else
                        lbltab2.Text = "ยังไม่ได้รับการตรวจ"
                    End If
                End If

                If Not dr("comments_tab2") Is DBNull.Value Then
                    txtcomments_tab2.Text = dr("comments_tab2")
                End If

                If Not dr("check_tab3") Is DBNull.Value Then
                    If dr("check_tab3") = 1 Then
                        chktabY3.Checked = dr("check_tab3")
                        lbltab3.Text = "ผ่าน"

                    ElseIf dr("check_tab3") = 2 Then
                        chktabN3.Checked = dr("check_tab3")
                        lbltab3.Text = "ไม่ผ่าน"

                    Else
                        lbltab3.Text = "ยังไม่ได้รับการตรวจ"
                    End If
                End If

                If Not dr("comments_tab3") Is DBNull.Value Then
                    txtcomments_tab3.Text = dr("comments_tab3")
                End If

                If Not dr("check_tab4") Is DBNull.Value Then
                    If dr("check_tab4") = 1 Then
                        chktabY4.Checked = dr("check_tab4")
                        lbltab4.Text = "ผ่าน"

                    ElseIf dr("check_tab4") = 2 Then
                        chktabN4.Checked = dr("check_tab4")
                        lbltab4.Text = "ไม่ผ่าน"

                    Else
                        lbltab4.Text = "ยังไม่ได้รับการตรวจ"
                    End If
                End If

                If Not dr("comments_tab4") Is DBNull.Value Then
                    txtcomments_tab4.Text = dr("comments_tab4")
                End If

                If Not dr("act_no") Is DBNull.Value And Not dr("act_company") Is DBNull.Value Then
                    lbltab4Check.Visible = False
                    chktabY4.Visible = True
                    chktabN4.Visible = True
                    texttabY4.Visible = True
                    texttabN4.Visible = True
                Else
                    lbltab4Check.Visible = True
                    lbltab4Check.Text = "ไม่ได้แนบ พรบ."
                    chktabY4.Visible = False
                    chktabN4.Visible = False
                    lbltab4.Text = "ไม่ได้แนบ พรบ. / รอซื้อ พรบ."
                    chktabY4.Checked = "1"
                    texttabY4.Visible = False
                    texttabN4.Visible = False
                    txtcomments_tab4.Visible = False
                End If


                If Not dr("check_tab8") Is DBNull.Value Then
                    If dr("check_tab8") = 1 Then
                        chktabY8.Checked = dr("check_tab8")
                        lbltab8.Text = "ผ่าน"
                    ElseIf dr("check_tab8") = 2 Then
                        chktabN8.Checked = dr("check_tab8")
                        lbltab8.Text = "ไม่ผ่าน"
                    Else
                        lbltab8.Text = "ยังไม่ได้รับการตรวจ"
                    End If
                End If

                If Not dr("comments_tab8") Is DBNull.Value Then
                    txtcomments_tab8.Text = dr("comments_tab8")
                End If

                If chktabY0.Checked And chktabY1.Checked And chktabY2.Checked And chktabY3.Checked And chktabY4.Checked And chktabY8.Checked Then
                    btnSubmitY.Visible = True
                    btnSubmitSend.Visible = False
                Else
                    btnSubmitY.Visible = False
                    btnSubmitSend.Visible = True

                End If


                If lbltab0.Text = "ยังไม่ได้รับการตรวจ" Or lbltab1.Text = "ยังไม่ได้รับการตรวจ" Or lbltab2.Text = "ยังไม่ได้รับการตรวจ" Or lbltab3.Text = "ยังไม่ได้รับการตรวจ" Or lbltab4.Text = "ยังไม่ได้รับการตรวจ" Or lbltab8.Text = "ยังไม่ได้รับการตรวจ" Then
                    btnSubmitY.Visible = False
                    btnSubmitSend.Visible = False
                End If


                If Not dr("licensedriver_photo") Is DBNull.Value Then
                    imageFilelicense_no.ImageUrl = fpathstrIMGLicense & dr("licensedriver_photo")
                    Hyperlicense_no.NavigateUrl = "../ViewImage.aspx?fpath=FileLicenseDriver&ImageType=" & dr("licensedriver_photo")
                Else
                    imageFilelicense_no.Visible = False
                    Hyperlicense_no.Visible = False
                End If

                If Not dr("licensedriver_photo_2") Is DBNull.Value Then
                    If dr("licensedriver_photo_2").ToString.Trim <> "" Then
                        imageFilelicense_no2.ImageUrl = fpathstrIMGLicense & dr("licensedriver_photo_2")
                        Hyperlicense_no2.NavigateUrl = "../ViewImage.aspx?fpath=FileLicenseDriver&ImageType=" & dr("licensedriver_photo_2")
                    Else
                        imageFilelicense_no2.Visible = False
                        Hyperlicense_no2.Visible = False
                    End If

                Else
                    imageFilelicense_no2.Visible = False
                    Hyperlicense_no2.Visible = False
                End If

              
                If Not dr("photo_cer") Is DBNull.Value Then
                    hidFileCer.Value = dr("photo_cer")

                    If hidFileCer.Value <> "" Then
                        Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver") & "/")
                        Dim tempFile = New System.IO.FileInfo(fpathstr & hidFileCer.Value)
                        HyFileCer.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidFileCer.Value & "&fname=" & Server.UrlPathEncode(hidFileCer.Value) & "&fPath=FileLicenseDriver"
                        HyFileCer.Target = "_blank"
                        HyFileCer.Visible = True
                    Else
                        'PhotoCer.Visible = False
                        HyFileCer.Visible = False
                    End If
                Else
                    HyFileCer.Visible = False
                End If

              
                If Not dr("spare_1_photo_cer") Is DBNull.Value Then
                    hidFileCer2.Value = dr("spare_1_photo_cer")

                    If hidFileCer2.Value <> "" Then
                        Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver") & "/")
                        Dim tempFile = New System.IO.FileInfo(fpathstr & hidFileCer2.Value)
                        HyFileCer2.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidFileCer2.Value & "&fname=" & Server.UrlPathEncode(hidFileCer2.Value) & "&fPath=FileLicenseDriver"
                        HyFileCer2.Target = "_blank"
                        HyFileCer2.Visible = True
                    Else
                        'PhotoCer2.Visible = False
                        HyFileCer2.Visible = False
                    End If
                Else
                    HyFileCer2.Visible = False
                End If


              
                If Not dr("spare_2_photo_cer") Is DBNull.Value Then
                    hidFileCer3.Value = dr("spare_2_photo_cer")

                    If hidFileCer3.Value <> "" Then
                        Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver") & "/")
                        Dim tempFile = New System.IO.FileInfo(fpathstr & hidFileCer3.Value)
                        HyFileCer3.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidFileCer3.Value & "&fname=" & Server.UrlPathEncode(hidFileCer3.Value) & "&fPath=FileLicenseDriver"
                        HyFileCer3.Target = "_blank"
                        HyFileCer3.Visible = True
                    Else
                        'PhotoCer2.Visible = False
                        HyFileCer3.Visible = False
                    End If
                Else
                    HyFileCer3.Visible = False
                End If


                If Not dr("spare_1_licensedriver_photo") Is DBNull.Value Then
                    imageFilelicense_no_1.ImageUrl = fpathstrIMGLicense & dr("spare_1_licensedriver_photo")
                    Hyperlicense_no_1.NavigateUrl = "../ViewImage.aspx?fpath=FileLicenseDriver&ImageType=" & dr("spare_1_licensedriver_photo")
                Else
                    imageFilelicense_no_1.Visible = False
                    Hyperlicense_no_1.Visible = False
                End If

                If Not dr("spare_1_licensedriver_photo_2") Is DBNull.Value Then
                    If dr("spare_1_licensedriver_photo_2").ToString.Trim <> "" Then
                        imageFilelicense_no_1_2.ImageUrl = fpathstrIMGLicense & dr("spare_1_licensedriver_photo_2")
                        Hyperlicense_no_1_2.NavigateUrl = "../ViewImage.aspx?fpath=FileLicenseDriver&ImageType=" & dr("spare_1_licensedriver_photo_2")
                    Else
                        imageFilelicense_no_1_2.Visible = False
                        Hyperlicense_no_1_2.Visible = False
                    End If

                Else
                    imageFilelicense_no_1_2.Visible = False
                    Hyperlicense_no_1_2.Visible = False
                End If

                If Not dr("spare_2_licensedriver_photo") Is DBNull.Value Then
                    imageFilelicense_no_2.ImageUrl = fpathstrIMGLicense & dr("spare_2_licensedriver_photo")
                    Hyperlicense_no_2.NavigateUrl = "../ViewImage.aspx?fpath=FileLicenseDriver&ImageType=" & dr("spare_2_licensedriver_photo")
                Else
                    imageFilelicense_no_2.Visible = False
                    Hyperlicense_no_2.Visible = False
                End If

                If Not dr("spare_2_licensedriver_photo_2") Is DBNull.Value Then
                    If dr("spare_2_licensedriver_photo_2").ToString.Trim <> "" Then
                        imageFilelicense_no_2_2.ImageUrl = fpathstrIMGLicense & dr("spare_2_licensedriver_photo_2")
                        Hyperlicense_no_2_2.NavigateUrl = "../ViewImage.aspx?fpath=FileLicenseDriver&ImageType=" & dr("spare_2_licensedriver_photo_2")
                    Else
                        imageFilelicense_no_2_2.Visible = False
                        Hyperlicense_no_2_2.Visible = False
                    End If

                Else
                    imageFilelicense_no_2_2.Visible = False
                    Hyperlicense_no_2_2.Visible = False
                End If

                If Not dr("passport_photo") Is DBNull.Value Then
                    imageFilepassport.ImageUrl = fpathstrIMGPassport & dr("passport_photo")
                    Hyperpassport.NavigateUrl = "../ViewImage.aspx?fpath=FilePassport&ImageType=" & dr("passport_photo")
                Else
                    imageFilepassport.Visible = False
                    Hyperpassport.Visible = False
                End If

                If Not dr("passport_photo_2") Is DBNull.Value Then
                    If dr("passport_photo_2").ToString.Trim <> "" Then
                        imageFilepassport2.ImageUrl = fpathstrIMGPassport & dr("passport_photo_2")
                        Hyperpassport2.NavigateUrl = "../ViewImage.aspx?fpath=FilePassport&ImageType=" & dr("passport_photo_2")
                    Else
                        imageFilepassport2.Visible = False
                        Hyperpassport2.Visible = False
                    End If

                Else
                    imageFilepassport2.Visible = False
                    Hyperpassport2.Visible = False
                End If

                If Not dr("spare_1_passport_photo") Is DBNull.Value Then
                    imageFilepassport_1.ImageUrl = fpathstrIMGPassport & dr("spare_1_passport_photo")
                    Hyperpassport_1.NavigateUrl = "../ViewImage.aspx?fpath=FilePassport&ImageType=" & dr("spare_1_passport_photo")
                Else
                    imageFilepassport_1.Visible = False
                    Hyperpassport_1.Visible = False
                End If

                If Not dr("spare_1_passport_photo_2") Is DBNull.Value Then
                    If dr("spare_1_passport_photo_2").ToString.Trim <> "" Then
                        imageFilepassport_1_2.ImageUrl = fpathstrIMGPassport & dr("spare_1_passport_photo_2")
                        Hyperpassport_1_2.NavigateUrl = "../ViewImage.aspx?fpath=FilePassport&ImageType=" & dr("spare_1_passport_photo_2")
                    Else
                        imageFilepassport_1_2.Visible = False
                        Hyperpassport_1_2.Visible = False
                    End If

                Else
                    imageFilepassport_1_2.Visible = False
                    Hyperpassport_1_2.Visible = False
                End If

                If Not dr("spare_2_passport_photo") Is DBNull.Value Then
                    imageFilepassport_2.ImageUrl = fpathstrIMGPassport & dr("spare_2_passport_photo")
                    Hyperpassport_2.NavigateUrl = "../ViewImage.aspx?fpath=FilePassport&ImageType=" & dr("spare_2_passport_photo")
                Else
                    imageFilepassport_2.Visible = False
                    Hyperpassport_2.Visible = False
                End If

                If Not dr("spare_2_passport_photo_2") Is DBNull.Value Then
                    If dr("spare_2_passport_photo_2").ToString.Trim <> "" Then
                        imageFilepassport_2_2.ImageUrl = fpathstrIMGPassport & dr("spare_2_passport_photo_2")
                        Hyperpassport_2_2.NavigateUrl = "../ViewImage.aspx?fpath=FilePassport&ImageType=" & dr("spare_2_passport_photo_2")
                    Else
                        imageFilepassport_2_2.Visible = False
                        Hyperpassport_2_2.Visible = False
                    End If

                Else
                    imageFilepassport_2_2.Visible = False
                    Hyperpassport_2_2.Visible = False
                End If


                If Not dr("authorize_car") Is DBNull.Value Then
                    imageFileauthorize_car.ImageUrl = fPathAuthorize & dr("authorize_car")
                    Hyperauthorize_car.NavigateUrl = "../ViewImage.aspx?fpath=FileAuthorize&ImageType=" & dr("authorize_car")
                Else
                    imageFileauthorize_car.Visible = False
                    Hyperauthorize_car.Visible = False
                End If

                If Not dr("authorize_car_2") Is DBNull.Value Then
                    If dr("authorize_car_2").ToString.Trim <> "" Then
                        imageFileauthorize_car2.ImageUrl = fPathAuthorize & dr("authorize_car_2")
                        Hyperauthorize_car2.NavigateUrl = "../ViewImage.aspx?fpath=FileAuthorize&ImageType=" & dr("authorize_car_2")
                    Else
                        imageFileauthorize_car2.Visible = False
                        Hyperauthorize_car2.Visible = False
                    End If

                Else
                    imageFileauthorize_car2.Visible = False
                    Hyperauthorize_car2.Visible = False
                End If


                If Not dr("regis_photo") Is DBNull.Value Then
                    imageFileregis_photo.ImageUrl = fpathstrIMGRegistercar & dr("regis_photo")
                    Hyperregis_photo.NavigateUrl = "../ViewImage.aspx?fpath=FileRegisterCar&ImageType=" & dr("regis_photo")
                Else
                    imageFileregis_photo.Visible = False
                    Hyperregis_photo.Visible = False
                End If

                If Not dr("regis_photo_2") Is DBNull.Value Then
                    If dr("regis_photo_2").ToString.Trim <> "" Then
                        imageFileregis_photo2.ImageUrl = fpathstrIMGRegistercar & dr("regis_photo_2")
                        Hyperregis_photo2.NavigateUrl = "../ViewImage.aspx?fpath=FileRegisterCar&ImageType=" & dr("regis_photo_2")
                    Else
                        imageFileregis_photo2.Visible = False
                        Hyperregis_photo2.Visible = False
                    End If

                Else
                    imageFileregis_photo2.Visible = False
                    Hyperregis_photo2.Visible = False
                End If

                If Not dr("act_photo") Is DBNull.Value Then
                    imageFileact_photo.ImageUrl = fpathstrIMGAct & dr("act_photo")
                    Hyperact_photo.NavigateUrl = "../ViewImage.aspx?fpath=FileAct&ImageType=" & dr("act_photo")
                Else
                    imageFileact_photo.Visible = False
                    Hyperact_photo.Visible = False
                End If

                If Not dr("act_photo_2") Is DBNull.Value Then
                    If dr("act_photo_2").ToString.Trim <> "" Then
                        imageFileact_photo_2.ImageUrl = fpathstrIMGAct & dr("act_photo_2")
                        Hyperact_photo_2.NavigateUrl = "../ViewImage.aspx?fpath=FileAct&ImageType=" & dr("act_photo_2")
                    Else
                        imageFileact_photo_2.Visible = False
                        Hyperact_photo_2.Visible = False
                    End If

                Else
                    imageFileact_photo_2.Visible = False
                    Hyperact_photo_2.Visible = False
                End If

                If Not dr("act_photo2") Is DBNull.Value Then
                    imageFileact_photo2.ImageUrl = fpathstrIMGAct & dr("act_photo2")
                    Hyperact_photo2.NavigateUrl = "../ViewImage.aspx?fpath=FileAct&ImageType=" & dr("act_photo2")
                Else
                    imageFileact_photo2.Visible = False
                    Hyperact_photo2.Visible = False
                End If

                If Not dr("act_photo2_2") Is DBNull.Value Then
                    If dr("act_photo2_2").ToString.Trim <> "" Then
                        imageFileact_photo2_2.ImageUrl = fpathstrIMGAct & dr("act_photo2_2")
                        Hyperact_photo2_2.NavigateUrl = "../ViewImage.aspx?fpath=FileAct&ImageType=" & dr("act_photo2_2")
                    Else
                        imageFileact_photo2_2.Visible = False
                        Hyperact_photo2_2.Visible = False
                    End If

                Else
                    imageFileact_photo2_2.Visible = False
                    Hyperact_photo2_2.Visible = False
                End If

                If Not dr("travel_itinerary_filesaved") Is DBNull.Value Then
                    hidTravel_Itinerary.Value = dr("travel_itinerary_filesaved")

                    If hidTravel_Itinerary.Value <> "" Then
                        Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FilePDF") & "/")
                        Dim tempFile = New System.IO.FileInfo(fpathstr & hidTravel_Itinerary.Value)
                        lnkTravel_Itinerary.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidTravel_Itinerary.Value & "&fname=" & Server.UrlPathEncode(hidTravel_Itinerary.Value) & "&fPath=FilePDF"
                        lnkTravel_Itinerary.Target = "_blank"
                        lnkTravel_Itinerary.Visible = True
                    Else
                        lnkTravel_Itinerary.Visible = False
                    End If
                Else
                    lnkTravel_Itinerary.Visible = False
                End If




            End If
            dr.Close()

            Dim dbConnect As New DBConnect


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


            Dim strsql2 = "select gid , file_name from car_cer where car_id = " & car_id
          
            Dim DataTable3 As DataTable = dbConnect.getDataTable(strsql2, "DataTable")
            With DataTable3.Columns
                .Add(New DataColumn("PathImg"))
            End With

            For Each nrow As DataRow In DataTable3.Rows
                nrow("PathImg") = "~/Upload/RegisterCar/" & nrow("file_name")
                If Not nrow("file_name") Is DBNull.Value Then
                    hidPhotonamecar_cer.Value = nrow("file_name")
                End If
            Next
            If hidPhotonamecar_cer.Value <> "" Then

                Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileRegisterCar") & "/")
                Dim tempFile = New System.IO.FileInfo(fpathstr & hidPhotonamecar_cer.Value)
                linkCar_cer.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidPhotonamecar_cer.Value & "&fname=" & Server.UrlPathEncode(hidPhotonamecar_cer.Value) & "&fPath=FileRegisterCar"
                linkCar_cer.Target = "_blank"
                linkCar_cer.Visible = True
            Else
                linkCar_cer.Visible = False
            End If


            Dim strsql3 = "select gid , file_name from car_inspec where car_id = " & car_id
            Dim DataTableimg3 As DataTable = dbConnect.getDataTable(strsql3, "car_inspec")
            With DataTableimg3.Columns
                .Add(New DataColumn("PathImg"))
                .Add(New DataColumn("LinkImg"))
            End With
            For Each nrow As DataRow In DataTableimg3.Rows
                nrow("PathImg") = fpathstrIMGRegistercar & nrow("file_name")
                nrow("LinkImg") = "../ViewImage.aspx?fpath=FileRegisterCar&ImageType=" & nrow("file_name")
            Next
            If DataTableimg3.Rows.Count > 0 Then
                DtlImg_car_inspec.DataSource = DataTableimg3
                DtlImg_car_inspec.DataBind()
            End If


            Dim strarea_use As String = ""
            Dim sprov_code As String = ""

            Dim dtUse As DataTable = dbConnect.getDataTable(" select area_group.prov_code , prov_th from area_group left join province on province.prov_code = area_group.prov_code " & _
                                                            "where group_id in (select group_id from travel_group_car where license_id = " & license_id & ") order by area_id", "dtUse")
            For Each ddr As DataRow In dtUse.Rows
                If dtUse.Rows.Count > 1 Then
                    strarea_use = strarea_use & " - " & ddr("prov_th") & "<br/>"
                    sprov_code = sprov_code & "," & ddr("prov_code")
                Else
                    strarea_use = ddr("prov_th")
                    sprov_code = ddr("prov_code")
                End If


            Next
            lblpro_area_use.Text = strarea_use


            lnkMap.NavigateUrl = "javascript:window.open('MapPop.aspx?pro=" & sprov_code & "" & _
                          "','L11','scrollbars=yes,resizable=1,width=1002,height=798').focus();"

            If Request.QueryString("rt") = 2 Then
                
                Dim tbguide As DataTable = dbConnect.getDataTable(" select Row_number() over (order by guide.guide_id nulls last) as number , " & _
                                     " travel_group_guide.gid , guide.guide_id , CAST(prename ||' ' || guide_name || ' ' || guide_surname as varchar) " & _
                                     "  as guide_name ,  guide_tel , guide_idcard , ( " & _
                                     "   SELECT count(*) from travel_group_guide as a " & _
                                     "   LEFT JOIN travel_group as b on a.group_id = b.group_id " & _
                                     "            WHERE(guide_id = guide.guide_id) " & _
                                     "    and ((start_date >= travel_group.start_date And exp_date <= travel_group.exp_date) or (start_date <= travel_group.exp_date  and exp_date >= travel_group.start_date)) " & _
                                     "  ) as status , " & _
                                     "    regis_no , regis_photo from guide  " & _
                                     "    INNER JOIN travel_group_guide on guide.guide_id = travel_group_guide.guide_id  " & _
                                     "    LEFT JOIN travel_group on travel_group.group_id = travel_group_guide.group_id " & _
                                     "    WHERE travel_group.group_id in ( SELECT group_id FROM travel_group_car where  license_id in (select license_id from license " & _
                                     " where license.token = '" & Request.QueryString("token") & "' ) ) ", "tbguide")
                PopulateS.SetGrid_Footable(gvguide2, tbguide)


            End If

            If Request.QueryString("rt") = 3 Or Request.QueryString("rt") = 4 Then ' Or Request.QueryString("rt") = 2
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMap(" & sprov_code & ");", True)
            End If


        Catch ex As Exception
            Dim ppScript As String = " alert('เกิดข้อผิดพลาด:: " & ex.Message & " ไม่สามารถเรียกข้อมูลแผนงานได้'); "
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", ppScript, True)
        Finally
            cmd.Connection.Close()
            con = Nothing
        End Try

    End Sub

    Private fPathAttach As String = ConfigurationManager.AppSettings("FileAttach")
    Private Sub hlAttach(ByVal hl As HyperLink, ByVal hids As HiddenField, ByVal hidf As HiddenField, ByVal fpath As String)
        Dim tempFile As FileInfo
        Dim strScriptOpen As String = ""
        Dim fpathstr = Server.MapPath(fPathAttach & hidfolderAttach.Value & "/")
        If hl.Text.Trim <> "" Then
            If File.Exists(fpathstr & hids.Value) Then
                tempFile = New System.IO.FileInfo(fpathstr & hids.Value)
                hl.NavigateUrl = "ViewFile.aspx?sname=" & hidfolderAttach.Value & "/" & hids.Value & "&fname=" & Server.UrlPathEncode(hidf.Value) & "&fPath=" & fpath
                hl.Target = "_blank"
            End If
        End If
    End Sub

    Private _is_edit As Integer = 0
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
                If Not dr("is_edit") Is DBNull.Value Then
                    _is_edit = dr("is_edit")
                End If
                If Not dr("permit_no") Is DBNull.Value Then
                    lblpermit_no.Text = dr("permit_no")
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
                    lbltelephone.Text = dr("telephone")
                End If

                If Not dr("email") Is DBNull.Value Then
                    lblemail.Text = dr("email")
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
                    lblvin_no.Text = dr("vin_no")
                End If

                If Not dr("engine_no") Is DBNull.Value Then
                    lblengine_no.Text = dr("engine_no")
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

                If Not dr("check_tab5") Is DBNull.Value Then
                    chktab5.Checked = dr("check_tab5")
                End If

                If Not dr("check_tab6") Is DBNull.Value Then
                    chktab6.Checked = dr("check_tab6")
                End If

                If Not dr("check_tab7") Is DBNull.Value Then
                    chktab7.Checked = dr("check_tab7")
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

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Try

            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            cmd.Parameters.Clear()

            If Request.QueryString("token") Is Nothing Then

                cmd.CommandText = "UPDATE license set check_tab" & HidTab.Value & " = :check_tab , comments_tab" & HidTab.Value & " = :comments_tab WHERE license_id = " & Request.QueryString("license_id")
            Else
                cmd.CommandText = "UPDATE license set check_tab" & HidTab.Value & " = :check_tab , comments_tab" & HidTab.Value & " = :comments_tab WHERE token = '" & Request.QueryString("token") & "'"
            End If

            If Request.QueryString("rt") = 5 Then

                If HidTab.Value = 5 Then
                    If chktab5.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                    End If

                ElseIf HidTab.Value = 6 Then
                    If chktab6.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                    End If

                ElseIf HidTab.Value = 7 Then
                    If chktab7.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                    End If
                End If

            Else

                If HidTab.Value = 0 Then
                    If chktabY0.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab0.Text.Trim = "", Nothing, txtcomments_tab0.Text)
                    ElseIf chktabN0.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab0.Text.Trim = "", Nothing, txtcomments_tab0.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab0.Text.Trim = "", Nothing, txtcomments_tab0.Text)
                    End If

                ElseIf HidTab.Value = 1 Then
                    If chktabY1.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab1.Text.Trim = "", Nothing, txtcomments_tab1.Text)
                    ElseIf chktabN1.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab1.Text.Trim = "", Nothing, txtcomments_tab1.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab1.Text.Trim = "", Nothing, txtcomments_tab1.Text)
                    End If

                ElseIf HidTab.Value = 2 Then
                    If chktabY2.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab2.Text.Trim = "", Nothing, txtcomments_tab2.Text)
                    ElseIf chktabN2.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab2.Text.Trim = "", Nothing, txtcomments_tab2.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab2.Text.Trim = "", Nothing, txtcomments_tab2.Text)
                    End If

                ElseIf HidTab.Value = 3 Then
                    If chktabY3.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab3.Text.Trim = "", Nothing, txtcomments_tab3.Text)
                    ElseIf chktabN3.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab3.Text.Trim = "", Nothing, txtcomments_tab3.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab3.Text.Trim = "", Nothing, txtcomments_tab3.Text)
                    End If

                ElseIf HidTab.Value = 4 Then
                    If chktabY4.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab4.Text.Trim = "", Nothing, txtcomments_tab4.Text)
                    ElseIf chktabN4.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab4.Text.Trim = "", Nothing, txtcomments_tab4.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab4.Text.Trim = "", Nothing, txtcomments_tab4.Text)
                    End If


                ElseIf HidTab.Value = 8 Then
                    If chktabY8.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab8.Text.Trim = "", Nothing, txtcomments_tab8.Text)
                    ElseIf chktabN8.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab8.Text.Trim = "", Nothing, txtcomments_tab8.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab8.Text.Trim = "", Nothing, txtcomments_tab8.Text)
                    End If
                End If

            End If
            If HidTab.Value = 4 Then
                HidTab.Value = 8
            Else
                HidTab.Value = HidTab.Value + 1
            End If

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถบันทึกข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                con.Close()
            End If
            dbConnect = Nothing
        End Try

        If Request.QueryString("rt") = 5 Then
            If HidTab.Value > 7 Then
                Response.Redirect("index.aspx?rt=" & Request.QueryString("rt"))
            Else
                LoadData_Type5()
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> tab_active(" & HidTab.Value & ");</script>", False)
            End If

        Else
            If HidTab.Value > 4 And HidTab.Value <> 8 And HidTab.Value <> 9 Then
                Response.Redirect("index.aspx?rt=" & Request.QueryString("rt"))
            Else
                LoadData()
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> tab_active(" & HidTab.Value & ");</script>", False)
            End If

        End If

    End Sub

    Protected Sub BtnSave2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave2.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Try

            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            cmd.Parameters.Clear()

            If Request.QueryString("token") Is Nothing Then

                cmd.CommandText = "UPDATE license set check_tab" & HidTab.Value & " = :check_tab , comments_tab" & HidTab.Value & " = :comments_tab WHERE license_id = " & Request.QueryString("license_id")
            Else
                cmd.CommandText = "UPDATE license set check_tab" & HidTab.Value & " = :check_tab , comments_tab" & HidTab.Value & " = :comments_tab WHERE token = '" & Request.QueryString("token") & "'"
            End If

            If Request.QueryString("rt") = 5 Then

                If HidTab.Value = 5 Then
                    If chktab5.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                    End If

                ElseIf HidTab.Value = 6 Then
                    If chktab6.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                    End If

                ElseIf HidTab.Value = 7 Then
                    If chktab7.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                    End If
                End If

            Else

                If HidTab.Value = 0 Then
                    If chktabY0.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab0.Text.Trim = "", Nothing, txtcomments_tab0.Text)
                    ElseIf chktabN0.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab0.Text.Trim = "", Nothing, txtcomments_tab0.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab0.Text.Trim = "", Nothing, txtcomments_tab0.Text)
                    End If

                ElseIf HidTab.Value = 1 Then
                    If chktabY1.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab1.Text.Trim = "", Nothing, txtcomments_tab1.Text)
                    ElseIf chktabN1.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab1.Text.Trim = "", Nothing, txtcomments_tab1.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab1.Text.Trim = "", Nothing, txtcomments_tab1.Text)
                    End If

                ElseIf HidTab.Value = 2 Then
                    If chktabY2.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab2.Text.Trim = "", Nothing, txtcomments_tab2.Text)
                    ElseIf chktabN2.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab2.Text.Trim = "", Nothing, txtcomments_tab2.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab2.Text.Trim = "", Nothing, txtcomments_tab2.Text)
                    End If

                ElseIf HidTab.Value = 3 Then
                    If chktabY3.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab3.Text.Trim = "", Nothing, txtcomments_tab3.Text)
                    ElseIf chktabN3.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab3.Text.Trim = "", Nothing, txtcomments_tab3.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab3.Text.Trim = "", Nothing, txtcomments_tab3.Text)
                    End If

                ElseIf HidTab.Value = 4 Then
                    If chktabY4.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab4.Text.Trim = "", Nothing, txtcomments_tab4.Text)
                    ElseIf chktabN4.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab4.Text.Trim = "", Nothing, txtcomments_tab4.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab4.Text.Trim = "", Nothing, txtcomments_tab4.Text)
                    End If


                ElseIf HidTab.Value = 8 Then
                    If chktabY8.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab8.Text.Trim = "", Nothing, txtcomments_tab8.Text)
                    ElseIf chktabN8.Checked = True Then
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab8.Text.Trim = "", Nothing, txtcomments_tab8.Text)
                    Else
                        cmd.Parameters.Add("check_tab", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                        cmd.Parameters.Add("comments_tab", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtcomments_tab8.Text.Trim = "", Nothing, txtcomments_tab8.Text)
                    End If
                End If

            End If

         
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถบันทึกข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                con.Close()
            End If
            dbConnect = Nothing
        End Try

        If Request.QueryString("rt") = 5 Then
            If HidTab.Value > 7 Then
                Response.Redirect("index.aspx?rt=" & Request.QueryString("rt"))
            Else
                LoadData_Type5()
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> tab_active(" & HidTabNow.Value & ");</script>", False)
            End If

        Else
            If HidTab.Value > 4 And HidTab.Value <> 8 And HidTab.Value <> 9 Then
                Response.Redirect("index.aspx?rt=" & Request.QueryString("rt"))
            Else
                LoadData()
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> tab_active(" & HidTabNow.Value & ");</script>", False)
            End If

        End If

    End Sub

    Protected Sub lnkBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBack.Click

        Response.Redirect("index.aspx?rt=" & Request.QueryString("rt"))

    End Sub

    Protected Sub btnSubmitY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmitY.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim token As String = Request.QueryString("token")
        Dim status As Integer
        Dim reason As String = ""

        Try
            con.Open()
            cmd.Connection = con

            If Request.QueryString("rt") = 5 Then
                cmd.Parameters.Clear()
                cmd.CommandText = "UPDATE license set status_id = 5, user_app = admin_id WHERE token = '" & token & "'"
                cmd.ExecuteNonQuery()
            Else


                Dim license_no As String = dbConnect.executeScalar("SELECT license_no from license WHERE token = '" & token & "' ")

                cmd.CommandType = CommandType.Text
                cmd.CommandText = "Update license set status_id = :status_id , qrcode = :qrcode, reason_app = :reason_app, user_app = admin_id  WHERE token = '" & token & "' "
                cmd.Parameters.Clear()
                If Request.QueryString("rt") = 3 Or Request.QueryString("rt") = 4 Then
                    cmd.Parameters.Add("status_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = 5
                    cmd.Parameters.Add("qrcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.qrcode(token, Request.QueryString("rt")) 'qrCode & url & token
                    cmd.Parameters.Add("reason_app", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                    status = 5
                    cmd.ExecuteNonQuery()
                Else
                    If lbltab4.Text = "ไม่ได้แนบ พรบ. / รอซื้อ พรบ." Then
                        status = 3
                    Else
                        status = 1
                    End If

                    cmd.Parameters.Add("status_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = status
                    cmd.Parameters.Add("qrcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.qrcode(token, Request.QueryString("rt")) 'qrCode & url & token
                    cmd.Parameters.Add("reason_app", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                    cmd.ExecuteNonQuery()
                End If

               
                Dim dread As Npgsql.NpgsqlDataReader
                Dim str = " SELECT driver.prename, coalesce(driver.prename_other,'')as prename_other , driver.name ,  driver.surname , idcard_no  , type_user.typename_th " & _
                    ", plate, country_car, " & IIf(Request.QueryString("rt") = 2, "travel_group.start_date, travel_group.exp_date", "license.start_date, license.exp_date") & _
                    IIf(Request.QueryString("rt") = 2, ", user_travel.email ", ", driver.email ") & _
                " from driver LEFT JOIN license on license.driver_id = driver.driver_id " & _
                " LEFT JOIN type_user on type_user.typeuser_id = license.typeuser_id " & _
                " LEFT JOIN car on car.car_id = license.car_id " & _
                " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
                " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                " LEFT JOIN user_travel on user_travel.user_id = travel_group.user_id " & _
                " WHERE license.token = '" & token & "' "
                cmd.CommandText = str
                dread = cmd.ExecuteReader()

                Dim email As String = ""
                Dim typename_th As String = ""
                Dim _Name As String = ""
                Dim plate As String = ""
                Dim country_car As String = ""
                Dim start_date As String = ""
                Dim exp_date As String = ""
                If dread.Read Then
                    If dread("prename") IsNot DBNull.Value Then
                      

                        If dread("prename") = "Other" Then
                            _Name = ""
                        Else
                            _Name = dread("prename")
                        End If
                    End If

                    If dread("name") IsNot DBNull.Value Then
                        _Name = _Name & " " & dread("name")
                    End If
                    If dread("surname") IsNot DBNull.Value Then
                        _Name = _Name & " " & dread("surname")
                    End If

                    If dread("email") IsNot DBNull.Value Then
                        email = dread("email")
                    End If

                    If dread("typename_th") IsNot DBNull.Value Then
                        typename_th = dread("typename_th")
                    End If

                    If dread("plate") IsNot DBNull.Value Then
                        plate = dread("plate")
                    End If

                    If dread("country_car") IsNot DBNull.Value Then
                        country_car = dread("country_car")
                    End If

                    If dread("start_date") IsNot DBNull.Value Then
                        start_date = dread("start_date")
                    End If

                    If dread("exp_date") IsNot DBNull.Value Then
                        exp_date = dread("exp_date")
                    End If

                End If
                dread.Close()
               
                Send.EmailSummit(email, lblagen_name.Text, token, typename_th, status, reason, 1, _Name, plate, country_car, start_date, exp_date)
            End If

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถอัพเดตข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                con.Close()
            End If
            dbConnect = Nothing
        End Try
        Response.Redirect("index.aspx?rt=" & Request.QueryString("rt"))

    End Sub

    Protected Sub btnSubmitSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmitSend.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim token As String = Request.QueryString("token")
        Dim status As Integer
        Dim reason As String = ""
        Dim reason2 As String = ""

        Try
            con.Open()
            cmd.Connection = con
            If Request.QueryString("rt") = 5 Then
                cmd.Parameters.Clear()
                cmd.CommandText = "UPDATE license set status_id = '2' , is_edit = 1 WHERE token = '" & token & "'"
                cmd.ExecuteNonQuery()
            ElseIf Request.QueryString("rt") = 2 Then
                cmd.Parameters.Clear()
               

                Dim now_date As String = Now().Year & "-" & Format(CDbl(Now.Month), "00") & "-" & Format(CDbl(Now.Day), "00")
                Dim ar_tmp As Array = CDate(lblstartdategroup.Text).ToString.Split("/")
                Dim tmp_date As String = ar_tmp(2).ToString.Substring(0, 4) & "-" & ar_tmp(0) & "-" & ar_tmp(1)
                Dim strChkDate As String = "SELECT count(*) AS count_days_no_weekend  FROM generate_series(timestamp '" & now_date & "', timestamp '" & tmp_date & "' , interval  '1 day') the_day  " & _
                    " WHERE extract('ISODOW' FROM the_day) < 6 and the_day not in (SELECT h_date FROM holiday)  "
                Dim CntDay As Integer = dbConnect.executeScalar(strChkDate)

                If CntDay < 5 Then 'If start < Now.Date Then
                    status = 7
                    cmd.CommandText = "UPDATE license set status_id = '7' , is_edit = 1 , cancel_date = now() WHERE token = '" & token & "'"

                Else
                    status = 2
                    cmd.CommandText = "UPDATE license set status_id = '2' , is_edit = 1 WHERE token = '" & token & "'"
                End If


                cmd.ExecuteNonQuery()

                Dim license_no As String = dbConnect.executeScalar("SELECT license_no from license WHERE token = '" & token & "' ")
              

                Dim dread As Npgsql.NpgsqlDataReader
                Dim str = " SELECT driver.prename, coalesce(driver.prename_other,'')as prename_other , driver.name ,  driver.surname , idcard_no , driver.email , type_user.typename_th ,  type_user.typeuser_id , typecar_id , travel_group.group_id,  " & _
                " check_tab0, check_tab1, check_tab2, check_tab3, check_tab4, check_tab8, " & _
                " comments_tab0, comments_tab1, comments_tab2, comments_tab3, comments_tab4, comments_tab8 " & _
                " , countries , travel_id , user_travel.email as travelEmail, plate, country_car, " & IIf(Request.QueryString("rt") = 2, "travel_group.start_date, travel_group.exp_date", "license.start_date, license.exp_date") & _
                " from driver LEFT JOIN license on license.driver_id = driver.driver_id " & _
                " LEFT JOIN type_user on type_user.typeuser_id = license.typeuser_id " & _
                " LEFT JOIN car on car.car_id = license.car_id " & _
                " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
                " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                " LEFT JOIN user_travel on user_travel.user_id = travel_group.user_id " & _
                " WHERE license.token = '" & token & "' "
                cmd.CommandText = str
                dread = cmd.ExecuteReader()
                Dim emailUser As String = ""
                Dim emailTravel As String = ""
                Dim typename_th As String = ""
                Dim plate As String = ""
                Dim country_car As String = ""
                Dim start_date As String = ""
                Dim exp_date As String = ""
                Dim _Name As String = ""
                Dim country As String = ""
                If dread.Read Then

                    If dread("travel_id") IsNot DBNull.Value Then
                        Dim urlEdit As String = ""

                        If dread("prename") IsNot DBNull.Value Then
                           

                            If dread("prename") = "Other" Then
                                _Name = ""
                            Else
                                _Name = dread("prename")
                            End If
                        End If

                        If dread("name") IsNot DBNull.Value Then
                            _Name = _Name & " " & dread("name")
                        End If
                        If dread("surname") IsNot DBNull.Value Then
                            _Name = _Name & " " & dread("surname")
                        End If

                        If dread("email") IsNot DBNull.Value Then
                            emailUser = dread("email")
                        End If

                        If dread("travelEmail") IsNot DBNull.Value Then
                            emailTravel = dread("travelEmail")
                        End If

                        If dread("typename_th") IsNot DBNull.Value Then
                            typename_th = dread("typename_th")
                        End If

                        If dread("plate") IsNot DBNull.Value Then
                            plate = dread("plate")
                        End If

                        If dread("country_car") IsNot DBNull.Value Then
                            country_car = dread("country_car")
                        End If

                        If dread("start_date") IsNot DBNull.Value Then
                            start_date = dread("start_date")
                        End If

                        If dread("exp_date") IsNot DBNull.Value Then
                            exp_date = dread("exp_date")
                        End If


                        If dread("check_tab0") = 2 Then
                            urlEdit = ConfigurationManager.AppSettings("UrlWebFVM") & "/Travel/MgtEdit.aspx?type=" & dread("typecar_id") & "&regis=" & dread("typeuser_id") & "&token=" & token & country
                            Dim url = urlEdit & "&Page=0"
                            reason = reason & " <br / >  <br / > <li> " & dread("comments_tab0") & " : <br / > You can review and edit your application  <a href='" & url & "'>here.</a> </li>"
                            reason2 = reason2 & " <br / >  <br / > <li> " & dread("comments_tab0") & "</li>"
                        End If

                        If dread("check_tab1") = 2 Then
                            urlEdit = ConfigurationManager.AppSettings("UrlWebFVM") & "/Travel/MgtEdit.aspx?type=" & dread("typecar_id") & "&regis=" & dread("typeuser_id") & "&token=" & token & country
                            Dim url = urlEdit & "&Page=1"
                            reason = reason & " <br / >   <li>  " & dread("comments_tab1") & "  : <br / > You can review and edit your application  <a href='" & url & "'>here.</a> </li>"
                            reason2 = reason2 & " <br / >  <br / > <li> " & dread("comments_tab1") & "</li>"
                        End If

                        If dread("check_tab2") = 2 Then
                            urlEdit = ConfigurationManager.AppSettings("UrlWebFVM") & "/Travel/MgtEdit.aspx?type=" & dread("typecar_id") & "&regis=" & dread("typeuser_id") & "&token=" & token & country
                            Dim url = urlEdit & "&Page=2"
                            reason = reason & " <br / >   <li> " & dread("comments_tab2") & " : <br / > You can review and edit your application  <a href='" & url & "'>here.</a> </li>"
                            reason2 = reason2 & " <br / >  <br / > <li> " & dread("comments_tab2") & "</li>"
                        End If

                        If dread("check_tab3") = 2 Then
                            urlEdit = ConfigurationManager.AppSettings("UrlWebFVM") & "/Travel/MgtEdit.aspx?type=" & dread("typecar_id") & "&regis=" & dread("typeuser_id") & "&token=" & token & country
                            Dim url = urlEdit & "&Page=3"
                            reason = reason & " <br / >   <li> " & dread("comments_tab3") & " : <br / > You can review and edit your application  <a href='" & url & "'>here.</a> </li>"
                            reason2 = reason2 & " <br / >  <br / > <li> " & dread("comments_tab3") & "</li>"
                        End If

                        If dread("check_tab4") = 2 Then
                            urlEdit = ConfigurationManager.AppSettings("UrlWebFVM") & "/Travel/MgtEdit.aspx?type=" & dread("typecar_id") & "&regis=" & dread("typeuser_id") & "&token=" & token & country
                            Dim url = urlEdit & "&Page=4"
                            reason = reason & " <br / >   <li> " & dread("comments_tab4") & " : <br / > You can review and edit your application  <a href='" & url & "'>here.</a> </li>"
                            reason2 = reason2 & " <br / >  <br / > <li> " & dread("comments_tab4") & "</li>"
                        End If

                        If dread("check_tab8") = 2 Then
                            urlEdit = ConfigurationManager.AppSettings("UrlWebFVM") & "/Travel/GroupAdd.aspx?type=" & dread("typecar_id") & "&regis=" & dread("typeuser_id") & "&id=" & dread("group_id") & country
                            Dim url = urlEdit & "&Page=8"
                            reason = reason & " <br / >   <li> " & dread("comments_tab8") & " : <br / > You can review and edit your application  <a href='" & url & "'>here.</a>  </li> "
                            reason2 = reason2 & " <br / >  <br / > <li> " & dread("comments_tab8") & "</li>"
                        End If
                        dread.Close()
                     
                        If status = 7 Then
                            Send.EmailSummit(emailTravel, lblagen_name.Text, token, typename_th, status, reason2, 1, _Name, plate, country_car, start_date, exp_date)
                        Else
                            Send.EmailSummit(emailTravel, lblagen_name.Text, token, typename_th, status, reason, 1, _Name, plate, country_car, start_date, exp_date)
                        End If
                        Send.EmailSummit(lblEmailLicense.Text, _Name, token, typename_th, status, reason2, 2, _Name, plate, country_car, start_date, exp_date)

                                        Else
                        Dim urlEdit As String = ConfigurationManager.AppSettings("UrlWebFVM") & "RenewPermit.aspx?type=" & dread("typecar_id") & "&regis=" & dread("typeuser_id") & "&token=" & token & country
                        If dread("prename") IsNot DBNull.Value Then
                           
                            If dread("prename") = "Other" Then
                                _Name = ""
                            Else
                                _Name = dread("prename")
                            End If
                        End If

                        If dread("name") IsNot DBNull.Value Then
                            _Name = _Name & " " & dread("name")
                        End If
                        If dread("surname") IsNot DBNull.Value Then
                            _Name = _Name & " " & dread("surname")
                        End If

                        If dread("email") IsNot DBNull.Value Then
                            emailUser = dread("email")
                        End If
                        If dread("typename_th") IsNot DBNull.Value Then
                            typename_th = dread("typename_th")
                        End If


                        If dread("check_tab0") = 2 Then
                            Dim url = urlEdit & "&Page=0"
                            reason = reason & " <br / >  <br / > <li> " & dread("comments_tab0") & " : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a> </li>"
                        End If

                        If dread("check_tab1") = 2 Then
                            Dim url = urlEdit & "&Page=1"
                            reason = reason & " <br / >   <li>  " & dread("comments_tab1") & "  : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a> </li>"
                        End If

                        If dread("check_tab2") = 2 Then
                            Dim url = urlEdit & "&Page=2"
                            reason = reason & " <br / >   <li> " & dread("comments_tab2") & " : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a> </li>"
                        End If

                        If dread("check_tab3") = 2 Then
                            Dim url = urlEdit & "&Page=3"
                            reason = reason & " <br / >   <li> " & dread("comments_tab3") & " : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a> </li>"
                        End If

                        If dread("check_tab4") = 2 Then
                            Dim url = urlEdit & "&Page=4"
                            reason = reason & " <br / >   <li> " & dread("comments_tab4") & " : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a> </li>"
                        End If

                        If dread("check_tab8") = 2 Then
                            Dim url = urlEdit & "&Page=8"
                            reason = reason & " <br / >   <li> " & dread("comments_tab8") & " : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a>  </li> "
                        End If
                        dread.Close()
                        Send.EmailSummit(lblEmailLicense.Text, lblFLname.Text, token, typename_th, status, reason)
                    End If

                End If

            Else
                cmd.Parameters.Clear()
                cmd.CommandText = "UPDATE license set status_id = '2' , is_edit = 1 WHERE token = '" & token & "'"
                cmd.ExecuteNonQuery()
                status = 2
                Dim license_no As String = dbConnect.executeScalar("SELECT license_no from license WHERE token = '" & token & "' ")
              

                Dim dread As Npgsql.NpgsqlDataReader
                Dim str = " SELECT driver.prename, coalesce(driver.prename_other,'')as prename_other , driver.name ,  driver.surname , idcard_no , driver.email , type_user.typename_th ,  type_user.typeuser_id , typecar_id ,  " & _
                " check_tab0, check_tab1, check_tab2, check_tab3, check_tab4, check_tab8, " & _
                " comments_tab0, comments_tab1, comments_tab2, comments_tab3, comments_tab4, comments_tab8 , countries " & _
                " from driver LEFT JOIN license on license.driver_id = driver.driver_id " & _
                " LEFT JOIN type_user on type_user.typeuser_id = license.typeuser_id " & _
                " LEFT JOIN car on car.car_id = license.car_id " & _
                " WHERE license.token = '" & token & "' "
                cmd.CommandText = str
                dread = cmd.ExecuteReader()

                Dim email As String = ""
                Dim typename_th As String = ""
                Dim _Name As String = ""
                Dim country As String = ""

                If dread.Read Then

                    If dread("countries") = "Myanmar" Then
                        country = "&Country=1"
                    End If


                    Dim urlEdit As String = ConfigurationManager.AppSettings("UrlWebFVM") & "RenewPermit.aspx?type=" & dread("typecar_id") & "&regis=" & dread("typeuser_id") & "&token=" & token & country

                    If dread("prename") IsNot DBNull.Value Then
                       

                        If dread("prename") = "Other" Then
                            _Name = ""
                        Else
                            _Name = dread("prename")
                        End If
                    End If

                    If dread("name") IsNot DBNull.Value Then
                        _Name = _Name & " " & dread("name")
                    End If
                    If dread("surname") IsNot DBNull.Value Then
                        _Name = _Name & " " & dread("surname")
                    End If

                    If dread("email") IsNot DBNull.Value Then
                        email = dread("email")
                    End If
                    If dread("typename_th") IsNot DBNull.Value Then
                        typename_th = dread("typename_th")
                    End If


                    If dread("check_tab0") = 2 Then
                        Dim url = urlEdit & "&Page=0"
                        reason = reason & " <br / >  <br / > <li> " & dread("comments_tab0") & " : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a> </li>"
                    End If

                    If dread("check_tab1") = 2 Then
                        Dim url = urlEdit & "&Page=1"
                        reason = reason & " <br / >   <li>  " & dread("comments_tab1") & "  : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a> </li>"
                    End If

                    If dread("check_tab2") = 2 Then
                        Dim url = urlEdit & "&Page=2"
                        reason = reason & " <br / >   <li> " & dread("comments_tab2") & " : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a> </li>"
                    End If

                    If dread("check_tab3") = 2 Then
                        Dim url = urlEdit & "&Page=3"
                        reason = reason & " <br / >   <li> " & dread("comments_tab3") & " : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a> </li>"
                    End If

                    If dread("check_tab4") = 2 Then
                        Dim url = urlEdit & "&Page=4"
                        reason = reason & " <br / >   <li> " & dread("comments_tab4") & " : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a> </li>"
                    End If

                    If dread("check_tab8") = 2 Then
                        Dim url = urlEdit & "&Page=8"
                        reason = reason & " <br / >   <li> " & dread("comments_tab8") & " : <br / > You can review and edit the issue  <a href='" & url & "'>here.</a>  </li> "
                    End If

                End If

                dread.Close()
                Send.EmailSummit(lblEmailLicense.Text, lblFLname.Text, token, typename_th, status, reason)
            End If

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถอัพเดตข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                con.Close()
            End If
            dbConnect = Nothing
        End Try
        Response.Redirect("index.aspx?rt=" & Request.QueryString("rt"))

    End Sub


    Protected Sub gvguide2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvguide2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblgid As Label = e.Row.Cells(0).FindControl("lblgid")
            Dim lblguide_id As Label = e.Row.Cells(0).FindControl("lblguide_id")
            Dim Labelstatus As Label = e.Row.Cells(0).FindControl("Labelstatus_guide")
            Dim hidstatus As HiddenField = e.Row.Cells(0).FindControl("Hidstatus_guide")
            Dim lblregis_photo As Label = e.Row.Cells(0).FindControl("lblregis_photo")
            Dim Imgregis As Image = e.Row.Cells(0).FindControl("Imgregis")
            If lblregis_photo.Text = "" Then
                Imgregis.Visible = False
            Else
                Imgregis.ImageUrl = "~/Upload/FileGuide/" & lblregis_photo.Text
                Imgregis.Visible = True
            End If
            Dim HyperLicensePhotoGuide As HyperLink = e.Row.Cells(0).FindControl("HyperLicensePhotoGuide")
            HyperLicensePhotoGuide.NavigateUrl = "../ViewImage.aspx?fpath=FileGuide&ImageType=" & lblregis_photo.Text

        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        End If
    End Sub
End Class
