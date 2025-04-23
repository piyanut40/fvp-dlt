Imports System.Data
Imports Npgsql
Partial Class Travel_index
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected text As String
    Protected name As String
    Protected qrCode As String = "https://api.qrserver.com/v1/create-qr-code/?size=300x300&data="
    Protected url As String = HttpContext.Current.Request.Url.Host & "/BorderTransport/Report/QRCode.aspx?token="
    Protected Css As String = " w3-padding-top w3-right-align "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Try
                If Session("user_id") = Nothing Or Session("user_type") = 1 Then
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


                    genDDLStatus(ddlstatus, True)

                    Populate.genDDLBudyearEN(ddlYear, 0, "All Year")

                    loadData()

                End If
            Catch ex As Exception
                Response.Redirect("../Login.aspx")
            End Try
        End If

    End Sub


    Public Sub genDDLStatus(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try

            Dim strselect As String = " select distinct status_id as value , case  status_id = 4 when true then 'Permit Revoked' else status_en  end  as text from  status WHERE status_id not in (5 , 3 , 1 , 6) "
            Dt = db.getDataTable(strselect & " Order By status_id ", "Data")
        Catch ex As Exception

        End Try

        ddl.Items.Clear()
        If IsSelectAll Then
            ddl.Items.Insert(0, "All status")
            ddl.Items(0).Value = -1
        End If

        ddl.Items.Insert(1, "Draft")
        ddl.Items(1).Value = "null"
        ddl.DataSource = Dt
        ddl.DataTextField = "text"
        ddl.DataValueField = "value"
        ddl.DataBind()
        ddl.SelectedIndex = 0
        'ddl.Attributes.Add("data-inline", "true")
    End Sub

    Private Sub loadData()
        Dim dbConnect As New DBConnect
        'Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dt As DataTable
        Dim strsql As String = ""
        Try
            Dim strType As String = "replace(type_name,'(','<br/>(')" '"type_name"
            strsql = " SELECT Row_number() over (order by number1 ) as number , dt.* FROM ( SELECT Row_number() over (order by case license.status_id when 2 then -1 else license.status_id  end asc nulls first , regis_date desc nulls last) as number1 , license.license_id , token , CAST(prename || ' ' || name || ' ' || surname as varchar) as name " & _
                " , " & strType & " as typecar_en, brands, model as models, plate , group_name , status_en  || '<br/>(' || status_th || ')' as status_en, status.status_id ,  CAST('LicenseDtl.aspx?rt=2&token=' || token as varchar ) as urlDoc, CAST('MgtEdit.aspx?token=' || token as varchar ) as urlEdit " & _
                " , CAST('..\RptApplication.aspx?token=' || token as varchar ) as urlPDF , car_no , " & _
                " to_char(license.regis_date , 'DD/MM/YYYY') as regis_date , license.regis_date as regis_date1 , " & _
                " to_char(travel_group.start_date , 'DD/MM/YYYY') as start_date , " & _
                " to_char(travel_group.exp_date , 'DD/MM/YYYY') as exp_date ," & _
                " (select STRING_AGG(CAST(case when guide.prename = 'Other' then '' else guide.prename end || ' ' || guide.guide_name || ' ' || guide.guide_surname as varchar),' , ')  from guide " & _
                " LEFT JOIN travel_group_guide on travel_group_guide.guide_id = guide.guide_id " & _
                " WHERE travel_group_guide.group_id = travel_group_car.group_id ) as guide " & _
                " FROM license " & _
                " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                " LEFT JOIN car on car.car_id = license.car_id " & _
                " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
                " LEFT JOIN status on license.status_id = status.status_id " & _
                " LEFT JOIN travel_group_car on travel_group_car.license_id = license.license_id " & _
                " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id " & _
                " WHERE typeuser_id = 2 and travel_id = " & Session("user_id")

            strsql = strsql & " and (license.status_id not in (5 , 3 , 1) or (license.status_id is null )) ) as dt WHERE 1=1 "

            If ddlYear.SelectedIndex > 0 Then
                strsql = strsql & " and  EXTRACT(year FROM regis_date1) = " & ddlYear.SelectedValue
            End If
            If txtName.Text <> "" Then
                strsql = strsql & "and lower(name) like '%" & txtName.Text.ToLower & "%' "
            End If
            If txtGroup.Text <> "" Then
                strsql = strsql & "and lower(group_name) like  '%" & txtGroup.Text.ToLower & "%' "
            End If

            If txtGuide.Text <> "" Then
                strsql = strsql & " and lower(guide) like lower('%" & txtGuide.Text & "%')"
            End If

            If txtstartdate.Text <> "" Then
                strsql = strsql & " and start_date = '" & txtstartdate.Text & "'"
            End If

            If txtexpdate.Text <> "" Then
                strsql = strsql & " and exp_date = '" & txtexpdate.Text & "'"
            End If

         
            If ddlstatus.SelectedIndex > 0 Then
                If ddlstatus.SelectedValue = "null" Then
                    strsql = strsql & "and status_id is null "
                Else
                    strsql = strsql & "and status_id = " & ddlstatus.SelectedValue
                End If
            End If

            dt = dbConnect.getDataTable(strsql & " order by number  ", "local")

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
            Dim HyperEdit As HyperLink = e.Row.Cells(0).FindControl("HyperEdit")

        
            Dim lnkDel As HyperLink = e.Row.Cells(13).FindControl("HyperLinkDel")
            lnkDel.Attributes.Add("onclick", "javascript:DelData(" & lblLicense.Text & ");")

            Dim lnkEdit As HyperLink = e.Row.Cells(12).FindControl("HyperEdit")

            Dim lnkDoc As HyperLink = e.Row.Cells(9).FindControl("HyperPDF")
          
            If e.Row.Cells(11).Text = "&nbsp;" Then
                lnkDoc.Visible = False
                e.Row.Cells(11).Text = "Draft<br/>(แบบร่าง)"
            ElseIf e.Row.Cells(11).Text.Contains("Incomplete") Then
                lnkDoc.Visible = False
                e.Row.Cells(11).Text = "Incomplete<br/>(เอกสารไม่สมบูรณ์รอการแก้ไข)"
                HyperEdit.NavigateUrl = HyperEdit.NavigateUrl & "&Page=1"

              
                lnkEdit.Visible = False
                lnkDel.Visible = False
            ElseIf e.Row.Cells(11).Text.Contains("Expired") Or e.Row.Cells(11).Text.Contains("Canceled") Or e.Row.Cells(11).Text.Contains("Failed") Then
              
                e.Row.Cells(11).Text = e.Row.Cells(11).Text.ToString.Replace("ไม่สำเร็จ (", "").ToString.Replace("))", ")")
                lnkEdit.Visible = False
                lnkDel.Visible = False
            ElseIf e.Row.Cells(11).Text.Contains("Cancel") Then
                e.Row.Cells(11).Text = "Rejected<br/>(ยกเลิกใบอนุญาต)"
                lnkEdit.Visible = False
                lnkDel.Visible = False
            ElseIf e.Row.Cells(11).Text.Contains("Permit Revoked") Then
                e.Row.Cells(11).Text = "Permit Revoked<br/>(เจ้าหน้าที่ยกเลิกใบอนุญาต)"
                lnkEdit.Visible = False
                lnkDel.Visible = False
            ElseIf e.Row.Cells(11).Text.Contains("Completed") Then

                lnkEdit.Visible = False
                lnkDel.Visible = False
            Else
                e.Row.Cells(11).Text = "Pending<br/>(กำลังดำเนินการ)"
                lnkEdit.Visible = False
                lnkDel.Visible = False
            End If





        ElseIf e.Row.RowType = DataControlRowType.Header Then
           
            e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(9).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(10).Attributes.Add("data-breakpoints", "xs")
            'e.Row.Cells(11).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(12).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(14).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(17).Attributes.Add("data-breakpoints", "xs")

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
    Protected Sub ddlstatus_SelectIndexChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlstatus.SelectedIndexChanged
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

        Response.Redirect("MgtEdit.aspx")

    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
        loadData()
    End Sub
End Class
