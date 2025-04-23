<%@ Page Language="VB" AutoEventWireup="false" CodeFile="postLocation.aspx.vb" Inherits="API_postLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

   <%-- <form id="form1" runat="server" method="POST" action="http://localhost:10505/BorderTransport/API/postLocation.ashx" enctype="multipart/form-data">--%>
    <form id="form2" runat="server" method="POST" action="http://fvp.dlt.go.th/api/postLocation.ashx" enctype="multipart/form-data">
    <div>
        lat:
        <input type="text" name="lat" value="13.723406" size="20" /><br />
        lon:
        <input type="text" name="lon" value="100.476202" size="20" /><br />
        token:
      
        <input type="text" name="token" value="21DC478177762A2E8E0DE0EA1E7FA027" size="50" /><br />
        <input type="submit" value="Submit" />
    </div>
    </form>
</body>
</html>
