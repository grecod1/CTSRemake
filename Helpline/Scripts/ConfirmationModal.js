
$('#btnCreate').click(function () {
    $('#modal').modal('show');
    $('#modal').draggable();
    $('#modal strong.text-danger').html('');
    $('button.btn-danger').addClass('btn-secondary').removeClass('btn-danger');
    assignValues();
})

$('form').on('invalid-form', function () {
    $('#modal strong.text-danger').html('Please go back to the form by clicking on the red button.');    
    $('#modal button.btn-secondary').addClass('btn-danger').removeClass('btn-secondary');    
})

function assignValues() {
    $('#resultsCommunicationType').html(getDropDownListValue('#CommunicationTypeId'));
    $('#resultsRequestType').html(getDropDownListValue('#RequestTypeId'));
    $('#resultsRoutingCategory').html(getDropDownListValue('#RouteCategoryId'));
    $('#resultsProgram').html(getDropDownListValue('#ProgramId'));

    if ($('#FirstName').val() === ''
        && $('#LastName').val() === ''
        && $('#Email').val() === '') {
        $('#modalSectionNameAndEmail').addClass('d-none');
    } else {
        $('#modalSectionNameAndEmail').removeClass('d-none');

        if ($('#FirstName').val() != '') {
            $('#listGroupItemFirstName').removeClass('d-none');
            $('#resultsFirstName').html($('#FirstName').val());            
        } else {
            $('#listGroupItemFirstName').addClass('d-none');
        }

        if ($('#LastName').val() != '') {
            $('#listGroupItemLastName').removeClass('d-none');
            $('#resultsLastName').html($('#LastName').val());
        } else {
            $('#listGroupItemLastName').addClass('d-none');
        }

        if ($('#Email').val() != '') {
            $('#listGroupItemEmail').removeClass('d-none');
            $('#resultsEmail').html($('#Email').val());
        } else {
            $('#listGroupItemEmail').addClass('d-none');
        }
    }
    

    if ($('#TicketImage').val().endsWith('jpg')
        || $('#TicketImage').val().endsWith('png') 
        || $('#TicketImage').val().endsWith('jpeg')) {
        $('#pImageError').html('')
            $('#alertImageError').addClass('d-none');
        $('#modalSectionImage').removeClass('d-none');
    } else if ($('#TicketImage').val() != '') {
        $('#modalSectionImage').removeClass('d-none');
        $('#alertImageError').removeClass('d-none');
    }
    else {
        $('#modalSectionImage').addClass('d-none');
    }

    var phoneNumbers = getPhoneList();

    if (phoneNumbers.length <= 0) {
        $('#modalSectionPhoneNumbers').addClass('d-none');
    } else {
        $('#modalSectionPhoneNumbers').removeClass('d-none');
        $('#modalSectionPhoneNumbers ul').html('');
        $.each(phoneNumbers, function (index, value) {
            if (index === phoneNumbers.length - 1) {
                $('#modalSectionPhoneNumbers ul').append('<li class="list-group-item border-bottom border-primary"> <strong>Type: </strong> '
                    + value.Type + ' <strong class="ml-2">Number: </strong>'
                    + value.Number + '</li>');
            } else {
                $('#modalSectionPhoneNumbers ul').append('<li class="list-group-item"> <strong>Type: </strong> '
                    + value.Type + ' <strong class="ml-2">Number: </strong>'
                    + value.Number + '</li>');
            }            
        })
    }

    if ($('#AddressInvolved').val() === 'true') {
        $('#modalSectionAddress').removeClass('d-none');

        if ($('#IsPOBox').is(':checked')) {
            $('#resultsMailingAddressFirstLine').html('PO Box # ' + $('#MailingAddress_POBox').val())
        } else {
            $('#resultsMailingAddressFirstLine').html($('#MailingAddress_StreetNumber').val() + '  '
                + $('#MailingAddress_StreetName').val());
            if ($('#MailingAddress_AptNumber').val() != '') {
                $('#resultsMailingAddressFirstLine').append(' #' + $('#MailingAddress_AptNumber').val());
            }
        }
        
        $('#resultsMailingAddressSecondLine').html($('#MailingAddress_City').val() + '  '
            + $('#MailingAddress_State').val() + '  '
            + $('#MailingAddress_Zip').val());

        var countyName = 'No County'

        if (getDropDownListValue('#MailingAddress_CountyId') != 'NONE') {
            countyName = getDropDownListValue('#MailingAddress_CountyId');
        }

        $('#resultsMailingAddressSecondLine').append(' ' + countyName);

        $('#resultsPhysicalAddressFirstLine').html($('#PhysicalAddress_StreetNumber').val() + '  '
            + $('#PhysicalAddress_StreetName').val());

        if ($('#PhysicalAddress_AptNumber').val() != '') {
            $('#resultsPhysicalAddressFirstLine').append(' #' + $('#PhysicalAddress_AptNumber').val());
        }

        $('#resultsPhysicalAddressSecondLine').html($('#PhysicalAddress_City').val() + ' '
            + $('#PhysicalAddress_State').val() + ' ' + $('#PhysicalAddress_Zip').val());

        if (getDropDownListValue('#PhysicalAddress_CountyId') != 'NONE') {
            countyName = getDropDownListValue('#PhysicalAddress_CountyId');
        } else {
            countyName = 'No County';
        }

        $('#resultsPhysicalAddressSecondLine').append(' ' + countyName);
    } else {
        $('#modalSectionAddress').addClass('d-none');
    }

    if ($('#CallerRemarks').val() != '') {
        $('#resultsCallReason').html('<h4>Reason for Call</h4><p>'
            + $('#CallerRemarks').val() + '</p>');
    } else {
        $('#resultsCallReason').html('<h4>Reason for Call</h4><p class="text-danger">Requires input</p>');
    }

    if ($('#Resolution').val() != '') {
        $('#resultsResolution').html('<h4>Resolution</h4><p>'
            + $('#Resolution').val() + '</p>');
    } else {
        $('#resultsResolution').html('');
    }

    if ($('#Comments').val() != '') {
        $('#resultsNotes').html('<h4>Notes</h4><p>'
            + $('#Comments').val() + '</p>');
    } else {
        $('#resultsNotes').html('');
    }
}

function getDropDownListValue(dropDownListId) {
    var displayValue = '';
    $(dropDownListId).children('option').each(function (index, element) {
        if ($(dropDownListId).val() === $(this).attr('value')) {
            displayValue = $(this).html();
        }
    });

    if ($(dropDownListId).val() === '') {
        var displayValue = '<span class="text-danger">Must Select Value</span>';
    }

    return displayValue;
}

function getPhoneList() {
    var phoneNumbers = [];
    $('#phoneTable tr').each(function (index, element) {      
        var phoneNumber = {
            Number: $(this).find('.PhoneNumberListItem').val(),
            Type: $(this).find('.tdPhoneNumber+td.w-25').text().trim()
        };
        phoneNumbers.push(phoneNumber);
    })

    return phoneNumbers;
}