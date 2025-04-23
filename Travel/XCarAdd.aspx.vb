Imports Npgsql
Imports System.IO
Imports System.Data
Imports System.Drawing
Partial Class Travel_XCarAdd
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
                hiddriver_id.Value = 0
                hidspare_driver_id1.Value = 0
                hidspare_driver_id2.Value = 0
                hidcar_id.Value = 0
                hidact_id.Value = 0


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

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptDelPhoto2Step2", "tab_active(2);", True)
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
                Dim str As String = "'"
                If hiddriver_id.Value = "0" Then
                    str = "INSERT INTO driver( idcard_no, passport_no, passport_expire, prename, national, birthday, name, surname " & _
                        ", other_information, gender, address, state, countries, zipcode, thailicense_no, license_expire, email, tel, passport_photo, licensedriver_photo, added_user, added_date, modified_user, modified_date)" & _
                        " values ( :idcard_no, :passport_no, :passport_expire, :prename, :national, :birthday, :name, :surname " & _
                        ", :other_information, :gender, :address, :state, :countries, :zipcode, :thailicense_no, :license_expire, :email, :tel, :passport_photo, :licensedriver_photo, :added_user, now(), :modified_user, now())  RETURNING driver_id;"
                Else
                    str = "update driver set idcard_no = :idcard_no, passport_no = :passport_no, passport_expire = :passport_expire " & _
                    " , prename = :prename, national = :national, birthday = :birthday, name = :name, surname = :surname, other_information = :other_information, gender = :gender " & _
                    " , address = :address, state = :state, countries = :countries, zipcode = :zipcode, thailicense_no = :thailicense_no, license_expire = :license_expire, email = :email, tel = :tel, passport_photo = :passport_photo " & _
                    " , licensedriver_photo = :licensedriver_photo, modified_user = :modified_user, modified_date = now() where driver_id = " & hiddriver_id.Value
                End If


                cmd.CommandText = str
                cmd.Parameters.Clear()
                'cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CDate(txtexp_license_no.Text)
                cmd.Parameters.Add("idcard_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtid_code.Text
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
                If hiddriver_id.Value = "0" Then
                    cmd.Parameters.Add("added_user", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("user_id")
                End If
                cmd.Parameters.Add("modified_user", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("user_id")
                If hiddriver_id.Value = "0" Then
                    cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
                End If

                cmd.ExecuteNonQuery()

                If hiddriver_id.Value = "0" Then
                    hiddriver_id.Value = cmd.Parameters("driver_id").Value.ToString
                End If


                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep1", "tab_active(2);", True)
            Catch ex As Exception
                Dim scriptError As String = "alert('เกิดข้อผิดพลาด:: " & ex.Message.ToString.Replace("'", "") & " ไม่สามารถบันทึกข้อมูลได้');tab_active(1);"
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScriptAddHideProgress1", scriptError, True)
            Finally
                cmd.Connection.Close()
                con.Close()

            End Try
        End If

        'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep1", "tab_active(2);", True)
    End Sub


    Protected Sub btnNext2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext2.Click

        If hiddriver_id.Value = "0" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please fill up form 1!!'); tab_active(1);</script>", False)
        Else
            If txtname1.Text.Trim = "" And txtsurname1.Text.Trim = "" And txtname2.Text.Trim = "" And txtsurname2.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep2", "tab_active(3);", True)
            Else                If (txtname1.Text.Trim <> "" Or txtsurname1.Text.Trim <> "") And (hidPhotoNamePassport1.Value = "" Or hidPhotoNameLicense1.Value = "") Then
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

                        Dim str As String = ""


                        If hidspare_driver_id1.Value = "0" Then
                            str = " INSERT INTO spare_driver( prename, name, surname, license_no, national, driver_id, passport_no, passport_expire, spare_ord, passport_photo, licensedriver_photo, " & _
                                        " address, state, country, zipcode, tel, email, gender, license_exp_date) " & _
                                        " values ( :prename, :name, :surname, :license_no, :national, :driver_id, :passport_no, :passport_expire, :spare_ord, :passport_photo, :licensedriver_photo, " & _
                                        " :address, :state, :country, :zipcode, :tel, :email, :gender, :license_exp_date) RETURNING sparedriver_id;"
                        Else
                            str = " update spare_driver set  prename = :prename, name = :name, surname = :surname, license_no = :license_no, national = :national, driver_id = :driver_id " & _
                                        " , passport_no = :passport_no, passport_expire = :passport_expire, spare_ord = :spare_ord, passport_photo = :passport_photo, licensedriver_photo = :licensedriver_photo " & _
                                        " , address = :address, state = :state, country = :country, zipcode = :zipcode, tel = :tel, email = :email, gender = :gender " & _
                                        " , license_exp_date = :license_exp_date where sparedriver_id = " & hidspare_driver_id1.Value
                        End If

                        cmd.CommandText = str

                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(rdoprename1.SelectedValue = "other", IIf(txtprename1.Text.Trim = "", Nothing, txtprename1.Text), rdoprename1.SelectedValue) 'rdoprename1.SelectedValue
                        'cmd.Parameters.Add("prename_other", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtprename.Text.Trim = "", Nothing, txtprename.Text)
                        cmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtname1.Text
                        cmd.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtsurname1.Text
                        cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtlicense_no1.Text
                        'cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CDate(txtexp_license_no.Text)
                        cmd.Parameters.Add("national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlnational1.SelectedItem.Text
                        cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
                        cmd.Parameters.Add("passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtpassport1.Text
                        If txtexp_pass_date1.Text.Trim = "" Then
                            cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                        Else
                            arr = txtexp_pass_date1.Text.Split("/")
                            tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                            'cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtexp_pass_date1.Text)
                            cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                        End If
                        cmd.Parameters.Add("spare_ord", NpgsqlTypes.NpgsqlDbType.Integer).Value = 1
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
                        If hidspare_driver_id1.Value = "0" Then
                            cmd.Parameters.Add("sparedriver_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
                        End If

                        cmd.ExecuteNonQuery()

                        If hidspare_driver_id1.Value = "0" Then
                            hidspare_driver_id1.Value = cmd.Parameters("sparedriver_id").Value.ToString
                        End If

                      

                        If hidspare_driver_id2.Value = "0" Then
                            str = " INSERT INTO spare_driver( prename, name, surname, license_no, national, driver_id, passport_no, passport_expire, spare_ord, passport_photo, licensedriver_photo, " & _
                                        " address, state, country, zipcode, tel, email, gender, license_exp_date) " & _
                                        " values ( :prename, :name, :surname, :license_no, :national, :driver_id, :passport_no, :passport_expire, :spare_ord, :passport_photo, :licensedriver_photo, " & _
                                        " :address, :state, :country, :zipcode, :tel, :email, :gender, :license_exp_date) RETURNING sparedriver_id;"
                        Else
                            str = " update spare_driver set  prename = :prename, name = :name, surname = :surname, license_no = :license_no, national = :national, driver_id = :driver_id " & _
                                        " , passport_no = :passport_no, passport_expire = :passport_expire, spare_ord = :spare_ord, passport_photo = :passport_photo, licensedriver_photo = :licensedriver_photo " & _
                                        " , address = :address, state = :state, country = :country, zipcode = :zipcode, tel = :tel, email = :email, gender = :gender " & _
                                        " , license_exp_date = :license_exp_date where sparedriver_id = " & hidspare_driver_id2.Value
                        End If

                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(rdoprename2.SelectedValue = "other", IIf(txtprename2.Text.Trim = "", Nothing, txtprename2.Text), rdoprename2.SelectedValue) 'rdoprename2.SelectedValue
                        'cmd.Parameters.Add("prename_other", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtprename.Text.Trim = "", Nothing, txtprename.Text)
                        cmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtname2.Text
                        cmd.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtsurname2.Text
                        cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtlicense_no2.Text
                        'cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CDate(txtexp_license_no.Text)
                        cmd.Parameters.Add("national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlnational2.SelectedItem.Text
                        cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
                        cmd.Parameters.Add("passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtpassport2.Text
                        If txtexp_pass_date2.Text.Trim = "" Then
                            cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = Nothing
                        Else
                            arr = txtexp_pass_date2.Text.Split("/")
                            tmp_date = arr(2) & "-" & arr(0) & "-" & arr(1)
                            'cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(txtexp_pass_date2.Text)
                            cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = CDate(tmp_date)
                        End If
                        cmd.Parameters.Add("spare_ord", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
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
                        If hidspare_driver_id2.Value = "0" Then
                            cmd.Parameters.Add("sparedriver_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
                        End If

                        cmd.ExecuteNonQuery()

                        If hidspare_driver_id2.Value = "0" Then
                            hidspare_driver_id2.Value = cmd.Parameters("sparedriver_id").Value.ToString
                        End If


                        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep2", "tab_active(3);", True)
                    Catch ex As Exception
                        Dim scriptError As String = "alert('เกิดข้อผิดพลาด:: " & ex.Message.ToString.Replace("'", "") & " ไม่สามารถบันทึกข้อมูลได้');tab_active(2);"
                        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScriptAddHideProgress2", scriptError, True)
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

                    Dim str As String = ""
                 

                    If hidcar_id.Value = "0" Then
                        str = " INSERT INTO car( plate, platelocal, passportcar_expire, passportcar_no, brands, model, seat, weight, province_car, car_no, engine_no, " & _
                                            " type_car, typecar_id, colors, owner_name, owner_idcard, owner_address, owner_tel, holder_name, holder_idcard, holder_address, holder_tel , country_car, engine_cap) " & _
                                            " values ( :plate, :platelocal, :passportcar_expire, :passportcar_no, :brands, :model, :seat, :weight, :province_car, :car_no, :engine_no, " & _
                                            " :type_car, :typecar_id, :colors, :owner_name, :owner_idcard, :owner_address, :owner_tel, :holder_name, :holder_idcard, :holder_address, :holder_tel , :country_car, :engine_cap) RETURNING car_id;"
                    Else
                        str = " update car set plate = :plate, platelocal = :platelocal, passportcar_expire = :passportcar_expire, passportcar_no = :passportcar_no, brands = :brands, model = :model " & _
                                            " , seat = :seat, weight = :weight, province_car = :province_car, car_no = :car_no, engine_no = :engine_no, type_car = :type_car, typecar_id = :typecar_id " & _
                                            " , colors = :colors, owner_name = :owner_name, owner_idcard = :owner_idcard, owner_address = :owner_address, owner_tel = :owner_tel, holder_name = :holder_name " & _
                                            " , holder_idcard = :holder_idcard, holder_address = :holder_address, holder_tel = :holder_tel, country_car = :country_car, engine_cap = :engine_cap where car_id = " & hidcar_id.Value
                    End If



                    cmd.CommandText = str

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
                    If hidcar_id.Value = "0" Then
                        cmd.Parameters.Add("car_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
                    End If

                    cmd.ExecuteNonQuery()
                    If hidcar_id.Value = "0" Then
                        hidcar_id.Value = cmd.Parameters("car_id").Value.ToString
                    End If



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
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "AlertScriptAddHideProgress3", scriptError, True)
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
            If txtinsure_no.Text.Trim = "" Or txtstart_date.Text.Trim = "" Or txtend_date.Text.Trim = "" Or txtcompany.Text.Trim = "" Then
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

                    Dim str As String = ""
                   

                    If hidact_id.Value = "0" Then
                        str = " INSERT INTO act(  act_no, act_tankno, act_start, act_ends, act_company) " & _
                                                " values ( :act_no, :act_tankno, :act_start, :act_ends, :act_company) RETURNING act_id;"
                    Else
                        str = " update act set act_no = :act_no, act_tankno = :act_tankno, act_start = :act_start, act_ends = :act_ends " & _
                                                " , act_company = :act_company where act_id = " & hidact_id.Value
                    End If


                    cmd.CommandText = str

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
                    If hidact_id.Value = "0" Then
                        cmd.Parameters.Add("act_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
                    End If

                    cmd.ExecuteNonQuery()
                    If hidact_id.Value = "0" Then
                        hidact_id.Value = cmd.Parameters("act_id").Value.ToString
                    End If

                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep4", "tab_active(6);", True)
                Catch ex As Exception
                    Dim scriptError As String = "alert('เกิดข้อผิดพลาด:: " & ex.Message.ToString.Replace("'", "") & " ไม่สามารถบันทึกข้อมูลได้');tab_active(4);"
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScriptAddHideProgress4", scriptError, True)
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

             
                Dim strInsert As String = " INSERT INTO license( car_id, driver_id, status_id, checkin_id, checkout_id, regis_date, typeuser_id, travel_id, act_id, admin_id) " & _
                                        " values ( :car_id, :driver_id, :status_id, :checkin_id, :checkout_id, :regis_date, :typeuser_id, :travel_id, :act_id, :admin_id) RETURNING license_id;"
                cmd.CommandText = strInsert

                cmd.Parameters.Clear()

                cmd.Parameters.Add("car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidcar_id.Value
                cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
                cmd.Parameters.Add("status_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
                'cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Date).Value =
                cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckin.SelectedValue
                cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckout.SelectedValue
                'cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Varchar).Value =
                'cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Varchar).Value =
                cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Now.Date
                cmd.Parameters.Add("typeuser_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
                'cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = licenseNo()
                'cmd.Parameters.Add("qrcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value =
                cmd.Parameters.Add("travel_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("user_id")
                cmd.Parameters.Add("act_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidact_id.Value
                cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
                cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlformarea.SelectedValue
                cmd.ExecuteNonQuery()

                hidlicense_id.Value = cmd.Parameters("license_id").Value.ToString
                'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep3", "tab_active(4);", True)

                Dim strUpdate As String = "update license set token = :token where license_id = " & hidlicense_id.Value
                cmd.CommandText = strUpdate
                cmd.Parameters.Clear()
                cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.Token(hidlicense_id.Value, hidcar_id.Value)
                cmd.ExecuteNonQuery()

                Dim sqlstr As String = " select province.prov_code from border_check LEFT JOIN province on province.prov_code = border_check.prov_code " & _
                          " WHERE border_id = '" & ddlBorderCheckin.SelectedValue & "' "
                hidProvince.Value = dbConnect.executeScalar(sqlstr)

              

                cmd.Parameters.Clear()
                cmd.CommandText = "Insert into area (prov_code , license_id ) VALUES ('0' , " & hidlicense_id.Value & " ) "
                cmd.ExecuteNonQuery()


                Response.Redirect("index.aspx")
            Catch ex As Exception
                Dim scriptError As String = "alert('เกิดข้อผิดพลาด:: " & ex.Message.ToString.Replace("'", "") & " ไม่สามารถบันทึกข้อมูลได้');tab_active(6);"
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScriptAddHideProgress6", scriptError, True)
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


    '#Region 


    '#End Region

    Protected Sub btnUploadedIMG_passport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      
    End Sub

    Protected Sub ImgDelete_passport_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
     
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
