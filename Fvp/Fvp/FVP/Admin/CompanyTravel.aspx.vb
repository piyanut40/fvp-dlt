Imports System.Data
Imports Npgsql

Partial Class Admin_CompanyTravel
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected text As String
    Protected name As String
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_id") Is Nothing Then
            Response.Redirect("../Login.aspx")
        Else
            If Session("user_id").ToString <> "adminbt" Then
                Session.Clear()
                Response.Redirect("../Login.aspx")
            End If
            If Page.IsPostBack = False Then
                loaddata()
                Populate.genPageSize(ddl_PageSize)
                ddl_PageSize.SelectedValue = 10
                If PopulateS.IsMobile Then
                    lnkAdd.Text = "<i class='fa fa-plus' aria-hidden='true' ></i> เพิ่ม"
                    Css = ""
                End If
            End If
        End If

    End Sub
    Private Sub loaddata()
        Dim dbconnect As New DBConnect
        Try
            Dim table As DataTable
            Dim str As String = " SELECT ROW_NUMBER() OVER (order by company_nameth ) as num , company_id , company_nameth , company_nameen, CAST('CompanyTravelMgt.aspx?id=' || company_id as varchar ) as urledit " & _
                " , company_license  , tumbol.p_name_t , email , telephone " & _
                " FROM company_travel left join tumbol on tumbol.t_id = company_travel.t_id "
            If txtName.Text <> "" Then
                str = str & "WHERE company_nameth like '%" & txtName.Text & "%' "
            End If
            str = str & " order by company_nameth "

            table = dbconnect.getDataTable(str, "company")
            gvMain.DataSource = table
            gvMain.DataBind()
            UpdatePanel1.Update()
        Catch ex As Exception

        Finally
            dbconnect = Nothing
        End Try
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
            e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            Dim lnkDel As HyperLink = e.Row.Cells(6).FindControl("HyperLinkDel")
            Dim lblcompany_id As Label = e.Row.Cells(0).FindControl("lblcompany_id")
            lnkDel.Attributes.Add("onclick", "javascript:DelData(" & lblcompany_id.Text & ");")
        End If
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
        loaddata()
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

    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSch.Click
        loadData()
    End Sub

    Protected Sub lnkAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAdd.Click
        Response.Redirect("CompanyTravelMgt.aspx")

    End Sub

    Protected Sub BtnDelete_Click(sender As Object, e As System.EventArgs) Handles BtnDelete.Click
        Dim dbConnect As New DBConnect

        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            Dim strdel As String

            strdel = "DELETE from company_travel WHERE company_id = " & HidDel_ID.Value
            cmd.CommandText = strdel
            cmd.ExecuteNonQuery()

            loaddata()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Try

        dbConnect = Nothing
    End Sub
End Class
