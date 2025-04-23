<%@ Page Language="VB" AutoEventWireup="false" CodeFile="QRCode.aspx.vb" Inherits="QR_CODE" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Direct Vehicle Cross Borders</title>
    <link rel="icon" href="image/logo_dlt.png">

    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="~/Styles/w3.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
 
</head>
<style>

.tabbar{
    padding : 5px;
    padding-left: 8%;
    
}


</style>
<body>
    <form class=" w3-responsive" id="form1" runat="server">
    <div class="lg-6">
    <div align="right" class=" w3-margin-right auto" style="font-size:3vw;">เลขที่เครื่องหมายแสดงการใช้รถ <%  Response.Write(check_in)%> &nbsp; <%  Response.Write(license)%> </div>
    <br><br>
   <p align="center" style="font-size:5vw;"><b>เครื่องหมายแสดงการใช้รถประจำถิ่น</b></p>
    <p align="center" style="font-size:5vw;"><b>Temporary Permit</b></p>
     <p align="center" style="font-size:5vw;"><b>วันที่ <%  Response.Write(start_date)%> - <%  Response.Write(end_date)%></b></p>
     <p align="center" style="font-size:5vw;"><b>Valid from   -  Valid Through</b></p>
  <br> <asp:Image ID="Imgcar" class="w3-margin w3-content w3-right"  runat="server" height='30%' width='30%' /><br>
    <div class="tabbar">
   <p style="font-size:4vw;">ชื่อผู้ขับ : <%  Response.Write(name_driver)%></b></p>
    <p style="font-size:4vw;">ชื่อผู้ขออนุญาต : <%  Response.Write(name_driver)%></b></p>
   <br>
   </div>
   <div class="tabbar">
      <p style="font-size:4vw;">ประเภท : <%  Response.Write(type_car)%>   ยี่ห้อ : <%  Response.Write(brands)%> </b></p>
      <p style="font-size:4vw;">แบบ : <%  Response.Write(model)%>   สี : <%  Response.Write(color)%> </b></p>
      <p style="font-size:4vw;">ท้องที่ใช้รถ : <%  Response.Write(area)%> </b></p>
      <p style="font-size:4vw;">รถประเทศ : <%  Response.Write(car_Regis)%>   เลขทะเบียน : <%  Response.Write(license_car)%> </b></p>
      
      <asp:Image ID="dlt" class="w3-margin w3-content " ImageUrl="~/image/dlt.png" runat="server" height='30%' width='30%' />
      <asp:Image ID="qrcodeImg" class="w3-margin w3-content " runat="server" height='30%' width='30%' />
   <br>
   </div>
    </div>
    </form>
</body>
</html>
