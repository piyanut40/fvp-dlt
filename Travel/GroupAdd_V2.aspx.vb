Imports System.Data
Imports Npgsql
Imports System.IO

Partial Class Travel_GroupAdd_V2
    Inherits System.Web.UI.Page
    Private Populate As New PopulateDropDown
    Public name As String
    Private tbProvice As New DataTable
    Dim strprov_code As String = ""


    Dim fPathGuide As String = Server.MapPath(ConfigurationManager.AppSettings("FileGuide"))

    Private Send As New SendEmail
    Private checkin As Object
    Private checkout As Object
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Page.IsPostBack = False Then
            If Session("user_id") = Nothing Or Session("user_type") = 1 Then
                Session.Clear()
                Response.Redirect("../Login.aspx")
            End If

            genDDLLicense(ddlLicense, IIf(Request.QueryString("id") Is Nothing, 0, Request.QueryString("id")))
            genDDLGuide(ddlGuide, IIf(Request.QueryString("id") Is Nothing, 0, Request.QueryString("id")))

            Populate.genAreaform(ddladmin, False)
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

            If Request.QueryString("is_renew") <> "" Then

                ddlBorderCheckin.Enabled = False
                txtStart.Enabled = False
                'ddlProvarea.Enabled = False
                Paneladd.Visible = False
                FileUploadPDF.Enabled = False
                btnDelPDF.Visible = False
                ddladmin.Enabled = False
                lnkSchMap.Visible = False
                divExtension.Visible = True
            End If



            'กรณีขยายเวลา
            If Not Request.QueryString("is_renew") Is Nothing Then
                LoadDataRenew()
            Else
                If Not ((Request.QueryString("id")) Is Nothing) Then
                    LoadData()
                Else
                    'Dim db As New DBConnect
                    checkin = dbconnect.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
                    checkout = dbconnect.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)

                End If
            End If

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
                    UpdatePanel13.update()
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

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack10", "get_IframeMap('" & strprov_code & "');checkddlProv();", True)


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
                                      " FROM travel_group  WHERE group_id = " & Request.QueryString("id")
            cmd.CommandText = CommandType.Text
            cmd.CommandText = strCheckUser
            dread = cmd.ExecuteReader()

            Dim para_checkin_id, para_checkout_id As Integer
            If dread.Read Then
                If Not dread("group_name") Is DBNull.Value Then
                    txtgroup_name.Text = dread("group_name")
                End If
                
                If Not dread("exp_date") Is DBNull.Value Then
                    ''txtExpire.Text = dread("exp_date")
                    'txtExpire.Text = Format(Month(dread("exp_date")), "00") & "/" & Format(Day(dread("exp_date")), "00") & "/" & CDate(dread("exp_date")).ToString("yyyy", enCul) ' Year(dread("exp_date"))
                    Dim exp_dateNew As Date = CDate(dread("exp_date")).AddDays(1)
                    txtStart.Text = Format(Month(exp_dateNew), "00") & "/" & Format(Day(exp_dateNew), "00") & "/" & CDate(exp_dateNew).ToString("yyyy", enCul) ' Year(dread("exp_date"))
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



            Dim sqlstr2 = "select area_id , prov_en , area_group.prov_code from area_group LEFT JOIN province on province.prov_code = area_group.prov_code WHERE group_id = '" & Request.QueryString("id") & "' order by area_id "
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
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con
            Dim strCheckUser As String = " SELECT group_name, start_date, exp_date, cntpeople, checkin_id, checkout_id , admin_id, travel_itinerary_filesaved, travel_itinerary_filename " & _
                                      " FROM travel_group  WHERE group_id = " & Request.QueryString("id")
            cmd.CommandText = CommandType.Text
            cmd.CommandText = strCheckUser
            dread = cmd.ExecuteReader()

            Dim para_checkin_id, para_checkout_id As Integer
            If dread.Read Then
                If Not dread("group_name") Is DBNull.Value Then
                    txtgroup_name.Text = dread("group_name")
                End If
                If Not dread("start_date") Is DBNull.Value Then
                    'txtStart.Text = dread("start_date")
                    txtStart.Text = Format(Month(dread("start_date")), "00") & "/" & Format(Day(dread("start_date")), "00") & "/" & CDate(dread("start_date")).ToString("yyyy", enCul) 'Year(dread("start_date"))
                End If
                If Not dread("exp_date") Is DBNull.Value Then
                    'txtExpire.Text = dread("exp_date")
                    txtExpire.Text = Format(Month(dread("exp_date")), "00") & "/" & Format(Day(dread("exp_date")), "00") & "/" & CDate(dread("exp_date")).ToString("yyyy", enCul) ' Year(dread("exp_date"))
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

            End If
            dread.Close()

            Dim _status As Integer = dbConnect.executeScalar("select coalesce(status_id,0) from license where license_id = (select license_id from travel_group_car where group_id = " & Request.QueryString("id") & ")")

            If _status = 2 Then
                ddlBorderCheckin.Enabled = False
                ddladmin.Enabled = False
                lnkSchMap.Visible = False
                'Page2.Enabled = False
                'Page3.Enabled = False
            End If
           

            Dim sqlstr2 = "select area_id , prov_en , area_group.prov_code from area_group LEFT JOIN province on province.prov_code = area_group.prov_code WHERE group_id = '" & Request.QueryString("id") & "' order by area_id "
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
        Dim strPopup As String = "javascript:w=window.open(" & _
                        """" & ResolveClientUrl("~/Map/MapAdmin2.aspx?" & paraMap) & """," & _
                        """SearchMapAdminWindow""," & _
                        """" & "location=0,status=0,scrollbars=yes,resizable=no," & _
                        "width=1024,height=780""" & _
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
                'ddlBorderCheckout.SelectedValue = ddlBorderCheckin.SelectedValue
                'UpdBorderCheckout.Update()
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
        Dim prov_code As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
        Dim admin_id As Object = db.executeScalar("select admin_id from admin where prov_code = '" & prov_code & "'")
        Dim prov_en As Object = db.executeScalar("select prov_en from province where prov_code = ( select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue & ") ")
        If ddlBorderCheckin.SelectedValue = ddlBorderCheckout.SelectedValue Then
            tbProvice.Clear()
            tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)
        Else
            If tbProvice.Select("prov_code=" & prov_code).Length > 0 Then
            Else
                tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)
            End If
        End If


        ddladmin.SelectedValue = admin_id

        checkin = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
        checkout = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)

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

        checkin = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckin.SelectedValue)
        checkout = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)
        Dim oldprov As String = tbProvice.Rows(0)("prov_code")
       
        Dim prov_code As Object = db.executeScalar("select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue)
        Dim admin_id As Object = db.executeScalar("select admin_id from admin where prov_code = '" & prov_code & "'")
        Dim prov_en As Object = db.executeScalar("select prov_en from province where prov_code = ( select prov_code from border_check where border_id = " & ddlBorderCheckout.SelectedValue & ") ")
      

        If ddlBorderCheckin.SelectedValue = ddlBorderCheckout.SelectedValue Then
            tbProvice.Clear()
            tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)
        Else
            If tbProvice.Select("prov_code=" & prov_code).Length > 0 Then
            Else
                tbProvice.Rows.Add(tbProvice.Rows.Count + 1, prov_en, prov_code)
            End If
        End If

        'ddladmin.SelectedValue = admin_id


        gvProv.DataSource = tbProvice
        gvProv.DataBind()
        UpdatePanel11.Update()
        UpdatePanel12.Update()
        updateddladmin.Update()


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
        ' ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack", "get_IframeMapDel(" & oldprov & ");", True)
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
                Dim group_id = Request.QueryString("id")
                Dim dbconect As New DBConnect
                Dim tablecommand As DataTable = dbconect.TableCommand
                Dim datatableGroup = dbconect.getDataTable("select license.license_id , license.token , license.fname , license.lname , license.email from travel_group_car LEFT JOIN license on license.license_id = travel_group_car.license_id WHERE travel_group_car.group_id = " & group_id, "license_group")

                For Each i In datatableGroup.Rows
                    tablecommand.Clear()
                    tablecommand.Rows.Add("status_id", NpgsqlTypes.NpgsqlDbType.Integer, 0)
                    tablecommand.Rows.Add("regis_no", NpgsqlTypes.NpgsqlDbType.Varchar, DBConnect.RegisterNo())
                    Dim tableUpdate = dbconect.UpdateDataTable(tablecommand, "license", "WHERE license_id = " & i("license_id").ToString())

                    Try
                        Send.Email(i("email").ToString(), i("fname").ToString() & " " & i("lname").ToString(), i("token").ToString(), 2)
                    Catch ex As Exception

                    End Try
                Next
                Response.Redirect("Group.aspx")
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
        If txtgroup_name.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Key Group Name!!!')", True)
        ElseIf txtStart.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Select Start date!!!')", True)
        ElseIf txtExpire.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Select End date!!!')", True)
        ElseIf hidFNamePDF.Value = "" Then
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script5", "alert('Choose Travel Itinerary File!!!')", True)
        Else
            Dim DBconnect As New DBConnect
            Dim con As Npgsql.NpgsqlConnection = DBconnect.getConnection
            Dim cmd As New Npgsql.NpgsqlCommand
            Dim tablecommand As DataTable = DBconnect.TableCommand

            'Dim transaction As NpgsqlTransaction
            Try
                con.Open()
                'transaction = con.BeginTransaction()
                cmd.Connection = con


                Dim old_group_id As Integer = 0
                If Request.QueryString("id") Is Nothing Or Not Request.QueryString("is_renew") Is Nothing Then
                    Dim is_renew As Integer = 0
                    If Not Request.QueryString("is_renew") Is Nothing Then
                        If Request.QueryString("is_renew").IndexOf(",") > -1 Then
                            is_renew = CInt(Request.QueryString("is_renew").Split(",")(0)) + 1
                        Else
                            is_renew = Request.QueryString("is_renew") + 1
                        End If

                        old_group_id = Request.QueryString("id")
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
                    " WHERE group_id = " & Request.QueryString("id")
                    cmd.CommandText = CommandType.Text
                    cmd.CommandText = sqlUpdate
                End If
                'HidExpire.Value = txtExpire.Text
                cmd.Parameters.Clear()
                cmd.Parameters.Add("group_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtgroup_name.Text
                cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtStart.Text.Trim = "", Nothing, txtStart.Text)
                cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txtExpire.Text.Trim = "", Nothing, txtExpire.Text)
                cmd.Parameters.Add("cntpeople", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0 'txtcntpeople.Text
                cmd.Parameters.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckin.SelectedValue
                cmd.Parameters.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlBorderCheckout.SelectedValue
                cmd.Parameters.Add("user_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session("user_id")
                cmd.Parameters.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddladmin.SelectedValue
                cmd.Parameters.Add("travel_itinerary_filename", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidFNamePDF.Value.Trim = "", Nothing, hidFNamePDF.Value)
                cmd.Parameters.Add("travel_itinerary_filesaved", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidSNamePDF.Value.Trim = "", Nothing, hidSNamePDF.Value)
                If Request.QueryString("id") Is Nothing Or Not Request.QueryString("is_renew") Is Nothing Then
                    cmd.Parameters.Add("attachments_file_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidFNameAttach.Value.Trim = "", Nothing, hidFNameAttach.Value)
                    cmd.Parameters.Add("attachments_file_saved", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(hidSNameAttach.Value.Trim = "", Nothing, hidSNameAttach.Value)
                    cmd.Parameters.Add("reason", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtReason.Text.Trim = "", Nothing, txtReason.Text)
                End If

                If Not Request.QueryString("is_renew") Is Nothing Then
                    Dim group_id As String
                    group_id = cmd.ExecuteScalar

                    '------------อัพโหลดจังหวัด-------------
                    cmd.CommandText = "Insert into area_group (prov_code , group_id )  select prov_code , " & group_id & " as group_id  from area_group  where group_id = " & old_group_id
                    cmd.ExecuteNonQuery()

                    
                    '------------Add Guide-------------
                    cmd.CommandText = " INSERT INTO travel_group_guide ( group_id, guide_id , regis_no , regis_photo )  " & _
                    " select " & group_id & " as group_id , guide_id , regis_no , regis_photo from travel_group_guide where group_id = " & old_group_id
                    cmd.ExecuteNonQuery()

                    Response.Redirect("GroupAdd.aspx?id=" & group_id & "&tab=2" & "&is_renew=1")
                Else


                    Dim group_id As String
                    If Request.QueryString("id") Is Nothing Then
                        group_id = cmd.ExecuteScalar
                        Dim sqlselectcheck As String = "SELECT area_id from area_group WHERE group_id = " & group_id

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
                            cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id
                            cmd.ExecuteNonQuery()
                        Next

                        '----------ลบจังหวัด---------------

                        For Each cRow In tbProviceold.Rows
                            cmd.Parameters.Clear()
                            cmd.CommandText = "delete from area_group where area_id =" & cRow("area_id")
                            cmd.ExecuteScalar()
                        Next

                     

                        Response.Redirect("GroupAdd.aspx?id=" & group_id & "&tab=2")
                    Else
                        cmd.ExecuteNonQuery()
                        group_id = Request.QueryString("id")
                        getCarLicense()
                        Dim sqlselectcheck As String = "SELECT area_id from area_group WHERE group_id = " & group_id

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
                            cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = group_id
                            cmd.ExecuteNonQuery()
                        Next

                        '----------ลบจังหวัด---------------

                        For Each cRow In tbProviceold.Rows
                            cmd.Parameters.Clear()
                            cmd.CommandText = "delete from area_group where area_id =" & cRow("area_id")
                            cmd.ExecuteScalar()
                        Next



                        Dim table As DataTable = DBconnect.getDataTable("select license_id from travel_group_car WHERE group_id = " & group_id, "group_car")

                        For Each i In table.Rows
                            areaCar(i("license_id").ToString)
                        Next
                        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab2();", True)
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
            " where travel_group.group_id = " & Request.QueryString("id") & " ) "

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
            Try
                old_group_id = dbconnect.executeScalar("select old_group_id from travel_group where group_id = " & Request.QueryString("id"))
            Catch ex As Exception

            End Try
            If old_group_id > 0 Then
                'กรณีขยายเวลา
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

                cmd.CommandText = "Insert Into driver ( prename , address , name , surname , license_expire , national , countries , gender " & _
                " , passport_photo , licensedriver_photo , idcard_no , county , zipcode , tel , email , birthday , passport_no , passport_expire , photo_cer ) " & _
                " select prename , address , name , surname , license_expire , national , countries , gender " & _
                " , passport_photo , licensedriver_photo , idcard_no , county , zipcode , tel , email , birthday , passport_no , passport_expire , photo_cer " & _
                " from driver where driver_id = (select driver_id from license where license_id = " & ddlLicense.SelectedValue & " )  " & _
                " RETURNING driver_id ; "
                Dim driver_id As Object = cmd.ExecuteScalar()


                cmd.CommandText = "Insert Into spare_driver (prename , name , surname , license_no , national , driver_id , passport_no , passport_expire , spare_ord " & _
                                  ", licensedriver_photo , address , state , country , zipcode , tel , email , gender , license_exp_date , passport_photo , photo_cer " & _
                                  ") " & _
                                  "select prename , name , surname , license_no , national , driver_id , passport_no , passport_expire , spare_ord " & _
                                  ", licensedriver_photo , address , state , country , zipcode , tel , email , gender , license_exp_date , passport_photo , photo_cer from spare_driver " & _
                                  " where sparedriver_id = ( select sparedriver_id from spare_driver where driver_id = " & driver_id & ")"
                cmd.ExecuteNonQuery()

               
                cmd.CommandText = " Insert Into act (act_no , act_name , act_tankno , act_start , act_ends , act_photo , act_company , act_no2 " & _
                            " , act_name2 , act_start2 , act_photo2 , act_company2 , act_ends2 ) " & _
                            " values( null , null , null , null , null , null , null , null " & _
                            " , null , null , null , null , null  ) RETURNING act_id ;"
                Dim act_id As Object = cmd.ExecuteScalar()




                HidExpire.Value = dbconnect.executeScalar("select exp_date from travel_group where group_id = " & Request.QueryString("id"))
                cmd.CommandText = "Insert Into license ( driver_id , car_id , act_id , typeuser_id , travel_id , regis_date , fname , lname , email , exp_date ) " & _
                   " select " & driver_id & " as driver_id , " & car_id & " as car_id , " & act_id & " as act_id , typeuser_id , travel_id , regis_date , fname , lname , email , '" & HidExpire.Value & "' " & _
                   " from license  where license_id = " & ddlLicense.SelectedValue & _
                   " RETURNING license_id ;"
                Dim license_id As Object = cmd.ExecuteScalar()


                Dim sqlInsert As String = "INSERT INTO travel_group_car( group_id, license_id) VALUES (:group_id, :license_id)"
                cmd.CommandText = CommandType.Text
                cmd.CommandText = sqlInsert
                cmd.Parameters.Clear()
                cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Request.QueryString("id")
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
                cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Request.QueryString("id")
                cmd.Parameters.Add("license_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ddlLicense.SelectedValue
                cmd.ExecuteNonQuery()

                Datatable.Rows.Clear()
                Datatable.Rows.Add("checkin_id", NpgsqlTypes.NpgsqlDbType.Integer, ddlBorderCheckin.SelectedValue)
                Datatable.Rows.Add("checkout_id", NpgsqlTypes.NpgsqlDbType.Integer, ddlBorderCheckin.SelectedValue)
                Datatable.Rows.Add("admin_id", NpgsqlTypes.NpgsqlDbType.Integer, ddladmin.SelectedValue)
                Dim tableinsert = dbconnect.UpdateDataTable(Datatable, "license", "WHERE license_id = " & ddlLicense.SelectedValue)
            End If

          

            Response.Redirect("GroupAdd.aspx?id=" & Request.QueryString("id") & "&tab=2")
        Catch ex As Exception

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
            cmd.Parameters.Add("group_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Request.QueryString("id")
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
        
        Response.Redirect("GroupAdd.aspx?id=" & Request.QueryString("id") & "&tab=3")
       
    End Sub

    Protected Sub btnSetValueddladmin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetValueddladmin.Click
        ddladmin.SelectedValue = HidValueddladmin.Value
        updateddladmin.Update()
    End Sub

    Public Sub genDDLLicense(ByVal ddl As DropDownList)
        Try
            Dim db As New DBConnect
            Dim Dt As New DataTable
            Try
                Dim strselect As String

                Dim old_group_id As Integer = 0
                Try
                    old_group_id = db.executeScalar("select old_group_id from travel_group where group_id = " & Request.QueryString("id"))
                Catch ex As Exception

                End Try
                If old_group_id > 0 Then

                    strselect = "select * from (select distinct car.plate || ' ' || country_car as text  , license_id as value " & _
                        ",(select max(exp_date) - min(start_date) as sumday   from car as a , license as b " & _
                        " WHERE(car_no = car.car_no And a.car_id = b.car_id) " & _
                        " and EXTRACT(YEAR FROM start_date) = EXTRACT(YEAR FROM now()) " & _
                        " and EXTRACT(YEAR FROM exp_date) = EXTRACT(YEAR FROM now())) as sumday " & _
                        " from license LEFT JOIN car on license.car_id = car.car_id "
                    strselect = strselect & " where license_id not in (select license_id from travel_group_car where group_id = " & Request.QueryString("id") & ") " & _
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
                
                    strselect = strselect & " where (license.status_id is null or license.status_id = 2) and travel_id = " & Session("user_id") & _
                      " and license_id not in (select license_id from travel_group_car where group_id = " & Request.QueryString("id") & ") and license_id not in " & _
                      " ( select license_id from travel_group_car  LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id where user_id = " & Session("user_id") & "  )" & _
                    " order by  car.plate || ' ' || country_car ) as dt   WHERE sumday < 60 "
                    '" order by  car.plate || ' ' || country_car || ' (' || type_name || ') ' || CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar)   "
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

                End Try
                If old_group_id > 0 Then

                    strselect = "select * from (select distinct car.plate || ' ' || country_car as text  , license_id as value " & _
                        ",(select coalesce(max(exp_date) - min(start_date),0) as sumday   from car as a , license as b " & _
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
                        " ,(select coalesce(max(exp_date) - min(start_date),0) as sumday   from car as a , license as b " & _
                        "  WHERE(car_no = car.car_no And a.car_id = b.car_id)  " & _
                        " and EXTRACT(YEAR FROM start_date) = EXTRACT(YEAR FROM now())  " & _
                        " and EXTRACT(YEAR FROM exp_date) = EXTRACT(YEAR FROM now())) as sumday   " & _
                        " from license LEFT JOIN car on license.car_id = car.car_id " '& _
                    
                    strselect = strselect & " where (license.status_id is null or license.status_id = 2) and travel_id = " & Session("user_id") & _
                      " and license_id not in (select license_id from travel_group_car where group_id = " & group_id & ") and license_id not in " & _
                      " ( select license_id from travel_group_car  LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id where user_id = " & Session("user_id") & "  )" & _
                    " order by  car.plate || ' ' || country_car ) as dt   WHERE sumday < 60 "
                    '" order by  car.plate || ' ' || country_car || ' (' || type_name || ') ' || CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar)   "
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
            Dim drow As DataRow = Dt.Rows(0)
            lblType.Text = drow("type_name")
            lblDriver.Text = drow("driver_name")
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
                " where travel_group_car.group_id = " & Request.QueryString("id"), "carr")
            is_renew = dtCar.Rows(0).Item("is_renew")
            PopulateS.SetGrid_Footable(gvMain, dtCar)
            UpdGrid.Update()

            cnt_car = dtCar.Rows.Count

        Catch ex As Exception

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
                                     "   LEFT JOIN travel_group as b on a.group_id = b.group_id " & _
                                     "            WHERE(guide_id = guide.guide_id) " & _
                                     "    and ((start_date >= travel_group.start_date And exp_date <= travel_group.exp_date) or (start_date <= travel_group.exp_date  and exp_date >= travel_group.start_date)) " & _
                                     "  ) as status , " & _
                                     "    regis_no , regis_photo from guide  " & _
                                     "    INNER JOIN travel_group_guide on guide.guide_id = travel_group_guide.guide_id  " & _
                                     "    LEFT JOIN travel_group on travel_group.group_id = travel_group_guide.group_id " & _
                                     "    WHERE travel_group.group_id = " & Request.QueryString("id"), "guide")
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
                           " WHERE travel_user_id = " & Session("user_id") & " and guide_id not in (select guide_id from travel_group_guide WHERE group_id = " & Request.QueryString("id") & ")"
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


            Dim Labelstatus As Label = e.Row.Cells(0).FindControl("Labelstatus")
            Dim Hidstatus As HiddenField = e.Row.Cells(0).FindControl("Hidstatus")
            If Hidstatus.Value = "1" Then

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
            Dim hidstatus As HiddenField = e.Row.Cells(0).FindControl("Hidstatus_guide")
            lnkDel.Attributes.Add("onclick", "javascript:DelData2(" & lblgid.Text & ");")
            If hidstatus.Value < 2 Then
                checkerr.Value = 0
            Else
                checkerr.Value = 1
                Labelstatus.Text = Labelstatus.Text.Replace("fa-check", "fa-asterisk")
                Labelstatus.ForeColor = Drawing.Color.Red
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
        Response.Redirect("GroupAdd.aspx?id=" & Request.QueryString("id") & "&tab=2")
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
        Response.Redirect("GroupAdd.aspx?id=" & Request.QueryString("id") & "&tab=3")

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
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
    End Sub

    Protected Sub btnDelAttach_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles btnDelAttach.Command

        btndelInsAttach(btnDelAttach, hidFNameAttach, hidSNameAttach, hlFileAttach, "FileAttach")
        hidFNameAttach.Value = ""
        hidSNameAttach.Value = ""

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Script", "tab1();", True)
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
                'Else
                '    lblError.Text = "ไม่สามารถเพิ่มไฟล์ " & srcFName & "(" & fSize & "K) เนื่องจากขนาดไฟล์มากกว่า " & maxFSize & "K"
                'End If
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
        End If

    End Sub

End Class
