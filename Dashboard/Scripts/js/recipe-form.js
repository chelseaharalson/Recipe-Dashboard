(function (window, $) {
    "use strict";

    $(document).ready(function () {
        (function () {
            [].slice.call(document.querySelectorAll('select.cs-select')).forEach(function (el) {
                new SelectFx(el);
            });
        })();

        var stepCount = 1;

        // Floating labels
        $(window, document, undefined).ready(function () {
            $('.recipe-form').find('input').each(function () {
                var RecipeName = $("#Name").val();
                if (RecipeName.length !== 0) {
                    $(this).addClass('used');
                }
            });

            $('.recipe-form').find('textarea').each(function () {
                var RecipeName = $("#Name").val();
                if (RecipeName.length !== 0) {
                    $(this).addClass('used');
                }
            });

            $('input').blur(function () {
                var $this = $(this);
                if ($this.val())
                    $this.addClass('used');
                else
                    $this.removeClass('used');
            });

            $('textarea').blur(function () {
                var $this = $(this);
                if ($this.val())
                    $this.addClass('used');
                else
                    $this.removeClass('used');
            });
        });

        // Add a bullet point after each enter
        $("#Ingredients").on('keydown', function (e) {
            var t = $(this);
            switch (e.which) {
                case 13:
                    t.val(t.val() + '\n• ');
                    return false;
            }
        });

        // Check if the textarea is empty. If so, add a bullet point.
        $('#recipe-form').find("#Ingredients").focus(function () {
            if (!$.trim($("#Ingredients").val())) {
                var t = $(this);
                t.val(t.val() + '• ');
            }
        });

        // Check if the textarea is empty. If so, add a #1.
        $('#recipe-form').find("#Instructions").focus(function () {
            if (!$.trim($("#Instructions").val())) {
                stepCount = 1;
                var t = $(this);
                t.val(t.val() + stepCount + ') ');
                stepCount++;
            }
        });

        // Add a number after each enter
        $("#Instructions").on('keydown', function (e) {
            var t = $(this);
            switch (e.which) {
                case 13:
                    t.val(t.val() + '\n' + stepCount + ') ');
                    stepCount++;
                    return false;
            }
        });

        $('#recipe-button').click(function (e) {
            if ($('#Category :selected').text() === 'Category') {
                e.preventDefault();
                return alertForRequiredFields();
            }
            if ($("#Name").val() === '' || $("#Description").val() === '' || $("#PrepTime").val() === ''
                || $("#CookTime").val() === '' || $("#Servings").val() === ''
                || $("#Ingredients").val() === '' || $("#Instructions").val() === '') {
                e.preventDefault();
                return alertForRequiredFields();
            }
        });

        function alertForRequiredFields() {
            swal({
                title: "Missing fields",
                text: "Please fill out all the required fields",
                type: "warning",
                showCancelButton: false,
                confirmButtonText: "Okay",
                closeOnConfirm: true,
                closeOnCancel: true
            });
        }

        // Only allow number input
        $("#Servings").keypress(function (event) {
            if (event.keyCode < 48 || event.keyCode > 57) {
                event.preventDefault();
            }
        });
    });
}(this, jQuery));