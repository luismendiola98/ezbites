using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepData.DataModels;
using Microsoft.EntityFrameworkCore;

namespace FoodPrepData.Operations
{
    public class RecipeCategoryOperations
    {
        private readonly FoodPrepContext _context;

        public RecipeCategoryOperations(FoodPrepContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecipeCategory>> GetAllRecipeCategories()
        {
            return await _context.RecipeCategories.ToListAsync();
        }

        public async Task<RecipeCategory> GetRecipeCategory(int id)
        {
            var recipeRecipeCategory = await _context.RecipeCategories.FindAsync(id);
            if (recipeRecipeCategory == null)
                return new RecipeCategory();

            return recipeRecipeCategory;
        }

        public async Task<bool> UpdateRecipeCategory(int id, RecipeCategory recipeRecipeCategory)
        {
            if (id != recipeRecipeCategory.ID)
                return false;

            _context.Entry(recipeRecipeCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeCategoryExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<RecipeCategory> InsertRecipeCategory(RecipeCategory recipeRecipeCategory)
        {
            _context.RecipeCategories.Add(recipeRecipeCategory);
            await _context.SaveChangesAsync();

            return recipeRecipeCategory;
        }

        private bool RecipeCategoryExists(int id)
        {
            return _context.RecipeCategories.Any(e => e.ID == id);
        }
    }
}
