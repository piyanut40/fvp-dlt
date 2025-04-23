
Partial Class Admin_RptStatChartData
    Inherits System.Web.UI.Page

    Private PopulateS As New PopulateScript
    Protected _CSSDiv As String = "w3-large3 w3-padding-left100"
    Protected _rt As String = "1"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If PopulateS.IsMobile Then
                lblHead.Font.Bold = False
                lblHead.Font.Size = 17

                lbltab2.Font.Bold = False
                lbltab2.Font.Size = 17
                lbltab3.Font.Bold = False
                lbltab3.Font.Size = 17
                lbltab4.Font.Bold = False
                lbltab4.Font.Size = 17
                lbltab5.Font.Bold = False
                lbltab5.Font.Size = 17
                lbltab6.Font.Bold = False
                lbltab6.Font.Size = 17

                lbltab.Font.Bold = False
                lbltab.Font.Size = 17
                _CSSDiv = "w3-large2 w3-padding-left"
            End If
            If Request.QueryString("rt") = 1 Then
                lblHead.Text = lblHead.Text & "รถประจำถิ่น"
            ElseIf Request.QueryString("rt") = 2 Then
                lblHead.Text = lblHead.Text & "รถท่องเที่ยว"
            End If
            _rt = Request.QueryString("rt")
        End If
    End Sub
End Class
