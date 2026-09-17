Imports System.Data
Imports Npgsql
Imports System.IO
Imports System.Diagnostics


Partial Class Travel_GroupAdd
    Inherits System.Web.UI.Page
    Private Populate As New PopulateDropDown
    Protected name As String
    Protected min_date As String
    Private tbProvice As New DataTable
    Dim strprov_code As String = ""


    Dim fPathGuide As String = Server.MapPath(ConfigurationManager.AppSettings("FileGuide"))

    Private Send As New SendEmail
    Private checkin As Object
    Private checkout As Object
    Private group_id As String
    Protected text As String = "Add Tour Group"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.QueryString("id") Is Nothing Then
            group_id = Request.QueryString("id")
        ElseIf Not Request.QueryString("token") Is Nothing Then
            Dim db As New DBConnect
            Try
                group_id = db.executeScalar("select group_id from travel_group where crypt(group_id :: text, 'groupid2562') = '" & Request.QueryString("token") & "' ")
            Catch ex As Exception

            Finally
                db = Nothing
            End Try
        End If

        Dim _day As Integer = 0
        Dim _date As Date
        Dim myCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
        If myCulture.Calendar.GetDayOfWeek(Date.Today).ToString.ToLower = "sunday" Then
            _day = 6
        ElseIf myCulture.Calendar.GetDayOfWeek(Date.Today).ToString.ToLower = "monday" Then
            _day = 5
        Else
            _day = 7
        End If


        Dim strChkDate As String = "SELECT count(h_date) FROM holiday where h_date between '" & Date.Today & "' and '" & DateAdd(DateInterval.Day, (_day), Date.Today) & "'"
        Dim DBCon As New DBConnect
        Dim Cnt_h_date As Integer = DBCon.executeScalar(strChkDate)

        _date = DateAdd(DateInterval.Day, (_day + Cnt_h_date), Date.Today)

        strChkDate = "select min(the_day) from (SELECT *  FROM generate_series(timestamp '" & DateAdd(DateInterval.Day, (_day + Cnt_h_date), Date.Today) & "', timestamp '" & DateAdd(DateInterval.Day, (_day + Cnt_h_date + 7), Date.Today) & "' , interval  '1 day') the_day  " &
            " WHERE the_day not in (SELECT h_date FROM holiday where extract('ISODOW' FROM h_date) < 6 ) ) dt "
        _date = DBCon.executeScalar(strChkDate)
        Dim nextWorkingDate As Date = GetNextWorkingDate(5)
        'min_date = "+" & DateDiff(DateInterval.Day, Date.Today, _date)
        'min_date = DateDiff(DateInterval.Day, Date.Today, _date)
        min_date = DateDiff(DateInterval.Day, Date.Today, nextWorkingDate)
        'Populate.genAreaform(ddladmin, False)
        Dim logScript As String = ""
        logScript &= "console.log('Server Today: " & Date.Today.ToString("yyyy-MM-dd") & "');"
        logScript &= "console.log('Next Working Date: " & nextWorkingDate.ToString("yyyy-MM-dd") & "');"
        logScript &= "console.log('Calculated min_date: " & min_date & "');"
        'logScript &= "console.log('Calculated min_date (TypeName): " & min_date.GetType().Name & "');"

        ' Inject ลง Browser Console
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LogMinDate", logScript, True)
        Dim dbs As New DBConnect
        Dim dtHoliday As DataTable = dbs.getDataTable("holiday")
        logScript &= "console.log('--- Holidays Loaded ---');"
        For Each row As DataRow In dtHoliday.Rows
            If Not IsDBNull(row("h_date")) Then
                logScript &= "console.log('" & CDate(row("h_date")).ToString("yyyy-MM-dd") & "');"
            End If
        Next

        ' Inject log ลง Browser Console
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LogMinDate", logScript, True)
        If Page.IsPostBack = False Then

            '        Dim minStartDate As Date = GetNextWorkingDate(5) 'GetWorkingDateAfterNDays(Date.Today, 5) 
            '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SetMinDate",
            '"setMinDate('" & minStartDate.ToString("yyyy-MM-dd") & "');", True)




            If Session("user_id") = Nothing Or Session("user_type") = 1 Then
                Session.Clear()
                Response.Redirect("../Login.aspx")
            End If
            Populate.genAreaform(ddladmin, False)
            'genDDLLicense(ddlLicense, IIf(Request.QueryString("id") Is Nothing, 0, Request.QueryString("id")))
            genDDLGuide(ddlGuide, IIf(group_id Is Nothing, 0, group_id))


            Populate.genDDLProvince(ddlProvarea, False)
            Populate.genDDLBorder(ddlBorderCheckin, False, "")
            Populate.genDDLBorder(ddlBorderCheckout, False, "")
            'tbitinerary_file.Visible = False
            btnDelPDF.Visible = False

            Dim dbconnect As New DBConnect
            HidExpDate.Value = dbconnect.executeScalar("select license_exp from user_travel WHERE user_id = " & Session("user_id"))
            HidExpDate.Value = Format(CDate(HidExpDate.Value), "MM/dd/yy")
            If HidExpDate.Value <> "" Then
                If HidExpDate.Value < Date.Now().AddDays(5) Then

                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "AlertTravelExpire();", True)
                End If
            Else
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "AlertTravelExpire();", True)
            End If


            Iframe2.Attributes("src") = "GroupAdd_tab2.aspx?is_renew=" & is_renew & IIf(group_id Is Nothing, "", "&id=" & group_id & "")
            Iframe3.Attributes("src") = "GroupAdd_tab3.aspx?is_renew=" & is_renew & IIf(group_id Is Nothing, "", "&id=" & group_id & "")



            If Request.QueryString("is_renew") <> "" Then

                ddlBorderCheckin.Enabled = False
                txtStart.Enabled = False

                Paneladd.Visible = False
                FileUploadPDF.Enabled = False
                btnDelPDF.Visible = False
                ddladmin.Enabled = False
                lnkSchMap.Visible = False
                divExtension.Visible = True
            End If


            If Not Request.QueryString("is_renew") Is Nothing AndAlso Request.QueryString("is_renew").Contains(",0") Then
                LoadDataRenew()

            Else
                If Not ((group_id) Is Nothing) Then

                    LoadData()
                Else
                    'Dim db As New DBConnect
                    checkin = dbconnect.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
                    checkout = dbconnect.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)
                End If
            End If
            genDDLLicense(ddlLicense, IIf(group_id Is Nothing, 0, group_id))
            If Not (Request.QueryString("Page") Is Nothing) Then
                If Request.QueryString("Page") = "8" Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
                    ddlBorderCheckin.Enabled = False
                    ddladmin.Enabled = False
                    lnkSchMap.Visible = False
                    Page2.Enabled = False
                    Page3.Enabled = False
                End If
            Else
                If Request.QueryString("tab") <> "" Then
                    If Request.QueryString("tab") = "2" Then
                        getCarLicense()
                    ElseIf Request.QueryString("tab") = "3" Then
                        btnNext3_Click(e, e)
                    End If
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab" & Request.QueryString("tab") & "();", True)
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
                End If
            End If




            Dim db As New DBConnect
            Dim prov_code As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)


            AddPopupMapAdmin("")

        End If

        With tbProvice
            .Columns.Add("area_id")
            .Columns.Add("prov_en")
            .Columns.Add("prov_code")
        End With
        For Each row As GridViewRow In gvProv.Rows
            Dim nrow As DataRow = tbProvice.NewRow
            nrow("area_id") = CType(row.Cells(0).FindControl("lblarea_id"), Label).Text
            nrow("prov_code") = CType(row.Cells(0).FindControl("lblprov_code"), Label).Text
            nrow("prov_en") = CType(row.Cells(0).FindControl("lblprov_en"), Label).Text
            tbProvice.Rows.Add(nrow)
        Next

        If Session("user_type") = 1 Or Session("user_type") = 2 Then
            'lblProv0.Visible = False
            If tbProvice.Rows.Count = 0 Then

                Dim db As New DBConnect
                Try
                    Dim prov_code As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
                    Dim prov_en As Object = db.executeScalar("select prov_en from province where prov_code = ( select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue & ") ")

                    tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)

                    gvProv.DataSource = tbProvice
                    gvProv.DataBind()
                    UpdatePanel11.Update()
                    UpdatePanel12.Update()
                Catch ex As Exception

                Finally
                    db = Nothing
                End Try
            End If
            If Session("user_type") = "1" Then
                Paneladd.Visible = False
                ddlProvarea.Visible = False
                If gvProv.Columns.Count > 0 Then
                    Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                    ProvareaDelete.Visible = False
                End If
            Else
                If tbProvice.Rows(0).Item("prov_code") = 0 Then
                    ddlProvarea.Visible = False
                    Paneladd.Visible = False
                Else
                    ddlProvarea.Visible = True
                    Paneladd.Visible = True
                    UpdatePanel13.Update()
                    'btnProv.Visible = True
                    Dim db As New DBConnect

                End If
            End If
        Else
            If Page.IsPostBack = False Then
                tbProvice.Rows.Add(tbProvice.Rows.Count + 1, "All province", "0")
                ddlProvarea.Visible = False
                btnProv.Visible = False
                Paneladd.Visible = False
            End If
            strprov_code = 0
            gvProv.DataSource = tbProvice
            gvProv.DataBind()
            Dim a = gvProv.Columns.Count
            gvProv.Columns(0).Visible = False
        End If

        If Hidstatus.Value = "2" Then
            text = "Edit Tour Group"
            If Hidchecktab_0.Value = "0" And Hidchecktab_8.Value = "0" Then


            ElseIf Hidchecktab_0.Value = "0" Or Hidchecktab_8.Value = "0" Then
                If Hidchecktab_0.Value = "0" Then
                    ddlBorderCheckout.Enabled = False
                    FileUploadPDF.Enabled = False
                    btnDelPDF.Visible = False
                    ddlProvarea.Visible = False
                    Paneladd.Visible = False
                End If
                If Hidchecktab_8.Value = "0" Then
                    txtStart.Enabled = False
                    txtExpire.Enabled = False
                    'txtgroup_name.Attributes.Add("disabled", "true")
                    txtgroup_name.Enabled = False
                    Page3.Enabled = False
                End If
            Else
                ddlBorderCheckout.Enabled = False
                FileUploadPDF.Enabled = False
                btnDelPDF.Visible = False
                ddlProvarea.Visible = False
                Paneladd.Visible = False
                txtStart.Enabled = False
                txtExpire.Enabled = False
                'txtgroup_name.Attributes.Add("disabled", "true")
                txtgroup_name.Enabled = False
                Page3.Enabled = False
            End If
        End If


        For Each i As DataRow In tbProvice.Rows
            Try
                ddlProvarea.Items.FindByValue(i("prov_code").ToString).Attributes.Add("disabled", "disabled")
                If Session("user_type") = 1 Or Session("user_type") = 2 Then
                    strprov_code = strprov_code & i("prov_code").ToString & ","
                End If
            Catch ex As Exception

            End Try
        Next

        strprov_code = strprov_code.Remove(strprov_code.Length - 1)

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack10", " $('#loadings').hide(); get_IframeMap('" & strprov_code & "');checkddlProv();", True)


    End Sub
    'Function GetNextWorkingDate(Optional ByVal nDays As Integer = 5) As Date
    '    Dim db As New DBConnect
    '    Dim holidayList As New HashSet(Of Date)()


    '    Dim dtHoliday As DataTable = db.getDataTable("holiday")


    '    For Each row As DataRow In dtHoliday.Rows
    '        If Not IsDBNull(row("h_date")) Then
    '            Dim hDate As Date = CDate(row("h_date")).Date
    '            If hDate >= Date.Today Then
    '                holidayList.Add(hDate)
    '            End If
    '        End If
    '    Next


    '    Dim currentDate As Date = Date.Today
    '    Dim count As Integer = 0

    '    Do While count < nDays
    '        currentDate = currentDate.AddDays(1)

    '        If currentDate.DayOfWeek <> DayOfWeek.Saturday AndAlso
    '       currentDate.DayOfWeek <> DayOfWeek.Sunday AndAlso
    '       Not holidayList.Contains(currentDate.Date) Then
    '            count += 1
    '        End If
    '    Loop

    '    Return currentDate
    'End Function
    ' helper function สำหรับเขียน log ออก console
    Private Sub LogToConsole(msg As String)
        Dim script As String = "console.log('" & msg.Replace("'", "\'") & "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), script, True)
    End Sub

    Function GetNextWorkingDate(Optional ByVal nDays As Integer = 5) As Date
        Dim db As New DBConnect
        Dim holidayList As New HashSet(Of Date)()


        Dim dtHoliday As DataTable = db.getDataTable("holiday")

        'For Each row As DataRow In dtHoliday.Rows
        '    If Not IsDBNull(row("h_date")) Then
        '        holidayList.Add(CDate(row("h_date")).Date)
        '    End If
        'Next
        For Each row As DataRow In dtHoliday.Rows
            If Not IsDBNull(row("h_date")) Then
                Dim hDate As Date = CDate(row("h_date")).Date
                holidayList.Add(hDate)
                ' log ออก console ของ browser
                'LogToConsole("Holiday loaded: " & hDate.ToString("yyyy-MM-dd"))
            End If
        Next

        'LogToConsole("Total holidays loaded: " & holidayList.Count)

        Dim currentDate As Date = Date.Today
        LogToConsole("Start checking from: " & currentDate.ToString("yyyy-MM-dd"))
        Dim count As Integer = 0

        Do While count < nDays
            'LogToConsole("Checking date: " & currentDate.ToString("yyyy-MM-dd"))
            If currentDate.DayOfWeek <> DayOfWeek.Saturday AndAlso
           currentDate.DayOfWeek <> DayOfWeek.Sunday AndAlso
           Not holidayList.Contains(currentDate.Date) Then

                count += 1
                'LogToConsole(" -> Count as working day (" & count & "/" & nDays & ")")
            Else
                'LogToConsole(" -> Skip (Weekend or Holiday)")
            End If

            If count < nDays Then
                currentDate = currentDate.AddDays(1)
            End If
        Loop
        currentDate = currentDate.AddDays(1)
        'LogToConsole("Final result: " & currentDate.ToString("yyyy-MM-dd"))

        Return currentDate
    End Function


    'Function GetWorkingDateAfterNDays(startDate As Date, workingDaysToAdd As Integer) As Date
    '    Dim db As New DBConnect
    '    Dim currentDate As Date = startDate.AddDays(1)
    '    Dim workdayCount As Integer = 0

    '    Do While workdayCount < workingDaysToAdd
    '        ' ตรวจสอบว่าเป็นวันเสาร์หรืออาทิตย์
    '        If currentDate.DayOfWeek = DayOfWeek.Saturday Or currentDate.DayOfWeek = DayOfWeek.Sunday Then
    '            currentDate = currentDate.AddDays(1)
    '            Continue Do
    '        End If


    '        Dim sql = "SELECT COUNT(*) FROM holiday WHERE h_date = '" & currentDate.ToString("yyyy-MM-dd") & "'"
    '        Dim count = CInt(db.executeScalar(sql))
    '        If count > 0 Then
    '            currentDate = currentDate.AddDays(1)
    '            Continue Do
    '        End If


    '        workdayCount += 1

    '        ' หากยังไม่ครบ ให้ไปวันถัดไป
    '        If workdayCount < workingDaysToAdd Then
    '            currentDate = currentDate.AddDays(1)
    '        End If
    '    Loop

    '    Return currentDate
    'End Function


    Private Sub LoadDataRenew()
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try

            con.Open()
            cmd.Connection = con
            Dim strCheckUser As String = " SELECT group_name, start_date, exp_date, cntpeople, checkin_id, checkout_id , admin_id, travel_itinerary_filesaved, travel_itinerary_filename, attachments_file_name, attachments_file_saved, reason " &
                                      " FROM travel_group  WHERE group_id = " & group_id
            cmd.CommandText = CommandType.Text
            cmd.CommandText = strCheckUser
            dread = cmd.ExecuteReader()

            Dim para_checkin_id, para_checkout_id As Integer
            If dread.Read Then
                If Not dread("group_name") Is DBNull.Value Then
                    txtgroup_name.Text = dread("group_name")
                End If
                If Not dread("start_date") Is DBNull.Value Then
                    'txtStart.Text = Format(Month(dread("start_date")), "00") & "/" & Format(Day(dread("start_date")), "00") & "/" & CDate(dread("start_date")).ToString("yyyy", enCul) 'Year(dread("start_date"))

                End If
                If Not dread("exp_date") Is DBNull.Value Then

                    Dim exp_dateNew As Date = CDate(dread("exp_date")).AddDays(1)

                    txtStart.Text = Format(Day(exp_dateNew), "00") & "/" & Format(Month(exp_dateNew), "00") & "/" & CDate(exp_dateNew).ToString("yyyy", enCul)
                    HidStart.Value = Format(CDate(exp_dateNew), "MM/dd/yy")

                    Dim end_dateNew As Date = CDate(dread("exp_date")).AddDays(30)
                    HidEnd.Value = Format(CDate(end_dateNew), "MM/dd/yy")

                End If
                If Not dread("cntpeople") Is DBNull.Value Then
                    txtcntpeople.Text = dread("cntpeople")
                End If
                If Not dread("checkin_id") Is DBNull.Value Then
                    'ddlBorderCheckin.SelectedValue = dread("checkin_id")
                    para_checkin_id = dread("checkin_id")
                End If
                If Not dread("checkout_id") Is DBNull.Value Then
                    'ddlBorderCheckout.SelectedValue = dread("checkout_id")
                    para_checkout_id = dread("checkout_id")
                End If

                If Not dread("admin_id") Is DBNull.Value Then
                    ddladmin.SelectedValue = dread("admin_id")
                End If

                If Not dread("travel_itinerary_filesaved") Is DBNull.Value Then
                    Dim ppPathPDFcost = dread("travel_itinerary_filesaved").ToString.Replace(hidfolderPDF.Value & "/", "")
                    hidSNamePDF.Value = ppPathPDFcost
                    hidFNamePDF.Value = dread("travel_itinerary_filename") 'ppPathPDFcost
                    hlFilePDF.Text = dread("travel_itinerary_filename")
                    hl(hlFilePDF, hidSNamePDF, hidFNamePDF, "FilePDF")
                    btnDelPDF.Visible = True
                    UpdFilePDF.Update()
                Else
                    hlFilePDF.Text = ""
                End If

                If Not dread("attachments_file_saved") Is DBNull.Value Then
                    Dim ppPathAttachcost = dread("attachments_file_saved").ToString.Replace(hidfolderAttach.Value & "/", "")
                    hidSNameAttach.Value = ppPathAttachcost
                    hidFNameAttach.Value = dread("attachments_file_name") 'ppPathPDFcost
                    hlFileAttach.Text = dread("attachments_file_name")
                    hlAttach(hlFileAttach, hidSNameAttach, hidFNameAttach, "FileAttach")
                    btnDelAttach.Visible = True
                    UpdFileAttach.Update()
                Else
                    hlFileAttach.Text = ""
                End If

                If Not dread("reason") Is DBNull.Value Then
                    txtReason.Text = dread("reason")
                End If

            End If
            dread.Close()


            Dim sqlstr2 = "select area_id , prov_en , area_group.prov_code from area_group LEFT JOIN province on province.prov_code = area_group.prov_code WHERE group_id = '" & group_id & "' order by area_id "
            Dim Datatable2 As DataTable = dbConnect.getDataTable(sqlstr2, "DataTable2")

            If Datatable2.Rows.Count > 0 Then
                gvProv.DataSource = Datatable2
                gvProv.DataBind()

                Dim strprov_codeNew As String = "'-1'"
                For Each i As DataRow In Datatable2.Rows
                    strprov_codeNew = strprov_codeNew & ",'" & i("prov_code").ToString & "'"
                Next

                genDDLBorderNew(ddlBorderCheckin, False, strprov_codeNew)
                ddlBorderCheckin.SelectedValue = para_checkin_id
                UpdBorderCheckin.Update()

                genDDLBorderNew(ddlBorderCheckout, False, strprov_codeNew)
                ddlBorderCheckout.SelectedValue = para_checkout_id
                UpdBorderCheckout.Update()
            End If

            ddlBorderCheckin.Enabled = False
            txtStart.Enabled = False
            'ddlProvarea.Enabled = False
            Paneladd.Visible = False
            FileUploadPDF.Enabled = False
            btnDelPDF.Visible = False
            btnDelAttach.Visible = False
            ddladmin.Enabled = False
            lnkSchMap.Visible = False
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
        Finally
            cmd.Connection.Close()
            con.Close()
            dbConnect = Nothing
            con.Dispose()
            cmd.Dispose()
        End Try
    End Sub


    Private enCul As New System.Globalization.CultureInfo("en-US")
    Private Sub LoadData()
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try

            con.Open()
            cmd.Connection = con

            Dim strCheckUser As String = " SELECT travel_group.group_name, travel_group.start_date, travel_group.exp_date, travel_group.cntpeople, travel_group.checkin_id, travel_group.checkout_id " &
                                        ", travel_group.admin_id, travel_group.travel_itinerary_filesaved, travel_group.travel_itinerary_filename, coalesce(license.status_id,0) as status, check_tab0 , check_tab1 , check_tab2 , check_tab3 , check_tab4 , check_tab8 " &
                                        " FROM travel_group " &
                                        " LEFT JOIN travel_group_car on travel_group_car.group_id = travel_group.group_id " &
                                        " LEFT JOIN license on travel_group_car.license_id = license.license_id " &
                                        " WHERE travel_group.group_id = " & group_id
            cmd.CommandText = CommandType.Text
            cmd.CommandText = strCheckUser
            dread = cmd.ExecuteReader()

            Dim para_checkin_id, para_checkout_id As Integer
            If dread.Read Then
                If Not dread("group_name") Is DBNull.Value Then
                    txtgroup_name.Text = dread("group_name")
                End If
                If Not dread("start_date") Is DBNull.Value Then

                    txtStart.Text = Format(Day(dread("start_date")), "00") & "/" & Format(Month(dread("start_date")), "00") & "/" & CDate(dread("start_date")).ToString("yyyy", enCul)

                End If
                If Not dread("exp_date") Is DBNull.Value Then

                    txtExpire.Text = Format(Day(dread("exp_date")), "00") & "/" & Format(Month(dread("exp_date")), "00") & "/" & CDate(dread("exp_date")).ToString("yyyy", enCul)

                End If
                If Not dread("cntpeople") Is DBNull.Value Then
                    txtcntpeople.Text = dread("cntpeople")
                End If
                If Not dread("checkin_id") Is DBNull.Value Then
                    ddlBorderCheckin.SelectedValue = dread("checkin_id")
                    para_checkin_id = dread("checkin_id")
                End If
                If Not dread("checkout_id") Is DBNull.Value Then
                    ddlBorderCheckout.SelectedValue = dread("checkout_id")
                    para_checkout_id = dread("checkout_id")
                End If
                Dim db As New DBConnect
                checkin = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
                checkout = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)

                If Not dread("admin_id") Is DBNull.Value Then
                    ddladmin.SelectedValue = dread("admin_id")
                End If

                If Not dread("travel_itinerary_filesaved") Is DBNull.Value Then
                    Dim ppPathPDFcost = dread("travel_itinerary_filesaved").ToString.Replace(hidfolderPDF.Value & "/", "")
                    hidSNamePDF.Value = ppPathPDFcost
                    hidFNamePDF.Value = dread("travel_itinerary_filename") 'ppPathPDFcost
                    hlFilePDF.Text = dread("travel_itinerary_filename")
                    hl(hlFilePDF, hidSNamePDF, hidFNamePDF, "FilePDF")
                    btnDelPDF.Visible = True
                    UpdFilePDF.Update()
                Else
                    hlFilePDF.Text = ""
                End If

                Hidstatus.Value = dread("status")

                If dread("check_tab0") = 1 Then
                    Hidchecktab_0.Value = 1
                Else
                    Hidchecktab_0.Value = 0
                End If

                If dread("check_tab1") = 1 Then
                    Hidchecktab_1.Value = 1
                Else
                    Hidchecktab_1.Value = 0
                End If

                If dread("check_tab2") = 1 Then
                    Hidchecktab_2.Value = 1
                Else
                    Hidchecktab_2.Value = 0
                End If

                If dread("check_tab3") = 1 Then
                    Hidchecktab_3.Value = 1
                Else
                    Hidchecktab_3.Value = 0
                End If

                If dread("check_tab4") = 1 Then
                    Hidchecktab_4.Value = 1
                Else
                    Hidchecktab_4.Value = 0
                End If

                If dread("check_tab8") = 1 Then
                    Hidchecktab_8.Value = 1
                Else
                    Hidchecktab_8.Value = 0
                End If

            End If
            dread.Close()

            Try

                If Hidstatus.Value = "2" Then

                    ddladmin.Enabled = False
                    lnkSchMap.Visible = False
                    Page2.Enabled = False
                    If Hidchecktab_0.Value = "0" And Hidchecktab_8.Value = "0" Then


                    ElseIf Hidchecktab_0.Value = "0" Or Hidchecktab_8.Value = "0" Then
                        If Hidchecktab_0.Value = "0" Then
                            ddlBorderCheckin.Enabled = False
                            ddlBorderCheckout.Enabled = False
                            FileUploadPDF.Enabled = False
                            btnDelPDF.Visible = False
                            ddlProvarea.Visible = False
                            Paneladd.Visible = False
                        End If
                        If Hidchecktab_8.Value = "0" Then
                            txtStart.Enabled = False
                            txtExpire.Enabled = False
                            txtgroup_name.Attributes.Add("disabled", "true")
                            Page3.Enabled = False
                        End If
                    Else
                        ddlBorderCheckin.Enabled = False
                        ddlBorderCheckout.Enabled = False
                        FileUploadPDF.Enabled = False
                        btnDelPDF.Visible = False
                        ddlProvarea.Visible = False
                        Paneladd.Visible = False
                        txtStart.Enabled = False
                        txtExpire.Enabled = False
                        txtgroup_name.Attributes.Add("disabled", "true")
                        Page3.Enabled = False
                    End If
                    'Page3.Enabled = False
                End If
            Catch ex As Exception

            End Try


            Dim sqlstr2 = "select area_id , prov_en , area_group.prov_code from area_group LEFT JOIN province on province.prov_code = area_group.prov_code WHERE group_id = '" & group_id & "' order by area_id "
            Dim Datatable2 As DataTable = dbConnect.getDataTable(sqlstr2, "DataTable2")

            If Datatable2.Rows.Count > 0 Then


                gvProv.DataSource = Datatable2
                gvProv.DataBind()

                Dim strprov_codeNew As String = "'-1'"
                For Each i As DataRow In Datatable2.Rows
                    strprov_codeNew = strprov_codeNew & ",'" & i("prov_code").ToString & "'"
                Next


                genDDLBorderNew(ddlBorderCheckin, False, "")
                ddlBorderCheckin.SelectedValue = para_checkin_id
                UpdBorderCheckin.Update()

                genDDLBorderNew(ddlBorderCheckout, False, "")
                ddlBorderCheckout.SelectedValue = para_checkout_id
                UpdBorderCheckout.Update()


            End If

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
        Finally
            cmd.Connection.Close()
            con.Close()
            dbConnect = Nothing
            con.Dispose()
            cmd.Dispose()

        End Try
    End Sub

    Private Sub AddPopupMapAdmin(ByVal paraMap As String)
        Dim strPopup As String = "javascript:w=window.open(" &
                        """" & ResolveClientUrl("~/Map/MapAdmin2.aspx?" & paraMap) & """," &
                        """SearchMapAdminWindow""," &
                        """" & "location=0,status=0,scrollbars=yes,resizable=no," &
                        "width=1024,height=780""" &
                        ");w.focus();"
        lnkSchMap.NavigateUrl = "javascript://"
        lnkSchMap.Attributes.Add("OnClick", strPopup)

    End Sub
    Protected Sub btnProv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProv.Click
        Dim db As New DBConnect
        Dim pro = ddlProvarea.SelectedValue
        tbProvice.Rows.Add(tbProvice.Rows.Count + 1, ddlProvarea.SelectedItem.Text, ddlProvarea.SelectedValue)
        If ddlProvarea.SelectedValue = 0 Then
            tbProvice.Clear()
            ddlProvarea.Visible = False
            btnProv.Visible = False
            Paneladd.Visible = False
            tbProvice.Rows.Add(tbProvice.Rows.Count + 1, ddlProvarea.SelectedItem.Text, ddlProvarea.SelectedValue)
        Else
            ddlProvarea.Visible = True
            btnProv.Visible = True
            Paneladd.Visible = True
            UpdatePanel13.Update()
        End If

        Dim strprov_codeNew As String = "'-1'"
        For Each i As DataRow In tbProvice.Rows
            ddlProvarea.Items.FindByValue(i("prov_code").ToString).Attributes.Add("disabled", "disabled")
            strprov_codeNew = strprov_codeNew & ",'" & i("prov_code").ToString & "'"
        Next

        checkin = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
        checkout = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)

        ddlProvarea.ClearSelection()
        gvProv.DataSource = tbProvice
        gvProv.DataBind()

        If Session("user_type") = 1 Then
            Paneladd.Visible = False
            ddlProvarea.Visible = False
            If gvProv.Columns.Count > 0 Then
                Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                ProvareaDelete.Visible = False
            End If
        ElseIf pro <> 0 Then

        End If
        UpdatePanel11.Update()
        UpdatePanel12.Update()


        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMap(" & pro & ");checkddlProv();", True)
    End Sub

    Private Sub genDDLBorderNew(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean, ByVal _strprov_code As String)
        'ด่านพรหมแดน
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            If _strprov_code Like "*0*" Then
                strselect = " select border_id as value , CAST(border_nameen || '  (' ||  prov_en || ')' as varchar ) as text " &
                            " from  border_check LEFT JOIN province on province.prov_code = border_check.prov_code Order By border_id "
            ElseIf _strprov_code <> "" Then
                strselect = " select border_id as value , CAST(border_nameen || '  (' ||  prov_en || ')' as varchar ) as text " &
               " from  border_check LEFT JOIN province on province.prov_code = border_check.prov_code WHERE province.prov_code in (" & _strprov_code & ") Order By border_id "
            Else
                strselect = " select border_id as value , CAST(border_nameen || '  (' ||  prov_en || ')' as varchar ) as text " &
                          " from  border_check LEFT JOIN province on province.prov_code = border_check.prov_code  Order By border_id "
            End If


            Dt = db.getDataTable(strselect, "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "เลือกทั้งหมด")
            ddl.Items(0).Value = 0
        End If



        ddl.SelectedIndex = -1
        If ddl.SelectedValue.Length > 0 Then
            ddl.SelectedValue.Remove(0)
        End If

        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataSource = Dt

        ddl.DataBind()

        'ddl.SelectedIndex = 0
        'ddl.Attributes.Add("data-inline", "true")
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptddlBorder", "checkddlBorder();", True)
    End Sub


    Protected Sub Provarea_Delete(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim db As New DBConnect
        If Session("user_type") = 1 Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "alert('Do not delete because there must be at least 1 province.')", True)
        ElseIf Session("user_type") = 2 And tbProvice.Rows.Count = 1 And e.CommandArgument <> 0 Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "alert('Do not delete because there must be at least 1 province.')", True)
        Else
            Dim prov_code = e.CommandArgument
            If prov_code = 0 Then
                Dim data = tbProvice.Select("prov_code=" & 0)
                ddlProvarea.Items.FindByValue(data("0")("prov_code").ToString).Attributes.Remove("disabled")
                tbProvice.Clear()
                ddlProvarea.Visible = True
                btnProv.Visible = True
                Paneladd.Visible = True
                UpdatePanel13.Update()
                'Dim checkin As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
                checkin = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
                checkout = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)

                Dim prov_en As Object = db.executeScalar("select prov_en from province where prov_code = ( select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue & ") ")
                tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, checkin)

                If checkin <> checkout Then
                    prov_en = db.executeScalar("select prov_en from province where prov_code = ( select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue & ") ")
                    tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, checkout)
                End If


                For Each i As DataRow In tbProvice.Rows
                    ddlProvarea.Attributes.Clear()
                    'ddlProvarea.Items.FindByValue(i("prov_code").ToString).Attributes.Add("disabled", "disabled")
                Next
                gvProv.DataSource = tbProvice
                gvProv.DataBind()


                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack3", "get_IframeMaps(" & checkin & "); checkddlBorder(); bordercheck();", True)
            Else
                Dim data = tbProvice.Select("prov_code=" & prov_code)
                checkin = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
                checkout = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)
                ddlProvarea.Items.FindByValue(data("0")("prov_code").ToString).Attributes.Remove("disabled")
                tbProvice.Rows.Remove(data(0))
                gvProv.DataSource = tbProvice
                gvProv.DataBind()
            End If



            If Session("user_type") = 1 Then
                Paneladd.Visible = False
                ddlProvarea.Visible = False
                If gvProv.Columns.Count > 0 Then
                    Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                    ProvareaDelete.Visible = False
                End If
            ElseIf prov_code <> 0 Then

            End If


            UpdatePanel11.Update()
            UpdatePanel12.Update()

            For Each i As DataRow In tbProvice.Rows
                Try
                    ddlProvarea.Items.FindByValue(i("prov_code").ToString).Attributes.Add("disabled", "disabled")
                    If Session("user_type") = 1 Or Session("user_type") = 2 Then
                        strprov_code = i("prov_code").ToString & ","
                    End If
                Catch ex As Exception

                End Try
            Next

            strprov_code = strprov_code.Remove(strprov_code.Length - 1)

            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMapDel(" & prov_code & ");", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack2", "get_IframeMapDel(" & prov_code & ");", True)
            'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack10", "tab1();", True)
        End If
    End Sub
    Protected Sub BtnBorderCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBorderCheck.Click

        Dim db As New DBConnect
        Dim oldprov As String = tbProvice.Rows(0)("prov_code")
        'tbProvice.Clear()
        checkin = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
        checkout = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)

        Dim prov_code As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
        Dim admin_id As Object = db.executeScalar("select admin_id from admin where prov_code = '" & prov_code & "'")
        Dim prov_en As Object = db.executeScalar("select prov_en from province where prov_code = ( select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue & ") ")
        If ddlBorderCheckin.SelectedValue = ddlBorderCheckout.SelectedValue Then
            tbProvice.Clear()
            tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)
        Else
            tbProvice.Clear()
            Dim checkin_en As String = db.executeScalar("select prov_en from province where prov_code = '" & checkin & "'")
            Dim checkout_en As String = db.executeScalar("select prov_en from province where prov_code = '" & checkout & "'")
            tbProvice.Rows.Add(tbProvice.Rows.Count + 1, checkin_en, checkin)
            tbProvice.Rows.Add(tbProvice.Rows.Count + 1, checkout_en, checkout)
            If tbProvice.Select("prov_code=" & prov_code).Length > 0 Then
            Else
                tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)
            End If
        End If


        'ddladmin.SelectedValue = admin_id
        If admin_id IsNot Nothing AndAlso ddladmin.Items.FindByValue(admin_id.ToString()) IsNot Nothing Then
            ddladmin.SelectedValue = admin_id.ToString()
        Else
            ddladmin.ClearSelection()
        End If

        gvProv.DataSource = tbProvice
        gvProv.DataBind()
        UpdatePanel11.Update()
        UpdatePanel12.Update()
        updateddladmin.Update()



        Dim strprov_codeNew As String = "'-1'"
        For Each i As DataRow In tbProvice.Rows
            ddlProvarea.Attributes.Clear()
            ddlProvarea.Items.FindByValue(i("prov_code").ToString).Attributes.Add("disabled", "disabled")
            strprov_codeNew = strprov_codeNew & ",'" & i("prov_code").ToString & "'"
        Next

        If Session("user_type") = 1 Then
            Paneladd.Visible = False
            ddlProvarea.Visible = False
            If gvProv.Columns.Count > 0 Then
                Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                ProvareaDelete.Visible = False
            End If
        Else

        End If
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMapDel(" & oldprov & ");", True)
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack5", "get_IframeMap(" & prov_code & ");", True)
    End Sub
    Protected Sub BtnBorderCheckOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBorderCheckOut.Click

        Dim db As New DBConnect

        'checkin = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
        checkout = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)

        Dim prov_code As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)
        Dim admin_id As Object = db.executeScalar("select admin_id from admin where prov_code = '" & prov_code & "'")
        Dim prov_en As Object = db.executeScalar("select prov_en from province where prov_code = ( select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue & ") ")

        If ddlBorderCheckin.SelectedValue = ddlBorderCheckout.SelectedValue Then
            tbProvice.Clear()
            tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)
        Else
            tbProvice.Clear()
            'Dim checkin_en As String = db.executeScalar("select prov_en from province where prov_code = '" & checkin & "'")
            Dim checkout_en As String = db.executeScalar("select prov_en from province where prov_code = '" & checkout & "'")
            'tbProvice.Rows.Add(tbProvice.Rows.Count + 1, checkin_en, checkin)
            tbProvice.Rows.Add(tbProvice.Rows.Count + 1, checkout_en, checkout)
            If tbProvice.Select("prov_code=" & prov_code).Length > 0 Then
            Else
                tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)
            End If

        End If
        Dim oldprov As String = tbProvice.Rows(0)("prov_code")
        'If admin_id IsNot Nothing AndAlso ddladmin.Items.FindByValue(admin_id.ToString()) IsNot Nothing Then
        '    ddladmin.SelectedValue = admin_id.ToString()
        'Else
        '    ddladmin.ClearSelection()
        'End If


        gvProv.DataSource = tbProvice
        gvProv.DataBind()
        UpdatePanel11.Update()
        UpdatePanel12.Update()
        updateddladmin.Update()

        Dim strprov_codeNew As String = "'-1'"
        For Each i As DataRow In tbProvice.Rows
            ddlProvarea.Attributes.Clear()
            ddlProvarea.Items.FindByValue(i("prov_code").ToString).Attributes.Add("disabled", "disabled")
            strprov_codeNew = strprov_codeNew & ",'" & i("prov_code").ToString & "'"
        Next

        If Session("user_type") = 1 Then
            Paneladd.Visible = False
            ddlProvarea.Visible = False
            If gvProv.Columns.Count > 0 Then
                Dim ProvareaDelete As ImageButton = gvProv.Rows.Item(0).FindControl("ProvareaDelete")
                ProvareaDelete.Visible = False
            End If
        Else


        End If
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMapDel(" & oldprov & ");", True)
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack5", "get_IframeMap(" & prov_code & ");", True)
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If checkerr.Value = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "AlertSubmit2();", True)
            btnNext3_Click(e, e)
        Else
            If checkerr.Value = 1 Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "AlertSubmit();", True)
                btnNext3_Click(e, e)
            Else
                'Dim group_id = Request.QueryString("id")
                If gvMain.Rows.Count <= 5 AndAlso gvMain_guide.Rows.Count < 1 Then
                    'กรณี 1-5 คัน ใช้ไกด์ 1 คน
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "AlertSubmit2();", True)
                    btnNext3_Click(e, e)
                ElseIf (gvMain.Rows.Count > 5 And gvMain.Rows.Count <= 15) AndAlso gvMain_guide.Rows.Count < 2 Then
                    'กรณี 6-15 คัน ใช้ไกด์ 2 คน
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "AlertSubmit2();", True)
                    btnNext3_Click(e, e)
                ElseIf (gvMain.Rows.Count > 15) AndAlso gvMain_guide.Rows.Count < 3 Then
                    'กรณี 16ขึ้นไป ใช้ไกด์ 3 คน
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "AlertSubmit2();", True)
                    btnNext3_Click(e, e)
                Else
                    Dim dbconect As New DBConnect
                    Dim tablecommand As DataTable = dbconect.TableCommand

                    Dim strGroup As String = "select license.license_id , license.token , license.fname , license.lname , license.email, user_travel.email as travelEmail, CAST(user_travel.user_name || ' ' || user_travel.user_surname as varchar) as agen_name" & _
                        ", car.plate, car.country_car, name_company, company_license, coalesce(license.regis_no,'') as regis_no from travel_group_car " & _
                        " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                        " LEFT JOIN license on license.license_id = travel_group_car.license_id " & _
                        " LEFT JOIN car on car.car_id = license.car_id " & _
                        " LEFT JOIN user_travel on user_travel.user_id = travel_group.user_id " & _
                        " WHERE (license.status_id is null or license.status_id not in (1,3,4)) and travel_group_car.group_id = " & group_id

                    Dim datatableGroup = dbconect.getDataTable(strGroup, "license_group")
                    For Each i In datatableGroup.Rows
                        tablecommand.Clear()
                        tablecommand.Rows.Add("status_id", NpgsqlTypes.NpgsqlDbType.Integer, 0)
                        tablecommand.Rows.Add("regis_no", NpgsqlTypes.NpgsqlDbType.Varchar, IIf(i("regis_no").ToString().Trim = "", DBConnect.RegisterNo(), i("regis_no").ToString()))
                        tablecommand.Rows.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Varchar, ddladmin.SelectedValue)
                        Dim tableUpdate = dbconect.UpdateDataTable(tablecommand, "license", "WHERE license_id = " & i("license_id").ToString())

                        Try

                            'ส่งให้ผปก.
                            Send.Email(i("travelEmail").ToString(), i("agen_name").ToString(), i("token").ToString(), i("plate").ToString(), i("country_car").ToString(), i("name_company").ToString(), i("company_license").ToString(), 1)
                            'ส่งให้นทท.
                            Send.Email(i("email").ToString(), i("fname").ToString() & " " & i("lname").ToString(), i("token").ToString(), i("plate").ToString(), i("country_car").ToString(), i("name_company").ToString(), i("company_license").ToString(), 2)
                        Catch ex As Exception

                        End Try
                    Next
                    Response.Redirect("Group.aspx")
                End If
            End If

        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Response.Redirect("Group.aspx")
    End Sub


    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("Group.aspx")
    End Sub

    Protected Sub btnNext2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext2.Click
        Dim ar_startDate As String() = txtStart.Text.ToString.Split("/")
        Dim ar_endDate As String() = txtExpire.Text.ToString.Split("/")
        Dim startDate As New DateTime(ar_startDate(2), ar_startDate(1), ar_startDate(0)) 'DateTime.Parse(Format(CDate(txtStart.Text), "MM/dd/yyyy"))
        Dim endDate As New DateTime(ar_endDate(2), ar_endDate(1), ar_endDate(0)) ' DateTime.Parse(Format(CDate(txtExpire.Text), "MM/dd/yyyy"))
        Try
            startDate = New DateTime(ar_startDate(2), ar_startDate(1), ar_startDate(0))
            endDate = New DateTime(ar_endDate(2), ar_endDate(1), ar_endDate(0))
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Select End date!!!')", True)
            Exit Sub
        End Try
        If txtgroup_name.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Key Group Name!!!')", True)
        ElseIf txtStart.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Select Start date!!!')", True)
        ElseIf txtExpire.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Select End date!!!')", True)
        ElseIf CDate(startDate) > CDate(endDate) Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('End date is greater than the Start date!!!')", True)
        ElseIf hidFNamePDF.Value = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Choose Travel Itinerary File!!!')", True)
        Else

            Dim diff As TimeSpan = endDate - startDate
            Dim days As Double = diff.TotalDays
            If days > 30 Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Travel date must be less than 30 days.!!!')", True)
            Else
                Dim DBconnect As New DBConnect
                Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
                Dim cmd As New Npgsql.NpgsqlCommand
                Dim tablecommand As DataTable = DBconnect.TableCommand

                Dim ss_exp = DBconnect.executeScalar("select to_char(license_exp , 'dd/mm/YYYY') license_exp from user_travel WHERE user_id = " & Session("user_id"))
                Dim ar_exp As String() = ss_exp.Split("/")
                Dim _license_exp As New Date(ar_exp(2), ar_exp(1), ar_exp(0))
                If CDate(endDate) > CDate(_license_exp) Then
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Your license cannot travel on that date.!')", True)
                Else
                    'Dim transaction As NpgsqlTransaction
                    Try
                        con.Open()
                        'transaction = con.BeginTransaction()
                        cmd.Connection = con


                        Dim old_group_id As Integer = 0
                        If group_id Is Nothing Or Request.QueryString("is_renew").Contains(",0") Then 'Not Request.QueryString("is_renew") Is Nothing Then
                            Dim is_renew As Integer = 0
                            If Request.QueryString("is_renew").Contains(",0") Then 'Not Request.QueryString("is_renew") Is Nothing Then
                                If Request.QueryString("is_renew").IndexOf(",") > -1 Then
                                    is_renew = CInt(Request.QueryString("is_renew").Split(",")(0)) + 1
                                Else
                                    is_renew = Request.QueryString("is_renew") + 1
                                End If

                                old_group_id = group_id
                            End If
                            Dim sqlInsert As String = "INSERT INTO travel_group ( group_name, is_active, start_date, exp_date, cntpeople , checkin_id , checkout_id , user_id , admin_id, travel_itinerary_filename, travel_itinerary_filesaved " &
                                " , is_renew , old_group_id, attachments_file_name, attachments_file_saved, reason ) " &
                            " VALUES (@group_name, 1, @start_date, @exp_date, @cntpeople , @checkin_id , @checkout_id , @user_id , @admin_id, @travel_itinerary_filename, @travel_itinerary_filesaved " &
                                " , " & is_renew & " , " & old_group_id & ", @attachments_file_name, @attachments_file_saved, @reason ) RETURNING group_id;  "
                            cmd.CommandText = CommandType.Text
                            cmd.CommandText = sqlInsert
                        Else
                            Dim sqlUpdate As String = " UPDATE travel_group SET group_name = :group_name , start_date = :start_date , exp_date = :exp_date , cntpeople = :cntpeople " &
                            " , checkin_id = :checkin_id , checkout_id = :checkout_id , user_id = :user_id , admin_id = :admin_id , travel_itinerary_filename = :travel_itinerary_filename, travel_itinerary_filesaved = :travel_itinerary_filesaved " &
                            " WHERE group_id = " & group_id
                            cmd.CommandText = CommandType.Text
                            cmd.CommandText = sqlUpdate
                        End If
                        'HidExpire.Value = txtExpire.Text
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("group_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtgroup_name.Text
                        cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtStart.Text.Trim = "", Nothing, startDate)
                        cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtExpire.Text.Trim = "", Nothing, endDate)
                        cmd.Parameters.Add("cntpeople", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0 'txtcntpeople.Text
                        cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = CInt(ddlBorderCheckin.SelectedValue)
                        cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = CInt(ddlBorderCheckout.SelectedValue)
                        cmd.Parameters.Add("user_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("user_id")
                        Debug.WriteLine("Selected Admin ID = " & ddladmin.SelectedValue)
                        cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = CInt(ddladmin.SelectedValue)
                        cmd.Parameters.Add("travel_itinerary_filename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidFNamePDF.Value.Trim = "", Nothing, hidFNamePDF.Value)
                        cmd.Parameters.Add("travel_itinerary_filesaved", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidSNamePDF.Value.Trim = "", Nothing, hidSNamePDF.Value)
                        If group_id Is Nothing Or Request.QueryString("is_renew").Contains(",0") Then 'Not Request.QueryString("is_renew") Is Nothing Then
                            'cmd.Parameters.Add("attachments_file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidFNameAttach.Value.Trim = "", Nothing, hidFNameAttach.Value)
                            'cmd.Parameters.Add("attachments_file_saved", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidSNameAttach.Value.Trim = "", Nothing, hidSNameAttach.Value)
                            'cmd.Parameters.Add("reason", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReason.Text.Trim = "", Nothing, txtReason.Text)
                            cmd.Parameters.Add("attachments_file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = If(String.IsNullOrWhiteSpace(hidFNameAttach.Value), DBNull.Value, hidFNameAttach.Value)
                            cmd.Parameters.Add("attachments_file_saved", NpgsqlTypes.NpgsqlDbType.Varchar).Value = If(String.IsNullOrWhiteSpace(hidSNameAttach.Value), DBNull.Value, hidSNameAttach.Value)
                            cmd.Parameters.Add("reason", NpgsqlTypes.NpgsqlDbType.Varchar).Value = If(String.IsNullOrWhiteSpace(txtReason.Text), DBNull.Value, txtReason.Text)

                        End If

                        If Request.QueryString("is_renew").Contains(",0") Then 'Not Request.QueryString("is_renew") Is Nothing Then
                            Dim group_id As String
                            group_id = cmd.ExecuteScalar

                            '------------อัพโหลดจังหวัด-------------
                            cmd.CommandText = "Insert into area_group (prov_code , group_id )  select prov_code , " & group_id & " as group_id  from area_group  where group_id = " & old_group_id
                            cmd.ExecuteNonQuery()


                            '------------Add Guide-------------
                            cmd.CommandText = " INSERT INTO travel_group_guide ( group_id, guide_id , regis_no , regis_photo )  " &
                            " select " & group_id & " as group_id , guide_id , regis_no , regis_photo from travel_group_guide where group_id = " & old_group_id
                            cmd.ExecuteNonQuery()

                            'Response.Redirect("GroupAdd.aspx?id=" & group_id & "&tab=2" & "&is_renew=1")
                            Response.Redirect("GroupAdd.aspx?id=" & group_id & "&tab=2&is_renew=1", False)
                            Context.ApplicationInstance.CompleteRequest()

                        Else


                            Dim group_id1 As String
                            If group_id Is Nothing Then
                                group_id1 = cmd.ExecuteScalar
                                Dim sqlselectcheck As String = "SELECT area_id from area_group WHERE group_id = " & group_id1

                                Dim cRowf As DataRow
                                Dim drRow() As DataRow
                                Dim tbProviceold As New DataTable

                                cmd.CommandText = CommandType.Text
                                cmd.CommandText = sqlselectcheck
                                tbProviceold = DBconnect.getDataTable(sqlselectcheck, "TbProviceold")

                                '------------อัพโหลดจังหวัด-------------

                                For introw = 0 To tbProvice.Rows.Count - 1
                                    cmd.Parameters.Clear()
                                    cRowf = tbProvice.Rows(introw)
                                    drRow = tbProviceold.Select("area_id = " & cRowf("area_id"))

                                    If drRow.Length > 0 Then
                                        cmd.CommandText = "Update area_group set prov_code=:prov_code , group_id=:group_id WHERE area_id = " & cRowf("area_id")
                                        tbProviceold.Rows.Remove(drRow(0))
                                    Else
                                        cmd.CommandText = "Insert into area_group (prov_code , group_id ) VALUES (:prov_code , :group_id ) "

                                    End If

                                    cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("prov_code")
                                    'cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id1
                                    cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(group_id1)

                                    cmd.ExecuteNonQuery()
                                Next

                                '----------ลบจังหวัด---------------

                                For Each cRow In tbProviceold.Rows
                                    cmd.Parameters.Clear()
                                    cmd.CommandText = "delete from area_group where area_id =" & cRow("area_id")
                                    cmd.ExecuteScalar()
                                Next


                                Response.Redirect("GroupAdd.aspx?id=" & group_id1 & "&tab=2&is_renew=", False)
                                Context.ApplicationInstance.CompleteRequest()

                            Else
                                cmd.ExecuteNonQuery()
                                group_id1 = group_id
                                getCarLicense()
                                Dim sqlselectcheck As String = "SELECT area_id from area_group WHERE group_id = " & group_id1

                                Dim cRowf As DataRow
                                Dim drRow() As DataRow
                                Dim tbProviceold As New DataTable

                                cmd.CommandText = CommandType.Text
                                cmd.CommandText = sqlselectcheck
                                tbProviceold = DBconnect.getDataTable(sqlselectcheck, "TbProviceold")

                                '------------อัพโหลดจังหวัด-------------

                                For introw = 0 To tbProvice.Rows.Count - 1
                                    cmd.Parameters.Clear()
                                    cRowf = tbProvice.Rows(introw)
                                    drRow = tbProviceold.Select("area_id = " & cRowf("area_id"))

                                    If drRow.Length > 0 Then
                                        cmd.CommandText = "Update area_group set prov_code=:prov_code , group_id=:group_id WHERE area_id = " & cRowf("area_id")
                                        tbProviceold.Rows.Remove(drRow(0))
                                    Else
                                        cmd.CommandText = "Insert into area_group (prov_code , group_id ) VALUES (:prov_code , :group_id ) "

                                    End If

                                    cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("prov_code")
                                    cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id1
                                    cmd.ExecuteNonQuery()
                                Next

                                '----------ลบจังหวัด---------------

                                For Each cRow In tbProviceold.Rows
                                    cmd.Parameters.Clear()
                                    cmd.CommandText = "delete from area_group where area_id =" & cRow("area_id")
                                    cmd.ExecuteScalar()
                                Next



                                Dim table As DataTable = DBconnect.getDataTable("select license_id from travel_group_car WHERE group_id = " & group_id1, "group_car")

                                For Each i In table.Rows
                                    areaCar(i("license_id").ToString)
                                Next
                                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2();", True)
                            End If

                        End If


                    Catch ex As Exception
                        'Console.WriteLine(ex.Message)
                        Debug.WriteLine("Error in loadData: " & ex.ToString())

                    Finally
                        'DBconnect = Nothing
                        cmd.Connection.Close()
                        con.Close()
                        cmd.Dispose()
                        con.Dispose()
                    End Try
                End If
            End If
        End If

        genDDLLicense(ddlLicense, If(IsNumeric(group_id), CInt(group_id), 0))

        'genDDLLicense(ddlLicense, IIf(group_id Is Nothing, 0, group_id))

    End Sub

    'Protected Sub btnNext2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext2.Click
    '    Dim ar_startDate As String() = txtStart.Text.ToString.Split("/")
    '    Dim ar_endDate As String() = txtExpire.Text.ToString.Split("/")
    '    Dim startDate 'As New DateTime(ar_startDate(2), ar_startDate(1), ar_startDate(0)) 'DateTime.Parse(Format(CDate(txtStart.Text), "MM/dd/yyyy"))
    '    Dim endDate 'As New DateTime(ar_endDate(2), ar_endDate(1), ar_endDate(0)) ' DateTime.Parse(Format(CDate(txtExpire.Text), "MM/dd/yyyy"))
    '    Try
    '        startDate = New DateTime(ar_startDate(2), ar_startDate(1), ar_startDate(0))
    '        endDate = New DateTime(ar_endDate(2), ar_endDate(1), ar_endDate(0))
    '    Catch ex As Exception
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Select End date!!!')", True)
    '        Exit Sub
    '    End Try
    '    If txtgroup_name.Text.Trim = "" Then
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Key Group Name!!!')", True)
    '    ElseIf txtStart.Text.Trim = "" Then
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Select Start date!!!')", True)
    '    ElseIf txtExpire.Text.Trim = "" Then
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Select End date!!!')", True)
    '    ElseIf CDate(startDate) > CDate(endDate) Then
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('End date is greater than the Start date!!!')", True)
    '    ElseIf hidFNamePDF.Value = "" Then
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    '        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Choose Travel Itinerary File!!!')", True)
    '    Else

    '        Dim diff As TimeSpan = endDate - startDate
    '        Dim days As Double = diff.TotalDays
    '        If days > 30 Then
    '            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    '            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Travel date must be less than 30 days.!!!')", True)
    '        Else
    '            Dim DBconnect As New DBConnect
    '            Dim con As Npgsql.NpgsqlConnection = DBconnect.getConnection
    '            Dim cmd As New Npgsql.NpgsqlCommand
    '            Dim tablecommand As DataTable = DBconnect.TableCommand

    '            Dim ss_exp = DBconnect.executeScalar("select to_char(license_exp , 'dd/mm/YYYY') license_exp from user_travel WHERE user_id = " & Session("user_id"))
    '            Dim ar_exp As String() = ss_exp.Split("/")
    '            Dim _license_exp As New Date(ar_exp(2), ar_exp(1), ar_exp(0))
    '            If CDate(endDate) > CDate(_license_exp) Then
    '                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    '                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Your license cannot travel on that date.!')", True)
    '            Else
    '                'Dim transaction As NpgsqlTransaction
    '                Try
    '                    con.Open()
    '                    'transaction = con.BeginTransaction()
    '                    cmd.Connection = con


    '                    Dim old_group_id As Integer = 0
    '                    If group_id Is Nothing Or Request.QueryString("is_renew").Contains(",0") Then 'Not Request.QueryString("is_renew") Is Nothing Then
    '                        Dim is_renew As Integer = 0
    '                        If Request.QueryString("is_renew").Contains(",0") Then 'Not Request.QueryString("is_renew") Is Nothing Then
    '                            If Request.QueryString("is_renew").IndexOf(",") > -1 Then
    '                                is_renew = CInt(Request.QueryString("is_renew").Split(",")(0)) + 1
    '                            Else
    '                                is_renew = Request.QueryString("is_renew") + 1
    '                            End If

    '                            old_group_id = group_id
    '                        End If
    '                        Dim sqlInsert As String = "INSERT INTO travel_group ( group_name, is_active, start_date, exp_date, cntpeople , checkin_id , checkout_id , user_id , admin_id, travel_itinerary_filename, travel_itinerary_filesaved " & _
    '                            " , is_renew , old_group_id, attachments_file_name, attachments_file_saved, reason ) " & _
    '                        " VALUES (:group_name, 1, :start_date, :exp_date, :cntpeople , :checkin_id , :checkout_id , :user_id , :admin_id, :travel_itinerary_filename, :travel_itinerary_filesaved " & _
    '                            " , " & is_renew & " , " & old_group_id & ", :attachments_file_name, :attachments_file_saved, :reason ) RETURNING group_id;  "
    '                        cmd.CommandText = CommandType.Text
    '                        cmd.CommandText = sqlInsert
    '                    Else
    '                        Dim sqlUpdate As String = " UPDATE travel_group SET group_name = :group_name , start_date = :start_date , exp_date = :exp_date , cntpeople = :cntpeople " & _
    '                        " , checkin_id = :checkin_id , checkout_id = :checkout_id , user_id = :user_id , admin_id = :admin_id , travel_itinerary_filename = :travel_itinerary_filename, travel_itinerary_filesaved = :travel_itinerary_filesaved " & _
    '                        " WHERE group_id = " & group_id
    '                        cmd.CommandText = CommandType.Text
    '                        cmd.CommandText = sqlUpdate
    '                    End If
    '                    'HidExpire.Value = txtExpire.Text
    '                    cmd.Parameters.Clear()
    '                    cmd.Parameters.Add("group_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtgroup_name.Text
    '                    cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtStart.Text.Trim = "", Nothing, startDate)
    '                    cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtExpire.Text.Trim = "", Nothing, endDate)
    '                    cmd.Parameters.Add("cntpeople", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0 'txtcntpeople.Text
    '                    cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckin.SelectedValue
    '                    cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckout.SelectedValue
    '                    cmd.Parameters.Add("user_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("user_id")
    '                    'cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddladmin.SelectedValue
    '                    'If Not String.IsNullOrWhiteSpace(ddladmin.SelectedValue) Then
    '                    '    cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(ddladmin.SelectedValue)
    '                    'Else
    '                    '    cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = DBNull.Value
    '                    'End If
    '                    cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = CInt(ddladmin.SelectedValue)
    '                    cmd.Parameters.Add("travel_itinerary_filename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidFNamePDF.Value.Trim = "", Nothing, hidFNamePDF.Value)
    '                    cmd.Parameters.Add("travel_itinerary_filesaved", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidSNamePDF.Value.Trim = "", Nothing, hidSNamePDF.Value)
    '                    If group_id Is Nothing Or Request.QueryString("is_renew").Contains(",0") Then 'Not Request.QueryString("is_renew") Is Nothing Then
    '                        cmd.Parameters.Add("attachments_file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidFNameAttach.Value.Trim = "", Nothing, hidFNameAttach.Value)
    '                        cmd.Parameters.Add("attachments_file_saved", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidSNameAttach.Value.Trim = "", Nothing, hidSNameAttach.Value)
    '                        cmd.Parameters.Add("reason", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReason.Text.Trim = "", Nothing, txtReason.Text)
    '                    End If

    '                    If Request.QueryString("is_renew").Contains(",0") Then 'Not Request.QueryString("is_renew") Is Nothing Then
    '                        Dim group_id As String
    '                        group_id = cmd.ExecuteScalar

    '                        '------------อัพโหลดจังหวัด-------------
    '                        cmd.CommandText = "Insert into area_group (prov_code , group_id )  select prov_code , " & group_id & " as group_id  from area_group  where group_id = " & old_group_id
    '                        cmd.ExecuteNonQuery()


    '                        '------------Add Guide-------------
    '                        cmd.CommandText = " INSERT INTO travel_group_guide ( group_id, guide_id , regis_no , regis_photo )  " & _
    '                        " select " & group_id & " as group_id , guide_id , regis_no , regis_photo from travel_group_guide where group_id = " & old_group_id
    '                        cmd.ExecuteNonQuery()

    '                        Response.Redirect("GroupAdd.aspx?id=" & group_id & "&tab=2" & "&is_renew=1")
    '                    Else


    '                        Dim group_id1 As String
    '                        If group_id Is Nothing Then
    '                            group_id1 = cmd.ExecuteScalar
    '                            Dim sqlselectcheck As String = "SELECT area_id from area_group WHERE group_id = " & group_id1

    '                            Dim cRowf As DataRow
    '                            Dim drRow() As DataRow
    '                            Dim tbProviceold As New DataTable

    '                            cmd.CommandText = CommandType.Text
    '                            cmd.CommandText = sqlselectcheck
    '                            tbProviceold = DBconnect.getDataTable(sqlselectcheck, "TbProviceold")

    '                            '------------อัพโหลดจังหวัด-------------

    '                            For introw = 0 To tbProvice.Rows.Count - 1
    '                                cmd.Parameters.Clear()
    '                                cRowf = tbProvice.Rows(introw)
    '                                drRow = tbProviceold.Select("area_id = " & cRowf("area_id"))

    '                                If drRow.Length > 0 Then
    '                                    cmd.CommandText = "Update area_group set prov_code=:prov_code , group_id=:group_id WHERE area_id = " & cRowf("area_id")
    '                                    tbProviceold.Rows.Remove(drRow(0))
    '                                Else
    '                                    cmd.CommandText = "Insert into area_group (prov_code , group_id ) VALUES (:prov_code , :group_id ) "

    '                                End If

    '                                cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("prov_code")
    '                                cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id1
    '                                cmd.ExecuteNonQuery()
    '                            Next

    '                            '----------ลบจังหวัด---------------

    '                            For Each cRow In tbProviceold.Rows
    '                                cmd.Parameters.Clear()
    '                                cmd.CommandText = "delete from area_group where area_id =" & cRow("area_id")
    '                                cmd.ExecuteScalar()
    '                            Next


    '                            Response.Redirect("GroupAdd.aspx?id=" & group_id1 & "&tab=2&is_renew=")
    '                        Else
    '                            cmd.ExecuteNonQuery()
    '                            group_id1 = group_id
    '                            getCarLicense()
    '                            Dim sqlselectcheck As String = "SELECT area_id from area_group WHERE group_id = " & group_id1

    '                            Dim cRowf As DataRow
    '                            Dim drRow() As DataRow
    '                            Dim tbProviceold As New DataTable

    '                            cmd.CommandText = CommandType.Text
    '                            cmd.CommandText = sqlselectcheck
    '                            tbProviceold = DBconnect.getDataTable(sqlselectcheck, "TbProviceold")

    '                            '------------อัพโหลดจังหวัด-------------

    '                            For introw = 0 To tbProvice.Rows.Count - 1
    '                                cmd.Parameters.Clear()
    '                                cRowf = tbProvice.Rows(introw)
    '                                drRow = tbProviceold.Select("area_id = " & cRowf("area_id"))

    '                                If drRow.Length > 0 Then
    '                                    cmd.CommandText = "Update area_group set prov_code=:prov_code , group_id=:group_id WHERE area_id = " & cRowf("area_id")
    '                                    tbProviceold.Rows.Remove(drRow(0))
    '                                Else
    '                                    cmd.CommandText = "Insert into area_group (prov_code , group_id ) VALUES (:prov_code , :group_id ) "

    '                                End If

    '                                cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("prov_code")
    '                                cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id1
    '                                cmd.ExecuteNonQuery()
    '                            Next

    '                            '----------ลบจังหวัด---------------

    '                            For Each cRow In tbProviceold.Rows
    '                                cmd.Parameters.Clear()
    '                                cmd.CommandText = "delete from area_group where area_id =" & cRow("area_id")
    '                                cmd.ExecuteScalar()
    '                            Next



    '                            Dim table As DataTable = DBconnect.getDataTable("select license_id from travel_group_car WHERE group_id = " & group_id1, "group_car")

    '                            For Each i In table.Rows
    '                                areaCar(i("license_id").ToString)
    '                            Next
    '                            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2();", True)
    '                        End If

    '                    End If


    '                Catch ex As Exception
    '                    Console.WriteLine(ex.Message)
    '                Finally
    '                    'DBconnect = Nothing
    '                    cmd.Connection.Close()
    '                    con.Close()
    '                    cmd.Dispose()
    '                    con.Dispose()
    '                End Try
    '            End If
    '        End If
    '    End If

    '    genDDLLicense(ddlLicense, IIf(group_id Is Nothing, 0, group_id))

    'End Sub
    Public Function areaCar(ByVal license_id As String)

        Dim DBconnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = DBconnect.getConnection
        Dim cmd As New Npgsql.NpgsqlCommand
        Try
            con.Open()
            cmd.Connection = con
            Dim sqlselectcheck As String = "SELECT area_id from area WHERE license_id = " & license_id
            Dim cRowf As DataRow
            Dim drRow() As DataRow
            Dim tbProviceold As New DataTable

            cmd.CommandText = CommandType.Text
            cmd.CommandText = sqlselectcheck
            tbProviceold = DBconnect.getDataTable(sqlselectcheck, "TbProviceold")

            '------------อัพโหลดจังหวัด-------------

            For introw = 0 To tbProvice.Rows.Count - 1
                cmd.Parameters.Clear()
                cRowf = tbProvice.Rows(introw)
                drRow = tbProviceold.Select("area_id = " & cRowf("area_id"))

                If drRow.Length > 0 Then
                    cmd.CommandText = "Update area set prov_code=:prov_code , license_id=:license_id WHERE area_id = " & cRowf("area_id")
                    tbProviceold.Rows.Remove(drRow(0))
                Else
                    cmd.CommandText = "Insert into area (prov_code , license_id ) VALUES (:prov_code , :license_id ) "

                End If

                cmd.Parameters.Add("prov_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cRowf("prov_code")
                cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = license_id
                cmd.ExecuteNonQuery()
            Next

            '----------ลบจังหวัด---------------

            For Each cRow In tbProviceold.Rows
                cmd.Parameters.Clear()
                cmd.CommandText = "delete from area where area_id =" & cRow("area_id")
                cmd.ExecuteScalar()
            Next
        Catch ex As Exception

        Finally
            cmd.Connection.Close()
            con.Close()
            cmd.Dispose()
            con.Dispose()
        End Try
    End Function


    Protected Sub btnPrev1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev1.Click
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    End Sub

    Protected Sub btnNext3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext3.Click
        getCarLicense()
        getGuide()

        CheckGuide()
        If CheckInsurance() Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab3();", True)
        Else
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", " alert('Please Fill Insurance information !!!');tab2();", True)
        End If

    End Sub


    Private Sub CheckGuide()
        If cnt_car <= 5 Then
            'กรณี 1-5 คัน ใช้ไกด์ 1 คน
            If gvMain_guide.Rows.Count = 1 Then
                ddlGuide.Visible = False
                BtnAddGuide.Visible = False
            Else
                ddlGuide.Visible = True
                BtnAddGuide.Visible = True
            End If

        ElseIf cnt_car <= 15 Then
            'กรณี 6-15 คัน ใช้ไกด์ 2 คน
            If gvMain_guide.Rows.Count = 2 Then
                ddlGuide.Visible = False
                BtnAddGuide.Visible = False
            Else
                ddlGuide.Visible = True
                BtnAddGuide.Visible = True
            End If
        Else
            If gvMain_guide.Rows.Count = 3 Then
                ddlGuide.Visible = False
                BtnAddGuide.Visible = False
            Else
                ddlGuide.Visible = True
                BtnAddGuide.Visible = True
            End If
            'กรณี 16ขึ้นไป ใช้ไกด์ 3 คน

        End If

        divGuide1.Visible = BtnAddGuide.Visible
        divGuide2.Visible = BtnAddGuide.Visible
        divGuide3.Visible = BtnAddGuide.Visible
        divGuide4.Visible = BtnAddGuide.Visible
    End Sub

    Private Function CheckInsurance() As Boolean
        Dim chk As Boolean = False

        Dim db As New DBConnect
        Dim str As String = " select count(*) from act where act_no is null and act_id in (select act_id from license  " & _
            " LEFT JOIN  travel_group_car on license.license_id = travel_group_car.license_id " & _
            " LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id " & _
            " where travel_group.group_id = " & group_id & " ) "

        If db.executeScalar(str) = 0 Then
            chk = True
        End If

        Return chk
    End Function

    Protected Sub btnPrev2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev2.Click
        getCarLicense()
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2();", True)
    End Sub

    Protected Sub BtnAddLicense_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddLicense.Click
        Dim dbconnect As New DBConnect
        Dim Datatable As DataTable = dbconnect.TableCommand

        Dim con As Npgsql.NpgsqlConnection = dbconnect.getConnection
        Dim cmd As New Npgsql.NpgsqlCommand
        Try
            con.Open()
            cmd.Connection = con

            Dim old_group_id As Integer = 0
            Dim cancel_license_id As Integer = 0
            Try
                cancel_license_id = dbconnect.executeScalar("select status_id from license where license_id = " & ddlLicense.SelectedValue)
                old_group_id = dbconnect.executeScalar("select old_group_id from travel_group where group_id = " & group_id)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            If (old_group_id > 0) Or (cancel_license_id = 4 Or cancel_license_id = 5 Or cancel_license_id = 7 Or cancel_license_id = 8 Or cancel_license_id = 9) Then

                '------------Add License ใหม่-----------
                cmd.CommandText = "INSERT INTO car ( owner_name, owner_idcard, owner_address, owner_tel , owner_lastname , owner_province , owner_zipcode , owner_country " & _
                    " , brands , model , colors , seat , weight , car_no , country_car , typecar_id  ,  province_car , plate , engine_no , engine_cap , authorize_car , regis_photo , platelocal ) " & _
                    " select owner_name, owner_idcard, owner_address, owner_tel , owner_lastname , owner_province , owner_zipcode , owner_country " & _
                    " , brands , model , colors , seat , weight , car_no , country_car , typecar_id  ,  province_car , plate , engine_no , engine_cap , authorize_car , regis_photo , platelocal " & _
                    " from car where car_id = (select car_id from license where license_id = " & ddlLicense.SelectedValue & " ) " & _
                    " RETURNING car_id ;"
                Dim car_id As Object = cmd.ExecuteScalar()

                cmd.CommandText = "Insert Into car_pic ( car_id , file_name , imgtype) " & _
                " select " & car_id & " as car_id , file_name , imgtype from car_pic where car_id = (select car_id from license where license_id = " & ddlLicense.SelectedValue & " )"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "Insert Into car_cer ( car_id , file_name ) " & _
                " select " & car_id & " as car_id , file_name from car_cer where car_id = (select car_id from license where license_id = " & ddlLicense.SelectedValue & " )"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "Insert Into car_inspec ( car_id , file_name )  " & _
                " select " & car_id & " as car_id , file_name from car_inspec where car_id = (select car_id from license where license_id = " & ddlLicense.SelectedValue & " )"
                cmd.ExecuteNonQuery()

                ' คนขับรถ
                cmd.CommandText = "Insert Into driver ( prename , address , name , surname , license_expire , national , countries , gender " & _
                " , passport_photo , licensedriver_photo , idcard_no , county , zipcode , tel , email , birthday , passport_no , passport_expire , photo_cer ) " & _
                " select prename , address , name , surname , license_expire , national , countries , gender " & _
                " , passport_photo , licensedriver_photo , idcard_no , county , zipcode , tel , email , birthday , passport_no , passport_expire , photo_cer " & _
                " from driver where driver_id = (select driver_id from license where license_id = " & ddlLicense.SelectedValue & " )  " & _
                " RETURNING driver_id ; "
                Dim driver_id As Object = cmd.ExecuteScalar()

                ' คนขับสำรองคนที่ 1 / คนขับสำรองคนที่ 2
                cmd.CommandText = "Insert Into spare_driver (prename , name , surname , license_no , national , driver_id , passport_no , passport_expire , spare_ord " & _
                                  ", licensedriver_photo , address , state , country , zipcode , tel , email , gender , license_exp_date , passport_photo , photo_cer " & _
                                  ") " & _
                                  "select prename , name , surname , license_no , national , driver_id , passport_no , passport_expire , spare_ord " & _
                                  ", licensedriver_photo , address , state , country , zipcode , tel , email , gender , license_exp_date , passport_photo , photo_cer from spare_driver " & _
                                  " where sparedriver_id = ( select sparedriver_id from spare_driver where driver_id = " & driver_id & ")"
                cmd.ExecuteNonQuery()

                'ตาราง act
                If cancel_license_id = 4 Or cancel_license_id = 5 Or cancel_license_id = 7 Or cancel_license_id = 8 Or cancel_license_id = 9 Then
                    cmd.CommandText = " Insert Into act (act_no , act_name , act_tankno , act_start , act_ends , act_photo , act_company , act_no2 " & _
                    " , act_name2 , act_start2 , act_photo2 , act_company2 , act_ends2 ) " & _
                    " select act_no , act_name , act_tankno , act_start , act_ends , act_photo , act_company , act_no2 " & _
                    " , act_name2 , act_start2 , act_photo2 , act_company2 , act_ends2 " & _
                    " from act where act_id = ( select act_id from license where license_id = " & ddlLicense.SelectedValue & " ) RETURNING act_id ;"
                Else
                    cmd.CommandText = " Insert Into act (act_no , act_name , act_tankno , act_start , act_ends , act_photo , act_company , act_no2 " & _
                    " , act_name2 , act_start2 , act_photo2 , act_company2 , act_ends2 ) " & _
                    " values( null , null , null , null , null , null , null , null " & _
                    " , null , null , null , null , null  ) RETURNING act_id ;"
                End If
                Dim act_id As Object = cmd.ExecuteScalar()

                HidExpire.Value = dbconnect.executeScalar("select exp_date from travel_group where group_id = " & group_id)

                If cancel_license_id = 4 Or cancel_license_id = 5 Or cancel_license_id = 7 Or cancel_license_id = 8 Or cancel_license_id = 9 Then
                    cmd.CommandText = "Insert Into license ( driver_id , car_id , act_id , typeuser_id , travel_id , regis_date , fname , lname , email , exp_date , copy_license_id ) " & _
                       " select " & driver_id & " as driver_id , " & car_id & " as car_id , " & act_id & " as act_id , typeuser_id , travel_id , regis_date , fname , lname , email , '" & HidExpire.Value & "' , " & ddlLicense.SelectedValue & " " & _
                       " from license  where license_id = " & ddlLicense.SelectedValue & _
                       " RETURNING license_id ;"
                Else
                    cmd.CommandText = "Insert Into license ( driver_id , car_id , act_id , typeuser_id , travel_id , regis_date , fname , lname , email , exp_date ) " & _
                   " select " & driver_id & " as driver_id , " & car_id & " as car_id , " & act_id & " as act_id , typeuser_id , travel_id , regis_date , fname , lname , email , '" & HidExpire.Value & "' " & _
                   " from license  where license_id = " & ddlLicense.SelectedValue & _
                   " RETURNING license_id ;"
                End If

                Dim license_id As Object = cmd.ExecuteScalar()


                Dim sqlInsert As String = "INSERT INTO travel_group_car( group_id, license_id) VALUES (:group_id, :license_id)"
                cmd.CommandText = CommandType.Text
                cmd.CommandText = sqlInsert
                cmd.Parameters.Clear()
                cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id
                cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = license_id
                cmd.ExecuteNonQuery()

                Datatable.Rows.Clear()
                Datatable.Rows.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer, ddlBorderCheckin.SelectedValue)
                Datatable.Rows.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer, ddlBorderCheckin.SelectedValue)
                Datatable.Rows.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer, ddladmin.SelectedValue)
                Dim tableinsert = dbconnect.UpdateDataTable(Datatable, "license", "WHERE license_id = " & license_id)



                Dim sqlUpdate As String = "Update license set  token=:token , regis_date=:regis_date , exp_date =:exp_date WHERE license_id = " & license_id
                cmd.CommandText = CommandType.Text
                cmd.CommandText = sqlUpdate
                cmd.Parameters.Clear()
                Dim pToken As Object = dbconnect.Token(license_id, car_id)
                cmd.Parameters.Add("token", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pToken
                cmd.Parameters.Add("regis_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
                cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = HidExpire.Value 'txtExpire.Text
                cmd.ExecuteNonQuery()
            Else


                Dim sqlInsert As String = "INSERT INTO travel_group_car( group_id, license_id) VALUES (:group_id, :license_id)"
                cmd.CommandText = CommandType.Text
                cmd.CommandText = sqlInsert
                cmd.Parameters.Clear()
                cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id
                cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlLicense.SelectedValue
                cmd.ExecuteNonQuery()

                Datatable.Rows.Clear()
                Datatable.Rows.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer, ddlBorderCheckin.SelectedValue)
                Datatable.Rows.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer, ddlBorderCheckin.SelectedValue)
                Datatable.Rows.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer, ddladmin.SelectedValue)
                Dim tableinsert = dbconnect.UpdateDataTable(Datatable, "license", "WHERE license_id = " & ddlLicense.SelectedValue)
            End If

           


            Response.Redirect("GroupAdd.aspx?id=" & group_id & "&tab=2&is_renew=")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            dbconnect = Nothing
            cmd.Connection.Close()
            con.Close()
            cmd.Dispose()
            con.Dispose()
        End Try

        'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2();", True)
    End Sub

    Protected Sub BtnAddGuide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddGuide.Click
        Dim dbconnect As New DBConnect
        Dim Datatable As DataTable = dbconnect.TableCommand

        Dim con As Npgsql.NpgsqlConnection = dbconnect.getConnection
        Dim cmd As New Npgsql.NpgsqlCommand
        Try
            con.Open()
            cmd.Connection = con

            Dim sqlInsert As String = "INSERT INTO travel_group_guide( group_id, guide_id , regis_no , regis_photo) VALUES (:group_id, :guide_id , :regis_no , :regis_photo) "
            cmd.CommandText = CommandType.Text
            cmd.CommandText = sqlInsert
            cmd.Parameters.Clear()
            cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id
            cmd.Parameters.Add("guide_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlGuide.SelectedValue
            cmd.Parameters.Add("regis_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregis_no.Text
            cmd.Parameters.Add("regis_photo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = hidPhotoAct.Value
            cmd.ExecuteNonQuery()
        Catch ex As Exception


        Finally
            cmd.Connection.Close()
            con.Close()
            cmd.Dispose()
            con.Dispose()
        End Try

        Response.Redirect("GroupAdd.aspx?id=" & group_id & "&tab=3&is_renew=")

    End Sub

    Protected Sub btnSetValueddladmin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetValueddladmin.Click
        ddladmin.SelectedValue = HidValueddladmin.Value
        updateddladmin.Update()
    End Sub

    Public Sub xgenDDLLicense(ByVal ddl As DropDownList)
        Try
            Dim db As New DBConnect
            Dim Dt As New DataTable
            Try
                Dim strselect As String

                Dim old_group_id As Integer = 0
                Try
                    old_group_id = db.executeScalar("select old_group_id from travel_group where group_id = " & group_id)
                Catch ex As Exception

                End Try
                If old_group_id > 0 Then

                    strselect = "select * from (select distinct car.plate || ' ' || country_car as text  , license_id as value " & _
                        ",(select max(exp_date) - min(start_date) as sumday   from car as a , license as b " & _
                        " WHERE(car_no = car.car_no And a.car_id = b.car_id) " & _
                        " and EXTRACT(YEAR FROM start_date) = EXTRACT(YEAR FROM now()) " & _
                        " and EXTRACT(YEAR FROM exp_date) = EXTRACT(YEAR FROM now())) as sumday " & _
                        " from license LEFT JOIN car on license.car_id = car.car_id "
                    strselect = strselect & " where license_id not in (select license_id from travel_group_car where group_id = " & group_id & ") " & _
                        " and license_id in  (select license_id from travel_group_car where group_id = " & old_group_id & ") " & _
                    " order by  car.plate || ' ' || country_car ) as dt where sumday < 60 "
                    Dt = db.getDataTable(strselect, "Data")
                Else
                 
                    strselect = "select * from ( select distinct car.plate || ' ' || country_car as text  , license_id as value " & _
                        " ,(select max(exp_date) - min(start_date) as sumday   from car as a , license as b " & _
                        "  WHERE(car_no = car.car_no And a.car_id = b.car_id)  " & _
                        " and EXTRACT(YEAR FROM start_date) = EXTRACT(YEAR FROM now())  " & _
                        " and EXTRACT(YEAR FROM exp_date) = EXTRACT(YEAR FROM now())) as sumday   " & _
                        " from license LEFT JOIN car on license.car_id = car.car_id " '& _
       
                    strselect = strselect & " where (license.status_id is null or license.status_id = 2 ) and travel_id = " & Session("user_id") & _
                      " and license_id not in (select license_id from travel_group_car where group_id = " & group_id & ") and license_id not in " & _
                      " ( select license_id from travel_group_car  LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id where user_id = " & Session("user_id") & "  )" & _
                    " order by  car.plate || ' ' || country_car ) as dt   WHERE sumday < 60 "

                    Dt = db.getDataTable(strselect, "Data")
                End If

            Catch ex As Exception

            End Try

            ddl.Items.Clear()
        
            If Dt.Rows.Count > 0 Then
                ddl.DataSource = Dt
                ddl.DataTextField = "text"
                ddl.DataValueField = "value"
                ddl.DataBind()
                ddl.SelectedIndex = 0
                ddl.Attributes.Add("data-inline", "true")
            Else

            End If
        Catch ex As Exception

        End Try

        genCarDriver()
    End Sub

    Public Sub genDDLLicense(ByVal ddl As DropDownList, ByVal group_id As Integer)
        Try
            Dim db As New DBConnect
            Dim Dt As New DataTable
            Try
                Dim strselect As String
                Dim old_group_id As Integer = 0
                Try
                    old_group_id = db.executeScalar("select old_group_id from travel_group where group_id = " & group_id)
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try


                Dim ar_startDate As String() = txtStart.Text.ToString.Split("/")
                Dim ar_endDate As String() = txtExpire.Text.ToString.Split("/")
                Dim startDate As New DateTime(ar_startDate(2), ar_startDate(1), ar_startDate(0)) 'DateTime = DateTime.Parse(txtStart.Text)
                Dim endDate As New DateTime(ar_endDate(2), ar_endDate(1), ar_endDate(0)) 'DateTime = DateTime.Parse(txtExpire.Text)
                Dim diff As TimeSpan = endDate - startDate
                Dim dayslicense As Double = diff.TotalDays + 1

                Dim str60 As String = "  select sum(sumday) + " & dayslicense & " as sumday , car_no from ( " & _
                " Select car_no , DATE_PART('day', travel_group.exp_date ::timestamp - travel_group.start_date ::timestamp) + 1 as sumday " & _
                " from license  LEFT JOIN car on license.car_id = car.car_id  " & _
                " LEFT JOIN travel_group_car ON license.license_id = travel_group_car.license_id " & _
                " LEFT JOIN travel_group ON travel_group_car.group_id = travel_group.group_id " & _
                " where license.status_id in (1,2,5)) dt group by car_no "


                Dim dtAct As String = " select act_start, act_ends , license_id  from act LEFT JOIN license on license.act_id = act.act_id  " & _
                " union all select act_start2 as act_start , act_ends2 as act_ends , license_id  from act LEFT JOIN license on license.act_id = act.act_id "

                Dim SdayFilter As String = startDate.Year & "-" & Format(CDbl(startDate.Month), "00") & "-" & Format(CDbl(startDate.Day), "00") '2019-11-29
                Dim EdayFilter As String = startDate.Year & "-" & Format(CDbl(startDate.Month), "00") & "-" & Format(CDbl(startDate.Day), "00") '2019-11-29
                Dim strWhereAct As String = " and license_id in (select license_id from (" & dtAct & ") dt where license_id > 0 " & _
                " and '" & SdayFilter & "' >= act_start and '" & EdayFilter & "' <= act_ends ) "

                If old_group_id > 0 Then
                   
                    strselect = "select distinct car.plate || ' ' || country_car as text  , license_id as value " & _
                        " from license LEFT JOIN car on license.car_id = car.car_id "
                    strselect = strselect & " where license_id not in (select license_id from travel_group_car where group_id = " & group_id & ") " & _
                        " and license_id in  (select license_id from travel_group_car where group_id = " & old_group_id & ") " & strWhereAct

                    strselect = strselect & " and car_no not in ( select distinct car_no from ( " & str60 & ") dt where sumday > 60 ) "
                    strselect = strselect & " order by  car.plate || ' ' || country_car "
                    Dt = db.getDataTable(strselect, "Data")
                Else
                    
                    strselect = "select car.plate || ' ' || country_car as text  , max(license_id) as value " & _
                        " from license LEFT JOIN car on license.car_id = car.car_id "
                    strselect = strselect & " where travel_id = " & Session("user_id")
                    strselect = strselect & " and ( license.status_id is null or license.status_id = 2 "

                    strselect = strselect & " or license.status_id in (4,7,8,9) "

                    Dim dayFilter As String = startDate.Year & "-" & Format(CDbl(startDate.Month), "00") & "-" & Format(CDbl(startDate.Day), "00") '2019-11-29

                    strselect = strselect & " or license_id in ( select max(license.license_id) " & _
                    " from travel_group_car LEFT JOIN license ON license.license_id = travel_group_car.license_id  LEFT JOIN car on license.car_id = car.car_id " & _
                    " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id where user_id = " & Session("user_id") & " and license.status_id = 5 and travel_group.exp_date < '" & dayFilter & "' " & _
                    " group by car.plate || ' ' || country_car ) "
                    strselect = strselect & " ) " & strWhereAct
                    strselect = strselect & " and license_id not in ( select license_id from travel_group_car where group_id = " & group_id & ") "
                   
                    strselect = strselect & " and license_id not in ( select copy_license_id from  license where copy_license_id > 0 and (license.status_id is null or license.status_id = 2 ) ) "

                    strselect = strselect & " and car_no not in ( select distinct car_no from ( " & str60 & ") dt where sumday > 60 ) "
                    strselect = strselect & " group by  car.plate || ' ' || country_car "
                    strselect = strselect & " order by  car.plate || ' ' || country_car "
                    Dt = db.getDataTable(strselect, "Data")
                End If

            Catch ex As Exception

            End Try

            ddl.Items.Clear()
           
            If Dt.Rows.Count > 0 Then
                ddl.DataSource = Dt
                ddl.DataTextField = "text"
                ddl.DataValueField = "value"
                ddl.DataBind()
                ddl.SelectedIndex = 0
                ddl.Attributes.Add("data-inline", "true")
            Else

            End If
        Catch ex As Exception

        End Try

        genCarDriver()
    End Sub

    Private Sub genCarDriver()
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String = "select type_name ,  CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name " & _
                " from license LEFT JOIN car on license.car_id = car.car_id " & _
                " left join type_car on type_car.type_id = car.typecar_id " & _
                " LEFT JOIN driver on driver.driver_id = license.driver_id where license_id = " & ddlLicense.SelectedValue
            Dt = db.getDataTable(strselect, "Data")
            If Dt IsNot Nothing AndAlso Dt.Rows.Count > 0 Then
                Dim drow As DataRow = Dt.Rows(0)
                lblType.Text = drow("type_name")
                lblDriver.Text = drow("driver_name")
            Else
                lblType.Text = ""
                lblDriver.Text = ""
            End If
        Catch ex As Exception

        Finally
            db = Nothing
        End Try
    End Sub

    Private PopulateS As New PopulateScript
    Dim cnt_car As Integer
    Dim is_renew As Integer

    Private Sub getCarLicense()
        Dim db As New DBConnect
        Try
            Dim dtCar As DataTable = db.getDataTable("select Row_number() over (order by travel_group_car.gid nulls last) as number , travel_group_car.gid , plate , country_car , type_name , dt.status " & _
                " , CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name " & _
                " , travel_group.start_date , travel_group.exp_date , travel_group_car.license_id , is_renew " & _
                " , CAST('MgtEdit.aspx?token=' || license.token || '&is_renew=' || travel_group.is_renew as varchar ) as urlEdit " & _
                " , CAST('MgtEdit.aspx?token=' || license.token || '&is_renew=' || travel_group.is_renew || '&ins=1' as varchar ) as urlIns " & _
                " from travel_group_car LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id  " & _
                " LEFT JOIN license on license.license_id = travel_group_car.license_id  " & _
                " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                " LEFT JOIN car on license.car_id = car.car_id " & _
                " left join type_car on type_car.type_id = car.typecar_id " & _
                " left join (SELECT count(group_id) status , license_id FROM public.travel_group_car group by license_id ) dt on dt.license_id = license.license_id " & _
                " where travel_group_car.group_id = " & group_id, "carr")
            is_renew = dtCar.Rows(0).Item("is_renew")
            PopulateS.SetGrid_Footable(gvMain, dtCar)
            UpdGrid.Update()

            cnt_car = dtCar.Rows.Count

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            db = Nothing
        End Try
        genDDLGuide(ddlGuide)
    End Sub
    Private Sub getGuide()
        Dim db As New DBConnect
        Try
           
            Dim dtGuide As DataTable = db.getDataTable(" select Row_number() over (order by guide.guide_id nulls last) as number , " & _
                                     " travel_group_guide.gid , guide.guide_id , CAST(prename ||' ' || guide_name || ' ' || guide_surname as varchar) " & _
                                     "  as guide_name ,  guide_tel , guide_idcard , ( " & _
                                     "   SELECT count(*) from travel_group_guide as a " & _
                                     "      LEFT JOIN travel_group as b on a.group_id = b.group_id " & _
                                     "      WHERE(guide_id = guide.guide_id) " & _
                                     "      and a.group_id not in (select group_id from travel_group_car where license_id in (select license_id from license where status_id in (4,7,8,9) )) " & _
                                     "      and ((start_date >= travel_group.start_date And exp_date <= travel_group.exp_date) or (start_date <= travel_group.exp_date  and exp_date >= travel_group.start_date)) " & _
                                     "  ) as status , " & _
                                     "    regis_no , regis_photo from guide  " & _
                                     "    INNER JOIN travel_group_guide on guide.guide_id = travel_group_guide.guide_id  " & _
                                     "    LEFT JOIN travel_group on travel_group.group_id = travel_group_guide.group_id " & _
                                     "    WHERE travel_group.group_id = " & group_id, "guide")
            PopulateS.SetGrid_Footable(gvMain_guide, dtGuide)
            UpdGrid.Update()
        Catch ex As Exception

        Finally
            db = Nothing
        End Try
        genDDLGuide(ddlGuide)
    End Sub

    Private Sub genDDLGuide(ByVal ddl As DropDownList)
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try

            Dim dt_guide = " select guide_id , CAST(prename ||' ' || guide_name || ' ' || guide_surname as varchar) as guide_name from guide " & _
                           " WHERE travel_user_id = " & Session("user_id") & " and guide_id not in (select guide_id from travel_group_guide WHERE group_id = " & group_id & ")"
            Dt = db.getDataTable(dt_guide, "Data")
           
            ddl.Items.Clear()
            If Dt.Rows.Count > 0 Then
                ddl.DataSource = Dt
                ddl.DataTextField = "guide_name"
                ddl.DataValueField = "guide_id"
                ddl.DataBind()
                ddl.SelectedIndex = 0
                ddl.Attributes.Add("data-inline", "true")
            Else

            End If
        Catch ex As Exception

        Finally
            db = Nothing
        End Try

    End Sub

    Private Sub genDDLGuide(ByVal ddl As DropDownList, ByVal group_id As Integer)
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try

            Dim dt_guide = " select guide_id , CAST(prename ||' ' || guide_name || ' ' || guide_surname as varchar) as guide_name from guide " & _
                           " WHERE travel_user_id = " & Session("user_id") & " and guide_id not in (select guide_id from travel_group_guide WHERE group_id = " & group_id & ")"
            Dt = db.getDataTable(dt_guide, "Data")
         
            ddl.Items.Clear()
            If Dt.Rows.Count > 0 Then
                ddl.DataSource = Dt
                ddl.DataTextField = "guide_name"
                ddl.DataValueField = "guide_id"
                ddl.DataBind()
                ddl.SelectedIndex = 0
                ddl.Attributes.Add("data-inline", "true")
            Else

            End If
        Catch ex As Exception

        Finally
            db = Nothing
        End Try

    End Sub



    Private Function CheckRepeat(ByVal license_id As Integer, ByVal start_date As Date, ByVal exp_date As Date) As Boolean
        Dim IsRepeat As Boolean = False


        Dim dtCar As New DataTable
        Dim db As New DBConnect
        Try
            dtCar = db.getDataTable(" SELECT start_date , exp_date FROM  travel_group_car LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id  " & _
                                    " where license_id = " & license_id, "carr")
        Catch ex As Exception

        Finally
            db = Nothing
        End Try
        For Each dr As DataRow In dtCar.Rows
            Dim s As Date = dr("start_date")
            Dim e As Date = dr("exp_date")
            IsRepeat = True
        Next

        Return IsRepeat
    End Function

    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblgid As Label = e.Row.Cells(0).FindControl("lblgid")
            Dim lnkDel As HyperLink = e.Row.Cells(9).FindControl("HyperLinkDel")
            lnkDel.Attributes.Add("onclick", "javascript:DelData(" & lblgid.Text & ");")
            If Hidstatus.Value = "2" Then
              
                lnkDel.Visible = False
            End If


            Dim Labelstatus As Label = e.Row.Cells(0).FindControl("Labelstatus")
            Dim status As HiddenField = e.Row.Cells(0).FindControl("Hidstatus")
            If status.Value = "1" Then

            Else
                Dim lbllicense_id As Label = e.Row.Cells(0).FindControl("lbllicense_id")
                Dim lblstart_date As Label = e.Row.Cells(0).FindControl("lblstart_date")
                Dim lblexp_date As Label = e.Row.Cells(0).FindControl("lblexp_date")
                If CheckRepeat(lbllicense_id.Text, lblstart_date.Text, lblexp_date.Text) Then
                    Labelstatus.Text = Labelstatus.Text.Replace("fa-check", "fa-asterisk")
                    Labelstatus.ForeColor = Drawing.Color.Red
                End If
            End If

        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        End If

        If is_renew = 0 Then
            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(7).Visible = False
                e.Row.Cells(8).Visible = False
            End If
        End If

    End Sub

    Protected Sub gvMain_guide_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain_guide.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblgid As Label = e.Row.Cells(0).FindControl("lblgid")
            Dim lblguide_id As Label = e.Row.Cells(0).FindControl("lblguide_id")
            Dim lnkDel As HyperLink = e.Row.Cells(0).FindControl("HyperLinkDel_guide")
            Dim Labelstatus As Label = e.Row.Cells(0).FindControl("Labelstatus_guide")
            Dim status As HiddenField = e.Row.Cells(0).FindControl("Hidstatus_guide")
            lnkDel.Attributes.Add("onclick", "javascript:DelData2(" & lblgid.Text & ");")
            If status.Value < 2 Then
                checkerr.Value = 0
            Else
                checkerr.Value = 1
                Labelstatus.Text = Labelstatus.Text.Replace("fa-check", "fa-asterisk")
                Labelstatus.ForeColor = Drawing.Color.Red
            End If

            If Hidstatus.Value = "2" Then
                If Hidchecktab_0.Value = "0" Then
                    lnkDel.Visible = True
                Else
                    lnkDel.Visible = False
                End If
            End If

            Dim lblregis_photo As Label = e.Row.Cells(0).FindControl("lblregis_photo")
            Dim Imgregis As Image = e.Row.Cells(0).FindControl("Imgregis")
            If lblregis_photo.Text = "" Then
                Imgregis.Visible = False
            Else
                Imgregis.ImageUrl = "~/Upload/FileGuide/" & lblregis_photo.Text
                Imgregis.Visible = True
            End If

        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        End If
    End Sub

    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = DBConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.Parameters.Clear()
            cmd.CommandText = " delete from travel_group_car where gid = " & HidDel_ID.Value
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Try
        'getCarLicense()
        'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2();", True)
        Response.Redirect("GroupAdd.aspx?id=" & group_id & "&tab=2&is_renew=")
    End Sub
    Protected Sub BtnDeleteGuide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete_guide.Click
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = DBConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.Parameters.Clear()
            cmd.CommandText = " delete from travel_group_guide where gid = " & HidDelGuide_id.Value
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Try
        'getGuide()
        'btnNext3_Click(e, e)
        Response.Redirect("GroupAdd.aspx?id=" & group_id & "&tab=3&is_renew=")

    End Sub

    Protected Sub gvMain_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvMain.PageIndexChanging
        gvMain.PageIndex = e.NewPageIndex
        getCarLicense()
    End Sub

    

    Protected Sub btnUploadAct_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnUploadAct.Click
        Dim srcName As String
        Dim srcExt As String
        If FileUpload5.PostedFile.FileName <> "" Then
            If FileUpload5.HasFile Then
                srcName = Path.GetFileName(FileUpload5.PostedFile.FileName)
                srcExt = Path.GetExtension(FileUpload5.PostedFile.FileName)
                srcName = "regis" & (srcName & DateTime.Now).GetHashCode
                FileUpload5.PostedFile.SaveAs(Server.MapPath("~/Upload/FileGuide/") + srcName & srcExt)
                hidPhotoAct.Value = srcName & srcExt
                PhotoAct.ImageUrl = "~/Upload/FileGuide/" & hidPhotoAct.Value
                PhotoAct.Visible = True
                btnUploadAct.Visible = False
                FileUpload5.CssClass = "w3-hide"
                PhotoDeleteAct.Visible = True
            End If
        End If
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab3();", True)
    End Sub

    Protected Sub PhotoDeleteAct_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PhotoDeleteAct.Command
        If File.Exists(fPathGuide & hidPhotoAct.Value) Then
            File.Delete(fPathGuide & hidPhotoAct.Value)
        End If
        btnUploadAct.Visible = True
        FileUpload5.Visible = True
        FileUpload5.CssClass = "w3-show"
        hidPhotoAct.Value = ""
        PhotoAct.Visible = False
        PhotoDeleteAct.Visible = False
    End Sub

    Protected Sub ddlLicense_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLicense.SelectedIndexChanged
        genCarDriver()
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2();", True)
    End Sub

    Protected Sub btnUploadPDF_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnUploadPDF.Click
        Dim Path As String = Server.MapPath(fPathPDF & hidfolderPDF.Value & "/")
        If (Not System.IO.Directory.Exists(Path)) Then
            System.IO.Directory.CreateDirectory(Path)
        End If
        saveFilePdf(Me.FileUploadPDF, Path)
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    End Sub

    Protected Sub btnDelPDF_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles btnDelPDF.Command
     
        btndelIns(btnDelPDF, hidFNamePDF, hidSNamePDF, hlFilePDF, "FilePDF")
        hidFNamePDF.Value = ""
        hidSNamePDF.Value = ""

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    End Sub

    Private fPathAttach As String = ConfigurationManager.AppSettings("FileAttach")
    Protected Sub btnUploadAttach_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnUploadAttach.Click
        Dim Path As String = Server.MapPath(fPathAttach & hidfolderAttach.Value & "/")
        If (Not System.IO.Directory.Exists(Path)) Then
            System.IO.Directory.CreateDirectory(Path)
        End If
        saveFileAttach(Me.FileUploadAttach, Path)
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();  setFocusPage('divMap');", True)
    End Sub

    Protected Sub btnDelAttach_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles btnDelAttach.Command

        btndelInsAttach(btnDelAttach, hidFNameAttach, hidSNameAttach, hlFileAttach, "FileAttach")
        hidFNameAttach.Value = ""
        hidSNameAttach.Value = ""

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1(); setFocusPage('divMap');", True)
    End Sub

    Private supportedFilePdf As String = ",.pdf,"
    Private Sub saveFilePdf(ByVal fuAttach As FileUpload, ByVal fPath As String)
        Dim fSize, maxFSize As Integer
        Dim srcFName, srcExt, sName As String

        srcFName = Path.GetFileName(fuAttach.PostedFile.FileName)
        srcExt = Path.GetExtension(fuAttach.PostedFile.FileName)
        'maxFSize = lblSize.Text

        If srcFName.Length <> 0 Then

            If supportedFilePdf.Contains("," & srcExt.ToLower.Trim & ",") Then
                fSize = CInt((fuAttach.PostedFile.ContentLength.ToString()) / 1024)
                If fSize = 0 Then
                    fSize = 1
                End If

                'If fSize < maxFSize Then
                sName = "Travel_itinerary_" & (srcFName & DateTime.Now).GetHashCode & ".pdf" '(srcFName & DateTime.Now).GetHashCode

                Dim pdf As String = fPath & sName
                DelFilePdf(pdf)

                fuAttach.PostedFile.SaveAs(pdf) '(fPath & sName & srcExt)
                lblError.Text = ""

                hidFNamePDF.Value = srcFName '& srcExt
                hidSNamePDF.Value = sName '& srcExt


                hl(hlFilePDF, hidSNamePDF, hidSNamePDF, "FilePDF")
                hlFilePDF.Text = srcFName '& srcExt '"Travel itinerary file "
                btnDelPDF.Visible = True
                UpdFilePDF.Update()
               
            Else
                lblError.Text = "Unable to add file '" & srcFName & "', the file type is not supported. " '& srcExt
            End If
        End If
    End Sub

    Private Sub saveFileAttach(ByVal fuAttach As FileUpload, ByVal fPath As String)
        Dim fSize, maxFSize As Integer
        Dim srcFName, srcExt, sName As String

        srcFName = Path.GetFileName(fuAttach.PostedFile.FileName)
        srcExt = Path.GetExtension(fuAttach.PostedFile.FileName)
        'maxFSize = lblSize.Text

        If srcFName.Length <> 0 Then

            If supportedFilePdf.Contains("," & srcExt.ToLower.Trim & ",") Then
                fSize = CInt((fuAttach.PostedFile.ContentLength.ToString()) / 1024)
                If fSize = 0 Then
                    fSize = 1
                End If

                'If fSize < maxFSize Then
                sName = "Travel_Attachments_" & (srcFName & DateTime.Now).GetHashCode & ".pdf" '(srcFName & DateTime.Now).GetHashCode

                Dim pdf As String = fPath & sName
                DelFilePdf(pdf)

                fuAttach.PostedFile.SaveAs(pdf) '(fPath & sName & srcExt)
                lblErrorAttach.Text = ""

                hidFNameAttach.Value = srcFName '& srcExt
                hidSNameAttach.Value = sName '& srcExt


                hlAttach(hlFileAttach, hidSNameAttach, hidSNameAttach, "FileAttach")
                hlFileAttach.Text = srcFName '& srcExt '"Travel itinerary file "
                btnDelAttach.Visible = True
                UpdFileAttach.Update()
                'Else
                '    lblError.Text = "ไม่สามารถเพิ่มไฟล์ " & srcFName & "(" & fSize & "K) เนื่องจากขนาดไฟล์มากกว่า " & maxFSize & "K"
                'End If
            Else
                lblErrorAttach.Text = "Unable to add file '" & srcFName & "', the file type is not supported. " '& srcExt
            End If
        End If
    End Sub

    Private Sub DelFilePdf(ByVal file As String)
        Dim FileIn As New FileInfo(file)
        If FileIn.Exists Then
            FileIn.Delete()
        End If
    End Sub

    Private fPathPDF As String = ConfigurationManager.AppSettings("FilePDF")
    Private Sub hl(ByVal hl As HyperLink, ByVal hids As HiddenField, ByVal hidf As HiddenField, ByVal fpath As String)
        Dim tempFile As FileInfo
        Dim strScriptOpen As String = ""
        Dim fpathstr = Server.MapPath(fPathPDF & hidfolderPDF.Value & "/")
        If hl.Text.Trim <> "" Then
            If File.Exists(fpathstr & hids.Value) Then
                tempFile = New System.IO.FileInfo(fpathstr & hids.Value)
              
                hl.NavigateUrl = "ViewFile.aspx?sname=" & hidfolderPDF.Value & "/" & hids.Value & "&fname=" & Server.UrlPathEncode(hidf.Value) & "&fPath=" & fpath
                'hl.NavigateUrl = fpathstr & hids.Value '""
                hl.Target = "_blank"
                hl.visible = True
            End If
        End If
    End Sub

    Private Sub hlAttach(ByVal hl As HyperLink, ByVal hids As HiddenField, ByVal hidf As HiddenField, ByVal fpath As String)
        Dim tempFile As FileInfo
        Dim strScriptOpen As String = ""
        Dim fpathstr = Server.MapPath(fPathAttach & hidfolderAttach.Value & "/")
        If hl.Text.Trim <> "" Then
            If File.Exists(fpathstr & hids.Value) Then
                tempFile = New System.IO.FileInfo(fpathstr & hids.Value)
                hl.NavigateUrl = "ViewFile.aspx?sname=" & hidfolderAttach.Value & "/" & hids.Value & "&fname=" & Server.UrlPathEncode(hidf.Value) & "&fPath=" & fpath
                hl.Target = "_blank"
            End If
        End If
    End Sub

    Protected Sub btnloadPDF_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnloadPDF.Click
        dialogSave()
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    End Sub

    Protected Sub btnloadAttach_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnloadAttach.Click
        dialogSaveAttach()
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    End Sub

    Private fpathstr As String
    Private Sub dialogSave()
        Dim objFileInfo As System.IO.FileInfo
        Try
            fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FilePDF"))
            If Not System.IO.File.Exists(fpathstr & hidSNamePDF.Value) Then Exit Sub
            objFileInfo = New System.IO.FileInfo(fpathstr & hidSNamePDF.Value)
            Response.Clear()

            Response.AddHeader("Content-Disposition", "attachment; filename=" & Server.UrlPathEncode(hidFNamePDF.Value))
            Response.AddHeader("Content-Length", objFileInfo.Length.ToString())
            Response.ContentType = "application/octet-stream"
            Response.WriteFile(objFileInfo.FullName)
        Catch
        Finally
            Response.End()
        End Try
    End Sub

    Private Sub dialogSaveAttach()
        Dim objFileInfo As System.IO.FileInfo
        Try
            fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FilePDFAttach"))
            If Not System.IO.File.Exists(fpathstr & hidSNameAttach.Value) Then Exit Sub
            objFileInfo = New System.IO.FileInfo(fpathstr & hidSNameAttach.Value)
            Response.Clear()

            Response.AddHeader("Content-Disposition", "attachment; filename=" & Server.UrlPathEncode(hidFNameAttach.Value))
            Response.AddHeader("Content-Length", objFileInfo.Length.ToString())
            Response.ContentType = "application/octet-stream"
            Response.WriteFile(objFileInfo.FullName)
        Catch
        Finally
            Response.End()
        End Try
    End Sub

    Protected Sub btnDelPDF_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) 'Handles btnDel.Click
        btndelIns(btnDelPDF, hidFNamePDF, hidSNamePDF, hlFilePDF, "FilePDF")
        hidFNamePDF.Value = ""
        hidSNamePDF.Value = ""
       
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    End Sub

    Private OtherFile As String
    Private Sub btndelIns(ByVal btndel As ImageButton, ByVal hidf As HiddenField, ByVal hids As HiddenField, ByVal hl As HyperLink, ByVal fpath As String)
        Dim fpathstr = Server.MapPath(fPathPDF & hidfolderPDF.Value & "/")
        Try
            'If hl.Text.Trim <> "" Then
            OtherFile = hids.Value
            If File.Exists(fpathstr & OtherFile) Then
                File.Delete(fpathstr & OtherFile)
                hl.Text = ""
                btndel.Visible = False
            End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnDelAttach_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) 'Handles btnDel.Click
        btndelIns(btnDelAttach, hidFNameAttach, hidSNameAttach, hlFileAttach, "FileAttach")
        hidFNamePDF.Value = ""
        hidSNamePDF.Value = ""

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    End Sub

    Private Sub btndelInsAttach(ByVal btndel As ImageButton, ByVal hidf As HiddenField, ByVal hids As HiddenField, ByVal hl As HyperLink, ByVal fpath As String)
        Dim fpathstr = Server.MapPath(fPathAttach & hidfolderAttach.Value & "/")
        Try
            'If hl.Text.Trim <> "" Then
            OtherFile = hids.Value
            If File.Exists(fpathstr & OtherFile) Then
                File.Delete(fpathstr & OtherFile)
                hl.Text = ""
                btndel.Visible = False
            End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvProv_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblprov_code As Label = e.Row.Cells(0).FindControl("lblprov_code")
            Dim lnkDel As ImageButton = e.Row.Cells(2).FindControl("ProvareaDelete")
           
            If lblprov_code.Text = checkin Or lblprov_code.Text = checkout Then
                lnkDel.Visible = False
            Else
                lnkDel.Visible = True
            End If

            If Hidstatus.Value = "2" Then
                If Hidchecktab_0.Value = "0" And Hidchecktab_8.Value = "0" Then
                    lnkDel.Visible = False
                ElseIf Hidchecktab_0.Value = "1" And Hidchecktab_8.Value = "1" Then
                    lnkDel.Visible = False
                ElseIf Hidchecktab_0.Value = "0" Then
                    lnkDel.Visible = False
                End If

            End If

        End If

    End Sub

End Class
