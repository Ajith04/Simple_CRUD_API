
using DotNetCRUD.Models;

namespace DotNetCRUD.IRepositories.IProductRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllProductsAsync();
        Task<Products> GetProductByIdAsync(Guid id);
        Task<Products> AddProductAsync(Products product);
        Task UpdateProductAsync(Products product);
        Task DeleteProductAsync(Guid id);
    }
}
