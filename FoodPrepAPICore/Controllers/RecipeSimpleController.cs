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
    public class RecipeSimpleController : ControllerBase
    {
        private RecipeViewLogic _logic;

        public RecipeSimpleController(FoodPrepContext context)
        {
            _logic = new RecipeViewLogic(context);
        }

        // GET: api/RecipesSimple/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<RecipeSimpleView>>> GetRecipeSimples(int id)
        {
            var list = new List<int>();
            list.Add(id);

            return await _logic.GetSimpleRecipesByCategoryAsync(list);
        }
    }
}
