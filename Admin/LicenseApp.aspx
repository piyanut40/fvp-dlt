<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="LicenseApp.aspx.vb" Inherits="Admin_LicenseApp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
 <script src="../Scripts/jquery-ui.js"></script>  

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
<header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
   <h4 class="headtxt w3-xlarge fontKanit"><b> ข้อมูล<% Response.Write(text)%></b></h4>
</header>
 <div class="w3-container w3-padding-top20"  >
           <div class="w3-right">
               <asp:LinkButton ID="lnkBack" class="w3-button w3-purple2 w3-padding w3-round" runat="server" text="ย้อนกลับ" ></asp:LinkButton>
            </div>      
</div><br />
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
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
    function tab_active(_tab) {
        
        var _tab0 = document.getElementById("tab0");
        var _tab1 = document.getElementById("tab1");
        var _tab2 = document.getElementById("tab2");
        var _tab3 = document.getElementById("tab3");
        var _tab4 = document.getElementById("tab4");
        var _tab5 = document.getElementById("tab5");
        var _tab6 = document.getElementById("tab6");
        var _tab7 = document.getElementById("tab7");
        var _tab8 = document.getElementById("tab8");
        var _tab9 = document.getElementById("tab9");

        var _ul1 = document.getElementById("ul1");
        var _ul2 = document.getElementById("ul2");

        var _formT1 = document.getElementById("formT1");
        var _formT2 = document.getElementById("formT2");

        var _form0 = document.getElementById("formTab0");
        var _form1 = document.getElementById("formTab1");
        var _form2 = document.getElementById("formTab2");
        var _form3 = document.getElementById("formTab3");
        var _form4 = document.getElementById("formTab4");
        var _form5 = document.getElementById("form2Tab1");
        var _form6 = document.getElementById("form2Tab2");
        var _form7 = document.getElementById("form2Tab3");
        var _form8 = document.getElementById("formTab8");
        var _form9 = document.getElementById("formTab9");

        var formcompany = document.getElementById("xformTab1");


        var _txttab0 = document.getElementById("MainContent_texttab0");
        var _txttab1 = document.getElementById("MainContent_texttab1");
        var _txttab2 = document.getElementById("MainContent_texttab2");
        var _txttab3 = document.getElementById("MainContent_texttab3");
        var _txttab4 = document.getElementById("MainContent_texttab4");
        var _txttab5 = document.getElementById("MainContent_texttab5");
        var _txttab6 = document.getElementById("MainContent_texttab6");
        var _txttab7 = document.getElementById("MainContent_texttab7");
        var _txttab8 = document.getElementById("MainContent_texttab8");
        var _txttab9 = document.getElementById("MainContent_texttab9");


        var _tab_active = "nav-link w3-purple2 active ";
        var _tab_hide = "nav-link w3-purple3";
        var _tab_complete = "completed";
        var _tab_active2 = "active";
        var _form_active = "w3-animate-center col-12 text-dark w3-padding w3-white ";
        var _form_hide = "w3-animate-center  col-12 text-dark w3-hide ";



        if ((_tab < 5) || (_tab == 8) || (_tab == 9)) {


            var tabnow = $("#ul1 > li > a.active ").attr("id");

            if (tabnow != undefined && tabnow != 'tab9') {
                var tab = tabnow.substring(4, 3);

                cf_check2(tab, tab, _tab);
            }
        


            _ul1.style.display = "block";
            _ul2.style.display = "none";

            if (_tab == 0) {
                _tab0.className = _tab_active;
                _tab1.className = _tab_hide;
                _tab2.className = _tab_hide;
                _tab3.className = _tab_hide;
                _tab4.className = _tab_hide;
                _tab8.className = _tab_hide;
                _tab9.className = _tab_hide;

                _form0.className = _form_active;
                 formcompany.className = _form_active;
                _form1.className = _form_hide;
                _form2.className = _form_hide;
                _form3.className = _form_hide;
                _form4.className = _form_hide;
                _form8.className = _form_hide;
                _form9.className = _form_hide;
            
            }
            else if (_tab == 1) {
                _tab0.className = _tab_hide;
                _tab1.className = _tab_active;
                _tab2.className = _tab_hide;
                _tab3.className = _tab_hide;
                _tab4.className = _tab_hide;
                _tab8.className = _tab_hide;
                _tab9.className = _tab_hide;

                _form0.className = _form_hide;
                _form1.className = _form_active;
                _form2.className = _form_hide;
                _form3.className = _form_hide;
                _form4.className = _form_hide;
                _form8.className = _form_hide;
                _form9.className = _form_hide;
             


            }
            else if (_tab == 2) {
                _tab0.className = _tab_hide;
                _tab1.className = _tab_hide;
                _tab2.className = _tab_active;
                _tab3.className = _tab_hide;
                _tab4.className = _tab_hide;
                _tab8.className = _tab_hide;
                _tab9.className = _tab_hide;

                _form0.className = _form_hide;
                _form1.className = _form_hide;
                _form2.className = _form_active;
                _form3.className = _form_hide;
                _form4.className = _form_hide;
                _form8.className = _form_hide;
                _form9.className = _form_hide;
            

            }
            else if (_tab == 3) {
                _tab0.className = _tab_hide;
                _tab1.className = _tab_hide;
                _tab2.className = _tab_hide;
                _tab3.className = _tab_active;
                _tab4.className = _tab_hide;
                _tab8.className = _tab_hide;
                _tab9.className = _tab_hide;

                _form0.className = _form_hide;
                _form1.className = _form_hide;
                _form2.className = _form_hide;
                _form3.className = _form_active;
                _form4.className = _form_hide;
                _form8.className = _form_hide;
                _form9.className = _form_hide;

         
            }
            else if (_tab == 4) {
                _tab0.className = _tab_hide;
                _tab1.className = _tab_hide;
                _tab2.className = _tab_hide;
                _tab3.className = _tab_hide;
                _tab4.className = _tab_active;
                _tab8.className = _tab_hide;
                _tab9.className = _tab_hide;

                _form0.className = _form_hide;
                _form1.className = _form_hide;
                _form2.className = _form_hide;
                _form3.className = _form_hide;
                _form4.className = _form_active;
                _form8.className = _form_hide;
                _form9.className = _form_hide;

             
            }
            else if (_tab == 8) {
                _tab0.className = _tab_hide;
                _tab1.className = _tab_hide;
                _tab2.className = _tab_hide;
                _tab3.className = _tab_hide;
                _tab4.className = _tab_hide;
                _tab8.className = _tab_active;
                _tab9.className = _tab_hide;

                _form0.className = _form_hide;
                _form1.className = _form_hide;
                _form2.className = _form_hide;
                _form3.className = _form_hide;
                _form4.className = _form_hide;
                _form8.className = _form_active;
                _form9.className = _form_hide;

             
            }  else if (_tab == 9) {

                _tab0.className = _tab_hide;
                _tab1.className = _tab_hide;
                _tab2.className = _tab_hide;
                _tab3.className = _tab_hide;
                _tab4.className = _tab_hide;
                _tab8.className = _tab_hide;
                _tab9.className = _tab_active;

                _form0.className = _form_hide;
                _form1.className = _form_hide;
                _form2.className = _form_hide;
                _form3.className = _form_hide;
                _form4.className = _form_hide;
                _form8.className = _form_hide;
                _form9.className = _form_active;

            
            }
        } else {
            _ul1.style.display = "none";
            _ul2.style.display = "block";

            if (_tab == 5) {
                _tab5.className = _tab_active;
                _tab6.className = _tab_hide;
                _tab7.className = _tab_hide;

                _form5.className = _form_active;
                _form6.className = _form_hide;
                _form7.className = _form_hide;

                _chktab5.disabled = false;
                _chktab6.disabled = true;
                _chktab7.disabled = true;

            }
            else if (_tab == 6) {
                _tab5.className = _tab_hide;
                _tab6.className = _tab_active;
                _tab7.className = _tab_hide;

                _form5.className = _form_hide;
                _form6.className = _form_active;
                _form7.className = _form_hide;

                _chktab5.disabled = true;
                _chktab6.disabled = false;
                _chktab7.disabled = true;
            }
            else if (_tab == 7) {
                _tab5.className = _tab_hide;
                _tab6.className = _tab_hide;
                _tab7.className = _tab_active;

                _form5.className = _form_hide;
                _form6.className = _form_hide;
                _form7.className = _form_active;

                _chktab5.disabled = true;
                _chktab6.disabled = true;
                _chktab7.disabled = false;
            }
        }


    }



    function cf_check(chk, tab) {
        showProgress();
        var Msg;
        var _chk = document.getElementById('MainContent_' + chk);

            document.getElementById('MainContent_HidTab').value = tab;
            document.getElementById('MainContent_BtnSave').click();

        }

        function cf_check2(chk, tab, tabnow) {
            showProgress();
            var Msg;
            var _chk = document.getElementById('MainContent_' + chk);
            document.getElementById('MainContent_HidTabNow').value = tabnow;
            document.getElementById('MainContent_HidTab').value = tab;
            document.getElementById('MainContent_BtnSave2').click();
            
        }
    
    


</script>

  <form id="Form1" class="form-horizontal " align="center">

   <ul id="ul1" class="nav nav-pills nav-justified">
    <li class="nav-item">
      <a id="tab0" onclick="tab_active(0);" style="cursor: pointer;" >1 . ข้อมูลทั่วไป <br />
      </a>
    </li>
    <li class="nav-item">
      <a id="tab1" onclick="tab_active(1);" style="cursor: pointer;">2 . ข้อมูลเจ้าของรถ <br />
      </a>
    </li>
    <li class="nav-item">
      <a id="tab2" onclick="tab_active(2);" style="cursor: pointer;">3 . ข้อมูลคนขับ <br />
      </a> 
    </li> 
    <li class="nav-item">
      <a id="tab3" onclick="tab_active(3);" style="cursor: pointer;">4 . ข้อมูลรถ   <br />
      </a>
    </li>
    <li class="nav-item">
      <a id="tab4" onclick="tab_active(4);" style="cursor: pointer;">5 . ข้อมูลประกันภัยรถ  <br />
      </a>
    </li>
    <li class="nav-item">
      <a id="tab8" onclick="tab_active(8);" style="cursor: pointer;">6 . ข้อมูลการเข้า-ออกด่านพรมแดน  <br />
      </a>
    </li>

    <li class="nav-item">
      <a id="tab9" onclick="tab_active(9);" style="cursor: pointer;">7 . สรุปผลการตรวจเอกสาร  <br />
      </a>
    </li>

  </ul>
  <%--<br/>--%>

  <ul id="ul2" class="nav nav-pills nav-justified" >
    <li class="nav-item">
      <a id="tab5" onclick="tab_active(5);" style="pointer {cursor: pointer;}">1 . Issue  <br /><asp:CheckBox ID="chktab5" onclick="cf_check('chktab5', 5);" runat="server" Text="" />
      <label id="texttab5" >ตรวจสอบแล้ว</label> 
      </a>
    </li>
    <li class="nav-item">
      <a id="tab6" onclick="tab_active(6);" style="pointer {cursor: pointer;}">2 . Operator  <br /><asp:CheckBox ID="chktab6" onclick="cf_check('chktab6', 6);" runat="server" Text="" />
      <label id="texttab6" >ตรวจสอบแล้ว</label> 
      </a>
    </li>
    <li class="nav-item">
      <a id="tab7" onclick="tab_active(7);" style="pointer {cursor: pointer;}">3 . Vehicle  <br /><asp:CheckBox ID="chktab7" onclick="cf_check('chktab7', 7);" runat="server" Text="" />
      <label id="texttab7" >ตรวจสอบแล้ว</label> 
      </a>
    </li>
  </ul><%--<br/>--%>
  
   

    <div id="formT1"  runat="server">
   
   <div id="formTab0" class="container position-relative w3-padding " >
   
      <div id="xformTab1" class="container position-relative w3-padding  w3-animate-center  col-12 text-dark w3-hide ">
      <div class="w3-border w3-round-large">
<div id="divCompany" runat="server"> 

<div class="w3-row w3-padding-small">
<h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-address-card-o" aria-hidden="true"></i>  ข้อมูลผู้ประกอบการท่องเที่ยว</b></h5>
<%-- <h5 class="headmenu w3-purple2 w3-padding"><b> # ข้อมูลผู้ประกอบการท่องเที่ยว</b></h5>--%>
</div>

<div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อผู้ประกอบการ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcom_name" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        ชื่อ :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblagen_name" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small" style="display:none">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ข้อมูล : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcom_info" runat="server" Text=""></asp:Label>

    </div>


  </div>

    <div class="w3-row w3-padding-small" style="display:none">

     
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ประวัติ :
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblhistory" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        โทรศัพท์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcom_tel" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        E-mail :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblcom_mail" runat="server" Text=""></asp:Label>

    </div>

  </div>

    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่ใบอนุญาตประกอบธุรกิจท่องเที่ยว : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcompany_license" runat="server" Text=""></asp:Label>

    </div>
     

  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ที่อยู่ผู้ประกอบการ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcom_address" runat="server" Text=""></asp:Label>

    </div>

     
  </div>
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
                                        <%--<asp:HyperLink ID="HyperLicensePhotoGuide" NavigateUrl="<%#Eval("regis_photo") %>" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>--%>
                                        <asp:HyperLink ID="HyperLicensePhotoGuide" 
               NavigateUrl='<%# Eval("regis_photo") %>' 
               Target="_blank" runat="server">
    ดูรูปใหญ่
</asp:HyperLink>
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>

             
         </Columns>
          <EmptyDataRowStyle HorizontalAlign="Center" />
           
    </asp:GridView>
     
 
    </div>
 
     
  </div>
 </div>

</div>


  


   
<br />
   <div class="w3-row w3-padding-small" style="display:none">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อ - นามสกุล : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblFLname" runat="server" Text=""></asp:Label>
      <%--  <asp:TextBox ID="txtpassport"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

    </div>


  <div class="w3-row w3-padding-small" style="display:none">
   
  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Email : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblEmailLicense" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtdate" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

    </div>

    <br />
       
        <div id="Exten" runat="server">
         <div class="w3-row w3-padding-small">
          <h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-address-card-o" aria-hidden="true"></i>  ข้อมูลการขอขยายเวลา</b></h5>
          </div>

            <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่เครื่องหมายแสดงการใช้รถ อ้างอิง  : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:HyperLink ID="hlrefer" runat="server" Cssclass="btn-link"></asp:HyperLink>

    </div>
 
     
  </div>

            <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        สาเหตุการขอขยายเวลา  : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblReasonExten" runat="server" Text=""></asp:Label>

    </div>
 
     
  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ไฟล์แนบ  : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <%--<asp:Label ID="Label2" runat="server" Text=""></asp:Label>--%>
        <asp:HyperLink ID="hlFileAttach" runat="server" Cssclass="btn-link"></asp:HyperLink>


             <asp:HiddenField ID="hidfolderAttach" runat="server" />
              <asp:HiddenField ID="HidFname" runat="server" />
              <asp:HiddenField ID="HidSname" runat="server" />
    </div>
 
     
  </div>

  </div>
   </div>

   </div>
      <div class="w3-col l2_3 <% Response.Write(Css)%>" >
        สถานะการตรวจสอบเอกสาร : <br />
         <asp:CheckBox ID="chktabY0" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabY0" >ผ่าน</label> 
        <asp:CheckBox ID="chktabN0" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabN0" >ไม่ผ่าน</label> 
    <br />
    <script type="text/javascript">

   
        $(function () {

            $("#MainContent_chktabY0").change(function () {
                var ischecked = $(this).is(":checked");
   
                if (ischecked) {
                    $("#MainContent_chktabN0").removeAttr("checked");
                }
            });


            $("#MainContent_chktabN0").change(function () {
                var ischecked = $(this).is(":checked");
       
                if (ischecked) {
                    $("#MainContent_chktabY0").removeAttr("checked");
                }
            });

        });
    
    
    </script>

     </div>

     
     
      <div class=" w3-row w3-col l2_3 <% Response.Write(Css)%>" >
        หมายเหตุ (ข้อมูลทั่วไป) :
     </div>
      
    <div class="w3-col l5 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:TextBox ID="txtcomments_tab0" type="text" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>

     </div> 




      <div class=" mt-5 w3-right">
               <a onclick="tab_active(1);" class="w3-button w3-purple2 w3-padding w3-round" >ถัดไป1</a>
            </div>
    </div>

    

    <div id="formTab1" class="container position-relative w3-padding " >
    
   <div class="w3-border w3-round-large">
   <br />
    <%--<br />
    <h5 class="headmenu w3-padding-left">เจ้าของรถ </h5>--%>

    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อเจ้าของรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblowner" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtowner" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อผู้ถือกรรมสิทธิ์" ></asp:TextBox>--%>
    </div>
     
   </div>

  <div class="w3-row w3-padding-small">
   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขบัตรประจำตัวประชาชน : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblowner_id_card" runat="server" Text=""></asp:Label>
      <%-- <asp:TextBox ID="txtowner_id_card" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชนผู้ถือกรรมสิทธิ์" ></asp:TextBox>--%>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ที่อยู่ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

     <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        จังหวัด : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblprovince_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

       <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        รหัสไปรษณีย์ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblzipcode_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

       <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ประเทศ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcountry_owner" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>


   <div class="w3-row w3-padding-small" style="display:none">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        โทรศัพท์  : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_owner" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txttel_owner" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>--%>
    </div>
     


  </div>

     <br />
      <div class=" mt-5 w3-left">
               <a ID="btnPrevTab1" onclick="tab_active(0);" class="w3-button w3-purple2 w3-padding w3-round"  >ก่อนหน้า</a>
       </div>

      <div class="w3-col l2_3 <% Response.Write(Css)%>" >
        สถานะการตรวจสอบเอกสาร : <br />
         <asp:CheckBox ID="chktabY1" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabY1" >ผ่าน</label> 
        <asp:CheckBox ID="chktabN1" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabN1" >ไม่ผ่าน</label> 
    <br />
    <script type="text/javascript">

        // Check Tab 0 ผ่าน หรือ ไม่ผ่าน
        $(function () {

            $("#MainContent_chktabY1").change(function () {
                var ischecked = $(this).is(":checked");

                if (ischecked) {
                    $("#MainContent_chktabN1").removeAttr("checked");
                }
            });


            $("#MainContent_chktabN1").change(function () {
                var ischecked = $(this).is(":checked");

                if (ischecked) {
                    $("#MainContent_chktabY1").removeAttr("checked");
                }
            });

        });
    
    
    </script>

     </div>

     
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเหตุ (ข้อมูลเจ้าของรถ) :
     </div>
      
    <div class="w3-col l5 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:TextBox ID="txtcomments_tab1" type="text" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>
    </div>


     </div>

     

       <div class=" mt-5 w3-right">
               <a ID="btnNextTab1" onclick="tab_active(2);" class="w3-button w3-purple2 w3-padding w3-round" runat="server" >ถัดไป</a>
            </div>

    </div>

  

  <div id="formTab2" class="container position-relative w3-padding" >

    <div class="w3-border w3-round-large">
     
    
<div class="w3-row w3-padding-small">
<h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-address-card-o" aria-hidden="true"></i> ข้อมูลคนขับหลัก</b></h5>
 <%--<h5 class="headmenu w3-purple2 w3-padding"><b> # ข้อมูลคนขับหลัก</b></h5>--%>
</div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
      <%-- <asp:TextBox ID="txtname"   class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อ" ></asp:TextBox>--%>
    </div>

  </div>

   <div class="w3-row w3-padding-small">


   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        สัญชาติ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnational" runat="server" Text=""></asp:Label>

    </div>

     
<div class="w3-col l2 <% Response.Write(Css)%>" >
        เพศ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblgender" runat="server" Text=""></asp:Label>

    </div>

  </div>


   <div class="w3-row w3-padding-small">

        <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        วัน เดือน ปี เกิด : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtexp_license_no" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

   
     
   </div>

       <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่หนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtlicense_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุของหนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblexp_pass_date" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtexp_license_no" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

    </div>

    <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเลขใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtlicense_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblexp_license_no" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtexp_license_no" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

    </div>


     <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ที่อยู่ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_driver" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtaddress_driver"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

</div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        โทรศัพท์  : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_driver" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txttel_driver" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>--%>
    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        Email : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblemail_driver" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtemail_driver" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small" style="DISPLAY: none">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขบัตรประจำตัวประชาชนผู้ขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblid_code" runat="server" Text=""></asp:Label>
      <%-- <asp:TextBox ID="txtid_code"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชน" ></asp:TextBox>--%>
    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        ประเทศของผู้ขับรถ :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblcountry_driver" runat="server" Text=""></asp:Label>

    </div>

  </div>

  

  <div class="w3-row w3-padding-small" id="divIMG_passport" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

       <div class="w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือเดินทาง (เพิ่มเติม) : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_passport2" runat="server" UpdateMode="Conditional">
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


    <div class="w3-row w3-padding-small" id="divIMG_license_no" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ (เพิ่มเติม) : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_license_no2" runat="server" UpdateMode="Conditional">
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

  
    <div class="w3-row w3-padding-small" id="divImg_cer" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Certified translation of driver license   : 
     </div>
      


    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="HyFileCer" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidFileCer" runat="server" />
    </div>
  </div>


  <div class="w3-row w3-padding-small" style="DISPLAY: none" >

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        รายละเอียด : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label>
          <%--<asp:TextBox ID="txtinfo" TextMode="MultiLine" class="w3-input w3-border w3-round-large" runat="server" placeholder="ข้อมูลเกี่ยวกับกำหนดการต่างๆ เช่น สถานที่พัก กำหนดการในแต่ละวัน"></asp:TextBox>--%>
    </div>
     
   </div>

      
 
  <br />


<div class="w3-row w3-padding-small">
<h5 class="fontKanit w3-purple2 w3-padding w3-large"><b><i class="fa fa-address-card-o" aria-hidden="true"></i> ข้อมูลคนขับสำรอง</b></h5>
<%-- <h5 class="headmenu w3-purple2 w3-padding"><b> # ข้อมูลคนขับสำรอง</b></h5>--%>
</div>

 
<div class="w3-border w3-round-large w3-margin "  >
    <br />
    <h5 class="fontKanit w3-large w3-padding-left"><b>คนขับสำรองคนที่ 1 </b></h5>
    <hr style="width: 140px;" />
    



   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblname1" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtname1"   class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อ" ></asp:TextBox>--%>
    </div>
     
    

  </div>

   <div class="w3-row w3-padding-small">


   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        สัญชาติ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnational1" runat="server" Text=""></asp:Label>

    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        เพศ :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblgender1" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small">


   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       หมายเลขใบอนุญาตขับรถ :  
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_no1" runat="server" Text=""></asp:Label>
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุใบอนุญาตขับรถ :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_exp_date_1" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small"  >

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่หนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport1" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpassport1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุหนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport_expire_1" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtexp_pass_date1" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">


   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       ที่อยู่ :  
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_1" runat="server" Text=""></asp:Label>
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        เบอร์โทร :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_1" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small">


   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Email :  
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblemail_1" runat="server" Text=""></asp:Label>
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     
    </div>


  </div>

    <div class="w3-row w3-padding-small" id="div1" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

        <div class="w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือเดินทาง (เพิ่มเติม) : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ (เพิ่มเติม) : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

   <div class="w3-row w3-padding-small" id="divImg_cer2" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Certified translation of driver license   : 
     </div>
      
   

    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="HyFileCer2" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidFileCer2" runat="server" />
    </div>
  </div>
    <br />
  </div>
  <div class="w3-border w3-round-large w3-margin"  >
    <br />
 <h5 class="fontKanit w3-large w3-padding-left"><b>คนขับสำรองคนที่ 2 </b></h5>
    <hr style="width: 140px;" />


   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblname2" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtname2"   class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อ" ></asp:TextBox>--%>
    </div>
     
   
  </div>

   <div class="w3-row w3-padding-small">


   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        สัญชาติ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnational2" runat="server" Text=""></asp:Label>
       
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        เพศ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblgender2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtlicense_no2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small"  >

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเลขใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_no2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpassport2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbllicense_exp_date_2" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtexp_pass_date2" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small"  >

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่หนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpassport2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุหนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpassport_expire_2" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtexp_pass_date2" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">


   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       ที่อยู่ :  
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_2" runat="server" Text=""></asp:Label>
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        เบอร์โทร :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_2" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="หมายเลขใบอนุญาตขับรถ" ></asp:TextBox>--%>
    </div>


  </div>

  <div class="w3-row w3-padding-small">


   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Email :  
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblemail_2" runat="server" Text=""></asp:Label>
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     
    </div>


  </div>

    <div class="w3-row w3-padding-small" id="div3" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายหนังสือเดินทาง (เพิ่มเติม) : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        รูปถ่ายใบอนุญาตขับรถ (เพิ่มเติม) : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

   <div class="w3-row w3-padding-small" id="divImg_cer3" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Certified translation of driver license   : 
     </div>
      
    

    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="HyFileCer3" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidFileCer3" runat="server" />
    </div>
  </div>



 

 
    <br />

      
      
   
  </div>
     

  

 

  <div class="w3-row w3-padding-small" style="DISPLAY: none">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่หนังสือเดินทางรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpass_car" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtpass_car"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>--%>
    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        วันหมดอายุหนังสือเดินทางรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblexp_pass_car_date" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtexp_pass_car_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

     

   <br />
  <div class="w3-border w3-round-large" style="display:none">
    <br />
    <h5 class="headmenu w3-padding-left">เจ้าของรถ </h5>

<div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อเจ้าของรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblholder" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtholder" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อเจ้าของรถ" ></asp:TextBox>--%>
    </div>
     
   
   <div class="w3-col l2 <% Response.Write(Css)%>" >
        เลขบัตรประจำตัวประชาชน : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblholder_id_card" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtholder_id_card" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชนเจ้าของรถ" ></asp:TextBox>--%>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ที่อยู่ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladdress_holder" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtaddress_holder"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>--%>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        โทรศัพท์  : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltel_holder" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txttel_holder" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>--%>
    </div>
     


  </div>

  <br />



     </div>
       <br />
    
     
    </div>

    <div class=" mt-5 w3-left">
               <a ID="btnPrevTab2" onclick="tab_active(1);" class="w3-button w3-purple2 w3-padding w3-round" >ก่อนหน้า</a>
       </div>

 <div class="w3-col l2_3 <% Response.Write(Css)%>" >
        สถานะการตรวจสอบเอกสาร : <br />
         <asp:CheckBox ID="chktabY2" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabY2" >ผ่าน</label> 
        <asp:CheckBox ID="chktabN2" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabN2" >ไม่ผ่าน</label> 
    <br />
    <script type="text/javascript">

        // Check Tab 0 ผ่าน หรือ ไม่ผ่าน
        $(function () {

            $("#MainContent_chktabY2").change(function () {
                var ischecked = $(this).is(":checked");

                if (ischecked) {
                    $("#MainContent_chktabN2").removeAttr("checked");
                }
            });


            $("#MainContent_chktabN2").change(function () {
                var ischecked = $(this).is(":checked");

                if (ischecked) {
                    $("#MainContent_chktabY2").removeAttr("checked");
                }
            });

        });
    
    
    </script>

     </div>

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเหตุ (ข้อมูลคนขับ) :
     </div>
      <div class="w3-col l5 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:TextBox ID="txtcomments_tab2" type="text" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>
    </div>

     <div class=" mt-5 w3-right w3-margin ">
               <a ID="btnNextTab2" onclick="tab_active(3);" class="w3-button w3-purple2 w3-padding w3-round" >ถัดไป</a>
            </div>



     </div>


  <div id="formTab3" class="container position-relative w3-padding" >


<div class="w3-border w3-round-large">
<br />
<div id="divCar" runat="server" >


<div class="w3-row w3-padding-small">
  
     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ยี่ห้อ :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblbrands" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtbrands" class="w3-input w3-border w3-round-large" runat="server" placeholder="ยี่ห้อ" ></asp:TextBox>--%>
    </div>

        <div class="w3-col l2 <% Response.Write(Css)%>" >
        รุ่นรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblmodels" runat="server" Text=""></asp:Label>
       <%--<asp:TextBox ID="txtmodels" class="w3-input w3-border w3-round-large" runat="server" placeholder="รุ่นรถ" ></asp:TextBox>--%>
    </div>

  </div>


  <div class="w3-row w3-padding-small">

      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        สี :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcolors" runat="server" Text=""></asp:Label>
    
     
    </div>
     
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
      จำนวนที่นั่ง :  
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblSeats" runat="server" Text=""></asp:Label>

    
        <%--<asp:TextBox ID="txtcolors" class="w3-input w3-border w3-round-large" runat="server" placeholder="สี" ></asp:TextBox>--%>
    </div>

  </div>


  <div class="w3-row w3-padding-small" id="divCar_1" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ประเทศที่จดทะเบียน :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
   <asp:Label ID="lblcountry_car" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtplate" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขทะเบียนรถ" ></asp:TextBox>--%>
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        จังหวัดที่จดทะเบียน :

     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblprovince_car" runat="server" Text=""></asp:Label>
    </div>
     
      
  </div>


  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขทะเบียนรถ (Local) :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblplatelocal" runat="server" Text=""></asp:Label>
    
        <%--<asp:TextBox ID="txtplate" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขทะเบียนรถ" ></asp:TextBox>--%>
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
         เลขทะเบียนรถ  (ENG) :

     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblplate" runat="server" Text=""></asp:Label>
   
    </div>
     
      
  </div>

  <div class="w3-row w3-padding-small" id="divCar_2" runat="server">

       <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       เลขเครื่องยนต์ :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblNumEngine" runat="server" Text=""></asp:Label>
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
         ความจุกระบอกสูบ :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblEngine_cap" runat="server" Text=""></asp:Label>
    </div>
     
  </div>


  <div class="w3-row w3-padding-small" id="divCar_3" runat="server">


      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขตัวรถ :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblnumcar" runat="server" Text=""></asp:Label>
       <%-- <asp:TextBox ID="txtnumcar" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขตัวรถ" ></asp:TextBox>--%>
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        น้ำหนักรวม :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblweight" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtEngine_cap" class="w3-input w3-border w3-round-large" runat="server" placeholder="ความจุกระบอกสูบ" ></asp:TextBox>--%>
    </div>

  </div>

   

  <div class="w3-row w3-padding-small" id="divIMG_regis_photo" runat="server"  >

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ภาพถ่ายหนังสือการจดทะเบียนรถ :  
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        ภาพถ่ายหนังสือการจดทะเบียนรถ : 
        <br/> (เพิ่มเติม) &nbsp;
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
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

<div class="w3-row w3-padding-small" id="divIMG_authorize_car" runat="server"  >

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ภาพถ่ายหนังสือมอบอำนาจยินยอม : 
<br/>ให้ใช้รถ (*กรณีไม่ใช่เจ้าของรถ) &nbsp; 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        ภาพถ่ายหนังสือมอบอำนาจยินยอมให้ : 
 <br/>ใช้รถ(*กรณีไม่ใช่เจ้าของรถ) (เพิ่มเติม)  &nbsp; 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
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


  <div class="w3-row w3-padding-small" id="divIMG_Cer_car" runat="server"  >

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
            Certified translation of vehicle registration
     </div>
      
    

    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">

        <%--<asp:HyperLink ID="HyFileCer" runat="server" Cssclass="btn-link"></asp:HyperLink>--%>
            <asp:HyperLink ID="linkCar_cer" CssClass="w3-text-purple"  runat="server">ดูไฟล์ </asp:HyperLink>
             <asp:HiddenField ID="hidPhotonamecar_cer" runat="server" />
    </div>
  </div>



  <div class="w3-row w3-padding-small" id="divIMG_inspec_car" runat="server"  >

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
            หนังสือรับรองการตรวจสภาพรถ 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

   
    <div class="w3-row w3-padding-small" id="divIMG_car" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        รูปถ่ายตัวรถ : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
       <asp:UpdatePanel ID="UpdgvIMG_car" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <asp:DataList ID="DtlImg_car" runat="server" CellPadding="4" 
                    DataKeyField="gid" ForeColor="#333333" Width="100%"
                            RepeatDirection="Horizontal">
                    
                    <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                           <ItemTemplate>
                               <table  style="width: 120px; height: 150px;">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile" Height="150px" runat="server" ImageUrl='<%# Bind("PathImg") %>' /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("LinkImg") %>' Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                 </td> </tr>
                               </table>
                           </ItemTemplate>
                </asp:DataList>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>

    </div>
  </div>

    

    

    <div class="w3-row w3-padding-small" style="DISPLAY: none">
  
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
         รุ่นรถปี ค.ศ. : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblyears" runat="server" Text=""></asp:Label>
       
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    
        <%--<asp:TextBox ID="txtweight" class="w3-input w3-border w3-round-large" runat="server" placeholder="น้ำหนัก" ></asp:TextBox>--%>
    </div>

  </div>

    

     <div class="w3-row w3-padding-small" style="DISPLAY: none">

       <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ประเภทรถ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbltypecar" runat="server" Text=""></asp:Label>
     
    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
         
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    
     <%--<asp:TextBox ID="txtNumEngine" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขเครื่อง" ></asp:TextBox>--%>
    </div>
     
  </div>


    

  </div>
<br />




   <div class=" mt-5 w3-left">
               <a ID="btnPrevTab3" onclick="tab_active(2);" class="w3-button w3-purple2 w3-padding w3-round" >ก่อนหน้า</a>
       </div>

      <div class="w3-col l2_3 <% Response.Write(Css)%>" >
        สถานะการตรวจสอบเอกสาร : <br />
         <asp:CheckBox ID="chktabY3" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabY3" >ผ่าน</label> 
        <asp:CheckBox ID="chktabN3" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabN3" >ไม่ผ่าน</label> 
    <br />
    <script type="text/javascript">

        // Check Tab 0 ผ่าน หรือ ไม่ผ่าน
        $(function () {

            $("#MainContent_chktabY3").change(function () {
                var ischecked = $(this).is(":checked");
     
                if (ischecked) {
                    $("#MainContent_chktabN3").removeAttr("checked");
                }
            });


            $("#MainContent_chktabN3").change(function () {
                var ischecked = $(this).is(":checked");
        
                if (ischecked) {
                    $("#MainContent_chktabY3").removeAttr("checked");
                }
            });

        });
    
    
    </script>

     </div>

     
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเหตุ (ข้อมูลรถ) :
     </div>
      
    <div class="w3-col l5 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:TextBox ID="txtcomments_tab3" type="text" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>
    </div>


     </div>

     

       <div class=" mt-5 w3-right">
               <a ID="btnNextTab3" onclick="tab_active(4)" class="w3-button w3-purple2 w3-padding w3-round"  >ถัดไป</a>
            </div>
 

 
  </div>

    <div id="formTab4" class="container position-relative w3-padding">
    
    <div class="w3-border w3-round-large">

    <br />

      <div class="w3-col w3-left ml-5" >
      <a><b class="fontKanit w3-large">Compulsory motor vehicle insurance (พรบ.)</b> </a>
     </div>


    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อบริษัทกรมธรรม์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcompany" runat="server" Text=""></asp:Label>
    
        <%--<asp:TextBox ID="txtinsure_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขที่กรมธรรม์ประกันภัย" ></asp:TextBox>--%>
    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        เลขที่กรมธรรม์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinsure_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcompany" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อบริษัท" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        วันเริ่มต้นกรมธรรม์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblstart_date" runat="server" Text=""></asp:Label>
         <%--<asp:TextBox ID="txtstart_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        วันสิ้นสุดกรมธรรม์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblend_date" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblexp_note" runat="server" Text="*กรมธรรม์ไม่ครอบคลุมวันที่เดินทาง" ForeColor="Red"></asp:Label>
        <%--<asp:TextBox ID="txtend_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small" style="DISPLAY: none">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อผู้เอาประกันภัย : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinsure_name" runat="server" Text=""></asp:Label>
         <%--<asp:TextBox ID="txtinsure_name"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อผู้เอาประกันภัย"></asp:TextBox>--%>
    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        เลขตัวถัง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblcar_no" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcar_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขตัวถัง"></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small" id="divIMG_act_photo" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ภาพถ่ายหนังสือกรมธรรม์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        ภาพถ่ายหนังสือกรมธรรม์ (เพิ่มเติม) : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

    <br />
    
      <div class="w3-col w3-left ml-5" >
      <a><b class="fontKanit w3-large">Third-party liability motor vehicle insurance (ประกันภัยชั้น 3 ระบุวงเงินคุ้มครองตามข้อ 5)</b> </a>
     </div>


    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อบริษัทกรมธรรม์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblcompany2" runat="server" Text=""></asp:Label>
    
        <%--<asp:TextBox ID="txtinsure_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขที่กรมธรรม์ประกันภัย" ></asp:TextBox>--%>
    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        เลขที่กรมธรรม์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinsure_no2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcompany" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อบริษัท" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        วันเริ่มต้นกรมธรรม์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblstart_date2" runat="server" Text=""></asp:Label>
         <%--<asp:TextBox ID="txtstart_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        วันสิ้นสุดกรมธรรม์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblend_date2" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblexp_note2" runat="server" Text="*กรมธรรม์ไม่ครอบคลุมวันที่เดินทาง" ForeColor="Red"></asp:Label>
        <%--<asp:TextBox ID="txtend_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small" style="DISPLAY: none">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อผู้เอาประกันภัย : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblinsure_name2" runat="server" Text=""></asp:Label>
         <%--<asp:TextBox ID="txtinsure_name"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อผู้เอาประกันภัย"></asp:TextBox>--%>
    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
        เลขตัวถัง : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblcar_no2" runat="server" Text=""></asp:Label>
        <%--<asp:TextBox ID="txtcar_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขตัวถัง"></asp:TextBox>--%>
    </div>

  </div>

    <div class="w3-row w3-padding-small" id="divIMG_act_photo2" runat="server">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ภาพถ่ายหนังสือกรมธรรม์ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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

    <div class="w3-col l2 <% Response.Write(Css)%>" >
        ภาพถ่ายหนังสือกรมธรรม์ (เพิ่มเติม) : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
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
  <asp:HiddenField ID="Hidchkact" runat="server" />
  <br />
    <div class=" mt-5 w3-left">
               <a ID="btnPrevTab4" onclick="tab_active(3);" class="w3-button w3-purple2 w3-padding w3-round"  >ก่อนหน้า</a>
       </div>

      <div class="w3-col l2_3 <% Response.Write(Css)%>" >
        สถานะการตรวจสอบเอกสาร : <br /> <asp:Label ID="lbltab4Check" runat="server" ></asp:Label>
         <asp:CheckBox ID="chktabY4" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabY4" runat="server" >ผ่าน</label> 
        <asp:CheckBox ID="chktabN4" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabN4" runat="server" >ไม่ผ่าน</label> 
    <br />
    <script type="text/javascript">

        // Check Tab 0 ผ่าน หรือ ไม่ผ่าน
        $(function () {

            $("#MainContent_chktabY4").change(function () {

                if (document.getElementById("MainContent_Hidchkact").value == 1) {
                    alert('ไม่สามารถอนุมัติได้ เนื่องจากกรมธรรม์ไม่ครอบคลุมวันที่เดินทาง');
                    $("#MainContent_chktabY4").removeAttr("checked");
                }
                else {
                    var ischecked = $(this).is(":checked");
                    if (ischecked) {
                        $("#MainContent_chktabN4").removeAttr("checked");
                    }
                }

            });


            $("#MainContent_chktabN4").change(function () {
                var ischecked = $(this).is(":checked");
                if (ischecked) {
                    $("#MainContent_chktabY4").removeAttr("checked");
                }
            });

        });
    
    
    </script>

     </div>

     
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเหตุ (ข้อมูล พรบ.) :
     </div>
      
    <div class="w3-col l5 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:TextBox ID="txtcomments_tab4" type="text" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>
    </div>


     </div>

     

       <div class=" mt-5 w3-right">
               <a ID="btnNextTab4" onclick="tab_active(8);" class="w3-button w3-purple2 w3-padding w3-round" >ถัดไป</a>
            </div>
    </div>

    <div id="formTab8" class="container position-relative w3-padding">

      <div class="w3-border w3-round-large">
       <br />
        <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ด่านพรมแดนขาเข้า : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblBorderCheckin" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
      ด่านพรมแดนขาออก :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblBorderCheckout" runat="server" Text=""></asp:Label>

    </div>

  </div>

   <div class="w3-row w3-padding-small" id="div_admin" runat="server">
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       สถานที่รับเอกสาร : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lbladmin_name" runat="server" Text=""></asp:Label>
 
    </div>

       
    <div class="w3-col l3 <% Response.Write(Css)%>" >
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
       จังหวัดใช้ยานพาหนะ : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
    <asp:Label ID="lblpro_area_use" runat="server" Text=""></asp:Label>
    
    </div>

    <div class="w3-col l3 <% Response.Write(Css)%>" >
         
     </div>

     <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">

            <asp:HyperLink ID="lnkMap" CssClass="w3-text-purple"  runat="server">ดูแผนที่ </asp:HyperLink>
 
    </div>
 
   </div>


   <div class="w3-row w3-padding-small" id="div_map" runat="server">
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
         
     </div>
      

       
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>"    >

    <iframe runat="server" id="iframeMap" enableviewstate="true" frameborder="0"  style="width:380px; height:280px;"  name="IframeLocation" scrolling="yes" 
          src="../Map/MapArea.aspx?pro=-1" >Your browser does not support iframes 
    </iframe>
  
    </div>



    <script  type='text/javascript'>
        $(document).ready(function () {




            var dv = document.getElementById("MainContent_div_map").offsetWidth;

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
                iFrame.style.width = (dv * 0.6) + 'px';
                iFrame.style.height = (dv * 0.6) + 'px';
            }
        });

        function get_IframeMaps(pro) {
            document.getElementById('MainContent_iframeMap').src = '../Map/MapArea.aspx?pro=' + pro;
        }
        function get_IframeMap(pro) {
            document.getElementById('MainContent_iframeMap').src = document.getElementById('MainContent_iframeMap').src + ',' + pro;
        }

        function get_IframeMapDel(pro) {
            document.getElementById('MainContent_iframeMap').src = document.getElementById('MainContent_iframeMap').src.replace("," + pro, "");
        }
    </script>

   </div>

       <br />

           <div class=" mt-5 w3-left">
               <a ID="btnPrevTab8" onclick="tab_active(4);" class="w3-button w3-purple2 w3-padding w3-round" >ก่อนหน้า</a>
       </div>

      <div class="w3-col l2_3 <% Response.Write(Css)%>" >
        สถานะการตรวจสอบเอกสาร : <br />
         <asp:CheckBox ID="chktabY8" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabY8" >ผ่าน</label> 
        <asp:CheckBox ID="chktabN8" OnClientClick="showProgress()" runat="server" Text="" />
        <label id="texttabN8" >ไม่ผ่าน</label> 
    <br />
    <script type="text/javascript">

        // Check Tab 0 ผ่าน หรือ ไม่ผ่าน
        $(function () {

            $("#MainContent_chktabY8").change(function () {
                var ischecked = $(this).is(":checked");
                if (ischecked) {
                    $("#MainContent_chktabN8").removeAttr("checked");
                }
            });


            $("#MainContent_chktabN8").change(function () {
                var ischecked = $(this).is(":checked");
                if (ischecked) {
                    $("#MainContent_chktabY8").removeAttr("checked");
                }
            });

        });
    
    
    </script>

     </div>

     
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        หมายเหตุ (ข้อมูลการเข้า-ออกด่านพรมแดน) :
     </div>
      
    <div class="w3-col l5 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:TextBox ID="txtcomments_tab8" type="text" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>
    </div>

    <div class=" mt-5 w3-right">
               <a onclick="tab_active(9);" class="w3-button w3-purple2 w3-padding w3-round" >ถัดไป</a>
            </div>

      </div>
    </div>


       <div id="formTab9" class="container position-relative w3-padding">

      <div class="w3-border w3-round-large">

        <div class="w3-col l12  w3-left-align fontKanit " >
                <h3 style=" margin-left: 5%;">สรุปผลการตรวจประเมิน</h3>
         </div>

        

    <div class="w3-row w3-padding-small" runat="server">
      <div class="w3-col l2_2  <% Response.Write(Css)%>" >
      1. ข้อมูลทั่วไป :
     </div>
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lbltab0" runat="server" Text=""></asp:Label>
    </div>
   </div>

     <div class="w3-row w3-padding-small" runat="server">
      <div class=" w3-col l2_2 <% Response.Write(Css)%>" >
      2. ข้อมูลเจ้าของรถ :
     </div>
    <div class=" w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lbltab1" runat="server" Text=""></asp:Label>
    </div>
   </div>

   <div class="w3-row w3-padding-small" runat="server">
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       3. ข้อมูลคนขับ : 
     </div>
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lbltab2" runat="server" Text=""></asp:Label>
    </div>
   </div>

      <div class="w3-row w3-padding-small" runat="server">
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       4. ข้อมูลรถ : 
     </div>
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lbltab3" runat="server" Text=""></asp:Label>
    </div>
   </div>

  <div class="w3-row w3-padding-small" runat="server">
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       5. ข้อมูล พรบ. : 
     </div>
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lbltab4" runat="server" Text=""></asp:Label>
    </div>
   </div>

     <div class="w3-row w3-padding-small" runat="server">
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       6. ข้อมูลการเข้า-ออกด่านพรมแดน : 
     </div>
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lbltab8" runat="server" Text=""></asp:Label>
    </div>
   </div>

       <br />
        <div class="w3-row w3-padding-large w3-center">
            <asp:Button ID="btnSubmitY" class="w3-button w3-large w3-green w3-padding w3-round" runat="server" text="อนุมัติ" />
           <%-- <asp:Button ID="btnSubmitN" class="w3-button w3-large w3-purple2 w3-padding w3-round" runat="server" text="ไม่อนุมัติ" ></asp:Button>--%>
            <asp:Button ID="btnSubmitSend" class="w3-button w3-large w3-red w3-padding w3-round" runat="server" text="เอกสารไม่สมบูรณ์" ></asp:Button>
       <br />
      </div>
      </div>
    </div>



   </div>






    <div id="formT2" runat="server" visible=false>

    <div id="form2Tab1" class="container position-relative w3-padding" >


<div class="w3-border w3-round-large"> 
 <br />
<div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Permit Number : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblpermit_no" runat="server" Text=""></asp:Label>

    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
       Place of Issue : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblissue_place" runat="server" Text=""></asp:Label>

    </div>
     
      

  </div>
 
  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Issue Date :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblissue_date" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        Expiry Date (Valid Until) :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblexpiry_date" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Extended Until : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblextended_until" runat="server" Text=""></asp:Label>

    </div>

    <div class="w3-col l2 <% Response.Write(Css)%>" >
       Motor Vehicle TAD Number : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lbltad_no" runat="server" Text=""></asp:Label>

    </div>
    

  </div>

    <div class="w3-row w3-padding-small">

      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Issuing Authority :
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblissuing_authority" runat="server" Text=""></asp:Label>

    </div>
      
  </div>
  <br />
  </div>

  </div>

  <div id="form2Tab2" class="container position-relative w3-padding" >
  <div class="w3-border w3-round-large"> 
 <br />
 

   <div class="w3-row w3-padding-small">

   
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Name of Transport Operator :
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lbltransport_operator_name" runat="server" Text=""></asp:Label>

    </div>

  </div>
   
      <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
      Address : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lbladdress" runat="server" Text=""></asp:Label>

    </div>

  </div>

     <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Province : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblprovince" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Telephone :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lbltelephone" runat="server" Text=""></asp:Label>

    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       E-mail : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>

    </div>
     

  </div>
  <br />
  <div class="w3-border w3-round-large">
    <br />
    <h5 class="headmenu w3-padding-left"> If different from Operator  </h5>

     <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Name of Vehicle Owner : 
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvehicle_owner_name" runat="server" Text=""></asp:Label>

    </div>
     
      

  </div>

  <div class="w3-row w3-padding-small">

   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Address :
     </div>
      
    <div class="w3-col l8 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblvehicle_owner_address" runat="server" Text=""></asp:Label>

    </div>
  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
      Province : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvehicle_owner_province" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Telephone :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblvehicle_owner_telephone" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       E-mail : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvehicle_owner_email" runat="server" Text=""></asp:Label>

    </div>
     

  </div>
  <br />
  </div>
   <br />
  </div>
  </div>

  <div id="form2Tab3" class="container position-relative w3-padding" >
  

<div class="w3-border w3-round-large"> 
 <br />

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
      Type of Vehicle : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvehicle_type" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Registration Number :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblregistration_no" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
      Vehicle Category : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvehicle_category" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Date of Registration :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblregis_date" runat="server" Text=""></asp:Label>

    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
      Registered at Province : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblregis_province" runat="server" Text=""></asp:Label>

    </div>

     <div class="w3-col l2 <% Response.Write(Css)%>" >
      Semi-trailer : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblsemi_trailer" runat="server" Text=""></asp:Label>

    </div>
    

    </div>

    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
     Brand : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblbrand" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Model :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblmodel" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
     VIN Number : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblvin_no" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Engine Number :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblengine_no" runat="server" Text=""></asp:Label>

    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
    Number of Axles : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblaxles_no" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Colour :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblcolour" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
    Capacity in CC : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblcapacity_cc" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Gross Weight in Kg :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblweight_gross" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
    Net Weight in Kg : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblweight_net" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Number of Seats (for Bus) :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lblseats_no" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
    Width in Metres : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblwidth" runat="server" Text=""></asp:Label>

    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
       Length in Metres :
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
     <asp:Label ID="lbllength" runat="server" Text=""></asp:Label>

    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
    Height in Metres : 
     </div>
      
    <div class="w3-col l3 w3-padding-top <% Response.Write(Css_Ctrl)%>">
        <asp:Label ID="lblheight" runat="server" Text=""></asp:Label>

    </div>
     
  </div>

   <br />
  </div>
  </div>
  </div>









    </form>


    <asp:Panel ID="PnChk" style="DISPLAY: none" runat="server" >
        <asp:HiddenField id="HidTab" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="HidTabNow" runat="server"></asp:HiddenField> 
        <asp:Button style="DISPLAY: none" id="BtnSave" runat="server" UseSubmitBehavior="false" ></asp:Button>
        <asp:Button style="DISPLAY: none" id="BtnSave2" runat="server" UseSubmitBehavior="false" ></asp:Button>
       
</asp:Panel>
</asp:Content>

