using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using RecipeDashboard.Models;
using System.Linq;

namespace RecipeDashboard.Database.DataAccess
{
    public class RecipeRepository
    {
        string DbConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<RecipeViewModel> GetRecipes()
        {
            var connection = new SqlConnection(DbConnectionString);
            connection.Open();
            IEnumerable<RecipeViewModel> result = connection.Query<RecipeViewModel>("[dbo].[GetRecipes]", null, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }

        public RecipeViewModel GetRecipe(int RecipeId)
        {
            var connection = new SqlConnection(DbConnectionString);
            connection.Open();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RecipeId", RecipeId);
            RecipeViewModel result = connection.Query<RecipeViewModel>("[dbo].[GetRecipe]", parameters, commandType: CommandType.StoredProcedure).First();
            connection.Close();
            return result;
        }

        public int AddRecipe(AddRecipeViewModel model)
        {
            var connection = new SqlConnection(DbConnectionString);
            connection.Open();
            DynamicParameters parameters = new DynamicParameters();
            const string outputVariable = "@retId";
            parameters.Add("@Name", model.Name);
            parameters.Add("@Category", model.Category);
            parameters.Add("@CookTime", model.CookTime);
            parameters.Add("@Description", model.Description);
            parameters.Add("@Ingredients", model.Ingredients);
            parameters.Add("@Instructions", model.Instructions);
            parameters.Add("@Notes", model.Notes);
            parameters.Add("@PrepTime", model.PrepTime);
            parameters.Add("@Servings", model.Servings);
            parameters.Add("@retId", -1, DbType.Int32, direction: ParameterDirection.Output);
            connection.Execute("[dbo].[AddRecipe]", parameters, commandType: CommandType.StoredProcedure);
            connection.Close();
            return parameters.Get<int>(outputVariable);
        }

        public void DeleteRecipe(int RecipeId)
        {
            var connection = new SqlConnection(DbConnectionString);
            connection.Open();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RecipeId", RecipeId);
            connection.Execute("[dbo].[DeleteRecipe]", parameters, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void UpdateRecipe(EditRecipeViewModel model)
        {
            var connection = new SqlConnection(DbConnectionString);
            connection.Open();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RecipeId", model.RecipeId);
            parameters.Add("@Name", model.Name);
            parameters.Add("@Category", model.Category);
            parameters.Add("@CookTime", model.CookTime);
            parameters.Add("@Description", model.Description);
            parameters.Add("@Ingredients", model.Ingredients);
            parameters.Add("@Instructions", model.Instructions);
            parameters.Add("@Notes", model.Notes);
            parameters.Add("@PrepTime", model.PrepTime);
            parameters.Add("@Servings", model.Servings);
            connection.Execute("[dbo].[UpdateRecipe]", parameters, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void UpdateFavorite(RecipeViewModel model)
        {
            var connection = new SqlConnection(DbConnectionString);
            connection.Open();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RecipeId", model.RecipeId);
            parameters.Add("@Favorite", model.Favorite);
            connection.Execute("[dbo].[UpdateFavorite]", parameters, commandType: CommandType.StoredProcedure);
            connection.Close();
        }
    }
}