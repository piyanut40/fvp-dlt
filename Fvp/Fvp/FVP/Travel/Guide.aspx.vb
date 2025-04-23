Imports System.Data
Imports Npgsql

Partial Class Travel_Guide
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected text As String
    Protected name As String
    Protected qrCode As String = "https://api.qrserver.com/v1/create-qr-code/?size=300x300&data="
    Protected url As String = HttpContext.Current.Request.Url.Host & "/BorderTransport/Report/QRCode.aspx?token="
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            If Session("user_id") = Nothing Or Session("user_type") = 1 Then
                Response.Redirect("../Login.aspx")
            Else
                If PopulateS.IsMobile Then
                    lnkAdd.Text = "<i class='fa fa-plus' aria-hidden='true' ></i> Add"
                    Css = ""
                End If

                text = "ค้นหาขออนุญาตนำรถท่องเที่ยวเข้ามาในราชอาณาจักร"
                name = "ชื่อผู้ใช้รถ"
                Populate.genPageSize(ddl_PageSize)
                ddl_PageSize.SelectedValue = 10
                loadData()

            End If

        End If

    End Sub

    Private Sub loadData()
        Dim dbConnect As New DBConnect
        Dim dt As DataTable
        Dim strsql As String = ""
        Try

            Dim urlEdit As String = " CAST('GuideEdit.aspx?token='|| crypt(guide_id :: text, 'guide2562')  as varchar) "
            strsql = " select row_number() over (order by guide_id asc) as number , * from ( " & _
                     " select guide_id, CAST(prename ||' '|| guide_name || ' ' || guide_surname as varchar) as guide_name , guide_tel , guide_email , guide_idcard " & _
                     " , " & urlEdit & " as urlEdit from guide " & _
                     " WHERE(travel_user_id = '" & Session("user_id") & "') " & _
                     " ) as dt "

            If txtName.Text <> "" Then
                strsql = strsql & "WHERE lower(guide_name) like lower('%" & txtName.Text & "%')"
            End If

            dt = dbConnect.getDataTable(strsql, "local")

            PopulateS.SetGrid_Footable(gvMain, dt)
            UpdGrid.Update()

        Catch ex As Exception

        Finally
            dbConnect = Nothing
        End Try
    End Sub

    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblguide_id As Label = e.Row.Cells(0).FindControl("lblguide_id")
            Dim lnkDel As HyperLink = e.Row.Cells(0).FindControl("HyperLinkDel")

            lnkDel.Attributes.Add("onclick", "javascript:DelData(" & lblguide_id.Text & ");")

        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(3).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
           
        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        End If
    End Sub
    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim transaction As NpgsqlTransaction
        Dim tablecommand As DataTable = dbConnect.TableCommand
        Try
            con.Open()
            transaction = con.BeginTransaction()
            cmd.Connection = con

            cmd.Parameters.Clear()
            cmd.CommandText = " delete from guide where guide_id = " & HidDel_ID.Value
            cmd.ExecuteNonQuery()

            transaction.Commit()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            'dbConnect = Nothing
        End Try
        loadData()
    End Sub

    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSch.Click
        loadData()
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


    Protected Sub lnkAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAdd.Click

        Response.Redirect("GuideEdit.aspx")

    End Sub
End Class
