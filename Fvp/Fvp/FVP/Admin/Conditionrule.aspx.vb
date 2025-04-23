Imports System.Data
Imports Npgsql
Imports System.IO

Partial Class Conditionrule
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected text As String
    Protected name As String
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "
    Dim fpathDoc As String = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("FileDocNews"))
    Dim fpathImg As String = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("FileNews"))

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_id") Is Nothing Then
            Response.Redirect("../Login.aspx")
        Else

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
        Dim table As DataTable
        'Dim str As String = " SELECT ROW_NUMBER() OVER (order by date_news desc ) as num , news_id , title, detail, To_CHAR(date_news, 'DD/MON/YYYY')as date_news  , CAST('MgtNews.aspx?id=' || news_id as varchar ) as urledit FROM news "
        Dim str As String = " SELECT ROW_NUMBER() over(order by cond_time desc) as num , cond_id , con_rule, latitude, longtitude, license_no , cond_time,CAST('MgtConditionrule.aspx?id=' || cond_id as varchar) as urledit , " & _
                            " rule_name " & _
                            " FROM public.condition_rule " & _
                            " LEFT JOIN license on license.license_id = condition_rule.license_id " & _
                            " LEFT JOIN condition on condition.con_id = condition_rule.con_id "
        If txtName.Text <> "" Then
            str = str & "WHERE license_no like '%" & txtName.Text & "%' "
        End If
        str = str & " order by cond_time desc "
        Dim dbconnect As New DBConnect
        table = dbconnect.getDataTable(str, "rule")
        gvMain.DataSource = table
        gvMain.DataBind()
        UpdatePanel1.Update()

    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.TableSection = TableRowSection.TableHeader
                'e.Row.Cells(2).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
                'e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
            ElseIf e.Row.RowType = DataControlRowType.Pager Then
                e.Row.TableSection = TableRowSection.TableFooter
            Else

                Dim lbl_consid As Label = e.Row.Cells(0).FindControl("lbl_consid")
                Dim lnkDel As HyperLink = e.Row.Cells(5).FindControl("HyperLinkDel")
                lnkDel.Attributes.Add("onclick", "javascript:DelData(" & lbl_consid.Text & ");")

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
      
        gvMain.PageIndex = e.NewPageIndex
        loaddata()
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

    Protected Sub lnkAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAdd.Click
        Response.Redirect("MgtConditionrule.aspx")

    End Sub

    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim dbConnect As New DBConnect

        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        ' Dim transaction As NpgsqlTransaction
        Dim TbFileOld As New DataTable
        Dim TbImgOld As New DataTable


        Try
            con.Open()
            cmd.Connection = con
            cmd.Parameters.Clear()
            cmd.CommandText = "DELETE FROM condition_rule WHERE cond_id = " & HidDel_ID.Value & ""
            cmd.ExecuteNonQuery()

           

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
        loaddata()
    End Sub
End Class
