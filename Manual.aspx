<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Manual.aspx.vb" Inherits="Manual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
.container{
  background-color:#F8F9F9;
  padding: 2rem;
  box-shadow: 4px 4px 8px rgba(0,0,0,0.1);
}
#mapContact
{
    width:1080px;
    height:450px;
}
@media screen and (min-width: 1025px) and (max-width:1449px)
{
     #mapContact
{
    width:800px;
    height:450px;
}
}
@media screen and (min-width: 980px) and (max-width:1024px)
{
   #mapContact
{
    width:650px;
    height:450px;
}
}
@media screen and (min-width: 480px) and (max-width:767px) and (orientation : portrait)
{
   #mapContact
{
    width:350px;
    height:350px;
}
   
 }
 
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
    #mapContact
{
    width:270px;
    height:270px;
}
    
    }
 @media screen and (min-width: 360px) and (max-width:376px) and (orientation : portrait)
 {
    
    #mapContact
{
    width:250px;
    height:250px;
}
     
}
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
 {#mapContact
{
      width:220px;
    height:220px;
}
  
  
  }
</style>


<style type="text/css">

    
 .img9  
{
    width: 960px;
    }
    
    .img7
{
    width: 780px;
    }
    
    .img5
{
    width: 500px;
    }
    
@media screen and (min-width: 480px) and (max-width:767px) and (orientation : portrait)
{
    .img , .img5 , .img7, .img9
{
    width: 280px;
    }
 b,h3 {
  
  font-size: 14px;
}
    
}
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
    .img, .img5 , .img7, .img9
{
    width: 280px;
    }
 b,h3 {
  
  font-size: 14px;
}
  
}
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
{
   .img, .img5 , .img7, .img9
{
    width: 280px;
    }
    b,h3 {
  
  font-size: 14px;
}
  
}
</style>

<div class="container" style=" max-width: 1200px">
<center>
              <h1  id="head0" style="<% Response.Write(Csstext)%>"><b>คู่มือผู้ประกอบธุรกิจนำเที่ยว</b></h1>
        <hr style="height:3px; border:none; width:370px; color:#542a6b; background-color:#542a6b; margin-top:-0.5%">
  <br />
<div class="w3-container "  style="Display:none" >
     <asp:Image ID="Image1" runat="server" Height="670px" ImageUrl="~/Upload/FileManual/Manual1.png" /><br/>
     <asp:LinkButton ID="btnPrev" class="btn w3-button w3-padding-small w3-round w3-large" runat="server" > << ก่อนหน้า</asp:LinkButton>
    <asp:LinkButton ID="btnNext" runat="server" class="btn w3-button w3-padding-small w3-round w3-large" >ถัดไป >> </asp:LinkButton> 
</div>

<div class="w3-container w3-left-align w3-border w3-round-large" style="background-color:#f0defa;">
<h3 style="<% Response.Write(Csstext2)%>" class="w3-padding w3-text-purple "> <center><b>สารบัญ</b></center> </h3>
<h3 > <b><a href="#head1" class="w3-padding w3-text-purple ">ระบบสารสนเทศเพื่อรองรับการขออนุญาตรถเพื่อการท่องเที่ยว </a></b> </h3>
<h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;  <a href="#head1_1" class="w3-padding w3-text-purple ">๑. กระบวนการขออนุญาตรถเพื่อการท่องเที่ยว </a></b></h3>
<h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;  <a href="#head1_2" class="w3-padding w3-text-purple ">๒. ระบบสารสนเทศสำหรับขออนุญาตรถเพื่อการท่องเที่ยว(ผู้ประกอบธุกิจนำเที่ยว) </a></b></h3> 
<h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="#head1_2" class="w3-padding w3-text-purple ">๒.๑ ลงทะเบียน </a></b></h3>
<h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="#head1_2_2" class="w3-padding w3-text-purple ">๒.๒ การเพิ่มผู้นำเที่ยว </a></b></h3>
<h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="#head1_2_3" class="w3-padding w3-text-purple ">๒.๓ การยื่นขออนุญาตรถเพื่อการท่องเที่ยว</a><%--<asp:Image ID="Image17" runat="server" ImageUrl="~/Upload/FileManual/iconNew.gif" />--%></b></h3>
<h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="#head1_2_4" class="w3-padding w3-text-purple ">๒.๔ ตรวจสอบรายการคำขออนุญาตรถเพื่อการท่องเที่ยวรายคันที่ยังไม่ผ่านการพิจารณา </a></b></h3>
<h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="#head1_2_5" class="w3-padding w3-text-purple ">๒.๕ ตรวจสอบรายการคำขออนุญาตรถเพื่อการท่องเที่ยวที่ผ่านการอนุมัติ </a></b></h3>
<h3 id="head1"> <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="#head1_2_6" class="w3-padding w3-text-purple ">๒.๖ การขอขยายเวลา </a></b></h3>
<h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="#head1_2_7" class="w3-padding w3-text-purple ">๒.๗ การแก้ไขรายการขออนุญาตรถเพื่อการท่องเที่ยว (กรณีเอกสารไม่สมบูรณ์)</a><%--<asp:Image ID="Image18" runat="server" ImageUrl="~/Upload/FileManual/iconNew.gif" />--%></b></h3>
<br />
</div>
<h3 id="head1_1"> </h3>
<br />
<br />
<div class="w3-container w3-left-align " >
    <h3 > <b>ระบบสารสนเทศเพื่อรองรับการขออนุญาตรถเพื่อการท่องเที่ยว </b></h3> 
    <h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;  ๑. กระบวนการขออนุญาตรถเพื่อการท่องเที่ยว </b></h3> 
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; รถส่วนบุคคลเพื่อการท่องเที่ยวจากประเทศต่างๆ ทั่วโลก ตามประกาศกรมการขนส่งทางบกเรื่อง กําหนดหลักเกณฑ์ วิธีการและเงื่อนไขในการขออนุญาต การอนุญาต ระยะเวลาในการใช้รถและเครื่องหมายแสดงการใช้รถที่นําเข้ามาในราชอาณาจักรเป็นการชั่วคราวเพื่อใช้ในการท่องเที่ยวหรือการอื่นใดที่มีความจําเป็นเฉพาะกรณี พ.ศ. ๒๕๖๒ อนุญาตให้ใช้รถในพื้นที่จังหวัดที่ได้รับการอนุญาต และเครื่องหมายแสดงการใช้รถมีอายุไม่เกิน ๓๐ วัน โดยมีขั้นตอนการขออนุญาตแสดงในรูปที่ ๑.๑</span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image2" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_1.png" />
        <p id="head1_2">รูปที่ ๑.๑ กระบวนการขออนุญาตข้ามพรมแดนของรถเพื่อการท่องเที่ยว</p></center>
        <br />
    <h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;  ๒. ระบบสารสนเทศสำหรับขออนุญาตรถเพื่อการท่องเที่ยว(ผู้ประกอบธุกิจนำเที่ยว) </b></h3> 
    <h3 id="head1_2_1"> <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ๒.๑ ลงทะเบียน </b></h3>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑. ผู้ประกอบธุรกิจนำเที่ยวต้องดำเนินการขึ้นทะเบียนโดยเข้าไปที่ https://fvp.dlt.go.th กดปุ่ม For ThaiTourist Agency จากนั้นกดปุ่ม Register ดังแสดงในรูปที่ ๑.๒ </span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image3" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_2.png" />
        <p>รูปที่ ๑.๒ หน้าแรกของระบบ</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๒.	ผู้ประกอบธุรกิจนำเที่ยวกรอกข้อมูลส่วนตัว ข้อมูลที่อยู่และกำหนด Username และ Password เพื่อใช้ในการ Login เพื่อขออนุญาตรถเพื่อท่องเที่ยว ดังแสดงในรูปที่ ๑.๓ </span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image4" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_3.png" />
        <p>รูปที่ ๑.๓ หน้าจอลงทะเบียนของผู้ประกอบธุรกิจนำเที่ยว</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๓.	ระบบแสดงข้อความว่าการลงทะเบียนผู้ขออนุญาตเรียบร้อยแล้วและสามารถกดปุ่ม Home กลับไปยังหน้าหลักได้ ดังแสดงในรูปที่ ๑.๔ </span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image5" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_4.png" />
        <p>รูปที่ ๑.๔  หน้าจอลงทะเบียนของผู้ประกอบธุรกิจนำเที่ยว (๒)</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๔.	ระบบแจ้งเตือนการสมัครสมาชิกไปยังประกอบธุรกิจนำเที่ยว ดังแสดงในรูปที่ ๑.๕ </span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image6" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_5.png" />
        <p>รูปที่ ๑.๕ หน้าจอแจ้งเตือนการสมัครสมาชิกของผู้ประกอบธุรกิจนำเที่ยวทาง E-mail</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๕.	ผู้ประกอบธุรกิจนำเที่ยวเข้าไปขออนุญาตรถเพื่อการท่องเที่ยวโดย Login เข้าสู่ระบบที่ https://fvp.dlt.go.th โดยกดปุ่ม For Thai Travel Agency จากนั้นกดปุ่ม Login ดังแสดงในรูปที่ ๑.๖ </span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image7" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_6.png" />
        <p>รูปที่ ๑.๖ หน้าจอแรกของระบบ</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๖.	ผู้ประกอบธุรกิจนำเที่ยวกรอก Username และ Password จากนั้นกดปุ่ม Loginดังแสดงในรูปที่ ๑.๗ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image8" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_7.png" />
        <p>รูปที่ ๑.๗ หน้าจอ Login ผู้ประกอบธุรกิจนำเที่ยว</p></center>--%>
        <center class="w3-padding-16" ><asp:Image ID="Image8_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_7_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px"  />
        <p>รูปที่ ๑.๗ หน้าจอ Login ผู้ประกอบธุรกิจนำเที่ยว</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๗.	ระบบแสดงรายการคำขออนุญาต ดังแสดงในรูปที่ ๑.๘ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image9" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_8.png" />
        <p id="head1_2_2">รูปที่ ๑.๘ หน้าจอตารางรายการที่ผู้ประกอบธุรกิจนำเที่ยวยื่นขออนุญาต</p></center>--%>
        <center class="w3-padding-16" ><asp:Image ID="Image9_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_8_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p id="head1_2_2">รูปที่ ๑.๘ หน้าจอตารางรายการที่ผู้ประกอบธุรกิจนำเที่ยวยื่นขออนุญาต</p></center><br />
    <h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ๒.๒ การเพิ่มผู้นำเที่ยว </b></h3>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑.	ผู้ประกอบธุรกิจนำเที่ยวสามารถเพิ่มผู้นำเที่ยวได้ โดยกดที่เมนู “Tour Leader or Assistant” กดปุ่ม Tour leader or assistant ดังแสดงในรูปที่ ๑.๙ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image10" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_9.png" />
        <p>รูปที่ ๑.๙ หน้าจอตารางรายชื่อผู้นำเที่ยว</p></center>--%>
    <center class="w3-padding-16" ><asp:Image ID="Image10_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_9_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๙ หน้าจอตารางรายชื่อผู้นำเที่ยว</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๒.	ผู้ประกอบธุรกิจนำเที่ยวกรอกข้อมูลผู้นำเที่ยว จากนั้นกดปุ่มบันทึกดังแสดงในรูปที่ ๑.๑๐ </span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image11" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_10.png" />
        <p id="head1_2_3">รูปที่ ๑.๑๐ หน้าจอลงทะเบียนผู้นำเที่ยว</p></center><br />
    <h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ๒.๓ การยื่นขออนุญาตรถเพื่อการท่องเที่ยว</b></h3>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑.	ผู้ประกอบธุรกิจนำเที่ยวสามารถยื่นขออนุญาตรถเพื่อการท่องเที่ยวได้ โดยกดที่เมนู “Active and Rejected Application” จากนั้นกดปุ่ม Apply for a permit ดังแสดงในรูปที่ ๑.๑๑ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image12" runat="server" ImageUrl="~/Upload/FileManual/Manual1_11.png" />
        <p id="head1_2_3_2">รูปที่ ๑.๑๑ หน้าจอตารางรายการที่ผู้ประกอบธุรกิจนำเที่ยวยื่นขออนุญาต</p></center>--%>
        <center class="w3-padding-16" ><asp:Image ID="Image12_2" CssClass="img9"  runat="server" ImageUrl="~/Upload/FileManual/Manual1_11_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p id="head1_2_3_2">รูปที่ ๑.๑๑ หน้าจอตารางรายการที่ผู้ประกอบธุรกิจนำเที่ยวยื่นขออนุญาต</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๒.	ระบบจะแสดงรายละเอียดให้ผู้ประกอบธุรกิจนำเที่ยวกรอกเพื่อขออนุญาตให้นักท่องเที่ยว โดยหน้าแรกกรอกข้อมูลเจ้าของรถ เมื่อกรอกข้อมูลครบถ้วนแล้วกดปุ่ม Next ดังแสดงในรูปที่ ๑.๑๒ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image13" runat="server" ImageUrl="~/Upload/FileManual/Manual1_12.png" />
        <p>รูปที่ ๑.๑๒ หน้าจอลงทะเบียนรถเพื่อการท่องเที่ยวโดยผู้ประกอบธุรกิจนำเที่ยว</p></center>--%>
    <center class="w3-padding-16" ><asp:Image ID="Image13_2" CssClass="img9" runat="server"  ImageUrl="~/Upload/FileManual/Manual1_12_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๑๒ หน้าจอลงทะเบียนรถเพื่อการท่องเที่ยวโดยผู้ประกอบธุรกิจนำเที่ยว</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๓.	กรอกข้อมูลส่วนตัวของผู้ขับหลักและผู้ขับสำรองคนที่ ๑ และ ๒ พร้อมแนบภาพถ่ายใบอนุญาตขับขี่ดังแสดงในรูปที่ ๑.๑๓ </span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image14" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_13.png" />
        <p>รูปที่ ๑.๑๓ หน้าจอลงทะเบียนรถเพื่อการท่องเที่ยวโดยผู้ประกอบธุรกิจนำเที่ยว (๒)</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๔.	ผู้ประกอบธุรกิจนำเที่ยวกรอกข้อมูลรถและแนบภาพถ่ายรถ เมื่อกรอกข้อมูลครบจากนั้น กดปุ่ม Next ดังแสดงในรูปที่ ๑.๑๔ </span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image15" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_14.png" />
        <p>รูปที่ ๑.๑๔ หน้าจอลงทะเบียนรถเพื่อการท่องเที่ยวโดยผู้ประกอบธุรกิจนำเที่ยว (๓)</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๕.	ผู้ประกอบธุรกิจนำเที่ยวกรอกข้อมูลข้อมูล พรบ.รถยนต์หรือรถจักรยานยนต์ จากนั้นกดปุ่ม Save ดังแสดงในรูปที่ ๑.๑๕ </span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image16" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_15.png" />
        <p>รูปที่ ๑.๑๕ หน้าจอลงทะเบียนรถเพื่อการท่องเที่ยวโดยผู้ประกอบธุรกิจนำเที่ยว (๔)</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๖.	ผู้ประกอบธุรกิจนำเที่ยวสามารถตรวจสอบรายการที่ยื่นแต่ยังไม่ได้รับการพิจารณาจากทางเจ้าหน้าที่กรมการขนส่งทางบกได้ โดยกดที่เมนู “Active and Rejected Application” ดังแสดงในรูปที่ ๑.๑๖ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image17" runat="server" ImageUrl="~/Upload/FileManual/Manual1_16.png" />
        <p>รูปที่ ๑.๑๖ หน้าจอตารางรายการรถเพื่อการท่องเที่ยวที่ถูกบันทึกในระบบ</p></center>--%>
    <center class="w3-padding-16" ><asp:Image ID="Image17_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_16_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๑๖ หน้าจอตารางรายการรถเพื่อการท่องเที่ยวที่ถูกบันทึกในระบบ</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๗.	ผู้ประกอบธุรกิจนำเที่ยวสามารถสร้างกรุ๊ปทัวร์ได้โดยกดที่เมนู “Tour Group” จากนั้นกดปุ่ม Add Tour Group ดังแสดงในรูปที่ ๑.๑๗ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image18" runat="server" ImageUrl="~/Upload/FileManual/Manual1_17.png" />
        <p>รูปที่ ๑.๑๗ หน้าจอตารางรายการกรุ๊ปทัวร์</p></center>--%>
        <center class="w3-padding-16" ><asp:Image ID="Image18_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_17_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๑๗ หน้าจอตารางรายการกรุ๊ปทัวร์</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๘.	ผู้ประกอบธุรกิจนำเที่ยวกรอกข้อมูลทั่วไปในการสร้างกรุ๊ปทัวร์ จากนั้นกดปุ่ม Next ดังแสดงในรูปที่ ๑.๑๘ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image19" runat="server" ImageUrl="~/Upload/FileManual/Manual1_18.png" />
        <p>รูปที่ ๑.๑๘ หน้าจอการสร้างกรุ๊ปทัวร์</p></center>--%>
    <center class="w3-padding-16" ><asp:Image ID="Image19_2" CssClass="img7"  runat="server" ImageUrl="~/Upload/FileManual/Manual1_18_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๑๘ หน้าจอการสร้างกรุ๊ปทัวร์</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๙.	จากนั้นผู้ประกอบธุรกิจนำเที่ยวเลือกรายการรถที่ต้องการนำมาอยู่ในกรุ๊ปทัวร์ที่สร้างขึ้น จากนั้นกดปุ่ม "Find Existing Vehicle" <%--หลังจากเลือกรายการรถที่จะนำมาอยู่ในกรุ๊ปทัวร์ครบถ้วนแล้ว จากนั้นกดปุ่ม Next ดังแสดงในรูปที่ ๑.๑๙--%> 
        ดังแสดงในรูปที่ ๑.๑๙.๑ จากนั้นรายการรถที่จะนำมาอยู่ในกรุ๊ปทัวร์ โดยการกดปุ่ม <asp:Image ID="Image13" runat="server" ImageUrl="~/Upload/FileManual/Manual_add.png" /> ดังแสดงในรูปที่ ๑.๑๙.๒ 
        ระบบก็จะแสดงรายการรถที่ถูกบันทึกในกรุ๊ปทัวร์ จากนั้นกดปุ่ม Next ดังแสดงในรูปที่ ดังแสดงในรูปที่ ๑.๑๙.๓ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image20" runat="server" ImageUrl="~/Upload/FileManual/Manual1_19.png" />
        <p>รูปที่ ๑.๑๙ หน้าจอการสร้างกรุ๊ปทัวร์ (๒)</p></center>--%>

        <center class="w3-padding-16" ><asp:Image ID="Image20_1" CssClass="img9"  runat="server" ImageUrl="~/Upload/FileManual/Manual1_20_1.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๑๙.๑ หน้าจอการสร้างกรุ๊ปทัวร์ (๒.๑)</p></center>

        <center class="w3-padding-16" ><asp:Image ID="Image20_2" CssClass="img9"  runat="server" ImageUrl="~/Upload/FileManual/Manual1_20_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๑๙.๒ หน้าจอการสร้างกรุ๊ปทัวร์ (๒.๒)</p></center>

        <center class="w3-padding-16" ><asp:Image ID="Image12" CssClass="img9"  runat="server" ImageUrl="~/Upload/FileManual/Manual1_20_3.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๑๙.๓ หน้าจอรายการรถที่ถูกบันทึกในกรุ๊ปทัวร์ (๒.๓)</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; กรณีไม่มีรายการรถที่ต้องการนำมาอยู่ในกรุ๊ปทัวร์นั้น ให้ผู้ประกอบธุรกิจนำเที่ยวกดปุ่ม "Add New Vehicle" ดังแสดงในรูปที่ ๑.๑๙.๔ จากนั้นระบบจะแสดงรายละเอียดให้ผู้ประกอบธุรกิจนำเที่ยวกรอกเพื่อขออนุญาตให้นักท่องเที่ยว ซึ่งหน้าจอเหมือนกับขั้นตอน <a href="#head1_2_3_2" class="w3-padding w3-text-purple ">๑.๒.๓ การยื่นขออนุญาตรถเพื่อการท่องเที่ยว</a> </span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image17" CssClass="img9"  runat="server" ImageUrl="~/Upload/FileManual/Manual1_20_3_1.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๑๙.๔ หน้าจอรายการรถที่ถูกบันทึกในกรุ๊ปทัวร์ (๒.๔)</p></center>

    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑๐. จากนั้นผู้ประกอบธุรกิจนำเที่ยวต้องเลือกผู้นำเที่ยวสำหรับกรุ๊ปทัวร์ดังกล่าว พร้อมแนบรูปหนังสือจดทะเบียนรถที่ผู้นำเที่ยวใช้เดินทาง จากนั้นกดปุ่ม Add ดังแสดงในรูปที่ ๑.๒๐ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image21" runat="server" ImageUrl="~/Upload/FileManual/Manual1_20.png" />
        <p>รูปที่ ๑.๒๐ หน้าจอการสร้างกรุ๊ปทัวร์ (๓)</p></center>--%>
        <center class="w3-padding-16" ><asp:Image ID="Image21_2" CssClass="img7"  runat="server" ImageUrl="~/Upload/FileManual/Manual1_20_4.png"  BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๒๐ หน้าจอการสร้างกรุ๊ปทัวร์ (๓)</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑๑. ระบบจะบันทึกข้อมูลของนักท่องเที่ยวลงในระบบและแสดงรายละเอียดของผู้นำเที่ยว จากนั้นกดปุ่ม Submit เพื่อทำการส่งไปยังเจ้าหน้าที่สำนักงานขนส่งจังหวัด ดังแสดงในรูปที่ ๑.๒๑ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image22" runat="server" ImageUrl="~/Upload/FileManual/Manual1_21.png" />
        <p>รูปที่ ๑.๒๑ หน้าจอการสร้างกรุ๊ปทัวร์ (๔)</p></center>--%>
        <center class="w3-padding-16" ><asp:Image ID="Image22_2" CssClass="img7"  runat="server" ImageUrl="~/Upload/FileManual/Manual1_21_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๒๑ หน้าจอการสร้างกรุ๊ปทัวร์ (๔)</p></center>
     <%--<h3 > <b>๑๐. ระบบจะแสดงรายการกรุ๊ปทัวร์พร้อมสถานะ Success กรณีกดปุ่ม Submit  และจะส่งคำขออนุญาตดังกล่าวไปยังเจ้าหน้าที่สำนักงานขนส่งจังหวัด ดังแสดงในรูปที่ ๑.๒๒ </b></h3>--%> 
     <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑๒. ระบบจะแสดงรายการกรุ๊ปทัวร์พร้อมสถานะ Pendings กรณีกดปุ่ม Submit  และจะส่งคำขออนุญาตดังกล่าวไปยังเจ้าหน้าที่สำนักงานขนส่งจังหวัด ดังแสดงในรูปที่ ๑.๒๒ </span>
    </div>
    <%--<center class="w3-padding-16" ><asp:Image ID="Image23" runat="server" ImageUrl="~/Upload/FileManual/Manual1_22.png" />
        <p id="head1_2_4">รูปที่ ๑.๒๒ หน้าจอตารางรายการกรุ๊ปทัวร์</p></center>--%>
        <center class="w3-padding-16" ><asp:Image ID="Image23_2"  CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_22_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p id="head1_2_4">รูปที่ ๑.๒๒ หน้าจอตารางรายการกรุ๊ปทัวร์</p></center>
        <br />
   <h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ๒.๔ ตรวจสอบรายการคำขออนุญาตรถเพื่อการท่องเที่ยวรายคันที่ยังไม่ผ่านการพิจารณา </b></h3>
   <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑.	ผู้ประกอบธุรกิจนำเที่ยวสามารถตรวจสอบรายการคำขออนุญาตรถเพื่อการท่องเที่ยวรายคันได้ โดยกดที่เมนู “Active and Rejected Application” รายการคำขออนุญาตที่ถูกส่งไปยังเจ้าหน้าที่สำนักงานขนส่งจังหวัดจะขึ้นสถานะ Pending ดังแสดงในรูปที่ ๑.๒๓ </span>
    </div>
     <%--<center class="w3-padding-16" ><asp:Image ID="Image24" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_23.png" />
        <p>รูปที่ ๑.๒๓ หน้าจอตารางรายการคำขออนุญาต</p></center>--%>
    <center class="w3-padding-16" ><asp:Image ID="Image24_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_23_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๒๓ หน้าจอตารางรายการคำขออนุญาต</p></center>
         <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๒.	ระบบจะแจ้งเตือนการยื่นขออนุญาตรถเพื่อการท่องเที่ยวให้ผู้ประกอบธุรกิจนำเที่ยวและนักท่องเที่ยวทราบทาง E-mail ดังแสดงในรูปที่ ๑.๒๔ </span>
    </div>
     <center class="w3-padding-16" ><asp:Image ID="Image25" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_24.png" />
        <p id="head1_2_5">รูปที่ ๑.๒๔ หน้าจอการแจ้งเตือนการยื่นขออนุญาตทาง E-mail</p></center><br />
       <h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ๒.๕ ตรวจสอบรายการคำขออนุญาตรถเพื่อการท่องเที่ยวที่ผ่านการอนุมัติ </b></h3>
  <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑.	ผู้ประกอบธุรกิจนำเที่ยวสามารถตรวจสอบคำขอที่ผ่านการอนุมัติจากเจ้าหน้าที่สำนักงานขนส่งจังหวัดได้ โดยกดที่เมนู “Permit” คำขออนุญาตที่ผ่านการอนุมัติจากเจ้าหน้าที่สำนักงานขนส่งจังหวัดจะแสดงสถานะ Pass (Waiting for payment) จากนั้นกดปุ่ม <asp:Image ID="Image26" runat="server" ImageUrl="~/Upload/FileManual/Manual_pdf.png" /> เพื่อตรวจสอบและพิมพ์ใบคำขออนุญาตดังแสดงในรูปที่ ๑.๒๕ </span>
    </div>
     <%--<center class="w3-padding-16" ><asp:Image ID="Image27" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_25.png" />
        <p>รูปที่ ๑.๒๕ หน้าจอตารางรายการคำขออนุญาตที่ผ่านการอนุมัติ</p></center>--%>
        <center class="w3-padding-16" ><asp:Image ID="Image27_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_25_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๒๕ หน้าจอตารางรายการคำขออนุญาตที่ผ่านการอนุมัติ</p></center>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๒.	หลังจากทำการพิมพ์ใบคำขออนุญาต ผู้ขออนุญาตต้องทำการตรวจสอบความถูกต้องภายในเอกสาร หากไม่ถูกต้องให้ทำการติดต่อไปยังสำนักงานขนส่งจังหวัดเพื่อทำการแก้ไขข้อมูล หากถูกต้องครบถ้วนให้ลงลายมือชื่อผู้ดำเนินการเพื่อรับรองว่าข้อมูลถูกต้องและเป็นความจริง และนำใบคำขออนุญาตไปยื่นพร้อมชำระค่าธรรมเนียมที่สำนักงานขนส่งจังหวัดที่ได้ทำการระบุไว้ในขั้นตอนการสร้างกรุ๊ปทัวร์ เพื่อรับเครื่องหมายแสดงการใช้รถ ดังแสดงในรูปที่ ๑.๒๖ </span>
    </div>
     <%--<center class="w3-padding-16" ><asp:Image ID="Image28" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_26.png" />
        <p id="head1_2_6">รูปที่ ๑.๒๖ หน้าจอแสดงตัวอย่างใบคำขออนุญาต</p></center>--%>
        <center class="w3-padding-16" ><asp:Image ID="Image8" CssClass="img5" runat="server" ImageUrl="~/Upload/FileManual/Manual1_26_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p id="head1_2_6">รูปที่ ๑.๒๖ หน้าจอแสดงตัวอย่างใบคำขออนุญาต</p></center><br />
         <h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ๒.๖ การขอขยายเวลา </b></h3>
    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑.	ผู้ประกอบธุรกิจนำเที่ยวสามารถยื่นขอขยายเวลาได้โดยกดที่เมนู ”Tour Group Success” จากนั้นเลือกกรุ๊ปทัวร์ที่ต้องการขอขยายเวลาจากนั้นกดปุ่ม <asp:Image ID="Image29" runat="server" ImageUrl="~/Upload/FileManual/Manual_add.png" />  เพื่อขอขยายเวลา โดยกรุ๊ปทัวร์ดังกล่าวต้องมีสถานะ “Success” ดังแสดงในรูปที่ ๑.๒๗ </span>
    </div>
     <%--<center class="w3-padding-16" ><asp:Image ID="Image30" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_27.png" />
        <p>รูปที่ ๑.๒๗ หน้าจอยื่นขอขยายเวลา</p></center>--%>
     <center class="w3-padding-16" ><asp:Image ID="Image30_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_27_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๒๗ หน้าจอยื่นขอขยายเวลา</p></center>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๒.	ผู้ประกอบธุรกิจนำเที่ยวกรอก End date และสาเหตุที่ขอขยายเวลาและไฟล์แจ้งวัตถุประสงค์การขอขยายเวลาจากนั้นกดปุ่ม Next ดังแสดงในรูปที่ ๑.๒๘ </span>
    </div>
     <%--<center class="w3-padding-16" ><asp:Image ID="Image31" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_28.png" />
        <p>รูปที่ ๑.๒๘ หน้าจอยื่นขอขยายเวลา(๒)</p></center>--%>
    <center class="w3-padding-16" ><asp:Image ID="Image31_2" CssClass="img7" runat="server" ImageUrl="~/Upload/FileManual/Manual1_28_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๒๘ หน้าจอยื่นขอขยายเวลา(๒)</p></center>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๓.	จากนั้นผู้ประกอบธุรกิจนำเที่ยวสามารถเลือกรถที่จะขอขยายเวลาได้เป็นรายคัน <%--จากนั้นกดปุ่ม Add ดังแสดงในรูปที่ ๑.๒๙--%> 
        จากนั้นกดปุ่ม "Find Existing Vehicle" ดังแสดงในรูปที่ ๑.๒๙.๑ จากนั้นเลือกรายการรถที่จะนำมาอยู่ในกรุ๊ปทัวร์ โดยการกดปุ่ม <asp:Image ID="Image9" runat="server" ImageUrl="~/Upload/FileManual/Manual_add.png" /> ดังแสดงในรูปที่ ๑.๒๙.๒ 
        ระบบก็จะแสดงรายการรถที่ถูกบันทึกในกรุ๊ปทัวร์ ดังแสดงในรูปที่ ๑.๒๙.๓ </span>
    </div>
    <%-- <center class="w3-padding-16" ><asp:Image ID="Image32" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_29.png" />
        <p>รูปที่ ๑.๒๙ หน้าจอยื่นขอขยายเวลา(๓)</p></center>--%>
    <center class="w3-padding-16" ><asp:Image ID="Image32_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_29_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๒๙.๑ หน้าจอยื่นขอขยายเวลา(๓.๑)</p></center>
        <center class="w3-padding-16" ><asp:Image ID="Image32_3" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_29_3.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๒๙.๒ หน้าจอยื่นขอขยายเวลา(๓.๒)</p></center>
        <center class="w3-padding-16" ><asp:Image ID="Image32_4" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_29_4.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๒๙.๓ หน้าจอยื่นขอขยายเวลา(๓.๓)</p></center>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๔.	ผู้ประกอบธุรกิจนำเที่ยวสามารถแก้ไขข้อมูลคนขับได้ โดยกดปุ่ม <asp:Image ID="Image33" runat="server" ImageUrl="~/Upload/FileManual/Manual_edit.png" /> ดังแสดงในรูปที่ ๑.๓๐ </span>
    </div>
     <%--<center class="w3-padding-16" ><asp:Image ID="Image34" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_30.png" />
        <p>รูปที่ ๑.๓๐ หน้าจอยื่นขอขยายเวลา(๔)</p></center>--%>
        <center class="w3-padding-16" ><asp:Image ID="Image34_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_30_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๓๐ หน้าจอยื่นขอขยายเวลา(๔)</p></center>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๕.	หลังจากผู้ประกอบธุรกิจนำเที่ยวแก้ไขข้อมูลคนขับเรียบร้อย สามารถกดปุ่ม Next เพื่อบันทึกข้อมูลคนขับใหม่ลงในระบบ ดังแสดงในรูปที่ ๑.๓๑ </span>
    </div>
     <center class="w3-padding-16" ><asp:Image ID="Image35" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_31.png" />
        <p>รูปที่ ๑.๓๑ หน้าจอยื่นขอขยายเวลา(๕)</p></center>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๖.	เมื่อผู้ประกอบธุรกิจนำเที่ยวเพิ่มข้อมูลคนขับครบถ้วนแล้ว จากนั้นผู้ประกอบธุรกิจนำเที่ยวสามารถแก้ไขหรือเพิ่มข้อมูลประกันภัยใหม่ได้ โดยกดปุ่ม <asp:Image ID="Image36" runat="server" ImageUrl="~/Upload/FileManual/Manual_edit.png" /> ที่ช่อง Insurance ดังแสดงในรูปที่ ๑.๓๒ </span>
    </div>
     <%--<center class="w3-padding-16" ><asp:Image ID="Image37" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_32.png" />
        <p>รูปที่ ๑.๓๒ หน้าจอยื่นขอขยายเวลา(๖)</p></center>--%>
    <center class="w3-padding-16" ><asp:Image ID="Image37_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_32_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๓๒ หน้าจอยื่นขอขยายเวลา(๖)</p></center>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๗.	จากนั้นผู้ประกอบธุรกิจนำเที่ยวเพิ่มข้อมูลประกันภัยให้ครบถ้วน หลังจากนั้นกดปุ่ม save ดังแสดงในรูปที่ ๑.๓๓ </span>
    </div>
     <center class="w3-padding-16" ><asp:Image ID="Image38" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_33.png" />
        <p>รูปที่ ๑.๓๓ หน้าจอยื่นขอขยายเวลา(๗)</p></center>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๘.	เมื่อผู้ประกอบธุรกิจนำเที่ยวเพิ่มข้อมูลคนขับครบถ้วนแล้วกดปุ่ม Next ดังแสดงในรูปที่ ๑.๓๔ </span>
    </div>
     <%--<center class="w3-padding-16" ><asp:Image ID="Image39" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_34.png" />
        <p>รูปที่ ๑.๓๔ หน้าจอยื่นขอขยายเวลา(๘)</p></center>--%>
    <center class="w3-padding-16" ><asp:Image ID="Image39_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_34_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px"  />
        <p>รูปที่ ๑.๓๔ หน้าจอยื่นขอขยายเวลา(๘)</p></center>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๙.	ผู้ประกอบธุรกิจนำเที่ยวสามารถแก้ไขข้อมูลผู้นำเที่ยวหรือข้อมูลรถนำเยวได้ โดยการลบข้อมูลผู้นำเที่ยวหรือรถนำเที่ยวเดิมออกก่อน จากนั้นจึงกรอกข้อมูลลงในระบบใหม่ จากนั้นกดปุ่ม Submit ดังแสดงในรูปที่ ๑.๓๕ </span>
    </div>
     <center class="w3-padding-16" ><asp:Image ID="Image40" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_35.png" />
        <p>รูปที่ ๑.๓๕ หน้าจอยื่นขอขยายเวลา(๙)</p></center>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑๐. ระบบจะแสดงรายการที่ผู้ประกอบธุรกิจนำเที่ยวได้ทำการขอขยายเวลาไป โดยจะมีสถานะ Pending และเป็นการขยายเวลาครั้งที่ ๑ ดังแสดงในรูปที่ ๑.๓๖ </span>
    </div>
     <%--<center class="w3-padding-16" ><asp:Image ID="Image41" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_36.png" />
        <p>รูปที่ ๑.๓๖ หน้าจอยื่นขอขยายเวลา(๑๐)</p></center>--%>
    <center class="w3-padding-16" ><asp:Image ID="Image41_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_36_2.png"  BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px"  />
        <p>รูปที่ ๑.๓๖ หน้าจอยื่นขอขยายเวลา(๑๐)</p></center>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑๑. หลังจากได้รับการอนุมัติขอขยายเวลาจากทางเจ้าหน้าที่กรมการขนส่งทางบกเรียบร้อยแล้ว สถานะของกรุ๊ปทัวร์จะเปลี่ยนเป็น Success ดังแสดงในรูปที่ ๑.๓๗ </span>
    </div>
     <%--<center class="w3-padding-16" ><asp:Image ID="Image42" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_37.png" />
        <p >รูปที่ ๑.๓๗ หน้าจอยื่นขอขยายเวลา(๑๑)</p></center>--%>
         <center class="w3-padding-16" ><asp:Image ID="Image42_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_37_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px"  />
        <p >รูปที่ ๑.๓๗ หน้าจอยื่นขอขยายเวลา(๑๑)</p></center>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑๒. เจ้าหน้าที่กรมการขนส่งทางบกสามารถตรวจสอบกรุ๊ปทัวร์ที่ยื่นขอขยายเวลา ว่าขอขยายเวลาจากกรุ๊ปทัวร์ใดได้ โดยกดปุ่ม <asp:Image ID="Image43" runat="server" ImageUrl="~/Upload/FileManual/Manual_dtl.png" /> ดังแสดงในรูปที่ ๑.๓๘ </span>
    </div>
     <%--<center  class="w3-padding-16" ><asp:Image ID="Image44" CssClass="img" runat="server" ImageUrl="~/Upload/FileManual/Manual1_38.png" />
        <p id="head1_2_7" >รูปที่ ๑.๓๘ หน้าจอยื่นขอขยายเวลา(๑๒)</p></center>--%>
        <center  class="w3-padding-16" ><asp:Image ID="Image44_2" CssClass="img9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_38_2.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p id="head1_2_7" >รูปที่ ๑.๓๘ หน้าจอยื่นขอขยายเวลา(๑๒)</p></center>

        <br />
        <h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ๒.๗ การแก้ไขรายการขออนุญาตรถเพื่อการท่องเที่ยว (กรณีเอกสารไม่สมบูรณ์) </b></h3>
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑.	ผู้ประกอบธุรกิจนำเที่ยวสามารแก้ไขรายการขออนุญาตรถเพื่อการท่องเที่ยวได้โดยกดที่เมนู "Tour Group Incomplete"  จากนั้นเลือกกรุ๊ปทัวร์ที่ต้องการแก้ไข จากนั้นกดปุ่ม <asp:Image ID="Image46" runat="server" ImageUrl="~/Upload/FileManual/Manual_edit.png" />  เพื่อทำการแก้ไข  ดังแสดงในรูปที่ ๑.๓๙ </span>
    </div>

    <center class="w3-padding-16" ><asp:Image ID="Image45" CssClass="img9"  runat="server"  ImageUrl="~/Upload/FileManual/Manual1_39.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๓๙ หน้าจอแก้ไขรายการขออนุญาตรถ</p></center>


        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๒.	ผู้ประกอบธุรกิจนำเที่ยวสามารถแก้ไขข้อมูลขออนุญาตรถ จากนั้นกดปุ่ม Next ดังแสดงในรูปที่ ๑.๔๐ </span>
    </div>

    <center class="w3-padding-16" ><asp:Image ID="Image47" CssClass="img7"  runat="server"  ImageUrl="~/Upload/FileManual/Manual1_40.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๔๐ หน้าจอแก้ไขรายการขออนุญาตรถ(๒) </p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๓.	จากนั้นผู้ประกอบธุรกิจนำเที่ยวสามารถเลือกรถที่ต้องการแก้ไขได้เป็นรายคัน จากนั้นกดปุ่ม <asp:Image ID="Image49" runat="server" ImageUrl="~/Upload/FileManual/Manual_edit.png" />  เพื่อทำการแก้ไข ดังแสดงในรูปที่ ๑.๔๑ </span>
    </div>

    <center class="w3-padding-16" ><asp:Image ID="Image48" CssClass="img7" runat="server"  ImageUrl="~/Upload/FileManual/Manual1_41.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๔๑ หน้าจอแก้ไขรายการขออนุญาตรถ(๓) </p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๔.	ระบบจะแสดงรายละเอียดให้ผู้ประกอบธุรกิจนำเที่ยวกรอกเพื่อขออนุญาตให้นักท่องเที่ยว ซึ่งหน้าจอเหมือนกับขั้นตอน <a href="#head1_2_3_2" class="w3-padding w3-text-purple ">๑.๒.๓ การยื่นขออนุญาตรถเพื่อการท่องเที่ยว</a> โดยระบบจะเปิดให้แก้ไขเฉพาะข้อมูลที่เจ้าหน้าที่ตรวจสอบสถานะเป็น "ไม่ผ่าน" เท่านั้น เมื่อทำการแก้ไขข้อมูลครบถ้วนแล้วกดปุ่ม Next ดังแสดงในรูปที่  ๑.๔๒ </span>
    </div>

    <center class="w3-padding-16" ><asp:Image ID="Image50" CssClass="img9"  runat="server"  ImageUrl="~/Upload/FileManual/Manual1_42.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๔๒ หน้าจอแก้ไขรายการขออนุญาตรถ(๔) </p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๕.	เมื่อทำการแก้ไขข้อมูลครบถ้วนแล้วกดปุ่ม Save ดังแสดงในรูปที่ ๑.๔๓ ระบบจะบันทึกสถานะเป็น Incomplete (ไม่สมบูรณ์) *แก้ไขแล้ว ดังแสดงในรูปที่ ๑.๔๔ จากนั้นให้กดปุ่ม Next </span>
    </div>

    <center class="w3-padding-16" ><asp:Image ID="Image51" CssClass="img7"  runat="server"  ImageUrl="~/Upload/FileManual/Manual1_43.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๔๓ หน้าจอแก้ไขรายการขออนุญาตรถ(๕) </p></center>
    <center class="w3-padding-16" ><asp:Image ID="Image52" CssClass="img7"  runat="server"  ImageUrl="~/Upload/FileManual/Manual1_44.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๔๔ หน้าจอแก้ไขรายการขออนุญาตรถ(๖) </p></center>
    
        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๖.	จากนั้นผู้ประกอบธุรกิจนำเที่ยวสามารถแก้ไขข้อมูลผู้นำเที่ยว เมื่อทำการแก้ไขข้อมูลครบถ้วนแล้วกดปุ่ม Summit ดังแสดงในรูปที่ ๑.๔๕</span>
    </div>
    <center class="w3-padding-16" ><asp:Image ID="Image53" CssClass="img7"  runat="server"  ImageUrl="~/Upload/FileManual/Manual1_45.png" BorderColor="Black"   BorderStyle="Solid" BorderWidth="2px" />
        <p>รูปที่ ๑.๔๕ หน้าจอแก้ไขรายการขออนุญาตรถ(๗) </p></center>

</div>
</center> 

<%--<hr />--%>
 

 <div class="w3-right"> <a href="#head0" class="w3-padding w3-text-purple "> <i class="fa fa-toggle-up" aria-hidden="true"></i> <b>สารบัญ</b> </a> </div>
</div>

</asp:Content>
  
 
<asp:Content ID="Content5" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

