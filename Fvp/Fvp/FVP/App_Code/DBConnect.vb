Imports Npgsql
Imports System.Configuration
Imports System.Data
Imports System.Security.Cryptography

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

    Public Shared Function getconstr() As String
        Dim str As String = ConfigurationManager.ConnectionStrings("BorderTransport").ConnectionString
        Return str
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

    Public Function ReadDataTable(ByVal str As String) As DataTable
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = getConnection()
        Dim dt As New DataTable
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            cmd.CommandText = str
            dt.Load(cmd.ExecuteReader())
            If dt.Columns.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            cmd.Connection.Close()
            con.Close()
        End Try
    End Function

    Public Function ReadDataTabletest(ByVal str As String) As DataTable
        Dim cmd As New NpgsqlCommand
        System.Web.HttpContext.Current.Response.Write("<br /> 2. New NpgsqlCommand")
        Dim con As Npgsql.NpgsqlConnection = getConnection()
        System.Web.HttpContext.Current.Response.Write("<br /> 3. getConnection")
        Dim dt As New DataTable
        Try
            System.Web.HttpContext.Current.Response.Write("<br /> 4. New DataTable")
            con.Open()
            System.Web.HttpContext.Current.Response.Write("<br /> 5. con.Open()")
            cmd.Connection = con
            cmd.CommandText = CommandType.Text
            cmd.CommandText = str
            System.Web.HttpContext.Current.Response.Write("<br /> 6. cmd.CommandText")
            dt.Load(cmd.ExecuteReader())
            System.Web.HttpContext.Current.Response.Write("<br /> 7. cmd.ExecuteReader")
            If dt.Columns.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            System.Web.HttpContext.Current.Response.Write("<br /> 9. ReadDataTable Error " & ex.Message.ToString)
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

    Public Function getDataTabletest(ByVal qry As String, ByVal tableName As String) As DataTable
        Try
            Dim localAdap As New NpgsqlDataAdapter
            System.Web.HttpContext.Current.Response.Write("<br /> 2. New NpgsqlDataAdapter")
            Dim rtntable As New DataTable(tableName)
            System.Web.HttpContext.Current.Response.Write("<br /> 3. New NpgsqlCommand")
            localAdap.SelectCommand = New NpgsqlCommand(qry, con)
            System.Web.HttpContext.Current.Response.Write("<br /> 4. SelectCommand")
            localAdap.Fill(rtntable)
            System.Web.HttpContext.Current.Response.Write("<br /> 5. localAdap.Fill")
            localAdap.Dispose()
            System.Web.HttpContext.Current.Response.Write("<br /> 6. localAdap.Dispose")
            Return rtntable
        Catch ex As Exception
            System.Web.HttpContext.Current.Response.Write("<br /> 7. getDataTable Error " & ex.Message.ToString)
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
        sqlstr = " SELECT license_id from ( select max(SUBSTRING(license_no,5,5)) as license_id , MAX(SUBSTRING(license_no,11,4)) as yearid  " & _
                 " FROM license where admin_id = " & admin_id & " ) as dt WHERE yearid like '%" & Now.Year + 543 & "%' "
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
        sqlstr = " select max(substring(license_group,2,7)) as regis_no from travel_group " & _
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

End Class
