using Production.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class GetPlansUseCase
    {
        private readonly IAnnualProductionPlanRepository _repo;
        public dynamic plans;

        public GetPlansUseCase(IAnnualProductionPlanRepository repo)
        {
            _repo = repo;
        }
        public async void Handle()
        {
            plans = await _repo.GetPlans();
        }
    }
}
