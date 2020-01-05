using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeDashboard.Utils
{
    public static class CategoryList
    {
        public static IEnumerable<SelectListItem> GetCategoryList()
        {
            IList<SelectListItem> categoryList = new List<SelectListItem>
            {
                new SelectListItem() { Text="Breakfast", Value="Breakfast"},
                new SelectListItem() { Text="Appetizers", Value="Appetizers"},
                new SelectListItem() { Text="Snacks", Value="Snacks"},
                new SelectListItem() { Text="Chicken", Value="Chicken"},
                new SelectListItem() { Text="Beef", Value="Beef"},
                new SelectListItem() { Text="Pork", Value="Pork"},
                new SelectListItem() { Text="Seafood", Value="Seafood"},
                new SelectListItem() { Text="Vegetables", Value="Vegetables"},
                new SelectListItem() { Text="Desserts", Value="Desserts"},
                new SelectListItem() { Text="Soups", Value="Soups"},
                new SelectListItem() { Text="Salads", Value="Salads"}
            };
            return categoryList;
        }
    }
}