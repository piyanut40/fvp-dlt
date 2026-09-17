Imports System.Data
Imports Npgsql
Partial Class Admin_arrival
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected _year As String
    Protected text As String
    Protected name As String
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _year = Now.Year()
        If IsPostBack = False Then
            If Session("user_id") = Nothing Then
                Response.Redirect("../Login.aspx")
            Else
                Populate.genDDLBudyear(ddlYear, 0, "ปีทั้งหมด")
                Populate.genAdminNames(ddladmin, "สนง.ขนส่งทั้งหมด")
                Populate.genDDLCountry(ddlCountry, "ประเทศรถทั้งหมด")
                If PopulateS.IsMobile Then
                    Css = ""
                End If
                If Request.QueryString("rt") = 1 Then

                    text = "รถประจำถิ่นที่ได้รับอนุญาติเข้ามาในราชอาณาจักร"
                    name = "ชื่อผู้ใช้รถ"
                    Populate.genPageSize(ddl_PageSize)
                    ddl_PageSize.SelectedValue = 10
                    loadData()
                    'licenseNo()
                ElseIf Request.QueryString("rt") = 2 Then
                    text = "รถท่องเที่ยวที่ได้รับอนุญาติเข้ามาในราชอาณาจักร"
                    name = "ชื่อผู้ใช้รถ"
                    Populate.genPageSize(ddl_PageSize)
                    ddl_PageSize.SelectedValue = 10

                    loadData()
                    If Request.QueryString("cancel") = 1 Then
                        text = "รายการยกเลิกเครื่องหมายแสดงการใช้รถ"
                    ElseIf Request.QueryString("fail") = 1 Then
                        text = "รายการขออนุญาตที่ไม่สำเร็จ"
                        ddlYear.Visible = False

                    ElseIf Request.QueryString("st") = 1 Then
                        ddlYear.Visible = False
                        'BtnDelete.Visible = True
                    End If
                    If Session("admin_id") <> "" Then
                        ddladmin.SelectedValue = Session("admin_id")
                        ddladmin.Attributes.Add("disabled", "true")
                    End If
                ElseIf Request.QueryString("rt") = 3 Then
                    text = "รถตามความตกลงประเทศลาวที่ได้รับอนุญาติเข้ามาในราชอาณาจักร"
                    name = "ชื่อผู้ใช้รถ"
                    Populate.genPageSize(ddl_PageSize)
                    ddl_PageSize.SelectedValue = 10
                    loadData()
                ElseIf Request.QueryString("rt") = 4 Then
                    text = "รถตามความตกลงระหว่างประเทศรถยนต์ส่วนบุคคล ของประเทศมาเลเซีย และสิงคโปร์ที่ได้รับอนุญาติเข้ามาในราชอาณาจักร"
                    name = "ชื่อผู้ใช้รถ"
                    Populate.genPageSize(ddl_PageSize)
                    ddl_PageSize.SelectedValue = 10
                    loadData()

                Else
                    text = "รถขนส่งเชิงพาณิชย์ที่ได้รับอนุญาติเข้ามาในราชอาณาจักร"
                    name = "ชื่อบริษัท"
                    Populate.genPageSize(ddl_PageSize)
                    ddl_PageSize.SelectedValue = 10
                    loadData()
                    pnCommerce.Visible = True
                    'licenseNo()

                End If
                If Request.QueryString("all") = 1 Then
                    text = text & " (ทั่วประเทศ)"
                    ddladmin.Visible = True
                    ddladmin.SelectedIndex = 0
                    ddladmin.Attributes.Remove("disabled")
                End If
            End If
        End If

    End Sub

    Private Sub loadData()
        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dt As DataTable
        Dim strsql As String = ""
        Try

            Dim admin_id As String = "travel_group.admin_id" 

            If Request.QueryString("rt") <> 5 Then
               
                If Request.QueryString("cancel") = 1 Then

                    strsql = "SELECT Row_number() over (order by SUBSTR(cast (license_no as text), 11,4) desc ,license_no desc nulls last) as number,* FROM ( SELECT license.license_no , admin.admin_id , license.license_id , plate , country_car , token ,CAST(case when prename = 'Other' then '' else prename end || ' ' || name || ' ' || surname as varchar) as name, '' as vehicle_type " & _
                        " , type_name as typecar_en, brands, model as models, status_th , CAST('LicenseDtl.aspx?rt=" & Request.QueryString("rt") & "&token=' || token as varchar ) as urlDoc,typeuser_id,license.status_id " & _
                        " , CAST('~/Report/Qrcode.aspx?token=' || token as varchar ) as urlcode, license.qrcode as urlqrcode, CAST('~/Sign.aspx?token=' || token || '&typeuser=' || typeuser_id as varchar ) as urlSign " & _
                        " , CAST('~/Document.aspx?print=1&token=' || token as varchar ) as urlPDF , cancel_date, travel_group.start_date, travel_group.exp_date, license.receipt_date " & _
                        " ,(select CASE when license.status_id = 5 THEN count(*) + 1 ELSE count(*) + 0 END from receipt WHERE receipt.license_id = license.license_id) as count, old_group_id, receipt " & _
                        " FROM license " & _
                        " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                        " LEFT JOIN car on car.car_id = license.car_id " & _
                        " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
                        " LEFT JOIN status on license.status_id = status.status_id " & _
                        " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
                        " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                        " LEFT JOIN admin on " & admin_id & " = admin.admin_id " & _
                        " LEFT JOIN province on admin.prov_code = province.prov_code " & _
                        " WHERE license.status_id in (4) and typeuser_id = " & Request.QueryString("rt") & " "
                ElseIf Request.QueryString("fail") = 1 Then

                    Dim status_th As String = " status.status_th "
                    strsql = "SELECT Row_number() over (order by  cancel_date desc nulls first , license_no desc nulls last ) as number,* FROM ( SELECT license.license_no , admin.admin_id , license.license_id , plate , country_car , token ,CAST(case when prename = 'Other' then '' else prename end || ' ' || name || ' ' || surname as varchar) as name, '' as vehicle_type " & _
                      " , type_name as typecar_en, brands, model as models, " & status_th & "  as status_th, CAST('LicenseDtl.aspx?rt=" & Request.QueryString("rt") & "&token=' || token as varchar ) as urlDoc,typeuser_id,license.status_id " & _
                      " , CAST('~/Report/Qrcode.aspx?token=' || token as varchar ) as urlcode, license.qrcode as urlqrcode, CAST('~/Sign.aspx?token=' || token || '&typeuser=' || typeuser_id as varchar ) as urlSign " & _
                      " , CAST('~/Document.aspx?print=1&token=' || token as varchar ) as urlPDF , cancel_date, travel_group.start_date, travel_group.exp_date, license.receipt_date " & _
                      " ,(select CASE when license.status_id = 5 THEN count(*) + 1 ELSE count(*) + 0 END from receipt WHERE receipt.license_id = license.license_id) as count, old_group_id, receipt " & _
                      " FROM license " & _
                      " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                      " LEFT JOIN car on car.car_id = license.car_id " & _
                      " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
                      " LEFT JOIN status on license.status_id = status.status_id " & _
                      " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
                      " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                      " LEFT JOIN admin on " & admin_id & " = admin.admin_id " & _
                      " LEFT JOIN province on admin.prov_code = province.prov_code " & _
                      " WHERE license.status_id in (2,7,8,9) and typeuser_id = " & Request.QueryString("rt") & " "
                Else
                    strsql = "SELECT Row_number() over (order by SUBSTR(cast (license_no as text), 11,4) desc ,license_no desc nulls last) as number,* FROM ( SELECT license.license_no , admin.admin_id , license.license_id , plate , country_car , token ,CAST(case when prename = 'Other' then '' else prename end || ' ' || name || ' ' || surname as varchar) as name, '' as vehicle_type " & _
                                " , type_name as typecar_en, brands, model as models, status_th , CAST('LicenseDtl.aspx?rt=" & Request.QueryString("rt") & "&token=' || token as varchar ) as urlDoc,typeuser_id,license.status_id " & _
                                " , CAST('~/Report/Qrcode.aspx?token=' || token as varchar ) as urlcode, license.qrcode as urlqrcode, CAST('~/Sign.aspx?token=' || token || '&typeuser=' || typeuser_id as varchar ) as urlSign " & _
                                " , CAST('~/Document.aspx?print=1&token=' || token as varchar ) as urlPDF , cancel_date, travel_group.start_date, travel_group.exp_date, license.receipt_date " & _
                                " ,(select CASE when license.status_id = 5 THEN count(*) + 1 ELSE count(*) + 0 END from receipt WHERE receipt.license_id = license.license_id) as count, old_group_id, receipt " & _
                                " FROM license " & _
                                " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                                " LEFT JOIN car on car.car_id = license.car_id " & _
                                " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
                                " LEFT JOIN status on license.status_id = status.status_id " & _
                                " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
                                " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                                " LEFT JOIN admin on " & admin_id & " = admin.admin_id " & _
                                " LEFT JOIN province on admin.prov_code = province.prov_code " & _
                                " WHERE license.status_id in (1,3,5) and typeuser_id = " & Request.QueryString("rt") & " "

                End If
                If Request.QueryString("st") = 1 Then
                    strsql = strsql & "and license.status_id in (1,3) and typeuser_id = 2 AND license.regis_date >= CURRENT_DATE - INTERVAL '30 days'"
                ElseIf Request.QueryString("st") = 2 Then
                    strsql = strsql & "and license.status_id = 5"
                End If




            Else

                strsql = "SELECT Row_number() over (order by SUBSTR(cast (license_no as text), 11,4) desc ,license_no desc nulls last) as number,* FROM ( SELECT  license.license_no , license_id , registration_no as plate , country_car ,  token , transport_operator_name as name, vehicle_type " & _
                        " , vehicle_category as typecar_en, brand as brands, model as models, status_th , CAST('LicenseDtl.aspx?rt=" & Request.QueryString("rt") & "&token=' || token as varchar ) as urlDoc,typeuser_id,license.status_id " & _
                        " , CAST('~/Report/Qrcode.aspx?token=' || token as varchar ) as urlcode, license.qrcode as urlqrcode, CAST('~/Sign.aspx?token=' || token as varchar ) as urlSign " & _
                        " , CAST('~/Document.aspx?print=1&token=' || token as varchar ) as urlPDF, cancel_date, start_date, exp_date, receipt_date " & _
                        " FROM license " '& _
                '" LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                strsql = strsql & " LEFT JOIN car_commerce car on car.car_id = license.car_id " '& _
                '" LEFT JOIN type_car on car.typecar_id = type_car.typecar_id " & _
                strsql = strsql & " LEFT JOIN status on license.status_id = status.status_id " & _
                       " WHERE typeuser_id = " & Request.QueryString("rt") & "   "



                If ddlstatussearch.SelectedValue = 1 Then
                    strsql = strsql & " and license.status_id = 0  "
                Else
                    strsql = strsql & " and license.status_id = 5  "
                End If

            End If

            strsql = strsql & " order by license_no desc ) as dt where 1=1 "



            If Session("user_id").ToString <> "adminbt" Then
                If Request.QueryString("all") = 1 Then
                    strsql = strsql & ""
                Else
                    strsql = strsql & " and admin_id = " & Session("admin_id") & " "
                End If
            End If

            If txtName.Text <> "" Then
                strsql = strsql & " and LOWER(name) like LOWER('%" & txtName.Text & "%') "
            End If

            If txtplate.Text <> "" Then
                strsql = strsql & " and lower(dt.plate) like lower('%" & txtplate.Text & "%') "
            End If

            If ddlCountry.SelectedIndex > 0 Then
                strsql = strsql & " and dt.country_car = '" & ddlCountry.SelectedItem.Text & "' "
            End If

            If txtlicense_no.Text <> "" Then
                strsql = strsql & "and license_no like '%" & txtlicense_no.Text & "%'"
            End If




            Dim arr_s As Array
            Dim arr_e As Array
            If ddldate.SelectedValue = 1 Then
                If txtstartdate.Text <> "" And txtexpdate.Text <> "" Then
                    arr_s = txtstartdate.Text.Split("/")
                    arr_e = txtexpdate.Text.Split("/")
                    strsql = strsql & " and  receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                Else

                    If txtstartdate.Text <> "" Then
               
                        arr_s = txtstartdate.Text.Split("/")
                        strsql = strsql & " and  receipt_date >= '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "'"
                    End If

                    If txtexpdate.Text <> "" Then
         
                        arr_e = txtexpdate.Text.Split("/")
                        strsql = strsql & " and  receipt_date <= '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                    End If
                End If
            Else
                If txtstartdate.Text <> "" And txtexpdate.Text <> "" Then
                    arr_s = txtstartdate.Text.Split("/")
                    arr_e = txtexpdate.Text.Split("/")
                    strsql = strsql & " and  start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                Else

                    If txtstartdate.Text <> "" Then
        
                        arr_s = txtstartdate.Text.Split("/")
                        strsql = strsql & " and  start_date >= '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "'"
                    End If

                    If txtexpdate.Text <> "" Then
  
                        arr_e = txtexpdate.Text.Split("/")
                        strsql = strsql & " and  start_date <= '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                    End If
                End If
            End If

      
            If ddlYear.SelectedIndex > 0 Then
                strsql = strsql & " and SUBSTR(cast (license_no as text), 11,4) = '" & ddlYear.SelectedValue & "'"
            End If

            If ddladmin.SelectedIndex > 0 Then
                strsql = strsql & " and admin_id = " & ddladmin.SelectedValue
            End If

            If Request.QueryString("fail") = 1 Then
                strsql = strsql & " order by number "
            Else
                'strsql = strsql & " order by license_no desc nulls last"
                strsql = strsql & " order by SUBSTR(cast (license_no as text), 11,4) desc ,license_no desc nulls last "
            End If



            dt = dbConnect.getDataTable(strsql, "local")
            gvMain.DataSource = dt
            gvMain.DataBind()
            UpdGrid.Update()


        Catch ex As Exception
        Finally
            dbConnect = Nothing
            con.Close()
            con.Dispose()

        End Try



    End Sub

    Private RowIndex As Integer = 1

    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        Dim dbconnect As New DBConnect

        Try


            If e.Row.RowType = DataControlRowType.Header Then
                Dim lblstatusid As Label = e.Row.Cells(0).FindControl("lblstatus_id")
                e.Row.TableSection = TableRowSection.TableHeader
                If Request.QueryString("fail") = 1 Then

                Else
                    e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
                End If

                e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(9).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(11).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(12).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(13).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(14).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(16).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(19).Attributes.Add("data-breakpoints", "xs")
                If Request.QueryString("rt") <> 5 Then
                    e.Row.Cells(7).Visible = False
                    e.Row.Cells(9).Visible = False
                Else
                    e.Row.Cells(2).Visible = False
                End If
                e.Row.Cells(3).Text = name

                If Session("user_id") = "adminbt" Then
                    e.Row.Cells(15).Visible = False
                    e.Row.Cells(17).Visible = False
                    e.Row.Cells(18).Visible = False
                End If

                If Request.QueryString("cancel") = 1 Or Request.QueryString("fail") = 1 Then
                    e.Row.Cells(10).Attributes.Add("data-breakpoints", "xs")
                Else
                    e.Row.Cells(20).Visible = False
                End If

                If (Session("user_type").ToString.IndexOf("ขนส่งจังหวัด") > -1 Or Session("user_type") = "0") And Request.QueryString("all") = 1 Then
                    e.Row.Cells(12).Visible = False
                    e.Row.Cells(14).Visible = False
                    e.Row.Cells(15).Visible = False
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                    e.Row.Cells(18).Visible = False
                    e.Row.Cells(19).Visible = False
                End If

            ElseIf e.Row.RowType = DataControlRowType.Pager Then
                e.Row.TableSection = TableRowSection.TableFooter
            Else

                Dim url As String = HttpContext.Current.Request.Url.Host & "/BorderTransport/Documenttoken="

                Dim lnkDel As HyperLink = CType(e.Row.FindControl("HyperLinkDel"), HyperLink)
                Dim lblLicense As Label = CType(e.Row.FindControl("lblLicense"), Label)
                Dim lblToken As Label = CType(e.Row.FindControl("lbltoken"), Label)
                Dim lblold_group_id As Label = CType(e.Row.FindControl("lblold_group_id"), Label)
                Dim lblreceipt_no As Label = CType(e.Row.FindControl("lblreceipt_no"), Label)
                Dim HyperDoc As HyperLink = CType(e.Row.FindControl("HyperPDF"), HyperLink)
                Dim HyperDoc1 As HyperLink = CType(e.Row.FindControl("HyperDoc"), HyperLink)
                Dim HyperSign As HyperLink = CType(e.Row.FindControl("HyperSign"), HyperLink)
                Dim lblstatusid As Label = CType(e.Row.FindControl("lblstatus_id"), Label)
                Dim deltravel As HyperLink = CType(e.Row.FindControl("btnDelete_Command"), HyperLink)

                If lblstatusid IsNot Nothing Then
                    System.Diagnostics.Debug.WriteLine("lblstatusid.Text: " & lblstatusid.Text)
                End If
                Dim lbllicense_no As Label = CType(e.Row.FindControl("lbllicense_no"), Label)
                If lblLicense IsNot Nothing AndAlso lnkDel IsNot Nothing Then
                    lnkDel.Attributes.Add("onclick", "javascript:DelUser('" & lblLicense.Text & "');")
                End If
                'lnkDel.Attributes.Add("onclick", "javascript:DelUser(" & lblLicense.Text & ");")

                Dim Hyperplan As HyperLink = CType(e.Row.FindControl("Hyperplan"), HyperLink)
                ' Hyperplan.Attributes.Add("onclick", "javascript:ResetActive(" & lblLicense.Text & ");")

                If Hyperplan IsNot Nothing AndAlso lbllicense_no IsNot Nothing Then
                    Hyperplan.NavigateUrl = "javascript:window.open('MapPop.aspx?no=" & lbllicense_no.Text &
                          "','L11','scrollbars=yes,resizable=1,width=1002,height=798').focus();"
                End If
                Dim lnkPay As HyperLink = CType(e.Row.FindControl("HyperPay"), HyperLink)
                'lnkPay.Attributes.Add("onclick", "javascript:Pay(" & lblLicense.Text & ");")
                If lnkPay IsNot Nothing AndAlso lblLicense IsNot Nothing AndAlso Not String.IsNullOrEmpty(lblLicense.Text) Then
                    lnkPay.Attributes.Add("onclick", "javascript:Pay(" & lblLicense.Text & ");")
                Else
                    If lnkPay Is Nothing Then
                        System.Diagnostics.Debug.WriteLine("lnkPay not found")
                    End If
                    If lblLicense Is Nothing Then
                        System.Diagnostics.Debug.WriteLine("lblLicense not found")
                    End If
                End If

                Dim lnkPDFNew As HyperLink = CType(e.Row.FindControl("HyperPDFNew"), HyperLink)

                If lnkPDFNew IsNot Nothing AndAlso lblLicense IsNot Nothing AndAlso Not String.IsNullOrEmpty(lblLicense.Text) Then
                    Dim query As String = "SELECT count(license_id) + 2 as count FROM public.receipt WHERE license_id = " & lblLicense.Text
                    Dim count As String = dbconnect.executeScalar(query)

                    If count IsNot Nothing Then
                        lnkPDFNew.Attributes.Add("onclick", "javascript:Pay2(" & lblLicense.Text & " , " & count & ");")
                    Else

                        System.Diagnostics.Debug.WriteLine("The query returned no result.")
                    End If
                Else

                    System.Diagnostics.Debug.WriteLine("lnkPDFNew or lblLicense not found.")
                End If
                'lnkPDFNew.Attributes.Add("onclick", "javascript:Pay2(" & lblLicense.Text & " , " & dbconnect.executeScalar("SELECT count(license_id) + 2 as count FROM public.receipt WHERE license_id = " & lblLicense.Text & "") & ");")

                Dim lnkRegist As HyperLink = CType(e.Row.FindControl("HyperRegist"), HyperLink)
                If lnkRegist IsNot Nothing AndAlso lblLicense IsNot Nothing Then
                    lnkRegist.Attributes.Add("onclick", "javascript:Regist(" & lblLicense.Text & ");")
                Else

                    System.Diagnostics.Debug.WriteLine("lnkRegist or lblLicense not found.")
                End If
                'lnkRegist.Attributes.Add("onclick", "javascript:Regist(" & lblLicense.Text & ");")
                'If Request.QueryString("rt") <> 2 Then
                '    e.Row.Cells(11).Visible = False
                'End If
                If Request.QueryString("rt") <> 5 Then
                    e.Row.Cells(7).Visible = False
                    e.Row.Cells(9).Visible = False

                    If lblold_group_id IsNot Nothing AndAlso HyperDoc1 IsNot Nothing Then
                        If lblold_group_id.Text <> "0" Then
                            HyperDoc1.Text = "<img src='../image/dtl_extend.png' height='20px'>"
                        Else
                            HyperDoc1.Text = "<img src='../image/dtl.png' height='20px'>"
                            System.Diagnostics.Debug.WriteLine("lblold_group_id is Nothing or lblold_group_id.Text is 0")
                        End If
                    Else
                        System.Diagnostics.Debug.WriteLine("lblold_group_id or HyperDoc1 is Nothing")
                    End If
                Else
                    e.Row.Cells(2).Visible = False
                    If e.Row.Cells(10).Text = "รออนุมัติ" Then
                        e.Row.Cells(10).Text = "รอออกเครื่องหมาย"
                    ElseIf e.Row.Cells(10).Text = "เสร็จสมบูรณ์" Then
                        e.Row.Cells(10).Text = "ออกเครื่องหมายเสร็จสมบูรณ์"
                    End If
                End If

                If e.Row.Cells(10).Text.Contains("รอซื้อ") Then
                    lnkPay.Visible = False
                    Dim the_url = New HyperLink()
                    the_url.NavigateUrl = "addact.aspx?token=" & lblToken.Text & "&rt=" & Request.QueryString("rt")
                    the_url.Text = "อนุมัติ(รอซื้อ พรบ.)"
                    e.Row.Cells(10).Controls.Add(the_url)
                End If

                If e.Row.Cells(10).Text.Contains("เสร็จ") Then
                    lnkPay.Visible = False
                    lnkRegist.Visible = False
                Else
                    If lblreceipt_no IsNot Nothing AndAlso Not String.IsNullOrEmpty(lblreceipt_no.Text.Trim()) Then
                        If lnkPay IsNot Nothing Then lnkPay.Visible = False
                        If lnkRegist IsNot Nothing Then lnkRegist.Visible = True
                    Else
                        If lnkPay IsNot Nothing Then lnkPay.Visible = True
                        If lnkRegist IsNot Nothing Then lnkRegist.Visible = False
                        'If lblreceipt_no IsNot Nothing AndAlso Not String.IsNullOrEmpty(Convert.ToString(lblreceipt_no.Text).Trim()) Then
                        '    lnkPay.Visible = False
                        '    lnkRegist.Visible = True
                        'Else
                        '    lnkPay.Visible = True
                        '    lnkRegist.Visible = False
                    End If

                End If

                If Session("user_id") = "adminbt" Then
                    e.Row.Cells(15).Visible = False
                    e.Row.Cells(17).Visible = False
                    e.Row.Cells(18).Visible = False


                End If

                If lblstatusid IsNot Nothing Then
                    If lblstatusid.Text <> 5 Then
                        Hyperplan.Visible = False
                        HyperDoc.Visible = False
                        HyperSign.Visible = False
                        lnkPDFNew.Visible = False
                        If lblstatusid.Text = 4 Or 7 Then
                            lnkDel.Visible = False

                        End If
                    End If
                Else
                    System.Diagnostics.Debug.WriteLine("lblstatusid not found in this row.")
                End If

                If (Session("user_type").ToString.IndexOf("ขนส่งจังหวัด") > -1 Or Session("user_type") = "0") And Request.QueryString("all") = 1 Then
                        e.Row.Cells(12).Visible = False
                        e.Row.Cells(14).Visible = False
                        e.Row.Cells(15).Visible = False
                        e.Row.Cells(16).Visible = False
                        e.Row.Cells(17).Visible = False
                        e.Row.Cells(18).Visible = False
                        e.Row.Cells(19).Visible = False
                    End If

                'If Request.QueryString("all") = 1 Then
                '    Hyperplan.Visible = False
                '    HyperDoc.Visible = False
                '    lnkPay.Visible = False
                '    lnkPDFNew.Visible = False
                '    lnkRegist.Visible = False

                'End If
                If Request.QueryString("all") = "1" Then

                    ' ตรวจว่า control นั้นมีจริงไหมก่อนใช้
                    If Hyperplan IsNot Nothing Then Hyperplan.Visible = False
                    If HyperDoc IsNot Nothing Then HyperDoc.Visible = False
                    If lnkPay IsNot Nothing Then lnkPay.Visible = False
                    If lnkPDFNew IsNot Nothing Then lnkPDFNew.Visible = False
                    If lnkRegist IsNot Nothing Then lnkRegist.Visible = False
                End If

            End If



                If Request.QueryString("cancel") = "1" Or Request.QueryString("fail") = 1 Then

                If e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.DataRow Then
                    If Request.QueryString("fail") = 1 Then
                        e.Row.Cells(2).Visible = False

                    End If
                    If e.Row.RowType = DataControlRowType.DataRow Then
                        e.Row.Cells(10).HorizontalAlign = HorizontalAlign.Left
                        e.Row.Cells(10).Width = Unit.Pixel(200)
                    End If
                    e.Row.Cells(11).Visible = False
                    e.Row.Cells(14).Visible = False
                    e.Row.Cells(15).Visible = False
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                    e.Row.Cells(18).Visible = False
                    e.Row.Cells(19).Visible = False
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("message :" & ex.Message)

        End Try
    End Sub

    Protected Sub BtnPay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPay.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim urlpath As String = ""
        Dim token As String
        Dim typegroup As String
        Dim TableCommand As DataTable = dbConnect.TableCommand

        Try
            
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text


            Dim strUpdate As String = "Update license set start_date=:start_date , receipt=:receipt , receipt_pc=:receipt_pc , receipt_process=:receipt_process , " & _
                                      " receipt_date = now() , exp_date=:exp_date WHERE license_id = '" & HidLicense.Value & "' "
            If Request.QueryString("rt") = 5 Then

                cmd.CommandText = strUpdate
                cmd.Parameters.Clear()
                cmd.Parameters.Add("receipt", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtReciept.Text
                cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.licenseNo(1)
                cmd.ExecuteNonQuery()
            Else

                Dim minval As Date = dbConnect.executeScalar(" select min(row1) from ( VALUES ( " & _
                                   " (select act_ends  from act LEFT JOIN license on license.act_id = act.act_id  WHERE license_id = " & HidLicense.Value & "))," & _
                                   " ((select exp_date from travel_group where group_id = (select group_id from travel_group_car where license_id = " & HidLicense.Value & "))),((select act_ends2  from act LEFT JOIN license on license.act_id = act.act_id  WHERE license_id = " & HidLicense.Value & ")) " & _
                                   " ) as dt (row1) ")
                token = dbConnect.executeScalar("SELECT token from license WHERE license_id = '" & HidLicense.Value & "' ")
                typegroup = dbConnect.executeScalar("SELECT typegroup from license WHERE license_id = '" & HidLicense.Value & "' ")
                Dim license_no As String = dbConnect.executeScalar("SELECT license_no from license WHERE license_id = '" & HidLicense.Value & "' ")
                cmd.CommandText = strUpdate
                cmd.Parameters.Clear()

                If Request.QueryString("rt") = 2 Then
                    'Dim DateNow = DateSerial(Now.Year, Now.Month, Now.Day + 30)
                    Dim DateVal = minval
                    cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
                    cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DateVal
                    'cmd.Parameters.Add("registrar_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_name.Text
                    'cmd.Parameters.Add("registrar_position", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_position.Text
                    cmd.Parameters.Add("receipt_pc", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReciept_pc.Text.Trim <> "", txtReciept_pc.Text, Nothing)
                    cmd.Parameters.Add("receipt_process", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReciept_process.Text.Trim <> "", txtReciept_process.Text, Nothing)
                    cmd.Parameters.Add("receipt", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReciept.Text.Trim <> "", txtReciept.Text, Nothing)
                    'cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.licenseNo(admin_id)
                ElseIf typegroup = 2 Then
                    Dim DateNow = DateSerial(Now.Year, Now.Month + 4, Now.Day)
                    Dim DateVal = New DateTime(Math.Min(DateNow.Ticks, minval.Ticks))
                    cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
                    cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DateVal
                    'cmd.Parameters.Add("registrar_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_name.Text
                    'cmd.Parameters.Add("registrar_position", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_position.Text
                    cmd.Parameters.Add("receipt_pc", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReciept_pc.Text.Trim <> "", txtReciept_pc.Text, Nothing)
                    cmd.Parameters.Add("receipt_process", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReciept_process.Text.Trim <> "", txtReciept_process.Text, Nothing)
                    cmd.Parameters.Add("receipt", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReciept.Text.Trim <> "", txtReciept.Text, Nothing)
                    'cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.licenseNo(admin_id)
                Else
                    Dim DateNow = DateSerial(Now.Year + 1, Now.Month, Now.Day)
                    Dim DateVal = New DateTime(Math.Min(DateNow.Ticks, minval.Ticks))
                    cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
                    cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DateVal
                    'cmd.Parameters.Add("registrar_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_name.Text
                    'cmd.Parameters.Add("registrar_position", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_position.Text
                    cmd.Parameters.Add("receipt_pc", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReciept_pc.Text.Trim <> "", txtReciept_pc.Text, Nothing)
                    cmd.Parameters.Add("receipt_process", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReciept_process.Text.Trim <> "", txtReciept_process.Text, Nothing)
                    cmd.Parameters.Add("receipt", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReciept.Text.Trim <> "", txtReciept.Text, Nothing)
                    'cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.licenseNo(admin_id)
                End If
                cmd.ExecuteNonQuery()


             

            End If
            'urlpath = dbConnect.executeScalar("SELECT CAST('../Sign.aspx?token=' || token as varchar ) as urlSign from license where license_id = '" & HidLicense.Value & "' ")
            loadData()
            'ScriptManager.RegisterStartupScript(Page, GetType(Page), "script", "window.open('" & urlpath & "&typeuser=" & Request.QueryString("rt") & "','_newtab');", True)
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถบันทึกได้ กรุณาลองใหม่อีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
    End Sub

    Protected Sub BtnBtnRegistar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRegistar.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim urlpath As String = ""
        Dim token As String
        Dim typegroup As String
        Dim TableCommand As DataTable = dbConnect.TableCommand

        Try
            Dim admin_id As Integer ' = dbConnect.executeScalar("SELECT admin_id from license where license_id = '" & HidLicense.Value & "'")


            If Request.QueryString("rt") = 2 Then
                admin_id = dbConnect.executeScalar("SELECT admin_id from travel_group where group_id = (select group_id from travel_group_car where license_id = '" & HidLicense.Value & "')")
            Else
                admin_id = dbConnect.executeScalar("SELECT admin_id from license where license_id = '" & HidLicense.Value & "'")
            End If
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
  
            Dim strUpdate As String = "Update license set status_id = 5 , registrar_name=:registrar_name , registrar_position=:registrar_position, license_no=:license_no, cancel_date = null WHERE license_id = '" & HidLicense.Value & "' "

            If Request.QueryString("rt") = 5 Then

                cmd.CommandText = strUpdate
                cmd.Parameters.Clear()
                cmd.Parameters.Add("receipt", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtReciept.Text
                cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.licenseNo(1, HidLicense.Value)
                cmd.ExecuteNonQuery()
            Else
                cmd.CommandText = strUpdate
                cmd.Parameters.Add("registrar_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_name.Text
                cmd.Parameters.Add("registrar_position", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_position.Text
                cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.licenseNo(admin_id, HidLicense.Value)
                cmd.ExecuteNonQuery()

                Dim checklicnese = dbConnect.executeScalar("select license_group from travel_group WHERE group_id in(select group_id from travel_group_car WHERE license_id = '" & HidLicense.Value & "')")

                If checklicnese = "" Then
                    Dim group_id = dbConnect.executeScalar("SELECT group_id  FROM public.travel_group_car WHERE(license_id = " & HidLicense.Value & ")")
                    TableCommand.Clear()
                    TableCommand.Rows.Add("license_group", NpgsqlTypes.NpgsqlDbType.Varchar, dbConnect.GroupNo)
                    Dim check = dbConnect.UpdateDataTable(TableCommand, "travel_group", "WHERE group_id = " & group_id)
                    If check = "" Then
                        Dim ReadGuide As DataTable = dbConnect.ReadDataTable("select gid , group_id , guide_id from travel_group_guide WHERE group_id = " & group_id)
                        For Each i In ReadGuide.Rows
                            TableCommand.Clear()
                            TableCommand.Rows.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar, dbConnect.TokenGuide(i("gid"), i("group_id"), i("guide_id")))
                            dbConnect.UpdateDataTable(TableCommand, "travel_group_guide", "WHERE gid = " & i("gid"))
                        Next
                    End If
                End If


            End If
            urlpath = dbConnect.executeScalar("SELECT CAST('../Sign.aspx?token=' || token as varchar ) as urlSign from license where license_id = '" & HidLicense.Value & "' ")
            loadData()
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "script", "$('#loadings').hide(); window.open('" & urlpath & "&typeuser=" & Request.QueryString("rt") & "','_newtab');", True)
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถบันทึกได้ กรุณาลองใหม่อีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
    End Sub

    Private Send As New SendEmail
    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles BtnDelete.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim token As String
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Clear()
            cmd.CommandText = "Update license set  status_id = 4 , cancel_date = now()  WHERE license_id = '" & HidLicense.Value & "' "
            cmd.ExecuteNonQuery()

            token = dbConnect.executeScalar("SELECT token from license WHERE license_id = '" & HidLicense.Value & "' ")
            Dim dread As Npgsql.NpgsqlDataReader
            Dim str = " SELECT driver.prename, coalesce(driver.prename_other,'')as prename_other , driver.name ,  driver.surname , idcard_no , driver.email , type_user.typeuser_id , plate, country_car, " & IIf(Request.QueryString("rt") = 2, "travel_group.start_date, travel_group.exp_date", "license.start_date, license.exp_date") & _
            " from driver LEFT JOIN license on license.driver_id = driver.driver_id " & _
                " LEFT JOIN type_user on type_user.typeuser_id = license.typeuser_id " & _
                " LEFT JOIN car on car.car_id = license.car_id " & _
                " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
                " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                " LEFT JOIN user_travel on user_travel.user_id = travel_group.user_id " & _
            " WHERE license.token = '" & token & "' "
            cmd.CommandText = str
            dread = cmd.ExecuteReader()
            Dim email As String = ""
            Dim typeuser_id As String = ""
            Dim plate As String = ""
            Dim country_car As String = ""
            Dim start_date As String = ""
            Dim exp_date As String = ""
            Dim _Name As String = ""
            If dread.Read Then
                If dread("prename") IsNot DBNull.Value Then
                  
                    If dread("prename") = "Other" Then
                        _Name = ""
                    Else
                        _Name = dread("prename")
                    End If
                End If

                If dread("name") IsNot DBNull.Value Then
                    _Name = _Name & " " & dread("name")
                End If
                If dread("surname") IsNot DBNull.Value Then
                    _Name = _Name & " " & dread("surname")
                End If

                If dread("email") IsNot DBNull.Value Then
                    email = dread("email")
                End If
                If dread("typeuser_id") IsNot DBNull.Value Then
                    typeuser_id = dread("typeuser_id")
                End If

                If dread("plate") IsNot DBNull.Value Then
                    plate = dread("plate")
                End If

                If dread("country_car") IsNot DBNull.Value Then
                    country_car = dread("country_car")
                End If

                If dread("start_date") IsNot DBNull.Value Then
                    start_date = dread("start_date")
                End If

                If dread("exp_date") IsNot DBNull.Value Then
                    exp_date = dread("exp_date")
                End If
            End If
            dread.Close()


            Send.EmailCancelled(email, _Name, token, typeuser_id, plate, country_car, start_date, exp_date)
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถยกเลิกใบอนุญาตได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
        loadData()
    End Sub

    Protected Sub BtnResetActive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnResetActive.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Update license set license_no =:license_no , status_id = 1 WHERE license_id = '" & HidLicense.Value & "' "
            cmd.Parameters.Clear()
            cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ""
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถอัพเดตข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
    End Sub

    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSch.Click
        loadData()
    End Sub


    Protected Sub gvMain_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.DataBound
        '//--- For Paging ---------
        Dim row As GridViewRow = gvMain.BottomPagerRow
        If row Is Nothing Then
            Return
        End If

        Dim DDLPage As DropDownList = DirectCast(row.Cells(0).FindControl("DDLPage"), DropDownList)

        If Not DDLPage Is Nothing Then
            For i As Integer = 0 To gvMain.PageCount - 1
                Dim pageNumber As Integer = i + 1
                Dim item As New ListItem(pageNumber.ToString())
                If i = gvMain.PageIndex Then
                    item.Selected = True
                End If
                DDLPage.Items.Add(item)
            Next
        End If

        '//-- For First and Previous ImageButton
        If gvMain.PageIndex = 0 Then
            Dim btnFirst As LinkButton = DirectCast(row.Cells(0).FindControl("btnFirst"), LinkButton)
            Dim btnPrev As LinkButton = DirectCast(row.Cells(0).FindControl("btnPrev"), LinkButton)
            btnFirst.Visible = False
            btnPrev.Visible = False
        End If


        '//-- For Last and Next ImageButton
        If gvMain.PageIndex + 1 = gvMain.PageCount Then
            Dim btnLast As LinkButton = DirectCast(row.Cells(0).FindControl("btnLast"), LinkButton)
            Dim btnNext As LinkButton = DirectCast(row.Cells(0).FindControl("btnNext"), LinkButton)
            btnLast.Visible = False
            btnNext.Visible = False
        End If
    End Sub
    Private Sub gvMain_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles gvMain.PageIndexChanging
  
        gvMain.PageIndex = e.NewPageIndex
        loadData()
    End Sub

    Protected Sub DDLPage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow = gvMain.BottomPagerRow
        Dim DDLPage As DropDownList = DirectCast(row.Cells(0).FindControl("DDLPage"), DropDownList)
        gvMain.PageIndex = DDLPage.SelectedIndex
        gvMain.DataBind()
        loadData()
    End Sub

    Protected Sub ddl_PageSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_PageSize.SelectedIndexChanged
        If ddl_PageSize.SelectedValue <> "--" Then
            gvMain.PageSize = Convert.ToInt32(ddl_PageSize.SelectedValue)
            gvMain.DataBind()
            loadData()
        End If
    End Sub

    Protected Sub ddlstatussearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlstatussearch.SelectedIndexChanged
        loadData()
    End Sub

    Protected Sub BtnReceipt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReceipt.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim urlpath As String = ""
        Dim TableCommand As DataTable = dbConnect.TableCommand

        Try

            Dim checkcount As Integer = dbConnect.executeScalar("SELECT count(license_id) + 2 as count FROM public.receipt WHERE license_id = " & HidLicense.Value & "")
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "INSERT INTO receipt( license_id , receipt_no , receipt_date , receipt_pc , receipt_process , registrar_name , registrar_position , unit) " &
                              " VALUES (:license_id, :receipt_no , now() , :receipt_pc , :receipt_process , :registrar_name , :registrar_position , :unit ); "
            cmd.Parameters.Clear()
            cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = HidLicense.Value
            cmd.Parameters.Add("receipt_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtReciept2.Text
            cmd.Parameters.Add("registrar_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_name2.Text
            cmd.Parameters.Add("registrar_position", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_position2.Text
            cmd.Parameters.Add("receipt_pc", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtReciept_pc2.Text
            cmd.Parameters.Add("receipt_process", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtReciept_process2.Text
            cmd.Parameters.Add("unit", NpgsqlTypes.NpgsqlDbType.Integer).Value = checkcount 'txtcheckcount2.Text
            cmd.ExecuteNonQuery()
            urlpath = dbConnect.executeScalar("SELECT CAST('../Sign.aspx?token=' || token as varchar ) as urlSign from license where license_id = '" & HidLicense.Value & "' ")
            loadData()

            ScriptManager.RegisterStartupScript(Page, GetType(Page), "script", "window.open('" & urlpath & "&typeuser=" & Request.QueryString("rt") & "','_newtab');", True)
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถบันทึกได้ กรุณาลองใหม่อีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
    End Sub
    Protected Sub btnDelete_Command(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim dbConnect As New DBConnect()
        Dim cmd As New NpgsqlCommand()
        Dim con As NpgsqlConnection = DBConnect.getConnection()

        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Clear()

            ' รับค่า license_id จากปุ่มที่กดลบ
            Dim licenseId As String = e.CommandArgument.ToString()

            ' คำสั่ง SQL สำหรับลบ
            cmd.CommandText = "DELETE FROM license WHERE license_id = @license_id"
            cmd.Parameters.AddWithValue("@license_id", licenseId)
            cmd.ExecuteNonQuery()

            ' โหลดข้อมูลใหม่หลังจากลบ
            loadData()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('เกิดข้อผิดพลาด ไม่สามารถลบได้');", True)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

End Class
