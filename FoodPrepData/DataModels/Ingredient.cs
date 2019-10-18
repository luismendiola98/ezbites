using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodPrepData.DataModels
{
    public class Ingredient
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public string Info { get; set; }

 
    }
}
