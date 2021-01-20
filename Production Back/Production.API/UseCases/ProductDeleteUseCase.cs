using Production.API.Interfaces;
using Production.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class ProductDeleteUseCase
    {
        private readonly IProductsRepository _repo;
        public string error = null;

        public ProductDeleteUseCase(IProductsRepository repo)
        {
            _repo = repo;
        }
        public async void Handle(int id)
        {
            var product = await _repo.GetProduct(id);
            if (product == null)
            {
                error = "Product is not found";
                return;

            }
            _repo.Delete(product);

        }
    }
}
