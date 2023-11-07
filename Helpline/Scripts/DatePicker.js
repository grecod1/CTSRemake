var dateFormat = 'mm/dd/yy',
    from = $('#startDatePicker, .startDate').datepicker({            
            minDate: '-10Y',
            maxDate: 0,
            defaultDate: '+1w',
            changeMonth: true,
            changeYear: true,
            showAnim: 'fadeIn'
        }).on('change', function () {
            to.datepicker('option', 'minDate', getDate(this));
        }),
    to = $('#endDatePicker, .endDate').datepicker({
            maxDate: 1,
            defaultDate: '+1w',
            changeMonth: true,
            changeYear: true,
            showAnim: 'fadeIn'
        }).on('change', function () {
                from.datepicker('option', 'maxDate', getDate(this));
        });

var dateFormat2 = 'mm/dd/yy',
    from2 = $('.startDate2').datepicker({
        minDate: '-10Y',
        maxDate: 0,
        defaultDate: '+1w',
        changeMonth: true,
        changeYear: true,
        showAnim: 'fadeIn'
    }).on('change', function () {
        to2.datepicker('option', 'minDate', getDate(this));
    }),
    to2 = $('.endDate2').datepicker({
        maxDate: 1,
        defaultDate: '+1w',
        changeMonth: true,
        changeYear: true,
        showAnim: 'fadeIn'
    }).on('change', function () {
        from2.datepicker('option', 'maxDate', getDate(this));
        });

var dateFormat3 = 'mm/dd/yy',
    from3 = $('.startDate3').datepicker({
        minDate: '-10Y',
        maxDate: 0,
        defaultDate: '+1w',
        changeMonth: true,
        changeYear: true,
        showAnim: 'fadeIn'
    }).on('change', function () {
        to3.datepicker('option', 'minDate', getDate(this));
    }),
    to3 = $('.endDate3').datepicker({
        maxDate: 1,
        defaultDate: '+1w',
        changeMonth: true,
        changeYear: true,
        showAnim: 'fadeIn'
    }).on('change', function () {
        from3.datepicker('option', 'maxDate', getDate(this));
    });


$('document').ready(function () {     
    
    $('#DatePicker').datepicker({
        maxDate: 1,
        changeMonth: true,
        changeYear: true,
        showAnim: 'fadeIn',        
    });    
})

    function getDate(element) {
        var date;
        try {
            date = $.datepicker.parseDate(dateFormat, element.value);
        } catch (error) {
            date = null;
        }

        return date;
    }
