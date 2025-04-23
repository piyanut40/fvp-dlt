Imports Npgsql

Partial Class Admin_UserTravelData
    Inherits System.Web.UI.Page
    Protected Css As String = " w3-padding-top w3-left-right w3-left-align "
    Protected Css_Ctrl As String = ""
    Dim fPathLicense As String = Server.MapPath(ConfigurationManager.AppSettings("FileTravel"))

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            LoadData()
        End If
    End Sub

    Private Sub LoadData()
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim strsql As String = ""
        Try
            con.ClearPool()
            cmd.Connection = con
            cmd.Connection.Open()
            strsql = " SELECT  name_company as com_name , CAST(user_name || ' ' || user_surname as varchar) as agen_name, info_company, history, user_travel.telephone as com_tel, user_travel.email as com_mail, company_license " & _
                " , coalesce(user_travel.address,'')|| ' ตำบล' || t_name_t || ' อำเภอ' || a_name_t || ' จังหวัด' ||p_name_t|| ' ' ||coalesce(postal,'') as com_address , idcard , license_exp , facebook , line , lat , lon , license_photo"
            
            strsql = strsql & " FROM  user_travel  LEFT JOIN tumbol on tumbol.t_id = user_travel.tumbol " & _
                " where user_id = " & Request.QueryString("id")
            cmd.CommandText = strsql
            Dim dr As NpgsqlDataReader
            dr = cmd.ExecuteReader


            If dr.Read Then


                If Not dr("facebook") Is DBNull.Value Then
                    lblfacebook.Text = dr("facebook")
                End If

                If Not dr("line") Is DBNull.Value Then
                    lblline.Text = dr("line")
                End If

                If Not dr("com_name") Is DBNull.Value Then
                    lblcom_name.Text = dr("com_name")
                End If

                If Not dr("agen_name") Is DBNull.Value Then
                    lblagen_name.Text = dr("agen_name")
                End If

                If Not dr("idcard") Is DBNull.Value Then
                    lblidcard.Text = dr("idcard")
                End If

                If Not dr("license_exp") Is DBNull.Value Then
                    lblexpdate.Text = Format(CDate(dr("license_exp")), "d MMMM yyyy")
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

                If Not dr("lat") Is DBNull.Value Then
                    hidlat.Value = dr("lat")
                End If

                If Not dr("lon") Is DBNull.Value Then
                    hidlon.Value = dr("lon")
                End If

                If Not dr("license_photo") Is DBNull.Value Then
                    license_photo.ImageUrl = "../Upload/FileTravel/" & dr("license_photo")
                    Hyperlicense_photo.NavigateUrl = "../ViewImage.aspx?fpath=FileTravel&ImageType=" & dr("license_photo")
                Else
                    license_photo.Visible = False
                    Hyperlicense_photo.Visible = False
                End If

                ScriptManager.RegisterStartupScript(Page, GetType(Page), "ScriptMaps", " Getloaction(" & hidlon.Value & " , " & hidlat.Value & " );", True)


             
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
End Class
