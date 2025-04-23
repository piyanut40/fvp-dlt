Imports Npgsql
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Globalization



Partial Class RenewPermit
    Inherits System.Web.UI.Page
    Protected statusth As String
    Protected Img As String
    Protected name As String
    Protected Headername As String


    Dim fPath As String = Server.MapPath(ConfigurationManager.AppSettings("FilePhotoDriver"))
    Dim fPathCar As String = Server.MapPath(ConfigurationManager.AppSettings("FileVehicle"))
    Dim fPathLicense As String = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver"))
    Dim fPathPassport As String = Server.MapPath(ConfigurationManager.AppSettings("FilePassport"))
    Dim fPathRegiscar As String = Server.MapPath(ConfigurationManager.AppSettings("FileRegisterCar"))
    Dim fPathAct As String = Server.MapPath(ConfigurationManager.AppSettings("FileAct"))
    Dim fPathAuthorize As String = Server.MapPath(ConfigurationManager.AppSettings("FileAuthorize"))


    Private populate As New PopulateDropDown
    Dim checktab As Integer

    Private tbImage As New DataTable
    Private tbSpareDriver As New DataTable
    Private tbProvice As New DataTable
    Dim strprov_code As String = ""





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("regis") = "1" Then
            Headername = "Apply for a Permit (Myanmar/Cambodia)"
            lblProv0.Visible = False
        ElseIf Request.QueryString("regis") = "2" Then
            Headername = "Sign Up for Private Vehicle (Cambodia/Myanmar)"
            lblProv0.Visible = False
        ElseIf Request.QueryString("regis") = "3" Then
            Headername = "Apply for International Permit (Laos)"
            pnLaos.Visible = False
            pnLao2.Visible = False
        ElseIf Request.QueryString("regis") = "4" Then
            Headername = "Apply for International Agreement Personal Vehicle (Malaysia/Singapore)"
        End If
        If Page.IsPostBack = False Then

            If Request.QueryString("Page") = "0" Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script1", "tab1();", True)
            ElseIf Request.QueryString("Page") = "1" Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
            ElseIf Request.QueryString("Page") = "2" Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab3();", True)
            ElseIf Request.QueryString("Page") = "3" Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab4();", True)
            ElseIf Request.QueryString("Page") = "4" Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab5();", True)
            ElseIf Request.QueryString("Page") = "8" Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab6();", True)
            End If

            loaddata()
            populate.genDDLCountry(ddlCountry, False)
            populate.genDDLNationality(ddlNational, False)

            populate.genDDLCountry(ddlCountry2, False)
            populate.genDDLNationality(ddlNational2, False)

            populate.genDDLCountry(ddlCountry3, False)
            populate.genDDLNationality(ddlNational3, False)
            populate.genDDLProvince(ddlProvarea, False)
            populate.genDDLCountry(ddlOwnerCountry, False)
            'populate.genDDLCountry(ddlCountryCar, False)
            'populate.genDDLTypeCar(ddlTypecar, False)
            'populate.genDDLBrandCar(ddlBrandcar, False)
            If Request.QueryString("regis") = "1" Or Request.QueryString("regis") = "2" Then
                If Request.QueryString("country") = "1" Then
                    populate.genDDLBorder(ddlBorderCheckin, False, "Myanmar")
                Else
                    populate.genDDLBorder(ddlBorderCheckin, False, "Cambodia")
                End If
                ddladmin.Enabled = False
                lnkSchMap.Visible = False
            ElseIf Request.QueryString("regis") = "3" Then
                populate.genDDLBorder(ddlBorderCheckin, False, "Lao")

            ElseIf Request.QueryString("regis") = "4" Then
                populate.genDDLBorder(ddlBorderCheckin, False, "Malaysia")
            End If

            'populate.genDDLBorder(ddlBorderCheckout, False)
            'populate.genDDLProvince(ddlAreaUse, False)
            'populate.genDDLNationality(ddlNationnalSpare, False)
            'populate.genAreaform(ddlformarea, False)
            populate.gencolors(ddlColor)
            'populate.genDDLNationality(ddlNationnalSpare, False)
            'populate.genDDLCountry(ddlCountrySpare, False)
            populate.genAreaform(ddladmin, False)
            AddPopupMapAdmin("")

            If Request.QueryString("regis") = "1" Then
                ddlCountryCar.Items.Add(New ListItem("Myanmar", "Myanmar"))
                ddlCountryCar.Items.Add(New ListItem("Cambodia", "Cambodia"))
                If Request.QueryString("country") = "1" Then
                    ddlNational.SelectedValue = "Burmese"
                    ddlNational2.SelectedValue = "Burmese"
                    ddlNational3.SelectedValue = "Burmese"
                    ddlCountry.SelectedValue = "Myanmar"
                    ddlCountry2.SelectedValue = "Myanmar"
                    ddlCountry3.SelectedValue = "Myanmar"
                    ddlCountryCar.SelectedValue = "Myanmar"

                Else
                    ddlNational.SelectedValue = "Cambodian"
                    ddlNational2.SelectedValue = "Cambodian"
                    ddlNational3.SelectedValue = "Cambodian"
                    ddlCountry.SelectedValue = "Cambodia"
                    ddlCountry2.SelectedValue = "Cambodia"
                    ddlCountry3.SelectedValue = "Cambodia"
                    ddlCountryCar.SelectedValue = "Cambodia"
                End If
            ElseIf Request.QueryString("regis") = "2" Then
                ddlCountryCar.Items.Add(New ListItem("Myanmar", "Myanmar"))
                ddlCountryCar.Items.Add(New ListItem("Cambodia", "Cambodia"))
                If Request.QueryString("country") = "1" Then
                    ddlNational.SelectedValue = "Burmese"
                    ddlNational2.SelectedValue = "Burmese"
                    ddlNational3.SelectedValue = "Burmese"
                    ddlCountry.SelectedValue = "Myanmar"
                    ddlCountry2.SelectedValue = "Myanmar"
                    ddlCountry3.SelectedValue = "Myanmar"
                    ddlCountryCar.SelectedValue = "Myanmar"
                Else
                    ddlNational.SelectedValue = "Cambodian"
                    ddlNational2.SelectedValue = "Cambodian"
                    ddlNational3.SelectedValue = "Cambodian"
                    ddlCountry.SelectedValue = "Cambodia"
                    ddlCountry2.SelectedValue = "Cambodia"
                    ddlCountry3.SelectedValue = "Cambodia"
                    ddlCountryCar.SelectedValue = "Cambodia"
                End If
            ElseIf Request.QueryString("regis") = "3" Then
                ddlCountryCar.Items.Add(New ListItem("Lao", "Lao"))
                ddlNational.SelectedValue = "Lao"
                ddlNational2.SelectedValue = "Lao"
                ddlNational3.SelectedValue = "Lao"
                ddlCountry.SelectedValue = "Lao"
                ddlCountry2.SelectedValue = "Lao"
                ddlCountry3.SelectedValue = "Lao"
                receive.Visible = False
                UpdatePanel6.Visible = False
                UpdatePanel9.Visible = False
            ElseIf Request.QueryString("regis") = "4" Then
                ddlCountryCar.Items.Add(New ListItem("Malaysia", "Malaysia"))
                ddlCountryCar.Items.Add(New ListItem("Singapore", "Singapore"))
                receive.Visible = False
                If Request.QueryString("country") = "1" Then
                    ddlNational.SelectedValue = "Malaysian"
                    ddlNational2.SelectedValue = "Malaysian"
                    ddlNational3.SelectedValue = "Malaysian"
                    ddlCountry.SelectedValue = "Malaysia"
                    ddlCountry2.SelectedValue = "Malaysia"
                    ddlCountry3.SelectedValue = "Malaysia"
                Else
                    ddlNational.SelectedValue = "Singaporean"
                    ddlNational2.SelectedValue = "Singaporean"
                    ddlNational3.SelectedValue = "Singaporean"
                    ddlCountry.SelectedValue = "Singapore"
                    ddlCountry2.SelectedValue = "Singapore"
                    ddlCountry3.SelectedValue = "Singapore"
                End If
                receive.Visible = False
            End If

            ddlCountryCar.Enabled = False

            Dim db As New DBConnect
            Dim prov_code As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
            Dim admin_id As Object = db.executeScalar("select admin_id from admin where prov_code = '" & prov_code & "'")
            ddladmin.SelectedValue = admin_id



        End If

        With tbImage
            .Columns.Add("gid")
            .Columns.Add("car_id")
            .Columns.Add("file_name")
            .Columns.Add("PathImg")
            .Columns.Add("ImgType")
        End With

        For Each row As GridViewRow In gvFile.Rows
            Dim nrow As DataRow = tbImage.NewRow
            nrow("gid") = CType(row.Cells(0).FindControl("lblID"), Label).Text
            nrow("car_id") = CType(row.Cells(0).FindControl("lblCarid"), Label).Text
            nrow("file_name") = CType(row.Cells(0).FindControl("lblfile_name"), Label).Text
            nrow("PathImg") = CType(row.Cells(0).FindControl("lblPathImg"), Label).Text
            nrow("ImgType") = CType(row.Cells(0).FindControl("lblImgType"), Label).Text
            tbImage.Rows.Add(nrow)
        Next

        With tbProvice
            .Columns.Add("area_id")
            .Columns.Add("prov_en")
            .Columns.Add("prov_code")
        End With


        For Each row As GridViewRow In gvProv.Rows
            Dim nrow As DataRow = tbProvice.NewRow
            nrow("area_id") = CType(row.Cells(0).FindControl("lblarea_id"), Label).Text
            nrow("prov_code") = CType(row.Cells(0).FindControl("lblprov_code"), Label).Text
            nrow("prov_en") = CType(row.Cells(0).FindControl("lblprov_en"), Label).Text
            tbProvice.Rows.Add(nrow)
        Next

        If Request.QueryString("regis") = "1" Or Request.QueryString("regis") = "2" Then
            If tbProvice.Rows.Count = 0 Then
                'หน้ารถประจำถิ่นมากกว่า 1 จังหวัด ต้องบวก จังหวัด ที่อิง ตามด่านแล้ว 1 จังหวัดเข้าไปครับ!!!
                Dim db As New DBConnect
                Try
                    Dim prov_code As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
                    Dim prov_en As Object = db.executeScalar("select prov_en from province where prov_code = ( select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue & ") ")

                    tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)
                    gvProv.DataSource = tbProvice
                    gvProv.DataBind()

                    UpdatePanel11.Update()
                Catch ex As Exception

                Finally
                    db = Nothing
                End Try
            End If
            If Request.QueryString("regis") = "1" Then
                Paneladd.Visible = False
                ddlProvarea.Visible = False
                If gvProv.Columns.Count > 0 Then
                    Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                    ProvareaDelete.Visible = False
                End If

            End If
        Else
            If Page.IsPostBack = False Then
                tbProvice.Rows.Add(tbProvice.Rows.Count + 1, "All province", "0")
                ddlProvarea.Visible = False
                btnProv.Visible = False
                Paneladd.Visible = False
            End If
            strprov_code = 0
            gvProv.DataSource = tbProvice
            gvProv.DataBind()
            Dim a = gvProv.Columns.Count
            gvProv.Columns(0).Visible = False
        End If

        For Each i As DataRow In tbProvice.Rows
            Try
                ddlProvarea.Items.FindByValue(i("prov_code").ToString).Attributes.Add("disabled", "disabled")
                If Request.QueryString("regis") = "1" Or Request.QueryString("regis") = "2" Then
                    strprov_code = i("prov_code").ToString & ","
                End If
            Catch ex As Exception

            End Try
        Next


        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack10", "get_IframeMap(" & strprov_code & ");", True)







        'คนขับหลัก 
        If hidPhotoNamePassport.Value <> "" Then
            PhotoPassport.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport.Value
            PhotoPassport.Visible = True
            btnUploadPassport.Visible = False
            FileUpload1.Visible = False
            PhotoDeletePassport.Visible = True
        Else
            PhotoPassport.Visible = False
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

        'คนขับสำรองคนที่ 1
        If hidPhotoNamePassport2.Value <> "" Then
            PhotoPassport2.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport2.Value
            PhotoPassport2.Visible = True
            btnUploadPassport2.Visible = False
            FileUploadPassport2.Visible = False
            PhotoDeletePassport2.Visible = True
        Else
            PhotoPassport2.Visible = False
        End If


        If hidPhotoNameLicense2.Value <> "" Then
            PhotoLicense2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense2.Value
            PhotoLicense2.Visible = True
            btnUploadLicense2.Visible = False
            FileUploadLicense2.Visible = False
            PhotoDeleteLicense2.Visible = True
        Else
            PhotoLicense2.Visible = False
        End If

        'คนขับสำรองคนที่ 3
        If hidPhotoNamePassport3.Value <> "" Then
            PhotoPassport3.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport3.Value
            PhotoPassport3.Visible = True
            btnUploadPassport3.Visible = False
            FileUploadPassport3.Visible = False
            PhotoDeletePassport3.Visible = True
        Else
            PhotoPassport3.Visible = False
        End If


        If hidPhotoNameLicense3.Value <> "" Then
            PhotoLicense3.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense3.Value
            PhotoLicense3.Visible = True
            btnUploadLicense3.Visible = False
            FileUploadLicense3.Visible = False
            PhotoDeleteLicense3.Visible = True
        Else
            PhotoLicense3.Visible = False
        End If


        If hidPhotoRegisCar.Value <> "" Then
            PhotoRegisCar.ImageUrl = "~/Upload/RegisterCar/" & hidPhotoRegisCar.Value
            PhotoRegisCar.Visible = True
            btnUploadRegisCar.Visible = False
            FileUpload4.Visible = False
            PhotoDeleteRegisCar.Visible = True
        Else
            PhotoRegisCar.Visible = False
        End If


        If hidPhotoAct.Value <> "" Then
            PhotoAct.ImageUrl = "~/Upload/Act/" & hidPhotoAct.Value
            PhotoAct.Visible = True
            btnUploadAct.Visible = False
            FileUpload5.Visible = False
            PhotoDeleteAct.Visible = True
        Else
            PhotoAct.Visible = False
        End If


        If hidAuthorize.Value <> "" Then
            PhotoAuthorize.ImageUrl = "~/Upload/Authorize/" & hidAuthorize.Value
            PhotoAuthorize.Visible = True
            btnUploadAuthorize.Visible = False
            FileUpload6.Visible = False
            PhotoDeleteAuthorize.Visible = True
        Else
            PhotoAuthorize.Visible = False
        End If

        If ddlPrename.SelectedValue = "Other" Then
            txtPrename.Visible = True
        Else
            txtPrename.Visible = False
        End If



        If ddlCountryCar.SelectedValue = "Myanmar" Then
            populate.genDDLProvinceMyanmar(ddlProvinceRegis, False)
        ElseIf ddlCountryCar.SelectedValue = "Cambodia" Then
            populate.genDDLProvinceCambodia(ddlProvinceRegis, False)
        ElseIf ddlCountryCar.SelectedValue = "Malaysia" Then
            populate.genDDLProvinceMalaysia(ddlProvinceRegis, False)
        ElseIf ddlCountryCar.SelectedValue = "Singapore" Then
            populate.genDDLProvinceSingapore(ddlProvinceRegis, False)
        Else
            ddlProvinceRegis.Visible = False
        End If




    End Sub

    Private Sub AddPopupMapAdmin(ByVal paraMap As String)
        Dim strPopup As String = "javascript:w=window.open(" & _
                        """" & ResolveClientUrl("Map/MapAdmin.aspx?" & paraMap) & """," & _
                        """SearchMapAdminWindow""," & _
                        """" & "location=0,status=0,scrollbars=yes,resizable=no," & _
                        "width=1024,height=780""" & _
                        ");w.focus();"
        lnkSchMap.NavigateUrl = "javascript://"
        lnkSchMap.Attributes.Add("OnClick", strPopup)

    End Sub

    Protected Sub btnSetValueddladmin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetValueddladmin.Click
        ddladmin.SelectedValue = HidValueddladmin.Value
        updateddladmin.Update()
    End Sub

    Protected Sub ddlPrename_SelectIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPrename.SelectedIndexChanged
        If ddlPrename.SelectedValue = "Other" Then
            txtPrename.Visible = True
        Else
            txtPrename.Visible = False
        End If
    End Sub

    Protected Sub ddlCountryCar_SelectIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCountryCar.SelectedIndexChanged
        If ddlCountryCar.SelectedValue = "Myanmar" Then
            populate.genDDLProvinceMyanmar(ddlProvinceRegis, False)
        ElseIf ddlCountryCar.SelectedValue = "Cambodia" Then
            populate.genDDLProvinceCambodia(ddlProvinceRegis, False)
        ElseIf ddlCountryCar.SelectedValue = "Malaysia" Then
            populate.genDDLProvinceMalaysia(ddlProvinceRegis, False)
        ElseIf ddlCountryCar.SelectedValue = "Singapore" Then
            populate.genDDLProvinceSingapore(ddlProvinceRegis, False)
        Else
            ddlProvinceRegis.Visible = False
        End If
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab3();", True)
            End If
        End If
    End Sub
    '''อัพโหลด และ ลบ รูป พาสปอร์ต คนที่2
    Protected Sub PhotoDeletePassport2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeletePassport2.Command
        If File.Exists(fPathPassport & hidPhotoNamePassport2.Value) Then
            File.Delete(fPathPassport & hidPhotoNamePassport2.Value)
        End If
        btnUploadPassport2.Visible = True
        FileUploadPassport2.Visible = True
        hidPhotoNamePassport2.Value = ""
        PhotoPassport2.Visible = False
        PhotoDeletePassport2.Visible = False
    End Sub
    Protected Sub btnUploadPassport2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadPassport2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadPassport2.PostedFile.FileName <> "" Then
            If FileUploadPassport2.HasFile Then
                srcName = Path.GetFileName(FileUploadPassport2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadPassport2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUploadPassport2.PostedFile.SaveAs(Server.MapPath("~/Upload/Passport/") + srcName & srcExt)
                hidPhotoNamePassport2.Value = srcName & srcExt
                PhotoPassport2.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport2.Value
                PhotoPassport2.Visible = True
                btnUploadPassport2.Visible = False
                FileUploadPassport2.Visible = False
                PhotoDeletePassport2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab3();", True)
            End If
        End If
    End Sub
    '''อัพโหลด และ ลบ รูป พาสปอร์ต คนที่3
    Protected Sub PhotoDeletePassport3_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeletePassport3.Command
        If File.Exists(fPathPassport & hidPhotoNamePassport3.Value) Then
            File.Delete(fPathPassport & hidPhotoNamePassport3.Value)
        End If
        btnUploadPassport3.Visible = True
        FileUploadPassport3.Visible = True
        hidPhotoNamePassport3.Value = ""
        PhotoPassport3.Visible = False
        PhotoDeletePassport3.Visible = False
    End Sub
    Protected Sub btnUploadPassport3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadPassport3.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadPassport3.PostedFile.FileName <> "" Then
            If FileUploadPassport3.HasFile Then
                srcName = Path.GetFileName(FileUploadPassport3.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadPassport3.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUploadPassport3.PostedFile.SaveAs(Server.MapPath("~/Upload/Passport/") + srcName & srcExt)
                hidPhotoNamePassport3.Value = srcName & srcExt
                PhotoPassport3.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport2.Value
                PhotoPassport3.Visible = True
                btnUploadPassport3.Visible = False
                FileUploadPassport3.Visible = False
                PhotoDeletePassport3.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab3();", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab3();", True)
            End If
        End If
    End Sub



    '''อัพโหลด และ ลบ รูป ใบอนุญาตขับรถ คนที่2
    Protected Sub PhotoDeleteLicense2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteLicense2.Command
        If File.Exists(fPathLicense & hidPhotoNameLicense2.Value) Then
            File.Delete(fPathLicense & hidPhotoNameLicense2.Value)
        End If
        btnUploadLicense2.Visible = True
        FileUploadLicense2.Visible = True
        hidPhotoNameLicense2.Value = ""
        PhotoLicense2.Visible = False
        PhotoDeleteLicense2.Visible = False
    End Sub

    Protected Sub btnUploadLicense2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadLicense2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadLicense2.PostedFile.FileName <> "" Then
            If FileUploadLicense2.HasFile Then
                srcName = Path.GetFileName(FileUploadLicense2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadLicense2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUploadLicense2.PostedFile.SaveAs(Server.MapPath("~/Upload/LicenseDriver/") + srcName & srcExt)
                hidPhotoNameLicense2.Value = srcName & srcExt
                PhotoLicense2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense2.Value
                PhotoLicense2.Visible = True
                btnUploadLicense2.Visible = False
                FileUploadLicense2.Visible = False
                PhotoDeleteLicense2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab3();", True)
            End If
        End If
    End Sub



    '''อัพโหลด และ ลบ รูป ใบอนุญาตขับรถ คนที่3
    Protected Sub PhotoDeleteLicense3_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteLicense3.Command
        If File.Exists(fPathLicense & hidPhotoNameLicense3.Value) Then
            File.Delete(fPathLicense & hidPhotoNameLicense3.Value)
        End If
        btnUploadLicense3.Visible = True
        FileUploadLicense3.Visible = True
        hidPhotoNameLicense3.Value = ""
        PhotoLicense3.Visible = False
        PhotoDeleteLicense3.Visible = False
    End Sub

    Protected Sub btnUploadLicense3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadLicense3.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadLicense3.PostedFile.FileName <> "" Then
            If FileUploadLicense3.HasFile Then
                srcName = Path.GetFileName(FileUploadLicense3.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadLicense3.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUploadLicense3.PostedFile.SaveAs(Server.MapPath("~/Upload/LicenseDriver/") + srcName & srcExt)
                hidPhotoNameLicense3.Value = srcName & srcExt
                PhotoLicense3.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense3.Value
                PhotoLicense3.Visible = True
                btnUploadLicense3.Visible = False
                FileUploadLicense3.Visible = False
                PhotoDeleteLicense3.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab3();", True)
            End If
        End If
    End Sub

    ''อัพโหลด และ ลบ รูปลงทะเบียนรถ
    Protected Sub PhotoDeleteRegisCar_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteRegisCar.Command
        If File.Exists(fPathRegiscar & hidPhotoRegisCar.Value) Then
            File.Delete(fPathRegiscar & hidPhotoRegisCar.Value)
        End If
        btnUploadRegisCar.Visible = True
        FileUpload4.Visible = True
        hidPhotoRegisCar.Value = ""
        PhotoRegisCar.Visible = False
        PhotoDeleteRegisCar.Visible = False
    End Sub

    Protected Sub btnUploadRegisCar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadRegisCar.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload4.PostedFile.FileName <> "" Then
            If FileUpload4.HasFile Then
                srcName = Path.GetFileName(FileUpload4.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload4.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload4.PostedFile.SaveAs(Server.MapPath("~/Upload/RegisterCar/") + srcName & srcExt)
                hidPhotoRegisCar.Value = srcName & srcExt
                PhotoRegisCar.ImageUrl = "~/Upload/RegisterCar/" & hidPhotoRegisCar.Value
                PhotoRegisCar.Visible = True
                btnUploadRegisCar.Visible = False
                FileUpload4.Visible = False
                PhotoDeleteRegisCar.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "tab4();", True)
            End If
        End If
    End Sub

    ''อัพโหลด และ ลบ รูป กรมธรรม์
    Protected Sub PhotoDeleteAct_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteAct.Command
        If File.Exists(fPathAct & hidPhotoAct.Value) Then
            File.Delete(fPathAct & hidPhotoAct.Value)
        End If
        btnUploadAct.Visible = True
        FileUpload5.Visible = True
        hidPhotoAct.Value = ""
        PhotoAct.Visible = False
        PhotoDeleteAct.Visible = False
    End Sub

    Protected Sub btnUploadAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadAct.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload5.PostedFile.FileName <> "" Then
            If FileUpload5.HasFile Then
                srcName = Path.GetFileName(FileUpload5.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload5.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload5.PostedFile.SaveAs(Server.MapPath("~/Upload/Act/") + srcName & srcExt)
                hidPhotoAct.Value = srcName & srcExt
                PhotoAct.ImageUrl = "~/Upload/Act/" & hidPhotoAct.Value
                PhotoAct.Visible = True
                btnUploadAct.Visible = False
                FileUpload5.Visible = False
                PhotoDeleteAct.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script6", "tab5();", True)
            End If
        End If
    End Sub

    ''อัพโหลด และ ลบ รูป หนังสือยินยอมให้ใช้รถ
    Protected Sub PhotoDeleteAuthorize_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteAuthorize.Command
        If File.Exists(fPathAuthorize & hidAuthorize.Value) Then
            File.Delete(fPathAuthorize & hidAuthorize.Value)
        End If
        btnUploadAuthorize.Visible = True
        FileUpload6.Visible = True
        hidAuthorize.Value = ""
        PhotoAuthorize.Visible = False
        PhotoDeleteAuthorize.Visible = False
    End Sub

    Protected Sub btnUploadAuthorize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadAuthorize.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload6.PostedFile.FileName <> "" Then
            If FileUpload6.HasFile Then
                srcName = Path.GetFileName(FileUpload6.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload6.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload6.PostedFile.SaveAs(Server.MapPath("~/Upload/Authorize/") + srcName & srcExt)
                hidAuthorize.Value = srcName & srcExt
                PhotoAuthorize.ImageUrl = "~/Upload/Authorize/" & hidAuthorize.Value
                PhotoAuthorize.Visible = True
                btnUploadAuthorize.Visible = False
                FileUpload6.Visible = False
                PhotoDeleteAuthorize.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script10", "tab4();", True)
            End If
        End If
    End Sub

    ''อัพโหลดและลบ รูปรถ
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
                    nrow.Item("ImgType") = ddlImgtype.SelectedItem.Text
                    tbImage.Rows.Add(nrow)
                    nrow = Nothing
                    gvFile.DataSource = tbImage
                    gvFile.DataBind()

                    DtlImg.DataSource = tbImage
                    DtlImg.DataBind()
                    UpdgvFile.Update()

                Catch ex As Exception
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
                End Try
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script7", "tab4();", True)

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
        End Try

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script8", "tab4();", True)
    End Sub
    Protected Sub ddladmin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddladmin.SelectedIndexChanged
        'Page_Load(sender, e)
    End Sub




    '' Event ปุ่ม Next และ ปุ่ม Prev
    Private Sub loaddata()
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con
            Dim strCheckUser As String = " SELECT driver.driver_id , passport_no , passport_expire , birthday , license_id , car.car_id , act.act_id , is_send ," & _
                                         " comments_tab0 , comments_tab1 , comments_tab2 , comments_tab3 , comments_tab4 , comments_tab8 ," & _
                                         " check_tab0 , check_tab1 , check_tab2 , check_tab3 , check_tab4 , check_tab8" & _
                                         "  from driver " & _
                                         " LEFT JOIN license on driver.driver_id = license.driver_id " & _
                                         " LEFT JOIN car on license.car_id = car.car_id " & _
                                         " LEFT JOIN act on license.act_id = act.act_id " & _
                                         " WHERE license.token like '%" & Request.QueryString("token") & "%'"
            cmd.CommandText = CommandType.Text
            cmd.CommandText = strCheckUser
            dread = cmd.ExecuteReader()
            If dread.Read Then

                'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptAlert", "alertDataOld();", True)
                Page0.Enabled = False
                If dread("check_tab0") = 1 Then
                    lblcomments0.Visible = False
                End If


                If dread("check_tab1") = 1 Then
                    Page1.Enabled = False
                    lblcomments1.Visible = False
                End If

                If dread("check_tab2") = 1 Then
                    Page2.Enabled = False
                    lblcomments2.Visible = False
                End If

                If dread("check_tab3") = 1 Then
                    Page3.Enabled = False
                    lblcomments3.Visible = False
                End If


                If dread("check_tab4") = 1 Then
                    Page4.Enabled = False
                    lblcomments4.Visible = False
                End If

                If dread("check_tab8") = 1 Then
                    Page8.Enabled = False
                    lblcomments8.Visible = False
                End If


                If dread("comments_tab0") IsNot DBNull.Value Then
                    lblcomments0.Text = " *Comments : " & dread("comments_tab0")
                End If

                If dread("comments_tab1") IsNot DBNull.Value Then
                    lblcomments1.Text = " *Comments : " & dread("comments_tab1")
                End If

                If dread("comments_tab2") IsNot DBNull.Value Then
                    lblcomments2.Text = " *Comments : " & dread("comments_tab2")
                End If

                If dread("comments_tab3") IsNot DBNull.Value Then
                    lblcomments3.Text = " *Comments : " & dread("comments_tab3")
                End If

                If dread("comments_tab4") IsNot DBNull.Value Then
                    lblcomments4.Text = " *Comments : " & dread("comments_tab4")
                End If

                If dread("comments_tab8") IsNot DBNull.Value Then
                    lblcomments8.Text = " *Comments : " & dread("comments_tab8")
                End If


                Session("driver_id") = dread("driver_id")
                Session("car_id") = dread("car_id")
                Session("license_id") = dread("license_id")
                Session("act_id") = dread("act_id")
                dread.Close()
                loadoldData()
            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
        Finally
            cmd.Connection.Close()
            con.Close()
            dbConnect = Nothing
            con.Dispose()
            cmd.Dispose()

        End Try
    End Sub

    Protected Sub btnNext1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext1.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2();", True)
    End Sub
    Protected Sub ddlOwnerPrename_SelectIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlOwnerPrename.SelectedIndexChanged
        If ddlOwnerPrename.SelectedValue = "Other" Then
            txtOwnerPrename.Visible = True
        Else
            txtOwnerPrename.Visible = False
        End If
    End Sub

    Protected Sub btnNext2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext2.Click
        If Session("car_id") Then
            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Dim dread As Npgsql.NpgsqlDataReader
            Try
                con.Open()
                cmd.Connection = con
                Dim strCheckCar = " SELECT car.car_id from car  LEFT JOIN license on license.car_id = car.car_id WHERE license_id = '" & Session("license_id") & "' "
                cmd.CommandText = CommandType.Text
                cmd.CommandText = strCheckCar
                dread = cmd.ExecuteReader()
                If dread.Read Then
                    If dread("car_id") Then
                        Session("car_id") = dread("car_id")
                    End If
                    dread.Close()
                    Dim strUpdate = "Update car set owner_name=:owner_name , owner_idcard=:owner_idcard , owner_address=:owner_address , owner_tel=:owner_tel " & _
                                    " , owner_lastname=:owner_lastname , owner_province =:owner_province , owner_zipcode =:owner_zipcode , owner_country =:owner_country  WHERE car_id = '" & Session("car_id") & "'"
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strUpdate
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerName.Text.Trim = "", Nothing, txtOwnerName.Text)
                    cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerIdcard.Text.Trim = "", Nothing, txtOwnerIdcard.Text)
                    cmd.Parameters.Add("owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerAddress.Text.Trim = "", Nothing, txtOwnerAddress.Text)
                    cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnertel.Text.Trim = "", Nothing, txtOwnertel.Text)
                    cmd.Parameters.Add("owner_lastname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerLastName.Text = "", Nothing, txtOwnerLastName.Text)
                    cmd.Parameters.Add("owner_province", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerProvince.Text = "", Nothing, txtOwnerProvince.Text)
                    cmd.Parameters.Add("owner_zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerZipcode.Text = "", Nothing, txtOwnerZipcode.Text)
                    cmd.Parameters.Add("owner_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlOwnerCountry.SelectedValue
                    cmd.ExecuteNonQuery()

                End If

            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
            Finally
                cmd.Connection.Close()
                con.Close()
                dbConnect = Nothing
                con.Dispose()
                cmd.Dispose()
            End Try

            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "tab3();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptAlert", "alertDataDriver();", True)
        Else
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
        End If

    End Sub
    Protected Sub btnNext3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext3.Click
        If txtAddress.Text = "" Or txtName.Text = "" Or txtSurname.Text = "" Or txtLicenseExpire.Text = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab3();", True)
        ElseIf hidPhotoNameLicense.Value = "" Or hidPhotoNamePassport.Value = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck2();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab3();", True)
        Else
            If Session("driver_id") Then
                Dim dbConnect As New DBConnect
                Dim cmd As New NpgsqlCommand
                Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
                Dim dread As Npgsql.NpgsqlDataReader
                Try
                    con.Open()
                    cmd.Connection = con
                    Dim strInsert = "Update driver Set prename=:prename , address=:address , name=:name , surname=:surname , license_expire=:license_expire , national=:national , countries=:countries , gender=:gender , passport_photo=:passport_photo , licensedriver_photo=:licensedriver_photo , idcard_no=:idcard_no , county=:county , zipcode=:zipcode  " & _
                        ", tel=:tel , email = :email , passport_no = :passport_no , passport_expire=:passport_expire , birthday=:birthday WHERE driver_id = '" & Session("driver_id") & "'"
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strInsert
                    cmd.Parameters.Clear()
                    If ddlPrename.SelectedValue = "other" Then
                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtPrename.Text
                    Else
                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlPrename.SelectedValue
                    End If


                    cmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtName.Text.Trim = "", Nothing, txtName.Text)
                    cmd.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtSurname.Text.Trim = "", Nothing, txtSurname.Text)
                    cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtAddress.Text.Trim = "", Nothing, txtAddress.Text)
                    cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtLicenseExpire.Text.Trim = "", Nothing, txtLicenseExpire.Text)
                    cmd.Parameters.Add("national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlNational.SelectedItem
                    cmd.Parameters.Add("countries", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountry.SelectedItem
                    cmd.Parameters.Add("gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlGender.SelectedValue
                    cmd.Parameters.Add("passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport.Value
                    cmd.Parameters.Add("licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense.Value
                    cmd.Parameters.Add("idcard_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtIdcardDriver.Text.Trim = "", Nothing, txtIdcardDriver.Text)
                    'cmd.Parameters.Add("state", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtState.Text.Trim = "", Nothing, txtState.Text)
                    cmd.Parameters.Add("county", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtCounty.Text.Trim = "", Nothing, txtCounty.Text)
                    cmd.Parameters.Add("zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtZipcode.Text.Trim = "", Nothing, txtZipcode.Text)
                    cmd.Parameters.Add("tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtTel.Text.Trim = "", Nothing, txtTel.Text)
                    cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtEmail.Text.Trim = "", Nothing, txtEmail.Text)
                    cmd.Parameters.Add("passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtPassport.Text.Trim = "", Nothing, txtPassport.Text)
                    cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtPassportExpire.Text.Trim = "", Nothing, txtPassportExpire.Text)
                    cmd.Parameters.Add("birthday", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtDate.Text.Trim = "", Nothing, txtDate.Text)
                    cmd.ExecuteNonQuery()

                    ' คนขับสำรองคนที่ 2 
                    If txtName2.Text <> "" And txtSurname2.Text <> "" Then
                        Dim strCheckDriver As String = "SELECT sparedriver_id from spare_driver WHERE driver_id = '" & Session("driver_id") & "' and spare_ord = 1"
                        cmd.CommandText = CommandType.Text
                        cmd.CommandText = strCheckDriver
                        cmd.Parameters.Clear()
                        dread = cmd.ExecuteReader()
                        If dread.Read Then
                            cmd.CommandText = "Update spare_driver set  driver_id = :driver_id , prename = :prename , name = :name , surname = :surname , license_no = :license_no , national = :national , licensedriver_photo=:licensedriver_photo ,  " & _
                                                 " address = :address , country = :country , zipcode = :zipcode , tel = :tel , email = :email , gender = :gender , license_exp_date = :license_exp_date , passport_no = :passport_no , passport_expire = :passport_expire , passport_photo =:passport_photo WHERE sparedriver_id = " & dread("sparedriver_id") & " and spare_ord = 1"
                        Else
                            cmd.CommandText = "Insert Into spare_driver ( prename , name , surname , license_no , national , driver_id  , licensedriver_photo , address  , country , zipcode , tel , email , gender , license_exp_date , passport_no , passport_expire , passport_photo , spare_ord ) " & _
                                                 " VALUES (:prename , :name , :surname , :license_no , :national , :driver_id , :licensedriver_photo , :address , :country , :zipcode , :tel , :email , :gender , :license_exp_date , :passport_no , :passport_expire , :passport_photo , 1 ) "
                        End If
                        dread.Close()
                        If ddlPrename2.SelectedValue = "other" Then
                            cmd.Parameters.Add(":prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtPrename2.Text.Trim = "", Nothing, txtPrename2.Text)
                        Else
                            cmd.Parameters.Add(":prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlPrename2.SelectedValue
                        End If
                        cmd.Parameters.Add(":name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtName2.Text.Trim = "", Nothing, txtName2.Text.Trim)
                        cmd.Parameters.Add(":surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtSurname2.Text.Trim = "", Nothing, txtSurname2.Text.Trim)
                        cmd.Parameters.Add(":license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicense2.Text.Trim = "", Nothing, txtLicense2.Text.Trim)
                        cmd.Parameters.Add(":license_exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtLicenseExpire2.Text.Trim = "", Nothing, txtLicenseExpire2.Text.Trim)
                        cmd.Parameters.Add(":passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtPassportNo2.Text.Trim = "", Nothing, txtPassportNo2.Text.Trim)
                        cmd.Parameters.Add(":passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtPassport_exp2.Text.Trim = "", Nothing, txtPassport_exp2.Text.Trim)
                        cmd.Parameters.Add(":address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtAddress2.Text.Trim = "", Nothing, txtAddress2.Text.Trim)
                        'cmd.Parameters.Add(":state", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtState2.Text.Trim = "", Nothing, txtState2.Text.Trim)
                        cmd.Parameters.Add(":country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountry2.SelectedItem
                        cmd.Parameters.Add(":zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtZipcode2.Text.Trim = "", Nothing, txtZipcode2.Text.Trim)
                        cmd.Parameters.Add(":tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtTel2.Text.Trim = "", Nothing, txtTel2.Text.Trim)
                        cmd.Parameters.Add(":email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtEmail2.Text.Trim = "", Nothing, txtEmail2.Text.Trim)
                        cmd.Parameters.Add(":gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlGender2.SelectedValue
                        cmd.Parameters.Add(":national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlNational2.SelectedValue
                        cmd.Parameters.Add(":driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("driver_id")
                        cmd.Parameters.Add(":licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense2.Value
                        cmd.Parameters.Add(":passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport2.Value
                        cmd.ExecuteNonQuery()
                    End If

                    ' คนขับสำรองคนที่ 3
                    If txtName3.Text <> "" And txtSurname3.Text <> "" Then
                        Dim strCheckDriver As String = "SELECT sparedriver_id from spare_driver WHERE driver_id = '" & Session("driver_id") & "' and spare_ord = 2"
                        cmd.CommandText = CommandType.Text
                        cmd.CommandText = strCheckDriver
                        cmd.Parameters.Clear()
                        dread = cmd.ExecuteReader()
                        If dread.Read Then
                            cmd.CommandText = "Update spare_driver set  driver_id = :driver_id , prename = :prename , name = :name , surname = :surname , license_no = :license_no , national = :national , licensedriver_photo=:licensedriver_photo ,  " & _
                                                 " address = :address , country = :country , zipcode = :zipcode , tel = :tel , email = :email , gender = :gender , license_exp_date = :license_exp_date , passport_no = :passport_no , passport_expire = :passport_expire , passport_photo =:passport_photo WHERE sparedriver_id = " & dread("sparedriver_id") & " and spare_ord = 2"
                        Else
                            cmd.CommandText = "Insert Into spare_driver ( prename , name , surname , license_no , national , driver_id  , licensedriver_photo , address , country , zipcode , tel , email , gender , license_exp_date , passport_no , passport_expire , passport_photo , spare_ord ) " & _
                                                 " VALUES (:prename , :name , :surname , :license_no , :national , :driver_id , :licensedriver_photo , :address , :country , :zipcode , :tel , :email , :gender , :license_exp_date , :passport_no , :passport_expire , :passport_photo , 3 ) "
                        End If
                        dread.Close()
                        If ddlPrename3.SelectedValue = "other" Then
                            cmd.Parameters.Add(":prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtPrename3.Text.Trim = "", Nothing, txtPrename3.Text)
                        Else
                            cmd.Parameters.Add(":prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlPrename3.SelectedValue
                        End If
                        cmd.Parameters.Add(":name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtName3.Text.Trim = "", Nothing, txtName3.Text.Trim)
                        cmd.Parameters.Add(":surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtSurname3.Text.Trim = "", Nothing, txtSurname3.Text.Trim)
                        cmd.Parameters.Add(":license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicense3.Text.Trim = "", Nothing, txtLicense3.Text.Trim)
                        cmd.Parameters.Add(":license_exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtLicenseExpire3.Text.Trim = "", Nothing, txtLicenseExpire3.Text.Trim)
                        cmd.Parameters.Add(":passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtPassportNo3.Text.Trim = "", Nothing, txtPassportNo3.Text.Trim)
                        cmd.Parameters.Add(":passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtPassport_exp3.Text.Trim = "", Nothing, txtPassport_exp3.Text.Trim)
                        cmd.Parameters.Add(":address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtAddress3.Text.Trim = "", Nothing, txtAddress3.Text.Trim)
                        'cmd.Parameters.Add(":state", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtState3.Text.Trim = "", Nothing, txtState3.Text.Trim)
                        cmd.Parameters.Add(":country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountry3.SelectedItem
                        cmd.Parameters.Add(":zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtZipcode3.Text.Trim = "", Nothing, txtZipcode3.Text.Trim)
                        cmd.Parameters.Add(":tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtTel3.Text.Trim = "", Nothing, txtTel3.Text.Trim)
                        cmd.Parameters.Add(":email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtEmail3.Text.Trim = "", Nothing, txtEmail3.Text.Trim)
                        cmd.Parameters.Add(":gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlGender3.SelectedItem
                        cmd.Parameters.Add(":national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlNational3.SelectedValue
                        cmd.Parameters.Add(":driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("driver_id")
                        cmd.Parameters.Add(":licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense3.Value
                        cmd.Parameters.Add(":passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport3.Value
                        cmd.ExecuteNonQuery()
                    End If







                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab4();", True)

                Catch ex As Exception
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab3();", True)
                Finally
                    cmd.Connection.Close()
                    con.Close()
                    dbConnect = Nothing
                    con.Dispose()
                    cmd.Dispose()
                End Try

            Else
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            End If
        End If
    End Sub
    Protected Sub btnNext4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext4.Click
        If txtBrands.Text = "" Or txtLicenseCar.Text = "" Or txtOwnerName.Text = "" Or txtOwnerIdcard.Text = "" Or txtOwnerAddress.Text = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab4();", True)
        Else
            If Session("car_id") Then
                Dim dbConnect As New DBConnect
                Dim cmd As New NpgsqlCommand
                Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
                Dim dread As Npgsql.NpgsqlDataReader
                Try
                    con.Open()
                    cmd.Connection = con
                    Dim strCheckCar = " SELECT car.car_id from car  LEFT JOIN license on license.car_id = car.car_id WHERE license_id = '" & Session("license_id") & "' "
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strCheckCar
                    dread = cmd.ExecuteReader()
                    If dread.Read Then
                        If dread("car_id") Then
                            Session("car_id") = dread("car_id")
                        End If

                        dread.Close()
                        Dim strUpdate = "Update car set brands =:brands  , model=:model   , colors =:colors , " & _
                                        " seat=:seat , weight=:weight , car_no=:car_no , country_car=:country_car ," & _
                                        " province_car=:province_car , plate=:plate , engine_no=:engine_no , engine_cap=:engine_cap , owner_name=:owner_name , owner_idcard=:owner_idcard , owner_address=:owner_address , owner_tel=:owner_tel , authorize_car=:authorize_car , regis_photo=:regis_photo , platelocal=:platelocal WHERE car_id = '" & Session("car_id") & "'"
                        Dim strCheckPic = "Select gid from car_pic WHERE car_id = '" & Session("car_id") & "'"

                        cmd.CommandText = CommandType.Text
                        cmd.CommandText = strUpdate
                        cmd.Parameters.Clear()
                        'cmd.Parameters.Add("type_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlTypecar.SelectedValue
                        cmd.Parameters.Add("brands", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtBrands.Text.Trim = "", Nothing, txtBrands.Text)
                        cmd.Parameters.Add("model", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtModel.Text.Trim = "", Nothing, txtModel.Text)
                        'cmd.Parameters.Add("year", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtYears.Text
                        cmd.Parameters.Add("colors", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlColor.SelectedValue
                        'cmd.Parameters.Add("passportcar_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtPassportCar.Text
                        'cmd.Parameters.Add("passportcar_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = txtPassportCarExpire.Text
                        cmd.Parameters.Add("seat", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlSeats.SelectedValue
                        cmd.Parameters.Add("weight", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtWeight.Text.Trim = "", Nothing, txtWeight.Text)
                        cmd.Parameters.Add("car_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtNumcar.Text.Trim = "", Nothing, txtNumcar.Text)
                        cmd.Parameters.Add("country_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(ddlCountryCar.SelectedItem.Value = "", Nothing, ddlCountryCar.SelectedItem.Value)
                        cmd.Parameters.Add("province_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlProvinceRegis.SelectedItem
                        cmd.Parameters.Add("plate", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicenseCar.Text.Trim = "", Nothing, txtLicenseCar.Text)
                        cmd.Parameters.Add("engine_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtNumEngine.Text.Trim = "", Nothing, txtNumEngine.Text)
                        cmd.Parameters.Add("engine_cap", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtEnginCap.Text.Trim = "", Nothing, txtEnginCap.Text)
                        cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerName.Text.Trim = "", Nothing, txtOwnerName.Text)
                        cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerIdcard.Text.Trim = "", Nothing, txtOwnerIdcard.Text)
                        cmd.Parameters.Add("owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerAddress.Text.Trim = "", Nothing, txtOwnerAddress.Text)
                        cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnertel.Text.Trim = "", Nothing, txtOwnertel.Text)
                        cmd.Parameters.Add("platelocal", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicenseLocalCar.Text.Trim = "", Nothing, txtLicenseLocalCar.Text)
                        cmd.Parameters.Add("authorize_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidAuthorize.Value.Trim = "", Nothing, hidAuthorize.Value)
                        cmd.Parameters.Add("regis_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidPhotoRegisCar.Value.Trim = "", Nothing, hidPhotoRegisCar.Value)



                        cmd.ExecuteNonQuery()

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
                                cmd.CommandText = "Update car_pic set car_id = :car_id , file_name = :file_name , imgtype = :imgtype WHERE gid = " & cRowf("gid")
                                TbImgOld.Rows.Remove(drRow(0))
                            Else
                                cmd.CommandText = "Insert Into car_pic ( car_id , file_name , imgtype) VALUES (:car_id , :file_name , :imgtype) "

                            End If

                            cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("car_id")
                            cmd.Parameters.Add(":file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("file_name")
                            cmd.Parameters.Add(":imgtype", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("imgtype")
                            cmd.ExecuteNonQuery()
                        Next

                        '----------ลบรูป---------------

                        For Each cRow In TbImgOld.Rows
                            cmd.Parameters.Clear()
                            cmd.CommandText = "delete from car_pic where gid =" & cRow("gid")
                            cmd.ExecuteScalar()
                        Next




                    End If




                Catch ex As Exception
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
                Finally
                    cmd.Connection.Close()
                    con.Close()
                    dbConnect = Nothing
                    con.Dispose()
                    cmd.Dispose()
                End Try

                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "tab5();", True)
                'loadProvice()
            Else
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            End If

        End If
    End Sub

    Protected Sub btnNext5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext5.Click
        If Session("act_id") Then

            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Try
                con.Open()
                cmd.Connection = con
                Dim strUpdate = "Update act set act_no=:act_no , act_company=:act_company , act_start=:act_start , act_ends=:act_ends , act_photo=:act_photo " & _
                                "WHERE act_id = '" & Session("act_id") & "' "
                cmd.CommandText = CommandType.Text
                cmd.CommandText = strUpdate
                cmd.Parameters.Clear()
                cmd.Parameters.Add("act_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtActNo.Text.Trim = "", Nothing, txtActNo.Text)
                'cmd.Parameters.Add("act_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtActName.Text
                'cmd.Parameters.Add("act_tankno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtActTankNo.Text
                cmd.Parameters.Add("act_start", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtActStart.Text.Trim = "", Nothing, txtActStart.Text)
                cmd.Parameters.Add("act_ends", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtActExpire.Text.Trim = "", Nothing, txtActExpire.Text)
                cmd.Parameters.Add("act_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidPhotoAct.Value.Trim = "", Nothing, hidPhotoAct.Value)
                cmd.Parameters.Add("act_company", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtActCompany.Text.Trim = "", Nothing, txtActCompany.Text)
                cmd.ExecuteNonQuery()
            Catch ex As Exception

            Finally
                cmd.Connection.Close()
                con.Close()
                dbConnect = Nothing
                con.Dispose()
                cmd.Dispose()
            End Try

            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script6", "tab6();", True)
        Else
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab1();", True)
        End If

    End Sub

    'Protected Sub btnPrev1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev1.Click
    '    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab1();", True)
    'End Sub

    Protected Sub btnPrev2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev2.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script6", "tab2();", True)
    End Sub

    Protected Sub btnPrev3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev3.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script8", "tab3();", True)
    End Sub
    Protected Sub btnPrev4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev4.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script9", "tab4();", True)
    End Sub
    Protected Sub btnPrev5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev5.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script10", "tab5();", True)
    End Sub
    Protected Sub btnLoadDriver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadDriver.Click
        Dim array() As String = Split(txtOwnerName.Text, " ")
        txtName.Text = array(0)
        If array.Length > 1 Then
            txtSurname.Text = array(1)
        End If
        txtAddress.Text = txtOwnerAddress.Text
        txtTel.Text = txtOwnertel.Text
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script15", "tab3();", True)
    End Sub
    Protected Sub loadoldData()
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            Dim strHistory = " SELECT passport_no, license.fname , license.lname , license.email as license_email , passport_expire , passport_no , birthday, driver.driver_id , car.car_id, license_id , act.act_id  , countries , driver.prename , driver.national , driver.name , " & _
                             " driver.surname , gender , address , passport_photo , licensedriver_photo , license_expire , idcard_no ,  " & _
                             " type_car , brands , model , colors , seat , car_no , country_car , province_car , " & _
                             " plate , engine_no , weight , owner_name , owner_idcard , owner_address , owner_tel , owner_lastname , owner_province  , owner_zipcode , owner_country , regis_photo , authorize_car , engine_cap , " & _
                             " act_no , act_name , act_company , act_tankno , act_start , act_ends , act_photo , checkin_id , checkout_id , passportcar_no , passportcar_expire ,  " & _
                             " holder_name , holder_address , holder_idcard , holder_tel , state , zipcode , county , platelocal , tel , admin_id , driver.email " & _
                             " from driver " & _
                             " LEFT JOIN license on license.driver_id = driver.driver_id " & _
                             " LEFT JOIN car on car.car_id = license.car_id " & _
                             " LEFT JOIN act on act.act_id = license.act_id " & _
                             " WHERE driver.driver_id = '" & Session("driver_id") & "' and license.status_id = 2"
            cmd.CommandText = strHistory
            dread = cmd.ExecuteReader()
            If dread.Read Then

                If dread("passport_no") IsNot DBNull.Value Then
                    txtPassport.Text = dread("passport_no")
                End If

                If dread("passport_expire") IsNot DBNull.Value Then
                    txtPassportExpire.Text = dread("passport_expire")
                    txtPassportExpire.Text = Format(CDate(txtPassportExpire.Text), "MM/dd/yyyy")
                End If

                If dread("birthday") IsNot DBNull.Value Then
                    txtDate.Text = dread("passport_expire")
                    txtDate.Text = Format(CDate(txtDate.Text), "MM/dd/yyyy")
                End If


                If dread("fname") IsNot DBNull.Value Then
                    txtFname.Text = dread("fname")
                End If

                If dread("lname") IsNot DBNull.Value Then
                    txtLname.Text = dread("lname")
                End If


                If dread("license_email") IsNot DBNull.Value Then
                    txtLicenseEmail.Text = dread("license_email")
                End If

                If dread("admin_id") IsNot DBNull.Value Then
                    ddladmin.SelectedValue = dread("admin_id")
                End If

                Dim paraMap As String = ""
                If dread("admin_id") IsNot DBNull.Value Then
                    ddladmin.SelectedValue = dread("admin_id")
                    paraMap = "admin_id=" & dread("admin_id")
                End If

                AddPopupMapAdmin(paraMap)

                'If dread("state") IsNot DBNull.Value Then
                '    txtState.Text = dread("state")
                'End If

                If dread("zipcode") IsNot DBNull.Value Then
                    txtZipcode.Text = dread("zipcode")
                End If
                If dread("county") IsNot DBNull.Value Then
                    txtCounty.Text = dread("county")
                End If
                If dread("tel") IsNot DBNull.Value Then
                    txtTel.Text = dread("tel")
                End If
                If dread("platelocal") IsNot DBNull.Value Then
                    txtLicenseLocalCar.Text = dread("platelocal")
                End If
                If dread("email") IsNot DBNull.Value Then
                    txtEmail.Text = dread("email")
                End If
              

                If dread("engine_cap") IsNot DBNull.Value Then
                    txtEnginCap.Text = dread("engine_cap")
                End If


                If dread("owner_tel") IsNot DBNull.Value Then
                    txtOwnertel.Text = dread("owner_tel")
                End If


                If dread("driver_id") IsNot DBNull.Value Then
                    Session("driver_id") = dread("driver_id")
                End If
                If dread("car_id") IsNot DBNull.Value Then
                    Session("car_id") = dread("car_id")
                End If
                If dread("license_id") IsNot DBNull.Value Then
                    Session("license_id") = dread("license_id")
                End If
                If dread("act_id") IsNot DBNull.Value Then
                    Session("act_id") = dread("act_id")
                End If
                If dread("countries") IsNot DBNull.Value Then
                    ddlCountry.SelectedValue = dread("countries")
                End If
                If dread("prename") IsNot DBNull.Value Then
                    If (dread("prename") = "Mr." Or dread("prename") = "Ms." Or dread("prename") = "Miss." Or dread("prename") = "Mrs.") Then
                        ddlPrename.SelectedValue = dread("prename")
                    Else
                        ddlPrename.SelectedValue = "other"
                        txtPrename.Visible = True
                        txtPrename.Text = dread("prename")
                    End If
                End If
                If dread("national") IsNot DBNull.Value Then
                    ddlNational.SelectedValue = dread("national")
                End If
                If dread("name") IsNot DBNull.Value Then
                    txtName.Text = dread("name")
                End If
                If dread("surname") IsNot DBNull.Value Then
                    txtSurname.Text = dread("surname")
                End If
                If dread("gender") IsNot DBNull.Value Then
                    ddlGender.SelectedValue = dread("gender")
                End If
                If dread("address") IsNot DBNull.Value Then
                    txtAddress.Text = dread("address")
                End If
                If dread("passport_photo") IsNot DBNull.Value Then
                    hidPhotoNamePassport.Value = dread("passport_photo")
                    PhotoPassport.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport.Value
                    PhotoPassport.Visible = True
                    btnUploadPassport.Visible = False
                    FileUpload1.Visible = False
                    PhotoDeletePassport.Visible = True
                End If
                If dread("license_expire") IsNot DBNull.Value Then
                    txtLicenseExpire.Text = dread("license_expire")
                    txtLicenseExpire.Text = Format(CDate(txtLicenseExpire.Text), "MM/dd/yyyy")
                End If

                If dread("idcard_no") IsNot DBNull.Value Then
                    txtIdcardDriver.Text = dread("idcard_no")
                End If
                If dread("licensedriver_photo") IsNot DBNull.Value Then
                    hidPhotoNameLicense.Value = dread("licensedriver_photo")
                    PhotoLicense.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense.Value
                    PhotoLicense.Visible = True
                    btnUploadLicense.Visible = False
                    FileUpload3.Visible = False
                    PhotoDeleteLicense.Visible = True
                End If
                'If dread("type_car") IsNot DBNull.Value Then
                '    ddlTypecar.Text = dread("type_car")
                'End If
                If dread("brands") IsNot DBNull.Value Then
                    txtBrands.Text = dread("brands")
                End If
                If dread("model") IsNot DBNull.Value Then
                    txtModel.Text = dread("model")
                End If
                If dread("colors") IsNot DBNull.Value Then
                    ddlColor.SelectedValue = dread("colors")
                End If
                If dread("seat") IsNot DBNull.Value Then
                    ddlSeats.SelectedValue = dread("seat")
                End If
                If dread("car_no") IsNot DBNull.Value Then
                    txtNumcar.Text = dread("car_no")
                End If
                If dread("country_car") IsNot DBNull.Value Then
                    ddlCountryCar.SelectedValue = dread("country_car")
                End If

                If dread("plate") IsNot DBNull.Value Then
                    txtLicenseCar.Text = dread("plate")
                End If
                If dread("engine_no") IsNot DBNull.Value Then
                    txtNumEngine.Text = dread("engine_no")
                End If
                If dread("weight") IsNot DBNull.Value Then
                    txtWeight.Text = dread("weight")
                End If

                If dread("owner_name") IsNot DBNull.Value Then
                    txtOwnerName.Text = dread("owner_name")
                End If
                If dread("owner_idcard") IsNot DBNull.Value Then
                    txtOwnerIdcard.Text = dread("owner_idcard")
                End If
                If dread("owner_address") IsNot DBNull.Value Then
                    txtOwnerAddress.Text = dread("owner_address")
                End If
                If dread("owner_lastname") IsNot DBNull.Value Then
                    txtOwnerLastName.Text = dread("owner_lastname")
                End If
                If dread("owner_zipcode") IsNot DBNull.Value Then
                    txtOwnerZipcode.Text = dread("owner_zipcode")
                End If
                If dread("owner_province") IsNot DBNull.Value Then
                    txtOwnerProvince.Text = dread("owner_province")
                End If

                If dread("owner_country") IsNot DBNull.Value Then
                    ddlOwnerCountry.SelectedValue = dread("owner_country")
                End If


                If dread("regis_photo") IsNot DBNull.Value Then
                    hidPhotoRegisCar.Value = dread("regis_photo")
                    PhotoRegisCar.ImageUrl = "~/Upload/RegisterCar/" & hidPhotoRegisCar.Value
                    PhotoRegisCar.Visible = True
                    btnUploadRegisCar.Visible = False
                    FileUpload4.Visible = False
                    PhotoDeleteRegisCar.Visible = True
                End If
                If dread("authorize_car") IsNot DBNull.Value Then
                    hidAuthorize.Value = dread("authorize_car")
                    PhotoAuthorize.ImageUrl = "~/Upload/Authorize/" & hidAuthorize.Value
                    PhotoAuthorize.Visible = True
                    btnUploadAuthorize.Visible = False
                    FileUpload6.Visible = False
                    PhotoDeleteAuthorize.Visible = True
                End If
                If dread("act_no") IsNot DBNull.Value Then
                    txtActNo.Text = dread("act_no")
                End If
                'If dread("act_name") IsNot DBNull.Value Then
                '    txtActName.Text = dread("act_name")
                'End If

                'If dread("act_tankno") IsNot DBNull.Value Then
                '    txtActTankNo.Text = dread("act_tankno")
                'End If

                If dread("act_company") IsNot DBNull.Value Then
                    txtActCompany.Text = dread("act_company")
                End If

                If dread("checkin_id") IsNot DBNull.Value Then
                    ddlBorderCheckin.SelectedValue = dread("checkin_id")
                End If


                'If dread("checkout_id") IsNot DBNull.Value Then
                '    ddlBorderCheckout.SelectedValue = dread("checkout_id")
                'End If


                If dread("act_start") IsNot DBNull.Value Then
                    txtActStart.Text = dread("act_start")
                    txtActStart.Text = Format(CDate(txtActStart.Text), "MM/dd/yyyy")
                End If

                If dread("act_ends") IsNot DBNull.Value Then
                    txtActExpire.Text = dread("act_ends")
                    txtActExpire.Text = Format(CDate(txtActExpire.Text), "MM/dd/yyyy")
                End If

                If dread("act_photo") IsNot DBNull.Value Then
                    hidPhotoAct.Value = dread("act_photo")
                    PhotoAct.ImageUrl = "~/Upload/Act/" & hidPhotoAct.Value
                    PhotoAct.Visible = True
                    btnUploadAct.Visible = False
                    FileUpload5.Visible = False
                    PhotoDeleteAct.Visible = True
                End If

                Dim sqlstr As String

                'อัพโหลดรูปภาพ 
                sqlstr = "select gid , car_id , file_name , imgtype from car_pic WHERE car_id = '" & Session("car_id") & "' "

                Dim DataTable As DataTable = dbConnect.getDataTable(sqlstr, "DataTable")
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

                'จังหวัด 
                Dim sqlstr3 = "select area_id , prov_en , area.prov_code from area LEFT JOIN province on province.prov_code = area.prov_code WHERE license_id = '" & Session("license_id") & "' "
                Dim Datatable3 As DataTable = dbConnect.getDataTable(sqlstr3, "DataTable2")

                If Datatable3.Rows.Count > 0 Then
                    gvProv.DataSource = Datatable3
                    gvProv.DataBind()
                End If


                If dread("province_car") IsNot DBNull.Value Then
                    ddlProvinceRegis.SelectedValue = dread("province_car")
                End If

            Else
                Response.Redirect("index.aspx")

            End If

            dread.Close()

            Dim sqlstr2 As String
            sqlstr2 = "select sparedriver_id , prename , name , surname , license_no , to_char(license_exp_date,'MM/DD/YYYY') as license_exp_date , national , driver_id , licensedriver_photo , address , state , country , zipcode , tel , email , gender , passport_no , to_char(passport_expire,'MM/DD/YYYY') as passport_expire , passport_photo  FROM spare_driver WHERE driver_id = '" & Session("driver_id") & "' order by spare_ord"
            Dim Datatable2 As DataTable = dbConnect.getDataTable(sqlstr2, "DataTable2")
            If Datatable2.Rows.Count > 0 Then
                Dim i = 0
                For Each nrow As DataRow In Datatable2.Rows
                    If i = 0 Then
                        If nrow("prename") IsNot DBNull.Value Then
                            If (nrow("prename") = "Mr." Or nrow("prename") = "Ms." Or nrow("prename") = "Miss." Or nrow("prename") = "Mrs.") Then
                                ddlPrename2.SelectedValue = nrow("prename")
                            Else
                                ddlPrename2.SelectedValue = "other"
                                txtPrename2.Visible = True
                                txtPrename2.Text = dread("prename")
                            End If
                        End If
                        If nrow("name") IsNot DBNull.Value Then
                            txtName2.Text = nrow("name")
                        End If

                        If nrow("surname") IsNot DBNull.Value Then
                            txtSurname2.Text = nrow("name")
                        End If

                        If nrow("license_no") IsNot DBNull.Value Then
                            txtLicense2.Text = nrow("license_no")
                        End If

                        If nrow("license_exp_date") IsNot DBNull.Value Then
                            txtLicenseExpire2.Text = nrow("license_exp_date")
                        End If

                        If nrow("national") IsNot DBNull.Value Then
                            ddlNational2.SelectedValue = nrow("national")
                        End If

                        If nrow("licensedriver_photo") IsNot DBNull.Value Then
                            hidPhotoNameLicense2.Value = nrow("licensedriver_photo")
                        End If

                        If nrow("address") IsNot DBNull.Value Then
                            txtAddress2.Text = nrow("address")
                        End If

                        'If nrow("state") IsNot DBNull.Value Then
                        '    txtState2.Text = nrow("state")
                        'End If

                        If nrow("country") IsNot DBNull.Value Then
                            ddlCountry2.SelectedValue = nrow("country")
                        End If

                        If nrow("zipcode") IsNot DBNull.Value Then
                            txtZipcode2.Text = nrow("zipcode")
                        End If

                        If nrow("tel") IsNot DBNull.Value Then
                            txtTel2.Text = nrow("tel")
                        End If

                        If nrow("gender") IsNot DBNull.Value Then
                            ddlGender2.SelectedValue = nrow("gender")
                        End If

                        If nrow("passport_no") IsNot DBNull.Value Then
                            txtPassportNo2.Text = nrow("passport_no")
                        End If

                        If nrow("passport_expire") IsNot DBNull.Value Then
                            txtPassport_exp2.Text = nrow("passport_expire")
                        End If

                        If nrow("passport_photo") IsNot DBNull.Value Then
                            hidPhotoNamePassport2.Value = nrow("passport_photo")
                        End If

                        If nrow("email") IsNot DBNull.Value Then
                            txtEmail2.Text = nrow("email")
                        End If

                        i = i + 1

                    Else
                        If nrow("prename") IsNot DBNull.Value Then
                            If (nrow("prename") = "Mr." Or nrow("prename") = "Ms." Or nrow("prename") = "Miss." Or nrow("prename") = "Mrs.") Then
                                ddlPrename3.SelectedValue = nrow("prename")
                            Else
                                ddlPrename3.SelectedValue = "other"
                                txtPrename3.Visible = True
                                txtPrename3.Text = dread("prename")
                            End If
                        End If
                        If nrow("name") IsNot DBNull.Value Then
                            txtName3.Text = nrow("name")
                        End If

                        If nrow("surname") IsNot DBNull.Value Then
                            txtSurname3.Text = nrow("name")
                        End If

                        If nrow("license_no") IsNot DBNull.Value Then
                            txtLicense3.Text = nrow("license_no")
                        End If

                        If nrow("license_exp_date") IsNot DBNull.Value Then
                            txtLicenseExpire3.Text = nrow("license_exp_date")
                        End If

                        If nrow("national") IsNot DBNull.Value Then
                            ddlNational3.SelectedValue = nrow("national")
                        End If

                        If nrow("licensedriver_photo") IsNot DBNull.Value Then
                            hidPhotoNameLicense3.Value = nrow("licensedriver_photo")
                        End If

                        If nrow("address") IsNot DBNull.Value Then
                            txtAddress3.Text = nrow("address")
                        End If

                        'If nrow("state") IsNot DBNull.Value Then
                        '    txtState3.Text = nrow("state")
                        'End If

                        If nrow("country") IsNot DBNull.Value Then
                            ddlCountry3.SelectedValue = nrow("country")
                        End If

                        If nrow("zipcode") IsNot DBNull.Value Then
                            txtZipcode3.Text = nrow("zipcode")
                        End If

                        If nrow("tel") IsNot DBNull.Value Then
                            txtTel3.Text = nrow("tel")
                        End If

                        If nrow("gender") IsNot DBNull.Value Then
                            ddlGender3.SelectedValue = nrow("gender")
                        End If

                        If nrow("passport_no") IsNot DBNull.Value Then
                            txtPassportNo3.Text = nrow("passport_no")
                        End If

                        If nrow("passport_expire") IsNot DBNull.Value Then
                            txtPassport_exp3.Text = nrow("passport_expire")
                        End If

                        If nrow("passport_photo") IsNot DBNull.Value Then
                            hidPhotoNamePassport3.Value = nrow("passport_photo")
                        End If

                        If nrow("email") IsNot DBNull.Value Then
                            txtEmail3.Text = nrow("email")
                        End If

                        i = i + 1
                    End If


                Next


            End If





        Catch ex As Exception

        Finally
            cmd.Connection.Close()
            con.Close()
            dbConnect = Nothing
            con.Dispose()
            cmd.Dispose()

        End Try

        'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
    End Sub
    Protected Sub ddlBorderCheckin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBorderCheckin.SelectedIndexChanged
        Dim db As New DBConnect
        Dim oldprov As String = tbProvice.Rows(0)("prov_code")
        tbProvice.Clear()
        Dim prov_code As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
        Dim admin_id As Object = db.executeScalar("select admin_id from admin where prov_code = '" & prov_code & "'")
        Dim prov_en As Object = db.executeScalar("select prov_en from province where prov_code = ( select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue & ") ")
        tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)
        ddladmin.SelectedValue = admin_id
        gvProv.DataSource = tbProvice
        gvProv.DataBind()
        UpdatePanel11.Update()
        updateddladmin.Update()
        If Request.QueryString("regis") = "1" Then
            Paneladd.Visible = False
            ddlProvarea.Visible = False
            If gvProv.Columns.Count > 0 Then
                Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                ProvareaDelete.Visible = False
            End If

        End If

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script20", "tab6();", True)
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMapDel(" & oldprov & ");", True)
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack5", "get_IframeMap(" & prov_code & ");", True)
    End Sub

    Private Function RegisterNo() As String
        Dim sqlstr As String
        Dim DBconnect As New DBConnect
        sqlstr = "select count(register_no) from license " & _
                 "WHERE date_part('month',register_date) = '" & Now.Month & "' and date_part('Year',register_date) = '" & Now.Year & "'"
        Dim regis_no As String = ""
        Dim no As Integer
        no = DBconnect.executeScalar(sqlstr)
        no = no + 1
        Dim length As Integer
        length = no.ToString.Length

        If length = 1 Then
            regis_no = Now.Year & Now.Month & "000" & no
        ElseIf length = 2 Then
            regis_no = Now.Year & Now.Month & "00" & no
        ElseIf length = 3 Then
            regis_no = Now.Year & Now.Month & "0" & no
        ElseIf length = 4 Then
            regis_no = Now.Year & Now.Month & no
        End If

        Return regis_no.ToString

    End Function

    Private Send As New SendEmail
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            Send.Email(txtEmail.Text, txtName.Text & " " & txtSurname.Text)
        Catch ex As Exception

        End Try

        If Session("license_id") Then
            Dim DBconnect As New DBConnect
            Dim con As Npgsql.NpgsqlConnection = DBconnect.getConnection
            Dim cmd As New Npgsql.NpgsqlCommand
            Dim dread As Npgsql.NpgsqlDataReader

            Try
                con.Open()
                cmd.Connection = con
                Dim sqlUpdate As String = "Update license set  token=:token , checkin_id=:checkin_id , regis_date=:regis_date , status_id = 0 , admin_id =:admin_id WHERE license_id = '" & Session("license_id") & "'"
                cmd.CommandText = CommandType.Text
                cmd.CommandText = sqlUpdate
                cmd.Parameters.Clear()
                Dim pToken As Object = DBconnect.Token(Session("license_id"), Session("car_id"))
                cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pToken
                cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckin.SelectedValue
                'cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckout.SelectedValue
                cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
                cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddladmin.SelectedValue
                cmd.ExecuteNonQuery()

                Dim sqlUpdateSend = "Update driver set is_send = 1 WHERE driver_id = '" & Session("driver_id") & "'"
                cmd.CommandText = sqlUpdateSend
                cmd.Parameters.Clear()
                cmd.ExecuteNonQuery()




                Dim sqlselectcheck As String = "SELECT area_id from area WHERE license_id = '" & Session("license_id") & "'"

                Dim cRowf As DataRow
                Dim drRow() As DataRow
                Dim tbProviceold As New DataTable

                cmd.CommandText = CommandType.Text
                cmd.CommandText = sqlselectcheck
                tbProviceold = DBconnect.getDataTable(sqlselectcheck, "TbProviceold")

                '------------อัพโหลดจังหวัด-------------

                For introw = 0 To tbProvice.Rows.Count - 1
                    cmd.Parameters.Clear()
                    cRowf = tbProvice.Rows(introw)
                    drRow = tbProviceold.Select("area_id = " & cRowf("area_id"))

                    If drRow.Length > 0 Then
                        cmd.CommandText = "Update area set prov_code=:prov_code , license_id=:license_id WHERE area_id = " & cRowf("area_id")
                        tbProviceold.Rows.Remove(drRow(0))
                    Else
                        cmd.CommandText = "Insert into area (prov_code , license_id ) VALUES (:prov_code , :license_id ) "

                    End If

                    cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("prov_code")
                    cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("license_id")
                    cmd.ExecuteNonQuery()
                Next

                '----------ลบจังหวัด---------------

                For Each cRow In tbProviceold.Rows
                    cmd.Parameters.Clear()
                    cmd.CommandText = "delete from area where area_id =" & cRow("area_id")
                    cmd.ExecuteScalar()
                Next


                Response.Redirect("RegisterComplete.aspx?token=" & pToken)

            Catch ex As Exception

            Finally
                cmd.Connection.Close()
                con.Close()
                DBconnect = Nothing
                con.Dispose()
                cmd.Dispose()
            End Try

        Else
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "tab1();", True)

        End If

    End Sub
    Protected Sub btnSave_Command(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("license_id") Then
            Dim DBconnect As New DBConnect
            Dim con As Npgsql.NpgsqlConnection = DBconnect.getConnection
            Dim cmd As New Npgsql.NpgsqlCommand
            Dim dread As Npgsql.NpgsqlDataReader

            Try
                con.Open()
                cmd.Connection = con
                Dim sqlUpdate As String = "Update license set  token=:token , checkin_id=:checkin_id  WHERE license_id = '" & Session("license_id") & "'"
                cmd.CommandText = CommandType.Text
                cmd.CommandText = sqlUpdate
                cmd.Parameters.Clear()
                cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBconnect.Token(Session("license_id"), Session("car_id"))
                cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckin.SelectedValue
                'cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckout.SelectedValue
                cmd.ExecuteNonQuery()

                Dim sqlselectcheck As String = "SELECT area_id from area WHERE license_id = '" & Session("license_id") & "'"

                Dim cRowf As DataRow
                Dim drRow() As DataRow
                Dim tbProviceold As New DataTable

                cmd.CommandText = CommandType.Text
                cmd.CommandText = sqlselectcheck
                tbProviceold = DBconnect.getDataTable(sqlselectcheck, "TbFileOld")

                '------------อัพโหลดจังหวัด-------------

                For introw = 0 To tbProvice.Rows.Count - 1
                    cmd.Parameters.Clear()
                    cRowf = tbProvice.Rows(introw)
                    drRow = tbProviceold.Select("area_id = " & cRowf("area_id"))

                    If drRow.Length > 0 Then
                        cmd.CommandText = "Update area set prov_code=:prov_code , license_id=:license_id WHERE area_id = " & cRowf("area_id")
                        tbProviceold.Rows.Remove(drRow(0))
                    Else
                        cmd.CommandText = "Insert into area (prov_code , license_id ) VALUES (:prov_code , :license_id ) "

                    End If

                    cmd.Parameters.Add(":prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("prov_code")
                    cmd.Parameters.Add(":license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("license_id")
                    cmd.ExecuteNonQuery()
                Next

                '----------ลบจังหวัด---------------

                For Each cRow In tbProviceold.Rows
                    cmd.Parameters.Clear()
                    cmd.CommandText = "delete from area where area_id =" & cRow("area_id")
                    cmd.ExecuteScalar()
                Next
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBackHome", "tab1();", True)


            Catch ex As Exception

            Finally
                cmd.Connection.Close()
                con.Close()
                DBconnect = Nothing
                con.Dispose()
                cmd.Dispose()
            End Try

        Else
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "tab1();", True)

        End If
    End Sub
    Protected Sub btnProv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProv.Click
        Dim pro = ddlProvarea.SelectedValue
        tbProvice.Rows.Add(tbProvice.Rows.Count + 1, ddlProvarea.SelectedItem.Text, ddlProvarea.SelectedValue)
        If ddlProvarea.SelectedValue() = 0 Then
            tbProvice.Clear()
            ddlProvarea.Visible = False
            btnProv.Visible = False
            Paneladd.Visible = False
            tbProvice.Rows.Add(tbProvice.Rows.Count + 1, ddlProvarea.SelectedItem.Text, ddlProvarea.SelectedValue)
        End If
        For Each i As DataRow In tbProvice.Rows
            ddlProvarea.Items.FindByValue(i("prov_code").ToString).Attributes.Add("disabled", "disabled")
        Next
        ddlProvarea.ClearSelection()
        gvProv.DataSource = tbProvice
        gvProv.DataBind()
        UpdatePanel11.Update()

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMap(" & pro & ");", True)
    End Sub
    Protected Sub Provarea_Delete(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        If Request.QueryString("regis") = 1 Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "alert('Do not delete because there must be at least 1 province.')", True)
        Else
            Dim prov_code = e.CommandArgument
            If prov_code = 0 Then
                tbProvice.Clear()
                ddlProvarea.Visible = True
                btnProv.Visible = True
                Paneladd.Visible = True
                tbProvice.Rows.Add(tbProvice.Rows.Count + 1, ddlProvarea.SelectedItem.Text, ddlProvarea.SelectedValue)
            End If
            Dim data = tbProvice.Select("prov_code=" & prov_code)
            ddlProvarea.Items.FindByValue(data("0")("prov_code").ToString).Attributes.Remove("disabled")
            gvProv.DataSource = tbProvice
            gvProv.DataBind()
            UpdatePanel11.Update()

            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMapDel(" & prov_code & ");", True)
        End If
    End Sub
    Protected Sub btnNext3_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles btnNext3.Command

    End Sub
End Class
