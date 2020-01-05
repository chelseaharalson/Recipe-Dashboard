(function (window, $) {
    'use strict';

    $(document).ready(function () {
        var favoritesToggled = false;

        // Selector Objects
        var $recipecards = $(".recipe-card"),
            $categorySelect = $("#CategoryFilter"),
            $showAll = $("#show-all-recipes");

        // Functions
        function hideRecipeCards(category, dataAttr) {
            $recipecards.hide();
            var $recipeCardsToShow = $recipecards.filter(function (index) {
                var datapoint;
                if (dataAttr === "categoryname") {
                    datapoint = $(this).data("categoryname");
                }
                var result = datapoint === category;
                return result;
            });
            $recipeCardsToShow.show();
        }

        function showAllRecipeCards() {
            $recipecards.show();
        }

        $('.cs-select.cs-skin-elastic').on("click", function (e) {
            var categoryName = $categorySelect.val();
            categoryName ? hideRecipeCards(categoryName, "categoryname") : showAllRecipeCards();
        });
        $showAll.on("click", showAllRecipeCards);

        $('.filter-favorites.text-decoration-none').on("click", function (e) {
            if (favoritesToggled === false) {
                favoritesToggled = true;
                var $favoriteRecipeCardsToShow = $recipecards.filter(function (index) {
                    var isFavorite = $(this).data("isfavorite") === "True";
                    return isFavorite;
                });
                $recipecards.hide();
                $favoriteRecipeCardsToShow.show();
            }
            else if (favoritesToggled === true) {
                favoritesToggled = false;
                showAllRecipeCards();
            }
        });
    });

}(this, jQuery));