Imports System.Data

Partial Class Control_SearchLicense
    Inherits System.Web.UI.Page

    Public Class ListOfLicense
        Public license_no As String
    End Class

    <Services.WebMethod()> _
<Script.Services.ScriptMethod(ResponseFormat:=Script.Services.ResponseFormat.Json)> _
    Public Shared Function GetLicense(ByVal name As String) As List(Of ListOfLicense)
        Dim db As New DBConnect
        Dim License As New List(Of ListOfLicense)()

        Dim strselect As String
        strselect = " select distinct license_no as text from license where license_no <> '' and status_id = 5 order by license_no "
        Dim dt As DataTable = db.getDataTable(strselect, "Data")
        For Each dr In dt.Rows
            Try
                ' Add parts to the list.
                License.Add(New ListOfLicense() With {.license_no = dr("license_no")})
            Catch ex As Exception
                ' Place.Add(New ListOfPlace() With {.OBJECT_ID = dr("OBJECT_ID"), .PlaceTH = dr("name"), .lon = 0, .lat = 0, .img = "../images/i_map.gif", .icon = ""})
            End Try
        Next
        Return License
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Dim db As New DBConnect
            Dim DtProvince As New DataTable
            Try

                DtProvince = db.getDataTable(" select distinct coalesce(license_no,license_group) as license_no , token " & _
                                             " from vmaplocation where status_id = 5 and token is not null ", "Data")
            Catch ex As Exception

            Finally
                db = Nothing
            End Try

            Dim jsDataSource As New StringBuilder
            jsDataSource.Remove(0, jsDataSource.Length)
            jsDataSource.Append(" var data_source = [ ")
            For Each dr In DtProvince.Rows
                jsDataSource.Append(" { 'license': '" & dr("license_no") & "' , 'token' : '" & dr("token") & "'} ,  ")
            Next
            jsDataSource.Append(" ]; ")
            mBody.Attributes.Add("onload", jsDataSource.ToString & " AddSmartSearch(data_source); ")
        End If
    End Sub
End Class
