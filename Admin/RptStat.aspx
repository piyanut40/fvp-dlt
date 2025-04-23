<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptStat.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="Admin_RptStat" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <header class="w3-container" style="padding-top:22px">
    
 <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
 <script type="text/javascript" src="../Scripts/jquery-ui.js"></script> 
  <header class="w3-container" style="margin-top: 10px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;"><asp:Label ID="lbl" Text="ข้อมูลสถิติจำนวนรถ" runat="server"></asp:Label></b></a><br /><br/>
</header>


    <script type="text/javascript">

        $(function () {

            $("#<%=txtsdate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-15 :+0",
                showButtonPanel: true,
                dateFormat: 'dd/mm/yy'
            });

            $("#<%=txtedate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-15 :+0",
                showButtonPanel: true,
                dateFormat: 'dd/mm/yy'
            });
        });

        function ShowData() {

            if (document.getElementById("MainContent_rdoshow_0").checked == true) {

                document.getElementById("divshow1").style.display = "block";
                document.getElementById("divshow2").style.display = "none";
            }
            else if (document.getElementById("MainContent_rdoshow_1").checked == true) {

                document.getElementById("divshow1").style.display = "none";
                document.getElementById("divshow2").style.display = "none";
            }
            else if (document.getElementById("MainContent_rdoshow_2").checked == true) {

                document.getElementById("divshow1").style.display = "none";
                document.getElementById("divshow2").style.display = "block";
            }


        }



    </script>

  

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
 <i class="fa fa-search" aria-hidden="true"></i> กำหนดช่วงเวลา :
    <div class="w3-border-gray w3-round-large w3-border">

     

     <div class="w3-row w3-padding-small "> 
           
          </div>


           <div class="w3-row w3-padding "> 

            

            <div class="w3-col l1 w3-right-align w3-padding-top">
            ข้อมูลปี : &nbsp;
            </div>

            <div class="w3-col l2 w3-padding-Left">

                <asp:DropDownList ID="ddlSchyear" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                </asp:DropDownList>

            </div>

            <div class="w3-col l1 w3-right-align w3-padding-top">
            แบบขออนุญาต : &nbsp;
            </div>

            <div class="w3-col l2 w3-padding-Left">

                <asp:DropDownList ID="ddltype" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                
                </asp:DropDownList>

            </div>

             <div class="w3-col l07 w3-right-align w3-padding-top">
            ด่าน : &nbsp;
            </div>

            <div class="w3-col l2 w3-padding-Left">

                <asp:DropDownList ID="ddlBorder" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                </asp:DropDownList>

            </div>

            <div class="w3-col l05 w3-right-align w3-padding-top">
            ประเทศ : &nbsp;
            </div>

            <div class="w3-col l2 w3-padding-Left">

                <asp:DropDownList ID="ddlCountry" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                </asp:DropDownList>

            </div>

           
       
          </div>

         

          <div class="w3-row w3-padding "> 

          <div class="w3-col l1 w3-right-align w3-padding-top">
            กรองตาม : &nbsp;
            </div>

             <div class="w3-col l2 w3-padding-Left">
             <asp:DropDownList ID="ddldate" class="w3-input w3-border w3-round-large" runat="server" AppendDataBoundItems="true" ><%--onchange="document.getElementById('MainContent_BtnSch').click();"--%>
                 <asp:ListItem Value="1" Text="วันที่ออกใบเสร็จ"></asp:ListItem>
                 <asp:ListItem Value="2" Text="วันที่แจ้งขอเข้าประเทศ"></asp:ListItem>
                 </asp:DropDownList>

            </div>

             <div class="w3-col l1 w3-right-align w3-padding-top">
            แสดงข้อมูล : &nbsp;
            </div>

           

            <div class="w3-col l2 w3-padding-Left w3-padding-top">
                <asp:RadioButtonList ID="rdoshow" runat="server" RepeatDirection="Horizontal" onChange="ShowData();">
                <asp:ListItem Text="รายวัน" Selected="False" Value="0"></asp:ListItem>
                <asp:ListItem Text="รายเดือน" Selected="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="ช่วงวันที่" Selected="False" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
                
               
             

            </div>

            
             <div id="divshow1"  >

           <div  class="w3-col l07 w3-right-align w3-padding-top">
            เดือน
             : &nbsp;
            </div>

          <div class="w3-col l2 w3-padding-Left">
             <asp:DropDownList ID="ddlSchMonth" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >   </asp:DropDownList>
            </div>
           </div>

          <div id="divshow2"  > 


           <div class="w3-col l07 w3-right-align w3-padding-top">
            ตั้งแต่วันที่ : &nbsp;
            </div>

            <div class="w3-col l2 w3-padding-Left">
             <asp:TextBox ID="txtsdate" class="w3-input w3-border w3-round-large" runat="server"  Width="200px" autocomplete="off"></asp:TextBox>

            </div>

             <div class="w3-col l05 w3-right-align w3-padding-top">
            ถึงวันที่ : &nbsp;
            </div>

            <div class="w3-col l2 w3-padding-Left">

               <asp:TextBox ID="txtedate" class="w3-input w3-border w3-round-large"  Width="200px" runat="server" autocomplete="off"></asp:TextBox>

            </div>


          </div>
               
    
       
          </div>

            <div class="w3-row w3-padding "> 
 
             <div class="w3-col l3_1  w3-right w3-right-align">
          
             <asp:LinkButton ID="lnkSch" class="w3-button w3-purple2 w3-padding w3-round" runat="server" OnClientClick="document.getElementById('MainContent_BtnSch').click();"><i class="fa fa-search" aria-hidden="true" ></i>  ค้นหา</asp:LinkButton>
           
           <input ID="btnExcel" runat="server" type="button" class="w3-button w3-purple2 w3-padding w3-round" value="Download Excel" onClick="download_Excel();" />
        <input ID="btnCSV" runat="server" type="button" class="w3-button w3-purple2 w3-padding w3-round" value="Download CSV" onClick="download_CSV();" />
        
            </div>
            </div>
    </div>
    <%--<br />--%>
    


         
     


       

       <div id="container" ></div>
    <div class="w3-row "> 
    <asp:Table ID="tbData" CssClass="responsive" runat="server" CellPadding="4" CellSpacing="0" Width="100%" BorderColor="#EEEDE8"></asp:Table>
    </div>
        
    
    <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
  

     <asp:Button style="DISPLAY: none" id="BtnSch" onclick="BtnSch_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> 
    </ContentTemplate>
    </asp:UpdatePanel>




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