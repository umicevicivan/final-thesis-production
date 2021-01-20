using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Production.API.Interfaces;
using Production.API.UseCases;
using Production.Domen;
using Production.Domen.DTOs;

namespace Production.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsRepository _repo;
        private readonly IMapper _mapper;

        public ProductController(IProductsRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            GetProductsUseCase useCase = new GetProductsUseCase(_repo);
            useCase.Handle();
            if (useCase.products == null)
            {
                return BadRequest("There was an error");
            }
            return Ok(useCase.products);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductToSaveDTO product)
        {

            ProductSaveUseCase useCase = new ProductSaveUseCase(_repo, _mapper);
            useCase.Handle(product);
            if(useCase.error == null)
            {
                return Ok();
            }
            return BadRequest(useCase.error);

        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            GetProductUseCase useCase = new GetProductUseCase(_repo);
            useCase.Handle(id);
            if (useCase.product == null) 
            {
                return BadRequest("Product does not exsis");    
            }
            return Ok(useCase.product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ProductDeleteUseCase useCase = new ProductDeleteUseCase(_repo);
            useCase.Handle(id);
            if(useCase.error == null)
            {
                return Ok();
            }
            return BadRequest(useCase.error);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductToUpdateDTO product)
        {
            ProdictToUpdateUseCase useCase = new ProdictToUpdateUseCase(_repo, _mapper);
            useCase.Handle(id, product);
            if(useCase.ok == true)
            {
                return NoContent();
            }
            return BadRequest(useCase.error);
            

        }


    }
}
