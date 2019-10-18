using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepAPICore.Models;
using FoodPrepData.DataModels;
using FoodPrepData.Operations;

namespace FoodPrepAPICore.AppLogic
{
    public class RecipeViewLogic
    {
        private readonly FoodPrepContext _context;

        public RecipeViewLogic(FoodPrepContext context)
        {
            _context = context;
        }

        public async Task<List<RecipeSimpleView>> GetSimpleRecipesByCategoryAsync(List<int> categoryIDs)
        {
            var recipeSimpleList = new List<RecipeSimpleView>();

            var recipeOperations = new RecipeOperations(_context);
            var recipeCategoryOperations = new RecipeCategoryOperations(_context);
            
            var recipeCategories = await recipeCategoryOperations.GetAllRecipeCategories();
            var recipeCatsFiltered = recipeCategories.Where(x => categoryIDs.Contains(x.CategoryID))
                                                        .GroupBy(g => g.RecipeID)
                                                            .Select(grp => grp.First()).ToList();
            
            foreach (var recipeCat in recipeCatsFiltered)
            {
                var recipe = await recipeOperations.GetRecipe(recipeCat.RecipeID);
                var recipeView = new RecipeSimpleView(recipe);
                recipeSimpleList.Add(recipeView);
            }

            return recipeSimpleList;
        }


        public async Task<RecipeFullView> GetFullRecipeAsync(int recipeID)
        {
            var ingredients = new List<Ingredient>();
            var categories = new List<Category>();

            var recipeOperations = new RecipeOperations(_context);
            var recipeCategoryOperations = new RecipeCategoryOperations(_context);
            var recipeIngredientOperations = new RecipeIngredientOperations(_context);
            var categoryOperations = new CategoryOperations(_context);
            var ingredientOperations = new IngredientOperations(_context);


            var recipe = await recipeOperations.GetRecipe(recipeID);

            var recipeCats = await recipeCategoryOperations.GetAllRecipeCategories();
            var recipeCatsFiltered = recipeCats.Where(x => x.RecipeID == recipeID).ToList();
            foreach (var recipeCat in recipeCatsFiltered)
            {
                var category = await categoryOperations.GetCategory(recipeCat.CategoryID);
                categories.Add(category);
            }

            var recipeIngs = await recipeIngredientOperations.GetAllRecipeIngredients();
            var recipeIngsFiltered = recipeIngs.Where(x => x.RecipeID == recipeID).ToList();
            foreach (var recipeIng in recipeIngsFiltered)
            {
                var ingredient = await ingredientOperations.GetIngredient(recipeIng.IngredientID);
                ingredients.Add(ingredient);
            }

            var recipeFullView = new RecipeFullView(recipe, ingredients, categories);
            return recipeFullView;
        }
    }
}
