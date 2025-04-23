<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="LoadDatabase.aspx.vb" Inherits="LoadDatabase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="topbar" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<br /><br />
    <center>
    <div class="w3-padding w3-border w3-round-large" style="max-width:680px">

   <div class="w3-container" >
   <br />
   <div class="w3-row" >
    <div class="w3-col l5 w3-padding-top w3-left-align ">
        &nbsp;   <b><asp:Label ID="Label2" Text="File Backup"  runat="server"></asp:Label></b>
 </div>
      
     
  </div><br />
  <div class="w3-row" >
    <div class="w3-col l5 w3-padding-top w3-padding-right w3-right-align ">
        ชื่อไฟล์ที่ต้องการดาวน์โหลด :  &nbsp;
    </div>
    <div class="w3-col l7 w3-padding-top w3-left-align ">
            &nbsp;<asp:TextBox ID="txtfileName" Text="BorderTransport_20191011_020000.zip" Width="350px" runat="server"></asp:TextBox>
    </div>
      
     
  </div>

  &nbsp;   <asp:Label ID="Label1"  runat="server"></asp:Label>

  <br />
<div class="w3-row">
    
    <div class="w3-center">
        
       &nbsp; <a href="#" class=" w3-button w3-black"  onclick="document.getElementById('ContentPlaceHolder2_BtnLoadFile').click();" > Download File .zip  </a>
      
    </div>
</div>

<br />
 
  </div>
 
</div>

</center>

<asp:Panel style="DISPLAY: none" id="PnSave" runat="server" Height="0px" __designer:wfdid="w55">
    <asp:Button ID="BtnLoadFile"  style="DISPLAY: none" class="custom-a" runat="server" OnClick="BtnLoadFile_Click"  />
</asp:Panel> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

