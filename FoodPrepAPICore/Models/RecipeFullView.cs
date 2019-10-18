using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepData.DataModels;
using FoodPrepData.Operations;

namespace FoodPrepAPICore.Models
{
    public class RecipeFullView
    {
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string RecipeSteps { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Category> Categories { get; set; }

        public RecipeFullView()
        {

        }

        public RecipeFullView(Recipe recipe, List<Ingredient> ingredients, List<Category> categories)
        {
            MapRecipeFullView(recipe, ingredients, categories);
        }

        public void MapRecipeFullView(Recipe recipe, List<Ingredient> ingredients, List<Category> categories)
        {
            this.RecipeID = recipe.ID;
            this.Name = recipe.Name;
            this.Info = recipe.Info;
            this.RecipeSteps = recipe.RecipeSteps;
            this.Ingredients = ingredients;
            this.Categories = categories;
        }
    }
}
