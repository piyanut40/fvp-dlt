<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditPassword.aspx.vb" MasterPageFile="MasterPage.master" Inherits="EditPassword" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<link rel="Stylesheet" type="text/css" href="Scripts/Semantic/semantic.min.css" />--%>
    <script src="Scripts/Semantic/semantic.min.js"></script>
    <link rel="stylesheet" href="https://www.w3schools.com/lib/w3-colors-flat.css">
    <header class="w3-container" style="padding-top:18px;">
    <center>
      <p class=" w3-text-purple" style="font-size:2rem;margin-left:0%"><b>Setting Password</b></p>
    </center>
</header>
 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <script>

       function passoldnottrue() {
           alert('รหัสผ่านเดิมไม่ถูกต้อง');
       }
  
  </script>
  <center>
   <div class=" w3-card-4 w3-round-large  w3-margin w3-padding-16 w3-container w3-flat-clouds editPassword">

    <div class="ui form w3-margin">
    <div class="eight wide field w3-margin">
    <label class=" w3-left w3-text-purple" style="font-family: 'Kanit', sans-serif;font-size: large;" >Username  : </label><br />
      <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
   
      </div>
    
 
  <%-- <div class="container pl-0 m-4">
    <div class="row">
    <div class="col-4">
       <label>Password : </label>
     </div>
     <div class="col-8">
        <asp:TextBox ID="txtOldPass" class="form-control" type="password" runat="server"></asp:TextBox>
     </div>

    </div> 
    </div>--%>
    

    <div class=" eight wide field w3-margin">
       <label class=" w3-left w3-text-purple"  style="font-family: 'Kanit', sans-serif;font-size: large;margin-top: 15px;" >Password : </label>
        <asp:TextBox ID="txtNewPass" class="form-control" type="password" runat="server"></asp:TextBox>
     </div>

    <div class="eight wide field w3-margin">
       <label class=" w3-left w3-text-purple"  style="font-family: 'Kanit', sans-serif;font-size: large;margin-top: 15px;"  >Confirm password  : </label>
        <asp:TextBox ID="txtNewPassCon" class="form-control" type="password" runat="server"></asp:TextBox>
     </div>
     <asp:HiddenField ID="hidtypeuser_id" runat=server />
  </div>
  <div class="m-5 mr-3 w3-center w3-margin w3-padding" style="margin-bottom: 20px; ">
  <asp:Button ID="Button1" class=" w3-button w3-green  w3-round-large w3-large bt" runat="server" Text="Submit" />
  <asp:Button ID="Button2" class=" w3-button w3-red  w3-round-large  w3-large bt" runat="server" Text="Cancel" />
  </div>
  </div>
  </center>
  
</asp:Content>