Imports System.Data
Imports Microsoft.Reporting.WebForms
Imports System.IO
Partial Class Admin_RptStatCarByAdmin_Car
    Inherits System.Web.UI.Page
    Private Populate As New PopulateDropDown
    Protected _year As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _year = Now.Year()
        If Page.IsPostBack = False Then
            Populate.genDDLyears_th(ddlSchyear, Now.Year + 543, "")
            Populate.genDDLmonths(ddlSchMonth, "", "th")

            If Request.QueryString("type") = 1 Then
                divShowDate.Visible = False
            ElseIf Request.QueryString("type") = 2 Then
                lblHead.Text = lblHead.Text & " สะสม"
            Else
                divShowMonth.Visible = False
            End If
            btnBack.PostBackUrl = btnBack.PostBackUrl & "?rt=" & Request.QueryString("rt")
            PopulateReport()
        End If
    End Sub

    Private Sub PopulateReport()
        Try
            Dim Dt As DataTable
            Dt = getData()

            Dim rpt As LocalReport = ReportViewer1.LocalReport
            rpt.DataSources.Clear()
            rpt.ReportPath = "Report\RptStatCarByAdmin_Car.rdlc"
            rpt.DataSources.Add(New ReportDataSource("DataSet1", Dt))

            rpt.EnableHyperlinks = True

            Me.ReportViewer1.ShowReportBody = True
            Me.ReportViewer1.ShowPromptAreaButton = True
            Dim pBrowser = System.Web.HttpContext.Current.Request.Browser.Browser
            If pBrowser = "Chrome" Or pBrowser = "Firefox" Then
                ReportViewer1.AsyncRendering = False
                ReportViewer1.Width = Unit.Pixel(1200) 'Unit.Percentage(100)
                ReportViewer1.Height = Unit.Pixel(600)
            Else
                ReportViewer1.Width = Unit.Percentage(100)
            End If
            ReportViewer1.LocalReport.Refresh()


        Catch ex As Exception

        End Try
    End Sub

    Private Function getData() As DataTable
        Dim dtReport As DataTable
        Dim db As New DBConnect
        Try
            Dim typeuser_id As Integer = Request.QueryString("rt")
            Dim strWhere As String = " where typeuser_id = " & typeuser_id
            Dim strWhere_old As String = " where typeuser_id = " & typeuser_id
            If Request.QueryString("type") = 1 Then
                ''ประจำเดือน"
                Dim _startdate As String
                Dim _expdate As String

                Dim schdate As String = ddlSchyear.SelectedValue - 543 & Format(CDbl(ddlSchMonth.SelectedValue), "00")
                If typeuser_id = 2 Then
                    If ddldate1.SelectedValue = 1 Then
                        _startdate = " (EXTRACT(year FROM license.receipt_date) :: text || to_char(EXTRACT(MONTH FROM license.receipt_date) :: integer,'FM09')  :: text) :: integer "
                        strWhere = strWhere & " and ( " & schdate & " = " & _startdate & " ) "
                    Else
                        _startdate = " (EXTRACT(year FROM travel_group.start_date) :: text || to_char(EXTRACT(MONTH FROM travel_group.start_date) :: integer,'FM09')  :: text) :: integer "
                        _expdate = " (EXTRACT(year FROM travel_group.exp_date) :: text || to_char(EXTRACT(MONTH FROM travel_group.exp_date) :: integer,'FM09')  :: text) :: integer "
                        strWhere = strWhere & " and ( " & schdate & " between " & _startdate & " and " & _expdate & " ) "
                    End If
                Else

                    If ddldate1.SelectedValue = 1 Then
                        _startdate = " (EXTRACT(year FROM license.receipt_date) :: text || to_char(EXTRACT(MONTH FROM license.receipt_date) :: integer,'FM09')  :: text) :: integer "
                        strWhere = strWhere & " and ( " & schdate & " = " & _startdate & " ) "
                    Else
                        _startdate = " (EXTRACT(year FROM license.start_date) :: text || to_char(EXTRACT(MONTH FROM license.start_date) :: integer,'FM09')  :: text) :: integer "
                        _expdate = " (EXTRACT(year FROM license.exp_date) :: text || to_char(EXTRACT(MONTH FROM license.exp_date) :: integer,'FM09')  :: text) :: integer "
                        strWhere = strWhere & " and ( " & schdate & " between " & _startdate & " and " & _expdate & " ) "
                    End If

                End If
                strWhere = strWhere & " and license.status_id = 5 "

                Dim _startdate_old As String
                Dim _expdate_old As String
             
                If ddldate1.SelectedValue = 1 Then
                    _startdate_old = " (EXTRACT(year FROM license.receipt_date) :: text || to_char(EXTRACT(MONTH FROM license.receipt_date) :: integer,'FM09')  :: text) :: integer "
                    strWhere_old = strWhere_old & " and ( " & schdate & " = " & _startdate_old & " ) and license.status_id = 5 "
                Else
                    _startdate_old = " (EXTRACT(year FROM license.start_date) :: text || to_char(EXTRACT(MONTH FROM license.start_date) :: integer,'FM09')  :: text) :: integer "
                    _expdate_old = " (EXTRACT(year FROM license.exp_date) :: text || to_char(EXTRACT(MONTH FROM license.exp_date) :: integer,'FM09')  :: text) :: integer "
                    strWhere_old = strWhere_old & " and ( " & schdate & " between " & _startdate_old & " and " & _expdate_old & " ) and license.status_id = 5 "
                End If

            ElseIf Request.QueryString("type") = 2 Then
                'สะสม"

            Else
                Dim arr_s As Array
                Dim arr_e As Array

                If typeuser_id = 2 Then
                    If Page.IsPostBack = False Then
                        arr_s = {"01", "01", _year}
                        arr_e = {Format(CInt(Now.Day), "00"), Format(CInt(Now.Month), "00"), _year}

                        If ddldate.SelectedValue = 1 Then
                            strWhere = strWhere & " and   (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                        Else
                            strWhere = strWhere & " and   ( (travel_group.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                            strWhere = strWhere & " or  (travel_group.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "' ) )"
                        End If

                    Else
                        If txtsdate.Text <> "" And txtedate.Text <> "" Then
                            arr_s = txtsdate.Text.Split("/")
                            arr_e = txtedate.Text.Split("/")
                            If ddldate.SelectedValue = 1 Then
                                strWhere = strWhere & " and    (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                            Else
                                strWhere = strWhere & " and   ( (travel_group.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                                strWhere = strWhere & " or  (travel_group.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'  ) ) "
                            End If

                        End If
                    End If
                Else
                    If Page.IsPostBack = False Then
                        arr_s = {"01", "01", _year}
                        arr_e = {Format(CInt(Now.Day), "00"), Format(CInt(Now.Month), "00"), _year}

                        If ddldate.SelectedValue = 1 Then
                            strWhere = strWhere & " and    (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                        Else
                            strWhere = strWhere & " and   ( (license.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                            strWhere = strWhere & " or  (license.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "' ) )"
                        End If

                    Else
                        If txtsdate.Text <> "" And txtedate.Text <> "" Then
                            arr_s = txtsdate.Text.Split("/")
                            arr_e = txtedate.Text.Split("/")
                            If ddldate.SelectedValue = 1 Then
                                strWhere = strWhere & " and    (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                            Else
                                strWhere = strWhere & " and   ( (license.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                                strWhere = strWhere & " or  (license.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'  ) ) "
                            End If

                        End If
                    End If
                End If
                strWhere = strWhere & " and license.status_id = 5 "

                If Page.IsPostBack = False Then
                    arr_s = {"01", "01", _year}
                    arr_e = {Format(CInt(Now.Day), "00"), Format(CInt(Now.Month), "00"), _year}
                    If ddldate.SelectedValue = 1 Then
                        strWhere_old = strWhere_old & " and    (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                    Else
                        strWhere_old = strWhere_old & " and   ( (license.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                        strWhere_old = strWhere_old & " or  (license.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "' ) )"
                    End If

                Else
                    If txtsdate.Text <> "" And txtedate.Text <> "" Then
                        arr_s = txtsdate.Text.Split("/")
                        arr_e = txtedate.Text.Split("/")
                        If ddldate.SelectedValue = 1 Then
                            strWhere_old = strWhere_old & " and    (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                        Else
                            strWhere_old = strWhere_old & " and   ( (license.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                            strWhere_old = strWhere_old & " or  (license.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'  ) ) "
                        End If

                    End If
                End If
                strWhere_old = strWhere_old & " and license.status_id = 5 "
            End If

            Dim pQuery As String = " select row_number() OVER ( ORDER BY receipt_date,start_date  asc) AS i,* from (" & _
                " select coalesce(admin.admin_name,'ไม่ระบุ') admin_name, to_char(receipt_date, 'DD-MM-YYYY') as receipt_date, license.license_no " & _
                    " , case when typeuser_id = 2 then to_char(travel_group.start_date, 'DD-MM-YYYY') else to_char(license.start_date, 'DD-MM-YYYY') end as start_date  , case when typeuser_id = 2 then to_char(travel_group.exp_date, 'DD-MM-YYYY') else to_char(license.exp_date, 'DD-MM-YYYY') end as exp_date " & _
                    " , coalesce(car.country_car,'ไม่ระบุ') countries ,plate, province_car, case is_juristic when 1 then car.owner_name else ltrim(CAST(coalesce(car.owner_prename,'') || ' ' || car.owner_name || ' ' || car.owner_lastname as varchar)) end as owner_name, coalesce(type_car.type_name_th,'ไม่ระบุ') as type_car " & _
                    " , brands as make , model, colors, seat, car_no, engine_no, engine_cap, weight, coalesce(border_checkin.border_nameth,'ไม่ระบุ') as border_nameth_in, coalesce(border_checkout.border_nameth,'ไม่ระบุ')  as border_nameth_out " & _
                    "  , (select string_agg(prov_th , ', ' ) from area_group left join province on province.prov_code = area_group.prov_code where group_id in (select group_id from travel_group_car where license_id = license.license_id)) as provarea  " & _
                    "  ,name_company as com_name, company_license , case when receipt.registrar_name is null then license.registrar_name else receipt.registrar_name end as registrar_name " & _
                    " , case when receipt.registrar_position is null then license.registrar_position else receipt.registrar_position end as registrar_position, coalesce(app.admin_name,'ไม่ระบุ') user_app " & _
                    " ,  ltrim(CAST(coalesce(driver.prename,'') || ' ' || driver.name || ' ' || driver.surname as varchar))  as driver_name, driver.passport_no  " & _
                    " , ltrim(CAST(coalesce(spare_1.prename,'') || ' ' || spare_1.name || ' ' || spare_1.surname as varchar)) as spare_1_name, spare_1.passport_no as spare_1_passport_no " & _
                    " , ltrim(CAST(coalesce(spare_2.prename,'') || ' ' || spare_2.name || ' ' || spare_2.surname as varchar)) as spare_2_name, spare_2.passport_no as spare_2_passport_no " & _
                    " fROM license LEFT JOIN car on car.car_id = license.car_id " & _
                    " left join type_car on type_car.type_id = car.typecar_id  " & _
                    " left join driver on driver.driver_id = license.driver_id  " & _
                    " LEFT JOIN spare_driver spare_1 on driver.driver_id = spare_1.driver_id and spare_1.spare_ord = 1 " & _
                    " LEFT JOIN spare_driver spare_2 on driver.driver_id = spare_2.driver_id and spare_2.spare_ord > 1 " & _
                    " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " & _
                    " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id  " & _
                    " left join admin on admin.admin_id = case when typeuser_id = 2 then travel_group.admin_id else license.admin_id  end  " & _
                    " left join admin app on app.admin_id = license.user_app " & _
                    " left join border_check border_checkin on border_checkin.border_id = case when typeuser_id = 2 then travel_group.checkin_id else license.checkin_id  end  " & _
                    " left join border_check border_checkout on border_checkout.border_id = case when typeuser_id = 2 then travel_group.checkout_id else license.checkout_id   end  " & _
                    " left join user_travel on user_travel.user_id = license.travel_id  " & _
                    " left join (select distinct(license_id) , receipt.registrar_name , receipt.registrar_position ,unit from receipt where  id in (select max(id) from receipt group by license_id )) receipt on receipt.license_id = license.license_id " & _
                    strWhere ' & " ORDER BY to_char(receipt_date, 'MM-DD-YYYY'), case when typeuser_id = 2 then to_char(travel_group.start_date, 'MM-DD-YYYY') else to_char(license.start_date, 'MM-DD-YYYY') end asc "

            pQuery = pQuery & "union all " & _
                " select coalesce(admin.admin_name,'ไม่ระบุ') admin_name, to_char(receipt_date, 'DD-MM-YYYY') as receipt_date, license.license_no  " & _
                    " , to_char(license.start_date, 'DD-MM-YYYY') as start_date  , to_char(license.exp_date, 'DD-MM-YYYY') as exp_date  , coalesce(license.country_car,'ไม่ระบุ') countries ,plate, province_car " & _
                    " , owner_fullname as owner_name, coalesce(type_car.type_name_th,'ไม่ระบุ') as type_car  , brands as make , model, colors, seat, car_no, engine_no, engine_cap, weight " & _
                    " , coalesce(border_checkin.border_nameth,'ไม่ระบุ') as border_nameth_in, coalesce(border_checkout.border_nameth,'ไม่ระบุ')  as border_nameth_out  , provarea ,name_company as com_name, company_license , registrar_name  ,  registrar_position " & _
                    " , coalesce(app.admin_name,'ไม่ระบุ') user_app  ,  driver_fullname  as driver_name, driver_passport_no " & _
                    " , driver_fullname2 as spare_1_name, driver_passport_no2 as spare_1_passport_no " & _
                    " , '' as spare_2_name, '' as spare_2_passport_no " & _
                    " fROM license_old license " & _
                    " left join type_car on type_car.type_id = license.typecar_id " & _
                    " left join admin on admin.admin_id = license.admin_id " & _
                    " left join admin app on app.admin_id = license.user_app " & _
                    " left join border_check border_checkin on border_checkin.border_id = license.checkin_id " & _
                    " left join border_check border_checkout on border_checkout.border_id = license.checkout_id " & _
                    " left join user_travel on user_travel.user_id = license.travel_id " & _
                    strWhere_old '& " ORDER BY to_char(receipt_date, 'MM-DD-YYYY'), to_char(license.start_date, 'MM-DD-YYYY') asc "
            pQuery = pQuery & " )dt ORDER BY receipt_date, start_date asc "
            dtReport = db.getDataTable(pQuery, "report")
            If dtReport.Rows.Count > 0 Then
                Return dtReport.Rows(0).Table
            Else
                Return dtReport
            End If


        Catch ex As Exception
            Dim ppScript As String = " alert('เกิดข้อผิดพลาด:: " & ex.Message & " ไม่สามารถเรียกข้อมูลได้'); "
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", ppScript, True)
            Return Nothing
        Finally
            db = Nothing
        End Try

    End Function

    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSch.Click
        PopulateReport()
    End Sub


#Region "Export ไฟล์"
    Private cssborder As String = " border='1' bordercolor='#000000' "
    Private cssgroup As String = "  style='vertical-align:middle' "
    Private cssgroupBg As String = "  style='vertical-align:middle; font-size: 15px; font-family: tahoma; background-color: #DDD9C3;' "

    Private Function getQuery() As String
        Dim typeuser_id As Integer = Request.QueryString("rt")
        Dim strWhere As String = " where typeuser_id = " & typeuser_id
        Dim strWhere_old As String = " where typeuser_id = " & typeuser_id
        If Request.QueryString("type") = 1 Then
            ''ประจำเดือน"
            Dim _startdate As String
            Dim _expdate As String

            Dim schdate As String = ddlSchyear.SelectedValue - 543 & Format(CDbl(ddlSchMonth.SelectedValue), "00")
            If typeuser_id = 2 Then

                If ddldate1.SelectedValue = 1 Then
                    _startdate = " (EXTRACT(year FROM license.receipt_date) :: text || to_char(EXTRACT(MONTH FROM license.receipt_date) :: integer,'FM09')  :: text) :: integer "
                    strWhere = strWhere & " and ( " & schdate & " = " & _startdate & " ) "
                Else
                    _startdate = " (EXTRACT(year FROM travel_group.start_date) :: text || to_char(EXTRACT(MONTH FROM travel_group.start_date) :: integer,'FM09')  :: text) :: integer "
                    _expdate = " (EXTRACT(year FROM travel_group.exp_date) :: text || to_char(EXTRACT(MONTH FROM travel_group.exp_date) :: integer,'FM09')  :: text) :: integer "
                    strWhere = strWhere & " and ( " & schdate & " between " & _startdate & " and " & _expdate & " ) "
                End If
            Else

                If ddldate1.SelectedValue = 1 Then
                    _startdate = " (EXTRACT(year FROM license.receipt_date) :: text || to_char(EXTRACT(MONTH FROM license.receipt_date) :: integer,'FM09')  :: text) :: integer "
                    strWhere = strWhere & " and ( " & schdate & " = " & _startdate & " ) "
                Else
                    _startdate = " (EXTRACT(year FROM license.start_date) :: text || to_char(EXTRACT(MONTH FROM license.start_date) :: integer,'FM09')  :: text) :: integer "
                    _expdate = " (EXTRACT(year FROM license.exp_date) :: text || to_char(EXTRACT(MONTH FROM license.exp_date) :: integer,'FM09')  :: text) :: integer "
                    strWhere = strWhere & " and ( " & schdate & " between " & _startdate & " and " & _expdate & " ) "
                End If

            End If
            strWhere = strWhere & " and license.status_id = 5 "

            Dim _startdate_old As String
            Dim _expdate_old As String
           
            If ddldate1.SelectedValue = 1 Then
                _startdate_old = " (EXTRACT(year FROM license.receipt_date) :: text || to_char(EXTRACT(MONTH FROM license.receipt_date) :: integer,'FM09')  :: text) :: integer "
                strWhere_old = strWhere_old & " and ( " & schdate & " = " & _startdate_old & " ) and license.status_id = 5 "
            Else
                _startdate_old = " (EXTRACT(year FROM license.start_date) :: text || to_char(EXTRACT(MONTH FROM license.start_date) :: integer,'FM09')  :: text) :: integer "
                _expdate_old = " (EXTRACT(year FROM license.exp_date) :: text || to_char(EXTRACT(MONTH FROM license.exp_date) :: integer,'FM09')  :: text) :: integer "
                strWhere_old = strWhere_old & " and ( " & schdate & " between " & _startdate_old & " and " & _expdate_old & " ) and license.status_id = 5 "
            End If

        ElseIf Request.QueryString("type") = 2 Then
            'สะสม"

        Else
            Dim arr_s As Array
            Dim arr_e As Array

            If typeuser_id = 2 Then
                If Page.IsPostBack = False Then
                    arr_s = {"01", "01", _year}
                    arr_e = {Format(CInt(Now.Day), "00"), Format(CInt(Now.Month), "00"), _year}

                    If ddldate.SelectedValue = 1 Then
                        strWhere = strWhere & " and   (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                    Else
                        strWhere = strWhere & " and   ( (travel_group.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                        strWhere = strWhere & " or  (travel_group.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "' ) )"
                    End If

                Else
                    If txtsdate.Text <> "" And txtedate.Text <> "" Then
                        arr_s = txtsdate.Text.Split("/")
                        arr_e = txtedate.Text.Split("/")
                        If ddldate.SelectedValue = 1 Then
                            strWhere = strWhere & " and    (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                        Else
                            strWhere = strWhere & " and   ( (travel_group.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                            strWhere = strWhere & " or  (travel_group.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'  ) ) "
                        End If

                    End If
                End If
            Else
                If Page.IsPostBack = False Then
                    arr_s = {"01", "01", _year}
                    arr_e = {Format(CInt(Now.Day), "00"), Format(CInt(Now.Month), "00"), _year}

                    If ddldate.SelectedValue = 1 Then
                        strWhere = strWhere & " and    (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                    Else
                        strWhere = strWhere & " and   ( (license.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                        strWhere = strWhere & " or  (license.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "' ) )"
                    End If

                Else
                    If txtsdate.Text <> "" And txtedate.Text <> "" Then
                        arr_s = txtsdate.Text.Split("/")
                        arr_e = txtedate.Text.Split("/")
                        If ddldate.SelectedValue = 1 Then
                            strWhere = strWhere & " and    (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                        Else
                            strWhere = strWhere & " and   ( (license.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                            strWhere = strWhere & " or  (license.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'  ) ) "
                        End If

                    End If
                End If
            End If
            strWhere = strWhere & " and license.status_id = 5 "

            If Page.IsPostBack = False Then
                arr_s = {"01", "01", _year}
                arr_e = {Format(CInt(Now.Day), "00"), Format(CInt(Now.Month), "00"), _year}
                If ddldate.SelectedValue = 1 Then
                    strWhere_old = strWhere_old & " and    (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                Else
                    strWhere_old = strWhere_old & " and   ( (license.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                    strWhere_old = strWhere_old & " or  (license.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "' ) )"
                End If

            Else
                If txtsdate.Text <> "" And txtedate.Text <> "" Then
                    arr_s = txtsdate.Text.Split("/")
                    arr_e = txtedate.Text.Split("/")
                    If ddldate.SelectedValue = 1 Then
                        strWhere_old = strWhere_old & " and    (license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                    Else
                        strWhere_old = strWhere_old & " and   ( (license.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "') "
                        strWhere_old = strWhere_old & " or  (license.exp_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'  ) ) "
                    End If

                End If
            End If
            strWhere_old = strWhere_old & " and license.status_id = 5 "
        End If

                Dim pQuery As String = " select row_number() OVER ( ORDER BY receipt_date,start_date  asc) AS i,* from (" & _
                " select coalesce(admin.admin_name,'ไม่ระบุ') admin_name, to_char(receipt_date, 'DD-MM-YYYY') as receipt_date, license.license_no " & _
                    " , case when typeuser_id = 2 then to_char(travel_group.start_date, 'DD-MM-YYYY') else to_char(license.start_date, 'DD-MM-YYYY') end as start_date  , case when typeuser_id = 2 then to_char(travel_group.exp_date, 'DD-MM-YYYY') else to_char(license.exp_date, 'DD-MM-YYYY') end as exp_date " & _
                    " , coalesce(car.country_car,'ไม่ระบุ') countries ,plate, province_car, case is_juristic when 1 then car.owner_name else ltrim(CAST(coalesce(car.owner_prename,'') || ' ' || car.owner_name || ' ' || car.owner_lastname as varchar)) end as owner_name, coalesce(type_car.type_name_th,'ไม่ระบุ') as type_car " & _
                    " , brands as make , model, colors, seat, car_no, engine_no, engine_cap, weight, coalesce(border_checkin.border_nameth,'ไม่ระบุ') as border_nameth_in, coalesce(border_checkout.border_nameth,'ไม่ระบุ')  as border_nameth_out " & _
                    "  , (select string_agg(prov_th , ', ' ) from area_group left join province on province.prov_code = area_group.prov_code where group_id in (select group_id from travel_group_car where license_id = license.license_id)) as provarea  " & _
                    "  ,name_company as com_name, company_license , case when receipt.registrar_name is null then license.registrar_name else receipt.registrar_name end as registrar_name " & _
                    " , case when receipt.registrar_position is null then license.registrar_position else receipt.registrar_position end as registrar_position, coalesce(app.admin_name,'ไม่ระบุ') user_app " & _
                    " ,  ltrim(CAST(coalesce(driver.prename,'') || ' ' || driver.name || ' ' || driver.surname as varchar))  as driver_name, driver.passport_no  " & _
                    " , ltrim(CAST(coalesce(spare_1.prename,'') || ' ' || spare_1.name || ' ' || spare_1.surname as varchar)) as spare_1_name, spare_1.passport_no as spare_1_passport_no " & _
                    " , ltrim(CAST(coalesce(spare_2.prename,'') || ' ' || spare_2.name || ' ' || spare_2.surname as varchar)) as spare_2_name, spare_2.passport_no as spare_2_passport_no " & _
                    " fROM license LEFT JOIN car on car.car_id = license.car_id " & _
                    " left join type_car on type_car.type_id = car.typecar_id  " & _
                    " left join driver on driver.driver_id = license.driver_id  " & _
                    " LEFT JOIN spare_driver spare_1 on driver.driver_id = spare_1.driver_id and spare_1.spare_ord = 1 " & _
                    " LEFT JOIN spare_driver spare_2 on driver.driver_id = spare_2.driver_id and spare_2.spare_ord > 1 " & _
                    " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " & _
                    " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id  " & _
                    " left join admin on admin.admin_id = case when typeuser_id = 2 then travel_group.admin_id else license.admin_id  end  " & _
                    " left join admin app on app.admin_id = license.user_app " & _
                    " left join border_check border_checkin on border_checkin.border_id = case when typeuser_id = 2 then travel_group.checkin_id else license.checkin_id  end  " & _
                    " left join border_check border_checkout on border_checkout.border_id = case when typeuser_id = 2 then travel_group.checkout_id else license.checkout_id   end  " & _
                    " left join user_travel on user_travel.user_id = license.travel_id  " & _
                    " left join (select distinct(license_id) , receipt.registrar_name , receipt.registrar_position ,unit from receipt where  id in (select max(id) from receipt group by license_id )) receipt on receipt.license_id = license.license_id " & _
                    strWhere ' & " ORDER BY to_char(receipt_date, 'MM-DD-YYYY'), case when typeuser_id = 2 then to_char(travel_group.start_date, 'MM-DD-YYYY') else to_char(license.start_date, 'MM-DD-YYYY') end asc "

        pQuery = pQuery & "union all " & _
            " select coalesce(admin.admin_name,'ไม่ระบุ') admin_name, to_char(receipt_date, 'DD-MM-YYYY') as receipt_date, license.license_no  " & _
                " , to_char(license.start_date, 'DD-MM-YYYY') as start_date  , to_char(license.exp_date, 'DD-MM-YYYY') as exp_date  , coalesce(license.country_car,'ไม่ระบุ') countries ,plate, province_car " & _
                " , owner_fullname as owner_name, coalesce(type_car.type_name_th,'ไม่ระบุ') as type_car  , brands as make , model, colors, seat, car_no, engine_no, engine_cap, weight " & _
                " , coalesce(border_checkin.border_nameth,'ไม่ระบุ') as border_nameth_in, coalesce(border_checkout.border_nameth,'ไม่ระบุ')  as border_nameth_out  , provarea ,name_company as com_name, company_license , registrar_name  ,  registrar_position " & _
                " , coalesce(app.admin_name,'ไม่ระบุ') user_app  ,  driver_fullname  as driver_name, driver_passport_no " & _
                " , driver_fullname2 as spare_1_name, driver_passport_no2 as spare_1_passport_no " & _
                " , '' as spare_2_name, '' as spare_2_passport_no " & _
                " fROM license_old license " & _
                " left join type_car on type_car.type_id = license.typecar_id " & _
                " left join admin on admin.admin_id = license.admin_id " & _
                " left join admin app on app.admin_id = license.user_app " & _
                " left join border_check border_checkin on border_checkin.border_id = license.checkin_id " & _
                " left join border_check border_checkout on border_checkout.border_id = license.checkout_id " & _
                " left join user_travel on user_travel.user_id = license.travel_id " & _
                strWhere_old '& " ORDER BY to_char(receipt_date, 'MM-DD-YYYY'), to_char(license.start_date, 'MM-DD-YYYY') asc "
        pQuery = pQuery & " )dt ORDER BY receipt_date, start_date asc "
        Return pQuery
    End Function

    Protected Sub BtnExportExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExportExcel.Click
        Dim db As New DBConnect
        Try
            Dim strCommand As String = getQuery()
            Dim dt As DataTable = db.getDataTable(strCommand, "stat")
            'Dim headerTable As String = ""
            Dim headerTable As String = "<Table " & cssborder & "  >" '<tr><td colspan=" & dt.Columns.Count & " style='font-size: 18px; font-family: tahoma;' ><center><b>การประเมินกิจกรรมกิจกรรมปรับปรุงทางหลวงผ่านย่านชุมชน<b></center></td></tr>" '& _
            headerTable = headerTable & "<tr>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>#<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>สำนักงาน<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>วันที่ดำเนินการ<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>เลขที่ใบอนุญาต<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>วันที่เข้า<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>วันที่ออก<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ประเทศที่รถจดทะเบียน<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>เลขทะเบียน<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>จังหวัด/รัฐ<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>เจ้าของรถ/ผู้ขอ<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ลักษณะรถ<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ยี่ห้อรถ<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>แบบ (MODEL)<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>สีรถ<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ที่นั่ง<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>หมายเลขตัวถัง<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>หมายเลขเครื่องยนต์<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ความจุกระบอกสูบ(CC.)<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>น้ำหนักรวม<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ด่านศุลกากรที่เข้า<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ด่านศุลกากรที่ออก<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ท้องที่ใช้รถ(Province)<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ผู้ประกอบการธุรกิจนำเที่ยว<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ใบอนุญาตเลขที่<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>นายทะเบียน<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ตำแหน่ง<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>ผู้ดำเนินการ<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>คนขับ<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>Passport<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>คนขับที่2<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>Passport<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>คนขับที่3<b></center></td>"
            headerTable = headerTable & "<td " & cssgroupBg & "><center><b>Passport<b></center></td>"

            headerTable = headerTable & "</tr>"
            headerTable = headerTable & "</Table>"

            If Request.QueryString("type") = 1 Then
                ExportExcel.Convert(dt, "การอนุญาตรถท่องเที่ยว ประจำเดือน.xls", Response, headerTable, False)
            Else
                ExportExcel.Convert(dt, "การอนุญาตรถท่องเที่ยว.xls", Response, headerTable, False)
            End If


        Catch ex As Exception

        Finally
            db = Nothing
        End Try
    End Sub

#End Region

End Class
