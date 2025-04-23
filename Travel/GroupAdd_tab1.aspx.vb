Imports System.Data
Imports System.IO
Imports Npgsql

Partial Class Travel_GroupAdd_tab1
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With tbProvice
            .Columns.Add("area_id")
            .Columns.Add("prov_en")
            .Columns.Add("prov_code")
        End With

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
        Else
            group_id = Nothing
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

        strChkDate = "select min(the_day) from (SELECT *  FROM generate_series(timestamp '" & DateAdd(DateInterval.Day, (_day + Cnt_h_date), Date.Today) & "', timestamp '" & DateAdd(DateInterval.Day, (_day + Cnt_h_date + 7), Date.Today) & "' , interval  '1 day') the_day  " & _
            " WHERE the_day not in (SELECT h_date FROM holiday where extract('ISODOW' FROM h_date) < 6 ) ) dt "
        _date = DBCon.executeScalar(strChkDate)

        min_date = "+" & DateDiff(DateInterval.Day, Date.Today, _date)
        If Page.IsPostBack = False Then

            Populate.genAreaform(ddladmin, False)
            Populate.genDDLProvince(ddlProvarea, False)
            Populate.genDDLBorder(ddlBorderCheckin, False, "")
            Populate.genDDLBorder(ddlBorderCheckout, False, "")
            btnDelPDF.Visible = False

            AddPopupMapAdmin("")
            genExplicenseDate()


            If Request.QueryString("is_renew").Contains(",0") Then
                LoadDataRenew()
            Else
                If Not ((group_id) Is Nothing) Then
                    LoadData()
                Else
                    genGridProvice(False)
                End If
            End If
        End If
        For Each row As GridViewRow In gvProv.Rows
            Dim nrow As DataRow = tbProvice.NewRow
            nrow("area_id") = CType(row.Cells(0).FindControl("lblarea_id"), Label).Text
            nrow("prov_code") = CType(row.Cells(0).FindControl("lblprov_code"), Label).Text
            nrow("prov_en") = CType(row.Cells(0).FindControl("lblprov_en"), Label).Text
            tbProvice.Rows.Add(nrow)
        Next
    End Sub

    Private Sub LoadDataRenew()
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con
            Dim strCheckUser As String = " SELECT group_name, start_date, exp_date, cntpeople, checkin_id, checkout_id , admin_id, travel_itinerary_filesaved, travel_itinerary_filename, attachments_file_name, attachments_file_saved, reason " & _
                                      " FROM travel_group  WHERE group_id = " & group_id
            cmd.CommandText = CommandType.Text
            cmd.CommandText = strCheckUser
            dread = cmd.ExecuteReader()

            Dim para_checkin_id, para_checkout_id As Integer
            If dread.Read Then
                If Not dread("group_name") Is DBNull.Value Then
                    txtgroup_name.Text = dread("group_name")
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

           

            genGridProvice(False)
           
            If tbProvice.Rows.Count > 0 Then
            
                Dim strprov_codeNew As String = "'-1'"
                For Each i As DataRow In tbProvice.Rows
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
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "alert('" & ex.Message.ToString & "');", True)
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
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con

            Dim strCheckUser As String = " SELECT travel_group.group_name, travel_group.start_date, travel_group.exp_date, travel_group.cntpeople, travel_group.checkin_id, travel_group.checkout_id " & _
                                        ", travel_group.admin_id, travel_group.travel_itinerary_filesaved, travel_group.travel_itinerary_filename, coalesce(license.status_id,0) as status " & _
                                        ", coalesce(check_tab0,0) as check_tab0 , coalesce(check_tab1,0) as check_tab1 , coalesce(check_tab2,0) as check_tab2 , coalesce(check_tab3,0) as check_tab3 , coalesce(check_tab4,0) as check_tab4 , coalesce(check_tab8,0) as check_tab8 " & _
                                        " FROM travel_group " & _
                                        " LEFT JOIN travel_group_car on travel_group_car.group_id = travel_group.group_id " & _
                                        " LEFT JOIN license on travel_group_car.license_id = license.license_id " & _
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

                'ข้อมูลการเข้า-ออกด่านพรมแดน
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
                    'Page2.Enabled = False
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
                            'Page3.Enabled = False
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
                        'Page3.Enabled = False
                    End If
                    'Page3.Enabled = False
                End If
            Catch ex As Exception

            End Try

            genGridProvice(False)
        
            If tbProvice.Rows.Count > 0 Then


                genDDLBorderNew(ddlBorderCheckin, False, "")
                ddlBorderCheckin.SelectedValue = para_checkin_id
                UpdBorderCheckin.Update()

                genDDLBorderNew(ddlBorderCheckout, False, "")
                ddlBorderCheckout.SelectedValue = para_checkout_id
                UpdBorderCheckout.Update()


            End If



        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "alert('" & ex.Message.ToString & "');", True)
        Finally
            cmd.Connection.Close()
            con.Close()
            dbConnect = Nothing
            con.Dispose()
            cmd.Dispose()

        End Try
    End Sub

    Private Sub genDDLBorderNew(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean, ByVal _strprov_code As String)
        'ด่านพรหมแดน
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try
            Dim strselect As String
            If _strprov_code Like "*0*" Then
                strselect = " select border_id as value , CAST(border_nameen || '  (' ||  prov_en || ')' as varchar ) as text " & _
                            " from  border_check LEFT JOIN province on province.prov_code = border_check.prov_code Order By border_id "
            ElseIf _strprov_code <> "" Then
                strselect = " select border_id as value , CAST(border_nameen || '  (' ||  prov_en || ')' as varchar ) as text " & _
               " from  border_check LEFT JOIN province on province.prov_code = border_check.prov_code WHERE province.prov_code in (" & _strprov_code & ") Order By border_id "
            Else
                strselect = " select border_id as value , CAST(border_nameen || '  (' ||  prov_en || ')' as varchar ) as text " & _
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

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptddlBorder", "checkddlBorder();", True)
    End Sub

    Private Sub AddPopupMapAdmin(ByVal paraMap As String)
        Dim strPopup As String = "javascript:w=window.open(" & _
                        """" & ResolveClientUrl("~/Map/MapAdmin2.aspx?" & paraMap) & """," & _
                        """SearchMapAdminWindow""," & _
                        """" & "location=0,status=0,scrollbars=yes,resizable=no," & _
                        "width=1024,height=780""" & _
                        ");w.focus();"
        lnkSchMap.NavigateUrl = "javascript://"
        lnkSchMap.Attributes.Add("OnClick", strPopup)
    End Sub

    Private Sub genExplicenseDate()
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
        dbconnect = Nothing
    End Sub

    Private Sub genGridProvice(ByVal IsAdd As Boolean)
        Dim dbconnect As New DBConnect
        Dim oldprov As String
        If Page.IsPostBack Then
            oldprov = tbProvice.Rows(0)("prov_code")
        End If
        checkin = dbconnect.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
        checkout = dbconnect.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)
        If IsAdd Then

        ElseIf group_id > 0 Then
            Dim sqlstr2 = "select area_id , prov_en , area_group.prov_code from area_group LEFT JOIN province on province.prov_code = area_group.prov_code " & _
                " WHERE group_id = '" & group_id & "' order by area_id "
            tbProvice = dbconnect.getDataTable(sqlstr2, "DataTable2")
            If tbProvice.Select("prov_code= '" & checkin & "' ").Length = 0 Then
                Dim checkin_en As String = dbconnect.executeScalar("select prov_en from province where prov_code = '" & checkin & "'")
                tbProvice.Rows.Add(tbProvice.Rows.Count + 1, checkin_en, checkin)
            End If
            If tbProvice.Select("prov_code= '" & checkout & "' ").Length = 0 Then
                Dim checkout_en As String = dbconnect.executeScalar("select prov_en from province where prov_code = '" & checkout & "'")
                tbProvice.Rows.Add(tbProvice.Rows.Count + 1, checkout_en, checkout)
            End If
        Else
            If ddlBorderCheckin.SelectedValue = ddlBorderCheckout.SelectedValue Then
                tbProvice.Clear()
                Dim prov_code As Object = dbconnect.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
                Dim prov_en As Object = dbconnect.executeScalar("select prov_en from province where prov_code = ( select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue & ") ")
                tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)
            Else
                tbProvice.Clear()
                Dim checkin_en As String = dbconnect.executeScalar("select prov_en from province where prov_code = '" & checkin & "'")
                Dim checkout_en As String = dbconnect.executeScalar("select prov_en from province where prov_code = '" & checkout & "'")
                'tbProvice.Rows.Add(tbProvice.Rows.Count + 1, checkin_en, checkin)
                If tbProvice.Select("prov_code=" & checkin).Length > 0 Then

                Else
                    tbProvice.Rows.Add(tbProvice.Rows.Count + 1, checkin_en, checkin)
                End If

                'tbProvice.Rows.Add(tbProvice.Rows.Count + 1, checkout_en, checkout)
                If tbProvice.Select("prov_code=" & checkout).Length > 0 Then

                Else
                    tbProvice.Rows.Add(tbProvice.Rows.Count + 1, checkout_en, checkout)
                End If
            End If
        End If
        gvProv.DataSource = tbProvice
        gvProv.DataBind()
        UpdatePanel11.Update()
        UpdatePanel12.Update()

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

        Dim _Script As String = ""
        If Page.IsPostBack Then
            _Script = " get_IframeMapDel(" & oldprov & ");  "
        End If
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack10", _Script & " get_IframeMap('" & strprov_code & "'); checkddlProv();", True)
        dbconnect = Nothing
    End Sub

    Protected Sub BtnBorderCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBorderCheck.Click
        genGridProvice(False)
    End Sub

    Protected Sub BtnBorderCheckOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBorderCheckOut.Click
        genGridProvice(False)
    End Sub

    Protected Sub btnProv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProv.Click
        Dim nrow As DataRow = tbProvice.NewRow
        nrow("area_id") = tbProvice.Rows.Count + 1
        nrow("prov_code") = ddlProvarea.SelectedValue
        nrow("prov_en") = ddlProvarea.SelectedItem.Text
        tbProvice.Rows.Add(nrow)
        genGridProvice(True)
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
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Response.Redirect("Group.aspx")
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "window.parent.tab_activeIframe(0);", True)
    End Sub

    Protected Sub btnNext2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext2.Click
        Dim ar_startDate As String() = txtStart.Text.ToString.Split("/")
        Dim ar_endDate As String() = txtExpire.Text.ToString.Split("/")
        Dim startDate 'As New DateTime(ar_startDate(2), ar_startDate(1), ar_startDate(0)) 'DateTime.Parse(Format(CDate(txtStart.Text), "MM/dd/yyyy"))
        Dim endDate 'As New DateTime(ar_endDate(2), ar_endDate(1), ar_endDate(0)) ' DateTime.Parse(Format(CDate(txtExpire.Text), "MM/dd/yyyy"))
        Try
            startDate = New DateTime(ar_startDate(2), ar_startDate(1), ar_startDate(0))
            endDate = New DateTime(ar_endDate(2), ar_endDate(1), ar_endDate(0))
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Select End date!!!')", True)
            Exit Sub
        End Try
        If txtgroup_name.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Key Group Name!!!')", True)
        ElseIf txtStart.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Select Start date!!!')", True)
        ElseIf txtExpire.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Select End date!!!')", True)
        ElseIf CDate(startDate) > CDate(endDate) Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('End date is greater than the Start date!!!')", True)
        ElseIf hidFNamePDF.Value = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Choose Travel Itinerary File!!!')", True)
        Else

            Dim diff As TimeSpan = endDate - startDate
            Dim days As Double = diff.TotalDays
            If days > 30 Then
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Travel date must be less than 30 days.!!!')", True)
            Else
                Dim DBconnect As New DBConnect
                Dim con As Npgsql.NpgsqlConnection = DBconnect.getConnection
                Dim cmd As New Npgsql.NpgsqlCommand
                Dim tablecommand As DataTable = DBconnect.TableCommand

                Dim ss_exp = DBconnect.executeScalar("select to_char(license_exp , 'dd/mm/YYYY') license_exp from user_travel WHERE user_id = " & Session("user_id"))
                Dim ar_exp As String() = ss_exp.Split("/")
                Dim _license_exp As New Date(ar_exp(2), ar_exp(1), ar_exp(0))
                If CDate(endDate) > CDate(_license_exp) Then
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
                            Dim sqlInsert As String = "INSERT INTO travel_group ( group_name, is_active, start_date, exp_date, cntpeople , checkin_id , checkout_id , user_id , admin_id, travel_itinerary_filename, travel_itinerary_filesaved " & _
                                " , is_renew , old_group_id, attachments_file_name, attachments_file_saved, reason ) " & _
                            " VALUES (:group_name, 1, :start_date, :exp_date, :cntpeople , :checkin_id , :checkout_id , :user_id , :admin_id, :travel_itinerary_filename, :travel_itinerary_filesaved " & _
                                " , " & is_renew & " , " & old_group_id & ", :attachments_file_name, :attachments_file_saved, :reason ) RETURNING group_id;  "
                            cmd.CommandText = CommandType.Text
                            cmd.CommandText = sqlInsert
                        Else
                            Dim sqlUpdate As String = " UPDATE travel_group SET group_name = :group_name , start_date = :start_date , exp_date = :exp_date , cntpeople = :cntpeople " & _
                            " , checkin_id = :checkin_id , checkout_id = :checkout_id , user_id = :user_id , admin_id = :admin_id , travel_itinerary_filename = :travel_itinerary_filename, travel_itinerary_filesaved = :travel_itinerary_filesaved " & _
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
                        cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckin.SelectedValue
                        cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckout.SelectedValue
                        cmd.Parameters.Add("user_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("user_id")
                        cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddladmin.SelectedValue
                        cmd.Parameters.Add("travel_itinerary_filename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidFNamePDF.Value.Trim = "", Nothing, hidFNamePDF.Value)
                        cmd.Parameters.Add("travel_itinerary_filesaved", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidSNamePDF.Value.Trim = "", Nothing, hidSNamePDF.Value)
                        If group_id Is Nothing Or Request.QueryString("is_renew").Contains(",0") Then 'Not Request.QueryString("is_renew") Is Nothing Then
                            cmd.Parameters.Add("attachments_file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidFNameAttach.Value.Trim = "", Nothing, hidFNameAttach.Value)
                            cmd.Parameters.Add("attachments_file_saved", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidSNameAttach.Value.Trim = "", Nothing, hidSNameAttach.Value)
                            cmd.Parameters.Add("reason", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReason.Text.Trim = "", Nothing, txtReason.Text)
                        End If

                        If Request.QueryString("is_renew").Contains(",0") Then 'Not Request.QueryString("is_renew") Is Nothing Then
                            Dim group_id As String
                            group_id = cmd.ExecuteScalar

                            '------------อัพโหลดจังหวัด-------------
                            cmd.CommandText = "Insert into area_group (prov_code , group_id )  select prov_code , " & group_id & " as group_id  from area_group  where group_id = " & old_group_id
                            cmd.ExecuteNonQuery()


                            '------------Add Guide-------------
                            cmd.CommandText = " INSERT INTO travel_group_guide ( group_id, guide_id , regis_no , regis_photo )  " & _
                            " select " & group_id & " as group_id , guide_id , regis_no , regis_photo from travel_group_guide where group_id = " & old_group_id
                            cmd.ExecuteNonQuery()


                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "window.parent.tab_activeIframe(2);", True)
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
                                    cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id1
                                    cmd.ExecuteNonQuery()
                                Next

                                '----------ลบจังหวัด---------------

                                For Each cRow In tbProviceold.Rows
                                    cmd.Parameters.Clear()
                                    cmd.CommandText = "delete from area_group where area_id =" & cRow("area_id")
                                    cmd.ExecuteScalar()
                                Next

                             
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "window.parent.tab_activeIframe(2);", True)
                            Else
                                cmd.ExecuteNonQuery()
                                group_id1 = group_id
                                'getCarLicense()
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
                                'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2();", True)
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "window.parent.tab_activeIframe(2);", True)
                            End If

                        End If


                    Catch ex As Exception

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
    End Sub

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

#Region "Travel Itinerary (For pdf files only) :"

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

    Protected Sub btnUploadPDF_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnUploadPDF.Click
        Dim Path As String = Server.MapPath(fPathPDF & hidfolderPDF.Value & "/")
        If (Not System.IO.Directory.Exists(Path)) Then
            System.IO.Directory.CreateDirectory(Path)
        End If
        saveFilePdf(Me.FileUploadPDF, Path)
        'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
        genGridProvice(False)
    End Sub

    Protected Sub btnDelPDF_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDelPDF.Click
        btndelIns(btnDelPDF, hidFNamePDF, hidSNamePDF, hlFilePDF, "FilePDF")
        hidFNamePDF.Value = ""
        hidSNamePDF.Value = ""
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

#End Region

    Private fPathPDF As String = ConfigurationManager.AppSettings("FilePDF")
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


    Private Sub hl(ByVal hl As HyperLink, ByVal hids As HiddenField, ByVal hidf As HiddenField, ByVal fpath As String)
        Dim tempFile As FileInfo
        Dim strScriptOpen As String = ""
        Dim fpathstr = Server.MapPath(fPathPDF & hidfolderPDF.Value & "/")
        If hl.Text.Trim <> "" Then
            If File.Exists(fpathstr & hids.Value) Then
                tempFile = New System.IO.FileInfo(fpathstr & hids.Value)

                hl.NavigateUrl = "ViewFile.aspx?sname=" & hidfolderPDF.Value & "/" & hids.Value & "&fname=" & Server.UrlPathEncode(hidf.Value) & "&fPath=" & fpath

                hl.Target = "_blank"
                hl.Visible = True
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

    Private fPathAttach As String = ConfigurationManager.AppSettings("FileAttach")
    Protected Sub btnUploadAttach_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnUploadAttach.Click
        Dim Path As String = Server.MapPath(fPathAttach & hidfolderAttach.Value & "/")
        If (Not System.IO.Directory.Exists(Path)) Then
            System.IO.Directory.CreateDirectory(Path)
        End If
        saveFileAttach(Me.FileUploadAttach, Path)
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", " setFocusPage('divMap');", True)
        genGridProvice(False)
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



    Protected Sub MainContent_btnSetValueddladmin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainContent_btnSetValueddladmin.Click
        ddladmin.SelectedValue = MainContent_HidValueddladmin.Value
        updateddladmin.Update()
    End Sub


End Class
