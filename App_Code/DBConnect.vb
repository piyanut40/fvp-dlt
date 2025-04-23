Imports System.Data
Imports System.Security.Cryptography
Imports Npgsql

Public Class DBConnect
    Private con As NpgsqlConnection


    '***********
    'constructor
    '***********
    Public Sub New()
        con = New NpgsqlConnection
        con.ConnectionString = getconstr()
    End Sub

    Public Sub New(ByVal constr As String)
        con = New NpgsqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings(constr).ConnectionString
    End Sub

    Sub Main()
        Dim connString As String = ConfigurationManager.ConnectionStrings("BorderTransport").ConnectionString

        If String.IsNullOrEmpty(connString) Then
            Console.WriteLine("ไม่พบ Connection String")
            Return
        End If

        Dim builder As New NpgsqlConnectionStringBuilder(connString)
        Console.WriteLine("Host: " & builder.Host)
        Console.WriteLine("Port: " & builder.Port)
        Console.WriteLine("User: " & builder.Username)
        Console.WriteLine("Password: " & builder.Password)
        Console.WriteLine("Database: " & builder.Database)

    End Sub

    Public Shared Function getconstr() As String
        Dim str As String = Nothing

        ' ตรวจสอบว่ามีการตั้งค่า "BorderTransport" ใน ConnectionStrings หรือไม่
        If ConfigurationManager.ConnectionStrings("BorderTransport") IsNot Nothing Then
            str = ConfigurationManager.ConnectionStrings("BorderTransport").ConnectionString
            Console.WriteLine(str)
        Else
            Console.WriteLine("Error: Connection string 'BorderTransport' not found.")
        End If

        Return str
        'Dim str As String = ConfigurationManager.ConnectionStrings("BorderTransport").ConnectionString
        'Console.WriteLine(str)
        'Return str
    End Function

    Public Shared Function getConnection() As NpgsqlConnection
        Return New NpgsqlConnection(getconstr())
    End Function

    Public Shared Function getConnection(ByVal constr As String) As NpgsqlConnection
        Return New NpgsqlConnection(ConfigurationManager.ConnectionStrings(constr).ConnectionString)
    End Function

    Public Shared Function getConnectionRouting() As NpgsqlConnection
        Return New NpgsqlConnection(ConfigurationManager.ConnectionStrings("TDSCRouting").ConnectionString)
    End Function

    Public Function getDataTable(ByVal tableName As String) As DataTable
        Dim localAdap As New NpgsqlDataAdapter
        Dim rtntable As New DataTable(tableName)
        localAdap.SelectCommand = New NpgsqlCommand("SELECT * FROM " & tableName, con)
        localAdap.Fill(rtntable)
        localAdap.Dispose()
        Return rtntable
    End Function

    Public Function TableCommand() As DataTable
        Dim Table As New DataTable
        With Table
            .Columns.Add("name")
            .Columns.Add("type")
            .Columns.Add("val")
        End With
        Return Table
    End Function

    Public Function UpdateDataTable(ByVal Data As DataTable, ByVal tableName As String, ByVal WHERE As String) As String
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = getConnection()
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            cmd.CommandText = "Update " & tableName & " set "
            cmd.Parameters.Clear()
            For Each crow In Data.Rows
                cmd.CommandText = cmd.CommandText & crow("name") & " = :" & crow("name")
                Dim name = crow("name")
                Dim val = IIf(crow("val").Trim = "", Nothing, crow("val"))
                Dim type = "NpgsqlTypes.NpgsqlDbType." & crow("type")
                cmd.Parameters.Add(name, type).Value = val
                cmd.CommandText = cmd.CommandText & ","
            Next
            cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1)
            cmd.CommandText = cmd.CommandText & " " & WHERE
            cmd.ExecuteNonQuery()
            Return ""
        Catch ex As Exception
            Return ex.ToString
        Finally
            cmd.Connection.Close()
            con.Close()
            cmd.Dispose()
            con.Dispose()
        End Try


    End Function

    Public Function InsertDataTable(ByVal Data As DataTable, ByVal tableName As String) As String
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = getConnection()
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            cmd.CommandText = "Insert INTO " & tableName & "("
            cmd.Parameters.Clear()
            For Each crow In Data.Rows
                cmd.CommandText = cmd.CommandText & crow("name")
                Dim name = crow("name")
                cmd.CommandText = cmd.CommandText & ","
            Next
            cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1)
            cmd.CommandText = cmd.CommandText & ") VALUES ( "

            For Each crow In Data.Rows
                cmd.CommandText = cmd.CommandText & ":" & crow("name")
                Dim name = crow("name")
                Dim val = IIf(crow("val").Trim = "", Nothing, crow("val"))
                Dim type = "NpgsqlTypes.NpgsqlDbType." & crow("type")
                cmd.Parameters.Add(name, type).Value = val
                cmd.CommandText = cmd.CommandText & ","
            Next
            cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1)
            cmd.CommandText = cmd.CommandText & ")"
            cmd.ExecuteNonQuery()
            Return ""
        Catch ex As Exception
            Return ex.ToString
        Finally
            cmd.Connection.Close()
            con.Close()
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Function InsertDataTableReturn(ByVal Data As DataTable, ByVal tableName As String, ByVal rtn As String) As String
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = getConnection()
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            cmd.CommandText = "Insert INTO " & tableName & "("
            cmd.Parameters.Clear()
            For Each crow In Data.Rows
                cmd.CommandText = cmd.CommandText & crow("name")
                Dim name = crow("name")
                cmd.CommandText = cmd.CommandText & ","
            Next
            cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1)
            cmd.CommandText = cmd.CommandText & ") VALUES ( "

            For Each crow In Data.Rows
                cmd.CommandText = cmd.CommandText & ":" & crow("name")
                Dim name = crow("name")
                Dim val = IIf(crow("val").Trim = "", Nothing, crow("val"))
                Dim type = "NpgsqlTypes.NpgsqlDbType." & crow("type")
                cmd.Parameters.Add(name, type).Value = val
                cmd.CommandText = cmd.CommandText & ","
            Next
            cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1)
            cmd.CommandText = cmd.CommandText & ") RETURNING " & rtn & ""
            Dim id = cmd.ExecuteScalar()
            Return id
        Catch ex As Exception
            Return ex.ToString
        Finally
            cmd.Connection.Close()
            con.Close()
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Function DeleteDataTable(ByVal tableName As String, ByVal WHERE As String) As String
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = getConnection()
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            cmd.CommandText = "DELETE From  " & tableName & " " & WHERE
            cmd.ExecuteNonQuery()
            Return ""
        Catch ex As Exception
            Return ex.ToString
        Finally
            cmd.Connection.Close()
            con.Close()
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function

    'Public Function ReadDataTable(ByVal str As String) As DataTable
    '    Dim cmd As New NpgsqlCommand
    '    Dim con As Npgsql.NpgsqlConnection = getConnection()

    '    Dim dt As New DataTable
    '    Try
    '        Dim version As String = con.PostgreSqlVersion.ToString()
    '        Console.WriteLine("PostgreSQL Version: " & version)
    '        con.Open()
    '        cmd.Connection = con
    '        cmd.CommandText = CommandType.Text
    '        cmd.CommandText = str
    '        dt.Load(cmd.ExecuteReader())
    '        If dt.Columns.Count > 0 Then
    '            Return dt
    '        Else
    '            Return Nothing
    '        End If
    '    Catch ex As Exception
    '        Console.WriteLine("Connection Failed: " & ex.Message)

    '        Return Nothing
    '    Finally
    '        cmd.Connection.Close()
    '        con.Close()
    '    End Try
    'End Function
    Public Function ReadDataTable(ByVal str As String) As DataTable
        Using con As NpgsqlConnection = getConnection(),
          cmd As New NpgsqlCommand(str, con)

            Dim dt As New DataTable
            Try
                Console.WriteLine("กำลังเปิดการเชื่อมต่อฐานข้อมูล...")
                con.Open()
                Console.WriteLine("เชื่อมต่อสำเร็จ! กำลังรันคำสั่ง SQL: " & str)

                dt.Load(cmd.ExecuteReader())

                If dt.Columns.Count > 0 Then
                    Console.WriteLine("ดึงข้อมูลสำเร็จ! จำนวนคอลัมน์: " & dt.Columns.Count)
                    Return dt
                Else
                    Console.WriteLine("ไม่มีข้อมูลที่ได้รับจากฐานข้อมูล")
                    Return Nothing
                End If
            Catch ex As Exception
                Console.WriteLine("เกิดข้อผิดพลาด: " & ex.Message)
                Return Nothing
            End Try
        End Using
    End Function


    Public Function ReadDataTabletest(ByVal str As String) As DataTable
        Dim cmd As New NpgsqlCommand
        'System.Web.HttpContext.Current.Response.Write("<br /> 2. New NpgsqlCommand")
        Dim con As Npgsql.NpgsqlConnection = getConnection()
        'System.Web.HttpContext.Current.Response.Write("<br /> 3. getConnection")
        Dim dt As New DataTable
        Try
            'System.Web.HttpContext.Current.Response.Write("<br /> 4. New DataTable")
            con.Open()
            'System.Web.HttpContext.Current.Response.Write("<br /> 5. con.Open()")
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            cmd.CommandText = str
            'System.Web.HttpContext.Current.Response.Write("<br /> 6. cmd.CommandText")
            dt.Load(cmd.ExecuteReader())
            'System.Web.HttpContext.Current.Response.Write("<br /> 7. cmd.ExecuteReader")
            If dt.Columns.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'System.Web.HttpContext.Current.Response.Write("<br /> 9. ReadDataTable Error " & ex.Message.ToString)
            Return Nothing
        Finally
            cmd.Connection.Close()
            con.Close()
        End Try
    End Function

    Public Function getDataTableRoute(ByVal qry As String, ByVal tableName As String) As DataTable
        Try
            Dim localAdap As New NpgsqlDataAdapter
            Dim rtntable As New DataTable(tableName)
            localAdap.SelectCommand = New NpgsqlCommand(qry, getConnectionRouting)
            localAdap.Fill(rtntable)
            localAdap.Dispose()
            Return rtntable
        Catch ex As Exception
            If ex.Message.IndexOf("22P02") > 0 Then
                Return Nothing
                'Response.Redirect("Login.aspx")
            End If
        End Try

    End Function

    Public Function getDataTable(ByVal qry As String, ByVal tableName As String) As DataTable
        Try
            Dim localAdap As New NpgsqlDataAdapter
            Dim rtntable As New DataTable(tableName)
            localAdap.SelectCommand = New NpgsqlCommand(qry, con)
            localAdap.Fill(rtntable)
            localAdap.Dispose()
            Return rtntable
        Catch ex As Exception
            If ex.Message.IndexOf("22P02") > 0 Then
                Return Nothing
                'Response.Redirect("Login.aspx")
            End If
        End Try

    End Function
    'Public Function getDataTable(ByVal qry As String, ByVal tableName As String) As DataTable
    '    Try
    '        ' ✅ แสดง SQL Query ที่กำลังรัน
    '        HttpContext.Current.Response.Write("✅ Executing SQL: " & qry & "<br>")

    '        ' ✅ ตรวจสอบว่า Connection มีค่าหรือไม่
    '        If con Is Nothing Then
    '            HttpContext.Current.Response.Write("❌ Error: Connection = Nothing <br>")
    '            Return Nothing
    '        End If

    '        ' ✅ ตรวจสอบสถานะ Connection
    '        If con.State <> ConnectionState.Open Then
    '            HttpContext.Current.Response.Write("❌ Error: Connection ไม่ได้เปิด <br>")
    '            con.Open()
    '            If con.State <> ConnectionState.Open Then
    '                HttpContext.Current.Response.Write("❌ Error: เปิด Connection ไม่สำเร็จ <br>")
    '                Return Nothing
    '            End If
    '            HttpContext.Current.Response.Write("✅ Connection เปิดสำเร็จ <br>")
    '        End If

    '        ' ✅ เตรียม Adapter และ DataTable
    '        Dim localAdap As New NpgsqlDataAdapter
    '        Dim rtntable As New DataTable(tableName)

    '        ' ✅ ตรวจสอบว่ากำลังสร้าง Command หรือไม่
    '        HttpContext.Current.Response.Write("✅ Creating SQL Command... <br>")
    '        localAdap.SelectCommand = New NpgsqlCommand(qry, con)

    '        ' ✅ ลอง Fill DataTable
    '        HttpContext.Current.Response.Write("✅ Filling DataTable... <br>")
    '        localAdap.Fill(rtntable)

    '        ' ✅ ตรวจสอบผลลัพธ์
    '        If rtntable Is Nothing Then
    '            HttpContext.Current.Response.Write("❌ Error: DataTable = Nothing <br>")
    '            Return Nothing
    '        End If

    '        If rtntable.Rows.Count = 0 Then
    '            HttpContext.Current.Response.Write("❌ Error: DataTable ไม่มีข้อมูล (Rows.Count = 0) <br>")
    '            Return Nothing
    '        End If

    '        ' ✅ คืนค่า DataTable ปกติ
    '        HttpContext.Current.Response.Write("✅ ดึงข้อมูลสำเร็จ! พบ " & rtntable.Rows.Count & " แถว <br>")
    '        Return rtntable

    '    Catch ex As Exception
    '        ' ✅ Debug ข้อผิดพลาด
    '        HttpContext.Current.Response.Write("❌ Exception: " & ex.Message & "<br>")

    '        ' ✅ เช็ค Error Code 22P02 (Invalid Text Representation)
    '        If ex.Message.IndexOf("22P02") > 0 Then
    '            HttpContext.Current.Response.Write("❌ Error: Invalid Text Representation (22P02) <br>")
    '            Return Nothing
    '        End If

    '        Return Nothing
    '    Finally
    '        ' ✅ ปิด Adapter
    '        HttpContext.Current.Response.Write("✅ Disposing Adapter... <br>")
    '    End Try
    'End Function


    Public Function getDataTabletest(ByVal qry As String, ByVal tableName As String) As DataTable
        Try
            Dim localAdap As New NpgsqlDataAdapter
            'System.Web.HttpContext.Current.Response.Write("<br /> 2. New NpgsqlDataAdapter")
            Dim rtntable As New DataTable(tableName)
            'System.Web.HttpContext.Current.Response.Write("<br /> 3. New NpgsqlCommand")
            localAdap.SelectCommand = New NpgsqlCommand(qry, con)
            'System.Web.HttpContext.Current.Response.Write("<br /> 4. SelectCommand")
            localAdap.Fill(rtntable)
            'System.Web.HttpContext.Current.Response.Write("<br /> 5. localAdap.Fill")
            localAdap.Dispose()
            'System.Web.HttpContext.Current.Response.Write("<br /> 6. localAdap.Dispose")
            Return rtntable
        Catch ex As Exception
            'System.Web.HttpContext.Current.Response.Write("<br /> 7. getDataTable Error " & ex.Message.ToString)
            If ex.Message.IndexOf("22P02") > 0 Then
                Return Nothing
                'Response.Redirect("Login.aspx")
            End If
        End Try

    End Function

    Public Function getDataSchema(ByVal tableName As String) As DataTable
        Dim localAdap As New NpgsqlDataAdapter
        Dim rtntable As New DataTable(tableName)
        localAdap.SelectCommand = New NpgsqlCommand("SELECT * FROM " & tableName, con)
        localAdap.FillSchema(rtntable, SchemaType.Mapped)
        localAdap.Dispose()
        Return rtntable

    End Function

    Public Function getDataSchema(ByVal qry As String, ByVal tableName As String) As DataTable
        Dim localAdap As New NpgsqlDataAdapter
        Dim rtntable As New DataTable(tableName)
        localAdap.SelectCommand = New NpgsqlCommand(qry, con)
        localAdap.FillSchema(rtntable, SchemaType.Mapped)
        localAdap.Dispose()
        Return rtntable

    End Function

    Public Function getDataSet(ByVal qry As String, ByVal tableName As String) As DataSet
        Dim localAdap As New NpgsqlDataAdapter
        Dim rtnDS As New DataSet
        localAdap.SelectCommand = New NpgsqlCommand(qry, con)
        localAdap.Fill(rtnDS, tableName)
        localAdap.Dispose()
        Return rtnDS
    End Function

    Public Function executeScalar(ByVal qry As String) As String
        con.Open()
        Dim cmd As New NpgsqlCommand
        cmd.CommandText = qry
        cmd.Connection = con
        Try
            Dim obj As Object = cmd.ExecuteScalar
            If obj Is Nothing Then
                Return ""
            Else
                Return obj.ToString
            End If

        Catch ex As System.Exception
            Return ""
        Finally
            con.Close()
        End Try

    End Function
    Public Shared Function password(ByVal s1 As String, ByVal s2 As String) As Integer
        Return (s1 & "*/*" & s2).GetHashCode
    End Function

    Public Shared Function Token(ByVal s1 As String, ByVal s2 As String) As String
        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(s1 & s2))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using
    End Function

    Public Shared Function TokenGuide(ByVal s1 As String, ByVal s2 As String, ByVal s3 As String) As String
        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(s1 & s2 & s3))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using
    End Function

    Public Shared Function qrcode(ByVal token As String, ByVal rt As String) As String
        Dim qrurl As String = "https://api.qrserver.com/v1/create-qr-code/?size=300x300&data="
        Dim mainUrl As String = HttpContext.Current.Request.Url.Host & "/Report/ViewData.aspx?rt="
        Dim data As String = mainUrl & rt & "%26token=" & token

        Return data

    End Function

    Public Shared Function licenseNo(ByVal admin_id As Integer) As String
        Dim sqlstr As String
        Dim DBconnect As New DBConnect
        sqlstr = " SELECT license_id from ( select max(SUBSTRING(license_no,5,5)) as license_id , MAX(SUBSTRING(license_no,11,4)) as yearid  " &
                 " FROM license where admin_id = " & admin_id & " ) as dt WHERE yearid like '%" & Now.Year + 543 & "%' "
        Dim sqlstrABB_no = "select abb_en from province " &
                          " LEFT JOIN admin on admin.prov_code = province.prov_code " &
                          " WHERE admin_id = " & admin_id & " "
        Dim license_no As String = ""
        Dim no As Integer
        Dim check As String
        check = DBconnect.executeScalar(sqlstr)
        If check = "" Then
            check = 0
        End If
        no = check
        no = no + 1
        Dim length As Integer
        length = no.ToString.Length

        Dim abb_no As String = DBconnect.executeScalar(sqlstrABB_no)
        If length = 1 Then
            license_no = "0000" & no & "/" & Now.Year + 543
        ElseIf length = 2 Then
            license_no = "000" & no & "/" & Now.Year + 543
        ElseIf length = 3 Then
            license_no = "00" & no & "/" & Now.Year + 543
        ElseIf length = 4 Then
            license_no = "0" & no & "/" & Now.Year + 543
        ElseIf length = 5 Then
            license_no = "" & no & "/" & Now.Year + 543
        End If

        license_no = abb_no & "/" & license_no
        Return license_no.ToString

    End Function

    Public Shared Function licenseNo(ByVal admin_id As Integer, ByVal license_id As Integer) As String

        Dim sqlstr As String
        Dim DBconnect As New DBConnect


        sqlstr = "select max(SUBSTRING(license_no,5,5)) as license_id  FROM license where admin_id = " & admin_id & " and license_id <> " & license_id & " and SUBSTRING(license_no,11,4) like '%" & Now.Year + 543 & "%' "

        Dim sqlstrABB_no = "select abb_en from province " & _
                          " LEFT JOIN admin on admin.prov_code = province.prov_code " & _
                          " WHERE admin_id = " & admin_id & " "
        Dim license_no As String = ""
        Dim no As Integer
        Dim check As String
        check = DBconnect.executeScalar(sqlstr)
        If check = "" Then
            check = 0
        End If
        no = check
        no = no + 1
        Dim length As Integer
        length = no.ToString.Length

        Dim abb_no As String = DBconnect.executeScalar(sqlstrABB_no)
        If length = 1 Then
            license_no = "0000" & no & "/" & Now.Year + 543
        ElseIf length = 2 Then
            license_no = "000" & no & "/" & Now.Year + 543
        ElseIf length = 3 Then
            license_no = "00" & no & "/" & Now.Year + 543
        ElseIf length = 4 Then
            license_no = "0" & no & "/" & Now.Year + 543
        ElseIf length = 5 Then
            license_no = "" & no & "/" & Now.Year + 543
        End If

        license_no = abb_no & "/" & license_no
        Return license_no.ToString

    End Function

    Public Shared Function RegisterNo() As String
        Dim sqlstr As String
        Dim DBconnect As New DBConnect
        sqlstr = "select max(substring(regis_no,0,8)) as regis_no from license " & _
                     " WHERE substring(regis_no,9,4) like '%" & Now.Year + 543 & "%'"
        Dim license_no As String = ""
        Dim no As Integer
        Dim check As String
        check = DBconnect.executeScalar(sqlstr)
        If check = "" Then
            check = 0
        End If
        no = check
        no = no + 1
        Dim length As Integer
        length = no.ToString.Length

        If length = 1 Then
            license_no = "000000" & no & "/" & Now.Year + 543
        ElseIf length = 2 Then
            license_no = "00000" & no & "/" & Now.Year + 543
        ElseIf length = 3 Then
            license_no = "0000" & no & "/" & Now.Year + 543
        ElseIf length = 4 Then
            license_no = "000" & no & "/" & Now.Year + 543
        ElseIf length = 5 Then
            license_no = "00" & no & "/" & Now.Year + 543
        ElseIf length = 6 Then
            license_no = "0" & no & "/" & Now.Year + 543
        ElseIf length = 7 Then
            license_no = "" & no & "/" & Now.Year + 543
        End If
        Return license_no.ToString

    End Function


    Public Shared Function GroupNo() As String
        Dim sqlstr As String
        Dim DBconnect As New DBConnect
        sqlstr = " select max(substring(license_group,2,7)) as regis_no from travel_group " &
                 " WHERE  substring(license_group,10,4)  like '%" & Now.Year + 543 & "%' "
        Dim license_no As String = ""
        Dim no As Integer
        Dim check As String
        check = DBconnect.executeScalar(sqlstr)
        If check = "" Then
            check = 0
        End If
        no = check
        no = no + 1
        Dim length As Integer
        length = no.ToString.Length

        If length = 1 Then
            license_no = "T000000" & no & "/" & Now.Year + 543
        ElseIf length = 2 Then
            license_no = "T00000" & no & "/" & Now.Year + 543
        ElseIf length = 3 Then
            license_no = "T0000" & no & "/" & Now.Year + 543
        ElseIf length = 4 Then
            license_no = "T000" & no & "/" & Now.Year + 543
        ElseIf length = 5 Then
            license_no = "T00" & no & "/" & Now.Year + 543
        ElseIf length = 6 Then
            license_no = "T0" & no & "/" & Now.Year + 543
        ElseIf length = 7 Then
            license_no = "T" & no & "/" & Now.Year + 543
        End If
        Return license_no.ToString

    End Function
    Private conn As NpgsqlConnection


    Public Sub CloseConnection()
        If conn IsNot Nothing AndAlso conn.State <> ConnectionState.Closed Then
            conn.Close()
        End If
    End Sub


End Class
