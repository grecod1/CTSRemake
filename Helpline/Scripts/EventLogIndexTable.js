
$('#GetData').click(GetData);

var table = $('#Table');

$(document).ajaxStart(function () {
    $('#loading').removeClass('d-none');
})

$(document).ajaxComplete(function () {
    $('#loading').addClass('d-none')
})

$('#UserName, #TicketTrackingNumber').keypress(function (event) {
    var input = event.key;
    if (input === 'Enter') {
        GetData()
    }
})

function GetData() {
    var eventTypeId = $('#EventTypeId').val();
    var startDate = $('#startDatePicker').val();
    var endDate = $('#endDatePicker').val();
    var userName = $('#UserName').val();
    var trackingNumber = $('#TicketTrackingNumber').val();

    if (startDate === "") {
        startDate = null;
    }
    if (endDate === "") {
        endDate = null;
    }

    $.ajax({
        url: '/EventLog/GetEventLogData/?eventTypeId=' + eventTypeId + '&startDate=' +
            startDate + '&endDate=' + endDate + '&userName=' + userName + '&trackingNumber=' + trackingNumber,
        Type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        success: successFunction,
        error: function () {
            table.html('<p id="ajaxError">Something isn\'t right</p>');
        }
    })
}

function successFunction(results) {
    if ($.fn.dataTable.isDataTable('#Table')) {
        table.DataTable({
            destroy: true,
            data: results,
            columns: [
                { title: 'Event Date', data: 'Time', type: 'date', width:'25%', className: 'text-center' },
                { title: 'Event Type', data: 'EventType', width: '10%', className: 'text-center' },
                { title: 'Email', data: 'Email', width: '25%', className: 'text-center d-none d-lg-table-cell'},
                { title: 'User', data: 'UserName', width: '20%', className: 'text-center' },
                { title: 'Ticket Number', data: 'TrackingNumber', width: '10%', className: 'text-center d-none d-sm-table-cell' }
            ],
            order: [0, 'desc']
        })
    }
    else {
        table.DataTable({
            destroy: true,
            data: results,
            columns: [
                { title: 'Event Date', data: 'Time', type: 'date', width: '25%', className: 'text-center' },
                { title: 'Event Type', data: 'EventType', width: '10%', className: 'text-center' },
                { title: 'Email', data: 'Email', width: '25%', className: 'text-center d-none d-lg-table-cell' },
                { title: 'User', data: 'UserName', width: '20%', className: 'text-center' },
                { title: 'Ticket Number', data: 'TrackingNumber', width: '10%', className: 'text-center d-none d-sm-table-cell' }
            ],
            order: [0, 'desc']
        })
    }
    $('#ajaxError').remove();
}