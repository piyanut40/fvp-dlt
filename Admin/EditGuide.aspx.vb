Imports System.Data
Imports Npgsql

Partial Class EditGuide
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

    Private Sub loaddata()
        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dt As DataTable
        Dim sqlstr As String
        Try
            con.Open()

            sqlstr = " select Row_number() over (order by guide_id) as number , " & _
                    " CAST(prename || ' ' || guide_name || ' ' || guide_surname as varchar ) as name, " & _
                    " guide_tel , guide_email , user_travel.name_company , guide_idcard, cast('GuideDtl.aspx?gid=' || guide_id as varchar) as urldata from guide " & _
                    " LEFT JOIN user_travel on user_travel.user_id = guide.travel_user_id "
            If txtName.Text <> "" Then
                sqlstr = sqlstr & "WHERE  lower(prename||guide_name||guide_surname) like lower('%" & txtName.Text & "%') "
            End If

            dt = dbConnect.getDataTable("select * from (" & sqlstr & " ) as dt", "userlogin")
            PopulateS.SetGrid_Footable(gvMain, dt)
            UpdGrid.Update()
        Catch ex As Exception

        Finally
            dbConnect = Nothing
            con.Close()
            con.Dispose()

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
End Class
