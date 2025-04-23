<%@ WebHandler Language="VB" Class="checkDateLicense" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization
Imports Npgsql
Imports System.IO
Imports System.Xml


Public Class checkDateLicense : Implements IHttpHandler
  
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Dim db As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim send As New SendEmail
        
        Try
            con.Open()
            cmd.Connection = con
        
            Dim statusFail As Integer = 8 'ไม่สำเร็จ (ยังไม่ชำระเงิน)
            Dim strquery As String = "UPDATE license SET status_id = " & statusFail & " , cancel_date = now() " & _
            " where license_id in ( select license.license_id  from license inner join travel_group_car on license.license_id = travel_group_car.license_id " & _
            " inner join travel_group on travel_group_car.group_id = travel_group.group_id  where  status_id in (1,3) " & _
            " and travel_group.start_date <= to_char(now() - INTERVAL '1 days'  ,'MM/DD/YYYY'):: DATE ) "
            cmd.CommandText = strquery
            cmd.ExecuteNonQuery()
            
            '---------------------------------------------------------------
            statusFail = 7 'ไม่สำเร็จ (เอกสารไม่สมบูรณ์ก่อน 5 วันทำการ)
            cmd.Parameters.Clear()
          
            Dim queryMail As String = " select DISTINCT license.license_id , (token), email ,cast( fname || ' ' || lname as varchar)  as name , (select email from user_travel where user_id = travel_id ) as travelemail  " & _
                                      " , to_char(travel_group.start_date,'YYYY-MM-DD') as start_date " & _
                                      " from license LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
                                      " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
                                      " WHERE status_id in (2) and travel_group.start_date < to_char(now() + INTERVAL '7 days' ,'MM/DD/YYYY'):: DATE "
            Dim table As DataTable = db.ReadDataTable(queryMail)
            For Each i In table.Rows
                'กรณีใบอนุญาตเหลือเวลาน้อยกว่า ​5 วันทำการ
                Try
                    Dim start_date As String = i("start_date")
                    Dim now_date As String = Now().Year & "-" & Format(CDbl(Now.Month), "00") & "-" & Format(CDbl(Now.Day), "00")  '"2019-11-05"
                    Dim strCntDay As String = "SELECT count(*) AS count_days_no_weekend " & _
                    " FROM generate_series(timestamp '" & now_date & "', timestamp '" & start_date & "' , interval  '1 day') the_day " & _
                    " WHERE extract('ISODOW' FROM the_day) < 6 "
                    Dim CntDay As Integer = db.executeScalar(strCntDay)
                    If CntDay < 5 Then
                        send.EmailSummit(i("email"), i("name"), i("token"), "", statusFail, "")
                        send.EmailSummit(i("travelemail"), i("name"), i("token"), "", statusFail, "")
                
                        Dim strquery2 As String = " UPDATE license SET status_id = " & statusFail & " , cancel_date = now()  WHERE license_id = " & i("license_id")
                        cmd.CommandText = strquery2
                        cmd.ExecuteNonQuery()
                    End If
                Catch ex As Exception

                End Try
            Next
                       
            context.Response.Write("success")
        Catch ex As Exception
            context.Response.Write("Error")
        Finally
            con.Close()
            cmd.Dispose()
            db = Nothing
        End Try
     
       
        
    End Sub
    
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class