<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
body, html {
  height: 100%;
  color: #777;
  line-height: 1.8;
  scroll-behavior:smooth;
  overflow: hidden;
}  @font-face{
      font-family: 'Kanit', sans-serif;
        src : url('font/ThaiSansNeue-Regular/thaisansneue-bold-webfont.woff2');
    
    
    }
bgimg
{
    
  height: 100%; 
  /* Center and scale the image nicely */
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
    
       
    }
/* First image (Logo. Full height) */
.bgimg{
  background-image: url("image/BG.jpg");
  min-height: 100%;
  background-size: cover;
  position: relative;
  
}
.bgMS
{
    background-image: url("image/Amethyst.jpg");
  min-height: 100%;
  background-size: cover;
    
    }
.bgimg-2{
  background-image: url("image/Worldbg.jpg");
  /* Full height */
  height: 100%; 
  /* Center and scale the image nicely */
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
    
}

.mapasia
{
    max-width:100%;
    max-height:100%;
    height: auto;
    /*padding:10px 50px 20px 50px;*/
    margin-left:10em;
    margin-top:-2%;
}

section {
  width: 100%;
  margin: 0;
  max-width: none;
  height: 100vh;  
}
.arrow
{
     cursor: pointer;
     width:40px; 
     height:40px;
     margin-right:5%;
     /*margin-top:-7%;*/
     margin-top:38%;
    
    
}

.popup
{
 
  max-width:30%;   
    
 }.m1
 {
     margin-top:1%;
     font-size:1em;
     text-shadow:2px 1px 0 #444;
     
}
.m2
{
  margin-top:-3%;
  font-size:0.8em;
      
    
}  
.hdtext2
{
     margin-top:1%;font-size:1.8em; text-shadow:2px 1px 0 #444;
}
.R1
{
    width:35%; height:10%;
} 
.R2
{
    width:35%; height:20%;margin-left:-5%;margin-right:12%;
    
}
.R3
{
    width:35%; height:10%;
    margin-bottom: -5%;
}
.title
{
        height: 6em;
    overflow: hidden;
    text-overflow: ellipsis;
 
    
    }
  .txt
  {
        height: 8em;
white-space:wrap;overflow: hidden;
text-overflow: ellipsis;
    margin-top: -2%;
}
.date{ margin-top: -1%;}
.news
{
    margin-top:9%;
    margin-left: 15%;
}
div.card {
  /*position: absolute;*/
  /*left: 50%;*/
  margin-top: 5%;
  margin-left: 20%;
  width: 390px;
  height: 350px;
  -webkit-transform: translate(-50%, -50%) translateZ(0);
  transform: translate(-50%, -50%) translateZ(0);
  border-radius: 3px;
  box-shadow: 0 1px 4px rgba(0, 0, 0, 0.3);
  overflow: hidden;
  display:block;
}
div.card .thumb {
  width: 100%;
  height: 260px;
  border-radius: 3px;
 
}
div.card .infos {
  width: auto;
  height: 350px;
  position: relative;
  /*padding: 14px 24px;*/
  padding: 16px;
  background: #fff;
  transition: 0.4s 0.15s cubic-bezier(0.17, 0.67, 0.5, 1.03);
}
div.card .infos .title {
  position: relative;
  margin: 10px 0;
  letter-spacing: 3px;
  color: #152536;
  /*font-family: "Grotesque Black", sans-serif;*/
  font-size: 1rem;
  text-transform: uppercase;
  text-shadow: 0 0 0px #32577f;  
  margin-top: -1%;

}
div.card .infos .flag {
  position: absolute;
  top: 50%;
  right: 0;
  -webkit-transform: translateY(-50%);
          transform: translateY(-50%);
  width: 35px;
  height: 23px;
  background: url("https://s3-us-west-2.amazonaws.com/s.cdpn.io/397014/flag.png") no-repeat top right;
  background-size: 100% auto;
  display: inline-block;
}
div.card .infos .date, article.card .infos .seats {
  margin-bottom: 10px;
  text-transform: uppercase;
  font-size: .85rem;
  color: rgba(21, 37, 54, 0.7);
  /*font-family: "Grotesque", sans-serif;*/
}
div.card .infos .seats {
  display: inline-block;
  margin-bottom: 24px;
  padding-bottom: 24px;
  border-bottom: 1px solid rgba(0, 0, 0, 0.2);
  opacity: 0;
  transition: 0.5s 0.25s cubic-bezier(0.17, 0.67, 0.5, 1.03);
}
div.card .infos .txt {
  /*font-family: "Merriweather", sans-serif;*/
  line-height: 2;
  font-size: .95rem;
  color: rgba(21, 37, 54, 0.7);
  opacity: 0;
  transition: 0.5s 0.25s cubic-bezier(0.17, 0.67, 0.5, 1.03);
 
}
div.card .infos .details {
  position: absolute;
  left: 0;
  left: 0;
  bottom: 0;
  margin: 10px 0;
  padding: 20px 24px;
  letter-spacing: 1px;
  color: #4e958b;
  /*font-family: "Grotesque Black", sans-serif;*/
  font-size: .9rem;
  text-transform: uppercase;
  cursor: pointer;
  opacity: 0;
  transition: 0.5s 0.25s cubic-bezier(0.17, 0.67, 0.5, 1.03);
}
div.card:hover .infos {
  -webkit-transform: translateY(-260px);
          transform: translateY(-260px);
}
div.card:hover .infos .seats, div.card:hover .infos .txt, div.card:hover .infos .details {
  opacity: 1;
}.btReadall
{
    margin-top: -8%;
    font-size:18px;
    width:120px;
    height:40px;
    margin-right: 8%;
    margin-bottom: 2%;
}
#P1{margin-top:0%;}
#P2{margin-top:0%;}
#btmenu{margin-top:5%;margin-bottom:5%;margin-right: 18%;}
.bgimg-1{ display:none;}
#menuT{/*width:40%;margin-left:13%;margin-top:80%;margin-top:-23.5%;*//*width: 40%;
    margin-left: 9%;
    margin-top: -20.2%;*/width: 40%;
    margin-left: 12%;
    margin-top: -18%;}
@media screen and (min-width:1450px) and (max-width:1700px)
 {
    .bgimg{
    background-image: url("image/BG.jpg");
    
    }
 .hdtext
    {
       /*background-color:#593674;
      border-radius: 10px;
      box-shadow: 0px 0px 43px -10px black;*/
      padding:30px 50px;
    width:700px;
     height:600px;
     
        }  
.hdtext2
{
     font-size:1.7rem;
    }
.R1
{
    width:35%; 
    height:10%;
    font-size:1em;
} 
.R2
{
    width:50%; height:20%;margin-left:-5%;margin-right:1%;font-size:1em;
    
}
    .mapasia
{
    max-width:65rem;
    max-height:65rem;
    height: auto;
    padding:10px 50px 20px 50px;
    margin-left:10em;
    margin-top:-0.8%;
    padding :0px;
}  
.arrow
{
    margin-top:32%;
   
} 
div.card {
    /* position: absolute; */
    /* left: 50%; */
    margin-top: 5%;
    margin-left: 20%;
    width: 340px;
    height: 340px;
    -webkit-transform: translate(-50%, -50%) translateZ(0);
    transform: translate(-50%, -50%) translateZ(0);
    border-radius: 3px;
    box-shadow: 0 1px 4px rgba(0, 0, 0, 0.3);
    overflow: hidden;
    display: block;
}.news
{
    margin-top:11%;
    margin-left: 15%;
}#P1{margin-top: 2%;}
#P2{margin-top: 2%;}
#btmenu{margin-top:5%;margin-bottom:5%;margin-right: 10%;}
 #menuT {
   /*width : 40%;
    margin-left: 11%;
    margin-top: -27%;*/
    width: 40%;
    margin-left: 9%;
    margin-top: -20.2%;
}
}
@media screen and (min-width: 980px) and (max-width:1449px) {
    .bgimg{
   background-image: url("image/BG.jpg");
 
    }.hdtext
    {
       /*background-color:#593674;
      border-radius: 10px;
      box-shadow: 0px 0px 43px -10px black;*/
      padding:30px 50px;
    width:700px;
     height:600px;
     
        }  
.hdtext2
{
     font-size:1.7rem;
    }
.R1
{
    width:35%; 
    height:10%;
    font-size:1em;
} 
.R2
{
    width:50%; height:20%;margin-left:-5%;margin-right:1%;font-size:1em;
    
}
.mapasia
{
    max-width:60rem;
    max-height:60rem;
    height: auto;
    padding:10px 50px 20px 50px;
    margin-left:10em;
    margin-top:-2%;
    padding :0px;
    
}  
.arrow
{
    margin-top:32%;
     margin-right:5%;
}div.card {
    /* position: absolute; */
    /* left: 50%; */
    margin-top: 5%;
    margin-left: 20%;
    width: 290px;
    height: 290px;
    -webkit-transform: translate(-50%, -50%) translateZ(0);
    transform: translate(-50%, -50%) translateZ(0);
    border-radius: 3px;
    box-shadow: 0 1px 4px rgba(0, 0, 0, 0.3);
    overflow: hidden;
    display: block;
}div.card .infos .txt {
    font-size: .8rem;
    color: rgba(21, 37, 54, 0.7);
    opacity: 0;
    transition: 0.5s 0.25s cubic-bezier(0.17, 0.67, 0.5, 1.03);
}div.card .infos .details {
  position: relative;
  padding: 0px;
}
.txt {
    height: 4em;
    white-space: wrap;
    overflow: hidden;
    text-overflow: ellipsis;
    margin-top: -2%;
}
.news
{
    margin-top:10%;
    margin-left: 15%;
   
}.btReadall
{
    margin-top: -9%;
    font-size:18px;
    width:120px;
    height:40px;
    margin-right: 7%;
    margin-bottom: 2%;
}#P1{margin-top: 2%;}
#P2{margin-top: 2%;}
#btmenu{margin-top:5%;margin-bottom:5%;margin-right: 10%;}
#menuT {
    /*width: 40%;
    margin-left: 11%;
    margin-top: -27%;*/
    width: 40%;
    margin-left: 9%;
    margin-top: -20.2%;
    
}

}
 @media screen and (min-width: 768px) and (max-width:1024px)
 {
     .hdtext
    {
      background-color:#593674;
      border-radius: 20px;
      box-shadow: 0px 0px 43px -10px black;
        margin-top:-0.5%;
    }
    div.card {
    /* position: absolute; */
    /* left: 50%; */
    margin-top: 45%;
    margin-left: 20%;
    width: 290px;
    height: 290px;
    -webkit-transform: translate(-50%, -50%) translateZ(0);
    transform: translate(-50%, -50%) translateZ(0);
    border-radius: 3px;
    box-shadow: 0 1px 4px rgba(0, 0, 0, 0.3);
    overflow: hidden;
    display: block;
 }
 
 }
 @media screen and (min-width: 768px) and (max-width:979px) 
 {
     .bgimg{
background-image: url("image/BG.jpg");

    }.hdtext
    {
     /* background-color:#593674;
      border-radius: 20px;
      box-shadow: 0px 0px 43px -10px black;*/
        margin-top:-0.5%;
    }
   .mapasia
{
    max-width:50rem;
    max-height:50rem;
    height: auto;
    padding:10px 50px 20px 50px;
    margin-left:5%;
	margin-top:5%;
    padding :0px;
}  .arrow
{
   margin-top:18%;
   margin-bottom:10%;

}#P1{margin-top: 2%;}
#P2{margin-top: 2%;}

}@media screen and (min-width: 480px) and (max-width:767px) and (orientation : portrait)
 {     
   .bgimg{
background-image: url("image/BG.jpg");

    }/*.hdtext
    {
      background-color:#593674;
      border-radius: 20px;
      box-shadow: 0px 0px 43px -10px black;
        
    }*/
   .mapasia
{
    max-width:100%;
    max-height:100%;
    height: auto;
    padding:10px 50px 20px 50px;
    margin-left:3%;
	margin-top:5%;
    padding :0px;
}  #P1{margin-top: 2%;}
#P2{margin-top: 2%;}

 }
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
 {     
    .mapasia{
	/*top: calc(75% - 75px);
	left: calc(35% - 90px);*/
	min-width:125%;
    min-height:40%;
	margin-left:-5%;
	margin-top:5%;
	padding :0px;
    }
    .arrow
   {
    margin-top:10%;
   
    }.popup
{
 
  max-width:100%;   
    
 }#P1{margin-top: 2%;}
#P2{margin-top: 2%;}
}
@media screen and (min-width: 360px) and (max-width:376px) and (orientation : portrait)
 {     
    .mapasia{
	/*top: calc(75% - 75px);
	left: calc(35% - 90px);*/
	min-width:125%;
    min-height:40%;
	margin-left:-5%;
	margin-top:5%;
	padding :0px;
    }
    .arrow
{
   margin-top:10%;
   margin-bottom:10%;
    }.popup
{
 
  max-width:100%;   
    
 }.m1
 {
     margin-top:1%;
     font-size:0.8em;
     text-shadow:2px 1px 0 #444;
     
}
.m2
{
  margin-top:-3%;
  font-size:0.5em;
      
    
}   #P1{margin-top: 2%;}
#P2{margin-top: 2%;}
}
@media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
{
    .mapasia{
	/*top: calc(75% - 75px);
	left: calc(35% - 90px);*/
	min-width:125%;
    min-height:40%;
	margin-left:-5%;
	margin-top:5%;
	padding :0px;
    }
    .arrow
{
   margin-top:10%;
   margin-bottom:10%;
    }.popup
{
 
  max-width:100%;   
    
 }.m1
 {
     margin-top:1%;
     font-size:0.8em;
     text-shadow:2px 1px 0 #444;
     
}
.m2
{
  margin-top:-3%;
  font-size:0.5em;
      
    
}   #P1{margin-top: 2%;}
#P2{margin-top: 2%;}
    
    }

</style>
<!-- First Parallax Image with Logo Text -->
<section id="page1"  ><%--class="intro"--%>
<header class=" w3-mobile w3-display-container bgimg w3-mobile w3-hide-medium w3-hide-small " id="home">
  <div style="white-space:nowrap;margin-right:2%; " class="w3-display-right hdtext">
    <span class="w3-center w3-padding">
    <center>
    <img src="image/logo_dlt.png" style="width:15%;" class="w3-round w3-center ae-1 fromCenter">
    <p class=" w3-text-amber w3-show w3-wide hdtext2"><b>Foreign Vehicle Permit</b></p>
    <p class=" w3-text-white " style="margin-top:-2%;font-size:1em">Department of Land Transport</p>   
    </center>
   <%--  <center class="w3-row-padding" style="margin-top:5%">
    <a   href="OtherCovntries.aspx" class=" w3-amber w3-large w3-round-large w3-padding w3-button w3-btn R3"><b>Apply for a Permit</b></a>
    </center>--%>
   <center class="w3-row-padding" style="margin-top:5%">
    <a <%--id="permit"--%> href="OtherCovntries.aspx" class=" w3-amber w3-large w3-round-large w3-padding w3-button w3-btn R1"><b>Apply for a Permit</b></a>
    <a <%--id="mana"--%> href="ManageApp.aspx?status=2" class=" w3-deep-orange w3-round-large w3-padding  w3-large w3-right w3-button w3-btn R2" ><b>Manage Application / Permit </b></a>
    </center>
    </span>
    <center>
    <img src="image/Car.png" style=" width:90%; height:30%;margin-top:5%"/>
    </center>
   <div class=" w3-row-padding" id="btmenu">
   <a class="w3-dropdown-click">
     </a><a onclick="menu2()" class="w3-padding  w3-btn  w3-border w3-round-large w3-text-white" style="width:45%; height:10%;font-size:1rem;margin-left:18%;"><img src="image/login-square.png"> For Thai Travel Agency</a>
    <div id="menuT" class="w3-dropdown-content w3-bar-block w3-card-4 w3-animate-zoom">
      <a href="Login.aspx" class="w3-bar-item w3-button" target="_self" >Login</a>
      <a href="RegisterTravel.aspx" class="w3-bar-item w3-button" target="_self">Register</a>
     <%-- <a href="ManageApp.aspx?status=2" class="w3-bar-item w3-button" target="_self">Manage Application / Permit</a>--%>
    </div>
  
  <a href="Login.aspx" class="w3-padding  w3-btn  w3-border w3-round-large w3-text-white" style="width:45%; height:10%;font-size:1rem;"><img src="image/login-square.png">  For Land Transport Officer</a>
  </div>
  </div>
</header>
<!-- Medium-Small Size -->
<header  class=" w3-mobile w3-display-container w3-mobile w3-hide-large bgMS " id="home2" style="overflow: scroll; min-height: 100%; height: 100%; background-position: center;background-repeat: no-repeat;background-size: cover;" >
  <div  class=" w3-display-middle w3-padding-16" >
    <span class="w3-center  w3-xlarge  ">
    <center>
    <img src="image/logo_dlt.png" style="margin-top:-5%;width:30%;"> 
    <p class=" w3-text-amber w3-show w3-wide m1"><b>Foreign Vehicle Permit</b></p>
    <p class="  w3-text-white m2"> Planning Division, Department of Land Transport</p>   
   </center>

   <%--<div style="margin-top:5% " class="w3-row-padding">
   <a class=" w3-amber w3-large w3-round-large w3-padding w3-button w3-btn "  href="OtherCovntries.aspx" style="width:100%; height:15%; margin-bottom:-3%"><b>Apply for a Permit</b></a>
   </div>--%>
    <div style="margin-top:5% " class="w3-row-padding">
    <a  <%--id="permit"--%> href="OtherCovntries.aspx" class=" w3-amber w3-large w3-round-large w3-padding w3-button w3-btn " style="width:100%; height:15%;"><b>Apply for a Permit</b></a>
    <a <%--id="mana"--%> href="ManageApp.aspx?status=2" class="w3-deep-orange w3-large  w3-round-large w3-padding  w3-button w3-btn" style="width:100%; height:15%;margin-top:5%;"><b>Manage Application / Permit </b></a>
    </div>

    </span>
  
    <div  class=" w3-row" style="margin-top:5%;" >
   <%-- <a href="Login.aspx" class="w3-container w3-half w3-padding  w3-btn  w3-border w3-round-large w3-text-white w3-hover-dark-gray" style="margin-top:3%;width:100%; height:10%;font-size:15px"><img src="image/login-square.png" /> Login</a>--%>
   <a class="w3-dropdown-click">
  <a  onclick="menu3()" class="w3-container w3-half w3-padding  w3-btn  w3-border w3-round-large w3-text-white w3-hover-dark-gray" style="margin-top:3%;width:100%; height:10%;font-size:15px"><img src="image/login-square.png" /> For Thai Travel Agency</a>
  <div id="menuTs" class="w3-dropdown-content w3-bar-block w3-card-4 w3-animate-zoom" style="/*width: 100%;height: 15%;font-size: 12px;margin-top: -65%;*/ width: 100%;height: 15%;font-size: 12px;margin-top: -30%">
      <a href="Login.aspx" class="w3-bar-item w3-button"  >Login</a>
      <a href="RegisterTravel.aspx" class="w3-bar-item w3-button" >Register</a>
     <%-- <a href="ManageApp.aspx?status=2" class="w3-bar-item w3-button" >Manage Application / Permit</a>--%>
    </div>
</a>
  <a href="Login.aspx" class="w3-container w3-half w3-padding  w3-btn  w3-border w3-round-large w3-text-white w3-hover-dark-gray" style="margin-top:3%;width:100%; height:10%;font-size:15px"><img src="image/login-square.png" /> For Land Transport Office</a>
    
    </div>
  </div>
</header>

<div class="w3-top " style="height:75px"> 
<a class="w3-bar-item w3-button w3-text-white w3-left w3-hide-large w3-hide-medium " onclick="w3_open()" style="margin-left: 5%;font-size: 2rem;margin-top: 3%;"><i class="fa fa-bars w3-left"></i></a>
  <div class="w3-bar " id="myNavbar" style="margin-left:15%;">
  <%--<div class=" w3-auto w3-left w3-medium w3-button w3-purple " onclick="w3_open()">&#9776; </div> --%>

    

    <div  class="w3-hide-small" style="margin-right:20%;">
    <a  class=" w3-bar-item w3-button w3-text-white w3-hide-small w3-right " style="margin-right:1%;" onclick="w3_open()"><i class="fa fa-bars" style=" margin-right:5px"></i><b style="font-size:1.2em">Menu</b></a>
    <a href="News.aspx" id="newsbt" class="w3-bar-item w3-button w3-text-white w3-hide-small w3-right " style="margin-right:1%;"><b style="font-size:1.2em">News<b /></a>
     
    <div class="w3-dropdown-hover w3-text-white w3-hide-small w3-right "  style="margin-right:1%; width: 160px; background-color:inherit;" >
    <a class="w3-button "  > <b style="font-size:1.2em">About FVP<b /> <i class="fa fa-caret-down"></i></a>     
    <div class="w3-dropdown-content w3-card-4 w3-bar-block">
        <a href="Upload/FileManual/Final FVP Brochure ENG-V1.pdf"class="w3-bar-item w3-button w3-theme-l4 " target="_blank"> <b style="font-size:1em">English Brochure<b /> </a>
        <a href="Upload/FileManual/Final FVP Brochure TH-V1.pdf" class="w3-bar-item w3-button w3-theme-l4 " target="_blank"> <b style="font-size:1em">Thai Brochure<b /> </a>
    </div>
    </div>
    
 
    </div>
  
    
  </div>
</div>
</section>
<script>
    function menu2() {
        var x = document.getElementById("menuT");
        if (x.className.indexOf("w3-show") == -1) {
            x.className += " w3-show";
        } else {
            x.className = x.className.replace(" w3-show","");
        }
    }
    function menu3() {
        var x = document.getElementById("menuTs");
        if (x.className.indexOf("w3-show") == -1) {
            x.className += " w3-show";
        } else {
            x.className = x.className.replace(" w3-show", "");
        }
    }

    $(document).ready(function () {

     $("#permit").click(function () {
            $("#page1").hide();
            $("#map2pg").hide();
            $("#News").hide();
            $("#mappg").show();
            $("#mappg").css('display', 'block');
            $("#mappg").css('position', 'relative');
        });
        $("#mana").click(function () {
            $("#page1").hide();
            $("#mappg").hide();
            $("#News").hide();
            $("#map2pg").show();
            $('#map2pg').css('display', 'block');
            $("#map2pg").css('position', 'relative');
        });
        $("#newsbt").click(function () {
            $("#page1").hide();
            $("#mappg").hide();
            $("#map2pg").hide();
            $("#News").show();
            $('#News').css('display', 'block');
            $("#map2pg").css('position', 'relative');
        });
        $("#permit2").click(function () {
            $("#page1").hide();
            $("#map2pg").hide();
            $("#News").hide();
            $("#mappg").show();
            $('#mappg').css('display', 'block');
            $("#mappg").css('position', 'relative');
        });
        $("#mana2").click(function () {
            $("#page1").hide();
            $("#mappg").hide();
            $("#News").hide();
            $("#map2pg").show();
            $('#map2pg').css('display', 'block');
            $("#map2pg").css('position', 'relative');
        });
        $("#Img1").click(function () {
            $("#page1").show();
            $("#mappg").hide();
            $("#map2pg").hide();
            $("#News").hide();
        });
        $("#Img2").click(function () {
            $("#page1").show();
            $("#mappg").hide();
            $("#map2pg").hide();
            $("#News").hide();
        });
        $("#Img3").click(function () {
            $("#page1").show();
            $("#mappg").hide();
            $("#map2pg").hide();
            $("#News").hide();
        });
        $("#Img4").click(function () {
            $("#page1").show();
            $("#mappg").hide();
            $("#map2pg").hide();
            $("#News").hide();
        });
        
    }); 
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="topbar" Runat="Server">
  
</asp:Content>


 <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <section id="mappg" style=" position: fixed" >

 <div class="bgimg-2 " style="min-height: 100%;">
 
 
 <header class="w3-padding w3-hide-small w3-hide-medium"> 

  <p class=" w3-text-white w3-round-large w3-center w3-xxlarge" id="P1"><b>Apply for a Permit</b></p>
  <p class="w3-text-white  w3-center w3-xlarge" style="margin-top:-1%;">Please select where you car is registered</p>
 </header>

  <!--Mobile Size-->
  <header class="w3-padding w3-hide-large w3-light-gray w3-card-2"> 
  <h1 class=" w3-text-purple w3-round-large w3-center w3-xlarge"style="margin-top:10px;"><b>Apply for a Permit</b></h1>
  <h3 class=" w3-text-red w3-center w3-hide-large ">Please select where you car is registered<br /><br /></h3>
  </header>

 
 <center>
 <img  src="image/map1536x864.png" id="1" alt="Planets" usemap="#planetmap" class="mapasia" > 
<img src="image/arrow-up.png" class="w3-right w3-hide-medium  arrow w3-hide-small"  class=" w3-right" onclick="topFunction()" id="Img1" title="Go to top" />
<img src="image/arrow-up.png" class="w3-hide-large arrow" style=" cursor: pointer;width:1.5em; height:1.5em;"  class=" w3-right" onclick="topFunction()" id="Img3" title="Go to top" />
<map name="planetmap" >
<%-- Myanmar--%>
 <area onclick="document.getElementById('id01').style.display='block'" shape="circle" coords="300,215,90" alt="Myanmar" title="Myanmar">
<%-- Malaysia--%>
  <area onclick="document.getElementById('id02').style.display='block'"  shape="circle" coords="509,688,90" alt="Malaysia" title="Malaysia">
 <%--Laos--%>
  <area onclick="document.getElementById('id03').style.display='block'" shape="circle" coords="1090,210,95" alt="Laos" title="Laos" >
 <%--Cambodia--%>
  <area onclick="document.getElementById('id04').style.display='block'" shape="circle" coords="1108,496,90" alt="Cambodia" title="Cambodia">
<%--Singapore--%>
  <area onclick="document.getElementById('id05').style.display='block'" shape="circle" coords="990,727,80" alt="Singapore" title="Singapore">
 <%-- Other--%>
  <area onclick="document.getElementById('id06').style.display='block'" shape="circle" coords="166,718,80" alt="Other" title="Other Countries">
</map>
</center>
<script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
<!--<script src="./image-map.min.js"></script>-->
<script src="Scripts/image-map.js"></script>
<script>

    /* JavaScript */
    ImageMap('img[usemap]', 500);
    /*$('#mappg').css('display', 'block');*/
    /* jQuery */
   // $('img[usemap]').imageMap(500);
 
   
</script>

 </div>
 
 <%-- Myanmar--%>
 <div id="id01" class="w3-modal">
    <div class="w3-modal-content w3-card-4 w3-round-xlarge w3-purple w3-text-white w3-display-middle popup">
  
      <div class="w3-center"><br>
        <span onclick="document.getElementById('id01').style.display='none'" class="w3-button w3-xxlarge w3-transparent w3-display-topright" title="Close Modal">×</span>
      
      </div>
     <a class="w3-hover-dark-gray w3-padding  w3-block "  onclick="myFunction('DemoMyanmar')" style="cursor:pointer;"><img src="image/Icon2/motorcycle.png" style=" margin-right:3%" /><b>Motorcycle</b></a>
    <div id="DemoMyanmar" class="w3-hide w3-container w3-card w3-white w3-text-dark-gray">
    
      <a href="Register.aspx?country=1&type=1&regis=1&group=1" class="w3-bar-item w3-button w3-hover-dark-gray w3-large"  style="width:100%;overflow:auto;" target="_blank">1 Year Permit, 1 Province</a><br/>
      <a href="Register.aspx?country=1&type=1&regis=2&group=2" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">120 Day Permit, Multiple Provinces</a><br/>

  </div>
      
    <a class="w3-hover-dark-gray w3-padding  w3-block "  onclick="myFunction('DemoMyanmar2')" style="cursor:pointer;"><img src="image/Icon2/car2.png" style=" margin-right:3%" /><b>Private Vehicle</b></a>
    <div id="DemoMyanmar2" class="w3-hide w3-container w3-card w3-white w3-text-dark-gray">
    
      <a href="Register.aspx?country=1&type=2&regis=1&group=1" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">1 Year Permit, 1 Province</a><br/>
      <a href="Register.aspx?country=1&type=2&regis=2&group=2" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">120 Day Permit, Multiple Provinces</a><br/>

  </div>

  <a class="w3-hover-dark-gray w3-padding  w3-block "  onclick="myFunction('DemoMyanmar3')" style="cursor:pointer;"><img src="image/Icon2/pickup.png" style=" margin-right:3%" /><b>Pickup Truck</b></a>
  <div id="DemoMyanmar3" class="w3-hide w3-container w3-card w3-white w3-text-dark-gray">
    
      <a href="Register.aspx?country=1&type=4&regis=1&group=1" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">1 Year Permit, 1 Province</a><br/>
      <a href="Register.aspx?country=1&type=4&regis=2&group=2" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">120 Day Permit, Multiple Provinces</a><br/>
  </div>

<a class="w3-hover-dark-gray w3-padding  w3-block "  onclick="myFunction('DemoMyanmar4')" style="cursor:pointer;"><img src="image/Icon2/van.png" style=" margin-right:3%" /><b>Van</b></a>
  <div id="DemoMyanmar4" class="w3-hide w3-container w3-card w3-white w3-text-dark-gray">
    
      <a href="Register.aspx?country=1&type=5&regis=1&group=1" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">1 Year Permit, 1 Province</a><br/>
      <a href="Register.aspx?country=1&type=5&regis=2&group=2" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">120 Day Permit, Multiple Provinces</a><br/>
  </div>


    <!--a class="w3-hover-dark-gray w3-padding w3-block w3-text-white" style="width:100%;overflow:auto;" href="RegisterCommerce.aspx" target="_blank"><img src="image/Icon2/bus2.png" style=" margin-right:3%" /><b>Bus</b></a>
    <a class="w3-hover-dark-gray w3-padding w3-block  w3-text-white" style="width:100%;overflow:auto;" href="RegisterCommerce.aspx" target="_blank"><img src="image/Icon2/lorry.png" style=" margin-right:3%" /><b>Truck</b></a-->

    </div>

  </div>
  <%--Malaysia--%>
 <div id="id02" class="w3-modal">
    <div class="w3-modal-content w3-card-4  w3-round-xlarge w3-purple w3-text-white w3-display-middle popup">
  
      <div class="w3-center"><br>
        <span onclick="document.getElementById('id02').style.display='none'" class="w3-button w3-xxlarge w3-transparent w3-display-topright" title="Close Modal">×</span>
      </div>
       <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="cursor: pointer;" href=" Register.aspx?country=1&type=1&regis=4" target="_blank"><img src="image/Icon2/motorcycle.png" style=" margin-right:3%" /><b>Motorcycle</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="cursor: pointer;" href="Register.aspx?country=1&type=2&regis=4" target="_blank"><img src="image/Icon2/car2.png" style=" margin-right:3%" /><b>Private Vehicle</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="cursor: pointer;" href="Register.aspx?country=1&type=4&regis=4" target="_blank"><img src="image/Icon2/pickup.png" style=" margin-right:3%" /><b>Pickup Truck</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="cursor: pointer;" href="Register.aspx?country=1&type=5&regis=4" target="_blank"><img src="image/Icon2/van.png" style=" margin-right:3%" /><b>Van</b></a>
    <!--a class="w3-hover-dark-gray w3-padding w3-block w3-text-white"  href="RegisterCommerce.aspx" target="_blank"><img src="image/Icon2/bus2.png" style=" margin-right:3%" /><b>Bus</b></a>
    <a class="w3-hover-dark-gray w3-padding w3-block  w3-text-white" href="RegisterCommerce.aspx" target="_blank"><img src="image/Icon2/lorry.png" style=" margin-right:3%" /><b>Truck</b></a-->
     
      
    </div>

  </div>
    <%--Laos--%>
 <div id="id03" class="w3-modal">
    <div class="w3-modal-content w3-card-4 w3-round-xlarge w3-purple w3-text-white w3-display-middle popup" >
  
      <div class="w3-center"><br>
        <span onclick="document.getElementById('id03').style.display='none'" class="w3-button w3-xxlarge w3-transparent w3-display-topright" title="Close Modal">×</span>
       </div>
       <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="Register.aspx?type=1&regis=3" target="_blank"><img src="image/Icon2/motorcycle.png" style=" margin-right:3%" /><b>Motorcycle</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="Register.aspx?type=2&regis=3" target="_blank"><img src="image/Icon2/car2.png" style=" margin-right:3%" /><b>Private Vehicle</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="Register.aspx?type=4&regis=3" target="_blank"><img src="image/Icon2/pickup.png" style=" margin-right:3%" /><b>Pickup Truck</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="Register.aspx?type=5&regis=3" target="_blank"><img src="image/Icon2/van.png" style=" margin-right:3%" /><b>Van</b></a>
    <%--<a class="w3-hover-dark-gray w3-padding w3-block w3-text-white" style="width:100%;" href="RegisterCommerce.aspx"><img src="image/Icon2/bus.png" style=" margin-right:3%" /><b>Bus</b></a>
    <a class="w3-hover-dark-gray w3-padding w3-block  w3-text-white" style="width:100%;" href="RegisterCommerce.aspx"><img src="image/Icon2/truck.png" style=" margin-right:3%" /><b>Truck</b></a>--%>
      </div>
      
   

  </div>
   <%-- Cambodia--%>
 <div id="id04" class="w3-modal">
    <div class="w3-modal-content w3-card-4 w3-round-xlarge w3-purple w3-text-white w3-display-middle popup">
  
      <div class="w3-center"><br>
        <span onclick="document.getElementById('id04').style.display='none'" class="w3-button w3-xxlarge w3-transparent w3-display-topright" title="Close Modal">×</span>
      
      </div>
    <a class="w3-hover-dark-gray w3-padding  w3-block "  onclick="myFunction('DemoCambodia')" style="cursor:pointer;"><img src="image/Icon2/motorcycle.png" style=" margin-right:3%" /><b>Motorcycle</b></a>
    <div id="DemoCambodia" class="w3-hide w3-container w3-card w3-white w3-text-dark-gray">
    
      <a href="Register.aspx?type=1&regis=1&group=1" class="w3-bar-item w3-button w3-hover-dark-gray w3-large"  style="width:100%;overflow:auto;" target="_blank">1 Year Permit, 1 Province</a><br/>
      <a href="Register.aspx?type=1&regis=2&group=2" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">120 Day Permit, Multiple Provinces</a><br/>

  </div>
      
    <a class="w3-hover-dark-gray w3-padding  w3-block "  onclick="myFunction('DemoCambodia2')" style="cursor:pointer;"><img src="image/Icon2/car2.png" style=" margin-right:3%" /><b>Private Vehicle</b></a>
    <div id="DemoCambodia2" class="w3-hide w3-container w3-card w3-white w3-text-dark-gray">
    
      <a href="Register.aspx?type=2&regis=1&group=1" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">1 Year Permit, 1 Province</a><br/>
      <a href="Register.aspx?type=2&regis=2&group=2" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">120 Day Permit, Multiple Provinces</a><br/>

  </div>
  <a class="w3-hover-dark-gray w3-padding  w3-block "  onclick="myFunction('DemoCambodia3')" style="cursor:pointer;"><img src="image/Icon2/pickup.png" style=" margin-right:3%" /><b>Pickup Truck</b></a>
    <div id="DemoCambodia3" class="w3-hide w3-container w3-card w3-white w3-text-dark-gray">
    
      <a href="Register.aspx?type=4&regis=1&group=1" class="w3-bar-item w3-button w3-hover-dark-gray w3-large"  style="width:100%;overflow:auto;" target="_blank">1 Year Permit, 1 Province</a><br/>
      <a href="Register.aspx?type=4&regis=2&group=2" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">120 Day Permit, Multiple Provinces</a><br/>

  </div>
  <a class="w3-hover-dark-gray w3-padding  w3-block "  onclick="myFunction('DemoCambodia4')" style="cursor:pointer;"><img src="image/Icon2/van.png" style=" margin-right:3%" /><b>Van</b></a>
    <div id="DemoCambodia4" class="w3-hide w3-container w3-card w3-white w3-text-dark-gray">
    
      <a href="Register.aspx?type=5&regis=1&group=1" class="w3-bar-item w3-button w3-hover-dark-gray w3-large"  style="width:100%;overflow:auto;" target="_blank">1 Year Permit, 1 Province</a><br/>
      <a href="Register.aspx?type=5&regis=2&group=2" class="w3-bar-item w3-button w3-hover-dark-gray w3-large" style="width:100%;overflow:auto;" target="_blank">120 Day Permit, Multiple Provinces</a><br/>

  </div>
    <!--a class="w3-hover-dark-gray w3-padding w3-block w3-text-white" style="width:100%;" href="RegisterCommerce.aspx" target="_blank"><img src="image/Icon2/bus2.png" style=" margin-right:3%" /><b>Bus</b></a>
    <a class="w3-hover-dark-gray w3-padding w3-block  w3-text-white" style="width:100%;" href="RegisterCommerce.aspx" target="_blank"><img src="image/Icon2/lorry.png" style=" margin-right:3%" /><b>Truck</b></a-->

    </div>
    </div>

  </div>
   <%--Singapore--%>
 <div id="id05" class="w3-modal">
    <div class="w3-modal-content w3-card-4  w3-round-xlarge w3-purple w3-text-white w3-display-middle popup" >
  
      <div class="w3-center"><br>
        <span onclick="document.getElementById('id05').style.display='none'" class="w3-button w3-xxlarge w3-transparent w3-display-topright" title="Close Modal">×</span>
     </div>
     <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="Register.aspx?type=1&regis=4" target="_blank"><img src="image/Icon2/motorcycle.png" style=" margin-right:3%" /><b>Motorcycle</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="Register.aspx?type=2&regis=4" target="_blank"><img src="image/Icon2/car2.png" style=" margin-right:3%" /><b>Private Vehicle</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="Register.aspx?type=4&regis=4" target="_blank"><img src="image/Icon2/pickup.png" style=" margin-right:3%" /><b>Pickup Truck</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="Register.aspx?type=5&regis=4" target="_blank"><img src="image/Icon2/van.png" style=" margin-right:3%" /><b>Van</b></a>
    <!--a class="w3-hover-dark-gray w3-padding w3-block w3-text-white" style="width:100%;" href="RegisterCommerce.aspx" target="_blank"><img src="image/Icon2/bus2.png" style=" margin-right:3%" /><b>Bus</b></a>
    <a class="w3-hover-dark-gray w3-padding w3-block  w3-text-white" style="width:100%;" href="RegisterCommerce.aspx" target="_blank"><img src="image/Icon2/lorry.png" style=" margin-right:3%" /><b>Truck</b></a-->
      
      
    </div>

  </div>
  <%--Other Countries--%>
 <div id="id06" class="w3-modal">
    <div class="w3-modal-content w3-card-4  w3-round-xlarge w3-purple w3-text-white w3-display-middle popup" >
  
      <div class="w3-center"><br>
        <span onclick="document.getElementById('id06').style.display='none'" class="w3-button w3-xxlarge w3-transparent w3-display-topright" title="Close Modal">×</span>
     </div>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="OtherCovntries.aspx" target="_blank"><img src="image/Icon2/motorcycle.png" style=" margin-right:3%" /><b>Motorcycle</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="OtherCovntries.aspx" target="_blank"><img src="image/Icon2/car2.png" style=" margin-right:3%" /><b>Private Vehicle</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="OtherCovntries.aspx" target="_blank"><img src="image/Icon2/pickup.png" style=" margin-right:3%" /><b>Pickup Truck</b></a>
      <a class="w3-hover-dark-gray w3-padding  w3-block w3-text-white" style="width:100%;cursor: pointer;" href="OtherCovntries.aspx" target="_blank"><img src="image/Icon2/van.png" style=" margin-right:3%" /><b>Van</b></a>
    <!--a class="w3-hover-dark-gray w3-padding w3-block w3-text-white" style="width:100%;" href="RegisterCommerce.aspx" target="_blank"><img src="image/Icon2/bus2.png" style=" margin-right:3%" /><b>Bus</b></a>
    <a class="w3-hover-dark-gray w3-padding w3-block  w3-text-white" style="width:100%;" href="RegisterCommerce.aspx" target="_blank"><img src="image/Icon2/lorry.png" style=" margin-right:3%" /><b>Truck</b></a-->
    
      
    </div>

  </div>
</section>
 <script>
         function myFunction(id) {
             var x = document.getElementById(id);
             if (x.className.indexOf("w3-show") == -1) {
                 x.className += " w3-show";
             } else {
                 x.className = x.className.replace(" w3-show", "");
             }
         }
</script>

 <section id="map2pg"  style=" position: fixed"> 
 <div class="bgimg-2 " style="min-height: 100%;">
  
  <header class="w3-padding w3-hide-small w3-hide-medium"> 
  <p class=" w3-text-white w3-round-large w3-center w3-xxlarge"  id="P2"><b>Manage Application</b></p>
  <p class="w3-text-white  w3-center  w3-xlarge" style="margin-top:-1%">Please select where you car is registered</p>
 </header>
 <!--Mobile Size-->
 <header class="w3-padding w3-hide-large w3-light-gray w3-card-2"> 
  <h1 class=" w3-text-purple w3-round-large w3-center w3-xlarge" style="margin-top:10px;" ><b>Manage Application </b></h1>
  <h3 class=" w3-text-red w3-center w3-hide-large ">Please select where you car is registered<br /><br /></h3>
  </header>
 <center>
 <img  src="image/map1536x864.png" id="2" alt="Planets" usemap="#planetmap2" class="mapasia" > 
<img src="image/arrow-up.png" class="w3-right w3-hide-medium w3-hide-small arrow" class=" w3-right" onclick="topFunction()" id="Img4" title="Go to top" /> 
<img src="image/arrow-up.png" class=" w3-hide-large arrow" style=" cursor: pointer;width:1.5em; height:1.5em;"  class=" w3-right" id="Img2" title="Go to top" />
<map name="planetmap2" style="border: 0;">
<%-- Myanmar--%>
 <area href="ManageApp.aspx?status=1" shape="circle" coords="300,215,90" alt="Myanmar" title="Myanmar" target="_blank">
<%-- Malaysia--%>
  <area href="ManageApp.aspx?status=4"  shape="circle" coords="509,688,90" alt="Malaysia" title="Malaysia" target="_blank">
 <%--Laos--%>
  <area href="ManageApp.aspx?status=3" shape="circle" coords="1090,210,95" alt="Laos" title="Laos" target="_blank">
 <%--Cambodia--%>
  <area href="ManageApp.aspx?status=1"  shape="circle" coords="1108,496,90" alt="Cambodia" title="Cambodia" target="_blank">
<%--Singapore--%>
  <area  href="ManageApp.aspx?status=4" shape="circle" coords="990,727,80" alt="Singapore" title="Singapore" target="_blank">
 <%-- Other--%>
  <area href="#" shape="circle" coords="166,718,80" alt="Other" title="Other Countries">
</map>
</center>
<script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
<!--<script src="./image-map.min.js"></script>-->
<script src="Scripts/image-map.js"></script>
<script>

    /* JavaScript */
    ImageMap('img[usemap]', 500);
    //$('#map2pg').css('display', 'block');
    /* jQuery */
    // $('img[usemap]').imageMap(500);

</script>
 </div>
</section>

<section class=" w3-hide-small" id="News" style=" position:fixed" > 
 <div class=" w3-purple"  style="min-height: 100%;font-size: 100%;">
 
    <header class="w3-hide-small" style="margin-right:5%;">
    <a  class=" w3-bar-item w3-button w3-text-white w3-hide-small w3-right " style="margin-right:1%;" onclick="w3_open()"><i class="fa fa-bars" style=" margin-right:5px"></i><b style="font-size:1.2em">Menu</b></a>
    <a   href=" index.aspx " class="w3-bar-item w3-button w3-text-white w3-hide-small w3-right " style="margin-right:1%;"><b style="font-size:1.2em">Home<b /></a>
 
    </header>

 <div> 
  <h1 class=" w3-text-white w3-xlarge w3-left-align" style="margin-left:11%;"><b style="font-size:2rem;"><br /><br />News</b></h1>
  <hr class=" w3-white" style="margin-left:11%;width:80px;margin-top:0%;" />
  </div>
<div class="w3-row-padding news">



<%Response.Write(DivNews) %>

</div>

<a href="News.aspx" class="w3-right w3-btn w3-round-large w3-text-dark-gray w3-amber w3-padding btReadall w3-half" target="_blank">Read all</a>

<%--<div class="w3-right-align ae-1 fromCenter">  <a  href="#" class="w3-btn w3-round-large w3-text-dark-gray w3-amber w3-padding w3-hide-large" style="margin-top: 2%;font-size:14px;width:90px;height:30px;margin-right: 5%;margin-bottom: 2%;">ดูทั้งหมด</a></div>--%>
 </div>
</section> 
     </b></b> 
 </asp:Content>




 <asp:Content ID="Content4" ContentPlaceHolderID="footer" Runat="Server">
     <footer class="ftbanner w3-mobile w3-hide" style="width:100%;height:15%;left:0%;buttom:0%;">
  
     
         <h2 class="w3-text-white w3-center w3-card w3-orange w3-padding-16 w3-hide-small" style="margin-bottom:2%;text-shadow:1px 1px 0 #444; width:200px; height:60px;margin-left:45%"><b style="font-size:x-large">Contact Us</b></h2>

         <div class=" w3-text-white w3-center w3-hide-small" style="font-size:x-large">
         <p> <i class="fa fa-phone w3-hover-opacity w3-text-white"></i>  โทรศัพท์ : 02-2718-443 <i class="fa fa-fax w3-hover-opacity w3-text-white" aria-hidden="true"></i>  โทรสาร : 02-2718-443</p> </br>
         </div>
         <div class=" w3-text-white w3-center w3-hide-small" style="font-size:x-large;margin-top:-2.5%">
         <p><i class="fa fa-home w3-hover-opacity w3-text-white" "></i> อาคาร4 ชั้น5 กองแผนงาน กรมการขนส่งทางบก </br> 1032 ถนนพหลโยธิน แขวงจอมพล เขตจตุจักร กรุงเทพมหานคร 10900</p>
         </div>


          <%-- size monlie--%>

          <h2 class="w3-text-white w3-center w3-card w3-orange w3-hide-large w3-small" style="margin-bottom:2%;text-shadow:1px 1px 0 #444; width:200px; height:50px;margin-left:25%"><b style="font-size:30px">Contact Us</b></h2>
         <div class=" w3-text-white w3-center  w3-hide-large" style="font-size:16px;margin-top:5%">
         <p> <i class="fa fa-phone w3-hover-opacity w3-text-white"></i>  โทรศัพท์ : 02-2718-443 <i class="fa fa-fax w3-hover-opacity w3-text-white" aria-hidden="true"></i>  โทรสาร : 02-2718-443</p> </br>
         </div>
         <div class=" w3-text-white w3-center w3-hide-large " style="font-size:16px;margin-top:-8%">
         <p><i class="fa fa-home w3-hover-opacity w3-text-white" "></i> อาคาร4 ชั้น5 กองแผนงาน กรมการขนส่งทางบก </br> 1032 ถนนพหลโยธิน แขวงจอมพล เขตจตุจักร กรุงเทพมหานคร 10900</p>
         </div>







         <img src="image/arrow-up.png " class="w3-hide-small w3-right arrow" style=" width:40px; height:40px;margin-top:-5%; margin-right:3%"  class=" w3-right" onclick="topFunction()" id="myBtn2" title="Go to top" />
         
 </footer>
      <p class="w3-center w3-amber w3-black w3-hide" style="margin-left:0%;width:100%;height:4%;margin-top:0px;font-size:0.7em;"><i class="fa fa-copyright" aria-hidden="true"></i> Copyright 2019</p>
 </asp:Content>


 