<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtConditionrule.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="MgtConditionrule" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat=server>
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
    <link href="../Styles/progress-wizard.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>

    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/jodit/3.1.39/jodit.min.css">
    <script src="//cdnjs.cloudflare.com/ajax/libs/jodit/3.1.39/jodit.min.js"></script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.9/css/select2.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.9/js/select2.min.js"></script>

<link href="../Styles/jquery-ui-timepicker-addon.min.css" rel="stylesheet" />

<script src="../Scripts/jquery-ui-timepicker-addon.min.js"></script>
<script src="../Scripts/jquery-ui-sliderAccess.js"></script>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
           </asp:ScriptManager>
 <style>
.fontKanit
{ 
    font-family: 'Kanit', sans-serif;
  
}
</style>
 <header class="w3-container w3-center" style="padding-top:22px">
    <h3 class="headtxt w3-xlarge fontKanit"><b>จัดการข้อมูลการฝ่าฝืนเงื่อนไข</b></h3>
</header>
<br />


<div class="container col-12 bg__white pt-5 pl-5 log-in--container position-relative">

    <div class="row mt-5 mr-5">
            <div class="col-sm">

  <div class="form-row">
  <div class="form-group ml-5 col-12 col-md-6 col-lg-6">
    <label>เลขที่เครื่องหมายแสดงการใช้รถ : </label>
      <asp:DropDownList CssClass="form-control"  ID="ddlLicenseNo" runat="server">
      </asp:DropDownList>
    </div>
      <div class="form-group ml-5 col-12 col-md-4 col-lg-4 ">
    <label>วันที่ / เวลา ฝ่าฝืนเงื่อนไข : </label>
      <asp:TextBox ID="txtCond_time" class="form-control" runat="server"></asp:TextBox>
    </div>
  </div>


              

  <div class="form-row">
  <div class="form-group ml-5 col-12">
    <label>เงื่อนไขที่ฝ่าฝืน : </label>
      <asp:DropDownList ID="ddlcon" class="form-control" runat="server">
      </asp:DropDownList>
    </div>
  </div>



  <div class="form-row">
  <div class="form-group ml-5 col-12">
    <label>รายละเอียดการฝ่าฝืนเงื่อนไข : </label>
      <asp:TextBox ID="txtCond_info" class="form-control" runat="server"></asp:TextBox>
    </div>
  </div>



    <div class="form-row">
  <div class="form-group ml-5 col-12">
    <label>สถานที่ฝ่าฝืนเงื่อนไข : </label>
      <asp:TextBox ID="txtrule_name" class="form-control" runat="server"></asp:TextBox>
    </div>
  </div>





  <div class="m-5 w3-center">


  <asp:LinkButton ID="Button2" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-arrow-left" aria-hidden="true"></i> ยกเลิก</asp:LinkButton>
    <asp:LinkButton ID="Button1" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-save" aria-hidden="true"></i> บันทึก</asp:LinkButton>
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


    $("#<%=ddlLicenseNo.ClientID %>").select2();
    $("#<%=ddlcon.ClientID %>").select2();



    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }



    $(function () {
        $('#<%=txtCond_time.ClientID %>').datetimepicker({
            format: 'dd MM yy hh:mm',
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            beforeShow: function () {
                setTimeout(function () {
                    $('.ui-datepicker').css('z-index', 99999999999999);
                }, 0);
            }

        });
        $("#<%=txtCond_time.ClientID %>").keyup(function () {
            $("#<%=txtCond_time.ClientID %>").val('');
        })
      
});


</script>
    
</asp:Content>