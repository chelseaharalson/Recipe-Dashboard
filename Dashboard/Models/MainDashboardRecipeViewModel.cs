using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeDashboard.Models
{
    public class MainDashboardRecipeViewModel
    {
        public MainDashboardRecipeViewModel()
        {
        }

        public IEnumerable<RecipeViewModel> RecipeCards { get; set; }

        public SelectList CategoryFilter { get; set; }

        public int FavoriteCount { get; set; }
    }
}