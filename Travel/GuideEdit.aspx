<%@ Page Title="Foreign Vehicle Permit" Language="VB" MasterPageFile="~/MasterPageC.Master" AutoEventWireup="false"CodeFile="GuideEdit.aspx.vb" Inherits="GuideEdit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <%--<link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Styles/w3.css">--%>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous" />
    <script type="text/javascript" src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <%--<link rel="stylesheet" href="~/Styles/w3.css">--%>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
    <link href="../Styles/progress-wizard.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>

    <link rel="Stylesheet" type="text/css" href="../Scripts/Semantic/semantic.min.css" />
    <script src="../Scripts/Semantic/semantic.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/css/w3-theme-deep-purple.css" />
    <link rel="stylesheet" href="../Styles/w3Home.css"/>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.9/dist/css/bootstrap-select.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

 <link rel="stylesheet" href="https://unpkg.com/leaflet@1.3.4/dist/leaflet.css"integrity="sha512-puBpdR0798OZvTTbP4A8Ix/l+A4dHDD0DGqYW6RQ+9jxkRFclaxxQb/SJAWZfWAkuyeQUytO7+7N4QKrDh+drA=="crossorigin=""/>
<script src="https://unpkg.com/leaflet@1.3.4/dist/leaflet.js"integrity="sha512-nMMmRyTVoLYqjP9hrbed9S+FzjZHW5gY1TWCHA5ckwXZBadntCNs8kEqAWdrb9O7rxbCaA4lKTIWjDXZxflOcA=="crossorigin=""></script>
<style type="text/css">
#map  
{
    height: 360px;
     width: 580px; 
     z-index:0;
 }
.topic
{
     box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
     font-size:140%;   
     color: white;text-transform: uppercase;
     padding: 14px 0 10px 49px;
     letter-spacing: 1px;
     margin-left: -8%;
     width: 330px;
    }
.PhotoAct
{
     height:200px;
            
 }
@media screen and (min-width: 1025px) and (max-width:1449px)
{
    #map
    {
        height: 360px; 
        width: 580px; 
        z-index:0;
        margin-left:-25%;
        margin-top:2%;
        
        }    
}
@media screen and (min-width: 980px) and (max-width:1024px)
{
    #map
   {
       height: 300px; 
       width: 400px; 
       z-index:0;
        margin-left:-10%;
        margin-top:2%;
       }
    
    }
@media screen and (min-width: 480px) and (max-width:767px) and (orientation : portrait)
{
   #map
   {
       height: 200px; 
       width: 200px; 
       z-index:0;
       } 
    
    .topic
{
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    font-size:80%;
    color: white;
    text-transform: uppercase;
    padding:20px;
    letter-spacing: 1px;
    margin-left: 0%;
    width: 200px;
    margin-top: -10%

    }
 }
 
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
     #map
   {
       height: 200px; 
       width: 200px; 
       z-index:0;
       }
       .topic
{
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    font-size:80%;
    color: white;
    text-transform: uppercase;
    padding:20px;
    letter-spacing: 1px;
    margin-left: 0%;
    width: 200px;
    margin-top: -10%

    }.PhotoAct
{
     height:100px;
            
 }
    
    }
 @media screen and (min-width: 360px) and (max-width:376px) and (orientation : portrait)
 {
     
     #map
   {
       height: 200px; 
       width: 200px; 
       z-index:0;
       } 
.topic
{
     box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    font-size:80%;
    color: white;
    text-transform: uppercase;
    padding:20px;
    letter-spacing: 1px;
    margin-left: 0%;
    width: 200px;
    margin-top: -10%;

    }.PhotoAct
{
     height:100px;
            
 }
     
     }
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
 {
   #map
   {
       height: 200px; 
       width: 200px; 
       z-index:0;
       } 
     .topic
{
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    font-size:80%;
    color: white;
    text-transform: uppercase;
    padding:20px;
    letter-spacing: 1px;
    margin-left: 0%;
    width: 200px;
    margin-top: -10%
    

    }.PhotoAct
{
     height:100px;
            
 }
  
  }
</style>

    <style>
  body {
      overflow-x: unset;
   
      }
  @font-face{
      font-family: 'Kanit', sans-serif;
        src : url('font/ThaiSansNeue-Regular/thaisansneue-bold-webfont.woff2');
    
    
    }
    
  </style>


    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
           <a class=" w3-text-purple" style="margin-left:0%"><b style="font-size:1.7em;margin-left:0%;font-family: 'Kanit', sans-serif;"><i class="fa fa-pencil-square" aria-hidden="true"></i>  
           Edit Tour leader or assistant</b></a><br /><br />
    </header>
      
 

 

 <div align="center">
<div class="w3-container col-8 bg__white pt-5 pb-5 pl-0 log-in--container position-relative w3-text-deep-purple w3-card-2 w3-round-large w3-theme-l5 w3-row-padding">          
<form>

       
<div id="form1" class="w3-animate-right fill center ui-form w3-margin text-dark ">


 

<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif;">
 

<div class="fields" style="margin-top:2rem;">
<div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
<%--&nbsp; &nbsp; &nbsp;--%> 
</div>
<div class="two wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">

<asp:UpdatePanel ID="Updateprename" runat="server" style="font-family: 'Kanit', sans-serif;font-size: small;">
    <ContentTemplate>
     <%--<div class="form-row">
  <div class="form-group ml-5 col-12 col-md-10 col-lg-10">--%>
            <label for="Prename" class="w3-left">Title : </label>
             <asp:DropDownList ID="ddlprename" runat="server" class="form-control font_txt" AutoPostBack="true"  Font-Size="Small"> 
            <asp:ListItem Value="Mr." Text="Mr."></asp:ListItem>
            <asp:ListItem Value="Ms." Text="Ms."></asp:ListItem>
            <asp:ListItem Value="Miss." Text="Miss."></asp:ListItem>
            <asp:ListItem Value="Mrs." Text="Mrs."></asp:ListItem>
            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
            </asp:DropDownList>  
    <%--</div>
    </div>--%>
    <asp:TextBox ID="txtPrename" Visible=false class="form-control font_txt col-4 ml-5" runat="server" placeholder="Etc."></asp:TextBox>
     </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="ddlprename" EventName="SelectedIndexChanged"/>
    </Triggers>
    </asp:UpdatePanel>

            </div>

         <div class="five wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
             <label class="w3-left"><a class="w3-text-red">*</a> Name : </label>
      <asp:TextBox ID="txtName" class="form-control font_txt" runat="server"></asp:TextBox>
        </div>

        
            
            <div class="five wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label class="w3-left"><a class="w3-text-red">*</a> Last name : </label>
      <asp:TextBox ID="txtSurname" class="form-control font_txt" runat="server"></asp:TextBox>
            </div>
        
        </div>

 


 <div class="fields" style="margin-top:2rem;">

 <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
<%--&nbsp; &nbsp; &nbsp; --%>
</div>

 <div class="twelve wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <label for="name" class="w3-left">Email :</label> <br />  
           
              <asp:TextBox ID="txtEmail" class="form-control font_txt" runat="server"></asp:TextBox>
            </div>
            </div>

 


 <div class="fields" style="margin-top:2rem;">
 <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
<%--&nbsp; &nbsp; &nbsp; --%>
</div>
            <div class="twelve wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
           <label for="Surname" class="w3-left">Telephone : </label> <br />
             <asp:TextBox ID="txtTelephone" class="form-control font_txt" runat="server"></asp:TextBox>
            </div>

            </div>

 

 <div class="fields" style="margin-top:2rem;">
 <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
<%--&nbsp; &nbsp; &nbsp; --%>
</div>
 

 <div class="twelve wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <label for="name" class="w3-left"><a class="w3-text-red">*</a> ID card :</label> <br />  
           
             <asp:TextBox ID="txtIdcard" class="form-control font_txt" runat="server"></asp:TextBox>
            </div>
            </div>

 



<div class="fields" style="margin-top:2rem;">

<div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
<%--&nbsp; &nbsp; &nbsp; --%>
</div>

 <div class="twelve wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
 <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>

           <div style="font-family: 'Kanit', sans-serif;font-size: small;">
           <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Photo of identity card : </label> <br />
          <asp:FileUpload ID="FileUpload5" runat="server" onchange="document.getElementById('MainContent_btnUploadAct').click();" />
            <asp:ImageButton ID="btnUploadAct" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoAct" runat="server" />
            <%--<asp:Image ID="PhotoAct" runat="server" Height="300px" Width="400px"/>--%>
            <asp:Image ID="PhotoAct" runat="server" CssClass="PhotoAct" /><%--Height="200px"--%>
            <asp:ImageButton ID="PhotoDeleteAct"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="~/image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
             </div>
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger  ControlID="btnUploadAct"/>
	          </Triggers>
           </asp:UpdatePanel>
 </div>
 </div>


   </br>
   <div class="<%--m-5--%> w3-container w3-center">
  <asp:LinkButton ID="BtnBack" class="w3-button w3-purple2  w3-round w3-margin" runat="server"><i class="fa fa-arrow-left" aria-hidden="true"></i> ยกเลิก</asp:LinkButton>
    <asp:LinkButton ID="BtnNext4" class="w3-button w3-purple2 w3-round w3-margin" runat="server"><i class="fa fa-save" aria-hidden="true"></i> บันทึก</asp:LinkButton>
  </div>   

</div>
       
 
    
          


      
</div>

 
</form>

</div> 



</div>
<asp:UpdateProgress ID="UpdateProgress" runat="server" >
    <ProgressTemplate>
        <div align="center" class="overlays">
            <div class="loader" ></div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
 
</asp:Content>
