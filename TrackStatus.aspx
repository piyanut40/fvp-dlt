<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="TrackStatus.aspx.vb" Inherits="TrackStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
       <link rel="Stylesheet" type="text/css" href="Scripts/Semantic/semantic.min.css" />
    <script src="Scripts/Semantic/semantic.min.js"></script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    

<center>
<div class="w3-card-4 w3-margin w3-white  " style="max-width:1200px">

   <div class="w3-container w3-padding-16 w3-purple"> 
   <div class="w3-left" style=" font-size:1.5rem">
         Track Status
   </div>
   <br />
   <!--div class="w3-right">
 
  </div-->
  </div>
  <br />
   <div class="w3-container fill ui-form w3-responsive w3-margin" >   <div class="ui form w3-margin" > 
   <div class="fields" ><%--style="margin-top:2rem;"--%>
       <div class="four wide field column" >
         <label class="w3-left w3-text-purple " style="font-weight:bold;">Name :</label>
        </div>
        <div class="six wide field column" style="border-bottom: 1px solid black; ">
         <asp:Label ID="lblName"  runat="server" Text="" class="w3-left"></asp:Label>
        
        </div>

       <div class="three wide field column ">
         <label  class="w3-left w3-text-purple " style="font-weight:bold;"> Driver License No. :</label>
         </div>
         <div class="five wide field column" style="border-bottom: 1px solid black; ">
         <asp:Label ID="lblIdcardDriver"  runat="server" Text="" class="w3-left"></asp:Label>
        </div>
        <div class="four wide field column">
          <label class="w3-left w3-text-purple " style="font-weight:bold;">Driver License Expired Date : </label>
        </div>
        <div class="two wide field column" style="border-bottom: 1px solid black; ">
          <asp:Label ID="lblLicenseExpire"  runat="server" Text="" class="w3-left"></asp:Label>
        </div>
  </div> 
  <div class="w3-row"  style="DISPLAY: none" >
       <div class="w3-col l12 w3-padding-top w3-padding-right">
          License Driver : 
           <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload3" class="w3-button w3-round-large w3-hover-purple" runat="server" onchange="document.getElementById('ContentPlaceHolder1_btnUploadLicense1').click();" />
            <asp:ImageButton ID="btnUploadLicense1" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNameLicense" runat="server" />
            <asp:Image ID="PhotoLicense" runat="server" Height="300px" Width="400px"/>
            <asp:ImageButton ID="PhotoDeleteLicense"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense1"/>
	          </Triggers>
           </asp:UpdatePanel>
         </div>   
  </div>
  <div class="fields" >
       
         
       <div class="four wide field column" >
         <label class="w3-left w3-text-purple " style="font-weight:bold;"> Place to receive documents :</label>
         </div>
         <div class="six wide field column" style="border-bottom: 1px solid black; " >
           <asp:Label ID="lbladmin_name"  runat="server" Text="" class="w3-left"></asp:Label>
         </div>  
         
         <div class=" three wide field column">
         <label class="w3-left w3-text-purple" style="font-weight:bold;"> Type :</label>
         </div>
         <div class="five wide field column" style="border-bottom: 1px solid black; ">
           <asp:Label ID="lbltypename_en"  runat="server" Text="" class="w3-left"></asp:Label>
         </div>    
         
         <div class="four wide field column">
         <label class="w3-left w3-text-purple" style="font-weight:bold;" > Regiter date :</label>
         </div>
         <div class="two wide field column" style="border-bottom: 1px solid black; " >
           <asp:Label ID="lblregis_date"  runat="server" Text="" class="w3-left"></asp:Label>
         </div> 
  </div>


 <div class="fields" >

      
       <div class="four wide field column" >
          <label class="w3-left w3-text-purple" style="font-weight:bold;">Entry :</label>
            </div>
         <div class="six wide field column" style="border-bottom: 1px solid black; ">
           <asp:Label ID="lblborder_checkin"  runat="server" Text=""  class="w3-left"></asp:Label>
         </div>
      

    <div class=" three wide field column">
          <label class="w3-left w3-text-purple" style="font-weight:bold;">Exit :</label>
            </div>
         <div class="five wide field column" style="border-bottom: 1px solid black; ">
           <asp:Label ID="lblborder_checkout"  runat="server" Text=""  class="w3-left"></asp:Label>
         </div>   

      <div class="four wide field column">
          <label class="w3-left w3-text-purple" style="font-weight:bold;">Status :</label>
    </div>
         <div class="two wide field column" style="border-bottom: 1px solid black; " >
           <asp:Label ID="lblstatus_en"  runat="server" Text=""  class="w3-left"></asp:Label>
         </div>    
       
</div>

  <div class="fields">
        
  
       <div class="four wide field column" >
          <label class="w3-left w3-text-purple" style="font-weight:bold;">license no :</label>
             </div>
         <div class="six wide field column" style="border-bottom: 1px solid black; ">
           <asp:Label ID="lbllicense_no"  runat="server" Text=""  class="w3-left"></asp:Label>
         </div>

     <div class=" three wide field column" >
          <label class="w3-left w3-text-purple" style="font-weight:bold;">Start Date :</label>
           </div>
         <div class="five wide field column" style="border-bottom: 1px solid black; ">
           <asp:Label ID="lblstart_date"  runat="server" Text=""  class="w3-left"></asp:Label>
         </div>   

       <div class="four wide field column">
         <label class="w3-left w3-text-purple" style="font-weight:bold;"> End Date : </label>
          </div>
         <div class="two wide field column" style="border-bottom: 1px solid black; ">
           <asp:Label ID="lblexp_date"  runat="server" Text=""  class="w3-left"></asp:Label>
         </div> 

  </div>
  </div>
  </div>
  <!--Mobile-->
  <!--div class="w3-container w3-hide-medium  w3-hide" >
   <div class="w3-row mr-3" style="font-size:14px;">
       <div class="w3-col s6 w3-center " style="margin-left: -18%;">
         <b> Name :</b>
        </div>
   
         <div class="w3-col s6 w3-center" style="margin-left: -20%;">
           <asp:Label ID="lblNameM"  runat="server" Text=""></asp:Label>
         </div>   
  </div> <div class="w3-row mr-3" style="margin-left: -15%;font-size: 14px;">
       <div class="w3-col s9 " style="margin-left: -3%;">
           <b>Driver License No. :</b>
        </div>
   
            <div class="w3-col s3" style="margin-left: -80%;">
           <asp:Label ID="lblLicenseDriverM"  runat="server" Text=""></asp:Label>
         </div> 
               
  </div>    <div class="w3-row mr-3" style="font-size: 14px;">
       <div class="w3-col s9 " style="margin-left: -5%;">
         <b >Driver License Expired Date : </b>
        </div>
   
         <div class="w3-col s3" >
           <asp:Label ID="lblLicenseDriverExM"  runat="server" Text=""></asp:Label>
         </div>   
  </div>
  <div class="w3-row"  style="DISPLAY: none" >
       <div class="w3-col l4 w3-padding-top w3-padding-right <% Response.Write(Css)%> ">
          License Driver : 
        </div>
   
         <div class="w3-left  w3-padding-16 w3-padding-top w3-margin-left16">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload1" class="w3-button w3-round-large w3-hover-purple" runat="server" onchange="document.getElementById('ContentPlaceHolder1_btnUploadLicense1').click();" />
            <asp:ImageButton ID="ImageButton1" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:Image ID="Image1" runat="server" Height="300px" Width="400px"/>
            <asp:ImageButton ID="ImageButton2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense1"/>
	          </Triggers>
           </asp:UpdatePanel>
         </div>   
  </div>
  <div class="w3-row mr-3" style="font-size: 14px;">
       <div class="w3-col s3  " style="margin-left: -8%;">
          <b>Type : </b>
        </div>
         <div class="w3-col s3" style="margin-left: -5%;">
           <asp:Label ID="lblTypeM"  runat="server" Text=""></asp:Label>
         </div>  
         <div class="w3-col s5" style="margin-left: -4%;">
          <b>Regiter date : </b>
        </div>
         <div class="w3-col s3" style="margin-left: -10%;">
           <asp:Label ID="lblRegisM"  runat="server" Text=""></asp:Label>
         </div>   
  </div>


<div class="w3-row mr-3" style="font-size: 14px;">
       <div class="w3-col s9" style="margin-left: -3%;">
           <b>Place to receive documents : </b>
        </div>
   
         <div class="w3-col s9 mr-1">
           <asp:Label ID="lblReceiveM"  runat="server" Text=""></asp:Label>
         </div>   
  </div>

   <div class="w3-row mr-3" style="font-size: 14px;">
       <div class="w3-col s6 " style="margin-left: -19%;">
          <b>Status : </b>
        </div>
   
         <div class="w3-col s6" style="margin-left: -95%;">
           <asp:Label ID="lblStatusM"  runat="server" Text=""></asp:Label>
         </div>   
  </div>

  <div class="w3-row mr-3" style="font-size: 14px;margin-left: -9%;">
      <div class="w3-col s6 ">
          <b style="margin-left: -20%;">license no : </b>
       </div>
   
         <div class="w3-col s6" style="margin-left: -95%;">
           <asp:Label ID="lblLicenseNoM"  runat="server" Text=""></asp:Label>
         </div>   
  </div>

 

  <div class="w3-row mr-3" style="font-size: 14px;">
        <div class="w3-col s6"><b style="margin-left: -58%;">Check in : </b>
        </div>
         <div class="w3-col s6">
           <asp:Label ID="lblCheckinM"  runat="server" Text=""></asp:Label>
         </div>   
  </div>

  <div class="w3-row mr-3" style="font-size: 14px;margin-left: -3%;">
       <div class="w3-col s6"><b style="margin-left: -41%;">Check out : </b>
        </div>
   
         <div class="w3-col s6">
           <asp:Label ID="lblCheckOutM"  runat="server" Text=""></asp:Label>
         </div>   
  </div>

  <div class="w3-row mr-3" style="font-size: 14px;margin-left: -3%;">
       <div class="w3-col s6"><b style="margin-left: -42%;"> Start Date : </b>
        </div>
   
         <div class="w3-col s6" style="margin-left: -95%;" >
           <asp:Label ID="lblStartDateM"  runat="server" Text=""></asp:Label>
         </div>   
  </div>

  <div class="w3-row mr-3" style="font-size: 14px;margin-left: -5%;">
       <div class="w3-col s6"><b style="margin-left: -42%;"> End Date : </b></div>
   
         <div class="w3-col s6" style="margin-left: -95%;">
           <asp:Label ID="lblEndDateM"  runat="server" Text=""></asp:Label>
         </div>   
  </div>

  <br/>
  </div-->
    <asp:HiddenField ID="hidurlRenew" runat="server" />
 <br/>
 <div class="w3-container w3-padding-16 w3-purple"> 
   <div class="w3-right">
   
  <asp:Button ID="btnReapply" class=" w3-padding w3-blue w3-btn w3-round-large w3-right  mr-2 btnReapply"  runat="server" Text="Re-apply Permit" />
   <asp:Button ID="btnRenewPermit" class=" w3-padding w3-right w3-blue w3-btn w3-round-large  mr-2 btnRenewPermit "  runat="server" Text="Renew Permit" />
   <asp:HyperLink Target="_blank" ID="lnkPrint" class=" w3-padding w3-right w3-blue w3-btn w3-round-large mr-2"  runat="server" Text="Print" >Print</asp:HyperLink>
  </div>
  </div>
</div>

 </center>
</asp:Content>
 

