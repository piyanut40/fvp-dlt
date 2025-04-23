<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="CarCommerceMgt.aspx.vb" Inherits="Admin_CarCommerceMgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
  <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
 <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
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
}

</style>
<header class="w3-container" style="padding-top:22px">
    <h4 class="headtxt w3-xlarge fontKanit"><b><i class="fa fa-dashboard"></i> <% Response.Write(textMgt)%>ข้อมูล<% Response.Write(text)%></b></h4>
</header>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


<script type="text/javascript">
    function formatComma(input) {
        var num = input.value.replace(/\,/g, '');
        if (!isNaN(num)) {
            if (num > 0) {
                if (num.indexOf('.') > -1) {
                    num = num.split('.');
                    num[0] = num[0].toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1,').split('').reverse().join('').replace(/^[\,]/, '');
                    if (num[1].length > 3) {
                        alert('มีทศนิยมได้3ตำแหน่งเท่านั้น');
                        input.value = 0; // oldvalue;
                        num[1] = num[1].substring(0, 3);
                    } input.value = num[0] + '.' + num[1];
                } else { input.value = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1,').split('').reverse().join('').replace(/^[\,]/, '') };
            }
            else {
                /*alert('กรุณาระบุจำนวนมากกว่า 0 บาท');
                input.value = 0; //oldvalue;*/
            };
        }
        else {
            alert('กรุณาระบุตัวเลข');
            input.value = 0; // oldvalue;
        }
    }

    $(function () {
        $("#<%=txtissue_date.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true
        });

        $("#<%=txtexpiry_date.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true
        });

        $("#<%=txtextended_until.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true
        });

        $("#<%=txtregis_date.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true
        });
    });


</script>
<div id="formT2" runat="server">
  <div class="w3-row w3-padding-small">
  <p class="headmenu w3-purple2 w3-padding w3-large fontKanit"><b><i class="fa fa-address-card-o" aria-hidden="true"></i>  Issue</b></p>
 <%--<h4 class="headmenu w3-purple2 w3-padding"><b> # Issue</b></h4>--%>
</div>

<div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>">
       Permit Number : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtpermit_no" runat="server" placeholder="Permit Number" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
    <asp:HiddenField ID="hidcar_id" runat="server" />
    <asp:HiddenField ID="hidlicense_id" runat="server" />
    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Place of Issue : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtissue_place" runat="server" placeholder="Place of Issue" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      

  </div>
 
  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Issue Date :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <%--<asp:Textbox ID="txtissue_date" type="date" runat="server" placeholder="Issue Date" class="w3-input w3-border w3-round-large"></asp:Textbox>--%>
     <asp:Textbox ID="txtissue_date" runat="server" class="w3-input w3-border w3-round-large"></asp:Textbox>
    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Expiry Date (Valid Until) :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <%--<asp:Textbox ID="txtexpiry_date" type="date" runat="server" placeholder="Expiry Date (Valid Until)" class="w3-input w3-border w3-round-large"></asp:Textbox>--%>
     <asp:Textbox ID="txtexpiry_date" runat="server" class="w3-input w3-border w3-round-large"></asp:Textbox>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Extended Until : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <%--<asp:Textbox ID="txtextended_until" type="date" runat="server" placeholder="Extended Until" class="w3-input w3-border w3-round-large"></asp:Textbox>--%>
        <asp:Textbox ID="txtextended_until" runat="server" class="w3-input w3-border w3-round-large"></asp:Textbox>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Motor Vehicle TAD Number : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txttad_no" runat="server" placeholder="Motor Vehicle TAD Number" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
    

  </div>

    <div class="w3-row w3-padding-small">

      <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Issuing Authority :
     </div>
      
    <div class="fontKanit w3-medium w3-col l8">
     <asp:Textbox ID="txtissuing_authority" runat="server" placeholder="Issuing Authority" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
      
  </div><br />

  <div class="w3-row w3-padding-small">
  <p class="headmenu w3-purple2 w3-padding w3-large fontKanit"><b><i class="fa fa-user-circle-o" aria-hidden="true"></i>  Operator</b></p>
    <%--<h4 class="headmenu w3-purple2 w3-padding"><b> # Operator</b></h4>--%>
</div>

   <div class="w3-row w3-padding-small">

   
      <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Name of Transport Operator :
     </div>
      
    <div class="fontKanit w3-medium w3-col l8">
     <asp:Textbox ID="txttransport_operator_name" runat="server" placeholder="Name of Transport Operator" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>
   
      <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
      Address : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8">
        <asp:Textbox ID="txtaddress" runat="server" placeholder="Address" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

     <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Province : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtprovince" runat="server" placeholder="Province" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Telephone :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <asp:Textbox ID="txttelephone" runat="server" placeholder="Telephone" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       E-mail : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtemail" runat="server" placeholder="E-mail" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     

  </div>
  <br />
  <div class="w3-border w3-round-large">
    <br />
   <%-- <h5 class="headmenu  w3-padding-left"> If different from Operator  </h5>--%>
    <p class="fontKanit w3-large  w3-padding-left"> <b>If different from Operator </b> </p>
    <hr />
     <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Name of Vehicle Owner : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8">
        <asp:Textbox ID="txtvehicle_owner_name" runat="server" placeholder="Name of Vehicle Owner" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      

  </div>

  <div class="w3-row w3-padding-small">

   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Address :
     </div>
      
    <div class="fontKanit w3-medium w3-col l8">
     <asp:Textbox ID="txtvehicle_owner_address" runat="server" placeholder="Address" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
      Province : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtvehicle_owner_province" runat="server" placeholder="Province" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Telephone :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <asp:Textbox ID="txtvehicle_owner_telephone" runat="server" placeholder="Telephone" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       E-mail : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtvehicle_owner_email" runat="server" placeholder="E-mail" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     

  </div>
  <br />
  </div><br />

    <div class="w3-row w3-padding-small">
    <p class="headmenu w3-purple2 w3-padding w3-large fontKanit"><b><i class="fa fa-car" aria-hidden="true"></i>  Vehicle</b></p>
<%-- <h4 class="headmenu w3-purple2 w3-padding"><b> # Vehicle</b></h4>--%>
</div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
      Type of Vehicle : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtvehicle_type" runat="server" placeholder="Type of Vehicle" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Registration Number :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <asp:Textbox ID="txtregistration_no" runat="server" placeholder="Registration Number" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
      Vehicle Category : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtvehicle_category" runat="server" placeholder="Vehicle Category" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Date of Registration :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <%--<asp:Textbox ID="txtregis_date" runat="server" type="date" placeholder="Date of Registration" class="w3-input w3-border w3-round-large"></asp:Textbox>--%>
     <asp:Textbox ID="txtregis_date" runat="server" class="w3-input w3-border w3-round-large"></asp:Textbox>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
      Registered at Province : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtregis_province" runat="server" placeholder="Registered at Province" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
      Semi-trailer : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtsemi_trailer" runat="server" placeholder="Semi-trailer" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
    

    </div>

    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
     Brand : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtbrand" runat="server" placeholder="Brand" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Model :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <asp:Textbox ID="txtmodel" runat="server" placeholder="Model" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
     VIN Number : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtvin_no" runat="server" placeholder="VIN Number" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Engine Number :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <asp:Textbox ID="txtengine_no" runat="server" placeholder="Engine Number" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
    Number of Axles : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtaxles_no" runat="server" placeholder="Number of Axles" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Colour :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <asp:Textbox ID="txtcolour" runat="server" placeholder="Colour" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
    Capacity in CC : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtcapacity_cc" runat="server" placeholder="Capacity in CC" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Gross Weight in Kg :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <asp:Textbox ID="txtweight_gross" runat="server" placeholder="Gross Weight in Kg" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
    Net Weight in Kg : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtweight_net" runat="server" placeholder="Net Weight in Kg" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Number of Seats (for Bus) :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <asp:Textbox ID="txtseats_no" runat="server" placeholder="Number of Seats (for Bus)" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
    Width in Metres : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtwidth" runat="server" placeholder="Width in Metres" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Length in Metres :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
     <asp:Textbox ID="txtlength" runat="server" placeholder="Length in Metres" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
    Height in Metres : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:Textbox ID="txtheight" runat="server" placeholder="Height in Metres" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Country Vehicle :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3">
        <asp:DropDownList ID="ddlCountryCar" class="w3-input w3-border w3-round-large" runat="server">
        </asp:DropDownList>
    </div>
     
  </div>

   <div class="w3-row w3-padding-small m-5">
    <center>
    <asp:LinkButton ID="lnkBack" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-arrow-left" aria-hidden="true"></i> Cancel</asp:LinkButton>
    <asp:LinkButton ID="lnkSubmit" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-save" aria-hidden="true"></i> Submit</asp:LinkButton>
      
      </center>  
  </div>
  
  </div>
</asp:Content>

