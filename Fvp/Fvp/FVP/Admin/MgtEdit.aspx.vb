Partial Class MgtEdit
    Inherits System.Web.UI.Page
    Protected text As String
    Protected name As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_id") Is Nothing Then
            Response.Redirect("../Login.aspx")
        Else
            If Session("user_id") = Nothing Then
                Response.Redirect("../Login.aspx")
            Else
                If Request.QueryString("rt") = 1 Then


                    text = "ค้นหาขออนุญาตนำรถประจำถิ่นเข้ามาในราชอาณาจักร"
                    name = "ชื่อผู้ใช้รถ"

                Else
                    text = "ค้นหาขออนุญาตใช้รถในราชอาณาจักรชั่วคราว"
                    name = "ชื่อบริษัท"

                End If
            End If
        End If
    End Sub
End Class
