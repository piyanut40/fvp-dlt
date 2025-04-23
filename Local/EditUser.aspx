<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditUser.aspx.vb" MasterPageFile="~/MasterPageC.master" Inherits="EditUser" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <header class="w3-container" style="padding-top:22px">
    <h3><b>Change your password</b></h3>
</header>
 

<br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <script>

       function passoldnottrue() {
           alert('Current password incorrect');
       }
  
  </script>
   <div class="container col-12 bg__white pt-5 pl-5 log-in--container position-relative">

    <div class="row">

  <div class="container pl-0 m-4">
   <div class="row">
    <div class="col-4">
    <label>Username  : </label>
    </div>
      <div class="col-8">
      <asp:Label ID="lblUser" runat="server" Text=""><%Response.Write(Session("email"))%></asp:Label>
      </div>
    </div>  
    </div>
   <div class="container pl-0 m-4">
    <div class="row">
    <div class="col-4">
       <label>Current password : </label>
     </div>
     <div class="col-8">
        <asp:TextBox ID="txtOldPass" class="form-control" type="password" runat="server"></asp:TextBox>
     </div>

    </div> 
    </div>
     <div class="container pl-0  m-4">
    <div class="row">
    <div class="col-4">
       <label>New password : </label>
     </div>
     <div class="col-8">
        <asp:TextBox ID="txtNewPass" class="form-control" type="password" runat="server"></asp:TextBox>
     </div>

    </div> 
    </div>
     <div class="container pl-0  m-4">
    <div class="row">
    <div class="col-4">
       <label>Retype new password : </label>
     </div>
     <div class="col-8">
        <asp:TextBox ID="txtNewPassCon" class="form-control" type="password" runat="server"></asp:TextBox>
     </div>

    </div> 
    </div>





  </div>
  </div>


  <div class="m-5 w3-center">
  <asp:Button ID="Button1" class=" w3-button w3-green  w3-round-large w3-large" runat="server" Text="Save" />
  <asp:Button ID="Button2" class=" w3-button w3-red  w3-round-large  w3-large" runat="server" Text="Cancel" />
  </div>
  
</asp:Content>