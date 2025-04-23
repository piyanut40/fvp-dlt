<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageC.master" AutoEventWireup="false" CodeFile="Group.aspx.vb" Inherits="Travel_Group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 
 <%--    <link href="../Styles/datatables.min.css" rel="stylesheet">
<script type="text/javascript" src="../Scripts/datatables.min.js"></script>--%>
 <link rel="stylesheet" type="text/css" href="../Styles/css/w3-theme-deep-purple.css" />
   <link rel="stylesheet" href="../Styles/w3Home.css"/>
   <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
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
    
  </style>


<script type="text/javascript">

    $(function () {
        $("#<%=txtstartdate.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            setDate: new Date(),
            showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtstartdate.ClientID %>").keyup(function () {
            $("#<%=txtstartdate.ClientID %>").val('');
        })
    });

    $(function () {
        $("#<%=txtexpdate.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            setDate: new Date(),
            showButtonPanel: true
            , dateFormat: 'dd/mm/yy'
        });
        $("#<%=txtexpdate.ClientID %>").keyup(function () {
            $("#<%=txtexpdate.ClientID %>").val('');
        })
    });


</script>

<header class="w3-container" style="margin-top: 10px;/*margin-bottom: 10px;*/">
<a   style="margin-left:0%"><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">Tour Group <asp:Label ID="lblStatusHead" runat="server" Text=""></asp:Label></b></a><br /><br/>
</header>
<%--<style>
td{
    text-align : center;
}
</style>--%>

  <div class="w3-row w3-padding-small  w3-container"  style="margin-left:-2%"> 

            <div class="w3-col l1 w3-padding-small  <% Response.Write(Css)%>">
               <i class="fa fa-search" aria-hidden="true"></i> Filter :
                        
            </div>
            <div class="w3-col l1 w3-padding-small">
                 <asp:DropDownList ID="ddlYear" class="w3-input w3-border w3-round-large" runat="server" AutoPostBack="true" AppendDataBoundItems="true" >
                 <asp:ListItem Value="all" Text="All year"></asp:ListItem>
                 </asp:DropDownList>
            </div>
            <div class="w3-col l2 w3-padding-small">
             
            <asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="Group Name" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
            </div>

              <div class="w3-col l2 w3-padding-small">
              <asp:TextBox ID="txtGuide" class="w3-input w3-border w3-round-large"  placeholder="Tour Leader Name" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>

               <div class="w3-col l1_2 w3-padding-small">
              <asp:TextBox ID="txtstartdate" class="w3-input w3-border w3-round-large"  autocomplete="off" placeholder="Start Date" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>

              
               <div class="w3-col l1_2 w3-padding-small">
              <asp:TextBox ID="txtexpdate" class="w3-input w3-border w3-round-large"  autocomplete="off" placeholder="End Date" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>

              
            <div class="w3-col l2 w3-padding-small w3-right-align" Style="margin-top:-15px">

             <asp:LinkButton ID="lnkAdd" class="w3-button w3-purple2 w3-padding w3-round w3-margin" runat="server" text="<i class='fa fa-plus' aria-hidden='true' ></i> Add Tour Group" ></asp:LinkButton>
            </div>
          </div><%--<br>--%>


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

         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                          <asp:Label id="lblgroup_id" runat="server" Text='<%# eval("group_id") %>'></asp:Label>
                                           <asp:Label id="lblurlAdds" runat="server" Text='<%# eval("urlAdds") %>'></asp:Label>
                                           <asp:Label id="lblold_group_id" runat="server" Text='<%# eval("old_group_id") %>'></asp:Label>
                                           <asp:Label id="lblActive" runat="server" Text='<%# eval("active") %>'></asp:Label>
                                           <asp:Label id="lblActiveno" runat="server" Text='<%# eval("activeno") %>'></asp:Label>
                                         <asp:Label id="lblActiveedit" runat="server" Text='<%# eval("activeedit") %>'></asp:Label>
                                         <asp:Label id="lblstart_date2" runat="server" Text='<%# eval("start_date") %>'></asp:Label>
                                          <asp:Label id="lblexp_date2" runat="server" Text='<%# eval("exp_date") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" HeaderText="<center>No.</center>" ItemStyle-Width="70px"
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center" >

             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>


             <asp:BoundField DataField="license_group" HeaderText="<center>Group License</center>" HtmlEncode="False"/>

             <asp:BoundField DataField="group_name" ItemStyle-Width="150px" HeaderText="<center>Group Name</center>" HtmlEncode="False"/>

             <asp:BoundField DataField="border_nameen" HeaderText="<center>Border Crossing Checkin</center>" HtmlEncode="False"/>

             <asp:BoundField DataField="start_date" HeaderText="<center>Start date</center>"  HtmlEncode="False" DataFormatString="{0: dd MMM yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" />

                 <asp:BoundField DataField="border_nameen2" HeaderText="<center>Border Crossing Checkout</center>" HtmlEncode="False"/>

             <asp:BoundField DataField="exp_date" HeaderText="<center>End date</center>" HtmlEncode="False" DataFormatString="{0: dd MMM yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" />

             <asp:BoundField DataField="cntpeople" HeaderText="<center>Number of Car</center>" HtmlEncode="False" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px" />

               <asp:BoundField DataField="cntguide" HeaderText="<center>Number of Tour Leader</center>" HtmlEncode="False" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px" />

                <asp:BoundField DataField="guide" HeaderText="<center>Tour Leader or Assistant</center>" HtmlEncode="False" ItemStyle-Width="150px" />

               <asp:TemplateField HeaderText="<center>View </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperDoc" NavigateUrl='<%# Bind("urlData") %>' Target="_parent" runat="server" ><i class="fa fa-file " aria-hidden="true"></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="<center>Edit </center>" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperEdit" NavigateUrl='<%# Bind("urlEdit") %>' Target="_self" runat="server" ToolTip="Edit Data" ><i class="fa fa-edit " ></i></asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
             </asp:TemplateField>

            

              
              <asp:TemplateField HeaderText="<center>Extension </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         <asp:Label id="lblis_renew" runat="server" Text='<%# eval("is_renew") %>'></asp:Label>
                                         <asp:HyperLink ID="HyperLinkAdds" NavigateUrl='<%# Bind("urlAdds") %>' runat="server" ><img src="../image/Button-Add-icon.png" ></asp:HyperLink>
              
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
              </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>Delete </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLinkDel" NavigateUrl="#" runat="server" ><img src="../image/g_delete.gif" ></asp:HyperLink>
              
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
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

