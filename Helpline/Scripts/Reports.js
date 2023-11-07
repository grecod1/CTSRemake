


$('#pdfTotalReports').click(function (event) {
    var rServer = createServerString();
    if ($('#StartDate_TotalPrograms').val() == null || $('#StartDate_TotalPrograms').val() == '') {
        event.preventDefault()
        $('#StartDate_TotalPrograms').addClass('is-invalid');
        $('#totalProgramsError').html('You must select a start date to get this report');
        $('#pdfTotalReports').attr('href', '#');
    }   else {
        var urlString = '';
        if ($('#EndDate_TotalPrograms').val() == null || $('#EndDate_TotalPrograms').val() == '') {
            urlString = rServer + 'ProgramCount&StartDate=' + $('#StartDate_TotalPrograms').val()
                + '&rs:Command=Render&rs:format=pdf';

        }
        else {

            var endDateString = $('#EndDate_TotalPrograms').val();
            urlString = rServer + 'ProgramCount&StartDate=' + $('#StartDate_TotalPrograms').val()
                + '&EndDate=' + endDateString
                + '&rs:Command=Render&rs:format=pdf';
        }
        $('#pdfTotalReports').attr('href', urlString);
    }
})

$('#excelTotalReports').click(function (event) {
    var rServer = createServerString();
    if ($('#StartDate_TotalPrograms').val() == null || $('#StartDate_TotalPrograms').val() == '') {
        event.preventDefault()
        programReportError();
    }   else {
        if ($('#EndDate_TotalPrograms').val() == null || $('#EndDate_TotalPrograms').val() == '') {
            var urlString = rServer + 'ProgramCount&StartDate=' + $('#StartDate_TotalPrograms').val()
                + '&rs:Command=Render&rs:format=excel';
        }
        else {

            var endDateString = $('#EndDate_TotalPrograms').val();
            var urlString = rServer + 'ProgramCount&StartDate=' + $('#StartDate_TotalPrograms').val()
                + '&EndDate=' + endDateString
                + '&rs:Command=Render&rs:format=excel';
        }
        $('#excelTotalReports').attr('href', urlString);
    }
})

$('#pdfProgramGraph, #excelProgramGraph').click(function (event) {
    
    var rServer = createServerString();    
    if ($('#StartDate_SelectedProgram').val() == '' && $('#ProgramId').val() == '') {
        event.preventDefault();
        $('#StartDate_SelectedProgram').addClass('is-invalid');
        $('#selectedProgramsErrorDate').html('You must select a start date to get this report');

        $('#ProgramId').addClass('is-invalid');
        $('#selectedProgramsErrorId').html('You must select a Program to get this report');
    }
    else if ($('#ProgramId').val() == '') {
        event.preventDefault();
        $('#ProgramId').addClass('is-invalid');
        $('#selectedProgramsErrorId').html('You must select a Program to get this report');
    }
    else if ($('#StartDate_SelectedProgram').val() == '') {
        event.preventDefault();
        $('#StartDate_SelectedProgram').addClass('is-invalid');
        $('#selectedProgramsErrorDate').html('You must select a start date to get this report');
    }
    else {
        var urlString = '';
        var todayNumeric = Date.now();
        var today = new Date();
        var todayString = today.toLocaleDateString();
        var endDateURL = '&EndDate=' + todayString;
        if ($('#EndDate_SelectedProgram').val() != '') {
            endDateURL = '&EndDate=' + $('#EndDate_SelectedProgram').val();
        }
        var routingCategoryURL = '&RoutingCategoryId=0';
        if ($('#RoutingCategoryId').val() != '') {
            routingCategoryURL = '&RoutingCategoryId=' + $('#RoutingCategoryId').val();
        }
        var requestTypeURL = '&RequestTypeId=0';
        if ($('#RequestTypeId').val() != '') {
            requestTypeURL = '&RequestTypeId=' + $('#RequestTypeId').val();
        }
        var communicationTypeURL = '&CommunicationTypeId=0';
        if ($('#CommunicationTypeId').val() != '') {
            communicationTypeURL = '&CommunicationTypeId=' + $('#CommunicationTypeId').val();
        }
        var countyURL = '&CountyId=0';
        if ($('#CountyId').val() != '') {
            countyURL = '&CountyId=' + $('#CountyId').val();
        }
        var cityURL = '&City=';
        if ($('#City').val() != '') {
            cityURL = '&City=' + $('#City').val();
        }
        var streetNameURL = '&StreetName=';
        if ($('#StreetName').val() != '') {
            streetNameURL = '&StreetName=' + $('#StreetName').val();
        }

        var reportString = '';
        var documentType = '';
        if ($(this).attr('id') === 'excelProgramGraph') {
            reportString = 'ProgramMatrix';
            documentType = 'excel';
        } else {
            reportString = 'ProgramChart';
            documentType = 'pdf';
        }

        urlString = rServer + reportString + '&ProgramId=' + $('#ProgramId').val()
            + '&StartDate=' + $('#StartDate_SelectedProgram').val() + endDateURL
            + routingCategoryURL + requestTypeURL + communicationTypeURL
            + countyURL + cityURL + streetNameURL + '&rs:Command=Render&rs:format=' + documentType;

        $(this).attr('href', urlString);

    }
})

$('#StartDate_TotalPrograms').change(function () {
    $('#StartDate_TotalPrograms').removeClass('is-invalid');
    $('#totalProgramsError').html('');
})

$('#ProgramId').change(function () {
    $('#ProgramId').removeClass('is-invalid');
    $('#selectedProgramsErrorId').html('');
})

$('#StartDate_SelectedProgram').change(function () {
    $('#StartDate_SelectedProgram').removeClass('is-invalid');
    $('#selectedProgramsErrorDate').html('');
})

$('#StartDate_CountyProgram').change(function () {
    $('#StartDate_CountyProgram').removeClass('is-invalid');
    $('#countyProgramError').html('')

})


function createServerString() {
    var reportServer = 'http://tlhsql12/ReportServer/Pages/ReportViewer.aspx?%2fDPI%2fHelpLine%2fReports%2f';
    var url = document.URL;
    if (url.indexOf('helplinedev') != -1) {
        reportServer = 'http://tlhsql12dev/ReportServer_DPI/Pages/ReportViewer.aspx?%2fHelpLineDB%2fReports%2f';
    }
    else if (url.indexOf('helplinetest') != -1) {
        reportServer = 'http://tlhsql12test/ReportServer/Pages/ReportViewer.aspx?%2fDPI%2fHelpLine%2fReports%2f';
    }

    return reportServer;
}
