Imports Npgsql
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic

Partial Class Travel_EditUserTravel
    Inherits System.Web.UI.Page

    Protected statusth As String
    Protected Img As String
    Protected name As String
    Private Populate As New PopulateDropDown
    Dim fPath As String = Server.MapPath(ConfigurationManager.AppSettings("FilePhotoUser"))
    Dim fPathLicense As String = Server.MapPath(ConfigurationManager.AppSettings("FileTravel"))


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Populate.genDDLProvinceNotAll(ddlPro, False)
            Populate.genDDLAmphoe(ddlPro, ddlAmp, False)
            Populate.genDDLTumbol(ddlPro, ddlAmp, ddlTum, False)

            LoadData()
            lat.Text = hidlat.Value
            lon.Text = hidlon.Value
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", " tab1(); Getloaction(" & hidlon.Value & " , " & hidlat.Value & " ); ", True)
        End If

        If hidPhotoNameLicense.Value <> "" Then
            PhotoLicense.ImageUrl = "~/Upload/FileTravel/" & hidPhotoNameLicense.Value
            PhotoLicense.Visible = True
            btnUploadLicense.Visible = False
            FileUploadLicense.Visible = False
            PhotoDeleteLicense.Visible = True
        Else
            PhotoLicense.Visible = False
        End If
    End Sub

    Private Sub LoadData()
        If Session("user_id") Is Nothing Then
            Response.Redirect("../Login.aspx")
        Else
            'Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Dim dread As Npgsql.NpgsqlDataReader
            Try
                con.Open()
                cmd.Connection = con
                Dim strCheckUser As String = " SELECT name_company , user_name , user_surname , idcard , license_exp , telephone , tumbol , amphoe , " & _
                                      " province , postal , lat , lon , email , facebook , line , company_license , address , user_type , username , pass , the_geom , is_active , license_photo " & _
                                          " FROM user_travel  WHERE user_id = " & Session("user_id")
                cmd.CommandText = CommandType.Text
                cmd.CommandText = strCheckUser
                dread = cmd.ExecuteReader()
                If dread.Read Then
                    If Not dread("user_name") Is DBNull.Value Then
                        txtName.Text = dread("user_name")
                    End If
                    If Not dread("user_surname") Is DBNull.Value Then
                        txtSurname.Text = dread("user_surname")
                    End If
                    If Not dread("name_company") Is DBNull.Value Then
                        txtCompanyName.Text = dread("name_company")
                    End If
                    If Not dread("idcard") Is DBNull.Value Then
                        txtIdcard.Text = dread("idcard")
                    End If
                    If Not dread("license_exp") Is DBNull.Value Then
                        txtlicenseexp.Text = dread("license_exp")
                    End If
                    If Not dread("telephone") Is DBNull.Value Then
                        txtPhone.Text = dread("telephone")
                    End If
                    If Not dread("province") Is DBNull.Value Then
                        ddlPro.SelectedValue = dread("province")
                        Populate.genDDLAmphoe(ddlPro, ddlAmp, False)
                    End If
                    If Not dread("amphoe") Is DBNull.Value Then
                        ddlAmp.SelectedValue = dread("amphoe")
                        Populate.genDDLTumbol(ddlPro, ddlAmp, ddlTum, False)
                    End If
                    If Not dread("tumbol") Is DBNull.Value Then
                        ddlTum.SelectedValue = dread("tumbol")
                    End If
                    If Not dread("postal") Is DBNull.Value Then
                        txtPostal.Text = dread("postal")
                    End If
                    If Not dread("lat") Is DBNull.Value Then
                        hidlat.Value = dread("lat")
                    End If
                    If Not dread("lon") Is DBNull.Value Then
                        hidlon.Value = dread("lon")
                    End If
                    If Not dread("email") Is DBNull.Value Then
                        txtEmail.Text = dread("email")
                    End If
                    If Not dread("facebook") Is DBNull.Value Then
                        txtfacebook.Text = dread("facebook")
                    End If
                    If Not dread("line") Is DBNull.Value Then
                        txtLine.Text = dread("line")
                    End If
                    If Not dread("company_license") Is DBNull.Value Then
                        txtLiecense.Text = dread("company_license")
                    End If
                    If Not dread("address") Is DBNull.Value Then
                        txtAddressT.Text = dread("address")
                    End If

                    hidPhotoNameLicense.Value = ""
                    If Not dread("license_photo") Is DBNull.Value Then
                        hidPhotoNameLicense.Value = dread("license_photo")
                    End If
                    If hidPhotoNameLicense.Value <> "" Then
                        PhotoLicense.ImageUrl = "~/Upload/FileTravel/" & hidPhotoNameLicense.Value
                        PhotoLicense.Visible = True
                        btnUploadLicense.Visible = False
                        'FileUploadLicense.Visible = False
                        PhotoDeleteLicense.Visible = True
                    Else
                        PhotoLicense.Visible = False
                    End If
                End If
                dread.Close()
                'UpdLocation.Update()
                'UpdateLicense.Update()

            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "alert('" & ex.Message.ToString & "');", True)
            Finally
                cmd.Connection.Close()
                con.Close()
                'dbConnect = Nothing
                con.Dispose()
                cmd.Dispose()
            End Try
        End If

    End Sub


#Region "ตำบล/อำเภอ/จังหวัด"
    Protected Sub ddlPro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPro.SelectedIndexChanged
        Populate.genDDLAmphoe(ddlPro, ddlAmp, False)
        Populate.genDDLTumbol(ddlPro, ddlAmp, ddlTum, False)
        hidProv.Value = ddlPro.SelectedValue
        UpdLocation.Update()
        Dim Location As String = ZoomLocation()
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", " " & Location & " ", True)
    End Sub

    Protected Sub ddlAmp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAmp.SelectedIndexChanged
        hidProv.Value = ddlPro.SelectedValue
        Populate.genDDLTumbol(ddlPro, ddlAmp, ddlTum, False)
        UpdLocation.Update()
        Dim Location As String = ZoomLocation()
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript2", " " & Location & " ", True)
    End Sub

    Protected Sub ddlTum_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTum.SelectedIndexChanged

        Dim Location As String = ZoomLocation()
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript3", " " & Location & " ", True)
    End Sub

    Private Function ZoomLocation() As String
        Dim min_x, min_y, max_x, max_y As Double
        Dim chkSch As Boolean = True
        Dim sql As String = ""
        Dim conname As String = ""
        Dim strCommand As String = ""

        If ddlTum.SelectedIndex <> 0 Then
            strCommand = " SELECT  ST_xmin(ST_extent(ST_Transform(the_geom, 4326))) As xmin " & _
                " , ST_Ymin(ST_extent(ST_Transform(the_geom, 4326))) As ymin" & _
                " , ST_xmax(ST_extent(ST_Transform(the_geom, 4326))) As xmax " & _
                " , ST_ymax(ST_extent(ST_Transform(the_geom, 4326))) As ymax " & _
                "from tumbol WHERE t_id='" & ddlTum.SelectedValue & "'"
        ElseIf ddlAmp.SelectedIndex <> 0 Then
            strCommand = " SELECT ST_xmin(ST_extent(ST_Transform(the_geom, 4326))) As xmin " & _
                " , ST_Ymin(ST_extent(ST_Transform(the_geom, 4326))) As ymin" & _
                " , ST_xmax(ST_extent(ST_Transform(the_geom, 4326))) As xmax " & _
                " , ST_ymax(ST_extent(ST_Transform(the_geom, 4326))) As ymax " & _
                "from tumbol WHERE a_code='" & ddlAmp.SelectedValue & "' and p_code='" & hidProv.Value & "'"
        Else
            strCommand = " SELECT  ST_xmin(ST_extent(ST_Transform(the_geom, 4326))) As xmin " & _
                " , ST_Ymin(ST_extent(ST_Transform(the_geom, 4326))) As ymin" & _
                " , ST_xmax(ST_extent(ST_Transform(the_geom, 4326))) As xmax " & _
                " , ST_ymax(ST_extent(ST_Transform(the_geom, 4326))) As ymax " & _
                "from province WHERE prov_code='" & ddlPro.SelectedValue & "'"
            'Else
            '    chkSch = False
        End If

        If chkSch Then
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
            Try
                con.ClearPool()
                cmd.Connection = con
                If cmd.Connection.State = Data.ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = strCommand
                Dim dr As NpgsqlDataReader
                dr = cmd.ExecuteReader
                If dr.Read Then
                    min_x = IIf(dr("xmin") Is DBNull.Value, 0, dr("xmin"))
                    min_y = IIf(dr("ymin") Is DBNull.Value, 0, dr("ymin"))
                    max_x = IIf(dr("xmax") Is DBNull.Value, 0, dr("xmax"))
                    max_y = IIf(dr("ymax") Is DBNull.Value, 0, dr("ymax"))
                End If
                dr.Close()
                con.Close()
            Catch ex As Exception

            Finally
                If cmd.Connection.State = Data.ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                con.Close()
            End Try
            Return " ZoomLocation(" & min_x & "," & min_y & "," & max_x & "," & max_y & "); "
        Else
            Return ""
        End If
    End Function
#End Region

    Protected Sub btnNext2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext2.Click
        lat.Text = hidlat.Value
        lon.Text = hidlon.Value
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2(); Getloaction(" & hidlon.Value & " , " & hidlat.Value & " ); ", True)
    End Sub

    Protected Sub btnNext3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext3.Click
    
        If txtName.Text.Trim = "" Or txtSurname.Text.Trim = "" Or txtlicenseexp.Text.Trim = "" Or txtAddressT.Text.Trim = "" Or txtIdcard.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'>tab1(); alert('Please fill in the following information!!'); </script>", False)
        ElseIf txtEmail.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'>tab1(); alert('Please specify your email !!'); </script>", False)
        ElseIf hidPhotoNameLicense.Value = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'>tab1(); alert('Please Upload agency license !! '); </script>", False)
        Else
            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
            Dim strError As String = ""
            Try
                con.Open()
                cmd.Connection = con

                Dim strthe_geom As String = "st_transform(st_setsrid( st_point( " & hidlon.Value & " ," & hidlat.Value & ") ::geometry ,4326)  ,32647)"
                If hidlat.Value = "" Or hidlon.Value = "" Then
                    strthe_geom = " null "
                End If
                Dim strInsert = "UPDATE user_travel SET name_company = :name_company , user_name = :user_name , user_surname = :user_surname , idcard = :idcard " & _
                                " , license_exp = :license_exp , telephone = :telephone , tumbol = :tumbol , amphoe = :amphoe ,  province = :province , postal = :postal " & _
                                " , lat = :lat , lon = :lon , email = :email , facebook = :facebook , line = :line , company_license = :company_license , address = :address " & _
                                " , the_geom = " & strthe_geom & " , license_photo = :license_photo where user_id = " & Session("user_id")

                cmd.CommandText = strInsert
                cmd.Parameters.Clear()
                cmd.Parameters.Add("name_company", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtCompanyName.Text = "", Nothing, txtCompanyName.Text)
                cmd.Parameters.Add("user_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtName.Text = "", Nothing, txtName.Text)
                cmd.Parameters.Add("user_surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtSurname.Text = "", Nothing, txtSurname.Text)
                cmd.Parameters.Add("idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtIdcard.Text = "", Nothing, txtIdcard.Text)
                cmd.Parameters.Add("license_exp", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtlicenseexp.Text = "", Nothing, txtlicenseexp.Text)
                cmd.Parameters.Add("telephone", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtPhone.Text = "", Nothing, txtPhone.Text)
                cmd.Parameters.Add("tumbol", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlTum.SelectedValue
                cmd.Parameters.Add("amphoe", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlAmp.SelectedValue
                cmd.Parameters.Add("province", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ddlPro.SelectedValue
                cmd.Parameters.Add("postal", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtPostal.Text = "", Nothing, txtPostal.Text)
                If hidlat.Value = "" Then
                    cmd.Parameters.Add("lat", NpgsqlTypes.NpgsqlDbType.Numeric).Value = DBNull.Value
                Else
                    cmd.Parameters.Add("lat", NpgsqlTypes.NpgsqlDbType.Numeric).Value = hidlat.Value
                End If
                If hidlon.Value = "" Then
                    cmd.Parameters.Add("lon", NpgsqlTypes.NpgsqlDbType.Numeric).Value = DBNull.Value
                Else
                    cmd.Parameters.Add("lon", NpgsqlTypes.NpgsqlDbType.Numeric).Value = hidlon.Value
                End If
                cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtEmail.Text
                cmd.Parameters.Add("facebook", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtfacebook.Text = "", Nothing, txtfacebook.Text)
                cmd.Parameters.Add("line", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLine.Text = "", Nothing, txtLine.Text)
                cmd.Parameters.Add("company_license", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtLiecense.Text = "", Nothing, txtLiecense.Text)
                cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtAddressT.Text = "", Nothing, txtAddressT.Text)
                cmd.Parameters.Add("license_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense.Value
                cmd.ExecuteNonQuery()

                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "<script type='text/javascript'> tab1(); alert('Save successfully'); </script>", False)
                Response.Redirect("index.aspx")
            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "<script type='text/javascript'> alert('Error please try again!!'); </script>", False)
            Finally
                dbConnect = Nothing
                con.Dispose()
                cmd.Dispose()
            End Try
        End If

    End Sub

    Protected Sub btnPrev1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev1.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    End Sub

#Region "FileUpload"

    Protected Sub btn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn1.Click
        lat.Text = hidlat.Value
        lon.Text = hidlon.Value
    End Sub
    Protected Sub PhotoDeleteLicense_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteLicense.Command
        If File.Exists(fPathLicense & hidPhotoNameLicense.Value) Then
            File.Delete(fPathLicense & hidPhotoNameLicense.Value)
        End If
        btnUploadLicense.Visible = True
        FileUploadLicense.Visible = True
        hidPhotoNameLicense.Value = ""
        PhotoLicense.Visible = False
        PhotoDeleteLicense.Visible = False
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    End Sub

    Protected Sub btnUploadLicense_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadLicense.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUploadLicense.PostedFile.FileName <> "" Then
            If FileUploadLicense.HasFile Then
                srcName = Path.GetFileName(FileUploadLicense.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUploadLicense.PostedFile.FileName)
                srcName = (srcName & DateTime.Now).GetHashCode
                FileUploadLicense.PostedFile.SaveAs(Server.MapPath("~/Upload/FileTravel/") + srcName & srcExt)
                hidPhotoNameLicense.Value = srcName & srcExt
                PhotoLicense.ImageUrl = "~/Upload/FileTravel/" & hidPhotoNameLicense.Value
                PhotoLicense.Visible = True
                btnUploadLicense.Visible = False
                FileUploadLicense.Visible = False
                PhotoDeleteLicense.Visible = True
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab1();", True)
            End If
        End If
    End Sub

#End Region
End Class
