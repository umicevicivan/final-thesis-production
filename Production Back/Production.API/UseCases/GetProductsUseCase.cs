using Production.API.Interfaces;
using Production.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class GetProductsUseCase
    {
        private readonly IProductsRepository _repo;
        public dynamic products;

        public GetProductsUseCase(IProductsRepository repo)
        {
            _repo = repo;
        }
        public async void Handle()
        {
            products = await _repo.GetProducts();
        }
    }
}
