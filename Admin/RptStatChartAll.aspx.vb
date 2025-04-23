Imports System.Data

Partial Class Admin_RptStatChartAll
    Inherits System.Web.UI.Page
    Protected _year As String

    Private IsMobile As Boolean = False
    Private PopulateS As New PopulateScript
    Private CSSChart As String = ""
    Private WidthChart As Double
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request.QueryString("IsPopup") = "1" Then
            MasterPageFile = "~/MasterPagePopup.master"
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _year = Now.Year()
        If Page.IsPostBack = False Then
            If PopulateS.IsMobile Then
                IsMobile = True
                CSSChart = "w3-half"
                WidthChart = 98
            Else
                CSSChart = "w3-col m12"
                WidthChart = 50
            End If
            If Request.QueryString("rt") = 1 Then
                lblHead.Text = "รถประจำถิ่นที่ได้รับอนุญาตให้เข้ามาในราชอาณาจักร" '"การขออนุญาตนำรถประจำถิ่นเข้ามาในราชอาณาจักร"
            ElseIf Request.QueryString("rt") = 2 Then
                lblHead.Text = "รถท่องเที่ยวที่ได้รับอนุญาตให้เข้ามาในราชอาณาจักร" '"การขออนุญาตนำรถท่องเที่ยวเข้ามาในราชอาณาจักร"
            End If
            loadChart()
        End If
    End Sub

    Private Function indexMobile(ByVal indexHead As Integer) As Integer
        If indexHead = 1 Then
            indexHead = 2
        ElseIf indexHead = 2 Then
            indexHead = 1
        ElseIf indexHead = 3 Then
            indexHead = 4
        ElseIf indexHead = 4 Then
            indexHead = 3
        ElseIf indexHead = 5 Then
            indexHead = 6
        ElseIf indexHead = 6 Then
            indexHead = 5
        End If
        Return indexHead
    End Function

    Private Function addHeader(ByVal indexHead As Integer, ByVal txtHead As String) As String
        Dim _paddingleft As String = "w3-padding-left32"
        If IsMobile Then
            indexHead = indexMobile(indexHead)
        Else
            txtHead = txtHead.ToString.Replace("<br />", "")
        End If
        Dim strIndex As String = "<span class='fa-stack'>" & _
        "<span class='fa fa-circle-o fa-stack-2x'></span>" & _
        "<strong class='fa-stack-1x'>" & _
        "    " & indexHead & "    " & _
        "</strong>" & _
        "</span>"
        Return "<div class='w3-col l9 " & _paddingleft & " w3-padding-right'>" & _        "<p><a class='w3-button w3-block w3-purple3 w3-left-align w3-round w3-theme-l4 w3-border w3-theme-border'  >" & strIndex & "&nbsp;&nbsp;" & txtHead & " </a></p>" & _
        "</div><br />"
    End Function

    Private PopulateChart As New PopulateChart
    Private Sub loadChart()
        Dim typeuser_id As Integer = Request.QueryString("rt")
        Dim styleChart As String = "style='width: 98%; height: 400px; margin: 0 auto' "
        If IsMobile Then
            styleChart = "style='width: 300px; height: 400px; margin: 0 auto' "
        End If
        Dim tr As TableRow
        Dim tc As TableCell
        Dim sumcar As Object = 0
        Try
            'Dim tbChart As DataTable = PopulateChart.getQueryChart(Page, "admin.admin_name", 1, typeuser_id, _year, txtsdate, txtedate, 0)
            Dim tbChart As DataTable = PopulateChart.getQueryChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ')", 2, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
            If tbChart.Rows.Count > 0 Then
                sumcar = tbChart.Compute("Sum(cnt)", "").ToString()
            Else
                sumcar = 0
            End If

        Catch ex As Exception

        End Try


        tr = New TableRow
        'tr.CssClass = "w3-row-padding"
       

        tc = New TableCell
        Dim divChart1 As String = "<div id='container1' " & styleChart & " ></div> <br /><br /><br />"
        tc.BorderColor = Drawing.Color.DarkGray
        tc.CssClass = CSSChart
        tc.Width = Unit.Percentage(WidthChart)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        Dim strtotal As String = "<div class='w3-container w3-large w3-purple2 w3-round-xlarge'  style='width: 280px;'>" & _
        "<b>จำนวนรถที่ได้รับอนุญาตฯ <br /> ทั้งสิ้น " & Format(CDbl(sumcar), "#,##0") & " คัน</b>" & _
        "</div> <br />"
        tc.Text = strtotal & addHeader(1, "รถที่ได้รับอนุญาตฯ <br />จำแนก ตามสำนักงาน") & divChart1.ToString.Replace("height: 400px;", "height: 330px;")
        tr.Cells.Add(tc)
        tbData.Rows.Add(tr)

        tc = New TableCell
        tc.BorderColor = Drawing.Color.DarkGray
        tc.CssClass = CSSChart
        tc.Width = Unit.Percentage(WidthChart)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        Dim divChart2 As String = "<div id='container2' " & styleChart & " ></div> <br /><br /><br />"
        strtotal = "<div class='w3-container w3-large '  style='width: 280px;height: 50px;'>  </div> <br />"        tc.Text = strtotal & addHeader(2, "ประเภทรถที่ได้รับอนุญาตฯ") & divChart2.ToString.Replace("height: 400px;", "height: 330px;")
        tr.Cells.Add(tc)

        tr = New TableRow
        'tr.CssClass = "w3-row-padding"
        

        tc = New TableCell
        Dim divChart3 As String = "<div id='container3' " & styleChart & " ></div> <br /><br /><br />"
        tc.BorderColor = Drawing.Color.DarkGray
        'tc.Width = Unit.Percentage(45)
        tc.CssClass = CSSChart
        tc.Width = Unit.Percentage(WidthChart)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = addHeader(3, "จำนวนรถที่ได้รับอนุญาตฯ <br />จำแนกตามรายเดือน") & divChart3
        tr.Cells.Add(tc)
        tbData.Rows.Add(tr)

        tc = New TableCell
        tc.BorderColor = Drawing.Color.DarkGray
        'tc.Width = Unit.Percentage(45)
        tc.CssClass = CSSChart
        tc.Width = Unit.Percentage(WidthChart)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        Dim divChart4 As String = "<div id='container4' " & styleChart & " ></div> <br /><br /><br />"
        tc.Text = addHeader(4, "ประเทศรถที่จดทะเบียน <br />5 อันดับแรก") & divChart4
        tr.Cells.Add(tc)


        tr = New TableRow
        'tr.CssClass = "w3-row-padding"
       

        tc = New TableCell
        Dim divChart5 As String = "<div id='container5_1' " & styleChart & " ></div>  <br />" & _
                                  "<div id='container5_2' " & styleChart & " ></div>  "
        tc.BorderColor = Drawing.Color.DarkGray
        'tc.Width = Unit.Percentage(45)
        tc.CssClass = CSSChart
        tc.Width = Unit.Percentage(WidthChart)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = addHeader(5, "จำนวนรถที่ได้รับอนุญาตฯ<br /> เข้า-ออก จำแนกตามด่าน") & divChart5.ToString.Replace("height: 400px;", "height: 280px;")
        tr.Cells.Add(tc)
        tbData.Rows.Add(tr)

        tc = New TableCell
        tc.BorderColor = Drawing.Color.DarkGray
        'tc.Width = Unit.Percentage(45)
        tc.CssClass = CSSChart
        tc.Width = Unit.Percentage(WidthChart)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        Dim divChart6 As String = "<div id='container6' " & styleChart & " ></div> "
        If IsMobile Then
            divChart6 = divChart6 & "<br /><br /><br />"
            tc.Text = addHeader(6, "จำนวนรถจำแนกตามผู้ประกอบการ<br />นำเที่ยวที่ได้รับอนุญาตฯ") & divChart6.ToString.Replace("height: 400px;", "height: 390px;")
        Else
            tc.Text = addHeader(6, "จำนวนรถจำแนกตามผู้ประกอบธุรกิจนำเที่ยวที่ได้รับอนุญาตฯ") & divChart6.ToString.Replace("height: 400px;", "height: 420px;")
        End If
        tr.Cells.Add(tc)

        UpdatePanel1.Update()
        Dim _data As String = "" '" var _data = [ { name: 'Chrome', y: 62.74 },  { name: 'Firefox', y: 10.57 },  { name: 'Internet Explorer', y: 7.23 }, { name: 'Safari',  y: 5.58 }, { name: 'Edge', y: 4.02 }, { name: 'Opera', y: 1.92 }, { name: 'Other', y: 7.62 }  ]; "
        Dim pScriptAddChart As String = ""

        _data = PopulateChart.getDataChart(Page, "admin.admin_name", 1, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        pScriptAddChart = _data & " AddChart1(_data,'container1',false); "

        _data = PopulateChart.getDataChart(Page, "coalesce(type_car.type_name_th,'ไม่ระบุ')", 2, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        pScriptAddChart = pScriptAddChart & _data & " AddChart2(_data,'container2'); "

        If ddldate.SelectedValue = 1 Then
            _data = PopulateChart.getDataChart(Page, "EXTRACT(year FROM license.receipt_date) as yy , EXTRACT(MONTH FROM license.receipt_date)", 3, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        Else
            _data = PopulateChart.getDataChart(Page, "EXTRACT(year FROM travel_group.start_date) as yy , EXTRACT(MONTH FROM travel_group.start_date)", 3, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        End If
        pScriptAddChart = pScriptAddChart & _data & " AddChart3(_data,_categories,'container3',false,''); "

        _data = PopulateChart.getDataChart(Page, "car.country_car", 4, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        pScriptAddChart = pScriptAddChart & _data & " AddChart4(_data,'container4'); "

        _data = PopulateChart.getDataChart(Page, "border_checkin.border_nameth", 5, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        pScriptAddChart = pScriptAddChart & _data & " AddChart5_1(_data,'container5_1',false); "

        _data = PopulateChart.getDataChart(Page, "border_checkout.border_nameth", 5, typeuser_id, _year, txtsdate, txtedate, 0, ddldate.SelectedValue)
        pScriptAddChart = pScriptAddChart & _data & " AddChart5_2(_data,'container5_2',false); "

        _data = PopulateChart.getDataChart(Page, "coalesce(name_company,'ไม่ระบุ') as name_company, coalesce(type_car.type_name_th,'ไม่ระบุ') ", 6, typeuser_id, _year, txtsdate, txtedate, 5, ddldate.SelectedValue)
        pScriptAddChart = pScriptAddChart & _data & " AddChart6(_data,_categories,'container6',false,'','vertical','left','middle'); "

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
