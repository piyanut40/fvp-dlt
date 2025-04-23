Imports System.Data
Imports Npgsql
Imports System.IO

Partial Class Admin_RptStatCharts
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected text As String
    Protected name As String
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "
    Protected _year As String
    Protected CssChart As String = "style='min-width: 300px; max-width: 90%; min-height: 680px; margin: 0 auto'"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _year = Now.Year()
        If Page.IsPostBack = False Then
            btnCSV.Visible = False
            btnExcel.Visible = False
            If PopulateS.IsMobile Then
                IsMobile = True
            End If
            If Request.QueryString("type") = "5" Then
                CssChart = "style='min-width: 300px; max-width: 60%; min-height: 480px; margin: 0 auto'"
            End If
            btnBack.PostBackUrl = btnBack.PostBackUrl & "?rt=" & Request.QueryString("rt")



            loadChart()

        End If
    End Sub


    Private Sub AddScriptChart3D()
        Dim js As New HtmlGenericControl("script")
        js.Attributes("type") = "text/javascript"
        js.Attributes("src") = "../Scripts/Chart/3D/highcharts.js"
        Page.Header.Controls.Add(js)

        js = New HtmlGenericControl("script")
        js.Attributes("type") = "text/javascript"
        js.Attributes("src") = "../Scripts/Chart/3D/highcharts-3d.js"
        Page.Header.Controls.Add(js)

        js = New HtmlGenericControl("script")
        js.Attributes("type") = "text/javascript"
        js.Attributes("src") = "../Scripts/Chart/3D/cylinder.js"
        Page.Header.Controls.Add(js)

        js = New HtmlGenericControl("script")
        js.Attributes("type") = "text/javascript"
        js.Attributes("src") = "../Scripts/Chart/3D/exporting.js"
        Page.Header.Controls.Add(js)

        js = New HtmlGenericControl("script")
        js.Attributes("type") = "text/javascript"
        js.Attributes("src") = "../Scripts/Chart/3D/export-data.js"
        Page.Header.Controls.Add(js)
    End Sub

    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles BtnSch.Click
        loadChart()
    End Sub

    Private PopulateChart As New PopulateChart
    Private IsMobile As Boolean = False
    Private Sub loadChart()
        If Request.QueryString("type") = "8" Or Request.QueryString("type") = "10" Or Request.QueryString("type") = "11" Or Request.QueryString("type") = "13" Then
            'กรณีไม่ใช่ Chart
            Dim typeuser_id As Integer = Request.QueryString("rt")

            Dim tr As TableRow
            Dim tc As TableCell

            tr = New TableRow
            tc = New TableCell
            tc.BorderColor = Drawing.Color.DarkGray
            tc.CssClass = "w3-responsive"
            tc.HorizontalAlign = HorizontalAlign.Center
            tc.VerticalAlign = VerticalAlign.Top
            Dim _limit As Integer = 0
            If Request.QueryString("type") = "8" Then
                If Request.QueryString("IsAll") = "1" Then
                    _limit = 0
                Else
                   
                    _limit = 0
                End If
                btnCSV.Visible = True
                btnExcel.Visible = True
            ElseIf Request.QueryString("type") = "10" Then
               
                btnCSV.Visible = True
                btnExcel.Visible = True
            ElseIf Request.QueryString("type") = "11" Or Request.QueryString("type") = "13" Then
                btnCSV.Visible = True
                btnExcel.Visible = True
            End If
            Dim table_1 As Table = PopulateChart.AddTable(Page, Request.QueryString("type"), typeuser_id, _year, lblHead, txtsdate, txtedate, _limit, ddldate.SelectedValue) 'getTableChart1()
            If IsMobile Then
                table_1.Width = Unit.Pixel(800)
                tc.Width = Unit.Pixel(340)
                tc.Attributes.Add("style", "padding-left: 15px; padding-right: 15px;")
            Else
                table_1.Width = Unit.Percentage(98)
                tc.Width = Unit.Percentage(99)
                tc.Attributes.Add("style", "padding-left: 10px;")
            End If
            tc.Controls.Add(table_1)
            tr.Cells.Add(tc)
            tbData.Rows.Add(tr)
            UpdatePanel1.Update()
            If Request.QueryString("type") = "8" Then
                lblHead.Text = "<br />ด่านศุลกากรที่ขออนุญาตรถผ่านเข้า-ออก "
               
            ElseIf Request.QueryString("type") = "10" Then
              
                lblHead.Text = "<br />จำนวนรถที่ขออนุญาตเข้ามาในราชอาณาจักรเป็นการชั่วคราว <br />จำแนกตามผู้ประกอบการธุรกิจนำเที่ยว "
            End If

        Else
            lblHeadtable.Visible = False
            Dim _limit As Integer = 0
          
            Dim pScriptAddChart As String = PopulateChart.AddScript(Page, Request.QueryString("type"), Request.QueryString("rt"), _year, lblHead, txtsdate, txtedate, _limit, ddldate.SelectedValue)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> " & pScriptAddChart & " </script>", False)
        End If

    End Sub

#Region "Export data"
    Private Function LoadDataExport(ByVal IsExcel As Boolean) As DataTable
        Dim _limit As Integer = 0
        If Request.QueryString("type") = "8" Then
            If Request.QueryString("IsAll") = "1" Then
                _limit = 0
            Else
                _limit = 5
            End If
        ElseIf Request.QueryString("type") = "10" Then
            
        End If
        Dim dtChart As DataTable = PopulateChart.ConvertDataExport(Page, Request.QueryString("type"), Request.QueryString("rt"), _year, lblHead, txtsdate, txtedate, _limit, IsExcel, ddldate.SelectedValue)
        Return dtChart
    End Function

   

    'Private dtChart As DataTable
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
        Response.AddHeader("Content-Disposition", "attachment;filename=myChart" & Request.QueryString("type") & ".csv")
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
        Response.AddHeader("content-disposition", "attachment;filename=myChart" & Request.QueryString("type") & ".xls")
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

        'style to format numbers to string
        
        Dim style As String = "<style> .textmode{mso-number-format:\@;}  </style>"

        Dim headerTable As String = ""
        Dim cntColumns As Integer = dtExcel.Columns.Count
        If Request.QueryString("type") = "8" Then
            headerTable = "<table border=1><tr><td colspan=" & cntColumns & "><center><b>ด่านศุลกากรที่ขออนุญาตรถผ่านเข้า-ออก<b></center></td></tr><tr>" & _
            "<td><center><b>ประเภทด่าน<b></center></td>" & _
            "<td><center><b>ลำดับที่<b></center></td>" & _
            "<td><center><b>ด่านศุลการกร</center></td>"
            For col As Integer = 3 To dtExcel.Columns.Count - 1
                headerTable = headerTable & "<td><center><b>" & dtExcel.Columns(col).ColumnName & "</center></td>"
            Next
            headerTable = headerTable & "</tr></table>"
        ElseIf Request.QueryString("type") = "10" Then
            headerTable = "<table border=1><tr><td colspan=" & cntColumns & "><center><b>จำนวนรถที่ขออนุญาตเข้ามาในราชอาณาจักรเป็นการชั่วคราว<br/>จำแนกตามผู้ประกอบการธุรกิจนำเที่ยว<b></center></td></tr><tr>" & _
            "<td><center><b>ลำดับที่<b></center></td>" & _
            "<td><center><b>ผู้ประกอบการธุรกิจนำเที่ยว</center></td>"
            For col As Integer = 2 To dtExcel.Columns.Count - 1
                headerTable = headerTable & "<td><center><b>" & dtExcel.Columns(col).ColumnName & "</center></td>"
            Next
            headerTable = headerTable & "</tr></table>"
        ElseIf Request.QueryString("type") = "11" Then
            headerTable = "<table border=1><tr><td colspan=" & cntColumns & "><center><b>การขออนุญาตรถเข้ามาในราชอาณาจักร<b></center></td></tr><tr>" & _
            "<td><center><b>ลำดับที่<b></center></td>" & _
            "<td><center><b>สำนักงาน</center></td>"
            For col As Integer = 2 To dtExcel.Columns.Count - 1
                headerTable = headerTable & "<td><center><b>" & dtExcel.Columns(col).ColumnName & "</center></td>"
            Next
            headerTable = headerTable & "</tr></table>"
        ElseIf Request.QueryString("type") = "13" Then
            headerTable = "<table border=1><tr><td colspan=" & cntColumns & "><center><b>การขออนุญาตรถเข้ามาในราชอาณาจักร<b></center></td></tr><tr>" & _
            "<td><center><b>ลำดับที่<b></center></td>" & _
            "<td><center><b>ประเทศที่รถจดทะเบียน</center></td>"
            For col As Integer = 2 To dtExcel.Columns.Count - 1
                headerTable = headerTable & "<td><center><b>" & dtExcel.Columns(col).ColumnName & "</center></td>"
            Next
            headerTable = headerTable & "</tr></table>"
        End If
        Response.Write(headerTable)
        Response.Write(style)
        Dim html As String = sw.ToString()
        Response.Output.Write(html.ToString)
        Response.Flush()
        Response.End()
    End Sub

  

#End Region
    
End Class
