Imports System.Data
Imports Npgsql

Partial Class MasterPageC
    Inherits System.Web.UI.MasterPage
    Protected name As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user_id") = Nothing Then
            Response.Redirect("~/Login.aspx")
        Else
            If Session("name") = "" Then
                Dim dbConnect As New DBConnect
                Dim cmd As New NpgsqlCommand
                Dim con As Npgsql.NpgsqlConnection

                If Session("login") = "" Then
                    Try
                        con = dbConnect.getConnection
                        con.Open()

                        cmd.Connection = con
                        cmd.CommandType = CommandType.Text

                        If Session("user_type") = 1 Then
                            Dim str As String
                            str = " select distinct fname , lname  from license " & _
                                  " LEFT JOIN user_cus on license.email = user_cus.username " & _
                                  " WHERE user_cus.user_id = '" & Session("user_id") & "' "
                            cmd.CommandText = str
                            Dim dr As NpgsqlDataReader
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                Session("name") = dr("fname")
                                Session("surname") = dr("lname")
                                Session("photo") = "businessman.png" 'dr("photo_user")
                                Session("login") = 1
                                'Session("typeuser_id") = dr("typeuser_id")
                                dr.Close()
                            End If
                            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "tourDis();", True)
                        Else
                            Dim str As String
                            'str = "select user_name , user_surname , photo_user  from user_travel WHERE user_id = '" & Session("user_id") & "' "
                            str = "select user_name , user_surname  from user_travel WHERE user_id = '" & Session("user_id") & "' "
                            cmd.CommandText = str
                            Dim dr As NpgsqlDataReader
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                Session("name") = dr("user_name")
                                Session("surname") = dr("user_surname")
                                Session("photo") = "businessman.png" 'dr("photo_user")
                                Session("login") = 2
                                Session("typeuser_id") = 2
                                dr.Close()
                            End If
                        End If

                    Catch ex As Exception
                        Session.Clear()
                        Response.Redirect("~/Login.aspx")
                    Finally
                        cmd.Connection.Close()
                        con.Close()
                        dbConnect = Nothing
                    End Try
                End If
            End If
            If Session("user_type") = 1 Then
                'รถประจำถิ่น
                name = Session("name") & " " & Session("surname")
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "tourDis();", True)
                linkEdit.NavigateUrl = "Local/EditUser.aspx"
                UserTravel.Visible = False
                'lnkManual.Visible = False
            Else
                'รถท่องเที่ยว
                name = Session("name_company")
                linkEdit.NavigateUrl = "Travel/EditTravel.aspx"

                lnkUserTravel.HRef = "Travel/EditUserTravel.aspx"
                lnkGroupAll.HRef = "Travel/Group.aspx"
                lnkGroup.HRef = "Travel/Group.aspx?status=1"
                lnkGroup0.HRef = "Travel/Group.aspx?status=2"
                lnkGroup2.HRef = "Travel/Group.aspx?status=5"
                lnkGuide.HRef = "Travel/Guide.aspx"
                getData()
            End If

        End If

    End Sub
    Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Session.Clear()
        Response.Redirect("../Login.aspx")
    End Sub


    Private Sub getData()
        Dim db As New DBConnect
        Try
            Dim CntGroup, CntGroupPendings, CntGroupPendings0, CntGroupSuccess As Double
            Dim strGroupSuccess As String = " SELECT count(group_id) FROM ( SELECT   travel_group.group_id ,  (select * from (select count(status_id) from license LEFT JOIN travel_group_car on license.license_id = travel_group_car.license_id  WHERE travel_group_car.group_id = travel_group.group_id and  (status_id = 1 or status_id = 0 or status_id = 5)) as a) as active  " & _
            "	FROM travel_group  where user_id = " & Session("user_id") & " ) as dt "
            CntGroup = db.executeScalar(strGroupSuccess)
            If CntGroup > 0 Then
                lnkGroupAll.InnerHtml = "&nbsp; Tour Group All <b> (" & CntGroup & " รายการ)</b> " '"  - Success <span style='color:#5EFB6E;' ><b> (" & CntGroupSuccess & " รายการ)</b></span>"
            End If

           
            Dim strGroupPendings As String = " SELECT count(group_id) FROM ( SELECT   travel_group.group_id ,  (select * from (select count(status_id) from license LEFT JOIN travel_group_car on license.license_id = travel_group_car.license_id  WHERE travel_group_car.group_id = travel_group.group_id and  (status_id = 1 or status_id = 0)) as a) as active  " & _
            "	FROM travel_group  where user_id = " & Session("user_id") & " ) as dt "
            CntGroupPendings = db.executeScalar(strGroupPendings & " where active > 0 ")
            If CntGroupPendings > 0 Then
                lnkGroup.InnerHtml = "&nbsp; Tour Group Pendings <b> (" & CntGroupPendings & " รายการ)</b> " '"  - Success <span style='color:#5EFB6E;' ><b> (" & CntGroupSuccess & " รายการ)</b></span>"
            Else
                lnkGroup.Visible = False
            End If



            Dim strGroupPendings0 As String = " SELECT count(group_id) FROM ( SELECT   travel_group.group_id ,  (select * from (select count(status_id) from license LEFT JOIN travel_group_car on license.license_id = travel_group_car.license_id  WHERE travel_group_car.group_id = travel_group.group_id and  (status_id = 2)) as a) as active  " & _
            "	FROM travel_group  where user_id = " & Session("user_id") & " ) as dt "
            CntGroupPendings0 = db.executeScalar(strGroupPendings0 & " where active > 0 ")
            If CntGroupPendings0 > 0 Then
                lnkGroup0.InnerHtml = "&nbsp; Tour Group Incomplete <b> (" & CntGroupPendings0 & " รายการ)</b> " '"  - Success <span style='color:#5EFB6E;' ><b> (" & CntGroupSuccess & " รายการ)</b></span>"
            Else
                lnkGroup0.Visible = False
            End If

            strGroupSuccess = " SELECT count(group_id) FROM ( SELECT   travel_group.group_id ,  (select * from (select count(status_id) from license LEFT JOIN travel_group_car on license.license_id = travel_group_car.license_id  WHERE travel_group_car.group_id = travel_group.group_id and  (status_id = 5)) as a) as active  " & _
            "	FROM travel_group  where user_id = " & Session("user_id") & _
            " and  travel_group.group_id  not in ( select distinct travel_group_car.group_id  from license  inner JOIN travel_group_car on license.license_id = travel_group_car.license_id  " & _
            " WHERE (status_id in (4,7,8,9) ))  ) as dt "
            CntGroupSuccess = db.executeScalar(strGroupSuccess & " where active > 0 ")
            If CntGroupSuccess > 0 Then
                lnkGroup2.InnerHtml = "&nbsp; Tour Group Success <b> (" & CntGroupSuccess & " รายการ)</b> " '"  - Success <span style='color:#5EFB6E;' ><b> (" & CntGroupSuccess & " รายการ)</b></span>"
            Else
                lnkGroup2.Visible = False
            End If

            If Not lnkGroup.Visible And Not lnkGroup2.Visible Then
                lnkGroupNo.HRef = "Travel/Group.aspx"
                If CntGroup > 0 Then
                    lnkGroupNo.InnerHtml = "Tour Group <b> (" & CntGroup & " รายการ)</b> "
                End If
                lnkGroupAll.Visible = False
            Else
                lnkGroupNo.HRef = "Travel/Group.aspx"
            End If

            Dim Cntguide As Double
            Dim strguide As String = " SELECT count(guide_id)  FROM guide  where travel_user_id = " & Session("user_id") & " "
            Cntguide = db.executeScalar(strguide)
            If Cntguide > 0 Then
                lnkGuide.InnerHtml = " Tour Leader or Assistant <b> (" & Cntguide & " รายการ) </b> "
            End If


        Catch ex As Exception

        Finally
            db = Nothing
        End Try
    End Sub
End Class

