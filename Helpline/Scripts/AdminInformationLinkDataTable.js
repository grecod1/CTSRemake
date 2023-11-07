
var table = $('#table');

$('#StatusId').change(getData);
$('#GetData').click(getData);

$(document).ajaxStart(function () {
    $('#loading').removeClass('d-none');
})

$(document).ajaxComplete(function () {
    $('#loading').addClass('d-none')
})


function getData() {
    var statusId = $('#StatusId').val();
    $.ajax({
        url: '/Administrator/InformationLinkData/?statusNumber=' + statusId,
        type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        success: successFunction,
        error: function () {
            $('#TableError').html('Something isn\'t right');
        }
    })
}

function successFunction(results) {        
    console.log(results);    

    if ($.fn.dataTable.isDataTable('#table')) {
        table.DataTable({
            destroy: true,
            data: results,
            columns: [
                {
                    title: 'Action', data: 'InformationLinkId',
                    render: function (data) {
                        return '<a href="/Administrator/InformationLink/' + data + '?newEntry=false" class = "btn btn-primary">Edit</a>';
                    }
                },
                { title: 'Name', data: 'InformationLinkName' },
                {
                    title: 'URL Address', data: 'InformationLinkURL',
                    render: function (data) {
                        return '<a href="' + data + '" class="text-primary">' + data + '</a>'
                    }
                },
                {
                    title: 'Status', data: 'Status',
                    render: function (data) {
                        return '<p class = "' + data.StatusClass + '">' + data.StatusName + '</p>';
                    }
                }
            ]            
        });
    }
    else {
        table.DataTable({            
            destroy: true,
            data: results,
            columns: [
                {
                    title: 'Action', data: 'InformationLinkId',
                    render: function (data) {
                        return '<a href="/Administrator/InformationLink/' + data + '?newEntry=false" class = "btn btn-primary">Edit</a>';
                    }
                },
                { title: 'Name', data: 'InformationLinkName' },
                {
                    title: 'URL Address', data: 'InformationLinkURL',
                    render: function (data) {
                        return '<a href="' + data + '" class="text-primary">' + data + '</a>'
                    }
                },
                {
                    title: 'Status', data: 'Status',
                    render: function (data) {
                        return '<p class = "' + data.StatusClass + '">' + data.StatusName + '</p>';
                    }
                }
            ]            
        });
    }
}