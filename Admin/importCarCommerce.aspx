<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="importCarCommerce.aspx.vb" Inherits="Admin_importCarCommerce" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Styles/datatables.min.css" rel="stylesheet">
    <script type="text/javascript" src="../Scripts/datatables.min.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <header class="w3-container" style="padding-top:22px;padding-bottom:50px; ">
    <h4 class="headtxt"><b><i class="fa fa-dashboard"></i>  <% Response.Write(text)%></b></h4>

    </header>

    <center>
    <div class="w3-padding w3-border w3-round-large" style="max-width:620px">

   <div class="w3-container" >
        
<div class="w3-row" >
    <div class="w3-col l5 w3-padding-top w3-padding-right w3-right-align ">
      ประเทศของรถ :
    </div>
    <div class="w3-col l5 w3-padding-top w3-left-align ">
         <asp:DropDownList ID="ddlCountry" class="w3-input w3-border w3-round-large" runat="server">
        </asp:DropDownList>
    </div>
     
  </div>
  <div class="w3-row" >
    <div class="w3-col l5 w3-padding-top w3-padding-right w3-right-align ">
       แนบไฟล์ Excel :
    </div>
    <div class="w3-col l5 w3-padding-top w3-left-align ">
          <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>
     
  </div>

  &nbsp;   <asp:Label ID="Label1"  runat="server"></asp:Label>

  <br />
<div class="w3-row">
    
    <div class="w3-center">
        
       &nbsp; <a href="#" class="w3-button w3-purple2 w3-padding w3-round" onclick="document.getElementById('MainContent_BtnImportExcel').click();" > นำเข้าข้อมูล </a>
       <%--<asp:HyperLink ID="hpLinkText" class="w3-button w3-purple w3-padding w3-round" runat="server" Target="_parent" > สรุปการนำเข้า </asp:HyperLink> --%> 
       <asp:HyperLink ID="hpLinkEx" NavigateUrl="../Upload/FileExcel/FileCarCommerce.xls" class="w3-button w3-purple2 w3-padding w3-round" runat="server" target="_blank" > ไฟล์ตัวอย่าง </asp:HyperLink>
    </div>
</div>

<br />
 
  </div>
 
</div>

</center>

<asp:Panel style="DISPLAY: none" id="PnSave" runat="server" Height="0px" __designer:wfdid="w55">
    <asp:Button ID="BtnImportExcel"  style="DISPLAY: none" class="custom-a" runat="server" OnClick="BtnImportExcel_Click"  />
</asp:Panel> 
</asp:Content>

