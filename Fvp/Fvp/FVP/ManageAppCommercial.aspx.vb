Imports Npgsql
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Globalization



Partial Class ManageAppCommercial
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub loadData()
        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dt As DataTable
        Dim strsql As String = ""
        Try
            strsql = " SELECT license_id , brand , status_id , registration_no , model , colour , vin_no , engine_no , CAST('~/Document.aspx?token=' || token || '&typeuser=5' as varchar) as urltoken , CAST('~/Sign.aspx?token=' || token || '&typeuser=5' as varchar) as urlsign from license " & _
                   " inner join car_commerce on car_commerce.car_id = license.car_id  "
            If txtVinNo.Text <> "" Then
                strsql = strsql & "WHERE vin_no = '" & txtVinNo.Text & "' and status_id = 0 or vin_no = '" & txtVinNo.Text & "' and status_id = 5 "
            End If

        Catch ex As Exception
        Finally
            dt = dbConnect.getDataTable(strsql, "local")
            dbConnect = Nothing
            PopulateS.SetGrid_Footable(gvMain, dt)
            UpdGrid.Update()


        End Try



    End Sub
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If txtVinNo.Text <> "" Then
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
        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        Else
            'Dim hyperlinkDoc As HyperLink = e.Row.Cells(9).FindControl("HyperDoc")
            'Dim hyperlinkQRcode As HyperLink = e.Row.Cells(10).FindControl("HyperDoc2")
            'If e.Row.Cells(8).Text.Contains("Pass") Then
            '    hyperlinkDoc.Visible = True
            '    hyperlinkQRcode.Visible = True
            'Else
            '    hyperlinkDoc.Visible = False
            '    hyperlinkQRcode.Visible = False
            'End If
        End If
    End Sub

End Class
