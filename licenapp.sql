Select  Row_number() over (order by regis_date desc nulls last) As number ,* FROM  
         ( Select plate , country_car , license.license_id , token , " travel_group.admin_id " admin_id , CAST(Case when driver.prename = 'Other' Then '' Else driver.prename end || ' ' || name || ' ' || surname As varchar) As name, '' As vehicle_type  , "replace(type_name,'(','<br/>(')" As typecar_en 
         , brands, model As models, Case when (check_tab0 + check_tab1 + check_tab2 + check_tab3 + check_tab4 + check_tab8) > 6 Then 'รออนุมัติ(แก้ไขคำขอ)' Else status_th end As status_th ,  
         CAST('LicenseApp.aspx?rt=2&token=' || token As varchar ) As urlDoc, 
         CAST('LicenseAppEdit.aspx?rt=2&token=' || token As varchar ) As urlMgt, typeuser_id, license.status_id,regis_date  , check_tab1, check_tab2, check_tab3, check_tab4, check_tab5, check_tab6, check_tab7 , check_tab0 , check_tab8, reason_app As reason   , 
        (Select STRING_AGG(CAST(Case when guide.prename = 'Other' Then '' Else guide.prename end || ' ' || guide.guide_name || ' ' || guide.guide_surname As varchar),' , ')  from guide 
         LEFT JOIN travel_group_guide on travel_group_guide.guide_id = guide.guide_id 
        WHERE travel_group_guide.group_id = travel_group_car.group_id ) As guide , 
        name_company , to_char(travel_group.start_date , 'DD-MM-YYYY') As start_date , 
         to_char(travel_group.exp_date , 'DD-MM-YYYY') As exp_date ,travel_group.start_date As start_date1,travel_group.exp_date As exp_date1
         FROM license  LEFT JOIN driver on driver.driver_id = 
         license.driver_id  LEFT JOIN car on car.car_id = license.car_id  LEFT JOIN type_car on car.typecar_id = type_car.type_id 
          LEFT JOIN status on license.status_id = status.status_id  LEFT JOIN user_travel on user_travel.user_id =  license.travel_id  
         LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id  
         LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id 
         WHERE typeuser_id = 2 And license.status_id Not in (4, 2, 5 , 3 , 1 , 7 , 8 , 9)  ) As dt 