$('a.card-link').click(function ()
{
        var link = $(this);
        var span = $(this.firstChild);
    var collapse = $(this.nextElementSibling);    
    var linkText = $(this.lastElementChild);

        if (collapse.hasClass('show')) {
            span.removeClass('ui-icon-triangle-1-s');
            span.addClass('ui-icon-triangle-1-e');            
            
            
        }
        else {
            span.removeClass('ui-icon-triangle-1-e');
            span.addClass('ui-icon-triangle-1-s');            

            
            
        }
    })