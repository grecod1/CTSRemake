

$("#GetData, #GetDataMobile").click(ticketAJAX);


$('#TrackingNumber').keypress(function (event) {
    trackingNumberInput(event);
});

$('#FirstName, #LastName, #CreatedBy_UserName, #City, #StreetNumber, #StreetName, #PhoneNumber').keypress(function (event) {
    nameInput(event);
})

$('#satistics, #satisticsMobile').click(function () {
    $('#modal').modal('show');
    $('#modal').draggable();

    $.ajax({
        url: '/API/TicketAPI/Count',
        type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        data: getTicketFields(),
        beforeSend: function () { $('#modalLoading').removeClass('d-none') },
        complete: function () { $('#modalLoading').addClass('d-none') },
        success: displayCount,
        error: errorCount
    })
})

// JSON object
function getTicketFields() {
    var request = {
        RouteCategoryId: $('#RouteCategoryId').val(),
        ProgramId: $('#ProgramId').val(),
        RequestTypeId: $('#RequestTypeId').val(),
        CommunicationTypeId: $('#CommunicationTypeId').val(),
        ReferredFrom: $('#ReferredFrom').val(),
        Bureau: $('#Bureau').val(),
        Email: $('#Email').val(),
        PhoneNumber: $('#PhoneNumber').val(),
        StreetNumber: $('#StreetNumber').val(),
        StreetName: $('#StreetName').val(),
        City: $('#City').val(),
        CountyId: $('#CountyId').val(),
        State: $('#State').val(),
        StatusId: $('#StatusId').val(),
        StartDate: $('#startDatePicker').val(),
        EndDate: $('#endDatePicker').val(),
        TrackingNumber: $('#TrackingNumber').val(),
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        Affiliation: $('#Affiliation').val(),
        UserName: $('#CreatedBy_UserName').val()        
    };

    if (request.StartDate === "") request.StartDate = null;

    if (request.EndDate === "") request.EndDate = null;

    return request;
}

function ticketAJAX() {          

    $.ajax({
        url: '/API/TicketAPI/Tickets',
        type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        data: getTicketFields(),
        beforeSend: function () { $('#loading').removeClass('d-none'); },
        complete: function () { $('#loading').addClass('d-none') },
        success: ticketTable,
        error: errorCount
    })
}

function ticketTable(response) {
    $('#pError').html("");

    if (response.length >= 2000) {
        $('#warningModal').modal('show');
        $('#warningModal').draggable();
    }

    $('#Table').DataTable({
        destroy: true,
        data: response,
        columns: [
            {
                title: 'Link',
                data: 'TicketId',
                width: '10%',
                className: 'text-center',
                render: function (data, type, ticket) {
                    return '<a href="/Ticket/Details/'
                        + data + '?fromIndex=true" class="btn btn-outline-primary" target="_blank">'
                        + data + '</a>'
                }
            },
            {
                title: 'Routing Category',
                data: 'RoutingCategory',
                width: '20%',
                className: 'align-center text-center'
            },
            {
                title: 'Program',
                data: 'Program',
                width: '15%',
                className: 'd-none d-sm-table-cell align-center text-center'
            },
            {
                title: 'Date',
                data: 'DisplayDate',
                type: 'date',
                width: '10%',
                className: 'd-none d-lg-table-cell align-center text-center'
            },
            {
                title: 'Request Type',
                data: 'RequestType',
                width: '20%',
                className: 'd-none d-lg-table-cell align-center text-center'
            },
            {
                title: 'Caller Name',
                data: 'ContactName',
                width: '20%',
                className: 'd-none d-lg-table-cell align-center text-center'
            },
            {
                title: 'County',
                data: 'County',
                width: '5%',
                className: 'd-none d-lg-table-cell align-center text-center'
            },
            {
                title: 'Status',
                data: 'Status',
                width: '10%',
                className: 'align-center text-center font-weight-bold',
                render: function (data) {
                    if (data === 'Complete') return '<p class="text-success">Complete</p>';
                    else if (data === 'Disabled') return '<p class="text-danger">Disabled</p>';
                    else return '<p class="text-warning">Pending</p>';
                }
            }
        ],
        order: [3, 'desc']
    });

    $('#ajaxError').remove();
}

function displayCount(response) {
    $('#amount').html('Based on your search criteria there are a total number of ' + response + ' tickets');
    $('#amount').addClass('remove-class');
}

function errorCount() {
    $('#amount').html('Error: something didn\'t work right');
    $('#amount').addClass('text-danger');
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
    } else if (input == 'Enter') {
        event.preventDefault();
        ticketAJAX();
    }
}

function nameInput(event) {    
    
    if (event.key == 'Enter') {

        event.preventDefault();
        ticketAJAX();
    }
}

$('#PhoneNumber').keypress(function (event) {
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
        || input == '-'
        || input == 'End'
        || input == 'Home')) {
        event.preventDefault();
    }
})