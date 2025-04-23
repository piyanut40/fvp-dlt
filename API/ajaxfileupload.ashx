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
        Dim srcName As String
        Dim srcExt As String
        srcName = a.FileName
        srcExt = Path.GetExtension(a.FileName)
        srcName = (srcName + DateTime.Now).GetHashCode
        srcName = srcName + srcExt
        'srcExt = Path.GetExtension(a.PostedFile.FileName)
        Dim filesave = Path.Combine(HttpContext.Current.Server.MapPath("~/Upload/Jodit/") + srcName)
        a.SaveAs(filesave)
       
        Dim dict As New Dictionary(Of String, Object)
        Dim dict2 As New Dictionary(Of String, Object)
        Dim packet As New List(Of String)
        dict.Add("success", True)
        dict2.Add("baseurl", url)
        packet.Add(srcName)
        dict2.Add("files", packet)
        dict.Add("data", dict2)
        
       
        
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