
$(document).ready(function (){
    if (window.innerWidth < 1430) {
        $('.fullHdOnly').addClass('d-none');
        $('.lessThanFullHD').removeClass('d-none');
    } else {
        $('.fullHdOnly').removeClass('d-none');
        $('.lessThanFullHD').addClass('d-none');
    }
})

$(window).resize(function () {    
    if (window.innerWidth < 1430) {
        $('.fullHdOnly').addClass('d-none');
        $('.lessThanFullHD').removeClass('d-none');
    } else {
        $('.fullHdOnly').removeClass('d-none');
        $('.lessThanFullHD').addClass('d-none');
    }
})