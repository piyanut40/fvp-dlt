<%@ WebHandler Language="VB" Class="getLocationPost" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization


Public Class getLocationPost : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim typeLand_sql As String = "SELECT id_location ,  lat , lon , token_license ,CAST(date_time as varchar) from realtime_location order by id_location "
    
        Dim db As New DBConnect
        Dim dtTask As DataTable = db.getDataTable(typeLand_sql, "realtime_location")
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