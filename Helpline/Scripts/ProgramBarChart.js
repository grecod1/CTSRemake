$('#btnPrint').click(function () {
    window.print();
})

let Flag = 0;

var ProBarChar = "";

$('#btnProgramBarChar').click(function () {
    if ($('#StartDate_TotalPrograms').val() == null || $('#StartDate_TotalPrograms').val() == '') {
        event.preventDefault()
        $('#StartDate_TotalPrograms').addClass('is-invalid');
        $('#totalProgramsError').html('You must select a start date to get this chart');
    } else {
        $('#totalProgramsError').html('');
        $('#StartDate_TotalPrograms').removeClass('is-invalid');

        var url = '/Administrator/BarChartData?startDate='
            + $('#StartDate_TotalPrograms').val()
            + '&endDate=' + $('#EndDate_TotalPrograms').val();
        $.ajax({
            beforeSend: function () {
                $('#divBarChartLoading').removeClass('d-none');
            },
            complete: function () {
                $('#divBarChartLoading').addClass('d-none');
            },
            url: url,
            method: 'GET',
            async: true,
            dataType: 'JSON',
            success: DisplayProgramBarChart
        })
    }
})

function DisplayProgramBarChart(url) {

    var ctx = document.getElementById('barChartPrograms').getContext('2d');

    const labels = Array.from(url, x => x.Label);
    const values = Array.from(url, x => x.Value);

    if (Flag != 0) ProBarChar.destroy();

    ProBarChar = new Chart(ctx, {
        type: 'horizontalBar',
        data: {
            labels: labels,
            datasets: [
                {
                    data: values,
                    backgroundColor: "rgba(0, 56, 128, 0.2)",
                    borderColor: "rgba(0, 56, 128, 1)",
                    borderWidth: 1
                }
            ]
        },
        options: {
            elements: {
                bar: {
                    borderWidth: 2
                }
            },
            responsive: true,
            legend: {
                display: false
            },
            scales: {
                yAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: 'Name of Program'
                    }
                }],
                xAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: 'Number of Tickets'
                    },
                    ticks: {
                        beginAtZero: true,
                        suggestedMax: 100
                    }
                }]
            }
        }
    });

    Flag = 1;
}


