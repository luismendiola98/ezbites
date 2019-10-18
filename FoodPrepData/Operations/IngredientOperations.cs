using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepData.DataModels;
using Microsoft.EntityFrameworkCore;

namespace FoodPrepData.Operations
{
    public class IngredientOperations
    {
        private readonly FoodPrepContext _context;

        public IngredientOperations(FoodPrepContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
                return new Ingredient();

            return ingredient;
        }

        public async Task<bool> UpdateIngredient(int id, Ingredient ingredient)
        {
            if (id != ingredient.ID)
                return false;

            _context.Entry(ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<Ingredient> InsertIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

            return ingredient;
        }

        public async Task<Ingredient> FindIngredientByName(string name)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<bool> DeleteIngredient(Ingredient delIngredient)
        {
            var ingredient = await _context.Ingredients.FindAsync(delIngredient.ID);
            if (ingredient == null)
                return false;

            var recipeIngredients = await _context.RecipeIngredients.ToListAsync();
            foreach (var recipeIngredient in recipeIngredients.Where(x => x.IngredientID == ingredient.ID))
            {
                _context.RecipeIngredients.Remove(recipeIngredient);
            }

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool IngredientsExists(string name)
        {
            return _context.Ingredients.Any(e => e.Name == name);
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.ID == id);
        }
    }
}
