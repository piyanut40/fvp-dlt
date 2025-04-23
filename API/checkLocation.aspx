<%@ Page Language="VB" AutoEventWireup="false" CodeFile="checkLocation.aspx.vb" Inherits="API_checkLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

  <link rel="apple-touch-icon" sizes="128x128" href="image/logo_dlt.png">

    <link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
    <link rel="stylesheet" href="../Styles/w3.css">
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/boostrap-stackpath.css" rel="stylesheet" type="text/css" />
    <script src="../Styles/boostrap-stackpath.js"></script>
    <%--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>--%>
    
    <%--<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">--%>

    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">




    <%-- Footable --%>
     <link rel="stylesheet" href="~/Footable/Icon/Styles/font-awesome.min.css" />

   <%-- <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1/css/footable.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>--%>

    <link rel="stylesheet" href="~/Footable/bootstrap.min.css" />
    <link rel="stylesheet" href="~/Footable/bootstrap-theme.min.css" />
   
    <link href="../Footable/css/footable.bootstrap.min.css" rel="stylesheet" />
     
    <script src="../Footable/jquery.min.js"></script>
    <script src="../Footable/bootstrap.min.js"></script>
    <script src="../Footable/footable.js"></script>




<body>
<form runat=server>
  <header class="w3-container" style="margin-top: 10px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">ค้นหาข้อมูลส่ง Location จาก Token</b></a>
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
            <div class="w3-col l1 ">
               <i class="fa fa-search" aria-hidden="true"></i> กรองการค้นหา :
            </div>

            <div class="w3-col l2">
            <asp:TextBox ID="txtName" class="w3-input w3-border w3-round-large"  placeholder="Token" oninput="document.getElementById('BtnSch').click();" runat="server"></asp:TextBox>
            </div>


          </div><br />

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
     
         <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass="table  table-bordered table-center table-hover " >
         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
        
             <asp:BoundField DataField="id_location" HeaderText="<center>ID location</center>" 
                 HtmlEncode="False" />

             <asp:BoundField DataField="lat" HeaderText="<center>Lattitude</center>" HtmlEncode="False" />

             <asp:BoundField DataField="lon" HeaderText="<center>Longtitude</center>" HtmlEncode="False" />

             <asp:BoundField DataField="token_license" HeaderText="<center>Token</center>" HtmlEncode="False" />

             <asp:BoundField DataField="date_time" HeaderText="<center>เวลา</center>" HtmlEncode="False" ItemStyle-HorizontalAlign="Center" />

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
        <asp:HiddenField id="HidDel_ID" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="HidType" runat="server"></asp:HiddenField>
        <asp:HiddenField id="HidActive" runat="server"></asp:HiddenField> 

   <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:ImageButton ID="BtnSch" runat="server"  ImageUrl="~/images/schd.gif" />
    </ContentTemplate>
    </asp:UpdatePanel>
       
</asp:Panel>
</form>
</body>
</html>
