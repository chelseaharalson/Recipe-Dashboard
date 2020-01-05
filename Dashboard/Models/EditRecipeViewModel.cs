namespace RecipeDashboard.Models
{
    public class EditRecipeViewModel
    {
        public EditRecipeViewModel()
        {
        }

        public int RecipeId { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string Instructions { get; set; }

        public string CookTime { get; set; }

        public string PrepTime { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public int Servings { get; set; }
    }
}