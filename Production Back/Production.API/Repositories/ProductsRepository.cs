using Microsoft.EntityFrameworkCore;
using Production.API.Data;
using Production.API.Interfaces;
using Production.Domen;
using Production.Domen.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;

        public ProductsRepository(DataContext context)
        {
            _context = context;

        }

        public void Add(Product product)
        {

             _context.Products.Add(product);
             _context.SaveChanges();
        }

        public  void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.Include(u => u.UnitOfMeasure).FirstOrDefaultAsync(u => u.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _context.Products.Include(u => u.UnitOfMeasure).ToListAsync();

            return products;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ProductExsists(string name)
        {
            if (await _context.Products.AnyAsync(x => x.Name == name))
            {
                return true;
            }
            return false;
        }

    }
}

