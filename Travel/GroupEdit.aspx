<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageC.master" AutoEventWireup="false" CodeFile="GroupEdit.aspx.vb" Inherits="Travel_GroupEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
       <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous" />
    <script type="text/javascript" src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
   
    <link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
    <link href="../Styles/progress-wizard.min.css" rel="stylesheet"/>
    
    <link rel="Stylesheet" type="text/css" href="../Scripts/Semantic/semantic.min.css" />
    <script src="../Scripts/Semantic/semantic.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/css/w3-theme-deep-purple.css" />
    <link rel="stylesheet" href="../Styles/w3Home.css"/>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     
     <style>
  body {
      overflow-x: unset;
   
      }
  @font-face{
      font-family: 'Kanit', sans-serif;
        src : url('font/ThaiSansNeue-Regular/thaisansneue-bold-webfont.woff2');
    
    
    }
    
    .toplabel
    {
        margin-top:10px!important;
        /*margin-left:-20px;*/
        }
  </style>
<script type="text/javascript">

    function tab_active(_tab) {
        var _tab1 = document.getElementById("tab1");
        var _tab2 = document.getElementById("tab2");
        var _tab3 = document.getElementById("tab3");
        

        var _form1 = document.getElementById("formT1");
        var _form2 = document.getElementById("formT2");
        var _form3 = document.getElementById("formT3");
        

        var _tab_active = "nav-link w3-purple2 active ";
        var _tab_hide = "nav-link w3-purple3";
        var _tab_complete = "completed";
        var _tab_active2 = "active";
//        var _form_active = "w3-animate-center col-12 text-dark w3-padding w3-white ";
        var _form_active = "w3-animate-center col-12 text-dark ";
        var _form_hide = "w3-animate-center  col-12 text-dark w3-hide ";


        if (_tab == 1) {

            _tab1.className = _tab_active;
            _tab2.className = _tab_hide;
            _tab3.className = _tab_hide;
           

            _form1.className = _form_active;
            _form2.className = _form_hide;
            _form3.className = _form_hide;
            
        }
        else if (_tab == 2) {
            _tab1.className = _tab_hide;
            _tab2.className = _tab_active;
            _tab3.className = _tab_hide;
            

            _form1.className = _form_hide;
            _form2.className = _form_active;
            _form3.className = _form_hide;
           
        }
        else if (_tab == 3) {
            
            _tab1.className = _tab_hide;
            _tab2.className = _tab_hide;
            _tab3.className = _tab_active;

            _form1.className = _form_hide;
            _form2.className = _form_hide;
            _form3.className = _form_active;

        }
         
    }



    window.tab_activeIframe = function (_tab) {
        if (_tab == 0) {
            var href = window.location.href.split('?')[0].toLowerCase().replace("groupedit.aspx", "group.aspx");
            window.location.href = href;
        }
        else if (_tab == 1) {
            LoadPageNew();
        }
        else {
            tab_active(_tab);
        }
    }

    window.tab_Redirect = function (_href) {
        var href = window.location.href.split('?')[0].toLowerCase().replace("groupedit.aspx", _href);
        window.location.href = href;
    }

    function LoadPageNew() {
      
        var href = window.location.href;
        window.location.href = href;
    }

    function closeIFrame() {
        window.open(window.location, '_self').close();
    }



</script>
 
  
<div class="container col-12  position-relative w3-padding w3-white w3-padding-top32"  

<header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
           <a class=" w3-text-purple" style="margin-left:0%"><b style="font-size:1.7em;margin-left:0%;font-family: 'Kanit', sans-serif;"><i class="fa fa-pencil-square" aria-hidden="true"></i>  Edit Tour Group</b></a><br /><br />
    </header>
    <form id="Form1"  align="center">     


       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
           </asp:ScriptManager>
  
  <ul class="nav nav-pills nav-justified">
    <li class="nav-item" >
      <a id="tab1" href="javascript:LoadPageNew();">Tour Group <br /> </a>
    </li>
    <li class="nav-item">
      <a id="tab2" href="javascript:tab_active(2);" > Car <br /> </a>
    </li>
    <li class="nav-item">
      <%--<a id="tab3" href="javascript:tab_active(3);"> Tour Leader <br /> </a>--%>
      <a id="tab3" href="javascript:document.getElementById('MainContent_btnNext3').click();"> Tour Leader <br /> </a>
      
    </li>
  </ul><br/>
  
  <div class="container col-12 log-in--container position-relative w3-text-deep-purple w3-card-2 w3-round-large w3-theme-l5 "  > 
 <br/>
  <div id="formT1"  >
        <iframe runat="server" id="Iframe1" enableviewstate="true" frameborder="0" class="w3-theme-l5"
            name="Iframe1" scrolling="yes"   width="100%"  src=""  
            style="background-color: transparent; height: 1380px;" >Your browser does not support iframes 
        </iframe>
  </div>
  <div id="formT2" class="container ">
        <iframe runat="server" id="Iframe2" enableviewstate="true" frameborder="0" class="w3-theme-l5"
            name="Iframe1" scrolling="no"   width="100%"  src=""  
            style="background-color: transparent; height: 780px;" >Your browser does not support iframes 
        </iframe>
  </div>
  <div id="formT3" class="container ">
  <iframe runat="server" id="Iframe3" enableviewstate="true" frameborder="0" class="w3-theme-l5"
            name="Iframe1" scrolling="no"   width="100%"  src=""  
            style="background-color: transparent; height: 980px;" >Your browser does not support iframes 
        </iframe>
  </div>
      </div>
    </form>
</div>
   <%--<asp:UpdatePanel ID="UpdateButton1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>--%>
   <asp:Panel ID="PnDelete" style="DISPLAY: none" runat="server" >

     <asp:Button ID="btnNext3"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Next" />

</asp:Panel>
<%--</ContentTemplate>
  </asp:UpdatePanel>--%>
</asp:Content>

