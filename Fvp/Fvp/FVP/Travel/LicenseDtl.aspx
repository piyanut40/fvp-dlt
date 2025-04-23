<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageC.master" AutoEventWireup="false" CodeFile="LicenseDtl.aspx.vb" Inherits="Travel_LicenseDtl" %>

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
.imageFilepassport{width:180px;}
 
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
.imageFilepassport{width:120px;}
    
}
 @media screen and (min-width: 360px) and (max-width:376px) and (orientation : portrait)
{
     
     .imageFilepassport{width:120px;}
     
}
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
 {
    .imageFilepassport{width:120px;}
  
  }
</style>
<header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
   <a   style="margin-left:0%"><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;"><% Response.Write(text)%></b></a>
</header>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<div id="formT1" runat="server">
<div id="divCompany" runat="server">
<div class="conta"> 
<div class="w3-row w3-padding-small">

 <p class="w3-purple2 w3-padding w3-large fontKanit"><b><i class="fa fa-address-card-o" aria-hidden="true"></i> Travel Agency</b></p>
</div>

<div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Agency name : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcom_name" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Name  :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblagen_name" runat="server" Text=""></asp:Label>

    </div>

  </div>

  

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Telephone  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcom_tel" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        E-mail :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblcom_mail" runat="server" Text=""></asp:Label>

    </div>

  </div>

    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        License Agency Travel : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcompany_license" runat="server" Text=""></asp:Label>

    </div>
     
 <%--     <div class="w3-col l2 <% Response.Write(Css)%>" >
        E-mail :
     </div>
      
    <div class="w3-col l3 w3-padding-top">
     <asp:Label ID="Label3" runat="server" Text=""></asp:Label>

    </div>--%>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Address  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcom_address" runat="server" Text=""></asp:Label>

    </div>
     


  </div>
  </div>
  <br />
  <div class="conta">

   <p class="w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-address-card-o" aria-hidden="true"></i>  Tour Group </b></p>
      <div class="w3-row w3-padding-small">

      <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Group Name  : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblgroupname" runat="server" Text=""></asp:Label>

    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
       Number of Car : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcountcar" runat="server" Text=""></asp:Label>

    </div>
     
      
      </div>
      



       <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Start Date  : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblstartdategroup" runat="server" Text=""></asp:Label>

    </div>
 
     
  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Expiry Date  : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblexpdategroup" runat="server" Text=""></asp:Label>

    </div>
 
     
  </div>


  <div class="w3-row w3-padding-small">
  <div class="w3-col l2_2 <% Response.Write(Css)%>" style="DISPLAY: none" >
       Guide  :
     </div>
      <%--</div>
  <div class="w3-row w3-padding-small">--%>
    

  </div>

 </div>
 </div><br />

 <div class="conta">

   <p class="w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-address-card-o" aria-hidden="true"></i>  Tour Leader </b></p>

   <div class="w3-row w3-padding-small">
   <div class="w3-col l2_2 <% Response.Write(Css)%>"   >
    </div>
   <div class="w3-col l6 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <%--''Ver.1 by.ท๊อป--%>
       <%--<asp:GridView ID="gvguide" ShowHeader="false" GridLines="None" runat="server" AutoGenerateColumns="false" CellSpacing="0" CellPadding="0" >
        <Columns>
          <asp:TemplateField>
          <ItemTemplate>
             <label>Name :</label> <asp:Label ID="lblnameguide" runat="server" Text= "<%# Bind('nameguide') %>"></asp:Label> 
              <br> </br>
              <label>Registration No :</label> <asp:Label ID="lblregis_no" runat="server" Text=" <%# Bind('regis_no') %>"></asp:Label>
              <br></br>
              <label>License Photo :</label> <asp:Image runat="server" ID="imgRegis" ImageUrl="<%# Bind('regis_photo') %>" Height="100px" Width="100px" />
              <asp:HyperLink ID="HyperLicensePhotoGuide" NavigateUrl="<%# Bind('regis_photo') %>" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
        </asp:GridView> --%>  
         
      <%--''Ver.2 copy มาจากหน้า GroupAdd.aspx เรย--%>
      <asp:GridView ID="gvguide2" runat="server" AutoGenerateColumns="False" 
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
               <asp:BoundField DataField="guide_tel" HeaderText="<center>Telephone</center>" Visible="false" HtmlEncode="False"/>
               <asp:BoundField DataField="guide_idcard" HeaderText="<center>ID card</center>" Visible="false" HtmlEncode="False"/>
               <asp:BoundField DataField="regis_no" HeaderText="<center>Registration no</center>" HtmlEncode="False"/>

               <asp:TemplateField HeaderText="<center>Registration Photo </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Image ID="Imgregis" runat="server" Width="320px" ImageUrl="#" />
                                        <asp:HyperLink ID="HyperLicensePhotoGuide" NavigateUrl="<%# Bind('regis_photo') %>" Target="_blank"  runat="server">Big Picture</asp:HyperLink>
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>

             
         </Columns>
          <EmptyDataRowStyle HorizontalAlign="Center" />
           
    </asp:GridView>
     
 
    </div>
    </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Note  : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcomments_tab0" runat="server" Text=""></asp:Label>

    </div>
 
     
  </div>

   </div><br />

</div>
</div>



<div class="conta">
<div class="w3-row w3-padding-small" id="divDriver" >

 <p class="w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-address-card-o" aria-hidden="true"></i> Driver</b></p>
</div>
    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Driver License No.<%--Driver ID Card No--%> : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblid_code" runat="server" Text=""></asp:Label>
      <%-- <asp:TextBox ID="txtid_code"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชน" ></asp:TextBox>--%>
    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Country  :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblcountry_driver" runat="server" Text=""></asp:Label>
         <%--<asp:DropDownList ID="ddlcountry_driver" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Passport No : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport" runat="server" Text=""></asp:Label>
      <%--  <asp:TextBox ID="txtpassport"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Passport Expiry Date : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblexp_pass_date" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtexp_pass_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small" id="divIMG_passport" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Passport Photo : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_passport" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table style="width: 225px;">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport" CssClass=" imageFilepassport " runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Passport Photo (Optional) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table style="width: 225px;">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport2" CssClass=" imageFilepassport " runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

 <%-- <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        คำนำหน้าชื่อ : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:RadioButtonList ID="rdoprename" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="Mr.">Mr.</asp:ListItem>
            <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
            <asp:ListItem Value="other">other</asp:ListItem>
        </asp:RadioButtonList>
    </div>

   <div class="w3-col l2 <% Response.Write(Css)%>" >
        อื่นๆ(ระบุ) :     
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtprename"  class="w3-input w3-border w3-round-large" runat="server" placeholder="คำนำหน้าชื่อ" ></asp:TextBox>
    </div>

  </div>--%>
     <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Name : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
      <%-- <asp:TextBox ID="txtname"   class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อ" ></asp:TextBox>--%>
    </div>
     
     <%-- <div class="w3-col l2 <% Response.Write(Css)%>" >
        นามสกุล :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtsurname" class="w3-input w3-border w3-round-large" runat="server" placeholder="นามสกุล" ></asp:TextBox>
    </div>--%>

  </div>

   <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Nationality  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnational" runat="server" Text=""></asp:Label>
      <%-- <asp:DropDownList ID="ddlnational" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Birth Date : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtdate" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small" style="DISPLAY: none">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Info : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label>
          <%--<asp:TextBox ID="txtinfo" TextMode="MultiLine" class="w3-input w3-border w3-round-large" runat="server" placeholder="ข้อมูลเกี่ยวกับกำหนดการต่างๆ เช่น สถานที่พัก กำหนดการในแต่ละวัน"></asp:TextBox>--%>
    </div>
     
   </div>


   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Gender  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblgender" runat="server" Text=""></asp:Label>
          <%--<asp:DropDownList ID="ddlgender" runat="server" class="w3-input w3-border w3-round-large"> 
               <asp:ListItem Value="M">Male</asp:ListItem>
               <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:DropDownList>--%>
    </div>

   
     
   </div>

    <div class="w3-row w3-padding-small">

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Driver License No : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtlicense_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Driver License Expiry Date : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblexp_license_no" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtexp_license_no" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

    </div>

    <div class="w3-row w3-padding-small" id="divIMG_license_no" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Driver License Photo : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_license_no" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no"  CssClass=" imageFilepassport" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Driver License Photo (Optional) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no2"  CssClass=" imageFilepassport" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

       <div class="w3-row w3-padding-small" id="div5" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Certified translation of driver license : 
     </div>

     <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="HyFileCer" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidFileCer" runat="server" />
    </div>
  </div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Address  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_driver" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtaddress_driver"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

</div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Telephone   : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_driver" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txttel_driver" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>--%>
    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        E-mail : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblemail_driver" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtemail_driver" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>--%>
    </div>
  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Note  : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcomments_tab2" runat="server" Text=""></asp:Label>

    </div>
 
     
  </div>

   </div>
  <%--<div class="w3-row w3-padding-small m-5">
  <center>

    <asp:LinkButton ID="lnkNext1" class="w3-button w3-blue2 w3-padding w3-round" runat="server">Next <i class="fa fa-forward" aria-hidden="true"></i></asp:LinkButton>

  </center>

  </div>--%>

  <%--<div class="w3-row w3-padding-small">

 <h5 class="w3-gray w3-padding"><b> # ข้อมูลคนขับสำรอง</b></h5>
</div>--%>

<div class="conta" id="reserve1" runat=server  >
    <%--<h5 class="fontKanit w3-large w3-padding-left"><b>Reserve Driver 1 </b></h5>--%>
       <a class="w3-large w3-padding-left"><b class="fontKanit">Reserve Driver 1</b></a>
    <hr style="width: 140px;" />

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Name : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblname1" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtname1"   class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อ" ></asp:TextBox>--%>
    </div>
     
      <%--<div class="w3-col l2 <% Response.Write(Css)%>" >
        นามสกุล :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtsurname1" class="w3-input w3-border w3-round-large" runat="server" placeholder="นามสกุล" ></asp:TextBox>
    </div>--%>

  </div>

   <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Nationality  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnational1" runat="server" Text=""></asp:Label>
      <%-- <asp:DropDownList ID="ddlnational1" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>--%>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Gender :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblgender1" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Driver License No :  
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_no1" runat="server" Text=""></asp:Label>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Driver License Expiry Date :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_exp_date_1" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small"  >

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Passport No. : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport1" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpassport1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Passport Expiry Date : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport_expire_1" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtexp_pass_date1" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Address :  
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_1" runat="server" Text=""></asp:Label>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Telephone :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_1" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       E-mail :  
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblemail_1" runat="server" Text=""></asp:Label>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     
    </div>


  </div>

    <div class="w3-row w3-padding-small" id="div1" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Passport Photo : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport_1" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport_1" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

        <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Passport Photo (Optional) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport_1_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport_1_2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>


    <div class="w3-row w3-padding-small" id="div2" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Driver License Photo : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no_1" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no_1" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Driver License Photo (Optional) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no_1_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no_1_2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

  <div class="w3-row w3-padding-small" id="div6" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Certified translation of driver license : 
     </div>

     <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="HyFileCer2" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidFileCer2" runat="server" />
    </div>
  </div>
    <br />
  </div>
 
   <br />
  <div class="conta" id="reserve2" runat=server >
    <br />
    <%--<h5 class="fontKanit w3-large w3-padding-left"><b>Reserve Driver 2 </b></h5>--%>
       <a class="w3-large w3-padding-left"><b class="fontKanit">Reserve Driver 2 </b></a>
    <hr style="width: 140px;" />

 <%-- <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        คำนำหน้าชื่อ : 
     </div>
      
    <div class="w3-col l3 ">

        <asp:RadioButtonList ID="rdoprename2" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="Mr.">Mr.</asp:ListItem>
            <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
            <asp:ListItem Value="other">other</asp:ListItem>
        </asp:RadioButtonList>
    </div>

   <div class="w3-col l2 <% Response.Write(Css)%>" >
        อื่นๆ(ระบุ) :     
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtprename2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="คำนำหน้าชื่อ" ></asp:TextBox>
    </div>

  </div>--%>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Name : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblname2" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtname2"   class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อ" ></asp:TextBox>--%>
    </div>
     
      <%--<div class="w3-col l2 <% Response.Write(Css)%>" >
        นามสกุล :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtsurname2" class="w3-input w3-border w3-round-large" runat="server" placeholder="นามสกุล" ></asp:TextBox>
    </div>--%>

  </div>

   <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Nationality  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnational2" runat="server" Text=""></asp:Label>
       <%--<asp:DropDownList ID="ddlnational2" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>--%>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Gender : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblgender2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtlicense_no2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small"  >

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Driver License No : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_no2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpassport2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Driver License Expiry Date : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_exp_date_2" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtexp_pass_date2" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small"  >

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Passport No : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpassport2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Passport Expiry Date : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport_expire_2" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtexp_pass_date2" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Address  :  
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_2" runat="server" Text=""></asp:Label>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Telephone :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_2" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       E-mail :  
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblemail_2" runat="server" Text=""></asp:Label>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     
    </div>


  </div>

    <div class="w3-row w3-padding-small" id="div3" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Passport Photo : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport_2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Passport Photo (Optional) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport_2_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport_2_2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>


    <div class="w3-row w3-padding-small" id="div4" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Driver License Photo : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no_2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Driver License Photo (Optional) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no_2_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no_2_2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

  <div class="w3-row w3-padding-small" id="div7" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Certified translation of driver license : 
     </div>

     <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

              <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="HyFileCer3" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidFileCer3" runat="server" />
    </div>
  </div>
    <br />
  </div>
     <br />



  <div id="divCar" runat="server" >
  <div class="conta"  >
  <div class="w3-row w3-padding-small">

 <p class="fontKanit w3-purple2 w3-padding w3-large fontKanit"><b class="fontKanit"><i class="fa fa-car" aria-hidden="true"></i>  Vehicle</b></p>
</div>

    <div class="w3-row w3-padding-small" id="divIMG_car" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Vehicle Photos : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_car" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <asp:DataList ID="DtlImg_car" runat="server" CellPadding="4" 
                    DataKeyField="gid" ForeColor="#333333" Width="100%"
                            RepeatDirection="Horizontal">
                    
                    <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                           <ItemTemplate>
                               <table  style="width: 225px; height: 150px;">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile" CssClass=" imageFilepassport" runat="server" ImageUrl='<%# Bind("PathImg") %>' /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("LinkImg") %>' Target="_blank" Text='<%# Bind("imgtype") %>' runat="server"></asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                           </ItemTemplate>
                </asp:DataList>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Registration No. :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblplate" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtplate" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขทะเบียนรถ" ></asp:TextBox>--%>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Province of registration : 

     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblstate_car" runat="server" Text=""></asp:Label>
    <%--<asp:TextBox ID="txtstate_car" class="w3-input w3-border w3-round-large" runat="server" placeholder="จังหวัดที่จดทะเบียน" ></asp:TextBox>--%>
      <%--<asp:DropDownList ID="ddlCountryCar" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>--%>
    </div>
     
      
  </div>

    <div class="w3-row w3-padding-small">
  
     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Make  :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblbrands" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtbrands" class="w3-input w3-border w3-round-large" runat="server" placeholder="ยี่ห้อ" ></asp:TextBox>--%>
    </div>

        <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Model  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblmodels" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtmodels" class="w3-input w3-border w3-round-large" runat="server" placeholder="รุ่นรถ" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">
  
      <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Seats : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblSeats" runat="server" Text=""></asp:Label>
       <%--<asp:DropDownList ID="ddlSeats" runat="server" class="w3-input w3-border w3-round-large"> 
                <asp:ListItem Value="">กรุณาเลือก</asp:ListItem>
                <asp:ListItem Value="1">1 seat</asp:ListItem>
                <asp:ListItem Value="2">2 seat</asp:ListItem>
                <asp:ListItem Value="3">3 seat</asp:ListItem>
                <asp:ListItem Value="4">4 seat</asp:ListItem>
                <asp:ListItem Value="5">5 seat</asp:ListItem>
                <asp:ListItem Value="6">6 seat</asp:ListItem>
                <asp:ListItem Value="7">7 seat</asp:ListItem>
            </asp:DropDownList>--%>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Gross Weight (kg.) :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblweight" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtweight" class="w3-input w3-border w3-round-large" runat="server" placeholder="น้ำหนัก" ></asp:TextBox>--%>
    </div>

  </div>

  
     <div class="w3-row w3-padding-small">

    
     
     
      <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Colors  :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcolors" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcolors" class="w3-input w3-border w3-round-large" runat="server" placeholder="สี" ></asp:TextBox>--%>
    </div>

  </div>
     <div class="w3-row w3-padding-small">

       <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Type  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltypecar" runat="server" Text=""></asp:Label>
       <%--<asp:DropDownList ID="ddltypecar" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>--%>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Engine Number : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblNumEngine" runat="server" Text=""></asp:Label>
     <%--<asp:TextBox ID="txtNumEngine" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขเครื่อง" ></asp:TextBox>--%>
    </div>
     
  </div>

  
    <div class="w3-row w3-padding-small">


      <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Vehicle Identification Number (VIN) :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnumcar" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtnumcar" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขตัวรถ" ></asp:TextBox>--%>
    </div>

  </div>

  <%--  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        น้ำหนักบรรทุก : 
     </div>
      
    <div class="w3-col l3 ">
     <asp:TextBox ID="txtWeight_Carry" class="w3-input w3-border w3-round-large" runat="server" placeholder="น้ำหนักบรรทุก" ></asp:TextBox>
    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        ความจุกระบอกสูบ :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtCylinder_cap" class="w3-input w3-border w3-round-large" runat="server" placeholder="ความจุกระบอกสูบ" ></asp:TextBox>
    </div>

  </div>--%>

  <div class="w3-row w3-padding-small" id="display_lao" runat=server>

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Passport Vehicle : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpass_car" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpass_car"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Passport Vehicle Expiry Date : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblexp_pass_car_date" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtexp_pass_car_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

      <div class="w3-row w3-padding-small" id="divIMG_authorize_car" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
      Letter of Consent from Vehicle Owner / Authorization from Vehicle Owner : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_authorize_car" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileauthorize_car" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperauthorize_car" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

  <div class="w3-row w3-padding-small" id="divIMG_regis_photo" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Vehicle Registration Certificate : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_regis_photo" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileregis_photo" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperregis_photo" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Vehicle Registration Certificate (Optional) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_regis_photo2" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileregis_photo2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperregis_photo2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

      <div class="w3-row w3-padding-small" id="divIMG_car_cer" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Certified translation of vehicle registration : 
     </div>
      
    <%--<div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_car_cer" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <asp:DataList ID="DtlImg_car_cer" runat="server" CellPadding="4" 
                    DataKeyField="gid" ForeColor="#333333" Width="100%"
                            RepeatDirection="Horizontal">
                    
                    <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                           <ItemTemplate>
                               <table  style="width: 225px; height: 150px;">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile" Height="180px" runat="server" ImageUrl='<%# Bind("PathImg") %>' /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("LinkImg") %>' Target="_blank" Text='Big Picture' runat="server"></asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                           </ItemTemplate>
                </asp:DataList>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>--%>

     <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="linkCar_cer" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidPhotonamecar_cer" runat="server" />
    </div>
  </div>

        <div class="w3-row w3-padding-small" id="divIMG_car_inspec" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
              Vehicle inspection cetificate : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_car_inspec" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <asp:DataList ID="DtlImg_car_inspec" runat="server" CellPadding="4" 
                    DataKeyField="gid" ForeColor="#333333" Width="100%"
                            RepeatDirection="Horizontal">
                    
                    <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                           <ItemTemplate>
                               <table  style="width: 225px; height: 150px;">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile" Height="180px" runat="server" ImageUrl='<%# Bind("PathImg") %>' /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("LinkImg") %>' Target="_blank" Text='Big Picture' runat="server"></asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                           </ItemTemplate>
                </asp:DataList>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Note : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <asp:Label ID="lblcomments_tab3" runat="server" Text=""></asp:Label>
    </div>

  </div>


   <br />
       <div class="w3-border w3-round-large">
    <br />
   <%-- <h5 class="fontKanit w3-padding-left">พื้นที่อนุญาตให้ใช้ยานพาหนะ </h5>--%>
     <a class="w3-large w3-padding-left"><b class="fontKanit">Area use vehicle</b></a>
    <hr style="width: 140px;margin-top: 2px;" class="hr1" />
    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Province : 
     </div>

    <div class="fontKanit w3-medium w3-col l9 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblprovarea" runat="server" Text=""></asp:Label>
      
    </div>
     
     <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Border Crossing Checkin : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblBorderCheckin" runat="server" Text=""></asp:Label>
        <%-- <asp:DropDownList ID="ddlBorderCheckin" runat="server" class="w3-input w3-border w3-round-large" > 
            </asp:DropDownList>--%>
    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
      Border Crossing Checkout :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblBorderCheckout" runat="server" Text=""></asp:Label>
       <%--<asp:DropDownList ID="ddlBorderCheckout" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Note : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <asp:Label ID="lblcomments_tab8" runat="server" Text=""></asp:Label>
    </div>

  </div>
 

  </div>

     <br />

     </div>

  <div class="w3-border w3-round-large" style="display:none">
    <br />
     <a class="w3-large w3-padding-left"><b class="fontKanit">Owner</b></a>
    <hr style="width: 50px;margin-top: 2px;" class="hr1" />
<div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Name : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblholder" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtholder" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อผู้ครอบครอง" ></asp:TextBox>--%>
    </div>
     
   
   <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        ID card : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblholder_id_card" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtholder_id_card" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชนผู้ครอบครอง" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

  <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Address : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_holder" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtaddress_holder"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>



 


   <div class="w3-row w3-padding-small" style="display:none">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Telephone  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_holder" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txttel_holder" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>--%>
    </div>
     
<%--      <div class="w3-col l2 <% Response.Write(Css)%>" >
        Email : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtemail_holder" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
    </div>--%>

  </div>

  <br />

     </div>
       <br />

    <div class="w3-border w3-round-large">
    <br /><%--headmenu--%>
    <%--<h5 class="fontKanit w3-padding-left">ผู้ครอบครอง </h5>--%>
    <a class="w3-large w3-padding-left"><b class="fontKanit">Owner</b></a>
    <hr style="width: 50px;margin-top: 2px;" class="hr1" />
    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Name : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblowner" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtowner" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อผู้ถือกรรมสิทธิ์" ></asp:TextBox>--%>
    </div>
     
   
   <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        ID card : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblowner_id_card" runat="server" Text=""></asp:Label>
      <%-- <asp:TextBox ID="txtowner_id_card" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชนผู้ถือกรรมสิทธิ์" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

  <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Province : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblprovince_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

       <div class="w3-row w3-padding-small">

  <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Postal  : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblzipcode_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

       <div class="w3-row w3-padding-small">

  <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Country : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcountry_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

  <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Address : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Note : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <asp:Label ID="lblcomments_tab1" runat="server" Text=""></asp:Label>
    </div>

  </div>


   <div class="w3-row w3-padding-small" style="display:none">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Telephone  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_owner" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txttel_owner" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>--%>
    </div>
     
<%--      <div class="w3-col l2 <% Response.Write(Css)%>" >
        Email : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtemail_owner" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
    </div>--%>

  </div>

     <br />

     </div>
</div>
 </div> 
 <br />
     <div class="conta">
     <div class="w3-row w3-padding-small">

 <p class=" w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-id-card-o" aria-hidden="true"></i>  Compulsory Motor Insurance</b></p>
</div>

 <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Policy Number : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinsure_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtinsure_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขที่กรมธรรม์ประกันภัย" ></asp:TextBox>--%>
    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Insurance Company : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcompany" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcompany" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อบริษัท" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Start date : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblstart_date" runat="server" Text=""></asp:Label>
         <%--<asp:TextBox ID="txtstart_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        End date : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblend_date" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtend_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small" style="display:none">

     <div class="ontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อผู้เอาประกันภัย : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinsure_name" runat="server" Text=""></asp:Label>
         <%--<asp:TextBox ID="txtinsure_name"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อผู้เอาประกันภัย"></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        เลขตัวถัง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblcar_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcar_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขตัวถัง"></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small" id="divIMG_act_photo" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Policy Schedule : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_act_photo" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileact_photo"  CssClass=" imageFilepassport" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperact_photo" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Policy Schedule (Optional) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileact_photo_2"  CssClass=" imageFilepassport" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperact_photo_2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>
  </div>
    <div class="conta">
     <div class="w3-row w3-padding-small">

 <p class=" w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-id-card-o" aria-hidden="true"></i> Third-party liability motor vehicle insurance</b></p>
</div>

 <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Policy Number : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinsure_no2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtinsure_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขที่กรมธรรม์ประกันภัย" ></asp:TextBox>--%>
    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Insurance Company : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcompany2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcompany" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อบริษัท" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Start date : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblstart_date2" runat="server" Text=""></asp:Label>
         <%--<asp:TextBox ID="txtstart_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        End date : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblend_date2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtend_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small" style="display:none">

     <div class="ontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อผู้เอาประกันภัย : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinsure_name2" runat="server" Text=""></asp:Label>
         <%--<asp:TextBox ID="txtinsure_name"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อผู้เอาประกันภัย"></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        เลขตัวถัง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <%-- <asp:Label ID="lblcar_no2" runat="server" Text=""></asp:Label>--%>
        <%--<asp:TextBox ID="txtcar_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขตัวถัง"></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small" id="divIMG_act_photo2" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Policy Schedule : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_act_photo2" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileact_photo2"  CssClass=" imageFilepassport" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperact_photo2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Policy Schedule : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileact_photo2_2"  CssClass=" imageFilepassport" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperact_photo2_2" NavigateUrl="" Target="_blank"  runat="server">Big Picture</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Note : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <asp:Label ID="lblcomments_tab4" runat="server" Text=""></asp:Label>
    </div>

  </div>

  </div>
  <script type="text/javascript">
      jQuery(function ($) {

          $(document).ready(function () {

              $('#<%= gvMain.ClientID %>').footable({
                  "paging": {
                      "enabled": false
                  }//,
                  //                "breakpoints": {
                  //                    "phone": 480,
                  //                    "phone": 768,
                  //                    "phone": 992,
                  //                    "tablet": 1200,
                  //                    "tablet": 1400
                  //                }
              });

              var prm = Sys.WebForms.PageRequestManager.getInstance();

              prm.add_endRequest(function () {
                  $('#<%= gvMain.ClientID %>').footable({
                      "paging": {
                          "enabled": false
                      }//,
                      //                    "breakpoints": {
                      //                        "phone": 480,
                      //                        "phone": 768,
                      //                        "phone": 992,
                      //                        "tablet": 1200,
                      //                        "tablet": 1400
                      //                    }
                  });
              });

          });
      }); 


</script>
<br />
<div class="conta">
  <div class="w3-row w3-padding-small">

 <p class="w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-credit-card-alt" aria-hidden="true"></i>  Payment </b></p>
</div>

<div class="w3-row w3-padding-small w3-padding fontKanit w3-medium">

<asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="No Data" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass=" table table-striped table-bordered table-center table-hover " >
         <Columns>
             <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                           
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
           
             <asp:BoundField DataField="receipt_no" HeaderText="<center>receipt number</center>" HtmlEncode="False" />

             <asp:BoundField DataField="receipt_date" HeaderText="<center>Date</center>"  ItemStyle-HorizontalAlign="Center"  HtmlEncode="False" DataFormatString="{0:d MMM yyyy}" />

              

               
         </Columns>
        <%--<PagerTemplate>
          <div class="w3-row w3-padding-small"> 
                      
            <div class="col ">
             <div  class="w3-right"> 

               <asp:LinkButton ID="btnLast" runat="server" CommandArgument="Last" CommandName="Page"  class="w3-right btn w3-button w3-padding-small w3-round w3-large" >สุดท้าย</asp:LinkButton>
              <asp:LinkButton ID="btnNext" runat="server" CommandArgument="Next" CommandName="Page" class="w3-right btn w3-button w3-padding-small w3-round w3-large" >ถัดไป</asp:LinkButton> 
  
             
              
                <asp:LinkButton ID="btnPrev" class="w3-right btn w3-button w3-padding-small w3-round w3-large" runat="server" CommandArgument="Prev" CommandName="Page" >ก่อนหน้า</asp:LinkButton>
              

              
               <asp:LinkButton ID="btnFirst" class="w3-right btn w3-button w3-padding-small w3-round w3-large" runat="server" CommandArgument="First" CommandName="Page" >แรกสุด </asp:LinkButton>
               
            </div> 
               

               <div class="w3-left"> 
              <p class="w3-left w3-padding-small"> หน้าที่   
             </p>

            <p class="w3-left"><asp:DropDownList ID="DDLPage" runat="server" class="w3-input w3-border w3-round-large"  AutoPostBack="true"  OnSelectedIndexChanged="DDLPage_SelectedIndexChanged" Style="position: static" >
                
                </asp:DropDownList>  
             </p>
             </div> 
            </div>
          </div>
        </PagerTemplate>--%>        
    </asp:GridView>
    </div>
  </div><br />

    <div id="formT2" runat="server">
    <div class="conta">
  <div class="w3-row w3-padding-small">
  <p class="headmenu w3-purple2 w3-padding w3-large fontKanit"><b><i class="fa fa-address-card-o" aria-hidden="true"></i>  Issue</b></p>
<%-- <h5 class="headmenu w3-purple2 w3-padding"><b> # Issue</b></h5>--%>
</div>

<div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium  w3-col l2_2 <% Response.Write(Css)%>" >
       Permit Number : 
     </div>
      
    <div class="fontKanit w3-medium  w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblpermit_no" runat="server" Text=""></asp:Label>

    </div>

    <div class="fontKanit w3-medium  w3-col l2 <% Response.Write(Css)%>" >
       Place of Issue : 
     </div>
      
    <div class="fontKanit w3-medium  w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblissue_place" runat="server" Text=""></asp:Label>

    </div>
     
      

  </div>
 
  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium  w3-col l2_2 <% Response.Write(Css)%>" >
        Issue Date :
     </div>
      
    <div class="fontKanit w3-medium  w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblissue_date" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium  w3-col l2 <% Response.Write(Css)%>" >
        Expiry Date (Valid Until) :
     </div>
      
    <div class="fontKanit w3-medium  w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblexpiry_date" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class=" w3-row w3-padding-small">

    <div class="fontKanit w3-medium  w3-col l2_2 <% Response.Write(Css)%>" >
       Extended Until : 
     </div>
      
    <div class="fontKanit w3-medium  w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblextended_until" runat="server" Text=""></asp:Label>

    </div>

    <div class="fontKanit w3-medium  w3-col l2 <% Response.Write(Css)%>" >
       Motor Vehicle TAD Number : 
     </div>
      
    <div class="fontKanit w3-medium  w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lbltad_no" runat="server" Text=""></asp:Label>

    </div>
    

  </div>

    <div class="w3-row w3-padding-small">

      <div class="fontKanit w3-medium  w3-col l2_2 <% Response.Write(Css)%>" >
        Issuing Authority :
     </div>
      
    <div class="fontKanit w3-medium  w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblissuing_authority" runat="server" Text=""></asp:Label>

    </div>
      
  </div></br>
  </div><br />
  <div class="conta">
  <div class=" w3-row w3-padding-small">
   <p class="headmenu w3-purple2 w3-padding w3-large fontKanit"><b><i class="fa fa-user-circle-o" aria-hidden="true"></i>  Operator</b></p>
    <%--<h5 class="headmenu w3-purple2 w3-padding"><b> # Operator</b></h5>--%>
</div>

   <div class="w3-row w3-padding-small">

   
      <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        Name of Transport Operator :
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lbltransport_operator_name" runat="server" Text=""></asp:Label>

    </div>

  </div>
   
      <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
      Address : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lbladdress" runat="server" Text=""></asp:Label>

    </div>

  </div>

     <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Province : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblprovince" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Telephone :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lbltelephone" runat="server" Text=""></asp:Label>

    </div>

  </div>

   <div class=" w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       E-mail : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>

    </div>
     

  </div>
  <br />
  <div class="w3-border w3-round-large">
    <br />
    <p class="fontKanit w3-large  w3-padding-left"> <b>If different from Operator </b> </p>
    <hr />
     <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Name of Vehicle Owner : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvehicle_owner_name" runat="server" Text=""></asp:Label>

    </div>
     
      

  </div>

  <div class="w3-row w3-padding-small">

   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Address :
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblvehicle_owner_address" runat="server" Text=""></asp:Label>

    </div>
  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
      Province : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvehicle_owner_province" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Telephone :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblvehicle_owner_telephone" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       E-mail : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvehicle_owner_email" runat="server" Text=""></asp:Label>

    </div>
     

  </div>
  <br />
  </div></div><br />
   <div class="conta">
    <div class="w3-row w3-padding-small">
    <p class="headmenu w3-purple2 w3-padding w3-large "><b  class="fontKanit"><i class="fa fa-car" aria-hidden="true"></i>  Vehicle</b></p>
 <%--<h5 class="headmenu w3-purple2 w3-padding"><b> # Vehicle</b></h5>--%>
</div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
      Type of Vehicle : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvehicle_type" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Registration Number :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblregistration_no" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
      Vehicle Category : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvehicle_category" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Date of Registration :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblregis_date" runat="server" Text=""></asp:Label>

    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
      Registered at Province : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblregis_province" runat="server" Text=""></asp:Label>

    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
      Semi-trailer : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblsemi_trailer" runat="server" Text=""></asp:Label>

    </div>
    

    </div>

    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
     Brand : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblbrand" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Model :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblmodel" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
     VIN Number : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvin_no" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Engine Number :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblengine_no" runat="server" Text=""></asp:Label>

    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
    Number of Axles : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblaxles_no" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Colour :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblcolour" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
    Capacity in CC : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcapacity_cc" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Gross Weight in Kg :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblweight_gross" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
    Net Weight in Kg : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblweight_net" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Number of Seats (for Bus) :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblseats_no" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
    Width in Metres : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblwidth" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       Length in Metres :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lbllength" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
    Height in Metres : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblheight" runat="server" Text=""></asp:Label>

    </div>
     
  </div>
  </div>
  </div>
 
</asp:Content>

