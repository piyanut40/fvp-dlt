<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageC.master" AutoEventWireup="false" CodeFile="Guide.aspx.vb" Inherits="Travel_Guide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 
 <%--    <link href="../Styles/datatables.min.css" rel="stylesheet">
<script type="text/javascript" src="../Scripts/datatables.min.js"></script>--%>
 <link rel="stylesheet" type="text/css" href="../Styles/css/w3-theme-deep-purple.css" />
   <link rel="stylesheet" href="../Styles/w3Home.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<style>
  body {
      overflow-x: unset;
   
      }
  @font-face{
      font-family: 'Kanit', sans-serif;
        src : url('font/ThaiSansNeue-Regular/thaisansneue-bold-webfont.woff2');
    
    
    }
.addbt
{
 margin-top: -20px;   
    
 }@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
.addbt{ margin-top:0px; }
    
}
 @media screen and (min-width: 360px) and (max-width:376px) and (orientation : portrait)
{
     
.addbt{ margin-top:0px; }
     
}
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
 {
 .addbt{ margin-top:0px; }
  }
    
  </style>
    <!--header class="w3-container" style="padding-top:22px">
    <h4 class="headtxt"><b>Active and Rejected Application</b></h4>
</header-->
<header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
<a   style="margin-left:0%"><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">Tour leader or assistant</b></a><br /><br/>
</header>
<%--<style>
td{
    text-align : center;
}
</style>--%>

  <div class="w3-row w3-padding-small"> 
  <%--<div class="row no-gutters align-items-center py-2 ">--%>
            <div class="w3-col l1 <% Response.Write(Css)%>">
               <i class="fa fa-search" aria-hidden="true"></i> Filter :
                  <%--<input class="admin--search" type="text" name="search" placeholder="ค้าหาผู้ประกอบการ" value="">--%>
                  <%--<asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="ชื่อผู้ใช้รถ" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>--%>
            
            </div>

            <div class="w3-col l2">
             
            <asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="Tour leader name" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
            </div>

            <div class="w3-col l9 w3-right-align addbt">
            <%--<asp:Button class="w3-button w3-purple w3-padding w3-round" ID="Button1" runat="server" PostBackUrl="CarAdd.aspx" Text="ขออนุญาตรายการรถท่องเที่ยว"></asp:Button>--%>
             <%--<asp:LinkButton ID="lnkAdd" class="w3-button w3-purple w3-padding w3-round" runat="server" ><i class="fa fa-plus" aria-hidden="true" ></i>  ขออนุญาตรายการรถท่องเที่ยว</asp:LinkButton>--%>
             <asp:LinkButton ID="lnkAdd" class="w3-button w3-purple2 w3-padding w3-round w3-margin" runat="server" text="<i class='fa fa-plus' aria-hidden='true' ></i> Tour leader or assistant" ></asp:LinkButton>
            </div>
          </div>


    <script  type='text/javascript'>

        jQuery(function ($) {

            $(document).ready(function () {

                $('#<%= gvMain.ClientID %>').footable({
                    "paging": {
                        "enabled": false
                    },
                  
                });

                var prm = Sys.WebForms.PageRequestManager.getInstance();

                prm.add_endRequest(function () {
                    $('#<%= gvMain.ClientID %>').footable({
                        "paging": {
                            "enabled": false
                        },
                     
                    });
                });

            });
        }); 

</script>




<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="No data" 
            EmptyDataRowStyle-HorizontalAlign="Center"  
            CssClass="table table-striped table-bordered table-center table-hover " >
        <%--<asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" PagerSettings-PageButtonCount="5"  
PagerSettings-Mode="NumericFirstLast"  PagerStyle-HorizontalAlign="Center"  Width="100%" EmptyDataText="ไม่มีข้อมูล" CssClass="table table-striped table-bordered table-lg table-center" >--%>
         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                          <asp:Label id="lblguide_id" runat="server" Text='<%# eval("guide_id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" HeaderText="<center>No.</center>" 
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center" >

             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

             <%--<asp:BoundField DataField="register_no" HeaderText="เลขที่ใบสมัคร" 
                 HtmlEncode="False" />--%>

             <asp:BoundField DataField="guide_name" HeaderText="<center>Tour Leader or Assistant Name</center>" HtmlEncode="False"  />

             <asp:BoundField DataField="guide_email" HeaderText="<center>Email</center>" HtmlEncode="False"   />

               <asp:BoundField DataField="guide_tel" HeaderText="<center>Telephone</center>" HtmlEncode="False"    />

             
           <asp:BoundField DataField="guide_idcard" HeaderText="<center>IDcard No.</center>" HtmlEncode="False" ItemStyle-HorizontalAlign="Center"  />

             <asp:TemplateField HeaderText="<center>Edit </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperEdit" NavigateUrl='<%# Bind("urlEdit") %>' Target="_self" runat="server" ToolTip="Edit Data" ><i class="fa fa-edit " ></i></asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
             </asp:TemplateField>

            

              <asp:TemplateField HeaderText="<center>Delete </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLinkDel" NavigateUrl="#" runat="server" ><img src="../image/g_delete.gif" ></asp:HyperLink>
              
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>
         </Columns>
          <EmptyDataRowStyle HorizontalAlign="Center" />
          <PagerTemplate>
          <div class="w3-row w3-padding-small"> 
                      
            <div class="col ">
             <div  class="w3-right"> 

               <asp:LinkButton ID="btnLast" runat="server" CommandArgument="Last" CommandName="Page"  class="w3-right btn w3-button w3-padding-small w3-round w3-large" >Last</asp:LinkButton>
              <asp:LinkButton ID="btnNext" runat="server" CommandArgument="Next" CommandName="Page" class="w3-right btn w3-button w3-padding-small w3-round w3-large" >Next</asp:LinkButton> 
  
             
             <%-- <a href="#" class="btn disabled">--%>
                <asp:LinkButton ID="btnPrev" class="w3-right btn w3-button w3-padding-small w3-round w3-large" runat="server" CommandArgument="Prev" CommandName="Page" >Prev</asp:LinkButton>
             <%-- </a>--%>

              <%--<a href="#" class="btn disabled">--%>
               <asp:LinkButton ID="btnFirst" class="w3-right btn w3-button w3-padding-small w3-round w3-large" runat="server" CommandArgument="First" CommandName="Page" >First </asp:LinkButton>
              <%--</a>--%>
            </div> 
               

               <div class="w3-left"> 
              <p class="w3-left w3-padding-small"> Page   
             </p>

            <p class="w3-left"><asp:DropDownList ID="DDLPage" runat="server" class="w3-input w3-border w3-round-large"  AutoPostBack="true"  OnSelectedIndexChanged="DDLPage_SelectedIndexChanged" Style="position: static" >
                
                </asp:DropDownList>  
             </p>
             </div> 
            </div>
          </div>
        </PagerTemplate>   
    </asp:GridView>
     <p class="w3-left w3-padding "> Display  </p>
    <p class="w3-left "> <asp:DropDownList id="ddl_PageSize" runat="server" class="w3-input w3-border w3-round-large" Style="position: static"  AppendDataBoundItems="True" AutoPostBack="True"></asp:DropDownList>  </p>
    <p class="w3-left w3-padding "> Rows  </p>
</ContentTemplate>
  </asp:UpdatePanel>

  <asp:Panel ID="PnDelete" style="DISPLAY: none" runat="server" >
        <asp:HiddenField id="HidLicense" runat="server"></asp:HiddenField> 
        <asp:Button style="DISPLAY: none" id="BtnDelete" runat="server" UseSubmitBehavior="false" ></asp:Button> 
        <asp:Button style="DISPLAY: none" id="BtnResetActive" runat="server" UseSubmitBehavior="false" ></asp:Button> 
        <asp:HiddenField id="HidDel_ID" runat="server"></asp:HiddenField> 
   <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:ImageButton ID="BtnSch" runat="server"/>
    </ContentTemplate>
    </asp:UpdatePanel>
       
</asp:Panel>

<script type='text/javascript'>

    function DelData(license_id) {
        var Msg = 'Do you want delete data ?';
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

