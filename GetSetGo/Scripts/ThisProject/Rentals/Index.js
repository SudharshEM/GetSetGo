

$(document).ready(function () {

    toastr.options = { "closeButton": true, "positionClass": "toast-bottom-right" };

    let table = $("#rentals").DataTable({
        ajax: {
            url: "/api/rentals",
            dataSrc: ""
        },
        columns: [
            {
                data: "customer.name",
                render: function (data, type, rental) {
                    //return "<div class='customer' data-container='body' data-toggle='popover' data-placement='left' data-content='Test' data-customer-id="+rental.customerId+" data-rental-id="+rental.id+">"+rental.customer.name+"</div>";
                    return "<div class='customer' data-customer-id="+rental.customerId+" data-rental-id="+rental.id+">"+rental.customer.name+"</div>";
                }
            },
            { data: "vehicle.name" },
            { data: "vehicle.plateNumber" },
            { data: "vehicle.color" },
            {
                data: "rentedDateTime",
                render: function (data) {
                    return moment(data).format('lll');
                }
            },
            {
                data: "returnedDateTime",
                render: function (data) {
                    if (data != null)
                        return moment(data).format('lll');
                    return "";
                }
            },
            {
                data: "id",
                render: function (data, type, rental) {
                    if (rental.returnedDateTime != null)
                        return "<button class='btn btn-sm' disabled>Return</button>";
                    return "<button data-rental-id=" + data + " class='btn btn-sm js-return'>Return</button>";

                }
            }
        ],
        "language": {
            "zeroRecords": "No records to display"
        }
        //,
        //drawCallback: function () {
        //    $('[data-toggle="popover"]').popover();
        //}
    });

    $('#rentals tbody').on("click", ".js-return", function () {
        let button = $(this);

        bootbox.confirm("Are you sure you want to mark this rental as returned?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/rentals/" + button.attr("data-rental-id"),
                    method: "PUT",
                    success: function () {
                        button.attr("disabled", "disabled");
                        table.ajax.reload(null, false);
                        toastr.success("Success!");
                    },
                    error: function () {
                        toastr.error("Something went wrong.");
                    }
                });
            }
        });

        table.ajax.reload(null, false);

    });

    $("#show-active").on("click", function () {
        $(this).text(function (i, text) {
            if (text == "Show Active Rentals") {
                table.column(5).search('^$', true, false).draw();
                return "Show All Rentals";
            } else {
                table.search('').columns().search('').draw();
                return "Show Active Rentals";
            };
        });
    });

    $("#show-active").click();

    //var storedCustomer;
    //table.on('mouseenter', 'tbody tr .customer', function () {
    //    var customerId = $(this).attr('data-customer-id');

    //    customerDetails(customerId);

    //    $('[data-toggle="popover"]').popover();

    //}).on('mouseleave', function () {

    //});

    //function customerDetails(id) {
    //    $.ajax({
    //        url: '/api/customers/' + id,
    //        method: "GET",
    //        success: function (data) {
    //            storedCustomer = data;
    //        }
    //    });
    //};

});