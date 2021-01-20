using Production.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class GetWorkersUseCase
    {
        private readonly IWorkersRepository _repo;
        public dynamic workers;

        public GetWorkersUseCase(IWorkersRepository repo)
        {
            _repo = repo;
        }
        public async void Handle()
        {
            workers = await _repo.GetWorkers();
        }
    }
}
