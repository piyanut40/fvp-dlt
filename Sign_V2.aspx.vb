Imports Microsoft.Reporting.WebForms
Imports System.Data
Imports System.IO
Imports System.Net

Partial Class Sign_V2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            DisplayReport()
        End If
    End Sub

    Private Sub DisplayReport()

        Dim rpt As LocalReport = ReportViewer1.LocalReport
        rpt.DataSources.Clear()
        rpt.EnableExternalImages = True
        rpt.ReportPath = "Report\Sign_V2.rdlc"
        Dim db As New DBConnect
        Dim dt As New DataTable
        Try
            dt = getTsmData()
        Catch ex As Exception

        Finally
            db = Nothing
        End Try

        ''Add ข้อมูลลง DataSet
        Dim rds As ReportDataSource
        rds = New ReportDataSource("DataSet1", dt)
        rpt.DataSources.Add(rds)



        Me.ReportViewer1.ShowReportBody = True
        Me.ReportViewer1.ShowPromptAreaButton = True
        Dim pBrowser = System.Web.HttpContext.Current.Request.Browser.Browser
        If pBrowser = "Chrome" Or pBrowser = "Firefox" Then
            ReportViewer1.AsyncRendering = False
            ReportViewer1.Width = Unit.Percentage(100)
        Else
            ReportViewer1.Width = Unit.Percentage(100)
        End If
        ReportViewer1.Height = Unit.Pixel(700)
        ReportViewer1.LocalReport.Refresh()

        Dim pdf As String = GetpdfFile(dt, "Report\Sign_V2.rdlc", "DataSet1", "Sign22")


        'Dim fileName As String = "DocSign22.pdf"
        Dim dirPath As String = Server.MapPath(fPathpdf)
        If Not Directory.Exists(dirPath) Then
            Directory.CreateDirectory(dirPath)
        End If
        'Dim pdf As String = dirPath & fileName
        'DelFilePdf(pdf)

        Dim pathFile As String = pdf
        Dim User As WebClient = New WebClient()
        Dim FileBuffer As Byte() = User.DownloadData(pathFile)

        If FileBuffer IsNot Nothing Then
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-length", FileBuffer.Length.ToString())
            Response.BinaryWrite(FileBuffer)
        End If
    End Sub


    Private Function getTsmData() As DataTable
        Dim token = Request.QueryString("token")
         

        'ข้อมูลคนขับรถหลัก
        Dim dt As New DataTable
        Dim db As New DBConnect
        Dim str As String
        If Request.QueryString("typeuser") = 5 Then
            str = " SELECT CAST('เลขที่ใบอนุญาต' || license.license_no  as varchar ) as province , sign_th ,  car_commerce.registration_no as plate ,(select string_agg(prov_en , ',') from area " & _
                  " LEFT JOIN province on area.prov_code = province.prov_code  WHERE license_id = license.license_id) as area , (select count(prov_en) from area LEFT JOIN province on area.prov_code = province.prov_code " & _
                  " WHERE license_id = license.license_id) as countprov  , car_commerce.country_car ,  " & _
                  " CAST('1 . ' || driver.prename || ' ' || driver.name ||' '|| driver.surname as varchar) as name ,  CAST( driver.prename || ' ' || driver.name ||' '|| driver.surname as varchar) as name1 , " & _
                  "  (select CAST('2 . ' || spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 1) as name2, " & _
                  "  (select CAST('3 . ' || spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 2) as name3, " & _
                  "    car_commerce.vehicle_type as type_car , car_commerce.colour as colors , car_commerce.brand as brands , car_commerce.model , (SELECT REPLACE(border_nameth,'ด่านพรมแดน','') from border_check WHERE license.checkin_id = border_check.border_id)as checkin ,  " & _
                  "    (SELECT REPLACE(border_nameth,'ด่านพรมแดน','') from border_check WHERE license.checkout_id = border_check.border_id)as checkout , CAST('https://api.qrserver.com/v1/create-qr-code/?data=' as varchar)|| qrcode as qrcode , CAST( start_date || ' - ' ||  exp_date as varchar ) as exp , " & _
                  "     CAST('Upload/Vehicle/' || (SELECT car_pic.file_name from car_pic WHERE car_id = car.car_id order by gid asc  limit 1 ) as varchar ) as pic  from license " & _
                  "       LEFT JOIN border_check on border_check.border_id = license.checkin_id  LEFT JOIN province on province.prov_code = border_check.prov_code " & _
                  "       LEFT JOIN type_user on license.typeuser_id = type_user.typeuser_id LEFT JOIN car on license.car_id = car.car_id  " & _
                  "        LEFT JOIN driver on license.driver_id = driver.driver_id  LEFT JOIN spare_driver on spare_driver.driver_id = driver.driver_id  " & _
                  "        LEFT JOIN car_commerce on car_commerce.car_id = license.car_id " & _
                  "         WHERE token = '" & token & "' and status_id in(4,5) limit 1 "
        ElseIf Request.QueryString("typeuser") = 3 Or Request.QueryString("typeuser") = 4 Or Request.QueryString("typeuser") = 2 Then

      

            str = " SELECT CAST('image/sign2.jpg' as varchar) as imgsign, CAST(license.license_no  as varchar ) as permit , " & _
                  " plate ,CAST('' as varchar) as area ,  " & _
                  " (select count(prov_en) from area " & _
                  "  LEFT JOIN province on area.prov_code = province.prov_code " & _
                  " WHERE license_id = license.license_id) as countprov , country_car ,  " & _
                  " CAST( owner_prename ||' ' || owner_name ||' '|| owner_lastname as varchar) as nameowner ,  " & _
                  " CAST('1 . ' || driver.prename || ' ' || driver.name ||' '|| driver.surname as varchar) as name1 ,  " & _
                  " (select CAST('2 . ' || spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 1) as name2,  " & _
                  " (select CAST('3 . ' || spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 2) as name3, " & _
                  " substring(type_name,0,15) as type_name  , colors , brands , model , substring((SELECT border_nameen from border_check WHERE license.checkin_id = border_check.border_id),0,23) as checkin , " & _
                  " substring((SELECT border_nameen from border_check WHERE license.checkout_id = border_check.border_id),0,23) as checkout , CAST('https://api.qrserver.com/v1/create-qr-code/?data=' as varchar)|| " & _
                  " qrcode as qrcode , to_char( start_date , 'DD/MM/YYYY') as start_date , to_char( exp_date , 'DD/MM/YYYY') as exp_date , CAST('Upload/Vehicle/' || (SELECT car_pic.file_name from car_pic WHERE car_id = car.car_id order by gid asc  limit 1 ) as varchar ) as pic " & _
                  " from license  LEFT JOIN border_check on border_check.border_id = license.checkin_id " & _
                  " LEFT JOIN admin on license.admin_id = admin.admin_id LEFT JOIN province on admin.prov_code = province.prov_code  " & _
                  " LEFT JOIN type_user on license.typeuser_id = type_user.typeuser_id LEFT JOIN car on license.car_id = car.car_id " & _
                  " LEFT JOIN driver on license.driver_id = driver.driver_id  LEFT JOIN spare_driver on spare_driver.driver_id = driver.driver_id  " & _
                  " LEFT JOIN type_car on type_car.type_id = car.typecar_id " & _
                  " WHERE token = '" & token & "' and status_id in(4,5) limit 1 "
        Else
        
            str = " SELECT CAST('image/sign1.jpg' as varchar) as imgsign, CAST(license.license_no  as varchar ) as permit , " & _
                  " plate ,(select string_agg(prov_en , ',') " & _
                  " from area LEFT JOIN province on area.prov_code = province.prov_code " & _
                  " WHERE license_id = license.license_id) as area , " & _
                  " (select count(prov_en) from area " & _
                  " LEFT JOIN province on area.prov_code = province.prov_code " & _
                  " WHERE license_id = license.license_id) as countprov , country_car ,  " & _
                  " CAST( owner_prename ||' ' || owner_name ||' '|| owner_lastname as varchar) as nameowner ,  " & _
                  " CAST( driver.prename || ' ' || driver.name ||' '|| driver.surname as varchar) as name1 ,  " & _
                  " (select CAST( spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 1) as name2,  " & _
                  " (select CAST( spare_driver.prename || ' ' || spare_driver.name ||' '|| spare_driver.surname as varchar) from spare_driver WHERE spare_driver.driver_id = driver.driver_id and spare_ord = 2) as name3, " & _
                  " substring(type_name,0,15) as type_name  , colors , brands , model , substring((SELECT border_nameen from border_check WHERE license.checkin_id = border_check.border_id),0,23) as checkin , " & _
                  " substring((SELECT border_nameen from border_check WHERE license.checkout_id = border_check.border_id),0,23) as checkout , CAST('https://api.qrserver.com/v1/create-qr-code/?data=' as varchar)|| " & _
                  " qrcode as qrcode , to_char( start_date , 'DD/MM/YYYY') as start_date , to_char( exp_date , 'DD/MM/YYYY') as exp_date ,  CAST('Upload/Vehicle/' || (SELECT car_pic.file_name from car_pic WHERE car_id = car.car_id order by gid asc  limit 1 ) as varchar ) as pic " & _
                  " from license  LEFT JOIN border_check on border_check.border_id = license.checkin_id " & _
                  " LEFT JOIN admin on license.admin_id = admin.admin_id LEFT JOIN province on admin.prov_code = province.prov_code  " & _
                  " LEFT JOIN type_user on license.typeuser_id = type_user.typeuser_id LEFT JOIN car on license.car_id = car.car_id " & _
                  " LEFT JOIN driver on license.driver_id = driver.driver_id  LEFT JOIN spare_driver on spare_driver.driver_id = driver.driver_id  " & _
                  " LEFT JOIN type_car on type_car.type_id = car.typecar_id " & _
                  " WHERE token = '" & token & "' and status_id in(4,5) limit 1 "

        End If

        dt = db.getDataTable(str, "driver")
        Return dt
    End Function

    Private fPathpdf = ConfigurationManager.AppSettings("FileApt")
    Private Function GetpdfFile(ByVal tb As DataTable, ByVal pReportPath As String, ByVal pDataSource As String, ByVal pFilename As String) As String
        If Not tb Is Nothing Then
            Dim rds As ReportDataSource
            Dim rpt As New ReportViewer
            rpt.SizeToReportContent = True
            rpt.ProcessingMode = ProcessingMode.Local
            rpt.LocalReport.ReportPath = pReportPath

            rds = New ReportDataSource(pDataSource, tb)
            rpt.LocalReport.DataSources.Clear()
            rpt.LocalReport.DataSources.Add(rds)
            rpt.LocalReport.Refresh()

            Dim dirPath As String = Server.MapPath(fPathpdf)
            If Not Directory.Exists(dirPath) Then
                Directory.CreateDirectory(dirPath)
            End If

            Dim tempfilename As String = pFilename & ".pdf"
            Dim pdfFile As String = dirPath & tempfilename
            DelFilePdf(pdfFile)

            Dim deviceInfo As String = ""
            Dim mimeType As String = ""
            Dim encoding As String = ""
            Dim fileNameExtension As String = ""
            Dim streams() As String
            Dim warnings As Warning() = Nothing
            Dim bytes() As Byte
            Dim file As System.IO.FileStream

            bytes = rpt.LocalReport.Render("PDF", Nothing, mimeType, encoding, fileNameExtension, streams, warnings)

            Response.ContentEncoding = System.Text.Encoding.UTF32
            file = New System.IO.FileStream(pdfFile, IO.FileMode.Create)
            file.Write(bytes, 0, bytes.Length)
            file.Close()
            bytes = Nothing
            Return pdfFile

        Else
            Return ""
        End If


    End Function

    Private Sub DelFilePdf(ByVal file As String)
        Dim FileIn As New FileInfo(file)
        If FileIn.Exists Then
            FileIn.Delete()
        End If
    End Sub

End Class
