<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="LicenseDtl.aspx.vb" Inherits="Admin_LicenseDtl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<%--   <link href="../Styles/datatables.min.css" rel="stylesheet">
    <script type="text/javascript" src="../Scripts/datatables.min.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">--%>
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
   <h4 class="headtxt w3-xlarge fontKanit"><b> ข้อมูล<% Response.Write(text)%></b></h4>
</header>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<div id="ViewDriver" runat=server>
<div id="formT1" runat="server">
<div id="divCompany" runat="server">
<div class="conta"> 
<div class="w3-row w3-padding-small">

 <p class="w3-purple2 w3-padding w3-large fontKanit"><b><i class="fa fa-address-card-o" aria-hidden="true"></i> ข้อมูลผู้ประกอบการท่องเที่ยว</b></p>
</div>

<div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อผู้ประกอบการ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcom_name" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        ชื่อ :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblagen_name" runat="server" Text=""></asp:Label>

    </div>

  </div>

 

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        โทรศัพท์ : 
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
        เลขที่ใบอนุญาตประกอบธุรกิจท่องเที่ยว : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcompany_license" runat="server" Text=""></asp:Label>

    </div>
     
 

  </div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ที่อยู่ผู้ประกอบการ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcom_address" runat="server" Text=""></asp:Label>

    </div>
     

  </div>
  </div><br />
  <div class="conta">
  <div class="w3-row w3-padding-small">
   <h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-address-card-o" aria-hidden="true"></i>  ข้อมูล กรุ๊ปทัวร์</b></h5>
   </div>
      <div class="w3-row w3-padding-small">

      <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อกรุ๊ปทัวร์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblgroupname" runat="server" Text=""></asp:Label>

    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        จำนวนรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcountcar" runat="server" Text=""></asp:Label> คัน

    </div>
 
    

  </div>



       <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        วันเริ่มต้น  : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblstartdategroup" runat="server" Text=""></asp:Label>

    </div>

      <div class="w3-col l2 <% Response.Write(Css)%>" >
        วันสิ้นสุด  : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblexpdategroup" runat="server" Text=""></asp:Label>

    </div>
 
     
  </div>

  <div class="w3-row w3-padding-small">
  <div class="w3-col l2_2 <% Response.Write(Css)%>"   >
    ชื่อผู้นำเที่ยว :
    </div>
   <div class="w3-col l6 w3-padding-top <% Response.Write(Css_Ctrl)%>">

      
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

              <asp:BoundField DataField="guide_name" HeaderText="<center>ชื่อผู้นำเที่ยว</center>" HtmlEncode="False"/>
               <asp:BoundField DataField="guide_tel" HeaderText="<center>โทรศัพท์</center>" Visible="false" HtmlEncode="False"/>
               <asp:BoundField DataField="guide_idcard" HeaderText="<center>เลขประจำตัวปชช.</center>" Visible="false" HtmlEncode="False"/>
               <asp:BoundField DataField="regis_no" HeaderText="<center>ป้ายทะเบียน</center>" HtmlEncode="False"/>

               <asp:TemplateField HeaderText="<center>รูปถ่าย</center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Image ID="Imgregis" runat="server" Width="320px" ImageUrl="#" />
                                        <asp:HyperLink ID="HyperLicensePhotoGuide" NavigateUrl="<%# Bind('regis_photo') %>" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>
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
        กำหนดการเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="lnkTravel_Itinerary" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidTravel_Itinerary" runat="server" />
    </div>

  </div>


  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเหตุ (ข้อมูลทั่วไป) : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <asp:Label ID="lblcomments_tab0" runat="server" Text=""></asp:Label>
    </div>

  </div>

  
</div>
 </div>
 
 <br />
</div>
</div>
<div class="conta" id="divExtend" runat="server">
<div class="w3-row w3-padding-small">

 <p class="w3-purple2 w3-padding w3-large fontKanit"><b><i class="fa fa-address-card-o" aria-hidden="true"></i> ข้อมูลการขอขยายเวลา</b></p>
</div>

    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่เครื่องหมายแสดงการใช้รถ อ้างอิง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:HyperLink ID="hlrefer" runat="server" Cssclass="btn-link"></asp:HyperLink>
    
    </div>
     

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        สาเหตุการขอขยายเวลา : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
         <asp:Label ID="lblReasonExten" runat="server" Text=""></asp:Label>
    
    </div>
     

  </div>

  <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ไฟล์แนบ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
         <asp:HyperLink ID="hlFileAttach" runat="server" Cssclass="btn-link"></asp:HyperLink>
      

             <asp:HiddenField ID="hidfolderAttach" runat="server" />
              <asp:HiddenField ID="HidFname" runat="server" />
              <asp:HiddenField ID="HidSname" runat="server" />
    
    </div>
     

  </div>
 
</div>
 <br />
<div class="conta">
<div class="w3-row w3-padding-small">

 <h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-address-card-o" aria-hidden="true"></i> ข้อมูลคนขับหลัก</b></h5>
</div>
    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        เลขบัตรประจำตัวประชาชนผู้ขับรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblid_code" runat="server" Text=""></asp:Label>
      <%-- <asp:TextBox ID="txtid_code"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชน" ></asp:TextBox>--%>
    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        ประเทศของผู้ขับรถ :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblcountry_driver" runat="server" Text=""></asp:Label>
         <%--<asp:DropDownList ID="ddlcountry_driver" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่หนังสือเดินทาง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport" runat="server" Text=""></asp:Label>
      <%--  <asp:TextBox ID="txtpassport"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุของหนังสือเดินทาง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblexp_pass_date" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtexp_pass_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small" id="divIMG_passport" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือเดินทาง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_passport" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือเดินทาง (เพิ่มเติม) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

 
     <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
      <%-- <asp:TextBox ID="txtname"   class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อ" ></asp:TextBox>--%>
    </div>
    

  </div>

   <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        สัญชาติ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnational" runat="server" Text=""></asp:Label>

    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        วัน เดือน ปี เกิด : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtdate" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small" style="DISPLAY: none">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        รายละเอียด : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label>
          <%--<asp:TextBox ID="txtinfo" TextMode="MultiLine" class="w3-input w3-border w3-round-large" runat="server" placeholder="ข้อมูลเกี่ยวกับกำหนดการต่างๆ เช่น สถานที่พัก กำหนดการในแต่ละวัน"></asp:TextBox>--%>
    </div>
     
   </div>


   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        เพศ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblgender" runat="server" Text=""></asp:Label>

    </div>

   
     
   </div>

    <div class="w3-row w3-padding-small">

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเลขใบอนุญาตขับรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtlicense_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุหมายเลขใบอนุญาตขับรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblexp_license_no" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtexp_license_no" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

    </div>

    <div class="w3-row w3-padding-small" id="divIMG_license_no" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_license_no" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ (เพิ่มเติม) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
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
      
  

     <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="HyFileCer" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidFileCer" runat="server" />
    </div>
  </div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ที่อยู่ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_driver" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtaddress_driver"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

</div>

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        โทรศัพท์  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_driver" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txttel_driver" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>--%>
    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        Email : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblemail_driver" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtemail_driver" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>--%>
    </div>
  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเหตุ (ข้อมูลคนขับ) :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <asp:Label ID="lblcomments_tab2" runat="server" Text=""></asp:Label>
    </div>

  </div>

  

   </div>
 

<div class="conta" id="reserve1" runat=server >
    <br />
    <h5 class="fontKanit w3-large w3-padding-left"><b>คนขับสำรองคนที่ 1 </b></h5>
    <hr style="width: 140px;" />

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblname1" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtname1"   class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อ" ></asp:TextBox>--%>
    </div>
     
    

  </div>

   <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        สัญชาติ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnational1" runat="server" Text=""></asp:Label>
     
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        เพศ :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblgender1" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       หมายเลขใบอนุญาตขับรถ :  
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_no1" runat="server" Text=""></asp:Label>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุใบอนุญาตขับรถ :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_exp_date_1" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small"  >

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่หนังสือเดินทาง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport1" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpassport1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุหนังสือเดินทาง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport_expire_1" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtexp_pass_date1" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       ที่อยู่ :  
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_1" runat="server" Text=""></asp:Label>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        เบอร์โทร :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_1" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Email :  
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
        รูปถ่ายหนังสือเดินทาง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport_1" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport_1" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือเดินทาง (เพิ่มเติม) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport_1_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport_1_2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>


    <div class="w3-row w3-padding-small" id="div2" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no_1" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no_1" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ (เพิ่มเติม) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no_1_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no_1_2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
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
      
  

    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="HyFileCer2" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidFileCer2" runat="server" />
    </div>
  </div>
    <br />
  </div>
 
   <%--<br />--%>
  <div class="conta" id="reserve2" runat=server >
    <br />
    <h5 class="fontKanit w3-large w3-padding-left"><b>คนขับสำรองคนที่ 2 </b></h5>
    <hr style="width: 140px;" />

 

   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblname2" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtname2"   class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อ" ></asp:TextBox>--%>
    </div>
     
      
  </div>

   <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        สัญชาติ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnational2" runat="server" Text=""></asp:Label>
       <%--<asp:DropDownList ID="ddlnational2" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>--%>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        เพศ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblgender2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtlicense_no2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small"  >

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเลขใบอนุญาตขับรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_no2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpassport2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุใบอนุญาตขับรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_exp_date_2" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtexp_pass_date2" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small"  >

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่หนังสือเดินทาง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpassport2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุหนังสือเดินทาง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport_expire_2" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtexp_pass_date2" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       ที่อยู่ :  
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_2" runat="server" Text=""></asp:Label>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        เบอร์โทร :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_2" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small">


   <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       Email :  
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
        รูปถ่ายหนังสือเดินทาง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport_2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือเดินทาง (เพิ่มเติม) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilepassport_2_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperpassport_2_2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>


    <div class="w3-row w3-padding-small" id="div4" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no_2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ (เพิ่มเติม) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFilelicense_no_2_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperlicense_no_2_2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
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
      
  
     <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

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

 <h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-car" aria-hidden="true"></i>  ข้อมูลรถ</b></h5>
</div>

    <div class="w3-row w3-padding-small" id="divIMG_car" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายตัวรถ : 
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
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile" Height="180px" runat="server" ImageUrl='<%# Bind("PathImg") %>' /></td></tr>
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
        เลขทะเบียนรถ :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblplate" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtplate" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขทะเบียนรถ" ></asp:TextBox>--%>
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        จังหวัดที่จดทะเบียน : 

     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblstate_car" runat="server" Text=""></asp:Label>
    
    </div>
     
      
  </div>

    <div class="w3-row w3-padding-small">
  
     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ยี่ห้อ :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblbrands" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtbrands" class="w3-input w3-border w3-round-large" runat="server" placeholder="ยี่ห้อ" ></asp:TextBox>--%>
    </div>

        <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        รุ่นรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblmodels" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtmodels" class="w3-input w3-border w3-round-large" runat="server" placeholder="รุ่นรถ" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">
  
      <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        จำนวนที่นั่ง : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblSeats" runat="server" Text=""></asp:Label>
       
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        น้ำหนักรวม :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblweight" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtweight" class="w3-input w3-border w3-round-large" runat="server" placeholder="น้ำหนัก" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

  
     
     
      <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        สี :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcolors" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcolors" class="w3-input w3-border w3-round-large" runat="server" placeholder="สี" ></asp:TextBox>--%>
    </div>

  </div>

     <div class="w3-row w3-padding-small">

       <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ประเภทรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltypecar" runat="server" Text=""></asp:Label>
      
    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        เลขเครื่องยนต์ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblNumEngine" runat="server" Text=""></asp:Label>
     <%--<asp:TextBox ID="txtNumEngine" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขเครื่อง" ></asp:TextBox>--%>
    </div>
     
  </div>

  
    <div class="w3-row w3-padding-small">


      <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        เลขตัวรถ :
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnumcar" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtnumcar" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขตัวรถ" ></asp:TextBox>--%>
    </div>

  </div>


  <div class="w3-row w3-padding-small" id="display_lao" runat=server>

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่หนังสือเดินทางรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpass_car" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpass_car"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุหนังสือเดินทางรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblexp_pass_car_date" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtexp_pass_car_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

      <div class="w3-row w3-padding-small" id="divIMG_authorize_car" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือมอบอำนาจ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_authorize_car" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileauthorize_car" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperauthorize_car" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือมอบอำนาจ (เพิ่มเติม) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileauthorize_car2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperauthorize_car2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

  <div class="w3-row w3-padding-small" id="divIMG_regis_photo" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือจดทะเบียนรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_regis_photo" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileregis_photo" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperregis_photo" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือจดทะเบียนรถ (เพิ่มเติม) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileregis_photo2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperregis_photo2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
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
      
  

    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="linkCar_cer" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidPhotonamecar_cer" runat="server" />
    </div>
  </div>

       <div class="w3-row w3-padding-small" id="divIMG_car_inspec" runat="server">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
              หนังสือรับรองการตรวจสภาพรถ : 
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
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("LinkImg") %>' Target="_blank" Text='ดูรูปใหญ่' runat="server"></asp:HyperLink>&nbsp;&nbsp;
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
        หมายเหตุ (ข้อมูลรถ) :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <asp:Label ID="lblcomments_tab3" runat="server" Text=""></asp:Label>
    </div>

  </div>

  

   <br />
       <div class="w3-border w3-round-large">
    <br />
   <%-- <h5 class="fontKanit w3-padding-left">พื้นที่อนุญาตให้ใช้ยานพาหนะ </h5>--%>
     <h5 class="fontKanit w3-large w3-padding-left"><b>พื้นที่อนุญาตให้ใช้ยานพาหนะ</b></h5>
    <hr style="width: 200px;" />
    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        จังหวัด : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l9 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblprovarea" runat="server" Text=""></asp:Label>
      
    </div>
     
   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ด่านพรมแดนขาเข้า : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblBorderCheckin" runat="server" Text=""></asp:Label>
        <%-- <asp:DropDownList ID="ddlBorderCheckin" runat="server" class="w3-input w3-border w3-round-large" > 
            </asp:DropDownList>--%>
    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
      ด่านพรมแดนขาออก :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblBorderCheckout" runat="server" Text=""></asp:Label>
       <%--<asp:DropDownList ID="ddlBorderCheckout" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>--%>
    </div>

  </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเหตุ (ข้อมูลการเข้า-ออกด่านพรมแดน) :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <asp:Label ID="lblcomments_tab8" runat="server" Text=""></asp:Label>
    </div>

  </div>
     <br />

     </div>

    

  <div class="w3-border w3-round-large" style="display:none">
    <br />
      <h5 class="fontKanit w3-large w3-padding-left"><b>เจ้าของรถ</b></h5>
    <hr style="width: 140px;" />

<div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อเจ้าของรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblholder" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtholder" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อเจ้าของรถ" ></asp:TextBox>--%>
    </div>
     
   
   <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        เลขบัตรประจำตัวประชาชน : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblholder_id_card" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtholder_id_card" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชนเจ้าของรถ" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

  <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ที่อยู่ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_holder" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtaddress_holder"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>
 

 


   <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        โทรศัพท์  : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_holder" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txttel_holder" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>--%>
    </div>
     

  </div>

  <br />

     </div>
       <br />

    <div class="w3-border w3-round-large">
    <br /><%--headmenu--%>
    <%--<h5 class="fontKanit w3-padding-left">เจ้าของรถ </h5>--%>
     <h5 class="fontKanit w3-large w3-padding-left"><b>เจ้าของรถ</b></h5>
    <hr style="width:95px;" />
    <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อเจ้าของรถ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblowner" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtowner" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อผู้ถือกรรมสิทธิ์" ></asp:TextBox>--%>
    </div>
     
   
   <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        เลขบัตรประจำตัวประชาชน : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblowner_id_card" runat="server" Text=""></asp:Label>
      <%-- <asp:TextBox ID="txtowner_id_card" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชนผู้ถือกรรมสิทธิ์" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

  <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        จังหวัด : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblprovince_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

       <div class="w3-row w3-padding-small">

  <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        รหัสไปรษณีย์ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblzipcode_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

       <div class="w3-row w3-padding-small">

  <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ประเทศ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcountry_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

  <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ที่อยู่ : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเหตุ (ข้อมูลเจ้าของรถ) :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <asp:Label ID="lblcomments_tab1" runat="server" Text=""></asp:Label>
    </div>

  </div>

  

   
     <br />

     </div>

     

</div>
 </div> 
 <br />
     <div class="conta">
     <div class="w3-row w3-padding-small">

 <h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-id-card-o" aria-hidden="true"></i>  ข้อมูลพรบ.</b></h5>
</div>

 <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่กรมธรรม์ประกันภัย : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinsure_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtinsure_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขที่กรมธรรม์ประกันภัย" ></asp:TextBox>--%>
    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        ชื่อบริษัท : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcompany" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcompany" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อบริษัท" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
        ระยะเวลาประกันภัย เริ่มต้น : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblstart_date" runat="server" Text=""></asp:Label>
         <%--<asp:TextBox ID="txtstart_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        ถึงวันที่ : 
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
        รูปถ่ายเอกสาร พรบ. : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_act_photo" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileact_photo" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperact_photo" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายเอกสาร พรบ.(เพิ่มเติม) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileact_photo_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperact_photo_2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเหตุ (ข้อมูล พรบ.) :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <asp:Label ID="lblcomments_tab4" runat="server" Text=""></asp:Label>
    </div>

  </div>

  

  </div>
      <div class="conta">
     <div class="w3-row w3-padding-small">

 <p class=" w3-purple2 w3-padding w3-large"><b class="fontKanit"><i class="fa fa-id-card-o" aria-hidden="true"></i> Third-party liability motor vehicle insurance</b></p>
</div>

 <div class="w3-row w3-padding-small">

    <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       เลขที่กรมธรรม์ประกันภัย : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinsure_no2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtinsure_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขที่กรมธรรม์ประกันภัย" ></asp:TextBox>--%>
    </div>
     
      <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
        ชื่อบริษัท : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcompany2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcompany" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อบริษัท" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

     <div class="fontKanit w3-medium w3-col l2_2 <% Response.Write(Css)%>" >
       วันที่เริ่มต้น : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblstart_date2" runat="server" Text=""></asp:Label>
         <%--<asp:TextBox ID="txtstart_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

     <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
       วันที่สิ้นสุด : 
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
         รูปถ่ายเอกสาร พรบ. : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_act_photo2" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileact_photo2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperact_photo2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>

    <div class="fontKanit w3-medium w3-col l2 <% Response.Write(Css)%>" >
         รูปถ่ายเอกสาร พรบ.(เพิ่มเติม) : 
     </div>
      
    <div class="fontKanit w3-medium w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <table  style="width: 225px; ">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFileact_photo2_2" Height="180px" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Hyperact_photo2_2" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

  
  </div>
  <script type="text/javascript">
      jQuery(function ($) {

          $(document).ready(function () {

              $('#<%= gvMain.ClientID %>').footable({
                  "paging": {
                      "enabled": false
                  }
              });

              var prm = Sys.WebForms.PageRequestManager.getInstance();

              prm.add_endRequest(function () {
                  $('#<%= gvMain.ClientID %>').footable({
                      "paging": {
                          "enabled": false
                      }
                  });
              });

          });
      }); 


</script>
<br />
<div class="conta">
  <div class="w3-row w3-padding-small">

 <h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-credit-card-alt" aria-hidden="true"></i>  การชำระเงิน </b></h5>
</div>

<div class="w3-row w3-padding-small w3-padding fontKanit w3-medium">

<asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass=" table table-striped table-bordered table-center table-hover " >
         <Columns>
             <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                           
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:TemplateField HeaderText="<center>ครั้งที่พิมพ์</center>">
                 <ItemTemplate>
                  <%# Container.DataItemIndex + 1%>
                  </ItemTemplate>
           </asp:TemplateField>
           
             <asp:BoundField DataField="registrar_name" HeaderText="<center>ชื่อนายทะเบียน</center>" HtmlEncode="False" />

             <asp:BoundField DataField="registrar_position" HeaderText="<center>ตำแหน่งนายทะเบียน</center>" HtmlEncode="False" />

              <asp:BoundField DataField="receipt_pc" HeaderText="<center>เลขเครื่อง PC</center>" HtmlEncode="False" />

              <asp:BoundField DataField="receipt_process" HeaderText="<center>เลขคุมใบเสร็จ </center>" HtmlEncode="False" />

              <asp:BoundField DataField="receipt_no" HeaderText="<center>เลขที่ใบเสร็จ </center>" HtmlEncode="False" />

             <asp:BoundField DataField="receipt_date" HeaderText="<center>วันที่ออกใบเสร็จ</center>"  ItemStyle-HorizontalAlign="Center"  HtmlEncode="False" DataFormatString="{0:d MMM yyyy}" />

              

               
         </Columns>
       
    </asp:GridView>
    </div>
  </div><br />

  </div>
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
    <p class="headmenu w3-purple2 w3-padding w3-large fontKanit"><b><i class="fa fa-car" aria-hidden="true"></i>  Vehicle</b></p>
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

