<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RptApplication.aspx.vb" Inherits="RptApplication" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>

    <center>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <br />
                <rsweb:ReportViewer ID="ReportViewer1" runat="server">
                </rsweb:ReportViewer>
                 <%--       
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server"  InteractiveDeviceInfos="(Collection)" 
                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" AsyncRendering="true" SizeToReportContent="true">
                                       <localreport reportpath="">
                    </localreport>
                    </rsweb:ReportViewer>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
 <br />
         <br />
    </center>
</asp:Content>

