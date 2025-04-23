<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="CompanyTravelMgt.aspx.vb" Inherits="Admin_CompanyTravelMgt" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<style>

.font_txt {
     font-size: 19px;    
}
</style>
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
           </asp:ScriptManager>

    <header class="w3-container" style="padding-top:22px">
    <h4 class="headtxt"><b> จัดการข้อมูลบริษัทท่องเที่ยว</b></h4>
</header>
 


<br />


<div class="container col-12 bg__white pt-5 pl-5 log-in--container position-relative">

    <div class="row mt-5 mr-5">
            <div class="col-sm">

  <div class="form-row">
  <div class="form-group ml-5 col-12 col-md-5 col-lg-5">
   <label>ชื่อบริษัทท่องเที่ยวภาษาไทย : </label>
      <asp:TextBox ID="txtcompany_nameth" class="form-control font_txt" runat="server"></asp:TextBox>
    </div>
      <div class="form-group ml-5 col-12 col-md-5 col-lg-5 ">
     <label>ชื่อบริษัทท่องเที่ยวภาษาอังกฤษ : </label>
      <asp:TextBox ID="txtcompany_nameen" class="form-control font_txt" runat="server"></asp:TextBox>
    </div>
  </div>

  <div class="form-row"  style="DISPLAY: none">
  <div class="form-group ml-5 col-12 col-md-5 col-lg-5">
   <label>เลขที่ใบอนุญาต : </label>
       <asp:TextBox ID="txtcompany_license" class="form-control font_txt"  runat="server"></asp:TextBox> 
    </div>
      <div class="form-group ml-5 col-12 col-md-6 col-lg-6 ">
     <label>รายละเอียดบริษัท : </label>
     <asp:TextBox ID="txtinfo_company" class="form-control font_txt" runat="server"></asp:TextBox> 
       
    </div>
  </div>
            
            <div class="form-row">
  <div class="form-group ml-5 col-12 col-md-5 col-lg-5">
   <label>ที่อยู่ : </label>
       <asp:TextBox ID="txtaddress" class="form-control font_txt"  runat="server"></asp:TextBox> 
    </div>
      <div class="form-group ml-5 col-12 col-md-6 col-lg-6 ">
     <label>จังหวัด : </label>
     <asp:DropDownList id="ddlPro"  class="w3-input w3-border w3-round-large  font_txt" AutoPostBack="true" runat="server" AppendDataBoundItems="True" Width="200px" ></asp:DropDownList> 
       
    </div>
  </div>

  <div class="form-row">
  <div class="form-group ml-5 col-12 col-md-5 col-lg-5">
   <label>อำเภอ : </label>
       <asp:DropDownList id="ddlAmp"  class="w3-input w3-border w3-round-large  font_txt" AutoPostBack="true" runat="server" AppendDataBoundItems="True" Width="200px" ></asp:DropDownList> 
    </div>
      <div class="form-group ml-5 col-12 col-md-6 col-lg-6 ">
     <label>ตำบล : </label>
      <asp:DropDownList id="ddlTum"  class="w3-input w3-border w3-round-large  font_txt" runat="server" AppendDataBoundItems="True" Width="200px" ></asp:DropDownList> 
        
    </div>
  </div>


   <div class="form-row">
  <div class="form-group ml-5 col-12 col-md-5 col-lg-5">
   <label>รหัสไปรษณีย์ : </label>
       <asp:TextBox ID="txtpostal" class="form-control font_txt"  runat="server"></asp:TextBox> 
    </div>
     <div class="form-group ml-5 col-12 col-md-5 col-lg-5 ">
     <label>เบอร์โทร : </label>
      <asp:TextBox ID="txttelephone" class="form-control font_txt"  runat="server"></asp:TextBox> 
        
    </div>
  </div>

  <div class="form-row">
  <div class="form-group ml-5 col-12 col-md-5 col-lg-5">
   <label>Email : </label>
       <asp:TextBox ID="txtemail" class="form-control font_txt"  runat="server"></asp:TextBox> 
    </div>
      <div class="form-group ml-5 col-12 col-md-5 col-lg-5 ">
     <label>Facebook : </label>
      <asp:TextBox ID="txtfacebook" class="form-control font_txt"  runat="server"></asp:TextBox> 
        
    </div>
  </div>


   <div class="form-row">
  <div class="form-group ml-5 col-12 col-md-5 col-lg-5">
   <label>Line ID: </label>
       <asp:TextBox ID="txtline" class="form-control font_txt"  runat="server"></asp:TextBox> 
    </div>
      <div class="form-group ml-5 col-12 col-md-5 col-lg-5 ">
      
        
    </div>
  </div>

  <div class="m-5 w3-center">
  <asp:LinkButton ID="BtnBack" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-arrow-left" aria-hidden="true"></i> ยกเลิก</asp:LinkButton>
    <asp:LinkButton ID="BtnSave" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-save" aria-hidden="true"></i> บันทึก</asp:LinkButton>
  </div>
            
            </div>
    </div>

</div>


<asp:UpdateProgress ID="UpdateProgress" runat="server" >
    <ProgressTemplate>
        <div align="center" class="overlays">
            <div class="loader" ></div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

<script type="text/javascript">

    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>
</asp:Content>

