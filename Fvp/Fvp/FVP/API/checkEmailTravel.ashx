<%@ WebHandler Language="VB" Class="checkEmailTravel" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization
Imports Npgsql
Imports System.IO
Imports System.Xml


Public Class checkEmailTravel : Implements IHttpHandler
  
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
       
        Dim db As New DBConnect
        Dim sendEmail As New SendEmail
        Try
           
            Dim strquery = "select email , CAST(user_name || ' ' || user_surname as varchar ) as name , name_company , username , to_char(license_exp ,'DD/MM/YYYY') as license_exp , " & _
                       " to_char(now(),'DD/MM/YYYY') , to_char(license_exp - INTERVAL '30 days' ,'DD/MM/YYYY') from user_travel " & _
                       " WHERE to_char(license_exp - INTERVAL '30 days','DD/MM/YYYY') = to_char(now(),'DD/MM/YYYY') "
            Dim table As DataTable = db.ReadDataTable(strquery)
            For Each i In table.Rows
                sendEmail.EmailTravelNotification(i("email"), i("name"), i("name_company"), i("username"))
            Next
        Catch ex As Exception
            context.Response.Write("Error")
        Finally
            context.Response.Write("success")
        End Try
        db = Nothing
        sendEmail = Nothing
    End Sub
    
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class