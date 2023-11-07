$('#IsPOBox').click(function () {
    var checkbox = $('#IsPOBox');
    if (checkbox.is(':checked')) {
        $('#MailingPOBoxAddress').fadeIn();
        $('#MailingStreetAddress').fadeOut();
        $('#PhysicalSameAsMailingAddress').prop('checked', false);
        $('#PhysicalSameAsMailingAddress').attr('disabled', true);        
        $('.PhysicalAddress').attr('readonly', false);
        $('.PhysicalAddressDD').attr('disabled', false);
    } else {
        $('#MailingPOBoxAddress').fadeOut();
        $('#MailingStreetAddress').fadeIn();
        $('#PhysicalSameAsMailingAddress').attr('disabled', false);
    }
});