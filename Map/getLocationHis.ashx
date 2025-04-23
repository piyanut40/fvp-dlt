<%@ WebHandler Language="VB" Class="getLocationHis" %>

Imports System
Imports System.Web
Imports Npgsql

Public Class getLocationHis : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim license_id As String = context.Request.QueryString("id")
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim PopupHtml As String = ""
        Try
            con.ClearPool()
            cmd.Connection = con
            cmd.Connection.Open()
            Dim str As String = "select lat , lon , date_time , license.typeuser_id , typecar_id , license.license_id , license_no , typename_th , type_name , en_short_name " & _
            " , CAST('../Travel/LicenseDtl.aspx?isPopup=1&rt=' || license.typeuser_id || '&token=' || license.token as varchar ) as link " & _
            " , CAST('../Travel/GroupDtl.aspx?isPopup=1&id=' || travel_group_guide.group_id as varchar )  as linkGroup , is_guide  " & _
            " , (driver.name::text || ' '::text) || driver.surname::text AS _name " & _
            " from realtime_location left join license on license.token = realtime_location.token_license " & _
            " left join travel_group_guide on travel_group_guide.token = realtime_location.token_license " & _
            " left join type_user on type_user.typeuser_id = license.typeuser_id " & _
            " left join car on car.car_id = license.car_id  " & _
            " left join type_car on type_car.type_id = car.typecar_id " & _
            " left join countries on countries.en_short_name = car.country_car " & _
            " LEFT JOIN driver ON driver.driver_id = license.driver_id " & _
            "where id_location = " & license_id 'token_license in (select token from license where license_id = " & license_id & ") "
            cmd.CommandText = str
            Dim dr As NpgsqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                PopupHtml = getTablePopup(dr("date_time"), dr("license_no"), dr("typename_th"), dr("type_name"), dr("en_short_name"), dr("link"), dr("is_guide"), dr("linkGroup"), dr("_name"))
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
 
    Private Function getTablePopup(ByVal date_time As Object, ByVal license_no As Object, ByVal typename_th As Object, ByVal type_name As Object, ByVal en_short_name As Object, _
                                   ByVal link As Object, ByVal is_guide As Object, ByVal linkGroup As Object, ByVal driver_name As Object) As String
        Try
            Dim txtpopup As String = "<span style=color:slateblue> วันที่/เวลา </span> <br /> &nbsp; " & Format(CDate(date_time), "dd MMM yy HH:mm น.") & "" '& _
            'txtpopup = txtpopup & "<br /><span style=color:slateblue> ประเทศ </span><br /> &nbsp; " & en_short_name & ""
            'txtpopup = txtpopup & "<br /><span style=color:slateblue> พนักงานขับรถ </span><br /> &nbsp; " & driver_name & ""
            If is_guide = "1" Then
                txtpopup = txtpopup & "<br /><span style='width: 200px; text-align: right; float: right; color:slateblue; '><a href='#' onClick=window.open('" & linkGroup & "','_blank','height=900,width=1200'); > [รายละเอียดกรุ๊ป] </a></span> <br/> &nbsp; "
            Else
                txtpopup = txtpopup & "<br /><span style='width: 200px; text-align: right; float: right; color:slateblue; '><a href='#' onclick=window.open('" & link & "','_blank','height=900,width=1200'); > [รายละเอียดใบอนุญาต] </a></span> <br/> &nbsp; "
            End If
           
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