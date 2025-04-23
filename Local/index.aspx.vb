Imports System.Data
Imports Npgsql
Partial Class Local_index
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected text As String
    Protected name As String
    Protected qrCode As String = "https://api.qrserver.com/v1/create-qr-code/?size=300x300&data="
    Protected url As String = HttpContext.Current.Request.Url.Host & "/BorderTransport/Report/QRCode.aspx?token="
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            If Session("user_id") = Nothing Or Session("user_type") = 2 Then
                Response.Redirect("../Login.aspx")
            Else
                If PopulateS.IsMobile Then
                    lnkAdd.Text = "<i class='fa fa-plus' aria-hidden='true' ></i> Add"
                    Css = ""
                End If

                text = "ค้นหาขออนุญาตนำรถท่องเที่ยวเข้ามาในราชอาณาจักร"
                name = "ชื่อผู้ใช้รถ"
                Populate.genPageSize(ddl_PageSize)
                ddl_PageSize.SelectedValue = 10
                loadData()

            End If

        End If

        If Session("typeuser_id") <> 1 Then
            lnkAddgroup2.Visible = False
        End If

    End Sub
    Private Sub loadData()
        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dt As DataTable
        Dim strsql As String = ""
        Dim query = ""
        Try
            If Session("typeuser_id") = 1 Then
                query = "'MgtEdit.aspx?token=' || token || '&group=' || typegroup as varchar"
            Else
                query = "'MgtEdit.aspx?token=' || token  as varchar"
            End If
            strsql = " SELECT * FROM ( SELECT Row_number() over (order by regis_date desc nulls last) as number , license_id , token , CAST(prename || ' ' || name || ' ' || surname as varchar) as name " & _
                " , type_name as typecar_en, brands, model as models, status_en , CAST('LicenseDtl.aspx?rt=" & Session("typeuser_id") & "&token=' || token as varchar ) as urlDoc, CAST(" & query & ") as urlEdit " & _
                " , CAST('..\RptApplication.aspx?token=' || token as varchar ) as urlPDF FROM license " & _
                " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                " LEFT JOIN car on car.car_id = license.car_id " & _
                " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
                " LEFT JOIN status on license.status_id = status.status_id " & _
                " LEFT JOIN user_cus on license.email = user_cus.username " & _
                " WHERE user_cus.user_id =" & Session("user_id") & " and license.typeuser_id = " & Session("typeuser_id") & " and (license.status_id = 0 or license.status_id is null or license.status_id = 2) ) as dt "

            If txtName.Text <> "" Then
                strsql = strsql & "WHERE lower(name) like '%" & txtName.Text.ToLower & "%' "
            End If

            dt = dbConnect.getDataTable(strsql, "local")

            PopulateS.SetGrid_Footable(gvMain, dt)
            UpdGrid.Update()

        Catch ex As Exception

        Finally
            dbConnect = Nothing
        End Try



    End Sub
    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim url As String = HttpContext.Current.Request.Url.Host & "/BorderTransport/Documenttoken="
            Dim lblLicense As Label = e.Row.Cells(0).FindControl("lblLicense")
            Dim lblToken As Label = e.Row.Cells(0).FindControl("lbltoken")



            Dim lnkDel As HyperLink = e.Row.Cells(11).FindControl("HyperLinkDel")
            lnkDel.Attributes.Add("onclick", "javascript:DelData(" & lblLicense.Text & ");")

            Dim lnkEdit As HyperLink = e.Row.Cells(10).FindControl("HyperEdit")

            Dim lnkDoc As HyperLink = e.Row.Cells(7).FindControl("HyperPDF")

            If e.Row.Cells(6).Text = "&nbsp;" Then
                lnkDoc.Visible = False
                e.Row.Cells(6).Text = "Draft"
            ElseIf e.Row.Cells(6).Text = "Incomplete" Then

            Else
                lnkEdit.Visible = False
                lnkDel.Visible = False
            End If





        ElseIf e.Row.RowType = DataControlRowType.Header Then
            'If Request.QueryString("rt") = 5 Then
            '    e.Row.Cells(7).Visible = False
            'End If
            e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(9).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(10).Attributes.Add("data-breakpoints", "xs")
            'e.Row.Cells(11).Attributes.Add("data-breakpoints", "xs")
            'e.Row.Cells(12).Attributes.Add("data-breakpoints", "xs")


        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        End If
    End Sub
    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim transaction As NpgsqlTransaction
        Try
            con.Open()
            transaction = con.BeginTransaction()
            cmd.Connection = con
            cmd.Parameters.Clear()

            cmd.CommandText = " delete from driver where driver_id = (select coalesce(driver_id,0) from license where license_id = " & HidDel_ID.Value & ")"
            cmd.ExecuteNonQuery()

            cmd.CommandText = " delete from spare_driver where driver_id = (select coalesce(driver_id,0) from license where license_id = " & HidDel_ID.Value & ")"
            cmd.ExecuteNonQuery()

            cmd.CommandText = " delete from car where car_id = (select coalesce(car_id,0) from license where license_id = " & HidDel_ID.Value & ")"
            cmd.ExecuteNonQuery()


            cmd.CommandText = " delete from act where act_id = (select coalesce(act_id,0) from license where license_id = " & HidDel_ID.Value & ")"
            cmd.ExecuteNonQuery()

            cmd.CommandText = " delete from license where license_id = " & HidDel_ID.Value
            cmd.ExecuteNonQuery()


            transaction.Commit()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
        loadData()
    End Sub

    Protected Sub BtnResetActive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnResetActive.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT token from license WHERE license_id = '" & HidLicense.Value & "' "
            Dim token = cmd.ExecuteScalar()
            cmd.CommandText = "Update license set license_no =:license_no , start_date =:start_date , exp_date = :exp_date , qrcode = :qrcode , status_id = 1 WHERE license_id = '" & HidLicense.Value & "' "
            cmd.Parameters.Clear()
            cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = licenseNo()
            cmd.Parameters.Add("start_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Date.Now
            cmd.Parameters.Add("exp_date", NpgsqlTypes.NpgsqlDbType.Date).Value = Now.Month & "-" & Now.Day & "-" & Now.Year + 1
            cmd.Parameters.Add("qrcode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = qrCode & url & token
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถอัพเดตข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                con.Close()
            End If
            dbConnect = Nothing
        End Try
        loadData()

    End Sub

    ''ออกเลขที่ใบอนุญาติ
    Private Function licenseNo() As String
        Dim sqlstr As String
        Dim DBconnect As New DBConnect
        sqlstr = " SELECT license_id  from ( select max(SUBSTRING(license_no,1,4)) as license_id , MAX(SUBSTRING(license_no,6,4)) as yearid " & _
                 " FROM license ) as dt WHERE yearid like '%" & Now.Year & "%'"
        Dim license_no As String = ""
        Dim no As Integer
        Dim check As String
        check = DBconnect.executeScalar(sqlstr)
        If check = "" Then
            check = 0
        End If
        no = check
        no = no + 1
        Dim length As Integer
        length = no.ToString.Length

        If length = 1 Then
            license_no = "000" & no & "/" & Now.Year
        ElseIf length = 2 Then
            license_no = "00" & no & "/" & Now.Year
        ElseIf length = 3 Then
            license_no = "0" & no & "/" & Now.Year
        ElseIf length = 4 Then
            license_no = "" & no & "/" & Now.Year
        End If

        Return license_no.ToString

    End Function

    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSch.Click
        loadData()
    End Sub

    'จัดการตาราง
    Protected Sub gvMain_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.DataBound
        '//--- For Paging ---------
        Dim row As GridViewRow = gvMain.BottomPagerRow
        If row Is Nothing Then
            Return
        End If

        Dim DDLPage As DropDownList = DirectCast(row.Cells(0).FindControl("DDLPage"), DropDownList)



        If Not DDLPage Is Nothing Then
            For i As Integer = 0 To gvMain.PageCount - 1
                Dim pageNumber As Integer = i + 1
                Dim item As New ListItem(pageNumber.ToString())
                If i = gvMain.PageIndex Then
                    item.Selected = True
                End If
                DDLPage.Items.Add(item)
            Next
        End If

        '//-- For First and Previous ImageButton
        If gvMain.PageIndex = 0 Then
            Dim btnFirst As LinkButton = DirectCast(row.Cells(0).FindControl("btnFirst"), LinkButton)
            Dim btnPrev As LinkButton = DirectCast(row.Cells(0).FindControl("btnPrev"), LinkButton)
            btnFirst.Visible = False
            btnPrev.Visible = False
        End If


        '//-- For Last and Next ImageButton
        If gvMain.PageIndex + 1 = gvMain.PageCount Then
            Dim btnLast As LinkButton = DirectCast(row.Cells(0).FindControl("btnLast"), LinkButton)
            Dim btnNext As LinkButton = DirectCast(row.Cells(0).FindControl("btnNext"), LinkButton)
            btnLast.Visible = False
            btnNext.Visible = False
        End If
    End Sub
    Private Sub gvMain_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles gvMain.PageIndexChanging
   
        gvMain.PageIndex = e.NewPageIndex
        loadData()


    End Sub

    Protected Sub DDLPage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow = gvMain.BottomPagerRow
        Dim DDLPage As DropDownList = DirectCast(row.Cells(0).FindControl("DDLPage"), DropDownList)
        gvMain.PageIndex = DDLPage.SelectedIndex
        gvMain.DataBind()
        loadData()
    End Sub

    Protected Sub ddl_PageSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_PageSize.SelectedIndexChanged
        If ddl_PageSize.SelectedValue <> "--" Then
            gvMain.PageSize = Convert.ToInt32(ddl_PageSize.SelectedValue)
            gvMain.DataBind()
            loadData()
        End If
    End Sub


    Protected Sub lnkAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAdd.Click

        If Session("typeuser_id") = 1 Then
            Response.Redirect("MgtEdit.aspx?group=1")
        Else
            Response.Redirect("MgtEdit.aspx")
        End If
    End Sub

    Protected Sub lnkAdd2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddgroup2.Click

        Response.Redirect("MgtEdit.aspx?group=2")

    End Sub
End Class
