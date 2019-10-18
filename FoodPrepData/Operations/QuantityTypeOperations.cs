using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepData.DataModels;
using Microsoft.EntityFrameworkCore;

namespace FoodPrepData.Operations
{
    public class QuantityTypeOperations
    {
        private readonly FoodPrepContext _context;

        public QuantityTypeOperations(FoodPrepContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuantityType>> GetAllQuantityTypes()
        {
            return await _context.QuantityType.ToListAsync();
        }

        public async Task<QuantityType> GetQuantityType(int id)
        {
            var quantityType = await _context.QuantityType.FindAsync(id);
            if (quantityType == null)
                return new QuantityType();

            return quantityType;
        }

        public async Task<bool> UpdateQuantityType(int id, QuantityType quantityType)
        {
            if (id != quantityType.ID)
                return false;

            _context.Entry(quantityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuantityTypeExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<QuantityType> InsertQuantityType(QuantityType quantityType)
        {
            _context.QuantityType.Add(quantityType);
            await _context.SaveChangesAsync();

            return quantityType;
        }

        public bool QuantityTypeExists(string name)
        {
            return _context.QuantityType.Any(e => e.Name == name);
        }

        private bool QuantityTypeExists(int id)
        {
            return _context.QuantityType.Any(e => e.ID == id);
        }
    }
}
