using Production.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class GetPlanUseCase
    {
        private readonly IAnnualProductionPlanRepository _repo;
        public dynamic product;

        public GetPlanUseCase(IAnnualProductionPlanRepository repo)
        {
            _repo = repo;
        }
        public async void Handle(int id)
        {

            product = await _repo.GetPlan(id);
        }
    }
}
