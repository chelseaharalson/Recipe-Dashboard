CREATE PROCEDURE [dbo].[DeleteRecipe]
	@RecipeId INT
AS
	DELETE FROM [dbo].[Recipes]
	WHERE [RecipeId] = @RecipeId