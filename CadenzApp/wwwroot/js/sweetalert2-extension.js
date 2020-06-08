async function confirmDanger(title, message, icon) {
    return swal({
        title: title,
        text: message,
        icon: icon,
        type: 'warning',
        buttons: [
            "Cancel",
            "Delete"
        ],
        dangerMode: true
    });
}

async function confirmNormal(title, message, icon) {
    return swal({
        title: title,
        text: message,
        icon: icon,
        type: 'warning',
        buttons: [
            "Cancel",
            "Confirm"
        ]
    });
}