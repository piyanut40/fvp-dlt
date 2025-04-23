Imports System.Data
Imports Npgsql

Partial Class Travel_Group
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected text As String
    Protected name As String
    Protected qrCode As String = "https://api.qrserver.com/v1/create-qr-code/?size=300x300&data="
    Protected url As String = HttpContext.Current.Request.Url.Host & "/BorderTransport/Report/QRCode.aspx?token="
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "


    Private user_id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_id") = Nothing Or Session("user_type") = 1 Then

        Else
            user_id = Session("user_id")

            If Not Request.QueryString("fixID") Is Nothing Then

                user_id = Request.QueryString("fixID")
            End If
        End If

        If IsPostBack = False Then
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

                Populate.genDDLBudyearEN(ddlYear, 0, "All Year")

                loadData()

            End If

        End If

    End Sub

    Private Sub loadData()
        Dim dbConnect As New DBConnect
        Dim dt As DataTable
        Dim strsql As String = ""
        Try

            Dim urlData1 As String = " CAST('GroupDtl.aspx?token='|| crypt(travel_group.group_id :: text, 'groupid2562')  as varchar) "
            Dim urlEdit2 As String = " CAST('GroupEdit.aspx?token=' || crypt(travel_group.group_id :: text, 'groupid2562') as varchar) || CASE when is_renew > 0 THEN '&is_renew=' || is_renew || ',1'  else '&is_renew='  end "
            Dim urlAdds1 As String = " CASE when travel_group.group_id in (select old_group_id from travel_group WHERE old_group_id <> 0) THEN ' '  ELSE CAST('GroupAdd.aspx?is_renew=' || is_renew|| ',0' || '&token=' || crypt(travel_group.group_id :: text, 'groupid2562') as varchar ) END "


            Dim urlData As String = " CAST('GroupDtl.aspx?id=' || travel_group.group_id as varchar ) "
            Dim urlEdit As String = " CAST('GroupAdd.aspx?id=' || travel_group.group_id || CASE when is_renew > 0 THEN '&is_renew=' || is_renew || ',1'  else '&is_renew='  end as varchar) "
            Dim urlAdds As String = " CASE when travel_group.group_id in (select old_group_id from travel_group WHERE old_group_id <> 0) THEN ' '  ELSE CAST('GroupAdd.aspx?is_renew=' || is_renew|| ',0' || '&id=' || travel_group.group_id as varchar ) END "

            Dim stractive As String = "case (license_group is null and active > 0) when true then '9999' else license_group end "
            Dim stractiveno As String = "case (activeno > 0) when true then 'T9999' || coalesce(license_group,'') else " & stractive & "  end  "
            Dim stractiveedit As String = "case (license_group is null and activeedit > 0) when true then '0000' else " & stractiveno & " end "
            Dim strOrderBy As String = "case license_group is null  when true then " & stractiveedit & " else " & stractiveno & " end nulls first, start_date1 desc nulls last "

            strsql = " SELECT Row_number() over (order by " & strOrderBy & " ) as number , dt.* FROM ( " & _
                " SELECT Row_number() over (order by start_date desc nulls last) as number1 , old_group_id , license_group, travel_group.group_id , group_name " & _
                " , to_char(start_date , 'DD/MM/YYYY') as start_date , start_date as start_date1 , to_char(exp_date , 'DD/MM/YYYY') as exp_date , exp_date as exp_date1 " & _
                " , coalesce(dtCar.cntCar,0) as cntpeople , coalesce(dtGuide.cntguide,0) cntguide " & _
                " , " & urlEdit2 & " as urlEdit  , " & urlData1 & "  as urlData  , " & urlAdds1 & " as urlAdds , is_renew " '& _

            strsql = strsql & " , border_check.border_nameen  , border_check2.border_nameen as border_nameen2 "
            strsql = strsql & " , (select STRING_AGG(CAST(case when guide.prename = 'Other' then '' else guide.prename end || ' ' || guide.guide_name || ' ' || guide.guide_surname as varchar),' , ') " & _
             " from guide   " & _
             " LEFT JOIN travel_group_guide on travel_group_guide.guide_id = guide.guide_id  " & _
             " WHERE travel_group.group_id = travel_group_guide.group_id) as guide "


            strsql = strsql & " ,  (select count(status_id) from license LEFT JOIN travel_group_car on license.license_id = travel_group_car.license_id  " & _
                " WHERE travel_group_car.group_id = travel_group.group_id and (status_id = 1 or status_id = 0 or status_id = 5))  as active  " & _
                " ,  (select count(status_id) from license LEFT JOIN travel_group_car on license.license_id = travel_group_car.license_id  " & _
                " WHERE travel_group_car.group_id = travel_group.group_id and (status_id = 4 or status_id = 7 or status_id = 8 or status_id = 9)) as activeno " & _
                " ,  (select count(status_id) from license LEFT JOIN travel_group_car on license.license_id = travel_group_car.license_id  " & _
                " WHERE travel_group_car.group_id = travel_group.group_id and (status_id = 2)) as activeedit "

            strsql = strsql & " FROM travel_group " & _
              " LEFT JOIN border_check on border_check.border_id = travel_group.checkin_id " & _
              " LEFT JOIN border_check border_check2 on border_check2.border_id = travel_group.checkout_id " '& _
            strsql = strsql & " LEFT JOIN (SELECT count(gid) cntguide , group_id   FROM travel_group_guide group by group_id) dtGuide on dtGuide.group_id = travel_group.group_id " & _
                " LEFT JOIN (SELECT  count(gid) cntCar , group_id  FROM travel_group_car group by group_id) dtCar on dtCar.group_id = travel_group.group_id "
            strsql = strsql & " where user_id = " & user_id & _
              " ) as dt where 1=1 "
            If ddlYear.SelectedIndex > 0 Then
                Dim sday As String = ddlYear.SelectedValue & "-01-01"
                Dim eday As String = ddlYear.SelectedValue & "-12-31"
                strsql = strsql & " and start_date1 >= '" & sday & "'  and exp_date1 <= '" & eday & "' "
            End If
            If txtName.Text <> "" Then
                strsql = strsql & " and lower(group_name) like '%" & txtName.Text.ToLower & "%' "
            End If

            If txtGuide.Text <> "" Then
                strsql = strsql & " and lower(guide) like '%" & txtGuide.Text.ToLower & "%' "
            End If

            If txtstartdate.Text <> "" Then
                strsql = strsql & " and start_date = '" & txtstartdate.Text & "' "
            End If

            If txtexpdate.Text <> "" Then
                strsql = strsql & " and exp_date = '" & txtexpdate.Text & "' "
            End If


            If Not Request.QueryString("status") Is Nothing Then
                If Request.QueryString("status") = "1" Then
                    strsql = strsql & " and  group_id in ( select distinct travel_group_car.group_id  from license  inner JOIN travel_group_car on license.license_id = travel_group_car.license_id  " & _
                    " WHERE (status_id = 1 or status_id = 0)) "
                    lblStatusHead.Text = "Pendings"
                ElseIf Request.QueryString("status") = "2" Then
                    strsql = strsql & " and  group_id in ( select distinct travel_group_car.group_id  from license  inner JOIN travel_group_car on license.license_id = travel_group_car.license_id  " & _
                    " WHERE (status_id = 2)) "
                    lblStatusHead.Text = "Incomplete"
                ElseIf Request.QueryString("status") = "5" Then
                    strsql = strsql & " and  group_id  in ( select distinct travel_group_car.group_id  from license  inner JOIN travel_group_car on license.license_id = travel_group_car.license_id  " & _
                    " WHERE (status_id = 5)) "
                    strsql = strsql & " and  group_id  not in ( select distinct travel_group_car.group_id  from license  inner JOIN travel_group_car on license.license_id = travel_group_car.license_id  " & _
                    " WHERE (status_id in (4,7,8,9) )) "
                    lblStatusHead.Text = "Success"
                End If
            End If
            dt = dbConnect.getDataTable(strsql & " order by number ", "local")

            PopulateS.SetGrid_Footable(gvMain, dt)
            UpdGrid.Update()

        Catch ex As Exception

        Finally
            dbConnect = Nothing
        End Try
    End Sub

    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblgroup_id As Label = e.Row.Cells(0).FindControl("lblgroup_id")
            Dim oldgroup As Label = e.Row.Cells(0).FindControl("lblold_group_id")
            Dim lblurladd As Label = e.Row.Cells(0).FindControl("lblurlAdds")
            Dim lnkDel As HyperLink = e.Row.Cells(0).FindControl("HyperLinkDel")
            Dim UrlEdit As HyperLink = e.Row.Cells(0).FindControl("HyperEdit")


            Dim active As Label = e.Row.Cells(0).FindControl("lblActive")

            lnkDel.Attributes.Add("onclick", "javascript:DelData(" & lblgroup_id.Text & ");")



            Dim HyperLinkAdds As HyperLink = e.Row.Cells(0).FindControl("HyperLinkAdds")
            Dim lblActiveno As Label = e.Row.Cells(0).FindControl("lblActiveno")
            Dim lblActiveedit As Label = e.Row.Cells(0).FindControl("lblActiveedit")
            If lblActiveedit.Text = 0 Then
                If active.Text > 0 And e.Row.Cells(2).Text = "&nbsp;" Then
                    e.Row.Cells(12).Text = "Pendings"
                    e.Row.Cells(14).Text = ""
                    HyperLinkAdds.Visible = False
                ElseIf active.Text > 0 And lblActiveno.Text = 0 Then
                    e.Row.Cells(12).Text = "Success"
                    e.Row.Cells(14).Text = ""
                Else
                    If lblActiveno.Text > 0 Then
                        e.Row.Cells(12).Text = "Not Success"
                        e.Row.Cells(14).Text = ""
                        HyperLinkAdds.Visible = False
                    Else
                        HyperLinkAdds.Visible = False
                    End If
                End If
            Else
                HyperLinkAdds.Visible = False
            End If





            If lblurladd.Text = " " Then
                HyperLinkAdds.Visible = False
            Else
              
                Dim nowDate As New DateTime(Now.Year, Now.Month, Now.Day)

                Dim lblexp_date2 As Label = e.Row.Cells(0).FindControl("lblexp_date2")
                Dim ar_expDate As String() = lblexp_date2.Text.ToString.Split("/")
                Dim expDate As New DateTime(ar_expDate(2), ar_expDate(1), ar_expDate(0))
               
                If expDate < nowDate Then
                    HyperLinkAdds.Visible = False
                End If
            End If


            Dim lblis_renew As Label = e.Row.Cells(0).FindControl("lblis_renew")
            If lblis_renew.Text <> "0" Then
                lblis_renew.Text = ChkOrdinalNumbers(lblis_renew.Text)   '"ครั้งที่ " & lblis_renew.Text
            Else
                lblis_renew.Text = ""
            End If


        ElseIf e.Row.RowType = DataControlRowType.Header Then
            'e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(9).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(10).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(11).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(13).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(14).Attributes.Add("data-breakpoints", "xs")
        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        End If
    End Sub
    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim transaction As NpgsqlTransaction
        Dim tablecommand As DataTable = dbConnect.TableCommand
        Try
            con.Open()
            transaction = con.BeginTransaction()
            cmd.Connection = con

            cmd.Parameters.Clear()
            cmd.CommandText = " delete from travel_group where group_id = " & HidDel_ID.Value
            cmd.ExecuteNonQuery()

            cmd.Parameters.Clear()
            cmd.CommandText = " delete from user_travel_group where group_id = " & HidDel_ID.Value
            cmd.ExecuteNonQuery()

            cmd.Parameters.Clear()
            cmd.CommandText = " delete from travel_group_car where group_id = " & HidDel_ID.Value
            cmd.ExecuteNonQuery()

            cmd.Parameters.Clear()
            cmd.CommandText = " delete from travel_group_guide where group_id = " & HidDel_ID.Value
            cmd.ExecuteNonQuery()

            Dim datatableGroup = dbConnect.getDataTable("select license_id from travel_group_car WHERE group_id = " & HidDel_ID.Value, "license_group")

            For Each i In datatableGroup.Rows
                tablecommand.Clear()
                tablecommand.Rows.Add("status_id", NpgsqlTypes.NpgsqlDbType.Integer, "")
                Dim tableUpdate = dbConnect.UpdateDataTable(tablecommand, "license", "WHERE license_id = " & i("license_id").ToString())
            Next



            transaction.Commit()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            'dbConnect = Nothing
        End Try
        loadData()
    End Sub

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

        Response.Redirect("GroupAdd.aspx?is_renew=")

    End Sub

    Private Function ChkOrdinalNumbers(ByVal pNum As Integer) As String
        Dim result As String = ""

        Select Case pNum
            Case 11, 12, 13
                result = pNum & "th"
            Case Else
                If pNum Mod 10 = 1 Then
                    result = pNum & "st"
                ElseIf pNum Mod 10 = 2 Then
                    result = pNum & "nd"
                ElseIf pNum Mod 10 = 3 Then
                    result = pNum & "rd"
                Else
                    result = pNum & "th"
                End If

        End Select

        Return result
    End Function

    Protected Sub ddlYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
        loadData()
    End Sub
End Class
