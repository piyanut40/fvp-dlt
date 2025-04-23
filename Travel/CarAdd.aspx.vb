Imports Npgsql
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Globalization
Partial Class Travel_CarAdd
    Inherits System.Web.UI.Page
    Protected statusth As String
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

        If Page.IsPostBack = False Then

            If Session("user_id") = Nothing Or Session("user_type") = 1 Then
                Session.Clear()
                Response.Redirect("../Login.aspx")
            End If

            populate.genDDLCountry(ddlCountry, False)
            populate.genDDLNationality(ddlNational, False)

            populate.genDDLCountry(ddlCountry2, False)
            populate.genDDLNationality(ddlNational2, False)

            populate.genDDLCountry(ddlCountry3, False)
            populate.genDDLNationality(ddlNational3, False)
            populate.genDDLProvince(ddlProvarea, False)
            populate.genDDLCountry(ddlCountryCar, False)
            populate.genDDLBorder(ddlBorderCheckin, False, "")
            populate.gencolors(ddlColor)
            populate.genAreaform(ddladmin, False)
            populate.genDDLCartype(ddltypecar, True)
            AddPopupMapAdmin("")


            hiddriver_id.Value = 0
            hidsparedriver_id1.Value = 0
            hidsparedriver_id2.Value = 0
            hidcar_id.Value = 0
            hidact_id.Value = 0
            Dim db As New DBConnect
            Dim prov_code As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
            Dim admin_id As Object = db.executeScalar("select admin_id from admin where prov_code = '" & prov_code & "'")
            ddladmin.SelectedValue = admin_id


            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
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


        For Each i As DataRow In tbProvice.Rows
            Try
                ddlProvarea.Items.FindByValue(i("prov_code").ToString).Attributes.Add("disabled", "disabled")
                If Request.QueryString("regis") = "1" Or Request.QueryString("regis") = "2" Then
                    strprov_code = i("prov_code").ToString & ","
                End If
            Catch ex As Exception

            End Try
        Next



        'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack10", "get_IframeMap(" & strprov_code & ");", True)



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

    End Sub

    Private Sub AddPopupMapAdmin(ByVal paraMap As String)
        Dim strPopup As String = "javascript:w=window.open(" & _
                        """" & ResolveClientUrl("~/Map/MapAdmin.aspx?" & paraMap) & """," & _
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab2();", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab2();", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab2();", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab2();", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab2();", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab2();", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "tab3();", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script6", "tab4();", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script10", "tab3();", True)
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
                    nrow.Item("car_id") = hidcar_id.Value
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script7", "tab3();", True)

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

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script8", "tab3();", True)
    End Sub
    Protected Sub ddladmin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddladmin.SelectedIndexChanged
        'Page_Load(sender, e)
    End Sub

   
    Protected Sub btnNext2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext2.Click

        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con
            Dim Str As String
            'Dim strUpdate = "Update car set owner_name=:owner_name , owner_idcard=:owner_idcard , owner_address=:owner_address , owner_tel=:owner_tel WHERE car_id = " & hidcar_id.Value
            If hidcar_id.Value = "0" Then
                Str = " INSERT INTO car( owner_name, owner_idcard, owner_address, owner_tel) values( :owner_name, :owner_idcard, :owner_address, :owner_tel) RETURNING car_id;"
            Else
                Str = " update car set owner_name = :owner_name, owner_idcard = :owner_idcard, owner_address = :owner_address, owner_tel = :owner_tel where car_id = " & hidcar_id.Value
            End If

            cmd.CommandText = CommandType.Text
            cmd.CommandText = Str
            cmd.Parameters.Clear()
            cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerName.Text
            cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerIdcard.Text
            cmd.Parameters.Add("owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerAddress.Text
            cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnertel.Text
            If hidcar_id.Value = "0" Then
                cmd.Parameters.Add("car_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
            End If


            cmd.ExecuteNonQuery()
            If hidcar_id.Value = "0" Then
                hidcar_id.Value = cmd.Parameters("car_id").Value.ToString
            End If


        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
        Finally
            cmd.Connection.Close()
            con.Close()
        End Try

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "Script2", "tab2();", True)
        'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptAlert", "alertDataDriver();", True)


    End Sub
    Protected Sub btnNext3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext3.Click
        If txtAddress.Text = "" Or txtName.Text = "" Or txtSurname.Text = "" Or txtLicenseExpire.Text = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
        ElseIf hidPhotoNameLicense.Value = "" Or hidPhotoNamePassport.Value = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck2();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
        Else

            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Dim dread As Npgsql.NpgsqlDataReader
            Try
                con.Open()
                cmd.Connection = con
                Dim str As String
                If hiddriver_id.Value = "0" Then
                    str = "INSERT INTO driver( idcard_no, passport_no, passport_expire, prename, national, birthday, name, surname " & _
                                          ", gender, address, countries, zipcode, license_expire, email, tel, passport_photo, licensedriver_photo ,county, added_user, added_date, modified_user, modified_date)" & _
                                          " values ( :idcard_no, :passport_no, :passport_expire, :prename, :national, :birthday, :name, :surname " & _
                                          ", :gender, :address, :countries, :zipcode, :license_expire, :email, :tel, :passport_photo, :licensedriver_photo, :county, :added_user, now(), :modified_user, now())  RETURNING driver_id;"
                Else
                    str = "update driver set idcard_no = :idcard_no, passport_no = :passport_no, passport_expire = :passport_expire, prename = :prename, national = :national, birthday = :birthday, name = :name, surname =:surname " & _
                                         " , gender = :gender, address = :address, countries = :countries, zipcode = :zipcode, license_expire = :license_expire, email = :email " & _
                                         " , tel = :tel, passport_photo = :passport_photo, licensedriver_photo = :licensedriver_photo ,county = :county, modified_user = :modified_user, modified_date = now() where driver_id = " & hiddriver_id.Value

                End If


                cmd.CommandText = CommandType.Text
                cmd.CommandText = str
                cmd.Parameters.Clear()

                cmd.Parameters.Add("idcard_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicenseDriver.Text.Trim = "", Nothing, txtLicenseDriver.Text)
                cmd.Parameters.Add("passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtPassportNo.Text
                cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtPassportExpire.Text.Trim = "", Nothing, txtPassportExpire.Text)
                If ddlPrename.SelectedValue = "Other" Then
                    cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtPrename.Text
                Else
                    cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlPrename.SelectedValue
                End If
                cmd.Parameters.Add("national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlNational.SelectedItem
                cmd.Parameters.Add("birthday", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtDate.Text.Trim = "", Nothing, txtDate.Text)
                cmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtName.Text.Trim = "", Nothing, txtName.Text)
                cmd.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtSurname.Text.Trim = "", Nothing, txtSurname.Text)
                cmd.Parameters.Add("gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlGender.SelectedValue
                cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtAddress.Text.Trim = "", Nothing, txtAddress.Text)
                cmd.Parameters.Add("countries", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountry.SelectedItem
                cmd.Parameters.Add("zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtZipcode.Text.Trim = "", Nothing, txtZipcode.Text)
                cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtLicenseExpire.Text.Trim = "", Nothing, txtLicenseExpire.Text)
                cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtEmail.Text.Trim = "", Nothing, txtEmail.Text)
                cmd.Parameters.Add("tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtTel.Text.Trim = "", Nothing, txtTel.Text)
                cmd.Parameters.Add("passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport.Value
                cmd.Parameters.Add("licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense.Value
                cmd.Parameters.Add("county", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtCounty.Text.Trim = "", Nothing, txtCounty.Text)
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

                ' คนขับสำรองคนที่ 1 
                If txtName2.Text <> "" And txtSurname2.Text <> "" Then
                    cmd.Parameters.Clear()
                    If hidsparedriver_id1.Value = "0" Then
                        cmd.CommandText = "Insert Into spare_driver ( prename , name , surname , license_no , national , driver_id  , licensedriver_photo , address  , country , zipcode , tel , email , gender , license_exp_date , passport_no , passport_expire , passport_photo , spare_ord ) " & _
                                      " VALUES (:prename , :name , :surname , :license_no , :national , :driver_id , :licensedriver_photo , :address , :country , :zipcode , :tel , :email , :gender , :license_exp_date , :passport_no , :passport_expire , :passport_photo , 1 ) "
                    Else
                        cmd.CommandText = "update spare_driver set prename = :prename , name = :name , surname = :surname , license_no = :license_no , national = :national , driver_id = :driver_id " & _
                            " , licensedriver_photo = :licensedriver_photo, address =:address , country = :country , zipcode = :zipcode , tel = :tel , email = :email , gender = :gender, " & _
                            " license_exp_date = :license_exp_date , passport_no = :passport_no , passport_expire = :passport_expire , passport_photo =:passport_photo where sparedriver_id = " & hidsparedriver_id1.Value


                    End If

                    If ddlPrename2.SelectedValue = "Other" Then
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
                    cmd.Parameters.Add(":driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
                    cmd.Parameters.Add(":licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense2.Value
                    cmd.Parameters.Add(":passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport2.Value

                    If hidsparedriver_id1.Value = "0" Then
                        cmd.Parameters.Add("sparedriver_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
                    End If

                    cmd.ExecuteNonQuery()

                    If hidsparedriver_id1.Value = "0" Then
                        hidsparedriver_id1.Value = cmd.Parameters("sparedriver_id").Value.ToString
                    End If

                End If

                ' คนขับสำรองคนที่ 2
                If txtName3.Text <> "" And txtSurname3.Text <> "" Then
                    cmd.Parameters.Clear()
                    If hidsparedriver_id2.Value = "0" Then
                        cmd.CommandText = "Insert Into spare_driver ( prename , name , surname , license_no , national , driver_id  , licensedriver_photo , address  , country , zipcode , tel , email , gender , license_exp_date , passport_no , passport_expire , passport_photo , spare_ord ) " & _
                                      " VALUES (:prename , :name , :surname , :license_no , :national , :driver_id , :licensedriver_photo , :address , :country , :zipcode , :tel , :email , :gender , :license_exp_date , :passport_no , :passport_expire , :passport_photo , 2 ) "
                    Else
                        cmd.CommandText = "update spare_driver set prename = :prename , name = :name , surname = :surname , license_no = :license_no , national = :national , driver_id = :driver_id " & _
                            " , licensedriver_photo = :licensedriver_photo, address =:address , country = :country , zipcode = :zipcode , tel = :tel , email = :email , gender = :gender, " & _
                            " license_exp_date = :license_exp_date , passport_no = :passport_no , passport_expire = :passport_expire , passport_photo =:passport_photo where sparedriver_id = " & hidsparedriver_id2.Value


                    End If
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
                    cmd.Parameters.Add(":driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
                    cmd.Parameters.Add(":licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense3.Value
                    cmd.Parameters.Add(":passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport3.Value

                    If hidsparedriver_id2.Value = "0" Then
                        cmd.Parameters.Add("sparedriver_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
                    End If

                    cmd.ExecuteNonQuery()

                    If hidsparedriver_id2.Value = "0" Then
                        hidsparedriver_id2.Value = cmd.Parameters("sparedriver_id").Value.ToString
                    End If
                End If


                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab3();", True)

            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2();", True)
            Finally
                dbConnect = Nothing
                cmd.Connection.Close()
                con.Close()
            End Try

        End If
    End Sub
    Protected Sub btnNext4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext4.Click
        If txtBrands.Text = "" Or txtLicenseCar.Text = "" Or txtOwnerName.Text = "" Or txtOwnerIdcard.Text = "" Or txtOwnerAddress.Text = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab3();", True)
        Else

            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Dim dread As Npgsql.NpgsqlDataReader
            Try
                con.Open()
                cmd.Connection = con
                Dim str As String

                If hidcar_id.Value = "0" Then
                    str = " INSERT INTO car( plate, platelocal, brands, model, seat, weight, province_car, car_no, engine_no, " & _
                                                                " typecar_id, colors, owner_name, owner_idcard, owner_address, owner_tel , country_car, engine_cap) " & _
                                                                " values ( :plate, :platelocal, :brands, :model, :seat, :weight, :province_car, :car_no, :engine_no, " & _
                                                                " :typecar_id, :colors, :owner_name, :owner_idcard, :owner_address, :owner_tel, :country_car, :engine_cap) RETURNING car_id;"
                Else
                    str = " update car set plate = :plate, platelocal=:platelocal, brands=:brands, model=:model, seat =:seat, weight=:weight, province_car=:province_car, car_no=:car_no, engine_no=:engine_no, " & _
                                                            " typecar_id=:typecar_id, colors=:colors, owner_name=:owner_name, owner_idcard=:owner_idcard, owner_address=:owner_address " & _
                                                            " , owner_tel=:owner_tel , country_car=:country_car, engine_cap=:engine_cap where car_id = " & hidcar_id.Value
                End If



                cmd.CommandText = CommandType.Text
                cmd.CommandText = str
                cmd.Parameters.Clear()
                cmd.Parameters.Add("plate", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicenseCar.Text.Trim = "", Nothing, txtLicenseCar.Text)
                cmd.Parameters.Add("platelocal", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicenseLocalCar.Text.Trim = "", Nothing, txtLicenseLocalCar.Text)
                cmd.Parameters.Add("brands", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtBrands.Text.Trim = "", Nothing, txtBrands.Text)
                cmd.Parameters.Add("model", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtModel.Text.Trim = "", Nothing, txtModel.Text)
                cmd.Parameters.Add("seat", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtSeats.Text.Trim = "", Nothing, txtSeats.Text) 'ddlSeats.SelectedValue
                cmd.Parameters.Add("weight", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtWeight.Text.Trim = "", Nothing, txtWeight.Text)
                cmd.Parameters.Add("province_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtstate_car.Text 'ddlProvinceRegis.SelectedItem
                cmd.Parameters.Add("car_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtNumcar.Text.Trim = "", Nothing, txtNumcar.Text)
                cmd.Parameters.Add("engine_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtNumEngine.Text.Trim = "", Nothing, txtNumEngine.Text)
                cmd.Parameters.Add("typecar_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = IIf(ddltypecar.SelectedItem.Value = "", Nothing, ddltypecar.SelectedItem.Value)
                cmd.Parameters.Add("colors", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlColor.SelectedValue
                cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerName.Text.Trim = "", Nothing, txtOwnerName.Text)
                cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerIdcard.Text.Trim = "", Nothing, txtOwnerIdcard.Text)
                cmd.Parameters.Add("owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerAddress.Text.Trim = "", Nothing, txtOwnerAddress.Text)
                cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnertel.Text.Trim = "", Nothing, txtOwnertel.Text)
                cmd.Parameters.Add("country_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(ddlCountryCar.SelectedItem.Value = "", Nothing, ddlCountryCar.SelectedItem.Value)
                cmd.Parameters.Add("engine_cap", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtEnginCap.Text.Trim = "", Nothing, txtEnginCap.Text)
                If hidcar_id.Value = "0" Then
                    cmd.Parameters.Add("car_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
                End If


               
                cmd.ExecuteNonQuery()
                If hidcar_id.Value = "0" Then
                    hidcar_id.Value = cmd.Parameters("car_id").Value.ToString
                End If


                Dim strCheckPic = "Select gid from car_pic WHERE car_id = " & hidcar_id.Value
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

                    cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidcar_id.Value
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




            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
            Finally
                cmd.Connection.Close()
                con.Close()
            End Try

            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab4();", True)
            'loadProvice()

        End If
    End Sub

    Protected Sub btnNext5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext5.Click


        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            Dim str As String
            If hidact_id.Value = "0" Then
                str = " INSERT INTO act(  act_no, act_start, act_ends, act_company) " & _
                                     " values ( :act_no, :act_start, :act_ends, :act_company) RETURNING act_id;"
            Else
                str = " update act set act_no = :act_no, act_start =:act_start, act_ends = :act_ends, act_company =:act_company where act_id = " & hidact_id.Value
            End If

            cmd.CommandText = CommandType.Text
            cmd.CommandText = str
            cmd.Parameters.Clear()
            cmd.Parameters.Add("act_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtActNo.Text.Trim = "", Nothing, txtActNo.Text)
            'cmd.Parameters.Add("act_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtActName.Text
            'cmd.Parameters.Add("act_tankno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtActTankNo.Text
            cmd.Parameters.Add("act_start", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtActStart.Text.Trim = "", Nothing, txtActStart.Text)
            cmd.Parameters.Add("act_ends", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtActExpire.Text.Trim = "", Nothing, txtActExpire.Text)
            'cmd.Parameters.Add("act_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidPhotoAct.Value.Trim = "", Nothing, hidPhotoAct.Value)
            cmd.Parameters.Add("act_company", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtActCompany.Text.Trim = "", Nothing, txtActCompany.Text)
            If hidact_id.Value = "0" Then
                cmd.Parameters.Add("act_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
            End If

            cmd.ExecuteNonQuery()
            If hidact_id.Value = "0" Then
                hidact_id.Value = cmd.Parameters("act_id").Value.ToString
            End If



        Catch ex As Exception

        Finally
            cmd.Connection.Close()
            con.Close()
        End Try

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "tab5();", True)

    End Sub


    Protected Sub btnPrev2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev2.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script6", "tab1();", True)
    End Sub

    Protected Sub btnPrev3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev3.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script8", "tab2();", True)
    End Sub
    Protected Sub btnPrev4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev4.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script9", "tab3();", True)
    End Sub
    Protected Sub btnPrev5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev5.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script10", "tab4();", True)
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
    Protected Sub btnLoaddata_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoaddata.Click
        
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

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script20", "tab5();", True)

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack5", "get_IframeMap(0);", True)
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



        Dim DBconnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = DBconnect.getConnection
        Dim cmd As New Npgsql.NpgsqlCommand
        Dim dread As Npgsql.NpgsqlDataReader

        Try
            con.Open()
            cmd.Connection = con
           

            Dim strInsert As String = " INSERT INTO license( car_id, driver_id, status_id, checkin_id, regis_date, typeuser_id, travel_id, act_id, admin_id) " & _
                                       " values ( :car_id, :driver_id, :status_id, :checkin_id, :regis_date, :typeuser_id, :travel_id, :act_id, :admin_id) RETURNING license_id;"
            cmd.CommandText = strInsert

            cmd.Parameters.Clear()

            cmd.Parameters.Add("car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidcar_id.Value
            cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
            cmd.Parameters.Add("status_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0
            'cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Date).Value =
            cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckin.SelectedValue
            'cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckout.SelectedValue
            'cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Varchar).Value =
            'cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Varchar).Value =
            cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Now.Date
            cmd.Parameters.Add("typeuser_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = 2
            'cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = licenseNo()
            'cmd.Parameters.Add("qrcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value =
            cmd.Parameters.Add("travel_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("user_id")
            cmd.Parameters.Add("act_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidact_id.Value
            cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Direction = ParameterDirection.Output
            cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddladmin.SelectedValue
            cmd.ExecuteNonQuery()

            hidlicense_id.Value = cmd.Parameters("license_id").Value.ToString
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptCompleteStep3", "tab_active(4);", True)

            Dim strUpdate As String = "update license set token = :token where license_id = " & hidlicense_id.Value
            cmd.CommandText = strUpdate
            cmd.Parameters.Clear()
            cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBconnect.Token(hidlicense_id.Value, hidcar_id.Value)
            cmd.ExecuteNonQuery()

            Dim sqlUpdateSend = "Update driver set is_send = 1 WHERE driver_id = " & hidlicense_id.Value
            cmd.CommandText = sqlUpdateSend
            cmd.Parameters.Clear()
            cmd.ExecuteNonQuery()


            Dim sqlselectcheck As String = "SELECT * from area WHERE license_id = " & hidlicense_id.Value
            Dim drRow() As DataRow
            Dim tbProviceold As New DataTable

            cmd.CommandText = CommandType.Text
            cmd.CommandText = sqlselectcheck
            tbProviceold = DBconnect.getDataTable(sqlselectcheck, "TbProviceold")

            '------------อัพโหลดจังหวัด-------------

            drRow = tbProviceold.Select("license_id = " & hidlicense_id.Value)

            If drRow.Length > 0 Then
                cmd.CommandText = "Update area set prov_code=0  WHERE license_id = " & hidlicense_id.Value
                tbProviceold.Rows.Remove(drRow(0))
            Else
                cmd.CommandText = "Insert into area (prov_code , license_id ) VALUES (0 , " & hidlicense_id.Value & " ) "

            End If

            'cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("prov_code")
            'cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidlicense_id.Value
            cmd.ExecuteNonQuery()

            '----------ลบจังหวัด---------------

            For Each cRow In tbProviceold.Rows
                cmd.Parameters.Clear()
                cmd.CommandText = "delete from area where area_id =" & cRow("area_id")
                cmd.ExecuteScalar()
            Next

            Try
                Send.Email(txtEmail.Text, txtName.Text & " " & txtSurname.Text, DBconnect.Token(hidlicense_id.Value, hidcar_id.Value), "")
            Catch ex As Exception

            End Try

            Response.Redirect("index.aspx")

        Catch ex As Exception

        Finally
            DBconnect = Nothing
            cmd.Connection.Close()
            con.Close()
            cmd.Dispose()
            con.Dispose()
        End Try


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

        'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMap(" & pro & ");", True)
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMap(0);", True)
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

            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMapDel(" & prov_code & ");", True)
        End If
    End Sub

End Class
