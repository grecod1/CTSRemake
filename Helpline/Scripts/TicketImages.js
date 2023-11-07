
$(document).ready(function () {
    $.ajax({
        url: '/api/ImageAPI/' + $('#TicketId').val(),
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            displayImages(response);
            
        },
        error: function () {
            $('#imageList').append('<div class="col-12"><h3 class="text-danger">Error loading images</h3></div>')
        }
    })    
})

var ImageUpload = document.getElementById('Image');
ImageUpload.addEventListener('change', function () {
    if (this.files[0].size > 10485760) {
        event.preventDefault();
        $('#spanTicketErr').html('Image file cannot be greater than 10 MB');
        $('.btn-success').prop('disabled', true)
    } else {
        $('#spanTicketErr').html('');
        $('.btn-success').prop('disabled', false);
    }
})


$('#rowImages').on('click', '.btn-remove', function () {
    $('#modalDeactivateImage').modal('show');
    $('#modalDeactivateImage').draggable();
    $('#btnDelete').val($(this).val());
});


$('#btnDelete').click(function () {
    $.ajax({
        url: '/api/ImageAPI/Delete/' + $(this).val(),
        method: 'DELETE',
        dataType: 'JSON',
        beforeSend: function () {
            $('#loadingDelete').removeClass('d-none');
            $('#hideRemoveBtn').addClass('d-none');
        },
        complete: function () {
            $('#loadingDelete').addClass('d-none');
            $('#hideRemoveBtn').removeClass('d-none');
        },
        success: function (response) {
            $('#modalDeactivateImage').modal('hide');
            $('#updateToast').toast({ delay: 5000 });
            $('#updateToast').removeClass('bg-success');
            $('#updateToast').addClass('bg-danger');
            $('#updateToast h6').html('<span class="fa fa-trash pull-left"></span>Update Complete')
            $('#updateToast').toast('show');
            $('#fiveImagesMessage').addClass('d-none');
            displayImages(response);
        },
        error: function (response) { $('#spanTicketErr').html(response.responseText); }
    });
})

function ConsoleLog() {
    console.log('Complete')

}

function success(response) {
    displayImages(response);
    $('#updateToast').toast({ delay: 5000 });
    $('#updateToast').removeClass('bg-danger');
    $('#updateToast').addClass('bg-success');
    $('#updateToast h6').html('<span class="fa fa-save pull-left"></span>Update Complete')
    $('#updateToast').toast('show');
}

function displayImages(response) {
    $('#Image').val('');
    var imageCount = 0;
    $('#rowImages').html('');
    $.each(response, function (index, value) {

        var content = '<div class="col-lg-4 col-md-6 col-12">'
            + '<div class="card p-2" style = "height:580px">'
            + '<img src="/Ticket/Image/' + value.Id + '" class="card-img-top h-50" alt="Ticket Image" />'
            + '<div class="card-body">'            
            + '<p class="text-danger"></p>'            
            + '</div>'
            + '<div class="card-footer px-0">'            
            + '<button class="btn btn-danger btn-remove pull-right" type="button" value="'
            + value.Id + '">Remove Image</button>'
            + '</div>'
            + '</div>'
            +'</div > ';

        $('#rowImages').append(content);

        imageCount++;
    })    
    
    
    if (imageCount >= 5) {
        $('#panelAddImage').addClass('d-none');
        $('#maximumImages').removeClass('d-none');
    } else {
        $('#panelAddImage').removeClass('d-none');
        $('#maximumImages').addClass('d-none');
    }
}



function formFailure(response) {    

    var message = "";

    if (response.responseJSON != null) {
        message = "Invalid photo. Please check if the photo is either jpeg or png, and if the photo is below 5 mb."
                        
    } else {
        message = response.responseText;
    }        

    $('#spanTicketErr').html(message);
}