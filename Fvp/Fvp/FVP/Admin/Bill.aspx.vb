Imports System.Data
Imports Npgsql

Partial Class Bill
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
                If Session("user_type").ToString.IndexOf("ขนส่งจังหวัด") <= -1 And Session("user_type") <> "0" Then
                    Session.Clear()
                    Response.Redirect("../Login.aspx")
                End If

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

            sqlstr = " select ROW_NUMBER() OVER(order by license_no desc, unit desc) as rownum ,  * from  ( " & _
                      " SELECT license_id,license_id as id , license_no , receipt as receipt_no , registrar_name , registrar_position , receipt_pc , receipt_process , cast(1 as integer) as unit , CAST('LicenseDtl.aspx?rt=' || typeuser_id || '&token=' || token as varchar) as urldata, license.admin_id " & _
                      " FROM license " & _
                      " WHERE receipt_pc Is Not null  " & _
                      "  UNION ALL " & _
                      " SELECT license.license_id, receipt.id  , license.license_no , receipt_no , receipt.registrar_name , receipt.registrar_position , receipt.receipt_pc , receipt.receipt_process , unit , CAST('LicenseDtl.aspx?rt=' || typeuser_id || '&token=' || token as varchar) as urldata, license.admin_id  " & _
                      " FROM receipt  " & _
                      " LEFT JOIN license on license.license_id = receipt.license_id ) as dt WHERE 1=1 "
            If txtName.Text <> "" Then
                sqlstr = sqlstr & " and receipt_no like '%" & txtName.Text & "%'"
            End If
            If (Session("user_type").ToString.IndexOf("ขนส่งจังหวัด") > -1 Or Session("user_type") = "0") Then
                sqlstr = sqlstr & " and admin_id = " & Session("admin_id") 'Session("user_id").ToString.Replace("T", "")
            End If


            sqlstr = sqlstr & " order by license_no desc, unit desc"
            'dt = dbConnect.getDataTable("select * from (" & sqlstr & " ) as dt", "userlogin")
            dt = dbConnect.getDataTable(sqlstr, "bill")
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
                e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
                e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")

                If Session("user_id").ToString = "adminbt" Then
                    e.Row.Cells(10).Visible = False
                End If
            ElseIf e.Row.RowType = DataControlRowType.Pager Then
                e.Row.TableSection = TableRowSection.TableFooter
            Else
                Dim lnk As HyperLink = e.Row.Cells(6).FindControl("HyperData")
                Dim lblid As Label = e.Row.Cells(0).FindControl("lblid")


                If Session("user_id").ToString = "adminbt" Then
                    e.Row.Cells(10).Visible = False
                Else
                    Dim HyperEdit As HyperLink = e.Row.Cells(10).FindControl("HyperEdit")
                    HyperEdit.Attributes.Add("onclick", "javascript:SetPopupEdit(" & lblid.Text & ",'" & e.Row.Cells(4).Text & "','" & e.Row.Cells(5).Text & "','" & e.Row.Cells(6).Text & "','" & e.Row.Cells(7).Text & "','" & e.Row.Cells(3).Text & "'," & e.Row.Cells(8).Text & ");")
                    'gid, registar_name, registar_position, Reciept_pc, Reciept_process, Reciept
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

    Protected Sub BtnReceipt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReceipt.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim urlpath As String = ""
        Dim TableCommand As DataTable = dbConnect.TableCommand

        Try

            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            If Hidunit.Value > 1 Then
                cmd.CommandText = "update receipt set  receipt_no = :receipt_no , receipt_pc = :receipt_pc, receipt_process = :receipt_process " & _
                                    " , registrar_name = :registrar_name , registrar_position = :registrar_position where id = " & Hidid.Value

                cmd.Parameters.Clear()
                cmd.Parameters.Add("receipt_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtReciept.Text
                cmd.Parameters.Add("receipt_pc", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtReciept_pc.Text
                cmd.Parameters.Add("receipt_process", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtReciept_process.Text
                cmd.Parameters.Add("registrar_position", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_position.Text
                cmd.Parameters.Add("registrar_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_name.Text
                cmd.ExecuteNonQuery()
            Else
                cmd.CommandText = "update license set  receipt = :receipt , receipt_pc = :receipt_pc, receipt_process = :receipt_process " & _
                                 " , registrar_name = :registrar_name , registrar_position = :registrar_position where license_id = " & Hidid.Value

                cmd.Parameters.Clear()
                cmd.Parameters.Add("receipt", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtReciept.Text
                cmd.Parameters.Add("receipt_pc", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtReciept_pc.Text
                cmd.Parameters.Add("receipt_process", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtReciept_process.Text
                cmd.Parameters.Add("registrar_position", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_position.Text
                cmd.Parameters.Add("registrar_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = txtregistar_name.Text
                cmd.ExecuteNonQuery()
            End If


            loadData()

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
