Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Web.Script.Serialization

Public Class PopulateScript
    Public Sub SetGrid_w3(ByVal pGrid As GridView, ByVal dt As DataTable)
        pGrid.DataSource = dt
        pGrid.DataBind()

        If dt.Rows.Count > 0 Then

            pGrid.Attributes.Add("data-role", "table")

            pGrid.Attributes.Add("data-input", "#filterTable-input")
            pGrid.Attributes.Add("data-filter", "true")


            pGrid.Attributes.Add("data-mode", "reflow")
            pGrid.Attributes.Add("class", "movie-list ui-responsive")


            pGrid.UseAccessibleHeader = True
            pGrid.HeaderRow.TableSection = TableRowSection.TableHeader
            pGrid.GridLines = GridLines.None
        End If
    End Sub

    Public Sub SetGrid_Footable(ByVal pGrid As GridView, ByVal dt As DataTable)
        pGrid.DataSource = dt
        pGrid.DataBind()

        Try
            If dt.Rows.Count > 0 Then
                'For Footable
                pGrid.Attributes.Add("class", "table")
                'pGrid.UseAccessibleHeader = True
                pGrid.HeaderRow.TableSection = TableRowSection.TableHeader
                pGrid.GridLines = GridLines.None
            End If
        Catch ex As Exception
            If System.Web.HttpContext.Current.Session("user_id") Is Nothing Then
                System.Web.HttpContext.Current.Response.Redirect("index.aspx")
            End If
        End Try

    End Sub

    Public Sub SetGrid_Footable(ByVal pGrid As GridView, ByVal dt As DataView)
        pGrid.DataSource = dt
        pGrid.DataBind()

        If dt.Table.Rows.Count > 0 Then
            'For Footable
            pGrid.Attributes.Add("class", "table")
            'pGrid.UseAccessibleHeader = True
            pGrid.HeaderRow.TableSection = TableRowSection.TableHeader
            pGrid.GridLines = GridLines.None
        End If
    End Sub

    Public Sub SetGrid_FootableSort(ByVal pGrid As GridView, ByVal dt As DataTable)
        pGrid.DataSource = dt
        pGrid.DataBind()

        If dt.Rows.Count > 0 Then
            'For Footable
            pGrid.Attributes.Add("class", "table")
            pGrid.Attributes.Add("data-sorting", "true")
            'pGrid.UseAccessibleHeader = True
            pGrid.HeaderRow.TableSection = TableRowSection.TableHeader
            pGrid.GridLines = GridLines.None
        End If
    End Sub


    Public Function GetJson(ByVal dt As DataTable) As String
        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object) = Nothing
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each dc As DataColumn In dt.Columns
                'If dc.ColumnName.Trim() = "TAGNAME" Then
                row.Add(dc.ColumnName.Trim(), dr(dc))
                'End If
            Next
            rows.Add(row)
        Next
        Return serializer.Serialize(rows)
    End Function


    Public Function IsMobile() As Boolean
        Dim strUserAgent As String = System.Web.HttpContext.Current.Request.UserAgent.ToString().ToLower()
        If Not strUserAgent Is DBNull.Value Then
            If System.Web.HttpContext.Current.Request.Browser.IsMobileDevice = True Or _
                strUserAgent.Contains("iphone") Or _
                strUserAgent.Contains("blackberry") Or _
                strUserAgent.Contains("mobile") Or _
                strUserAgent.Contains("windows ce") Or _
                strUserAgent.Contains("opera mini") Or _
                strUserAgent.Contains("palm") Then

                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function DIVHide(ByVal divName As String) As String

        Return " document.getElementById('" & divName & "').style.display ='none'; " & _
          " document.getElementById('" & divName & "').style.height = 0; " & _
          " document.getElementById('" & divName & "').style.width = 0; " & _
          " document.getElementById('" & divName & "').style.marginLeft = '0px'; "
    End Function

    Public Sub AddCssTableCell(ByVal CssName As String, ByVal tc As TableCell)
        Select Case CssName
            Case "HeadTbCell"
                tc.ForeColor = Drawing.Color.Black
                tc.Font.Bold = True
            Case "RowTbForm"
                tc.HorizontalAlign = HorizontalAlign.Left
                tc.BackColor = Drawing.ColorTranslator.FromHtml("#F8F8FF")
            Case "RowTbSub"

            Case "RowTbCellL"
                tc.HorizontalAlign = HorizontalAlign.Left

            Case "RowTbCellR"
                tc.HorizontalAlign = HorizontalAlign.Right

            Case "RowTbCell"
                tc.BackColor = Drawing.ColorTranslator.FromHtml("#fffced")
                tc.BorderWidth = Unit.Pixel(1)
                tc.Style("Padding-Right") = "8px"
                tc.BorderColor = Drawing.Color.Gray
            Case "HeadRowTbCell"
                tc.BorderWidth = Unit.Pixel(1)
                tc.ForeColor = Drawing.Color.White
                tc.BorderColor = Drawing.Color.Gray
                tc.BackColor = Drawing.ColorTranslator.FromHtml("#693b9b")
            Case "FooterRowTbCell"
                tc.BorderWidth = Unit.Pixel(1)
                tc.Style("Padding-Right") = "8px"
                tc.BorderColor = Drawing.Color.Gray
                tc.BackColor = Drawing.ColorTranslator.FromHtml("#b2aeba")
            Case "SubHeadRowTbCell"
                tc.BorderWidth = Unit.Pixel(1)
                tc.BorderColor = Drawing.Color.Gray
                tc.BackColor = Drawing.ColorTranslator.FromHtml("#e8be17")

        End Select
    End Sub

End Class
