using Production.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class AnnualPlanToDeleteUseCase
    {
        private readonly IAnnualProductionPlanRepository _repo;
        public string error = null;

        public AnnualPlanToDeleteUseCase(IAnnualProductionPlanRepository repo)
        {
            _repo = repo;
        }
        public async void Handle(int id)
        {
            var plan = await _repo.GetPlan(id);
            if (plan == null)
            {
                error = "Product is not found";
                return;

            }
            _repo.Delete(plan);

        }
    }
}
