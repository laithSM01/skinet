using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context) { 
        _context = context;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(b => b.ProductBrand)
                .Include(t => t.ProductType)
                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var products = await _context.Products
                .Include(b => b.ProductBrand)
                .Include(t => t.ProductType)
                .ToListAsync();
            return products;
        }
    }
}
