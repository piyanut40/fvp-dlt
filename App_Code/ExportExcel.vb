'Imports Microsoft.VisualBasic
'Imports System.Data
Imports System.IO
'Imports Microsoft.Reporting.WebForms

'Imports ClosedXML.Excel

Public Class ExportExcel

    Public Shared Sub ConvertOld(ByVal ds As System.Data.DataSet, ByVal pfilename As String, ByVal response As HttpResponse)
        Try
            'first let's clean up the response.object
            response.Clear()
            response.Charset = ""

            response.BufferOutput = True
            response.AddHeader("content-disposition", "attachment;filename=" & pfilename)
            response.ContentEncoding = System.Text.Encoding.Unicode
            response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())

            'set the response mime type for excel
            response.ContentType = "application/vnd.ms-excel"
            'response.ContentType = "application/vnd.xls"
            'create a string writer
            Dim stringWrite As New System.IO.StringWriter
            'create an htmltextwriter which uses the stringwriter
            Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
            'instantiate a datagrid
            Dim dg As New DataGrid
            'set the datagrid datasource to the dataset passed in
            dg.DataSource = ds.Tables(0)
            'bind the datagrid
            dg.DataBind()
            'tell the datagrid to render itself to our htmltextwriter
            dg.RenderControl(htmlWrite)
            'all that's left is to output the html

            response.Write(stringWrite.ToString)
            response.End()

        Catch ex As Exception


        End Try
    End Sub

    Public Shared Sub Convert(ByVal dt As System.Data.DataTable, ByVal pfilename As String, ByVal response As HttpResponse)
        'pfilename = pfilename & "x"

        'Create a dummy GridView
        Dim GridView1 As New GridView()
        GridView1.AllowPaging = False
        GridView1.DataSource = dt
        GridView1.DataBind()

        response.Clear()
        response.Buffer = True
        response.AddHeader("content-disposition", "attachment;filename=" & pfilename)
        response.Charset = ""

        '2003
        response.ContentType = "application/vnd.ms-excel"

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
        Dim style As String = "<style> .textmode{mso-number-format:\@;}</style>"
        response.Write(style)
        response.Output.Write(sw.ToString())
        response.Flush()
        response.End()
    End Sub


    Public Shared Sub Convert(ByVal dt As System.Data.DataTable, ByVal pfilename As String, ByVal response As HttpResponse, ByVal headerTable As String)
        'pfilename = pfilename & "x"

        'Create a dummy GridView
        Dim GridView1 As New GridView()
        GridView1.AllowPaging = False
        GridView1.ShowHeader = False
        GridView1.DataSource = dt
        GridView1.DataBind()

        response.Clear()
        response.Buffer = True
        response.AddHeader("content-disposition", "attachment;filename=" & pfilename)
        response.Charset = ""

        '2003
        response.ContentType = "application/vnd.ms-excel"

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
        Dim style As String = "<style> .textmode{mso-number-format:\@;}</style>"
        'Dim headerTable As String = "<Table><tr><td colspan=20 ><center><b>" & pHead & "<b></center></td></tr></Table>"
        response.Write(headerTable)
        response.Write(style)
        Dim html As String = sw.ToString() '.Replace("www.google.com", "=HYPERLINK('www.google.com',test)")
        response.Output.Write(html.ToString)
        response.Flush()
        response.End()
    End Sub

    Public Shared Sub Convert(ByVal dt As System.Data.DataTable, ByVal pfilename As String, ByVal response As HttpResponse, ByVal headerTable As String, ByVal IsShowHeader As Boolean)
        'pfilename = pfilename & "x"

        'Create a dummy GridView
        Dim GridView1 As New GridView()
        GridView1.AllowPaging = False
        GridView1.ShowHeader = IsShowHeader
        GridView1.DataSource = dt
        GridView1.DataBind()

        response.Clear()
        response.Buffer = True
        response.AddHeader("content-disposition", "attachment;filename=" & pfilename)
        response.Charset = ""

        '2003
        response.ContentType = "application/vnd.ms-excel"

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
        Dim style As String = "<style> .textmode{mso-number-format:\@;}</style>"
        'Dim headerTable As String = "<Table><tr><td colspan=20 ><center><b>" & pHead & "<b></center></td></tr></Table>"
        response.Write(headerTable)
        response.Write(style)
        Dim html As String = sw.ToString() '.Replace("www.google.com", "=HYPERLINK('www.google.com',test)")
        response.Output.Write(html.ToString)
        response.Flush()
        response.End()
    End Sub

    Private Shared Sub DelFileExcel(ByVal filename As String)
        Dim fNews As FileInfo
        If File.Exists(filename) Then
            fNews = New FileInfo(filename)
            fNews.Delete()
        End If
    End Sub

    Public Shared Sub ConvertNoServer(ByVal dt As Data.DataTable, ByVal pfilename As String, ByVal response As HttpResponse)


        Try


            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value


            xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
            xlWorkBook = xlApp.Workbooks.Add(misValue)

            xlWorkSheet = xlWorkBook.Sheets("sheet1")

            Dim i As Integer = 1
            For col = 0 To dt.Columns.Count - 1
                xlApp.Cells(1, i).value = dt.Columns(col).ColumnName
                xlApp.Cells(1, i).EntireRow.Font.Bold = True
                i += 1
            Next

            i = 2

            Dim k As Integer = 1
            For col = 0 To dt.Columns.Count - 1
                i = 2
                For row = 0 To dt.Rows.Count - 1
                    xlApp.Cells(i, k).Value = dt.Rows(row).ItemArray(col)
                    i += 1
                Next
                k += 1
            Next


            Dim target As String = ConfigurationManager.AppSettings("filepath") & "excel\"
            Dim filename As String = target & pfilename
            If Directory.Exists(target) = False Then
                Directory.CreateDirectory(target)
            End If
            DelFileExcel(filename)
            xlWorkSheet.SaveAs(filename)
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            dialogSave(filename, pfilename, response)

            'ExportToExcelss(dt, filename) 
        Catch ex As Exception
            response.Write(ex.Message)
        End Try

        'ExportDatasetToExcel(ds, "d:\\my.xls")
    End Sub

    Private Shared Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Shared Sub dialogSave(ByVal filename As String, ByVal pfilename As String, ByVal response As HttpResponse)
        Dim objFileInfo As System.IO.FileInfo
        Try

            If Not System.IO.File.Exists(filename) Then Exit Sub
            objFileInfo = New System.IO.FileInfo(filename)
            response.Clear()

            response.AddHeader("Content-Disposition", "attachment; filename=" & pfilename)
            response.AddHeader("Content-Length", objFileInfo.Length.ToString())
            response.ContentType = "application/octet-stream"
            response.WriteFile(objFileInfo.FullName)
        Catch
        Finally
            response.End()
        End Try
    End Sub


End Class


