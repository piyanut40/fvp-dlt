<%@ Page Language="VB" AutoEventWireup="false" CodeFile="checkDateLicense.aspx.vb" Inherits="API_checkDateLicense" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<form id="form2" runat="server" method="POST" action="http://fvp.dlt.go.th/api/checkDateLicense.ashx" enctype="multipart/form-data">--%>
    <form id="form2" runat="server" method="POST" action="http://localhost:15746/BorderTransport/api/checkDateLicense.ashx" enctype="multipart/form-data">
    <div>
        กรณีที่ 2 : <%--กรณีใบอนุญาตเหลือเวลาน้อยกว่า​5วันทำการแล้วยังทำเรื่องไม่เสร็จ​ และอื่นๆ --%>มี 2 เคส <br />
        1. เคลียร์ใบอนุญาตที่ไม่เรียบร้อยมี 2 กรณี คือ รอชำระเงิน และ รอซื้อพรบ. เป็นสถานะ "ไม่สำเร็จ" <br />
        2. เคลียร์ใบอนุญาตที่ เอกสารไม่สมบูรณ์ เป็นสถานะ "ไม่สำเร็จ" ก่อนหน้า 5 วันทำการ พร้อมแจ้งเตือน Email <br />
        <input type="submit" value="Submit" />
    </div>
    </form>
</body>
</html>
