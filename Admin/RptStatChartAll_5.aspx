<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPagePopup.master" AutoEventWireup="false" CodeFile="RptStatChartAll_5.aspx.vb" Inherits="Admin_RptStatChartAll_5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

<link href="../Styles/jquery-ui.css" rel="stylesheet" />  
 <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
 <script type="text/javascript">

     $(function () {
         var _year = <% Response.Write(_year)%>;

         var queryDate = _year + '-01-01',
         dateParts = queryDate.match(/(\d+)/g)
         realDate = new Date(dateParts[0], dateParts[1] - 1, dateParts[2]);

         $("#<%=txtsdate.ClientID %>").datepicker({
             changeMonth: true,
             changeYear: true,
             yearRange: "-15 :+0",
             showButtonPanel: true,
             dateFormat: 'dd/mm/yy'
         }).datepicker('setDate', realDate);


    

         $("#<%=txtedate.ClientID %>").datepicker({
             changeMonth: true,
             changeYear: true,
             yearRange: "-15 :+0",
             showButtonPanel: true,
             dateFormat: 'dd/mm/yy'
         }).datepicker('setDate', "0");
     });


    </script>
    
<%--For Chart--%>
    <script src="../Scripts/Chart/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/Chart/highcharts.js"></script>
    <%--<script src="../Scripts/Chart/highcharts-3d.js"></script>--%>
    <script src="../Scripts/Chart/modules/data.js"></script>
    <script src="../Scripts/Chart/modules/series-label.js"></script>
    <script src="../Scripts/Chart/modules/exporting.js"></script>

    <script src="RptStatChart.js"></script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <center>
   <div class="w3-container w3-content w3-center" style="max-width:1600px" >
    <div  class="w3-row w3-padding w3-right"> 
        <input ID="btnExcel" runat="server" type="button" class="w3-button w3-purple2 w3-padding w3-round" value="Download Excel" onClick="download_Excel();" />
        <input ID="btnCSV" runat="server" type="button" class="w3-button w3-purple2 w3-padding w3-round" value="Download CSV" onClick="download_CSV();" /> 
    </div>
    </div>
    
    <div class="w3-container w3-content w3-center w3-padding-4" style="max-width:800px" >  <asp:Label ID="lblHead" runat="server" Text="สถิติจำนวนรถ" Font-Bold="True" Font-Size="20"></asp:Label> 
 
  <div id="divShowDate" class="w3-row w3-padding "> 



            
             <div class="w3-col l1_1 w3-left-align w3-padding-top ">
            กรองตาม : 
            </div>

             <div class="w3-col l2_2 w3-padding-Left">
             <asp:DropDownList ID="ddldate" class="w3-input w3-border w3-round-large" runat="server" AppendDataBoundItems="true" ><%--onchange="document.getElementById('MainContent_BtnSch').click();"--%>
                 <asp:ListItem Value="1" Text="วันที่ออกใบเสร็จ"></asp:ListItem>
                 <asp:ListItem Value="2" Text="วันที่แจ้งขอเข้าประเทศ"></asp:ListItem>
                 </asp:DropDownList>

            </div>


           <div class="w3-col l1_1 w3-left-align w3-padding-top ">
            ระหว่างวันที่ : 
            </div>

            <div class="w3-col l2_2 w3-padding-Left">
             <asp:TextBox ID="txtsdate" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>

            </div>

             <div class="w3-col l1_1 w3-left-align w3-padding-top w3-padding-left">
             ถึงวันที่
            </div>

            <div class="w3-col l2_2 w3-padding-Left">

               <asp:TextBox ID="txtedate" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>

            </div>

            <div class="w3-col l1_1 w3-right-align">
      
           
           <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:Button class="w3-button w3-purple2 w3-padding w3-round" id="BtnSch" onclick="BtnSch_Click" runat="server" UseSubmitBehavior="false" Text="ค้นหา" > </asp:Button>
    </ContentTemplate>
    </asp:UpdatePanel>
            </div>

          </div>


          <br /><asp:Label ID="Label1" runat="server" Text="จำนวนรถที่ได้รับอนุญาตเข้ามาในราชอาณาจักรเป็นการชั่วคราว จำแนกตามสำนักงาน"  Font-Size="18" ForeColor="#333333"></asp:Label> 
          </div>

    <div class="w3-container w3-content w3-center" style="max-width:1600px" >
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Table ID="tbData" CssClass="responsive" runat="server" CellPadding="4" CellSpacing="0" Width="100%" BorderColor="#EEEDE8"></asp:Table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>

    </center>

    <asp:Button style="DISPLAY: none" ID="BtnDownloadCSV" runat="server" Text="Download CSV" Width="0px" />
<asp:Button style="DISPLAY: none" ID="BtnDownloadExcel" runat="server" Text="Download Excel" Width="0px" />
<script type="text/javascript">
    function download_CSV() {
        document.getElementById('MainContent_BtnDownloadCSV').click();
    }

    function download_Excel() {
        document.getElementById('MainContent_BtnDownloadExcel').click();
    }
</script>
</asp:Content>

