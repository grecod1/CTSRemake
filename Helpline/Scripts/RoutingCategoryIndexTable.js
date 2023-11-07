
var table = $('#table');
$('#GetData').click(GetData);
$('#StatusId').change(GetData);
function GetData() {    
    $.ajax({
        url: '/Administrator/RoutingCategoryData/?status=' + $('#Status').val(),
        method: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        success: successFunction,
        error: function () {
            $('#TableError').html('Something isn\'t right')
        }
    })
}

function successFunction(results) {

    $('#table').DataTable({
        destroy: true,
        data: results,
        columns: [
            {
                title: 'Action', data: 'Id',
                render: function (data) {
                    return '<a href="/Administrator/RoutingCategory/' + data + '?newEntry=false" class="btn btn-outline-primary">Edit</a>'
                }
            },
            { title: 'Routing Category Name', data: 'Name' },
            {
                title: 'Status', data: 'Status', className:'font-weight-bold',
                render: function (data) {
                    return '<p class = "' + data.StatusClass + '">' + data.StatusName + '</p>';
                }
            }
        ]
    })

    
}