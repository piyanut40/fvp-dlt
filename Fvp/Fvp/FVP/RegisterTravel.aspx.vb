Imports Npgsql
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic
Imports System
Partial Class RegisterTravel
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
        'Populate.genDDLTumbol(ddlPro, ddlAmp, ddlTum, False)
        'UpdLocation.Update()
        Dim Location As String = ZoomLocation()
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript3", " " & Location & " ", True)
    End Sub
#End Region

    Private Function ZoomLocation() As String
        Dim min_x, min_y, max_x, max_y As Double
        Dim chkSch As Boolean = True
        Dim sql As String = ""
        Dim conname As String = ""
        Dim strCommand As String = ""

        If ddlTum.SelectedIndex <> 0 Then
            strCommand = " SELECT  ST_xmin(ST_extent(ST_Transform(the_geom, 4326))) As xmin " &
                " , ST_Ymin(ST_extent(ST_Transform(the_geom, 4326))) As ymin" &
                " , ST_xmax(ST_extent(ST_Transform(the_geom, 4326))) As xmax " &
                " , ST_ymax(ST_extent(ST_Transform(the_geom, 4326))) As ymax " &
                "from tumbol WHERE t_id='" & ddlTum.SelectedValue & "'"
        ElseIf ddlAmp.SelectedIndex <> 0 Then
            strCommand = " SELECT ST_xmin(ST_extent(ST_Transform(the_geom, 4326))) As xmin " &
                " , ST_Ymin(ST_extent(ST_Transform(the_geom, 4326))) As ymin" &
                " , ST_xmax(ST_extent(ST_Transform(the_geom, 4326))) As xmax " &
                " , ST_ymax(ST_extent(ST_Transform(the_geom, 4326))) As ymax " &
                "from tumbol WHERE a_code='" & ddlAmp.SelectedValue & "' and p_code='" & hidProv.Value & "'"
        Else
            strCommand = " SELECT  ST_xmin(ST_extent(ST_Transform(the_geom, 4326))) As xmin " &
                " , ST_Ymin(ST_extent(ST_Transform(the_geom, 4326))) As ymin" &
                " , ST_xmax(ST_extent(ST_Transform(the_geom, 4326))) As xmax " &
                " , ST_ymax(ST_extent(ST_Transform(the_geom, 4326))) As ymax " &
                "from province WHERE prov_code='" & ddlPro.SelectedValue & "'"
            'Else
            '    chkSch = False
        End If

        If chkSch Then
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
            Try
                'con.ClearPool()
                Npgsql.NpgsqlConnection.ClearPool(con)
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
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script4", "tab3();", True)
            End If
        End If
    End Sub

    Private sendemail As New SendEmail



    Protected Sub LinkbtnSignup_Click(sender As Object, e As System.EventArgs) Handles LinkbtnSignup.Click
        If txtUsername.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please specify your username!!'); </script>", False)
        ElseIf txtPassword.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please specify your Password!!'); </script>", False)
        ElseIf txtConPassword.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please specify your Confirm Password!!'); </script>", False)
        ElseIf txtName.Text.Trim = "" Or txtSurname.Text.Trim = "" Or txtAddressT.Text.Trim = "" Or txtIdcard.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please fill in the following information!!'); </script>", False)
        ElseIf txtEmail.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please specify your email !!'); </script>", False)
        ElseIf txtexpdate.Text = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please specify expired license !! '); </script>", False)
        ElseIf hidPhotoNameLicense.Value = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'> alert('Please Upload agency license !! '); </script>", False)
        Else
            Dim dbConnect As New DBConnect
            Dim cmd As New NpgsqlCommand
            Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
            Dim countUser As Integer
            Dim strError As String = ""
            Try
                con.Open()
                cmd.Connection = con
                Dim Checkuser = "select count(username) from user_travel WHERE username like '%" & txtUsername.Text.Trim & "%'"
                cmd.CommandText = Checkuser
                countUser = cmd.ExecuteScalar()
                If countUser = 1 Then
                    strError = "alert('This username is already in use !!');"
                    ClientScript.RegisterStartupScript(Me.GetType(), "Script", "<script type='text/javascript'>" & strError & "</script>")
                    txtUsername.Text = ""
                    txtPassword.Text = ""
                    txtConPassword.Text = ""
                ElseIf txtPassword.Text <> txtConPassword.Text Then
                    strError = "alert('Password does not match the confirm password !! ');"
                    ClientScript.RegisterStartupScript(Me.GetType(), "Script", "<script type='text/javascript'>" & strError & "</script>")
                    txtPassword.Text = ""
                    txtConPassword.Text = ""
                Else
                    Dim strthe_geom As String = "st_transform(st_setsrid( st_point( " & hidlon.Value & " ," & hidlat.Value & ") ::geometry ,4326)  ,32647)"
                    If hidlat.Value = "" Or hidlon.Value = "" Then
                        strthe_geom = " null "
                    End If
                    Dim strInsert = "Insert INTO user_travel (name_company , user_name , user_surname , idcard , telephone , tumbol , amphoe , " &
                                  " province , postal , lat , lon , email , facebook , line , company_license , address , user_type , username , pass , the_geom , is_active , license_photo , license_exp )" &
                                  " VALUES (:name_company , :user_name , :user_surname , :idcard  ,  :telephone , :tumbol , :amphoe , " &
                                  " :province , :postal , :lat, :lon , :email , :facebook , :line  , :company_license , :address , 2 , :username , :pass , " & strthe_geom & " , 0 , :license_photo , :license_exp ) "

                    cmd.CommandText = strInsert
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("name_company", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtCompanyName.Text = "", Nothing, txtCompanyName.Text)
                    cmd.Parameters.Add("user_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtName.Text = "", Nothing, txtName.Text)
                    cmd.Parameters.Add("user_surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtSurname.Text = "", Nothing, txtSurname.Text)
                    cmd.Parameters.Add("idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtIdcard.Text = "", Nothing, txtIdcard.Text)
                    'cmd.Parameters.Add("agency_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtAgencyNo.Text = "", Nothing, txtAgencyNo.Text)
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
                    cmd.Parameters.Add("username", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtUsername.Text
                    cmd.Parameters.Add("pass", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.password(txtUsername.Text, txtPassword.Text)
                    cmd.Parameters.Add("license_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoNameLicense.Value
                    cmd.Parameters.Add("license_exp", NpgsqlTypes.NpgsqlDbType.Date).Value = txtexpdate.Text
                    cmd.ExecuteNonQuery()
                    'Dim strSuccess As String = "alert('Signup Success ');"
                    'Dim linktoLogin As String = "window.location.href = 'Login.aspx';"
                    'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "<script type='text/javascript'>" & strSuccess & linktoLogin & "</script>", False)
                    'Response.Redirect("document.aspx?token=" & dbConnect.Token(Session("driver_id"), Session("car_id")))
                    sendemail.EmailTravelRegis(txtEmail.Text, txtName.Text & " " & txtSurname.Text, txtCompanyName.Text, txtLiecense.Text)
                    Response.Redirect("RegisterCompleteTravel.aspx")
                End If


            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "<script type='text/javascript'> alert('Error please try again!!'); </script>", False)
            Finally
                dbConnect = Nothing
                con.Dispose()
                cmd.Dispose()
            End Try
        End If

    End Sub
End Class
