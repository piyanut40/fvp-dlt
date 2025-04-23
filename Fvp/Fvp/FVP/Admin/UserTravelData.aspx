<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="UserTravelData.aspx.vb" Inherits="Admin_UserTravelData" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.3.4/dist/leaflet.css"integrity="sha512-puBpdR0798OZvTTbP4A8Ix/l+A4dHDD0DGqYW6RQ+9jxkRFclaxxQb/SJAWZfWAkuyeQUytO7+7N4QKrDh+drA=="crossorigin=""/>
<script src="https://unpkg.com/leaflet@1.3.4/dist/leaflet.js"integrity="sha512-nMMmRyTVoLYqjP9hrbed9S+FzjZHW5gY1TWCHA5ckwXZBadntCNs8kEqAWdrb9O7rxbCaA4lKTIWjDXZxflOcA=="crossorigin=""></script>
<link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
<style type="text/css">
#map  
{
    height: 360px;
     width: 580px; 
     z-index:0;
    /*margin-left:30%;*/
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
    }.headmenu
{
    font-size:large;    
    font-weight:bolder;
    width:100%;
}
.H
{ font-family: 'Kanit', sans-serif;
   font-size:16px;
   color:#530f87;
  
  }
.P
{ font-family: 'Kanit', sans-serif;
   font-size:15px;
  
  }

@media screen and (min-width: 1025px) and (max-width:1449px)
{
    #map
    {
        height: 360px; 
        width: 580px; 
        z-index:0;
        margin-left:25%;
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
        margin-left:-5%;
        margin-top:2%;
       }
    
    }
@media screen and (min-width: 480px) and (max-width:767px) and (orientation : portrait)
{
   #map
   {
       height: 400px; 
       width: 400px; 
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
    

    }.fontKanit
{ 
    font-family: 'Kanit', sans-serif;
  
}
  
  }
</style>

 <header class="w3-container w3-center" style="margin-top: 15px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">ข้อมูลสมาชิก/ผู้ประกอบธุรกิจนำเที่ยว</b></a><br /><br/>
</header>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<div id="formT1" runat="server">

<div id="divCompany" runat="server" class="container w3-card-2"> 
<div class="row">

 <p class="headmenu w3-padding w3-purple2 w3-xlarge" style="100%"><b><i class="fa fa-address-card-o" aria-hidden="true"></i> ข้อมูลผู้ประกอบธุรกิจนำเที่ยว</b></p>
</div>

<div class="row container w3-padding">
              <div class="col-md-4 mb-2">
                <label for="firstName" class="H"> ชื่อผู้ประกอบการ </label><br />
               <asp:Label ID="lblcom_name" runat="server" Text="" class="P"></asp:Label>
              </div>
              <div class="col-md-4 mb-2">
                <label for="lastName" class="H">ชื่อ-นามสกุล</label><br />
                <asp:Label ID="lblagen_name" runat="server" Text="" class="P"></asp:Label>
              </div>
              <div class="col-md-4 mb-2">
                <label for="lastName" class="H">หมายเลขประจำตัวประชาชน /หมายเลขนิติบุคคล</label><br />
                <asp:Label ID="lblidcard" runat="server" Text="" class="P"></asp:Label>
            </div>
</div>
<div class="row container w3-padding">
               <div class="col-md-4 mb-2">
                <label for="firstName" class="H">วันหมดอายุใบอนุญาต</label><br />
               <asp:Label ID="lblexpdate" runat="server" Text="" class="P"></asp:Label>
              </div>
              <div class="col-md-4 mb-2">
                <label for="firstName" class="H">โทรศัพท์</label><br />
                <asp:Label ID="lblcom_tel" runat="server" Text="" class="P"></asp:Label>
              </div>
              <div class="col-md-4 mb-2">
                <label for="firstName" class="H"> E-mail</label><br />
                <asp:Label ID="lblcom_mail" runat="server" Text="" class="P"></asp:Label>
              </div>
</div>
<div class="row container w3-padding">
                <div class="col-md-4 mb-2">
                <label for="firstName" class="H"> Facebook </label><br />
                <asp:Label ID="lblfacebook" runat="server" Text="" class="P"></asp:Label>
                </div>
                 <div class="col-md-4 mb-2">
                <label for="firstName" class="H"> Line ID </label><br />
                 <asp:Label ID="lblline" runat="server" Text="" class="P"></asp:Label>
                </div>
                 <div class="col-md-4 mb-2">
                <label for="firstName" class="H">เลขที่ใบอนุญาตประกอบธุรกิจนำเที่ยว</label><br />
                 <asp:Label ID="lblcompany_license" runat="server" Text="" class="P"></asp:Label>
                </div>
</div>


    <div class="container w3-padding">
        <label for="firstName" class="H"> ที่อยู่ผู้ประกอบการ  </label>
        <br />
        <asp:Label ID="lblcom_address" runat="server" Text="" class="P"></asp:Label>
     </div>


      <div class="container w3-padding">
        <label for="firstName" class="H"> ใบอนุญาต ผู้ประกอบธุรกิจนำเที่ยว  </label>
        <br />
          <asp:Image ID="license_photo" Width="300px" Height="250px" runat="server" />
          <asp:HyperLink ID="Hyperlicense_photo" runat="server">ดูรูปภาพขนาดใหญ่</asp:HyperLink>
     </div>
     
 

  <hr style=" margin-bottom : -5px;" />
 <div class="container w3-padding-16 w3-center" >
               <label for="firstName" class="H" style="font-size:20px;"> ที่อยู่ผู้ประกอบธุรกิจนำเที่ยว </label><br />
              <div id="map" class="w3-center container"></div>
               
                 
            </div>



    <asp:HiddenField ID="hidlat" runat="server" />
    <asp:HiddenField ID="hidlon" runat="server" />
  <script type="text/javascript" language="javascript">


      var maps;
      maps = L.map('map').setView([13, 100], 6);
      L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
          attribution: '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors',
          maxZoom: 20
      }).addTo(maps);
      maps.attributionControl.setPrefix(''); // Don't show the 'Powered by Leaflet' text.

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

      function Getloaction( lat , lon ) {

          L.marker([lon, lat], { icon: myIcon }).addTo(maps);
      
      }



</script>


 
  </div>
</div>
</asp:Content>

