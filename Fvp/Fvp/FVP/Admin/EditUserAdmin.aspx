<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditUserAdmin.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="EditUserAdmin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

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
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">จัดการข้อมูลสมาชิกระบบ Foreign Vehicle Permit (FVP)</b></a>
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
            <asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="Username สมาชิก" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
            </div>
               <div class="w3-col l8 w3-right-align">
                <asp:LinkButton ID="lnkAdd" class="w3-button w3-purple2 w3-padding w3-round adduser" runat="server"><i class="fa fa-plus" aria-hidden="true" ></i> เพิ่ม USER </asp:LinkButton>
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
                                          <asp:Label id="lblid" runat="server" Text='<%# eval("user_id") %>'></asp:Label>
                                          <asp:Label id="lblusername" runat="server" Text='<%# eval("username") %>'></asp:Label>
                                          <asp:Label id="lblptype" runat="server" Text='<%# eval("ptype") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" HeaderText="<center>No.</center>" ItemStyle-Width="60px"  
                 HtmlEncode="False"  ItemStyle-HorizontalAlign="Center"/>

             <asp:BoundField DataField="username" HeaderText="<center>Username</center>" 
                 HtmlEncode="False" />

             <asp:BoundField DataField="admin_name" HeaderText="<center>สังกัดสำนักงานขนส่ง</center>" HtmlEncode="False" />

              <asp:TemplateField HeaderText="<center>แก้ไข<br/>รายละเอียด</center>" ItemStyle-Width="80px"  ItemStyle-HorizontalAlign="Center">
                 <ItemTemplate>
                                     <asp:HyperLink ID="HyperData" NavigateUrl='<%# Bind("urldata") %>' Target="_blank" runat="server" ><i class="fa fa-edit" aria-hidden="true"></i></asp:HyperLink>
                 </ItemTemplate>
         </asp:TemplateField>

         <asp:TemplateField HeaderText="<center>reset password</center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperReset" NavigateUrl="#" runat="server" ><img src="../image/ResetPass.gif" ></asp:HyperLink>
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
    <p class="w3-left w3-padding "> ราย  </p>
</ContentTemplate>
  </asp:UpdatePanel>
   



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


    function ResetPass(Del_ID, username, type) {
        var Msg = 'คุณต้องการ Reset password ใช่หรือไม่?';
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            document.getElementById('MainContent_HidDel_ID').value = Del_ID;
            document.getElementById('MainContent_HidUsername').value = username;
            document.getElementById('MainContent_Hidptype').value = type;
            document.getElementById('MainContent_BtnResetPassword').click();
        } else {
            return false;
        }
    } 
</script>

<asp:Panel ID="PnDelete" style="DISPLAY: none" runat="server" >
        <asp:HiddenField id="HidDel_ID" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="HidType" runat="server"></asp:HiddenField>
        <asp:HiddenField id="HidActive" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="HidUsername" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="Hidptype" runat="server"></asp:HiddenField>
        <asp:Button style="DISPLAY: none" id="BtnDelete" onclick="BtnDelete_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> 
<%--        <asp:Button style="DISPLAY: none" id="BtnResetActive" onclick="BtnResetActive_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> --%>
        <asp:Button style="DISPLAY: none" id="BtnResetPassword" onclick="BtnResetPassword_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> 
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