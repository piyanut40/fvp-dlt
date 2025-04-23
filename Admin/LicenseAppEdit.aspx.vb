Imports System.Data
Imports Microsoft.ReportingServices.Rendering.ExcelOpenXmlRenderer
Imports Microsoft.SqlServer.Server
Imports Npgsql
Imports Microsoft.VisualBasic
Imports System.Diagnostics



Partial Class Admin_LicenseAppEdit
    Inherits System.Web.UI.Page
    Protected text As String
    Private car_id As Integer
    Private tbIMG_car As New DataTable


    'Private fpathstrIMGCar As String = ConfigurationSettings.AppSettings("FileVehicle")
    'Private fpathstrIMGLicense As String = ConfigurationSettings.AppSettings("FileLicenseDriver")
    'Private fpathstrIMGPassport As String = ConfigurationSettings.AppSettings("FilePassport")
    'Private fpathstrIMGRegistercar As String = ConfigurationSettings.AppSettings("FileRegisterCar")
    'Private fpathstrIMGAct As String = ConfigurationSettings.AppSettings("FileAct")
    'Private fPathAuthorize As String = ConfigurationSettings.AppSettings("FileAuthorize")
    Protected Css As String = "fontKanit w3-medium w3-padding-top w3-padding-right w3-right-align "
    Protected CSSY As String = "w3-button w3-large w3-green w3-padding w3-round fontKanit w3-medium"
    Protected CSSN As String = "w3-button w3-large w3-red w3-padding w3-round fontKanit w3-medium"
    Protected CSSbutton As String = "w3-button w3-large w3-purple2 w3-padding w3-round fontKanit w3-medium"
    Protected Css_Ctrl As String = ""
    Private PopulateS As New PopulateScript
    Private _is_edit As Integer = 1
    Protected WithEvents MainContent_ddlOwnerCountry As DropDownList
    Protected WithEvents MainContent_ddlOwnerPrename As DropDownList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If IsPostBack = False Then
            If Session("user_id") = Nothing Then
                Response.Redirect("../Login.aspx")
            Else
                If Request.QueryString("rt") = 1 Then
                    text = "ขออนุญาตนำรถประจำถิ่นเข้ามาในราชอาณาจักร"
                    'divCompany.Visible = False
                    'div_map.Visible = False


                ElseIf Request.QueryString("rt") = 2 Then
                    text = "ขออนุญาตนำรถท่องเที่ยวเข้ามาในราชอาณาจักร"

                    'LoadData()
                    'divCompany.Visible = True
                    'div_map.Visible = False
                ElseIf Request.QueryString("rt") = 3 Then
                    text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถยนต์ส่วนบุคคล ของประเทศลาวเข้ามาในราชอาณาจักร"
                    'divCar.Visible = False
                    'divCar_1.Visible = False
                    'divCar_2.Visible = False
                    'divCar_3.Visible = False
                    'divIMG_regis_photo.Visible = False
                    'divIMG_authorize_car.Visible = False

                    'div_admin.Visible = False
                    'divCompany.Visible = False
                    'div_map.Visible = False
                ElseIf Request.QueryString("rt") = 4 Then
                    text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถยนต์ส่วนบุคคล ของประเทศมาเลเซีย และสิงคโปร์เข้ามาในราชอาณาจักร"
                    'divCompany.Visible = False
                    'div_map.Visible = False
                    'div_admin.Visible = False

                ElseIf Request.QueryString("rt") = 5 Then
                    text = "ขออนุญาตนำรถตามความตกลงระหว่างประเทศรถขนส่งเชิงพาณิชย์เข้ามาในราชอาณาจักร"
                    'divCompany.Visible = False
                    'div_map.Visible = False
                    'formT2.Visible = True
                End If
            End If

            If Request.QueryString("rt") = 5 Then
                LoadData_Type5()
                'formT1.Visible = False
            Else
                LoadData()
                'formT2.Visible = False
            End If
            'DtlImg_car.RepeatColumns = 4
            If PopulateS.IsMobile Then
                Css = "w3-padding "
                Css_Ctrl = " w3-padding w3-padding-left32 w3-purple3 w3-round-large "
                'DtlImg_car.RepeatColumns = 1
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
                'DtlImg_car.RepeatColumns = 1
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
    Private Sub LoadData()
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim strsql As String = ""
        Try
            Dim license_id As Integer
            'con.ClearPool()
            Npgsql.NpgsqlConnection.ClearPool(con)
            cmd.Connection = con
            cmd.Connection.Open()
            strsql = "SELECT * FROM ( SELECT driver.*, car.*, act.*, license.email as licenseemail , fname , lname, license.license_id , token ,  driver.prename as driver_prename,driver.name as driver_firstname,driver.surname as driver_lastname, check_tab0, check_tab1, check_tab2, check_tab3, check_tab4 , check_tab8 " &
                " , comments_tab0 , comments_tab1 , comments_tab2 , comments_tab3 , comments_tab4 , comments_tab8 ,driver.tel as driver_tel,driver.email as driver_email,car.brands as car_brands,car.model as car_model" &
                " , spare_1.prename as spare_1_prename,spare_1.name as spare_1_name,spare_1.surname as spare_1_Surname,spare_2.prename as spare_2_prename,spare_2.name as spare_2_name,spare_2.surname as spare_2_Surname " &
                " , spare_1.passport_no as spare_1_passport_no, spare_1.passport_expire as spare_1_passport_expire, spare_2.passport_no as spare_2_passport_no, spare_2.passport_expire as spare_2_passport_expire " &
                " , spare_1.national as spare_1_national, spare_1.license_no as spare_1_license_no , spare_1.photo_cer as spare_1_photo_cer, spare_2.national as spare_2_national, spare_2.license_no as spare_2_license_no , spare_2.photo_cer as spare_2_photo_cer,spare_1.country as spare_1_country " &
                " , type_name as typecar_en, model as models, status_th , coalesce(driver.address,'')  || ' ' || coalesce(driver.state,'') || ' ' || coalesce(driver.county,'')  || ' ' || coalesce(driver.countries,'') || ' ' || coalesce(driver.zipcode,'') as address_1 " '& _

            strsql = strsql & " , spare_1.license_exp_date as spare_1_license_exp_date " &
                              " , spare_2.license_exp_date as spare_2_license_exp_date "

            strsql = strsql & " , spare_1.gender as spare_1_gender , coalesce(spare_1.address,'') || ' ' || coalesce(spare_1.state,'') || ' ' || coalesce(spare_1.country,'') || ' ' || coalesce(spare_1.zipcode,'') as spare_1_address , spare_1.tel as spare_1_tel,spare_1.zipcode as spare_1_zipcode  " &
                              " , spare_2.gender as spare_2_gender , coalesce(spare_2.address,'') || ' ' || coalesce(spare_2.state,'') || ' ' || coalesce(spare_2.country,'') || ' ' || coalesce(spare_2.zipcode,'') as spare_2_address , spare_2.tel as spare_2_tel ,spare_2.zipcode as spare_2_zipcode "

            strsql = strsql & " , spare_1.email as spare_1_email , spare_1.passport_photo as spare_1_passport_photo , spare_1.licensedriver_photo as spare_1_licensedriver_photo, spare_1.passport_photo_2 as spare_1_passport_photo_2, spare_1.licensedriver_photo_2 as spare_1_licensedriver_photo_2 " &
                              " , spare_2.email as spare_2_email , spare_2.passport_photo as spare_2_passport_photo , spare_2.licensedriver_photo as spare_2_licensedriver_photo, spare_2.passport_photo_2 as spare_2_passport_photo_2, spare_2.licensedriver_photo_2 as spare_2_licensedriver_photo_2 ,spare_2.country as spare_2_country"

            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " ,name_company as com_name , CAST(user_travel.user_name || ' ' || user_travel.user_surname as varchar) as agen_name, info_company, history, user_travel.telephone as com_tel, user_travel.email as com_mail, company_license " &
                " , coalesce(user_travel.address,'')|| ' ตำบล' || t_name_t || ' อำเภอ' || a_name_t || ' จังหวัด' ||p_name_t|| ' ' ||coalesce(postal,'') as com_address , group_name , travel_group.start_date as group_start  ,  travel_group.exp_date as group_exp, country_car , border_check.border_nameth , admin.admin_name  "
            End If
            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " , (select border_nameth from border_check WHERE border_check.border_id = travel_group.checkout_id) as borderout_nameth  "
            Else
                strsql = strsql & " , (select border_nameth from border_check WHERE border_check.border_id = license.checkout_id) as borderout_nameth "
            End If


            strsql = strsql & " , license.is_edit, old_group_id, attachments_file_name, attachments_file_saved, reason, travel_itinerary_filesaved, coalesce(dtCar.cntCar,0) as cnt_car FROM license " &
             " LEFT JOIN driver on driver.driver_id = license.driver_id " &
             " LEFT JOIN spare_driver spare_1 on driver.driver_id = spare_1.driver_id and spare_1.spare_ord = 1 " &
             " LEFT JOIN spare_driver spare_2 on driver.driver_id = spare_2.driver_id and spare_2.spare_ord > 1 " &
             " LEFT JOIN car on car.car_id = license.car_id " &
             " LEFT JOIN act on act.act_id = license.act_id " &
             " LEFT JOIN type_car on car.typecar_id = type_car.type_id " &
             " LEFT JOIN status on license.status_id = status.status_id " '& _
            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " LEFT JOIN user_travel on user_travel.user_id = license.travel_id " &
                " LEFT JOIN tumbol on tumbol.t_id = user_travel.tumbol  " &
                " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " &
                " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " &
                " LEFT JOIN (SELECT  count(gid) cntCar , group_id  FROM travel_group_car group by group_id) dtCar on dtCar.group_id = travel_group.group_id "
            End If
            If Request.QueryString("rt") = 2 Then
                strsql = strsql & " LEFT JOIN border_check on border_check.border_id = travel_group.checkin_id " &
                    " LEFT JOIN admin on admin.admin_id = travel_group.admin_id " '& _
            Else
                strsql = strsql & " LEFT JOIN border_check on border_check.border_id = license.checkin_id " &
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
                If dr("is_juristic") = 0 Then

                    If Not dr("owner_name") Is DBNull.Value Then

                        MainContent_txtOwnerName.Text = dr("owner_name")


                    End If
                    If Not dr("owner_prename") Is DBNull.Value Then
                        Dim ownPrename As String = dr("owner_prename").ToString()
                        Dim scriptownprename As String = String.Format("document.getElementById('MainContent_ddlOwnerPrename').value = '{0}';", ownPrename)
                        ClientScript.RegisterStartupScript(Me.GetType(), "Setowner_prename", scriptownprename, True)
                    End If
                Else
                    MainContent_txtOwnerName.Text = dr("owner_name")
                End If
                If Not dr("owner_lastname") Is DBNull.Value Then

                    MainContent_txtOwnerLastName.Text = dr("owner_lastname")
                End If

                If Not dr("owner_idcard") Is DBNull.Value Then
                    MainContent_txtOwnerIdcard.Text = dr("owner_idcard")
                End If

                If Not dr("owner_address") Is DBNull.Value Then
                    txtOwnerAddress.Text = dr("owner_address")
                End If


                If Not dr("owner_province") Is DBNull.Value Then
                    txtOwnerProvince.Text = dr("owner_province")
                End If

                If Not dr("owner_zipcode") Is DBNull.Value Then
                    MainContent_txtOwnerZipcode.Text = dr("owner_zipcode")
                End If



                If Not dr("owner_tel") Is DBNull.Value Then
                    MainContent_txtOwnertel.Text = dr("owner_tel")
                End If

                If Not dr("owner_email") Is DBNull.Value Then
                    MainContent_txtLicenseEmail.Text = dr("owner_email")

                End If
                Dim countryValue As String = dr("owner_country").ToString()
                Dim script As String = String.Format("document.getElementById('MainContent_ddlOwnerCountry').value = '{0}';", countryValue)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SetCountry", script, True)

                If Not dr("driver_prename") Is DBNull.Value Then
                    Dim driverPrename As String = dr("driver_prename").ToString()
                    Dim script1 As String = String.Format("document.getElementById('MainContent_ddlPrename').value = '{0}';", driverPrename)
                    ClientScript.RegisterStartupScript(Me.GetType(), "SetPrename", script1, True)
                End If


                If Not dr("driver_firstname") Is DBNull.Value Then
                    MainContent_txtName.Text = dr("driver_firstname")
                End If

                If Not dr("driver_lastname") Is DBNull.Value Then
                    MainContent_txtSurname.Text = dr("driver_lastname")
                End If

                If Not IsDBNull(dr("gender")) Then
                    Dim genderValue As String = dr("gender").ToString()
                    genderValue = genderValue.Replace("'", "\'")
                    Dim script2 As String = "document.getElementById('MainContent_ddlGender').value = '" & genderValue & "';"
                    ClientScript.RegisterStartupScript(Me.GetType(), "SetGender", script2, True)
                End If

                If Not IsDBNull(dr("birthday")) Then
                    Dim birthdayDate As DateTime = Convert.ToDateTime(dr("birthday"))
                    Debug.WriteLine("Birthday Date: " & birthdayDate.ToString())
                    MainContent_txtDate.Text = birthdayDate.ToString("dd/MM/yyyy")
                End If


                If Not IsDBNull(dr("national")) Then

                    Dim national As String = dr("national").ToString()


                    Dim scriptnational As String = "document.getElementById('MainContent_ddlNational').value = '" & national & "';"


                    ClientScript.RegisterStartupScript(Me.GetType(), "SetNational", scriptnational, True)
                End If


                If Not dr("passport_no") Is DBNull.Value Then
                    MainContent_txtPassportNo.Text = dr("passport_no")
                End If
                If Not IsDBNull(dr("Passport_expire")) Then
                    Dim expiredate As DateTime = Convert.ToDateTime(dr("Passport_expire"))
                    MainContent_txtPassportExpire.Text = expiredate.ToString("dd/MM/yyyy")
                End If

                If Not dr("idcard_no") Is DBNull.Value Then
                    MainContent_txtLicenseDriver.Text = dr("idcard_no")
                End If
                If Not IsDBNull(dr("license_expire")) Then
                    Dim licenseexpire As DateTime = Convert.ToDateTime(dr("license_expire"))
                    MainContent_txtLicenseExpire.Text = licenseexpire.ToString("dd/MM/yyyy")
                End If


                If Not dr("address") Is DBNull.Value Then
                    MainContent_txtAddress.Text = dr("address")
                End If

                If Not dr("province_car") Is DBNull.Value Then
                    MainContent_txtCounty.Text = dr("province_car")

                End If

                If Not dr("zipcode") Is DBNull.Value Then
                    MainContent_txtZipcode.Text = dr("zipcode")
                End If

                If Not IsDBNull(dr("countries")) Then

                    Dim countrydriver As String = dr("countries").ToString()


                    Dim scriptdriver As String = "document.getElementById('MainContent_ddlCountry').value = '" & countrydriver & "';"


                    ClientScript.RegisterStartupScript(Me.GetType(), "Setcountries", scriptdriver, True)
                End If

                If Not dr("driver_tel") Is DBNull.Value Then
                    MainContent_txtTel.Text = dr("driver_tel")
                End If

                If Not dr("driver_email") Is DBNull.Value Then
                    MainContent_txtEmail.Text = dr("driver_email")
                End If

                If Not dr("spare_1_prename") Is DBNull.Value Then
                    Dim sparePrename As String = dr("spare_1_prename").ToString()
                    Dim script4 As String = String.Format("document.getElementById('MainContent_ddlPrename2').value = '{0}';", sparePrename)
                    ClientScript.RegisterStartupScript(Me.GetType(), "SetsparePrename", script4, True)
                End If

                If Not dr("spare_1_name") Is DBNull.Value Then
                    MainContent_txtName2.Text = dr("spare_1_name")
                End If

                If Not dr("spare_1_Surname") Is DBNull.Value Then
                    MainContent_txtSurname2.Text = dr("spare_1_Surname")
                End If

                If Not IsDBNull(dr("spare_1_gender")) Then
                    Dim spare1genderValue As String = dr("spare_1_gender").ToString()
                    spare1genderValue = spare1genderValue.Replace("'", "\'")
                    Dim scriptgenderspare1 As String = "document.getElementById('MainContent_ddlGender2').value = '" & spare1genderValue & "';"
                    ClientScript.RegisterStartupScript(Me.GetType(), "SetGender", scriptgenderspare1, True)
                End If

                If Not IsDBNull(dr("spare_1_national")) Then

                    Dim spare1national As String = dr("spare_1_national").ToString()


                    Dim scriptspare1national As String = "document.getElementById('MainContent_ddlNational2').value = '" & spare1national & "';"


                    ClientScript.RegisterStartupScript(Me.GetType(), "SetNational", scriptspare1national, True)
                End If

                If Not dr("spare_1_passport_no") Is DBNull.Value Then
                    MainContent_txtPassportNo2.Text = dr("spare_1_passport_no")
                End If


                If Not IsDBNull(dr("spare_1_passport_expire")) Then
                    Dim expiredatespare As DateTime = Convert.ToDateTime(dr("spare_1_passport_expire"))
                    MainContent_txtPassport_exp2.Text = expiredatespare.ToString("dd/MM/yyyy")
                End If


                If Not dr("spare_1_license_no") Is DBNull.Value Then
                    MainContent_txtLicense2.Text = dr("spare_1_license_no")
                End If

                If Not IsDBNull(dr("spare_1_license_exp_date")) Then
                    Dim licenseexpire1 As DateTime = Convert.ToDateTime(dr("spare_1_license_exp_date"))
                    MainContent_txtLicenseExpire2.Text = licenseexpire1.ToString("dd/MM/yyyy")
                End If

                If Not dr("spare_1_address") Is DBNull.Value Then
                    MainContent_txtAddress2.Text = dr("spare_1_address")
                End If

                If Not IsDBNull(dr("spare_1_country")) Then

                    Dim countryspare1 As String = dr("spare_1_country").ToString()


                    Dim scriptspare1 As String = "document.getElementById('MainContent_ddlCountry2').value = '" & countryspare1 & "';"


                    ClientScript.RegisterStartupScript(Me.GetType(), "Setcountries", scriptspare1, True)
                End If

                If Not dr("spare_1_zipcode") Is DBNull.Value Then
                    MainContent_txtZipcode2.Text = dr("spare_1_zipcode")
                End If

                If Not dr("spare_1_tel") Is DBNull.Value Then
                    MainContent_txtTel2.Text = dr("spare_1_tel")
                End If

                If Not dr("spare_1_email") Is DBNull.Value Then
                    MainContent_txtEmail2.Text = dr("spare_1_email")
                End If

                If Not dr("spare_2_prename") Is DBNull.Value Then
                    Dim spare2Prename As String = dr("spare_2_prename").ToString()
                    Dim script5 As String = String.Format("document.getElementById('MainContent_ddlPrename3').value = '{0}';", spare2Prename)
                    ClientScript.RegisterStartupScript(Me.GetType(), "SetsparePrename", script5, True)
                End If

                If Not dr("spare_2_name") Is DBNull.Value Then
                    MainContent_txtName3.Text = dr("spare_2_name")
                End If

                If Not dr("spare_2_Surname") Is DBNull.Value Then
                    MainContent_txtSurname3.Text = dr("spare_2_Surname")
                End If

                If Not IsDBNull(dr("spare_2_gender")) Then
                    Dim spare2genderValue As String = dr("spare_2_gender").ToString()
                    spare2genderValue = spare2genderValue.Replace("'", "\'")
                    Dim scriptgenderspare2 As String = "document.getElementById('MainContent_ddlGender3').value = '" & spare2genderValue & "';"
                    ClientScript.RegisterStartupScript(Me.GetType(), "SetGender", scriptgenderspare2, True)
                End If

                If Not IsDBNull(dr("spare_2_national")) Then

                    Dim spare2national As String = dr("spare_2_national").ToString()


                    Dim scriptspare2national As String = "document.getElementById('MainContent_ddlNational3').value = '" & spare2national & "';"


                    ClientScript.RegisterStartupScript(Me.GetType(), "SetNational", scriptspare2national, True)
                End If

                If Not dr("spare_2_passport_no") Is DBNull.Value Then
                    MainContent_txtPassportNo3.Text = dr("spare_2_passport_no")
                End If


                If Not IsDBNull(dr("spare_2_passport_expire")) Then
                    Dim expiredatespare2 As DateTime = Convert.ToDateTime(dr("spare_2_passport_expire"))
                    MainContent_txtPassport_exp3.Text = expiredatespare2.ToString("dd/MM/yyyy")
                End If


                If Not dr("spare_2_license_no") Is DBNull.Value Then
                    MainContent_txtLicense3.Text = dr("spare_2_license_no")
                End If

                If Not IsDBNull(dr("spare_2_license_exp_date")) Then
                    Dim licenseexpire2 As DateTime = Convert.ToDateTime(dr("spare_2_license_exp_date"))
                    MainContent_txtLicenseExpire3.Text = licenseexpire2.ToString("dd/MM/yyyy")
                End If

                If Not dr("spare_2_address") Is DBNull.Value Then
                    MainContent_txtAddress3.Text = dr("spare_2_address")
                End If

                If Not IsDBNull(dr("spare_2_country")) Then

                    Dim countryspare2 As String = dr("spare_2_country").ToString()


                    Dim scriptspare2 As String = "document.getElementById('MainContent_ddlCountry3').value = '" & countryspare2 & "';"


                    ClientScript.RegisterStartupScript(Me.GetType(), "Setcountries", scriptspare2, True)
                End If

                If Not dr("spare_2_zipcode") Is DBNull.Value Then
                    MainContent_txtZipcode3.Text = dr("spare_2_zipcode")
                End If

                If Not dr("spare_2_tel") Is DBNull.Value Then
                    MainContent_txtTel3.Text = dr("spare_2_tel")
                End If


                If Not dr("spare_2_email") Is DBNull.Value Then
                    MainContent_txtEmail3.Text = dr("spare_2_email")
                End If


                If Not dr("brands") Is DBNull.Value Then
                    brands_id.Text = dr("brands")
                End If

                If Not dr("model") Is DBNull.Value Then
                    MainContent_txtModel.Text = dr("model")
                End If

                Dim colors As String = dr("colors").ToString()
                Dim scriptcolors As String = String.Format("document.getElementById('MainContent_ddlColor').value = '{0}';", colors)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SetColors", scriptcolors, True)

                If Not dr("seat") Is DBNull.Value Then
                    MainContent_txtSeats.Text = dr("seat")
                End If

                Dim countrycar As String = dr("country_car").ToString()
                Dim scriptcar_country As String = String.Format("document.getElementById('MainContent_ddlCountryCar').value = '{0}';", countrycar)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Setcountry_car", scriptcar_country, True)

                If Not dr("province_car") Is DBNull.Value Then
                    MainContent_txtstate_car.Text = dr("province_car")
                End If

                If Not dr("plate") Is DBNull.Value Then
                    MainContent_txtLicenseCar.Text = dr("plate")
                End If

                If Not dr("platelocal") Is DBNull.Value Then
                    MainContent_txtLicenseLocalCar.Text = dr("platelocal")
                End If

                If Not dr("engine_no") Is DBNull.Value Then
                    MainContent_txtNumEngine.Text = dr("engine_no")
                End If

                If Not dr("engine_cap") Is DBNull.Value Then
                    MainContent_txtEnginCap.Text = dr("engine_cap")
                End If
                If Not dr("car_no") Is DBNull.Value Then
                    MainContent_txtNumcar.Text = dr("car_no")
                End If
                If Not dr("weight") Is DBNull.Value Then
                    MainContent_txtWeight.Text = dr("weight")
                End If

                Dim typecar As String = dr("type_car").ToString()
                Dim scripttype_car As String = String.Format("document.getElementById('MainContent_ddltypecar').value = '{0}';", typecar)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Settype_car", scripttype_car, True)


                If Not dr("act_company") Is DBNull.Value Then
                    MainContent_txtActCompany.Text = dr("act_company")
                End If
                If Not dr("act_no") Is DBNull.Value Then
                    MainContent_txtActNo.Text = dr("act_no")
                End If

                If Not IsDBNull(dr("act_start")) Then
                    Dim act_start As DateTime = Convert.ToDateTime(dr("act_start"))
                    MainContent_txtActStart.Text = act_start.ToString("dd/MM/yyyy")
                End If

                If Not IsDBNull(dr("act_ends")) Then
                    Dim act_ends As DateTime = Convert.ToDateTime(dr("act_ends"))
                    MainContent_txtActExpire.Text = act_ends.ToString("dd/MM/yyyy")
                End If
                If Not dr("act_company2") Is DBNull.Value Then
                    MainContent_txtActCompany2.Text = dr("act_company2")
                End If
                If Not dr("act_no2") Is DBNull.Value Then
                    MainContent_txtActNo2.Text = dr("act_no2")
                End If
                If Not IsDBNull(dr("act_start2")) Then
                    Dim act_start2 As DateTime = Convert.ToDateTime(dr("act_start2"))
                    MainContent_txtActStart2.Text = act_start2.ToString("dd/MM/yyyy")
                End If

                If Not IsDBNull(dr("act_ends2")) Then
                    Dim act_ends2 As DateTime = Convert.ToDateTime(dr("act_ends2"))
                    MainContent_txtActExpire2.Text = act_ends2.ToString("dd/MM/yyyy")
                End If
            End If
            Dim sessioncarID As String = dr("car_id")
            Session("car_id") = sessioncarID
            dr.Close()
        Catch ex As Exception
            Dim ppScript As String = " alert('เกิดข้อผิดพลาด:: " & ex.Message & " ไม่สามารถเรียกข้อมูลแผนงานได้'); "
            'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", ppScript, True)
        Finally
            cmd.Connection.Close()
            con = Nothing
        End Try

    End Sub
    'Protected Sub BtnSave_Click(sender As Object, e As System.EventArgs) Handles MainContent_btnSave.Click
    '    Dim dbConnect As New DBConnect
    '    Dim cmd As New Npgsql.NpgsqlCommand
    '    Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection



    '    Try
    '        con.Open()
    '        cmd.Connection = con
    '        cmd.CommandText = CommandType.Text
    '        Dim strQuery As String = ""
    '        If Session("car_id") IsNot Nothing AndAlso Not String.IsNullOrEmpty(Session("car_id").ToString()) Then
    '            strQuery = "UPDATE public.car SET " &
    '                                         "owner_name = @owner_name, owner_idcard = @owner_idcard, owner_address = @owner_address, " &
    '                                         "owner_tel = @owner_tel, owner_lastname = @owner_lastname, owner_province = @owner_province, " &
    '                                         "owner_zipcode = @owner_zipcode, owner_country = @owner_country, owner_email = @owner_email, " &
    '                                         "owner_prename = @owner_prename " &
    '                                         "WHERE car_id = @car_id" & Request.QueryString("car_id")
    '        End If
    '        Debug.WriteLine("DEBUG: car_id = " & Session("car_id"))



    '        cmd.CommandText = strQuery
    '        cmd.Parameters.Clear()
    '        cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = MainContent_txtOwnerName.Text
    '        cmd.Parameters.Add("owner_lastname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = MainContent_txtOwnerLastName.Text
    '        cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = MainContent_txtOwnerIdcard.Text
    '        cmd.Parameters.Add("owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerAddress.Text
    '        cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = MainContent_txtOwnertel.Text
    '        cmd.Parameters.Add("owner_province", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerProvince.Text
    '        cmd.Parameters.Add("owner_zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = MainContent_txtOwnerZipcode.Text
    '        cmd.Parameters.Add("owner_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlOwnerCountry.SelectedValue
    '        cmd.Parameters.Add("owner_email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = MainContent_txtLicenseEmail.Text
    '        cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlOwnerPrename.SelectedValue
    '        cmd.Parameters.AddWithValue("car_id", Convert.ToInt64(Session("car_id")))







    '        cmd.ExecuteNonQuery()

    '    Catch ex As Exception
    '        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถบันทึกข้อมูลได้ Error >>> " & ex.Message.ToString & " กรุณาลองอีกครั้ง!!! ');", True)
    '    Finally
    '        cmd.Connection.Close()
    '        con.Close()
    '        dbConnect = Nothing
    '    End Try
    'End Sub
    Protected Sub BtnSave_Click(sender As Object, e As System.EventArgs) Handles MainContent_btnSave.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New Npgsql.NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection()
        Dim transaction As Npgsql.NpgsqlTransaction = Nothing ' ✅ ประกาศ Transaction

        Try
            con.Open()
            transaction = con.BeginTransaction() ' ✅ เริ่ม Transaction
            cmd.Connection = con
            cmd.Transaction = transaction ' ✅ ผูก Transaction กับ Command
            cmd.CommandType = CommandType.Text ' ✅ ตั้งค่าถูกต้อง

            ' ✅ ตรวจสอบค่า car_id
            If Session("car_id") IsNot Nothing AndAlso Not String.IsNullOrEmpty(Session("car_id").ToString()) Then
                Dim strQuery As String = "UPDATE public.car SET " &
                                     "owner_name = @owner_name, owner_idcard = @owner_idcard, owner_address = @owner_address, " &
                                     "owner_tel = @owner_tel, owner_lastname = @owner_lastname, owner_province = @owner_province, " &
                                     "owner_zipcode = @owner_zipcode, owner_country = @owner_country, owner_email = @owner_email, " &
                                     "owner_prename = @owner_prename " &
                                     "WHERE car_id = @car_id"

                cmd.CommandText = strQuery
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("owner_name", MainContent_txtOwnerName.Text)
                cmd.Parameters.AddWithValue("owner_lastname", MainContent_txtOwnerLastName.Text)
                cmd.Parameters.AddWithValue("owner_idcard", MainContent_txtOwnerIdcard.Text)
                cmd.Parameters.AddWithValue("owner_address", txtOwnerAddress.Text)
                cmd.Parameters.AddWithValue("owner_tel", MainContent_txtOwnertel.Text)
                cmd.Parameters.AddWithValue("owner_province", txtOwnerProvince.Text)
                cmd.Parameters.AddWithValue("owner_zipcode", MainContent_txtOwnerZipcode.Text)
                cmd.Parameters.AddWithValue("owner_country", ddlOwnerCountry.SelectedValue)
                cmd.Parameters.AddWithValue("owner_email", MainContent_txtLicenseEmail.Text)
                cmd.Parameters.AddWithValue("owner_prename", ddlOwnerPrename.SelectedValue)

                ' ✅ แปลงค่า car_id เป็น BIGINT
                Dim carId As Long
                If Long.TryParse(Session("car_id").ToString(), carId) Then
                    cmd.Parameters.AddWithValue("car_id", carId)
                Else
                    ' ❌ ถ้า car_id ไม่ใช่ตัวเลข ให้ Rollback และแจ้งเตือน
                    transaction.Rollback()
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript",
                    "alert('Error: car_id ต้องเป็นตัวเลขเท่านั้น!');", True)
                    Exit Sub
                End If

                ' ✅ แสดงค่า Query เพื่อ Debug
                Debug.WriteLine("SQL Query: " & cmd.CommandText)

                ' ✅ Execute Query
                cmd.ExecuteNonQuery()

                ' ✅ ถ้าทุกอย่างสำเร็จ ให้ Commit Transaction
                transaction.Commit()
            Else
                ' ❌ ถ้าไม่มี car_id ให้ Rollback และแจ้งเตือน
                transaction.Rollback()
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript",
                "alert('Error: car_id ไม่ถูกต้อง!');", True)
            End If

        Catch ex As Exception
            ' ❌ ถ้ามี Error ให้ Rollback
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            ' ❌ แจ้งเตือน Error
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript",
            "alert('Error: " & ex.Message.ToString() & " กรุณาลองอีกครั้ง!');", True)
            Debug.WriteLine("ERROR: " & ex.Message)

        Finally
            ' ✅ ปิดการเชื่อมต่อ
            If cmd.Connection IsNot Nothing Then cmd.Connection.Close()
            If con IsNot Nothing Then con.Close()
            dbConnect = Nothing
        End Try
    End Sub

    Private Sub LoadData_Type5()
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim strsql As String = ""
        Try
            'con.ClearPool()
            Npgsql.NpgsqlConnection.ClearPool(con)
            cmd.Connection = con
            cmd.Connection.Open()
            strsql = "SELECT * FROM ( SELECT license.*, car_commerce.* " &
                " FROM license " &
                " LEFT JOIN car_commerce on car_commerce.car_id = license.car_id " &
                " WHERE token = '" & Request.QueryString("token") & "' ) as dt "
            cmd.CommandText = strsql
            Dim dr As NpgsqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                If Not dr("is_edit") Is DBNull.Value Then
                    _is_edit = dr("is_edit")
                End If
                If Not dr("permit_no") Is DBNull.Value Then
                    'lblpermit_no.Text = dr("permit_no")
                End If
                If Not dr("issue_date") Is DBNull.Value Then
                    'lblissue_date.Text = dr("issue_date")
                End If

                If Not dr("issue_place") Is DBNull.Value Then
                    'lblissue_place.Text = dr("issue_place")
                End If

                If Not dr("expiry_date") Is DBNull.Value Then
                    'lblexpiry_date.Text = dr("expiry_date")
                End If

                If Not dr("extended_until") Is DBNull.Value Then
                    'lblextended_until.Text = dr("extended_until")
                End If

                If Not dr("issuing_authority") Is DBNull.Value Then
                    'lblissuing_authority.Text = dr("issuing_authority")
                End If

                If Not dr("tad_no") Is DBNull.Value Then
                    'lbltad_no.Text = dr("tad_no")
                End If

                If Not dr("transport_operator_name") Is DBNull.Value Then
                    'lbltransport_operator_name.Text = dr("transport_operator_name")
                End If

                If Not dr("address") Is DBNull.Value Then
                    'lbladdress.Text = dr("address")
                End If

                If Not dr("province") Is DBNull.Value Then
                    'lblprovince.Text = dr("province")
                End If

                If Not dr("telephone") Is DBNull.Value Then
                    'lbltelephone.Text = dr("telephone")
                End If

                If Not dr("email") Is DBNull.Value Then
                    'lblemail.Text = dr("email")
                End If

                If Not dr("vehicle_owner_name") Is DBNull.Value Then
                    'lblvehicle_owner_name.Text = dr("vehicle_owner_name")
                End If

                If Not dr("vehicle_owner_address") Is DBNull.Value Then
                    'lblvehicle_owner_address.Text = dr("vehicle_owner_address")
                End If

                If Not dr("vehicle_owner_province") Is DBNull.Value Then
                    'lblvehicle_owner_province.Text = dr("vehicle_owner_province")
                End If

                If Not dr("vehicle_owner_telephone") Is DBNull.Value Then
                    'lblvehicle_owner_telephone.Text = dr("vehicle_owner_telephone")
                End If

                If Not dr("vehicle_owner_email") Is DBNull.Value Then
                    'lblvehicle_owner_email.Text = dr("vehicle_owner_email")
                End If

                If Not dr("vehicle_type") Is DBNull.Value Then
                    'lblvehicle_type.Text = dr("vehicle_type")
                End If

                If Not dr("registration_no") Is DBNull.Value Then
                    'lblregistration_no.Text = dr("registration_no")
                End If

                If Not dr("vehicle_category") Is DBNull.Value Then
                    'lblvehicle_category.Text = dr("vehicle_category")
                End If

                If Not dr("regis_date") Is DBNull.Value Then
                    'lblregis_date.Text = dr("regis_date")
                    'lblregis_date.Text = ConvertDateFormat(dr("regis_date"))
                End If

                If Not dr("regis_province") Is DBNull.Value Then
                    'lblregis_province.Text = dr("regis_province")
                End If

                If Not dr("semi_trailer") Is DBNull.Value Then
                    'lblsemi_trailer.Text = dr("semi_trailer")
                End If

                If Not dr("brand") Is DBNull.Value Then
                    'lblbrand.Text = dr("brand")
                End If

                If Not dr("model") Is DBNull.Value Then
                    'lblmodel.Text = dr("model")
                End If

                If Not dr("vin_no") Is DBNull.Value Then
                    'lblvin_no.Text = dr("vin_no")
                End If

                If Not dr("engine_no") Is DBNull.Value Then
                    'lblengine_no.Text = dr("engine_no")
                End If

                If Not dr("axles_no") Is DBNull.Value Then
                    'lblaxles_no.Text = dr("axles_no")
                End If

                If Not dr("colour") Is DBNull.Value Then
                    'lblcolour.Text = dr("colour")
                End If

                If Not dr("capacity_cc") Is DBNull.Value Then
                    'lblcapacity_cc.Text = Format(dr("capacity_cc"), "#,###.##")
                End If

                If Not dr("weight_gross") Is DBNull.Value Then
                    'lblweight_gross.Text = Format(dr("weight_gross"), "#,###.##")
                End If

                If Not dr("weight_net") Is DBNull.Value Then
                    'lblweight_net.Text = Format(dr("weight_net"), "#,###.##")
                End If

                If Not dr("seats_no") Is DBNull.Value Then
                    'lblseats_no.Text = Format(dr("seats_no"), "#,###.##")
                End If

                If Not dr("width") Is DBNull.Value Then
                    'lblwidth.Text = Format(dr("width"), "#,###.##")
                End If

                If Not dr("length") Is DBNull.Value Then
                    'lbllength.Text = Format(dr("length"), "#,###.##")
                End If

                If Not dr("height") Is DBNull.Value Then
                    'lblheight.Text = Format(dr("height"), "#,###.##")
                End If

                If Not dr("check_tab5") Is DBNull.Value Then
                    'chktab5.Checked = dr("check_tab5")
                End If

                If Not dr("check_tab6") Is DBNull.Value Then
                    'chktab6.Checked = dr("check_tab6")
                End If

                If Not dr("check_tab7") Is DBNull.Value Then
                    'chktab7.Checked = dr("check_tab7")
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
                Dim arr_tmp As Array = Microsoft.VisualBasic.Strings.Format(CDate(pDate), "yyyy-MMMM-d").Split("-"c)


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

    'Protected Sub btnNext2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext2.Click
    '    If chkisJuristic.Checked = False And (txtOwnerName.Text = "" Or txtOwnerLastName.Text = "" Or txtOwnerIdcard.Text = "" Or txtLicenseEmail.Text = "") Then
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
    '    ElseIf chkisJuristic.Checked = True And (txtJuristicName.Text = "" Or txtJuristicID.Text = "" Or txtLicenseEmail.Text = "") Then
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
    '    Else
    '        If hidcar_id.Value <> "" Then
    '            Dim dbConnect As New DBConnect
    '            Dim cmd As New NpgsqlCommand
    '            Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
    '            Dim tbCommand As DataTable = dbConnect.TableCommand
    '            Try
    '                con.Open()
    '                cmd.Connection = con
    '                Dim strUpdate = "Update car set owner_prename=:owner_prename ,owner_name=:owner_name , owner_lastname=:owner_lastname,  owner_idcard=:owner_idcard , owner_address=:owner_address , owner_tel=:owner_tel " &
    '                                     "  , owner_province =:owner_province , owner_zipcode =:owner_zipcode , owner_country =:owner_country, is_juristic = :is_juristic  WHERE car_id = " & hidcar_id.Value
    '                cmd.CommandText = CommandType.Text
    '                cmd.CommandText = strUpdate
    '                cmd.Parameters.Clear()
    '                If chkisJuristic.Checked = False Then

    '                    If ddlOwnerPrename.SelectedValue = "Other" Then
    '                        cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerPrename.Text
    '                    Else
    '                        cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlOwnerPrename.SelectedValue
    '                    End If
    '                    cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerName.Text.Trim = "", Nothing, txtOwnerName.Text)
    '                    cmd.Parameters.Add("owner_lastname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerLastName.Text = "", Nothing, txtOwnerLastName.Text)
    '                    cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerIdcard.Text.Trim = "", Nothing, txtOwnerIdcard.Text)
    '                Else

    '                    cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
    '                    cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtJuristicName.Text.Trim = "", Nothing, txtJuristicName.Text)
    '                    cmd.Parameters.Add("owner_lastname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
    '                    cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtJuristicID.Text.Trim = "", Nothing, txtJuristicID.Text)
    '                End If

    '                cmd.Parameters.Add("owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerAddress.Text.Trim = "", Nothing, txtOwnerAddress.Text)
    '                cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnertel.Text.Trim = "", Nothing, txtOwnertel.Text)
    '                cmd.Parameters.Add("owner_province", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerProvince.Text = "", Nothing, txtOwnerProvince.Text)
    '                cmd.Parameters.Add("owner_zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerZipcode.Text = "", Nothing, txtOwnerZipcode.Text)
    '                cmd.Parameters.Add("owner_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlOwnerCountry.SelectedValue
    '                cmd.Parameters.Add("is_juristic", NpgsqlTypes.NpgsqlDbType.Integer).Value = IIf(chkisJuristic.Checked = False, 0, 1)




    '                cmd.ExecuteNonQuery()

    '                tbCommand.Rows.Clear()
    '                tbCommand.Rows.Add("fname", NpgsqlTypes.NpgsqlDbType.Varchar, txtOwnerName.Text)
    '                tbCommand.Rows.Add("lname", NpgsqlTypes.NpgsqlDbType.Varchar, txtOwnerLastName.Text)
    '                tbCommand.Rows.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar, txtLicenseEmail.Text)
    '                Dim check = dbConnect.UpdateDataTable(tbCommand, "license", " WHERE license_id = " & hidlicense_id.Value)

    '                If check = "" Then

    '                Else
    '                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
    '                End If



    '            Catch ex As Exception
    '                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
    '            Finally
    '                cmd.Connection.Close()
    '                con.Close()
    '            End Try


    '        Else
    '            Dim dbConnect As New DBConnect
    '            Dim cmd As New NpgsqlCommand
    '            Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
    '            Try
    '                con.Open()
    '                cmd.Connection = con
    '                Dim strCar = " INSERT INTO car( owner_prename, owner_name,  owner_idcard, owner_address, owner_tel , owner_lastname , owner_province , owner_zipcode , owner_country, is_juristic) values( :owner_prename, :owner_name,  :owner_idcard, :owner_address, :owner_tel , :owner_lastname , :owner_province , :owner_zipcode , :owner_country, :is_juristic) RETURNING car_id;"
    '                cmd.CommandText = CommandType.Text
    '                cmd.CommandText = strCar
    '                cmd.Parameters.Clear()
    '                If chkisJuristic.Checked = False Then

    '                    If ddlOwnerPrename.SelectedValue = "Other" Then
    '                        cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerPrename.Text
    '                    Else
    '                        cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlOwnerPrename.SelectedValue
    '                    End If
    '                    cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerName.Text.Trim = "", Nothing, txtOwnerName.Text)
    '                    cmd.Parameters.Add("owner_lastname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerLastName.Text = "", Nothing, txtOwnerLastName.Text)
    '                    cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerIdcard.Text.Trim = "", Nothing, txtOwnerIdcard.Text)
    '                Else

    '                    cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
    '                    cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtJuristicName.Text.Trim = "", Nothing, txtJuristicName.Text)
    '                    cmd.Parameters.Add("owner_lastname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
    '                    cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtJuristicID.Text.Trim = "", Nothing, txtJuristicID.Text)
    '                End If

    '                cmd.Parameters.Add("owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerAddress.Text.Trim = "", Nothing, txtOwnerAddress.Text)
    '                cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnertel.Text.Trim = "", Nothing, txtOwnertel.Text)
    '                cmd.Parameters.Add("owner_province", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerProvince.Text = "", Nothing, txtOwnerProvince.Text)
    '                cmd.Parameters.Add("owner_zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerZipcode.Text = "", Nothing, txtOwnerZipcode.Text)
    '                cmd.Parameters.Add("owner_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlOwnerCountry.SelectedValue

    '                cmd.Parameters.Add("is_juristic", NpgsqlTypes.NpgsqlDbType.Integer).Value = IIf(chkisJuristic.Checked = False, 0, 1)
    '                Dim car_id As Object = cmd.ExecuteScalar()
    '                hidcar_id.Value = car_id.ToString()

    '                Dim strDriver As String = " Insert Into driver (driver_id ) VALUES (DEFAULT) RETURNING driver_id ;"
    '                cmd.CommandText = CommandType.Text
    '                cmd.CommandText = strDriver
    '                cmd.Parameters.Clear()
    '                Dim driver_id As Object = cmd.ExecuteScalar()
    '                hiddriver_id.Value = driver_id.ToString()


    '                Dim strAct As String = "Insert Into act ( act_id ) VALUES (DEFAULT) RETURNING act_id ;"
    '                cmd.CommandText = CommandType.Text
    '                cmd.CommandText = strAct
    '                cmd.Parameters.Clear()
    '                Dim act_id As Object = cmd.ExecuteScalar()
    '                hidact_id.Value = act_id.ToString()


    '                Dim strInsertlicense As String = "Insert Into license ( driver_id , car_id , act_id , typeuser_id , travel_id , regis_date , fname , lname , email) VALUES ( :driver_id , :car_id , :act_id , 2 , :travel_id , :regis_date , :fname , :lname , :email ) RETURNING license_id ;"
    '                cmd.CommandText = CommandType.Text
    '                cmd.CommandText = strInsertlicense
    '                cmd.Parameters.Clear()
    '                cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
    '                cmd.Parameters.Add("car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidcar_id.Value
    '                cmd.Parameters.Add("act_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidact_id.Value
    '                cmd.Parameters.Add("travel_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("user_id")
    '                cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
    '                cmd.Parameters.Add("fname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerName.Text
    '                cmd.Parameters.Add("lname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerLastName.Text
    '                cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtLicenseEmail.Text

    '                Dim license_id As Object = cmd.ExecuteScalar()
    '                hidlicense_id.Value = license_id.ToString()


    '                Dim strUpdateToken As String = "Update license Set token=:token WHERE license_id =" & hidlicense_id.Value
    '                cmd.CommandText = CommandType.Text
    '                cmd.CommandText = strUpdateToken
    '                cmd.Parameters.Clear()
    '                cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBConnect.Token(hidlicense_id.Value, hidcar_id.Value)
    '                cmd.ExecuteNonQuery()

    '            Catch ex As Exception
    '                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
    '                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script1", "tab1();", True)
    '            Finally
    '                cmd.Connection.Close()
    '                con.Close()
    '            End Try
    '        End If

    '        If Page2.Enabled = False Then
    '            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
    '        Else
    '            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
    '            If chkisJuristic.Checked = False Then
    '                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptAlert", "alertDataDriver();", True)
    '            End If

    '        End If
    '    End If




    'End Sub
End Class
