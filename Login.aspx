<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">

.contactMasterPage
{
    max-width:100%; 
    margin-top:3%;
}.contactLogin
{
    width:50%; 
    margin-top:1%;
    margin-bottom: -5%;
}
@media screen and (min-width: 480px) and (max-width:767px) and (orientation : portrait)
{
  .contactLogin
{
    width: 70%;
    margin-bottom: -20%;
    margin-top: 15%;
}  
}
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
.contactLogin
{
    width: 85%;
    margin-bottom: -20%;
    margin-top: 15%;
}
}
@media screen and (min-width: 360px) and (max-width:376px) and (orientation : portrait)
{
 .contactLogin
{
    width: 85%;
    margin-bottom: -20%;
    margin-top: 15%;
}
} 
@media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
{
  .contactLogin
{
    width: 85%;
    margin-bottom: -20%;
    margin-top: 15%;
}  
} 
</style>
    <center>
<div class="container p-0 contactLogin">
<!--div class="w3-row-padding">
        <div class="p-l-55 p-r-55 p-t-65 p-b-50"-->
          <div class="w3-card  w3-round-large w3-white w3-text-blue2">
            <div class="w3-container w3-padding" style="background-color:#F5F5F5;width:100%;">
 
            
                <img src="image/logo_dlt.png" style="width:130px; height:130px;margin-top:5%" alt="Avatar" class="avatar"> <br />
              <p class=" w3-text-purple" style="margin-top:3%;font-size:1em"><b>Foreign Vehicle Permit</b></p>
       
              <div class="form-group" style="margin-top:5%;width:75%">
                  <asp:TextBox ID="txtUsername" class="w3-input" placeholder="Username" runat="server" style="background-color:#F5F5F5"> </asp:TextBox>
                </div>

            <div class="form-group" style="width:75%;">
                <asp:TextBox ID="txtPassword" class="w3-input" type="password" placeholder="Password" runat="server" style="background-color:#F5F5F5"></asp:TextBox>
            </div>
            <br />
            <div class="w3-right w3-hide-small"  style="margin-top:-2%; margin-right:15%">
            <a href="#">Forgot Password ?</a>
        </div>
        
        <br />
              <div class="w3-center" style="margin-top:-1%">
                <button id="myInput"  style="Display:none" onclick="document.getElementById('ContentPlaceHolder1_LinkButton1').click();"></button>
                <asp:LinkButton ID="LinkButton1" type="submit" class="w3-button w3-padding w3-round w3-text-white w3-mobile" style="background-color:#FBAF3F;font-size:100%;border-radius:10px" runat="server"><i class="fa fa-sign-in" aria-hidden="true"></i> Login </asp:LinkButton>
                <%--<button class='w3-button w3-blue2 '><i class='fa fa-check-square-o'></i> Sign-in </button>--%>
                </div>  
                <div class="w3-center w3-hide-large w3-hide-medium"  style="margin-top:2%;">
            <a href="#">Forgot Password ?</a>
        </div>             
                <br/>


            </div>
          </div>
        <!--/div>
      </div-->
      </div>
      <br /><br />
</center>

    <script type="text/javascript">



        $('#ContentPlaceHolder1_txtUsername').keypress(function (e) {

                if(e.keyCode=='13') //Keycode for "Return"

                $('#myInput').click();
        });

         $('#ContentPlaceHolder1_txtPassword').keypress(function (e) {

                if(e.keyCode=='13') //Keycode for "Return"

                $('#myInput').click();
        });

</script>

</asp:Content>