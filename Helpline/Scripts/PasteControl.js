$('.form-control').on('paste', function (event) {
    var content;
    if (determineBrowser() === 'IE') {
        content = window.clipboardData.getData('Text');
    } else {
        content = event.originalEvent.clipboardData.getData('text/plain');
    }
    var stringContent = new String(content);
    if (stringContent.indexOf('<') != -1) {
        event.preventDefault();
        for (i = 0; i <= stringContent.indexOf('<'); i++) {
            stringContent = stringContent.replace('<', '');            
        }       
        $(this).val(stringContent.trim());
    }        
})