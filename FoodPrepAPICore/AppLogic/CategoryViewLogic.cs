using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepAPICore.Models;
using FoodPrepData.DataModels;
using FoodPrepData.Operations;

namespace FoodPrepAPICore.AppLogic
{
    public class CategoryViewLogic
    {
        private readonly FoodPrepContext _context;

        public CategoryViewLogic(FoodPrepContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryView>> GetCategoriesAsync()
        {
            var categoryViews = new List<CategoryView>();
            var categoryOperations = new CategoryOperations(_context);

            var categories = await categoryOperations.GetAllCategories();
            foreach (var category in categories)
            {
                categoryViews.Add(new CategoryView(category));
            }
            return categoryViews;
        }

        public async Task<CategoryView> GetCategoryAsync(int id)
        {
            var categoryOperations = new CategoryOperations(_context);

            var category = await categoryOperations.GetCategory(id);
            var categoryView = new CategoryView(category);

            return categoryView;
        }
    }
}
