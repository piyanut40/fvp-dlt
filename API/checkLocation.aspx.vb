Imports System.Data
Imports Npgsql
Partial Class API_checkLocation
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
            If Page.IsPostBack = False Then
                If PopulateS.IsMobile Then
                End If
                loaddata()
                Populate.genPageSize(ddl_PageSize)
                ddl_PageSize.SelectedValue = 10
            End If

    End Sub

    Private Sub loaddata()
        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dt As DataTable
        Dim sqlstr As String
        Try
            con.Open()

            sqlstr = "SELECT id_location, lat, lon, token_license, to_char(date_time,'DD/MM/YYYY เวลา HH24:MI') as date_time " & _
                     " FROM public.realtime_location "
            If txtName.Text <> "" Then
                sqlstr = sqlstr & "WHERE token_license like '%" & txtName.Text & "%'"
            End If

            dt = dbConnect.getDataTable("select * from (" & sqlstr & " ) as dt", "userlogin")
            PopulateS.SetGrid_Footable(gvMain, dt)
            UpdGrid.Update()
        Catch ex As Exception

        Finally
            con.Close()
            con.Dispose()
            dbConnect = Nothing
        End Try

    End Sub
    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.TableSection = TableRowSection.TableHeader

                e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
            ElseIf e.Row.RowType = DataControlRowType.Pager Then
                e.Row.TableSection = TableRowSection.TableFooter
         
            End If
        Catch ex As Exception

        End Try
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
        loaddata()
        gvMain.PageIndex = e.NewPageIndex
        gvMain.DataBind()
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
    Private sendemail As New SendEmail
    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSch.Click
        loaddata()
    End Sub
End Class
