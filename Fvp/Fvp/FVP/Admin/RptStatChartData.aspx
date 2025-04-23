<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="RptStatChartData.aspx.vb" Inherits="Admin_RptStatChartData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
<style>

.fontKanit
{ font-family: 'Kanit', sans-serif;
  
}

.heading {
  color: #fff;
  text-align: center;
}
.heading h1 {
  margin-bottom: 3rem;
  font-weight: 300;
  position: relative;
}
.heading h1:after {
  content: '';
  height: 2px;
  width: 2rem;
  position: absolute;
  left: 50%;
  bottom: -1rem;
  -webkit-transform: translateX(-50%);
          transform: translateX(-50%);
  background-color: #fff;
}
.container {
  background-color:#F8F9F9;
  padding: 2rem;
  box-shadow: 4px 4px 8px rgba(0,0,0,0.1);
}
.container .nav {
  background-color: #530f87;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 1rem;
  margin: 0 -3rem 2rem;
  box-shadow: 2px 2px 4px rgba(0,0,0,0.1);
  position: relative;
}
.container .nav:before,
.container .nav:after {
  content: '';
  height: 0;
  width: 0;
  position: absolute;
  top: 0;
  border: 0.75rem solid transparent;
  border-bottom: 0.75rem solid #f2f0f0;
  -webkit-transform-origin: center;
          transform-origin: center;
  box-shadow: 2px 2px 4px rgba(0,0,0,0.1);
  z-index: -1;
}
.container .nav:before {
  left: 0;
  -webkit-transform: translateY(-0.45rem) rotate(135deg) translateX(-0.4rem);
          transform: translateY(-0.45rem) rotate(135deg) translateX(-0.4rem);
}
.container .nav:after {
  right: 0;
  -webkit-transform: translateY(-0.45rem) rotate(-135deg) translateX(0.4rem);
          transform: translateY(-0.45rem) rotate(-135deg) translateX(0.4rem);
}
.container .nav a {
  display: inline-block;
  margin: 0 3rem;
  font-size: 2rem;
  color: #2980b9;
  opacity: 0.7;
  transition: 0.25s;
}
.container .nav a:hover {
  opacity: 1;
}
.container .list .num {
  padding: 0.5rem 2rem;
  display: flex;
  align-items: center;
  justify-content: flex-start;
  transition: 0.25s;
}
.container .list .num:nth-child(0):before {
  content: '0';
  font-size: 4rem;
  font-weight: bold;
  color: #000;
  width: 2rem;
  opacity: 0.05;
  transition: 0.25s;
}
.container .list .num:nth-child(1):before {
  content: '1';
  font-size: 4rem;
  font-weight: bold;
  color: #000;
  width: 2rem;
  opacity: 0.05;
  transition: 0.25s;
}
.container .list .num:nth-child(2):before {
  content: '2';
  font-size: 4rem;
  font-weight: bold;
  color: #000;
  width: 2rem;
  opacity: 0.05;
  transition: 0.25s;
}
.container .list .num:nth-child(3):before {
  content: '3';
  font-size: 4rem;
  font-weight: bold;
  color: #000;
  width: 2rem;
  opacity: 0.05;
  transition: 0.25s;
}
.container .list .num:nth-child(4):before {
  content: '4';
  font-size: 4rem;
  font-weight: bold;
  color: #000;
  width: 2rem;
  opacity: 0.05;
  transition: 0.25s;
}
.container .list .num:nth-child(5):before {
  content: '5';
  font-size: 4rem;
  font-weight: bold;
  color: #000;
  width: 2rem;
  opacity: 0.05;
  transition: 0.25s;
}
.container .list .num:nth-child(6):before {
  content: '6';
  font-size: 4rem;
  font-weight: bold;
  color: #000;
  width: 2rem;
  opacity: 0.05;
  transition: 0.25s;
}
.container .list .num:nth-child(7):before {
  content: '7';
  font-size: 4rem;
  font-weight: bold;
  color: #000;
  width: 2rem;
  opacity: 0.05;
  transition: 0.25s;
}
.container .list .num:nth-child(8):before {
  content: '8';
  font-size: 4rem;
  font-weight: bold;
  color: #000;
  width: 2rem;
  opacity: 0.05;
  transition: 0.25s;
}
.container .list .num:nth-child(9):before {
  content: '9';
  font-size: 4rem;
  font-weight: bold;
  color: #000;
  width: 2rem;
  opacity: 0.05;
  transition: 0.25s;
}
.container .list .num h3 {
  position: relative;
  left: -1.5rem;
  color: #3d3d3d;
  font-size: 0.85rem;
  transition: 0.25s;
}
.container .list .num:hover {
  background-color: #fafafa;
  cursor: pointer;
}
.container .list .num:hover:before {
  opacity: 0.2;
}
.container .list .num:hover h3  {
  left: 1rem;
}

.container .list .num a {
  position: relative;
  left: -1.5rem;
  color: #3d3d3d;
  font-size: 0.85rem;
  transition: 0.25s;
}

.container .list .num:hover a  {
  left: 1rem;
}
 
.message {
  color: #fff;
  text-align: center;
  text-transform: uppercase;
  margin-top: 2rem;
}
.ColorAmin
{
background-color:#530f87;
color:White;

    
    }
</style>
<script type="text/javascript" src="../Scripts/OrderedListjquery.min.js.js"></script>

 <center>
  <header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;color:#530f87">    <asp:Label ID="lblHead" runat="server" Text="รายงานสถิติ" Font-Bold="True" class="fontKanit" Font-Size="xx-large"></asp:Label> 
    
  </header>
</center>
<br />

<div class="container">
   <asp:Label ID="lbltab2" runat="server" Text="ประเภทรถ" Font-Bold="True" class="w3-xlarge fontKanit nav ColorAmin" ></asp:Label>
 
  <div class="list">
    <div class="num">
      <a id="A12" href="RptStatCharts.aspx?type=2&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large"> ประเภทรถที่ขออนุญาต </a>
    </div>
    <div class="num">
        <a id="A10" href="RptStatCharts.aspx?type=7&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  จำนวนรถที่ขออนุญาต จำแนกตามประเภทรถ และรายเดือน</a>
    </div>
    <div class="num">
        <a id="A2" href="RptStatCharts.aspx?type=15&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  เปรียบเทียบจำนวนรถที่ขออนุญาต รายเดือน</a>
    </div>
  </div>
</div>
 <br />
 <div class="container">
 <asp:Label ID="lbltab3" runat="server" Text="ด่านศุลกากร เข้า-ออก" Font-Bold="True" class="w3-xlarge fontKanit nav ColorAmin"></asp:Label> 
  <div class="list">
    <div class="num">
     <a id="A15" href="RptStatCharts.aspx?type=5&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  จำนวนรถที่ขออนุญาตฯ เข้า-ออก จำแนกตามด่าน 5 ลำดับแรก </a>
    </div>
    <%--<div class="num">
        <a id="A24" href="RptStatCharts.aspx?type=8&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  จำนวนรถที่ขออนุญาตฯ เข้า-ออก จำแนกตามด่าน 5 ลำดับแรก(รูปแบบตาราง)</a>
    </div>--%>
    <div class="num">
       <a id="A25" href="RptStatCharts.aspx?type=9&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  จำนวนรถที่ขออนุญาตฯ เข้า-ออก จำแนกตามด่าน ทั้งหมด</a>
    </div>
   <div class="num">
    <a id="A6"  href="RptStatCharts.aspx?type=8&IsAll=1&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  จำนวนรถที่ขออนุญาตฯ เข้า-ออก จำแนกตามด่าน ทั้งหมด (รูปแบบตาราง)</a>
   </div>
  </div>
</div>
<br />
<div class="container">
 <asp:Label ID="lbltab4" runat="server" Text="ผู้ประกอบธุรกิจนำเที่ยว" Font-Bold="True" class="w3-xlarge fontKanit nav ColorAmin"></asp:Label> 
  <div class="list">
    <div class="num">
     <a id="A4" href="RptStatCharts.aspx?type=6&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  จำนวนรถจำแนกตามผู้ประกอบธุรกิจนำเที่ยวที่ยื่นขอฯ</a>
    </div>
    <div class="num">
      <a id="A26" href="RptStatCharts.aspx?type=10&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  จำนวนรถจำแนกตามผู้ประกอบธุรกิจนำเที่ยวที่ยื่นขอฯ (รูปแบบตาราง)</a>
    </div>
  </div>
</div>
<br />
<div class="container">
<asp:Label ID="lbltab5" runat="server" Text="สำนักงาน" Font-Bold="True" class="w3-xlarge fontKanit nav ColorAmin"></asp:Label> 
  <div class="list">
    <div class="num">
     <a id="A11" href="RptStatCharts.aspx?type=1&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large" >  รถที่ขออนุญาตฯ จำแนกตามสำนักงาน</a>
    </div>
    <div class="num">
      <a id="A28" href="RptStatCharts.aspx?type=12&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  จำนวนรถที่ขออนุญาตฯ จำแนกตามสำนักงาน และประเภทรถ</a>
    </div>
    <div class="num">
      <a id="A29" href="RptStatCharts.aspx?type=11&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  จำนวนรถที่ขออนุญาตฯ จำแนกตามสำนักงาน และประเภทรถ (รูปแบบตาราง)</a>
    </div>
  </div>
</div>

<br />
<div class="container">
<asp:Label ID="lbltab6" runat="server" Text="ประเทศที่รถจดทะเบียน" Font-Bold="True" class="w3-xlarge fontKanit nav ColorAmin"></asp:Label> 
  <div class="list">
    <div class="num">
     <a id="A14" href="RptStatCharts.aspx?type=4&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  ประเทศที่รถจดทะเบียน </a>
    </div>
    <div class="num">
      <a id="A32" href="RptStatCharts.aspx?type=14&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  จำนวนรถที่ขออนุญาตฯ จำแนกตามประเทศที่รถจดทะเบียน และประเภทรถ</a>
    </div>
    <div class="num">
      <a id="A33" href="RptStatCharts.aspx?type=13&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large">  จำนวนรถที่ขออนุญาตฯ จำแนกตามประเทศที่รถจดทะเบียน และประเภทรถ (รูปแบบตาราง)</a>
    </div>
  </div>
</div>
<br />
<div class="container">
<asp:Label ID="lbltab" runat="server" Text="รายงานสรุป" Font-Bold="True" class="w3-xlarge fontKanit nav ColorAmin" ></asp:Label>
  <div class="list">
    <div class="num">
     <a id="A3" href="RptStatCarByAdmin.aspx?type=0&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large" >รายงานการอนุญาตรถเข้ามาในราชอาณาจักรชั่วคราว จำแนกตามสำนักงาน </a>
    </div>
    <div class="num">
    <a id="A1" href="RptStatCarByAdmin.aspx?type=1&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large" >รายงานการอนุญาตรถเข้ามาในราชอาณาจักรชั่วคราว จำแนกตามสำนักงาน ประจำเดือน </a>
    </div>
    <div class="num">
    <a id="A5" href="RptStatCarByAdmin_Car.aspx?type=0&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large" >รายงานการอนุญาตรถเข้ามาในราชอาณาจักรชั่วคราว จำแนกตามคำขอฯ </a>
    </div>
    <div class="num">
    <a id="A7" href="RptStatCarByAdmin_Car.aspx?type=1&rt=<% Response.Write(_rt)%>" class="w3-text-deep-purple fontKanit w3-large" >รายงานการอนุญาตรถเข้ามาในราชอาณาจักรชั่วคราว จำแนกตามคำขอฯ ประจำเดือน</a>
    </div>
  </div>
</div>


</asp:Content>

