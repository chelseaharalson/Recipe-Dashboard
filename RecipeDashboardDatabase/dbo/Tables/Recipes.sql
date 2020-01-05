CREATE TABLE [dbo].[Recipes] (
    [RecipeId]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50)  NOT NULL,
    [Ingredients]  VARCHAR (MAX) NOT NULL,
    [Instructions] VARCHAR (MAX) NOT NULL,
    [Category]     VARCHAR (MAX) NOT NULL,
    [CookTime]     VARCHAR (50)  NOT NULL,
    [PrepTime]     VARCHAR (50)  NOT NULL,
    [Image]        IMAGE         NULL,
    [Description] VARCHAR(MAX) NOT NULL, 
    [Notes] VARCHAR(MAX) NULL, 
    [Servings] INT NOT NULL, 
    [Favorite] BIT NULL, 
    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([RecipeId] ASC)
);

