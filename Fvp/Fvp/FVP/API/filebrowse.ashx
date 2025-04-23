<%@ WebHandler Language="VB" Class="filebrowse" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Web.Script.Serialization
Imports System.Text


Public Class filebrowse : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim url As String = "https://" & HttpContext.Current.Request.Url.Host & ":" & HttpContext.Current.Request.Url.Port & "/Upload/Jodit/"
        Dim pathImg As String = Path.Combine(HttpContext.Current.Server.MapPath("~/Upload/Jodit/"))
        
        
        If context.Request("action") = "permissions" Then
            Dim webClient As New System.Net.WebClient
            Dim result As String = webClient.DownloadString("https://xdsoft.net/jodit/connector/index.php?action=permissions")
            context.Response.Write(result)
          
        ElseIf context.Request("action") = "folders" Then
            
           
            Dim dict As New Dictionary(Of String, Object)
            Dim data As New Dictionary(Of String, Object)
            Dim soucres As New Dictionary(Of String, Object)
            Dim def As New Dictionary(Of String, Object)
            Dim fol As New List(Of Object)
            
            def.Add("baseurl", url)
            def.Add("path", "")
            fol.Add(".")
            def.Add("folders", fol)
            
            soucres.Add("default", def)
            data.Add("sources", soucres)
            

            dict.Add("success", True)
            dict.Add("data", data)
            dict.Add("code", 220)
            
            Dim json As New JavaScriptSerializer
            Dim dt = json.Serialize(dict)

            context.Response.Write(dt)
        ElseIf context.Request("action") = "files" Then
            
            Dim dict As New Dictionary(Of String, Object)
            Dim data As New Dictionary(Of String, Object)
            Dim soucres As New Dictionary(Of String, Object)
            Dim def As New Dictionary(Of String, Object)
            Dim fol As New List(Of Object)
        
        
        
            Dim fileList As New DirectoryInfo(pathImg)
            For Each f In fileList.GetFiles()
                Dim dict3 As New Dictionary(Of String, Object)
                dict3.Add("file", f.Name)
                fol.Add(dict3)
            Next
          
            def.Add("baseurl", url)
            def.Add("path", "")
            def.Add("files", fol)
            
            soucres.Add("default", def)
            data.Add("sources", soucres)
            

            dict.Add("success", True)
            dict.Add("data", data)
            dict.Add("code", 220)
            
            Dim json As New JavaScriptSerializer
            Dim dt = json.Serialize(dict)

            context.Response.Write(dt)
            
            
            
        ElseIf context.Request("action") = "fileRemove" Then
            Dim dict As New Dictionary(Of String, Object)
            Dim name = context.Request.Form("name")
            If File.Exists(pathImg & name) Then
                File.Delete(pathImg & name)
            End If
            dict.Add("success", True)
            Dim json As New JavaScriptSerializer
            Dim dt = json.Serialize(dict)
            
            context.Response.Write(dt)
        End If
        
        
      
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class