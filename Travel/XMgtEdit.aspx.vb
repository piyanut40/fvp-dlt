Imports Npgsql
Imports System.IO
Imports System.Data
Imports System.Drawing

Partial Class Travel_XMgtEdit
    Inherits System.Web.UI.Page
    Protected text As String
    Protected name As String
    Private populate As New PopulateDropDown
    Private fPathLicense As String = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver"))
    Private fPathPassport As String = Server.MapPath(ConfigurationManager.AppSettings("FilePassport"))
    Private tbImage As New DataTable
    Private driver_id As String = "0"
    Private fPathCar As String = Server.MapPath(ConfigurationManager.AppSettings("FileVehicle"))
    Private PopulateS As New PopulateScript
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "
    Protected Css_Ctrl As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            If Session("user_id") = Nothing Or Session("user_type") = 1 Then
                Session.Clear()
                Response.Redirect("../Login.aspx")
            Else


                'populate.genDDLCountry(ddlcountrydriver, False)
                populate.genDDLCountry(ddlCountry_driver, False)
                populate.genDDLCountry(ddlCountry_driver1, False)
                populate.genDDLCountry(ddlCountry_driver2, False)
                populate.genDDLCountry(ddlCountryCar, False)
                'populate.genDDLCountry(ddlcountry_holder, False)
                'populate.genDDLCountry(ddlcountry_owner, False)
                populate.genDDLNationality(ddlnational, False)
                populate.genDDLNationality(ddlnational1, False)
                populate.genDDLNationality(ddlnational2, False)
                populate.genDDLBorder(ddlBorderCheckin, False, "")
                populate.genDDLBorder(ddlBorderCheckout, False, "")
                populate.genDDLCartype(ddltypecar, True)
                'populate.genDDLyears(ddlyears, Now.Year, "")
                populate.genAreaform(ddlformarea, False)

                tblicense_img.Visible = False
                tbpassport_img.Visible = False
                tbcar_check.Visible = False
                tbconsent_file.Visible = False
                tbinsure_img.Visible = False
                tbinformation_file.Visible = False
                tbcar_registration_img.Visible = False
                tbVISA_file.Visible = False
                tbreason_file.Visible = False

                If Not (Request.QueryString("token") Is Nothing) Then
                    loadData()
                End If
            End If
        End If


        If hidPhotoNamePassport.Value <> "" Then
            PhotoPassport.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport.Value
            PhotoPassport.Visible = True
            btnUploadPassport.Visible = False
            FileUpload1.Visible = False
            PhotoDeletePassport.Visible = True
        Else
            PhotoPassport.Visible = False
        End If

        If hidPhotoNamePassport1.Value <> "" Then
            PhotoPassport1.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport1.Value
            PhotoPassport1.Visible = True
            btnUploadPassport1.Visible = False
            FileUpload7.Visible = False
            PhotoDeletePassport1.Visible = True
        Else
            PhotoPassport1.Visible = False
        End If

        If hidPhotoNamePassport2.Value <> "" Then
            PhotoPassport2.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport2.Value
            PhotoPassport2.Visible = True
            btnUploadPassport2.Visible = False
            FileUpload6.Visible = False
            PhotoDeletePassport2.Visible = True
        Else
            PhotoPassport2.Visible = False
        End If

        If hidPhotoNameLicense.Value <> "" Then
            PhotoLicense.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense.Value
            PhotoLicense.Visible = True
            btnUploadLicense.Visible = False
            FileUpload3.Visible = False
            PhotoDeleteLicense.Visible = True
        Else
            PhotoLicense.Visible = False
        End If

        If hidPhotoNameLicense1.Value <> "" Then
            PhotoLicense1.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense1.Value
            PhotoLicense1.Visible = True
            btnUploadLicense1.Visible = False
            FileUpload4.Visible = False
            PhotoDeleteLicense1.Visible = True
        Else
            PhotoLicense1.Visible = False
        End If

        If hidPhotoNameLicense2.Value <> "" Then
            PhotoLicense2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense2.Value
            PhotoLicense2.Visible = True
            btnUploadLicense2.Visible = False
            FileUpload5.Visible = False
            PhotoDeleteLicense2.Visible = True
        Else
            PhotoLicense2.Visible = False
        End If

        If PopulateS.IsMobile Then
            Css = "w3-padding w3-padding-left0"
            Css_Ctrl = " w3-padding w3-padding-left32 w3-purple3 w3-round-large "
        End If
        With tbImage
            .Columns.Add("gid")
            .Columns.Add("car_id")
            .Columns.Add("file_name")
            .Columns.Add("PathImg")
        End With

        For Each row As GridViewRow In gvFile.Rows
            Dim nrow As DataRow = tbImage.NewRow
            nrow("gid") = CType(row.Cells(0).FindControl("lblID"), Label).Text
            nrow("car_id") = CType(row.Cells(0).FindControl("lblCarid"), Label).Text
            nrow("file_name") = CType(row.Cells(0).FindControl("lblfile_name"), Label).Text
            nrow("PathImg") = CType(row.Cells(0).FindControl("lblPathImg"), Label).Text
            tbImage.Rows.Add(nrow)
        Next

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> tab_active(1);</script>", False)
    End Sub

    Private Sub loadData()
        Dim dbconect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim strsql As String = ""
        Dim pScript As New StringBuilder
        pScript.Remove(0, pScript.Length)
        Try
            con.ClearPool()
            cmd.Connection = con
            cmd.Connection.Open()
            ', CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name 
            ', CAST(spare_1.prename || ' ' || spare_1.name || ' ' || spare_1.surname as varchar) as spare_1_name 
            ', CAST(spare_2.prename || ' ' || spare_2.name || ' ' || spare_2.surname as varchar) as spare_2_name
            strsql = "SELECT * FROM ( SELECT driver.*, car.*, act.*, act.act_id as actid, license_id, admin_id , token , driver.prename as prename, driver.name as name, driver.surname as surname " & _
                " , spare_1.prename as prename1, spare_1.name as name1, spare_1.surname as surname1 ,spare_2.prename as prename2, spare_2.name as name2, spare_2.surname as surname2 " & _
                " , spare_1.passport_no as spare_1_passport_no, spare_1.passport_expire as spare_1_passport_expire, spare_2.passport_no as spare_2_passport_no, spare_2.passport_expire as spare_2_passport_expire " & _
                " , spare_1.national as spare_1_national, spare_1.license_no as spare_1_license_no, spare_2.national as spare_2_national, spare_2.license_no as spare_2_license_no " & _
                " , spare_1.licensedriver_photo as spare_1_licensedriver_photo, spare_1.passport_photo as spare_1_passport_photo, spare_2.passport_photo as spare_2_passport_photo " & _
                " , spare_2.licensedriver_photo as spare_2_licensedriver_photo, spare_1.license_exp_date as spare_1_license_exp_date, spare_2.license_exp_date as spare_2_license_exp_date " & _
                " , spare_1.address as spare_1_address, spare_1.state as spare_1_state, spare_1.country as spare_1_country, spare_1.zipcode as spare_1_zipcode, spare_1.tel as spare_1_tel, spare_1.email as spare_1_email, spare_1.gender as spare_1_gender " & _
                " , spare_2.address as spare_2_address, spare_2.state as spare_2_state, spare_2.country as spare_2_country, spare_2.zipcode as spare_2_zipcode, spare_2.tel as spare_2_tel, spare_2.email as spare_2_email, spare_2.gender as spare_2_gender " & _
                " , type_name as typecar_en, model as models, status_th, spare_1.sparedriver_id as sparedriver_id1, spare_2.sparedriver_id as sparedriver_id2, checkin_id, checkout_id " '& _

            'If Request.QueryString("rt") = 2 Then
            strsql = strsql & " ,name_company as com_name , CAST(user_name || ' ' || user_surname as varchar) as agen_name, info_company, history, user_travel.telephone as com_tel, user_travel.email as com_mail, company_license " & _
            " , coalesce(user_travel.address,'')|| ' ตำบล' || t_name_t || ' อำเภอ' || a_name_t || ' จังหวัด' ||p_name_t|| ' ' ||coalesce(postal,'') as com_address "
            'End If
            strsql = strsql & " FROM license " & _
             " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
             " LEFT JOIN spare_driver spare_1 on driver.driver_id = spare_1.driver_id and spare_1.spare_ord = 1 " & _
             " LEFT JOIN spare_driver spare_2 on driver.driver_id = spare_2.driver_id and spare_2.spare_ord = 2 " & _
             " LEFT JOIN car on car.car_id = license.car_id " & _
             " LEFT JOIN act on act.act_id = license.act_id " & _
             " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
             " LEFT JOIN status on license.status_id = status.status_id " '& _

            'If Request.QueryString("rt") = 2 Then
            strsql = strsql & " LEFT JOIN user_travel on user_travel.user_id = license.travel_id " & _
            " LEFT JOIN tumbol on tumbol.t_id = user_travel.tumbol "
            'End If
            strsql = strsql & " WHERE token = '" & Request.QueryString("token") & "' ) as dt "
            cmd.CommandText = strsql
            Dim dr As NpgsqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then



                'If Request.QueryString("rt") = 2 Then
                '    If Not dr("com_name") Is DBNull.Value Then
                '        lblcom_name.Text = dr("com_name")
                '    End If

                '    If Not dr("agen_name") Is DBNull.Value Then
                '        lblagen_name.Text = dr("agen_name")
                '    End If

                '    If Not dr("info_company") Is DBNull.Value Then
                '        lblcom_info.Text = dr("info_company")
                '    End If

                '    If Not dr("history") Is DBNull.Value Then
                '        lblhistory.Text = dr("history")
                '    End If

                '    If Not dr("com_tel") Is DBNull.Value Then
                '        lblcom_tel.Text = dr("com_tel")
                '    End If

                '    If Not dr("com_mail") Is DBNull.Value Then
                '        lblcom_mail.Text = dr("com_mail")
                '    End If

                '    If Not dr("company_license") Is DBNull.Value Then
                '        lblcompany_license.Text = dr("company_license")
                '    End If

                '    If Not dr("com_address") Is DBNull.Value Then
                '        lblcom_address.Text = dr("com_address")
                '    End If

                'End If

                'car_id = dr("car_id")
                If Not dr("car_id") Is DBNull.Value Then
                    hidcar_id.Value = dr("car_id")
                End If

                If Not dr("actid") Is DBNull.Value Then
                    hidact_id.Value = dr("actid")
                End If

                If Not dr("driver_id") Is DBNull.Value Then
                    hiddriver_id.Value = dr("driver_id")
                End If

                If Not dr("license_id") Is DBNull.Value Then
                    hidlicense_id.Value = dr("license_id")
                End If

                If Not dr("sparedriver_id1") Is DBNull.Value Then
                    hidsparedriver_id1.Value = dr("sparedriver_id1")
                End If

                If Not dr("sparedriver_id2") Is DBNull.Value Then
                    hidsparedriver_id2.Value = dr("sparedriver_id2")
                End If

                If Not dr("idcard_no") Is DBNull.Value Then
                    txtid_code.Text = dr("idcard_no")
                End If

                If Not dr("countries") Is DBNull.Value Then
                    ddlcountry_driver.SelectedValue = dr("countries")
                End If

                If Not dr("passport_no") Is DBNull.Value Then
                    txtpassport.Text = dr("passport_no")
                End If

                If Not dr("passport_expire") Is DBNull.Value Then
                    'txtexp_pass_date.Text = Format(dr("passport_expire"), "yyyy-MM-dd")
                    txtexp_pass_date.Text = Format(Month(dr("passport_expire")), "00") & "/" & Format(Day(dr("passport_expire")), "00") & "/" & Year(dr("passport_expire"))
                    pScript.Append("$(""#" & txtexp_pass_date.ClientID & """).val('" & txtexp_pass_date.Text & "');")
                End If

                If Not dr("prename") Is DBNull.Value Then
                    Select Case dr("prename")
                        Case "Mr.", "Mrs.", "Ms."
                            rdoprename.SelectedValue = dr("prename")
                        Case "other"
                            rdoprename.SelectedValue = "other"
                            txtprename.Text = dr("prename")
                        Case Else
                            rdoprename.SelectedValue = "other"
                            txtprename.Text = dr("prename")
                    End Select
                End If

                If Not dr("name") Is DBNull.Value Then
                    txtname.Text = dr("name")
                End If

                If Not dr("surname") Is DBNull.Value Then
                    txtsurname.Text = dr("surname")
                End If

                If Not dr("national") Is DBNull.Value Then
                    ddlnational.SelectedValue = dr("national")
                End If

                If Not dr("birthday") Is DBNull.Value Then
                    'txtdate.Text = Format(dr("birthday"), "yyyy-MM-dd")
                    txtdate.Text = Format(Month(dr("birthday")), "00") & "/" & Format(Day(dr("birthday")), "00") & "/" & Year(dr("birthday"))
                    pScript.Append("$(""#" & txtdate.ClientID & """).val('" & txtdate.Text & "');")
                End If

                If Not dr("other_information") Is DBNull.Value Then
                    txtinfo.Text = dr("other_information")
                End If

                If Not dr("gender") Is DBNull.Value Then
                    'ddlgender.Text = dr("gender")

                    If dr("gender") = "Female" Then
                        ddlgender.SelectedValue = "F"
                    Else
                        ddlgender.SelectedValue = "M"
                    End If
                End If

                If Not dr("thailicense_no") Is DBNull.Value Then
                    txtlicense_no.Text = dr("thailicense_no")
                End If

                If Not dr("license_expire") Is DBNull.Value Then
                    'txtexp_license_no.Text = Format(dr("license_expire"), "yyyy-MM-dd")
                    txtexp_license_no.Text = Format(Month(dr("license_expire")), "00") & "/" & Format(Day(dr("license_expire")), "00") & "/" & Year(dr("license_expire"))
                    pScript.Append("$(""#" & txtexp_license_no.ClientID & """).val('" & txtexp_license_no.Text & "');")
                End If

                If Not dr("address") Is DBNull.Value Then
                    txtaddress_driver.Text = dr("address")
                End If

                If Not dr("state") Is DBNull.Value Then
                    txtstate_driver.Text = dr("state")
                End If

                If Not dr("zipcode") Is DBNull.Value Then
                    txtzipcode_driver.Text = dr("zipcode")
                End If

                If Not dr("tel") Is DBNull.Value Then
                    txttel_driver.Text = dr("tel")
                End If

                If Not dr("email") Is DBNull.Value Then
                    txtemail_driver.Text = dr("email")
                End If

                If Not dr("passport_photo") Is DBNull.Value Then
                    hidPhotoNamePassport.Value = dr("passport_photo")
                End If

                If Not dr("licensedriver_photo") Is DBNull.Value Then
                    hidPhotoNameLicense.Value = dr("licensedriver_photo")
                End If

                If Not dr("typecar_en") Is DBNull.Value Then
                    ddltypecar.SelectedValue = dr("typecar_en")
                End If

                If Not dr("brands") Is DBNull.Value Then
                    txtbrands.Text = dr("brands")
                End If

                If Not dr("models") Is DBNull.Value Then
                    txtmodels.Text = dr("models")
                End If

                'If Not dr("spare_1_name") Is DBNull.Value Then
                '    txtname1.Text = dr("spare_1_name")
                'End If

                If Not dr("prename1") Is DBNull.Value Then
                    Select Case dr("prename1")
                        Case "Mr.", "Mrs.", "Ms."
                            rdoprename1.SelectedValue = dr("prename1")
                        Case "other"
                            rdoprename1.SelectedValue = "other"
                            txtprename1.Text = dr("prename1")
                        Case Else
                            rdoprename1.SelectedValue = "other"
                            txtprename1.Text = dr("prename1")
                    End Select
                End If

                If Not dr("name1") Is DBNull.Value Then
                    txtname1.Text = dr("name1")
                End If

                If Not dr("surname1") Is DBNull.Value Then
                    txtsurname1.Text = dr("surname1")
                End If

                If Not dr("spare_1_licensedriver_photo") Is DBNull.Value Then
                    hidPhotoNameLicense1.Value = dr("spare_1_licensedriver_photo")
                End If

                If Not dr("spare_1_license_exp_date") Is DBNull.Value Then
                    txtexp_license_no1.Text = Format(Month(dr("spare_1_license_exp_date")), "00") & "/" & Format(Day(dr("spare_1_license_exp_date")), "00") & "/" & Year(dr("spare_1_license_exp_date"))
                    pScript.Append("$(""#" & txtexp_license_no1.ClientID & """).val('" & txtexp_license_no1.Text & "');")
                End If

                If Not dr("spare_1_passport_no") Is DBNull.Value Then
                    txtpassport1.Text = dr("spare_1_passport_no")
                End If

                If Not dr("spare_1_passport_expire") Is DBNull.Value Then
                    'txtexp_pass_date1.Text = Format(dr("spare_1_passport_expire"), "yyyy-MM-dd")
                    txtexp_pass_date1.Text = Format(Month(dr("spare_1_passport_expire")), "00") & "/" & Format(Day(dr("spare_1_passport_expire")), "00") & "/" & Year(dr("spare_1_passport_expire"))
                    pScript.Append("$(""#" & txtexp_pass_date1.ClientID & """).val('" & txtexp_pass_date1.Text & "');")
                End If

                If Not dr("spare_1_passport_photo") Is DBNull.Value Then
                    hidPhotoNamePassport1.Value = dr("spare_1_passport_photo")
                End If

                If Not dr("spare_1_national") Is DBNull.Value Then
                    ddlnational1.SelectedValue = dr("spare_1_national")
                End If

                If Not dr("spare_1_license_no") Is DBNull.Value Then
                    txtlicense_no1.Text = dr("spare_1_license_no")
                End If

                If Not dr("spare_1_address") Is DBNull.Value Then
                    txtaddress_driver1.Text = dr("spare_1_address")
                End If

                If Not dr("spare_1_state") Is DBNull.Value Then
                    txtstate_driver1.Text = dr("spare_1_state")
                End If

                If Not dr("spare_1_country") Is DBNull.Value Then
                    ddlCountry_driver1.SelectedValue = dr("spare_1_country")
                End If

                If Not dr("spare_1_zipcode") Is DBNull.Value Then
                    txtzipcode_driver1.Text = dr("spare_1_zipcode")
                End If

                If Not dr("spare_1_tel") Is DBNull.Value Then
                    txttel_driver1.Text = dr("spare_1_tel")
                End If

                If Not dr("spare_1_email") Is DBNull.Value Then
                    txtemail_driver1.Text = dr("spare_1_email")
                End If

                If Not dr("spare_1_gender") Is DBNull.Value Then

                    If dr("spare_1_gender") = "Female" Then
                        ddlgender1.SelectedValue = "F"
                    Else
                        ddlgender1.SelectedValue = "M"
                    End If

                End If

                'If Not dr("spare_2_name") Is DBNull.Value Then
                '    txtname2.Text = dr("spare_2_name")
                'End If

                If Not dr("prename2") Is DBNull.Value Then
                    Select Case dr("prename2")
                        Case "Mr.", "Mrs.", "Ms."
                            rdoprename2.SelectedValue = dr("prename2")
                        Case "other"
                            rdoprename2.SelectedValue = "other"
                            txtprename2.Text = dr("prename2")
                        Case Else
                            rdoprename2.SelectedValue = "other"
                            txtprename2.Text = dr("prename2")
                    End Select
                End If

                If Not dr("name2") Is DBNull.Value Then
                    txtname2.Text = dr("name2")
                End If

                If Not dr("surname2") Is DBNull.Value Then
                    txtsurname2.Text = dr("surname2")
                End If

                If Not dr("spare_2_licensedriver_photo") Is DBNull.Value Then
                    hidPhotoNameLicense2.Value = dr("spare_2_licensedriver_photo")
                End If


                If Not dr("spare_2_license_exp_date") Is DBNull.Value Then
                    txtexp_license_no2.Text = Format(Month(dr("spare_2_license_exp_date")), "00") & "/" & Format(Day(dr("spare_2_license_exp_date")), "00") & "/" & Year(dr("spare_2_license_exp_date"))
                    pScript.Append("$(""#" & txtexp_license_no2.ClientID & """).val('" & txtexp_license_no2.Text & "');")
                End If

                If Not dr("spare_2_passport_no") Is DBNull.Value Then
                    txtpassport2.Text = dr("spare_2_passport_no")
                End If

                If Not dr("spare_2_passport_expire") Is DBNull.Value Then
                    'txtexp_pass_date2.Text = Format(dr("spare_2_passport_expire"), "yyyy-MM-dd")
                    txtexp_pass_date2.Text = Format(Month(dr("spare_2_passport_expire")), "00") & "/" & Format(Day(dr("spare_2_passport_expire")), "00") & "/" & Year(dr("spare_2_passport_expire"))
                    pScript.Append("$(""#" & txtexp_pass_date2.ClientID & """).val('" & txtexp_pass_date2.Text & "');")
                End If

                If Not dr("spare_2_passport_photo") Is DBNull.Value Then
                    hidPhotoNamePassport2.Value = dr("spare_2_passport_photo")
                End If

                If Not dr("spare_2_national") Is DBNull.Value Then
                    ddlnational2.SelectedValue = dr("spare_2_national")
                End If

                If Not dr("spare_2_license_no") Is DBNull.Value Then
                    txtlicense_no2.Text = dr("spare_2_license_no")
                End If

                If Not dr("spare_2_address") Is DBNull.Value Then
                    txtaddress_driver2.Text = dr("spare_2_address")
                End If

                If Not dr("spare_2_state") Is DBNull.Value Then
                    txtstate_driver2.Text = dr("spare_2_state")
                End If

                If Not dr("spare_2_country") Is DBNull.Value Then
                    ddlCountry_driver2.SelectedValue = dr("spare_2_country")
                End If

                If Not dr("spare_2_zipcode") Is DBNull.Value Then
                    txtzipcode_driver2.Text = dr("spare_2_zipcode")
                End If

                If Not dr("spare_2_tel") Is DBNull.Value Then
                    txttel_driver2.Text = dr("spare_2_tel")
                End If

                If Not dr("spare_2_email") Is DBNull.Value Then
                    txtemail_driver2.Text = dr("spare_2_email")
                End If

                If Not dr("spare_2_gender") Is DBNull.Value Then

                    If dr("spare_2_gender") = "Female" Then
                        ddlgender2.SelectedValue = "F"
                    Else
                        ddlgender2.SelectedValue = "M"
                    End If

                End If

                If Not dr("plate") Is DBNull.Value Then
                    txtplate.Text = dr("plate")
                End If

                If Not dr("platelocal") Is DBNull.Value Then
                    txtlocal_plate.Text = dr("platelocal")
                End If

                If Not dr("seat") Is DBNull.Value Then
                    ddlSeats.SelectedValue = dr("seat")
                End If

                If Not dr("weight") Is DBNull.Value Then
                    txtweight.Text = Format(CDbl(dr("weight")), "#,###.##")
                End If

                'If Not dr("year") Is DBNull.Value Then
                '    ddlyears.SelectedValue = dr("year")
                'End If

                If Not dr("colors") Is DBNull.Value Then
                    txtcolors.Text = dr("colors")
                End If

                If Not dr("engine_no") Is DBNull.Value Then
                    txtNumEngine.Text = dr("engine_no")
                End If

                If Not dr("car_no") Is DBNull.Value Then
                    txtnumcar.Text = dr("car_no")
                End If

                If Not dr("typecar_id") Is DBNull.Value Then
                    ddltypecar.SelectedValue = dr("typecar_id")
                End If

                If Not dr("province_car") Is DBNull.Value Then
                    txtstate_car.Text = dr("province_car")
                End If

                If Not dr("country_car") Is DBNull.Value Then
                    ddlCountryCar.SelectedValue = dr("country_car")
                End If

                If Not dr("engine_cap") Is DBNull.Value Then
                    txtEngine_cap.Text = dr("engine_cap")
                End If

                If Not dr("passportcar_no") Is DBNull.Value Then
                    txtpass_car.Text = dr("passportcar_no")
                End If

                If Not dr("passportcar_expire") Is DBNull.Value Then
                    'txtexp_pass_car_date.Text = Format(dr("passportcar_expire"), "yyyy-MM-dd")
                    txtexp_pass_car_date.Text = Format(Month(dr("passportcar_expire")), "00") & "/" & Format(Day(dr("passportcar_expire")), "00") & "/" & Year(dr("passportcar_expire"))
                    pScript.Append("$(""#" & txtexp_pass_car_date.ClientID & """).val('" & txtexp_pass_car_date.Text & "');")
                End If

                If Not dr("owner_name") Is DBNull.Value Then
                    txtowner.Text = dr("owner_name")
                End If

                If Not dr("owner_idcard") Is DBNull.Value Then
                    txtowner_id_card.Text = dr("owner_idcard")
                End If

                If Not dr("owner_address") Is DBNull.Value Then
                    txtaddress_owner.Text = dr("owner_address")
                End If

                If Not dr("owner_tel") Is DBNull.Value Then
                    txttel_owner.Text = dr("owner_tel")
                End If

                If Not dr("holder_name") Is DBNull.Value Then
                    txtholder.Text = dr("holder_name")
                End If

                If Not dr("holder_idcard") Is DBNull.Value Then
                    txtholder_id_card.Text = dr("holder_idcard")
                End If

                If Not dr("holder_address") Is DBNull.Value Then
                    txtaddress_holder.Text = dr("holder_address")
                End If

                If Not dr("holder_tel") Is DBNull.Value Then
                    txttel_holder.Text = dr("holder_tel")
                End If

                If Not dr("act_no") Is DBNull.Value Then
                    txtinsure_no.Text = dr("act_no")
                End If

                'If Not dr("act_name") Is DBNull.Value Then
                '    txtinsure_name.Text = dr("act_name")
                'End If

                If Not dr("act_tankno") Is DBNull.Value Then
                    txtcar_no.Text = dr("act_tankno")
                End If

                If Not dr("act_company") Is DBNull.Value Then
                    txtcompany.Text = dr("act_company")
                End If

                If Not dr("act_start") Is DBNull.Value Then
                    'txtstart_date.Text = Format(dr("act_start"), "yyyy-MM-dd")
                    txtstart_date.Text = Format(Month(dr("act_start")), "00") & "/" & Format(Day(dr("act_start")), "00") & "/" & Year(dr("act_start"))
                    pScript.Append("$(""#" & txtstart_date.ClientID & """).val('" & txtstart_date.Text & "');")
                End If

                If Not dr("act_ends") Is DBNull.Value Then
                    'txtend_date.Text = Format(dr("act_ends"), "yyyy-MM-dd")
                    txtend_date.Text = Format(Month(dr("act_ends")), "00") & "/" & Format(Day(dr("act_ends")), "00") & "/" & Year(dr("act_ends"))
                    pScript.Append("$(""#" & txtend_date.ClientID & """).val('" & txtend_date.Text & "');")
                End If

                If Not dr("checkin_id") Is DBNull.Value Then
                    ddlBorderCheckin.SelectedValue = dr("checkin_id")
                End If

                If Not dr("checkout_id") Is DBNull.Value Then
                    ddlBorderCheckout.SelectedValue = dr("checkout_id")
                End If

                If Not dr("admin_id") Is DBNull.Value Then
                    ddlformarea.SelectedValue = dr("admin_id")
                End If

                'If Not dr("licensedriver_photo") Is DBNull.Value Then
                '    imageFilelicense_no.ImageUrl = fpathstrIMGDriver & dr("licensedriver_photo")
                '    Hyperlicense_no.NavigateUrl = "../ViewImage.aspx?fpath=FilePhotoDriver&ImageType=" & dr("licensedriver_photo")
                'Else
                '    imageFilelicense_no.Visible = False
                '    Hyperlicense_no.Visible = False
                'End If

                'If Not dr("passport_photo") Is DBNull.Value Then
                '    imageFilepassport.ImageUrl = fpathstrIMGDriver & dr("passport_photo")
                '    Hyperpassport.NavigateUrl = "../ViewImage.aspx?fpath=FilePhotoDriver&ImageType=" & dr("passport_photo")
                'Else
                '    imageFilepassport.Visible = False
                '    Hyperpassport.Visible = False
                'End If

            End If
            dr.Close()

            'Dim dbConnect As New DBConnect

            ''รูปถ่ายรถ
            'strsql = "select gid , file_name from car_pic where car_id = " & car_id
            'Dim DataTableimg As DataTable = dbConnect.getDataTable(strsql, "car_pic")
            'With DataTableimg.Columns
            '    .Add(New DataColumn("PathImg"))
            '    .Add(New DataColumn("LinkImg"))
            'End With
            'For Each nrow As DataRow In DataTableimg.Rows
            '    nrow("PathImg") = fpathstrIMGCar & nrow("file_name")
            '    nrow("LinkImg") = "../ViewImage.aspx?fpath=FileVehicle&ImageType=" & nrow("file_name")
            'Next
            'If DataTableimg.Rows.Count > 0 Then

            '    DtlImg_car.DataSource = DataTableimg
            '    DtlImg_car.DataBind()
            'End If

            Dim sqlstr As String

            'อัพโหลดรูปภาพ 
            sqlstr = "select gid , car_id , file_name from car_pic WHERE car_id = '" & hidcar_id.Value & "' "

            Dim DataTable As DataTable = dbconect.getDataTable(sqlstr, "DataTable")
            With DataTable.Columns
                .Add(New DataColumn("PathImg"))
            End With

            For Each nrow As DataRow In DataTable.Rows
                nrow("PathImg") = "~/Upload/Vehicle/" & nrow("file_name")
            Next

            If DataTable.Rows.Count > 0 Then
                gvFile.DataSource = DataTable
                gvFile.DataBind()

                DtlImg.DataSource = DataTable
                DtlImg.DataBind()
            End If


        Catch ex As Exception
            Dim ppScript As String = " alert('เกิดข้อผิดพลาด:: " & ex.Message & " ไม่สามารถเรียกข้อมูลแผนงานได้'); "
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", ppScript, True)
        Finally
            cmd.Connection.Close()
            con = Nothing
        End Try

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", pScript.ToString, True)



    End Sub

    Protected Sub btnUploadCar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadCar.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload2.PostedFile.FileName <> "" Then
            If FileUpload2.HasFile Then
                srcName = Path.GetFileName(FileUpload2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Upload/Vehicle/") + srcName & srcExt)
                hidPhotonamecar.Value = srcName & srcExt
                PhotoCar.ImageUrl = "~/Upload/Vehicle/" & hidPhotonamecar.Value
                PhotoCar.Visible = False
                btnUploadCar.Visible = True
                FileUpload2.Visible = True
                'PhotoCarDelete.Visible = True
                Try
                    Dim nrow As DataRow = tbImage.NewRow
                    nrow.Item("gid") = tbImage.Rows.Count + 1
                    nrow.Item("car_id") = Session("car_id")
                    nrow.Item("file_name") = hidPhotonamecar.Value
                    nrow.Item("PathImg") = PhotoCar.ImageUrl
                    tbImage.Rows.Add(nrow)
                    nrow = Nothing
                    gvFile.DataSource = tbImage
                    gvFile.DataBind()

                    DtlImg.DataSource = tbImage
                    DtlImg.DataBind()
                    UpdgvFile.Update()

                Catch ex As Exception
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep2", "tab_active(3);", True)
                End Try
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep2", "tab_active(3);", True)

            End If
        End If
    End Sub

    Protected Sub PhotoCarDelete_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) 'Handles PhotoCarDelete.Command
        Try
            Dim FileID As Integer = e.CommandArgument
            Dim nrow As DataRow = tbImage.Select("gid=" & FileID)(0)
            If File.Exists(fPathCar & nrow("file_name")) Then
                File.Delete(fPathCar & nrow("file_name"))
            End If
            tbImage.Select("gid=" & FileID)(0).Delete()
            gvFile.DataSource = tbImage
            gvFile.DataBind()
            DtlImg.DataSource = tbImage
            DtlImg.DataBind()
            UpdgvFile.Update()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep2", "tab_active(3);", True)
        End Try
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep2", "tab_active(3);", True)
    End Sub


    '''อัพโหลด และ ลบ รูป พาสปอร์ต
    Protected Sub PhotoDeletePassport_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeletePassport.Command
        If File.Exists(fPathPassport & hidPhotoNamePassport.Value) Then
            File.Delete(fPathPassport & hidPhotoNamePassport.Value)
        End If
        btnUploadPassport.Visible = True
        FileUpload1.Visible = True
        hidPhotoNamePassport.Value = ""
        PhotoPassport.Visible = False
        PhotoDeletePassport.Visible = False
    End Sub


    Protected Sub btnUploadPassport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadPassport.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload1.PostedFile.FileName <> "" Then
            If FileUpload1.HasFile Then
                srcName = Path.GetFileName(FileUpload1.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload1.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload/Passport/") + srcName & srcExt)
                hidPhotoNamePassport.Value = srcName & srcExt
                PhotoPassport.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport.Value
                PhotoPassport.Visible = True
                btnUploadPassport.Visible = False
                FileUpload1.Visible = False
                PhotoDeletePassport.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptPassportStep1", "tab_active(1);", True)
            End If
        End If
    End Sub

    Protected Sub PhotoDeletePassport1_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeletePassport1.Command
        If File.Exists(fPathPassport & hidPhotoNamePassport1.Value) Then
            File.Delete(fPathPassport & hidPhotoNamePassport1.Value)
        End If
        btnUploadPassport1.Visible = True
        FileUpload7.Visible = True
        hidPhotoNamePassport1.Value = ""
        PhotoPassport1.Visible = False
        PhotoDeletePassport1.Visible = False

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptDelPassport1Step2", "tab_active(2);", True)
    End Sub


    Protected Sub btnUploadPassport1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadPassport1.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload7.PostedFile.FileName <> "" Then
            If FileUpload7.HasFile Then
                srcName = Path.GetFileName(FileUpload7.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload7.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload7.PostedFile.SaveAs(Server.MapPath("~/Upload/Passport/") + srcName & srcExt)
                hidPhotoNamePassport1.Value = srcName & srcExt
                PhotoPassport1.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport1.Value
                PhotoPassport1.Visible = True
                btnUploadPassport1.Visible = False
                FileUpload7.Visible = False
                PhotoDeletePassport1.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptPassport1Step2", "tab_active(2);", True)
            End If
        End If
    End Sub

    Protected Sub PhotoDeletePassport2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeletePassport2.Command
        If File.Exists(fPathPassport & hidPhotoNamePassport2.Value) Then
            File.Delete(fPathPassport & hidPhotoNamePassport2.Value)
        End If
        btnUploadPassport2.Visible = True
        FileUpload6.Visible = True
        hidPhotoNamePassport2.Value = ""
        PhotoPassport2.Visible = False
        PhotoDeletePassport2.Visible = False

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptDelPassport2Step2", "tab_active(2);", True)
    End Sub


    Protected Sub btnUploadPassport2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadPassport2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload6.PostedFile.FileName <> "" Then
            If FileUpload6.HasFile Then
                srcName = Path.GetFileName(FileUpload6.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload6.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload6.PostedFile.SaveAs(Server.MapPath("~/Upload/Passport/") + srcName & srcExt)
                hidPhotoNamePassport2.Value = srcName & srcExt
                PhotoPassport2.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport2.Value
                PhotoPassport2.Visible = True
                btnUploadPassport2.Visible = False
                FileUpload6.Visible = False
                PhotoDeletePassport2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptPassport2Step2", "tab_active(2);", True)
            End If
        End If
    End Sub

    '''อัพโหลด และ ลบ รูป ใบอนุญาตขับรถ
    Protected Sub PhotoDeleteLicense_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteLicense.Command
        If File.Exists(fPathLicense & hidPhotoNameLicense.Value) Then
            File.Delete(fPathLicense & hidPhotoNameLicense.Value)
        End If
        btnUploadLicense.Visible = True
        FileUpload3.Visible = True
        hidPhotoNameLicense.Value = ""
        PhotoLicense.Visible = False
        PhotoDeleteLicense.Visible = False
    End Sub

    Protected Sub btnUploadLicense_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadLicense.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload3.PostedFile.FileName <> "" Then
            If FileUpload3.HasFile Then
                srcName = Path.GetFileName(FileUpload3.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload3.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload3.PostedFile.SaveAs(Server.MapPath("~/Upload/LicenseDriver/") + srcName & srcExt)
                hidPhotoNameLicense.Value = srcName & srcExt
                PhotoLicense.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense.Value
                PhotoLicense.Visible = True
                btnUploadLicense.Visible = False
                FileUpload3.Visible = False
                PhotoDeleteLicense.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptPhotoStep1", "tab_active(1);", True)
            End If
        End If
    End Sub

    Protected Sub PhotoDeleteLicense1_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteLicense1.Command
        If File.Exists(fPathLicense & hidPhotoNameLicense1.Value) Then
            File.Delete(fPathLicense & hidPhotoNameLicense1.Value)
        End If
        btnUploadLicense1.Visible = True
        FileUpload4.Visible = True
        hidPhotoNameLicense1.Value = ""
        PhotoLicense1.Visible = False
        PhotoDeleteLicense1.Visible = False

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptDelPhoto1Step2", "tab_active(2);", True)
    End Sub

    Protected Sub btnUploadLicense1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadLicense1.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload4.PostedFile.FileName <> "" Then
            If FileUpload4.HasFile Then
                srcName = Path.GetFileName(FileUpload4.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload4.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload4.PostedFile.SaveAs(Server.MapPath("~/Upload/LicenseDriver/") + srcName & srcExt)
                hidPhotoNameLicense1.Value = srcName & srcExt
                PhotoLicense1.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense1.Value
                PhotoLicense1.Visible = True
                btnUploadLicense1.Visible = False
                FileUpload4.Visible = False
                PhotoDeleteLicense1.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptPhoto1Step2", "tab_active(2);", True)
            End If
        End If
    End Sub

    Protected Sub PhotoDeleteLicense2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteLicense2.Command
        If File.Exists(fPathLicense & hidPhotoNameLicense2.Value) Then
            File.Delete(fPathLicense & hidPhotoNameLicense2.Value)
        End If
        btnUploadLicense2.Visible = True
        FileUpload5.Visible = True
        hidPhotoNameLicense2.Value = ""
        PhotoLicense2.Visible = False
        PhotoDeleteLicense2.Visible = False

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptDelPhoto1Step2", "tab_active(2);", True)
    End Sub

    Protected Sub btnUploadLicense2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadLicense2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload5.PostedFile.FileName <> "" Then
            If FileUpload5.HasFile Then
                srcName = Path.GetFileName(FileUpload5.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload5.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload5.PostedFile.SaveAs(Server.MapPath("~/Upload/LicenseDriver/") + srcName & srcExt)
                hidPhotoNameLicense2.Value = srcName & srcExt
                PhotoLicense2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense2.Value
                PhotoLicense2.Visible = True
                btnUploadLicense2.Visible = False
                FileUpload5.Visible = False
                PhotoDeleteLicense2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptPhoto2Step2", "tab_active(2);", True)
            End If
        End If
    End Sub


    Protected Sub lnkNext1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext1.Click
        If txtname.Text.Trim = "" Or txtsurname.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please specify name!!'); </script>", False)
        ElseIf txtid_code.Text.Trim = "" Or txtemail_driver.Text.Trim = "" Or txttel_driver.Text.Trim = "" Or txtaddress_driver.Text.Trim = "" Or txtpassport.Text.Trim = "" Or txtexp_pass_date.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please fill up this form!!'); </script>", False)
        ElseIf hidPhotoNameLicense.Value = "" Or hidPhotoNamePassport.Value = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please upload photo!!'); </script>", False)
        Else
            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Dim strError As String = ""
            Dim arr As Array
            Dim tmp_date As String
            Try
                con.Open()
                cmd.Connection = con


                'Dim strUpdate As String = "update driver set idcard_no = :idcard_no, countries = :countries, passport_no = :passport_no, passport_expire = :passport_expire " & _
                '    " , prename = :prename, national = :national, birthday = :birthday, name = :name, surname = :surname, other_information = :other_information, gender = :gender " & _
                '    " , address = :address, thailicense_no = :thailicense_no, license_expire = :license_expire, email = :email, tel = :tel, modified_user = :modified_user, modified_date = now() where driver_id = " & hiddriver_id.Value


                Dim strUpdate As String = "update driver set idcard_no = :idcard_no, passport_no = :passport_no, passport_expire = :passport_expire " & _
                    " , prename = :prename, national = :national, birthday = :birthday, name = :name, surname = :surname, other_information = :other_information, gender = :gender " & _
                    " , address = :address, state = :state, countries = :countries, zipcode = :zipcode, thailicense_no = :thailicense_no, license_expire = :license_expire, email = :email, tel = :tel, passport_photo = :passport_photo " & _
                    " , licensedriver_photo = :licensedriver_photo, modified_user = :modified_user, modified_date = now() where driver_id = " & hiddriver_id.Value
                cmd.CommandText = strUpdate
                cmd.Parameters.Clear()
                'cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CDate(txtexp_license_no.Text)
                cmd.Parameters.Add("idcard_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtid_code.Text
                cmd.Parameters.Add("countries", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlcountry_driver.SelectedItem.Text
                cmd.Parameters.Add("passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtpassport.Text
                If txtexp_pass_date.Text = "" Then
                    cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                Else
                    arr = txtexp_pass_date.Text.Split("/")
                    tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                    'cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtexp_pass_date.Text)
                    cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                End If
                cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(rdoprename.SelectedValue = "other", IIf(txtprename.Text.Trim = "", Nothing, txtprename.Text), rdoprename.SelectedValue) 'rdoprename.SelectedValue
                'cmd.Parameters.Add("prename_other", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtprename.Text.Trim = "", Nothing, txtprename.Text)
                cmd.Parameters.Add("national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlnational.SelectedItem.Text
                If txtdate.Text = "" Then
                    cmd.Parameters.Add("birthday", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                Else
                    arr = txtdate.Text.Split("/")
                    tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                    'cmd.Parameters.Add("birthday", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtdate.Text)
                    cmd.Parameters.Add("birthday", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                End If
                cmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtname.Text
                cmd.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtsurname.Text
                cmd.Parameters.Add("other_information", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtinfo.Text.Trim = "", Nothing, txtinfo.Text)
                cmd.Parameters.Add("gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlgender.SelectedItem.Text
                cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtaddress_driver.Text
                cmd.Parameters.Add("state", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtstate_driver.Text
                cmd.Parameters.Add("countries", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountry_driver.SelectedItem.Text
                cmd.Parameters.Add("zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtzipcode_driver.Text
                cmd.Parameters.Add("thailicense_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtlicense_no.Text.Trim = "", Nothing, txtlicense_no.Text)
                If txtexp_license_no.Text.Trim = "" Then
                    cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                Else
                    arr = txtexp_license_no.Text.Split("/")
                    tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                    'cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtexp_license_no.Text)
                    cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                End If
                cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtemail_driver.Text
                cmd.Parameters.Add("tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txttel_driver.Text
                cmd.Parameters.Add("passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport.Value
                cmd.Parameters.Add("licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense.Value
                cmd.Parameters.Add("modified_user", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("user_id")
                cmd.ExecuteNonQuery()

                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep1", "tab_active(2);", True)
            Catch ex As Exception
                Dim scriptError As String = "alert('เกิดข้อผิดพลาด:: " & ex.Message.ToString.Replace("'", "") & " ไม่สามารถบันทึกข้อมูลได้');tab_active(1);"
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScriptAddHideProgress", scriptError, True)
            Finally
                cmd.Connection.Close()
                con.Close()

            End Try
        End If

    End Sub


    Protected Sub btnNext2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext2.Click

        If hiddriver_id.Value = "0" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please fill up form 1!!'); tab_active(1);</script>", False)
        Else
            If txtname1.Text.Trim = "" And txtsurname1.Text.Trim = "" And txtname2.Text.Trim = "" And txtsurname2.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep2", "tab_active(3);", True)
            Else
                If (txtname1.Text.Trim <> "" Or txtsurname1.Text.Trim <> "") And (hidPhotoNamePassport1.Value = "" Or hidPhotoNameLicense1.Value = "") Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please upload photo!!'); tab_active(2); </script>", False)
                ElseIf (txtname2.Text.Trim <> "" Or txtsurname2.Text.Trim <> "") And (hidPhotoNamePassport2.Value = "" Or hidPhotoNameLicense2.Value = "") Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please upload photo!!'); tab_active(2); </script>", False)
                    'ElseIf txtpassport1.Text.Trim = "" Or txtpassport2.Text.Trim = "" Or txtlicense_no1.Text.Trim = "" Or txtlicense_no2.Text.Trim = "" Then
                    '    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please fill up this form!!'); tab_active(2);</script>", False)
                Else
                    Dim cmd As New NpgsqlCommand
                    Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
                    Dim strError As String = ""
                    Dim arr As Array
                    Dim tmp_date As String
                    Try
                        con.Open()
                        cmd.Connection = con

                        'Dim strUpdate As String = " update spare_driver set prename = :prename, name = :name, surname = :surname, license_no = :license_no, national = :national " & _
                        '    " , passport_no = :passport_no, passport_expire = :passport_expire where sparedriver_id = :sparedriver_id "

                        Dim strUpdate As String = " update spare_driver set  prename = :prename, name = :name, surname = :surname, license_no = :license_no, national = :national " & _
                                        " , passport_no = :passport_no, passport_expire = :passport_expire, passport_photo = :passport_photo, licensedriver_photo = :licensedriver_photo " & _
                                        " , address = :address, state = :state, country = :country, zipcode = :zipcode, tel = :tel, email = :email, gender = :gender " & _
                                        " , license_exp_date = :license_exp_date where sparedriver_id = :sparedriver_id "

                        cmd.CommandText = strUpdate
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(rdoprename1.SelectedValue = "other", IIf(txtprename1.Text.Trim = "", Nothing, txtprename1.Text), rdoprename1.SelectedValue) 'rdoprename1.SelectedValue
                        'cmd.Parameters.Add("prename_other", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtprename.Text.Trim = "", Nothing, txtprename.Text)
                        cmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtname1.Text
                        cmd.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtsurname1.Text
                        cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtlicense_no1.Text
                        'cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CDate(txtexp_license_no.Text)
                        cmd.Parameters.Add("national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlnational1.SelectedItem.Text
                        'cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
                        cmd.Parameters.Add("passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtpassport1.Text
                        If txtexp_pass_date1.Text.Trim = "" Then
                            cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                        Else
                            arr = txtexp_pass_date1.Text.Split("/")
                            tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                            'cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtexp_pass_date1.Text)
                            cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                        End If
                        'cmd.Parameters.Add("spare_ord", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
                        cmd.Parameters.Add("passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport1.Value
                        cmd.Parameters.Add("licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense1.Value
                        cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtaddress_driver1.Text
                        cmd.Parameters.Add("state", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtstate_driver1.Text
                        cmd.Parameters.Add("country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountry_driver1.SelectedItem.Text
                        cmd.Parameters.Add("zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtzipcode_driver1.Text
                        cmd.Parameters.Add("tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txttel_driver1.Text
                        cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtemail_driver1.Text
                        cmd.Parameters.Add("gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlgender1.SelectedItem.Text
                        If txtexp_license_no1.Text.Trim = "" Then
                            cmd.Parameters.Add("license_exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                        Else
                            arr = txtexp_license_no1.Text.Split("/")
                            tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                            'cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtexp_license_no1.Text)
                            cmd.Parameters.Add("license_exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                        End If
                        cmd.Parameters.Add("sparedriver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidsparedriver_id1.Value

                        cmd.ExecuteNonQuery()

                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(rdoprename2.SelectedValue = "other", IIf(txtprename2.Text.Trim = "", Nothing, txtprename2.Text), rdoprename2.SelectedValue) 'rdoprename2.SelectedValue
                        'cmd.Parameters.Add("prename_other", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtprename.Text.Trim = "", Nothing, txtprename.Text)
                        cmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtname2.Text
                        cmd.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtsurname2.Text
                        cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtlicense_no2.Text
                        'cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CDate(txtexp_license_no.Text)
                        cmd.Parameters.Add("national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlnational2.SelectedItem.Text
                        'cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
                        cmd.Parameters.Add("passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtpassport2.Text
                        If txtexp_pass_date2.Text.Trim = "" Then
                            cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                        Else
                            arr = txtexp_pass_date2.Text.Split("/")
                            tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                            'cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtexp_pass_date2.Text)
                            cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                        End If
                        'cmd.Parameters.Add("spare_ord", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                        cmd.Parameters.Add("passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport2.Value
                        cmd.Parameters.Add("licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense2.Value
                        cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtaddress_driver2.Text
                        cmd.Parameters.Add("state", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtstate_driver2.Text
                        cmd.Parameters.Add("country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountry_driver2.SelectedItem.Text
                        cmd.Parameters.Add("zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtzipcode_driver2.Text
                        cmd.Parameters.Add("tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txttel_driver2.Text
                        cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtemail_driver2.Text
                        cmd.Parameters.Add("gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlgender2.SelectedItem.Text
                        If txtexp_license_no2.Text.Trim = "" Then
                            cmd.Parameters.Add("license_exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                        Else
                            arr = txtexp_license_no2.Text.Split("/")
                            tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                            'cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtexp_license_no1.Text)
                            cmd.Parameters.Add("license_exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                        End If
                        cmd.Parameters.Add("sparedriver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidsparedriver_id2.Value

                        cmd.ExecuteNonQuery()


                        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep2", "tab_active(3);", True)
                    Catch ex As Exception
                        Dim scriptError As String = "alert('เกิดข้อผิดพลาด:: " & ex.Message.ToString.Replace("'", "") & " ไม่สามารถบันทึกข้อมูลได้');tab_active(2);"
                        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScriptAddHideProgress", scriptError, True)
                    Finally
                        cmd.Connection.Close()
                        con.Close()
                    End Try
                End If

            End If


        End If


    End Sub

    Protected Sub btnPrev2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev2.Click

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptPreviousStep1", "tab_active(1);", True)

    End Sub

    Protected Sub lnkNext3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext3.Click

        If hiddriver_id.Value = "0" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please fill up form 1 !!'); tab_active(1);</script>", False)
        Else
            If txtplate.Text.Trim = "" Or txtlocal_plate.Text.Trim = "" Or txtnumcar.Text.Trim = "" Or txtNumEngine.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please fill up this form!!'); tab_active(3);</script>", False)
            Else
                Dim dbConnect As New DBConnect
                Dim cmd As New NpgsqlCommand
                Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
                Dim strError As String = ""
                Dim arr As Array
                Dim tmp_date As String
                Try
                    con.Open()
                    cmd.Connection = con

                    'Dim strUpdate As String = " update car set plate = :plate, platelocal = :platelocal, passportcar_expire = :passportcar_expire, passportcar_no = :passportcar_no, brands = :brands, model = :model " & _
                    '    " , year = :year, seat = :seat, weight = :weight, province_car = :province_car, car_no = :car_no, engine_no = :engine_no, type_car = :type_car, typecar_id = :typecar_id " & _
                    '    " , colors = :colors, owner_name = :owner_name, owner_idcard = :owner_idcard, owner_address = :owner_address, owner_tel = :owner_tel, holder_name = :holder_name " & _
                    '    " , holder_idcard = :holder_idcard, holder_address = :holder_address, holder_tel = :holder_tel, country_car = :country_car, engine_cap = :engine_cap where car_id = " & hidcar_id.Value

                    Dim strUpdate As String = " update car set plate = :plate, platelocal = :platelocal, passportcar_expire = :passportcar_expire, passportcar_no = :passportcar_no, brands = :brands, model = :model " & _
                        " , seat = :seat, weight = :weight, province_car = :province_car, car_no = :car_no, engine_no = :engine_no, type_car = :type_car, typecar_id = :typecar_id " & _
                        " , colors = :colors, owner_name = :owner_name, owner_idcard = :owner_idcard, owner_address = :owner_address, owner_tel = :owner_tel, holder_name = :holder_name " & _
                        " , holder_idcard = :holder_idcard, holder_address = :holder_address, holder_tel = :holder_tel, country_car = :country_car, engine_cap = :engine_cap where car_id = " & hidcar_id.Value

                    cmd.CommandText = strUpdate
                    cmd.Parameters.Clear()

                    cmd.Parameters.Add("plate", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtplate.Text
                    cmd.Parameters.Add("platelocal", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtlocal_plate.Text
                    If txtexp_pass_car_date.Text.Trim = "" Then
                        cmd.Parameters.Add("passportcar_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                    Else
                        arr = txtexp_pass_car_date.Text.Split("/")
                        tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                        'cmd.Parameters.Add("passportcar_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtexp_pass_car_date.Text)
                        cmd.Parameters.Add("passportcar_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                    End If
                    cmd.Parameters.Add("passportcar_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtpass_car.Text
                    cmd.Parameters.Add("brands", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtbrands.Text
                    cmd.Parameters.Add("model", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtmodels.Text
                    'cmd.Parameters.Add("year", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlyears.SelectedValue
                    'cmd.Parameters.Add("idcard_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtname1.Text
                    cmd.Parameters.Add("seat", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlSeats.SelectedValue
                    cmd.Parameters.Add("weight", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtweight.Text.Replace(",", "")
                    cmd.Parameters.Add("province_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtstate_car.Text
                    cmd.Parameters.Add("car_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtnumcar.Text
                    cmd.Parameters.Add("engine_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtNumEngine.Text
                    'cmd.Parameters.Add("act_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtname1.Text
                    'cmd.Parameters.Add("country_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtname1.Text
                    cmd.Parameters.Add("type_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddltypecar.SelectedItem.Text
                    cmd.Parameters.Add("typecar_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddltypecar.SelectedValue
                    cmd.Parameters.Add("colors", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtcolors.Text
                    'cmd.Parameters.Add("authorize_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtname1.Text
                    'cmd.Parameters.Add("regis_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtname1.Text
                    cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtowner.Text
                    cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtowner_id_card.Text
                    cmd.Parameters.Add("owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtaddress_owner.Text
                    cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txttel_owner.Text
                    cmd.Parameters.Add("holder_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtholder.Text
                    cmd.Parameters.Add("holder_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtholder_id_card.Text
                    cmd.Parameters.Add("holder_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtaddress_holder.Text
                    cmd.Parameters.Add("holder_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txttel_holder.Text
                    cmd.Parameters.Add("country_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountryCar.SelectedItem.Text
                    cmd.Parameters.Add("engine_cap", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtEngine_cap.Text
                    cmd.ExecuteNonQuery()

                    Dim strCheckPic = "Select gid from car_pic WHERE car_id = '" & hidcar_id.Value & "'"
                    Dim cRowf As DataRow
                    Dim drRow() As DataRow
                    Dim TbImgOld As New DataTable

                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strCheckPic
                    TbImgOld = dbConnect.getDataTable(strCheckPic, "TbFileOld")

                    '------------อัพโหลดรูป-------------

                    For introw = 0 To tbImage.Rows.Count - 1
                        cRowf = tbImage.Rows(introw)
                        drRow = TbImgOld.Select("gid = " & cRowf("gid"))

                        If drRow.Length > 0 Then
                            cmd.CommandText = "Update car_pic set car_id = :car_id , file_name = :file_name WHERE gid = " & cRowf("gid")
                            TbImgOld.Rows.Remove(drRow(0))
                        Else
                            cmd.CommandText = "Insert Into car_pic ( car_id , file_name) VALUES (:car_id , :file_name) "

                        End If

                        cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidcar_id.Value
                        cmd.Parameters.Add(":file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("file_name")
                        cmd.ExecuteNonQuery()
                    Next

                    '----------ลบรูป---------------

                    For Each cRow In TbImgOld.Rows
                        cmd.Parameters.Clear()
                        cmd.CommandText = "delete from car_pic where gid =" & cRow("gid")
                        cmd.ExecuteScalar()
                    Next


                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep3", "tab_active(4);", True)
                Catch ex As Exception
                    Dim scriptError As String = "alert('เกิดข้อผิดพลาด:: " & ex.Message.ToString.Replace("'", "") & " ไม่สามารถบันทึกข้อมูลได้');tab_active(3);"
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScriptAddHideProgress", scriptError, True)
                Finally
                    cmd.Connection.Close()
                    con.Close()
                End Try
            End If
        End If


    End Sub

    Protected Sub lnkPrev3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrev3.Click

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptPreviousStep2", "tab_active(2);", True)

    End Sub

    Protected Sub lnkNext4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext4.Click

        If hiddriver_id.Value = "0" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please fill up form 1 !!'); tab_active(1);</script>", False)
        Else
            If txtcar_no.Text.Trim = "" Or txtinsure_no.Text.Trim = "" Or txtstart_date.Text.Trim = "" Or txtend_date.Text.Trim = "" Or txtcompany.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please fill up this form!!'); tab_active(4);</script>", False)
            Else
                Dim dbConnect As New DBConnect
                Dim cmd As New NpgsqlCommand
                Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
                Dim strError As String = ""
                Dim arr As Array
                Dim tmp_date As String
                Try
                    con.Open()
                    cmd.Connection = con

                    'Dim strUpdate As String = "update act set act_no = :act_no, act_name = :act_name, act_tankno = :act_tankno, act_start = :act_start, act_ends = :act_ends " & _
                    '    " , act_company = :act_company where act_id = " & hidact_id.Value
                    Dim strUpdate As String = "update act set act_no = :act_no, act_tankno = :act_tankno, act_start = :act_start, act_ends = :act_ends " & _
                        " , act_company = :act_company where act_id = " & hidact_id.Value

                    cmd.CommandText = strUpdate

                    cmd.Parameters.Clear()

                    cmd.Parameters.Add("act_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtinsure_no.Text
                    'cmd.Parameters.Add("act_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtinsure_name.Text
                    cmd.Parameters.Add("act_tankno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtcar_no.Text
                    'cmd.Parameters.Add("act_start", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtstart_date.Text)
                    'cmd.Parameters.Add("act_ends", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtend_date.Text)
                    If txtstart_date.Text.Trim = "" Then
                        cmd.Parameters.Add("act_start", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                    Else
                        arr = txtstart_date.Text.Split("/")
                        tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                        'cmd.Parameters.Add("act_start", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtstart_date.Text)
                        cmd.Parameters.Add("act_start", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                    End If
                    If txtend_date.Text.Trim = "" Then
                        cmd.Parameters.Add("act_ends", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                    Else
                        arr = txtend_date.Text.Split("/")
                        tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                        'cmd.Parameters.Add("act_ends", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtend_date.Text)
                        cmd.Parameters.Add("act_ends", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                    End If
                    cmd.Parameters.Add("act_company", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtcompany.Text

                    cmd.ExecuteNonQuery()


                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep4", "tab_active(6);", True)
                Catch ex As Exception
                    Dim scriptError As String = "alert('เกิดข้อผิดพลาด:: " & ex.Message.ToString.Replace("'", "") & " ไม่สามารถบันทึกข้อมูลได้');tab_active(4);"
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScriptAddHideProgress", scriptError, True)
                Finally
                    cmd.Connection.Close()
                    con.Close()
                End Try
            End If
        End If


    End Sub

    Protected Sub lnkPrev4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrev4.Click

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptPreviousStep3", "tab_active(3);", True)

    End Sub

    Protected Sub lnkSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSubmit.Click

        If hiddriver_id.Value = "0" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please fill up form 1 !!'); tab_active(1);</script>", False)
        Else

            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Dim strError As String = ""
            Try
                con.Open()
                cmd.Connection = con

                Dim strUpdate As String = "update license set checkin_id = :checkin_id, checkout_id = :checkout_id, admin_id = :admin_id where license_id = " & hidlicense_id.Value
                cmd.CommandText = strUpdate
                cmd.Parameters.Clear()
                cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckin.SelectedValue
                cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckout.SelectedValue
                cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlformarea.SelectedValue
                cmd.ExecuteNonQuery()

                Dim sqlstr As String = " select province.prov_code from border_check LEFT JOIN province on province.prov_code = border_check.prov_code " & _
                         " WHERE border_id = '" & ddlBorderCheckin.SelectedValue & "' "
                hidProvince.Value = dbConnect.executeScalar(sqlstr)

                cmd.Parameters.Clear()
                sqlstr = "SELECT count(license_id) from area WHERE license_id = " & hidlicense_id.Value
                If dbConnect.executeScalar(sqlstr) > 0 Then
                    strUpdate = "Update area set prov_code= '" & hidProvince.Value & "' WHERE license_id = " & hidlicense_id.Value
                Else
                    strUpdate = "Insert into area (prov_code , license_id ) VALUES ('" & hidProvince.Value & "' , " & hidlicense_id.Value & " ) "
                End If
                cmd.CommandText = strUpdate
                cmd.ExecuteNonQuery()

                Response.Redirect("index.aspx")
            Catch ex As Exception
                Dim scriptError As String = "alert('เกิดข้อผิดพลาด:: " & ex.Message.ToString.Replace("'", "") & " ไม่สามารถบันทึกข้อมูลได้');tab_active(6);"
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScriptAddHideProgress", scriptError, True)
            Finally
                cmd.Connection.Close()
                con.Close()
            End Try

        End If


    End Sub

    Protected Sub lnkPrev6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrev6.Click

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptPreviousStep4", "tab_active(4);", True)

    End Sub

    ''ออกเลขที่ใบอนุญาติ
    Private Function licenseNo() As String
        Dim sqlstr As String
        Dim DBconnect As New DBConnect
        sqlstr = " SELECT license_id  from ( select max(SUBSTRING(license_no,1,4)) as license_id , MAX(SUBSTRING(license_no,6,4)) as yearid " & _
                 " FROM license ) as dt WHERE yearid like '%" & Now.Year & "%'"
        Dim license_no As String = ""
        Dim no As Integer
        Dim check As String
        check = DBconnect.executeScalar(sqlstr)
        If check = "" Then
            check = 0
        End If
        no = check
        no = no + 1
        Dim length As Integer
        length = no.ToString.Length

        If length = 1 Then
            license_no = "000" & no & "/" & Now.Year
        ElseIf length = 2 Then
            license_no = "00" & no & "/" & Now.Year
        ElseIf length = 3 Then
            license_no = "0" & no & "/" & Now.Year
        ElseIf length = 4 Then
            license_no = "" & no & "/" & Now.Year
        End If

        Return license_no.ToString

    End Function

    'Protected Sub ddlBorderCheckin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim DBconnect As New DBConnect

    '    'Dim sqlstr As String = " select prov_en from border_check " & _
    '    '                       " LEFT JOIN province on province.prov_code = border_check.prov_code " & _
    '    '                       " WHERE border_id = '" & ddlBorderCheckin.SelectedValue & "' "
    '    'lblArea.Text = DBconnect.executeScalar(sqlstr)

    '    'Dim sqlstr2 As String = " select province.prov_code from border_check " & _
    '    '                      " LEFT JOIN province on province.prov_code = border_check.prov_code " & _
    '    '                      " WHERE border_id = '" & ddlBorderCheckin.SelectedValue & "' "
    '    'hidProvince.Value = DBconnect.executeScalar(sqlstr2)

    '    ddlBorderCheckout.SelectedValue = ddlBorderCheckin.SelectedValue

    'End Sub

    'Protected Sub PhotoCarDelete_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) 'Handles PhotoCarDelete.Command
    '    Try
    '        Dim FileID As Integer = e.CommandArgument
    '        Dim nrow As DataRow = tbImage.Select("gid=" & FileID)(0)
    '        If File.Exists(fPathCar & nrow("file_name")) Then
    '            File.Delete(fPathCar & nrow("file_name"))
    '        End If
    '        tbImage.Select("gid=" & FileID)(0).Delete()
    '        gvFile.DataSource = tbImage
    '        gvFile.DataBind()
    '        DtlImg.DataSource = tbImage
    '        DtlImg.DataBind()
    '        UpdgvFile.Update()
    '    Catch ex As Exception
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
    '    End Try

    '    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab_active(3);", True)
    'End Sub


    '#Region 


    '#End Region

    Protected Sub btnUploadedIMG_passport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim nrow As DataRow = tbIMG_2.NewRow
        'nrow.Item("id") = tbIMG_2.Rows.Count + 1
        'nrow.Item("file_name") = hidFNameIMG_2.Value
        'nrow.Item("saved_name") = hidSNameIMG_2.Value
        'nrow("PathImg") = fpathstrIMG & hidSNameIMG_2.Value
        'nrow("LinkImg") = "ViewImage.aspx?fpath=FileSurveyIMG&ImageType=" & hidSNameIMG_2.Value
        'tbIMG_2.Rows.Add(nrow)
        'nrow = Nothing
        'gvIMG_2.DataSource = tbIMG_2
        'gvIMG_2.DataBind()
        'DtlImg_2.DataSource = tbIMG_2
        'DtlImg_2.DataBind()
        'UpdgvIMG_2.Update()
    End Sub

    Protected Sub ImgDelete_passport_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        '    Dim IMGID As Integer = e.CommandArgument
        '    Dim nrow As DataRow = tbIMG_2.Select("id=" & IMGID)(0)
        '    If File.Exists(fpathIMG & nrow("saved_name")) Then
        '        File.Delete(fpathIMG & nrow("saved_name"))
        '    End If

        '    If File.Exists(fpathIMGSmall & nrow("saved_name")) Then
        '        File.Delete(fpathIMGSmall & nrow("saved_name"))
        '    End If

        '    tbIMG_2.Select("id=" & IMGID)(0).Delete()
        '    gvIMG_2.DataSource = tbIMG_2
        '    gvIMG_2.DataBind()

        '    DtlImg_2.DataSource = tbIMG_2
        '    DtlImg_2.DataBind()
        '    Me.UpdgvIMG_2.Update()
    End Sub

    Protected Sub btnUploadedIMG_license_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ImgDelete_license_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub

    Protected Sub btnUploadedIMG_car_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ImgDelete_car_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub

    Protected Sub btnUploaded_consent_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ImgDelete_consent_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub

    Protected Sub btnUploadedIMG_VISA_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub imageFile_VISA_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub

    Protected Sub btnUploaded_car_registration_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ImgDelete_car_registration_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub

    Protected Sub btnUploaded_car_check_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ImgDelete_car_check_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub

    Protected Sub btnUploaded_insure_img_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ImgDelete_insure_img_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub

    Protected Sub btnUploaded_information_file_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ImgDelete_information_file_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub

    Protected Sub btnUploaded_reason_file_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ImgDelete_reason_file_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

    End Sub
End Class
