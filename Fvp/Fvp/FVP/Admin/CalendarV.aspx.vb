Imports System.Data
Imports Npgsql
Partial Class Admin_CalendarV
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown

    Protected min_date As Object
    Protected _dd As Object
    Protected _mm As Object
    Protected _yyyy As Object
    Protected text As String
    Protected name As String
    Protected cur_month As Integer = 0
    Protected cur_year As Integer = 0
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

            sqlstr = "select Row_number() over (order by dt.h_date) as number ,* from (select  gid, year_id, description, h_date, to_char(h_date , 'DD-MM-YYYY') as hdate, CAST('HolidayMgt.aspx?id=' || gid  as varchar ) as urldata   from holiday order by h_date) dt "


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

            Dim _day As Integer = 0
            Dim _date As Date
            Dim myCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
            If myCulture.Calendar.GetDayOfWeek(Date.Today).ToString.ToLower = "sunday" Then
                _day = 6
            ElseIf myCulture.Calendar.GetDayOfWeek(Date.Today).ToString.ToLower = "monday" Then
                _day = 5
            Else
                _day = 7
            End If


            Dim strChkDate As String = "SELECT count(h_date) FROM holiday where h_date between '" & Date.Today & "' and '" & DateAdd(DateInterval.Day, (_day), Date.Today) & "'"
            Dim DBCon As New DBConnect
            Dim Cnt_h_date As Integer = DBCon.executeScalar(strChkDate)

            _date = DateAdd(DateInterval.Day, (_day + Cnt_h_date), Date.Today)

            strChkDate = "select min(the_day) from (SELECT *  FROM generate_series(timestamp '" & DateAdd(DateInterval.Day, (_day + Cnt_h_date), Date.Today) & "', timestamp '" & DateAdd(DateInterval.Day, (_day + Cnt_h_date + 7), Date.Today) & "' , interval  '1 day') the_day  " & _
                " WHERE the_day not in (SELECT h_date FROM holiday where extract('ISODOW' FROM h_date) < 6 ) ) dt "
            _date = DBCon.executeScalar(strChkDate)

            _dd = Format(_date, "dd")
            _mm = Format(_date, "MM")
            _yyyy = Format(_date, "yyyy")
            min_date = Format(_date, "dd/MM/yyyy") ' "+" & DateDiff(DateInterval.Day, Date.Today, _date)

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

    Public Shared Function ConvertToDateTime(ByVal strExcelDate As String) As String
        Dim excelDate As Double
        Try
            excelDate = Convert.ToDouble(strExcelDate)
        Catch
            Return strExcelDate
        End Try
        If excelDate < 1 Then
            Throw New ArgumentException("Excel dates cannot be smaller than 0.")
        End If
        Dim dateOfReference As New DateTime(1900, 1, 1)
        If excelDate > 60.0 Then
            excelDate = excelDate - 2
        Else
            excelDate = excelDate - 1
        End If
        Return dateOfReference.AddDays(excelDate).ToShortDateString()
    End Function

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) ' Handles BtnSave.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Dim urlpath As String = ""
        Dim token As String
        Dim typegroup As String
        'Dim TableCommand As DataTable = dbConnect.TableCommand

        Try
            Dim ar_txtDate As String() = HidData.Value.Split(":")
            Dim _txtDate As New DateTime
            Try
                cur_month = Hidmonth.Value
                cur_year = Hidyear.Value
                _txtDate = New DateTime(Hidyear.Value, Hidmonth.Value, ar_txtDate(0))
            Catch ex As Exception

            End Try

            hid_id.Value = dbConnect.executeScalar("select gid from holiday where h_date = '" & _txtDate & "'")

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
            cmd.Parameters.Add("year_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Hidyear.Value 'ddlYear0.SelectedValue
            cmd.Parameters.Add("h_date", NpgsqlTypes.NpgsqlDbType.Date).Value = _txtDate
            cmd.Parameters.Add("description", NpgsqlTypes.NpgsqlDbType.Varchar).Value = IIf(ar_txtDate(1).ToString.Trim = "", Nothing, ar_txtDate(1))
            cmd.ExecuteNonQuery()

            loaddata()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", "alert('ไม่สามารถบันทึกได้ กรุณาลองใหม่อีกครั้ง');", True)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dbConnect = Nothing
        End Try
    End Sub

    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles BtnDelete.Click
        Dim dbConnect As New DBConnect
        Dim cmd As New NpgsqlCommand
        Dim con As NpgsqlConnection = dbConnect.getConnection
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            Dim strdel As String

            'Dim ar_txtDate As String() = HidData.Value.Split(":")
            Dim _txtDate As New DateTime
            Try
                cur_month = Hidmonth.Value
                cur_year = Hidyear.Value
                _txtDate = New DateTime(Hidyear.Value, Hidmonth.Value, HidDel_ID.Value)
            Catch ex As Exception

            End Try

   
            strdel = "DELETE from holiday WHERE h_date = '" & _txtDate & "'"
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
    Protected Sub BtnDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDtl.Click
        Response.Redirect("CalendarAllV.aspx?yearid=" & Hidyear.Value)
    End Sub
End Class
