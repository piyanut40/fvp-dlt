Imports Npgsql
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Globalization
Imports System.ServiceModel.Channels

Partial Class Travel_MgtEdit
    Inherits System.Web.UI.Page

    Protected statusth As String
    Protected Img As String
    Protected name As String
    Protected Headername As String

    Private supportedFilePDF As String = ",.pdf,"
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
    Private tbImageCer As New DataTable
    Private tbImageInspec As New DataTable
    Private tbSpareDriver As New DataTable
    Private tbProvice As New DataTable
    Dim strprov_code As String = ""
    'Private ptxtFileNAME As String
    'Private strTxtFile As New StringBuilder
    'Dim NewLine As String = System.Environment.NewLine
    'Dim IndexFile As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            Try
                If Session("user_id") = Nothing Or Session("user_type") = 1 Then
                    Session.Clear()
                    Response.Redirect("../Login.aspx")
                End If
            Catch ex As Exception
                Session.Clear()
                Response.Redirect("../Login.aspx?Page=" & HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri))
            End Try


            populate.genDDLCountry(ddlCountry, False)
            populate.genDDLNationality(ddlNational, False)

            populate.genDDLCountry(ddlCountry2, False)
            populate.genDDLNationality(ddlNational2, False)

            populate.genDDLCountry(ddlCountry3, False)
            populate.genDDLNationality(ddlNational3, False)
            populate.genDDLCountry(ddlOwnerCountry, False)
            populate.genDDLProvince(ddlProvarea, False)
            populate.genDDLCountry(ddlCountryCar, False)

            populate.genDDLBorder(ddlBorderCheckin, False, "")
            populate.gencolors(ddlColor)
            populate.genAreaform(ddladmin, False)
            populate.genDDLCartype(ddltypecar, True)
            AddPopupMapAdmin("")

            Dim strScriptchk As String = "javascript:isJuristic('" & chkisJuristic.ClientID & "');"
            chkisJuristic.Attributes.Add("OnClick", strScriptchk)



            If Not (Request.QueryString("token") Is Nothing) Then
                loaddata()
            End If
            If Request.QueryString("is_renew") IsNot Nothing Then
                If Request.QueryString("ins") IsNot Nothing Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab4();", True)
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script1", "tab2();", True)
                End If

            Else
                If Request.QueryString("Page") = "0" Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script1", "tab2();", True)
                ElseIf Request.QueryString("Page") = "1" Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab1();", True)
                ElseIf Request.QueryString("Page") = "2" Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
                ElseIf Request.QueryString("Page") = "3" Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab3();", True)
                ElseIf Request.QueryString("Page") = "4" Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab4();", True)
                ElseIf Request.QueryString("Page") = "8" Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab4();", True)
                End If
            End If

            ScriptManager.RegisterStartupScript(Page, GetType(Page), "ChkScript", " isJuristic('" & chkisJuristic.ClientID & "'); ", True)
            Dim db As New DBConnect
            Dim prov_code As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
            Dim admin_id As Object = db.executeScalar("select admin_id from admin where prov_code = '" & prov_code & "'")
            ddladmin.SelectedValue = admin_id


            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
        End If

        With tbImage
            .Columns.Add("gid")
            .Columns.Add("car_id")
            .Columns.Add("file_name")
            .Columns.Add("PathImg")
            .Columns.Add("ImgType")
        End With

        With tbImageCer
            .Columns.Add("gid")
            .Columns.Add("car_id")
            .Columns.Add("file_name")
            .Columns.Add("PathImg")
        End With

        With tbImageInspec
            .Columns.Add("gid")
            .Columns.Add("car_id")
            .Columns.Add("file_name")
            .Columns.Add("PathImg")
        End With

        For Each row As GridViewRow In gvFile_inspec.Rows
            Dim nrow As DataRow = tbImageInspec.NewRow
            nrow("gid") = CType(row.Cells(0).FindControl("lblID"), Label).Text
            nrow("car_id") = CType(row.Cells(0).FindControl("lblCarid"), Label).Text
            nrow("file_name") = CType(row.Cells(0).FindControl("lblfile_name"), Label).Text
            nrow("PathImg") = CType(row.Cells(0).FindControl("lblPathImg"), Label).Text
            tbImageInspec.Rows.Add(nrow)
        Next


        If hidPhotonamecar_cer.Value <> "" Then
            btnUploadCar_cer.Visible = False
            FileUpload_cer.Visible = False
            PhotoCar_cerDelete.Visible = True

            Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileRegisterCar") & "/")
            Dim tempFile = New System.IO.FileInfo(fpathstr & hidPhotonamecar_cer.Value)
            linkCar_cer.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidPhotonamecar_cer.Value & "&fname=" & Server.UrlPathEncode(hidPhotonamecar_cer.Value) & "&fPath=FileRegisterCar"
            linkCar_cer.Target = "_blank"
            linkCar_cer.Visible = True
        Else
            linkCar_cer.Visible = False
        End If

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

        If Session("user_type") = 1 Or Session("user_type") = 2 Then
            lblProv0.Visible = False
            If tbProvice.Rows.Count = 0 Then

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
            If Session("user_type") = "1" Then
                Paneladd.Visible = False
                ddlProvarea.Visible = False
                If gvProv.Columns.Count > 0 Then
                    Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                    ProvareaDelete.Visible = False
                End If
            Else
                Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                ProvareaDelete.Visible = False
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
                If Session("user_type") = 1 Or Session("user_type") = 2 Then
                    strprov_code = strprov_code & i("prov_code").ToString & ","
                End If
            Catch ex As Exception

            End Try
        Next

        strprov_code = strprov_code.Remove(strprov_code.Length - 1)

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack10", " $('#loadings').hide(); get_IframeMap('" & strprov_code & "');", True)



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
        If hidPhotoNamePassport_2.Value <> "" Then
            PhotoPassport_2.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport_2.Value
            PhotoPassport_2.Visible = True
            btnUploadPassport_2.Visible = False
            FileUpload1_2.Visible = False
            PhotoDeletePassport_2.Visible = True
        Else
            PhotoPassport_2.Visible = False
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
        If hidPhotoNameLicense_2.Value <> "" Then
            PhotoLicense_2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense_2.Value
            PhotoLicense_2.Visible = True
            btnUploadLicense_2.Visible = False
            FileUpload3_2.Visible = False
            PhotoDeleteLicense_2.Visible = True
        Else
            PhotoLicense_2.Visible = False
        End If


        If hidPhotoCer.Value <> "" Then
            'PhotoCer.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoCer.Value
            'PhotoCer.Visible = True
            btnUploadCer.Visible = False
            FileUploadPhotoCer.Visible = False
            PhotoDeleteCer.Visible = True

            Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver") & "/")
            Dim tempFile = New System.IO.FileInfo(fpathstr & hidPhotoCer.Value)
            linkPhotoCer.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidPhotoCer.Value & "&fname=" & Server.UrlPathEncode(hidPhotoCer.Value) & "&fPath=FileLicenseDriver"
            linkPhotoCer.Target = "_blank"
            linkPhotoCer.Visible = True
        Else
            'PhotoCer.Visible = False
            linkPhotoCer.Visible = False
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
        If hidPhotoNamePassport2_2.Value <> "" Then
            PhotoPassport2_2.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport2_2.Value
            PhotoPassport2_2.Visible = True
            btnUploadPassport2_2.Visible = False
            FileUploadPassport2_2.Visible = False
            PhotoDeletePassport2_2.Visible = True
        Else
            PhotoPassport2_2.Visible = False
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
        If hidPhotoNameLicense2_2.Value <> "" Then
            PhotoLicense2_2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense2_2.Value
            PhotoLicense2_2.Visible = True
            btnUploadLicense2_2.Visible = False
            FileUploadLicense2_2.Visible = False
            PhotoDeleteLicense2_2.Visible = True
        Else
            PhotoLicense2_2.Visible = False
        End If

        If hidPhotoCer2.Value <> "" Then
            'PhotoCer2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoCer2.Value
            'PhotoCer2.Visible = True
            btnUploadCer2.Visible = False
            FileUploadPhotoCer2.Visible = False
            PhotoDeleteCer2.Visible = True

            Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver") & "/")
            Dim tempFile = New System.IO.FileInfo(fpathstr & hidPhotoCer2.Value)
            linkPhotoCer2.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidPhotoCer2.Value & "&fname=" & Server.UrlPathEncode(hidPhotoCer2.Value) & "&fPath=FileLicenseDriver"
            linkPhotoCer2.Target = "_blank"
            linkPhotoCer2.Visible = True
        Else
            'PhotoCer2.Visible = False
            linkPhotoCer2.Visible = False
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
        If hidPhotoNamePassport3_2.Value <> "" Then
            PhotoPassport3_2.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport3_2.Value
            PhotoPassport3_2.Visible = True
            btnUploadPassport3_2.Visible = False
            FileUploadPassport3_2.Visible = False
            PhotoDeletePassport3_2.Visible = True
        Else
            PhotoPassport3_2.Visible = False
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
        If hidPhotoNameLicense3_2.Value <> "" Then
            PhotoLicense3_2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense3_2.Value
            PhotoLicense3_2.Visible = True
            btnUploadLicense3_2.Visible = False
            FileUploadLicense3_2.Visible = False
            PhotoDeleteLicense3_2.Visible = True
        Else
            PhotoLicense3_2.Visible = False
        End If

        If hidPhotoCer3.Value <> "" Then
            'PhotoCer3.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoCer3.Value
            'PhotoCer3.Visible = True
            btnUploadCer3.Visible = False
            FileUploadPhotoCer3.Visible = False
            PhotoDeleteCer3.Visible = True
            Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver") & "/")
            Dim tempFile = New System.IO.FileInfo(fpathstr & hidPhotoCer3.Value)
            linkPhotoCer3.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidPhotoCer3.Value & "&fname=" & Server.UrlPathEncode(hidPhotoCer3.Value) & "&fPath=FileLicenseDriver"
            linkPhotoCer3.Target = "_blank"
            linkPhotoCer3.Visible = True
        Else
            'PhotoCer3.Visible = False
            linkPhotoCer3.Visible = False
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
        If hidPhotoRegisCar_2.Value <> "" Then
            PhotoRegisCar_2.ImageUrl = "~/Upload/RegisterCar/" & hidPhotoRegisCar_2.Value
            PhotoRegisCar_2.Visible = True
            btnUploadRegisCar_2.Visible = False
            FileUpload4_2.Visible = False
            PhotoDeleteRegisCar_2.Visible = True
        Else
            PhotoRegisCar_2.Visible = False
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
        If hidPhotoAct_2.Value <> "" Then
            PhotoAct_2.ImageUrl = "~/Upload/Act/" & hidPhotoAct_2.Value
            PhotoAct_2.Visible = True
            btnUploadAct_2.Visible = False
            FileUpload5_2.Visible = False
            PhotoDeleteAct_2.Visible = True
        Else
            PhotoAct_2.Visible = False
        End If

        If hidPhotoAct2.Value <> "" Then
            PhotoAct2.ImageUrl = "~/Upload/Act/" & hidPhotoAct2.Value
            PhotoAct2.Visible = True
            btnUploadAct2.Visible = False
            FileUpload52.Visible = False
            PhotoDeleteAct2.Visible = True
        Else
            PhotoAct2.Visible = False
        End If
        If hidPhotoAct2_2.Value <> "" Then
            PhotoAct2_2.ImageUrl = "~/Upload/Act/" & hidPhotoAct2_2.Value
            PhotoAct2_2.Visible = True
            btnUploadAct2_2.Visible = False
            FileUpload52_2.Visible = False
            PhotoDeleteAct2_2.Visible = True
        Else
            PhotoAct2_2.Visible = False
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
        If hidAuthorize_2.Value <> "" Then
            PhotoAuthorize_2.ImageUrl = "~/Upload/Authorize/" & hidAuthorize_2.Value
            PhotoAuthorize_2.Visible = True
            btnUploadAuthorize_2.Visible = False
            FileUpload6_2.Visible = False
            PhotoDeleteAuthorize_2.Visible = True
        Else
            PhotoAuthorize_2.Visible = False
        End If

        If ddlPrename.SelectedValue = "Other" Then
            txtPrename.Visible = True
        Else
            txtPrename.Visible = False
        End If


        If ddlOwnerPrename.SelectedValue = "Other" Then
            txtOwnerPrename.Visible = True
        Else
            txtOwnerPrename.Visible = False
        End If



    End Sub

    Private Sub loaddata()
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con
            Dim strCheckUser As String = " SELECT driver.driver_id , passport_no , passport_expire , birthday , license_id , car.car_id , act.act_id , is_send ," &
                                         " comments_tab0 , comments_tab1 , comments_tab2 , comments_tab3 , comments_tab4 , comments_tab8 ," &
                                         " check_tab0 , check_tab1 , check_tab2 , check_tab3 , check_tab4 , check_tab8" &
                                         "  from driver " &
                                         " LEFT JOIN license on driver.driver_id = license.driver_id " &
                                         " LEFT JOIN car on license.car_id = car.car_id " &
                                         " LEFT JOIN act on license.act_id = act.act_id " &
                                         " WHERE license.token like '%" & Request.QueryString("token") & "%'"
            cmd.CommandText = CommandType.Text
            cmd.CommandText = strCheckUser
            dread = cmd.ExecuteReader()
            If dread.Read Then


                If dread("check_tab1") = 1 Then
                    Page1_2.Enabled = False
                    lblcomments1.Visible = False
                End If

                If dread("check_tab2") = 1 Then
                    Page2.Enabled = False
                    lblcomments2.Visible = False

                    If FileUpload1_2.Visible = True Then
                        FileUpload1_2.Enabled = False
                    End If

                    If FileUpload3_2.Visible = True Then
                        FileUpload3_2.Enabled = False
                    End If

                    If FileUploadPhotoCer.Visible = True Then
                        FileUploadPhotoCer.Enabled = False
                    End If

                    If FileUploadPassport2.Visible = True Then
                        FileUploadPassport2.Enabled = False
                    End If

                    If FileUploadPassport2_2.Visible = True Then
                        FileUploadPassport2_2.Enabled = False
                    End If

                    If FileUploadLicense2.Visible = True Then
                        FileUploadLicense2.Enabled = False
                    End If

                    If FileUploadLicense2_2.Visible = True Then
                        FileUploadLicense2_2.Enabled = False
                    End If

                    If FileUploadPhotoCer2.Visible = True Then
                        FileUploadPhotoCer2.Enabled = False
                    End If

                    If FileUploadPassport3.Visible = True Then
                        FileUploadPassport3.Enabled = False
                    End If

                    If FileUploadPassport3_2.Visible = True Then
                        FileUploadPassport3_2.Enabled = False
                    End If

                    If FileUploadLicense3.Visible = True Then
                        FileUploadLicense3.Enabled = False
                    End If

                    If FileUploadLicense3_2.Visible = True Then
                        FileUploadLicense3_2.Enabled = False
                    End If

                    If FileUploadPhotoCer3.Visible = True Then
                        FileUploadPhotoCer3.Enabled = False
                    End If

                End If

                If dread("check_tab3") = 1 Then
                    Page3.Enabled = False
                    lblcomments3.Visible = False

                    If FileUpload4.Visible = True Then
                        FileUpload4.Enabled = False
                    End If

                    If FileUpload4_2.Visible = True Then
                        FileUpload4_2.Enabled = False
                    End If

                    If FileUpload6.Visible = True Then
                        FileUpload6.Enabled = False
                    End If

                    If FileUpload6_2.Visible = True Then
                        FileUpload6_2.Enabled = False
                    End If

                    If FileUpload_cer.Visible = True Then
                        FileUpload_cer.Enabled = False
                    End If

                    If FileUpload_inspec.Visible = True Then
                        FileUpload_inspec.Enabled = False
                    End If

                    If FileUpload2.Visible = True Then
                        FileUpload2.Enabled = False
                    End If
                End If


                If dread("check_tab4") = 1 Then
                    Page4.Enabled = False
                    lblcomments4.Visible = False

                    If FileUpload5_2.Visible = True Then
                        FileUpload5_2.Enabled = False
                    End If

                    If FileUpload52_2.Visible = True Then
                        FileUpload52_2.Enabled = False
                    End If

                End If

                If dread("check_tab8") = 1 Then
                    Page8.Enabled = False
                    lblcomments8.Visible = False
                End If


                'If dread("comments_tab0") IsNot DBNull.Value Then
                '    lblcomments0.Text = " *Comments : " & dread("comments_tab0")
                'End If

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

                'If Request.QueryString("Page") IsNot Nothing Then
                '    pnSubmit.Visible = True
                'End If

                If Request.QueryString("is_renew") IsNot Nothing Then
                    Page1_2.Enabled = False
                    'Page2.Enabled = False
                    Page3.Enabled = False
                    Page8.Enabled = False
                    If Request.QueryString("ins") IsNot Nothing Then
                    Else
                        Page4.Enabled = False
                    End If


                End If
                hiddriver_id.Value = dread("driver_id")
                hidcar_id.Value = dread("car_id")
                hidlicense_id.Value = dread("license_id")
                If Not (dread("act_id") Is DBNull.Value) Then
                    hidact_id.Value = dread("act_id")
                End If

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

    Private Sub loadoldData()
        Dim dbconect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim strsql As String = ""
        Dim pScript As New StringBuilder
        pScript.Remove(0, pScript.Length)
        Try
            Npgsql.NpgsqlConnection.ClearPool(con)

            'con.ClearPool()
            cmd.Connection = con
            cmd.Connection.Open()

            strsql = "SELECT * FROM ( SELECT driver.*, car.*, act.*, act.act_id as actid, license.email as license_email, license_id, admin_id , token , driver.prename as prename, driver.name as name, driver.surname as surname , driver.photo_cer " &
                   " , spare_1.prename as prename1, spare_1.name as name1, spare_1.surname as surname1 ,spare_2.prename as prename2, spare_2.name as name2, spare_2.surname as surname2 , spare_1.photo_cer as photo_cer2 , spare_2.photo_cer as photo_cer3 " &
                   " , spare_1.passport_no as spare_1_passport_no, spare_1.passport_expire as spare_1_passport_expire, spare_2.passport_no as spare_2_passport_no, spare_2.passport_expire as spare_2_passport_expire " &
                   " , spare_1.national as spare_1_national, spare_1.license_no as spare_1_license_no, spare_2.national as spare_2_national, spare_2.license_no as spare_2_license_no " &
                   " , spare_1.licensedriver_photo as spare_1_licensedriver_photo, spare_1.passport_photo as spare_1_passport_photo , spare_1.licensedriver_photo_2 as spare_1_licensedriver_photo_2, spare_1.passport_photo_2 as spare_1_passport_photo_2 " &
                   " , spare_2.passport_photo as spare_2_passport_photo  , spare_2.licensedriver_photo as spare_2_licensedriver_photo , spare_2.passport_photo_2 as spare_2_passport_photo_2  , spare_2.licensedriver_photo_2 as spare_2_licensedriver_photo_2 " &
                   " , spare_1.license_exp_date as spare_1_license_exp_date, spare_2.license_exp_date as spare_2_license_exp_date " &
                   " , spare_1.address as spare_1_address, spare_1.state as spare_1_state, spare_1.country as spare_1_country, spare_1.zipcode as spare_1_zipcode, spare_1.tel as spare_1_tel, spare_1.email as spare_1_email, spare_1.gender as spare_1_gender " &
                   " , spare_2.address as spare_2_address, spare_2.state as spare_2_state, spare_2.country as spare_2_country, spare_2.zipcode as spare_2_zipcode, spare_2.tel as spare_2_tel, spare_2.email as spare_2_email, spare_2.gender as spare_2_gender " &
                   " , type_name as typecar_en, model as models, status_th, spare_1.sparedriver_id as sparedriver_id1, spare_2.sparedriver_id as sparedriver_id2, checkin_id, checkout_id, driver.county , photocar_cer " '& _


            'If Request.QueryString("rt") = 2 Then
            strsql = strsql & " ,name_company as com_name , CAST(user_name || ' ' || user_surname as varchar) as agen_name, info_company, history, user_travel.telephone as com_tel, user_travel.email as com_mail, company_license " &
            " , coalesce(user_travel.address,'')|| ' ตำบล' || t_name_t || ' อำเภอ' || a_name_t || ' จังหวัด' ||p_name_t|| ' ' ||coalesce(postal,'') as com_address "
            'End If
            strsql = strsql & " FROM license " &
             " LEFT JOIN driver on driver.driver_id = license.driver_id " &
             " LEFT JOIN spare_driver spare_1 on driver.driver_id = spare_1.driver_id and spare_1.spare_ord = 1 " &
             " LEFT JOIN spare_driver spare_2 on driver.driver_id = spare_2.driver_id and spare_2.spare_ord = 2 " &
             " LEFT JOIN car on car.car_id = license.car_id " &
             " LEFT JOIN act on act.act_id = license.act_id " &
             " LEFT JOIN type_car on car.typecar_id = type_car.type_id " &
             " LEFT JOIN status on license.status_id = status.status_id " '& _

            'If Request.QueryString("rt") = 2 Then
            strsql = strsql & " LEFT JOIN user_travel on user_travel.user_id = license.travel_id " &
            " LEFT JOIN tumbol on tumbol.t_id = user_travel.tumbol "
            'End If
            strsql = strsql & " WHERE token = '" & Request.QueryString("token") & "' ) as dt "
            cmd.CommandText = strsql
            Dim dr As NpgsqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then

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
                    txtOwnerIdcard.Text = dr("idcard_no")
                End If

                If Not dr("countries") Is DBNull.Value Then
                    ddlCountry.SelectedValue = dr("countries")
                End If

                If Not dr("passport_no") Is DBNull.Value Then
                    txtPassportNo.Text = dr("passport_no")
                End If

                If Not dr("passport_expire") Is DBNull.Value Then
                    'txtPassportExpire.Text = Format(dr("passport_expire"), "dd/MM/yyyy")
                    'txtPassportExpire.Text = Format(Month(dr("passport_expire")), "00") & "/" & Format(Day(dr("passport_expire")), "00") & "/" & Year(dr("passport_expire"))
                    txtPassportExpire.Text = Format(Day(dr("passport_expire")), "00") & "/" & Format(Month(dr("passport_expire")), "00") & "/" & Year(dr("passport_expire"))
                    pScript.Append("$(""#" & txtPassportExpire.ClientID & """).val('" & txtPassportExpire.Text & "');")
                End If

                If Not dr("prename") Is DBNull.Value Then
                    Select Case dr("prename")
                        Case "Mr.", "Mrs.", "Ms.", "Miss."
                            ddlPrename.SelectedValue = dr("prename")
                        Case "Other"
                            ddlPrename.SelectedValue = "Other"
                            txtPrename.Text = dr("prename")
                        Case Else
                            ddlPrename.SelectedValue = "Other"
                            txtPrename.Text = dr("prename")
                    End Select
                End If

                If Not dr("name") Is DBNull.Value Then
                    txtName.Text = dr("name")
                End If

                If Not dr("surname") Is DBNull.Value Then
                    txtSurname.Text = dr("surname")
                End If

                If Not dr("national") Is DBNull.Value Then
                    ddlNational.SelectedValue = dr("national")
                End If

                If Not dr("birthday") Is DBNull.Value Then
                    'txtDate.Text = Format(CDate(dr("birthday")), "dd/MM/yyyy")
                    'txtDate.Text = Format(Month(dr("birthday")), "00") & "/" & Format(Day(dr("birthday")), "00") & "/" & Year(dr("birthday"))
                    txtDate.Text = Format(Day(dr("birthday")), "00") & "/" & Format(Month(dr("birthday")), "00") & "/" & Year(dr("birthday"))
                    pScript.Append("$(""#" & txtDate.ClientID & """).val('" & txtDate.Text & "');")
                End If



                If Not dr("gender") Is DBNull.Value Then
                    ddlGender.Text = dr("gender")

                    If dr("gender") = "Female" Then
                        ddlGender.SelectedValue = "F"
                    Else
                        ddlGender.SelectedValue = "M"
                    End If
                    ddlGender.SelectedValue = dr("gender")
                End If

                If Not dr("idcard_no") Is DBNull.Value Then
                    txtLicenseDriver.Text = dr("idcard_no")
                End If

                If Not dr("license_expire") Is DBNull.Value Then
                    'txtLicenseExpire.Text = Format(dr("license_expire"), "dd/MM/yyyy")
                    'txtLicenseExpire.Text = Format(Month(dr("license_expire")), "00") & "/" & Format(Day(dr("license_expire")), "00") & "/" & Year(dr("license_expire"))
                    txtLicenseExpire.Text = Format(Day(dr("license_expire")), "00") & "/" & Format(Month(dr("license_expire")), "00") & "/" & Year(dr("license_expire"))
                    pScript.Append("$(""#" & txtLicenseExpire.ClientID & """).val('" & txtLicenseExpire.Text & "');")
                End If

                If Not dr("address") Is DBNull.Value Then
                    txtAddress.Text = dr("address")
                End If

                If Not dr("county") Is DBNull.Value Then
                    txtCounty.Text = dr("county")
                End If

                If Not dr("zipcode") Is DBNull.Value Then
                    txtZipcode.Text = dr("zipcode")
                End If

                If Not dr("tel") Is DBNull.Value Then
                    txtTel.Text = dr("tel")
                End If

                If Not dr("email") Is DBNull.Value Then
                    txtEmail.Text = dr("email")
                End If

                If Not dr("passport_photo") Is DBNull.Value Then
                    hidPhotoNamePassport.Value = dr("passport_photo")
                End If

                If Not dr("licensedriver_photo") Is DBNull.Value Then
                    hidPhotoNameLicense.Value = dr("licensedriver_photo")
                End If

                If Not dr("passport_photo_2") Is DBNull.Value Then
                    hidPhotoNamePassport_2.Value = dr("passport_photo_2")
                End If

                If Not dr("licensedriver_photo_2") Is DBNull.Value Then
                    hidPhotoNameLicense_2.Value = dr("licensedriver_photo_2")
                End If

                If Not dr("photo_cer") Is DBNull.Value Then
                    hidPhotoCer.Value = dr("photo_cer")
                End If



                If Not dr("photo_cer2") Is DBNull.Value Then
                    hidPhotoCer2.Value = dr("photo_cer2")
                End If


                If Not dr("photo_cer3") Is DBNull.Value Then
                    hidPhotoCer3.Value = dr("photo_cer3")
                End If


                If Not dr("prename1") Is DBNull.Value Then
                    Select Case dr("prename1")
                        Case "Mr.", "Mrs.", "Ms.", "Miss."
                            ddlPrename2.SelectedValue = dr("prename1")
                        Case "Other"
                            ddlPrename2.SelectedValue = "Other"
                            txtPrename2.Text = dr("prename1")
                        Case Else
                            ddlPrename2.SelectedValue = "Other"
                            txtPrename2.Text = dr("prename1")
                    End Select
                End If

                If Not dr("name1") Is DBNull.Value Then
                    txtName2.Text = dr("name1")
                End If

                If Not dr("surname1") Is DBNull.Value Then
                    txtSurname2.Text = dr("surname1")
                End If

                If Not dr("spare_1_licensedriver_photo") Is DBNull.Value Then
                    hidPhotoNameLicense2.Value = dr("spare_1_licensedriver_photo")
                End If
                If Not dr("spare_1_licensedriver_photo_2") Is DBNull.Value Then
                    hidPhotoNameLicense2_2.Value = dr("spare_1_licensedriver_photo_2")
                End If

                If Not dr("spare_1_license_exp_date") Is DBNull.Value Then
                    'txtLicenseExpire2.Text = Format(Month(dr("spare_1_license_exp_date")), "00") & "/" & Format(Day(dr("spare_1_license_exp_date")), "00") & "/" & Year(dr("spare_1_license_exp_date"))
                    txtLicenseExpire2.Text = Format(Day(dr("spare_1_license_exp_date")), "00") & "/" & Format(Month(dr("spare_1_license_exp_date")), "00") & "/" & Year(dr("spare_1_license_exp_date"))
                    pScript.Append("$(""#" & txtLicenseExpire2.ClientID & """).val('" & txtLicenseExpire2.Text & "');")
                End If

                If Not dr("spare_1_passport_no") Is DBNull.Value Then
                    txtPassportNo2.Text = dr("spare_1_passport_no")
                End If

                If Not dr("spare_1_passport_expire") Is DBNull.Value Then
                    'txtexp_pass_date1.Text = Format(dr("spare_1_passport_expire"), "yyyy-MM-dd")
                    'txtPassport_exp2.Text = Format(Month(dr("spare_1_passport_expire")), "00") & "/" & Format(Day(dr("spare_1_passport_expire")), "00") & "/" & Year(dr("spare_1_passport_expire"))
                    txtPassport_exp2.Text = Format(Day(dr("spare_1_passport_expire")), "00") & "/" & Format(Month(dr("spare_1_passport_expire")), "00") & "/" & Year(dr("spare_1_passport_expire"))
                    pScript.Append("$(""#" & txtPassport_exp2.ClientID & """).val('" & txtPassport_exp2.Text & "');")
                End If

                If Not dr("spare_1_passport_photo") Is DBNull.Value Then
                    hidPhotoNamePassport2.Value = dr("spare_1_passport_photo")
                End If
                If Not dr("spare_1_passport_photo_2") Is DBNull.Value Then
                    hidPhotoNamePassport2_2.Value = dr("spare_1_passport_photo_2")
                End If

                If Not dr("spare_1_national") Is DBNull.Value Then
                    ddlNational2.SelectedValue = dr("spare_1_national")
                End If

                If Not dr("spare_1_license_no") Is DBNull.Value Then
                    txtLicense2.Text = dr("spare_1_license_no")
                End If

                If Not dr("spare_1_address") Is DBNull.Value Then
                    txtAddress2.Text = dr("spare_1_address")
                End If

                'If Not dr("spare_1_state") Is DBNull.Value Then
                '    txtstate_driver1.Text = dr("spare_1_state")
                'End If

                If Not dr("spare_1_country") Is DBNull.Value Then
                    ddlCountry2.SelectedValue = dr("spare_1_country")
                End If

                If Not dr("spare_1_zipcode") Is DBNull.Value Then
                    txtZipcode2.Text = dr("spare_1_zipcode")
                End If

                If Not dr("spare_1_tel") Is DBNull.Value Then
                    txtTel2.Text = dr("spare_1_tel")
                End If

                If Not dr("spare_1_email") Is DBNull.Value Then
                    txtEmail2.Text = dr("spare_1_email")
                End If

                If Not dr("spare_1_gender") Is DBNull.Value Then


                    ddlGender2.SelectedValue = dr("spare_1_gender")
                End If



                If Not dr("prename2") Is DBNull.Value Then
                    Select Case dr("prename2")
                        Case "Mr.", "Mrs.", "Ms.", "Miss."
                            ddlPrename3.SelectedValue = dr("prename2")
                        Case "Other"
                            ddlPrename3.SelectedValue = "Other"
                            txtPrename3.Text = dr("prename2")
                        Case Else
                            ddlPrename3.SelectedValue = "Other"
                            txtPrename3.Text = dr("prename2")
                    End Select
                End If

                If Not dr("name2") Is DBNull.Value Then
                    txtName3.Text = dr("name2")
                End If

                If Not dr("surname2") Is DBNull.Value Then
                    txtSurname3.Text = dr("surname2")
                End If

                If Not dr("spare_2_licensedriver_photo") Is DBNull.Value Then
                    hidPhotoNameLicense3.Value = dr("spare_2_licensedriver_photo")
                End If
                If Not dr("spare_2_licensedriver_photo_2") Is DBNull.Value Then
                    hidPhotoNameLicense3_2.Value = dr("spare_2_licensedriver_photo_2")
                End If


                If Not dr("spare_2_license_exp_date") Is DBNull.Value Then
                    'txtLicenseExpire3.Text = Format(Month(dr("spare_2_license_exp_date")), "00") & "/" & Format(Day(dr("spare_2_license_exp_date")), "00") & "/" & Year(dr("spare_2_license_exp_date"))
                    txtLicenseExpire3.Text = Format(Day(dr("spare_2_license_exp_date")), "00") & "/" & Format(Month(dr("spare_2_license_exp_date")), "00") & "/" & Year(dr("spare_2_license_exp_date"))
                    pScript.Append("$(""#" & txtLicenseExpire3.ClientID & """).val('" & txtLicenseExpire3.Text & "');")
                End If

                If Not dr("spare_2_passport_no") Is DBNull.Value Then
                    txtPassportNo3.Text = dr("spare_2_passport_no")
                End If


                If Not dr("spare_2_passport_expire") Is DBNull.Value Then
                    'txtexp_pass_date2.Text = Format(dr("spare_2_passport_expire"), "yyyy-MM-dd")
                    'txtPassport_exp3.Text = Format(Month(dr("spare_2_passport_expire")), "00") & "/" & Format(Day(dr("spare_2_passport_expire")), "00") & "/" & Year(dr("spare_2_passport_expire"))
                    txtPassport_exp3.Text = Format(Day(dr("spare_2_passport_expire")), "00") & "/" & Format(Month(dr("spare_2_passport_expire")), "00") & "/" & Year(dr("spare_2_passport_expire"))
                    pScript.Append("$(""#" & txtPassport_exp3.ClientID & """).val('" & txtPassport_exp3.Text & "');")
                End If

                If Not dr("spare_2_passport_photo") Is DBNull.Value Then
                    hidPhotoNamePassport3.Value = dr("spare_2_passport_photo")
                End If
                If Not dr("spare_2_passport_photo_2") Is DBNull.Value Then
                    hidPhotoNamePassport3_2.Value = dr("spare_2_passport_photo_2")
                End If

                If Not dr("spare_2_national") Is DBNull.Value Then
                    ddlNational3.SelectedValue = dr("spare_2_national")
                End If

                If Not dr("spare_2_license_no") Is DBNull.Value Then
                    txtLicense3.Text = dr("spare_2_license_no")
                End If

                If Not dr("spare_2_address") Is DBNull.Value Then
                    txtAddress3.Text = dr("spare_2_address")
                End If



                If Not dr("spare_2_country") Is DBNull.Value Then
                    ddlCountry3.SelectedValue = dr("spare_2_country")
                End If

                If Not dr("spare_2_zipcode") Is DBNull.Value Then
                    txtZipcode3.Text = dr("spare_2_zipcode")
                End If

                If Not dr("spare_2_tel") Is DBNull.Value Then
                    txtTel3.Text = dr("spare_2_tel")
                End If

                If Not dr("spare_2_email") Is DBNull.Value Then
                    txtEmail3.Text = dr("spare_2_email")
                End If

                If Not dr("spare_2_gender") Is DBNull.Value Then


                    ddlGender3.SelectedValue = dr("spare_2_gender")
                End If


                If Not dr("brands") Is DBNull.Value Then
                    txtBrands.Text = dr("brands")
                End If

                If Not dr("models") Is DBNull.Value Then
                    txtModel.Text = dr("models")
                End If

                If Not dr("plate") Is DBNull.Value Then
                    txtLicenseCar.Text = dr("plate")
                End If

                If Not dr("platelocal") Is DBNull.Value Then
                    txtLicenseLocalCar.Text = dr("platelocal")
                End If

                If Not dr("seat") Is DBNull.Value Then
                    txtSeats.Text = dr("seat")
                End If

                If Not dr("weight") Is DBNull.Value Then
                    txtWeight.Text = dr("weight")
                End If



                If Not dr("colors") Is DBNull.Value Then
                    ddlColor.Text = dr("colors")
                End If

                If Not dr("engine_no") Is DBNull.Value Then
                    txtNumEngine.Text = dr("engine_no")
                End If

                If Not dr("car_no") Is DBNull.Value Then
                    txtNumcar.Text = dr("car_no")
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
                    txtEnginCap.Text = dr("engine_cap")
                End If



                If dr("is_juristic") = 0 Then
                    chkisJuristic.Checked = False
                    If Not dr("owner_prename") Is DBNull.Value Then
                        Select Case dr("owner_prename")
                            Case "Mr.", "Mrs.", "Ms.", "Miss."
                                ddlOwnerPrename.SelectedValue = dr("owner_prename")
                            Case "Other"
                                ddlOwnerPrename.SelectedValue = "Other"
                                txtOwnerPrename.Text = dr("owner_prename")
                            Case Else
                                ddlOwnerPrename.SelectedValue = "Other"
                                txtOwnerPrename.Text = dr("owner_prename")
                        End Select
                    End If
                    If dr("owner_name") IsNot DBNull.Value Then
                        txtOwnerName.Text = dr("owner_name")
                    End If
                    If dr("owner_idcard") IsNot DBNull.Value Then
                        txtOwnerIdcard.Text = dr("owner_idcard")
                    End If
                    If dr("owner_lastname") IsNot DBNull.Value Then
                        txtOwnerLastName.Text = dr("owner_lastname")
                    End If
                Else
                    chkisJuristic.Checked = True
                    If dr("owner_name") IsNot DBNull.Value Then
                        txtJuristicName.Text = dr("owner_name")
                    End If
                    If dr("owner_idcard") IsNot DBNull.Value Then
                        txtJuristicID.Text = dr("owner_idcard")
                    End If
                End If

                If dr("owner_address") IsNot DBNull.Value Then
                    txtOwnerAddress.Text = dr("owner_address")
                End If
                If dr("owner_zipcode") IsNot DBNull.Value Then
                    txtOwnerZipcode.Text = dr("owner_zipcode")
                End If
                If dr("owner_province") IsNot DBNull.Value Then
                    txtOwnerProvince.Text = dr("owner_province")
                End If

                If dr("owner_country") IsNot DBNull.Value Then
                    ddlOwnerCountry.SelectedValue = dr("owner_country")
                End If

                If dr("owner_tel") IsNot DBNull.Value Then
                    txtOwnertel.Text = dr("owner_tel")
                End If

                If dr("license_email") IsNot DBNull.Value Then
                    txtLicenseEmail.Text = dr("license_email")
                End If



                If dr("act_photo") IsNot DBNull.Value Then
                    hidPhotoAct.Value = dr("act_photo")
                    PhotoAct.ImageUrl = "~/Upload/Act/" & hidPhotoAct.Value
                    PhotoAct.Visible = True
                    btnUploadAct.Visible = False
                    FileUpload5.Visible = False
                    PhotoDeleteAct.Visible = True
                End If
                If dr("act_photo_2") IsNot DBNull.Value Then
                    hidPhotoAct_2.Value = dr("act_photo_2")
                    PhotoAct_2.ImageUrl = "~/Upload/Act/" & hidPhotoAct_2.Value
                    PhotoAct_2.Visible = True
                    btnUploadAct_2.Visible = False
                    FileUpload5_2.Visible = False
                    PhotoDeleteAct_2.Visible = True
                End If

                If dr("act_photo2") IsNot DBNull.Value Then
                    hidPhotoAct2.Value = dr("act_photo2")
                    PhotoAct2.ImageUrl = "~/Upload/Act/" & hidPhotoAct2.Value
                    PhotoAct2.Visible = True
                    btnUploadAct2.Visible = False
                    FileUpload52.Visible = False
                    PhotoDeleteAct2.Visible = True
                End If
                If dr("act_photo2_2") IsNot DBNull.Value Then
                    hidPhotoAct2_2.Value = dr("act_photo2_2")
                    PhotoAct2_2.ImageUrl = "~/Upload/Act/" & hidPhotoAct2_2.Value
                    PhotoAct2_2.Visible = True
                    btnUploadAct2_2.Visible = False
                    FileUpload52_2.Visible = False
                    PhotoDeleteAct2_2.Visible = True
                End If





                If Not dr("act_no") Is DBNull.Value Then
                    txtActNo.Text = dr("act_no")
                End If

                If Not dr("act_company") Is DBNull.Value Then
                    txtActCompany.Text = dr("act_company")
                End If

                If Not dr("act_start") Is DBNull.Value Then
                    'txtstart_date.Text = Format(dr("act_start"), "yyyy-MM-dd")
                    'txtActStart.Text = Format(Month(dr("act_start")), "00") & "/" & Format(Day(dr("act_start")), "00") & "/" & Year(dr("act_start"))
                    txtActStart.Text = Format(Day(dr("act_start")), "00") & "/" & Format(Month(dr("act_start")), "00") & "/" & Year(dr("act_start"))
                    pScript.Append("$(""#" & txtActStart.ClientID & """).val('" & txtActStart.Text & "');")
                End If

                If Not dr("act_ends") Is DBNull.Value Then
                    'txtend_date.Text = Format(dr("act_ends"), "yyyy-MM-dd")
                    'txtActExpire.Text = Format(Month(dr("act_ends")), "00") & "/" & Format(Day(dr("act_ends")), "00") & "/" & Year(dr("act_ends"))
                    txtActExpire.Text = Format(Day(dr("act_ends")), "00") & "/" & Format(Month(dr("act_ends")), "00") & "/" & Year(dr("act_ends"))
                    pScript.Append("$(""#" & txtActExpire.ClientID & """).val('" & txtActExpire.Text & "');")
                End If


                If Not dr("act_no2") Is DBNull.Value Then
                    txtActNo2.Text = dr("act_no2")
                End If

                If Not dr("act_company2") Is DBNull.Value Then
                    txtActCompany2.Text = dr("act_company2")
                End If

                If Not dr("act_start2") Is DBNull.Value Then
                    'txtstart_date.Text = Format(dr("act_start"), "yyyy-MM-dd")
                    'txtActStart2.Text = Format(Month(dr("act_start2")), "00") & "/" & Format(Day(dr("act_start2")), "00") & "/" & Year(dr("act_start2"))
                    txtActStart2.Text = Format(Day(dr("act_start2")), "00") & "/" & Format(Month(dr("act_start2")), "00") & "/" & Year(dr("act_start2"))
                    pScript.Append("$(""#" & txtActStart2.ClientID & """).val('" & txtActStart2.Text & "');")
                End If

                If Not dr("act_ends2") Is DBNull.Value Then
                    'txtend_date.Text = Format(dr("act_ends"), "yyyy-MM-dd")
                    'txtActExpire2.Text = Format(Month(dr("act_ends2")), "00") & "/" & Format(Day(dr("act_ends2")), "00") & "/" & Year(dr("act_ends2"))
                    txtActExpire2.Text = Format(Day(dr("act_ends2")), "00") & "/" & Format(Month(dr("act_ends2")), "00") & "/" & Year(dr("act_ends2"))
                    pScript.Append("$(""#" & txtActExpire2.ClientID & """).val('" & txtActExpire2.Text & "');")
                End If




                If Not dr("checkin_id") Is DBNull.Value Then
                    ddlBorderCheckin.SelectedValue = dr("checkin_id")
                End If



                If Not dr("admin_id") Is DBNull.Value Then
                    ddladmin.SelectedValue = dr("admin_id")
                End If



                If dr("regis_photo") IsNot DBNull.Value Then
                    hidPhotoRegisCar.Value = dr("regis_photo")
                    PhotoRegisCar.ImageUrl = "~/Upload/RegisterCar/" & hidPhotoRegisCar.Value
                    PhotoRegisCar.Visible = True
                    btnUploadRegisCar.Visible = False
                    FileUpload4.Visible = False
                    PhotoDeleteRegisCar.Visible = True
                End If
                If dr("regis_photo_2") IsNot DBNull.Value Then
                    hidPhotoRegisCar_2.Value = dr("regis_photo_2")
                    PhotoRegisCar_2.ImageUrl = "~/Upload/RegisterCar/" & hidPhotoRegisCar_2.Value
                    PhotoRegisCar_2.Visible = True
                    btnUploadRegisCar_2.Visible = False
                    FileUpload4_2.Visible = False
                    PhotoDeleteRegisCar_2.Visible = True
                End If

                If dr("authorize_car") IsNot DBNull.Value Then
                    hidAuthorize.Value = dr("authorize_car")
                    PhotoAuthorize.ImageUrl = "~/Upload/Authorize/" & hidAuthorize.Value
                    PhotoAuthorize.Visible = True
                    btnUploadAuthorize.Visible = False
                    FileUpload6.Visible = False
                    PhotoDeleteAuthorize.Visible = True
                End If
                If dr("authorize_car_2") IsNot DBNull.Value Then
                    hidAuthorize_2.Value = dr("authorize_car_2")
                    PhotoAuthorize_2.ImageUrl = "~/Upload/Authorize/" & hidAuthorize_2.Value
                    PhotoAuthorize_2.Visible = True
                    btnUploadAuthorize_2.Visible = False
                    FileUpload6_2.Visible = False
                    PhotoDeleteAuthorize_2.Visible = True
                End If

            End If
            dr.Close()



            Dim sqlstr As String
            Dim sqlstr2 As String

            'อัพโหลดรูปภาพ 
            sqlstr = "select gid , car_id , file_name, ImgType  from car_pic WHERE car_id = '" & hidcar_id.Value & "' "

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



            'อัพโหลดรูปภาพใบแปลรถ
            Dim sqlstr3 = "select gid , car_id , file_name  from car_cer WHERE car_id = '" & hidcar_id.Value & "' "

            Dim DataTable3 As DataTable = dbconect.getDataTable(sqlstr3, "DataTable")
            With DataTable3.Columns
                .Add(New DataColumn("PathImg"))
            End With

            For Each nrow As DataRow In DataTable3.Rows
                nrow("PathImg") = "~/Upload/RegisterCar/" & nrow("file_name")
                If Not nrow("file_name") Is DBNull.Value Then
                    hidPhotonamecar_cer.Value = nrow("file_name")
                End If
            Next

            If DataTable3.Rows.Count > 0 Then


            End If


            ' ใบตรวจสอบสภาพรถ
            Dim sqlstr4 = "select gid , car_id , file_name  from car_inspec WHERE car_id = '" & hidcar_id.Value & "' "

            Dim DataTable4 As DataTable = dbconect.getDataTable(sqlstr4, "DataTable")
            With DataTable4.Columns
                .Add(New DataColumn("PathImg"))
            End With

            For Each nrow As DataRow In DataTable4.Rows
                nrow("PathImg") = "~/Upload/RegisterCar/" & nrow("file_name")
            Next

            If DataTable4.Rows.Count > 0 Then
                gvFile_inspec.DataSource = DataTable4
                gvFile_inspec.DataBind()

                DtlImg_inspec.DataSource = DataTable4
                DtlImg_inspec.DataBind()
            End If




            'จังหวัด 
            sqlstr2 = "select area_id , prov_en , area.prov_code from area LEFT JOIN province on province.prov_code = area.prov_code WHERE license_id = '" & hidlicense_id.Value & "' "
            Dim Datatable2 As DataTable = dbconect.getDataTable(sqlstr2, "DataTable2")

            If Datatable2.Rows.Count > 0 Then
                gvProv.DataSource = Datatable2
                gvProv.DataBind()
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

    Private Sub AddPopupMapAdmin(ByVal paraMap As String)
        Dim strPopup As String = "javascript:w=window.open(" &
                        """" & ResolveClientUrl("~/Map/MapAdmin2.aspx?" & paraMap) & """," &
                        """SearchMapAdminWindow""," &
                        """" & "location=0,status=0,scrollbars=yes,resizable=no," &
                        "width=1024,height=780""" &
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

    Protected Sub ddlPrename2_SelectIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPrename2.SelectedIndexChanged
        If ddlPrename2.SelectedValue = "Other" Then
            txtPrename2.Visible = True
        Else
            txtPrename2.Visible = False
        End If
    End Sub

    Protected Sub ddlPrename3_SelectIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPrename3.SelectedIndexChanged
        If ddlPrename3.SelectedValue = "Other" Then
            txtPrename3.Visible = True
        Else
            txtPrename3.Visible = False
        End If
    End Sub


    Protected Sub ddlOwnerPrename_SelectIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlOwnerPrename.SelectedIndexChanged
        If ddlOwnerPrename.SelectedValue = "Other" Then
            txtOwnerPrename.Visible = True
        Else
            txtOwnerPrename.Visible = False
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
            End If
        End If
    End Sub

    '''อัพโหลด และ ลบ รูป พาสปอร์ต _2
    Protected Sub PhotoDeletePassport_2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeletePassport_2.Command
        If File.Exists(fPathPassport & hidPhotoNamePassport_2.Value) Then
            File.Delete(fPathPassport & hidPhotoNamePassport_2.Value)
        End If
        btnUploadPassport_2.Visible = True
        FileUpload1_2.Visible = True
        hidPhotoNamePassport_2.Value = ""
        PhotoPassport_2.Visible = False
        PhotoDeletePassport_2.Visible = False
    End Sub
    Protected Sub btnUploadPassport_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadPassport_2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload1_2.PostedFile.FileName <> "" Then
            If FileUpload1_2.HasFile Then
                srcName = Path.GetFileName(FileUpload1_2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload1_2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload1_2.PostedFile.SaveAs(Server.MapPath("~/Upload/Passport/") + srcName & srcExt)
                hidPhotoNamePassport_2.Value = srcName & srcExt
                PhotoPassport_2.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport_2.Value
                PhotoPassport_2.Visible = True
                btnUploadPassport_2.Visible = False
                FileUpload1_2.Visible = False
                PhotoDeletePassport_2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver1');", True)
            End If
        End If
    End Sub

    '''อัพโหลด และ ลบ รูป พาสปอร์ต คนที่2 _2
    Protected Sub PhotoDeletePassport2_2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeletePassport2_2.Command
        If File.Exists(fPathPassport & hidPhotoNamePassport2_2.Value) Then
            File.Delete(fPathPassport & hidPhotoNamePassport2_2.Value)
        End If
        btnUploadPassport2_2.Visible = True
        FileUploadPassport2_2.Visible = True
        hidPhotoNamePassport2_2.Value = ""
        PhotoPassport2_2.Visible = False
        PhotoDeletePassport2_2.Visible = False
    End Sub
    Protected Sub btnUploadPassport2_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadPassport2_2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadPassport2_2.PostedFile.FileName <> "" Then
            If FileUploadPassport2_2.HasFile Then
                srcName = Path.GetFileName(FileUploadPassport2_2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadPassport2_2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUploadPassport2_2.PostedFile.SaveAs(Server.MapPath("~/Upload/Passport/") + srcName & srcExt)
                hidPhotoNamePassport2_2.Value = srcName & srcExt
                PhotoPassport2_2.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport2_2.Value
                PhotoPassport2_2.Visible = True
                btnUploadPassport2_2.Visible = False
                FileUploadPassport2_2.Visible = False
                PhotoDeletePassport2_2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver1');", True)
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
                PhotoPassport3.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport3.Value
                PhotoPassport3.Visible = True
                btnUploadPassport3.Visible = False
                FileUploadPassport3.Visible = False
                PhotoDeletePassport3.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver2');", True)
            End If
        End If
    End Sub

    '''อัพโหลด และ ลบ รูป พาสปอร์ต คนที่3 _2
    Protected Sub PhotoDeletePassport3_2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeletePassport3_2.Command
        If File.Exists(fPathPassport & hidPhotoNamePassport3_2.Value) Then
            File.Delete(fPathPassport & hidPhotoNamePassport3_2.Value)
        End If
        btnUploadPassport3_2.Visible = True
        FileUploadPassport3_2.Visible = True
        hidPhotoNamePassport3_2.Value = ""
        PhotoPassport3_2.Visible = False
        PhotoDeletePassport3_2.Visible = False
    End Sub
    Protected Sub btnUploadPassport3_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadPassport3_2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadPassport3_2.PostedFile.FileName <> "" Then
            If FileUploadPassport3_2.HasFile Then
                srcName = Path.GetFileName(FileUploadPassport3_2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadPassport3_2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUploadPassport3_2.PostedFile.SaveAs(Server.MapPath("~/Upload/Passport/") + srcName & srcExt)
                hidPhotoNamePassport3_2.Value = srcName & srcExt
                PhotoPassport3_2.ImageUrl = "~/Upload/Passport/" & hidPhotoNamePassport3_2.Value
                PhotoPassport3_2.Visible = True
                btnUploadPassport3_2.Visible = False
                FileUploadPassport3_2.Visible = False
                PhotoDeletePassport3_2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver2');", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
            End If
        End If
    End Sub

    '''อัพโหลด และ ลบ รูป ใบอนุญาตขับรถ _2
    Protected Sub PhotoDeleteLicense_2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteLicense_2.Command
        If File.Exists(fPathLicense & hidPhotoNameLicense_2.Value) Then
            File.Delete(fPathLicense & hidPhotoNameLicense_2.Value)
        End If
        btnUploadLicense_2.Visible = True
        FileUpload3_2.Visible = True
        hidPhotoNameLicense_2.Value = ""
        PhotoLicense_2.Visible = False
        PhotoDeleteLicense_2.Visible = False
    End Sub

    Protected Sub btnUploadLicense_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadLicense_2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload3_2.PostedFile.FileName <> "" Then
            If FileUpload3_2.HasFile Then
                srcName = Path.GetFileName(FileUpload3_2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload3_2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload3_2.PostedFile.SaveAs(Server.MapPath("~/Upload/LicenseDriver/") + srcName & srcExt)
                hidPhotoNameLicense_2.Value = srcName & srcExt
                PhotoLicense_2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense_2.Value
                PhotoLicense_2.Visible = True
                btnUploadLicense_2.Visible = False
                FileUpload3_2.Visible = False
                PhotoDeleteLicense_2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); ", True)
            End If
        End If
    End Sub

    '''อัพโหลด และ ลบ รูป ใบ Cer
    Protected Sub PhotoDeleteCer_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteCer.Command
        If File.Exists(fPathLicense & hidPhotoCer.Value) Then
            File.Delete(fPathLicense & hidPhotoCer.Value)
        End If
        btnUploadCer.Visible = True
        FileUploadPhotoCer.Visible = True
        hidPhotoCer.Value = ""
        'PhotoCer.Visible = False
        linkPhotoCer.Visible = False
        PhotoDeleteCer.Visible = False
    End Sub

    Protected Sub btnUploadCer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadCer.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadPhotoCer.PostedFile.FileName <> "" Then
            If FileUploadPhotoCer.HasFile Then
                srcName = Path.GetFileName(FileUploadPhotoCer.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadPhotoCer.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                If supportedFilePDF.Contains("," & srcExt.ToLower.Trim & ",") Then
                    FileUploadPhotoCer.PostedFile.SaveAs(Server.MapPath("~/Upload/LicenseDriver/") + srcName & srcExt)
                    hidPhotoCer.Value = srcName & srcExt
                    'PhotoCer.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoCer.Value
                    'PhotoCer.Visible = True
                    linkPhotoCer.Visible = True
                    btnUploadCer.Visible = False
                    FileUploadPhotoCer.Visible = False
                    PhotoDeleteCer.Visible = True

                    Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver") & "/")
                    Dim tempFile = New System.IO.FileInfo(fpathstr & hidPhotoCer.Value)
                    linkPhotoCer.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidPhotoCer.Value & "&fname=" & Server.UrlPathEncode(hidPhotoCer.Value) & "&fPath=FileLicenseDriver"
                    linkPhotoCer.Target = "_blank"
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver0'); ", True)
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver0'); alert('Please attach a pdf file'); ", True)
                End If
            End If
        End If
    End Sub
    '''อัพโหลด และ ลบ รูป ใบ Cer คนขับสำรอง 1 
    Protected Sub PhotoDeleteCer2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteCer2.Command
        If File.Exists(fPathLicense & hidPhotoCer2.Value) Then
            File.Delete(fPathLicense & hidPhotoCer2.Value)
        End If
        btnUploadCer2.Visible = True
        FileUploadPhotoCer2.Visible = True
        hidPhotoCer2.Value = ""
        'PhotoCer2.Visible = False
        linkPhotoCer2.Visible = False
        PhotoDeleteCer2.Visible = False
    End Sub

    Protected Sub btnUploadCer2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadCer2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadPhotoCer2.PostedFile.FileName <> "" Then
            If FileUploadPhotoCer2.HasFile Then
                srcName = Path.GetFileName(FileUploadPhotoCer2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadPhotoCer2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                If supportedFilePDF.Contains("," & srcExt.ToLower.Trim & ",") Then
                    FileUploadPhotoCer2.PostedFile.SaveAs(Server.MapPath("~/Upload/LicenseDriver/") + srcName & srcExt)
                    hidPhotoCer2.Value = srcName & srcExt
                    'PhotoCer2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoCer2.Value
                    'PhotoCer2.Visible = True
                    linkPhotoCer2.Visible = True
                    btnUploadCer2.Visible = False
                    FileUploadPhotoCer2.Visible = False
                    PhotoDeleteCer2.Visible = True

                    Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver") & "/")
                    Dim tempFile = New System.IO.FileInfo(fpathstr & hidPhotoCer2.Value)
                    linkPhotoCer2.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidPhotoCer2.Value & "&fname=" & Server.UrlPathEncode(hidPhotoCer2.Value) & "&fPath=FileLicenseDriver"
                    linkPhotoCer2.Target = "_blank"
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver1'); ", True)
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver1'); alert('Please attach a pdf file'); ", True)
                End If
            End If
        End If
    End Sub

    '''อัพโหลด และ ลบ รูป ใบ Cer คนขับสำรอง 2
    Protected Sub PhotoDeleteCer3_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteCer3.Command
        If File.Exists(fPathLicense & hidPhotoCer3.Value) Then
            File.Delete(fPathLicense & hidPhotoCer3.Value)
        End If
        btnUploadCer3.Visible = True
        FileUploadPhotoCer3.Visible = True
        hidPhotoCer3.Value = ""
        'PhotoCer3.Visible = False
        linkPhotoCer3.Visible = False
        PhotoDeleteCer3.Visible = False
    End Sub

    Protected Sub btnUploadCer3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadCer3.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadPhotoCer3.PostedFile.FileName <> "" Then
            If FileUploadPhotoCer3.HasFile Then
                srcName = Path.GetFileName(FileUploadPhotoCer3.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadPhotoCer3.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                If supportedFilePDF.Contains("," & srcExt.ToLower.Trim & ",") Then

                    FileUploadPhotoCer3.PostedFile.SaveAs(Server.MapPath("~/Upload/LicenseDriver/") + srcName & srcExt)
                    hidPhotoCer3.Value = srcName & srcExt
                    'PhotoCer3.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoCer3.Value
                    'PhotoCer3.Visible = True
                    linkPhotoCer3.Visible = True
                    btnUploadCer3.Visible = False
                    FileUploadPhotoCer3.Visible = False
                    PhotoDeleteCer3.Visible = True

                    Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver") & "/")
                    Dim tempFile = New System.IO.FileInfo(fpathstr & hidPhotoCer3.Value)
                    linkPhotoCer3.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidPhotoCer3.Value & "&fname=" & Server.UrlPathEncode(hidPhotoCer3.Value) & "&fPath=FileLicenseDriver"
                    linkPhotoCer3.Target = "_blank"
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver2');", True)
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver2'); alert('Please attach a pdf file'); ", True)
                End If
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver1');", True)
            End If
        End If
    End Sub

    '''อัพโหลด และ ลบ รูป ใบอนุญาตขับรถ คนที่2 _2
    Protected Sub PhotoDeleteLicense2_2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteLicense2_2.Command
        If File.Exists(fPathLicense & hidPhotoNameLicense2_2.Value) Then
            File.Delete(fPathLicense & hidPhotoNameLicense2_2.Value)
        End If
        btnUploadLicense2_2.Visible = True
        FileUploadLicense2_2.Visible = True
        hidPhotoNameLicense2_2.Value = ""
        PhotoLicense2_2.Visible = False
        PhotoDeleteLicense2_2.Visible = False
    End Sub

    Protected Sub btnUploadLicense2_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadLicense2_2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadLicense2_2.PostedFile.FileName <> "" Then
            If FileUploadLicense2_2.HasFile Then
                srcName = Path.GetFileName(FileUploadLicense2_2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadLicense2_2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUploadLicense2_2.PostedFile.SaveAs(Server.MapPath("~/Upload/LicenseDriver/") + srcName & srcExt)
                hidPhotoNameLicense2_2.Value = srcName & srcExt
                PhotoLicense2_2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense2_2.Value
                PhotoLicense2_2.Visible = True
                btnUploadLicense2_2.Visible = False
                FileUploadLicense2_2.Visible = False
                PhotoDeleteLicense2_2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver1');", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver2');", True)
            End If
        End If
    End Sub

    '''อัพโหลด และ ลบ รูป ใบอนุญาตขับรถ คนที่3 _2
    Protected Sub PhotoDeleteLicense3_2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteLicense3_2.Command
        If File.Exists(fPathLicense & hidPhotoNameLicense3_2.Value) Then
            File.Delete(fPathLicense & hidPhotoNameLicense3_2.Value)
        End If
        btnUploadLicense3_2.Visible = True
        FileUploadLicense3_2.Visible = True
        hidPhotoNameLicense3_2.Value = ""
        PhotoLicense3_2.Visible = False
        PhotoDeleteLicense3_2.Visible = False
    End Sub

    Protected Sub btnUploadLicense3_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadLicense3_2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadLicense3_2.PostedFile.FileName <> "" Then
            If FileUploadLicense3_2.HasFile Then
                srcName = Path.GetFileName(FileUploadLicense3_2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadLicense3_2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUploadLicense3_2.PostedFile.SaveAs(Server.MapPath("~/Upload/LicenseDriver/") + srcName & srcExt)
                hidPhotoNameLicense3_2.Value = srcName & srcExt
                PhotoLicense3_2.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense3_2.Value
                PhotoLicense3_2.Visible = True
                btnUploadLicense3_2.Visible = False
                FileUploadLicense3_2.Visible = False
                PhotoDeleteLicense3_2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2(); setFocusPage('divReserveDriver2');", True)
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

    ''อัพโหลด และ ลบ รูปลงทะเบียนรถ _2
    Protected Sub PhotoDeleteRegisCar_2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteRegisCar_2.Command
        If File.Exists(fPathRegiscar & hidPhotoRegisCar_2.Value) Then
            File.Delete(fPathRegiscar & hidPhotoRegisCar_2.Value)
        End If
        btnUploadRegisCar_2.Visible = True
        FileUpload4_2.Visible = True
        hidPhotoRegisCar_2.Value = ""
        PhotoRegisCar_2.Visible = False
        PhotoDeleteRegisCar_2.Visible = False
    End Sub

    Protected Sub btnUploadRegisCar_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadRegisCar_2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload4_2.PostedFile.FileName <> "" Then
            If FileUpload4_2.HasFile Then
                srcName = Path.GetFileName(FileUpload4_2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload4_2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload4_2.PostedFile.SaveAs(Server.MapPath("~/Upload/RegisterCar/") + srcName & srcExt)
                hidPhotoRegisCar_2.Value = srcName & srcExt
                PhotoRegisCar_2.ImageUrl = "~/Upload/RegisterCar/" & hidPhotoRegisCar_2.Value
                PhotoRegisCar_2.Visible = True
                btnUploadRegisCar_2.Visible = False
                FileUpload4_2.Visible = False
                PhotoDeleteRegisCar_2.Visible = True
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

    ''อัพโหลด และ ลบ รูป กรมธรรม์ _2
    Protected Sub PhotoDeleteAct_2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteAct_2.Command
        If File.Exists(fPathAct & hidPhotoAct_2.Value) Then
            File.Delete(fPathAct & hidPhotoAct_2.Value)
        End If
        btnUploadAct_2.Visible = True
        FileUpload5_2.Visible = True
        hidPhotoAct_2.Value = ""
        PhotoAct_2.Visible = False
        PhotoDeleteAct_2.Visible = False
    End Sub

    Protected Sub btnUploadAct_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadAct_2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload5_2.PostedFile.FileName <> "" Then
            If FileUpload5_2.HasFile Then
                srcName = Path.GetFileName(FileUpload5_2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload5_2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload5_2.PostedFile.SaveAs(Server.MapPath("~/Upload/Act/") + srcName & srcExt)
                hidPhotoAct_2.Value = srcName & srcExt
                PhotoAct_2.ImageUrl = "~/Upload/Act/" & hidPhotoAct_2.Value
                PhotoAct_2.Visible = True
                btnUploadAct_2.Visible = False
                FileUpload5_2.Visible = False
                PhotoDeleteAct_2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script6", "tab4();", True)
            End If
        End If
    End Sub

    ''อัพโหลด และ ลบ รูป กรมธรรม์ 2 เพิ่มมาใหม่
    Protected Sub PhotoDeleteAct2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteAct2.Command
        If File.Exists(fPathAct & hidPhotoAct2.Value) Then
            File.Delete(fPathAct & hidPhotoAct2.Value)
        End If
        btnUploadAct2.Visible = True
        FileUpload52.Visible = True
        hidPhotoAct2.Value = ""
        PhotoAct2.Visible = False
        PhotoDeleteAct2.Visible = False
    End Sub

    Protected Sub btnUploadAct2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadAct2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload52.PostedFile.FileName <> "" Then
            If FileUpload52.HasFile Then
                srcName = Path.GetFileName(FileUpload52.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload52.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload52.PostedFile.SaveAs(Server.MapPath("~/Upload/Act/") + srcName & srcExt)
                hidPhotoAct2.Value = srcName & srcExt
                PhotoAct2.ImageUrl = "~/Upload/Act/" & hidPhotoAct2.Value
                PhotoAct2.Visible = True
                btnUploadAct2.Visible = False
                FileUpload52.Visible = False
                PhotoDeleteAct2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script6", "tab4(); setFocusPage('divThird-party');", True)
            End If
        End If
    End Sub

    ''อัพโหลด และ ลบ รูป กรมธรรม์ 2 เพิ่มมาใหม่ _2
    Protected Sub PhotoDeleteAct2_2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteAct2_2.Command
        If File.Exists(fPathAct & hidPhotoAct2_2.Value) Then
            File.Delete(fPathAct & hidPhotoAct2_2.Value)
        End If
        btnUploadAct2_2.Visible = True
        FileUpload52_2.Visible = True
        hidPhotoAct2_2.Value = ""
        PhotoAct2_2.Visible = False
        PhotoDeleteAct2_2.Visible = False
    End Sub

    Protected Sub btnUploadAct2_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadAct2_2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload52_2.PostedFile.FileName <> "" Then
            If FileUpload52_2.HasFile Then
                srcName = Path.GetFileName(FileUpload52_2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload52_2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload52_2.PostedFile.SaveAs(Server.MapPath("~/Upload/Act/") + srcName & srcExt)
                hidPhotoAct2_2.Value = srcName & srcExt
                PhotoAct2_2.ImageUrl = "~/Upload/Act/" & hidPhotoAct2_2.Value
                PhotoAct2_2.Visible = True
                btnUploadAct2_2.Visible = False
                FileUpload52_2.Visible = False
                PhotoDeleteAct2_2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script6", "tab4(); setFocusPage('divThird-party');", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script10", "tab3(); setFocusPage('divCarAuthorize');", True)
            End If
        End If
    End Sub

    ''อัพโหลด และ ลบ รูป หนังสือยินยอมให้ใช้รถ _2
    Protected Sub PhotoDeleteAuthorize_2_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteAuthorize_2.Command
        If File.Exists(fPathAuthorize & hidAuthorize_2.Value) Then
            File.Delete(fPathAuthorize & hidAuthorize_2.Value)
        End If
        btnUploadAuthorize_2.Visible = True
        FileUpload6_2.Visible = True
        hidAuthorize_2.Value = ""
        PhotoAuthorize_2.Visible = False
        PhotoDeleteAuthorize_2.Visible = False
    End Sub

    Protected Sub btnUploadAuthorize_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadAuthorize_2.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload6_2.PostedFile.FileName <> "" Then
            If FileUpload6_2.HasFile Then
                srcName = Path.GetFileName(FileUpload6_2.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload6_2.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload6_2.PostedFile.SaveAs(Server.MapPath("~/Upload/Authorize/") + srcName & srcExt)
                hidAuthorize_2.Value = srcName & srcExt
                PhotoAuthorize_2.ImageUrl = "~/Upload/Authorize/" & hidAuthorize_2.Value
                PhotoAuthorize_2.Visible = True
                btnUploadAuthorize_2.Visible = False
                FileUpload6_2.Visible = False
                PhotoDeleteAuthorize_2.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script10", "tab3(); setFocusPage('divCarAuthorize');", True)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script7", "tab3(); setFocusPage('divCar');", True)

            End If
        End If
    End Sub

    ' ใบ แปลภาษา รถ
    Protected Sub btnUploadCarCer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadCar_cer.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload_cer.PostedFile.FileName <> "" Then
            If FileUpload_cer.HasFile Then
                srcName = Path.GetFileName(FileUpload_cer.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload_cer.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                If supportedFilePDF.Contains("," & srcExt.ToLower.Trim & ",") Then
                    FileUpload_cer.PostedFile.SaveAs(Server.MapPath("~/Upload/RegisterCar/") + srcName & srcExt)
                    hidPhotonamecar_cer.Value = srcName & srcExt
                    'PhotoCar_cer.ImageUrl = "~/Upload/RegisterCar/" & hidPhotonamecar_cer.Value
                    'PhotoCar_cer.Visible = False
                    Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FileRegisterCar") & "/")
                    Dim tempFile = New System.IO.FileInfo(fpathstr & hidPhotonamecar_cer.Value)
                    linkCar_cer.NavigateUrl = "../Admin/ViewFile.aspx?sname=" & hidPhotonamecar_cer.Value & "&fname=" & Server.UrlPathEncode(hidPhotonamecar_cer.Value) & "&fPath=FileRegisterCar"
                    linkCar_cer.Target = "_blank"
                    linkCar_cer.Visible = True
                    btnUploadCar_cer.Visible = True
                    FileUpload_cer.Visible = False
                    PhotoCar_cerDelete.Visible = True

                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script7", "tab3(); setFocusPage('divCertified');", True)
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script7", "tab3(); setFocusPage('divCertified'); alert('Please attach a pdf file');", True)
                End If
            End If
        End If
    End Sub

    Protected Sub PhotoCar_cerDelete_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoCar_cerDelete.Command
        If File.Exists(fPathRegiscar & hidPhotonamecar_cer.Value) Then
            File.Delete(fPathRegiscar & hidPhotonamecar_cer.Value)
        End If
        btnUploadCar_cer.Visible = True
        FileUpload_cer.Visible = True
        hidPhotonamecar_cer.Value = ""
        linkCar_cer.Visible = False
        PhotoCar_cerDelete.Visible = False
    End Sub

    ' ใบตรวจสอบสภาพรถ
    Protected Sub btnUploadCarinspec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadCar_inspec.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload_inspec.PostedFile.FileName <> "" Then
            If FileUpload_inspec.HasFile Then
                srcName = Path.GetFileName(FileUpload_inspec.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload_inspec.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUpload_inspec.PostedFile.SaveAs(Server.MapPath("~/Upload/RegisterCar/") + srcName & srcExt)
                hidPhotonamecar_inspec.Value = srcName & srcExt
                PhotoCar_inspec.ImageUrl = "~/Upload/RegisterCar/" & hidPhotonamecar_inspec.Value
                PhotoCar_inspec.Visible = False
                btnUploadCar_inspec.Visible = True
                FileUpload_inspec.Visible = True
                'PhotoCarDelete.Visible = True
                Try
                    Dim nrow As DataRow = tbImageInspec.NewRow
                    nrow.Item("gid") = tbImageInspec.Rows.Count + 1
                    nrow.Item("car_id") = hidcar_id.Value
                    nrow.Item("file_name") = hidPhotonamecar_inspec.Value
                    nrow.Item("PathImg") = PhotoCar_inspec.ImageUrl
                    tbImageInspec.Rows.Add(nrow)
                    nrow = Nothing
                    gvFile_inspec.DataSource = tbImageInspec
                    gvFile_inspec.DataBind()

                    DtlImg_inspec.DataSource = tbImageInspec
                    DtlImg_inspec.DataBind()
                    UpdgvFile_inspec.Update()

                Catch ex As Exception
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
                End Try
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script7", "tab3(); setFocusPage('divCertified');", True)

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

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script8", "tab3(); ", True)
    End Sub

    Protected Sub PhotoCarDelete_cer_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) 'Handles PhotoCarDelete.Command


        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script8", "tab3();", True)
    End Sub

    Protected Sub PhotoCarDelete_inspec_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try
            Dim FileID As Integer = e.CommandArgument
            Dim nrow As DataRow = tbImageInspec.Select("gid=" & FileID)(0)
            If File.Exists(fPathRegiscar & nrow("file_name")) Then
                File.Delete(fPathRegiscar & nrow("file_name"))
            End If
            tbImageInspec.Select("gid=" & FileID)(0).Delete()
            gvFile_inspec.DataSource = tbImageInspec
            gvFile_inspec.DataBind()
            DtlImg_inspec.DataSource = tbImageInspec
            DtlImg_inspec.DataBind()
            UpdgvFile_inspec.Update()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
        End Try

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script8", "tab3();", True)
    End Sub
    Protected Sub ddladmin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddladmin.SelectedIndexChanged
        'Page_Load(sender, e)
    End Sub



    Protected Sub btnNext2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext2.Click
        If chkisJuristic.Checked = False And (txtOwnerName.Text = "" Or txtOwnerLastName.Text = "" Or txtOwnerIdcard.Text = "" Or txtLicenseEmail.Text = "") Then
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
        ElseIf chkisJuristic.Checked = True And (txtJuristicName.Text = "" Or txtJuristicID.Text = "" Or txtLicenseEmail.Text = "") Then
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
        Else
            If hidcar_id.Value <> "" Then
                Dim dbConnect As New DBConnect
                Dim cmd As New NpgsqlCommand
                Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
                Dim tbCommand As DataTable = dbConnect.TableCommand
                Try
                    con.Open()
                    cmd.Connection = con
                    Dim strUpdate = "Update car set owner_prename=:owner_prename ,owner_name=:owner_name , owner_lastname=:owner_lastname,  owner_idcard=:owner_idcard , owner_address=:owner_address , owner_tel=:owner_tel " &
                                         "  , owner_province =:owner_province , owner_zipcode =:owner_zipcode , owner_country =:owner_country, is_juristic = :is_juristic  WHERE car_id = " & hidcar_id.Value
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strUpdate
                    cmd.Parameters.Clear()
                    If chkisJuristic.Checked = False Then

                        If ddlOwnerPrename.SelectedValue = "Other" Then
                            cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerPrename.Text
                        Else
                            cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlOwnerPrename.SelectedValue
                        End If
                        cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerName.Text.Trim = "", Nothing, txtOwnerName.Text)
                        cmd.Parameters.Add("owner_lastname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerLastName.Text = "", Nothing, txtOwnerLastName.Text)
                        cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerIdcard.Text.Trim = "", Nothing, txtOwnerIdcard.Text)
                    Else

                        cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                        cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtJuristicName.Text.Trim = "", Nothing, txtJuristicName.Text)
                        cmd.Parameters.Add("owner_lastname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                        cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtJuristicID.Text.Trim = "", Nothing, txtJuristicID.Text)
                    End If

                    cmd.Parameters.Add("owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerAddress.Text.Trim = "", Nothing, txtOwnerAddress.Text)
                    'cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnertel.Text.Trim = "", Nothing, txtOwnertel.Text)
                    cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = If(String.IsNullOrWhiteSpace(txtOwnertel.Text), DBNull.Value, txtOwnertel.Text.Trim())
                    cmd.Parameters.Add("owner_province", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerProvince.Text = "", Nothing, txtOwnerProvince.Text)
                    cmd.Parameters.Add("owner_zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerZipcode.Text = "", Nothing, txtOwnerZipcode.Text)
                    cmd.Parameters.Add("owner_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlOwnerCountry.SelectedValue
                    cmd.Parameters.Add("is_juristic", NpgsqlTypes.NpgsqlDbType.Integer).Value = IIf(chkisJuristic.Checked = False, 0, 1)




                    cmd.ExecuteNonQuery()

                    tbCommand.Rows.Clear()
                    tbCommand.Rows.Add("fname", NpgsqlTypes.NpgsqlDbType.Varchar, txtOwnerName.Text)
                    tbCommand.Rows.Add("lname", NpgsqlTypes.NpgsqlDbType.Varchar, txtOwnerLastName.Text)
                    tbCommand.Rows.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar, txtLicenseEmail.Text)
                    Dim check = dbConnect.UpdateDataTable(tbCommand, "license", " WHERE license_id = " & hidlicense_id.Value)

                    If check = "" Then

                    Else
                        'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
                    End If



                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
                Finally
                    cmd.Connection.Close()
                    con.Close()
                End Try

                'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
                'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptAlert", "alertDataDriver();", True)
            Else
                Dim dbConnect As New DBConnect
                Dim cmd As New NpgsqlCommand
                Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
                Try
                    con.Open()
                    cmd.Connection = con
                    Dim strCar = " INSERT INTO car( owner_prename, owner_name,  owner_idcard, owner_address, owner_tel , owner_lastname , owner_province , owner_zipcode , owner_country, is_juristic) values( @owner_prename, @owner_name,  @owner_idcard, @owner_address, @owner_tel , @owner_lastname , @owner_province , @owner_zipcode , @owner_country, @is_juristic) RETURNING car_id;"
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strCar
                    cmd.Parameters.Clear()
                    If chkisJuristic.Checked = False Then

                        If ddlOwnerPrename.SelectedValue = "Other" Then
                            cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerPrename.Text
                        Else
                            cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlOwnerPrename.SelectedValue
                        End If
                        cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerName.Text.Trim = "", Nothing, txtOwnerName.Text)
                        cmd.Parameters.Add("owner_lastname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerLastName.Text = "", Nothing, txtOwnerLastName.Text)
                        cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerIdcard.Text.Trim = "", Nothing, txtOwnerIdcard.Text)
                    Else

                        cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                        cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtJuristicName.Text.Trim = "", Nothing, txtJuristicName.Text)
                        cmd.Parameters.Add("owner_lastname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                        cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtJuristicID.Text.Trim = "", Nothing, txtJuristicID.Text)
                    End If

                    cmd.Parameters.Add("owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerAddress.Text.Trim = "", Nothing, txtOwnerAddress.Text)
                    'cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnertel.Text.Trim = "", Nothing, txtOwnertel.Text)
                    cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = If(String.IsNullOrWhiteSpace(txtOwnertel.Text), DBNull.Value, txtOwnertel.Text.Trim())
                    cmd.Parameters.Add("owner_province", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerProvince.Text = "", Nothing, txtOwnerProvince.Text)
                    cmd.Parameters.Add("owner_zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerZipcode.Text = "", Nothing, txtOwnerZipcode.Text)
                    cmd.Parameters.Add("owner_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlOwnerCountry.SelectedValue

                    cmd.Parameters.Add("is_juristic", NpgsqlTypes.NpgsqlDbType.Integer).Value = IIf(chkisJuristic.Checked = False, 0, 1)
                    Dim car_id As Object = cmd.ExecuteScalar()
                    hidcar_id.Value = car_id.ToString()

                    Dim strDriver As String = " Insert Into driver (driver_id ) VALUES (DEFAULT) RETURNING driver_id ;"
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strDriver
                    cmd.Parameters.Clear()
                    Dim driver_id As Object = cmd.ExecuteScalar()
                    hiddriver_id.Value = driver_id.ToString()


                    Dim strAct As String = "Insert Into act ( act_id ) VALUES (DEFAULT) RETURNING act_id ;"
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strAct
                    cmd.Parameters.Clear()
                    Dim act_id As Object = cmd.ExecuteScalar()
                    hidact_id.Value = act_id.ToString()


                    Dim strInsertlicense As String = "Insert Into license ( driver_id , car_id , act_id , typeuser_id , travel_id , regis_date , fname , lname , email) VALUES ( :driver_id , :car_id , :act_id , 2 , :travel_id , :regis_date , :fname , :lname , :email ) RETURNING license_id ;"
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strInsertlicense
                    cmd.Parameters.Clear()
                    'cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
                    'cmd.Parameters.Add("car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidcar_id.Value
                    'cmd.Parameters.Add("act_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidact_id.Value
                    cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(hiddriver_id.Value)
                    cmd.Parameters.Add("car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(hidcar_id.Value)
                    cmd.Parameters.Add("act_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(hidact_id.Value)

                    cmd.Parameters.Add("travel_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("user_id")
                    cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
                    cmd.Parameters.Add("fname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerName.Text
                    cmd.Parameters.Add("lname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtOwnerLastName.Text
                    cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtLicenseEmail.Text

                    Dim license_id As Object = cmd.ExecuteScalar()
                    hidlicense_id.Value = license_id.ToString()


                    Dim strUpdateToken As String = "Update license Set token=:token WHERE license_id =" & hidlicense_id.Value
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strUpdateToken
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBConnect.Token(hidlicense_id.Value, hidcar_id.Value)
                    cmd.ExecuteNonQuery()




                    'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)

                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
                    'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script1", "tab1();", True)
                Finally
                    cmd.Connection.Close()
                    con.Close()
                End Try
            End If

            If Page2.Enabled = False Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
            Else
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
                If chkisJuristic.Checked = False Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptAlert", "alertDataDriver();", True)
                End If

            End If
        End If




    End Sub
    Protected Sub btnNext3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext3.Click
        If txtAddress.Text = "" Or txtName.Text = "" Or txtSurname.Text = "" Or txtLicenseExpire.Text = "" Then
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
        ElseIf hidPhotoNameLicense.Value = "" Or hidPhotoNamePassport.Value = "" Then
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck2();", True)
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
        ElseIf txtDate.Text = "" Then
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
        ElseIf txtPassportExpire.Text = "" Then
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab2();", True)
        Else

            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
            Dim dread As Npgsql.NpgsqlDataReader
            Try
                Dim driverIdStr As String = hiddriver_id.Value
                Response.Write("driver_id=" & driverIdStr)
                Dim ar_txtDate As String() = txtDate.Text.ToString.Split("/")
                Dim ar_txtLicenseExpire As String() = txtLicenseExpire.Text.ToString.Split("/")
                Dim ar_txtPassportExpire As String() = txtPassportExpire.Text.ToString.Split("/")

                Dim _txtDate As New DateTime '(ar_txtDate(2), ar_txtDate(1), ar_txtDate(0))
                If ar_txtDate.Length = 3 AndAlso IsNumeric(ar_txtDate(0)) AndAlso IsNumeric(ar_txtDate(1)) AndAlso IsNumeric(ar_txtDate(2)) Then
                    _txtDate = New DateTime(Convert.ToInt32(ar_txtDate(2)), Convert.ToInt32(ar_txtDate(1)), Convert.ToInt32(ar_txtDate(0)))
                Else
                    Throw New FormatException("Invalid date format in txtDate.")
                End If

                Dim _txtLicenseExpire As New DateTime '(ar_txtLicenseExpire(2), ar_txtLicenseExpire(1), ar_txtLicenseExpire(0))
                If ar_txtLicenseExpire.Length = 3 AndAlso IsNumeric(ar_txtLicenseExpire(0)) AndAlso IsNumeric(ar_txtLicenseExpire(1)) AndAlso IsNumeric(ar_txtLicenseExpire(2)) Then
                    _txtLicenseExpire = New DateTime(Convert.ToInt32(ar_txtLicenseExpire(2)), Convert.ToInt32(ar_txtLicenseExpire(1)), Convert.ToInt32(ar_txtLicenseExpire(0)))
                Else
                    Throw New FormatException("Invalid date format in txtDate.")
                End If

                Dim _txtPassportExpire As New DateTime '(ar_txtPassportExpire(2), ar_txtPassportExpire(1), ar_txtPassportExpire(0))
                If ar_txtPassportExpire.Length = 3 AndAlso IsNumeric(ar_txtPassportExpire(0)) AndAlso IsNumeric(ar_txtPassportExpire(1)) AndAlso IsNumeric(ar_txtPassportExpire(2)) Then
                    _txtPassportExpire = New DateTime(Convert.ToInt32(ar_txtPassportExpire(2)), Convert.ToInt32(ar_txtPassportExpire(1)), Convert.ToInt32(ar_txtPassportExpire(0)))
                Else
                    Throw New FormatException("Invalid date format in txtDate.")
                End If
                Try
                    _txtDate = New DateTime(ar_txtDate(2), ar_txtDate(1), ar_txtDate(0))
                    _txtLicenseExpire = New DateTime(ar_txtLicenseExpire(2), ar_txtLicenseExpire(1), ar_txtLicenseExpire(0))
                    _txtPassportExpire = New DateTime(ar_txtPassportExpire(2), ar_txtPassportExpire(1), ar_txtPassportExpire(0))
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
                con.Open()
                cmd.Connection = con
                Dim strInsert = "Update driver Set prename=@prename , address=@address , name=@name , surname=@surname , license_expire=@license_expire , national=@national , countries=@countries , gender=@gender " &
                    " , passport_photo=@passport_photo , licensedriver_photo=@licensedriver_photo , passport_photo_2=@passport_photo_2 , licensedriver_photo_2 =@licensedriver_photo_2 " &
                    " , idcard_no=@idcard_no , county=@county , zipcode=@zipcode  " &
                      ", tel=@tel , email = @email, birthday = @birthday, passport_no = @passport_no, passport_expire = @passport_expire , photo_cer = @photo_cer WHERE driver_id = " & hiddriver_id.Value
                Dim driver_id As Integer = 0
                If Not String.IsNullOrWhiteSpace(hiddriver_id.Value) AndAlso IsNumeric(hiddriver_id.Value) Then
                    driver_id = Convert.ToInt32(hiddriver_id.Value)
                Else
                    ' สามารถเลือกจะ throw error, แจ้งเตือน หรือใช้ค่า default เป็น 0 ก็ได้
                    Console.WriteLine("hiddriver_id มีค่าว่างหรือไม่ใช่ตัวเลข")
                End If

                cmd.Parameters.AddWithValue("@driver_id", driver_id)
                'cmd.Parameters.AddWithValue("@driver_id", Convert.ToInt32(hiddriver_id.Value))
                cmd.CommandText = CommandType.Text
                cmd.CommandText = strInsert
                cmd.Parameters.Clear()
                If ddlPrename.SelectedValue = "Other" Then
                    cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtPrename.Text
                Else
                    cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlPrename.SelectedValue
                End If


                cmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtName.Text.Trim = "", Nothing, txtName.Text)
                cmd.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtSurname.Text.Trim = "", Nothing, txtSurname.Text)
                cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtAddress.Text.Trim = "", Nothing, txtAddress.Text)
                cmd.Parameters.Add("license_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtLicenseExpire.Text.Trim = "", Nothing, _txtLicenseExpire) 'IIf(txtLicenseExpire.Text.Trim = "", Nothing, Format(CDate(txtLicenseExpire.Text), "MM/dd/yyyy"))
                cmd.Parameters.Add("national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlNational.SelectedValue
                cmd.Parameters.Add("countries", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountry.SelectedValue
                cmd.Parameters.Add("gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlGender.SelectedValue
                cmd.Parameters.Add("passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport.Value
                cmd.Parameters.Add("licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense.Value
                cmd.Parameters.Add("passport_photo_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport_2.Value
                cmd.Parameters.Add("licensedriver_photo_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense_2.Value
                cmd.Parameters.Add("idcard_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicenseDriver.Text.Trim = "", Nothing, txtLicenseDriver.Text)
                'cmd.Parameters.Add("state", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtState.Text.Trim = "", Nothing, txtState.Text)
                cmd.Parameters.Add("county", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtCounty.Text.Trim = "", Nothing, txtCounty.Text)
                cmd.Parameters.Add("zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtZipcode.Text.Trim = "", Nothing, txtZipcode.Text)
                cmd.Parameters.Add("tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtTel.Text.Trim = "", Nothing, txtTel.Text)
                cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtEmail.Text.Trim = "", Nothing, txtEmail.Text)
                cmd.Parameters.Add("birthday", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtDate.Text.Trim = "", Nothing, _txtDate) 'IIf(txtDate.Text.Trim = "", Nothing, Format(CDate(txtDate.Text), "MM/dd/yyyy"))
                cmd.Parameters.Add("passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtPassportNo.Text
                cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtPassportExpire.Text.Trim = "", Nothing, _txtPassportExpire) 'IIf(txtPassportExpire.Text.Trim = "", Nothing, Format(CDate(txtPassportExpire.Text), "MM/dd/yyyy"))
                cmd.Parameters.Add("photo_cer", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoCer.Value
                cmd.ExecuteNonQuery()

                ' คนขับสำรองคนที่ 1 
                If txtName2.Text <> "" And txtSurname2.Text <> "" Then
                    Dim ar_txtLicenseExpire2 As String() = txtLicenseExpire2.Text.ToString.Split("/")
                    Dim ar_txtPassport_exp2 As String() = txtPassport_exp2.Text.ToString.Split("/")

                    Dim _txtLicenseExpire2 As New DateTime(ar_txtLicenseExpire2(2), ar_txtLicenseExpire2(1), ar_txtLicenseExpire2(0))
                    Dim _txtPassport_exp2 As New DateTime(ar_txtPassport_exp2(2), ar_txtPassport_exp2(1), ar_txtPassport_exp2(0))

                    Dim strCheckDriver As String = "SELECT sparedriver_id from spare_driver WHERE driver_id = " & hiddriver_id.Value & " and spare_ord = 1"
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strCheckDriver
                    cmd.Parameters.Clear()
                    dread = cmd.ExecuteReader()
                    If dread.Read Then
                        Dim sparedriver_id = dread("sparedriver_id")
                        dread.Close()
                        cmd.CommandText = "Update spare_driver set  driver_id = @driver_id , prename = @prename , name = @name , surname = @surname , license_no = @license_no , national = @national ,  " &
                                             " address = @address , country = @country , zipcode = @zipcode , tel = @tel , email = @email , gender = @gender , license_exp_date = @license_exp_date , passport_no = @passport_no , passport_expire = @passport_expire " &
                                             " , licensedriver_photo=@licensedriver_photo , passport_photo =@passport_photo , licensedriver_photo_2=@licensedriver_photo_2 , passport_photo_2 =@passport_photo_2 " &
                                             " , photo_cer =@photo_cer WHERE sparedriver_id = " & dread("sparedriver_id") & " and spare_ord = 1"
                        cmd.Parameters.AddWithValue("@sparedriver_id", dread("sparedriver_id"))
                    Else
                        dread.Close()
                        cmd.CommandText = "Insert Into spare_driver ( prename , name , surname , license_no , national , driver_id  , address  , country , zipcode , tel , email , gender , license_exp_date , passport_no , passport_expire " &
                                            " , licensedriver_photo , passport_photo , licensedriver_photo_2 , passport_photo_2 , spare_ord , photo_cer ) " &
                                             " VALUES (@prename , @name , @surname , @license_no , @national , @driver_id  , @address , @country , @zipcode , @tel , @email , @gender , @license_exp_date , @passport_no , @passport_expire " &
                                             ", @licensedriver_photo, @passport_photo , @licensedriver_photo_2 , @passport_photo_2 , 1 , @photo_cer ) "
                    End If
                    dread.Close()
                    If ddlPrename2.SelectedValue = "Other" Then
                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtPrename2.Text.Trim = "", Nothing, txtPrename2.Text)
                    Else
                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlPrename2.SelectedValue
                    End If
                    cmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtName2.Text.Trim = "", Nothing, txtName2.Text.Trim)
                    cmd.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtSurname2.Text.Trim = "", Nothing, txtSurname2.Text.Trim)
                    cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicense2.Text.Trim = "", Nothing, txtLicense2.Text.Trim)
                    cmd.Parameters.Add("national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlNational2.SelectedValue
                    'cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
                    If IsNumeric(hiddriver_id.Value) Then
                        cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = CInt(hiddriver_id.Value)
                    Else
                        cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = DBNull.Value
                    End If

                    cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtAddress2.Text.Trim = "", Nothing, txtAddress2.Text.Trim)
                    cmd.Parameters.Add("country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountry2.SelectedValue
                    cmd.Parameters.Add("zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtZipcode2.Text.Trim = "", Nothing, txtZipcode2.Text.Trim)
                    cmd.Parameters.Add("tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtTel2.Text.Trim = "", Nothing, txtTel2.Text.Trim)
                    cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtEmail2.Text.Trim = "", Nothing, txtEmail2.Text.Trim)
                    cmd.Parameters.Add("gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlGender2.SelectedValue


                    cmd.Parameters.Add("license_exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtLicenseExpire2.Text.Trim = "", Nothing, _txtLicenseExpire2) 'IIf(txtLicenseExpire2.Text.Trim = "", Nothing, Format(CDate(txtLicenseExpire2.Text.Trim), "MM/dd/yyyy"))
                    cmd.Parameters.Add("passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtPassportNo2.Text.Trim = "", Nothing, txtPassportNo2.Text.Trim)
                    cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtPassport_exp2.Text.Trim = "", Nothing, _txtPassport_exp2) 'IIf(txtPassport_exp2.Text.Trim = "", Nothing, Format(CDate(txtPassport_exp2.Text.Trim), "MM/dd/yyyy"))


                    'cmd.Parameters.Add(":state", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtState2.Text.Trim = "", Nothing, txtState2.Text.Trim)
                    'cmd.Parameters.Add(":gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlGender2.SelectedValue


                    cmd.Parameters.Add("licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense2.Value
                    cmd.Parameters.Add("passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport2.Value
                    cmd.Parameters.Add("licensedriver_photo_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense2_2.Value
                    cmd.Parameters.Add("passport_photo_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport2_2.Value
                    cmd.Parameters.Add("photo_cer", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoCer2.Value
                    cmd.ExecuteNonQuery()
                End If

                ' คนขับสำรองคนที่ 2
                If txtName3.Text <> "" And txtSurname3.Text <> "" Then

                    Dim ar_txtLicenseExpire3 As String() = txtLicenseExpire3.Text.ToString.Split("/")
                    Dim ar_txtPassport_exp3 As String() = txtPassport_exp2.Text.ToString.Split("/")

                    Dim _txtLicenseExpire3 As New DateTime(ar_txtLicenseExpire3(2), ar_txtLicenseExpire3(1), ar_txtLicenseExpire3(0))
                    Dim _txtPassport_exp3 As New DateTime(ar_txtPassport_exp3(2), ar_txtPassport_exp3(1), ar_txtPassport_exp3(0))

                    Dim strCheckDriver As String = "SELECT sparedriver_id from spare_driver WHERE driver_id = " & hiddriver_id.Value & " and spare_ord = 2"
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strCheckDriver
                    cmd.Parameters.Clear()
                    dread = cmd.ExecuteReader()
                    If dread.Read Then
                        Dim sparedriver_id = dread("sparedriver_id")
                        dread.Close()
                        cmd.CommandText = "Update spare_driver set  driver_id = :driver_id , prename = :prename , name = :name , surname = :surname , license_no = :license_no , national = :national ,  " &
                                             " address = :address , country = :country , zipcode = :zipcode , tel = :tel , email = :email , gender = :gender , license_exp_date = :license_exp_date , passport_no = :passport_no , passport_expire = :passport_expire " &
                                             " , licensedriver_photo=:licensedriver_photo , passport_photo =:passport_photo , licensedriver_photo_2 =:licensedriver_photo_2 , passport_photo_2 =:passport_photo_2 " &
                                             " , photo_cer=:photo_cer WHERE sparedriver_id = " & dread("sparedriver_id") & " and spare_ord = 2"
                    Else
                        dread.Close()
                        cmd.CommandText = "Insert Into spare_driver ( prename , name , surname , license_no , national , driver_id  , address , country , zipcode , tel , email , gender , license_exp_date , passport_no , passport_expire " &
                                            " , licensedriver_photo , passport_photo , licensedriver_photo_2 , passport_photo_2 , spare_ord , photo_cer ) " &
                                                         " VALUES (:prename , :name , :surname , :license_no , :national , :driver_id  , :address , :country , :zipcode , :tel , :email , :gender , :license_exp_date , :passport_no , :passport_expire " &
                                            " , :licensedriver_photo, :passport_photo , :licensedriver_photo_2, :passport_photo_2 , 2 , :photo_cer) "
                    End If
                    dread.Close()
                    If ddlPrename3.SelectedValue = "Other" Then
                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtPrename3.Text.Trim = "", Nothing, txtPrename3.Text)
                    Else
                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlPrename3.SelectedValue
                    End If
                    cmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtName3.Text.Trim = "", Nothing, txtName3.Text.Trim)
                    cmd.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtSurname3.Text.Trim = "", Nothing, txtSurname3.Text.Trim)
                    cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicense3.Text.Trim = "", Nothing, txtLicense3.Text.Trim)
                    cmd.Parameters.Add("national", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlNational3.SelectedValue
                    'cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hiddriver_id.Value
                    If IsNumeric(hiddriver_id.Value) Then
                        cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = CInt(hiddriver_id.Value)
                    Else
                        cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = DBNull.Value
                    End If
                    cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtAddress3.Text.Trim = "", Nothing, txtAddress3.Text.Trim)
                    'cmd.Parameters.Add(":gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlGender3.SelectedValue

                    'cmd.Parameters.Add(":state", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtState3.Text.Trim = "", Nothing, txtState3.Text.Trim)
                    cmd.Parameters.Add("country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlCountry3.SelectedValue
                    cmd.Parameters.Add("zipcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtZipcode3.Text.Trim = "", Nothing, txtZipcode3.Text.Trim)
                    cmd.Parameters.Add("tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtTel3.Text.Trim = "", Nothing, txtTel3.Text.Trim)
                    cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtEmail3.Text.Trim = "", Nothing, txtEmail3.Text.Trim)
                    cmd.Parameters.Add("gender", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlGender3.SelectedValue
                    cmd.Parameters.Add("license_exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtLicenseExpire3.Text.Trim = "", Nothing, _txtLicenseExpire3) 'IIf(txtLicenseExpire3.Text.Trim = "", Nothing, Format(CDate(txtLicenseExpire3.Text.Trim), "MM/dd/yyyy"))
                    cmd.Parameters.Add("passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtPassportNo3.Text.Trim = "", Nothing, txtPassportNo3.Text.Trim)
                    cmd.Parameters.Add("passport_expire", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtPassport_exp3.Text.Trim = "", Nothing, _txtPassport_exp3) 'IIf(txtPassport_exp3.Text.Trim = "", Nothing, Format(CDate(txtPassport_exp3.Text.Trim), "MM/dd/yyyy"))


                    cmd.Parameters.Add("licensedriver_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense3.Value
                    cmd.Parameters.Add("passport_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport3.Value
                    cmd.Parameters.Add("licensedriver_photo_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense3_2.Value
                    cmd.Parameters.Add("passport_photo_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNamePassport3_2.Value
                    cmd.Parameters.Add("photo_cer", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoCer3.Value
                    cmd.ExecuteNonQuery()
                End If

                If Request.QueryString("is_renew") IsNot Nothing Then
                    Dim Gid As Integer = dbConnect.executeScalar("select group_id from travel_group_car where license_id = " & hidlicense_id.Value)
                    Response.Redirect("GroupAdd.aspx?id=" & Gid & "&tab=2")
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab3();", True)
                End If


            Catch ex As Exception
                Console.WriteLine(ex.Message)

                'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
                'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2();", True)
            Finally
                dbConnect = Nothing
                cmd.Connection.Close()
                con.Close()
            End Try

        End If
    End Sub
    Protected Sub btnNext4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext4.Click
        If txtBrands.Text = "" Or txtLicenseCar.Text = "" Or hidPhotoRegisCar.Value = "" Then
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script3", "tab3();", True)
        Else

            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Dim dread As Npgsql.NpgsqlDataReader
            Try
                con.Open()
                cmd.Connection = con
                'Dim strUpdate = "Update car set brands =:brands  , model=:model   , colors =:colors , seat=:seat , weight=:weight , car_no=:car_no , country_car=:country_car , typecar_id = :typecar_id , " & _
                '                     " province_car=:province_car , plate=:plate , engine_no=:engine_no , engine_cap=:engine_cap , owner_name=:owner_name , owner_idcard=:owner_idcard , owner_address=:owner_address , owner_tel=:owner_tel " & _
                '                     " , authorize_car=:authorize_car , authorize_car_2=:authorize_car_2 " & _
                '                     " , regis_photo=:regis_photo , regis_photo_2 = :regis_photo_2 , platelocal=:platelocal  WHERE car_id = " & hidcar_id.Value

                Dim strUpdate = "Update car set brands =:brands  , model=:model   , colors =:colors , seat=:seat , weight=:weight , car_no=:car_no , country_car=:country_car , typecar_id = :typecar_id , " &
                                    " province_car=:province_car , plate=:plate , engine_no=:engine_no , engine_cap=:engine_cap  " &
                                    " , authorize_car=:authorize_car , authorize_car_2=:authorize_car_2 " &
                                    " , regis_photo=:regis_photo , regis_photo_2 = :regis_photo_2 , platelocal=:platelocal  WHERE car_id = " & hidcar_id.Value
                Dim strCheckPic = "Select gid from car_pic WHERE car_id = " & hidcar_id.Value

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
                cmd.Parameters.Add("seat", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtSeats.Text.Trim = "", Nothing, txtSeats.Text) 'ddlSeats.SelectedValue
                cmd.Parameters.Add("weight", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtWeight.Text.Trim = "", Nothing, txtWeight.Text)
                cmd.Parameters.Add("car_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtNumcar.Text.Trim = "", Nothing, txtNumcar.Text)
                cmd.Parameters.Add("country_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(ddlCountryCar.SelectedItem.Value = "", Nothing, ddlCountryCar.SelectedItem.Value)
                'cmd.Parameters.Add("typecar_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = IIf(ddltypecar.SelectedItem.Value = "", Nothing, ddltypecar.SelectedItem.Value)
                If ddltypecar.SelectedItem.Value = "" Then
                    cmd.Parameters.Add("typecar_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = DBNull.Value
                Else
                    cmd.Parameters.Add("typecar_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(ddltypecar.SelectedItem.Value)
                End If
                cmd.Parameters.Add("province_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtstate_car.Text 'ddlProvinceRegis.SelectedItem.Text
                cmd.Parameters.Add("plate", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicenseCar.Text.Trim = "", Nothing, txtLicenseCar.Text)
                cmd.Parameters.Add("engine_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtNumEngine.Text.Trim = "", Nothing, txtNumEngine.Text)
                cmd.Parameters.Add("engine_cap", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtEnginCap.Text.Trim = "", Nothing, txtEnginCap.Text)
                'cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerName.Text.Trim = "", Nothing, txtOwnerName.Text)
                'cmd.Parameters.Add("owner_idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerIdcard.Text.Trim = "", Nothing, txtOwnerIdcard.Text)
                'cmd.Parameters.Add("owner_address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnerAddress.Text.Trim = "", Nothing, txtOwnerAddress.Text)
                'cmd.Parameters.Add("owner_tel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtOwnertel.Text.Trim = "", Nothing, txtOwnertel.Text)
                cmd.Parameters.Add("platelocal", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLicenseLocalCar.Text.Trim = "", Nothing, txtLicenseLocalCar.Text)
                'cmd.Parameters.Add("authorize_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidAuthorize.Value.Trim = "", Nothing, hidAuthorize.Value)
                If String.IsNullOrWhiteSpace(hidAuthorize.Value) Then
                    cmd.Parameters.Add("authorize_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                Else
                    cmd.Parameters.Add("authorize_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidAuthorize.Value
                End If

                'cmd.Parameters.Add("authorize_car_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidAuthorize_2.Value.Trim = "", Nothing, hidAuthorize_2.Value)
                If String.IsNullOrWhiteSpace(hidAuthorize_2.Value) Then
                    cmd.Parameters.Add("authorize_car_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                Else
                    cmd.Parameters.Add("authorize_car_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidAuthorize_2.Value
                End If

                cmd.Parameters.Add("regis_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidPhotoRegisCar.Value.Trim = "", Nothing, hidPhotoRegisCar.Value)
                'cmd.Parameters.Add("regis_photo_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidPhotoRegisCar_2.Value.Trim = "", Nothing, hidPhotoRegisCar_2.Value)
                If String.IsNullOrWhiteSpace(hidPhotoRegisCar_2.Value) Then
                    cmd.Parameters.Add("regis_photo_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                Else
                    cmd.Parameters.Add("regis_photo_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoRegisCar_2.Value
                End If

                'cmd.Parameters.Add("photocar_cer", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoCarCer.Value


                cmd.ExecuteNonQuery()

                Dim cRowf As DataRow
                Dim drRow() As DataRow
                Dim TbImgOld As New DataTable

                cmd.CommandText = CommandType.Text
                cmd.CommandText = strCheckPic
                TbImgOld = dbConnect.getDataTable(strCheckPic, "TbFileOld")

                Dim tablecer As String = "select gid from car_cer WHERE car_id = " & hidcar_id.Value

                Dim tableInspec As String = "select gid from car_inspec WHERE car_id = " & hidcar_id.Value

                Dim TbImgcer = dbConnect.getDataTable(tablecer, "TbCerOld")
                Dim TbImgInspec = dbConnect.getDataTable(tableInspec, "TbInspecOld")
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

                    'cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidcar_id.Value
                    If IsNumeric(hidcar_id.Value) Then
                        cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(hidcar_id.Value)
                    Else
                        cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = DBNull.Value
                    End If

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



                ''เปลี่ยนจากรูปเป็นไฟล์
                cmd.Parameters.Clear()
                cmd.CommandText = "delete from car_cer where car_id = " & hidcar_id.Value
                cmd.ExecuteScalar()
                cmd.Parameters.Clear()
                cmd.CommandText = "Insert Into car_cer ( car_id , file_name ) VALUES (:car_id , :file_name ) "
                'cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidcar_id.Value
                If IsNumeric(hidcar_id.Value) Then
                    cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(hidcar_id.Value)
                Else
                    cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = DBNull.Value
                End If
                cmd.Parameters.Add(":file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotonamecar_cer.Value
                cmd.ExecuteNonQuery()


                '------------อัพโหลดรูปใบรับรองตวจสภาพ-------------

                For introw = 0 To tbImageInspec.Rows.Count - 1
                    cRowf = tbImageInspec.Rows(introw)
                    drRow = TbImgInspec.Select("gid = " & cRowf("gid"))

                    If drRow.Length > 0 Then
                        cmd.CommandText = "Update car_inspec set car_id = :car_id , file_name = :file_name WHERE gid = " & cRowf("gid")
                        TbImgInspec.Rows.Remove(drRow(0))
                    Else
                        cmd.CommandText = "Insert Into car_inspec ( car_id , file_name ) VALUES (:car_id , :file_name ) "

                    End If

                    'cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = hidcar_id.Value
                    If IsNumeric(hidcar_id.Value) Then
                        cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(hidcar_id.Value)
                    Else
                        cmd.Parameters.Add(":car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = DBNull.Value
                    End If
                    cmd.Parameters.Add(":file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("file_name")
                    cmd.ExecuteNonQuery()
                Next

                '----------ลบรูป---------------

                For Each cRow In TbImgInspec.Rows
                    cmd.Parameters.Clear()
                    cmd.CommandText = "delete from car_inspec where gid =" & cRow("gid")
                    cmd.ExecuteScalar()
                Next


                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab4();", True)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
            Finally
                cmd.Connection.Close()
                con.Close()
            End Try


            'loadProvice()

        End If
    End Sub

    Protected Sub btnNext5_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles btnNext5.Click


        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Try

            Dim ar_txtActStart As String() = txtActStart.Text.ToString.Split("/")
            Dim ar_txtActExpire As String() = txtActExpire.Text.ToString.Split("/")

            Dim _txtActStart As New DateTime(ar_txtActStart(2), ar_txtActStart(1), ar_txtActStart(0))
            Dim _txtActExpire As New DateTime(ar_txtActExpire(2), ar_txtActExpire(1), ar_txtActExpire(0))

            Dim ar_txtActStart2 As String() = txtActStart2.Text.ToString.Split("/")
            Dim ar_txtActExpire2 As String() = txtActExpire2.Text.ToString.Split("/")

            Dim _txtActStart2 As New DateTime(ar_txtActStart2(2), ar_txtActStart2(1), ar_txtActStart2(0))
            Dim _txtActExpire2 As New DateTime(ar_txtActExpire2(2), ar_txtActExpire2(1), ar_txtActExpire2(0))
            con.Open()
            cmd.Connection = con
            Dim strUpdate = "Update act set act_no=:act_no , act_company=:act_company , act_start=:act_start , act_ends=:act_ends , act_photo=:act_photo , act_photo_2=:act_photo_2 " &
                            ",act_no2=:act_no2 , act_company2=:act_company2 , act_start2=:act_start2 , act_ends2=:act_ends2 , act_photo2=:act_photo2 , act_photo2_2=:act_photo2_2 " &
                            " WHERE act_id = " & hidact_id.Value
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strUpdate
            cmd.Parameters.Clear()
            cmd.Parameters.Add("act_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtActNo.Text.Trim = "", Nothing, txtActNo.Text)
            cmd.Parameters.Add("act_start", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtActStart.Text.Trim = "", Nothing, _txtActStart) 'IIf(txtActStart.Text.Trim = "", Nothing, txtActStart.Text)
            cmd.Parameters.Add("act_ends", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtActExpire.Text.Trim = "", Nothing, _txtActExpire) 'IIf(txtActExpire.Text.Trim = "", Nothing, txtActExpire.Text)
            cmd.Parameters.Add("act_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidPhotoAct.Value.Trim = "", Nothing, hidPhotoAct.Value)
            If String.IsNullOrWhiteSpace(hidPhotoAct_2.Value) Then
                cmd.Parameters.Add("act_photo_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
            Else
                cmd.Parameters.Add("act_photo_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoAct_2.Value
            End If

            cmd.Parameters.Add("act_company", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtActCompany.Text.Trim = "", Nothing, txtActCompany.Text)
            cmd.Parameters.Add("act_no2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtActNo2.Text.Trim = "", Nothing, txtActNo2.Text)
            cmd.Parameters.Add("act_start2", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtActStart2.Text.Trim = "", Nothing, _txtActStart2) ' IIf(txtActStart2.Text.Trim = "", Nothing, txtActStart2.Text)
            cmd.Parameters.Add("act_ends2", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtActExpire2.Text.Trim = "", Nothing, _txtActExpire2) 'IIf(txtActExpire2.Text.Trim = "", Nothing, txtActExpire2.Text)
            cmd.Parameters.Add("act_photo2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidPhotoAct2.Value.Trim = "", Nothing, hidPhotoAct2.Value)
            If String.IsNullOrWhiteSpace(hidPhotoAct2_2.Value) Then
                cmd.Parameters.Add("act_photo2_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
            Else
                cmd.Parameters.Add("act_photo2_2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoAct2_2.Value
            End If
            cmd.Parameters.Add("act_company2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtActCompany2.Text.Trim = "", Nothing, txtActCompany2.Text)
            cmd.ExecuteNonQuery()

            If Request.QueryString("is_renew") IsNot Nothing Then
                Dim Gid As Integer = dbConnect.executeScalar("select group_id from travel_group_car where license_id = " & hidlicense_id.Value)
                Response.Redirect("GroupAdd.aspx?id=" & Gid & "&tab=2")

            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            cmd.Connection.Close()
            con.Close()
        End Try

        ''ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "tab5();", True)

    End Sub


    Protected Sub btnPrev2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev2.Click
        If Request.QueryString("is_renew") IsNot Nothing Then
            Dim DB As New DBConnect
            Dim Gid As Integer = DB.executeScalar("select group_id from travel_group_car where license_id = " & hidlicense_id.Value)
            Response.Redirect("GroupAdd.aspx?id=" & Gid & "&tab=2")
        Else

            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script6", "tab1();", True)
        End If
    End Sub

    Protected Sub btnPrev3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev3.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script8", "tab2();", True)
    End Sub
    Protected Sub btnPrev4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev4.Click
        If Request.QueryString("is_renew") IsNot Nothing Then
            Dim DB As New DBConnect
            Dim Gid As Integer = DB.executeScalar("select group_id from travel_group_car where license_id = " & hidlicense_id.Value)
            Response.Redirect("GroupAdd.aspx?id=" & Gid & "&tab=2")
        Else

            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script9", "tab3();", True)
        End If

    End Sub

    Protected Sub btnLoadDriver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadDriver.Click
        txtName.Text = txtOwnerName.Text
        txtSurname.Text = txtOwnerLastName.Text
        txtAddress.Text = txtOwnerAddress.Text
        'txtOwnerIdcard.Text = txtOwnerIdcard.Text
        'txtTel.Text = txtOwnertel.Text
        txtZipcode.Text = txtOwnerZipcode.Text
        txtCounty.Text = txtOwnerProvince.Text
        txtEmail.Text = txtLicenseEmail.Text
        Select Case ddlOwnerPrename.SelectedValue
            Case "Mr.", "Mrs.", "Ms.", "Miss."
                ddlPrename.SelectedValue = ddlOwnerPrename.SelectedValue
                txtPrename.Visible = False
            Case "Other"
                ddlPrename.SelectedValue = "Other"
                txtPrename.Text = txtOwnerPrename.Text
                txtPrename.Visible = True
            Case Else
                ddlPrename.SelectedValue = "Other"
                txtPrename.Text = txtOwnerPrename.Text
                txtPrename.Visible = True
        End Select
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script15", "tab2();", True)
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

        If Session("user_type") = 1 Then
            Paneladd.Visible = False
            ddlProvarea.Visible = False
            If gvProv.Columns.Count > 0 Then
                Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                ProvareaDelete.Visible = False
            End If
        Else
            Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
            ProvareaDelete.Visible = False
        End If

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script20", "tab5();", True)
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
        If txtActCompany.Text = "" Or txtActNo.Text = "" Or txtActStart.Text = "" Or txtActExpire.Text = "" Or txtActCompany2.Text = "" Or txtActNo2.Text = "" Or txtActStart2.Text = "" Or txtActExpire2.Text = "" Then
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
        Else

            btnNext5_Click(sender, e)

            Try
                Send.Email(txtLicenseEmail.Text, txtOwnerName.Text & " " & txtOwnerLastName.Text, Request.QueryString("token"), 2)
            Catch ex As Exception

            End Try


            Dim DBconnect As New DBConnect
            Dim con As Npgsql.NpgsqlConnection = DBconnect.getConnection
            Dim cmd As New Npgsql.NpgsqlCommand
            ' Dim dread As Npgsql.NpgsqlDataReader

            Try
                con.Open()
                cmd.Connection = con
                Dim sqlUpdate As String = "Update license set  token=:token , regis_date=:regis_date , status_id = 0  WHERE license_id = " & hidlicense_id.Value
                cmd.CommandText = CommandType.Text
                cmd.CommandText = sqlUpdate
                cmd.Parameters.Clear()
                Dim pToken As Object = DBconnect.Token(hidlicense_id.Value, hidcar_id.Value)
                cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pToken
                'cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckin.SelectedValue
                ''cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckout.SelectedValue
                cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
                'cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddladmin.SelectedValue
                cmd.ExecuteNonQuery()

                Dim sqlUpdateSend = "Update driver set is_send = 1 WHERE driver_id = " & hidlicense_id.Value
                cmd.CommandText = sqlUpdateSend
                cmd.Parameters.Clear()
                cmd.ExecuteNonQuery()


               
                Response.Redirect("index.aspx")

            Catch ex As Exception

            Finally
                DBconnect = Nothing
                cmd.Connection.Close()
                con.Close()
                cmd.Dispose()
                con.Dispose()
            End Try
        End If

    End Sub
    Protected Sub btnSave_Command(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtActCompany.Text = "" Or txtActNo.Text = "" Or txtActStart.Text = "" Or txtActExpire.Text = "" Or hidPhotoAct.Value.Trim = "" _
            Or txtActCompany2.Text = "" Or txtActNo2.Text = "" Or txtActStart2.Text = "" Or txtActExpire2.Text = "" Or hidPhotoAct2.Value.Trim = "" Then
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "fromCheck();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script2", "tab4();", True)
        Else
            btnNext5_Click(sender, e)



            Dim DBconnect As New DBConnect
            Dim con As Npgsql.NpgsqlConnection = DBconnect.getConnection
            Dim cmd As New Npgsql.NpgsqlCommand
            Dim TableCommand As DataTable = DBconnect.TableCommand

            'Dim dread As Npgsql.NpgsqlDataReader

            Try
                con.Open()
                cmd.Connection = con
                Dim sqlUpdate As String = "Update license set  token = :token  WHERE license_id = " & hidlicense_id.Value
                cmd.CommandText = CommandType.Text
                cmd.CommandText = sqlUpdate
                cmd.Parameters.Clear()
                cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBconnect.Token(hidlicense_id.Value, hidcar_id.Value)
                'cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckin.SelectedValue
                'cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddladmin.SelectedValue
                'cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckout.SelectedValue
                cmd.ExecuteNonQuery()





                TableCommand.Clear()
                TableCommand.Rows.Add("is_send", NpgsqlTypes.NpgsqlDbType.Integer, "1")
                Dim tableUpdate = DBconnect.UpdateDataTable(TableCommand, "driver", "WHERE driver_id = " & hiddriver_id.Value)

                'เชคหน่อยว่าถ้ามาแก้จากสถานะ 2/"Incomplete"/"เอกสารไม่สมบูรณ์"
                Dim dtGroup As DataTable = DBconnect.getDataTable("select coalesce(license.status_id,0) as status_id ,  CAST(crypt(travel_group_car.group_id :: text, 'groupid2562') as varchar)  token " & _
                                                                  " from license left join travel_group_car on travel_group_car.license_id =  license.license_id " & _
                                                                  " where license.license_id = " & hidlicense_id.Value, "")
                Dim drowG As DataRow = dtGroup.Rows(0)
                Dim status = drowG("status_id")
                If status = "2" Then
                    Dim sqlUpdateEdit As String = "Update license set is_edit_user = 1 WHERE license_id = " & hidlicense_id.Value
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = sqlUpdateEdit
                    cmd.Parameters.Clear()
                    cmd.ExecuteNonQuery()

                    'Response.Redirect("GroupEdit.aspx?tab=2&token=" & drowG("token"))
                    If Not (Request.QueryString("isedit") Is Nothing) Then

                    Else
                        Response.Redirect("GroupEdit.aspx?tab=2&token=" & drowG("token"))
                    End If
                Else
                    Response.Redirect("index.aspx")
                End If

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            Finally
                DBconnect = Nothing
                cmd.Connection.Close()
                con.Close()
                cmd.Dispose()
                con.Dispose()
            End Try
            If Not (Request.QueryString("isedit") Is Nothing) Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", " window.open(window.location, '_self').close(); ", True)
                'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", " parent.closeIFrame(); ", True)
            End If


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

        If Session("user_type") = 1 Then
            Paneladd.Visible = False
            ddlProvarea.Visible = False
            If gvProv.Columns.Count > 0 Then
                Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                ProvareaDelete.Visible = False
            End If
        ElseIf pro <> 0 Then
            Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
            ProvareaDelete.Visible = False
        End If



        UpdatePanel11.Update()

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMap(" & pro & ");", True)
    End Sub
    Protected Sub Provarea_Delete(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        If Session("user_type") = 1 Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "alert('Do not delete because there must be at least 1 province.')", True)
        ElseIf Session("user_type") = 2 And tbProvice.Rows.Count = 1 And e.CommandArgument <> 0 Then
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
            tbProvice.Rows.Remove(data(0))
            gvProv.DataSource = tbProvice
            gvProv.DataBind()


            If Session("user_type") = 1 Then
                Paneladd.Visible = False
                ddlProvarea.Visible = False
                If gvProv.Columns.Count > 0 Then
                    Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                    ProvareaDelete.Visible = False
                End If
            ElseIf prov_code <> 0 Then
                Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                ProvareaDelete.Visible = False
            End If


            UpdatePanel11.Update()

            For Each i As DataRow In tbProvice.Rows
                Try
                    ddlProvarea.Items.FindByValue(i("prov_code").ToString).Attributes.Add("disabled", "disabled")
                    If Session("user_type") = 1 Or Session("user_type") = 2 Then
                        strprov_code = i("prov_code").ToString & ","
                    End If
                Catch ex As Exception

                End Try
            Next

            strprov_code = strprov_code.Remove(strprov_code.Length - 1)

            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMapDel(" & prov_code & ");", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack2", "get_IframeMapDel(" & prov_code & ");", True)
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack10", "get_IframeMap(" & strprov_code & ");", True)
        End If
    End Sub

   
End Class
