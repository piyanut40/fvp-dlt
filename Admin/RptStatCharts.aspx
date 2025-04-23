<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="RptStatCharts.aspx.vb" Inherits="Admin_RptStatCharts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <header class="w3-container" style="padding-top:22px">
 <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
 <script type="text/javascript" src="../Scripts/jquery-ui.js"></script> 

</header>
 

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
    <script src="../Scripts/Chart/modules/data.js"></script>
    <script src="../Scripts/Chart/modules/series-label.js"></script>
    <script src="../Scripts/Chart/modules/exporting.js"></script>

    <script src="RptStatChart.js"></script>




    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <center>
    
  <div  class="w3-row w3-padding w3-right"> 
  <input ID="btnExcel" runat="server" type="button" class="w3-button w3-purple2 w3-padding w3-round" value="Download Excel" onClick="download_Excel();" />
  <input ID="btnCSV" runat="server" type="button" class="w3-button w3-purple2 w3-padding w3-round" value="Download CSV" onClick="download_CSV();" />
               <asp:LinkButton ID="btnBack" runat="server"   
                   class="w3-button w3-purple2 w3-padding w3-round" 
                   PostBackUrl="RptStatChartData.aspx"  >ย้อนกลับ</asp:LinkButton> 
            </div>

  <div class="w3-container w3-content w3-center w3-padding-4" style="max-width:800px" >               <div  class="w3-row w3-padding w3-center" >   <asp:Label ID="lblHead" runat="server" Text="การขออนุญาตรถเข้ามาในราชอาณาจักร" Font-Bold="True" Font-Size="20"></asp:Label> 
  </div> 
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

          <asp:Label ID="lblHeadtable" runat="server" Text="<br />ด่านศุลกากรที่ขออนุญาตรถผ่านเข้า-ออก มากที่สุด 5 ลำดับแรก" Visible="false"  Font-Size="18"></asp:Label>
          </div>
       
       <br />
       <div class="w3-container w3-content w3-center" style="max-width:1600px" >
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Table ID="tbData" CssClass="responsive" runat="server" CellPadding="4" CellSpacing="0" Width="98%" BorderColor="#EEEDE8"></asp:Table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
       <div id="container" <% Response.Write(CssChart)%> ></div>
   
    <div id="container2" <% Response.Write(CssChart)%> ></div>
    
     

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

