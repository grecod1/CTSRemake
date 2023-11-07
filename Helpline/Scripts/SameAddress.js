$('#PhysicalSameAsMailingAddress').on("click", function () {
    var checkbox =  $('#PhysicalSameAsMailingAddress');        
    if (checkbox.prop('checked')) {        
            $('.PhysicalAddress').attr('readonly', true);
            $('.PhysicalAddressDD').attr('disabled', true);
            $('.PhysicalAddress').removeClass('is-invalid');
            $('.PhysicalAddress ~ span.field-validation-error > span.is-invalid').html("");

            $('#PhysicalAddress_StreetNumber').val($('#MailingAddress_StreetNumber').val());            
            $('#PhysicalAddress_Direction').val($('#MailingAddress_Direction').val());
            $('#PhysicalAddress_StreetName').val($('#MailingAddress_StreetName').val());
            $('#PhysicalAddress_AptNumber').val($('#MailingAddress_AptNumber').val());
            $('#PhysicalAddress_City').val($('#MailingAddress_City').val());
            $('#PhysicalAddress_State').val($('#MailingAddress_State').val());
            $('#PhysicalAddress_Zip').val($('#MailingAddress_Zip').val());
            $('#PhysicalAddress_CountyId').val($('#MailingAddress_CountyId').val());           
            $('#PhysicalAddress_CountyId').val($('#MailingAddress_CountyId').val());           
        }
        else {
            $('.PhysicalAddress').attr('readonly', false);
            $('.PhysicalAddressDD').attr('disabled', false);
        }            
});

$('#MailingAddress_StreetNumber').on('change', function () {    
    if ($('#PhysicalSameAsMailingAddress').prop('checked')) {
        $('#PhysicalAddress_StreetNumber').val($('#MailingAddress_StreetNumber').val());        
    }
});

$('#MailingAddress_Direction').on('change', function () {
    if ($('#PhysicalSameAsMailingAddress').prop('checked')) {
        $('#PhysicalAddress_Direction').val($('#MailingAddress_Direction').val());
    }
});

$('#MailingAddress_StreetName').on('change', function () {
    if ($('#PhysicalSameAsMailingAddress').prop('checked')) {
        $('#PhysicalAddress_StreetName').val($('#MailingAddress_StreetName').val());
    }
});

$('#MailingAddress_AptNumber').on('change', function () {
    if ($('#PhysicalSameAsMailingAddress').prop('checked')) {
        $('#PhysicalAddress_AptNumber').val($('#MailingAddress_AptNumber').val());
    }
});

$('#MailingAddress_City').on('change', function () {
    if ($('#PhysicalSameAsMailingAddress').prop('checked')) {
        $('#PhysicalAddress_City').val($('#MailingAddress_City').val());
    }
});

$('#MailingAddress_State').on('change', function () {
    if ($('#PhysicalSameAsMailingAddress').prop('checked')) {        
        $('#PhysicalAddress_State').val($('#MailingAddress_State').val());
    }
});

$('#MailingAddress_Zip').on('change', function () {
    if ($('#PhysicalSameAsMailingAddress').prop('checked')) {
        $('#PhysicalAddress_Zip').val($('#MailingAddress_Zip').val());
    }
});

$('#MailingAddress_CountyId').on('change', function () {
    if ($('#PhysicalSameAsMailingAddress').prop('checked')) {
        $('#PhysicalAddress_CountyId').val($('#MailingAddress_CountyId').val());
    }
});

