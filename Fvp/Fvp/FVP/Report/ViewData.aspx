<%@ Page Title="" Language="VB" MasterPageFile="MasterPageViewData.master" AutoEventWireup="false" CodeFile="ViewData.aspx.vb" Inherits="Viewdata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
  <%-- <link href="../Styles/datatables.min.css" rel="stylesheet">--%>
  <%--  <script type="text/javascript" src="../Scripts/datatables.min.js"></script>--%>
     <link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
     <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
  <link rel="Stylesheet" type="text/css" href="../Scripts/Semantic/semantic.min.css" />
    <script src="../Scripts/Semantic/semantic.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <style>

.fontKanit
{ font-family: 'Kanit', sans-serif;
  
}
hr { 
    display: block;
    margin-top: -0.4em;
    margin-bottom: 0.5em;
    border-style: inset;
    border-width: 21x;
    margin-left: 15px;
    width: 210px;
}.conta {
  background-color:#F8F9F9;
  padding: 2rem;
  box-shadow: 4px 4px 8px rgba(0,0,0,0.1);
}.nav {
  background-color: #530f87;
  display: flex;
  align-items: center;
  justify-content:center;
  padding: 1rem;
  margin: 0 -3rem 2rem;
  box-shadow: 2px 2px 4px rgba(0,0,0,0.1);
  position: relative;
  color:White;
}.colortext{font-family: 'Kanit', sans-serif;color:#6c6e70; font-size:14px;}
.t1{ margin-top:0.5%;}
.t2{ margin-top:2%;}
.ex1{color:#5e239d; font-size:16px;}
.ex2{color:#5e239d; font-size:16px;}
.ex3{color:#5e239d; font-size:16px;}
.sizeCarImg{width: 250px; height: 180px;}
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
  .t1
    {
      margin-top:0%;
      margin-left:-3%;
      }
      .t2
    {
      margin-top:0%;
      margin-left:-3%;
      }
       .ex1
    {
         color:#5e239d; 
         font-size:16px;
         margin-right: 50px;
      }  
      .ex2
    {
         color:#5e239d; 
         font-size:16px;
         margin-right: 30px;
      }
      .ex3
    {
         color:#5e239d; 
         font-size:16px;
         margin-right: 60px;
      }
.sizeCarImg
{/*width: 150px; height: 120px;*/ 
    width: 60px;
    height: 60px;
    margin-left: -20px;
}
}
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
 {  .t1
    {
      margin-top:0%;
      margin-left:-3%;
      }
      .t2
    {
      margin-top:0%;
      margin-left:-3%;
      } 
      .ex1
    {
         color:#5e239d; 
         font-size:16px;
          margin-right: 50px;
      } 
      .ex2
    {
         color:#5e239d; 
         font-size:16px;
         margin-right: 30px;
      } .ex3
    {
         color:#5e239d; 
         font-size:16px;
         margin-right: 60px;
      }
.sizeCarImg
{
  /*width: 150px; height: 120px;*/
    width: 60px;
    height: 60px;
    margin-left: -20px;
  
}
 }
</style>

<header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
<center>
   <h4 class="headtxt w3-xlarge fontKanit "><b> ข้อมูล<% Response.Write(text)%></b></h4>
   </center>
</header>
<br />
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<div id="formT1" runat="server">

<div id="divCompany" runat="server">
<div class="conta container w3-round-large"> 
<div class="ui stackable  three column divided grid container " >
     
        <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        Status Foreign Vehicle Permit (FVP) :   </b></a> <br class=" w3-hide-large" /><asp:Label ID="lblStatus_en" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
     </div>


   
  </div>
  <br />
<div class="w3-row w3-padding-small container">
<p class="w3-purple2 w3-padding w3-large fontKanit w3-hide-medium"><b><i class="fa fa-address-card-o" aria-hidden="true"></i>  Travel Agency</b></p>
</div>
<div class="ui stackable  four column divided grid container " style="margin-top:0.5%;">
  
    <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>Agency name : </b></a>   <br class=" w3-hide-large" /><asp:Label ID="lblcom_name" runat="server" Text="" CssClass="colortext " ></asp:Label>
      </div>
    </div>
    <div class="column w3-padding-small ">
      <div class="ui"><a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>Name :</b></a>  <br class=" w3-hide-large" /><asp:Label ID="lblagen_name" runat="server" Text="" CssClass="colortext "></asp:Label></div>
    </div>
    <div class="column w3-padding-small">
      <div class="ui"><a class="fontKanit" style="color:#5e239d; font-size:16px;"><b> Telephone :</b></a>    <br class=" w3-hide-large" /><asp:Label ID="lblcom_tel" runat="server" Text="" CssClass="colortext "></asp:Label></div>
    </div>
    <div class="column w3-padding-small ">
      <div class="ui "><a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>  E-mail :</b></a>  <br class=" w3-hide-large" /><asp:Label ID="lblcom_mail" runat="server" Text="" CssClass="colortext "></asp:Label></div>
    </div>


      <div class="ui fontKanit  w3-padding-small t1" ><a  style="color:#5e239d; font-size:16px;"><b> Address : </b></a>    <br class=" w3-hide-large" /><asp:Label ID="lblcom_address" runat="server" Text="" CssClass="colortext "></asp:Label></div>

    <%--<div class="column">
      <div class="ui segment">Content</div>
    </div>--%>


</div>
<!--div class="w3-row w3-padding">

    <div class="fontKanit w3-col l3 w3-padding-top  w3-padding-left w3-left-align" >
        
     </div>
      
   
      <div class="fontKanit w3-col l3 w3-padding-top  w3-padding-left w3-left-align " >
        
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top  w3-padding-left w3-left-align" >
       
     </div>
      
  
     
      <div class="fontKanit w3-col l3 w3-padding-top  w3-padding-left w3-left-align" >
       
     </div>
      

  </div-->

<%--  <div class="w3-row w3-padding-small">--%>

    <%--<div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        ข้อมูล : 
     </div>
      
    <div class="w3-col l8 w3-padding-top">
        <asp:Label ID="lblcom_info" runat="server" Text=""></asp:Label>

    </div>--%>
     
    <%--  <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        ประวัติ :
     </div>
      
    <div class="w3-col l3 w3-padding-top">
     <asp:Label ID="lblhistory" runat="server" Text=""></asp:Label>

    </div>--%>
<%--
  </div>--%>

<%--    <div class="w3-row w3-padding-small">--%>

<%--    <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        ข้อมูล : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    </div>--%>
     <%--
      <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        ประวัติ :
     </div>
      
    <div class="w3-col l8 w3-padding-top">
     <asp:Label ID="lblhistory" runat="server" Text=""></asp:Label>

    </div>

  </div>--%>
<%--
  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        โทรศัพท์ :  <asp:Label ID="lblcom_tel" runat="server" Text=""></asp:Label>
     </div>
      
  
     
      <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        E-mail :  <asp:Label ID="lblcom_mail" runat="server" Text=""></asp:Label>
     </div>
      
   

  </div>--%>
    <%--<div class="w3-row w3-padding-small">--%>

    <%--<div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขที่ใบอนุญาตประกอบธุรกิจท่องเที่ยว : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
        <asp:Label ID="lblcompany_license" runat="server" Text=""></asp:Label>

    </div>--%>
     
 <%--  <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        E-mail :
     </div>
      
    <div class="w3-col l3 w3-padding-top">
     <asp:Label ID="Label3" runat="server" Text=""></asp:Label>

    </div>--%>

 <%-- </div>--%>

   <!--div class="w3-row w3-padding"><%--w3-padding-small--%>

    <div class="fontKanit w3-col w3-padding" ><%--w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align--%>
        
     </div>
      
    
 <%--<div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        E-mail :
     </div>
      
    <div class="w3-col l3 w3-padding-top">
     <asp:Label ID="Label3" runat="server" Text=""></asp:Label>

    </div>--%>

  </div-->
  </div>
</div>

<br />
<div class="conta container w3-round-large"> 

<div class="w3-row w3-padding-small container">
 <p class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-address-card-o" aria-hidden="true"></i> Driver</b></p>
</div>
  <%--  <div class="w3-row w3-padding-small">--%>

   <%-- <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขบัตรประจำตัวประชาชนผู้ขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
        <asp:Label ID="lblid_code" runat="server" Text=""></asp:Label>
      <%-- <asp:TextBox ID="txtid_code"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชน" ></asp:TextBox>--%>
    <%--</div>--%>
    <div class="ui stackable  three column divided grid container " style="margin-top:2%;">
      <div class="column w3-padding-small">
    <div class="ui fontKanit ">
       <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b> Name :  </b></a>
         <br class=" w3-hide-large" /><asp:Label ID="lblname" runat="server" Text="" CssClass="colortext "></asp:Label>
     </div>
     </div>
     <div class="column w3-padding-small">
     <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b> Nationality : </b></a>
         <br class=" w3-hide-large" /><asp:Label ID="lblnational" runat="server" Text="" CssClass="colortext "></asp:Label>
  </div>
  </div>
    <div class="column w3-padding-small">
<div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;">
      <b> Gender :</b></a>
       <br class=" w3-hide-large" /><asp:Label ID="lblgender" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
   </div> 

   
  </div>
 

<%--  <div class="w3-row w3-padding-small">--%>

     <%--<div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขที่หนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lblpassport" runat="server" Text=""></asp:Label>
      <%--  <asp:TextBox ID="txtpassport"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>
    </div>--%>

    

 <%-- <div class="w3-row w3-padding-small" id="divIMG_passport" runat="server">

    <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        รูปถ่ายหนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l8 w3-padding-top">
       <asp:UpdatePanel ID="UpdgvIMG_passport" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div--%>
 <%-- </div>--%>

 <%-- <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        คำนำหน้าชื่อ : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:RadioButtonList ID="rdoprename" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="Mr.">Mr.</asp:ListItem>
            <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
            <asp:ListItem Value="other">other</asp:ListItem>
        </asp:RadioButtonList>
    </div>

   <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        อื่นๆ(ระบุ) :     
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtprename"  class="w3-input w3-border w3-round-large" runat="server" placeholder="คำนำหน้าชื่อ" ></asp:TextBox>
    </div>

  </div>--%>
  <%--   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        ชื่อ : 
        <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
     </div>

  </div>

   <div class="w3-row w3-padding-small">
   <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
      สัญชาติ : 
        <asp:Label ID="lblnational" runat="server" Text=""></asp:Label>
  </div>
  
      <%-- <asp:DropDownList ID="ddlnational" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
    </div>--%>

     <%--<div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        วัน เดือน ปี เกิด : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtdate" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>
    </div>--%>


<%--  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        รายละเอียด : 
     </div>
      
    <div class="w3-col l8 w3-padding-top">
    <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label>
          <%--<asp:TextBox ID="txtinfo" TextMode="MultiLine" class="w3-input w3-border w3-round-large" runat="server" placeholder="ข้อมูลเกี่ยวกับกำหนดการต่างๆ เช่น สถานที่พัก กำหนดการในแต่ละวัน"></asp:TextBox>
    </div>
     
   </div>--%>

<%--
   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        เพศ :      <asp:Label ID="lblgender" runat="server" Text=""></asp:Label>
     </div>
   </div>--%>



     <%--<div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        หมายเลขใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lbllicense_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtlicense_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>
    </div>--%>

  <div class="ui stackable three column divided grid container " style="margin-top:2%;">
   <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b> Country : </b></a>  <br class=" w3-hide-large" /><asp:Label ID="lblcountry_driver" runat="server" Text="" CssClass="colortext "></asp:Label>
    </div>
    </div>
   <div class="column w3-padding-small">
    <div class="ui fontKanit ">
    <a class="fontKanit <%--ex1--%>" style="color:#5e239d; font-size:16px;"><b>Passport Expiry Date : </b></a> <br class=" w3-hide-large" /><asp:Label ID="lblexp_pass_date" runat="server" Text="" CssClass="colortext "></asp:Label>
    </div>
    </div>
   <div class="column w3-padding-small">
    <div class="ui fontKanit ">
       <a class="fontKanit <%--ex2--%>" style="color:#5e239d; font-size:16px;"><b> Driver License Expiry Date :</b></a> 
    <br class=" w3-hide-large" /><asp:Label ID="lblexp_license_no" runat="server" Text="" CssClass=" colortext"></asp:Label>
       <%-- <asp:TextBox ID="txtexp_license_no" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>
    </div>
    </div> 
   <div class="ui fontKanit  w3-padding-small t2"   >
   <a  style="color:#5e239d; font-size:16px;"><b>  Email : </b></a>    <br class=" w3-hide-large" /><asp:Label ID="lblemail_driver" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>


 <%--   <div class="w3-row w3-padding-small" id="divIMG_license_no" runat="server">

    <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        รูปถ่ายใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top">
       <asp:UpdatePanel ID="UpdgvIMG_license_no" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>--%>

<%--   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        ที่อยู่ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top">
    <asp:Label ID="lbladdress_driver" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtaddress_driver"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>
    </div>

</div>--%>

   <!--div class="w3-row w3-padding-small">
<%--
    <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        โทรศัพท์  : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lbltel_driver" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txttel_driver" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>
    </div>--%>
     
    <%--  <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        Email :   <asp:Label ID="lblemail_driver" runat="server" Text=""></asp:Label>
     </div>--%>
      
   

  </div>
   </div-->  
  <%--<div class="w3-row w3-padding-small m-5">
  <center>

    <asp:LinkButton ID="lnkNext1" class="w3-button w3-blue2 w3-padding w3-round" runat="server">Next <i class="fa fa-forward" aria-hidden="true"></i></asp:LinkButton>

  </center>

  </div>--%>
  <br />
  <%--<div class="w3-row w3-padding-small">

 <h5 class="w3-gray w3-padding"><b> # ข้อมูลคนขับสำรอง</b></h5>
</div>--%>

<div class="w3-border w3-round-large w3-padding">

    <p class="fontKanit w3-large w3-padding-left" style="color:#5e239d; font-size:16px;"><b>Reserve Driver 1 </b></p>
    <hr style="width: 140px;" />

    
  <div class="ui stackable three column divided grid container " style="margin-top:2%;">

  <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b> Passport Expire :  </b></a>
       <br class=" w3-hide-large" /><asp:Label ID="lblexp_pass_date1" runat="server" Text="" CssClass=" colortext"></asp:Label>
      </div>
      </div>
  

     <%--<div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขที่หนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lblpassport1" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpassport1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>
    </div>--%>

   
      <div class="column w3-padding-small">
       <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b> Name :</b></a> 
       <br class=" w3-hide-large" /><asp:Label ID="lblname1" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
   </div>
<div class="column w3-padding-small">
<div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
      Nationality : </b></a>  
         <br class=" w3-hide-large" /><asp:Label ID="lblnational1" runat="server" Text="" CssClass=" colortext"></asp:Label>
        </div>
     </div>

  </div>
<%--  <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        คำนำหน้าชื่อ : 
     </div>
      
    <div class="w3-col l3 ">

        <asp:RadioButtonList ID="rdoprename1" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="Mr.">Mr.</asp:ListItem>
            <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
            <asp:ListItem Value="other">other</asp:ListItem>
        </asp:RadioButtonList>
    </div>

   <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        อื่นๆ(ระบุ) :     
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtprename1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="คำนำหน้าชื่อ" ></asp:TextBox>
    </div>

  </div>--%>

   <!--div class="w3-row w3-padding-small">

   <%-- <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        ชื่อ : <asp:Label ID="lblname1" runat="server" Text=""></asp:Label>
     </div>
      --%>
   
      <%--<div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        นามสกุล :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtsurname1" class="w3-input w3-border w3-round-large" runat="server" placeholder="นามสกุล" ></asp:TextBox>
    </div>--%>

  </div-->

   <!--div class="w3-row w3-padding-small">


   <%--<div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        สัญชาติ : <asp:Label ID="lblnational1" runat="server" Text=""></asp:Label>
     </div>--%>
      
   

  <%--  <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        หมายเลขใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lbllicense_no1" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>
    </div>--%>


  </div-->
    <br />
  </div>
   <br />
  <div class="w3-border w3-round-large w3-padding">

     <p class="fontKanit w3-large w3-padding-left" style="color:#5e239d; font-size:16px;"><b>Reserve Driver 2 </b></p>
    <hr style="width: 140px;" />
     <div class="ui stackable three column divided grid container " style="margin-top:2%;">

     <%--<div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขที่หนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lblpassport2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpassport2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>
    </div>
--%>
    <div class="column w3-padding-small">
       <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>Passport Expire :</a></b>   
         <br class=" w3-hide-large" /><asp:Label ID="lblexp_pass_date2" runat="server" Text="" CssClass=" colortext"></asp:Label>
        </div>
     </div>
      
           <div class="column w3-padding-small">
       <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>Name : </a></b> 
       <br class=" w3-hide-large" /><asp:Label ID="lblname2" runat="server" Text=""></asp:Label>
      </div>
     </div>
  <div class="column w3-padding-small">
       <div class="ui fontKanit ">
        <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>Nationality :</a></b> 
         <br class=" w3-hide-large" /><asp:Label ID="lblnational2" runat="server" Text=""></asp:Label>
        </div>
     </div>

  </div>

 <%-- <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        คำนำหน้าชื่อ : 
     </div>
      
    <div class="w3-col l3 ">

        <asp:RadioButtonList ID="rdoprename2" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="Mr.">Mr.</asp:ListItem>
            <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
            <asp:ListItem Value="other">other</asp:ListItem>
        </asp:RadioButtonList>
    </div>

   <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        อื่นๆ(ระบุ) :     
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtprename2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="คำนำหน้าชื่อ" ></asp:TextBox>
    </div>

  </div>--%>

   <!--div class="w3-row w3-padding-small">

 <%--   <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        ชื่อ :  <asp:Label ID="lblname2" runat="server" Text=""></asp:Label>
     </div>--%>
      
   
     
      <%--<div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        นามสกุล :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtsurname2" class="w3-input w3-border w3-round-large" runat="server" placeholder="นามสกุล" ></asp:TextBox>
    </div>--%>

  </div-->

   <!--div class="w3-row w3-padding-small">


   <%--<div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        สัญชาติ :  <asp:Label ID="lblnational2" runat="server" Text=""></asp:Label>
     </div>--%>
   

   <%-- <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        หมายเลขใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lbllicense_no2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtlicense_no2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>
    </div>--%>


  </div-->
    <br />
  </div>
  </div>
  <br />
  
  <div id="divCar" runat="server">
  <div class="conta  container w3-round-large">
<div class="w3-row w3-padding-small">
 <p class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-car" aria-hidden="true"></i> Vehicle</b></p>
</div>

    <div class="w3-row w3-padding-small container " id="divIMG_car" runat="server">

    <div class="ui fontKanit w3-medium"   >
   <a  style="color:#5e239d; font-size:16px;"><b>Vehicle Photos : </b></a> 
     </div>
      
    <div class="fontKanit w3-medium w3-col l4 w3-padding-top container ">
       <asp:UpdatePanel ID="UpdgvIMG_car" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <asp:DataList ID="DtlImg_car" runat="server" CellPadding="4" 
                    DataKeyField="gid" ForeColor="#333333" Width="100%" RepeatColumns="4" 
                            RepeatDirection="Horizontal">
                    
                    <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                           <ItemTemplate>
                               <table  >
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile" CssClass="sizeCarImg" runat="server" ImageUrl='<%# Bind("PathImg") %>' /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("LinkImg") %>' Target="_blank"  runat="server"> big picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                           </ItemTemplate>
                </asp:DataList>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

    <div class="ui stackable  four column divided grid container " style="margin-top:2%;">

    <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        Registration No. :  </b></a> <br class=" w3-hide-large" /> <asp:Label ID="lblplate" runat="server" Text="" CssClass=" colortext"></asp:Label>
        </div>
     </div>
      
  

   <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        Province of registration :  </b></a> <br class=" w3-hide-large" /> <asp:Label ID="lblstate_car" runat="server" Text="" CssClass=" colortext"></asp:Label>
        </div>
     </div>
      
     <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        Make :   </b></a> <br class=" w3-hide-large" /> <asp:Label ID="lblbrands" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
       </div>
  
   <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        Model :  </b></a> <br class=" w3-hide-large" /><asp:Label ID="lblmodels" runat="server" Text="" CssClass=" colortext"></asp:Label>

        </div>
     </div>
     
      
  </div>

    <!--div class="w3-row w3-padding-small">
  
    <%-- <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        ยี่ห้อ :    <asp:Label ID="lblbrands" runat="server" Text=""></asp:Label>
     </div>
      
  

        <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        รุ่นรถ :    <asp:Label ID="lblmodels" runat="server" Text=""></asp:Label>
     </div>--%>
  

  </div-->

   <div class="ui stackable  four column divided grid container " style="margin-top:2%;">
  
        <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        Seats : </b></a> <br class=" w3-hide-large" /><asp:Label ID="lblSeats" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
      </div>
    
      <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        Gross Weight (kg.) : </b></a> <br class=" w3-hide-large" /> <asp:Label ID="lblweight" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
      </div>

     <!--div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        รุ่นรถปี ค.ศ. :  </b></a> <%--<asp:Label ID="lblyears" runat="server" Text="" CssClass=" colortext"></asp:Label>--%>
     </div>
    </div-->

       <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        Colors : </b></a>  <br class=" w3-hide-large" /> <asp:Label ID="lblcolors" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
    </div>

 <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        Type : </b></a>  <br class=" w3-hide-large" /><asp:Label ID="lbltypecar" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
      </div>
  </div>

    <!--div class="w3-row w3-padding-small">

     <%-- <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        รุ่นรถปี ค.ศ. :  <asp:Label ID="lblyears" runat="server" Text=""></asp:Label>
     </div>
      
  
     
     
      <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        สี :   <asp:Label ID="lblcolors" runat="server" Text=""></asp:Label>
     </div>
   --%>
  </div-->

    <div class="ui stackable  two column divided grid container " style="margin-top:2%;">

   
<%--
      <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit ex3" style="color:#5e239d; font-size:16px;"><b>
        วันหมดอายุหนังสือเดินทางรถ : </b></a><asp:Label ID="lblexp_pass_car_date" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
     </div>--%>
      
    <!--div class="w3-col l3 w3-padding-top">
   
       <%--<asp:DropDownList ID="ddltypecar" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>--%>
    </div-->

    <%--<div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขเครื่องยนต์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lblNumEngine" runat="server" Text=""></asp:Label>
     <%--<asp:TextBox ID="txtNumEngine" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขเครื่อง" ></asp:TextBox>
    </div>--%>
     
  </div>

  
    <!--div class="w3-row w3-padding-small">


    <%--  <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขตัวรถ :
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lblnumcar" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtnumcar" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขตัวรถ" ></asp:TextBox>
    </div>--%>

  </div-->

  <%--  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        น้ำหนักบรรทุก : 
     </div>
      
    <div class="w3-col l3 ">
     <asp:TextBox ID="txtWeight_Carry" class="w3-input w3-border w3-round-large" runat="server" placeholder="น้ำหนักบรรทุก" ></asp:TextBox>
    </div>
     
      <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        ความจุกระบอกสูบ :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtCylinder_cap" class="w3-input w3-border w3-round-large" runat="server" placeholder="ความจุกระบอกสูบ" ></asp:TextBox>
    </div>

  </div>--%>

  <!--div class="w3-row w3-padding-small">

     <%--<div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขที่หนังสือเดินทางรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lblpass_car" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpass_car"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>
    </div>--%>

    <%-- <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        วันหมดอายุหนังสือเดินทางรถ : <asp:Label ID="lblexp_pass_car_date" runat="server" Text=""></asp:Label>
     </div>--%>
      
    

  </div-->

    <%--  <div class="w3-row w3-padding-small" id="divIMG_authorize_car" runat="server">

    <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        รูปถ่ายหนังสือมอบอำนาจ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top">
       <asp:UpdatePanel ID="UpdgvIMG_authorize_car" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileauthorize_car" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperauthorize_car" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>--%>

<%--  <div class="w3-row w3-padding-small" id="divIMG_regis_photo" runat="server">

    <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        รูปถ่ายหนังสือจดทะเบียนรถ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top">
       <asp:UpdatePanel ID="UpdgvIMG_regis_photo" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileregis_photo" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperregis_photo" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>--%>
 
   <br />
<%--  <div class="w3-border w3-round-large">
    <br />
    <h5 style="padding-left:15px;">ผู้ครอบครอง </h5>

<div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        ชื่อผู้ครอบครอง :  <asp:Label ID="lblholder" runat="server" Text=""></asp:Label>
     </div>
      
    
     
   <%--
   <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขบัตรประจำตัวประชาชน : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lblholder_id_card" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtholder_id_card" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชนผู้ครอบครอง" ></asp:TextBox>
    </div>

  </div>
--%>
<%--  <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        ที่อยู่ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top">
    <asp:Label ID="lbladdress_holder" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtaddress_holder"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>
    </div>

  </div>--%>

   <div class="w3-row w3-padding-small">

   <%-- <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        โทรศัพท์  : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lbltel_holder" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txttel_holder" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>
    </div>--%>
     
<%--      <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        Email : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtemail_holder" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
    </div>--%>

  </div>

  <br />

      <div class="w3-border w3-round-large w3-padding">

       <p class="fontKanit w3-large w3-padding-left" style="color:#5e239d;"><b>Area use vehicle</b></p>
    <hr style="width: 140px;" />

    <div class="w3-row w3-padding">

    <div class="fontKanit  w3-col  w3-padding"  >
        <a style="color:#5e239d;font-size:16px;"><b>Province :</b> </a> <br class=" w3-hide-large" /><asp:Label ID="lblprovarea" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>

  </div>
  

  </div>

  <br />
    <div class="w3-border w3-round-large w3-padding" >
    
        <p class="fontKanit w3-large w3-padding-left" style="color:#5e239d;"><b>Owner</b></p>
    <hr style="width:55px;" />
    <div class="w3-row w3-padding">

    <div class="fontKanit w3-col  w3-padding" >
        <a style="color:#5e239d;font-size:16px;"><b>Owner name : </b></a> <br class=" w3-hide-large" /><asp:Label ID="lblowner" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>

  </div>
  </div>
  </div>
  </div>
     <br />

</div>
 <div class="conta container w3-round-large">
     <div class="w3-row w3-padding-small">

 <p class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-id-card-o" aria-hidden="true"></i>  Compulsory motor vehicle insurance</b></p>
</div>
<div class="ui stackable  three column divided grid container " style="margin-top:2%;">

 <%--   <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขที่กรมธรรม์ประกันภัย : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lblinsure_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtinsure_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขที่กรมธรรม์ประกันภัย" ></asp:TextBox>
    </div>--%>
     
        <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        Insurance Company :   </b></a> <br class=" w3-hide-large" /><asp:Label ID="lblcompany" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
     </div>

        <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
       Period of Insurance From :  </b></a>  <br class=" w3-hide-large" /><asp:Label ID="lblstart_date" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
      </div>

        <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
       To : </b></a> <br class=" w3-hide-large" /><asp:Label ID="lblend_date" runat="server" Text="" CssClass=" colortext"></asp:Label>
        </div>
     </div>
   
  </div>
  <br />
   <div class="w3-row w3-padding-small">

 <p class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-id-card-o" aria-hidden="true"></i>  Third-party liability motor vehicle insurance</b></p>
</div>
<div class="ui stackable  three column divided grid container " style="margin-top:2%;">

 <%--   <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขที่กรมธรรม์ประกันภัย : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
    <asp:Label ID="lblinsure_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtinsure_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขที่กรมธรรม์ประกันภัย" ></asp:TextBox>
    </div>--%>
     
        <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
        Insurance Company :   </b></a> <br class=" w3-hide-large" /><asp:Label ID="lblcompany2" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
     </div>

        <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
       Period of Insurance From :  </b></a>  <br class=" w3-hide-large" /><asp:Label ID="lblstart_date2" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>
      </div>

        <div class="column w3-padding-small">
      <div class="ui fontKanit ">
      <a class="fontKanit" style="color:#5e239d; font-size:16px;"><b>
       To : </b></a> <br class=" w3-hide-large" /><asp:Label ID="lblend_date2" runat="server" Text="" CssClass=" colortext"></asp:Label>
        </div>
     </div>
   
  </div>

    <!--div class="w3-row w3-padding-small">

    <%-- <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        ระยะเวลาประกันภัย เริ่มต้น :   <asp:Label ID="lblstart_date" runat="server" Text=""></asp:Label>
     </div>
      

     <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        ถึงวันที่ : <asp:Label ID="lblend_date" runat="server" Text=""></asp:Label>
     </div>--%>
   

  </div-->

       <%--<div class="ui fontKanit  w3-padding-small t2"   >
   <a  style="color:#5e239d; font-size:16px;"><b> 
      The insured name: </b></a> <br class=" w3-hide-large" /><asp:Label ID="lblinsure_name" runat="server" Text="" CssClass=" colortext"></asp:Label>
     </div>--%>
      
   

    <%-- <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        เลขตัวถัง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
     <asp:Label ID="lblcar_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcar_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขตัวถัง"></asp:TextBox>
    </div>--%>

  </div>

  <%--  <div class="w3-row w3-padding-small" id="divIMG_act_photo" runat="server">

    <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        รูปถ่ายเอกสาร พรบ. : 
     </div>
      
    <div class="w3-col l8 w3-padding-top">
       <asp:UpdatePanel ID="UpdgvIMG_act_photo" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileact_photo" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperact_photo" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>
--%>
</div>

    <div id="formT2" runat="server">
 <%-- <div class="w3-row w3-padding-small">

 <h5 class="w3-purple w3-padding"><b> # Issue</b></h5>
</div>--%>
 <div class="conta">
     <div class="w3-row w3-padding-small">

 <h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-id-card-o" aria-hidden="true"></i>  Issue</b></h5>
</div>
<div class="w3-row w3-padding-small">

    <%--<div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
       Permit Number : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
        <asp:Label ID="lblpermit_no" runat="server" Text=""></asp:Label>

    </div>
--%>
    <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Place of Issue : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblissue_place" runat="server" Text=""></asp:Label>

    </div>
     
      

  </div>
 
  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        Issue Date :
     </div>
      
    <div class="w3-col l3 w3-padding-top">
     <asp:Label ID="lblissue_date" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
        Expiry Date (Valid Until) :
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
     <asp:Label ID="lblexpiry_date" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
       Extended Until : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblextended_until" runat="server" Text=""></asp:Label>

    </div>

    <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Motor Vehicle TAD Number : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lbltad_no" runat="server" Text=""></asp:Label>

    </div>
    

  </div>

    <div class="w3-row w3-padding-small">

      <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        Issuing Authority :
     </div>
      
    <div class="fontKanit w3-col l8 w3-padding-top">
     <asp:Label ID="lblissuing_authority" runat="server" Text=""></asp:Label>

    </div>
      
  </div>
  </div>
 <%-- <div class="w3-row w3-padding-small">

    <h5 class="w3-purple w3-padding"><b> # Operator</b></h5>
</div>
--%> <div class="conta">
     <div class="w3-row w3-padding-small">

 <h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-id-card-o" aria-hidden="true"></i>  Operator</b></h5>
</div>
   <div class="w3-row w3-padding-small">

   
      <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
        Name of Transport Operator :
     </div>
      
    <div class="fontKanit w3-col l8 w3-padding-top">
     <asp:Label ID="lbltransport_operator_name" runat="server" Text=""></asp:Label>

    </div>

  </div>
   
      <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
      Address : 
     </div>
      
    <div class="fontKanit w3-col l8 w3-padding-top">
        <asp:Label ID="lbladdress" runat="server" Text=""></asp:Label>

    </div>

  </div>

     <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
       Province : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblprovince" runat="server" Text=""></asp:Label>

    </div>
   <%--  
      <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Telephone :
     </div>
      
    <div class="w3-col l3 w3-padding-top">
     <asp:Label ID="lbltelephone" runat="server" Text=""></asp:Label>

    </div>--%>

  </div>

   <div class="w3-row w3-padding-small">

   <%-- <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
       E-mail : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
        <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>

    </div>--%>
     

  </div>
  <br />
  <div class="w3-border w3-round-large">
    <br />
    <h5 style="padding-left:15px;" class="fontKanit"> If different from Operator  </h5>

     <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
       Name of Vehicle Owner : 
     </div>
      
    <div class="fontKanit w3-col l8 w3-padding-top">
        <asp:Label ID="lblvehicle_owner_name" runat="server" Text=""></asp:Label>

    </div>
     
      

  </div>

  <div class="w3-row w3-padding-small">

   <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
       Address :
     </div>
      
    <div class="fontKanit w3-col l8 w3-padding-top">
     <asp:Label ID="lblvehicle_owner_address" runat="server" Text=""></asp:Label>

    </div>
  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
      Province : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblvehicle_owner_province" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Telephone :
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
     <asp:Label ID="lblvehicle_owner_telephone" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
       E-mail : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblvehicle_owner_email" runat="server" Text=""></asp:Label>

    </div>
     

  </div>
  <br />
  </div>
  </div>
   <%-- <div class="w3-row w3-padding-small">

 <h5 class="w3-purple w3-padding"><b> # Vehicle</b></h5>
</div>--%>
<div class="conta">
     <div class="w3-row w3-padding-small">

 <h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-id-card-o" aria-hidden="true"></i>   Vehicle</b></h5>
</div>
  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
      Type of Vehicle : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblvehicle_type" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Registration Number :
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
     <asp:Label ID="lblregistration_no" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
      Vehicle Category : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblvehicle_category" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Date of Registration :
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
     <asp:Label ID="lblregis_date" runat="server" Text=""></asp:Label>

    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
      Registered at Province : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblregis_province" runat="server" Text=""></asp:Label>

    </div>

     <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
      Semi-trailer : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblsemi_trailer" runat="server" Text=""></asp:Label>

    </div>
    

    </div>

    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
     Brand : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblbrand" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Model :
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
     <asp:Label ID="lblmodel" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

  <%--  <div class="w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
     VIN Number : 
     </div>
      
    <div class="w3-col l3 w3-padding-top">
        <asp:Label ID="lblvin_no" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Engine Number :
     </div>
      
    <div class="w3-col l3 w3-padding-top">
     <asp:Label ID="lblengine_no" runat="server" Text=""></asp:Label>

    </div>--%>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
    Number of Axles : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblaxles_no" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Colour :
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
     <asp:Label ID="lblcolour" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
    Capacity in CC : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblcapacity_cc" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Gross Weight in Kg :
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
     <asp:Label ID="lblweight_gross" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
    Net Weight in Kg : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblweight_net" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Number of Seats (for Bus) :
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
     <asp:Label ID="lblseats_no" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
    Width in Metres : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblwidth" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-col l2 w3-padding-top  w3-padding-left w3-left-align" >
       Length in Metres :
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
     <asp:Label ID="lbllength" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-col l2_2 w3-padding-top  w3-padding-left w3-left-align" >
    Height in Metres : 
     </div>
      
    <div class="fontKanit w3-col l3 w3-padding-top">
        <asp:Label ID="lblheight" runat="server" Text=""></asp:Label>

    </div>
     
  </div>
  
  </div>
  </div>
</asp:Content>

