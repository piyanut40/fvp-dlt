Imports System.Data
Imports Npgsql
Partial Class Admin_CalendarAllV
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected text As String
    Protected name As String
    Protected cur_month As Integer = 0
    Protected cur_year As Integer = 0
    Protected yearid As Integer = 0
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
                yearid = Request.QueryString("yearid")

                If PopulateS.IsMobile Then
                    Css = ""
                End If
                loaddata()


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

            sqlstr = "select Row_number() over (order by dt.h_date) as number ,* from (select  gid, year_id, description, h_date, to_char(h_date , 'DD-MM-YYYY') as hdate, CAST('HolidayMgt.aspx?id=' || gid  as varchar ) as urldata   from holiday where year_id =" & Request.QueryString("yearid") & " order by h_date) dt "



            dt = dbConnect.getDataTable(sqlstr, "holiday")

            Dim holidays As String = ""
            If dt.Rows.Count > 0 Then
                Dim m_y As String = ""
                Dim cur_m_y As String = ""
                For Each dr As DataRow In dt.Rows


                    cur_m_y = Month(dr("h_date")) - 1 & "-" & dr("year_id")

                    If m_y = cur_m_y Then
                        holidays = holidays & """" & Day(dr("h_date")) & """" & ":" & """" & dr("description") & """" & ","
                    Else
                        m_y = cur_m_y
                        If holidays <> "" Then
                            holidays = holidays & "}_"
                        End If
                        holidays = holidays & Month(dr("h_date")) - 1 & "-" & dr("year_id") & "/{" & """" & Day(dr("h_date")) & """" & ":" & """" & dr("description") & """" & ","
                    End If

                Next
                holidays = holidays & "}"

                holidays = holidays.Replace(",}", "}")
            End If

            text = holidays

            Dim strjs As String = " $(document).ready(function() { " & _
                 " alert(44);" & _
                 " localStorage.clear();" & _
                   holidays & _
                   " alert(55);" & _
                   " }); "

            HidAllData.Value = holidays
        Catch ex As Exception

        Finally
            dbConnect = Nothing

        End Try

    End Sub
 

    Protected Sub BtnSch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSch.Click
        loaddata()
    End Sub
End Class
