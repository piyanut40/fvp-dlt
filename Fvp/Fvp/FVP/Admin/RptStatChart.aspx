<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptStatChart.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="Admin_RptStatChart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <header class="w3-container" style="padding-top:22px">
    
 <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
 <script type="text/javascript" src="../Scripts/jquery-ui.js"></script> 
  <header class="w3-container" style="margin-top: 10px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;"><asp:Label ID="lbl" Text="กราฟสถิติจำนวนรถ" runat="server"></asp:Label></b></a><br /><br/>
</header>
  <%--  <h4 class="headtxt"><b><asp:Label ID="lbl" Text="สถิติจำนวนรถ" runat="server"></asp:Label><%--สถิติการฝ่าฝืนเงื่อนไข--%><%--</b></h4>--%>

 

 <%--For Chart--%>
    <script src="../Scripts/Chart/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/Chart/highcharts.js"></script>
    <script src="../Scripts/Chart/modules/data.js"></script>
    <script src="../Scripts/Chart/modules/series-label.js"></script>
    <script src="../Scripts/Chart/modules/exporting.js"></script>
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

                document.getElementById("divshow1").style.display = "none";
                document.getElementById("divshow2").style.display = "none";
            }
            else if (document.getElementById("MainContent_rdoshow_1").checked == true) {

                document.getElementById("divshow1").style.display = "none";
                document.getElementById("divshow2").style.display = "block";
            }
        

        }



    </script>

    <script type="text/javascript">


        jQuery.noConflict();
        var example = 'line-basic',
					theme = 'default';
        (function ($) { // encapsulate jQuery
            Highcharts.setOptions({
                chart: {
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    },
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    options3d: {
                        enabled: true,
                        alpha: 45,
                        beta: 0
                    }
                },
                lang: {
                    thousandsSep: ','
                },
                exporting: {
                    chartOptions: {
                        yAxis: {
                            labels: {
                                style: {
                                    fontFamily: 'thaisans',
                                    fontSize: '18px'
                                }
                            }
                        }
                    }
                }
            });
        })(jQuery);

        function AddChart(_data1, _data2, _data3, _data4, _data5, _data6, _data7, _dataMonth_name) {
            Highcharts.chart('container', {
                chart: {
                    type: 'line'

                },

                title: {
                    text: 'จำนวนรถจำแนกตามประเภท'
                , style: {
                    fontFamily: 'thaisans',
                    fontSize: '22px'

                }
                },

                xAxis: {
                    categories: _dataMonth_name
                , title: {
                    text: 'เดือน'

                },
                    labels: {
                        style: {
                            fontFamily: 'thaisans',
                            fontSize: '18px'
                        }
                    }

                , gridLineWidth: 1
                    //  ,lineWidth: 0,
                    //  minorGridLineWidth: 0,
                    //  lineColor: 'transparent',
                    //  minorTickLength: 0,
                    // ,tickLength: 20

                },
                yAxis: {
                    min: 0,
                    labels: {
                        style: {
                            fontFamily: 'thaisans',
                            fontSize: '18px'
                        }
                    },
                    title: {
                        text: 'จำนวนรถ (คัน)'
                         , align: 'high'
                    }

                },
                tooltip: {
                    valueSuffix: ' คัน',
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    }

                },
                plotOptions: {
                    bar: {
                        dataLabels: {
                            enabled: true,
                            style: {
                                fontFamily: 'thaisans',
                                fontSize: '18px'
                            }
                        },

                        series: {
                            groupPadding: 0
                        }
                    }

                },
                legend: {

                    borderWidth: 1,
                    backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
                    shadow: true,
                    itemStyle: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    }
                },
                credits: {
                    enabled: false
                },
                series: [{
                    name: 'Motorcycle',
                    data: _data1
                }, {
                    name: 'Passenger Car (≤ 9 seats)',
                    data: _data2
                }, {
                    name: 'Passenger Car (≤ 12 seats)',
                    data: _data3
                }, {
                    name: 'Pickup Truck (≤ 3,500 kg)',
                    data: _data4
                }, {
                    name: 'Van (≤ 12 seats)',
                    data: _data5
                }, {
                    name: 'Bus',
                    data: _data6
                }, {
                    name: 'Truck',
                    data: _data7
                }]
            });
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
                <%--<asp:ListItem Value="" Text="เลือกทั้งหมด" Selected="True"></asp:ListItem>
                <asp:ListItem Value="1" Text="รถประจำถิ่น"></asp:ListItem>
                <asp:ListItem Value="3" Text="รถตามความตกลงระหว่างประเทศลาว"></asp:ListItem>
                <asp:ListItem Value="4" Text="รถตามความตกลงระหว่างประเทศมาเลเซียและสิงคโปร์"></asp:ListItem>
                <asp:ListItem Value="5" Text="รถตามความตกลงระหว่างประเทศเชิงพาณิชย์"></asp:ListItem>
                <asp:ListItem Value="2" Text="รถเพื่อการท่องเที่ยว"></asp:ListItem>--%>

                <%--<asp:ListItem Value="1" Text="รถประจำถิ่น"></asp:ListItem>
                <asp:ListItem Value="2" Text="รถตามความตกลง"></asp:ListItem>
                <asp:ListItem Value="3" Text="รถท่องเที่ยว"></asp:ListItem>--%>
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

                <asp:DropDownList ID="ddlCountry" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true">
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


            <div class="w3-col l1 w3-right-align w3-padding-top" >
            แสดงข้อมูล : 
            </div>

            <%--<div class="w3-col l2 w3-padding-Left">

                <asp:DropDownList ID="ddlSchDay" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >
                </asp:DropDownList>

            </div>

             <div class="w3-col l2 w3-right-align w3-padding-top">
            รายเดือน : 
            </div>--%>

            <div class="w3-col l2 w3-padding-Left w3-padding-top" >
                <asp:RadioButtonList ID="rdoshow" runat="server" RepeatDirection="Horizontal" onChange="ShowData();">
                <%--<asp:ListItem Text="รายวัน" Selected="False" Value="0" ></asp:ListItem>--%>
                <asp:ListItem Text="รายเดือน" Selected="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="ช่วงวันที่" Selected="False" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
                
               
             

            </div>


         <div id="divshow1" >

           <div  class="w3-col l07 w3-right-align w3-padding-top">
            เดือน : &nbsp;
            </div>

          <div class="w3-col l2 w3-padding-Left">
             <asp:DropDownList ID="ddlSchMonth" runat="server" Width="200px" class="w3-input w3-border w3-round-large" AppendDataBoundItems="true" >   </asp:DropDownList>
            </div>
           </div>

          <div id="divshow2" > 


           <div class="w3-col l05 w3-right-align w3-padding-top">
            ตั้งแต่วันที่ : &nbsp;
            </div>

            <div class="w3-col l2 w3-padding-Left">
             <asp:TextBox ID="txtsdate" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>

            </div>

             <div class="w3-col l05 w3-right-align w3-padding-top">
            ถึงวันที่ : &nbsp;
            </div>

            <div class="w3-col l2 w3-padding-Left">

               <asp:TextBox ID="txtedate" class="w3-input w3-border w3-round-large" runat="server" autocomplete="off"></asp:TextBox>

            </div>


          </div>
           

       
          </div>


          <div class="w3-col w3-right-align">
          
             <asp:LinkButton ID="lnkSch" class="w3-button w3-purple2 w3-padding w3-round" runat="server" OnClientClick="document.getElementById('MainContent_BtnSch').click();"><i class="fa fa-search" aria-hidden="true" ></i>  ค้นหา</asp:LinkButton>
            </div>   
 <br />

 <br />
    </div>
   

    
    

       <br />
       <div id="container" style="min-width: 500px; max-width: 1100px; min-height: 600px; margin: 0 auto"></div>
    <div class="row">
    <asp:Table ID="tbData" CssClass="responsive" runat="server" CellPadding="4" CellSpacing="0" Width="98%" BorderColor="#EEEDE8"></asp:Table>
    </div>
        
       <%--<asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
         <ContentTemplate> 
          <center>
            <asp:Table ID="tbData" CssClass="responsive" runat="server" CellPadding="4" CellSpacing="0" Width="98%" BorderColor="#EEEDE8"></asp:Table>

          </center>
          </ContentTemplate>
   </asp:UpdatePanel>--%>
    <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <%--<asp:ImageButton ID="BtnSch" runat="server" style="display:none"/>--%>

     <asp:Button style="DISPLAY: none" id="BtnSch" onclick="BtnSch_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> 
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>