using Microsoft.EntityFrameworkCore;
using Production.API.Data;
using Production.API.Interfaces;
using Production.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Repositories
{
    public class AnnualProductionPlanRepository : IAnnualProductionPlanRepository
    {
        private readonly DataContext _context;

        public AnnualProductionPlanRepository(DataContext context)
        {
            _context = context;

        }

        public void Add(AnnualProductionPlan plan)
        {

            _context.AnnualProductionPlans.Add(plan);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<AnnualProductionPlan> GetPlan(int id)
        {
            var plan = await _context.AnnualProductionPlans.Include(i => i.PlanItems).ThenInclude(pi => pi.Product).Include(w => w.Worker).FirstOrDefaultAsync(p => p.Id == id);
            return plan;
        }

        public async Task<IEnumerable<AnnualProductionPlan>> GetPlans()
        {
            var plans = await _context.AnnualProductionPlans.Include(i => i.PlanItems).Include(w => w.Worker).ToListAsync();

            return plans;
        }

        public async Task<bool> SaveAll()
        {

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> PlanExsists(int id)
        {
            if (await _context.AnnualProductionPlans.AnyAsync(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

    }
}
