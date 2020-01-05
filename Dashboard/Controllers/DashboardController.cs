using RecipeDashboard.Models;
using RecipeDashboard.Services;
using System;
using System.Diagnostics;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace RecipeDashboard.Controllers
{
    public class DashboardController : Controller
    {
        public RecipeService recipeService = new RecipeService();

        public DashboardController()
        {
        }

        [HttpGet]
        public ActionResult MainDashboard()
        {
            var model = new MainDashboardRecipeViewModel();
            model.RecipeCards = recipeService.GetRecipes();
            int FavoriteCount = 0;
            foreach (RecipeViewModel r in model.RecipeCards)
            {
                if (r.Favorite == true)
                {
                    FavoriteCount++;
                }
            }
            model.FavoriteCount = FavoriteCount;
            return View(model);
        }

        [HttpGet]
        public ActionResult RecipeDetails(int id)
        {
            RecipeViewModel model = new RecipeViewModel();
            model = recipeService.GetRecipe(id);
            string[] ingredientsArray = JsonConvert.DeserializeObject<string[]>(model.Ingredients);
            model.Ingredients = "";
            for (int i = 0; i < ingredientsArray.Length; i++)
            {
                model.Ingredients += "\n\r" + ingredientsArray[i].Trim();
            }
            string[] instructionsArray = JsonConvert.DeserializeObject<string[]>(model.Instructions);
            model.Instructions = instructionsArray[0];
            for (int i = 1; i < instructionsArray.Length; i++)
            {
                model.Instructions += "\n\r\r\n" + instructionsArray[i].Trim();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRecipe(AddRecipeViewModel model)
        {
            try
            {
                string[] ingredientsArray = null;
                if (model.Ingredients.Contains("\r"))
                {
                    model.Ingredients = model.Ingredients.Replace('\r',' ');
                }
                ingredientsArray = model.Ingredients.Split('\n');

                string[] instructionsArray = null;
                if (model.Instructions.Contains("\r"))
                {
                    model.Instructions = model.Instructions.Replace('\r', ' ');
                }
                instructionsArray = model.Instructions.Split('\n');

                model.Ingredients = JsonConvert.SerializeObject(ingredientsArray);
                model.Instructions = JsonConvert.SerializeObject(instructionsArray);

                var recipe = new AddRecipeViewModel()
                {
                    Name = model.Name,
                    Category = model.Category,
                    CookTime = model.CookTime,
                    Description = model.Description,
                    Ingredients = model.Ingredients,
                    Instructions = model.Instructions,
                    Notes = model.Notes,
                    PrepTime = model.PrepTime,
                    Servings = model.Servings
                };

                int RecipeId = recipeService.AddRecipe(recipe);
                return RedirectToAction("RecipeDetails", "Dashboard", new { id = RecipeId });
            }
            catch (Exception e)
            {
                Trace.TraceError($"Unable to add recipe: {e.Message}");
            }
            return RedirectToAction("MainDashboard", "Dashboard");
        }

        [HttpPost]
        public ActionResult DeleteRecipe(int RecipeId)
        {
            recipeService.DeleteRecipe(RecipeId);
            return RedirectToAction("MainDashboard", "Dashboard");
        }

        [HttpGet]
        public ActionResult EditRecipe(int RecipeId)
        {
            var recipe = recipeService.GetRecipe(RecipeId);
            string[] ingredientsArray = JsonConvert.DeserializeObject<string[]>(recipe.Ingredients);
            recipe.Ingredients = "";
            for (int i = 0; i < ingredientsArray.Length; i++)
            {
                recipe.Ingredients += ingredientsArray[i].Trim() + "\r";
            }
            string[] instructionsArray = JsonConvert.DeserializeObject<string[]>(recipe.Instructions);
            recipe.Instructions = "";
            for (int i = 0; i < instructionsArray.Length; i++)
            {
                recipe.Instructions += instructionsArray[i].Trim() + "\r";
            }
            var model = new EditRecipeViewModel()
            {
                Category = recipe.Category,
                CookTime = recipe.CookTime,
                Description = recipe.Description,
                Ingredients = recipe.Ingredients.Trim(),
                Instructions = recipe.Instructions.Trim(),
                Name = recipe.Name,
                Notes = recipe.Notes,
                PrepTime = recipe.PrepTime,
                Servings = recipe.Servings,
                RecipeId = recipe.RecipeId
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditRecipe(EditRecipeViewModel model)
        {
            try
            {
                string[] ingredientsArray = null;
                if (model.Ingredients.Contains("\r"))
                {
                    model.Ingredients = model.Ingredients.Replace('\r', ' ');
                }
                ingredientsArray = model.Ingredients.Split('\n');

                string[] instructionsArray = null;
                if (model.Instructions.Contains("\r"))
                {
                    model.Instructions = model.Instructions.Replace('\r', ' ');
                }
                instructionsArray = model.Instructions.Split('\n');

                model.Ingredients = JsonConvert.SerializeObject(ingredientsArray);
                model.Instructions = JsonConvert.SerializeObject(instructionsArray);

                var recipe = new EditRecipeViewModel()
                {
                    Name = model.Name,
                    Category = model.Category,
                    CookTime = model.CookTime,
                    Description = model.Description,
                    Ingredients = model.Ingredients,
                    Instructions = model.Instructions,
                    Notes = model.Notes,
                    PrepTime = model.PrepTime,
                    Servings = model.Servings,
                    RecipeId = model.RecipeId
                };

                recipeService.UpdateRecipe(recipe);
                return RedirectToAction("RecipeDetails", "Dashboard", new { id = model.RecipeId });
            }
            catch (Exception e)
            {
                Trace.TraceError($"Unable to edit recipe: {e.Message}");
            }
            return RedirectToAction("MainDashboard", "Dashboard");
        }

        [HttpPost]
        public JsonResult UpdateFavorite(RecipeViewModel model)
        {
            try
            {
                var recipe = new RecipeViewModel()
                {
                    Favorite = model.Favorite,
                    RecipeId = model.RecipeId
                };

                recipeService.UpdateFavorite(recipe);
                return Json(new { success = true, favorite = model.Favorite });
            }
            catch (Exception e)
            {
                Trace.TraceError($"Unable to edit recipe: {e.Message}");
            }
            return Json(new { success = false });
        }
    }
}