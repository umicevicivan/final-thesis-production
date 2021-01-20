using AutoMapper;
using Production.API.Interfaces;
using Production.Domen;
using Production.Domen.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class AnnualPlanSaveUseCase
    {
        private readonly IAnnualProductionPlanRepository _repo;
        private readonly IMapper _mapper;
        public string error = null;

        public AnnualPlanSaveUseCase(IAnnualProductionPlanRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async void Handle(AnnualProductionPlanDTO plan)
        {

            AnnualProductionPlan planToSave = new AnnualProductionPlan();

            _mapper.Map(plan, planToSave);
            _repo.Add(planToSave);
            //ovo je magija

            if (await _repo.SaveAll())
            {
                return;
            }
            error = "Saving plan failed on save";
            //ovo dole nista ne mora, mapper radi sve sam
            /*            if (plan == null)
                        {
                            error = "There was no plan to save";
                            return;
                        }
                        if (await _repo.PlanExsists(plan.Id))
                        {
                            error = "Plan already exsists";
                            return;
                        }
                        _repo.Add(plan);
                        PlanItemSaveUseCase useCase = new PlanItemSaveUseCase(_repoItem);
                        foreach(PlanItem item in plan.PlanItems)
                        {
                            item.AnnualProductionPlan = plan;
                            useCase.Handle(item);
                            if(useCase.error != null)
                            {
                                error = "There was an error in saving items";
                                return;
                            }
                        }
                        Task<bool> checkPlan = _repo.SaveAll();
                        if(checkPlan.Result == true)
                        {
                            return;
                        }
                        error = "There was an error in saving plan";
                        return;*/

        }
    }
}
