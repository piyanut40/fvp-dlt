Imports System.Data

Partial Class Admin_MapLocationHis
    Inherits System.Web.UI.Page
    Private Populate As New PopulateDropDown
    Private PopulateS As New PopulateScript
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If PopulateS.IsMobile Then
                Css = ""
            End If
            Populate.genPageSize(ddl_PageSize)
            ddl_PageSize.SelectedValue = 10
            loadData()
        End If
    End Sub

    'Private enCul As New System.Globalization.CultureInfo("en-US")
    Private Sub loadData()
        Dim dbConnect As New DBConnect
        Dim dt As DataTable
        Try
            Dim strsql As String = " SELECT ROW_NUMBER() OVER (order by name_company asc) as num , name_company , token  , group_name , license_group " & _
            " , to_char(start_date , 'MM/DD/YYYY') as start_date , to_char(exp_date , 'MM/DD/YYYY') as exp_date " '& _
            '" , to_char(start_date_drive , 'MM/DD/YYYY') as start_date_drive , to_char(exp_date_drive , 'MM/DD/YYYY') as exp_date_drive " & _
            strsql = strsql & " , _name  as guide , count(id_location) as cntAll , count(case when wrong_way = 1 then 1 else null end) as cntWrong " & _
            " , to_char( max(date_time) , 'MM/DD/YYYY HH24:MI:SS')  as max_date_time " & _
            " , 'MapLocationHisData.aspx' as urlMap "
            strsql = strsql & " from vmaplocation where 1=1 "
            If Request.QueryString("is_guide") = "1" Then
                strsql = strsql & " and is_guide = 1 "

                lblHead.Text = "ผู้นำเที่ยว"
            ElseIf Request.QueryString("is_guide") = "0" Then
                strsql = strsql & " and is_guide = 0 "
            End If
            Dim arr_s As Array
            Dim arr_e As Array
            If Page.IsPostBack = False Then
                Dim beginDate As Date = Now.AddDays(-60)
                arr_s = {Format(CInt(beginDate.Day), "00"), Format(CInt(beginDate.Month), "00"), Format(CInt(beginDate.Year), "0000")}
                arr_e = {Format(CInt(Now.Day), "00"), Format(CInt(Now.Month), "00"), Format(CInt(Now.Year), "0000")}
                strsql = strsql & " and ( start_date >= '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "'"
                strsql = strsql & " or  exp_date <= '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "' )"

                txtstartdate.Text = Format(arr_s(1) & "/" & arr_s(0) & "/" & arr_s(2))
                txtexpdate.Text = Format(arr_e(1) & "/" & arr_e(0) & "/" & arr_e(2))
            Else
                Dim beginDate As Date = txtstartdate.Text
                Dim endDate As Date = txtexpdate.Text
                arr_s = {Format(CInt(beginDate.Day), "00"), Format(CInt(beginDate.Month), "00"), Format(CInt(beginDate.Year), "0000")}
                arr_e = {Format(CInt(endDate.Day), "00"), Format(CInt(endDate.Month), "00"), Format(CInt(endDate.Year), "0000")}
                If txtstartdate.Text <> "" And txtexpdate.Text <> "" Then
                    strsql = strsql & " and ( start_date >= '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "'"
                    strsql = strsql & " or  exp_date <= '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "' )"
                ElseIf txtstartdate.Text <> "" Then
                    strsql = strsql & " and start_date >= '" & arr_s(2) & "-" & arr_s(1) & "-" & arr_s(0) & "' "
                ElseIf txtexpdate.Text <> "" Then
                    strsql = strsql & " and exp_date <= '" & arr_e(2) & "-" & arr_e(1) & "-" & arr_e(0) & "' "
                End If
            End If
            If txtTour.Text <> "" Then
                strsql = strsql & " and lower(name_company) like '%" & txtTour.Text.ToString.ToLower & "%' "
            End If
            strsql = strsql & " group by name_company , token  , group_name , license_group , to_char(start_date , 'MM/DD/YYYY') , to_char(exp_date , 'MM/DD/YYYY') , _name " ', to_char(start_date_drive , 'MM/DD/YYYY') , to_char(exp_date_drive , 'MM/DD/YYYY') "
            strsql = strsql & " order by name_company , group_name ,  _name "


            '---------------- ออกนอกเส้นทาง ------------------
            strsql = "select * from (" & strsql & ") dt where 1=1 "
            If ChkIsWrong.Checked Then
                strsql = strsql & " and cntWrong > 0 "
            End If
            dt = dbConnect.getDataTable(strsql, "maplocal")
            gvMain.DataSource = dt
            gvMain.DataBind()
            UpdGrid.Update()
        Catch ex As Exception

        Finally
            dbConnect = Nothing
        End Try
    End Sub

    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSch.Click
        loadData()
    End Sub

    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
            e.Row.Cells(1).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(2).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
            'e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(10).Attributes.Add("data-breakpoints", "xs")
            If Request.QueryString("is_guide") = "0" Then
                e.Row.Cells(7).Text = "คนขับรถ"
            End If
        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbltoken As Label = e.Row.Cells(0).FindControl("lbltoken")
            Dim HyperMap As HyperLink = e.Row.Cells(0).FindControl("HyperMap")
            Dim strPopup = "javascript:w=window.open(" & _
                         """" & ResolveClientUrl("../Map/MapLocationHis.aspx?token=" & lbltoken.Text) & """," & _
                         """PunishResignWindow""," & _
                         """" & "location=0,status=0,scrollbars=yes,resizable=no," & _
                         "width=920,height=900""" & _
                         ");w.focus();"
            HyperMap.NavigateUrl = "javascript://"
            HyperMap.Attributes.Add("OnClick", strPopup)
        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        End If
    End Sub

#Region "จัดการตาราง"
    Private RowIndex As Integer = 1
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

            If DDLPage.SelectedValue > 1 Then
                RowIndex = ((DDLPage.SelectedValue - 1) * ddl_PageSize.SelectedValue) + 1
            End If

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
#End Region
End Class
