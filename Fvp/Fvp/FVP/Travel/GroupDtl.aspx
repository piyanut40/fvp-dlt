<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageC.master" AutoEventWireup="false" CodeFile="GroupDtl.aspx.vb" Inherits="Travel_GroupDtl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />

<style>
.fontKanit
{ font-family: 'Kanit', sans-serif;
  
}
.hr1 { 
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
}

 
</style>
<header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
   <a   style="margin-left:0%"><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">Tour Group Detail</b></a>
</header>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<div id="formT1" runat="server">
<div id="divCompany" runat="server">
  <div class="conta">

   <p class="w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-address-card-o" aria-hidden="true"></i>  Tour Group </b></p>
      <div class="w3-row w3-padding-small">

      <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Group Name :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblgroup_name" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>"  >
    
    </div>

  </div>



  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Border Crossing Checkin : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        
        <asp:Label ID="lblCheckin" runat="server" Text=""></asp:Label>
    </div>
 <div class="w3-col l2 <% Response.Write(Css)%>" >
       Start Date  :  
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblStart" runat="server" Text=""></asp:Label>
     </div>
  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Border Crossing Checkout : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        
        <asp:Label ID="lblCheckout" runat="server" Text=""></asp:Label>
    </div>
 
     <div class="w3-col l2 <% Response.Write(Css)%>" >
      End date : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblExpire" runat="server" Text=""></asp:Label>
     </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
      Place to receive documents :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lbladmin_name" runat="server" Text=""></asp:Label>

    </div>
 <div class="w3-col l2 <% Response.Write(Css)%>" >
       Travel Itinerary :
     </div>
      
       <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="lnkTravel_Itinerary" CssClass="w3-text-purple"  runat="server">View file</asp:HyperLink>
             <asp:HiddenField ID="hidSTravel_Itinerary" runat="server" />
             <asp:HiddenField ID="hidFTravel_Itinerary" runat="server" />
    </div>
  </div>

  
  <div class="w3-row w3-padding-small" id="divRefer" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
     Refer Group :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
      <asp:HyperLink ID="hyperlinkRefer" Target="_blank" runat="server" ><i class="fa fa-file " aria-hidden="true"></i></asp:HyperLink>
    </div>
 <div class="w3-col l2 <% Response.Write(Css)%>" >
      
     </div>
      
    
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
              iFrame.style.width = (dv * 0.8) + 'px';
              iFrame.style.height = (dv * 0.8) + 'px';
          }
          else {
              var iFrame = document.getElementById("MainContent_iframeMap");
              iFrame.style.width = (dv * 2.0) + 'px';
              iFrame.style.height = (dv * 1.2) + 'px';
          }




      });

      function get_IframeMaps(pro) {
          document.getElementById('MainContent_iframeMap').src = '../Map/MapArea.aspx?pro=' + pro;
      }

      function get_IframeMap(pro) {
          document.getElementById('MainContent_iframeMap').src = document.getElementById('MainContent_iframeMap').src + ',' + pro;
          console.log(pro)
          console.log(document.getElementById('MainContent_iframeMap').src);
      }

      function get_IframeMapDel(pro) {
          document.getElementById('MainContent_iframeMap').src = document.getElementById('MainContent_iframeMap').src.replace("," + pro, "");
          console.log(document.getElementById('MainContent_iframeMap').src);
      }
    </script>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Province use vehicle : 
     </div>
      
    <div class="w3-col l2_3 w3-padding-top <% Response.Write(Css_Ctrl)%>"   id="divMap" >
        <iframe runat="server" id="iframeMap" enableviewstate="true" frameborder="0"  style="width:400px; height:300px;" name="IframeLocation" scrolling="yes" 
          src="../Map/MapArea.aspx?pro=-1" >Your browser does not support iframes 
    </iframe>


    </div>


    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    
     </div>
  
  </div>


  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
         
          <asp:Label ID="lblprov_en"  runat="server" Text="-"></asp:Label>
           <asp:GridView ID="gvProv" runat="server" GridLines="None" AutoGenerateColumns="false"  style="display:none" >
        <Columns>
          <asp:TemplateField>
          <ItemTemplate>
                <asp:Label ID="lblarea_id" runat="server" style="display:none" Text="<%# Bind('area_id') %>"></asp:Label>
                <asp:Label ID="lblprov_code" runat="server" style="display:none" Text="<%# Bind('prov_code') %>"></asp:Label>
              <asp:Label ID="lblprov_en"  runat="server" Text="<%# Bind('prov_en') %>"></asp:Label>
                
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
        </asp:GridView>

    </div>
    </div>

 </div>
 </div><br />

  <div class="conta">

   <p class="w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-address-card-o" aria-hidden="true"></i>  Car </b></p>
      <div class="w3-row w3-padding-small">

      <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Number of Car :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:Label ID="lblcnt_car" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>"  >
    
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l1 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l10 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        
        <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="No data" 
            EmptyDataRowStyle-HorizontalAlign="Center"  
            CssClass="table table-striped table-bordered table-center table-hover " >
        
         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                          <asp:Label id="lblgid" runat="server" Text='<%# eval("gid") %>'></asp:Label>
                                          <asp:Label id="lbllicense_id" runat="server" Text='<%# eval("license_id") %>'></asp:Label>
                                          <asp:Label id="lblstart_date" runat="server" Text='<%# eval("start_date") %>'></asp:Label>
                                          <asp:Label id="lblexp_date" runat="server" Text='<%# eval("exp_date") %>'></asp:Label>
                                          <asp:Label id="lbltoken" runat="server" Text='<%# eval("token") %>'></asp:Label>
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

               <asp:TemplateField HeaderText="<center>View </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperDoc" NavigateUrl="#" Target="_parent" runat="server" ><i class="fa fa-file " aria-hidden="true"></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>Delete </center>" ItemStyle-Width="80px" Visible="false" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLinkDel" NavigateUrl="#" runat="server" ><img src="../image/g_delete.gif" ></asp:HyperLink>
              
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>
         </Columns>
          <EmptyDataRowStyle HorizontalAlign="Center" />
              
    </asp:GridView>
      
</ContentTemplate>
  </asp:UpdatePanel>
  <br />
  <asp:Label id="NoteStatus" runat="server" ForeColor="Red" ><i class="fa fa-asterisk"></i></asp:Label> Vehicle have duplicate group tour  
    </div>
     
       

  </div>

   


 </div>
 </div><br />

 <div class="conta">

   <p class="w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-address-card-o" aria-hidden="true"></i>  Tour Guide </b></p>
      <div class="w3-row w3-padding-small">

      <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Number of Guide :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        
        <asp:Label ID="lblcnt_guide" runat="server" Text=""></asp:Label>
    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>"  >
    
    </div>

  </div>


  <div class="w3-row w3-padding-small">

    <div class="w3-col l1 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l10 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        
        <asp:UpdatePanel ID="UpdGrid_guide" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:GridView ID="gvMain_guide" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="No data" 
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
               <asp:BoundField DataField="guide_tel"  HeaderText="<center>Telephone</center>" HtmlEncode="False"/>
               <asp:BoundField DataField="guide_idcard" HeaderText="<center>ID card</center>" HtmlEncode="False"/>
               <asp:BoundField DataField="regis_no" HeaderText="<center>Car Registration No.</center>" HtmlEncode="False"/>

               <asp:TemplateField HeaderText="<center>Car Registration Photo </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Image ID="Imgregis" runat="server" Width="300px" ImageUrl="#" />
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

               <asp:TemplateField HeaderText="<center>View </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperDoc" NavigateUrl="#" Target="_parent" runat="server" ><i class="fa fa-file " aria-hidden="true"></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>Delete </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"  Visible="false" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLinkDel_guide" NavigateUrl="#" runat="server" ><img src="../image/g_delete.gif" ></asp:HyperLink>
              
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>
         </Columns>
          <EmptyDataRowStyle HorizontalAlign="Center" />
              
    </asp:GridView>
     
</ContentTemplate>
  </asp:UpdatePanel>
     
    </div>
     
       

  </div>

 </div>
 </div><br />
</div>
</div>


    <asp:HiddenField id="checkerr" runat="server"></asp:HiddenField>  
 
</asp:Content>

