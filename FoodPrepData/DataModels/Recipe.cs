using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FoodPrepData.DataModels
{
    public class Recipe
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }
        public string Info { get; set; }
        public int ServingSizeID { get; set; }
        [ForeignKey("ServingSizeID")]
        public ServingSize ServingSize { get; set; }
        public int EstimatedCostID { get; set; }
        [ForeignKey("EstimatedCostID")]
        public EstimatedCost EstimatedCost { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string RecipeSteps { get; set; }
    }
}
