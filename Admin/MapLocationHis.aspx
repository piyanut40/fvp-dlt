<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="MapLocationHis.aspx.vb" Inherits="Admin_MapLocationHis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<header class="w3-container" style="padding-top:22px">
 <header class="w3-container" style="margin-top: 15px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">ติดตามตำแหน่ง<asp:Label ID="lblHead" runat="server" Text="รถ"></asp:Label> (ย้อนหลัง)</b></a><br /><br/>
</header>
</header>
 <script type="text/javascript">
 $(document).ready(function () {

  $(function () {
        $("#<%=txtstartdate.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            setDate: new Date(),
            showButtonPanel: true
        });

        $("#<%=txtstartdate.ClientID %>").keyup(function () {
            $("#<%=txtstartdate.ClientID %>").val('');
        })
    });

    $(function () {
        $("#<%=txtexpdate.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            setDate: new Date(),
            showButtonPanel: true
        });

        $("#<%=txtexpdate.ClientID %>").keyup(function () {
            $("#<%=txtexpdate.ClientID %>").val('');
        })
    });

});

</script>
 
        <div class="w3-row w3-padding-small"> 
            <div class="w3-col l2 <% Response.Write(Css)%>">
               <i class="fa fa-search" aria-hidden="true"></i> กรองการค้นหา :
            </div>
             


               <div class="w3-col l2  mr-2">
            <asp:TextBox ID="txtTour" class="w3-input w3-border w3-round-large" placeholder="บริษัททัวร์" oninput="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>

            <div class="w3-col l1 <% Response.Write(Css)%>">
            ช่วงวันที่ :
            </div>
                <div class="w3-col l1  mr-2">
            <asp:TextBox ID="txtstartdate"  class="w3-input w3-border w3-round-large" placeholder="วันที่เริ่มต้น" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>
           
            <div class="w3-col l1 mr-2">
             <asp:TextBox ID="txtexpdate"  class="w3-input w3-border w3-round-large" placeholder="วันที่สิ้นสุด" onchange="document.getElementById('MainContent_BtnSch').click();" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </div>

           <div class="w3-col l2 <% Response.Write(Css)%>">
              สถานะ : <asp:CheckBox ID="ChkIsWrong" runat="server" Checked="true" /> ออกนอกเส้นทาง
            </div>

            <div class="w3-col l1  w3-right-align" id="divAddType5" runat="server"  >
            <asp:Button class="w3-button w3-purple2 w3-padding w3-round" id="BtnSch" onclick="BtnSch_Click" runat="server" UseSubmitBehavior="false" Text="ค้นหา" > </asp:Button>
             <%--<asp:LinkButton ID="lnkAdd" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-plus" aria-hidden="true" ></i>  รถตามความตกลงระหว่างประเทศรถขนส่งเชิงพาณิชย์</asp:LinkButton>--%>
            </div>
          </div>
  

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
     <asp:UpdatePanel ID="UpdGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
     
      <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" EmptyDataText="ไม่มีข้อมูล" EmptyDataRowStyle-HorizontalAlign="Center" PageSize="10"  CssClass="table table-striped table-bordered table-center table-hover " >
    <Columns>
    <asp:TemplateField Visible="false">
        <ItemTemplate>
         <asp:Label id="lbltoken" runat="server" Text='<%# eval("token") %>'></asp:Label>
            
        </ItemTemplate>
    </asp:TemplateField>
         <asp:BoundField DataField="num" HeaderText="<center>No.</center>" ItemStyle-HorizontalAlign="Center"  HtmlEncode="False" />
        
         <asp:BoundField DataField="name_company" HeaderText="<center>บริษัททัวร์</center>" HtmlEncode="False" />
         <asp:BoundField DataField="license_group" HeaderText="<center>เลขทัวร์กรุ๊ป</center>" HtmlEncode="False" />
         <asp:BoundField DataField="group_name" HeaderText="<center>ชื่อกรุ๊ป</center>" HtmlEncode="False" />
          <asp:BoundField DataField="start_date" HeaderText="<center>วันเริ่มต้น</center>" HtmlEncode="False" ItemStyle-HorizontalAlign="Center" />
          <asp:BoundField DataField="exp_date" HeaderText="<center>วันสิ้นสุด</center>" HtmlEncode="False" ItemStyle-HorizontalAlign="Center" />
        
           <asp:BoundField DataField="guide" HeaderText="<center>ผู้นำเที่ยว</center>" HtmlEncode="False" />
           
             <asp:BoundField DataField="cntAll" HeaderText="<center>ทั้งหมด</center>" HtmlEncode="False" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"/>
             <asp:BoundField DataField="cntWrong" HeaderText="<center>ออกนอกเส้นทาง</center>" HtmlEncode="False" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" />
              
              <asp:BoundField DataField="max_date_time" HeaderText="<center>วันเวลา<br />ส่งข้อมูลล่าสุด</center>" HtmlEncode="False"  ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
              
         <asp:TemplateField HeaderText="<center>แผนที่ </center>" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperMap" NavigateUrl='#' Target="_parent" runat="server" ToolTip="ดูข้อมูล" ><i class="fa fa-map-marker " ></i></asp:HyperLink>
                                    </ItemTemplate>
             </asp:TemplateField>

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

    <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:ImageButton ID="ImageButton1" runat="server" style="display:none"/>
    </ContentTemplate>
    </asp:UpdatePanel>


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



        function DelData(Del_ID) {
            var Msg = 'คุณต้องการลบข้อมูลใช่หรือไม่?';
            var IsConfirm = window.confirm(Msg);
            if (IsConfirm == true) {
                document.getElementById('MainContent_HidDel_ID').value = Del_ID;
                document.getElementById('MainContent_BtnDelete').click();
            }
            else {
                return false;
            }
        }
    </script>

 
</asp:Content>

