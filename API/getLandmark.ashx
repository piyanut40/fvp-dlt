<%@ WebHandler Language="VB" Class="getLandmark" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization


Public Class getLandmark : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim url As String = HttpContext.Current.Request.Url.Host
        Dim map_id As String = context.Request.QueryString("gid")
        Dim map_sql As String = "SELECT landmark60V2.gid , type_name  , name_t ,  name_e , location_t , t_name_t , a_name_t , p_name_t , location_e , t_name_e , a_name_e , p_name_e , point_y as latitude ,point_x as longtitude " & _
                             " FROM public.landmark60V2 " & _
                             " LEFT JOIN tumbol on landmark60V2.t_code = tumbol.t_code and landmark60V2.a_code = tumbol.a_code and landmark60V2.p_code = tumbol.p_code " & _
                             " LEFT JOIN type_landmark on landmark60V2.type = type_landmark.type_no " & _
                             " WHERE 1=1 "
        If map_id <> "" Then
            map_sql = map_sql & "and landmark60V2.gid = " & map_id & "limit 10"
        Else
            map_sql = map_sql & "limit 10"
        End If
        
        Dim db As New DBConnect
        Try
            Dim dtTask As DataTable = db.getDataTable(map_sql, "getLandmark")
            Dim str As String = DataSetToJSON(dtTask)
            context.Response.Write(str)
        Catch ex As Exception
            
        Finally
            db = Nothing
        End Try
    End Sub
    
    Public Function DataSetToJSON(ByVal dt As DataTable) As String
        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim packet As New List(Of Dictionary(Of String, Object))()
        Dim packHead As New Dictionary(Of String, Object)
        Dim row As Dictionary(Of String, Object) = Nothing
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each dc As DataColumn In dt.Columns
                row.Add(dc.ColumnName.Trim(), dr(dc))
            Next
            packet.Add(row)
        Next
        packHead.Add(dt.TableName, packet)
        
        Return serializer.Serialize(packHead)
    End Function
    
    
    
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class