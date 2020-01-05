CREATE PROCEDURE [dbo].[UpdateRecipe]
	@RecipeId INT,
	@Name VARCHAR(50),
	@Ingredients VARCHAR(MAX),
	@Instructions VARCHAR(MAX),
	@Category VARCHAR(MAX),
	@CookTime VARCHAR(50),
	@PrepTime VARCHAR(50),
	@Description VARCHAR(MAX),
	@Notes VARCHAR(MAX),
	@Servings INT
AS
	UPDATE [dbo].[Recipes] 
	SET Name = @Name,
		Ingredients = @Ingredients,
		Instructions = @Instructions,
		Category = @Category,
		CookTime = @CookTime,
		PrepTime = @PrepTime,
		Description = @Description,			
		Notes = @Notes,
		Servings = @Servings
	WHERE [RecipeId] = @RecipeId