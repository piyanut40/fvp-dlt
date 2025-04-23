<%@ WebHandler Language="VB" Class="getlistNews" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization


Public Class getlistNews : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim url As String = HttpContext.Current.Request.Url.Host
        Dim news_no As String = context.Request.QueryString("id")
        Dim news As String = "SELECT news_id, title , detail , CAST('" & url & "/Upload/News/' as varchar)||pic as url from news WHERE 1=1 "
        If news_no <> "" Then
            news = news & "and news_id = " & news_no & ""
        Else
            news = "SELECT news_id, title , CAST('" & url & "/Upload/News/' as varchar)||pic as url from news"
        End If
        Dim db As New DBConnect
        Dim dtTask As DataSet = db.getDataSet(news, "task")
        Dim str As String = DataSetToJSON(dtTask)
        context.Response.Write(str)
    End Sub
    
    Function DataSetToJSON(ByVal ds As DataSet) As String
        Dim dict As New Dictionary(Of String, Object)
        
        For Each dt As DataTable In ds.Tables
            Dim arr(dt.Rows.Count - 1) As Object
            
            For i As Integer = 0 To dt.Rows.Count - 1
                arr(i) = dt.Rows(i).ItemArray
            Next
            
            dict.Add(dt.TableName, arr)
        Next
        
        Dim json As New JavaScriptSerializer
        
        Return json.Serialize(dict)
        
    End Function
    
    
    
    
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class