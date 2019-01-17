$(document).ready(function () {

    var vm = {
    };

    toastr.options = { "closeButton": true, "positionClass": "toast-bottom-right" };

    var customertb = $("#customer");
    var vehicletb = $("#vehicle");
    var customerDetail = $("#customer-detail");
    var vehicleDetail = $("#vehicle-detail");
    var submitBtn = $("#submit");
    var resetBtn = $("#reset");

    var customers = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/customers?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    customertb.typeahead({
        minLength: 1,
        highlight: true,
        hint: false
    }, {
            name: 'customers',
            display: 'name',
            source: customers,
            templates: {
                suggestion: function (data) {
                    let customerStatus;
                    if (data.rentedVehicleId != null)
                        customerStatus = "<br />Status: <span class='text-danger'>Not Available</span>";
                    else
                        customerStatus = "";

                    return '<div>Name: ' + data.name
                        + '<br>Phone: ' + data.phone
                        + customerStatus
                        + '<div>';
                }
            }
        }).on("typeahead:select", function (e, customer) {

            if (customer.rentedVehicleId != null) {
                toastr.error("This customer has already rented a vehicle.");
                customertb.typeahead("val", "").focus();
            } else {
                $(".card").show();
                vm.customerId = customer.id;
                customerDetail.empty();
                customerDetail.append(
                    "<div><strong>Customer Name:</strong> " + customer.name
                    + '<br><strong>Phone:</strong> ' + customer.phone
                    + '<br><strong>Driving Licence:</strong> ' + customer.drivingLicence
                    + "</div>");
                if (vehicletb.val() == "")
                    vehicletb.focus();
                else
                    submitBtn.focus();
            };
        });


    var vehicles = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/vehicles?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    vehicletb.typeahead({
        minLength: 1,
        highlight: true,
        hint: false
    }, {
            name: 'vehicles',
            display: 'name',
            source: vehicles,
            templates: {
                suggestion: function (data) {
                    var vehicleAvailability = (data.availability) ? "<span class='text-success'>Available</span>" : "<span class='text-danger'>Not Available</span>";
                    return '<div>Name: ' + data.name + '<br>Type: ' + data.vehicleType.name + '<br>Plate Number: ' + data.plateNumber + '<br>Color: ' + data.color + '<br>Status: ' + vehicleAvailability + '</div>';
                }
            }
        }).on("typeahead:select", function (e, vehicle) {
            if (!vehicle.availability) {
                toastr.error("This vehicle is currently not available.");
                vehicletb.typeahead("val", "");
            } else {
                $(".card").show();
                vm.vehicleId = vehicle.id;
                //vehicletb.attr("disabled", "disabled").css({ "background": "#ceffd4" });
                vehicleDetail.empty();
                vehicleDetail.append(
                    '<div><strong>Vehicle Name:</strong> ' + vehicle.name
                    + '<br><strong>Type:</strong> ' + vehicle.vehicleType.name
                    + '<br><strong>Color:</strong> ' + vehicle.color
                    + '<br><strong>Plate Number:</strong> ' + vehicle.plateNumber + '</div>');
                if (customertb.val() == "")
                    customertb.focus();
                else
                    submitBtn.focus();
            }

        });

    $.validator.addMethod("validCustomer", function () {
        return vm.customerId && vm.customerId !== 0;
    }, "Please select a valid customer.");

    $.validator.addMethod("validVehicle", function () {
        return vm.vehicleId && vm.vehicleId;
    }, "Please select a valid vehicle.");

    var validator = $("#newRental").validate({
        submitHandler: function () {
            $.ajax({
                url: "/api/rentals",
                method: "post",
                data: vm
            })
                .done(function () {
                    toastr.success("Rental successfully recorded.");
                    resetBtn.click();
                })
                .fail(function () {
                    toastr.error("Some error has occoured.");
                })
            return false;
        }
    });

    resetBtn.on("click", function () {
        vm = {}
        customertb.typeahead("val", "");
        customerDetail.empty();
        vehicletb.typeahead("val", "");
        vehicleDetail.empty();
        validator.resetForm();
        customertb.focus();
        $(".card").hide();
    });

    $("#customer").focus();
});