
$(document).ready(function () {
    var url = document.URL;
    if (url.indexOf('helplinedev') != -1) {
        $('#disclaimer').html('Dev');
    }
    else if (url.indexOf('helplinetest') != -1) {
        $('#disclaimer').html('Test');
    }    
})


    