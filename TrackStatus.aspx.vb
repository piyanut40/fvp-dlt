Imports Npgsql
Imports System.Data

Partial Class TrackStatus
    Inherits System.Web.UI.Page
    Dim url As String
    Protected Css As String = ""
    Private PopulateS As New PopulateScript
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Not Request.QueryString("token") Is Nothing Then
                LoadData()
            End If
            If PopulateS.IsMobile Then
                Css = "style='font-size:14px;'"
            End If
        End If
    End Sub

    Private Sub LoadData()
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            Dim str = " SELECT driver.prename , driver.name ,  driver.surname , idcard_no , license.status_id , license_expire , licensedriver_photo , status_en " & _
            " , typename_en , CAST('RenewPermit.aspx?type=' || car.typecar_id  || '&regis=' || license.typeuser_id ||'&token='||license.token  as varchar) as urlrenew " & _
            " , license_no , dtcheckin.border_nameen as border_checkin , dtcheckout.border_nameen as border_checkout , travel_group.start_date , travel_group.exp_date , regis_date , admin_nameen " & _
            " from driver LEFT JOIN license on license.driver_id = driver.driver_id " & _
            " left join status on status.status_id  = license.status_id " & _
            " left join type_user on type_user.typeuser_id = license.typeuser_id " & _
            " left join travel_group_car on travel_group_car.license_id = license.license_id " & _
            " left join travel_group on travel_group_car.group_id = travel_group.group_id " & _
            " left join border_check dtcheckin  on dtcheckin.border_id = travel_group.checkin_id " & _
            " left join border_check dtcheckout on dtcheckout.border_id = travel_group.checkout_id " & _
            " left join admin on admin.admin_id = license.admin_id " & _
            " left join car on license.car_id = car.car_id " & _
            " WHERE license.token = '" & Request.QueryString("token") & "' "
            cmd.CommandText = str
            dread = cmd.ExecuteReader()
            If dread.Read Then
                If dread("prename") IsNot DBNull.Value Then
                    If (dread("prename") = "Mr." Or dread("prename") = "Ms." Or dread("prename") = "Miss." Or dread("prename") = "Mrs.") Then
                        lblName.Text = dread("prename")
                    Else
                        lblName.Text = dread("prename")
                    End If
                End If

                If dread("status_id") IsNot DBNull.Value Then
                    If dread("status_id") = 5 Or dread("status_id") = 1 Then
                        btnReapply.Visible = False
                        btnRenewPermit.Visible = False
                    Else
                        btnRenewPermit.Visible = False
                        btnReapply.Visible = False
                    End If
                End If

                If dread("name") IsNot DBNull.Value Then
                    lblName.Text = lblName.Text & " " & dread("name")
                    lblNameM.Text = lblName.Text
                End If


                If dread("surname") IsNot DBNull.Value Then
                    lblName.Text = lblName.Text & " " & dread("surname")
                    lblNameM.Text = lblName.Text
                End If

                If dread("idcard_no") IsNot DBNull.Value Then
                    lblIdcardDriver.Text = dread("idcard_no")
                    lblLicenseDriverM.Text = lblIdcardDriver.Text
                End If

                If dread("license_expire") IsNot DBNull.Value Then
                    lblLicenseExpire.Text = dread("license_expire")
                    lblLicenseExpire.Text = Format(CDate(lblLicenseExpire.Text), "MM/dd/yyyy")
                    lblLicenseDriverExM.Text = lblLicenseExpire.Text
                End If

                If dread("licensedriver_photo") IsNot DBNull.Value Then
                    hidPhotoNameLicense.Value = dread("licensedriver_photo")
                    PhotoLicense.ImageUrl = "~/Upload/LicenseDriver/" & hidPhotoNameLicense.Value
                    PhotoLicense.Visible = True
                    btnUploadLicense1.Visible = False
                    FileUpload3.Visible = False
                    'PhotoDeleteLicense.Visible = True
                End If

                If dread("status_en") IsNot DBNull.Value Then
                    lblstatus_en.Text = dread("status_en")
                    lblStatusM.Text = lblstatus_en.Text
                End If
                If dread("typename_en") IsNot DBNull.Value Then
                    lbltypename_en.Text = dread("typename_en")
                    lblTypeM.Text = lbltypename_en.Text
                End If
                If dread("license_no") IsNot DBNull.Value Then
                    lbllicense_no.Text = dread("license_no")
                    lblLicenseNoM.Text = lbllicense_no.Text
                Else
                    lbllicense_no.Text = "-"
                    lblLicenseNoM.Text = "-"
                End If

                If dread("regis_date") IsNot DBNull.Value Then
                    lblregis_date.Text = Format(CDate(dread("regis_date")), "MM/dd/yyyy")
                    lblRegisM.Text = lblregis_date.Text
                End If

                If dread("border_checkin") IsNot DBNull.Value Then
                    lblborder_checkin.Text = dread("border_checkin")
                    lblCheckinM.Text = lblborder_checkin.Text
                Else
                    lblborder_checkin.Text = "-"
                    lblCheckinM.Text = "-"
                End If
                If dread("border_checkout") IsNot DBNull.Value Then
                    lblborder_checkout.Text = dread("border_checkout")
                    lblCheckOutM.Text = lblborder_checkout.Text
                Else
                    lblborder_checkout.Text = "-"
                    lblCheckOutM.Text = "-"
                End If

                If dread("start_date") IsNot DBNull.Value Then
                    lblstart_date.Text = Format(CDate(dread("start_date")), "MM/dd/yyyy")
                    lblStartDateM.Text = lblstart_date.Text
                Else
                    lblstart_date.Text = "-"
                    lblStartDateM.Text = "-"
                End If
                If dread("exp_date") IsNot DBNull.Value Then
                    lblexp_date.Text = Format(CDate(dread("exp_date")), "MM/dd/yyyy")
                    lblEndDateM.Text = lblexp_date.Text
                Else
                    lblexp_date.Text = "-"
                    lblEndDateM.Text = "-"
                End If
                If dread("admin_nameen") IsNot DBNull.Value Then
                    lbladmin_name.Text = dread("admin_nameen")
                End If
                If dread("urlrenew") IsNot DBNull.Value Then
                    hidurlRenew.Value = dread("urlrenew")
                End If
                lnkPrint.NavigateUrl = "RptApplication.aspx?token=" & Request.QueryString("token")
            End If
            dread.Close()
        Catch ex As Exception
        Finally
            cmd.Connection.Close()
            con.Close()
        End Try

    End Sub

    Protected Sub btnRenewPermit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRenewPermit.Click
        Response.Redirect(hidurlRenew.Value)
    End Sub
    Protected Sub btnReapply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReapply.Click
        Response.Redirect(hidurlRenew.Value)
    End Sub
End Class
