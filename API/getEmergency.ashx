<%@ WebHandler Language="VB" Class="getEmergency" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization


Public Class getEmergency : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim url As String = HttpContext.Current.Request.Url.Host
        Dim emergen_sql As String = "SELECT emergen_id , emergen_nameth , emergen_nameen , emergen_tel , CAST('" & url & "/Upload/emergency/' as varchar)||photo as url   from emergency order by emergen_id"
     
        Dim db As New DBConnect
        Try
            Dim dtTask As DataTable = db.getDataTable(emergen_sql, "emergency")
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