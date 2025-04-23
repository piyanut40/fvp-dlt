<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageC.master" AutoEventWireup="false" CodeFile="xxMgtEditG.aspx.vb" Inherits="Travel_xxMgtEditG" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Styles/w3.css">--%>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous" />
    <script type="text/javascript" src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <%--<link rel="stylesheet" href="~/Styles/w3.css">--%>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
    <link href="../Styles/progress-wizard.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>

    <link rel="Stylesheet" type="text/css" href="../Scripts/Semantic/semantic.min.css" />
    <script src="../Scripts/Semantic/semantic.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/css/w3-theme-deep-purple.css" />
    <link rel="stylesheet" href="../Styles/w3Home.css"/>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
  
  <style>
  body {
      overflow-x: unset;
   
      }
  @font-face{
      font-family: 'Kanit', sans-serif;
        src : url('font/ThaiSansNeue-Regular/thaisansneue-bold-webfont.woff2');
    
    
    }
    
  </style>


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
           <a class=" w3-text-purple" style="margin-left:0%"><b style="font-size:1.7em;margin-left:0%;font-family: 'Kanit', sans-serif;"><i class="fa fa-pencil-square" aria-hidden="true"></i>  Edit Application</b></a><br /><br />
    </header>
 <ul class="progress-indicator" style=" margin-top:10px;">
  <li id="tab1" class="active"> <span class="bubble"></span> Owner </li>
  <li id="tab2"> <span class="bubble"></span> Driver </li>
  <li id="tab3"><span class="bubble"></span> Vehicle </li>
  <li id="tab4"><span class="bubble"></span> Compulsory Motor Insurance  </li>
  <li id="tab6"> <span class="bubble"></span> Tour Group </li>
  <li id="tab5"> <span class="bubble"></span> Submit </li>
</ul>
<br />
           
<div align="center">
<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative w3-text-deep-purple w3-card-2 w3-round-large w3-theme-l5 w3-row-padding">          
<form>




<script type="text/javascript">

    function tab1() {

        document.getElementById("tab1").className = "active";
        document.getElementById("tab2").className = "";
        document.getElementById("tab3").className = "";
        document.getElementById("tab4").className = "";
        document.getElementById("tab5").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill pl-5";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form5").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form6").className = "text-dark w3-animate-right fill w3-hide";

    }


    function tab2() {

        document.getElementById("tab2").className = "active";
        document.getElementById("tab1").className = "completed";
        document.getElementById("tab3").className = "";
        document.getElementById("tab4").className = "";
        document.getElementById("tab5").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill pl-5";
        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form5").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form6").className = "text-dark w3-animate-right fill w3-hide";
    }

    function tab3() {

        document.getElementById("tab1").className = "completed";
        document.getElementById("tab2").className = "completed";
        document.getElementById("tab3").className = "active";
        document.getElementById("tab4").className = "";
        document.getElementById("tab5").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form3").className = "text-dark w3-animate-right fill pl-5";
        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form5").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form6").className = "text-dark w3-animate-right fill w3-hide";

    }

    function tab4() {

        document.getElementById("tab1").className = "completed";
        document.getElementById("tab2").className = "completed";
        document.getElementById("tab3").className = "completed";
        document.getElementById("tab4").className = "active";
        document.getElementById("tab5").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form4").className = "text-dark w3-animate-right pl-5";
        document.getElementById("form5").className = "text-dark w3-animate-right pl-5 w3-hide";
        document.getElementById("form6").className = "text-dark w3-animate-right fill w3-hide";

    }

    function tab5() {

        document.getElementById("tab1").className = "completed";
        document.getElementById("tab2").className = "completed";
        document.getElementById("tab3").className = "completed";
        document.getElementById("tab4").className = "completed";
        document.getElementById("tab6").className = "completed";
        document.getElementById("tab5").className = "active";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form5").className = "text-dark w3-animate-right pl-5";
        document.getElementById("form6").className = "text-dark w3-animate-right fill w3-hide";
    }

    function tab6() {

        document.getElementById("tab1").className = "completed";
        document.getElementById("tab2").className = "completed";
        document.getElementById("tab3").className = "completed";
        document.getElementById("tab4").className = "completed";
        document.getElementById("tab5").className = "completed";
        document.getElementById("tab6").className = "active";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form5").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form6").className = "text-dark w3-animate-right pl-5";
    }

    $(function () {
        $("#<%=txtDate.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-100:-15",
            showButtonPanel: true
        });
    });

    $(function () {
        $("#<%=txtPassportExpire.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "now :+20",
            setDate: new Date(),
            showButtonPanel: true
        });
    });

    $(function () {
        $("#<%=txtPassport_exp2.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "now :+20",
            setDate: new Date(),
            showButtonPanel: true
        });
    });

    $(function () {
        $("#<%=txtPassport_exp3.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "now :+20",
            setDate: new Date(),
            showButtonPanel: true
        });
    });

    $(function () {
        $("#<%=txtLicenseExpire.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "now :+20",
            setDate: new Date(),
            showButtonPanel: true
        });
    });


    $(function () {
        $("#<%=txtLicenseExpire2.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "now :+20",
            setDate: new Date(),
            showButtonPanel: true
        });
    });


    $(function () {
        $("#<%=txtLicenseExpire3.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "now :+20",
            setDate: new Date(),
            showButtonPanel: true
        });
    });




    $(function () {
        $("#<%=txtActStart.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            setDate: new Date(),
            showButtonPanel: true
        });
    });

    $(function () {
        $("#<%=txtActExpire.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "now :+20",
            setDate: new Date(),
            showButtonPanel: true
        });
    });





    
</script>


<script type="text/javascript">
    //    function alertDataOld() {
    //        $.confirm({
    //            title: 'Notification ',
    //            content: 'You have the information you entered in the previous time. Do you want to continue? ',
    //            buttons: {
    //                confirm: function () {
    //                    document.getElementById('MainContent_btnLoaddata').click();
    //                },
    //                cancel: function () {
    //                    //$.alert('Cancel');
    //                }
    //            }
    //        });
    //    }

    //    function alertDataDriver() {
    //        $.confirm({
    //            title: 'Notification ',
    //            content: 'Is driver the same as owner?     YES or NO ',
    //            buttons: {
    //                confirm: function () {
    //                    document.getElementById('MainContent_btnLoadDriver').click();
    //                },
    //                cancel: function () {
    //                    //$.alert('Cancel');
    //                }
    //            }
    //        });
    //    }

    function SaveSuccess() {

        alert("Save Information Success");

    }

    function fromCheck() {

        alert("Please complete the information !!!");

    }

    function fromCheck2() {

        alert("Please Upload Photo !!!");

    }

    function Error() {

        alert("Please Fill information !!!");

    }
        
</script>

<asp:Button ID="btnLoaddata" UseSubmitBehavior="false" runat="server" style="DISPLAY: none" Text="Button" />
<asp:Button ID="btnLoadDriver" UseSubmitBehavior="false" runat="server" style="DISPLAY: none" Text="Button" />
<asp:Button ID="btnSubmit" UseSubmitBehavior="false" runat="server" style="DISPLAY: none" Text="Button" />
 <asp:HiddenField ID="hiddriver_id" runat="server" />
 <asp:HiddenField ID="hidcar_id" runat="server" />
 <asp:HiddenField ID="hidact_id" runat="server" />
 <asp:HiddenField ID="hidlicense_id" runat="server" />
 <asp:HiddenField ID="hidsparedriver_id1" runat="server" />
 <asp:HiddenField ID="hidsparedriver_id2" runat="server" />
 <asp:HiddenField ID="HiddenField1" runat="server" />

<div id="form1" class="w3-animate-right fill center ui-form w3-margin text-dark ">
<div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom: .21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 30px;font-size: x-large;margin-top: -35px;">
 Owner
</b>
</div>
<br />
<asp:Label ID="lblcomments1" class="w3-text-red" runat="server"></asp:Label>   
<br />

<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif;">

<asp:Panel ID="Page1" runat=server>
<div class="fields" >

 <asp:UpdatePanel ID="UpdatePanel20" runat="server" class="two wide field " style="font-family: 'Kanit', sans-serif;font-size: small;">
    <ContentTemplate>
  
  <label for="Prename" class="w3-left">Title : </label>
  
             <asp:DropDownList ID="ddlOwnerPrename" runat="server" class="w3-input w3-border w3-round-large" AutoPostBack=true > 
            <asp:ListItem Value="Mr." Text="Mr."></asp:ListItem>
            <asp:ListItem Value="Ms." Text="Ms."></asp:ListItem>
            <asp:ListItem Value="Miss." Text="Miss."></asp:ListItem>
            <asp:ListItem Value="Mrs." Text="Mrs."></asp:ListItem>
            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
            </asp:DropDownList>  
        
       <asp:TextBox ID="txtOwnerPrename" type="prename" Visible=false class="w3-input w3-border w3-round-large" runat="server" placeholder="Etc." ></asp:TextBox>
 
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="ddlOwnerprename" EventName="SelectedIndexChanged"/>
    </Triggers>
    </asp:UpdatePanel>
      <div  class="six wide field " style="font-family: 'Kanit', sans-serif;font-size: small;" >
          <label for="name" class="w3-left">First name :</label>

               <asp:TextBox ID="txtOwnerName" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="First name" ></asp:TextBox>
      
   </div>   

     <div  class=" six wide field " style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left"> Last name :</label>

               <asp:TextBox ID="txtOwnerLastName" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder=" Last name" ></asp:TextBox>
      
   </div>    
        <div class=" six wide field " style="font-family: 'Kanit', sans-serif;font-size: small;" >
          <label for="name" class="w3-left"> ID Card No. :</label>
              <asp:TextBox ID="txtOwnerIdcard" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Owner ID Card No." ></asp:TextBox>
        </div>

<div class="four wide field " style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Telephone :</label>
         
              <asp:TextBox ID="txtOwnertel" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Owner Telephone" ></asp:TextBox>
        </div>

</div>

        <div class=" sixteen wide field" style="margin-top:2rem;font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Address :</label>
        
               <asp:TextBox ID="txtOwnerAddress" type="text" class="textarea w3-input w3-border w3-round-large" TextMode="MultiLine" runat="server" placeholder="Owner Address" ></asp:TextBox>
      </div>
      
      <div class="fields" style="margin-top:2rem;">
         <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Province : </label>
                 <asp:TextBox ID="txtOwnerProvince" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Province" ></asp:TextBox>
        </div>

        
           <div class="three wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Zipcode: </label>
                 <asp:TextBox ID="txtOwnerZipcode" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Zipcode" ></asp:TextBox>
        </div>

        <div class="six wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Country : </label>
            <asp:DropDownList ID="ddlOwnerCountry" runat="server" class="w3-input w3-border w3-round-large"> 
         <%--   <asp:ListItem Value="Myanmar" Text="Myanmar"></asp:ListItem>
             <asp:ListItem Value="Cambodia" Text="Cambodia"></asp:ListItem>--%>
            </asp:DropDownList>
            </div>

        <div class="six wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Email : </label>
                  <asp:TextBox ID="txtLicenseEmail" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
            </div>
   
 </div>  
</asp:Panel>


      </br>
       <asp:Button ID="btnNext2"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Next" />
</div>

</div>


<div id="form2" class="w3-animate-right fill w3-hide text-dark ui-form w3-margin" style="font-family: 'Kanit', sans-serif;"><%--margin-left:10%--%>
<div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom: .21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 9%;font-size: x-large;">
  Main Driver
</b>
</div>
<br />
<asp:Label ID="lblcomments2" class="w3-text-red" runat="server"></asp:Label>   
<br />

<asp:Panel ID="Page2" runat=server>

<div class="ui stackable four column grid " style="font-family: 'Kanit', sans-serif;">
 <div class="w3-left fields col-md-1 pb-3"></div>
  <div class="w3-left fields col-md-2 pb-3">
  <asp:UpdatePanel ID="UpdatePanel3" runat="server" style="font-family: 'Kanit', sans-serif;font-size: small;">
    <ContentTemplate>


          <label for="Prename" class="w3-left">Title : </label>
             <asp:DropDownList ID="ddlPrename" runat="server" class="w3-input w3-border w3-round-large" AutoPostBack="true" > 
            <asp:ListItem Value="Mr." Text="Mr."></asp:ListItem>
            <asp:ListItem Value="Ms." Text="Ms."></asp:ListItem>
            <asp:ListItem Value="Miss." Text="Miss."></asp:ListItem>
            <asp:ListItem Value="Mrs." Text="Mrs."></asp:ListItem>
            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
            </asp:DropDownList>  
       <asp:TextBox ID="txtPrename" type="prename" Visible="false" class="w3-input w3-border w3-round-large" runat="server" placeholder="Etc." ></asp:TextBox>

  
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="ddlprename" EventName="SelectedIndexChanged"/>
    </Triggers>
    </asp:UpdatePanel>
 </div>

    <div class="w3-left fields col-md-4 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label class="w3-left">Name : </label>
            <asp:TextBox ID="txtName" type="Name" class="w3-input w3-border w3-round-large" runat="server" placeholder="Name" ></asp:TextBox>
               
         </div>  

        <div class="w3-left fields col-md-4 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label class="w3-left fields">Last Name : </label>
                 <asp:TextBox ID="txtSurname" type="Surname" class="w3-input w3-border w3-round-large" runat="server" placeholder="Last Name" ></asp:TextBox>
        </div>

   
 </div>        

 <div class="ui stackable three column grid" >

        <div class="w3-left fields col-md-1 pb-3"></div>
       <!--div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Gender : </label>
            <asp:DropDownList ID="ddlGender" runat="server" class="w3-input w3-border w3-round-large"> 
            <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
             <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
            </asp:DropDownList>
            </div-->

            <div class="w3-left fields col-md-5 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields">Birth Date : </label>
                 <asp:TextBox ID="txtDate" type="BirthDate" class="w3-input w3-border w3-round-large w3-left " runat="server" placeholder="Birth Date"></asp:TextBox>
        </div>


         <div class="w3-left fields col-md-5 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left fields">Nationality : </label> 
            <asp:DropDownList ID="ddlNational" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
            </div>


             
 
 </div>

 <div class="ui stackable three column grid" >
 <div class="w3-left fields col-md-1 pb-3"></div>
 <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Passport No. : </label>
                 <asp:TextBox ID="txtPassportNo" type="passport" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport No" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields">Passport Expiry Date : </label>
                 <asp:TextBox ID="txtPassportExpire" type="PassportExpire" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport Expiry Date" ></asp:TextBox>
        </div>

 <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Driver License No. : </label>
                 <asp:TextBox ID="txtLicenseDriver" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License No." ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields">Driver License Expiry Date : </label>
                 <asp:TextBox ID="txtLicenseExpire" type="LicenseExpire" class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License Expiry Date" ></asp:TextBox>
        </div>
 
 </div>
  
        <div class="ui stackable four column grid">
        <div class="w3-left fields col-md-1 pb-3"></div>
        <div class="w3-left fields col-md-4 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Address : </label>
                 <asp:TextBox ID="txtAddress" type="Address" class="w3-input w3-border w3-round-large"  runat="server" placeholder="Address" ></asp:TextBox>
        </div>

        <%--
         <div class="w3-left fields">
            <label for="Surname" class="w3-left fields">State : </label>
                 <asp:TextBox ID="txtState" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="State" ></asp:TextBox>
        </div>
--%>
         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Province : </label>
                 <asp:TextBox ID="txtCounty" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Province" ></asp:TextBox>
        </div>

        
           <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Zipcode: </label>
                 <asp:TextBox ID="txtZipcode" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Zipcode" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left fields">Country : </label>
            <asp:DropDownList ID="ddlCountry" runat="server" class="w3-input w3-border w3-round-large"> 
         <%--   <asp:ListItem Value="Myanmar" Text="Myanmar"></asp:ListItem>
             <asp:ListItem Value="Cambodia" Text="Cambodia"></asp:ListItem>--%>
            </asp:DropDownList>
            </div>

               </div>
 
         <div class="ui stackable four column grid" >
          <div class="w3-left fields col-md-1 pb-3"></div>
         
              <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname"  class="w3-left">Telephone : </label>
                 <asp:TextBox ID="txtTel" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Telephone" ></asp:TextBox>
        </div>

            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Email : </label>
            <asp:TextBox ID="txtEmail" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
        </div>

         </div>

          
      
   
   <div class="ui stackable four column grid">
     <div class="w3-left fields col-md-1 pb-3"></div>
    <div class="w3-left fields" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Passport : </label>
       
           <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload1" runat="server" onchange="document.getElementById('MainContent_btnUploadPassport').click();" />
            <asp:ImageButton ID="btnUploadPassport" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNamePassport" runat="server" />
            <asp:Image ID="PhotoPassport" runat="server" Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeletePassport"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadPassport"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>


   

       <div class="w3-left fields" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Driver License No. : </label>
           <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload3" runat="server" onchange="document.getElementById('MainContent_btnUploadLicense').click();" />
            <asp:ImageButton ID="btnUploadLicense" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNameLicense" runat="server" />
            <asp:Image ID="PhotoLicense" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteLicense"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
      </div>
      <br />
<br />
 <div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom: .21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 9%;font-size: x-large;">
  Reserve Driver 1
</b>

</div>
<br />
<br />

<div class="ui stackable four column grid" >
 <div class="w3-left fields col-md-1 pb-3"></div>
  <div class="w3-left fields col-md-2 pb-3">
  <asp:UpdatePanel ID="Updateprename2" runat="server" style="font-family: 'Kanit', sans-serif;font-size: small;">
    <ContentTemplate>
   
          <label for="Prename" class="w3-left">Title : </label>
             <asp:DropDownList ID="ddlPrename2" runat="server" class="w3-input w3-border w3-round-large" AutoPostBack="true" > 
            <asp:ListItem Value="Mr." Text="Mr."></asp:ListItem>
            <asp:ListItem Value="Ms." Text="Ms."></asp:ListItem>
            <asp:ListItem Value="Miss." Text="Miss."></asp:ListItem>
            <asp:ListItem Value="Mrs." Text="Mrs."></asp:ListItem>
            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
            </asp:DropDownList>  
       <asp:TextBox ID="txtPrename2" type="prename" Visible="false" class="w3-input w3-border w3-round-large" runat="server" placeholder="Etc." ></asp:TextBox>
       
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="ddlprename" EventName="SelectedIndexChanged"/>
    </Triggers>
    </asp:UpdatePanel>
    </div>

    <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label class="w3-left">Name : </label>
            <asp:TextBox ID="txtName2" type="Name" class="w3-input w3-border w3-round-large" runat="server" placeholder="Name" ></asp:TextBox>
               
         </div>  

        <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label class="w3-left fields">Last Name : </label>
                 <asp:TextBox ID="txtSurname2" type="Surname" class="w3-input w3-border w3-round-large" runat="server" placeholder="Last Name" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Gender : </label>
            <asp:DropDownList ID="ddlGender2" runat="server" class="w3-input w3-border w3-round-large"> 
            <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
             <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
            </asp:DropDownList>
            </div>

                <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left fields">Nationality : </label> 
            <asp:DropDownList ID="ddlNational2" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
            </div>


 </div>        

 <div class="ui stackable three column grid">
  <div class="w3-left fields col-md-1 pb-3"></div>

 <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Driver License No. : </label>
                 <asp:TextBox ID="txtLicense2" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License No." ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields">Driver License Expiry Date : </label>
                 <asp:TextBox ID="txtLicenseExpire2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License Expiry Date" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Passport No : </label>
                 <asp:TextBox ID="txtPassportNo2" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport No" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields">Passport Expire : </label>
                 <asp:TextBox ID="txtPassport_exp2" type="LicenseExpire" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport Expire" ></asp:TextBox>
        </div>
 
 </div>
  
        <div class="ui stackable four column grid" >
        <div class="w3-left fields col-md-1 pb-3"></div>
        <div class="w3-left fields col-md-4 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Address : </label>
                 <asp:TextBox ID="txtAddress2" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Address" ></asp:TextBox>
        </div>

        

         <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left fields">Country : </label>
            <asp:DropDownList ID="ddlCountry2" runat="server" class="w3-input w3-border w3-round-large"> 

            </asp:DropDownList>
            </div>

              <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Zipcode: </label>
                 <asp:TextBox ID="txtZipcode2" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Zipcode" ></asp:TextBox>
        </div>


         </div>
 
         <div class="ui stackable three column grid">
         <div class="w3-left fields col-md-1 pb-3"></div>
            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname"  class="w3-left">Telephone : </label>
                 <asp:TextBox ID="txtTel2" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Telephone" ></asp:TextBox>
        </div>

            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Email : </label>
            <asp:TextBox ID="txtEmail2" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
        </div>

         </div>
   
   <div class="ui stackable two column grid">
   <div class="w3-left fields col-md-1 pb-3"></div>
    <div class="w3-left fields" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Passport : </label>
       
           <asp:UpdatePanel ID="UpdatePassport2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadPassport2" runat="server" onchange="document.getElementById('MainContent_btnUploadPassport2').click();" />
            <asp:ImageButton ID="btnUploadPassport2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNamePassport2" runat="server" />
            <asp:Image ID="PhotoPassport2" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeletePassport2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadPassport2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>

       <div class="w3-left fields" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Driver License : </label>
           <asp:UpdatePanel ID="UpdateLicense2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadLicense2" runat="server" onchange="document.getElementById('MainContent_btnUploadLicense2').click();" />
            <asp:ImageButton ID="btnUploadLicense2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNameLicense2" runat="server" />
            <asp:Image ID="PhotoLicense2" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteLicense2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
      </div>

<br />
<br />
 <div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom:.21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 9%;font-size: x-large;">
  Reserve Driver 2
</b>
</div>
<br />
<br />
<br />

<div class="ui stackable four column grid">
<div class="w3-left fields col-md-1 pb-3"></div>
<div class="w3-left fields col-md-2 pb-3" >
  <asp:UpdatePanel ID="Updateprename3" runat="server" style="font-family: 'Kanit', sans-serif;font-size: small;">
    <ContentTemplate>
    
          <label for="Prename" class="w3-left">Title : </label>
             <asp:DropDownList ID="ddlPrename3" runat="server" class="w3-input w3-border w3-round-large" AutoPostBack="true" > 
            <asp:ListItem Value="Mr." Text="Mr."></asp:ListItem>
            <asp:ListItem Value="Ms." Text="Ms."></asp:ListItem>
            <asp:ListItem Value="Miss." Text="Miss."></asp:ListItem>
            <asp:ListItem Value="Mrs." Text="Mrs."></asp:ListItem>
            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
            </asp:DropDownList>  
       <asp:TextBox ID="txtPrename3" type="prename" Visible="false" class="w3-input w3-border w3-round-large" runat="server" placeholder="Etc." ></asp:TextBox>
       
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="ddlprename" EventName="SelectedIndexChanged"/>
    </Triggers>
    </asp:UpdatePanel>
    </div>

    <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;" >
          <label class="w3-left">Name : </label>
            <asp:TextBox ID="txtName3" type="Name" class="w3-input w3-border w3-round-large" runat="server" placeholder="Name" ></asp:TextBox>
               
         </div>  

        <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label class="w3-left fields">Last Name : </label>
                 <asp:TextBox ID="txtSurname3" type="Surname" class="w3-input w3-border w3-round-large" runat="server" placeholder="Last Name" ></asp:TextBox>
        </div>

        <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Gender : </label>
            <asp:DropDownList ID="ddlGender3" runat="server" class="w3-input w3-border w3-round-large"> 
            <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
             <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
            </asp:DropDownList>
            </div>

    <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left fields">Nationality : </label> 
            <asp:DropDownList ID="ddlNational3" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
            </div>
 </div>        

 <div class="ui stackable three column grid">

        <div class="w3-left fields col-md-1 pb-3"></div>
       

 <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Driver License No. : </label>
                 <asp:TextBox ID="txtLicense3" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License No." ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields">Driver License Expiry Date : </label>
                 <asp:TextBox ID="txtLicenseExpire3" type="LicenseExpire" class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License Expiry Date" ></asp:TextBox>
        </div>


         <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Passport No. : </label>
                 <asp:TextBox ID="txtPassportNo3" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport No. " ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields">Passport Expire : </label>
                 <asp:TextBox ID="txtPassport_exp3" type="LicenseExpire" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport Expire" ></asp:TextBox>
        </div>
 
 </div>
  
        <div class="ui stackable four column grid" >
         <div class="w3-left fields col-md-1 pb-3"></div>
        <div class="w3-left fields col-md-4 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;" >
            <label for="Surname" class="w3-left fields">Address : </label>
                 <asp:TextBox ID="txtAddress3" type="Address" TextMode="MultiLine" class="w3-input w3-border w3-round-large" runat="server" placeholder="Address" ></asp:TextBox>
        </div>

       
         <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left fields">Country : </label>
            <asp:DropDownList ID="ddlCountry3" runat="server" class="w3-input w3-border w3-round-large"> 

            </asp:DropDownList>
            </div>


            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Zipcode: </label>
                 <asp:TextBox ID="txtZipcode3" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Zipcode" ></asp:TextBox>
        </div>

         </div>
 
         <div class="ui stackable three column grid">
          <div class="w3-left fields col-md-1 pb-3"></div>
            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname"  class="w3-left">Telephone : </label>
                 <asp:TextBox ID="txtTel3" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Telephone" ></asp:TextBox>
        </div>

            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Email : </label>
            <asp:TextBox ID="txtEmail3" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
        </div>

         </div>
   <div class="ui stackable two column grid">
    <div class="w3-left fields col-md-1 pb-3"></div>
    <div class="w3-left fields" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Passport : </label>
       
           <asp:UpdatePanel ID="UpdatePassport3" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadPassport3" runat="server" onchange="document.getElementById('MainContent_btnUploadPassport3').click();" />
            <asp:ImageButton ID="btnUploadPassport3" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNamePassport3" runat="server" />
            <asp:Image ID="PhotoPassport3" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeletePassport3"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadPassport3"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>


   

       <div class="w3-left fields" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Driver License  : </label>
           <asp:UpdatePanel ID="UpdateLicense3" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadLicense3" runat="server" onchange="document.getElementById('MainContent_btnUploadLicense3').click();" />
            <asp:ImageButton ID="btnUploadLicense3" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNameLicense3" runat="server" />
            <asp:Image ID="PhotoLicense3" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteLicense3"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense3"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
      </div>
 
 </asp:Panel>
 
          
 
         <div class="pb-0">	
    <div class="ml-5 pt-5 pb-5 mb-5 pr-5">
        <asp:Button ID="btnNext3"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Next" />
          <asp:Button ID="btnPrev2" class="w3-purple w3-btn w3-round-large w3-left w3-large"  runat="server" UseSubmitBehavior="false" Text="Prev" />
      </div>
                
             </div>
          
     </div>

<div id="form3" class=" w3-animate-right fill w3-hide text-dark ui-form ">

 <div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom:.21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 9%;font-size: x-large;">
  Vehicle
</b>
</div>
<br />
<asp:Label ID="lblcomments3" class="w3-text-red" runat="server"></asp:Label>   
<br />
<br />
<br />
<asp:Panel ID="Page3" runat=server>
<div class="ui stackable four column grid ">

<div class="w3-left fields col-md-1 pb-3 "></div>
 <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
        <label for="Surname">Make : </label>
                 
        </div>

        <div class="w3-left fields col-md-3 pb-3 " style="font-family: 'Kanit', sans-serif;font-size: small;">

         <asp:TextBox ID="txtBrands" type="brands" class="w3-input w3-border w3-round-large" runat="server" placeholder="Make" ></asp:TextBox>
        </div>

      
        <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <label for="name">Model : </label>
              
        </div>

        <div class="w3-left fields col-md-3 pb-3 " style="font-family: 'Kanit', sans-serif;font-size: small;">
         <asp:TextBox ID="txtModel" type="Model" class="w3-input w3-border w3-round-large" runat="server" placeholder="Model" ></asp:TextBox>
        </div>

       
 </div>

 <div class="ui stackable four column grid ">
 <div class="w3-left fields col-md-1 pb-3 "></div>

  <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
        <label for="name">Colors : </label>
            
        </div>

        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
        <asp:DropDownList ID="ddlColor" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
        
        </div>

        <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
        <label for="name">Seats : </label>
             
        </div>
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
           <%--<asp:DropDownList ID="ddlSeats" runat="server" class="w3-input w3-border w3-round-large"> 
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="6">6</asp:ListItem>
                <asp:ListItem Value="7">7</asp:ListItem>
            </asp:DropDownList>--%>
            <asp:TextBox ID="txtSeats"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Seats" ></asp:TextBox>
        </div>

 </div>

 <br />
   <asp:UpdatePanel ID="UpdatePanel5" runat="server">
     <ContentTemplate>
 <div class="ui stackable four column grid ">
  <div class="w3-left fields col-md-1 pb-3 "></div>
 


      <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Country of registration : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <asp:DropDownList ID="ddlCountryCar" runat="server" class="w3-input w3-border w3-round-large" AutoPostBack="true"> 
            </asp:DropDownList>
            </div>


      <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
      
          <label for="name">Province of registration : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
             <asp:TextBox ID="txtstate_car" type="Registration No." class="w3-input w3-border w3-round-large" runat="server" placeholder="Province of registration" ></asp:TextBox>
      </div>


 </div>
  
      </ContentTemplate>
      <Triggers>
      <asp:AsyncPostBackTrigger ControlID="ddlCountryCar" EventName="SelectedIndexChanged" />
      </Triggers>
    </asp:UpdatePanel>
     <br />

         <div class="ui stackable four column grid ">
          <div class="w3-left fields col-md-1 pb-3 "></div>
             <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Registration No. (ENG) : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <asp:TextBox ID="txtLicenseCar" type="Registration No." class="w3-input w3-border w3-round-large" runat="server" placeholder="Registration No. (ENG)" ></asp:TextBox>
            </div>

            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Registration No. (Local) : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <asp:TextBox ID="txtLicenseLocalCar" type="Registration No." class="w3-input w3-border w3-round-large" runat="server" placeholder="Registration No. (Local)" ></asp:TextBox>
            </div>


         </div>

         
<div class="ui stackable four column grid ">

 <div class="w3-left fields col-md-1 pb-3 "></div>
   <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Engine Number : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
               <asp:TextBox ID="txtNumEngine" type="Serial Engine" class="w3-input w3-border w3-round-large" runat="server" placeholder="Engine Number" ></asp:TextBox>
        </div>

        
            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Engine Capacity : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
               <asp:TextBox ID="txtEnginCap" type="number" class="w3-input w3-border w3-round-large" runat="server" placeholder="Engine Capacity" ></asp:TextBox>
        </div>


</div>


<div class="ui stackable four column grid ">
<div class="w3-left fields col-md-1 pb-3 "></div>

  <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Vehicle Identification Number (VIN) : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <asp:TextBox ID="txtNumcar" type="Serial Car" class=" w3-input  w3-border w3-round-large" runat="server" placeholder="VIN Number" ></asp:TextBox>
            </div>

          <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Gross Weight (kg.) : </label>
           </div> 
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
        
               <asp:TextBox ID="txtWeight" type="text" class="w3-input w3-border w3-round-large " runat="server" placeholder="weight" ></asp:TextBox>
        </div>

</div>

<div class="ui stackable four column grid ">
<div class="w3-left fields col-md-1 pb-3 "></div>


 <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Type : </label>
           </div> 
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
        
               <asp:DropDownList ID="ddltypecar" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
        </div>
            <asp:Panel ID="pnLaos" runat="server" Visible=false>
            <div class="w3-left fields col-md-1 pb-3 "></div>
          
           <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Vehicle Registration Certificate : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3">
         

         
           <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload4" runat="server" onchange="document.getElementById('MainContent_btnUploadRegisCar').click();" />
            <asp:ImageButton ID="btnUploadRegisCar" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoRegisCar" runat="server" />
            <asp:Image ID="PhotoRegisCar" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteRegisCar"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadRegisCar"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
        <div class="w3-left fields col-md-1 pb-3 "></div>

        <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Letter of Consent from Vehicle Owner / Authorization from Vehicle Owner : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" >
         

         
           <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload6" runat="server" onchange="document.getElementById('MainContent_btnUploadAuthorize').click();" />
            <asp:ImageButton ID="btnUploadAuthorize" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidAuthorize" runat="server" />
            <asp:Image ID="PhotoAuthorize" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteAuthorize"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadAuthorize"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div><br />
    </asp:Panel>  
</div>




    <div class="ui stackable four column grid ">
<div class="w3-left fields col-md-1 pb-3 "></div>


 <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
           <label for="name">Vehicle Photos : </label>
           </div> 
        <div class="w3-left fields col-md-3 pb-3">
        
            <asp:DropDownList ID="ddlImgtype" class="w3-input w3-border w3-round-large mb-4" runat="server">
                <asp:ListItem Text="Front" Value="1"></asp:ListItem>
                <asp:ListItem Text="Rear" Value="2"></asp:ListItem>
                <asp:ListItem Text="Side view" Value="3"></asp:ListItem>
          <%--      <asp:ListItem Text="Right Side" Value="4"></asp:ListItem>--%>
            </asp:DropDownList>

           <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true" style="font-family: 'Kanit', sans-serif;font-size: small;">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload2" runat="server" onchange="document.getElementById('MainContent_btnUploadCar').click();" />
            <asp:ImageButton ID="btnUploadCar" style="DISPLAY: none" runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress(); " formnovalidate="formnovalidate" CausesValidation=false  UseSubmitBehavior="false"/>
               <asp:HiddenField ID="hidPhotonamecar" runat="server" />
            <asp:Image ID="PhotoCar" runat="server" Width="250px" Hight="200"  />
          <%--  <asp:ImageButton ID="PhotoCarDelete"  OnClientClick="javascript:return confirm('Do you want delete photo?');"  ImageUrl="image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" formnovalidate="formnovalidate" CausesValidation="false" UseSubmitBehavior="false" Visible="false" oncommand="PhotoCarDelete_Command" />
--%>
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadCar"/>
	          </Triggers>
           </asp:UpdatePanel>
<%--           <script type='text/javascript'>

               function addpic(fname){
                   var txtfname = document.getElementById('MainContent_hidFName');
                   txtfname.value = fname;
                   alert(txtfname.value);
                   document.getElementById('MainContent_btnAddImage').click();
               };


               </script>--%>
        </div>
</div>
          
<!--div class="ui stackable column  grid"></div>
<div class="w3-left fields col-md-1 pb-3 "></div-->

    <asp:UpdatePanel ID="UpdgvFile" runat="server" class="w3-row-padding w3-center" UpdateMode="Conditional" style="font-family: 'Kanit', sans-serif;font-size: small;">
                    <contenttemplate>
                       <asp:DataList ID="DtlImg" runat="server" CellPadding="0" RepeatLayout="Flow" 
                    DataKeyField="gid" ForeColor="#333333" RepeatColumns="4" 
                            RepeatDirection="Horizontal" >
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemStyle  VerticalAlign="Middle"  HorizontalAlign="Center"/>
                   
                           <ItemTemplate> 
                            <div class="w3-col l3 m6 w3-margin-bottom">
                              <br /><br />
                                <div class="w3-display-container">

                                    <%--<img src="/w3images/sandwich.jpg" alt="Sandwich" style="width:100%">--%>
                                    <asp:Image ID="imageFile" runat="server" ImageUrl='<%# Bind("PathImg") %>' style="width: 250px;height: 250px;" />
                                    <%--<h3>The Perfect Sandwich, A Real NYC Classic</h3>--%>
                                 
                                    
                                      
                                <div class=" w3-margin">
                                    <a style="font-family: 'Kanit', sans-serif;font-size: small;height: 250px;"><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("PathImg") %>' Target="_blank"  runat="server">  <asp:Label ID="lblShow" runat="server" Text='<%# Bind("ImgType") %>'></asp:Label></asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="PhotoCarDelete" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                CommandArgument='<%# Eval("gid") %>' CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="PhotoCarDelete_Command" formnovalidate="formnovalidate" CausesValidation="false"  UseSubmitBehavior="false"/></a>
                                </div>

                                
                            </div>

                             </div>
                           </ItemTemplate> 
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:DataList>

                <asp:Panel style="DISPLAY: none" id="Pngrid" runat="server" Height="0px">
                        <asp:GridView ID="gvFile" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" CssClass="Grid" GridLines="None" PageSize="2"  
                            Width="500px">
                            <Columns>
                                <asp:TemplateField SortExpression="saved_name" Visible="False">
                                     <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("gid") %>'></asp:Label>
                                        <asp:Label ID="lblCarid" runat="server" Text='<%# Bind("car_id") %>'></asp:Label>
                                        <asp:Label ID="lblfile_name" runat="server" Text='<%# Bind("file_name") %>'></asp:Label>
                                         <asp:Label ID="lblPathImg" runat="server" Text='<%# Bind("PathImg") %>'></asp:Label>
                                         <asp:Label ID="lblImgType" runat="server" Text='<%# Bind("ImgType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pgr" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
                </asp:Panel>

                    </contenttemplate>
                     <%--<Triggers>
    <asp:AsyncPostBackTrigger ControlID="ImgDelete" EventName="Click" />
        
    </Triggers>--%>
                </asp:UpdatePanel>

</asp:Panel>

    


 <div class="pb-0">	
    <div class="ml-5 pt-5 pb-5 mb-5 pr-5">
        <asp:Button ID="btnNext4"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large" runat="server" UseSubmitBehavior="false" Text="Next" />
         <asp:Button ID="btnPrev3"  class=" w3-left  w3-purple w3-btn w3-round-large w3-large" runat="server" UseSubmitBehavior="false" Text="Prev" />
      </div>
    </div>

</div>

<div id="form4" class="w3-animate-right fill w3-hide text-dark">


 <div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom:.21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 9%;font-size: x-large;">
 Compulsory Motor Insurance
</b>
</div>
<br />
<asp:Label ID="lblcomments4" class="w3-text-red" runat="server"></asp:Label>   
<br />
<br />
<br />
<br />


<asp:Panel ID="Page4" runat=server>
<div class="ui stackable four column grid ">

<div class="w3-left fields col-md-1 pb-3 "></div>

  <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
    
        <label for="name">Insurance Company :</label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
               <asp:TextBox ID="txtActCompany" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Insurance Company" ></asp:TextBox>
        </div>


        <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Policy Number : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
               <asp:TextBox ID="txtActNo" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Policy Number" ></asp:TextBox>
        </div>
</div>

      
<%--
        <div class="col-ml-2 pl-5 w3-left">
          <label for="name">ชื่อผู้เอากรมธรรม์ : </label>
         </div>    
        <div class="col-md-7 pb-3">
               <asp:TextBox ID="txtActName" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="name" ></asp:TextBox>
        </div>

         <div class="col-ml-2 pl-5 w3-left">
          <label for="name">เลขถังรถ : </label>
         </div>    
        <div class="col-md-7 pb-3">
               <asp:TextBox ID="txtActTankNo" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="no." ></asp:TextBox>
        </div>--%>

<div class="ui stackable four column grid ">

<div class="w3-left fields col-md-1 pb-3 "></div>
        
          <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Start date : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
               <asp:TextBox ID="txtActStart" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Start date" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">End date : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;"> 
               <asp:TextBox ID="txtActExpire" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="End date" ></asp:TextBox>
        </div>

</div>
<div class="ui stackable four column grid ">

<div class="w3-left fields col-md-1 pb-3 "></div>
        
        
           <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Policy Schedule : </label>
         </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;" >
         
           <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload5" runat="server" onchange="document.getElementById('MainContent_btnUploadAct').click();" />
            <asp:ImageButton ID="btnUploadAct" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoAct" runat="server" />
            <asp:Image ID="PhotoAct" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteAct"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadAct"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
  </div>
</asp:Panel>

 <div class="pb-0">	
    <div class="ml-5 pt-5 pb-5 mb-5 pr-5">
        <asp:Button ID="btnNext5"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"  runat="server" UseSubmitBehavior="false" Text="Next" />
         <asp:Button ID="btnPrev4"  class=" w3-left w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Prev" />
      </div>
    </div>

</div>

<div id="form5" class=" w3-animate-right fill w3-hide text-dark">
<br />
<asp:Label ID="lblcomments8" class="w3-text-red" runat="server"></asp:Label>   
<br />
<br />
<div class="ui form grid">
<div class="row">
<div class=" seven wide column"  id="divMap" >

            <iframe runat="server" id="iframeMap" enableviewstate="true" frameborder="0" style="width:400px; height:600px;" name="IframeLocation" scrolling="yes" 
          src="../Map/MapArea.aspx?pro=-1" >Your browser does not support iframes 
    </iframe>

     
</div>  


  <script  type='text/javascript'>
      $(document).ready(function () {
          var dv = document.getElementById("divMap").offsetWidth;
          //alert(dv)
          if (navigator.userAgent.match(/Android/i)
 || navigator.userAgent.match(/webOS/i)
 || navigator.userAgent.match(/iPhone/i)
 || navigator.userAgent.match(/iPad/i)
 || navigator.userAgent.match(/iPod/i)
 || navigator.userAgent.match(/BlackBerry/i)
 || navigator.userAgent.match(/Windows Phone/i)
 ) {
              var iFrame = document.getElementById("MainContent_iframeMap");
              iFrame.style.width = (dv * 0.9) + 'px';
              iFrame.style.height = (dv * 1.1) + 'px';
          }
          else {
              var iFrame = document.getElementById("MainContent_iframeMap");
              iFrame.style.width = (dv * 1.2) + 'px';
              iFrame.style.height = (dv * 1.6) + 'px';
          }




      });

      function get_IframeMaps(pro) {
          document.getElementById('MainContent_iframeMap').src = '../Map/MapArea.aspx?pro=' + pro;
      }

      function get_IframeMap(pro) {
          document.getElementById('MainContent_iframeMap').src = document.getElementById('MainContent_iframeMap').src + ',' + pro;
          console.log(document.getElementById('MainContent_iframeMap').src);
      }

      function get_IframeMapDel(pro) {
          document.getElementById('MainContent_iframeMap').src = document.getElementById('MainContent_iframeMap').src.replace("," + pro, "");
          console.log(document.getElementById('MainContent_iframeMap').src);
      }
    </script>

<%--<div class="col-ml-2 pl-4 w3-left">
       
        </div>  --%>  
<div class=" nine wide column">
    <asp:Panel ID="Page8" runat=server>
       <div class=" ten wide field"  style="font-family: 'Kanit', sans-serif;font-size: large;" >
         
         <label for="Border" class="w3-left">Border Crossing Checkin : </label>
       
                <asp:DropDownList ID="ddlBorderCheckin" runat="server" AutoPostBack="true" class="w3-input w3-border w3-round-large" > 
            </asp:DropDownList>
       
       </div>


           

<%-- <div class="col-ml-2 pl-5 w3-left">
       <label for="Border">Border Checkout : </label>
        </div>    
        <div class="col-md-7 pb-3 ">
                <asp:DropDownList ID="ddlBorderCheckout" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
        </div>
--%>
        
 <%--<div class="col-ml-2 pl-4 w3-left">
       
        </div>--%>    

<asp:Panel runat="server" ID="receive">
  <div class="ten wide field"  style="font-family: 'Kanit', sans-serif;font-size: large;" >
       
       <label for="Border" class="w3-left">Place to receive documents :  </label>
       
          
<asp:UpdatePanel id="updateddladmin" runat="server" UpdateMode="Conditional">
<ContentTemplate>
                <asp:DropDownList ID="ddladmin" runat="server" class="w3-input w3-border w3-round-large">  <%--Width="400px"--%>
            </asp:DropDownList>  


            <asp:Button style="DISPLAY: none" id="btnSetValueddladmin" UseSubmitBehavior="false" runat="server" Text="Button" />
        <asp:HiddenField ID="HidValueddladmin" runat="server" />

            </ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="btnAddImage" EventName="Click" />--%>
    </Triggers>
</asp:UpdatePanel>
</div>

      
         
           <div class="ten wide field" >
           <%--<asp:LinkButton ID="lnkSchMap"  class="w3-purple w3-btn w3-round-large w3-large" runat="server"><i class="fa fa-map-marker" aria-hidden="true" ></i> ค้นหา </asp:LinkButton>--%>
           <asp:HyperLink ID="lnkSchMap" runat="server" class="w3-purple w3-btn w3-round-large w3-large" ><i class="fa fa-map-marker" aria-hidden="true" ></i> ค้นหา </asp:HyperLink>
        </div>
   
</asp:Panel>
<br />

     <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
      
        <div class="ten wide field "  style="font-family: 'Kanit', sans-serif;font-size: large" > 
      
            <label for="area" class="w3-left">Province use vehicle : </label>
            <br />
 <asp:DropDownList ID="ddlProvarea" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>

            <asp:Panel ID="Paneladd" runat="server">
            <div class=" w3-text-purple mt-2 " onclick="document.getElementById('MainContent_btnProv').click();"> <i class="fa fa-2x fa-plus-circle" aria-hidden="true"></i></div>
            </asp:Panel> 
 </div>

  
  
          
    <div class="ten wide field" >
      <asp:Label ID="lblProv0" runat="server" Text="All Province"></asp:Label>
        <asp:GridView ID="gvProv" runat="server" GridLines="None" AutoGenerateColumns="false">
        <Columns>
          <asp:TemplateField>
          <ItemTemplate>
                <asp:Label ID="lblarea_id" runat="server" style="display:none" Text="<%# Bind('area_id') %>"></asp:Label>
                <asp:Label ID="lblprov_code" runat="server" style="display:none" Text="<%# Bind('prov_code') %>"></asp:Label>
              <asp:Label ID="lblprov_en" runat="server" Text="<%# Bind('prov_en') %>"></asp:Label>
                <asp:ImageButton ID="ProvareaDelete" OnClientClick="javascript:return confirm('Do you want delete Provice?'); return false;"  ImageUrl="~/image/g_delete.gif" 
                CommandArgument='<%# Bind("prov_code") %>' OnCommand="Provarea_Delete"  runat="server"  alt="Delete" title="Delete" UseSubmitBehavior="false"  />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
        </asp:GridView>
    </div>

       
         
        <asp:HiddenField ID="hidProvince" runat="server" />
        <asp:Button ID="btnProv" runat="server" Text="Button" style="DISPLAY:none" />
        <asp:Button ID="btnProvClear" runat="server" Text="Button" style="DISPLAY:none" />
     
     
     </ContentTemplate>
     <Triggers>
     <asp:AsyncPostBackTrigger ControlID="btnProv" EventName="Click" />
     </Triggers>
     </asp:UpdatePanel>

  <%--  <asp:UpdatePanel ID="ProvinceUpdate" runat="server" UpdateMode="Conditional">
    <ContentTemplate>--%>

<%--    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlBorderCheckin" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
--%>
 <%--<div class="col-ml-2 pl-5 w3-left">
       <label for="Border">Border Checkout : </label>
        </div>    
        <div class="col-md-7 pb-3 ">
                <asp:DropDownList ID="ddlBorderCheckout" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
        </div>--%>

        
 <%--<div class="col-ml-2 pl-5 w3-left">
       <label for="Border">สถานที่รับเอกสาร : </label>
        </div>    
        <div class="col-md-7 pb-3 ">
                <asp:DropDownList ID="ddlformarea" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
 </div>--%>
 <br /><br /><br /><br /> <br /><br /> <br />

 <div class= " fields w3-display-bottomright">
 <div class="row">
 <div class="five wide field ">
                <asp:Button ID="btnPrev5" class=" w3-center w3-purple w3-btn w3-round-large w3-large "  runat="server" UseSubmitBehavior=false Text="Prev" />
</div>
 <div class="five wide field ">
                <asp:Button ID="btnSave" class=" w3-center w3-purple w3-btn w3-round-large w3-large "   runat="server" UseSubmitBehavior=false Text="Save" />
</div>
 <div class="five wide field ">
                <button class=" w3-center w3-purple w3-btn w3-round-large w3-large"   onclick ="Submit();return false;" UseSubmitBehavior=false>Submit</Button> 
</div>

</div>
</div>
</asp:Panel>

 </div>

 </div>

 </div>    


</div>



<div id="form6"  class=" w3-animate-right fill w3-hide text-dark">

<div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom:.21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 9%;font-size: x-large;">
 TOUR GROUP
</b>
</div>

<br />
<asp:Label ID="Label1" class="w3-text-red" runat="server"></asp:Label>   
<br />
<br />

<asp:Panel ID="Page7" runat=server>
<div class="ui stackable four column grid ">

 <div class="row">
<div class="w3-left fields col-md-1 pb-3 "></div>

  <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
    
        <label for="name">TOUR GROUP :</label>
         </div>    
       
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
               <asp:DropDownList ID="ddlGroup" runat="server" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" AutoPostBack="true" > 
             </asp:DropDownList> 
        </div>
 
 </div>

  <div class="row">
<div class="w3-left fields col-md-1 pb-3 "></div>
      <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
    
        <label for="name">Guide :</label>
         </div>    

        <div class="w3-left fields col-md-3 pb-3" 
          style="font-family: 'Kanit', sans-serif;font-size: small; text-align: left;" 
          align="left">
            <asp:Label ID="lblGuidedata" runat="server" Text="-" class="w3-input  w3-round-large" ></asp:Label>
        </div>

</div>
         
</div>

</asp:Panel>


<div class="pb-0">	
    <div class="ml-5 pt-5 pb-5 mb-5 pr-5">
        <asp:Button ID="btnNext6"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"  runat="server" UseSubmitBehavior="false" Text="Next" />
         <asp:Button ID="btnPrev6"  class=" w3-left w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Prev" />
      </div>
    </div>


 </form>

</div>
</div>
  <script type="text/javascript">

      function Submit() {
          $.confirm({
              title: 'Notification',
              content: "Once you have submitted the document, it cannot be modified again. Do you want to send it? ",
              buttons: {
                  submit: function () {
                      document.getElementById('MainContent_btnSubmit').click();
                  },
                  cancel: function () {
                      //$.alert('Cancel');
                  }
              }
          });
      }
    </script>

<asp:UpdateProgress ID="UpdateProgress" runat="server" >
    <ProgressTemplate>
        <div align="center" class="overlays">
            <div class="loader" ></div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

  <script type="text/javascript">


      function showProgress() {
          var updateProgress = $get("<%= UpdateProgress.ClientID %>");
          updateProgress.style.display = "block";
      }
       
   </script>

</asp:Content>

