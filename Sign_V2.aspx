<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Sign_V2.aspx.vb" Inherits="Sign_V2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server">
                </rsweb:ReportViewer>
                 
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
 <br />
         <br />
    </center>
    </div>
    </form>
</body>
</html>
