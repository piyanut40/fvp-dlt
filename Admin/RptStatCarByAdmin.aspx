<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="RptStatCarByAdmin.aspx.vb" Inherits="Admin_RptStatCarByAdmin" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<header class="w3-container" style="padding-top:22px">
 <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
 <script type="text/javascript" src="../Scripts/jquery-ui.js"></script> 
    <%--<h4 class="headtxt"><b><asp:Label ID="lbl" Text="สถิติจำนวนรถ" runat="server"></asp:Label></b></h4>--%>
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

   

<center>

 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<div class="w3-card-4 w3-margin w3-white " style="max-width:1500px">
  
  <div  class="w3-row w3-padding w3-right"> 
           <%--  <a href="javascript:void(0)" class="w3-button w3-purple2 w3-padding w3-round"  onclick="document.getElementById('<%=BtnExportExcel.ClientID %>').click();"  >Export Excel ข้อมูลการอนุญาตรถท่องเที่ยว</a>--%>

               <asp:LinkButton ID="btnBack" runat="server"   
                   class="w3-button w3-purple2 w3-padding w3-round" 
                   PostBackUrl="RptStatChartData.aspx"  >ย้อนกลับ</asp:LinkButton>  

                    
            </div>

            <div class="w3-container w3-content w3-center w3-padding-4" style="max-width:800px" >               <div  class="w3-row w3-padding w3-center" >   <asp:Label ID="lblHead" runat="server" Text="รายงานการอนุญาตรถเข้ามาในราชอาณาจักรชั่วคราว จำแนกตามสำนักงาน" Font-Bold="True" Font-Size="20"></asp:Label> 
  </div> 
  <div id="divShowDate" runat="server" class="w3-row w3-padding "> 


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

          <div id="divShowMonth" runat="server" class="w3-row w3-padding "> 

  
            <div class="w3-col l1_1 w3-left-align w3-padding-top ">
            กรองตาม : 
            </div>

             <div class="w3-col l2_2 w3-padding-Left">
             <asp:DropDownList ID="ddldate1" class="w3-input w3-border w3-round-large" runat="server" AppendDataBoundItems="true" ><%--onchange="document.getElementById('MainContent_BtnSch').click();"--%>
                 <asp:ListItem Value="1" Text="วันที่ออกใบเสร็จ"></asp:ListItem>
                 <asp:ListItem Value="2" Text="วันที่แจ้งขอเข้าประเทศ"></asp:ListItem>
                 </asp:DropDownList>

            </div>

           <div class="w3-col l1_1 w3-left-align w3-padding-top ">
            ประจำเดือน : 
            </div>

            <div class="w3-col l2_2 w3-padding-Left">
             <asp:DropDownList ID="ddlSchMonth" runat="server" Width="120px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >   </asp:DropDownList>

            </div>

             <div class="w3-col l1_1 w3-left-align w3-padding-top w3-padding-left">
             ปี พ.ศ. 
            </div>

            <div class="w3-col l2_2 w3-padding-Left">

               <asp:DropDownList ID="ddlSchyear" runat="server" Width="120px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                </asp:DropDownList>

            </div>

            <div class="w3-col l1_1 w3-right-align">
                      
           <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
     <asp:Button class="w3-button w3-purple2 w3-padding w3-round" id="Button1" onclick="BtnSch_Click" runat="server" UseSubmitBehavior="false" Text="ค้นหา" > </asp:Button>
    </ContentTemplate>
    </asp:UpdatePanel>
            </div>

          </div>

          <asp:Label ID="lblHeadtable" runat="server" Text="<br />ด่านศุลกากรที่ขออนุญาตรถผ่านเข้า-ออก มากที่สุด 5 ลำดับแรก" Visible="false"  Font-Size="18"></asp:Label>
          </div>

  
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>   
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server">
                </rsweb:ReportViewer>
            </ContentTemplate>
        </asp:UpdatePanel>
         <asp:Panel ID="PnUpload" style="DISPLAY: none" runat="server" >
        <asp:Button ID="BtnExportExcel" class="w3-button w3-green2 w3-hover-black w3-padding-4 " Text="Export Excel" runat="server"  /> 

    </asp:Panel>
    </div>
      </center>

</asp:Content>

