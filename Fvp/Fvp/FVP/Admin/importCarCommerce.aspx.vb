Imports System.Data
Imports Npgsql
Imports System.IO
Imports Excel

Partial Class Admin_importCarCommerce
    Inherits System.Web.UI.Page
    Protected text As String
    Private populate As New PopulateDropDown

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_id").ToString <> "adminbt" Then
            Session.Clear()
            Response.Redirect("../Login.aspx")
        End If
        If Page.IsPostBack = False Then
            text = "นำเข้าข้อมูลรถตามความตกลงระหว่างประเทศรถขนส่งเชิงพาณิชย์"
            populate.genDDLCountry(ddlCountry, False)
        End If


    End Sub

    Private fPath As String = Server.MapPath(ConfigurationManager.AppSettings("FileExcel"))
    Private strTxtFile As New StringBuilder
    Dim NewLine As String = System.Environment.NewLine
    Protected Sub BtnImportExcel_Click(sender As Object, e As System.EventArgs) 'Handles BtnImportExcel.Click
        If FileUpload1.HasFile Then
            ptxtFileNAME = "txtCarCommerceError-" & FileUpload1.FileName & ".txt"

            strTxtFile.Remove(0, strTxtFile.Length)
            strTxtFile.Append(NewLine & "--------------- สรุปไฟล์การนำเข้าข้อมูลรถตามความตกลงระหว่างประเทศรถขนส่งเชิงพาณิชย์ที่ไม่สำเร็จมีดังนี้ ---------------" & NewLine)
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
                    dtExcel.Columns(0).ColumnName = "index"
                    dtExcel.Columns(1).ColumnName = "_language"
                    dtExcel.Columns(2).ColumnName = "permit_no"
                    dtExcel.Columns(3).ColumnName = "issue_date"
                    dtExcel.Columns(4).ColumnName = "issue_place"
                    dtExcel.Columns(5).ColumnName = "expiry_date"
                    dtExcel.Columns(6).ColumnName = "extended_until"
                    dtExcel.Columns(7).ColumnName = "issuing_authority"
                    dtExcel.Columns(8).ColumnName = "tad_no"
                    dtExcel.Columns(9).ColumnName = "transport_operator_name"
                    dtExcel.Columns(10).ColumnName = "address"
                    dtExcel.Columns(11).ColumnName = "province"
                    dtExcel.Columns(12).ColumnName = "telephone"
                    dtExcel.Columns(13).ColumnName = "email"
                    dtExcel.Columns(14).ColumnName = "vehicle_owner_name"
                    dtExcel.Columns(15).ColumnName = "vehicle_owner_address"
                    dtExcel.Columns(16).ColumnName = "vehicle_owner_province"
                    dtExcel.Columns(17).ColumnName = "vehicle_owner_telephone"
                    dtExcel.Columns(18).ColumnName = "vehicle_owner_email"
                    dtExcel.Columns(19).ColumnName = "vehicle_type"
                    dtExcel.Columns(20).ColumnName = "registration_no"
                    dtExcel.Columns(21).ColumnName = "semi_trailer"
                    dtExcel.Columns(22).ColumnName = "vehicle_category"
                    dtExcel.Columns(23).ColumnName = "regis_date"
                    dtExcel.Columns(24).ColumnName = "regis_province"
                    dtExcel.Columns(25).ColumnName = "brand"
                    dtExcel.Columns(26).ColumnName = "model"
                    dtExcel.Columns(27).ColumnName = "vin_no"
                    dtExcel.Columns(28).ColumnName = "engine_no"
                    dtExcel.Columns(29).ColumnName = "axles_no"
                    dtExcel.Columns(30).ColumnName = "colour"
                    dtExcel.Columns(31).ColumnName = "capacity_cc"
                    dtExcel.Columns(32).ColumnName = "weight_gross"
                    dtExcel.Columns(33).ColumnName = "weight_net"
                    dtExcel.Columns(34).ColumnName = "seats_no"
                    dtExcel.Columns(35).ColumnName = "width"
                    dtExcel.Columns(36).ColumnName = "length"
                    dtExcel.Columns(37).ColumnName = "height"
                    'dtExcel.Columns(37).ColumnName = ""
                    dtExcel.AcceptChanges()

                    Dim db As New DBConnect
                    Dim cmd As New NpgsqlCommand
                    Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
                    'Dim transaction As NpgsqlTransaction
                    Dim CntInsert As Integer = 0
                    Dim index As Object
                    Try
                        con.Open()
                        cmd.Connection = con
                        'transaction = con.BeginTransaction()

                        Dim StrInsert As String = " INSERT INTO car_commerce (_language, permit_no, issue_date, issue_place, expiry_date, " & _
                        " extended_until, issuing_authority, tad_no, transport_operator_name, " & _
                        " address, province, telephone, email, vehicle_owner_name, vehicle_owner_address, " & _
                        " vehicle_owner_province, vehicle_owner_telephone, vehicle_owner_email, " & _
                        " vehicle_type, registration_no, vehicle_category, regis_date, " & _
                        " regis_province, brand, model, vin_no, engine_no, axles_no, colour, " & _
                        " capacity_cc, weight_gross, weight_net, seats_no, width, length,  height , import_date , semi_trailer , country_car) " & _
                         " VALUES (  :_language, :permit_no, :issue_date, :issue_place, :expiry_date, " & _
                        " :extended_until, :issuing_authority, :tad_no, :transport_operator_name, " & _
                        " :address, :province, :telephone, :email, :vehicle_owner_name, :vehicle_owner_address, " & _
                        " :vehicle_owner_province, :vehicle_owner_telephone, :vehicle_owner_email, " & _
                        " :vehicle_type, :registration_no, :vehicle_category, :regis_date, " & _
                        " :regis_province, :brand, :model, :vin_no, :engine_no, :axles_no, :colour, " & _
                        " :capacity_cc, :weight_gross, :weight_net, :seats_no, :width, :length,  :height , now() , :semi_trailer , :country_car) "
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("_language", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("permit_no", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("issue_date", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("issue_place", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("expiry_date", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("extended_until", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("issuing_authority", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("tad_no", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("transport_operator_name", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("province", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("telephone", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("vehicle_owner_name", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("vehicle_owner_address", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("vehicle_owner_province", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("vehicle_owner_telephone", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("vehicle_owner_email", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("vehicle_type", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("registration_no", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("vehicle_category", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date)
                        cmd.Parameters.Add("regis_province", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("brand", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("model", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("vin_no", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("engine_no", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("axles_no", NpgsqlTypes.NpgsqlDbType.Integer)
                        cmd.Parameters.Add("colour", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("capacity_cc", NpgsqlTypes.NpgsqlDbType.Double)
                        cmd.Parameters.Add("weight_gross", NpgsqlTypes.NpgsqlDbType.Double)
                        cmd.Parameters.Add("weight_net", NpgsqlTypes.NpgsqlDbType.Double)
                        cmd.Parameters.Add("seats_no", NpgsqlTypes.NpgsqlDbType.Double)
                        cmd.Parameters.Add("width", NpgsqlTypes.NpgsqlDbType.Double)
                        cmd.Parameters.Add("length", NpgsqlTypes.NpgsqlDbType.Double)
                        cmd.Parameters.Add("height", NpgsqlTypes.NpgsqlDbType.Double)
                        cmd.Parameters.Add("semi_trailer", NpgsqlTypes.NpgsqlDbType.Varchar)
                        cmd.Parameters.Add("country_car", NpgsqlTypes.NpgsqlDbType.Varchar)
                        Dim Cur_types As String = ""
                        Dim _language, permit_no, issue_date, issue_place, expiry_date, extended_until, issuing_authority, _
                                    tad_no, transport_operator_name, address, province, telephone, email, vehicle_owner_name, vehicle_owner_address, vehicle_owner_province, _
                                    vehicle_owner_telephone, vehicle_owner_email, vehicle_type, registration_no, vehicle_category, p_regis_date, _
                                    regis_province, brand, model, vin_no, engine_no, axles_no, colour, capacity_cc, weight_gross, _
                                    weight_net, seats_no, width, length, height, semi_trailer, country_car As Object
                        Dim test As Object = ""
                        For Each dr As DataRow In dtExcel.Rows
                            Try


                                Dim regisdate As DateTime = Nothing
                                If dr("_language") Is DBNull.Value Then
                                    If Not dr("registration_no") Is DBNull.Value And _language <> "中文" Then
                                        If Not dr("registration_no") Is DBNull.Value Then
                                            registration_no = dr("registration_no")
                                        End If
                                        If Not dr("vehicle_category") Is DBNull.Value Then
                                            vehicle_category = dr("vehicle_category")
                                        End If
                                        If Not dr("regis_date") Is DBNull.Value Then
                                            p_regis_date = dr("regis_date")
                                        End If
                                        If Not dr("regis_province") Is DBNull.Value Then
                                            regis_province = dr("regis_province")
                                        End If
                                        If Not dr("model") Is DBNull.Value Then
                                            model = dr("model")
                                        End If
                                        If Not dr("brand") Is DBNull.Value Then
                                            brand = dr("brand")
                                        End If
                                        If Not dr("vin_no") Is DBNull.Value Then
                                            vin_no = dr("vin_no")
                                        End If
                                        If Not dr("engine_no") Is DBNull.Value Then
                                            engine_no = dr("engine_no")
                                        End If
                                        If Not dr("axles_no") Is DBNull.Value Then
                                            axles_no = dr("axles_no")
                                        End If
                                        If Not dr("colour") Is DBNull.Value Then
                                            colour = dr("colour")
                                        End If
                                        If Not dr("capacity_cc") Is DBNull.Value Then
                                            capacity_cc = dr("capacity_cc")
                                        End If
                                        If Not dr("weight_gross") Is DBNull.Value Then
                                            weight_gross = dr("weight_gross")
                                        End If
                                        If Not dr("weight_net") Is DBNull.Value Then
                                            weight_net = dr("weight_net")
                                        End If
                                        If Not dr("seats_no") Is DBNull.Value Then
                                            seats_no = dr("seats_no")
                                        End If
                                        If Not dr("width") Is DBNull.Value Then
                                            width = dr("width")
                                        End If
                                        If Not dr("length") Is DBNull.Value Then
                                            length = dr("length")
                                        End If
                                        If Not dr("height") Is DBNull.Value Then
                                            height = dr("height")
                                        End If
                                        If Not dr("semi_trailer") Is DBNull.Value Then
                                            semi_trailer = dr("semi_trailer")
                                        End If
                                        INSERTCarCommerce(StrInsert, cmd, index, _language, permit_no, issue_date, issue_place, expiry_date, extended_until, issuing_authority, _
                                            tad_no, transport_operator_name, address, province, telephone, email, vehicle_owner_name, vehicle_owner_address, vehicle_owner_province, _
                                            vehicle_owner_telephone, vehicle_owner_email, vehicle_type, registration_no, vehicle_category, p_regis_date, _
                                            regis_province, brand, model, vin_no, engine_no, axles_no, colour, capacity_cc, weight_gross, _
                                            weight_net, seats_no, width, length, height, semi_trailer, ddlCountry.SelectedValue)
                                        CntInsert = CntInsert + 1
                                    End If
                                ElseIf dr("_language").ToString.Contains("中文") Then
                                    If Not dr("index") Is DBNull.Value Then
                                        index = dr("index")
                                    End If
                                    If Not dr("_language") Is DBNull.Value Then
                                        _language = dr("_language")
                                    End If
                                ElseIf dr("_language").ToString.Contains("English") Then
                                    If Not dr("index") Is DBNull.Value Then
                                        index = dr("index")
                                    End If
                                    If Not dr("_language") Is DBNull.Value Then
                                        _language = dr("_language")
                                    End If
                                    If Not dr("permit_no") Is DBNull.Value Then
                                        permit_no = dr("permit_no")
                                    End If
                                    If Not dr("issue_date") Is DBNull.Value Then
                                        issue_date = dr("issue_date")
                                    End If
                                    If Not dr("issue_place") Is DBNull.Value Then
                                        issue_place = dr("issue_place")
                                    End If
                                    If Not dr("expiry_date") Is DBNull.Value Then
                                        expiry_date = dr("expiry_date")
                                    End If
                                    If Not dr("extended_until") Is DBNull.Value Then
                                        extended_until = dr("extended_until")
                                    End If
                                    If Not dr("issuing_authority") Is DBNull.Value Then
                                        issuing_authority = dr("issuing_authority")
                                    End If
                                    If Not dr("tad_no") Is DBNull.Value Then
                                        tad_no = dr("tad_no")
                                    End If
                                    If Not dr("transport_operator_name") Is DBNull.Value Then
                                        transport_operator_name = dr("transport_operator_name")
                                    End If
                                    If Not dr("address") Is DBNull.Value Then
                                        address = dr("address")
                                    End If
                                    If Not dr("province") Is DBNull.Value Then
                                        province = dr("province")
                                    End If
                                    If Not dr("telephone") Is DBNull.Value Then
                                        telephone = dr("telephone")
                                    End If
                                    If Not dr("email") Is DBNull.Value Then
                                        email = dr("email")
                                    End If
                                    If Not dr("vehicle_owner_name") Is DBNull.Value Then
                                        vehicle_owner_name = dr("vehicle_owner_name")
                                    End If
                                    If Not dr("vehicle_owner_address") Is DBNull.Value Then
                                        vehicle_owner_address = dr("vehicle_owner_address")
                                    End If
                                    If Not dr("vehicle_owner_province") Is DBNull.Value Then
                                        vehicle_owner_province = dr("vehicle_owner_province")
                                    End If
                                    If Not dr("vehicle_owner_telephone") Is DBNull.Value Then
                                        vehicle_owner_telephone = dr("vehicle_owner_telephone")
                                    End If
                                    If Not dr("vehicle_owner_email") Is DBNull.Value Then
                                        vehicle_owner_email = dr("vehicle_owner_email")
                                    End If
                                    If Not dr("vehicle_type") Is DBNull.Value Then
                                        vehicle_type = dr("vehicle_type")
                                    End If
                                    If Not dr("registration_no") Is DBNull.Value Then
                                        registration_no = dr("registration_no")
                                    End If
                                    If Not dr("vehicle_category") Is DBNull.Value Then
                                        vehicle_category = dr("vehicle_category")
                                    End If
                                    If Not dr("regis_date") Is DBNull.Value Then
                                        p_regis_date = dr("regis_date")
                                    End If
                                    If Not dr("regis_province") Is DBNull.Value Then
                                        regis_province = dr("regis_province")
                                    End If
                                    If Not dr("model") Is DBNull.Value Then
                                        model = dr("model")
                                    End If
                                    If Not dr("brand") Is DBNull.Value Then
                                        brand = dr("brand")
                                    End If
                                    If Not dr("vin_no") Is DBNull.Value Then
                                        vin_no = dr("vin_no")
                                    End If
                                    If Not dr("engine_no") Is DBNull.Value Then
                                        engine_no = dr("engine_no")
                                    End If
                                    If Not dr("axles_no") Is DBNull.Value Then
                                        axles_no = dr("axles_no")
                                    End If
                                    If Not dr("colour") Is DBNull.Value Then
                                        colour = dr("colour")
                                    End If
                                    If Not dr("capacity_cc") Is DBNull.Value Then
                                        capacity_cc = dr("capacity_cc")
                                    End If
                                    If Not dr("weight_gross") Is DBNull.Value Then
                                        weight_gross = dr("weight_gross")
                                    End If
                                    If Not dr("weight_net") Is DBNull.Value Then
                                        weight_net = dr("weight_net")
                                    End If
                                    If Not dr("seats_no") Is DBNull.Value Then
                                        seats_no = dr("seats_no")
                                    End If
                                    If Not dr("width") Is DBNull.Value Then
                                        width = dr("width")
                                    End If
                                    If Not dr("length") Is DBNull.Value Then
                                        length = dr("length")
                                    End If
                                    If Not dr("height") Is DBNull.Value Then
                                        height = dr("height")
                                    End If
                                    If Not dr("semi_trailer") Is DBNull.Value Then
                                        semi_trailer = dr("semi_trailer")
                                    End If


                                    INSERTCarCommerce(StrInsert, cmd, index, _language, permit_no, issue_date, issue_place, expiry_date, extended_until, issuing_authority, _
                                    tad_no, transport_operator_name, address, province, telephone, email, vehicle_owner_name, vehicle_owner_address, vehicle_owner_province, _
                                    vehicle_owner_telephone, vehicle_owner_email, vehicle_type, registration_no, vehicle_category, p_regis_date, _
                                    regis_province, brand, model, vin_no, engine_no, axles_no, colour, capacity_cc, weight_gross, _
                                    weight_net, seats_no, width, length, height, semi_trailer, ddlCountry.SelectedValue)

                                    CntInsert = CntInsert + 1

                                   
                                End If

                            Catch ex As Exception
                                strTxtFile.Append(NewLine & "ลำดับ : " & index) ' dr("index"))
                                strTxtFile.Append(" : ไม่สามารถบันทึกข้อมูลรถได้เนื่องจาก " & ex.Message.ToString)
                            End Try
                        Next

                        cmd.CommandText = " UPDATE license SET regis_date = subquery.ddd FROM ( " & _
                        "   select car_id , regis_date as ddd  from car_commerce where regis_date is not null " & _
                        " ) AS subquery WHERE license.car_id = subquery.car_id and typeuser_id = 5 and regis_date is null "
                        cmd.ExecuteNonQuery()

                        'transaction.Commit()


                        If CntInsert > 0 Then
                            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ระบบได้นำเข้าข้อมูลรถตามความตกลงระหว่างประเทศรถขนส่งเชิงพาณิชย์เรียบร้อยแล้ว');", True)
                        Else
                            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ระบบไม่สามารถนำเข้าข้อมูลได้ กรุณาตรวจสอบไฟล์ Excel');", True)
                        End If

                    Catch ex As Exception

                    Finally
                        db = Nothing
                        cmd.Connection.Close()
                        con.Close()

                    End Try
                    WriteTxtFile()
                End If

            Catch ex As Exception
                If ex.Message.ToString().Contains("") Then
                    Label1.Text = "ERROR: " & ex.Message.ToString() & " กรุณาตรวจสอบว่ามี ฟิลด์ Semi-trailer อยู่รึป่าว?"
                Else
                    Label1.Text = "ERROR: " & ex.Message.ToString()
                End If

            End Try
        Else
            Label1.Text = "You have not specified a file."
        End If
    End Sub

    Private Sub INSERTCarCommerce(ByVal StrInsert As String, ByVal cmd As NpgsqlCommand,
                                  ByVal index As Object, ByVal _language As Object, ByVal permit_no As Object, ByVal issue_date As Object, ByVal issue_place As Object, ByVal expiry_date As Object, ByVal extended_until As Object, ByVal issuing_authority As Object, _
                                  ByVal tad_no As Object, ByVal transport_operator_name As Object, ByVal address As Object, ByVal province As Object, ByVal telephone As Object, ByVal email As Object, ByVal vehicle_owner_name As Object, ByVal vehicle_owner_address As Object, ByVal vehicle_owner_province As Object, _
                                  ByVal vehicle_owner_telephone As Object, ByVal vehicle_owner_email As Object, ByVal vehicle_type As Object, ByVal registration_no As Object, ByVal vehicle_category As Object, ByVal p_regis_date As Object, _
                                  ByVal regis_province As Object, ByVal brand As Object, ByVal model As Object, ByVal vin_no As Object, ByVal engine_no As Object, ByVal axles_no As Object, ByVal colour As Object, ByVal capacity_cc As Object, ByVal weight_gross As Object, _
                                  ByVal weight_net As Object, ByVal seats_no As Object, ByVal width As Object, ByVal length As Object, ByVal height As Object, ByVal semi_trailer As Object, ByVal country_car As Object)
        Dim regisdate As DateTime = Nothing
        cmd.CommandText = StrInsert
        cmd.Parameters.Item("_language").Value = _language 'dr("_language")
        cmd.Parameters.Item("permit_no").Value = permit_no 'dr("permit_no")
        cmd.Parameters.Item("issue_date").Value = issue_date 'dr("issue_date")
        cmd.Parameters.Item("issue_place").Value = issue_place ' dr("issue_place")
        cmd.Parameters.Item("expiry_date").Value = expiry_date 'dr("expiry_date")
        cmd.Parameters.Item("extended_until").Value = extended_until ' dr("extended_until")
        cmd.Parameters.Item("issuing_authority").Value = issuing_authority 'dr("issuing_authority")
        cmd.Parameters.Item("tad_no").Value = tad_no 'dr("tad_no")
        cmd.Parameters.Item("transport_operator_name").Value = transport_operator_name 'dr("transport_operator_name")
        cmd.Parameters.Item("address").Value = address 'dr("address")
        cmd.Parameters.Item("province").Value = province 'dr("province")
        cmd.Parameters.Item("telephone").Value = telephone 'dr("telephone")
        cmd.Parameters.Item("email").Value = email 'dr("email")
        cmd.Parameters.Item("vehicle_owner_name").Value = vehicle_owner_name 'dr("vehicle_owner_name")
        cmd.Parameters.Item("vehicle_owner_address").Value = vehicle_owner_address 'dr("vehicle_owner_address")
        cmd.Parameters.Item("vehicle_owner_province").Value = vehicle_owner_province 'dr("vehicle_owner_province")
        cmd.Parameters.Item("vehicle_owner_telephone").Value = vehicle_owner_telephone 'dr("vehicle_owner_telephone")
        cmd.Parameters.Item("vehicle_owner_email").Value = vehicle_owner_email 'dr("vehicle_owner_email")
        cmd.Parameters.Item("vehicle_type").Value = vehicle_type 'dr("vehicle_type")
        cmd.Parameters.Item("registration_no").Value = registration_no 'dr("registration_no")
        cmd.Parameters.Item("vehicle_category").Value = vehicle_category 'dr("vehicle_category")

        If p_regis_date Is DBNull.Value Then 'dr("regis_date") Is DBNull.Value Then
            cmd.Parameters.Item("regis_date").Value = DBNull.Value
        Else
            Try
                Dim val As Double = Double.Parse(p_regis_date) 'dr("regis_date"))
                regisdate = DateTime.FromOADate(val)
                cmd.Parameters.Item("regis_date").Value = CDate(regisdate)
            Catch ex As Exception
               
                If p_regis_date.ToString.Contains("-") And p_regis_date.ToString.Contains(".") Then
                    Try
                        Dim dd As String = p_regis_date.ToString.Substring(8, 2)
                        Dim mm As String = p_regis_date.ToString.Substring(5, 2)
                        Dim yyyy As String = p_regis_date.ToString.Substring(0, 4)
                        'Dim thCul As New System.Globalization.CultureInfo("th-TH")
                        Dim dayRegis As Date = CDate(dd & " / " & mm & " / " & yyyy).ToString("dd/MM/yyyy") ', thCul)
                        cmd.Parameters.Item("regis_date").Value = dayRegis
                    Catch ex1 As Exception
                        strTxtFile.Append(NewLine & "ลำดับ : " & index)
                        strTxtFile.Append(" : ไม่สามารถบันทึกข้อมูลรถได้เนื่องจาก format Date of Registration ไม่ถูกต้อง (" & p_regis_date & ") ")
                    End Try

                ElseIf p_regis_date.ToString.Contains(".") Then
                    Try
                        Dim Ar As String() = p_regis_date.ToString.Split(".")
                        Dim dayRegis As Date = CDate(Ar(2) & " / " & Ar(1) & " / " & Ar(0)).ToString("dd/MM/yyyy") ', thCul)
                        cmd.Parameters.Item("regis_date").Value = dayRegis
                    Catch ex2 As Exception
                        Dim Ar As String() = p_regis_date.ToString.Replace(".", "").Split("/")
                        Dim dayRegis As Date = CDate(Ar(2) & " / " & Ar(1) & " / " & Ar(0)).ToString("dd/MM/yyyy") ', thCul)
                        cmd.Parameters.Item("regis_date").Value = dayRegis
                    End Try
                Else
                    cmd.Parameters.Item("regis_date").Value = DBNull.Value
                    strTxtFile.Append(NewLine & "ลำดับ : " & index)
                    strTxtFile.Append(" : ไม่สามารถบันทึกข้อมูลรถได้เนื่องจาก format Date of Registration ไม่ถูกต้อง (" & p_regis_date & ") ")
                End If
            End Try
        End If

        cmd.Parameters.Item("regis_province").Value = regis_province 'dr("regis_province")
        cmd.Parameters.Item("brand").Value = brand 'dr("brand")
        cmd.Parameters.Item("model").Value = model ' dr("model")
        cmd.Parameters.Item("vin_no").Value = vin_no 'dr("vin_no")
        cmd.Parameters.Item("engine_no").Value = engine_no 'dr("engine_no")
        If axles_no Is DBNull.Value Then ' dr("axles_no") Is DBNull.Value Then
            cmd.Parameters.Item("axles_no").Value = DBNull.Value
        Else
            cmd.Parameters.Item("axles_no").Value = CInt(axles_no) 'dr("axles_no"))
        End If

        cmd.Parameters.Item("colour").Value = colour 'dr("colour")
        If capacity_cc Is DBNull.Value Then ' dr("capacity_cc") Is DBNull.Value Then
            cmd.Parameters.Item("capacity_cc").Value = DBNull.Value
        Else
            cmd.Parameters.Item("capacity_cc").Value = CDbl(capacity_cc) 'dr("capacity_cc"))
        End If
        If weight_gross Is DBNull.Value Then 'dr("weight_gross") Is DBNull.Value Then
            cmd.Parameters.Item("weight_gross").Value = DBNull.Value
        Else
            cmd.Parameters.Item("weight_gross").Value = CDbl(weight_gross.ToString.Replace("(Tow Weight in Kg)", "").ToString.Replace("กก.", "").ToString.Replace(",", "")) 'CDbl(dr("weight_gross").ToString.Replace("(Tow Weight in Kg)", ""))
        End If

        If weight_net Is DBNull.Value Then 'dr("weight_net") Is DBNull.Value Then
            cmd.Parameters.Item("weight_net").Value = DBNull.Value
        Else
            cmd.Parameters.Item("weight_net").Value = CDbl(weight_net) 'dr("weight_net"))
        End If
        If seats_no Is DBNull.Value Then 'dr("seats_no") Is DBNull.Value Then
            cmd.Parameters.Item("seats_no").Value = DBNull.Value
        Else
            cmd.Parameters.Item("seats_no").Value = CDbl(seats_no) 'dr("seats_no"))
        End If
        If width Is DBNull.Value Then 'dr("width") Is DBNull.Value Then
            cmd.Parameters.Item("width").Value = DBNull.Value
        Else
            Try
                cmd.Parameters.Item("width").Value = CDbl(width) 'dr("width"))
            Catch ex As Exception
                'Conversion from string "2.5.1" to type 'Double' is not valid.
                Dim Ar As String() = width.Split(".")
                If Ar.Length > 2 Then
                    cmd.Parameters.Item("width").Value = CDbl(Ar(0) & "." & (Ar(1)) & (Ar(2))) 'dr("width"))
                End If
            End Try
        End If
        If length Is DBNull.Value Then 'dr("length") Is DBNull.Value Then
            cmd.Parameters.Item("length").Value = DBNull.Value
        Else
            cmd.Parameters.Item("length").Value = CDbl(length) 'dr("length"))
        End If
        If height Is DBNull.Value Then 'dr("height") Is DBNull.Value Then
            cmd.Parameters.Item("height").Value = DBNull.Value
        Else
            cmd.Parameters.Item("height").Value = CDbl(height) 'dr("height"))
        End If
        cmd.Parameters.Item("semi_trailer").Value = semi_trailer ' dr("semi_trailer")
        cmd.Parameters.Item("country_car").Value = country_car 'ddlCountry.SelectedValue
        cmd.ExecuteNonQuery()


        cmd.CommandText = "SELECT currval('""car_commerce_car_id_seq""')"
        Dim car_id As Integer = cmd.ExecuteScalar

        cmd.CommandText = "INSERT INTO license ( car_id , typeuser_id , status_id  ) " & _
                                   " VALUES ( " & car_id & "  , 5 , 0  ) "
        cmd.ExecuteNonQuery()

        cmd.CommandText = "SELECT currval('""license_license_id_seq""')"
        Dim license_id As Integer = cmd.ExecuteScalar
        Dim token As String = DBConnect.Token(license_id, car_id)
        Dim qrcode As String = DBConnect.qrcode(token, "5")
        cmd.CommandText = " UPDATE license SET token = '" & token & "' , qrcode = '" & qrcode & "' where license_id = " & license_id
        cmd.ExecuteNonQuery()

        cmd.CommandText = " INSERT INTO area ( prov_code, license_id)  VALUES (0 , " & license_id & " ) "
        cmd.ExecuteNonQuery()
    End Sub

    Private Function getMonthID(ByVal txt As String) As Integer
        If txt.ToString.ToLower.Contains("january") Then
            Return 1
        ElseIf txt.ToString.ToLower.Contains("february") Then
            Return 2
        ElseIf txt.ToString.ToLower.Contains("march") Then
            Return 3
        ElseIf txt.ToString.ToLower.Contains("april") Then
            Return 4
        ElseIf txt.ToString.ToLower.Contains("may") Then
            Return 5
        ElseIf txt.ToString.ToLower.Contains("june") Then
            Return 6
        ElseIf txt.ToString.ToLower.Contains("july") Then
            Return 7
        ElseIf txt.ToString.ToLower.Contains("august") Then
            Return 8
        ElseIf txt.ToString.ToLower.Contains("september	") Then
            Return 9
        ElseIf txt.ToString.ToLower.Contains("october") Then
            Return 10
        ElseIf txt.ToString.ToLower.Contains("november") Then
            Return 11
        ElseIf txt.ToString.ToLower.Contains("december") Then
            Return 12
        Else
            Return 0
        End If
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

       
        objStreamWriter.WriteLine(strTxtFile.ToString)


        'Close the stream
        objStreamWriter.Close()

        'Read the file, displaying its contents

        'Get a StreamReader class that can be used to read the file
        Dim objStreamReader As StreamReader
        objStreamReader = File.OpenText(FILENAME)

        'Now, read the entire file into a string
        Dim contents As String = objStreamReader.ReadToEnd()


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
End Class
