<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="MapLocation.aspx.vb" Inherits="Admin_MapLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<header class="w3-container" style="padding-top:22px">
 <header class="w3-container" style="margin-top: 15px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">ติดตามตำแหน่งรถบนแผนที่</b></a><br /><br/>
</header>
  <%--  <h4 class="headtxt"><b>ติดตามตำแหน่งรถบนแผนที่ </b></h4>--%>
</header>
 

<br />
  
   
  <div class="row no-gutters align-items-center py-2 ">

   
    <iframe runat="server" id="IframeLocation" enableviewstate="true" frameborder="0" name="IframeLocation" scrolling="yes" 
         width="99%" height="700px" src="../Map/MapLocations.aspx" >Your browser does not support iframes 
    </iframe>
    
  </div>
   
</asp:Content>

