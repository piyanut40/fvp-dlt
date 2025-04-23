Imports System.Data
Imports System.EnterpriseServices
Imports Npgsql

Partial Class EditUser
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected text As String
    Protected name As String
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Session("user_id") Is Nothing Then
    '        Response.Redirect("../Login.aspx")
    '    Else
    '        If Session("user_id").ToString <> "adminbt" Then
    '            Session.Clear()
    '            Response.Redirect("../Login.aspx")
    '        End If
    '        If Page.IsPostBack = False Then
    '            If PopulateS.IsMobile Then
    '                Css = ""
    '            End If
    '            loaddata()
    '            Populate.genPageSize(ddl_PageSize)
    '            ddl_PageSize.SelectedValue = 10

    '        End If
    '    End If

    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loaddata()
            'BindData()
        End If
    End Sub

    Private Sub BindData()
        ' สร้าง DataTable และเพิ่มคอลัมน์
        Dim dt As New DataTable()
        dt.Columns.Add("number")
        dt.Columns.Add("user_id")
        dt.Columns.Add("user_type")
        dt.Columns.Add("is_active")
        dt.Columns.Add("user_name")
        dt.Columns.Add("name_company")
        dt.Columns.Add("username")
        dt.Columns.Add("active_name")
        dt.Columns.Add("urldata")

        ' ทดสอบเพิ่มข้อมูลตัวอย่าง
        dt.Rows.Add("1", "1", "Admin", "Active", "สมชาย ใจดี", "บริษัท A", "somchai123", "Active", "#")
        dt.Rows.Add("2", "2", "User", "Inactive", "สายฟ้า เร็วแรง", "บริษัท B", "saifa789", "Inactive", "#")

        '' แสดงชื่อคอลัมน์ทั้งหมด
        'For Each col As DataColumn In dt.Columns
        '    Response.Write(col.ColumnName & "<br>")
        'Next

        ' ตรวจสอบว่ามีข้อมูลหรือไม่
        If dt.Rows.Count > 0 Then
            gvMain.DataSource = dt
            gvMain.DataBind()
        Else
            gvMain.DataSource = Nothing
            gvMain.DataBind()
        End If
    End Sub



    Private Sub loaddata()
        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
        Dim dt As DataTable
        Dim sqlstr As String
        Try
            con.Open()

            'sqlstr = "select Row_number() over (order by user_id) as number , CASE WHEN is_active = 0 THEN 'Not Active ' WHEN is_active = 1 THEN 'Active' END as active_name,* " &
            '    " , CAST('UserTravelData.aspx?id=' || user_id as varchar ) as urldata from user_travel where 1=1"

            'sqlstr = "select Row_number() over (order by user_id) as number , CASE WHEN is_active = 0 THEN 'Not Active ' WHEN is_active = 1 THEN 'Active' END as active_name, *" &
            '",user_id, user_name,user_type, name_company, username, CAST('UserTravelData.aspx?id=' || user_id as varchar ) as urldata from user_travel where 1=1"


            sqlstr = "select Row_number() over (order by user_id) as number, " &
         "CASE WHEN is_active = 0 THEN 'Not Active' WHEN is_active = 1 THEN 'Active' END as active_name, " &
         "user_id, user_type, user_name, name_company, username,is_active, " &
         "CAST('UserTravelData.aspx?id=' || user_id as varchar) as urldata " &
         "from user_travel where 1=1"

            If txtName.Text <> "" Then
                sqlstr = sqlstr & "and  user_name like '%" & txtName.Text & "%'"
            End If

            If Request.QueryString("st") Is Nothing Then

            ElseIf Request.QueryString("st") = 0 Then
                sqlstr = sqlstr & " and is_active = 0 "
            ElseIf Request.QueryString("st") = 1 Then
                sqlstr = sqlstr & " and is_active = 1 "
            End If

            'Response.Write("SQL Query: " & sqlstr)
            'Response.End()
            'If dbConnect.getDataTable("select * from (" & sqlstr & " ) as dt", "userlogin") Is Nothing Then
            '    Response.Write("Error: getDataTable คืนค่า Nothing")
            '    Response.End()
            'End If
            dt = dbConnect.getDataTable("select * from (" & sqlstr & " ) as dt", "userlogin")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                gvMain.DataSource = dt
                gvMain.DataBind()
            Else
                gvMain.DataSource = Nothing
                gvMain.DataBind()
            End If
            PopulateS.SetGrid_Footable(gvMain, dt)
            UpdGrid.Update()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถดึงข้อมูลได้: " & ex.Message & "');", True)

        Finally

            If con.State = ConnectionState.Open Then
                con.Close()
                con.Dispose()
            End If
            dbConnect = Nothing
        End Try

    End Sub
    'Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
    '    Try
    '        If e.Row.RowType = DataControlRowType.Header Then
    '            e.Row.TableSection = TableRowSection.TableHeader

    '            e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
    '            e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
    '            e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
    '            e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
    '            e.Row.Cells(9).Attributes.Add("data-breakpoints", "xs")
    '        ElseIf e.Row.RowType = DataControlRowType.Pager Then
    '            e.Row.TableSection = TableRowSection.TableFooter
    '        Else

    '            Dim lnkDel As HyperLink = e.Row.Cells(6).FindControl("HyperLinkDel")
    '            Dim lblid As Label = e.Row.Cells(0).FindControl("lblid")
    '            Dim lbltype As Label = e.Row.Cells(0).FindControl("lbltype")
    '            lnkDel.Attributes.Add("onclick", "javascript:DelUser(" & lblid.Text & ",'" & lbltype.Text & "');")

    '            Dim lnkActive As HyperLink = e.Row.Cells(5).FindControl("HyperActive")
    '            Dim lblis_active As Label = e.Row.Cells(0).FindControl("lblactive")
    '            lnkActive.Attributes.Add("onclick", "javascript:ResetActive(" & lblid.Text & ",'" & lbltype.Text & "','" & lblis_active.Text & "');")

    '            Dim lblusername As Label = e.Row.Cells(0).FindControl("lblusername")
    '            Dim HyperReset As HyperLink = e.Row.Cells(5).FindControl("HyperReset")
    '            HyperReset.Attributes.Add("onclick", "javascript:ResetPass(" & lblid.Text & ",'" & lblusername.Text & "');")

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.TableSection = TableRowSection.TableHeader

                e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(9).Attributes.Add("data-breakpoints", "xs")
            ElseIf e.Row.RowType = DataControlRowType.Pager Then
                e.Row.TableSection = TableRowSection.TableFooter
            Else
                ' ประกาศตัวแปรก่อนใช้งาน
                Dim lnkDel As HyperLink = CType(e.Row.Cells(6).FindControl("HyperLinkDel"), HyperLink)
                Dim lblid As Label = CType(e.Row.Cells(0).FindControl("lblid"), Label)
                Dim lbltype As Label = CType(e.Row.Cells(0).FindControl("lbltype"), Label)
                Dim lblis_active As Label = CType(e.Row.Cells(0).FindControl("lblactive"), Label)
                Dim lblusername As Label = CType(e.Row.Cells(0).FindControl("lblusername"), Label)

                ' ตรวจสอบว่า lnkDel และ lblid, lbltype ไม่ใช่ Nothing
                If lnkDel IsNot Nothing AndAlso lblid IsNot Nothing AndAlso lbltype IsNot Nothing Then
                    lnkDel.Attributes.Add("onclick", "javascript:DelUser(" & lblid.Text & ",'" & lbltype.Text & "');")
                End If

                ' ตรวจสอบ lnkActive
                Dim lnkActive As HyperLink = CType(e.Row.Cells(5).FindControl("HyperActive"), HyperLink)
                If lnkActive IsNot Nothing AndAlso lblis_active IsNot Nothing Then
                    lnkActive.Attributes.Add("onclick", "javascript:ResetActive(" & lblid.Text & ",'" & lbltype.Text & "','" & lblis_active.Text & "');")
                End If

                ' ตรวจสอบ HyperReset
                Dim HyperReset As HyperLink = CType(e.Row.Cells(5).FindControl("HyperReset"), HyperLink)
                If HyperReset IsNot Nothing AndAlso lblusername IsNot Nothing Then
                    HyperReset.Attributes.Add("onclick", "javascript:ResetPass(" & lblid.Text & ",'" & lblusername.Text & "');")
                End If
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
    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            Dim strdel As String
          
            strdel = "DELETE from user_travel WHERE user_id = " & HidDel_ID.Value
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
    Private sendemail As New SendEmail

    Protected Sub BtnResetActive_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles BtnResetActive.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text

            Dim strUpdate As String = ""


            Dim sqlTravel As String = "SELECT CAST(user_name || ' ' || user_surname as varchar) as user_name , name_company , username , email from user_travel WHERE user_id = " & HidDel_ID.Value
            Dim DataTable = dbConnect.ReadDataTable(sqlTravel)
            Dim dr As DataRow
            dr = DataTable.Select()(0)

            If HidActive.Value = "0" Then
                strUpdate = " UPDATE user_travel SET is_active = 1 where user_id = " & HidDel_ID.Value
                sendemail.EmailTravelApprove(dr("email"), dr("user_name"), dr("name_company"), dr("username"))
            ElseIf HidActive.Value = "1" Then
                strUpdate = " UPDATE user_travel SET is_active = 0 where user_id = " & HidDel_ID.Value
                sendemail.EmailTravelCancel(dr("email"), dr("user_name"), dr("name_company"), dr("username"))
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
            Dim strUpdate As String = " UPDATE user_travel SET pass = '" & pass & "' where user_id = " & HidDel_ID.Value
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
