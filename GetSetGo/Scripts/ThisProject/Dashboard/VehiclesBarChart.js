$(document).ready(function () {
    $.ajax({
        url: '/api/rentals',
        method: 'GET',
        success: function (data) {
            
            var obj = [];

            $(data).each(function (index, value) {
                var vehicleName = value.vehicle.name;
                var objIndex = obj.findIndex((obj => obj.name == vehicleName));
                if (objIndex >= 0) {
                    obj[objIndex].count += 1;
                } else {
                    obj.push(
                        {
                            name: vehicleName,
                            count: 1
                        }
                    );
                }
            });

            //console.log(obj);

            var vehiclesArray = [];
            var vehicleCountArray = [];

            obj.forEach(function (data) {
                vehiclesArray.push(data.name);
                vehicleCountArray.push(data.count);
            });

            //console.log(vehiclesArray);
            //console.log(vehicleCountArray);

            var chart = Highcharts.chart('vehiclesChart', {
                chart: {
                    type: 'bar'
                },
                title: {
                    text: 'Scope of Vehicles'
                },
                xAxis: {
                    categories: vehiclesArray
                },
                yAxis: {
                    title: {
                        text: 'Count'
                    }
                },
                series: [{
                    name: 'Number of Times Rented',
                    data: vehicleCountArray
                }],
                credits: {
                    enabled: false
                }
            });

            //end of rentals success callback
        }
        //end of rentals ajax request
    });
    // end of document ready
});