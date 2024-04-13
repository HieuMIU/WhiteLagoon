$(document).ready(function () {
    loadBookingAndCustomerLineChartData();
});

function loadBookingAndCustomerLineChartData(){
    $(".newmemberandbooking-chart-spinner").show();

    $.ajax({
        url: "/Dashboard/GetMemberAndBookingLineChartData",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            
            loadLineChart("newMembersAndBookingLineChart", data);

            $(".newmemberandbooking-chart-spinner").hide();
        }
    })
};

