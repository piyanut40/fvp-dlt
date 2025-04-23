Imports System.Data

Partial Class Travel_GroupEdit
    Inherits System.Web.UI.Page
    Protected text As String
    Protected name As String
    Protected Css As String = " w3-padding-top w3-padding-right w3-right-align "
    Protected Css_Ctrl As String = ""
    Private Send As New SendEmail
    Private group_id, is_renew As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Try
                If Session("user_id") = Nothing Or Session("user_type") = 1 Then
                    Session.Clear()
                    Response.Redirect("../Login.aspx")
                End If
            Catch ex As Exception
                Response.Redirect("../Login.aspx")
            End Try
        End If

        If Not Request.QueryString("id") Is Nothing Then
            group_id = Request.QueryString("id")
        ElseIf Not Request.QueryString("token") Is Nothing Then
            Dim db As New DBConnect
            Try
                group_id = db.executeScalar("select group_id from travel_group where crypt(group_id :: text, 'groupid2562') = '" & Request.QueryString("token") & "' ")
            Catch ex As Exception

            Finally
                db = Nothing
            End Try
        Else
            group_id = Nothing
        End If


        If Not Request.QueryString("is_renew") Is Nothing Then
            is_renew = Request.QueryString("is_renew")
        End If


        If Page.IsPostBack = False Then
            Iframe1.Attributes("src") = "GroupAdd_tab1.aspx?is_renew=" & is_renew & IIf(group_id Is Nothing, "", "&id=" & group_id & "")
            Iframe2.Attributes("src") = "GroupAdd_tab2.aspx?is_renew=" & is_renew & IIf(group_id Is Nothing, "", "&id=" & group_id & "")
            Iframe3.Attributes("src") = "GroupAdd_tab3.aspx?is_renew=" & is_renew & IIf(group_id Is Nothing, "", "&id=" & group_id & "")
            If Not Request.QueryString("tab") Is Nothing Then

                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> tab_active(" & Request.QueryString("tab") & ");</script>", False)
            Else
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "pop", "<script language='javascript'> tab_active(1);</script>", False)
            End If

        Else
           
        End If


    End Sub

    Protected Sub btnNext3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext3.Click
        Dim db2 As New DBConnect
        Try


            Dim strDuplicate As String = "SELECT count(group_id) status , license_id FROM public.travel_group_car " & _
                                         "where license_id in (select license_id from travel_group_car where group_id = " & group_id & ") group by license_id "
            Dim dtDuplicate As DataTable = db2.getDataTable(strDuplicate, "data")
            If dtDuplicate.Rows.Count = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType, "popday", "<script language='javascript'> alert('Please add car');  tab_active(2); </script>")


            Else

                Page.ClientScript.RegisterStartupScript(Me.GetType, "popday", "<script language='javascript'> tab_active(3); </script>")
            End If
        Catch ex As Exception

        Finally
            db2 = Nothing
        End Try
    End Sub


End Class
