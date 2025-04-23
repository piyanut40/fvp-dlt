Imports System.Data
Imports Npgsql
Imports System.IO

Partial Class Admin_RptStat
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


        Select Case rdoshow.SelectedValue
            Case 0
                If ddlSchMonth.SelectedIndex = 0 Then
                    pScript = "alert('กรุณาระบุเดือน!');"
                Else
                    LoadTableDay()
                End If

            Case 1
                LoadTableMonth()
            Case 2
                If txtsdate.Text = "" Or txtedate.Text = "" Then
                    pScript = "alert('กรุณาระบุช่วงวันที่!');"
                Else
                    LoadTableDateRange()
                End If
        End Select

        ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", pScript & "ShowData();", True)
    End Sub

    Private Function getType_Car() As DataTable
        Dim dbconnect As New DBConnect
        Try
            Dim str As String = " select * from type_car order by type_id "
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
                    str = " select count(car.car_id) as cnt_car, typecar_id, travel_group.start_date, typeuser_id, EXTRACT(YEAR FROM travel_group.start_date)as year_id, EXTRACT(MONTH FROM travel_group.start_date)as month_id, EXTRACT(DAY FROM travel_group.start_date)as days " & _
                            " from license left join car on license.car_id = car.car_id " & _
                            " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  " & _
                            " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
                            " where license.status_id = 5 " '& _

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

                           
                                Try
                                    str = str & " and  receipt_date between '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(txtedate.Text), "yyyy-MM-dd") & "'"
                                Catch ex As Exception
                                   
                                    Dim arr1 As Array = txtsdate.Text.Split("/")
                                    Dim dd1 As String = arr1(0) '"01"
                                    Dim MM1 As String = arr1(1) '"08"
                                    Dim yyyy1 As String = arr1(2) '"2019"
                                    Dim tmp_start As Date = New Date(yyyy1, MM1, dd1)

                                    Dim arr As Array = txtedate.Text.Split("/")
                                    Dim dd As String = arr(0) '"01"
                                    Dim MM As String = arr(1) '"08"
                                    Dim yyyy As String = arr(2) '"2019"
                                    Dim tmp_end As Date = New Date(yyyy, MM, dd)

                                    str = str & " and  receipt_date between '" & Format(CDate(tmp_start), "yyyy-MM-dd") & "' and '" & Format(CDate(tmp_end), "yyyy-MM-dd") & "'"
                                End Try
                        End Select
                    Else
                        Select Case rdoshow.SelectedValue
                            Case 0
                                str = str & " and  EXTRACT(YEAR FROM travel_group.start_date) = " & ddlSchyear.SelectedValue

                                If ddlSchMonth.SelectedIndex > 0 Then
                                    str = str & " and  EXTRACT(MONTH FROM travel_group.start_date) = " & ddlSchMonth.SelectedValue
                                End If
                            Case 1
                                str = str & " and  EXTRACT(YEAR FROM travel_group.start_date) = " & ddlSchyear.SelectedValue
                            Case 2

                               
                                Try
                                    str = str & " and  travel_group.start_date between '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(txtedate.Text), "yyyy-MM-dd") & "'"
                                Catch ex As Exception


                                    Dim arr1 As Array = txtsdate.Text.Split("/")
                                    Dim dd1 As String = arr1(0) '"01"
                                    Dim MM1 As String = arr1(1) '"08"
                                    Dim yyyy1 As String = arr1(2) '"2019"
                                    Dim tmp_start As Date = New Date(yyyy1, MM1, dd1)

                                    Dim arr As Array = txtedate.Text.Split("/")
                                    Dim dd As String = arr(0) '"01"
                                    Dim MM As String = arr(1) '"08"
                                    Dim yyyy As String = arr(2) '"2019"
                                    Dim tmp_end As Date = New Date(yyyy, MM, dd)

                                    str = str & " and  travel_group.start_date between '" & Format(CDate(tmp_start), "yyyy-MM-dd") & "' and '" & Format(CDate(tmp_end), "yyyy-MM-dd") & "'"
                                End Try
                        End Select
                    End If

                    If ddltype.SelectedIndex > 0 Then
                        str = str & " and  typeuser_id = " & ddltype.SelectedValue
                    End If

                    If ddlBorder.SelectedIndex > 0 Then
                        str = str & " and  (travel_group.checkin_id = " & ddlBorder.SelectedValue & " OR travel_group.checkout_id = " & ddlBorder.SelectedValue & ")"
                    End If

                    If ddlCountry.SelectedIndex > 0 Then
                        str = str & " and  country_car = '" & ddlCountry.SelectedItem.Text & "'"
                    End If

                    str = str & " group by typecar_id, travel_group.start_date, typeuser_id, EXTRACT(YEAR FROM travel_group.start_date), EXTRACT(MONTH FROM travel_group.start_date), EXTRACT(DAY FROM travel_group.start_date) "

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

                            
                                Try
                                    str = str & " and  receipt_date between '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(txtedate.Text), "yyyy-MM-dd") & "'"
                                Catch ex As Exception


                                    Dim arr1 As Array = txtsdate.Text.Split("/")
                                    Dim dd1 As String = arr1(0) '"01"
                                    Dim MM1 As String = arr1(1) '"08"
                                    Dim yyyy1 As String = arr1(2) '"2019"
                                    Dim tmp_start As Date = New Date(yyyy1, MM1, dd1)

                                    Dim arr As Array = txtedate.Text.Split("/")
                                    Dim dd As String = arr(0) '"01"
                                    Dim MM As String = arr(1) '"08"
                                    Dim yyyy As String = arr(2) '"2019"
                                    Dim tmp_end As Date = New Date(yyyy, MM, dd)

                                    str = str & " and  receipt_date between '" & Format(CDate(tmp_start), "yyyy-MM-dd") & "' and '" & Format(CDate(tmp_end), "yyyy-MM-dd") & "'"
                                End Try
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

                               
                                Try
                                    str = str & " and  start_date between '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(txtedate.Text), "yyyy-MM-dd") & "'"
                                Catch ex As Exception


                                    Dim arr1 As Array = txtsdate.Text.Split("/")
                                    Dim dd1 As String = arr1(0) '"01"
                                    Dim MM1 As String = arr1(1) '"08"
                                    Dim yyyy1 As String = arr1(2) '"2019"
                                    Dim tmp_start As Date = New Date(yyyy1, MM1, dd1)

                                    Dim arr As Array = txtedate.Text.Split("/")
                                    Dim dd As String = arr(0) '"01"
                                    Dim MM As String = arr(1) '"08"
                                    Dim yyyy As String = arr(2) '"2019"
                                    Dim tmp_end As Date = New Date(yyyy, MM, dd)

                                    str = str & " and  start_date between '" & Format(CDate(tmp_start), "yyyy-MM-dd") & "' and '" & Format(CDate(tmp_end), "yyyy-MM-dd") & "'"
                                End Try
                        End Select
                    End If

                    If ddltype.SelectedIndex > 0 Then
                        str = str & " and  typeuser_id = " & ddltype.SelectedValue
                    End If

                    If ddlBorder.SelectedIndex > 0 Then
                        str = str & " and  (checkin_id = " & ddlBorder.SelectedValue & " OR checkout_id = " & ddlBorder.SelectedValue & ")"
                    End If

                    If ddlCountry.SelectedIndex > 0 Then
                        str = str & " and  country_car = '" & ddlCountry.SelectedItem.Text & "'"
                    End If

                    str = str & " group by typecar_id, start_date, typeuser_id, EXTRACT(YEAR FROM start_date), EXTRACT(MONTH FROM start_date), EXTRACT(DAY FROM start_date) "
                Case 2
                    str = " select count(car.car_id) as cnt_car, typecar_id, cond_time, typeuser_id, EXTRACT(YEAR FROM cond_time)as year_id, EXTRACT(MONTH FROM cond_time)as month_id, EXTRACT(DAY FROM cond_time)as days " & _
                             " from license left join car on license.car_id = car.car_id " & _
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
                             
                                Try
                                    str = str & " and  cond_time between '" & Format(CDate(txtsdate.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(txtedate.Text), "yyyy-MM-dd") & "'"
                                Catch ex As Exception


                                    Dim arr1 As Array = txtsdate.Text.Split("/")
                                    Dim dd1 As String = arr1(0) '"01"
                                    Dim MM1 As String = arr1(1) '"08"
                                    Dim yyyy1 As String = arr1(2) '"2019"
                                    Dim tmp_start As Date = New Date(yyyy1, MM1, dd1)

                                    Dim arr As Array = txtedate.Text.Split("/")
                                    Dim dd As String = arr(0) '"01"
                                    Dim MM As String = arr(1) '"08"
                                    Dim yyyy As String = arr(2) '"2019"
                                    Dim tmp_end As Date = New Date(yyyy, MM, dd)

                                    str = str & " and  cond_time between '" & Format(CDate(tmp_start), "yyyy-MM-dd") & "' and '" & Format(CDate(tmp_end), "yyyy-MM-dd") & "'"
                                End Try
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
                        str = str & " and  country_car = '" & ddlCountry.SelectedItem.Text & "'"
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
#Region "XLoadTable"
    Private Sub XLoadTable()
       
        tbDataType_Car = getType_Car()
        Dim tr = New TableRow 'ขึ้นบรรทัดใหม่
        Dim tc = New TableCell
        tbData.Rows.Clear()
        Dim Index0 As Integer = 1
        Dim Index1 As Integer = 1

        tr = New TableRow
        tc = New TableCell
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.Text = "ประเภทรถที่ขออนุญาต"
        tc.Width = Unit.Pixel(150)
        tc.RowSpan = 2
        PopulateS.AddCssTableCell("HeadRowTbCell", tc)
        tr.Cells.Add(tc)


        tc = New TableCell
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.Text = ddlSchyear.SelectedValue
        tc.ColumnSpan = 12
        tc.Width = Unit.Pixel(150)
        PopulateS.AddCssTableCell("HeadRowTbCell", tc)
        tr.Cells.Add(tc)
        tbData.Rows.Add(tr)


        tr = New TableRow
        For i As Integer = 1 To 12
            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.Text = getMonthName(i, "th")
            tc.Width = Unit.Pixel(110)
            PopulateS.AddCssTableCell("HeadRowTbCell", tc)
            tr.Cells.Add(tc)
        Next
        tbData.Rows.Add(tr)


        tbData.Rows.Add(tr)
        Dim a1 As Integer = 7
        Dim a2 As Integer = 1
        Dim b1 As Integer = 77
        Dim b2 As Integer = 1
       

        For Each dr As DataRow In tbDataType_Car.Rows
            tr = New TableRow
            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Left
            tc.Text = dr("type_name")
            PopulateS.AddCssTableCell("RowTbCell", tc)
            tr.Cells.Add(tc)

            For i As Integer = 1 To 12
                tc = New TableCell
                tc.HorizontalAlign = HorizontalAlign.Right
                If i <= 4 Then
                    If a2 Mod 2 = 0 Then
                        tc.Text = a1 * 1
                    Else
                        tc.Text = a1 * 2
                    End If
                Else
                    tc.Text = 0
                End If

                tc.Width = Unit.Pixel(110)
                PopulateS.AddCssTableCell("RowTbCell", tc)
                tr.Cells.Add(tc)
                If a2 Mod 2 = 0 Then
                    a1 = a1 - 1
                Else
                    a1 = a1 + 2
                End If

            Next
            tbData.Rows.Add(tr)

            a2 = a2 + 1
        Next
        
        tr = New TableRow
        tc = New TableCell
        tc.HorizontalAlign = HorizontalAlign.Right
        tc.Text = "รวมทั้งหมด"
        tc.Width = Unit.Pixel(150)
        PopulateS.AddCssTableCell("HeadRowTbCell", tc)
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.HorizontalAlign = HorizontalAlign.Right

        tc.Text = "329"
        tc.Width = Unit.Pixel(110)
        PopulateS.AddCssTableCell("HeadRowTbCell", tc)
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.HorizontalAlign = HorizontalAlign.Right

        tc.Text = "342"
        tc.Width = Unit.Pixel(110)
        PopulateS.AddCssTableCell("HeadRowTbCell", tc)
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.HorizontalAlign = HorizontalAlign.Right

        tc.Text = "355"
        tc.Width = Unit.Pixel(110)
        PopulateS.AddCssTableCell("HeadRowTbCell", tc)
        tr.Cells.Add(tc)

        tc = New TableCell
        tc.HorizontalAlign = HorizontalAlign.Right

        tc.Text = "368"
        tc.Width = Unit.Pixel(110)
        PopulateS.AddCssTableCell("HeadRowTbCell", tc)
        tr.Cells.Add(tc)
        For i As Integer = 5 To 12
            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Right

            tc.Text = 0
            tc.Width = Unit.Pixel(110)
            PopulateS.AddCssTableCell("HeadRowTbCell", tc)
            tr.Cells.Add(tc)
        Next

        tbData.Rows.Add(tr)

       

        tbData.Rows.Add(tr)
    End Sub
#End Region

    Private Sub LoadTableMonth()

        Try
            Dim tr = New TableRow
            Dim tc = New TableCell
            tbData.Rows.Clear()
            Dim Index0 As Integer = 1
            Dim Index1 As Integer = 1

            tr = New TableRow
            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.Text = "เดือน"
            tc.Width = Unit.Pixel(150)
            'tc.RowSpan = 2
            PopulateS.AddCssTableCell("HeadRowTbCell", tc)
            tr.Cells.Add(tc)


            tbData.Rows.Add(tr)

            For Each dr As DataRow In tbDataType_Car.Rows ' For i As Integer = 1 To 12
                tc = New TableCell
                tc.HorizontalAlign = HorizontalAlign.Center

                If dr("type_name").ToString.IndexOf("(") > 0 Then
                    tc.Text = dr("type_name").ToString.Replace("(", "<br />(")
                Else
                    tc.Text = dr("type_name")
                End If

                PopulateS.AddCssTableCell("HeadRowTbCell", tc)
                tr.Cells.Add(tc)
            Next

            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.Text = "รวมทั้งหมด"
            PopulateS.AddCssTableCell("FooterRowTbCell", tc)
            tr.Cells.Add(tc)

            tbData.Rows.Add(tr)


            tr = New TableRow
            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.Text = ddlSchyear.SelectedValue
            tc.ColumnSpan = 14
            tc.Width = Unit.Pixel(150)
            PopulateS.AddCssTableCell("SubHeadRowTbCell", tc)
            tr.Cells.Add(tc)

            tbData.Rows.Add(tr)

            For i As Integer = 1 To 12 'For Each dr As DataRow In tbDataType_Car.Rows
                tr = New TableRow
                tc = New TableCell
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.Text = getMonthName(i, "th")
                tc.Width = Unit.Pixel(150)
                PopulateS.AddCssTableCell("HeadRowTbCell", tc)
                tr.Cells.Add(tc)

                For Each dr As DataRow In tbDataType_Car.Rows 'For i As Integer = 1 To 12

                    tc = New TableCell
                    tc.HorizontalAlign = HorizontalAlign.Right

                    If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue & " and month_id = " & i & " and typecar_id = " & dr("type_id")).Length = 0 Then
                        tc.Text = 0
                    Else
                        tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & "and month_id = " & i & " and typecar_id = " & dr("type_id")), "#,##0")
                    End If


                    PopulateS.AddCssTableCell("RowTbCell", tc)
                    tr.Cells.Add(tc)

                Next
                tc = New TableCell
                tc.HorizontalAlign = HorizontalAlign.Right
                If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue & " and month_id = " & i).Length = 0 Then
                    tc.Text = 0
                Else
                    tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & "and month_id = " & i & " and typecar_id is not null "), "#,##0")
                End If
                tc.Width = Unit.Pixel(110)
                PopulateS.AddCssTableCell("FooterRowTbCell", tc)
                tr.Cells.Add(tc)

                tbData.Rows.Add(tr)

            Next




            tr = New TableRow
            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Right
            tc.Text = "รวมทั้งหมด"
            tc.Width = Unit.Pixel(150)
            PopulateS.AddCssTableCell("FooterRowTbCell", tc)
            tr.Cells.Add(tc)

            For Each dr As DataRow In tbDataType_Car.Rows ' For i As Integer = 5 To 12
                tc = New TableCell
                tc.HorizontalAlign = HorizontalAlign.Right

                If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue & " and typecar_id = " & dr("type_id")).Length = 0 Then
                    tc.Text = 0
                Else
                    tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & " and typecar_id = " & dr("type_id")), "#,##0")
                End If
                tc.Width = Unit.Percentage(10)
                PopulateS.AddCssTableCell("FooterRowTbCell", tc)
                tr.Cells.Add(tc)
            Next

            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Right

            If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue).Length = 0 Then
                tc.Text = 0
            Else
                tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & " and typecar_id is not null "), "#,##0")
            End If
            tc.Width = Unit.Pixel(110)
            PopulateS.AddCssTableCell("FooterRowTbCell", tc)
            tr.Cells.Add(tc)

            tbData.Rows.Add(tr)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadTableDay()
        Try
            Dim days As Integer = 31
            Dim months_value As Integer
            If ddlSchMonth.SelectedIndex > 0 Then
                months_value = ddlSchMonth.SelectedValue
            Else
                months_value = Month(Now)
            End If
            Select Case months_value
                Case 1, 3, 5, 7, 8, 10, 12
                    days = 31
                Case 4, 6, 9, 11
                    days = 30
                Case 2
                    If ddlSchyear.SelectedValue Mod 4 = 0 Then
                        days = 29
                    Else
                        days = 28
                    End If
            End Select

            Dim tr = New TableRow
            Dim tc = New TableCell
            tbData.Rows.Clear()
            Dim Index0 As Integer = 1
            Dim Index1 As Integer = 1

            tr = New TableRow
            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.Text = "วันที่"
            tc.Width = Unit.Pixel(150)
            'tc.RowSpan = 2
            PopulateS.AddCssTableCell("HeadRowTbCell", tc)
            tr.Cells.Add(tc)


            tbData.Rows.Add(tr)

            For Each dr As DataRow In tbDataType_Car.Rows ' For i As Integer = 1 To 12

                tc = New TableCell
                tc.HorizontalAlign = HorizontalAlign.Center

                If dr("type_name").ToString.IndexOf("(") > 0 Then
                    tc.Text = dr("type_name").ToString.Replace("(", "<br />(")
                Else
                    tc.Text = dr("type_name")
                End If

                PopulateS.AddCssTableCell("HeadRowTbCell", tc)
                tr.Cells.Add(tc)
            Next

            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.Text = "รวมทั้งหมด"
            PopulateS.AddCssTableCell("FooterRowTbCell", tc)
            tr.Cells.Add(tc)

            tbData.Rows.Add(tr)


            tr = New TableRow
            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.Text = getMonthName(months_value, "th") & " " & ddlSchyear.SelectedValue
            tc.ColumnSpan = 14
            tc.Width = Unit.Pixel(150)
            PopulateS.AddCssTableCell("SubHeadRowTbCell", tc)
            tr.Cells.Add(tc)

            tbData.Rows.Add(tr)

            For i As Integer = 1 To days 'For Each dr As DataRow In tbDataType_Car.Rows
                tr = New TableRow
                tc = New TableCell
                tc.HorizontalAlign = HorizontalAlign.Center
                tc.Text = i 'getMonthName(i, "th")
                tc.Width = Unit.Pixel(150)
                PopulateS.AddCssTableCell("HeadRowTbCell", tc)
                tr.Cells.Add(tc)

                For Each dr As DataRow In tbDataType_Car.Rows 'For i As Integer = 1 To 12

                    tc = New TableCell
                    tc.HorizontalAlign = HorizontalAlign.Right

                    If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue & " and days = " & i & " and typecar_id = " & dr("type_id")).Length = 0 Then
                        tc.Text = 0
                    Else
                        tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & "and days = " & i & " and typecar_id = " & dr("type_id")), "#,##0")
                    End If


                    PopulateS.AddCssTableCell("RowTbCell", tc)
                    tr.Cells.Add(tc)

                Next
                tc = New TableCell
                tc.HorizontalAlign = HorizontalAlign.Right
                If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue & " and days = " & i).Length = 0 Then
                    tc.Text = 0
                Else
                    tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & "and days = " & i), "#,##0")
                End If
                tc.Width = Unit.Pixel(110)
                PopulateS.AddCssTableCell("FooterRowTbCell", tc)
                tr.Cells.Add(tc)

                tbData.Rows.Add(tr)

            Next




            tr = New TableRow
            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Right
            tc.Text = "รวมทั้งหมด"
            tc.Width = Unit.Pixel(150)
            PopulateS.AddCssTableCell("FooterRowTbCell", tc)
            tr.Cells.Add(tc)

            For Each dr As DataRow In tbDataType_Car.Rows ' For i As Integer = 5 To 12
                tc = New TableCell
                tc.HorizontalAlign = HorizontalAlign.Right

                If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue & " and typecar_id = " & dr("type_id")).Length = 0 Then
                    tc.Text = 0
                Else
                    tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & " and typecar_id = " & dr("type_id")), "#,##0")
                End If
                tc.Width = Unit.Percentage(10)
                PopulateS.AddCssTableCell("FooterRowTbCell", tc)
                tr.Cells.Add(tc)
            Next

            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Right

            If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue).Length = 0 Then
                tc.Text = 0
            Else
                tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue), "#,##0")
            End If
            tc.Width = Unit.Pixel(110)
            PopulateS.AddCssTableCell("FooterRowTbCell", tc)
            tr.Cells.Add(tc)

            tbData.Rows.Add(tr)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub LoadTableDateRange()
        Try
            Dim tmp_start, tmp_end As Date
            Try
                tmp_start = CDate(txtsdate.Text)
                tmp_end = CDate(txtedate.Text)
            Catch ex As Exception


                Dim arr1 As Array = txtsdate.Text.Split("/")
                Dim dd1 As String = arr1(0) '"01"
                Dim MM1 As String = arr1(1) '"08"
                Dim yyyy1 As String = arr1(2) '"2019"
                tmp_start = New Date(yyyy1, MM1, dd1)

                Dim arr As Array = txtedate.Text.Split("/")
                Dim dd As String = arr(0) '"01"
                Dim MM As String = arr(1) '"08"
                Dim yyyy As String = arr(2) '"2019"
                tmp_end = New Date(yyyy, MM, dd)
            End Try
            

          
            Dim tmp_sdate, tmp_edate, tmp_smonth, tmp_emonth, tmp_syear, tmp_eyear As Integer
            Dim days As Integer = 31
            Dim tmp_day As Integer
            Dim months_value, monthe_value As Integer
            
            tmp_sdate = Day(tmp_start)
            tmp_edate = Day(tmp_end)

            tmp_smonth = Month(tmp_start)
            tmp_emonth = Month(tmp_end)

            tmp_syear = Year(tmp_start)
            tmp_eyear = Year(tmp_end)

           

            Dim tr = New TableRow
            Dim tc = New TableCell
            tbData.Rows.Clear()
            Dim Index0 As Integer = 1
            Dim Index1 As Integer = 1

            tr = New TableRow
            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.Text = "วันที่"
            tc.Width = Unit.Pixel(150)
            'tc.RowSpan = 2
            PopulateS.AddCssTableCell("HeadRowTbCell", tc)
            tr.Cells.Add(tc)


            tbData.Rows.Add(tr)


            For Each dr As DataRow In tbDataType_Car.Rows ' For i As Integer = 1 To 12

                tc = New TableCell
                tc.HorizontalAlign = HorizontalAlign.Center

                If dr("type_name").ToString.IndexOf("(") > 0 Then
                    tc.Text = dr("type_name").ToString.Replace("(", "<br />(")
                Else
                    tc.Text = dr("type_name")
                End If

                PopulateS.AddCssTableCell("HeadRowTbCell", tc)
                tr.Cells.Add(tc)
            Next

            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.Text = "รวมทั้งหมด"
            PopulateS.AddCssTableCell("FooterRowTbCell", tc)
            tr.Cells.Add(tc)

            tbData.Rows.Add(tr)

            For int_year As Integer = tmp_syear To tmp_eyear
           

                If int_year <> tmp_eyear Then
                    monthe_value = 12
                    If int_year <> tmp_syear Then
                        months_value = 1
                    Else
                        months_value = tmp_smonth
                    End If
                Else
                    monthe_value = tmp_emonth
                    If tmp_syear <> tmp_eyear Then
                        months_value = 1
                    Else
                        months_value = tmp_smonth
                    End If
                End If

                For int_month As Integer = months_value To monthe_value
                    tr = New TableRow
                    tc = New TableCell
                    tc.HorizontalAlign = HorizontalAlign.Center

                  
                    tc.Text = getMonthName(int_month, "th") & " " & int_year

                    tc.Width = Unit.Pixel(150)
                    PopulateS.AddCssTableCell("SubHeadRowTbCell", tc)
                    tr.Cells.Add(tc)

                    For Each dr As DataRow In tbDataType_Car.Rows ' For i As Integer = 5 To 12
                        tc = New TableCell
                        tc.HorizontalAlign = HorizontalAlign.Right


                        If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue & " and month_id = " & int_month & " and typecar_id = " & dr("type_id")).Length = 0 Then
                            tc.Text = 0
                        Else
                            tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & " and month_id = " & int_month & " and typecar_id = " & dr("type_id")), "#,##0")
                        End If
                        tc.Width = Unit.Percentage(10)
                        PopulateS.AddCssTableCell("SubHeadRowTbCell", tc)
                        tc.Style("Padding-Right") = "8px"
                        tr.Cells.Add(tc)
                    Next

                    tc = New TableCell
                    tc.HorizontalAlign = HorizontalAlign.Right

                  
                    If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue & " and month_id = " & int_month).Length = 0 Then
                        tc.Text = 0
                    Else
                        tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & " and month_id = " & int_month), "#,##0")
                    End If
                    tc.Width = Unit.Pixel(110)
                    PopulateS.AddCssTableCell("SubHeadRowTbCell", tc)
                    tc.Style("Padding-Right") = "8px"
                    tr.Cells.Add(tc)

                    tbData.Rows.Add(tr)

                    Select Case int_month 'tmp_month
                        Case 1, 3, 5, 7, 8, 10, 12
                            days = 31
                        Case 4, 6, 9, 11
                            days = 30
                        Case 2
                            If ddlSchyear.SelectedValue Mod 4 = 0 Then
                                days = 29
                            Else
                                days = 28
                            End If
                    End Select
                    If int_month = tmp_smonth And int_year = tmp_syear Then
                        tmp_day = tmp_sdate
                    Else
                        tmp_day = 1
                    End If
                    If int_month = monthe_value And int_year = tmp_eyear Then
                        days = tmp_edate
                    End If
                    For i As Integer = tmp_day To days 'For Each dr As DataRow In tbDataType_Car.Rows
                        tr = New TableRow
                        tc = New TableCell
                        tc.HorizontalAlign = HorizontalAlign.Center
                        tc.Text = i 'getMonthName(i, "th")
                        tc.Width = Unit.Pixel(150)
                        PopulateS.AddCssTableCell("HeadRowTbCell", tc)
                        tr.Cells.Add(tc)

                        For Each dr As DataRow In tbDataType_Car.Rows 'For i As Integer = 1 To 12

                            tc = New TableCell
                            tc.HorizontalAlign = HorizontalAlign.Right

                          
                            If tbDataCnt_Car.Select("year_id = " & int_year & " and month_id = " & int_month & " and days = " & i & " and typecar_id = " & dr("type_id")).Length = 0 Then
                                tc.Text = 0
                            Else
                                tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & int_year & " and month_id = " & int_month & " and days = " & i & " and typecar_id = " & dr("type_id")), "#,##0")
                            End If


                            PopulateS.AddCssTableCell("RowTbCell", tc)
                            tr.Cells.Add(tc)

                        Next
                        tc = New TableCell
                        tc.HorizontalAlign = HorizontalAlign.Right
                       

                        If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue & " and month_id = " & int_month & " and days = " & i).Length = 0 Then
                            tc.Text = 0
                        Else
                            tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & int_year & " and month_id = " & int_month & " and days = " & i), "#,##0")
                        End If
                        tc.Width = Unit.Pixel(110)
                        PopulateS.AddCssTableCell("FooterRowTbCell", tc)
                        tr.Cells.Add(tc)

                        tbData.Rows.Add(tr)

                    Next
                   
                Next



            Next





            tr = New TableRow
            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Right
            tc.Text = "รวมทั้งหมด"
            tc.Width = Unit.Pixel(150)
            PopulateS.AddCssTableCell("FooterRowTbCell", tc)
            tr.Cells.Add(tc)

            For Each dr As DataRow In tbDataType_Car.Rows ' For i As Integer = 5 To 12
                tc = New TableCell
                tc.HorizontalAlign = HorizontalAlign.Right

                If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue & " and typecar_id = " & dr("type_id")).Length = 0 Then
                    tc.Text = 0
                Else
                    tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & " and typecar_id = " & dr("type_id")), "#,##0")
                End If
                tc.Width = Unit.Percentage(10)
                PopulateS.AddCssTableCell("FooterRowTbCell", tc)
                tr.Cells.Add(tc)
            Next

            tc = New TableCell
            tc.HorizontalAlign = HorizontalAlign.Right

            If tbDataCnt_Car.Select("year_id = " & ddlSchyear.SelectedValue).Length = 0 Then
                tc.Text = 0
            Else
                tc.Text = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue), "#,##0")
            End If
            tc.Width = Unit.Pixel(110)
            PopulateS.AddCssTableCell("FooterRowTbCell", tc)
            tr.Cells.Add(tc)

            tbData.Rows.Add(tr)
        Catch ex As Exception

        End Try


    End Sub

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


    Private Function LoadDataExport(ByVal IsExcel As Boolean) As DataTable
        tbDataType_Car = getType_Car()
        If Not (Request.QueryString("sid") Is Nothing) Then
            tbDataCnt_Car = getCnt_Car(Request.QueryString("sid"))
        Else
            tbDataCnt_Car = getCnt_Car(1)
        End If
        Dim dtChart As DataTable = tbDataCnt_Car
        If IsExcel Then
            Dim dtExcel As New DataTable
            dtExcel = New DataTable
            With dtExcel
                .Columns.Add("no")
                .Columns.Add("_name")
                For Each dr As DataRow In tbDataType_Car.Select("", "type_id")
                    .Columns.Add("_type" & dr("type_id"))
                Next
                .Columns.Add("sum")
            End With
            If rdoshow.SelectedValue = 0 Then
                'รายวัน
                Dim days As Integer = 31
                Dim months_value As Integer
                If ddlSchMonth.SelectedIndex > 0 Then
                    months_value = ddlSchMonth.SelectedValue
                Else
                    months_value = Month(Now)
                End If
                Select Case months_value
                    Case 1, 3, 5, 7, 8, 10, 12
                        days = 31
                    Case 4, 6, 9, 11
                        days = 30
                    Case 2
                        If ddlSchyear.SelectedValue Mod 4 = 0 Then
                            days = 29
                        Else
                            days = 28
                        End If
                End Select

                Dim _order As Integer = 1
                For i As Integer = 1 To days
                    Dim nrow As DataRow = dtExcel.NewRow
                    nrow.Item("no") = _order
                    'nrow.Item("_name") = getMonthName(i, "th")
                    Dim _sum As Object = 0
                    For Each dr As DataRow In tbDataType_Car.Select("", "type_id")
                        Dim Sum_cnt_car As Object
                        Try
                            Sum_cnt_car = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & "and days = " & i & " and typecar_id = " & dr("type_id")), "#,##0")
                        Catch ex As Exception
                            Sum_cnt_car = 0
                        End Try
                        nrow.Item("_type" & dr("type_id")) = Sum_cnt_car
                        _sum = _sum + Sum_cnt_car
                    Next
                    nrow.Item("sum") = _sum
                    dtExcel.Rows.Add(nrow)
                    nrow = Nothing
                    _order = _order + 1
                Next


                Dim nrow2 As DataRow = dtExcel.NewRow
                'nrow.Item("no") = _order
                nrow2.Item("no") = "รวมทั้งหมด"
                Dim _sum2 As Object = 0
                For Each dr As DataRow In tbDataType_Car.Select("", "type_id")
                    Dim Sum_cnt_car As Object
                    Try
                        Sum_cnt_car = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & " and typecar_id = " & dr("type_id")), "#,##0")
                    Catch ex As Exception
                        Sum_cnt_car = 0
                    End Try
                    nrow2.Item("_type" & dr("type_id")) = Sum_cnt_car
                    _sum2 = _sum2 + Sum_cnt_car
                Next
                nrow2.Item("sum") = _sum2
                dtExcel.Rows.Add(nrow2)
                nrow2 = Nothing
                dtExcel.Columns.Remove("_name")
            ElseIf rdoshow.SelectedValue = 1 Then
                'รายเดือน
                Dim _order As Integer = 1
                For i As Integer = 1 To 12
                    Dim nrow As DataRow = dtExcel.NewRow
                    nrow.Item("no") = _order
                    nrow.Item("_name") = getMonthName(i, "th")
                    Dim _sum As Object = 0
                    For Each dr As DataRow In tbDataType_Car.Select("", "type_id")
                        Dim Sum_cnt_car As Object
                        Try
                            Sum_cnt_car = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & "and month_id = " & i & " and typecar_id = " & dr("type_id")), "#,##0")
                        Catch ex As Exception
                            Sum_cnt_car = 0
                        End Try
                        nrow.Item("_type" & dr("type_id")) = Sum_cnt_car
                        _sum = _sum + Sum_cnt_car
                    Next
                    nrow.Item("sum") = _sum
                    dtExcel.Rows.Add(nrow)
                    nrow = Nothing
                    _order = _order + 1
                Next

                Dim nrow2 As DataRow = dtExcel.NewRow
                'nrow.Item("no") = _order
                nrow2.Item("_name") = "รวมทั้งหมด"
                Dim _sum2 As Object = 0
                For Each dr As DataRow In tbDataType_Car.Select("", "type_id")
                    Dim Sum_cnt_car As Object
                    Try
                        Sum_cnt_car = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & " and typecar_id = " & dr("type_id")), "#,##0")
                    Catch ex As Exception
                        Sum_cnt_car = 0
                    End Try
                    nrow2.Item("_type" & dr("type_id")) = Sum_cnt_car
                    _sum2 = _sum2 + Sum_cnt_car
                Next
                nrow2.Item("sum") = _sum2
                dtExcel.Rows.Add(nrow2)
                nrow2 = Nothing
            ElseIf rdoshow.SelectedValue = 2 Then
                
                Dim tmp_start, tmp_end As Date
                Try
                    tmp_start = CDate(txtsdate.Text)
                    tmp_end = CDate(txtedate.Text)
                Catch ex As Exception
                   
                    Dim arr1 As Array = txtsdate.Text.Split("/")
                    Dim dd1 As String = arr1(0) '"01"
                    Dim MM1 As String = arr1(1) '"08"
                    Dim yyyy1 As String = arr1(2) '"2019"
                    tmp_start = New Date(yyyy1, MM1, dd1)

                    Dim arr As Array = txtedate.Text.Split("/")
                    Dim dd As String = arr(0) '"01"
                    Dim MM As String = arr(1) '"08"
                    Dim yyyy As String = arr(2) '"2019"
                    tmp_end = New Date(yyyy, MM, dd)
                End Try
                Dim tmp_sdate, tmp_edate, tmp_smonth, tmp_emonth, tmp_syear, tmp_eyear As Integer
                Dim days As Integer = 31
                Dim tmp_day As Integer
                Dim months_value, monthe_value As Integer
               
                tmp_sdate = Day(tmp_start)
                tmp_edate = Day(tmp_end)

                tmp_smonth = Month(tmp_start)
                tmp_emonth = Month(tmp_end)

                tmp_syear = Year(tmp_start)
                tmp_eyear = Year(tmp_end)

                For int_year As Integer = tmp_syear To tmp_eyear
                    If int_year <> tmp_eyear Then
                        monthe_value = 12
                        If int_year <> tmp_syear Then
                            months_value = 1
                        Else
                            months_value = tmp_smonth
                        End If
                    Else
                        monthe_value = tmp_emonth
                        If tmp_syear <> tmp_eyear Then
                            months_value = 1
                        Else
                            months_value = tmp_smonth
                        End If
                    End If

                    Dim _order As Integer = 1
                    For int_month As Integer = months_value To monthe_value
                      
                        Select Case int_month 'tmp_month
                            Case 1, 3, 5, 7, 8, 10, 12
                                days = 31
                            Case 4, 6, 9, 11
                                days = 30
                            Case 2
                                If ddlSchyear.SelectedValue Mod 4 = 0 Then
                                    days = 29
                                Else
                                    days = 28
                                End If
                        End Select
                        If int_month = tmp_smonth And int_year = tmp_syear Then
                            tmp_day = tmp_sdate
                        Else
                            tmp_day = 1
                        End If
                        If int_month = monthe_value And int_year = tmp_eyear Then
                            days = tmp_edate
                        End If
                        For i As Integer = tmp_day To days
                            Dim nrow As DataRow = dtExcel.NewRow
                            nrow.Item("no") = _order
                            nrow.Item("_name") = i & " " & getMonthName(int_month, "th") & " " & int_year
                            Dim _sum As Object = 0
                            For Each dr As DataRow In tbDataType_Car.Select("", "type_id")
                                Dim Sum_cnt_car As Object
                                Try
                                    Sum_cnt_car = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & int_year & " and month_id = " & int_month & " and days = " & i & " and typecar_id = " & dr("type_id")), "#,##0")
                                Catch ex As Exception
                                    Sum_cnt_car = 0
                                End Try
                                nrow.Item("_type" & dr("type_id")) = Sum_cnt_car
                                _sum = _sum + Sum_cnt_car
                            Next
                            nrow.Item("sum") = _sum
                            dtExcel.Rows.Add(nrow)
                            nrow = Nothing
                        Next
                        _order = _order + 1
                    Next
                Next


                Dim nrow2 As DataRow = dtExcel.NewRow
                'nrow.Item("no") = _order
                nrow2.Item("_name") = "รวมทั้งหมด"
                Dim _sum2 As Object = 0
                For Each dr As DataRow In tbDataType_Car.Select("", "type_id")
                    Dim Sum_cnt_car As Object
                    Try
                        Sum_cnt_car = Format(tbDataCnt_Car.Compute("Sum(cnt_car)", " year_id = " & ddlSchyear.SelectedValue & " and typecar_id = " & dr("type_id")), "#,##0")
                    Catch ex As Exception
                        Sum_cnt_car = 0
                    End Try
                    nrow2.Item("_type" & dr("type_id")) = Sum_cnt_car
                    _sum2 = _sum2 + Sum_cnt_car
                Next
                nrow2.Item("sum") = _sum2
                dtExcel.Rows.Add(nrow2)
                nrow2 = Nothing
                dtExcel.Columns.Remove("no")
            End If
            Return dtExcel
        Else
            Return dtChart
        End If
    End Function

    Protected Sub BtnDownloadCSV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDownloadCSV.Click
        'Export CSV สถิติในรูปแบบตารางทุกอันสามารถ Export ออกมาเป็นไฟล์ได้ (csv)
        Dim DataTable = LoadDataExport(False)
        Dim builder As StringBuilder = New StringBuilder()
        Dim columnNames As List(Of String) = New List(Of String)()
        Dim rows As List(Of String) = New List(Of String)()

        For Each column As DataColumn In DataTable.Columns
            columnNames.Add(column.ColumnName)
        Next

        builder.Append(String.Join(",", columnNames.ToArray())).Append(vbLf)

        For Each row As DataRow In DataTable.Rows
            Dim currentRow As List(Of String) = New List(Of String)()

            For Each column As DataColumn In DataTable.Columns
                Dim item As Object = row(column)
                currentRow.Add(item.ToString())
            Next

            rows.Add(String.Join(",", currentRow.ToArray()))
        Next

        builder.Append(String.Join(vbLf, rows.ToArray()))
        Response.Clear()
        Response.ContentType = "text/csv"
        Response.AddHeader("Content-Disposition", "attachment;filename=myChartC-" & Request.QueryString("sid") & ".csv")
        Response.ContentEncoding = System.Text.Encoding.Unicode
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
        Response.Write(builder.ToString())
        Response.[End]()
    End Sub

    Protected Sub BtnDownloadExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDownloadExcel.Click
        ''Export Excel

        Dim dtExcel As DataTable = LoadDataExport(True)
        'Create a dummy GridView
        Dim GridView1 As New GridView()
        GridView1.AllowPaging = False
        GridView1.ShowHeader = False
        GridView1.DataSource = dtExcel
        GridView1.DataBind()

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=myChartC-" & Request.QueryString("sid") & ".xls")
        Response.Charset = ""

        '2003
        Response.ContentType = "application/vnd.ms-excel"

        ''2007
        'response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"

        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            'Apply text style to each Row
            GridView1.Rows(i).Attributes.Add("class", "textmode")
        Next
        GridView1.RenderControl(hw)

        Dim style As String = "<style> .textmode{mso-number-format:\@;}  </style>"
        ''Dim headerTable As String = "<Table><tr><td colspan=20 ><center><b>" & pHead & "<b></center></td></tr></Table>"
        Dim headerTable As String = ""
        Dim cntColumns As Integer = dtExcel.Columns.Count
        Dim tmp_start, tmp_end As Date
        If rdoshow.SelectedValue = 2 Then
            Try
                Dim arr1 As Array = txtsdate.Text.Split("/")
                Dim dd1 As String = arr1(0) '"01"
                Dim MM1 As String = arr1(1) '"08"
                Dim yyyy1 As String = arr1(2) '"2019"
                tmp_start = New Date(yyyy1, MM1, dd1)

                Dim arr As Array = txtedate.Text.Split("/")
                Dim dd As String = arr(0) '"01"
                Dim MM As String = arr(1) '"08"
                Dim yyyy As String = arr(2) '"2019"
                tmp_end = New Date(yyyy, MM, dd)
            Catch ex As Exception

            End Try
            headerTable = "<table border=1><tr><td colspan=" & cntColumns & "><center><b>" & lbl.Text & " " & rdoshow.SelectedItem.Text & " " & _
               Format(CDate(tmp_start), "dd MMM yyyy") & " - " & Format(CDate(tmp_end), "dd MMM yyyy") & _
                "<b></center></td></tr><tr>"
        Else
            headerTable = "<table border=1><tr><td colspan=" & cntColumns & "><center><b>" & lbl.Text & " " & rdoshow.SelectedItem.Text & "<b></center></td></tr><tr>"
        End If

        If rdoshow.SelectedValue = 0 Then
            'รายวัน
            headerTable = headerTable & "<td><center><b>วันที่<b></center></td>"
        ElseIf rdoshow.SelectedValue = 1 Then
            'รายเดือน
            headerTable = headerTable & "<td><center><b>ลำดับที่<b></center></td>" & _
            "<td><center><b>เดือน<b></center></td>"
        ElseIf rdoshow.SelectedValue = 2 Then
            'ช่วงวัน
            headerTable = headerTable & "<td><center><b>วันที่<b></center></td>"
        End If

        For Each dr As DataRow In tbDataType_Car.Select("", "type_id")
            headerTable = headerTable & "<td><center><b>" & dr("type_name") & "<b></center></td>"
        Next
        headerTable = headerTable & "<td><center><b>รวมทั้งหมด<b></center></td></tr></table>"

        Response.Write(headerTable)
        Response.Write(style)
        Dim html As String = sw.ToString() '.Replace("www.google.com", "=HYPERLINK('www.google.com',test)")
        Response.Output.Write(html.ToString)
        Response.Flush()
        Response.End()
    End Sub
End Class
