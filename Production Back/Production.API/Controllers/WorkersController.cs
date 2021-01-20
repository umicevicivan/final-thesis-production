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
    public class WorkersController : ControllerBase
    {
        private readonly IWorkersRepository _repo;
        private readonly IMapper _mapper;

        public WorkersController(IWorkersRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkers()
        {
            GetWorkersUseCase useCase = new GetWorkersUseCase(_repo);
            useCase.Handle();
            if (useCase.workers == null)
            {
                return BadRequest("There was an error");
            }
            return Ok(useCase.workers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorker(int id)
        {
            GetWorkerUseCase useCase = new GetWorkerUseCase(_repo);
            useCase.Handle(id);
            if (useCase.worker == null)
            {
                return BadRequest("Worker does not exsis");
            }
            return Ok(useCase.worker);
        }
    }
}
