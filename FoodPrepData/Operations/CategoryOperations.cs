﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepData.DataModels;
using Microsoft.EntityFrameworkCore;


namespace FoodPrepData.Operations
{
    public class CategoryOperations
    {
        private readonly FoodPrepContext _context;

        public CategoryOperations(FoodPrepContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return new Category();

            return category;
        }

        public async Task<bool> UpdateCategory(int id, Category category)
        {
            if (id != category.ID)
                return false;

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<Category> InsertCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public bool CategoryExists(string name)
        {
            return _context.Categories.Any(e => e.Name == name);
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.ID == id);
        }
    }
}
