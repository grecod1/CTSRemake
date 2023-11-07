var counter = 0;
var PhoneTypeId = $('#homePhoneID').val();

$('#btnAddPhone').click(function () {
    buttonAnimation(false);
    insertPhoneNumber();
});

$('#addPhoneNumber').on('click', function (event) {
    event.preventDefault();
});

$('#addPhoneNumber').on('keydown', function (event) {
    $('#addPhoneField  span.is-invalid').html('');
    var valid = numericInput(event);
    var value = $('#addPhoneNumber').val();
    var length = value.length;
    if (valid == false) {
        event.preventDefault();
    }
    if (event.key == 'Backspace') {
        buttonAnimation(false);
        event.preventDefault();
        $('#addPhoneNumber').val(value.substring(0, length - 1));
        value = $('#addPhoneNumber').val();
        switch (length) {
            case 5: {
                $('#addPhoneNumber').val(value.substring(0, 4));
                value = $('#addPhoneNumber').val();
                break;
            } case 9: {
                $('#addPhoneNumber').val(value.substring(0, 8));
                value = $('#addPhoneNumber').val();
                break;
            } case 18: {
                $('#addPhoneNumber').val(value.substring(0, 13));

                break;
            } case 19: {
                $('#addPhoneNumber').val(value.substring(0, 13));
                value = $('#addPhoneNumber').val();
                break;
            }
        }
    } else if (event.key == 'Enter') {
        switch (length) {
            case 12: {
                buttonAnimation(false);
                insertPhoneNumber();
                break;
            } case 13: {
                buttonAnimation(false);
                $('#addPhoneNumber').val(value.substring(0, 12));
                insertPhoneNumber();
                break;
            } case 19: {
                buttonAnimation(false);
                insertPhoneNumber();
                break;
            } case 20: {
                buttonAnimation(false);
                insertPhoneNumber();
                break;
            } case 21: {
                buttonAnimation(false);
                insertPhoneNumber();
                break;
            } case 22: {
                buttonAnimation(false);
                insertPhoneNumber();
                break;
            }
        }
    } else if (event.key == '0' || event.key == '1' || event.key == '2' || event.key == '3'
        || event.key == '4' || event.key == '5' || event.key == '6' || event.key == '7'
        || event.key == '8' || event.key == '9') {
        event.preventDefault();

        switch (length) {
            case 0: {
                $('#addPhoneNumber').val(value + event.key);
                value = $('#addPhoneNumber').val();
                break;
            } case 1: {
                $('#addPhoneNumber').val(value + event.key);
                value = $('#addPhoneNumber').val();
                break;
            } case 2: {
                $('#addPhoneNumber').val(value + event.key);
                value = $('#addPhoneNumber').val();
                break;
            } case 3: {
                $('#addPhoneNumber').val(value + '-' + event.key);
                value = $('#addPhoneNumber').val();
                break;
            } case 4: {
                $('#addPhoneNumber').val(value + event.key);
                value = $('#addPhoneNumber').val();
                break;
            } case 5: {
                $('#addPhoneNumber').val(value + event.key);
                value = $('#addPhoneNumber').val();
                break;
            } case 6: {
                $('#addPhoneNumber').val(value + event.key);
                value = $('#addPhoneNumber').val();
                break;
            } case 7: {
                $('#addPhoneNumber').val(value + '-' + event.key);
                value = $('#addPhoneNumber').val();
                break;
            } case 8: {
                $('#addPhoneNumber').val(value + event.key);
                value = $('#addPhoneNumber').val();
                break;
            } case 9: {
                $('#addPhoneNumber').val(value + event.key);
                value = $('#addPhoneNumber').val();
                break;
            } case 10: {
                $('#addPhoneNumber').val(value + event.key);
                value = $('#addPhoneNumber').val();
                break;
            } case 11: {
                $('#addPhoneNumber').val(value + event.key);
                value = $('#addPhoneNumber').val();
                buttonAnimation(true);
                break;
            } case 12: {
                if (PhoneTypeId == $('#workPhoneID').val()) {
                    $('#addPhoneNumber').val(value + '  ex: ' + event.key);
                    value = $('#addPhoneNumber').val();
                }
                break;
            } case 13: {
                $('#addPhoneNumber').val(value.substring(0, 12));
                value = $('#addPhoneNumber').val();
                if (PhoneTypeId == $('#workPhoneID').val()) {
                    $('#addPhoneNumber').val(value + '  ex: ' + event.key);
                    value = $('#addPhoneNumber').val();
                }
                break;
            } case 19: {
                if (PhoneTypeId = $('#workPhoneID').val()) {
                    $('#addPhoneNumber').val(value + event.key);
                    value = $('#addPhoneNumber').val();
                }
                break;
            } case 20: {
                if (PhoneTypeId = $('#workPhoneID').val()) {
                    $('#addPhoneNumber').val(value + event.key);
                    value = $('#addPhoneNumber').val();
                }
                break;
            } case 21: {
                if (PhoneTypeId = $('#workPhoneID').val()) {
                    $('#addPhoneNumber').val(value + event.key);
                    value = $('#addPhoneNumber').val();
                }
                break;
            }
        }
    }

});

$('#addPhoneNumber').on('paste', function (event) {
    var regex = /^([1-9]{3}(-){1}[1-9]{3}(-){1}[1-9]{4})$/;
    var content;
    var browser = determineBrowser();
    if (browser == 'IE') {
        content = window.clipboardData.getData('text');
    } else {
        console.log(event);
        content = event.originalEvent.clipboardData.getData('text/plain');
    }
    if (!content.match(regex)) {
        event.preventDefault();
    }
    buttonAnimation(true)
})

$('#slPhoneType a').on('click', function (event) {
    var value = $('#addPhoneNumber').val();
    var length = value.length;
    var select = $(this).html();
    switch (select) {
        case 'Home Phone   ': {
            PhoneTypeId = $('#homePhoneID').val();
            if (length > 13) {
                $('#addPhoneNumber').val(value.substring(0, 12));
            }
            break;
        } case 'Work Phone   ': {
            PhoneTypeId = $('#workPhoneID').val();
            break;
        } case 'Mobile Number   ': {
            PhoneTypeId = $('#mobilePhoneID').val();
            if (length > 13) {
                $('#addPhoneNumber').val(value.substring(0, 12));
            }
            break;
        }
    }
    event.preventDefault();
    $('#btnDropDown').html(select);
})


$('#phoneTable').on('click', '.BTNremove', function () {
    counter--;
    var row = $(this).parents('tr').remove();
    setNameProperties();
});


function insertPhoneNumber() {
    if (counter < 5) {
        var phoneInput = $('#addPhoneNumber').val();
        var regex = /^([0-9]{3}(-){1}[0-9]{3}(-){1}[0-9]{4}[\s]?)$/;
        var workRegex = /([0-9]{3}(-){1}[0-9]{3}(-){1}[0-9]{4}(  Ext: [0-9]{1,4})*)/
        if (phoneInput.match(regex) || PhoneTypeId == $('#workPhoneID').val() && phoneInput.match(workRegex)) {
            var sameNumber = false;
            $('td.tdPhoneNumber').each(function (index, element) {
                if (element.innerHTML.indexOf(phoneInput) != -1) {
                    sameNumber = true;
                }
            });
            if (sameNumber) {
                $('#modalPhone').modal('show');
                $('#modalPhone').draggable();
                $('#modalErrorMessage').html('You cannot add in the same phone number');
            } else {
                $('#AddPhoneRequired').html('');
                $('#addPhoneNumber').removeClass('input-validation-error');
                $('#phoneTable').append('<tr><td class="tdPhoneNumber w-50">' + phoneInput
                    + '<input type="hidden" class="PhoneNumberListItem" value="' + phoneInput
                    + '" data-val="true"></td><td class="w-25">' + $('#btnDropDown').html()
                    + '<input type="hidden" class="PhoneTypeListItem" value ="' + PhoneTypeId + '"></td>'
                    + '<td class="w-25 text-center"><button type="button" class="BTNremove btn btn-outline-danger btn-sm">Remove</button></td> </tr>');
                counter++;
                $('#addPhoneNumber').val('');
                setNameProperties();
            }
        } else {
            $('#AddPhoneRequired').html('Requires proper input, home and mobile numbers should only take 10 digits');
        }
    } else {
        $('#modalPhone').modal('show');
        $('#modalPhone').draggable();
        $('#modalErrorMessage').html('You cannot add more than 5 phone numbers');
    }
}

function setNameProperties() {
    var index = 0;
    $('.PhoneNumberListItem').each(function (index, element) {
        element.setAttribute('name', 'PhoneNumbers[' + index + '].Number');
        index++;
    })
    index = 0;
    $('.PhoneTypeListItem').each(function (index, element) {
        element.setAttribute('name', 'PhoneNumbers[' + index + '].PhoneTypeId');
        index++;
    })
    index = 0;
}

function numericInput(event) {
    var textField = document.getElementById('addPhoneNumber').value;
    var input = event.key;
    if (!(input == '0'
        || input == '1'
        || input == '2'
        || input == '3'
        || input == '4'
        || input == '5'
        || input == '6'
        || input == '7'
        || input == '8'
        || input == '9'
        || input == 'Backspace'
        || input == 'End'
        || input == 'Tab')) {

        return false;
    } else {
        return true;
    }
}

function buttonAnimation(complete) {
    if (complete === true) {
        $('#btnAddPhone').removeClass('btn-primary')
        $('#btnAddPhone').addClass('btn-success');
    } else {
        $('#btnAddPhone').removeClass('btn-success')
        $('#btnAddPhone').addClass('btn-primary');
    }
}

