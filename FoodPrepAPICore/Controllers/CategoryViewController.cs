using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodPrepAPICore.AppLogic;
using FoodPrepAPICore.Models;
using FoodPrepData.DataModels;

namespace FoodPrepAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryViewController : ControllerBase
    {
        private CategoryViewLogic _logic;

        public CategoryViewController(FoodPrepContext context)
        {
            _logic = new CategoryViewLogic(context);
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryView>>> GetCategoryViews()
        {
            return await _logic.GetCategoriesAsync();
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryView>> GetCategory(int id)
        {
            var category = await _logic.GetCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Recipes/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        //{
        //    if (id != recipe.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(recipe).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RecipeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Recipes
        //[HttpPost]
        //public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        //{
        //    _context.Recipes.Add(recipe);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRecipe", new { id = recipe.ID }, recipe);
        //}

        // DELETE: api/Recipes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
        //{
        //    var recipe = await _context.Recipes.FindAsync(id);
        //    if (recipe == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Recipes.Remove(recipe);
        //    await _context.SaveChangesAsync();

        //    return recipe;
        //}

        //private bool RecipeExists(int id)
        //{
        //    return _context.Recipes.Any(e => e.ID == id);
        //}
    }
}
