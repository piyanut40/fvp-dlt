<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RegisterComplete.aspx.vb" Inherits="RegisterComplete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<center>
<div class="w3-card-4 w3-margin w3-white " style="max-width:800px">
   <div class="w3-container w3-padding-16 w3-blue2">
        <div class="w3-left ">
         You have already registered.
        </div>
  </div>

   <div class="w3-container" >   
   <div class="w3-row">
       <div class="w3-col l4 w3-padding-top w3-padding-right w3-right-align">
          Name :
        </div>
   
         <div class="w3-left  w3-padding-8 w3-padding-top w3-margin-left16">
           <asp:Label ID="lblName"  runat="server" Text=""></asp:Label>
         </div>   
  </div>

 <div class="w3-row">
       <div class="w3-col l4 w3-padding-top w3-padding-right w3-right-align ">
          Driver License No. :
        </div>
   
         <div class="w3-left  w3-padding-8 w3-padding-top w3-margin-left16">
           <asp:Label ID="lblIdcardDriver"  runat="server" Text=""></asp:Label>
         </div>   
  </div>   <div class="w3-row">
       <div class="w3-col l4 w3-padding-16 w3-padding-right w3-right-align">
            Track status :
        </div>
   
         <div class="w3-left  w3-padding-8 w3-margin-left16">
           <iframe width="100%" id="iframeQRCode" runat="server" height="178" frameborder="0" style="border:0" 
            src=""  allowfullscreen> </iframe >
         </div>   
  </div><div class="w3-row">    <div class="w3-row" >
    <br />
    <div class="w3-col l9 w3-padding-top20 ">
      <%--Please contact the administrator to approve the information.--%>
    </div>
    <div class="w3-col l2 w3-left-align w3-padding-top20 ">
         <a href="index.aspx" class="w3-button w3-blue2 w3-round" target="_parent" > <i class='fa fa-sign-in'></i> Home </a>
        </div>
     
  </div></div>

  <br/>
  </div>
 
 <br/>
</div>

 </center>

</asp:Content>

