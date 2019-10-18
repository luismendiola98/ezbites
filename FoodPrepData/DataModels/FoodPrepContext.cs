using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodPrepData.DataModels
{
    public class FoodPrepContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<EstimatedCost> EstimatedCost { get; set; }
        public DbSet<ServingSize> ServingSize { get; set; }
        public DbSet<QuantityType> QuantityType { get; set; }

        public FoodPrepContext(DbContextOptions<FoodPrepContext> options) : base(options) { }

    }
}
