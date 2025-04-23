<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="GuideDtl.aspx.vb" Inherits="Admin_GuideDtl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />

<style>
.fontKanit
{ font-family: 'Kanit', sans-serif;
  
}
.hr1 { 
    display: block;
    margin-top: -0.4em;
    margin-bottom: 0.5em;
    border-style: inset;
    border-width: 21x;
    margin-left: 15px;
    width: 210px;
}.conta {
  background-color:#F8F9F9;
  padding: 2rem;
  box-shadow: 4px 4px 8px rgba(0,0,0,0.1);
}.nav {
  background-color: #530f87;
  display: flex;
  align-items: center;
  justify-content:center;
  padding: 1rem;
  margin: 0 -3rem 2rem;
  box-shadow: 2px 2px 4px rgba(0,0,0,0.1);
  position: relative;
  color:White;
}

 
</style>
<header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
   <a   style="margin-left:0%"><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">Tour Guide Detail</b></a>
</header>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<div id="formT1" runat="server">
<div id="divCompany" runat="server">
  <div class="conta">

   <p class="w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-address-card-o" aria-hidden="true"></i>  Tour Guide </b></p>
      <div class="w3-row w3-padding-small">

      <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Guide Name :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblgroup_name" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>"  >
    
    </div>

  </div>

 

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
      Email :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblguide_email" runat="server" Text=""></asp:Label>

    </div>
 <div class="w3-col l2 <% Response.Write(Css)%>" >
      
     </div>
      
    
  </div>
  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
      Telephone :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblguide_tel" runat="server" Text=""></asp:Label>

    </div>
 <div class="w3-col l2 <% Response.Write(Css)%>" >
      
     </div>
      
    
  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
     ID card :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblguide_idcard" runat="server" Text=""></asp:Label>

    </div>
 <div class="w3-col l2 <% Response.Write(Css)%>" >
      
     </div>
      
    
  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
      Photo of identity card : 
     </div>
      
    <div class="w3-col l5 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>

            
          <asp:FileUpload ID="FileUpload5" runat="server" onchange="document.getElementById('MainContent_btnUploadAct').click();" />
            <asp:ImageButton ID="btnUploadAct" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoAct" runat="server" />
            <%--<asp:Image ID="PhotoAct" runat="server" Height="300px" Width="400px"/>--%>
            <asp:Image ID="PhotoAct" runat="server" Height="200px" />
             
             
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger  ControlID="btnUploadAct"/>
	          </Triggers>
           </asp:UpdatePanel>

    </div>
 
      
    
  </div>
 </div>
 </div><br />

<div class="conta" style="display:none">

   <p class="w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-address-card-o" aria-hidden="true"></i>  Registration </b></p>
      <div class="w3-row w3-padding-small">

      <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Car Registration No. :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblregis_no" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>"  >
    
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
      Car Registration Photo  :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:Image ID="Imgregis" runat="server" Width="300px" ImageUrl="#" />

    </div>
 <div class="w3-col l2 <% Response.Write(Css)%>" >
      
     </div>
      
    
  </div>
 
 </div>
 </div><br />
</div>
</div>


    <asp:HiddenField id="checkerr" runat="server"></asp:HiddenField>  
 
</asp:Content>

