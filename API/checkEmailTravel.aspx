<%@ Page Language="VB" AutoEventWireup="false" CodeFile="checkEmailTravel.aspx.vb" Inherits="API_checkEmailTravel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<form id="form2" runat="server" method="POST" action="http://fvp.dlt.go.th/api/checkEmailTravel.ashx" enctype="multipart/form-data">--%>
    <form id="form2" runat="server" method="POST" action="http://localhost:12042/BorderTransport/api/checkEmailTravel.ashx" enctype="multipart/form-data">
    <div>
        กรณีที่ 1 : กรณีใบประกอบธุรกิจนำเที่ยวของผปก.นำเที่ยวจะหมดอายุในอีก 30 วันให้ระบบแจ้งเตือนผปก.นำเที่ยวทาง E-mail <br />
        <input type="submit" value="Submit" />
    </div>
    </form>
</body>
</html>
