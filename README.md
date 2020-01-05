# Recipe Dashboard

http://recipe-dashboard.us-east-2.elasticbeanstalk.com/

### MODEL:

	RecipeDashboard/Dashboard/Models/AddRecipeViewModel.cs: model for the Add Recipe feature

	RecipeDashboard/Dashboard/Models/EditRecipeViewModel.cs: model for the Update Recipe feature

	RecipeDashboard/Dashboard/Models/MainDashboardRecipeViewModel.cs: model for viewing the main dashboard with all the recipe cards

	RecipeDashboard/Dashboard/Models/RecipeViewModel.cs: model for viewing the Recipe Details


### CONTROLLER:

	RecipeDashboard/Dashboard/Controllers/DashboardController.cs: dashboard controller for all the logic for the dashboard (returning main view, recipe details, adding a recipe, updating a recipe, deleting a recipe, updating a favorite)


### VIEW:

	RecipeDashboard/Dashboard/App_Start/BundleConfig.cs: where all the script files and css are bundled

	RecipeDashboard/Dashboard/Content/bootstrap: bootstrap 4 for sass installed

	RecipeDashboard/Dashboard/Content/fontawesome: fontawesome library

	RecipeDashboard/Dashboard/Content/images: any images for the dashboard

	RecipeDashboard/Dashboard/Content/webfonts: fonts for fontawesome

	RecipeDashboard/Dashboard/Content/layouts/dashboard/components/... : sass files for dashboard layout

	RecipeDashboard/Dashboard/Views/Dashboard/AddRecipe.cshtml: form for adding a recipe

	RecipeDashboard/Dashboard/Views/Dashboard/EditRecipe.cshtml: form for updating a recipe

	RecipeDashboard/Dashboard/Views/Dashboard/MainDashboard.cshtml: main dashboard landing page

	RecipeDashboard/Dashboard/Views/Dashboard/RecipeDetails.cshtml: details page for each recipe

	RecipeDashboard/Dashboard/Views/Dashboard/_LayoutDashboard.cshtml: layout page for the dashboard

	RecipeDashboard/Dashboard/Scripts/... : jQuery and other libraries installed by nuget

	RecipeDashboard/Dashboard/Scripts/libraries/... : libraries that were unavailable through nuget

	RecipeDashboard/Dashboard/Scripts/js/delete-recipe.js: js file to trigger the alert to ask a user if they are sure they want to delete that recipe

	RecipeDashboard/Dashboard/Scripts/js/filter-by-category.js: js file to show or hide recipe cards based on dropdown selection or when a user clicks the favorite button on the main dashboard page

	RecipeDashboard/Dashboard/Scripts/js/recipe-details.js: js file for expanding or minimizing the ingredients and instructions div

	RecipeDashboard/Dashboard/Scripts/js/recipe-form.js: js file for the add/update form for floating labels. Also, adds a bullet point or number after each new line when a user is entering the recipe steps and ingredients. Does a check that all required fields are filled out when user presses submit.

	RecipeDashboard/Dashboard/Scripts/js/update-favorite.js: js file for making an ajax call to update if a recipe is a favorite. Also, changes color of heart and the favorite count.


### DATA:

	RecipeDashboard/Dashboard/Database/DataAccess/RecipeRepository.cs: main logic for connecting to the SQL server database and retrieving a recipe, adding a recipe, updating a recipe, deleting a recipe, and updating a favorite

	RecipeDashboard/Dashboard/Services/RecipeService.cs: functions for calling the database and returning the model
	
	RecipeDashboard/RecipeDashboardDatabase/dbo/Stored Procedures/ ... : stored procedures for adding a recipe, deleting a recipe, getting a recipe, getting all recipes, updating a recipe, and updating a favorite


### UTIL:

	RecipeDashboard/Dashboard/Utils/CategoryList.cs: creates the dropdown selections for filtering of a category



*********************
#### FUTURE WORK
*********************

- Implement sign up and login with a Users table and Account controller

- Upload and retrieve images of a recipe

- Add Favorites column to Users table so that a User would have a list of Favorites

- Landing page

- Sharing of a recipe

- Searching of a recipe

- More input validations and formatting

- Style the step numbers and implement it so you could click the step and it would form a checkmark (this would be useful to check off steps while cooking)