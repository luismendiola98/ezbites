using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepData.DataModels;
using Microsoft.EntityFrameworkCore;


namespace FoodPrepData.Operations
{
    public class RecipeIngredientOperations
    {
        private readonly FoodPrepContext _context;

        public RecipeIngredientOperations(FoodPrepContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecipeIngredient>> GetAllRecipeIngredients()
        {
            return await _context.RecipeIngredients.ToListAsync();
        }

        public async Task<RecipeIngredient> GetRecipeIngredient(int id)
        {
            var recipeIngredient = await _context.RecipeIngredients.FindAsync(id);
            if (recipeIngredient == null)
                return new RecipeIngredient();

            return recipeIngredient;
        }

        public async Task<bool> UpdateRecipeIngredient(int id, RecipeIngredient recipeIngredient)
        {
            if (id != recipeIngredient.ID)
                return false;

            _context.Entry(recipeIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeIngredientExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }



        public async Task<RecipeIngredient> InsertRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            _context.RecipeIngredients.Add(recipeIngredient);
            await _context.SaveChangesAsync();

            return recipeIngredient;
        }

        private bool RecipeIngredientExists(int id)
        {
            return _context.RecipeIngredients.Any(e => e.ID == id);
        }
    }
}
