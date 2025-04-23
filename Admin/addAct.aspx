<%@ Page Title="Foreign Vehicle Permit" Language="VB" MasterPageFile="~/MasterPageB.Master" AutoEventWireup="false"CodeFile="addAct.aspx.vb" Inherits="addAct" %>



<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">


 <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
 <script src="../Scripts/jquery-ui.js"></script>  



</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
  
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
           </asp:ScriptManager>


<p class=" w3-text-purple" style="font-size:1.7em;margin-left:0%"><b>เพิ่มรายละเอียดกรมธรรม์</b></p>

<script type="text/javascript">
    $(function () {
        $("#<%=txtActStart.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            setDate: new Date(),
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });
    });

    $(function () {
        $("#<%=txtActExpire.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "now :+20",
            setDate: new Date(),
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });
    });
</script>



<div class="container col-6 bg__white pt-5 pl-5 log-in--container position-relative">

    <div class="row mt-5 mr-5">
            <div class="col-sm">

  <div class="form-row">
  <div class="form-group ml-5 col-12 col-md-10 col-lg-10">
    <label>ชื่อบริษัทกรมธรรม์ : </label>
      <asp:TextBox ID="txtActCompany" class="form-control font_txt" runat="server"></asp:TextBox>
    </div>

    </div>


    <div class="form-row">
      <div class="form-group ml-5 col-12 col-md-10 col-lg-10">
    <label>เลขที่กรมธรรม์ : </label>
      <asp:TextBox ID="txtActNo" class="form-control font_txt" runat="server"></asp:TextBox>
    </div>
  </div>


      <div class="form-row">
      <div class="form-group ml-5 col-12 col-md-10 col-lg-10">
    <label>ชื่อผู้เอากรมธรรม์ : </label>
      <asp:TextBox ID="txtActName" class="form-control font_txt" runat="server"></asp:TextBox>
    </div>
  </div>



        <div class="form-row">
      <div class="form-group ml-5 col-12 col-md-10 col-lg-10">
    <label>วันที่เริ่มต้นกรรมธรรม์ : </label>
      <asp:TextBox ID="txtActStart" class="form-control font_txt" runat="server"></asp:TextBox>
    </div>
  </div>


  
        <div class="form-row">
      <div class="form-group ml-5 col-12 col-md-10 col-lg-10">
    <label>วันสิ้นสุดกรมธรรม์ : </label>
      <asp:TextBox ID="txtActExpire" class="form-control font_txt" runat="server"></asp:TextBox>
    </div>
  </div>


             <div class="col-ml-2 pl-5 w3-left">
          <label for="name">ภาพถ่ายหนังสือกรมธรรม์ : </label>
         </div>    
        <div class="col-md-7 pb-3">
         

         
           <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload5" runat="server" onchange="document.getElementById('MainContent_btnUploadAct').click();" />
            <asp:ImageButton ID="btnUploadAct" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoAct" runat="server" />
            <asp:Image ID="PhotoAct" runat="server" Height="300px" Width="400px"/>
            <asp:ImageButton ID="PhotoDeleteAct"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="~/image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadAct"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>

        



  <div class="m-5 w3-center">
  <asp:LinkButton ID="BtnBack" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-arrow-left" aria-hidden="true"></i> ยกเลิก</asp:LinkButton>
    <asp:LinkButton ID="BtnNext4" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-save" aria-hidden="true"></i> บันทึก</asp:LinkButton>
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


   </script>

</asp:Content>
