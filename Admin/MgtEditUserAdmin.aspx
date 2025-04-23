<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtEditUserAdmin.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="MgtEditUserAdmin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   <link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
 <style>
.fontKanit
{ 
    font-family: 'Kanit', sans-serif;
  
}
</style>
    <header class="w3-container w3-center" style="padding-top:22px">
    <h3 class="headtxt w3-xlarge fontKanit"><b><i class="fa fa-pencil-square-o" aria-hidden="true"></i>  จัดการข้อมูล USER FVP</b></h3>
</header>

<br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <script>

       function passoldnottrue() {
           alert('รหัสผ่านเดิมไม่ถูกต้อง');
       }
  
  </script>
   <div class="container w3-container col-12 bg__white pt-5 pl-5 w3-card-2  position-relative w3-round-large "><%--log-in--container--%>

    <div class="row ">

  <div class="container pl-0 m-4">
   <div class="row">
    <div class=" fontKanit col-4">
    <label>Username  : </label>
    </div>
      <div class=" fontKanit w3-medium col-8">
         <asp:TextBox ID="txtUser" class="form-control" type="username" runat="server"></asp:TextBox>
      </div>
    </div>  
    </div>
     <div class="container pl-0  m-4">
    <div class="row">
    <div class=" fontKanit col-4">
       <b>พาสเวิร์ด</b><label id="isEdit" runat="server" visible="false">ใหม่ : </label>
     </div>
     <div class=" fontKanit w3-medium col-8">
        <asp:TextBox ID="txtPass" class="form-control" type="password" runat="server"></asp:TextBox>
     </div>

    </div> 
    </div>
     <div class="container pl-0  m-4">
    <div class="row">
    <div class=" fontKanit col-4">
       <label>ยืนยันพาสเวิร์ดใหม่ : </label>
     </div>
     <div class=" fontKanit w3-medium col-8">
        <asp:TextBox ID="txtPassCon" class="form-control" type="password" runat="server"></asp:TextBox>
     </div>

    </div> 
    </div>

      <div class="container pl-0  m-4">
    <div class="row">
    <div class=" fontKanit col-4">
       <label>สำนักงานเขตขนส่ง : </label>
     </div>
     <div class=" fontKanit w3-medium col-8">
         <asp:DropDownList ID="ddlAdminName" class="form-control" runat="server"></asp:DropDownList>
     </div>

    </div> 
    </div>

        <div class="container pl-0  m-4">
    <div class="row">
    <div class=" fontKanit col-4">
       <label>  </label>
     </div>
     <div class=" fontKanit w3-medium col-8">
        
         <asp:CheckBox ID="chkIsofficer" Text=" เจ้าหน้าที่ส่วนทะเบียนรถยนต์" runat="server" />
     </div>

    </div> 
    </div>

  </div>



  <div class="m-5 w3-center">
  <asp:Button ID="Button1" class=" w3-button w3-green  w3-round-large w3-large" runat="server" Text="บันทึก" />
  <asp:Button ID="Button2" class=" w3-button w3-red  w3-round-large  w3-large" runat="server" Text="ยกเลิก" />
  </div>
    </div>
</asp:Content>