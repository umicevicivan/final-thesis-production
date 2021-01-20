using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Production.API.Interfaces;
using Production.API.UseCases;
using Production.Domen;
using Production.Domen.DTOs;

namespace Production.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnnualProductionPlanController : ControllerBase
    {
        private readonly IAnnualProductionPlanRepository _repo;
        private readonly IMapper _mapper;

        public AnnualProductionPlanController(IAnnualProductionPlanRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            GetPlansUseCase useCase = new GetPlansUseCase(_repo);
            useCase.Handle();
            if (useCase.plans == null)
            {
                return BadRequest("There was an error");
            }
            return Ok(useCase.plans);
        }

/*        [HttpPost]
        public async Task<IActionResult> AddNewAnnualPlan(AnnualProductionPlan plan)
        {

            AnnualPlanSaveUseCase useCase = new AnnualPlanSaveUseCase(_repo, _repoItem);
            useCase.Handle(plan);
            if (useCase.error == null)
            {
                return Ok();
            }
            return BadRequest(useCase.error);

        }*/

        [HttpPost]
        public async Task<IActionResult> AddNewAnnualPlan(AnnualProductionPlanDTO planToAdd)
        {

            AnnualPlanSaveUseCase useCase = new AnnualPlanSaveUseCase(_repo, _mapper);
            useCase.Handle(planToAdd);
            if (useCase.error == null)
            {
                return Ok();
            }
            return BadRequest(useCase.error);

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Getplan(int id)
        {
            GetPlanUseCase useCase = new GetPlanUseCase(_repo);
            useCase.Handle(id);
            if (useCase.product == null)
            {
                return BadRequest("Plan does not exsis");
            }
            return Ok(useCase.product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlan(int id, AnnualProductionPlanDTO planToUpdate)
        {
            AnnualPlanToUpdateUseCase useCase = new AnnualPlanToUpdateUseCase(_repo, _mapper);
            useCase.Handle(id, planToUpdate);
            if (useCase.ok == true)
            {
                return NoContent();
            }
            return BadRequest(useCase.error);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            AnnualPlanToDeleteUseCase useCase = new AnnualPlanToDeleteUseCase(_repo);
            useCase.Handle(id);
            if (useCase.error == null)
            {
                return Ok();
            }
            return BadRequest(useCase.error);
        }


    }
}
