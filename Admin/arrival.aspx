<%@ Page Language="VB" AutoEventWireup="false" CodeFile="arrival.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="Admin_arrival" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" Runat="Server">
   <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
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

    <header class="w3-container" style="margin-top: 15px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;"><% Response.Write(text)%></b></a><br /><br/>
</header>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


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


         <div class="w3-row w3-padding-small"  > 
            <div class="w3-col l2 <% Response.Write(Css)%>">
               <i class="fa fa-search" aria-hidden="true"></i> กรองการค้นหา :
            </div>
            <div class="w3-col l1 mr-2">
             <asp:DropDownList ID="ddlYear" class="w3-input w3-border w3-round-large" runat="server" AppendDataBoundItems="true" onchange="document.getElementById('MainContent_BtnSch').click();">
                 <asp:ListItem Value="all" Text="ปีทั้งหมด"></asp:ListItem>
                 </asp:DropDownList>
            </div>
             <div class="w3-col l3 mr-2">
             <asp:DropDownList ID="ddladmin" class="w3-input w3-border w3-round-large" runat="server" AppendDataBoundItems="true" onchange="document.getElementById('MainContent_BtnSch').click();">
                 <asp:ListItem Value="all" Text="สนง.ขนส่งทั้งหมด"></asp:ListItem>
                 </asp:DropDownList>
             </div>
            <div class="w3-col l2 mr-2">
            <asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="ชื่อผู้ใช้รถ" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
            </div>
              

           
          </div>
       <div class="w3-row w3-padding-small"  > 
            <div class="w3-col l2 w3-padding-top w3-padding-right w3-right-align">
            </div>
            <div class="w3-col l1  mr-2">
            <asp:TextBox ID="txtplate" class="w3-input w3-border w3-round-large"  placeholder="ป้ายทะเบียน" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>
            <div class="w3-col l1  mr-2">
            <asp:TextBox ID="txtlicense_no" class="w3-input w3-border w3-round-large"  placeholder="Permit No." oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>

            <div class="w3-col l2 mr-2">
              <asp:DropDownList ID="ddlCountry" runat="server" class="w3-input w3-border w3-round-large" onchange="document.getElementById('MainContent_BtnSch').click();" AppendDataBoundItems="true"> 
              <%--<asp:ListItem Value="" Text="เลือกทั้งหมด"></asp:ListItem>--%></asp:DropDownList>
            </div>
           <asp:Panel ID="pnCommerce" Visible="false" runat="server">

            <div class="w3-col l1 <% Response.Write(Css)%>">
                สถานะ :
            </div>

            <div class="w3-col l2">
            <asp:UpdatePanel ID="updateSearch" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DropDownList ID="ddlstatussearch" class="w3-input w3-border w3-round-large" AutoPostBack=true runat="server">
                <asp:ListItem value="1" Text="รอออกเครื่องหมาย"></asp:ListItem>
                 <asp:ListItem value="2" Text="ออกเครื่องหมายเสร็จสมบูรณ์"></asp:ListItem>
              
                </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlstatussearch" EventName="SelectedIndexChanged" />
                </Triggers>
          </asp:UpdatePanel>
            </div>
           </asp:Panel>
           </div>
            <div class="w3-row w3-padding-small"  > 
            <div class="w3-col l2 <% Response.Write(Css)%> ">
            กรองตาม :
            </div>
           <div class="w3-col l2 mr-2">
             <asp:DropDownList ID="ddldate" class="w3-input w3-border w3-round-large" runat="server" AppendDataBoundItems="true" onchange="document.getElementById('MainContent_BtnSch').click();">
                 <asp:ListItem Value="1" Text="วันที่ออกใบเสร็จ"></asp:ListItem>
                 <asp:ListItem Value="2" Text="วันที่แจ้งขอเข้าประเทศ"></asp:ListItem>
                 </asp:DropDownList>
            </div>

             <div class="w3-col l1 mr-2">
            <asp:TextBox ID="txtstartdate"  class="w3-input w3-border w3-round-large" autocomplete="off" placeholder="ระหว่างวันที่" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>
           
            <div class="w3-col l1 mr-2">
            <asp:TextBox ID="txtexpdate"  class="w3-input w3-border w3-round-large" autocomplete="off" placeholder="ถึงวันที่" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>
      </div>



    <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <%--<asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" CssClass="table-striped table-bordered footable">--%>
        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass="table table-striped table-bordered table-center table-hover " >
         <Columns>
             <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                    
                                    <asp:Label id="lblnumber" runat="server" Text='<%# eval("number") %>'></asp:Label>
                                          <asp:Label id="lblLicense" runat="server" Text='<%# eval("license_id") %>'></asp:Label>
                                          <asp:Label id="lbltoken" runat="server" Text='<%# eval("token") %>'></asp:Label>
                                           <asp:Label id="lbltypeuser_id" runat="server" Text='<%# eval("typeuser_id") %>'></asp:Label>
                                           <asp:Label id="lblstatus_id" runat="server" Text='<%# eval("status_id") %>'></asp:Label>
                                           <asp:Label id="lbllicense_no" runat="server" Text='<%# eval("license_no") %>'></asp:Label>
                                           <asp:Label id="lblold_group_id" runat="server" Text='<%# eval("old_group_id") %>'></asp:Label>
                                            <asp:Label id="lblreceipt_no" runat="server" Text='<%# eval("receipt") %>'></asp:Label>
                                           
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" HeaderText="<center>No.</center>"  ItemStyle-Width="78px"
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center"/>

            
             <asp:BoundField DataField="license_no" HeaderText="<center>เลขที่เครื่องหมาย<br />แสดงการใช้รถ</center>"    HtmlEncode="False" ItemStyle-Width="150" />

             <asp:BoundField DataField="name" HeaderStyle-CssClass="w3-center" />

             <asp:BoundField DataField="brands" HeaderText="<center>ยี่ห้อรถ</center>" HtmlEncode="False" />

             <asp:BoundField DataField="plate" HeaderText="<center>ป้ายทะเบียนรถ</center>" HtmlEncode="False" />

             <asp:BoundField DataField="models" HeaderText="<center>รุ่นรถ</center>" HtmlEncode="False" />

             <asp:BoundField DataField="typecar_en" HeaderText="<center>ประเภทรถ</center>" HtmlEncode="False" />

             <asp:BoundField DataField="country_car" HeaderText="<center>ประเทศรถ</center>" HtmlEncode="False" />

             <asp:BoundField DataField="vehicle_type" HeaderText="<center>ประเภทสินค้า</center>" HtmlEncode="False" />

             <asp:BoundField DataField="status_th" HeaderText="<center>สถานะ</center>" HtmlEncode="False" ItemStyle-HorizontalAlign="Center"  />

               <asp:BoundField DataField="count" HeaderText="<center>พิมพ์ครั้งที่</center>" HtmlEncode="False" ItemStyle-HorizontalAlign="Center" />

              <asp:TemplateField HeaderText="<center>แผนที่ </center>" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="Hyperplan" NavigateUrl="#" runat="server" ><img src="../image/icon2/earth-globe.png"  width="17px"  height="17px"></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>
             
             <asp:TemplateField HeaderText="<center>ดู </center>" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <%--<asp:HyperLink ID="HyperDoc" NavigateUrl='<%# Bind("urlDoc") %>' Target="_parent" runat="server" ToolTip="ดูข้อมูล" ><i class="fa fa-file" aria-hidden="true" ></i></asp:HyperLink>--%>
                                         <asp:HyperLink ID="HyperDoc" NavigateUrl='<%# Bind("urlDoc") %>' Target="_parent" runat="server" ToolTip="ดูข้อมูล" ></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>


             <asp:TemplateField HeaderText="<center>พิมพ์ใบอนุญาต </center>" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" Visible="false" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperPDF" NavigateUrl='<%# Bind("urlPDF") %>' Target="_blank" runat="server" ><img src="../image/pdf32.png" height="20px"/></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

                 <asp:TemplateField HeaderText="<center>พิมพ์ซ้ำ </center>" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperPDFNew" NavigateUrl="#" runat="server" >
                                             <span data-toggle="modal" data-target="#Model3" >
                                             <i class="fa fa-share-square-o" aria-hidden="true"></i>
                                            </span>
                                         </asp:HyperLink>
              
                                    </ItemTemplate>  
             </asp:TemplateField>

             <asp:TemplateField HeaderText="<center>เครื่องหมาย </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperSign" NavigateUrl='<%# Bind("urlSign") %>' Target="_blank" runat="server" ><asp:Image ID="Image1" runat="server" ImageUrl="../image/icon_sign.png"  height="20px" /></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>



              <asp:TemplateField HeaderText="<center>ชำระเงิน</center>" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperPay" NavigateUrl="#" runat="server" >
                                             <span data-toggle="modal" data-target="#Model2" >
                                             <i class="fa fa-money" aria-hidden="true"></i>
                                            </span>
                                         </asp:HyperLink>
             <%--<a href="#confirm" data-rel="popup" data-position-to="window" > 
                    <img src="../image/g_delete.gif" > 
                </a>--%>
                                    </ItemTemplate>     
              </asp:TemplateField>

               <asp:TemplateField HeaderText="<center>นายทะเบียน</center>" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperRegist" NavigateUrl="#" runat="server" >
                                             <span data-toggle="modal" data-target="#Model4" >
                                             <i class="fa fa-edit" aria-hidden="true"></i>
                                            </span>
                                         </asp:HyperLink>
             <%--<a href="#confirm" data-rel="popup" data-position-to="window" > 
                    <img src="../image/g_delete.gif" > 
                </a>--%>
                                    </ItemTemplate>     
              </asp:TemplateField>

              <asp:TemplateField  HeaderText="<center>ยกเลิก<br />เครื่องหมาย<br />แสดงการใช้รถ </center>"  ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLinkDel" NavigateUrl="#" runat="server" ><img src="../image/g_delete.gif" ></asp:HyperLink>
                                    </ItemTemplate>     
              </asp:TemplateField>
               <asp:BoundField DataField="cancel_date"  HeaderText="<center>วันที่ยกเลิก</center>" DataFormatString="{0:dd-MM-yyyy เวลา HH:mm}" HtmlEncode="False" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="150" />
            <asp:TemplateField HeaderText="<center>ลบ</center>" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                         <ItemTemplate>
                             <asp:HyperLink ID="btnDelete_Command" NavigateUrl="#" runat="server" ><img src="~/image/g_delete.gif" ></asp:HyperLink>
    <%--<asp:ImageButton ID="btnDelete" runat="server" 
            ImageUrl="~/image/g_delete.gif" 
            CommandArgument='<%# Eval("license_id") %>' 
            OnCommand="btnDelete_Command"
            OnClientClick="return confirm('คุณแน่ใจหรือไม่ว่าต้องการลบข้อมูลนี้?');" />--%>
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
     <asp:HiddenField id="HidDel_ID" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="HidLicense" runat="server"></asp:HiddenField> 
          <asp:Button style="DISPLAY: none" id="BtnPay" runat="server" UseSubmitBehavior="false"></asp:Button> 
          <asp:Button style="DISPLAY: none" id="BtnRegistar"  runat="server" UseSubmitBehavior="false"></asp:Button>
        <asp:Button Visible="false" id="BtnDelete" onclick="BtnDelete_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> 
        <asp:Button style="DISPLAY: none" id="BtnResetActive" onclick="BtnResetActive_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> 
        <asp:Button style="DISPLAY: none" id="BtnReceipt" runat="server" UseSubmitBehavior="false"></asp:Button> 
        

   <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:ImageButton ID="BtnSch" runat="server"/>
    </ContentTemplate>
    </asp:UpdatePanel>
       
</asp:Panel>

  <div class="modal fade" id="Model2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
              <div class="modal-content">
                <div class="modal-body">
                  <div class="pl-3 modal--title">
                    <div class="row">
                      <u class="hv-bold h3">ข้อมูลใบเสร็จ</u>
                      <div class="offset-md-2 ">
                      </div>
                    
                    </div>
                  </div>
                  <div class="pt-4 pb-4">
                  <div class="row">
                  <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">พิมพ์ครั้งที่ : </span>
                              <asp:TextBox  CssClass="w3-input" Enabled=false ID="txtcheckcount" Text="1"  runat="server"></asp:TextBox>
                      </div>

                    <%--<div class="offset-md-2 col-md-6">
                        <span class="hv-bold">กรอกชื่อนายทะเบียน : </span>
                              <asp:TextBox class=" w3-input" ID="txtregistar_name" runat="server"></asp:TextBox>
                      </div>
                    <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">กรอกชื่อตำแหน่ง : </span>
                              <asp:TextBox class=" w3-input" ID="txtregistar_position" runat="server"></asp:TextBox>
                      </div>--%>

                          <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">เลขที่ PC : </span>
                              <asp:TextBox class=" w3-input" ID="txtReciept_pc" runat="server"></asp:TextBox>
                      </div>

                      <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">เลขคุมใบเสร็จ : </span>
                              <asp:TextBox class=" w3-input" ID="txtReciept_process" runat="server"></asp:TextBox>
                      </div>

                      <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">เลขที่ใบเสร็จ : </span>
                              <asp:TextBox class=" w3-input" ID="txtReciept" runat="server"></asp:TextBox>
                      </div>
                       </div>
                       <br />
                       <div class="row">
                       <div class="offset-md-3 col-md-6">
                     
                          <asp:HyperLink ID="HyperLink2" class="w3-button w3-purple w3-padding w3-round"  onclick="document.getElementById('MainContent_BtnPay').click();" runat="server"><i class="fa fa-save" aria-hidden="true"></i> Submit</asp:HyperLink>
                                       
                          <button type="button" class="w3-button w3-purple w3-padding w3-round"  data-dismiss="modal" ><i class="fa fa-close"></i> close</button>
                     </div>
                  </div>
                 </div>
              </div>
            </div>
          </div>
 </div>
            
            <div class="modal fade" id="Model3" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
              <div class="modal-content">
                <div class="modal-body">
                  <div class="pl-3 modal--title">
                    <div class="row">
                      <u class="hv-bold h3">พิมพ์ใบอนุญาตใหม่</u>
                      <div class="offset-md-2 ">
                      </div>
                    
                    </div>
                  </div>
                  <%--<div class="pt-4 pb-4">
                    <div class="row">
                      <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">กรอกเลขที่ใบอนุญาต : </span>
                              <asp:TextBox class=" w3-input" ID="TextBox2" runat="server"></asp:TextBox>
                      </div>
                       </div>
                       <br />
                       <div class="row">
                       <div class="offset-md-3 col-md-6">
                     
                          
                     </div>
                  </div>
                 </div>--%>

                  <div class="pt-4 pb-4">
                    <div class="row">

                     <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">พิมพ์ครั้งที่ : </span>
                              <asp:TextBox CssClass=" w3-input" Enabled=false ID="txtcheckcount2" runat="server"></asp:TextBox>
                      </div>

                    <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">กรอกชื่อนายทะเบียน : </span>
                              <asp:TextBox class=" w3-input" ID="txtregistar_name2" runat="server"></asp:TextBox>
                      </div>
                    <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">กรอกชื่อตำแหน่ง : </span>
                              <asp:TextBox class=" w3-input" ID="txtregistar_position2" runat="server"></asp:TextBox>
                      </div>

                          <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">เลขที่ PC : </span>
                              <asp:TextBox class=" w3-input" ID="txtReciept_pc2" runat="server"></asp:TextBox>
                      </div>

                      <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">เลขคุมใบเสร็จ : </span>
                              <asp:TextBox class=" w3-input" ID="txtReciept_process2" runat="server"></asp:TextBox>
                      </div>

                      <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">เลขที่ใบเสร็จ : </span>
                              <asp:TextBox class=" w3-input" ID="txtReciept2" runat="server"></asp:TextBox>
                      </div>
                       </div>
                       <br />
                       <br />
                       <div class="row">
                       <div class="offset-md-3 col-md-6">
                     
                          <asp:HyperLink ID="HyperLink1" class="w3-button w3-purple w3-padding w3-round"  onclick="document.getElementById('MainContent_BtnReceipt').click();" runat="server"><i class="fa fa-save" aria-hidden="true"></i> Submit</asp:HyperLink>
                                       
                          <button type="button" class="w3-button w3-purple w3-padding w3-round"  data-dismiss="modal" ><i class="fa fa-close"></i> close</button>
                     </div>
                  </div>
                 </div>

                  
              </div>
            </div>
          </div>
 </div>

   <div class="modal fade" id="Model4" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
              <div class="modal-content">
                <div class="modal-body">
                  <div class="pl-3 modal--title">
                    <div class="row">
                      <u class="hv-bold h3">ข้อมูลนายทะเบียน</u>
                      <div class="offset-md-2 ">
                      </div>
                    
                    </div>
                  </div>
                  <div class="pt-4 pb-4">
                  <div class="row">
                  <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">กรอกชื่อนายทะเบียน : </span>
                              <asp:TextBox class=" w3-input" ID="txtregistar_name" runat="server"></asp:TextBox>
                      </div>
                    <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">กรอกชื่อตำแหน่ง : </span>
                              <asp:TextBox class=" w3-input" ID="txtregistar_position" runat="server"></asp:TextBox>
                      </div>
                       </div>
                       <br />
                       <div class="row">
                       <div class="offset-md-3 col-md-6">
                     
                          <asp:HyperLink ID="HyperLink3" class="w3-button w3-purple w3-padding w3-round" OnClientClick="$('#loadings').show();"  onclick="document.getElementById('MainContent_BtnRegistar').click();" runat="server"><i class="fa fa-save" aria-hidden="true"></i> Submit</asp:HyperLink>
                                       
                          <button type="button" class="w3-button w3-purple w3-padding w3-round"  data-dismiss="modal" ><i class="fa fa-close"></i> close</button>
                     </div>
                  </div>
                 </div>
              </div>
            </div>
          </div>
 </div>
<script type="text/javascript">
    function DelUsertravel(Del_ID, Del_Type) {
        var Msg = 'คุณต้องการลบข้อมูลใช่หรือไม่?';
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            document.getElementById('MainContent_HidDel_ID').value = Del_ID;
            document.getElementById('MainContent_HidType').value = Del_Type;
            document.getElementById('MainContent_BtnDelete').click();
        } else {
            return false;
        }
    }

    function Pay(license_id) {
        document.getElementById('MainContent_HidLicense').value = license_id;
        document.getElementById('MainContent_IframeReceipt').src = "ReceiptData.aspx?license_id=" + license_id;

        document.getElementById('MainContent_txtRecieptNew').value = "";

    }

    function Pay2(license_id, count) {

        document.getElementById('MainContent_txtcheckcount2').value = count
        document.getElementById('MainContent_HidLicense').value = license_id;
        document.getElementById('MainContent_IframeReceipt').src = "ReceiptData.aspx?license_id=" + license_id;

        document.getElementById('MainContent_txtRecieptNew').value = "";

    }

    function Regist(license_id) {
        document.getElementById('MainContent_HidLicense').value = license_id;


    }


    function DelUser(license_id) {
        var Msg = 'ต้องการยกเลิกใบอนุญาต ?'; 
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            document.getElementById('MainContent_HidLicense').value = license_id;
            document.getElementById('MainContent_BtnDelete').click();
        } else {
            return false;
        }
    }


    function ResetActive(license_id) {
        console.log(license_id);
        var Msg = 'อนุมัติ ใบอนุญาต ?';
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            document.getElementById('MainContent_HidLicense').value = license_id;

        } else {
            return false;
        }
    }

    function linkDoc(url, token) {
        console.log(url);
        console.log(token);
        return false;
    }


</script>

</asp:Content>