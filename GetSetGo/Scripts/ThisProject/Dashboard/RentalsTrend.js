
$(document).ready(function () {

    $.ajax({
        url: '/api/rentals',
        method: 'GET',
        dataType: 'JSON',
        success: function (data) {

            var obj = [];

            $(data).each(function (index, value) {

                var onlyDate = value.rentedDateTime.substring(0, 10) + "T00:00:00.000"

                var objIndex = obj.findIndex((obj => obj.date == onlyDate));

                if (objIndex >= 0) {
                    obj[objIndex].count += 1;
                }
                else {
                    obj.push({
                        date: onlyDate,
                        count: 1
                    });
                };
            });

            //console.log(obj);

            var dateArray = [], countArray = [];

            obj.forEach(function (data) {
                var formatedDate = moment(new Date(data.date)).format('ll')
                dateArray.push(formatedDate);
                countArray.push(data.count);
            });

            //console.log(dateArray);
            //console.log(countArray);

            var chart = Highcharts.chart('rentalTrend', {
                chart: {
                    type: 'line'
                },
                title: {
                    text: 'Rentals Trend'
                },
                xAxis: {
                    categories: dateArray
                },
                yAxis: {
                    title: {
                        text: 'Count'
                    }
                },
                series: [{
                    name: 'Rental',
                    data: countArray
                }],
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
                },
                credits: {
                    enabled: false
                }
            });

            //end of ajax success call back
        }
    });

});