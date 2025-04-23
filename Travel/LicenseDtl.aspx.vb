Imports System.Data
Imports Npgsql

Partial Class Travel_LicenseDtl
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
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "
    Protected Css_Ctrl As String = ""
    Private PopulateS As New PopulateScript

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            If Session("user_id") = Nothing Then
                Response.Redirect("../Login.aspx")
            Else
                If Request.QueryString("rt") = 1 Then
                    text = "Permit/Application Detail"
                    divCompany.Visible = False
                    display_lao.Visible = False

                ElseIf Request.QueryString("rt") = 2 Then
                    text = "Permit/Application Detail"

                    divIMG_act_photo.Visible = True
                    divIMG_act_photo2.Visible = True
                    divIMG_car.Visible = True            
                    display_lao.Visible = False

                ElseIf Request.QueryString("rt") = 3 Then
                    text = "Permit/Application Detail"
                    divCar.Visible = False
                    divCompany.Visible = False

                ElseIf Request.QueryString("rt") = 4 Then
                    text = "Permit/Application Detail"
                    divCompany.Visible = False
                    display_lao.Visible = False

                ElseIf Request.QueryString("rt") = 5 Then
                    text = "Permit/Application Detail"
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
            DtlImg_car.RepeatColumns = 4
            If PopulateS.IsMobile Then
                Css = "w3-padding "
                Css_Ctrl = " w3-padding w3-padding-left32 w3-purple3 w3-round-large "
                DtlImg_car.RepeatColumns = 1
            End If

            If Request.QueryString("focus") <> "" Then
                Dim ppScript As String = "  document.location.href = '#" & Request.QueryString("focus") & "'; "
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", ppScript, True)
            End If
        End If

    End Sub

    Private Sub LoadData()
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim strsql As String = ""
        Dim receipt As String = ""
        Dim receipt_date As String = ""
        Try
            con.ClearPool()
            cmd.Connection = con
            cmd.Connection.Open()
            strsql = "SELECT * FROM ( SELECT driver.*, car.*, act.*, license.email as licenseemail , fname , lname, license.license_id , token , CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name, check_tab0, check_tab1, check_tab2, check_tab3, check_tab4 , check_tab8 " & _
                   " , comments_tab0 , comments_tab1 , comments_tab2 , comments_tab3 , comments_tab4 , comments_tab8 " & _
                   " , CAST(spare_1.prename || ' ' || spare_1.name || ' ' || spare_1.surname as varchar) as spare_1_name , CAST(spare_2.prename || ' ' || spare_2.name || ' ' || spare_2.surname as varchar) as spare_2_name " & _
                   " , spare_1.passport_no as spare_1_passport_no, spare_1.passport_expire as spare_1_passport_expire, spare_2.passport_no as spare_2_passport_no, spare_2.passport_expire as spare_2_passport_expire " & _
                   " , spare_1.national as spare_1_national, spare_1.license_no as spare_1_license_no , spare_1.photo_cer as spare_1_photo_cer, spare_2.national as spare_2_national, spare_2.license_no as spare_2_license_no , spare_2.photo_cer as spare_2_photo_cer " & _
                   " , type_name as typecar_en, model as models, status_th , coalesce(driver.address,'')  || ' ' || coalesce(driver.state,'') || ' ' || coalesce(driver.county,'')  || ' ' || coalesce(driver.countries,'') || ' ' || coalesce(driver.zipcode,'') as address_1 " & _
                   ", (select string_agg(prov_en , ', ' ) from area_group left join province on province.prov_code = area_group.prov_code where group_id in (select group_id from travel_group_car where license_id = license.license_id)) as provarea  "

            strsql = strsql & " , spare_1.license_exp_date as spare_1_license_exp_date " & _
                              " , spare_2.license_exp_date as spare_2_license_exp_date "

            strsql = strsql & " , spare_1.gender as spare_1_gender , coalesce(spare_1.address,'') || ' ' || coalesce(spare_1.state,'') || ' ' || coalesce(spare_1.country,'') || ' ' || coalesce(spare_1.zipcode,'') as spare_1_address , spare_1.tel as spare_1_tel  " & _
                              " , spare_2.gender as spare_2_gender , coalesce(spare_2.address,'') || ' ' || coalesce(spare_2.state,'') || ' ' || coalesce(spare_2.country,'') || ' ' || coalesce(spare_2.zipcode,'') as spare_2_address , spare_2.tel as spare_2_tel  "

            strsql = strsql & " , spare_1.email as spare_1_email , spare_1.passport_photo as spare_1_passport_photo , spare_1.licensedriver_photo as spare_1_licensedriver_photo, spare_1.passport_photo_2 as spare_1_passport_photo_2, spare_1.licensedriver_photo_2 as spare_1_licensedriver_photo_2 " & _
                              " , spare_2.email as spare_2_email , spare_2.passport_photo as spare_2_passport_photo , spare_2.licensedriver_photo as spare_2_licensedriver_photo, spare_2.passport_photo_2 as spare_2_passport_photo_2, spare_2.licensedriver_photo_2 as spare_2_licensedriver_photo_2 "

            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " ,name_company as com_name , CAST(user_travel.user_name || ' ' || user_travel.user_surname as varchar) as agen_name, info_company, history, user_travel.telephone as com_tel, user_travel.email as com_mail, company_license " & _
               " , coalesce(user_travel.address,'')|| ' ตำบล' || t_name_t || ' อำเภอ' || a_name_t || ' จังหวัด' ||p_name_t|| ' ' ||coalesce(postal,'') as com_address , group_name , travel_group.start_date as group_start  ,  travel_group.exp_date as group_exp  "
            End If

            strsql = strsql & " , receipt , receipt_date "
            strsql = strsql & " , country_car , border_check.border_nameen as bordercheckin, admin.admin_name "
            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " , (select border_nameen from border_check WHERE border_check.border_id = travel_group.checkout_id) as bordercheckout  "
            Else
                strsql = strsql & " , (select border_nameen from border_check WHERE border_check.border_id = license.checkout_id) as bordercheckout  "
            End If

            strsql = strsql & " , comments_tab0  , comments_tab1 , comments_tab2 , comments_tab3 , comments_tab4 , comments_tab5 , comments_tab6 , comments_tab7 , comments_tab8, coalesce(dtCar.cntCar,0) as cnt_car "

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


            strsql = strsql & " WHERE token = '" & Request.QueryString("token") & "' ) as dt "
            cmd.CommandText = strsql
            Dim dr As NpgsqlDataReader
            dr = cmd.ExecuteReader
            Dim license_id As String = ""

            If dr.Read Then
                If Not dr("license_id") Is DBNull.Value Then
                    license_id = dr("license_id")
                End If
                If Not dr("comments_tab0") Is DBNull.Value Then
                    lblcomments_tab0.Text = dr("comments_tab0")
                End If

                If Not dr("comments_tab1") Is DBNull.Value Then
                    lblcomments_tab1.Text = dr("comments_tab1")
                End If

                If Not dr("comments_tab2") Is DBNull.Value Then
                    lblcomments_tab2.Text = dr("comments_tab2")
                End If

                If Not dr("comments_tab3") Is DBNull.Value Then
                    lblcomments_tab3.Text = dr("comments_tab3")
                End If

                If Not dr("comments_tab4") Is DBNull.Value Then
                    lblcomments_tab4.Text = dr("comments_tab4")
                End If

                If Not dr("comments_tab8") Is DBNull.Value Then
                    lblcomments_tab8.Text = dr("comments_tab8")
                End If
                If Request.QueryString("rt") = 2 Then
                    If Not dr("group_name") Is DBNull.Value Then
                        lblgroupname.Text = dr("group_name")
                    End If

                    If Not dr("cnt_car") Is DBNull.Value Then
                        If dr("cnt_car") = 0 Then
                            lblcountcar.Text = ""
                        Else
                            lblcountcar.Text = dr("cnt_car")
                        End If

                    End If

                    If Not dr("group_start") Is DBNull.Value Then
                        lblstartdategroup.Text = Format(dr("group_start"), "d MMMM yyyy")
                    End If

                    If Not dr("group_exp") Is DBNull.Value Then
                        lblexpdategroup.Text = Format(dr("group_exp"), "d MMMM yyyy")
                    End If
                    If Not dr("com_name") Is DBNull.Value Then
                        lblcom_name.Text = dr("com_name")
                    End If

                    If Not dr("agen_name") Is DBNull.Value Then
                        lblagen_name.Text = dr("agen_name")
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


                If Not dr("country_car") Is DBNull.Value Then
                    lblstate_car.Text = dr("country_car")
                End If

                If Not dr("provarea") Is DBNull.Value Then
                    lblprovarea.Text = dr("provarea")
                End If


                If Not dr("idcard_no") Is DBNull.Value Then
                    lblid_code.Text = dr("idcard_no")
                End If

                If Not dr("countries") Is DBNull.Value Then
                    lblcountry_driver.Text = dr("countries")
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

                If Not dr("address") Is DBNull.Value Then
                    lbladdress_driver.Text = dr("address")
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
                Else
                    reserve1.Visible = False
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
                Else
                    reserve2.Visible = False
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

                If Not dr("seat") Is DBNull.Value Then
                    lblSeats.Text = dr("seat")
                End If

                If Not dr("weight") Is DBNull.Value Then
                    lblweight.Text = Format(CDbl(dr("weight")), "#,###.##")
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

                'If Not dr("act_tankno2") Is DBNull.Value Then
                '    lblcar_no2.Text = dr("act_tankno2")
                'End If

                If Not dr("act_company2") Is DBNull.Value Then
                    lblcompany2.Text = dr("act_company2")
                End If

                If Not dr("act_start2") Is DBNull.Value Then
                    lblstart_date2.Text = Format(dr("act_start2"), "d MMMM yyyy")
                End If

                If Not dr("act_ends2") Is DBNull.Value Then
                    lblend_date2.Text = Format(dr("act_ends2"), "d MMMM yyyy")
                End If

                If Not dr("bordercheckin") Is DBNull.Value Then
                    lblBorderCheckin.Text = dr("bordercheckin")
                End If

                If Not dr("bordercheckout") Is DBNull.Value Then
                    lblBorderCheckout.Text = dr("bordercheckout")
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

                If Not dr("authorize_car") Is DBNull.Value Then
                    imageFileauthorize_car.ImageUrl = fPathAuthorize & dr("authorize_car")
                    Hyperauthorize_car.NavigateUrl = "../ViewImage.aspx?fpath=FileAuthorize&ImageType=" & dr("authorize_car")
                Else
                    imageFileauthorize_car.Visible = False
                    Hyperauthorize_car.Visible = False
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


                If Not dr("receipt") Is DBNull.Value Then
                    receipt = dr("receipt")
                End If
                If Not dr("receipt_date") Is DBNull.Value Then
                    receipt_date = dr("receipt_date")
                End If

                If Not dr("photo_cer") Is DBNull.Value Then
                    hidFileCer.Value = dr("photo_cer")

                    If hidFileCer.Value <> "" Then
                        Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver") & "/")
                        Dim tempFile = New System.IO.FileInfo(fpathstr & hidFileCer.Value)
                        HyFileCer.NavigateUrl = "../Travel/ViewFile.aspx?sname=" & hidFileCer.Value & "&fname=" & Server.UrlPathEncode(hidFileCer.Value) & "&fPath=FileLicenseDriver"
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
                        HyFileCer2.NavigateUrl = "../Travel/ViewFile.aspx?sname=" & hidFileCer2.Value & "&fname=" & Server.UrlPathEncode(hidFileCer2.Value) & "&fPath=FileLicenseDriver"
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
                        HyFileCer3.NavigateUrl = "../Travel/ViewFile.aspx?sname=" & hidFileCer3.Value & "&fname=" & Server.UrlPathEncode(hidFileCer3.Value) & "&fPath=FileLicenseDriver"
                        HyFileCer3.Target = "_blank"
                        HyFileCer3.Visible = True
                    Else
                        'PhotoCer2.Visible = False
                        HyFileCer3.Visible = False
                    End If
                Else
                    HyFileCer3.Visible = False
                End If
            End If
            dr.Close()

            Dim dbConnect As New DBConnect

            'รูปถ่ายรถ
            strsql = "select gid , file_name , imgtype from car_pic where car_id = " & car_id
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

            'รูปใบแปลไทย
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
                linkCar_cer.NavigateUrl = "../Travel/ViewFile.aspx?sname=" & hidPhotonamecar_cer.Value & "&fname=" & Server.UrlPathEncode(hidPhotonamecar_cer.Value) & "&fPath=FileRegisterCar"
                linkCar_cer.Target = "_blank"
                linkCar_cer.Visible = True
            Else
                linkCar_cer.Visible = False
            End If


            'รูปใบตรวจสภาพรถ
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


            Dim strreceipt As String = "select receipt_no , receipt_date from receipt where license_id = " & license_id
            Dim dtreceipt As DataTable = dbConnect.getDataTable(strreceipt, "receipt")

            If receipt <> "" Then
                Dim nrow2 As DataRow = dtreceipt.NewRow
                With nrow2
                    .Item("receipt_no") = receipt

                    If receipt_date <> "" Then
                        .Item("receipt_date") = receipt_date
                    End If
                End With
                dtreceipt.Rows.Add(nrow2)
                nrow2 = Nothing
            End If


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

            PopulateS.SetGrid_Footable(gvMain, dtreceipt)


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

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request.QueryString("isPopup") Is Nothing Then
            MasterPageFile = "~/MasterPageC.master"
        ElseIf Request.QueryString("isPopup") = "1" Then
            MasterPageFile = "~/MasterPagePopup.master"
        End If
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
