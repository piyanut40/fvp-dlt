Imports System.Data
Partial Class MasterPageB
    Inherits System.Web.UI.MasterPage
    Protected _name As String
    Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Session.Clear()
        Response.Redirect("~/Login.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("user_id") Is Nothing Or Session("user_type") = "1" Or Session("user_type") = "2" Then
                Session.Clear()
                Response.Redirect("~/Login.aspx")
            Else
                If Session("user_id").ToString = "adminbt" Then
                    getData()
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "hideUser();", True)
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script2", "mySetFunc2('carTravel');", True)
                ElseIf Session("user_id").ToString <> "" Then
                    getData2()
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "hideAdmin();", True)
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script2", "mySetFunc2('carTravel');", True)
                Else
                    Session.Clear()
                    Response.Redirect("~/Login.aspx")
                End If
            End If

            If Session("user_type") = "0" Then
                _name = "ส่วนทะเบียนรถยนต์ " & Session("admin_name")
            ElseIf Session("user_type") = "99" Then
                _name = Session("admin_name")
            Else
                _name = Session("user_type")
            End If
        Catch ex As Exception
            Session.Clear()
            Response.Redirect("~/Login.aspx")
        End Try
    End Sub


    Private Sub getData()
        Dim db As New DBConnect
        Try
            Dim CntCarWait1, CntCarWait2, CntCarWait3, CntCarWait4, CntCarWait5 As Double
            Dim strCount As String = "select count(distinct license_id) from license where status_id = 0 "
            CntCarWait1 = db.executeScalar(strCount & " and typeuser_id = 1 ")
            CntCarWait2 = db.executeScalar(strCount & " and typeuser_id = 2 ")
            CntCarWait3 = db.executeScalar(strCount & " and typeuser_id = 3 ")
            CntCarWait4 = db.executeScalar(strCount & " and typeuser_id = 4 ")
            'CntCarWait5 = db.executeScalar(strCount & " and typeuser_id = 5 ")
            If CntCarWait1 > 0 Then
                menu0.InnerHtml = "รายการรออนุมัติรถเข้ามาในราชอาณาจักร <span style='color:yellow;' ><b>(" & CntCarWait1 & " รายการ)</b></span>"
            Else
                menu0.Visible = False
            End If
            If CntCarWait2 > 0 Then
                menu0_2.InnerHtml = "รายการรออนุมัติรถเข้ามาในราชอาณาจักร <span style='color:yellow;' ><b>(" & CntCarWait2 & " รายการ)</b></span>"
            Else
                menu0_2.Visible = False
            End If
            If CntCarWait3 > 0 Then
                menu0_3.InnerHtml = "รายการรออนุมัติรถเข้ามาในราชอาณาจักร <span style='color:yellow;' ><b>(" & CntCarWait3 & " รายการ)</b></span>"
            Else
                menu0_3.Visible = False
            End If
            If CntCarWait4 > 0 Then
                menu0_4.InnerHtml = "รายการรออนุมัติรถเข้ามาในราชอาณาจักร <span style='color:yellow;' ><b>(" & CntCarWait4 & " รายการ)</b></span>"
            Else
                menu0_4.Visible = False
            End If

            menu0.HRef = "Admin/index.aspx?rt=1&st=0"
            menu0_2.HRef = "Admin/index.aspx?rt=2&st=0"
            menu0_3.HRef = "Admin/index.aspx?rt=3&st=0"
            menu0_4.HRef = "Admin/index.aspx?rt=4&st=0"
            'menu0_5.HRef = "Admin/index.aspx?rt=5&st=0"

            If Session("user_type") = "0" Then
                menu0_2.Visible = False
            End If

            Dim CntCarWait8 As Integer = db.executeScalar(" select count(distinct license_id) from license where status_id in (2,7,8) ")
            If CntCarWait8 = 0 Then
                menu3_3.Visible = False
            Else
                menu3_3.HRef = "Admin/arrival.aspx?rt=2&fail=1"
            End If
        Catch ex As Exception

        Finally
            db = Nothing
        End Try
    End Sub

    Private Sub getData2()
        Dim db As New DBConnect
        Try
            Dim CntCarWait1, CntCarWait2, CntCarWait3, CntCarWait4, CntCarWait5 As Double
            Dim strCount As String = "select count(distinct license_id) from license where status_id = 0 and admin_id = " & Session("admin_id")
            CntCarWait1 = db.executeScalar(strCount & " and typeuser_id = 1 ")
            CntCarWait2 = db.executeScalar(strCount & " and typeuser_id = 2 ")
            CntCarWait3 = db.executeScalar(strCount & " and typeuser_id = 3 ")
            CntCarWait4 = db.executeScalar(strCount & " and typeuser_id = 4 ")
            'CntCarWait5 = db.executeScalar(strCount & " and typeuser_id = 5 ")
            If CntCarWait1 > 0 Then
                menu0.InnerHtml = "รายการรออนุมัติรถเข้ามาในราชอาณาจักร <span style='color:yellow;' ><b>(" & CntCarWait1 & " รายการ)</b></span>"
            Else
                menu0.Visible = False
            End If
            If CntCarWait2 > 0 Then
                menu0_2.InnerHtml = "รายการรออนุมัติรถเข้ามาในราชอาณาจักร <span style='color:yellow;' ><b>(" & CntCarWait2 & " รายการ)</b></span>"
            Else
                menu0_2.Visible = False
            End If
            If CntCarWait3 > 0 Then
                menu0_3.InnerHtml = "รายการรออนุมัติรถเข้ามาในราชอาณาจักร <span style='color:yellow;' ><b>(" & CntCarWait3 & " รายการ)</b></span>"
            Else
                menu0_3.Visible = False
            End If
            If CntCarWait4 > 0 Then
                menu0_4.InnerHtml = "รายการรออนุมัติรถเข้ามาในราชอาณาจักร <span style='color:yellow;' ><b>(" & CntCarWait4 & " รายการ)</b></span>"
            Else
                menu0_4.Visible = False
            End If

 
            menu0.HRef = "Admin/index.aspx?rt=1&st=0"
            menu0_2.HRef = "Admin/index.aspx?rt=2&st=0"
            menu0_3.HRef = "Admin/index.aspx?rt=3&st=0"
            menu0_4.HRef = "Admin/index.aspx?rt=4&st=0"
            'menu0_5.HRef = "Admin/index.aspx?rt=5&st=0"


            If Session("user_type") = "0" Then
                menu0_2.Visible = False
            End If

            Dim CntCarWait8 As Integer = db.executeScalar(" select count(distinct license_id) from license where status_id in (2,7,8) and admin_id = " & Session("admin_id"))
            If CntCarWait8 = 0 Then
                menu3_3.Visible = False
            Else
                menu3_3.HRef = "Admin/arrival.aspx?rt=2&fail=1"
            End If
        Catch ex As Exception

        Finally
            db = Nothing
        End Try
    End Sub

End Class

