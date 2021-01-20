using Production.Domen;
using Production.Domen.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Interfaces
{
    public interface IProductsRepository
    {

        void Add(Product product);
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<bool> ProductExsists(string name);

    }
}
