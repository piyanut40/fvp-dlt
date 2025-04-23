<%@ Page Title="Foreign Vehicle Permit" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false"CodeFile="RegisterTravel.aspx.vb" Inherits="RegisterTravel" %>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server"> 
<link rel="stylesheet" href="https://unpkg.com/leaflet@1.3.4/dist/leaflet.css"integrity="sha512-puBpdR0798OZvTTbP4A8Ix/l+A4dHDD0DGqYW6RQ+9jxkRFclaxxQb/SJAWZfWAkuyeQUytO7+7N4QKrDh+drA=="crossorigin=""/>
<script src="https://unpkg.com/leaflet@1.3.4/dist/leaflet.js"integrity="sha512-nMMmRyTVoLYqjP9hrbed9S+FzjZHW5gY1TWCHA5ckwXZBadntCNs8kEqAWdrb9O7rxbCaA4lKTIWjDXZxflOcA=="crossorigin=""></script>
<style type="text/css">
#map { height: 400px; width: 480px;}
</style>
 </asp:Content>--%>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <link href="Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="Scripts/jquery-ui.js"></script>  
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.3.4/dist/leaflet.css"integrity="sha512-puBpdR0798OZvTTbP4A8Ix/l+A4dHDD0DGqYW6RQ+9jxkRFclaxxQb/SJAWZfWAkuyeQUytO7+7N4QKrDh+drA=="crossorigin=""/>
<script src="https://unpkg.com/leaflet@1.3.4/dist/leaflet.js"integrity="sha512-nMMmRyTVoLYqjP9hrbed9S+FzjZHW5gY1TWCHA5ckwXZBadntCNs8kEqAWdrb9O7rxbCaA4lKTIWjDXZxflOcA=="crossorigin=""></script>
<style type="text/css">
#map  
{
    height: 400px;
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
     width: 470px;
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
  

  <div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative w3-text-purple font-weight-bold " style="margin-top:-2%">
   <%--<form id="id1" class="form-horizontal" align="center" runat="server">--%>
   <asp:ScriptManager ID="ScriptManager1" runat="server">
  </asp:ScriptManager>   


<script type="text/javascript">
    $(function () {
        $("#<%=txtexpdate.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "now :+20",
            setDate: new Date(),
            minDate: new Date(),
            showButtonPanel: true
        });

        $("#<%=txtexpdate.ClientID %>").keyup(function () {
            $("#<%=txtexpdate.ClientID %>").val('');
        })
    });

</script>

<p class=" w3-text-purple w3-hide-medium w3-hide-small" style="font-size:2em;margin-left:0%" align=center><b>Sign Up User for Travel Agency</b></p>
<p class=" w3-text-purple w3-hide-large" style="font-size:1.5em;margin-left:0%;margin-top:-10%" align=center><b>Sign Up User for Travel Agency</b></p>
<%--ส่วนที่ 1--%>
<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative  w3-card-2  w3-round-large " style="margin-top:3%;background-color:#F5F5F5">
         <div class="w3-row w3-padding-small " style="margin-top:-2%">
         <div class="w3-col l4 w3-padding-left100" style="padding: 48px 40px 0;width: 60%;margin-top:-2%" >
            <h1 class="topic w3-purple"><b> 1. Travel Agent Information </b></h1>
         </div>
        </div>

        <div class="w3-row-padding w3-padding w3-center">
     

        <div class="w3-container w3-half w3-mobile w3-left w3-padding">
          <label for="name" class="w3-left"> <a class="w3-text-red">*</a> Agency name : </label> <br />  
           
             <asp:TextBox ID="txtCompanyName" type="Name" class="w3-input w3-border w3-round-large" runat="server" placeholder="Agency name" ></asp:TextBox>
               
         </div>  

         <div class="w3-container w3-half w3-mobile w3-right w3-padding">
            <label for="Surname" class="w3-left"> <a class="w3-text-red">*</a> ID No. <span style=" font-size:13px">(เลขที่บัตรประชาชน/นิติบุคคล)  :</span> </label> <br />
                <asp:TextBox ID="txtIdcard" type="Surname" class="w3-input w3-border w3-round-large" runat="server" placeholder="Personal ID Card" ></asp:TextBox>
        </div>

       <%-- <div class="w3-container w3-half w3-mobile w3-left">
          <label for="name" class="w3-left"><a class="w3-text-red">*</a> Agency Travel no:</label> <br />  
           
             <asp:TextBox ID="txtAgencyNo" Type="Username" class="w3-input w3-border w3-round-large" runat="server" placeholder="Agency Travel no" ></asp:TextBox>
               
         </div>  --%>


         <div class="w3-container w3-half w3-mobile w3-right w3-padding">
            <label for="Surname" class="w3-left"> <a class="w3-text-red">*</a> Email :</label> <br />
                <asp:TextBox ID="txtEmail" type="Email" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox> 
        </div>

        <div class="w3-container w3-half w3-mobile w3-left w3-padding">
            <label for="Surname" class="w3-left"> <a class="w3-text-red">*</a> License no <span style=" font-size:13px">(เลขที่ใบอนุญาตประกอบกิจการนำเที่ยว) :</span> </label> <br />
               <asp:TextBox ID="txtLiecense" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="xx/xxxxx" ></asp:TextBox>
        </div>

          <div class="w3-container w3-half w3-mobile w3-left w3-padding">
            <label for="Surname" class="w3-left"> <a class="w3-text-red">*</a> License expired date : </label> <br />
               <asp:TextBox ID="txtexpdate" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="expired date" ></asp:TextBox>
        </div>



        <script type="text/javascript">
            $("#<%=txtLiecense.ClientID %>").keyup(function () {

                if (this.value.length == 2) {
                    this.value = this.value + '/';
                }
                this.setAttribute('maxlength', 8);
            })
        
        </script>

        <div class="w3-container w3-half w3-mobile w3-right w3-padding">
            <label for="Surname" class="w3-left">Facebook Link :</label> <br />
                <asp:TextBox ID="txtfacebook" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Facebook Link"></asp:TextBox> 
        </div>

        <div class="w3-container w3-half w3-mobile w3-left w3-padding">
            <label for="Surname" class="w3-left"> Line : </label> <br />
               <asp:TextBox ID="txtLine" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Line" ></asp:TextBox>
        </div>


       <div class="w3-container w3-half w3-mobile w3-left m-1 w3-padding ">
          <label for="name" class="w3-left">Agency License ( jpg or png and size of attached file not over 5 MB) </label> 
           <asp:UpdatePanel ID="UpdateLicense" runat="server" UpdateMode="Conditional"  CausesValidation="false"  >
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadLicense" runat="server" onchange="document.getElementById('ContentPlaceHolder1_btnUploadLicense').click();" />
            <asp:ImageButton ID="btnUploadLicense" style="DISPLAY: none"  runat="server" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="true" />
               <asp:HiddenField ID="hidPhotoNameLicense" runat="server" />
            <asp:Image ID="PhotoLicense" runat="server" Height="150px" Width="200px"/>
            <asp:ImageButton ID="PhotoDeleteLicense"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>



    </div>
</div>


<%--ส่วนที่ 2--%>
<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative  w3-card-2  w3-round-large " style="margin-top:3%;background-color:#F5F5F5">
         <div class="w3-row w3-padding-small" style="margin-top:-2%">
         <div class="w3-col l4 w3-padding-left100" style="padding: 48px 40px 0;width: 60%;margin-top:-2%" >
            <h1 class="topic w3-purple"><b> 2. Contact Person </b></h1>
         </div>
        </div>

        <div class="w3-row-padding w3-padding w3-center">
        <div class="w3-container w3-half w3-mobile w3-left w3-padding">
          <label for="name" class="w3-left"> <a class="w3-text-red">*</a> Name :</label> <br />  
           
              <asp:TextBox ID="txtName" type="Name" class="w3-input w3-border w3-round-large" runat="server" placeholder="Name" ></asp:TextBox>
               
         </div>  



         <div class="w3-container w3-half w3-mobile w3-right w3-padding">
            <label for="Surname" class="w3-left"><a class="w3-text-red">*</a>  Surname :</label> <br />
               <asp:TextBox ID="txtSurname" type="Surname" class="w3-input w3-border w3-round-large" runat="server" placeholder="Surname"></asp:TextBox>
        </div>


         <div class="w3-container w3-half w3-mobile w3-left w3-padding">
            <label for="Surname" class="w3-left">Telephone : </label> <br />
             <asp:TextBox ID="txtPhone" type="Telephone" class="w3-input w3-border w3-round-large" runat="server" placeholder="Telephone"></asp:TextBox>
        </div>

     </div>
</div>



<%-- ส่วนที่3--%>
<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative  w3-card-2  w3-round-large" style="margin-top:2%;background-color:#F5F5F5">

 <div class="w3-row w3-padding-small"style="margin-top:-2%">
         <div class="w3-col l4 w3-padding-left100 " style="padding: 48px 40px 0;width: 60%;margin-top:-2%"  >
            <h1 class="topic w3-purple"> <b>3. Location Detail</b> </h1>
         </div>
        </div>
<div class="w3-row-padding w3-padding">
 <div class="w3-row w3-padding-small ">

    <div class="w3-col l2_2 w3-padding-top  " >
        <a class="w3-text-red">*</a> Address : 
     </div>
      
    <div class="w3-col l8 ">
        <asp:TextBox ID="txtAddressT" Type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Address" ></asp:TextBox>
    </div>
     
      

  </div>

  <%--<br />--%>
  <div class="w3-row">
    <div class="w3-col m5">
     <asp:UpdatePanel ID="UpdLocation"   runat="server" UpdateMode="Conditional">
         <ContentTemplate>
          <div class="w3-row w3-padding-small">

            <div class="w3-col l6_0 w3-padding-top " >
              <a class="w3-text-red">*</a>  Province :
            </div>
            <div class="w3-col l5 ">
                <asp:DropDownList id="ddlPro"  class="w3-input w3-border w3-round-large" AutoPostBack="true" runat="server" AppendDataBoundItems="True" ></asp:DropDownList>                        
            </div>
        </div>
        <div class="w3-row w3-padding-small">

            <div class="w3-col l6_0 w3-padding-top " >
              <a class="w3-text-red">*</a>  Amphoe :
            </div>
            <div class="w3-col l5 ">
                <asp:DropDownList id="ddlAmp" class="w3-input w3-border w3-round-large" AutoPostBack="true" runat="server" AppendDataBoundItems="True" ></asp:DropDownList>                       
            </div>
        </div>
        <div class="w3-row w3-padding-small">

            <div class="w3-col l6_0 w3-padding-top " >
              <a class="w3-text-red">*</a>  Tumbol :
            </div>
            <div class="w3-col l5 ">
                <asp:DropDownList id="ddlTum" class="w3-input w3-border w3-round-large" runat="server" AutoPostBack="true" AppendDataBoundItems="True" ></asp:DropDownList>                             
            </div>
        </div>

        <div class="w3-row w3-padding-small">

            <div class="w3-col l6_0 w3-padding-top " >
                <a class="w3-text-red">*</a>  Postal Code :
            </div>
            <div class="w3-col l5 ">
                <asp:TextBox ID="txtPostal" type="Zipcode" class="w3-input w3-border w3-round-large" runat="server" placeholder="Postal Code" ></asp:TextBox>                             
            </div>
        </div>
         <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdLocation">
    <ProgressTemplate>
        <div align="center" class="overlays">
            <div class="loader" ></div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
</ContentTemplate>
          <%--<Triggers>
              <asp:AsyncPostBackTrigger ControlID="ddlTum" EventName="SelectedIndexChanged" />
              <asp:AsyncPostBackTrigger ControlID="ddlPro" EventName="SelectedIndexChanged" />
              <asp:AsyncPostBackTrigger ControlID="ddlAmp" EventName="SelectedIndexChanged" />
          </Triggers>--%>
</asp:UpdatePanel>

    </div>
    <div class="w3-col m5">
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


      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <center> Please click Map to pin  store location coordinates (<asp:Label ID="lat" runat="server" Text="0"></asp:Label>,<asp:Label ID="lon" runat="server" Text="0"></asp:Label>) </center>
        <asp:HiddenField ID="hidlat" runat="server" />
        <asp:HiddenField ID="hidlon" runat="server" />

        <%--<asp:Field ID="lat" runat="server" />
        <asp:Field ID="long" runat="server" />--%>
        <asp:Button ID="btn1" style = "display:none" UseSubmitBehavior="false" runat="server" Text="Button" />
    </ContentTemplate>
    </asp:UpdatePanel>

    </div>

</div>
</div>
</div>

        <asp:HiddenField ID="hidProv" runat="server" />

<%--ส่วนที่ 4--%>

<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative  w3-card-2  w3-round-large" style="margin-top:2%;background-color:#F5F5F5">

    <div class="w3-row w3-padding-small" style="margin-top:-2%">
         <div class="w3-col l4 w3-padding-left100 " style="padding: 48px 40px 0;width: 60%;margin-top:-2%"  >
            <h1 class="topic w3-purple"> <b> 4. For Login </b></h1>
         </div>
        </div>



        <div class="w3-row-padding w3-padding w3-center">
        <div class="w3-container w3-half w3-mobile w3-left w3-padding">
          <label for="name" class="w3-left"><a class="w3-text-red">*</a> Username : </label> <br />  
           
           <asp:TextBox ID="txtUsername" Type="Username" class="w3-input w3-border w3-round-large" runat="server" placeholder="Username" ></asp:TextBox>
               
         </div>  

         <div class="w3-container w3-half w3-mobile w3-right w3-padding">
            <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Password : </label> <br />
               <asp:TextBox ID="txtPassword" type="Password" class="w3-input w3-border w3-round-large" runat="server" placeholder="Password" ></asp:TextBox>
        </div>

        <div class="w3-container w3-half w3-mobile w3-left w3-padding">
          <label for="name" class="w3-left"><a class="w3-text-red">*</a> Confirm Password :  </label> <br />  
           
             <asp:TextBox ID="txtConPassword" Type="Password" class="w3-input w3-border w3-round-large" runat="server" placeholder="Confirm Password" ></asp:TextBox>
               
         </div>  


         </div>


 

  <%--<center>--%>
  
  
  <script type="text/javascript" language="javascript">


          var maps;
          maps = L.map('map').setView([13, 100], 6);
          L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
              attribution: '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors',
              maxZoom: 20
          }).addTo(maps);
          maps.attributionControl.setPrefix(''); // Don't show the 'Powered by Leaflet' text.

          var osmap = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
              attribution: '&copy; <a href="https://openstreetmap.org">OpenStreetMap</a> contributors',
              maxZoom: 20
              , attribution: "OpenStreetMap",
              apikey: 'choisirgeoportail',
              format: 'image/jpeg',
              style: 'normal'
          });
          osmap.addTo(maps);

          var longdo = L.tileLayer('https://map.doh.go.th/map/msn-server/img.php?zoom={z}&x={x}&y={y}&mode=gray&proj=epsg3857', {
              layername: 'gray', type: 'png', sphericalMercator: true,
              maxZoom:20
              , attribution: "longdo"
          });

          var google = L.tileLayer('https://mt{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}', {
              attribution: "Google",
              maxZoom:20,
              subdomains: ['1', '2', '3']
          });

          var baseMaps = {
              "Street Map": osmap,
              "Longdo Map": longdo,
              "Google Map": google
          };

          var controller = L.control.layers(baseMaps).addTo(maps);

          var theMarker = {};

          function ZoomLocation(min_x, min_y, max_x, max_y) {
              if (min_y > 0) {
                  var originalLatLngs = [[min_y, min_x], [max_y, max_x]];
                  maps.fitBounds(originalLatLngs);
              }
          }

          var myIcon = L.icon({
              iconUrl: 'image/Icon2/enterprise.png',
              iconSize: [30, 30]
          });



          maps.on('click', function (e) {
              lat = e.latlng.lat;
              lon = e.latlng.lng;

              //              document.getElementById('MainContent_hidlat').value = lat;
              //              document.getElementById('MainContent_hidlon').value = lon;

              //              console.log("คุณเลือก: " + document.getElementById('MainContent_hidlat').value + " and LONG: " + document.getElementById('MainContent_hidlon').value);

              document.getElementById('ContentPlaceHolder1_hidlat').value = lat;
              document.getElementById('ContentPlaceHolder1_hidlon').value = lon;

              //console.log("คุณเลือก: " + document.getElementById('ContentPlaceHolder1_hidlat').value + " and LONG: " + document.getElementById('ContentPlaceHolder1_hidlon').value);
              //document.getElementById('ContentPlaceHolder1_lblMaplatLon').value = document.getElementById('ContentPlaceHolder1_hidlat').value + " and LONG: " + document.getElementById('ContentPlaceHolder1_hidlon').value;


              //Clear existing marker, 

              if (theMarker != undefined) {
                  maps.removeLayer(theMarker);
              };

              //Add a marker to show where you clicked.
              theMarker = L.marker([lat, lon],{icon:myIcon}).addTo(maps);
              document.getElementById("<%=btn1.ClientID %>").click();
          });

</script>
   
  <%--</center>--%>


       

      <br /><%--<br /><br />--%>
        <div class="row" align="center">
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <%-- <asp:Button type="submit" class="w3-button w3-purple w3-text-white w3-padding w3-round" ID="LinkbtnSignup" Text="Register" runat="server" ></asp:Button>--%>
                 <%--<input type="submit" class="w3-button w3-purple w3-text-white w3-padding w3-round " runat=server onclick="document.getElementById('ContentPlaceHolder1_LinkbtnSignup').click();" value="Sign-in" />--%>
                 <asp:LinkButton ID="LinkbtnSignup" class="w3-button w3-purple w3-text-white w3-padding w3-round" runat="server"><i class="fa fa-check-square-o" aria-hidden="true"></i> Register</asp:LinkButton>
                 <asp:LinkButton ID="LinkButton1" class="w3-button w3-purple w3-padding w3-text-white w3-round" 
                     runat="server" PostBackUrl="~/index.aspx"><i class="fa fa-mail-reply" aria-hidden="true"></i> Cancel</asp:LinkButton>
            </div>
        </div>

   <%--</form>--%>
     </div>

     </div>


    
     


</asp:Content>
