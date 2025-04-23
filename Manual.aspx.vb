
Partial Class Manual
    Inherits System.Web.UI.Page

    'Protected Sub DDLPage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLPage.SelectedIndexChanged

    'End Sub
    Protected Csstext As String = "font-size: 2rem;color:#542a6b"
    Protected Csstext2 As String = "font-size: 1.6rem;color:#542a6b"
    Private PopulateS As New PopulateScript
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If PopulateS.IsMobile Then
            Csstext = "font-size: 1.2rem;color:#542a6b"
            Csstext2 = "font-size: 1.1rem;color:#542a6b"
        End If

        If Page.IsPostBack = False Then
            btnPrev.Visible = False
        End If
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Image1.ImageUrl = "~/Upload/FileManual/Manual2.png"
    End Sub
End Class
