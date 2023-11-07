$('#satistics, #satisticsMobile').click(function () {

    $('#modal').modal('show');
    $('#modal').draggable();

    var routeCategoryId = $('#RouteCategoryId').val();
    var programId = $('#ProgramId').val();
    var requestTypeId = $('#RequestTypeId').val();
    var communicationTypeId = $('#CommunicationTypeId').val();
    var referredFrom = $('#ReferredFrom').val();
    var bureau = $('#Bureau').val();
    var phoneNumber = $('#PhoneNumber').val();
    var streetNumber = $('#StreetNumber').val();
    var streetName = $('#StreetName').val();
    var city = $('#City').val();
    var countyId = $('#CountyId').val();
    var state = $('#State').val();
    var statusId = $('#StatusId').val();
    var startDate = $('#startDatePicker').val();
    var endDate = $('#endDatePicker').val();
    var trackingNumber = $('#TrackingNumber').val();;
    var firstName = $('#FirstName').val();
    var lastName = $('#LastName').val();
    var affiliation = $('#Affiliation').val();
    var userName = $('#CreatedBy_UserName').val();
    var table = $('#Table');
    if (startDate === "") {
        startDate = null;
    }
    if (endDate === "") {
        endDate = null;
    }

    $.ajax({
        url: '/Ticket/TicketSatistics/?routingCategoryId=' + routeCategoryId +
            '&programId=' + programId +
            '&requestTypeId=' + requestTypeId +
            '&communicationTypeId=' + communicationTypeId +
            '&referredFrom=' + referredFrom +
            '&bureau=' + bureau +
            '&phoneNumber=' + phoneNumber +
            '&streetNumber=' + streetNumber +
            '&streetName=' + streetName +
            '&city=' + city +
            '&countyId=' + countyId +
            '&state=' + state +
            '&statusId=' + statusId +
            '&startDate=' + startDate +
            '&endDate=' + endDate +
            '&trackingNumber=' + trackingNumber +
            '&lastName=' + lastName +
            '&firstName=' + firstName +
            '&affiliation=' + affiliation +
            '&userName=' + userName,
        type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        beforeSend: function () { $('#modalLoading').removeClass('d-none') },
        complete: function () { $('#modalLoading').addClass('d-none') },
        success: displaySatistics,
        error: error
    });
})

function displaySatistics(data) {    
    $('#amount').html('Based on your search criteria there are a total number of ' + data.amount + ' tickets');
    $('#amount').addClass('remove-class');
}

function error() {    
    $('#amount').html('Error: something didn\'t work right');
    $('#amount').addClass('text-danger');
}