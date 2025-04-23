Imports System.Data
Imports Npgsql
Imports System.IO
Imports System.Drawing
Imports Microsoft.Reporting.WebForms
Imports System.Net

Partial Class RptApplication
    Inherits System.Web.UI.Page
    Private fPathpdf As String = ConfigurationManager.AppSettings("FileApt")
    Private _fPath As String = "FileApt"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim token = Request.QueryString("token")
        If IsPostBack = False Then
            getTsmData()
        End If
    End Sub

    Dim dt As New DataTable
    Dim dt2 As New DataTable
    Dim dt3 As New DataTable
    Private Sub getTsmData()
        Dim db As New DBConnect


        Dim str As String = " select coalesce(prename,'') || coalesce(name,'') || ' ' || coalesce(surname,'') as name, coalesce(national,'-') as nationality " & _
                            " , coalesce(gender,'-') as gender, coalesce(driver.address,'-') as address, coalesce(state,'-') as state, coalesce(countries,'-') as country , coalesce(zipcode,'-') as zipcode " & _
                            " , coalesce(tel,'-') as telephone , coalesce(driver.email,'-') as email , coalesce(thailicense_no,'-') as driver_license_no, license_expire,''  as driver_license_exp_date , act_company2 as company_name2, act_no2 as insurance_number2 " & _
                            " , cast(act_start2 as date) as insurance_start_date2, cast(act_ends2 as date) as insurance_exp_date2" & _
                            " , coalesce(type_name,'-')  as vehicle_type , coalesce(brands,'-')  as make, coalesce(model,'-')  as model, colors as color, seat, weight, coalesce(country_car,'-') as country_register, coalesce(province_car,'-') as province_register ,plate as license_plate_eng, platelocal as license_plate_Local " & _
                            " , coalesce(engine_no,'-')  as serial_engine_number, coalesce(engine_cap,'-') as engine_capacity, coalesce(car_no,'-') as VIN , act_company as company_name, act_no as insurance_number, act_start as insurance_start_date, act_ends as insurance_exp_date, qrcode as urlqrcode " & _
                            " , border_check.border_nameen as check_in_border, border_check2.border_nameen as check_out_border, license.driver_id ,  coalesce(prename,'') || coalesce(name,'') || ' ' || coalesce(surname,'') as drivername1 , CAST('' as varchar ) as drivername2 , CAST('' as varchar ) as drivername3" & _
                            " , license.typeuser_id , license.license_no , coalesce(owner_prename,'')as owner_prename , owner_name , owner_lastname " & _
                            " , passport_no as passport_no1  , CAST('' as varchar ) as passport_no2 , CAST('' as varchar ) as passport_no3 " & _
                            " , national as national1  , CAST('' as varchar ) as national2 , CAST('' as varchar ) as national3 " & _
                            " , driver.idcard_no  as idcard_no1  , CAST('' as varchar ) as idcard_no2 , CAST('' as varchar ) as idcard_no3 " & _
                            " , user_travel.name_company, user_travel.company_license, regis_no, case when license.typeuser_id <> 2 then license.start_date else travel_group.start_date end as start_date, case when license.typeuser_id <> 2 then license.exp_date else travel_group.exp_date end as exp_date, admin_nameen " & _
                            " from driver inner join license on license.driver_id = driver.driver_id " & _
                            " left join user_travel on user_travel.user_id = license.travel_id " & _
                            " left join car on license.car_id = car.car_id " & _
                            " left join type_car on type_car.type_id = car.typecar_id " & _
                            " left join act on act.act_id = license.act_id " '& _
        If Not (Request.QueryString("rt") Is Nothing) Then
            If Request.QueryString("rt") = 2 Then
                str = str & " left join travel_group_car on travel_group_car.license_id = license.license_id " & _
                             " left join travel_group on travel_group.group_id = travel_group_car.group_id " & _
                             " left join border_check on border_check.border_id = travel_group.checkin_id " & _
                             " left join border_check border_check2 on border_check2.border_id = travel_group.checkout_id " & _
                             " left join admin on admin.admin_id = travel_group.admin_id " '& _
            Else
                str = str & " left join border_check on border_check.border_id = license.checkin_id " & _
                             " left join border_check border_check2 on border_check2.border_id = license.checkout_id " & _
                             " left join travel_group_car on travel_group_car.license_id = license.license_id " & _
                             " left join travel_group on travel_group.group_id = travel_group_car.group_id " & _
                             " left join admin on admin.admin_id = license.admin_id " '& _
            End If

        Else
            str = str & " left join border_check on border_check.border_id = license.checkin_id " & _
                             " left join border_check border_check2 on border_check2.border_id = license.checkout_id " & _
                             " left join travel_group_car on travel_group_car.license_id = license.license_id " & _
                             " left join travel_group on travel_group.group_id = travel_group_car.group_id " & _
                             " left join admin on admin.admin_id = license.admin_id " '& _
        End If

        str = str & " WHERE token = '" & Request.QueryString("token") & "' "
        dt = db.getDataTable(str, "Licence")


        dt(0).Item("driver_license_exp_date") = Format(CDate(dt(0).Item("license_expire").ToString.Split(" ")(0)), "dd MMMM yyyy")
        If Not (dt(0).Item("insurance_start_date") Is DBNull.Value) Then
            dt(0).Item("insurance_start_date") = Format(CDate(dt(0).Item("insurance_start_date").ToString.Split(" ")(0)), "dd MMMM yyyy")
        End If
        If Not (dt(0).Item("insurance_exp_date") Is DBNull.Value) Then
            dt(0).Item("insurance_exp_date") = Format(CDate(dt(0).Item("insurance_exp_date").ToString.Split(" ")(0)), "dd MMMM yyyy")
        End If
        If Not (dt(0).Item("insurance_start_date2") Is DBNull.Value) Then
            dt(0).Item("insurance_start_date2") = Format(CDate(dt(0).Item("insurance_start_date2").ToString.Split(" ")(0)), "dd MMMM yyyy")
        End If
        If Not (dt(0).Item("insurance_exp_date2") Is DBNull.Value) Then
            dt(0).Item("insurance_exp_date2") = Format(CDate(dt(0).Item("insurance_exp_date2").ToString.Split(" ")(0)), "dd MMMM yyyy")
        End If


        str = "select *,coalesce(prename,'') || coalesce(name,'') || ' ' || coalesce(surname,'') as driver_name , passport_no ,  national , license_no " & _
            " from spare_driver where driver_id = " & dt(0).Item("driver_id").ToString & _
            " order by spare_ord"

        dt2 = db.getDataTable(str, "Driver")

        Dim i = 2
        For Each dr As DataRow In dt2.Rows
            Try
                dt(0).Item("drivername" & i) = IIf(dr("driver_name").ToString.Trim = "", "-", dr("driver_name"))
                dt(0).Item("passport_no" & i) = IIf(dr("passport_no").ToString.Trim = "", "-", dr("passport_no"))
                dt(0).Item("national" & i) = IIf(dr("national").ToString.Trim = "", "-", dr("national"))
                dt(0).Item("idcard_no" & i) = IIf(dr("license_no").ToString.Trim = "", "-", dr("license_no"))

                dt(0).Item("name") = dt(0).Item("name") & " / " & IIf(dr("driver_name").ToString.Trim = "", "-", dr("driver_name"))
                dt(0).Item("nationality") = dt(0).Item("nationality") & " / " & IIf(dr("national").ToString.Trim = "", "-", dr("national"))
                dt(0).Item("gender") = dt(0).Item("gender") & " / " & IIf(dr("gender").ToString.Trim = "", "-", dr("gender"))
                dt(0).Item("address") = dt(0).Item("address") & " / " & IIf(dr("address").ToString.Trim = "", "-", dr("address"))
                dt(0).Item("state") = dt(0).Item("state") & " / " & IIf(dr("state").ToString.Trim = "", "-", dr("state"))
                dt(0).Item("country") = dt(0).Item("country") & " / " & IIf(dr("country").ToString.Trim = "", "-", dr("country"))
                dt(0).Item("zipcode") = dt(0).Item("zipcode") & " / " & IIf(dr("zipcode").ToString.Trim = "", "-", dr("zipcode"))
                dt(0).Item("email") = dt(0).Item("email") & " / " & IIf(dr("email").ToString.Trim = "", "-", dr("email"))
                dt(0).Item("telephone") = dt(0).Item("telephone") & " / " & IIf(dr("tel").ToString.Trim = "", "-", dr("tel"))
                dt(0).Item("driver_license_no") = dt(0).Item("driver_license_no") & " / " & IIf(dr("license_no").ToString.Trim = "", "-", dr("license_no"))
                If dr("license_exp_date") Is DBNull.Value Then
                    dt(0).Item("driver_license_exp_date") = dt(0).Item("driver_license_exp_date") & " / -"
                Else
                    dt(0).Item("driver_license_exp_date") = dt(0).Item("driver_license_exp_date") & " / " & Format(CDate(dr("license_exp_date")), "dd MMMM yyyy")
                End If
            Catch ex As Exception

            End Try
            i = i + 1
        Next

     
        Dim pdf_file As String
        If dt(0).Item("typeuser_id") = 2 Then
            pdf_file = GetpdfFile(dt, "Report/RptApplication_V2.rdlc", "dsApplication", "RptApplication" & Request.QueryString("token"))
        Else
            pdf_file = GetpdfFile(dt, "Report/RptApplication_V3.rdlc", "dsApplication", "RptApplication" & Request.QueryString("token"))
        End If

   

        Dim User As WebClient = New WebClient()
        Dim FileBuffer As Byte() = User.DownloadData(pdf_file)
        If FileBuffer IsNot Nothing Then
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-length", FileBuffer.Length.ToString())
            Response.BinaryWrite(FileBuffer)
        End If
    End Sub

    Private Sub LoadFilePdf(ByVal fileName As String)
        Dim pathFile As String = Server.MapPath(ConfigurationManager.AppSettings("FilePDF")) & fileName
        Dim User As WebClient = New WebClient()
        Dim FileBuffer As Byte() = User.DownloadData(pathFile)

        If FileBuffer IsNot Nothing Then
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-length", FileBuffer.Length.ToString())
            Response.BinaryWrite(FileBuffer)
        End If
    End Sub

    ' Private fpathTrailer As String = ConfigurationSettings.AppSettings("FileTrailerSmall")

    Private Sub DisplayReport()
        'getTsmData()
        'Dim dt As DataTable = getTsmData()

        Dim rpt As LocalReport = ReportViewer1.LocalReport
        rpt.DataSources.Clear()
        rpt.EnableExternalImages = True
        rpt.ReportPath = "Report\RptApplication_V2.rdlc"

        ''Add ข้อมูลลง DataSet
        Dim rds As ReportDataSource
        rds = New ReportDataSource("dsApplication", dt)
        rpt.DataSources.Add(rds)


        Dim parameters(0) As ReportParameter
        parameters = New ReportParameter(0) {}
        Dim fPathLogo As String = ConfigurationManager.AppSettings("FileTravel")
        Dim pImgBarCode As String = "file:\" & Server.MapPath(fPathLogo) & "logoL.png" 'รถประจำถิ่น
        pImgBarCode = pImgBarCode.ToString.Replace("Upload\FileTravel\", "image\")
        Dim drRow As DataRow = dt.Rows(0)
        If drRow("typeuser_id") = 2 Then 'รถท่องเที่ยว 
            pImgBarCode = pImgBarCode.ToString.Replace("logoL.png", "logoT.png")
        End If
        parameters(0) = New ReportParameter("PathIMG", pImgBarCode, True)
        rpt.SetParameters(parameters)

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





    End Sub
    Private Sub dialogSave(ByVal strFName As String, ByVal strSrcName As String) ', ByVal strSrcName As String, ByVal folder As String
        Dim objFileInfo As System.IO.FileInfo
        Try

            'strFName = Server.MapPath("..\app_files\" & folder & "\" & strSrcName)
            'exit if file does not exist
            If Not System.IO.File.Exists(strFName) Then Exit Sub
            objFileInfo = New System.IO.FileInfo(strFName)
            Response.Clear()

            'Add Headers to enable dialog display
            Dim att As String = [String].Format("attachment; filename={0}", Server.UrlPathEncode(strSrcName))

            Response.AddHeader("Content-Disposition", att)
            'Response.AddHeader("Content-Disposition", "attachment; filename=" & strSrcName)
            Response.AddHeader("Content-Length", objFileInfo.Length.ToString())

            Response.ContentType = "application/octet-stream"
            Response.WriteFile(objFileInfo.FullName)

        Catch
            'on exception take no action Response.End()
        Finally
            'Dim script As String = "window.close(); "
            'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Response.End()
        End Try

    End Sub

    Private Function GetpdfFile(ByVal tb As DataTable, ByVal pReportPath As String, ByVal pDataSource As String, ByVal pFilename As String) As String
        If Not tb Is Nothing Then
            Dim rds As ReportDataSource
            Dim rpt As New ReportViewer
            rpt.SizeToReportContent = True
            rpt.ProcessingMode = ProcessingMode.Local
            rpt.LocalReport.ReportPath = pReportPath
            rpt.LocalReport.EnableExternalImages = True

            If pFilename.IndexOf("_") > 0 Then
            
                Dim parameters(0) As ReportParameter
                parameters = New ReportParameter(0) {}
                Dim fpath As String = "file:\" & Server.MapPath(ConfigurationManager.AppSettings(_fPath))
                parameters(0) = New ReportParameter("fpath", fpath, True)
                rpt.LocalReport.SetParameters(parameters)

            Else
                If pReportPath.ToString.Contains("_V2") Or pReportPath.ToString.Contains("_V3") Then
                    Dim parameters(0) As ReportParameter
                    parameters = New ReportParameter(0) {}
                    Dim fPathLogo As String = ConfigurationManager.AppSettings("FileTravel")
                    Dim pImgBarCode As String = "file:\" & Server.MapPath(fPathLogo) & "logoL.png" 'รถประจำถิ่น
                    pImgBarCode = pImgBarCode.ToString.Replace("Upload\FileTravel\", "image\")
                    Dim drRow As DataRow = dt.Rows(0)
                    If drRow("typeuser_id") = 2 Then 'รถท่องเที่ยว 
                        pImgBarCode = pImgBarCode.ToString.Replace("logoL.png", "logoT.png")
                    End If
                    parameters(0) = New ReportParameter("PathIMG", pImgBarCode, True)
                    rpt.LocalReport.SetParameters(parameters)
                End If


            End If


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

            'bytes = rptViewer.LocalReport.Render("PDF", deviceInfo, mimeType, encoding, fileNameExtension, streams, warnings)

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
