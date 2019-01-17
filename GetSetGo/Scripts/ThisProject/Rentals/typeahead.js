//export { customerTypeAhead, vehicleTypeAhead };

//var customertb = $("#customer");
//var vehicletb = $("#vehicle");

//var customerTypeAhead = customertb.typeahead({
//    minLength: 1,
//    highlight: true,
//    hint: true
//}, {
//        name: 'customers',
//        display: 'name',
//        source: customers,
//        templates: {
//            suggestion: function (data) {
//                return '<div>Name: ' + data.name + '<br>Phone: ' + data.phone + '<div>';
//            }
//        }
//    }).on("typeahead:select", function (e, customer) {

//        if (customer.rentedVehicleId != null) {
//            toastr.error("This customer has already rented a vehicle.");
//            customertb.typeahead("val", "").focus();
//        } else {
//            $(".card").show();
//            vm.customerId = customer.id;
//            customertb.attr("disabled", "disabled").css({ "background": "#ceffd4" });
//            vehicletb.focus();
//            customerDetail.append(
//                "<div><strong>Customer Name:</strong> " + customer.name
//                + '<br><strong>Phone:</strong> ' + customer.phone
//                + '<br><strong>Driving Licence:</strong> ' + customer.drivingLicence
//                + "</div>");
//        };
//    });

//var vehicleTypeAhead = vehicletb.typeahead({
//    minLength: 1,
//    highlight: true,
//    hint: false
//}, {
//        name: 'vehicles',
//        display: 'name',
//        source: vehicles,
//        templates: {
//            suggestion: function (data) {
//                var vehicleAvailability = (data.availability) ? "<span class='text-success'>Available</span>" : "<span class='text-danger'>Not Available</span>";
//                return '<div>Name: ' + data.name + '<br>Type: ' + data.vehicleType.name + '<br>Plate Number: ' + data.plateNumber + '<br>Color: ' + data.color + '<br>Status: ' + vehicleAvailability + '</div>';
//            }
//        }
//    }).on("typeahead:select", function (e, vehicle) {
//        if (!vehicle.availability) {
//            toastr.error("This vehicle is currently not available.");
//            vehicletb.typeahead("val", "");
//        } else {
//            $(".card").show();
//            vm.vehicleId = vehicle.id;
//            vehicletb.attr("disabled", "disabled").css({ "background": "#ceffd4" });
//            vehicleDetail.append(
//                '<div><strong>Vehicle Name:</strong> ' + vehicle.name
//                + '<br><strong>Type:</strong> ' + vehicle.vehicleType.name
//                + '<br><strong>Color:</strong> ' + vehicle.color
//                + '<br><strong>Plate Number:</strong> ' + vehicle.plateNumber + '</div>');
//        }

//    });