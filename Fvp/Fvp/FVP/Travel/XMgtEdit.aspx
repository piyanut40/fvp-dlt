<%@ Page Language="VB" AutoEventWireup="false" CodeFile="XMgtEdit.aspx.vb" MasterPageFile="~/MasterPageC.master" Inherits="Travel_XMgtEdit" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">

 <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
 <script src="../Scripts/jquery-ui.js"></script>  

</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="w3-container " style="padding-top:22px">
    <h4 class="headtxt"><b>Edit Application</b></h4>
</div>

<script type="text/javascript">

    //$.datepicker.regional['th'] = {
    //   closeText: "ปิด",
    //	prevText: "&#xAB;&#xA0;ย้อน",
    //	nextText: "ถัดไป&#xA0;&#xBB;",
    //	currentText: "วันนี้",
    //	monthNames: [ "มกราคม","กุมภาพันธ์","มีนาคม","เมษายน","พฤษภาคม","มิถุนายน",
    //	"กรกฎาคม","สิงหาคม","กันยายน","ตุลาคม","พฤศจิกายน","ธันวาคม" ],
    //	monthNamesShort: [ "ม.ค.","ก.พ.","มี.ค.","เม.ย.","พ.ค.","มิ.ย.",
    //	"ก.ค.","ส.ค.","ก.ย.","ต.ค.","พ.ย.","ธ.ค." ],
    //	dayNames: [ "อาทิตย์","จันทร์","อังคาร","พุธ","พฤหัสบดี","ศุกร์","เสาร์" ],
    //	dayNamesShort: [ "อา.","จ.","อ.","พ.","พฤ.","ศ.","ส." ],
    //	dayNamesMin: [ "อา.","จ.","อ.","พ.","พฤ.","ศ.","ส." ],
    //	weekHeader: "Wk",
    //	dateFormat: "dd/mm/yy",
    //	firstDay: 0,
    //	isRTL: false,
    //	showMonthAfterYear: false
    //};

    //$.datepicker.setDefaults($.datepicker.regional['th']);

    //    $(function () {
    //        $("#<%=txtDate.ClientID %>").datepicker({
    //            changeMonth: true,
    //            changeYear: true,
    //            yearRange: "-100:-15",
    //            showButtonPanel: true, 
    //        });
    //    });



    function tab_active(_tab) {
        var _tab1 = document.getElementById("tab1");
        var _tab2 = document.getElementById("tab2");
        var _tab3 = document.getElementById("tab3");
        var _tab4 = document.getElementById("tab4");
        var _tab5 = document.getElementById("tab5");
        var _tab6 = document.getElementById("tab6");

        var _form1 = document.getElementById("formT1");
        var _form2 = document.getElementById("formT2");
        var _form3 = document.getElementById("formT3");
        var _form4 = document.getElementById("formT4");
        var _form5 = document.getElementById("formT5");
        var _form6 = document.getElementById("formT6");

        var _tab_active = "nav-link w3-purple2 active ";
        var _tab_hide = "nav-link w3-purple3";
        var _tab_complete = "completed";
        var _tab_active2 = "active";
        var _form_active = "w3-animate-center col-12 text-dark w3-padding w3-white ";
        var _form_hide = "w3-animate-center  col-12 text-dark w3-hide ";


        if (_tab == 1) {

            _tab1.className = _tab_active;
            _tab2.className = _tab_hide;
            _tab3.className = _tab_hide;
            _tab4.className = _tab_hide;
            _tab5.className = _tab_hide;
            _tab6.className = _tab_hide;

            _form1.className = _form_active;
            _form2.className = _form_hide;
            _form3.className = _form_hide;
            _form4.className = _form_hide;
            _form5.className = _form_hide;
            _form6.className = _form_hide;
        }
        else if (_tab == 2) {
            _tab1.className = _tab_hide;
            _tab2.className = _tab_active;
            _tab3.className = _tab_hide;
            _tab4.className = _tab_hide;
            _tab5.className = _tab_hide;
            _tab6.className = _tab_hide;

            _form1.className = _form_hide;
            _form2.className = _form_active;
            _form3.className = _form_hide;
            _form4.className = _form_hide;
            _form5.className = _form_hide;
            _form6.className = _form_hide;
        }
        else if (_tab == 3) {
            _tab1.className = _tab_hide;
            _tab2.className = _tab_hide;
            _tab3.className = _tab_active;
            _tab4.className = _tab_hide;
            _tab5.className = _tab_hide;
            _tab6.className = _tab_hide;

            _form1.className = _form_hide;
            _form2.className = _form_hide;
            _form3.className = _form_active;
            _form4.className = _form_hide;
            _form5.className = _form_hide;
            _form6.className = _form_hide;
        }
        else if (_tab == 4) {
            _tab1.className = _tab_hide;
            _tab2.className = _tab_hide;
            _tab3.className = _tab_hide;
            _tab4.className = _tab_active;
            _tab5.className = _tab_hide;
            _tab6.className = _tab_hide;

            _form1.className = _form_hide;
            _form2.className = _form_hide;
            _form3.className = _form_hide;
            _form4.className = _form_active;
            _form5.className = _form_hide;
            _form6.className = _form_hide;
        }
        else if (_tab == 5) {
            _tab1.className = _tab_hide;
            _tab2.className = _tab_hide;
            _tab3.className = _tab_hide;
            _tab4.className = _tab_hide;
            _tab5.className = _tab_active;
            _tab6.className = _tab_hide;

            _form1.className = _form_hide;
            _form2.className = _form_hide;
            _form3.className = _form_hide;
            _form4.className = _form_hide;
            _form5.className = _form_active;
            _form6.className = _form_hide;
        }
        else if (_tab == 6) {
            _tab1.className = _tab_hide;
            _tab2.className = _tab_hide;
            _tab3.className = _tab_hide;
            _tab4.className = _tab_hide;
            _tab5.className = _tab_hide;
            _tab6.className = _tab_active;

            _form1.className = _form_hide;
            _form2.className = _form_hide;
            _form3.className = _form_hide;
            _form4.className = _form_hide;
            _form5.className = _form_hide;
            _form6.className = _form_active;
        }

    }

    function SaveSuccess() {

        alert("Save Information Success");
        tab_active(3);

    }

    function fromCheck(type) {
        var _str;
        if (type == 1) {
            _str = 'Please fill up this form !!!';
        }
        else {
            _str = 'Please Upload Photo !!!';
        }

        alert(_str);

    }

    function Error() {

        alert('Save Error Please Try again !!!');

    }

    function formatComma(input) {
        var num = input.value.replace(/\,/g, '');
        if (!isNaN(num)) {
            if (num > 0) {
                if (num.indexOf('.') > -1) {
                    num = num.split('.');
                    num[0] = num[0].toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1,').split('').reverse().join('').replace(/^[\,]/, '');
                    if (num[1].length > 3) {
                        alert('มีทศนิยมได้3ตำแหน่งเท่านั้น');
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
            alert('Please enter the number ');
            input.value = 0; // oldvalue;
        }
    }

    $(function () {
        $("#<%=txtexp_pass_date.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });

        $("#<%=txtexp_license_no.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });

        $("#<%=txtexp_license_no1.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });

        $("#<%=txtexp_license_no2.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });

        $("#<%=txtdate.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-80:-15",
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });

        $("#<%=txtexp_pass_date1.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });

        $("#<%=txtexp_pass_date2.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });

        $("#<%=txtexp_pass_car_date.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });

        $("#<%=txtstart_date.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });

        $("#<%=txtend_date.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-5 :+20",
            showButtonPanel: true,
            dateFormat: 'mm/dd/yy'
        });
    });
</script>
 

<div class="container col-12  position-relative w3-padding w3-white w3-padding-top32">
    <form id="Form1" class="form-horizontal" align="center">     
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
           </asp:ScriptManager>
 <asp:HiddenField ID="hiddriver_id" runat="server" />
 <asp:HiddenField ID="hidcar_id" runat="server" />
 <asp:HiddenField ID="hidact_id" runat="server" />
 <asp:HiddenField ID="hidlicense_id" runat="server" />
 <asp:HiddenField ID="hidsparedriver_id1" runat="server" />
 <asp:HiddenField ID="hidsparedriver_id2" runat="server" />
 <asp:HiddenField ID="hidProvince" runat="server" />
  <ul class="nav nav-pills nav-justified">
    <li class="nav-item" >
      <a id="tab1" >1 . MAIN DRIVER <br /> &nbsp;</a>
    </li>
    <li class="nav-item">
      <a id="tab2" >2 . RESERVE DRIVER <br /> &nbsp;</a>
    </li>
    <li class="nav-item">
      <a id="tab3" >3 . VEHICLE <br /> &nbsp;</a>
    </li>
    <li class="nav-item">
      <a id="tab4" >4 . COMPULSORY MOTOR INSURANCE</a>
    </li>
    <li class="nav-item" style="display:none; " >
      <a id="tab5" >5 . FILES</a>
    </li>
    <li class="nav-item" >
      <a id="tab6" >5 . BORDER <br /> &nbsp;</a>
    </li>
  </ul><br/>

 <%-- <ul class="nav nav-pills nav-justified">
    <li class="nav-item">
      <a id="tab1" href="javascript:tab_active(1);">1 . ข้อมูลคนขับหลัก</a>
    </li>
    <li class="nav-item">
      <a id="tab2" href="javascript:tab_active(2);">2 . ข้อมูลคนขับสำรอง</a>
    </li>
    <li class="nav-item">
      <a id="tab3" href="javascript:tab_active(3);">3 . ข้อมูลรถ</a>
    </li>
    <li class="nav-item">
      <a id="tab4" href="javascript:tab_active(4);">4 . ข้อมูลพรบ.</a>
    </li>
    <li class="nav-item" style="display:none; " >
      <a id="tab5" href="javascript:tab_active(5);">5 . แนบไฟล์ประกอบ</a>
    </li>
    <li class="nav-item" >
      <a id="tab6" href="javascript:tab_active(6);">5 . ข้อมูลการเข้า-ออกด่านพรมแดน</a>
    </li>
  </ul><br/>--%>

     <div id="formT1" class="container position-relative w3-padding">

    
  <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Title : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:RadioButtonList ID="rdoprename" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="Mr.">Mr.</asp:ListItem>
            <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
            <asp:ListItem Value="other">other</asp:ListItem>
        </asp:RadioButtonList>
    </div>

   <div class="w3-col l3 <% Response.Write(Css)%>" >
        Etc. :     
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtprename"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Etc." ></asp:TextBox>
    </div>

  </div>
     <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Name : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtname"   class="w3-input w3-border w3-round-large" runat="server" placeholder="Name" ></asp:TextBox>
    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
        Last Name :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtsurname" class="w3-input w3-border w3-round-large" runat="server" placeholder="Last Name" ></asp:TextBox>
    </div>

  </div>
    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Driver ID Card No. : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtid_code"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver ID Card No." ></asp:TextBox>
    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
        Nationality :
     </div>
      
    <div class="w3-col l3 ">
     <asp:DropDownList ID="ddlnational" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
         
    </div>

  </div>

  <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Passport No. : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtpassport"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport No." ></asp:TextBox>
    </div>

     <div class="w3-col l3 <% Response.Write(Css)%>" >
        Passport Expiry Date : 
     </div>
      
    <div class="w3-col l3 ">
        <%--<asp:TextBox ID="txtexp_pass_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
        <asp:TextBox ID="txtexp_pass_date" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>
    </div>

  </div>

  <%-- <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       รูปถ่ายหนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l3 ">
         <iframe id="Iframe_passport" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FilePhotoDriver&type=Passport&support=IMG" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l8 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvIMG_passport" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                     <table id="tbpassport_img" runat="server"  style="width: 225px; height: 150px;">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile_passport" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Link_passport" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="ImgDelete_passport" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_passport_Command"  /></td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel_passport" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFNameIMG_passport" runat="server" />
                        <asp:HiddenField ID="hidSNameIMG_passport" runat="server" />
                        
                        <asp:Button ID="btnUploadedIMG_passport" runat="server" CausesValidation="False"  onclick="btnUploadedIMG_passport_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploadedIMG_passport" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>--%>


   <div class="w3-row w3-padding-small">


   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Gender : 
     </div>
      
    <div class="w3-col l3 ">
     <asp:DropDownList ID="ddlgender" runat="server" class="w3-input w3-border w3-round-large"> 
               <asp:ListItem Value="M">Male</asp:ListItem>
               <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:DropDownList>
    </div>

     <div class="w3-col l3 <% Response.Write(Css)%>" >
        Birth Date : 
     </div>
      
    <div class="w3-col l3 ">
        <%--<asp:TextBox ID="txtdate" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
        <asp:TextBox ID="txtdate" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>
    </div>


  </div>

  <div class="w3-row w3-padding-small" style="display:none;">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        รายละเอียด : 
     </div>
      
    <div class="w3-col l9 ">
          <asp:TextBox ID="txtinfo" TextMode="MultiLine" class="w3-input w3-border w3-round-large" runat="server" placeholder="ข้อมูลเกี่ยวกับกำหนดการต่างๆ เช่น สถานที่พัก กำหนดการในแต่ละวัน"></asp:TextBox>
    </div>
     
   </div>


    <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Driver License No. : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtlicense_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License No." ></asp:TextBox>
    </div>

     <div class="w3-col l3 <% Response.Write(Css)%>" >
        Driver License Expiry Date : 
     </div>
      
    <div class="w3-col l3 ">
        <%--<asp:TextBox ID="txtexp_license_no" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
        <asp:TextBox ID="txtexp_license_no" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>
    </div>

    </div>

<%--       <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       รูปถ่ายใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l3 ">
         <iframe id="Iframe_license" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FilePhotoDriver&type=License&support=IMG" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l8 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvIMG_license" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                     <table id="tblicense_img" runat="server" style="width: 225px; height: 150px;" >
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile_license" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Link_license" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="ImgDelete_license" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_license_Command"  /></td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel_license" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFNameIMG_license" runat="server" />
                        <asp:HiddenField ID="hidSNameIMG_license" runat="server" />
                        
                        <asp:Button ID="btnUploadedIMG_license" runat="server" CausesValidation="False"  onclick="btnUploadedIMG_license_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploadedIMG_license" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>--%>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Address : 
     </div>
      
    <div class="w3-col l9 ">
        <asp:TextBox ID="txtaddress_driver"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Address" ></asp:TextBox>
    </div>
     
      <%--<div class="w3-col l2 <% Response.Write(Css)%>" >
        ถนน : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtroad_driver"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ถนน" ></asp:TextBox>
    </div>--%>

  </div>

   <div class="w3-row w3-padding-small">

  <%--  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เมือง : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtcity_driver"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เมือง" ></asp:TextBox>
    </div>--%>
     
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        State : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtstate_driver" class="w3-input w3-border w3-round-large" runat="server" placeholder="State" ></asp:TextBox>
    </div>

    <div class="w3-col l3 <% Response.Write(Css)%>" >
        Country : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:DropDownList ID="ddlCountry_driver" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
    </div>

  </div>


  <div class="w3-row w3-padding-small">

    
     
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Zipcode : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtzipcode_driver" class="w3-input w3-border w3-round-large" runat="server" placeholder="Zipcode" ></asp:TextBox>
    </div>

  </div>

    <%-- <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ประเทศของผู้ขับรถ : 
     </div>
      
    <div class="w3-col l3 ">
     <asp:DropDownList ID="ddlcountry_driver" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
          
    </div>

   
     
   </div>--%>


   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Telephone  : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txttel_driver" class="w3-input w3-border w3-round-large" runat="server" placeholder="Telephone" ></asp:TextBox>
    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
        Email : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtemail_driver" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Passport Photo : 
     </div>
      
    <div class="w3-col l9 ">
         <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload1" runat="server" onchange="document.getElementById('MainContent_btnUploadPassport').click();" />
            <asp:ImageButton ID="btnUploadPassport" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="../image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNamePassport" runat="server" />
            <asp:Image ID="PhotoPassport" runat="server" Height="300px" Width="400px"/>
            <asp:ImageButton ID="PhotoDeletePassport"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadPassport"/>
	          </Triggers>
           </asp:UpdatePanel>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Driver License Photo : 
     </div>
      
    <div class="w3-col l9 ">
          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload3" runat="server" onchange="document.getElementById('MainContent_btnUploadLicense').click();" />
            <asp:ImageButton ID="btnUploadLicense" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="../image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNameLicense" runat="server" />
            <asp:Image ID="PhotoLicense" runat="server" Height="300px" Width="400px"/>
            <asp:ImageButton ID="PhotoDeleteLicense"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense"/>
	          </Triggers>
           </asp:UpdatePanel>
    </div>

  </div>


  <div class="w3-row w3-padding-small m-5">
  <center>
<%--  <asp:Button ID="btnNext1" class="w3-button w3-blue2 w3-padding w3-round" runat="server" UseSubmitBehavior="false" Text="Next" />--%>

    <asp:LinkButton ID="lnkNext1" class="w3-button w3-purple2 w3-padding w3-round" runat="server">Next <i class="fa fa-forward" aria-hidden="true"></i></asp:LinkButton>

  </center>

  </div>
  </div>

     <div id="formT2" class="container position-relative w3-padding">

  <div class="w3-border w3-round-large">
    <br />
    <h4 class="headmenu w3-padding-left">Reserve Driver 1 </h4>

      <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Title : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:RadioButtonList ID="rdoprename1" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="Mr.">Mr.</asp:ListItem>
            <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
            <asp:ListItem Value="other">other</asp:ListItem>
        </asp:RadioButtonList>
    </div>

   <div class="w3-col l3 <% Response.Write(Css)%>" >
        Etc. :     
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtprename1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Etc." ></asp:TextBox>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Name : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtname1"   class="w3-input w3-border w3-round-large" runat="server" placeholder="Name" ></asp:TextBox>
    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
        Last Name :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtsurname1" class="w3-input w3-border w3-round-large" runat="server" placeholder="Last Name" ></asp:TextBox>
    </div>

  </div>

  <div class="w3-row w3-padding-small">
   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Driver License No. : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtlicense_no1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License No." ></asp:TextBox>
    </div>

        <div class="w3-col l3 <% Response.Write(Css)%>" >
        Driver License Expiry Date : 
     </div>
      
    <div class="w3-col l3 ">
        <%--<asp:TextBox ID="txtexp_license_no1" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
        <asp:TextBox ID="txtexp_license_no1" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>
    </div>



  </div>

    <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Passport No. : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtpassport1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport No." ></asp:TextBox>
    </div>

     <div class="w3-col l3 <% Response.Write(Css)%>" >
        Passport Expiry Date : 
     </div>
      
    <div class="w3-col l3 ">
        <%--<asp:TextBox ID="txtexp_pass_date1" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
        <asp:TextBox ID="txtexp_pass_date1" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>
    </div>

  </div>


     <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Address : 
     </div>
      
    <div class="w3-col l9 ">
        <asp:TextBox ID="txtaddress_driver1"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Address" ></asp:TextBox>
    </div>

  </div>

   <div class="w3-row w3-padding-small">
 
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        State : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtstate_driver1" class="w3-input w3-border w3-round-large" runat="server" placeholder="State" ></asp:TextBox>
    </div>

    <div class="w3-col l3 <% Response.Write(Css)%>" >
        Country : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:DropDownList ID="ddlCountry_driver1" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
    </div>

  </div>


  <div class="w3-row w3-padding-small">

    
     
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Zipcode : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtzipcode_driver1" class="w3-input w3-border w3-round-large" runat="server" placeholder="Zipcode" ></asp:TextBox>
    </div>

     

  </div>

    <div class="w3-row w3-padding-small">

       <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Gender : 
     </div>
      
    <div class="w3-col l3 ">
     <asp:DropDownList ID="ddlgender1" runat="server" class="w3-input w3-border w3-round-large"> 
               <asp:ListItem Value="M">Male</asp:ListItem>
               <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:DropDownList>
    </div>


     <div class="w3-col l3 <% Response.Write(Css)%>" >
        Nationality : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:DropDownList ID="ddlnational1" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
    </div>

    </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Telephone  : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txttel_driver1" class="w3-input w3-border w3-round-large" runat="server" placeholder="Telephone" ></asp:TextBox>
    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
        Email : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtemail_driver1" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Passport Photo : 
     </div>
      
    <div class="w3-col l9 ">
         <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload7" runat="server" onchange="document.getElementById('MainContent_btnUploadPassport1').click();" />
            <asp:ImageButton ID="btnUploadPassport1" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="../image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNamePassport1" runat="server" />
            <asp:Image ID="PhotoPassport1" runat="server" Height="300px" Width="400px"/>
            <asp:ImageButton ID="PhotoDeletePassport1"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadPassport1"/>
	          </Triggers>
           </asp:UpdatePanel>
    </div>

  </div>

      <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Driver License Photo : 
     </div>
      
    <div class="w3-col l9 ">
          <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload4" runat="server" onchange="document.getElementById('MainContent_btnUploadLicense1').click();" />
            <asp:ImageButton ID="btnUploadLicense1" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="../image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNameLicense1" runat="server" />
            <asp:Image ID="PhotoLicense1" runat="server" Height="300px" Width="400px"/>
            <asp:ImageButton ID="PhotoDeleteLicense1"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadLicense1"/>
	          </Triggers>
           </asp:UpdatePanel>
    </div>

  </div>
    <br />
  </div>
   <br />
  <div class="w3-border w3-round-large">
    <br />
    <h4 class="headmenu w3-padding-left">Reserve Driver 2 </h4>

      <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Title : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:RadioButtonList ID="rdoprename2" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="Mr.">Mr.</asp:ListItem>
            <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
            <asp:ListItem Value="other">other</asp:ListItem>
        </asp:RadioButtonList>
    </div>

   <div class="w3-col l3 <% Response.Write(Css)%>" >
        Etc. :     
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtprename2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Etc." ></asp:TextBox>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Name : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtname2"   class="w3-input w3-border w3-round-large" runat="server" placeholder="Name" ></asp:TextBox>
    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
        Last Name :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtsurname2" class="w3-input w3-border w3-round-large" runat="server" placeholder="Last Name" ></asp:TextBox>
    </div>

  </div>

 <div class="w3-row w3-padding-small">
   <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Driver License No. : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtlicense_no2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Driver License No." ></asp:TextBox>
    </div>

        <div class="w3-col l3 <% Response.Write(Css)%>" >
        Driver License Expiry Date : 
     </div>
      
    <div class="w3-col l3 ">
        <%--<asp:TextBox ID="txtexp_license_no2" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
        <asp:TextBox ID="txtexp_license_no2" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>
    </div>



  </div>

    <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Passport No. : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtpassport2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport No." ></asp:TextBox>
    </div>

     <div class="w3-col l3 <% Response.Write(Css)%>" >
        Passport Expiry Date : 
     </div>
      
    <div class="w3-col l3 ">
        <%--<asp:TextBox ID="txtexp_pass_date2" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
        <asp:TextBox ID="txtexp_pass_date2" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>
    </div>

  </div>


     <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Address : 
     </div>
      
    <div class="w3-col l9 ">
        <asp:TextBox ID="txtaddress_driver2"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Address" ></asp:TextBox>
    </div>

  </div>

   <div class="w3-row w3-padding-small">
 
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        State : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtstate_driver2" class="w3-input w3-border w3-round-large" runat="server" placeholder="State" ></asp:TextBox>
    </div>

    <div class="w3-col l3 <% Response.Write(Css)%>" >
        Country : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:DropDownList ID="ddlCountry_driver2" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
    </div>

  </div>


  <div class="w3-row w3-padding-small">

    
     
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Zipcode : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtzipcode_driver2" class="w3-input w3-border w3-round-large" runat="server" placeholder="Zipcode" ></asp:TextBox>
    </div>

     

  </div>

    <div class="w3-row w3-padding-small">

       <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Gender : 
     </div>
      
    <div class="w3-col l3 ">
     <asp:DropDownList ID="ddlgender2" runat="server" class="w3-input w3-border w3-round-large"> 
               <asp:ListItem Value="M">Male</asp:ListItem>
               <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:DropDownList>
    </div>


     <div class="w3-col l3 <% Response.Write(Css)%>" >
        Nationality : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:DropDownList ID="ddlnational2" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
    </div>

    </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Telephone  : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txttel_driver2" class="w3-input w3-border w3-round-large" runat="server" placeholder="Telephone" ></asp:TextBox>
    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
        Email : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtemail_driver2" class="w3-input w3-border w3-round-large" runat="server" placeholder="Email" ></asp:TextBox>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Passport Photo : 
     </div>
      
    <div class="w3-col l9 ">
         <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload6" runat="server" onchange="document.getElementById('MainContent_btnUploadPassport2').click();" />
            <asp:ImageButton ID="btnUploadPassport2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="../image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNamePassport2" runat="server" />
            <asp:Image ID="PhotoPassport2" runat="server" Height="300px" Width="400px"/>
            <asp:ImageButton ID="PhotoDeletePassport2"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadPassport2"/>
	          </Triggers>
           </asp:UpdatePanel>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Driver License Photo : 
     </div>
      
    <div class="w3-col l9 ">
          <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload5" runat="server" onchange="document.getElementById('MainContent_btnUploadLicense2').click();" />
            <asp:ImageButton ID="btnUploadLicense2" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="../image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoNameLicense2" runat="server" />
            <asp:Image ID="PhotoLicense2" runat="server" Height="300px" Width="400px"/>
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
  </div>



  <div class="w3-row w3-padding-small m-5">

  <center>
    <%--<asp:Button ID="btnPrev2" class="w3-button w3-blue2 w3-padding w3-round" runat="server" UseSubmitBehavior="false" Text="Prev" />
   <asp:Button ID="btnNext3" class="w3-button w3-blue2 w3-padding w3-round" runat="server" UseSubmitBehavior="false" Text="Next" />--%>

   <asp:LinkButton ID="btnPrev2" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-backward" aria-hidden="true"></i> Prev</asp:LinkButton>
    <asp:LinkButton ID="btnNext2" class="w3-button w3-purple2 w3-padding w3-round" runat="server">Next <i class="fa fa-forward" aria-hidden="true"></i></asp:LinkButton>
    </center>   
  </div>

  </div>

     <div id="formT3" class="container position-relative w3-padding">


 <%-- <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       รูปถ่ายตัวรถ : 
     </div>
      
    <div class="w3-col l3 ">
         <iframe id="Iframe_car" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FileVehicle&type=Car&support=IMG" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l8 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvIMG_car" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <asp:DataList ID="DtlImg_car" runat="server" CellPadding="4" 
                    DataKeyField="id" ForeColor="#333333" Width="700px" RepeatColumns="4" 
                            RepeatDirection="Horizontal">
                    
                    <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                           <ItemTemplate>
                               <table  style="width: 225px; height: 150px;">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile_car" runat="server" ImageUrl='<%# Bind("PathImg") %>' /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Link_car" NavigateUrl='<%# Bind("LinkImg") %>' Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="ImgDelete_car" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                CommandArgument='<%# Eval("gid") %>' CommandName="Delete" 
                                                ImageUrl="~/image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_car_Command"  /></td> </tr>
                               </table>
                           </ItemTemplate>
                </asp:DataList>
                    <asp:Panel style="DISPLAY: none" id="pn_car" runat="server" Height="0px">
                        <asp:GridView ID="gvIMG_car" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" CssClass="Grid" GridLines="None" Width="500px"> 
                            <Columns>
                                <asp:TemplateField SortExpression="file_name" Visible="False">
                                     <ItemTemplate>
                                        <asp:Label ID="lblfile_name" runat="server" Text='<%# Bind("file_name") %>'></asp:Label>
                                       
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("gid") %>'></asp:Label>
                                        <asp:Label ID="lblPathImg" runat="server" Text='<%# Bind("PathImg") %>'></asp:Label>
                                        <asp:Label ID="lblLinkImg" runat="server" Text='<%# Bind("LinkImg") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pgr" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
                    </asp:Panel>
                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel_car" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFNameIMG_car" runat="server" />
                        <asp:HiddenField ID="hidSNameIMG_car" runat="server" />
                        
                        <asp:Button ID="btnUploadedIMG_car" runat="server" CausesValidation="False"  onclick="btnUploadedIMG_car_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploadedIMG_car" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>

  <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       ภาพถ่ายใบคู่มือจดทะเบียนรถ : 
     </div>
      
    <div class="w3-col l3 ">
         <iframe id="Iframe_car_registration" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FileVehicle&type=Car_Registration&support=IMG" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l8 w3-padding-top">

    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                     
                     <table id="tbcar_registration_img" runat="server" style="width: 225px; height: 150px;" >
                                  <tr><td style="text-align: center" ><asp:Image ID="image3" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="HyperLink4" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="ImageButton4" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_license_Command"  /></td> </tr>
                               </table>

                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="HiddenField10" runat="server" />
                        <asp:HiddenField ID="HiddenField11" runat="server" />
                        <asp:HiddenField ID="HiddenField12" runat="server" Value="0" />
                        <asp:Button ID="Button4" runat="server" CausesValidation="False"  onclick="btnUploaded_consent_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploaded_consent" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>--%>

    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Registration No. (Local) :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtlocal_plate" class="w3-input w3-border w3-round-large" runat="server" placeholder="Registration No. (Local)" ></asp:TextBox>
    </div>

    <div class="w3-col l3 <% Response.Write(Css)%>" >
        Province of registration : 

     </div>
      
    <div class="w3-col l3 ">

    <asp:TextBox ID="txtstate_car" class="w3-input w3-border w3-round-large" runat="server" placeholder="Province of registration" ></asp:TextBox>
      
    </div>
     
      
  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Registration No. (ENG) :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtplate" class="w3-input w3-border w3-round-large" runat="server" placeholder="Registration No. (ENG)" ></asp:TextBox>
    </div>

    <div class="w3-col l3 <% Response.Write(Css)%>" >
        Country of registration :

     </div>
      
    <div class="w3-col l3 ">

   <asp:DropDownList ID="ddlCountryCar" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>

    </div>
     
      
  </div>

    <div class="w3-row w3-padding-small">
  
     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Make :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtbrands" class="w3-input w3-border w3-round-large" runat="server" placeholder="Make" ></asp:TextBox>
    </div>

        <div class="w3-col l3 <% Response.Write(Css)%>" >
        Model : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtmodels" class="w3-input w3-border w3-round-large" runat="server" placeholder="Model" ></asp:TextBox>
    </div>

  </div>

    <div class="w3-row w3-padding-small">
  
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Seats : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:DropDownList ID="ddlSeats" runat="server" class="w3-input w3-border w3-round-large"> 
                <asp:ListItem Value="">please select</asp:ListItem>
                <asp:ListItem Value="2">2 seat</asp:ListItem>
                <%--<asp:ListItem Value="4">4 seat</asp:ListItem>--%>
                <asp:ListItem Value="5">5 seat</asp:ListItem>
                <asp:ListItem Value="7">7 seat</asp:ListItem>
                <asp:ListItem Value="11">11 seat</asp:ListItem>
                <asp:ListItem Value="13">13 seat</asp:ListItem>
                <asp:ListItem Value="18">18 seat</asp:ListItem>
                <asp:ListItem Value="21">21 seat</asp:ListItem>
                <asp:ListItem Value="30">30 seat</asp:ListItem>
                <asp:ListItem Value="40">40 seat</asp:ListItem>
                <asp:ListItem Value="50">50 seat</asp:ListItem>
            </asp:DropDownList>
    </div>

    <div class="w3-col l3 <% Response.Write(Css)%>" >
        Gross Weight (kg.) :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtweight" class="w3-input w3-border w3-round-large" onBlur="formatComma(this)" runat="server" placeholder="Gross Weight (kg.)" ></asp:TextBox>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

      <%--<div class="w3-col l2_2 <% Response.Write(Css)%>" >
        รุ่นรถปี ค.ศ. : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:DropDownList ID="ddlyears" runat="server" class="w3-input w3-border w3-round-large"> 
       <asp:ListItem Value="">กรุณาเลือก</asp:ListItem>
            </asp:DropDownList>
    </div>--%>
     
     
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Colors :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtcolors" class="w3-input w3-border w3-round-large" runat="server" placeholder="Colors" ></asp:TextBox>
    </div>

  </div>

     <div class="w3-row w3-padding-small">

       <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Type : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:DropDownList ID="ddltypecar" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
    </div>

    <div class="w3-col l3 <% Response.Write(Css)%>" >
        Engine Number : 
     </div>
      
    <div class="w3-col l3 ">
     <asp:TextBox ID="txtNumEngine" class="w3-input w3-border w3-round-large" runat="server" placeholder="Engine Number" ></asp:TextBox>
    </div>
     
  </div>

  
    <div class="w3-row w3-padding-small">


      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Vehicle Identification Number (VIN) :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtnumcar" class="w3-input w3-border w3-round-large" runat="server" placeholder="VIN Number" ></asp:TextBox>
    </div>


      <div class="w3-col l3 <% Response.Write(Css)%>" >
        Engine Capacity :
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtEngine_cap" class="w3-input w3-border w3-round-large" runat="server" placeholder="Engine Capacity" ></asp:TextBox>
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

  <div class="w3-row w3-padding-small" style="display:none">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขที่หนังสือเดินทางรถ : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtpass_car"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Passport" ></asp:TextBox>
    </div>

     <div class="w3-col l3 <% Response.Write(Css)%>" >
        วันหมดอายุหนังสือเดินทางรถ : 
     </div>
      
    <div class="w3-col l3 ">
        <%--<asp:TextBox ID="txtexp_pass_car_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
        <asp:TextBox ID="txtexp_pass_car_date" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>
    </div>

    </div>
    <div class="w3-row w3-padding-small">


    <div class="w3-col l2_2 <% Response.Write(Css)%> " >
        Vehicle Photos : 
     </div>

        <div class=" w3-col l9">

           <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FileUpload2" runat="server" onchange="document.getElementById('MainContent_btnUploadCar').click();" />
            <asp:ImageButton ID="btnUploadCar" style="DISPLAY: none" runat="server" AutoPostBack="true" Width="50px"  OnClientClick="showProgress(); " formnovalidate="formnovalidate" CausesValidation=false  UseSubmitBehavior="false"/>
               <asp:HiddenField ID="hidPhotonamecar" runat="server" />
            <asp:Image ID="PhotoCar" runat="server" Width="300px"  />
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
                   var txtfname = document.getElementById('ContentPlaceHolder1_hidFName');
                   txtfname.value = fname;
                   alert(txtfname.value);
                   document.getElementById('ContentPlaceHolder1_btnAddImage').click();
               };


               </script>--%>
          
        
           <br />
    <asp:UpdatePanel ID="UpdgvFile" runat="server" class="w3-row-padding w3-center" UpdateMode="Conditional">
                    <contenttemplate>
                       <asp:DataList ID="DtlImg" runat="server" CellPadding="0" RepeatLayout="Flow" 
                    DataKeyField="gid" ForeColor="#333333" RepeatColumns="4" 
                            RepeatDirection="Horizontal">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                           <ItemTemplate>
                              

                            <div class="w3-col l3 m6 w3-margin-bottom" style="height: 250px;">
                                <div class="w3-display-container">

                                    <%--<img src="/w3images/sandwich.jpg" alt="Sandwich" style="width:100%">--%>
                                    <asp:Image ID="imageFile" runat="server" ImageUrl='<%# Bind("PathImg") %>' style="width:200px" />
                                    <%--<h3>The Perfect Sandwich, A Real NYC Classic</h3>--%>
                                 
                                    
                                      
                                <div class="w3-white w3-margin">
                                    <h3><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("PathImg") %>' Target="_blank"  runat="server">Big picture</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="PhotoCarDelete" runat="server" OnClientClick = "javascript:return confirm('Do you want delete photo?');"
                                                CommandArgument='<%# Eval("gid") %>' CommandName="Delete" 
                                                ImageUrl="~/image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="PhotoCarDelete_Command" formnovalidate="formnovalidate" CausesValidation=false  UseSubmitBehavior="false"/></h3>
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

</div>


  </div>
   <br />
  <div class="w3-border w3-round-large w3-margin-top" style="display:none;">
    <br />
    <h4 class="headmenu w3-padding-left">ผู้ครอบครอง </h4>

<div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อผู้ครอบครอง : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtholder" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อผู้ครอบครอง" ></asp:TextBox>
    </div>
     
   
   <div class="w3-col l2 <% Response.Write(Css)%>" >
        เลขบัตรประจำตัวประชาชน : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtholder_id_card" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชนผู้ครอบครอง" ></asp:TextBox>
    </div>

  </div>

<%--  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ที่อยู่ : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtaddress_holder"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>
    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        ถนน : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtroad_holder"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ถนน" ></asp:TextBox>
    </div>

  </div>--%>

<%--   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เมือง : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtcity_holder"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เมือง" ></asp:TextBox>
    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        รัฐ : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtstate_holder" class="w3-input w3-border w3-round-large" runat="server" placeholder="รัฐ" ></asp:TextBox>
    </div>

  </div>
--%>

<%--  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ประเทศ : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:DropDownList ID="ddlcountry_holder" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
        Zipcode : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtzipcode_holder" class="w3-input w3-border w3-round-large" runat="server" placeholder="Zipcode" ></asp:TextBox>
    </div>

  </div>--%>

  <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ที่อยู่ : 
     </div>
      
    <div class="w3-col l8 ">
        <asp:TextBox ID="txtaddress_holder"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        โทรศัพท์  : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txttel_holder" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>
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

       <div class="w3-border w3-round-large" >
    <br />
    <h4 class="headmenu w3-padding-left">Owner</h4>

    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Owner Name : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtowner" class="w3-input w3-border w3-round-large" runat="server" placeholder="Owner Name" ></asp:TextBox>
    </div>
     
   
   <div class="w3-col l3 <% Response.Write(Css)%>" >
        Owner ID Card No. : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtowner_id_card" class="w3-input w3-border w3-round-large" runat="server" placeholder="Owner ID Card No." ></asp:TextBox>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Owner Address : 
     </div>
      
    <div class="w3-col l9 ">
        <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Owner Address" ></asp:TextBox>
    </div>

  </div>


   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Owner Telephone  : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txttel_owner" class="w3-input w3-border w3-round-large" runat="server" placeholder="Owner Telephone" ></asp:TextBox>
    </div>

  </div>

     <br />

     </div>
    <%--<div class="w3-border w3-round-large" >
    <br />
    <h4 class="headmenu w3-padding-left">ผู้ถือกรรมสิทธิ์ </h4>

    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อผู้ถือกรรมสิทธิ์ : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtowner" class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อผู้ถือกรรมสิทธิ์" ></asp:TextBox>
    </div>
     
   
   <div class="w3-col l2 <% Response.Write(Css)%>" >
        เลขบัตรประจำตัวประชาชน : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:TextBox ID="txtowner_id_card" class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขบัตรประจำตัวประชาชนผู้ถือกรรมสิทธิ์" ></asp:TextBox>
    </div>

  </div>

   <div class="w3-row w3-padding-small">

  <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ที่อยู่ : 
     </div>
      
    <div class="w3-col l8 ">
        <asp:TextBox ID="txtaddress_owner"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ที่อยู่" ></asp:TextBox>
    </div>

  </div>


   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        โทรศัพท์  : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txttel_owner" class="w3-input w3-border w3-round-large" runat="server" placeholder="โทรศัพท์" ></asp:TextBox>
    </div>

  </div>

     <br />

     </div>--%>
  

  <div class="w3-row w3-padding-small m-5">
  <center>
   <%--<asp:Button ID="Button2" class="w3-button w3-blue2 w3-padding w3-round" runat="server" UseSubmitBehavior="false" Text="Prev" />
   <asp:Button ID="Button1" class="w3-button w3-blue2 w3-padding w3-round" runat="server" UseSubmitBehavior="false" Text="Next" />--%>

   <asp:LinkButton ID="lnkPrev3" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-backward" aria-hidden="true"></i> Prev</asp:LinkButton>
    <asp:LinkButton ID="lnkNext3" class="w3-button w3-purple2 w3-padding w3-round" runat="server">Next <i class="fa fa-forward" aria-hidden="true"></i></asp:LinkButton>
      </center>  

   </div>
    </div>

     <div id="formT4" class="container position-relative w3-padding">
    
    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Policy Number : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtinsure_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="Policy Number" ></asp:TextBox>
    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
        Insurance Company : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtcompany" class="w3-input w3-border w3-round-large" runat="server" placeholder="Insurance Company" ></asp:TextBox>
    </div>

  </div>

    <div class="w3-row w3-padding-small">

     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Start date : 
     </div>
      
    <div class="w3-col l3 ">
         <%--<asp:TextBox ID="txtstart_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
         <asp:TextBox ID="txtstart_date" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>
    </div>

     <div class="w3-col l3 <% Response.Write(Css)%>" >
        End date : 
     </div>
      
    <div class="w3-col l3 ">
        <%--<asp:TextBox ID="txtend_date" type="Date" class="w3-input w3-border w3-round-large" runat="server" ></asp:TextBox>--%>
        <asp:TextBox ID="txtend_date" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>
    </div>

  </div>

    <div class="w3-row w3-padding-small" style="display:none">

    <%-- <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        ชื่อผู้เอาประกันภัย : 
     </div>
      
    <div class="w3-col l3 ">
         <asp:TextBox ID="txtinsure_name"  class="w3-input w3-border w3-round-large" runat="server" placeholder="ชื่อผู้เอาประกันภัย"></asp:TextBox>
    </div>
--%>
     <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        เลขตัวถัง : 
     </div>
      
    <div class="w3-col l3 ">
        <asp:TextBox ID="txtcar_no"  class="w3-input w3-border w3-round-large" runat="server" placeholder="เลขตัวถัง"></asp:TextBox>
    </div>

  </div>
    

    <div class="w3-row w3-padding-small m-5">
    <center>
<%--     <asp:Button ID="btnPrev3" class="w3-button w3-blue2 w3-padding w3-round" runat="server" UseSubmitBehavior="false" Text="Prev"  />
   <button class="w3-button w3-blue2 w3-padding w3-round" onclick ="Submit();return false;" UseSubmitBehavior="false">Submit</Button>--%>

    <asp:LinkButton ID="lnkPrev4" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-backward" aria-hidden="true"></i> Prev</asp:LinkButton>
    <asp:LinkButton ID="lnkNext4" class="w3-button w3-purple2 w3-padding w3-round" runat="server">Next <i class="fa fa-forward" aria-hidden="true"></i></asp:LinkButton>
    <%--<asp:LinkButton ID="lnkSubmit" class="w3-button w3-purple w3-padding w3-round" runat="server"><i class="fa fa-save" aria-hidden="true"></i> Submit</asp:LinkButton>--%>
       <%-- <asp:Button ID="btnNext4" class="btn btn-lg btn-success w3-center next btnext" runat="server" UseSubmitBehavior=false Text="Save" />--%>
      </center>  
  </div>

    </div>

     <div id="formT5" style="display:none; " class="container position-relative w3-padding">

      <div class="w3-row w3-padding-small">

     <div class="w3-col l5 <% Response.Write(Css)%>" >
       รูปถ่ายหนังสือเดินทาง : 
     </div>
      
    <div class="w3-col l5 ">
         <iframe id="Iframe_passport" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FilePhotoDriver&type=Passport&support=IMG" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l5 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l5 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvIMG_passport" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                     <table id="tbpassport_img" runat="server"  style="width: 225px; height: 150px;">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile_passport" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Link_passport" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="ImgDelete_passport" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_passport_Command"  /></td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel_passport" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFNameIMG_passport" runat="server" />
                        <asp:HiddenField ID="hidSNameIMG_passport" runat="server" />
                        
                        <asp:Button ID="btnUploadedIMG_passport" runat="server" CausesValidation="False"  onclick="btnUploadedIMG_passport_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploadedIMG_passport" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>

   <div class="w3-row w3-padding-small">

     <div class="w3-col l5 <% Response.Write(Css)%>" >
       รายการตรวจลงตรา (VISA) กรณีที่ผู้ขอมีสัญชาติที่มิได้รับการยกเว้นการตรวจลงตรา : 
     </div>
      
    <div class="w3-col l5 ">
         <iframe id="Iframe_VISA" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FilePhotoDriver&type=VISA&support=File" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l5 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l5 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvIMG_VISA" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
        

                                <table id="tbVISA_file" runat="server" >
                                  <tr>
                                  <td style="text-align: center" ><asp:HyperLink ID="Link_VISA" runat="server" NavigateUrl="" Text="หนังสือยินยอมจากเจ้าของรถ" > </asp:HyperLink></td>
                                  <td style="text-align: center" ><asp:ImageButton ID="imageFile_VISA" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบไฟล์ใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="imageFile_VISA_Command"  /></td>
                                  
                                  </tr>

                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel_VISA" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFNameIMG_VISA" runat="server" />
                        <asp:HiddenField ID="hidSNameIMG_VISA" runat="server" />
                        
                        <asp:Button ID="btnUploadedIMG_VISA" runat="server" CausesValidation="False"  onclick="btnUploadedIMG_VISA_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploadedIMG_VISA" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>

         <div class="w3-row w3-padding-small">

     <div class="w3-col l5 <% Response.Write(Css)%>" >
       รูปถ่ายใบอนุญาตขับรถ : 
     </div>
      
    <div class="w3-col l5 ">
         <iframe id="Iframe_license" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FilePhotoDriver&type=License&support=IMG" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l5 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l5 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvIMG_license" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                     <table id="tblicense_img" runat="server" style="width: 225px; height: 150px;" >
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile_license" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Link_license" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="ImgDelete_license" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_license_Command"  /></td> </tr>
                               </table>
                    
                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel_license" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFNameIMG_license" runat="server" />
                        <asp:HiddenField ID="hidSNameIMG_license" runat="server" />
                        
                        <asp:Button ID="btnUploadedIMG_license" runat="server" CausesValidation="False"  onclick="btnUploadedIMG_license_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploadedIMG_license" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>

   <div class="w3-row w3-padding-small">

     <div class="w3-col l5 <% Response.Write(Css)%>" >
       รูปถ่ายตัวรถ : 
     </div>
      
    <div class="w3-col l5 ">
         <iframe id="Iframe_car" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FileVehicle&type=Car&support=IMG" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l8 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvIMG_car" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    <asp:DataList ID="DtlImg_car" runat="server" CellPadding="4" 
                    DataKeyField="id" ForeColor="#333333" Width="700px" RepeatColumns="4" 
                            RepeatDirection="Horizontal">
                    
                    <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                           <ItemTemplate>
                               <table  style="width: 225px; height: 150px;">
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile_car" runat="server" ImageUrl='<%# Bind("PathImg") %>' /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Link_car" NavigateUrl='<%# Bind("LinkImg") %>' Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="ImgDelete_car" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                CommandArgument='<%# Eval("gid") %>' CommandName="Delete" 
                                                ImageUrl="~/image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_car_Command"  /></td> </tr>
                               </table>
                           </ItemTemplate>
                </asp:DataList>
                    <asp:Panel style="DISPLAY: none" id="pn_car" runat="server" Height="0px">
                        <asp:GridView ID="gvIMG_car" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" CssClass="Grid" GridLines="None" Width="500px"> 
                            <Columns>
                                <asp:TemplateField SortExpression="file_name" Visible="False">
                                     <ItemTemplate>
                                        <asp:Label ID="lblfile_name" runat="server" Text='<%# Bind("file_name") %>'></asp:Label>
                                       
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("gid") %>'></asp:Label>
                                        <asp:Label ID="lblPathImg" runat="server" Text='<%# Bind("PathImg") %>'></asp:Label>
                                        <asp:Label ID="lblLinkImg" runat="server" Text='<%# Bind("LinkImg") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pgr" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
                    </asp:Panel>
                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel_car" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFNameIMG_car" runat="server" />
                        <asp:HiddenField ID="hidSNameIMG_car" runat="server" />
                        
                        <asp:Button ID="btnUploadedIMG_car" runat="server" CausesValidation="False"  onclick="btnUploadedIMG_car_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploadedIMG_car" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>

  <div class="w3-row w3-padding-small">

     <div class="w3-col l5 <% Response.Write(Css)%>" >
       ภาพถ่ายใบคู่มือจดทะเบียนรถ : 
     </div>
      
    <div class="w3-col l5 ">
         <iframe id="Iframe_car_registration" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FileVehicle&type=Car_Registration&support=IMG" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l5 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l5 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvIMG_car_registration" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                     
                     <table id="tbcar_registration_img" runat="server" style="width: 225px; height: 150px;" >
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile_car_registration" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Link_car_registration" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="ImgDelete_car_registration" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_car_registration_Command"  /></td> </tr>
                               </table>

                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel_car_registration" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFNameIMG_car_registration" runat="server" />
                        <asp:HiddenField ID="hidSNameIMG_car_registration" runat="server" />
         
                        <asp:Button ID="btnUploaded_car_registration" runat="server" CausesValidation="False"  onclick="btnUploaded_car_registration_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploaded_car_registration" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>

       <div class="w3-row w3-padding-small">

     <div class="w3-col l5 <% Response.Write(Css)%>" >
       หนังสือยินยอมจากเจ้าของรถ กรณีผู้ขออนุญาตใช้รถมิได้เป็นเจ้าของรถ : 
     </div>
      
    <div class="w3-col l5 ">
         <iframe id="Iframe_consent" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FilePDF&type=Consent&support=File" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l5 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l5 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvFile_consent" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                     
                     <table id="tbconsent_file" runat="server" >
                                  <tr>
                                  <td style="text-align: center" ><asp:HyperLink ID="Link_consent" runat="server" NavigateUrl="" Text="หนังสือยินยอมจากเจ้าของรถ" > </asp:HyperLink></td>
                                  <td style="text-align: center" ><asp:ImageButton ID="ImgDelete_consent" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบไฟล์ใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_consent_Command"  /></td>
                                  
                                  </tr>

                               </table>

                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdUploadFile_consent" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFName_consent" runat="server" />
                        <asp:HiddenField ID="hidSName_consent" runat="server" />
                        <asp:HiddenField ID="Hidsize_consent" runat="server" Value="0" />
                        <asp:Button ID="btnUploaded_consent" runat="server" CausesValidation="False"  onclick="btnUploaded_consent_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploaded_consent" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>

   <div class="w3-row w3-padding-small">

     <div class="w3-col l5 <% Response.Write(Css)%>" >
       ภาพถ่ายหนังสือรับรองการผ่านการตรวจสภาพรถ : 
     </div>
      
    <div class="w3-col l5 ">
         <iframe id="Iframe_carcheck" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FilePDF&type=CarCheck&support=IMG" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l5 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l5 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvFile_car_check" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                     
                     <table id="tbcar_check" runat="server" style="width: 225px; height: 150px;" >
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile_car_check" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Link_car_check" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="ImgDelete_car_check" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_car_check_Command"  /></td> </tr>
                               </table>

                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdUploadFile_car_check" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFName_car_check" runat="server" />
                        <asp:HiddenField ID="hidSName_car_check" runat="server" />
                        <asp:HiddenField ID="Hidsize_car_check" runat="server" Value="0" />
                        <asp:Button ID="btnUploaded_car_check" runat="server" CausesValidation="False"  onclick="btnUploaded_car_check_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploaded_car_check" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>

  <div class="w3-row w3-padding-small">

     <div class="w3-col l5 <% Response.Write(Css)%>" >
       ภาพถ่ายหลักฐานการเอาประกันภัยตาม พ.ร.บ. คุ้มครองผู้ประสบภัยจากรถ พ.ศ. 2535 : 
     </div>
      
    <div class="w3-col l5 ">
         <iframe id="Iframe_insure_img" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FilePDF&type=insure_img&support=IMG" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l5 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l5 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvFile_insure_img" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                     
                     <table id="tbinsure_img" runat="server" style="width: 225px; height: 150px;" >
                                  <tr><td style="text-align: center" ><asp:Image ID="imageFile_insure_img" runat="server" ImageUrl="" /></td></tr>
                                  <tr><td style="text-align: center" ><asp:HyperLink ID="Link_insure_img" NavigateUrl="" Target="_blank"  runat="server">ดูรูปใหญ่</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="ImgDelete_insure_img" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_insure_img_Command"  /></td> </tr>
                               </table>

                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdUploadFile_insure_img" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFName_insure_img" runat="server" />
                        <asp:HiddenField ID="hidSName_insure_img" runat="server" />
                        <asp:HiddenField ID="Hidsize_insure_img" runat="server" Value="0" />
                        <asp:Button ID="btnUploaded_insure_img" runat="server" CausesValidation="False"  onclick="btnUploaded_insure_img_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploaded_insure_img" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>

   <div class="w3-row w3-padding-small">

     <div class="w3-col l5 <% Response.Write(Css)%>" >
       หลักฐานแสดงรายละเอียดเกี่ยวกับการเดินทาง เช่น สถานที่พักและกำหนดการต่างๆ : 
     </div>
      
    <div class="w3-col l5 ">
         <iframe id="Iframeinformation_file" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FilePDF&type=information_file&support=File" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l5 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l5 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvFile_information_file" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                     
                     <table id="tbinformation_file" runat="server" >
                                  <tr>
                                  <td style="text-align: center" ><asp:HyperLink ID="Link_information_file" runat="server" NavigateUrl="" Text="รายละเอียด" > </asp:HyperLink></td>
                                  <td style="text-align: center" ><asp:ImageButton ID="ImgDelete_information_file" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบไฟล์ใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_information_file_Command"  /></td>
                                  
                                  </tr>

                               </table>

                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdUploadFile_information_file" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFName_information_file" runat="server" />
                        <asp:HiddenField ID="hidSName_information_file" runat="server" />
                        <asp:HiddenField ID="Hidsize_information_file" runat="server" Value="0" />
                        <asp:Button ID="btnUploaded_information_file" runat="server" CausesValidation="False"  onclick="btnUploaded_information_file_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploaded_information_file" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>

  <div class="w3-row w3-padding-small">

     <div class="w3-col l5 <% Response.Write(Css)%>" >
       หนังสือชี้แจงเหตุผลความจำเป็นในการใช้รถจดทะเบียนต่างประเทศในประเทศไทย : 
     </div>
      
    <div class="w3-col l5 ">
         <iframe id="Iframereason_file" enableviewstate="true" frameborder="0" height="80" name="I1" 
                    scrolling="no" src="../Control/UploadFileM.aspx?f=FilePDF&type=reason_file&support=File" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; background-color: transparent;
                border-right-width: 0px" width="320">Your browser does not support iframes 
                </iframe>
    </div>

  </div>

  <div class="w3-row w3-padding-small">

    <div class="w3-col l5 <% Response.Write(Css)%>" >
        
     </div>
      
    <div class="w3-col l5 w3-padding-top">

    <asp:UpdatePanel ID="UpdgvFile_reason_file" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                     
                     <table id="tbreason_file" runat="server" >
                                  <tr>
                                  <td style="text-align: center" ><asp:HyperLink ID="Link_reason_file" runat="server" NavigateUrl="" Text="หนังสือชี้แจงเหตุผล" > </asp:HyperLink></td>
                                  <td style="text-align: center" ><asp:ImageButton ID="ImgDelete_reason_file" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบไฟล์ใช่หรือไม่?');"
                                                 CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="ImgDelete_reason_file_Command"  /></td>
                                  
                                  </tr>

                               </table>

                    </contenttemplate>
                    
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdUploadFile_reason_file" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:HiddenField ID="hidFName_reason_file" runat="server" />
                        <asp:HiddenField ID="hidSName_reason_file" runat="server" />
                        <asp:HiddenField ID="Hidsize_reason_file" runat="server" Value="0" />
                        <asp:Button ID="btnUploaded_reason_file" runat="server" CausesValidation="False"  onclick="btnUploaded_reason_file_Click" style="DISPLAY: none" UseSubmitBehavior="false" />
                    </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUploaded_reason_file" EventName="Click" />
                    </triggers>
                </asp:UpdatePanel>

    </div>
  </div>

    <div class="w3-row w3-padding-small m-5">
    <center>

    <asp:LinkButton ID="lnkPrev5" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-backward" aria-hidden="true"></i> Prev</asp:LinkButton>
    <%--<asp:LinkButton ID="lnkSubmit" class="w3-button w3-purple w3-padding w3-round" runat="server"><i class="fa fa-save" aria-hidden="true"></i> Submit</asp:LinkButton>--%>
        <%--<asp:Button ID="Button1" class="btn btn-lg btn-success w3-center next btnext" runat="server" UseSubmitBehavior=false Text="Save" />--%>
      </center>  
  </div>

     </div>

     <div id="formT6" class="container position-relative w3-padding">
    
    <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Border Crossing Checkin : 
     </div>
      
    <div class="w3-col l3 ">
         <asp:DropDownList ID="ddlBorderCheckin" runat="server" class="w3-input w3-border w3-round-large" > 
            </asp:DropDownList>
    </div>
     
      <div class="w3-col l3 <% Response.Write(Css)%>" >
       Border Crossing Checkout : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:DropDownList ID="ddlBorderCheckout" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
    </div>

  </div>

   <div class="w3-row w3-padding-small">
      <div class="w3-col l2_2 <% Response.Write(Css)%>" >
       Place to receive documents : 
     </div>
      
    <div class="w3-col l3 ">
       <asp:DropDownList ID="ddlformarea" runat="server" class="w3-input w3-border w3-round-large"> 
            </asp:DropDownList>
    </div>
   </div>

<%--   <div class="w3-row w3-padding-small">

    <div class="w3-col l2_2 <% Response.Write(Css)%>" >
        Province use vehicle : 
     </div>
      
    <div class="w3-col l3 ">
         <asp:Label ID="lblArea" runat="server" CssClass=" font-weight-bold" Text=""></asp:Label>
          <asp:HiddenField ID="hidProvince" runat="server" />
    </div>
     
      <div class="w3-col l2 <% Response.Write(Css)%>" >
      
     </div>
      
    <div class="w3-col l3 ">
       
    </div>

  </div>--%>

    <div class="w3-row w3-padding-small m-5">
    <center>
<%--     <asp:Button ID="btnPrev3" class="w3-button w3-blue2 w3-padding w3-round" runat="server" UseSubmitBehavior="false" Text="Prev"  />
   <button class="w3-button w3-blue2 w3-padding w3-round" onclick ="Submit();return false;" UseSubmitBehavior="false">Submit</Button>--%>

    <asp:LinkButton ID="lnkPrev6" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-backward" aria-hidden="true"></i> Prev</asp:LinkButton>
    <%--<asp:LinkButton ID="lnkNext5" class="w3-button w3-purple w3-padding w3-round" runat="server">Next <i class="fa fa-forward" aria-hidden="true"></i></asp:LinkButton>--%>
    <asp:LinkButton ID="lnkSubmit" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-save" aria-hidden="true"></i> Submit</asp:LinkButton>
       <%-- <asp:Button ID="btnNext4" class="btn btn-lg btn-success w3-center next btnext" runat="server" UseSubmitBehavior=false Text="Save" />--%>
      </center>  
  </div>

    </div>
    </form>
</div>
   

</asp:Content>