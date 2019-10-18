using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodPrepData.DataModels;
using Microsoft.EntityFrameworkCore;


namespace FoodPrepData.Operations
{
    public class EstimatedCostOperations
    {
        private readonly FoodPrepContext _context;

        public EstimatedCostOperations(FoodPrepContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstimatedCost>> GetAllEstimatedCost()
        {
            return await _context.EstimatedCost.ToListAsync();
        }

        public async Task<EstimatedCost> GetEstimatedCost(int id)
        {
            var estimatedCost = await _context.EstimatedCost.FindAsync(id);
            if (estimatedCost == null)
                return new EstimatedCost();

            return estimatedCost;
        }

        public async Task<bool> UpdateEstimatedCost(int id, EstimatedCost estimatedCost)
        {
            if (id != estimatedCost.ID)
                return false;

            _context.Entry(estimatedCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstimatedCostExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<EstimatedCost> InsertEstimatedCost(EstimatedCost estimatedCost)
        {
            _context.EstimatedCost.Add(estimatedCost);
            await _context.SaveChangesAsync();

            return estimatedCost;
        }

        public bool EstimatedCostsExists(string name)
        {
            return _context.EstimatedCost.Any(e => e.Name == name);
        }

        private bool EstimatedCostExists(int id)
        {
            return _context.EstimatedCost.Any(e => e.ID == id);
        }
    }
}
