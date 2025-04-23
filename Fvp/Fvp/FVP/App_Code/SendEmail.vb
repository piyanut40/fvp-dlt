Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class SendEmail

    Public Sub Email(mailrcver As String, Name As String)
        'เปลี่ยนไปส่งหลังเก็บภาพ QRcode แล้ว

    End Sub

    Public Sub Email(mailrcver As String, Name As String, token As Object, typename_th As String)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                Dim dbconnect As New DBConnect
                Dim plate As String

                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False
                'SmtpServer.Timeout = 100
                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    plate = dbconnect.executeScalar("select plate from license , car WHERE license.car_id = car.car_id and license.token = '" & token & "'")
                    mail.From = New MailAddress(mailUser, " FVP " & plate & " ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8


                    Dim urlQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "TrackStatus.aspx?token=" & token
                    Dim urlIMGQ As String = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" & urlQ.ToString.Replace("&", "%26")
                    
                    mail.Subject = "[FVP] We have received your " & plate & "  "
                    mail.IsBodyHtml = True
                    'Name = "Mr. Renon Thynott"
                    mail.Body = "<br>Dear &nbsp; " & Name & " <br><br> "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; We have received your application for " & plate & " You can track your applciation status at  <a href=" & urlQ & " target=_parent > Foreign Vehicle Permit </a>  <br>"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=" & urlIMGQ & "><br>"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards, Foreign Vehicle Permit Admin<br>"
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)
                    SmtpServer.Send(mail)

                    Dim script As String = "ระบบทำการส่ง Email เรียบร้อยแล้ว"
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                    System.Console.WriteLine(script)
                Catch ex As Exception
                    Dim script As String = " alert(' ไม่สามารถส่ง Email ได้ กรุณาลองใหม่อีกครั้ง!!!'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                    System.Console.WriteLine(ex.Message)


                Finally
                    mail.Dispose()
                    SmtpServer.Dispose()
                    dbconnect = Nothing
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Email(ByVal mailrcver As String, ByVal Name As String, ByVal token As Object, ByVal plate As Object, ByVal country_car As Object, ByVal name_company As Object, ByVal company_license As Object)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                Dim dbconnect As New DBConnect
                'Dim plate As String
                mail.Priority = MailPriority.Low
                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                  
                    mail.From = New MailAddress(mailUser, " Foreign Vehicle Permit System ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8


                    Dim urlQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "TrackStatus.aspx?token=" & token
                    Dim urlIMGQ As String = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" & urlQ.ToString.Replace("&", "%26")


                    mail.Subject = "[FVP] We have received FVP application for " & plate & "  "
                    mail.IsBodyHtml = True

                    mail.Body = "<br>Dear &nbsp; " & Name & " <br><br> "

                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; We have received FVP application for your vehicle. "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; License Number: " & plate
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Country of Registration: " & country_car
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Travel Agency: " & name_company
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tourism Business License Number: " & company_license
                    mail.Body = mail.Body & "<br><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; You can track your application status <a href=" & urlQ & " target=_parent > here </a>.<br>"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=" & urlIMGQ & "><br>"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards, "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Foreign Vehicle Permit Admin<br>"
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)
                    SmtpServer.Send(mail)

                    Dim script As String = "ระบบทำการส่ง Email เรียบร้อยแล้ว"
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                    System.Console.WriteLine(script)
                Catch ex As Exception
                    Dim script As String = " alert(' ไม่สามารถส่ง Email ได้ กรุณาลองใหม่อีกครั้ง!!!'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                    System.Console.WriteLine(ex.Message)


                Finally
                    mail.Dispose()
                    SmtpServer.Dispose()
                    dbconnect = Nothing
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Email(ByVal mailrcver As String, ByVal Name As String, ByVal token As Object, ByVal plate As Object, ByVal country_car As Object, ByVal name_company As Object, ByVal company_license As Object, ByVal type As Integer)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                Dim dbconnect As New DBConnect
                'Dim plate As String
                mail.Priority = MailPriority.Low
                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                
                    mail.From = New MailAddress(mailUser, " Foreign Vehicle Permit System ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8


                    Dim urlQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "TrackStatus.aspx?token=" & token
                    Dim urlIMGQ As String = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" & urlQ.ToString.Replace("&", "%26")


                    mail.Subject = "[FVP] We have received FVP application for " & plate & "  "
                    mail.IsBodyHtml = True

                    mail.Body = "<br>Dear &nbsp; " & Name & " <br><br> "

                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; We have received FVP application for your vehicle. "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; License Number: " & plate
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Country of Registration: " & country_car
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Travel Agency: " & name_company
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tourism Business License Number: " & company_license

                    If type = 1 Then
                        mail.Body = mail.Body & "<br><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; It may take up to 3 business days to process your application."
                        mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; You can track your application status <a href=" & urlQ & " target=_parent > here </a>.<br>"
                    Else
                        mail.Body = mail.Body & "<br><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; You can track your application status <a href=" & urlQ & " target=_parent > here </a>.<br>"
                    End If
                   
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=" & urlIMGQ & "><br>"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards, "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Foreign Vehicle Permit Admin<br>"
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)
                    SmtpServer.Send(mail)

                    Dim script As String = "ระบบทำการส่ง Email เรียบร้อยแล้ว"
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                    System.Console.WriteLine(script)
                Catch ex As Exception
                    Dim script As String = " alert(' ไม่สามารถส่ง Email ได้ กรุณาลองใหม่อีกครั้ง!!!'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                    System.Console.WriteLine(ex.Message)

                Finally
                    mail.Dispose()
                    SmtpServer.Dispose()
                    dbconnect = Nothing
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub EmailSummit(ByVal mailrcver As String, ByVal Name As String, ByVal token As Object, ByVal typename_th As String)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                Dim plate As String
                Dim dbConnect As New DBConnect



                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    plate = dbConnect.executeScalar("select plate from license , car WHERE license.car_id = car.car_id and license.token = '" & token & "'")
                    mail.From = New MailAddress(mailUser, " FVP " & plate & " ", System.Text.Encoding.UTF8)

                    mail.BodyEncoding = System.Text.Encoding.UTF8
        
                    Dim padmin_name As String = ""

                    Try
                        Dim strreceipt As String = "select admin_name from admin left join license on license.admin_id = admin.admin_id where token = '" & token & "' "
                        padmin_name = dbConnect.executeScalar(strreceipt)
                    Catch ex As Exception

                    Finally
                        dbConnect = Nothing
                    End Try


                    Dim urlQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "TrackStatus.aspx?token=" & token
                    Dim urlIMGQ As String = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" & urlQ.ToString.Replace("&", "%26")

                    mail.Subject = "[FVP]   "
                    mail.IsBodyHtml = True
                    mail.Body = "<br>Dear&nbsp; " & Name & " <br><br> "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Your application has been approved " & _
                    "  You can track your application status at <a href=" & urlQ & " target=_parent >.  You can receive your permit at " & padmin_name & " <br>"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=" & urlIMGQ & "><br>"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards,"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Foreign Vehicle Permit Admin<br>"
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                    'Dim script As String = " alert('ระบบทำการส่ง Email เรียบร้อยแล้ว'); "
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

    Public Sub EmailSummit(ByVal mailrcver As String, ByVal Name As String, ByVal token As Object, ByVal typename_th As String, ByVal status As Integer, ByVal reason As String)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                Dim dbConnect As New DBConnect
                Dim plate As String

                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    plate = dbConnect.executeScalar("select plate from license , car WHERE license.car_id = car.car_id and license.token = '" & token & "'")
                    mail.From = New MailAddress(mailUser, " FVP " & plate & " ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8
                   
                    Dim padmin_name As String = ""

                    Try
                        Dim strreceipt As String = "select admin_nameen from admin left join license on license.admin_id = admin.admin_id where token = '" & token & "' "
                        padmin_name = dbConnect.executeScalar(strreceipt)
                    Catch ex As Exception

                    Finally
                        dbConnect = Nothing
                    End Try


                    Dim urlQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "TrackStatus.aspx?token=" & token
                    Dim urlIMGQ As String = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" & urlQ.ToString.Replace("&", "%26")


                    Dim url As String = "<a href='" & urlQ & "'> here </a>"
                    Dim str_status As String = ""
                    If status = 1 Then
                        str_status = "Your application has been approved."
                    ElseIf status = 3 Then
                        str_status = "Your application has been approved , but Compulsory motor insurance is required"
                    ElseIf status = 7 Then
                        str_status = "Your application has been terminated because of incomplete"
                    ElseIf status = 8 Then
                        str_status = "Your application has been canceled due to incomplete documents"
                    Else
                        str_status = "Your application has been rejected."
                    End If
                    mail.Subject = "[FVP] " & str_status
                    mail.IsBodyHtml = True
                    mail.Body = "<br>Dear&nbsp; " & Name & " <br><br> "

                    If status = 7 Then
                        mail.Body = mail.Body & "<br> &nbsp;&nbsp;&nbsp; Your application has been terminated because of incomplete documents and insufficient time to resubmit and approve the documents (less than 5 days to check-in date). "
                    End If


                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " & str_status & IIf(status = 1 Or status = 3, "", IIf(reason.Trim = "", "", "  The reason is as follows. " & reason & ". <br/>")) & _
                    "  You can track your application status  " & url & ". " & IIf(status = 1 Or status = 3, "You can receive your permit at " & padmin_name & " <br/>", "")
                    mail.Body = mail.Body & "<br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=" & urlIMGQ & "><br/>"
                    mail.Body = mail.Body & "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards,"
                    mail.Body = mail.Body & "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Foreign Vehicle Permit Admin<br/>"

                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                    'Dim script As String = " alert('ระบบทำการส่ง Email เรียบร้อยแล้ว'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
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

    Public Sub EmailSummit(ByVal mailrcver As String, ByVal Name As String, ByVal token As Object, ByVal typename_th As String, ByVal status As Integer, ByVal reason As String, ByVal typeuser As Integer, ByVal _Name As String)

        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                Dim dbConnect As New DBConnect
                Dim plate As String

                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    plate = dbConnect.executeScalar("select plate from license , car WHERE license.car_id = car.car_id and license.token = '" & token & "'")
                    mail.From = New MailAddress(mailUser, " FVP " & plate & " ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8
                   

                    Dim padmin_name As String = ""

                    Try
                        Dim strreceipt As String = "select admin_nameen from admin left join license on license.admin_id = admin.admin_id where token = '" & token & "' "
                        padmin_name = dbConnect.executeScalar(strreceipt)
                    Catch ex As Exception

                    Finally
                        dbConnect = Nothing
                    End Try


                    Dim urlQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "TrackStatus.aspx?token=" & token
                    Dim urlIMGQ As String = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" & urlQ.ToString.Replace("&", "%26")
                 
                    Dim url As String = "<a href='" & urlQ & "'> here </a>"
                    Dim str_status As String = ""
                    If typeuser = 1 Then
                        
                        If status = 1 Then
                            str_status = "FVP Application for " & plate & " has been approved."
                        ElseIf status = 3 Then
                            str_status = "FVP Application for " & plate & " has been approved , but Compulsory motor insurance is required."
                        ElseIf status = 7 Then
                            str_status = "FVP Application for " & plate & " has been terminated because of incomplete."
                        Else
                            str_status = "FVP Application for " & plate & " is incomplete."
                        End If
                    ElseIf typeuser = 2 Then
                        
                        If status = 1 Then
                            str_status = "Your application has been approved."
                        ElseIf status = 3 Then
                            str_status = "Your application has been approved , but Compulsory motor insurance is required."
                        ElseIf status = 7 Then
                            str_status = "Your application has been terminated because of incomplete."
                        Else
                            str_status = "Your application is incomplete."
                        End If
                    End If

                    mail.Subject = "[FVP] " & str_status
                    mail.IsBodyHtml = True
                    mail.Body = "<br>Dear&nbsp; " & Name & " <br><br> "

                    If status = 7 Then
                        mail.Body = mail.Body & "<br> &nbsp;&nbsp;&nbsp; Your application has been terminated because of incomplete documents and insufficient time to resubmit and approve the documents (less than 5 days to check-in date). "

                    End If


                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " & str_status & IIf(status = 1 Or status = 3, "", IIf(reason.Trim = "", "", "  The reason is as follows. " & reason & ". <br/>")) & _
                    "  You can track your application status  " & url & ". " & IIf(status = 1 Or status = 3, "You can receive your permit at " & padmin_name & " <br/>", "")
                    mail.Body = mail.Body & "<br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=" & urlIMGQ & "><br/>"
                    mail.Body = mail.Body & "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards,"
                    mail.Body = mail.Body & "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Foreign Vehicle Permit Admin<br/>"

                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                    'Dim script As String = " alert('ระบบทำการส่ง Email เรียบร้อยแล้ว'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
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

    Public Sub EmailSummit(ByVal mailrcver As String, ByVal Name As String, ByVal token As Object, ByVal typename_th As String, ByVal status As Integer, ByVal reason As String, ByVal typeuser As Integer _
                           , ByVal _Name As String, ByVal _plate As String, ByVal _country_car As String, ByVal _start_date As String, ByVal _exp_date As String)
        'typeuser 1= ผู้ประกอบการ 2 = นักท่องเที่ยว
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                Dim dbConnect As New DBConnect
                Dim plate As String
                mail.Priority = MailPriority.Low
                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    plate = dbConnect.executeScalar("select plate from license , car WHERE license.car_id = car.car_id and license.token = '" & token & "'")
                    mail.From = New MailAddress(mailUser, " Foreign Vehicle Permit System ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8
                   

                    Dim padmin_name As String = ""

                    Try
                        Dim strreceipt As String = "select admin_nameen from admin left join license on license.admin_id = admin.admin_id where token = '" & token & "' "
                        padmin_name = dbConnect.executeScalar(strreceipt)
                    Catch ex As Exception

                    Finally
                        dbConnect = Nothing
                    End Try



                    Dim urlQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "RptApplication.aspx?token=" & token & "&rt=2"
                    Dim urlIMGQ As String = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" & urlQ.ToString.Replace("&", "%26")
                    
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

                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                    'Dim script As String = " alert('ระบบทำการส่ง Email เรียบร้อยแล้ว'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
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

    Public Sub EmailCancelled(ByVal mailrcver As String, ByVal Name As String, ByVal token As Object, ByVal typeuser_id As String)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                Dim dbconnect As New DBConnect
                Dim plate As String
                mail.Priority = MailPriority.Low
                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    plate = dbconnect.executeScalar("select plate from license , car WHERE license.car_id = car.car_id and license.token = '" & token & "'")
                    mail.From = New MailAddress(mailUser, " FVP " & plate & " ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8

                    Dim urlQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "TrackStatus.aspx?token=" & token
                    Dim urlIMGQ As String = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" & urlQ.ToString.Replace("&", "%26")


                    Dim url As String = "<a href='" & urlQ & "'> here </a>"


                    mail.Subject = "[FVP] Your permit has been cancelled."
                    mail.IsBodyHtml = True
                    mail.Body = "<br>Dear&nbsp; " & Name & " <br><br> "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Your permit has been cancelled." & _
                    "  You can check your permit detail  " & url & ". "
                    mail.Body = mail.Body & "<br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=" & urlIMGQ & "><br/>"
                    mail.Body = mail.Body & "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards,"
                    mail.Body = mail.Body & "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Foreign Vehicle Permit Admin<br/>"
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                    'Dim script As String = " alert('ระบบทำการส่ง Email เรียบร้อยแล้ว'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                Catch ex As Exception
                    Throw ex
                    
                Finally
                    mail.Dispose()
                    SmtpServer.Dispose()
                    dbconnect = Nothing
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub EmailCancelled(ByVal mailrcver As String, ByVal Name As String, ByVal token As Object, ByVal typeuser_id As String, ByVal _plate As String, ByVal _country_car As String, ByVal _start_date As String, ByVal _exp_date As String)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                Dim dbconnect As New DBConnect

                mail.Priority = MailPriority.Low
                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try

                    mail.From = New MailAddress(mailUser, " Foreign Vehicle Permit System ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8

                    Dim urlQ As String = ConfigurationManager.AppSettings("UrlWebFVM") & "TrackStatus.aspx?token=" & token
                    Dim urlIMGQ As String = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" & urlQ.ToString.Replace("&", "%26")


                    Dim url As String = "<a href='" & urlQ & "'> here </a>"


                    mail.Subject = "[FVP] Your FVP for " & _plate & " has been revoked."
                    mail.IsBodyHtml = True
                    mail.Body = "<br>Dear&nbsp; " & Name & " <br><br> "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Your Foreign Vehicle Permit (FVP) for " & _plate & " " & _country_car & " valid from " & Format(CDate(_start_date), "MM/dd/yyyy") & " to " & Format(CDate(_exp_date), "MM/dd/yyyy") & " has been revoked by Department of Land Transport." & _
                    " <br/><br/> You can check your FVP status " & url & ". "
                    mail.Body = mail.Body & "<br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=" & urlIMGQ & "><br/>"
                    mail.Body = mail.Body & "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards,"
                    mail.Body = mail.Body & "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FVP System Admin<br/>"
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                    'Dim script As String = " alert('ระบบทำการส่ง Email เรียบร้อยแล้ว'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                Catch ex As Exception
                    Throw ex
                    
                Finally
                    mail.Dispose()
                    SmtpServer.Dispose()
                    dbconnect = Nothing
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub EmailRegis(ByVal mailrcver As String, ByVal Name As String, ByVal token As Object, ByVal typeuser_id As String)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                Dim dbconnect As New DBConnect
                Dim plate As String
                mail.Priority = MailPriority.Low
                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    plate = dbconnect.executeScalar("select plate from license , car WHERE license.car_id = car.car_id and license.token = '" & token & "'")
                    mail.From = New MailAddress(mailUser, " FVP " & plate & " ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8
                    

                    Dim urlpassword As String = ConfigurationManager.AppSettings("UrlWebFVM") & "EditPassword.aspx?token=" & token & "&regis=" & typeuser_id
                  
                    mail.Subject = "[FVP]   "
                    mail.IsBodyHtml = True
                    mail.Body = "<br>Dear&nbsp; " & Name & " <br><br> "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; We have received your registration"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Please activate your account and set your password <a href='" & urlpassword & "'>[here]</a> <br>"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards,"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Foreign Vehicle Permit Admin<br>"
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                    'Dim script As String = " alert('ระบบทำการส่ง Email เรียบร้อยแล้ว'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                Catch ex As Exception
                    Throw ex
                  
                Finally
                    mail.Dispose()
                    SmtpServer.Dispose()
                    dbconnect = Nothing
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub EmailTravelRegis(ByVal mailrcver As String, ByVal Name As String, ByVal agency As String, ByVal Liecense As String)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                mail.Priority = MailPriority.Low
                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    mail.From = New MailAddress(mailUser, " FVP ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8
                   

                    mail.Subject = "Request for System Registration"
                    mail.IsBodyHtml = True
                    mail.Body = "<br>Dear&nbsp; " & Name & " <br><br> "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;We have received your request for system registration. "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Travel Agency: " & agency
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;License Number: " & Liecense
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;It may take up to 2 business days to review the submitted information before your account is activated."
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If you have any question, please contact system administrator.<br><br>"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards,"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FVP System Admin<br>"

                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                    'Dim script As String = " alert('ระบบทำการส่ง Email เรียบร้อยแล้ว'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                Catch ex As Exception
                    Throw ex
                   
                Finally
                    mail.Dispose()
                    SmtpServer.Dispose()

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub EmailTravelApprove(ByVal mailrcver As String, ByVal Name As String, ByVal Agency As String, ByVal username As String)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                mail.Priority = MailPriority.Low
                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    mail.From = New MailAddress(mailUser, " FVP ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8
                    
                    Dim urllogin As String = ConfigurationManager.AppSettings("UrlWebFVM") & "/Login.aspx"
                    Dim urlManual2 As String = ConfigurationManager.AppSettings("UrlWebFVM") & "Manual2.aspx"
                    Dim urlManual As String = ConfigurationManager.AppSettings("UrlWebFVM") & "Manual.aspx"
                   

                    mail.Subject = "Your account has been activated.   "
                    mail.IsBodyHtml = True
                    mail.Body = "<br>Dear&nbsp; " & Name & " <br><br> "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Your FVP account for  " & Agency & " has been activated."
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You can now log in and create application for Foreign Vehicle Permit (FVP).<br>"

                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Before proceeding to create your application, please look into the current regulation on "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreign vehicle and application criteria <a href='" & urlManual2 & "'>[here]</a>"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Guideline on how to use FVP system can also be found  <a href='" & urlManual & "'>[here]</a>"

                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards,"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Foreign Vehicle Permit Admin<br>"
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                    'Dim script As String = " alert('ระบบทำการส่ง Email เรียบร้อยแล้ว'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                Catch ex As Exception
                    Throw ex
                    
                Finally
                    mail.Dispose()
                    SmtpServer.Dispose()
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub EmailTravelCancel(ByVal mailrcver As String, ByVal Name As String, ByVal Agency As String, ByVal username As String)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                mail.Priority = MailPriority.Low
                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    mail.From = New MailAddress(mailUser, " FVP ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8
                  
                    Dim urllogin As String = ConfigurationManager.AppSettings("UrlWebFVM") & "/Login.aspx"


                    mail.Subject = "[FVP]   "
                    mail.IsBodyHtml = True
                    mail.Body = "<br>Dear&nbsp; " & Name & " <br><br> "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Your agency " & Agency & " has been cancel "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards,"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Foreign Vehicle Permit Admin<br>"
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                    'Dim script As String = " alert('ระบบทำการส่ง Email เรียบร้อยแล้ว'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                Catch ex As Exception
                    Throw ex
                   
                Finally
                    mail.Dispose()
                    SmtpServer.Dispose()
                End Try
            End If

        Catch ex As Exception

        Finally


        End Try
    End Sub

    Public Sub EmailTravelNotification(ByVal mailrcver As String, ByVal Name As String, ByVal Agency As String, ByVal username As String)
        Try
            If mailrcver = "" Then
                'Dim script As String = " alert('กรุณาระบุ Email'); "
                'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
            Else
                Dim mail As New MailMessage()

                Dim SmtpServer As New SmtpClient()
                Dim pHost As String = ConfigurationManager.AppSettings("SmtpServer")
                Dim mailUser As String = ConfigurationManager.AppSettings("MailServer")
                Dim password As String = ConfigurationManager.AppSettings("MailPassword")
                mail.Priority = MailPriority.Low
                SmtpServer.EnableSsl = True
                SmtpServer.UseDefaultCredentials = False

                SmtpServer.Credentials = New Net.NetworkCredential(mailUser, password)
                SmtpServer.Port = ConfigurationManager.AppSettings("MailPort")
                SmtpServer.Host = pHost
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                mail = New MailMessage()
                mail.To.Add(mailrcver)
                Try
                    mail.From = New MailAddress(mailUser, " FVP ", System.Text.Encoding.UTF8)
                    mail.BodyEncoding = System.Text.Encoding.UTF8
                   
                    Dim urllogin As String = ConfigurationManager.AppSettings("UrlWebFVM") & "/Login.aspx"


                    mail.Subject = "[FVP]   "
                    mail.IsBodyHtml = True
                    mail.Body = "<br>Dear&nbsp; " & Name & " <br><br> "
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Your agency " & Agency & " has been would like to inform you that  Your tourism license will be expired in 30 days. "
                    mail.Body = mail.Body & "<br><br><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Best Regards,"
                    mail.Body = mail.Body & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Foreign Vehicle Permit Admin<br>"
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    mail.ReplyTo = New MailAddress(mailrcver)

                    SmtpServer.Send(mail)

                    'Dim script As String = " alert('ระบบทำการส่ง Email เรียบร้อยแล้ว'); "
                    'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AlertScript", script, True)
                Catch ex As Exception
                    Throw ex
                    
                Finally
                    mail.Dispose()
                    SmtpServer.Dispose()
                End Try
            End If

        Catch ex As Exception

        Finally


        End Try
    End Sub
End Class
