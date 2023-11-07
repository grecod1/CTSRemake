var dateFormat = 'mm/dd/yy',
    from = $('#startDatePicker').datepicker({        
        maxDate: '-9Y',
        defaultDate: '-9Y',
        changeMonth: true,
        changeYear: true,
        showAnim: 'fadeIn'
    }).on('change', function () {
        to.datepicker('option', 'minDate', getDate(this));
    }),
    to = $('#endDatePicker').datepicker({        
        maxDate: '-9Y',
        defaultDate: '-9Y',
        changeMonth: true,
        changeYear: true,
        showAnim: 'fadeIn'
    }).on('change', function () {
        from.datepicker('option', 'maxDate', getDate(this));
    });

function getDate(element) {
    var date;
    try {
        date = $.datepicker.parseDate(dateFormat, element.value);
    } catch (error) {
        date = null;
    }

    return date;
}