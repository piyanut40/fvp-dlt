<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GroupAdd_tab3.aspx.vb" Inherits="Travel_GroupAdd_tab3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--For Footable--%>
    <link rel="stylesheet" href="~/Footable/Icon/Styles/font-awesome.min.css" />

    
	<!-- Bootstrap core CSS -->
	<%--<link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet">
	<link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" rel="stylesheet">--%>
    <link rel="stylesheet" href="~/Footable/bootstrap.min.css" />
    <link rel="stylesheet" href="~/Footable/bootstrap-theme.min.css" />
   
    <link href="~/Footable/css/footable.bootstrap.min.css" rel="stylesheet" />
 
    <script src="../Footable/jquery.min.js"></script>
    <script src="../Footable/bootstrap.min.js"></script>
    <script src="../Footable/footable.js"></script>

    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous" />
     <script type="text/javascript" src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
     <link rel="stylesheet" href="~/Styles/w3.css">


    <link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
    <link href="../Styles/progress-wizard.min.css" rel="stylesheet"/>
    

    <link rel="Stylesheet" type="text/css" href="../Scripts/Semantic/semantic.min.css" />
    <script src="../Scripts/Semantic/semantic.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/css/w3-theme-deep-purple.css" />
    <link rel="stylesheet" href="../Styles/w3Home.css"/>


</head>
<body  class="w3-theme-l5">
<style type="text/css">
.PhotoAct
{
    width:280px;
    }
.delete
{
    margin-right: -370px;
    margin-top: -20px;
}.iframe{width:400px; height:300px;}
@media screen and (min-width: 480px) and (max-width:767px) and (orientation : portrait)
{
    .PhotoAct
{
    width: 200px;
    margin-right: 70%;
    }
.delete
{
    margin-right: 20px;
    margin-top: 10px;

}
.iframe
{   width: 250px;
    height: 250px;
    margin-left: -15%;  
}
    
}
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
    .PhotoAct
{
    width: 200px;
    margin-right: 70%;
    }
.delete
{
    margin-right: 20px;
    margin-top: 10px;
}.iframe
{   width: 250px;
    height: 250px;
    margin-left: -15%;  
}
}
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
{
    .PhotoAct
{
    width: 200px;
    margin-right: 70%;
    }
.delete
{
   margin-right: 20px;
    margin-top: 10px;
}.iframe
{   width: 250px;
    height: 250px;
    margin-left: -15%;  
    margin-top:-10%;
}
}
</style>

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
    <div id="form3" class="w3-animate-right fill center ui-form w3-margin text-dark ">

<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif;">
 <br />
<asp:Panel ID="Page3" runat="server">
<div class="row" id="Guide1_row1" runat="server" >
<b class="w3-text-purple" style="position:relative;font-family: 'Kanit', sans-serif;padding-bottom: .21428571rem;border-bottom: 2px solid rgba(34,36,38,.15);margin-left: 30px;font-size: x-large;margin-top: -35px;">
 Tour Leader <asp:Label ID="lblGuideNo1" runat="server" Text=""></asp:Label>
</b>
</div>

<div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif;">
<div class="fields" style="margin-top:2rem;">
<div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
         <div class=" five wide field w3-margin" style="font-family: 'Kanit', sans-serif;font-size: small;" id="divGuide1" runat="server">
            <label for="Surname" class="w3-left">Guide : </label>
                <asp:DropDownList id="ddlGuide" runat="server" class="w3-input w3-border w3-round-large " AppendDataBoundItems="True" >
                                <%--<asp:ListItem Value="0">เลือกทั้งหมด</asp:ListItem> --%>
                              </asp:DropDownList> 
        </div>
        <%--</div>
        <div class="fields" style="margin-top:2rem;">--%>
        <div class=" five wide field w3-margin" style="font-family: 'Kanit', sans-serif;font-size: small;" id="divGuide2" runat="server">
            <label for="Surname" class="w3-left">Car Registration No. : </label>
                <asp:TextBox ID="txtregis_no" class="form-control font_txt" runat="server"></asp:TextBox> 
        </div>
        <%--</div>
        <div class="fields" style="margin-top:2rem;">--%>



        <div class=" five wide field w3-margin" style="font-family: 'Kanit', sans-serif;font-size: small;" id="divGuide3" runat="server">
            <label for="Surname" class="w3-left">Car Registration Photo : </label>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
           <div style="font-family: 'Kanit', sans-serif;font-size: small;">
          <asp:FileUpload ID="FileUpload5" runat="server" onchange="document.getElementById('btnUploadAct').click();" />
            <asp:ImageButton ID="btnUploadAct" style="DISPLAY: none"  runat="server" AutoPostBack="true" ImageUrl="image/upload.png" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidPhotoAct" runat="server" />

            <asp:Image ID="PhotoAct" runat="server"  CssClass="PhotoAct"/>
            <%--<asp:ImageButton ID="PhotoDeleteAct"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="~/image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" class="delete"/>--%>
             <asp:ImageButton ID="PhotoDeleteAct"  OnClientClick="javascript:return confirm('Do you want delete photo?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
             </div>
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger  ControlID="btnUploadAct"/>
	          </Triggers>
           </asp:UpdatePanel>
        </div>

   
        <div class="seven wide field" style="font-family: 'Kanit', sans-serif;font-size: small; padding-top:20px; " id="divGuide4" runat="server">
        <asp:Button ID="BtnAddGuide" OnClientClick="$('#loadings').show();"   class=" w3-purple w3-btn w3-round-large w3-right-align w3-large"   runat="server" UseSubmitBehavior="false" Text="Add" /> 
   </div>
 </div>

 <div class="fields" style="margin-top:2rem;">
 <div class="one wide field" style="font-family: 'Kanit', sans-serif;font-size: small;">
        </div>
  <div class="thirteen  wide field  " style="font-family: 'Kanit', sans-serif;font-size: small;">

 <asp:UpdatePanel ID="UpdGrid_guide" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:GridView ID="gvMain_guide" runat="server" AutoGenerateColumns="False" 
        AllowPaging="true" Width="100%" EmptyDataText="No data" 
            EmptyDataRowStyle-HorizontalAlign="Center"  
            CssClass="table table-striped table-bordered table-center table-hover " >
        
         <Columns>
           <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                          <asp:Label id="lblguide_id" runat="server" Text='<%# eval("guide_id") %>'></asp:Label>
                                          <asp:Label id="lblgid" runat="server" Text='<%# eval("gid") %>'></asp:Label>
                                          <asp:Label id="lblregis_photo" runat="server" Text='<%# eval("regis_photo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
          <asp:BoundField DataField="number" HeaderText="<center>No.</center>" 
                 HtmlEncode="False" ItemStyle-HorizontalAlign="Center" >

             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

              <asp:BoundField DataField="guide_name" HeaderText="<center>Name</center>" HtmlEncode="False"/>
               <asp:BoundField DataField="guide_tel" HeaderText="<center>Telephone</center>" HtmlEncode="False"/>
               <asp:BoundField DataField="guide_idcard" HeaderText="<center>ID card</center>" HtmlEncode="False"/>
               <asp:BoundField DataField="regis_no" HeaderText="<center>Registration no</center>" HtmlEncode="False"/>

               <asp:TemplateField HeaderText="<center>Registration Photo </center>" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Image ID="Imgregis" runat="server" Width="280px" ImageUrl="#" />
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
              </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>Status </center>" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                           <asp:Label id="Labelstatus_guide" runat="server" ForeColor="#006600" Font-Size="14px"><i class="fa fa-check"></i></asp:Label>
                                          <asp:HiddenField ID="Hidstatus_guide" Value='<%# eval("status") %>' runat="server" />
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
              </asp:TemplateField>

              <asp:TemplateField HeaderText="<center>Delete </center>" ItemStyle-Width="50px" ItemStyle-HorizontalAlign=" right " >
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLinkDel_guide" NavigateUrl="#" runat="server" ><img src="../image/g_delete.gif" ></asp:HyperLink>
              
                                    </ItemTemplate>     
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
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

  <asp:Label id="NoteStatus_guide" runat="server" ForeColor="Red" ><i class="fa fa-asterisk"></i></asp:Label> This guide has been assigned to other group  
  </div>
  </div>
<br />

</div>

    <script type="text/javascript">
     function Submit() {
        $.confirm({
            title: 'Notification',
            content: "Once you have submitted the document, it cannot be modified again. Do you want to send it? ",
            buttons: {
                submit: function () {
                    document.getElementById('btnSubmit').click();
                },
                cancel: function () {
                   
                }
            }
        });
    }


      function AlertTravelExpire() {
        $.confirm({
            title: 'Notification',
            content: "Your license has expired. Please contact admin.",
            buttons: {
                OK: function () {
                 
                   var href = window.location.href.replace("GroupAdd.aspx", "EditUserTravel.aspx");
                   window.location.href = href;
                }
            }
        });
    }

    function AlertSubmit() { 
           $.alert({
            title: 'Alert!',
            content: "This guide has been assigned to other group",
            });
   
    }

    function AlertSubmit2() { 
           $.alert({
            title: 'Alert!',
            content: "Please add guide !!!!",
            });
   
    }

    </script>
     </asp:Panel>
 </br>
       <center><button class=" w3-center w3-purple w3-btn w3-round-large w3-large w3-margin"  onclick ="Submit();return false;" UseSubmitBehavior=false>Submit </Button>
       <asp:Button ID="btnSubmit"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large w3-margin" OnClientClick="$('#loadings').show();"   style="display:none"   runat="server" UseSubmitBehavior="false" Text="Save" /> &nbsp; &nbsp;&nbsp;
       <asp:Button ID="btnSave"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large w3-margin" OnClientClick="$('#loadings').show();"    runat="server" UseSubmitBehavior="false" Text="Save" /> &nbsp; &nbsp;&nbsp;
     <asp:Button ID="btnPrev2" class="w3-purple w3-btn w3-round-large w3-left w3-large w3-margin"  runat="server" UseSubmitBehavior="false" Text="Prev" /></center>

</div>

</div>
    </div>


     <script  type='text/javascript'>

        jQuery(function ($) {

            $(document).ready(function () {

                $('#<%= gvMain_guide.ClientID %>').footable({
                    "paging": {
                        "enabled": false
                    },
                  
                });

                var prm = Sys.WebForms.PageRequestManager.getInstance();

                prm.add_endRequest(function () {
                    $('#<%= gvMain_guide.ClientID %>').footable({
                        "paging": {
                            "enabled": false
                        },
                     
                    });
                });

            });
        }); 
         </script>

         <asp:Panel ID="PnDelete" style="DISPLAY: none" runat="server" >
    <asp:HiddenField ID="Hidstatus"  runat="server" />
    <asp:HiddenField ID="Hidchecktab_0"  runat="server" />
    <asp:HiddenField ID="Hidchecktab_1"  runat="server" />
    <asp:HiddenField ID="Hidchecktab_2"  runat="server" />
    <asp:HiddenField id="checkerr" runat="server"></asp:HiddenField>
    <asp:Button style="DISPLAY: none" id="BtnDelete_guide" runat="server" UseSubmitBehavior="false" ></asp:Button>
      
     <asp:HiddenField id="HidDelGuide_id" runat="server"></asp:HiddenField> 

     <asp:Button ID="btnNext3"  class=" w3-right  w3-purple w3-btn w3-round-large w3-large"   runat="server" UseSubmitBehavior="false" Text="Next" />
</asp:Panel>
          

    <script type='text/javascript'>

     

        function DelData2(guide_id) {
            var Msg = 'Do you want delete data ?';
            var IsConfirm = window.confirm(Msg);
            if (IsConfirm == true) {
                document.getElementById('HidDelGuide_id').value = guide_id;
                document.getElementById('BtnDelete_guide').click();
            } else {
                return false;
            }
        }



  
</script>
    </form>
</body>
</html>
