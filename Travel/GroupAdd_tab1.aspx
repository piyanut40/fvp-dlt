<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GroupAdd_tab1.aspx.vb" Inherits="Travel_GroupAdd_tab1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
</head>
<body class="w3-theme-l5">
   


    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField id="HidExpDate" runat="server"></asp:HiddenField>
    <%--<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative w3-text-deep-purple w3-card-2 w3-round-large w3-theme-l5 w3-row-padding"> --%>

    <div id="Div1" class="w3-animate-right fill center ui-form w3-margin text-dark  ">


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
          <asp:FileUpload ID="FileUploadPDF" runat="server" onchange="document.getElementById('btnUploadPDF').click();" />
           
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



<center>
     <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
         <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%" Height="158px" >
<asp:GridView ID="gvProv" runat="server" GridLines="None" AutoGenerateColumns="false">
        <Columns>
          <asp:TemplateField Visible="false">
          <ItemTemplate>
                <asp:Label ID="lblarea_id" runat="server"  Text="<%# Bind('area_id') %>"></asp:Label>
                <asp:Label id="lblprov_code" runat="server" Text='<%# eval("prov_code") %>'></asp:Label>
              <asp:Label ID="lblprov_en" runat="server" Text="<%# Bind('prov_en') %>"></asp:Label>
                
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
         </asp:Panel>
       
    

       
         
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
            <div class=" w3-text-purple mt-2 " onclick="document.getElementById('btnProv').click();"> <i class="fa fa-2x fa-plus-circle" aria-hidden="true"></i></div>
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

 
                <asp:DropDownList ID="ddladmin" Width="94%" runat="server" class="w3-input w3-border w3-round-large">   
            </asp:DropDownList>  
 
             
            <asp:Button style="DISPLAY: none" id="MainContent_btnSetValueddladmin" UseSubmitBehavior="false" runat="server" Text="Button" />
        <asp:HiddenField ID="MainContent_HidValueddladmin" runat="server" />

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
            
  

  

   <%--<br />--%>
   <center>
   <div class="fields" style="margin-top:2rem;" >
   <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
  <%-- &nbsp; &nbsp; &nbsp;--%>
 </div>
 <div class="seven wide field"  id="divMap"  >

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
          <asp:FileUpload ID="FileUploadAttach" runat="server" onchange="document.getElementById('btnUploadAttach').click();" />
           
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
    
</div>

 

  <script  type='text/javascript'>
      $(document).ready(function () {
          var dv = document.getElementById("divMap").offsetWidth;
         
          if (navigator.userAgent.match(/Android/i)
 || navigator.userAgent.match(/webOS/i)
 || navigator.userAgent.match(/iPhone/i)
 || navigator.userAgent.match(/iPad/i)
 || navigator.userAgent.match(/iPod/i)
 || navigator.userAgent.match(/BlackBerry/i)
 || navigator.userAgent.match(/Windows Phone/i)
 ) {
              var iFrame = document.getElementById("iframeMap");
              iFrame.style.width = (dv * 0.8) + 'px';
              iFrame.style.height = (dv * 1.5) + 'px';
          }
          else {
              var iFrame = document.getElementById("iframeMap");
              iFrame.style.width = (dv * 1.68) + 'px';
              iFrame.style.height = (dv * 1.1) + 'px';
          }




      });

      function get_IframeMaps(pro) {
          document.getElementById('iframeMap').src = '../Map/MapArea.aspx?pro=' + pro;
      }

      function get_IframeMap(pro) {
          document.getElementById('iframeMap').src = document.getElementById('iframeMap').src + ',' + pro;
          console.log(pro)
          console.log(document.getElementById('iframeMap').src);
      }

      function get_IframeMapDel(pro) {
          document.getElementById('iframeMap').src = document.getElementById('iframeMap').src.replace("," + pro, "");
          console.log(document.getElementById('iframeMap').src);
      }

      function get_IframeMapDelAll(pro) {
          document.getElementById('iframeMap').src = pro
          console.log(document.getElementById('iframeMap').src);
      }
    </script>




</asp:Panel>
</br>
 <asp:UpdatePanel ID="UpdButton" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:Button ID="btnCancel"  class=" w3-purple w3-btn w3-round-large w3-left w3-large"   runat="server" UseSubmitBehavior="false" Text="Cancel" /> &nbsp; &nbsp;&nbsp;
       <asp:Button ID="btnNext2"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Next" />
       </ContentTemplate>
  </asp:UpdatePanel>
<%--</asp:Panel>--%>

</div>
     


     <asp:Panel ID="PnDelete"  style="DISPLAY: none" runat="server" >
     
      <asp:Button   style="DISPLAY: none" id="BtnBorderCheck" runat="server" UseSubmitBehavior="false" ></asp:Button> 
       <asp:Button   style="DISPLAY: none"  id="BtnBorderCheckOut" runat="server" UseSubmitBehavior="false" ></asp:Button> 
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
</div>
<%--</div>--%>
    </div>


    <script type="text/javascript">

        var v = document.getElementById('<%= HidExpDate.ClientID %>').value;
        console.log(v);
       

        function checkddlProv() {
            $("#<%=ddlProvarea.ClientID %>").select2();
        }

        function checkddlBorder() {
            $("#<%=ddlBorderCheckin.ClientID %>").select2();
            $("#<%=ddlBorderCheckout.ClientID %>").select2();
        }


        function getDay() {

        var date = new Date();
        var dayname = date.toLocaleDateString('en-EN', { weekday: 'long' });
        var _Day;

         
        
        _Day = <% Response.Write(min_date)%>;
        return _Day;
    }

        $(document).ready(function () {
            $("#<%=ddlProvarea.ClientID %>").select2();
            $("#<%=ddlBorderCheckin.ClientID %>").select2();
            $("#<%=ddlBorderCheckout.ClientID %>").select2();
            $("#<%=ddladmin.ClientID %>").select2();
        });

     

        $(function () {
           
            var dateFormat = "dd/mm/yy";
            $("#<%=txtStart.ClientID %>").datepicker({

                changeMonth: true,
                changeYear: true,
                yearRange: "-5 :+20",
                setDate: new Date(),
                minDate: getDay(),
                
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




            function getDate(element) {
               
                var date;
                try {

                    date = $.datepicker.parseDate(dateFormat, element.value);
                    //                var date = new Date(element.value);
                } catch (error) {
                    date = null;
                }
                
                return date;
            }

            function EndgetDate(element) {

                date = $.datepicker.parseDate(dateFormat, element.value);
               
                return date;
            }

        });



 $(function () {
       
        $("#<%=txtExpire.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "now :+20",
            setDate: new Date(),
          
            minDate: $("#<%=HidStart.ClientID %>").val() == '' ? $("#<%=txtStart.ClientID %>").val() == '' ? getDay() : $("#<%=txtStart.ClientID %>").val() : getDaybyHid($("#<%=HidStart.ClientID %>").val()),
          
            maxDate: $("#<%=HidEnd.ClientID %>").val() == '' ? +40 : getDaybyHid($("#<%=HidEnd.ClientID %>").val()),
            showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtExpire.ClientID %>").keyup(function () {
            $("#<%=txtExpire.ClientID %>").val('');
        })
       
    });


        function AlertTravelExpire() {
            $.confirm({
                title: 'Notification',
                content: "Your license has expired. Please contact admin.",
                buttons: {
                    OK: function () {
                      
                        var href = window.location.href.replace("GroupAdd.aspx", "EditUserTravel.aspx");
                        window.location.href = href;
                    }
                }
            });
        }

    </script>

    </form>
    
</body>
</html>
