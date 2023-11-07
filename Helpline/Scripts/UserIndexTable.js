
var table = $('#table');
$('#GetData').click(GetData);
function GetData() {    
    $.ajax({
        url: '/User/GetUserData/?status=' + $('#Status').val(),
        type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        beforeSend: function () { $('#cogLoading').removeClass('d-none') },
        complete: function () { $('#cogLoading').addClass('d-none') },
        success: successFunction,
        error: function () {
            $('#TableError').html('Something isn\'t right');
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
                    title: 'Action', data: 'Id', className:'text-center',
                    render: function (data) {
                        return '<a href="/User/Edit/' + data +'?newEntry=false" class="btn btn-outline-primary">Edit</a>'
                    }                    
                },
                { title: 'User Name', data: 'UserName', className: 'text-center' },
                { title: 'Full Name', data: 'FullName', className:'d-none d-sm-table-cell text-center' },
                { title: 'User Role', data: 'Role', className: 'text-center' },
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
                        return '<a href="/User/Edit/' + data + '?newEntry=false" class="btn btn-outline-primary">Edit</a>'
                    }
                },
                { title: 'User Name', data: 'UserName', className: 'text-center' },
                { title: 'Full Name', data: 'FullName', className: 'd-none d-sm-table-cell text-center' },
                { title: 'User Role', data: 'Role', className: 'text-center' },
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