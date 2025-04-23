Imports System.Data
Imports Npgsql
Partial Class Local_arrival
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected text As String
    Protected name As String
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            If Session("user_id") = Nothing Or Session("user_type") = 2 Then
                Session.Clear()
                Response.Redirect("../Login.aspx")
            Else

                If PopulateS.IsMobile Then
                    Css = ""
                End If
                text = "Permits"
                name = "ชื่อบริษัท"
                Populate.genPageSize(ddl_PageSize)
                ddl_PageSize.SelectedValue = 10
                loadData()
               
            End If
        End If

    End Sub
    Private Sub loadData()
        Dim dbConnect As New DBConnect
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dt As DataTable
        Dim strsql As String = ""
        Try
          
            strsql = "SELECT * FROM ( SELECT Row_number() over (order by regis_date desc nulls last) as number,license.license_no , license_id , token , CAST(name || ' ' || surname as varchar) as name " & _
                           " , type_name as typecar_en, brands, model as models, status_en as status_th , CAST('LicenseDtl.aspx?rt=" & Session("typeuser_id") & "&token=' || token as varchar ) as urlDoc,license.typeuser_id,license.status_id " & _
                           " , CAST('~/Report/Qrcode.aspx?token=' || token as varchar ) as urlcode, license.qrcode as urlqrcode, CAST('~/Sign.aspx?token=' || token as varchar ) as urlSign " & _
                           " FROM license " & _
                           " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                           " LEFT JOIN car on car.car_id = license.car_id " & _
                           " LEFT JOIN type_car on car.typecar_id = type_car.type_id " & _
                           " LEFT JOIN status on license.status_id = status.status_id " & _
                           " LEFT JOIN user_cus on license.email = user_cus.username " & _
                           " WHERE (license.status_id=1 or license.status_id=5) and user_cus.user_id = " & Session("user_id") & ") as dt "

            If txtName.Text <> "" Then
                strsql = strsql & "WHERE name like '%" & txtName.Text & "%' "
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
            Dim url As String = HttpContext.Current.Request.Url.Host & "/Documenttoken="

            Dim lnkDel As HyperLink = e.Row.Cells(10).FindControl("HyperLinkDel")
            Dim lblLicense As Label = e.Row.Cells(0).FindControl("lblLicense")
            Dim lblToken As Label = e.Row.Cells(0).FindControl("lbltoken")

            Dim lbllicense_no As Label = e.Row.Cells(0).FindControl("lbllicense_no")
            lnkDel.Attributes.Add("onclick", "javascript:DelUser(" & lblLicense.Text & ");")

            Dim Hyperplan As HyperLink = e.Row.Cells(8).FindControl("Hyperplan")
            ' Hyperplan.Attributes.Add("onclick", "javascript:ResetActive(" & lblLicense.Text & ");")

            Hyperplan.NavigateUrl = "javascript:window.open('../Admin/MapPop.aspx?no=" & lbllicense_no.Text & "" & _
                              "','L11','scrollbars=yes,resizable=1,width=1002,height=900').focus();"

            Dim lnkDoc As HyperLink = e.Row.Cells(7).FindControl("HyperDoc")
            url = url & lblToken.Text
            lnkDoc.Attributes.Add("onclick", "javascript:linkDoc(" & url & ");")

            Dim lblstatusid As Label = e.Row.Cells(0).FindControl("lblstatus_id")
            Dim hyperDoc As HyperLink = e.Row.Cells(7).FindControl("HyperDoc")
            Dim hyperSign As HyperLink = e.Row.Cells(7).FindControl("HyperSign")


            If lblstatusid.Text <> 5 Then
                hyperDoc.Visible = False
                Hyperplan.Visible = False
                hyperSign.Visible = False
            End If

        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(4).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(5).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(6).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(7).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(8).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(10).Attributes.Add("data-breakpoints", "xs")
            e.Row.Cells(11).Attributes.Add("data-breakpoints", "xs")


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
            cmd.CommandText = "Update license set  status_id = 4 WHERE license_id = '" & HidLicense.Value & "' "
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถลบข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
        loadData()
    End Sub

    Protected Sub BtnResetActive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnResetActive.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Update license set license_no =:license_no , status_id = 1 WHERE license_id = '" & HidLicense.Value & "' "
            cmd.Parameters.Clear()
            cmd.Parameters.Add("license_no", NpgsqlTypes.NpgsqlDbType.Varchar).Value = licenseNo()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถอัพเดตข้อมูลได้ กรุณาลองอีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
    End Sub

    ''ออกเลขที่ใบอนุญาติ
    Private Function licenseNo() As String
        Dim sqlstr As String
        Dim DBconnect As New DBConnect
        sqlstr = " SELECT license_id  from ( select max(SUBSTRING(license_no,1,4)) as license_id , MAX(SUBSTRING(license_no,6,4)) as yearid " & _
                 " FROM license ) as dt WHERE yearid like '%" & Now.Year & "%'"
        Dim license_no As String = ""
        Dim no As Integer
        no = DBconnect.executeScalar(sqlstr)
        no = no + 1
        Dim length As Integer
        length = no.ToString.Length

        If length = 1 Then
            license_no = "000" & no & "/" & Now.Year
        ElseIf length = 2 Then
            license_no = "00" & no & "/" & Now.Year
        ElseIf length = 3 Then
            license_no = "0" & no & "/" & Now.Year
        ElseIf length = 4 Then
            license_no = "" & no & "/" & Now.Year
        End If

        Return license_no.ToString

    End Function


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
End Class
