Imports System.Data

Partial Class Admin_RptStatChartAll_2
    Inherits System.Web.UI.Page
    Protected _year As String

    Private IsMobile As Boolean = False
    Private PopulateS As New PopulateScript
    Private CSSChart As String = ""
    Private WidthChart As Double
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _year = Now.Year()
        If Page.IsPostBack = False Then
            If PopulateS.IsMobile Then
                IsMobile = True
                CSSChart = "w3-third"
                WidthChart = 88
            Else
                CSSChart = "w3-col m12"
                WidthChart = 33
            End If
            If Request.QueryString("rt") = 1 Then
                lblHead.Text = "ข้อมูลรถประจำถิ่นที่ได้รับอนุญาตนำเข้ามาในราชอาณาจักร" '"ข้อมูลรถประจำถิ่นที่ขออนุญาตนำเข้ามาในราชอาณาจักร"
            ElseIf Request.QueryString("rt") = 2 Then
                lblHead.Text = "ข้อมูลรถท่องเที่ยวที่ได้รับอนุญาตนำเข้ามาในราชอาณาจักร" '"ข้อมูลรถท่องเที่ยวที่ขออนุญาตนำเข้ามาในราชอาณาจักร"
            End If
            loadChart()
        End If
    End Sub

    Private Function addHeader(ByVal indexHead As Integer, ByVal txtHead As String) As String
        'Dim strIndex As String = "<span class='fa-stack'>" & _
        '"<span class='fa fa-circle-o fa-stack-2x'></span>" & _
        '"<strong class='fa-stack-1x'>" & _
        '"    " & indexHead & "    " & _
        '"</strong>" & _
        '"</span>"
        'Return "<div class='w3-col l8 w3-padding-left w3-padding-right'>" & _        '"<p><button class='w3-button w3-block w3-purple3 w3-left-align w3-round w3-theme-l4 w3-border w3-theme-border' >" & strIndex & "&nbsp;&nbsp;" & txtHead & " </button></p>" & _
        '"</div><br />"
        Return ""
    End Function

    Private PopulateChart As New PopulateChart
    Private Sub loadChart()
        Dim typeuser_id As Integer = Request.QueryString("rt")
        Dim styleChart As String = "style='width: 98%; height: 400px; margin: 0 auto'"
        If IsMobile Then
            styleChart = "style='max-width: 300px; height: 400px; margin: 0 auto' "
        End If
        Dim tr As TableRow
        Dim tc As TableCell

        tr = New TableRow
        tc = New TableCell
        Dim divChart1 As String = "<br /><div id='container1' " & styleChart & " ></div> <br /><br /> "
        tc.BorderColor = Drawing.Color.DarkGray
        'tc.Width = Unit.Percentage(33)
        tc.CssClass = CSSChart
        tc.Width = Unit.Percentage(WidthChart)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = addHeader(1, "จำนวนรถที่ได้รับอนุญาตฯ จำแนก ตามสำนักงาน") & divChart1
        tr.Cells.Add(tc)

        tc = New TableCell
        Dim divChart2 As String = "<br /><div id='container2' " & styleChart & " ></div> <br /><br /> "
        tc.BorderColor = Drawing.Color.DarkGray
        'tc.Width = Unit.Percentage(33)
        tc.CssClass = CSSChart
        tc.Width = Unit.Percentage(WidthChart)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = addHeader(2, "ประเภทรถที่ได้รับอนุญาตฯ") & divChart2
        tr.Cells.Add(tc)

        tc = New TableCell
        Dim divChart4 As String = "<br /><div id='container4' " & styleChart & " ></div> <br /><br /> "
        tc.BorderColor = Drawing.Color.DarkGray
        'tc.Width = Unit.Percentage(33)
        tc.CssClass = CSSChart
        tc.Width = Unit.Percentage(WidthChart)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = addHeader(4, "ประเทศรถที่จดทะเบียน 5 อันดับแรก") & divChart4
        tr.Cells.Add(tc)
        tbData.Rows.Add(tr)


        styleChart = "style='width: 98%; height: 420px; margin: 0 auto'"
        If IsMobile Then
            styleChart = "style='max-width: 300px; height: 400px; margin: 0 auto' "
        End If
        tr = New TableRow
        tc = New TableCell
        Dim divChart3 As String = "<div id='container3' " & styleChart & " ></div> <br /><br /><br />"
        tc.BorderColor = Drawing.Color.DarkGray
        'tc.Width = Unit.Percentage(33)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = addHeader(3, "จำนวนรถที่ได้รับอนุญาตฯ จำแนกตามรายเดือน") & divChart3
        tc.ColumnSpan = 3
        tr.Cells.Add(tc)
        tbData.Rows.Add(tr)

        tr = New TableRow
        tc = New TableCell
        Dim divChart7 As String = "<div id='container7' " & styleChart & " ></div> <br /><br /><br />"
        tc.BorderColor = Drawing.Color.DarkGray
        'tc.Width = Unit.Percentage(33)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = addHeader(7, "จำนวนรถที่ได้รับอนุญาต จำแนกตามประเภทรถ และรายเดือน") & divChart7
        tc.ColumnSpan = 3
        tr.Cells.Add(tc)
        tbData.Rows.Add(tr)

        Dim _data As String = "" '" var _data = [ { name: 'Chrome', y: 62.74 },  { name: 'Firefox', y: 10.57 },  { name: 'Internet Explorer', y: 7.23 }, { name: 'Safari',  y: 5.58 }, { name: 'Edge', y: 4.02 }, { name: 'Opera', y: 1.92 }, { name: 'Other', y: 7.62 }  ]; "
        Dim pScriptAddChart As String = ""

        _data = PopulateChart.getDataChart(Page, "admin.admin_name", 1, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        pScriptAddChart = _data & " AddChart1Bar(_data,'container1',true); "

        _data = PopulateChart.getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ')", 2, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        pScriptAddChart = pScriptAddChart & _data & " AddChart2Pie3D(_data,'container2'); "

        _data = PopulateChart.getDataChart(Page, "car.country_car", 4, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        pScriptAddChart = pScriptAddChart & _data & " AddChart4Column(_data,'container4'); "

        '_data = PopulateChart.getDataChart(Page, "EXTRACT(year FROM license.regis_date) as yy , EXTRACT(MONTH FROM license.regis_date)", 3, typeuser_id, _year, txtsdate, txtedate, 0)
        If ddldate.SelectedValue = 1 Then
            _data = PopulateChart.getDataChart(Page, "EXTRACT(year FROM license.receipt_date) as yy , EXTRACT(MONTH FROM license.receipt_date)", 3, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        Else
            _data = PopulateChart.getDataChart(Page, "EXTRACT(year FROM travel_group.start_date) as yy , EXTRACT(MONTH FROM travel_group.start_date)", 3, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        End If
        pScriptAddChart = pScriptAddChart & _data & " AddChart3(_data,_categories,'container3',false,'จำนวนรถที่ได้รับอนุญาตฯ จำแนกตามรายเดือน'); "

        '_data = PopulateChart.getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , EXTRACT(year FROM license.regis_date) as yy , EXTRACT(MONTH FROM license.regis_date)", 7, typeuser_id, _year, txtsdate, txtedate, 0)
        _data = PopulateChart.getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ') as car_type , EXTRACT(year FROM travel_group.start_date) as yy , EXTRACT(MONTH FROM travel_group.start_date)", 7, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        pScriptAddChart = pScriptAddChart & _data & " AddChart7(_data,_categories,'container7',false,'จำนวนรถที่ได้รับอนุญาต จำแนกตามประเภทรถ และรายเดือน'); "

        Dim pAlert As String = ""

        If pAlert <> "" Then
            pScriptAddChart = " alert('" & pAlert & "'); " & pScriptAddChart
        End If
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> " & pScriptAddChart & " </script>", False)
    End Sub

    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles BtnSch.Click
        loadChart()
    End Sub
End Class
