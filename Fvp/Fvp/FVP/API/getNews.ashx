<%@ WebHandler Language="VB" Class="getNews" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization


Public Class getNews : Implements IHttpHandler
    Public nohtml As String
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim url As String = HttpContext.Current.Request.Url.Host
        Dim port As String = "" '":" & HttpContext.Current.Request.Url.Port
        Dim news_no As String = context.Request.QueryString("id")
        Dim fetch As String = context.Request.QueryString("fetch")
        Dim name As String = context.Request.QueryString("name")
        nohtml = context.Request.QueryString("NoHtml")
        
        If name <> "" Then
            name = "and title like '%" & name & "%'"
        Else
            name = ""
        End If
        Dim news As String = "SELECT news_id, title , detail , CAST(date_news as varchar)  , CAST('" & url & port & "/Upload/News/' as varchar)||pic as url from news WHERE 1=1 " & name & " "
        If news_no <> "" Then
            news = news & "and news_id = " & news_no & ""
        Else
            If fetch <> "" Then
                news = "SELECT news_id, title, CAST(date_news as varchar) , CAST('" & url & port & "/Upload/News/' as varchar)||pic as url from news WHERE news_id < " & fetch & " " & name & " order by news_id DESC limit 8"
            Else
                news = "SELECT news_id, title, CAST(date_news as varchar) , CAST('" & url & port & "/Upload/News/' as varchar)||pic as url from news WHERE 1=1 " & name & " order by news_id DESC limit 8"
            End If
        End If
        Dim db As New DBConnect
        
        Dim dtTask As DataTable = db.getDataTable(news, "News")
        If news_no <> "" Then
            If dtTask.Rows.Count > 0 Then
                If Not dtTask.Rows(0).Item("detail") Is DBNull.Value Then
                                          
                    Dim desc = dtTask.Rows(0).Item("detail")
                    desc = Regex.Replace(desc, "<.*?>", "")
                    dtTask.Rows(0).Item("detail") = System.Web.HttpUtility.HtmlDecode(desc)
                End If
            End If
        End If
        Dim str As String = DataSetToJSON(dtTask)
        context.Response.Write(str)
    End Sub
    
    Public Function StripTags(ByVal html As String) As String
        Return Regex.Replace(html, "<.*?>", "")
    End Function

    
    Public Function DataSetToJSON(ByVal dt As DataTable) As String
        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim packet As New List(Of Dictionary(Of String, Object))()
        Dim packHead As New Dictionary(Of String, Object)
        Dim row As Dictionary(Of String, Object) = Nothing
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each dc As DataColumn In dt.Columns
                If nohtml = 1 Then
                    row.Add(dc.ColumnName.Trim(), StripTags(dr(dc)))
                Else
                    row.Add(dc.ColumnName.Trim(), dr(dc))
                End If
            Next
            packet.Add(row)
        Next
        packHead.Add(dt.TableName, packet)
        
        Return serializer.Serialize(packHead)
    End Function
    
    
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