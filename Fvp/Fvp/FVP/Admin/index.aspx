<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="Admin_index" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" Runat="Server">
   <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
</asp:Content>
 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <header class="w3-container" style="margin-top: 15px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;"><% Response.Write(text)%></b></a><br /><br/>
</header>
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


     $(function () {
    var _year = <% Response.Write(_year)%>;

         var queryDate = _year + '-01-01',
         dateParts = queryDate.match(/(\d+)/g)
         realDate = new Date(dateParts[0], dateParts[1] - 1, dateParts[2]);

        $("#<%=txtstartdate.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            setDate: new Date(),
            dateFormat: 'dd/mm/yy',
            showButtonPanel: true
//        }).datepicker('setDate', realDate);
            });
        $("#<%=txtstartdate.ClientID %>").keyup(function () {
            $("#<%=txtstartdate.ClientID %>").val('');
        })

        $("#<%=txtexpdate.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            setDate: new Date(),
            dateFormat: 'dd/mm/yy',
            showButtonPanel: true
//        }).datepicker('setDate', "0");
        });
        $("#<%=txtexpdate.ClientID %>").keyup(function () {
            $("#<%=txtexpdate.ClientID %>").val('');
        })
    });

</script>


        <div class="w3-row w3-padding-small"> 
            <div class="w3-col l2 <% Response.Write(Css)%>">
               <i class="fa fa-search" aria-hidden="true"></i> กรองการค้นหา :
            </div>
            <div class="w3-col l1 mr-2">
             <asp:DropDownList ID="ddlYear" class="w3-input w3-border w3-round-large" runat="server" AppendDataBoundItems="true" onchange="document.getElementById('MainContent_BtnSch').click();">
                 <asp:ListItem Value="all" Text="ปีทั้งหมด"></asp:ListItem>
                 </asp:DropDownList>
            </div>
             <div class="w3-col l2 mr-2">
             <asp:DropDownList ID="ddladmin" class="w3-input w3-border w3-round-large" runat="server" AppendDataBoundItems="true" onchange="document.getElementById('MainContent_BtnSch').click();">
                 <asp:ListItem Value="all" Text="สนง.ขนส่งทั้งหมด"></asp:ListItem>
                 </asp:DropDownList>
             </div>
            <div class="w3-col l2  mr-2">
            <asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="ชื่อคนขับหลัก" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>
            
            <div class="w3-col l2  mr-2">
            <asp:TextBox ID="txtplate" class="w3-input w3-border w3-round-large"  placeholder="ป้ายทะเบียน" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>

         
           
          </div>
          <div class="w3-row w3-padding-small"> 
           <div class="w3-col l2 <% Response.Write(Css)%>">
               
            </div>
           <div class="w3-col l2  mr-2">
              <asp:DropDownList ID="ddlCountry" runat="server" class="w3-input w3-border w3-round-large" onchange="document.getElementById('MainContent_BtnSch').click();" AppendDataBoundItems="true"> 
              <asp:ListItem Value="" Text="เลือกทั้งหมด"></asp:ListItem></asp:DropDownList>
            </div>

               <div class="w3-col l2  mr-2">
            <asp:TextBox ID="txtTour" class="w3-input w3-border w3-round-large" placeholder="บริษัททัวร์" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>

                <div class="w3-col l1  mr-2">
            <asp:TextBox ID="txtstartdate"  class="w3-input w3-border w3-round-large" autocomplete="off" placeholder="ระหว่างวันที่" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>
           
            <div class="w3-col l1 mr-2">
            <asp:TextBox ID="txtexpdate"  class="w3-input w3-border w3-round-large" autocomplete="off" placeholder="ถึงวันที่" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>
           

            <div class="w3-col l2  w3-right-align" id="divAddType5" runat="server">

             <asp:LinkButton ID="lnkAdd" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-plus" aria-hidden="true" ></i>  รถตามความตกลงระหว่างประเทศรถขนส่งเชิงพาณิชย์</asp:LinkButton>
            </div>
          </div>
  

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

      <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass="table table-striped table-bordered table-center table-hover " >
         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                    
                                     <asp:Label id="lblnumber" runat="server" Text='<%# eval("number") %>'></asp:Label>
                                          <asp:Label id="lblLicense" runat="server" Text='<%# eval("license_id") %>'></asp:Label>
                                          <asp:Label id="lbltoken" runat="server" Text='<%# eval("token") %>'></asp:Label>
                                           <%--<asp:Label id="lblcount" runat="server" Text='<%# eval("count") %>'></asp:Label>--%>
                                           <asp:Label id="lbltypeuser_id" runat="server" Text='<%# eval("typeuser_id") %>'></asp:Label>
                                           <asp:Label id="lblstatus_id" runat="server" Text='<%# eval("status_id") %>'></asp:Label>
                                           <asp:Label id="lblReason" runat="server" Text='<%# eval("Reason") %>'></asp:Label>
                                           <asp:Label id="lblcheck_tab1" runat="server" Text='<%# eval("check_tab1") %>'></asp:Label>
                                           <asp:Label id="lblcheck_tab2" runat="server" Text='<%# eval("check_tab2") %>'></asp:Label>
                                           <asp:Label id="lblcheck_tab3" runat="server" Text='<%# eval("check_tab3") %>'></asp:Label>
                                           <asp:Label id="lblcheck_tab4" runat="server" Text='<%# eval("check_tab4") %>'></asp:Label>
                                           <asp:Label id="lblcheck_tab5" runat="server" Text='<%# eval("check_tab5") %>'></asp:Label>
                                           <asp:Label id="lblcheck_tab6" runat="server" Text='<%# eval("check_tab6") %>'></asp:Label>
                                           <asp:Label id="lblcheck_tab7" runat="server" Text='<%# eval("check_tab7") %>'></asp:Label>

                                           <asp:Label id="lblcheck_tab0" runat="server" Text='<%# eval("check_tab0") %>'></asp:Label>
                                           <asp:Label id="lblcheck_tab8" runat="server" Text='<%# eval("check_tab8") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" HeaderText="<center>No.</center>" 
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center"/>



             <asp:BoundField DataField="name" HeaderText="<center>ชื่อ - นามสกุล</center>" HtmlEncode="False"/>

             <asp:BoundField DataField="brands" HeaderText="<center>ยี่ห้อรถ</center>" HtmlEncode="False" />

             <asp:BoundField DataField="plate" HeaderText="<center>ป้ายทะเบียนรถ</center>" HtmlEncode="False" />

             <asp:BoundField DataField="models" HeaderText="<center>รุ่นรถ</center>" HtmlEncode="False" />

             <asp:BoundField DataField="country_car" HeaderText="<center>ประเทศรถ</center>" HtmlEncode="False" />


             <asp:BoundField DataField="typecar_en" HeaderText="<center>ประเภทรถ</center>" HtmlEncode="False" />
             
          

             <asp:BoundField DataField="vehicle_type" HeaderText="<center>ประเภทสินค้า</center>" HtmlEncode="False" />

             <asp:BoundField DataField="name_company" HeaderText="<center>บริษัททัวร์</center>" HtmlEncode="False" />
            	
              <asp:BoundField DataField="guide" HeaderText="<center>ผู้นำเที่ยว</center>" HtmlEncode="False" />
              
                <asp:BoundField DataField="start_date" HeaderText="<center>วันเริ่มต้น</center>" HtmlEncode="False" />
                <asp:BoundField DataField="exp_date" HeaderText="<center>วันสิ้นสุด</center>"  HtmlEncode="False" />

                   <asp:BoundField DataField="status_th" HeaderText="<center>สถานะ</center>" HtmlEncode="False" />

             
            
             <asp:TemplateField HeaderText="<center>ตรวจสอบ </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperDoc" NavigateUrl='<%# Bind("urlDoc") %>' Target="_parent" runat="server" ToolTip="ดูข้อมูล" ><i class="fa fa-file " ></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="<center>แก้ไข </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperMgt" NavigateUrl='<%# Bind("urlMgt") %>' Target="_parent" runat="server" ToolTip="แก้ไขข้อมูล"><i class="fa fa-edit" ></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

       

             


              <asp:TemplateField HeaderText="<center>ลบ</center>" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLinkDel" NavigateUrl="#" runat="server" ><img src="../image/g_delete.gif" ></asp:HyperLink>
            
                                    </ItemTemplate>     
              </asp:TemplateField>
         </Columns>
      <PagerTemplate>
          <div class="w3-row w3-padding-small"> 
                      
            <div class="col ">
             <div  class="w3-right"> 

               <asp:LinkButton ID="btnLast" runat="server" CommandArgument="Last" CommandName="Page"  class="w3-right btn w3-button w3-padding-small w3-round w3-large" >สุดท้าย</asp:LinkButton>
              <asp:LinkButton ID="btnNext" runat="server" CommandArgument="Next" CommandName="Page" class="w3-right btn w3-button w3-padding-small w3-round w3-large" >ถัดไป</asp:LinkButton> 
  
             
             <%-- <a href="#" class="btn disabled">--%>
                <asp:LinkButton ID="btnPrev" class="w3-right btn w3-button w3-padding-small w3-round w3-large" runat="server" CommandArgument="Prev" CommandName="Page" >ก่อนหน้า</asp:LinkButton>
             <%-- </a>--%>

              <%--<a href="#" class="btn disabled">--%>
               <asp:LinkButton ID="btnFirst" class="w3-right btn w3-button w3-padding-small w3-round w3-large" runat="server" CommandArgument="First" CommandName="Page" >แรกสุด </asp:LinkButton>
              <%--</a>--%>
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
        </PagerTemplate> 
    </asp:GridView>
      <p class="w3-left w3-padding "> แสดงผลข้อมูล จำนวน  </p>
    <p class="w3-left "> <asp:DropDownList id="ddl_PageSize" runat="server" class="w3-input w3-border w3-round-large" Style="position: static"  AppendDataBoundItems="True" AutoPostBack="True"></asp:DropDownList>  </p>
    <p class="w3-left w3-padding "> ราย  </p>


</ContentTemplate>
  </asp:UpdatePanel>

<asp:Panel ID="PnDelete" style="DISPLAY: none" runat="server" >
        <asp:HiddenField id="HidLicense" runat="server"></asp:HiddenField> 
        <asp:Button style="DISPLAY: none" id="BtnDelete" runat="server" UseSubmitBehavior="false" ></asp:Button> 
        <asp:Button style="DISPLAY: none" id="BtnResetActive" runat="server" UseSubmitBehavior="false" ></asp:Button> 
        <asp:Button style="DISPLAY: none" id="BtnSave" runat="server" UseSubmitBehavior="false" ></asp:Button>
        <asp:HiddenField id="HidDel_ID" runat="server"></asp:HiddenField> 
   <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:ImageButton ID="BtnSch" runat="server"/>
    </ContentTemplate>
    </asp:UpdatePanel>
       
</asp:Panel>

 <asp:HiddenField id="HiddenField1" runat="server"></asp:HiddenField> 


  <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
              <div class="modal-content">
                <div class="modal-body">
                  <div class="pl-3 modal--title">
                    <div class="row">
                      <u class="hv-bold h3">อนุมัติ</u>
                      <div class="offset-md-2 ">
                      </div>
                    
                    </div>
                  </div>
                  <div class="pt-4 pb-4">
                    <div class="row">
                      <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">สถานะ : </span>
                          <asp:DropDownList ID="ddlstatus" runat="server" AppendDataBoundItems="true" onchange="javascript:ChangeStatus()" >
                              <asp:ListItem Selected="True" Value="0">รออนุมัติ</asp:ListItem>
                              <asp:ListItem  Value="1">อนุมัติ</asp:ListItem>
                              <asp:ListItem  Value="2">เอกสารไม่สมบูรณ์</asp:ListItem>
                              <asp:ListItem  Value="3">ไม่ผ่าน</asp:ListItem>
                             <%-- <asp:ListItem  Value="4">ยกเลิกใบอนุญาต</asp:ListItem>--%> 
                          </asp:DropDownList>
                         
                        
                      </div>
                       </div>
                       <br />
                       <div class="row" id="divreason" runat="server">
                      <div class="offset-md-2 col-md-8">
                        <span class="hv-bold">เหตุผลเพิ่มเติม : </span>
                         <asp:TextBox ID="txtreason" TextMode="MultiLine" class="w3-input w3-border w3-round-large" runat="server" placeholder="เหตุผลเพิ่มเติม" ></asp:TextBox>
                         
                        
                      </div>
                       </div>
                       <br />
                       <div class="row">
                       <div class="offset-md-3 col-md-6">
                     
                          <asp:HyperLink ID="HyperLink1" class="w3-button w3-purple w3-padding w3-round"  onclick="document.getElementById('MainContent_BtnSave').click();" runat="server"><i class="fa fa-save" aria-hidden="true"></i> Submit</asp:HyperLink>
                                       
                          <button type="button" class="w3-button w3-purple w3-padding w3-round"  data-dismiss="modal" ><i class="fa fa-close"></i> close</button>
                     </div>
                  </div>
                 </div>
              </div>
            </div>
          </div>
 </div>
                                





<script type="text/javascript">


    function Save() {
       
        document.getElementById('MainContent_BtnSave').click();
    }

    function setModalDoc(license_id, status, reason) {
//        alert(status);
        document.getElementById('MainContent_ddlstatus').value = status;
        document.getElementById('MainContent_HidLicense').value = license_id;
        document.getElementById('MainContent_txtreason').value = reason;
        ChangeStatus();
    }

    function ChangeStatus() {

        var _ddlstatus = document.getElementById('MainContent_ddlstatus').value;
        var _div = document.getElementById('MainContent_divreason');
        if (_ddlstatus == 2)  {
            //            _div.style.visibility = "visible";
            _div.style.display = "block";
        }
        else if (_ddlstatus == 3){
            _div.style.display = "block";
        }
        else {
            //            _div.style.visibility = "hidden";
            _div.style.display = "none";
        }

    }

      function DelData(license_id) {
          var Msg = 'ต้องการยกเลิกคำขออนุญาต ?';
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            document.getElementById('MainContent_HidDel_ID').value = license_id;
            document.getElementById('MainContent_BtnDelete').click();
        } else {
            return false;
        }
    }


    function ResetActive(license_id) {
        
        var Msg = ' ต้องการอนุมัติใบอนุญาต ?';
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            console.log(license_id);
            document.getElementById('MainContent_HidLicense').value = license_id;
            document.getElementById('MainContent_BtnResetActive').click();
        } else {
            return false;
        }
    }



</script>

</asp:Content>