using System;
using System.Collections;
using System.Collections.Generic;

namespace ezbites.Models
{
    public class RecipeFullView
    {
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string RecipeSteps { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<CategoryView> Categories { get; set; }

        public RecipeFullView()
        {

        }

    }
}
