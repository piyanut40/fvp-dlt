Imports System.Data
Imports Npgsql
Imports System.IO
Partial Class Admin_departures
    Inherits System.Web.UI.Page
    Protected pagetext As String
    Protected name As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_id") = Nothing Then
            Response.Redirect("../Login.aspx")
        Else
            If Request.QueryString("rt") = 1 Then


                pagetext = "จัดการรถออกจากราชอาณาจักร (รถประจำถิ่น)"
                name = "ชื่อผู้ใช้รถ"

            Else
                pagetext = "จัดการรถออกจากราชอาณาจักร (รถท่องเที่ยว)"
                name = "ชื่อบริษัท"

            End If
        End If
    End Sub
End Class
