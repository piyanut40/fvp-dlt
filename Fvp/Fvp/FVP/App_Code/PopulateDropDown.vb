Imports Microsoft.VisualBasic
Imports System.Data
Imports Npgsql

Public Class PopulateDropDown

    Public Sub genDDLBudyear(ByVal ddl As DropDownList, ByVal year_value As Integer, ByVal txtSelectAll As String)
        'ปีงบประมาณ
        Dim Dtyear As New DataTable
        With Dtyear
            .Columns.Add("text")
            .Columns.Add("value")
        End With
        Dim pYear As New Integer
        Dim thCul As New System.Globalization.CultureInfo("th-TH")
        pYear = Now().ToString("yyyy", thCul) + 3
        Dim i As New Integer
        For i = 0 To 6
            Dim nrow As DataRow = Dtyear.NewRow
            With nrow
                .Item("text") = pYear - i
                .Item("value") = pYear - i
            End With
            Dtyear.Rows.Add(nrow)
            nrow = Nothing
        Next

        ddl.Items.Clear()
        If txtSelectAll <> "" Then
            ddl.Items.Insert(0, txtSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dtyear
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedValue = year_value
    End Sub

    Public Sub genDDLBudyearEN(ByVal ddl As DropDownList, ByVal year_value As Integer, ByVal txtSelectAll As String)
        'ปีงบประมาณ
        Dim Dtyear As New DataTable
        With Dtyear
            .Columns.Add("text")
            .Columns.Add("value")
        End With
        Dim pYear As New Integer
        Dim thCul As New System.Globalization.CultureInfo("th-TH")
        'pYear = Now().ToString("yyyy", thCul) + 3
        pYear = Now().Year + 3
        Dim i As New Integer
        For i = 0 To 6
            Dim nrow As DataRow = Dtyear.NewRow
            With nrow
                .Item("text") = pYear - i
                .Item("value") = pYear - i
            End With
            Dtyear.Rows.Add(nrow)
            nrow = Nothing
        Next

        ddl.Items.Clear()
        If txtSelectAll <> "" Then
            ddl.Items.Insert(0, txtSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dtyear
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedValue = year_value
    End Sub

    Public Sub genDDLCartype(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'ประเภทยานพาหนะ
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String

            strselect = " select distinct  type_id as value , type_name  as text from  type_car WHERE type_id in (1,2,4) "

            Dt = db.getDataTable(strselect & " Order By type_id ", "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        'ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLGroup(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
        

            strselect = " select distinct  group_id as value , group_name  as text from  travel_group where is_active = 1 "

            Dt = db.getDataTable(strselect & " Order By group_name ", "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "Select Tour Group")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
    End Sub

    Public Sub genDDLyears(ByVal ddl As DropDownList, ByVal year_value As Integer, ByVal txtSelectAll As String)
        'ปี
        Dim Dtyear As New DataTable
        With Dtyear
            .Columns.Add("text")
            .Columns.Add("value")
        End With
        Dim pYear As New Integer
        Dim thCul As New System.Globalization.CultureInfo("th-TH")
        pYear = Now().ToString("yyyy", thCul) - 543
        Dim i As New Integer
        For i = 0 To 20
            Dim nrow As DataRow = Dtyear.NewRow
            With nrow
                .Item("text") = pYear - i
                .Item("value") = pYear - i
            End With
            Dtyear.Rows.Add(nrow)
            nrow = Nothing
        Next

        ddl.Items.Clear()
        If txtSelectAll <> "" Then
            ddl.Items.Insert(0, txtSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dtyear
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedValue = year_value
    End Sub

    Public Sub genDDLyears_th(ByVal ddl As DropDownList, ByVal year_value As Integer, ByVal txtSelectAll As String)
        'ปี
        Dim Dtyear As New DataTable
        With Dtyear
            .Columns.Add("text")
            .Columns.Add("value")
        End With
        Dim pYear As New Integer
        Dim thCul As New System.Globalization.CultureInfo("th-TH")
        pYear = Now().ToString("yyyy", thCul)
        Dim i As New Integer
        For i = 0 To 20
            Dim nrow As DataRow = Dtyear.NewRow
            With nrow
                .Item("text") = pYear - i
                .Item("value") = pYear - i
            End With
            Dtyear.Rows.Add(nrow)
            nrow = Nothing
        Next

        ddl.Items.Clear()
        If txtSelectAll <> "" Then
            ddl.Items.Insert(0, txtSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dtyear
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedValue = year_value
    End Sub

    Public Sub genDDLmonths(ByVal ddl As DropDownList, ByVal txtSelectAll As String, ByVal Cult As String)

        Dim Dtmonths As New DataTable
        With Dtmonths
            .Columns.Add("text")
            .Columns.Add("value")
        End With

        Dim i As New Integer
        For i = 1 To 12
            Dim nrow As DataRow = Dtmonths.NewRow
            With nrow
                If Cult.ToLower = "th" Then
                    Select Case i
                        Case 1
                            .Item("text") = "มกราคม"
                        Case 2
                            .Item("text") = "กุมภาพันธ์"
                        Case 3
                            .Item("text") = "มีนาคม"
                        Case 4
                            .Item("text") = "เมษายน"
                        Case 5
                            .Item("text") = "พฤษภาคม"
                        Case 6
                            .Item("text") = "มิถุนายน"
                        Case 7
                            .Item("text") = "กรกฎาคม"
                        Case 8
                            .Item("text") = "สิงหาคม"
                        Case 9
                            .Item("text") = "กันยายน"
                        Case 10
                            .Item("text") = "ตุลาคม"
                        Case 11
                            .Item("text") = "พฤศจิกายน"
                        Case 12
                            .Item("text") = "ธันวาคม"
                    End Select
                ElseIf Cult.ToLower = "en" Then
                    Select Case i
                        Case 1
                            .Item("text") = "January"
                        Case 2
                            .Item("text") = "February"
                        Case 3
                            .Item("text") = "March"
                        Case 4
                            .Item("text") = "April"
                        Case 5
                            .Item("text") = "May"
                        Case 6
                            .Item("text") = "June"
                        Case 7
                            .Item("text") = "July"
                        Case 8
                            .Item("text") = "August"
                        Case 9
                            .Item("text") = "September"
                        Case 10
                            .Item("text") = "October"
                        Case 11
                            .Item("text") = "November"
                        Case 12
                            .Item("text") = "December"
                    End Select
                End If

                .Item("value") = i
            End With
            Dtmonths.Rows.Add(nrow)
            nrow = Nothing
        Next

        ddl.Items.Clear()
        If txtSelectAll <> "" Then
            ddl.Items.Insert(0, txtSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dtmonths
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        'ddl.SelectedValue = months_value

        If txtSelectAll = "" Then
            ddl.SelectedValue = Now.Month
        End If
    End Sub

    Public Sub genDDLdays(ByVal ddl As DropDownList, ByVal year_value As Integer, ByVal months_value As Integer, ByVal txtSelectAll As String)

        Dim Dtyear As New DataTable
        With Dtyear
            .Columns.Add("text")
            .Columns.Add("value")
        End With
        Dim days As Integer = 31
        Select Case months_value
            Case 1, 3, 5, 7, 8, 10, 12
                days = 31
            Case 4, 6, 9, 11
                days = 30
            Case 2
                If year_value Mod 4 = 0 Then
                    days = 29
                Else
                    days = 28
                End If
        End Select
        For i = 1 To days
            Dim nrow As DataRow = Dtyear.NewRow
            With nrow
                .Item("text") = i
                .Item("value") = i
            End With
            Dtyear.Rows.Add(nrow)
            nrow = Nothing
        Next

        ddl.Items.Clear()
        If txtSelectAll <> "" Then
            ddl.Items.Insert(0, txtSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dtyear
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        'ddl.SelectedValue = year_value
    End Sub

    Public Sub genDDLCountry(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'ประเทศทั้งหมด
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = "select distinct en_short_name as value , en_short_name as text , nearcountry from countries order by nearcountry, en_short_name "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try
        'ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, IsSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLCountry(ByVal ddl As DropDownList, ByVal IsSelectAll As String)
        'ประเทศทั้งหมด
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = "select distinct en_short_name as value , en_short_name as text, nearcountry from countries order by nearcountry, en_short_name "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try
        'ddl.Items.Clear()
        If IsSelectAll <> "" Then
            ddl.Items.Insert(0, IsSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub
    Public Sub genDDLNationality(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'สัญชาติ
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = "select distinct nationality as value , nationality as text, nearcountry  from countries order by nearcountry, nationality "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try
        ' ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, IsSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLProvince(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'จังหวัด
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  prov_code as value , prov_en  as text from  province Order By prov_en "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        ddl.DataSource = Dt
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLProvinceNotAll(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'จังหวัด ไม่มี ALL
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  prov_code as value , prov_en  as text from  province WHERE prov_code not like '0' Order By prov_en "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        ddl.DataSource = Dt
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLProvinceTH(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'จังหวัด
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  prov_code as value , prov_th  as text from  province where prov_code <> '0' Order By prov_th "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        ddl.DataSource = Dt
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLProvinceCambodia(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'จังหวัดประเทศกัมพูชา
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  name as value , name  as text from  cambodia_province Order By name "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLProvinceMyanmar(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'จังหวัดประเทศพม่า
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  name as value , name  as text from myanmar_province  Order By name "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLProvinceMalaysia(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'จังหวัดประเทศมาเลเซีย
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  name as value , name  as text from malaysia_province Order By name "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub
    Public Sub genDDLProvinceSingapore(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'จังหวัดประเทศสิงคโปร์
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  name as value , name  as text from singapore_province Order By name "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLTypeCar(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'ประเภทรถ
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  type_id as value , type_name  as text  from  type_car Order By type_id "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLBrandCar(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'ยี่ห้อรถ
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select   barndcar_id as value , brandcar_en  as text from  brand_car Order By barndcar_id "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLBorder(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean, ByVal Country As String)
        'ด่านพรหมแดน
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            If Country <> "" Then
                strselect = " select border_id as value , CAST(border_nameen || '  (' ||  prov_en || ')' as varchar ) as text " & _
                " from  border_check LEFT JOIN province on province.prov_code = border_check.prov_code " & _
                " WHERE (border_nameen is not null or border_nameen <> '' ) and border_country like '%" & Country & "%' Order By CAST(border_nameen || '  (' ||  prov_en || ')' as varchar ) "
            Else
                strselect = " select border_id as value , CAST(border_nameen || '  (' ||  prov_en || ')' as varchar )  as text " & _
                            " from  border_check LEFT JOIN province on province.prov_code = border_check.prov_code " & _
                            " where border_nameen is not null or border_nameen <> '' Order By CAST(border_nameen || '  (' ||  prov_en || ')' as varchar ) "
            End If

           
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub



    Public Sub genDDLProvince(ByVal ddl As DropDownList, ByVal IsSelectAll As String)
        'จังหวัด
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  prov_code as value , prov_en  as text from  province Order By prov_en "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll <> "" Then
            ddl.Items.Insert(0, IsSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLAmphoe(ByVal ddlPro As DropDownList, ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'เขต/อำเภอ
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct a_code as value , a_name_e  as text from  tumbol  "
            If ddlPro.SelectedValue <> 0 Then
                strselect = strselect & " where p_code = '" & ddlPro.SelectedValue & "' "
            End If
            Dt = db.getDataTable(strselect & " Order By a_name_e ", "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLAmphoeTH(ByVal ddlPro As DropDownList, ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'เขต/อำเภอ
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct a_code as value , a_name_t  as text  from  tumbol  "
            If ddlPro.SelectedValue <> 0 Then
                strselect = strselect & " where p_code = '" & ddlPro.SelectedValue & "' "
            End If
            Dt = db.getDataTable(strselect & " Order By a_name_t ", "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLAmphoe(ByVal ddlPro As DropDownList, ByVal ddl As DropDownList, ByVal IsSelectAll As String)
        'เขต/อำเภอ
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct a_code as value , a_name_e  as text from  tumbol  "
            If ddlPro.SelectedValue <> 0 Then
                strselect = strselect & " where p_code = '" & ddlPro.SelectedValue & "' "
            End If
            Dt = db.getDataTable(strselect & " Order By a_name_e ", "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll <> "" Then
            ddl.Items.Insert(0, IsSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLTumbol(ByVal ddlPro As DropDownList, ByVal ddlAmp As DropDownList, ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'แขวง/ตำบล
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  t_id as value , t_name_e  as text from  tumbol where 1=1 "
            If ddlPro.SelectedValue <> 0 Then
                strselect = strselect & " and p_code = '" & ddlPro.SelectedValue & "' "
            End If
            If ddlAmp.SelectedValue <> 0 Then
                strselect = strselect & " and a_code = '" & ddlAmp.SelectedValue & "' "
            End If
            Dt = db.getDataTable(strselect & " Order By t_name_e ", "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLTumbolTH(ByVal ddlPro As DropDownList, ByVal ddlAmp As DropDownList, ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'แขวง/ตำบล
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  t_id as value , t_name_t  as text from  tumbol where 1=1 "
            If ddlPro.SelectedValue <> 0 Then
                strselect = strselect & " and p_code = '" & ddlPro.SelectedValue & "' "
            End If
            If ddlAmp.SelectedValue <> 0 Then
                strselect = strselect & " and a_code = '" & ddlAmp.SelectedValue & "' "
            End If
            Dt = db.getDataTable(strselect & " Order By t_name_t ", "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLTumbol(ByVal ddlPro As DropDownList, ByVal ddlAmp As DropDownList, ByVal ddl As DropDownList, ByVal IsSelectAll As String)
        'แขวง/ตำบล
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  t_id as value , t_name_e  as text from  tumbol where 1=1 "
            If ddlPro.SelectedValue <> 0 Then
                strselect = strselect & " and p_code = '" & ddlPro.SelectedValue & "' "
            End If
            If ddlAmp.SelectedValue <> 0 Then
                strselect = strselect & " and a_code = '" & ddlAmp.SelectedValue & "' "
            End If
            Dt = db.getDataTable(strselect & " Order By t_name_e ", "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll <> "" Then
            ddl.Items.Insert(0, IsSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genAreaform(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'สำนักงานเขตรับเอกสาร
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select admin_id as value , admin_nameen as text  from admin " & _
                        " WHERE Not admin_id = 1 " & _
                        " order by admin_nameen "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genAdminNames(ByVal ddl As DropDownList, ByVal IsSelectAll As String)
        'สำนักงานเขตขนส่งแบบส่ง IsSelectAll มาเอง
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select admin_id as value , admin_name as text  from admin " & _
                        " WHERE Not admin_id = 1 " & _
                        " order by admin_name "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll <> "" Then
            ddl.Items.Insert(0, IsSelectAll)
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genAdminName(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'สำนักงานเขตขนส่ง
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select admin_id as value , admin_name as text  from admin " & _
                        " WHERE Not admin_id = 1 " & _
                        " order by admin_name "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genPageSize(ByVal ddl As DropDownList)
        'จำนวนข้อมูลที่แสดงในกริด
        Dim Dt As New DataTable
        With Dt
            .Columns.Add("text")
            .Columns.Add("value")
        End With

        Dim nrow As DataRow = Dt.NewRow
        With nrow
            .Item("text") = "20"
            .Item("value") = "20"
        End With
        Dt.Rows.Add(nrow)
        nrow = Nothing

        nrow = Dt.NewRow
        With nrow
            .Item("text") = "10"
            .Item("value") = "10"
        End With
        Dt.Rows.Add(nrow)
        nrow = Nothing

        nrow = Dt.NewRow
        With nrow
            .Item("text") = "5"
            .Item("value") = "5"
        End With
        Dt.Rows.Add(nrow)
        nrow = Nothing

        ddl.Items.Clear()
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()

    End Sub

    Public Sub gencolors(ByVal ddl As DropDownList)
        'gen สีทั่วไป

        Dim color = {"Red", "Blue", "Yellow", "White", "Black", "Purple", "Green", "Orange", "Brown/Bronze", "Pink", "Grey/Silver", "Others"}

        For Each i In color
            ddl.Items.Add(i)
        Next

    End Sub


    Public Sub genDDLTypeUser(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'ประเภทแบบขออนุญาต
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select distinct  typeuser_id as value , typename_th  as text " & _
             " from  type_user Order By typeuser_id "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genLicenseIdfromNo(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'id ใบอนุญาติ เป็น เลขที่ ใบอนุญาติ
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = " select license_id as value , license_no as text from license " & _
                        " WHERE license_no not like '' " & _
                        " order by license_no "
            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub

    Public Sub genDDLCondition(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        'id ใบอนุญาติ เป็น เลขที่ ใบอนุญาติ
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            strselect = "SELECT con_id as value , con_rule as text FROM condition "

            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        ddl.Attributes.Add("data-inline", "true")
    End Sub
End Class
