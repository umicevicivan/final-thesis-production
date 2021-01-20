using Production.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class GetWorkerUseCase
    {
        private readonly IWorkersRepository _repo;
        public dynamic worker;

        public GetWorkerUseCase(IWorkersRepository repo)
        {
            _repo = repo;
        }
        public async void Handle(int id)
        {

            worker = await _repo.GetWorker(id);
        }
    }
}
