
Partial Class Admin_MapPop
    Inherits System.Web.UI.Page
    Public no As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Not (Request.QueryString("no") Is Nothing) Then
                no = " <div class='row no-gutters align-items-center py-2 '>" & _
                             " <iframe runat='server' id='IframeLocation' enableviewstate='true' frameborder='0' name='IframeLocation' scrolling='yes' " & _
                             " width='100%' height='780px' src='../Map/RealtimeLocation.aspx?no=" & Request.QueryString("no") & "'> Your browser does not support iframes " & _
                             " </iframe>" & _
                             " </div>"
            Else
                no = " <div class='row no-gutters align-items-center py-2 '>" & _
                            " <iframe runat='server' id='IframeLocation' enableviewstate='true' frameborder='0' name='IframeLocation' scrolling='yes' " & _
                            " width='100%' height='780px' src='../Map/MapArea.aspx?pro=" & Request.QueryString("pro") & "'> Your browser does not support iframes " & _
                            " </iframe>" & _
                            " </div>"
            End If

        End If
    End Sub
End Class
