<%@ Page Title="Foreign Vehicle Permit" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false"CodeFile="ManageApp.aspx.vb" Inherits="ManageApp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="Scripts/jquery-ui.js"></script>  
    <link href="Styles/progress-wizard.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>
    <%-- Footable --%>
     <link rel="stylesheet" href="Footable/Icon/Styles/font-awesome.min.css" />
    <link rel="stylesheet" href="Footable/bootstrap.min.css" />
    <link rel="stylesheet" href="Footable/bootstrap-theme.min.css" />
    <link href="Footable/css/footable.bootstrap.min.css" rel="stylesheet" />
   <script src="Footable/jquery.min.js"></script>
 <script src="Footable/bootstrap.min.js"></script>
 <script src="Footable/footable.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 
<%--<div class="row"  style="margin-top:3%;">--%>
            
            <div class="w3-row-padding" align=center  style="margin-top:3%;">
             <div class=" w3-text-purple">
             <div class=" w3-container">
                <p class=" w3-text-purple w3-hide-medium w3-hide-small" style="font-family: 'Kanit', sans-serif;font-size:1.5em;margin-left:0%"><b>Check Vehicle Status </b></p>
                <p class=" w3-text-purple w3-hide-large" style="font-family: 'Kanit', sans-serif;font-size:1em;margin-left:0%"><b>Check Vehicle Status </b></p>
                </div>
                </div>
              
            </div>
       <%-- </div> --%>
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
        <div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative w3-card-2 w3-theme-l5 w3-round-large" style="margin-top:18px;">
<div align="center">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
           </asp:ScriptManager>

<script type="text/javascript">


</script>

 <div class="w3-row" >

 <div class="w3-col" >
    <asp:Label ID="Label1" runat="server" Text="Registration No. (ENG) : " ForeColor="Black"></asp:Label>
    <asp:TextBox ID="txtlicense" CssClass="w3-round-large" runat="server"></asp:TextBox>
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="image/analytics.png" style="width:40px;height:40px; padding-top:auto"/>
</div>

</div>


<asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
<ContentTemplate>


 <div class="w3-container m-5">

                   <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="120%" EmptyDataText="ไม่มีข้อมูล" PageSize="10" EmptyDataRowStyle-HorizontalAlign="Center" CssClass=" table table-striped table-bordered table-lg table-center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <%--  <asp:Label id="lblLicense" runat="server" Text='<%# eval("license_id") %>'></asp:Label>
                                          <asp:Label id="lbltoken" runat="server" Text='<%# eval("token") %>'></asp:Label>--%>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
         <%-- <asp:BoundField DataField="number" HeaderText="No." 
                 HtmlEncode="False" />--%>

             <asp:BoundField DataField="plate" HeaderText="Registration No." HeaderStyle-CssClass="w3-center" HtmlEncode="False" ItemStyle-HorizontalAlign="Center"  />
             <asp:BoundField DataField="name_company" HeaderText="Travel Agency" HeaderStyle-CssClass="w3-center" HtmlEncode="False" ItemStyle-HorizontalAlign="Center"/>
             <asp:BoundField DataField="brands" HeaderText="Make" HtmlEncode="False" HeaderStyle-CssClass="w3-center" ItemStyle-HorizontalAlign="Center"/>

             <asp:BoundField DataField="model" HeaderText="Model" HtmlEncode="False" HeaderStyle-CssClass="w3-center"  ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="colors" HeaderText="Colors" HtmlEncode="False" HeaderStyle-CssClass="w3-center"  ItemStyle-HorizontalAlign="Center"  />

              <asp:BoundField DataField="start_date" HeaderText="Entry Date" HtmlEncode="False" HeaderStyle-CssClass="w3-center"  ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd-MMM-yyyy}"  />
             <asp:BoundField DataField="exp_date" HeaderText="Exit Date" HtmlEncode="False" HeaderStyle-CssClass="w3-center"  ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd-MMM-yyyy}" />

             
             <asp:BoundField DataField="country_car" HeaderText="Country" HtmlEncode="False" HeaderStyle-CssClass="w3-center" ItemStyle-HorizontalAlign="Center"  />
             <asp:BoundField DataField="status_en" HeaderText="Status" HtmlEncode="False" HeaderStyle-CssClass="w3-center" ItemStyle-HorizontalAlign="Center"  />
             
        <%--     <asp:TemplateField HeaderText="<center>เอกสารใบสมัคร </center>" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperDoc" NavigateUrl='<%# Bind("urltoken") %>' Target="_blank" runat="server" ><i class="fa fa-print fa-2x" aria-hidden="true"></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField> --%>
         </Columns>      
    </asp:GridView>


</div>
 <asp:HyperLink ID="HyperLink1"  NavigateUrl="~/ManageAppCommercial.aspx" CssClass=""  runat="server">Manage Application For Commercial Vehicle</asp:HyperLink>  
</ContentTemplate>

<Triggers><asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click"  />  </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <br /><br /><br />
</asp:Content>
