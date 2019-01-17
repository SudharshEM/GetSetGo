var editor;

$(document).ready(function () {

    // Get the list of customers
    var table = $("#customers").DataTable({
        responsive: false,
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, customer) {
                    return "<a href='/customers/edit/" + customer.id + "'>" + customer.name + "</a>"
                }
            },
            {
                data: "dateOfBirth",
                render: function (data) {
                    return moment(data).format("ll");
                }
            },
            {
                data: "phone"
            },
            {
                data: "drivingLicence"
            },
            {
                data: "rentedVehicle",
                render: function (data) {
                    if (data == null)
                        return "-";
                    return '<div><strong>Vehicle:</strong> ' + data.name + ' <br><strong>Plate Number:</strong> ' + data.plateNumber + '</div>';
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn btn-sm btn-danger js-delete' data-customer-id=" + data + ">Delete</button>"
                }
            }
        ],
        "language": {
            "zeroRecords": "No records to display"
        }
    });


    // Delete Customer from table
    $("#customers").on("click", ".js-delete", function () {
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete this customer?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/customers/" + button.attr("data-customer-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    $("#show-active").on("click", function () {
        $(this).text(function (i, text) {
            if (text == "Show Active Customers") {
                table.column(4).search('^(?!-$)', true, false).draw();
                return "Show All";
            } else {
                table.search('').columns().search('').draw();
                return "Show Active Customers";
            };
        });
    });

    $("#show-active").click();
});