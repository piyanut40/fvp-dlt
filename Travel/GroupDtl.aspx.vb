Imports System.Data
Imports Npgsql

Partial Class Travel_GroupDtl
    Inherits System.Web.UI.Page
    Protected text As String
    Private car_id As Integer
    Private tbIMG_car As New DataTable
    Private group_id As Integer
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "
    Protected Css_Ctrl As String = ""

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request.QueryString("isPopup") Is Nothing Then
            MasterPageFile = "~/MasterPageC.master"
        ElseIf Request.QueryString("isPopup") = "1" Then
            MasterPageFile = "~/MasterPagePopup.master"
        End If
       
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Request.QueryString("id") Is Nothing Then
            group_id = Request.QueryString("id")
            LoadData()
        ElseIf Not Request.QueryString("token") Is Nothing Then
            Dim db As New DBConnect
            Try
                group_id = db.executeScalar("select group_id from travel_group where crypt(group_id :: text, 'groupid2562') = '" & Request.QueryString("token") & "' ")
            Catch ex As Exception

            Finally
                db = Nothing
            End Try
            LoadData()
        End If

        Dim pScript As String = getMapprovince()
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptBack10", pScript, True)
    End Sub

    Private tbProvice As New DataTable
    Dim strprov_code As String = ""
    Private Function getMapprovince() As String
        With tbProvice
            .Columns.Add("area_id")
            .Columns.Add("prov_en")
            .Columns.Add("prov_code")
        End With
        For Each row As GridViewRow In gvProv.Rows
            Dim nrow As DataRow = tbProvice.NewRow
            nrow("area_id") = CType(row.Cells(0).FindControl("lblarea_id"), Label).Text
            nrow("prov_code") = CType(row.Cells(0).FindControl("lblprov_code"), Label).Text
            nrow("prov_en") = CType(row.Cells(0).FindControl("lblprov_en"), Label).Text
            tbProvice.Rows.Add(nrow)
        Next
        For Each i As DataRow In tbProvice.Rows
            Try
                'If Session("user_type") = 1 Or Session("user_type") = 2 Then
                strprov_code = strprov_code & i("prov_code").ToString & ","
                'End If
            Catch ex As Exception

            End Try
        Next
        strprov_code = strprov_code.Remove(strprov_code.Length - 1)
        Return "get_IframeMap('" & strprov_code & "');"
    End Function

    Private PopulateS As New PopulateScript
    Private enCul As New System.Globalization.CultureInfo("en-US")
    Private Sub LoadData()
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As Npgsql.NpgsqlConnection = dbConnect.getConnection
        Dim dread As Npgsql.NpgsqlDataReader
        Try
            con.Open()
            cmd.Connection = con

            Dim urlData1 As String = " CAST('GroupDtl.aspx?token='|| crypt(old_group_id :: text, 'groupid2562')  as varchar) "

            Dim strCheckUser As String = " SELECT group_name, start_date, exp_date, cntpeople, checkin_id, checkout_id , travel_group.admin_id , admin_nameen " & _
                                      " , border_in.border_nameen as border_name_in , border_out.border_nameen as border_name_out , old_group_id," & urlData1 & " as old_group_id_url, travel_itinerary_filesaved, travel_itinerary_filename " & _
                                      " FROM travel_group left join admin on admin.admin_id = travel_group.admin_id " & _
                                      " left join border_check border_in on border_in.border_id = travel_group.checkin_id " & _
                                      " left join border_check border_out on border_out.border_id = travel_group.checkout_id  " & _
                                      " WHERE group_id = " & group_id
         

            cmd.CommandText = CommandType.Text
            cmd.CommandText = strCheckUser
            dread = cmd.ExecuteReader()
            If dread.Read Then
                If Not dread("group_name") Is DBNull.Value Then
                    lblgroup_name.Text = dread("group_name")
                End If
                If Not dread("start_date") Is DBNull.Value Then
                    'txtStart.Text = dread("start_date")
                    lblStart.Text = Format(dread("start_date"), "dd MMMM yyyy")
                End If
                If Not dread("exp_date") Is DBNull.Value Then
                    'txtExpire.Text = dread("exp_date")
                    lblExpire.Text = Format(dread("exp_date"), "dd MMMM yyyy")
                End If
                 
                If Not dread("border_name_in") Is DBNull.Value Then
                    'ddlBorderCheckin.SelectedValue = dread("checkin_id")
                    lblCheckin.Text = dread("border_name_in")
                End If
                If Not dread("border_name_out") Is DBNull.Value Then
                    'ddlBorderCheckout.SelectedValue = dread("checkout_id")
                    lblCheckout.Text = dread("border_name_out")
                End If

                If Not dread("admin_nameen") Is DBNull.Value Then
                    'ddladmin.SelectedValue = dread("admin_id")
                    lbladmin_name.Text = dread("admin_nameen")
                End If

                If Not dread("old_group_id") Is DBNull.Value Then

                    hyperlinkRefer.NavigateUrl = dread("old_group_id_url")


                    If dread("old_group_id") <> 0 Then
                        divRefer.Visible = True
                    Else
                        divRefer.Visible = False
                    End If
                Else
                    hyperlinkRefer.Text = "-"
                End If

                If Not dread("travel_itinerary_filesaved") Is DBNull.Value Then
                    hidSTravel_Itinerary.Value = dread("travel_itinerary_filesaved")
                    hidFTravel_Itinerary.Value = dread("travel_itinerary_filename")

                    If hidSTravel_Itinerary.Value <> "" Then
                        Dim fpathstr = Server.MapPath(ConfigurationManager.AppSettings("FilePDF") & "/")
                        Dim tempFile = New System.IO.FileInfo(fpathstr & hidSTravel_Itinerary.Value)
                        lnkTravel_Itinerary.NavigateUrl = "../Travel/ViewFile.aspx?sname=" & hidSTravel_Itinerary.Value & "&fname=" & Server.UrlPathEncode(hidFTravel_Itinerary.Value) & "&fPath=FilePDF"
                        lnkTravel_Itinerary.Target = "_blank"
                        lnkTravel_Itinerary.Text = hidFTravel_Itinerary.Value
                        lnkTravel_Itinerary.Visible = True
                    Else
                        lnkTravel_Itinerary.Visible = False
                    End If
                Else
                    lnkTravel_Itinerary.Visible = False
                End If

            End If
            dread.Close()

           

            Dim sqlstr2 = "select area_id , prov_en , area_group.prov_code from area_group LEFT JOIN province on province.prov_code = area_group.prov_code WHERE group_id = " & group_id & " order by area_id "
            Dim Datatable2 As DataTable = dbConnect.getDataTable(sqlstr2, "DataTable2")
            If Datatable2.Rows.Count > 0 Then
                lblprov_en.Text = ""
                For Each dr As DataRow In Datatable2.Rows
                    If Datatable2.Rows.Count = 1 Then
                        lblprov_en.Text = dr("prov_en")
                    Else
                        lblprov_en.Text = lblprov_en.Text & " - " & dr("prov_en") & "<br/>"
                    End If
                Next

                gvProv.DataSource = Datatable2
                gvProv.DataBind()
            End If


            Dim dtCar As DataTable = dbConnect.getDataTable("select Row_number() over (order by travel_group_car.gid nulls last) as number , travel_group_car.gid , plate , country_car , type_name , dt.status " & _
                " , CAST(driver.prename || ' ' || driver.name || ' ' || driver.surname as varchar) as driver_name " & _
                " , travel_group.start_date , travel_group.exp_date , travel_group_car.license_id , token " & _
                " from travel_group_car LEFT JOIN travel_group on travel_group.group_id = travel_group_car.group_id  " & _
                " LEFT JOIN license on license.license_id = travel_group_car.license_id  " & _
                " LEFT JOIN driver on driver.driver_id = license.driver_id " & _
                " LEFT JOIN car on license.car_id = car.car_id " & _
                " left join type_car on type_car.type_id = car.typecar_id " & _
                " left join (SELECT count(group_id) status , license_id FROM public.travel_group_car group by license_id ) dt on dt.license_id = license.license_id " & _
                " where travel_group_car.group_id = " & group_id, "carr")
            PopulateS.SetGrid_Footable(gvMain, dtCar)
            UpdGrid.Update()
            lblcnt_car.Text = dtCar.Rows.Count


            Dim dtGuide As DataTable = dbConnect.getDataTable(" select Row_number() over (order by guide.guide_id nulls last) as number , " & _
                                      " travel_group_guide.gid , guide.guide_id , CAST(prename ||' ' || guide_name || ' ' || guide_surname as varchar) " & _
                                      "  as guide_name ,  guide_tel , guide_idcard , ( " & _
                                      "   SELECT count(*) from travel_group_guide as a " & _
                                      "   LEFT JOIN travel_group as b on a.group_id = b.group_id " & _
                                      "            WHERE(guide_id = guide.guide_id) " & _
                                      "    and ((start_date >= travel_group.start_date And exp_date <= travel_group.exp_date) or (start_date <= travel_group.exp_date  and exp_date >= travel_group.start_date)) " & _
                                      "  ) as status , " & _
                                      "    regis_no , regis_photo from guide  " & _
                                      "    INNER JOIN travel_group_guide on guide.guide_id = travel_group_guide.guide_id  " & _
                                      "    LEFT JOIN travel_group on travel_group.group_id = travel_group_guide.group_id " & _
                                      "    WHERE travel_group.group_id = " & group_id, "guide")
            PopulateS.SetGrid_Footable(gvMain_guide, dtGuide)
            UpdGrid_guide.Update()
            lblcnt_guide.Text = dtGuide.Rows.Count
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "Error();", True)
        Finally
            cmd.Connection.Close()
            con.Close()
            dbConnect = Nothing
            con.Dispose()
            cmd.Dispose()

        End Try
    End Sub

    Protected Sub gvMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
          

            Dim lbltoken As Label = e.Row.Cells(0).FindControl("lbltoken")
            Dim HyperDoc As HyperLink = e.Row.Cells(0).FindControl("HyperDoc")
            Dim strPopup = "javascript:w=window.open(" & _
                        """" & ResolveClientUrl("LicenseDtl.aspx?focus=divDriver&isPopup=1&rt=2&token=" & lbltoken.Text) & """," & _
                        """LicenseWindow""," & _
                        """" & "location=0,status=0,scrollbars=yes,resizable=no," & _
                        "width=1300,height=800""" & _
                        ");w.focus();"
            HyperDoc.NavigateUrl = "javascript://"
            HyperDoc.Attributes.Add("OnClick", strPopup)
        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        End If
    End Sub
    Protected Sub gvMain_guide_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvMain_guide.PageIndexChanging
        gvMain_guide.PageIndex = e.NewPageIndex
        LoadData()
    End Sub
    Protected Sub gvMain_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvMain.PageIndexChanging
        gvMain.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub gvMain_guide_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMain_guide.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblgid As Label = e.Row.Cells(0).FindControl("lblgid")
            Dim lblguide_id As Label = e.Row.Cells(0).FindControl("lblguide_id")
            Dim lnkDel As HyperLink = e.Row.Cells(0).FindControl("HyperLinkDel_guide")
            Dim Labelstatus As Label = e.Row.Cells(0).FindControl("Labelstatus_guide")
            Dim hidstatus As HiddenField = e.Row.Cells(0).FindControl("Hidstatus_guide")
            lnkDel.Attributes.Add("onclick", "javascript:DelData2(" & lblgid.Text & ");")
            If hidstatus.Value < 2 Then
                checkerr.Value = 0
            Else
                checkerr.Value = 1
                Labelstatus.Text = Labelstatus.Text.Replace("fa-check", "fa-asterisk")
                Labelstatus.ForeColor = Drawing.Color.Red
            End If

            Dim lblregis_photo As Label = e.Row.Cells(0).FindControl("lblregis_photo")
            Dim Imgregis As Image = e.Row.Cells(0).FindControl("Imgregis")
            If lblregis_photo.Text = "" Then
                Imgregis.Visible = False
            Else
                Imgregis.ImageUrl = "~/Upload/FileGuide/" & lblregis_photo.Text
                Imgregis.Visible = True
            End If

            Dim HyperDoc As HyperLink = e.Row.Cells(0).FindControl("HyperDoc")
            Dim strPopup = "javascript:w=window.open(" & _
                        """" & ResolveClientUrl("GuideDtl.aspx?isPopup=1&gid=" & lblgid.Text) & """," & _
                        """LicenseWindow""," & _
                        """" & "location=0,status=0,scrollbars=yes,resizable=no," & _
                        "width=1000,height=800""" & _
                        ");w.focus();"
            HyperDoc.NavigateUrl = "javascript://"
            HyperDoc.Attributes.Add("OnClick", strPopup)
        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            e.Row.TableSection = TableRowSection.TableFooter
        End If
    End Sub

     
End Class
