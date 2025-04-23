<%@ Page Title="Foreign Vehicle Permit" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false"CodeFile="ManageAppCommercial.aspx.vb" Inherits="ManageAppCommercial" %>


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
    <script src="Footable/bootstrap.min.js"></script>
    <script src="Footable/footable.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="row"  style="margin-top:18px;">
            <div class="col-md-3"></div>
            <div class="col-md-6" align=center>
             <div class=" w3-text-purple">
             <div class=" w3-container p-2">
                <h1 style="font-family: 'Kanit', sans-serif;">Search Commercial Vehicle</h1>
                </div>
                </div>
                <hr>
            </div>
        </div>

<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative w3-card-2 w3-light-gray w3-round-large" style="margin-top:18px;">
 
<div align="center">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
           </asp:ScriptManager>

<script type="text/javascript">


    $(function () {


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


</script>
 <div class=" w3-row m-4 p-4 w3-center " >

 <div class=" w3-third w3-container mb-5">
    <asp:Label ID="Label1" runat="server" Text="VIN Number1: " ForeColor="Black"></asp:Label>
    <asp:TextBox ID="txtVinNo" CssClass="w3-round-large" runat="server"></asp:TextBox>
</div>
 <div class=" w3-third w3-container mb-5">
    <asp:Label ID="Label2" runat="server" Text="VIN Number2: " ForeColor="Black"></asp:Label>
    <asp:TextBox ID="txtVin2" CssClass="w3-round-large" runat="server"></asp:TextBox>
</div>
    <div class="w3-third w3-container mb-5"> 
       <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="image/analytics.png"  Width="50" Height="50" />
       </div>
</div>
    <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>


 <div class="m-5">

                   <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" PageSize="10" CssClass="table table-striped table-bordered table-lg table-center" style="color:black">
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

             <asp:BoundField DataField="brand" HeaderText="ยื่ห้อรถ" HtmlEncode="False" />
             <asp:BoundField DataField="registration_no" HeaderText="ป้ายทะเบียนรถ" HtmlEncode="False" />
             <asp:BoundField DataField="model" HeaderText="โมเดลรถ" HtmlEncode="False" />
             <asp:BoundField DataField="colour" HeaderText="สีรถ" HtmlEncode="False" />
             <asp:BoundField DataField="engine_no" HeaderText="หมายเลขเครื่อง" HtmlEncode="False" />
             <asp:BoundField DataField="vin_no" HeaderText="หมายเลขรถ" HtmlEncode="False" />

               <asp:TemplateField HeaderText="<center>เอกสารใบสมัคร </center>" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperDoc" NavigateUrl='<%# Bind("urltoken") %>' Target="_blank" runat="server" ><i class="fa fa-print fa-2x" aria-hidden="true"></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>เครื่องหมาย </center>" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperDoc2" NavigateUrl='<%# Bind("urlsign") %>' Target="_blank" runat="server" ><i class="fa fa-print fa-2x" aria-hidden="true"></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

         </Columns>      
    </asp:GridView>

        </div>  

</div>
</ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </div>
</asp:Content>
