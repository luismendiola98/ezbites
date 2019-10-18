using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepData.DataModels;
using FoodPrepData.Operations;

namespace FoodPrepAPICore.Models
{
    public class CategoryView
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public CategoryView()
        {

        }

        public CategoryView(Category category)
        {
            MapCategoryView(category);
        }

        public void MapCategoryView(Category category)
        {
            this.CategoryID = category.ID;
            this.Name = category.Name;
        }
    }
}
