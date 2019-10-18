using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepData.DataModels;
using Microsoft.EntityFrameworkCore;


namespace FoodPrepData.Operations
{
    public class ServingSizeOperations
    {
        private readonly FoodPrepContext _context;

        public ServingSizeOperations(FoodPrepContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServingSize>> GetAllServingSizes()
        {
            return await _context.ServingSize.ToListAsync();
        }

        public async Task<ServingSize> GetServingSize(int id)
        {
            var servingSize = await _context.ServingSize.FindAsync(id);
            if (servingSize == null)
                return new ServingSize();

            return servingSize;
        }

        public async Task<bool> UpdateServingSize(int id, ServingSize servingSize)
        {
            if (id != servingSize.ID)
                return false;

            _context.Entry(servingSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServingSizeExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<ServingSize> InsertServingSize(ServingSize servingSize)
        {
            _context.ServingSize.Add(servingSize);
            await _context.SaveChangesAsync();

            return servingSize;
        }

        public bool ServingSizeExists(string name)
        {
            return _context.ServingSize.Any(e => e.Name == name);
        }

        private bool ServingSizeExists(int id)
        {
            return _context.ServingSize.Any(e => e.ID == id);
        }
    }
}
