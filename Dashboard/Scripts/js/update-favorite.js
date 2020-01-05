(function (window, $) {
    'use strict';

    $('.favorite-button').click(function (e) {
        e.preventDefault();
        var toggleThis = $(this);
        var recipeId = $(this).data("recipeid");
        var favorite = $(this).data("favorite");
        var favoriteCountText = $("#FavoriteCount").text();
        var favoriteCount = parseInt(favoriteCountText);
        var data = new FormData();
        data.append("RecipeId", recipeId);
        if (favorite === "False") {
            data.append("Favorite", true);
        }
        else if (favorite === "True") {
            data.append("Favorite", false);
        }

        var request = $.ajax({
            url: '/Dashboard/UpdateFavorite/',
            type: 'POST',
            data: data,
            cache: false,
            contentType: false,
            processData: false,
            success: function (data) {
                if (data.success === true) {
                    toggleThis.toggleClass('fas far');
                    if (data.favorite === false) {
                        toggleThis.data("favorite", "False");
                        favoriteCount = favoriteCount - 1;
                        $("#FavoriteCount").text(favoriteCount);
                    }
                    else if (data.favorite === true) {
                        toggleThis.data("favorite", "True");
                        favoriteCount = favoriteCount + 1;
                        $("#FavoriteCount").text(favoriteCount);
                    }
                }
                else if (data.success === false) {
                    Console.log("Failure to update favorite");
                }
            },
            error: function (data) {
                Console.log("ERROR: Failure to update favorite");
            }
        });
    });

}(this, jQuery));