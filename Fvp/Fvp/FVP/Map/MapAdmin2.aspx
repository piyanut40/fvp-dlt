<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MapAdmin2.aspx.vb" Inherits="Map_MapAdmin2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Foreign Vehicle Permit</title>
    <meta charset="utf-8" />
    <meta name='viewport' content='initial-scale=1,maximum-scale=1,user-scalable=no' />

    <link rel="stylesheet" href="../Styles/leaflet.css" />
	<script type="text/javascript" src="../Scripts/leaflet.js"></script>
    

    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
 <link rel="stylesheet" href="../Styles/w3.css">
     <style type="text/css">
        *
        {
            margin: 0px;
            padding: 0px;
             /*font-family: ThaiSansNeueRegular;*/
             font-family: "Raleway", sans-serif;
            font-size: 15px;
        }
         
         /* Loading */
        .modal
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }
        
        .center
        {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 50px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }
        /* Loading */
        
        #map
        {
            min-height: 100%;
            /*height: 640px;*/
              height:100vh;
            /*height: 400px;*/ /* แบบมี header */
            /*height: 620px;*/ /* แบบไม่มี header */
            
            /*ทำหลอกก่อน*/
            /*width: 900px;*/
        }       
        
         #over_map_right
        {
            position: absolute; 
            top: 52px;
            /*ทำหลอกก่อน*/
            right: 370px;
            /*right: 2px;*/
            z-index: 99;
            
            margin: auto;
            padding: 10px;
            background-color: white;/*#4682B4;*/  /* สีพื้นของ overlay */
            opacity:0.9;
            color:Black;
        }
        
         #over_map_rights
        {
            position: absolute; 
            top: 52px;
            /*ทำหลอกก่อน*/
            right: 2px;
            z-index: 99;
            
            margin: auto;
            padding: 10px;
            background-color: white;/*#4682B4;*/  /* สีพื้นของ overlay */
            opacity:0.9;
            color:Black;
            width: 330px;
            
            /*padding: 10px;*/
        }
        
        #over_map_rights2
        {
            position: absolute; 
            top: 52px;
            /*ทำหลอกก่อน*/
            right: 2px;
            z-index: 99;
            
            margin: auto;
            padding: 10px;
            background-color: white;/*#4682B4;*/  /* สีพื้นของ overlay */
            opacity:0.9;
            color:Black;
            width: 900px;
            
            /*padding: 10px;*/
        }
        
        #over_map_Icon
        {
            position: absolute; 
            top: 52px;
            /*ทำหลอกก่อน*/
            /*right: 370px;*/
            right: 2px;
            z-index: 99;
            
            margin: auto;
            padding: 8px;
            background-color: white;/*#4682B4;*/  /* สีพื้นของ overlay */
            /*opacity:0.9;*/
            color:Black;
            height:18px;
        }
        
        #over_map_change
        {
            position: absolute; 
            top: 48px;
            /*ทำหลอกก่อน*/
            /*right: 370px;*/
            right: 30px;
            z-index: 99;
            
            margin: auto;
            padding: 8px;
            /*background-color: white;*//*#4682B4;*/  /* สีพื้นของ overlay */
            /*opacity:0.9;*/
            color:Black;
        }
        
        /* @media screen and (min-width: 320px) and (max-width:600px)
        {
            #over_map_right
            {
                right: 10px;
            }
            
        }*/
        
        
        .ScrollStyle
{
    max-height: 150px;
    overflow-y: scroll;
}

      </style>

      <style type="text/css">
    .divTable
    {
        display:  table;
        width: 320px;
        /*width:auto;*/
        /*background-color:#eee;
        border:1px solid  #666666;*/
        border-spacing:2px;/*cellspacing:poor IE support for  this*/
       /* border-collapse:separate;*/
        /*font-size: 18px;*/
    }

    .divRow
    {
       display:table-row;
       
    }

    .divCell
    {
        float:left;/*fix for  buggy browsers*/
        display:table-column;
        margin-left:10px;
        width:180px;
        /*background-color:#ccc;*/
        color: Gray;
    }
    
    .divCellR0
    {
        float:left;/*fix for  buggy browsers*/
        display:table-column;
        text-align:right;
        color: #124679;
        width:70px;
        /*background-color:#ccc;*/
    }
    
    .divCellR
    {
        float:left;/*fix for  buggy browsers*/
        display:table-column;
        text-align:right;
        color: #124679;
        width:120px;
        /*background-color:#ccc;*/
    }
    
    .divCellRs
    {
        float:left;/*fix for  buggy browsers*/
        display:table-column;
        text-align:right;
        color: #124679;
        width:200px;
        /*background-color:#ccc;*/
    }
    
    
table.dataForm
{
	background-color: #ffffff;
	/*font-family: Verdana,Tahoma;
	font-size: 12px;*/
	color: #585768;
	border: 0px;
	width: 981px;
	border-right: #989898 1px solid;
	border-top: #989898 1px solid;
	border-left: #989898 1px solid;
	border-bottom: #989898 1px solid;
	padding-right: 5px;
	padding-left: 5px;
	padding-bottom: 5px;
	padding-top: 5px;
	margin-left : auto;
	margin-right: auto;	
}


    
</style> 

<script type="text/javascript" language="javascript" >
    var maps;
    function addMap() {

        maps = L.map('map').setView([13, 102.2], 6);
        L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors',
            maxZoom: 18
        }).addTo(maps);
        maps.attributionControl.setPrefix(''); // Don't show the 'Powered by Leaflet' text.

        var osmap = L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors',
            maxZoom: 18
              , attribution: "OpenStreetMap"
        });
        osmap.addTo(maps);

        var longdo = L.tileLayer('http://map.doh.go.th/map/msn-server/img.php?zoom={z}&x={x}&y={y}&mode=gray&proj=epsg3857', {
            layername: 'gray', type: 'png', sphericalMercator: true
              , attribution: "longdo"
        });

        var baseMaps = {
            "Street Map": osmap,
            "Longdo Map": longdo
        };

        var controller = L.control.layers(baseMaps).addTo(maps);
        mLayerCars = new L.FeatureGroup().addTo(maps);

        cityRoutes = new L.FeatureGroup().addTo(maps);
    }



    function RemoveLayerGroup() {
        if (mLayerCars != undefined) {
            mLayerCars.eachLayer(function (layer) {
                maps.removeLayer(layer);
            });
        }
        else {
            mLayerCars = new L.FeatureGroup().addTo(maps);
        }

        if (cityRoutes != undefined) {
            cityRoutes.eachLayer(function (layer) {
                maps.removeLayer(layer);
            });
        }
        else {
            cityRoutes = new L.FeatureGroup().addTo(maps);
        }
    }

    function RemoveLayerGroup1() {
        if (cityRoutes != undefined) {
            cityRoutes.eachLayer(function (layer) {
                maps.removeLayer(layer);
            });
        }
        else {
            cityRoutes = new L.FeatureGroup().addTo(maps);
        }
    }

    var mIconCarx = L.icon({
        iconUrl: 'images/truck3.png',
        iconSize: [32, 37]
    });



    var mLayerCars;
    function AddMarkerAdmin(x, y, textPopup , admin_id) {
        var mIconCar = L.icon({
            iconUrl: 'images/house.png',
            iconSize: [32, 37]
        });
        var marker = L.marker(new L.LatLng(y, x), { icon: mIconCar, draggable: false }).addTo(mLayerCars).bindPopup(textPopup + " <a onclick='SelectAdmin_ID(" + admin_id + ");' ><img src=../image/Button-Add-icon.png ></a>");
        //var marker = L.marker(new L.LatLng(y, x), { icon: mIconCar, draggable: false }).on('click', MarkerOnClick);
        //var marker = L.marker([y, x], { icon: mIconCar }).on('click', MarkerOnClick);
        marker.id = admin_id;
        //mLayerCars.addLayer(marker);
//        marker.on('click', MarkerOnClick);
    }

    function MarkerOnClick1(e) {

    }

    function MarkerOnClick(e) {
        console.log(e);
        document.getElementById('HidMarkerIB').value = this.id;

        /*var x = e.latlng.lat;
        var y = e.latlng.lng;*/
        //alert(this.id + 'มันไม่ทำงาน!!!');
        var xmlHttpReq2 = createXMLHttpRequest();
        //xmlHttpReq2.open("GET", "getTunnel.ashx?id=" + this.id, false);
        xmlHttpReq2.open("GET", "getRealTimeLocation.ashx?id=" + this.id, false);
        xmlHttpReq2.send(null);


        var yourJSString2 = xmlHttpReq2.responseText;
        //alert(yourJSString2)
        L.popup({ autoClose: false })
            .setContent(yourJSString2)
            .setLatLng(e.latlng)
            .openOn(maps);

        SchMap1();
    }



    function createXMLHttpRequest() {
        try { return new XMLHttpRequest(); } catch (e) { }
        try { return new ActiveXObject("Msxml2.XMLHTTP"); } catch (e) { }
        try { return new ActiveXObject("Microsoft.XMLHTTP"); } catch (e) { }
        alert("XMLHttpRequest not supported");
        return null;
    }

    function ZoomLayerGroup() {
        /*maps.fitBounds(mLayerCars.getBounds());
        maps.fitBounds(cityRoutes.getBounds());*/
    }

    function ZoomLocation(min_x, min_y, max_x, max_y) {
        if (min_y > 0) {
            var originalLatLngs = [[min_y, min_x], [max_y, max_x]];
            maps.fitBounds(originalLatLngs);
        }
    }

    function SelectAdmin_ID(admin_id) {
        document.getElementById('HidAdminID').value = admin_id;
        document.getElementById('btnSetAdmin').click();
    }
</script>

<script type="text/javascript">
    function SchMap() {
        var obj = document.getElementById('IframeLicense');
        obj.style.height = '40px';
        document.getElementById('btnLoad').click();
    }

    function SchMap1() {
        document.getElementById('btnLoad1').click();
    }

    var cityRoutes;
    function AddProvince(polylinePro, ProTH, p_color) {

        //        alert(polylinePro);

        //            var polylinePoints = [
        //                            new L.LatLng(15.2774683251243, 104.856908417564),
        //                            new L.LatLng(15.2771390237077, 104.852530876947),
        //                            new L.LatLng(15.2771390237077, 104.852530876947)
        //                         ];
        //              
        //                var polygon = L.polygon([
        //            [15.2774683251243, 104.856908417564],
        //            [15.2771390237077, 104.852530876947],
        //            [15.2771390237077, 104.852530876947]
        //        ]).addTo(cityRoutes);


        var polylineOptions = {
            color: p_color,
            id: ProTH
        };

        var polygon = new L.polygon(polylinePro, polylineOptions).addTo(cityRoutes);
        //        //polygon.bindTooltip("my tooltip text").openTooltip();
        //        if (ProTH != '') {
        //            polygon.bindTooltip(ProTH, { permanent: true, direction: "center" }); //.openTooltip();
        //        }


        //        maps.eachLayer(function (l) {
        //            if (l.getTooltip) {
        //                var toolTip = l.getTooltip();
        //                if (toolTip) {
        //                    this.maps.closeTooltip(toolTip);
        //                }
        //            }
        //        });

        //        var lastZoom;
        //        maps.on('zoomend', function zoomendEvent(ev) {
        //            var zoom = maps.getZoom();
        //            if (zoom < 6 && (!lastZoom || lastZoom >= 6)) {
        //                maps.eachLayer(function (l) {
        //                    if (l.getTooltip) {
        //                        var toolTip = l.getTooltip();
        //                        if (toolTip) {
        //                            this.maps.closeTooltip(toolTip);
        //                        }
        //                    }
        //                });
        //            } else if (zoom >= 6 && (!lastZoom || lastZoom < 6)) {
        //                maps.eachLayer(function (l) {
        //                    if (l.getTooltip) {
        //                        var toolTip = l.getTooltip();
        //                        if (toolTip) {
        //                            this.maps.addLayer(toolTip);
        //                        }
        //                    }
        //                });
        //            }
        //            lastZoom = zoom;
        //        });
    }



</script>

 

</head>
<body id="mBody" runat="server">
   <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" AsyncPostBackTimeOut="1000" runat="server">
    </asp:ScriptManager>
     
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdMap">
    <ProgressTemplate>
        <div align="center" class="overlays">
            <div class="loader" ></div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
    
    <div id="map" class="map" > </div>

       
             
             <script type="text/javascript">
                 window.mgtonFocus = function (txtID) {
                     var obj = document.getElementById('IframeLicense');
                     obj.style.height = '200px';
                 }

                 window.mgtonFocus = function () {
                     var obj = document.getElementById('IframeLicense');
                     obj.style.height = '200px';
                 }

                 window.mgtonFocusClose = function (item) {
                     document.getElementById('HidLicense_NO').value = item;
                     SchMap();
                 }
                </script>
    <div id="over_map_rights" style="z-index:500;" runat="server">
    <asp:UpdatePanel ID="UpdLocation"   runat="server" UpdateMode="Conditional">
         <ContentTemplate>

        <table class="dataForm" style="width: 100%;"  >
                     <tr>
                        <td align="right" style="width: 120px">
                            Province : &nbsp; 
                        </td>
                        <td align="left">
                              <asp:DropDownList id="ddlPro" Width="200px"  class="w3-input w3-border w3-round-large" AutoPostBack="true" runat="server" AppendDataBoundItems="True" >
                              </asp:DropDownList>  
                        </td>
                    </tr>
                    

                     <tr>
                        <td align="right" style="width: 120px">
                             Amphoe : &nbsp; 
                        </td>
                        <td align="left">
                              <asp:DropDownList id="ddlAmp" Width="200px"  class="w3-input w3-border w3-round-large" AutoPostBack="true" runat="server" AppendDataBoundItems="True" >
                              <asp:ListItem Value="0" Text="Select Amphoe" ></asp:ListItem>
                              </asp:DropDownList>    
                
               
                        </td>
                    </tr>

                    <tr>
                        <td align="right" style="width: 120px">
                            Tumbol : &nbsp; 
                        </td>
                        <td align="left">
                              <asp:DropDownList id="ddlTum" Width="200px"  class="w3-input w3-border w3-round-large" runat="server" AutoPostBack="true" AppendDataBoundItems="True" >
                              <asp:ListItem Value="0" Text="Select Tumbol" ></asp:ListItem>
                              </asp:DropDownList>  
                        </td>
                    </tr>

                     

                    <tr>
                        <td colspan="2" align="right">
                             <%--<asp:LinkButton ID="lnkSch" class="w3-button w3-purple2 w3-padding w3-round" runat="server" OnClientClick="javascript:SchMap();"><i class="fa fa-search" aria-hidden="true" ></i>  ค้นหา</asp:LinkButton>--%>
                              <%--<a  class="w3-button w3-purple2 w3-padding w3-round" onclick"SchMap();" ><i class="fa fa-search" aria-hidden="true" ></i> ค้นหา</a>--%>
                              <button id="btn" class="w3-button w3-purple2 w3-padding w3-round" onclick="SchMap();return false;" > searching </button>
                        </td>
                    </tr>
                </table>     

                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdLocation">
    <ProgressTemplate>
        <div align="center" class="overlays">
            <div class="loader" ></div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
</ContentTemplate>
           
</asp:UpdatePanel>

                
           <center>
           <asp:Panel ID="PnUpdateData"  runat="server" >
           <br/>
                <input id="BtnUpdateData" type="button" onclick="javascript:document.getElementById('BtnUpdateDataMarker').click();" value="Update สำนักขนส่งจังหวัด " />
            </asp:Panel>
            </center> 
    </div>

  

    <div id="over_map_rights2" style="DISPLAY: none">
        <br />          
    </div>

 

    <div id="over_map_Icon" style="DISPLAY: none">
                 
    </div>
            
    <asp:UpdatePanel ID="UpdMap" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Button ID="btnLoad" style="DISPLAY: none" runat="server" Width="80px" />
            <asp:HiddenField ID="HidIndex" runat="server" />

            <asp:Button ID="btnLoad1" style="DISPLAY: none" runat="server" Width="80px" />
            <asp:HiddenField ID="HidMarkerIB" runat="server" />

            <asp:Button ID="btnSetAdmin" style="DISPLAY: none" runat="server" Width="80px" />
            <asp:HiddenField ID="HidAdminID" runat="server" />

            <asp:Button ID="BtnUpdateDataMarker" style="DISPLAY: none" runat="server" Width="80px" />
        </ContentTemplate>
    </asp:UpdatePanel>
           


<%--For Loading--%>
<style type="text/css">
.overlays
{
position: fixed;
z-index: 999;
height: 100%;
width: 100%;
top: 0;
background-color: Black;
filter: alpha(opacity=60);
opacity: 0.6;
-moz-opacity: 0.8;
color:White;

/*เพิ่มมาเองมันมีช่องว่างด้านซ้าย*/
left: 0;
}

.loader {
    border: 16px solid #f3f3f3; /* Light grey */
    border-top: 16px solid #2980B9; /* purple */
    border-radius: 50%;
    width: 90px;
    height: 90px;
    animation: spin 2s linear infinite;
    margin-top:200px;
}

@keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
}

</style>

    </form>
</body>
</html>
