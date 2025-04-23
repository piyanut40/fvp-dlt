 
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
                    text: 'จำนวนรถที่ขออนุญาต',
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
            name: "รถที่ขออนุญาต",
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


//----------------------  Chart3 ---------------------------- 

function AddChart3(_data, _categories, chart_id, ShowAxisY) {

    Highcharts.chart(chart_id, {
        chart: {
            type: 'line'
        },
        title: {
            text: ''
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
                    style: {
                        fontFamily: 'thaisans',
                        fontSize: '18px'
                    }
                },
                enableMouseTracking: false
            }
        },
        legend: {
            enabled: false
        },
        series: [{
            name: 'รถที่ขออนุญาต',
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
            name: "จำนวนรถที่ขออนุญาต",
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
            name: "จำนวนรถที่ขออนุญาต",
            colorByPoint: true,
            data: _data
        }
    ]
    });
}

//----------------------  Chart6 --------------------------- 

function AddChart6(_data, _categories, chart_id, ShowAxisY) {

    Highcharts.chart(chart_id, {
        title: {
            text: ''
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
            layout: 'vertical',
            align: 'left',
            verticalAlign: 'middle',
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
