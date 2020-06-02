async function confirm(title, message) {
    return swal({
        title: title,
        text: message,
        type: 'warning',
        buttons: true,
        dangerMode: true
    });
}