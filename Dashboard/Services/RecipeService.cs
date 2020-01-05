using RecipeDashboard.Database.DataAccess;
using RecipeDashboard.Models;
using System.Collections.Generic;

namespace RecipeDashboard.Services
{
    public class RecipeService
    {
        public RecipeRepository recipeRepository = new RecipeRepository();

        public RecipeService()
        {
        }

        public IEnumerable<RecipeViewModel> GetRecipes()
        {
            var recipes = recipeRepository.GetRecipes();
            return recipes;
        }

        public RecipeViewModel GetRecipe(int RecipeId)
        {
            var recipe = recipeRepository.GetRecipe(RecipeId);
            return recipe;
        }

        public int AddRecipe(AddRecipeViewModel model)
        {
            return recipeRepository.AddRecipe(model);
        }

        public void DeleteRecipe(int RecipeId)
        {
            recipeRepository.DeleteRecipe(RecipeId);
        }

        public void UpdateRecipe(EditRecipeViewModel model)
        {
            recipeRepository.UpdateRecipe(model);
        }

        public void UpdateFavorite(RecipeViewModel model)
        {
            recipeRepository.UpdateFavorite(model);
        }
    }
}