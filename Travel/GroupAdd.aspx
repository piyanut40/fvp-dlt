<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageC.master" AutoEventWireup="false" CodeFile="GroupAdd.aspx.vb" Inherits="Travel_GroupAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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

<link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.9/css/select2.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.9/js/select2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script language="javascript" type="text/javascript">
    $(window).load(function () {
        $('#loadings').hide();
    });
</script>
  <div id="loadings" align="center" class="overlays">
            <div class="loader" ></div>
        </div>
<asp:HiddenField id="HidExpDate" runat="server"></asp:HiddenField>    
<style type="text/css">
.PhotoAct
{
    width:300px;
    }
.delete
{
    margin-right: -370px;
    margin-top: -20px;
}.iframe{width:400px; height:300px;}
@media screen and (min-width: 480px) and (max-width:767px) and (orientation : portrait)
{
    .PhotoAct
{
    width: 200px;
    margin-right: 70%;
    }
.delete
{
    margin-right: 20px;
    margin-top: 10px;

}
.iframe
{   width: 250px;
    height: 250px;
    margin-left: -15%;  
}
    
}
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
    .PhotoAct
{
    width: 200px;
    margin-right: 70%;
    }
.delete
{
    margin-right: 20px;
    margin-top: 10px;
}.iframe
{   width: 250px;
    height: 250px;
    margin-left: -15%;  
}
}
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
{
    .PhotoAct
{
    width: 200px;
    margin-right: 70%;
    }
.delete
{
   margin-right: 20px;
    margin-top: 10px;
}.iframe
{   width: 250px;
    height: 250px;
    margin-left: -15%;  
    margin-top:-10%;
}
}
</style>

<script type="text/javascript">

    var v = document.getElementById('<%= HidExpDate.ClientID %>').value;
    console.log("Exp:",v);
    //    alert(v)

    function checkddlProv() {
        $("#<%=ddlProvarea.ClientID %>").select2();
    }

    function checkddlBorder() {
        $("#<%=ddlBorderCheckin.ClientID %>").select2();
        $("#<%=ddlBorderCheckout.ClientID %>").select2();
    }


     <%--function getDay() {

        var date = new Date();
        var dayname = date.toLocaleDateString('en-EN', { weekday: 'long' });
        var _Day;

        //        if (dayname.toLowerCase() == 'sunday') {
        //            _Day = '+6';
        //        }
        //        else {
        //            _Day = '+7';
        //        }

         _Day = <% Response.Write(min_date)%>;
        return _Day;
    }--%>
   // console.log("Injected min_date from server:", <%= min_date %>);
    function getDay() {
        var dayOffset = <%= min_date %>;  
        var today = new Date();
        // สร้างวันที่ใหม่ โดยบวก dayOffset เข้าไป
        var minDate = new Date(today.getFullYear(), today.getMonth(), today.getDate() + dayOffset);
        //console.log("dayOffset:", dayOffset, "typeof dayOffset:", typeof dayOffset);
        //console.log("Calculated minDate:", minDate);
        return minDate;
    }


    function getDaybyHid(pHid) {

        var date = new Date(pHid);
        return date;
    }

    $(document).ready(function () {

        $("#<%=ddlProvarea.ClientID %>").select2();


        $("#<%=ddlBorderCheckin.ClientID %>").select2();
        $("#<%=ddlBorderCheckout.ClientID %>").select2();
        $("#<%=ddladmin.ClientID %>").select2();
    });

    /* กำหนดวันเวลา + - 5 วัน กำหนดกรุ๊ปทัวร์ */

    $(function () {
        //var dateFormat = "mm/dd/yy";
        var dateFormat = "dd/mm/yy";
        $("#<%=txtStart.ClientID %>").datepicker({

            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            setDate: new Date(),
            minDate: getDay(),
            //maxDate: v, 'อยากขอให้ขยายเป็น 3 เดือนค่ะ เพราะจริงๆแล้วตามระเบียบไม่ได้ล็อคเรื่องนี้เอาไว้
            maxDate: "+100",
            showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        }).on("change", function () {
            $("#<%=txtExpire.ClientID %>").datepicker("option", "minDate", getDate(this));
            $("#<%=txtExpire.ClientID %>").datepicker("option", "maxDate", EndgetDate(this));
        });
        $("#<%=txtStart.ClientID %>").keyup(function () {
            $("#<%=txtStart.ClientID %>").val('');
        })
   
        $(function () {
            var $start = $("#<%=txtStart.ClientID %>");

       // แสดงค่า minDate ใน console
       var minDate = $start.datepicker("option", "minDate");
       console.log("Current minDate is:", minDate);

   });
    
        function getDate(element) {
            // var dateFormat1 = "dd/mm/yy";
            var date;
            try {

                date = $.datepicker.parseDate(dateFormat, element.value);
                //                var date = new Date(element.value);
            } catch (error) {
                date = null;
            }
            //            alert(date);
            return date;
        }

        function EndgetDate(element) {

            //            var date = new Date(element.value);
            date = $.datepicker.parseDate(dateFormat, element.value);
            //var expdate = new Date(v);
            date.setDate(date.getDate() + 30);
            //alert(expdate)
            /*console.log(expdate);
            if (expdate < date) {
            console.log(expdate);
            return expdate;
            } else {
            console.log(date);
            return date;
            }*/
            //            alert(date);
            return date;
        }

    });

    $(function () {
        //alert($("#<%=txtStart.ClientID %>").val());
        $("#<%=txtExpire.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "now :+20",
            setDate: new Date(),
            //minDate: '0',
            //minDate: getDay(),
            minDate: $("#<%=HidStart.ClientID %>").val() == '' ? $("#<%=txtStart.ClientID %>").val() == '' ? getDay() : $("#<%=txtStart.ClientID %>").val() : getDaybyHid($("#<%=HidStart.ClientID %>").val()),
            //maxDate: v, //'อยากขอให้ขยายเป็น 3 เดือนค่ะ เพราะจริงๆแล้วตามระเบียบไม่ได้ล็อคเรื่องนี้เอาไว้
            //maxDate: "+100",
            maxDate: $("#<%=HidEnd.ClientID %>").val() == '' ? +40 : getDaybyHid($("#<%=HidEnd.ClientID %>").val()),
            showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtExpire.ClientID %>").keyup(function () {
            $("#<%=txtExpire.ClientID %>").val('');
        })
        //alert(v)
    });


</script>

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


    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
           <a class=" w3-text-purple" style="margin-left:0%"><b style="font-size:1.7em;margin-left:0%;font-family: 'Kanit', sans-serif;"><i class="fa fa-pencil-square" aria-hidden="true"></i> <% Response.Write(text)%></b></a><br /><br />
    </header>
    <ul class="progress-indicator" style=" margin-top:10px;">
  <li id="tab1" class="active"> <span class="bubble"></span> Tour Group </li>
  <li id="tab2"> <span class="bubble"></span> Car </li>
  <li id="tab3"><span class="bubble"></span> Tour Leader </li>
</ul>
<br />

<script type="text/javascript">

    $(document).ready(function () {
        //tab1();
    });

    function tab1() {
        document.getElementById("tab1").className = "active";
        document.getElementById("tab2").className = "";
        document.getElementById("tab3").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill pl-5";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide"
    }


    function tab2() {
        document.getElementById("tab2").className = "active";
        document.getElementById("tab1").className = "completed";
        document.getElementById("tab3").className = "";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill pl-5";
        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
    }

    function tab3() {
        document.getElementById("tab1").className = "completed";
        document.getElementById("tab2").className = "completed";
        document.getElementById("tab3").className = "active";
        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
        document.getElementById("form3").className = "text-dark w3-animate-right fill pl-5"
    }


</script>

 <div align="center">
<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative w3-text-deep-purple w3-card-2 w3-round-large w3-theme-l5 w3-row-padding">          
<form>

       
<div id="form1" class="w3-animate-right fill center ui-form w3-margin text-dark  ">


<div class="ui form w3-margin w3-container" style="font-family: 'Kanit', sans-serif;">
<asp:Panel ID="Page1_2" runat="server">



<div class="fields" style="margin-top:2rem;">
<div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
 <div class=" six wide field" style="font-family: 'Kanit', sans-serif;font-size: small;" align="left" >
          <label for="name" class="w3-left">Border Crossing Checkin : </label>
          <asp:UpdatePanel id="UpdBorderCheckin" runat="server" UpdateMode="Conditional">
<ContentTemplate>
             <asp:DropDownList ID="ddlBorderCheckin"  runat="server" class="w3-input w3-border w3-round-large" > 
            </asp:DropDownList>

            </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">

    $($("#<%=ddlBorderCheckin.ClientID %>").select2()).change(function () {
        $("#<%=BtnBorderCheck.ClientID %>").click();
    });

</script>
     
            </div>
        <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
            <div class="five wide field" style="font-family: 'Kanit', sans-serif;font-size: small;" align="left" >
          <label for="name" class="w3-left">Start date : </label>
             <asp:TextBox ID="txtStart" type="text" class="w3-input w3-border w3-round-large" autocomplete="off" runat="server" placeholder="Start date" ></asp:TextBox>
            </div>
 
 </div>

 <div class="fields" style="margin-top:2rem;">
 <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
  <div class="six wide field" style="font-family: 'Kanit', sans-serif;font-size: small;" align="left">
          <label for="name" class="w3-left"> Border Crossing Checkout : </label>
          <asp:UpdatePanel id="UpdBorderCheckout" runat="server" UpdateMode="Conditional">
<ContentTemplate>
                  <asp:DropDownList ID="ddlBorderCheckout" runat="server"  class="w3-input w3-border w3-round-large" > 
            </asp:DropDownList>
             </ContentTemplate>
</asp:UpdatePanel>

<script>
    $($("#<%=ddlBorderCheckOut.ClientID %>").select2()).change(function () {
        $("#<%=BtnBorderCheckOut.ClientID %>").click();
    });
    function bordercheck() {

        $($("#<%=ddlBorderCheckOut.ClientID %>").select2()).change(function () {
            $("#<%=BtnBorderCheckOut.ClientID %>").click();
        });


    }
</script>


            </div>


            <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
<div class="five wide field" style="font-family: 'Kanit', sans-serif;font-size: small;" align="left">
          
          <label for="name" class="w3-left">End date : </label>
          <asp:TextBox ID="txtExpire" type="text" class="w3-input w3-border w3-round-large" autocomplete="off" runat="server" placeholder="End date" ></asp:TextBox>
          <asp:HiddenField ID="HidExpire" runat="server" />
          <asp:HiddenField ID="HidStart" runat="server" />
          <asp:HiddenField ID="HidEnd" runat="server" />

</div> 


</div> 


<div class="fields" style="margin-top:2rem;">
<div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
<div class=" six wide field" style="font-family: 'Kanit', sans-serif;font-size: small;" align="left">
            <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Group Name : </label>
                 <asp:TextBox ID="txtgroup_name" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Group Name" ></asp:TextBox>

                 
        </div>
        <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
         <div class=" five wide field" style="font-family: 'Kanit', sans-serif;font-size: small;" align="left">

    <label for="area" class="w3-left"><a class="w3-text-red">*</a> Travel Itinerary (For pdf files only) :  </label>

                <asp:UpdatePanel ID="UpdFilePDF" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
           <div style="font-family: 'Kanit', sans-serif;font-size: small;">
          <asp:FileUpload ID="FileUploadPDF" runat="server" onchange="document.getElementById('MainContent_btnUploadPDF').click();" />
           
            <asp:ImageButton ID="btnUploadPDF" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
            <asp:ImageButton ID="btnloadPDF" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidFNamePDF" runat="server" />
                <asp:HiddenField ID="hidSNamePDF" runat="server" />
                <asp:HiddenField ID="hidfolderPDF" runat="server" />

           
             </div>
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger  ControlID="btnUploadPDF"/>
	          </Triggers>
           </asp:UpdatePanel>


   </div>

   <div class=" three wide field" align="left" style="font-family: 'Kanit', sans-serif;font-size: small; vertical-align:bottom; ">
   <br /><br />
   <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
   <asp:HyperLink ID="hlFilePDF" runat="server" Visible="false" Cssclass="btn-link w3-text-purple" >[hlFilePDF]</asp:HyperLink>&nbsp;
             <asp:ImageButton ID="btnDelPDF"  OnClientClick="javascript:return confirm('Do you want delete file?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
   </div>
</div>
     
 

 
 
 <div class="fields" style="margin-top:2rem; margin-left:1px;">
         <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
          
        </div>
   <div class="six wide field" style="font-family: 'Kanit', sans-serif;font-size: small;"  align="left">

  <label for="area" class="w3-left"> Province to visit :  </label>

              <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
     <ContentTemplate>

    
             
 <asp:DropDownList ID="ddlProvarea" Width="94%" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>

           
          

 </ContentTemplate>
     <Triggers>
     <asp:AsyncPostBackTrigger ControlID="btnProv" EventName="Click" />
     </Triggers>
     </asp:UpdatePanel>

    <%--<br />  <label for="name" class="w3-left">Start date : </label>
             <asp:TextBox ID="txtStart" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Start date" ></asp:TextBox>
    

    <br />   <label for="name" class="w3-left">End date : </label>
                  <asp:TextBox ID="txtExpire" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="End date" ></asp:TextBox>--%>

<center>
     <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
     <ContentTemplate>

       <asp:GridView ID="gvProv" runat="server" GridLines="None" AutoGenerateColumns="false">
        <Columns>
          <asp:TemplateField Visible="false">
          <ItemTemplate>
              <asp:Label ID="lblarea_id" runat="server" Text='<%# Bind("area_id") %>'></asp:Label>
                <%--<asp:Label ID="lblarea_id" runat="server"  Text="<%# Bind('area_id') %>"></asp:Label>--%>
                <asp:Label id="lblprov_code" runat="server" Text='<%# eval("prov_code") %>'></asp:Label>
              <asp:Label ID="lblprov_en" runat="server" Text='<%# Bind("prov_en") %>'></asp:Label>
              <%--<asp:Label ID="lblprov_en" runat="server" Text="<%# Bind('prov_en') %>"></asp:Label>--%>
                
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="prov_en" 
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center"/>
          <asp:TemplateField>
          <ItemTemplate> &nbsp; 
          <asp:ImageButton ID="ProvareaDelete" OnClientClick="javascript:return confirm('Do you want delete Provice?'); return false;"  ImageUrl="~/image/g_delete.gif" 
                CommandArgument='<%# Bind("prov_code") %>' OnCommand="Provarea_Delete"  runat="server"  alt="Delete" title="Delete" UseSubmitBehavior="false"  />
           </ItemTemplate>
          </asp:TemplateField>
        </Columns>
        </asp:GridView>
    

       
         
        <asp:HiddenField ID="hidProvince" runat="server" />
        <asp:Button ID="btnProv" runat="server" Text="Button" style="DISPLAY:none" />
        <asp:Button ID="btnProvClear" runat="server" Text="Button" style="DISPLAY:none" />

        </ContentTemplate>
     <Triggers>
     <asp:AsyncPostBackTrigger ControlID="btnProv" EventName="Click" />
     </Triggers>
     </asp:UpdatePanel>
     </center>
       </div>

   <div class="two wide field " align="left"  > 
    <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
 <asp:Panel ID="Paneladd" runat="server">
            <div class=" w3-text-purple mt-2 " onclick="document.getElementById('MainContent_btnProv').click();"> <i class="fa fa-2x fa-plus-circle" aria-hidden="true"></i></div>
                </asp:Panel>

                </ContentTemplate>
     <Triggers>
     <asp:AsyncPostBackTrigger ControlID="btnProv" EventName="Click" />
     </Triggers>
     </asp:UpdatePanel>
   </div>

 <div class="six wide field" style="font-family: 'Kanit', sans-serif;font-size: small;  margin-left:-11px; " align="left"  >

       <label for="Border" class="w3-left">Place to receive documents :  </label>
       
          
<asp:UpdatePanel id="updateddladmin" runat="server" UpdateMode="Conditional">
<ContentTemplate>

     <asp:DropDownList ID="ddladmin" Width="94%" runat="server" AutoPostBack="true" class="w3-input w3-border w3-round-large" > 
</asp:DropDownList>  
                <%--<asp:DropDownList ID="ddladmin" Width="94%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddladmin_selectedindexchanged" class="w3-input w3-border w3-round-large" > 
            </asp:DropDownList>--%>  
 
             
            <asp:Button style="DISPLAY: none" id="btnSetValueddladmin" UseSubmitBehavior="false" runat="server" Text="Button" />
        <asp:HiddenField ID="HidValueddladmin" runat="server" />

            </ContentTemplate>
    <Triggers>
       
    </Triggers>
</asp:UpdatePanel>
</div>

    <div class="three wide field"  align="left"> 
           <asp:HyperLink ID="lnkSchMap" runat="server" class="w3-purple w3-btn w3-round-large w3-medium" style=" margin-top: 10px;" ><i class="fa fa-map-marker" aria-hidden="true" ></i> ค้นหา </asp:HyperLink>
        </div>
 </div>      

                <label for="name" class="w3-left" style="display:none">Number of Car : </label>
             <%--<asp:TextBox ID="txtcntpeople" type="text" class="w3-input w3-border w3-round-large" runat="server" placeholder="Number of people" ></asp:TextBox>--%>
             <asp:TextBox ID="txtcntpeople" style="display:none;" type="number" class="w3-input w3-border w3-round-large" runat="server" placeholder="Number of Car" ></asp:TextBox>
            
  

  

   <br />
   <center>
   <div class="fields" style="margin-top:2rem;" >
   <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
  <%-- &nbsp; &nbsp; &nbsp;--%>
 </div>
 <div class="seven wide field"  id="divMap"  >
<%--   <div class="two wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
   &nbsp; &nbsp; &nbsp;
 </div>--%>
            <iframe runat="server" id="iframeMap" enableviewstate="true" frameborder="0"  style="width:380px; height:280px;"  name="IframeLocation" scrolling="yes" 
          src="../Map/MapArea.aspx?pro=-1" >Your browser does not support iframes 
    </iframe>

</div>
    </div>
</center>
   

   
      <div class="fields" style="margin-top:2rem;" id="divExtension" runat="server" visible="false">
<div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;" >
        </div>
        <div class=" six wide field" style="font-family: 'Kanit', sans-serif;font-size: small;" align="left">
        
        <label for="area" class="w3-left"> Reason for Extension :  </label>
        <asp:TextBox ID="txtReason"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Reason for Extension" TextMode="MultiLine" ></asp:TextBox>
        </div>
         <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
        <div class=" five wide field" style="font-family: 'Kanit', sans-serif;font-size: small;" align="left">

        <label for="area" class="w3-left"> Attachments :  </label>

                <asp:UpdatePanel ID="UpdFileAttach" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
           <div style="font-family: 'Kanit', sans-serif;font-size: small;">
          <asp:FileUpload ID="FileUploadAttach" runat="server" onchange="document.getElementById('MainContent_btnUploadAttach').click();" />
           
            <asp:ImageButton ID="btnUploadAttach" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
            <asp:ImageButton ID="btnloadAttach" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidFNameAttach" runat="server" />
                <asp:HiddenField ID="hidSNameAttach" runat="server" />
                <asp:HiddenField ID="hidfolderAttach" runat="server" />

           
             </div>
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger  ControlID="btnUploadAttach"/>
	          </Triggers>
           </asp:UpdatePanel>


   </div>

   <div class=" three wide field" align="left" style="font-family: 'Kanit', sans-serif;font-size: small; vertical-align:bottom; ">
   <br /><br />
   <asp:Label ID="lblErrorAttach" runat="server" ForeColor="Red"></asp:Label>
   <asp:HyperLink ID="hlFileAttach" runat="server" Cssclass="btn-link"></asp:HyperLink>
             <asp:ImageButton ID="btnDelAttach"  OnClientClick="javascript:return confirm('Do you want delete file?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
   </div>

      </div>    
        
        <script language="javascript" type="text/javascript">
            function setFocusPage(_divName) {
                var PageAutoSec = 500;
                setTimeout(function () {
                    document.location.href = '#' + _divName;
                }, PageAutoSec);
            }
        </script>

<div class="row">

 <div class="two wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
   &nbsp; &nbsp; &nbsp;
 </div>
 <%--<div class="ten wide column"  id="divMap"  >
   <div class="two wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
   &nbsp; &nbsp; &nbsp;
 </div>
            <iframe runat="server" id="iframeMap" enableviewstate="true" frameborder="0"  style="width:400px; height:300px;" name="IframeLocation" scrolling="yes" 
          src="../Map/MapArea.aspx?pro=-1" >Your browser does not support iframes 
    </iframe>

    
</div>--%>  
</div>

 

  <script  type='text/javascript'>
      var mapProlist = [];
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
              iFrame.style.width = (dv * 0.8) + 'px';
              iFrame.style.height = (dv * 0.8) + 'px';
          }
          else {
              var iFrame = document.getElementById("MainContent_iframeMap");
              iFrame.style.width = (dv * 1.7) + 'px';
              iFrame.style.height = (dv * 1.18) + 'px';
          }




      });

      function get_IframeMaps(pro) {
          document.getElementById('MainContent_iframeMap').src = '../Map/MapArea.aspx?pro=' + pro;
      }

      function get_IframeMap(pro) {
          document.getElementById('MainContent_iframeMap').src = document.getElementById('MainContent_iframeMap').src + ',' + pro;
          console.log('getiframemap',pro)
          console.log(document.getElementById('MainContent_iframeMap').src);
      }

      function get_IframeMapDel(pro) {
          document.getElementById('MainContent_iframeMap').src = document.getElementById('MainContent_iframeMap').src.replace("," + pro, "");
          console.log(document.getElementById('MainContent_iframeMap').src);
      }

      function get_IframeMapDelAll(pro) {
          document.getElementById('MainContent_iframeMap').src = pro
          console.log(document.getElementById('MainContent_iframeMap').src);
      }
  </script>
    




</asp:Panel>


     </br>
      <asp:Button ID="btnCancel"  class=" w3-purple w3-btn w3-round-large w3-left w3-large"   runat="server" UseSubmitBehavior="false" Text="Cancel" /> &nbsp; &nbsp;&nbsp;
       <asp:Button ID="btnNext2"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Next" />

<%--</asp:Panel>--%>

</div>
     
</div>

<script type="text/javascript">
    window.tab_activeIframe = function (_tab) {
        if (_tab == 0) {
            var href = window.location.href.split('?')[0].toLowerCase().replace("groupadd.aspx", "group.aspx");
            window.location.href = href;
        }
        else if (_tab == 1) {
            LoadPageNew();
        }
        else if (_tab == 2) {
            tab2();
        }
        else if (_tab == 3) {
            tab3();
        }
    }

    window.tab_Redirect = function (_href) {
        var href = window.location.href.split('?')[0].toLowerCase().replace("groupadd.aspx", _href);
        window.location.href = href;
    }

    function LoadPageNew() {
        // ต้องโหลดใหม่ไม่งั้นแผนที่ไม่ขึ้น!!!
        var href = window.location.href;
        window.location.href = href;
    }

    function closeIFrame() {
        window.open(window.location, '_self').close();
    }
</script>

<div id="form2" class="w3-animate-right fill center ui-form w3-margin text-dark ">

<%--เปลี่ยนไปใช้ iframe เรียกที่เดียวกับหน้า GroupEdit.aspx น่ะ--%>
<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif; " >
<iframe runat="server" id="Iframe2" enableviewstate="true" frameborder="0" class="w3-theme-l5"
            name="Iframe1" scrolling="no"   width="100%"  src=""  
            style="background-color: transparent; height: 780px;" >Your browser does not support iframes 
        </iframe>
</div>

<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif; DISPLAY: none;" >

<asp:Panel ID="Page2" runat="server">
<div class="fields" style="margin-top:2rem;">
         <div class=" four wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Car : </label>
                <asp:DropDownList id="ddlLicense" runat="server" class="w3-input w3-border w3-round-large " AutoPostBack="true" AppendDataBoundItems="True" > 
                              </asp:DropDownList> 
        </div>
         <div class=" three wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <label for="Surname" class="w3-left">Type : </label> <br /> 
             <asp:Label class="w3-left toplabel" ID="lblType" runat="server" Text="-"></asp:Label>
         </div>
         <div class=" two wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <label for="Surname" class="w3-left">Driver : </label><br /> 
            <asp:Label class="w3-left toplabel" ID="lblDriver" runat="server" Text="-"></asp:Label>
         </div>
        <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small; padding-top:20px; ">
        <asp:Button ID="BtnAddLicense"  class=" w3-purple w3-btn w3-round-large  w3-right-align w3-large"  OnClientClick="$('#loadings').show();"     runat="server" UseSubmitBehavior="false" Text="Add" /> 
   </div>
 </div>

 <div class="fields" style="margin-top:2rem;">

  <div class=" twelve wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">

 <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="false" Width="100%" EmptyDataText="No data" 
            EmptyDataRowStyle-HorizontalAlign="Center"  
            CssClass="table table-striped table-bordered table-center table-hover " >
        
         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                          <asp:Label id="lblgid" runat="server" Text='<%# eval("gid") %>'></asp:Label>
                                          <asp:Label id="lbllicense_id" runat="server" Text='<%# eval("license_id") %>'></asp:Label>
                                          <asp:Label id="lblstart_date" runat="server" Text='<%# eval("start_date") %>'></asp:Label>
                                          <asp:Label id="lblexp_date" runat="server" Text='<%# eval("exp_date") %>'></asp:Label>
                                          <asp:Label id="lblis_renew" runat="server" Text='<%# eval("is_renew") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" HeaderText="<center>No.</center>" 
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center" >

             <ItemStyle HorizontalAlign="Center" Width="50px" />
             </asp:BoundField>

              <asp:BoundField DataField="plate" HeaderText="<center>plate</center>" HtmlEncode="False" ItemStyle-Width="80px" />
              <asp:BoundField DataField="country_car" HeaderText="<center>Country of registration</center>" HtmlEncode="False" ItemStyle-Width="21%"/>
              <asp:BoundField DataField="type_name" HeaderText="<center>Type</center>" HtmlEncode="False"/>
              <asp:BoundField DataField="driver_name" HeaderText="<center>Driver</center>" HtmlEncode="False"/>
             
              <asp:TemplateField HeaderText="<center>Status </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                           <asp:Label id="Labelstatus" runat="server" ForeColor="#006600" Font-Size="14px"><i class="fa fa-check"></i></asp:Label>
                                          <asp:HiddenField ID="Hidstatus" Value='<%# eval("status") %>' runat="server" />
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>เปลี่ยน<br>คนขับ </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         
               <asp:HyperLink ID="HyperEdit" NavigateUrl='<%# Bind("urlEdit") %>' Target="_self" runat="server" ToolTip="Edit Data" ><i class="fa fa-edit " ></i></asp:HyperLink>
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />

              </asp:TemplateField>

              <asp:TemplateField HeaderText="<center> Insurance </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         
               <asp:HyperLink ID="HyperInsurance" NavigateUrl='<%# Bind("urlIns") %>' Target="_self" runat="server" ToolTip="Edit Data" ><i class="fa fa-edit " ></i></asp:HyperLink>
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />

              </asp:TemplateField>
              <asp:TemplateField HeaderText="<center>Delete </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLinkDel" NavigateUrl="#" runat="server" ><img src="../image/g_delete.gif" ></asp:HyperLink>
              
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>
         </Columns>
          <EmptyDataRowStyle HorizontalAlign="Center" />
          <%--<PagerTemplate>
          <div class="w3-row w3-padding-small"> 
                      
            <div class="col ">
             <div  class="w3-right"> 

               <asp:LinkButton ID="btnLast" runat="server" CommandArgument="Last" CommandName="Page"  class="w3-right btn w3-button w3-padding-small w3-round w3-large" >Last</asp:LinkButton>
              <asp:LinkButton ID="btnNext" runat="server" CommandArgument="Next" CommandName="Page" class="w3-right btn w3-button w3-padding-small w3-round w3-large" >Next</asp:LinkButton> 
  
             
              
                <asp:LinkButton ID="btnPrev" class="w3-right btn w3-button w3-padding-small w3-round w3-large" runat="server" CommandArgument="Prev" CommandName="Page" >Prev</asp:LinkButton>
             

             
               <asp:LinkButton ID="btnFirst" class="w3-right btn w3-button w3-padding-small w3-round w3-large" runat="server" CommandArgument="First" CommandName="Page" >First </asp:LinkButton>
              
            </div> 
               

               <div class="w3-left"> 
              <p class="w3-left w3-padding-small"> Page   
             </p>

            <p class="w3-left"><asp:DropDownList ID="DDLPage" runat="server" class="w3-input w3-border w3-round-large"  AutoPostBack="true"  OnSelectedIndexChanged="DDLPage_SelectedIndexChanged" Style="position: static" >
                
                </asp:DropDownList>  
             </p>
             </div> 
            </div>
          </div>
        </PagerTemplate>--%>   
    </asp:GridView>
     <%--<p class="w3-left w3-padding "> Display  </p>
    <p class="w3-left "> <asp:DropDownList id="ddl_PageSize" runat="server" class="w3-input w3-border w3-round-large" Style="position: static"  AppendDataBoundItems="True" AutoPostBack="True"></asp:DropDownList>  </p>
    <p class="w3-left w3-padding "> Rows  </p>--%>
</ContentTemplate>
  </asp:UpdatePanel>

   
    </div>

  </div>


  <div class="fields" style="margin-top:2rem;"> 
  <div class=" five wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">

  <asp:Label id="NoteStatus" runat="server" ForeColor="Red" ><i class="fa fa-asterisk"></i></asp:Label> jiuweb Vehicle have duplicate group tour  
  </div>
  </div>

  </asp:Panel>
<br />
<asp:Button ID="btnNext3"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Next2" />
<asp:Button ID="btnPrev1" class="w3-purple w3-btn w3-round-large w3-left w3-large"  runat="server" UseSubmitBehavior="false" Text="Prev" />

</div>

</div>

<div id="form3" class="w3-animate-right fill center ui-form w3-margin text-dark ">

<%--เปลี่ยนไปใช้ iframe เรียกที่เดียวกับหน้า GroupEdit.aspx น่ะ--%>
<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif; " >
<iframe runat="server" id="Iframe3" enableviewstate="true" frameborder="0" class="w3-theme-l5"
            name="Iframe1" scrolling="no"   width="100%"  src=""  
            style="background-color: transparent; height: 980px;" >Your browser does not support iframes 
        </iframe>
</div>

<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif; DISPLAY: none;">

<asp:Panel ID="Page3" runat="server">
<div class="row" id="Guide1_row1" runat="server" >
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom: .21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 30px;font-size: x-large;margin-top: -35px;">
 Tour Leader <asp:Label ID="lblGuideNo1" runat="server" Text=""></asp:Label>
</b>
</div>

<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif;">
<div class="fields" style="margin-top:2rem;">
         <div class=" five wide field w3-margin" style="font-family: 'Kanit', sans-serif;font-size: small;" id="divGuide1" runat="server">
            <label for="Surname" class="w3-left">Guide : </label>
                <asp:DropDownList id="ddlGuide" runat="server" class="w3-input w3-border w3-round-large " AppendDataBoundItems="True" >
                                <%--<asp:ListItem Value="0">เลือกทั้งหมด</asp:ListItem> --%>
                              </asp:DropDownList> 
        </div>
        <%--</div>
        <div class="fields" style="margin-top:2rem;">--%>
        <div class=" five wide field w3-margin" style="font-family: 'Kanit', sans-serif;font-size: small;" id="divGuide2" runat="server">
            <label for="Surname" class="w3-left">Car Registration No. : </label>
                <asp:TextBox ID="txtregis_no" class="form-control font_txt" runat="server"></asp:TextBox> 
        </div>
        <%--</div>
        <div class="fields" style="margin-top:2rem;">--%>
        <div class=" five wide field w3-margin" style="font-family: 'Kanit', sans-serif;font-size: small;" id="divGuide3" runat="server">
            <label for="Surname" class="w3-left">Car Registration Photo : </label>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
           <div style="font-family: 'Kanit', sans-serif;font-size: small;">
          <asp:FileUpload ID="FileUpload5" runat="server" onchange="document.getElementById('MainContent_btnUploadAct').click();" />
            <asp:ImageButton ID="btnUploadAct" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoAct" runat="server" />

            <asp:Image ID="PhotoAct" runat="server"  CssClass="PhotoAct"/>
            <%--<asp:ImageButton ID="PhotoDeleteAct"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="~/image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" class="delete"/>--%>
             <asp:ImageButton ID="PhotoDeleteAct"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
             </div>
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger  ControlID="btnUploadAct"/>
	          </Triggers>
           </asp:UpdatePanel>
        </div>

     <%--    <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif;font-size: small;">
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
          
        </div>--%>
        <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small; padding-top:20px; " id="divGuide4" runat="server">
        <asp:Button ID="BtnAddGuide"  class=" w3-purple w3-btn w3-round-large w3-right-align w3-large"   runat="server" UseSubmitBehavior="false" Text="Add" /> 
   </div>
 </div>

 <div class="fields" style="margin-top:2rem;">

  <div class="  wide field  twelve" style="font-family: 'Kanit', sans-serif;font-size: small;">

 <asp:UpdatePanel ID="UpdGrid_guide" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:GridView ID="gvMain_guide" runat="server" AutoGenerateColumns="False" 
        AllowPaging="true" Width="100%" EmptyDataText="No data" 
            EmptyDataRowStyle-HorizontalAlign="Center"  
            CssClass="table table-striped table-bordered table-center table-hover " >
        
         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                          <asp:Label id="lblguide_id" runat="server" Text='<%# eval("guide_id") %>'></asp:Label>
                                          <asp:Label id="lblgid" runat="server" Text='<%# eval("gid") %>'></asp:Label>
                                          <asp:Label id="lblregis_photo" runat="server" Text='<%# eval("regis_photo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" HeaderText="<center>No.</center>" 
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center" >

             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

              <asp:BoundField DataField="guide_name" HeaderText="<center>Name</center>" HtmlEncode="False"/>
               <asp:BoundField DataField="guide_tel" HeaderText="<center>Telephone</center>" HtmlEncode="False"/>
               <asp:BoundField DataField="guide_idcard" HeaderText="<center>ID card</center>" HtmlEncode="False"/>
               <asp:BoundField DataField="regis_no" HeaderText="<center>Registration no</center>" HtmlEncode="False"/>

               <asp:TemplateField HeaderText="<center>Registration Photo </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Image ID="Imgregis" runat="server" Width="320px" ImageUrl="#" />
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>Status </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                           <asp:Label id="Labelstatus_guide" runat="server" ForeColor="#006600" Font-Size="14px"><i class="fa fa-check"></i></asp:Label>
                                          <asp:HiddenField ID="Hidstatus_guide" Value='<%# eval("status") %>' runat="server" />
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>Delete </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign=" right " >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLinkDel_guide" NavigateUrl="#" runat="server" ><img src="../image/g_delete.gif" ></asp:HyperLink>
              
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>
         </Columns>
          <EmptyDataRowStyle HorizontalAlign="Center" />
          <%--<PagerTemplate>
          <div class="w3-row w3-padding-small"> 
                      
            <div class="col ">
             <div  class="w3-right"> 

               <asp:LinkButton ID="btnLast" runat="server" CommandArgument="Last" CommandName="Page"  class="w3-right btn w3-button w3-padding-small w3-round w3-large" >Last</asp:LinkButton>
              <asp:LinkButton ID="btnNext" runat="server" CommandArgument="Next" CommandName="Page" class="w3-right btn w3-button w3-padding-small w3-round w3-large" >Next</asp:LinkButton> 
  
             
              
                <asp:LinkButton ID="btnPrev" class="w3-right btn w3-button w3-padding-small w3-round w3-large" runat="server" CommandArgument="Prev" CommandName="Page" >Prev</asp:LinkButton>
             

             
               <asp:LinkButton ID="btnFirst" class="w3-right btn w3-button w3-padding-small w3-round w3-large" runat="server" CommandArgument="First" CommandName="Page" >First </asp:LinkButton>
              
            </div> 
               

               <div class="w3-left"> 
              <p class="w3-left w3-padding-small"> Page   
             </p>

            <p class="w3-left"><asp:DropDownList ID="DDLPage" runat="server" class="w3-input w3-border w3-round-large"  AutoPostBack="true"  OnSelectedIndexChanged="DDLPage_SelectedIndexChanged" Style="position: static" >
                
                </asp:DropDownList>  
             </p>
             </div> 
            </div>
          </div>
        </PagerTemplate>   --%>
    </asp:GridView>
     <%--<p class="w3-left w3-padding "> Display  </p>
    <p class="w3-left "> <asp:DropDownList id="ddl_PageSize" runat="server" class="w3-input w3-border w3-round-large" Style="position: static"  AppendDataBoundItems="True" AutoPostBack="True"></asp:DropDownList>  </p>
    <p class="w3-left w3-padding "> Rows  </p>--%>
</ContentTemplate>
  </asp:UpdatePanel>

   
    </div>

  </div>


  <div class="fields" style="margin-top:2rem;"> 
  <div class=" five wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">

  <asp:Label id="NoteStatus_guide" runat="server" ForeColor="Red" ><i class="fa fa-asterisk"></i></asp:Label> This guide has been assigned to other group  
  </div>
  </div>
<br />

</div>

    <script type="text/javascript">
        function Submit() {
            alert('SUBMIT FUNCTION CALLED');
        $.confirm({
            title: 'Notification',
            content: "Once you have submitted the document, it cannot be modified again. Do you want to send it? ",
            buttons: {
                //submit: function () {
                //    $.alert("Confirm submit clicked");
                //    document.getElementById('MainContent_btnSubmit').click();


                //},
                submit: function () {
                    alert('CLICK CONFIRM');
                },
                cancel: function () {
                    //$.alert('Cancel');
                }
            }
        });
    }


      function AlertTravelExpire() {
        $.confirm({
            title: 'Notification',
            content: "Your license has expired. Please contact admin.",
            buttons: {
                OK: function () {
                    //Ver.1 By.ท๊อป มันไม่ไปจร้า หน้าที่ส่งไปก็ผิดหน้าอีก!!!
                   //window.location.replace("/Travel/Group.aspx");
                   var href = window.location.href.replace("GroupAdd.aspx", "EditUserTravel.aspx");
                   window.location.href = href;
                }
            }
        });
    }

    function AlertSubmit() { 
           $.alert({
            title: 'Alert!',
            content: "This guide has been assigned to other group",
            });
   
    }

    function AlertSubmit2() { 
           $.alert({
            title: 'Alert!',
            content: "Please add guide !!!!",
            });
   
    }


    </script>
     </asp:Panel>
 </br>
    
</div>
   <button class=" w3-center w3-purple w3-btn w3-round-large w3-large w3-margin" onclick ="Submit();return false;" UseSubmitBehavior=false>Submit1 </Button>
  <asp:Button ID="btnSubmit"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large w3-margin" style="display:none"   runat="server" UseSubmitBehavior="false" Text="Save3" /> &nbsp; &nbsp;&nbsp;
  <asp:Button ID="btnSave"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large w3-margin"   runat="server" UseSubmitBehavior="false" Text="Save2" /> &nbsp; &nbsp;&nbsp;
<asp:Button ID="btnPrev2" class="w3-purple w3-btn w3-round-large w3-left w3-large w3-margin"  runat="server" UseSubmitBehavior="false" Text="Prev" />
</div>
         


</form>

</div> 



</div>



<script  type='text/javascript'>




</script>

<asp:Panel ID="PnDelete" style="DISPLAY: none" runat="server" >
    <asp:Button style="DISPLAY: none" id="BtnDelete" runat="server" UseSubmitBehavior="false" ></asp:Button> 
    <asp:Button style="DISPLAY: none" id="BtnDelete_guide" runat="server" UseSubmitBehavior="false" ></asp:Button>
      <asp:Button style="DISPLAY: none" id="BtnBorderCheck" runat="server" UseSubmitBehavior="false" ></asp:Button> 
       <asp:Button style="DISPLAY: none" id="BtnBorderCheckOut" runat="server" UseSubmitBehavior="false" ></asp:Button> 
     <asp:HiddenField id="checkerr" runat="server"></asp:HiddenField>  
    <asp:HiddenField id="HidDel_ID" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="Hidstatus"  runat="server" />
    <asp:HiddenField ID="Hidchecktab_0"  runat="server" />
    <asp:HiddenField ID="Hidchecktab_1"  runat="server" />
    <asp:HiddenField ID="Hidchecktab_2"  runat="server" />
    <asp:HiddenField ID="Hidchecktab_3"  runat="server" />
    <asp:HiddenField ID="Hidchecktab_4"  runat="server" />
    <asp:HiddenField ID="Hidchecktab_8"  runat="server" />
     <asp:HiddenField id="HidDelGuide_id" runat="server"></asp:HiddenField> 
</asp:Panel>

<script type='text/javascript'>



    function DelData(license_id) {
        var Msg = 'Do you want delete data ?';
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            document.getElementById('MainContent_HidDel_ID').value = license_id;
            document.getElementById('MainContent_BtnDelete').click();
        } else {
            return false;
        }
    }

    function DelData2(guide_id) {
        var Msg = 'Do you want delete data ?';
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            document.getElementById('MainContent_HidDelGuide_id').value = guide_id;
            document.getElementById('MainContent_BtnDelete_guide').click();
        } else {
            return false;
        }
    }




</script>
</asp:Content>

