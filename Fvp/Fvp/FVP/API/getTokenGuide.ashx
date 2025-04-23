<%@ WebHandler Language="VB" Class="getTokenGuide" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization


Public Class getTokenGuide : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim url As String = HttpContext.Current.Request.Url.Host
        Dim regis As String = context.Request.QueryString("license")
        Dim idcard As String = context.Request.QueryString("id_card")
        Dim tokensql As String = " select token from guide " & _
                                " INNER JOIN travel_group_guide tgg on guide.guide_id = tgg.guide_id " & _
                                " INNER JOIN travel_group tg on tgg.group_id = tg.group_id " & _
                                " WHERE guide_idcard = '" & idcard & "' and license_group = '" & regis & "' "
        Dim db As New DBConnect
        Dim dtTask As DataTable = db.getDataTable(tokensql, "token")
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