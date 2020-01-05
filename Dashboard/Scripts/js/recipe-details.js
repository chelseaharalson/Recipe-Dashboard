(function (window, $) {
    "use strict";

    $(document).ready(function () {
        var expandIngredients = true;
        var expandInstructions = true;

        $('#expand-ingredients').on("click", function () {
            $('.ingredients').slideToggle(100);
            if (expandIngredients === true) {
                expandIngredients = false;
                $('#expand-ingredients').html("<i class='fa fa-plus fa-lg'></i>");
            }
            else if (expandIngredients === false) {
                expandIngredients = true;
                $('#expand-ingredients').html("<i class='fa fa-minus fa-lg'></i>");
            }
        });

        $('#expand-instructions').on("click", function () {
            $('.instructions').slideToggle(100);
            if (expandInstructions === true) {
                expandInstructions = false;
                $('#expand-instructions').html("<i class='fa fa-plus fa-lg'></i>");
            }
            else if (expandInstructions === false) {
                expandInstructions = true;
                $('#expand-instructions').html("<i class='fa fa-minus fa-lg'></i>");
            }
        });
    });
}(this, jQuery));