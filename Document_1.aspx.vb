Imports System.Data
Imports Microsoft.Reporting.WebForms

Partial Class Document_1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim token = Request.QueryString("token")
        DisplayReport()
    End Sub

    Private Function getTsmData() As DataTable
        Dim dt As New DataTable
        Dim db As New DBConnect
        Dim str As String = " select name_driver, surname , address , state , city , telephone, id_card , email , postal, " & _
                            " (select  en_short_name from countries WHERE num_code = country) as country , " & _
                            " (select  nationality from countries WHERE num_code = nation) as nation , " & _
                            " register_no , token , CAST(brands as varchar) as brandcar_en , type_name as typecar_en , model , colors , seats , " & _
                            " number_car, number_engine, license_car, cylinder_cap , " & _
                            " (select en_short_name from countries WHERE num_code = regis_country) as regis_country , " & _
                            " weight, weight_carry , " & _
                            " (select border_nameth from border_check WHERE border_id = checkin_id) as check_in , " & _
                            " (select border_nameth from border_check WHERE border_id = checkout_id) as check_out , " & _
                            " (SELECT string_agg(prov_en ,',' ) from area LEFT JOIN province on area.prov_code = province.prov_code WHERE license_id = license.license_id) as area " & _
                            " , nature , license_no , start_date , exp_date , urlqrcode from license " & _
                            " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                            " LEFT JOIN car on car.car_id = license.car_id " & _
                            " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
                            " WHERE token = '" & Request.QueryString("token") & "' "
        dt = db.getDataTable(str, "gf_Licence")
        Return dt
    End Function

    Private fpathTrailer As String = ConfigurationSettings.AppSettings("FileTrailerSmall")
    Private Sub DisplayReport()

        Dim dt As DataTable = getTsmData()

        Dim rpt As LocalReport = ReportViewer1.LocalReport
        rpt.DataSources.Clear()
        rpt.EnableExternalImages = True
        rpt.ReportPath = "Report\DocLocalLicense.rdlc"

        ''Add ข้อมูลลง DataSet
        Dim rds As ReportDataSource
        rds = New ReportDataSource("DataSet1", dt)
        rpt.DataSources.Add(rds)

        'Dim urlTrailerH As String = "file:\" & Server.MapPath(fpathTrailerH)
        'Dim parameters(0) As ReportParameter
        'parameters = New ReportParameter(0) {}
        'parameters(0) = New ReportParameter("urltrailer", urlTrailer, True)
        'rpt.EnableExternalImages = True

        Me.ReportViewer1.ShowReportBody = True
        Me.ReportViewer1.ShowPromptAreaButton = True
        Dim pBrowser = System.Web.HttpContext.Current.Request.Browser.Browser
        If pBrowser = "Chrome" Or pBrowser = "Firefox" Then
            ReportViewer1.AsyncRendering = False
            ReportViewer1.Width = Unit.Percentage(100)
        Else
            ReportViewer1.Width = Unit.Percentage(100)
        End If

        ReportViewer1.LocalReport.Refresh()
    End Sub


End Class
