function loadPieChart(id, data) {
    var chartColors = getChartColorsArray(id);

    options = {
        chart: {
            type: "pie",
            width: 380,
        },
        colors: chartColors,
        series: data.series,
        labels: data.labels,
        stroke: {
            show: false
        },
        legend: {
            position: 'bottom',
            horizontalAlign: 'center',
            labels: {
                colors: "#fff",
                useSeriesColors: true
            }
        }
    }

    var chart = new ApexCharts(document.querySelector("#" + id), options);

    chart.render();

}