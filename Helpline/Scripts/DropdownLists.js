
$(document).ready(function () {
    $('.nav-item.dropdown').hover(function () {
        $(this).children('.dropdown-menu').addClass('show');
    }, function () {
        $(this).children('.dropdown-menu').removeClass('show');
    });
})
