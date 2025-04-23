<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GroupAdd_tab2.aspx.vb" Inherits="Travel_GroupAdd_tab2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<%--For Footable--%>
    <link rel="stylesheet" href="~/Footable/Icon/Styles/font-awesome.min.css" />

	<!-- Bootstrap core CSS -->

    <link rel="stylesheet" href="~/Footable/bootstrap.min.css" />
    <link rel="stylesheet" href="~/Footable/bootstrap-theme.min.css" />
   
    <link href="~/Footable/css/footable.bootstrap.min.css" rel="stylesheet" />
 
    <script src="../Footable/jquery.min.js"></script>
    <script src="../Footable/bootstrap.min.js"></script>
    <script src="../Footable/footable.js"></script>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous" />
    <script type="text/javascript" src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
  
    <link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
    <link href="../Styles/progress-wizard.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>

    <link rel="Stylesheet" type="text/css" href="../Scripts/Semantic/semantic.min.css" />
    <script src="../Scripts/Semantic/semantic.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/css/w3-theme-deep-purple.css" />
    <link rel="stylesheet" href="../Styles/w3Home.css"/>




 
</head>
<body class="w3-theme-l5">

 <%--For Loading--%>
<style type="text/css">

.overlays
{
position: fixed;
z-index: 999;
height: 100%;
width: 100%;
top: 0;
background-color: Black;
filter: alpha(opacity=60);
opacity: 0.6;
-moz-opacity: 0.8;
color:White;


left: 0;
}

.loader {
    border: 16px solid #f3f3f3; /* Light grey */
    border-top: 16px solid #570EC2; /* purple */
    border-radius: 50%;
    width: 90px;
    height: 90px;
    animation: spin 2s linear infinite;
    margin-top:200px;
}

@keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
}

</style>
    <form id="form1" runat="server">
    <div>

    <script language="javascript" type="text/javascript">
        $(window).load(function () {
            $('#loadings').hide();
        });

</script>

  <div id="loadings" align="center" class="overlays">
            <div class="loader" ></div>
        </div>

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="form2" class="w3-animate-right fill center ui-form w3-margin text-dark ">

<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif; ">

<asp:Panel ID="Page2" runat="server">
<div class="fields" style="margin-top:2rem;">
 <div class="two wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
<div class="twelve wide field" style="font-family: 'Kanit', sans-serif;font-size: small; padding-top:20px; " align="right">
 <asp:UpdatePanel ID="UpdButton" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:LinkButton ID="LinkSelectCar" class="w3-button w3-purple w3-padding w3-round w3-large" runat="server" text="<i class='fa fa-search' aria-hidden='true' ></i> Find Existing Vehicle" ></asp:LinkButton>
        <asp:LinkButton ID="LinkAddCarNew" class="w3-button w3-purple w3-padding w3-round w3-large" runat="server" text="<i class='fa fa-plus' aria-hidden='true' ></i> Add New Vehicle" ></asp:LinkButton>
    </ContentTemplate>
  </asp:UpdatePanel>
   </div>
</div>

<div class="fields" style="margin-top:2rem; DISPLAY: none;" >
 <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
         <div class=" four wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
            <label for="Surname" class="w3-left">Car : </label> 
                

                              <asp:Label class="w3-left toplabel" ID="lblLicense" runat="server" Text="<br />-"></asp:Label>
        </div>
         <div class=" three wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <label for="Surname" class="w3-left">Type : </label> <br /> 
             <asp:Label class="w3-left toplabel" ID="lblType" runat="server" Text="-"></asp:Label>
         </div>
         <div class=" four wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
         <label for="Surname" class="w3-left">Driver : </label><br /> 
            <asp:Label class="w3-left toplabel" ID="lblDriver" runat="server" Text="-"></asp:Label>
         </div>
        <div class="three wide field" style="font-family: 'Kanit', sans-serif;font-size: small; ">
        <asp:Button ID="BtnAddLicense"  class=" w3-purple w3-btn w3-round-large  w3-right-align w3-large"  OnClientClick="$('#loadings').show();"     runat="server" UseSubmitBehavior="false" Text="Add" /> 
   </div>
   
 </div>

 <div class="fields" style="margin-top:2rem;">
  <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
  <div class=" thirteen wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">

 <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="false" Width="100%" EmptyDataText="No data" 
            EmptyDataRowStyle-HorizontalAlign="Center"  
            CssClass="table table-striped table-bordered table-center table-hover " >
        
         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                          <asp:Label id="lblgid" runat="server" Text='<%# eval("gid") %>'></asp:Label>
                                          <asp:Label id="lbllicense_id" runat="server" Text='<%# eval("license_id") %>'></asp:Label>
                                          <asp:Label id="lblstart_date" runat="server" Text='<%# eval("start_date") %>'></asp:Label>
                                          <asp:Label id="lblexp_date" runat="server" Text='<%# eval("exp_date") %>'></asp:Label>
                                          <asp:Label id="lblis_renew" runat="server" Text='<%# eval("is_renew") %>'></asp:Label>
                                          <asp:Label id="lblis_edit_user" runat="server" Text='<%# eval("is_edit_user") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" HeaderText="<center>No.</center>" 
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center" >

             <ItemStyle HorizontalAlign="Center" Width="50px" />
             </asp:BoundField>

              <asp:BoundField DataField="plate" HeaderText="<center>plate</center>" HtmlEncode="False"  />
              <asp:BoundField DataField="country_car" HeaderText="<center>Country of <br/>registration</center>" HtmlEncode="False" />
              <asp:BoundField DataField="type_name" HeaderText="<center>Type</center>" HtmlEncode="False"/>
              <asp:BoundField DataField="driver_name" HeaderText="<center>Driver</center>" HtmlEncode="False"/>
              <asp:BoundField DataField="status_en" HeaderText="<center>Status<br/>Permit</center>" HtmlEncode="False"/>
            
              <asp:TemplateField HeaderText="<center>Status<br/>Group</center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                           <asp:Label id="Labelstatus" runat="server" ForeColor="#006600" Font-Size="14px"><i class="fa fa-check"></i></asp:Label>
                                          <asp:HiddenField ID="Hidstatus" Value='<%# eval("status") %>' runat="server" />
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>change driver</center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         
               <asp:HyperLink ID="HyperEdit"  class="w3-large w3-text-purple" NavigateUrl='<%# Bind("urlEdit") %>' Target="_self" runat="server" ToolTip="Edit Data" ><i class="fa fa-edit " ></i></asp:HyperLink>
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />

              </asp:TemplateField>

              <asp:TemplateField HeaderText="<center> Insurance </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         
               <asp:HyperLink ID="HyperInsurance" class="w3-large w3-text-purple" NavigateUrl='<%# Bind("urlIns") %>' Target="_self" runat="server" ToolTip="Edit Data" ><i class="fa fa-edit " ></i></asp:HyperLink>
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />

              </asp:TemplateField>

              <asp:TemplateField HeaderText="<center> Edit </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                         
               <%-- <asp:HyperLink ID="HyperEdit2" class="w3-large w3-text-purple" NavigateUrl='<%# Bind("urlEdit2") %>' Target="_self" runat="server" ToolTip="Edit Data" ><i class="fa fa-edit " ></i></asp:HyperLink>--%>

               <asp:HyperLink ID="HyperEdit2" class="w3-large w3-text-purple" NavigateUrl='<%# string.Format("MgtEdit.aspx?token={0}&isedit=1", (Eval("token").ToString())) %>' Target="_blank" runat="server" ToolTip="Edit Data" ><i class="fa fa-edit " ></i></asp:HyperLink>
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
           
    </asp:GridView>
    
</ContentTemplate>
  </asp:UpdatePanel>

   
    </div>

  </div>


  <div class="fields" style="margin-top:2rem;"> 
  <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
  <div class=" five wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">

  <asp:Label id="NoteStatus" runat="server" ForeColor="Red" ><i class="fa fa-asterisk"></i></asp:Label> Vehicle have duplicate group tour  
  </div>
  </div>

  </asp:Panel>
<br /><br />
<asp:UpdatePanel ID="UpdateButton1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:HiddenField ID="HidDuplicate" runat="server" />
<asp:Button ID="btnNext3"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Next" />
<asp:Button ID="btnPrev1" class="w3-purple w3-btn w3-round-large w3-left w3-large"  runat="server" UseSubmitBehavior="false" Text="Prev" />
  </ContentTemplate>
  </asp:UpdatePanel>
</div>

</div>
    </div>

     <script type="text/javascript" language="javascript" >
    function DelData(license_id) {
        var Msg = 'Do you want delete data ?';
        var IsConfirm = window.confirm(Msg);
        if (IsConfirm == true) {
            document.getElementById('HidDel_ID').value = license_id;
            document.getElementById('BtnDelete').click();
        } else {
            return false;
        }
    }
     </script>

        <asp:HiddenField ID="HidValueLicense" runat="server" />
        <asp:Button style="DISPLAY: none" id="btnSetValueLicense" UseSubmitBehavior="false" runat="server" Text="Button" />
        <asp:HiddenField ID="HidExpire" runat="server" />
        <asp:HiddenField ID="Hidstatus"  runat="server" />
        <asp:Button style="DISPLAY: none" id="BtnDelete" runat="server" UseSubmitBehavior="false" ></asp:Button> 
         <asp:HiddenField id="HidDel_ID" runat="server"></asp:HiddenField>


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


         
    </form>
</body>
</html>
