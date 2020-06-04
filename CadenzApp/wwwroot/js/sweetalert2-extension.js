async function confirm(title, message, icon) {
    return swal({
        title: title,
        text: message,
        icon: icon,
        type: 'warning',
        buttons: [
            "Cancel",
            "Close"
        ],
        dangerMode: true
    });
}