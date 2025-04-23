<%@ WebHandler Language="VB" Class="getlistLandmark" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization


Public Class getlistLandmark : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim url As String = HttpContext.Current.Request.Url.Host
        Dim map_name As String = context.Request.QueryString("name")
        Dim map_sql As String = "SELECT gid , type , type_name , name_t , name_e from landmark60V2 LEFT JOIN type_landmark on landmark60V2.type = type_landmark.type_no WHERE 1=1"
        If map_name <> "" Then
            map_sql = map_sql & "and name_t like '%" & map_name & "%' or Lower(name_e) like '%" & map_name & "%' or Upper(name_e) like '%" & map_name & "%' limit 20"
        Else
            map_sql = "select gid , type , type_name , name_t , name_e from landmark60V2 LEFT JOIN type_landmark on landmark60V2.type = type_landmark.type_no order by name_t limit 20"
        End If
        Dim db As New DBConnect
        Dim dtTask As DataTable = db.getDataTable(map_sql, "LandmarkList")
        Dim str As String = DataSetToJSON(dtTask)
        context.Response.Write(str)
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