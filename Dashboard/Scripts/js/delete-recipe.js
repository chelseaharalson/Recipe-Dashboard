(function (window, $) {
    'use strict';

    $(document).ready(function () {
        $('#delete-recipe-button').click(function (e) {
            e.preventDefault();
            swal({
                title: "Are you sure you want to delete this recipe?",
                text: "You will not be able to recover this recipe",
                type: "warning",
                showCancelButton: true,
                confirmButtonText: "Yes, delete it",
                cancelButtonText: "No, cancel",
                closeOnConfirm: false,
                closeOnCancel: false
            }, function (isConfirm) {
                if (isConfirm) {
                    $("#delete-form").unbind('submit').submit();
                    swal("Deleted!", "Recipe has been deleted.", "success");
                } else {
                    swal("Cancelled", "Recipe was not deleted", "error");
                }
            });
        });
    });

}(this, jQuery));