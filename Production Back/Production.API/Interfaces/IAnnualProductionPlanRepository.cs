using Production.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Interfaces
{
    public interface IAnnualProductionPlanRepository
    {
        void Add(AnnualProductionPlan plan);
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<AnnualProductionPlan>> GetPlans();
        Task<AnnualProductionPlan> GetPlan(int id);
        Task<bool> PlanExsists(int id);
    }
}
