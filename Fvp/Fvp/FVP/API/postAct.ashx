<%@ WebHandler Language="VB" Class="postAct" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization
Imports Npgsql
Imports System.IO
Imports System.Xml


Public Class postAct : Implements IHttpHandler
  
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim act_no As String = context.Request.Form("act_no")
        Dim act_name As String = context.Request.Form("act_name")
        Dim act_tankno As String = context.Request.Form("act_tankno")
        Dim act_start As String = context.Request.Form("act_start")
        Dim act_ends As String = context.Request.Form("act_ends")
        Dim act_photo = context.Request.Files.Item("act_photo")
        Dim act_company As String = context.Request.Form("act_company")
        Dim token As String = context.Request.Form("token")

        
        Dim db As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        If token <> "" Then
            Try
                con.Open()
                cmd.Connection = con
                cmd.CommandText = CommandType.Text
                cmd.CommandText = "select act_id from license WHERE token = '" & token & "'"
                Dim act_id As Integer = cmd.ExecuteScalar
                If act_id <> 0 Then
                    Dim srcname As String = act_photo.FileName
                    Dim extname As String = Path.GetExtension(act_photo.FileName)
                    srcname = (srcname + DateTime.Now).GetHashCode
                    srcname = srcname + extname
                    Dim filesave = Path.Combine(HttpContext.Current.Server.MapPath("~/Upload/Act/") + srcname)
                    act_photo.SaveAs(filesave)
                    cmd.Parameters.Clear()
                    cmd.CommandText = "Update act set act_no = :act_no , act_name = :act_name , act_tankno = :act_tankno , act_start = :act_start , act_ends = :act_ends , " & _
                                      " act_photo = :act_photo , act_company = :act_company WHERE act_id = " & act_id & ""
                    cmd.Parameters.Add("act_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = act_no
                    cmd.Parameters.Add("act_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = act_name
                    cmd.Parameters.Add("act_tankno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = act_tankno
                    cmd.Parameters.Add("act_start", NpgsqlTypes.NpgsqlDbType.Date).Value = act_start
                    cmd.Parameters.Add("act_ends", NpgsqlTypes.NpgsqlDbType.Date).Value = act_ends
                    cmd.Parameters.Add("act_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = srcname
                    cmd.Parameters.Add("act_company", NpgsqlTypes.NpgsqlDbType.Varchar).Value = act_company
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
            db = Nothing
            cmd.Connection.Close()
            con.Close()
            
        End If
        db = Nothing
        cmd.Connection.Close()
        con.Close()
    End Sub
    
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class