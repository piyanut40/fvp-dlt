<%@ WebHandler Language="VB" Class="getLandmarkWithTypeLocat" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization


Public Class getLandmarkWithTypeLocat : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim lat As String = context.Request.QueryString("lat")
        Dim lon As String = context.Request.QueryString("lon")
        Dim type As String = context.Request.QueryString("type")
        Dim typeLand_sql As String = "SELECT 0"
        
        If lat <> "" And lon <> "" Then
            If type <> "" Then
                typeLand_sql = "SELECT gid , type , type_name , name_t , name_e , point_x as lon , point_y as lat" & _
                           " FROM public.landmark60V2 LEFT JOIN type_landmark on landmark60V2.type = type_landmark.type_no " & _
                           " WHERE type = '" & type & "' " & _
                           " order by st_distance(st_setsrid(st_point(point_x , point_y)::geometry , 4326),st_transform(st_setsrid( st_point('" & lon & "' , '" & lat & "' ) ::geometry ,4326)  ,4326)) limit 25"
            Else
                typeLand_sql = "SELECT gid , type , type_name , name_t , name_e , point_x as lon , point_y as lat" & _
                            " FROM public.landmark60V2 LEFT JOIN type_landmark on landmark60V2.type = type_landmark.type_no " & _
                            " order by st_distance(st_setsrid(st_point(point_x , point_y)::geometry , 4326) ,st_transform(st_setsrid( st_point('" & lon & "' , '" & lat & "' ) ::geometry ,4326)  ,4326)) limit 25"
            End If
        Else
            typeLand_sql = "SELECT gid , type , type_name , name_t , name_e , point_x as lon , point_y as lat" & _
                          " FROM public.landmark60V2 LEFT JOIN type_landmark on landmark60V2.type = type_landmark.type_no limit 25 "
        End If
        Dim db As New DBConnect
        Try
            Dim dtTask As DataTable = db.getDataTable(typeLand_sql, "realtime_location")
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