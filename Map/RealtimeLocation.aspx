<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RealtimeLocation.aspx.vb" Inherits="Map_RealtimeLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Foreign Vehicle Permit</title>
    <meta charset="utf-8" />
    <meta name='viewport' content='initial-scale=1,maximum-scale=1,user-scalable=no' />
<%--
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.4.0/dist/leaflet.css"
  integrity="sha512-puBpdR0798OZvTTbP4A8Ix/l+A4dHDD0DGqYW6RQ+9jxkRFclaxxQb/SJAWZfWAkuyeQUytO7+7N4QKrDh+drA=="
  crossorigin=""/>
<script src="https://unpkg.com/leaflet@1.4.0/dist/leaflet.js"
  integrity="sha512-QVftwZFqvtRNi0ZyCtsznlKSWOStnDORoefr1enyq5mVL4tmKB3S/EnC3rRJcxCPavG10IcrVGSmPh6Qw5lwrg=="
  crossorigin=""></script>--%>
    <link rel="stylesheet" href="../Styles/leaflet.css" />
    <%--ของเราหารูปไม่เจอ--%>
	<%--<script type="text/javascript" src="leaflet.js"></script>--%>
	<script type="text/javascript" src="../Scripts/leaflet.js"></script>
    <%--<link rel="stylesheet" href="https://unpkg.com/leaflet@1.3.4/dist/leaflet.css" />--%>
    <%--<script src="https://unpkg.com/leaflet@1.3.4/dist/leaflet.js"></script>--%>

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
            width: 370px;
            
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

	        maps = L.map('map').setView([13, 100], 6);
	        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
	            attribution: '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors',
	            maxZoom: 18
	        }).addTo(maps);
	        maps.attributionControl.setPrefix(''); // Don't show the 'Powered by Leaflet' text.

	        var osmap = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
	            attribution: '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors',
	            maxZoom: 18
              , attribution: "OpenStreetMap"
	        });
	        osmap.addTo(maps);

	        var longdo = L.tileLayer('https://map.doh.go.th/map/msn-server/img.php?zoom={z}&x={x}&y={y}&mode=gray&proj=epsg3857', {
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

	    var mIconCar = L.icon({
	        iconUrl: 'images/Car1.png',
	        iconSize: [32, 37]
	    });

	    var mLayerCars;
	    function AddMarkerCar(x, y, textPopup) {
	        var marker = L.marker(new L.LatLng(y, x), { icon: mIconCar, draggable: false }).addTo(mLayerCars).bindPopup(textPopup); //.openPopup();
	        //alert('123');
	    }

	    function ZoomLayerGroup() {
	        //maps.fitBounds(mLayerCars.getBounds());
	        //maps.fitBounds(cityRoutes.getBounds());
	    }

</script>

<script type="text/javascript">
    function SchMap() {
//        alert(555);

//        document.getElementById('MainContent_IframeLocation_btnLoad').click();
        document.getElementById('btnLoad').click();
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
    

             

    <div id="over_map_rights" runat="server">
        <table class="dataForm" style="width: 100%;"  >
                     
                    <tr>
                        <td align="right" style="width: 160px">
                            เลขที่เครื่องหมายแสดงการใช้รถ : &nbsp; 
                        </td>
                        <td align="left">
                              <%--<asp:DropDownList id="ddlLicense" onchange="SchMap();" runat="server" AppendDataBoundItems="True" >
                                <asp:ListItem Value="">เลือกทั้งหมด</asp:ListItem> 
                              </asp:DropDownList> --%> 
                              <asp:DropDownList id="ddlLicense" runat="server" class="w3-input w3-border w3-round-large" AppendDataBoundItems="True" >
                                <asp:ListItem Value="0">เลือกทั้งหมด</asp:ListItem> 
                              </asp:DropDownList> 
                        </td>
                    </tr>

                     <tr>
                        <td align="right" style="width: 160px">
                            แบบขออนุญาต : &nbsp; 
                        </td>
                        <td align="left">
                              <asp:DropDownList ID="ddltype" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                <%--<asp:ListItem Value="" Text="เลือกทั้งหมด" Selected="True"></asp:ListItem>
                <asp:ListItem Value="1" Text="รถประจำถิ่น"></asp:ListItem>
                <asp:ListItem Value="2" Text="รถตามความตกลงระหว่างประเทศลาว"></asp:ListItem>
                <asp:ListItem Value="3" Text="รถตามความตกลงระหว่างประเทศมาเลเซียและสิงคโปร์"></asp:ListItem>
                <asp:ListItem Value="4" Text="รถตามความตกลงระหว่างประเทศเชิงพาณิชย์"></asp:ListItem>
                <asp:ListItem Value="5" Text="รถเพื่อการท่องเที่ยว"></asp:ListItem>--%>

                <%--<asp:ListItem Value="1" Text="รถประจำถิ่น"></asp:ListItem>
                <asp:ListItem Value="2" Text="รถตามความตกลง"></asp:ListItem>
                <asp:ListItem Value="3" Text="รถท่องเที่ยว"></asp:ListItem>--%>
                </asp:DropDownList> 
                        </td>
                    </tr>

                    <tr>
                        <td align="right" style="width: 160px">
                            ประเภทรถ : &nbsp; 
                        </td>
                        <td align="left">
                              <asp:DropDownList ID="ddltype_car" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                <asp:ListItem Value="" Text="เลือกทั้งหมด" Selected="True"></asp:ListItem>
                </asp:DropDownList> 
                        </td>
                    </tr>

                     <tr>
                        <td align="right" style="width: 160px">
                            ประเทศ : &nbsp; 
                        </td>
                        <td align="left">
                              <asp:DropDownList ID="ddlcountry" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                <asp:ListItem Value="" Text="เลือกทั้งหมด" Selected="True"></asp:ListItem>
                </asp:DropDownList> 
                        </td>
                    </tr>
                    
                    <tr>
                        <td colspan="2" align="right">
                             <%--<asp:LinkButton ID="lnkSch" class="w3-button w3-purple2 w3-padding w3-round" runat="server" OnClientClick="javascript:SchMap();"><i class="fa fa-search" aria-hidden="true" ></i>  ค้นหา</asp:LinkButton>--%>
                              <%--<a  class="w3-button w3-purple2 w3-padding w3-round" onclick"SchMap();" ><i class="fa fa-search" aria-hidden="true" ></i> ค้นหา</a>--%>
                              <button id="btn" class="w3-button w3-purple2 w3-padding w3-round" onclick="SchMap();return false;" > ค้นหา</button>
                        </td>
                    </tr>
                </table>     
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
