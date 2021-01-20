using Production.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class GetUnitsOfMeasureUseCase
    {
        private readonly IUnitsOfMeasureRepository _repo;
        public dynamic unitsOfMeasure;

        public GetUnitsOfMeasureUseCase(IUnitsOfMeasureRepository repo)
        {
            _repo = repo;
        }
        public async void Handle()
        {
            unitsOfMeasure = await _repo.GetUnitsOfMeasure();
        }
    }
}
