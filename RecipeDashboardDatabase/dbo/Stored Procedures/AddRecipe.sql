CREATE PROCEDURE [dbo].[AddRecipe]
	@Name VARCHAR(50),
	@Ingredients VARCHAR(MAX),
	@Instructions VARCHAR(MAX),
	@Category VARCHAR(MAX),
	@CookTime VARCHAR(50),
	@PrepTime VARCHAR(50),
	@Description VARCHAR(MAX),
	@Notes VARCHAR(MAX),
	@Servings INT,
	@retId INT OUTPUT
AS

BEGIN
	BEGIN TRANSACTION
		INSERT INTO [dbo].[Recipes](
		    Name,
		    Ingredients,
		    Instructions,
            Category,
            CookTime,
            PrepTime,
			Image,
            Description,
            Notes,
            Servings,
			Favorite)
		VALUES(
            @Name, 
            @Ingredients, 
            @Instructions, 
            @Category,
            @CookTime,
            @PrepTime,
			null,
            @Description,
            @Notes,
            @Servings,
			0);
			SET @retId = SCOPE_IDENTITY();
	COMMIT TRANSACTION
END