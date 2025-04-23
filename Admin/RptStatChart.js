
jQuery.noConflict();
var example = 'line-basic',
					theme = 'default';
(function ($) { // encapsulate jQuery
    Highcharts.setOptions({
        chart: {
            style: {
                fontFamily: 'thaisans',
                fontSize: '20px'
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


function CurrencyFormatted(amount) {
    var i = parseFloat(amount);
    if (isNaN(i)) { i = 0.00; }
    var minus = '';
    if (i < 0) { minus = '-'; }
    i = Math.abs(i);
    i = parseInt((i + .005) * 100);
    i = i / 100;
    s = new String(i);
    if (s.indexOf('.') < 0) { s += '.00'; }
    if (s.indexOf('.') == (s.length - 2)) { s += '0'; }
    s = minus + s;
    return s;
}


function CommaFormatted(amount) {
    var delimiter = ","; // replace comma if desired
    var a = amount.split('.', 2)
    var d = a[1];
    var i = parseInt(a[0]);
    if (isNaN(i)) { return ''; }
    var minus = '';
    if (i < 0) { minus = '-'; }
    i = Math.abs(i);
    var n = new String(i);
    var a = [];
    while (n.length > 3) {
        var nn = n.substr(n.length - 3);
        a.unshift(nn);
        n = n.substr(0, n.length - 3);
    }
    if (n.length > 0) { a.unshift(n); }
    n = a.join(delimiter);
    if (d.length < 1) { amount = n; }
    else { amount = n + '.' + d; }
    amount = minus + amount;
    return amount;
}

//----------------------  Chart1 ----------------------------  

function AddChart1(_data, chart_id, ShowAxisY) {

    Highcharts.chart(chart_id, {
        chart: {
            type: 'column'
        },
        title: {
            text: '', //'รถที่ขออนุญาตจำแนกตามสำนักงาน',
            style: {
                fontFamily: 'thaisans',
                fontSize: '22px'

            }
        },

        xAxis: {
            type: 'category',
            labels: {
                enabled: false,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        yAxis: {
            title: {
                text: 'จำนวนรถที่ได้รับอนุญาต',
                enabled: ShowAxisY
            },
            labels: {
                enabled: ShowAxisY,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        legend: {
            enabled: false,
            itemStyle: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        plotOptions: {
            series: {
                borderWidth: 1,
                dataLabels: {
                    enabled: true,
                    format: '{point.th}', // <br><b>จำนวน {point.y} คัน </b>  <b> (ร้อยละ {point.z})</b>',
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '17px'
                    }
                }
            }
        },

        tooltip: {
            headerFormat: '<span style="font-size:18px">{series.name}</span><br>',
            //pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b> of total<br/>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>จำนวน {point.y} คัน </b> <b> (ร้อยละ {point.z})</b><br/>',
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },

        series: [
        {
            //name: "Browsers",
            name: "รถที่ได้รับอนุญาต",
            colorByPoint: true,
            data: _data
        }
    ]
    });
}


function AddChart1Bar(_data, chart_id, ShowAxisY) {

    Highcharts.chart(chart_id, {
        chart: {
            type: 'bar'
        },
        title: {
            text: 'จำนวนรถที่ได้รับอนุญาตฯ จำแนกตามสำนักงาน',
            style: {
                fontFamily: 'thaisans',
                fontSize: '22px'

            }
        },

        xAxis: {
            type: 'category',
            labels: {
                //enabled: false,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                },
                formatter: function () {
                    /*if (this.value == "Malaysia")
                    return '<img src="http://www.highcharts.com/demo/gfx/sun.png" style="width: 30px; vertical-align: middle" />' + this.value;
                    else if (this.value == "Dec")
                    return '<img src="http://www.highcharts.com/demo/gfx/snow.png" style="width: 30px; vertical-align: middle" />' + this.value;
                    else*/
                    var x_th = this.value.replace("สำนักงานขนส่งจังหวัด", "สขจ.").replace("สำนักงานขนส่งกรุงเทพมหานคร", "สขพ.");
                    return x_th;
                }
            }
        },
        yAxis: {
            title: {
                text: '',
                enabled: ShowAxisY
            },
            labels: {
                enabled: ShowAxisY,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        legend: {
            enabled: false,
            itemStyle: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        plotOptions: {
            series: {
                borderWidth: 1,
                dataLabels: {
                    enabled: true,
                    format: '{point.y}', // <br><b>จำนวน {point.y} คัน </b>  <b> (ร้อยละ {point.z})</b>',
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '17px'
                    }
                }
            }
        },

        tooltip: {
            headerFormat: '<span style="font-size:18px">{series.name}</span><br>',
            //pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b> of total<br/>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>จำนวน {point.y} คัน </b> <b> (ร้อยละ {point.z})</b><br/>',
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },

        series: [
        {
            //name: "Browsers",
            name: "รถที่ได้รับอนุญาต",
            colorByPoint: true,
            data: _data
        }
    ]
    });
}


//----------------------  Chart2 ---------------------------- 

function AddChart2(_data, chart_id) {
    Highcharts.chart(chart_id, {
        chart: {
            type: 'pie'
        },
        title: {
            text: '', // 'ประเภทรถที่ขออนุญาต', 
            style: {
                fontFamily: 'thaisans',
                fontSize: '22px'

            }
        },
        tooltip: {
            headerFormat: '',
            pointFormat: '<span style="color:{point.color}">\u25CF</span> <b> {point.name}</b><br/>' +
            'จำนวน : <b>{point.y} คัน</b>, <b>{point.z}%</b><br/>',
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        series: [{
            minPointSize: 20,
            size: '70%',
            innerSize: '40%',
            zMin: 0,
            name: 'countries',
            data: _data,
            dataLabels: {
                enabled: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        }],
        plotOptions: {
            series: {
                borderWidth: 1,
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b><br/> <br/><b>{point.y} คัน</b> <b> {point.z}% </b><br/> ',
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    }
                }
            }
        }
    });
}


function AddChart2Pie3D(_data, chart_id) {
    Highcharts.chart(chart_id, {
        chart: {
            type: 'pie'
        },
        title: {
            text: 'ประเภทรถที่ได้รับอนุญาต', 
            style: {
                fontFamily: 'thaisans',
                fontSize: '22px'

            }
        },
        tooltip: {
            headerFormat: '',
            pointFormat: '<span style="color:{point.color}">\u25CF</span> <b> {point.name}</b><br/>' +
            'จำนวน : <b>{point.y} คัน</b>, <b>{point.z}%</b><br/>',
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        series: [{
            /*minPointSize: 20,
            size: '70%',
            innerSize: '40%',
            zMin: 0,*/
            type: 'pie',
            size: '55%',
            name: 'countries',
            data: _data,
            dataLabels: {
                enabled: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '15px'
                }
            }
        }],
        plotOptions: {
            series: {
                borderWidth: 1,
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b><br/> <br/><b>{point.y} คัน</b> <b> {point.z}% </b><br/> ',
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    }
                }
            }
        }
    });
}

//----------------------  Chart3 ---------------------------- 

function AddChart3(_data, _categories, chart_id, ShowAxisY, txtTitle) {

    Highcharts.chart(chart_id, {
        chart: {
            type: 'line'
        },
        title: {
            text: txtTitle,
            style: {
                fontFamily: 'thaisans',
                fontSize: '22px'

            }
        },
        xAxis: {
            categories: _categories, //['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            labels: {
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        yAxis: {
            title: {
                text: '', //'รถที่ขออนุญาต'
                enabled: ShowAxisY
            },
            labels: {
                enabled: ShowAxisY,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        plotOptions: {
            line: {
                dataLabels: {
                    enabled: true,
                    useHTML: true,
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'/*,
                        borderWidth: '1px',
                        color: 'red',
                        borderColor: 'red'*/
                    }/*,
                    
                    formatter: function () {
                        //var x_th = this.value.replace("สำนักงานขนส่งจังหวัด", "สขจ.").replace("สำนักงานขนส่งกรุงเทพมหานคร", "สขพ.");
                        return '<span style="borderWidth: 1px">' + this.y + '</span>';
                    }*/
                },
                enableMouseTracking: false
            }
        },
        legend: {
            enabled: false
        },
        series: [{
            name: 'รถที่ได้รับอนุญาต',
            data: _data //[7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
        }]
    });
}

//----------------------  Chart4 ---------------------------- 


function AddChart4(_data, chart_id) {

    Highcharts.chart(chart_id, {
        chart: {
            type: 'bar'
        },
        title: {
            text: ''
        },
        xAxis: {
            type: 'category',
            //categories: _categories, //['A', 'B', 'C', 'D', 'E'],
            labels: {
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '20px'
                }

                /*ยังไม่มีรูปให้ใส่*/
                /*, useHTML: true,
                formatter: function () {
                if (this.value == "Malaysia")
                return '<img src="http://www.highcharts.com/demo/gfx/sun.png" style="width: 30px; vertical-align: middle" />' + this.value;
                else if (this.value == "Dec")
                return '<img src="http://www.highcharts.com/demo/gfx/snow.png" style="width: 30px; vertical-align: middle" />' + this.value;
                else
                return this.value;
                }*/
            }

        },
        yAxis: {
            title: {
                text: '' //'รถที่ขออนุญาต'
            },
            labels: {
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        plotOptions: {
            column: {
                stacking: 'normal'
            },
            series: {
                borderWidth: 1,
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.y} คัน</b> <b>, (ร้อยละ {point.z}) </b><br/> ',
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    }
                }
            }
        },
        legend: {
            enabled: false
        },


        tooltip: {
            headerFormat: '<span style="font-size:18px">{series.name}</span><br>',
            //pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b> of total<br/>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>จำนวน {point.y} คัน </b> <b> (ร้อยละ {point.z})</b><br/>',
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },

        //series: _data 
        series: [{
            name: 'รถที่จดทะเบียน',
            data: _data //[7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
        }]
    });

}


function AddChart4Column(_data, chart_id) {

    Highcharts.chart(chart_id, {
        chart: {
            type: 'column'
        },
        title: {
            text: 'ประเทศรถที่จดทะเบียน 5 อันดับแรก',
            style: {
                fontFamily: 'thaisans',
                fontSize: '22px'

            }
        },
        xAxis: {
            type: 'category',
            //categories: _categories, //['A', 'B', 'C', 'D', 'E'],
            labels: {
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '20px'
                }
 
            }

        },
        yAxis: {
            title: {
                text: '' //'รถที่ขออนุญาต'
            },
            labels: {
                enabled: false,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        plotOptions: {
            /*column: {
                stacking: 'normal'
            },*/
            series: {
                borderWidth: 1,
                dataLabels: {
                    enabled: true,
                    format: '{point.y}', //'<b>{point.y} คัน</b> <b>, (ร้อยละ {point.z}) </b><br/> ',
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    }
                }
            }
        },
        legend: {
            enabled: false
        },


        tooltip: {
            headerFormat: '<span style="font-size:18px">{series.name}</span><br>',
            //pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b> of total<br/>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>จำนวน {point.y} คัน </b> <b> (ร้อยละ {point.z})</b><br/>',
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },

        //series: _data 
        series: [{
            name: 'รถที่จดทะเบียน',
            data: _data //[7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
        }]
    });

}


//----------------------  Chart5 ---------------------------- 

function AddChart5_1(_data, chart_id, ShowAxisY) {
    // Create the chart
    Highcharts.chart(chart_id, {
        chart: {
            type: 'bar'
        },
        title: {
            text: 'ด่านศุลกากรขาเข้า 5 อันดับแรก'
        },
        xAxis: {
            type: 'category',
            labels: {
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        yAxis: {
            title: {
                text: '' //'Total percent market share'
            },
            labels: {
                enabled: ShowAxisY,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }

        },
        legend: {
            enabled: false
        },
        plotOptions: {
            series: {
                borderWidth: 0,
                dataLabels: {
                    enabled: true,
                    format: '{point.y}',
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    }
                }
            }
        },

        tooltip: {
            headerFormat: '<span style="font-size:18px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>จำนวน {point.y} คัน </b> <b> (ร้อยละ {point.z})</b><br/>',
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },

        series: [
        {
            name: "จำนวนรถที่ได้รับอนุญาต",
            colorByPoint: true,
            data: _data
        }
    ]
    });
}

function AddChart5_2(_data, chart_id, ShowAxisY) {
    Highcharts.chart(chart_id, {
        chart: {
            type: 'bar'
        },
        title: {
            text: 'ด่านศุลกากรขาออก 5 อันดับแรก'
        },
        xAxis: {
            type: 'category',
            labels: {
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        yAxis: {
            title: {
                text: '' //'Total percent market share'
            },
            labels: {
                enabled: ShowAxisY,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }

        },
        legend: {
            enabled: false
        },
        plotOptions: {
            series: {
                borderWidth: 0,
                dataLabels: {
                    enabled: true,
                    format: '{point.y}',
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    }
                }
            }
        },

        tooltip: {
            headerFormat: '<span style="font-size:18px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>จำนวน {point.y} คัน </b> <b> (ร้อยละ {point.z})</b><br/>',
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },

        series: [
        {
            name: "จำนวนรถที่ได้รับอนุญาต",
            colorByPoint: true,
            data: _data
        }
    ]
    });
}

//----------------------  Chart6 --------------------------- 

function AddChart6(_data, _categories, chart_id, ShowAxisY, txtTitle, _layout, _align, _verticalAlign) {

    Highcharts.chart(chart_id, {
        title: {
            text: txtTitle,
            style: {
                fontFamily: 'thaisans',
                fontSize: '22px'

            }
        },
        xAxis: {
            categories: _categories, //['Apples', 'Oranges', 'Pears', 'Bananas', 'Plums'],
            labels: {
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: '',
                enabled: ShowAxisY
            },
            labels: {
                enabled: ShowAxisY,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        legend: {
            layout: _layout, //'vertical',
            align: _align, //'left',
            verticalAlign: _verticalAlign, //'middle',
            itemStyle: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        plotOptions: {
            series: {
                borderWidth: 0,
                dataLabels: {
                    enabled: true,
                    //format: '{point.y}',
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    },
                    formatter: function () {
                        if (this.series.name == "รวม") {
                            return this.y;
                        }
                        else {
                            return "";
                        }

                    }
                }
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:18px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>จำนวน {point.y} คัน </b> <b> (ร้อยละ {point.z})</b><br/>',
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        series: _data /*[{
            type: 'column',
            name: 'Jane',
            data: [3, 2, 1, 3, 4]
        }, {
            type: 'column',
            name: 'John',
            data: [2, 3, 5, 7, 6]
        }, {
            type: 'column',
            name: 'Joe',
            data: [4, 3, 3, 9, 0]
        }, {
            type: 'spline',
            name: 'รวม',
            data: [3, 2.67, 3, 6.33, 3.33],
            marker: {
                lineWidth: 2,
                lineColor: Highcharts.getOptions().colors[3],
                fillColor: 'white'
            }
        }]*/
    });
}





//----------------------  Chart7 ---------------------------
function AddChart7(_data, _categories, chart_id, ShowAxisY, txtTitle) {

    Highcharts.chart(chart_id, {
        chart: {
            type: 'line'
        },
        title: {
            text: txtTitle,
            style: {
                fontFamily: 'thaisans',
                fontSize: '22px'

            }
        },
        xAxis: {
            categories: _categories,
            labels: {
                enabled: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        yAxis: {
            title: {
                text: ''
            },
            labels: {
                enabled: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        legend: {
            enabled: true,
            itemStyle: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        plotOptions: {
            line: {
                dataLabels: {
                    enabled: false,
                    //format: '{point.th}', // <br><b>จำนวน {point.y} คัน </b>  <b> (ร้อยละ {point.z})</b>',
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    }
                },
                enableMouseTracking: false
            }
        },
        series: _data /*[{
            name: 'Tokyo',
            data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
        }, {
            name: 'London',
            data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8]
        }]*/
        /*
        dataLabels: {
            enabled: false
        }*/
    });

}




//----------------------  Chart9 ---------------------------
function AddChart9(_data, _categories, chart_id, ShowAxisY, txtTitle) {

    Highcharts.chart(chart_id, {
        chart: {
            type: 'column'
        },
        title: {
            text: txtTitle,
            style: {
                fontFamily: 'thaisans',
                fontSize: '22px'

            }
        },
        xAxis: {
            categories: _categories,
            crosshair: true,
            labels: {
                enabled: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: ''
            },
            labels: {
                enabled: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        legend: {
            //layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -20,
            y: 20,
            floating: true,
            itemStyle: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:18px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
            '<td style="padding:0"><b>{point.y} คัน</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true,
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        colors: ['#86bdf9', '#90e57e'],
        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0,
                dataLabels: {
                    enabled: true,
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    }
                }
            }
        },
        series: _data
    });

}



//----------------------  Chart12 กับ Chart14 ---------------------------

function AddChart12(_data, _categories, chart_id, ShowAxisY, txtTitle) {
    Highcharts.chart(chart_id, {
        chart: {
            type: 'column'
        },
        title: {
            text: txtTitle,
            style: {
                fontFamily: 'thaisans',
                fontSize: '22px'

            }
        },
        xAxis: {
            categories: _categories,
            crosshair: true,
            labels: {
                enabled: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: ''
            },
            labels: {
                enabled: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -20,
            y: 20,
            floating: true,
            itemStyle: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:18px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
            '<td style="padding:0"><b>{point.y} คัน</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true,
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0
            },
            dataLabels: {
                enabled: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        series: _data
    });
}



//----------------------  Chart15 3D---------------------------
var cur_value = 0;
function AddChart15(_data, _categories, chart_id, ShowAxisY, txtTitle) {
    Highcharts.chart(chart_id, {
        chart: {
            type: 'column'
        },
        title: {
            text: txtTitle
        },
        xAxis: {
            categories: _categories,
            crosshair: true,
            labels: {
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: ''
            },
            labels: {
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:18px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
            '<td style="padding:0"><b>{point.y} คัน</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true,
            style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        legend: {
            enabled: false
        },
        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0
            },
            dataLabels: {
                enabled: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        series: [{
            name: 'จำนวนรถ',
            data: _data,
            dataLabels: {
                enabled: true,
                //format: '{point.y:.1f}',
                useHTML: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                },
                formatter: function () {
                    if (cur_value == 0) {
                        cur_value = this.y;
                        //alert(cur_value)
                        return this.y;
                    }
                    else {
                        var _value = ((this.y - cur_value) / cur_value) * 100;
                        cur_value = this.y;
                        //alert(cur_value)
                        return '<center>' + CommaFormatted(CurrencyFormatted(_value)) +'% <br/>' + this.y + '</center>';
                    } 
                }
            }
        }]
    });
}

//'แบบ 3D หาวิธีใส่ dataLabels ยังไม่ได้!!!
function AddChart153D(_data, _categories, chart_id, ShowAxisY, txtTitle) {
    Highcharts.chart(chart_id, {
        chart: {
            type: 'cylinder',
            options3d: {
                enabled: true,
                alpha: 25,
                beta: 0,
                depth: 100,
                viewDistance: 25
            }
        },
        title: {
            text: txtTitle
        },
        xAxis: {
            categories: _categories, //['Apples', 'Oranges', 'Pears', 'Bananas', 'Plums'],
            labels: {
                enabled: true,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        yAxis: {
            title: {
                text: ''
            },
            labels: {
                enabled: false,
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        },
        tooltip: {
             style: {
                fontFamily: 'thaisans',
                fontSize: '18px'
            }
        },
        plotOptions: {
            series: {
                depth: 25,
                colorByPoint: true,
                dataLabels: {
                    enabled: true,
                    //format: '<b>{point.name}</b> ({point.y:,.0f})',
                    allowOverlap: true,
                    x: 10,
                    y: -5
                }
            }
        },
        series: [{
            data: _data, //[29.9, 71.5, 106.4, 129.2, 144.0],
            name: 'จำนวนรถ',
            //showInLegend: false,
            dataLabels: {
                enabled: true,
                format: '{point.y:.1f}',
                style: {
                    fontFamily: 'thaisans',
                    fontSize: '18px'
                }
            }
        }]
    });
}