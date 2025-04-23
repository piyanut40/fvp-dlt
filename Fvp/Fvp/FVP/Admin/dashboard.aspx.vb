
Partial Class Admin_Dashboard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dbconnect As New DBConnect
        If Session("user_id") = "adminbt" Then
            pnAdmin.Visible = True
            Dim qryString As String = " Select * from (VALUES( " & _
                             " (select count(license_id) from license " & _
                             " WHERE status_id = 0 and typeuser_id = 2) ," & _
                             " (select count(license_id) from license " & _
                             " WHERE status_id in(1,3) and typeuser_id = 2) , " & _
                             " (select count(license_id) from license " & _
                             " WHERE status_id = 5 and typeuser_id = 2) , " & _
                             " (select count(license_id) from license " & _
                             " WHERE typeuser_id = 2 and status_id in (1,3,5)) ," & _
                             " (select count(*) from user_travel WHERE is_active = 0)," & _
                             " (select count(*) from user_travel WHERE is_active = 1)," & _
                             " (select count(*) from border_check)," & _
                             " (select count(*) from condition_rule) " & _
                             " )) as dt(wait1,wait2,wait3,wait4,tourwait,tourall,bc,conr) "

            Dim a = dbconnect.ReadDataTable(qryString)

            lblTourWait1.Text = a.Rows(0).Item("wait1")
            lblTourWait2.Text = a.Rows(0).Item("wait2")
            lblTourWait3.Text = a.Rows(0).Item("wait3")
            lblTourWait4.Text = a.Rows(0).Item("wait4")
            lblTourWait.Text = a.Rows(0).Item("tourwait")
            lblTourAll.Text = a.Rows(0).Item("tourall")
            lblBorder.Text = a.Rows(0).Item("bc")
            lblCon.Text = a.Rows(0).Item("conr")
        ElseIf Session("admin_id") Then
            Dim admin_id = Session("admin_id")
            pnTransport.Visible = True

            'มันต้องเปลี่ยนไปดึงจากตาราง group สิ
            Dim strWhereAdmin As String = " and license_id in (select license_id from travel_group_car LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id where admin_id = " & admin_id & ") " '"and admin_id = " & admin_id & ""

            Dim qryString As String = " Select * from (VALUES( " & _
                             " (select count(license_id) from license " & _
                             " WHERE status_id = 0 and typeuser_id = 2 " & strWhereAdmin & ") ," & _
                             " (select count(license_id) from license " & _
                             " WHERE status_id in(1,3) and typeuser_id = 2 " & strWhereAdmin & ") , " & _
                             " (select count(license_id) from license " & _
                             " WHERE status_id = 5 and typeuser_id = 2 " & strWhereAdmin & ") , " & _
                             " (select count(license_id) from license " & _
                             " WHERE typeuser_id = 2 " & strWhereAdmin & " and status_id in (1,3,5) ) " & _
                             " )) as dt(wait1,wait2,wait3,wait4) "
            Dim a = dbconnect.ReadDataTable(qryString)
            lblATourWait1.Text = a.Rows(0).Item("wait1")

            lblATourWait2.Text = a.Rows(0).Item("wait2")

            lblATourWait3.Text = a.Rows(0).Item("wait3")

            lblATourWait4.Text = a.Rows(0).Item("wait4")

            If Session("user_type") = "0" Then
                officer.Visible = False
            End If
        Else
            Session.Clear()
        End If

    End Sub
End Class
