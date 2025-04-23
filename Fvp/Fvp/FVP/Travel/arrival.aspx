<%@ Page Language="VB" AutoEventWireup="false" CodeFile="arrival.aspx.vb" MasterPageFile="~/MasterPageC.master" Inherits="Travel_arrival" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" Runat="Server">
 <%--<link href="../Styles/datatables.min.css" rel="stylesheet">
    <script type="text/javascript" src="../Scripts/datatables.min.js"></script>--%>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

<header class="w3-container" style="margin-top: 10px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;"><% Response.Write(text)%></b></a><br /><br/>
</header>


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
  <div class="w3-row w3-padding-small  w3-container"  style="margin-left:-2%"> 
             <div class="w3-col l1  w3-padding-small <% Response.Write(Css)%>">
                <i class="fa fa-search" aria-hidden="true"></i>  Filter :
      
                
            </div>

             <div class="w3-col l2  w3-padding-small ">
            <asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="Driver name" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
            </div>

            
             <div class="w3-col l2  w3-padding-small ">
              <asp:TextBox ID="txtGroup" class="w3-input w3-border w3-round-large"  placeholder="Leader name" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>

              <div class="w3-col l2  w3-padding-small ">
              <asp:TextBox ID="txtplate" class="w3-input w3-border w3-round-large"  placeholder="Registration No." oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>

                <div class="w3-col l2 w3-padding-small">
              <asp:TextBox ID="txtstartdate" class="w3-input w3-border w3-round-large" autocomplete="off"   placeholder="Start date" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>

              
               <div class="w3-col l2 w3-padding-small">
              <asp:TextBox ID="txtexpdate" class="w3-input w3-border w3-round-large" autocomplete="off"  placeholder="Exp date" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>

          </div><br />


<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="No Data"  EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass="table table-striped table-bordered table-center table-hover " >
         <Columns>
             <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                          <asp:Label id="lblLicense" runat="server" Text='<%# eval("license_id") %>'></asp:Label>
                                          <asp:Label id="lbltoken" runat="server" Text='<%# eval("token") %>'></asp:Label>
                                           <asp:Label id="lbltypeuser_id" runat="server" Text='<%# eval("typeuser_id") %>'></asp:Label>
                                           <asp:Label id="lblstatus_id" runat="server" Text='<%# eval("status_id") %>'></asp:Label>
                                           <asp:Label id="lbllicense_no" runat="server" Text='<%# eval("license_no") %>'></asp:Label>
                                           
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" ItemStyle-Width="60px" HeaderText="<center>No.</center>" 
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center"/>

             <asp:BoundField DataField="license_no" HeaderText="<center>Permit No.</center>" 
                 HtmlEncode="False" />

             <asp:BoundField DataField="name" HeaderText="<center>Name</center>" HtmlEncode="False" />

             <asp:BoundField DataField="brands" HeaderText="<center>Make</center>" HtmlEncode="False" />

               <asp:BoundField DataField="plate" HeaderText="<center>Registration No.</center>" HtmlEncode="False" />

             <asp:BoundField DataField="typecar_en" HeaderText="<center>Type</center>" HtmlEncode="False" />

             <asp:BoundField DataField="group_name" HeaderText="<center>Group</center>" HtmlEncode="False" />

             <asp:BoundField DataField="guide" HeaderText="<center>Tour Leader or Assistant</center>" HtmlEncode="False" />

             <asp:BoundField DataField="start_date" HeaderText="<center>Entry date</center>" HtmlEncode="False" />

              <asp:BoundField DataField="exp_date" HeaderText="<center>Exit date</center>" HtmlEncode="False" />

             <asp:BoundField DataField="status_th" HeaderText="<center>Status</center>" HtmlEncode="False" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="left"/>

              <asp:TemplateField HeaderText="<center>Map </center>" Visible="false" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="Hyperplan" NavigateUrl="#" runat="server" ><img src="../image/icon2/earth-globe.png" width="17px"  height="17px"></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>
             
             <asp:TemplateField HeaderText="<center>View </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperDoc" NavigateUrl='<%# Bind("urlDoc") %>' Target="_parent" runat="server" ><i class="fa fa-file " aria-hidden="true"></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>



             <asp:TemplateField HeaderText="<center>Application</center>" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperPDF" NavigateUrl='<%# Bind("urlPDF") %>' Target="_blank" runat="server" ><i class="fa fa-file-pdf-o " aria-hidden="true"></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>Permit </center>" Visible="false" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperSign" NavigateUrl='<%# Bind("urlSign") %>' Target="_parent" runat="server" ><asp:Image ID="Image1" runat="server" ImageUrl="../image/icon_sign.png"  height="17px"/></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

              <asp:TemplateField  HeaderText="<center>Cancel Permit </center>"  ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLinkDel" NavigateUrl="#" runat="server" ><img src="../image/g_delete.gif" ></asp:HyperLink>
                                    </ItemTemplate>     
              </asp:TemplateField>
         </Columns>
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
        <asp:Button style="DISPLAY: none" id="BtnDelete" onclick="BtnDelete_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> 
        <asp:Button style="DISPLAY: none" id="BtnResetActive" onclick="BtnResetActive_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> 

   <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:ImageButton ID="BtnSch" runat="server"/>
    </ContentTemplate>
    </asp:UpdatePanel>
       
</asp:Panel>



<script type="text/javascript">

    function DelUser(license_id) {
        var Msg = 'Do you want Cancel Permit ?';
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
        var Msg = 'อนุมัติ ใบอนุญาติ ?';
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