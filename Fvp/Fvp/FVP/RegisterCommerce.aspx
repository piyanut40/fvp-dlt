<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RegisterCommerce.aspx.vb" Inherits="RegisterCommerce" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/jquery-ui.css" rel="stylesheet" />  
 <script type="text/javascript" src="Scripts/jquery-ui.js"></script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <header class="w3-container" style="padding-top:22px">
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
                        alert('3 Decimal only !!!');
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
            alert('Please use number !!');
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
<!--div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6" align=center>
             <div class=" w3-text-purple">
             <div class=" w3-container p-2 w3-border w3-round-large w3-border-deep-purple">
                <h1 style="font-family: 'Kanit', sans-serif;">Sign-up Internaltional Agreement Commercial Transport Vehicle</h1>
                </div>
                </div>
                <hr>
            </div>
        </div-->
<p class=" w3-text-purple w3-hide-medium w3-hide-small w3-center" style="font-size:1.8em;"><b>Sign-up Internaltional Agreement Commercial Transport Vehicle</b></p>
<p class=" w3-text-purple w3-hide-large w3-center" style="font-size:1em;"><b>Sign-up Internaltional Agreement Commercial Transport Vehicle</b></p>
<div id="formT2" class="w3-card-2 w3-round-large w3-theme-l5 w3-padding" runat="server" style="margin-top:3%">

  <div class="w3-purple w3-padding w3-round issue">

 <a class="headmenu w3-text-white w3-wide " style="font-size:22px"><b> Issue </b></a>

</div>
  
<div class="w3-row w3-padding-small ">

    <div class="w3-col l2 <% Response.Write(Css)%>">
       Permit Number : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtpermit_no" runat="server" placeholder="Permit Number" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
    <asp:HiddenField ID="hidcar_id" runat="server" />
    <asp:HiddenField ID="hidlicense_id" runat="server" />
    <div class="w3-col l2 <% Response.Write(Css)%>" >
       Place of Issue : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:Textbox ID="txtissue_place" runat="server" placeholder="Place of Issue" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        Issue Date :
     </div>
      
    <div class="w3-col l3 mr-5">
     <%--<asp:Textbox ID="txtissue_date" type="date" runat="server" placeholder="Issue Date" class="w3-input w3-border w3-round-large"></asp:Textbox>--%>
     <asp:Textbox ID="txtissue_date" runat="server" class="w3-input w3-border w3-round-large"></asp:Textbox>
    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        Expiry Date (Valid Until) :
     </div>
      
    <div class="w3-col l3">
     <%--<asp:Textbox ID="txtexpiry_date" type="date" runat="server" placeholder="Expiry Date (Valid Until)" class="w3-input w3-border w3-round-large"></asp:Textbox>--%>
     <asp:Textbox ID="txtexpiry_date" runat="server" class="w3-input w3-border w3-round-large"></asp:Textbox>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
       Extended Until : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <%--<asp:Textbox ID="txtextended_until" type="date" runat="server" placeholder="Extended Until" class="w3-input w3-border w3-round-large"></asp:Textbox>--%>
        <asp:Textbox ID="txtextended_until" runat="server" class="w3-input w3-border w3-round-large"></asp:Textbox>
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
       Motor Vehicle TAD Number : 
     </div>
      
    <div class="w3-col l3">
        <asp:Textbox ID="txttad_no" runat="server" placeholder="Motor Vehicle TAD Number" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
    

  </div>

    <div class="w3-row w3-padding-small">

      <div class="w3-col l2 <% Response.Write(Css)%>" >
        Issuing Authority :
     </div>
      
    <div class="w3-col l8">
     <asp:Textbox ID="txtissuing_authority" runat="server" placeholder="Issuing Authority" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
      
  </div>

  <!--div class="w3-row w3-padding-small">

    <h4 class="headmenu w3-purple2 w3-padding"><b> # Operator</b></h4>
</div-->

<div class="w3-purple w3-padding w3-round issue">

 <a class="headmenu w3-text-white w3-wide " style="font-size:22px"><b> Operator </b></a>

</div>

   <div class="w3-row w3-padding-small">

   
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        Name of Transport Operator :
     </div>
      
    <div class="w3-col l8">
     <asp:Textbox ID="txttransport_operator_name" runat="server" placeholder="Name of Transport Operator" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>
   
      <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
      Address : 
     </div>
      
    <div class="w3-col l8">
        <asp:Textbox ID="txtaddress" runat="server" placeholder="Address" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

     <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
       Province : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtprovince" runat="server" placeholder="Province" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="w3-col l1 mr-4 <% Response.Write(Css)%>" >
       Telephone:
     </div>
      
    <div class="w3-col l3">
     <asp:Textbox ID="txttelephone" runat="server" placeholder="Telephone" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
       E-mail : 
     </div>
      
    <div class="w3-col l3">
        <asp:Textbox ID="txtemail" runat="server" placeholder="E-mail" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     

  </div>
  <br />
  <div class="w3-row w3-padding-small">
    <br />
    <h5 class="headmenu  w3-padding-left"> If different from Operator  </h5>

     <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
       Name of Vehicle Owner : 
     </div>
      
    <div class="w3-col l8">
        <asp:Textbox ID="txtvehicle_owner_name" runat="server" placeholder="Name of Vehicle Owner" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      

  </div>

  <div class="w3-row w3-padding-small">

   <div class="w3-col l2 <% Response.Write(Css)%>" >
       Address :
     </div>
      
    <div class="w3-col l8">
     <asp:Textbox ID="txtvehicle_owner_address" runat="server" placeholder="Address" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
      Province : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtvehicle_owner_province" runat="server" placeholder="Province" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="w3-col l1 mr-4  <% Response.Write(Css)%>" >
       Telephone:
     </div>
      
    <div class="w3-col l3">
     <asp:Textbox ID="txtvehicle_owner_telephone" runat="server" placeholder="Telephone" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
       E-mail : 
     </div>
      
    <div class="w3-col l3">
        <asp:Textbox ID="txtvehicle_owner_email" runat="server" placeholder="E-mail" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     

  </div>
  <br />
  </div>

    <!--div class="w3-row w3-padding-small">

 <h4 class="headmenu w3-purple2 w3-padding"><b> # Vehicle</b></h4>
</div-->
<div class="w3-purple w3-padding w3-round issue">

 <a class="headmenu w3-text-white w3-wide " style="font-size:22px"><b> Vehicle </b></a>

</div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
      Type of Vehicle : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtvehicle_type" runat="server" placeholder="Type of Vehicle" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Registration Number :
     </div>
      
    <div class="w3-col l3">
     <asp:Textbox ID="txtregistration_no" runat="server" placeholder="Registration Number" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
      Vehicle Category : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtvehicle_category" runat="server" placeholder="Vehicle Category" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Date of Registration :
     </div>
      
    <div class="w3-col l3">
     <%--<asp:Textbox ID="txtregis_date" runat="server" type="date" placeholder="Date of Registration" class="w3-input w3-border w3-round-large"></asp:Textbox>--%>
     <asp:Textbox ID="txtregis_date" runat="server" class="w3-input w3-border w3-round-large"></asp:Textbox>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
      Registered at Province: 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtregis_province" runat="server" placeholder="Registered at Province" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
      Semi-trailer : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtsemi_trailer" runat="server" placeholder="Semi-trailer" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
    

    </div>

    <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
     Brand : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtbrand" runat="server" placeholder="Brand" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Model :
     </div>
      
    <div class="w3-col l3">
     <asp:Textbox ID="txtmodel" runat="server" placeholder="Model" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
     VIN Number : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtvin_no" runat="server" placeholder="VIN Number" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Engine Number :
     </div>
      
    <div class="w3-col l3">
     <asp:Textbox ID="txtengine_no" runat="server" placeholder="Engine Number" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
    Number of Axles : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtaxles_no" runat="server" onBlur="formatComma(this)" placeholder="Number of Axles" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Colour :
     </div>
      
    <div class="w3-col l3">
     <asp:Textbox ID="txtcolour" runat="server" placeholder="Colour" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
    Capacity in CC : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtcapacity_cc" runat="server" placeholder="Capacity in CC" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Gross Weight in Kg:
     </div>
      
    <div class="w3-col l3">
     <asp:Textbox ID="txtweight_gross" runat="server" placeholder="Gross Weight in Kg" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
    Net Weight in Kg : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtweight_net" runat="server" placeholder="Net Weight in Kg" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Number of Seats (for Bus) :
     </div>
      
    <div class="w3-col l3">
     <asp:Textbox ID="txtseats_no" runat="server" placeholder="Number of Seats (for Bus)" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
    Width in Metres : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtwidth" runat="server" placeholder="Width in Metres" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Length in Metres :
     </div>
      
    <div class="w3-col l3">
     <asp:Textbox ID="txtlength" runat="server" placeholder="Length in Metres" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2 <% Response.Write(Css)%>" >
    Height in Metres : 
     </div>
      
    <div class="w3-col l3 mr-5">
        <asp:Textbox ID="txtheight" runat="server" placeholder="Height in Metres" onBlur="formatComma(this)" class="w3-input w3-border w3-round-large"></asp:Textbox>

    </div>

      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Country Vehicle :
     </div>
      
    <div class="w3-col l3">
        <asp:DropDownList ID="ddlCountryCar" class="w3-input w3-border w3-round-large" runat="server">
        </asp:DropDownList>
    </div>
     
  </div>



   <div class="w3-row w3-padding-small m-5">
    <center>
    <asp:LinkButton ID="lnkBack" class="w3-button w3-purple w3-padding w3-round" runat="server" style="margin-top:5%"><i class="fa fa-arrow-left" aria-hidden="true"></i> Cancel</asp:LinkButton>
    <asp:LinkButton ID="lnkSubmit" class="w3-button w3-purple w3-padding w3-round" runat="server" style="margin-top:5%"><i class="fa fa-save" aria-hidden="true"></i> Submit</asp:LinkButton>
      
      </center>  
  </div>
  
  </div>
</asp:Content>

