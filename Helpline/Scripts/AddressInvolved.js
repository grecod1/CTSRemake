$('#AddressInvolved').on('change', function () {
    if ($(this).val() == 'true') {
        $('.AddressPanel').fadeIn();
    } else {
        $('.AddressPanel').each(function (index, element) {
            $(this).fadeOut();
        })
    }
})