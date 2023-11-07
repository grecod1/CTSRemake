function numberInput(event) {
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
        || input == 'End')) {
        event.preventDefault();
    } 
    
    else if (input == '.' && textField.indexOf('.') != -1) {
        event.preventDefault();
    }
    else {
        $('#numberERROR').remove();
    }
}