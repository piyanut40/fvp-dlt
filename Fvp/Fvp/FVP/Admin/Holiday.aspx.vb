Imports System.Data
Imports Npgsql

Partial Class Admin_Holiday
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

                Populate.genDDLBudyearEN(ddlYear, Now.Year, "")
                Populate.genDDLBudyearEN(ddlYear0, Now.Year, "")
                If PopulateS.IsMobile Then
                    Css = ""
                End If
                loaddata()
                Populate.genPageSize(ddl_PageSize)
                ddl_PageSize.SelectedValue = 10

            End If
        End If

    End Sub

    Private Sub loaddata()
        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dt As DataTable
        Dim sqlstr As String
        Try
            con.Open()

            sqlstr = "select Row_number() over (order by dt.h_date) as number ,* from (select  gid, year_id, description, h_date, to_char(h_date , 'DD-MM-YYYY') as hdate, CAST('HolidayMgt.aspx?id=' || gid  as varchar ) as urldata   from holiday where year_id = " & ddlYear.SelectedValue & " order by h_date) dt "



            dt = dbConnect.getDataTable(sqlstr, "holiday")
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

                'e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
            ElseIf e.Row.RowType = DataControlRowType.Pager Then
                e.Row.TableSection = TableRowSection.TableFooter
            Else

                'Dim lnkData As HyperLink = e.Row.Cells(4).FindControl("HyperData")
                Dim lnkDel As HyperLink = e.Row.Cells(6).FindControl("HyperLinkDel")
                Dim lnkEdit As HyperLink = e.Row.Cells(5).FindControl("HyperEdit")
                Dim lblid As Label = e.Row.Cells(0).FindControl("lblid")
                'Dim lblptype As Label = e.Row.Cells(0).FindControl("lblptype")
                lnkDel.Attributes.Add("onclick", "javascript:DelUser(" & lblid.Text & ");")

                lnkEdit.Attributes.Add("onclick", "javascript:Edit(" & lblid.Text & ",'" & e.Row.Cells(3).Text & "','" & e.Row.Cells(4).Text & "');")
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

            strdel = "DELETE from holiday WHERE gid = " & HidDel_ID.Value
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

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) ' Handles BtnSave.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim urlpath As String = ""
        Dim token As String
        Dim typegroup As String
        Dim TableCommand As DataTable = dbConnect.TableCommand

        Try
            Dim ar_txtDate As String() = txth_date.Text.ToString.Split("/")
            Dim _txtDate As New DateTime
            Try
                _txtDate = New DateTime(ar_txtDate(2), ar_txtDate(1), ar_txtDate(0))
            Catch ex As Exception

            End Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            Dim strsql As String
            If hid_id.Value = "" Then
                strsql = "insert into holiday (year_id, h_date, description) values(:year_id, :h_date, :description) "
            Else
                strsql = "Update holiday set year_id = :year_id, h_date = :h_date, description = :description  WHERE gid = " & hid_id.Value
            End If

            cmd.CommandText = strsql
            cmd.Parameters.Clear()
            cmd.Parameters.Add("year_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = ar_txtDate(2) 'ddlYear0.SelectedValue
            cmd.Parameters.Add("h_date", NpgsqlTypes.NpgsqlDbType.Date).Value = IIf(txth_date.Text.Trim = "", Nothing, _txtDate)
            cmd.Parameters.Add("description", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(txtdesc.Text.Trim = "", Nothing, txtdesc.Text)
            cmd.ExecuteNonQuery()

            loaddata()
            'ScriptManager.RegisterStartupScript(Page, GetType(Page), "script", "window.open('" & urlpath & "&typeuser=" & Request.QueryString("rt") & "','_newtab');", True)
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถบันทึกได้ กรุณาลองใหม่อีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
    End Sub
End Class
