using Production.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Interfaces
{
    public interface IWorkersRepository
    {
        Task<IEnumerable<Worker>> GetWorkers();
        Task<Worker> GetWorker(int id);
    }
}
