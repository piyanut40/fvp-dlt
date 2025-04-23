Imports System.Data
Imports Npgsql
Partial Class OtherCovntries
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align w3-padding-bottom"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Populate.genDDLProvince(ddlprovince, False)
            Populate.genPageSize(ddl_PageSize)
            ddl_PageSize.SelectedValue = 10
            loaddata()
        End If
    End Sub

    Private Sub loaddata()
        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dt As DataTable
        Dim strsql As String = ""
        Try
            strsql = " SELECT ROW_NUMBER() OVER (order by name_company ) as num ,* from (select distinct  name_company , tumbol.p_name_e , email , telephone , facebook  FROM user_travel  left join tumbol on tumbol.t_id = user_travel.tumbol " & _
                     "  WHERE is_active = 1 and user_id not in ( 29, 39 ) and user_name is not null) dt  " 'fix ซ่อนuser test คุณเพชร
            If txtName.Text <> "" Then
                strsql = strsql & "and lower(name_company) like '%" & txtName.Text.ToLower & "%'"

            End If

            If ddlprovince.SelectedIndex > 0 Then
                strsql = strsql & "and province = '" & ddlprovince.SelectedValue & "'"

            End If

            dt = dbConnect.getDataTable(strsql & " order by name_company", "agency")
            gvMain.DataSource = dt
            gvMain.DataBind()
            UpdGrid.Update()


        Catch ex As Exception
        Finally
            dbConnect = Nothing
            con.Close()
            con.Dispose()

        End Try
    End Sub
    Private RowIndex As Integer = 1

    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.TableSection = TableRowSection.TableHeader
                e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
                'e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
                'e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
                'e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
            ElseIf e.Row.RowType = DataControlRowType.Pager Then
                e.Row.TableSection = TableRowSection.TableFooter
            Else
                Dim lnkFacebook As HyperLink = e.Row.Cells(6).FindControl("Hyperfacebook")
            End If

        Catch ex As Exception

        End Try
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
        'loadData()
        'gvMain.PageIndex = e.NewPageIndex
        'gvMain.DataBind()

        gvMain.PageIndex = e.NewPageIndex
        loadData()
    End Sub

    Protected Sub DDLPage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow = gvMain.BottomPagerRow
        Dim DDLPage As DropDownList = DirectCast(row.Cells(0).FindControl("DDLPage"), DropDownList)
        gvMain.PageIndex = DDLPage.SelectedIndex
        gvMain.DataBind()
        loaddata()
    End Sub

    Protected Sub ddl_PageSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_PageSize.SelectedIndexChanged
        If ddl_PageSize.SelectedValue <> "--" Then
            gvMain.PageSize = Convert.ToInt32(ddl_PageSize.SelectedValue)
            gvMain.DataBind()
            loaddata()
        End If
    End Sub
    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSch.Click
        loaddata()
    End Sub
End Class
