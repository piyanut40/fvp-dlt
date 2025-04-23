Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Net
Partial Class testSendEmail
    Inherits System.Web.UI.Page

    Private Send As New SendEmail
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Send.EmailSummit(txtemail.Text, txt_Name.Text, txttoken.Text, txttypename_th.Text, txtstatus.Text, txtreason.Text)
            Response.Write("Send Email Complete!!!")
        Catch ex As Exception

        End Try
    End Sub

    Dim arr_s As Array
    Dim arr_e As Array
    Dim PopulateChart As New PopulateChart
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        arr_s = txtsdate.Text.Split("/")
        arr_e = txtedate.Text.Split("/")
        Dim eyear = arr_e(2)
        'Dim _year = arr_s(2)
        Dim _categories As Object = ""
        For _year As Integer = arr_s(2) To arr_e(2)
            For i As Integer = IIf(_year = arr_s(2), arr_s(1), 1) To IIf(_year = arr_e(2), arr_e(1), 12)
                If _categories = "" Then
                    _categories = " var _categories = [ '" & PopulateChart.getMonthName(i, "th") & " " & _year.ToString & "' "
                Else
                    _categories = _categories & ", '" & PopulateChart.getMonthName(i, "th") & " " & _year.ToString & "' "
                End If
            Next
        Next

        Label1.Text = _categories
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try

            Dim myMail = New MailMessage()
            myMail.From = New MailAddress("Admin System<fvp@dlt.mail.go.th>")

            myMail.Subject = "My Subject TEST send mail from fvp"
            myMail.To.Add(New MailAddress(txtname.Text & "<" & txtmail.Text & ">"))
            'myMail.To.Add(New MailAddress("Evildada<evildada@gmail.com>"))
            'myMail.Bcc.Add(New MailAddress("BCC Nam3<maya11.mj@gmail.com>"))
            'myMail.Bcc.Add(New MailAddress("BCC Nam3<fvp@dlt.mail.go.th>"))
            myMail.IsBodyHtml = True
            myMail.BodyEncoding = System.Text.Encoding.UTF8
            myMail.Body = "My Body & <b>Description</b>  My Subject TEST send mail from fvp  My Subject TEST send mail from fvp "
            myMail.Priority = MailPriority.Low


            Dim credential = New NetworkCredential("fvp@dlt.mail.go.th", "Dlt12345678") ' User & Password
            Dim smtpClient = New SmtpClient()
            smtpClient.Port = txtport.Text ' 587
            smtpClient.UseDefaultCredentials = False
            smtpClient.Credentials = credential
            smtpClient.Host = txtsmtp.Text '"169.254.26.109"  '"127.0.0.1" '"outgoing.mail.go.th" ' SMTP
            smtpClient.EnableSsl = True
            smtpClient.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            smtpClient.Timeout = 20000
            smtpClient.Send(myMail)

            smtpClient.Dispose()
            myMail.Dispose()
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "alert('ส่งเมลสำเร็จ!');", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "alert('" & ex.Message.ToString & "');", True)
        End Try

    End Sub


    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            'ส่งหาผปก.
            EmailSummit(txtmail2.Text, txtname2.Text, "CD1ECB0F59B80CF97D2D2932FF062F08", 2, "<br / >   <li> เลขพาสปอร์ตไม่ถูกต้อง : <br / > You can review and edit your application  <a href='#'>here.</a> </li>", 1, txtname1.Text, "TEST999", "Singapore", "2019-12-01", "2019-12-20")
            'ส่งหานทท.
            EmailSummit(txtmail1.Text, txtname1.Text, "CD1ECB0F59B80CF97D2D2932FF062F08", 2, "<br / >  <br / > <li> เลขพาสปอร์ตไม่ถูกต้อง</li>", 2, txtname1.Text, "TEST999", "Singapore", "2019-12-01", "2019-12-20")

            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "alert('ส่งเมลสำเร็จ!');", True)
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScriptError", "alert('" & ex.Message.ToString & "');", True)
        End Try

    End Sub

    Private Sub EmailSummit(ByVal mailrcver As String, ByVal Name As String, ByVal token As Object, ByVal status As Integer, ByVal reason As String, ByVal typeuser As Integer _
                           , ByVal _Name As String, ByVal _plate As String, ByVal _country_car As String, ByVal _start_date As String, ByVal _exp_date As String)
        'typeuser 1= ผู้ประกอบการ 2 = นักท่องเที่ยว
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = txtsmtp1.Text
                Dim mailUser As String = "fvp@dlt.mail.go.th"
                Dim password As String = "Dlt12345678"
                Dim dbConnect As New DBConnect
                'Dim plate As String
                mail.Priority = MailPriority.Low
                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False
                'SmtpServer.Timeout = 100
                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = txtport1.Text
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    'plate = dbConnect.executeScalar("select plate from license , car WHERE license.car_id = car.car_id and license.token = '" & token & "'")
                    mail.From = New MailAddress(mailUser, " Foreign Vehicle Permit System ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8

                    Dim padmin_name As String = ""

                    Try
                        Dim strreceipt As String = "select admin_nameen from admin left join license on license.admin_id = admin.admin_id where token = '" & token & "' "
                        padmin_name = dbConnect.executeScalar(strreceipt)
                    Catch ex As Exception
                        padmin_name = ""
                    Finally
                        dbConnect = Nothing
                    End Try


                    'Dim urlQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "TrackStatus.aspx?token=" & token
                    Dim urlQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "RptApplication.aspx?token=" & token & "&rt=2"
                    Dim urlIMGQ As String = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" & urlQ.ToString.Replace("&", "%26")
                    'Dim urlIMGQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "Upload/QRCode/" & token & ".png"

                    Dim url As String = "<a href='" & urlQ & "'> click here </a>"
                    Dim str_status As String = ""
                    Dim str_status_info As String = ""
                    If typeuser = 1 Then
                        If status = 1 Then
                            str_status = "FVP Application for " & _plate & " of " & _Name & " has been approved."
                            str_status_info = "FVP Application for " & _plate & " " & _country_car & " valid from " & Format(CDate(_start_date), "MM/dd/yyyy") & " to " & Format(CDate(_exp_date), "MM/dd/yyyy") & " of " & _Name & " has been approved."
                        ElseIf status = 3 Then
                            str_status = "FVP Application for " & _plate & " of " & _Name & " has been approved , but Compulsory motor insurance is required."
                            str_status_info = "FVP Application for " & _plate & " " & _country_car & " valid from " & Format(CDate(_start_date), "MM/dd/yyyy") & " to " & Format(CDate(_exp_date), "MM/dd/yyyy") & " of " & _Name & " has been approved , but Compulsory motor insurance is required."
                        ElseIf status = 7 Then
                            str_status = "FVP Application for " & _plate & " of " & _Name & " has expired."
                            str_status_info = "FVP Application for " & _plate & " " & _country_car & " valid from " & Format(CDate(_start_date), "MM/dd/yyyy") & " to " & Format(CDate(_exp_date), "MM/dd/yyyy") & " of " & _Name & " has expired due to failure to complete the application 5 business days prior to the date pf entry.<br/>The list of incompletions are as follow;"
                        Else
                            str_status = "FVP Application for " & _plate & " of " & _Name & " is incomplete."
                            str_status_info = "FVP Application for " & _plate & " " & _country_car & " period of use from " & Format(CDate(_start_date), "MM/dd/yyyy") & " to " & Format(CDate(_exp_date), "MM/dd/yyyy") & " of " & _Name & " has been rejected"
                        End If
                    ElseIf typeuser = 2 Then
                        If status = 1 Then
                            str_status = "FVP Application for " & _plate & " has been approved."
                            str_status_info = "Your application for " & _plate & " " & _country_car & " valid from " & Format(CDate(_start_date), "MM/dd/yyyy") & " to " & Format(CDate(_exp_date), "MM/dd/yyyy") & " has been approved."
                        ElseIf status = 3 Then
                            str_status = "FVP Application for " & _plate & " has been approved , but Compulsory motor insurance is required."
                            str_status_info = "Your application for " & _plate & " " & _country_car & " valid from " & Format(CDate(_start_date), "MM/dd/yyyy") & " to " & Format(CDate(_exp_date), "MM/dd/yyyy") & " has been approved , but Compulsory motor insurance is required."
                        ElseIf status = 7 Then
                            str_status = "FVP Application for " & _plate & " has expired."
                            str_status_info = "Your application for " & _plate & " " & _country_car & " valid from " & Format(CDate(_start_date), "MM/dd/yyyy") & " to " & Format(CDate(_exp_date), "MM/dd/yyyy") & " has expired because of failure to complete the application 5 business days prior to the date pf entry.<br/>The list of incompletions are as follow;"
                        Else
                            str_status = "FVP Application for " & _plate & " is incomplete."
                            str_status_info = "Your application for " & _plate & " " & _country_car & " period of use from " & Format(CDate(_start_date), "MM/dd/yyyy") & " to " & Format(CDate(_exp_date), "MM/dd/yyyy") & " is incomplete."
                        End If
                    End If

                    mail.Subject = "[FVP] " & str_status
                    mail.IsBodyHtml = True
                    mail.Body = "<br>Dear&nbsp; " & Name & " <br><br> "

                    'If reason <> "" Then
                    If typeuser = 1 Then
                        mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " & str_status_info & IIf(status = 1 Or status = 3, "<br/>", IIf(reason.Trim = "", "", IIf(status = 7, " <br/>  " & reason & ". <br/>", " <br/><br/> The guidelines to edit your application are also attached herewith. " & reason & ". <br/>"))) '& _
                    ElseIf typeuser = 2 Then
                        mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " & str_status_info & IIf(status = 1 Or status = 3, "<br/>", IIf(status = 7, IIf(reason.Trim = "", "", " <br/>  " & reason & ". <br/>"), "<br/><br/> Please contact your travel agency to review details of your application.<br/>")) '& _
                    End If

                    If status = 1 Then
                        mail.Body = mail.Body & "  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; You can contact " & padmin_name & " to make payment and pick up Foreign Vehicle permit (FVP).Please prepare the following set of documents when contacting the land transport office; <br/>" & _
                        "  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.	Application form printed from FVP system " & url & "<br/>" & _
                        "  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2.	National identificationcard or certificate of juristic person registration issued by Department of Business Development (DBD) <br/>" & _
                        "  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3.	Certified photocopy of tourism business license issued by Department of Tourism (DOT) <br/>" & _
                        "  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4.	Power of Attorney (if applicable) <br/>" & _
                        "  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Last date to make payment and pick up FVP is " & Format(CDate(_start_date), "MM/dd/yyyy") & ". Failure to contact the specified land transport office by the " & Format(CDate(_start_date), "MM/dd/yyyy") & " will result in application expiration.<br/>"
                    ElseIf status = 2 Then
                        If typeuser = 1 Then
                            mail.Body = mail.Body & "  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Please be informed that the application shall be completed <u>5 business days prior to the date of entry</u>.<br/> Failure to do so will result in application expiration. <br/>"
                        ElseIf typeuser = 2 Then
                            mail.Body = mail.Body & "  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Also, please be informed that the application shall be completed <u>5 business days prior to the date of entry</u>.<br/> Failure to do so will result in application expiration. <br/>"
                        End If
                    ElseIf status = 7 Then
                        If typeuser = 1 Then
                            mail.Body = mail.Body & "  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br/> This application is now no longer available to edit or resubmit. However, you can still create a new application and select a new entry date.  <br/>"
                        ElseIf typeuser = 2 Then
                            mail.Body = mail.Body & "  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br/> This application is now no longer available to edit or resubmit. Please contact your travel agency if you wish to submit a new application. <br/>"
                        End If
                    End If

                    '"  You can track your application status  " & url & ". " & IIf(status = 1 Or status = 3, "You can receive your permit at " & padmin_name & " <br/>", "")
                    If typeuser = 1 Then
                        If status = 1 Then
                            mail.Body = mail.Body & "<br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=" & urlIMGQ & "><br/>"
                        End If
                    ElseIf typeuser = 2 Then
                        mail.Body = mail.Body & "<br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; You can track your application status <a href=" & urlQ & " target=_parent > here </a>.<br>"
                        mail.Body = mail.Body & "<br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=" & urlIMGQ & "><br/>"
                    End If

                    mail.Body = mail.Body & "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards,"
                    mail.Body = mail.Body & "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FVP System Admin<br/>"
                    'End If
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                Catch ex As Exception
                    Throw ex
                Finally
                    mail.Dispose()
                    SmtpServer.Dispose()
                    dbConnect = Nothing
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
