

$("#GetData").click(getData);

$('.DropDownGetData').change(getData);

$(document).ajaxStart(function () {
    $('#loading').removeClass('d-none');
})

$(document).ajaxComplete(function () {
    $('#loading').addClass('d-none')
})

$('#TrackingNumber').keypress(function (event) {
    trackingNumberInput(event);
});

$('#FirstName, #LastName, #CreatedBy_UserName').keypress(function (event) {
    nameInput(event);
});

function getData() {
    var routeCategoryId = $('#RouteCategoryId').val();
    var programId = $('#ProgramId').val();
    var requestTypeId = $('#RequestTypeId').val();
    var communicationTypeId = $('#CommunicationTypeId').val();
    var phoneNumber = $('#PhoneNumber').val();
    var countyId = $('#CountyId').val();
    var state = $('#State').val();
    var statusId = $('#StatusId').val();
    var startDate = $('#startDatePicker').val();
    var endDate = $('#endDatePicker').val();
    var streetNumber = $('#StreetNumber').val();
    var streetName = $('#StreetName').val();
    var city = $('#City').val();
    var trackingNumber = $('#TrackingNumber').val();
    var firstName = $('#FirstName').val();
    var lastName = $('#LastName').val();
    var userName = $('#CreatedBy_UserName').val();
    var table = $('#Table');
    if (startDate === "") {
        startDate = null;
    }
    if (endDate === "") {
        endDate = null;
    }

    $.ajax({
        url: '/Ticket/TicketArchiveData/?routingCategoryId=' + routeCategoryId +
            '&programId=' + programId +
            '&requestTypeId=' + requestTypeId +
            '&communicationTypeId=' + communicationTypeId +
            '&phoneNumber=' + phoneNumber +
            '&countyId=' + countyId +
            '&state=' + state +
            '&statusId=' + statusId +
            '&startDate=' + startDate +
            '&endDate=' + endDate +
            '&streetNumber=' + streetNumber +
            '&streetName=' + streetName +
            '&city=' + city +
            '&trackingNumber=' + trackingNumber +
            '&lastName=' + lastName +
            '&firstName=' + firstName +
            '&userName=' + userName,
        type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        success: successFunction,
        error: function () {
            table.html('<p id="ajaxError">Something isn\'t right</p>')
        }
    })    
}

function successFunction(result) {
    $('#Table').DataTable({
        destroy: true,
        data: result,
        columns: [
            {
                title: 'Ticket #', data: 'TicketId', width: '10%', className: 'text-center',
                render: function (data, type, ticket) {
                    return '<a href="/Ticket/Details/' + data + '?fromIndex=true" class="btn btn-outline-primary">' + data + '</a>'
                }
            },
            { title: 'Routing Category', data: 'RoutingCategory', width: '20%', className: 'align-center text-center' },
            { title: 'Program', data: 'Program', width: '15%', className: 'align-center text-center' },
            {
                title: 'Date', data: 'DisplayDate', type: 'date', width: '10%', className: 'd-none d-lg-table-cell align-center text-center'
            },
            { title: 'Request Type', data: 'RequestType', width: '20%', className: 'd-none d-lg-table-cell align-center text-center' },
            { title: 'Caller Name', data: 'ContactName', width: '20%', className: 'd-none d-lg-table-cell align-center text-center' },
            { title: 'County', data: 'County', width: '5%', className: 'd-none d-lg-table-cell align-center text-center' },
            {
                title: 'Status', data: 'Status', width: '10%', className: 'align-center text-center',
                render: function (data) {
                    if (data === 'Complete') {
                        return '<p class="text-success">Complete</p>';
                    } else if (data === 'Disabled') {
                        return '<p class="text-danger">Disabled</p>'
                    } else {
                        return '<p class="text-warning">Pending</p>'
                    }
                }
            }
        ],
        order: [3, 'desc']
    });
    $('#ajaxError').remove();
}

function trackingNumberInput(event) {
    var input = event.key;
    if (!(input == '0'
        || input == '1'
        || input == '2'
        || input == '3'
        || input == '4'
        || input == '5'
        || input == '6'
        || input == '7'
        || input == '8'
        || input == '9'
        || input == 'Space'
        || input == ' '
        || input == 'End'
        || input == 'Enter')) {
        event.preventDefault();
    } else if (input == 'Enter') {
        getData();
    }
}

function nameInput(event) {
    var input = event.key;
    if (input == 'Enter') {
        getData();
    }
}