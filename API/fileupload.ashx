<%@ WebHandler Language="VB" Class="AjaxFileUploader" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Web.Script.Serialization
Imports System.Text

Public Class AjaxFileUploader : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim url As String = "https://" & HttpContext.Current.Request.Url.Host & ":" & HttpContext.Current.Request.Url.Port & "/Upload/Jodit/"
        
        Dim a = context.Request.Files.Item(0)
        Dim dict As New Dictionary(Of String, Object)
       
        dict.Add("name", a.FileName)
        

    
        Dim json As New JavaScriptSerializer
        
        Dim dt = json.Serialize(dict)
        context.Response.Write(dt)
        
        
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class