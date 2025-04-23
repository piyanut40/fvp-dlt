<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dashboard.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="Admin_Dashboard" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" Runat="Server">
 <link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />

   <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script> 
</asp:Content>
 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style>
 .topic{font-family: 'Kanit', sans-serif;color:#5e239d; font-size:16px;}
 .education {
  --bg-color: #f6665c ;
  --bg-color-light: #fbb3ae;
  --text-color-hover:#4C5656;
  --box-shadow-color:#fdd9d6 ;
}
.card {
  width: 220px;
  height: 331px;
  background: #fff;
  border-top-right-radius: 10px;
  border-top-left-radius: 10px;
  border-bottom-left-radius: 10px;
  border-bottom-right-radius: 10px;
  overflow: hidden;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  position: relative;
  box-shadow: 0 14px 26px rgba(0,0,0,0.04);
  transition: all 0.3s ease-out;
  text-decoration: none;
}

.card:hover {
  transform: translateY(-5px) scale(1.005) translateZ(0);
  box-shadow: 0 24px 36px rgba(0,0,0,0.11),
    0 24px 46px var(--box-shadow-color);
}

.card:hover .overlay {
  transform: scale(5) translateZ(0);
}

.card:hover .overlay2 {
  transform: scale(4.5) translateZ(0);
}
.card:hover .circle {
  border-color: var(--bg-color-light);
  background: var(--bg-color);
}

.card:hover .circle:after {
  background: var(--bg-color-light);
}

.card:hover p {
  color: var(--text-color-hover);

}

.card:active {
  transform: scale(1) translateZ(0);
  box-shadow: 0 15px 24px rgba(0,0,0,0.11),
    0 15px 24px var(--box-shadow-c
    olor);
}

.card p {
  font-size: 17px;
  color: #4C5656;
  margin-top: 30px;
  z-index: 1000;
  transition: color 0.3s ease-out;
}

.circle {
  width: 131px;
  height: 131px;
  border-radius: 50%;
  background: #fff;
  border: 2px solid var(--bg-color);
  display: flex;
  justify-content: center;
  align-items: center;
  position: relative;
  z-index: 1;
  top: 7px;
  left: 7px;
  transition: all 0.3s ease-out;
}

.circle:after {
  content: "";
  width: 118px;
  height: 118px;
  display: block;
  position: absolute;
  background: var(--bg-color);
  border-radius: 50%;
  transition: opacity 0.3s ease-out;
}

.circle svg {
  z-index: 10000;
  transform: translateZ(0);
}

.overlay {
  width: 118px;
  position: absolute; 
  height: 118px;
  border-radius: 50%;
  background: var(--bg-color);
  /*top: 70px;
  left: 50px;*/
  top: 20px;
  left: 51px;
  z-index: 0;
  transition: transform 0.3s ease-out;
}
.overlay2 {
  width: 118px;
  position: absolute; 
  height: 118px;
  border-radius: 50%;
  background: var(--bg-color);
  /*top: 70px;
  left: 50px;*/
  top: 31px;
  left: 53px;
  z-index: 0;
  transition: transform 0.3s ease-out;
}
 .credentialing {
  --bg-color: #B8F9D3;
  --bg-color-light: #e2fced;
  --text-color-hover: #4C5656;
  --box-shadow-color: rgba(184, 249, 211, 0.48);
}.wallet {
  --bg-color: #ffd1ff;
  --bg-color-light: #F0E7FF;
  --text-color-hover: #4C5656;
  --box-shadow-color: rgba(206, 178, 252, 0.48);
}.human-resources {
  --bg-color: #DCE9FF;
  --bg-color-light: #f1f7ff;
  --text-color-hover: #4C5656;
  --box-shadow-color: rgba(220, 233, 255, 0.48);
}.h3{font-family: 'Kanit', sans-serif;}
.wait{
  --bg-color: #ffd861;
  --bg-color-light: #ffeeba;
  --text-color-hover: #4C5656;
  --box-shadow-color: rgba(255, 215, 97, 0.48);
}.guid
{
    --bg-color: #ce6ddf ;
  --bg-color-light:#efcef4 ;
  --text-color-hover: #4C5656;
  --box-shadow-color:#efcef4;  

}
.bordertransport
{
   --bg-color: #ed4d82 ;
  --bg-color-light: #fbd2e0 ;
  --text-color-hover: #4C5656;
  --box-shadow-color: #fbd2e0;  
}
 .stopping
{
   --bg-color: #4daaf6;
  --bg-color-light: #d2eafd;
  --text-color-hover: #4C5656;
  --box-shadow-color:#d2eafd;
}
 </style>


<asp:Panel ID="pnTransport" Visible="false" runat="server">
  <div class="tabcontent container w3-hide-medium w3-hide-small" style=" margin-left:25rem; margin-right:-5rem;">
  <h1><img src="../image/Icon2/car.png" style=" font-family: 'Kanit', sans-serif;width:64px; height:64px; " /> จัดการรายการคำขอ</h1> 
</div>
<div class="tabcontent container w3-hide-large">
  <h2><img src="../image/Icon2/car.png" style=" font-family: 'Kanit', sans-serif;width:64px; height:64px; " /> จัดการรายการคำขอ</h2> 
</div>
<center>
<div class=" w3-row  container" style=" margin-left:5rem; margin-right:-5rem;">
  
<div class="w3-row-padding w3-margin-bottom mt-5">
<a class="w3-margin card education w3-quarter w3-padding mr-4" href="index.aspx?rt=2&st=0" id="officer" runat="server">
     <div class="overlay"></div>
  <div class="circle">


  <svg width="71px" height="76px"  xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" id="Layer_1" x="0px" y="0px" viewBox="0 0 512 512" style="enable-background:new 0 0 512 512;" xml:space="preserve">
<polygon style="fill:#FEBA00;" points="441.275,93.782 375.95,63.391 347.493,0 241.855,0 220.941,265.404 241.855,512 441.275,512   "/>
<rect x="42.435" style="fill:#FEE899;" width="199.419" height="512"/>
<polygon style="fill:#FEA730;" points="441.275,93.782 347.493,93.782 347.493,0 "/>
<path style="fill:#2BAED3;" d="M378.147,172.26l-20.915,91.417l20.915,91.417c50.488,0,91.417-40.929,91.417-91.417  C469.565,213.189,428.636,172.26,378.147,172.26z"/>
<path style="fill:#4CDFFD;" d="M286.73,263.677c0,50.488,40.929,91.417,91.417,91.417V172.26  C327.659,172.26,286.73,213.189,286.73,263.677z"/>
<polygon style="fill:#FFFFFF;" points="436.201,279.351 362.474,279.351 362.474,205.624 393.821,205.624 393.821,248.004   436.201,248.004 "/>
<g>
	<polygon style="fill:#FEA730;" points="217.385,132.446 142.145,132.446 121.23,148.12 142.145,163.793 217.385,163.793  "/>
	<polygon style="fill:#FEA730;" points="217.385,186.386 142.145,186.386 121.23,202.059 142.145,217.733 217.385,217.733  "/>
	<polygon style="fill:#FEA730;" points="217.385,240.327 142.145,240.327 121.23,256 142.145,271.673 217.385,271.673  "/>
	<polygon style="fill:#FEA730;" points="217.385,294.267 142.145,294.267 121.23,309.941 142.145,325.614 217.385,325.614  "/>
	<polygon style="fill:#FEA730;" points="217.385,348.207 142.145,348.207 121.23,363.88 142.145,379.554 217.385,379.554  "/>
	<polygon style="fill:#FEA730;" points="217.385,402.148 142.145,402.148 121.23,417.821 142.145,433.495 217.385,433.495  "/>
</g>
<g>
	<rect x="66.905" y="132.441" style="fill:#FEBA00;" width="75.243" height="31.347"/>
	<rect x="66.905" y="186.389" style="fill:#FEBA00;" width="75.243" height="31.347"/>
	<rect x="66.905" y="240.327" style="fill:#FEBA00;" width="75.243" height="31.347"/>
	<rect x="66.905" y="294.264" style="fill:#FEBA00;" width="75.243" height="31.347"/>
	<rect x="66.905" y="348.212" style="fill:#FEBA00;" width="75.243" height="31.347"/>
	<rect x="66.905" y="402.15" style="fill:#FEBA00;" width="75.243" height="31.347"/>
</g>
<polygon style="fill:#FEA730;" points="174.094,78.505 142.145,78.505 121.23,94.179 142.145,109.852 174.094,109.852 "/>
<rect x="66.905" y="78.503" style="fill:#FEBA00;" width="75.243" height="31.347"/>
<polyline style="fill:#FFFFFF;" points="377.841,279.351 362.474,279.351 362.474,205.624 378.23,205.624 "/>
<polyline style="fill:#EBEBEB;" points="378.23,205.624 393.821,205.624 393.821,248.004 436.201,248.004 436.201,279.351   377.841,279.351 "/>
</svg>
  </div>
  <p class="topic">รายการคำขออนุญาตใช้รถในราชอาณาจักร<br />รออนุมัติ </p>
  <h3><asp:Label runat="server" Text="0" ID="lblATourWait1"></asp:Label> รายการ</h3>
</a>

<a class="w3-margin card wallet  w3-quarter w3-padding mr-4" href="arrival.aspx?rt=2&st=1">
  <div class="overlay"></div>
  <div class="circle">
<svg  xmlns="http://www.w3.org/2000/svg"width="71px" height="76px" viewBox="0 0 512 512" >

<path fill="#359685" d="M138.064,49.625l202.437-19.692c5.908-0.394,11.028,3.545,11.815,9.452l48.443,396.997
	c0.394,5.908-3.545,11.028-9.452,11.422L188.87,467.496c-5.908,0.394-11.028-3.545-11.815-9.452L128.612,61.046
	C128.218,55.532,132.551,50.018,138.064,49.625z"/>
<path fill="#53A697" d="M330.655,54.351c-0.394-2.757-2.757-5.12-5.908-4.726L153.818,66.166
	c-2.757,0.394-5.12,2.757-4.726,5.908l9.058,90.191c0.394,2.757,2.757,5.12,5.908,4.726c2.757-0.394,5.12-2.757,4.726-5.908
	l-8.271-84.677l160.295-15.36l8.271,84.677c0.394,2.757,2.757,5.12,5.908,4.726c2.757-0.394,5.12-2.757,4.726-5.908
	C339.714,144.542,330.655,54.351,330.655,54.351z"/>
<path fill="#3DB39E" d="M207.775,0h206.769c5.908,0,11.028,4.726,11.028,11.028v411.569c0,5.908-4.726,11.028-11.028,11.028
	H207.775c-5.908,0-11.028-4.726-11.028-11.028V11.028C196.748,4.726,201.474,0,207.775,0z"/>
<path fill="#81CEC0" d="M232.194,216.615c0,43.717,35.446,78.769,78.769,78.769s78.769-35.446,78.769-78.769
	s-35.446-78.769-78.769-78.769S232.194,173.292,232.194,216.615z M268.821,214.646h5.908c1.182-9.846,6.695-17.329,12.603-20.48
	c0.788-0.394,1.969-0.788,2.757-0.788c3.151,0,5.514,2.363,5.514,5.12c0,2.363-1.182,3.545-2.363,4.332
	c-4.332,4.332-7.877,9.452-7.877,16.542c0,9.058,3.151,13.391,9.452,13.391c15.36,0,8.271-36.628,33.477-36.628
	c9.452,0,17.329,5.514,18.905,18.511h5.908c2.757,0,5.12,1.969,5.12,4.726s-2.363,4.726-5.12,4.726h-5.908
	c-1.182,7.877-4.332,14.572-9.452,18.117c-0.788,0.788-1.969,1.182-3.545,1.182c-3.151,0-5.514-2.363-5.514-5.514
	c0-1.575,0.788-2.757,2.363-4.332c3.151-3.151,5.514-8.271,5.514-14.178c0-8.271-3.938-11.422-8.271-11.422
	c-13.785,0-7.483,36.628-33.477,36.628c-11.422,0-18.905-7.089-20.48-20.48h-5.908c-2.757,0-5.12-1.969-5.12-4.726
	C263.701,216.615,266.064,214.646,268.821,214.646z M399.578,334.769c-3.151,0-5.908,2.757-5.908,5.908v61.046H228.255v-61.046
	c0-3.151-2.757-5.908-5.908-5.908s-5.908,2.757-5.908,5.908v66.954c0,3.151,2.757,5.908,5.908,5.908h177.231
	c3.151,0,5.908-2.757,5.908-5.908v-66.954C405.486,337.526,402.729,334.769,399.578,334.769z M399.578,19.692h-177.23
	c-3.151,0-5.908,2.757-5.908,5.908v66.954c0,3.151,2.757,5.908,5.908,5.908s5.908-2.757,5.908-5.908V31.508h165.415v61.046
	c0,3.151,2.757,5.908,5.908,5.908s5.908-2.757,5.908-5.908V25.6C405.486,22.449,402.729,19.692,399.578,19.692z M299.148,350.523
	c0,6.695,5.12,11.815,11.815,11.815s11.815-5.12,11.815-11.815s-5.12-11.815-11.815-11.815S299.148,344.222,299.148,350.523z
	 M322.778,82.708c0-6.695-5.12-11.815-11.815-11.815s-11.815,5.12-11.815,11.815s5.12,11.815,11.815,11.815
	S322.778,89.403,322.778,82.708z"/>
</svg>

  </div>
  <p class="topic">รายการคำขออนุญาตใช้รถในราชอาณาจักร<br />อนุมัติแล้ว (รอชำระเงิน)</p>
  <h3><asp:Label runat="server" Text="0" ID="lblATourWait2"></asp:Label> รายการ</h3>
</a>

<a class="w3-margin card credentialing  w3-quarter w3-padding mr-4" href="arrival.aspx?rt=2&st=2">
  <div class="overlay"></div>
  <div class="circle">
  <svg xmlns="http://www.w3.org/2000/svg"  width="71px" height="76px"  viewBox="0 0 512.0002 512">
<path d="m270 377c0 74.699219-60.300781 135-135 135s-135-60.300781-135-135 60.300781-135 135-135 135 60.300781 135 135zm0 0" fill="#61d7a8"/>
<path d="m270 377c0 74.699219-60.300781 135-135 135v-270c74.699219 0 135 60.300781 135 135zm0 0" fill="#00ab94"/>
<path d="m190.5 357.5-55.5 55.800781-15 15-40.5-40.800781 21-21 19.5 19.199219 15-15 34.5-34.199219zm0 0" fill="#fff5f5"/>
<path d="m190.5 357.5-55.5 55.800781v-42.601562l34.5-34.199219zm0 0" fill="#efe2dd"/>
<path d="m394.5 308.300781-42.300781 42.300781c-13.199219 13.5-31.5 19.796876-51.597657 19.796876-33.902343 0-74.101562-18-107.402343-51.597657-53.699219-53.402343-67.5-123.300781-31.800781-159l42.300781-42.300781zm0 0" fill="#fdbf00"/>
<path d="m394.5 308.300781-42.300781 42.300781c-13.199219 13.5-31.5 19.796876-51.597657 19.796876-33.902343 0-74.101562-18-107.402343-51.597657l105.898437-105.902343zm0 0" fill="#ff9100"/>
<path d="m394.5 308.300781c-12.902344 12.898438-30.601562 19.5-51.300781 19.5-7.800781 0-16.199219-.902343-24.898438-3-28.800781-6.601562-58.203125-23.699219-82.800781-48.300781s-41.699219-54-48.300781-82.796875c-7.5-31.203125-1.5-58.5 16.5-76.203125 28.199219-28.5 79.800781-25.800781 128.101562 6.300781l56.398438 56.402344c32.101562 48.296875 34.800781 99.894531 6.300781 128.097656zm0 0" fill="#596c76"/>
<path d="m394.5 308.300781c-12.902344 12.898438-30.601562 19.5-51.300781 19.5-7.800781 0-16.199219-.902343-24.898438-3-28.800781-6.601562-58.203125-23.699219-82.800781-48.300781l124.5-124.5 28.199219 28.199219c32.101562 48.300781 34.800781 99.898437 6.300781 128.101562zm0 0" fill="#465a61"/>
<path d="m491.601562 94.695312-166.699218 135.003907c-11.402344 0-22.203125-4.5-30-12.597657-8.101563-7.800781-12.601563-18.601562-12.601563-30l134.902344-166.808593c19.199219-24.597657 56.398437-27.597657 79.199219-4.800781 22.800781 22.5 20.101562 59.703124-4.800782 79.203124zm0 0" fill="#fdbf00"/>
<path d="m491.601562 94.695312-166.699218 135.003907c-11.402344 0-22.203125-4.5-30-12.597657l201.5-201.609374c22.800781 22.5 20.101562 59.703124-4.800782 79.203124zm0 0" fill="#ff9100"/>
</svg>

  </div>
  <p class="topic">รายการคำขออนุญาตใช้รถในราชอาณาจักร<br />อนุมัติแล้ว (เสร็จสมบูรณ์)</p>
  <h3><asp:Label runat="server" Text="0" ID="lblATourWait3"></asp:Label>  รายการ</h3>
</a>

<a class="w3-margin card human-resources  w3-quarter w3-padding mr-4" href="arrival.aspx?rt=2">
  <div class="overlay"></div>
  <div class="circle">

 <svg xmlns="http://www.w3.org/2000/svg" width="71px" height="76px"  viewBox="0 0 512.0002 512" >
<g>
	<path fill="#b30000" d="M449.557,235.01c-6.85-16.07-21.91-28.1-40.51-30.23l-70.54-8.06l-37.63-61.16
		c-9.62-15.64-26.67-25.17-45.03-25.17h-121.5c-31.66,0-59.43,21.15-67.83,51.68l-0.95,3.45c-2.66,9.69-7.77,18.32-14.62,25.21
		c-6.85,6.9-15.46,12.05-25.12,14.78c-10.44,2.94-17.66,12.47-17.66,23.31v67.883l38.41-8.983c0.81-1.88,1.73-3.71,2.75-5.49
		c9.59-16.61,27.44-26.93,46.6-26.93s37,10.32,46.58,26.93c1.02,1.78,1.95,3.61,2.75,5.49h163.08c0.79-1.86,1.7-3.67,2.71-5.43
		c9.58-16.65,27.45-26.99,46.64-26.99c19.16,0,37,10.32,46.58,26.93c1.02,1.78,1.95,3.61,2.75,5.49h42.82l0.27,0.03l3.12-27.4
		c0.13-1.12,0.22-2.23,0.27-3.34C453.867,249.25,452.437,241.77,449.557,235.01z"/>
	<path fill="#CCCCCC" d="M462.2,299.792L462.2,299.792c0,6.654-5.394,12.048-12.048,12.048h-38.795
		c0.05-0.92,0.08-1.85,0.08-2.78c0-7.37-1.51-14.65-4.42-21.34l43.142,0.024C456.81,287.747,462.2,293.14,462.2,299.792z"/>
	<path fill="#666666" d="M400.437,309.06c0,0.93-0.03,1.86-0.09,2.78c-1.43,22.31-19.98,39.97-42.66,39.97
		c-22.69,0-41.24-17.66-42.67-39.97c-0.06-0.92-0.09-1.85-0.09-2.78c0-7.75,2.06-15.02,5.66-21.29
		c7.38-12.83,21.23-21.47,37.1-21.47c15.84,0,29.67,8.62,37.05,21.42C398.367,294,400.437,301.29,400.437,309.06z M375.217,309.06
		c0-9.67-7.86-17.54-17.53-17.54c-9.68,0-17.54,7.87-17.54,17.54s7.86,17.54,17.54,17.54
		C367.357,326.6,375.217,318.73,375.217,309.06z"/>
	<path fill="#E6E6E6" d="M357.687,291.52c9.67,0,17.53,7.87,17.53,17.54s-7.86,17.54-17.53,17.54
		c-9.68,0-17.54-7.87-17.54-17.54C340.147,299.39,348.007,291.52,357.687,291.52z"/>
	<path fill="#CCCCCC" d="M303.927,309.06c0,0.93,0.03,1.87,0.08,2.78h-154.41c0.05-0.93,0.08-1.86,0.08-2.78
		c0-7.37-1.51-14.65-4.42-21.34h163.08C305.437,294.43,303.927,301.7,303.927,309.06z"/>
	<path fill="#9ca6a6" d="M115.967,138.39v58.33h-33.47c0,0,3.9-15.83,6.37-24.79l0.95-3.45c0.5-1.83,1.11-3.6,1.82-5.32
		C96.257,151.94,105.097,143.12,115.967,138.39z"/>
	<path fill="#9ca6a6" d="M200.027,134.55v62.17h-69.06v-62.04c1.12-0.09,2.25-0.13,3.38-0.13L200.027,134.55L200.027,134.55z
		"/>
	<path fill="#9ca6a6" d="M310.137,196.72h-95.11v-62.17h40.82c9.89,0,19.27,5.24,24.45,13.67L310.137,196.72z"/>
	<path fill="#666666" d="M138.587,311.84c-1.43,22.31-19.98,39.97-42.66,39.97c-22.69,0-41.24-17.66-42.67-39.97
		c-0.06-0.92-0.09-1.85-0.09-2.78c0-7.77,2.07-15.06,5.69-21.34c7.39-12.8,21.22-21.42,37.07-21.42c15.84,0,29.67,8.62,37.05,21.42
		c3.63,6.28,5.7,13.57,5.7,21.34C138.677,309.99,138.647,310.92,138.587,311.84z M113.467,309.06c0-9.67-7.87-17.54-17.54-17.54
		c-9.68,0-17.54,7.87-17.54,17.54s7.86,17.54,17.54,17.54C105.597,326.6,113.467,318.73,113.467,309.06z"/>
	<path fill="#E6E6E6" d="M95.927,291.52c9.67,0,17.54,7.87,17.54,17.54s-7.87,17.54-17.54,17.54
		c-9.68,0-17.54-7.87-17.54-17.54C78.387,299.39,86.247,291.52,95.927,291.52z"/>
	<path fill="#CCCCCC" d="M42.167,309.06c0,0.93,0.03,1.86,0.08,2.78H12.06C5.399,311.84,0,306.441,0,299.78l0,0
		c0-6.661,5.399-12.06,12.06-12.06h34.517C43.677,294.42,42.167,301.69,42.167,309.06z"/>
	<path fill="#CCCCCC" d="M256.236,229.631h-15.76c-3.313,0-6-2.686-6-6s2.687-6,6-6h15.76c3.313,0,6,2.686,6,6
		S259.55,229.631,256.236,229.631z"/>
	<path fill="#CCCCCC" d="M148.017,229.631h-15.76c-3.313,0-6-2.686-6-6s2.687-6,6-6h15.76c3.313,0,6,2.686,6,6
		S151.33,229.631,148.017,229.631z"/>
	<path fill="#FFFFFF" d="M453.497,257.01h-12.05c-12.15,0-22-9.85-22-22l0,0h30.11
		C452.867,242.245,454.367,249.37,453.497,257.01z"/>
	<polygon fill="#C3C9C9" points="200.027,134.68 200.027,196.72 192.997,196.72 130.967,134.68 	"/>
	<path fill="#C3C9C9" d="M310.137,196.72h-32.94l-62.17-62.17h40.82c9.89,0,19.27,5.24,24.45,13.67L310.137,196.72z"/>
	<path fill="#C3C9C9" d="M115.967,138.39v49.1l-24.33-24.33C96.257,151.94,105.097,143.12,115.967,138.39z"/>

</svg>
  </div>
  <p class="topic">รายการคำขออนุญาตใช้รถในราชอาณาจักร<br />ทั้งหมด</p>
  <h3><asp:Label runat="server" Text="0" ID="lblATourWait4"></asp:Label> รายการ</h3>
</a>

</div>
</div>
</center>
</asp:Panel>

  <asp:Panel ID="pnAdmin" Visible="false" runat="server">
 
  
  <div class="tabcontent container w3-hide-medium w3-hide-small" style=" margin-left:25rem; margin-right:-5rem;">
  <h1><img src="../image/Icon2/car.png" style=" font-family: 'Kanit', sans-serif;width:64px; height:64px; " /> จัดการรายการคำขอ</h1> 
</div>
<div class="tabcontent container w3-hide-large">
  <h2><img src="../image/Icon2/car.png" style=" font-family: 'Kanit', sans-serif;width:64px; height:64px; " /> จัดการรายการคำขอ</h2> 
</div>
<center>
<div class=" w3-row  container" style=" margin-left:5rem; margin-right:-5rem;">
  
<div class="w3-row-padding w3-margin-bottom mt-5">
<a class="w3-margin card education w3-quarter w3-padding mr-4" href="index.aspx?rt=2&st=0">
     <div class="overlay"></div>
  <div class="circle">


  <svg width="71px" height="76px"  xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" id="Layer_1" x="0px" y="0px" viewBox="0 0 512 512" style="enable-background:new 0 0 512 512;" xml:space="preserve">
<polygon style="fill:#FEBA00;" points="441.275,93.782 375.95,63.391 347.493,0 241.855,0 220.941,265.404 241.855,512 441.275,512   "/>
<rect x="42.435" style="fill:#FEE899;" width="199.419" height="512"/>
<polygon style="fill:#FEA730;" points="441.275,93.782 347.493,93.782 347.493,0 "/>
<path style="fill:#2BAED3;" d="M378.147,172.26l-20.915,91.417l20.915,91.417c50.488,0,91.417-40.929,91.417-91.417  C469.565,213.189,428.636,172.26,378.147,172.26z"/>
<path style="fill:#4CDFFD;" d="M286.73,263.677c0,50.488,40.929,91.417,91.417,91.417V172.26  C327.659,172.26,286.73,213.189,286.73,263.677z"/>
<polygon style="fill:#FFFFFF;" points="436.201,279.351 362.474,279.351 362.474,205.624 393.821,205.624 393.821,248.004   436.201,248.004 "/>
<g>
	<polygon style="fill:#FEA730;" points="217.385,132.446 142.145,132.446 121.23,148.12 142.145,163.793 217.385,163.793  "/>
	<polygon style="fill:#FEA730;" points="217.385,186.386 142.145,186.386 121.23,202.059 142.145,217.733 217.385,217.733  "/>
	<polygon style="fill:#FEA730;" points="217.385,240.327 142.145,240.327 121.23,256 142.145,271.673 217.385,271.673  "/>
	<polygon style="fill:#FEA730;" points="217.385,294.267 142.145,294.267 121.23,309.941 142.145,325.614 217.385,325.614  "/>
	<polygon style="fill:#FEA730;" points="217.385,348.207 142.145,348.207 121.23,363.88 142.145,379.554 217.385,379.554  "/>
	<polygon style="fill:#FEA730;" points="217.385,402.148 142.145,402.148 121.23,417.821 142.145,433.495 217.385,433.495  "/>
</g>
<g>
	<rect x="66.905" y="132.441" style="fill:#FEBA00;" width="75.243" height="31.347"/>
	<rect x="66.905" y="186.389" style="fill:#FEBA00;" width="75.243" height="31.347"/>
	<rect x="66.905" y="240.327" style="fill:#FEBA00;" width="75.243" height="31.347"/>
	<rect x="66.905" y="294.264" style="fill:#FEBA00;" width="75.243" height="31.347"/>
	<rect x="66.905" y="348.212" style="fill:#FEBA00;" width="75.243" height="31.347"/>
	<rect x="66.905" y="402.15" style="fill:#FEBA00;" width="75.243" height="31.347"/>
</g>
<polygon style="fill:#FEA730;" points="174.094,78.505 142.145,78.505 121.23,94.179 142.145,109.852 174.094,109.852 "/>
<rect x="66.905" y="78.503" style="fill:#FEBA00;" width="75.243" height="31.347"/>
<polyline style="fill:#FFFFFF;" points="377.841,279.351 362.474,279.351 362.474,205.624 378.23,205.624 "/>
<polyline style="fill:#EBEBEB;" points="378.23,205.624 393.821,205.624 393.821,248.004 436.201,248.004 436.201,279.351   377.841,279.351 "/>
</svg>
  </div>
  <p class="topic">รายการคำขออนุญาตใช้รถในราชอาณาจักร<br />รออนุมัติ </p>
  <h3><asp:Label runat="server" Text="0" ID="lblTourWait1"></asp:Label> รายการ</h3>
</a>

<a class="w3-margin card wallet  w3-quarter w3-padding mr-4" href="arrival.aspx?rt=2&st=1">
  <div class="overlay"></div>
  <div class="circle">
  <%--<svg xmlns="http://www.w3.org/2000/svg" width="71px" height="76px"  viewBox="0 0 512.00001 512">
<path d="m118.359375 254.6875-72.855469 49.726562c-25.132812 0-45.503906-70.101562-45.503906-95.234374 0-12.574219 5.09375-23.949219 13.332031-32.183594 8.234375-8.234375 19.605469-13.328125 32.171875-13.328125h296.351563c21.324219 0 38.597656 17.273437 38.597656 38.597656v19.355469" fill="#ce6209"/>
<path d="m275.308594 26.484375v228.203125h-225.734375v-228.203125c0-14.628906 11.855469-26.484375 26.492187-26.484375h172.75c14.628906 0 26.492188 11.855469 26.492188 26.484375zm0 0" fill="#3c3f4d"/>
<path d="m253.230469 59.703125v194.984375h-181.589844v-194.984375c0-7.375 5.984375-13.363281 13.363281-13.363281h154.867188c7.386718 0 13.359375 5.988281 13.359375 13.363281zm0 0" fill="#c4e2f2"/>
<path d="m253.234375 59.699219v241.878906c0 7.382813-5.984375 13.363281-13.359375 13.363281h-18.898438c7.378907 0 13.367188-5.980468 13.367188-13.363281v-241.878906c0-7.382813-5.988281-13.359375-13.367188-13.359375h18.898438c7.375 0 13.359375 5.976562 13.359375 13.359375zm0 0" fill="#83b2c6"/>
<path d="m400.765625 104.03125h-221.480469c-16.039062 0-29.042968 13-29.042968 29.042969v124.394531c0 16.039062 13.003906 29.042969 29.042968 29.042969h221.480469c17.378906 0 31.464844-14.089844 31.464844-31.46875v-119.546875c0-17.378906-14.085938-31.464844-31.464844-31.464844zm0 0" fill="#83b2c6"/>
<path d="m423.101562 104.03125h-221.480468c-16.039063 0-29.042969 13-29.042969 29.042969v124.394531c0 16.039062 13.003906 29.042969 29.042969 29.042969h221.480468c17.375 0 31.464844-14.089844 31.464844-31.46875v-119.546875c0-17.378906-14.089844-31.464844-31.464844-31.464844zm0 0" fill="#ff491f"/>
<path d="m172.578125 145.101562h281.988281v38.164063h-281.988281zm0 0" fill="#2d303b"/>
<path d="m106.074219 221.617188h380.8125v219.125h-380.8125zm0 0" fill="#83b2c6"/>
<path d="m131.1875 221.617188h380.8125v219.125h-380.8125zm0 0" fill="#32cc77"/>
<path d="m479.046875 367.289062v-72.214843c-22.367187 0-40.503906-18.136719-40.503906-40.503907h-233.902344c0 22.367188-18.132813 40.503907-40.5 40.503907v72.214843c22.367187 0 40.5 18.132813 40.5 40.5h233.902344c0-22.367187 18.132812-40.5 40.503906-40.5zm0 0" fill="#1fb25e"/>
<path d="m429.359375 339.027344h-25.109375c-4.335938 0-7.847656-3.511719-7.847656-7.847656 0-4.332032 3.511718-7.847657 7.847656-7.847657h25.109375c4.332031 0 7.847656 3.515625 7.847656 7.847657 0 4.335937-3.515625 7.847656-7.847656 7.847656zm0 0" fill="#32cc77"/>
<path d="m479.046875 262.410156c-6.902344 0-10.433594-8.710937-5.429687-13.503906 2.269531-2.171875 5.738281-2.78125 8.609374-1.503906 3.113282 1.386718 5.039063 4.726562 4.601563 8.128906-.496094 3.878906-3.851563 6.878906-7.78125 6.878906zm0 0" fill="#1fb25e"/>
<path d="m479.046875 415.636719c-7.039063 0-10.527344-9.042969-5.195313-13.722657 2.386719-2.089843 5.882813-2.550781 8.71875-1.128906 3.03125 1.523438 4.78125 4.945313 4.214844 8.300782-.632812 3.726562-3.949218 6.550781-7.738281 6.550781zm0 0" fill="#1fb25e"/>
<path d="m380.453125 293.285156v180.113282c0 21.324218-17.273437 38.597656-38.597656 38.597656h-296.351563c-25.132812 0-45.503906-20.371094-45.503906-45.511719v-257.304687c0 25.132812 20.371094 45.507812 45.503906 45.507812h296.351563c21.324219 0 38.597656 17.285156 38.597656 38.597656zm0 0" fill="#ff8e1d"/>
<path d="m49.574219 254.6875v257.308594h-4.070313c-25.132812 0-45.503906-20.371094-45.503906-45.511719v-257.304687c0 25.132812 20.371094 45.507812 45.503906 45.507812zm0 0" fill="#e2720e"/>
<path d="m336.515625 381.296875c0 13.839844-9.425781 25.476563-22.210937 28.835937-2.429688.636719-4.980469.984376-7.609376.984376-16.46875 0-29.820312-13.351563-29.820312-29.820313 0-16.472656 13.351562-29.820313 29.820312-29.820313 2.628907 0 5.179688.34375 7.609376.980469 12.785156 3.359375 22.210937 14.996094 22.210937 28.839844zm0 0" fill="#ffbe1d"/>
<path d="m336.515625 381.296875c0 13.839844-9.425781 25.476563-22.210937 28.835937-12.777344-3.371093-22.203126-15.003906-22.203126-28.835937 0-13.835937 9.425782-25.46875 22.203126-28.839844 12.785156 3.359375 22.210937 14.996094 22.210937 28.839844zm0 0" fill="#ffe14d"/>
</svg>--%>
<svg  xmlns="http://www.w3.org/2000/svg"width="71px" height="76px" viewBox="0 0 512 512" >
<%--<path fill="#2B8272" d="M87.258,111.458l199.286-39.385c5.908-1.182,11.422,2.757,12.603,8.271l77.982,371.791
	c1.182,5.908-2.757,11.422-8.271,12.603l-199.68,39.385c-5.908,1.182-11.422-2.757-12.603-8.271l-77.587-371.79
	C77.806,118.154,81.351,112.64,87.258,111.458z"/>--%>
<%--<path fill="#4B9587" d="M297.178,185.895L279.061,97.28c-0.394-2.757-3.545-4.726-6.302-4.332l-168.566,33.477
	c-2.757,0.394-4.726,3.545-4.332,6.302l18.117,88.615c0.394,2.757,3.545,4.726,6.302,4.332s4.726-3.545,4.332-6.302l-16.935-83.495
	l157.932-31.508l16.935,83.495c0.394,2.757,3.545,4.726,6.302,4.332C295.603,191.409,297.572,188.652,297.178,185.895z"/>--%>
<path fill="#359685" d="M138.064,49.625l202.437-19.692c5.908-0.394,11.028,3.545,11.815,9.452l48.443,396.997
	c0.394,5.908-3.545,11.028-9.452,11.422L188.87,467.496c-5.908,0.394-11.028-3.545-11.815-9.452L128.612,61.046
	C128.218,55.532,132.551,50.018,138.064,49.625z"/>
<path fill="#53A697" d="M330.655,54.351c-0.394-2.757-2.757-5.12-5.908-4.726L153.818,66.166
	c-2.757,0.394-5.12,2.757-4.726,5.908l9.058,90.191c0.394,2.757,2.757,5.12,5.908,4.726c2.757-0.394,5.12-2.757,4.726-5.908
	l-8.271-84.677l160.295-15.36l8.271,84.677c0.394,2.757,2.757,5.12,5.908,4.726c2.757-0.394,5.12-2.757,4.726-5.908
	C339.714,144.542,330.655,54.351,330.655,54.351z"/>
<path fill="#3DB39E" d="M207.775,0h206.769c5.908,0,11.028,4.726,11.028,11.028v411.569c0,5.908-4.726,11.028-11.028,11.028
	H207.775c-5.908,0-11.028-4.726-11.028-11.028V11.028C196.748,4.726,201.474,0,207.775,0z"/>
<path fill="#81CEC0" d="M232.194,216.615c0,43.717,35.446,78.769,78.769,78.769s78.769-35.446,78.769-78.769
	s-35.446-78.769-78.769-78.769S232.194,173.292,232.194,216.615z M268.821,214.646h5.908c1.182-9.846,6.695-17.329,12.603-20.48
	c0.788-0.394,1.969-0.788,2.757-0.788c3.151,0,5.514,2.363,5.514,5.12c0,2.363-1.182,3.545-2.363,4.332
	c-4.332,4.332-7.877,9.452-7.877,16.542c0,9.058,3.151,13.391,9.452,13.391c15.36,0,8.271-36.628,33.477-36.628
	c9.452,0,17.329,5.514,18.905,18.511h5.908c2.757,0,5.12,1.969,5.12,4.726s-2.363,4.726-5.12,4.726h-5.908
	c-1.182,7.877-4.332,14.572-9.452,18.117c-0.788,0.788-1.969,1.182-3.545,1.182c-3.151,0-5.514-2.363-5.514-5.514
	c0-1.575,0.788-2.757,2.363-4.332c3.151-3.151,5.514-8.271,5.514-14.178c0-8.271-3.938-11.422-8.271-11.422
	c-13.785,0-7.483,36.628-33.477,36.628c-11.422,0-18.905-7.089-20.48-20.48h-5.908c-2.757,0-5.12-1.969-5.12-4.726
	C263.701,216.615,266.064,214.646,268.821,214.646z M399.578,334.769c-3.151,0-5.908,2.757-5.908,5.908v61.046H228.255v-61.046
	c0-3.151-2.757-5.908-5.908-5.908s-5.908,2.757-5.908,5.908v66.954c0,3.151,2.757,5.908,5.908,5.908h177.231
	c3.151,0,5.908-2.757,5.908-5.908v-66.954C405.486,337.526,402.729,334.769,399.578,334.769z M399.578,19.692h-177.23
	c-3.151,0-5.908,2.757-5.908,5.908v66.954c0,3.151,2.757,5.908,5.908,5.908s5.908-2.757,5.908-5.908V31.508h165.415v61.046
	c0,3.151,2.757,5.908,5.908,5.908s5.908-2.757,5.908-5.908V25.6C405.486,22.449,402.729,19.692,399.578,19.692z M299.148,350.523
	c0,6.695,5.12,11.815,11.815,11.815s11.815-5.12,11.815-11.815s-5.12-11.815-11.815-11.815S299.148,344.222,299.148,350.523z
	 M322.778,82.708c0-6.695-5.12-11.815-11.815-11.815s-11.815,5.12-11.815,11.815s5.12,11.815,11.815,11.815
	S322.778,89.403,322.778,82.708z"/>
</svg>

  </div>
  <p class="topic">รายการคำขออนุญาตใช้รถในราชอาณาจักร<br />อนุมัติแล้ว (รอชำระเงิน)</p>
  <h3><asp:Label runat="server" Text="0" ID="lblTourWait2"></asp:Label> รายการ</h3>
</a>

<a class="w3-margin card credentialing  w3-quarter w3-padding mr-4" href="arrival.aspx?rt=2&st=2">
  <div class="overlay"></div>
  <div class="circle">
  <svg xmlns="http://www.w3.org/2000/svg"  width="71px" height="76px"  viewBox="0 0 512.0002 512">
<path d="m270 377c0 74.699219-60.300781 135-135 135s-135-60.300781-135-135 60.300781-135 135-135 135 60.300781 135 135zm0 0" fill="#61d7a8"/>
<path d="m270 377c0 74.699219-60.300781 135-135 135v-270c74.699219 0 135 60.300781 135 135zm0 0" fill="#00ab94"/>
<path d="m190.5 357.5-55.5 55.800781-15 15-40.5-40.800781 21-21 19.5 19.199219 15-15 34.5-34.199219zm0 0" fill="#fff5f5"/>
<path d="m190.5 357.5-55.5 55.800781v-42.601562l34.5-34.199219zm0 0" fill="#efe2dd"/>
<path d="m394.5 308.300781-42.300781 42.300781c-13.199219 13.5-31.5 19.796876-51.597657 19.796876-33.902343 0-74.101562-18-107.402343-51.597657-53.699219-53.402343-67.5-123.300781-31.800781-159l42.300781-42.300781zm0 0" fill="#fdbf00"/>
<path d="m394.5 308.300781-42.300781 42.300781c-13.199219 13.5-31.5 19.796876-51.597657 19.796876-33.902343 0-74.101562-18-107.402343-51.597657l105.898437-105.902343zm0 0" fill="#ff9100"/>
<path d="m394.5 308.300781c-12.902344 12.898438-30.601562 19.5-51.300781 19.5-7.800781 0-16.199219-.902343-24.898438-3-28.800781-6.601562-58.203125-23.699219-82.800781-48.300781s-41.699219-54-48.300781-82.796875c-7.5-31.203125-1.5-58.5 16.5-76.203125 28.199219-28.5 79.800781-25.800781 128.101562 6.300781l56.398438 56.402344c32.101562 48.296875 34.800781 99.894531 6.300781 128.097656zm0 0" fill="#596c76"/>
<path d="m394.5 308.300781c-12.902344 12.898438-30.601562 19.5-51.300781 19.5-7.800781 0-16.199219-.902343-24.898438-3-28.800781-6.601562-58.203125-23.699219-82.800781-48.300781l124.5-124.5 28.199219 28.199219c32.101562 48.300781 34.800781 99.898437 6.300781 128.101562zm0 0" fill="#465a61"/>
<path d="m491.601562 94.695312-166.699218 135.003907c-11.402344 0-22.203125-4.5-30-12.597657-8.101563-7.800781-12.601563-18.601562-12.601563-30l134.902344-166.808593c19.199219-24.597657 56.398437-27.597657 79.199219-4.800781 22.800781 22.5 20.101562 59.703124-4.800782 79.203124zm0 0" fill="#fdbf00"/>
<path d="m491.601562 94.695312-166.699218 135.003907c-11.402344 0-22.203125-4.5-30-12.597657l201.5-201.609374c22.800781 22.5 20.101562 59.703124-4.800782 79.203124zm0 0" fill="#ff9100"/>
</svg>

  </div>
  <p class="topic">รายการคำขออนุญาตใช้รถในราชอาณาจักร<br />อนุมัติแล้ว (เสร็จสมบูรณ์)</p>
  <h3><asp:Label runat="server" Text="0" ID="lblTourWait3"></asp:Label>  รายการ</h3>
</a>

<a class="w3-margin card human-resources  w3-quarter w3-padding mr-4" href="arrival.aspx?rt=2">
  <div class="overlay"></div>
  <div class="circle">
<%-- <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" id="Capa_1" enable-background="new 0 0 510 510" viewBox="0 0 510 510" width="71px" height="76px" >
 <linearGradient id="lg1">
 <stop offset="0" stop-color="#ff4974"/>
 <stop offset=".2231" stop-color="#fb3f6c"/>
 <stop offset=".6075" stop-color="#f12357"/>
 <stop offset="1" stop-color="#e4003d"/></linearGradient>
 <linearGradient id="SVGID_1_" gradientUnits="userSpaceOnUse" x1="35.421" x2="56.672" xlink:href="#lg1" y1="196.747" y2="227.656"/>
 <linearGradient id="lg2"><stop offset="0" stop-color="#4f4a72"/><stop offset="1" stop-color="#3b395f"/></linearGradient>
 <linearGradient id="SVGID_2_" gradientUnits="userSpaceOnUse" x1="16" x2="26.013" xlink:href="#lg2" y1="232.777" y2="232.777"/>
 <linearGradient id="SVGID_3_" gradientUnits="userSpaceOnUse" x1="233.969" x2="248.334" xlink:href="#lg1" y1="71.84" y2="108.386"/>
 <linearGradient id="SVGID_4_" gradientUnits="userSpaceOnUse" x1="260.73" x2="260.73" xlink:href="#lg1" y1="139.231" y2="229.237"/>
 <linearGradient id="SVGID_5_" gradientUnits="userSpaceOnUse" x1="271.08" x2="298.527" xlink:href="#lg2" y1="125.709" y2="175.305"/>
 <linearGradient id="SVGID_6_" gradientUnits="userSpaceOnUse" x1="347.555" x2="375.003" xlink:href="#lg2" y1="125.708" y2="175.307"/>
 <linearGradient id="SVGID_7_" gradientUnits="userSpaceOnUse" x1="421.773" x2="448.22" xlink:href="#lg2" y1="125.477" y2="173.268"/>
 <linearGradient id="SVGID_8_" gradientUnits="userSpaceOnUse" x1="194.605" x2="222.053" xlink:href="#lg2" y1="125.708" y2="175.307"/>
 <linearGradient id="SVGID_9_" gradientUnits="userSpaceOnUse" x1="103.245" x2="141.943" xlink:href="#lg2" y1="132.689" y2="171.387"/>
 <linearGradient id="SVGID_10_" gradientUnits="userSpaceOnUse" x1="226.713" x2="294.713" xlink:href="#lg1" y1="232.298" y2="405.298"/>
 <linearGradient id="SVGID_11_" gradientUnits="userSpaceOnUse" x1="241.181" x2="271.181" xlink:href="#lg1" y1="292.749" y2="418.749"/>
 <linearGradient id="lg3"><stop offset="0" stop-color="#d4f7ff"/><stop offset="1" stop-color="#a2e3e9"/></linearGradient>
 <linearGradient id="SVGID_12_" gradientUnits="userSpaceOnUse" x1="323.052" x2="336.568" xlink:href="#lg3" y1="295.916" y2="352.683"/>
 <linearGradient id="SVGID_13_" gradientUnits="userSpaceOnUse" x1="81.093" x2="145.061" xlink:href="#lg1" y1="212.512" y2="442.428"/>
 <linearGradient id="lg4"><stop offset="0" stop-color="#a34a9e" stop-opacity="0"/><stop offset="1" stop-color="#343168"/></linearGradient>
 <linearGradient id="SVGID_14_" gradientUnits="userSpaceOnUse" x1="100.752" x2="100.752" xlink:href="#lg4" y1="313.424" y2="448.869"/>
 <linearGradient id="SVGID_15_" gradientUnits="userSpaceOnUse" x1="424.167" x2="424.167" xlink:href="#lg4" y1="313.424" y2="448.869"/>
 <linearGradient id="SVGID_16_" gradientUnits="userSpaceOnUse" x1="253.819" x2="253.819" xlink:href="#lg1" y1="371.77" y2="398.835"/>
 <linearGradient id="lg5"><stop offset="0" stop-color="#a34a9e"/><stop offset=".1551" stop-color="#9b489a"/><stop offset=".4019" stop-color="#84438f"/><stop offset=".7073" stop-color="#5e3b7d"/><stop offset="1" stop-color="#343168"/></linearGradient>
 <radialGradient id="SVGID_17_" cx="94.388" cy="376.029" gradientUnits="userSpaceOnUse" r="56.764" xlink:href="#lg5"/>
 <linearGradient id="lg6"><stop offset="0" stop-color="#a34a9e"/><stop offset="1" stop-color="#343168"/></linearGradient>
 <linearGradient id="SVGID_18_" gradientTransform="matrix(-1 0 0 -1 -2682 -1618)" gradientUnits="userSpaceOnUse" x1="-2816.577" x2="-2753.909" xlink:href="#lg6" y1="-2041.036" y2="-1978.368"/>
 <linearGradient id="SVGID_19_" gradientUnits="userSpaceOnUse" x1="70.014" x2="126.959" xlink:href="#lg3" y1="358.473" y2="415.418"/>
 <linearGradient id="SVGID_20_" gradientTransform="matrix(-1 0 0 -1 -2682 -1618)" gradientUnits="userSpaceOnUse" x1="-2800.611" x2="-2767.523" xlink:href="#lg3" y1="-2025.07" y2="-1991.981"/>
 <linearGradient id="lg7"><stop offset="0" stop-color="#a2e3e9" stop-opacity="0"/><stop offset="1" stop-color="#518cd2"/></linearGradient>
 <linearGradient id="SVGID_21_" gradientUnits="userSpaceOnUse" x1="123.553" x2="97.887" xlink:href="#lg7" y1="412.011" y2="386.345"/>
 <linearGradient id="SVGID_22_" gradientUnits="userSpaceOnUse" x1="98.933" x2="108.171" xlink:href="#lg2" y1="387.392" y2="396.63"/>
 <linearGradient id="SVGID_23_" gradientUnits="userSpaceOnUse" x1="99.122" x2="102.95" xlink:href="#lg2" y1="366.484" y2="370.311"/>
 <linearGradient id="SVGID_24_" gradientUnits="userSpaceOnUse" x1="99.122" x2="102.95" xlink:href="#lg2" y1="408.678" y2="412.506"/>
 <linearGradient id="SVGID_25_" gradientTransform="matrix(0 1 -1 0 -2150 532)" gradientUnits="userSpaceOnUse" x1="-144.419" x2="-140.592" xlink:href="#lg2" y1="-2273.477" y2="-2269.65"/>
 <linearGradient id="SVGID_26_" gradientTransform="matrix(0 1 -1 0 -2150 532)" gradientUnits="userSpaceOnUse" x1="-144.419" x2="-140.592" xlink:href="#lg2" y1="-2231.283" y2="-2227.455"/>
 <linearGradient id="SVGID_27_" gradientTransform="matrix(.707 .707 -.707 .707 -964.832 711.177)" gradientUnits="userSpaceOnUse" x1="524.192" x2="528.019" xlink:href="#lg2" y1="-1003.882" y2="-1000.055"/>
 <linearGradient id="SVGID_28_" gradientTransform="matrix(.707 .707 -.707 .707 -964.832 711.177)" gradientUnits="userSpaceOnUse" x1="524.192" x2="528.019" xlink:href="#lg2" y1="-961.687" y2="-957.86"/>
 <linearGradient id="SVGID_29_" gradientTransform="matrix(-.707 .707 .707 .707 -1717.168 711.177)" gradientUnits="userSpaceOnUse" x1="-1514.772" x2="-1510.945" xlink:href="#lg2" y1="1035.082" y2="1038.909"/>
 <linearGradient id="SVGID_30_" gradientTransform="matrix(-.707 .707 .707 .707 -1717.168 711.177)" gradientUnits="userSpaceOnUse" x1="-1514.772" x2="-1510.945" xlink:href="#lg2" y1="1077.276" y2="1081.104"/>
 <radialGradient id="SVGID_31_" cx="417.804" cy="376.029" gradientUnits="userSpaceOnUse" r="56.764" xlink:href="#lg5"/><linearGradient id="SVGID_32_" gradientTransform="matrix(-1 0 0 -1 -2682 -1618)" gradientUnits="userSpaceOnUse" x1="-3139.993" x2="-3077.326" xlink:href="#lg6" y1="-2041.036" y2="-1978.368"/>
 <linearGradient id="SVGID_33_" gradientUnits="userSpaceOnUse" x1="393.431" x2="450.375" xlink:href="#lg3" y1="358.473" y2="415.417"/><linearGradient id="SVGID_34_" gradientTransform="matrix(-1 0 0 -1 -2682 -1618)" gradientUnits="userSpaceOnUse" x1="-3124.028" x2="-3090.939" xlink:href="#lg3" y1="-2025.07" y2="-1991.981"/>
 <linearGradient id="SVGID_35_" gradientUnits="userSpaceOnUse" x1="446.969" x2="421.303" xlink:href="#lg7" y1="412.011" y2="386.345"/><linearGradient id="SVGID_36_" gradientUnits="userSpaceOnUse" x1="422.349" x2="431.588" xlink:href="#lg2" y1="387.392" y2="396.63"/><linearGradient id="SVGID_37_" gradientUnits="userSpaceOnUse" x1="422.539" x2="426.366" xlink:href="#lg2" y1="366.484" y2="370.311"/>
 <linearGradient id="SVGID_38_" gradientUnits="userSpaceOnUse" x1="422.539" x2="426.366" xlink:href="#lg2" y1="408.678" y2="412.506"/><linearGradient id="SVGID_39_" gradientTransform="matrix(0 1 -1 0 -2150 532)" gradientUnits="userSpaceOnUse" x1="-144.419" x2="-140.592" xlink:href="#lg2" y1="-2596.893" y2="-2593.066"/><linearGradient id="SVGID_40_" gradientTransform="matrix(0 1 -1 0 -2150 532)" gradientUnits="userSpaceOnUse" x1="-144.419" x2="-140.592" xlink:href="#lg2" y1="-2554.699" y2="-2550.872"/>
 <linearGradient id="SVGID_41_" gradientTransform="matrix(.707 .707 -.707 .707 -964.832 711.177)" gradientUnits="userSpaceOnUse" x1="752.884" x2="756.711" xlink:href="#lg2" y1="-1232.574" y2="-1228.747"/><linearGradient id="SVGID_42_" gradientTransform="matrix(.707 .707 -.707 .707 -964.832 711.177)" gradientUnits="userSpaceOnUse" x1="752.884" x2="756.711" xlink:href="#lg2" y1="-1190.379" y2="-1186.552"/>
 <linearGradient id="SVGID_43_" gradientTransform="matrix(-.707 .707 .707 .707 -1717.168 711.177)" gradientUnits="userSpaceOnUse" x1="-1743.464" x2="-1739.637" xlink:href="#lg2" y1="1263.774" y2="1267.601"/><linearGradient id="SVGID_44_" gradientTransform="matrix(-.707 .707 .707 .707 -1717.168 711.177)" gradientUnits="userSpaceOnUse" x1="-1743.464" x2="-1739.637" xlink:href="#lg2" y1="1305.968" y2="1309.796"/>
 <linearGradient id="lg8"><stop offset="0" stop-color="#ffe548"/><stop offset=".1758" stop-color="#ffde50"/><stop offset=".4446" stop-color="#ffca65"/><stop offset=".7709" stop-color="#ffaa87"/><stop offset="1" stop-color="#ff90a4"/></linearGradient><linearGradient id="SVGID_45_" gradientUnits="userSpaceOnUse" x1="475.114" x2="490.484" xlink:href="#lg8" y1="340.618" y2="359.12"/><linearGradient id="SVGID_46_" gradientUnits="userSpaceOnUse" x1="17.981" x2="21.991" xlink:href="#lg8" y1="336.839" y2="370.798"/><linearGradient id="SVGID_47_" gradientUnits="userSpaceOnUse" x1="25.092" x2="25.092" xlink:href="#lg3" y1="359.681" y2="386.428"/><linearGradient id="SVGID_48_" gradientUnits="userSpaceOnUse" x1="491.744" x2="491.744" xlink:href="#lg3" y1="359.681" y2="386.428"/>
 <linearGradient id="SVGID_49_" gradientUnits="userSpaceOnUse" x1="233.314" x2="288.245" xlink:href="#lg2" y1="169.625" y2="367.06"/><linearGradient id="SVGID_50_" gradientUnits="userSpaceOnUse" x1="86.898" x2="138.231" xlink:href="#lg2" y1="226.823" y2="301.49"/><linearGradient id="SVGID_51_" gradientUnits="userSpaceOnUse" x1="193.635" x2="221.083" xlink:href="#lg2" y1="227.311" y2="276.91"/><linearGradient id="SVGID_52_" gradientUnits="userSpaceOnUse" x1="271.08" x2="298.527" xlink:href="#lg2" y1="226.775" y2="276.372"/><linearGradient id="SVGID_53_" gradientUnits="userSpaceOnUse" x1="347.555" x2="375.003" xlink:href="#lg2" y1="226.775" y2="276.373"/>
 <linearGradient id="SVGID_54_" gradientUnits="userSpaceOnUse" x1="421.773" x2="448.22" xlink:href="#lg2" y1="226.544" y2="274.334"/><path d="m22.808 223.992h-8v-5.247c0-8.21 6.679-14.888 14.889-14.888h49.957v8h-49.958c-3.798 0-6.889 3.09-6.889 6.888v5.247z" fill="url(#SVGID_1_)"/><path d="m18.808 251.349c-3.47 0-6.284-2.813-6.284-6.284v-24.577c0-3.471 2.813-6.284 6.284-6.284 3.471 0 6.284 2.813 6.284 6.284v24.577c0 3.471-2.814 6.284-6.284 6.284z" fill="url(#SVGID_2_)"/><path d="m316.89 94.445h-152.95v-10.786c0-4.721 3.827-8.548 8.548-8.548h135.854c4.721 0 8.548 3.827 8.548 8.548z" fill="url(#SVGID_3_)"/><path d="m468.811 86.01h-373.892c-35.539 0-64.688 28.289-65.603 63.815-.287 11.121 0 138.318 0 138.318h462.954v-178.673c0-12.957-10.503-23.46-23.459-23.46z" fill="url(#SVGID_4_)"/>
 <path d="m240.42 102.016h76.47v74.76h-76.47z" fill="url(#SVGID_5_)"/><path d="m316.89 102.016h76.48v74.76h-76.48z" fill="url(#SVGID_6_)"/><path d="m469.85 112.416v53.96c0 5.74-4.66 10.4-10.4 10.4h-66.08v-74.76h66.08c5.74 0 10.4 4.66 10.4 10.4z" fill="url(#SVGID_7_)"/><path d="m163.94 102.016h76.48v74.76h-76.48z" fill="url(#SVGID_8_)"/><path d="m49.872 146.645v19.731c0 5.744 4.656 10.4 10.4 10.4h103.668v-74.76h-69.439c-24.648 0-44.629 19.981-44.629 44.629z" fill="url(#SVGID_9_)"/><path d="m468.811 187.077h-373.892c-35.539 0-64.688 28.289-65.603 63.815-.287 11.121-1.088 19.484-6.421 21.755-6.319 2.896-10.371 9.209-10.371 16.16v100.403h479.746v-178.674c0-12.956-10.503-23.459-23.459-23.459z" fill="url(#SVGID_10_)"/><path d="m12.524 290.5h479.746v98.709h-479.746z" fill="url(#SVGID_11_)"/><path d="m163.94 308.259h328.33v17.759h-328.33z" fill="url(#SVGID_12_)"/>
 <path d="m163.94 203.087h-53.552c-35.539 0-64.688 28.289-65.603 63.815-.287 11.121 0 122.308 0 122.308h119.155z" fill="url(#SVGID_13_)"/><path d="m163.94 389.207h-126.377c0-34.899 28.29-63.189 63.189-63.189 5.977 0 11.767.828 17.257 2.391 26.514 7.506 45.931 31.885 45.931 60.798z" fill="url(#SVGID_14_)"/><path d="m487.355 389.207h-126.377c0-34.899 28.29-63.189 63.189-63.189 5.977 0 11.767.828 17.257 2.391 26.514 7.506 45.931 31.885 45.931 60.798z" fill="url(#SVGID_15_)"/><path d="m27.098 370.323h453.443v21.372h-453.443z" fill="url(#SVGID_16_)"/><circle cx="100.751" cy="389.21" fill="url(#SVGID_17_)" r="45.679"/><circle cx="100.751" cy="389.21" fill="url(#SVGID_18_)" r="29.544"/><circle cx="100.751" cy="389.21" fill="url(#SVGID_19_)" r="26.845"/><circle cx="100.751" cy="389.21" fill="url(#SVGID_20_)" r="15.599"/>
 <path d="m124.877 400.99-17.542-17.542c-1.605-1.833-3.956-2.996-6.584-2.996-4.837 0-8.757 3.921-8.757 8.758 0 2.628 1.163 4.979 2.996 6.584l17.542 17.542c5.363-2.624 9.721-6.983 12.345-12.346z" fill="url(#SVGID_21_)"/><circle cx="100.751" cy="389.21" fill="url(#SVGID_22_)" r="8.757"/><circle cx="100.751" cy="368.113" fill="url(#SVGID_23_)" r="3.106"/><circle cx="100.751" cy="410.307" fill="url(#SVGID_24_)" r="3.106"/><circle cx="121.848" cy="389.21" fill="url(#SVGID_25_)" r="3.106"/><circle cx="79.654" cy="389.21" fill="url(#SVGID_26_)" r="3.106"/><circle cx="115.669" cy="374.292" fill="url(#SVGID_27_)" r="3.106"/><circle cx="85.833" cy="404.128" fill="url(#SVGID_28_)" r="3.106"/><circle cx="85.833" cy="374.292" fill="url(#SVGID_29_)" r="3.106"/><circle cx="115.669" cy="404.128" fill="url(#SVGID_30_)" r="3.106"/>
 <circle cx="424.167" cy="389.21" fill="url(#SVGID_31_)" r="45.679"/><circle cx="424.167" cy="389.21" fill="url(#SVGID_32_)" r="29.544"/><circle cx="424.167" cy="389.21" fill="url(#SVGID_33_)" r="26.845"/><circle cx="424.167" cy="389.21" fill="url(#SVGID_34_)" r="15.599"/><path d="m448.293 400.99-17.542-17.542c-1.605-1.833-3.956-2.996-6.584-2.996-4.837 0-8.757 3.921-8.757 8.758 0 2.628 1.163 4.979 2.996 6.584l17.542 17.542c5.363-2.624 9.721-6.983 12.345-12.346z" fill="url(#SVGID_35_)"/><circle cx="424.167" cy="389.21" fill="url(#SVGID_36_)" r="8.757"/><circle cx="424.167" cy="368.113" fill="url(#SVGID_37_)" r="3.106"/><circle cx="424.167" cy="410.307" fill="url(#SVGID_38_)" r="3.106"/><circle cx="445.265" cy="389.21" fill="url(#SVGID_39_)" r="3.106"/><circle cx="403.07" cy="389.21" fill="url(#SVGID_40_)" r="3.106"/><circle cx="439.085" cy="374.292" fill="url(#SVGID_41_)" r="3.106"/><circle cx="409.25" cy="404.128" fill="url(#SVGID_42_)" r="3.106"/><circle cx="409.25" cy="374.292" fill="url(#SVGID_43_)" r="3.106"/>
 <circle cx="439.085" cy="404.128" fill="url(#SVGID_44_)" r="3.106"/><path d="m492.637 338.972h-7.361c-4.856 0-8.793 3.937-8.793 8.792v17.242h16.153v-26.034z" fill="url(#SVGID_45_)"/><path d="m19.2 338.972h-6.676v26.035h15.469v-17.242c-.001-4.856-3.937-8.793-8.793-8.793z" fill="url(#SVGID_46_)"/><path d="m38.547 396.821h-26.911c-6.426 0-11.636-5.21-11.636-11.636v-13.81c0-6.427 5.21-11.636 11.636-11.636h26.911c6.426 0 11.636 5.21 11.636 11.636v13.81c0 6.426-5.21 11.636-11.636 11.636z" fill="url(#SVGID_47_)"/><path d="m498.364 396.821h-13.24c-6.427 0-11.636-5.21-11.636-11.636v-13.81c0-6.427 5.21-11.636 11.636-11.636h13.24c6.427 0 11.636 5.21 11.636 11.636v13.81c0 6.426-5.21 11.636-11.636 11.636z" fill="url(#SVGID_48_)"/><path d="m469.846 213.483c0-5.742-4.655-10.397-10.396-10.397h-295.51-39.063-14.489c-35.539 0-64.688 28.289-65.603 63.815-.178 6.92-.135 21.304-.076 31.183.034 5.718 4.678 10.335 10.396 10.335h52.457c14.628 0 28.731-5.451 39.556-15.29 10.825-9.839 24.928-15.29 39.556-15.29h272.776c5.742 0 10.396-4.655 10.396-10.397z" fill="url(#SVGID_49_)"/><path d="m44.785 266.905c-.067 2.619-.103 10.77-.118 21.705.009 3.342.025 6.6.042 9.475.034 5.718 4.678 10.335 10.396 10.335h52.457c14.628 0 28.731-5.451 39.556-15.29 4.997-4.542 10.699-8.136 16.823-10.703v-79.34h-53.552c-25.543 0-47.786 14.614-58.617 36.026-1.884 3.724-3.422 7.653-4.573 11.747-.575 2.047-1.054 4.135-1.43 6.259-.188 1.062-.351 2.133-.487 3.212-.273 2.159-.44 4.351-.497 6.571z" fill="url(#SVGID_50_)"/><path d="m240.42 203.083v74.76h-53.75c-7.31 0-14.49 1.36-21.2 3.96-.51.2-1.03.4-1.53.62v-79.34z" fill="url(#SVGID_51_)"/><path d="m240.42 203.083h76.47v74.76h-76.47z" fill="url(#SVGID_52_)"/><path d="m316.89 203.083h76.48v74.76h-76.48z" fill="url(#SVGID_53_)"/>
 <path d="m469.85 213.483v53.96c0 5.74-4.66 10.4-10.4 10.4h-66.08v-74.76h66.08c5.74 0 10.4 4.66 10.4 10.4z" fill="url(#SVGID_54_)"/></svg>--%>
 <svg xmlns="http://www.w3.org/2000/svg" width="71px" height="76px"  viewBox="0 0 512.0002 512" >
<g>
	<path fill="#b30000" d="M449.557,235.01c-6.85-16.07-21.91-28.1-40.51-30.23l-70.54-8.06l-37.63-61.16
		c-9.62-15.64-26.67-25.17-45.03-25.17h-121.5c-31.66,0-59.43,21.15-67.83,51.68l-0.95,3.45c-2.66,9.69-7.77,18.32-14.62,25.21
		c-6.85,6.9-15.46,12.05-25.12,14.78c-10.44,2.94-17.66,12.47-17.66,23.31v67.883l38.41-8.983c0.81-1.88,1.73-3.71,2.75-5.49
		c9.59-16.61,27.44-26.93,46.6-26.93s37,10.32,46.58,26.93c1.02,1.78,1.95,3.61,2.75,5.49h163.08c0.79-1.86,1.7-3.67,2.71-5.43
		c9.58-16.65,27.45-26.99,46.64-26.99c19.16,0,37,10.32,46.58,26.93c1.02,1.78,1.95,3.61,2.75,5.49h42.82l0.27,0.03l3.12-27.4
		c0.13-1.12,0.22-2.23,0.27-3.34C453.867,249.25,452.437,241.77,449.557,235.01z"/>
	<path fill="#CCCCCC" d="M462.2,299.792L462.2,299.792c0,6.654-5.394,12.048-12.048,12.048h-38.795
		c0.05-0.92,0.08-1.85,0.08-2.78c0-7.37-1.51-14.65-4.42-21.34l43.142,0.024C456.81,287.747,462.2,293.14,462.2,299.792z"/>
	<path fill="#666666" d="M400.437,309.06c0,0.93-0.03,1.86-0.09,2.78c-1.43,22.31-19.98,39.97-42.66,39.97
		c-22.69,0-41.24-17.66-42.67-39.97c-0.06-0.92-0.09-1.85-0.09-2.78c0-7.75,2.06-15.02,5.66-21.29
		c7.38-12.83,21.23-21.47,37.1-21.47c15.84,0,29.67,8.62,37.05,21.42C398.367,294,400.437,301.29,400.437,309.06z M375.217,309.06
		c0-9.67-7.86-17.54-17.53-17.54c-9.68,0-17.54,7.87-17.54,17.54s7.86,17.54,17.54,17.54
		C367.357,326.6,375.217,318.73,375.217,309.06z"/>
	<path fill="#E6E6E6" d="M357.687,291.52c9.67,0,17.53,7.87,17.53,17.54s-7.86,17.54-17.53,17.54
		c-9.68,0-17.54-7.87-17.54-17.54C340.147,299.39,348.007,291.52,357.687,291.52z"/>
	<path fill="#CCCCCC" d="M303.927,309.06c0,0.93,0.03,1.87,0.08,2.78h-154.41c0.05-0.93,0.08-1.86,0.08-2.78
		c0-7.37-1.51-14.65-4.42-21.34h163.08C305.437,294.43,303.927,301.7,303.927,309.06z"/>
	<path fill="#9ca6a6" d="M115.967,138.39v58.33h-33.47c0,0,3.9-15.83,6.37-24.79l0.95-3.45c0.5-1.83,1.11-3.6,1.82-5.32
		C96.257,151.94,105.097,143.12,115.967,138.39z"/>
	<path fill="#9ca6a6" d="M200.027,134.55v62.17h-69.06v-62.04c1.12-0.09,2.25-0.13,3.38-0.13L200.027,134.55L200.027,134.55z
		"/>
	<path fill="#9ca6a6" d="M310.137,196.72h-95.11v-62.17h40.82c9.89,0,19.27,5.24,24.45,13.67L310.137,196.72z"/>
	<path fill="#666666" d="M138.587,311.84c-1.43,22.31-19.98,39.97-42.66,39.97c-22.69,0-41.24-17.66-42.67-39.97
		c-0.06-0.92-0.09-1.85-0.09-2.78c0-7.77,2.07-15.06,5.69-21.34c7.39-12.8,21.22-21.42,37.07-21.42c15.84,0,29.67,8.62,37.05,21.42
		c3.63,6.28,5.7,13.57,5.7,21.34C138.677,309.99,138.647,310.92,138.587,311.84z M113.467,309.06c0-9.67-7.87-17.54-17.54-17.54
		c-9.68,0-17.54,7.87-17.54,17.54s7.86,17.54,17.54,17.54C105.597,326.6,113.467,318.73,113.467,309.06z"/>
	<path fill="#E6E6E6" d="M95.927,291.52c9.67,0,17.54,7.87,17.54,17.54s-7.87,17.54-17.54,17.54
		c-9.68,0-17.54-7.87-17.54-17.54C78.387,299.39,86.247,291.52,95.927,291.52z"/>
	<path fill="#CCCCCC" d="M42.167,309.06c0,0.93,0.03,1.86,0.08,2.78H12.06C5.399,311.84,0,306.441,0,299.78l0,0
		c0-6.661,5.399-12.06,12.06-12.06h34.517C43.677,294.42,42.167,301.69,42.167,309.06z"/>
	<path fill="#CCCCCC" d="M256.236,229.631h-15.76c-3.313,0-6-2.686-6-6s2.687-6,6-6h15.76c3.313,0,6,2.686,6,6
		S259.55,229.631,256.236,229.631z"/>
	<path fill="#CCCCCC" d="M148.017,229.631h-15.76c-3.313,0-6-2.686-6-6s2.687-6,6-6h15.76c3.313,0,6,2.686,6,6
		S151.33,229.631,148.017,229.631z"/>
	<path fill="#FFFFFF" d="M453.497,257.01h-12.05c-12.15,0-22-9.85-22-22l0,0h30.11
		C452.867,242.245,454.367,249.37,453.497,257.01z"/>
	<polygon fill="#C3C9C9" points="200.027,134.68 200.027,196.72 192.997,196.72 130.967,134.68 	"/>
	<path fill="#C3C9C9" d="M310.137,196.72h-32.94l-62.17-62.17h40.82c9.89,0,19.27,5.24,24.45,13.67L310.137,196.72z"/>
	<path fill="#C3C9C9" d="M115.967,138.39v49.1l-24.33-24.33C96.257,151.94,105.097,143.12,115.967,138.39z"/>

</svg>
  </div>
  <p class="topic">รายการคำขออนุญาตใช้รถในราชอาณาจักร<br />ทั้งหมด</p>
  <h3><asp:Label runat="server" Text="0" ID="lblTourWait4"></asp:Label> รายการ</h3>
</a>

</div>
</div>
</center>

 <div class="mt-5 tabcontent container w3-hide-small w3-hide-medium" style=" margin-left:25rem; margin-right:-5rem;">
  <h1><img src="../image/Icon2/folder%20(1).png" style=" font-family: 'Kanit', sans-serif;width:64px; height:64px; " /> จัดการข้อมูลทั่วไป</h1>
</div>
<div class="tabcontent container w3-hide-large">
  <h2><img src="../image/Icon2/folder%20(1).png" style=" font-family: 'Kanit', sans-serif;width:64px; height:64px; " /> จัดการข้อมูลทั่วไป </h2> 
</div>
<center>
<div class=" w3-row  container" style=" margin-left:5rem; margin-right:-5rem;">
<div class="w3-row-padding w3-margin-bottom mt-5">
<a class="w3-margin card wait w3-quarter w3-padding mr-4" href="EditUser.aspx?st=0">
  <div class="overlay2"></div>
  <div class="circle">
  <svg version="1.1" width="71px" height="76px" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 512 512" style="enable-background:new 0 0 512 512;" xml:space="preserve">
<path style="fill:#9B735A;" d="M351.458,34.712H229.966c0,9.585-7.771,17.356-17.356,17.356s-17.356-7.771-17.356-17.356H73.763
	c-14.378,0-26.034,11.656-26.034,26.034V425.22c0,14.378,11.656,26.034,26.034,26.034h277.695c14.378,0,26.034-11.656,26.034-26.034
	V60.746C377.492,46.367,365.836,34.712,351.458,34.712z"/>
<path style="fill:#8C5F50;" d="M368.814,303.729c-2.93,0-5.805,0.219-8.678,0.438V60.746c0-4.792-3.886-8.678-8.678-8.678h-43.39
	c-4.792,0-8.678-3.886-8.678-8.678v-8.678h-69.424c0,9.585-7.771,17.356-17.356,17.356s-17.356-7.771-17.356-17.356h-69.424v8.678
	c0,4.792-3.886,8.678-8.678,8.678h-43.39c-4.792,0-8.678,3.886-8.678,8.678V425.22c0,4.792,3.886,8.678,8.678,8.678h183.606
	c0.933,5.948,2.316,11.748,4.13,17.356h89.959c14.378,0,26.034-11.656,26.034-26.034V304.167
	C374.618,303.948,371.743,303.729,368.814,303.729z"/>
<path style="fill:#F1F4FB;" d="M334.102,416.542H91.119c-4.792,0-8.678-3.886-8.678-8.678V78.102c0-4.792,3.886-8.678,8.678-8.678
	h242.983c4.792,0,8.678,3.886,8.678,8.678v329.763C342.78,412.657,338.894,416.542,334.102,416.542z"/>
<path style="fill:#E4EAF8;" d="M342.78,407.864V306.869C293.048,318.639,256,363.214,256,416.542h78.102
	C338.894,416.542,342.78,412.657,342.78,407.864z"/>
<path style="fill:#7F8499;" d="M290.712,182.237h-86.78c-4.797,0-8.678-3.881-8.678-8.678c0-4.797,3.881-8.678,8.678-8.678h86.78
	c4.797,0,8.678,3.881,8.678,8.678C299.39,178.356,295.509,182.237,290.712,182.237z"/>
<path style="fill:#5B5D6E;" d="M264.678,147.525h-60.746c-4.797,0-8.678-3.881-8.678-8.678s3.881-8.678,8.678-8.678h60.746
	c4.797,0,8.678,3.881,8.678,8.678S269.475,147.525,264.678,147.525z"/>
<path style="fill:#7F8499;" d="M290.712,269.017h-86.78c-4.797,0-8.678-3.881-8.678-8.678c0-4.797,3.881-8.678,8.678-8.678h86.78
	c4.797,0,8.678,3.881,8.678,8.678C299.39,265.136,295.509,269.017,290.712,269.017z"/>
<path style="fill:#5B5D6E;" d="M264.678,234.305h-60.746c-4.797,0-8.678-3.881-8.678-8.678s3.881-8.678,8.678-8.678h60.746
	c4.797,0,8.678,3.881,8.678,8.678S269.475,234.305,264.678,234.305z"/>
<path style="fill:#7F8499;" d="M290.712,355.797h-86.78c-4.797,0-8.678-3.881-8.678-8.678c0-4.797,3.881-8.678,8.678-8.678h86.78
	c4.797,0,8.678,3.881,8.678,8.678C299.39,351.915,295.509,355.797,290.712,355.797z"/>
<path style="fill:#5B5D6E;" d="M264.678,321.085h-60.746c-4.797,0-8.678-3.881-8.678-8.678c0-4.797,3.881-8.678,8.678-8.678h60.746
	c4.797,0,8.678,3.881,8.678,8.678C273.356,317.204,269.475,321.085,264.678,321.085z"/>
<path style="fill:#FFF082;" d="M264.678,17.356h-22.17C236.495,7.024,225.425,0,212.61,0s-23.885,7.024-29.898,17.356h-22.17
	c-9.585,0-17.356,7.77-17.356,17.356v34.712c0,4.792,3.886,8.678,8.678,8.678h121.492c4.792,0,8.678-3.886,8.678-8.678V34.712
	C282.034,25.126,274.263,17.356,264.678,17.356z M212.61,47.729c-7.189,0-13.017-5.828-13.017-13.017s5.828-13.017,13.017-13.017
	s13.017,5.828,13.017,13.017S219.799,47.729,212.61,47.729z"/>
<g>
	<path style="fill:#FFDC64;" d="M151.864,78.102h121.492c4.792,0,8.678-3.886,8.678-8.678l0,0c0-4.792-3.886-8.678-8.678-8.678
		H151.864c-4.792,0-8.678,3.886-8.678,8.678l0,0C143.186,74.216,147.072,78.102,151.864,78.102z"/>
	<circle style="fill:#FFDC64;" cx="368.814" cy="416.542" r="95.458"/>
</g>
<circle style="fill:#FFFFFF;" cx="368.814" cy="416.542" r="78.102"/>
<g>
	<circle style="fill:#FFDC64;" cx="151.864" cy="156.203" r="26.034"/>
	<circle style="fill:#FFDC64;" cx="151.864" cy="329.763" r="26.034"/>
	<circle style="fill:#FFDC64;" cx="151.864" cy="242.983" r="26.034"/>
</g>
<path style="fill:#5B5D6E;" d="M273.871,355.797h16.841c4.797,0,8.678-3.881,8.678-8.678c0-4.797-3.881-8.678-8.678-8.678h-3.164
	C282.433,343.747,277.873,349.571,273.871,355.797z"/>
<path style="fill:#E4EAF8;" d="M383.391,450.188c-24.206-4.5-43.743-24.048-48.229-48.256c-1.497-8.077-1.361-15.911,0.11-23.265
	c1.084-5.421-5.258-9.137-9.188-5.251c-13.028,12.885-20.258,31.607-17.392,51.947c3.697,26.239,25.062,47.604,51.301,51.301
	c20.34,2.866,39.064-4.364,51.949-17.393c3.887-3.93,0.17-10.271-5.249-9.188C399.326,451.558,391.479,451.691,383.391,450.188z"/>
<path style="fill:#5B5D6E;" d="M404.975,461.381c-2.22,0-4.441-0.847-6.135-2.543l-36.161-36.161c-3.39-3.39-3.39-8.882,0-12.272
	s8.882-3.39,12.272,0l36.161,36.161c3.39,3.39,3.39,8.882,0,12.272C409.416,460.534,407.195,461.381,404.975,461.381z"/>
<path style="fill:#464655;" d="M368.814,425.22L368.814,425.22c-4.792,0-8.678-3.886-8.678-8.678v-60.746
	c0-4.792,3.886-8.678,8.678-8.678l0,0c4.792,0,8.678,3.886,8.678,8.678v60.746C377.492,421.335,373.606,425.22,368.814,425.22z"/>
</svg>
  </div>
  <p class="topic">รายการรออนุมัติ<br />ผู้ประกอบธุรกิจนำเที่ยว </p>
  <h3><asp:Label runat="server" Text="0" ID="lblTourWait"></asp:Label> รายการ</h3>
</a>

<a class="w3-margin card  guid w3-quarter w3-padding mr-4" href="EditUser.aspx?st=1">
  <div class="overlay2"></div>
  <div class="circle">
  
<svg id="Capa_1" width="71px" height="76px" enable-background="new 0 0 509.98 509.98" viewBox="0 0 509.98 509.98"  xmlns="http://www.w3.org/2000/svg">
<path d="m424.32 453.86v56.12h-416.66v-55.45c0-29.86 17.14-55.06 41.05-66.28 0 0 6.3-3.02 62.69-29.98 12.65-6.05 27.82-13.3 46.01-22h117.16c17.94 8.58 32.93 15.75 45.47 21.74l.01.01c56.88 27.2 63.22 30.23 63.22 30.23 25.05 11.75 41.05 37.94 41.05 65.61z" fill="#eae2e0"/><path d="m424.32 453.86v56.12h-208.33v-173.71h58.58c17.94 8.58 32.93 15.75 45.47 21.74l.01.01c56.88 27.2 63.22 30.23 63.22 30.23 25.05 11.75 41.05 37.94 41.05 65.61z" fill="#c0b2b0"/><path d="m424.32 453.86v56.12h-208.33v-57.84l104.05-94.13.01.01c56.88 27.2 63.22 30.23 63.22 30.23 25.05 11.75 41.05 37.94 41.05 65.61z" fill="#224370"/>
<path d="m280.44 509.98h-272.78v-55.45c0-29.86 17.14-55.06 41.05-66.28 0 0 6.3-3.02 62.69-29.98l104.59 93.87.28.25z" fill="#6aa9ff"/>
<path d="m280.44 509.98h-64.45v-57.84l.28.25z" fill="#7985ed"/>
<path d="m267.533 51.55v71.93h-103.08v-71.93c0-28.3 22.78-51.27 51.01-51.54.18-.01.36-.01.52-.01h.01c28.47.01 51.54 23.08 51.54 51.55z" fill="#f4d34e"/>
<path d="m267.533 51.55v71.93h-51.54v-123.48c28.47.01 51.54 23.08 51.54 51.55z" fill="#ffa001"/>
<path d="m316.173 166.03v94.82c0 55.33-44.85 100.18-100.18 100.18s-100.18-44.85-100.18-100.18v-94.82c0-55.33 44.85-100.18 100.18-100.18 55.325 0 100.18 44.838 100.18 100.18z" fill="#f9c5b9"/>
<path d="m316.173 166.03v94.82c0 55.33-44.85 100.18-100.18 100.18v-295.18c55.325 0 100.18 44.838 100.18 100.18z" fill="#ffb19e"/>
<path d="m316.173 166.03v22.95c-55.342 0-100.18-44.856-100.18-100.18 0 55.344-44.858 100.18-100.18 100.18v-22.95c0-55.33 44.85-100.18 100.18-100.18s100.18 44.85 100.18 100.18z" fill="#ffa001"/>
<path d="m316.173 166.03v22.95c-55.342 0-100.18-44.856-100.18-100.18v-22.95c55.33 0 100.18 44.85 100.18 100.18z" fill="#f77e01"/>
<path d="m381.724 224.137 17.872 60.324 102.724-16.227v-95.507h-102.724z" fill="#e80b6a"/><path d="m368.228 172.727h31.369v172.917h-31.369z" fill="#c0b2b0"/>
<path d="m342.36 404.07h83v105.91h-83z" fill="#7985ed"/><path d="m425.365 368.053v36.02c0 21.131-18.582 38.256-41.5 38.256s-41.5-17.125-41.5-38.256v-36.02c0-21.036 18.422-38.108 41.205-38.252.1-.004.195-.004.294-.004s.195 0 .294.004c22.748.136 41.207 17.188 41.207 38.252z" fill="#ffb19e"/>
</svg>
  </div>
  <p class="topic">รายการผู้ประกอบธุรกิจนำเที่ยวทั้งหมด</p>
  <h3><asp:Label runat="server" Text="0" ID="lblTourAll"></asp:Label> รายการ</h3>
</a>

<a class="w3-margin card bordertransport w3-quarter w3-padding mr-4" href="BorderCheck.aspx">
  <div class="overlay2"></div>
  <div class="circle">
  <svg id="Layer_1" width="71px" height="76px"  viewBox="0 0 128 128"  xmlns="http://www.w3.org/2000/svg" data-name="Layer 1"><path d="m19.75 46.356h88.5v60.574h-88.5z" fill="#fedc8a"/><path d="m13 106.93h102v8.07h-102z" fill="#f2f4fb"/><path d="m13 38.134h102v8.07h-102z" fill="#cd5d47"/><path d="m108.25 38.134h-88.5l5-6.467h78.5z" fill="#fdae52"/><path d="m37.5 13h53v9.667h-53z" fill="#9fe3fa"/><path d="m41.065 22.667h5.25v9h-5.25z" fill="#a8413d"/><path d="m81.685 22.667h5.25v9h-5.25z" fill="#a8413d"/><path d="m52.125 78.5h23.75v28.43h-23.75z" fill="#cd5d47"/><g fill="#f2f4fb"><path d="m26.472 78.5h18.5v7h-18.5z"/><path d="m83.028 78.5h18.5v7h-18.5z"/><path d="m101.528 70.583h-75.056a1.75 1.75 0 0 0 0 3.5h75.057a1.75 1.75 0 0 0 0-3.5z"/></g><path d="m64 31.667c-5.25 6.25-16.5 6.583-16.5 6.583 4 27.84 16.5 27.84 16.5 27.84s12.5 0 16.5-27.841c0 .001-11.25-.332-16.5-6.582z" fill="#20c1e2"/></svg>
  </div>
  <p class="topic">รายการ<br />ด่านทั้งหมด</p>
  <h3><asp:Label runat="server" Text="0" ID="lblBorder"></asp:Label> รายการ</h3>
</a>

<a class="w3-margin card  stopping w3-quarter w3-padding mr-4" href="Conditionrule.aspx">
  <div class="overlay2"></div>
  <div class="circle">
  <svg  viewBox="0 0 512.00013 512" width="71px" height="76px"  xmlns="http://www.w3.org/2000/svg"><path d="m436.300781 75.398438c-49.5-49.5-114.902343-75.398438-180.300781-75.398438s-130.796875 25.898438-180.300781 75.398438c-100.933594 100.628906-100.933594 259.972656 0 360.601562 49.800781 49.796875 114.902343 75.699219 180.300781 75.699219s130.5-25.902344 180.300781-75.699219c100.933594-100.628906 100.933594-259.972656 0-360.601562zm-180.300781-15.699219c39.601562 0 79.199219 13 113.101562 37l-113.101562 113.097656-113.101562-113.097656c33.902343-24 73.5-37 113.101562-37zm-159 82.898437 113.101562 113.101563-113.101562 113.101562c-49.332031-69.683593-49.332031-156.519531 0-226.203125zm159 309.101563c-39.601562 0-79.199219-13.003907-113.101562-37l113.101562-113.101563 113.101562 113.101563c-33.902343 24-73.5 37-113.101562 37zm159-82.898438-113.097656-113.101562 113.097656-113.101563c49.335938 69.683594 49.335938 156.519532 0 226.203125zm0 0" fill="#ff4949"/><path d="m436.300781 75.398438c-49.5-49.5-114.902343-75.398438-180.300781-75.398438v59.699219c39.601562 0 79.199219 13 113.101562 37l-113.101562 113.097656v91.800781l113.101562 113.101563c-33.902343 24-73.5 37-113.101562 37v60c65.398438 0 130.5-25.902344 180.300781-75.699219 100.933594-100.628906 100.933594-259.972656 0-360.601562zm-21.300781 293.402343-113.097656-113.101562 113.097656-113.101563c49.335938 69.683594 49.335938 156.519532 0 226.203125zm0 0" fill="#ff193d"/></svg>
  </div>
  <p class="topic">รายการ<br />ฝ่าฝืนเงื่อนไข </p>
  <h3><asp:Label runat="server" Text="0" ID="lblCon"></asp:Label> รายการ</h3>
</a>
</div>
</div>
</center>
</asp:Panel>
<script type="text/javascript">

    
</script>
  

</asp:Content>