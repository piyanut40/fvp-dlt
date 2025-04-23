<%@ WebHandler Language="VB" Class="postLocation" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization
Imports Npgsql
Imports System.IO
Imports System.Xml


Public Class postLocation : Implements IHttpHandler
  
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim lat As String = context.Request.Form("lat")
        Dim lon As String = context.Request.Form("lon")
        Dim token As String = context.Request.Form("token")

        Dim date_time As DateTime = DateTime.Now
      
        
        Dim db As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        If token <> "" And lon <> "" And lat <> "" Then
            Try
                con.Open()
                cmd.Connection = con
                cmd.CommandText = CommandType.Text
                cmd.CommandText = "select count(token) from (select token from license union select token from travel_group_guide) as dt WHERE token = '" & token & "'"
                Dim t As Integer = cmd.ExecuteScalar
                Dim is_wrong As Integer
                Dim is_guide As Object = DBNull.Value
                If t = 1 Then
                    Dim way_wrong As Object
                    cmd.CommandText = "select st_intersects(st_union(geom4326) , st_setsrid(st_point(" & lon & "," & lat & "),4326)) as way from ( " & _
                                                   " select geom4326 from area_group , province WHERE area_group.prov_code = province.prov_code and group_id = ( " & _
                                                   " select group_id from travel_group_guide where token =( " & _
                                                   " select token from (select token from travel_group_guide)  " & _
                                                   " as dt WHERE token = '" & token & "') ) ) as dt "
                    way_wrong = cmd.ExecuteScalar
                    If way_wrong IsNot DBNull.Value Then
                        If way_wrong = True Then
                            is_wrong = 0
                        Else
                            is_wrong = 1
                        End If
                        is_guide = 1
                    Else
                        cmd.CommandText = "select st_intersects(st_union(geom4326) , st_setsrid(st_point(" & lon & "," & lat & "),4326)) as way from ( " & _
                                                   " select geom4326 from area_group , province WHERE area_group.prov_code = province.prov_code and group_id = ( " & _
                                                   " select group_id from travel_group_car where license_id in( " & _
                                                   " select license_id from license WHERE token = '" & token & "') ) ) as dt "
                        way_wrong = cmd.ExecuteScalar
                        If way_wrong IsNot DBNull.Value Then
                            If way_wrong = True Then
                                is_wrong = 0
                            Else
                                is_wrong = 1
                            End If
                            is_guide = 0
                        End If
                    End If
                    cmd.Parameters.Clear()
                    cmd.CommandText = "INSERT INTO realtime_location (lat , lon , token_license , date_time , wrong_way , is_guide ) VALUES ( :lat , :lon , :token_license , :date_time , :wrong_way , :is_guide) "
                    cmd.Parameters.Add("lat", NpgsqlTypes.NpgsqlDbType.Varchar).Value = lat
                    cmd.Parameters.Add("lon", NpgsqlTypes.NpgsqlDbType.Varchar).Value = lon
                    cmd.Parameters.Add("token_license", NpgsqlTypes.NpgsqlDbType.Varchar).Value = token
                    cmd.Parameters.Add("date_time", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = date_time
                    cmd.Parameters.Add("wrong_way", NpgsqlTypes.NpgsqlDbType.Integer).Value = is_wrong
                    cmd.Parameters.Add("is_guide", NpgsqlTypes.NpgsqlDbType.Integer).Value = is_guide
                    cmd.ExecuteNonQuery()
                    context.Response.Write("Success")
                Else
                    context.Response.Write("Not found Token !")
                End If
            Catch ex As Exception
                context.Response.Write("Error")
                con.Close()
            Finally
               
            End Try
        Else
            context.Response.Write(token & " :: Error - Please Fill Data!!!")
            cmd.Connection.Close()
            con.Close()
            db = Nothing
            
        End If
        cmd.Connection.Close()
        con.Close()
        db = Nothing
 
    End Sub
    
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class