Imports System.Data
Imports System.IO
Imports Npgsql

Partial Class Travel_GroupAdd_tab3
    Inherits System.Web.UI.Page
    Private Send As New SendEmail
    Private PopulateS As New PopulateScript
    Private group_id As String
    Dim cnt_car As Integer
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
        End If
        If PopulateS.IsMobile Then
            IsMobile = True
        End If
        If Page.IsPostBack = False Then
            getGuide()
        End If
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack10", " $('#loadings').hide(); ", True)
    End Sub

    Private Sub genDDLGuide(ByVal ddl As DropDownList, ByVal group_id As Integer)
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            If ddl Is Nothing Then
                Throw New Exception("DropDownList is Nothing.")
            End If

            Dim dt_guide = " select guide_id , CAST(prename ||' ' || guide_name || ' ' || guide_surname as varchar) as guide_name from guide " &
                           " WHERE travel_user_id = " & Session("user_id") & " and guide_id not in (select guide_id from travel_group_guide WHERE group_id = " & group_id & ")"
            Dt = db.getDataTable(dt_guide, "Data")

            ddl.Items.Clear()
            If Dt.Rows.Count > 0 Then
                ddl.DataSource = Dt
                ddl.DataTextField = "guide_name"
                ddl.DataValueField = "guide_id"
                ddl.DataBind()
                ddl.SelectedIndex = 0
                ddl.Attributes.Add("data-inline", "true")
            Else

            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)

        Finally
            db = Nothing
        End Try

    End Sub

    Private Sub getGuide()
        Dim db As New DBConnect
        Try
         
            Dim dtGuide As DataTable = db.getDataTable(" select Row_number() over (order by guide.guide_id nulls last) as number , " & _
                                     " travel_group_guide.gid , guide.guide_id , CAST(prename ||' ' || guide_name || ' ' || guide_surname as varchar) " & _
                                     "  as guide_name ,  guide_tel , guide_idcard , ( " & _
                                     "   SELECT count(*) from travel_group_guide as a " & _
                                     "      LEFT JOIN travel_group as b on a.group_id = b.group_id " & _
                                     "      WHERE(guide_id = guide.guide_id) " & _
                                     "      and a.group_id not in (select group_id from travel_group_car where license_id in (select license_id from license where status_id in (4,7,8,9) )) " & _
                                     "      and ((start_date >= travel_group.start_date And exp_date <= travel_group.exp_date) or (start_date <= travel_group.exp_date  and exp_date >= travel_group.start_date)) " & _
                                     "  ) as status , " & _
                                     "    regis_no , regis_photo from guide  " & _
                                     "    INNER JOIN travel_group_guide on guide.guide_id = travel_group_guide.guide_id  " & _
                                     "    LEFT JOIN travel_group on travel_group.group_id = travel_group_guide.group_id " & _
                                     "    WHERE travel_group.group_id = " & group_id, "guide")
            PopulateS.SetGrid_Footable(gvMain_guide, dtGuide)
            UpdGrid_guide.Update()


            Dim dtCar As DataTable = db.getDataTable("select Row_number() over (order by travel_group_car.gid nulls last) as number , travel_group_car.gid , plate , country_car , type_name , dt.status " & _
                " , CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name " & _
                " , travel_group.start_date , travel_group.exp_date , travel_group_car.license_id , is_renew " & _
                " , CAST('MgtEdit.aspx?token=' || license.token || '&is_renew=' || travel_group.is_renew as varchar ) as urlEdit " & _
                " , CAST('MgtEdit.aspx?token=' || license.token || '&is_renew=' || travel_group.is_renew || '&ins=1' as varchar ) as urlIns " & _
                " from travel_group_car LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id  " & _
                " LEFT JOIN license on license.license_id = travel_group_car.license_id  " & _
                " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                " LEFT JOIN car on license.car_id = car.car_id " & _
                " left join type_car on type_car.type_id = car.typecar_id " & _
                " left join (SELECT count(group_id) status , license_id FROM public.travel_group_car group by license_id ) dt on dt.license_id = license.license_id " & _
                " where travel_group_car.group_id = " & group_id, "carr")
            cnt_car = dtCar.Rows.Count


        Catch ex As Exception

        Finally
            db = Nothing
        End Try
        genDDLGuide(ddlGuide, group_id)
        CheckGuide()
    End Sub


    Private Sub CheckGuide()
        If cnt_car <= 5 Then
            'กรณี 1-5 คัน ใช้ไกด์ 1 คน
            If gvMain_guide.Rows.Count = 1 Then
                ddlGuide.Visible = False
                BtnAddGuide.Visible = False
            Else
                ddlGuide.Visible = True
                BtnAddGuide.Visible = True
            End If

        ElseIf cnt_car <= 15 Then
            'กรณี 6-15 คัน ใช้ไกด์ 2 คน
            If gvMain_guide.Rows.Count = 2 Then
                ddlGuide.Visible = False
                BtnAddGuide.Visible = False
            Else
                ddlGuide.Visible = True
                BtnAddGuide.Visible = True
            End If
        Else
            If gvMain_guide.Rows.Count = 3 Then
                ddlGuide.Visible = False
                BtnAddGuide.Visible = False
            Else
                ddlGuide.Visible = True
                BtnAddGuide.Visible = True
            End If
            'กรณี 16ขึ้นไป ใช้ไกด์ 3 คน

        End If

        divGuide1.Visible = BtnAddGuide.Visible
        divGuide2.Visible = BtnAddGuide.Visible
        divGuide3.Visible = BtnAddGuide.Visible
        divGuide4.Visible = BtnAddGuide.Visible
    End Sub

    Protected Sub btnPrev2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev2.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "window.parent.tab_activeIframe(2);", True)
    End Sub

    Dim fPathGuide As String = Server.MapPath(ConfigurationManager.AppSettings("FileGuide"))
    Protected Sub btnUploadAct_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnUploadAct.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload5.PostedFile.FileName <> "" Then
            If FileUpload5.HasFile Then
                srcName = Path.GetFileName(FileUpload5.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload5.PostedFile.FileName)
                srcName = "regis" & (srcName & DateTime.Now).GetHashCode
                FileUpload5.PostedFile.SaveAs(Server.MapPath("~/Upload/FileGuide/") + srcName & srcExt)
                hidPhotoAct.Value = srcName & srcExt
                PhotoAct.ImageUrl = "~/Upload/FileGuide/" & hidPhotoAct.Value
                PhotoAct.Visible = True
                btnUploadAct.Visible = False
                FileUpload5.CssClass = "w3-hide"
                PhotoDeleteAct.Visible = True
            End If
        End If
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "window.parent.tab_activeIframe(3);", True)
    End Sub

    Protected Sub PhotoDeleteAct_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles PhotoDeleteAct.Click
        If File.Exists(fPathGuide & hidPhotoAct.Value) Then
            File.Delete(fPathGuide & hidPhotoAct.Value)
        End If
        btnUploadAct.Visible = True
        FileUpload5.Visible = True
        FileUpload5.CssClass = "w3-show"
        hidPhotoAct.Value = ""
        PhotoAct.Visible = False
        PhotoDeleteAct.Visible = False
    End Sub

    Protected Sub BtnAddGuide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddGuide.Click
        Dim dbconnect As New DBConnect
        Dim Datatable As DataTable = dbconnect.TableCommand

        Dim con As Npgsql.NpgsqlConnection = dbconnect.getConnection
        Dim cmd As New Npgsql.NpgsqlCommand
        If hidPhotoAct.Value = "" Then
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "alert('Plese Select Registration Photo ');tab3();", True)
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Plese Select Registration Photo ');window.parent.tab_activeIframe(3);", True)
        Else

            Try
                con.Open()
                cmd.Connection = con

                Dim sqlInsert As String = "INSERT INTO travel_group_guide( group_id, guide_id , regis_no , regis_photo) VALUES (:group_id, :guide_id , :regis_no , :regis_photo) "
                cmd.CommandText = CommandType.Text
                cmd.CommandText = sqlInsert
                cmd.Parameters.Clear()
                'cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id
                Dim groupIdInt As Integer
                If Not Integer.TryParse(group_id, groupIdInt) Then
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('รหัสกลุ่มไม่ถูกต้อง');window.parent.tab_activeIframe(3);", True)
                    Exit Sub
                End If
                cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = groupIdInt

                Dim guideId As Integer
                If Integer.TryParse(ddlGuide.SelectedValue, guideId) Then
                    cmd.Parameters.Add("guide_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = guideId
                Else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('รหัสไกด์ไม่ถูกต้อง');window.parent.tab_activeIframe(3);", True)
                    Exit Sub
                End If

                'cmd.Parameters.Add("guide_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlGuide.SelectedValue
                cmd.Parameters.Add("regis_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregis_no.Text
                cmd.Parameters.Add("regis_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoAct.Value
                cmd.ExecuteNonQuery()
            Catch ex As Exception

                Console.WriteLine(ex.Message)
            Finally
                cmd.Connection.Close()
                con.Close()
                cmd.Dispose()
                con.Dispose()
            End Try
            'getGuide()
            Response.Redirect(Request.RawUrl)
        End If


       
    End Sub


    Protected Sub gvMain_guide_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain_guide.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblgid As Label = e.Row.Cells(0).FindControl("lblgid")
            Dim lblguide_id As Label = e.Row.Cells(0).FindControl("lblguide_id")
            Dim lnkDel As HyperLink = e.Row.Cells(0).FindControl("HyperLinkDel_guide")
            Dim Labelstatus As Label = e.Row.Cells(0).FindControl("Labelstatus_guide")
            Dim status As HiddenField = e.Row.Cells(0).FindControl("Hidstatus_guide")
            lnkDel.Attributes.Add("onclick", "javascript:DelData2(" & lblgid.Text & ");")
            If status.Value < 2 Then
                checkerr.Value = 0
            Else
                checkerr.Value = 1
                Labelstatus.Text = Labelstatus.Text.Replace("fa-check", "fa-asterisk")
                Labelstatus.ForeColor = Drawing.Color.Red
            End If

            If Hidstatus.Value = "2" Then
                If Hidchecktab_0.Value = "0" Then
                    lnkDel.Visible = True
                Else
                    lnkDel.Visible = False
                End If
            End If

            Dim lblregis_photo As Label = e.Row.Cells(0).FindControl("lblregis_photo")
            Dim Imgregis As Image = e.Row.Cells(0).FindControl("Imgregis")
            If lblregis_photo.Text = "" Then
                Imgregis.Visible = False
            Else
                Imgregis.ImageUrl = "~/Upload/FileGuide/" & lblregis_photo.Text
                Imgregis.Visible = True
            End If

            If IsMobile Then
                Imgregis.Width = Unit.Pixel(140)
            End If
        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(1).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
        End If
    End Sub

    Protected Sub BtnDelete_guide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete_guide.Click
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = DBConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.Parameters.Clear()
            cmd.CommandText = " delete from travel_group_guide where gid = " & HidDelGuide_id.Value
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Try
        'getGuide()
        Response.Redirect(Request.RawUrl)
        'Response.Redirect("GroupAdd.aspx?id=" & group_id & "&tab=3&is_renew=")
        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "window.parent.tab_activeIframe(3);", True)
    End Sub


    Private Function CheckInsurance() As Boolean
        Dim chk As Boolean = False

        Dim db As New DBConnect
        Dim str As String = " select count(*) from act where act_no is null and act_id in (select act_id from license  " & _
            " LEFT JOIN  travel_group_car on license.license_id = travel_group_car.license_id " & _
            " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
            " where travel_group.group_id = " & group_id & " ) "

        If db.executeScalar(str) = 0 Then
            chk = True
        End If

        Return chk
    End Function

    Protected Sub btnNext3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext3.Click
        'getCarLicense()
        getGuide()

        CheckGuide()
        If CheckInsurance() Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab3();", True)
        Else
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", " alert('Please Fill Insurance information !!!');tab2();", True)
        End If

    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If checkerr.Value = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "AlertSubmit2();", True)
            btnNext3_Click(e, e)
        Else
            If checkerr.Value = 1 Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "AlertSubmit();", True)
                btnNext3_Click(e, e)
            Else
                'Dim group_id = Request.QueryString("id")
                getGuide()
                If cnt_car <= 5 AndAlso gvMain_guide.Rows.Count < 1 Then
                    'กรณี 1-5 คัน ใช้ไกด์ 1 คน
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "AlertSubmit2();", True)
                    btnNext3_Click(e, e)
                ElseIf (cnt_car > 5 And cnt_car <= 15) AndAlso gvMain_guide.Rows.Count < 2 Then
                    'กรณี 6-15 คัน ใช้ไกด์ 2 คน
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "AlertSubmit2();", True)
                    btnNext3_Click(e, e)
                ElseIf (cnt_car > 15) AndAlso gvMain_guide.Rows.Count < 3 Then
                    'กรณี 16ขึ้นไป ใช้ไกด์ 3 คน
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "AlertSubmit2();", True)
                    btnNext3_Click(e, e)
                Else
                    Dim dbconect As New DBConnect
                    Dim tablecommand As DataTable = dbconect.TableCommand
                    'Dim datatableGroup = dbconect.getDataTable("select license.license_id , license.token , license.fname , license.lname , license.email from travel_group_car LEFT JOIN license on license.license_id = travel_group_car.license_id WHERE (license.status_id is null or license.status_id not in (1,3,4)) and travel_group_car.group_id = " & group_id, "license_group")
                    Dim strGroup As String = "select license.license_id , license.token , license.fname , license.lname , license.email, user_travel.email as travelEmail, CAST(user_travel.user_name || ' ' || user_travel.user_surname as varchar) as agen_name" & _
                        ", car.plate, car.country_car, name_company, company_license, coalesce(license.regis_no,'') as regis_no from travel_group_car " & _
                        " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                        " LEFT JOIN license on license.license_id = travel_group_car.license_id " & _
                        " LEFT JOIN car on car.car_id = license.car_id " & _
                        " LEFT JOIN user_travel on user_travel.user_id = travel_group.user_id " & _
                        " WHERE (license.status_id is null or license.status_id not in (1,3,4)) and travel_group_car.group_id = " & group_id

                    Dim datatableGroup = dbconect.getDataTable(strGroup, "license_group")
                    Dim admin_id As Integer = 0
                    Try
                        Dim dtGroups As DataTable = dbconect.getDataTable("select old_group_id , checkin_id , checkout_id , admin_id from travel_group where group_id = " & group_id, "group")
                        Dim drG As DataRow = dtGroups.Rows(0)
                        If Not drG("admin_id") Is DBNull.Value Then
                            admin_id = drG("admin_id")
                        End If
                    Catch ex As Exception

                    End Try
                    For Each i In datatableGroup.Rows
                        tablecommand.Clear()
                        tablecommand.Rows.Add("status_id", NpgsqlTypes.NpgsqlDbType.Integer, 0)
                        tablecommand.Rows.Add("regis_no", NpgsqlTypes.NpgsqlDbType.Varchar, IIf(i("regis_no").ToString().Trim = "", DBConnect.RegisterNo(), i("regis_no").ToString()))
                        tablecommand.Rows.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Varchar, admin_id)
                        tablecommand.Rows.Add("is_edit_user", NpgsqlTypes.NpgsqlDbType.Integer, 0)
                        Dim tableUpdate = dbconect.UpdateDataTable(tablecommand, "license", "WHERE license_id = " & i("license_id").ToString())

                        Try

                            'ส่งให้ผปก.
                            Send.Email(i("travelEmail").ToString(), i("agen_name").ToString(), i("token").ToString(), i("plate").ToString(), i("country_car").ToString(), i("name_company").ToString(), i("company_license").ToString(), 1)
                            'ส่งให้นทท.
                            Send.Email(i("email").ToString(), i("fname").ToString() & " " & i("lname").ToString(), i("token").ToString(), i("plate").ToString(), i("country_car").ToString(), i("name_company").ToString(), i("company_license").ToString(), 2)
                        Catch ex As Exception

                        End Try
                    Next
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "window.parent.tab_activeIframe(0);", True)
                End If
            End If

        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "window.parent.tab_activeIframe(0);", True)
    End Sub
End Class
