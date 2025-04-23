<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtEdit.aspx.vb" MasterPageFile="~/MasterPageC.master" Inherits="Travel_MgtEdit" %>

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
  <script language="javascript" type="text/javascript">
      $(window).load(function () {
          $('#loadings').hide();
      });
</script>

  <div id="loadings" align="center" class="overlays">
            <div class="loader" ></div>
        </div>
  <style>
  body {
      overflow-x: unset;
   
      }
  @font-face{
      font-family: 'Kanit', sans-serif;
        src : url('font/ThaiSansNeue-Regular/thaisansneue-bold-webfont.woff2');
    
    
    }
    .w3-col.l01{width:38px}
    .w3-col.l02{width:50px}
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
</ul>
<br />
           
<div align="center">
<form>
<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative w3-text-deep-purple w3-card-2 w3-round-large w3-theme-l5 w3-row-padding">          





<script type="text/javascript">

    function tab1() {

        document.getElementById("tab1").className = "active";
        document.getElementById("tab2").className = "";
        document.getElementById("tab3").className = "";
        document.getElementById("tab4").className = "";
        //document.getElementById("tab5").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill ";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
        //document.getElementById("form5").className = "text-dark w3-animate-right fill w3-hide";
    }


    function tab2() {

        document.getElementById("tab2").className = "active";
        document.getElementById("tab1").className = "completed";
        document.getElementById("tab3").className = "";
        document.getElementById("tab4").className = "";
       // document.getElementById("tab5").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill ";
        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
        //document.getElementById("form5").className = "text-dark w3-animate-right fill w3-hide";
    }

    function tab3() {

        document.getElementById("tab1").className = "completed";
        document.getElementById("tab2").className = "completed";
        document.getElementById("tab3").className = "active";
        document.getElementById("tab4").className = "";
        //document.getElementById("tab5").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form3").className = "text-dark w3-animate-right fill pl-5";
        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
        //document.getElementById("form5").className = "text-dark w3-animate-right fill w3-hide";

    }

    function tab4() {

        document.getElementById("tab1").className = "completed";
        document.getElementById("tab2").className = "completed";
        document.getElementById("tab3").className = "completed";
        document.getElementById("tab4").className = "active";
      //  document.getElementById("tab5").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form4").className = "text-dark w3-animate-right pl-5";
        //document.getElementById("form5").className = "text-dark w3-animate-right pl-5 w3-hide";

    }

    function tab5() {

        document.getElementById("tab1").className = "completed";
        document.getElementById("tab2").className = "completed";
        document.getElementById("tab3").className = "completed";
        document.getElementById("tab4").className = "completed";
       // document.getElementById("tab5").className = "active";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
        //document.getElementById("form5").className = "text-dark w3-animate-right pl-5";
    }

    $(function () {
        $("#<%=txtDate.ClientID %>").datepicker({
            changeMonth: true
            , changeYear: true
            , yearRange: "-100:-15"
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });

        $("#<%=txtDate.ClientID %>").keyup(function () {
            $("#<%=txtDate.ClientID %>").val('');
            $("#<%=txtDate.ClientID %>").datepicker("option", "defaultDate", new Date(1919, 9, 3));
        })
        $("#<%=txtDate.ClientID %>").datepicker("option", "defaultDate", new Date(1919, 9, 3));
    });

    $(function () {
        $("#<%=txtPassportExpire.ClientID %>").datepicker({
            changeMonth: true
            , changeYear: true
            , yearRange: "now :+20"
            , setDate: new Date()
            , minDate: '0'
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });

        $("#<%=txtPassportExpire.ClientID %>").keyup(function () {
            $("#<%=txtPassportExpire.ClientID %>").val('');
        })
    });

    $(function () {
        $("#<%=txtPassport_exp2.ClientID %>").datepicker({
            changeMonth: true
            , changeYear: true
            , yearRange: "now :+20"
            , setDate: new Date()
            , minDate: '0'
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtPassport_exp2.ClientID %>").keyup(function () {
            $("#<%=txtPassport_exp2.ClientID %>").val('');
        })
    });

    $(function () {
        $("#<%=txtPassport_exp3.ClientID %>").datepicker({
            changeMonth: true
            , changeYear: true
            , yearRange: "now :+20"
            , setDate: new Date()
            , minDate: '0'
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtPassport_exp3.ClientID %>").keyup(function () {
            $("#<%=txtPassport_exp3.ClientID %>").val('');
        })
    });

    $(function () {
        $("#<%=txtLicenseExpire.ClientID %>").datepicker({
            changeMonth: true
            , changeYear: true
            , yearRange: "now :+20"
            , setDate: new Date()
            , minDate: '0'
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtLicenseExpire.ClientID %>").keyup(function () {
            $("#<%=txtLicenseExpire.ClientID %>").val('');
        })
    });


    $(function () {
        $("#<%=txtLicenseExpire2.ClientID %>").datepicker({
            changeMonth: true
            , changeYear: true
            , yearRange: "now :+20"
            , setDate: new Date()
            , minDate: '0'
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtLicenseExpire2.ClientID %>").keyup(function () {
            $("#<%=txtLicenseExpire2.ClientID %>").val('');
        })
    });


    $(function () {
        $("#<%=txtLicenseExpire3.ClientID %>").datepicker({
            changeMonth: true
            , changeYear: true
            , yearRange: "now :+20"
            , setDate: new Date()
            , minDate: '0'
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtLicenseExpire3.ClientID %>").keyup(function () {
            $("#<%=txtLicenseExpire3.ClientID %>").val('');
        })
    });




    $(function () {
        $("#<%=txtActStart.ClientID %>").datepicker({
            changeMonth: true
            , changeYear: true
            , yearRange: "-5 :+20"
            , setDate: new Date()
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtActStart.ClientID %>").keyup(function () {
            $("#<%=txtActStart.ClientID %>").val('');
        })
    });

    $(function () {
        $("#<%=txtActExpire.ClientID %>").datepicker({
            changeMonth: true
            , changeYear: true
            , yearRange: "now :+20"
            , setDate: new Date()
            , minDate: '0'
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtActExpire.ClientID %>").keyup(function () {
            $("#<%=txtActExpire.ClientID %>").val('');
        })
    });


    $(function () {
        $("#<%=txtActStart2.ClientID %>").datepicker({
            changeMonth: true
            , changeYear: true
            , yearRange: "-5 :+20"
            , setDate: new Date()
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtActStart2.ClientID %>").keyup(function () {
            $("#<%=txtActStart2.ClientID %>").val('');
        })
    });

    $(function () {
        $("#<%=txtActExpire2.ClientID %>").datepicker({
            changeMonth: true
            , changeYear: true
            , yearRange: "now :+20"
            , setDate: new Date()
            , minDate: '0'
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtActExpire2.ClientID %>").keyup(function () {
            $("#<%=txtActExpire2.ClientID %>").val('');
        })
    });




    
</script>


<script type="text/javascript">
   

        function alertDataDriver() {
            $.confirm({
                title: 'Notification ',
                content: 'Is driver the same as owner?     YES or NO ',
                buttons: {
                    confirm: function () {
                        document.getElementById('MainContent_btnLoadDriver').click();
                    },
                    cancel: function () {
                        
                    }
                }
            });
        }

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

    function isJuristic(_chk) {
        var chk = document.getElementById(_chk);
       
        if (chk.checked == true) {
            document.getElementById("MainContent_Juristic0").style.visibility = "hidden";
            document.getElementById("MainContent_Juristic0").style.height = "0px";
            document.getElementById("MainContent_Juristic1").style.visibility = "visible";
            document.getElementById("MainContent_Juristic1").style.height = "auto";
        }
        else {
            document.getElementById("MainContent_Juristic0").style.visibility = "visible";
            document.getElementById("MainContent_Juristic0").style.height = "auto";
            document.getElementById("MainContent_Juristic1").style.visibility = "hidden";
            document.getElementById("MainContent_Juristic1").style.height = "0px";
        }



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
<%--<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom: .21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 30px;font-size: x-large;margin-top: -35px;">
 Owner
</b>--%>
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom: .21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 70px;font-size: x-large;">
  Owner
</b>
</div>
<%--<br />--%>
<asp:Label ID="lblcomments1" class="w3-text-red" runat="server"></asp:Label>   
<br />

<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif;">

<asp:Panel ID="Page1_2" runat="server" >
<div class="fields" >
<div class="one wide field"></div>

 <div class=" sixteen wide field " style="font-family: 'Kanit', sans-serif;font-size: small; " >
 <asp:CheckBox runat="server" ID="chkisJuristic" class="w3-left" ></asp:CheckBox >&nbsp;<label for="name" class="w3-left"> Juristic Persons</label>
         <%-- 
              <asp:TextBox ID="TextBox1" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Owner ID Card No." ></asp:TextBox>--%>
        </div>
</div>

<div class="fields "  ID="Juristic0" runat="server">

  <div class="one wide field"></div>
 <asp:UpdatePanel ID="UpdatePanel20" runat="server" class=" two wide field " style="font-family: 'Kanit', sans-serif;font-size: small;">
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
          <label for="name" class="w3-left"><a class="w3-text-red">*</a> First name :</label>

               <asp:TextBox ID="txtOwnerName" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="First name" ></asp:TextBox>
      
   </div>   

     <div  class=" six wide field " style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left"><a class="w3-text-red">*</a> Last name :</label>

               <asp:TextBox ID="txtOwnerLastName" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder=" Last name" ></asp:TextBox>
      
   </div>    
        <div class=" six wide field " style="font-family: 'Kanit', sans-serif;font-size: small;" >
          <label for="name" class="w3-left"><a class="w3-text-red">*</a> ID Card No. :</label>
              <asp:TextBox ID="txtOwnerIdcard" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Owner ID Card No." ></asp:TextBox>
        </div>

<div class="four wide field " style="font-family: 'Kanit', sans-serif;font-size: small; display:none;">
          <label for="name" class="w3-left"><a class="w3-text-red">*</a>Telephone :</label>
         
              <asp:TextBox ID="txtOwnertel" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Owner Telephone" ></asp:TextBox>
        </div>

</div>

<div class="fields" ID="Juristic1" runat="server"  ><%--style=" display:none;"--%>

  <div class="one wide field"></div>

    
      <div  class="fourteen wide field " style="font-family: 'Kanit', sans-serif;font-size: small;" >
          <label for="name" class="w3-left"><a class="w3-text-red">*</a> Juristic name :</label>

               <asp:TextBox ID="txtJuristicName" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Juristic name" ></asp:TextBox>
      
   </div>   

  
        <div class=" six wide field " style="font-family: 'Kanit', sans-serif;font-size: small;" >
          <label for="name" class="w3-left"><a class="w3-text-red">*</a> Juristic ID :</label>
              <asp:TextBox ID="txtJuristicID" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Juristic ID" ></asp:TextBox>
        </div>


</div>

 
 <div class="fields" style="margin-left: 4.5%; " >
  <%--<div class="one wide field"></div>--%>
        <div class=" sixteen wide field" style="margin-top:-0.22rem;font-family: 'Kanit', sans-serif;font-size: small;">
        <%--<div class="two wide field">&nbsp; &nbsp; </div>--%>
         
          <label for="name" class="w3-left"><a class="w3-text-red">*</a> Address :</label>
        
               <asp:TextBox ID="txtOwnerAddress" type="text" class="textarea w3-input w3-border w3-round-large" TextMode="MultiLine" runat="server" placeholder="Owner Address" ></asp:TextBox>
               
      </div>
     </div>
      <div class="fields" style="margin-top:1rem;">
      <div class="one wide field"></div>
         <div class="five wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Province : </label>
                 <asp:TextBox ID="txtOwnerProvince" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Province" ></asp:TextBox>
        </div>

        
           <div class="three wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Zipcode: </label>
                 <asp:TextBox ID="txtOwnerZipcode" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Zipcode" ></asp:TextBox>
        </div>

        <div class="six wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left"><a class="w3-text-red">*</a> Country : </label>
            <asp:DropDownList ID="ddlOwnerCountry" runat="server" class="w3-input w3-border w3-round-large"> 
         <%--   <asp:ListItem Value="Myanmar" Text="Myanmar"></asp:ListItem>
             <asp:ListItem Value="Cambodia" Text="Cambodia"></asp:ListItem>--%>
            </asp:DropDownList>
            </div>

        <div class="six wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left"><a class="w3-text-red">*</a> Email : </label>
                  <asp:TextBox ID="txtLicenseEmail" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
            </div>
   
 </div>  
</asp:Panel>


      <br />
       <asp:Button ID="btnNext2"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large" OnClientClick="$('#loadings').show();"   runat="server" UseSubmitBehavior="false" Text="Next" />
</div>

</div>


<div id="form2" class="w3-animate-right fill w3-hide text-dark ui-form w3-margin" style="font-family: 'Kanit', sans-serif;"><%--margin-left:10%--%>
<div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom: .21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 6%;font-size: x-large;">
  Main Driver
</b>
</div>
<br />
<asp:Label ID="lblcomments2" class="w3-text-red" runat="server"></asp:Label>   
<br />

<asp:Panel ID="Page2" runat="server">

<div class="ui stackable five column grid container " style="font-family: 'Kanit', sans-serif;">
<%-- <div class="w3-left fields col-md-1 pb-3"></div>--%>
  <div class="w3-left fields col-md-1 pb-3"  >
  <asp:UpdatePanel ID="UpdatePanel3" runat="server" style="font-family: 'Kanit', sans-serif;font-size: small;">
    <ContentTemplate>


          <label for="Prename" class="w3-left"><a class="w3-text-red">*</a>Title : </label>
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

    <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label class="w3-left"><a class="w3-text-red">*</a> Name : </label>
            <asp:TextBox ID="txtName" type="Name" class="w3-input w3-border w3-round-large" runat="server" placeholder="Name" ></asp:TextBox>
               
         </div>  

        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label class="w3-left fields"><a class="w3-text-red">*</a> Last Name : </label>
                 <asp:TextBox ID="txtSurname" type="Surname" class="w3-input w3-border w3-round-large" runat="server" placeholder="Last Name" ></asp:TextBox>
        </div>
 
            

    <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
           <label class="w3-left fields"><a class="w3-text-red">*</a> Gender : </label>
            <asp:DropDownList ID="ddlGender" runat="server" class="w3-input w3-border w3-round-large"> 
            <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
             <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
            </asp:DropDownList>
            </div>
 
 <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields"><a class="w3-text-red">*</a> Birth Date : </label>
                 <asp:TextBox ID="txtDate" type="txtDate" autocomplete="off"  class="w3-input w3-border w3-round-large w3-left " runat="server" placeholder="Birth Date"></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left fields"><a class="w3-text-red">*</a> Nationality : </label> 
            <asp:DropDownList ID="ddlNational" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
            </div>

           

 </div>        



 <div class="ui stackable three column grid container" >
 <%--<div class="w3-left fields col-md-1 pb-3"></div>--%>
 <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields"><a class="w3-text-red">*</a> Passport No. : </label>
                 <asp:TextBox ID="txtPassportNo" type="passport" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport No" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields"><a class="w3-text-red">*</a> Passport Expiry Date : </label>
                 <asp:TextBox ID="txtPassportExpire" type="PassportExpire" autocomplete="off" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport Expiry Date" ></asp:TextBox>
        </div>

 <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields"><a class="w3-text-red">*</a> Driver License No. : </label>
                 <asp:TextBox ID="txtLicenseDriver" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License No." ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-4 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields"><a class="w3-text-red">*</a> Driver License Expiry Date : </label>
                 <asp:TextBox ID="txtLicenseExpire" type="LicenseExpire" autocomplete="off" class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License Expiry Date" ></asp:TextBox>
        </div>
 
 </div>
  
        <div class="ui stackable four column grid  container">
       <%-- <div class="w3-left fields col-md-1 pb-3"></div>--%>
        <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields"><a class="w3-text-red">*</a> Address : </label>
                 <asp:TextBox ID="txtAddress" type="Address" class="w3-input w3-border w3-round-large"  TextMode="MultiLine" runat="server" placeholder="Address" ></asp:TextBox>
        </div>


         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields"><a class="w3-text-red">*</a> Province : </label>
                 <asp:TextBox ID="txtCounty" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Province" ></asp:TextBox>
        </div>

        
           <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Zipcode: </label>
                 <asp:TextBox ID="txtZipcode" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Zipcode" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left fields"><a class="w3-text-red">*</a> Country : </label>
            <asp:DropDownList ID="ddlCountry" runat="server" class="w3-input w3-border w3-round-large"> 
        
            </asp:DropDownList>
            </div>

               </div>
 
         <div class="ui stackable four column grid container" >
       <%--   <div class="w3-left fields col-md- pb-3"></div>--%>
         
              <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname"  class="w3-left"><a class="w3-text-red">*</a> Telephone : </label>
                 <asp:TextBox ID="txtTel" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Telephone" ></asp:TextBox>
        </div>

            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Email : </label>
            <asp:TextBox ID="txtEmail" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
        </div>

         </div>

          
      <br /> &nbsp; 
   
   <div class="ui stackable two column grid container ">
    
    <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left" ><a class="w3-text-red">*</a> Passport ( jpg or png and size of attached file not over 5 MB) : </label>
       
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

        <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left" > Passport ( jpg or png and size of attached file not over 5 MB) (Optional) : </label>
       
           <asp:UpdatePanel ID="UpdatePanel1_2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload1_2" runat="server" onchange="document.getElementById('MainContent_btnUploadPassport_2').click();" />
            <asp:ImageButton ID="btnUploadPassport_2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNamePassport_2" runat="server" />
            <asp:Image ID="PhotoPassport_2" runat="server" Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeletePassport_2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadPassport_2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>

        </div>
        <div class="ui stackable two column grid container " id="divReserveDriver0">

       <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left" > <a class="w3-text-red">*</a> Driver License ( jpg or png and size of attached file not over 5 MB) : </label>
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

        <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left" > Driver License ( jpg or png and size of attached file not over 5 MB) (Optional) : </label>
           <asp:UpdatePanel ID="UpdatePanel4_2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload3_2" runat="server" onchange="document.getElementById('MainContent_btnUploadLicense_2').click();" />
            <asp:ImageButton ID="btnUploadLicense_2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNameLicense_2" runat="server" />
            <asp:Image ID="PhotoLicense_2" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteLicense_2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense_2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
        </div>
          <div class="ui stackable two column grid container ">
         <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left" >Certified translation of driver license (For pdf files only) (If applicable) : </label>
           <asp:UpdatePanel ID="UpdatePanelCer" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadPhotoCer" runat="server" onchange="document.getElementById('MainContent_btnUploadCer').click();" />
            <asp:ImageButton ID="btnUploadCer" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoCer" runat="server" />
               <%--เปลี่ยนจากรูปเป็นไฟล์--%>
            <%--<asp:Image ID="PhotoCer" runat="server"  Height="200px" Width="250px"/>--%>
            <br/><asp:HyperLink ID="linkPhotoCer" CssClass="w3-text-purple"  runat="server"><asp:Image ID="imgpdf" ImageUrl="~/image/pdf32.png" Height="24px" runat="server"  /> File Certified translation of driver license </asp:HyperLink>
            <asp:ImageButton ID="PhotoDeleteCer"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadCer"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>

      </div>
      <br />
<br />
<script language="javascript" type="text/javascript">
    function setFocusPage(_divName) {
        var PageAutoSec = 500;
        setTimeout(function () {
            document.location.href = '#' + _divName;
        }, PageAutoSec);
    }
</script>

 <div class="row"  >
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom: .21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left:6%;font-size: x-large;">
  Reserve Driver 1
</b>

</div>
<br />
<br />

<div class="ui stackable four column grid container" >
 <%--<div class="w3-left fields col-md-1 pb-3"></div>--%>
  <div class="w3-left fields col-md-1 pb-3">
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

        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label class="w3-left fields">Last Name : </label>
                 <asp:TextBox ID="txtSurname2" type="Surname" class="w3-input w3-border w3-round-large" runat="server" placeholder="Last Name" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Gender : </label>
            <asp:DropDownList ID="ddlGender2" runat="server" class="w3-input w3-border w3-round-large"> 
            <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
             <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
            </asp:DropDownList>
            </div>

                <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left fields">Nationality : </label> 
            <asp:DropDownList ID="ddlNational2" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
            </div>


 </div>        

 <div class="ui stackable three column grid container">
  <%--<div class="w3-left fields col-md-1 pb-3"></div>--%>
  
         <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Passport No : </label>
                 <asp:TextBox ID="txtPassportNo2" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport No" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields">Passport Expire : </label>
                 <asp:TextBox ID="txtPassport_exp2" autocomplete="off" type="LicenseExpire" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport Expire" ></asp:TextBox>
        </div>
 <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Driver License No. : </label>
                 <asp:TextBox ID="txtLicense2" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License No." ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields">Driver License Expiry Date : </label>
                 <asp:TextBox ID="txtLicenseExpire2" autocomplete="off" class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License Expiry Date" ></asp:TextBox>
        </div>

 
 </div>
  
        <div class="ui stackable four column grid container" >
     <%--   <div class="w3-left fields col-md-1 pb-3"></div>--%>
        <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Address : </label>
                 <asp:TextBox ID="txtAddress2" type="Address" TextMode="MultiLine" class="w3-input w3-border w3-round-large" runat="server" placeholder="Address" ></asp:TextBox>
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
 
         <div class="ui stackable three column grid container" id="divReserveDriver1">
        <%-- <div class="w3-left fields col-md-1 pb-3"></div>--%>
            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname"  class="w3-left">Telephone : </label>
                 <asp:TextBox ID="txtTel2" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Telephone" ></asp:TextBox>
        </div>

            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Email : </label>
            <asp:TextBox ID="txtEmail2" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
        </div>

         </div>
   
    <br /> &nbsp; 
   <div class="ui stackable four column grid container" >

    <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Passport ( jpg or png and size of attached file not over 5 MB) : </label>
       
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
        <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Passport ( jpg or png and size of attached file not over 5 MB) (Optional): </label>
       
           <asp:UpdatePanel ID="UpdatePassport2_2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadPassport2_2" runat="server" onchange="document.getElementById('MainContent_btnUploadPassport2_2').click();" />
            <asp:ImageButton ID="btnUploadPassport2_2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNamePassport2_2" runat="server" />
            <asp:Image ID="PhotoPassport2_2" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeletePassport2_2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadPassport2_2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
        </div>
        <div class="ui stackable four column grid container">
       <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Driver License ( jpg or png and size of attached file not over 5 MB) : </label>
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
        <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Driver License ( jpg or png and size of attached file not over 5 MB) (Optional): </label>
           <asp:UpdatePanel ID="UpdateLicense2_2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadLicense2_2" runat="server" onchange="document.getElementById('MainContent_btnUploadLicense2_2').click();" />
            <asp:ImageButton ID="btnUploadLicense2_2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNameLicense2_2" runat="server" />
            <asp:Image ID="PhotoLicense2_2" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteLicense2_2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense2_2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
 </div>
        <div class="ui stackable four column grid container">
           <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Certified translation of driver license (For pdf files only) (If applicable) : </label>
           <asp:UpdatePanel ID="UpdatePanelCer2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadPhotoCer2" runat="server" onchange="document.getElementById('MainContent_btnUploadCer2').click();" />
            <asp:ImageButton ID="btnUploadCer2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoCer2" runat="server" />
            
            <%--เปลี่ยนจากรูปเป็นไฟล์--%>
            <%--<asp:Image ID="PhotoCer2" runat="server"  Height="200px" Width="250px"/>--%>
            <br/><asp:HyperLink ID="linkPhotoCer2" CssClass="w3-text-purple"  runat="server"><asp:Image ID="Image1" ImageUrl="~/image/pdf32.png" Height="24px"  runat="server" /> File Certified translation of driver license </asp:HyperLink>
            <asp:ImageButton ID="PhotoDeleteCer2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadCer2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
      </div>

<br />
<br />
 <div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom:.21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left:6%;font-size: x-large;">
  Reserve Driver 2
</b>
</div>
<br />
<br />

<div class="ui stackable four column grid container">
<%--<div class="w3-left fields col-md-1 pb-3"></div>--%>
<div class="w3-left fields col-md-1 pb-3" >
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

        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label class="w3-left fields">Last Name : </label>
                 <asp:TextBox ID="txtSurname3" type="Surname" class="w3-input w3-border w3-round-large" runat="server" placeholder="Last Name" ></asp:TextBox>
        </div>

        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Gender : </label>
            <asp:DropDownList ID="ddlGender3" runat="server" class="w3-input w3-border w3-round-large"> 
            <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
             <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
            </asp:DropDownList>
            </div>

    <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left fields">Nationality : </label> 
            <asp:DropDownList ID="ddlNational3" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
            </div>
 </div>        

 <div class="ui stackable three column grid container">

      <%--  <div class="w3-left fields col-md-1 pb-3"></div>--%>
       
  <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Passport No. : </label>
                 <asp:TextBox ID="txtPassportNo3" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport No. " ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields">Passport Expire : </label>
                 <asp:TextBox ID="txtPassport_exp3" type="LicenseExpire" autocomplete="off" class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport Expire" ></asp:TextBox>
        </div>
 <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left fields">Driver License No. : </label>
                 <asp:TextBox ID="txtLicense3" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License No." ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Expire License" class="w3-left fields">Driver License Expiry Date : </label>
                 <asp:TextBox ID="txtLicenseExpire3" type="LicenseExpire" autocomplete="off" class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License Expiry Date" ></asp:TextBox>
        </div>
 </div>
  
        <div class="ui stackable four column grid container" >
        <%-- <div class="w3-left fields col-md-1 pb-3"></div>--%>
        <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;" >
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
 
         <div class="ui stackable three column grid container" id="divReserveDriver2">
         <%-- <div class="w3-left fields col-md-1 pb-3"></div>--%>
            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname"  class="w3-left">Telephone : </label>
                 <asp:TextBox ID="txtTel3" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Telephone" ></asp:TextBox>
        </div>

            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Email : </label>
            <asp:TextBox ID="txtEmail3" type="Address" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
        </div>

         </div>

          <br /> &nbsp; 
   <div class="ui stackable  four column grid container">

    <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Passport ( jpg or png and size of attached file not over 5 MB) : </label>
       
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
        <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Passport ( jpg or png and size of attached file not over 5 MB) (Optional): </label>
       
           <asp:UpdatePanel ID="UpdatePassport3_2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadPassport3_2" runat="server" onchange="document.getElementById('MainContent_btnUploadPassport3_2').click();" />
            <asp:ImageButton ID="btnUploadPassport3_2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNamePassport3_2" runat="server" />
            <asp:Image ID="PhotoPassport3_2" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeletePassport3_2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadPassport3_2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
        </div>
        <div class="ui stackable  four column grid container">
       <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Driver License ( jpg or png and size of attached file not over 5 MB)  : </label>
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
        <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Driver License ( jpg or png and size of attached file not over 5 MB)  (Optional): </label>
           <asp:UpdatePanel ID="UpdateLicense3_2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadLicense3_2" runat="server" onchange="document.getElementById('MainContent_btnUploadLicense3_2').click();" />
            <asp:ImageButton ID="btnUploadLicense3_2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNameLicense3_2" runat="server" />
            <asp:Image ID="PhotoLicense3_2" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteLicense3_2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense3_2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
        </div>
        <div class="ui stackable  four column grid container">
          
         <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name" class="w3-left">Certified translation of  driver license (For pdf files only) (If applicable) : </label>
           <asp:UpdatePanel ID="UpdatePanelCer3" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUploadPhotoCer3" runat="server" onchange="document.getElementById('MainContent_btnUploadCer3').click();" />
            <asp:ImageButton ID="btnUploadCer3" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoCer3" runat="server" />
            
            <%--เปลี่ยนจากรูปเป็นไฟล์--%>
            <%--<asp:Image ID="PhotoCer3" runat="server"  Height="200px" Width="250px"/>--%>
            <br/><asp:HyperLink ID="linkPhotoCer3" CssClass="w3-text-purple"  runat="server"><asp:Image ID="Image2" ImageUrl="~/image/pdf32.png" Height="24px"  runat="server" /> File Certified translation of driver license </asp:HyperLink>
            <asp:ImageButton ID="PhotoDeleteCer3"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadCer3"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>

      </div>
 
 </asp:Panel>
 
          
 
         <div class="pb-0" >	
    <div class="ml-5 pt-5 pb-5 mb-5 pr-5" style="font-family: 'Kanit', sans-serif; font-size: small;">
        <asp:Button ID="btnNext3"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Next" />
          <asp:Button ID="btnPrev2" class="w3-purple w3-btn w3-round-large w3-left w3-large"  runat="server" UseSubmitBehavior="false" Text="Prev" />
      </div>
                
             </div>
          
     </div>

<div id="form3" class=" w3-animate-right fill w3-hide text-dark ui-form ">

 <div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom:.21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 10%;font-size: x-large;">
  Vehicle
</b>
 
</div>
<%--<br />--%>
<asp:Label ID="lblcomments3" class="w3-text-red" runat="server"></asp:Label>   
<br />
<br />

<asp:Panel ID="Page3" runat=server>
<div class="ui stackable four column grid ">

<div class="w3-left fields col-md-1 pb-3 "></div>
 <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
        <label for="Surname"><a class="w3-text-red">*</a> Make : </label>
                 
        <%--</div>

        <div class="w3-left fields col-md-3 pb-3 " style="font-family: 'Kanit', sans-serif;font-size: small;">--%>

         <asp:TextBox ID="txtBrands" type="brands" class="w3-input w3-border w3-round-large" runat="server" placeholder="e.g. TOYOTA HONDA" ></asp:TextBox>

         <%--<label for="Surname">e.g. TOYOTA HONDA </label>--%>
        </div>

      
        <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <label for="name"><a class="w3-text-red">*</a> Model : </label>
              
        <%--</div>

        <div class="w3-left fields col-md-3 pb-3 " style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
         <asp:TextBox ID="txtModel" type="Model" class="w3-input w3-border w3-round-large" runat="server" placeholder="e.g. VIGO CIVIC" ></asp:TextBox>
<%--
         <label for="name">e.g.VIGO CIVIC   </label>--%>
        </div>

       
 <%--</div>

 <div class="ui stackable four column grid ">
 <div class="w3-left fields col-md-1 pb-3 "></div>--%>

  <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
        <label for="name"><a class="w3-text-red">*</a> Colors : </label>
            
        <%--</div>

        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
        <asp:DropDownList ID="ddlColor" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
        
        </div>

        <%--</div>

 <div class="ui stackable four column grid ">
 <div class="w3-left fields col-md-1 pb-3 "></div>--%>
        <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
        <label for="name"><a class="w3-text-red">*</a> Seats : </label>
             
      
            <asp:TextBox ID="txtSeats"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Seats" ></asp:TextBox>
        </div>

 </div>

 <%--<br />--%>
   
 <div class="ui stackable four column grid ">
  <div class="w3-left fields col-md-1 pb-3 "></div>
 


      <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Country of registration : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
      <asp:UpdatePanel ID="UpdatePanel5" runat="server">
     <ContentTemplate>    <asp:DropDownList ID="ddlCountryCar" runat="server" class="w3-input w3-border w3-round-large" AutoPostBack="true"> 
            </asp:DropDownList>
            </ContentTemplate>
      <Triggers>
      <asp:AsyncPostBackTrigger ControlID="ddlCountryCar" EventName="SelectedIndexChanged" />
      </Triggers>
    </asp:UpdatePanel>
            </div>


      <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
      
          <label for="name"><a class="w3-text-red">*</a> Province of registration : </label>
        <%-- </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
             <asp:TextBox ID="txtstate_car" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Province" ></asp:TextBox>
      </div>



  
      

     <%--</div>
     <br />

         <div class="ui stackable four column grid ">
          <div class="w3-left fields col-md-1 pb-3 "></div>--%>
             <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> <%--Registration No.--%> Plate (ENG)  : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
         <asp:TextBox ID="txtLicenseCar" onpaste="return false;" oncut="return false;" ondrop="return false;" onkeypress="return Validate(event);" autocomplete="off" type="Registration No." class="w3-input w3-border w3-round-large" style="text-transform:uppercase;" runat="server" placeholder="Plate (ENG)" ></asp:TextBox>
            </div>

            <script type="text/javascript">
                function Validate(event) {
                    var regex = new RegExp("^[A-Za-z0-9]");
                    var key = String.fromCharCode(event.charCode ? event.which : event.charCode);
                    if (!regex.test(key)) {
                        event.preventDefault();
                        return false;
                    }

                } 
            </script>

            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><%--Registration No.--%> Plate (Local) : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
         <asp:TextBox ID="txtLicenseLocalCar" style="text-transform:uppercase;" type="Registration No." class="w3-input w3-border w3-round-large" runat="server" placeholder="Plate (Local)" autocomplete="off"></asp:TextBox>
            </div>


         </div>

         
<div class="ui stackable four column grid ">

 <div class="w3-left fields col-md-1 pb-3 "></div>
   <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Engine Number : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
               <asp:TextBox ID="txtNumEngine" type="Serial Engine" class="w3-input w3-border w3-round-large" runat="server" placeholder="Engine Number" ></asp:TextBox>
        </div>

        <%--</div>

         
<div class="ui stackable four column grid ">

 <div class="w3-left fields col-md-1 pb-3 "></div>--%>
            <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Engine Capacity : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
               <asp:TextBox ID="txtEnginCap" type="number" class="w3-input w3-border w3-round-large" runat="server" placeholder="Engine Capacity" ></asp:TextBox>
        </div>


<%--</div>


<div class="ui stackable four column grid ">
<div class="w3-left fields col-md-1 pb-3 "></div>--%>

  <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a>Vehicle Identification Number (VIN) : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
         <asp:TextBox ID="txtNumcar" type="Serial Car" class=" w3-input  w3-border w3-round-large" runat="server" placeholder="VIN Number" ></asp:TextBox>
            </div>

          <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Gross Weight (kg.) : </label>
           <%--</div> 
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
        
               <asp:TextBox ID="txtWeight" type="number" class="w3-input w3-border w3-round-large " runat="server" placeholder="weight" ></asp:TextBox>
        </div>

</div>

<div class="ui stackable four column grid " id="divCarAuthorize">
<div class="w3-left fields col-md-1 pb-3 "></div>


 <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Type : </label>
          <%-- </div> 
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
        
               <asp:DropDownList ID="ddltypecar" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
        </div>
        </div>

        <br /><br />
            <asp:Panel ID="pnLaos" runat="server">
            <div class="ui stackable four column grid ">
<div class="w3-left fields col-md-1 pb-3 "></div>
           
           <div class="w3-left fields col-md-5 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Vehicle Registration Certificate ( jpg or png and size of attached file not over 5 MB) : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3">--%>
 
           <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload4" runat="server" onchange="document.getElementById('MainContent_btnUploadRegisCar').click();" />
            <asp:ImageButton ID="btnUploadRegisCar" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoRegisCar" runat="server" />
            &nbsp; &nbsp; <asp:Image ID="PhotoRegisCar" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteRegisCar"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadRegisCar"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>

        <div class="w3-left fields col-md-5 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Vehicle Registration Certificate ( jpg or png and size of attached file not over 5 MB) (Optional): </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3">--%>
 
           <asp:UpdatePanel ID="UpdatePanel6_2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload4_2" runat="server" onchange="document.getElementById('MainContent_btnUploadRegisCar_2').click();" />
            <asp:ImageButton ID="btnUploadRegisCar_2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoRegisCar_2" runat="server" />
            &nbsp; &nbsp; <asp:Image ID="PhotoRegisCar_2" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteRegisCar_2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadRegisCar_2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>

        <%--<div class="w3-left fields col-md-1 pb-2 "></div>--%>
        </div><br /><br /><div class="ui stackable four column grid ">
        <div class="w3-left fields col-md-1 pb-3 "></div>
        <div class="w3-left fields col-md-5 pb-3  w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Letter of Consent from Vehicle Owner / Authorization from Vehicle Owner ( jpg or png and size of attached file not over 5 MB) : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" >--%>
 
           <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload6" runat="server" onchange="document.getElementById('MainContent_btnUploadAuthorize').click();" />
            <asp:ImageButton ID="btnUploadAuthorize" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidAuthorize" runat="server" />
            &nbsp; &nbsp; <asp:Image ID="PhotoAuthorize" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteAuthorize"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadAuthorize"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
        
        <div class="w3-left fields col-md-5 pb-3  w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">Letter of Consent from Vehicle Owner / Authorization from Vehicle Owner ( jpg or png and size of attached file not over 5 MB) (Optional) : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" >--%>
 
           <asp:UpdatePanel ID="UpdatePanel9_2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload6_2" runat="server" onchange="document.getElementById('MainContent_btnUploadAuthorize_2').click();" />
            <asp:ImageButton ID="btnUploadAuthorize_2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidAuthorize_2" runat="server" />
            &nbsp; &nbsp; <asp:Image ID="PhotoAuthorize_2" runat="server"  Height="200px" Width="250px"/>
            <asp:ImageButton ID="PhotoDeleteAuthorize_2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadAuthorize_2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>

        <br />
     
       

       </div>

    </asp:Panel> 

<br /> <br />
<asp:Panel ID="Panel1" runat="server">
<div class="ui stackable four column grid " id="divCertified">
     <div class="w3-left fields col-md-1 pb-3 "></div>

     
     <%--<div class="w3-left fields col-md-1 pb-3 "></div>--%>
     <div class="w3-left fields col-md-5 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
           <label for="name">Certified translation of vehicle registration (For pdf files only) (If applicable) : </label>
           <%--</div> 
        <div class="w3-left fields col-md-3 pb-3">--%>
        
         

           <asp:UpdatePanel ID="UpdatePanel_cer" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true" >
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload_cer"  runat="server" onchange="document.getElementById('MainContent_btnUploadCar_cer').click();"  />
            <asp:ImageButton ID="btnUploadCar_cer" style="DISPLAY: none" runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress(); " formnovalidate="formnovalidate" CausesValidation=false  UseSubmitBehavior="false"/>
               <asp:HiddenField ID="hidPhotonamecar_cer" runat="server" />
            
            <%--เปลี่ยนจากรูปเป็นไฟล์--%>
            <%--<asp:Image ID="PhotoCar_cer" runat="server" Width="250px" Hight="200"  />--%>
            &nbsp; &nbsp; <asp:HyperLink ID="linkCar_cer" CssClass="w3-text-purple"  runat="server"><asp:Image ID="Image3" ImageUrl="~/image/pdf32.png" Height="24px"  runat="server" /> File Certified translation of driver license </asp:HyperLink> 
            <asp:ImageButton ID="PhotoCar_cerDelete"  OnClientClick="javascript:return confirm('Do you want delete photo?');"  ImageUrl="~/image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" formnovalidate="formnovalidate" CausesValidation="false" UseSubmitBehavior="false" Visible="false" oncommand="PhotoCar_cerDelete_Command" />
             <br/><br/>
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadCar_cer"/>
	          </Triggers>
           </asp:UpdatePanel>

</div>
</div>
 
 
  
    
 </asp:Panel> 
                 <%--<br /><br />--%>
<asp:Panel ID="Panel2" runat="server">
<div class="ui stackable four column grid ">
<div class="w3-left fields col-md-1 pb-3 "></div>
                   <%--  <div class="w3-left fields col-md-1 pb-2 "></div>--%>

                      <%--<div class="ui stackable four column grid ">--%>

     <div class="w3-left fields col-md-4 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
           <label for="name"> Vehicle inspection cetificate ( jpg or png and size of attached file not over 5 MB) (If applicable) : </label>
           <%--</div> 
        <div class="w3-left fields col-md-3 pb-3">--%>
        
         

           <asp:UpdatePanel ID="UpdatePanel_inspec"   runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true"  >
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload_inspec" runat="server" onchange="document.getElementById('MainContent_btnUploadCar_inspec').click();" />
            <asp:ImageButton ID="btnUploadCar_inspec" style="DISPLAY: none" runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress(); " formnovalidate="formnovalidate" CausesValidation=false  UseSubmitBehavior="false"/>
               <asp:HiddenField ID="hidPhotonamecar_inspec" runat="server" />
            <asp:Image ID="PhotoCar_inspec" runat="server" Width="250px" Hight="200"  />
          <%--  <asp:ImageButton ID="PhotoCarDelete"  OnClientClick="javascript:return confirm('Do you want delete photo?');"  ImageUrl="image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" formnovalidate="formnovalidate" CausesValidation="false" UseSubmitBehavior="false" Visible="false" oncommand="PhotoCarDelete_Command" />
--%>
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadCar_inspec"/>
	          </Triggers>
           </asp:UpdatePanel>

        </div>
</div>
 
    &nbsp; &nbsp; <asp:UpdatePanel ID="UpdgvFile_inspec" runat="server" class="w3-row-padding w3-center" UpdateMode="Conditional"  >
                    <contenttemplate>
                    <div class="w3-col l01 w3-margin-bottom"></div>
                       <asp:DataList ID="DtlImg_inspec" runat="server" CellPadding="0" RepeatLayout="Flow" 
                    DataKeyField="gid" ForeColor="#333333" RepeatColumns="4" 
                            RepeatDirection="Horizontal" >
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemStyle  VerticalAlign="Middle"  HorizontalAlign="Center"/>
                   
                           <ItemTemplate> 
                            <div class="w3-col l3 m6 w3-margin-bottom">
                              <br /><%--<br />--%>
                                <div class="w3-display-container">

                                    <%--<img src="/w3images/sandwich.jpg" alt="Sandwich" style="width:100%">--%>
                                    <asp:Image ID="imageFile" runat="server" ImageUrl='<%# Bind("PathImg") %>' style="width: 200px;height: 200px;" />
                                    <%--<h3>The Perfect Sandwich, A Real NYC Classic</h3>--%>
                                 
                                    
                                      
                                <div class=" w3-margin">
                                    <a style="font-family: 'Kanit', sans-serif;font-size: small;height: 250px;"><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("PathImg") %>' Target="_blank"  runat="server">&nbsp; 
                                    &nbsp;&nbsp;&nbsp;  <asp:Label ID="lblShow" runat="server" Text='Big Picture'></asp:Label></asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="PhotoCarDeleteinspec" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                CommandArgument='<%# Eval("gid") %>' CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="PhotoCarDelete_inspec_Command" formnovalidate="formnovalidate" CausesValidation="false"  UseSubmitBehavior="false"/></a>
                                </div>

                                
                            </div>

                             </div>
                           </ItemTemplate> 
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:DataList>

                <asp:Panel style="DISPLAY: none" id="Pngrid_inspec" runat="server" Height="0px">
                        <asp:GridView ID="gvFile_inspec" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" CssClass="Grid" GridLines="None" PageSize="2"  
                            Width="500px">
                            <Columns>
                                <asp:TemplateField SortExpression="saved_name" Visible="False">
                                     <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("gid") %>'></asp:Label>
                                        <asp:Label ID="lblCarid" runat="server" Text='<%# Bind("car_id") %>'></asp:Label>
                                        <asp:Label ID="lblfile_name" runat="server" Text='<%# Bind("file_name") %>'></asp:Label>
                                         <asp:Label ID="lblPathImg" runat="server" Text='<%# Bind("PathImg") %>'></asp:Label>                                    
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pgr" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
                </asp:Panel>

                    </contenttemplate>
                     
                </asp:UpdatePanel>

                 </asp:Panel> 
                <%--<div class="w3-left fields col-md-1 pb-5 "></div>--%>
                 <br />
                  <br />

                  <asp:Panel ID="Panel3" runat="server">
    <div class="ui stackable four column grid ">
    <div class="w3-left fields col-md-1 pb-3 "></div>
<%--<div class="w3-left fields col-md-1 pb-3 "></div>--%>


 <div id="divCar" class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
             
           <label for="name"><a class="w3-text-red">*</a> Vehicle Photos : </label>
            
           <%--</div> 
        <div class="w3-left fields col-md-3 pb-3">--%>
        
            <asp:DropDownList ID="ddlImgtype" class="w3-input w3-border w3-round-large mb-4" runat="server">
                <asp:ListItem Text="Front" Value="1"></asp:ListItem>
                <asp:ListItem Text="Rear" Value="2"></asp:ListItem>
                <asp:ListItem Text="Side view" Value="3"></asp:ListItem>
          <%--      <asp:ListItem Text="Right Side" Value="4"></asp:ListItem>--%>
            </asp:DropDownList>
            
             </div>
             <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
             <br /><br />
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

        </div>
</div>
          
<!--div class="ui stackable column  grid"></div>
<div class="w3-left fields col-md-1 pb-3 "></div-->

 
  &nbsp; &nbsp;   <asp:UpdatePanel ID="UpdgvFile" runat="server" class="w3-row-padding w3-center" UpdateMode="Conditional" style="font-family: 'Kanit', sans-serif;font-size: small;">
                    <contenttemplate>
                     <div class="w3-col l02 w3-margin-bottom"></div>
                       <asp:DataList ID="DtlImg" runat="server" CellPadding="0" RepeatLayout="Flow" 
                    DataKeyField="gid" ForeColor="#333333" RepeatColumns="4" 
                            RepeatDirection="Horizontal" >
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemStyle  VerticalAlign="Middle"  HorizontalAlign="Center"/>
                   
                           <ItemTemplate> 
                            <div class="w3-col l3 m6 w3-margin-bottom">
                              <br /><%--<br />--%>
                                <div class="w3-display-container">

                                    <%--<img src="/w3images/sandwich.jpg" alt="Sandwich" style="width:100%">--%>
                                    <asp:Image ID="imageFile" runat="server" ImageUrl='<%# Bind("PathImg") %>' style="width: 250px;height: 250px;" />
                                    <%--<h3>The Perfect Sandwich, A Real NYC Classic</h3>--%>
                                 
                                    
                                      
                                <div class=" w3-margin">
                                    <a style="font-family: 'Kanit', sans-serif;font-size: small;height: 250px;"><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("PathImg") %>' Target="_blank"  runat="server">&nbsp; 
                                    &nbsp;&nbsp;&nbsp;  <asp:Label ID="lblShow" runat="server" Text='<%# Bind("ImgType") %>'></asp:Label></asp:HyperLink>&nbsp;&nbsp;
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

</asp:Panel>

    


 <div class="pb-0">	
    <div class="ml-5 pt-5 pb-5 mb-5 pr-5" style="font-family: 'Kanit', sans-serif; font-size: small;">
        <asp:Button ID="btnNext4"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large" runat="server" UseSubmitBehavior="false" Text="Next" />
         <asp:Button ID="btnPrev3"  class=" w3-left  w3-purple w3-btn w3-round-large w3-large" runat="server" UseSubmitBehavior="false" Text="Prev" />
      </div>
    </div>

</div>

<div id="form4" class=" container w3-animate-right fill w3-hide text-dark w3-margin">


 <div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom:.21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 10%;font-size: x-large;">
 Compulsory motor vehicle insurance (พรบ.)
</div>
<br />
<asp:Label ID="lblcomments4" class="w3-text-red" runat="server"></asp:Label>   
<br /> &nbsp; 

<asp:Panel ID="Page4" runat=server>
<div class="ui stackable four column grid ">

<div class="w3-left fields col-md-1 pb-3 "></div>

  <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
    
        <label for="name"><a class="w3-text-red">*</a> Insurance Company :</label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
               <asp:TextBox ID="txtActCompany" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Insurance Company" ></asp:TextBox>
        </div>


        <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Policy Number : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
               <asp:TextBox ID="txtActNo" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Policy Number" ></asp:TextBox>
        </div>
<%--</div>
--%>
      


<%--<div class="ui stackable four column grid ">

<div class="w3-left fields col-md-1 pb-3 "></div>--%>
        
          <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Start date : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
               <asp:TextBox ID="txtActStart" type="text" autocomplete="off" class="w3-input w3-border w3-round-large" runat="server" placeholder="Start date" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> End date : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%> 
               <asp:TextBox ID="txtActExpire" type="text" autocomplete="off" class="w3-input w3-border w3-round-large" runat="server" placeholder="End date" ></asp:TextBox>
        </div>

 </div>
<br /> &nbsp;
<div class="ui stackable four column grid ">

<div class="w3-left fields col-md-1 pb-3 "></div> 
        
        
           <div class="w3-left fields col-md-6 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Policy Schedule ( jpg or png and size of attached file not over 5 MB) : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;" >--%>
         
           <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload5" runat="server" onchange="document.getElementById('MainContent_btnUploadAct').click();" />
            <asp:ImageButton ID="btnUploadAct" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoAct" runat="server" />
            &nbsp; <asp:Image ID="PhotoAct" runat="server"  Height="250px" Width="300px"/>
            <asp:ImageButton ID="PhotoDeleteAct"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadAct"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
        <div class="w3-left fields col-md-5 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"> Policy Schedule ( jpg or png and size of attached file not over 5 MB) (Optional) : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;" >--%>
         
           <asp:UpdatePanel ID="UpdatePanel7_2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload5_2" runat="server" onchange="document.getElementById('MainContent_btnUploadAct_2').click();" />
            <asp:ImageButton ID="btnUploadAct_2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoAct_2" runat="server" />
            &nbsp; <asp:Image ID="PhotoAct_2" runat="server"  Height="250px" Width="300px"/>
            <asp:ImageButton ID="PhotoDeleteAct_2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadAct_2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>
  </div>
 
  <br /> <br />  &nbsp; 
  <div class="row">
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom:.21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 10%;font-size: x-large;">
 Third-party liability motor vehicle insurance (ประกันภัยบุคคลที่ 3 วงเงินคุ้มครองตามที่กรมการขนส่งทางบกกำหนด)
</b>
</div>
<%--<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom:.21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);font-size: x-large;">
 Third-party liability motor vehicle insurance (ประกันภัยชั้น 3 ระบุวงเงินคุ้มครองตามข้อ 5) 
</b>--%>
<br /> &nbsp; <br /> 
<div class="ui stackable four column grid " id="divThird-party">
<div class="w3-left fields col-md-1 pb-3 "></div>

  <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
    
        <label for="name"><a class="w3-text-red">*</a> Insurance Company :</label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
               <asp:TextBox ID="txtActCompany2" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Insurance Company" ></asp:TextBox>
        </div>


        <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Policy Number : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
               <asp:TextBox ID="txtActNo2" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Policy Number" ></asp:TextBox>
        </div>
<%--</div>--%>

      


<%--<div class="ui stackable four column grid ">

<div class="w3-left fields col-md-1 pb-3 "></div>--%>
        
          <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Start date : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">--%>
               <asp:TextBox ID="txtActStart2" type="text" autocomplete="off" class="w3-input w3-border w3-round-large" runat="server" placeholder="Start date" ></asp:TextBox>
        </div>

         <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> End date : </label>
        <%-- </div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;"> --%>
               <asp:TextBox ID="txtActExpire2" type="text" autocomplete="off" class="w3-input w3-border w3-round-large" runat="server" placeholder="End date" ></asp:TextBox>
        </div>

</div>

<br /> &nbsp;
<div class="ui stackable four column grid ">

<div class="w3-left fields col-md-1 pb-3 "></div>
        
        
           <div class="w3-left fields col-md-6 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name"><a class="w3-text-red">*</a> Policy Schedule ( jpg or png and size of attached file not over 5 MB) : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;" >--%>
         
           <asp:UpdatePanel ID="UpdatePanel72" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload52" runat="server" onchange="document.getElementById('MainContent_btnUploadAct2').click();" />
            <asp:ImageButton ID="btnUploadAct2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoAct2" runat="server" />
            &nbsp; <asp:Image ID="PhotoAct2" runat="server"  Height="250px" Width="300px"/>
            <asp:ImageButton ID="PhotoDeleteAct2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadAct2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div>  

        <div class="w3-left fields col-md-5 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
          <label for="name">  Policy Schedule ( jpg or png and size of attached file not over 5 MB) (Optional) : </label>
         <%--</div>    
        <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;" >--%>
         
           <asp:UpdatePanel ID="UpdatePanel72_2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload52_2" runat="server" onchange="document.getElementById('MainContent_btnUploadAct2_2').click();" />
            <asp:ImageButton ID="btnUploadAct2_2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="~/image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoAct2_2" runat="server" />
            &nbsp; <asp:Image ID="PhotoAct2_2" runat="server"  Height="250px" Width="300px"/>
            <asp:ImageButton ID="PhotoDeleteAct2_2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadAct2_2"/>
	          </Triggers>
           </asp:UpdatePanel>
          
        </div> 
</div>
<br />
<div class="ui stackable four column grid " >
<div class="w3-left fields col-md-1 pb-3 "></div>
<div class="w3-left fields col-md-5 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif;font-size: small;">
<p>Third Party Coverage<br />
- Limit liability for bodily injury or death – no less than 1,000,000 baht per person in an accident<br />
- Limit liability for property – no less than 1,000,000 baht per accident</p>
<p>ความคุ้มครองของประกันภัยบุคคลที่ 3<br />
- ความคุ้มครองความเสียหายต่อชีวิตและร่างกายของบุคคลภายนอกไม่ต่ำกว่า 1,000,000 บาทต่อหนึ่งคนในแต่ละครั้ง<br />
- ความคุ้มครองความเสียหายต่อทรัพย์สินไม่ต่ำกว่า 1,000,000 บาท ในแต่ละครั้ง
</p>
</div>
</div>
<br /> &nbsp;
</asp:Panel>

 <div class="pb-0">	
    <div class="ml-5 pt-5 pb-5 mb-5 pr-5" style="font-family: 'Kanit', sans-serif; font-size: small;">
             <asp:Button ID="btnPrev4"  class=" w3-left w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Prev" />
           <asp:Button ID="btnSave" class=" w3-right w3-purple w3-btn w3-round-large w3-large "   runat="server" UseSubmitBehavior="false" Text="Save" />
           <asp:Panel runat=server ID="pnSubmit" Visible=false> <button class="w3-center w3-purple w3-btn w3-round-large w3-large" runat="server" onclick ="Submit();return false;" UseSubmitBehavior=false>Submit</Button></asp:Panel>  
      </div>
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

 
 <br /><br /><br /><br /> <br /><br /> <br />


</asp:Panel>

 </div>

 </div>

 </div>    


</div>
 </form>
</div>
<%--</div>--%>
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

    <br/>



</asp:Content>