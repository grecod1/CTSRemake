$('document').ready(function () {
            if ($('#IsActive').val() == 'False') {
                 $('.userField').attr('Disabled', 'Disabled')
            }            
        })

        $('#submit').click(function () {
            $('.userField').removeAttr('Disabled')
        })

        $('#IsActive').change(function () {
            if ($('#IsActive').val() == 'True') {
                $('.userField').removeAttr('Disabled')
            }
            else if ($('#IsActive').val() == 'False') {
                $('.userField').attr('Disabled', 'Disabled')                
            }                            
        })