CREATE PROCEDURE [dbo].[UpdateFavorite]
	@RecipeId INT,
	@Favorite BIT
AS
	UPDATE [dbo].[Recipes] 
	SET Favorite = @Favorite
	WHERE [RecipeId] = @RecipeId