
let graphFlag = 0;

var ProLineGraph = "";

$('#btnProgramLineGrap').click(function () {

    var request = {
        programId: $('#ProgramId').val(),
        startDate: $('#StartDate_SelectedProgram').val(),
        endDate: $('#EndDate_SelectedProgram').val(),
        routingCategoryId: $('#RoutingCategoryId').val(),
        requestTypeId: $('#RequestTypeId').val(),
        communicationTypeId: $('#CommunicationTypeId').val(),
        countyId: $('#CountyId').val(),
        city: $('#City').val(),
        streetName: $('#StreetName').val()
    };

    var url = '/Administrator/LineChartData?programId=' + request.programId +
        '&startDate=' + request.startDate +
        '&endDate=' + request.endDate +
        '&routingCategoryId=' + request.routingCategoryId +
        '&requestTypeI=' + request.requestTypeId +
        '&communicationTypeId=' + request.communicationTypeId +
        '&countyId=' + request.countyId +
        '&city=' + request.city +
        '&streetName=' + request.streetName;

    $.ajax({
        beforeSend: function () {
            $('#divLineChartLoading').removeClass('d-none');
        },
        complete: function () {
            $('#divLineChartLoading').addClass('d-none');
        },
        url: url,
        method: 'GET',
        async: true,
        data: request,
        dataType: 'JSON',
        success: DisplayProgramLineGraph
    })
})

function DisplayProgramLineGraph(url) {
    var ctx = document.getElementById('lineGraphPrograms').getContext('2d');

    const labels = Array.from(url, x => x.Label);
    const values = Array.from(url, x => x.Value);

    if (graphFlag != 0) ProLineGraph.destroy();

    ProLineGraph = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    data: values,
                    backgroundColor: 'rgba(0, 56, 128, 1)',
                    borderColor: 'rgba(0, 56, 128, 0.5)',
                    fill: false
                }
            ]
        },
        options: {
            legend: {
                display: false
            },
            responsive: true
        }
    })

    graphFlag = 1;
}