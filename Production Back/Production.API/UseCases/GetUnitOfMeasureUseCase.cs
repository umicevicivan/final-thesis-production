using Production.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class GetUnitOfMeasureUseCase
    {
        private readonly IUnitsOfMeasureRepository _repo;
        public dynamic unitOfMeasure;

        public GetUnitOfMeasureUseCase(IUnitsOfMeasureRepository repo)
        {
            _repo = repo;
        }
        public async void Handle(int id)
        {

            unitOfMeasure = await _repo.GetUnitOfMeasure(id);
        }
    }
}
