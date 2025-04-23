<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="OtherCovntries.aspx.vb" Inherits="OtherCovntries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat=server>
<link rel="stylesheet" href="Footable/Icon/Styles/font-awesome.min.css" />
 <link rel="stylesheet" href="Footable/bootstrap.min.css" />
 <link rel="stylesheet" href="Footable/bootstrap-theme.min.css" />
 <link href="Footable/css/footable.bootstrap.min.css" rel="stylesheet" />
 <script src="Footable/jquery.min.js"></script>
 <script src="Footable/bootstrap.min.js"></script>
 <script src="Footable/footable.js"></script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
 <style>

@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
 
    
}
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
{ 
    
}
</style>
<div class="w3-container w3-text-purple w3-xxlarge w3-hide-medium w3-hide-small w3-margin w3-padding" style=" width:100%;">
<b> <center>Please contact licensed travel agency for permit application </center></b>
</div>
<div class="w3-container w3-text-purple w3-large w3-hide-large w3-margin w3-padding" style=" width:100%;">
<b> <center>Please contact licensed travel agency for permit application  </center></b>
</div>
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


<div class="w3-row w3-padding-small w3-margin"> 
            <div class="w3-col l1 mr4" style="margin-top: 5px;">
               <i class="fa fa-search" aria-hidden="true"></i> Search  :
            </div>

            <div class="w3-col l3 mr-5 pr-3">
            <asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="Agency name" oninput="document.getElementById('ContentPlaceHolder1_BtnSch').click();" runat="server"></asp:TextBox>
            </div>
            &nbsp;&nbsp;
            <div class="w3-col l3 mr-5 pr-3">
            <%--<asp:d ID="ddlprovince" class="w3-input w3-border w3-round-large"  placeholder="Agency name" onchange="document.getElementById('ContentPlaceHolder1_BtnSch').click();" runat="server"></asp:TextBox>--%>
             <asp:DropDownList id="ddlprovince"  class="w3-input w3-border w3-round-large" onchange="document.getElementById('ContentPlaceHolder1_BtnSch').click();"  runat="server" AppendDataBoundItems="True" ></asp:DropDownList>  
            </div>
          </div><br />

          <div class="w3-container w3-text-purple w3-xxlarge w3-hide-medium w3-hide-small w3-margin w3-padding" style=" width:100%;">
<b> List of Thai Travel Agencies Registered in FVP System </b>
</div>

<asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional" class="w3-card-2 w3-white w3-padding">
    <ContentTemplate>
      <%--<asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" CssClass="table-striped table-bordered footable">--%>
        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass="table table-striped table-bordered table-center table-hover " >
         <Columns>
             <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                         
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="num" HeaderText="<center>No.</center>" 
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center"/>

             <asp:BoundField DataField="name_company" HeaderText="<center>Agency Name</center>" 
                 HtmlEncode="False" />

             <asp:BoundField DataField="p_name_e" HeaderText="<center>Province</center>" HtmlEncode="False" />

             <asp:BoundField DataField="email" HeaderText="<center>E-mail</center>" HtmlEncode="False" />

             <asp:BoundField DataField="telephone" HeaderText="<center>Tel.</center>" HtmlEncode="False" />


               <asp:TemplateField HeaderText="<center>Facebook </center>" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="Hyperfacebook" NavigateUrl='<%# Bind("facebook") %>' Target="_blank" runat="server" ><img src="image/facebook.png"  width="50px"  height="50px"></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>
       
<%--
              <asp:TemplateField HeaderText="<center>แผนที่ </center>" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="Hyperplan" NavigateUrl="#" runat="server" ><img src="../image/icon2/earth-globe.png"  width="17px"  height="17px"></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>--%>
       
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
    <div class="w3-row-padding w3-white">
       <p class="w3-left w3-padding "> แสดงผลข้อมูล จำนวน  </p>
    <p class="w3-left "> <asp:DropDownList id="ddl_PageSize" runat="server" class="w3-input w3-border w3-round-large" Style="position: static"  AppendDataBoundItems="True" AutoPostBack="True"></asp:DropDownList>  </p>
    <p class="w3-left w3-padding "> ราย  </p>
  
</div>

</ContentTemplate>
  </asp:UpdatePanel>
  
   <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:ImageButton style="display:none" ID="BtnSch" runat="server"/>
    </ContentTemplate>
    </asp:UpdatePanel>
    <br />
  <center>
  <a href="RegisterTravel.aspx" class="w3-padding  w3-btn  w3-border w3-round-large w3-text-white w3-purple" style="width:25%; height:10%;font-size:1.7rem;"><img src="image/login-square.png">  Thai Travel Agency Registration</a>
   <a href="Login.aspx" class="w3-padding  w3-btn  w3-border w3-round-large w3-text-white w3-purple" style="width:25%; height:10%;font-size:1.7rem;"><img src="image/login-square.png">  Login As Thai Travel Agency</a>
   </center>
</asp:Content>


