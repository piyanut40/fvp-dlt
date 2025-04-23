<%@ WebHandler Language="VB" Class="getLicense" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization


Public Class getLicense : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim url As String = HttpContext.Current.Request.Url.Host
        Dim token As String = context.Request.QueryString("token")
       
        Dim license_sql As String = "SELECT  license.license_id , license.license_no , country_car as regis_country , plate as license_car ,  owner_name as name_driver , driver.surname as surname , type_name as typecar_en , brands as brand_caren, model , colors " & _
            " , seat as seats , car_no as number_car , engine_no as number_engine , 0 as cylinder_cap , weight ,0 as weight_carry , border_check_in.border_nameth as check_in , border_check_out.border_nameth as check_out ,  CAST('" & url & "/Upload/Passport/' as varchar)|| driver.passport_photo as urlphoto " & _
            " , CAST('https://api.qrserver.com/v1/create-qr-code/?data=' as varchar)|| qrcode as qrcode , _area area " ' & _
        
        '----------------- ข้อมูกรมธรรม์ ----------------- 

        license_sql = license_sql & " , act_no , act_name , act_tankno , act_start , act_ends , CAST('" & url & "/Upload/Act/' as varchar) || act_photo as act_photo , act.act_company " & _
                                    " , act_no2 , act_name2, act_start2 , act_ends2 , CAST('" & url & "/Upload/Act/' as varchar) || act_photo2 as act_photo2, act_company2 "
                
         '----------------- ข้อมูลรถ ----------------- 

        license_sql = license_sql & " , car.plate , car.passportcar_no , car.passportcar_expire ,  coalesce(car.owner_prename,'')  || ' ' ||  coalesce(car.owner_name,'') || ' ' || coalesce(car.owner_lastname,'')  as owner_name  , car.owner_idcard " & _
                                    " , owner_address , owner_province, owner_zipcode, owner_country , owner_tel  , owner_email ,  CAST('" & url & "/Upload/Authorize/' as varchar) || authorize_car as authorize_car "
         
        '----------------- คนขับรถ ----------------- 

        license_sql = license_sql & " , driver.countries as driver_countries , driver.birthday as driver_birthday " '", thailicense_no, other_information, is_send, photo_cer "
        license_sql = license_sql & " , CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name " & _
                                    " , driver.passport_no as driver_passport_no , driver.passport_expire as driver_passport_expire " & _
                                    " , driver.national as driver_national , driver.idcard_no as driver_license_no , driver.license_expire as driver_license_exp_date " & _
                                    " , driver.gender as driver_gender , coalesce(driver.address,'') || ' ' || coalesce(driver.state,'') || ' ' || coalesce(driver.county,'') || ' ' || coalesce(driver.zipcode,'') as driver_address , driver.tel as driver_tel " & _
                                    " , driver.email as driver_email , CAST('" & url & "/Upload/Passport/' as varchar) || driver.passport_photo as driver_passport_photo , CAST('" & url & "/Upload/LicenseDriver/' as varchar) || driver.licensedriver_photo as driver_licensedriver_photo "
                
        '----------------- คนขับสำรองคนที่ 1 ----------------- 
        license_sql = license_sql & " , CAST(spare_1.prename || ' ' || spare_1.name || ' ' || spare_1.surname as varchar) as spare_1_name " & _
                                    " , spare_1.passport_no as spare_1_passport_no, spare_1.passport_expire as spare_1_passport_expire " & _
                                    " , spare_1.national as spare_1_national, spare_1.license_no as spare_1_license_no  , spare_1.license_exp_date as spare_1_license_exp_date " & _
                                    " , spare_1.gender as spare_1_gender , coalesce(spare_1.address,'') || ' ' || coalesce(spare_1.state,'') || ' ' || coalesce(spare_1.country,'') || ' ' || coalesce(spare_1.zipcode,'') as spare_1_address , spare_1.tel as spare_1_tel  " & _
                                    " , spare_1.email as spare_1_email , CAST('" & url & "/Upload/Passport/' as varchar) || spare_1.passport_photo as spare_1_passport_photo , CAST('" & url & "/Upload/LicenseDriver/' as varchar) || spare_1.licensedriver_photo as spare_1_licensedriver_photo "
        
        '----------------- คนขับสำรองคนที่ 2 ----------------- 
        license_sql = license_sql & " , CAST(spare_2.prename || ' ' || spare_2.name || ' ' || spare_2.surname as varchar) as spare_2_name " & _
                                    " , spare_2.passport_no as spare_2_passport_no, spare_2.passport_expire as spare_2_passport_expire " & _
                                    " , spare_2.national as spare_2_national, spare_2.license_no as spare_2_license_no  , spare_2.license_exp_date as spare_2_license_exp_date  " & _
                                    " , spare_2.gender as spare_2_gender , coalesce(spare_2.address,'') || ' ' || coalesce(spare_2.state,'') || ' ' || coalesce(spare_2.country,'') || ' ' || coalesce(spare_2.zipcode,'') as spare_2_address , spare_2.tel as spare_2_tel  " & _
                                    " , spare_2.email as spare_2_email , CAST('" & url & "/Upload/Passport/' as varchar) || spare_2.passport_photo as spare_2_passport_photo , CAST('" & url & "/Upload/LicenseDriver/' as varchar) || spare_2.licensedriver_photo as spare_2_licensedriver_photo "
        
        license_sql = license_sql & " , status_en as status_th , (select string_agg(prov_en , ',') from area LEFT JOIN province on area.prov_code = province.prov_code  WHERE license_id = license.license_id) as provarea "
        
        license_sql = license_sql & " ,name_company as com_name , CAST(user_travel.user_name || ' ' || user_travel.user_surname as varchar) as agen_name "

       
        license_sql = license_sql & " , user_travel.telephone as com_tel, user_travel.email as com_mail, company_license " & _
        " , coalesce(user_travel.address,'')|| ' ' || t_name_e || ' , ' || a_name_e || ' , ' ||p_name_e|| '  ' ||coalesce(postal,'') as com_address , group_name , travel_group.start_date as group_start  ,  travel_group.exp_date as group_exp  "
        license_sql = license_sql & " , country_car "
        license_sql = license_sql & " , receipt , receipt_date "

        license_sql = license_sql & " FROM license " & _
         " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
         " LEFT JOIN spare_driver spare_1 on driver.driver_id = spare_1.driver_id and spare_1.spare_ord = 1 " & _
         " LEFT JOIN spare_driver spare_2 on driver.driver_id = spare_2.driver_id and spare_2.spare_ord = 2 " & _
         " LEFT JOIN car on car.car_id = license.car_id " & _
         " LEFT JOIN act on act.act_id = license.act_id " & _
         " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
         " LEFT JOIN status on license.status_id = status.status_id " & _
         " LEFT JOIN border_check border_check_in on license.checkin_id = border_check_in.border_id   " & _
         " LEFT JOIN border_check border_check_out on license.checkout_id = border_check_out.border_id " & _
         " LEFT JOIN (SELECT string_agg(prov_code,':' ) _area , license_id from area  group by license_id) area on area.license_id = license.license_id "
                
        license_sql = license_sql & " LEFT JOIN user_travel on user_travel.user_id = license.travel_id " & _
        " LEFT JOIN tumbol on tumbol.t_id = user_travel.tumbol  " & _
        " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
        " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id "

        license_sql = license_sql & " WHERE license.status_id = 5 and token = '" & token & "' "
        
        Dim db As New DBConnect
        Dim dtTask As DataTable = db.getDataTable(" SELECT * FROM ( " & license_sql & " ) as dt ", "license")
        Dim str As String = DataSetToJSON(dtTask)
        context.Response.Write(str)
    End Sub
    
    Public Function DataSetToJSON(ByVal dt As DataTable) As String
        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim packet As New List(Of Dictionary(Of String, Object))()
        Dim packHead As New Dictionary(Of String, Object)
        Dim row As Dictionary(Of String, Object) = Nothing
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each dc As DataColumn In dt.Columns
                row.Add(dc.ColumnName.Trim(), dr(dc))
            Next
            packet.Add(row)
        Next
        packHead.Add(dt.TableName, packet)
        
        Return serializer.Serialize(packHead)
    End Function
    
    
    
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class