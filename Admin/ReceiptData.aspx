<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReceiptData.aspx.vb" Inherits="Admin_ReceiptData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
    <link rel="stylesheet" href="../Styles/w3.css">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
   
    <link rel="stylesheet" href="~/Footable/bootstrap.min.css" />
    <link rel="stylesheet" href="~/Footable/bootstrap-theme.min.css" />
   
    <link href="~/Footable/css/footable.bootstrap.min.css" rel="stylesheet" />
     
    <script src="../Footable/jquery.min.js"></script>
    <script src="../Footable/bootstrap.min.js"></script>
    <script src="../Footable/footable.js"></script>
</head>
<body>
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
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="80%" EmptyDataText="ไม่มีข้อมูล" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass="table table-striped table-bordered table-center table-hover " >
         <Columns>
             <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                           
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tdCenter" />
                                </asp:TemplateField>
           
             <asp:BoundField DataField="receipt_no" HeaderText="<center>เลขที่ใบเสร็จ</center>" HtmlEncode="False" />

             <asp:BoundField DataField="receipt_date" HeaderText="<center>วันที่ออกใบเสร็จ</center>"  ItemStyle-HorizontalAlign="Center"  HtmlEncode="False" DataFormatString="{0:d MMM yyyy}" />

              

               
         </Columns>
        
    </asp:GridView>
    </div>
    </form>
</body>
</html>
