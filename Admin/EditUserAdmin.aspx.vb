Imports System.Data
Imports Npgsql

Partial Class EditUserAdmin
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
                If PopulateS.IsMobile Then
                    Css = ""
                End If
                loaddata()
                Populate.genPageSize(ddl_PageSize)
                ddl_PageSize.SelectedValue = 10

            End If
        End If

    End Sub
    Protected Sub lnkAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAdd.Click
        Response.Redirect("MgtEditUserAdmin.aspx")
    End Sub

    Private Sub loaddata()
        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dt As DataTable
        Dim sqlstr As String
        Try
            con.Open()


            sqlstr = "select Row_number() over (order by dt.username) as number ,* from (select  user_id , user_admin.username , admin_name , " & _
                    " CAST('MgtEditUserAdmin.aspx?id=' || user_id || '&ptype=1' as varchar ) as urldata, 1 as ptype   from user_admin " & _
                    " LEFT JOIN admin on user_admin.admin_id = admin.admin_id " & _
                    " union all " & _
                    " select  admin_id , username , admin_name , " & _
                    " CAST('MgtEditUserAdmin.aspx?id=' || admin_id || '&ptype=2' as varchar ) as urldata, 2 as ptype    from admin where admin_id <>1 ) dt "

            If txtName.Text <> "" Then
                sqlstr = sqlstr & "WHERE  lower(username) like lower('%" & txtName.Text & "%')"
            End If

            dt = dbConnect.getDataTable(sqlstr, "userlogin")
            PopulateS.SetGrid_Footable(gvMain, dt)
            UpdGrid.Update()
        Catch ex As Exception

        Finally
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
            Else
               
                Dim lnkData As HyperLink = e.Row.Cells(4).FindControl("HyperData")
                Dim lnkDel As HyperLink = e.Row.Cells(5).FindControl("HyperLinkDel")
                Dim lblid As Label = e.Row.Cells(0).FindControl("lblid")
                Dim lblptype As Label = e.Row.Cells(0).FindControl("lblptype")
                lnkDel.Attributes.Add("onclick", "javascript:DelUser(" & lblid.Text & ");")

                If lblptype.Text = 2 Then
                    lnkData.Visible = False
                    lnkDel.Visible = False
                End If

              
                Dim lblusername As Label = e.Row.Cells(0).FindControl("lblusername")
                Dim HyperReset As HyperLink = e.Row.Cells(5).FindControl("HyperReset")
                HyperReset.Attributes.Add("onclick", "javascript:ResetPass(" & lblid.Text & ",'" & lblusername.Text & "'," & lblptype.Text & ");")
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
        loaddata()
    End Sub

    Protected Sub ddl_PageSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_PageSize.SelectedIndexChanged
        If ddl_PageSize.SelectedValue <> "--" Then
            gvMain.PageSize = Convert.ToInt32(ddl_PageSize.SelectedValue)
            gvMain.DataBind()
            loaddata()
        End If
    End Sub
    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            Dim strdel As String
           
            strdel = "DELETE from user_admin WHERE user_id = " & HidDel_ID.Value
            cmd.CommandText = strdel
            cmd.ExecuteNonQuery()

            loaddata()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
    End Sub

    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSch.Click
        loaddata()
    End Sub

    Protected Sub BtnResetPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnResetPassword.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text

            Dim pass As Object = dbConnect.password(HidUsername.Value, HidUsername.Value)
            Dim strUpdate As String
            If hidptype.value = 1 Then
                strUpdate = " UPDATE user_admin SET password = '" & pass & "' where user_id = " & HidDel_ID.Value
            Else
                strUpdate = " UPDATE admin SET pass = '" & pass & "' where admin_id = " & HidDel_ID.Value
            End If

            cmd.CommandText = strUpdate
            cmd.ExecuteNonQuery()

            loaddata()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถอัพเดตข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
    End Sub
End Class
