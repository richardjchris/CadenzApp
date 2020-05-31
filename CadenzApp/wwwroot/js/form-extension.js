function ClearForm() {
    $("input").val("");
    $("input").next('label').removeClass("active");
    $(".radio label:first input").prop('checked', true);
}


$(".modalClose").click(function () {
    swal({
        title: "Close form?",
        text: "Any changes made will not be saved.",
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
    }
});