Imports Npgsql
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Globalization



Partial Class ManageApp
    Inherits System.Web.UI.Page
    Protected statusth As String
    Protected Img As String
    Protected name As String
    Dim fPath As String = Server.MapPath(ConfigurationManager.AppSettings("FilePhotoDriver"))
    Dim fPathCar As String = Server.MapPath(ConfigurationManager.AppSettings("FileVehicle"))
    Dim fPathLicense As String = Server.MapPath(ConfigurationManager.AppSettings("FileLicenseDriver"))
    Dim fPathPassport As String = Server.MapPath(ConfigurationManager.AppSettings("FilePassport"))
    Dim fPathRegiscar As String = Server.MapPath(ConfigurationManager.AppSettings("FileRegisterCar"))
    Dim fPathAct As String = Server.MapPath(ConfigurationManager.AppSettings("FileAct"))
    Dim fPathAuthorize As String = Server.MapPath(ConfigurationManager.AppSettings("FileAuthorize"))

    Private PopulateS As New PopulateScript
    Private populate As New PopulateDropDown
    Dim checktab As Integer

    Private tbImage As New DataTable
    Private tbSpareDriver As New DataTable
    Dim passport As Date
    Dim birthday As Date
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("status") = 1 Then
            name = "Local Vehicle"
        ElseIf Request.QueryString("status") = 3 Then
            name = "International Agreement Personal Vehicle (Laos)"
        ElseIf Request.QueryString("status") = 4 Then
            name = "International Agreement Personal Vehicle (Malaysia/Singapore)"
        ElseIf Request.QueryString("status") = 2 Then
            name = "Tourist Vehicle"
        End If
    End Sub

    Private Sub loadData()
        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dt As DataTable
        Dim strsql As String = ""
        Try
            strsql = " select plate , name_company , brands , model , colors , start_date , exp_date , country_car , status_en  from driver  " & _
                     " LEFT JOIN license on driver.driver_id = license.driver_id  " & _
                     " LEFT JOIN car on license.car_id = car.car_id  " & _
                     " LEFT JOIN status on status.status_id = license.status_id " & _
                     " LEFT JOIN user_travel on license.travel_id = user_travel.user_id"
            If txtlicense.Text <> "" Then
                strsql = strsql & " WHERE plate = '" & txtlicense.Text & "'"
            End If
       
            dt = dbConnect.getDataTable(strsql, "local")
            dbConnect = Nothing
            PopulateS.SetGrid_Footable(gvMain, dt)
            UpdGrid.Update()

        Catch ex As Exception
        Finally
        End Try
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If txtlicense.Text <> "" Then
            loadData()
        End If
    End Sub

    Protected Sub gvMain_DataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
            e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(9).Attributes.Add("data-breakpoints", "xs")

          
        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        Else


        End If
    End Sub
End Class
