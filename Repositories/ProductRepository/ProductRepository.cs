using DotNetCRUD.Database;
using DotNetCRUD.IRepositories.IProductRepository;
using DotNetCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCRUD.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ABCDbContext _context;

        public ProductRepository(ABCDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> GetProductByIdAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }
            return product;
        }

        public async Task<Products> AddProductAsync(Products product)
        {
            var data = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task UpdateProductAsync(Products product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
