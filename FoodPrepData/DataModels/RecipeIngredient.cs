using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodPrepData.DataModels
{
    public class RecipeIngredient
    {
        [Key]
        public int ID { get; set; }
        public int RecipeID { get; set; }
        [ForeignKey("RecipeID")]
        public Recipe Recipe { get; set; }
        public int IngredientID { get; set; }
        [ForeignKey("IngredientID")]
        public Ingredient Ingredient { get; set; }
        public float Quantity { get; set; }
        public int QuantityTypeID { get; set; }
        [ForeignKey("QuantityTypeID")]
        public QuantityType QuantityType { get; set; }
    }
}
