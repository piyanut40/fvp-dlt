<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Bill.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="Bill" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

  <header class="w3-container" style="margin-top: 10px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">ข้อมูล ใบเสร็จรับเงิน</b></a>
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


</script>
<br />
  
   <div class="w3-row w3-padding-small"> 
            <div class="w3-col l2 <% Response.Write(Css)%>">
               <i class="fa fa-search" aria-hidden="true"></i> กรองการค้นหา :
            </div>

            <div class="w3-col l2">
            <asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="เลขที่ใบเสร็จ" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
            </div>


          </div><br />

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <%--<asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False"  
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" PageSize="20" CssClass="footable table-striped table-bordered table-lg table-center">--%>
         <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass="table table-striped table-bordered table-center table-hover " >
         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                          <asp:Label id="lblid" runat="server" Text='<%# eval("id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="rownum" HeaderText="<center>No.</center>" ItemStyle-Width="60px"  
                 HtmlEncode="False"  ItemStyle-HorizontalAlign="Center"/>

             <asp:BoundField DataField="license_no" HeaderText="<center>เลขที่เครื่องหมายแสดงการใช้รถ</center>" 
                 HtmlEncode="False" />

             <asp:BoundField DataField="receipt_no" HeaderText="<center>เลขที่ใบเสร็จ</center>" HtmlEncode="False" ItemStyle-HorizontalAlign="Center" />

             <asp:BoundField DataField="registrar_name" HeaderText="<center>ชื่อนายทะเบียน</center>" HtmlEncode="False" />

             <asp:BoundField DataField="registrar_position" HeaderText="<center>ชื่อตำแหน่ง</center>" HtmlEncode="False" />

             <asp:BoundField DataField="receipt_pc" HeaderText="<center>เลขที่ PC </center>" HtmlEncode="False" />
             
              <asp:BoundField DataField="receipt_process" HeaderText="<center>เลขที่คุมใบเสร็จ</center>" HtmlEncode="False" ItemStyle-HorizontalAlign="Center" />

               <asp:BoundField DataField="unit" HeaderText="<center>ครั้งที่พิมพ์ใบเสร็จ</center>" HtmlEncode="False" ItemStyle-HorizontalAlign="Center" />

              <asp:TemplateField HeaderText="<center>รายละเอียด </center>"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                 <ItemTemplate>
                                     <asp:HyperLink ID="HyperData" NavigateUrl='<%# Bind("urldata") %>' Target="_blank" runat="server" ><i class="fa fa-file " aria-hidden="true"></i></asp:HyperLink>
                 </ItemTemplate>
         </asp:TemplateField>

         <asp:TemplateField HeaderText="<center>แก้ไข</center>" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperEdit" NavigateUrl="#" runat="server" >
                                             <span data-toggle="modal" data-target="#modalEdit" >
                                             <i class="fa fa-edit" ></i>
                                            </span>
                                         </asp:HyperLink>
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
   

   <div class="modal fade" id="modalEdit" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
              <div class="modal-content">
                <div class="modal-body">
                  <div class="pl-3 modal--title">
                    <div class="row">
                      <u class="hv-bold h3">แก้ไขข้อมูล ใบเสร็จรับเงิน</u>
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

<script type="text/javascript" language="javascript" >
    
     function EditData(Del_ID, Del_Type , Active) {
       
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            document.getElementById('MainContent_HidDel_ID').value = Del_ID;
            document.getElementById('MainContent_HidType').value = Del_Type;
            document.getElementById('MainContent_HidActive').value = Active;
            document.getElementById('MainContent_BtnResetActive').click();
        } else {
            return false;
        }
    }

    function SetHiddenField() {

        var _ctday = document.getElementById("ContentPlaceHolder1_dtqdate_ddlDay");
        var _ctmonth = document.getElementById("ContentPlaceHolder1_dtqdate_ddlMonth");
        var _ctyear = document.getElementById("ContentPlaceHolder1_dtqdate_ddlYear");
        _NewDate = DateSerial((+_ctyear.value), (+_ctmonth.value), (+_ctday.value));

        document.getElementById('ContentPlaceHolder1_Hidtxtqdate').value = _NewDate; 
    }

    function SetPopupEdit(gid, registar_name, registar_position, Reciept_pc, Reciept_process, Reciept, unit) {
 
        document.getElementById('MainContent_Hidid').value = gid;
        document.getElementById('MainContent_txtregistar_name').value = registar_name;
        document.getElementById('MainContent_txtregistar_position').value = registar_position;
        document.getElementById('MainContent_txtReciept_pc').value = Reciept_pc;
        document.getElementById('MainContent_txtReciept_process').value = Reciept_process;
        document.getElementById('MainContent_txtReciept').value = Reciept;
        document.getElementById('MainContent_Hidunit').value = unit;

    }       
</script>

<asp:Panel ID="PnDelete" style="DISPLAY: none" runat="server" >
        <asp:HiddenField id="Hidid" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="Hidunit" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="HidType" runat="server"></asp:HiddenField>
        <asp:HiddenField id="HidActive" runat="server"></asp:HiddenField> 

        <asp:Button style="DISPLAY: none" id="BtnReceipt" runat="server" UseSubmitBehavior="false"></asp:Button> 

   <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:ImageButton ID="BtnSch" runat="server"  ImageUrl="~/images/schd.gif" />
    </ContentTemplate>
    </asp:UpdatePanel>
       
</asp:Panel>




<script  type='text/javascript'>



    jQuery(function ($) {
        $('#MainContent_gvMain').footable({
            "paging": {
                "enabled": true
            }

        });

    });

</script>

</asp:Content>