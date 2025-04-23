<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" MasterPageFile="~/MasterPageC.master" Inherits="Travel_index" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" Runat="Server">
<%--    <link href="../Styles/datatables.min.css" rel="stylesheet">
<script type="text/javascript" src="../Scripts/datatables.min.js"></script>--%>
 <link rel="stylesheet" type="text/css" href="../Styles/css/w3-theme-deep-purple.css" />
   <link rel="stylesheet" href="../Styles/w3Home.css"/>
     <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<style>
  body {
      overflow-x: unset;
   
      }
  @font-face{
      font-family: 'Kanit', sans-serif;
        src : url('font/ThaiSansNeue-Regular/thaisansneue-bold-webfont.woff2');
}
.topic
{
  font-size:1.5em;
  margin-left:0%;
  font-family: 'Kanit', sans-serif;
  margin-top: 10px;
 
  
}.hd{padding: 0.01em 16px;}

@media screen and (min-width: 1025px) and (max-width:1449px)
{
  .topic
{
  font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;
}  
}
@media screen and (min-width: 980px) and (max-width:1024px)
{
.topic
{
  font-size:1 em;margin-left:0%;font-family: 'Kanit', sans-serif;
} .w3-col.l1 {
    width: 15%;
} 
    
}
@media screen and (min-width: 480px) and (max-width:767px) and (orientation : portrait)
{
   
    .topic
{
  
  font-size:1em;margin-left:0%;font-family: 'Kanit', sans-serif;

    }
 }
 
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
.topic
{
   font-size:1em;margin-left:0%;font-family: 'Kanit', sans-serif;

 }.hd{padding: 0em 0px;}
    
}
 @media screen and (min-width: 360px) and (max-width:376px) and (orientation : portrait)
{
     
.topic
{
   font-size:1em;margin-left:0%;font-family: 'Kanit', sans-serif;

    }.hd{padding: 0em 0px;}
     
}
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
 {
     .topic
{
  font-size:1em;margin-left:0%;font-family: 'Kanit', sans-serif;
    

    }.hd{padding: 0em 0px;}
  
  }
    
  </style>
    <!--header class="w3-container" style="padding-top:22px">
    <h4 class="headtxt"><b>Active and Rejected Application</b></h4>
</header-->

<header class="w3-container" style="margin-top: 10px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">Active and Rejected Application</b></a><br /><br/>
</header>
<%--<style>
td{
    text-align : center;
}
</style>--%>


          <div class="w3-row w3-padding-small w3-container" style="margin-left:-2%">
   <div class="w3-col l05 <% Response.Write(Css)%>">
                <%--<i class="fa fa-search" aria-hidden="true"></i> Filter  --%>
                 
            </div>
            <div class="w3-col l07 w3-padding-top  <% Response.Write(Css)%>" >
                Year added :
            </div>
            <div class="w3-col l2 w3-padding-small">
                 <asp:DropDownList ID="ddlYear" class="w3-input w3-border w3-round-large" runat="server" Width="100px" AutoPostBack="true" AppendDataBoundItems="true" >
                 <asp:ListItem Value="all" Text="All year"></asp:ListItem>
                 </asp:DropDownList>
            </div>
            
            <div class="w3-col l07 w3-padding-top <% Response.Write(Css)%>" >
                Date of entry :
            </div>
            <%--<div class="w3-col l05 w3-padding-top align="right">
                date :
            </div>--%>
             <div class="w3-col l1 <%--mr-5--%> w3-padding-small">
              <asp:TextBox ID="txtstartdate" class="w3-input w3-border w3-round-large" autocomplete="off" placeholder="Entry Date" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>

              <div class="w3-col l1 <%--mr-5--%> w3-padding-small">
              <asp:TextBox ID="txtexpdate" class="w3-input w3-border w3-round-large" autocomplete="off" placeholder="Exit Date" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>
              <div class="w3-col l1_1 w3-padding-top  <% Response.Write(Css)%>" >
                status :
            </div>
            <div class="w3-col l1 <%--mr-5 --%> w3-padding-small">
            <asp:DropDownList ID="ddlstatus" class="w3-input w3-border w3-round-large" Width="140px" runat="server" AutoPostBack="true" AppendDataBoundItems="true" >
                 <asp:ListItem Value="all" Text="All status"></asp:ListItem>
                 <asp:ListItem Value="-" Text="Draft"></asp:ListItem>
                 <asp:ListItem Value="0" Text="Pending"></asp:ListItem>
                 <asp:ListItem Value="2" Text="Incomplete"></asp:ListItem>
                 </asp:DropDownList>
            </div>
    </div>

    <div class="w3-row w3-padding-small w3-container" style="margin-left:-2%"> 
  <%--<div class="row no-gutters align-items-center py-2 ">--%>
            <div class="w3-col l05 <% Response.Write(Css)%>">
 
            </div>
            <div class="w3-col l07 w3-padding-top  <% Response.Write(Css)%>" >
                Driver Name :
            </div>
            <div class="w3-col l2 <%--mr-5 --%> w3-padding-small">
                <asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="Driver Name" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
            </div>
            <div class="w3-col l07 w3-padding-top  <% Response.Write(Css)%>" >
                Group Name :
            </div>
             <div class="w3-col l2 <%--mr-5--%> w3-padding-small">
              <asp:TextBox ID="txtGroup" class="w3-input w3-border w3-round-large"  placeholder="Group Name" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>
              <div class="w3-col l1_1 w3-padding-top  <% Response.Write(Css)%>" >
                Tour Leader Name :
            </div>
            <div class="w3-col l2 <%--mr-5--%> w3-padding-small">
              <asp:TextBox ID="txtGuide" class="w3-input w3-border w3-round-large"  placeholder="Tour Leader Name" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>
              
            
            
               

              
                <div class="w3-col l2 <%--mr-5--%> w3-right-align w3-padding-small">
          <asp:LinkButton ID="lnkAdd" class="w3-button w3-purple2 w3-padding w3-round " Stylr="margin-top:-15px" runat="server" text="<i class='fa fa-plus' aria-hidden='true' ></i> Apply for a Permit" ></asp:LinkButton>
          </div>
          </div>
           <br>

             <div class="w3-col w3-right-align" style="margin-top: -20px;">

            
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




<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="No data" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass="table table-striped table-bordered table-center table-hover " >

         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                          <asp:Label id="lblLicense" runat="server" Text='<%# eval("license_id") %>'></asp:Label>
                                          <asp:Label id="lbltoken" runat="server" Text='<%# eval("token") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" HeaderText="<center>No.</center>" ItemStyle-Width="60px"
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center" />

     
                
             <asp:BoundField DataField="name" HeaderText="<center>Name</center>" HtmlEncode="False"/>

             <asp:BoundField DataField="brands" HeaderText="<center>Make</center>" HtmlEncode="False" />

             <asp:BoundField DataField="models" HeaderText="<center>Model</center>" HtmlEncode="False" />

             <asp:BoundField DataField="typecar_en" HeaderText="<center>Type</center>" HtmlEncode="False" ItemStyle-Width="110px" />

              <asp:BoundField DataField="plate" HeaderText="<center>Plate</center>" HtmlEncode="False" />

              <%--<asp:BoundField DataField="car_no" HeaderText="<center>VIN</center>" HtmlEncode="False" />--%>

              <asp:BoundField DataField="group_name" HeaderText="<center>Group</center>" HtmlEncode="False" />

             <asp:BoundField DataField="start_date" HeaderText="<center>Entry date</center>" HtmlEncode="False" ItemStyle-Width="80px" />

             <asp:BoundField DataField="exp_date" HeaderText="<center>Exite date</center>" HtmlEncode="False" ItemStyle-Width="80px" />

             <asp:BoundField DataField="guide" HeaderText="<center>Tour Leader <br>or Assistant</center>" HtmlEncode="False" />

             <asp:BoundField DataField="status_en" HeaderText="<center>Status</center>" HtmlEncode="False" ItemStyle-Width="140px" />

             <asp:BoundField DataField="regis_date" HeaderText="<center>Added Date</center>" HtmlEncode="False" ItemStyle-Width="80px" /> 
             
             <asp:TemplateField HeaderText="<center>Application </center>" ItemStyle-Width="80px" Visible="false" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                      <asp:HyperLink ID="HyperPDF" NavigateUrl='<%# Bind("urlPDF") %>' Target="_parent" runat="server" ><i class="fa fa-file-pdf-o " aria-hidden="true"></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="<center>View </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperDoc" NavigateUrl='<%# Bind("urlDoc") %>' Target="_parent" runat="server" ToolTip="View Data" ><i class="fa fa-file " ></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="<center>Edit </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperEdit" NavigateUrl='<%# Bind("urlEdit") %>' Target="_parent" runat="server" ToolTip="Edit Data" ><i class="fa fa-edit " ></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="<center>Approve </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" Visible="false">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperActive" NavigateUrl="#" runat="server" ><img src="../image/icon2/checked.png" width="20px" height="20px"></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>Delete </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" >
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