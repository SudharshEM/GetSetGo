$(document).ready(function () {

    var table = $("#vehicles").DataTable({
        ajax: {
            url: "/api/vehicles",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, vehicle) {
                    return "<a href='/vehicles/edit/" + vehicle.id + "'>" + vehicle.name + "</a>";
                }
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
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn btn-danger btn-sm js-delete' data-vehicle-id=" + data + ">Delete</button>"
                }
            }
        ],
        "language": {
            "zeroRecords": "No records to display"
        }
    });

    $("#vehicles").on("click", ".js-delete", function () {
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete this vehicle?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/vehicles/" + button.attr("data-vehicle-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    $("#show-available").on("click", function () {
        $(this).text(function (i, text) {
            if (text == "Show Available") {
                table.column(4).search('^Available$',true, false).draw();
                return "Show All";
            } else {
                table.search('').columns().search('').draw();
                return "Show Available";
            };
        });
    });

    $("#show-available").click();


});