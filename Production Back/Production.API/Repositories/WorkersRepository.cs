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
    public class WorkersRepository : IWorkersRepository
    {
        private readonly DataContext _context;

        public WorkersRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Worker>> GetWorkers()
        {
            var workers = await _context.Workers.ToListAsync();

            return workers;

        }

        public async Task<Worker> GetWorker(int id)
        {
            var worker = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);
            return worker;
        }
    }
}
