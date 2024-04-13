$(document).ready(function () {
    loadCustomerBookingsData();
});

function loadCustomerBookingsData(){
    $(".customerbookings-chart-spinner").show();

    $.ajax({
        url: "/Dashboard/GetBookingPieChartData",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            
            loadPieChart("customerBookingPieChart", data);

            $(".customerbookings-chart-spinner").hide();
        }
    })
};

