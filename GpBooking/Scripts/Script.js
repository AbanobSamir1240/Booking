/* Add here all your JS customizations */
function openPopUp(url) {
    $(() => {
        window.swal({
            icon: "warning",
            position: 'top-right',
            title: 'Are you sure?',
            text: "Your will not be able to recover this Data!",
            closeOnEsc: true,
            closeOnClickOutside: true,
            buttons: {
                cancel: {
                    text: "Cancel",
                    value: null,
                    visible: true,
                    className: "",
                    closeModal: true
                },
                confirm: {
                    text: "OK",
                    value: true,
                    visible: true,
                    className: "btn-danger",
                    closeModal: true
                }
            }
        }).then((value) => {
            if (value !== null) {
                window.location.href = url;
            }
        });
    });
}