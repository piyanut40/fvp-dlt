Imports System.Data

Partial Class Map_MapLocationHis
    Inherits System.Web.UI.Page
    Private PopulateS As New PopulateScript
    Private Populate As New PopulateDropDown
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            'genDDLLicense(ddlLicense)
            'Populate.genDDLCountry(ddlcountry, "เลือกทั้งหมด")
            'Populate.genDDLCartype(ddltype_car, True)
            'Populate.genDDLTypeUser(ddltype, True)
            loadMap(False)
        End If
    End Sub

    Private Sub loadMap(ByVal IsClickPopup As Boolean)
        Dim db As New DBConnect
        Dim JsMarkerCar As String = ""
        Dim Popup As String = ""
        Dim JsProvince As New StringBuilder
        JsProvince.Remove(0, JsProvince.Length)
        Try
            Dim is_guide As Boolean = False
            Dim strsql As String = " SELECT name_company , to_char(start_date , 'MM/DD/YYYY') as start_date , to_char(exp_date , 'MM/DD/YYYY') as exp_date , _name  as guide , is_guide " & _
            " from vmaplocation where token  = '" & Request.QueryString("token") & "' limit 1 "
            Dim dtData As DataTable = db.getDataTable(strsql, "Province")
            Dim drRow As DataRow = dtData.Rows(0)
            If Not drRow("is_guide") Is DBNull.Value Then
                If drRow("is_guide") = 1 Then
                    is_guide = True
                Else
                    lblHeads.text = "คนขับรถ"
                End If
            End If
            If Not drRow("name_company") Is DBNull.Value Then
                lblname_company.Text = drRow("name_company")
            End If
            If Not drRow("start_date") Is DBNull.Value Then
                lbldate.Text = Format(CDate(drRow("start_date")), "MM/dd/yyyy")
            End If
            If Not drRow("exp_date") Is DBNull.Value Then
                lbldate.Text = lbldate.Text & " - " & Format(CDate(drRow("exp_date")), "MM/dd/yyyy")
            End If
            If Not drRow("guide") Is DBNull.Value Then
                lblguide.Text = drRow("guide")
            End If

            Dim strProvince As String = " select distinct prov_th , geomjson  from province " & _
                " where prov_code in (select prov_code from  area_group where 1=1 "
            If is_guide Then
                strProvince = strProvince & " and group_id in ( select group_id from travel_group_guide where token = '" & Request.QueryString("token") & "') "
            Else
                strProvince = strProvince & " and group_id in ( select travel_group_car.group_id from travel_group_car Inner JOIN license ON license.license_id = travel_group_car.license_id " & _
                    " where token = '" & Request.QueryString("token") & "') "
            End If
            strProvince = strProvince & ") "
            Dim dtProvince As DataTable = db.getDataTable(strProvince, "Province")
            For Each dr As DataRow In dtProvince.Rows
                Try
                    If dr("geomjson") IsNot DBNull.Value Then
                        JsProvince.Append("AddProvince([" & dr("geomjson") & "]);")
                    End If
                Catch ex As Exception

                End Try
            Next

            Dim str As String = " select id_location , lat , lon , date_time , typecar_id , wrong_way " & _
            " from vmaplocation where token = '" & Request.QueryString("token") & "' "
            If ddlStatus.SelectedValue = 1 Then
                'อยู่ในเส้นทาง
                str = str & " and wrong_way = 0 "
            ElseIf ddlStatus.SelectedValue = 2 Then
                'ออกนอกเส้นทาง
                str = str & " and wrong_way = 1 "
            End If
            Dim Dt As DataTable = db.getDataTable(str, "Form2")
            For Each dr As DataRow In Dt.Rows
                Try
                    Dim xy As String = dr("lon") & "," & dr("lat")
                    Dim typecar_id As Integer = 0
                    If Not dr("typecar_id") Is DBNull.Value Then
                        typecar_id = dr("typecar_id")
                    End If
                    Dim txtpopup = "-"
                    If dr("wrong_way") = "1" Then
                        JsMarkerCar = JsMarkerCar & " AddMarkerCar(" & xy & ",'" & txtpopup & "'," & typecar_id & ",'R'," & dr("id_location") & "); "
                    Else
                        JsMarkerCar = JsMarkerCar & " AddMarkerCar(" & xy & ",'" & txtpopup & "'," & typecar_id & ",''," & dr("id_location") & "); "
                    End If
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        Finally
            db = Nothing
        End Try
        If Page.IsPostBack = False Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", "  addMap(); " & JsMarkerCar & Popup & JsProvince.ToString & " ZoomLayerGroup(); ", True)
        ElseIf IsClickPopup Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", " RemoveLayerGroup(); " & JsMarkerCar & Popup & JsProvince.ToString & " document.getElementById('HidMarkerIB').value = '';  ZoomLayerGroup(); " & _
                                                 IIf(Request.QueryString("IsTest") = 1, "alert('test'); ", ""), True)
        Else
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "UpdatePage", " RemoveLayerGroup(); " & JsMarkerCar & Popup & JsProvince.ToString & " ZoomLayerGroup(); ", True)

        End If
    End Sub

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        loadMap(False)
    End Sub
End Class
