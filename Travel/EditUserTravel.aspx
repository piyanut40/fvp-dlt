<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageC.master" AutoEventWireup="false" CodeFile="EditUserTravel.aspx.vb" Inherits="Travel_EditUserTravel" %>

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

  <script type="text/javascript">
      $(function () {
          $("#<%=txtlicenseexp.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              yearRange: "now :+20",
              setDate: new Date(),
              minDate: new Date(),
              showButtonPanel: true
          });

          $("#<%=txtlicenseexp.ClientID %>").keyup(function () {
              $("#<%=txtlicenseexp.ClientID %>").val('');
          })
      });

</script>


    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
           <a class=" w3-text-purple" style="margin-left:0%"><b style="font-size:1.7em;margin-left:0%;font-family: 'Kanit', sans-serif;"><i class="fa fa-pencil-square" aria-hidden="true"></i>  
           Edit Profile</b></a><br /><br />
    </header>
     <ul class="progress-indicator" style=" margin-top:10px;">
  <li id="tab1" class="active"> <span class="bubble"></span> Personal Detail </li>
  <li id="tab2"> <span class="bubble"></span> Location Detail </li>
  <%--<li id="tab3"><span class="bubble"></span> For Login </li>--%>
</ul>
 

<script type="text/javascript">

    $(document).ready(function () {
        //tab1();

        
    });

    function tab1() {
        document.getElementById("tab1").className = "active";
        document.getElementById("tab2").className = "";
        //document.getElementById("tab3").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill pl-5";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        //document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide"
    }


    function tab2() {
        document.getElementById("tab2").className = "active";
        document.getElementById("tab1").className = "completed";
        //document.getElementById("tab3").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill pl-5";
        //document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
    }

    function tab3() {
        document.getElementById("tab1").className = "completed";
        document.getElementById("tab2").className = "completed";
        //document.getElementById("tab3").className = "active";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        //document.getElementById("form3").className = "text-dark w3-animate-right fill pl-5"
    }

 
</script>

 <div align="center">
<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative w3-text-deep-purple w3-card-2 w3-round-large w3-theme-l5 w3-row-padding">          
<form>

       
<div id="form1" class="w3-animate-right fill center ui-form w3-margin text-dark ">


 

<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif;">
 

<div class="fields" style="margin-top:2rem;">
         <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
             <label for="name" class="w3-left"> <%--<a class="w3-text-red">*</a>--%> Name :</label> <br />  
           
              <asp:TextBox ID="txtName" type="Name" class="w3-input w3-border w3-round-large" runat="server" placeholder="Name" ></asp:TextBox>
        </div>

        
            
            <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
           <label for="Surname" class="w3-left">  Surname :</label> <br />
               <asp:TextBox ID="txtSurname" type="Surname" class="w3-input w3-border w3-round-large" runat="server" placeholder="Surname"></asp:TextBox>
            </div>
        
        </div>

 <div class="fields" style="margin-top:2rem;">
        <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="name" class="w3-left"> <%--<a class="w3-text-red">*</a>--%> Agency name : </label> <br />  
           
             <asp:TextBox ID="txtCompanyName" type="Name" class="w3-input w3-border w3-round-large" runat="server" placeholder="Agency name" ></asp:TextBox>
            </div>
            <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
             <label for="Surname" class="w3-left"> <%--<a class="w3-text-red">*</a>--%> Personal ID Card : </label> <br />
                <asp:TextBox ID="txtIdcard" type="Surname" class="w3-input w3-border w3-round-large" runat="server" placeholder="Personal ID Card" ></asp:TextBox>
            </div>
   
 </div>

 <div class="fields" style="margin-top:2rem;">

 

 <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <label for="name" class="w3-left"><%--<a class="w3-text-red">*</a>--%> License expired date :</label> <br />  
           
             <asp:TextBox ID="txtlicenseexp" CssClass="w3-input w3-border w3-round-large" Type="Username" runat="server" placeholder="License expired date" ></asp:TextBox>
            </div>

            <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
           <label for="Surname" class="w3-left">Telephone : </label> <br />
             <asp:TextBox ID="txtPhone" type="Telephone" class="w3-input w3-border w3-round-large" runat="server" placeholder="Telephone"></asp:TextBox>
            </div>

            </div>

<div class="fields" style="margin-top:2rem;">
             

        <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <label for="Surname" class="w3-left"> <%--<a class="w3-text-red">*</a>--%> License no : </label> <br />
               <asp:TextBox ID="txtLiecense" type="License"  CssClass="w3-input w3-border w3-round-large" runat="server" placeholder="License no" ></asp:TextBox>
            </div> 
            
        <script type="text/javascript">
                  $("#<%=txtLiecense.ClientID %>").keyup(function () {

                      if (this.value.length == 2) {
                          this.value = this.value + '/';
                      }
                      this.setAttribute('maxlength', 8);
                  })
        
        </script>  

            <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="Surname" class="w3-left"> <%--<a class="w3-text-red">*</a>--%> Email :</label> <br />
                <asp:TextBox ID="txtEmail" type="Email" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
            </div>
 </div>

 <div class="fields" style="margin-top:2rem;">
             

        <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="Surname" class="w3-left"> Line : </label> <br />
               <asp:TextBox ID="txtLine" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Line" ></asp:TextBox>
            </div>   

            <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="Surname" class="w3-left">Facebook Link :</label> <br />
                <asp:TextBox ID="txtfacebook" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Facebook Link"></asp:TextBox> 
            </div>
 </div>

 
   <div class="fields" style="margin-top:2rem;">

   <%--<div class="w3-container w3-half w3-mobile w3-left m-5">--%>
   <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Agency License ( jpg or png and size of attached file not over 5 MB) </label> 
           <asp:UpdatePanel ID="UpdateLicense" runat="server" UpdateMode="Conditional"  CausesValidation="false"  >
           <ContentTemplate>
            <div style="font-family: 'Kanit', sans-serif;font-size: small;">
          <asp:FileUpload ID="FileUploadLicense" runat="server" onchange="document.getElementById('MainContent_btnUploadLicense').click();" />
            <asp:ImageButton ID="btnUploadLicense" style="DISPLAY: none"  runat="server" ImageUrl="../image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="true" />
               <asp:HiddenField ID="hidPhotoNameLicense" runat="server" />
            <asp:Image ID="PhotoLicense" runat="server" Height="150px" Width="200px"/>
            <asp:ImageButton ID="PhotoDeleteLicense"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />

             </div>
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense"/>
                      <asp:PostBackTrigger ControlID="PhotoDeleteLicense"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>

    </div>
  


   </br>
      <%--<asp:Button ID="btnCancel"  class=" w3-purple w3-btn w3-round-large w3-left w3-large"   runat="server" UseSubmitBehavior="false" Text="Cancel" /> &nbsp; &nbsp;&nbsp;--%>
       <asp:Button ID="btnNext2"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Next" />
      

</div>
       
 
    
          


      
</div>

 <div id="form2" class="w3-animate-right fill center ui-form w3-margin text-dark ">

 <div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif;">

 <div class="fields" style="margin-top:2rem;">
         <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
             <label for="name" class="w3-left"><%--<a class="w3-text-red">*</a>--%> Address : </label> <br />  
           
              <asp:TextBox ID="txtAddressT" Type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Address" ></asp:TextBox>
        </div>

        
            
            
        
        </div>


        <div class="fields" style="margin-top:2rem;">
         <div class="four wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        <asp:UpdatePanel ID="UpdLocation"   runat="server" UpdateMode="Conditional">
         <ContentTemplate>
         <div  style="font-family: 'Kanit', sans-serif;font-size: small;">
          <%--<div class="w3-row w3-padding-small">

            <div class="w3-col l6_0 w3-padding-top " >--%>
                <label for="name" class="w3-left">  Province :   </label>
            <%--</div>
            <div class="w3-col l5 ">--%>
                <asp:DropDownList id="ddlPro"  class="w3-input w3-border w3-round-large" AutoPostBack="true" runat="server"  AppendDataBoundItems="True" ></asp:DropDownList>                        
            <%--</div>
        </div>--%>
        <%--<div class="w3-row w3-padding-small">

            <div class="w3-col l6_0 w3-padding-top " >--%>
            <br/>
                <label for="name" class="w3-left"> Amphoe : </label>
            <%--</div>
            <div class="w3-col l5 ">--%>
                <asp:DropDownList id="ddlAmp" class="w3-input w3-border w3-round-large" AutoPostBack="true" runat="server"  AppendDataBoundItems="True" ></asp:DropDownList>                       
            <%--</div>
        </div>
        <div class="w3-row w3-padding-small">

            <div class="w3-col l6_0 w3-padding-top " >--%>
            <br/>
               <label for="name" class="w3-left">  Tumbol : </label>
            <%--</div>
            <div class="w3-col l5 ">--%>
                <asp:DropDownList id="ddlTum" class="w3-input w3-border w3-round-large" runat="server" AutoPostBack="true"  AppendDataBoundItems="True" ></asp:DropDownList>                             
           <%-- </div>
        </div>

        <div class="w3-row w3-padding-small">

            <div class="w3-col l6_0 w3-padding-top " >--%>
            <br/>
               <label for="name" class="w3-left">  <%--<a class="w3-text-red">*</a>--%>  Postal Code : </label>
            <%--</div>
            <div class="w3-col l5 ">--%>
                <asp:TextBox ID="txtPostal" type="Zipcode" class="w3-input w3-border w3-round-large" runat="server"  placeholder="Postal Code" ></asp:TextBox>                             
           <%-- </div>
        </div>--%>

         </div>

         <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdLocation">
    <ProgressTemplate>
        <div align="center" class="overlays">
            <div class="loader" ></div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
</ContentTemplate>
         
</asp:UpdatePanel>
  </div>

  <div class="three wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
   &nbsp; &nbsp; &nbsp; &nbsp;
  </div>
  <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
    <div class="w3-row-padding" >
        <div class="w3-col m12">
          <%--<div class="w3-card w3-round w3-white">--%>
            <div class="w3-container w3-padding">
              <%--<h3>Location</h3>--%>
              <div id="map"></div>
               
                 
            </div>
            <%--<center>พิกัด <asp:Label ID="lblMaplatLon" runat="server" Text="(0,0)"></asp:Label></center>--%>
            
          <%--</div>--%>
        </div>
      </div>

      <script type="text/javascript" language="javascript">

 

          

          var maps;
           
              maps = L.map('map').setView([13, 100], 6);
              L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                  attribution: '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors',
                  maxZoom: 20
              }).addTo(maps);
              maps.attributionControl.setPrefix(''); // Don't show the 'Powered by Leaflet' text.

              function Getloaction(lon, lat) {
                  if (theMarker != undefined) {
                      maps.removeLayer(theMarker);
                  };
                  theMarker = L.marker([lat, lon], { icon: myIcon }).addTo(maps);
                  maps.setView([lat, lon], 12);
              }

              maps.on('click', function (e) {
                  lat = e.latlng.lat;
                  lon = e.latlng.lng;

               
                  document.getElementById('MainContent_hidlat').value = lat;
                  document.getElementById('MainContent_hidlon').value = lon;

                

                  if (theMarker != undefined) {
                      maps.removeLayer(theMarker);
                  };

                  //Add a marker to show where you clicked.
                  theMarker = L.marker([lat, lon], { icon: myIcon }).addTo(maps);
                  document.getElementById("<%=btn1.ClientID %>").click();
              });
          

          var theMarker = {};

          function ZoomLocation(min_x, min_y, max_x, max_y) {
              if (min_y > 0) {
                  var originalLatLngs = [[min_y, min_x], [max_y, max_x]];
                  maps.fitBounds(originalLatLngs);
              }
          }

          var myIcon = L.icon({
              iconUrl: '../image/Icon2/enterprise.png',
              iconSize: [30, 30]
          });



         

           
          

</script>

      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <center> Please click Map to pin  store location coordinates (<asp:Label ID="lat" runat="server" Text="0"></asp:Label>,<asp:Label ID="lon" runat="server" Text="0"></asp:Label>) </center>
        <asp:HiddenField ID="hidlat" runat="server" />
        <asp:HiddenField ID="hidlon" runat="server" />

        
        <asp:Button ID="btn1" style = "display:none" UseSubmitBehavior="false" runat="server" Text="Button" />
    </ContentTemplate>
    </asp:UpdatePanel>
  </div>

    </div>



    <br />
<asp:Button ID="btnNext3"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Save" />
<asp:Button ID="btnPrev1" class="w3-purple w3-btn w3-round-large w3-left w3-large"  runat="server" UseSubmitBehavior="false" Text="Prev" />


 <asp:HiddenField ID="hidProv" runat="server" />
 </div>

 </div>



</form>

</div> 



</div>

 
</asp:Content>

