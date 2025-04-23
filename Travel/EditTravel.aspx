<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditTravel.aspx.vb" MasterPageFile="~/MasterPageC.master" Inherits="EditTravel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
    <script src="../Scripts/Semantic/semantic.min.js"></script>
    <link rel="Stylesheet" type="text/css" href="../Scripts/Semantic/semantic.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/css/w3-theme-deep-purple.css" />

 <style>
 .Sidebar{z-index:3;width:300px;margin-top: 3%;}
 .h{font-size:1.7em;margin-left:0%;font-family: 'Kanit', sans-serif;color:#542A6B;}
@media screen and (min-width: 480px) and (max-width:767px) and (orientation : portrait)
{
.h{font-size:1.3em;margin-left:0%;font-family: 'Kanit', sans-serif;color:#542A6B;}
}
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
.h{font-size:1.3em;margin-left:0%;font-family: 'Kanit', sans-serif;color:#542A6B;}
}
@media screen and (min-width: 360px) and (max-width:376px) and (orientation : portrait)
{
.h{font-size:1.3em;margin-left:0%;font-family: 'Kanit', sans-serif;color:#542A6B;}
}
@media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
{
.h{font-size:1.3em;margin-left:0%;font-family: 'Kanit', sans-serif;color:#542A6B;}
}
 </style>
<header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
           <a  style="margin-left:0%"><b class="h"><i class="fa fa-pencil-square" aria-hidden="true"></i>  
           Change your password</b></a><br />
 </header>

<br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <script>

       function passoldnottrue() {
           alert('Current password incorrect');
       }
  
  </script>
 <div align="center">
   <div class="container col-12 w3-text-deep-purple w3-card-2 w3-round-large w3-theme-l5 w3-row-padding">

    <div class="w3-animate-right fill  text-dark">
    <div class="ui form w3-margin center container" style="font-family: 'Kanit', sans-serif;">
<%--  <div class="container pl-0 m-4">--%>
   <div class="two fields" style="margin-top:2rem;">

     <div class="field" style="font-family: 'Kanit', sans-serif;font-size: small;">
      <label class="w3-left">Username  : </label><br />  
      <asp:Label ID="lblUser" runat="server" Text=""><%Response.Write(Session("username"))%></asp:Label>
      </div>

      <div class="field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        <label class="w3-left">Current password  : </label><br />  
        <asp:TextBox ID="txtOldPass" class="w3-input w3-border w3-round-large" type="password" runat="server"></asp:TextBox>
     </div>

    </div>  
<%--    </div>--%>
  
 <div class="two fields" style="margin-top:2rem;">
 <div class="field" style="font-family: 'Kanit', sans-serif;font-size: small;">
   <label class="w3-left">New password  : </label><br />
   <asp:TextBox ID="txtNewPass" class="form-control" type="password" runat="server"></asp:TextBox>
 </div>
  <div class="field" style="font-family: 'Kanit', sans-serif;font-size: small;">
    <label class="w3-left">Retype new password : </label> <br />
    <asp:TextBox ID="txtNewPassCon" class="w3-input w3-border w3-round-large" type="password" runat="server"></asp:TextBox>
 </div>
 </div>

    </div>
  </div>
  <div class="m-5 w3-center">
  <asp:Button ID="Button1" class=" w3-button w3-green  w3-round-large w3-large" runat="server" Text="Save" />
  <asp:Button ID="Button2" class=" w3-button w3-red  w3-round-large  w3-large" runat="server" Text="Cancel" />
  </div>
  </div>
  </div>
  
</asp:Content>