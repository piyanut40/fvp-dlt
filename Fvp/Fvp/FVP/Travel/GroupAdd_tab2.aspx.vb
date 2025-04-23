Imports System.Data
Imports Npgsql

Partial Class Travel_GroupAdd_tab2
    Inherits System.Web.UI.Page
    Private group_id, is_renew As String
    Private IsMobile As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.QueryString("id") Is Nothing Then
            group_id = Request.QueryString("id")
        ElseIf Not Request.QueryString("token") Is Nothing Then
            Dim db As New DBConnect
            Try
                group_id = db.executeScalar("select group_id from travel_group where crypt(group_id :: text, 'groupid2562') = '" & Request.QueryString("token") & "' ")
            Catch ex As Exception

            Finally
                db = Nothing
            End Try
        Else
            group_id = Nothing
        End If

        If Not Request.QueryString("is_renew") Is Nothing Then
            is_renew = Request.QueryString("is_renew")
        End If

        If PopulateS.IsMobile Then
            IsMobile = True
            LinkSelectCar.Text = "<i class='fa fa-search' aria-hidden='true' ></i>"
            LinkAddCarNew.Text = "<i class='fa fa-plus' aria-hidden='true' ></i>"
        End If
        
        If Page.IsPostBack = False Then
           
            If Not group_id Is Nothing Then
                Dim strPopup As String = "javascript:w=window.open(" & _
                                       """" & ResolveClientUrl("LicenseSch.aspx?id=" & group_id & "&is_renew=" & is_renew) & """," & _
                                       """SearchLicenseWindow""," & _
                                       """" & "location=0,status=0,scrollbars=yes,resizable=no," & _
                                       "width=1200,height=740""" & _
                                       ");w.focus();"
                LinkSelectCar.Attributes.Add("OnClick", strPopup)

                LinkAddCarNew.Attributes.Add("OnClick", "javascript:window.parent.tab_Redirect('MgtEdit.aspx');")
            End If
            getCarLicense()
        End If
        
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack10", " $('#loadings').hide(); ", True)
    End Sub

 
    Private Sub genCarDriver()
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim license_id As Integer = 0
            If HidValueLicense.Value <> "" Then
                license_id = HidValueLicense.Value
            Else
                'license_id = ddlLicense.SelectedValue
            End If
            Dim strselect As String = "select car.plate || ' ' || country_car as text , type_name ,  CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name " & _
                " from license LEFT JOIN car on license.car_id = car.car_id " & _
                " left join type_car on type_car.type_id = car.typecar_id " & _
                " LEFT JOIN driver on driver.driver_id = license.driver_id where license_id = " & license_id 'ddlLicense.SelectedValue
            Dt = db.getDataTable(strselect, "Data")
            Dim drow As DataRow = Dt.Rows(0)
            lblLicense.Text = "<br/>" & drow("text")
            lblType.Text = drow("type_name")
            lblDriver.Text = drow("driver_name")
        Catch ex As Exception

        Finally
            db = Nothing
        End Try
    End Sub

    Private PopulateS As New PopulateScript
    Dim cnt_car As Integer
    'Dim is_renew As Integer
    Private Sub getCarLicense()
        Dim db As New DBConnect
        Try
           
            Hidduplicate.Value = "0"
            Dim dtCar As DataTable = db.getDataTable("select Row_number() over (order by plate || country_car nulls last) as number , travel_group_car.gid , plate , country_car , type_name , dt.status " & _
                " , CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name " & _
                " , travel_group.start_date , travel_group.exp_date , travel_group_car.license_id , is_renew, license.token " & _
                " , CAST('MgtEdit.aspx?token=' || license.token || '&is_renew=' || travel_group.is_renew as varchar ) as urlEdit " & _
                " , CAST('MgtEdit.aspx?token=' || license.token as varchar ) as urlEdit2 " & _
                " , CAST('MgtEdit.aspx?token=' || license.token || '&is_renew=' || travel_group.is_renew || '&ins=1' as varchar ) as urlIns " & _
                " , status_en  || '<br/>(' || status_th || ')' as status_en , is_edit_user " & _
                " from travel_group_car LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id  " & _
                " LEFT JOIN license on license.license_id = travel_group_car.license_id  " & _
                " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                " LEFT JOIN car on license.car_id = car.car_id " & _
                " LEFT JOIN status on license.status_id = status.status_id " & _
                " left join type_car on type_car.type_id = car.typecar_id " & _
                " left join (SELECT count(group_id) status , license_id FROM public.travel_group_car group by license_id ) dt on dt.license_id = license.license_id " & _
                " where travel_group_car.group_id = " & group_id, "carr")
            is_renew = dtCar.Rows(0).Item("is_renew")
            PopulateS.SetGrid_Footable(gvMain, dtCar)
            If PopulateS.IsMobile Then
                gvMain.Width = Unit.Percentage(98)
            End If
            UpdGrid.Update()

            cnt_car = dtCar.Rows.Count

        Catch ex As Exception

        Finally
            db = Nothing
        End Try
        'genDDLGuide(ddlGuide)
    End Sub

    Protected Sub btnPrev1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev1.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "window.parent.tab_activeIframe(1);", True)
    End Sub

    Protected Sub btnNext3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext3.Click
        If gvMain.Rows.Count = 0 Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Please add car')", True)
        ElseIf HidDuplicate.Value = "1" Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Vehicle have duplicate group tour')", True)
        Else
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "window.parent.tab_activeIframe(3);", True)
        End If
    End Sub


    Protected Sub btnSetValueLicense_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetValueLicense.Click
        genCarDriver()
    End Sub

    Protected Sub BtnAddLicense_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddLicense.Click
        Dim lbllicense_id As Integer = 0
        If HidValueLicense.Value <> "" Then
            lbllicense_id = HidValueLicense.Value
        Else

        End If
        If lbllicense_id > 0 Then

            HidValueLicense.Value = ""

            Dim dbconnect As New DBConnect
            Dim Datatable As DataTable = dbconnect.TableCommand

            Dim con As Npgsql.NpgsqlConnection = dbconnect.getConnection
            Dim cmd As New Npgsql.NpgsqlCommand
            Try
                con.Open()
                cmd.Connection = con


                Dim old_group_id As Integer = 0
                Dim cancel_license_id As Integer = 0
                Dim checkin_id As Integer = 0
                Dim checkout_id As Integer = 0
                Dim admin_id As Integer = 0
                Try
                    cancel_license_id = dbconnect.executeScalar("select status_id from license where license_id = " & lbllicense_id)

                    'old_group_id = dbconnect.executeScalar("select old_group_id from travel_group where group_id = " & group_id)
                    Dim dtGroups As DataTable = dbconnect.getDataTable("select old_group_id , checkin_id , checkout_id , admin_id from travel_group where group_id = " & group_id, "group")
                    Dim drG As DataRow = dtGroups.Rows(0)
                    If Not drG("old_group_id") Is DBNull.Value Then
                        old_group_id = drG("old_group_id")
                    End If
                    If Not drG("checkin_id") Is DBNull.Value Then
                        checkin_id = drG("checkin_id")
                    End If
                    If Not drG("checkout_id") Is DBNull.Value Then
                        checkout_id = drG("checkout_id")
                    End If
                    If Not drG("admin_id") Is DBNull.Value Then
                        admin_id = drG("admin_id")
                    End If
                Catch ex As Exception

                End Try
                If (old_group_id > 0) Or (cancel_license_id = 4 Or cancel_license_id = 5 Or cancel_license_id = 7 Or cancel_license_id = 8 Or cancel_license_id = 9) Then
                   
                    cmd.CommandText = "INSERT INTO car ( owner_name, owner_idcard, owner_address, owner_tel , owner_lastname , owner_province , owner_zipcode , owner_country " & _
                        " , brands , model , colors , seat , weight , car_no , country_car , typecar_id  ,  province_car , plate , engine_no , engine_cap , authorize_car , regis_photo , platelocal ) " & _
                        " select owner_name, owner_idcard, owner_address, owner_tel , owner_lastname , owner_province , owner_zipcode , owner_country " & _
                        " , brands , model , colors , seat , weight , car_no , country_car , typecar_id  ,  province_car , plate , engine_no , engine_cap , authorize_car , regis_photo , platelocal " & _
                        " from car where car_id = (select car_id from license where license_id = " & lbllicense_id & " ) " & _
                        " RETURNING car_id ;"
                    Dim car_id As Object = cmd.ExecuteScalar()

                    cmd.CommandText = "Insert Into car_pic ( car_id , file_name , imgtype) " & _
                    " select " & car_id & " as car_id , file_name , imgtype from car_pic where car_id = (select car_id from license where license_id = " & lbllicense_id & " )"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Insert Into car_cer ( car_id , file_name ) " & _
                    " select " & car_id & " as car_id , file_name from car_cer where car_id = (select car_id from license where license_id = " & lbllicense_id & " )"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Insert Into car_inspec ( car_id , file_name )  " & _
                    " select " & car_id & " as car_id , file_name from car_inspec where car_id = (select car_id from license where license_id = " & lbllicense_id & " )"
                    cmd.ExecuteNonQuery()

                    ' คนขับรถ
                    cmd.CommandText = "Insert Into driver ( prename , address , name , surname , license_expire , national , countries , gender " & _
                    " , passport_photo , licensedriver_photo , idcard_no , county , zipcode , tel , email , birthday , passport_no , passport_expire , photo_cer ) " & _
                    " select prename , address , name , surname , license_expire , national , countries , gender " & _
                    " , passport_photo , licensedriver_photo , idcard_no , county , zipcode , tel , email , birthday , passport_no , passport_expire , photo_cer " & _
                    " from driver where driver_id = (select driver_id from license where license_id = " & lbllicense_id & " )  " & _
                    " RETURNING driver_id ; "
                    Dim driver_id As Object = cmd.ExecuteScalar()

                    ' คนขับสำรองคนที่ 1 / คนขับสำรองคนที่ 2
                    cmd.CommandText = "Insert Into spare_driver (prename , name , surname , license_no , national , driver_id , passport_no , passport_expire , spare_ord " & _
                                      ", licensedriver_photo , address , state , country , zipcode , tel , email , gender , license_exp_date , passport_photo , photo_cer " & _
                                      ") " & _
                                      "select prename , name , surname , license_no , national , driver_id , passport_no , passport_expire , spare_ord " & _
                                      ", licensedriver_photo , address , state , country , zipcode , tel , email , gender , license_exp_date , passport_photo , photo_cer from spare_driver " & _
                                      " where sparedriver_id = ( select sparedriver_id from spare_driver where driver_id = " & driver_id & ")"
                    cmd.ExecuteNonQuery()

                    'ตาราง act
                    If cancel_license_id = 4 Or cancel_license_id = 5 Or cancel_license_id = 7 Or cancel_license_id = 8 Or cancel_license_id = 9 Then
                        cmd.CommandText = " Insert Into act (act_no , act_name , act_tankno , act_start , act_ends , act_photo , act_company , act_no2 " & _
                        " , act_name2 , act_start2 , act_photo2 , act_company2 , act_ends2 ) " & _
                        " select act_no , act_name , act_tankno , act_start , act_ends , act_photo , act_company , act_no2 " & _
                        " , act_name2 , act_start2 , act_photo2 , act_company2 , act_ends2 " & _
                        " from act where act_id = ( select act_id from license where license_id = " & lbllicense_id & " ) RETURNING act_id ;"
                    Else
                        cmd.CommandText = " Insert Into act (act_no , act_name , act_tankno , act_start , act_ends , act_photo , act_company , act_no2 " & _
                        " , act_name2 , act_start2 , act_photo2 , act_company2 , act_ends2 ) " & _
                        " values( null , null , null , null , null , null , null , null " & _
                        " , null , null , null , null , null  ) RETURNING act_id ;"
                    End If
                    Dim act_id As Object = cmd.ExecuteScalar()


                    HidExpire.Value = dbconnect.executeScalar("select exp_date from travel_group where group_id = " & group_id)

                    If cancel_license_id = 4 Or cancel_license_id = 5 Or cancel_license_id = 7 Or cancel_license_id = 8 Or cancel_license_id = 9 Then
                        cmd.CommandText = "Insert Into license ( driver_id , car_id , act_id , typeuser_id , travel_id , regis_date , fname , lname , email , exp_date , copy_license_id ) " & _
                           " select " & driver_id & " as driver_id , " & car_id & " as car_id , " & act_id & " as act_id , typeuser_id , travel_id , regis_date , fname , lname , email , '" & HidExpire.Value & "' , " & lbllicense_id & " " & _
                           " from license  where license_id = " & lbllicense_id & _
                           " RETURNING license_id ;"
                    Else
                        cmd.CommandText = "Insert Into license ( driver_id , car_id , act_id , typeuser_id , travel_id , regis_date , fname , lname , email , exp_date ) " & _
                       " select " & driver_id & " as driver_id , " & car_id & " as car_id , " & act_id & " as act_id , typeuser_id , travel_id , regis_date , fname , lname , email , '" & HidExpire.Value & "' " & _
                       " from license  where license_id = " & lbllicense_id & _
                       " RETURNING license_id ;"
                    End If

                    Dim license_id As Object = cmd.ExecuteScalar()


                    Dim sqlInsert As String = "INSERT INTO travel_group_car( group_id, license_id) VALUES (:group_id, :license_id)"
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = sqlInsert
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id
                    cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = license_id
                    cmd.ExecuteNonQuery()

                    Datatable.Rows.Clear()
                    Datatable.Rows.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer, checkin_id) 'ddlBorderCheckin.SelectedValue)
                    Datatable.Rows.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer, checkout_id) ' ddlBorderCheckin.SelectedValue)
                    Datatable.Rows.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer, admin_id) 'ddladmin.SelectedValue)
                    Dim tableinsert = dbconnect.UpdateDataTable(Datatable, "license", "WHERE license_id = " & license_id)



                    Dim sqlUpdate As String = "Update license set  token=:token , regis_date=:regis_date , exp_date =:exp_date WHERE license_id = " & license_id
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = sqlUpdate
                    cmd.Parameters.Clear()
                    Dim pToken As Object = dbconnect.Token(license_id, car_id)
                    cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pToken
                    cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
                    cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = HidExpire.Value 'txtExpire.Text
                    cmd.ExecuteNonQuery()
                Else


                    Dim sqlInsert As String = "INSERT INTO travel_group_car( group_id, license_id) VALUES (:group_id, :license_id)"
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = sqlInsert
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id
                    cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = lbllicense_id
                    cmd.ExecuteNonQuery()

                    Datatable.Rows.Clear()
                    Datatable.Rows.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer, checkin_id) 'ddlBorderCheckin.SelectedValue)
                    Datatable.Rows.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer, checkout_id) 'ddlBorderCheckin.SelectedValue)
                    Datatable.Rows.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer, admin_id) 'ddladmin.SelectedValue)
                    Dim tableinsert = dbconnect.UpdateDataTable(Datatable, "license", "WHERE license_id = " & lbllicense_id)
                End If

              
                Response.Redirect(Request.RawUrl)
            Catch ex As Exception

            Finally
                dbconnect = Nothing
                cmd.Connection.Close()
                con.Close()
                cmd.Dispose()
                con.Dispose()
            End Try
        Else
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Find Existing Application!!!');", True)
        End If
    End Sub

    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblgid As Label = e.Row.Cells(0).FindControl("lblgid")
            Dim lnkDel As HyperLink = e.Row.Cells(9).FindControl("HyperLinkDel")
            lnkDel.Attributes.Add("onclick", "javascript:DelData(" & lblgid.Text & ");")
            If Hidstatus.Value = "2" Then
              
                lnkDel.Visible = False
            End If


            Dim Labelstatus As Label = e.Row.Cells(0).FindControl("Labelstatus")
            Dim status As HiddenField = e.Row.Cells(0).FindControl("Hidstatus")
            If status.Value = "1" Then

            Else
             
                Labelstatus.Text = Labelstatus.Text.Replace("fa-check", "fa-asterisk")
                Labelstatus.ForeColor = Drawing.Color.Red
            End If

            Dim lnkEdit As HyperLink = e.Row.Cells(0).FindControl("HyperEdit")
            lnkEdit.Attributes.Add("onclick", "javascript:window.parent.tab_Redirect('" & lnkEdit.NavigateUrl & "');")
            lnkEdit.NavigateUrl = "#"

            Dim lnkEdit2 As HyperLink = e.Row.Cells(0).FindControl("HyperEdit2")
         
            Dim lnkInsurance As HyperLink = e.Row.Cells(0).FindControl("HyperInsurance")
            lnkInsurance.Attributes.Add("onclick", "javascript:window.parent.tab_Redirect('" & lnkInsurance.NavigateUrl & "');")
            lnkInsurance.NavigateUrl = "#"

          
            If e.Row.Cells(6).Text = "&nbsp;" Then
                e.Row.Cells(6).Text = "Draft<br/>(แบบร่าง)"
            ElseIf e.Row.Cells(6).Text.Contains("Incomplete") Then
                Dim lblis_edit_user As Label = e.Row.Cells(0).FindControl("lblis_edit_user")
                If lblis_edit_user.Text = "1" Then
                    e.Row.Cells(6).Text = "Incomplete<br/>(ไม่สมบูรณ์) *แก้ไขแล้ว"
                Else
                    e.Row.Cells(6).Text = "Incomplete<br/>(ไม่สมบูรณ์)"
                End If
            ElseIf e.Row.Cells(6).Text.Contains("Expire Date") Or e.Row.Cells(6).Text.Contains("Fail") Then
                e.Row.Cells(6).Text = e.Row.Cells(6).Text.ToString.Replace("ไม่สำเร็จ (", "").ToString.Replace("))", ")")
                lnkEdit.Visible = False
                lnkDel.Visible = False
                lnkInsurance.Visible = False
                lnkEdit2.Visible = False
            ElseIf e.Row.Cells(6).Text.Contains("Cancel") Then
                e.Row.Cells(6).Text = "Rejected<br/>(ยกเลิกใบอนุญาต)"
                lnkEdit.Visible = False
                lnkDel.Visible = False
                lnkInsurance.Visible = False
                lnkEdit2.Visible = False
            Else
                e.Row.Cells(6).Text = "Pending<br/>(กำลังดำเนินการ)"
                lnkEdit.Visible = False
                lnkDel.Visible = False
                lnkInsurance.Visible = False
                lnkEdit2.Visible = False
            End If

            If Labelstatus.ForeColor = Drawing.Color.Red Then
                lnkDel.Visible = True
                'btnNext3.Enabled = False
                Hidduplicate.Value = "1"
                btnNext3.ToolTip = "Vehicle have duplicate group tour"
            End If



        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter

        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(1).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(9).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(10).Attributes.Add("data-breakpoints", "xs")
            
        End If


        If is_renew = 0 Then
            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(8).Visible = False
                e.Row.Cells(9).Visible = False
            End If
        Else
            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(10).Visible = False
            End If
        End If
    End Sub

    Private Function CheckRepeat(ByVal license_id As Integer, ByVal start_date As Date, ByVal exp_date As Date) As Boolean
        Dim IsRepeat As Boolean = False


        Dim dtCar As New DataTable
        Dim db As New DBConnect
        Try
            dtCar = db.getDataTable(" SELECT start_date , exp_date FROM  travel_group_car LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id  " & _
                                    " where license_id = " & license_id, "carr")
        Catch ex As Exception

        Finally
            db = Nothing
        End Try
        For Each dr As DataRow In dtCar.Rows
            Dim s As Date = dr("start_date")
            Dim e As Date = dr("exp_date")
            IsRepeat = True
        Next

        Return IsRepeat
    End Function

    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = DBConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.Parameters.Clear()
            cmd.CommandText = " delete from travel_group_car where gid = " & HidDel_ID.Value
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Try
        
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
