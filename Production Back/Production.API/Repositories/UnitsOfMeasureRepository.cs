using Microsoft.EntityFrameworkCore;
using Production.API.Data;
using Production.API.Interfaces;
using Production.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Repositories
{
    public class UnitsOfMeasureRepository : IUnitsOfMeasureRepository
    {
        private readonly DataContext _context;

        public UnitsOfMeasureRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<UnitOfMeasure>> GetUnitsOfMeasure()
        {
            var unitsOfMeasure = await _context.UnitsOfMeasure.ToListAsync();

            return unitsOfMeasure;

        }

        public async Task<UnitOfMeasure> GetUnitOfMeasure(int id)
        {
            var product = await _context.UnitsOfMeasure.FirstOrDefaultAsync(u => u.UnitOfMeasureId == id);
            return product;
        }
    }
}
