<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Document_1.aspx.vb" Inherits="Document_1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <center>
<div class="w3-card-4 w3-margin w3-white " style="max-width:1050px">
  
  <div>
<form id="form1" runat="server" >
<%--   <div class="w3-container w3-padding-16 w3-grey2">
        <div class="w3-left w3-text-white ">
              <asp:Label ID="lblhead" runat="server" Text="Label"></asp:Label>
        </div>
        
         <div class="w3-right ">
                <asp:Button class="w3-button w3-grey w3-hover-black w3-padding-4 w3-text-white" ID="BtnBack" OnClientClick="showProgress()"   style="width: 120px"  runat="server"  Text="ย้อนกลับ"  />
        </div>
  </div>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <br />
                        
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" AsyncRendering="true" SizeToReportContent="true">
                                       <localreport reportpath="">
                    </localreport>
                    </rsweb:ReportViewer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    </div>
    </div>
      </center>
</body>
</html>
