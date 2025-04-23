Imports System.Data
Imports System.IO

Partial Class Admin_RptStatChartAll_4
    Inherits System.Web.UI.Page
    Protected _year As String
    Private IsMobile As Boolean = False
    Private PopulateS As New PopulateScript
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _year = Now.Year()
        If Page.IsPostBack = False Then
            If PopulateS.IsMobile Then
                IsMobile = True
            End If
            If Request.QueryString("rt") = 1 Then
                lblHead.Text = "ข้อมูลผู้ประกอบธุรกิจนำเที่ยวที่ได้รับอนุญาตนำรถประจำถิ่นเข้ามาในราชอาณาจักร" '"ข้อมูลผู้ประกอบธุรกิจนำเที่ยวที่ขออนุญาตนำรถประจำถิ่นเข้ามาในราชอาณาจักร"
            ElseIf Request.QueryString("rt") = 2 Then
                lblHead.Text = "ข้อมูลผู้ประกอบธุรกิจนำเที่ยวที่ได้รับอนุญาตนำรถท่องเที่ยวเข้ามาในราชอาณาจักร" '"ข้อมูลผู้ประกอบธุรกิจนำเที่ยวที่ขออนุญาตนำรถท่องเที่ยวเข้ามาในราชอาณาจักร"  
            End If
            loadChart()
        End If
    End Sub

    Private PopulateChart As New PopulateChart
    Private Sub loadChart()
        Dim typeuser_id As Integer = Request.QueryString("rt")

        Dim tr As TableRow
        Dim tc As TableCell

        tr = New TableRow
        tc = New TableCell
        tc.BorderColor = Drawing.Color.DarkGray
        tc.CssClass = "w3-responsive"
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        'Dim table_2 As Table = PopulateChart.AddTable(Page, 10, typeuser_id, _year, lblHead, txtsdate, txtedate, 10)
        Dim table_2 As Table = PopulateChart.AddTable(Page, 10, typeuser_id, _year, lblHead, txtsdate, txtedate, 0, ddldate.SelectedValue)
        If IsMobile Then
            table_2.Width = Unit.Pixel(940)
            tc.Width = Unit.Pixel(340)
            tc.Attributes.Add("style", "padding-left: 15px; padding-right: 15px;")
        Else
            table_2.Width = Unit.Percentage(98)
            tc.Width = Unit.Percentage(99)
            tc.Attributes.Add("style", "padding-left: 10px;")
        End If
        tc.Controls.Add(table_2)
        tr.Cells.Add(tc)
        tbData.Rows.Add(tr)


        Dim styleChart As String = "style='width: 98%; height: 450px; margin: 0 auto'"
        If IsMobile Then
            styleChart = "style='max-width: 300px; height: 400px; margin: 0 auto' "
        End If
        tr = New TableRow
        tc = New TableCell
        Dim divChart6 As String = "<br /><br /><div id='container6_1' " & styleChart & " ></div> <br /><br />"
        tc.BorderColor = Drawing.Color.DarkGray
        'tc.Width = Unit.Percentage(33)
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.VerticalAlign = VerticalAlign.Top
        tc.Text = divChart6
        tc.ColumnSpan = 3
        tr.Cells.Add(tc)
        tbData.Rows.Add(tr)
        UpdatePanel1.Update()

        Dim _data As String = ""
        Dim pScriptAddChart As String = ""

        _data = PopulateChart.getDataChart(Page, "coalesce(name_company,'ไม่ระบุ') as name_company, coalesce(type_car.type_name_th,'ไม่ระบุ') ", 6, typeuser_id, _year, txtsdate, txtedate, 10, ddldate.SelectedValue)
        pScriptAddChart = pScriptAddChart & _data & " AddChart6(_data,_categories,'container6_1',true,'จำนวนรถที่ได้รับอนุญาตฯ จำแนกตามผู้ประกอบธุรกิจนำเที่ยวที่ยื่นขอฯ (ผู้ยื่นขอ) 10 ลำดับแรก','horizontal','center','bottom'); "

        Dim pAlert As String = ""

        If pAlert <> "" Then
            pScriptAddChart = " alert('" & pAlert & "'); " & pScriptAddChart
        End If
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> " & pScriptAddChart & " </script>", False)
    End Sub

    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles BtnSch.Click
        loadChart()
    End Sub

    Private Function LoadDataExport(ByVal IsExcel As Boolean) As DataTable
        Dim dtChart As DataTable = PopulateChart.ConvertDataExport(Page, 10, Request.QueryString("rt"), _year, lblHead, txtsdate, txtedate, 0, IsExcel, ddldate.SelectedValue)
        Return dtChart
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
        Response.AddHeader("Content-Disposition", "attachment;filename=myChart" & 10 & ".csv")
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
        Response.AddHeader("content-disposition", "attachment;filename=myChart" & 10 & ".xls")
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

        headerTable = "<table border=1><tr><td colspan=" & cntColumns & "><center><b>จำนวนรถที่ได้รับอนุญาตเข้ามาในราชอาณาจักรเป็นการชั่วคราว<br/>จำแนกตามผู้ประกอบการธุรกิจนำเที่ยว<b></center></td></tr><tr>" & _
            "<td><center><b>ลำดับที่<b></center></td>" & _
            "<td><center><b>ผู้ประกอบการธุรกิจนำเที่ยว</center></td>"
        For col As Integer = 2 To dtExcel.Columns.Count - 1
            headerTable = headerTable & "<td><center><b>" & dtExcel.Columns(col).ColumnName & "</center></td>"
        Next
        headerTable = headerTable & "</tr></table>"
        Response.Write(headerTable)
        Response.Write(style)
        Dim html As String = sw.ToString()
        Response.Output.Write(html.ToString)
        Response.Flush()
        Response.End()
    End Sub
End Class
