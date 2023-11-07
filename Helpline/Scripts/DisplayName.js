$(document).ready(function () {       
    $.ajax({
        url: "/Home/FullName", 
        type: "GET",
        dataType: "JSON",
        async: true,
        cache: true,
        success: function (data) {
            $("#DisplayUserName").html(data);
        }
    })
})

