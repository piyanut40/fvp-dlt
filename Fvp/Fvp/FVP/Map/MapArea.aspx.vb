Imports System.Data

Partial Class Map_MapArea
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Not Request.QueryString("pro") Is Nothing Then
                loadMap()
            Else
                mBody.Attributes.Add("onload", " addMap(); ZoomLayerGroup(); ")
            End If
        End If
    End Sub


    Private Sub loadMap()
        If Request.QueryString("pro") = "-1" Then
            mBody.Attributes.Add("onload", " addMap(); ")
        Else
            Dim JsProvince As New StringBuilder
            JsProvince.Remove(0, JsProvince.Length)

            Dim db As New DBConnect
            Try
                Dim strProvince As String = "  select distinct prov_th , geomjson from province WHERE 1 = 1"

                If ("'" & Request.QueryString("pro").ToString.Replace(",", "','") & "'").Contains(",'0'") Then
                    strProvince = strProvince & " and prov_code = '0' "
                Else
                    strProvince = strProvince & " and prov_code in  ('" & Request.QueryString("pro").ToString.Replace(",", "','") & "') "
                End If

                Dim dtProvince As DataTable = db.getDataTable(strProvince, "Province")
                For Each dr As DataRow In dtProvince.Rows
                    Try
                        If dr("geomjson") IsNot DBNull.Value Then
                            JsProvince.Append("AddProvince([" & dr("geomjson") & "]);")
                        End If
                    Catch ex As Exception

                    End Try
                Next


            Catch ex As Exception

            Finally
                db = Nothing
            End Try

            If Page.IsPostBack = False Then
                mBody.Attributes.Add("onload", " addMap(); " & JsProvince.ToString & " ZoomLayerGroup(); ")
            Else
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", " RemoveLayerGroup(); " & JsProvince.ToString & " ZoomLayerGroup(); ", True)
            End If
        End If
    End Sub
End Class
