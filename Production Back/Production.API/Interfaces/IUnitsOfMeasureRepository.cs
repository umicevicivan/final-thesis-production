using Production.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Interfaces
{
    public interface IUnitsOfMeasureRepository
    {
        Task<IEnumerable<UnitOfMeasure>> GetUnitsOfMeasure();
        Task<UnitOfMeasure> GetUnitOfMeasure(int id);
    }
}
