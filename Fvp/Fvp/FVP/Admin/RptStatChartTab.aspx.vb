
Partial Class Admin_RptStatChartTab
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Request.QueryString("rt") = 1 Then
                lblHead.Text = "รถประจำถิ่น"
            ElseIf Request.QueryString("rt") = 2 Then
                lblHead.Text = "รถท่องเที่ยว"
            End If
            Iframe1.Attributes("src") = "RptStatChartAll.aspx?IsPopup=1&rt=" & Request.QueryString("rt")
            Iframe2.Attributes("src") = "RptStatChartAll_2.aspx?rt=" & Request.QueryString("rt")
            Iframe3.Attributes("src") = "RptStatChartAll_3.aspx?rt=" & Request.QueryString("rt")
            Iframe4.Attributes("src") = "RptStatChartAll_4.aspx?rt=" & Request.QueryString("rt")
            Iframe5.Attributes("src") = "RptStatChartAll_5.aspx?rt=" & Request.QueryString("rt")
            Iframe6.Attributes("src") = "RptStatChartAll_6.aspx?rt=" & Request.QueryString("rt")
        End If
    End Sub
End Class
