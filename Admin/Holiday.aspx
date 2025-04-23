<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Holiday.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="Admin_Holiday" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
    <link href="../Styles/progress-wizard.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>

    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/jodit/3.1.39/jodit.min.css">
    <script src="//cdnjs.cloudflare.com/ajax/libs/jodit/3.1.39/jodit.min.js"></script>
       
<style>
  body {
      overflow-x: unset;
   
      }
  @font-face{
      font-family: 'Kanit', sans-serif;
        src : url('font/ThaiSansNeue-Regular/thaisansneue-bold-webfont.woff2');
    
    
    }
.adduser
{
 margin-top: 0px;   
    
 }@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
.adduser{ margin-top:10px; }
    
}
 @media screen and (min-width: 360px) and (max-width:376px) and (orientation : portrait)
{
     
.adduser{ margin-top:10px; }
     
}
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
 {
 .adduser{ margin-top:10px; }
  }
    
  </style>
  <header class="w3-container" style="margin-top: 10px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">จัดการข้อมูลวันหยุดประจำปี</b></a>
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
         $("#<%=txth_date.ClientID %>").datepicker({
             changeMonth: true
            , changeYear: true
            , yearRange: "-1 :+10"
            , setDate: new Date()
//            , minDate: '0'
            , showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
         });
         $("#<%=txth_date.ClientID %>").keyup(function () {
             $("#<%=txth_date.ClientID %>").val('');
         })
     });
</script>
<br />
  
   <div class="w3-row w3-padding-small"> 
            <div class="w3-col l2 <% Response.Write(Css)%>">
               <i class="fa fa-search" aria-hidden="true"></i> กรองการค้นหา :
            </div>

            <div class="w3-col l2">
            <asp:DropDownList ID="ddlYear" class="w3-input w3-border w3-round-large" runat="server" AppendDataBoundItems="true" onchange="document.getElementById('MainContent_BtnSch').click();">
                 <asp:ListItem Value="all" Text="ปีทั้งหมด"></asp:ListItem>
                 </asp:DropDownList>
            </div>
               <div class="w3-col l8 w3-right-align">
                <%--<asp:LinkButton ID="lnkAdd"  class="w3-button w3-purple2 w3-padding w3-round adduser" runat="server" data-target="#Model1"><i class="fa fa-plus" aria-hidden="true"  ></i> เพิ่ม  </asp:LinkButton>--%>
                <asp:HyperLink ID="lnkAdd"  class="w3-button w3-purple2 w3-padding w3-round adduser" NavigateUrl="#" runat="server" >
                                             <span data-toggle="modal" data-target="#Model1" onclick="Add()" ><i class="fa fa-plus" aria-hidden="true"  ></i>  เพิ่ม </span> </asp:HyperLink>
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
                                          <asp:Label id="lblid" runat="server" Text='<%# eval("gid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" HeaderText="<center>No.</center>" ItemStyle-Width="60px"  
                 HtmlEncode="False"  ItemStyle-HorizontalAlign="Center"/>

             <asp:BoundField DataField="year_id" HeaderText="<center>ปี</center>" 
                 HtmlEncode="False" />

                 <asp:BoundField DataField="hdate" HeaderText="<center>วันที่</center>" 
                 HtmlEncode="False" />

             <asp:BoundField DataField="description" HeaderText="<center>รายละเอียด</center>" HtmlEncode="False" />



                <asp:TemplateField HeaderText="<center>แก้ไข</center>" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperEdit" NavigateUrl="#" runat="server" >
                                             <span data-toggle="modal" data-target="#Model1" >
                                             <i class="fa fa-edit" aria-hidden="true"></i>
                                            </span>
                                         </asp:HyperLink>
  
                                    </ItemTemplate>     
              </asp:TemplateField>


              <asp:TemplateField HeaderText="<center>ลบ</center>" ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" >
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
    <p class="w3-left w3-padding "> รายการ  </p>
</ContentTemplate>
  </asp:UpdatePanel>

  <p class="w3-left w3-padding " style="color:Red"> <b>*เฉพาะวันหยุด/วันหยุดชดเชยที่ตรงกับวันทำการฯ</b>  </p>
   
    <div class="modal fade" id="Model1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
              <div class="modal-content">
                <div class="modal-body">
                  <div class="pl-3 modal--title">
                    <div class="row">
                      <u class="hv-bold h3">ข้อมูลวันหยุดประจำปี</u>
                      <div class="offset-md-2 ">
                      </div>
                    
                    </div>
                  </div>
                  <div class="pt-4 pb-4">
                  <div class="row">

                          <div class="offset-md-2 col-md-6" style="display:none">
                        <span class="hv-bold">ปี : </span>
                              <asp:DropDownList ID="ddlYear0" class="w3-input w3-border w3-round-large" runat="server" AppendDataBoundItems="true" >
                 <asp:ListItem Value="all" Text="ปีทั้งหมด"></asp:ListItem>
                 </asp:DropDownList>
                      </div>

                      <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">วันที่ : </span>
                              <asp:TextBox class=" w3-input" ID="txth_date" autocomplete="off" runat="server"></asp:TextBox>
                      </div>

                      <div class="offset-md-2 col-md-6">
                        <span class="hv-bold">รายละเอียด : </span>
                              <asp:TextBox class=" w3-input" ID="txtdesc" runat="server"></asp:TextBox>
                      </div>
                       </div>
                       <br />
                       <div class="row">
                       <div class="offset-md-3 col-md-6">
                     
                          <asp:HyperLink ID="HyperLink2" class="w3-button w3-purple w3-padding w3-round"  onclick="document.getElementById('MainContent_BtnSave').click();" runat="server"><i class="fa fa-save" aria-hidden="true"></i> Submit</asp:HyperLink>
                                       
                          <button type="button" class="w3-button w3-purple w3-padding w3-round"  data-dismiss="modal" ><i class="fa fa-close"></i> close</button>
                     </div>
                  </div>
                 </div>
              </div>
            </div>
          </div>
 </div>


<script type="text/javascript" language="javascript" >
    
    function DelUser(Del_ID) {
        var Msg = 'คุณต้องการลบข้อมูลใช่หรือไม่?';
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            document.getElementById('MainContent_HidDel_ID').value = Del_ID;
            document.getElementById('MainContent_BtnDelete').click();
        } else {
            return false;
        }
    }

    function Edit(gid, date, desc) {

        //        document.getElementById('MainContent_txth_date').value = date.replace("-", "/");
        $("#<%=txth_date.ClientID %>").val(date.replace(/-/g, "/"));
        document.getElementById('MainContent_hid_id').value = gid;
        document.getElementById('MainContent_txtdesc').value = desc;

    }

    function Add() {

        //        document.getElementById('MainContent_txth_date').value = date.replace("-", "/");
        $("#<%=txth_date.ClientID %>").val('');
        document.getElementById('MainContent_hid_id').value = '';
        document.getElementById('MainContent_txtdesc').value = '';

    }


</script>

<asp:Panel ID="PnDelete" style="DISPLAY: none" runat="server" >
  <asp:HiddenField ID="hid_id" runat="server" />
        <asp:HiddenField id="HidDel_ID" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="HidType" runat="server"></asp:HiddenField>
        <asp:HiddenField id="HidActive" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="HidUsername" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="Hidptype" runat="server"></asp:HiddenField>
        <asp:Button style="DISPLAY: none" id="BtnDelete" onclick="BtnDelete_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> 
        <asp:Button style="DISPLAY: none" id="BtnSave" onclick="BtnSave_Click" runat="server" UseSubmitBehavior="false"></asp:Button> 

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