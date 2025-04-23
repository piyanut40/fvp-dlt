<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MapLocations.aspx.vb" Inherits="Map_MapLocations" %>

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
            width: 380px;
            
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
    var myRenderer = L.canvas({ padding: 0.5 });


    function addMap() {
        maps = L.map('map').setView([13, 100], 6);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors',
            renderer: L.canvas(),
            maxZoom: 18
        }).addTo(maps);
        maps.attributionControl.setPrefix(''); // Don't show the 'Powered by Leaflet' text.

        var osmap = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors',
            renderer: L.canvas(),
            maxZoom: 18
              , attribution: "OpenStreetMap"
        });
        osmap.addTo(maps);

        var longdo = L.tileLayer('https://map.doh.go.th/map/msn-server/img.php?zoom={z}&x={x}&y={y}&mode=gray&proj=epsg3857', {
            layername: 'gray', type: 'png', sphericalMercator: true
              , attribution: "longdo", renderer: L.canvas()
        });

        var google = L.tileLayer('https://mt{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}', {
            attribution: "Google",
            maxZoom: 20,
            renderer: L.canvas(),
            subdomains: ['1', '2', '3']
        });

        var baseMaps = {
            "Street Map": osmap,
            "Longdo Map": longdo,
            "Google Map": google
        };

        var controller = L.control.layers(baseMaps).addTo(maps);

        mLayerCars = new L.FeatureGroup().addTo(maps);

        mLayerGroup = new L.FeatureGroup().addTo(maps);

        cityRoutes = new L.FeatureGroup().addTo(maps);

        border = new L.featureGroup().addTo(maps);
    }



    function RemoveLayerGroup(e) {
        if (mLayerCars != undefined) {
            mLayerCars.eachLayer(function (layer) {
                if (e != layer._leaflet_id) {
                    maps.removeLayer(layer);
                } 
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

    function RemoveLayerGroup1(e) {
        if (mLayerCars != undefined) {
            mLayerCars.eachLayer(function (layer) {
                if (e != layer._leaflet_id) {
                    maps.removeLayer(layer);
                } 
            });
        }
        else {
            mLayerCars = new L.FeatureGroup().addTo(maps);
        }

        if (mLayerGroup != undefined) {
            mLayerGroup.eachLayer(function (layer) {
                if (e != layer._leaflet_id) {
                    maps.removeLayer(layer);
                } 
            });
        }
        else {
            mLayerGroup = new L.FeatureGroup().addTo(maps);
        }

        if (cityRoutes != undefined) {
            cityRoutes.eachLayer(function (layer) {
                maps.removeLayer(layer);
            });
        }
        else {
            cityRoutes = new L.FeatureGroup().addTo(maps);
        }

        if (border != undefined) {
            border.eachLayer(function (layer) {
                maps.removeLayer(layer);
            });
        }
        else {
            border = new L.FeatureGroup().addTo(maps);
        }

    }

    function AddBorder(x, y, textpopup) {
        var mIconCar = L.icon({
            iconUrl: 'images/house.png',
            iconSize: [32, 32]
        });
        var marker = L.marker(new L.LatLng(y, x), { icon: mIconCar, draggable: false }).addTo(border).bindPopup(L.popup({
            closeOnClick: false,
            autoClose: false
        }).setContent(textpopup));
    }


    function AddMarkerCar(x, y, textPopup, typecar_id, type, token , group_id) {
        var type_icon = '';
        var _width = 32;
        //        alert(typecar_id);
        if (typecar_id != -1) {

            type_icon = 'Car' + typecar_id + type;
        }
        else {
            _width = 24;
            type_icon = 'guide';
            if (type == 'R') {
                type_icon = type_icon + '1';
            }
            else {
                type_icon = type_icon + '0';
            }
        }
        var mIconCar = L.icon({
            iconUrl: 'images/' + type_icon + '.png',
            iconSize: [_width, _width]
        });
        var marker = L.marker(new L.LatLng(y, x), { icon: mIconCar, draggable: false }).addTo(mLayerCars).bindPopup(L.popup({
            closeOnClick: false,
            autoClose: false
        }).setContent(textPopup));
        //var marker = L.marker(new L.LatLng(y, x), { icon: mIconCar, draggable: false }).on('click', MarkerOnClick);
        //var marker = L.marker([y, x], { icon: mIconCar }).on('click', MarkerOnClick);
        marker.id = token;
        marker.group_id = group_id;
//         mLayerCars.addLayer(marker);
         marker.on('click', MarkerOnClick);
     }

     function AddMarkerGroup(x, y, textPopup, typecar_id, type, token, group_id) {
         var type_icon = '';
         var _width = 32;
         //        alert(typecar_id);
         if (typecar_id != -1) {

             type_icon = 'Car' + typecar_id + type;
         }
         else {
             _width = 24;
             type_icon = 'guide';
             if (type == 'R') {
                 type_icon = type_icon + '1';
             }
             else {
                 type_icon = type_icon + '0';
             }
         }
         var mIconCar = L.icon({
             iconUrl: 'images/' + type_icon + '.png',
             iconSize: [_width, _width]
         });
         var marker = L.marker(new L.LatLng(y, x), { icon: mIconCar, draggable: false }).addTo(mLayerGroup).bindPopup(textPopup);
         //var marker = L.marker(new L.LatLng(y, x), { icon: mIconCar, draggable: false }).on('click', MarkerOnClick);
         //var marker = L.marker([y, x], { icon: mIconCar }).on('click', MarkerOnClick);
         marker.id = token;
         marker.group_id = group_id;
         //         mLayerCars.addLayer(marker);
         marker.on('click', MarkerOnClick1);
     }

     function MarkerOnClick(e) {
             document.getElementById('HidMarkerIB').value = this.group_id;
             console.log(e.group_id);
             SchMap1();
             RemoveLayerGroup(e.target._leaflet_id);
             RemoveLayerGroup1(e.target._leaflet_id);
     }

   function MarkerOnClick1(e) {
       console.log(e);
   }

//    function MarkerOnClick(e) {
//        console.log(e);
//        document.getElementById('HidMarkerIB').value = this.id;
// 
//        /*var x = e.latlng.lat;
//        var y = e.latlng.lng;*/
//        //alert(this.id + 'มันไม่ทำงาน!!!');
//        var xmlHttpReq2 = createXMLHttpRequest();
//        //xmlHttpReq2.open("GET", "getTunnel.ashx?id=" + this.id, false);
//        xmlHttpReq2.open("GET", "getLocationHis.ashx?id=" + this.id, false);
//        xmlHttpReq2.send(null);


//        var yourJSString2 = xmlHttpReq2.responseText;
//        //alert(yourJSString2)
//        L.popup({ autoClose: false })
//            .setContent(yourJSString2)  
//            .setLatLng(e.latlng)
//            .openOn(maps);

//        SchMap1();
//    }

//    

//    function createXMLHttpRequest() {
//        try { return new XMLHttpRequest(); } catch (e) { }
//        try { return new ActiveXObject("Msxml2.XMLHTTP"); } catch (e) { }
//        try { return new ActiveXObject("Microsoft.XMLHTTP"); } catch (e) { }
//        alert("XMLHttpRequest not supported");
//        return null;
//    }

//    function ZoomLayerGroup() {
//        /*maps.fitBounds(mLayerCars.getBounds());
//        maps.fitBounds(cityRoutes.getBounds());*/
//    }

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
    function AddProvince(polylinePro) {
        var polygon = new L.geoJson(polylinePro, { renderer: myRenderer }).addTo(cityRoutes);
    }

    console.log(cityRoutes);

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
                 addMap();
                 window.mgtonFocus = function (txtID) {
                     var obj = document.getElementById('IframeLicense');
                     obj.style.height = '200px';
                 }

                 window.mgtonFocus = function () {
                     var obj = document.getElementById('IframeLicense');
                     console.log(obj);
                     obj.style.height = '200px';
                 }

                 window.mgtonFocusClose = function (item) {
                     console.log(item);
                     document.getElementById('HidLicense_NO').value = item;
                     SchMap();
                 }
                </script>


    <div id="over_map_rights" style="z-index:400;" runat="server">
        <table class="dataForm" style="width: 100%;"  >

          <tr>
                        <td  align="left" colspan="2" style="color: #3A038A">
                            &nbsp; ประเภท : 
                        </td>
                    </tr>

                     <tr>
                        <td align="right" style="width: 20px">
                            <%--สถานะ : --%> &nbsp; 
                        </td>
                        <td align="left" >
                        <%--คำว่า”ไกด์นำเที่ยว”,”ไกด์ทัวร์”ในระบบ เปลี่ยนเป็น “ผู้นำเที่ยว” ให้หมด และภาษาอังกฤษใช้ให้เหมือนกันคือ Tour leader or assistant--%>
                              <asp:DropDownList ID="ddlTypePosition"  runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                <asp:ListItem Value="-1" Text="เลือกทั้งหมด" ></asp:ListItem>
                <%--<asp:ListItem Value="1"  Selected="True" Text="ไกด์ทัวร์" ></asp:ListItem>--%>
                <asp:ListItem Value="1"  Selected="True" Text="ผู้นำเที่ยว" ></asp:ListItem>
                <asp:ListItem Value="0" Text="รถท่องเที่ยว"  ></asp:ListItem>
                </asp:DropDownList> 
                        </td>
                    </tr>

        <tr>
                        <td  align="left" colspan="2" style="color: #3A038A">
                            &nbsp; แสดงตำแหน่ง : 
                        </td>
                    </tr>

                     <tr>
                        <td align="right" style="width: 20px">
                            <%--สถานะ : --%> &nbsp; 
                        </td>
                        <td align="left" >
                              <asp:DropDownList ID="ddlSelect"  runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                <asp:ListItem Value="0" Text="เลือกทั้งหมด" ></asp:ListItem>
                <asp:ListItem Value="1" Text="ย้อนหลัง 3 วัน"  Selected="True" ></asp:ListItem>
                </asp:DropDownList> 
                        </td>
                    </tr>

        <tr>
                        <td  align="left" colspan="2" style="color: #3A038A">
                            &nbsp; สถานะ : 
                        </td>
                    </tr>

                     <tr>
                        <td align="right" style="width: 20px">
                            <%--สถานะ : --%> &nbsp; 
                        </td>
                        <td align="left" >
                              <asp:DropDownList ID="ddlStatus"  runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                <asp:ListItem Value="-1"  Selected="True" Text="เลือกทั้งหมด" ></asp:ListItem>
                <asp:ListItem Value="0" Text="อยู่ในเส้นทาง"></asp:ListItem>
                <asp:ListItem Value="1" Text="ออกนอกเส้นทาง"></asp:ListItem>
                </asp:DropDownList> 
                        </td>
                    </tr>
                    

                     <tr style="display:none">
                        <td align="right" style="width: 20px">
                            เลขทัวร์กรุ๊ป : &nbsp; 
                        </td>
                        <td align="left">
                              <asp:DropDownList ID="ddltype" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                <%--<asp:ListItem Value="" Text="เลือกทั้งหมด" Selected="True"></asp:ListItem>
                <asp:ListItem Value="1" Text="รถประจำถิ่น"></asp:ListItem>
                <asp:ListItem Value="3" Text="รถตามความตกลงระหว่างประเทศลาว"></asp:ListItem>
                <asp:ListItem Value="4" Text="รถตามความตกลงระหว่างประเทศมาเลเซียและสิงคโปร์"></asp:ListItem>
                <asp:ListItem Value="5" Text="รถตามความตกลงระหว่างประเทศเชิงพาณิชย์"></asp:ListItem>
                <asp:ListItem Value="2" Text="รถเพื่อการท่องเที่ยว"></asp:ListItem>--%>

                <%--<asp:ListItem Value="1" Text="รถประจำถิ่น"></asp:ListItem>
                <asp:ListItem Value="2" Text="รถตามความตกลง"></asp:ListItem>
                <asp:ListItem Value="3" Text="รถท่องเที่ยว"></asp:ListItem>--%>
                </asp:DropDownList> 
                        </td>
                    </tr>


                    <tr style="display:none">
                        <td  align="left" colspan="2" style="color: #3A038A; " >
                             &nbsp;  ผู้นำเที่ยว :   
                        </td>
                    </tr>

                    <tr style="display:none">
                        <td align="right" style="width: 20px">
                           <%-- ไกด์ทัวร์ : --%> &nbsp;
                        </td>
                        <td align="left"  >
                              <asp:DropDownList ID="ddltype_car" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                <asp:ListItem Value="" Text="เลือกทั้งหมด" Selected="True"></asp:ListItem>
                </asp:DropDownList> 
                        </td>
                    </tr>

                    <tr>
                        <td  align="left" colspan="2" style="color: #3A038A" >
                            &nbsp; เลขที่เครื่องหมายแสดงการใช้รถ / เลขที่ทัวร์กรุ๊ป : 
                        </td>
                    </tr>

                    <tr>
                        <td align="right" style="width: 20px" >
                            <%--เลขที่เครื่องหมายแสดงการใช้รถ : &nbsp;<br /> &nbsp; เลขที่ทัวร์กรุ๊ป--%> &nbsp;
                        </td>
                        <td align="center" >


                          <iframe runat="server" id="IframeLicense" enableviewstate="true" frameborder="0" name="IframeLicense" scrolling="no" 
         width="100%" height="40px" src="../Control/SearchLicense.aspx" >Your browser does not support iframes 
    </iframe>
                            <asp:HiddenField ID="HidLicense_NO" runat="server" />
                              <%--<asp:DropDownList id="ddlLicense" onchange="SchMap();" runat="server" AppendDataBoundItems="True" >
                                <asp:ListItem Value="">เลือกทั้งหมด</asp:ListItem> 
                              </asp:DropDownList> --%> 
                              <asp:DropDownList id="ddlLicense" Visible="false" runat="server" class="w3-input w3-border w3-round-large" AppendDataBoundItems="True" >
                                <asp:ListItem Value="0">เลือกทั้งหมด</asp:ListItem> 
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

            <asp:Button ID="btnLoad1" style="DISPLAY: none" runat="server" Width="80px" />
            <asp:HiddenField ID="HidMarkerIB" runat="server" />
            
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
