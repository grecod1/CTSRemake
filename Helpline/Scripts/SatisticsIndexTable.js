


$('#GetData').click(GetData);
$('#ProgramId, #DatePicker').change(GetData);

$(document).ajaxStart(function () {
    $('#loading').removeClass('d-none');
})

$(document).ajaxComplete(function () {
    $('#loading').addClass('d-none')
})

function GetData() {
    var table = $('#Table');
    var programId = $('#ProgramId').val();
    var date = $('#DatePicker').val();
    if (date === '') {
        date = null
    }

    $.ajax({
        url: '/Satistics/GetCountyProgramData/?date=' + date + '&programId=' + programId,
        type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        success: successFunction,
        error: function () {
            $('#Error').removeClass('d-none');
        }        
    });

    function successFunction(results) {
        var secondCol = $('#DatePicker').val();
        if (secondCol == Date.now() || secondCol == '') {
            secondCol = 'For Today'
        }
        else {
            secondCol = 'For ' + $('#DatePicker').val();
        }

        if ($.fn.dataTable.isDataTable('#Table')) {
            table.DataTable({
                destroy: true,
                data: results,
                autoWidth: false,
                pageLength: 100,
                columns: [
                    { title: 'County', data: 'CountyName' },
                    { title: secondCol, data: 'OneDayRequest', className:'text-center' },
                    { title: 'Total Days', data: 'TotalRequest', className: 'text-right' }
                ]
            })
        }
        else {
            table.DataTable({
                destroy: true,
                data: results,
                autoWidth: false,
                pageLength: 100,
                columns: [
                    { title: 'County', data: 'CountyName' },
                    { title: secondCol, data: 'OneDayRequest', className:'text-center' },
                    { title: 'Total Days', data: 'TotalRequest', className:'text-right' }
                ]
            })
        }
        $('#Error').addClass('d-none');
    }
}

