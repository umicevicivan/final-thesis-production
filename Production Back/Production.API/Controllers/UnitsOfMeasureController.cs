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

namespace Production.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsOfMeasureController : ControllerBase
    {
        private readonly IUnitsOfMeasureRepository _repo;
        private readonly IMapper _mapper;

        public UnitsOfMeasureController(IUnitsOfMeasureRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUnitsOfMeasure()
        {
            GetUnitsOfMeasureUseCase useCase = new GetUnitsOfMeasureUseCase(_repo);
            useCase.Handle();
            if (useCase.unitsOfMeasure == null)
            {
                return BadRequest("There was an error");
            }
            return Ok(useCase.unitsOfMeasure);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnitOfMeasure(int id)
        {
            GetUnitOfMeasureUseCase useCase = new GetUnitOfMeasureUseCase(_repo);
            useCase.Handle(id);
            if (useCase.unitOfMeasure == null)
            {
                return BadRequest("Unit of measure does not exsis");
            }
            return Ok(useCase.unitOfMeasure);
        }
    }
}
