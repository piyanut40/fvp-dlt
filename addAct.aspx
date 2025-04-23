<%@ Page Title="Foreign Vehicle Permit" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false"CodeFile="addAct.aspx.vb" Inherits="addAct" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="~/Styles/w3.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
    <link href="Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="Scripts/jquery-ui.js"></script>  
    <link href="Styles/progress-wizard.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>
    <link rel="stylesheet" href="https://www.w3schools.com/lib/w3-theme-deep-purple.css">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
           </asp:ScriptManager>


<p class=" w3-text-purple" style="font-size:1.7em;margin-left:0%"><b>แก้ไขรายละเอียดกรมธรรม์</b></p>


           
    <div align="center">
<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative w3-text-deep-purple w3-card-2 w3-round-large w3-theme-l5 w3-row-padding">          
<form >

 

<script>
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



<div id="form4" class="w3-animate-right fill text-dark">


        <div class="col-ml-2 pl-5 w3-left">
    
        <label for="name">ชื่อบริษัทกรมธรรม์ :</label>
         </div>    
        <div class="col-md-7 pb-3">
               <asp:TextBox ID="txtActCompany" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="name company" ></asp:TextBox>
        </div>


        <div class="col-ml-2 pl-5 w3-left">
          <label for="name">เลขที่กรมธรรม์ : </label>
         </div>    
        <div class="col-md-7 pb-3">
               <asp:TextBox ID="txtActNo" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="no." ></asp:TextBox>
        </div>

        <div class="col-ml-2 pl-5 w3-left">
          <label for="name">ชื่อผู้เอากรมธรรม์ : </label>
         </div>    
        <div class="col-md-7 pb-3">
               <asp:TextBox ID="txtActName" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="name" ></asp:TextBox>
        </div>

         <div class="col-ml-2 pl-5 w3-left">
          <label for="name">เลขถังรถ : </label>
         </div>    
        <div class="col-md-7 pb-3">
               <asp:TextBox ID="txtActTankNo" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="no." ></asp:TextBox>
        </div>

        <div class="col-ml-2 pl-5 w3-left">
          <label for="name">วันเริ่มต้นกรมธรรม์ : </label>
         </div>    
        <div class="col-md-7 pb-3">
               <asp:TextBox ID="txtActStart" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="start" ></asp:TextBox>
        </div>

         <div class="col-ml-2 pl-5 w3-left">
          <label for="name">วันสิ้นสุดกรมธรรม์ : </label>
         </div>    
        <div class="col-md-7 pb-3">
               <asp:TextBox ID="txtActExpire" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="end" ></asp:TextBox>
        </div>


        
           <div class="col-ml-2 pl-5 w3-left">
          <label for="name">ภาพถ่ายหนังสือกรมธรรม์ : </label>
         </div>    
        <div class="col-md-7 pb-3">
         

         
           <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload5" runat="server" onchange="document.getElementById('ContentPlaceHolder1_btnUploadAct').click();" />
            <asp:ImageButton ID="btnUploadAct" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoAct" runat="server" />
            <asp:Image ID="PhotoAct" runat="server" Height="300px" Width="400px"/>
            <asp:ImageButton ID="PhotoDeleteAct"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadAct"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
 

 <div class="pb-0">	
    <div class="ml-5 pt-5 pb-5 mb-5 pr-5">
        <asp:Button ID="btnNext4"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"  runat="server" UseSubmitBehavior=false Text="Save" />
      </div>
    </div>

</div>


 </form>     
 
</div>
    </script>

<asp:UpdateProgress ID="UpdateProgress" runat="server" >
    <ProgressTemplate>
        <div align="center" class="overlays">
            <div class="loader" ></div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

  <script type="text/javascript">


      function showProgress() {
          var updateProgress =  $get("<%= UpdateProgress.ClientID %>");
          updateProgress.style.display = "block";
      }



      function error() {

          alert("Please fill information try agian !! ");

      }


      function Submit() {
          $.confirm({
              title: 'Success',
              content: "Data save success !",
              buttons: {
                  OK: function () {
                      document.location.href = 'index.aspx';
                  }
              }
          });
      }
       
   </script>





</div>
</asp:Content>
