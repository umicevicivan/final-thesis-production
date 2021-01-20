using Production.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class GetProductUseCase
    {
        private readonly IProductsRepository _repo;
        public dynamic product;

        public GetProductUseCase(IProductsRepository repo)
        {
            _repo = repo;
        }
        public async void Handle(int id)
        {

            product = await _repo.GetProduct(id);
        }
    }
}
