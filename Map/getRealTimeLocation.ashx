<%@ WebHandler Language="VB" Class="getRealTimeLocation" %>

Imports System
Imports System.Web
Imports Npgsql

Public Class getRealTimeLocation : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim license_id As String = context.Request.QueryString("id")
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim PopupHtml As String = ""
        Try
            con.ClearPool()
            cmd.Connection = con
            cmd.Connection.Open()
            Dim str As String = "select lat , lon , date_time , license.typeuser_id , typecar_id , license.license_id , license_no , typename_th , type_name , en_short_name , CAST('../Admin/LicenseDtl.aspx?rt=' || license.typeuser_id || '&token=' || token as varchar ) as link  " & _
            " from realtime_location left join license on license.token = realtime_location.token_license " & _
            " left join type_user on type_user.typeuser_id = license.typeuser_id " & _
            " left join car on car.car_id = license.car_id  " & _
            " left join type_car on type_car.type_id = car.typecar_id " & _
            " left join countries on countries.en_short_name = car.country_car " & _
            "where id_location = " & license_id 'token_license in (select token from license where license_id = " & license_id & ") "
            cmd.CommandText = str
            Dim dr As NpgsqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                PopupHtml = getTablePopup(dr("date_time"), dr("license_no"), dr("typename_th"), dr("type_name"), dr("en_short_name"), dr("link") )
            End If
            dr.Close()
        Catch ex As Exception
            PopupHtml = "ระบบไม่สามารถค้นหาข้อมูลได้"
        Finally
            cmd.Connection.Close()
            con = Nothing
        End Try
        context.Response.Write(PopupHtml)
    End Sub
 
    Private Function getTablePopup(ByVal date_time As Object, ByVal license_no As Object, ByVal typename_th As Object, ByVal type_name As Object, ByVal en_short_name As Object, ByVal link As Object) As String
        Try
            Dim txtpopup As String = "<span style=color:slateblue> วันที่/เวลา </span> <br /> &nbsp; " & Format(CDate(date_time), "dd MMM yy HH:mm น.") & "" & _
                "<br /><span style=color:slateblue> เลขที่เครื่องหมายแสดงการใช้รถ </span><br /> &nbsp; " & license_no & "" & _
                "<br /><span style=color:slateblue> แบบขออนุญาต </span><br /> &nbsp; " & typename_th & "" & _
                "<br /><span style=color:slateblue> ประเภทรถ </span><br /> &nbsp; " & type_name & "" & _
                "<br /><span style=color:slateblue> ประเทศ </span><br /> &nbsp; " & en_short_name & "" & _
                "<br /><span style=color:slateblue><a href='" & link & "' target='_blank'> รายละเอียดใบอนุญาติ </a></span> <br/> &nbsp; "
            Return txtpopup
        Catch ex As Exception
            Return "ไม่พบข้อมูล"
        End Try
    End Function
    
    
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class