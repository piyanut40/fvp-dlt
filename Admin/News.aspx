<%@ Page Language="VB" AutoEventWireup="false" CodeFile="News.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="News" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<style>
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
 <header class="w3-container" style="margin-top: 10px;margin-bottom: 15px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">จัดการข่าวประชาสัมพันธ์</b></a>
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

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="w3-row w3-padding-small"> 
            <div class="w3-col l2 <% Response.Write(Css)%>">
               <i class="fa fa-search" aria-hidden="true"></i> กรองการค้นหา :
            </div>

            <div class="w3-col l2">
            <asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="หัวข้อข่าว" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
            </div>

             <div class="w3-col l8 w3-right-align">

             <asp:LinkButton ID="lnkAdd" class="w3-button w3-purple2 w3-padding w3-round adduser" runat="server"><i class="fa fa-plus" aria-hidden="true" ></i>  เพิ่มข่าวประชาสัมพันธ์</asp:LinkButton>
            </div>
          </div><br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

      <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass="table table-striped table-bordered table-center table-hover " >
    <Columns>
    <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="lblnews_id" runat="server" Text='<%# eval("news_id")%>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
         <asp:BoundField DataField="num" HeaderText="<center>No.</center>" ItemStyle-HorizontalAlign="Center"  HtmlEncode="False" ItemStyle-Width="60px"  />
         <asp:BoundField DataField="title" HeaderText="<center>หัวข้อข่าว</center>"  HtmlEncode="False"/>
         <asp:BoundField DataField="date_news" HeaderText="<center>วันที่ลงข่าว</center>" ItemStyle-HorizontalAlign="Center"  HtmlEncode="False" DataFormatString="{0:d MMM yyyy}" ItemStyle-Width="100"/>
         <asp:TemplateField HeaderText="<center>จัดการข่าว </center>"  ItemStyle-HorizontalAlign="Center">
                 <ItemTemplate>
                                     <asp:HyperLink ID="HyperDoc" NavigateUrl='<%# Bind("urledit") %>' Target="_blank" runat="server" ><i class="fa fa-pencil-square-o " aria-hidden="true"></i></asp:HyperLink>
                 </ItemTemplate>
         </asp:TemplateField>
          <asp:TemplateField HeaderText="<center>ลบข่าว</center>" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" >
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
     <asp:Button style="DISPLAY: none" id="BtnDelete" runat="server" UseSubmitBehavior="false" ></asp:Button> 
     <asp:HiddenField id="HidDel_ID" runat="server"></asp:HiddenField> 
  <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:ImageButton ID="BtnSch" runat="server" style="display:none"/>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>




    

    <script type="text/javascript">
    
     function DelData(license_id) {
        var Msg = 'ต้องการลบข้อมูล ?';
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            document.getElementById('MainContent_HidDel_ID').value = license_id;
            document.getElementById('MainContent_BtnDelete').click();
        } else {
            return false;
        }
    }
    
    
    
    </script>
</asp:Content>