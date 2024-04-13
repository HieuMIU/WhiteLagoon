function loadLineChart(id, data) {
    var chartColors = getChartColorsArray(id);

    options = {
        chart: {
            type: "line",
            height: 350,
        },
        colors: chartColors,
        series: data.series,
        stroke: {
            curve: 'smooth',
            width: 2
        },
        markers: {
            size: 3,
            strokeWidth: 0,
            hover: {
                size: 9
            }
        },
        xaxis: {
            categories: data.categories,
        },
        yaxis: {
            labels: {
                style: {
                    colors: "#ddd",
                }
            }
        },
        legend: {
            labels: {
                colors: "#fff"
            }
        },
        tooltip: {
            theme: 'dark'
        }
    }

    var chart = new ApexCharts(document.querySelector("#" + id), options);

    chart.render();

}
