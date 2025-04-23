Imports System.Data

Public Class PopulateChart

    Public Function AddScript(ByVal Page As Page, ByVal _type As Object, ByVal typeuser_id As Integer, ByVal _year As Integer, _
                              ByVal lblHead As Label, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer) As String
        Dim _data As String = "" '" var _data = [ { name: 'Chrome', y: 62.74 },  { name: 'Firefox', y: 10.57 },  { name: 'Internet Explorer', y: 7.23 }, { name: 'Safari',  y: 5.58 }, { name: 'Edge', y: 4.02 }, { name: 'Opera', y: 1.92 }, { name: 'Other', y: 7.62 }  ]; "
        Dim pScriptAddChart As String = "" '_data & " AddChart1(_data); "
        pAlert = ""
        If _type = "1" Then
            '1.รถที่ขออนุญาตฯ จำแนก ตามสำนักงาน 
            lblHead.Text = "รถที่ได้รับอนุญาตฯ จำแนก ตามสำนักงาน "
            _data = getDataChart(Page, "admin.admin_name", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = _data & " AddChart1(_data,'container',true); "

        ElseIf _type = "2" Then
            '2.ประเภทรถที่ขออนุญาต 
            lblHead.Text = "ประเภทรถที่ได้รับอนุญาต"
            _data = getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ')", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = _data & " AddChart2(_data,'container'); "

        ElseIf _type = "3" Then
            '3.จำนวนรถที่ขออนุญาต จำแนกรายเดือน 
            lblHead.Text = "จำนวนรถที่ได้รับอนุญาตฯ จำแนกรายเดือน  "
            '_data = getDataChart(Page, "EXTRACT(year FROM license.regis_date) as yy , EXTRACT(MONTH FROM license.regis_date)", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            _data = getDataChart(Page, "EXTRACT(year FROM travel_group.start_date) as yy , EXTRACT(MONTH FROM travel_group.start_date)", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = _data & " AddChart3(_data,_categories,'container',true,''); "

        ElseIf _type = "4" Then
            '4.ประเภทรถที่จดทะเบียน 5 ลำดับแรก
            lblHead.Text = "ประเทศรถที่จดทะเบียน 5 ลำดับแรก"
            _data = getDataChart(Page, "driver.countries", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = _data & " AddChart4(_data,'container'); "
            'CssChart = "style='min-width: 300px; max-width: 600px; min-height: 500px; margin: 0 auto'"

        ElseIf _type = "5" Then
            '5.จำนวนรถที่ขออนุญาตฯ เข้า-ออก จำแนกตามด่าน
            lblHead.Text = "จำนวนรถที่ได้รับอนุญาตฯ เข้า-ออก จำแนกตามด่าน"
            _data = getDataChart(Page, "border_checkin.border_nameth", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = _data & " AddChart5_1(_data,'container',true); "
            'CssChart = "style='min-width: 300px; max-width: 60%; min-height: 480px; margin: 0 auto'"

            _data = getDataChart(Page, "border_checkout.border_nameth", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = pScriptAddChart & _data & " AddChart5_2(_data,'container2',true); "

        ElseIf _type = "6" Then
            '6.จำนวนรถตามผู้ประกอบธุรกิจนำเที่ยวที่ยื่นขอฯ
            lblHead.Text = "จำนวนรถจำแนกตามผู้ประกอบธุรกิจนำเที่ยวที่ได้รับอนุญาตฯ"
            _data = getDataChart(Page, "coalesce(name_company,'ไม่ระบุ') as name_company, coalesce(type_car.type_name_th,'ไม่ระบุ') ", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = _data & " AddChart6(_data,_categories,'container',true,'','vertical','left','middle'); "

        ElseIf _type = "7" Then
            '7.จำนวนรถที่ขออนุญาต จำแนกตามประเภทรถ และรายเดือน
            lblHead.Text = "จำนวนรถที่ได้รับอนุญาต จำแนกตามประเภทรถ และรายเดือน"
            '_data = getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , EXTRACT(year FROM license.regis_date) as yy , EXTRACT(MONTH FROM license.regis_date)", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            _data = getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , EXTRACT(year FROM travel_group.start_date) as yy , EXTRACT(MONTH FROM travel_group.start_date)", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = _data & " AddChart7(_data,_categories,'container',true,''); "

        ElseIf _type = "8" Then
            'ด่านศุลกากรที่ขออนุญาตรถผ่านเข้า-ออก มากที่สุด 5 ลำดับแรก

        ElseIf _type = "9" Then
            'จำนวนรถที่ขออนุญาตเข้ามาในราชอาณาจักร จำแนกตามด่านศุลกากร
            lblHead.Text = "จำนวนรถที่ได้รับอนุญาตเข้ามาในราชอาณาจักร จำแนกตามด่านศุลกากร"
            _data = getDataChart(Page, " border_checkin.border_nameth", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = _data & " AddChart9(_data,_categories,'container',true,''); "

        ElseIf _type = "10" Then
            'ผู้ประกอบธุรกิจนำเที่ยวที่ขออนุญาตรถผ่านเข้า-ออก

        ElseIf _type = "11" Then
            'จำนวนรถที่ขออนุญาตฯ จำแนกตามสำนักงาน และประเภทรถ

        ElseIf _type = "12" Then
            'จำนวนรถที่ขออนุญาตฯ จำแนกตามสำนักงาน และประเภทรถ
            _data = getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(admin.admin_name,'ไม่ระบุ') ", 12, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = pScriptAddChart & _data & " AddChart12(_data,_categories,'container',true,''); "

        ElseIf _type = "13" Then
            'จำนวนรถที่ขออนุญาตฯ จำแนกตามประเทศที่รถจดทะเบียน

        ElseIf _type = "14" Then
            'จำนวนรถที่ขออนุญาตฯ จำแนกตามประเทศที่รถจดทะเบียน
            _data = getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(driver.countries,'ไม่ระบุ') ", 14, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = pScriptAddChart & _data & " AddChart12(_data,_categories,'container',true,''); "

        ElseIf _type = "15" Then
            'เปรียบเทียบจำนวนรถที่ขออนุญาต
            lblHead.Text = "เปรียบเทียบจำนวนรถที่ได้รับอนุญาตเข้ามาในราชอาณาจักร"
            '_data = getDataChart(Page, "EXTRACT(year FROM license.regis_date) as yy , EXTRACT(MONTH FROM license.regis_date) ", 15, typeuser_id, _year, txtsdate, txtedate, _limit)
            _data = getDataChart(Page, "EXTRACT(year FROM travel_group.start_date) as yy , EXTRACT(MONTH FROM travel_group.start_date) ", 15, typeuser_id, _year, txtsdate, txtedate, _limit)
            pScriptAddChart = pScriptAddChart & _data & " AddChart15(_data,_categories,'container',true,''); "

        End If


        If pAlert <> "" Then
            pScriptAddChart = " alert('" & pAlert & "'); " & pScriptAddChart
        End If

        Return pScriptAddChart
        'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> " & pScriptAddChart & " </script>", False)
    End Function

    Public Function AddScript(ByVal Page As Page, ByVal _type As Object, ByVal typeuser_id As Integer, ByVal _year As Integer, _
                            ByVal lblHead As Label, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer, ByVal _type_date As Integer) As String
        Dim _data As String = "" '" var _data = [ { name: 'Chrome', y: 62.74 },  { name: 'Firefox', y: 10.57 },  { name: 'Internet Explorer', y: 7.23 }, { name: 'Safari',  y: 5.58 }, { name: 'Edge', y: 4.02 }, { name: 'Opera', y: 1.92 }, { name: 'Other', y: 7.62 }  ]; "
        Dim pScriptAddChart As String = "" '_data & " AddChart1(_data); "
        pAlert = ""
        If _type = "1" Then
            '1.รถที่ขออนุญาตฯ จำแนก ตามสำนักงาน 
            lblHead.Text = "รถที่ได้รับอนุญาตฯ จำแนก ตามสำนักงาน "
            _data = getDataChart(Page, "admin.admin_name", _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            pScriptAddChart = _data & " AddChart1(_data,'container',true); "

        ElseIf _type = "2" Then
            '2.ประเภทรถที่ขออนุญาต 
            lblHead.Text = "ประเภทรถที่ได้รับอนุญาต"
            _data = getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ')", _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            pScriptAddChart = _data & " AddChart2(_data,'container'); "

        ElseIf _type = "3" Then
            '3.จำนวนรถที่ขออนุญาต จำแนกรายเดือน 
            lblHead.Text = "จำนวนรถที่ได้รับอนุญาตฯ จำแนกรายเดือน  "
            '_data = getDataChart(Page, "EXTRACT(year FROM license.regis_date) as yy , EXTRACT(MONTH FROM license.regis_date)", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            If _type_date = 1 Then
                _data = getDataChart(Page, "EXTRACT(year FROM license.receipt_date) as yy , EXTRACT(MONTH FROM license.receipt_date)", _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            Else
                _data = getDataChart(Page, "EXTRACT(year FROM travel_group.start_date) as yy , EXTRACT(MONTH FROM travel_group.start_date)", _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            End If

            pScriptAddChart = _data & " AddChart3(_data,_categories,'container',true,''); "

        ElseIf _type = "4" Then
            '4.ประเภทรถที่จดทะเบียน 5 ลำดับแรก
            lblHead.Text = "ประเทศรถที่จดทะเบียน 5 ลำดับแรก"
            _data = getDataChart(Page, "driver.countries", _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            pScriptAddChart = _data & " AddChart4(_data,'container'); "
            'CssChart = "style='min-width: 300px; max-width: 600px; min-height: 500px; margin: 0 auto'"

        ElseIf _type = "5" Then
            '5.จำนวนรถที่ขออนุญาตฯ เข้า-ออก จำแนกตามด่าน
            lblHead.Text = "จำนวนรถที่ได้รับอนุญาตฯ เข้า-ออก จำแนกตามด่าน"
            _data = getDataChart(Page, "border_checkin.border_nameth", _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            pScriptAddChart = _data & " AddChart5_1(_data,'container',true); "
            'CssChart = "style='min-width: 300px; max-width: 60%; min-height: 480px; margin: 0 auto'"

            _data = getDataChart(Page, "border_checkout.border_nameth", _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            pScriptAddChart = pScriptAddChart & _data & " AddChart5_2(_data,'container2',true); "

        ElseIf _type = "6" Then
            '6.จำนวนรถตามผู้ประกอบธุรกิจนำเที่ยวที่ยื่นขอฯ
            lblHead.Text = "จำนวนรถจำแนกตามผู้ประกอบธุรกิจนำเที่ยวที่ได้รับอนุญาตฯ"
            _data = getDataChart(Page, "coalesce(name_company,'ไม่ระบุ') as name_company, coalesce(type_car.type_name_th,'ไม่ระบุ') ", _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            pScriptAddChart = _data & " AddChart6(_data,_categories,'container',true,'','vertical','left','middle'); "

        ElseIf _type = "7" Then
            '7.จำนวนรถที่ขออนุญาต จำแนกตามประเภทรถ และรายเดือน
            lblHead.Text = "จำนวนรถที่ได้รับอนุญาต จำแนกตามประเภทรถ และรายเดือน"
            '_data = getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , EXTRACT(year FROM license.regis_date) as yy , EXTRACT(MONTH FROM license.regis_date)", _type, typeuser_id, _year, txtsdate, txtedate, _limit)
            If _type_date = 1 Then
                _data = getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , EXTRACT(year FROM license.receipt_date) as yy , EXTRACT(MONTH FROM license.receipt_date)", _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            Else
                _data = getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , EXTRACT(year FROM travel_group.start_date) as yy , EXTRACT(MONTH FROM travel_group.start_date)", _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            End If

            pScriptAddChart = _data & " AddChart7(_data,_categories,'container',true,''); "

        ElseIf _type = "8" Then
            'ด่านศุลกากรที่ขออนุญาตรถผ่านเข้า-ออก มากที่สุด 5 ลำดับแรก

        ElseIf _type = "9" Then
            'จำนวนรถที่ขออนุญาตเข้ามาในราชอาณาจักร จำแนกตามด่านศุลกากร
            lblHead.Text = "จำนวนรถที่ได้รับอนุญาตเข้ามาในราชอาณาจักร จำแนกตามด่านศุลกากร"
            _data = getDataChart(Page, " border_checkin.border_nameth", _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            pScriptAddChart = _data & " AddChart9(_data,_categories,'container',true,''); "

        ElseIf _type = "10" Then
            'ผู้ประกอบธุรกิจนำเที่ยวที่ขออนุญาตรถผ่านเข้า-ออก

        ElseIf _type = "11" Then
            'จำนวนรถที่ขออนุญาตฯ จำแนกตามสำนักงาน และประเภทรถ

        ElseIf _type = "12" Then
            'จำนวนรถที่ขออนุญาตฯ จำแนกตามสำนักงาน และประเภทรถ
            _data = getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(admin.admin_name,'ไม่ระบุ') ", 12, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            pScriptAddChart = pScriptAddChart & _data & " AddChart12(_data,_categories,'container',true,''); "

        ElseIf _type = "13" Then
            'จำนวนรถที่ขออนุญาตฯ จำแนกตามประเทศที่รถจดทะเบียน

        ElseIf _type = "14" Then
            'จำนวนรถที่ขออนุญาตฯ จำแนกตามประเทศที่รถจดทะเบียน
            _data = getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(driver.countries,'ไม่ระบุ') ", 14, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            pScriptAddChart = pScriptAddChart & _data & " AddChart12(_data,_categories,'container',true,''); "

        ElseIf _type = "15" Then
            'เปรียบเทียบจำนวนรถที่ขออนุญาต
            lblHead.Text = "เปรียบเทียบจำนวนรถที่ได้รับอนุญาตเข้ามาในราชอาณาจักร"
            '_data = getDataChart(Page, "EXTRACT(year FROM license.regis_date) as yy , EXTRACT(MONTH FROM license.regis_date) ", 15, typeuser_id, _year, txtsdate, txtedate, _limit)
            If _type_date = 1 Then
                _data = getDataChart(Page, "EXTRACT(year FROM license.receipt_date) as yy , EXTRACT(MONTH FROM license.receipt_date) ", 15, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            Else
                _data = getDataChart(Page, "EXTRACT(year FROM travel_group.start_date) as yy , EXTRACT(MONTH FROM travel_group.start_date) ", 15, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
            End If

            pScriptAddChart = pScriptAddChart & _data & " AddChart15(_data,_categories,'container',true,''); "

        End If


        If pAlert <> "" Then
            pScriptAddChart = " alert('" & pAlert & "'); " & pScriptAddChart
        End If

        Return pScriptAddChart
        'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> " & pScriptAddChart & " </script>", False)
    End Function

    Private tbChart As New DataTable
    Private Dt As DataTable
    Private pAlert As String
    Dim arr_s As Array
    Dim arr_e As Array
    Public Function getQueryChart(ByVal Page As Page, ByVal _Colname As String, ByVal _type As Object, ByVal typeuser_id As Integer, ByVal _year As Integer, _
                                  ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer) As DataTable
        Dim db As New DBConnect
        Try


            Dim strWhere As String = " where typeuser_id = " & typeuser_id & " and license.status_id = 5 "
            If Page.IsPostBack = False Then
                arr_s = {"01", "01", _year}
                arr_e = {Format(CInt(Now.Day), "00"), Format(CInt(Now.Month), "00"), _year}

                strWhere = strWhere & " and  travel_group.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
            Else
                If txtsdate.Text <> "" And txtedate.Text <> "" Then
                    arr_s = txtsdate.Text.Split("/")
                    arr_e = txtedate.Text.Split("/")

                    strWhere = strWhere & " and  travel_group.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                End If
            End If



            Dim strChart As String = ""
            If _type = "9" Then
                '--------------------------- get Data  2 series ------------------------------------
                strChart = "select sum(cnt_in) + sum(cnt_out) as cnt, sum(cnt_in) cnt_in , sum(cnt_out) cnt_out , _name from ( " & _
                    " select count(distinct car.car_id) cnt_in , 0 as cnt_out " & _
                    "  ,  coalesce(border_checkin.border_nameth,'ไม่ระบุ')  as _name  " & _
                    "  fROM license LEFT JOIN car on car.car_id = license.car_id   " & _
                    "  left join type_car on type_car.type_id = car.typecar_id  " & _
                    "  left join driver on driver.driver_id = license.driver_id  " '& _
                If typeuser_id = 2 Then
                    strChart = strChart & " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " & _
                        " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
                        "  left join border_check border_checkin on border_checkin.border_id = travel_group.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = travel_group.checkout_id  " & _
                        "  left join admin on admin.admin_id = travel_group.admin_id " & _
                        "  left join user_travel on user_travel.user_id = travel_group.user_id  " '& _
                Else
                    strChart = strChart & "  left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = license.checkout_id  " & _
                        "  left join admin on admin.admin_id = license.admin_id " '& _
                End If

                strChart = strChart & strWhere & _
                    "  group by  border_checkin.border_nameth " & _
                    " union all " & _
                    "  select 0 cnt_in , count(distinct car.car_id) cnt_out " & _
                    "  ,  coalesce(border_checkout.border_nameth,'ไม่ระบุ')  as _name  " & _
                    "  fROM license LEFT JOIN car on car.car_id = license.car_id   " & _
                    "  left join type_car on type_car.type_id = car.typecar_id  " & _
                    "  left join driver on driver.driver_id = license.driver_id  " '& _
                If typeuser_id = 2 Then
                    strChart = strChart & " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " & _
                        " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
                        "  left join border_check border_checkin on border_checkin.border_id = travel_group.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = travel_group.checkout_id  " & _
                        "  left join admin on admin.admin_id = travel_group.admin_id " & _
                        "  left join user_travel on user_travel.user_id = travel_group.user_id  " '& _
                Else
                    strChart = strChart & "  left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = license.checkout_id  " & _
                        "  left join admin on admin.admin_id = license.admin_id " '& _
                End If

                strChart = strChart & strWhere & _
                    "  group by  border_checkout.border_nameth " & _
                    " ) dt group by  _name "
            Else
                '--------------------------- get Data ------------------------------------
                strChart = " select count(distinct car.car_id) cnt , " & _Colname & " as _name " & _
                   " fROM license LEFT JOIN car on car.car_id = license.car_id  " & _
                   " left join type_car on type_car.type_id = car.typecar_id " & _
                   " left join driver on driver.driver_id = license.driver_id " '& _
                If typeuser_id = 2 Then
                    strChart = strChart & " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " & _
                        " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
                        "  left join border_check border_checkin on border_checkin.border_id = travel_group.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = travel_group.checkout_id  " & _
                        "  left join admin on admin.admin_id = travel_group.admin_id " & _
                        "  left join user_travel on user_travel.user_id = travel_group.user_id  " '& _
                Else
                    strChart = strChart & "  left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = license.checkout_id  " & _
                        "  left join admin on admin.admin_id = license.admin_id " '& _
                End If

                strChart = strChart & strWhere

                If _type = "8" Then
                    'ด่านศุลกากรที่ขออนุญาตรถผ่านเข้า-ออก มากที่สุด 5 ลำดับแรก
                    Dim _col As String = _Colname.ToString.Replace("coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type ,", "")
                    strChart = strChart & " and coalesce(" & _col & ",'') in (select coalesce(" & _col & ",'') from license LEFT JOIN car on car.car_id = license.car_id " '& _
                    If typeuser_id = 2 Then
                        strChart = strChart & " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " & _
                            " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
                            "  left join border_check border_checkin on border_checkin.border_id = travel_group.checkin_id  " & _
                            "  left join border_check border_checkout on border_checkout.border_id = travel_group.checkout_id  " '& _

                    Else
                        strChart = strChart & "  left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                            "  left join border_check border_checkout on border_checkout.border_id = license.checkout_id  " '& _
                    End If
                    strChart = strChart & strWhere & " group by " & _col & " order by count(distinct car.car_id) desc " & If(_limit > 0, " limit " & _limit, "") & ") "
                ElseIf _type = "10" Then
                    'ผู้ประกอบการธุรกิจนำเที่ยว จากมากไปน้อย 10 ลำดับแรก
                    strChart = strChart & " and coalesce(license.travel_id,0) in (select coalesce(license.travel_id,0) from license LEFT JOIN car on car.car_id = license.car_id " & _
                               strWhere & " group by license.travel_id order by count(distinct car.car_id) desc " & If(_limit > 0, " limit " & _limit, "") & ") "
                End If

                strChart = strChart & " group by " & _Colname.ToString.Replace("as name_company", "").Replace("as yy", "").Replace("as car_type", "").ToString.Replace("count(distinct license.driver_id ) cntdriver ,", "") & " "
            End If
            tbChart = db.getDataTable(strChart, "dataChart")

            If _type = "6" Then
                'เรียงผู้ประกอบธุรกิจนำเที่ยว จากมากไปน้อย 5 ลำดับแรก
                Dim strChartSum As String = strChart.ToString.Replace(", coalesce(type_car.type_name_th,'ไม่ระบุ')  as _name", "").ToString.Replace(", coalesce(type_car.type_name_th,'ไม่ระบุ')", "")
                Dt = db.getDataTable(strChartSum & " order by cnt desc " & If(_limit > 0, " limit " & _limit, ""), "dataChart")

            ElseIf _type = "8" Or _type = "10" Then
                Dim strChartSum As String = strChart.ToString.Replace("coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type ,", "").ToString.Replace("coalesce(type_car.type_name_th,'ไม่ระบุ')  ,", "")
                Dt = db.getDataTable(strChartSum & " order by cnt desc " & If(_limit > 0, " limit " & _limit, ""), "dataChart")

            ElseIf _type = "11" Or _type = "12" Or _type = "13" Or _type = "14" Then
                Dim strChartSum As String = strChart.ToString.Replace("coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type ,", "").ToString.Replace("coalesce(type_car.type_name_th,'ไม่ระบุ')  ,", "")
                Dt = db.getDataTable(strChartSum & " order by cnt desc " & If(_limit > 0, " limit " & _limit, ""), "dataChart")

            End If


            Return tbChart
        Catch ex As Exception

        Finally
            db = Nothing
        End Try

    End Function

    Public Function getQueryChart(ByVal Page As Page, ByVal _Colname As String, ByVal _type As Object, ByVal typeuser_id As Integer, ByVal _year As Integer, _
                                  ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer, ByVal _type_date As Integer) As DataTable
        Dim db As New DBConnect
        Try

            Dim strWhere As String = " where typeuser_id = " & typeuser_id & " and license.status_id = 5 "
            If Page.IsPostBack = False Then
                arr_s = {"01", "01", _year}
                arr_e = {Format(CInt(Now.Day), "00"), Format(CInt(Now.Month), "00"), _year}

                If _type_date = 1 Then
                    strWhere = strWhere & " and  license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                Else
                    strWhere = strWhere & " and  travel_group.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                End If

            Else
                If txtsdate.Text <> "" And txtedate.Text <> "" Then
                    arr_s = txtsdate.Text.Split("/")
                    arr_e = txtedate.Text.Split("/")

                    If _type_date = 1 Then
                        strWhere = strWhere & " and  license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                    Else
                        strWhere = strWhere & " and  travel_group.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                    End If

                End If
            End If

            Dim strWhere_old As String = " where typeuser_id = " & typeuser_id & " and license.status_id = 5 "
            If Page.IsPostBack = False Then
                arr_s = {"01", "01", _year}
                arr_e = {Format(CInt(Now.Day), "00"), Format(CInt(Now.Month), "00"), _year}

                If _type_date = 1 Then
                    strWhere_old = strWhere_old & " and  license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                Else
                    strWhere_old = strWhere_old & " and  license.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                End If

            Else
                If txtsdate.Text <> "" And txtedate.Text <> "" Then
                    arr_s = txtsdate.Text.Split("/")
                    arr_e = txtedate.Text.Split("/")

                    If _type_date = 1 Then
                        strWhere_old = strWhere_old & " and  license.receipt_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                    Else
                        strWhere_old = strWhere_old & " and  license.start_date between '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' and '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "'"
                    End If

                End If
            End If



            Dim strChart As String = ""
            If _type = "9" Then
                '--------------------------- get Data  2 series ------------------------------------
                strChart = "select sum(cnt_in) + sum(cnt_out) as cnt, sum(cnt_in) cnt_in , sum(cnt_out) cnt_out , _name from ( " & _
                    " select count(distinct car.car_id) cnt_in , 0 as cnt_out " & _
                    "  ,  coalesce(border_checkin.border_nameth,'ไม่ระบุ')  as _name  " & _
                    "  fROM license LEFT JOIN car on car.car_id = license.car_id   " & _
                    "  left join type_car on type_car.type_id = car.typecar_id  " & _
                    "  left join driver on driver.driver_id = license.driver_id  " '& _
                If typeuser_id = 2 Then
                    strChart = strChart & " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " & _
                        " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
                        "  left join border_check border_checkin on border_checkin.border_id = travel_group.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = travel_group.checkout_id  " & _
                        "  left join admin on admin.admin_id = travel_group.admin_id " & _
                        "  left join user_travel on user_travel.user_id = travel_group.user_id  " '& _
                Else
                    strChart = strChart & "  left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = license.checkout_id  " & _
                        "  left join admin on admin.admin_id = license.admin_id " '& _
                End If

                strChart = strChart & strWhere & _
                    "  group by  border_checkin.border_nameth " & _
                    " union all " & _
                    "  select 0 cnt_in , count(distinct car.car_id) cnt_out " & _
                    "  ,  coalesce(border_checkout.border_nameth,'ไม่ระบุ')  as _name  " & _
                    "  fROM license LEFT JOIN car on car.car_id = license.car_id   " & _
                    "  left join type_car on type_car.type_id = car.typecar_id  " & _
                    "  left join driver on driver.driver_id = license.driver_id  " '& _
                If typeuser_id = 2 Then
                    strChart = strChart & " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " & _
                        " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
                        "  left join border_check border_checkin on border_checkin.border_id = travel_group.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = travel_group.checkout_id  " & _
                        "  left join admin on admin.admin_id = travel_group.admin_id " & _
                        "  left join user_travel on user_travel.user_id = travel_group.user_id  " '& _
                Else
                    strChart = strChart & "  left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = license.checkout_id  " & _
                        "  left join admin on admin.admin_id = license.admin_id " '& _
                End If

                strChart = strChart & strWhere & _
                    "  group by  border_checkout.border_nameth " & _
                    " union all " & _
                    " select count(distinct license.license_id) cnt_in , 0 as cnt_out " & _
                    "  ,  coalesce(border_checkin.border_nameth,'ไม่ระบุ')  as _name  " & _
                    "  fROM license_old license " & _
                    "  left join type_car on type_car.type_id = license.typecar_id  " & _
                    "  left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                    "  left join border_check border_checkout on border_checkout.border_id = license.checkout_id  " & _
                    "  left join admin on admin.admin_id = license.admin_id " & _
                    "  left join user_travel on user_travel.user_id = license.travel_id "

                strChart = strChart & strWhere_old & _
                    "  group by  border_checkin.border_nameth " & _
                    " union all " & _
                    "  select 0 cnt_in , count(distinct license.license_id) cnt_out " & _
                    "  ,  coalesce(border_checkout.border_nameth,'ไม่ระบุ')  as _name  " & _
                    "  fROM license_old license " & _
                    "  left join type_car on type_car.type_id = license.typecar_id  " & _
                    "  left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                    "  left join border_check border_checkout on border_checkout.border_id = license.checkout_id  " & _
                    "  left join admin on admin.admin_id = license.admin_id " & _
                    "  left join user_travel on user_travel.user_id = license.travel_id "

                strChart = strChart & strWhere_old & _
                    "  group by  border_checkout.border_nameth " & _
                    " ) dt group by  _name "
            Else
                '--------------------------- get Data ------------------------------------
                If _type = "3" Or _type = "15" Then
                    strChart = "select sum(cnt) as cnt , yy, _name from ( "
                ElseIf _type = "6" Then
                    strChart = "select sum(cnt) as cnt , name_company, _name from ( "
                ElseIf _type = "7" Then
                    strChart = "select sum(cnt) as cnt , car_type, yy, _name from ( "
                ElseIf _type = "8" Or _type = "10" Or _type = "11" Or _type = "12" Or _type = "13" Or _type = "14" Then
                    strChart = "select sum(cnt) as cnt , car_type, _name from ( "
                Else
                    strChart = "select sum(cnt) as cnt , _name from ( "
                End If

                strChart = strChart & " select count(distinct car.car_id) cnt , " & _Colname & " as _name " & _
                   " fROM license LEFT JOIN car on car.car_id = license.car_id  " & _
                   " left join type_car on type_car.type_id = car.typecar_id " & _
                   " left join driver on driver.driver_id = license.driver_id " '& _
                If typeuser_id = 2 Then
                    strChart = strChart & " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " & _
                        " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
                        "  left join border_check border_checkin on border_checkin.border_id = travel_group.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = travel_group.checkout_id  " & _
                        "  left join admin on admin.admin_id = travel_group.admin_id " & _
                        "  left join user_travel on user_travel.user_id = travel_group.user_id  " '& _
                Else
                    strChart = strChart & "  left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                        "  left join border_check border_checkout on border_checkout.border_id = license.checkout_id  " & _
                        "  left join admin on admin.admin_id = license.admin_id " '& _
                End If

                strChart = strChart & strWhere

                If _type = "8" Then
                    'ด่านศุลกากรที่ขออนุญาตรถผ่านเข้า-ออก มากที่สุด 5 ลำดับแรก
                    Dim _col As String = _Colname.ToString.Replace("coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type ,", "")
                    strChart = strChart & " and coalesce(" & _col & ",'') in (select coalesce(" & _col & ",'') from license LEFT JOIN car on car.car_id = license.car_id " '& _
                    If typeuser_id = 2 Then
                        strChart = strChart & " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " & _
                            " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
                            "  left join border_check border_checkin on border_checkin.border_id = travel_group.checkin_id  " & _
                            "  left join border_check border_checkout on border_checkout.border_id = travel_group.checkout_id  " '& _

                    Else
                        strChart = strChart & "  left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                            "  left join border_check border_checkout on border_checkout.border_id = license.checkout_id  " '& _
                    End If
                    strChart = strChart & strWhere & " group by " & _col & " order by count(distinct car.car_id) desc " & If(_limit > 0, " limit " & _limit, "") & ") "
                ElseIf _type = "10" Then
                    'ผู้ประกอบการธุรกิจนำเที่ยว จากมากไปน้อย 10 ลำดับแรก
                    strChart = strChart & " and coalesce(license.travel_id,0) in (select coalesce(license.travel_id,0) from license LEFT JOIN car on car.car_id = license.car_id " & _
                               strWhere & " group by license.travel_id order by count(distinct car.car_id) desc " & If(_limit > 0, " limit " & _limit, "") & ") "
                End If

                strChart = strChart & " group by " & _Colname.ToString.Replace("as name_company", "").Replace("as yy", "").Replace("as car_type", "").ToString.Replace("count(distinct license.driver_id ) cntdriver ,", "") & " "
                'If _type = "1" Then
                If _type = "3" Then

                    If _type_date = 1 Then
                        strChart = strChart & "union all " & _
                                                    " select count(distinct license.license_id) cnt , EXTRACT(year FROM license.receipt_date) as yy , EXTRACT(MONTH FROM license.receipt_date) as _name " & _
                                                    " fROM license_old license left join type_car on type_car.type_id = license.typecar_id  " & _
                                                    " left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                                                    " left join border_check border_checkout on border_checkout.border_id = license.checkout_id " & _
                                                    " left join admin on admin.admin_id = license.admin_id " & _
                                                    " left join user_travel on user_travel.user_id = license.travel_id "
                        strChart = strChart & strWhere_old
                        strChart = strChart & " group by EXTRACT(year FROM license.receipt_date) , EXTRACT(MONTH FROM license.receipt_date) "
                    Else
                        strChart = strChart & "union all " & _
                                                    " select count(distinct license.license_id) cnt , EXTRACT(year FROM license.start_date) as yy , EXTRACT(MONTH FROM license.start_date) as _name " & _
                                                    " fROM license_old license left join type_car on type_car.type_id = license.typecar_id  " & _
                                                    " left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                                                    " left join border_check border_checkout on border_checkout.border_id = license.checkout_id " & _
                                                    " left join admin on admin.admin_id = license.admin_id " & _
                                                    " left join user_travel on user_travel.user_id = license.travel_id "
                        strChart = strChart & strWhere_old
                        strChart = strChart & " group by EXTRACT(year FROM license.start_date) , EXTRACT(MONTH FROM license.start_date) "
                    End If

                ElseIf _type = "4" Then
                    strChart = strChart & "union all " & _
                                                        " select count(distinct license.license_id) cnt , license.country_car as _name " & _
                                                        " fROM license_old license left join type_car on type_car.type_id = license.typecar_id  " & _
                                                        " left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                                                        " left join border_check border_checkout on border_checkout.border_id = license.checkout_id " & _
                                                        " left join admin on admin.admin_id = license.admin_id " & _
                                                        " left join user_travel on user_travel.user_id = license.travel_id "
                    strChart = strChart & strWhere_old
                    strChart = strChart & " group by license.country_car "
                ElseIf _type = "7" Then
                    strChart = strChart & "union all " & _
                                                        " select count(distinct license.license_id) cnt , coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , EXTRACT(year FROM license.start_date) as yy , EXTRACT(MONTH FROM license.start_date) as _name " & _
                                                        " fROM license_old license left join type_car on type_car.type_id = license.typecar_id  " & _
                                                        " left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                                                        " left join border_check border_checkout on border_checkout.border_id = license.checkout_id " & _
                                                        " left join admin on admin.admin_id = license.admin_id " & _
                                                        " left join user_travel on user_travel.user_id = license.travel_id "
                    strChart = strChart & strWhere_old
                    strChart = strChart & " group by  coalesce(type_car.type_name_th,'ไม่ระบุ') , EXTRACT(year FROM license.start_date) , EXTRACT(MONTH FROM license.start_date) "
                ElseIf _type = "11" Then
                    strChart = strChart & "union all " & _
                                                        " select count(distinct license.license_id) cnt , count(distinct license.license_id ) cntdriver , coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(admin.admin_name,'ไม่ระบุ')  as _name " & _
                                                        " fROM license_old license left join type_car on type_car.type_id = license.typecar_id  " & _
                                                        " left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                                                        " left join border_check border_checkout on border_checkout.border_id = license.checkout_id " & _
                                                        " left join admin on admin.admin_id = license.admin_id " & _
                                                        " left join user_travel on user_travel.user_id = license.travel_id "
                    strChart = strChart & strWhere_old
                    strChart = strChart & " group by coalesce(type_car.type_name_th,'ไม่ระบุ') , coalesce(admin.admin_name,'ไม่ระบุ') "
                ElseIf _type = "13" Or _type = "14" Then
                    strChart = strChart & "union all " & _
                                                        " select count(distinct license.license_id) cnt, coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(license.country_car,'ไม่ระบุ')  as _name " & _
                                                        " fROM license_old license left join type_car on type_car.type_id = license.typecar_id  " & _
                                                        " left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                                                        " left join border_check border_checkout on border_checkout.border_id = license.checkout_id " & _
                                                        " left join admin on admin.admin_id = license.admin_id " & _
                                                        " left join user_travel on user_travel.user_id = license.travel_id "
                    strChart = strChart & strWhere_old
                    strChart = strChart & " group by coalesce(type_car.type_name_th,'ไม่ระบุ') , coalesce(license.country_car,'ไม่ระบุ')  "
                Else
                    strChart = strChart & "union all " & _
                                                            " select count(distinct license.license_id) cnt , " & _Colname.Replace("travel_group", "license") & " as _name " & _
                                                            " fROM license_old license left join type_car on type_car.type_id = license.typecar_id  " & _
                                                            " left join border_check border_checkin on border_checkin.border_id = license.checkin_id  " & _
                                                            " left join border_check border_checkout on border_checkout.border_id = license.checkout_id " & _
                                                            " left join admin on admin.admin_id = license.admin_id " & _
                                                            " left join user_travel on user_travel.user_id = license.travel_id "
                    strChart = strChart & strWhere_old
                    strChart = strChart & " group by " & _Colname.ToString.Replace("as name_company", "").Replace("as yy", "").Replace("as car_type", "").Replace("travel_group", "license").Replace("count(distinct license.driver_id ) cntdriver ,", "") & " "

                End If


                If _type = "3" Or _type = "15" Then
                    strChart = strChart & ") dt group by  yy, _name "
                ElseIf _type = "6" Then
                    strChart = strChart & ") dt group by  name_company, _name "
                ElseIf _type = "7" Then
                    strChart = strChart & ") dt group by  car_type, yy, _name "
                ElseIf _type = "8" Or _type = "10" Or _type = "11" Or _type = "12" Or _type = "13" Or _type = "14" Then
                    strChart = strChart & ") dt group by car_type, _name "
                Else
                    strChart = strChart & ") dt group by _name "
                End If

            End If
            tbChart = db.getDataTable(strChart, "dataChart")

            If _type = "6" Then
                'เรียงผู้ประกอบธุรกิจนำเที่ยว จากมากไปน้อย 5 ลำดับแรก
                'Dim strChartSum As String = strChart.ToString.Replace(", coalesce(type_car.type_name_th,'ไม่ระบุ')  as _name", "").ToString.Replace(", coalesce(type_car.type_name_th,'ไม่ระบุ')", "")
                Dim strChartSum As String = strChart.ToString.Replace(", _name", "")
                Dt = db.getDataTable(strChartSum & " order by cnt desc " & If(_limit > 0, " limit " & _limit, ""), "dataChart")

            ElseIf _type = "8" Or _type = "10" Then
                'Dim strChartSum As String = strChart.ToString.Replace("coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type ,", "").ToString.Replace("coalesce(type_car.type_name_th,'ไม่ระบุ')  ,", "")
                Dim strChartSum As String = strChart.ToString.Replace("car_type,", "")
                Dt = db.getDataTable(strChartSum & " order by cnt desc " & If(_limit > 0, " limit " & _limit, ""), "dataChart")

            ElseIf _type = "11" Or _type = "12" Or _type = "13" Or _type = "14" Then
                'Dim strChartSum As String = strChart.ToString.Replace("coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type ,", "").ToString.Replace("coalesce(type_car.type_name_th,'ไม่ระบุ')  ,", "")
                Dim strChartSum As String = strChart.ToString.Replace("car_type,", "")
                Dt = db.getDataTable(strChartSum & " order by cnt desc " & If(_limit > 0, " limit " & _limit, ""), "dataChart")

            End If


            Return tbChart
        Catch ex As Exception

        Finally
            db = Nothing
        End Try

    End Function

    Public Function getDataChart(ByVal Page As Page, ByVal _Colname As String, ByVal _type As Object, ByVal typeuser_id As Integer, ByVal _year As Integer, _
                                  ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer) As String
        Dim _data As String = ""
        Dim _categories As String = ""
        Try
            tbChart = getQueryChart(Page, _Colname, _type, typeuser_id, _year, txtsdate, txtedate, _limit)

            If tbChart.Rows.Count > 0 Then
                Dim pToTal As Double = tbChart.Compute("Sum(cnt)", "").ToString()
                Dim IsFirst As Integer = 1

                If _type = "3" Or _type = "7" Or _type = "15" Then
                    '--------------------------- Add Data & Categories ------------------------------------
                    For yy As Integer = arr_s(2) To arr_e(2)
                        For i As Integer = IIf(yy = arr_s(2), arr_s(1), 1) To IIf(yy = arr_e(2), arr_e(1), 12)
                            If _categories = "" Then
                                _categories = " var _categories = [ '" & getMonthName(i, "th") & " " & yy.ToString & "' "
                            Else
                                _categories = _categories & ", '" & getMonthName(i, "th") & " " & yy.ToString & "' "
                            End If

                            If _type = "7" Then
                                ''จำแนกตามประเภทรถ และรายเดือน

                            Else
                                'จำแนกรายเดือน อย่างเดียว
                                Dim _cnt As Object = "0"
                                Try
                                    _cnt = tbChart.Compute("Sum(cnt)", "_name = " & i & " and yy = " & yy).ToString()
                                Catch ex As Exception

                                End Try

                                If _cnt = "" Then
                                    _cnt = "0"
                                End If
                                If _data = "" Then
                                    _data = " var _data = [" & _cnt
                                Else
                                    _data = _data & " , " & _cnt
                                End If
                            End If
                        Next
                    Next
                    _categories = _categories & "]; "
                    If _type = "7" Then
                        'จำแนกตามประเภทรถ และรายเดือน

                        Dim Ar As String() = {"car_type"}
                        Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, Ar)
                        For Each drCar As DataRow In DtCar.Select("", "car_type")
                            Dim strdata = " { name: '" & drCar("car_type") & "', data: [ "
                            Dim x As Integer = 1
                            For yy As Integer = arr_s(2) To arr_e(2)
                                For i As Integer = IIf(yy = arr_s(2), arr_s(1), 1) To IIf(yy = arr_e(2), arr_e(1), 12)
                                    If x = 1 Then

                                    Else
                                        strdata = strdata & ", "
                                    End If
                                    Try
                                        Dim sum As Decimal = tbChart.Compute("Sum(cnt)", "car_type = '" & drCar("car_type") & "' and _name = " & i & " and yy = " & yy).ToString()
                                        strdata = strdata & sum
                                    Catch ex As Exception
                                        strdata = strdata & 0
                                    End Try
                                    x = x + 1
                                Next
                            Next
                            strdata = strdata & "]}"
                            If _data = "" Then
                                _data = " var _data = [" & strdata
                            Else
                                _data = _data & " , " & strdata
                            End If
                        Next
                        _data = _data & "]; "
                    Else
                        'จำแนกรายเดือน อย่างเดียว
                        _data = _data & "]; "
                    End If



                ElseIf _type = "6" Then
                    '--------------------------- Add Data & Categories  & 2Chart (Column & Line) ------------------------------------

                    For Each dr As DataRow In Dt.Select("", "cnt desc")
                        If _categories = "" Then
                            _categories = " var _categories = [ '" & dr("name_company") & "' "
                        Else
                            _categories = _categories & ", '" & dr("name_company") & "' "
                        End If
                    Next
                    _categories = _categories & "]; "


                    Dim ArSeries As String() = {"_name"}
                    Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, ArSeries)
                    Dim CurName As String = ""

                    For Each dr As DataRow In tbChart.Select("", "_name")
                        Dim strdata As String = " { type: 'column',name: '" & dr("_name") & "',  data: [" ' & dr("cnt") & ", 2, 1, 3, 4]  } "
                        Dim x As Integer = 1
                        For Each drG As DataRow In Dt.Select("", "cnt desc")
                            If x = 1 Then

                            Else
                                strdata = strdata & ", "
                            End If
                            Try
                                Dim sum As Decimal = tbChart.Compute("Sum(cnt)", "_name = '" & dr("_name") & "' and name_company = '" & drG("name_company") & "' ").ToString()
                                strdata = strdata & sum
                            Catch ex As Exception
                                strdata = strdata & 0
                            End Try
                            x = x + 1
                        Next
                        strdata = strdata & "]}"
                        If CurName <> dr("_name") Then
                            If _data = "" Then
                                _data = " var _data = [ " & strdata
                            Else
                                _data = _data & " , " & strdata
                            End If
                            CurName = dr("_name")
                        End If
                    Next
                    _data = _data & " , { type: 'spline', name:'รวม', data: [" '3, 2.67, 3, 6.33, 3.33"
                    Dim x1 As Integer = 1
                    For Each dr As DataRow In Dt.Select("", "cnt desc")
                        If x1 = 1 Then

                        Else
                            _data = _data & ", "
                        End If
                        Try
                            _data = _data & dr("cnt")
                        Catch ex As Exception
                            _data = _data & 0
                        End Try
                        x1 = x1 + 1
                    Next
                    _data = _data & "], marker: { lineWidth: 2, lineColor: Highcharts.getOptions().colors[3],fillColor:  'white' } }]; "

                ElseIf _type = "9" Then


                    Dim strdataIn As String = " { name: 'ขาเข้า ', data: [ "
                    Dim strdataOut As String = " { name: 'ขาออก ', data: [ "
                    For Each dr As DataRow In tbChart.Select("", "cnt desc")
                        If _categories = "" Then
                            _categories = " var _categories = [ '" & dr("_name").ToString.Replace("ด่านพรมแดน", "") & "' "
                        Else
                            _categories = _categories & ", '" & dr("_name").ToString.Replace("ด่านพรมแดน", "") & "' "
                        End If

                        If IsFirst = 1 Then

                        Else
                            strdataIn = strdataIn & ","
                            strdataOut = strdataOut & ","
                        End If
                        Try
                            Dim sum_in As Decimal = tbChart.Compute("Sum(cnt_in)", "_name = '" & dr("_name") & "' ").ToString()
                            Dim sum_out As Decimal = tbChart.Compute("Sum(cnt_out)", "_name = '" & dr("_name") & "' ").ToString()
                            strdataIn = strdataIn & sum_in
                            strdataOut = strdataOut & sum_out
                        Catch ex As Exception
                            strdataIn = strdataIn & 0
                            strdataOut = strdataOut & 0
                        End Try
                        IsFirst = IsFirst + 1
                    Next
                    _categories = _categories & "]; "
                    strdataIn = strdataIn & "] }  "
                    strdataOut = strdataOut & "] }  "


                    _data = _data & " var _data = [ " & strdataIn & ", " & strdataOut & " ];"
                ElseIf _type = "12" Or _type = "14" Then
                    '_categories = " var _categories = [ 'Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep','Oct','Nov', 'Dec']; "
                    For Each dr As DataRow In Dt.Select("", "cnt desc")
                        If _categories = "" Then
                            _categories = " var _categories = [ '" & dr("_name").ToString.Replace("สำนักงานขนส่งจังหวัด", "สขจ.").ToString.Replace("สำนักงานขนส่งกรุงเทพมหานครพื้นที่", "สขพ.") & "' "
                        Else
                            _categories = _categories & ", '" & dr("_name").ToString.Replace("สำนักงานขนส่งจังหวัด", "สขจ.").ToString.Replace("สำนักงานขนส่งกรุงเทพมหานครพื้นที่", "สขพ.") & "' "
                        End If
                    Next
                    _categories = _categories & "]; "


                    Dim ArSeries As String() = {"car_type"}
                    Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, ArSeries)
                    Dim CurCar As String = ""
                    For Each dr As DataRow In DtCar.Select("", "car_type")
                        Dim strdata As String = " { name: '" & dr("car_type") & "', data: [ "
                        Dim x As Integer = 1
                        For Each drCat As DataRow In Dt.Select("", "cnt desc")
                            If x = 1 Then

                            Else
                                strdata = strdata & ", "
                            End If
                            Try
                                Dim sum As Decimal = tbChart.Compute("Sum(cnt)", "car_type = '" & dr("car_type") & "' and _name = '" & drCat("_name") & "' ").ToString()
                                strdata = strdata & sum
                            Catch ex As Exception
                                strdata = strdata & 0
                            End Try
                            x = x + 1
                        Next
                        strdata = strdata & "] } "

                        If _data = "" Then
                            _data = " var _data = [ " & strdata
                        Else
                            _data = _data & " , " & strdata
                        End If
                    Next
                    _data = _data & "]; "

                Else
                    '--------------------------- Add Data ------------------------------------
                    For Each dr As DataRow In tbChart.Select("", "cnt desc")
                        Dim _name As String = "ไม่ระบุ"
                        Dim _th As String = "ไม่ระบุ"
                        If Not dr("_name") Is DBNull.Value Then
                            _name = dr("_name")
                            _th = dr("_name").ToString.Replace("สำนักงานขนส่งจังหวัด", "สขจ.").ToString.Replace("สำนักงานขนส่งกรุงเทพมหานครพื้นที่", "สขพ.")
                        End If

                        If _type = "5" Then
                            _name = _name.ToString.Replace("ด่านพรมแดน", "")
                        End If

                        Dim _Percent As Double = Format(CDbl((dr("cnt") / pToTal) * 100), "##0.00")
                        If IsFirst = 1 Then
                            If _type = "1" Then
                                _th = _th & " มีรถที่ได้รับอนุญาตมากที่สุด <br><b>จำนวน " & dr("cnt") & " คัน </b>  <b> (ร้อยละ " & _Percent & ")</b>"
                            End If
                        Else
                            If _type = "1" Then
                                _th = _th & " <br><b>จำนวน " & dr("cnt") & " คัน </b> "
                            End If
                        End If


                        If _data = "" Then
                            _data = " var _data = [ { name: '" & _name & "' , th: '" & _th & "', y: " & dr("cnt") & " , z: " & _Percent & " } "
                        Else
                            _data = _data & " ,   { name: '" & _name & "' , th: '" & _th & "', y: " & dr("cnt") & " , z: " & _Percent & "  } "
                        End If

                        If _type = "4" Or _type = "5" Then
                            'เอาแค่ 5 ลำดับแรก
                            If IsFirst = 5 Then
                                Exit For
                            End If
                        End If
                        IsFirst = IsFirst + 1
                    Next
                    _data = _data & " ];"
                End If
            Else
                pAlert = "ไม่พบข้อมูลดังกล่าว กรุณาเลือกวันที่ให้ถูกต้อง!!!"
                _data = " var _data = [ { name: 'ไม่ระบุ' , th: 'ไม่ระบุ' , y: 0  , z: 0 }]; "
            End If

            Return _data & _categories
        Catch ex As Exception
            pAlert = "ไม่พบข้อมูลดังกล่าว !!!"
            Return " var _data = [ { name: 'ไม่ระบุ' , th: 'ไม่ระบุ' , y: 0  , z: 0 }]; "

        End Try
    End Function

    Public Function getDataChart(ByVal Page As Page, ByVal _Colname As String, ByVal _type As Object, ByVal typeuser_id As Integer, ByVal _year As Integer, _
                                  ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer, ByVal _type_date As Integer) As String
        Dim _data As String = ""
        Dim _categories As String = ""
        Try
            tbChart = getQueryChart(Page, _Colname, _type, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)

            If tbChart.Rows.Count > 0 Then
                Dim pToTal As Double = tbChart.Compute("Sum(cnt)", "").ToString()
                Dim IsFirst As Integer = 1

                If _type = "3" Or _type = "7" Or _type = "15" Then
                    '--------------------------- Add Data & Categories ------------------------------------
                    For yy As Integer = arr_s(2) To arr_e(2)
                        For i As Integer = IIf(yy = arr_s(2), arr_s(1), 1) To IIf(yy = arr_e(2), arr_e(1), 12)
                            If _categories = "" Then
                                _categories = " var _categories = [ '" & getMonthName(i, "th") & " " & yy.ToString & "' "
                            Else
                                _categories = _categories & ", '" & getMonthName(i, "th") & " " & yy.ToString & "' "
                            End If

                            If _type = "7" Then
                                ''จำแนกตามประเภทรถ และรายเดือน

                            Else
                                'จำแนกรายเดือน อย่างเดียว
                                Dim _cnt As Object = "0"
                                Try
                                    _cnt = tbChart.Compute("Sum(cnt)", "_name = " & i & " and yy = " & yy).ToString()
                                Catch ex As Exception

                                End Try

                                If _cnt = "" Then
                                    _cnt = "0"
                                End If
                                If _data = "" Then
                                    _data = " var _data = [" & _cnt
                                Else
                                    _data = _data & " , " & _cnt
                                End If
                            End If
                        Next
                    Next
                    _categories = _categories & "]; "
                    If _type = "7" Then
                        'จำแนกตามประเภทรถ และรายเดือน


                        Dim Ar As String() = {"car_type"}
                        Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, Ar)
                        For Each drCar As DataRow In DtCar.Select("", "car_type")
                            Dim strdata = " { name: '" & drCar("car_type") & "', data: [ "
                            Dim x As Integer = 1
                            For yy As Integer = arr_s(2) To arr_e(2)
                                For i As Integer = IIf(yy = arr_s(2), arr_s(1), 1) To IIf(yy = arr_e(2), arr_e(1), 12)
                                    If x = 1 Then

                                    Else
                                        strdata = strdata & ", "
                                    End If
                                    Try
                                        Dim sum As Decimal = tbChart.Compute("Sum(cnt)", "car_type = '" & drCar("car_type") & "' and _name = " & i & " and yy = " & yy).ToString()
                                        strdata = strdata & sum
                                    Catch ex As Exception
                                        strdata = strdata & 0
                                    End Try
                                    x = x + 1
                                Next
                            Next
                            strdata = strdata & "]}"
                            If _data = "" Then
                                _data = " var _data = [" & strdata
                            Else
                                _data = _data & " , " & strdata
                            End If
                        Next
                        _data = _data & "]; "
                    Else
                        'จำแนกรายเดือน อย่างเดียว
                        _data = _data & "]; "
                    End If



                ElseIf _type = "6" Then
                    '--------------------------- Add Data & Categories  & 2Chart (Column & Line) ------------------------------------

                    For Each dr As DataRow In Dt.Select("", "cnt desc")
                        If _categories = "" Then
                            _categories = " var _categories = [ '" & dr("name_company") & "' "
                        Else
                            _categories = _categories & ", '" & dr("name_company") & "' "
                        End If
                    Next
                    _categories = _categories & "]; "


                    Dim ArSeries As String() = {"_name"}
                    Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, ArSeries)
                    Dim CurName As String = ""

                    For Each dr As DataRow In tbChart.Select("", "_name")
                        Dim strdata As String = " { type: 'column',name: '" & dr("_name") & "',  data: ["
                        Dim x As Integer = 1
                        For Each drG As DataRow In Dt.Select("", "cnt desc")
                            If x = 1 Then

                            Else
                                strdata = strdata & ", "
                            End If
                            Try
                                Dim sum As Decimal = tbChart.Compute("Sum(cnt)", "_name = '" & dr("_name") & "' and name_company = '" & drG("name_company") & "' ").ToString()
                                strdata = strdata & sum
                            Catch ex As Exception
                                strdata = strdata & 0
                            End Try
                            x = x + 1
                        Next
                        strdata = strdata & "]}"
                        If CurName <> dr("_name") Then
                            If _data = "" Then
                                _data = " var _data = [ " & strdata
                            Else
                                _data = _data & " , " & strdata
                            End If
                            CurName = dr("_name")
                        End If
                    Next
                    _data = _data & " , { type: 'spline', name:'รวม', data: [" '3, 2.67, 3, 6.33, 3.33"
                    Dim x1 As Integer = 1
                    For Each dr As DataRow In Dt.Select("", "cnt desc")
                        If x1 = 1 Then

                        Else
                            _data = _data & ", "
                        End If
                        Try
                            _data = _data & dr("cnt")
                        Catch ex As Exception
                            _data = _data & 0
                        End Try
                        x1 = x1 + 1
                    Next
                    _data = _data & "], marker: { lineWidth: 2, lineColor: Highcharts.getOptions().colors[3],fillColor:  'white' } }]; "

                ElseIf _type = "9" Then


                    Dim strdataIn As String = " { name: 'ขาเข้า ', data: [ "
                    Dim strdataOut As String = " { name: 'ขาออก ', data: [ "
                    For Each dr As DataRow In tbChart.Select("", "cnt desc")
                        If _categories = "" Then
                            _categories = " var _categories = [ '" & dr("_name").ToString.Replace("ด่านพรมแดน", "") & "' "
                        Else
                            _categories = _categories & ", '" & dr("_name").ToString.Replace("ด่านพรมแดน", "") & "' "
                        End If

                        If IsFirst = 1 Then

                        Else
                            strdataIn = strdataIn & ","
                            strdataOut = strdataOut & ","
                        End If
                        Try
                            Dim sum_in As Decimal = tbChart.Compute("Sum(cnt_in)", "_name = '" & dr("_name") & "' ").ToString()
                            Dim sum_out As Decimal = tbChart.Compute("Sum(cnt_out)", "_name = '" & dr("_name") & "' ").ToString()
                            strdataIn = strdataIn & sum_in
                            strdataOut = strdataOut & sum_out
                        Catch ex As Exception
                            strdataIn = strdataIn & 0
                            strdataOut = strdataOut & 0
                        End Try
                        IsFirst = IsFirst + 1
                    Next
                    _categories = _categories & "]; "
                    strdataIn = strdataIn & "] }  "
                    strdataOut = strdataOut & "] }  "


                    _data = _data & " var _data = [ " & strdataIn & ", " & strdataOut & " ];"
                ElseIf _type = "12" Or _type = "14" Then

                    For Each dr As DataRow In Dt.Select("", "cnt desc")
                        If _categories = "" Then
                            _categories = " var _categories = [ '" & dr("_name").ToString.Replace("สำนักงานขนส่งจังหวัด", "สขจ.").ToString.Replace("สำนักงานขนส่งกรุงเทพมหานครพื้นที่", "สขพ.") & "' "
                        Else
                            _categories = _categories & ", '" & dr("_name").ToString.Replace("สำนักงานขนส่งจังหวัด", "สขจ.").ToString.Replace("สำนักงานขนส่งกรุงเทพมหานครพื้นที่", "สขพ.") & "' "
                        End If
                    Next
                    _categories = _categories & "]; "


                    Dim ArSeries As String() = {"car_type"}
                    Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, ArSeries)
                    Dim CurCar As String = ""
                    For Each dr As DataRow In DtCar.Select("", "car_type")
                        Dim strdata As String = " { name: '" & dr("car_type") & "', data: [ "
                        Dim x As Integer = 1
                        For Each drCat As DataRow In Dt.Select("", "cnt desc")
                            If x = 1 Then

                            Else
                                strdata = strdata & ", "
                            End If
                            Try
                                Dim sum As Decimal = tbChart.Compute("Sum(cnt)", "car_type = '" & dr("car_type") & "' and _name = '" & drCat("_name") & "' ").ToString()
                                strdata = strdata & sum
                            Catch ex As Exception
                                strdata = strdata & 0
                            End Try
                            x = x + 1
                        Next
                        strdata = strdata & "] } "

                        If _data = "" Then
                            _data = " var _data = [ " & strdata
                        Else
                            _data = _data & " , " & strdata
                        End If
                    Next
                    _data = _data & "]; "

                Else
                    '--------------------------- Add Data ------------------------------------
                    For Each dr As DataRow In tbChart.Select("", "cnt desc")
                        Dim _name As String = "ไม่ระบุ"
                        Dim _th As String = "ไม่ระบุ"
                        If Not dr("_name") Is DBNull.Value Then
                            _name = dr("_name")
                            _th = dr("_name").ToString.Replace("สำนักงานขนส่งจังหวัด", "สขจ.").ToString.Replace("สำนักงานขนส่งกรุงเทพมหานครพื้นที่", "สขพ.")
                        End If

                        If _type = "5" Then
                            _name = _name.ToString.Replace("ด่านพรมแดน", "")
                        End If

                        Dim _Percent As Double = Format(CDbl((dr("cnt") / pToTal) * 100), "##0.00")
                        If IsFirst = 1 Then
                            If _type = "1" Then
                                _th = _th & " มีรถที่ได้รับอนุญาตมากที่สุด <br><b>จำนวน " & dr("cnt") & " คัน </b>  <b> (ร้อยละ " & _Percent & ")</b>"
                            End If
                        Else
                            If _type = "1" Then
                                _th = _th & " <br><b>จำนวน " & dr("cnt") & " คัน </b> "
                            End If
                        End If


                        If _data = "" Then
                            _data = " var _data = [ { name: '" & _name & "' , th: '" & _th & "', y: " & dr("cnt") & " , z: " & _Percent & " } "
                        Else
                            _data = _data & " ,   { name: '" & _name & "' , th: '" & _th & "', y: " & dr("cnt") & " , z: " & _Percent & "  } "
                        End If

                        If _type = "4" Or _type = "5" Then
                            'เอาแค่ 5 ลำดับแรก
                            If IsFirst = 5 Then
                                Exit For
                            End If
                        End If
                        IsFirst = IsFirst + 1
                    Next
                    _data = _data & " ];"
                End If
            Else
                pAlert = "ไม่พบข้อมูลดังกล่าว กรุณาเลือกวันที่ให้ถูกต้อง!!!"
                _data = " var _data = [ { name: 'ไม่ระบุ' , th: 'ไม่ระบุ' , y: 0  , z: 0 }]; "
            End If

            Return _data & _categories
        Catch ex As Exception
            pAlert = "ไม่พบข้อมูลดังกล่าว !!!"
            Return " var _data = [ { name: 'ไม่ระบุ' , th: 'ไม่ระบุ' , y: 0  , z: 0 }]; "

        End Try
    End Function

    Public Function getMonthName(ByVal pIndex As Integer, ByVal pCul As String) As String
        Dim MonthName As String = ""


        If pCul.ToLower = "th" Then


            Select Case pIndex
                Case 1
                    MonthName = "ม.ค."
                Case 2
                    MonthName = "ก.พ."
                Case 3
                    MonthName = "มี.ค."
                Case 4
                    MonthName = "เม.ย."
                Case 5
                    MonthName = "พ.ค."
                Case 6
                    MonthName = "มิ.ย."
                Case 7
                    MonthName = "ก.ค."
                Case 8
                    MonthName = "ส.ค."
                Case 9
                    MonthName = "ก.ย."
                Case 10
                    MonthName = "ต.ต."
                Case 11
                    MonthName = "พ.ย."
                Case 12
                    MonthName = "ธ.ค."
            End Select
        ElseIf pCul.ToLower = "en" Then
            Select Case pIndex
                Case 1
                    MonthName = "January"
                Case 2
                    MonthName = "February"
                Case 3
                    MonthName = "March"
                Case 4
                    MonthName = "April"
                Case 5
                    MonthName = "May"
                Case 6
                    MonthName = "June"
                Case 7
                    MonthName = "July"
                Case 8
                    MonthName = "August"
                Case 9
                    MonthName = "September"
                Case 10
                    MonthName = "October"
                Case 11
                    MonthName = "November"
                Case 12
                    MonthName = "December"
            End Select
        End If

        Return MonthName
    End Function

#Region "For AddTable Into TableCell "
    Private IsMobile As Boolean = False
    Private PopulateS As New PopulateScript
    Public Function AddTable(ByVal Page As Page, ByVal _type As Object, ByVal typeuser_id As Integer, ByVal _year As Integer, _
                              ByVal lblHead As Label, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer) As Table
        Dim tableData As Table
        If PopulateS.IsMobile Then
            IsMobile = True
        End If
        If _type = "8" Then
            'ด่านศุลกากรที่ขออนุญาตรถผ่านเข้า-ออก มากที่สุด 5 ลำดับแรก
            tableData = AddTable8(Page, typeuser_id, _year, txtsdate, txtedate, _limit)
        ElseIf _type = "10" Then
            'ผู้ประกอบธุรกิจนำเที่ยวที่ขออนุญาตรถผ่านเข้า-ออก
            tableData = AddTable10(Page, typeuser_id, _year, txtsdate, txtedate, _limit)
        ElseIf _type = "11" Then
            'สถิติการขออนุญาตเข้ามาในราชอาณาจักรเป็นการชั่วคราว จำแนกตามสำนักงาน
            tableData = AddTable11(Page, typeuser_id, _year, txtsdate, txtedate, _limit)
        ElseIf _type = "13" Then
            'จำนวนรถที่ขออนุญาตฯ จำแนกตามประเทศที่รถจดทะเบียน
            tableData = AddTable13(Page, typeuser_id, _year, txtsdate, txtedate, _limit)
        End If
        Return tableData
    End Function

    Private Function AddTable8(ByVal Page As Page, ByVal typeuser_id As Integer, ByVal _year As Integer, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer) As Table

        '----------------------  ด่านศุลการกรขาเข้า -----------------------
        Try
            tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(border_checkin.border_nameth,'ไม่ระบุ')", 8, typeuser_id, _year, txtsdate, txtedate, _limit)
        Catch ex As Exception

        End Try

        Dim tableChart As New Table
        Dim tr As TableRow
        Dim tc As TableCell


        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#C2DFFF")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ลำดับที่<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ด่านศุลการกรขาเข้า<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        Dim Ar As String() = {"car_type"}
        Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>จำนวนรถ (คัน)<b>"
        tc.ColumnSpan = DtCar.Rows.Count + 1
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)

        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#C2DFFF")
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<b>" & drCar("car_type").ToString.Replace(" (", "<br/>(") & "<b>"
            If IsMobile Then
                tc.Width = Unit.Pixel(100)
            Else
                tc.Width = Unit.Pixel(128)
            End If
            tc.Attributes.Add("style", "padding-left: 2px;")
            tr.Cells.Add(tc)
        Next
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>รวม<b>"
        tc.Width = Unit.Pixel(90)
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)



        'Ar = {"_name"}
        Dim _order As Integer = 1
        'Dim DtBorder As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        For Each drB As DataRow In Dt.Select("", " cnt desc") 'DtBorder.Select("", "_name")
            tr = New TableRow
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = _order
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.Attributes.Add("style", "padding-left: 10px;")
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Left
            tc.VerticalAlign = VerticalAlign.Top
            If drB("_name") Is DBNull.Value Then
                tc.Text = "ไม่ระบุ"
            Else
                tc.Text = drB("_name")
            End If
            tr.Cells.Add(tc)

            Dim SumCar As Double = 0
            For Each drCar As DataRow In DtCar.Select("", "car_type")
                tc = New TableCell
                tc.BorderWidth = Unit.Pixel(1)
                tc.BorderColor = Drawing.Color.DarkGray
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.VerticalAlign = VerticalAlign.Top
                Dim _cnt As Double = 0
                Try
                    _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' ").ToString()
                    tc.Text = Format(CDbl(_cnt), "#,##0")
                Catch ex As Exception
                    tc.Text = "-"
                End Try
                tr.Cells.Add(tc)
                SumCar = SumCar + _cnt
            Next

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = Format(CDbl(SumCar), "#,##0")
            tr.Cells.Add(tc)
            tableChart.Rows.Add(tr)
            _order = _order + 1
        Next


        '----------------------  ด่านศุลการกรขาออก -----------------------
        Try
            'tbChart = Nothing
            'Dt = Nothing
            tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(border_checkout.border_nameth,'ไม่ระบุ')", 8, typeuser_id, _year, txtsdate, txtedate, _limit)
        Catch ex As Exception

        End Try
        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#B5EAAA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ลำดับที่<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ด่านศุลการกรขาออก<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        Ar = {"car_type"}
        DtCar = tbChart.DefaultView.ToTable(True, Ar)
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>จำนวนรถ (คัน)<b>"
        tc.ColumnSpan = DtCar.Rows.Count + 1
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)

        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#B5EAAA")
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<b>" & drCar("car_type").ToString.Replace(" (", "<br/>(") & "<b>"
            tc.Attributes.Add("style", "padding-left: 2px;")
            tr.Cells.Add(tc)
        Next
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>รวม<b>"
        tc.Width = Unit.Pixel(90)
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)


        'Ar = {"_name"}
        _order = 1
        For Each drB As DataRow In Dt.Select("", " cnt desc") 'DtBorder.Select("", "_name")
            tr = New TableRow
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = _order
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.Attributes.Add("style", "padding-left: 10px;")
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Left
            tc.VerticalAlign = VerticalAlign.Top
            If drB("_name") Is DBNull.Value Then
                tc.Text = "ไม่ระบุ"
            Else
                tc.Text = drB("_name")
            End If
            tr.Cells.Add(tc)

            Dim SumCar As Double = 0
            For Each drCar As DataRow In DtCar.Select("", "car_type")
                tc = New TableCell
                tc.BorderWidth = Unit.Pixel(1)
                tc.BorderColor = Drawing.Color.DarkGray
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.VerticalAlign = VerticalAlign.Top
                Dim _cnt As Double = 0
                Try
                    _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' ").ToString()
                    tc.Text = Format(CDbl(_cnt), "#,##0")
                Catch ex As Exception
                    tc.Text = "-"
                End Try
                tr.Cells.Add(tc)
                SumCar = SumCar + _cnt
            Next

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = Format(CDbl(SumCar), "#,##0")
            tr.Cells.Add(tc)
            tableChart.Rows.Add(tr)
            _order = _order + 1
        Next

        Return tableChart
    End Function

    Private Function AddTable10(ByVal Page As Page, ByVal typeuser_id As Integer, ByVal _year As Integer, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer) As Table

        '----------------------  ผู้ประกอบธุรกิจนำเที่ยว -----------------------
        Try
            tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(name_company,'ไม่ระบุ') ", 10, typeuser_id, _year, txtsdate, txtedate, _limit)
        Catch ex As Exception

        End Try

        Dim tableChart As New Table
        Dim tr As TableRow
        Dim tc As TableCell


        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ลำดับที่<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ผู้ประกอบการธุรกิจนำเที่ยว<b>" ' (ผู้ขอยื่น)<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        Dim Ar As String() = {"car_type"}
        Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>ประเภทรถ (คัน)<b>"
        tc.ColumnSpan = DtCar.Rows.Count + 1
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)

        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<b>" & drCar("car_type").ToString.Replace(" (", "<br/>(") & "<b>"
            If IsMobile Then
                tc.Width = Unit.Pixel(100)
            Else
                tc.Width = Unit.Pixel(128)
            End If
            tc.Attributes.Add("style", "padding-left: 2px;")
            tr.Cells.Add(tc)
        Next
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>รวม<b>"
        tc.Width = Unit.Pixel(90)
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)



        'Ar = {"_name"}
        Dim _order As Integer = 1
        'Dim DtBorder As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        For Each drB As DataRow In Dt.Select("", " cnt desc") 'DtBorder.Select("", "_name")
            tr = New TableRow
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = _order
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.Attributes.Add("style", "padding-left: 10px;")
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Left
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = drB("_name")
            tr.Cells.Add(tc)

            Dim SumCar As Double = 0
            For Each drCar As DataRow In DtCar.Select("", "car_type")
                tc = New TableCell
                tc.BorderWidth = Unit.Pixel(1)
                tc.BorderColor = Drawing.Color.DarkGray
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.VerticalAlign = VerticalAlign.Top
                Dim _cnt As Double = 0
                Try
                    _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' ").ToString()
                    tc.Text = Format(CDbl(_cnt), "#,##0")
                Catch ex As Exception
                    tc.Text = "-"
                End Try
                tr.Cells.Add(tc)
                SumCar = SumCar + _cnt
            Next

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = Format(CDbl(SumCar), "#,##0")
            tr.Cells.Add(tc)
            tableChart.Rows.Add(tr)
            _order = _order + 1
        Next


        Return tableChart
    End Function

    Private Function AddTable11(ByVal Page As Page, ByVal typeuser_id As Integer, ByVal _year As Integer, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer) As Table

        '----------------------  สำนักงาน -----------------------
        Try
            tbChart = getQueryChart(Page, "count(distinct license.driver_id ) cntdriver , coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(admin.admin_name,'ไม่ระบุ') ", 11, typeuser_id, _year, txtsdate, txtedate, _limit)
        Catch ex As Exception

        End Try

        Dim tableChart As New Table
        Dim tr As TableRow
        Dim tc As TableCell


        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ลำดับที่<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>สำนักงาน<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        Dim Ar As String() = {"car_type"}
        Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>ประเภทรถ (คัน)<b>"
        tc.ColumnSpan = DtCar.Rows.Count + 1
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ผู้ขับรถ<br/>(ราย)<b>"
        tc.RowSpan = 2
        tc.Width = Unit.Pixel(100)
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)

        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<b>" & drCar("car_type").ToString.Replace(" (", "<br/>(") & "<b>"
            If IsMobile Then
                tc.Width = Unit.Pixel(100)
            Else
                tc.Width = Unit.Pixel(128)
            End If
            tc.Attributes.Add("style", "padding-left: 2px;")
            tr.Cells.Add(tc)
        Next
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>รวม<b>"
        tc.Width = Unit.Pixel(90)
        tr.Cells.Add(tc)

        tableChart.Rows.Add(tr)



        'Ar = {"_name"}
        Dim _order As Integer = 1
        'Dim DtBorder As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        For Each drB As DataRow In Dt.Select("", " cnt desc") 'DtBorder.Select("", "_name")
            tr = New TableRow
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = _order
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.Attributes.Add("style", "padding-left: 10px;")
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Left
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = drB("_name")
            tr.Cells.Add(tc)

            Dim SumCar As Double = 0
            For Each drCar As DataRow In DtCar.Select("", "car_type")
                tc = New TableCell
                tc.BorderWidth = Unit.Pixel(1)
                tc.BorderColor = Drawing.Color.DarkGray
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.VerticalAlign = VerticalAlign.Top
                Dim _cnt As Double = 0
                Try
                    _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' ").ToString()
                    tc.Text = Format(CDbl(_cnt), "#,##0")
                Catch ex As Exception
                    tc.Text = "-"
                End Try
                tr.Cells.Add(tc)
                SumCar = SumCar + _cnt
            Next

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = Format(CDbl(SumCar), "#,##0")
            tr.Cells.Add(tc)


            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            Dim _cntdriver As Double = 0
            Try
                _cntdriver = tbChart.Compute("Sum(cntdriver)", "_name = '" & drB("_name") & "' ").ToString()
                tc.Text = Format(CDbl(_cntdriver), "#,##0")
            Catch ex As Exception
                tc.Text = "-"
            End Try
            tr.Cells.Add(tc)

            tableChart.Rows.Add(tr)
            _order = _order + 1
        Next

        '-------------------------- Footer --------------------------  
        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>รวมทั้งสิ้น<b>"
        tc.RowSpan = 2
        tc.ColumnSpan = 2
        tr.Cells.Add(tc)

        Dim SumFooterCar As Double = 0
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            Dim _cnt As Double = 0
            Try
                _cnt = tbChart.Compute("Sum(cnt)", "car_type = '" & drCar("car_type") & "' ").ToString()
                tc.Text = Format(CDbl(_cnt), "#,##0")
            Catch ex As Exception
                tc.Text = "-"
            End Try
            tr.Cells.Add(tc)
            SumFooterCar = SumFooterCar + _cnt
        Next

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = Format(CDbl(SumFooterCar), "#,##0")
        tr.Cells.Add(tc)


        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        Dim _Sumcntdriver As Double = 0
        Try
            _Sumcntdriver = tbChart.Compute("Sum(cntdriver)", "").ToString()
            tc.Text = Format(CDbl(_Sumcntdriver), "#,##0")
        Catch ex As Exception
            tc.Text = "-"
        End Try
        tr.Cells.Add(tc)

        tableChart.Rows.Add(tr)
        Return tableChart
    End Function

    Private Function AddTable13(ByVal Page As Page, ByVal typeuser_id As Integer, ByVal _year As Integer, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer) As Table

        '----------------------  ประเทศที่รถจดทะเบียน -----------------------
        Try
            tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(car.country_car,'ไม่ระบุ') ", 13, typeuser_id, _year, txtsdate, txtedate, _limit)
        Catch ex As Exception

        End Try

        Dim tableChart As New Table
        Dim tr As TableRow
        Dim tc As TableCell


        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ลำดับที่<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ประเทศที่รถจดทะเบียน<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        Dim Ar As String() = {"car_type"}
        Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>ประเภทรถ (คัน)<b>"
        tc.ColumnSpan = DtCar.Rows.Count + 1
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)

        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<b>" & drCar("car_type").ToString.Replace(" (", "<br/>(") & "<b>"
            If IsMobile Then
                tc.Width = Unit.Pixel(100)
            Else
                tc.Width = Unit.Pixel(128)
            End If
            tc.Attributes.Add("style", "padding-left: 2px;")
            tr.Cells.Add(tc)
        Next
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>รวม<b>"
        tc.Width = Unit.Pixel(90)
        tr.Cells.Add(tc)

        tableChart.Rows.Add(tr)



        'Ar = {"_name"}
        Dim _order As Integer = 1
        'Dim DtBorder As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        For Each drB As DataRow In Dt.Select("", " cnt desc") 'DtBorder.Select("", "_name")
            tr = New TableRow
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = _order
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.Attributes.Add("style", "padding-left: 10px;")
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Left
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = drB("_name")
            tr.Cells.Add(tc)

            Dim SumCar As Double = 0
            For Each drCar As DataRow In DtCar.Select("", "car_type")
                tc = New TableCell
                tc.BorderWidth = Unit.Pixel(1)
                tc.BorderColor = Drawing.Color.DarkGray
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.VerticalAlign = VerticalAlign.Top
                Dim _cnt As Double = 0
                Try
                    _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' ").ToString()
                    tc.Text = Format(CDbl(_cnt), "#,##0")
                Catch ex As Exception
                    tc.Text = "-"
                End Try
                tr.Cells.Add(tc)
                SumCar = SumCar + _cnt
            Next

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = Format(CDbl(SumCar), "#,##0")
            tr.Cells.Add(tc)

            tableChart.Rows.Add(tr)
            _order = _order + 1
        Next

        '-------------------------- Footer --------------------------  
        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>รวมทั้งสิ้น<b>"
        tc.RowSpan = 2
        tc.ColumnSpan = 2
        tr.Cells.Add(tc)

        Dim SumFooterCar As Double = 0
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            Dim _cnt As Double = 0
            Try
                _cnt = tbChart.Compute("Sum(cnt)", "car_type = '" & drCar("car_type") & "' ").ToString()
                tc.Text = Format(CDbl(_cnt), "#,##0")
            Catch ex As Exception
                tc.Text = "-"
            End Try
            tr.Cells.Add(tc)
            SumFooterCar = SumFooterCar + _cnt
        Next

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = Format(CDbl(SumFooterCar), "#,##0")
        tr.Cells.Add(tc)

        tableChart.Rows.Add(tr)
        Return tableChart
    End Function

    Public Function AddTable(ByVal Page As Page, ByVal _type As Object, ByVal typeuser_id As Integer, ByVal _year As Integer, _
                              ByVal lblHead As Label, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer, ByVal _type_date As Integer) As Table
        Dim tableData As Table
        If PopulateS.IsMobile Then
            IsMobile = True
        End If
        If _type = "8" Then
            'ด่านศุลกากรที่ขออนุญาตรถผ่านเข้า-ออก มากที่สุด 5 ลำดับแรก
            tableData = AddTable8(Page, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
        ElseIf _type = "10" Then
            'ผู้ประกอบธุรกิจนำเที่ยวที่ขออนุญาตรถผ่านเข้า-ออก
            tableData = AddTable10(Page, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
        ElseIf _type = "11" Then
            'สถิติการขออนุญาตเข้ามาในราชอาณาจักรเป็นการชั่วคราว จำแนกตามสำนักงาน
            tableData = AddTable11(Page, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
        ElseIf _type = "13" Then
            'จำนวนรถที่ขออนุญาตฯ จำแนกตามประเทศที่รถจดทะเบียน
            tableData = AddTable13(Page, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
        End If
        Return tableData
    End Function

    Private Function AddTable8(ByVal Page As Page, ByVal typeuser_id As Integer, ByVal _year As Integer, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer, ByVal _type_date As Integer) As Table

        '----------------------  ด่านศุลการกรขาเข้า -----------------------
        Try
            tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(border_checkin.border_nameth,'ไม่ระบุ')", 8, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
        Catch ex As Exception

        End Try

        Dim tableChart As New Table
        Dim tr As TableRow
        Dim tc As TableCell


        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#C2DFFF")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ลำดับที่<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ด่านศุลการกรขาเข้า<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        Dim Ar As String() = {"car_type"}
        Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>จำนวนรถ (คัน)<b>"
        tc.ColumnSpan = DtCar.Rows.Count + 1
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)

        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#C2DFFF")
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<b>" & drCar("car_type").ToString.Replace(" (", "<br/>(") & "<b>"
            If IsMobile Then
                tc.Width = Unit.Pixel(100)
            Else
                tc.Width = Unit.Pixel(128)
            End If
            tc.Attributes.Add("style", "padding-left: 2px;")
            tr.Cells.Add(tc)
        Next
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>รวม<b>"
        tc.Width = Unit.Pixel(90)
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)



        'Ar = {"_name"}
        Dim _order As Integer = 1
        'Dim DtBorder As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        For Each drB As DataRow In Dt.Select("", " cnt desc") 'DtBorder.Select("", "_name")
            tr = New TableRow
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = _order
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.Attributes.Add("style", "padding-left: 10px;")
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Left
            tc.VerticalAlign = VerticalAlign.Top
            If drB("_name") Is DBNull.Value Then
                tc.Text = "ไม่ระบุ"
            Else
                tc.Text = drB("_name")
            End If
            tr.Cells.Add(tc)

            Dim SumCar As Double = 0
            For Each drCar As DataRow In DtCar.Select("", "car_type")
                tc = New TableCell
                tc.BorderWidth = Unit.Pixel(1)
                tc.BorderColor = Drawing.Color.DarkGray
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.VerticalAlign = VerticalAlign.Top
                Dim _cnt As Double = 0
                Try
                    _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' ").ToString()
                    tc.Text = Format(CDbl(_cnt), "#,##0")
                Catch ex As Exception
                    tc.Text = "-"
                End Try
                tr.Cells.Add(tc)
                SumCar = SumCar + _cnt
            Next

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = Format(CDbl(SumCar), "#,##0")
            tr.Cells.Add(tc)
            tableChart.Rows.Add(tr)
            _order = _order + 1
        Next


        '----------------------  ด่านศุลการกรขาออก -----------------------
        Try
            'tbChart = Nothing
            'Dt = Nothing
            tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(border_checkout.border_nameth,'ไม่ระบุ')", 8, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
        Catch ex As Exception

        End Try
        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#B5EAAA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ลำดับที่<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ด่านศุลการกรขาออก<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        Ar = {"car_type"}
        DtCar = tbChart.DefaultView.ToTable(True, Ar)
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>จำนวนรถ (คัน)<b>"
        tc.ColumnSpan = DtCar.Rows.Count + 1
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)

        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#B5EAAA")
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<b>" & drCar("car_type").ToString.Replace(" (", "<br/>(") & "<b>"
            tc.Attributes.Add("style", "padding-left: 2px;")
            tr.Cells.Add(tc)
        Next
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>รวม<b>"
        tc.Width = Unit.Pixel(90)
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)


        'Ar = {"_name"}
        _order = 1
        For Each drB As DataRow In Dt.Select("", " cnt desc") 'DtBorder.Select("", "_name")
            tr = New TableRow
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = _order
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.Attributes.Add("style", "padding-left: 10px;")
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Left
            tc.VerticalAlign = VerticalAlign.Top
            If drB("_name") Is DBNull.Value Then
                tc.Text = "ไม่ระบุ"
            Else
                tc.Text = drB("_name")
            End If
            tr.Cells.Add(tc)

            Dim SumCar As Double = 0
            For Each drCar As DataRow In DtCar.Select("", "car_type")
                tc = New TableCell
                tc.BorderWidth = Unit.Pixel(1)
                tc.BorderColor = Drawing.Color.DarkGray
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.VerticalAlign = VerticalAlign.Top
                Dim _cnt As Double = 0
                Try
                    _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' ").ToString()
                    tc.Text = Format(CDbl(_cnt), "#,##0")
                Catch ex As Exception
                    tc.Text = "-"
                End Try
                tr.Cells.Add(tc)
                SumCar = SumCar + _cnt
            Next

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = Format(CDbl(SumCar), "#,##0")
            tr.Cells.Add(tc)
            tableChart.Rows.Add(tr)
            _order = _order + 1
        Next

        Return tableChart
    End Function

    Private Function AddTable10(ByVal Page As Page, ByVal typeuser_id As Integer, ByVal _year As Integer, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer, ByVal _type_date As Integer) As Table

        '----------------------  ผู้ประกอบธุรกิจนำเที่ยว -----------------------
        Try
            tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(name_company,'ไม่ระบุ') ", 10, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
        Catch ex As Exception

        End Try

        Dim tableChart As New Table
        Dim tr As TableRow
        Dim tc As TableCell


        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ลำดับที่<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ผู้ประกอบการธุรกิจนำเที่ยว<b>" ' (ผู้ขอยื่น)<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        Dim Ar As String() = {"car_type"}
        Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>ประเภทรถ (คัน)<b>"
        tc.ColumnSpan = DtCar.Rows.Count + 1
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)

        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<b>" & drCar("car_type").ToString.Replace(" (", "<br/>(") & "<b>"
            If IsMobile Then
                tc.Width = Unit.Pixel(100)
            Else
                tc.Width = Unit.Pixel(128)
            End If
            tc.Attributes.Add("style", "padding-left: 2px;")
            tr.Cells.Add(tc)
        Next
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>รวม<b>"
        tc.Width = Unit.Pixel(90)
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)



        'Ar = {"_name"}
        Dim _order As Integer = 1
        'Dim DtBorder As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        For Each drB As DataRow In Dt.Select("", " cnt desc") 'DtBorder.Select("", "_name")
            tr = New TableRow
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = _order
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.Attributes.Add("style", "padding-left: 10px;")
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Left
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = drB("_name")
            tr.Cells.Add(tc)

            Dim SumCar As Double = 0
            For Each drCar As DataRow In DtCar.Select("", "car_type")
                tc = New TableCell
                tc.BorderWidth = Unit.Pixel(1)
                tc.BorderColor = Drawing.Color.DarkGray
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.VerticalAlign = VerticalAlign.Top
                Dim _cnt As Double = 0
                Try
                    _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' ").ToString()
                    tc.Text = Format(CDbl(_cnt), "#,##0")
                Catch ex As Exception
                    tc.Text = "-"
                End Try
                tr.Cells.Add(tc)
                SumCar = SumCar + _cnt
            Next

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = Format(CDbl(SumCar), "#,##0")
            tr.Cells.Add(tc)
            tableChart.Rows.Add(tr)
            _order = _order + 1
        Next


        Return tableChart
    End Function

    Private Function AddTable11(ByVal Page As Page, ByVal typeuser_id As Integer, ByVal _year As Integer, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer, ByVal _type_date As Integer) As Table

        '----------------------  สำนักงาน -----------------------
        Try
            tbChart = getQueryChart(Page, "count(distinct license.driver_id ) cntdriver , coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(admin.admin_name,'ไม่ระบุ') ", 11, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
        Catch ex As Exception

        End Try

        Dim tableChart As New Table
        Dim tr As TableRow
        Dim tc As TableCell


        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ลำดับที่<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>สำนักงาน<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        Dim Ar As String() = {"car_type"}
        Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>ประเภทรถ (คัน)<b>"
        tc.ColumnSpan = DtCar.Rows.Count + 1
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ผู้ขับรถ<br/>(ราย)<b>"
        tc.RowSpan = 2
        tc.Width = Unit.Pixel(100)
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)

        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<b>" & drCar("car_type").ToString.Replace(" (", "<br/>(") & "<b>"
            If IsMobile Then
                tc.Width = Unit.Pixel(100)
            Else
                tc.Width = Unit.Pixel(128)
            End If
            tc.Attributes.Add("style", "padding-left: 2px;")
            tr.Cells.Add(tc)
        Next
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>รวม<b>"
        tc.Width = Unit.Pixel(90)
        tr.Cells.Add(tc)

        tableChart.Rows.Add(tr)



        'Ar = {"_name"}
        Dim _order As Integer = 1
        'Dim DtBorder As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        For Each drB As DataRow In Dt.Select("", " cnt desc") 'DtBorder.Select("", "_name")
            tr = New TableRow
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = _order
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.Attributes.Add("style", "padding-left: 10px;")
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Left
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = drB("_name")
            tr.Cells.Add(tc)

            Dim SumCar As Double = 0
            For Each drCar As DataRow In DtCar.Select("", "car_type")
                tc = New TableCell
                tc.BorderWidth = Unit.Pixel(1)
                tc.BorderColor = Drawing.Color.DarkGray
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.VerticalAlign = VerticalAlign.Top
                Dim _cnt As Double = 0
                Try
                    _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' ").ToString()
                    tc.Text = Format(CDbl(_cnt), "#,##0")
                Catch ex As Exception
                    tc.Text = "-"
                End Try
                tr.Cells.Add(tc)
                SumCar = SumCar + _cnt
            Next

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = Format(CDbl(SumCar), "#,##0")
            tr.Cells.Add(tc)


            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            Dim _cntdriver As Double = 0
            Try
                _cntdriver = tbChart.Compute("Sum(cntdriver)", "_name = '" & drB("_name") & "' ").ToString()
                tc.Text = Format(CDbl(_cntdriver), "#,##0")
            Catch ex As Exception
                tc.Text = "-"
            End Try
            tr.Cells.Add(tc)

            tableChart.Rows.Add(tr)
            _order = _order + 1
        Next

        '-------------------------- Footer --------------------------  
        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>รวมทั้งสิ้น<b>"
        tc.RowSpan = 2
        tc.ColumnSpan = 2
        tr.Cells.Add(tc)

        Dim SumFooterCar As Double = 0
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            Dim _cnt As Double = 0
            Try
                _cnt = tbChart.Compute("Sum(cnt)", "car_type = '" & drCar("car_type") & "' ").ToString()
                tc.Text = Format(CDbl(_cnt), "#,##0")
            Catch ex As Exception
                tc.Text = "-"
            End Try
            tr.Cells.Add(tc)
            SumFooterCar = SumFooterCar + _cnt
        Next

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = Format(CDbl(SumFooterCar), "#,##0")
        tr.Cells.Add(tc)


        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        Dim _Sumcntdriver As Double = 0
        Try
            _Sumcntdriver = tbChart.Compute("Sum(cntdriver)", "").ToString()
            tc.Text = Format(CDbl(_Sumcntdriver), "#,##0")
        Catch ex As Exception
            tc.Text = "-"
        End Try
        tr.Cells.Add(tc)

        tableChart.Rows.Add(tr)
        Return tableChart
    End Function

    Private Function AddTable13(ByVal Page As Page, ByVal typeuser_id As Integer, ByVal _year As Integer, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer, ByVal _type_date As Integer) As Table

        '----------------------  ประเทศที่รถจดทะเบียน -----------------------
        Try
            tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(car.country_car,'ไม่ระบุ') ", 13, typeuser_id, _year, txtsdate, txtedate, _limit, _type_date)
        Catch ex As Exception

        End Try

        Dim tableChart As New Table
        Dim tr As TableRow
        Dim tc As TableCell


        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ลำดับที่<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>ประเทศที่รถจดทะเบียน<b>"
        tc.RowSpan = 2
        tr.Cells.Add(tc)

        Dim Ar As String() = {"car_type"}
        Dim DtCar As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>ประเภทรถ (คัน)<b>"
        tc.ColumnSpan = DtCar.Rows.Count + 1
        tr.Cells.Add(tc)
        tableChart.Rows.Add(tr)

        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = "<b>" & drCar("car_type").ToString.Replace(" (", "<br/>(") & "<b>"
            If IsMobile Then
                tc.Width = Unit.Pixel(100)
            Else
                tc.Width = Unit.Pixel(128)
            End If
            tc.Attributes.Add("style", "padding-left: 2px;")
            tr.Cells.Add(tc)
        Next
        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = "<b>รวม<b>"
        tc.Width = Unit.Pixel(90)
        tr.Cells.Add(tc)

        tableChart.Rows.Add(tr)



        'Ar = {"_name"}
        Dim _order As Integer = 1
        'Dim DtBorder As DataTable = tbChart.DefaultView.ToTable(True, Ar)
        For Each drB As DataRow In Dt.Select("", " cnt desc") 'DtBorder.Select("", "_name")
            tr = New TableRow
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = _order
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.Attributes.Add("style", "padding-left: 10px;")
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Left
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = drB("_name")
            tr.Cells.Add(tc)

            Dim SumCar As Double = 0
            For Each drCar As DataRow In DtCar.Select("", "car_type")
                tc = New TableCell
                tc.BorderWidth = Unit.Pixel(1)
                tc.BorderColor = Drawing.Color.DarkGray
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.VerticalAlign = VerticalAlign.Top
                Dim _cnt As Double = 0
                Try
                    _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' ").ToString()
                    tc.Text = Format(CDbl(_cnt), "#,##0")
                Catch ex As Exception
                    tc.Text = "-"
                End Try
                tr.Cells.Add(tc)
                SumCar = SumCar + _cnt
            Next

            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            tc.Text = Format(CDbl(SumCar), "#,##0")
            tr.Cells.Add(tc)

            tableChart.Rows.Add(tr)
            _order = _order + 1
        Next

        '-------------------------- Footer --------------------------  
        tr = New TableRow
        tr.BackColor = Drawing.Color.FromName("#E3E4FA")

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Middle
        tc.Text = "<b>รวมทั้งสิ้น<b>"
        tc.RowSpan = 2
        tc.ColumnSpan = 2
        tr.Cells.Add(tc)

        Dim SumFooterCar As Double = 0
        For Each drCar As DataRow In DtCar.Select("", "car_type")
            tc = New TableCell
            tc.BorderWidth = Unit.Pixel(1)
            tc.BorderColor = Drawing.Color.DarkGray
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            Dim _cnt As Double = 0
            Try
                _cnt = tbChart.Compute("Sum(cnt)", "car_type = '" & drCar("car_type") & "' ").ToString()
                tc.Text = Format(CDbl(_cnt), "#,##0")
            Catch ex As Exception
                tc.Text = "-"
            End Try
            tr.Cells.Add(tc)
            SumFooterCar = SumFooterCar + _cnt
        Next

        tc = New TableCell
        tc.BorderWidth = Unit.Pixel(1)
        tc.BorderColor = Drawing.Color.DarkGray
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = Format(CDbl(SumFooterCar), "#,##0")
        tr.Cells.Add(tc)

        tableChart.Rows.Add(tr)
        Return tableChart
    End Function
#End Region

#Region "For Export CSV & Excel"
    Public Function ConvertDataExport(ByVal Page As Page, ByVal _type As Object, ByVal typeuser_id As Integer, ByVal _year As Integer, _
                              ByVal lblHead As Label, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer, ByVal IsExcel As Boolean) As DataTable
        '------------------------ Load Data Basic ------------------------ 
        Dim tbChart As New DataTable
        Dim tbChart2 As New DataTable
        Try
            If _type = "8" Then
                'ด่านศุลการกรขาเข้า
                tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(border_checkin.border_nameth,'ไม่ระบุ')", 8, typeuser_id, _
                                                      _year, txtsdate, txtedate, _limit)
                tbChart.Columns.Add(New DataColumn() With {.ColumnName = "Type2",
                                      .DataType = GetType(String),
                                      .DefaultValue = "ขาเข้า"})

                'ด่านศุลการกรขาออก
                tbChart2 = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(border_checkout.border_nameth,'ไม่ระบุ')", 8, typeuser_id, _
                                                       _year, txtsdate, txtedate, _limit)
                tbChart2.Columns.Add(New DataColumn() With {.ColumnName = "Type2",
                                      .DataType = GetType(String),
                                      .DefaultValue = "ขาออก"})
                tbChart.Merge(tbChart2)
            ElseIf _type = "10" Then
                tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(name_company,'ไม่ระบุ') ", 10, typeuser_id, _
                                                      _year, txtsdate, txtedate, _limit)
            ElseIf _type = "11" Then
                tbChart = getQueryChart(Page, "count(distinct license.driver_id ) cntdriver , coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(admin.admin_name,'ไม่ระบุ') ", 11, typeuser_id, _
                                                      _year, txtsdate, txtedate, _limit)
            ElseIf _type = "13" Then
                tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(driver.countries,'ไม่ระบุ') ", 13, typeuser_id, _
                                                      _year, txtsdate, txtedate, _limit)
            End If
        Catch ex As Exception

        End Try
        If Not IsExcel Then
            Return tbChart
        Else
            Dim dtExcel As New DataTable
            dtExcel = New DataTable
            Dim DtCar As DataTable
            With dtExcel
                .Columns.Add("no")
                .Columns.Add("_name")
                If _type = "8" Then
                    .Columns.Add("Type2")
                End If
                Dim Ar As String() = {"car_type"}
                DtCar = tbChart.DefaultView.ToTable(True, Ar)
                Dim type_index As Integer = 1
                For Each drCar As DataRow In DtCar.Select("", "car_type")
                    .Columns.Add(drCar("car_type"))
                    type_index = type_index + 1
                Next
                .Columns.Add("sum")
                If _type = "11" Then
                    .Columns.Add("sum_driver")
                End If
            End With
            If _type = "8" Then
                Dim _order As Integer = 1
                '---------------- ขาเข้า -------------------------
                For Each drB As DataRow In Dt.Select("", " cnt desc")
                    Dim nrow As DataRow = dtExcel.NewRow
                    nrow.Item("no") = _order
                    nrow.Item("Type2") = "ขาเข้า"
                    nrow.Item("_name") = drB("_name")
                    Dim SumCar As Double = 0
                    For Each drCar As DataRow In DtCar.Select("", "car_type")
                        Dim _cnt As Double = 0
                        Try
                            _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' and Type2 = 'ขาเข้า' ").ToString()
                            nrow.Item(drCar("car_type")) = _cnt
                        Catch ex As Exception

                        End Try

                        SumCar = SumCar + _cnt
                    Next
                    nrow.Item("sum") = Format(CDbl(SumCar), "#,##0")
                    dtExcel.Rows.Add(nrow)
                    nrow = Nothing
                    _order = _order + 1
                Next

                _order = 1
                '---------------- ขาออก -------------------------
                For Each drB As DataRow In Dt.Select("", " cnt desc")
                    Dim nrow2 As DataRow = dtExcel.NewRow
                    nrow2 = dtExcel.NewRow
                    nrow2.Item("no") = _order
                    nrow2.Item("Type2") = "ขาออก"
                    nrow2.Item("_name") = drB("_name")
                    Dim SumCar As Double = 0
                    For Each drCar As DataRow In DtCar.Select("", "car_type")
                        Dim _cnt As Double = 0
                        Try
                            _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' and Type2 = 'ขาออก' ").ToString()
                            nrow2.Item(drCar("car_type")) = _cnt
                        Catch ex As Exception

                        End Try

                        SumCar = SumCar + _cnt
                    Next
                    nrow2.Item("sum") = Format(CDbl(SumCar), "#,##0")
                    dtExcel.Rows.Add(nrow2)
                    nrow2 = Nothing
                    _order = _order + 1
                Next
            ElseIf _type = "10" Or _type = "11" Or _type = "13" Then
                Dim _order As Integer = 1
                For Each drB As DataRow In Dt.Select("", " cnt desc")
                    Dim nrow As DataRow = dtExcel.NewRow
                    nrow.Item("no") = _order
                    nrow.Item("_name") = drB("_name")
                    Dim SumCar As Double = 0
                    For Each drCar As DataRow In DtCar.Select("", "car_type")
                        Dim _cnt As Double = 0
                        Try
                            _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "'").ToString()
                            nrow.Item(drCar("car_type")) = _cnt
                        Catch ex As Exception

                        End Try
                        SumCar = SumCar + _cnt
                    Next
                    nrow.Item("sum") = Format(CDbl(SumCar), "#,##0")

                    If _type = "11" Then
                        'ผู้ขับรถ(ราย)
                        Dim _cntdriver As Double = 0
                        Try
                            _cntdriver = tbChart.Compute("Sum(cntdriver)", "_name = '" & drB("_name") & "' ").ToString()
                            nrow.Item("sum_driver") = Format(CDbl(_cntdriver), "#,##0")
                        Catch ex As Exception

                        End Try
                    End If
                    dtExcel.Rows.Add(nrow)
                    nrow = Nothing
                    _order = _order + 1
                Next
            End If

            dtExcel.Columns("sum").ColumnName = "รวม"
            If _type = "11" Then
                dtExcel.Columns("sum_driver").ColumnName = "ผู้ขับรถ (ราย)"
            End If
            dtExcel.AcceptChanges()
            Return dtExcel
        End If
    End Function

    Public Function ConvertDataExport(ByVal Page As Page, ByVal _type As Object, ByVal typeuser_id As Integer, ByVal _year As Integer, _
                              ByVal lblHead As Label, ByVal txtsdate As TextBox, ByVal txtedate As TextBox, ByVal _limit As Integer, ByVal IsExcel As Boolean, ByVal _type_date As Integer) As DataTable
        '------------------------ Load Data Basic ------------------------ 
        Dim tbChart As New DataTable
        Dim tbChart2 As New DataTable
        Try
            If _type = "8" Then
                'ด่านศุลการกรขาเข้า
                tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(border_checkin.border_nameth,'ไม่ระบุ')", 8, typeuser_id, _
                                                      _year, txtsdate, txtedate, _limit, _type_date)
                tbChart.Columns.Add(New DataColumn() With {.ColumnName = "Type2",
                                      .DataType = GetType(String),
                                      .DefaultValue = "ขาเข้า"})

                'ด่านศุลการกรขาออก
                tbChart2 = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(border_checkout.border_nameth,'ไม่ระบุ')", 8, typeuser_id, _
                                                       _year, txtsdate, txtedate, _limit, _type_date)
                tbChart2.Columns.Add(New DataColumn() With {.ColumnName = "Type2",
                                      .DataType = GetType(String),
                                      .DefaultValue = "ขาออก"})
                tbChart.Merge(tbChart2)
            ElseIf _type = "10" Then
                tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(name_company,'ไม่ระบุ') ", 10, typeuser_id, _
                                                      _year, txtsdate, txtedate, _limit, _type_date)
            ElseIf _type = "11" Then
                tbChart = getQueryChart(Page, "count(distinct license.driver_id ) cntdriver , coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(admin.admin_name,'ไม่ระบุ') ", 11, typeuser_id, _
                                                      _year, txtsdate, txtedate, _limit, _type_date)
            ElseIf _type = "13" Then
                tbChart = getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , coalesce(driver.countries,'ไม่ระบุ') ", 13, typeuser_id, _
                                                      _year, txtsdate, txtedate, _limit, _type_date)
            End If
        Catch ex As Exception

        End Try
        If Not IsExcel Then
            Return tbChart
        Else
            Dim dtExcel As New DataTable
            dtExcel = New DataTable
            Dim DtCar As DataTable
            With dtExcel
                .Columns.Add("no")
                .Columns.Add("_name")
                If _type = "8" Then
                    .Columns.Add("Type2")
                End If
                Dim Ar As String() = {"car_type"}
                DtCar = tbChart.DefaultView.ToTable(True, Ar)
                Dim type_index As Integer = 1
                For Each drCar As DataRow In DtCar.Select("", "car_type")
                    .Columns.Add(drCar("car_type"))
                    type_index = type_index + 1
                Next
                .Columns.Add("sum")
                If _type = "11" Then
                    .Columns.Add("sum_driver")
                End If
            End With
            If _type = "8" Then
                Dim _order As Integer = 1
                '---------------- ขาเข้า -------------------------
                For Each drB As DataRow In Dt.Select("", " cnt desc")
                    Dim nrow As DataRow = dtExcel.NewRow
                    nrow.Item("no") = _order
                    nrow.Item("Type2") = "ขาเข้า"
                    nrow.Item("_name") = drB("_name")
                    Dim SumCar As Double = 0
                    For Each drCar As DataRow In DtCar.Select("", "car_type")
                        Dim _cnt As Double = 0
                        Try
                            _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' and Type2 = 'ขาเข้า' ").ToString()
                            nrow.Item(drCar("car_type")) = _cnt
                        Catch ex As Exception

                        End Try

                        SumCar = SumCar + _cnt
                    Next
                    nrow.Item("sum") = Format(CDbl(SumCar), "#,##0")
                    dtExcel.Rows.Add(nrow)
                    nrow = Nothing
                    _order = _order + 1
                Next

                _order = 1
                '---------------- ขาออก -------------------------
                For Each drB As DataRow In Dt.Select("", " cnt desc")
                    Dim nrow2 As DataRow = dtExcel.NewRow
                    nrow2 = dtExcel.NewRow
                    nrow2.Item("no") = _order
                    nrow2.Item("Type2") = "ขาออก"
                    nrow2.Item("_name") = drB("_name")
                    Dim SumCar As Double = 0
                    For Each drCar As DataRow In DtCar.Select("", "car_type")
                        Dim _cnt As Double = 0
                        Try
                            _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "' and Type2 = 'ขาออก' ").ToString()
                            nrow2.Item(drCar("car_type")) = _cnt
                        Catch ex As Exception

                        End Try

                        SumCar = SumCar + _cnt
                    Next
                    nrow2.Item("sum") = Format(CDbl(SumCar), "#,##0")
                    dtExcel.Rows.Add(nrow2)
                    nrow2 = Nothing
                    _order = _order + 1
                Next
            ElseIf _type = "10" Or _type = "11" Or _type = "13" Then
                Dim _order As Integer = 1
                For Each drB As DataRow In Dt.Select("", " cnt desc")
                    Dim nrow As DataRow = dtExcel.NewRow
                    nrow.Item("no") = _order
                    nrow.Item("_name") = drB("_name")
                    Dim SumCar As Double = 0
                    For Each drCar As DataRow In DtCar.Select("", "car_type")
                        Dim _cnt As Double = 0
                        Try
                            _cnt = tbChart.Compute("Sum(cnt)", "_name = '" & drB("_name") & "' and car_type = '" & drCar("car_type") & "'").ToString()
                            nrow.Item(drCar("car_type")) = _cnt
                        Catch ex As Exception

                        End Try
                        SumCar = SumCar + _cnt
                    Next
                    nrow.Item("sum") = Format(CDbl(SumCar), "#,##0")

                    If _type = "11" Then
                        'ผู้ขับรถ(ราย)
                        Dim _cntdriver As Double = 0
                        Try
                            _cntdriver = tbChart.Compute("Sum(cntdriver)", "_name = '" & drB("_name") & "' ").ToString()
                            nrow.Item("sum_driver") = Format(CDbl(_cntdriver), "#,##0")
                        Catch ex As Exception

                        End Try
                    End If
                    dtExcel.Rows.Add(nrow)
                    nrow = Nothing
                    _order = _order + 1
                Next
            End If

            dtExcel.Columns("sum").ColumnName = "รวม"
            If _type = "11" Then
                dtExcel.Columns("sum_driver").ColumnName = "ผู้ขับรถ (ราย)"
            End If
            dtExcel.AcceptChanges()
            Return dtExcel
        End If
    End Function
#End Region
End Class
