using AutoMapper;
using Production.API.Interfaces;
using Production.Domen;
using Production.Domen.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.UseCases
{
    public class ProductSaveUseCase
    {
        private readonly IProductsRepository _repo;
        private readonly IMapper _mapper;
        public string error = null;

        public ProductSaveUseCase(IProductsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async void Handle(ProductToSaveDTO productToSave)
        {
            if(productToSave == null)
            {
                error = "There was no product to save";
                return;
            }
            if (await _repo.ProductExsists(productToSave.Name))
            {
                error = "Product already exsists";
                return;
            }
            Product product = new Product();
            _mapper.Map(productToSave, product);
            product.UnitOfMeasureID = product.UnitOfMeasure.UnitOfMeasureId;
            product.UnitOfMeasure = null;
            _repo.Add(product);
            
        }
    }
}
