Imports System.Data
Imports Npgsql

Partial Class Admin_RptStatChart
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected text As String
    Protected name As String
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user_id") Is Nothing Then
            Response.Redirect("../Login.aspx")
        Else

            If Page.IsPostBack = False Then

                Populate.genDDLyears(ddlSchyear, Now.Year, "")
                Populate.genDDLmonths(ddlSchMonth, "ไม่ระบุ", "th")
                'Populate.genDDLdays(ddlSchDay, ddlSchyear.SelectedValue, IIf(ddlSchMonth.SelectedIndex = 0, Now.Month, ddlSchMonth.SelectedValue), "ไม่ระบุ")
                Populate.genDDLBorder(ddlBorder, True, "")
                Populate.genDDLCountry(ddlCountry, "เลือกทั้งหมด")
                Populate.genDDLTypeUser(ddltype, True)

                If Not Request.QueryString("rt") Is Nothing Then
                    ddltype.SelectedValue = Request.QueryString("rt")
                    'ddltype.Enabled = False
                End If
                loaddata()
                'Populate.genPageSize(ddl_PageSize)
                'ddl_PageSize.SelectedValue = 10
                If PopulateS.IsMobile Then
                    'lnkAdd.Text = "<i class='fa fa-plus' aria-hidden='true' ></i> เพิ่ม"
                    Css = ""
                End If
                If Not (Request.QueryString("sid") Is Nothing) Then
                    lbl.Text = IIf(Request.QueryString("sid") = 1, "สถิติจำนวนรถ", "สถิติการฝ่าฝืนเงื่อนไข")
                End If
            Else
                loaddata()
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "ShowData();", True)
            End If
        End If

    End Sub

    Private Sub loaddata()
        Dim pScript As String = ""
        tbDataType_Car = getType_Car()
        If Not (Request.QueryString("sid") Is Nothing) Then
            tbDataCnt_Car = getCnt_Car(Request.QueryString("sid"))
        Else
            tbDataCnt_Car = getCnt_Car(1)
        End If

        loadChart()
        Dim type As Integer
        If Not (Request.QueryString("type") Is Nothing) Then
            type = Request.QueryString("type")

            Select Case type
                Case 1
                    Select Case rdoshow.SelectedValue
                        Case 0
                            If ddlSchMonth.SelectedIndex = 0 Then
                                pScript = "alert('กรุณาระบุเดือน!');"
                                'Else
                                '    LoadTableDay()
                            End If

                        Case 1
                            'LoadTableMonth()
                        Case 2
                            If txtsdate.Text = "" Or txtedate.Text = "" Then
                                pScript = "alert('กรุณาระบุช่วงวันที่!');"
                                'Else
                                '    LoadTableDateRange()
                            End If
                    End Select
                Case 2
                    Select Case rdoshow.SelectedValue
                        Case 0
                            If ddlSchMonth.SelectedIndex = 0 Then
                                pScript = "alert('กรุณาระบุเดือน!');"
                                'Else
                                '    LoadChartDay()
                            End If

                        Case 1
                            'LoadChartDay()
                        Case 2
                            If txtsdate.Text = "" Or txtedate.Text = "" Then
                                pScript = "alert('กรุณาระบุช่วงวันที่!');"
                                'Else
                                '    LoadChartDateRange()
                            End If
                    End Select
            End Select
        Else
            Select Case rdoshow.SelectedValue
                Case 0
                    If ddlSchMonth.SelectedIndex = 0 Then
                        pScript = "alert('กรุณาระบุเดือน!');"
                        'Else
                        '    LoadTableDay()
                    End If

                Case 1
                    'LoadTableMonth()
                Case 2
                    If txtsdate.Text = "" Or txtedate.Text = "" Then
                        pScript = "alert('กรุณาระบุช่วงวันที่!');"
                        'Else
                        '    LoadTableDateRange()
                    End If
            End Select
        End If

        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", pScript & "ShowData();", True)
    End Sub

    Private Function getType_Car() As DataTable
        Dim dbconnect As New DBConnect
        Try
            Dim str As String = " select * from type_car "
            Dim tmp = dbconnect.getDataTable(str, "Type_Car")
            Return tmp
        Catch ex As Exception

        Finally
            dbconnect = Nothing
        End Try
    End Function

    Private Function getCnt_Car(ByVal ptype As Integer) As DataTable
        Dim dbconnect As New DBConnect
        Try
            Dim str As String = ""

            Select Case ptype
                Case 1
                    str = " select count(car.car_id) as cnt_car, typecar_id, start_date, typeuser_id, EXTRACT(YEAR FROM start_date)as year_id, EXTRACT(MONTH FROM start_date)as month_id, EXTRACT(DAY FROM start_date)as days " & _
                             " from car inner join license on license.car_id = car.car_id where license.status_id = 5 " '& _
                    If ddldate.SelectedValue = 1 Then
                        Select Case rdoshow.SelectedValue
                            Case 0
                                str = str & " and  EXTRACT(YEAR FROM receipt_date) = " & ddlSchyear.SelectedValue

                                If ddlSchMonth.SelectedIndex > 0 Then
                                    str = str & " and  EXTRACT(MONTH FROM receipt_date) = " & ddlSchMonth.SelectedValue
                                End If
                            Case 1
                                str = str & " and  EXTRACT(YEAR FROM receipt_date) = " & ddlSchyear.SelectedValue
                            Case 2

                                If txtsdate.Text <> "" And txtedate.Text <> "" Then
                                    'Dim arr As Array = txtsdate.Text.Split("/")
                                    'Dim tmp_sdate = arr(2) & "-" & arr(0) & "-" & arr(1)
                                    'arr = txtedate.Text.Split("/")
                                    'Dim tmp_edate = arr(2) & "-" & arr(0) & "-" & arr(1)
                                    'str = str & " and  start_date >= '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "'"
                                    str = str & " and  receipt_date between '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(txtedate.Text), "yyyy-MM-dd") & "'"
                                    'str = str & " and  start_date between '" & Format(CDate(tmp_sdate), "yyyy-MM-dd") & "' and '" & Format(CDate(tmp_edate), "yyyy-MM-dd") & "'"

                                End If
                        End Select
                    Else
                        Select Case rdoshow.SelectedValue
                            Case 0
                                str = str & " and  EXTRACT(YEAR FROM start_date) = " & ddlSchyear.SelectedValue

                                If ddlSchMonth.SelectedIndex > 0 Then
                                    str = str & " and  EXTRACT(MONTH FROM start_date) = " & ddlSchMonth.SelectedValue
                                End If
                            Case 1
                                str = str & " and  EXTRACT(YEAR FROM start_date) = " & ddlSchyear.SelectedValue
                            Case 2

                                If txtsdate.Text <> "" And txtedate.Text <> "" Then
                                    'Dim arr As Array = txtsdate.Text.Split("/")
                                    'Dim tmp_sdate = arr(2) & "-" & arr(0) & "-" & arr(1)
                                    'arr = txtedate.Text.Split("/")
                                    'Dim tmp_edate = arr(2) & "-" & arr(0) & "-" & arr(1)
                                    'str = str & " and  start_date >= '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "'"
                                    str = str & " and  start_date between '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(txtedate.Text), "yyyy-MM-dd") & "'"
                                    'str = str & " and  start_date between '" & Format(CDate(tmp_sdate), "yyyy-MM-dd") & "' and '" & Format(CDate(tmp_edate), "yyyy-MM-dd") & "'"

                                End If
                        End Select
                    End If

                    If ddltype.SelectedIndex > 0 Then
                        str = str & " and  typeuser_id = " & ddltype.SelectedValue
                    End If

                    If ddlBorder.SelectedIndex > 0 Then
                        str = str & " and  (checkin_id = " & ddlBorder.SelectedValue & " OR checkout_id = " & ddlBorder.SelectedValue & ")"
                    End If

                    If ddlCountry.SelectedIndex > 0 Then
                        'Error  country_car = 'Lao People's Democratic Republic'
                        'str = str & " and  country_car = '" & ddlCountry.SelectedItem.Text & "'"
                        str = str & " and  replace(replace(country_car,',',''),'''', '') = '" & ddlCountry.SelectedItem.Text.ToString.Replace(",", "").Replace("'", "") & "'"
                    End If

                    str = str & " group by typecar_id, start_date, typeuser_id, EXTRACT(YEAR FROM start_date), EXTRACT(MONTH FROM start_date), EXTRACT(DAY FROM start_date) "

                    str = str & " union all " & _
                        " select count(license.license_id) as cnt_car, typecar_id, start_date, typeuser_id, EXTRACT(YEAR FROM start_date)as year_id, EXTRACT(MONTH FROM start_date)as month_id, EXTRACT(DAY FROM start_date)as days " & _
                             " from license_old license where license.status_id = 5 " '& _

                    If ddldate.SelectedValue = 1 Then
                        Select Case rdoshow.SelectedValue
                            Case 0
                                str = str & " and  EXTRACT(YEAR FROM receipt_date) = " & ddlSchyear.SelectedValue

                                If ddlSchMonth.SelectedIndex > 0 Then
                                    str = str & " and  EXTRACT(MONTH FROM receipt_date) = " & ddlSchMonth.SelectedValue
                                End If
                            Case 1
                                str = str & " and  EXTRACT(YEAR FROM receipt_date) = " & ddlSchyear.SelectedValue
                            Case 2

                                If txtsdate.Text <> "" And txtedate.Text <> "" Then
                                    'Dim arr As Array = txtsdate.Text.Split("/")
                                    'Dim tmp_sdate = arr(2) & "-" & arr(0) & "-" & arr(1)
                                    'arr = txtedate.Text.Split("/")
                                    'Dim tmp_edate = arr(2) & "-" & arr(0) & "-" & arr(1)
                                    'str = str & " and  start_date >= '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "'"
                                    str = str & " and  receipt_date between '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(txtedate.Text), "yyyy-MM-dd") & "'"
                                    'str = str & " and  start_date between '" & Format(CDate(tmp_sdate), "yyyy-MM-dd") & "' and '" & Format(CDate(tmp_edate), "yyyy-MM-dd") & "'"

                                End If
                        End Select
                    Else
                        Select Case rdoshow.SelectedValue
                            Case 0
                                str = str & " and  EXTRACT(YEAR FROM start_date) = " & ddlSchyear.SelectedValue

                                If ddlSchMonth.SelectedIndex > 0 Then
                                    str = str & " and  EXTRACT(MONTH FROM start_date) = " & ddlSchMonth.SelectedValue
                                End If
                            Case 1
                                str = str & " and  EXTRACT(YEAR FROM start_date) = " & ddlSchyear.SelectedValue
                            Case 2

                                If txtsdate.Text <> "" And txtedate.Text <> "" Then
                                    'Dim arr As Array = txtsdate.Text.Split("/")
                                    'Dim tmp_sdate = arr(2) & "-" & arr(0) & "-" & arr(1)
                                    'arr = txtedate.Text.Split("/")
                                    'Dim tmp_edate = arr(2) & "-" & arr(0) & "-" & arr(1)
                                    'str = str & " and  start_date >= '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "'"
                                    str = str & " and  start_date between '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(txtedate.Text), "yyyy-MM-dd") & "'"
                                    'str = str & " and  start_date between '" & Format(CDate(tmp_sdate), "yyyy-MM-dd") & "' and '" & Format(CDate(tmp_edate), "yyyy-MM-dd") & "'"

                                End If
                        End Select
                    End If

                    If ddltype.SelectedIndex > 0 Then
                        str = str & " and  typeuser_id = " & ddltype.SelectedValue
                    End If

                    If ddlBorder.SelectedIndex > 0 Then
                        str = str & " and  (checkin_id = " & ddlBorder.SelectedValue & " OR checkout_id = " & ddlBorder.SelectedValue & ")"
                    End If

                    If ddlCountry.SelectedIndex > 0 Then
                        'Error  country_car = 'Lao People's Democratic Republic'
                        'str = str & " and  country_car = '" & ddlCountry.SelectedItem.Text & "'"
                        str = str & " and  replace(replace(country_car,',',''),'''', '') = '" & ddlCountry.SelectedItem.Text.ToString.Replace(",", "").Replace("'", "") & "'"
                    End If

                    str = str & " group by typecar_id, start_date, typeuser_id, EXTRACT(YEAR FROM start_date), EXTRACT(MONTH FROM start_date), EXTRACT(DAY FROM start_date) "
                Case 2
                    str = " select count(car.car_id) as cnt_car, typecar_id, cond_time, typeuser_id, EXTRACT(YEAR FROM cond_time)as year_id, EXTRACT(MONTH FROM cond_time)as month_id, EXTRACT(DAY FROM cond_time)as days " & _
                             " from car inner join license on license.car_id = car.car_id " & _
                             " inner join condition_rule on condition_rule.license_id = license.license_id " & _
                             " where license.status_id = 5 " '& _

                    Select Case rdoshow.SelectedValue
                        Case 0
                            str = str & " and  EXTRACT(YEAR FROM cond_time) = " & ddlSchyear.SelectedValue

                            If ddlSchMonth.SelectedIndex > 0 Then
                                str = str & " and  EXTRACT(MONTH FROM cond_time) = " & ddlSchMonth.SelectedValue
                            End If
                        Case 1
                            str = str & " and  EXTRACT(YEAR FROM cond_time) = " & ddlSchyear.SelectedValue
                        Case 2

                            If txtsdate.Text <> "" And txtedate.Text <> "" Then
                                'Dim arr As Array = txtsdate.Text.Split("/")
                                'Dim tmp_sdate = arr(2) & "-" & arr(0) & "-" & arr(1)
                                'arr = txtedate.Text.Split("/")
                                'Dim tmp_edate = arr(2) & "-" & arr(0) & "-" & arr(1)
                                'str = str & " and  start_date >= '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "'"
                                str = str & " and  cond_time between '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(txtedate.Text), "yyyy-MM-dd") & "'"
                                'str = str & " and  start_date between '" & Format(CDate(tmp_sdate), "yyyy-MM-dd") & "' and '" & Format(CDate(tmp_edate), "yyyy-MM-dd") & "'"

                            End If
                    End Select

                    If ddltype.SelectedIndex > 0 Then
                        str = str & " and  typeuser_id = " & ddltype.SelectedValue
                    End If

                    If ddlBorder.SelectedIndex > 0 Then
                        str = str & " and  (checkin_id = " & ddlBorder.SelectedValue & " OR checkout_id = " & ddlBorder.SelectedValue & ")"
                    End If

                    If ddlCountry.SelectedIndex > 0 Then
                        'Error  country_car = 'Lao People's Democratic Republic'
                        'str = str & " and  country_car = '" & ddlCountry.SelectedItem.Text & "'"
                        str = str & " and  replace(replace(country_car,',',''),'''', '') = '" & ddlCountry.SelectedItem.Text.ToString.Replace(",", "").Replace("'", "") & "'"
                    End If

                    str = str & " group by typecar_id, cond_time, typeuser_id, EXTRACT(YEAR FROM cond_time), EXTRACT(MONTH FROM cond_time), EXTRACT(DAY FROM cond_time) "
            End Select

            Dim tmp = dbconnect.getDataTable(str, "Type_Car")
            Return tmp
        Catch ex As Exception

        Finally
            dbconnect = Nothing
        End Try
    End Function

    Private tbDataType_Car As New DataTable
    Private tbDataCnt_Car As New DataTable

    Private Function getMonthName(ByVal pIndex As Integer, ByVal pCul As String) As String
        Dim MonthName As String = ""


        If pCul.ToLower = "th" Then
            Select Case pIndex
                Case 1
                    MonthName = "มกราคม"
                Case 2
                    MonthName = "กุมภาพันธ์"
                Case 3
                    MonthName = "มีนาคม"
                Case 4
                    MonthName = "เมษายน"
                Case 5
                    MonthName = "พฤษภาคม"
                Case 6
                    MonthName = "มิถุนายน"
                Case 7
                    MonthName = "กรกฎาคม"
                Case 8
                    MonthName = "สิงหาคม"
                Case 9
                    MonthName = "กันยายน"
                Case 10
                    MonthName = "ตุลาคม"
                Case 11
                    MonthName = "พฤศจิกายน"
                Case 12
                    MonthName = "ธันวาคม"
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


    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles BtnSch.Click
        loaddata()
        'UpdatePanel2.Update()
    End Sub

    Private Function getChart() As String
        Dim styleChart As String = "style='min-width: 300px; height: 380px; margin: 0 auto'"

        Dim divChart1 As String = "<div class='w3-half'><div id='container1' " & styleChart & " ></div></div>"
        Dim divChart2 As String = "<div class='w3-half'><div id='container2' " & styleChart & " ></div></div>"
        Dim divChart3 As String = "<div class='w3-half'><div id='container3' " & styleChart & " ></div></div>"
        Dim divChart4 As String = "<div class='w3-half'><div id='container4' " & styleChart & " ></div></div>"
        Dim divChart5 As String = "<div class='w3-half'><div id='container5' " & styleChart & " ></div></div>"
        Dim divChart6 As String = "<div class='w3-half'><div id='container6' " & styleChart & " ></div></div>"
        Return "<div class='w3-row-padding'>" & divChart1 & divChart2 & "</div>" & _
               "<br/><div class='w3-row-padding'>" & divChart3 & divChart4 & "</div>" & _
               "<br/><div class='w3-row-padding'>" & divChart5 & divChart6 & "</div>"

        'Return "<div class='w3-row-padding'>" & divChart1 & "</div>"

    End Function


    Private Sub LoadChart()
        Dim tr As TableRow
        Dim tc As TableCell

        Dim styleChart As String = "style='max-width: 900px; height: 400px; margin: 0 auto'"

        tr = New TableRow
        tc = New TableCell
        Dim divChart1 As String = "<div id='container1' " & styleChart & " ></div>"
        tc.BorderColor = Drawing.Color.DarkGray
        'tc.BorderWidth = Unit.Pixel(1)
        tc.Width = Unit.Percentage(60)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.Text = divChart1
        tr.Cells.Add(tc)

        tbData.Rows.Add(tr)

        Dim _dataChart As String = "" ' var _data = [  { name: 'ส่งสินค้า', y: 10}, {name: 'รับสินค้า',y: 20 }, {name: 'อื่นๆ', y: 30 } ]; "
        Dim _categories As String = ""

        Dim i As Integer = 1
        Dim _dataMonth_name As String = ""
        Dim _data1 As String = ""
        Dim _data2 As String = ""
        Dim _data3 As String = ""
        Dim _data4 As String = ""
        Dim _data5 As String = ""
        Dim _data6 As String = ""
        Dim _data7 As String = ""
        Dim Dt As DataTable = getCnt_Car(Request.QueryString("sid"))


        Dim nrow As DataRow
        Dim dtset2 As New DataTable
        dtset2.Columns.Add("month_name")
        dtset2.Columns.Add("Cnt_type1", GetType(Decimal))
        dtset2.Columns.Add("Cnt_type2", GetType(Decimal))
        dtset2.Columns.Add("Cnt_type3", GetType(Decimal))
        dtset2.Columns.Add("Cnt_type4", GetType(Decimal))
        dtset2.Columns.Add("Cnt_type5", GetType(Decimal))
        dtset2.Columns.Add("Cnt_type6", GetType(Decimal))
        dtset2.Columns.Add("Cnt_type7", GetType(Decimal))
   
        For int As Integer = 1 To 12
            Try
                nrow = dtset2.NewRow
                nrow.Item("month_name") = getMonthName(int, "th")
                nrow.Item("Cnt_type1") = IIf(Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 1") Is DBNull.Value, 0, Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 1"))
                nrow.Item("Cnt_type2") = IIf(Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 2") Is DBNull.Value, 0, Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 2"))
                nrow.Item("Cnt_type3") = IIf(Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 3") Is DBNull.Value, 0, Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 3"))
                nrow.Item("Cnt_type4") = IIf(Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 4") Is DBNull.Value, 0, Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 4"))
                nrow.Item("Cnt_type5") = IIf(Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 5") Is DBNull.Value, 0, Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 5"))
                nrow.Item("Cnt_type6") = IIf(Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 6") Is DBNull.Value, 0, Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 6"))
                nrow.Item("Cnt_type7") = IIf(Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 7") Is DBNull.Value, 0, Dt.Compute("sum(cnt_car)", "month_id =" & int & " and year_id = " & ddlSchyear.SelectedValue & " and typecar_id = 7"))
                dtset2.Rows.Add(nrow)
                nrow = Nothing
            Catch ex As Exception

            End Try

        Next

        'Dt = dtset2



        For Each dr2 As DataRow In dtset2.Rows
            If _dataMonth_name = "" Then
                _dataMonth_name = " var _dataMonth_name = ['" & dr2("month_name") & "'"
            Else
                _dataMonth_name = _dataMonth_name & " ,  '" & dr2("month_name") & "'"
            End If
            If _data1 = "" Then
                _data1 = " var _data1 = [ {name :'จำนวนรถประเภท ""Motorcycle"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type1") & "}"
            Else
                _data1 = _data1 & ",{name :'จำนวนรถประเภท ""Motorcycle"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type1") & "} "
            End If
            If _data2 = "" Then
                _data2 = " var _data2 = [ {name :'จำนวนรถประเภท ""Passenger Car (≤ 9 seats)"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type2") & "} "
            Else
                _data2 = _data2 & ",{name :'จำนวนรถประเภท ""Passenger Car (≤ 9 seats)"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type2") & "} "
            End If
            If _data3 = "" Then
                _data3 = " var _data3 = [ {name :'จำนวนรถประเภท ""Passenger Car (≤ 12 seats)"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type3") & "} "
            Else
                _data3 = _data3 & ",{name :'จำนวนรถประเภท ""Passenger Car (≤ 12 seats)"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type3") & "} "
            End If
            If _data4 = "" Then
                _data4 = " var _data4 = [ {name :'จำนวนรถประเภท ""Pickup Truck (≤ 3,500 kg)"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type4") & "} "
            Else
                _data4 = _data4 & ",{name :'จำนวนรถประเภท ""Pickup Truck (≤ 3,500 kg)"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type4") & "} "
            End If
            If _data5 = "" Then
                _data5 = " var _data5 = [ {name :'จำนวนรถประเภท ""Van (≤ 12 seats)"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type5") & "} "
            Else
                _data5 = _data5 & ",{name :'จำนวนรถประเภท ""Van (≤ 12 seats)"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type5") & "} "
            End If
            If _data6 = "" Then
                _data6 = " var _data6 = [ {name :'จำนวนรถประเภท ""Bus"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type6") & "} "
            Else
                _data6 = _data6 & ",{name :'จำนวนรถประเภท ""Bus"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type6") & "} "
            End If
            If _data7 = "" Then
                _data7 = " var _data7 = [ {name :'จำนวนรถประเภท ""Truck"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type7") & "} "
            Else
                _data7 = _data7 & ",{name :'จำนวนรถประเภท ""Truck"" เดือน" & dr2("month_name") & "', y: " & dr2("Cnt_type7") & "} "
            End If


        Next
        _dataMonth_name = _dataMonth_name & " ]; "
        _data1 = _data1 & " ]; "
        _data2 = _data2 & " ]; "
        _data3 = _data3 & " ]; "
        _data4 = _data4 & " ]; "
        _data5 = _data5 & " ]; "
        _data6 = _data6 & " ]; "
        _data7 = _data7 & " ]; "
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> " & _data1 & _data2 & _data3 & _data4 & _data5 & _data6 & _data7 & _dataMonth_name & " AddChart(_data1,_data2,_data3,_data4,_data5,_data6,_data7,_dataMonth_name); </script>" & _
                                            " ShowData(); ", False)
        'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", pScript & "ShowData();", True)
    End Sub

End Class
