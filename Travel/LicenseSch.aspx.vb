Imports System.Data

Partial Class Travel_LicenseSch
    Inherits System.Web.UI.Page
    Private Populate As New PopulateDropDown
    Private PopulateS As New PopulateScript
    Private group_id, is_renew As String
    Protected Css As String = " w3-padding-top w3-right-align "
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
        Else
            group_id = Nothing
        End If

        If Not Request.QueryString("is_renew") Is Nothing Then
            is_renew = Request.QueryString("is_renew")
        End If

        If Page.IsPostBack = False Then
            If PopulateS.IsMobile Then
                Css = ""
            End If
            Populate.genPageSize(ddl_PageSize)
            ddl_PageSize.SelectedValue = 10


            genDDLLicense()
        End If
    End Sub

    Public Sub genDDLStatus(ByVal ddl As DropDownList, ByVal IsSelectAll As Boolean)
        Dim db As New DBConnect
        Dim Dt As New DataTable
        Try

            Dim strselect As String = " select distinct status_id as value , case  status_id = 4 when true then 'Rejected' else status_en  end  as text from  status WHERE status_id not in (5 , 3 , 1 , 6) "
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

    End Sub

    Private enCul As New System.Globalization.CultureInfo("en-US")
    Private Sub genDDLLicense()
        Try
            Dim db As New DBConnect
            Dim Dt As New DataTable
            Try
                Dim strselect As String
                Dim old_group_id As Integer = 0
                'Dim startDate As New DateTime
                'Dim endDate As New DateTime
                Try
                    'old_group_id = db.executeScalar("select old_group_id from travel_group where group_id = " & group_id)
                    Dim dtGroups As DataTable = db.getDataTable("select old_group_id , start_date , exp_date from travel_group where group_id = " & group_id, "group")
                    Dim drG As DataRow = dtGroups.Rows(0)
                    If Not drG("old_group_id") Is DBNull.Value Then
                        old_group_id = drG("old_group_id")
                    End If
                    If CheckInsurance.Checked Then
                        If old_group_id > 0 Then
                            Dim dtGroupsOld As DataTable = db.getDataTable("select  start_date , exp_date from travel_group where group_id = " & old_group_id, "group")
                            Dim drGOld As DataRow = dtGroupsOld.Rows(0)
                            If Not drGOld("start_date") Is DBNull.Value Then
                                'startDate = drG("start_date")
                                txtStart.Text = Format(Day(drGOld("start_date")), "00") & "/" & Format(Month(drGOld("start_date")), "00") & "/" & CDate(drGOld("start_date")).ToString("yyyy", enCul)
                            End If
                            If Not drGOld("exp_date") Is DBNull.Value Then
                                'endDate = drG("exp_date")
                                txtExpire.Text = Format(Day(drGOld("exp_date")), "00") & "/" & Format(Month(drGOld("exp_date")), "00") & "/" & CDate(drGOld("exp_date")).ToString("yyyy", enCul)
                            End If
                        Else
                            If Not drG("start_date") Is DBNull.Value Then
                                'startDate = drG("start_date")
                                txtStart.Text = Format(Day(drG("start_date")), "00") & "/" & Format(Month(drG("start_date")), "00") & "/" & CDate(drG("start_date")).ToString("yyyy", enCul)
                            End If
                            If Not drG("exp_date") Is DBNull.Value Then
                                'endDate = drG("exp_date")
                                txtExpire.Text = Format(Day(drG("exp_date")), "00") & "/" & Format(Month(drG("exp_date")), "00") & "/" & CDate(drG("exp_date")).ToString("yyyy", enCul)
                            End If
                        End If
                    End If

                Catch ex As Exception

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
                " where license.status_id in (1,2,5) and  EXTRACT(year FROM regis_date) = " & Now.Year & " ) dt group by car_no "


                Dim dtAct As String = " select act_start, act_ends , license_id  from act LEFT JOIN license on license.act_id = act.act_id  " & _
                " union all select act_start2 as act_start , act_ends2 as act_ends , license_id  from act LEFT JOIN license on license.act_id = act.act_id "

                Dim SdayFilter As String = startDate.Year & "-" & Format(CDbl(startDate.Month), "00") & "-" & Format(CDbl(startDate.Day), "00") '2019-11-29
                Dim EdayFilter As String = startDate.Year & "-" & Format(CDbl(startDate.Month), "00") & "-" & Format(CDbl(startDate.Day), "00") '2019-11-29
                Dim strWhereAct As String = " and license_id in (select license_id from (" & dtAct & ") dt where license_id > 0 " & _
                " and '" & SdayFilter & "' >= act_start and '" & EdayFilter & "' <= act_ends ) "


                Dim strType As String = "replace(type_name,'(','<br/>(')" '"type_name"
                strselect = "select distinct car.plate || ' ' || country_car as text  ,  max(license_id) as value " & _
                        " , car.car_no , plate , country_car  , sumday , to_char(act_start, 'DD/MM/YYYY') act_start , to_char(act_ends, 'DD/MM/YYYY') act_ends , to_char(act_start2, 'DD/MM/YYYY') act_start2, to_char(act_ends2, 'DD/MM/YYYY') act_ends2 " & _
                        " , " & strType & " type_name , CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name "
             
                strselect = strselect & " from license LEFT JOIN car on license.car_id = car.car_id " & _
                        " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                        " LEFT JOIN act on license.act_id = act.act_id " & _
                        " LEFT JOIN status on license.status_id = status.status_id " & _
                        " left join type_car on type_car.type_id = car.typecar_id " & _
                        " LEFT JOIN ( " & str60 & ") dt60 on car.car_no = dt60.car_no "
                If old_group_id > 0 Then

                    strselect = strselect & " where license_id not in (select license_id from travel_group_car where group_id = " & group_id & ") " & _
                        " and license_id in  (select license_id from travel_group_car where group_id = " & old_group_id & ") " '& strWhereAct
                 
                Else

                    strselect = strselect & " where travel_id = " & Session("user_id")
                    strselect = strselect & " and ( license.status_id is null or license.status_id = 2 "

                    strselect = strselect & " or license.status_id in (4,7,8,9) "

                    Dim dayFilter As String = startDate.Year & "-" & Format(CDbl(startDate.Month), "00") & "-" & Format(CDbl(startDate.Day), "00") '2019-11-29

                    strselect = strselect & " or license_id in ( select max(license.license_id) " & _
                    " from travel_group_car LEFT JOIN license ON license.license_id = travel_group_car.license_id  LEFT JOIN car on license.car_id = car.car_id " & _
                    " LEFT JOIN travel_group on travel_group_car.group_id = travel_group.group_id where user_id = " & Session("user_id") & " and license.status_id = 5 and travel_group.exp_date < '" & dayFilter & "' " & _
                    " group by car.plate || ' ' || country_car ) "
                    strselect = strselect & " ) " '& strWhereAct
                    strselect = strselect & " and license_id not in ( select license_id from travel_group_car where group_id = " & group_id & ") "
                    strselect = strselect & " and license_id not in ( select copy_license_id from  license where copy_license_id > 0 and (license.status_id is null or license.status_id = 2 ) ) "

                
                End If

                If txtPlate.Text <> "" Then
                    strselect = strselect & " and lower(car.plate) like '%" & txtPlate.Text.Trim.ToLower & "%'"
                End If

                If txtCountry.Text <> "" Then
                    strselect = strselect & " and lower(country_car) like '%" & txtCountry.Text.Trim.ToLower & "%'"
                End If

                If Check60.Checked Then

                    strselect = strselect & " and (sumday is null or sumday < 60) "
                End If

                If CheckInsurance.Checked Then

                    strselect = strselect & strWhereAct
                End If

                strselect = strselect & " group by  car.plate || ' ' || country_car " & _
                                        " , car.car_no , plate , country_car , act_start, act_ends , act_start2 , act_ends2 , sumday " & _
                                        " , type_name , CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) "
             
                strselect = strselect & " order by  car.plate || ' ' || country_car "
                Dt = db.getDataTable(strselect, "Data")
            Catch ex As Exception

            End Try


            'If Dt.Rows.Count > 0 Then
            PopulateS.SetGrid_Footable(gvMain, Dt)
            UpdGrid.Update()
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DDLPage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow = gvMain.BottomPagerRow
        Dim DDLPage As DropDownList = DirectCast(row.Cells(0).FindControl("DDLPage"), DropDownList)
        gvMain.PageIndex = DDLPage.SelectedIndex
        gvMain.DataBind()
        genDDLLicense()
    End Sub

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

     
    Protected Sub gvMain_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvMain.PageIndexChanging
       
        gvMain.PageIndex = e.NewPageIndex
        genDDLLicense()
    End Sub

    Protected Sub lnkSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSearch.Click
        genDDLLicense()
    End Sub

    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblLicense As Label = e.Row.Cells(0).FindControl("lblLicense")
            Dim lnkAdds As HyperLink = e.Row.Cells(0).FindControl("HyperLinkAdds")
            lnkAdds.Attributes.Add("onclick", "javascript:AddLicense(" & lblLicense.Text & ");")
        End If
    End Sub
End Class
