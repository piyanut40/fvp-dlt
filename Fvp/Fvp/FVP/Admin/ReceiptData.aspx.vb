Imports System.Data
Imports Npgsql

Partial Class Admin_ReceiptData
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Not Request.QueryString("license_id") Is Nothing Then


                Dim cmd As New NpgsqlCommand
                Dim con As Npgsql.NpgsqlConnection = DBConnect.getConnection
                Dim strsql As String = ""
                Try
                    con.ClearPool()
                    cmd.Connection = con
                    cmd.Connection.Open()
                    strsql = "SELECT  license_id  , receipt , receipt_date FROM license  WHERE license_id = " & Request.QueryString("license_id") & " "
                    cmd.CommandText = strsql
                    Dim dr As NpgsqlDataReader
                    dr = cmd.ExecuteReader
                    Dim license_id As Object
                    Dim receipt, receipt_date As Object
                    If dr.Read Then
                        If Not dr("license_id") Is DBNull.Value Then
                            license_id = dr("license_id")
                        End If

                        If Not dr("receipt") Is DBNull.Value Then
                            receipt = dr("receipt")
                        End If
                        If Not dr("receipt_date") Is DBNull.Value Then
                            receipt_date = dr("receipt_date")
                        End If
                    End If
                    dr.Close()

                    Dim dbConnect As New DBConnect
                    Dim strreceipt As String = "select receipt_no , receipt_date from receipt where license_id = " & license_id
                    Dim dtreceipt As DataTable = dbConnect.getDataTable(strreceipt, "car_pic")
                    dtreceipt = dbConnect.getDataTable(strreceipt, "local")

                    If receipt <> "" Then
                        Dim nrow2 As DataRow = dtreceipt.NewRow
                        With nrow2
                            .Item("receipt_no") = receipt

                            If receipt_date <> "" Then
                                .Item("receipt_date") = receipt_date
                            End If
                        End With
                        dtreceipt.Rows.Add(nrow2)
                        nrow2 = Nothing
                    End If

                    PopulateS.SetGrid_Footable(gvMain, dtreceipt)
                    'gvMain.DataSource = dtreceipt
                    'gvMain.DataBind()

                    If dtreceipt.Rows.Count = 0 Then
                        gvMain.Visible = False
                    End If
                Catch ex As Exception
                    Dim ppScript As String = " alert('เกิดข้อผิดพลาด:: " & ex.Message & " ไม่สามารถเรียกข้อมูลแผนงานได้'); "
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", ppScript, True)
                Finally
                    cmd.Connection.Close()
                    con = Nothing
                End Try
            End If
        End If
    End Sub
End Class
