using AutoMapper;
using Production.API.Interfaces;
using Production.Domen.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class AnnualPlanToUpdateUseCase
    {
        private readonly IAnnualProductionPlanRepository _repo;
        private readonly IMapper _mapper;
        public bool ok = false;
        public string error;

        public AnnualPlanToUpdateUseCase(IAnnualProductionPlanRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async void Handle(int id, AnnualProductionPlanDTO planToUpdateDTO)
        {

            var planFromRepo = await _repo.GetPlan(id);
            if (planFromRepo == null)
            {
                error = "Plan does not exsist";
                return;
            }
            _mapper.Map(planToUpdateDTO, planFromRepo);
            //ovo je magija

            if (await _repo.SaveAll())
            {
                ok = true;
                return;
            }
            error = "Updating plan failed on save";
        }
    }
}
