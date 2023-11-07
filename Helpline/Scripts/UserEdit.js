$('document').ready(function () {
    if ($('#StatusId').val() == 2) {
        $('.userField').attr('Disabled', 'Disabled')
    }    
})

        $('#submit').click(function () {
            $('.userField').removeAttr('Disabled')
        })

        $('#StatusId').change(function () {
            if ($('#StatusId').val() == 1) {
                $('.userField').removeAttr('Disabled')
            }
            else if ($('#StatusId').val() == 2) {
                $('.userField').attr('Disabled', 'Disabled')
                $('#RoleId').val($('#viewOnlyId').val());
            }                            
        })