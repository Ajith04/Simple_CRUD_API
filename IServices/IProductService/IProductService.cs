using DotNetCRUD.DTO.RequestDTO.Product;
using DotNetCRUD.DTO.ResponseDTO.Product;
using DotNetCRUD.Models;

namespace DotNetCRUD.IServices.IProductService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponceDTO>> GetAllProductsAsync();
        Task<Products> GetProductByIdAsync(Guid id);
        Task<ProductResponceDTO> AddProductAsync(ProductRequestDTO product);
        Task UpdateProductAsync(Products product);
        Task DeleteProductAsync(Guid id);
    }
}
