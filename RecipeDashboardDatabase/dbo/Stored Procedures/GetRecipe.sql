CREATE PROCEDURE [dbo].[GetRecipe]
@RecipeId INT
AS
	SELECT [RecipeId]
      ,[Name]
      ,[Ingredients]
      ,[Instructions]
      ,[Category]
      ,[CookTime]
      ,[PrepTime]
      ,[Image]
	  ,[Description]
	  ,[Notes]
	  ,[Servings]
	  ,[Favorite]
  FROM [dbo].[Recipes]
  WHERE [RecipeId] = @RecipeId
RETURN 0
