function ClearForm() {
    $("input").val("");
    $("textarea").val("");
    $("input").next('label').removeClass("active");
    $(".radio label:first input").prop('checked', true);
}


$(".modalClose").click(function () {
    swal({
        title: "Close form?",
        text: "Are you sure you want to close this window? Any changes made will not be saved.",
        icon: 'warning',
        buttons: [
            "Cancel",
            "Close"
        ],
        dangerMode: true
    }).then(function (isConfirm) {
        if (isConfirm) {
            $('.modal').modal('close');
        }
    })
});

$('.modal.form').modal({
    dismissible: false,
    onCloseEnd: function () {
        ClearForm();
        $('.modal.form .form-header').text(originalHeader);
    }
});