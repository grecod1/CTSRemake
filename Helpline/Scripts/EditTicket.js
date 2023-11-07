
$(document).ready(function () {    
    var checkbox = $('#IsPOBox');
    $('#CallerRemarks').val('blank');
    if (checkbox.is(':checked')) {
        $('#MailingStreetAddress').fadeOut();
        $('#MailingPOBoxAddress').fadeIn();
        $('#PhysicalSameAsMailingAddress').prop('checked', false);
        $('#PhysicalSameAsMailingAddress').attr('disabled', true);
    } else {
        $('#PhysicalSameAsMailingAddress').attr('disabled', false);
    }
})

$('#StatusId').on('change', function () {
    if ($(this).val() == 2) {
        $('#editTicket .form-control').attr('disabled', 'true');
        $('.alert-success').removeClass('d-none');
        $('.alert-success').fadeOut(10000);
    } else {
        $('#editTicket .form-control').removeAttr('disabled');
        $('.alert-success').addClass('d-none');
    }
});

$('#EditOption').on('change', function () {
    $('.hideable').fadeOut();

    switch ($('#EditOption').val()) {
        case 'Edit Ticket Information': {
            $('#pnlCallInfo').fadeIn();
            break;
        } case 'Edit Routing Information': {
            $('#pnlRoute').fadeIn();
            break;
        } case 'Edit Ticket, Routing Information, or Status': {
            $('#pnlCallInfo').fadeIn();
            $('#pnlRoute').fadeIn();
            $('#pnlTicketStatus').fadeIn();
            break;
        } case 'Change the Ticket Status': {
            $('#pnlTicketStatus').fadeIn();
            break;
        }
    }
});

$('#ddCallerComments').on('change', function () {
    var option = $('#ddCallerComments').val();
    console.log(option);
    if (option == 'Yes') {
        $('#pnlCallerComments').removeClass('d-none');
        $('#CallerRemarks').val('');
    } else {
        $('#pnlCallerComments').addClass('d-none');
        $('#CallerRemarks').val('blank');
    }
});

