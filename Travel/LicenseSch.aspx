<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPagePopup.master" AutoEventWireup="false" CodeFile="LicenseSch.aspx.vb" Inherits="Travel_LicenseSch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div class="container col-12  position-relative w3-padding w3-white w3-padding-top32"  >

<header class="w3-container" style="margin-top: 10px;margin-bottom: 10px;">
           <a class=" w3-text-purple" style="margin-left:0%"><b style="font-size:1.7em;margin-left:0%;font-family: 'Kanit', sans-serif;"><i class="fa fa-pencil-square" aria-hidden="true"></i>  Find Existing Vehicle</b></a><br /> 
    </header>

<div class="w3-row w3-padding-small w3-container" style="margin-left:-2%">

<div class="w3-col l1_2 w3-padding-top <% Response.Write(Css)%>" >
                Plate :
            </div>
            <div class="w3-col l2 w3-padding-small">
              <asp:TextBox ID="txtPlate" class="w3-input w3-border w3-round-large" autocomplete="off" placeholder="Plate" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>
            <div class="w3-col l2 w3-padding-top <% Response.Write(Css)%>" >
                Country :
            </div>
            <div class="w3-col l2 w3-padding-small">
              <asp:TextBox ID="txtCountry" class="w3-input w3-border w3-round-large" autocomplete="off" placeholder="Country" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>
   
            
            
    </div>

    <div class="w3-row w3-padding-small w3-container" style="margin-left:-2%">
    <div class="w3-col l1_2 w3-padding-top <% Response.Write(Css)%>" >
                 
            </div>
    <div class="w3-col l2 w3-padding-top  w3-padding-small" >
                <asp:CheckBox ID="Check60" Enabled="false" Checked="true" runat="server" /> Not more than 60 days 
            </div>
            <div class="w3-col l2 w3-padding-top  <% Response.Write(Css)%>" >
                <asp:CheckBox ID="CheckInsurance" Checked="true" runat="server" /> Date of insurance :
            </div>
            <div class="w3-col l1_2 <%--mr-5--%> w3-padding-small">
              <asp:TextBox ID="txtStart" class="w3-input w3-border w3-round-large" autocomplete="off" placeholder="Entry Date" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>

              <div class="w3-col l1_2 <%--mr-5--%> w3-padding-small">
              <asp:TextBox ID="txtExpire" class="w3-input w3-border w3-round-large" autocomplete="off" placeholder="Exit Date" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>
              </div>
                
    <div class="w3-col l2 <%--mr-5--%> w3-right-align w3-padding-small">
          <asp:LinkButton ID="lnkSearch" class="w3-button w3-purple2 w3-padding w3-round " Stylr="margin-top:-15px" runat="server" text="<i class='fa fa-search' aria-hidden='true' ></i> Search" ></asp:LinkButton>
          </div>
    </div>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="No data" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass="table table-striped table-bordered table-center table-hover " >
        
         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                          <asp:Label id="lblLicense" runat="server" Text='<%# eval("value") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <%--<asp:BoundField DataField="number" HeaderText="<center>No.</center>" ItemStyle-Width="60px"
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center" />--%>

             
                
             <asp:BoundField DataField="text" HeaderText="<center>text</center>" HtmlEncode="False" Visible="false" />

             <asp:BoundField DataField="value" HeaderText="<center>value</center>" HtmlEncode="False" Visible="false" />

             <asp:BoundField DataField="plate" HeaderText="<center>Plate</center>" HtmlEncode="False" />

                <asp:BoundField DataField="country_car" HeaderText="<center>Country of <br>registration</center>" HtmlEncode="False" />

                <asp:BoundField DataField="type_name" HeaderText="<center>Type</center>" HtmlEncode="False" />
                
             <asp:BoundField DataField="driver_name" HeaderText="<center>Driver</center>" HtmlEncode="False"/>

       

              <asp:BoundField DataField="act_start" HeaderText="<center>Insurance <br>start date</center>" HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"  />
              <asp:BoundField DataField="act_ends" HeaderText="<center>Insurance <br>expiration date</center>" HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="act_start2" HeaderText="<center>Insurance <br>start date<br>(ประกันภัยบุคคลที่ 3)</center>" HtmlEncode="False" ItemStyle-Width="140px" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="act_ends2" HeaderText="<center>Insurance <br>expiration date<br>(ประกันภัยบุคคลที่ 3)</center>" HtmlEncode="False" ItemStyle-Width="140px" ItemStyle-HorizontalAlign="Center" />

              <asp:BoundField DataField="sumday" HeaderText="<center>Number of <br>the day<br>entered</center>" HtmlEncode="False" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center" />

             
              <asp:TemplateField HeaderText="<center>Add </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLinkAdds" NavigateUrl="#" runat="server" ><img src="../image/Button-Add-icon.png" ></asp:HyperLink>
              
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
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

  <script type="text/javascript" language="javascript" >
      function AddLicense(license_id) {
          winOpener = window.self.opener;
          winOpener.document.getElementById('HidValueLicense').value = license_id;
         
          winOpener.document.getElementById('BtnAddLicense').click();
          window.close();
      }
  </script>
  </div>
</asp:Content>

