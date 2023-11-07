$('document').ready(function () {
        $('#accordion .card:first .collapse').addClass('show');
        $('.collapse.show').parent().addClass('selectedCard');
        $('.selectedCard .card-header').addClass('bg-helpline_color');
        $('.selectedCard em').toggle();
        $('.card:not(.selectedCard) .card-header').removeClass('bg-helpline_color');

    $('.card-header a').on('click', function () {
        $(this).children('em').toggle();
        var selectedTag = $(this).parents('.card');
        $('.collapse.show').addClass('bg-helpline_color');
        $('.collapse:not(.show)').removeClass('bg-helpline_color');
            
        })       
    })