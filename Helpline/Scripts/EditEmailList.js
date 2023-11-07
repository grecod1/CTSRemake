var counter = 0;
var regex = '^[a-z|A-Z|0-9|\.|_|-]+[@]{1}[a-z|A-Z|0-9|\.|_|-]+[\.]{1}[a-zA-z]{1,5}$';

$('#btnAddEmail').click(insertEmail);


$('document').ready(function () {
    setNameProperties();
    $('#emailTable tr').each(function (index, element) {
        counter++;
    })    
})

$('#addEmail').on('keydown', function (event) {
    emailInput(event);
})

$('#emailTable').on('click', '.BTNRemove', function () {
    counter--;
    var row = $(this).parents('tr').remove();
    setNameProperties();
})


function emailInput(event) {
    var input = event.key;
    var textfield = $('#addEmail').val();
    if (!(
        input == 'a' || input == 'A'
        || input == 'b' || input == 'B'
        || input == 'c' || input == 'C'
        || input == 'd' || input == 'D'
        || input == 'e' || input == 'E'
        || input == 'f' || input == 'F'
        || input == 'g' || input == 'G'
        || input == 'h' || input == 'H'
        || input == 'i' || input == 'I'
        || input == 'j' || input == 'J'
        || input == 'k' || input == 'K'
        || input == 'l' || input == 'L'
        || input == 'm' || input == 'M'
        || input == 'n' || input == 'N'
        || input == 'o' || input == 'O'
        || input == 'p' || input == 'P'
        || input == 'q' || input == 'Q'
        || input == 'r' || input == 'R'
        || input == 's' || input == 'S'
        || input == 't' || input == 'T'
        || input == 'u' || input == 'U'
        || input == 'v' || input == 'V'
        || input == 'w' || input == 'W'
        || input == 'x' || input == 'X'
        || input == 'y' || input == 'Y'
        || input == 'z' || input == 'Z'
        || input == '1' || input == '2'
        || input == '3' || input == '4'
        || input == '5' || input == '6'
        || input == '7' || input == '8'
        || input == '9' || input == '0'
        || input == '@' || input == 'Tab'
        || input == '-' || input == 'Enter'
        || input == '.' || input == 'Delete'
        || input == '_' || input == 'Backspace'
        || input == 'ArrowLeft' || input == 'ArrowRight'
        || input == 'Left' || input =='Right'
        || input == 'Home' || input == 'End'

    )) {
        event.preventDefault();
    } //0 input is required for firefox 
    else if (textfield.indexOf('@') != -1 && input == '@') {
        event.preventDefault();
    }
    else if (textfield.indexOf('@') != -1 && textfield.indexOf('.') != -1 && input != '@' && input != '.') {
        buttonAnimation(true);
        $('#AddEmailRequired').html('');
        if (input == 'Enter') {
            event.preventDefault();
            insertEmail();
        }
    }
    else if (input == 'Backspace' || input == 'Delete') {
        buttonAnimation(false);
        $('#AddEmailRequired').html('');
    }
    else {
        $('#AddEmailRequired').html('');
    }
}

function insertEmail() {
    if (counter < 20) {
        var emailInput = $('#addEmail').val();
        if (emailInput.match(regex)) {
            var sameEmail = false;
            $('td.tdEmail').each(function (index, element) {
                if (element.innerHTML.indexOf(emailInput) != -1) {
                    sameEmail = true;
                }
            })
            if (sameEmail) {
                $('#modalEmail').modal('show');
                $('#modalEmail').draggable();
                $('#modalErrorMessage').html('You cannot add in duplicate emails on the same routing category');
            }
            else {
                $('#emailTable').append('<tr><td class="tdEmail w-75">' + emailInput
                    + '<input type="hidden" class="EmailListItem" value="' + emailInput
                    + '" data-val="true"></td><td class="w-25 text-center"><button type="button"'
                    + 'class="BTNRemove btn btn-danger btn-sm">remove</button></td></tr>');
                counter++;
                $('#addEmail').val('');                
                setNameProperties();
                buttonAnimation(false);
            }
        }
        else {
            $('#AddEmailRequired').html('invalid email');
        }
    }
    else {
        $('#modalEmail').modal('show');
        $('#modalEmail').draggable();
        $('#modalErrorMessage').html('You cannot add more than 20 emails per routing category');
    }
}

function setNameProperties() {
    var index = 0;
    $('.EmailListItem').each(function (index, element) {
        element.setAttribute('name', 'Emails[' + index + ']');
        index++;
    })
    index = 0;        
}

function buttonAnimation(complete) {
    if (complete === true) {
        $('#btnAddEmail').removeClass('btn-primary')
        $('#btnAddEmail').addClass('btn-success');
    }
    else {
        $('#btnAddEmail').removeClass('btn-success')
        $('#btnAddEmail').addClass('btn-primary');
    }
}