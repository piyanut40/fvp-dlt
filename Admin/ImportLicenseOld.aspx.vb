Imports System.Data
Imports Npgsql
Imports System.IO
Imports Excel

Partial Class Admin_ImportLicenseOld
    Inherits System.Web.UI.Page

    Private populate As New PopulateDropDown
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_id") Is Nothing Then
            Session.Clear()
            Response.Redirect("../Login.aspx")
        ElseIf Session("user_id").ToString <> "adminbt" Then
            Session.Clear()
            Response.Redirect("../Login.aspx")
        End If
        If Page.IsPostBack = False Then
            populate.genAdminName(ddlAdminName, False)

            ddlAdminName.SelectedValue = 6

            If Request.QueryString("IsUpdate") = "1" Then

            Else
                lnkImport.Visible = False
            End If
        End If
    End Sub

    Private fPath As String = Server.MapPath(ConfigurationManager.AppSettings("FileExcel"))
    Private strTxtFile As New StringBuilder
    Dim NewLine As String = System.Environment.NewLine
    Protected Sub BtnImportExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles BtnImportExcel.Click
        If FileUpload1.HasFile Then
            ptxtFileNAME = "txtLicenseOldError-" & FileUpload1.FileName & ".txt"

            strTxtFile.Remove(0, strTxtFile.Length)
            strTxtFile.Append(NewLine & "--------------- สรุปไฟล์การนำเข้าข้อมูลใบอนุญาตรถท่องเที่ยวของเก่ามีดังนี้ ---------------" & NewLine)
            Try
                Dim fNews As FileInfo
                Dim xlsPath As String = fPath & FileUpload1.FileName
                If File.Exists(xlsPath) Then
                    fNews = New FileInfo(xlsPath)
                    fNews.Delete()
                End If
                FileUpload1.SaveAs(xlsPath)

                Dim dtExcel As DataTable = getData(xlsPath)
                If dtExcel.Rows.Count > 0 Then
                    dtExcel.Columns(1).ColumnName = "admin_name" 'สำนักงาน
                    dtExcel.Columns(2).ColumnName = "receipt_date" '"regis_date" 'วันที่ดำเนินการคือวันออกใบเสร็จ
                    'dtExcel.Columns(2).DataType() = System.Type.GetType("System.Date")
                    dtExcel.Columns(3).ColumnName = "license_no" 'เลขที่ใบอนุญาต
                    dtExcel.Columns(4).ColumnName = "start_date" 'วันที่เข้า
                    'dtExcel.Columns(4).DataType() = System.Type.GetType("System.Date")
                    dtExcel.Columns(5).ColumnName = "exp_date" 'วันที่ออก
                    'dtExcel.Columns(5).DataType() = System.Type.GetType("System.Date")
                    dtExcel.Columns(6).ColumnName = "country_car_th" 'ประเทศที่รถจดทะเบียน
                    dtExcel.Columns(7).ColumnName = "plate" 'เลขทะเบียน
                    dtExcel.Columns(8).ColumnName = "province_car" 'จังหวัด/รัฐ
                    dtExcel.Columns(9).ColumnName = "owner_name" 'เจ้าของรถ/ผู้ขอ
                    dtExcel.Columns(10).ColumnName = "typecar_th" 'ลักษณะรถ
                    dtExcel.Columns(11).ColumnName = "brands" 'ยี่ห้อรถ
                    dtExcel.Columns(12).ColumnName = "model" 'แบบ (MODEL)
                    dtExcel.Columns(13).ColumnName = "colors" 'สีรถ
                    dtExcel.Columns(14).ColumnName = "seat" 'ที่นั่ง	
                    dtExcel.Columns(15).ColumnName = "car_no" 'หมายเลขตัวถัง	
                    dtExcel.Columns(16).ColumnName = "engine_no" 'หมายเลขเครื่องยนต์	
                    dtExcel.Columns(17).ColumnName = "engine_cap" 'ความจุกระบอกสูบ(CC.)	
                    dtExcel.Columns(18).ColumnName = "weight0" 'น้ำหนักรถ
                    dtExcel.Columns(19).ColumnName = "weight" 'น้ำหนักรวม
                    dtExcel.Columns(20).ColumnName = "border_checkin" 'ด่านศุลกากรที่เข้า	
                    dtExcel.Columns(21).ColumnName = "border_checkout" 'ด่านศุลกากรที่ออก
                    dtExcel.Columns(22).ColumnName = "provarea" 'ท้องที่ใช้รถ(Province)
                    dtExcel.Columns(23).ColumnName = "name_company" 'ผู้ประกอบการธุรกิจนำเที่ยว
                    dtExcel.Columns(24).ColumnName = "company_license" 'ใบอนุญาตเลขที่
                    dtExcel.Columns(25).ColumnName = "registrar_name" 'นายทะเบียน	
                    dtExcel.Columns(26).ColumnName = "registrar_position" 'ตำแหน่ง	
                    dtExcel.Columns(27).ColumnName = "creator_name" 'ผู้ดำเนินการ	
                    dtExcel.Columns(28).ColumnName = "driver_name" 'คนขับ	
                    dtExcel.Columns(29).ColumnName = "passport_no" 'Passport	
                    dtExcel.Columns(30).ColumnName = "driver_name2" 'คนขับที่2
                    dtExcel.Columns(31).ColumnName = "passport_no2" 'Passport
                    dtExcel.AcceptChanges()




                    Dim dbConnect As New DBConnect
                    Dim cmd As New NpgsqlCommand
                    Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
                    Try
                        con.Open()
                        cmd.Connection = con



                        Dim CntInsert As Integer = 0
                        For Each dr As DataRow In dtExcel.Rows
                            Try
                                Dim is_insert_into_new_table As Boolean = True
                                If Not (is_insert_into_new_table) Then

                                    Dim OwnerPrename As String = ""
                                    Dim hasPrename As Boolean = True
                                    If dr("owner_name").ToString.ToUpper.Contains("MISS") Then
                                        OwnerPrename = "Miss."
                                    ElseIf dr("owner_name").ToString.ToUpper.Contains("MR.") Then
                                        OwnerPrename = "Mr."
                                    ElseIf dr("owner_name").ToString.ToUpper.Contains("MS.") Then
                                        OwnerPrename = "Ms."
                                    ElseIf dr("owner_name").ToString.ToUpper.Contains("MRS.") Then
                                        OwnerPrename = "Mrs."
                                    Else
                                        hasPrename = False
                                    End If

                                    Dim OwnerName, OwnerLastName As String
                                    If hasPrename Then
                                        Try
                                            Dim ArName As String() = dr("owner_name").ToString.Replace(OwnerPrename.ToUpper, "").Split(" ")
                                            OwnerName = IIf(OwnerPrename = "Miss.", ArName(1), ArName(0))
                                            If OwnerName = "" Then
                                                OwnerName = IIf(OwnerPrename = "Miss.", IIf(ArName(1) = "", ArName(2), ArName(1)), IIf(ArName(0) = "", ArName(1), ArName(0)))
                                            End If
                                            OwnerLastName = dr("owner_name").ToString.Replace(OwnerPrename.ToUpper, "").ToString.Replace(OwnerName, "").ToString.Replace("MISS", "")
                                        Catch ex As Exception
                                            OwnerName = dr("owner_name").ToString.Replace(OwnerPrename.ToUpper, "")
                                        End Try
                                    Else
                                        Dim ArName As String() = dr("owner_name").Split(" ")
                                        OwnerName = ArName(0)
                                        OwnerLastName = dr("owner_name").ToString.Replace(ArName(0), "")
                                    End If

                                    Dim typecar_id As Integer = 0
                                    If dr("typecar_th").ToString.Contains("รถยนต์นั่ง") Then

                                        typecar_id = 2
                                    ElseIf dr("typecar_th").ToString.Contains("รถจักรยานยนต์") Then
                                        typecar_id = 1
                                    ElseIf dr("typecar_th").ToString.Contains("รถยนต์บรรทุก") Then
                                        typecar_id = 7
                                    Else
                                        Try
                                            typecar_id = dbConnect.executeScalar("select type_id from type_car where type_name_th like '%" & dr("typecar_th") & "%' ")
                                        Catch ex As Exception
                                            typecar_id = 0
                                        End Try
                                    End If

                                    Dim country_car As Object = DBNull.Value
                                    If dr("country_car_th").ToString.Contains("เกาหลีเหนือ") Then
                                        country_car = "Korea (Democratic People Republic of)"
                                    ElseIf dr("country_car_th").ToString.Contains("ญี่ปุ่น") Then
                                        country_car = "Japan"
                                    ElseIf dr("country_car_th").ToString.Contains("ไต้หวัน") Then
                                        country_car = "Taiwan, Province of China"
                                    ElseIf dr("country_car_th").ToString.Contains("ราชอาณาจักรกัมพูชา") Then
                                        country_car = "Cambodia"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐโปแลนด์") Then
                                        country_car = "Poland"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐสังคมนิยมเวียดนาม") Then
                                        country_car = "Vietnam"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐแห่งสหภาพเมียนมา") Then
                                        country_car = "Myanmar"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐอินเดีย") Then
                                        country_car = "India"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐอินโดนีเซีย") Then
                                        country_car = "Indonesia"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐแอฟริกาใต้") Then
                                        country_car = "South Africa"
                                    End If

                                    '----- ข้อมูลรถ/เจ้าของรถ ----- 
                                    Dim strCar = " INSERT INTO car( owner_name, owner_lastname , owner_prename , plate , province_car , typecar_id , brands, model , colors , seat , car_no , engine_no , engine_cap , weight , country_car ) " & _
                                        " values( :owner_name, :owner_lastname , :owner_prename , :plate , :province_car , :typecar_id , :brands, :model , :colors , :seat , :car_no , :engine_no , :engine_cap , :weight , :country_car ) " & _
                                        " RETURNING car_id;"
                                    cmd.CommandText = CommandType.Text
                                    cmd.CommandText = strCar
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = OwnerName
                                    cmd.Parameters.Add("owner_lastname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = OwnerLastName
                                    If OwnerPrename = "" Then
                                        cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                    Else
                                        cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = OwnerPrename
                                    End If
                                    cmd.Parameters.Add("plate", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("plate")
                                    cmd.Parameters.Add("province_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("province_car")
                                    If typecar_id = 0 Then
                                        cmd.Parameters.Add("typecar_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = DBNull.Value
                                    Else
                                        cmd.Parameters.Add("typecar_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = typecar_id
                                    End If
                                    cmd.Parameters.Add("brands", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("brands")
                                    cmd.Parameters.Add("model", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("model")
                                    cmd.Parameters.Add("colors", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("colors")
                                    cmd.Parameters.Add("seat", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("seat")
                                    cmd.Parameters.Add("car_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("car_no")
                                    cmd.Parameters.Add("engine_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("engine_no")
                                    cmd.Parameters.Add("engine_cap", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("engine_cap")
                                    cmd.Parameters.Add("weight", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(dr("weight") = "-", dr("weight0"), dr("weight"))
                                    cmd.Parameters.Add("country_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = country_car
                                    Dim car_id As Object = cmd.ExecuteScalar()


                                    Dim DriverPrename As String = ""
                                    Dim DriverhasPrename As Boolean = True
                                    If dr("driver_name").ToString.ToUpper.Contains("MISS") Then
                                        DriverPrename = "Miss."
                                    ElseIf dr("driver_name").ToString.ToUpper.Contains("MR.") Then
                                        DriverPrename = "Mr."
                                    ElseIf dr("driver_name").ToString.ToUpper.Contains("MS.") Then
                                        DriverPrename = "Ms."
                                    ElseIf dr("driver_name").ToString.ToUpper.Contains("MRS.") Then
                                        DriverPrename = "Mrs."
                                    Else
                                        DriverhasPrename = False
                                    End If

                                    Dim DriverName, DriverLastName As String
                                    If DriverhasPrename Then
                                        Try
                                            Dim ArName As String() = dr("driver_name").ToString.Replace(DriverPrename.ToUpper, "").Split(" ")
                                            DriverName = IIf(DriverPrename = "Miss.", ArName(1), ArName(0))
                                            If DriverName = "" Then
                                                DriverName = IIf(DriverPrename = "Miss.", IIf(ArName(1) = "", ArName(2), ArName(1)), IIf(ArName(0) = "", ArName(1), ArName(0)))
                                            End If
                                            DriverLastName = dr("driver_name").ToString.Replace(DriverPrename.ToUpper, "").ToString.Replace(DriverName, "").ToString.Replace("MISS", "")
                                        Catch ex As Exception
                                            DriverName = dr("driver_name").ToString.Replace(DriverPrename.ToUpper, "")
                                        End Try
                                    Else
                                        Dim ArName As String() = dr("driver_name").Split(" ")
                                        DriverName = ArName(0)
                                        DriverLastName = dr("driver_name").ToString.Replace(ArName(0), "")
                                    End If

                                    '----- ข้อมูลคนขับรถ ----- 
                                    Dim strDriver = "Insert Into driver ( prename , name , surname , passport_no )  VALUES ( :prename , :name , :surname , :passport_no )" & _
                                    " RETURNING driver_id ; "
                                    cmd.CommandText = CommandType.Text
                                    cmd.CommandText = strDriver
                                    cmd.Parameters.Clear()
                                    If DriverPrename = "" Then
                                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                    Else
                                        cmd.Parameters.Add("prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DriverPrename
                                    End If
                                    cmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DriverName
                                    cmd.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DriverLastName
                                    cmd.Parameters.Add("passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("passport_no")
                                    Dim driver_id As Object = cmd.ExecuteScalar()


                               


                                    '-----  ข้อมูล User ผู้ประกอบการท่องเที่ยว ----- 
                                    Dim user_id As Object = DBNull.Value
                                    Try

                                        user_id = CInt(dbConnect.executeScalar("select max(user_id) from user_travel where company_license like '%" & dr("company_license") & "%' "))
                                    Catch ex As Exception
                                        Dim strUser = "Insert INTO user_travel (name_company , user_name , user_surname , idcard , company_license , user_type , username , pass, is_active )" & _
                                                      " VALUES (:name_company , :user_name , :user_surname , :idcard , :company_license , 2 , :username , :pass, 1 ) " & _
                                                      " RETURNING user_id; "
                                        cmd.CommandText = CommandType.Text
                                        cmd.CommandText = strUser
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.Add("name_company", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("name_company")
                                        cmd.Parameters.Add("user_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("user_surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("company_license", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("company_license")
                                        cmd.Parameters.Add("username", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value 'txtUsername.Text
                                        cmd.Parameters.Add("pass", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value 'dbConnect.password(txtUsername.Text, txtPassword.Text)
                                        user_id = cmd.ExecuteNonQuery()
                                    End Try

                                    Dim checkin_id As Object = DBNull.Value
                                    Try
                                        checkin_id = CInt(dbConnect.executeScalar("SELECT max(border_id) FROM  border_check where border_nameth like '%" & dr("border_checkin") & "%'"))
                                    Catch ex As Exception
                                        Dim strborderChk = "INSERT INTO border_check ( border_nameth, border_nameen, prov_code , border_country) " & _
                                                           " VALUES ( :border_nameth, :border_nameen, :prov_code , :border_country ) " & _
                                                           " RETURNING border_id; "
                                        cmd.CommandText = CommandType.Text
                                        cmd.CommandText = strborderChk
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.Add("border_nameth", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("border_checkin")
                                        cmd.Parameters.Add("border_nameen", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("border_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        checkin_id = cmd.ExecuteNonQuery()
                                        If checkin_id = -1 Then
                                            checkin_id = CInt(dbConnect.executeScalar("SELECT max(border_id) FROM  border_check "))
                                        End If
                                    End Try

                                    Dim checkout_id As Object = DBNull.Value
                                    Try
                                        checkout_id = CInt(dbConnect.executeScalar("SELECT max(border_id) FROM  border_check where border_nameth like '%" & dr("border_checkout") & "%'"))
                                    Catch ex As Exception
                                        Dim strborderChk = "INSERT INTO border_check ( border_nameth, border_nameen, prov_code , border_country) " & _
                                                           " VALUES ( :border_nameth, :border_nameen, :prov_code , :border_country ) " & _
                                                           " RETURNING border_id; "
                                        cmd.CommandText = CommandType.Text
                                        cmd.CommandText = strborderChk
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.Add("border_nameth", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("border_checkout")
                                        cmd.Parameters.Add("border_nameen", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("border_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        checkout_id = cmd.ExecuteNonQuery()
                                        If checkout_id = -1 Then
                                            checkout_id = CInt(dbConnect.executeScalar("SELECT max(border_id) FROM  border_check "))
                                        End If
                                    End Try

                                    '----- ข้อมูลกรุ๊ป ----- 
                                    Dim ar_startDate As String() = dr("start_date").ToString.Split("/")
                                    Dim ar_endDate As String() = dr("exp_date").ToString.Split("/")
                                    Dim startDate = New DateTime(ar_startDate(2), ar_startDate(1), ar_startDate(0))
                                    Dim endDate = New DateTime(ar_endDate(2), ar_endDate(1), ar_endDate(0))

                                    Dim strInsertGroup As String = "INSERT INTO travel_group ( group_name, is_active, start_date, exp_date, cntpeople , checkin_id , checkout_id , user_id , admin_id, travel_itinerary_filename, travel_itinerary_filesaved " & _
                                                " , is_renew , old_group_id, attachments_file_name, attachments_file_saved, reason ) " & _
                                                " VALUES (:group_name, 1, :start_date, :exp_date, :cntpeople , :checkin_id , :checkout_id , :user_id , :admin_id, :travel_itinerary_filename, :travel_itinerary_filesaved " & _
                                                " , 0 , 0, :attachments_file_name, :attachments_file_saved, :reason ) RETURNING group_id;  "
                                    cmd.CommandText = CommandType.Text
                                    cmd.CommandText = strInsertGroup
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add("group_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ""
                                    Try
                                        cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = startDate
                                    Catch ex As Exception
                                        cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value
                                    End Try
                                    Try
                                        cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = endDate
                                    Catch ex As Exception
                                        cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value
                                    End Try
                                    cmd.Parameters.Add("cntpeople", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0 'txtcntpeople.Text
                                    cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = checkin_id
                                    cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = checkout_id
                                    cmd.Parameters.Add("user_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = user_id
                                    cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlAdminName.SelectedValue
                                    cmd.Parameters.Add("travel_itinerary_filename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                                    cmd.Parameters.Add("travel_itinerary_filesaved", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                                    'If group_id Is Nothing Or Request.QueryString("is_renew").Contains(",0") Then 'Not Request.QueryString("is_renew") Is Nothing Then
                                    cmd.Parameters.Add("attachments_file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                                    cmd.Parameters.Add("attachments_file_saved", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                                    cmd.Parameters.Add("reason", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Nothing
                                    'End If
                                    Dim group_id As Object = cmd.ExecuteScalar()

                                    '----- ข้อมูลใบอนุญาต ----- 
                                    Dim ar_receipt_date As String() = dr("receipt_date").ToString.Split("/")
                                    Dim receipt_date = New DateTime(ar_receipt_date(2), ar_receipt_date(1), ar_receipt_date(0))
                                    Dim strInsertlicense As String = "Insert Into license ( driver_id , car_id , act_id , typeuser_id , travel_id , regis_date , fname , lname " & _
                                        " , license_no , status_id , start_date, exp_date , admin_id , checkin_id, checkout_id , registrar_name , registrar_position, receipt_date, user_app  ) " & _
                                        " VALUES ( :driver_id , :car_id , :act_id , 2 , :travel_id , :regis_date , :fname , :lname " & _
                                        " , :license_no , 5  , :start_date, :exp_date , :admin_id , :checkin_id, :checkout_id , :registrar_name , :registrar_position, :receipt_date, :user_app ) " & _
                                        " RETURNING license_id ;"
                                    cmd.CommandText = CommandType.Text
                                    cmd.CommandText = strInsertlicense
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add("driver_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = driver_id
                                    cmd.Parameters.Add("car_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = car_id
                                    cmd.Parameters.Add("act_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = DBNull.Value 'act_id
                                    cmd.Parameters.Add("travel_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = user_id 'Session("user_id")
                                    Try
                                        cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = receipt_date 'CDate(dr("receipt_date"))
                                    Catch ex As Exception
                                        cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value
                                    End Try
                                    cmd.Parameters.Add("fname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = OwnerName 'txtOwnerName.Text
                                    cmd.Parameters.Add("lname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = OwnerLastName 'txtOwnerLastName.Text
                                    cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("license_no")
                                    Try
                                        cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = startDate 'CDate(dr("start_date"))
                                    Catch ex As Exception
                                        cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value
                                    End Try
                                    Try
                                        cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = endDate 'CDate(dr("exp_date"))
                                    Catch ex As Exception
                                        cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value
                                    End Try
                                    cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlAdminName.SelectedValue
                                    cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = checkin_id
                                    cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = checkout_id
                                    cmd.Parameters.Add("registrar_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("registrar_name")
                                    cmd.Parameters.Add("registrar_position", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("registrar_position")
                                    Try
                                        cmd.Parameters.Add("receipt_date", NpgsqlTypes.NpgsqlDbType.Date).Value = receipt_date 'CDate(dr("receipt_date"))
                                    Catch ex As Exception
                                        cmd.Parameters.Add("receipt_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value
                                    End Try
                                    cmd.Parameters.Add("user_app", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlAdminName.SelectedValue
                                    Dim license_id As Object = cmd.ExecuteScalar()


                                    Dim strInsertgroup_car As String = "INSERT INTO travel_group_car( group_id, license_id) VALUES (:group_id, :license_id)"
                                    cmd.CommandText = CommandType.Text
                                    cmd.CommandText = strInsertgroup_car
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id
                                    cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = license_id
                                    cmd.ExecuteNonQuery()

                                    '----- Token and QRCode----- 
                                    Dim token As String = dbConnect.Token(license_id, car_id)
                                    Dim strUpdateToken As String = "Update license Set token=:token, qrcode = :qrcode WHERE license_id =" & license_id
                                    cmd.CommandText = CommandType.Text
                                    cmd.CommandText = strUpdateToken
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = token 'dbConnect.Token(license_id, car_id)
                                    cmd.Parameters.Add("qrcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.qrcode(token, 2)
                                    cmd.ExecuteNonQuery()

                                    '----- ท้องที่ใช้รถ(Province) ----- 
                                    Dim ArPro As String() = dr("provarea").ToString.Split("-")
                                    For i As Integer = 0 To ArPro.Length - 1
                                        Try
                                            Dim prov_th As Object = ArPro(i)
                                            Dim prov_code As Integer = dbConnect.executeScalar("select max(prov_code) from province where prov_th like '%" & prov_th & "%' ")

                                            cmd.CommandText = "Insert into area_group (prov_code , group_id ) VALUES (:prov_code , :group_id )"
                                            cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = prov_code
                                            cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id
                                            cmd.ExecuteNonQuery()
                                        Catch ex As Exception

                                        End Try
                                    Next
                                Else


                                    Dim OwnerPrename As String = ""
                                    Dim hasPrename As Boolean = True
                                    If dr("owner_name").ToString.ToUpper.Contains("MISS") Then
                                        OwnerPrename = "Miss."
                                    ElseIf dr("owner_name").ToString.ToUpper.Contains("MR.") Then
                                        OwnerPrename = "Mr."
                                    ElseIf dr("owner_name").ToString.ToUpper.Contains("MS.") Then
                                        OwnerPrename = "Ms."
                                    ElseIf dr("owner_name").ToString.ToUpper.Contains("MRS.") Then
                                        OwnerPrename = "Mrs."
                                    Else
                                        hasPrename = False
                                    End If

                                    Dim OwnerName, OwnerLastName As String
                                    If hasPrename Then
                                        Try
                                            Dim ArName As String() = dr("owner_name").ToString.Replace(OwnerPrename.ToUpper, "").Split(" ")
                                            OwnerName = IIf(OwnerPrename = "Miss.", ArName(1), ArName(0))
                                            If OwnerName = "" Then
                                                OwnerName = IIf(OwnerPrename = "Miss.", IIf(ArName(1) = "", ArName(2), ArName(1)), IIf(ArName(0) = "", ArName(1), ArName(0)))
                                            End If
                                            OwnerLastName = dr("owner_name").ToString.Replace(OwnerPrename.ToUpper, "").ToString.Replace(OwnerName, "").ToString.Replace("MISS", "")
                                        Catch ex As Exception
                                            OwnerName = dr("owner_name").ToString.Replace(OwnerPrename.ToUpper, "")
                                        End Try
                                    Else
                                        Dim ArName As String() = dr("owner_name").ToString.Trim.Split(" ")
                                        OwnerName = ArName(0)
                                        OwnerLastName = dr("owner_name").ToString.Replace(ArName(0), "")
                                    End If

                                    Dim typecar_id As Integer = 0
                                    If dr("typecar_th").ToString.Contains("รถยนต์นั่ง") Then

                                        typecar_id = 2
                                    ElseIf dr("typecar_th").ToString.Contains("รถจักรยานยนต์") Then
                                        typecar_id = 1
                                    ElseIf dr("typecar_th").ToString.Contains("รถยนต์บรรทุก") Then
                                        typecar_id = 7
                                    Else
                                        Try
                                            typecar_id = dbConnect.executeScalar("select type_id from type_car where type_name_th like '%" & dr("typecar_th") & "%' ")
                                        Catch ex As Exception
                                            typecar_id = 0
                                        End Try
                                    End If

                                    Dim country_car As Object = DBNull.Value
                                    
                                    If dr("country_car_th").ToString.Contains("กรีซ") Then
                                        country_car = "Greece"
                                    ElseIf dr("country_car_th").ToString.Contains("เกาหลีใต้") Then
                                        country_car = "Korea (Republic of Korea)"
                                    ElseIf dr("country_car_th").ToString.Contains("เกาหลีเหนือ") Then
                                        country_car = "Korea (Democratic People's Republic of Korea)"
                                    ElseIf dr("country_car_th").ToString.Contains("เครือรัฐออสเตรเลีย") Then
                                        country_car = "Australia"
                                    ElseIf dr("country_car_th").ToString.Contains("แคนาดา") Then
                                        country_car = "Canada"
                                    ElseIf dr("country_car_th").ToString.Contains("ญี่ปุ่น") Then
                                        country_car = "Japan"
                                    ElseIf dr("country_car_th").ToString.Contains("ไต้หวัน") Then
                                        country_car = "Taiwan, Province of China"
                                    ElseIf dr("country_car_th").ToString.Contains("นิวซีแลนด์") Then
                                        country_car = "New Zealand"
                                    ElseIf dr("country_car_th").ToString.Contains("บรูไนดารุสซาลาม") Then
                                        country_car = "Brunei Darussalam"
                                    ElseIf dr("country_car_th").ToString.Contains("ยูเครน") Then
                                        country_car = "Ukraine"
                                    ElseIf dr("country_car_th").ToString.Contains("ราชรัฐลักเซมเบิร์ก") Then
                                        country_car = "Luxembourg"
                                    ElseIf dr("country_car_th").ToString.Contains("ราชรัฐลิกเดนสไตน์") Or dr("country_car_th").ToString.Contains("ราชรัฐลิกเตนสไตน์") Then
                                        country_car = "Liechtenstein"
                                    ElseIf dr("country_car_th").ToString.Contains("ราชอาณาจักรกัมพูชา") Then
                                        country_car = "Cambodia"
                                    ElseIf dr("country_car_th").ToString.Contains("ราชอาณาจักรนอร์เวย์") Then
                                        country_car = "Norway" '
                                    ElseIf dr("country_car_th").ToString.Contains("ราชอาณาจักรเนเธอร์แลนด์") Then
                                        country_car = "Netherlands"
                                    ElseIf dr("country_car_th").ToString.Contains("ราชอาณาจักรเบลเยียม") Then
                                        country_car = "Belgium"
                                    ElseIf dr("country_car_th").ToString.Contains("ราชอาณาจักรสเปน") Then
                                        country_car = "Spain"
                                    ElseIf dr("country_car_th").ToString.Contains("ราชอาณาจักรสวีเดน") Then
                                        country_car = "Sweden"
                                    ElseIf dr("country_car_th").ToString.Contains("สวิตเซอร์แลนด์") Then
                                        country_car = "Switzerland"
                                    ElseIf dr("country_car_th").ToString.Contains("สหพันธรัฐรัสเซีย") Then
                                        country_car = "Russian Federation"
                                    ElseIf dr("country_car_th").ToString.Contains("สหพันธ์สาธารณรัฐบราซิล") Then
                                        country_car = "Brazil"
                                    ElseIf dr("country_car_th").ToString.Contains("สหพันธ์สาธารณรัฐเยอรมนี") Then
                                        country_car = "Germany"
                                    ElseIf dr("country_car_th").ToString.Contains("สหรัฐอเมริกา") Then
                                        country_car = "United States of America"
                                    ElseIf dr("country_car_th").ToString.Contains("สหรัฐอาหรับเอมิเรตส์") Then
                                        country_car = "United Arab Emirates"
                                    ElseIf dr("country_car_th").ToString.Contains("สหราชอาณาจักร") Then
                                        country_car = "United Kingdom" '"United Kingdom of Great Britain and Northern Ireland" 
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐตุรกี") Then
                                        country_car = "Turkey"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐประชาชนจีน") Then
                                        country_car = "China"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐโปแลนด์") Then
                                        country_car = "Poland"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐโปรตุเกส") Then
                                        country_car = "Portugal"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐฝรั่งเศส") Then
                                        country_car = "France"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐฟินแลนด์") Then
                                        country_car = "Finland"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐมอลตา") Then
                                        country_car = "Malta"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐสังคมนิยมเวียดนาม") Then
                                        country_car = "Vietnam"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐสิงคโปร์") Then
                                        country_car = "Singapore"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐแห่งสหภาพเมียนมา") Then
                                        country_car = "Myanmar" '
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐออสเตรีย") Then
                                        country_car = "Austria"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐอิตาลี") Then
                                        country_car = "Italy"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐอินเดีย") Then
                                        country_car = "India"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐอินโดนีเซีย") Then
                                        country_car = "Indonesia"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐเอสโตเนีย") Then
                                        country_car = "Estonia"
                                    ElseIf dr("country_car_th").ToString.Contains("สาธารณรัฐแอฟริกาใต้") Then
                                        country_car = "South Africa"
                                    ElseIf dr("country_car_th").ToString.Contains("ฮ่องกง") Then
                                        country_car = "Hong Kong"
                                    End If

                                    Dim DriverPrename As String = ""
                                    Dim DriverhasPrename As Boolean = True
                                    If dr("driver_name").ToString.ToUpper.Contains("MISS") Then
                                        DriverPrename = "Miss."
                                    ElseIf dr("driver_name").ToString.ToUpper.Contains("MR.") Then
                                        DriverPrename = "Mr."
                                    ElseIf dr("driver_name").ToString.ToUpper.Contains("MS.") Then
                                        DriverPrename = "Ms."
                                    ElseIf dr("driver_name").ToString.ToUpper.Contains("MRS.") Then
                                        DriverPrename = "Mrs."
                                    Else
                                        DriverhasPrename = False
                                    End If

                                    Dim DriverName, DriverLastName As String
                                    If DriverhasPrename Then
                                        Try
                                            Dim ArName As String() = dr("driver_name").ToString.Replace(DriverPrename.ToUpper, "").Split(" ")
                                            DriverName = IIf(DriverPrename = "Miss.", ArName(1), ArName(0))
                                            If DriverName = "" Then
                                                DriverName = IIf(DriverPrename = "Miss.", IIf(ArName(1) = "", ArName(2), ArName(1)), IIf(ArName(0) = "", ArName(1), ArName(0)))
                                            End If
                                            DriverLastName = dr("driver_name").ToString.Replace(DriverPrename.ToUpper, "").ToString.Replace(DriverName, "").ToString.Replace("MISS", "")
                                        Catch ex As Exception
                                            DriverName = dr("driver_name").ToString.Replace(DriverPrename.ToUpper, "")
                                        End Try
                                    Else
                                        Dim ArName As String() = dr("driver_name").ToString.Trim.Split(" ")
                                        DriverName = ArName(0)
                                        DriverLastName = dr("driver_name").ToString.Replace(ArName(0), "")
                                    End If

                                    Dim DriverPrename2 As String = ""
                                    Dim DriverhasPrename2 As Boolean = True
                                    If dr("driver_name2").ToString.ToUpper.Contains("MISS") Then
                                        DriverPrename2 = "Miss."
                                    ElseIf dr("driver_name2").ToString.ToUpper.Contains("MR.") Then
                                        DriverPrename2 = "Mr."
                                    ElseIf dr("driver_name2").ToString.ToUpper.Contains("MS.") Then
                                        DriverPrename2 = "Ms."
                                    ElseIf dr("driver_name2").ToString.ToUpper.Contains("MRS.") Then
                                        DriverPrename2 = "Mrs."
                                    Else
                                        DriverhasPrename2 = False
                                    End If

                                    Dim DriverName2, DriverLastName2 As String
                                    If DriverhasPrename2 Then
                                        Try
                                            Dim ArName2 As String() = dr("driver_name2").ToString.Replace(DriverPrename2.ToUpper, "").Split(" ")
                                            DriverName2 = IIf(DriverPrename2 = "Miss.", ArName2(1), ArName2(0))
                                            If DriverName2 = "" Then
                                                DriverName2 = IIf(DriverPrename2 = "Miss.", IIf(ArName2(1) = "", ArName2(2), ArName2(1)), IIf(ArName2(0) = "", ArName2(1), ArName2(0)))
                                            End If
                                            DriverLastName2 = dr("driver_name2").ToString.Replace(DriverPrename2.ToUpper, "").ToString.Replace(DriverName2, "").ToString.Replace("MISS", "")
                                        Catch ex As Exception
                                            DriverName2 = dr("driver_name2").ToString.Replace(DriverPrename2.ToUpper, "")
                                        End Try
                                    Else
                                        If dr("driver_name2").ToString.Trim <> "" Then
                                            Dim ArName2 As String() = dr("driver_name2").ToString.Trim.Split(" ")
                                            DriverName2 = ArName2(0)
                                            DriverLastName2 = dr("driver_name2").ToString.Replace(ArName2(0), "")
                                        Else
                                            DriverName2 = ""
                                            DriverLastName2 = ""
                                        End If

                                    End If

                                    '-----  ข้อมูล User ผู้ประกอบการท่องเที่ยว ----- 
                                    Dim user_id As Object = DBNull.Value
                                    Try

                                        user_id = CInt(dbConnect.executeScalar("select max(user_id) from user_travel where company_license like '%" & dr("company_license") & "%' "))
                                    Catch ex As Exception
                                        Dim strUser = "Insert INTO user_travel (name_company , user_name , user_surname , idcard , company_license , user_type , username , pass, is_active )" & _
                                                      " VALUES (:name_company , :user_name , :user_surname , :idcard , :company_license , 2 , :username , :pass, 1 ) " & _
                                                      " RETURNING user_id; "
                                        cmd.CommandText = CommandType.Text
                                        cmd.CommandText = strUser
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.Add("name_company", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("name_company")
                                        cmd.Parameters.Add("user_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("user_surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("idcard", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("company_license", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("company_license")
                                        cmd.Parameters.Add("username", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value 'txtUsername.Text
                                        cmd.Parameters.Add("pass", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value 'dbConnect.password(txtUsername.Text, txtPassword.Text)
                                        user_id = cmd.ExecuteNonQuery()
                                        If user_id = -1 Then
                                            user_id = CInt(dbConnect.executeScalar("SELECT max(user_id) from user_travel "))
                                        End If
                                    End Try

                                    Dim checkin_id As Object = DBNull.Value
                                    Try
                                        checkin_id = CInt(dbConnect.executeScalar("SELECT max(border_id) FROM  border_check where border_nameth like '%" & dr("border_checkin") & "%'"))
                                    Catch ex As Exception
                                        Dim strborderChk = "INSERT INTO border_check ( border_nameth, border_nameen, prov_code , border_country) " & _
                                                           " VALUES ( :border_nameth, :border_nameen, :prov_code , :border_country ) " & _
                                                           " RETURNING border_id; "
                                        cmd.CommandText = CommandType.Text
                                        cmd.CommandText = strborderChk
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.Add("border_nameth", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("border_checkin")
                                        cmd.Parameters.Add("border_nameen", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("border_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        checkin_id = cmd.ExecuteNonQuery()
                                        If checkin_id = -1 Then
                                            checkin_id = CInt(dbConnect.executeScalar("SELECT max(border_id) FROM  border_check "))
                                        End If
                                    End Try

                                    Dim checkout_id As Object = DBNull.Value
                                    Try
                                        checkout_id = CInt(dbConnect.executeScalar("SELECT max(border_id) FROM  border_check where border_nameth like '%" & dr("border_checkout") & "%'"))
                                    Catch ex As Exception
                                        Dim strborderChk = "INSERT INTO border_check ( border_nameth, border_nameen, prov_code , border_country) " & _
                                                           " VALUES ( :border_nameth, :border_nameen, :prov_code , :border_country ) " & _
                                                           " RETURNING border_id; "
                                        cmd.CommandText = CommandType.Text
                                        cmd.CommandText = strborderChk
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.Add("border_nameth", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("border_checkout")
                                        cmd.Parameters.Add("border_nameen", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        cmd.Parameters.Add("border_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                        checkout_id = cmd.ExecuteNonQuery()
                                        If checkout_id = -1 Then
                                            checkout_id = CInt(dbConnect.executeScalar("SELECT max(border_id) FROM  border_check "))
                                        End If
                                    End Try


                                    '----- ข้อมูลใบอนุญาต ----- 
                                    Dim str_start_date As Date = ConvertToDateTime(dr("start_date"))
                                    Dim ar_startDate As String() = str_start_date.ToString.Split("/") 'dr("start_date").ToString.Split("/")
                                    Dim str_exp_date As Date = ConvertToDateTime(dr("exp_date"))
                                    Dim ar_endDate As String() = str_exp_date.ToString.Split("/") 'dr("exp_date").ToString.Split("/")
                                    Dim startDate = New DateTime(ar_startDate(2).Substring(0, 4), ar_startDate(0), ar_startDate(1))
                                    Dim endDate = New DateTime(ar_endDate(2).Substring(0, 4), ar_endDate(0), ar_endDate(1))
                                    Dim str_receipt_date As Date = ConvertToDateTime(dr("receipt_date"))
                                    Dim ar_receipt_date As String() = str_receipt_date.ToString.Split("/") 'dr("receipt_date").ToString.Split("/")
                                    Dim receipt_date = New DateTime(ar_receipt_date(2).Substring(0, 4), ar_receipt_date(0), ar_receipt_date(1))
                                    
                                    Dim strInsertlicense As String = "Insert Into license_old ( typeuser_id , travel_id , regis_date , fname , lname , license_no , status_id , start_date, exp_date, admin_id , checkin_id, checkout_id  " & _
                                        " , registrar_name , registrar_position, receipt_date, creator_name, user_app, owner_name , owner_surname, owner_prename, plate, province_car, typecar_id, brands, model, colors, seat, car_no " & _
                                        " , engine_no, engine_cap, weight, weight_total, country_car, driver_prename, driver_name, driver_surname, driver_passport_no, driver_prename2, driver_name2, driver_surname2, driver_passport_no2, provarea, owner_fullname, driver_fullname, driver_fullname2) " & _
                                      " VALUES ( 2 , :travel_id , :regis_date , :fname , :lname , :license_no , 5  , :start_date, :exp_date, :admin_id , :checkin_id, :checkout_id  " & _
                                      " , :registrar_name , :registrar_position, :receipt_date, :creator_name, :user_app, :owner_name, :owner_surname, :owner_prename, :plate, :province_car, :typecar_id, :brands, :model, :colors, :seat, :car_no " & _
                                      " , :engine_no, :engine_cap, :weight, :weight_total, :country_car, :driver_prename, :driver_name, :driver_surname, :driver_passport_no, :driver_prename2, :driver_name2, :driver_surname2, :driver_passport_no2, :provarea, :owner_fullname, :driver_fullname, :driver_fullname2) " & _
                                      " RETURNING license_id ;"
                                    cmd.CommandText = CommandType.Text
                                    cmd.CommandText = strInsertlicense
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add("travel_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = user_id 'Session("user_id")
                                    Try
                                        cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = receipt_date 'CDate(dr("receipt_date"))
                                    Catch ex As Exception
                                        cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value
                                    End Try
                                    cmd.Parameters.Add("fname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = OwnerName.Trim 'txtOwnerName.Text
                                    cmd.Parameters.Add("lname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = OwnerLastName.Trim 'txtOwnerLastName.Text
                                    cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(dr("license_no").ToString.Trim = "", DBNull.Value, dr("license_no"))
                                    Try
                                        cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = startDate 'CDate(dr("start_date"))
                                    Catch ex As Exception
                                        cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value
                                    End Try
                                    Try
                                        cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = endDate 'CDate(dr("exp_date"))
                                    Catch ex As Exception
                                        cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value
                                    End Try
                                    cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlAdminName.SelectedValue
                                    cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = checkin_id
                                    cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = checkout_id
                                    cmd.Parameters.Add("registrar_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("registrar_name")
                                    cmd.Parameters.Add("registrar_position", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("registrar_position")
                                    Try
                                        cmd.Parameters.Add("receipt_date", NpgsqlTypes.NpgsqlDbType.Date).Value = receipt_date 'CDate(dr("receipt_date"))
                                    Catch ex As Exception
                                        cmd.Parameters.Add("receipt_date", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value
                                    End Try
                                    cmd.Parameters.Add("creator_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("creator_name")
                                    cmd.Parameters.Add("user_app", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlAdminName.SelectedValue
                                    cmd.Parameters.Add("owner_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = OwnerName.Trim
                                    cmd.Parameters.Add("owner_surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = OwnerLastName.Trim
                                    If OwnerPrename = "" Then
                                        cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                    Else
                                        cmd.Parameters.Add("owner_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = OwnerPrename
                                    End If
                                    cmd.Parameters.Add("plate", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("plate")
                                    cmd.Parameters.Add("province_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("province_car")
                                    If typecar_id = 0 Then
                                        cmd.Parameters.Add("typecar_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = DBNull.Value
                                    Else
                                        cmd.Parameters.Add("typecar_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = typecar_id
                                    End If
                                    cmd.Parameters.Add("brands", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("brands")
                                    cmd.Parameters.Add("model", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("model")
                                    cmd.Parameters.Add("colors", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("colors")
                                    cmd.Parameters.Add("seat", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("seat")
                                    cmd.Parameters.Add("car_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("car_no")
                                    cmd.Parameters.Add("engine_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("engine_no")
                                    cmd.Parameters.Add("engine_cap", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("engine_cap")
                                    cmd.Parameters.Add("weight", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("weight0") 'IIf(dr("weight") = "-", dr("weight0"), dr("weight"))
                                    cmd.Parameters.Add("weight_total", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("weight") 'IIf(dr("weight") = "-", dr("weight0"), dr("weight"))
                                    cmd.Parameters.Add("country_car", NpgsqlTypes.NpgsqlDbType.Varchar).Value = country_car
                                    If DriverPrename = "" Then
                                        cmd.Parameters.Add("driver_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                    Else
                                        cmd.Parameters.Add("driver_prename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DriverPrename
                                    End If
                                    cmd.Parameters.Add("driver_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DriverName.Trim
                                    cmd.Parameters.Add("driver_surname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DriverLastName.Trim
                                    cmd.Parameters.Add("driver_passport_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("passport_no")
                                    If DriverPrename2 = "" Then
                                        cmd.Parameters.Add("driver_prename2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                                    Else
                                        cmd.Parameters.Add("driver_prename2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DriverPrename2
                                    End If
                                    cmd.Parameters.Add("driver_name2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DriverName2.Trim
                                    cmd.Parameters.Add("driver_surname2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DriverLastName2.Trim
                                    cmd.Parameters.Add("driver_passport_no2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("passport_no2")
                                    cmd.Parameters.Add("provarea", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("provarea")
                                    cmd.Parameters.Add("owner_fullname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("owner_name")
                                    cmd.Parameters.Add("driver_fullname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("driver_name")
                                    cmd.Parameters.Add("driver_fullname2", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("driver_name2")
                                    Dim license_id As Object = cmd.ExecuteScalar()


                                    '----- Token and QRCode----- 
                                    Dim token As String = dbConnect.Token(license_id, -1)
                                    Dim strUpdateToken As String = "Update license_old Set token=:token, qrcode = :qrcode WHERE license_id =" & license_id
                                    cmd.CommandText = CommandType.Text
                                    cmd.CommandText = strUpdateToken
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = token 'dbConnect.Token(license_id, car_id)
                                    cmd.Parameters.Add("qrcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dbConnect.qrcode(token, 2)
                                    cmd.ExecuteNonQuery()


                                End If


                            Catch ex As Exception
                                strTxtFile.Append(NewLine & "ลำดับ : " & CntInsert) ' dr("index"))
                                strTxtFile.Append(" : ไม่สามารถบันทึกข้อมูลรถได้เนื่องจาก " & ex.Message.ToString)
                            End Try
                            CntInsert = CntInsert + 1
                        Next

                        If CntInsert > 0 Then
                            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ระบบได้นำเข้าข้อมูลใบอนุญาตรถท่องเที่ยวเรียบร้อยแล้ว');", True)
                        Else
                            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ระบบไม่สามารถนำเข้าข้อมูลได้ กรุณาตรวจสอบไฟล์ Excel');", True)
                        End If
                    Catch ex As Exception
                        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "alert('" & ex.Message.ToString & "');", True)
                    Finally
                        cmd.Connection.Close()
                        con.Close()
                        dbConnect = Nothing
                    End Try
                End If
                WriteTxtFile()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Shared Function ConvertToDateTime(ByVal strExcelDate As String) As String
        Dim excelDate As Double
        Try
            excelDate = Convert.ToDouble(strExcelDate)
        Catch
            Return strExcelDate
        End Try
        If excelDate < 1 Then
            Throw New ArgumentException("Excel dates cannot be smaller than 0.")
        End If
        Dim dateOfReference As New DateTime(1900, 1, 1)
        If excelDate > 60.0 Then
            excelDate = excelDate - 2
        Else
            excelDate = excelDate - 1
        End If
        Return dateOfReference.AddDays(excelDate).ToShortDateString()
    End Function

    Private ptxtFileNAME As String
    Private Sub WriteTxtFile()
        'Open a file for writing
        Dim FILENAME As String = fPath & ptxtFileNAME ' Server.MapPath("Output.txt")

        Dim fTxtFile As FileInfo
        If File.Exists(FILENAME) Then
            fTxtFile = New FileInfo(FILENAME)
            fTxtFile.Delete()
        End If

        'Get a StreamWriter class that can be used to write to the file
        Dim objStreamWriter As StreamWriter
        objStreamWriter = File.AppendText(FILENAME)

        'Append the the end of the string, "A user viewed this demo at: "
        'followed by the current date and time
        'objStreamWriter.WriteLine("A user viewed this demo at: " & DateTime.Now.ToString())
        objStreamWriter.WriteLine(strTxtFile.ToString)

        'Close the stream
        objStreamWriter.Close()

        'Read the file, displaying its contents

        'Get a StreamReader class that can be used to read the file
        Dim objStreamReader As StreamReader
        objStreamReader = File.OpenText(FILENAME)

        'Now, read the entire file into a string
        Dim contents As String = objStreamReader.ReadToEnd()

        'We may wish to replace carraige returns with <br>s
        'lblNicerOutput.Text = contents.Replace(vbCrLf, "<br>")

        objStreamReader.Close()
    End Sub

    Private Function getData(ByVal xlsPath As String) As DataTable
        Dim dtFile As New DataTable
        Dim srcExt As String = ""
        Try
            Dim stream As FileStream
            Dim excelReader As IExcelDataReader
            If xlsPath.ToString <> "" Then

                srcExt = Path.GetExtension(xlsPath)

                stream = File.Open(xlsPath, FileMode.Open, FileAccess.Read)

                If srcExt.ToLower.Trim = ".xls" Then
                    '1. Reading from a binary Excel file ('97-2003 format; *.xls)
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream)
                ElseIf srcExt.ToLower.Trim = ".xlsx" Then
                    '2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream)
                End If


                ''...
                ''3. DataSet - The result of each spreadsheet will be created in the result.Tables
                'Dim result As DataSet = excelReader.AsDataSet()
                '...
                '4. DataSet - Create column names from first row
                excelReader.IsFirstRowAsColumnNames = True

                Dim dsFile As DataSet = excelReader.AsDataSet()


                Dim dv As New DataView
                Dim dt As DataTable

                dv.Table = dsFile.Tables(0)

                dt = dv.ToTable

                dtFile = dt
                ''5. Data Reader methods
                'While excelReader.Read()
                '    excelReader.GetInt32(0)
                'End While

                '6. Free resources (IExcelDataReader is IDisposable)
                excelReader.Close()


            Else
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", " alert('ไม่สามารถนำข้อมูลเข้าได้ กรุณาแนบไฟล์'); ", True)
            End If

        Catch ex As Exception
            If srcExt.ToLower.Trim = ".xlsx" Then
                Dim script As String = " alert('ไม่สามารถเปิดไฟล์ Excel 2007 ได้ '); "
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            ElseIf ex.Message.Length > 100 Then
                Dim lbl As String = ex.Message.Substring(0, 50)
                'If lbl.IndexOf("The Microsoft Jet database engine cannot open") > 0 Then
                If lbl = "The Microsoft Jet database engine cannot open the " Then
                    Dim script As String = " alert('ไม่สามารถเปิดไฟล์ Excel ได้ กรุณาปิดไฟล์'); "
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                Else
                    Dim script As String = " alert('เกิดข้อผิดพลาด:: " & ex.Message & " ไม่สามารถเพิ่มข้อมูลได้'); "
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                End If
            Else
                Dim script As String = " alert('เกิดข้อผิดพลาด:: " & ex.Message & " ไม่สามารถเพิ่มข้อมูลได้'); "
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            End If
        Finally

        End Try
        Return dtFile
    End Function

    Protected Sub lnkImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkImport.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con

            cmd.CommandText = "DELETE FROM border_check where border_id not in (select distinct checkin_id from ( select checkin_id from license union all select checkout_id from license ) dt where checkin_id is not null ) "
            cmd.ExecuteNonQuery()

            Dim dtCustom As DataTable = dbConnect.getDataTable("select p_code , point_x, point_y, name_t2, name_e2 from custom2 ", "Customlist")
            For Each dr As DataRow In dtCustom.Rows
                Dim checkin_id As Object = DBNull.Value
                Try
                    checkin_id = CInt(dbConnect.executeScalar("SELECT max(border_id) FROM  border_check where border_nameth like '%" & dr("name_t2") & "%'"))
                Catch ex As Exception
                    Dim strborderChk = "INSERT INTO border_check ( border_nameth, border_nameen, prov_code , border_country , lat , lon ) " & _
                                       " VALUES ( :border_nameth, :border_nameen, :prov_code , :border_country , :lat , :lon) "
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = strborderChk
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("border_nameth", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("name_t2")
                    cmd.Parameters.Add("border_nameen", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("name_e2")
                    cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = dr("p_code")
                    cmd.Parameters.Add("border_country", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DBNull.Value
                    cmd.Parameters.Add("lat", NpgsqlTypes.NpgsqlDbType.Double).Value = dr("point_y")
                    cmd.Parameters.Add("lon", NpgsqlTypes.NpgsqlDbType.Double).Value = dr("point_x")
                    cmd.ExecuteNonQuery()
                End Try
            Next

            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ระบบทำการปรับปรุงข้อมูลด่านเรียบร้อยแล้ว');", True)
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "alert('" & ex.Message.ToString & "');", True)
        Finally
            cmd.Connection.Close()
            con.Close()
            dbConnect = Nothing
        End Try
    End Sub
End Class
