$('#btnExcel, #btnExcelMobile').click(function () {    

    var routeCategoryId = $('#RouteCategoryId').val() != '' ? $('#RouteCategoryId').val() : 0;
    var programId = $('#ProgramId').val() != '' ? $('#ProgramId').val() : 0;
    var requestTypeId = $('#RequestTypeId').val() != '' ? $('#RequestTypeId').val()  : 0;
    var communicationTypeId = $('#CommunicationTypeId').val() != '' ? $('#CommunicationTypeId').val() : 0;
    var phoneNumber = $('#PhoneNumber').val();
    var streetNumber = $('#StreetNumber').val();
    var streetName = $('#StreetName').val();
    var city = $('#City').val();
    var countyId = $('#CountyId').val() != '' ? $('#CountyId').val(): 0;
    var state = $('#State').val();
    var statusId = $('#StatusId').val() != '' ? $('#StatusId').val() : 0;
    var startDate = $('#startDatePicker').val();
    var endDate = $('#endDatePicker').val();
    var trackingNumber = $('#TrackingNumber').val();
    var firstName = $('#FirstName').val();
    var lastName = $('#LastName').val();
    var userName = $('#CreatedBy_UserName').val();
    var affiliation = $('#Affiliation').val();
    var referredFrom = $('#ReferredFrom').val();
    var bureau = $('#Bureau').val();
    
    var serverString = createServerString();

    serverString = serverString + 'TicketIndex&TrackingNumber=' + trackingNumber
        + '&StartDateRange=' + startDate
        + '&EndDateRange=' + endDate
        + '&CreatedBy_UserName=' + userName
        + '&FirstName=' + firstName
        + '&LastName=' + lastName
        + '&RequestTypeId=' + requestTypeId
        + '&CommunicationTypeId=' + communicationTypeId
        + '&RouteCategoryId=' + routeCategoryId
        + '&ProgramId=' + programId
        + '&StatusId=' + statusId
        + '&PhoneNumber=' + phoneNumber
        + '&StreetNumber=' + streetNumber
        + '&StreetName=' + streetName
        + '&City=' + city
        + '&CountyId=' + countyId
        + '&State=' + state
        + '&Affiliation=' + affiliation
        + '&Bureau=' + bureau
        + '&ReferredFrom=' + referredFrom
        + '&rs:Command=Render&rs:format=excel';
   
    $('#btnExcel').attr('href', serverString);
})


function createServerString() {

    var reportServer = ' http://tlhsql12/ReportServer?%2fDPI%2fHelpLine%2fReports%2f';
    
    var url = document.URL;
    if (url.indexOf('helplinedev') != -1 || url.indexOf('localhost') != -1) {
        reportServer = 'http://tlhsql12dev/ReportServer_DPI/Pages/ReportViewer.aspx?%2fHelpLineDB%2fReports%2f';
    }
    else if (url.indexOf('helplinetest') != -1) {
        reportServer = 'http://tlhsql12test/ReportServer/Pages/ReportViewer.aspx?%2fDPI%2fHelpLine%2fReports%2f';
    }

    return reportServer;
}