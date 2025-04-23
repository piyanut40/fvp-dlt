<%@ WebHandler Language="VB" Class="getlistNews" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization


Public Class getlistNews : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim url As String = HttpContext.Current.Request.Url.Host
        Dim id As String = context.Request.QueryString("id")
        Dim name As String = context.Request.QueryString("name")
        Dim strQry As String
        If id <> "" Then
            strQry = " select distinct user_name , user_lastname , user_travel_group.telephone , user_travel_group.idcard  from user_travel_group " & _
                              " LEFT JOIN travel_group on travel_group.group_id = user_travel_group.group_id  WHERE travel_group.user_id = " & id
        ElseIf name <> "" Then
            strQry = " select distinct user_name , user_lastname , user_travel_group.telephone , user_travel_group.idcard  from user_travel_group " & _
                                 " LEFT JOIN travel_group on travel_group.group_id = user_travel_group.group_id  WHERE user_travel_group.user_name like '%" & name & "%'"
        Else
            strQry = " select distinct user_name , user_lastname , user_travel_group.telephone , user_travel_group.idcard from user_travel_group " & _
                             " LEFT JOIN travel_group on travel_group.group_id = user_travel_group.group_id "
        End If
     
        Dim db As New DBConnect
        Dim dtTask As DataSet = db.getDataSet(strQry, "name")
        Dim str As String = DataSetToJSON(dtTask)
        context.Response.Write(str)
    End Sub
    
    Function DataSetToJSON(ByVal ds As DataSet) As String
        Dim dict As New Dictionary(Of String, Object)
        
        For Each dt As DataTable In ds.Tables
            Dim arr(dt.Rows.Count - 1) As Object
            Dim arr2(dt.Rows.Count - 1) As Object
            Dim arr3(dt.Rows.Count - 1) As Object
            Dim arr4(dt.Rows.Count - 1) As Object
            
            For i As Integer = 0 To dt.Rows.Count - 1
                arr(i) = dt.Rows(i).Item("user_name")
                arr2(i) = dt.Rows(i).Item("user_lastname")
                arr3(i) = dt.Rows(i).Item("telephone")
                arr4(i) = dt.Rows(i).Item("idcard")
            Next
            
            dict.Add(dt.TableName, arr)
            dict.Add("lastname", arr2)
            dict.Add("telephone", arr3)
            dict.Add("idcard", arr4)
            
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