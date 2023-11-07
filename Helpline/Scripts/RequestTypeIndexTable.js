
var table = $('#table');
$('#GetData').click(GetData);
function GetData() {    
    $.ajax({
        url: '/Administrator/RequestTypeData/?status=' + $('#Status').val(),
        type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        success: successFunction,
        error: function () {
            $('#TableError').html('something isn\'t right')
        }
    })
}

function successFunction(results) {
    if ($.fn.dataTable.isDataTable('#table')) {
        table.DataTable({
            destroy: true,
            data: results,
            columns: [
                {
                    title: 'Action', data: 'RequestTypeId', className:'text-center',
                    render: function (data) {
                        return '<a href="/Administrator/RequestType/' + data + '?newEntry=false" class = "btn btn-outline-primary">Edit</a>';
                    }
                },
                { title: 'Request Type Name', data: 'Name', className: 'text-center'}, 
                {
                    title: 'Status', data: 'Status', className: 'text-center font-weight-bold',
                    render: function (data) {
                        return '<p class = "' + data.StatusClass + '">' + data.StatusName + '</p>';
                    }
                }
            ]
        })
    }
    else {
        table.DataTable({
            destroy: true,
            data: results,
            columns: [
                {
                    title: 'Action', data: 'Id', className: 'text-center',
                    render: function (data) {
                        return '<a href="/Administrator/RequestType/' + data + '?newEntry=false" class = "btn btn-outline-primary">Edit</a>';
                    }
                },
                { title: 'Request Type Name', data: 'Name', className: 'text-center' },
                {
                    title: 'Status', data: 'Status', className: 'text-center font-weight-bold',
                    render: function (data) {
                        return '<p class = "' + data.StatusClass + '">' + data.StatusName + '</p>';
                    }
                }
            ]
        })
    }    
}