
var table = $('#table');
$('#GetData').click(GetData);

function GetData() {    
    $.ajax({
        url: '/Administrator/ProgramData/?status=' + $('#Status').val(),
        type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        success: successFunction,
        error: function () {
            console.log('Something isn\'t right');
            $('#TableError').html('Something isn\'t right')
        }
    })
}

function successFunction(result) {
    if ($.fn.dataTable.isDataTable('#table')) {
        table.DataTable({
            destroy: true,
            data: result,
            columns: [
                {
                    title: 'Action', className:'text-center', data: 'ProgramId',
                    render: function (data, type, ticket) {
                        return '<a href="/Administrator/Program/' + data + '?newEntry=false" class="btn btn-outline-primary">Edit</a>';
                    }
                },
                { title: 'Program Name', className: 'text-center', data: 'Name'  },
                { title: 'Abbreviation', data: 'Abbreviation', className: 'd-none text-center d-lg-table-cell' },
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
            data: result,
            columns: [
                {
                    title: 'Action', data: 'Id', className: 'text-center',
                    render: function (data, type, ticket) {
                        return '<a href="/Administrator/Program/' + data + '?newEntry=false" class="btn btn-outline-primary">Edit</a>';
                    }
                },
                { title: 'Name', className: 'text-center', data: 'Name' }, 
                { title: 'Abbreviation', data: 'Abbreviation', className: 'd-none text-center d-lg-table-cell' },
                {
                    title: 'Status', data: 'Status', className: 'text-center font-weight-bold',
                    render: function (data) {
                        return '<p class = "' + data.StatusClass + '">' + data.StatusName + '</p>'
                    }
                }
            ]                                
        })
    } 
}

