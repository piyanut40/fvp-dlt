<%@ Page Language="VB" AutoEventWireup="false" CodeFile="testChart.aspx.vb" Inherits="Admin_testChart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--For Chart--%>
    <script src="../Scripts/Chart/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/Chart/highcharts.js"></script>
    <script src="../Scripts/Chart/modules/data.js"></script>
    <script src="../Scripts/Chart/modules/series-label.js"></script>
    <script src="../Scripts/Chart/modules/exporting.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="container"> </div>
    </div>

    <script type="text/javascript">
        Highcharts.chart('container', {

            title: {
                //text: 'สถิติจำนวนรถ' 
                text: 'สถิติการฝ่าฝืนเงื่อนไข' 
            },
             
            xAxis: {
                categories: ['มค. 62', 'กพ. 62', 'มีค 62', 'เมษา 62'] 
            },
            yAxis: {
                title: {
                    text: 'จำนวนรถ'
                }
            },
            legend: {
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'middle'
            },

            plotOptions: {
                line: {
                    dataLabels: {
                        enabled: true
                    },
                    enableMouseTracking: false
                }
            },

            series: [{
                name: 'จำนวนรถ',
                data: [4, 1, 5, 6] 
            } ],

            responsive: {
                rules: [{
                    condition: {
                        maxWidth: 500
                    },
                    chartOptions: {
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
                            verticalAlign: 'bottom'
                        }
                    }
                }]
            }

        });
</script>
    </form>
</body>
</html>
