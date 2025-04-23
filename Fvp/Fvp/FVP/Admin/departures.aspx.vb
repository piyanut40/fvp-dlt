Partial Class Admin_departures
    Inherits System.Web.UI.Page
    Protected text As String
    Protected name As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_id") = Nothing Then
            Response.Redirect("../Login.aspx")
        Else
            If Request.QueryString("rt") = 1 Then


                text = "จัดการรถออกจากราชอาณาจักร (รถประจำถิ่น)"
                name = "ชื่อผู้ใช้รถ"

            Else
                text = "จัดการรถออกจากราชอาณาจักร (รถท่องเที่ยว)"
                name = "ชื่อบริษัท"

            End If
        End If
    End Sub
End Class
