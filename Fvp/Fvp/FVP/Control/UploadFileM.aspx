<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UploadFileM.aspx.vb" Inherits="Control_UploadFileM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link href="../Styles/style_w3.css" type="text/css" rel="stylesheet" />
    <link href="../Scripts/Font/ThaiSansNeue-Regular/thaisansneue-regular.css" rel="stylesheet" type="text/css">--%>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway" />
    <link rel="stylesheet" href="../Styles/w3.css" />
</head>
<body >
    <form id="form1" runat="server">
        <div class="w3-container ">
        <%-- <div class="w3-container" style="max-width:500px" >--%>
            <div class="w3-left">  
                <asp:FileUpload ID="Attach" runat="server" Width="200px" />        
            </div>
            <div class="w3-right">
                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/image/photo_add.png" ValidationGroup="AddFile" />     
            </div>
            <br/><br/><br/>
            <%--</div>--%>
        </div>
    </form>
</body>
</html>
