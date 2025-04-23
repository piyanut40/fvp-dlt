Imports System.Data
Imports Npgsql

Partial Class Admin_index
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected _year As String
    Protected text As String
    Protected name As String
    Protected qrCode As String = "https://api.qrserver.com/v1/create-qr-code/?size=300x300&data="
    Protected url As String = HttpContext.Current.Request.Url.Host & "/Report/QRCode.aspx?token="
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _year = Now.Year()
        If Session("user_id") = Nothing Then
            Response.Redirect("../Login.aspx")
        Else
            If IsPostBack = False Then
                Populate.genDDLCountry(ddlCountry, False)
                Populate.genDDLBudyearEN(ddlYear, 0, "ปีทั้งหมด")
                Populate.genAdminNames(ddladmin, "สนง.ขนส่งทั้งหมด")
                If PopulateS.IsMobile Then
                    lnkAdd.Text = "<i class='fa fa-plus' aria-hidden='true' ></i> เพิ่ม"
                    Css = ""
                End If
                If Request.QueryString("rt") = 1 Then

                    text = "ค้นหาคำขออนุญาตนำรถประจำถิ่นเข้ามาในราชอาณาจักร"
                    name = "ชื่อผู้ใช้รถ"
                    loadData()
                    Populate.genPageSize(ddl_PageSize)
                    ddl_PageSize.SelectedValue = 10
                    'licenseNo()
                    divAddType5.Visible = False
                    txtTour.Visible = False

                ElseIf Request.QueryString("rt") = 2 Then
                    text = "ค้นหาคำขออนุญาตนำรถท่องเที่ยวเข้ามาในราชอาณาจักร"
                    name = "ชื่อผู้ใช้รถ"
                    Populate.genPageSize(ddl_PageSize)
                    ddl_PageSize.SelectedValue = 10
                    loadData()
                    'licenseNo()
                    divAddType5.Visible = False
                    ddlCountry.Visible = False

                    If Session("admin_id") <> "" Then
                        ddladmin.SelectedValue = Session("admin_id")
                        ddladmin.Attributes.Add("disabled", "true")
                    End If

                ElseIf Request.QueryString("rt") = 3 Then
                    text = "ค้นหาคำขออนุญาตนำรถตามความตกลงระหว่างประเทศรถยนต์ส่วนบุคคล ของประเทศลาวเข้ามาในราชอาณาจักร"
                    name = "ชื่อผู้ใช้รถ"
                    Populate.genPageSize(ddl_PageSize)
                    ddl_PageSize.SelectedValue = 10
                    loadData()
                    'licenseNo()
                    divAddType5.Visible = False
                    txtTour.Visible = False

                ElseIf Request.QueryString("rt") = 4 Then
                    text = "ค้นหาคำขออนุญาตนำรถตามความตกลงระหว่างประเทศรถยนต์ส่วนบุคคล ของประเทศมาเลเซีย และสิงคโปร์เข้ามาในราชอาณาจักร"
                    name = "ชื่อผู้ใช้รถ"
                    Populate.genPageSize(ddl_PageSize)
                    ddl_PageSize.SelectedValue = 10
                    loadData()
                    'licenseNo()
                    divAddType5.Visible = False
                    txtTour.Visible = False

                ElseIf Request.QueryString("rt") = 5 Then
                    text = "ค้นหาคำขออนุญาตนำรถตามความตกลงระหว่างประเทศรถขนส่งเชิงพาณิชย์เข้ามาในราชอาณาจักร"
                    name = "ชื่อบริษัท"
                    txtTour.Visible = False
                    Populate.genPageSize(ddl_PageSize)
                    ddl_PageSize.SelectedValue = 10
                    ddlstatus.Items.Clear()
                    Dim dtstatus As New DataTable
                    With dtstatus
                        .Columns.Add("value")
                        .Columns.Add("text")
                    End With
                    With dtstatus
                        .Rows.Add("0", "อนุมัติ")
                        .Rows.Add("2", "เอกสารไม่สมบูรณ์")
                        .Rows.Add("3", "ไม่ผ่าน")
                        '.Rows.Add("4", "ยกเลิกใบอนุญาติ")
                    End With

                    ddlstatus.Items.Clear()
                    ddlstatus.DataSource = dtstatus
                    ddlstatus.DataTextField = "text"
                    ddlstatus.DataValueField = "value"
                    ddlstatus.DataBind()
                    ddlstatus.CssClass = "w3-input w3-border w3-round-large"
                    loadData()
                    'licenseNo()


                End If
            End If
        End If

    End Sub
    Private Sub loadData()
        Dim dbConnect As New DBConnect
        Dim dt As DataTable
        Dim strsql As String = ""
        Try
            Dim urlLicenseApp As String = " CAST('LicenseApp.aspx?rt=" & Request.QueryString("rt")

            Dim strType As String = "replace(type_name,'(','<br/>(')" '"type_name"


            Dim admin_id As String = "travel_group.admin_id" '"license.admin_id" 

            If Request.QueryString("rt") <> 5 And Request.QueryString("rt") <> 2 Then
                If Request.QueryString("rt") = 1 Then
                    strsql = " SELECT  Row_number() over (order by regis_date desc nulls last) as number ,* FROM  " &
                       " ( SELECT plate , country_car , license.license_id , token , " & admin_id & " admin_id , CAST(case when prename = 'Other' then '' else prename end || ' ' || name || ' ' || surname as varchar) as name, '' as vehicle_type  , CAST(" & strType & " || ' ( ' || license.typegroup || ' ) ' as varchar )  as typecar_en, brands, model as models, status_th ,  CAST('LicenseApp.aspx?rt=" & Request.QueryString("rt") & "&token=' || token as varchar ) as urlDoc, '' as urlMgt, typeuser_id, license.status_id,regis_date  , check_tab1, check_tab2, check_tab3, check_tab4, check_tab5, check_tab6, check_tab7 , check_tab0 , check_tab8, reason_app as reason  " &
                       " , CAST(case when user_prename = 'Other' then '' else user_prename end || ' ' || user_travel_group.user_name || ' ' || user_lastname as varchar) as guide  , name_company , travel_group.start_date , travel_group.exp_date, " &
                       " (select count(*) from user_travel_group as t1  " &
                       " LEFT JOIN travel_group as t2 on t2.group_id = t1.group_id  " &
                       " WHERE t1.idcard like user_travel_group.idcard  and (start_date >= travel_group.start_date AND exp_date <= travel_group.exp_date) )as count " &
                       " ,travel_group.start_date as start_date1,travel_group.exp_date as exp_date1" &
                       " FROM license " &
                       " LEFT JOIN driver on driver.driver_id = license.driver_id  LEFT JOIN car on car.car_id = license.car_id " &
                       " LEFT JOIN type_car on car.typecar_id = type_car.type_id  LEFT JOIN status on license.status_id = status.status_id " &
                       " LEFT JOIN user_travel on user_travel.user_id =  license.travel_id " &
                       " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " &
                       " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " &
                       " LEFT JOIN user_travel_group on user_travel_group.group_id = travel_group_car.group_id " &
                    " WHERE typeuser_id = " & Request.QueryString("rt") & " and license.status_id not in (4, 5 , 3 , 1) ) as dt "
                Else
                    strsql = " SELECT  Row_number() over (order by regis_date desc nulls last) as number ,* FROM  " &
                      " ( SELECT plate , country_car , license.license_id , token , " & admin_id & " admin_id , CAST(case when prename = 'Other' then '' else prename end || ' ' || name || ' ' || surname as varchar) as name, '' as vehicle_type  , " & strType & " as typecar_en, brands, model as models, status_th ,  CAST('LicenseApp.aspx?rt=" & Request.QueryString("rt") & "&token=' || token as varchar ) as urlDoc, '' as urlMgt, typeuser_id, license.status_id,regis_date  , check_tab1, check_tab2, check_tab3, check_tab4, check_tab5, check_tab6, check_tab7 , check_tab0 , check_tab8, reason_app as reason  " &
                      " , CAST(case when user_prename = 'Other' then '' else user_prename end || ' ' || user_travel_group.user_name || ' ' || user_lastname as varchar) as guide  , name_company , travel_group.start_date , travel_group.exp_date, " &
                      " (select count(*) from user_travel_group as t1  " &
                      " LEFT JOIN travel_group as t2 on t2.group_id = t1.group_id  " &
                      " WHERE t1.idcard like user_travel_group.idcard  and (start_date >= travel_group.start_date AND exp_date <= travel_group.exp_date) )as count " &
                      " ,travel_group.start_date as start_date1,travel_group.exp_date as exp_date1" &
                      " FROM license " &
                      " LEFT JOIN driver on driver.driver_id = license.driver_id  LEFT JOIN car on car.car_id = license.car_id " &
                      " LEFT JOIN type_car on car.typecar_id = type_car.type_id  LEFT JOIN status on license.status_id = status.status_id " &
                      " LEFT JOIN user_travel on user_travel.user_id =  license.travel_id " &
                      " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " &
                      " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " &
                      " LEFT JOIN user_travel_group on user_travel_group.group_id = travel_group_car.group_id " &
                   " WHERE typeuser_id = " & Request.QueryString("rt") & " and license.status_id not in (4, 5 , 3 , 1) ) as dt "
                End If
            ElseIf Request.QueryString("rt") = 2 Then
                strsql = " SELECT  Row_number() over (order by regis_date desc nulls last) as number ,* FROM  " &
                        " ( SELECT plate , country_car , license.license_id , token , " & admin_id & " admin_id , CAST(case when driver.prename = 'Other' then '' else driver.prename end || ' ' || name || ' ' || surname as varchar) as name, '' as vehicle_type  , " & strType & " as typecar_en " &
                        " , brands, model as models, case when (check_tab0 + check_tab1 + check_tab2 + check_tab3 + check_tab4 + check_tab8) > 6 then 'รออนุมัติ(แก้ไขคำขอ)' else status_th end as status_th ,  " &
                      " CAST('LicenseApp.aspx?rt=2&token=' || token as varchar ) as urlDoc,  " &
                      "  CAST('LicenseAppEdit.aspx?rt=2&token=' || token As varchar) AS urlMgt, typeuser_id, license.status_id,regis_date  , check_tab1, check_tab2, check_tab3, check_tab4, check_tab5, check_tab6, check_tab7 , check_tab0 , check_tab8, reason_app as reason   , " &
                      "(select STRING_AGG(CAST(case when guide.prename = 'Other' then '' else guide.prename end || ' ' || guide.guide_name || ' ' || guide.guide_surname as varchar),' , ')  from guide " &
                      " LEFT JOIN travel_group_guide on travel_group_guide.guide_id = guide.guide_id " &
                       "WHERE travel_group_guide.group_id = travel_group_car.group_id ) as guide , " &
                      "name_company , to_char(travel_group.start_date , 'DD-MM-YYYY') as start_date , " &
                      " to_char(travel_group.exp_date , 'DD-MM-YYYY') as exp_date ,travel_group.start_date as start_date1,travel_group.exp_date as exp_date1" &
                      " FROM license  LEFT JOIN driver on driver.driver_id = " &
                       " license.driver_id  LEFT JOIN car on car.car_id = license.car_id  LEFT JOIN type_car on car.typecar_id = type_car.type_id " &
                       "  LEFT JOIN status on license.status_id = status.status_id  LEFT JOIN user_travel on user_travel.user_id =  license.travel_id  " &
                        " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " &
                        " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " &
                        " WHERE typeuser_id = 2 and license.status_id not in (4, 2, 5 , 3 , 1 , 7 , 8 , 9)  ) as dt " 'and license.status_id not in (4, 5 , 3 , 1 , 7)  ) as dt "

            Else
                strsql = "SELECT  Row_number() over (order by regis_date desc nulls last) as number ,* FROM (SELECT  registration_no as plate ,  country_car , license_id , token , transport_operator_name as name, vehicle_type " &
                       " , vehicle_category as typecar_en, brand as brands, model as models, status_th , " & urlLicenseApp & "&token=' || token as varchar ) as urlDoc,license.regis_date " &
                       " , CAST('CarCommerceMgt.aspx?token=' || token as varchar ) as urlMgt, typeuser_id, license.status_id " &
                       " , check_tab1, check_tab2, check_tab3, check_tab4, check_tab5, check_tab6, check_tab7 , check_tab0 , check_tab8, reason_app as reason , CAST('' as varchar) as count , CAST('' as varchar) as guide , CAST('' as varchar) as name_company , CAST('' as varchar) as start_date , CAST('' as varchar) as exp_date,travel_group.start_date as start_date1,travel_group.exp_date as exp_date1 FROM license " '& _

                strsql = strsql & " LEFT JOIN car_commerce car on car.car_id = license.car_id "

                strsql = strsql & " LEFT JOIN status on license.status_id = status.status_id " &
                       " WHERE typeuser_id = " & Request.QueryString("rt") & " and license.status_id <> 0 ) as dt "
            End If

            strsql = strsql & " where 1=1 "

            If Session("user_id").ToString <> "adminbt" Then
                strsql = strsql & " and admin_id = " & Session("admin_id") & " "


            Else
                If ddladmin.SelectedIndex > 0 Then
                    strsql = strsql & " and admin_id = " & ddladmin.SelectedValue
                End If

            End If
            If Request.QueryString("st") <> "" Then
                strsql = strsql & " and dt.status_id  = " & Request.QueryString("st")
            End If
            If txtName.Text <> "" Then
                strsql = strsql & " and LOWER(dt.name) like LOWER('%" & txtName.Text & "%') "
            End If

            If txtplate.Text <> "" Then
                strsql = strsql & " and LOWER(dt.plate) like LOWER('%" & txtplate.Text & "%') "
            End If

            If ddlCountry.SelectedIndex > 0 Then
                strsql = strsql & " and dt.country_car = '" & ddlCountry.SelectedItem.Text & "' "
            End If

            If txtTour.Text <> "" Then
                strsql = strsql & " and LOWER(name_company) like LOWER('%" & txtTour.Text & "%')"
            End If


            Dim arr_s As Array
            Dim arr_e As Array
            If txtstartdate.Text <> "" And txtexpdate.Text <> "" Then
                arr_s = txtstartdate.Text.Split("/")
                arr_e = txtexpdate.Text.Split("/")
                strsql = strsql & " and  start_date1 between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
            Else

                If txtstartdate.Text <> "" Then

                    arr_s = txtstartdate.Text.Split("/")
                    strsql = strsql & " and  start_date1 >= '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "'"
                End If

                If txtexpdate.Text <> "" Then

                    arr_e = txtexpdate.Text.Split("/")
                    strsql = strsql & " and  start_date1 <= '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                End If
            End If


            If ddlYear.SelectedIndex > 0 Then
                Dim sday As String = ddlYear.SelectedValue & "-01-01"
                Dim eday As String = ddlYear.SelectedValue & "-12-31"
                strsql = strsql & " and start_date1 >= '" & sday & "'  and exp_date1 <= '" & eday & "' "
            End If




            If Request.QueryString("rt") <> 5 Then
                strsql = strsql & " order by regis_date desc nulls last"
            Else
                strsql = strsql & " order by regis_date desc nulls last"
            End If


            dt = dbConnect.getDataTable(strsql, "local")


            gvMain.DataSource = dt
            gvMain.Visible = True
            gvMain.DataBind()
            UpdGrid.Update()


        Catch ex As Exception

        Finally
            dbConnect = Nothing

        End Try
    End Sub

    Private RowIndex As Integer = 1
    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Header Then

                e.Row.TableSection = TableRowSection.TableHeader
                e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(9).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(10).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(11).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(12).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(13).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(14).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(15).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(16).Attributes.Add("data-breakpoints", "xs")

                If Request.QueryString("rt") = 5 Then
                    e.Row.Cells(2).Text = "<center>ชื่อบริษัท </center>"
                    e.Row.Cells(9).Visible = False
                    e.Row.Cells(10).Visible = False
                    e.Row.Cells(11).Visible = False
                    e.Row.Cells(12).Visible = False
                    e.Row.Cells(13).Visible = False
                ElseIf Request.QueryString("rt") = 2 Then

                    e.Row.Cells(8).Visible = False

                    'e.Row.Cells(15).Visible = False
                Else
                    e.Row.Cells(8).Visible = False
                    e.Row.Cells(9).Visible = False
                    e.Row.Cells(10).Visible = False
                    e.Row.Cells(11).Visible = False
                    e.Row.Cells(12).Visible = False

                    e.Row.Cells(15).Visible = False
                End If


            ElseIf e.Row.RowType = DataControlRowType.Pager Then
                e.Row.TableSection = TableRowSection.TableFooter
            Else


                Dim url As String = HttpContext.Current.Request.Url.Host & "/BorderTransport/Documenttoken="
                'Dim lblLicense As Label = e.Row.Cells(0).FindControl("lblLicense")
                Dim lblLicense As Label = TryCast(e.Row.Cells(0).FindControl("lblLicense"), Label)
                Dim lblToken As Label = e.Row.Cells(0).FindControl("lbltoken")
                'Dim lblcount As Label = e.Row.Cells(0).FindControl("lblcount")
                Dim typeuser_id As Label = e.Row.Cells(0).FindControl("lbltypeuser_id")
                Dim status_id As Label = e.Row.Cells(0).FindControl("lblstatus_id")
                Dim lblReason As Label = e.Row.Cells(0).FindControl("lblReason")
                Dim lblcheck_tab1 As Label = e.Row.Cells(0).FindControl("lblcheck_tab1")
                Dim lblcheck_tab2 As Label = e.Row.Cells(0).FindControl("lblcheck_tab2")
                Dim lblcheck_tab3 As Label = e.Row.Cells(0).FindControl("lblcheck_tab3")
                Dim lblcheck_tab4 As Label = e.Row.Cells(0).FindControl("lblcheck_tab4")
                Dim lblcheck_tab5 As Label = e.Row.Cells(0).FindControl("lblcheck_tab5")
                Dim lblcheck_tab6 As Label = e.Row.Cells(0).FindControl("lblcheck_tab6")
                Dim lblcheck_tab7 As Label = e.Row.Cells(0).FindControl("lblcheck_tab7")
                Dim lnkMgt As HyperLink = e.Row.Cells(9).FindControl("HyperMgt")
                Dim lblcheck_tab0 As Label = e.Row.Cells(0).FindControl("lblcheck_tab0")
                Dim lblcheck_tab8 As Label = e.Row.Cells(0).FindControl("lblcheck_tab8")
                If Request.QueryString("rt") = 5 Then
                    e.Row.Cells(9).Visible = False
                    e.Row.Cells(10).Visible = False
                    e.Row.Cells(11).Visible = False
                    e.Row.Cells(12).Visible = False
                    e.Row.Cells(13).Visible = False
                    If lblcheck_tab5.Text = 1 And lblcheck_tab6.Text = 1 And lblcheck_tab7.Text = 1 Then

                    Else
                        e.Row.Cells(13).Text = ""
                    End If

                    '///////////////////////
                ElseIf Request.QueryString("rt") = 2 Then

                    e.Row.Cells(8).Visible = False
                    'e.Row.Cells(15).Visible = False

                Else
                    e.Row.Cells(8).Visible = False
                    e.Row.Cells(9).Visible = False
                    e.Row.Cells(10).Visible = False
                    e.Row.Cells(11).Visible = False
                    e.Row.Cells(12).Visible = False

                    e.Row.Cells(15).Visible = False
                End If



                Dim lnkDel As HyperLink = TryCast(e.Row.Cells(14).FindControl("HyperLinkDel"), HyperLink)
                'Dim lblLicense As Label = TryCast(e.Row.Cells(0).FindControl("lblLicense"), Label)
                If lnkDel IsNot Nothing AndAlso lblLicense IsNot Nothing Then
                    lnkDel.Attributes.Add("onclick", "javascript:DelData(" & lblLicense.Text & ");")
                End If



            End If
        Catch ex As Exception
            Console.WriteLine("Error is:" & ex.Message)

        End Try
    End Sub

    'จัดการตาราง
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

            If DDLPage.SelectedValue > 1 Then
                RowIndex = ((DDLPage.SelectedValue - 1) * ddl_PageSize.SelectedValue) + 1
            End If

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
    Protected Sub gvMain_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvMain.PageIndexChanging

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

    Private Send As New SendEmail
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = DBConnect.getConnection
        Dim token As String
        Try

            con.Open()
            cmd.Connection = con

            If Request.QueryString("rt") = 5 Then
                token = dbConnect.executeScalar("SELECT token from license WHERE license_id = '" & HidLicense.Value & "' ")
                cmd.CommandText = CommandType.Text
                cmd.Parameters.Clear()
                cmd.CommandText = "UPDATE license set status_id = '" & ddlstatus.SelectedValue & "' WHERE license_id = '" & HidLicense.Value & "'"
                cmd.ExecuteNonQuery()
            Else

                Dim minval As Date = dbConnect.executeScalar(" select act_ends from act " &
                                     " LEFT JOIN license on license.act_id = act.act_id " &
                                     " WHERE license_id = '" & HidLicense.Value & "' ")

                token = dbConnect.executeScalar("SELECT token from license WHERE license_id = '" & HidLicense.Value & "' ")
                Dim license_no As String = dbConnect.executeScalar("SELECT license_no from license WHERE license_id = '" & HidLicense.Value & "' ")

                cmd.CommandType = CommandType.Text
                cmd.CommandText = "Update license set status_id = :status_id, start_date = now()  , qrcode = :qrcode, reason_app = :reason_app  WHERE license_id = '" & HidLicense.Value & "' "
                cmd.Parameters.Clear()
                If Request.QueryString("rt") = 3 Or Request.QueryString("rt") = 4 Then
                    If ddlstatus.SelectedValue = 1 Then
                        cmd.Parameters.Add("status_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = 5
                    Else
                        cmd.Parameters.Add("status_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlstatus.SelectedValue
                    End If
                Else
                    cmd.Parameters.Add("status_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlstatus.SelectedValue
                End If
                'cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
                cmd.Parameters.Add("qrcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBConnect.qrcode(token, Request.QueryString("rt")) 'qrCode & url & token
                If ddlstatus.SelectedValue = 2 Or ddlstatus.SelectedValue = 3 Then
                    cmd.Parameters.Add("reason_app", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtreason.Text
                Else
                    cmd.Parameters.Add("reason_app", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                End If

                cmd.ExecuteNonQuery()
            End If


            If ddlstatus.SelectedValue <> 0 Then


                Dim dread As Npgsql.NpgsqlDataReader
                Dim str = " SELECT driver.prename, coalesce(driver.prename_other,'')as prename_other , driver.name ,  driver.surname , idcard_no , driver.email , type_user.typename_th " &
                " from driver LEFT JOIN license on license.driver_id = driver.driver_id " &
                " LEFT JOIN type_user on type_user.typeuser_id = license.typeuser_id " &
                " WHERE license.token = '" & token & "' "
                cmd.CommandText = str
                dread = cmd.ExecuteReader()
                Dim email As String = ""
                Dim typename_th As String = ""
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
                    If dread("typename_th") IsNot DBNull.Value Then
                        typename_th = dread("typename_th")
                    End If
                End If
                dread.Close()

                Send.EmailSummit(email, _Name, token, typename_th, ddlstatus.SelectedValue, txtreason.Text)
            End If

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถอัพเดตข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                con.Close()
            End If
            dbConnect = Nothing
        End Try
        loadData()
    End Sub

    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim dbConnect As New DBConnect

        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = DBConnect.getConnection
        Dim transaction As NpgsqlTransaction
        Dim TbFileOld As New DataTable

        Try
            con.Open()
            transaction = con.BeginTransaction()
            cmd.Connection = con
            cmd.Parameters.Clear()
            If Request.QueryString("rt") = 5 Then
                cmd.CommandText = " delete from car_commerce where car_id = (select coalesce(car_id,0) from license where license_id = " & HidDel_ID.Value & ")"
                cmd.ExecuteNonQuery()

                cmd.CommandText = " delete from license where license_id = " & HidDel_ID.Value
                cmd.ExecuteNonQuery()

            Else

                cmd.CommandText = " UPDATE license set status_id = 9 , cancel_date = now() where license_id = " & HidDel_ID.Value
                cmd.ExecuteNonQuery()
            End If


            transaction.Commit()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
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
            cmd.CommandText = "SELECT token from license WHERE license_id = '" & HidLicense.Value & "' "
            Dim token = cmd.ExecuteScalar()
            cmd.CommandText = "Update license set license_no =:license_no , start_date =:start_date , exp_date = :exp_date , qrcode = :qrcode , status_id = 1 WHERE license_id = '" & HidLicense.Value & "' "
            cmd.Parameters.Clear()
            cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ""
            cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
            cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Now.Month & "-" & Now.Day & "-" & Now.Year + 1
            cmd.Parameters.Add("qrcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.qrcode(token, Request.QueryString("rt"))
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถอัพเดตข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                con.Close()
            End If
            dbConnect = Nothing
        End Try
        loadData()

    End Sub


    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSch.Click
        loadData()
    End Sub
    Protected Sub lnkAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAdd.Click

        Response.Redirect("CarCommerceMgt.aspx")

    End Sub
End Class
