<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="BorderCheckMgt.aspx.vb" Inherits="Admin_BorderCheckMgt" %>

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
    <h4 class="headtxt"><b> จัดการข้อมูลด่าน</b></h4>
</header>
 


<br />


<div class="container col-10 bg__white pt-5 pl-5 log-in--container position-relative">

    <div class="row mt-5 mr-5">
            <div class="col-sm">

            <div class="form-row">
  <div class="form-group ml-5 col-12 col-md-6 col-lg-5">
    <label>ชื่อด่านภาษาไทย : </label>
      <asp:TextBox ID="txtborder_nameth" class="form-control font_txt" runat="server"></asp:TextBox>
    </div>
      <div class="form-group ml-5 col-12 col-md-4 col-lg-5 ">
    <label>ชื่อด่านภาษาอังกฤษ : </label>
      <asp:TextBox ID="txtborder_nameen" class="form-control font_txt" runat="server"></asp:TextBox>
    </div>
  </div>

 
  <div class="form-row">
  <div class="form-group ml-5 col-12 col-md-6 col-lg-5">
    <label>จังหวัด :  </label>
      <asp:DropDownList id="ddlPro"  class="w3-input w3-border w3-round-large  font_txt" runat="server" AutoPostBack="true" AppendDataBoundItems="True" ></asp:DropDownList> 
    </div>
      <div class="form-group ml-5 col-12 col-md-4 col-lg-5 ">
    <label>ประเทศที่ติดกับด่านพรมแดน : </label>
      <asp:DropDownList id="ddlcountry"  class="w3-input w3-border w3-round-large  font_txt" runat="server" AppendDataBoundItems="True" >
        <asp:ListItem Value="None" Text="None"></asp:ListItem>
        <asp:ListItem Value="Myanmar" Text="Myanmar"></asp:ListItem>
        <asp:ListItem Value="Cambodia" Text="Cambodia"></asp:ListItem>
        <asp:ListItem Value="Lao" Text="Lao"></asp:ListItem>
        <asp:ListItem Value="Malaysia" Text="Malaysia"></asp:ListItem>
         <asp:ListItem Value="Singapore" Text="Singapore"></asp:ListItem>
       </asp:DropDownList> 
    </div>
  </div>




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

<div class="form-row">
      <div class="form-group ml-5 col-12 col-md-10 col-lg-10">
    <label>ที่ตั้ง : </label>
        <div id="map"></div>



        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="form-group ml-5 col-12 col-md-4 col-lg-5 ">
        <center> Please click Map to pin  store location coordinates (<asp:Label ID="lat" runat="server" Text="0"></asp:Label>,<asp:Label ID="lon" runat="server" Text="0"></asp:Label>) </center>
        </div>
        <asp:HiddenField ID="hidlat" runat="server" />
        <asp:HiddenField ID="hidlon" runat="server" />

        <%--<asp:Field ID="lat" runat="server" />
        <asp:Field ID="long" runat="server" />--%>
        <asp:Button ID="btn1" style = "display:none" UseSubmitBehavior="false" runat="server" Text="Button" />
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
  </div>
  <center>
  <div class="m-2  w3-center ">
  <asp:LinkButton ID="BtnBack" class="w3-button w3-purple2 w3-padding w3-round w3-margin" runat="server"><i class="fa fa-arrow-left" aria-hidden="true"></i> ยกเลิก</asp:LinkButton>
    <asp:LinkButton ID="BtnSave" class="w3-button w3-purple2 w3-padding w3-round w3-margin" runat="server"><i class="fa fa-save" aria-hidden="true"></i> บันทึก</asp:LinkButton>
  </div>
   </center>        
   
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



    maps.on('click', function (e) {
        lat = e.latlng.lat;
        lon = e.latlng.lng;

        document.getElementById('MainContent_hidlat').value = lat;
        document.getElementById('MainContent_hidlon').value = lon;


        if (theMarker != undefined) {
            maps.removeLayer(theMarker);
        };

        theMarker = L.marker([lat, lon], { icon: myIcon }).addTo(maps);
        document.getElementById("<%=btn1.ClientID %>").click();
    });


    function Getloaction(lon, lat) {
        if (theMarker != undefined) {
            maps.removeLayer(theMarker);
        };
        theMarker = L.marker([lat, lon], { icon: myIcon }).addTo(maps);
        maps.setView([lat, lon], 12);
    }
</script>
</asp:Content>

