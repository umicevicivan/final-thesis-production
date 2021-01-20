using AutoMapper;
using Production.API.Interfaces;
using Production.Domen;
using Production.Domen.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Production.API.UseCases
{
    public class ProdictToUpdateUseCase
    {
        private readonly IProductsRepository _repo;
        private readonly IMapper _mapper;
        public bool ok = false;
        public string error;

        public ProdictToUpdateUseCase(IProductsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async void Handle(int id, ProductToUpdateDTO product)
        {
            UnitOfMeasure um = new UnitOfMeasure();
            var productFromRepo = await _repo.GetProduct(id);
            if(productFromRepo == null)
            {
                error = "Product does not exsist";
                return;
            }
            if (await _repo.ProductExsists(product.Name) && product.Name != productFromRepo.Name)
            {
                error = "Product already exsists with that name";
                return;
            }
            //product.UnitOfMeasureID = product.UnitOfMeasure.UnitOfMeasureId;
            //product.UnitOfMeasure = null;

            _mapper.Map(product, productFromRepo);

            if (await _repo.SaveAll())
            {
                ok = true;
                return;
            }
            error = "Updating user failed on save";
        }
    }
}
