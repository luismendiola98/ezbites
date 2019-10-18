using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepData.DataModels;
using Microsoft.EntityFrameworkCore;


namespace FoodPrepData.Operations
{
    public class RecipeOperations
    {
        private readonly FoodPrepContext _context;

        public RecipeOperations(FoodPrepContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
                return new Recipe();

            return recipe;
        }

        public async Task<bool> UpdateRecipe(int id, Recipe recipe)
        {
            if (id != recipe.ID)
                return false;

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<Recipe> InsertRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return recipe;
        }

        public async Task<bool> DeleteRecipe(Recipe delRecipe)
        {
            var recipe = await _context.Recipes.FindAsync(delRecipe.ID);
            if (recipe == null)
                return false;

            var recipeCategories = await _context.RecipeCategories.ToListAsync();
            foreach (var recipeCategory in recipeCategories.Where(x => x.RecipeID == recipe.ID))
            {
                _context.RecipeCategories.Remove(recipeCategory);
            }

            var recipeIngredients = await _context.RecipeIngredients.ToListAsync();
            foreach (var recipeIngredient in recipeIngredients.Where(x => x.RecipeID == recipe.ID))
            {
                _context.RecipeIngredients.Remove(recipeIngredient);
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool RecipeExists(string name)
        {
            return _context.Recipes.Any(e => e.Name == name);
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.ID == id);
        }

    }
}
