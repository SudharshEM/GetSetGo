$(document).ready(function () {

    var table = $("#vehicles").DataTable({
        ajax: {
            url: "/api/vehicles",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
            },
            {
                data: "vehicleType.name"
            },
            {
                data: "plateNumber"
            },
            {
                data: "color"
            },
            {
                data: "availability",
                render: function (data) {
                    return (data) ? "<div class='text-success'>Available</div>" : "<div class='text-danger'>Not Available</div>";
                }
            }
        ]
    });

    $("#show-available").on("click", function () {
        $(this).text(function (i, text) {
            if (text == "Show Available") {
                table.column(4).search('^Available$', true, false).draw();
                return "Show All";
            } else {
                table.search('').columns().search('').draw();
                return "Show Available";
            };
        });
    });

    $("#show-available").click();
});