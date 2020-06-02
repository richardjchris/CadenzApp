async function confirm(title, message) {
    return swal({
        title: title,
        text: message,
        type: 'warning',
        showCancelButton: true
    });
}