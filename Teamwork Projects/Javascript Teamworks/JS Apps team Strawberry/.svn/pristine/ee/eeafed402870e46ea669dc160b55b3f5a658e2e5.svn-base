var DrawChart = function (chartTitles, fromMonth, toMonth, year) {
    var dataArray = [];
    dataArray.push(chartTitles);
        
    for (var i = fromMonth; i <= toMonth; i++) {
        var dataObject = createChartObject(i, year, homeBudget.getIncomes(i, year) || 0, homeBudget.getExpenses(i, year) || 0, homeBudget.getBudget(i, year) || 0);
        dataArray.push(dataObject);
    }

    function createChartObject(month, year, values) {
        var arrayObject = [];
        arrayObject[0] = arguments[0] + "";
        for (var i = 2; i < arguments.length; i++) {
            arrayObject[i - 1] = arguments[i];
        }

        return arrayObject;
    }    

    google.load("visualization", "1", { packages: ["corechart"] });
    google.setOnLoadCallback(drawChart);
    function drawChart() {
        var data = google.visualization.arrayToDataTable(dataArray);

        var options = {
            title: 'Budget Chart (' + year + ')',
            //hAxis: { slantedText: true, slantedTextAngle: 30 },
            legend: { position: 'bottom' },
            hAxis: { title: "Month" },
            vAxis: { title: "USD" },
        };

        var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
        chart.draw(data, options);        
    }
}