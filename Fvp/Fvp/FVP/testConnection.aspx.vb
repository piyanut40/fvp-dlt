Imports System.Data
Imports Npgsql

Partial Class testConnection
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Write("<br /> -------------------- getDataTable --------------------------- ")

        Dim dbconect As New DBConnect
        Response.Write("<br /> 1. New DBConnect ")
        Try
            Dim Dt As DataTable = dbconect.getDataTabletest(TextBox1.Text, "data1")
            Response.Write("<br /> 7. getDataTable สำเร็จ " & Dt.Rows.Count & " รายการ ")
        Catch ex As Exception
            Response.Write("<br /> 7. getDataTable Error " & ex.Message.ToString)
        Finally
            dbconect = Nothing
        End Try
        Response.Write("<br /> &nbsp;&nbsp; ")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Write("<br /> -------------------- ReadDataTable โค้ดใหม่ By.ท๊อป --------------------------- ")

        Dim dbconect As New DBConnect
        Response.Write("<br /> 1. New DBConnect ")
        Try
            Dim Dt As DataTable = dbconect.ReadDataTabletest(TextBox2.Text)
            Response.Write("<br /> 8. ReadDataTable สำเร็จ " & Dt.Rows.Count & " รายการ ")
        Catch ex As Exception
            Response.Write("<br /> 8. ReadDataTable Error " & ex.Message.ToString)
        Finally
            dbconect = Nothing
        End Try
        Response.Write("<br /> &nbsp;&nbsp; ")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Write("<br /> -------------------- ExecuteReader --------------------------- ")
        Dim cmd As New NpgsqlCommand
        Response.Write("<br /> 1. New NpgsqlCommand ")
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Response.Write("<br /> 2. getConnection ")
        Try
            con.ClearPool()
            cmd.Connection = con
            cmd.Connection.Open()
            Response.Write("<br /> 3. Connection.Open() ")
            cmd.CommandText = TextBox3.Text
            Dim dr As NpgsqlDataReader
            dr = cmd.ExecuteReader
            Response.Write("<br /> 4. cmd.ExecuteReader ")
            While dr.Read
                Response.Write("<br /> &nbsp;&nbsp;&nbsp;&nbsp; - status_id = " & dr("status_id"))
            End While
            dr.Close()
            Response.Write("<br /> 5. ExecuteReader สำเร็จ ")
        Catch ex As Exception
            Response.Write("<br /> 5. ExecuteReader Error " & ex.Message.ToString)
        Finally
            cmd.Connection.Close()
            con = Nothing
        End Try
        Response.Write("<br /> &nbsp;&nbsp; ")
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Response.Write("<br /> -------------------- ExecuteScalar adminbt --------------------------- ")
        getData()
        Response.Write("<br /> &nbsp;&nbsp; ")
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Response.Write("<br /> -------------------- ExecuteScalar ขนส่งจังหวัด --------------------------- ")
        getData2()
        Response.Write("<br /> &nbsp;&nbsp; ")
    End Sub

    Private Sub getData()
        Dim db As New DBConnect
        Try
            Dim CntCarWait1, CntCarWait2, CntCarWait3, CntCarWait4, CntCarWait5 As Double
            Dim strCount As String = "select count(distinct license_id) from license where status_id = 0 "
            CntCarWait1 = db.executeScalar(strCount & " and typeuser_id = 1 ")
            Response.Write("<br /> 1. get typeuser_id 1 = " & CntCarWait1)
            CntCarWait2 = db.executeScalar(strCount & " and typeuser_id = 2 ")
            Response.Write("<br /> 2. get typeuser_id 2 = " & CntCarWait2)
            CntCarWait3 = db.executeScalar(strCount & " and typeuser_id = 3 ")
            Response.Write("<br /> 3. get typeuser_id 3 = " & CntCarWait3)
            CntCarWait4 = db.executeScalar(strCount & " and typeuser_id = 4 ")
            Response.Write("<br /> 4. get typeuser_id 4 = " & CntCarWait4)
           
        Catch ex As Exception

        Finally
            db = Nothing
        End Try
    End Sub

    Private Sub getData2()
        Dim db As New DBConnect
        Try
            Dim CntCarWait1, CntCarWait2, CntCarWait3, CntCarWait4, CntCarWait5 As Double
            Dim strCount As String = "select count(distinct license_id) from license where status_id = 0 and admin_id = " & 11 'Session("admin_id")
            CntCarWait1 = db.executeScalar(strCount & " and typeuser_id = 1 ")
            Response.Write("<br /> 1. get typeuser_id 1 = " & CntCarWait1)
            CntCarWait2 = db.executeScalar(strCount & " and typeuser_id = 2 ")
            Response.Write("<br /> 2. get typeuser_id 2 = " & CntCarWait2)
            CntCarWait3 = db.executeScalar(strCount & " and typeuser_id = 3 ")
            Response.Write("<br /> 3. get typeuser_id 3 = " & CntCarWait3)
            CntCarWait4 = db.executeScalar(strCount & " and typeuser_id = 4 ")
            Response.Write("<br /> 4. get typeuser_id 4 = " & CntCarWait4)
          
        Catch ex As Exception

        Finally
            db = Nothing
        End Try
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim dbconect As New DBConnect
        'Response.Write("<br /> 1. New DBConnect ")
        Try
            Dim Dt As DataTable = dbconect.getDataTable(TextBox4.Text, "data1")
            GridView1.DataSource = Dt
            GridView1.DataBind()
            'Response.Write("<br /> 7. getDataTable สำเร็จ " & Dt.Rows.Count & " รายการ ")
        Catch ex As Exception
            Response.Write("<br /> Error " & ex.Message.ToString)
        Finally
            dbconect = Nothing
        End Try
        Response.Write("<br /> &nbsp;&nbsp; ")
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim dbconect As New DBConnect
        'Response.Write("<br /> 1. New DBConnect ")
        Try
            Dim Dt As DataTable = dbconect.getDataTable(TextBox5.Text, "data1")
            GridView1.DataSource = Dt
            GridView1.DataBind()
            'Response.Write("<br /> 7. getDataTable สำเร็จ " & Dt.Rows.Count & " รายการ ")
        Catch ex As Exception
            Response.Write("<br /> Error " & ex.Message.ToString)
        Finally
            dbconect = Nothing
        End Try
        Response.Write("<br /> &nbsp;&nbsp; ")
    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim dbconect As New DBConnect
        'Response.Write("<br /> 1. New DBConnect ")
        Try
            Dim Dt As DataTable = dbconect.getDataTable(TextBox6.Text, "data1")
            GridView1.DataSource = Dt
            GridView1.DataBind()
            'Response.Write("<br /> 7. getDataTable สำเร็จ " & Dt.Rows.Count & " รายการ ")
        Catch ex As Exception
            Response.Write("<br /> Error " & ex.Message.ToString)
        Finally
            dbconect = Nothing
        End Try
        Response.Write("<br /> &nbsp;&nbsp; ")
    End Sub

    Protected Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim dbconect As New DBConnect
        'Response.Write("<br /> 1. New DBConnect ")
        Try
            Dim newpass As String = DBConnect.password(TextBox9.Text, TextBox9.Text)

            Response.Write("<br /> Gen pass สำเร็จ password : " & newpass)
        Catch ex As Exception
            Response.Write("<br /> Error " & ex.Message.ToString)
        Finally
            dbconect = Nothing
        End Try
        Response.Write("<br /> &nbsp;&nbsp; ")
    End Sub
End Class
