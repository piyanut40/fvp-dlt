<%@ Page Language="VB" AutoEventWireup="false" CodeFile="postAct.aspx.vb" Inherits="API_postAct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<form id="form1" runat="server" method="POST" action="http://localhost:17517/BorderTransport/API/postAct.ashx" enctype="multipart/form-data">--%>
    <form id="form2" runat="server" method="POST" action="https://www.thaitruckcenter.com/bordertransport/API/postAct.ashx" enctype="multipart/form-data">
    <div>
        act_no:
        <input type="text" name="act_no" value="19044782534" size="40" /><br />
        act_name:
        <input type="text" name="act_name" value="Wisara Company" size="40" /><br />
        act_tankno:
        <input type="text" name="act_tankno" value="YGN 2K-2708" size="40" /><br />
        act_start:  
        <input type="text" name="act_start" value="08/01/2019 10:30:19" size="40" /> (MM/DD/YYYY)<br />
        act_ends:
        <input type="text" name="act_ends" value="09/25/2019 18:45:19" size="40" /> (MM/DD/YYYY)<br />
         act_photo:
         <input type="file" name="act_photo" id="act_photo" size="40" /><br />
         act_company:
        <input type="text" name="act_company" value="allianz" size="40" /><br />
         token:
        <input type="text" name="token" value="DE3ABB0A6310CF0FFEDC2771B665061E" size="50" /><br />
        <input type="submit" value="Submit" />
    </div>
    </form>
</body>
</html>
