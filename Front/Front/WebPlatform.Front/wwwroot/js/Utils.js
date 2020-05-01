function AlertSuccess(message) {

    Swal.fire({
        position: 'top-right',
        type: 'success',
        title: message,
        showConfirmButton: false,
        timer: 2000
    });
}

function AlertError(message) {

    Swal.fire({
        position: 'top-right',
        type: 'error',
        title: "Error!",
        text: message,
        showConfirmButton: true
    });
}

function AlertErrorValidator(message) {

    Swal.fire({
        position: 'top-right',
        type: 'error',
        title: "Error!",
        html: message,
        showConfirmButton: true
    });
}

function AlertDelete() {

    Swal.fire({
        title: '¿Estás seguro?',
        text: "¡No podrás revertir esto!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Eliminar!'
    }).then((result) => {
        if (result.value) {
            return true;
        }
    });
}
