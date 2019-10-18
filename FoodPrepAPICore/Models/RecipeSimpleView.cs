using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepData.DataModels;
using FoodPrepData.Operations;

namespace FoodPrepAPICore.Models
{
    public class RecipeSimpleView
    {
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public RecipeSimpleView()
        {

        }

        public RecipeSimpleView(Recipe recipe)
        {
            MapRecipeView(recipe);
        }

        public void MapRecipeView(Recipe recipe)
        {
            this.RecipeID = recipe.ID;
            this.Name = recipe.Name;
            this.Info = recipe.Info;
        }
    }
}
