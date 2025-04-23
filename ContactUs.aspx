<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ContactUs.aspx.vb" Inherits="_Default" %>

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

<div class="container">
<center>
              <h1 style="font-size: 2rem;color:#542a6b"><b>Contact Us</b></h1>
        <hr style="height:3px; border:none; width:145px; color:#542a6b; background-color:#542a6b; margin-top:-0.5%">
  <br />
<iframe id="mapContact" src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d15498.61311250261!2d100.55086400000002!3d13.799763!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x30e29c3e39e13081%3A0x7a71d0c6e58fd658!2sDepartment+Of+Land+Transport%2C+Khwaeng+Chom+Phon%2C+Khet+Chatuchak%2C+Krung+Thep+Maha+Nakhon+10900!5e0!3m2!1sen!2sth!4v1563267221686!5m2!1sen!2sth"  frameborder="0" style="border:0" allowfullscreen></iframe>
</center> 

<hr />


<center>
              <br /><h1 style="font-size: 2rem;color:#542a6b"><b>International Transport Affairs Sub-division</b></h1>
               <hr style="height:3px; border:none; width:600px; color:#542a6b; background-color:#542a6b; margin-top:-0.5%">
 </center>
              <div class=" w3-padding w3-container"  >
                <p style=" font-size:1.5rem"><i class="fa fa-home w3-hover-opacity " style="margin-top:1%" ></i> Planning Division, Department of Land Transport<br />
                &nbsp;&nbsp;&nbsp;Building 4, Floor 5<br />
                &nbsp;&nbsp;&nbsp;1032 Phaholyothin Road, Chom Phon, Chatuchak, Bangkok 10900 Thailand</p>
                <p style=" font-size:1.5rem"> <i class="fa fa-phone w3-hover-opacity  w3-text-dark-gray"></i> Telephone : 02-2718408-9 <span></span>
                <i class="fa fa-fax w3-hover-opacity w3-text-dark-gray" aria-hidden="true"></i>  Fax : 02-2718409<br /></p>
              </div>
 

</div>

</asp:Content>