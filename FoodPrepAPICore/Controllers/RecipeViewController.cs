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
    public class RecipeViewController : ControllerBase
    {
        private RecipeViewLogic _logic;

        public RecipeViewController(FoodPrepContext context)
        {
            _logic = new RecipeViewLogic(context);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<List<RecipeSimpleView>>> RetrieveRecipeByCategories(List<int> categoryIDs)
        {
            return await _logic.GetSimpleRecipesByCategoryAsync(categoryIDs);
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeFullView>> GetFullRecipe(int id)
        {
            var recipe = await _logic.GetFullRecipeAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }
    }
}
